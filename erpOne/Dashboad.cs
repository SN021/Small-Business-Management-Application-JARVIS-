using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace erpOne
{
    public partial class Dashboad : Form
    {
        private string currentUser;

        public void setLabel(string labelText)
        {
            this.label1.Text = labelText;
        }



        public Dashboad(String currentUser)
        {
            InitializeComponent();
            this.currentUser = currentUser;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text = "Home";
            Cards cards = new Cards();
            cards.MdiParent = Dashboad.ActiveForm;
            cards.Show();

            label2.Text = "Hello, " + currentUser;

        }

        private void panel6_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel14_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }


        private void button7_Click(object sender, EventArgs e)
        {
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            label1.Text = "Home";
            Admin admin = new Admin();
            admin.Hide();
            Info info = new Info();
            info.Hide();
            Cards cards = new Cards();
            cards.MdiParent = Dashboad.ActiveForm;
            cards.Show();
            cards.BringToFront();

        }

        private void button7_Click_1(object sender, EventArgs e)
        {

        }
        private void button6_Click(object sender, EventArgs e)
        {
            //get the loginform 
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label1.Text = "Calender";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            label1.Text = "Admin";
            Cards cards = new Cards();
            cards.Hide();
            Admin admin = new Admin();
            admin.MdiParent = Dashboad.ActiveForm;
            admin.Show();
            admin.BringToFront();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            label1.Text = "Info";
            Cards cards = new Cards();
            cards.Hide();
            Info info = new Info();
            info.MdiParent = Dashboad.ActiveForm;
            info.Show();
            info.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            label1.Text = "About";
            Cards cards = new Cards();
            cards.Hide();
            About_Us aboutus = new About_Us();
            aboutus.MdiParent = Dashboad.ActiveForm;
            aboutus.Show();
            aboutus.BringToFront();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
