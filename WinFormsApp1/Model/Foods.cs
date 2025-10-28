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
            ReadFoodsFromFile();
        }
        public List<Food> Foods { get; set; }
        public void WriteFoodsToFile()
        {
            StreamWriter writer = new StreamWriter("foods.txt", false, Encoding.UTF8);
            using (writer)
            {
                writer.Write(string.Join("\n", Foods.Select(a => a.ToFile())));
            }
        }
        public void ReadFoodsFromFile()
        {
            StreamReader reader = new StreamReader("foods.txt", Encoding.UTF8);
            using (reader)
            {
                var lines = reader.ReadLine();
                while (lines != null)
                {
                    string[] line = lines.Split("|");
                    string type = line[0];
                            string name = line[1];
                    double price = double.Parse(line[2]);
                    List<string> ingredients = line[3].Split(" ").Last().Split(";").ToList();
                    List<string> allergies = line[4].Split(" ").Last().Split(";").ToList();
                    List<string> addOns = line[5].Split(" ").Last().Split(";").ToList();
                    bool is_vegan = bool.Parse(line[6].Split(" ").Last());
                    switch (type)
                    {
                        case "Appetizer":
                            Appetizer app = new Appetizer(name, price, is_vegan);
                            app.Ingredients = ingredients;
                            app.Allergens = allergies;
                            app.AddOns = addOns;
                            Foods.Add(app);
                            break;
                        case "MainCourse":
                            MainCourse main = new MainCourse(name, price, is_vegan);
                            main.Ingredients = ingredients;
                            main.Allergens = allergies;
                            main.AddOns = addOns;
                            Foods.Add(main);
                            break;
                        case "Dessert":
                            Dessert dessert = new Dessert(name, price, is_vegan);
                            dessert.Ingredients = ingredients;
                            dessert.Allergens = allergies;
                            dessert.AddOns = addOns;
                            Foods.Add(dessert);
                            break;
                    }
                    lines = reader.ReadLine();
                }
            }
        }
    }
}
