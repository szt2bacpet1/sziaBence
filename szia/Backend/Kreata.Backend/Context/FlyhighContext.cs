using Flyhigh.Shared.Models;
using Microsoft.EntityFrameworkCore;
namespace Flyhigh.Backend.Context
{
    public class FlyhighContext : DbContext
    {
        public DbSet<Felhasznalo> Felhasznalok { get; set; }
        public DbSet<GepAdatok> Gepek { get; set; }
        public DbSet<Jegy> Jegy { get; set; }
        public DbSet<JegyTipus> JegyTipus { get; set; }

        public DbSet<Repulotarsasag> Reptars { get; set; }
        public DbSet<Countries> Countries { get; set; }
        public DbSet<GepAdatokTipus> GepAdatokTipus { get; set; }
        public DbSet<JogosultsagiSzints> JogosultsagiSzints { get; set; }

        public FlyhighContext(DbContextOptions options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<GepAdatokTipus>()
                .HasMany(gep => gep.GepekTipus)
                .WithOne(g => g.GepAdatokTipus)
                .HasForeignKey(g => g.GepAdatokTipusId)
                .IsRequired(false);

            modelBuilder.Entity<Countries>()
               .HasMany(cr => cr.Repulotarsasags)
               .WithOne(r => r.Countries)
               .HasForeignKey(r => r.CountryId)
               .IsRequired(false);

            modelBuilder.Entity<JogosultsagiSzints>()
                .HasMany(el => el.AllJogosultsagiSzints)
                .WithOne(e => e.JogosultsagiSzints)
                .HasForeignKey(e => e.JogosultsagiSzintId)
                .IsRequired(false);

            modelBuilder.Entity<JegyTipus>()
               .HasMany(gep => gep.JegyTipusok)
               .WithOne(g => g.JegyTipus)
               .HasForeignKey(g => g.JegyId)
               .IsRequired(false);

        }
    }
}