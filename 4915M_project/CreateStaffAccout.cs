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
    public partial class CreateStaffAccout : Form
    {
        public CreateStaffAccout()
        {
            InitializeComponent();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteStaffAccout deletestaff = new DeleteStaffAccout();
            deletestaff.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ManagerLobby managerlobby = new ManagerLobby();
            managerlobby.Show();
            this.Hide();
        }

        private void txtStaffname_Click(object sender, EventArgs e)
        {

        }


        private void txtStfPwd2(object sender, EventArgs e)
        {

        }

        private void txtStfPwd_Click(object sender, EventArgs e)
        {

        }
    }
}
