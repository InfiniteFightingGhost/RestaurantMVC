using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    public class AllDrink
    {
        public AllDrink()
        {
            Drinks = new List<Drink>();
        }
        public List<Drink> Drinks { get; set; }
    }
}
