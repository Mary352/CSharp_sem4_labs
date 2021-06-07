using Playgoer.Model.Repository_UoW.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playgoer.Model.Repository_UoW
{
    class PerformanceRepository : IRepository<Performance>
    {
        private PerformanceContext db;
        private ObservableCollection<Performance> performances = new ObservableCollection<Performance>();

        public PerformanceRepository(PerformanceContext context)
        {
            this.db = context;
        }

        public ObservableCollection<Performance> GetAll()
        {
            performances.Clear();
            IEnumerable<Performance> prfs = db.Performances;
            foreach (Performance prf in prfs)
            {
                performances.Add(prf);
            }
            return performances;
        }

        public Performance GetConcreteObjectById(Guid id)
        {
            return db.Performances.Find(id);
        }

        public Performance GetConcreteObjectByName(string name)
        {
            return db.Performances.Where(prf => prf.PName == name).FirstOrDefault();
        }

        // specific
        public Performance GetConcreteObjectByPNameThIdDatetime(string pName, Guid thId, DateTime dateTime)
        {
            return db.Performances.Where(a => a.PName == pName && a.TheaterId == thId && a.Date_time == dateTime).FirstOrDefault();
        }

        // specific
        public IEnumerable<Performance> GetSomeObjectsById(Guid id)
        {
            return db.Performances.Where(prf => prf.TheaterId == id);
        }

        public void Create(Performance Performance)
        {
            db.Performances.Add(Performance);
        }

        public void Update(Performance Performance)
        {
            db.Entry(Performance).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Performance Performance = db.Performances.Find(id);
            if (Performance != null)
                db.Performances.Remove(Performance);
        }

        //public void Delete(int id)
        //{
        //    Performance Performance = db.Performances.Find(id);
        //    if (Performance != null)
        //        db.Performances.Remove(Performance);
        //}
    }
}
