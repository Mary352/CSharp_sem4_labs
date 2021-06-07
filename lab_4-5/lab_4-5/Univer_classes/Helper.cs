using System;
using System.Drawing;
using System.Windows.Forms;

namespace lab_4_5.Univer_classes
{
    public static class Helper
    {
        public static string GetStringValue(TextBox txtB)
        {
            if (txtB.Text.Length != 0)
                return txtB.Text;
            else
            {
                throw new FormatException();
                //txtB.BackColor = Color.FromArgb(255, 77, 0);
            }                
        }

        public static int GetIntValue(MaskedTextBox mTxtB)
        {
            if (mTxtB.Text.Length != 0)
                return Convert.ToInt32(mTxtB.Text);
            else
                throw new FormatException();
        }

        public static int GetIntValue(TextBox txtB)
        {
            if (txtB.Text.Length != 0)
                return Convert.ToInt32(txtB.Text);
            else
                throw new FormatException();
        }

        public static string GetComboBoxValue(ComboBox cmbB)
        {
            if (cmbB.SelectedIndex > -1)
                return cmbB.SelectedItem.ToString();
            else
                throw new FormatException();            
        }

        public static double GetDoubleValue(MaskedTextBox mTxtB)
        {
            if (mTxtB.Text.Length != 0)
                return Convert.ToDouble(mTxtB.Text);
            else
                throw new FormatException();
        }

        // заменить переменными, доб параметры
        public static void AddLabel_and_TextBox(Form form, string labelName, int labelPointX, int labelPointY, string labelText, string txtB_Name, int txtB_PointX, int txtB_PointY)
        {
            form.Controls.Add(new Label() { Name = labelName, Location = new Point(labelPointX, labelPointY), Text = labelText });
            form.Controls.Add(new TextBox() { Name = txtB_Name, Location = new Point(txtB_PointX, txtB_PointY) });
        }
    }
}
