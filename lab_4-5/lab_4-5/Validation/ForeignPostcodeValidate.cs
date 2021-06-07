using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace lab_4_5.Validation
{
    class ForeignPostcodeValidate : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            Regex regForeignExpPost = new Regex(@"([1-9]{0,6}[a-z]{0,6}){3,6}");

            if (value != null)
            {
                string postcode = value.ToString();
                // regex
                if (regForeignExpPost.IsMatch(postcode))
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
