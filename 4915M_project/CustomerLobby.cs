﻿using System;
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
    public partial class CustomerLobby : Form
    {
        private Form activeForm = null;
        
        public CustomerLobby()
        {
            InitializeComponent();
            
        }

        private void btnAirwayBill_Click(object sender, EventArgs e)
        {
            Form form = new AirwayBill1();
            
            try
            {
                var frm = Application.OpenForms["AirwayBill1"];
                if (frm == null)
                {
                    form = new AirwayBill1();
                }
                openChildForm(form);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            


            
        }

        private void btnAirwayBill2_Click(object sender, EventArgs e)
        {

        }

        private void btnCustomerCheck_Click(object sender, EventArgs e)
        {
            openChildForm(new CustomerCheck_Cal()); 
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            CustomerCheck_Cal cusCheck = new CustomerCheck_Cal();
            cusCheck.Show();
            this.Hide();
        }

        private void btnBooking_Click(object sender, EventArgs e)
        {
            openChildForm(new CheckBooking());
        }

        private void btnBooking2_Click(object sender, EventArgs e)
        {
            BookingPickup booking = new BookingPickup();
            booking.Show();
            this.Hide();
        }

        private void btnTracking_Click(object sender, EventArgs e)
        {
            openChildForm(new Tracking());
        }

        private void btnCustomerInvoice_Click(object sender, EventArgs e)
        {
            openChildForm(new Invoice());
        }

        private void openChildForm(Form childForm)
        {
            if (activeForm != null)
            {
                activeForm.Close();
            }
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChildForm.Controls.Add(childForm);
            panelChildForm.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }

        private void panelLogo_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelChildForm_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void CustomerLobby_Load(object sender, EventArgs e)
        {
            lblCurrentUser.Text = "You are now login as " + CustomerLogin.currentCustomerName;


            /*   here is the code */
            DataTable dt3 = Program.DataTableVar;
            dt3.Clear();
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";

            string sqlStr = "Select orderStatus,dateOfPickUp,currentLocation,receiverCountry from ShipmentOrder where receiverEmail = '" + CustomerLogin.customerEmail + "' AND orderStatus = 'processing' ;";

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt3);

            if (dt3.Rows.Count > 0)
            {
                int loop = 0;
                while (loop < dt3.Rows.Count)
                {
                    String status = dt3.Rows[loop]["orderStatus"].ToString();
                    String pickupDate = dt3.Rows[loop]["dateOfPickUp"].ToString();
                    String vcurrentLocation = dt3.Rows[loop]["currentLocation"].ToString();
                    String vreceiverCountry = dt3.Rows[loop]["receiverCountry"].ToString();

                        DateTime localDate = DateTime.Now;

                        var v_exDay = DateTime.Parse(pickupDate);
                        DateTime expectedDate = (DateTime)v_exDay.AddDays(7);

                    int result = localDate.Day - expectedDate.Day;
                    if (result >= -2 && vcurrentLocation == vreceiverCountry)
                    {
                        MessageBox.Show("The goods you need to receive already arrived locally, please confirm the estimated time of delivery", "Goods Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    } else if (result >= -2) {
                        MessageBox.Show("The cargo is expected to arrive in the last two days, please pay attention to the cargo location and login information", "Goods Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    loop++;

                }

            }
            /* code end*/
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MonthlyManagement monthmanage = new MonthlyManagement();
            monthmanage.Show();
            this.Hide();
        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void viewAirwayBill_Click(object sender, EventArgs e)
        {
            
            openChildForm(new viewAirwayBill());
        }

        private void btnBulkOrder_Click(object sender, EventArgs e)
        {
            openChildForm(new excelAirwayBill());
        }
    }
}
