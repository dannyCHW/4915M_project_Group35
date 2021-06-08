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
    public partial class MonthlyPay : Form
    {
        public MonthlyPay()
        {
            InitializeComponent();
        }

        private void MonthlyPay_Load(object sender, EventArgs e)
        {

        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtOrder.Text == "")
            {
                MessageBox.Show("Please input oreder number", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!checkBox.Checked)
            {
                MessageBox.Show("Please confirm", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int orderID = Convert.ToInt32(txtOrder.Text);
                DataTable dt = Program.DataTableVar;
                dt.Clear();
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";

                string sqlStr = "Select orderStatus from ShipmentOrder where orderID = " + orderID;

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
                dataAdapter.Fill(dt);


                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        String status = dt.Rows[0]["orderStatus"].ToString();
                        if (status == "waitingPayment")
                        {

                            dt.Clear();
                            string strSqlStr = "Update  ShipmentOrder set orderStatus = 'waitingBooking'  where orderID = " + orderID;
                            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, connStr);
                            dataAdapter2.Fill(dt);

                            dt.Clear();
                            string str2SqlStr = "Update  Payment set paymentStatus = 'Monthly'  where paymentID = " + orderID;
                            OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(str2SqlStr, connStr);
                            dataAdapter3.Fill(dt);

                            MessageBox.Show("Finish Monthly Payment , please booking a pickup later", "Payment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("This order cannot change the payment method", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Cannot found this order", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                catch
                {
                    MessageBox.Show("Something Wrong", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
