using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace _4915M_project
{
    public partial class AirwayBill1 : Form
    {
        String[] goodsArray = new string[10];
        LinkedList<Array> goodsList = new LinkedList<Array>(); 
        String sCountry, sName, sAddress, sCompany, 
            rCountry, areaCode, rAddress, rName, rCompany,
            length, width, height, weight, description;

        public AirwayBill1()
        {
            InitializeComponent();
            
        }

        //private Form from = new CustomerLobby();
        private void createbtn_Click(object sender, EventArgs e)
        {
            //old useless code
        }



        private void btnGoNext_Click(object sender, EventArgs e)
        {
            Console.WriteLine("in air" + CustomerLogin.currentCustomerID);
            AirwayBillPanelGood.Visible = true;
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AirwayBillPanelGood.Visible = false;
        }

        private void btnGoAirwayBIll3_Click(object sender, EventArgs e)
        {
            
            
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

        private void btnMoreGood_Click(object sender, EventArgs e)
        {
            
        }

        private void AirwayBillPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
