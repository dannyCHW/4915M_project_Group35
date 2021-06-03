using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

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
                MessageBox.Show("Please enter value in all field", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Contains('.com'))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (txtPhone.Text.Length < 7) {
                MessageBox.Show("Please Enter A Valid Phone Number", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (txtPwd.Text != txtPwd2.Text) {
                MessageBox.Show("Please enter both password same", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        private void InitializeMyControl()
        {
            // Set to no text.
            txtPwd.Text = "";
            // The password character is an asterisk.
            txtPwd.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            txtPwd.MaxLength = 14;
            // Set to no text.
            txtPwd2.Text = "";
            // The password character is an asterisk.
            txtPwd2.PasswordChar = '*';
            // The control will allow no more than 14 characters.
            txtPwd2.MaxLength = 14;
        }

    }
}
