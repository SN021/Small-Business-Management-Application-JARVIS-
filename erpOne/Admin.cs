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
    public partial class Admin : Form
    {
        public Admin()
        {
            InitializeComponent();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Admin_Load(object sender, EventArgs e)
        {
            Database db = new Database();
            DataSet gridOneDs = db.ReadData("SELECT * FROM inventory", "gridOne");
            dataGridView1.DataSource = gridOneDs.Tables["gridOne"];
            DataSet gridTwoDs = db.ReadData("SELECT * FROM sales", "gridTwo");
            dataGridView2.DataSource = gridTwoDs.Tables["gridTwo"];
            DataSet gridThreeDs = db.ReadData("SELECT * FROM workers", "gridThree");
            dataGridView3.DataSource = gridThreeDs.Tables["gridThree"];
            DataSet gridFourDs = db.ReadData("SELECT * FROM customer", "gridFour");
            dataGridView4.DataSource = gridFourDs.Tables["gridFour"];

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
