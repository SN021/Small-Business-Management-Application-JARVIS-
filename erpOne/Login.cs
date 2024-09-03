using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erpOne
{
    public partial class Login : Form
    {


        private string ghostText = "Enter Username";
        private string ghostText2 = "Enter Password";

        [System.Runtime.InteropServices.DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int width, int height);
        public Login()
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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Close Login and show Signup again
            this.Close();

            // Alternatively, you can create a new instance of Form1 and show it
            Signup sign = new Signup();
            sign.Show();
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

        private void Login_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            // Close Login and show Signup again
            Signup sign = new Signup();
            sign.Show();
           this.Hide();
               
        }

       

        

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                // get data from textboxes to variables
                string username = textBox1.Text;
                string password = textBox2.Text;

                //create an object to CheckUser class
                CheckUser checkUser = new CheckUser();

                if (checkUser.ChecktheUser(username, password))
                {
                    //message box saying user exist add an icon too
                    MessageBox.Show("Login Success ", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information); ;

                    // naviage to the dashboard
                    Dashboad dash = new Dashboad(checkUser.getCurrentUser());
                    dash.Show();
                    this.Hide();


                }
                else
                {
                    //messagebox saying user does not exist
                    MessageBox.Show("Invalid username or password", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("System Error Occured : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           
            
        }
    }
}
