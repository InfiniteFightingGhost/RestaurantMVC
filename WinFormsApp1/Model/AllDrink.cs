using System.Text;

namespace WinFormsApp1.Model
{
    public class AllDrink
    {
        public AllDrink()
        {
            Drinks = new List<Drink>();
        }
        public List<Drink> Drinks { get; set; }

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
        public string AddDrinkToFile(Drink drink)
        {
            using (StreamWriter sw = new StreamWriter("drinks.txt", false, Encoding.UTF8))
            {
                sw.WriteLine(drink.ToString());
            }
            return "Drink added successfully";
        }
    }
}
