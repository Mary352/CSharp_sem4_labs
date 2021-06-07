using lab_4_5.AbstractFactoryPattern.Interfaces;
using lab_4_5.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab_4_5.Univer_classes
{
    [Serializable]
    class AddressForeign : IAddress
    {
        private string city, street, house, apt, country, postcode;

        public string City { get => city; set => city = value; }
        public string Country { get => country; set => country = value; }
        [Required]
        [ForeignPostcodeValidate]
        public string Postcode { get => postcode; set => postcode = value; }
        public string Street { get => street; set => street = value; }
        public string House { get => house; set => house = value; }
        public string Apt { get => apt; set => apt = value; }
        public string SpecificAddrLabel => "foreign";

        public AddressForeign() { }

        public AddressForeign(string country, string city, string postcode, string street, string house, string apt)
        {
            this.country = country;
            this.city = city;
            this.postcode = postcode;
            this.street = street;
            this.house = house;
            this.apt = apt;
        }        

        public override string ToString()
        {
            return $" {house} {street}, #Apt {apt}, {city}, {postcode}, {country}";
        }
    }
}
