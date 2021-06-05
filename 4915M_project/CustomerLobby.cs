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
    public partial class CustomerLobby : Form
    {
        private Form activeForm = null;

        public CustomerLobby()
        {
            InitializeComponent();
        }

        private void btnAirwayBill_Click(object sender, EventArgs e)
        {
            openChildForm(new AirwayBill1());
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
            CheckBooking check = new CheckBooking();
            check.Show();
            this.Hide();
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
        }
    }
}
