using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using lab_4_5.AbstractFactoryPattern.Interfaces;
using lab_4_5.Validation;

namespace lab_4_5.Univer_classes
{
    [Serializable]
    public class Address : IAddress
    {
        private string city, street, house, apt;
        private string postcode;

        public string City { get => city; set => city = value; }
        [Required]
        [PostcodeValidate]
        public string Postcode { get => postcode; set => postcode = value; }
        public string Street { get => street; set => street = value; }
        public string House { get => house; set => house = value; }
        public string Apt { get => apt; set => apt = value; }
        public string SpecificAddrLabel => "not foreign";

        public Address() { }

        public Address(string country, string city, string postcode, string street, string house, string apt) 
        {
            this.city = city;
            this.postcode = postcode;
            this.street = street;
            this.house = house;
            this.apt = apt;
        }

        public override string ToString()
        {
            return $" г. {city}, {postcode}, ул. {street}, {house}-{apt}";
        }

    }
}
