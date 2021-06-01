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
            AirwayBillPanel2.Visible = false;
            AirwayBillPanel3.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //old useless code (but do not delete !)
        }

        private Form from = new CustomerLobby();
        private void createbtn_Click(object sender, EventArgs e)
        {
            //old useless code (but do not delete !)
        }



        private void btnGoNext_Click(object sender, EventArgs e)
        {
            AirwayBillPanel1.Visible = false;
            AirwayBillPanel2.Visible = true;
            AirwayBillPanel3.Visible = false;
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AirwayBillPanel1.Visible = true;
            AirwayBillPanel2.Visible = false;
            AirwayBillPanel3.Visible = false;
        }

        private void btnGoAirwayBIll3_Click(object sender, EventArgs e)
        {
            AirwayBillPanel1.Visible = false;
            AirwayBillPanel2.Visible = false;
            AirwayBillPanel3.Visible = true;
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

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void AirwayBillPanel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AirwayBill1_Load(object sender, EventArgs e)
        {

        }
    }
}
