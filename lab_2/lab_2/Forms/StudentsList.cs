using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using lab_2.Univer_classes;

namespace lab_2
{
    public partial class StudentsList : Form
    {
        XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Student>));
        BindingList<Student> students = new BindingList<Student>();

        public StudentsList()
        {
            InitializeComponent();
            studentsListBox.DataSource = students;
        }

        private void createStudButt_Click(object sender, EventArgs e)
        {
            using (StudentForm form = new StudentForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                    students.Add(form.stud);
            }
        }

        private void delStudButt_Click(object sender, EventArgs e)
        {
            BindingList<Student> newListStudents = new BindingList<Student>(students.ToList());
            if(studentsListBox.SelectedIndex > -1)
            {
                foreach (Student item in studentsListBox.SelectedItems)
                    newListStudents.Remove(item);
            }

            students = newListStudents;
            studentsListBox.DataSource = students;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("StudentsList.xml", FileMode.Create))
            {
                serializer.Serialize(fs, students);
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            try
            {
                using (FileStream fs = new FileStream("StudentsList.xml", FileMode.Open))
                {
                    students = (BindingList<Student>)serializer.Deserialize(fs);
                    studentsListBox.DataSource = students;
                }
            }
            catch(FileNotFoundException)
            {
                MessageBox.Show("Отсутствует файл со списком студентов");
            }
            
        }
    }
}
