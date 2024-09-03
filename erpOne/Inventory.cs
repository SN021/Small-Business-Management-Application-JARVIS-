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
    public partial class Inventory : Form
    {
        private string id;
        private string name;
        private string quentity;
        private string price;

        public Inventory()
        {
            InitializeComponent();
        }

        private void Inventory_Load(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int ids = rnd.Next(100000, 999999);
            id = "INV" + ids.ToString();
            textBox1.Text = id;

            loadGrid();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                name = textBox2.Text;
                quentity = textBox3.Text;
                price = textBox4.Text;
                Database database = new Database();
                string query = "INSERT INTO inventory (id, name, quentity, price) " +
                    "VALUES ('" + id + "','" + name + "','" + quentity + "','" + price + "')";
                if (database.InsertData(query))
                {
                    MessageBox.Show("Item added successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadGrid();
                }
                else
                {
                    MessageBox.Show("Item not added", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("System Error :" +ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void loadGrid()
        {
            try
            {
                Database database = new Database();
                string query = "SELECT * FROM inventory";
                DataSet dataSet = database.ReadData(query, "inventory");
                dataGridView1.DataSource = dataSet.Tables["inventory"];


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
                MessageBox.Show("System Error :" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

           

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            /*if (e.ColumnIndex == dataGridView1.Columns["Update"].Index)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                //Do something with your button.
                MessageBox.Show("I was clicked " + row.Cells[1].Value.ToString());

            }

           else if (e.ColumnIndex == dataGridView1.Columns["Delete"].Index)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                //Do something with your button.
                MessageBox.Show("I was clicked Delete");

            }*/

            var senderGrid = (DataGridView)sender;

            if (e.ColumnIndex == senderGrid.Columns["Update"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                //Do something with your button.
                string id =  row.Cells[2].Value.ToString();

                UpdInv updInv = new UpdInv(id);
                updInv.Show();


            }

            if (e.ColumnIndex == senderGrid.Columns["Delete"].Index && e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                //Do something with your button.
                string id = row.Cells[2].Value.ToString();

                //delete data 
                Database database = new Database();
                string query = "DELETE FROM inventory WHERE id = '" + id + "'";
                if (database.DeleteData(query))
                {
                    MessageBox.Show("Item deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadGrid();
                }
                else
                {
                    MessageBox.Show("Item not deleted", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
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

        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Enter Product Name")
            {
                textBox2.Text = "";

                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                textBox2.Text = "Enter Product Name";

                textBox2.ForeColor = Color.Silver;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Enter Quantity")
            {
                textBox3.Text = "";

                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Enter Quantity";

                textBox3.ForeColor = Color.Silver;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Per Item")
            {
                textBox4.Text = "";

                textBox4.ForeColor = Color.Black;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {
                textBox4.Text = "Per Item";

                textBox4.ForeColor = Color.Black;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            loadGrid();
        }
    }
}
