using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915M_project
{
    public partial class AirwayBill1 : Form
    {
        public AirwayBill1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerLobby custLobby = new CustomerLobby();
            custLobby.Show();
            this.Hide();
        }
        
        private Form from = new CustomerLobby();
        private void createbtn_Click(object sender, EventArgs e)
        {
            //AirwayBill2 airwayBill2 = new AirwayBill2();
            //airwayBill2.Show();
            //this.Hide();
           
        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void btnGoNext_Click(object sender, EventArgs e)
        {
            AirwayBillPanel1.Visible = false;
            AirwayBillPanel2.Visible = true;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AirwayBillPanel1.Visible = true;
            AirwayBillPanel2.Visible = false;
        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }
    }
}
