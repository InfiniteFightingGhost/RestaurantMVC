namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            panel2.Visible = false;
            panel3.Visible = false;
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
            Close();
        }
    }
}
