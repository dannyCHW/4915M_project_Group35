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
    public partial class Payment : Form
    {
        public Payment()
        {
            InitializeComponent();
        }
        private void btnBack_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnEBA_Click(object sender, EventArgs e)
        {
            DialogResult diaglog= MessageBox.Show("Are you sure you want to pay on delivery? You will not be able to change the payment method after confirmation", "Payment", MessageBoxButtons.YesNo);
            if (diaglog == DialogResult.Yes) {
                EBAForm eba = new EBAForm();
                eba.Show();
                this.Close();
            }
        }

        private void btnCredit_Click(object sender, EventArgs e)
        {
            DialogResult diaglog = MessageBox.Show("Now jumping to oayment gateway", "Payment Gateway", MessageBoxButtons.YesNo);
            if (diaglog == DialogResult.Yes) {

                PaymentGateway paymentgateway = new PaymentGateway();
                paymentgateway.Show();
                    this.Close();

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Please remember your order ID and go to center for payment", "Cash Payment", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void Payment_Load(object sender, EventArgs e)
        {

        }

        private void btnMon_Click(object sender, EventArgs e)
        {
            MonthlyPay month = new MonthlyPay();
            month.Show();
            month.Close();
        }
    }
}
