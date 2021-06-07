using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playgoer.Model.Repository_UoW
{
    class PerformanceContext : DbContext
    {
        public DbSet<Theater> Theaters { get; set; }
        public DbSet<Performance> Performances { get; set; }

        public PerformanceContext() : base("name=PGContext")
        { }

        
    }
}
