using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace lab_4_5.Validation
{
    class PostcodeValidate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Regex regExpPost = new Regex(@"[1-9]{6}");

            if (value != null)
            {
                string postcode = value.ToString();
                // regex
                if (regExpPost.IsMatch(postcode))
                {
                    return true;
                }
                else
                    this.ErrorMessage = "Неверный индекс";
            }

            return false;
        }
    }
}
