using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playgoer.Model.Repository_UoW
{
    class UnitOfWork : IDisposable
    {
        private PerformanceContext db = new PerformanceContext();
        private TheaterRepository TheaterRepository;
        private PerformanceRepository PerformanceRepository;

        public TheaterRepository Theaters
        {
            get
            {
                if (TheaterRepository == null)
                    TheaterRepository = new TheaterRepository(db);
                return TheaterRepository;
            }
        }

        public PerformanceRepository Performances
        {
            get
            {
                if (PerformanceRepository == null)
                    PerformanceRepository = new PerformanceRepository(db);
                return PerformanceRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
