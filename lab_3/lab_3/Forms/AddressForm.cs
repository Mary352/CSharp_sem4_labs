using lab_3.Univer_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Forms;

namespace lab_3
{
    public partial class AddressForm : Form
    {
        public Address addr;

        public AddressForm()
        {
            InitializeComponent();
        }

        private void OKaddrButton_Click(object sender, EventArgs e)
        {
            try
            {
                string city = Helper.GetStringValue(cityTxtB);
                int postcode = Helper.GetIntValue(postcodeMTxtB);
                string street = Helper.GetStringValue(streetTxtB);
                string house = Helper.GetStringValue(houseTxtB);
                string apt = Helper.GetStringValue(houseTxtB);

                addr = new Address(city, postcode, street, house, apt);

                var results = new List<ValidationResult>();
                var context = new ValidationContext(addr);
                if (!Validator.TryValidateObject(addr, context, results, true))
                {
                    foreach (var error in results)
                    {
                        MessageBox.Show(error.ErrorMessage);
                    }
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

       
    }
}
