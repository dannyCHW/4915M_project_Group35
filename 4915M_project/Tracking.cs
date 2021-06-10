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
    public partial class Tracking : Form
    {
        public Tracking()
        {
            InitializeComponent();
        }


        private void Tracking_Load(object sender, EventArgs e)
        {

        }

        private void btnBack_Click_1(object sender, EventArgs e)
        {}

        private void btnCheck_Click(object sender, EventArgs e)
        {
            int orderID = Convert.ToInt32(txtOrder.Text);
            DataTable dt = Program.DataTableVar;
            dt.Clear();
            string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";

            string sqlStr = "Select orderStatus ,currentLocation,dateOfPickUp from ShipmentOrder where orderID = " + orderID;

            OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
            dataAdapter.Fill(dt);

            try
            {

                if (dt.Rows.Count > 0)
                {
                    
                    String dataInput = dt.Rows[0]["dateOfPickUp"].ToString();
                    String vStatus = dt.Rows[0]["orderStatus"].ToString();
                    String location = dt.Rows[0]["currentLocation"].ToString();
                    var v_exDay = DateTime.Parse(dataInput);
                    DateTime expectedDate = (DateTime)v_exDay;
                    expectedDate = expectedDate.AddDays(3);

                    if (vStatus == "processing")
                    {
                        dt.Clear();
                        txtNow.Text = "Now, this shipment is in " + location;
                        txtExpected.Text = "Date is expected to arrive : " + expectedDate.ToString();

                    }
                    else
                    {
                        MessageBox.Show("The order is not processing", "Fail Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                else
                {
                    MessageBox.Show("Cannot found this order", "Fail Check", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

            catch (Exception)
            {
                MessageBox.Show("Something wrong", "Fail Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
    }
}
