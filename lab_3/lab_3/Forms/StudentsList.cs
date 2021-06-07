using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using System.IO;
using lab_3.Univer_classes;
using System.Text.RegularExpressions;

namespace lab_3
{
    public partial class StudentsList : Form
    {
        XmlSerializer serializer = new XmlSerializer(typeof(BindingList<Student>));
        BindingList<Student> students = new BindingList<Student>();
        BindingList<Student> items = new BindingList<Student>();

        Timer timer;

        public StudentsList()
        {
            InitializeComponent();
            timer = new Timer() { Interval = 1000 };
            timer.Tick += timer_Tick;
            timer.Start();

            studentsListBox.DataSource = students;
            listSearchResult.DataSource = items;

            textSearch.Visible = false;
            buttonSearch.Visible = false;
            comboSearchOption.Visible = false;
            listSearchResult.Visible = false;

            buttonExpSort.Visible = false;
            buttonGroupSort.Visible = false;
            buttonCourseSort.Visible = false;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            toolStripDateTime.Text = DateTime.Now.ToString();

            toolStripNumberOfElements.Text = students.Count.ToString();
        }

        private void lastAction(string act)
        {
            toolStripLastAction.Text = act;
        }

        private void createStudButt_Click(object sender, EventArgs e)
        {
            using (StudentForm form = new StudentForm())
            {
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                    students.Add(form.stud);
            }
            lastAction("Новый студент");
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
            lastAction("Удалить студента");

        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            using (FileStream fs = new FileStream("StudentsList.xml", FileMode.Create))
            {
                serializer.Serialize(fs, students);
            }

            lastAction("Сохранить");
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            try
            {
                lastAction("Импорт");

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

        private void toolStripButtonAbout_Click(object sender, EventArgs e)
        {
            MessageBox.Show("v2.0.1.13 Крюкова Мария Сергеевна");
            lastAction("О программе");
        }

        private void toolStripButtonSearch_Click(object sender, EventArgs e)
        {
            //SearchForm form = new SearchForm(students);
            //form.ShowDialog();
            lastAction("Поиск");

            if (textSearch.Visible)
            {
                textSearch.Visible = false;
                buttonSearch.Visible = false;
                comboSearchOption.Visible = false;
                if (!buttonExpSort.Visible)
                {
                    listSearchResult.Visible = false;
                }
               
            }
            else
            {
                textSearch.Visible = true;
                buttonSearch.Visible = true;
                comboSearchOption.Visible = true;
                listSearchResult.Visible = true;
            }
            
        }

        private void buttonSearch_Click(object sender, EventArgs e)
        {
            items.Clear();
            try
            {
                lastAction("Поиск");

                string value = Helper.GetComboBoxValue(comboSearchOption);
                string searchQuery = Helper.GetStringValue(textSearch);
                //Regex r1 = new Regex($"(\\w*){searchQuery}(\\w*)");
                //string pattern1 = @"\w*";
                //string pattern = pattern1 + Regex.Escape(searchQuery) + pattern1;
                //Regex r1 = new Regex(pattern);
                //Regex r1 = new Regex($@"(\w*){Regex.Escape(searchQuery)}(\w*)");
                //Regex r5 = new Regex(@"\w*" + searchQuery + @"\w*");
                //Regex r6 = new Regex(@"[" + searchQuery + @"-10]");
                //Regex r2 = new Regex($@"[Regex.Escape(searchQuery)-10]");

                
                Regex regExpSNP = new Regex(@"([A-Z]{0,1}[А-Я]{0,1}[a-z]*[а-я]*)\s([A-Z]{0,1}[А-Я]{0,1}[a-z]*[а-я]*)\s([A-Z]{0,1}[А-Я]{0,1}[a-z]*[а-я]*)");
                Regex regExpSpec = new Regex(@"[А-Я]");
                Regex regExpCourse = new Regex(@"[1-5]");
                Regex regExpAverMark = new Regex(@"[0-9]\.[0-9][0-9]*");

                switch (value)
                {
                    case "ФИО":
                        if (regExpSNP.IsMatch(searchQuery))
                        {
                            string[] str = searchQuery.Split(new char[] { ' ' });

                            foreach (var c in students)
                            {
                                if ((c.Surname).Equals(str[0]) && (c.Name).Equals(str[1]) && (c.Patronymic).Equals(str[2]))
                                    items.Add(c);
                            }
                        }
                        else
                        {
                            MessageBox.Show("error string");
                        }
                        break;
                    case "Специальность":
                        if (regExpSpec.IsMatch(searchQuery))
                        {
                            foreach (var c in students)
                            {
                                if ((c.Speciality).Equals(searchQuery))
                                    items.Add(c);
                            }
                        }
                        else
                        {
                            MessageBox.Show("error string");
                        }

                        break;
                    case "Курс":
                        if (regExpCourse.IsMatch(searchQuery))
                        {
                            foreach (var c in students)
                            {
                                if ((c.Course.ToString()).Equals(searchQuery))
                                    items.Add(c);
                            }
                        }
                        else
                        {
                            MessageBox.Show("error string");
                        }

                        break;
                    case "Средний балл":
                        if (regExpAverMark.IsMatch(searchQuery))
                        {
                            string[] str = searchQuery.Split(new char[] { '.' });
                            searchQuery = str[0] + "," + str[1];

                            foreach (var c in students)
                            {
                                if (Convert.ToDouble(searchQuery) < c.AverageMark)
                                    items.Add(c);
                            }
                        }
                        else
                        {
                            MessageBox.Show("error string");
                        }

                        break;
                    default:
                        break;
                }               
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void toolStripButtonSort_Click(object sender, EventArgs e)
        {
            lastAction("Сортировка");

            if (buttonExpSort.Visible)
            {
                buttonExpSort.Visible = false;
                buttonGroupSort.Visible = false;
                buttonCourseSort.Visible = false;
                if (!textSearch.Visible)
                {
                    listSearchResult.Visible = false;
                }                
            }
            else
            {
                buttonExpSort.Visible = true;
                buttonGroupSort.Visible = true;
                buttonCourseSort.Visible = true;
                listSearchResult.Visible = true;
            }
        }

        private void buttonExpSort_Click(object sender, EventArgs e)
        {
            lastAction("Сортировка по стажу");

            var stList = items.OrderBy(s => s.PlaceWork.Experience).ToList();
            items.Clear();
            foreach (var st in stList)
            {
                items.Add(st);
            }

            var stList2 = students.OrderBy(s => s.PlaceWork.Experience).ToList();
            students.Clear();
            foreach (var st in stList2)
            {
                students.Add(st);
            }
        }

        private void buttonGroupSort_Click(object sender, EventArgs e)
        {
            lastAction("Сортировка по группе");


            var stList = items.OrderBy(s => s.Group).ToList();
            items.Clear();
            foreach (var st in stList)
            {
                items.Add(st);
            }

            var stList2 = students.OrderBy(s => s.Group).ToList();
            students.Clear();
            foreach (var st in stList2)
            {
                students.Add(st);
            }
        }

        private void buttonCourseSort_Click(object sender, EventArgs e)
        {
            lastAction("Сортировка по курсу");


            var stList = items.OrderBy(s => s.Course).ToList();
            items.Clear();
            foreach (var st in stList)
            {
                items.Add(st);
            }

            var stList2 = students.OrderBy(s => s.Course).ToList();
            students.Clear();
            foreach (var st in stList2)
            {
                students.Add(st);
            }
        } 

        private void поискToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonSearch_Click(sender, e);
        }

        private void сортировкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonSort_Click(sender, e);
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //saveButton_Click(sender, e);
            using (FileStream fs = new FileStream("StudentsListSort.xml", FileMode.Create))
            {
                serializer.Serialize(fs, items);
            }

            lastAction("Сохранить");

        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toolStripButtonAbout_Click(sender, e);
        }

        private void textSearch_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboSearchOption_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //private void studentsListBox_DataSourceChanged(object sender, EventArgs e)
        //{
        //    toolStripNumberOfElements.Text = ((BindingList<Student>)sender).Count.ToString();
        //}
    }
}
