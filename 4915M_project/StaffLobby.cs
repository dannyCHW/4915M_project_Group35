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
    public partial class StaffLobby : Form
    {


        public StaffLobby()
        {
            InitializeComponent();
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            Main main = new Main();
            main.Show();
            this.Hide();
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            VerifyOrder verify = new VerifyOrder();
            verify.Show();
            this.Close();
        }

        private void StaffLobby_Load(object sender, EventArgs e)
        {
        }

        private void btnPay_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnProblem_Click(object sender, EventArgs e)
        {
            problem problem = new problem();
            problem.Show();
            this.Close();
        }

    }
}
