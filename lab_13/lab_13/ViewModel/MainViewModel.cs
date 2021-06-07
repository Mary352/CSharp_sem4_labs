using lab_13.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Data.Entity;
using lab_13.Commands;

namespace lab_13.ViewModel
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Lecturer selectedLecturer;
        public ObservableCollection<Lecturer> Lecturers { get; set; }
        //public ObservableCollection<Lecturer2> Lecturers { get; set; }

        // команда добавления нового объекта
        private RelayCommand registerCommand;
        private RelayCommand cancelCommand;

        private static int maxStudNum = 0;

        public RelayCommand RegisterCommand
        {
            get
            {
                return registerCommand ??
                  (registerCommand = new RelayCommand(obj =>
                  {
                      using (lab_13_ConsultationsDbContext db = new lab_13_ConsultationsDbContext())
                      {
                          Lecturer lecturer = db.Lecturers.Where(lect => lect.SNP == SelectedLecturer.SNP).FirstOrDefault();
                          if (lecturer != null)
                          { 
                              lecturer.StudNum -= 1;
                              db.SaveChanges();

                              //SelectedLecturer.Price = lecturer.Price;
                              db.Lecturers.Load();
                              Lecturers.Clear();
                              foreach (var item in db.Lecturers.Local)
                              {
                                  Lecturers.Add(item);
                              }
                              SelectedLecturer = db.Lecturers.FirstOrDefault();
                          }
                      }
                  },
                  (obj) => SelectedLecturer.StudNum > 0));
            }
        }

        public RelayCommand CancelCommand
        {
            get
            {
                return cancelCommand ??
                  (cancelCommand = new RelayCommand(obj =>
                  {
                      using (lab_13_ConsultationsDbContext db = new lab_13_ConsultationsDbContext())
                      {
                          Lecturer lecturer = db.Lecturers.Where(lect => lect.SNP == SelectedLecturer.SNP).FirstOrDefault();
                          if (lecturer != null)
                          {
                              maxStudNum = lecturer.MaxStudNum;

                              lecturer.StudNum += 1;
                              db.SaveChanges();

                              //SelectedLecturer.Price = lecturer.Price;
                              db.Lecturers.Load();
                              Lecturers.Clear();
                              foreach (var item in db.Lecturers.Local)
                              {
                                  Lecturers.Add(item);
                              }
                              SelectedLecturer = db.Lecturers.FirstOrDefault();
                          }
                      }
                  },
                  obj =>
                  {
                      using (lab_13_ConsultationsDbContext db = new lab_13_ConsultationsDbContext())
                      {
                          Lecturer lecturer = db.Lecturers.Where(lect => lect.SNP == SelectedLecturer.SNP).FirstOrDefault();
                          if (lecturer != null)
                          {
                              maxStudNum = lecturer.MaxStudNum;
                          }

                      }
                      return SelectedLecturer.StudNum < maxStudNum;
                  }));
            }
        }

        public Lecturer SelectedLecturer
        {
            get { return selectedLecturer; }
            set
            {
                selectedLecturer = value;
                OnPropertyChanged("SelectedLecturer");
            }
        }

        public MainViewModel()
        {
            using (lab_13_ConsultationsDbContext db = new lab_13_ConsultationsDbContext())
            {
                // загружаем данные
                db.Lecturers.Load();
                // устанавливаем привязку к кэшу
                Lecturers = new ObservableCollection<Lecturer>();
                foreach (var item in db.Lecturers.Local)
                {
                    Lecturers.Add(item);
                }
                SelectedLecturer = db.Lecturers.FirstOrDefault();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
