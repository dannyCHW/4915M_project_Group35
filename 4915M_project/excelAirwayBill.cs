using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;
using System.Data.OleDb;

namespace _4915M_project
{
    public partial class excelAirwayBill : Form
    {
        String[,] shipmentArr = null;
        String[,] goodsArr = null;
        public excelAirwayBill()
        {
            InitializeComponent();
        }

        private void btnGetfile_Click(object sender, EventArgs e)
        {


            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse & import Airway Bill Excel Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "Excel",
                Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb;*.xltx;*.xltm;*.xls;*.xlt;*.xls;*.xml;*.xml;*.xlam;*.xla;*.xlw;*.xlr| All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                //MessageBox.Show("Import Files: " + openFileDialog1.FileName, "Information");

                dgvShipment.Rows.Clear();
                dgvShipment.Refresh();

                dgvGoods.Rows.Clear();
                dgvGoods.Refresh();

                Excel.Application excel_eAB = new Excel.Application();
                Excel.Workbooks workbooks = excel_eAB.Workbooks;
                var excel_WB = workbooks.Open(openFileDialog1.FileName);
                Excel.Worksheet excel_WS_shipment;
                Excel.Worksheet excel_WS_good;
                excel_WS_shipment = excel_WB.Worksheets[1];
                excel_WS_good = excel_WB.Worksheets[2];

                int shipment_UsedRow = 0;
                int shipment_UsedColumn = 0;

                int good_UsedRow = 0;
                int good_UsedColumn = 0;

                try
                {

                    shipment_UsedRow = excel_WS_shipment.Cells.Find("*", System.Reflection.Missing.Value,
                           System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                           Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious,
                           false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;

                    shipment_UsedColumn = excel_WS_shipment.Cells.Find("*", System.Reflection.Missing.Value,
                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                               Excel.XlSearchOrder.xlByColumns, Excel.XlSearchDirection.xlPrevious,
                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;

                    good_UsedRow = excel_WS_good.Cells.Find("*", System.Reflection.Missing.Value,
                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                               Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious,
                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;

                    good_UsedColumn = excel_WS_good.Cells.Find("*", System.Reflection.Missing.Value,
                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                               Excel.XlSearchOrder.xlByColumns, Excel.XlSearchDirection.xlPrevious,
                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;

                    

                    if (shipment_UsedRow <= 1 || good_UsedRow <= 1)
                    {
                        MessageBox.Show("If you are using the format porvided, the file have no data.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else if (shipment_UsedColumn < 12 || good_UsedColumn < 10)
                    {
                        MessageBox.Show("You must follow the format provided", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        Boolean isformat = true;

                        for (int col = 1; col <= 12; col++)
                        {  
                            Object tmp = (excel_WS_shipment.Cells[1, col]).Value;
                            if (col == 1 && tmp.ToString() != "orderID(each shipment use one ID)"
                                || col == 2 && tmp.ToString() != "receiverAddress"
                                || col == 3 && tmp.ToString() != "receiverName"
                                || col == 4 && tmp.ToString() != "receiverEmail"
                                || col == 5 && tmp.ToString() != "receiverCountry"
                                || col == 6 && tmp.ToString() != "receiverCompanyName"
                                || col == 7 && tmp.ToString() != "areaCode"
                                || col == 8 && tmp.ToString() != "senderName"
                                || col == 9 && tmp.ToString() != "senderAddress"
                                || col == 10 && tmp.ToString() != "senderCompanyName"
                                || col == 11 && tmp.ToString() != "contactPerson"
                                || col == 12 && tmp.ToString() != "contactPhone")
                            {
                                isformat = false;
                            }
                        }

                        for (int col = 1; col <= 10; col++)
                        {
                            Object tmp = (excel_WS_good.Cells[1, col]).Value;
                            if (col == 1 && tmp.ToString() != "orderID(The goods belongs to which order)"
                                || col == 2 && tmp.ToString() != "type(Document/Package)"
                                || col == 3 && tmp.ToString() != "description"
                                || col == 4 && tmp.ToString() != "totalWeight"
                                || col == 5 && tmp.ToString() != "length"
                                || col == 6 && tmp.ToString() != "width"
                                || col == 7 && tmp.ToString() != "height"
                                || col == 8 && tmp.ToString() != "harmonizedCode"
                                || col == 9 && tmp.ToString() != "numberOfItem"
                                || col == 10 && tmp.ToString() != "piece")
                            {
                                isformat = false;
                            }
                        }

                        String[,] shipmentArray = new String[shipment_UsedRow - 1, 12];
                        String[,] goodArray = new String[good_UsedRow - 1, 10];

                        if (isformat)
                        {
                            for (int row = 2; row <= shipment_UsedRow; row++)
                            {
                                for (int col = 1; col <= 12; col++)
                                {
                                    Object tmp = (excel_WS_shipment.Cells[row, col]).Value;
                                    shipmentArray[row - 2, col - 1] = tmp.ToString();
                                }
                            }

                            for (int row = 2; row <= good_UsedRow; row++)
                            {
                                for (int col = 1; col <= 10; col++)
                                {
                                    Object tmp = (excel_WS_good.Cells[row, col]).Value;
                                    if(col == 2 && tmp.ToString() != "Document" && tmp.ToString() != "Package")
                                    {
                                        throw new Exception();
                                    }
                                    goodArray[row - 2, col - 1] = tmp.ToString();
                                }
                            }

                            for (int row = 0; row < shipmentArray.GetLength(0); row++)
                            {
                                String[] cell = new String[12];
                                for(int col = 0; col < 12; col++)
                                {
                                    cell[col] = shipmentArray[row, col];
                                }
                                dgvShipment.Rows.Add(cell);
                            }

                            for (int row = 0; row < goodArray.GetLength(0); row++)
                            {
                                String[] cell = new String[10];
                                for (int col = 0; col < 10; col++)
                                {
                                    cell[col] = goodArray[row, col];
                                }
                                dgvGoods.Rows.Add(cell);
                            }

                            shipmentArr = shipmentArray;
                            goodsArr = goodArray;

                            lblFileName.Text = openFileDialog1.FileName + " Imported.";

                        }
                        else
                        {
                            MessageBox.Show("You must follow the format provided", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }


                    }


                }
                catch (ArgumentOutOfRangeException ex)
                {
                    MessageBox.Show(ex.Message, "Message");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nplease be informed that the format provided must be followed in order to import.", "Message");
                }
                finally
                {

                    if (excel_WB != null)
                    {
                        excel_WB.Close(false, null, null);
                        excel_WB = null;
                    }

                    if (excel_eAB != null)
                    {
                        excel_eAB.Quit();
                    }
                    GC.Collect();
                    System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");
                    foreach (var item in excelProcess)
                    {
                        item.Kill();
                    }

                }


            }
        }

        private void excelAirwayBill_Load(object sender, EventArgs e)
        {
            //set up the dgv
            dgvShipment.ColumnCount = 13;
            dgvShipment.Columns[0].Name = "OrderID(You assign)";
            dgvShipment.Columns[1].Name = "receiverAddress";
            dgvShipment.Columns[2].Name = "receiverName";
            dgvShipment.Columns[3].Name = "receiverEmail";
            dgvShipment.Columns[4].Name = "receiverCountry";
            dgvShipment.Columns[5].Name = "receiverCompanyName";
            dgvShipment.Columns[6].Name = "areaCode";
            dgvShipment.Columns[7].Name = "senderName";
            dgvShipment.Columns[8].Name = "senderAddress";
            dgvShipment.Columns[9].Name = "senderCompanyName";
            dgvShipment.Columns[10].Name = "contactPerson";
            dgvShipment.Columns[11].Name = "contactPhone";
            dgvShipment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;

            dgvGoods.ColumnCount = 10;
            dgvGoods.Columns[0].Name = "OrderID(Good belongs to which order)";
            dgvGoods.Columns[1].Name = "type";
            dgvGoods.Columns[2].Name = "description";
            dgvGoods.Columns[3].Name = "totalWeight";
            dgvGoods.Columns[4].Name = "length";
            dgvGoods.Columns[5].Name = "width";
            dgvGoods.Columns[6].Name = "height";
            dgvGoods.Columns[7].Name = "harmonizedCode";
            dgvGoods.Columns[8].Name = "numberOfItem";
            dgvGoods.Columns[9].Name = "piece";
            dgvGoods.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
        }

        internal void insertToDB()
        {
            
            if (shipmentArr == null || goodsArr == null)
            {
                MessageBox.Show("Please import a file before submit.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } 
            else
            {
                String sCountry, sName, sAddress, sCompany, rEmail, rCountry, areaCode, rAddress, rName, rCompany, length, width, height, weight, description, harmonizedCode, piece, numOfItem, type, cPerson, cPhone;

                for (int row = 0; row < shipmentArr.GetLength(0); row++)
                {
                    String tmpOrderID = shipmentArr[row, 0];
                    rAddress = shipmentArr[row, 1];
                    rName = shipmentArr[row, 2];
                    rEmail = shipmentArr[row, 3];
                    rCountry = shipmentArr[row, 4];
                    rCompany = shipmentArr[row, 5];
                    areaCode = shipmentArr[row, 6];
                    sName = shipmentArr[row, 7];
                    sAddress = shipmentArr[row, 8];
                    sCompany = shipmentArr[row, 9];
                    cPerson = shipmentArr[row, 10];
                    cPhone = shipmentArr[row, 11];

                    //Add Shipment order
                    int dbOrderID = addShipmentOrderUsingConnection(rAddress,rName,rEmail,rCompany,rCountry,areaCode,sName,sAddress,sCompany,cPerson,cPhone);
                    double payPrice = 0;

                    for (int goodrow = 0; goodrow < goodsArr.GetLength(0); goodrow++)
                    {
                        String tmpGoodOrderID = goodsArr[goodrow, 0];

                        if (tmpGoodOrderID == tmpOrderID)
                        {
                            type = goodsArr[goodrow, 1];
                            description = goodsArr[goodrow, 2];
                            weight = goodsArr[goodrow, 3];
                            length = goodsArr[goodrow, 4];
                            width = goodsArr[goodrow, 5];
                            height = goodsArr[goodrow, 6];
                            harmonizedCode = goodsArr[goodrow, 7];
                            numOfItem = goodsArr[goodrow, 8];
                            piece = goodsArr[goodrow, 9];

                            //Add good & cal fee
                            payPrice += addGoodAndCalFee(rCountry, dbOrderID.ToString(), description, weight, length, width, height, type, harmonizedCode, numOfItem, piece);

                        }
                    }

                    //Add payment
                    addPayment(dbOrderID.ToString(), payPrice.ToString());

                }

                MessageBox.Show("Your shipment orders are submited. Click 'View Airway Bill' to check it. ", "Submited", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            insertToDB();
        }


        public int addShipmentOrderUsingConnection(String rAddress, String rName, String rEmail, String rCountry, String rCompany, String areaCode,
            String sName, String sAddress, String sCompany, String cPerson, String cPhone)
        {
            String CONNECTION_STRING = Program.connStr;
            int curOrderID;
            string date = DateTime.UtcNow.ToString("MM/dd/yyyy HH:mm");
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
                    new OleDbParameter("@VsenderCountry", "Hong Kong"),
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
            return curOrderID;
        }



        public double addGoodAndCalFee(String rCountry, String curOrderID, String description, String weight, String length, String width, String height, 
            String type, String harmonizedCode, String numOfItem, String piece)
        {
            DataTable dt = new DataTable();
            string connStr = Program.connStr;
            OleDbDataAdapter dataAdapter;
            string sqlStr;
            double money = 0;

            sqlStr = "INSERT INTO Good (orderID, description, totalWeight, length, width, height, type, harmonizedCode, numberOfItem, piece)" +
                         "VALUES(" + "'" + curOrderID + "'," + "'" + description + "'," + "'" + weight + "'," + "'" + length + "'," + "'" + width + "'," + "'" + height + "'," + "'" + type + "'," + "'" + harmonizedCode + "'," + "'" + numOfItem + "'," + "'" + piece + "'" + ");";
            dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);

            if (type.Equals("Document"))
            {
                double kg = Convert.ToDouble(weight);
                //Console.WriteLine(kg);
                if (kg > 0.5)
                {
                    while (kg > 0.5)
                    {
                        money = money + 150;
                        kg = kg - 0.5;
                    }
                }
                money = money + 158;

            }
            else if (type.Equals("Package"))
            {
                double kg = Convert.ToDouble(weight);
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
            return money;

        }

        public void addPayment(String curOrderID, String payPrice)
        {
            DataTable dt = new DataTable();
            string connStr = Program.connStr;

            string sqlStr = "Insert into Payment " +
                "(paymentID, price, paymentStatus)" +
                "values (" + "'" + curOrderID + "'," + "'" + payPrice + "'," + "'unPaid'" + ");";

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);
            
        }

        
    }
}
