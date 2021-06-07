using lab_13.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace lab_13.ViewModel
{
    public class LecturerViewModel : INotifyPropertyChanged
    {
        private Lecturer lecturer;

        public LecturerViewModel(Lecturer lect)
        {
            lecturer = lect;
        }

        //public string Title
        //{
        //    get { return lecturer.Title; }
        //    set
        //    {
        //        lecturer.Title = value;
        //        OnPropertyChanged("Title");
        //    }
        //}
        //public string Company
        //{
        //    get { return lecturer.Company; }
        //    set
        //    {
        //        lecturer.Company = value;
        //        OnPropertyChanged("Company");
        //    }
        //}
        public int StudNum
        {
            get { return lecturer.StudNum; }
            set
            {
                lecturer.StudNum = value;
                OnPropertyChanged("StudNum");
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
