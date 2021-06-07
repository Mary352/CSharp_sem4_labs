using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace testMVVM
{
    public partial class PhonesDbContext : DbContext
    {
        public PhonesDbContext()
            : base("name=PhonesDbContext")
        {
        }

        public virtual DbSet<Phone> Phones { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
