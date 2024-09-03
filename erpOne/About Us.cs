using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erpOne
{
    public partial class About_Us : Form
    {

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int nLeftRect, int nTopRect, int nRightRect, int nBottomRect, int nWidthEllipse, int nHeightEllipse);
        public About_Us()
        {
            InitializeComponent();

            // Make the panel have curved edges
            panel3.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 10, 10));
            panel4.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 10, 10));
            panel5.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 10, 10));
            panel6.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 10, 10));
            panel7.Region = System.Drawing.Region.FromHrgn(CreateRoundRectRgn(0, 0, panel3.Width, panel3.Height, 10, 10));

            // Apply a shadow effect to panel3
            panel3.Padding = new Padding(20);
            panel3.BackColor = Color.White;
            panel3.ForeColor = Color.FromArgb(64, 64, 64);
           

            // Make the pictureBox2 circular
            pictureBox2.Paint += (sender, e) =>
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddEllipse(0, 0, pictureBox2.Width - 1, pictureBox2.Height - 1);
                    pictureBox2.Region = new Region(path);
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawEllipse(Pens.White, 0, 0, pictureBox2.Width - 1, pictureBox2.Height - 1);
                }
            };

            // Update label3 properties
            label3.Text = "Akash Niyas";
            label3.Font = new Font("Arial", 16, FontStyle.Bold);
            label3.ForeColor = Color.FromArgb(51, 51, 51);
            label3.AutoSize = true;
            label3.Location = new Point(panel3.Width / 2 - label3.Width / 2, pictureBox2.Bottom + 20);


            // Update label5 properties
            label5.Text = "Product Manager";
            label5.Font = new Font("Arial", 13, FontStyle.Bold);
            label5.ForeColor = Color.FromArgb(102, 102, 102);
            label5.AutoSize = true;
            label5.Location = new Point(panel3.Width / 2 - label5.Width / 2, label5.Bottom + 5);


            // Apply a shadow effect to panel4
            panel4.Padding = new Padding(20);
            panel4.BackColor = Color.White;
            panel4.ForeColor = Color.FromArgb(64, 64, 64);
           

            // Make the pictureBox3 circular
            pictureBox3.Paint += (sender, e) =>
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddEllipse(0, 0, pictureBox3.Width - 1, pictureBox3.Height - 1);
                    pictureBox3.Region = new Region(path);
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawEllipse(Pens.White, 0, 0, pictureBox3.Width - 1, pictureBox3.Height - 1);
                }
            };

            // Update label8 properties
            label8.Text = "Sachin Fernando"; 
            label8.Font = new Font("Arial", 16, FontStyle.Bold);
            label8.ForeColor = Color.FromArgb(51, 51, 51);
            label8.AutoSize = true;
            label8.Location = new Point(panel4.Width / 2 - label8.Width / 2, pictureBox3.Bottom + 20);

            

            // Update label6 properties
            label7.Text = "Team Leader"; 
            label7.Font = new Font("Arial", 13, FontStyle.Bold);
            label7.ForeColor = Color.FromArgb(102, 102, 102);
            label7.AutoSize = true;
            label7.Location = new Point(panel4.Width / 2 - label7.Width / 2, label7.Bottom + 5);


            // Apply a shadow effect to panel5
            panel5.Padding = new Padding(20);
            panel5.BackColor = Color.White;
            panel5.ForeColor = Color.FromArgb(64, 64, 64);
            

            // Make the pictureBox4 circular
            pictureBox4.Paint += (sender, e) =>
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddEllipse(0, 0, pictureBox4.Width - 1, pictureBox4.Height - 1);
                    pictureBox4.Region = new Region(path);
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawEllipse(Pens.White, 0, 0, pictureBox4.Width - 1, pictureBox4.Height - 1);
                }
            };

            // Update label11 properties
            label11.Text = "Sanduni Navodya";
            label11.Font = new Font("Arial", 16, FontStyle.Bold);
            label11.ForeColor = Color.FromArgb(51, 51, 51);
            label11.AutoSize = true;
            label11.Location = new Point(panel5.Width / 2 - label11.Width / 2, pictureBox4.Bottom + 20);


            // Update label10 properties
            label10.Text = "Developer"; 
            label10.Font = new Font("Arial", 13, FontStyle.Bold);
            label10.ForeColor = Color.FromArgb(102, 102, 102);
            label10.AutoSize = true;
            label10.Location = new Point(panel5.Width / 2 - label10.Width / 2, label10.Bottom + 5);


            // Apply a shadow effect to panel6
            panel6.Padding = new Padding(20);
            panel6.BackColor = Color.White;
            panel6.ForeColor = Color.FromArgb(64, 64, 64);
            

            // Make the pictureBox5 circular
            pictureBox5.Paint += (sender, e) =>
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddEllipse(0, 0, pictureBox5.Width - 1, pictureBox5.Height - 1);
                    pictureBox5.Region = new Region(path);
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawEllipse(Pens.White, 0, 0, pictureBox5.Width - 1, pictureBox5.Height - 1);
                }
            };

            // Update label14 properties
            label14.Text = "Vinuka Ampavila";
            label14.Font = new Font("Arial", 16, FontStyle.Bold);
            label14.ForeColor = Color.FromArgb(51, 51, 51);
            label14.AutoSize = true;
            label14.Location = new Point(panel6.Width / 2 - label14.Width / 2, pictureBox5.Bottom + 20);


            // Update label12 properties
            label13.Text = "Developer";
            label13.Font = new Font("Arial", 13, FontStyle.Bold);
            label13.ForeColor = Color.FromArgb(102, 102, 102);
            label13.AutoSize = true;
            label13.Location = new Point(panel6.Width / 2 - label13.Width / 2, label13.Bottom + 5);

            // Apply a shadow effect to panel7
            panel7.Padding = new Padding(20);
            panel7.BackColor = Color.White;
            panel7.ForeColor = Color.FromArgb(64, 64, 64);
            

            // Make the pictureBox6 circular
            pictureBox6.Paint += (sender, e) =>
            {
                using (var path = new System.Drawing.Drawing2D.GraphicsPath())
                {
                    path.AddEllipse(0, 0, pictureBox6.Width - 1, pictureBox6.Height - 1);
                    pictureBox6.Region = new Region(path);
                    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    e.Graphics.DrawEllipse(Pens.White, 0, 0, pictureBox6.Width - 1, pictureBox6.Height - 1);
                }
            };

            // Update label17 properties
            label17.Text = "Lakshan Sithara"; // Replace with the actual name
            label17.Font = new Font("Arial", 16, FontStyle.Bold);
            label17.ForeColor = Color.FromArgb(51, 51, 51);
            label17.AutoSize = true;
            label17.Location = new Point(panel7.Width / 2 - label17.Width / 2, pictureBox6.Bottom + 20);


            // Update label15 properties
            label16.Text = "Database Designer"; // Replace with the actual title
            label16.Font = new Font("Arial", 13, FontStyle.Bold);
            label16.ForeColor = Color.FromArgb(102, 102, 102);
            label16.AutoSize = true;
            label16.Location = new Point(panel7.Width / 2 - label16.Width / 2, label16.Bottom + 5);
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
