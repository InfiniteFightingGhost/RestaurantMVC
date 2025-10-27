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
            if(!panel2.Visible)
            {
                panel2.Visible = false;
                button3.Location = new Point(21, 312);
                panel2.Location = new Point(10, 145);
                panel2.Visible = true;
            }
        }
    }
}
