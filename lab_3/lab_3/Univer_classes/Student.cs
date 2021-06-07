using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Univer_classes
{
    [Serializable]
    public class Student
    {
        private string surname;
        private string name;
        private string patronymic;
        private string speciality;
        private int age;
        private int course, group;
        private DateTime dateBirth;
        private double averageMark;
        private string gender;
        private Address address;
        private PlaceWork placeWork;

        //[Required(ErrorMessage = "Отсутствует фамилия")]
        [StringLength(5, ErrorMessage = "Недопустимая длина фамилии")]
        [RegularExpression(@"[A-Z]{0,1}[А-Я]{0,1}[a-z]*[а-я]*", ErrorMessage = "Фамилия имеет недопутимый(-ые) символ(ы)")]
        public string Surname { get => surname; set => surname = value; }
        //[Required(ErrorMessage = "Отсутствует имя")]
        [StringLength(50, ErrorMessage = "Недопустимая длина имени")]
        [RegularExpression(@"[A-Z]{0,1}[А-Я]{0,1}[a-z]*[а-я]*", ErrorMessage = "Имя имеет недопутимый(-ые) символ(ы)")]
        public string Name { get => name; set => name = value; }
        //[Required(ErrorMessage = "Отсутствует отчество")]
        [StringLength(50, ErrorMessage = "Недопустимая длина отчества")]
        [RegularExpression(@"[A-Z]{0,1}[А-Я]{0,1}[a-z]*[а-я]*", ErrorMessage = "Отчество имеет недопутимый(-ые) символ(ы)")]
        public string Patronymic { get => patronymic; set => patronymic = value; }
        //[Required(ErrorMessage = "Отсутствует возраст")]
        [Range(17, 99, ErrorMessage = "Недопустимый возраст")]
        public int Age { get => age; set => age = value; }
        //[Required(ErrorMessage = "Отсутствует специальность")]
        [StringLength(10, ErrorMessage = "Недопустимая длина специальности")]
        public string Speciality { get => speciality; set => speciality = value; }
        public DateTime DateBirth { get => dateBirth; set => dateBirth = value; }
        public int Course { get => course; set => course = value; }
        public int Group { get => group; set => group = value; }
        //[Required(ErrorMessage = "Отсутствует средний балл")]
        [Range(0.0, 10.0, ErrorMessage = "Недопустимый средний балл")]
        public double AverageMark { get => averageMark; set => averageMark = value; }
        public string Gender { get => gender; set => gender = value; }
        public Address Address { get => address; set => address = value; }
        public PlaceWork PlaceWork { get => placeWork; set => placeWork = value; }

        public Student() { }

        public Student(string surname, string name, string patronymic, int age, string speciality, DateTime dateBirth, int course, int group,
            double averageMark, string gender, Address address, PlaceWork placeWork)
        {
            this.surname = surname;
            this.name = name;
            this.patronymic = patronymic;
            this.age = age;
            this.speciality = speciality;
            this.dateBirth = dateBirth;
            this.course = course;
            this.group = group;
            this.averageMark = averageMark;
            this.gender = gender;
            this.address = address;
            this.placeWork = placeWork;
        }

        public override string ToString()
        {
            return $"{surname} {name} {patronymic} ({gender}) - {speciality} {course} курс {group} группа - средний балл: {averageMark}; стаж - {placeWork.Experience}";
        }
    }
}
