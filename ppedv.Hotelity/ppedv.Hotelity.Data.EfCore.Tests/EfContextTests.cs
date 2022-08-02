using AutoFixture;
using AutoFixture.Kernel;
using FluentAssertions;
using ppedv.Hotelity.Model;
using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace ppedv.Hotelity.Data.EfCore.Tests
{
    public class EfContextTests
    {
        [Fact]
        public void Can_create_DB()
        {
            var con = new EfContext();
            con.Database.EnsureDeleted();

            var result = con.Database.EnsureCreated();

            Assert.True(result);
        }

        [Fact]
        public void Can_CRUD_Gast()
        {
            var gast = new Gast() { Name = $"Fred_{Guid.NewGuid()}" };
            var newName = $"Wilma_{Guid.NewGuid()}";

            using (var con = new EfContext())
            {
                con.Add(gast);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Gaeste.Find(gast.Id);
                Assert.NotNull(loaded);
                Assert.Equal(gast.Name, loaded?.Name);

                loaded.Name = newName;
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Gaeste.Find(gast.Id);
                Assert.Equal(newName, loaded?.Name);

                con.Remove(loaded);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Gaeste.Find(gast.Id);
                Assert.Null(loaded);
            }
        }


        [Fact]
        [Trait("Category", "Systemtest")]
        public void Can_Create_Gast_AutoFix()
        {
            var fix = new Fixture();
            fix.Behaviors.Add(new OmitOnRecursionBehavior());
            fix.Customizations.Add(new PropertyNameOmitter(nameof(Entity.Id)));

            var gast = fix.Create<Gast>();

            using (var con = new EfContext())
            {
                con.Add(gast);
                con.SaveChanges();
            }

            using (var con = new EfContext())
            {
                var loaded = con.Gaeste.Include(x => x.Buchung).ThenInclude(x => x.Zimmer).Where(x => x.Id == gast.Id).First();
                loaded.Should().BeEquivalentTo(gast, x => x.IgnoringCyclicReferences());
            }

        }

        internal class PropertyNameOmitter : ISpecimenBuilder
        {
            private readonly IEnumerable<string> names;

            internal PropertyNameOmitter(params string[] names)
            {
                this.names = names;
            }

            public object Create(object request, ISpecimenContext context)
            {
                var propInfo = request as PropertyInfo;
                if (propInfo != null && names.Contains(propInfo.Name))
                    return new OmitSpecimen();

                return new NoSpecimen();
            }
        }
    }
}