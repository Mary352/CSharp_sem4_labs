using lab_3.Forms;
using lab_3.Univer_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace lab_3
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
