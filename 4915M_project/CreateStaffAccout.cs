using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

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
            if (txtStaffName.Text == "Staff Full Name")
            {
                txtStaffName.Text = "";
            }
        }


        private void txtStfPwd2(object sender, EventArgs e)
        {
            if (txtPassword2.Text == "Repeated Password")
            {
                txtPassword2.Text = "";
                txtPassword2.PasswordChar = '*';
                txtPassword2.MaxLength = 14;
            }
        }

        private void txtStfPwd_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Passwrod")
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
                txtPassword.MaxLength = 14;
            }
        }

        private void CreateStaffAccout_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "" || txtPassword2.Text == "" || txtStaffName.Text == "")
            {
                MessageBox.Show("Please enter value in all field", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtStaffName.Text == "" || txtStaffName.Text.Length < 6)
            {
                MessageBox.Show("Please Enter A Valid Name", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text.Length < 6)
            {
                MessageBox.Show("The password cannot short than 6 digit", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPassword.Text != txtPassword2.Text)
            {
                MessageBox.Show("Please enter both password same", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = Program.DataTableVar;
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";
                String name = txtStaffName.Text;
                String pwd = txtPassword.Text;
                String position = comboBox1.Text;

                string sqlString = "Insert into Staff (stfName, stfPosition, stfPassword) values ('" + name + "','" + position + "','" + pwd + "');";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlString, connStr);
                dataAdapter.Fill(dt);
                dataAdapter.Dispose();
                dt.Clear();
                name = null;
                pwd = null;
                position = null;
                MessageBox.Show("Staff Account has been Successfully Created", "Registration success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
