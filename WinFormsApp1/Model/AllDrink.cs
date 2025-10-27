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

        public string AddSoftDrink(string name, double price, int ml)
        {
            File.WriteAllText("drinks.txt", $"SoftDrink|{name}|{price}|{ml}ml");
            return "Soft drink added successfully";
        }
        public string AddAlcoholicDrink(string name, double price, int ml, double percent)
        {
            File.WriteAllText("drinks.txt", $"AlcoholicDrink|{name}|{price}|{ml}ml|{percent:f1}%");
            return "Alcoholic drink added successfully";
        }
        public string ChangeDrinkInfo(string name, double price, int ml, double percent)
        {
            var lines = File.ReadAllLines("drinks.txt").ToList();
            for (int i = 0; i < lines.Count; i++)
            {
                if (lines[i].Contains(name))
                {
                    if (percent > 0)
                    {
                        lines[i] = $"AlcoholicDrink|{name}|{price}|{ml}ml|{percent:f1}%";
                    }
                    else
                    {
                        lines[i] = $"SoftDrink|{name}|{price}|{ml}ml";
                    }
                }
            }
            return "Drink info changed successfully";
        }
        public string AddDrinksFromFile()
        {
            StreamReader sr = new StreamReader("drinks.txt", Encoding.UTF8);
            using (sr)
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    string[] parts = line.Split('|');
                    if (parts.Length > 3 && parts[3].Contains('%'))
                    {
                        string name = parts[1];
                        double price = double.Parse(parts[2]);
                        int ml = int.Parse(parts[3].Replace("ml", "").Trim());
                        double percent = double.Parse(parts[4].Replace("%", "").Trim());
                        Drinks.Add(new AlcoholicDrink(name, price, ml, percent));
                    }
                    else
                    {
                        string name = parts[1];
                        double price = double.Parse(parts[2]);
                        int ml = int.Parse(parts[3].Replace("ml", "").Trim());
                        Drinks.Add(new SoftDrink(name, price, ml));
                    }
                }
            }
            return "Drinks loaded successfully";
        }
        public string DeleteDrinkFromFile(string name)
        {
            var lines = File.ReadAllLines("drinks.txt").ToList();
            lines = lines.Where(line => !line.Contains(name)).ToList();
            File.WriteAllLines("drinks.txt", lines);
            return "Drink deleted successfully";
        }
    }
}
