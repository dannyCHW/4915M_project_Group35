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
    public partial class DeleteStaffAccout : Form
    {
        public DeleteStaffAccout()
        {
            InitializeComponent();
        }

        private void btnLobby_Click(object sender, EventArgs e)
        {
            ManagerLobby managerlobby = new ManagerLobby();
            managerlobby.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            CreateStaffAccout createstaff = new CreateStaffAccout(); 
            createstaff.Show();
            this.Hide();
        }
    }
}
