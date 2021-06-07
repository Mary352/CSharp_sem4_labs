using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace testMVVM
{
    public class ApplicationViewModel : INotifyPropertyChanged
    {
        //private Phone2 selectedPhone;

        //public ObservableCollection<Phone> Phones { get; set; }
        ////public ObservableCollection<Phone2> Phones { get; set; }
        //public Phone2 SelectedPhone
        //{
        //    get { return selectedPhone; }
        //    set
        //    {
        //        selectedPhone = value;
        //        OnPropertyChanged("SelectedPhone");
        //    }
        //}

        private Phone selectedPhone;
        public ObservableCollection<Phone> Phones { get; set; }
        //public ObservableCollection<Phone2> Phones { get; set; }

        // команда добавления нового объекта
        private RelayCommand addCommand;
        private RelayCommand delCommand;

        public RelayCommand AddCommand
        {
            get
            {
                return addCommand ??
                  (addCommand = new RelayCommand(obj =>
                  {
                      using (PhonesDbContext db = new PhonesDbContext())
                      {
                          Phone phone = db.Phones.Where(p => p.Title == SelectedPhone.Title).FirstOrDefault();
                          //  && phone.Price < 30
                          if (phone != null)                          {

                              phone.Price += 1;
                              db.SaveChanges();

                              //SelectedPhone.Price = phone.Price;
                              db.Phones.Load();
                              Phones.Clear();
                              foreach (var item in db.Phones.Local)
                              {
                                  Phones.Add(item);
                              }
                              
                          }
                      }
                      //usrEmailBlock.Text = mail;

                      //Phone phone = new Phone();
                      //SelectedPhone.Price += 1;
                      //SelectedPhone = phone;
                  }));
            }
        }

        public Phone SelectedPhone
        {
            get { return selectedPhone; }
            set
            {
                selectedPhone = value;
                OnPropertyChanged("SelectedPhone");
            }
        }

        public ApplicationViewModel()
        {
            using (PhonesDbContext db = new PhonesDbContext())
            {
                // загружаем данные
                db.Phones.Load();
                // устанавливаем привязку к кэшу
                Phones = new ObservableCollection<Phone>();
                foreach (var item in db.Phones.Local)
                {
                    Phones.Add(item);
                }
                
            }


            //Phones = new ObservableCollection<Phone2>
            //{
            //    new Phone2 { Title="iPhone 7", Company="Apple", Price=56000 },
            //    new Phone2 {Title="Galaxy S7 Edge", Company="Samsung", Price =60000 },
            //    new Phone2 {Title="Elite x3", Company="HP", Price=56000 },
            //    new Phone2 {Title="Mi5S", Company="Xiaomi", Price=35000 }
            //};
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
