using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab_6_9.Classes
{
    public class ShortEBook : DependencyObject
    {
        public static readonly DependencyProperty Name2Property;
        public static readonly DependencyProperty Weight2Property;

        public string Name2
        {
            get { return (string)GetValue(Name2Property); }
            set { SetValue(Name2Property, value); }
        }
        public double Weight2
        {
            get { return (double)GetValue(Weight2Property); }
            set { SetValue(Weight2Property, value); }
        }

        static ShortEBook()
        {
            Name2Property = DependencyProperty.Register("Name2", typeof(string), typeof(ShortEBook));

            FrameworkPropertyMetadata metadata = new FrameworkPropertyMetadata();
            metadata.CoerceValueCallback = new CoerceValueCallback(CorrectValue);

            Weight2Property = DependencyProperty.Register("Weight2", typeof(double), typeof(ShortEBook), metadata,
                new ValidateValueCallback(ValidateValue));
        }

        private static object CorrectValue(DependencyObject d, object baseValue)
        {
            double currentValue = (double)baseValue;
            if (currentValue > 250d)  // если больше 200, возвращаем 200
                return 250d;
            return currentValue; // иначе возвращаем текущее значение
        }

        private static bool ValidateValue(object value)
        {
            double currentValue = -1.9;
            try
            {
                MessageBox.Show(value.ToString());
                currentValue = (double)value;


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "ValidateValue");
            }
            if (currentValue >= 0) // если текущее значение от нуля и выше
                return true;
            return false;
        }
    }
}
