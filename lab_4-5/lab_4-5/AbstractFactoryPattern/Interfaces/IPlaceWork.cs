using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4_5.AbstractFactoryPattern.Interfaces
{
    public interface IPlaceWork
    {
        string Company { get; set; }
        string City { get; set; }
        string Position { get; set; }
        string Country { get; set; }
        int Experience { get; set; }

        string SpecificPW_Labal { get; }
    }
}
