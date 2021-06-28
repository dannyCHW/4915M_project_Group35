using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;

namespace _4915M_project
{
    public partial class viewAirwayBill : Form
    {

        String orderNumber = "";
        String sName, sAddress, sCompany, rCountry, areaCode, rAddress, rName, rCompany, cPerson, cPhone, price;

        private void viewAirwayBill_Load(object sender, EventArgs e)
        {
            getRecord();
        }

        Boolean selected = false;

        public viewAirwayBill()
        {
            InitializeComponent();
        }

        private void AirwayBillPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void getAirwaybill()
        {

        }

        public void getRecord()
        {
            DataTable dt = Program.DataTableVar;
            string connStr = Program.connStr;

            string sqlStr = "SELECT orderID FROM ShipmentOrder WHERE cusID = " + CustomerLogin.currentCustomerID + " AND " + "orderStatus LIKE" + "'Completed'" + ";";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
                comboViewAirwaybill.Items.Clear();
                comboViewAirwaybill.Items.Add(dr["orderID"].ToString());
            }

            dt = null;
            dataAdapter.Dispose();
        }

        public void displayDetailRecord()
        {

            string connStr = Program.connStr;
            string sqlStr;

            if (orderNumber == "")
            {
                MessageBox.Show("You don't have completed shipment order.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                DataTable dt = new DataTable();
                sqlStr = "SELECT * FROM ShipmentOrder WHERE orderID = " + orderNumber + ";";
                Console.WriteLine(orderNumber);
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
                dataAdapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    sName = dt.Rows[0]["senderName"].ToString();
                    cPerson = dt.Rows[0]["contactPerson"].ToString();
                    cPhone = dt.Rows[0]["contactPhone"].ToString();
                    sAddress = dt.Rows[0]["senderAddress"].ToString();
                    sCompany = dt.Rows[0]["senderCompanyName"].ToString();

                    rCountry = dt.Rows[0]["receiverCountry"].ToString();
                    areaCode = dt.Rows[0]["areaCode"].ToString();
                    rCompany = dt.Rows[0]["receiverCompanyName"].ToString();
                    rName = dt.Rows[0]["receiverName"].ToString();
                    rAddress = dt.Rows[0]["receiverAddress"].ToString();
                }
                else
                {
                    MessageBox.Show("Datatable Row no thing ar, check 1 check la ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


                dt = null;
                sqlStr = null;
                dataAdapter.Dispose();

                dt = new DataTable();
                dt.Clear();
                string strSqlStr = "select * from Good where orderID = " + orderNumber + " ;";

                OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, Program.connStr);
                dataAdapter2.Fill(dt);

                dgvGoods.DataSource = dt;

            }

            txtSenderName.Text = sName;
            txtContactPerson.Text = cPerson;
            txtContactPhone.Text = cPhone;
            txtSenderAddress.Text = sAddress;
            txtSenderComanyName.Text = sCompany;
            txtReCountry.Text = rCountry;

            txtAreaCode.Text = areaCode;
            txtReCompanyName.Text = rCompany;
            txtReceiverName.Text = rName;
            txtReAddress.Text = rAddress;

        }

        private void comboViewAirwaybill_SelectedIndexChanged(object sender, EventArgs e)
        {
            orderNumber = comboViewAirwaybill.SelectedItem.ToString();
            selected = true;
            displayDetailRecord();
        }
    }
}
