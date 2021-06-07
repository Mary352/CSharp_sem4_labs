using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Playgoer.Model.Repository_UoW.Interfaces
{
    interface IRepository<T> where T : class
    {
        ObservableCollection<T> GetAll();
        //IEnumerable<T> GetAll();
        T GetConcreteObjectById(Guid id);
        T GetConcreteObjectByName(string name);
        void Create(T item);
        void Update(T item);
        void Delete(Guid id);
    }
}
