using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_10.Classes
{
    [Serializable]
    public class Address
    {
        private string city, street, house, apt, postcode;
        private int addrId;
        // masked textbox for int 

        public int AddrId { get => addrId; set => addrId = value; }
        public string City { get => city; set => city = value; }
        public string Postcode { get => postcode; set => postcode = value; }
        public string Street { get => street; set => street = value; }
        public string House { get => house; set => house = value; }
        public string Apt { get => apt; set => apt = value; }

        public Address() { }

        public Address(int addrId, string city, string postcode, string street, string house, string apt) 
        {
            this.addrId = addrId;
            this.city = city;
            this.postcode = postcode;
            this.street = street;
            this.house = house;
            this.apt = apt;
        }

        public override string ToString()
        {
            return $"г. {city}, {postcode}, ул. {street}, {house}-{apt}";
        }

    }
}
