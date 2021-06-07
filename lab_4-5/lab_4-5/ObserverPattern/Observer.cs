using lab_4_5.ObserverPattern.Interfaces;
using lab_4_5.Univer_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_4_5.ObserverPattern
{
    class Observer : IObserver
    {
        IObservable form;

        public Observer(IObservable obs)
        {
            form = obs;
            form.RegisterObserver(this);
        }
        public void Update(MaskedTextBox mtxtB)
        {
            double mark = Helper.GetDoubleValue(mtxtB);

            if (mark > 10.0)
            {
                MessageBox.Show("Неверная оценка. Введите число от 0.0 до 10.0");
                mtxtB.Clear();
            }
               
        }
    }
}
