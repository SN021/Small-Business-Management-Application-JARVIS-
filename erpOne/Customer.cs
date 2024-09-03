using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace erpOne
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
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
            if (textBox3.Text == "Enter Phone Number")
            {
                textBox3.Text = "";

                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Enter Phone Number";

                textBox3.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Enter Address")
            {
                textBox4.Text = "";

                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Enter Address";

                textBox4.ForeColor = Color.Silver;
            }
        }


        private void textBox4_TextChanged(object sender, EventArgs e)
        {
      }

        private void Customer_Load(object sender, EventArgs e)
        {
            dataGrid();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                //taking data from the textboxes
                string id = textBox1.Text;
                string name = textBox2.Text;
                string phone = textBox3.Text;
                string address = textBox4.Text;

                //inserting data into the database
                Database database = new Database();
                string sql = "INSERT INTO customer VALUES('" + id + "','" + name + "','" + phone + "','" + address + "')";
                bool check = database.InsertData(sql);
                if (check == true)
                {
                    MessageBox.Show("Data Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    dataGrid();
                    Customer_Load(this, null);
                }
                else
                {
                    MessageBox.Show("Data Insertion Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }catch(Exception ex)
            {
                MessageBox.Show("System Error Occured : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void dataGrid()
        {


            try
            {
                // take data from datagridview and put it in textboxes
                Database database = new Database();
                string sql = "SELECT * FROM customer";
                DataSet ds = database.ReadData(sql, "customerTable");
                dataGridView1.DataSource = ds.Tables["customerTable"];


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
            catch(Exception ex)
            {
                MessageBox.Show("System Error Occured : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


           
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            try
            {
                // take data from datagridview and put it in textboxes
                if (e.ColumnIndex == dataGridView1.Columns["Update"].Index)
                {
                    string id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    UpdCustomer updCustomer = new UpdCustomer(id);
                    updCustomer.Show();

                }
                else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
                {
                    string id = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                    Database database = new Database();
                    string sql = "DELETE FROM customer WHERE id='" + id + "'";
                    bool check = database.DeleteData(sql);
                    if (check == true)
                    {
                        MessageBox.Show("Data Deleted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataGrid();
                        Customer_Load(this, null);
                    }
                    else
                    {
                        MessageBox.Show("Data Deletion Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("System Error Occured : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGrid();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
