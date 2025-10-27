namespace WinFormsApp1.Model
{
    public class Drink
    {
        public Drink(string name, double price, int milliliters)
        {
            Name = name;
            Price = price;
            Milliliters = milliliters;
        }

        public string Name { get; set; }
        public double Price { get; set; }
        public int Milliliters { get; set; }

        public override string ToString()
        {
            return $"{this.GetType().Name}|{Name}|{Price}|{Milliliters}";
        }
    }
}