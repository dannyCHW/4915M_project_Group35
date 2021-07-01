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
    public partial class StaffLogin : Form
    {
        public static DataTable DataTableVar2 = new DataTable();

        public StaffLogin()
        {
            InitializeComponent();
        }

        private void StaffLogin_Load(object sender, EventArgs e)
        {
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                String staffID = txtStaffID.Text;
                String pswd = txtPassword.Text;
                int vID;
                String vPwd = "";
                String vPosition;
                int sstaffID = Convert.ToInt32(txtStaffID.Text);

                DataTable dt = Program.DataTableVar;
                String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";

                dt.Clear();

                string sqlStr = "Select stfID,stfPassword,stfPosition from Staff where stfID = " + sstaffID;
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
                dataAdapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    vID = Convert.ToInt32(dt.Rows[0]["stfID"]);
                    Main.staffID = Convert.ToInt32(dt.Rows[0]["stfID"]); ;
                    vPwd = dt.Rows[0]["stfPassword"].ToString();
                    vPosition = dt.Rows[0]["stfPosition"].ToString();
                    //Console.WriteLine(vpswd + vemail);


                    if (sstaffID == vID && pswd == vPwd && vPosition == "Manager")
                    {
                        Main.position = 5;
                        ManagerLobby managerLobby = new ManagerLobby();
                        managerLobby.Show();
                        this.Close();
                    }
                    else if (sstaffID == vID && pswd == vPwd && vPosition == "Normal Staff")
                    {
                        Main.position = 1;
                        StaffLobby stafflobby = new StaffLobby();
                        stafflobby.Show();
                        this.Hide();
                    }
                    else
                    {
                        //temp message, maybe change to messageBox?
                        MessageBox.Show("Wrong id or password", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    MessageBox.Show("Wrong Id or Password", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("The value cannot be empty", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtID_Click(object sender, EventArgs e)
        {
            if (txtStaffID.Text == "Staff ID")
            {
                txtStaffID.Text = "";
            }
        }

        private void txtPwd_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
                txtPassword.PasswordChar = '*';
                txtPassword.MaxLength = 14;
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            txtPassword.PasswordChar = '*';
            txtPassword.ForeColor = Color.White;
        }

        private void txtStaffID_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            txtStaffID.ForeColor = Color.White;
            if (!Char.IsNumber(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
