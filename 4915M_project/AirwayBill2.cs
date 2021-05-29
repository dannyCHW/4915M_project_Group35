using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915M_project
{
    public partial class AirwayBill2 : Form
    {
        public AirwayBill2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AirwayBill1 airwayBill1 = new AirwayBill1();
            airwayBill1.Show();
            this.Hide();
        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            AirwayBill3 airwayBill3 = new AirwayBill3();
            airwayBill3.Show();
            this.Hide();
        }
    }
}
