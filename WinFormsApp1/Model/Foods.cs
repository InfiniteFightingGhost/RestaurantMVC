using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    internal class AllFood
    {
        public AllFood()
        {
            Foods = new List<Food>();
        }
        public List<Food> Foods { get; set; }
    }
}
