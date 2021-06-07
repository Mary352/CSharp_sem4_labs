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

                DialogResult = DialogResult.OK;
                Close();

            }
            catch (FormatException)
            {
                MessageBox.Show("Заполните все поля");
            }
        }

       
    }
}
