using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace erpOne
{
    public partial class Sales : Form
    {
        public Sales()
        {
            InitializeComponent();
        }

        private void Sales_Load(object sender, EventArgs e)
        {
            loadDataGrid();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string id = textBox1.Text;
                string name = textBox2.Text;
                string amount = textBox3.Text;
                string date = dateTimePicker1.Value.ToShortDateString();
                string query = "insert into sales values('" + id + "','" + name + "','" + amount + "','" + date + "')";
                Database database = new Database();
                if(database.InsertData(query) == true)
                {
                    MessageBox.Show("Data Inserted Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    loadDataGrid();
                }
                else
                {
                    MessageBox.Show("Data Insertion Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch(Exception ex) {

                MessageBox.Show("System Error Occured : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadDataGrid()
        {
            string sql = "select * from sales";
            Database database = new Database();
            DataSet ds = database.ReadData(sql, "salesTable");
            dataGridView1.DataSource = ds.Tables["salesTable"];

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

                    

                    UpdSales updSales = new UpdSales(row.Cells[2].Value.ToString());
                    updSales.Show();


                }

                if (e.ColumnIndex == senderGrid.Columns["Delete"].Index && e.RowIndex >= 0)
                {
                    DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                    string id = row.Cells[2].Value.ToString();
                    Database database = new Database();

                    string query = "DELETE FROM sales WHERE id = '" + id + "'";
                    if (database.DeleteData(query))
                    {
                        MessageBox.Show("Item deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        loadDataGrid();
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
            loadDataGrid();
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
            if (textBox3.Text == "Enter Amount")
            {
                textBox3.Text = "";

                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {
                textBox3.Text = "Enter Amount";

                textBox3.ForeColor = Color.Silver;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
