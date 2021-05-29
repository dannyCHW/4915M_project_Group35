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
    public partial class Invoice2 : Form
    {
        public Invoice2()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Invoice invoice = new Invoice();
            invoice.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerLobby custLobby = new CustomerLobby();
            custLobby.Show();
            this.Hide();
        }
    }
}
