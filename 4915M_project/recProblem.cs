using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _4915M_project
{
    public partial class recProblem : Form
    {
        public recProblem()
        {
            InitializeComponent();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (Main.position == 1)
            {
                StaffLobby stafflobby = new StaffLobby();
                stafflobby.Show();
                this.Hide();
            }
            else
            {
                ManagerLobby managerLobby = new ManagerLobby();
                managerLobby.Show();
                this.Close();
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

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable dtSearch = StaffLogin.DataTableVar2;

                dtSearch.Clear();

                string sqlStr = "select * from ShipmentOrder where orderID = " + Convert.ToInt32(txtOrder.Text) ;
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, Program.connStr);
                dataAdapter.Fill(dtSearch);
                dataGridView1.DataSource = dtSearch;
                if (dtSearch.Rows.Count == 0) {
                    MessageBox.Show("Cannot found this order", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch
            {
                MessageBox.Show("Something Wrong", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void recProblem_Load(object sender, EventArgs e)
        {
            DataTable dtSearch2 = StaffLogin.DataTableVar2;

            dtSearch2.Clear();

            string sqlStr2 = "select * from ShipmentOrder where orderStatus = 'On Problem'";
            OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(sqlStr2, Program.connStr);
            dataAdapter2.Fill(dtSearch2);
            dataGridView1.DataSource = dtSearch2;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            recProblem_Load(sender, e);
        }

        private void btnProblem_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtStatus.Text.ToString() != "Completed") {
                    MessageBox.Show("The order status need to be 'Completed' , please check the order status again", "Action Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else {
                    DataTable dt3 = StaffLogin.DataTableVar2;
                    dt3.Clear();
                    string sqqlStr = "Update ShipmentOrder set  orderStatus = 'On Problem', solveProblemStaffID = " + Main.staffID + " where orderID = " + Convert.ToInt32(txtID.Text) + "; ";
                    OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(sqqlStr, Program.connStr);
                    dataAdapter3.Fill(dt3);

                    recProblem_Load(sender, e);

                    MessageBox.Show("Update the order to on problem", "Action Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch
            {
                MessageBox.Show("Please check the order status or order number is correct.", "Verify Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            try
            {
                String strOrderID = dataGridView1.Rows[e.RowIndex].Cells["orderID"].Value.ToString();
                String orderStatus = dataGridView1.Rows[e.RowIndex].Cells["orderStatus"].Value.ToString();
                txtID.Text = strOrderID;
                txtStatus.Text = orderStatus;
            }
            catch
            {
                MessageBox.Show("Don't press it indiscriminately", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
