using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab_4_5.Forms;

namespace lab_4_5.Univer_classes
{
    public sealed class AppSettingsSingleton
    {
        private static StudentsListForm thisStudentsListForm = new StudentsListForm();

        private static ListBox studentsListBox = new ListBox();
        private static ListBox listSearchResult = new ListBox();

        private static Button buttonSearch = new Button();
        private static Button createStudButt = new Button();
        private static Button delStudButt = new Button();
        private static Button saveButton;
        private static Button importButton;
        private static Button buttonExpSort = new Button();
        private static Button buttonGroupSort = new Button();
        private static Button buttonCourseSort = new Button();
        private static Button copyButton = new Button();

        private static readonly Lazy<AppSettingsSingleton> lazyAppFormSettings = new Lazy<AppSettingsSingleton>(() => new AppSettingsSingleton());
        //private static readonly Lazy<AppSettingsSingleton> lazyAppButtonSettings = new Lazy<AppSettingsSingleton>(() => new AppSettingsSingleton( buttonSearch,  createStudButt,  delStudButt,  
            //saveButton,  importButton,
            // buttonExpSort,  buttonGroupSort,  buttonCourseSort));

        private AppSettingsSingleton()
        {
            thisStudentsListForm.BackColor = ColorTranslator.FromHtml("#598234"); // Color.FromArgb(89, 130, 52);

            buttonSearch.BackColor = ColorTranslator.FromHtml("#68829E");
            buttonSearch.FlatAppearance.BorderSize = 0;
            buttonSearch.FlatStyle = FlatStyle.Flat;
            buttonSearch.ForeColor = Color.FromName("White");
            buttonSearch.Font = new Font("Segoe Print", 8, FontStyle.Regular, GraphicsUnit.Point);

            copyButton.BackColor = ColorTranslator.FromHtml("#AEBD38");
            copyButton.FlatAppearance.BorderSize = 0;
            copyButton.FlatStyle = FlatStyle.Flat;
            copyButton.Font = new Font("Segoe Print", 8, FontStyle.Regular, GraphicsUnit.Point);

            createStudButt.BackColor = ColorTranslator.FromHtml("#AEBD38");
            createStudButt.FlatAppearance.BorderSize = 0;
            createStudButt.FlatStyle = FlatStyle.Flat;
            createStudButt.Font = new Font("Segoe Print", 8, FontStyle.Regular, GraphicsUnit.Point);

            delStudButt.BackColor = ColorTranslator.FromHtml("#AEBD38");
            delStudButt.FlatAppearance.BorderSize = 0;
            delStudButt.FlatStyle = FlatStyle.Flat;
            delStudButt.Font = new Font("Segoe Print", 8, FontStyle.Regular, GraphicsUnit.Point);

            saveButton.BackColor = ColorTranslator.FromHtml("#AEBD38");
            saveButton.FlatAppearance.BorderSize = 0;
            saveButton.FlatStyle = FlatStyle.Flat;
            saveButton.Font = new Font("Segoe Print", 8, FontStyle.Regular, GraphicsUnit.Point);

            importButton.BackColor = ColorTranslator.FromHtml("#AEBD38");
            importButton.FlatAppearance.BorderSize = 0;
            importButton.FlatStyle = FlatStyle.Flat;
            importButton.Font = new Font("Segoe Print", 8, FontStyle.Regular, GraphicsUnit.Point);

            buttonExpSort.BackColor = ColorTranslator.FromHtml("#505160");
            buttonExpSort.FlatAppearance.BorderSize = 0;
            buttonExpSort.FlatStyle = FlatStyle.Flat;
            buttonExpSort.ForeColor = ColorTranslator.FromHtml("#AEBD38");
            buttonExpSort.Font = new Font("Segoe Print", 8, FontStyle.Regular, GraphicsUnit.Point);

            buttonGroupSort.BackColor = ColorTranslator.FromHtml("#505160");
            buttonGroupSort.FlatAppearance.BorderSize = 0;
            buttonGroupSort.FlatStyle = FlatStyle.Flat;
            buttonGroupSort.ForeColor = ColorTranslator.FromHtml("#AEBD38");
            buttonGroupSort.Font = new Font("Segoe Print", 8, FontStyle.Regular, GraphicsUnit.Point);

            buttonCourseSort.BackColor = ColorTranslator.FromHtml("#505160");
            buttonCourseSort.FlatAppearance.BorderSize = 0;
            buttonCourseSort.FlatStyle = FlatStyle.Flat;
            buttonCourseSort.ForeColor = ColorTranslator.FromHtml("#AEBD38");
            buttonCourseSort.Font = new Font("Segoe Print", 8, FontStyle.Regular, GraphicsUnit.Point);

            studentsListBox.Font = new Font("Segoe Print", 7.8f, FontStyle.Regular, GraphicsUnit.Point);
            listSearchResult.Font = new Font("Segoe Print", 7.8f, FontStyle.Regular, GraphicsUnit.Point);

            //studentsListForm.ForeColor = ColorTranslator.FromHtml("#34675C"); // Color.FromArgb(174, 189, 56);
        }

        public static AppSettingsSingleton GetInstance(StudentsListForm studentsListForm, Button b1, Button b2, Button b3, Button b4, Button b5, Button b6, Button b7, Button b8, Button b9, ListBox lb1, ListBox lb2)
        {
            thisStudentsListForm = studentsListForm;
            buttonSearch = b1;
            createStudButt = b2;
            delStudButt = b3;
            saveButton = b4;
            importButton = b5;
            buttonExpSort = b6;
            buttonGroupSort = b7;
            buttonCourseSort = b8;
            copyButton = b9;
            studentsListBox = lb1;
            listSearchResult = lb2;
            //var formType = Assembly.GetExecutingAssembly().GetTypes()
            //.Where(a => a.BaseType == typeof(Form) && a.Name == "StudentsListForm")     // a.BaseType == typeof(StudentsListForm)
            //.FirstOrDefault();

            //if (formType == null) // If there is no form with the given frmname
            //{
            //    studentsListForm = null;
            //    MessageBox.Show("no StudentsListForm");
            //}

            //else
            //{
            //    studentsListForm = formType;               //(StudentsListForm)Activator.CreateInstance(formType);

            //}

            //studentsListForm = (StudentsListForm)Assembly.GetExecutingAssembly().GetModule("StudentsListForm");

            return lazyAppFormSettings.Value;
            

            
        }

        //public AppSettingsSingleton(Button buttonSearch1, Button createStudButt, Button delStudButt, Button saveButton, Button importButton,
        //    Button buttonExpSort, Button buttonGroupSort, Button buttonCourseSort)
        //{
        //    buttonSearch1.BackColor = ColorTranslator.FromHtml("#34675C");
        //}

        //public static AppSettingsSingleton GetControlsInstance(Button b1, Button b2, Button b3, Button b4, Button b5, Button b6, Button b7, Button b8)
        //{
        //    buttonSearch = b1;
        //    createStudButt = b2;
        //    delStudButt = b3;
        //    saveButton = b4;
        //    importButton = b5;
        //    buttonExpSort = b6;
        //    buttonGroupSort = b7;
        //    buttonCourseSort = b8;

        //    return lazyAppButtonSettings.Value;
        //}

        //private Form TryGetFormByName(string frmname)
        //{
        //    var formType = Assembly.GetExecutingAssembly().GetTypes()
        //        .Where(a => a.BaseType == typeof(Form) && a.Name == frmname)
        //        .FirstOrDefault();

        //    if (formType == null) // If there is no form with the given frmname
        //        return null;

        //    return (Form)Activator.CreateInstance(formType);
        //}
    }
}
