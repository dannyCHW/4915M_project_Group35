using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data;

namespace _4915M_project
{
    static class Program
    {
        public static DataTable DataTableVar = new DataTable();
        public static string connStr = "Provider=Microsoft.ACE.OLEDB.12.0;" + "Data Source=des.accdb";

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main());
        }


    }
}
