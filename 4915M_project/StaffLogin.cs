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
            String staffID = txtStaffID.Text;
            String pswd = txtPassword.Text;
            String vID = "";
            String vPwd = "";
            string vPosition = "";

            DataTable dt = Program.DataTableVar;
            String connStr = "";

            string sqlStr = "Select stfID,stfPassword,stfPosition from Staff where stfID = '" + staffID + "'";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);

            try
            {
                if (dt.Rows.Count > 0)
                {
                    vID = dt.Rows[0]["stfID"].ToString();
                    vPwd = dt.Rows[0]["stfPassword"].ToString();
                    vPosition = dt.Rows[0]["stfPosition"].ToString();
                    //Console.WriteLine(vpswd + vemail);

                    if (staffID == vID && pswd == vPwd && vPosition == "5")
                    {

                        ManagerLobby managerLobby = new ManagerLobby();
                        managerLobby.Show();
                        this.Close();
                    }
                    else if (staffID == vID && pswd == vPwd && vPosition == "1")
                    {
                        StaffLobby stafflobby = new StaffLobby();
                        stafflobby.Show();
                        this.Hide();
                    }
                    else
                    {
                        //temp message, maybe change to messageBox?

                        MessageBox.Show("Wrong Id or Password", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    throw new Exception("");
                }
                dataAdapter.Dispose();
            }
            catch (Exception)
            {
                //temp message, maybe change to messageBox?
                Console.WriteLine("No such account , please contect manager");
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
    }
}
