using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Model;

namespace WinFormsApp1.Controller
{
    internal class FoodController
    {
        public AllFood allFood;
        public FoodController()
        {
            allFood = new AllFood();
        }
        public string AddFood(string name, double price, List<string> allergens, List<string> ingredients,
            List<string> addOns, bool is_vegeterian, string type)
        {
            Food food = null;
            switch(type)
            {
                case "Appetizer":
                    food = new Appetizer(name, price, is_vegeterian);
                    break;
                case "MainCourse":
                    food = new MainCourse(name, price, is_vegeterian);
                    break;
                case "Dessert":
                    food = new Dessert(name, price, is_vegeterian);
                    break;
            }
            food.Allergens = allergens;
            food.AddOns = addOns;
            food.Ingredients = ingredients;
            allFood.Foods.Add(food);
            return "Food was added successfully!";
        }
        public string DeleteFood(string name)
        {
            Food food = allFood.Foods.FirstOrDefault(x => x.Name == name);
            if (food != null)
            {
                allFood.Foods.Remove(food);
                return "Food was removed successfully!";
            }
            else
            {
                return "There doesnt exist such a food!";
            }
        }
        public string ChangeInfo(string name, string newInfo, string property)
        {
            Food food = allFood.Foods.FirstOrDefault(x => x.Name == name);
            if (food != null)
            {
                switch(property)
                {
                    case "Name":
                        food.Name = newInfo;
                        break;
                    case "Price":
                        food.Price = double.Parse(newInfo);
                        break;
                    case "Allergens":
                        food.Allergens = newInfo.Split(";").ToList();
                        break;
                    case "Ingredients":
                        food.Ingredients = newInfo.Split(";").ToList();
                        break;
                    case "AddOns":
                        food.AddOns = newInfo.Split(";").ToList();
                        break;
                    case "Is_Vegan":
                        food.Is_Vegan = bool.Parse(newInfo);
                        break;
                    default:
                        return "Incorrent property specified";
                }
                return "Property was changes successfully";
            }
            else
            {
                return "There isnt such a food";
            }
        }
        public string[] ListAllFoodTypes()
        {
            return allFood.Foods.Select(x => $"{x.GetType().Name} - {x.Name}").ToArray();
        }
        public string[] ListAllAppetizers()
        {
            return allFood.Foods.Where(x => x is Appetizer).Select(x => x.ToString()).ToArray();
        }

        public string[] ListAllMainCourses()
        {
            return allFood.Foods.Where(x => x is MainCourse).Select(x => x.ToString()).ToArray();
        }
        public string[] ListAllDesserts()
        {
            return allFood.Foods.Where(x => x is Dessert).Select(x => x.ToString()).ToArray();
        }
        public string[] ListBetweenPrices(double minPrice, double MaxPrice)
        {
            return allFood.Foods
                .Where(x => x.Price >= minPrice && x.Price <= MaxPrice)
                .Select(x => x.ToString())
                .ToArray();
        }
    }
}
