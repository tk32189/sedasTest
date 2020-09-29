using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.IO;
using System.Data.OleDb;
using DevExpress.XtraEditors;


namespace SmartPIS
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public static OleDbConnection EMRconn;
        public MainForm()
        {
            InitializeComponent();
            
            DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            

            
        }
        public static MySqlConnection Myconn;
        public bool ext=false;
        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            tableLayoutPanel1.SetColumnSpan(lbExstatus, 5);
            tableLayoutPanel1.SetColumnSpan(lbResult, 3);
            tableLayoutPanel1.SetColumnSpan(lbCode, 3);
            try
            {
                Getini();
                //string strSQL = Ini.strDB;
               // MySqlCommand cmd = new MySqlCommand(strSQL, Myconn);
               // MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
               // MessageBox.Show("연결성공"); 
                label1.Text = Ini.WK_NM;
            }
            catch (System.Exception ex)
            {
               // MessageBox.Show("연결실패");
                
            }
            InitControls();

            InitTest();
        }

        private void InitTest()
        {
            tbPTNO.Text = "S2018003549";
            btnSearch.PerformClick();
        }


        /// <summary>
        /// name         : InitControls
        /// desc         : 컨트롤 초기화
        /// author       : 심우종
        /// create date  : 2020-06-15 15:56
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitControls()
        {
            string[] comboData = { "",
            "Breast",
            "Cervix",
            "Colon",
            "Endometrial cancer",
            "Esophagus",
            "Kidney",
            "Liver Hepatectomy",
            "Liver Intrahepatic",
            "Liver meta",
            "Lung",
            "Ovary cancer",
            "Prostate",
            "Rectal",
            "Stomach gastrectomy",
            "Stomach GIST",
            "TESTIS",
            "Urinary bladder carcinoma",
            "Urinary bladder turb"};

            DataTable comboDt = new DataTable();
            comboDt.Columns.Add("value");
            comboDt.Columns.Add("description");
            for (int i = 0; i < comboData.Count(); i++)
            {
                DataRow row = comboDt.NewRow();
                row["value"] = comboData.ElementAt(i);
                row["description"] = comboData.ElementAt(i);
                comboDt.Rows.Add(row);
            }


            hImageComboBoxEdit1.DataBindingFromDataTable(comboDt, "value", "description");
        }

        private void Getini()
        {
            Ini.strPath = System.Environment.CurrentDirectory + "\\Setup.ini";
            Ini.strDB = Ini.G_IniReadValue("DB_Connection", "DBConnectionString", Ini.strPath);
            Ini.DBSelect = Ini.G_IniReadValue("DB_Connection", "SELECT", Ini.strPath);
            Ini.DBDelete = Ini.G_IniReadValue("DB_Connection", "DELETE", Ini.strPath);
            Ini.DBUpdate = Ini.G_IniReadValue("DB_Connection", "UPDATE", Ini.strPath);
            Ini.DBInsert = Ini.G_IniReadValue("DB_Connection", "INSERT", Ini.strPath);
            Ini.strOCSDB = Ini.G_IniReadValue("EMR_Connection", "EMRConnectionString", Ini.strPath);
            Ini.WK_NM = Ini.G_IniReadValue("Info", "WKNM", Ini.strPath);
            Ini.WK_ID = Ini.G_IniReadValue("Info", "WKID", Ini.strPath);
            Ini.LibraryPath = Ini.G_IniReadValue("Program", "LibraryPath", Ini.strPath);
            
            
        }

        private bool DBUpdate(int nNum)
        {
            try
            {
                string strSQL = Ini.strDB;                
                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();

                string sql = string.Format("UPDATE PISDIG001 SET INTEREST = '" + nNum + "' where PTNO = '" + SetPTNO(tbPTNO.Text) + "'");
                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
            Myconn.Close();

            return true;
        }

        private bool DBInsert()
        {
            string Redt = lbDate.Text;
            Redt = Redt.Replace("-", "");
            try
            {
                string sql = string.Format("INSERT INTO PISDIG001 (SYDT, UPDT, UPID, PTNO, OGTP, DITP, GRTX, DITX, TRYN, ABLK, NBLK, EXKB, PANO, PANM, PSEX, PAGE, DEPT, DOCT, REDT, DITM, EXCD, EXST ) values " +
                                                                    " ('{0}','{1}','{2}','{3}','{4}','{5}','{6}','{7}','{8}','{9}','{10}','{11}','{12}','{13}','{14}','{15}','{16}','{17}','{18}','{19}','{20}','{21}') ",
                                                                    DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd"), "SEDAS", tbPTNO.Text, " ", "N", "", "", "N", "", "", lbExcode.Text, lbPID.Text, lbPNM.Text,
                                                                    lbSex.Text, lbAge.Text, lbExam.Text, "", Redt, lbResult.Text, lbCode.Text, lbExstatus.Text);                
                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }

            return true;
        }

        private int GetCodeName(string strCode)
        {
            int nName = 0;
            switch (strCode)
            {
                case "brs":
                    nName = 1;
                    break;
                case "cvx":
                    nName = 2;
                    break;
                case "col":
                    nName = 3;
                    break;
                case "edc":
                    nName = 4;
                    break;
                case "esp":
                    nName = 5;
                    break;
                case "kdn":
                    nName = 6;
                    break;
                case "lvi":
                    nName = 8;
                    break;
                case "lvh":
                    nName = 7;
                    break;
                case "lvm":
                    nName = 9;
                    break;
                case "lng":
                    nName = 10;
                    break;
                case "ovc":
                    nName = 11;
                    break;
                case "prs":
                    nName = 12;
                    break;
                case "rtc":
                    nName = 13;
                    break;
                case "stg":
                    nName = 15;
                    break;
                case "stm":
                    nName = 14;
                    break;
                case "tst":
                    nName = 16;
                    break;
                case "ubc":
                    nName = 17;
                    break;
                case "ubt":
                    nName = 18;
                    break;
            }
            return nName;
        }

        private static string  SetPTNO(string PTNO)
        {
            string strPTNO = "";
            if (PTNO.Length < 8)
                strPTNO = "S " + DateTime.Now.ToString("yy") + PTNO.PadLeft(7, '0');
            else
                strPTNO = PTNO;

            return strPTNO;
        }

        private bool DBSearch()
        {
            bool bRet = false;
            try
            {
                string strSQL = Ini.strDB;
                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();

                string sql = string.Format("SELECT * FROM PISDIG001 WHERE PTNO = '{0}'", SetPTNO(tbPTNO.Text));
                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    //comboBox1.Text = "";
                    bRet = true;
                    textBox2.Text = read[6].ToString();
                    textBox3.Text = read[7].ToString().Replace("^", "'");
                    lbExcode.Text = read[11].ToString();     //검사분류
                    lbExstatus.Text = read[12].ToString();   //검사상태
                    lbPID.Text = read[13].ToString();        //환자번호
                    lbPNM.Text = read[14].ToString();        //환자이름
                    lbSex.Text = read[15].ToString();        //환자성별
                    lbAge.Text = read[16].ToString();        //환자나이
                    lbExam.Text = read[17].ToString();       //진료과아
                    //lbDoc.Text = read[18].ToString();        //주치의사
                    lbDate.Text = read[19].ToString();       //접수일자
                    //lbResult.Text = read[20].ToString();     //결과시간
                    lbCode.Text = read[21].ToString();       //검사코드
                    
                    //comboBox1.SelectedIndex = GetCodeName(read[4].ToString());     //검체
                    this.hImageComboBoxEdit1.SelectedIndex = GetCodeName(read[4].ToString());     //검체

                    if (read[22].ToString() == "1")
                        btnInterest.Text = "관심해제";
                    else if (read[22].ToString() == "0")
                        btnInterest.Text = "관심등록";
                }
                read.Close();
            }
            catch (System.Exception ex)
            {
                return false;
            }

            return bRet;
        }

        private void OnControl()
        {
            button1.Enabled = true;
            button2.Enabled = true;
            //comboBox1.Enabled = true;
            this.hImageComboBoxEdit1.Enabled = true;
        }

        private void OffControl()
        {
            button1.Enabled = false;
            button2.Enabled = false;
            //comboBox1.Enabled = false;
            this.hImageComboBoxEdit1.Enabled = false;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            lbExcode.Text = "";
            lbExstatus.Text = "";
            lbPID.Text = "";
            lbPNM.Text = "";
            lbSex.Text = "";
            lbAge.Text = "";
            lbExam.Text = "";
            lbResult.Text = "";
            lbDate.Text = "";
            lbCode.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            //comboBox1.SelectedIndex = 0;
            this.hImageComboBoxEdit1.SelectedIndex = 0;

            try
            {
                tbPTNO.Text = SetPTNO(tbPTNO.Text);
                bool bPtno = DBSearch();
                
                if (!bPtno)
                {
                    if (EMROpen())
                    {
                        if (!EMRSearch())
                        {
                            CtrlClear();
                            DevExpress.XtraEditors.XtraMessageBox.Show("병리번호가 존재하지 않습니다.");
                            return;
                        }
                        else
                        {
                            DBInsert();
                            OnControl();
                        }
                    }
                    else
                    {
                        CtrlClear();
                        OffControl();
                        DevExpress.XtraEditors.XtraMessageBox.Show("병리번호가 존재하지 않습니다.");
                    }
                }
                else
                    OnControl();
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                CtrlClear();
            }

            Myconn.Close();
        }

        private void CtrlClear()
        {
            lbExcode.Text = "";
            lbExstatus.Text = "";
            lbPID.Text = "";
            lbPNM.Text = "";
            lbSex.Text = "";
            lbAge.Text = "";
            lbExam.Text = "";
            lbDate.Text = "";
            lbResult.Text = "";
            lbCode.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        public static bool EMROpen()
        {
            try
            {
                string strEMR = Ini.strOCSDB;
                EMRconn = new OleDbConnection(strEMR);
                EMRconn.Open();
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        private bool EMRSearch()
        {
            try
            {
                string strQuery = "SELECT DISTINCT A.PATHO_NO, "+
                              " A.PT_NO, " +
                              " A.PT_NM, "+
                              " A.SEX, "+
                              " (SELECT DECODE(SIGN(24-trunc(months_between(A.ACPT_DTM, a.pt_birth_dtm))), 1, trunc(months_between(A.ACPT_DTM, a.pt_birth_dtm))|| 'Mo' , trunc(months_between(A.ACPT_DTM, a.pt_birth_dtm)/12) ) "+
                              "   FROM DUAL "+
                              " ) as age, "+
                              " a.TST_FRCT_CD, " +
                              " xsup.FC_DEPART_NAME(C.PT_DP_CD) as dept, "+
                              " xsup.FT_C_NAME(NVL(G.TST_CD,C.ORD_CD)) examcode, "+
                              " TO_CHAR(A.ACPT_DTM,'YYYY-MM-DD'), "+
                              " NVL(G.TST_CD,C.ORD_CD) " +
                              "FROM SPXWORKT A , "+
                                   "MOEEXAMT C , "+
                                   "CCDEPART D , "+
                                   "SPRESULT E , "+
                                   "SPRDRSLT F , "+
                                   "SP0ITEDT G "+
                             "WHERE A.ST1 <>'F' "+
                                   "AND A.PT_NO=C.PT_NO "+
                                   "AND A.PATHO_NO = E.PATHO_NO(+) "+
                                   "AND A.PATHO_NO = F.PATHO_NO(+) "+
                                   "AND C.FEE_GRP='PA' "+
                                   "AND A.PATHO_NO=C.SPC_NO "+
                                   "AND C.PT_DP_CD = D.DEPT_CD "+
                                   "AND C.ORD_CD = G.GRP_CD(+) "+
                                   "AND NOT "+
                                   "( C.ORD_CD LIKE 'PSF%' AND C.SUGA_CD = 'FB999' ) "+
                                   "AND a.patho_no = '" + SetPTNO(tbPTNO.Text) + "'";
  
                OleDbCommand cmd = new OleDbCommand(strQuery, EMRconn);
                OleDbDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    lbExstatus.Text = "육안검사";   //검사상태
                    
                    lbPID.Text = read[1].ToString();        //환자번호
                    lbPNM.Text = read[2].ToString();        //환자이름
                    lbSex.Text = read[3].ToString();        //환자성별
                    lbAge.Text = read[4].ToString();        //환자나이
                    lbExcode.Text = read[5].ToString();     //검사분류
                    lbExam.Text = read[6].ToString();       //진료과아
                    //lbDoc.Text = read[8].ToString();        //주치의사
                    lbDate.Text = read[8].ToString();       //접수일자
                    //lbResult.Text = read[10].ToString();     //결과시간
                    lbCode.Text = read[9].ToString();       //검사코드
                }
                read.Close();
                EMRconn.Close();
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                return false;	
            }


            return true;
        }

        public static string EMRPIASearch(string sPTNO) //추가처방조회
        {
            string strData = "";
            try
            {
                string strQuery = "SELECT ORD_CD FROM MOEEXAMT WHERE SPC_NO = '" + SetPTNO(sPTNO) + "' and ORD_CD like 'PIAG%' ";

                OleDbCommand cmd = new OleDbCommand(strQuery, EMRconn);
                OleDbDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    strData = read[0].ToString();       //검사코드
                }
                read.Close();
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                return strData;
            }

            return strData;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Gross dlg = new Gross();
            dlg.strGross = textBox2.Text;
            dlg.strPTNO = tbPTNO.Text;
            dlg.ShowDialog();
            textBox2.Text = dlg.strGross;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("종료 하시겠습니까?", "종료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                Close();
            }
            else
            {
                return;
            }
        }

        private void tbPTNO_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Return)
            {
                
                btnSearch.PerformClick();
            }
        }

        private void btnDiagnosis1_Click(object sender, EventArgs e)
        {
            Diagnosis1 dlg = new Diagnosis1();
            dlg.Show();
            textBox3.Text = dlg.strDis;
        }

        private void btnDiagnosis2_Click(object sender, EventArgs e)
        {
            Diagnosis2 dlg = new Diagnosis2();
            dlg.Show();
            textBox3.Text = dlg.strDis;
        }

        private void AllClear()
        {
            lbPID.Text = "";
            lbExcode.Text = "";
            lbPNM.Text = "";
            lbExstatus.Text = "";
            lbSex.Text = "";
            lbAge.Text = "";
            lbCode.Text = "";
            lbDate.Text = "";
            lbResult.Text = "";
            lbExam.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            View dlg = new View();
            dlg.strMSG = textBox2.Text + "\r\n\r\n\r\r\n\r\n" + textBox3.Text;
            dlg.strPTNO = tbPTNO.Text;
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "View")
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                        openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                    }

                    return;
                }
            }
            dlg.Show();

        }        

        private void button2_Click(object sender, EventArgs e)
        {
            
        }
        public void GetPTNO(string PTNO)
        {
            tbPTNO.Text = PTNO;
        }

        private void btnEmrSend_Click(object sender, EventArgs e)
        {
            EMRUpdate();
        }

        private void EMRUpdate()
        {
            try
            {
                string strEMR = Ini.strOCSDB;
                EMRconn = new OleDbConnection(strEMR);
                EMRconn.Open();
                
                string strSQL = "SELECT NVL(MAX(SEQ_NO)+1,'1')  FROM sptprslt WHERE PATHO_NO = '" + SetPTNO(tbPTNO.Text) + "'";
                
                OleDbCommand cmd = new OleDbCommand(strSQL, EMRconn);
                OleDbDataReader rd1 = cmd.ExecuteReader();
                
                string strSEQ = "";
                string strGross = "";
                string strIsRs = "";
                while (rd1.Read())
                {
                    strSEQ = rd1[0].ToString();
                    
                }
                
                rd1.Close();

                if (strSEQ == "")
                {
                    return;
                }
                strGross = textBox2.Text.Replace("'", "^");
                strIsRs = textBox3.Text.Replace("'", "^");
                strSQL = string.Format("INSERT INTO sptprslt (PATHO_NO, SEQ_NO, READ_RSLT, EDIT_ID, EDIT_DTM, PT_NO ) VALUES (" +
                                       " '{0}', '{1}', '{2}', 'SEDAS','{3}', '{4}' )",
                                       tbPTNO.Text, strSEQ, strGross + "\r\n\r\n\r\r\n\r\n" + strIsRs, DateTime.Now.ToString("yyyyMMddHHmmss"), lbPID.Text);
                //오류
                
                cmd = new OleDbCommand(strSQL, EMRconn);
                cmd.ExecuteNonQuery();
                
                strSQL = string.Format("INSERT INTO sprslttt (PATHO_NO, READ_RSLT1, WK_ID, WK_DTM, PT_NO ) VALUES (" +
                                       " '{0}', '{1}', 'SEDAS','{2}', '{3}' )",
                                       tbPTNO.Text, strGross + "\r\n\r\n\r\r\n\r\n" + strIsRs, DateTime.Now.ToString("yyyyMMddHHmmss"), lbPID.Text);

                cmd = new OleDbCommand(strSQL, EMRconn);
                cmd.ExecuteNonQuery();
                EMRconn.Close();
                DevExpress.XtraEditors.XtraMessageBox.Show("전송완료");

            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                return;
            }
        }

        private void btnBase_Click(object sender, EventArgs e)
        {
            
        }

        private void tbPTNO_Click(object sender, EventArgs e)
        {
            tbPTNO.SelectAll();
        }

        private void btnDiaSearch_Click(object sender, EventArgs e)
        {
            DiaSearch dias = new DiaSearch();

            /*
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    dias.SMTP = "brs";
                    break;
                case 1:
                    dias.SMTP = "cvx";
                    break;
                case 2:
                    dias.SMTP = "col";
                    break;
                case 3:
                    dias.SMTP = "edc";
                    break;
                case 4:
                    dias.SMTP = "esp";
                    break;
                case 5:
                    dias.SMTP = "kdg";
                    break;
                case 6:
                    dias.SMTP = "lvi";
                    break;
                case 7:
                    dias.SMTP = "lvh";
                    break;
                case 8:
                    dias.SMTP = "lvm";
                    break;
                case 9:
                    dias.SMTP = "lng";
                    break;
                case 10:
                    dias.SMTP = "ovc";
                    break;
                case 11:
                    dias.SMTP = "prs";
                    break;
                case 12:
                    dias.SMTP = "rtc";
                    break;
                case 13:
                    dias.SMTP = "stg";
                    break;
                case 14:
                    dias.SMTP = "stm";
                    break;
                case 15:
                    dias.SMTP = "tst";
                    break;
                case 16:
                    dias.SMTP = "ubc";
                    break;
                case 17:
                    dias.SMTP = "ubt";
                    break;
            }*/

            dias.Show();
        }

        private void btnGrsBase_Click(object sender, EventArgs e)
        {
            GrossBaseline gbs = new GrossBaseline();
            gbs.Show();
        }

        private void btnInterest_Click(object sender, EventArgs e)
        {
            if (btnInterest.Text == "관심등록")
            {
                Interst dlg1 = new Interst();
                dlg1.PTNO = tbPTNO.Text;
                dlg1.Show();
                
                DBUpdate(1);
                btnInterest.Text = "관심해제";
            }
            else{
                DBUpdate(0);
                btnInterest.Text = "관심등록";
            }
        }

        public static string[] GetPIACode(string sCode)
        {
            string[] strCodeName = new string[10];
            int nCnt = 0;
            try
            {
                string strSQL = Ini.strDB;
                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();

                string sql = string.Format("SELECT piaaddcode FROM PISPIA001 WHERE piacode = '{0}' ", sCode);
                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    strCodeName[nCnt] = read[0].ToString();
                    nCnt++;
                }
                read.Close();
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                return null;
            }

            return strCodeName;
        }

        private void btnIntSearch_Click(object sender, EventArgs e)
        {
            DiaSearch2 dlg = new DiaSearch2();
            dlg.Show();
        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void 결과기초자료ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolStripTextBox1_Click(object sender, EventArgs e)
        {

        }

        private void gross기초자료ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            GrossBaseline gbs = new GrossBaseline();
            gbs.Show();
        }

        private void 결과기초자료ToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            BaselineData bld = new BaselineData();
            bld.Show();
        }

        private void 관심환자조회ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiaSearch2 dlg = new DiaSearch2();
            dlg.Show();
        }

        private void 병리결과조회ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DiaSearch dias = new DiaSearch();

            /*
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    dias.SMTP = "brs";
                    break;
                case 1:
                    dias.SMTP = "cvx";
                    break;
                case 2:
                    dias.SMTP = "col";
                    break;
                case 3:
                    dias.SMTP = "edc";
                    break;
                case 4:
                    dias.SMTP = "esp";
                    break;
                case 5:
                    dias.SMTP = "kdg";
                    break;
                case 6:
                    dias.SMTP = "lvi";
                    break;
                case 7:
                    dias.SMTP = "lvh";
                    break;
                case 8:
                    dias.SMTP = "lvm";
                    break;
                case 9:
                    dias.SMTP = "lng";
                    break;
                case 10:
                    dias.SMTP = "ovc";
                    break;
                case 11:
                    dias.SMTP = "prs";
                    break;
                case 12:
                    dias.SMTP = "rtc";
                    break;
                case 13:
                    dias.SMTP = "stg";
                    break;
                case 14:
                    dias.SMTP = "stm";
                    break;
                case 15:
                    dias.SMTP = "tst";
                    break;
                case 16:
                    dias.SMTP = "ubc";
                    break;
                case 17:
                    dias.SMTP = "ubt";
                    break;
            }*/

            dias.Show();
        }

        private void tableLayoutPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                btnEmrSend.Enabled = true;
            }
        }

        private void textBox2_TabIndexChanged(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && textBox3.Text != "")
            {
                btnEmrSend.Enabled = true;
            }
        }
        private void SearchDialog()
        {
            string strSQL = Ini.strDB;
            Myconn = new MySqlConnection(strSQL);
            Myconn.Open();
            string ex ="";
            string OGTP = "";

            //string selectedValue = comboBox1.Text;
            string selectedValue = this.hImageComboBoxEdit1.SedasSelectedValue;

            if (selectedValue == "Breast")
            {
                OGTP = "brs";
            }
            else if (selectedValue == "Cervix")
            {
                OGTP = "cvx";
            }
            else if (selectedValue == "Colon")
            {
                OGTP = "col";
            }
            else if (selectedValue == "Endometrial cancer")
            {
                OGTP = "edc";
            }
            else if (selectedValue == "Esophagus")
            {
                OGTP = "esp";
            }
            else if (selectedValue == "Kidney")
            {
                OGTP = "kdn";
            }
            else if (selectedValue == "Liver Hepatectomy")
            {
                OGTP = "lvh";
            }
            else if (selectedValue == "Liver Intrahepatic")
            {
                OGTP = "lvi";
            }
            else if (selectedValue == "Liver meta")
            {
                OGTP = "lvm";
            }
            else if (selectedValue == "Lung")
            {
                OGTP = "lng";
            }
            else if (selectedValue == "Ovary cancer")
            {
                OGTP = "ovc";
            }
            else if (selectedValue == "Prostate")
            {
                OGTP = "prs";
            }
            else if (selectedValue == "Rectal")
            {
                OGTP = "rtc";
            }
            else if (selectedValue == "Stomach gastrectomy")
            {
                OGTP = "stm";
            }
            else if (selectedValue == "Stomach GIST")
            {
                OGTP = "stg";
            }
            else if (selectedValue == "TESTIS")
            {
                OGTP = "tst";
            }
            else if (selectedValue == "Urinary bladder carcinoma")
            {
                OGTP = "ubc";
            }
            else if (selectedValue == "Urinary bladder turb")
            {
                OGTP = "ubt";
            }
            else
            {
                OGTP = "OGTP";
            }
            string sql = string.Format("SELECT OGTP FROM PISDIG001 WHERE PTNO = '{0}' ", tbPTNO.Text);
            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader read = cmd.ExecuteReader();
            while (read.Read())
            {
                ex = read[0].ToString();
            }
            
            if (ex=="" || ex == " " || ex == OGTP)
            {
                ext = true;
            }
            else
            {
               ext = false;
            }
            read.Close();
            Myconn.Close();

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

            


            //switch (comboBox1.SelectedIndex)
            switch(hImageComboBoxEdit1.SelectedIndex)
            {
                case 0:
                    DevExpress.XtraEditors.XtraMessageBox.Show("장기를 선택하세요");
                    break;
                case 1:
                    Breast dlg1 = new Breast();
                    dlg1.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Breast")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg1.Show();
                    break;
                case 2:
                    Cervix dlg2 = new Cervix();
                    dlg2.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Cervix")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg2.Show();
                    break;
                case 3:
                    Colon__left_hemicoloectomy dlg3 = new Colon__left_hemicoloectomy();
                    dlg3.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Colon__left_hemicoloectomy")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg3.Show();
                    break;
                case 4:
                    Endometrial_cancer dlg4 = new Endometrial_cancer();
                    dlg4.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Endometrial_cancer")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg4.Show();
                    break;
                case 5:
                    Esophagus_ dlg5 = new Esophagus_();
                    dlg5.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Esophagus_")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg5.Show();
                    break;
                case 6:
                    Kidney dlg6 = new Kidney();
                    dlg6.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Kidney")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg6.Show();
                    break;
                case 7:
                    var dlg7 = new Liver__hepatectomy();
                    dlg7.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Liver__hepatectomy")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg7.Show();
                    break;
                case 8:
                    var dlg8 = new Liver_Intrahepatic_Cholangiocarcinoma();
                    dlg8.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Liver_Intrahepatic_Cholangiocarcinoma")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg8.Show();
                    break;
                case 9:
                    var dlg9 = new Liver__meta();
                    dlg9.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Liver__meta")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg9.Show();
                    break;
                case 10:
                    var dlg10 = new Lung();
                    dlg10.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Lung")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg10.Show();
                    break;
                case 11:
                    var dlg11 = new Ovary_cancer();
                    dlg11.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Ovary_cancer")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg11.Show();
                    break;
                case 12:
                    var dlg12 = new prostate();
                    dlg12.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "prostate")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg12.Show();
                    break;
                case 13:
                    var dlg13 = new Rectal_cancer();
                    dlg13.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Rectal_cancer")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg13.Show();
                    break;
                case 14:
                    var dlg14 = new Stomach_gastrectomy();
                    dlg14.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Stomach_gastrectomy")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg14.Show();
                    break;
                case 15:
                    var dlg15 = new Stomach__GIST();
                    dlg15.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Stomach__GIST")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg15.Show();
                    break;
                case 16:
                    var dlg16 = new TESTIS();
                    dlg16.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "TESTIS")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg16.Show();
                    break;
                case 17:
                    var dlg17 = new Urinary_bladder__cystectomy();
                    dlg17.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Urinary_bladder__cystectomy")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg17.Show();
                    break;
                case 18:
                    var dlg18 = new Urinary_bladder();
                    dlg18.PTNO = tbPTNO.Text;
                    SearchDialog();
                    if (ext == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("장기를 확인 하세요");
                        return;
                    }
                    foreach (Form openForm in Application.OpenForms)
                    {
                        if (openForm.Name == "Urinary_bladder")
                        {
                            if (openForm.WindowState == FormWindowState.Minimized)
                            {
                                openForm.WindowState = FormWindowState.Normal;
                                openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                            }

                            return;
                        }
                    }
                    dlg18.Show();
                    break;
            }
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            GrossBaseline gbs = new GrossBaseline();
            gbs.Show();
        }

        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            BaselineData bld = new BaselineData();
            bld.Show();
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            DiaSearch2 dlg = new DiaSearch2();
            dlg.Show();
        }

        private void toolStripButton9_Click(object sender, EventArgs e)
        {
            DiaSearch dias = new DiaSearch();

            /*
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    dias.SMTP = "brs";
                    break;
                case 1:
                    dias.SMTP = "cvx";
                    break;
                case 2:
                    dias.SMTP = "col";
                    break;
                case 3:
                    dias.SMTP = "edc";
                    break;
                case 4:
                    dias.SMTP = "esp";
                    break;
                case 5:
                    dias.SMTP = "kdg";
                    break;
                case 6:
                    dias.SMTP = "lvi";
                    break;
                case 7:
                    dias.SMTP = "lvh";
                    break;
                case 8:
                    dias.SMTP = "lvm";
                    break;
                case 9:
                    dias.SMTP = "lng";
                    break;
                case 10:
                    dias.SMTP = "ovc";
                    break;
                case 11:
                    dias.SMTP = "prs";
                    break;
                case 12:
                    dias.SMTP = "rtc";
                    break;
                case 13:
                    dias.SMTP = "stg";
                    break;
                case 14:
                    dias.SMTP = "stm";
                    break;
                case 15:
                    dias.SMTP = "tst";
                    break;
                case 16:
                    dias.SMTP = "ubc";
                    break;
                case 17:
                    dias.SMTP = "ubt";
                    break;
            }*/

            dias.Show();
        }

        private void 병리결과조회ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DiaSearch dias = new DiaSearch();
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "DiaSearch")
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                        openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                    }

                    return;
                }
            }

            /*
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    dias.SMTP = "brs";
                    break;
                case 1:
                    dias.SMTP = "cvx";
                    break;
                case 2:
                    dias.SMTP = "col";
                    break;
                case 3:
                    dias.SMTP = "edc";
                    break;
                case 4:
                    dias.SMTP = "esp";
                    break;
                case 5:
                    dias.SMTP = "kdg";
                    break;
                case 6:
                    dias.SMTP = "lvi";
                    break;
                case 7:
                    dias.SMTP = "lvh";
                    break;
                case 8:
                    dias.SMTP = "lvm";
                    break;
                case 9:
                    dias.SMTP = "lng";
                    break;
                case 10:
                    dias.SMTP = "ovc";
                    break;
                case 11:
                    dias.SMTP = "prs";
                    break;
                case 12:
                    dias.SMTP = "rtc";
                    break;
                case 13:
                    dias.SMTP = "stg";
                    break;
                case 14:
                    dias.SMTP = "stm";
                    break;
                case 15:
                    dias.SMTP = "tst";
                    break;
                case 16:
                    dias.SMTP = "ubc";
                    break;
                case 17:
                    dias.SMTP = "ubt";
                    break;
            }*/

            dias.Show();
        }

        private void 관심환자조회ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            DiaSearch2 dlg = new DiaSearch2();
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "DiaSearch2")
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                        openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                    }

                    return;
                }
            }
            dlg.Show();
        }

        private void 결과기초자료ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            BaselineData bld = new BaselineData();
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "BaselineData")
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                        openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                    }

                    return;
                }
            }
            bld.Show();
        }

        private void gross기초자료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GrossBaseline gbs = new GrossBaseline();
            foreach (Form openForm in Application.OpenForms)
            {
                if (openForm.Name == "GrossBaseline")
                {
                    if (openForm.WindowState == FormWindowState.Minimized)
                    {
                        openForm.WindowState = FormWindowState.Normal;
                        openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);

                    }

                    return;
                }
            }
            gbs.Show();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            InsertlogoutDB();
        }
        private void InsertlogoutDB()
        {
            try{

                    string sql = "INSERT INTO pisusr001 (WKID, WKNM, Logout, date) VALUES ( '[WKID]', '[WKNM]', '1', '[date]')";
                    sql = sql.Replace("[WKID]", Ini.WK_ID);
                    sql = sql.Replace("[WKNM]", Ini.WK_NM);
                    sql = sql.Replace("[date]", DateTime.Now.ToString("yyyyMMddHHmmss"));

                    
                    string strSQL = Ini.strDB;
                    Myconn = new MySqlConnection(strSQL);
                    MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                    Myconn.Open();
                    cmd.ExecuteNonQuery();
                    Myconn.Close();
                }
            
                catch(SystemException ex)
                {
                DevExpress.XtraEditors.XtraMessageBox.Show("Insert 실패");
                }
        }


        /// <summary>
        /// name         : tableLayoutPanel1_CellPaint
        /// desc         : layout 보더 컬러 지정
        /// author       : 심우종
        /// create date  : 2020-06-15 15:08
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void tableLayoutPanel1_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var rectangle = e.CellBounds;
            //rectangle.X = 3;
            //rectangle.Width = rectangle.Width - 5;
            Color color = Global.borderColor;
            int borderWidth = 1;
            if (e.Row == 0)
            {
                if (e.Column == 0)
                {
                    ControlPaint.DrawBorder(e.Graphics, rectangle, color, borderWidth, ButtonBorderStyle.Solid
                                                              , color, borderWidth, ButtonBorderStyle.Solid
                                                              , color, borderWidth, ButtonBorderStyle.Solid
                                                              , color, borderWidth, ButtonBorderStyle.Solid);
                }
                else
                {
                    ControlPaint.DrawBorder(e.Graphics, rectangle, color, 0, ButtonBorderStyle.Solid
                                                              , color, borderWidth, ButtonBorderStyle.Solid
                                                              , color, borderWidth, ButtonBorderStyle.Solid
                                                              , color, borderWidth, ButtonBorderStyle.Solid);
                }
                
            }
            else
            {
                if (e.Column == 0)
                {
                    ControlPaint.DrawBorder(e.Graphics, rectangle, color, borderWidth, ButtonBorderStyle.Solid
                                                                  , color, 0, ButtonBorderStyle.Solid
                                                                  , color, borderWidth, ButtonBorderStyle.Solid
                                                                  , color, borderWidth, ButtonBorderStyle.Solid);
                }
                else
                {
                    ControlPaint.DrawBorder(e.Graphics, rectangle, color, 0, ButtonBorderStyle.Solid
                                                                      , color, 0, ButtonBorderStyle.Solid
                                                                      , color, borderWidth, ButtonBorderStyle.Solid
                                                                      , color, borderWidth, ButtonBorderStyle.Solid);
                }
                
            }

        }
    }
}
