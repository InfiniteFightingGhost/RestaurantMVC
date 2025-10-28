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
                    if (parts[0] == "AlcoholicDrink")
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
        public string AddDrinkToFile()
        {
            using (StreamWriter sw = new StreamWriter("drinks.txt", false, Encoding.UTF8))
            {
                foreach(var drink in Drinks)
                {
                    sw.WriteLine(drink.ToFile());
                }
            }
            return "Drinks added successfully";
        }
    }
}
