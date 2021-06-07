﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace lab_10.Classes
{
    [Serializable]
    public class Student
    {
        private string surname, name, patronymic, speciality;
        private int age, course, group, addressId;
        private DateTime dateBirth;
        private double averageMark;
        private string gender;
        public ImageSource photo;

        public string Surname { get => surname; set => surname = value; }
        public string Name { get => name; set => name = value; }
        public string Patronymic { get => patronymic; set => patronymic = value; }
        public int Age { get => age; set => age = value; }
        public string Speciality { get => speciality; set => speciality = value; }
        public DateTime DateBirth { get => dateBirth; set => dateBirth = value; }
        public int Course { get => course; set => course = value; }
        public int Group { get => group; set => group = value; }
        public double AverageMark { get => averageMark; set => averageMark = value; }
        public string Gender { get => gender; set => gender = value; }
        public int AddressId { get => addressId; set => addressId = value; }
        public ImageSource Photo { get => photo; set => photo = value; }

        public Student() { }

        public Student(string surname, string name, string patronymic, int age, string speciality, DateTime dateBirth, int course, int group,
            double averageMark, string gender, int addressId, ImageSource photo)
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
            this.addressId = addressId;
            this.photo = photo;
        }

        public override string ToString()
        {
            return $"{surname} {name} {patronymic} ({gender}) - {speciality} {course} курс {group} группа - средний балл: {averageMark}";
        }
    }
}
