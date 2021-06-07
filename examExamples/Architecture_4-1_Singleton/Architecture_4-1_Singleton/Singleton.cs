using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Architecture_4_1_Singleton
{
    class Singleton
    {
        private static readonly Lazy<Singleton> Lazy = new Lazy<Singleton>(() => new Singleton());

        private Singleton()
        {

        }

        public static Singleton GetInstance()
        {
            return Lazy.Value;
        }
    }
}
