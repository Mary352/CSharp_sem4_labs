using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_3.Univer_classes
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
    }
}
