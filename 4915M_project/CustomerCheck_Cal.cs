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
    public partial class CustomerCheck_Cal : Form
    {
        public CustomerCheck_Cal()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CustomerLobby custLobby = new CustomerLobby();
            custLobby.Show();
            this.Hide();
        }

        private void btnPayment_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Show();
            this.Hide();
        }
    }
}
