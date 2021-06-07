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

namespace lab_4_5.Forms
{
    public partial class PlaceWorkForm : Form
    {
        public IPlaceWork placeWork;
        bool foreignStudCheckBoxChecked;
        IFactory foreignStudFactory = new ForeignStudFactory();
        IFactory studFactory = new StudFactory();

        public PlaceWorkForm(IFactory factory, bool foreignStudCheckBoxChecked)
        {
            InitializeComponent();

            if (foreignStudCheckBoxChecked)
            {
                countryTB.Visible = true;
                countryLabel.Visible = true;
            }
            else
            {
                countryTB.Visible = false;
                countryLabel.Visible = false;
            }

            this.foreignStudCheckBoxChecked = foreignStudCheckBoxChecked;
        }

        private void OKpwfButton_Click(object sender, EventArgs e)
        {
            try
            {
                string country = countryTB.Text;
                string company = Helper.GetStringValue(companyTxtB);
                string city = Helper.GetStringValue(cityTB);
                string position = Helper.GetStringValue(positionTxtB);
                int experience = Helper.GetIntValue(experienceMTxtB);

                if (foreignStudCheckBoxChecked)
                {
                    placeWork = foreignStudFactory.CreatePlaceWork(company, city, position, experience, country);
                }
                else
                {
                    placeWork = studFactory.CreatePlaceWork(company, city, position, experience, country);
                }

                //placeWork = studFactory.CreatePlaceWork(company, city, position, experience, country);
                //placeWork = new PlaceWork(company, city, position, experience, country);

                var results = new List<ValidationResult>();
                var context = new ValidationContext(placeWork);
                if (!Validator.TryValidateObject(placeWork, context, results, true))
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

                //DialogResult = DialogResult.OK;
                //Close();
            }
            catch (FormatException)
            {
                MessageBox.Show("Заполните все поля");
            }

        }

       
    }
}
