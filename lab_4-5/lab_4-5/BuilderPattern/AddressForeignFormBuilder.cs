using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using lab_4_5.Univer_classes;
using lab_4_5.AbstractFactoryPattern;
using lab_4_5.AbstractFactoryPattern.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace lab_4_5.BuilderPattern
{
    class AddressForeignFormBuilder : FormBuilder
    {        
        IFactory foreignStudFactory = new ForeignStudFactory();

        TextBox countryTxtB = new TextBox();
        TextBox cityTxtB = new TextBox();
        TextBox postcodeTxtB = new TextBox();
        TextBox streetTxtB = new TextBox();
        TextBox houseTxtB = new TextBox();
        TextBox aptTxtB = new TextBox();

        public override void SetCountryField()
        {
            this.form.Controls.Add(new Label() { Name = "countryLabel", Location = new Point(32, 35), Text = "Страна", Size = new Size(56, 17) });

            countryTxtB.Name = "countryTxtB";
            countryTxtB.Location = new Point(162, 29);
            countryTxtB.Size = new Size(225, 22);
            this.form.Controls.Add(countryTxtB);
            
            //Helper.AddLabel_and_TextBox(this.form, "countryLabel", 32, 35, "Страна", "countryTxtB", 162, 29);
        }

        public override void SetCityField()
        {            
            this.form.Controls.Add(new Label() { Name = "cityLabel", Location = new Point(32, 65), Text = "Город", Size = new Size(56, 17) });

            cityTxtB.Name = "cityTxtB";
            cityTxtB.Location = new Point(162, 59);
            cityTxtB.Size = new Size(225, 22);
            this.form.Controls.Add(cityTxtB);

            //Helper.AddLabel_and_TextBox(this.form, "cityLabel", 32, 65, "Город", "cityTxtB", 162, 59);
            //this.form.Controls.Add(new TextBox() { Name = "cityTxtB", Location = new Point(162, 59) });
        }

        public override void SetOtherFields()
        {
            this.form.Controls.Add(new Label() { Name = "postcodeTxtB", Location = new Point(32, 97), Text = "Индекс", Size = new Size(56, 17) });
            postcodeTxtB.Name = "postcodeTxtB";
            postcodeTxtB.Location = new Point(162, 94);
            postcodeTxtB.Size = new Size(225, 22);
            this.form.Controls.Add(postcodeTxtB);

            this.form.Controls.Add(new Label() { Name = "streetLabel", Location = new Point(32, 129), Text = "Улица", Size = new Size(56, 17) });
            streetTxtB.Name = "streetTxtB";
            streetTxtB.Location = new Point(162, 124);
            streetTxtB.Size = new Size(225, 22);
            this.form.Controls.Add(streetTxtB);

            this.form.Controls.Add(new Label() { Name = "houseLabel", Location = new Point(32, 163), Text = "Дом", Size = new Size(56, 17) });
            houseTxtB.Name = "houseTxtB";
            houseTxtB.Location = new Point(162, 158);
            houseTxtB.Size = new Size(225, 22);
            this.form.Controls.Add(houseTxtB);

            this.form.Controls.Add(new Label() { Name = "aptLabel", Location = new Point(32, 195), Text = "Квартира", Size = new Size(56, 17) });
            aptTxtB.Name = "aptTxtB";
            aptTxtB.Location = new Point(162, 190);
            aptTxtB.Size = new Size(225, 22);
            this.form.Controls.Add(aptTxtB);

            //Helper.AddLabel_and_TextBox(this.form, "postcodeTxtB", 32, 97, "Индекс", "postcodeTxtB", 162, 94);
            //Helper.AddLabel_and_TextBox(this.form, "streetLabel", 32, 129, "Улица", "streetTxtB", 162, 124);
            //Helper.AddLabel_and_TextBox(this.form, "houseLabel", 32, 163, "Дом", "houseTxtB", 162, 158);
            //Helper.AddLabel_and_TextBox(this.form, "aptLabel", 32, 195, "Квартира", "aptTxtB", 162, 190);
        }

        public override void SetOK_Button()
        {
            Button OKaddrButton = new Button();
            OKaddrButton.Name = "OKaddrButton";
            OKaddrButton.Location = new Point(143, 258);
            OKaddrButton.Text = "OK";
            OKaddrButton.Size = new Size(135, 34);
            OKaddrButton.Click += OKaddrButton_Click;
            this.form.Controls.Add(OKaddrButton);

            //this.form.Controls.Add(new Button() { Name = "OKaddrButton", Location = new Point(143, 258), Text = "OK"});

        }

        private void OKaddrButton_Click(object sender, EventArgs e)
        {
            try
            {
                string country = countryTxtB.Text;

                string city = Helper.GetStringValue(cityTxtB);
                string postcode = Helper.GetStringValue(postcodeTxtB);
                string street = Helper.GetStringValue(streetTxtB);
                string house = Helper.GetStringValue(houseTxtB);
                string apt = Helper.GetStringValue(aptTxtB);

                
                addr = foreignStudFactory.CreateAddress(country, city, postcode, street, house, apt);
                
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
                    form.DialogResult = DialogResult.OK;
                    form.Close();
                }

            }
            catch (FormatException)
            {
                MessageBox.Show("Заполните все поля");
            }
        }
    }
}
