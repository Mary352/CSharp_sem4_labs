using lab_4_5.AbstractFactoryPattern;
using lab_4_5.AbstractFactoryPattern.Interfaces;
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

namespace lab_4_5
{
    public partial class AddressForm : Form
    {
        public IAddress addr;
        bool foreignStudCheckBoxChecked;
        IFactory foreignStudFactory = new ForeignStudFactory();
        IFactory studFactory = new StudFactory();

        public AddressForm(IFactory factory, bool foreignStudCheckBoxChecked)
        {
            InitializeComponent();

            if (foreignStudCheckBoxChecked)
            {
                countryTxtB.Visible = true;
                countryLabel.Visible = true;

                //foreignStudFactory = factory;
            }
            else
            {
                countryTxtB.Visible = false;
                countryLabel.Visible = false;

                //studFactory = factory;
            }

            this.foreignStudCheckBoxChecked = foreignStudCheckBoxChecked;
        }

        private void OKaddrButton_Click(object sender, EventArgs e)
        {
            try
            {
                //string country = "";

                //if (countryTxtB.Text.Length != 0)
                string country = countryTxtB.Text;
                //if (foreignStudCheckBoxChecked)
                //{
                //    country = Helper.GetStringValue(countryTxtB);
                //}

                string city = Helper.GetStringValue(cityTxtB);
                string postcode = Helper.GetStringValue(postcodeTxtB);
                string street = Helper.GetStringValue(streetTxtB);
                string house = Helper.GetStringValue(houseTxtB);
                string apt = Helper.GetStringValue(houseTxtB);

                if (foreignStudCheckBoxChecked)
                {
                    addr = foreignStudFactory.CreateAddress(country, city, postcode, street, house, apt);
                }
                else
                {
                    addr = studFactory.CreateAddress(country, city, postcode, street, house, apt);
                }    
                
                //addr = new Address(country, city, postcode, street, house, apt);

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
