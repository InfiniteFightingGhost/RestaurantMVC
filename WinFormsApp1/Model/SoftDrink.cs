using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class SoftDrink : Drink
    {
        public SoftDrink(string name, double price, int milliliters) : base(name, price, milliliters) { }
    }
}
