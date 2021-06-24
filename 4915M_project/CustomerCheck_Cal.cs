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
    public partial class CustomerCheck_Cal : Form
    {
        public CustomerCheck_Cal()
        {
            InitializeComponent();
        }


        private void btnBack_Click_1(object sender, EventArgs e)
        {
            CustomerLobby custLobby = new CustomerLobby();
            custLobby.Show();
            this.Close();
        }
        private void btnPayment_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Show();
            this.Close();
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (cboOrderID.Text == "")
            {
                MessageBox.Show("You need to select a shipment order", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            }
            else {
                int orderID = Convert.ToInt32(cboOrderID.SelectedItem);

                DataTable dt = Program.DataTableVar;
                String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";

                string sqlStr = "Select orderStatus , rejectReason from ShipmentOrder where orderID = " + orderID + ";";
                    //" AND (cusID = " + CustomerLogin.currentCustomerID + " OR receiverEmail = '" + CustomerLogin.customerEmail + "') ;";   /* Price 未攞*/

                dt.Clear();

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
                dataAdapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {

                    String status = dt.Rows[0]["orderStatus"].ToString();
                    String rejectReason = dt.Rows[0]["rejectReason"].ToString();

                    if (status == "Waiting Payment" || status == "Waiting Booking" || status == "Processing" || status == "Waiting Pickup")
                    {

                        txtStatus.Text = status;

                        dt.Clear();
                        string strSqlStr = "Select price from Payment where paymentID =" + orderID + ";";
                        OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, connStr);
                        dataAdapter2.Fill(dt);
                        if (dt.Rows.Count > 0) { }
                        /* get     price*/
                        txtFare.Text = "$HKD " + dt.Rows[0]["price"].ToString();
                        dt.Clear();
                        dataAdapter2.Dispose();
                        dataAdapter.Dispose();

                    }
                    else if (status == "Rejected")
                    {
                        label9.Visible = true;
                        txtReason.Visible = true;
                        txtReason.Text = rejectReason;
                        txtStatus.Text = status;
                        txtFare.Text = "Null";
                    }
                    else if (status == "Completed") {

                        MessageBox.Show("Order is comepleted , Please check your invoice", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    } else if (status == "Unverify") {

                        txtStatus.Text = status;

                        dt.Clear();
                        string strSqlStr = "Select price from Payment where paymentID =" + orderID + ";";
                        OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, connStr);
                        dataAdapter2.Fill(dt);
                        if (dt.Rows.Count > 0) { }
                        /* get     price*/
                        txtFare.Text = "$HKD "+ dt.Rows[0]["price"].ToString();
                        dt.Clear();
                        dataAdapter2.Dispose();
                        dataAdapter.Dispose();

                    }
                }

                else {
                    MessageBox.Show("No this order", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void CustomerCheck_Cal_Load(object sender, EventArgs e)
        {
            cboOrderID.Items.Clear();
            DataTable dt = Program.DataTableVar;
            string connStr = Program.connStr;
            string sqlStr = "SELECT orderID FROM ShipmentOrder WHERE cusID=" + CustomerLogin.currentCustomerID + ";";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);

            foreach(DataRow dr in dt.Rows)
            {
                cboOrderID.Items.Clear();
                cboOrderID.Items.Add(dr["orderID"].ToString());
            }

            dataAdapter.Dispose();
            
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            CustomerLobby cuts = new CustomerLobby();
            cuts.Show();
            this.Close();
        }
    }
}
