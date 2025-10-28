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
            tabGroup.SelectTab(MainMenu);
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
            List<string> ingredients = textBox8.Text.Split(";").ToList();
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
            else if (radioButton4.Checked)
                is_vegetarian = false;
            string type = "";
            if (radioButton6.Checked)
            {
                type = "Appetizer";
            }
            else if (radioButton5.Checked)
            {
                type = "MainCourse";
            }
            else if (radioButton7.Checked)
            {
                type = "Dessert";
            }

            foodControl.AddFood(name, price, allergens, ingredients, addOns, is_vegetarian, type);
            textBox1.Text = "";
            textBox2.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
        }

        private void button11_Click(object sender, EventArgs e)
        {
            tabGroup.SelectTab(DeleteDrink);
        }

        private void button20_Click(object sender, EventArgs e)
        {
            string name = textBox9.Text;
            drinkControl.DeleteDrink(name);
            textBox9.Text = "";
        }

        private void button14_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            foreach (string item in drinkControl.PrintAllDrinkTypes())
            {
                listBox1.Items.Add(item);
            }
            tabGroup.SelectTab(ListAllDrinks);
        }

        private void button12_Click(object sender, EventArgs e)
        {
            tabGroup.SelectTab(ChangeInfoDrink);
        }

        private void button15_Click(object sender, EventArgs e)
        {
            listBox2.Items.Clear();
            foreach (string item in drinkControl.ReadSoftDrinksList())
            {
                listBox2.Items.Add(item);
            }
            tabGroup.SelectTab(ListAllSoftDrinks);
        }

        private void button16_Click(object sender, EventArgs e)
        {
            listBox3.Items.Clear();
            foreach (string item in drinkControl.ReadAlcoholicDrinksList())
            {
                listBox3.Items.Add(item);
            }
            tabGroup.SelectTab(ListAllAlcoholicDrinks);

        }

        private void button21_Click(object sender, EventArgs e)
        {
            string name = textBox10.Text;
            string newInfo = textBox11.Text;
            textBox10.Text = "";
            textBox11.Text = "";
            string parameter = "";
            if (radioButton10.Checked)
                parameter = "Name";
            else if (radioButton9.Checked)
                parameter = "Price";
            else if (radioButton8.Checked)
                parameter = "Milliliters";
            else if (radioButton11.Checked)
                parameter = "PercentAlcohol";
            else parameter = "Error";
            drinkControl.ChangeDrinkInfo(name, newInfo, parameter);

        }

        private void button22_Click(object sender, EventArgs e)
        {
            string name = textBox12.Text;
            foodControl.DeleteFood(name);
            textBox12.Text = "";
        }

        private void button6_Click(object sender, EventArgs e)
        {
            listBox4.Items.Clear();
            foreach (string item in foodControl.ListAllFoodTypes())
            {
                listBox4.Items.Add(item);
            }
            tabGroup.SelectTab(ListAllFood);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            listBox5.Items.Clear();
            foreach (string item in foodControl.ListAllAppetizers())
            {
                listBox5.Items.Add(item);
            }
            tabGroup.SelectTab(ListAllAppetizers);

        }

        private void button8_Click(object sender, EventArgs e)
        {
            listBox6.Items.Clear();
            foreach (string item in foodControl.ListAllMainCourses())
            {
                listBox6.Items.Add(item);
            }
            tabGroup.SelectTab(ListAllMainCourses);
        }

        private void button9_Click(object sender, EventArgs e)
        {
            listBox7.Items.Clear();
            foreach (string item in foodControl.ListAllDesserts())
            {
                listBox7.Items.Add(item);
            }
            tabGroup.SelectTab(ListAllDesserts);
        }
    }
}
