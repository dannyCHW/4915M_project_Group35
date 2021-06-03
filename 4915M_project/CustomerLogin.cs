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
    public partial class CustomerLogin : Form
    {

        private DataTable dt = new DataTable();
        string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";

        public CustomerLogin()
        {
            InitializeComponent();
        }

        private void CustomerLogin_Load(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            String email = txtEmail.Text;
            String pswd = txtPassword.Text;
            String vemail = "";
            String vpswd = "";

            string sqlStr = "Select cusEmail, cusPassword from Customer where cusEmail LIKE '" + email + "'";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);

            try
            {
                if (dt.Rows.Count > 0){
                    vemail = dt.Rows[0]["cusEmail"].ToString();
                    vpswd = dt.Rows[0]["cusPassword"].ToString();
                    //Console.WriteLine(vpswd + vemail);

                    if (vemail == email && vpswd == pswd)
                    {
                        CustomerLobby cusPage = new CustomerLobby();
                        vemail = null;
                        vpswd = null;
                        cusPage.Show();
                        this.Close();
                    }
                    else
                    {
                        //temp message, maybe change to messageBox?
                        Console.WriteLine("Wrong password or email");
                    }

                } 
                else
                {
                    throw new Exception("");
                }
                
            } 
            catch (Exception)
            {
                //temp message, maybe change to messageBox?
                Console.WriteLine("No such account, plz got to register");
            }

            dataAdapter.Dispose();

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Close();
        }

        private void txtEmail_MouseEnter(object sender, EventArgs e)
        {}

        private void txtEmail_MouseLeave(object sender, EventArgs e)
        {}

        private void txtEmail_TextChanged(object sender, EventArgs e)
        {}

        private void txtEmail_Click(object sender, EventArgs e)
        {
            if (txtEmail.Text == "Email")
            {
                txtEmail.Text = "";
            }
        }

        private void txtPasswrod_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text == "Password")
            {
                txtPassword.Text = "";
            }
        }
    }
}