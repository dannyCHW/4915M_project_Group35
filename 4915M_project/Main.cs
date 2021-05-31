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
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        private void btnCustomerLogin_Click_1(object sender, EventArgs e)
        {
            CustomerLogin csutLogin = new CustomerLogin();
            csutLogin.Show();
            this.Hide();
        }

        private void btnStaffLogin_Click_1(object sender, EventArgs e)
        {
<<<<<<< HEAD
<<<<<<< HEAD
            StaffLogin staffLogin = new StaffLogin();
            staffLogin.Show();
            this.Hide();
=======
            //StaffLogin staffLogin = new StaffLogin();
            //staffLogin.Show();
            //this.Hide();
>>>>>>> 63103e7f9d22687fe1a5cb27c9d69dcfc91d7063
=======
            //StaffLogin staffLogin = new StaffLogin();
            //staffLogin.Show();
            //this.Hide();
>>>>>>> 63103e7f9d22687fe1a5cb27c9d69dcfc91d7063
        }

        private void btnCustomerCreateAccount_Click_1(object sender, EventArgs e)
        {
            CustomerCreateAccout cusCreateAccount = new CustomerCreateAccout();
            cusCreateAccount.Show();
            this.Hide();
        }
    }
}
