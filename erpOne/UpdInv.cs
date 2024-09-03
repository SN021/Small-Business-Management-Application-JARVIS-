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
    public partial class UpdInv : Form
    {
        private string id;
        public UpdInv(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void UpdInv_Load(object sender, EventArgs e)
        {
            label1.Text = id;


            //get data from database 
            string sql = "select * from inventory where id = '" + id + "'";
     
            Database database = new Database();
            DataSet ds = database.ReadData(sql, "invTable");
            textBox1.Text = ds.Tables["invTable"].Rows[0]["id"].ToString();
            textBox2.Text = ds.Tables["invTable"].Rows[0]["name"].ToString();
            textBox3.Text = ds.Tables["invTable"].Rows[0]["quentity"].ToString();
            textBox4.Text = ds.Tables["invTable"].Rows[0]["price"].ToString();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //update database 
            try
            {
                string id = textBox1.Text;
                string name = textBox2.Text;
                string quentity = textBox3.Text;
                string price = textBox4.Text;
                string query = "update inventory set name = '" + name + "', quentity = '" + quentity + "', price = '" + price + "' where id = '" + id + "'";
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
    }
}
