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

namespace lab_2.Forms
{
    public partial class PlaceWorkForm : Form
    {
        public PlaceWork placeWork;

        public PlaceWorkForm()
        {
            InitializeComponent();
        }

        private void OKpwfButton_Click(object sender, EventArgs e)
        {
            try
            {
                string company = Helper.GetStringValue(companyTxtB);
                string position = Helper.GetStringValue(positionTxtB);
                int experience = Helper.GetIntValue(experienceMTxtB);
                
                placeWork = new PlaceWork(company, position, experience);

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
