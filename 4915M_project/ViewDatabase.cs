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
    public partial class ViewDatabase : Form
    {
        private Boolean isString;
        public ViewDatabase()
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
            else {
                ManagerLobby managerLobby = new ManagerLobby();
                managerLobby.Show();
                this.Close();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
 
                if (comboBox1.Text == "(column)")
                {
                    MessageBox.Show("Need to select the colunm to search.", "Attention", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else if (isString == true)
                {
                    DataTable dtSearch = StaffLogin.DataTableVar2;

                    dtSearch.Clear();

                    string sqlStr = "select * from ShipmentOrder where " + comboBox1.Text + " = '" + txtInput.Text + "' ;";
                    OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, Program.connStr);
                    dataAdapter.Fill(dtSearch);
                    dataGridView1.DataSource = dtSearch;
                }
                else if (isString == false)
                {
                DataTable dtSearch = StaffLogin.DataTableVar2;

                dtSearch.Clear();

                string sqlStr = "select * from ShipmentOrder where " + comboBox1.Text + " = " + Convert.ToInt32(intInput.Text) + " ;";
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, Program.connStr);
                dataAdapter.Fill(dtSearch);
                dataGridView1.DataSource = dtSearch;
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBox1.Text != "orderID" || comboBox1.Text != "cusID" || comboBox1.Text != "contactPhone" || comboBox1.Text != "staffID")
            {
                txtInput.Visible = true;
                intInput.Visible = false;
                isString = true;
            }
            if (comboBox1.Text == "orderID" || comboBox1.Text == "cusID" || comboBox1.Text == "contactPhone" || comboBox1.Text == "staffID")
            {
                intInput.Visible = true;
                txtInput.Visible = false;
                isString = false;
            }
        }

        private void ViewDatabase_Load(object sender, EventArgs e)
        {
            intInput.Visible = false;
            txtInput.Visible = false;
        }

        private void intInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.CurrentRow.Selected = true;
            try
            {
                String strOrderID = dataGridView1.Rows[e.RowIndex].Cells["orderID"].Value.ToString();

                DataTable dt = new DataTable();
                dt.Clear();
                string strSqlStr = "select * from Good where orderID = " + Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["orderID"].Value.ToString()) + " ;";

                OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, Program.connStr);
                dataAdapter2.Fill(dt);

                dataGridView2.DataSource = dt;

                DataTable dt2 = new DataTable();
                dt2.Clear();
                string strSqlStr2 = "select * from Payment where paymentID = " + Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["orderID"].Value.ToString()) + " ;";

                OleDbDataAdapter dataAdapter3 = new OleDbDataAdapter(strSqlStr2, Program.connStr);
                dataAdapter3.Fill(dt2);

                dataGridView3.DataSource = dt2;
            }
            catch
            {
                MessageBox.Show("Don't press it indiscriminately", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
