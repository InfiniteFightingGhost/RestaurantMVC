using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    internal class MainCourse : Food
    {
        public MainCourse(string name, double price, bool is_vegan) : base(name, price, is_vegan) { }
    }
}
