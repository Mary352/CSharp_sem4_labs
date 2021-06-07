using lab_4_5.AbstractFactoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4_5.DecoratorPattern
{
    [Serializable]
    abstract class StudentDecorator : Student
    {
        protected Student student;

        public StudentDecorator(Student st)
        {
            student = st;
        }
    }
}
