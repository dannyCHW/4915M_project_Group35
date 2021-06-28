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
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using Font = iTextSharp.text.Font;

namespace _4915M_project
{
    public partial class viewAirwayBill : Form
    {

        protected String orderNumber = "";
        String sName, sAddress, sCompany, rCountry, areaCode, rAddress, rName, rCompany, rEmail, cPerson, cPhone, price;
        String gType, gDescription, gWeight, gPiece, gLength, gWidth, gHeight;
        DataTable goodDT = new DataTable();
        Boolean selected = false;


        private void btnDownloadBill_Click(object sender, EventArgs e)
        {
            if (selected == true)
            {
                bornPDF();
                MessageBox.Show("PDF generate", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("You haven't select any record yet.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void viewAirwayBill_Load(object sender, EventArgs e)
        {
            orderNumber = null;
            comboViewAirwaybill.Items.Clear();
            
            for(int i = 0; i < comboViewAirwaybill.Items.Count; i++)
            {
                comboViewAirwaybill.Items.RemoveAt(0);
            }
            getRecord();
        }

        

        public viewAirwayBill()
        {
            InitializeComponent();
        }

        private void AirwayBillPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        public void getRecord()
        {
            DataTable dt = new DataTable();
            string connStr = Program.connStr;

            string sqlStr = "SELECT orderID FROM ShipmentOrder WHERE cusID = " + CustomerLogin.currentCustomerID + ";";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);
            foreach (DataRow dr in dt.Rows)
            {
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
                    rEmail = dt.Rows[0]["receiverEmail"].ToString();
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
                dataAdapter2.Fill(goodDT);

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
            txtReceiverEmail.Text = rEmail;

        }

        private void comboViewAirwaybill_SelectedIndexChanged(object sender, EventArgs e)
        {
            orderNumber = comboViewAirwaybill.SelectedItem.ToString();
            selected = true;
            displayDetailRecord();
        }

        public void bornPDF()
        {

            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4);
            try
            {

                PdfWriter.GetInstance(doc, new FileStream("AirwayBill.pdf", FileMode.Create));
                doc.Open();

                iTextSharp.text.Image logo = iTextSharp.text.Image.GetInstance("Logo.png");
                logo.ScalePercent(20f);
                logo.SetAbsolutePosition(10, 750);
                doc.Add(logo);

                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));
                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));
                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));

