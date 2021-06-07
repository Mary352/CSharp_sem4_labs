using lab_4_5.AbstractFactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace lab_4_5.BuilderPattern
{
    abstract class FormBuilder
    {
        public IAddress addr;
        public Form form { get; set; }
        public void CreateForm()
        {
            form = new Form();
            form.Size = new Size (456, 351); 
        }
        public abstract void SetCountryField();
        public abstract void SetCityField();
        public abstract void SetOK_Button();
        public abstract void SetOtherFields();
    }
}
