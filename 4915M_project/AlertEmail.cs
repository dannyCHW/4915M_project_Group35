using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Data.OleDb;

namespace _4915M_project
{
    public partial class AlertEmail : Form
    {

        NetworkCredential login;
        SmtpClient client;
        MailMessage msg;

        public AlertEmail()
        {
            InitializeComponent();
        }

        private void AlertEmail_Load(object sender, EventArgs e)
        {
            displayRecord();
        }

        public DataTable getRecords()
        {
            DataTable dt = Program.DataTableVar;
            String connStr = Program.connStr;
            string sqlStr = "SELECT * FROM ShipmentOrder WHERE orderStatus LIKE 'processing';";
            dt.Clear();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);
            return dt;
        }

        public void displayRecord()
        {
            DataTable dt = getRecords();
            ListViewItem item;

            foreach (DataRow dr in dt.Rows)
            {
                item = new ListViewItem(dr["orderID"].ToString());
                item.SubItems.Add(dr["receiverEmail"].ToString());
                item.SubItems.Add(dr["orderStatus"].ToString());
                item.SubItems.Add(dr["dateOfPickUp"].ToString());
                item.SubItems.Add(dr["currentLocation"].ToString());
                lvDisplayShipmentOrder.Items.Add(item);
            }
        }

        public void sendEmail(String id)
        {

            DataTable dt = Program.DataTableVar;
            String connStr = Program.connStr;
            string sqlStr = "SELECT receiverEmail FROM ShipmentOrder WHERE orderID = " + id + ";";
            dt.Clear();
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);

            String to;
            to = dt.Rows[0]["receiverEmail"].ToString();

            String from = txtUsername.Text;
            String pass = txtPassword.Text;

            MailMessage message = new MailMessage();
            SmtpClient smtp = new SmtpClient();
            message.From = new MailAddress(from);
            message.To.Add(new MailAddress(to));
            message.Subject = "Your package is coming.";
            message.IsBodyHtml = true; 
            message.Body = "Your package will be delivery to you in a short time. ";
            smtp.Port = 587;
            smtp.Host = "smtp.gmail.com";   
            smtp.EnableSsl = true;
            smtp.UseDefaultCredentials = false;
            smtp.Credentials = new NetworkCredential(from, pass);
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;

            try
            {
                smtp.Send(message);
                MessageBox.Show("Sended", "Goods Alert", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
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

        

        

        

        private void btnSendEmail_Click(object sender, EventArgs e)
        {
            try
            {
                if (lvDisplayShipmentOrder.SelectedItems.Count > 0)
                {
                    label1.Text = lvDisplayShipmentOrder.SelectedItems[0].SubItems[0].Text;
                    sendEmail(lvDisplayShipmentOrder.SelectedItems[0].SubItems[0].Text);

                }
                else
                {
                    MessageBox.Show("No selection. ", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }

            }
            catch (ArgumentOutOfRangeException ex)
            {
                Console.WriteLine(ex);
            }
        }
 
    }
}
