using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    internal class Dessert : Food
    {
        public Dessert(string name, double price, bool is_vegan) : base(name, price, is_vegan)
        {
        }
    }
}
