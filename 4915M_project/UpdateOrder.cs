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
            StaffLobby stafflobby = new StaffLobby();
            stafflobby.Show();
            this.Hide();
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

            string sqlStr = "Select orderStatus from ShipmentOrder where orderID = " + orderID;

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);

            try
            {

                if (dt.Rows.Count > 0)
                {
                    String vStatus= dt.Rows[0]["orderStatus"].ToString();
                    if (vStatus != "completed")
                    {
                        dt.Clear();
                        string strSqlStr = "Update ShipmentOrder set orderStatus = '" + comboStatus.Text + "', currentLocation = '" + comboLocation.Text + "' where orderID = " + orderID;
                        OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, connStr);
                        dataAdapter2.Fill(dt);
                        MessageBox.Show("Update Successful", "Sccessful Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataAdapter2.Dispose();
                        dataAdapter.Dispose();
                        dt.Clear();


                    }
                    else {
                        dt.Clear();
                        dataAdapter.Dispose();
                        MessageBox.Show("This order cannot change", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }


                }
                else
                {
                    MessageBox.Show("Wrong OrderID", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something Wrong", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
