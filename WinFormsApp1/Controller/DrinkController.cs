using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Model;

namespace WinFormsApp1.Controller
{
    public class DrinkController
    {
        public DrinkController()
        {
            AllDrinks = new AllDrink();
        }
        public AllDrink AllDrinks { get; set; }
    }
}
