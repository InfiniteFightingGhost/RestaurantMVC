using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class AlcoholicDrink:Drink
    {
        public AlcoholicDrink(string name, double price, int milliliters, double percentalcohol) : base(name, price, milliliters)
        {
            PercentAlcohol = percentalcohol;
        }
        public double PercentAlcohol { get; set; }

        public override string ToString()
        {
            return base.ToString() + $"|{PercentAlcohol:f1}%";
        }
    }
}
