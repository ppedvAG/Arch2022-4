using FluentAssertions;
using Moq;
using ppedv.Hotelity.Model;
using ppedv.Hotelity.Model.Contracts;

namespace ppedv.Hotelity.Logic.Tests
{
    public class CoreTests
    {
        [Fact]
        public void GetAvailableRooms_3_rooms_1_is_booked_results_2_rooms()
        {
            var core = new Core(new TestUnitOfWork());

            var result = core.GetAvailableRooms(DateTime.Now);

            result.Should().HaveCount(2);
        }

        [Fact]
        public void GetAvailableRooms_3_rooms_1_is_booked_results_2_rooms_moq()
        {
            var repoMock = new Mock<IRepository<Zimmer>>();
            repoMock.Setup(x => x.Query()).Returns(() =>
            {
                var r1 = new Zimmer();
                var r2 = new Zimmer();
                var r3 = new Zimmer();

                r2.Buchung.Add(new Buchung() { Buchungsdatum = DateTime.Now });
                return new[] { r1, r2, r3 }.AsQueryable();
            });

            var uowMock = new Mock<IUnitOfWork>();
            uowMock.Setup(x => x.GetRepo<Zimmer>()).Returns(() => repoMock.Object);

            var core = new Core(uowMock.Object);

            var result = core.GetAvailableRooms(DateTime.Now);

            result.Should().HaveCount(2);
        }
    }
}