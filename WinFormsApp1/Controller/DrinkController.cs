using System.Text;
using WinFormsApp1.Model;

namespace WinFormsApp1.Controller
{
    public class DrinkController
    {
        public DrinkController()
        {
            AllDrinks = new AllDrink();
            AllDrinks.AddDrinksFromFile();
        }
        public AllDrink AllDrinks { get; set; }

        public string AddSoftDrink(string name, double price, int ml)
        {
            AllDrinks.Drinks.Add(new SoftDrink(name, price, ml));
            return "Soft drink added successfully";
        }
        public string AddAlcoholicDrink(string name, double price, int ml, double percent)
        {
            AllDrinks.Drinks.Add(new AlcoholicDrink(name, price, ml, percent));
            return "Alcoholic drink added successfully";
        }
        public List<string> ReadSoftDrinksList()
        {
            List<string> drinks = new List<string>();
            foreach (var line in AllDrinks.Drinks.Where(d => d is SoftDrink))
            {
                drinks.Add(line.ToString());
            }
            return drinks;
        }
        public List<string> PrintAllDrinkTypes()
        {
            return AllDrinks.Drinks.Select(d => $"{d.GetType().Name} - {d.Name}").ToList();
        }
        public string ChangeDrinkInfo(string name, string newInfo, string property)
        {
            Drink drink = AllDrinks.Drinks.FirstOrDefault(x => x.Name == name);
            if (drink != null)
            {
                switch (property)
                {
                    case "Name":
                        drink.Name = newInfo;
                        break;
                    case "Price":
                        drink.Price = double.Parse(newInfo);
                        break;
                    case "Milliliters":
                        drink.Milliliters = int.Parse(newInfo);
                        break;
                    case "PercentAlcohol":
                        if (drink is AlcoholicDrink alcoholicDrink)
                        {
                            alcoholicDrink.PercentAlcohol = double.Parse(newInfo);
                        }
                        else
                        {
                            return "This drink is not alcoholic";
                        }
                        break;
                    default:
                        return "Incorrent property specified";
                }
                return "Property was changed successfully";
            }
            else
            {
                return "There isnt such a food";
            }
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
        public string DeleteDrink(string name)
        {
           AllDrinks.Drinks.RemoveAll(d => d.Name == name);
           return "Drink removed successfully";
        }
    }
}
