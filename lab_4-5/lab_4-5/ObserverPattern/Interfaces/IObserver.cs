using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_4_5.ObserverPattern.Interfaces
{
    public interface IObserver
    {
        void Update(MaskedTextBox mtxtB);
    }
}
