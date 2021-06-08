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

        public static int currentCustomerID;
        public static String currentCustomerName;
        public static String customerEmail;

        public CustomerLogin()
        {
            InitializeComponent();
        }

        private void CustomerLogin_Load(object sender, EventArgs e)
        {
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            DataTable dt = Program.DataTableVar;
            string connStr = Program.connStr;

            String email = txtEmail.Text;
            String pswd = txtPassword.Text;
            String vemail = "";
            String vpswd = "";

            //shortCut
            if (email == "s" && pswd == "s")
            {
                CustomerLobby cusPage = new CustomerLobby();
                vemail = null;
                vpswd = null;
                cusPage.Show();
                this.Close();
            }

            string sqlStr = "Select cusID, cusName, cusEmail, cusPassword from Customer where cusEmail LIKE '" + email + "'";
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
                        currentCustomerID = Convert.ToInt32(dt.Rows[0]["cusID"]);
                        currentCustomerName = dt.Rows[0]["cusName"].ToString();
                        customerEmail = dt.Rows[0]["cusEmail"].ToString(); ;
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
            dt = null;
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