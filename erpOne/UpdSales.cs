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
    public partial class UpdSales : Form
    {
        private string SalesUpdateId;
        public UpdSales(string salesUpdateId)
        {
            InitializeComponent();
            SalesUpdateId = salesUpdateId;
        }

        private void UpdSales_Load(object sender, EventArgs e)
        {
            //get data from database
            string sql = "select * from sales where id = '" + SalesUpdateId + "'";
            Database database = new Database();
            DataSet ds = database.ReadData(sql, "salesTable");
            textBox1.Text = ds.Tables["salesTable"].Rows[0]["id"].ToString();
            textBox2.Text = ds.Tables["salesTable"].Rows[0]["name"].ToString();
            textBox3.Text = ds.Tables["salesTable"].Rows[0]["amount"].ToString();
            dateTimePicker1.Value = Convert.ToDateTime(ds.Tables["salesTable"].Rows[0]["date"].ToString());

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //update data
            try
            {
                string id = textBox1.Text;
                string name = textBox2.Text;
                string amount = textBox3.Text;
                string date = dateTimePicker1.Value.ToShortDateString();
                string query = "update sales set name = '" + name + "', amount = '" + amount + "', date = '" + date + "' where id = '" + id + "'";
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
