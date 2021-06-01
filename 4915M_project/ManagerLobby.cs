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
    }
}
