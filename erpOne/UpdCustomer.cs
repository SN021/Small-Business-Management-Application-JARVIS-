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
    public partial class UpdCustomer : Form
    {
        private string id;
        public UpdCustomer(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void UpdCustomer_Load(object sender, EventArgs e)
        {
            string query = "select * from customer where id = '" + id + "'";
            Database db = new Database();
            DataSet dataSet = db.ReadData(query, "customer");
            textBox1.Text = dataSet.Tables["customer"].Rows[0]["id"].ToString();
            textBox2.Text = dataSet.Tables["customer"].Rows[0]["name"].ToString();
            textBox3.Text = dataSet.Tables["customer"].Rows[0]["phone"].ToString();
            textBox4.Text = dataSet.Tables["customer"].Rows[0]["address"].ToString();
            

        }

        private void button1_Click(object sender, EventArgs e)
        {


            try
            {
                //update query
                string query = "update customer set name = '" + textBox2.Text + "', phone = '" + textBox3.Text + "', address = '" + textBox4.Text + "' where id = '" + id + "'";
                Database db = new Database();
                if (db.UpdateData(query))
                {
                    MessageBox.Show("Successfuly Updated!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
    }
}
