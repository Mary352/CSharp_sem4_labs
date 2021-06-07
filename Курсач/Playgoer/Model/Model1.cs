namespace Playgoer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Model1 : DbContext
    {
        public Model1()
            : base("name=PGContext")
        {
        }

        public virtual DbSet<Performance> Performances { get; set; }
        public virtual DbSet<Seat> Seats { get; set; }
        public virtual DbSet<Theater> Theaters { get; set; }
        public virtual DbSet<Ticket> Tickets { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Performance>()
                .Property(e => e.PName)
                .IsUnicode(false);

            modelBuilder.Entity<Performance>()
                .Property(e => e.Genre)
                .IsUnicode(false);

            modelBuilder.Entity<Seat>()
                .Property(e => e.Sector)
                .IsUnicode(false);

            modelBuilder.Entity<Theater>()
                .Property(e => e.TName)
                .IsUnicode(false);

            modelBuilder.Entity<Theater>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Theater>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Theater>()
                .Property(e => e.Phone)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Nickname)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Login)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<User>()
                .Property(e => e.Email)
                .IsUnicode(false);
        }
    }
}
