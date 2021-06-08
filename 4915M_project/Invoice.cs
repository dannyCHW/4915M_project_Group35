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

namespace _4915M_project
{
    public partial class Invoice : Form
    {
        public Invoice()
        {
            InitializeComponent();
        }

        private void btnback_Click(object sender, EventArgs e)
        {
            CustomerLobby custLobby = new CustomerLobby();
            custLobby.Show();
            this.Hide();
        }

        private void btnNext_Click(object sender, EventArgs e)
        {
            Invoice2 invoice2 = new Invoice2();
            invoice2.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bornPDF();
        }

        public void bornPDF()
        {   
            iTextSharp.text.Document doc = new iTextSharp.text.Document(PageSize.A4.Rotate());
            try
            {
                
                PdfWriter.GetInstance(doc, new FileStream("TEST.pdf", FileMode.Create));
                doc.Open();
                doc.Add(new iTextSharp.text.Paragraph("TEST PDF"));
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
            DataTable dt = Program.DataTableVar;
            string connStr = Program.connStr;

            string sqlStr = "Select orderID,  from ShipmentOrder where cusEmail LIKE ";
            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);
        }

        
    }
}
