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
    public partial class CustomerCreateAccout : Form
    {


        public CustomerCreateAccout()
        {
            InitializeComponent();
        }


        private void btnCreateAccout_Click_1(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";
            if (txtPhone.Text == "" || txtEmail.Text == "" || txtPwd2.Text == "" || txtPwd.Text == "" || txtName.Text == "")
            {
                MessageBox.Show("Please enter value in all field", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (!this.txtEmail.Text.Contains('@') || !this.txtEmail.Text.Contains('.'))
            {
                MessageBox.Show("Please Enter A Valid Email", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPhone.Text.Length < 7 || System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, "[^0-9]"))
            {
                MessageBox.Show("Please Enter A Valid Phone Number", "Invalid Phone", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtName.Text == "" || System.Text.RegularExpressions.Regex.IsMatch(txtPhone.Text, "[^0-9]")|| txtName.Text.Length<6) {
                    MessageBox.Show("Please Enter A Valid Name", "Invalid Name", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            else if (txtPwd.Text.Length < 6) {
                MessageBox.Show("The password cannot short than 6 digit", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtPwd.Text != txtPwd2.Text)
            {
                MessageBox.Show("Please enter both password same", "Invalid Password", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {

                String phone = txtPhone.Text;
                String email = txtEmail.Text;
                String pwd = txtPwd.Text;
                String name = txtName.Text;

                string sqlStr = "Select cusEmail from Customer where cusEmail = '" + email + "';";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
                dataAdapter.Fill(dt);


                if (dt.Rows.Count > 0)
                {
                    dataAdapter.Dispose();

                    MessageBox.Show("This Email Already Been used", "Invalid Email", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }

                /*
                 * 
                 * 
                 * 
                 * 
                 * 
                 * 屌！！！！！！！！！！！！未check到Phone Number 用左未 可以留翻遲D做
                 */
                else {
                    dataAdapter.Dispose();
                    string sqlString = "Insert into Customer (cusName, cusPhone, cusPassword, cusEmail) values ('" + name + "','" + phone + "','" + pwd + "','" + email + "');";

                    OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(sqlString, connStr);
                    dataAdapter2.Fill(dt);
                    dataAdapter.Dispose();
                    MessageBox.Show("Your Account has been Successfully Created", "Registration success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Main main = new Main();
                    main.Show();
                    this.Hide();
                }
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

        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
            }
        }

        private void txtPhone_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text == "Phone")
            {
                txtPhone.Text = "";
            }
        }

        private void txtName_Click(object sender, EventArgs e)
        {
            if (txtName.Text == "Full Name")
            {
                txtName.Text = "";
            }
        }

        private void txtPwd_Click(object sender, EventArgs e)
        {
            if (txtPwd.Text == "Password")
            {
                txtPwd.Text = "";
                txtPwd.PasswordChar = '*';
                txtPwd.MaxLength = 14;
            }
        }

        private void txtPwd2_Click(object sender, EventArgs e)
        {
            if (txtPwd2.Text == "Repeated Password")
            {
                txtPwd2.Text = "";
                txtPwd2.PasswordChar = '*';
                txtPwd2.MaxLength = 14;
            }
        }
    }
}
