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
    public partial class CheckBooking : Form
    {
        public CheckBooking()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            CustomerLobby cuslobby = new CustomerLobby();
            cuslobby.Show();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BookingPickup booking = new BookingPickup();
            booking.Show();
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            if (cbo.Text != "")
            {
                DataTable dt = Program.DataTableVar;
                String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";
                int this_order = Convert.ToInt32(cbo.Text);
                dt.Clear();
                string sqlStr = "Select orderStatus,dateOfPickUp from ShipmentOrder where orderID = " + this_order + " AND cusID = " + CustomerLogin.currentCustomerID;

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
                dataAdapter.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    String status = dt.Rows[0]["orderStatus"].ToString();
                    String date = dt.Rows[0]["dateOfPickUp"].ToString();
                    if (status == "waitingBooking")
                    {
                        dataAdapter.Dispose();
                        dt.Clear();
                        MessageBox.Show("No booking of this order , Please create a booking", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (status == "waitingPickup")
                    {
                        dataAdapter.Dispose();
                        dt.Clear();
                        MessageBox.Show("Is already booking , the booking is in " + date + " You can edit before 3 day of the booking", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else {
                        dataAdapter.Dispose();
                        dt.Clear();
                        MessageBox.Show("This order cannot booking , please check the status" ,"Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                else
                {
                    MessageBox.Show("Cannot found this order", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            else
            {
                MessageBox.Show("Must input the order number", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CheckBooking_Load(object sender, EventArgs e)
        {
            cbo.Items.Clear();
            DataTable dt = Program.DataTableVar;
            string connStr = Program.connStr;
            string sqlStr = "SELECT orderID FROM ShipmentOrder WHERE cusID=" + CustomerLogin.currentCustomerID + " AND orderStatus LIKE 'waitingPickup' OR orderStatus LIKE 'waitingPayment' or orderStatus LIKE 'waitingBooking';";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cbo.Items.Clear();
                cbo.Items.Add(dr["orderID"].ToString());
            }

            dataAdapter.Dispose();
        }
    }
}
