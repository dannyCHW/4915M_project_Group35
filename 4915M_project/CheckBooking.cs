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
            if (txtOrder.Text != "")
            {
                DataTable dt = Program.DataTableVar;
                String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";
                int this_order = Convert.ToInt32(txtOrder.Text);
                dt.Clear();
                string sqlStr = "Select orderStatus,dateOfPickUp from ShipmentOrder where orderID = " + this_order + " AND cusID = " + CustomerLogin.currentCustomerID;

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
                dataAdapter.Fill(dt);
                MessageBox.Show("dll,", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                if (dt.Rows.Count > 0)
                {
                    String status = dt.Rows[0]["orderStatus"].ToString();
                    String date = dt.Rows[0]["dateOfPickUp"].ToString();
                    MessageBox.Show(status, "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                        MessageBox.Show("Is already booking , the booking is in " + date + " You can edit before 3 day of the booking", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        }
    }
}
