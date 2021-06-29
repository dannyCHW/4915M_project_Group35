using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Image = iTextSharp.text.Image;

namespace _4915M_project
{
    public partial class Invoice : Form
    {

        String orderNumber = "";
        String sName, sAddress, sCompany, rCountry, areaCode, rAddress, rName, rCompany, cPerson, cPhone, price;
        Boolean selected = false;

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void txtPrice_TextChanged(object sender, EventArgs e)
        {

        }

        public Invoice()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
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

        public void bornPDF()
        {   

            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4);
            try
            {
                
                PdfWriter.GetInstance(doc, new FileStream("Invoice.pdf", FileMode.Create));
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

                string invoiceStr = @"Invoice(Receipt)";
                Paragraph invoice = new Paragraph(invoiceStr);
                invoice.Alignment = Element.ALIGN_CENTER;
                doc.Add(invoice);

                string underLineStr = @"______________________________________________________________________________";
                Paragraph underLine = new Paragraph(underLineStr);
                underLine.Alignment = Element.ALIGN_CENTER;
                doc.Add(underLine);

                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));

                doc.Add(new iTextSharp.text.Paragraph("Shipment Order Number : " + orderNumber));
                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));
                doc.Add(new iTextSharp.text.Paragraph("Sender Name : " + sName));
                doc.Add(new iTextSharp.text.Paragraph("Sender Company : " + sCompany));
                doc.Add(new iTextSharp.text.Paragraph("Contact Phone : " + cPhone));
                doc.Add(new iTextSharp.text.Paragraph("Contact Person : " + cPerson));
                doc.Add(new iTextSharp.text.Paragraph("Sender Address : " + sAddress));

                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));
                doc.Add(new iTextSharp.text.Paragraph("SHIP TO"));
                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));

                doc.Add(new iTextSharp.text.Paragraph("Country/Area : " + rCountry));
                doc.Add(new iTextSharp.text.Paragraph("Receiver : " + rName));
                doc.Add(new iTextSharp.text.Paragraph("Area Code : " + areaCode));
                doc.Add(new iTextSharp.text.Paragraph("Receiver Address : " + rAddress));
                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));
                doc.Add(new iTextSharp.text.Paragraph("Total Price : HK$" + price));

                doc.Add(underLine);
                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));
                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));
                doc.Add(new iTextSharp.text.Paragraph("For and behalf of Eastern Delivery Express (EDE) Limited."));
                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));
                doc.Add(new iTextSharp.text.Paragraph(Environment.NewLine));
                doc.Add(new iTextSharp.text.Paragraph("___________________________"));
                doc.Add(new iTextSharp.text.Paragraph("                   Signature"));

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


        public void getRecord()
        {
            DataTable dt = new DataTable();
            string connStr = Program.connStr;

            string sqlStr = "SELECT orderID FROM ShipmentOrder WHERE cusID = " + CustomerLogin.currentCustomerID + " AND " + "orderStatus LIKE" + "'Completed'" + ";";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);
            
            foreach (DataRow dr in dt.Rows)
            {
                comboInvoice.Items.Add(dr["orderID"].ToString());
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

                if(dt.Rows.Count > 0)
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

                sqlStr = "SELECT price FROM Payment WHERE paymentID = " + orderNumber + ";";
                OleDbDataAdapter dataAdapterPayment = new OleDbDataAdapter(sqlStr, connStr);
                DataTable dtt = new DataTable();
                dataAdapterPayment.Fill(dtt);

                if (dtt.Rows.Count > 0)
                {
                    price = dtt.Rows[0]["price"].ToString();
                }
                else
                {
                    MessageBox.Show("Payment Datatable Row no thing ar, check 1 check la ", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

                dtt = null;
                dataAdapterPayment.Dispose();

            }

            txtSender.Text = sName;
            txtContactName.Text = cPerson;
            txtContactPhone.Text = cPhone;
            txtSenderAddress.Text = sAddress;
            txtCompany.Text = sCompany;
            txtReCountry.Text = rCountry;
            
            txtReCode.Text = areaCode;
            txtReCompanyName.Text = rCompany;
            txtReceiverName.Text = rName;
            txtReAddress.Text = rAddress;

            txtPrice.Text = price;

        }

        private void Invoice_Load(object sender, EventArgs e)
        {
            orderNumber = null;
            comboInvoice.DropDownStyle = ComboBoxStyle.DropDownList;
            comboInvoice.Items.Clear();
            getRecord();
        }

        private void comboInvoice_SelectedIndexChanged(object sender, EventArgs e)
        {
            orderNumber = comboInvoice.SelectedItem.ToString();
            selected = true;
            Console.WriteLine(orderNumber);
            displayDetailRecord();
        }

    }


}
