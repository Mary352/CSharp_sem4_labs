using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10.Classes
{
    [Serializable]
    public class PlaceWork
    {
        private string company, position;
        private int experience; // - masked TB

        public string Company { get => company; set => company = value; }
        public string Position { get => position; set => position = value; }
        public int Experience { get => experience; set => experience = value; }

        public PlaceWork() { }

        public PlaceWork(string company, string position, int experience)
        {
            this.company = company;
            this.position = position;
            this.experience = experience;
        }

        public override string ToString()
        {
            return $"{company} - должность: {position}, стаж: {experience}";
        }
    }
}
