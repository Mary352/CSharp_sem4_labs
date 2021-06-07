using lab_4_5.Univer_classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4_5.AbstractFactoryPattern.Interfaces
{
    public interface IFactory
    {
        string Surname { get; set; }
        string Name { get; set; }
        string Patronymic { get; set; }
        string Speciality { get; set; }
        int Age { get; set; }
        int Course { get; set; }
        int Group { get; set; }
        DateTime DateBirth { get; set; }
        double AverageMark { get; set; }
        string Gender { get; set; }
        IAddress Address { get; set; }
        IPlaceWork PlaceWork { get; set; }

        IAddress CreateAddress(string country, string city, string postcode, string street, string house, string apt);
        IPlaceWork CreatePlaceWork(string company, string city, string position, int experience, string country);
        //Prototype<IFactory> DeepCopy();
    }
}
