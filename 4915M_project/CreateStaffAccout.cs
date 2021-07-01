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
            this.Close();
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
            if (txtPassword.Text == "Password")
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
                MessageBox.Show("Please enter a valid name", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                DataTable dt = new DataTable();

                String name = txtStaffName.Text.ToString();
                String pwd = txtPassword.Text.ToString();
                String position = comboBox1.Text.ToString();

                string sqlString = "Insert into Staff (stfName, stfPosition, stfPassword) values ('" + name + "','" + position + "','" + pwd + "');";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlString, Program.connStr);
                dataAdapter.Fill(dt);
                dataAdapter.Dispose();
                dt.Clear();

                dt.Clear();
                string sqlString2 = "Select stfID from Staff where stfName = '" + name + "' AND stfPassword = '" + pwd + "'; ";
                OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(sqlString2, Program.connStr);
                dataAdapter2.Fill(dt);
                int id = Convert.ToInt32(dt.Rows[0]["stfID"]);
                dataAdapter2.Dispose();
                dt.Clear();


                MessageBox.Show("Staff Account has been Successfully Created , the staff ID is " + id.ToString(), "Registration success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtStaffName_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtStaffName.ForeColor = Color.Black;
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPassword.ForeColor = Color.Black;
        }

        private void txtPassword2_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPassword2.ForeColor = Color.Black;
        }
    }
}
