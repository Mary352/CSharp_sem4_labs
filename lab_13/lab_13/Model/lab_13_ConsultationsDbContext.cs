using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace lab_13.Model
{
    public partial class lab_13_ConsultationsDbContext : DbContext
    {
        public lab_13_ConsultationsDbContext()
            : base("name=lab_13_ConsultationsDbContext")
        {
        }

        public virtual DbSet<Lecturer> Lecturers { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
