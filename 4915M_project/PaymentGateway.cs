﻿using System;
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
    public partial class PaymentGateway : Form
    {
        public PaymentGateway()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            Payment payment = new Payment();
            payment.Show();
            this.Close();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (txtOrder.Text == "")
            {
                MessageBox.Show("Please input oreder number", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (!checkBox.Checked)
            {
                MessageBox.Show("Please confirm", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int orderID = Convert.ToInt32(txtOrder.Text);
                DataTable dt = new DataTable();
                dt.Clear();
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";

                string sqlStr = "Select orderStatus from ShipmentOrder where orderID = " + orderID;

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
                dataAdapter.Fill(dt);


                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        String status = dt.Rows[0]["orderStatus"].ToString();
                        if (status == "Waiting Payment")
                        {

                            dt.Clear();
                            string strSqlStr = "Update  ShipmentOrder set orderStatus = 'Waiting Booking'  where orderID = " + orderID;
                            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, connStr);
                            dataAdapter2.Fill(dt);

                            dt.Clear();
                            string str2SqlStr = "Update  Payment set paymentStatus = 'paid'  where paymentID = " + orderID;
                            OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(str2SqlStr, connStr);
                            dataAdapter3.Fill(dt);

                            MessageBox.Show("Finish payment , please booking a pickup later", "Payment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        } else if (status == "Addition") { 
                            

                                dt.Clear();
                                string strSqlStr7 = "Update  ShipmentOrder set orderStatus = 'Processing'  where orderID = " + orderID;
                                OleDbDataAdapter dataAdapter7 = new OleDbDataAdapter(strSqlStr7, connStr);
                                dataAdapter7.Fill(dt);

                                dt.Clear();
                                string str2SqlStr8 = "Update  Payment set paymentStatus = 'paid'  where paymentID = " + orderID;
                                OleDbDataAdapter dataAdapter8 = new OleDbDataAdapter(str2SqlStr8, connStr);
                                dataAdapter8.Fill(dt);

                                MessageBox.Show("Finish payment , addtion fee has been pay", "Payment Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            
                        }
                        else
                        {
                            MessageBox.Show("This order cannot change the payment method", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }

                    }
                    else
                    {
                        MessageBox.Show("Cannot found this order", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                catch
                {
                    MessageBox.Show("Something Wrong", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void txtOrder_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void PaymentGateway_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            //this.Close();
        }
    }
}
