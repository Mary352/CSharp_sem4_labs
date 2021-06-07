using lab_4_5.AbstractFactoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4_5.DecoratorPattern
{
    [Serializable]
    class StudwithPlacework : StudentDecorator
    {
        public StudwithPlacework(Student st) : base(st)
        { }

        public override string ToString()
        {
            return student.ToString() + student.PlaceWork.ToString();
        }
    }
}
