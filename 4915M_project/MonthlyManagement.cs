using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace _4915M_project
{
    public partial class MonthlyManagement : Form
    {
        public MonthlyManagement()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            CustomerLobby cuslobby = new CustomerLobby();
            cuslobby.Show();
            this.Close();
        }

        private void MonthlyManagement_Load(object sender, EventArgs e)
        {
            DataTable dtmonth = new DataTable();
            dtmonth.Clear();

            string sqlStr = "Select orderID,price,dateOfPickUp from ShipmentOrder,Payment where ShipmentORder.orderID = Payment.paymentID AND paymentStatus = 'monthly' AND cusID = " + CustomerLogin.currentCustomerID + ";";

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, Program.connStr);
            dataAdapter.Fill(dtmonth);
            view.DataSource = dtmonth;
            int loop = 0, price = 0;
            while (loop < dtmonth.Rows.Count) {
                price += Convert.ToInt32(dtmonth.Rows[loop]["price"]);
                loop++;
            }
            txtCount.Text = dtmonth.Rows.Count.ToString();
            txtMoney.Text = price.ToString();

        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            DataTable dtChange = Program.DataTableVar;

            dtChange.Clear();
            string sqlStr2 = "Update Payment,ShipmentOrder set paymentStatus='paid' where ShipmentOrder.orderID = Payment.paymentID AND paymentStatus = 'monthly' AND cusID = " + CustomerLogin.currentCustomerID + " ;";
            OleDbDataAdapter dataAdapterMon = new OleDbDataAdapter(sqlStr2, Program.connStr);
            dataAdapterMon.Fill(dtChange);

            MessageBox.Show("Payment Successful (Hypothesis)", "Payment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MonthlyManagement_Load(sender, e);

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
