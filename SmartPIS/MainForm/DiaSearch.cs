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
    public partial class DiaSearch : Form
    {
        MySqlConnection Myconn;
        public string SMTP = "";
        public string ms ="";
        public string mn1 = "", mn2 = "", mn3 = "", mn4 = "", mn5 = "", mn6 = "";
        public string TNM1 = "", TNM2 = "", TNM3 = "";
        public string cvxadd1 = "", cvxadd2 = "", cvxadd3 = "", cvxadd4 = "", cvxadd5 = "", cvxadd6 = "";
        public DiaSearch()
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
                DevExpress.XtraEditors.XtraMessageBox.Show("장기를 선택하세요.");
                return;
            }

            SetDgvColumHeader();

            string strTable = "pis" + SMTP + "001";

            string sql = "";
            if (SMTP == "lng")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.n0101, a.n0501, a.n1401, a.n1402, a.n1403, " +
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
                
            }

            else if (SMTP == "brs")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.TIT1, a.n0101, a.n0103, a.n0201, a.n0202, a.n0203, a.n0301, a.n0401, a.n0402, a.n0403, a.n0404,"+
                                             "a.S002, a.S003, a.S006, a.S102, a.S103, a.S106, a.S202, a.S203, a.S206, a.S302, a.S303, a.S306,"+
                                             "a.S402, a.S403, a.S406, a.S502, a.S503, a.S506, a.S602, a.S603, a.S606, a.S702, a.S703, a.S706, a.S802, a.S803, a.S806,a.S902, a.S903, a.S906, " +
                                             "a.n0501, a.n0502, a.n0601, a.n0602, a.n0701, a.n0702, a.n0801, a.n0802, a.n0901, a.n0902, " +
                                             "a.M102, a.M202, a.M302, a.M402, a.M502, a.M602, a.M101, a.M201, a.M301, a.M401, a.M501, a.M601, " +
                                             "a.n1001, a.n1101, a.n1102, a.n1103, a.n1104, a.n1105, a.n1106, a.n1107, " +
                                             "a.n1201, a.n1202, a.n1203, a.n1301, a.n1302, a.n1303, a.n1304, a.n1305, a.n1306, a.n1307, a.n1401, a.n1402, " +
                                             "a.n1501, a.n1601, a.G102, a.G202, a.G302, a.G402, a.G502, a.G602, a.G101, a.G201, a.G301, a.G401, a.G501, a.G601, a.n1801, a.n1802, a.n1803, a.n1901, a.n1902, a.n1903, a.n1904, a.n2001,a.n2004, " +
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
                /////////////
            else if (SMTP == "cvx")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.TIT2, a.n0101, a.n0102, a.n0201, a.n0202, a.n0203, a.n0301, a.n0401,a.n0501 , a.n0701, a.n0702, a.n0703, " +
                                             "a.n0801, a.n0901,a.n1001,a.n1002,a.n1003,a.n1004,a.n1005,a.n1006,a.n1101, "+                                             
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
            else if (SMTP == "col")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.TIT1, a.TIT2, a.TIT3, a.TIT4, a.n0101, a.n0201, a.n0301, a.n0401, a.n0404, a.n0501, a.n0601, a.n1101, a.n1102," +
                                             "a.n1201, a.n1202, a.n1203, a.n1301, a.n1302, a.n1303, a.n1401 , a.n1402, a.n1403, " +
                                             "a.n1501, a.n1502, a.n1503, a.n1504, a.n1505, " +
                                             "a.n1601, a.n1701, a.n1702, a.n1703, " +
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
            else if (SMTP == "edc")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.TIT1, a.TIT2, a.TIT3, a.n0101, a.n0201, a.n0202, a.n0203, a.n0301, a.n0401, a.n0501, a.n0601, a.n0602, a.n0603, a.n0604, a.n0605, " +
                                             "a.n0701, a.n0702, a.n0703, a.n0704, a.n0705, a.n0706, a.n0707, a.n0708, a.n0709, a.n0710,a.n0711, a.n0712, a.n0713, a.n0714, a.n0715, a.n0716, a.n0717, a.n0718, a.n0719, a.n0720, " +
                                             "a.n0801, a.n0802, a.n1001, a.n1101, a.n1102, a.n1103, a.n1104,a.n1105, a.n1106, a.n1201, " +
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
                ///////////////////////////// edc DB 0901 값 확인 
            else if (SMTP == "esp")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.TIT1, a.n0101, a.n0102, a.n0201, a.n0202, a.n0203, a.n0301, a.n0401, a.n0501, a.n0601, a.n0603," +
                                             "a.n0701, a.n0702, a.n0703, a.n0704, a.n0705, a.n0801, a.n0802, a.n0803, a.n0804, a.n0805, a.n0901,a.n0902,a.n1001,a.n1002,a.n1101,a.n1102, " +                                             
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
                
            else if (SMTP == "kdn")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.TIT1,a.TIT2,a.TIT3, a.n0101, a.n0102, a.n0301, a.n0401, a.n0402, a.n0501, a.n0502, a.n0601, " +
                                             "a.n0701, a.n0702,a.n0703,a.n0704, a.n0801, a.n0802, a.n0804, a.n0806,a.n0808,a.n0810,a.n0812, " +
                                             "a.n0901, a.n0902, a.n1001, " +                                             
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
            
            else if (SMTP == "lvh")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.n0101, a.n0102, a.n0103, a.n0201, a.n0301, a.n0302, a.n0303, a.n0401, a.n0501, a.n0502, a.n0601, a.n0602, a.n0701, a.n0702, " +
                                             "a.n0801, a.n0901, a.n1001, a.n1002, a.n1101, a.n1102, a.n1201, a.n1301,a.n1302,a.n1303, a.n1401, " +
                                             "a.n1501, a.n1502, a.n1503, a.n1504, a.n1601, " +                                                                                          
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }

            ////쿼리점검
            else if (SMTP == "lvi")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.n0101, a.n0201, a.n0202, a.n0203, a.n0301, a.n0302, a.n0303, a.n0401, a.n0501, a.n0601, a.n0602, a.n0701, a.n0702, a.n0703, a.n0704, " +
                                             "a.n0801, a.n0802, a.n0803, a.n0804, a.n0901, a.ECTX, " +                                             
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
            else if (SMTP == "lvm")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.n0102, a.n0301, a.n0302, a.n0303, a.n0401, a.n0402, a.n0403, a.n0501, a.n0601, " +
                                             "a.n0701, a.n0702, a.n0801, a.n0802, a.n0901, a.n0902, a.n1001, a.n1002, a.n1101, a.n1102, a.n1201, " +                                             
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
            else if (SMTP == "ovc")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.TIT2, a.n0101, a.n0201, a.n0301, a.n0302, a.n0303, a.n0304, a.n0305, a.n0306, a.n0401, a.n0402, a.n0403, a.n0404, " +
                                             "a.n0501, a.n0601, a.n0701, a.n0702, a.n0703, a.n0704, a.n0705, a.n0706, a.n0707, a.n0708, " +
                                             "a.n0709, a.n0710, a.n0711, a.n0712, a.n0713, a.n0714, a.n0715, a.n0716, a.n0801, " +
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
            else if (SMTP == "prs")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.TIT1, a.TIT2, a.n0101, a.n0201, a.n0202, a.n0301, a.n0401, a.n0402, a.n0403, a.n0404, a.n0405, a.n0406, " +
                                             "a.n0501, a.n1101, a.n1102, a.n1103, a.n0701, a.n0702, a.n0801, a.n0802, a.n0901, a.n0902, a.n1001, " +
                                             "a.n1201, a.n1202, a.n1203, a.n1204, " + 
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
            else if (SMTP == "rtc")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.TIT1, a.TIT2, a.TIT3, a.n0101, a.n0201, a.n0501, a.n0601, a.n0602, a.n0603, a.n0701, a.n0801, " +
                                             "a.n1101, a.n1102, a.n1103, a.n1104, a.n1105, a.n1106, a.n1201, a.n1301, a.n1302, " +
                                             "a.n1401, a.n1402, a.n1403, a.n1501, a.n1502, a.n1503, a.n1601, a.n1602, a.n1603, " +
                                             "a.n1701, a.n1702, a.n1703, a.n1704, a.n1705, a.n1801, a.n1901, a.n1902, a.n1903, " +
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }

                /////////////////////////////
            else if (SMTP == "stm")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.TIT1, a.TIT2, a.TIT3, a.n0101, a.n0102, a.n0201, a.n0202, a.n0203, a.n0301, a.n0302, a.n0501, a.n0502, a.n0503, a.n0504, a.n0505, a.n0506, " +
                                             "a.n0601, a.n0701, a.n0801, a.n0806, a.n0802, a.n0803, a.n0804, a.n0901, a.n0902, a.n0903, a.n1006, " +
                                             "a.n1101, a.n1102, a.n1201, a.n1202, a.n1301, a.n1302, a.n1401, " +                                             
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
            else if (SMTP == "stg")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.TIT1, a.TIT2, a.TIT3, a.n0301, a.n0401, a.n0402, a.n0501, a.n0502, a.n0601, a.n0701, a.n0801, a.n0802, " +
                                             "a.n0901, a.n0902, a.n0903, a.n0904, a.n0905, a.n0906, a.n1001, a.n1101, " +                                             
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
            else if (SMTP == "tst")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.TIT2, a.TIT1, a.n0101, a.n0102, a.n0201, a.n0301, a.n0302, a.n0303, a.n0401, a.n0402, a.n0601, a.n0701, " +
                                             "a.n0801, a.n0802, a.n0803, a.n0804, a.n0805, a.n0806, a.n0807, a.n0808, a.n0809, a.n0901, a.n0902, " +                                             
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
            else if (SMTP == "ubc")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.TIT1, a.TIT2, a.n0101, a.n0102, a.n0201, a.n0301, a.n0302, a.n0303, a.n0401, a.n0402, a.n0501, a.n0502, a.n0601, a.n0602, " +
                                             "a.n0701, a.n0801, a.n0901, a.n0902, a.n0903, a.n0904, a.n0905, a.n0906, a.n0907, a.n0908, a.n0909, a.n1001, a.n1002, " +
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
            else if (SMTP == "ubt")
            {
                sql = string.Format("select  a.ptno, b.pano, b.PANM, b.PSEX, b.PAGE, b.ABLK, b.NBLK, " +
                                             "a.TIT1, a.TIT2, a.n0101, a.n0102, a.n0201, a.n0202, a.n0301, a.n0203, a.n0401, a.n0501, a.n0601, " +
                                             "a.A101, a.A102, a.A201, a.A202, a.A301, a.A302, a.A401, a.A402, a.A501, a.A502, a.A601, a.A602,a.A701, a.A702, a.A801, a.A802, a.A901, a.A902 " + 
                                             "FROM {0} a, pisdig001 b where a.PTNO = b.PTNO and b.UPDT between '{1}' and '{2}' "
                                             , strTable, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
           
            else if (SMTP == "int")
            {
                sql = string.Format("select ptno, pano, PANM, PSEX, PAGE, ABLK, NBLK, OGTP, DEPT, GRTX, DITX, TRYN " +
                                    "FROM pisdig001 WHERE INTEREST = '1' and UPDT between '{0}' and '{1}' ",
                                    dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            }
            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                if (SMTP == "lng")
                {
                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";
                    //////////////////////////////////////////////////////////////////////////
                    

                    if (dr[13].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[12].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[13].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[12].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[15].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[14].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[15].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[14].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[17].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[16].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[17].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[16].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[19].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[18].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[19].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[18].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[21].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[20].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[21].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[20].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[23].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[22].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[23].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[22].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[25].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[24].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[25].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[24].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[27].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[26].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[27].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[26].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[29].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[28].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[29].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[28].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9

                    dgvList.Rows.Add(dr[0].ToString(),
                                     dr[1].ToString(),
                                     dr[2].ToString(),
                                     dr[3].ToString(),
                                     dr[4].ToString(),
                                     dr[5].ToString(),
                                     dr[6].ToString(),
                                     dr[7].ToString().Replace("^", "'"),
                                     dr[8].ToString().Replace("^", "'"),
                                     dr[9].ToString().Replace("^", "'"),
                                     dr[10].ToString().Replace("^", "'"),
                                     dr[11].ToString().Replace("^", "'"),
                                     strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9//추가처방
                                     );
                }
                
                else if (SMTP == "brs")
                {
                    

                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";
                    //////////////////////////////////////////////////////////////////////////


                    if (dr[114].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[113].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[114].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[113].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[116].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[115].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[116].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[115].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[118].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[117].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[118].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[117].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[120].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[119].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[120].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[119].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[122].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[121].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[122].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[121].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[124].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[123].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[124].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[123].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[126].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[125].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[126].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[125].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[128].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[127].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[128].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[127].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[130].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[129].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[130].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[129].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9
                                      

                    if ( dr[58].ToString() == "positive" || dr[59].ToString() == "positive" || dr[60].ToString() == "positive" || dr[61].ToString() == "positive" || dr[62].ToString() == "positive" || dr[63].ToString() == "positive")
                    {
                        ms = "positive";
                    }
                    else
                    {
                        ms = "negative";
                    }

                    if (dr[58].ToString() == "positive")
                    {
                        mn1 = dr[64].ToString() + ",";
                    }
                    else
                    {
                        mn1 = "";
                    }
                    if (dr[59].ToString() == "positive")
                    {
                        mn2 = dr[65].ToString() + ",";
                    }
                    else
                    {
                        mn2 = "";
                    }
                    if (dr[60].ToString() == "positive")
                    {
                        mn3 = dr[66].ToString() + ",";
                    }
                    else
                    {
                        mn3 = "";
                    }
                    if (dr[61].ToString() == "positive")
                    {
                        mn4 = dr[67].ToString() + ",";
                    }
                    else
                    {
                        mn4 = "";
                    }
                    if (dr[62].ToString() == "positive")
                    {
                        mn5 = dr[68].ToString() + ",";
                    }
                    else
                    {
                        mn5 = "";
                    }
                    
                    if (dr[63].ToString() == "positive")
                    {
                        mn6 = dr[69].ToString();
                    }
                    else
                    {
                        mn6 = "";
                    }


                    string dms;
                    string dmn1 = "", dmn2 = "", dmn3 = "", dmn4 = "", dmn5 = "", dmn6 = "";
                    

                    if (dr[92].ToString() == "positive" || dr[93].ToString() == "positive" || dr[94].ToString() == "positive" || dr[95].ToString() == "positive" || dr[96].ToString() == "positive" || dr[97].ToString() == "positive")
                    {
                        dms = "positive";
                    }
                    else
                    {
                        dms = "negative";
                    }

                    if (dr[92].ToString() == "positive")
                    {
                        dmn1 = dr[98].ToString() + ",";
                    }
                    else
                    {
                        dmn1 = "";
                    }
                    if (dr[93].ToString() == "positive")
                    {
                        dmn2 = dr[99].ToString() + ",";
                    }
                    else
                    {
                        dmn2 = "";
                    }
                    if (dr[94].ToString() == "positive")
                    {
                        dmn3 = dr[100].ToString() + ",";
                    }
                    else
                    {
                        dmn3 = "";
                    }
                    if (dr[95].ToString() == "positive")
                    {
                        dmn4 = dr[101].ToString() + ",";
                    }
                    else
                    {
                        dmn4 = "";
                    }
                    if (dr[96].ToString() == "positive")
                    {
                        dmn5 = dr[102].ToString() + ",";
                    }
                    else
                    {
                        dmn5 = "";
                    }

                    if (dr[97].ToString() == "positive")
                    {
                        dmn6 = dr[103].ToString();
                    }
                    else
                    {
                        dmn6 = "";
                    }
                    string size001 = "", size002 = "", size003 = "";
                    string size101 = "", size102 = "", size103 = "";
                    string size201 = "", size202 = "", size203 = "";
                    string size301 = "", size302 = "", size303 = "";
                    string size401 = "", size402 = "", size403 = "";
                    string size501 = "", size502 = "", size503 = "";
                    string size601 = "", size602 = "", size603 = "";
                    string size701 = "", size702 = "", size703 = "";
                    string size801 = "", size802 = "", size803 = "";
                    string size901 = "", size902 = "", size903 = "";

                    if (dr[18].ToString().Replace("^", "'") == "")
                    {
                        size001 = "";
                    }
                    else
                    {
                        size001 = dr[18].ToString().Replace("^", "'");
                    }
                    if (dr[19].ToString().Replace("^", "'") == "")
                    {
                        size002 = "";
                    }
                    else
                    {
                        size002 = dr[19].ToString().Replace("^", "'");
                    }
                    if (dr[20].ToString().Replace("^", "'") == "")
                    {
                        size003 = "";
                    }
                    else
                    {
                        size003 = dr[20].ToString().Replace("^", "'");
                    }

                    if (dr[21].ToString().Replace("^", "'") == "")
                    {
                        size101 = "";
                    }
                    else
                    {
                        size101 = ", " + dr[21].ToString().Replace("^", "'");
                    }
                    if (dr[22].ToString().Replace("^", "'") == "")
                    {
                        size102 = "";
                    }
                    else
                    {
                        size102 = ", " + dr[22].ToString().Replace("^", "'");
                    }
                    if (dr[23].ToString().Replace("^", "'") == "")
                    {
                        size103 = "";
                    }
                    else
                    {
                        size103 = ", " + dr[23].ToString().Replace("^", "'");
                    }

                    if (dr[24].ToString().Replace("^", "'") == "")
                    {
                        size201 = "";
                    }
                    else
                    {
                        size201 = ", " + dr[24].ToString().Replace("^", "'");
                    }
                    if (dr[25].ToString().Replace("^", "'") == "")
                    {
                        size202 = "";
                    }
                    else
                    {
                        size202 = ", " + dr[25].ToString().Replace("^", "'");
                    }
                    if (dr[26].ToString().Replace("^", "'") == "")
                    {
                        size203 = "";
                    }
                    else
                    {
                        size203 = ", " + dr[26].ToString().Replace("^", "'");
                    }

                    if (dr[27].ToString().Replace("^", "'") == "")
                    {
                        size301 = "";
                    }
                    else
                    {
                        size301 = ", " + dr[27].ToString().Replace("^", "'");
                    }
                    if (dr[28].ToString().Replace("^", "'") == "")
                    {
                        size302 = "";
                    }
                    else
                    {
                        size302 = ", " + dr[28].ToString().Replace("^", "'");
                    }
                    if (dr[29].ToString().Replace("^", "'") == "")
                    {
                        size303 = "";
                    }
                    else
                    {
                        size303 = ", " + dr[29].ToString().Replace("^", "'");
                    }

                    if (dr[30].ToString().Replace("^", "'") == "")
                    {
                        size401 = "";
                    }
                    else
                    {
                        size401 = ", " + dr[30].ToString().Replace("^", "'");
                    }
                    if (dr[31].ToString().Replace("^", "'") == "")
                    {
                        size402 = "";
                    }
                    else
                    {
                        size402 = ", " + dr[31].ToString().Replace("^", "'");
                    }
                    if (dr[32].ToString().Replace("^", "'") == "")
                    {
                        size403 = "";
                    }
                    else
                    {
                        size403 = ", " + dr[32].ToString().Replace("^", "'");
                    }

                    if (dr[33].ToString().Replace("^", "'") == "")
                    {
                        size501 = "";
                    }
                    else
                    {
                        size501 = ", " + dr[33].ToString().Replace("^", "'");
                    }
                    if (dr[34].ToString().Replace("^", "'") == "")
                    {
                        size502 = "";
                    }
                    else
                    {
                        size502 = ", " + dr[34].ToString().Replace("^", "'");
                    }
                    if (dr[35].ToString().Replace("^", "'") == "")
                    {
                        size503 = "";
                    }
                    else
                    {
                        size503 = ", " + dr[35].ToString().Replace("^", "'");
                    }

                    if (dr[36].ToString().Replace("^", "'") == "")
                    {
                        size601 = "";
                    }
                    else
                    {
                        size601 = ", " + dr[36].ToString().Replace("^", "'");
                    }
                    if (dr[37].ToString().Replace("^", "'") == "")
                    {
                        size602 = "";
                    }
                    else
                    {
                        size602 = ", " + dr[37].ToString().Replace("^", "'");
                    }
                    if (dr[38].ToString().Replace("^", "'") == "")
                    {
                        size603 = "";
                    }
                    else
                    {
                        size603 = ", " + dr[38].ToString().Replace("^", "'");
                    }

                    if (dr[39].ToString().Replace("^", "'") == "")
                    {
                        size701 = "";
                    }
                    else
                    {
                        size701 = ", " + dr[39].ToString().Replace("^", "'");
                    }
                    if (dr[40].ToString().Replace("^", "'") == "")
                    {
                        size702 = "";
                    }
                    else
                    {
                        size702 = ", " + dr[40].ToString().Replace("^", "'");
                    }
                    if (dr[41].ToString().Replace("^", "'") == "")
                    {
                        size703 = "";
                    }
                    else
                    {
                        size703 = ", " + dr[41].ToString().Replace("^", "'");
                    }

                    if (dr[42].ToString().Replace("^", "'") == "")
                    {
                        size801 = "";
                    }
                    else
                    {
                        size801 = ", " + dr[42].ToString().Replace("^", "'");
                    }
                    if (dr[43].ToString().Replace("^", "'") == "")
                    {
                        size802 = "";
                    }
                    else
                    {
                        size802 = ", " + dr[43].ToString().Replace("^", "'");
                    }
                    if (dr[44].ToString().Replace("^", "'") == "")
                    {
                        size803 = "";
                    }
                    else
                    {
                        size803 = ", " + dr[44].ToString().Replace("^", "'");
                    }

                    if (dr[45].ToString().Replace("^", "'") == "")
                    {
                        size901 = "";
                    }
                    else
                    {
                        size901 = ", " + dr[45].ToString().Replace("^", "'");
                    }
                    if (dr[46].ToString().Replace("^", "'") == "")
                    {
                        size902 = "";
                    }
                    else
                    {
                        size902 = ", " + dr[46].ToString().Replace("^", "'");
                    }
                    if (dr[47].ToString().Replace("^", "'") == "")
                    {
                        size903 = "";
                    }
                    else
                    {
                        size903 = ", " + dr[47].ToString().Replace("^", "'");
                    }
                  
                    
                    
                    dgvList.Rows.Add(dr[0].ToString(),
                                     dr[1].ToString(),
                                     dr[2].ToString(),
                                     dr[3].ToString(),
                                     dr[4].ToString(),
                                     dr[5].ToString(),
                                     dr[6].ToString(),
                                     dr[7].ToString().Replace("^", "'"),
                                     dr[8].ToString().Replace("^", "'"),
                                     dr[9].ToString().Replace("^", "'"),
                                     dr[10].ToString().Replace("^", "'"),
                                     dr[11].ToString().Replace("^", "'"),
                                     dr[12].ToString().Replace("^", "'"),
                                     dr[13].ToString().Replace("^", "'"),
                                     dr[14].ToString().Replace("^", "'"),
                                     dr[15].ToString().Replace("^", "'"),
                                     dr[16].ToString().Replace("^", "'"),
                                     dr[17].ToString().Replace("^", "'"),
                                     size001 + size101 + size201 + size301 + size401 + size501 + size601 + size701 + size801 + size901,//size1
                                     size002 + size102 + size202 + size302 + size402 + size502 + size602 + size702 + size802 + size902,//size2
                                     size003 + size103 + size203 + size303 + size403 + size503 + size603 + size703 + size803 + size903,//size3
                                     dr[48].ToString().Replace("^", "'"),
                                     dr[49].ToString().Replace("^", "'"),
                                     dr[50].ToString().Replace("^", "'"),
                                     dr[51].ToString().Replace("^", "'"),
                                     dr[52].ToString().Replace("^", "'"),
                                     dr[53].ToString().Replace("^", "'"),
                                     dr[54].ToString().Replace("^", "'"),
                                     dr[55].ToString().Replace("^", "'"),
                                     dr[56].ToString().Replace("^", "'"),
                                     dr[57].ToString().Replace("^", "'"),
                                     ms,                                     
                                     mn1 + mn2 +mn3 +mn4+mn5+mn6,                                                                          
                                     dr[70].ToString().Replace("^", "'"),
                                     dr[71].ToString().Replace("^", "'") + "T" +dr[72].ToString().Replace("^", "'"),
                                     dr[73].ToString().Replace("^", "'") + "N" +dr[74].ToString().Replace("^", "'"),
                                     dr[76].ToString().Replace("^", "'") + "M" +dr[77].ToString().Replace("^", "'"),
                                     dr[79].ToString().Replace("^", "'"),
                                     dr[81].ToString().Replace("^", "'"),
                                     dr[82].ToString().Replace("^", "'"),
                                     dr[88].ToString().Replace("^", "'") + " " + dr[89].ToString().Replace("^","'"),
                                     dr[90].ToString().Replace("^", "'"),
                                     dr[91].ToString().Replace("^", "'"),
                                     dms,//margin status
                                     dmn1 + dmn2 + dmn3+ dmn4 + dmn5 + dmn6,//margin name
                                     dr[104].ToString().Replace("^", "'"),
                                     strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9//추가처방

                                     );
                }
                else if (SMTP == "cvx")
                {

                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";
                    //////////////////////////////////////////////////////////////////////////


                    if (dr[29].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[28].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[29].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[28].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[31].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[30].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[31].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[30].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[33].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[32].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[33].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[32].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[35].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[34].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[35].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[34].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[37].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[36].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[37].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[36].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[39].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[38].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[39].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[38].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[41].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[40].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[41].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[40].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[43].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[42].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[43].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[42].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[45].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[44].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[45].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[44].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9

                    
                    string stradd1 = "", stradd2 = "", stradd3 = "", stradd4 = "", stradd5 = "";
                    
                    if (dr[21].ToString() == "")
                    {
                        stradd1 = "";                        
                    }
                    else
                    {
                        stradd1 = dr[21].ToString().Replace("^","'") + ", ";                        
                    }

                    if (dr[22].ToString() == "")
                    {
                        stradd2 = "";
                    }
                    else
                    {
                        stradd2 = dr[22].ToString().Replace("^", "'") + ", ";
                    }

                    if (dr[23].ToString() == "")
                    {
                        stradd3 = "";
                    }
                    else
                    {
                        stradd3 = dr[23].ToString().Replace("^", "'") + ", ";
                    }

                    if (dr[24].ToString() == "")
                    {
                        stradd4 = "";
                    }
                    else
                    {
                        stradd4 = dr[24].ToString().Replace("^", "'") + ", ";
                    }

                    if (dr[25].ToString() == "")
                    {
                        stradd5 = "";
                    }
                    else
                    {
                        stradd5 = dr[26].ToString().Replace("^", "'");
                    }


                    dgvList.Rows.Add(dr[0].ToString().Replace("^", "'"),
                                     dr[1].ToString().Replace("^", "'"),
                                     dr[2].ToString().Replace("^", "'"),
                                     dr[3].ToString().Replace("^", "'"),
                                     dr[4].ToString().Replace("^", "'"),
                                     dr[5].ToString().Replace("^", "'"),
                                     dr[6].ToString().Replace("^", "'"),
                                     dr[7].ToString().Replace("^", "'"),
                                     dr[8].ToString().Replace("^", "'"),
                                     dr[9].ToString().Replace("^", "'"),
                                     dr[10].ToString().Replace("^", "'"),
                                     dr[11].ToString().Replace("^", "'"),
                                     dr[12].ToString().Replace("^", "'"),
                                     dr[13].ToString().Replace("^", "'"),
                                     dr[14].ToString().Replace("^", "'"),
                                     dr[15].ToString().Replace("^", "'"),
                                     dr[16].ToString().Replace("^", "'"),
                                     dr[17].ToString().Replace("^", "'"),
                                     dr[18].ToString().Replace("^", "'"),
                                     dr[19].ToString().Replace("^", "'"),
                                     dr[20].ToString().Replace("^", "'"),
                                     stradd1 + stradd2 + stradd3 + stradd4 + stradd5,
                                     dr[27].ToString().Replace("^", "'"),
                                     strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9
                                     );
                }

                else if (SMTP == "col")
                {
                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";
                    //////////////////////////////////////////////////////////////////////////

                    
                    if (dr[39].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[38].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[39].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[38].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[41].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[40].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[41].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[40].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[43].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[42].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[43].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[42].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[45].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[44].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[45].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[44].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[47].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[46].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[47].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[46].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[49].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[48].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[49].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[48].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[51].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[50].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[51].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[50].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[53].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[52].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[53].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[52].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[55].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[54].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[55].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[54].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9

                    string size;
                    if (dr[10].ToString().Replace("^", "'") == "early")
                    {
                        size = dr[15].ToString().Replace("^", "'");

                    }
                    else
                    {
                        size = dr[14].ToString().Replace("^", "'");
                    }
                    string emp;
                    
                    if (dr[18].ToString().Replace("^", "'") == "Present")
                    {
                        emp = dr[19].ToString().Replace("^", "'");
                    }
                    else
                    {
                        emp = "0";
                    }

                    string mgn = "", mgn1 = "", mgn2 = "", mgn3 = "";
                    string mgs = "";

                    string strmg1 = dr[29].ToString().Replace("^", "'");                    
                    string strmg2 = dr[32].ToString().Replace("^", "'");


                    bool mg1 = strmg1.Contains("Uninvolved");
                    bool mg2 = strmg2.Contains("Uninvolved");
                    if (mg1 == true && mg2 == true)
                    {
                        mgs = "UnInvolved";
                        mgn = "";
                    }
                    else
                    {
                        mgs = "Involved";
                        if (mg1 == false)
                        {
                            if (dr[30].ToString().Replace("^", "'") == "")
                            {
                                mgn1 = " -Proximal";
                            }
                            if (dr[31].ToString().Replace("^", "'") == "")
                            {
                                mgn2 = " -Distal";
                            }
                        }
                        if (mg2 == false)
                        {
                            mgn3 = " -Circumferenitial";
                        }

                        mgn = mgn1 + mgn2 + mgn3;


                    }
                    string stradd1 = "", stradd2 = "", stradd3 = "";
                    if (dr[35].ToString().Replace("^", "'") == "")
                    {
                        stradd1 = "";
                    }
                    else
                    {
                        stradd1 = "-tumor budding : " + dr[35].ToString().Replace("^", "'") + ", ";
                    }

                    if (dr[36].ToString().Replace("^", "'") == "")
                    {
                        stradd2 = "";
                    }
                    else
                    {
                        stradd2 = "-inflammation : " + dr[36].ToString().Replace("^", "'") + ", ";
                    }


                    if (dr[37].ToString().Replace("^", "'") == "")
                    {
                        stradd3 = "";
                    }
                    else
                    {
                        stradd3 = "-other findings : " + dr[37].ToString().Replace("^", "'");
                    }
                    
                    

                   dgvList.Rows.Add(dr[0].ToString(),
                                     dr[1].ToString(),
                                     dr[2].ToString(),
                                     dr[3].ToString(),
                                     dr[4].ToString(),
                                     dr[5].ToString(),
                                     dr[6].ToString(),
                                     dr[8].ToString().Replace("^", "'") + " " + dr[9].ToString().Replace("^","'"),
                                     dr[11].ToString().Replace("^", "'"),
                                     dr[12].ToString().Replace("^", "'"),
                                     dr[13].ToString().Replace("^", "'"),
                                     size,
                                     dr[16].ToString().Replace("^", "'"),
                                     dr[17].ToString().Replace("^", "'"),
                                     emp,                                                                          
                                     dr[20].ToString().Replace("^", "'"),
                                     dr[21].ToString().Replace("^", "'"),
                                     dr[22].ToString().Replace("^", "'"),
                                     dr[23].ToString().Replace("^", "'"),
                                     dr[24].ToString().Replace("^", "'"),
                                     dr[25].ToString().Replace("^", "'"),
                                     dr[26].ToString().Replace("^", "'"),
                                     dr[27].ToString().Replace("^", "'"),
                                     dr[28].ToString().Replace("^", "'"),
                                     mgs,
                                     mgn,
                                     dr[34].ToString().Replace("^", "'"),
                                     stradd1 + stradd2 + stradd3,
                                     strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9

                                  
                                    
                                     

                                     );
                }
                else if (SMTP == "edc")
                {
                    string depth1 = "", depth2="";
                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";

                    if (dr[20].ToString().Replace("^", "'") == ">50% myometrial invasion")
                    {
                        depth1 = ">50%";
                    }
                    else
                    {
                        depth1 = "<50%";
                    }

                    //////////////////////////////////////////////////////////////////////////

                    if (dr[53].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[52].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[53].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[52].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[55].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[54].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[55].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[54].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[57].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[56].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[57].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[56].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[59].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[58].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[59].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[58].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[61].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[60].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[61].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[60].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[63].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[62].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[63].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[62].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[65].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[64].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[65].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[64].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[67].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[66].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[67].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[66].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[69].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[68].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[69].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[68].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9
                    
                    string stradd1 = "", stradd2 = "", stradd3 = "", stradd4 = "", stradd5 = "";
                    if (dr[45].ToString().Replace("^", "'") == "")
                    {
                        stradd1 = "";
                    }
                    else
                    {
                        stradd1 = dr[45].ToString().Replace("^", "'") + ", ";
                    }
                    if (dr[46].ToString().Replace("^", "'") == " ")
                    {
                        stradd2 = "";
                    }
                    else
                    {
                        stradd2 = dr[46].ToString().Replace("^", "'") + ", ";
                    }
                    if (dr[47].ToString().Replace("^", "'") == " ")
                    {
                        stradd3 = "";
                    }
                    else
                    {
                        stradd3 = dr[47].ToString().Replace("^", "'") + ", ";
                    }
                    if (dr[48].ToString().Replace("^", "'") == " ")
                    {
                        stradd4 = "";
                    }
                    else
                    {
                        stradd4 = dr[48].ToString().Replace("^", "'") + ", ";
                    }
                    if (dr[49].ToString().Replace("^", "'") == "")
                    {
                        stradd5 = "";
                    }
                    else
                    {
                        stradd5 = dr[50].ToString().Replace("^", "'");
                        
                    }

                    dgvList.Rows.Add(dr[0].ToString(),
                                      dr[1].ToString(),
                                      dr[2].ToString(),
                                      dr[3].ToString(),
                                      dr[4].ToString(),
                                      dr[5].ToString(),
                                      dr[6].ToString(),
                                      dr[8].ToString().Replace("^", "'") + " " + dr[9].ToString().Replace("^", "'"),
                                      dr[10].ToString().Replace("^", "'"),
                                      dr[11].ToString().Replace("^", "'"),
                                      dr[12].ToString().Replace("^", "'"),
                                      dr[13].ToString().Replace("^", "'"),
                                      dr[14].ToString().Replace("^", "'"),
                                      dr[15].ToString().Replace("^", "'"),
                                      dr[16].ToString().Replace("^", "'"),
                                      dr[17].ToString().Replace("^", "'"),
                                      dr[18].ToString().Replace("^", "'"),
                                      dr[19].ToString().Replace("^", "'"),
                                      depth1,
                                      dr[21].ToString().Replace("^", "'"),
                                      dr[22].ToString().Replace("^", "'"),
                                      dr[23].ToString().Replace("^", "'"),
                                      dr[24].ToString().Replace("^", "'"),
                                      dr[25].ToString().Replace("^", "'"),
                                      dr[26].ToString().Replace("^", "'"),
                                      dr[27].ToString().Replace("^", "'"),
                                      dr[28].ToString().Replace("^", "'"),
                                      dr[29].ToString().Replace("^", "'"),
                                      dr[30].ToString().Replace("^", "'"),
                                      dr[31].ToString().Replace("^", "'"),
                                      dr[32].ToString().Replace("^", "'"),
                                      dr[33].ToString().Replace("^", "'"),
                                      dr[34].ToString().Replace("^", "'"),
                                      dr[35].ToString().Replace("^", "'"),
                                      dr[36].ToString().Replace("^", "'"),
                                      dr[37].ToString().Replace("^", "'"),
                                      dr[38].ToString().Replace("^", "'"),
                                      dr[39].ToString().Replace("^", "'"),
                                      dr[40].ToString().Replace("^", "'"),
                                      dr[41].ToString().Replace("^", "'"),
                                      dr[42].ToString().Replace("^", "'"),
                                      dr[43].ToString().Replace("^", "'"),
                                      dr[44].ToString().Replace("^", "'") ,
                                      stradd1 + stradd2 + stradd3 + stradd4 + stradd5,
                                      dr[51].ToString().Replace("^", "'"),
                                      strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9

                                      );
                }

                else if (SMTP == "esp")
                {

                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";

                    string mgn ="", mgn1 = "", mgn2 = "",mgn3="";
                    string mgs = "";

                    string strmg1 = dr[18].ToString().Replace("^", "'");
                    string strmg2 = dr[21].ToString().Replace("^","'");
                    
                    
                    bool mg1 = strmg1.Contains("Uninvolved");
                    bool mg2 = strmg2.Contains("Uninvolved");
                    if (mg1 == true && mg2 == true)
                    {
                        mgs = "UnInvolved";
                        mgn = "";
                    }
                    else
                    {
                        mgs = "Involved";
                        if (mg1 == false)
                        {
                            if (dr[19].ToString().Replace("^", "'") == "")
                            {
                                mgn1 = " -Proximal";
                            }
                            if (dr[20].ToString().Replace("^", "'") == "")
                            {
                                mgn2 = " -Distal";
                            }
                        }
                        if (mg2 == false)
                        {
                            mgn3 = " -Circumferenitial";
                        }

                        mgn = mgn1 + mgn2 + mgn3;


                    }
                    

                    //////////////////////////////////////////////////////////////////////////

                    if (dr[35].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[34].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[35].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[34].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[37].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[36].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[37].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[36].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[39].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[38].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[39].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[38].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[41].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[40].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[41].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[40].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[43].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[42].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[43].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[42].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[45].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[44].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[45].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[44].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[47].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[46].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[47].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[46].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[49].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[48].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[49].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[48].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[51].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[50].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[51].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[50].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9

                    dgvList.Rows.Add(dr[0].ToString(),
                                      dr[1].ToString(),
                                      dr[2].ToString(),
                                      dr[3].ToString(),
                                      dr[4].ToString(),
                                      dr[5].ToString(),
                                      dr[6].ToString(),
                                      dr[7].ToString().Replace("^", "'"),
                                      dr[8].ToString().Replace("^", "'"),
                                      dr[9].ToString().Replace("^", "'"),
                                      dr[10].ToString().Replace("^", "'"),
                                      dr[11].ToString().Replace("^", "'"),
                                      dr[12].ToString().Replace("^", "'"),
                                      dr[13].ToString().Replace("^", "'"),
                                      dr[14].ToString().Replace("^", "'"),
                                      dr[15].ToString().Replace("^", "'"),
                                      dr[17].ToString().Replace("^", "'"),
                                      mgs, //maragin name 
                                      mgn, //postive margin 
                                      dr[23].ToString().Replace("^", "'"),
                                      dr[28].ToString().Replace("^", "'"),
                                      dr[29].ToString().Replace("^", "'"),
                                      dr[30].ToString().Replace("^", "'"),
                                      dr[31].ToString().Replace("^", "'"),
                                      dr[32].ToString().Replace("^", "'"),
                                      dr[33].ToString().Replace("^", "'"),
                                      strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9

                                      );
                }

                else if (SMTP == "kdn")
                {

                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";
                    string mgs = "";
                    //////////////////////////////////////////////////////////////////////////

                    if (dr[33].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[32].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[33].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[32].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[35].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[34].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[35].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[34].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[37].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[36].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[37].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[36].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[39].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[38].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[39].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[38].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[41].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[40].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[41].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[40].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[43].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[42].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[43].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[42].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[45].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[44].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[45].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[44].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[47].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[46].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[47].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[46].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[49].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[48].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[49].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[48].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9

                    string sf = "";
                    if (dr[13].ToString() == "Present")
                        sf = dr[14].ToString().Replace("^", "'");
                    else
                        sf = "0";

                    string tn = "";
                    if (dr[15].ToString() == "Present")
                        tn = dr[16].ToString().Replace("^", "'");
                    else
                        tn = "0";

                    

                    string TNM;
                    if (dr[18].ToString().Replace("^", "'") == "Tumor extension into")
                    {
                        TNM = dr[21].ToString().Replace("^", "'");
                    }
                    else
                    {
                        TNM = dr[20].ToString().Replace("^", "'");
                    }
                    string ms1="",ms2="",ms3="",ms4="",ms5="",ms6="";
                    if (dr[22].ToString().Replace("^", "'") == "Cannot be assessed")
                    {
                        mn1 = "";
                        mn2 = "";
                        mn3 = "";
                        mn4 = "";
                        mn5 = "";
                        mn6 = "";
                    }
                    else
                    {
                        
                        string strmg1 = dr[23].ToString().Replace("^", "'");
                        string strmg2 = dr[24].ToString().Replace("^", "'");
                        string strmg3 = dr[25].ToString().Replace("^", "'");
                        string strmg4 = dr[26].ToString().Replace("^", "'");
                        string strmg5 = dr[27].ToString().Replace("^", "'");
                        string strmg6 = dr[28].ToString().Replace("^", "'");
                                                

                        bool mg1 = strmg1.Contains("Uninvolved");
                        bool mg2 = strmg2.Contains("Uninvolved");
                        bool mg3 = strmg3.Contains("Uninvolved");
                        bool mg4 = strmg4.Contains("Uninvolved");
                        bool mg5 = strmg5.Contains("Uninvolved");
                        bool mg6 = strmg6.Contains("Uninvolved");

                        
                        if (mg1 == true && mg2 == true && mg3 == true && mg4 == true && mg5 == true && mg6 == true)
                        {
                            mgs = "Uninvolved";

                        }
                        else
                        {
                            mgs = "involved";
                        }
                        if (mg1 == true)
                        {
                            mn1 = "";
                        }
                        else
                        {
                            mn1 = "Renal parenchymal margin,";
                        }

                        if (mg2 == true)
                        {
                            mn2 = "";
                        }
                        else
                        {
                            mn2 = " Renal capsular margin,";
                        }

                        if (mg3 == true)
                        {
                            mn3 = "";
                        }
                        else
                        {
                            mn3 = " Perinephric fat margin,";
                        }

                        if (mg4 == true)
                        {
                            mn4 = "";
                        }
                        else
                        {
                            mn4 = " Gerota fascial margin,";
                        }

                        if (mg5 == true)
                        {
                            mn5 = "";
                        }
                        else
                        {
                            mn5 = " Renal vein margin,";
                        }

                        if (mg6 == true)
                        {
                            mn6 = "";
                        }
                        else
                        {
                            mn6 = " Ureteral margin";
                        }
                    }


                        dgvList.Rows.Add(dr[0].ToString(),
                                       dr[1].ToString(),
                                       dr[2].ToString(),
                                       dr[3].ToString(),
                                       dr[4].ToString(),
                                       dr[5].ToString(),
                                       dr[6].ToString(),
                                       dr[7].ToString().Replace("^", "'"),
                                       dr[8].ToString().Replace("^", "'") +" " + dr[9].ToString().Replace("^", "'"),
                                       dr[10].ToString().Replace("^", "'"),
                                       dr[11].ToString().Replace("^", "'"),
                                       dr[12].ToString().Replace("^", "'"),
                                       sf,
                                       tn,
                                       dr[17].ToString().Replace("^", "'"),
                                       TNM,
                                       mgs, //margin name 수정
                                       mn1 + mn2 + mn3 + mn4 + mn5 + mn6,
                                       dr[29].ToString().Replace("^", "'"),
                                       dr[30].ToString().Replace("^", "'"),
                                       dr[31].ToString().Replace("^", "'"),
                                       strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9
                                      

                                      );
                }

                else if (SMTP == "lvh")     //완료
                {

                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";

                    //////////////////////////////////////////////////////////////////////////

                    if (dr[38].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[37].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[38].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[37].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[40].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[39].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[40].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[39].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[42].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[41].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[42].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[41].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[44].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[43].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[44].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[43].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[46].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[45].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[46].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[45].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[48].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[47].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[48].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[47].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[50].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[49].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[50].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[49].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[52].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[51].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[52].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[51].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[54].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[53].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[54].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[53].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9


                    string tn = "", hop = "", fcwt="" , ci="", rm="";
                    if (dr[15].ToString() == "present")
                        tn = dr[16].ToString().Replace("^", "'");
                    else
                        tn = "0";
                    
                    if (dr[17].ToString() == "present")
                        hop = dr[18].ToString().Replace("^", "'");
                    else
                        hop = "0";

                    if (dr[23].ToString() == "present")
                        fcwt = dr[24].ToString().Replace("^", "'");
                    else if( dr[23].ToString() =="not applicable")
                        fcwt = "NA";
                    else
                        fcwt = "0";

                    if (dr[26].ToString().Replace("^", "'") == "with")
                        ci = "present";
                    else
                        ci = "absent";
                    //rm

                    string grs = dr[28].ToString().Replace("^", "'");
                    //int grsp = grs.IndexOf("(");                    
                    //string grs1 = grs.Substring(0, grsp);
                    int rmn;                    
                    string rm1 = "", rm2 = "";

                    if (dr[28].ToString().Replace("^", "'").Length > 2 && dr[30].ToString().Replace("^", "'").Length > 2)
                    {   
                        rmn = grs.IndexOf("(");
                        rm1 = grs.Substring(0, rmn);
                        rm2 = dr[30].ToString().Replace("^", "'");
                        rm = rm1 + ", " + rm2;
                    }
                    else if (dr[28].ToString().Replace("^", "'").Length > 2 && dr[30].ToString().Replace("^", "'").Length < 2)
                    {
                        rmn = grs.IndexOf("(");
                        rm1 = grs.Substring(0, rmn);   
                        rm = rm1;
                    }
                    else if (dr[28].ToString().Replace("^", "'").Length < 2 && dr[30].ToString().Replace("^", "'").Length > 2)
                    {

                        rm2 = dr[30].ToString().Replace("^", "'");
                        rm = rm2;
                    }
                    else
                    {
                        rm = "";
                    }
                    
                    dgvList.Rows.Add(dr[0].ToString(),
                                      dr[1].ToString(),
                                      dr[2].ToString(),
                                      dr[3].ToString(),
                                      dr[4].ToString(),
                                      dr[5].ToString(),
                                      dr[6].ToString(),
                                      dr[7].ToString().Replace("^", "'"),
                                      dr[8].ToString().Replace("^", "'"),
                                      dr[9].ToString().Replace("^", "'"),//Tumor site
                                      dr[10].ToString().Replace("^", "'"),
                                      dr[11].ToString().Replace("^", "'"),
                                      dr[12].ToString().Replace("^", "'"),
                                      dr[13].ToString().Replace("^", "'"),
                                      dr[14].ToString().Replace("^", "'"),
                                      tn,
                                      hop,
                                      dr[19].ToString().Replace("^", "'"),
                                      dr[20].ToString().Replace("^", "'"),
                                      dr[21].ToString().Replace("^", "'"),
                                      dr[22].ToString().Replace("^", "'"),
                                      fcwt,
                                      dr[25].ToString().Replace("^", "'"),
                                      ci,
                                      dr[27].ToString().Replace("^", "'"),
                                      rm,
                                      dr[31].ToString().Replace("^", "'"),
                                      dr[32].ToString().Replace("^", "'"),
                                      dr[33].ToString().Replace("^", "'"),
                                      dr[34].ToString().Replace("^", "'"),
                                      dr[35].ToString().Replace("^", "'"),
                                      dr[36].ToString().Replace("^", "'"),
                                      strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9
                                      );
                }

                else if (SMTP == "lvi")
                {

                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";

                    //////////////////////////////////////////////////////////////////////////

                    if (dr[29].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[28].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[29].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[28].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[31].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[30].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[31].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[30].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[33].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[32].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[33].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[32].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[35].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[34].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[35].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[34].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[37].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[36].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[37].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[36].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[39].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[38].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[39].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[38].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[41].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[40].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[41].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[40].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[43].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[42].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[43].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[42].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[45].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[44].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[45].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[44].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9


                    dgvList.Rows.Add(dr[0].ToString(),
                                      dr[1].ToString(),
                                      dr[2].ToString(),
                                      dr[3].ToString(),
                                      dr[4].ToString(),
                                      dr[5].ToString(),
                                      dr[6].ToString(),
                                      dr[7].ToString().Replace("^", "'"),
                                      dr[8].ToString().Replace("^", "'"),
                                      dr[9].ToString().Replace("^", "'"),
                                      dr[10].ToString().Replace("^", "'"),
                                      dr[11].ToString().Replace("^", "'"),
                                      dr[12].ToString().Replace("^", "'"),
                                      dr[13].ToString().Replace("^", "'"),
                                      dr[14].ToString().Replace("^", "'"),
                                      dr[15].ToString().Replace("^", "'"),
                                      dr[16].ToString().Replace("^", "'"),
                                      dr[17].ToString().Replace("^", "'"),
                                      dr[18].ToString().Replace("^", "'"),
                                      dr[20].ToString().Replace("^", "'"),
                                      dr[22].ToString().Replace("^", "'"),
                                      dr[23].ToString().Replace("^", "'"),
                                      dr[24].ToString().Replace("^", "'"),
                                      dr[25].ToString().Replace("^", "'"),
                                      dr[26].ToString().Replace("^", "'"),
                                      dr[27].ToString().Replace("^", "'"),
                                      strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9


                                      );
                }

                else if (SMTP == "lvm")
                {
                    string rsm = "";
                    if (dr[11].ToString().Length > 2 && dr[13].ToString().Length > 2)
                    {
                        rsm = dr[11].ToString().Replace("^", "'") + " " + dr[12].ToString().Replace("^", "'") + "cm), " + dr[13].ToString().Replace("^", "'");
                    }

                    else if (dr[11].ToString().Length > 2 && dr[13].ToString().Length < 2)
                    {
                        rsm = dr[11].ToString().Replace("^", "'") + " " + dr[12].ToString().Replace("^", "'") + "cm)";
                    }
                    else if (dr[11].ToString().Length < 2 && dr[13].ToString().Length > 2)
                    {
                        rsm = dr[13].ToString().Replace("^", "'");
                    }

                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";

                    //////////////////////////////////////////////////////////////////////////

                    if (dr[28].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[27].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[28].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[27].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[30].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[29].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[30].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[29].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[32].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[31].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[32].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[31].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[34].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[33].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[34].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[33].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[36].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[35].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[36].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[35].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[38].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[37].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[38].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[37].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[40].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[39].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[40].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[39].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[42].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[41].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[42].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[41].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[44].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[43].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[44].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[43].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9

                    dgvList.Rows.Add(dr[0].ToString(),
                                      dr[1].ToString(),
                                      dr[2].ToString(),
                                      dr[3].ToString(),
                                      dr[4].ToString(),
                                      dr[5].ToString(),
                                      dr[6].ToString(),
                                      dr[7].ToString().Replace("^", "'"),
                                      dr[8].ToString().Replace("^", "'"),
                                      dr[9].ToString().Replace("^", "'"),
                                      dr[10].ToString().Replace("^", "'"),
                                      rsm,
                                      dr[14].ToString().Replace("^", "'"),
                                      dr[15].ToString().Replace("^", "'"),
                                      dr[16].ToString().Replace("^", "'"),
                                      dr[17].ToString().Replace("^", "'"),
                                      dr[18].ToString().Replace("^", "'"),
                                      dr[19].ToString().Replace("^", "'"),
                                      dr[20].ToString().Replace("^", "'"),
                                      dr[21].ToString().Replace("^", "'"),
                                      dr[22].ToString().Replace("^", "'"),
                                      dr[23].ToString().Replace("^", "'"),
                                      dr[24].ToString().Replace("^", "'"),
                                      dr[25].ToString().Replace("^", "'"),
                                      dr[26].ToString().Replace("^", "'"),
                                      strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9
                                      

                                      );
                }

                else if (SMTP == "ovc")
                {


                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";

                    //////////////////////////////////////////////////////////////////////////

                    if (dr[40].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[39].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[40].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[39].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[42].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[41].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[42].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[41].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[44].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[43].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[44].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[43].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[46].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[45].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[46].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[45].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[48].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[47].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[48].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[47].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[50].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[49].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[50].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[49].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[52].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[51].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[52].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[51].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[54].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[53].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[54].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[53].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[56].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[55].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[56].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[55].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9

                    dgvList.Rows.Add(dr[0].ToString(),
                                      dr[1].ToString(),
                                      dr[2].ToString(),
                                      dr[3].ToString(),
                                      dr[4].ToString(),
                                      dr[5].ToString(),
                                      dr[6].ToString(),
                                      dr[7].ToString().Replace("^", "'"),
                                      dr[8].ToString().Replace("^", "'"),
                                      dr[9].ToString().Replace("^", "'"),
                                      dr[10].ToString().Replace("^", "'"),
                                      dr[11].ToString().Replace("^", "'"),
                                      dr[12].ToString().Replace("^", "'"),
                                      dr[13].ToString().Replace("^", "'"),
                                      dr[14].ToString().Replace("^", "'"),
                                      dr[15].ToString().Replace("^", "'"),
                                      dr[16].ToString().Replace("^", "'"),
                                      dr[17].ToString().Replace("^", "'"),
                                      dr[18].ToString().Replace("^", "'"),
                                      dr[19].ToString().Replace("^", "'"),
                                      dr[20].ToString().Replace("^", "'"),
                                      dr[21].ToString().Replace("^", "'"),
                                      dr[22].ToString().Replace("^", "'"),
                                      dr[23].ToString().Replace("^", "'"),
                                      dr[24].ToString().Replace("^", "'"),
                                      dr[25].ToString().Replace("^", "'"),
                                      dr[26].ToString().Replace("^", "'"),
                                      dr[27].ToString().Replace("^", "'"),
                                      dr[28].ToString().Replace("^", "'"),
                                      dr[29].ToString().Replace("^", "'"),
                                      dr[30].ToString().Replace("^", "'"),
                                      dr[31].ToString().Replace("^", "'"),
                                      dr[32].ToString().Replace("^", "'"),
                                      dr[33].ToString().Replace("^", "'"),
                                      dr[34].ToString().Replace("^", "'"),
                                      dr[35].ToString().Replace("^", "'"),
                                      dr[36].ToString().Replace("^", "'"),
                                      dr[37].ToString().Replace("^", "'"),
                                      dr[38].ToString().Replace("^", "'"),
                                      strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9

                                      );
                }

                else if (SMTP == "prs")
                {

                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";

                    //////////////////////////////////////////////////////////////////////////
                    
                    if (dr[35].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[34].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[35].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[34].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[37].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[36].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[37].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[36].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[39].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[38].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[39].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[38].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[41].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[40].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[41].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[40].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[43].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[42].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[43].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[42].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[45].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[44].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[45].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[44].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[47].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[46].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[47].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[46].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[49].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[48].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[49].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[48].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[51].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[50].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[51].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[50].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9
                    string grs = dr[9].ToString().Replace("^", "'");
                    int grsp = grs.IndexOf(")") +1 ;
                    int grsp1 = grs.Length - grs.LastIndexOf(")")-1;
                    string grs1 = grs.Substring(0,grs.IndexOf("("));
                    string grs2 = grs.Substring(grs.IndexOf("("), grs.IndexOf(")"));
                    string grs3 = grs.Substring( grsp, grsp1);
                    dgvList.Rows.Add(dr[0].ToString(),
                                      dr[1].ToString(),
                                      dr[2].ToString(),
                                      dr[3].ToString(),
                                      dr[4].ToString(),
                                      dr[5].ToString(),
                                      dr[6].ToString(),
                                      dr[7].ToString().Replace("^", "'"),
                                      grs1,
                                      grs2,
                                      grs3,
                                      dr[10].ToString().Replace("^", "'"),
                                      dr[11].ToString().Replace("^", "'"),
                                      dr[12].ToString().Replace("^", "'"),
                                      dr[13].ToString().Replace("^", "'"),
                                      dr[14].ToString().Replace("^", "'"),
                                      dr[15].ToString().Replace("^", "'"),
                                      dr[16].ToString().Replace("^", "'"),
                                      dr[17].ToString().Replace("^", "'"),
                                      dr[18].ToString().Replace("^", "'"),
                                      dr[19].ToString().Replace("^", "'"),
                                      "pT" + dr[20].ToString().Replace("^", "'"),
                                      "N" + dr[21].ToString().Replace("^", "'"),
                                      "M" + dr[22].ToString().Replace("^", "'"),                                     
                                      dr[23].ToString().Replace("^", "'"),
                                      dr[24].ToString().Replace("^", "'"),
                                      dr[25].ToString().Replace("^", "'"),
                                      dr[26].ToString().Replace("^", "'"),
                                      dr[27].ToString().Replace("^", "'"),
                                      dr[28].ToString().Replace("^", "'"),
                                      dr[29].ToString().Replace("^", "'"),
                                      dr[30].ToString().Replace("^", "'"),
                                      dr[31].ToString().Replace("^", "'"),
                                      dr[32].ToString().Replace("^", "'"),
                                      dr[33].ToString().Replace("^", "'"),
                                      strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9

                                      );
                }

                else if (SMTP == "rtc")
                {
                    string mgn1 = "", mgn2 = "";
                    
                    string strmg1 = dr[36].ToString().Replace("^", "'");
                    bool mg1 = strmg1.Contains("Uninvolved");
                    if (mg1 == true)
                    {
                        strmg1 = "UnInvolved, ";
                        mgn1 = "";
                    }
                    else if (mg1 == false)
                    {
                        bool mg2 = strmg1.Contains("involved");
                        if (mg2 == true)
                        {
                            strmg1 = "Involved, ";
                            mgn1 = "-Proximal";
                        }
                        else
                        {
                            strmg1 = dr[36].ToString().Replace("^", "'") + ", ";
                            mgn1 = "";
                        }
                    }

                    string strmg2 = dr[39].ToString().Replace("^", "'") + ", ";
                    bool mg3 = strmg2.Contains("Uninvolved");
                    if (mg3 == true)
                    {
                        strmg2 = "UnInvolved";
                        mgn2 = "";
                    }
                    else if (mg3 == false)
                    {
                        bool mg4 = strmg2.Contains("involved");
                        if (mg4 == true)
                        {
                            strmg2 = "Involved";
                            mgn2 = "-Circumferenital";
                        }
                        else
                        {
                            strmg2 = dr[39].ToString().Replace("^", "'") + ", ";
                            mgn2 = "";
                        }
                    }

                    

                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";
                    
                    //////////////////////////////////////////////////////////////////////////
                    if (dr[46].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[45].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[46].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[45].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[48].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[47].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[48].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[47].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[50].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[49].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[50].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[49].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[52].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[51].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[52].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[51].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[53].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[52].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[53].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[52].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[55].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[54].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[55].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[54].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[57].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[56].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[57].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[56].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[59].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[58].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[59].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[58].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[61].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[60].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[61].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[60].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9
                    string add1="", add2="", add3 ="";
                    if (dr[42].ToString().Replace("^", "'") == "")
                    {
                        add1 = "";
                    }
                    else
                    {
                        add1 = "-tumor budiing : " + dr[42].ToString().Replace("^", "'") + ", ";
                    }

                    if (dr[43].ToString().Replace("^", "'") == "")
                    {
                        add2 = "";
                    }
                    else
                    {
                        add2 = "-inflammation : " + dr[43].ToString().Replace("^", "'") + ", ";
                    }

                    if (dr[44].ToString().Replace("^", "'") == "")
                    {
                        add3 = "";
                    }
                    else
                    {
                        add3 = "-other findings : " + dr[44].ToString().Replace("^", "'");
                    }


                    dgvList.Rows.Add(dr[0].ToString(),
                                      dr[1].ToString(),
                                      dr[2].ToString(),
                                      dr[3].ToString(),
                                      dr[4].ToString(),
                                      dr[5].ToString(),
                                      dr[6].ToString(),
                                      dr[8].ToString().Replace("^", "'"),
                                      dr[10].ToString().Replace("^", "'"),
                                      dr[11].ToString().Replace("^", "'"),
                                      dr[12].ToString().Replace("^", "'"),
                                      dr[13].ToString().Replace("^", "'"),
                                      dr[16].ToString().Replace("^", "'"),
                                      dr[17].ToString().Replace("^", "'"),
                                      dr[18].ToString().Replace("^", "'") + "T" + dr[19].ToString().Replace("^", "'"),
                                      dr[20].ToString().Replace("^", "'") + "N" + dr[21].ToString().Replace("^", "'"),
                                      dr[22].ToString().Replace("^", "'") + "M" + dr[23].ToString().Replace("^", "'"),
                                      dr[24].ToString().Replace("^", "'"),
                                      dr[25].ToString().Replace("^", "'"),
                                      dr[26].ToString().Replace("^", "'") +"%",
                                      dr[27].ToString().Replace("^", "'"),
                                      dr[28].ToString().Replace("^", "'"),
                                      dr[29].ToString().Replace("^", "'"),
                                      dr[30].ToString().Replace("^", "'"),
                                      dr[31].ToString().Replace("^", "'"),
                                      dr[32].ToString().Replace("^", "'"),
                                      dr[33].ToString().Replace("^", "'"),
                                      dr[34].ToString().Replace("^", "'"),
                                      dr[35].ToString().Replace("^", "'"),
                                      strmg1+strmg2, // marginstatus
                                      mgn1 + mgn2, //postive margin name
                                      dr[41].ToString().Replace("^", "'"),
                                      add1 + add2 + add3, //additional Pathologic findings
                                      strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9
                                      
                                      

                                      );
                }

                else if (SMTP == "stm")
                {
                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";


                    string mgn1 = "";
                    string strmg1 = dr[30].ToString().Replace("^", "'");
                    
                    bool mg1 = strmg1.Contains("Uninvolved");
                    if (mg1 == true)
                    {
                        strmg1 = "UnInvolved, ";
                        
                    }
                    else if (mg1 == false)
                    {
                        bool mg2 = strmg1.Contains("Involved");
                        if (mg2 == true)
                        {
                            strmg1 = "Involved, ";
                            
                        }
                        else
                        {
                            strmg1 = dr[30].ToString().Replace("^", "'") + ", ";
                            
                        }
                    }
                    
                    if (dr[31].ToString().Replace("^", "'") == "")
                    {
                        mgn1 = "Proximal";
                    }
                    else
                    {
                        mgn1 = "Distal";
                    }

                    if (dr[31].ToString().Replace("^", "'") == "" && dr[32].ToString().Replace("^", "'") == "")
                    {
                        mgn1 = "Proximal, Distal";
                    }
                    else if (dr[31].ToString().Replace("^", "'") != "" && dr[32].ToString().Replace("^", "'") != "")
                    {
                        mgn1 = "";
                    }
                   

                    //////////////////////////////////////////////////////////////////////////
                    if (dr[42].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[41].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[42].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[41].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[44].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[43].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[44].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[43].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[46].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[45].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[46].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[45].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[48].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[47].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[48].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[47].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[50].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[49].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[50].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[49].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[52].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[51].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[52].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[51].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[54].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[53].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[54].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[53].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[56].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[55].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[56].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[55].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[58].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[57].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[58].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[57].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9

                    string gt ="",psm ="";
                    if (dr[8].ToString() == "Early")
                    {
                        gt = dr[15].ToString().Replace("^", "'");
                    }
                    else if( dr[8].ToString() =="Advanced")
                    {
                        gt = dr[16].ToString().Replace("^", "'");
                    }
                    else
                    {
                        gt="";
                    }
                    if (dr[29].ToString().Replace("^", "'") == "Involved by invasive carcinoma" || dr[29].ToString().Replace("^", "'") == "Involved by dysplasia")
                    {
                        psm = "proximal , Distal";
                    }
                    else
                    {
                        psm = "";
                    }

                    dgvList.Rows.Add(dr[0].ToString(),
                                      dr[1].ToString(),
                                      dr[2].ToString(),
                                      dr[3].ToString(),
                                      dr[4].ToString(),
                                      dr[5].ToString(),
                                      dr[6].ToString(),
                                      dr[7].ToString().Replace("^", "'") +  " gastrectomy", //수정
                                      dr[10].ToString().Replace("^", "'") + " " + dr[11].ToString().Replace("^", "'"),
                                      dr[12].ToString().Replace("^", "'"),
                                      gt,
                                      dr[17].ToString().Replace("^", "'"),
                                      dr[19].ToString().Replace("^", "'"),
                                      dr[23].ToString().Replace("^", "'"),
                                      dr[24].ToString().Replace("^", "'"),
                                      dr[26].ToString().Replace("^", "'"),//T
                                      dr[33].ToString().Replace("^", "'"),//N                                      
                                      strmg1, // marginstatus
                                      mgn1,
                                      dr[34].ToString().Replace("^", "'") ,
                                      dr[35].ToString().Replace("^", "'") ,
                                      dr[36].ToString().Replace("^", "'") ,
                                      dr[37].ToString().Replace("^", "'"),
                                      dr[38].ToString().Replace("^", "'"),
                                      dr[39].ToString().Replace("^", "'"),
                                      dr[40].ToString().Replace("^", "'"),
                                      strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9
                                     
                                      );
                }

                else if (SMTP == "stg")
                {
                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";
                    string Subtype = "";

                    if (dr[13].ToString().Replace("^", "'") == "Other")
                    {
                        Subtype = dr[14].ToString().Replace("^", "'");
                    }
                    else
                    {
                        Subtype = dr[13].ToString().Replace("^", "'");
                    }

                    //////////////////////////////////////////////////////////////////////////
                    if (dr[28].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 =  dr[27].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[28].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 =  dr[27].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[30].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[29].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[30].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[29].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[32].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[31].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[32].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[31].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[34].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[33].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[34].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[33].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[36].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[35].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[36].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[35].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[38].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[37].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[38].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[37].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[40].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[39].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[40].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[39].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[42].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[41].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[42].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[41].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[44].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[43].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[44].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[43].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9

                    dgvList.Rows.Add(dr[0].ToString(),
                                      dr[1].ToString(),
                                      dr[2].ToString(),
                                      dr[3].ToString(),
                                      dr[4].ToString(),
                                      dr[5].ToString(),
                                      dr[6].ToString(),
                                      dr[8].ToString().Replace("^", "'") + " " + dr[9].ToString().Replace("^", "'"),
                                      dr[10].ToString().Replace("^", "'"),
                                      dr[11].ToString().Replace("^", "'"),
                                      dr[12].ToString().Replace("^", "'"),
                                      Subtype,
                                      dr[15].ToString().Replace("^", "'"),
                                      dr[16].ToString().Replace("^", "'"),
                                      dr[17].ToString().Replace("^", "'") ,
                                      dr[19].ToString().Replace("^", "'") + "T" + dr[20].ToString().Replace("^", "'"),
                                      dr[21].ToString().Replace("^", "'") + "N" + dr[22].ToString().Replace("^", "'"),
                                      dr[23].ToString().Replace("^", "'") + "M" + dr[24].ToString().Replace("^", "'"),
                                      dr[25].ToString().Replace("^", "'"),
                                      dr[26].ToString().Replace("^", "'"),
                                      strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9
                                     
                                      );
                }

                else if (SMTP == "tst")
                {
                    string strATX1 = "", strATX2 = "", strATX3 = "", strATX4 = "", strATX5 = "", strATX6 = "", strATX7 = "", strATX8, strATX9 = "";
                    string mgn1="", mgn2="", mgn3="";
                    string strmg1 = dr[20].ToString().Replace("^", "'");
                    bool mg1 = strmg1.Contains("Uninvolved");
                    if (mg1 == true)
                    {
                        strmg1 = "UnInvolved, ";
                        mgn1 = "";
                    }
                    else if (mg1 == false)
                    {
                        bool mg2 = strmg1.Contains("Involved");
                        if (mg2 == true)
                        {
                            strmg1 = "Involved, ";
                            mgn1 = dr[19].ToString().Replace("^", "'") + ", ";
                        }
                        else
                        {
                            strmg1 = dr[20].ToString().Replace("^", "'") + ", "; 
                            mgn1 = "";
                        }
                    }

                    string strmg2 = dr[23].ToString().Replace("^", "'") + ", "; 
                    bool mg3 = strmg2.Contains("Uninvolved");
                    if (mg3 == true)
                    {
                        strmg2 = "UnInvolved, ";
                        mgn2 = "";
                    }
                    else if (mg3 == false)
                    {
                        bool mg4 = strmg2.Contains("Involved");
                        if (mg4 == true)
                        {
                            strmg2 = "Involved, ";
                            mgn2 = dr[22].ToString().Replace("^", "'") + ", "; 
                        }
                        else
                        {
                            strmg2 = dr[23].ToString().Replace("^", "'") + ", "; 
                            mgn2 = "";
                        }
                    }

                    string strmg3 = dr[26].ToString().Replace("^", "'");
                    bool mg5 = strmg3.Contains("Uninvolved");
                    if (mg5 == true)
                    {
                        strmg3 = "UnInvolved";
                        mgn3 = "";
                    }
                    else if (mg5 == false)
                    {
                        bool mg6 = strmg3.Contains("Involved");
                        if (mg6 == true)
                        {
                            strmg3 = "Involved";
                            mgn3 = dr[25].ToString().Replace("^", "'");
                        }
                        else
                        {
                            strmg3 = dr[26].ToString().Replace("^", "'");
                            mgn3 = "";
                        }
                    }

                    //////////////////////////////////////////////////////////////////////////
                    if (dr[31].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 =  dr[30].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[31].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 =  dr[30].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[33].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[32].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[33].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[32].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[35].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[34].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[35].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[34].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[37].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[36].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[37].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[36].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[39].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[38].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[39].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[38].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[41].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[40].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[41].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[40].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[43].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[42].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[43].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[42].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[45].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[44].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[45].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[44].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[47].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[46].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[47].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[46].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9
                    dgvList.Rows.Add(dr[0].ToString(),
                                      dr[1].ToString(),
                                      dr[2].ToString(),
                                      dr[3].ToString(),
                                      dr[4].ToString(),
                                      dr[5].ToString(),
                                      dr[6].ToString(),
                                      dr[7].ToString().Replace("^", "'"),
                                      dr[8].ToString().Replace("^", "'"),
                                      dr[9].ToString().Replace("^", "'"),
                                      dr[10].ToString().Replace("^", "'"),
                                      dr[11].ToString().Replace("^", "'"),
                                      dr[12].ToString().Replace("^", "'"),
                                      dr[13].ToString().Replace("^", "'"),
                                      dr[14].ToString().Replace("^", "'"),
                                      dr[16].ToString().Replace("^", "'"),
                                      dr[17].ToString().Replace("^", "'"),
                                      dr[18].ToString().Replace("^", "'"),
                                      strmg1 + strmg2 + strmg3,
                                      mgn1 + mgn2 + mgn3,
                                      dr[28].ToString().Replace("^", "'") + " " + dr[29].ToString().Replace("^", "'"),
                                      strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9
                                      

                                      );
                }

                else if (SMTP == "ubc")
                {
                    string strATX1="",strATX2="",strATX3="",strATX4="",strATX5="",strATX6="",strATX7="",strATX8,strATX9="";
                    string pog2;
                   // string mg1;
                    //string mg2;
                   // string mg3;
                    string strmg1 = dr[23].ToString().Replace("^", "'");
                    bool mg1 = strmg1.Contains("uninvolved");                    
                    if (mg1 == true)
                    {
                        strmg1 = "UnInvolved";
                    }
                    else if (mg1 == false)
                    {
                        bool mg2 = strmg1.Contains("involved");
                        if (mg2 == true)
                        {
                            strmg1 = "Involved";
                        }
                        else
                        {
                            strmg1 = dr[23].ToString().Replace("^", "'");
                        }
                    }
                    
                    string strmg2 = dr[26].ToString().Replace("^", "'");
                    bool mg3 = strmg2.Contains("uninvolved");
                    if (mg3 == true)
                    {
                        strmg2 = "UnInvolved";
                    }
                    else if (mg3 == false)
                    {
                        bool mg4 = strmg2.Contains("involved");
                        if (mg4 == true)
                        {
                            strmg2 = "Involved";
                        }
                        else
                        {
                            strmg2 = dr[26].ToString().Replace("^", "'");
                        }
                    }

                    string strmg3 = dr[29].ToString().Replace("^", "'");
                    bool mg5 = strmg3.Contains("uninvolved");
                    if (mg5 == true)
                    {
                        strmg3 = "UnInvolved";
                    }
                    else if (mg5 == false)
                    {
                        bool mg6 = strmg3.Contains("involved");
                        if (mg6 == true)
                        {
                            strmg3 = "Involved";
                        }
                        else
                        {
                            strmg3 = dr[29].ToString().Replace("^", "'");
                        }
                    }


                    

                    pog2 = dr[18].ToString();
                    if (dr[17].ToString() != "Mixed, noninvasive and invasive")
                    {
                        pog2 = "";
                    }
                    /*
                    if (dr[22].ToString().Replace("^", "'") == "Margins involved by invasive carcinoma")
                    {
                        mg1 = "-Ureters";
                    }
                    else
                        mg1 = "";
                    if (dr[25].ToString().Replace("^", "'") == "Margins uninvolved by invasive carcinoma")
                    {
                        mg2 = " -Urethra";
                    }
                    else
                        mg2 = "";
                    if (dr[28].ToString().Replace("^", "'") == "Margins involved by invasive carcinoma Margins uninvolved by invasive carcinoma")
                    {
                        mg3 = " -Paravesicular soft tissue";
                    }
                    else
                        mg3 = "";
                     */
                    //////////////////////////////////////////////////////////////////////////
                     
                    if (dr[35].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[34].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[35].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 =  dr[34].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 ="";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[37].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[36].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[37].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[36].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 ="";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[39].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[38].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[39].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[38].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[41].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[40].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[41].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[40].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[43].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[42].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[43].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[42].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[45].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[44].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[45].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[44].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[47].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[46].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[47].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[46].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 ="";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[49].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[48].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[49].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[48].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[51].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[50].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[51].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[50].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    /////////////////////////////////////////////추가처방9
                    dgvList.Rows.Add(dr[0].ToString().Replace("'","^"),
                                      dr[1].ToString(),
                                      dr[2].ToString(),
                                      dr[3].ToString(),
                                      dr[4].ToString(),
                                      dr[5].ToString(),
                                      dr[6].ToString(),
                                      dr[7].ToString().Replace("^", "'") +" "+ dr[8].ToString().Replace("^", "'"),
                                      dr[9].ToString().Replace("^", "'") + " " + dr[10].ToString().Replace("^", "'"),
                                      dr[11].ToString().Replace("^", "'"),
                                      dr[12].ToString().Replace("^", "'"),
                                      dr[13].ToString().Replace("^", "'"),
                                      dr[14].ToString().Replace("^", "'"),
                                      dr[15].ToString().Replace("^", "'"),
                                      dr[16].ToString().Replace("^", "'"),
                                      dr[17].ToString().Replace("^", "'"),
                                      pog2,
                                      dr[20].ToString().Replace("^", "'"),
                                      dr[21].ToString().Replace("^", "'"),
                                      dr[22].ToString().Replace("^", "'"),                                      
                                      strmg1,
                                      strmg2,
                                      strmg3,
                                      dr[32].ToString().Replace("^", "'") + " " + dr[33].ToString().Replace("^","'"),
                                      strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9
                                      
                                      
                                      

                                      );
                }

                else if (SMTP == "ubt")
                {
                    string strATX1="",strATX2="",strATX3="",strATX4="",strATX5="",strATX6="",strATX7="",strATX8,strATX9="";
                    if (dr[19].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX1 = dr[18].ToString().Replace("^", "'") +"+ ";
                    }
                    else if (dr[19].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX1 = dr[18].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX1 ="";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방1
                    if (dr[21].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX2 = " , " + dr[20].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[21].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX2 = " , " + dr[20].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX2 ="";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방2
                    if (dr[23].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX3 = " , " + dr[22].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[23].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX3 = " , " + dr[22].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX3 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방3
                    if (dr[25].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX4 = " , " + dr[24].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[25].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX4 = " , " + dr[24].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX4 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방4
                    if (dr[27].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX5 = " , " + dr[26].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[27].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX5 = " , " + dr[26].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX5 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방5
                    if (dr[29].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX6 = " , " + dr[28].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[29].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX6 = " , " + dr[28].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX6 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방6
                    if (dr[31].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX7 = " , " + dr[30].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[31].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX7 = " , " + dr[30].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX7 ="";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방7
                    if (dr[33].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX8 = " , " + dr[32].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[33].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX8 = " , " + dr[32].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX8 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방8
                    if (dr[35].ToString().Replace("^", "'") == "Positive")
                    {
                        strATX9 = " , " + dr[34].ToString().Replace("^", "'") + "+ ";
                    }
                    else if (dr[35].ToString().Replace("^", "'") == "Negative")
                    {
                        strATX9 = " , " + dr[34].ToString().Replace("^", "'") + "- ";
                    }
                    else
                    {
                        strATX9 = "";
                    }
                    ////////////////////////////////////////////////////////////////////////////////추가처방9
                    
                    string pog2;
                    pog2 = dr[12].ToString();
                    if (dr[11].ToString() != "Mixed, noninvasive and invasive")
                    {
                        pog2 = "";
                    }
                    dgvList.Rows.Add(dr[0].ToString(),
                                      dr[1].ToString(),
                                      dr[2].ToString(),
                                      dr[3].ToString(),
                                      dr[4].ToString(),
                                      dr[5].ToString(),
                                      dr[6].ToString(),
                                      dr[7].ToString().Replace("^", "'"),
                                      dr[8].ToString().Replace("^", "'"),
                                      dr[9].ToString().Replace("^", "'"),
                                      dr[10].ToString().Replace("^", "'"),
                                      dr[11].ToString().Replace("^", "'"),
                                      pog2,
                                      dr[13].ToString().Replace("^", "'"),
                                      dr[14].ToString().Replace("^", "'"),
                                      dr[15].ToString().Replace("^", "'"),
                                      dr[16].ToString().Replace("^", "'"),
                                      dr[17].ToString().Replace("^", "'"),
                                      strATX1 + strATX2 + strATX3 + strATX4 + strATX5 + strATX6 + strATX7 + strATX8 + strATX9
                                      

                                      );
                }

                else if (SMTP == "int")
                {
                    dgvList.Rows.Add(dr[0].ToString(),
                                     dr[1].ToString(),
                                     dr[2].ToString(),
                                     dr[3].ToString(),
                                     dr[4].ToString(),
                                     dr[5].ToString(),
                                     dr[6].ToString(),
                                     dr[7].ToString(),
                                     dr[8].ToString(),
                                     GetData(dr[9].ToString()),
                                     GetData(dr[10].ToString()),
                                     dr[11].ToString());
                }

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

        //엑셀 컬럼명 A~Z 보다 많을경우..AA AB AC..BA BB BC..붙여주기
        public static String translateColumnIndexToName(int index)
        {
            int quotient = (index) / 26;

            if (quotient > 0)
            {
                return translateColumnIndexToName(quotient - 1) + (char)((index % 26) + 65);
            }
            else
            {
                return "" + (char)((index % 26) + 65);
            }
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
                int quotient = (c) / 26;

                if (quotient > 0)
                {
                    columns[c] = Convert.ToString(translateColumnIndexToName(quotient - 1) + (char)((c % 26) + 65));
                }
                else
                {
                    columns[c] = Convert.ToString((char)((c % 26) + 65));
                }

                //Console.WriteLine(columns[c]); 
                
                //num = c + 65;
                //columns[c] = Convert.ToString((char)num);
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

                MessageBox.Show(errorMessage, "Error");
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

            
            if (SMTP == "brs") //1
            {
                dgvList.Columns.Add("l1", "진단명");
                dgvList.Columns.Add("l2", "tumor site");
                dgvList.Columns.Add("l3", "수술명");
                dgvList.Columns.Add("l4", "histology");
                dgvList.Columns.Add("l5", "subtype");
                dgvList.Columns.Add("l6", "other type");
                dgvList.Columns.Add("l7", "grade");
                dgvList.Columns.Add("l8", "total score");
                dgvList.Columns.Add("l9", "tubule formation");
                dgvList.Columns.Add("l10", "nuclear grade");
                dgvList.Columns.Add("l11", "mitosis grade");
                dgvList.Columns.Add("l12", "size 1");
                dgvList.Columns.Add("l13", "size 2");
                dgvList.Columns.Add("l14", "size 3");
                dgvList.Columns.Add("l15", "lymphovascular invasion");
                dgvList.Columns.Add("l15", "lymphovascular invasion2");
                dgvList.Columns.Add("l16", "necrosis");
                dgvList.Columns.Add("l16", "necrosis2");
                dgvList.Columns.Add("l17", "microcalcification");
                dgvList.Columns.Add("l17", "microcalcification2");
                dgvList.Columns.Add("l18", "dermal lymphatic involvement");
                dgvList.Columns.Add("l18", "dermal lymphatic involvement2");
                dgvList.Columns.Add("l19", "nipple involvement");
                dgvList.Columns.Add("l19", "nipple involvement2");
                dgvList.Columns.Add("l20", "margin status");
                dgvList.Columns.Add("l21", "postive margin name");
                dgvList.Columns.Add("l22", "additional foci of invasion carcinoma");
                dgvList.Columns.Add("l23", "T");
                dgvList.Columns.Add("l24", "N");
                dgvList.Columns.Add("l25", "M");
                dgvList.Columns.Add("l26", "DCIS grade");
                dgvList.Columns.Add("l27", "DCIS size");
                dgvList.Columns.Add("l28", "DCIS size2");
                dgvList.Columns.Add("l29", "DCIS type");
                dgvList.Columns.Add("l30", "DCIS necrosis");
                dgvList.Columns.Add("l31", "DCIS Ca2+");
                dgvList.Columns.Add("l32", "DCIS margin status");
                dgvList.Columns.Add("l33", "DCIS positive margin name");
                dgvList.Columns.Add("l34", "extracapsular extension of axillary lymph node");
                dgvList.Columns.Add("l35", "추가처방");
                
            }

            else if (SMTP == "cvx") //2
            {
                dgvList.Columns.Add("l1", "수술명");
                dgvList.Columns.Add("l2", "histology");
                dgvList.Columns.Add("l3", "subtype");
                dgvList.Columns.Add("l4", "tumor size1");
                dgvList.Columns.Add("l5", "tumor size2");
                dgvList.Columns.Add("l6", "tumor size3");
                dgvList.Columns.Add("l7", "tumor site");
                dgvList.Columns.Add("l8", "location");
                dgvList.Columns.Add("l9", "histologic grade");
                dgvList.Columns.Add("l10", "vaginal margin");
                dgvList.Columns.Add("l11", "exocervical marign");
                dgvList.Columns.Add("l12", "paracervical margin");
                dgvList.Columns.Add("l13", "lymphovascular invasion");
                dgvList.Columns.Add("l14", "perineural invasion");
                dgvList.Columns.Add("l15", "additional pathologic findings");
                dgvList.Columns.Add("l16", "pelvic lymphp node dissection");
                dgvList.Columns.Add("l17", "추가처방");
            }
            else if (SMTP == "col") //3
            {
                dgvList.Columns.Add("l1", "수술명");
                dgvList.Columns.Add("l2", "histologic type");
                dgvList.Columns.Add("l3", "tumor location");
                dgvList.Columns.Add("l4", "gross type");
                dgvList.Columns.Add("l5", "tumor size");
                dgvList.Columns.Add("l6", "histologic grade");
                dgvList.Columns.Add("l7", "growth pattern");
                dgvList.Columns.Add("l8", "extracellular mucin production");
                dgvList.Columns.Add("l9", "lymphatic invasion");
                dgvList.Columns.Add("l10", "lymphatic invasion2");
                dgvList.Columns.Add("l11", "lymphatic invasion3");
                dgvList.Columns.Add("l12", "venous invasion");
                dgvList.Columns.Add("l13", "venous invasion2");
                dgvList.Columns.Add("l14", "venous invasion3");
                dgvList.Columns.Add("l15", "perineural invasion");
                dgvList.Columns.Add("l16", "perineural invasion2");
                dgvList.Columns.Add("l17", "perineural invasion3");
                dgvList.Columns.Add("l18", "margin status");
                dgvList.Columns.Add("l19", "positve margin name");
                dgvList.Columns.Add("l20", "pre-existing adenoma");
                dgvList.Columns.Add("l21", "additional pathologic findings");
                dgvList.Columns.Add("l22", "추가처방");
            }

            else if (SMTP == "edc") //4
            {
                dgvList.Columns.Add("l1", "수술명");
                dgvList.Columns.Add("l2", "histologic type");
                dgvList.Columns.Add("l3", "tumor size1");
                dgvList.Columns.Add("l4", "tumor size2");
                dgvList.Columns.Add("l5", "tumor size3");
                dgvList.Columns.Add("l6", "tumor site");
                dgvList.Columns.Add("l7", "FIGO grade");
                dgvList.Columns.Add("l8", "FIGO stage");
                dgvList.Columns.Add("l9", "myometerial invasion");
                dgvList.Columns.Add("l10", "depth of invasion");
                dgvList.Columns.Add("l11", "total wall thickness");
                dgvList.Columns.Add("l12", "<50% vs >50%");
                dgvList.Columns.Add("l13", "cervix involvement");
                dgvList.Columns.Add("l14", "right ovary");
                dgvList.Columns.Add("l14", "right ovary2");
                dgvList.Columns.Add("l15", "left ovary");
                dgvList.Columns.Add("l15", "left ovary2");
                dgvList.Columns.Add("l16", "right salpinx");
                dgvList.Columns.Add("l16", "right salpinx2");
                dgvList.Columns.Add("l17", "left salpinx");
                dgvList.Columns.Add("l17", "left salpinx2");
                dgvList.Columns.Add("l18", "vagina");
                dgvList.Columns.Add("l18", "vagina2");
                dgvList.Columns.Add("l19", "parametrium");
                dgvList.Columns.Add("l19", "parametrium2");
                dgvList.Columns.Add("l20", "omentum");
                dgvList.Columns.Add("l20", "omentum2");
                dgvList.Columns.Add("l21", "rectal wall");
                dgvList.Columns.Add("l21", "rectal wall2");
                dgvList.Columns.Add("l22", "bladder wall");
                dgvList.Columns.Add("l22", "bladder wall2");
                dgvList.Columns.Add("l23", "lymph node");
                dgvList.Columns.Add("l23", "lymph node2");
                dgvList.Columns.Add("l24", "exocervcial margin");
                dgvList.Columns.Add("l25", "parametrial margin");
                dgvList.Columns.Add("l26", "perineural invasion");
                dgvList.Columns.Add("l27", "additional pathologic findings");
                dgvList.Columns.Add("l28", "pelvic lyph node dissection");
                dgvList.Columns.Add("l29", "추가처방");


            }

            else if (SMTP == "esp") //5
            {
                dgvList.Columns.Add("l1", "수술명");
                dgvList.Columns.Add("l2", "histologic type");
                dgvList.Columns.Add("l3", "subtype");
                dgvList.Columns.Add("l4", "tumor size1");
                dgvList.Columns.Add("l5", "tumor size2");
                dgvList.Columns.Add("l6", "tumor size3");
                dgvList.Columns.Add("l7", "tumor site");
                dgvList.Columns.Add("l8", "relationship to EGJ");
                dgvList.Columns.Add("l9", "histologic grade");
                dgvList.Columns.Add("l10", "T");
                dgvList.Columns.Add("l11", "margin status");
                dgvList.Columns.Add("l12", "positive margin name");
                dgvList.Columns.Add("l13", "pre-existing lesion");
                dgvList.Columns.Add("l14", "lymphatic invasion");
                dgvList.Columns.Add("l14", "lymphatic invasion2");
                dgvList.Columns.Add("l15", "venous invasion status");
                dgvList.Columns.Add("l15", "venous invasion status2");
                dgvList.Columns.Add("l16", "perineural invasion");
                dgvList.Columns.Add("l16", "perineural invasion2");
                dgvList.Columns.Add("l17", "추가처방");
            }

            else if (SMTP == "kdn") //6
            {
                dgvList.Columns.Add("l1", "site");
                dgvList.Columns.Add("l2", "수술명");
                dgvList.Columns.Add("l3", "histologic type");
                dgvList.Columns.Add("l4", "subtype");
                dgvList.Columns.Add("l5", "tumor location");
                dgvList.Columns.Add("l6", "sarcomatoid feature");
                dgvList.Columns.Add("l7", "tumor necrosis");
                dgvList.Columns.Add("l8", "Fuhrman nuclear grade");
                dgvList.Columns.Add("l9", "T");
                dgvList.Columns.Add("l10", "margin status");
                dgvList.Columns.Add("l11", "positive margin name");
                dgvList.Columns.Add("l12", "lymphovascular invasion");
                dgvList.Columns.Add("l13", "lymphovascular invasion-2");
                dgvList.Columns.Add("l14", "additional pathologic findings");
                dgvList.Columns.Add("l15", "추가처방");
            }

            else if (SMTP == "lvh") //7
            {
                dgvList.Columns.Add("l1", "number of the mass");
                dgvList.Columns.Add("l2", "number of the mass2");
                dgvList.Columns.Add("l3", "Tumor site");
                dgvList.Columns.Add("l4", "satellite nodule");
                dgvList.Columns.Add("l5", "tumor size 1");
                dgvList.Columns.Add("l6", "tumor size 2");
                dgvList.Columns.Add("l7", "tumor size 3");
                dgvList.Columns.Add("l8", "gross type");
                dgvList.Columns.Add("l9", "tumor necrosis");
                dgvList.Columns.Add("l10", "hemorrhage or peliosis within tumor");
                dgvList.Columns.Add("l11", "differentiation worst");
                dgvList.Columns.Add("l12", "differentiation most");
                dgvList.Columns.Add("l13", "histologic type");
                dgvList.Columns.Add("l14", "cell type");
                dgvList.Columns.Add("l15", "fatty change within tumor");
                dgvList.Columns.Add("l16", "fibrous capsule formation");
                dgvList.Columns.Add("l17", "capsular infiltration");
                dgvList.Columns.Add("l18", "septal formation within tumor");
                dgvList.Columns.Add("l19", "resection margin");
                dgvList.Columns.Add("l20", "serosal invasion");
                dgvList.Columns.Add("l21", "vascular invasion, macroscopically");
                dgvList.Columns.Add("l22", "vascular invasion, macroscopically2");
                dgvList.Columns.Add("l23", "vascular invasion, microscopically");
                dgvList.Columns.Add("l24", "vascular invasion, microscopically2");
                dgvList.Columns.Add("l25", "bile duct invasion");
                dgvList.Columns.Add("l26", "추가처방");
            }

            else if (SMTP == "lvi") //8
            {
                dgvList.Columns.Add("l1", "histologic type");
                dgvList.Columns.Add("l2", "tumor size #1-1");
                dgvList.Columns.Add("l3", "tumor size #1-2");
                dgvList.Columns.Add("l4", "tumor size #1-3");
                dgvList.Columns.Add("l5", "tumor focality");
                dgvList.Columns.Add("l6", "tumor focality2");
                dgvList.Columns.Add("l7", "tumor site");
                dgvList.Columns.Add("l8", "histologic grade");
                dgvList.Columns.Add("l9", "tumor growth pattern");
                dgvList.Columns.Add("l10", "microscopic tumor extension");
                dgvList.Columns.Add("l11", "microscopic tumor extension2");
                dgvList.Columns.Add("l12", "hepatic parencymal margin");
                dgvList.Columns.Add("l13", "bile duct margin");
                dgvList.Columns.Add("l14", "major vessel invasion-1");
                dgvList.Columns.Add("l15", "major vessel invasion-2");
                dgvList.Columns.Add("l16", "small vessel invasion-1");
                dgvList.Columns.Add("l17", "small vessel invasion-2");
                dgvList.Columns.Add("l18", "perineural invasion");
                dgvList.Columns.Add("l19", "비고");
                dgvList.Columns.Add("l20", "추가처방");
            }

            else if (SMTP == "lvm") //9
            {
                dgvList.Columns.Add("l1", "primary site");
                dgvList.Columns.Add("l2", "tumor size 1");
                dgvList.Columns.Add("l3", "tumor size 2");
                dgvList.Columns.Add("l4", "tumor size 3");
                dgvList.Columns.Add("l5", "resection margin");
                dgvList.Columns.Add("l6", "hepatic capsule");
                dgvList.Columns.Add("l7", "tumor regression grade");
                dgvList.Columns.Add("l8", "sinusoidal dilatation");
                dgvList.Columns.Add("l9", "sinusoidal dilatation2");
                dgvList.Columns.Add("l10", "nodular regeneration");
                dgvList.Columns.Add("l11", "nodular regeneration2");
                dgvList.Columns.Add("l12", "centrilobular or pertal vein lesions");
                dgvList.Columns.Add("l13", "centrilobular or pertal vein lesions2");
                dgvList.Columns.Add("l14", "centrilobular perisinusoidal and vein fibrosis");
                dgvList.Columns.Add("l15", "centrilobular perisinusoidal and vein fibrosis2");
                dgvList.Columns.Add("l16", "steatosis");
                dgvList.Columns.Add("l17", "steatosis2");
                dgvList.Columns.Add("l18", "other findings");
                dgvList.Columns.Add("l19", "추가처방");
                
            }

            else if (SMTP == "lng") //10
            {
                dgvList.Columns.Add("l1", "Histology type");
                dgvList.Columns.Add("l2", "Histology grade");
                dgvList.Columns.Add("l3", "pT");
                dgvList.Columns.Add("l4", "pN");
                dgvList.Columns.Add("l5", "pM");
                dgvList.Columns.Add("l6", "추가처방");
                
            }

            else if (SMTP == "ovc") //11
            {
                dgvList.Columns.Add("l1", "수술명");
                dgvList.Columns.Add("l2", "histologic type");
                dgvList.Columns.Add("l3", "tumor site");
                dgvList.Columns.Add("l4", "tumor size #1-1");
                dgvList.Columns.Add("l5", "tumor size #1-2");
                dgvList.Columns.Add("l6", "tumor size #1-3");
                dgvList.Columns.Add("l7", "tumor size #2-1");
                dgvList.Columns.Add("l8", "tumor size #2-2");
                dgvList.Columns.Add("l9", "tumor size #2-3");
                dgvList.Columns.Add("l10", "histologic grade");
                dgvList.Columns.Add("l11", "growth pattern");
                dgvList.Columns.Add("l12", "nuclear atypia");
                dgvList.Columns.Add("l13", "mitosis");
                dgvList.Columns.Add("l14", "specimen integrity");
                dgvList.Columns.Add("l15", "surface involvement");
                dgvList.Columns.Add("l16", "right ovary");
                dgvList.Columns.Add("l17", "right ovary2");
                dgvList.Columns.Add("l18", "left ovary");
                dgvList.Columns.Add("l19", "left ovary2");
                dgvList.Columns.Add("l20", "right salpinx");
                dgvList.Columns.Add("l21", "right salpinx2");
                dgvList.Columns.Add("l22", "left salpinx");
                dgvList.Columns.Add("l23", "left salpinx2");
                dgvList.Columns.Add("l24", "omentum");
                dgvList.Columns.Add("l25", "omentum2");
                dgvList.Columns.Add("l26", "uterus");
                dgvList.Columns.Add("l27", "uterus2");
                dgvList.Columns.Add("l28", "peritoneum");
                dgvList.Columns.Add("l29", "peritoneum2");
                dgvList.Columns.Add("l30", "lymph node");
                dgvList.Columns.Add("l31", "lymph node2");
                dgvList.Columns.Add("l32", "lymphovascular invasion");
                dgvList.Columns.Add("l33", "추가처방");
                
            }

            else if (SMTP == "prs") //12
            {
                dgvList.Columns.Add("l1", "수술명");
                dgvList.Columns.Add("l2", "Gleason score");
                dgvList.Columns.Add("l3", "Gleason score 2");
                dgvList.Columns.Add("l4", "grade group");
                dgvList.Columns.Add("l5", "tumor location a");
                dgvList.Columns.Add("l6", "tumor location b");
                dgvList.Columns.Add("l7", "multicentricity");
                dgvList.Columns.Add("l8", "nodule #1 size 1");
                dgvList.Columns.Add("l9", "nodule #1 size 2");
                dgvList.Columns.Add("l10", "nodule #1 size 3");
                dgvList.Columns.Add("l11", "nodule #2 size 1");
                dgvList.Columns.Add("l12", "nodule #2 size 2");
                dgvList.Columns.Add("l13", "nodule #2 size 3");
                dgvList.Columns.Add("l14", "tumor volume");
                dgvList.Columns.Add("l15", "T");
                dgvList.Columns.Add("l16", "N");
                dgvList.Columns.Add("l17", "M");                
                dgvList.Columns.Add("l18", "lymphatic invasion");
                dgvList.Columns.Add("l19", "lymphatic invasion2");
                dgvList.Columns.Add("l20", "perineural invasion");
                dgvList.Columns.Add("l21", "perineural invasion2");
                dgvList.Columns.Add("l22", "resection margin");
                dgvList.Columns.Add("l23", "resection margin2");
                dgvList.Columns.Add("l24", "tumor border");
                dgvList.Columns.Add("l25", "Highgrade PIN");
                dgvList.Columns.Add("l26", "nodular hyperplasia");
                dgvList.Columns.Add("l27", "hormonal therapy effect");
                dgvList.Columns.Add("l28", "intra ductal carcinoma of prostate (IDC-P)");
                dgvList.Columns.Add("l26", "추가처방");
                
            }

            else if (SMTP == "rtc") //13
            {
                dgvList.Columns.Add("l1", "수술명");
                dgvList.Columns.Add("l2", "histologic type");
                dgvList.Columns.Add("l3", "location");
                dgvList.Columns.Add("l4", "gross type");
                dgvList.Columns.Add("l5", "tumor size 1");
                dgvList.Columns.Add("l6", "histologic grade");
                dgvList.Columns.Add("l7", "growth pattern");
                dgvList.Columns.Add("l8", "T");
                dgvList.Columns.Add("l9", "N");
                dgvList.Columns.Add("l10", "M");
                dgvList.Columns.Add("l11", "MAC stage");
                dgvList.Columns.Add("l12", "Extracellular mucin production");
                dgvList.Columns.Add("l13", "Extracellular mucin production2");
                dgvList.Columns.Add("l14", "lymphatic invasion");
                dgvList.Columns.Add("l15", "lymphatic invasion2");
                dgvList.Columns.Add("l16", "lymphatic invasion3");
                dgvList.Columns.Add("l17", "venous invasion");
                dgvList.Columns.Add("l18", "venous invasion2");
                dgvList.Columns.Add("l19", "venous invasion3");
                dgvList.Columns.Add("l20", "perineural invasion");
                dgvList.Columns.Add("l21", "perineural invasion2");
                dgvList.Columns.Add("l22", "perineural invasion3");
                dgvList.Columns.Add("l23", "margin status");
                dgvList.Columns.Add("l24", "positive margin name");
                dgvList.Columns.Add("l25", "pre-existing adenoma");
                dgvList.Columns.Add("l26", "additional pathologic findings");
                dgvList.Columns.Add("l27", "추가처방");
                
            }

            else if (SMTP == "stm") //14
            {
                dgvList.Columns.Add("l1", "수술명");
                dgvList.Columns.Add("l2", "histologic type");
                dgvList.Columns.Add("l3", "location");
                dgvList.Columns.Add("l4", "growth type");
                dgvList.Columns.Add("l5", "histologic grade");
                dgvList.Columns.Add("l6", "histologic grade 2");
                dgvList.Columns.Add("l7", "histologic type by Lauren");
                dgvList.Columns.Add("l8", "growth pattern");
                dgvList.Columns.Add("l9", "T");
                dgvList.Columns.Add("l10", "N");                
                dgvList.Columns.Add("l11", "margin status");
                dgvList.Columns.Add("l12", "positive margin name");
                dgvList.Columns.Add("l13", "lymphatic invasion");
                dgvList.Columns.Add("l14", "lymphatic invasion2");
                dgvList.Columns.Add("l15", "venous invasion");
                dgvList.Columns.Add("l16", "venous invasion2");
                dgvList.Columns.Add("l17", "perineural invasion");
                dgvList.Columns.Add("l18", "perineural invasion2");
                dgvList.Columns.Add("l19", "additional pathologic findings");
                dgvList.Columns.Add("l20", "추가처방");
                
            }

            else if (SMTP == "stg") //15
            {
                dgvList.Columns.Add("l1", "수술명");
                dgvList.Columns.Add("l2", "tumor site");
                dgvList.Columns.Add("l3", "tumor focallity");
                dgvList.Columns.Add("l4", "-Number");
                dgvList.Columns.Add("l5", "GIST subtype");
                dgvList.Columns.Add("l6", "mitotic rate");
                dgvList.Columns.Add("l7", "histologic grade");
                dgvList.Columns.Add("l8", "necrosis");
                dgvList.Columns.Add("l9", "T");
                dgvList.Columns.Add("l10", "N");
                dgvList.Columns.Add("l11", "M");
                dgvList.Columns.Add("l12", "margin status");
                dgvList.Columns.Add("l13", "additional pathologic findings");
                dgvList.Columns.Add("l14", "추가처방");
                
            }
            else if (SMTP == "tst") //16
            {
                dgvList.Columns.Add("l1", "수술명");
                dgvList.Columns.Add("l2", "tumor site");
                dgvList.Columns.Add("l3", "histologic type");
                dgvList.Columns.Add("l4", "subtype");
                dgvList.Columns.Add("l5", "tumor focallity");
                dgvList.Columns.Add("l6", "tumor size 1");
                dgvList.Columns.Add("l7", "tumor size 2");
                dgvList.Columns.Add("l8", "tumor size 3");
                dgvList.Columns.Add("l9", "pT");
                dgvList.Columns.Add("l10", "vascular invasion");
                dgvList.Columns.Add("l11", "perineural invasion");
                dgvList.Columns.Add("l12", "margin status");
                dgvList.Columns.Add("l13", "positive margin name");
                dgvList.Columns.Add("l14", "addtional pathologic findings");
                dgvList.Columns.Add("l15", "추가처방");
                

            }
            else if (SMTP == "ubc") //17
            {
                dgvList.Columns.Add("l1", "수술명");
                dgvList.Columns.Add("l2", "histologic type");
                dgvList.Columns.Add("l3", "tumor site");
                dgvList.Columns.Add("l4", "tumor size1");
                dgvList.Columns.Add("l5", "tumor size2");
                dgvList.Columns.Add("l6", "tumor size3");
                dgvList.Columns.Add("l7", "grade(low/high)");
                dgvList.Columns.Add("l8", "grade(1/2/3)");
                dgvList.Columns.Add("l9", "pattern of growth 1");
                dgvList.Columns.Add("l10", "pattern of growth 2");
                dgvList.Columns.Add("l11", "pT");
                dgvList.Columns.Add("l12", "lymphovascular invasion");
                dgvList.Columns.Add("l13", "perineural invasion");
                dgvList.Columns.Add("l14", "-Ureters");
                dgvList.Columns.Add("l14", "-Urethra");
                dgvList.Columns.Add("l14", "-Paravesicular");                
                dgvList.Columns.Add("l16", "additional pathologic findings");
                dgvList.Columns.Add("l17", "추가처방");
                
            }
            else if (SMTP == "ubt") //18
            {
                dgvList.Columns.Add("l1", "site");
                dgvList.Columns.Add("l2", "histology");
                dgvList.Columns.Add("l3", "grade(low/high)");
                dgvList.Columns.Add("l4", "grade(1/2/3)");
                dgvList.Columns.Add("l5", "pattern of growth 1");
                dgvList.Columns.Add("l6", "pattern of growth 2");
                dgvList.Columns.Add("l7", "subepithelial connective tissue invasion");
                dgvList.Columns.Add("l7", "PT");
                dgvList.Columns.Add("l8", "muscularis propria ivnasion");
                dgvList.Columns.Add("l9", "lymphovascular invasion");
                dgvList.Columns.Add("l10", "perineural invasion");
                dgvList.Columns.Add("l11", "추가처방");
                
            }

            else if (SMTP == "int")
            {
                dgvList.Columns.Add("i1", "장기");
                dgvList.Columns.Add("i2", "진료과");
                dgvList.Columns.Add("i3", "Gross 결과");
                dgvList.Columns.Add("i4", "Diagnosis 결과");
                dgvList.Columns.Add("i5", "결과전송");
            }
        }
    }
}
