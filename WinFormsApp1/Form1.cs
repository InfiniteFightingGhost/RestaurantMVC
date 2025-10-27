using WinFormsApp1.Controller;
using WinFormsApp1.Model;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        FoodController foodControl;
        DrinkController drinkControl;
        public Form1()
        {
            InitializeComponent();
            panel2.Visible = false;
            panel3.Visible = false;
            foodControl = new FoodController();
            drinkControl = new DrinkController();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!panel2.Visible)
            {
                button3.Location = new Point(21, 425);
                panel2.Location = new Point(10, 135);
                panel2.Visible = true;
                if (panel3.Visible)
                {
                    panel3.Location = new Point(panel3.Location.X, button3.Location.Y + 47);
                }
            }
            else
            {
                panel2.Visible = false;
                button3.Location = new Point(21, 135);
                if (panel3.Visible)
                {
                    panel3.Location = new Point(panel3.Location.X, button3.Location.Y + 47);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!panel3.Visible)
            {
                panel3.Visible = true;
                panel3.Location = new Point(11, button3.Location.Y + 47);
            }
            else
            {
                panel3.Visible = false;
                panel3.Location = new Point(11, button3.Location.Y + 47);
            }
        }

        private void button17_Click(object sender, EventArgs e)
        {
            drinkControl.AllDrinks.AddDrinkToFile();
            foodControl.allFood.WriteFoodsToFile();
            Close();
        }

        private void label2_Click(object sender, EventArgs e) { }

        private void button18_Click(object sender, EventArgs e)
        {
            string name = textBox3.Text;
            double price = double.Parse(textBox4.Text);
            int amount = int.Parse(textBox5.Text);
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            if (radioButton1.Checked)
            {
                drinkControl.AddSoftDrink(name, price, amount);
            }
            else if (radioButton2.Checked)
            {
                double percent = double.Parse(textBox6.Text);
                textBox6.Text = "";
                drinkControl.AddAlcoholicDrink(name, price, amount, percent);
            }
        }

        private void button10_Click(object sender, EventArgs e)
        {
            tabGroup.SelectTab(AddDrink);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            tabGroup.SelectTab(AddFood);
        }

        private void button19_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            double price = double.Parse(textBox2.Text);
            List<string> allergens = textBox7.Text.Split(";").ToList();
            List<string> ingredients = textBox7.Text.Split(";").ToList();
            List<string> addOns = new List<string>();
            bool is_vegetarian = false;
            if (checkBox1.Checked)
                addOns.Add("Extra meat");
            if (checkBox2.Checked)
                addOns.Add("Extra sauce");
            if (checkBox3.Checked)
                addOns.Add("Extra veg");
            if (radioButton3.Checked)
                is_vegetarian = true;
            else if(radioButton4.Checked)
                is_vegetarian = false;
            if(radioButton5.Checked)
            {
                Appetizer appetizer = new Appetizer(name, price, is_vegetarian);
                appetizer.Allergens = allergens;
                appetizer.AddOns = addOns;
                appetizer.Ingredients = ingredients;
            }
        }
    }
}
