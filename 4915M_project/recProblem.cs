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
                DataTable dt3 = StaffLogin.DataTableVar2;
                dt3.Clear();
                string sqqlStr = "Update ShipmentOrder,solveProblemStaffID set orderStatus = 'On Problem', solveProblemStaffID = " + Main.staffID + " where orderID = " + Convert.ToInt32(txtID.Text) + "; ";
                OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(sqqlStr, Program.connStr);
                dataAdapter3.Fill(dt3);

                recProblem_Load(sender, e);

                MessageBox.Show("Verify Successful", "Verify Done", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch
            {
                MessageBox.Show("Something Wrong", "Verify Fail", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            try
            {
                String strOrderID = dataGridView1.Rows[e.RowIndex].Cells["orderID"].Value.ToString();
                txtID.Text = strOrderID;
                int orderID = Convert.ToInt32(strOrderID);

                DataTable dt4 = new DataTable();
                string strSqlStr4 = "select orderID,description,totalWeight,length,width,height,type,harmonizedCode,numberOfItem,piece,goodID  from Good where orderID = " + orderID + " ;";

                OleDbDataAdapter dataAdapter4 = new OleDbDataAdapter(strSqlStr4, Program.connStr);
                dataAdapter4.Fill(dt4);

                dataGridView1.DataSource = dt4;
            }
            catch
            {
                MessageBox.Show("Don't press it indiscriminately", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
