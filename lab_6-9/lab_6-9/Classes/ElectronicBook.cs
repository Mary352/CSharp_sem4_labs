using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace lab_6_9.Classes
{
    [Serializable]
    public class ElectronicBook : DependencyObject
    {
        //public static readonly DependencyProperty Name2Property;
        //public static readonly DependencyProperty Weight2Property;

        private string name, manufactuter, screenTechnology, screenResolution, bodyMater, color, imagePath;
        private double price, screenSize,  weight, rating;
        private bool backlight;
        private int ram;
        private List<string> txtFormatsSupport = new List<string>();

        //public string Name2
        //{
        //    get { return (string)GetValue(Name2Property); }
        //    set { SetValue(Name2Property, value); }
        //}
        //public double Weight2
        //{
        //    get { return (double)GetValue(Weight2Property); }
        //    set { SetValue(Weight2Property, value); }
        //}

        public string Name { get => name; set => name = value; }
        public string Manufactuter { get => manufactuter; set => name = manufactuter; }
        public string ScreenTechnology { get => screenTechnology; set => screenTechnology = value; }
        public string ScreenResolution { get => screenResolution; set => screenResolution = value; }
        public string BodyMater { get => bodyMater; set => bodyMater = value; }
        public string Color { get => color; set => color = value; }
        public string ImagePath { get => imagePath; set => imagePath = value; }
        public double Price { get => price; set => price = value; }
        public double ScreenSize { get => screenSize; set => screenSize = value; }
        public double Weight { get => weight; set => weight = value; }
        public double Rating { get => rating; set => rating = value; }
        public bool Backlight { get => backlight; set => backlight = value; }
        public int RAM { get => ram; set => ram = value; }
        public List<string> TxtFormatsSupport { get => txtFormatsSupport; set => txtFormatsSupport = value; }

        
        public ElectronicBook() { }

        public ElectronicBook(string name, string manufactuter, string screenTechnology, string screenResolution,
            string bodyMater, string color, string imagePath, double price, double screenSize, 
            double rating, double weight, bool backlight, int ram, List<string> txtFormatsSupport)
        {
            this.name = name;
            this.manufactuter = manufactuter;
            this.screenTechnology = screenTechnology;
            this.screenResolution = screenResolution;
            this.bodyMater = bodyMater;
            this.color = color;
            this.imagePath = imagePath;
            this.price = price;
            this.screenSize = screenSize;
            this.rating = rating;
            this.weight = weight;
            this.backlight = backlight;
            this.ram = ram;
            this.txtFormatsSupport = txtFormatsSupport;


            //MessageBox.Show("name "+name);
            //MessageBox.Show("manufactuter " + manufactuter);
            //MessageBox.Show("screenTechnology " + screenTechnology);
            //MessageBox.Show("screenResolution " + screenResolution);
            //MessageBox.Show("bodyMater " + bodyMater);
            //MessageBox.Show("color " + color);
            //MessageBox.Show("imagePath " + imagePath);
            //MessageBox.Show("price " + price.ToString());
            //MessageBox.Show("screenSize " + screenSize.ToString());
            //MessageBox.Show("rating " + rating.ToString());
            //MessageBox.Show("weight " + weight.ToString());
            //MessageBox.Show("backlight " + backlight.ToString());
            //MessageBox.Show("ram " + ram.ToString());
            //foreach (var item in txtFormatsSupport)
            //{
            //    MessageBox.Show("txtFormatsSupport " + item);
            //}


            //MessageBox.Show("Name " + Name);
            //MessageBox.Show("name " + this.name);
            //MessageBox.Show("manufactuter " + manufactuter);
            //MessageBox.Show("screenTechnology " + screenTechnology);
            //MessageBox.Show("screenResolution " + screenResolution);
            //MessageBox.Show("bodyMater " + bodyMater);
            //MessageBox.Show("color " + color);
            //MessageBox.Show("imagePath " + imagePath);
            //MessageBox.Show("price " + price.ToString());
            //MessageBox.Show("screenSize " + screenSize.ToString());
            //MessageBox.Show("rating " + rating.ToString());
            //MessageBox.Show("weight " + weight.ToString());
            //MessageBox.Show("backlight " + backlight.ToString());
            //MessageBox.Show("ram " + ram.ToString());
            //foreach (var item in txtFormatsSupport)
            //{
            //    MessageBox.Show("txtFormatsSupport " + item);
            //}
        }

        public override string ToString()
        {
            return Name + " " + Manufactuter + " " + ScreenTechnology + " " + ScreenResolution + " " + BodyMater + " " + Color +
                 " " + ImagePath + " " + Price + " " + ScreenSize + " " + Rating + " " + Weight + " " + Backlight
                  + " " + RAM;
        }
    }
}
