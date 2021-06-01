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
    public partial class VerifyOrder : Form
    {
        public VerifyOrder()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            StaffLobby stafflobby = new StaffLobby();
            stafflobby.Show();
            this.Hide();
        }
    }
}
