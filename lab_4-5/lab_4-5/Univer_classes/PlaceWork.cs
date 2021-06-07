using lab_4_5.AbstractFactoryPattern.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4_5.Univer_classes
{
    [Serializable]
    public class PlaceWork : IPlaceWork
    {
        private string company, position, city, country;
        private int experience; // - masked TB

        public string Company { get => company; set => company = value; }
        public string City { get => city; set => city = value; }
        public string Position { get => position; set => position = value; }
        public int Experience { get => experience; set => experience = value; }
        public string Country { get => country; set => country = value; }
        public string SpecificPW_Labal => "not foreign";

        public PlaceWork() { }

        public PlaceWork(string company, string city, string position, int experience, string country)
        {
            this.company = company;
            this.city = city;
            this.position = position;
            this.experience = experience;
        }

        public override string ToString()
        {
            return $" {company} - должность: {position}, стаж: {experience}";
        }
    }
}
