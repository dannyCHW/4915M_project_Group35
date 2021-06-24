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
    public partial class BookingPickup : Form
    {
        public BookingPickup()
        {
            InitializeComponent();
        }

        private void BookingPickup_Load(object sender, EventArgs e)
        {
            cbo.Items.Clear();
            DataTable dt = Program.DataTableVar;
            string connStr = Program.connStr;
            string sqlStr = "SELECT orderID FROM ShipmentOrder WHERE cusID=" + CustomerLogin.currentCustomerID + " AND (orderStatus = 'Waiting Pickup' OR orderStatus = 'Waiting Payment'OR orderStatus = 'Waiting Booking');";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                cbo.Items.Clear();
                cbo.Items.Add(dr["orderID"].ToString());
            }

            dataAdapter.Dispose();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            DateTime select = dateTime.Value;
            int result = DateTime.Compare(select, today.AddDays(3));

            if (cbo.Text != "")
            {
                DataTable dt = Program.DataTableVar;
                String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";
                int this_order = Convert.ToInt32(cbo.Text);
                dt.Clear();
                string sqlStr = "Select orderStatus,dateOfPickUp from ShipmentOrder where orderID = " + this_order + " AND cusID = " + CustomerLogin.currentCustomerID + ";";

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
                dataAdapter.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    if (result < 0)
                    {
                        MessageBox.Show("You must choose a date after 3 days", "Select wrong date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (dateTime.Value.Hour < 9)
                    {
                        MessageBox.Show("Not the working time", "Select wrong time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else if (dateTime.Value.Hour > 16)
                    {
                        MessageBox.Show("Not the working time", "Select wrong time", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else
                    {

                        String status = dt.Rows[0]["orderStatus"].ToString();
                        if (status == "Waiting Booking")
                        {
                            String createDate = dateTime.Value.ToString();

                            string strSqlStr = "Update ShipmentOrder set orderStatus = 'Waiting Pickup' , dateOfPickUp = " + "'" + createDate + "'" + " where orderID = " + this_order;
                            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, connStr);
                            dataAdapter2.Fill(dt);
                            dataAdapter.Dispose();

                            dataAdapter2.Dispose();
                            MessageBox.Show("Successful create a booking", "Booking Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else if (status == "Waiting Pickup")
                        {
                            String createDate = dateTime.Value.ToString();

                            string strSqlStr = "Update ShipmentOrder set  dateOfPickUp = '" + createDate + "' where orderID = " + this_order;

                            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, connStr);
                            dataAdapter2.Fill(dt);

                            MessageBox.Show("Successful Edit Booking", "Booking Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dt.Clear();
                            dataAdapter2.Dispose();
                        }
                        else
                        {
                            MessageBox.Show("Something Wroing", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                } 
            }
            else {
                MessageBox.Show("Must input the order number", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnUpdate_Click_1(object sender, EventArgs e)
        {

        }

        private void txtOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void dateTime_ValueChanged(object sender, EventArgs e)
        {
            DateTime select = dateTime.Value;
            DateTime today = DateTime.Today;
            int result = DateTime.Compare(select, today.AddDays(3));
            if (result < 0) {
                MessageBox.Show("You must choose a date after 3 days", "Select wrong date", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            } 

        }

        private void txtOrder_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
