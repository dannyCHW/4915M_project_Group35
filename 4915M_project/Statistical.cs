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
    public partial class Statistical : Form
    {
        public Statistical()
        {
            InitializeComponent();
        }

        private void Statistical_Load(object sender, EventArgs e)
        {
            timeMonth.Format = DateTimePickerFormat.Custom;
            timeMonth.CustomFormat = "yyyy/MM";

            timeDay.Format = DateTimePickerFormat.Custom;
            timeDay.CustomFormat = "yyyy/MM/dd";

            timeDay.Visible = false;
            timeMonth.Visible = false;

        }

        private void btnDay_Click(object sender, EventArgs e)
        {
            timeDay.Visible = true;
            timeMonth.Visible = false;
            timeDay_ValueChanged(sender, e);
        }

        private void btnMonth_Click(object sender, EventArgs e)
        {
            timeDay.Visible = false;
            timeMonth.Visible = true;
            timeMonth_ValueChanged(sender, e);
        }

        private void timeDay_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Program.DataTableVar;
                dt.Clear();
                string sqlStr = "Select price,dateOfOrder from ShipmentOrder,Payment where ShipmentOrder.orderID = Payment.paymentID AND paymentStatus = 'paid';";

                DateTime expected = (DateTime)timeDay.Value;
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, Program.connStr);
                dataAdapter.Fill(dt);
                int loop = 0, count = 0, price = 0;
                while (loop < dt.Rows.Count)
                {
                    DateTime dataTime = (DateTime)dt.Rows[loop]["dateOfOrder"];
                    if (expected.Day == dataTime.Day)
                    {
                        count++;
                        price += Convert.ToInt32(dt.Rows[loop]["price"]);
                    }
                    loop++;
                }
                txtCount.Text = count.ToString();
                txtMoney.Text = "$HKD " + price.ToString();
            }
            catch {

                MessageBox.Show("Something Wrong", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void timeMonth_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                DataTable dt = Program.DataTableVar;
                dt.Clear();
                string sqlStr = "Select price,dateOfOrder from ShipmentOrder,Payment where ShipmentOrder.orderID = Payment.paymentID AND paymentStatus = 'paid';";

                DateTime expected = (DateTime)timeDay.Value;
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, Program.connStr);
                dataAdapter.Fill(dt);
                int loop = 0, count = 0, price = 0;
                while (loop < dt.Rows.Count)
                {
                    DateTime dataTime = (DateTime)dt.Rows[loop]["dateOfOrder"];
                    if (expected.Month == dataTime.Month)
                    {
                        count++;
                        price += Convert.ToInt32(dt.Rows[loop]["price"]);
                    }
                    loop++;
                }
                txtCount.Text = count.ToString();
                txtMoney.Text = "$HKD " + price.ToString();
            }
            catch
            {

                MessageBox.Show("Something Wrong", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            ViewDatabase view = new ViewDatabase();
            view.Show();
            this.Close();
        }
    }
}
