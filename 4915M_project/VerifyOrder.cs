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
    public partial class VerifyOrder : Form
    {
        public String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";

        public VerifyOrder()
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

        private void VerifyOrder_Load(object sender, EventArgs e)
        {
 

        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dt3 = StaffLogin.DataTableVar2;
                dt3.Clear();
                string connnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";
                string sqqlStr = "Update ShipmentOrder set orderStatus = 'waitingPayment', staffID = " + Main.staffID + " where orderID = " + Convert.ToInt32(txtID.Text) + "; ";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqqlStr, connnStr);
                dataAdapter.Fill(dt3);

                MessageBox.Show("Verify Successful", "Verify Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch {
                MessageBox.Show("Something Wrong", "Verify Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }




        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dataGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView.CurrentRow.Selected = true;
            try
            {
                String strOrderID = dataGridView.Rows[e.RowIndex].Cells["orderID"].Value.ToString();
                txtID.Text = strOrderID;
                int orderID = Convert.ToInt32(strOrderID);

                DataTable dt2 = new DataTable();
                string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";
                string strSqlStr = "select orderID,description,totalWeight,length,width,height,type,harmonizedCode,numberOfItem,piece,goodID  from Good where orderID = " + orderID +" ;";

                OleDbDataAdapter dataAdapter2= new OleDbDataAdapter(strSqlStr, connStr);
                dataAdapter2.Fill(dt2);

                dataGridView1.DataSource = dt2;
            }
            catch {
                MessageBox.Show("Don't press it indiscriminately", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }



        private void btnLoad_Click(object sender, EventArgs e)
        {
            DataTable dt = StaffLogin.DataTableVar2;
            dt.Clear();
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";
            string sqlStr = "select ShipmentOrder.orderID,cusID,receiverAddress,receiverName,contactPerson,contactPhone,senderCountry,areaCode,senderCompanyName,senderAddress,receiverCountry,rejectReason,receiverCompanyName,senderName,receiverEmail from ShipmentOrder where orderStatus = 'unVerify' ;";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);
            dataGridView.DataSource = dt;
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtReason.Text == "")
                {
                    MessageBox.Show("Need to give the reject reson, plaease input on the text box", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    DataTable dt4 = StaffLogin.DataTableVar2;
                    dt4.Clear();
                    string connnStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";
                    string sqqlStr = "Update ShipmentOrder set orderStatus = 'reject' , rejectReason = '"  + txtReason.Text + "' , staffID = " + Main.staffID + " where orderID = " + Convert.ToInt32(txtID.Text) + " ; ";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqqlStr, connnStr);
                    dataAdapter.Fill(dt4);

                    MessageBox.Show("Reject Suceessful", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }

            }
            catch
            {
                MessageBox.Show("Something Wrong", "Verify Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
