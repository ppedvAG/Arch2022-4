using Microsoft.EntityFrameworkCore;
using ppedv.Hotelity.Model;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("ppedv.Hotelity.Data.EfCore.Tests")]

namespace ppedv.Hotelity.Data.EfCore
{
    internal class EfContext : DbContext
    {
        private readonly string conString;

        public DbSet<Gast> Gaeste => Set<Gast>();
        public DbSet<Buchung> Buchungen => Set<Buchung>();
        public DbSet<Zimmer> Zimmer => Set<Zimmer>();

        public EfContext(string conString = "Server=(localdb)\\mssqllocaldb;Database=Hotelity_DEV;Trusted_Connection=true")
        {
            this.conString = conString;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<Buchung>().HasMany<Zimmer>(x=>x.Zimmer).WithMany(x => x.Buchung);
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(conString);
        }

    }
}