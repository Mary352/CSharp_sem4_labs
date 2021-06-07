using lab_4_5.AbstractFactoryPattern;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4_5.DecoratorPattern
{
    [Serializable]
    class StudwithAddress : StudentDecorator
    {
        public StudwithAddress(Student st) : base(st)
        { }

        public override string ToString()
        {
            return student.ToString() + student.Address.ToString();
        }
    }
}
