using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.OleDb;
using System.Windows.Forms;

namespace _4915M_project
{
    public partial class DeleteStaffAccout : Form
    {
        public DeleteStaffAccout()
        {
            InitializeComponent();
        }

        private void btnLobby_Click(object sender, EventArgs e)
        {
            ManagerLobby managerlobby = new ManagerLobby();
            managerlobby.Show();
            this.Hide();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            CreateStaffAccout createstaff = new CreateStaffAccout(); 
            createstaff.Show();
            this.Hide();
        }

        private void textBox7_KeyPress(object sender, KeyPressEventArgs e)
        {
            char ch = e.KeyChar;
            if (!Char.IsNumber(e.KeyChar) && (!char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (!checkBox.Checked)
            {
                MessageBox.Show("You need confirm this action", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else {
                DataTable dt = new DataTable();
                String connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";
                int vStfID = Convert.ToInt32(txtStaffID.Text);

                string sqlStr = "Select stfID,stfPassword,stfPosition from Staff where stfID = " + vStfID;
                OleDbDataAdapter dataAdapter = new OleDbDataAdapter(sqlStr, connStr);
                dataAdapter.Fill(dt);

                if (dt.Rows.Count > 0)
                {
                    MessageBox.Show("Delete Successful", "Success Action", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string strSqlStr = "Delete from Staff where stfID = " + vStfID;
                    OleDbDataAdapter dataAdapter2 = new OleDbDataAdapter(strSqlStr, connStr);
                    dataAdapter2.Fill(dt);
                    dataAdapter.Dispose();
                    dataAdapter2.Dispose();
                    dt.Clear();
                }
                else {
                    MessageBox.Show("Cannot found this accout", "Fail Action", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void DeleteStaffAccout_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ManagerLobby managerlobby = new ManagerLobby();
            managerlobby.Show();
            this.Hide();
        }
    }
}
