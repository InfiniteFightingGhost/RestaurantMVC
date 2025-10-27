using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Model
{
    internal class Food
    {
        public Food(string name, double price, bool is_vegan)
        {
            Name = name;
            Price = price;
            Is_Vegan = is_vegan;
            Allergens = new List<string>();
            Ingredients = new List<string>();
            AddOns = new List<string>();
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public List<string> Allergens { get; set; }
        public List<string> Ingredients { get; set; }
        public List<string> AddOns { get; set; }
        public bool Is_Vegan { get; set; }
        public override string ToString()
        {
            return $"{this.GetType().Name}|{Name}|{Price}|Ingredients: {string.Join(";",Ingredients)}|Allergens: {string.Join(";", Allergens)}|Add ons: {string.Join(";", AddOns)}|Vegan: {Is_Vegan}";
        }


    }
}