                string NameStr = @"Eastern Delivery Express (EDE) Limited";
                Paragraph pLong = new Paragraph(NameStr);
                pLong.Alignment = Element.ALIGN_CENTER;
                doc.Add(pLong);

                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));

                string aStr = @"Airway Bill ";
                Paragraph airwaybill = new Paragraph(aStr);
                airwaybill.Alignment = Element.ALIGN_CENTER;
                doc.Add(airwaybill);

                string underLineStr = @"______________________________________________________________________________";
                Paragraph underLine = new Paragraph(underLineStr);
                underLine.Alignment = Element.ALIGN_CENTER;
                doc.Add(underLine);


                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));

                var boldFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 12);

                //order Number
                PdfPTable theTable = new PdfPTable(1);
                Phrase phrase = new Phrase();
                phrase.Add("Order Number : ");
                phrase.Add(new Chunk(orderNumber, boldFont));
                theTable.AddCell(phrase);
                doc.Add(theTable);

                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));

                //Sender Table
                theTable = null;
                theTable = new PdfPTable(1);
                phrase = null;
                phrase = new Phrase();
                phrase.Add("Sender Information ");
                theTable.AddCell(phrase);
                doc.Add(theTable);

                theTable = null;
                theTable = new PdfPTable(2);

                phrase = null;
                phrase = new Phrase();
                phrase.Add("Name : \n");
                phrase.Add(new Chunk(sName, boldFont));
                theTable.AddCell(phrase);

                phrase = null;
                phrase = new Phrase();
                phrase.Add("Country/Area : \n");
                phrase.Add(new Chunk("*Hong Kong", boldFont));
                theTable.AddCell(phrase);

                phrase = null;
                phrase = new Phrase();
                phrase.Add("Address : \n");
                phrase.Add(new Chunk(sAddress, boldFont));
                theTable.AddCell(phrase);

                phrase = null;
                phrase = new Phrase();
                phrase.Add("Company : \n");
                phrase.Add(new Chunk(sCompany, boldFont));
                theTable.AddCell(phrase);

                doc.Add(theTable);

                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));

                //Receiver Table
                theTable = null;
                theTable = new PdfPTable(1);
                phrase = null;
                phrase = new Phrase();
                phrase.Add("Receiver Information ");
                theTable.AddCell(phrase);
                doc.Add(theTable);

                theTable = null;
                theTable = new PdfPTable(2);

                phrase = null;
                phrase = new Phrase();
                phrase.Add("Name : \n");
                phrase.Add(new Chunk(rName, boldFont));
                theTable.AddCell(phrase);
                

                phrase = null;
                phrase = new Phrase();
                phrase.Add("Address : \n");
                phrase.Add(new Chunk(rAddress, boldFont));
                theTable.AddCell(phrase);
                

                phrase = null;
                phrase = new Phrase();
                phrase.Add("Email : \n");
                phrase.Add(new Chunk(rEmail, boldFont));
                theTable.AddCell(phrase);
                

                phrase = null;
                phrase = new Phrase();
                phrase.Add("Company : \n");
                phrase.Add(new Chunk(rCompany, boldFont));
                theTable.AddCell(phrase);

                doc.Add(theTable);

                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));

                //Destination Table
                theTable = null;
                theTable = new PdfPTable(1);
                phrase = null;
                phrase = new Phrase();
                phrase.Add("Destination Information ");
                theTable.AddCell(phrase);
                doc.Add(theTable);

                theTable = null;
                theTable = new PdfPTable(2);

                phrase = null;
                phrase = new Phrase();
                phrase.Add("Country/Area : \n");
                phrase.Add(new Chunk(rCountry, boldFont));
                theTable.AddCell(phrase);

                phrase = null;
                phrase = new Phrase();
                phrase.Add("Area Code : \n");
                phrase.Add(new Chunk(areaCode, boldFont));
                theTable.AddCell(phrase);

                doc.Add(theTable);

                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));

                //Contact person Table
                theTable = null;
                theTable = new PdfPTable(1);
                phrase = null;
                phrase = new Phrase();
                phrase.Add("Contact Person Information ");
                theTable.AddCell(phrase);
                doc.Add(theTable);

                theTable = null;
                theTable = new PdfPTable(2);

                phrase = null;
                phrase = new Phrase();
                phrase.Add("Contact Person : \n");
                phrase.Add(new Chunk(cPerson, boldFont));
                theTable.AddCell(phrase);

                phrase = null;
                phrase = new Phrase();
                phrase.Add("Contact Persons' Phone Number : \n");
                phrase.Add(new Chunk(cPhone, boldFont));
                theTable.AddCell(phrase);

                doc.Add(theTable);

                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));

                //Good table
                int goodNo = 1;
                foreach (DataRow dr in goodDT.Rows)
                {
                    doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));

                    theTable = null;
                    theTable = new PdfPTable(1);
                    phrase = null;
                    phrase = new Phrase();
                    phrase.Add("Goods Number " + goodNo + " Information");
                    theTable.AddCell(phrase);
                    doc.Add(theTable);

                    theTable = null;
                    theTable = new PdfPTable(2);

                    phrase = null;
                    phrase = new Phrase();
                    phrase.Add("Type : \n");
                    phrase.Add(new Chunk(dr["type"].ToString(), boldFont));
                    theTable.AddCell(phrase);

                    phrase = null;
                    phrase = new Phrase();
                    phrase.Add("Description : \n");
                    phrase.Add(new Chunk(dr["description"].ToString(), boldFont));
                    theTable.AddCell(phrase);

                    doc.Add(theTable);

                    theTable = null;
                    theTable = new PdfPTable(5);

                    phrase = null;
                    phrase = new Phrase();
                    phrase.Add("Total Weight : \n");
                    phrase.Add(new Chunk(dr["totalWeight"].ToString(), boldFont));
                    theTable.AddCell(phrase);

                    phrase = null;
                    phrase = new Phrase();
                    phrase.Add("Length : \n");
                    phrase.Add(new Chunk(dr["length"].ToString(), boldFont));
                    theTable.AddCell(phrase);

                    phrase = null;
                    phrase = new Phrase();
                    phrase.Add("Width : \n");
                    phrase.Add(new Chunk(dr["width"].ToString(), boldFont));
                    theTable.AddCell(phrase);

                    phrase = null;
                    phrase = new Phrase();
                    phrase.Add("Height : \n");
                    phrase.Add(new Chunk(dr["height"].ToString(), boldFont));
                    theTable.AddCell(phrase);

                    phrase = null;
                    phrase = new Phrase();
                    phrase.Add("Piece : \n");
                    phrase.Add(new Chunk(dr["piece"].ToString(), boldFont));
                    theTable.AddCell(phrase);

                    doc.Add(theTable);

                    goodNo++;
                }

                

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                doc.Close();
            }
        }

        
    }
}
