﻿using System;
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

        public static int position;
        public static int customerID;
        public static int staffID;

        public Main()
        {
            InitializeComponent();
        }
        private void Main_Load(object sender, EventArgs e)
        {

        }

        private void btnCustomerLogin_Click(object sender, EventArgs e)
        {
            CustomerLogin csutLogin = new CustomerLogin();
            csutLogin.Show();
            this.Hide();
        }

        private void btnStaffLogin_Click(object sender, EventArgs e)
        {
            StaffLogin staffLogin = new StaffLogin();
            staffLogin.Show();
            this.Hide();
        }

        private void btnCustomerCreateAccount_Click(object sender, EventArgs e)
        {
            CustomerCreateAccout cusCreateAccount = new CustomerCreateAccout();
            cusCreateAccount.Show();
            this.Hide();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
