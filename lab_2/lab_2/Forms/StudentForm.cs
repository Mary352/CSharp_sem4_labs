using lab_2.Forms;
using lab_2.Univer_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_2
{
    public partial class StudentForm : Form
    {
        Address addr;
        PlaceWork placeWork;
        public Student stud;

        public StudentForm()
        {
            InitializeComponent();
        }

        private void OKstudButton_Click(object sender, EventArgs e)
        {
            if (addr != null && placeWork != null)
            {
                try
                {
                    string surname = Helper.GetStringValue(surnameTxtB);
                    string name = Helper.GetStringValue(nameTxtB);
                    string patronymic = Helper.GetStringValue(patronymicTxtB);
                    int age = Helper.GetIntValue(ageMTxtB);
                    string speciality = Helper.GetComboBoxValue(specialityCmbB);
                    DateTime dateBirth = dateBirthDTP.Value;
                    int course = courseTrB.Value;
                    int group = (int)groupNUD.Value;
                    double averageMark = Helper.GetDoubleValue(avMarkMTxtB);
                    string gender = Helper.GetComboBoxValue(genderCmbB);

                    stud = new Student(surname, name, patronymic, age, speciality, dateBirth, course, group, averageMark, gender, addr, placeWork);

                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (FormatException)
                {
                    MessageBox.Show("Заполните все поля");
                }
            }
            else
                MessageBox.Show("Введите адрес и место работы");

            
        }

        private void AddrButtShowForm_Click(object sender, EventArgs e)
        {
            using (AddressForm form = new AddressForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK) 
                    this.addr = form.addr;
                
            }
        }

        private void PlaceWorkButtShowForm_Click(object sender, EventArgs e)
        {
            using (PlaceWorkForm form = new PlaceWorkForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                    this.placeWork = form.placeWork;
            }
        }
    }
}
