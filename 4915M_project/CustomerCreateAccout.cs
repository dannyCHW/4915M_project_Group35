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
    public partial class CustomerCreateAccout : Form
    {
        public CustomerCreateAccout()
        {
            InitializeComponent();
        }
        private void btnCreateAccout_Click_1(object sender, EventArgs e)
        {
            if (txtPhone.Text == "" || txtEmail.Text == "" || txtPwd2.Text == "" || txtPwd.Text == "") {
                MessageBox.Show("Please Enter All The Information", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Contains('.'))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (txtPhone.Text.Length < 7) {
                MessageBox.Show("Please Enter A Valid Phone Number", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (txtPwd.Text != txtPwd2.Text) {
                MessageBox.Show("Please Enter A Same Password", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Main main = new Main();
                main.Show();
                this.Hide();
            }
        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void CustomerCreateAccout_Load(object sender, EventArgs e)
        {

        }

    }
}
