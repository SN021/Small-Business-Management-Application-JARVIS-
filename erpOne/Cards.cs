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
    public partial class Cards : Form
    {
        public Cards()
        {
            InitializeComponent();
        }

        private void button7_Click(object sender, EventArgs e)
        {
           
        }
        //card one open
        private void button7_Click_1(object sender, EventArgs e)
        {
            Cards cards = new Cards();
            cards.Hide();
            Inventory inventory = new Inventory();
            inventory.MdiParent = Dashboad.ActiveForm;
            inventory.Show();
            inventory.BringToFront();

            
            

        }
        //card two open
        private void button1_Click(object sender, EventArgs e)
        {
            Cards cards = new Cards();
            cards.Hide();
            Sales sales = new Sales();
            sales.MdiParent = Dashboad.ActiveForm;
            sales.Show();
            sales.BringToFront();
        }
        //card four open
        private void button3_Click(object sender, EventArgs e)
        {
            Cards cards = new Cards();
            cards.Hide();
            Workers workers = new Workers();
            workers.MdiParent = Dashboad.ActiveForm;
            workers.Show();
            workers.BringToFront();
        }
        //card three open
        private void button2_Click(object sender, EventArgs e)
        {
            Cards cards = new Cards();
            cards.Hide();
            Customer customer = new Customer();
            customer.MdiParent = Dashboad.ActiveForm;
            customer.Show();
            customer.BringToFront();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void Cards_Load(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
