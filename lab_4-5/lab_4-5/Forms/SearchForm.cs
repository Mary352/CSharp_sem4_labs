using lab_4_5.AbstractFactoryPattern;
using lab_4_5.Univer_classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab_4_5.Forms
{
    public partial class SearchForm : Form
    {
        BindingList<Student> items;
        BindingList<Student> collection;

        public SearchForm(BindingList<Student> collection)
        {
            InitializeComponent();
            this.collection = collection;
            items = new BindingList<Student>();
            listSearchResult.DataSource = items;
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            //items.Clear();
            //try
            //{
            //    string value = Helper.GetComboBoxValue(comboSearchOption);
            //    string searchQuery = Helper.GetStringValue(textSearch);
            //    Regex r1 = new Regex($"(\\w*){searchQuery}(\\w*)");
            //    if (value == "MANUFACTURER")
            //    {
            //        foreach (var c in collection)
            //        {
            //            if (r1.IsMatch(c.Processor.Manufacturer))
            //                items.Add(c);
            //        }
            //    }
            //    else
            //    {
            //        foreach (var c in collection)
            //        {
            //            if (r1.IsMatch(c.Processor.Model))
            //                items.Add(c);
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }
    }
}
