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
    public partial class Workers : Form
    {
        public Workers()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Enter ID")
            {
                textBox1.Text = "";

                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                textBox1.Text = "Enter ID";

                textBox1.ForeColor = Color.Silver;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Name")
            {
                textBox2.Text = "";

                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Name";

                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Enter Address")
            {
                textBox3.Text = "";

                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Enter Address";

                textBox3.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Enter Phone Number")
            {
                textBox4.Text = "";

                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Enter Phone Number";

                textBox4.ForeColor = Color.Silver;
            }
        }

        private void textBox5_Leave(object sender, EventArgs e)
        {

            if (textBox5.Text == "")
            {
                textBox5.Text = "Enter Salary";

                textBox5.ForeColor = Color.Silver;
            }

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_Enter(object sender, EventArgs e)
        {
            if (textBox5.Text == "Enter Salary")
            {
                textBox5.Text = "";

                textBox5.ForeColor = Color.Black;
            }

        }

        private void Workers_Load(object sender, EventArgs e)
        {
            loadgridView();
        }

        private void loadgridView()
        {
            Database database = new Database();
            DataSet ds = database.ReadData("select * from workers", "workerDataset");
            dataGridView1.DataSource = ds.Tables["workerDataset"];

            DataGridViewButtonColumn UpdateBtn = new DataGridViewButtonColumn();
            UpdateBtn.Name = "Update";
            UpdateBtn.Text = "Update";
            UpdateBtn.UseColumnTextForButtonValue = true;


            if (dataGridView1.Columns["Update"] == null)
            {
                dataGridView1.Columns.Insert(dataGridView1.Columns.Count, UpdateBtn);
            }


            DataGridViewButtonColumn DeleteBtn = new DataGridViewButtonColumn();
            DeleteBtn.Name = "Delete";
            DeleteBtn.Text = "Delete";
            DeleteBtn.UseColumnTextForButtonValue = true;


            if (dataGridView1.Columns["Delete"] == null)
            {
                dataGridView1.Columns.Insert(dataGridView1.Columns.Count, DeleteBtn);
            }
        }

        private void button7_Click(object sender, EventArgs e)
        {

            try
            {
                // insert data 
                Database database = new Database();
                string query = "insert into workers values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "','" + textBox5.Text + "')";

                if (database.InsertData(query))
                {
                    MessageBox.Show("Successfuly registered!", "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    loadgridView();
                }
                else
                {
                    MessageBox.Show("Error in registration ", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }


            }
            catch(Exception ex)
            {
                MessageBox.Show("System Error Occured : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


            

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                var senderGrid = (DataGridView)sender;

                if (e.ColumnIndex == senderGrid.Columns["Update"].Index && e.RowIndex >= 0)
                {
                    //TODO - Button Clicked - Execute Code Here
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    //Do something with your button.



                    UpdWorker UpdWorker = new UpdWorker(row.Cells[2].Value.ToString());
                    UpdWorker.Show();


                }

                if (e.ColumnIndex == senderGrid.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    string id = row.Cells[2].Value.ToString();
                    Database database = new Database();

                    string query = "DELETE FROM workers WHERE id = '" + id + "'";
                    if (database.DeleteData(query))
                    {
                        MessageBox.Show("Item deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadgridView();
                    }
                    else
                    {
                        MessageBox.Show("Item not deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Error Occured : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadgridView();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
