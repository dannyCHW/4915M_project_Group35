using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915M_project
{
    public partial class ManagerLobby : Form
    {
        public ManagerLobby()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void btnCreateStaff_Click(object sender, EventArgs e)
        {
            CreateStaffAccout createstaff = new CreateStaffAccout();
            createstaff.Show();
            this.Hide();
        }
        private void btnViewRecord_Click(object sender, EventArgs e)
        {
            ViewDatabase viewdatabase = new ViewDatabase();
            viewdatabase.Show();
            this.Hide();
        }

        private void btnUpdateOrder_Click(object sender, EventArgs e)
        {
            UpdateOrder updateorder = new UpdateOrder();
            updateorder.Show();
            this.Hide();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            VerifyOrder verifyorder = new VerifyOrder();
            verifyorder.Show();
            this.Hide();
        }

        private void ManagerLobby_Load(object sender, EventArgs e)
        {

        }

        private void btnAlertPickUp_Click(object sender, EventArgs e)
        {
            AlertEmail alertpickup = new AlertEmail();
            alertpickup.Show();
            this.Hide();
        }

        private void btnProblem_Click(object sender, EventArgs e)
        {
            problem problem = new problem();
            problem.Show();
            this.Close();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

    }
}
