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
        String sCountry, sName, sAddress, sCompany, rEmail, rCountry, areaCode, rAddress, rName, rCompany, length, width, height, weight, description, harmonizedCode, piece, numOfItem, type, cPerson, cPhone;

        int goodCounter = 0;
        int curOrderID;
        double payPrice;
        string date = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm");

        

        public AirwayBill1()
        {
            InitializeComponent();
            
        }

        private void btnAddGood_Click(object sender, EventArgs e)
        {
            if (txtLength.Text == "" || txtHeight.Text == "" || txtHarmonizedCode.Text == "" || 
                txtNumberOfItem.Text == "" || txtPiece.Text == "" || txtWeight.Text == "" || txtWidth.Text == ""||
                rdoTypeDoc.Checked==false&&rdoTypePackage.Checked==false) 
            {
                MessageBox.Show("Please enter all field required", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else if (rdoTypePackage.Checked==true && Convert.ToDouble(txtWeight.Text) > 999)
            {
                MessageBox.Show("The max weight of package is 999", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else if (rdoTypeDoc.Checked == true && Convert.ToDouble(txtLength.Text) > 25 || Convert.ToInt32(txtWidth.Text) > 35)
            {
                MessageBox.Show("Size of EDE Express Document Envelope: 25cm(L) x 35cm(W)", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (rdoTypeDoc.Checked == true && Convert.ToDouble(txtWeight.Text) > 3)
            {
                string message = "Please notice that document weight over 3kg will be delivered through Express Freight, \nDo you want to submit?";
                string caption = "Warning";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                if (result == System.Windows.Forms.DialogResult.Yes)
                {
                    addAnotherGood();
                }
            } else
            {
                addAnotherGood();
            }

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

            if (rdoTypeDoc.Checked == true && Convert.ToDouble(txtWeight.Text) > 3)
            {
                type = rdoTypePackage.Text;
            } 
            else
            {
                if (rdoTypeDoc.Checked == true)
                {
                    type = rdoTypeDoc.Text;
                }
                else if (rdoTypePackage.Checked == true)
                {
                    type = rdoTypePackage.Text;
                }
            }
            

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
            rdoTypePackage.Checked = false;
            rdoTypeDoc.Checked = false;
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
            Boolean go;
            if (txtSenderName.Text==""||txtSenderAddress.Text==""||cboBoxReceiverCountry.Text==""||
                txtAreaCode.Text==""||txtReceiverAddress.Text==""||txtReceiverName.Text==""||
                txtContactPerson.Text==""||txtContactPhone.Text==""|| String.IsNullOrEmpty(txtReceiverEmail.Text.ToString()) )
            {
                go = false;
                MessageBox.Show("Please enter all field required", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else if (!(int.TryParse(txtContactPhone.Text, out n)) || txtContactPhone.Text.Length < 8)
            {
                go = false;
                MessageBox.Show(n + " is not allowed, ContactPhone must be number and length more or equals 8", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else
            {
                go = true;
            }

            if (go)
            {
                sCountry = this.txtSenderCountry.Text;
                sName = txtSenderName.Text;
                sAddress = txtSenderAddress.Text;
                sCompany = txtSenderComanyName.Text;

                rCountry = this.cboBoxReceiverCountry.SelectedItem.ToString();
                areaCode = txtAreaCode.Text;
                rAddress = txtReceiverAddress.Text;
                rName = txtReceiverName.Text;
                rCompany = txtReceiverCompanyName.Text;
                rEmail = txtReceiverEmail.Text;

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
            txtLength.ResetText();
            txtWidth.ResetText();
            txtHeight.ResetText();
            txtWeight.ResetText();
            txtDescription.ResetText();
            txtHarmonizedCode.ResetText();
            rdoTypePackage.Checked = false;
            rdoTypeDoc.Checked = false;
            txtNumberOfItem.ResetText();
            txtPiece.ResetText();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (goodCounter <= 0)
            {
                MessageBox.Show("There are not goods added.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else
            {
                addShipmentOrderUsingConnection();
                addGoodToShipmentOrder();
                addPayment();
                MessageBox.Show("Your shipment order has been submited.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            
        }

        public void addShipmentOrder()
        {
            DataTable dt = Program.DataTableVar;
            string connStr = Program.connStr;

            string sqlStr = "Insert into ShipmentOrder " +
                "(cusID, receiverAddress, receiverName, contactPerson, contactPhone, dateOfOrder, senderCountry, areaCode, orderStatus, dateOfPickUp, staffID, senderCompanyName, senderAddress, receiverCountry, rejectReason, currentLocation, receiverCompanyName, senderName) " +
                "values (" + CustomerLogin.currentCustomerID + ",'" + rAddress + "','" + rName + "','" + cPerson + "'," + cPhone + ",'" + date + "','" + sCountry + "','" + areaCode + "','" + "Unverify" + "','" + "" + "'," + 0 + ",'" + sCompany + "','" + sAddress + "','" + rCountry + "','" + "" + "','" + "" + "','" + rCompany + "','" + sName + "'" + ");";

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
                          (cusID, receiverAddress, receiverName, contactPerson, contactPhone, dateOfOrder, senderCountry, areaCode, orderStatus, dateOfPickUp, staffID, senderCompanyName, senderAddress, receiverCountry, rejectReason, currentLocation, receiverCompanyName, senderName, receiverEmail) 
                          VALUES (@VcusID, @VreceiverAddress, @VreceiverName, @VcontactPerson, @VcontactPhone, @VdateOfOrder, @VsenderCountry, @VareaCode, @VorderStatus, @VdateOfPickUp, @VstaffID, @VsenderCompanyName, @VsenderAddress, @VreceiverCountry, @VrejectReason, @VcurrentLocation, @VreceiverCompanyName, @VsenderName, @VreceiverEmail)";

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
                    new OleDbParameter("@VorderStatus", "Unverify"),
                    new OleDbParameter("@VdateOfPickUp", ""),
                    new OleDbParameter("@VstaffID", '0'),
                    new OleDbParameter("@VsenderCompanyName", sCompany),
                    new OleDbParameter("@VsenderAddress", sAddress),
                    new OleDbParameter("@VreceiverCountry", rCountry),
                    new OleDbParameter("@VrejectReason", ""),
                    new OleDbParameter("@VcurrentLocation", ""),
                    new OleDbParameter("@VreceiverCompanyName", rCompany),
                    new OleDbParameter("@VsenderName", sName),
                    new OleDbParameter("@VreceiverEmail", rEmail)
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
            double money = 0;
            
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

                if (tmp.getType().ToString().Equals("Document"))
                {
                    double kg = Convert.ToDouble(tmp.getWeight());
                    //Console.WriteLine(kg);
                    if(kg > 0.5)
                    {
                        while (kg > 0.5)
                        {
                            money = money + 150;
                            kg = kg - 0.5;
                        }
                    }
                    money = money + 158;
                    
                } 
                else if (tmp.getType().ToString().Equals("Package"))
                {
                    double kg = Convert.ToDouble(tmp.getWeight());
                    if (kg >= 3 && kg <= 15)
                    {
                        if (rCountry.Equals("Australia") || rCountry.Equals("Japan"))
                        {
                            money = money + (kg * 75);
                        } 
                        else
                        {
                            money = money + (kg * 45);
                        }
                    } 
                    else if (kg >= 16 && kg <= 29)
                    {
                        if (rCountry.Equals("Australia") || rCountry.Equals("Japan"))
                        {
                            money = money + (kg * 70);
                        }
                        else
                        {
                            money = money + (kg * 40);
                        }
                    }
                    else if (kg >= 30 && kg <= 44)
                    {
                        if (rCountry.Equals("Australia") || rCountry.Equals("Japan"))
                        {
                            money = money + (kg * 65);
                        }
                        else
                        {
                            money = money + (kg * 37);
                        }
                    }
                    else if (kg >= 45 && kg <= 69)
                    {
                        if (rCountry.Equals("Australia") || rCountry.Equals("Japan"))
                        {
                            money = money + (kg * 62);
                        }
                        else
                        {
                            money = money + (kg * 35);
                        }
                    }
                    else if (kg >= 70 && kg <= 99)
                    {
                        if (rCountry.Equals("Australia") || rCountry.Equals("Japan"))
                        {
                            money = money + (kg * 61);
                        }
                        else
                        {
                            money = money + (kg * 33);
                        }
                    }
                    else if (kg >= 100 && kg <= 999)
                    {
                        if (rCountry.Equals("Australia") || rCountry.Equals("Japan"))
                        {
                            money = money + (kg * 58);
                        }
                        else
                        {
                            money = money + (kg * 32);
                        }
                    }
                }
                
                i++;
            }
            payPrice = payPrice + money;
            money = 0;
            dataAdapter = null;
            dt = null;
        }

        public void addPayment()
        {
            DataTable dt = Program.DataTableVar;
            string connStr = Program.connStr;

            string sqlStr = "Insert into Payment " +
                "(paymentID, price, paymentStatus)" +
                "values (" + "'" + curOrderID + "'," + "'" + payPrice + "'," + "'unPaid'" + ");";

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);
            payPrice = 0;
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
            cboBoxReceiverCountry.DropDownStyle = ComboBoxStyle.DropDownList;
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
