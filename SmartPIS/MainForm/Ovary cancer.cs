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
using System.Diagnostics;


namespace SmartPIS
{
    public partial class Ovary_cancer : DevExpress.XtraEditors.XtraForm
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public static MySqlConnection Myconn;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        public string HMTP = "ovc";
        public string PTNO;
        public string block1;
        public string block2;
        public string totalAdd;

        public Ovary_cancer()
        {
            InitializeComponent();
        }

        private void label16_Click(object sender, EventArgs e)
        {
        }

        private void comboBox24_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
        {
            /*
            dataGridView3.Rows.Clear();
            tbATX1.Text = "#. Immunohistochemistry";
            tbATX2.Text = "#. Histochemistry\r\nVanGieson elastic fiber\r\nMucicarmine\r\nMasson Trichrome";

            dataGridView3.Rows.Add("TIF-1", "", "");
            dataGridView3.Rows.Add("CK7", "", "");
            dataGridView3.Rows.Add("p63", "", "");
            dataGridView3.Rows.Add("CK5/6", "", "");
            dataGridView3.Rows.Add("ALK", "", "");
            dataGridView3.Rows.Add("p53", "", "");
             */
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Ini.G_IniWriteValue("Info", "PTNO", PTNO, Ini.strPath);
            string path = System.Environment.CurrentDirectory + "\\Library.exe";
            string serverpath = Ini.LibraryPath;
            try
            {
                FileInfo file = new FileInfo(serverpath); //프로그램 업데이트
                file.CopyTo(path, true);
            }
            catch (SystemException ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("파일복사 실패");
            }
            Process.Start(path);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select DITX from PISDIG001 where PTNO ='[PTNO]' and OGTP ='OVC'";
                sql = sql.Replace("[PTNO]", PTNO);
                string strSQL = Ini.strDB;
                MySqlConnection conn = new MySqlConnection(strSQL);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader drc = cmd.ExecuteReader();

                bool bRet = false;

                while (drc.Read())
                {
                    bRet = true;
                }

                if (bRet)
                {

                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("해당하는 병리번호에 저장된 텍스트가 존재하지 않습니다");
                    return;

                }


                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm.Name == "ViewTEXTcs")
                    {
                        openForm.WindowState = FormWindowState.Normal;

                        return;
                    }
                    openForm.Activate();

                }
                ViewTEXTcs dlg = new ViewTEXTcs();

                dlg.PTNO = PTNO;

                dlg.OGTP = HMTP;
                dlg.ShowDialog();
            }
            catch (System.Exception ex)
            {
            }
        }

        private void Ovary_cancer_Load(object sender, EventArgs e)
        {
            try
            {
                CoreLibrary core = new CoreLibrary();
                core.InitGridStyle(dataGridView3);

                cbt00001.Items.Add(" ");
                cbt00002.Items.Add(" ");
                cb00101.Items.Add(" ");

                cb00201.Items.Add(" ");
                
                cb00402.Items.Add(" ");
                cb00403.Items.Add(" ");
                cb00501.Items.Add(" ");
                cb00601.Items.Add(" ");
                cb00701.Items.Add(" ");
                cb00703.Items.Add(" ");
                cb00705.Items.Add(" ");
                cb00707.Items.Add(" ");
                cb00709.Items.Add(" ");
                cb00711.Items.Add(" ");
                cb00713.Items.Add(" ");
                cb00715.Items.Add(" ");

                cb00801.Items.Add(" ");
                                
                string strSQL = Ini.strDB;

                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();

                Insertcombo00001();
                Insertcombo00002();

                Insertcombo00101();
                Insertcombo00201();
              
                Insertcombo00402();
                Insertcombo00403();

                Insertcombo00501();

                Insertcombo00601();
                
                Insertcombo00701();
                Insertcombo00703();
                Insertcombo00705();
                Insertcombo00707();
                Insertcombo00709();
                Insertcombo00711();
                Insertcombo00713();
                Insertcombo00715();
                
                Insertcombo00801();





                String sql = "select TIT1, TIT2, TIT3, n0101, n0201, n0301, n0302, n0303, n0304, n0305, n0306,n0401,n0402,n0403,n0404, n0501, n0601, n0701, n0702, n0703, n0704, n0705, n0706, n0707, n0708, n0709, n0710, n0711, n0712, n0713, n0714, n0715, n0716, n0801, n0901,ECTX,NOTE,ATX1,ATX2 from PISOVC001 where PTNO ='[PTNO]'";

                sql = sql.Replace("[PTNO]", PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();



                while (dr.Read())
                {

                    cbt00001.SelectedIndex = selectData00001(dr[0].ToString());
                    cbt00002.SelectedIndex = selectData00002(dr[1].ToString());
                    tbt00003.Text = dr[2].ToString().Replace("^", "'");

                    cb00101.SelectedIndex = selectData00101(dr[3].ToString());

                    cb00201.SelectedIndex = selectData00201(dr[4].ToString());
                    
                    tb00301.Text = dr[5].ToString().Replace("^", "'");
                    tb00302.Text = dr[6].ToString().Replace("^", "'");
                    tb00303.Text = dr[7].ToString().Replace("^", "'");
                    tb00304.Text = dr[8].ToString().Replace("^", "'");
                    tb00305.Text = dr[9].ToString().Replace("^", "'");
                    tb00306.Text = dr[10].ToString().Replace("^", "'");

                    tb00401.Text = dr[11].ToString().Replace("^", "'");
                    cb00402.SelectedIndex = selectData00402(dr[12].ToString());
                    cb00403.SelectedIndex = selectData00403(dr[13].ToString());
                    tb00404.Text = dr[14].ToString().Replace("^", "'");


                    cb00501.SelectedIndex = selectData00501(dr[15].ToString());

                    cb00601.SelectedIndex = selectData00601(dr[16].ToString());



                    cb00701.SelectedIndex = selectData00701(dr[17].ToString());
                    tb00702.Text = dr[18].ToString().Replace("^", "'");
                    cb00703.SelectedIndex = selectData00703(dr[19].ToString());
                    tb00704.Text = dr[20].ToString().Replace("^", "'");
                    cb00705.SelectedIndex = selectData00705(dr[21].ToString());
                    tb00706.Text = dr[22].ToString().Replace("^", "'");
                    cb00707.SelectedIndex = selectData00707(dr[23].ToString());
                    tb00708.Text = dr[24].ToString().Replace("^", "'");
                    cb00709.SelectedIndex = selectData00709(dr[25].ToString());
                    tb00710.Text = dr[26].ToString().Replace("^", "'");
                    cb00711.SelectedIndex = selectData00711(dr[27].ToString());
                    tb00712.Text = dr[28].ToString().Replace("^", "'");
                    cb00713.SelectedIndex = selectData00713(dr[29].ToString());
                    tb00714.Text = dr[30].ToString().Replace("^", "'");
                    cb00715.SelectedIndex = selectData00715(dr[31].ToString());
                    tb00716.Text = dr[32].ToString().Replace("^", "'");

                    cb00801.SelectedIndex = selectData00801(dr[33].ToString());
                                        
                    tb00901.Text = dr[34].ToString().Replace("^", "'");

                    

                    //161005

                    tbECTX.Text = dr[35].ToString().Replace("^", "'");
                    tbNOTE.Text = dr[36].ToString().Replace("^", "'");
                    tbATX1.Text = dr[37].ToString().Replace("^", "'");
                    tbATX2.Text = dr[38].ToString().Replace("^", "'");
                    selectAdd();
                }
                dr.Close();

                Selectblock();
            }
            catch (System.Exception ex)
            {
            }
        }

        private void Selectblock()
        {

            string sql = "select ABLK, NBLK from PISDIG001 where PTNO ='[PTNO]' and OGTP ='OVC'";
            sql = sql.Replace("[PTNO]", PTNO);
            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                tbblock01.Text = drc[0].ToString().Replace("^", "'");
                tbblock03.Text = drc[1].ToString().Replace("^", "'");

            }
            drc.Close();

        }

        private void selectAdd()
        {

            string sql = "select A101,A102,A103,A201,A202,A203,A301,A302,A303,A401,A402,A403,A501,A502,A503,A601,A602,A603,A701,A702,A703,A801,A802,A803,A901,A902,A903 from PISOVC001 where PTNO ='[PTNO]'";
            sql = sql.Replace("[PTNO]", PTNO);
            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();

            while (drc.Read())
            {

                if (drc[0].ToString() != "" || drc[1].ToString() != "" || drc[2].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[0].ToString(), drc[1].ToString(), drc[2].ToString());
                }
                if (drc[3].ToString() != "" || drc[4].ToString() != "" || drc[5].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[3].ToString(), drc[4].ToString(), drc[5].ToString());
                }
                if (drc[6].ToString() != "" || drc[7].ToString() != "" || drc[8].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[6].ToString(), drc[7].ToString(), drc[8].ToString());
                }
                if (drc[9].ToString() != "" || drc[10].ToString() != "" || drc[11].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[9].ToString(), drc[10].ToString(), drc[11].ToString());
                }
                if (drc[12].ToString() != "" || drc[13].ToString() != "" || drc[14].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[12].ToString(), drc[13].ToString(), drc[14].ToString());
                }
                if (drc[15].ToString() != "" || drc[16].ToString() != "" || drc[17].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[15].ToString(), drc[16].ToString(), drc[17].ToString());
                }
                if (drc[18].ToString() != "" || drc[19].ToString() != "" || drc[20].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[18].ToString(), drc[19].ToString(), drc[20].ToString());
                }
                if (drc[21].ToString() != "" || drc[22].ToString() != "" || drc[23].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[21].ToString(), drc[22].ToString(), drc[23].ToString());
                }
                if (drc[24].ToString() != "" || drc[25].ToString() != "" || drc[26].ToString() != "")
                {
                    dataGridView3.Rows.Add(drc[24].ToString(), drc[25].ToString(), drc[26].ToString());
                }

            }
            drc.Close();


        }


        private int selectData00001(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00001'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00002(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00002'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00101(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00101'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00201(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00201'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00402(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00401'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00403(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00402'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00501(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00501'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00601(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00601'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00701(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00701'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00703(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00702'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00705(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00703'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00707(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00704'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00709(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00705'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00711(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00706'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00713(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00707'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00715(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00708'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private int selectData00801(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'OVC'and  SQNO = '00801'";

            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            while (drc.Read())
            {
                n = Convert.ToInt32(drc[0].ToString());
            }

            drc.Close();
            conn.Close();
            /* if (n > 0)
             {
                 n--;
             }*/
            return n;
        }

        private void Insertcombo00001()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00001";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbt00001.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00002()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00002";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbt00002.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00101()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00101";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00101.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00201()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00201";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00201.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00402()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00401";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00402.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00403()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00402";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00403.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00501()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00501";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00501.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00601()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00601";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00601.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00701()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00701";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00701.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00703()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00702";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00703.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00705()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00703";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00705.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00707()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00704";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00707.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00709()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00705";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00709.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00711()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00706";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00711.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00713()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00707";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00713.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00715()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00708";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00715.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00801()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00801";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00801.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = "select * from PISOVC001 where PTNO = '[PTNO]'";
                sql = sql.Replace("[PTNO]", PTNO);
                string strSQL = Ini.strDB;
                MySqlConnection conn = new MySqlConnection(strSQL);
                conn.Open();
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                MySqlDataReader drc = cmd.ExecuteReader();

                bool bRet = false;

                while (drc.Read())
                {
                    bRet = true;
                }

                if (bRet)
                {
                    UpdateDB();
                }
                else
                {
                    InsertDB();

                }
                reset();
                selectOVC();
                Selectblock();
                drc.Close();
                conn.Close();
            }
            catch (System.Exception ex)
            {
            }
        }

        private void reset()
        {
            //161005
            cbt00001.Text = " ";
            cbt00002.Text = " ";
            tbt00003.Text = "Ovarian Cancer";
            
            cb00101.Text = " ";

            cb00201.Text = " ";
            
            tb00301.Text = "";
            tb00302.Text = "";
            tb00303.Text = "";
            tb00304.Text = "";
            tb00305.Text = "";
            tb00306.Text = "";

            tb00401.Text = "";
            cb00402.Text = " ";
            cb00403.Text = " ";
            tb00404.Text = "";

            cb00501.Text = " ";

            cb00601.Text = " ";
            

            cb00701.Text = " ";
            tb00702.Text = "";
            cb00703.Text = " ";
            tb00704.Text = "";
            cb00705.Text = " ";
            tb00706.Text = "";
            cb00707.Text = " ";
            tb00708.Text = "";
            cb00709.Text = " ";
            tb00710.Text = "";
            cb00711.Text = " ";
            tb00712.Text = "";
            cb00713.Text = " ";
            tb00714.Text = "";
            cb00715.Text = " ";
            tb00716.Text = "";
            
            cb00801.Text = " ";
            

            tb00901.Text = "";
            

            tbECTX.Text = "";
            tbNOTE.Text = "";

            tbblock01.Text = "";
            tbblock03.Text = "";
            tbATX1.Text = "";
            tbATX2.Text = "";
            dataGridView3.Rows.Clear();
            cbt00001.Select();
        }
        private void selectOVC()
        {

            String sql = "select TIT1, TIT2, TIT3, n0101, n0201, n0301, n0302, n0303, n0304, n0305, n0306,n0401,n0402,n0403,n0404, n0501, n0601, n0701, n0702, n0703, n0704, n0705, n0706, n0707, n0708, n0709, n0710, n0711, n0712, n0713, n0714, n0715, n0716, n0801, n0901,ECTX,NOTE,ATX1,ATX2 from PISOVC001 where PTNO ='[PTNO]'";

            sql = sql.Replace("[PTNO]", PTNO);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read())
            {

                cbt00001.SelectedIndex = selectData00001(dr[0].ToString());
                cbt00002.SelectedIndex = selectData00002(dr[1].ToString());
                tbt00003.Text = dr[2].ToString().Replace("^", "'");

                cb00101.SelectedIndex = selectData00101(dr[3].ToString());

                cb00201.SelectedIndex = selectData00201(dr[4].ToString());

                tb00301.Text = dr[5].ToString().Replace("^", "'");
                tb00302.Text = dr[6].ToString().Replace("^", "'");
                tb00303.Text = dr[7].ToString().Replace("^", "'");
                tb00304.Text = dr[8].ToString().Replace("^", "'");
                tb00305.Text = dr[9].ToString().Replace("^", "'");
                tb00306.Text = dr[10].ToString().Replace("^", "'");

                tb00401.Text = dr[11].ToString().Replace("^", "'");
                cb00402.SelectedIndex = selectData00402(dr[12].ToString());
                cb00403.SelectedIndex = selectData00403(dr[13].ToString());
                tb00404.Text = dr[14].ToString().Replace("^", "'");


                cb00501.SelectedIndex = selectData00501(dr[15].ToString());

                cb00601.SelectedIndex = selectData00601(dr[16].ToString());



                cb00701.SelectedIndex = selectData00701(dr[17].ToString());
                tb00702.Text = dr[18].ToString().Replace("^", "'");
                cb00703.SelectedIndex = selectData00703(dr[19].ToString());
                tb00704.Text = dr[20].ToString().Replace("^", "'");
                cb00705.SelectedIndex = selectData00705(dr[21].ToString());
                tb00706.Text = dr[22].ToString().Replace("^", "'");
                cb00707.SelectedIndex = selectData00707(dr[23].ToString());
                tb00708.Text = dr[24].ToString().Replace("^", "'");
                cb00709.SelectedIndex = selectData00709(dr[25].ToString());
                tb00710.Text = dr[26].ToString().Replace("^", "'");
                cb00711.SelectedIndex = selectData00711(dr[27].ToString());
                tb00712.Text = dr[28].ToString().Replace("^", "'");
                cb00713.SelectedIndex = selectData00713(dr[29].ToString());
                tb00714.Text = dr[30].ToString().Replace("^", "'");
                cb00715.SelectedIndex = selectData00715(dr[31].ToString());
                tb00716.Text = dr[32].ToString().Replace("^", "'");

                cb00801.SelectedIndex = selectData00801(dr[33].ToString());

                tb00901.Text = dr[34].ToString().Replace("^", "'");



                //161005

                tbECTX.Text = dr[35].ToString().Replace("^", "'");
                tbNOTE.Text = dr[36].ToString().Replace("^", "'");
                tbATX1.Text = dr[37].ToString().Replace("^", "'");
                tbATX2.Text = dr[38].ToString().Replace("^", "'");
                selectAdd();
            }
            dr.Close();
        }

        private void addupdateDB()
        {
            int n = 0;


            for (int i = 0; i < Convert.ToUInt32(dataGridView3.Rows.Count - 1); i++)
            {
                string str1 = dataGridView3.Rows[i].Cells[0].FormattedValue.ToString();
                string str2 = dataGridView3.Rows[i].Cells[1].FormattedValue.ToString();
                string str3 = dataGridView3.Rows[i].Cells[2].FormattedValue.ToString();
                str1 = str1.Replace("'", "^");
                str2 = str2.Replace("'", "^");
                str3 = str3.Replace("'", "^");
                n = i + 1;
                string ADD1 = "A" + n + "01";
                string ADD2 = "A" + n + "02";
                string ADD3 = "A" + n + "03";

                string sql = String.Format("Update PISOVC001 set {0}='{1}', {2} = '{3}',{4}='{5}' where PTNO = '{6}'", ADD1, str1, ADD2, str2, ADD3, str3, PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }


        }
        private void UpdateDB()
        {

            string Titlestr0001 = cbt00001.Text;
            Titlestr0001 = Titlestr0001.Replace("'", "^");

            string Titlestr0002 = cbt00002.Text;
            Titlestr0002 = Titlestr0002.Replace("'", "^");

            string Titlestr0003 = tbt00003.Text;
            Titlestr0003 = Titlestr0003.Replace("'", "^");


            string str0101 = cb00101.Text;
            str0101 = str0101.Replace("'", "^");

            string str0201 = cb00201.Text;
            str0201 = str0201.Replace("'", "^");

            string str0301 = tb00301.Text;
            str0301 = str0301.Replace("'", "^");
            string str0302 = tb00302.Text;
            str0302 = str0302.Replace("'", "^");
            string str0303 = tb00303.Text;
            str0303 = str0303.Replace("'", "^");
            string str0304 = tb00304.Text;
            str0304 = str0304.Replace("'", "^");
            string str0305 = tb00305.Text;
            str0305 = str0305.Replace("'", "^");
            string str0306 = tb00306.Text;
            str0306 = str0306.Replace("'", "^");



            string str0401 = tb00401.Text;
            str0401 = str0401.Replace("'", "^");

            string str0402 = cb00402.Text;
            str0402 = str0402.Replace("'", "^");

            string str0403 = cb00403.Text;
            str0403 = str0403.Replace("'", "^");

            string str0404 = tb00404.Text;
            str0404 = str0404.Replace("'", "^");




            string str0501 = cb00501.Text;
            str0501 = str0501.Replace("'", "^");


            string str0601 = cb00601.Text;
            str0601 = str0601.Replace("'", "^");



            string str0701 = cb00701.Text;
            str0701 = str0701.Replace("'", "^");

            string str0702 = tb00702.Text;
            str0702 = str0702.Replace("'", "^");

            string str0703 = cb00703.Text;
            str0703 = str0703.Replace("'", "^");

            string str0704 = tb00704.Text;
            str0704 = str0704.Replace("'", "^");

            string str0705 = cb00705.Text;
            str0705 = str0705.Replace("'", "^");

            string str0706 = tb00706.Text;
            str0706 = str0706.Replace("'", "^");

            string str0707 = cb00707.Text;
            str0707 = str0707.Replace("'", "^");

            string str0708 = tb00708.Text;
            str0708 = str0708.Replace("'", "^");

            string str0709 = cb00709.Text;
            str0709 = str0709.Replace("'", "^");

            string str0710 = tb00710.Text;
            str0710 = str0710.Replace("'", "^");

            string str0711 = cb00711.Text;
            str0711 = str0711.Replace("'", "^");

            string str0712 = tb00712.Text;
            str0712 = str0712.Replace("'", "^");

            string str0713 = cb00713.Text;
            str0713 = str0713.Replace("'", "^");

            string str0714 = tb00714.Text;
            str0714 = str0714.Replace("'", "^");

            string str0715 = cb00715.Text;
            str0715 = str0715.Replace("'", "^");

            string str0716 = tb00716.Text;
            str0716 = str0716.Replace("'", "^");

            string str0801 = cb00801.Text;
            str0801 = str0801.Replace("'", "^");

            string str0901 = tb00901.Text;
            str0901 = str0901.Replace("'", "^");

            string ectb = tbECTX.Text;
            ectb = ectb.Replace("'", "^");

            string note = tbNOTE.Text;
            note = note.Replace("'", "^");

            string strATX1 = tbATX1.Text;
            strATX1.Replace("'", "^");
            string strATX2 = tbATX2.Text;
            strATX2.Replace("'", "^");
            string strblock001 = tbblock01.Text;
            strblock001.Replace("'", "^");
            string strblock002 = tbblock03.Text;
            strblock002.Replace("'", "^");

            string sql = "Update pisOVC001 SET SYDT = '[SYDT]', UPDT = '[UPDT]', UPID = '[UPID]', OGTP = '[OGTP]', DITP='[DITP]', TRYN ='[TRYN]', TIT1 = '[TIT1]',TIT2= '[TIT2]',TIT3= '[TIT3]', n0101 = '[n0101]', n0201 = '[n0201]', n0301='[n0301]',n0302='[n0302]',n0303='[n0303]',n0304='[n0304]',n0305='[n0305]',n0306='[n0306]', n0401 = '[n0401]', n0402 = '[n0402]', n0403 = '[n0403]', n0404 = '[n0404]', n0501 = '[n0501]',  n0601='[n0601]', n0701='[n0701]', n0702='[n0702]', n0703='[n0703]', n0704='[n0704]', n0705='[n0705]', n0706='[n0706]', n0707='[n0707]', n0708='[n0708]', n0709='[n0709]', n0710='[n0710]', n0711='[n0711]', n0712='[n0712]', n0713='[n0713]', n0714='[n0714]', n0715='[n0715]', n0716='[n0716]', n0801='[n0801]', n0901='[n0901]',ECTX='[ECTX]', NOTE='[NOTE]' , ATX1='[ATX1]',ATX2 ='[ATX2]' where PTNO ='[PTNO]'";
            //20161005
            sql = sql.Replace("[SYDT]", DateTime.Now.ToString("yyyyMMdd"));
            sql = sql.Replace("[UPDT]", DateTime.Now.ToString("yyyyMMdd"));
            sql = sql.Replace("[UPID]", "");
            sql = sql.Replace("[PTNO]", PTNO);
            sql = sql.Replace("[OGTP]", HMTP);
            sql = sql.Replace("[DITP]", "");
            sql = sql.Replace("[TRYN]", "N");

            sql = sql.Replace("[TIT1]", Titlestr0001);
            sql = sql.Replace("[TIT2]", Titlestr0002);
            sql = sql.Replace("[TIT3]", Titlestr0003);

            sql = sql.Replace("[n0101]", str0101);

            sql = sql.Replace("[n0201]", str0201);


            sql = sql.Replace("[n0301]", str0301);
            sql = sql.Replace("[n0302]", str0302);
            sql = sql.Replace("[n0303]", str0303);
            sql = sql.Replace("[n0304]", str0304);
            sql = sql.Replace("[n0305]", str0305);
            sql = sql.Replace("[n0306]", str0306);

            sql = sql.Replace("[n0401]", str0401);
            sql = sql.Replace("[n0402]", str0402);
            sql = sql.Replace("[n0403]", str0403);
            sql = sql.Replace("[n0404]", str0404);


            sql = sql.Replace("[n0501]", str0501);

            sql = sql.Replace("[n0601]", str0601);


            sql = sql.Replace("[n0701]", str0701);
            sql = sql.Replace("[n0702]", str0702);
            sql = sql.Replace("[n0703]", str0703);
            sql = sql.Replace("[n0704]", str0704);
            sql = sql.Replace("[n0705]", str0705);
            sql = sql.Replace("[n0706]", str0706);
            sql = sql.Replace("[n0707]", str0707);
            sql = sql.Replace("[n0708]", str0708);
            sql = sql.Replace("[n0709]", str0709);
            sql = sql.Replace("[n0710]", str0710);
            sql = sql.Replace("[n0711]", str0711);
            sql = sql.Replace("[n0712]", str0712);
            sql = sql.Replace("[n0713]", str0713);
            sql = sql.Replace("[n0714]", str0714);
            sql = sql.Replace("[n0715]", str0715);
            sql = sql.Replace("[n0716]", str0716);



            sql = sql.Replace("[n0801]", str0801);


            sql = sql.Replace("[n0901]", str0901);

            sql = sql.Replace("[ECTX]", ectb);
            sql = sql.Replace("[NOTE]", note);
            sql = sql.Replace("[ATX1]", strATX1);
            sql = sql.Replace("[ATX2]", strATX2);


            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            cmd.ExecuteNonQuery();
            addupdateDB();
            MainDBUpdate();
            DevExpress.XtraEditors.XtraMessageBox.Show("업데이트 되었습니다");

        }

        private void InsertDB()
        {
            string Titlestr0001 = cbt00001.Text;
            Titlestr0001 = Titlestr0001.Replace("'", "^");

            string Titlestr0002 = cbt00002.Text;
            Titlestr0002 = Titlestr0002.Replace("'", "^");

            string Titlestr0003 = tbt00003.Text;
            Titlestr0003 = Titlestr0003.Replace("'", "^");


            string str0101 = cb00101.Text;
            str0101 = str0101.Replace("'", "^");

            string str0201 = cb00201.Text;
            str0201 = str0201.Replace("'", "^");

            string str0301 = tb00301.Text;
            str0301 = str0301.Replace("'", "^");
            string str0302 = tb00302.Text;
            str0302 = str0302.Replace("'", "^");
            string str0303 = tb00303.Text;
            str0303 = str0303.Replace("'", "^");
            string str0304 = tb00304.Text;
            str0304 = str0304.Replace("'", "^");
            string str0305 = tb00305.Text;
            str0305 = str0305.Replace("'", "^");
            string str0306 = tb00306.Text;
            str0306 = str0306.Replace("'", "^");



            string str0401 = tb00401.Text;
            str0401 = str0401.Replace("'", "^");

            string str0402 = cb00402.Text;
            str0402 = str0402.Replace("'", "^");

            string str0403 = cb00403.Text;
            str0403 = str0403.Replace("'", "^");

            string str0404 = tb00404.Text;
            str0404 = str0404.Replace("'", "^");

           


            string str0501 = cb00501.Text;
            str0501 = str0501.Replace("'", "^");


            string str0601 = cb00601.Text;
            str0601 = str0601.Replace("'", "^");
                        
            

            string str0701 = cb00701.Text;
            str0701 = str0701.Replace("'", "^");

            string str0702 = tb00702.Text;
            str0702 = str0702.Replace("'", "^");

            string str0703 = cb00703.Text;
            str0703 = str0703.Replace("'", "^");

            string str0704 = tb00704.Text;
            str0704 = str0704.Replace("'", "^");

            string str0705 = cb00705.Text;
            str0705 = str0705.Replace("'", "^");

            string str0706 = tb00706.Text;
            str0706 = str0706.Replace("'", "^");

            string str0707 = cb00707.Text;
            str0707 = str0707.Replace("'", "^");

            string str0708 = tb00708.Text;
            str0708 = str0708.Replace("'", "^");

            string str0709 = cb00709.Text;
            str0709 = str0709.Replace("'", "^");

            string str0710 = tb00710.Text;
            str0710 = str0710.Replace("'", "^");

            string str0711 = cb00711.Text;
            str0711 = str0711.Replace("'", "^");

            string str0712 = tb00712.Text;
            str0712 = str0712.Replace("'", "^");

            string str0713 = cb00713.Text;
            str0713 = str0713.Replace("'", "^");

            string str0714 = tb00714.Text;
            str0714 = str0714.Replace("'", "^");

            string str0715 = cb00715.Text;
            str0715 = str0715.Replace("'", "^");

            string str0716 = tb00716.Text;
            str0716 = str0716.Replace("'", "^");
            
            string str0801 = cb00801.Text;
            str0801 = str0801.Replace("'", "^");
            
            string str0901 = tb00901.Text;
            str0901 = str0901.Replace("'", "^");

            string ectb = tbECTX.Text;
            ectb = ectb.Replace("'", "^");

            string note = tbNOTE.Text;
            note = note.Replace("'", "^");

            string strATX1 = tbATX1.Text;
            strATX1.Replace("'", "^");
            string strATX2 = tbATX2.Text;
            strATX2.Replace("'", "^");
            string strblock001 = tbblock01.Text;
            strblock001.Replace("'", "^");
            string strblock002 = tbblock03.Text;
            strblock002.Replace("'", "^");

            string sql = "INSERT INTO pisOVC001 ( SYDT, UPDT, UPID, PTNO, OGTP, DITP, TRYN, TIT1, TIT2, TIT3, n0101,n0201,n0301,n0302,n0303,n0304,n0305,n0306,n0401, n0402, n0403, n0404, n0501, n0601, n0701, n0702,  n0703, n0704, n0705, n0706, n0707, n0708, n0709, n0710, n0711, n0712, n0713, n0714, n0715, n0716,n0801,n0901, ECTX, NOTE,ATX1,ATX2) VALUES ( '[SYDT]', '[UPDT]', '[UPID]', '[PTNO]', '[OGTP]', '[DITP]', '[TRYN]','[TIT1]', '[TIT2]','[TIT3]', '[n0101]', '[n0201]', '[n0301]','[n0302]','[n0303]','[n0304]','[n0305]','[n0306]', '[n0401]', '[n0402]', '[n0403]', '[n0404]',  '[n0501]','[n0601]', '[n0701]', '[n0702]','[n0703]', '[n0704]','[n0705]', '[n0706]','[n0707]', '[n0708]','[n0709]', '[n0710]','[n0711]', '[n0712]','[n0713]', '[n0714]','[n0715]', '[n0716]','[n0801]', '[n0901]', '[ECTX]','[NOTE]','[ATX1]','[ATX2]')";
            sql = sql.Replace("[SYDT]", DateTime.Now.ToString("yyyyMMdd"));
            sql = sql.Replace("[UPDT]", DateTime.Now.ToString("yyyyMMdd"));
            sql = sql.Replace("[UPID]", "");
            sql = sql.Replace("[PTNO]", PTNO);
            sql = sql.Replace("[OGTP]", HMTP);
            sql = sql.Replace("[DITP]", "");
            sql = sql.Replace("[TRYN]", "N");

            sql = sql.Replace("[TIT1]", Titlestr0001);
            sql = sql.Replace("[TIT2]", Titlestr0002);
            sql = sql.Replace("[TIT3]", Titlestr0003);
            
            sql = sql.Replace("[n0101]", str0101);

            sql = sql.Replace("[n0201]", str0201);
            

            sql = sql.Replace("[n0301]", str0301);
            sql = sql.Replace("[n0302]", str0302);
            sql = sql.Replace("[n0303]", str0303);
            sql = sql.Replace("[n0304]", str0304);
            sql = sql.Replace("[n0305]", str0305);
            sql = sql.Replace("[n0306]", str0306);

            sql = sql.Replace("[n0401]", str0401);
            sql = sql.Replace("[n0402]", str0402);
            sql = sql.Replace("[n0403]", str0403);
            sql = sql.Replace("[n0404]", str0404);
           

            sql = sql.Replace("[n0501]", str0501);

            sql = sql.Replace("[n0601]", str0601);
            

            sql = sql.Replace("[n0701]", str0701);
            sql = sql.Replace("[n0702]", str0702);
            sql = sql.Replace("[n0703]", str0703);
            sql = sql.Replace("[n0704]", str0704);
            sql = sql.Replace("[n0705]", str0705);
            sql = sql.Replace("[n0706]", str0706);
            sql = sql.Replace("[n0707]", str0707);
            sql = sql.Replace("[n0708]", str0708);
            sql = sql.Replace("[n0709]", str0709);
            sql = sql.Replace("[n0710]", str0710);
            sql = sql.Replace("[n0711]", str0711);
            sql = sql.Replace("[n0712]", str0712);
            sql = sql.Replace("[n0713]", str0713);
            sql = sql.Replace("[n0714]", str0714);
            sql = sql.Replace("[n0715]", str0715);
            sql = sql.Replace("[n0716]", str0716);



            sql = sql.Replace("[n0801]", str0801);
            

            sql = sql.Replace("[n0901]", str0901);
           
            sql = sql.Replace("[ECTX]", ectb);
            sql = sql.Replace("[NOTE]", note);
            sql = sql.Replace("[ATX1]", strATX1);
            sql = sql.Replace("[ATX2]", strATX2);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            cmd.ExecuteNonQuery();

            addupdateDB();
            MainDBUpdate();
            DevExpress.XtraEditors.XtraMessageBox.Show("저장되었습니다");
        }

        private void MainDBUpdate()
        {

            string sql = "Update PISDIG001 set  DITX = '[DITX]', ABLK = '[ABLK]',NBLK = '[NBLK]',OGTP = '[OGTP]' where PTNO = '[PTNO]'";
            //string DITX = lbt00001.Text + Environment.NewLine + lbt00002.Text + cbt00001.Text + cbt00002.Text + cbt00003.Text + Environment.NewLine + " " + tbt00004.Text + Environment.NewLine + Environment.NewLine + "  " + lb00101.Text + Environment.NewLine + "    " + cb00101.Text + Environment.NewLine + Environment.NewLine + "  " + lb00201.Text + Environment.NewLine + "    " + cb00201.Text + Environment.NewLine + Environment.NewLine + "  " + lb00301.Text + Environment.NewLine + "    " + cb00301.Text + Environment.NewLine + Environment.NewLine + "  " + lb00401.Text + tb00401.Text + lb00402.Text + tb00402.Text + lb00403.Text + tb00403.Text + lb00404.Text + Environment.NewLine + Environment.NewLine + "  " + lb00501.Text + Environment.NewLine + "    " + cb00501.Text + Environment.NewLine + Environment.NewLine + "  " + lb00601.Text + Environment.NewLine + "    " + cb00601.Text + Environment.NewLine + Environment.NewLine + "  " + lb00701.Text + Environment.NewLine + "    " + cb00701.Text + Environment.NewLine + "    " + tb00702.Text + Environment.NewLine + Environment.NewLine + "  " + lb00801.Text + Environment.NewLine + "    " + lb00802.Text + Environment.NewLine + "     " + cb00801.Text + Environment.NewLine + "      " + lb00803.Text + tb00802.Text + lb00804.Text + Environment.NewLine + "    " + lb00805.Text + Environment.NewLine + "     " + cb00803.Text + Environment.NewLine + "    " + lb00806.Text + Environment.NewLine + "     " + cb00804.Text + Environment.NewLine + "      " + lb00807.Text + tb00805.Text + lb00808.Text + Environment.NewLine + "    " + lb00809.Text + Environment.NewLine + "     " + cb00806.Text + Environment.NewLine + Environment.NewLine + "  " + lb00901.Text + Environment.NewLine + "    " + cb00901.Text + Environment.NewLine + Environment.NewLine + "  " + lb01001.Text + cb01001.Text + Environment.NewLine + Environment.NewLine + "  " + lb01101.Text + cb01101.Text + Environment.NewLine + Environment.NewLine + "  " + lb01201.Text + cb01201.Text + Environment.NewLine + Environment.NewLine + "  " + lb01301.Text + Environment.NewLine + "     " + tb01301.Text + Environment.NewLine + Environment.NewLine + "  " + lb01401.Text + lb01402.Text + tb01401.Text + lb01403.Text + tb01402.Text + lb01404.Text + tb01403.Text + Environment.NewLine + Environment.NewLine + "  " + ectb001.Text + Environment.NewLine + Environment.NewLine + "  " + ntlb001.Text + Environment.NewLine + "  " + nttb001.Text;

            string str00001 = Environment.NewLine + " "  + cbt00001.Text;
            str00001 = str00001.Replace("'", "^");
            string str00002 = "  " + cbt00002.Text;
            str00002 = str00002.Replace("'", "^");
            string str00003 = Environment.NewLine + " " + tbt00003.Text;
            if (cbt00001.Text == " ")
            {
                str00001 = "";
            }
            if (cbt00002.Text == " ")
            {
                str00002 = "";
            }
            if (tbt00003.Text == "")
            {
                str00003 = "";
            }

            string str000 = str00001 + str00002 + str00003;
            str000 = str000.Replace("'", "^");


            string str001 = Environment.NewLine + " " + lb00101.Text + cb00101.Text;

            if (cb00101.Text == " ")
            {
                str001 = "";
            }
            str001 = str001.Replace("'", "^");

            string str002 = Environment.NewLine + " " + lb00201.Text + cb00201.Text;

            if (cb00201.Text == " ")
            {
                str002 = "";
            }
            str002 = str002.Replace("'", "^");
           
            string str00301 = tb00301.Text + lb00303.Text;
            string str00302 = tb00302.Text + lb00304.Text;
            string str00303 = tb00303.Text;
            
            if (tb00301.Text == "")
            {
                str00301 = "";
            }
            if (tb00302.Text == "")
            {
                str00302 = "";
            }
            if (tb00303.Text == "")
            {
                str00302 = tb00302.Text;
                str00303 = "";
            }
            if (tb00302.Text == "" && tb00303.Text == "")
            {
                str00301 = tb00301.Text;
            }
            string str00304 = tb00304.Text + lb00307.Text;
            string str00305 = tb00305.Text + lb00308.Text;
            string str00306 = tb00306.Text;
            if (tb00304.Text == "")
            {
                str00304 = "";
            }
            if (tb00305.Text == "")
            {
                str00305 = "";
            }
            if (tb00306.Text == "")
            {
                str00305 = tb00305.Text;
                str00306 = "";
            }
            if (tb00305.Text == "" && tb00306.Text == "")
            {
                str00304 = tb00404.Text;
            }

            string str003 = Environment.NewLine + " " + lb00301.Text + " " + Environment.NewLine  + "      " + lb00302.Text + str00301 + str00302 + str00303 + lb00305.Text + Environment.NewLine + "      " + lb00306.Text + str00304 + str00305 + str00306 + lb00309.Text;
            str003 = str003.Replace("'", "^");
            if (tb00301.Text == "" && tb00302.Text == "" && tb00303.Text == "")
            {
                str003 =  Environment.NewLine + " " + lb00301.Text + " " + lb00306.Text + str00304 + str00305 + str00306 + lb00309.Text;
            }

            if (tb00304.Text == "" && tb00305.Text == "" && tb00306.Text == "")
            {
                str003 =  Environment.NewLine + " " + lb00301.Text + " " + lb00302.Text + str00301 + str00302 + str00303 + lb00305.Text;
            }

            if (tb00301.Text == "" && tb00302.Text == "" && tb00303.Text == "" && tb00304.Text == "" && tb00305.Text == "" && tb00306.Text == "")
            {
                str003 = "";
            }

            string str00401 = " " + tb00401.Text;
            if (tb00401.Text == "")
            {
                str00401 = "";
            }
            string str00402 = Environment.NewLine + "      " + lb00402.Text + " " +cb00402.Text;
            if (cb00402.Text == " ")
            {
                str00402 = "";
            }
            string str00403 = Environment.NewLine + "      " + lb00403.Text + " " + cb00403.Text;
            if (cb00403.Text == " ")
            {
                str00403 = "";
            }
            string str00404 = Environment.NewLine + "      " + lb00404.Text + " " + tb00404.Text + lb00405.Text;
            if (tb00404.Text == "")
            {
                str00404 = "";
            }


            string str004 = Environment.NewLine + " " + lb00401.Text + str00401 + str00402 + str00403 + str00404;
            str004 = str004.Replace("'", "^");
            if (tb00401.Text == "" && cb00402.Text == " " && cb00403.Text == " " && tb00404.Text == "")
            {
                str004 = "";
            }

            string str005 = Environment.NewLine + " " + lb00501.Text + cb00501.Text;
            str005 = str005.Replace("'", "^");

            if (cb00501.Text == " ")
            {
                str005 = "";
            }

            string str006 =  Environment.NewLine + " " + lb00601.Text + cb00601.Text;
            str006 = str006.Replace("'", "^");

            if (cb00601.Text == " ")
            {
                str006 = "";
            }

            string str00701 = Environment.NewLine + "      " + lb00702.Text + cb00701.Text;
            string str00702 = " " + tb00702.Text;
            if (cb00701.Text == " ")
            {
                str00701 = "";
                str00702 = Environment.NewLine + "      " + lb00702.Text + tb00702.Text;
            }
            if (tb00702.Text == "")
            {
                str00702 = "";
            }

            string str00703 = Environment.NewLine + "      " + lb00703.Text + cb00703.Text;
            string str00704 = " " + tb00704.Text;
            if (cb00703.Text == " ")
            {
                str00703 = "";
                str00704 = Environment.NewLine + "      " + lb00703.Text + tb00704.Text;
            }
            if (tb00704.Text == "")
            {
                str00704 = "";
            }

            string str00705 = Environment.NewLine + "      " + lb00704.Text + cb00705.Text;
            string str00706 = " " + tb00706.Text;
            if (cb00705.Text == " ")
            {
                str00705 = "";
                str00706 = Environment.NewLine + "      " + lb00704.Text + tb00706.Text;
            }
            if (tb00706.Text == "")
            {
                str00706 = "";
            }

            string str00707 = Environment.NewLine + "      " + lb00705.Text + cb00707.Text;
            string str00708 = " " + tb00708.Text;
            if (cb00707.Text == " ")
            {
                str00707 = "";
                str00708 = Environment.NewLine + "      " + lb00705.Text + tb00708.Text;
            }
            if (tb00708.Text == "")
            {
                str00708 = "";
            }

            string str00709 = Environment.NewLine + "      " + lb00706.Text + cb00709.Text;
            string str00710 = " " + tb00710.Text;
            if (cb00709.Text == " ")
            {
                str00709 = "";
                str00710 = Environment.NewLine + "      " + lb00706.Text + tb00710.Text;
            }
            if (tb00710.Text == "")
            {
                str00710 = "";
            }

            string str00711 = Environment.NewLine + "      " + lb00707.Text + cb00711.Text;
            string str00712 = " " + tb00712.Text;
            if (cb00711.Text == " ")
            {
                str00711 = "";
                str00712 = Environment.NewLine + "      " + lb00707.Text + tb00712.Text;
            }
            if (tb00712.Text == "")
            {
                str00712 = "";
            }

            string str00713 = Environment.NewLine + "      " + lb00708.Text + cb00713.Text;
            string str00714 = " " + tb00714.Text;
            if (cb00713.Text == " ")
            {
                str00713 = "";
                str00714 = Environment.NewLine + "      " + lb00708.Text + tb00714.Text;
            }
            if (tb00714.Text == "")
            {
                str00714 = "";
            }

            string str00715 = Environment.NewLine + "      " + lb00709.Text + cb00715.Text;
            string str00716 = " " + tb00716.Text;
            if (cb00715.Text == " ")
            {
                str00715 = "";
                str00716 = Environment.NewLine + "      " + lb00709.Text + tb00716.Text;
            }
            if (tb00716.Text == "")
            {
                str00716 = "";
            }

            string str007 = Environment.NewLine + " " + lb00701.Text + str00701 + str00702 + str00703 + str00704 + str00705 + str00706 + str00707 + str00708 + str00709 + str00710 + str00711 + str00712 + str00713 + str00714 + str00715 + str00716;
            str007 = str007.Replace("'", "^");
            if (cb00701.Text == " " && cb00703.Text == " " && cb00705.Text == " " && cb00707.Text == " " && cb00709.Text == " " && cb00711.Text == " " && cb00713.Text == " " && cb00715.Text == " " && tb00702.Text == "" && tb00704.Text == "" && tb00706.Text == "" && tb00708.Text == "" && tb00710.Text == "" && tb00712.Text == "" && tb00714.Text == "" && tb00716.Text == "")
            {
                str007 = "";
            }
            
            string str008 = Environment.NewLine + " " + lb00801.Text + cb00801.Text;
            str008 = str008.Replace("'", "^");
            if (cb00801.Text == " ")
            {
                str008 = "";
            }


           
            string str009 = Environment.NewLine + " " + lb00901.Text + Environment.NewLine + "       " +  tb00901.Text;
            str009 = str009.Replace("'", "^");
            if (tb00901.Text == "" )
            {
                str009 = "";
            }



            string strTBECTX = tbECTX.Text.Replace("\r\n", "\r\n ");
            string strECTX =  Environment.NewLine + " " + strTBECTX;
            strECTX = strECTX.Replace("'", "^");
            string strTBNOTE = "     " + tbNOTE.Text.Replace("\r\n", "\r\n     ");
            string strNOTE =  Environment.NewLine + " " + lbNOTE.Text + Environment.NewLine + strTBNOTE;
            strNOTE = strNOTE.Replace("'", "^");
            string strTBATX1 = " " + tbATX1.Text.Replace("\r\n", "\r\n     ");
            string strATX1 =  Environment.NewLine + tbATX1.Text;
            strATX1 = strATX1.Replace("'", "^");

            string strTBATX2 = " " + tbATX2.Text.Replace("\r\n", "\r\n   ");
            strTBATX2 = strTBATX2.Replace("#. Histochemistry", "#. Histochemistry");
            string strATX2 = Environment.NewLine + strTBATX2;
            strATX2 = strATX2.Replace("'", "^");



            if (tbECTX.Text == "")
            {
                strECTX = "";
            }
            if (tbNOTE.Text == "")
            {
                strNOTE = "";
            }

            if (tbATX1.Text == "")
            {
                strATX1 = "";
            }
            if (tbATX2.Text == "")
            {
                strATX2 = "";
            }


            int n = 0;
            string[] ADD = new string[10];

            for (int i = 0; i < Convert.ToUInt32(dataGridView3.Rows.Count - 1); i++)
            {
                string str1 = dataGridView3.Rows[i].Cells[0].FormattedValue.ToString();
                string str2 = dataGridView3.Rows[i].Cells[1].FormattedValue.ToString();
                string str3 = dataGridView3.Rows[i].Cells[2].FormattedValue.ToString();
                str1 = str1.Replace("'", "^");
                str2 = str2.Replace("'", "^");
                str3 = str3.Replace("'", "^");
                n = i + 1;

                if (str1 != "" && str2 != "" && str3 != "")
                {

                    ADD[n] = Environment.NewLine + "  " + str1 + " : " + str2 + " , " + str3;
                }
                else if (str1 == "" && str2 == "" && str3 == "")
                {
                    ADD[n] = "";
                }
                else if (str1 != "" && str2 == "" && str3 == "")
                {
                    ADD[n] = Environment.NewLine + "  " + str1;
                }
                else if (str1 != "" && str2 != "" && str3 == "")
                {
                    ADD[n] = Environment.NewLine + "  " + str1 + " : " + str2;
                }

                totalAdd =  ADD[1] + ADD[2] +  ADD[3] +  ADD[4] +  ADD[5] + ADD[6] +  ADD[7] + ADD[8];
                totalAdd = totalAdd.Replace("'", "^");
            }
            string DITX = lbt00001.Text + str000 + str001 + str002 + str003 + str004 + str005 + str006 + str007 + str008 + str009 + strECTX + strNOTE + strATX1 +  totalAdd + strATX2;
            string NBLK = tbblock03.Text;
            NBLK = NBLK.Replace("'", "^");
            string ABLK = tbblock01.Text;
            ABLK = ABLK.Replace("'", "^");
            sql = sql.Replace("[PTNO]", PTNO);
            sql = sql.Replace("[OGTP]", HMTP);
            sql = sql.Replace("[DITX]", DITX);
            sql = sql.Replace("[ABLK]", ABLK);
            sql = sql.Replace("[NBLK]", NBLK);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            cmd.ExecuteNonQuery();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void tb00301_KeyPress(object sender, KeyPressEventArgs e)
        {
            int nPreLen = 3;
            int nPostLen = 1;

            if (e.KeyChar == '\b')
                return;

            //sender 로부터 텍스트 박스 구함
            TextBox editor = sender as TextBox;

            //소숫점의 점(dot)이 포함되어 있는지 여부.
            //단, 현재 selection 상태인 텍스트에 점이 포함되어 있으면 비포함으로 간주
            bool bDotContains = editor.Text.Contains(".") && !editor.SelectedText.Contains(".");

            //전체 길이 체크를 위한 변수(selection 길이는 뺀다)
            int nTextLen = editor.Text.Length - editor.SelectedText.Length;
            //현재 커서 위치
            int nCursor = editor.SelectionStart;

            //점과 숫자 이외의 값은 받아들이지 않음.
            if (e.KeyChar != '.' && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            //소숫점 이하 값이 없는 경우 - 2010.12.29 추가
            else if (e.KeyChar == '.' && nPostLen < 1)
                e.Handled = true;
            //점이 포함되어 있을 경우
            else if (bDotContains)
            {
                //전체 길이 체크 정수부와 소수부의 길이 더하기 점의 길이보다 같거나 크면 받아들이지 않음.
                //또한, 이미 점이 포함되어 있으므로, 점이 들어오면 받아들이지 않음.
                if (nTextLen >= nPreLen + nPostLen + 1 || e.KeyChar == '.')
                    e.Handled = true;
                else
                {
                    //점의 위치를 구한다.
                    int nDotPos = editor.Text.IndexOf('.');
                    //텍스트를 정수부와 소수부로 나눈다.
                    string[] sSep = editor.Text.Split('.');

                    //현재 커서가 점 앞에 있고, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    if (nDotPos > nCursor && sSep[0].Length >= nPreLen)
                        e.Handled = true;
                    //현재 커서가 점 뒤에 있고, 소수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    else if (nDotPos < nCursor && sSep[1].Length >= nPostLen)
                        e.Handled = true;
                }
            }
            //들어온 값이 점이 아니고, 현재 텍스트가 점을 포함하지 않으면
            //현재 값은 정수인데, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
            else if (e.KeyChar != '.' && !bDotContains && nTextLen >= nPreLen)
                e.Handled = true;
        }

        private void tb00302_KeyPress(object sender, KeyPressEventArgs e)
        {
            int nPreLen = 3;
            int nPostLen = 1;

            if (e.KeyChar == '\b')
                return;

            //sender 로부터 텍스트 박스 구함
            TextBox editor = sender as TextBox;

            //소숫점의 점(dot)이 포함되어 있는지 여부.
            //단, 현재 selection 상태인 텍스트에 점이 포함되어 있으면 비포함으로 간주
            bool bDotContains = editor.Text.Contains(".") && !editor.SelectedText.Contains(".");

            //전체 길이 체크를 위한 변수(selection 길이는 뺀다)
            int nTextLen = editor.Text.Length - editor.SelectedText.Length;
            //현재 커서 위치
            int nCursor = editor.SelectionStart;

            //점과 숫자 이외의 값은 받아들이지 않음.
            if (e.KeyChar != '.' && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            //소숫점 이하 값이 없는 경우 - 2010.12.29 추가
            else if (e.KeyChar == '.' && nPostLen < 1)
                e.Handled = true;
            //점이 포함되어 있을 경우
            else if (bDotContains)
            {
                //전체 길이 체크 정수부와 소수부의 길이 더하기 점의 길이보다 같거나 크면 받아들이지 않음.
                //또한, 이미 점이 포함되어 있으므로, 점이 들어오면 받아들이지 않음.
                if (nTextLen >= nPreLen + nPostLen + 1 || e.KeyChar == '.')
                    e.Handled = true;
                else
                {
                    //점의 위치를 구한다.
                    int nDotPos = editor.Text.IndexOf('.');
                    //텍스트를 정수부와 소수부로 나눈다.
                    string[] sSep = editor.Text.Split('.');

                    //현재 커서가 점 앞에 있고, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    if (nDotPos > nCursor && sSep[0].Length >= nPreLen)
                        e.Handled = true;
                    //현재 커서가 점 뒤에 있고, 소수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    else if (nDotPos < nCursor && sSep[1].Length >= nPostLen)
                        e.Handled = true;
                }
            }
            //들어온 값이 점이 아니고, 현재 텍스트가 점을 포함하지 않으면
            //현재 값은 정수인데, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
            else if (e.KeyChar != '.' && !bDotContains && nTextLen >= nPreLen)
                e.Handled = true;
        }

        private void tb00303_KeyPress(object sender, KeyPressEventArgs e)
        {
            int nPreLen = 3;
            int nPostLen = 1;

            if (e.KeyChar == '\b')
                return;

            //sender 로부터 텍스트 박스 구함
            TextBox editor = sender as TextBox;

            //소숫점의 점(dot)이 포함되어 있는지 여부.
            //단, 현재 selection 상태인 텍스트에 점이 포함되어 있으면 비포함으로 간주
            bool bDotContains = editor.Text.Contains(".") && !editor.SelectedText.Contains(".");

            //전체 길이 체크를 위한 변수(selection 길이는 뺀다)
            int nTextLen = editor.Text.Length - editor.SelectedText.Length;
            //현재 커서 위치
            int nCursor = editor.SelectionStart;

            //점과 숫자 이외의 값은 받아들이지 않음.
            if (e.KeyChar != '.' && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            //소숫점 이하 값이 없는 경우 - 2010.12.29 추가
            else if (e.KeyChar == '.' && nPostLen < 1)
                e.Handled = true;
            //점이 포함되어 있을 경우
            else if (bDotContains)
            {
                //전체 길이 체크 정수부와 소수부의 길이 더하기 점의 길이보다 같거나 크면 받아들이지 않음.
                //또한, 이미 점이 포함되어 있으므로, 점이 들어오면 받아들이지 않음.
                if (nTextLen >= nPreLen + nPostLen + 1 || e.KeyChar == '.')
                    e.Handled = true;
                else
                {
                    //점의 위치를 구한다.
                    int nDotPos = editor.Text.IndexOf('.');
                    //텍스트를 정수부와 소수부로 나눈다.
                    string[] sSep = editor.Text.Split('.');

                    //현재 커서가 점 앞에 있고, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    if (nDotPos > nCursor && sSep[0].Length >= nPreLen)
                        e.Handled = true;
                    //현재 커서가 점 뒤에 있고, 소수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    else if (nDotPos < nCursor && sSep[1].Length >= nPostLen)
                        e.Handled = true;
                }
            }
            //들어온 값이 점이 아니고, 현재 텍스트가 점을 포함하지 않으면
            //현재 값은 정수인데, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
            else if (e.KeyChar != '.' && !bDotContains && nTextLen >= nPreLen)
                e.Handled = true;
        }

        private void tb00304_KeyPress(object sender, KeyPressEventArgs e)
        {
            int nPreLen = 3;
            int nPostLen = 1;

            if (e.KeyChar == '\b')
                return;

            //sender 로부터 텍스트 박스 구함
            TextBox editor = sender as TextBox;

            //소숫점의 점(dot)이 포함되어 있는지 여부.
            //단, 현재 selection 상태인 텍스트에 점이 포함되어 있으면 비포함으로 간주
            bool bDotContains = editor.Text.Contains(".") && !editor.SelectedText.Contains(".");

            //전체 길이 체크를 위한 변수(selection 길이는 뺀다)
            int nTextLen = editor.Text.Length - editor.SelectedText.Length;
            //현재 커서 위치
            int nCursor = editor.SelectionStart;

            //점과 숫자 이외의 값은 받아들이지 않음.
            if (e.KeyChar != '.' && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            //소숫점 이하 값이 없는 경우 - 2010.12.29 추가
            else if (e.KeyChar == '.' && nPostLen < 1)
                e.Handled = true;
            //점이 포함되어 있을 경우
            else if (bDotContains)
            {
                //전체 길이 체크 정수부와 소수부의 길이 더하기 점의 길이보다 같거나 크면 받아들이지 않음.
                //또한, 이미 점이 포함되어 있으므로, 점이 들어오면 받아들이지 않음.
                if (nTextLen >= nPreLen + nPostLen + 1 || e.KeyChar == '.')
                    e.Handled = true;
                else
                {
                    //점의 위치를 구한다.
                    int nDotPos = editor.Text.IndexOf('.');
                    //텍스트를 정수부와 소수부로 나눈다.
                    string[] sSep = editor.Text.Split('.');

                    //현재 커서가 점 앞에 있고, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    if (nDotPos > nCursor && sSep[0].Length >= nPreLen)
                        e.Handled = true;
                    //현재 커서가 점 뒤에 있고, 소수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    else if (nDotPos < nCursor && sSep[1].Length >= nPostLen)
                        e.Handled = true;
                }
            }
            //들어온 값이 점이 아니고, 현재 텍스트가 점을 포함하지 않으면
            //현재 값은 정수인데, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
            else if (e.KeyChar != '.' && !bDotContains && nTextLen >= nPreLen)
                e.Handled = true;
        }

        private void tb00305_KeyPress(object sender, KeyPressEventArgs e)
        {
            int nPreLen = 3;
            int nPostLen = 1;

            if (e.KeyChar == '\b')
                return;

            //sender 로부터 텍스트 박스 구함
            TextBox editor = sender as TextBox;

            //소숫점의 점(dot)이 포함되어 있는지 여부.
            //단, 현재 selection 상태인 텍스트에 점이 포함되어 있으면 비포함으로 간주
            bool bDotContains = editor.Text.Contains(".") && !editor.SelectedText.Contains(".");

            //전체 길이 체크를 위한 변수(selection 길이는 뺀다)
            int nTextLen = editor.Text.Length - editor.SelectedText.Length;
            //현재 커서 위치
            int nCursor = editor.SelectionStart;

            //점과 숫자 이외의 값은 받아들이지 않음.
            if (e.KeyChar != '.' && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            //소숫점 이하 값이 없는 경우 - 2010.12.29 추가
            else if (e.KeyChar == '.' && nPostLen < 1)
                e.Handled = true;
            //점이 포함되어 있을 경우
            else if (bDotContains)
            {
                //전체 길이 체크 정수부와 소수부의 길이 더하기 점의 길이보다 같거나 크면 받아들이지 않음.
                //또한, 이미 점이 포함되어 있으므로, 점이 들어오면 받아들이지 않음.
                if (nTextLen >= nPreLen + nPostLen + 1 || e.KeyChar == '.')
                    e.Handled = true;
                else
                {
                    //점의 위치를 구한다.
                    int nDotPos = editor.Text.IndexOf('.');
                    //텍스트를 정수부와 소수부로 나눈다.
                    string[] sSep = editor.Text.Split('.');

                    //현재 커서가 점 앞에 있고, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    if (nDotPos > nCursor && sSep[0].Length >= nPreLen)
                        e.Handled = true;
                    //현재 커서가 점 뒤에 있고, 소수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    else if (nDotPos < nCursor && sSep[1].Length >= nPostLen)
                        e.Handled = true;
                }
            }
            //들어온 값이 점이 아니고, 현재 텍스트가 점을 포함하지 않으면
            //현재 값은 정수인데, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
            else if (e.KeyChar != '.' && !bDotContains && nTextLen >= nPreLen)
                e.Handled = true;
        }

        private void tb00306_KeyPress(object sender, KeyPressEventArgs e)
        {
            int nPreLen = 3;
            int nPostLen = 1;

            if (e.KeyChar == '\b')
                return;

            //sender 로부터 텍스트 박스 구함
            TextBox editor = sender as TextBox;

            //소숫점의 점(dot)이 포함되어 있는지 여부.
            //단, 현재 selection 상태인 텍스트에 점이 포함되어 있으면 비포함으로 간주
            bool bDotContains = editor.Text.Contains(".") && !editor.SelectedText.Contains(".");

            //전체 길이 체크를 위한 변수(selection 길이는 뺀다)
            int nTextLen = editor.Text.Length - editor.SelectedText.Length;
            //현재 커서 위치
            int nCursor = editor.SelectionStart;

            //점과 숫자 이외의 값은 받아들이지 않음.
            if (e.KeyChar != '.' && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            //소숫점 이하 값이 없는 경우 - 2010.12.29 추가
            else if (e.KeyChar == '.' && nPostLen < 1)
                e.Handled = true;
            //점이 포함되어 있을 경우
            else if (bDotContains)
            {
                //전체 길이 체크 정수부와 소수부의 길이 더하기 점의 길이보다 같거나 크면 받아들이지 않음.
                //또한, 이미 점이 포함되어 있으므로, 점이 들어오면 받아들이지 않음.
                if (nTextLen >= nPreLen + nPostLen + 1 || e.KeyChar == '.')
                    e.Handled = true;
                else
                {
                    //점의 위치를 구한다.
                    int nDotPos = editor.Text.IndexOf('.');
                    //텍스트를 정수부와 소수부로 나눈다.
                    string[] sSep = editor.Text.Split('.');

                    //현재 커서가 점 앞에 있고, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    if (nDotPos > nCursor && sSep[0].Length >= nPreLen)
                        e.Handled = true;
                    //현재 커서가 점 뒤에 있고, 소수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    else if (nDotPos < nCursor && sSep[1].Length >= nPostLen)
                        e.Handled = true;
                }
            }
            //들어온 값이 점이 아니고, 현재 텍스트가 점을 포함하지 않으면
            //현재 값은 정수인데, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
            else if (e.KeyChar != '.' && !bDotContains && nTextLen >= nPreLen)
                e.Handled = true;
        }

        private void tb00404_KeyPress(object sender, KeyPressEventArgs e)
        {
            int nPreLen = 3;
            int nPostLen = 1;

            if (e.KeyChar == '\b')
                return;

            //sender 로부터 텍스트 박스 구함
            TextBox editor = sender as TextBox;

            //소숫점의 점(dot)이 포함되어 있는지 여부.
            //단, 현재 selection 상태인 텍스트에 점이 포함되어 있으면 비포함으로 간주
            bool bDotContains = editor.Text.Contains(".") && !editor.SelectedText.Contains(".");

            //전체 길이 체크를 위한 변수(selection 길이는 뺀다)
            int nTextLen = editor.Text.Length - editor.SelectedText.Length;
            //현재 커서 위치
            int nCursor = editor.SelectionStart;

            //점과 숫자 이외의 값은 받아들이지 않음.
            if (e.KeyChar != '.' && !char.IsDigit(e.KeyChar))
                e.Handled = true;
            //소숫점 이하 값이 없는 경우 - 2010.12.29 추가
            else if (e.KeyChar == '.' && nPostLen < 1)
                e.Handled = true;
            //점이 포함되어 있을 경우
            else if (bDotContains)
            {
                //전체 길이 체크 정수부와 소수부의 길이 더하기 점의 길이보다 같거나 크면 받아들이지 않음.
                //또한, 이미 점이 포함되어 있으므로, 점이 들어오면 받아들이지 않음.
                if (nTextLen >= nPreLen + nPostLen + 1 || e.KeyChar == '.')
                    e.Handled = true;
                else
                {
                    //점의 위치를 구한다.
                    int nDotPos = editor.Text.IndexOf('.');
                    //텍스트를 정수부와 소수부로 나눈다.
                    string[] sSep = editor.Text.Split('.');

                    //현재 커서가 점 앞에 있고, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    if (nDotPos > nCursor && sSep[0].Length >= nPreLen)
                        e.Handled = true;
                    //현재 커서가 점 뒤에 있고, 소수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
                    else if (nDotPos < nCursor && sSep[1].Length >= nPostLen)
                        e.Handled = true;
                }
            }
            //들어온 값이 점이 아니고, 현재 텍스트가 점을 포함하지 않으면
            //현재 값은 정수인데, 정수부의 길이가 지정된 길이보다 길어지면 받아들이지 않음.
            else if (e.KeyChar != '.' && !bDotContains && nTextLen >= nPreLen)
                e.Handled = true;
        }

        private void button10_Click(object sender, EventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("정보를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sql = "delete from pisOVC001 where ptno = '[PTNO]'";
                    sql = sql.Replace("[PTNO]", PTNO);
                    MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                    cmd.ExecuteNonQuery();
                    DevExpress.XtraEditors.XtraMessageBox.Show("삭제되었습니다");
                    reset();
                    DeleteMain();
                }
                else
                {
                    return;
                }
            }
            catch (System.Exception ex)
            {
            }
        }

        private void DeleteMain()
        {
            string sql = "Update PISDIG001 set  DITX = '', ABLK = '',NBLK = '',OGTP ='',GRTX ='' where PTNO = '[PTNO]'";
            sql = sql.Replace("[PTNO]", PTNO);
            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            cmd.ExecuteNonQuery();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            string[] strData = null;
            dataGridView3.Rows.Clear();
           
            string strCode = "";
            if (MainForm.EMROpen())
            {
                strCode = MainForm.EMRPIASearch(PTNO);
                if (strCode != "")
                {
                    strData = MainForm.GetPIACode(strCode);
                }
            }

            if (strData != null)
            {
                for (int i = 0; i < strData.Length; i++)
                {
                    if (strData[i] != null)
                        dataGridView3.Rows.Add(strData[i], "", "");
                }
                tbATX1.Text = "#. Immunohistochemistry";
                tbATX2.Text = "#. Histochemistry\r\nVanGieson elastic fiber\r\nMucicarmine\r\nMasson Trichrome";
            }
        }

        private void dataGridView3_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Stage dlg = new Stage();
            dlg.Show();
        }

    }
}
