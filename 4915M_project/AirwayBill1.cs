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
    public partial class AirwayBill1 : Form
    {
        
        LinkedList<Good> goodsList = new LinkedList<Good>();
        
        Object[] goodAarry = new object[9];
        String sCountry, sName, sAddress, sCompany, rCountry, areaCode, rAddress, rName, rCompany, length, width, height, weight, description, harmonizedCode, piece, numOfItem, type, cPerson, cPhone;

        int goodCounter = 0;
        int curOrderID;
        string date = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm");

        

        public AirwayBill1()
        {
            InitializeComponent();
            
        }

        private void btnAddGood_Click(object sender, EventArgs e)
        {
            addAnotherGood();
        }

        public void addAnotherGood()
        {

            length = txtLength.Text;
            width = txtWidth.Text;
            height = txtHeight.Text;
            weight = txtWeight.Text;
            description = txtDescription.Text;
            harmonizedCode = txtHarmonizedCode.Text;
            piece = txtPiece.Text;
            numOfItem = txtNumberOfItem.Text;
            type = txtType.Text;

            Good good = new Good(length, width, height, weight, description, harmonizedCode, piece, numOfItem, type);
            goodAarry[goodCounter] = good;
            Good tmp = new Good();
            tmp = (Good)goodAarry[goodCounter];

            txtLength.ResetText();
            txtWidth.ResetText();
            txtHeight.ResetText();
            txtWeight.ResetText();
            txtDescription.ResetText();
            txtHarmonizedCode.ResetText();
            txtType.ResetText();
            txtNumberOfItem.ResetText();
            txtPiece.ResetText();

            goodCounter++;
            lblCurrentGood.Text = "Current Goods Added : " + goodCounter;


        }

        
        private void createbtn_Click(object sender, EventArgs e)
        {
            //old useless code
        }



        private void btnGoNext_Click(object sender, EventArgs e)
        {
            int n;
            Boolean go = true;
            if (cboBoxSenderCountry.Text==""||
                txtSenderName.Text==""||txtSenderAddress.Text==""||cboBoxReceiverCountry.Text==""||
                txtAreaCode.Text==""||txtReceiverAddress.Text==""||txtReceiverName.Text==""||
                txtContactPerson.Text==""||txtContactPhone.Text=="")
            {
                go = false;
                MessageBox.Show("Please enter all field required", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else if (!(int.TryParse(txtContactPhone.Text, out n)) || txtContactPhone.Text.Length < 8)
            {
                go = false;
                MessageBox.Show(n + " is not allowed, ContactPhone must be number and length more or equals 8", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else if (cboBoxSenderCountry.Text=="Japen"||
                cboBoxSenderCountry.Text == "Hong Kong"||
                cboBoxSenderCountry.Text == "Australia"||
                cboBoxSenderCountry.Text == "Shanghai"||
                cboBoxSenderCountry.Text == "Toronto"||
                cboBoxSenderCountry.Text=="New York"||
                cboBoxSenderCountry.Text=="London")
            {
                go = true;
            } 
            else
            {
                go = false;
                MessageBox.Show("please select valid Country", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            if (go)
            {
                sCountry = this.cboBoxSenderCountry.SelectedItem.ToString();
                sName = txtSenderName.Text;
                sAddress = txtSenderAddress.Text;
                sCompany = txtSenderComanyName.Text;

                rCountry = this.cboBoxReceiverCountry.SelectedItem.ToString();
                areaCode = txtAreaCode.Text;
                rAddress = txtReceiverAddress.Text;
                rName = txtReceiverName.Text;
                rCompany = txtReceiverCompanyName.Text;

                cPerson = txtContactPerson.Text;
                cPhone = txtContactPhone.Text;

                Console.WriteLine("in airway bill " + CustomerLogin.currentCustomerID);
                AirwayBillPanelGood.Visible = true;
                lblCurrentGood.Text = "Current Goods Added : " + goodCounter;
            }

        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            AirwayBillPanelGood.Visible = false;
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            addShipmentOrderUsingConnection();
            addGoodToShipmentOrder();
        }

        public void addShipmentOrder()
        {
            DataTable dt = Program.DataTableVar;
            string connStr = Program.connStr;

            string sqlStr = "Insert into ShipmentOrder " +
                "(cusID, receiverAddress, receiverName, contactPerson, contactPhone, dateOfOrder, senderCountry, areaCode, orderStatus, dateOfPickUp, staffID, senderCompanyName, senderAddress, receiverCountry, rejectReason, currentLocation, receiverCompanyName, senderName) " +
                "values (" + CustomerLogin.currentCustomerID + ",'" + rAddress + "','" + rName + "','" + cPerson + "'," + cPhone + ",'" + date + "','" + sCountry + "','" + areaCode + "','" + "waitingVerify" + "','" + "" + "'," + 0 + ",'" + sCompany + "','" + sAddress + "','" + rCountry + "','" + "" + "','" + "" + "','" + rCompany + "','" + sName + "'" + ");";

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);
            dataAdapter = null;
            dt = null;

        }

        public void addShipmentOrderUsingConnection()
        {
            String CONNECTION_STRING = Program.connStr;
            using (OleDbConnection Connection = new OleDbConnection(CONNECTION_STRING))
            {
                Connection.Open();

                OleDbCommand Command = Connection.CreateCommand();
                Command.Connection = Connection;
                

                Command.CommandText = @"INSERT INTO ShipmentOrder 
                          (cusID, receiverAddress, receiverName, contactPerson, contactPhone, dateOfOrder, senderCountry, areaCode, orderStatus, dateOfPickUp, staffID, senderCompanyName, senderAddress, receiverCountry, rejectReason, currentLocation, receiverCompanyName, senderName) 
                          VALUES (@VcusID, @VreceiverAddress, @VreceiverName, @VcontactPerson, @VcontactPhone, @VdateOfOrder, @VsenderCountry, @VareaCode, @VorderStatus, @VdateOfPickUp, @VstaffID, @VsenderCompanyName, @VsenderAddress, @VreceiverCountry, @VrejectReason, @VcurrentLocation, @VreceiverCompanyName, @VsenderName)";

                Command.Parameters.AddRange(new OleDbParameter[]
                {
                    new OleDbParameter("@VcusID", CustomerLogin.currentCustomerID),
                    new OleDbParameter("@VreceiverAddress", rAddress),
                    new OleDbParameter("@VreceiverName", rName),
                    new OleDbParameter("@VcontactPerson", cPerson),
                    new OleDbParameter("@VcontactPhone", cPhone),
                    new OleDbParameter("@VdateOfOrder", date),
                    new OleDbParameter("@VsenderCountry", sCountry),
                    new OleDbParameter("@VareaCode", areaCode),
                    new OleDbParameter("@VorderStatus", "waitingVerify"),
                    new OleDbParameter("@VdateOfPickUp", ""),
                    new OleDbParameter("@VstaffID", '0'),
                    new OleDbParameter("@VsenderCompanyName", sCompany),
                    new OleDbParameter("@VsenderAddress", sAddress),
                    new OleDbParameter("@VreceiverCountry", rCountry),
                    new OleDbParameter("@VrejectReason", ""),
                    new OleDbParameter("@VcurrentLocation", ""),
                    new OleDbParameter("@VreceiverCompanyName", rCompany),
                    new OleDbParameter("@VsenderName", sName)
                });

                Command.ExecuteNonQuery();
                
                Command.Parameters.Clear();
                Command.CommandText = "SELECT @@IDENTITY";
                curOrderID = Convert.ToInt32(Command.ExecuteScalar());
                Console.WriteLine("curOrderID = " + curOrderID);
            }
        }

        public void addGoodToShipmentOrder()
        {
            DataTable dt = Program.DataTableVar;
            string connStr = Program.connStr;
            OleDbDataAdapter dataAdapter;
            string sqlStr;

            Good tmp = new Good();
            int i = 0;
            while (i < goodCounter)
            {
                tmp = (Good)goodAarry[i];
                Console.WriteLine(tmp.getLength() + tmp.getWidth());

                sqlStr = "INSERT INTO Good (orderID, description, totalWeight, length, width, height, type, harmonizedCode, numberOfItem, piece)" + 
                         "VALUES(" + "'" + curOrderID + "'," + "'" + tmp.getDescription() + "'," + "'" + tmp.getHeight() + "'," + "'" + tmp.getLength() + "'," + "'" + tmp.getWidth() + "'," + "'" + tmp.getHeight() + "'," + "'" + tmp.getType() + "'," + "'" + tmp.getHarmonizedCode() + "'," + "'" + tmp.getNumOfItem() + "'," + "'" + tmp.getPiece() + "'" + ");";
                dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
                dataAdapter.Fill(dt);
                i++;
            }

            
            dataAdapter = null;
            dt = null;
        }

        private void txtContactPhone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtWeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtPiece_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtNumberOfItem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txtLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void AirwayBill1_Load(object sender, EventArgs e)
        {
            txtSenderName.Text = CustomerLogin.currentCustomerName;
        }

        private void label13_Click_1(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void AirwayBillPanel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
