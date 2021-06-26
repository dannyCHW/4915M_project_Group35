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
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
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
                        string sqlStr2 = "Select receiverCountry,cusID from ShipmentOrder where orderID = " + orderID;
                        OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(sqlStr2, connStr);
                        dataAdapter2.Fill(dt);

                        int cusID = Convert.ToInt32(dt.Rows[0]["cusID"]);
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

                            if (paymentStatus.Equals("extenal") || paymentStatus.Equals("Monthly"))
                            {





                                dt.Clear();
                                string sqlStr4 = "Update Payment price=" + newestPrice + ",additionPrice = " + newPirce + "  where paymentID = " + orderID;
                                OleDbDataAdapter dataAdapter4 = new OleDbDataAdapter(sqlStr4, connStr);
                                dataAdapter4.Fill(dt);

                                dt.Clear();
                                string sqlStr9 = "Select cusEmail fron Customer where cusID = " + cusID;
                                OleDbDataAdapter dataAdapter9 = new OleDbDataAdapter(sqlStr9, connStr);
                                dataAdapter9.Fill(dt);
                                String recEmail = dt.Rows[0]["cusEmail"].ToString();




                                sendEmail("ededelivery35@gmail.com", "sdpgroup35", recEmail, "The price has been change", "We find out the weight is no match, we update the weight of the goods in order " + orderID.ToString() +" please check the update price." );
                                /* Email send to increate price*/

                                MessageBox.Show("Update successful, Email is send to the customer", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                            else if (paymentStatus.Equals("paid") || paymentStatus.Equals("addition"))
                            {

                                dt.Clear();
                                ///
                                string sqlStr5 = "Update ShipmentOrder SET orderStatus='Addition' where orderID = " + orderID;
                                OleDbDataAdapter dataAdapter5 = new OleDbDataAdapter(sqlStr5, connStr);
                                dataAdapter5.Fill(dt);

                                dt.Clear();
                                ///
                                string sqlStr6 = "Update Good SET totalWeight=" + newWeight + " where goodID = " + goodID;
                                OleDbDataAdapter dataAdapter6 = new OleDbDataAdapter(sqlStr6, connStr);
                                dataAdapter6.Fill(dt);

                                string sqlStr7 = "Update Payment SET paymentStatus='addition' where orderID = " + orderID;
                                OleDbDataAdapter dataAdapter7 = new OleDbDataAdapter(sqlStr7, connStr);
                                dataAdapter7.Fill(dt);

                                dt.Clear();
                                string sqlStr10 = "Select cusEmail fron Customer where cusID = " + cusID;
                                OleDbDataAdapter dataAdapter10 = new OleDbDataAdapter(sqlStr10, connStr);
                                dataAdapter10.Fill(dt);
                                String recEmail = dt.Rows[0]["cusEmail"].ToString();




                                sendEmail("ededelivery35@gmail.com", "sdpgroup35", recEmail, "The price has been change, please pay again for the order", "We find out the weight is no match, we update the weight of the goods in order " + orderID.ToString() + " please check the update price and pay again for the order.");

                                MessageBox.Show("Update successful, Email is send to the customer", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }




                        }
                        else
                        {

                            ///update weight
                            string sqlStr11 = "Update Good SET totalWeight=" + newWeight + " where goodID = " + goodID;
                            OleDbDataAdapter dataAdapter11 = new OleDbDataAdapter(sqlStr11, connStr);
                            dataAdapter11.Fill(dt);

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
                    MessageBox.Show("Something wrong", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }

        }    
        //用法: sendEmail("ededelivery35@gmail.com", "sdpgroup35", "receiver@gmail.com", "Subject of the email", "Message of the email.");
        public void sendEmail(String senderEmail, String senderPassword, String receiverEmail, String sbj, String message)
        {
            MailMessage msg = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            msg.From = new MailAddress(senderEmail);
            msg.To.Add(new MailAddress(receiverEmail));
            msg.Subject = sbj;
            msg.IsBodyHtml = true;
            msg.Body = message;
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(senderEmail, senderPassword);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                smtp.Send(msg);
                MessageBox.Show("Sended", "Goods Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void problem_Load(object sender, EventArgs e)
        {

        }
    }
}

