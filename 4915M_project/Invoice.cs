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
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            CustomerLobby custLobby = new CustomerLobby();
            custLobby.Show();
            this.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Invoice2 invoice2 = new Invoice2();
            invoice2.Show();
            this.Hide();
        }
    }
}
