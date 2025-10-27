using System.Text;
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
        public List<string> ReadSoftDrinksList()
        {
            List<string> drinks = new List<string>();
            foreach (var line in AllDrinks.Drinks.Where(d => d is SoftDrink))
            {
                drinks.Add(line.ToString());
            }
            return drinks;
        }
        public List<string> ReadAlcoholicDrinksList()
        {
            List<string> drinks = new List<string>();
            foreach (var line in AllDrinks.Drinks.Where(d => d is AlcoholicDrink))
            {
                drinks.Add(line.ToString());
            }
            return drinks;
        }
    }
}
