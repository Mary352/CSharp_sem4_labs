using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Playgoer.Model.Repository_UoW.Interfaces;

namespace Playgoer.Model.Repository_UoW
{
    class TheaterRepository : IRepository<Theater>
    {
        private PerformanceContext db;
        private ObservableCollection<Theater> theaters = new ObservableCollection<Theater>();

        public TheaterRepository(PerformanceContext context)
        {
            this.db = context;
        }

        public ObservableCollection<Theater> GetAll()
        {
            theaters.Clear();

            //db.Theaters.Load();
            //db.Theaters.Local.ToBindingList();
            IEnumerable<Theater> thrs = db.Theaters;
            foreach (Theater thr in thrs)
            {
                theaters.Add(thr);
                //MessageBox.Show(thr.TName);
            }
            return theaters;
        }

        //public IEnumerable<Theater> GetAll()
        //{
        //    return db.Theaters;
        //}

        public Theater GetConcreteObjectById(Guid id)
        {
            return db.Theaters.Find(id);
        }

        public Theater GetConcreteObjectByName(string name)
        {
            return db.Theaters.Where(th => th.TName == name).FirstOrDefault();
        }

        // specific
        public IEnumerable<Theater> GetConcreteObjectByCity(string city)
        {
            return db.Theaters.Where(th => th.City == city);
        }

        public void Create(Theater theater)
        {
            db.Theaters.Add(theater);
        }

        public void Update(Theater theater)
        {
            db.Entry(theater).State = EntityState.Modified;
        }

        public void Delete(Guid id)
        {
            Theater theater = db.Theaters.Find(id);
            if (theater != null)
                db.Theaters.Remove(theater);
        }
    }
}
