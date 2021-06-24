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
            int orderID = Convert.ToInt32(txtOrder.Text);
            DataTable dt = Program.DataTableVar;
            dt.Clear();
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";

            string sqlStr = "Select orderStatus,paymentStatus from ShipmentOrder,Payment where ShipmentOrder.orderID = Payment.paymentID and ShipmentOrder.orderID =" + orderID;

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);

            try
            {

                if (dt.Rows.Count > 0)
                {
                    String vStatus= dt.Rows[0]["orderStatus"].ToString();
                    String vPayStatus = dt.Rows[0]["paymentStatus"].ToString();
                    if (vStatus != "Completed")
                    {
                        if (checkBox1.Checked && vStatus == "Waiting Payment") {
                            dt.Clear();
                            string strSqlStr = "Update ShipmentOrder set orderStatus = 'Waiting Booking' where orderID = " + orderID + ";";
                            string strSqlStr2 = "Update Payment set paymentStatus = 'paid' where paymentID = " + orderID + ";";
                            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, connStr);
                            dataAdapter2.Fill(dt);
                            dt.Clear();
                            OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(strSqlStr2, connStr);
                            dataAdapter3.Fill(dt);

                            MessageBox.Show("Cash Payment Successful", "Sccessful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        } else if (checkBox2.Checked|| vPayStatus== "extenal") {
                            dt.Clear();
                            string strSqlStr = "Update ShipmentOrder set orderStatus = 'Waiting Booking' where orderID = " + orderID + ";";
                            string strSqlStr2 = "Update Payment set paymentStatus = 'paid' where paymentID = " + orderID + ";";
                            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, connStr);
                            dataAdapter2.Fill(dt);
                            dt.Clear();
                            OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(strSqlStr2, connStr);
                            dataAdapter3.Fill(dt);

                            MessageBox.Show("Cash Payment Successful", "Sccessful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else {
                            dt.Clear();
                            string strSqlStr = "Update ShipmentOrder set orderStatus = '" + comboStatus.Text + "', currentLocation = '" + comboLocation.Text + "' where orderID = " + orderID;
                            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, connStr);
                            dataAdapter2.Fill(dt);
                            MessageBox.Show("Update Successful", "Sccessful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            dataAdapter2.Dispose();
                            dataAdapter.Dispose();
                            dt.Clear();
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
                MessageBox.Show("Something Wrong, may be wrong payment method", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
                MessageBox.Show("You cannot select more than one check box", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }if (checkBox2.Checked || checkBox1.Checked) {
                label5.Visible = false;
                comboLocation.Visible = false;
                comboStatus.Visible = false;
                label4.Visible = false;
            }
            if (!checkBox2.Checked && !checkBox1.Checked)
            {
                label5.Visible = true;
                comboLocation.Visible = true;
                comboStatus.Visible = true;
                label4.Visible = true;
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked && checkBox1.Checked)
            {
                checkBox2.Checked = false;

                MessageBox.Show("You cannot select more than one check box", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            if (checkBox2.Checked || checkBox1.Checked)
            {
                label5.Visible = false;
                comboLocation.Visible = false;
                comboStatus.Visible = false;
                label4.Visible = false;
            }
            if (!checkBox2.Checked && !checkBox1.Checked)
            {
                label5.Visible = true;
                comboLocation.Visible = true;
                comboStatus.Visible = true;
                label4.Visible = true;
            }
        }
    }
}
