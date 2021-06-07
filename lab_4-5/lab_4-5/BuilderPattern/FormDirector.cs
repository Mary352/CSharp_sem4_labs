using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_4_5.BuilderPattern
{
    class FormDirector
    {
        public Form BuildForm(FormBuilder formBuilder)
        {
            formBuilder.CreateForm();
            formBuilder.SetCountryField();
            formBuilder.SetCityField();
            formBuilder.SetOtherFields();
            formBuilder.SetOK_Button();
            return formBuilder.form;
        }
    }
}
