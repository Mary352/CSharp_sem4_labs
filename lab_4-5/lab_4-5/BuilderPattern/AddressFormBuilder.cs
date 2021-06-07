using lab_4_5.AbstractFactoryPattern;
using lab_4_5.AbstractFactoryPattern.Interfaces;
using lab_4_5.Univer_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_4_5.BuilderPattern
{
    class AddressFormBuilder : FormBuilder
    {
        IFactory studFactory = new StudFactory();

        TextBox cityTxtB = new TextBox();
        TextBox postcodeTxtB = new TextBox();
        TextBox streetTxtB = new TextBox();
        TextBox houseTxtB = new TextBox();
        TextBox aptTxtB = new TextBox();

        public override void SetCountryField()
        {
            // no country
        }

        public override void SetCityField()
        {
            this.form.Controls.Add(new Label() { Name = "cityLabel", Location = new Point(36, 28), Text = "Город", Size = new Size(56, 17) });

            cityTxtB.Name = "cityTxtB";
            cityTxtB.Location = new Point(166, 22);
            cityTxtB.Size = new Size(225, 22);
            this.form.Controls.Add(cityTxtB);

            //Helper.AddLabel_and_TextBox(this.form, "cityLabel", 36, 28, "Город", "cityTxtB", 166, 22);
        }

        public override void SetOtherFields()
        {
            this.form.Controls.Add(new Label() { Name = "postcodeTxtB", Location = new Point(36, 60), Text = "Индекс", Size = new Size(56, 17) });
            postcodeTxtB.Name = "postcodeTxtB";
            postcodeTxtB.Location = new Point(166, 57);
            postcodeTxtB.Size = new Size(225, 22);
            this.form.Controls.Add(postcodeTxtB);

            this.form.Controls.Add(new Label() { Name = "streetLabel", Location = new Point(36, 92), Text = "Улица", Size = new Size(56, 17) });
            streetTxtB.Name = "streetTxtB";
            streetTxtB.Location = new Point(166, 87);
            streetTxtB.Size = new Size(225, 22);
            this.form.Controls.Add(streetTxtB);

            this.form.Controls.Add(new Label() { Name = "houseLabel", Location = new Point(36, 126), Text = "Дом", Size = new Size(56, 17) });
            houseTxtB.Name = "houseTxtB";
            houseTxtB.Location = new Point(166, 121);
            houseTxtB.Size = new Size(225, 22);
            this.form.Controls.Add(houseTxtB);

            this.form.Controls.Add(new Label() { Name = "aptLabel", Location = new Point(36, 158), Text = "Квартира", Size = new Size(56, 17) });
            aptTxtB.Name = "aptTxtB";
            aptTxtB.Location = new Point(166, 153);
            aptTxtB.Size = new Size(225, 22);
            this.form.Controls.Add(aptTxtB);

            Helper.AddLabel_and_TextBox(this.form, "postcodeTxtB", 36, 60, "Индекс", "postcodeTxtB", 166, 57);
            Helper.AddLabel_and_TextBox(this.form, "streetLabel", 36, 92, "Улица", "streetTxtB", 166, 87);
            Helper.AddLabel_and_TextBox(this.form, "houseLabel", 36, 126, "Дом", "houseTxtB", 166, 121);
            Helper.AddLabel_and_TextBox(this.form, "aptLabel", 36, 158, "Квартира", "aptTxtB", 166, 153);
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

            this.form.Controls.Add(new Button() { Name = "OKaddrButton", Location = new Point(143, 258), Text = "OK" });
        }

        private void OKaddrButton_Click(object sender, EventArgs e)
        {
            try
            {
                string country = "";

                string city = Helper.GetStringValue(cityTxtB);
                string postcode = Helper.GetStringValue(postcodeTxtB);
                string street = Helper.GetStringValue(streetTxtB);
                string house = Helper.GetStringValue(houseTxtB);
                string apt = Helper.GetStringValue(aptTxtB);

                addr = studFactory.CreateAddress(country, city, postcode, street, house, apt);

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
