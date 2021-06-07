using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_3.Univer_classes
{
    [Serializable]
    public class Address
    {
        private string city, street, house, apt;
        private int postcode;
        // masked textbox for int 

        public string City { get => city; set => city = value; }
        [Required]
        [PostcodeValidate]
        public int Postcode { get => postcode; set => postcode = value; }
        public string Street { get => street; set => street = value; }
        public string House { get => house; set => house = value; }
        public string Apt { get => apt; set => apt = value; }

        public Address() { }

        public Address(string city, int postcode, string street, string house, string apt) 
        {
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
