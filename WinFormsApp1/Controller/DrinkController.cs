using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
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

        public void AddDrinkToFile()
        {
            StreamWriter sw = new StreamWriter("drinks.txt", true, Encoding.UTF8);
            using (sw)
            {
                foreach (var drink in AllDrinks.Drinks)
                {
                    sw.WriteLine(drink.ToString());
                }
            }
        }
        public void DeleteDrinkFromFile(string name)
        {
            var lines = File.ReadAllLines("drinks.txt").ToList();
            lines = lines.Where(line => !line.Contains(name)).ToList();
            File.WriteAllLines("drinks.txt", lines);
        }
        public List<string> ReadDrinksFromFile()
        {
            List<string> drinks = new List<string>();
            StreamReader sr = new StreamReader("drinks.txt", Encoding.UTF8);
            using (sr)
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    drinks.Add(line);
                }
            }
            return drinks;
        }
        public void ClearDrinksFile()
        {
            File.WriteAllText("drinks.txt", string.Empty);
        }
        public List<string> ReadSoftDrinksFromFile()
        {
            List<string> drinks = new List<string>();
            StreamReader sr = new StreamReader("drinks.txt", Encoding.UTF8);
            using (sr)
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (!line.Contains('%'))
                    {
                        drinks.Add(line);
                    }
                }
            }
            return drinks;
        }
        public List<string> ReadAlcoholicDrinksFromFile()
        {
            List<string> drinks = new List<string>();
            StreamReader sr = new StreamReader("drinks.txt", Encoding.UTF8);
            using (sr)
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    if (line.Contains('%'))
                    {
                        drinks.Add(line);
                    }
                }
            }
            return drinks;
        }

    }
}
