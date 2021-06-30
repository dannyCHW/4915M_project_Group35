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
using System.Net.Mail;
using System.Net;

namespace _4915M_project
{
    public partial class UpdateOrder : Form
    {
        public UpdateOrder()
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

        private void UpdateOrder_Load(object sender, EventArgs e)
        {
            comboStatus.SelectedIndex = 0;
            comboLocation.SelectedIndex = 0;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {


            try
            {
                int orderID = Convert.ToInt32(txtOrder.Text);
                DataTable dt = Program.DataTableVar;
                dt.Clear();
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";

                string sqlStr = "Select orderStatus,paymentStatus,cusID from ShipmentOrder,Payment where ShipmentOrder.orderID = Payment.paymentID and ShipmentOrder.orderID =" + orderID;

                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
                dataAdapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    String vStatus= dt.Rows[0]["orderStatus"].ToString();
                    String vPayStatus = dt.Rows[0]["paymentStatus"].ToString();
                    int cusID = Convert.ToInt32(dt.Rows[0]["cusID"]);
                    if (vStatus != "Completed")
                    {
                        if (comboStatus.Text.ToString() == "Payment" && !checkBox1.Checked && !checkBox2.Checked)
                        {
                            MessageBox.Show("Update order status cannot use payment", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        else if (checkBox1.Checked && vStatus == "Waiting Payment")
                        {
                            dt.Clear();
                            string strSqlStr = "Update ShipmentOrder set orderStatus = 'Waiting Booking' where orderID = " + orderID + ";";
                            string strSqlStr2 = "Update Payment set paymentStatus = 'paid' where paymentID = " + orderID + ";";
                            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, connStr);
                            dataAdapter2.Fill(dt);
                            dt.Clear();
                            OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(strSqlStr2, connStr);
                            dataAdapter3.Fill(dt);

                            MessageBox.Show("Cash payment Successful", "Sccessful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else if (checkBox2.Checked && vPayStatus == "extenal")
                        {// has change
                            dt.Clear();
                            string strSqlStr = "Update ShipmentOrder set orderStatus = 'Completed' where orderID = " + orderID + ";";
                            string strSqlStr2 = "Update Payment set paymentStatus = 'paid' where paymentID = " + orderID + ";";
                            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, connStr);
                            dataAdapter2.Fill(dt);
                            dt.Clear();
                            OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(strSqlStr2, connStr);
                            dataAdapter3.Fill(dt);

                            MessageBox.Show("Extenal payment successful", "Sccessful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (checkBox1.Checked && vPayStatus == "addition")
                        {
                            dt.Clear();
                            string strSqlStr7 = "Update ShipmentOrder set orderStatus = 'Processing' where orderID = " + orderID + ";";
                            string strSqlStr8 = "Update Payment set paymentStatus = 'paid' where paymentID = " + orderID + ";";
                            OleDbDataAdapter dataAdapter7 = new OleDbDataAdapter(strSqlStr7, connStr);
                            dataAdapter7.Fill(dt);
                            dt.Clear();
                            OleDbDataAdapter dataAdapter8 = new OleDbDataAdapter(strSqlStr8, connStr);
                            dataAdapter8.Fill(dt);

                            MessageBox.Show("Cash payment successful, addtion fee has been pay", "Sccessful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else if (comboStatus.Text.ToString() == "Completed" && !checkBox3.Checked)
                        {
                            MessageBox.Show("You need to confirm the checkbox", "Sccessful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else if (comboStatus.Text.ToString() == "Completed" && checkBox3.Checked)
                        {
                            dt.Clear();
                            string strSqlStr7 = "Update ShipmentOrder set orderStatus = '" + comboStatus.Text + "', currentLocation = '" + comboLocation.Text + "' where orderID = " + orderID;
                            OleDbDataAdapter dataAdapter7 = new OleDbDataAdapter(strSqlStr7, connStr);
                            dataAdapter7.Fill(dt);
                            MessageBox.Show("Update successful", "Sccessful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataAdapter7.Dispose();
                            dataAdapter.Dispose();
                            dt.Clear();
                            /* send email (has been sign) , if that not you , cal tell:xxxxxxxx */

                            //get recEmail
                            string strSqlStr11 = "select cusEmail from Customer where cusID = " + cusID.ToString();
                            OleDbDataAdapter dataAdapter11 = new OleDbDataAdapter(strSqlStr11, connStr);
                            dataAdapter11.Fill(dt);

                            String recEmail = dt.Rows[0]["cusEmail"].ToString();


                            sendEmail("ededelivery35@gmail.com", "sdpgroup35", recEmail, "Your package has been receiver", "Your package has been receive, orderID is " + orderID.ToString() + "\n \n If that not you, please contect the customer service tel: 95422996.");

                        }
                        else if (comboStatus.Text.ToString() == "Processing")
                        {
                            dt.Clear();
                            string strSqlStr12 = "Update ShipmentOrder set orderStatus = '" + comboStatus.Text + "', currentLocation = '" + comboLocation.Text + "' where orderID = " + orderID;
                            OleDbDataAdapter dataAdapter12 = new OleDbDataAdapter(strSqlStr12, Program.connStr);
                            dataAdapter12.Fill(dt);
                            MessageBox.Show("Update successful", "Sccessful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataAdapter12.Dispose();
                            dataAdapter.Dispose();
                            dt.Clear();
                        } 
                        else {
                            MessageBox.Show("This order cannot pay , please check the payment status and order status", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }


                    }
                    else {
                        dt.Clear();
                        dataAdapter.Dispose();
                        MessageBox.Show("This order cannot change", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }


                }
                else
                {
                    MessageBox.Show("Wrong OrderID", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You need to input orde ", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            MoreUpdate moreupdate = new MoreUpdate();
            moreupdate.Show();
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked && checkBox1.Checked) {
                checkBox1.Checked = false;
                MessageBox.Show("You cannot select more than one payment method", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }if (checkBox2.Checked || checkBox1.Checked) {
                label5.Visible = false;
                comboLocation.Visible = false;
            }
            if (!checkBox2.Checked && !checkBox1.Checked)
            {
                label5.Visible = true;
                comboLocation.Visible = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked && checkBox1.Checked)
            {
                checkBox2.Checked = false;

                MessageBox.Show("You cannot select more than one payment method", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (checkBox2.Checked || checkBox1.Checked)
            {
                label5.Visible = false;
                comboLocation.Visible = false;

            }
            if (!checkBox2.Checked && !checkBox1.Checked)
            {
                label5.Visible = true;
                comboLocation.Visible = true;

            }
        }

        private void comboStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboStatus.Text.ToString() != "Processing")
            {
                checkBox2.Visible = false;
                checkBox1.Visible = false;
                comboLocation.Visible = true;
                label5.Visible = true;
            }
            if (comboStatus.Text.ToString() != "Payment") {
                checkBox2.Visible = false;
                checkBox1.Visible = false;
            }
            if (comboStatus.Text.ToString() == "Completed")
            {
                checkBox1.Visible = false;
                checkBox2.Visible = false;
                checkBox3.Visible = true;
            }
            else if (comboStatus.Text.ToString() == "Payment") {
                checkBox1.Visible = true;
                checkBox2.Visible = true;
                checkBox3.Visible = false;
                label5.Visible = false;
                comboLocation.Visible = false;
            }
            else {
                checkBox3.Visible = false;
            }
        }
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
    }
}
