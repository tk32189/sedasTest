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
    public partial class Rectal_cancer : DevExpress.XtraEditors.XtraForm
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public static MySqlConnection Myconn;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        public string HMTP = "rtc";
        public string PTNO;
        public string block1;
        public string block2;
        public string totalAdd;

        public Rectal_cancer()
        {
            InitializeComponent();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void comboBox15_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (comboBox15.SelectedItem.ToString() == "Distance of invasvie carcinoma or metastatic lymph node from closet margin")
            {
                //textBox4.Visible = true;
            }
            else
            {
                //textBox4.Visible = false;
            }*/
        }

        private void panel31_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel34_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

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

        private void comboBox14_SelectedIndexChanged(object sender, EventArgs e)
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

        private void Rectal_cancer_Load(object sender, EventArgs e)
        {
            try
            {
                CoreLibrary core = new CoreLibrary();
                core.InitGridStyle(dataGridView3);

                cbt00001.Items.Add(" ");

                cb00101.Items.Add(" ");
                cb00201.Items.Add(" ");
                cb00301.Items.Add(" ");
                cb00401.Items.Add(" ");
                cb00501.Items.Add(" ");
                cb00701.Items.Add(" ");
                cb00801.Items.Add(" ");
                cb00901.Items.Add(" ");
                cb01101.Items.Add(" ");
                cb01102.Items.Add(" ");
                cb01103.Items.Add(" ");
                cb01104.Items.Add(" ");
                cb01105.Items.Add(" ");
                cb01106.Items.Add(" ");

                cb01301.Items.Add(" ");

                cb01401.Items.Add(" ");
                cb01402.Items.Add(" ");
                cb01501.Items.Add(" ");
                cb01502.Items.Add(" ");
                cb01601.Items.Add(" ");
                cb01602.Items.Add(" ");

                cb01701.Items.Add(" ");
                cb01704.Items.Add(" ");

                cb01801.Items.Add(" ");
                cb01802.Items.Add(" ");
                cb01806.Items.Add(" ");
                cb02001.Items.Add(" ");
               

                string strSQL = Ini.strDB;

                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();

                Insertcombo00001();
                

                Insertcombo00101();
                Insertcombo00201();
                Insertcombo00301();

                Insertcombo00401();

                Insertcombo00501();
                
                Insertcombo00701();
                
                Insertcombo00801();

                Insertcombo00901();

                Insertcombo01101();
                Insertcombo01102();
                Insertcombo01103();
                Insertcombo01104();
                Insertcombo01105();
                Insertcombo01106();

                Insertcombo01301();

                Insertcombo01401();
                Insertcombo01402();

                Insertcombo01501();
                Insertcombo01502();

                Insertcombo01601();
                Insertcombo01602();

                Insertcombo01701();
                Insertcombo01704();

                Insertcombo01801();
                Insertcombo01802();
                Insertcombo01806();

                Insertcombo02001();

                cb01101.Text = "p";
                cb01103.Text = "p";
                cb01105.Text = "p";
                String sql = "select TIT1, TIT2, TIT3, n0101, n0201, n0301,n0401, n0501, n0601, n0602, n0603, n0701, n0801, n0901,n0902,n0903, n1001,n1002,n1003,n1101,n1102,n1103,n1104,n1105,n1106,n1201,n1301,n1302,n1401,n1402,n1403,n1501,n1502,n1503,n1601,n1602,n1603,n1701,n1702,n1703,n1704,n1705,n1801,n1802,n1803,n1804,n1805,n1806,n1901,n1902,n1903,n2001,ECTX,NOTE,ATX1,ATX2 from PISRTC001 where PTNO ='[PTNO]'";

                sql = sql.Replace("[PTNO]", PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();



                while (dr.Read())
                {

                    cbt00001.SelectedIndex = selectData00001(dr[0].ToString());
                    tbt00002.Text = dr[1].ToString().Replace("^", "'");
                    tbt00003.Text = dr[2].ToString().Replace("^", "'");
                    
                    cb00101.SelectedIndex = selectData00101(dr[3].ToString());

                    cb00201.SelectedIndex = selectData00201(dr[4].ToString());

                    cb00301.SelectedIndex = selectData00301(dr[5].ToString());

                    cb00401.SelectedIndex = selectData00401(dr[6].ToString());

                    cb00501.SelectedIndex = selectData00501(dr[7].ToString());

                    tb00601.Text = dr[8].ToString().Replace("^", "'");
                    tb00602.Text = dr[9].ToString().Replace("^", "'");
                    tb00603.Text = dr[10].ToString().Replace("^", "'");
                    

                    cb00701.SelectedIndex = selectData00701(dr[11].ToString());
                    

                    cb00801.SelectedIndex = selectData00801(dr[12].ToString());

                    cb00901.SelectedIndex = selectData00901(dr[13].ToString());
                    tb00902.Text = dr[14].ToString().Replace("^", "'");
                    tb00903.Text = dr[15].ToString().Replace("^", "'");

                    tb01001.Text = dr[16].ToString().Replace("^", "'");
                    tb01002.Text = dr[17].ToString().Replace("^", "'");
                    tb01003.Text = dr[18].ToString().Replace("^", "'");

                    cb01101.SelectedIndex = selectData01101(dr[19].ToString());
                    cb01102.SelectedIndex = selectData01102(dr[20].ToString());
                    cb01103.SelectedIndex = selectData01103(dr[21].ToString());
                    cb01104.SelectedIndex = selectData01104(dr[22].ToString());
                    cb01105.SelectedIndex = selectData01105(dr[23].ToString());
                    cb01106.SelectedIndex = selectData01106(dr[24].ToString());

                    tb01201.Text = dr[25].ToString().Replace("^", "'");
                    
                    cb01301.SelectedIndex = selectData01301(dr[26].ToString());
                    tb01302.Text = dr[27].ToString().Replace("^", "'");

                    cb01401.SelectedIndex = selectData01401(dr[28].ToString());
                    cb01402.SelectedIndex = selectData01402(dr[29].ToString());
                    tb01403.Text = dr[30].ToString().Replace("^", "'");

                    cb01501.SelectedIndex = selectData01501(dr[31].ToString());
                    cb01502.SelectedIndex = selectData01502(dr[32].ToString());
                    tb01503.Text = dr[33].ToString().Replace("^", "'");

                    cb01601.SelectedIndex = selectData01601(dr[34].ToString());
                    cb01602.SelectedIndex = selectData01602(dr[35].ToString());
                    tb01603.Text = dr[36].ToString().Replace("^", "'");

                    cb01701.SelectedIndex = selectData01701(dr[37].ToString());
                    tb01702.Text = dr[38].ToString().Replace("^", "'");
                    tb01703.Text = dr[39].ToString().Replace("^", "'");
                    cb01704.SelectedIndex = selectData01704(dr[40].ToString());
                    tb01705.Text = dr[41].ToString().Replace("^", "'");
                    //161005

                    cb01801.SelectedIndex = selectData01801(dr[42].ToString());
                    cb01802.SelectedIndex = selectData01802(dr[43].ToString());
                    tb01803.Text = dr[44].ToString().Replace("^", "'");
                    tb01804.Text = dr[45].ToString().Replace("^", "'");
                    tb01805.Text = dr[46].ToString().Replace("^", "'");
                    cb01806.SelectedIndex = selectData01806(dr[47].ToString());

                    tb01901.Text = dr[48].ToString().Replace("^", "'");
                    tb01902.Text = dr[49].ToString().Replace("^", "'");
                    tb01903.Text = dr[50].ToString().Replace("^", "'");

                    cb02001.SelectedIndex = selectData02001(dr[51].ToString());


                    tbECTX.Text = dr[52].ToString().Replace("^", "'");
                    tbNOTE.Text = dr[53].ToString().Replace("^", "'");
                    tbATX1.Text = dr[54].ToString().Replace("^", "'");
                    tbATX2.Text = dr[55].ToString().Replace("^", "'");
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

            string sql = "select ABLK, NBLK from PISDIG001 where PTNO ='[PTNO]' and OGTP ='RTC'";
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

            string sql = "select A101,A102,A103,A201,A202,A203,A301,A302,A303,A401,A402,A403,A501,A502,A503,A601,A602,A603,A701,A702,A703,A801,A802,A803,A901,A902,A903 from PISRTC001 where PTNO ='[PTNO]'";
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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '00001'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '00101'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '00201'";

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

        private int selectData00301(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '00301'";

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

        private int selectData00401(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '00401'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '00501'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '00701'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '00801'";

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

        private int selectData00901(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '00901'";

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

        private int selectData01101(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01101'";

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


        private int selectData01102(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01102'";

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


        private int selectData01103(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01103'";

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


        private int selectData01104(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01104'";

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


        private int selectData01105(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01105'";

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


        private int selectData01106(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01106'";

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


        private int selectData01301(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01301'";

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


        private int selectData01401(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01401'";

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


        private int selectData01402(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01402'";

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

        private int selectData01501(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01501'";

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


        private int selectData01502(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01502'";

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

        private int selectData01601(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01601'";

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


        private int selectData01602(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01602'";

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

        private int selectData01701(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01701'";

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

        private int selectData01704(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01702'";

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

        private int selectData01806(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01803'";

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

        private int selectData01801(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01801'";

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

        private int selectData01802(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '01802'";

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

        private int selectData02001(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'RTC'and  SQNO = '02001'";

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

        private void Insertcombo00301()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00301";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00301.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00401()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00401";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00401.Items.Add(dr.GetString(0));
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

        private void Insertcombo00901()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00901";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00901.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01101()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01101";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01101.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01102()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01102";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01102.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01103()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01103";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01103.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01104()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01104";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01104.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01105()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01105";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01105.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01106()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01106";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01106.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01301()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01301";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01301.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01401()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01401";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01401.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01402()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01402";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01402.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01501()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01501";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01501.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01502()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01502";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01502.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01601()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01601";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01601.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01602()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01602";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01602.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01701()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01701";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01701.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01704()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01702";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01704.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01801()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01801";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01801.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01802()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01802";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01802.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01806()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01803";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01806.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo02001()
        {
            String sql = Ini.DBSelect;
            string SQNO = "02001";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb02001.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = "select * from PISRTC001 where PTNO = '[PTNO]'";
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
                selectRTC();
                Selectblock();
                drc.Close();
                conn.Close();
            }
            catch (System.Exception ex)
            {
            }
        }

        private void selectRTC()
        {

            String sql = "select TIT1, TIT2, TIT3, n0101, n0201, n0301,n0401, n0501, n0601, n0602, n0603, n0701, n0801, n0901,n0902,n0903, n1001,n1002,n1003,n1101,n1102,n1103,n1104,n1105,n1106,n1201,n1301,n1302,n1401,n1402,n1403,n1501,n1502,n1503,n1601,n1602,n1603,n1701,n1702,n1703,n1704,n1705,n1801,n1802,n1803,n1804,n1805,n1806,n1901,n1902,n1903,n2001,ECTX,NOTE,ATX1,ATX2 from PISRTC001 where PTNO ='[PTNO]'";

            sql = sql.Replace("[PTNO]", PTNO);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read())
            {

                cbt00001.SelectedIndex = selectData00001(dr[0].ToString());
                tbt00002.Text = dr[1].ToString().Replace("^", "'");
                tbt00003.Text = dr[2].ToString().Replace("^", "'");

                cb00101.SelectedIndex = selectData00101(dr[3].ToString());

                cb00201.SelectedIndex = selectData00201(dr[4].ToString());

                cb00301.SelectedIndex = selectData00301(dr[5].ToString());

                cb00401.SelectedIndex = selectData00401(dr[6].ToString());

                cb00501.SelectedIndex = selectData00501(dr[7].ToString());

                tb00601.Text = dr[8].ToString().Replace("^", "'");
                tb00602.Text = dr[9].ToString().Replace("^", "'");
                tb00603.Text = dr[10].ToString().Replace("^", "'");


                cb00701.SelectedIndex = selectData00701(dr[11].ToString());


                cb00801.SelectedIndex = selectData00801(dr[12].ToString());

                cb00901.SelectedIndex = selectData00901(dr[13].ToString());
                tb00902.Text = dr[14].ToString().Replace("^", "'");
                tb00903.Text = dr[15].ToString().Replace("^", "'");

                tb01001.Text = dr[16].ToString().Replace("^", "'");
                tb01002.Text = dr[17].ToString().Replace("^", "'");
                tb01003.Text = dr[18].ToString().Replace("^", "'");

                cb01101.SelectedIndex = selectData01101(dr[19].ToString());
                cb01102.SelectedIndex = selectData01102(dr[20].ToString());
                cb01103.SelectedIndex = selectData01103(dr[21].ToString());
                cb01104.SelectedIndex = selectData01104(dr[22].ToString());
                cb01105.SelectedIndex = selectData01105(dr[23].ToString());
                cb01106.SelectedIndex = selectData01106(dr[24].ToString());

                tb01201.Text = dr[25].ToString().Replace("^", "'");

                cb01301.SelectedIndex = selectData01301(dr[26].ToString());
                tb01302.Text = dr[27].ToString().Replace("^", "'");

                cb01401.SelectedIndex = selectData01401(dr[28].ToString());
                cb01402.SelectedIndex = selectData01402(dr[29].ToString());
                tb01403.Text = dr[30].ToString().Replace("^", "'");

                cb01501.SelectedIndex = selectData01501(dr[31].ToString());
                cb01502.SelectedIndex = selectData01502(dr[32].ToString());
                tb01503.Text = dr[33].ToString().Replace("^", "'");

                cb01601.SelectedIndex = selectData01601(dr[34].ToString());
                cb01602.SelectedIndex = selectData01602(dr[35].ToString());
                tb01603.Text = dr[36].ToString().Replace("^", "'");

                cb01701.SelectedIndex = selectData01701(dr[37].ToString());
                tb01702.Text = dr[38].ToString().Replace("^", "'");
                tb01703.Text = dr[39].ToString().Replace("^", "'");
                cb01704.SelectedIndex = selectData01704(dr[40].ToString());
                tb01705.Text = dr[41].ToString().Replace("^", "'");
                //161005

                cb01801.SelectedIndex = selectData01801(dr[42].ToString());
                cb01802.SelectedIndex = selectData01802(dr[43].ToString());
                tb01803.Text = dr[44].ToString().Replace("^", "'");
                tb01804.Text = dr[45].ToString().Replace("^", "'");
                tb01805.Text = dr[46].ToString().Replace("^", "'");
                cb01806.SelectedIndex = selectData01806(dr[47].ToString());

                tb01901.Text = dr[48].ToString().Replace("^", "'");
                tb01902.Text = dr[49].ToString().Replace("^", "'");
                tb01903.Text = dr[50].ToString().Replace("^", "'");

                cb02001.SelectedIndex = selectData02001(dr[51].ToString());


                tbECTX.Text = dr[52].ToString().Replace("^", "'");
                tbNOTE.Text = dr[53].ToString().Replace("^", "'");
                tbATX1.Text = dr[54].ToString().Replace("^", "'");
                tbATX2.Text = dr[55].ToString().Replace("^", "'");
                selectAdd();
            }
            dr.Close();
        }

        private void UpdateDB()
        {

            string Titlestr0001 = cbt00001.Text;
            Titlestr0001 = Titlestr0001.Replace("'", "^");

            string Titlestr0002 = tbt00002.Text;
            Titlestr0002 = Titlestr0002.Replace("'", "^");

            string Titlestr0003 = tbt00003.Text;
            Titlestr0003 = Titlestr0003.Replace("'", "^");


            string str0101 = cb00101.Text;
            str0101 = str0101.Replace("'", "^");

            string str0201 = cb00201.Text;
            str0201 = str0201.Replace("'", "^");

            string str0301 = cb00301.Text;
            str0301 = str0301.Replace("'", "^");




            string str0401 = cb00401.Text;
            str0401 = str0401.Replace("'", "^");


            string str0501 = cb00501.Text;
            str0501 = str0501.Replace("'", "^");


            string str0601 = tb00601.Text;
            str0601 = str0601.Replace("'", "^");

            string str0602 = tb00602.Text;
            str0602 = str0602.Replace("'", "^");

            string str0603 = tb00603.Text;
            str0603 = str0603.Replace("'", "^");



            string str0701 = cb00701.Text;
            str0701 = str0701.Replace("'", "^");



            string str0801 = cb00801.Text;
            str0801 = str0801.Replace("'", "^");

            string str0901 = cb00901.Text;
            str0901 = str0901.Replace("'", "^");

            string str0902 = tb00902.Text;
            str0902 = str0902.Replace("'", "^");

            string str0903 = tb00903.Text;
            str0903 = str0903.Replace("'", "^");

            string str1001 = tb01001.Text;
            str1001 = str1001.Replace("'", "^");

            string str1002 = tb01002.Text;
            str1002 = str1002.Replace("'", "^");

            string str1003 = tb01003.Text;
            str1003 = str1003.Replace("'", "^");

            string str1101 = cb01101.Text;
            str1101 = str1101.Replace("'", "^");

            string str1102 = cb01102.Text;
            str1102 = str1102.Replace("'", "^");

            string str1103 = cb01103.Text;
            str1103 = str1103.Replace("'", "^");

            string str1104 = cb01104.Text;
            str1104 = str1104.Replace("'", "^");

            string str1105 = cb01105.Text;
            str1105 = str1105.Replace("'", "^");

            string str1106 = cb01106.Text;
            str1106 = str1106.Replace("'", "^");

            string str1201 = tb01201.Text;
            str1201 = str1201.Replace("'", "^");

            string str1301 = cb01301.Text;
            str1301 = str1301.Replace("'", "^");

            string str1302 = tb01302.Text;
            str1302 = str1302.Replace("'", "^");

            string str1401 = cb01401.Text;
            str1401 = str1401.Replace("'", "^");

            string str1402 = cb01402.Text;
            str1402 = str1402.Replace("'", "^");

            string str1403 = tb01403.Text;
            str1403 = str1403.Replace("'", "^");

            string str1501 = cb01501.Text;
            str1501 = str1501.Replace("'", "^");

            string str1502 = cb01502.Text;
            str1502 = str1502.Replace("'", "^");

            string str1503 = tb01503.Text;
            str1503 = str1503.Replace("'", "^");

            string str1601 = cb01601.Text;
            str1601 = str1601.Replace("'", "^");

            string str1602 = cb01602.Text;
            str1602 = str1602.Replace("'", "^");

            string str1603 = tb01603.Text;
            str1603 = str1603.Replace("'", "^");

            string str1701 = cb01701.Text;
            str1701 = str1701.Replace("'", "^");

            string str1702 = tb01702.Text;
            str1702 = str1702.Replace("'", "^");

            string str1703 = tb01703.Text;
            str1703 = str1703.Replace("'", "^");

            string str1704 = cb01704.Text;
            str1704 = str1704.Replace("'", "^");

            string str1705 = tb01705.Text;
            str1705 = str1705.Replace("'", "^");

            string str1801 = cb01801.Text;
            str1801 = str1801.Replace("'", "^");

            string str1802 = cb01802.Text;
            str1802 = str1802.Replace("'", "^");

            string str1803 = tb01803.Text;
            str1803 = str1803.Replace("'", "^");

            string str1804 = tb01804.Text;
            str1804 = str1804.Replace("'", "^");

            string str1805 = tb01805.Text;
            str1805 = str1805.Replace("'", "^");

            string str1806 = cb01806.Text;
            str1806 = str1806.Replace("'", "^");

            string str1901 = tb01901.Text;
            str1901 = str1901.Replace("'", "^");

            string str1902 = tb01902.Text;
            str1902 = str1902.Replace("'", "^");

            string str1903 = tb01903.Text;
            str1903 = str1903.Replace("'", "^");

            string str2001 = cb02001.Text;
            str2001 = str2001.Replace("'", "^");




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

            string sql = "Update pisRTC001 SET SYDT = '[SYDT]', UPDT = '[UPDT]', UPID = '[UPID]', OGTP = '[OGTP]', DITP='[DITP]', TRYN ='[TRYN]', TIT1 = '[TIT1]',TIT2= '[TIT2]',TIT3= '[TIT3]', n0101 = '[n0101]', n0201 = '[n0201]', n0301='[n0301]', n0401 = '[n0401]', n0501 = '[n0501]',  n0601='[n0601]', n0602='[n0602]',n0602='[n0602]',n0603='[n0603]',n0701='[n0701]', n0801='[n0801]', n0901='[n0901]',n0902='[n0902]',n0903='[n0903]',n1001='[n1001]',n1002='[n1002]',n1003='[n1003]',n1101='[n1101]',n1102='[n1102]',n1103='[n1103]',n1104='[n1104]',n1105='[n1105]',n1106='[n1106]',n1201='[n1201]',n1301='[n1301]',n1302='[n1302]',n1401='[n1401]',n1402='[n1402]',n1403='[n1403]',n1501='[n1501]',n1502='[n1502]',n1503='[n1503]',n1601='[n1601]',n1602='[n1602]',n1603='[n1603]',n1701='[n1701]',n1702='[n1702]',n1703='[n1703]',n1704='[n1704]',n1705='[n1705]',n1801='[n1801]',n1802='[n1802]',n1803='[n1803]',n1804='[n1804]',n1805='[n1805]',n1806='[n1806]',n1901='[n1901]',n1902='[n1902]',n1903='[n1903]',n2001='[n2001]',ECTX='[ECTX]', NOTE='[NOTE]' , ATX1='[ATX1]',ATX2 ='[ATX2]' where PTNO ='[PTNO]'";
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


            sql = sql.Replace("[n0401]", str0401);



            sql = sql.Replace("[n0501]", str0501);

            sql = sql.Replace("[n0601]", str0601);
            sql = sql.Replace("[n0602]", str0602);
            sql = sql.Replace("[n0603]", str0603);


            sql = sql.Replace("[n0701]", str0701);

            sql = sql.Replace("[n0801]", str0801);


            sql = sql.Replace("[n0901]", str0901);
            sql = sql.Replace("[n0902]", str0902);
            sql = sql.Replace("[n0903]", str0903);

            sql = sql.Replace("[n1001]", str1001);
            sql = sql.Replace("[n1002]", str1002);
            sql = sql.Replace("[n1003]", str1003);

            sql = sql.Replace("[n1101]", str1101);
            sql = sql.Replace("[n1102]", str1102);
            sql = sql.Replace("[n1103]", str1103);
            sql = sql.Replace("[n1104]", str1104);
            sql = sql.Replace("[n1105]", str1105);
            sql = sql.Replace("[n1106]", str1106);

            sql = sql.Replace("[n1201]", str1201);

            sql = sql.Replace("[n1301]", str1301);
            sql = sql.Replace("[n1302]", str1302);

            sql = sql.Replace("[n1401]", str1401);
            sql = sql.Replace("[n1402]", str1402);
            sql = sql.Replace("[n1403]", str1403);

            sql = sql.Replace("[n1501]", str1501);
            sql = sql.Replace("[n1502]", str1502);
            sql = sql.Replace("[n1503]", str1503);

            sql = sql.Replace("[n1601]", str1601);
            sql = sql.Replace("[n1602]", str1602);
            sql = sql.Replace("[n1603]", str1603);

            sql = sql.Replace("[n1701]", str1701);
            sql = sql.Replace("[n1702]", str1702);
            sql = sql.Replace("[n1703]", str1703);
            sql = sql.Replace("[n1704]", str1704);
            sql = sql.Replace("[n1705]", str1705);

            sql = sql.Replace("[n1801]", str1801);
            sql = sql.Replace("[n1802]", str1802);
            sql = sql.Replace("[n1803]", str1803);
            sql = sql.Replace("[n1804]", str1804);
            sql = sql.Replace("[n1805]", str1805);
            sql = sql.Replace("[n1806]", str1806);


            sql = sql.Replace("[n1901]", str1901);
            sql = sql.Replace("[n1902]", str1902);
            sql = sql.Replace("[n1903]", str1903);

            sql = sql.Replace("[n2001]", str2001);

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

                string sql = String.Format("Update PISRTC001 set {0}='{1}', {2} = '{3}',{4}='{5}' where PTNO = '{6}'", ADD1, str1, ADD2, str2, ADD3, str3, PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }


        }

        private void InsertDB()
        {
            string Titlestr0001 = cbt00001.Text;
            Titlestr0001 = Titlestr0001.Replace("'", "^");

            string Titlestr0002 = tbt00002.Text;
            Titlestr0002 = Titlestr0002.Replace("'", "^");

            string Titlestr0003 = tbt00003.Text;
            Titlestr0003 = Titlestr0003.Replace("'", "^");


            string str0101 = cb00101.Text;
            str0101 = str0101.Replace("'", "^");

            string str0201 = cb00201.Text;
            str0201 = str0201.Replace("'", "^");

            string str0301 = cb00301.Text;
            str0301 = str0301.Replace("'", "^");
           



            string str0401 = cb00401.Text;
            str0401 = str0401.Replace("'", "^");


            string str0501 = cb00501.Text;
            str0501 = str0501.Replace("'", "^");


            string str0601 = tb00601.Text;
            str0601 = str0601.Replace("'", "^");

            string str0602 = tb00602.Text;
            str0602 = str0602.Replace("'", "^");

            string str0603 = tb00603.Text;
            str0603 = str0603.Replace("'", "^");



            string str0701 = cb00701.Text;
            str0701 = str0701.Replace("'", "^");

           

            string str0801 = cb00801.Text;
            str0801 = str0801.Replace("'", "^");

            string str0901 = cb00901.Text;
            str0901 = str0901.Replace("'", "^");

            string str0902 = tb00902.Text;
            str0902 = str0902.Replace("'", "^");

            string str0903 = tb00903.Text;
            str0903 = str0903.Replace("'", "^");

            string str1001 = tb01001.Text;
            str1001 = str1001.Replace("'", "^");

            string str1002 = tb01002.Text;
            str1002 = str1002.Replace("'", "^");

            string str1003 = tb01003.Text;
            str1003 = str1003.Replace("'", "^");

            string str1101 = cb01101.Text;
            str1101 = str1101.Replace("'", "^");

            string str1102 = cb01102.Text;
            str1102 = str1102.Replace("'", "^");

            string str1103 = cb01103.Text;
            str1103 = str1103.Replace("'", "^");

            string str1104 = cb01104.Text;
            str1104 = str1104.Replace("'", "^");

            string str1105 = cb01105.Text;
            str1105 = str1105.Replace("'", "^");

            string str1106 = cb01106.Text;
            str1106 = str1106.Replace("'", "^");

            string str1201 = tb01201.Text;
            str1201 = str1201.Replace("'", "^");

            string str1301 = cb01301.Text;
            str1301 = str1301.Replace("'", "^");

            string str1302 = tb01302.Text;
            str1302 = str1302.Replace("'", "^");

            string str1401 = cb01401.Text;
            str1401 = str1401.Replace("'", "^");

            string str1402 = cb01402.Text;
            str1402 = str1402.Replace("'", "^");

            string str1403 = tb01403.Text;
            str1403 = str1403.Replace("'", "^");

            string str1501 = cb01501.Text;
            str1501 = str1501.Replace("'", "^");

            string str1502 = cb01502.Text;
            str1502 = str1502.Replace("'", "^");

            string str1503 = tb01503.Text;
            str1503 = str1503.Replace("'", "^");

            string str1601 = cb01601.Text;
            str1601 = str1601.Replace("'", "^");

            string str1602 = cb01602.Text;
            str1602 = str1602.Replace("'", "^");

            string str1603 = tb01603.Text;
            str1603 = str1603.Replace("'", "^");

            string str1701 = cb01701.Text;
            str1701 = str1701.Replace("'", "^");

            string str1702 = tb01702.Text;
            str1702 = str1702.Replace("'", "^");

            string str1703 = tb01703.Text;
            str1703 = str1703.Replace("'", "^");

            string str1704 = cb01704.Text;
            str1704 = str1704.Replace("'", "^");

            string str1705 = tb01705.Text;
            str1705 = str1705.Replace("'", "^");

            string str1801 = cb01801.Text;
            str1801 = str1801.Replace("'", "^");

            string str1802 = cb01802.Text;
            str1802 = str1802.Replace("'", "^");

            string str1803 = tb01803.Text;
            str1803 = str1803.Replace("'", "^");

            string str1804 = tb01804.Text;
            str1804 = str1804.Replace("'", "^");

            string str1805 = tb01805.Text;
            str1805 = str1805.Replace("'", "^");

            string str1806 = cb01806.Text;
            str1806 = str1806.Replace("'", "^");

            string str1901 = tb01901.Text;
            str1901 = str1901.Replace("'", "^");

            string str1902 = tb01902.Text;
            str1902 = str1902.Replace("'", "^");

            string str1903 = tb01903.Text;
            str1903 = str1903.Replace("'", "^");

            string str2001 = cb02001.Text;
            str2001 = str2001.Replace("'", "^");

            
            

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

            string sql = "INSERT INTO pisRTC001 ( SYDT, UPDT, UPID, PTNO, OGTP, DITP, TRYN, TIT1, TIT2, TIT3, n0101,n0201,n0301,n0401, n0501, n0601, n0602,n0603,n0701,n0801,n0901,n0902,n0903,n1001,n1002,n1003,n1101,n1102,n1103,n1104,n1105,n1106,n1201, n1301,n1302,n1401,n1402,n1403,n1501,n1502,n1503,n1601,n1602,n1603,n1701,n1702,n1703,n1704,n1705,n1801,n1802,n1803,n1804,n1805,n1806,n1901,n1902,n1903,n2001,ECTX, NOTE,ATX1,ATX2) VALUES ( '[SYDT]', '[UPDT]', '[UPID]', '[PTNO]', '[OGTP]', '[DITP]', '[TRYN]','[TIT1]', '[TIT2]','[TIT3]', '[n0101]', '[n0201]', '[n0301]','[n0401]', '[n0501]', '[n0601]', '[n0602]','[n0603]','[n0701]','[n0801]','[n0901]','[n0902]','[n0903]','[n1001]','[n1002]','[n1003]','[n1101]','[n1102]','[n1103]','[n1104]','[n1105]','[n1106]','[n1201]','[n1301]','[n1302]','[n1401]','[n1402]','[n1403]','[n1501]','[n1502]','[n1503]','[n1601]','[n1602]','[n1603]','[n1701]','[n1702]','[n1703]','[n1704]','[n1705]','[n1801]','[n1802]','[n1803]','[n1804]','[n1805]','[n1806]','[n1901]','[n1902]','[n1903]','[n2001]', '[ECTX]','[NOTE]','[ATX1]','[ATX2]')";
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
            

            sql = sql.Replace("[n0401]", str0401);
            


            sql = sql.Replace("[n0501]", str0501);

            sql = sql.Replace("[n0601]", str0601);
            sql = sql.Replace("[n0602]", str0602);
            sql = sql.Replace("[n0603]", str0603);


            sql = sql.Replace("[n0701]", str0701);
            
            sql = sql.Replace("[n0801]", str0801);


            sql = sql.Replace("[n0901]", str0901);
            sql = sql.Replace("[n0902]", str0902);
            sql = sql.Replace("[n0903]", str0903);

            sql = sql.Replace("[n1001]", str1001);
            sql = sql.Replace("[n1002]", str1002);
            sql = sql.Replace("[n1003]", str1003);

            sql = sql.Replace("[n1101]", str1101);
            sql = sql.Replace("[n1102]", str1102);
            sql = sql.Replace("[n1103]", str1103);
            sql = sql.Replace("[n1104]", str1104);
            sql = sql.Replace("[n1105]", str1105);
            sql = sql.Replace("[n1106]", str1106);

            sql = sql.Replace("[n1201]", str1201);

            sql = sql.Replace("[n1301]", str1301);
            sql = sql.Replace("[n1302]", str1302);

            sql = sql.Replace("[n1401]", str1401);
            sql = sql.Replace("[n1402]", str1402);
            sql = sql.Replace("[n1403]", str1403);

            sql = sql.Replace("[n1501]", str1501);
            sql = sql.Replace("[n1502]", str1502);
            sql = sql.Replace("[n1503]", str1503);

            sql = sql.Replace("[n1601]", str1601);
            sql = sql.Replace("[n1602]", str1602);
            sql = sql.Replace("[n1603]", str1603);

            sql = sql.Replace("[n1701]", str1701);
            sql = sql.Replace("[n1702]", str1702);
            sql = sql.Replace("[n1703]", str1703);
            sql = sql.Replace("[n1704]", str1704);
            sql = sql.Replace("[n1705]", str1705);

            sql = sql.Replace("[n1801]", str1801);
            sql = sql.Replace("[n1802]", str1802);
            sql = sql.Replace("[n1803]", str1803);
            sql = sql.Replace("[n1804]", str1804);
            sql = sql.Replace("[n1805]", str1805);
            sql = sql.Replace("[n1806]", str1806);
            

            sql = sql.Replace("[n1901]", str1901);
            sql = sql.Replace("[n1902]", str1902);
            sql = sql.Replace("[n1903]", str1903);

            sql = sql.Replace("[n2001]", str2001);

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

            string str00001 = cbt00001.Text;
            str00001 = str00001.Replace("'", "^");
            string str00002 = "  " + tbt00002.Text;
            str00002 = str00002.Replace("'", "^");
            string str00003 = Environment.NewLine + " " + tbt00003.Text;
            if (cbt00001.Text == " ")
            {
                str00001 = "";
            }
            if (tbt00002.Text == "")
            {
                str00002 = "";
            }
            
            if (tbt00003.Text == "")
            {
                str00003 = "";
            }

            string str000 = " " + lbt00002.Text + str00001 + str00002 + str00003;
            str000 = str000.Replace("'", "^");
            if (cbt00001.Text == " " && tbt00002.Text == "")
            {
                str000 = " " + lbt00002.Text + str00003;
            }


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

            string str003 =  Environment.NewLine + " " + lb00301.Text + cb00301.Text;

            if (cb00301.Text == " ")
            {
                str003 = "";
            }
            str003 = str003.Replace("'", "^");


            string str004 = Environment.NewLine + " " + lb00401.Text + cb00401.Text;

            if (cb00401.Text == " ")
            {
                str004 = "";
            }
            str004 = str004.Replace("'", "^");

            string str005 = Environment.NewLine + " " + lb00501.Text + cb00501.Text;

            if (cb00501.Text == " ")
            {
                str005 = "";
            }
            str005 = str005.Replace("'", "^");

            string str00601 = tb00601.Text + lb00602.Text;
            string str00602 = tb00602.Text + lb00603.Text;
            string str00603 = tb00603.Text;
            if (tb00601.Text == "")
            {
                str00601 = "";
            }
            if (tb00602.Text == "")
            {
                str00602 = "";
            }
            if (tb00603.Text == "")
            {
                str00602 = tb00602.Text;
                str00603 = "";
            }
            if (tb00602.Text == "" && tb00603.Text == "")
            {
                str00601 = tb00601.Text;
            }

            string str006 = Environment.NewLine + " " + lb00601.Text + str00601 + str00602 + str00603 + lb00604.Text;
            if (tb00602.Text == "" && tb00601.Text == "" && tb00603.Text == "")
            {
                str006 = "";
            }


            string str007 = Environment.NewLine + " " + lb00701.Text + cb00701.Text;

            if (cb00701.Text == " ")
            {
                str007 = "";
            }
            str007 = str007.Replace("'", "^");


            string str008 = Environment.NewLine + " " + lb00801.Text + cb00801.Text;

            if (cb00801.Text == " ")
            {
                str008 = "";
            }
            str008 = str008.Replace("'", "^");

            string str00901 = Environment.NewLine + "      " + cb00901.Text;
            if (cb00901.Text == " ")
            {
                str00901 = "";
            }
            string str00902 = Environment.NewLine + "        " + lb00902.Text + " " + tb00902.Text + " " + lb00903.Text;

            if (tb00902.Text == "")
            {
                str00902 = "";
            }

            string str00903 = Environment.NewLine + "        " + lb00904.Text +" " + tb00903.Text +" " + lb00905.Text;
            if (tb00903.Text == "")
            {
                str00903 = "";
            }
            
            string str009 = Environment.NewLine + " " + lb00901.Text + str00901 + str00902 + str00903;
            str009 = str009.Replace("'", "^");
            if (cb00901.Text == " " && tb00902.Text == "" && tb00903.Text =="")
            {
                str009 = "";
            }

            string str01001 = Environment.NewLine + "        " + lb01002.Text + tb01001.Text + lb01003.Text;
            string str01002 = Environment.NewLine + "        " + lb01004.Text + tb01002.Text + lb01005.Text + tb01003.Text + lb01006.Text;
            if (tb01001.Text == "")
            {
                str01001 = "";
            }
            if (tb01002.Text == "" && tb01003.Text == "")
            {
                str01002 = "";
            }
            string str010 =  Environment.NewLine + " " + lb01001.Text + str01001 + str01002;
            if (tb01001.Text == "" && tb01002.Text == "" && tb01003.Text == "")
            {
                str010 = "";
            }
            str010 = str010.Replace("'", "^");

            string str01101 = cb01101.Text + lb01102.Text + cb01102.Text;
            if (cb01101.Text == " " && cb01102.Text == " ")
            {
                str01101 = "";
            }
            string str01102 = " " + cb01103.Text + lb01103.Text + cb01104.Text;
            if (cb01103.Text == " " && cb01104.Text == " ")
            {
                str01102 = "";
            }
            string str01103 = " " + cb01105.Text + lb01104.Text + cb01106.Text;
            if (cb01105.Text == " " && cb01106.Text == " ")
            {
                str01103 = "";
            }
            string str011 =  Environment.NewLine +" " + lb01101.Text +  str01101 + str01102 + str01103;

            str011 = str011.Replace("'", "^");
            if (cb01101.Text == " " && cb01102.Text == " " && cb01103.Text == " " && cb01104.Text == " " && cb01105.Text == " " && cb01106.Text == " ")
            {
                str011 = "";
            }

            string str012 =  Environment.NewLine + " " + lb01201.Text + tb01201.Text;
            str012 = str012.Replace("'", "^");
            if (tb01201.Text == "")
            {
                str012 = "";
            }

            string str01301 = cb01301.Text;
            
            string str01302 = " " + tb01302.Text + lb01302.Text;
            if (tb01302.Text == "")
            {
                str01302 = "";
            }
            string str013 =  Environment.NewLine + " " + lb01301.Text + str01301 + str01302;
            str013 = str013.Replace("'", "^");
            if (cb01301.Text == " " && tb01302.Text == "")
            {
                str013 = "";
            }

            string str01401 = cb01401.Text;
            string str01402 = " " + cb01402.Text;
            string str01403 = " " + tb01403.Text;
            if (tb01403.Text == "")
            {
                str01403 = "";
            }
            if (cb01402.Text == " ")
            {
                str01402 = "";
            }
            string str014 = Environment.NewLine + " " + lb01401.Text + str01401 + str01402 + str01403;
            str014 = str014.Replace("'", "^");
            if (cb01401.Text == " " && cb01402.Text == " "&&tb01403.Text=="")
            {
                str014 = "";
            }

            string str01501 = cb01501.Text;
            string str01502 = " " + cb01502.Text;
            string str01503 = " " + tb01503.Text;
            if (cb01502.Text == " ")
            {
                str01502 = "";
            }
            if (tb01503.Text == "")
            {
                str01503 = "";
            }
            string str015 = Environment.NewLine + " " + lb01501.Text + str01501 + str01502+ str01503;
            str015 = str015.Replace("'", "^");
            if (cb01501.Text == " " && cb01502.Text == " "&& tb01503.Text=="")
            {
                str015 = "";
            }

            string str01601 = cb01601.Text;
            string str01602 = " " + cb01602.Text;
            string str01603 = " " + tb01603.Text;
            if (cb01602.Text == " ")
            {
                str01602 = "";
            }
            if (tb01603.Text == "")
            {
                str01603 = "";
            }
            string str016 =  Environment.NewLine + " " + lb01601.Text + str01601 + str01602 + str01603;
            str016 = str016.Replace("'", "^");
            if (cb01601.Text == " " && cb01602.Text == " "&&tb01603.Text=="")
            {
                str016 = "";
            }

            string str01701 =  Environment.NewLine + "          " + cb01701.Text;
            if (cb01701.Text == " ")
            {
                str01701 = "";
            }
            string str01702 = Environment.NewLine + "          " + lb01703.Text + tb01702.Text + lb01704.Text + " " + lb01705.Text + tb01703.Text + lb01706.Text;
            if (tb01702.Text == "" && tb01703.Text == "")
            {
                str01702 = "";
            }
            string str01703 = Environment.NewLine + "          " + lb01706.Text + cb01704.Text;
            if (cb01704.Text == " ")
            {
                str01703 = "";
            }

            string str01704 = Environment.NewLine + "          " + lb01708.Text + tb01705.Text + lb01709.Text;
            if (tb01705.Text == "")
            {
                str01704 = "";
            }

            string str017 = Environment.NewLine + " " + lb01701.Text + Environment.NewLine + "      " + lb01702.Text +str01701 + str01702 + Environment.NewLine + "      " + lb01707.Text + str01703 + str01704;
            str017 = str017.Replace("'", "^");
            if (cb01701.Text == " " && tb01702.Text == "" && tb01703.Text == "" && cb01704.Text == " " && tb01705.Text == "")
            {
                str017 = "";
            }

            string str01801 = Environment.NewLine + "      "  +cb01801.Text;
            string str01802 = lb01802.Text + cb01802.Text + lb01803.Text;
            if(cb01801.Text ==" ")
            {
                str01801 ="";
                str01802 = Environment.NewLine + "      " + lb01802.Text + cb01802.Text + lb01803.Text;
            }
            if(cb01802.Text ==" ")
            {
                str01802 ="";
            }
            string str01803 = tb01803.Text + lb01805.Text;
            string str01804 = tb01804.Text + lb01806.Text;
            string str01805 = tb01805.Text;
            if(tb01803.Text =="")
            {
                str01803 ="";
            }
            if(tb01804.Text =="")
            {
                str01804 ="";
            }
            string str01806 = Environment.NewLine +"      " +lb01808.Text + cb01806.Text;
            if (cb01806.Text == " ")
            {
                str01806 = "";
            }
            string str018 = Environment.NewLine + " " + lb01801.Text + str01801 + str01802 + Environment.NewLine + "      " + lb01804.Text + str01803 + str01804 + str01805 + lb01807.Text + str01806;
            str018 = str018.Replace("'", "^");
            if (tb01803.Text == "" && tb01804.Text == "" && tb01805.Text == "")
            {
                str018 =  Environment.NewLine + " " + lb01801.Text + str01801 + str01802 + str01806;
            }
            if (tb01803.Text == "" && tb01804.Text == "" && tb01805.Text == "" && cb01801.Text == " " && cb01802.Text == " ")
            {
                str018 = "";
            }
            string str01901 = Environment.NewLine + "    " + lb01902.Text + tb01901.Text;
            if (tb01901.Text == "")
            {
                str01901 = "";
            }
            string str01902 = Environment.NewLine + "    " + lb01903.Text + tb01902.Text;
            if (tb01902.Text == "")
            {
                str01902 = "";
            }
            string str01903 = Environment.NewLine + "    " + lb01904.Text + tb01903.Text;
            if (tb01903.Text == "")
            {
                str01903 = "";
            }
            string str019 =  Environment.NewLine +" " + lb01901.Text + str01901 + str01902 + str01903;
            if (tb01901.Text == "" && tb01902.Text == "" && tb01903.Text == "")
            {
                str019 = "";
            }

            str019 = str019.Replace("'", "^");
            string str020 =  Environment.NewLine +" " + lb02001.Text + cb02001.Text;
            if (cb02001.Text == " ")
            {
                str020 = "";
            }
            str020 = str020.Replace("'", "^");
           



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
            string strATX2 =  Environment.NewLine + strTBATX2;
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

                totalAdd =  ADD[1] + ADD[2] +  ADD[3] + ADD[4] +  ADD[5] + ADD[6] + ADD[7] +  ADD[8];
                totalAdd = totalAdd.Replace("'", "^");
            }
            string DITX = lbt00001.Text + Environment.NewLine + str000 + str001 + str002 + str003 + str004 + str005 + str006 + str007 + str008 + str009 +str010 + str011 + str012 + str013 + str014 + str015 + str016 + str017 + str018 + str019 + str020 + strECTX + strNOTE + strATX1 +  totalAdd + strATX2;
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select DITX from PISDIG001 where PTNO ='[PTNO]' and OGTP ='RTC'";
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

        private void button10_Click(object sender, EventArgs e)
        {

            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("정보를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sql = "delete from pisRTC001 where ptno = '[PTNO]'";
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

        private void reset()
        {
            //161005
            cbt00001.Text = " ";
            tbt00002.Text = "low anterior resection ";
            tbt00003.Text = "Rectal Cancer";

            cb00101.Text = " ";
            cb00201.Text = " ";
            cb00301.Text = " ";
            cb00401.Text = " ";
            cb00501.Text = " ";

            tb00601.Text = "";
            tb00602.Text = "";
            tb00603.Text = "";
            

            cb00701.Text = " ";
           

            cb00801.Text = " ";

            cb00901.Text = " ";
            tb00902.Text = "";
            tb00903.Text = "";

            tb01001.Text = "";
            tb01002.Text = "";
            tb01003.Text = "";

            cb01101.Text = "p";
            cb01102.Text = " ";
            cb01103.Text = "p";
            cb01104.Text = " ";
            cb01105.Text = "p";
            cb01106.Text = " ";

            tb01201.Text = "";

            cb01301.Text = " ";
            tb01302.Text = "";

            cb01401.Text = " ";
            cb01402.Text = " ";
            tb01403.Text = "";

            cb01501.Text = " ";
            cb01502.Text = " ";
            tb01503.Text = "";

            cb01601.Text = " ";
            cb01602.Text = " ";
            tb01603.Text = "";

            cb01701.Text = " ";
            tb01702.Text = "";
            tb01703.Text = "";
            cb01704.Text = " ";
            tb01705.Text = "";

            cb01801.Text = " ";
            cb01802.Text = " ";
            tb01803.Text = "";
            tb01804.Text = "";
            tb01805.Text = "";
            cb01806.Text = " ";

            tb01901.Text = "";
            tb01902.Text = "";
            tb01903.Text = "Not identified";

            cb02001.Text = " ";

            tbECTX.Text = "";
            tbNOTE.Text = "";

            tbblock01.Text = "";
            tbblock03.Text = "";
            tbATX1.Text = "";
            tbATX2.Text = "";
            dataGridView3.Rows.Clear();
            cbt00001.Select();
        }

        private void tb00601_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00602_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00603_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb01302_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb01702_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb01703_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb01705_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb01803_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb01804_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb01805_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void tb00902_KeyPress(object sender, KeyPressEventArgs e)
        {
            
            int nPreLen = 4;
            int nPostLen = 2;

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

        private void tb00903_KeyPress(object sender, KeyPressEventArgs e)
        {
             
            int nPreLen = 4;
            int nPostLen = 2;

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

        private void lb01802_Click(object sender, EventArgs e)
        {

        }

        private void cb00901_TextChanged(object sender, EventArgs e)
        {
            //tb00902Text.Text = cb00901.Text;
            cb00901Text.Text = cb00901.Text;
            string str00901;
            str00901 = cb00901Text.Text;
            if (str00901.Length >= 80)
            {
                string first;
                string end;
                int i = str00901.Length - 80;
                first = str00901.Substring(0, 80);
                end = str00901.Substring(80, i);
                str00901 = first + Environment.NewLine + end;
                cb00901Text.Text = str00901;
            }
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
        

    }
}
