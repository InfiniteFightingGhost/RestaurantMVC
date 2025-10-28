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
            RenderMenu();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!panel2.Visible)
            {
                button3.Location = new Point(18, 107 + 229 + 7);
                panel2.Location = new Point(10, 107);
                if (panel3.Visible)
                {
                    panel3.Location = new Point(panel3.Location.X, button3.Location.Y + 36);
                }
            }
            else
            {
                button3.Location = new Point(18, 107);
                panel3.Location = new Point(panel3.Location.X, button3.Location.Y + 36);
            }
            panel2.Visible = !panel2.Visible;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            panel3.Visible = !panel3.Visible;
            panel3.Location = new Point(11, button3.Location.Y + 36);
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

        private void button13_Click(object sender, EventArgs e)
        {
            tabGroup.SelectTab(ChangeInfoFood);
        }

        private void button23_Click(object sender, EventArgs e)
        {
            string name = textBox14.Text;
            string newInfo = textBox13.Text;
            string parameter = "";
            if (radioButton15.Checked)
                parameter = "Name";
            else if (radioButton14.Checked)
                parameter = "Price";
            else if (radioButton15.Checked)
                parameter = "Allergens";
            else if (radioButton14.Checked)
                parameter = "Ingredients";
            else if (radioButton15.Checked)
                parameter = "AddOns";
            foodControl.ChangeInfo(name, newInfo, parameter);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            tabGroup.SelectTab(MainMenu);
            listBox8.Items.Clear();
            RenderMenu();
        }
        private void RenderMenu()
        {
            listBox8.Items.Add("Appetizers:");
            foreach (string item in foodControl.ListAllAppetizers())
            {
                listBox8.Items.Add(item);
            }
            listBox8.Items.Add("Main courses:");
            foreach (string item in foodControl.ListAllMainCourses())
            {
                listBox8.Items.Add(item);
            }
            listBox8.Items.Add("Desserts:");
            foreach (string item in foodControl.ListAllDesserts())
            {
                listBox8.Items.Add(item);
            }
            listBox8.Items.Add("");
            listBox8.Items.Add("Soft drinks:");
            foreach (string item in drinkControl.ReadSoftDrinksList())
            {
                listBox8.Items.Add(item);
            }
            listBox8.Items.Add("Alcoholic drinks:");
            foreach (string item in drinkControl.ReadAlcoholicDrinksList())
            {
                listBox8.Items.Add(item);
            }
        }

        private void label4_Click(object sender, EventArgs e) { }

        private void button5_Click(object sender, EventArgs e)
        {
            tabGroup.SelectTab(DeleteFood);
        }


        private void button25_Click(object sender, EventArgs e)
        {
            listBox10.Items.Clear();
            double min = double.Parse(textBox18.Text);
            double max = double.Parse(textBox17.Text);
            textBox18.Text = "";
            textBox17.Text = "";
            foreach (string item in foodControl.ListBetweenPrices(min, max))
            {
                listBox10.Items.Add(item);
            }
        }

        private void button26_Click(object sender, EventArgs e)
        {
            tabGroup.SelectTab(PriceFoods);
        }

        private void button27_Click(object sender, EventArgs e)
        {
            tabGroup.SelectTab(PriceDrinks);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button24_Click(object sender, EventArgs e)
        {
            listBox9.Items.Clear();
            double min = double.Parse(textBox15.Text);
            double max = double.Parse(textBox16.Text);
            textBox15.Text = "";
            textBox16.Text = "";
            foreach (string item in drinkControl.DrinksBetweenPrice(min, max))
            {
                listBox9.Items.Add(item);
            }
        }
    }
}
