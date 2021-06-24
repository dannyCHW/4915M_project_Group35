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
    public partial class problem : Form
    {
        public problem()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Main.position == 1)
            {
                StaffLobby stafflobby = new StaffLobby();
                stafflobby.Show();
                this.Hide();
            }
            else
            {
                ManagerLobby managerLobby = new ManagerLobby();
                managerLobby.Show();
                this.Close();
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

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (!checkBox.Checked)
            {
                MessageBox.Show("You need to confirm check box", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtGood.Text == "")
            {
                MessageBox.Show("The order number cannot empty", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (txtWeight.Text == "")
            {
                MessageBox.Show("The weight number cannot empty", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                int goodID = Convert.ToInt32(txtGood.Text);
                double newWeight = Convert.ToDouble(txtWeight.Text);

                DataTable dt = Program.DataTableVar;
                dt.Clear();
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";

                string sqlStr = "Select orderID,totalWeight,type from Good where goodID = " + goodID;

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
                dataAdapter.Fill(dt);
                try
                {
                    if (dt.Rows.Count > 0)
                    {
                        int orderID = Convert.ToInt32(dt.Rows[0]["orderID"]);
                        double weight = Convert.ToDouble(dt.Rows[0]["totalWeight"]);
                        String type = dt.Rows[0]["type"].ToString();

                        dt.Clear();
                        string sqlStr2 = "Select receiverCountry from ShipmentOrder where orderID = " + orderID;
                        OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(sqlStr2, connStr);
                        dataAdapter2.Fill(dt);

                        String toCountry = dt.Rows[0]["receiverCountry"].ToString();

                        /*   origin pirce (cargo)  */
                        double currentMoney = 0;
                        if (type.Equals("Document"))
                        {
                            //Console.WriteLine(kg);
                            if (weight > 0.5)
                            {
                                while (weight > 0.5)
                                {
                                    currentMoney = currentMoney + 150;
                                    weight = weight - 0.5;
                                }
                            }
                            currentMoney = currentMoney + 158;

                        }
                        else if (type.Equals("Package"))
                        {
                            if (weight >= 3 && weight <= 15)
                            {
                                if (toCountry.Equals("Australia") || toCountry.Equals("Japan"))
                                {
                                    currentMoney = currentMoney + (weight * 75);
                                }
                                else
                                {
                                    currentMoney = currentMoney + (weight * 45);
                                }
                            }
                            else if (weight >= 16 && weight <= 29)
                            {
                                if (type.Equals("Australia") || type.Equals("Japan"))
                                {
                                    currentMoney = currentMoney + (weight * 70);
                                }
                                else
                                {
                                    currentMoney = currentMoney + (weight * 40);
                                }
                            }
                            else if (weight >= 30 && weight <= 44)
                            {
                                if (toCountry.Equals("Australia") || toCountry.Equals("Japan"))
                                {
                                    currentMoney = currentMoney + (weight * 65);
                                }
                                else
                                {
                                    currentMoney = currentMoney + (weight * 37);
                                }
                            }
                            else if (weight >= 45 && weight <= 69)
                            {
                                if (currentMoney.Equals("Australia") || currentMoney.Equals("Japan"))
                                {
                                    currentMoney = currentMoney + (weight * 62);
                                }
                                else
                                {
                                    currentMoney = currentMoney + (weight * 35);
                                }
                            }
                            else if (weight >= 70 && weight <= 99)
                            {
                                if (type.Equals("Australia") || type.Equals("Japan"))
                                {
                                    currentMoney = currentMoney + (weight * 61);
                                }
                                else
                                {
                                    currentMoney = currentMoney + (weight * 33);

                                }
                            }
                            else if (weight >= 100 && weight <= 999)
                            {
                                if (type.Equals("Australia") || type.Equals("Japan"))
                                {
                                    currentMoney = currentMoney + (weight * 58);
                                }
                                else
                                {
                                    currentMoney = currentMoney + (weight * 32);
                                }
                            }
                        }
                        /* end here */

                        /* new price*/
                        double newPirce = 0;

                        if (type.Equals("Document"))
                        {
                            //Console.WriteLine(kg);
                            if (newWeight > 0.5)
                            {
                                while (newWeight > 0.5)
                                {
                                    newPirce = newPirce + 150;
                                }
                            }
                            newPirce = newPirce + 158;

                        }
                        else if (type.Equals("Package"))
                        {
                            if (newWeight >= 3 && newWeight <= 15)
                            {
                                if (toCountry.Equals("Australia") || toCountry.Equals("Japan"))
                                {
                                    newPirce = newPirce + (newWeight * 75);
                                }
                                else
                                {
                                    newPirce = newPirce + (newWeight * 45);
                                }
                            }
                            else if (newWeight >= 16 && newWeight <= 29)
                            {
                                if (type.Equals("Australia") || type.Equals("Japan"))
                                {
                                    newPirce = newPirce + (newWeight * 70);
                                }
                                else
                                {
                                    newPirce = newPirce + (newWeight * 40);
                                }
                            }
                            else if (newWeight >= 30 && newWeight <= 44)
                            {
                                if (toCountry.Equals("Australia") || toCountry.Equals("Japan"))
                                {
                                    newPirce = newPirce + (newWeight * 65);
                                }
                                else
                                {
                                    newPirce = newPirce + (newWeight * 37);
                                }
                            }
                            else if (newWeight >= 45 && newWeight <= 69)
                            {
                                if (currentMoney.Equals("Australia") || currentMoney.Equals("Japan"))
                                {
                                    newPirce = newPirce + (newWeight * 62);
                                }
                                else
                                {
                                    newPirce = newPirce + (newWeight * 35);
                                }
                            }
                            else if (newWeight >= 70 && newWeight <= 99)
                            {
                                if (type.Equals("Australia") || type.Equals("Japan"))
                                {
                                    newPirce = newPirce + (newWeight * 61);
                                }
                                else
                                {
                                    newPirce = newPirce + (newWeight * 33);

                                }
                            }
                            else if (newWeight >= 100 && newWeight <= 999)
                            {
                                if (type.Equals("Australia") || type.Equals("Japan"))
                                {
                                    newPirce = newPirce + (newWeight * 58);
                                }
                                else
                                {
                                    newPirce = newPirce + (newWeight * 32);
                                }
                            }
                        }
                        /// Update

                        if (newPirce - currentMoney != 0)
                        {
                            dt.Clear();
                            string sqlStr3 = "select price,paymentStatus from Payment where paymentID = " + orderID;
                            OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(sqlStr3, connStr);
                            dataAdapter3.Fill(dt);
                            String paymentStatus = dt.Rows[0]["paymentStatus"].ToString();
                            int oldPrice = Convert.ToInt32(dt.Rows[0]["price"]);
                            int newestPrice = oldPrice + Convert.ToInt32(newPirce);

                            if (paymentStatus.Equals("extenal") || paymentStatus.Equals("Monthly")) {

                                dt.Clear();
                                string sqlStr4 = "Update Payment price=" + newestPrice + ",additionPrice = " + newPirce + "  where paymentID = " + orderID;
                                OleDbDataAdapter dataAdapter4 = new OleDbDataAdapter(sqlStr4, connStr);
                                dataAdapter4.Fill(dt);

                                /* Email send to increate price*/

                                MessageBox.Show("Update successful, Email is send to the customer", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            } else if (paymentStatus.Equals("paid") || paymentStatus.Equals("addition")) {
                                dt.Clear();
                                ///
                                string sqlStr5 = "Update Payment SET paymentStatus='addition' ,price =" + newestPrice + ",additionPrice = " + Convert.ToInt32(newPirce) + " where paymentID = " + orderID;
                                OleDbDataAdapter dataAdapter5 = new OleDbDataAdapter(sqlStr5, connStr);
                                dataAdapter5.Fill(dt);

                                dt.Clear();
                                ///
                                string sqlStr6 = "Update Good SET totalWeight=" + newWeight +" where goodID = " + goodID;
                                MessageBox.Show(toCountry.ToString(), "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                OleDbDataAdapter dataAdapter6 = new OleDbDataAdapter(sqlStr6, connStr);
                                dataAdapter6.Fill(dt);

                                /* Email send , remind repayment */

                                MessageBox.Show("Update successful, Email is send to the customer", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }




                        }
                        else {

                            ///update weight

                            MessageBox.Show("Update successful, the price no need to change", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                    }
                    else
                    {
                        MessageBox.Show("Cannot found this cargo", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
                catch
                {

                }

            }

        }
    }
}
