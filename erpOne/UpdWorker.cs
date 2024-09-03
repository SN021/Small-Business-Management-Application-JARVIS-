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
    public partial class UpdWorker : Form
    {
        private string id;

        public UpdWorker(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void UpdWorker_Load(object sender, EventArgs e)
        {
            string sql = "select * from workers where id = '" + id + "'";
            Database database = new Database();
            DataSet ds = database.ReadData(sql, "workersTable");
            textBox1.Text = ds.Tables["workersTable"].Rows[0]["id"].ToString();
            textBox2.Text = ds.Tables["workersTable"].Rows[0]["name"].ToString();
            textBox3.Text = ds.Tables["workersTable"].Rows[0]["phone"].ToString();
            textBox4.Text = ds.Tables["workersTable"].Rows[0]["address"].ToString();
            textBox5.Text = ds.Tables["workersTable"].Rows[0]["salary"].ToString();


            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            try
            {
                string id = textBox1.Text;
                string name = textBox2.Text;
                string phone = textBox3.Text;
                string address = textBox4.Text;
                string salary = textBox5.Text;
                string query = "update workers set name = '" + name + "', phone = '" + phone + "', address = '" + address + "', salary = '" + salary + "' where id = '" + id + "'";
                Database database = new Database();
                if (database.InsertData(query) == true)
                {
                    MessageBox.Show("Data Updated Successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Data Updation Failed", "Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("System Error Occured : " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
