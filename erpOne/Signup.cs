using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace erpOne
{
    public partial class Signup : Form
    {

        private string ghostText = "Enter Username";
        private string ghostText2 = "Enter Email";
        private string ghostText3 = "Enter Password";
        private string ghostTextcombo = "Select Workplace";


        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);

        public Signup()
        {
            InitializeComponent();

            

            // Set the button1 properties for curved edges
            button1.FlatStyle = FlatStyle.Flat;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = button1.BackColor;
            button1.FlatAppearance.MouseOverBackColor = button1.BackColor;
            button1.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, button1.Width, button1.Height, 10, 10));

            // Set the button2 properties for curved edges
            button2.FlatStyle = FlatStyle.Flat;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = button2.BackColor;
            button2.FlatAppearance.MouseOverBackColor = button2.BackColor;
            button2.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, button2.Width, button2.Height, 10, 10));

            // Set the initial ghost text in the textbox1
            textBox1.Text = ghostText;
            textBox1.ForeColor = SystemColors.GrayText;
            textBox1.TextAlign = HorizontalAlignment.Center;

            // Wire up the Enter and Leave events in textbox1
            textBox1.Enter += TextBox1_Enter;
            textBox1.Leave += TextBox1_Leave;

            // Set the initial ghost text in the textbox2
            textBox2.Text = ghostText2;
            textBox2.ForeColor = SystemColors.GrayText;
            textBox2.TextAlign = HorizontalAlignment.Center;

            // Wire up the Enter and Leave events in textbox2
            textBox2.Enter += TextBox2_Enter;
            textBox2.Leave += TextBox2_Leave;

            // Set the initial ghost text in the textbox3
            textBox3.Text = ghostText3;
            textBox3.ForeColor = SystemColors.GrayText;
            textBox3.TextAlign = HorizontalAlignment.Center;

            // Wire up the Enter and Leave events in textbox3
            textBox3.Enter += TextBox3_Enter;
            textBox3.Leave += TextBox3_Leave;

            // Set the initial ghost text in the ComboBox
            comboBox1.Text = ghostTextcombo;
            comboBox1.ForeColor = SystemColors.GrayText;


            // Add items to the ComboBox
            comboBox1.Items.Add("Default");
            comboBox1.Items.Add("Institutions");
            comboBox1.Items.Add("Clinics");
            comboBox1.Items.Add("Social Services");

            // Wire up the Enter and Leave events
            comboBox1.Enter += ComboBox1_Enter;
            comboBox1.Leave += ComboBox1_Leave;

            // Set DrawMode to OwnerDrawFixed and handle DrawItem event

            comboBox1.DrawMode = DrawMode.OwnerDrawFixed;
            comboBox1.DrawItem += ComboBox1_DrawItem;

            // Set panel1 color
            panel1.BackColor = Color.White;

            /* Set panel2 transparent
            panel2.BackColor = Color.Transparent;
            panel2.Parent = panel1;
            panel2.Location = new Point(-2, 0);
            panel2.Size = new Size(757, 47);*/
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //button click to login page
            Login login1 = new Login();
            login1.Show();

            // Hide the current form
            //this.Hide();
        }

        private void TextBox1_Enter(object sender, EventArgs e)
        {
            // Clear the text box and change the text color
            if (textBox1.Text == ghostText)
            {
                textBox1.Text = "";
                textBox1.ForeColor = SystemColors.ControlText;
            }
        }

        private void TextBox1_Leave(object sender, EventArgs e)
        {
            // Restore the ghost text if the text box is empty
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                textBox1.Text = ghostText;
                textBox1.ForeColor = SystemColors.GrayText;
            }
        }

        private void TextBox2_Enter(object sender, EventArgs e)
        {
            // Clear the text box and change the text color
            if (textBox2.Text == ghostText2)
            {
                textBox2.Text = "";
                textBox2.ForeColor = SystemColors.ControlText;
            }
        }

        private void TextBox2_Leave(object sender, EventArgs e)
        {
            // Restore the ghost text if the text box is empty
            if (string.IsNullOrWhiteSpace(textBox2.Text))
            {
                textBox2.Text = ghostText2;
                textBox2.ForeColor = SystemColors.GrayText;
            }
        }

        private void TextBox3_Enter(object sender, EventArgs e)
        {
            // Clear the text box and change the text color
            if (textBox3.Text == ghostText3)
            {
                textBox3.Text = "";
                textBox3.ForeColor = SystemColors.ControlText;
            }
        }

        private void TextBox3_Leave(object sender, EventArgs e)
        {
            // Restore the ghost text if the text box is empty
            if (string.IsNullOrWhiteSpace(textBox3.Text))
            {
                textBox3.Text = ghostText3;
                textBox3.ForeColor = SystemColors.GrayText;
            }
        }

        private void ComboBox1_Enter(object sender, EventArgs e)
        {
            // Clear the ComboBox and change the text color
            if (comboBox1.Text == ghostTextcombo)
            {
                comboBox1.Text = "";
                comboBox1.ForeColor = SystemColors.ControlText;
            }
        }

        private void ComboBox1_Leave(object sender, EventArgs e)
        {
            // Restore the ghost text if no item is selected
            if (comboBox1.SelectedIndex == -1)
            {
                comboBox1.Text = ghostTextcombo;
                comboBox1.ForeColor = SystemColors.GrayText;
            }
        }

        private void ComboBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Center align the text in the ComboBox
            e.DrawBackground();
            if (e.Index >= 0)
            {
                string text = comboBox1.GetItemText(comboBox1.Items[e.Index]);
                e.Graphics.DrawString(text, e.Font, new SolidBrush(e.ForeColor), e.Bounds.Left + (e.Bounds.Width - e.Graphics.MeasureString(text, e.Font).Width) / 2, e.Bounds.Top + (e.Bounds.Height - e.Graphics.MeasureString(text, e.Font).Height) / 2);
            }
            e.DrawFocusRectangle();
        }







        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            try
            {
                // button click to login page
                Login login1 = new Login();
                login1.Show();
                // hide this form
                this.Hide();

            }
            catch(Exception ex)
            {
                MessageBox.Show("System Error Occured : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
           


        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // create database object
                Database db = new Database();
                // create variables to store the values from the textboxes
                //change the address variable to a password variable
                string name = textBox1.Text;
                string password = textBox2.Text;
                string email = textBox3.Text;
                string type = comboBox1.Text;

                //create a method to check if the textboxes are empty and password is not empty and phone is a phone number and type is not empty
                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(type))
                {
                    MessageBox.Show("Please fill all the fields");
                    return;
                }





                // create a method to generate random ids for users with with USR strings at the begining
                Random rnd = new Random();
                int id = rnd.Next(100000, 999999);
                string userID = "USR" + id.ToString();



                // make a string variable to store sql queary to insert data to userData table take values from the variables
                string sql = "INSERT INTO userData (Id,Name,Email,Password,type) VALUES ('" + userID + "' ,'" + name + "','" + password + "','" + email + "','" + type + "')";

                // call the InsertData method from the database class and pass the sql variable as a parameter and use a if else to show a messagebox
                if (db.InsertData(sql))
                {
                    MessageBox.Show("Successfuly registered!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Error in registration ", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            

            }
            catch (Exception ex)
            {
                MessageBox.Show("System Error Occured : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void Signup_Load(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
