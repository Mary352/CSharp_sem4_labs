using lab_4_5.AbstractFactoryPattern;
using lab_4_5.AbstractFactoryPattern.Interfaces;
using lab_4_5.BuilderPattern;
using lab_4_5.Forms;
using lab_4_5.Univer_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab_4_5.ObserverPattern.Interfaces;
using lab_4_5.ObserverPattern;

namespace lab_4_5
{
    public partial class StudentForm : Form, IObservable
    {
        IAddress addr;
        IPlaceWork placeWork;
        public IFactory stud;

        List<IObserver> observers;

        public StudentForm()
        {
            InitializeComponent();

            observers = new List<IObserver>();
            Observer observer = new Observer(this);
        }

        public void RegisterObserver(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveObserver(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (IObserver o in observers)
            {
                o.Update(avMarkMTxtB);
            }
        }

        private void OKstudButton_Click(object sender, EventArgs e)
        {
            if (addr != null && placeWork != null)
            {
                try
                {
                    string surname = surnameTxtB.Text;
                    string name = nameTxtB.Text;
                    string patronymic = patronymicTxtB.Text;
                    int age = Helper.GetIntValue(ageMTxtB);
                    string speciality = Helper.GetComboBoxValue(specialityCmbB);
                    DateTime dateBirth = dateBirthDTP.Value;
                    int course = courseTrB.Value;
                    int group = (int)groupNUD.Value;
                    double averageMark = Helper.GetDoubleValue(avMarkMTxtB);
                    string gender = Helper.GetComboBoxValue(genderCmbB);

                    if (foreignStudCheckBox.Checked)
                    {
                        IFactory foreignStud = new ForeignStudFactory(surname, name, patronymic, age, speciality, dateBirth, course, group, averageMark, gender, addr, placeWork);
                        ValidationFunc(foreignStud);
                        stud = foreignStud;
                    }
                    else
                    {
                        IFactory belStud = new StudFactory(surname, name, patronymic, age, speciality, dateBirth, course, group, averageMark, gender, addr, placeWork);
                        ValidationFunc(belStud);
                        stud = belStud;
                    }
        }
                catch (FormatException)
                {
                    MessageBox.Show("Заполните все поля");
                }
}
            else
                MessageBox.Show("Введите адрес и место работы");
            
        }

        private void ValidationFunc(IFactory stud)
        {
            var results = new List<ValidationResult>();
            var context = new ValidationContext(stud);
            if (!Validator.TryValidateObject(stud, context, results, true))
            {
                string errorMsgs = "";
                foreach (var error in results)
                {
                    errorMsgs += "\n" + error.ErrorMessage;
                }

                MessageBox.Show(errorMsgs);
            }
            else
            {
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        private void AddrButtShowForm_Click(object sender, EventArgs e)
        {
            FormDirector formDirector = new FormDirector();
            FormBuilder builder;
            if (foreignStudCheckBox.Checked)
            {
                builder = new AddressForeignFormBuilder();
            }
            else
                builder = new AddressFormBuilder();
            
            using (Form form = formDirector.BuildForm(builder))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)                
                    this.addr = builder.addr;

                //MessageBox.Show(addr.ToString());
            }
        }        

        private void PlaceWorkButtShowForm_Click(object sender, EventArgs e)
        {
            using (PlaceWorkForm form = new PlaceWorkForm(stud, foreignStudCheckBox.Checked))
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                    this.placeWork = form.placeWork;
            }
        }

        private void avMarkMTxtB_Leave(object sender, EventArgs e)
        {
            NotifyObservers();
        }
    }
}
