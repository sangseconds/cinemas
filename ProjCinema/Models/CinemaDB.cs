using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace ProjCinema.Models
{
    public partial class CinemaDB : DbContext
    {
        public CinemaDB()
            : base("name=CinemaDB")
        {
        }

        public virtual DbSet<ADMIN_ACCOUNT> ADMIN_ACCOUNT { get; set; }
        public virtual DbSet<AD> ADS { get; set; }
        public virtual DbSet<BILL> BILLs { get; set; }
        public virtual DbSet<CINEMA> CINEMAs { get; set; }
        public virtual DbSet<CINEMA_IMAGE> CINEMA_IMAGE { get; set; }
        public virtual DbSet<CINEMA_LOCATION> CINEMA_LOCATION { get; set; }
        public virtual DbSet<DEPARTMENT> DEPARTMENTs { get; set; }
        public virtual DbSet<DISCOUNT_CODE> DISCOUNT_CODE { get; set; }
        public virtual DbSet<FEEDBACK> FEEDBACKs { get; set; }
        public virtual DbSet<MOVIE> MOVIEs { get; set; }
        public virtual DbSet<MOVIE_TIME> MOVIE_TIME { get; set; }
        public virtual DbSet<POST> POSTs { get; set; }
        public virtual DbSet<POST_CONTENT> POST_CONTENT { get; set; }
        public virtual DbSet<ROOM> ROOMs { get; set; }
        public virtual DbSet<SEAT> SEATs { get; set; }
        public virtual DbSet<SERVICE> SERVICEs { get; set; }
        public virtual DbSet<SERVICE_TO_CASH> SERVICE_TO_CASH { get; set; }
        public virtual DbSet<TICKET> TICKETs { get; set; }
        public virtual DbSet<TICKET_TYPE> TICKET_TYPE { get; set; }
        public virtual DbSet<USER_ACCOUNT> USER_ACCOUNT { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ADMIN_ACCOUNT>()
                .Property(e => e.AdminPassword)
                .IsUnicode(false);

            modelBuilder.Entity<ADMIN_ACCOUNT>()
                .Property(e => e.DepartmentID)
                .IsUnicode(false);

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

            modelBuilder.Entity<BILL>()
                .Property(e => e.BillID)
                .IsUnicode(false);

            modelBuilder.Entity<BILL>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<BILL>()
                .Property(e => e.TicketSession)
                .IsUnicode(false);

            modelBuilder.Entity<BILL>()
                .Property(e => e.ServiceSession)
                .IsUnicode(false);

            modelBuilder.Entity<BILL>()
                .Property(e => e.CodeID)
                .IsUnicode(false);

            modelBuilder.Entity<CINEMA>()
                .Property(e => e.CinemaID)
                .IsUnicode(false);

            modelBuilder.Entity<CINEMA>()
                .Property(e => e.LocationID)
                .IsUnicode(false);

            modelBuilder.Entity<CINEMA>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<CINEMA_IMAGE>()
                .Property(e => e.CinemaImageID)
                .IsUnicode(false);

            modelBuilder.Entity<CINEMA_IMAGE>()
                .Property(e => e.CinemaID)
                .IsUnicode(false);

            modelBuilder.Entity<CINEMA_IMAGE>()
                .Property(e => e.ImageLink)
                .IsUnicode(false);

            modelBuilder.Entity<CINEMA_LOCATION>()
                .Property(e => e.LocationID)
                .IsUnicode(false);

            modelBuilder.Entity<DEPARTMENT>()
                .Property(e => e.DepartmentID)
                .IsUnicode(false);

            modelBuilder.Entity<DISCOUNT_CODE>()
                .Property(e => e.CodeID)
                .IsUnicode(false);

            modelBuilder.Entity<FEEDBACK>()
                .Property(e => e.FeedbackID)
                .IsUnicode(false);

            modelBuilder.Entity<FEEDBACK>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIE>()
                .Property(e => e.MovieID)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIE>()
                .Property(e => e.PosterLink)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIE>()
                .Property(e => e.BannerLink)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIE>()
                .Property(e => e.TrailerLink)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIE_TIME>()
                .Property(e => e.MovieTimeID)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIE_TIME>()
                .Property(e => e.MovieID)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIE_TIME>()
                .Property(e => e.RoomID)
                .IsUnicode(false);

            modelBuilder.Entity<MOVIE_TIME>()
                .Property(e => e.ShowTime)
                .IsUnicode(false);

            modelBuilder.Entity<POST>()
                .Property(e => e.PostID)
                .IsUnicode(false);

            modelBuilder.Entity<POST>()
                .Property(e => e.PostThumbnail)
                .IsUnicode(false);

            modelBuilder.Entity<POST_CONTENT>()
                .Property(e => e.PostContentID)
                .IsUnicode(false);

            modelBuilder.Entity<POST_CONTENT>()
                .Property(e => e.PostID)
                .IsUnicode(false);

            modelBuilder.Entity<POST_CONTENT>()
                .Property(e => e.PostImg1)
                .IsUnicode(false);

            modelBuilder.Entity<POST_CONTENT>()
                .Property(e => e.PostImg2)
                .IsUnicode(false);

            modelBuilder.Entity<ROOM>()
                .Property(e => e.RoomID)
                .IsUnicode(false);

            modelBuilder.Entity<ROOM>()
                .Property(e => e.RoomName)
                .IsUnicode(false);

            modelBuilder.Entity<ROOM>()
                .Property(e => e.CinemaID)
                .IsUnicode(false);

            modelBuilder.Entity<ROOM>()
                .Property(e => e.ScreenType)
                .IsUnicode(false);

            modelBuilder.Entity<SEAT>()
                .Property(e => e.SeatID)
                .IsUnicode(false);

            modelBuilder.Entity<SEAT>()
                .Property(e => e.SeatName)
                .IsUnicode(false);

            modelBuilder.Entity<SEAT>()
                .Property(e => e.MovieTimeID)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICE>()
                .Property(e => e.ServiceID)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICE>()
                .Property(e => e.ServiceImage)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICE_TO_CASH>()
                .Property(e => e.ServiceToCashID)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICE_TO_CASH>()
                .Property(e => e.ServiceID)
                .IsUnicode(false);

            modelBuilder.Entity<SERVICE_TO_CASH>()
                .Property(e => e.ServiceSession)
                .IsUnicode(false);

            modelBuilder.Entity<TICKET>()
                .Property(e => e.TicketID)
                .IsUnicode(false);

            modelBuilder.Entity<TICKET>()
                .Property(e => e.SeatID)
                .IsUnicode(false);

            modelBuilder.Entity<TICKET>()
                .Property(e => e.TicketSession)
                .IsUnicode(false);

            modelBuilder.Entity<TICKET_TYPE>()
                .Property(e => e.TicketTypeID)
                .IsUnicode(false);

            modelBuilder.Entity<USER_ACCOUNT>()
                .Property(e => e.UserID)
                .IsUnicode(false);

            modelBuilder.Entity<USER_ACCOUNT>()
                .Property(e => e.Username)
                .IsUnicode(false);

            modelBuilder.Entity<USER_ACCOUNT>()
                .Property(e => e.UserPassword)
                .IsUnicode(false);

            modelBuilder.Entity<USER_ACCOUNT>()
                .Property(e => e.email)
                .IsUnicode(false);
        }
    }
}
