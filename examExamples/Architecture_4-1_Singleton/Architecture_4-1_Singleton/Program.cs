using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture_4_1_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            // нет неявного конструктора, т.к. есть явный приватный конструктор, который недоступен,
            // поэтому нельзя создать объект класса используя конструктор
            //Singleton singleton = new Singleton();

            Singleton.GetInstance();
        }
    }
}
