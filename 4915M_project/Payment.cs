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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            CustomerCheck_Cal cusCheck = new CustomerCheck_Cal();
            cusCheck.Show();
            this.Hide();
        }

        private void btnExtenalBilling_Click(object sender, EventArgs e)
        {
            CustomerLobby custLobby = new CustomerLobby();
            custLobby.Show();
            this.Hide();
        }

        private void btnCheque_credit_Click(object sender, EventArgs e)
        {
            CustomerLobby custLobby = new CustomerLobby();
            custLobby.Show();
            this.Hide();
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            CustomerLobby custLobby = new CustomerLobby();
            custLobby.Show();
            this.Hide();
        }
    }
}
