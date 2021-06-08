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
    public partial class MoreUpdate : Form
    {
        public MoreUpdate()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            UpdateOrder update = new UpdateOrder();
            update.Show();
            this.Close();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            DataTable dtSearch = StaffLogin.DataTableVar2;
            String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";

            dtSearch.Clear();

            String strOrderID = txtOrder.Text;
            int orderID = Convert.ToInt32(strOrderID);
            string sqlStr = "select ShipmentOrder.orderID,cusID,receiverAddress,receiverName,contactPerson,contactPhone,senderCountry,areaCode,senderCompanyName,senderAddress,receiverCountry,rejectReason,receiverCompanyName,senderName,receiverEmail from ShipmentOrder where orderID = " + orderID + " ;";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dtSearch);

            try
            {

                if (dtSearch.Rows.Count > 0)
                {

                    view.DataSource = dtSearch;

                }
                else
                {
                    MessageBox.Show("Cannot found this order", "Fail Search", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Something Wrong", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtInput_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            DataTable dtUpdate = StaffLogin.DataTableVar2;
            dtUpdate.Clear();
            String connStr2 = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";
            try
            {
                if (comboColumn.Text == "(column)")
                {
                    MessageBox.Show("You need to input something", "Fail Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (comboColumn.Text != "contactPhone")
                {
                    try
                    {
                        string strSqlStr = "Update ShipmentOrder set " + comboColumn.Text + " = '" + txtInput.Text + "' where orderID = " + Convert.ToInt32(txtOrder.Text) + ";";
                        OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, connStr2);
                        dataAdapter2.Fill(dtUpdate);
                        MessageBox.Show("Update Successful", "Fail Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnSearch_Click(sender, e);
                    }
                    catch
                    {
                        MessageBox.Show("Something Wrong , maybe you input a wrong order number , please check that before you chagne", "Fail Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else if (comboColumn.Text == "contactPhone")
                {
                    try
                    {
                        int intOrderID = Convert.ToInt32(intInput.Text);
                        string strSqlStr2 = "Update ShipmentOrder set contactPhone = " + intOrderID + " where orderID = " + Convert.ToInt32(txtOrder.Text) + " ;";
                        OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr2, connStr2);
                        dataAdapter2.Fill(dtUpdate);
                        MessageBox.Show("Update Successful", "Fail Update", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch {
                        MessageBox.Show("You may input a wrong value", "Fail Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch {
                MessageBox.Show("Something Wrong , maybe you input a wrong order number , please check that before you chagne", "Fail Update", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void comboColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            intInput.Visible = false;
            txtInput.Visible = false;
            if (comboColumn.Text == "contactPhone")
            {
                intInput.Visible = true;
            }
            else {
                txtInput.Visible = true;
            }
        }

        private void MoreUpdate_Load(object sender, EventArgs e)
        {

        }

        private void intInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void view_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            view.CurrentRow.Selected = true;
            try
            {
            }
            catch
            {
                MessageBox.Show("Don't press it indiscriminately", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void intInput_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtInput_Click(object sender, EventArgs e)
        {
            if (txtInput.Text == "(Input here)")
            {
                txtInput.Text = "";
            }
        }

        private void intInput_Click(object sender, EventArgs e)
        {
            if (intInput.Text == "(Input here)")
            {
                intInput.Text = "";
            }
        }
    }
}
