using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;
using Excel = Microsoft.Office.Interop.Excel;

namespace _4915M_project
{
    public partial class excelAirwayBill : Form
    {
        public excelAirwayBill()
        {
            InitializeComponent();
        }

        private void btnGetfile_Click(object sender, EventArgs e)
        {


            OpenFileDialog openFileDialog1 = new OpenFileDialog
            {
                InitialDirectory = @"D:\",
                Title = "Browse & import Airway Bill Excel Files",

                CheckFileExists = true,
                CheckPathExists = true,

                DefaultExt = "Excel",
                Filter = "Excel Files|*.xlsx;*.xlsm;*.xlsb;*.xltx;*.xltm;*.xls;*.xlt;*.xls;*.xml;*.xml;*.xlam;*.xla;*.xlw;*.xlr| All files (*.*)|*.*",
                FilterIndex = 1,
                RestoreDirectory = true,

                //ReadOnlyChecked = true,
                //ShowReadOnly = true
            };

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                MessageBox.Show("Import Files: " + openFileDialog1.FileName, "Message");



                Excel.Application excel_eAB = new Excel.Application();
                var workbooks = excel_eAB.Workbooks;
                var excel_WB = workbooks.Open(openFileDialog1.FileName);
                Excel.Worksheet excel_WS_shipment;
                Excel.Worksheet excel_WS_good;
                excel_WS_shipment = excel_WB.Worksheets[1];
                excel_WS_good = excel_WB.Worksheets[2];

                int shipment_UsedRow = 0;
                int shipment_UsedColumn = 0;

                int good_UsedRow = 0;
                int good_UsedColumn = 0;

                try
                {

                    if (((Excel.Range)excel_WS_good.Columns[1]).Text.ToString().Length <= 0)
                    {
                        MessageBox.Show("null asdasd", "Message");
                    }
                    else
                    {

                    }

                    shipment_UsedRow = excel_WS_shipment.Cells.Find("*", System.Reflection.Missing.Value,
                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                               Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious,
                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;

                    shipment_UsedColumn = excel_WS_shipment.Cells.Find("*", System.Reflection.Missing.Value,
                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                               Excel.XlSearchOrder.xlByColumns, Excel.XlSearchDirection.xlPrevious,
                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;

                    good_UsedRow = excel_WS_good.Cells.Find("*", System.Reflection.Missing.Value,
                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                               Excel.XlSearchOrder.xlByRows, Excel.XlSearchDirection.xlPrevious,
                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Row;

                    good_UsedColumn = excel_WS_good.Cells.Find("*", System.Reflection.Missing.Value,
                               System.Reflection.Missing.Value, System.Reflection.Missing.Value,
                               Excel.XlSearchOrder.xlByColumns, Excel.XlSearchDirection.xlPrevious,
                               false, System.Reflection.Missing.Value, System.Reflection.Missing.Value).Column;

                    String[,] shipmentArray = new String[shipment_UsedRow - 1, 13];
                    String[,] goodArray = new String[good_UsedRow - 1, 9];

                    for (int row = 1; row < shipment_UsedRow; row++)
                    {
                        for (int col = 0; col < 13; col++)
                        {

                        }
                    }


                    var cellValue = (string)(excel_WS_shipment.Cells[1, 1] as Excel.Range).Value;

                    MessageBox.Show(cellValue, "Message");

                    

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + "\nplease be informed that the format provided must be followed in order to import.", "Message");
                }
                finally
                {
                    //excel_WB.Close(false, null, null);
                    //excel_eAB.Quit();
                    //excel_eAB.Workbooks.Close();
                    //Marshal.ReleaseComObject(excel_WS_shipment);
                    //Marshal.ReleaseComObject(excel_WS_good);
                    //Marshal.ReleaseComObject(excel_WB);
                    //Marshal.ReleaseComObject(workbooks);
                    //Marshal.ReleaseComObject(excel_eAB);

                    //excel_WS_shipment = null;
                    //excel_WS_good = null;
                    //excel_WB = null;
                    //excel_eAB = null;

                    if (excel_WB != null)
                    {
                        excel_WB.Close(false, null, null);
                        excel_WB = null;
                    }

                    if (excel_eAB != null)
                    {
                        excel_eAB.Quit();
                    }
                    GC.Collect();
                    System.Diagnostics.Process[] excelProcess = System.Diagnostics.Process.GetProcessesByName("EXCEL");
                    foreach (var item in excelProcess)
                    {
                        item.Kill();
                    }

                }




            }
        }






    }
}
