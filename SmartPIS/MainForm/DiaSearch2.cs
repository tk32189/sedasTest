using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Reflection;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace SmartPIS
{
    public partial class DiaSearch2 : Form
    {
        MySqlConnection Myconn;
        public string SMTP = "";

        public DiaSearch2()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }       

        private void DiaSearch_Load(object sender, EventArgs e)
        {
            DBConn();
            Ini.strPath = System.Environment.CurrentDirectory + "\\Setup.ini";
            Ini.xlsPath = Ini.G_IniReadValue("PATH", "xls", Ini.strPath);
        }
        
        private bool DBConn()
        {
            try
            {
                string strSQL = Ini.strDB;
                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();
            }
            catch (System.Exception ex)
            {
                return false;
            }            
            return true;
        }

        private bool DBUnConn()
        {
            try
            {
                if (Myconn.State == ConnectionState.Open)
                    Myconn.Close();
            }
            catch (System.Exception ex)
            {
                return false;
            }
            return true;
        }

        private void DiaSearch_FormClosing(object sender, FormClosingEventArgs e)
        {
            DBUnConn();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DBSearch();
        }

        private void DBSearch()
        {
            dgvList.Rows.Clear();

            if (SMTP == "")
            {
                MessageBox.Show("장기를 선택하세요.");
                return;
            }

            //SetDgvColumHeader();

            string strTable = "pis" + SMTP + "001";

            string sql = string.Format("select ptno, pano, PANM, PSEX, PAGE, ABLK, NBLK, OGTP, DEPT, GRTX, DITX, TRYN, EXCD, EXST, INTR " +
                                    "FROM pisdig001 WHERE INTEREST = '1' and UPDT between '{0}' and '{1}' and OGTP = '{2}' ",
                                    dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"), SMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                dgvList.Rows.Add(dr[0].ToString(),
                                 dr[1].ToString(),
                                 dr[2].ToString(),
                                 dr[3].ToString(),
                                 dr[4].ToString(),
                                 dr[12].ToString(),//검사코드
                                 dr[13].ToString(),//검사상태
                                 dr[14].ToString(),//관심사유
                                 dr[5].ToString(),
                                 dr[6].ToString(),                                 
                                 dr[7].ToString(),
                                 dr[8].ToString(),
                                 GetData(dr[9].ToString()),
                                 GetData(dr[10].ToString()),
                                 dr[11].ToString());
            }
            dr.Close();
        }

        private string GetData(string strData)
        {
            string strValue = "";
            strData = strData.ToLower();

            if (strData == "negative")
                strValue = "-";
            else if (strData == "positive")
                strValue = "+";
            else if (strData != "")
                strValue = "O";
            else
                strValue = "X";

            return strValue;
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {
            ExportExcel(true);
        }

        private void ExportExcel(bool captions)
        {
            int num = 0;
            object missingType = Type.Missing;

            Excel.Application objApp;
            Excel._Workbook objBook;
            Excel.Workbooks objBooks;
            Excel.Sheets objSheets;
            Excel._Worksheet objSheet;
            Excel.Range range;

            string[] headers = new string[dgvList.ColumnCount];
            string[] columns = new string[dgvList.ColumnCount];

            for (int c = 0; c < dgvList.ColumnCount; c++)
            {
                headers[c] = dgvList.Rows[0].Cells[c].OwningColumn.HeaderText.ToString();
                num = c + 65;
                columns[c] = Convert.ToString((char)num);
            }

            try
            {
                objApp = new Excel.Application();
                objBooks = objApp.Workbooks;
                objBook = objBooks.Add(Missing.Value);
                objSheets = objBook.Worksheets;
                //objSheet = (Excel._Worksheet)objSheets.get_Item(1);
                objSheet = (Microsoft.Office.Interop.Excel._Worksheet)objSheets.get_Item(1);


                if (captions)
                {
                    for (int c = 0; c < dgvList.ColumnCount; c++)
                    {
                       
                        range = objSheet.get_Range(columns[c] + "1", Missing.Value);
                        range.set_Value(Missing.Value, headers[c]);
                    }
                }

                for (int i = 0; i < dgvList.RowCount; i++)
                {
                    for (int j = 0; j < dgvList.ColumnCount; j++)
                    {
                        range = objSheet.get_Range(columns[j] + Convert.ToString(i + 2),
                                                                Missing.Value);
                        range.set_Value(Missing.Value,
                                                dgvList.Rows[i].Cells[j].Value.ToString());
                    }
                }

                objApp.Visible = false;
                objApp.UserControl = false;
                string strFileName = Ini.xlsPath + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".xls";
                objBook.SaveAs(strFileName,
                            Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                            missingType, missingType, missingType, missingType,
                            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                            missingType, missingType, missingType, missingType, missingType);
                objBook.Close(false, missingType, missingType);

                Cursor.Current = Cursors.Default;
                
                Process process = new Process();
                process.StartInfo.FileName = strFileName;
                process.Start();
                //MessageBox.Show("Save Success!!!");
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                DevExpress.XtraEditors.XtraMessageBox.Show(errorMessage, "Error");
            }
            
        }

        string GetHTMP(string strData)
        {
            try
            {
                switch (strData)
                {
                    case "Breast":
                        SMTP = "brs";
                        break;
                    case "Cervix":
                        SMTP = "cvx";
                        break;
                    case "Colon":
                        SMTP = "col";
                        break;
                    case "Endometrial cancer":
                        SMTP = "edc";
                        break;
                    case "Esophagus":
                        SMTP = "esp";
                        break;
                    case "Gross":
                        SMTP = "grs";
                        break;
                    case "Kidney":
                        SMTP = "kdn";
                        break;
                    case "Liver Hepatectomy":
                        SMTP = "lvh";
                        break;
                    case "Liver Intrahepatic":
                        SMTP = "lvi";
                        break;
                    case "Liver meta":
                        SMTP = "lvm";
                        break;
                    case "Lung":
                        SMTP = "lng";
                        break;
                    case "Ovary cancer":
                        SMTP = "ovc";
                        break;
                    case "Prostate":
                        SMTP = "prs";
                        break;
                    case "Rectal":
                        SMTP = "rtc";
                        break;
                    case "Stomach gastrectomy":
                        SMTP = "stm";
                        break;
                    case "Stomach GIST":
                        SMTP = "stg";
                        break;
                    case "TESTIS":
                        SMTP = "tst";
                        break;
                    case "Urinary bladder carcinoma":
                        SMTP = "ubc";
                        break;
                    case "Urinary bladder turb":
                        SMTP = "ubt";
                        break;
                    case "관심환자":
                        SMTP = "int";
                        break;
                }
            }
            catch (System.Exception ex)
            {

            }
            return SMTP;
        }

        private void cbHMTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetHTMP(cbHMTP.Text);
        }

        private void SetDgvColumHeader()
        {
            int nCnt = dgvList.Columns.Count;

            for (int i = nCnt-1; i > 6; i--)
            {
                dgvList.Columns.RemoveAt(i);
            }

            dgvList.Columns.Add("i1", "장기");
            dgvList.Columns.Add("i2", "진료과");
            dgvList.Columns.Add("i3", "Gross 결과");
            dgvList.Columns.Add("i4", "Diagnosis 결과");
            dgvList.Columns.Add("i5", "결과전송");
            
        }
    }
}
