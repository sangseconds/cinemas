using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ProjCinema.Models
{
    public partial class CinemaADS : DbContext
    {
        public CinemaADS()
            : base("name=CinemaADS")
        {
        }

        public virtual DbSet<AD> ADS { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AD>()
                .Property(e => e.AdsID)
                .IsUnicode(false);

            modelBuilder.Entity<AD>()
                .Property(e => e.MovieID)
                .IsUnicode(false);

            modelBuilder.Entity<AD>()
                .Property(e => e.PostID)
                .IsUnicode(false);

            modelBuilder.Entity<AD>()
                .Property(e => e.Banner)
                .IsUnicode(false);
        }
    }
}
