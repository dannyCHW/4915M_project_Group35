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
    public partial class AirwayBill1 : Form
    {
        public AirwayBill1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CustomerLobby custLobby = new CustomerLobby();
            custLobby.Show();
            this.Hide();
        }

        private void createbtn_Click(object sender, EventArgs e)
        {
            AirwayBill2 airwayBill2 = new AirwayBill2();
            airwayBill2.Show();
            this.Hide();
        }
    }
}
