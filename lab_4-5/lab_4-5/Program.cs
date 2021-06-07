using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using lab_4_5.Univer_classes;

namespace lab_4_5
{
    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            StudentsListForm formStudentsList = new StudentsListForm();
            //AppSettingsSingleton.GetInstance(formStudentsList);
            Application.Run(formStudentsList);
        }
    }
}
