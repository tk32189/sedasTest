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
    public partial class Colon__left_hemicoloectomy : DevExpress.XtraEditors.XtraForm
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public static MySqlConnection Myconn;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        public string HMTP = "col";
        public string PTNO;
        public string block1;
        public string block2;
        public string totalAdd;
        public string strPTNO = "";
        public Colon__left_hemicoloectomy()
        {
            InitializeComponent();
        }

        private void comboBox29_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label16_Click(object sender, EventArgs e)
        {

        }

        private void panel12_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label38_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void comboBox30_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbt00004.SelectedItem.ToString() == "early")
            {
                lb00401.Text = "4. Size of whole tumor:";
                
                lb00405.Visible = true;
                lb00406.Visible = true;
                tb00404.Visible = true;
            }
            else
            {
                lb00401.Text = "4. Size of Invasive Carcinoma:";
                lb00405.Visible = false;
                lb00406.Visible = false;
                tb00404.Visible = false;
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            string[] strData = null;
            dataGridView1.Rows.Clear();
            
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
                        dataGridView1.Rows.Add(strData[i], "", "");
                }
                tbATX1.Text = "#. Immunohistochemistry";
                tbATX2.Text = "#. Histochemistry\r\nVanGieson elastic fiber\r\nMucicarmine\r\nMasson Trichrome";
            }
        }

        private void Colon__left_hemicoloectomy_Load(object sender, EventArgs e)
        {
            try
            {
                CoreLibrary core = new CoreLibrary();
                core.InitGridStyle(dataGridView1);

                cbt00001.Items.Add(" ");
                cbt00002.Items.Add(" ");
                cbt00004.Items.Add(" ");
                cb00101.Items.Add(" ");
                cb00201.Items.Add(" ");
                cb00301.Items.Add(" ");
                
                cb00501.Items.Add(" ");
                cb00601.Items.Add(" ");
                cb00701.Items.Add(" ");
               
                
                cb00901.Items.Add(" ");
                cb00902.Items.Add(" ");
                cb00903.Items.Add(" ");
                cb00904.Items.Add(" ");
                cb00905.Items.Add(" ");
                cb00906.Items.Add(" ");
                cb00907.Items.Add(" ");
                cb00909.Items.Add(" ");

                cb01101.Items.Add(" ");
                cb01201.Items.Add(" ");
                cb01202.Items.Add(" ");
                cb01301.Items.Add(" ");
                cb01302.Items.Add(" ");
                cb01401.Items.Add(" ");
                cb01402.Items.Add(" ");

                cb01501.Items.Add(" ");
                cb01504.Items.Add(" ");

                cb01601.Items.Add(" ");
                cb01602.Items.Add(" ");
                cb01606.Items.Add(" ");

                cb01801.Items.Add(" ");
                string strSQL = Ini.strDB;

               
                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();

                Insertcombo00001();
                Insertcombo00002();
                Insertcombo00004();
                Insertcombo00101();
                Insertcombo00201();
                Insertcombo00301();
                
                Insertcombo00501();
                Insertcombo00601();
                Insertcombo00701();

                Insertcombo00901();
                Insertcombo00902();
                Insertcombo00903();
                Insertcombo00904();
                Insertcombo00905();
                Insertcombo00906();
                Insertcombo00907();
                Insertcombo00909();

                Insertcombo01101();

                Insertcombo01201();
                Insertcombo01202();
                Insertcombo01301();
                Insertcombo01302();
                Insertcombo01401();
                Insertcombo01402();

                Insertcombo01501();
                Insertcombo01504();

                Insertcombo01601();
                Insertcombo01602();
                Insertcombo01606();

                Insertcombo01801();

                cb00901.Text = "p";
                cb00903.Text = "p";
                cb00905.Text = "p";

                String sql = "select TIT1, TIT2, TIT3, TIT4, n0101, n0201, n0301, n0401, n0402, n0403,n0404, n0501, n0601,n0701, n0702,n0703, n0801, n0802, n0803,n0901,n0902,n0903,n0904,n0905,n0906,n0907,n0908,n0909,n1001,n1101,n1102,n1201,n1202,n1203,n1301,n1302,n1303,n1401,n1402,n1403,n1501,n1502,n1503,n1504,n1505,n1601,n1602,n1603,n1604,n1605,n1606,n1701,n1702,n1703,n1801,n1802,ECTX,NOTE,ATX1,ATX2,n0704 from PISCOL001 where PTNO ='[PTNO]'";

                sql = sql.Replace("[PTNO]", PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();



                while (dr.Read())
                {

                    cbt00001.SelectedIndex = selectData00001(dr[0].ToString());
                    cbt00002.SelectedIndex = selectData00002(dr[1].ToString());
                    tbt00003.Text = dr[2].ToString().Replace("^", "'");
                    cbt00004.SelectedIndex = selectData00004(dr[3].ToString());
                    

                    cb00101.SelectedIndex = selectData00101(dr[4].ToString());
                    cb00201.SelectedIndex = selectData00201(dr[5].ToString());
                    cb00301.SelectedIndex = selectData00301(dr[6].ToString());

                    tb00401.Text = dr[7].ToString().Replace("^", "'");
                    tb00402.Text = dr[8].ToString().Replace("^", "'");
                    tb00403.Text = dr[9].ToString().Replace("^", "'");
                    tb00404.Text = dr[10].ToString().Replace("^", "'");

                    cb00501.SelectedIndex = selectData00501(dr[11].ToString());
                    

                    cb00601.SelectedIndex = selectData00601(dr[12].ToString());

                    cb00701.SelectedIndex = selectData00701(dr[13].ToString());
                    tb00702.Text = dr[14].ToString().Replace("^", "'");
                    tb00703.Text = dr[15].ToString().Replace("^", "'");
                    

                    tb00801.Text = dr[16].ToString().Replace("^", "'");
                    tb00802.Text = dr[17].ToString().Replace("^", "'");
                    tb00803.Text = dr[18].ToString().Replace("^", "'");
                   

                    cb00901.SelectedIndex = selectData00901(dr[19].ToString());
                    cb00902.SelectedIndex = selectData00902(dr[20].ToString());
                    cb00903.SelectedIndex = selectData00903(dr[21].ToString());
                    cb00904.SelectedIndex = selectData00904(dr[22].ToString());
                    cb00905.SelectedIndex = selectData00905(dr[23].ToString());
                    cb00906.SelectedIndex = selectData00906(dr[24].ToString());
                    cb00907.SelectedIndex = selectData00907(dr[25].ToString());
                    tb00908.Text = dr[26].ToString().Replace("^", "'");
                    cb00909.SelectedIndex = selectData00909(dr[27].ToString());

                    tb01001.Text = dr[28].ToString().Replace("^", "'");

                    cb01101.SelectedIndex = selectData01101(dr[29].ToString());
                    tb01102.Text = dr[30].ToString().Replace("^", "'");

                    cb01201.SelectedIndex = selectData01201(dr[31].ToString());
                    cb01202.SelectedIndex = selectData01202(dr[32].ToString());
                    tb01203.Text = dr[33].ToString().Replace("^", "'");

                    cb01301.SelectedIndex = selectData01301(dr[34].ToString());
                    cb01302.SelectedIndex = selectData01302(dr[35].ToString());
                    tb01303.Text = dr[36].ToString().Replace("^", "'");

                    cb01401.SelectedIndex = selectData01401(dr[37].ToString());
                    cb01402.SelectedIndex = selectData01402(dr[38].ToString());
                    tb01403.Text = dr[39].ToString().Replace("^", "'");

                    cb01501.SelectedIndex = selectData01501(dr[40].ToString());
                    tb01502.Text = dr[41].ToString().Replace("^", "'");
                    tb01503.Text = dr[42].ToString().Replace("^", "'");
                    cb01504.SelectedIndex = selectData01504(dr[43].ToString());
                    tb01505.Text = dr[44].ToString().Replace("^", "'");

                    cb01601.SelectedIndex = selectData01601(dr[45].ToString());
                    cb01602.SelectedIndex = selectData01602(dr[46].ToString());
                    tb01603.Text = dr[47].ToString().Replace("^", "'");
                    tb01604.Text = dr[48].ToString().Replace("^", "'");
                    tb01605.Text = dr[49].ToString().Replace("^", "'");
                    cb01606.SelectedIndex = selectData01606(dr[50].ToString());

                    tb01701.Text = dr[51].ToString().Replace("^", "'");
                    tb01702.Text = dr[52].ToString().Replace("^", "'");
                    tb01703.Text = dr[53].ToString().Replace("^", "'");

                    cb01801.SelectedIndex = selectData01801(dr[54].ToString());
                    tb01802.Text = dr[55].ToString().Replace("^", "'");

                    tbECTX.Text = dr[56].ToString().Replace("^", "'");
                    tbNOTE.Text = dr[57].ToString().Replace("^", "'");
                    tbATX1.Text = dr[58].ToString().Replace("^", "'");
                    tbATX2.Text = dr[59].ToString().Replace("^", "'");
                    tb00704.Text = dr[60].ToString().Replace("^", "'");
                    selectAdd();
                }
                dr.Close();
                

                Selectblock();
            }
            catch (System.Exception ex)
            {
            }

        }

        private void selectCOL()
        {

            String sql = "select TIT1, TIT2, TIT3, TIT4, n0101, n0201, n0301, n0401, n0402, n0403,n0404, n0501, n0601,n0701, n0702,n0703, n0801, n0802, n0803,n0901,n0902,n0903,n0904,n0905,n0906,n0907,n0908,n0909,n1001,n1101,n1102,n1201,n1202,n1203,n1301,n1302,n1303,n1401,n1402,n1403,n1501,n1502,n1503,n1504,n1505,n1601,n1602,n1603,n1604,n1605,n1606,n1701,n1702,n1703,n1801,n1802,ECTX,NOTE,ATX1,ATX2,n0704 from PISCOL001 where PTNO ='[PTNO]'";

            sql = sql.Replace("[PTNO]", PTNO);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read())
            {

                cbt00001.SelectedIndex = selectData00001(dr[0].ToString());
                cbt00002.SelectedIndex = selectData00002(dr[1].ToString());
                tbt00003.Text = dr[2].ToString().Replace("^", "'");
                cbt00004.SelectedIndex = selectData00004(dr[3].ToString());


                cb00101.SelectedIndex = selectData00101(dr[4].ToString());
                cb00201.SelectedIndex = selectData00201(dr[5].ToString());
                cb00301.SelectedIndex = selectData00301(dr[6].ToString());

                tb00401.Text = dr[7].ToString().Replace("^", "'");
                tb00402.Text = dr[8].ToString().Replace("^", "'");
                tb00403.Text = dr[9].ToString().Replace("^", "'");
                tb00404.Text = dr[10].ToString().Replace("^", "'");

                cb00501.SelectedIndex = selectData00501(dr[11].ToString());


                cb00601.SelectedIndex = selectData00601(dr[12].ToString());

                cb00701.SelectedIndex = selectData00701(dr[13].ToString());
                tb00702.Text = dr[14].ToString().Replace("^", "'");
                tb00703.Text = dr[15].ToString().Replace("^", "'");


                tb00801.Text = dr[16].ToString().Replace("^", "'");
                tb00802.Text = dr[17].ToString().Replace("^", "'");
                tb00803.Text = dr[18].ToString().Replace("^", "'");


                cb00901.SelectedIndex = selectData00901(dr[19].ToString());
                cb00902.SelectedIndex = selectData00902(dr[20].ToString());
                cb00903.SelectedIndex = selectData00903(dr[21].ToString());
                cb00904.SelectedIndex = selectData00904(dr[22].ToString());
                cb00905.SelectedIndex = selectData00905(dr[23].ToString());
                cb00906.SelectedIndex = selectData00906(dr[24].ToString());
                cb00907.SelectedIndex = selectData00907(dr[25].ToString());
                tb00908.Text = dr[26].ToString().Replace("^", "'");
                cb00909.SelectedIndex = selectData00909(dr[27].ToString());

                tb01001.Text = dr[28].ToString().Replace("^", "'");

                cb01101.SelectedIndex = selectData01101(dr[29].ToString());
                tb01102.Text = dr[30].ToString().Replace("^", "'");

                cb01201.SelectedIndex = selectData01201(dr[31].ToString());
                cb01202.SelectedIndex = selectData01202(dr[32].ToString());
                tb01203.Text = dr[33].ToString().Replace("^", "'");

                cb01301.SelectedIndex = selectData01301(dr[34].ToString());
                cb01302.SelectedIndex = selectData01302(dr[35].ToString());
                tb01303.Text = dr[36].ToString().Replace("^", "'");

                cb01401.SelectedIndex = selectData01401(dr[37].ToString());
                cb01402.SelectedIndex = selectData01402(dr[38].ToString());
                tb01403.Text = dr[39].ToString().Replace("^", "'");

                cb01501.SelectedIndex = selectData01501(dr[40].ToString());
                tb01502.Text = dr[41].ToString().Replace("^", "'");
                tb01503.Text = dr[42].ToString().Replace("^", "'");
                cb01504.SelectedIndex = selectData01504(dr[43].ToString());
                tb01505.Text = dr[44].ToString().Replace("^", "'");

                cb01601.SelectedIndex = selectData01601(dr[45].ToString());
                cb01602.SelectedIndex = selectData01602(dr[46].ToString());
                tb01603.Text = dr[47].ToString().Replace("^", "'");
                tb01604.Text = dr[48].ToString().Replace("^", "'");
                tb01605.Text = dr[49].ToString().Replace("^", "'");
                cb01606.SelectedIndex = selectData01606(dr[50].ToString());

                tb01701.Text = dr[51].ToString().Replace("^", "'");
                tb01702.Text = dr[52].ToString().Replace("^", "'");
                tb01703.Text = dr[53].ToString().Replace("^", "'");

                cb01801.SelectedIndex = selectData01801(dr[54].ToString());
                tb01802.Text = dr[55].ToString().Replace("^", "'");

                tbECTX.Text = dr[56].ToString().Replace("^", "'");
                tbNOTE.Text = dr[57].ToString().Replace("^", "'");
                tbATX1.Text = dr[58].ToString().Replace("^", "'");
                tbATX2.Text = dr[59].ToString().Replace("^", "'");
                tb00704.Text = dr[60].ToString().Replace("^", "'");
                selectAdd();
            }
            dr.Close();
        }

        private void Selectblock()
        {

            string sql = "select ABLK, NBLK from PISDIG001 where PTNO ='[PTNO]' and OGTP ='COL'";
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

            string sql = "select A101,A102,A103,A201,A202,A203,A301,A302,A303,A401,A402,A403,A501,A502,A503,A601,A602,A603,A701,A702,A703,A801,A802,A803,A901,A902,A903 from PISCOL001 where PTNO ='[PTNO]'";
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
                    dataGridView1.Rows.Add(drc[0].ToString(), drc[1].ToString(), drc[2].ToString());
                }
                if (drc[3].ToString() != "" || drc[4].ToString() != "" || drc[5].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[3].ToString(), drc[4].ToString(), drc[5].ToString());
                }
                if (drc[6].ToString() != "" || drc[7].ToString() != "" || drc[8].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[6].ToString(), drc[7].ToString(), drc[8].ToString());
                }
                if (drc[9].ToString() != "" || drc[10].ToString() != "" || drc[11].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[9].ToString(), drc[10].ToString(), drc[11].ToString());
                }
                if (drc[12].ToString() != "" || drc[13].ToString() != "" || drc[14].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[12].ToString(), drc[13].ToString(), drc[14].ToString());
                }
                if (drc[15].ToString() != "" || drc[16].ToString() != "" || drc[17].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[15].ToString(), drc[16].ToString(), drc[17].ToString());
                }
                if (drc[18].ToString() != "" || drc[19].ToString() != "" || drc[20].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[18].ToString(), drc[19].ToString(), drc[20].ToString());
                }
                if (drc[21].ToString() != "" || drc[22].ToString() != "" || drc[23].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[21].ToString(), drc[22].ToString(), drc[23].ToString());
                }
                if (drc[24].ToString() != "" || drc[25].ToString() != "" || drc[26].ToString() != "")
                {
                    dataGridView1.Rows.Add(drc[24].ToString(), drc[25].ToString(), drc[26].ToString());
                }

            }
            drc.Close();


        }

        private int selectData00001(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00001'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00002'";

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
        private int selectData00004(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00003'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00101'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00201'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00301'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00501'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00601'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00701'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00901'";

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
        private int selectData00902(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00902'";

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
        private int selectData00903(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00903'";

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
        private int selectData00904(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00904'";

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
        private int selectData00905(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00905'";

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
        private int selectData00906(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00906'";

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

        private int selectData00907(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00907'";

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

        private int selectData00909(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '00908'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '01101'";

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

        private int selectData01201(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '01201'";

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
        private int selectData01202(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '01202'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '01301'";

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
        private int selectData01302(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '01302'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '01401'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '01402'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '01501'";

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
        private int selectData01504(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '01502'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '01601'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '01602'";

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
        private int selectData01606(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '01603'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'COL'and  SQNO = '01801'";

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
        private void Insertcombo00004()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00003";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbt00004.Items.Add(dr.GetString(0));
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

        private void Insertcombo00902()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00902";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00902.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00903()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00903";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00903.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00904()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00904";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00904.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00905()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00905";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00905.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00906()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00906";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00906.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00907()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00907";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00907.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00909()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00908";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00909.Items.Add(dr.GetString(0));
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

        private void Insertcombo01201()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01201";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01201.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo01202()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01202";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01202.Items.Add(dr.GetString(0));
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

        private void Insertcombo01302()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01302";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01302.Items.Add(dr.GetString(0));
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

        private void Insertcombo01504()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01502";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01504.Items.Add(dr.GetString(0));
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

        private void Insertcombo01606()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01603";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01606.Items.Add(dr.GetString(0));
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = "select * from PISCOL001 where PTNO = '[PTNO]'";
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
                selectCOL();
                Selectblock();
                drc.Close();
                conn.Close();
            }
            catch (System.Exception ex)
            {
            }
        }

        private void InsertDB()
        {
            string Titlestr0001 = cbt00001.Text;
            Titlestr0001 = Titlestr0001.Replace("'", "^");

            string Titlestr0002 = cbt00002.Text;
            Titlestr0002 = Titlestr0002.Replace("'", "^");

            string Titlestr0003 = tbt00003.Text;
            Titlestr0003 = Titlestr0003.Replace("'", "^");

            string Titlestr0004 = cbt00004.Text;
            Titlestr0004 = Titlestr0004.Replace("'", "^");

            string str0101 = cb00101.Text;
            str0101 = str0101.Replace("'", "^");

            string str0201 = cb00201.Text;
            str0201 = str0201.Replace("'", "^");

            string str0301 = cb00301.Text;
            str0301 = str0301.Replace("'", "^");

            string str0401 = tb00401.Text;
            str0401 = str0401.Replace("'", "^");

            string str0402 = tb00402.Text;
            str0402 = str0402.Replace("'", "^");

            string str0403 = tb00403.Text;
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

            string str0703 = tb00703.Text;
            str0703 = str0703.Replace("'", "^");

            string str0704 = tb00704.Text;
            str0704 = str0704.Replace("'", "^");

            string str0801 = tb00801.Text;
            str0801 = str0801.Replace("'", "^");

            string str0802 = tb00802.Text;
            str0802 = str0802.Replace("'", "^");

            string str0803 = tb00803.Text;
            str0803 = str0803.Replace("'", "^");

            string str0901 = cb00901.Text;
            str0901 = str0901.Replace("'", "^");


            string str0902 = cb00902.Text;
            str0902 = str0902.Replace("'", "^");

            string str0903 = cb00903.Text;
            str0903 = str0903.Replace("'", "^");

            string str0904 = cb00904.Text;
            str0904 = str0904.Replace("'", "^");

            string str0905 = cb00905.Text;
            str0905 = str0905.Replace("'", "^");

            string str0906 = cb00906.Text;
            str0906 = str0906.Replace("'", "^");

            string str0907 = cb00907.Text;
            str0907 = str0907.Replace("'", "^");

            string str0908 = tb00908.Text;
            str0908 = str0908.Replace("'", "^");

            string str0909 = cb00909.Text;
            str0909 = str0909.Replace("'", "^");


            string str1001 = tb01001.Text;
            str1001 = str1001.Replace("'", "^");

            string str1101 = cb01101.Text;
            str1101 = str1101.Replace("'", "^");

            string str1102 = tb01102.Text;
            str1102 = str1102.Replace("'", "^");

            string str1201 = cb01201.Text;
            str1201 = str1201.Replace("'", "^");

            string str1202 = cb01202.Text;
            str1202 = str1202.Replace("'", "^");

            string str1203 = tb01203.Text;
            str1203 = str1203.Replace("'", "^");

            string str1301 = cb01301.Text;
            str1301 = str1301.Replace("'", "^");

            string str1302 = cb01302.Text;
            str1302 = str1302.Replace("'", "^");

            string str1303 = tb01303.Text;
            str1303 = str1303.Replace("'", "^");

            string str1401 = cb01401.Text;
            str1401 = str1401.Replace("'", "^");

            string str1402 = cb01402.Text;
            str1402 = str1402.Replace("'", "^");

            string str1403 = tb01403.Text;
            str1403 = str1403.Replace("'", "^");

            string str1501 = cb01501.Text;
            str1501 = str1501.Replace("'", "^");

            string str1502 = tb01502.Text;
            str1502 = str1502.Replace("'", "^");

            string str1503 = tb01503.Text;
            str1503 = str1503.Replace("'", "^");

            string str1504 = cb01504.Text;
            str1504 = str1504.Replace("'", "^");

            string str1505 = tb01505.Text;
            str1505 = str1505.Replace("'", "^");

            string str1601 = cb01601.Text;
            str1601 = str1601.Replace("'", "^");

            string str1602 = cb01602.Text;
            str1602 = str1602.Replace("'", "^");

            string str1603 = tb01603.Text;
            str1603 = str1603.Replace("'", "^");

            string str1604 = tb01604.Text;
            str1604 = str1604.Replace("'", "^");

            string str1605 = tb01605.Text;
            str1605 = str1605.Replace("'", "^");

            string str1606 = cb01606.Text;
            str1606 = str1606.Replace("'", "^");

            string str1701 = tb01701.Text;
            str1701 = str1701.Replace("'", "^");

            string str1702 = tb01702.Text;
            str1702 = str1702.Replace("'", "^");

            string str1703 = tb01703.Text;
            str1703 = str1703.Replace("'", "^");

            string str1801 = cb01801.Text;
            str1801 = str1801.Replace("'", "^");

            string str1802 = tb01802.Text;
            str1802 = str1802.Replace("'", "^");


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

            string sql = "INSERT INTO pisCOL001 ( SYDT, UPDT, UPID, PTNO, OGTP, DITP, TRYN, TIT1, TIT2,TIT3,TIT4, n0101, n0201,n0301, n0401, n0402,n0403, n0404, n0501, n0601, n0701, n0702,n0703,n0704, n0801, n0802, n0803, n0901,n0902,n0903,n0904,n0905,n0906,n0907,n0908,n0909, n1001,n1101,n1102,n1201,n1202,n1203,n1301,n1302,n1303,n1401,n1402,n1403,n1501,n1502,n1503,n1504,n1505,n1601,n1602,n1603,n1604,n1605,n1606,n1701,n1702,n1703,n1801,n1802, ECTX, NOTE,ATX1,ATX2) VALUES ( '[SYDT]', '[UPDT]', '[UPID]', '[PTNO]', '[OGTP]', '[DITP]', '[TRYN]','[TIT1]', '[TIT2]', '[TIT3]','[TIT4]','[n0101]', '[n0201]','[n0301]', '[n0401]', '[n0402]','[n0403]', '[n0404]', '[n0501]', '[n0601]', '[n0701]', '[n0702]','[n0703]','[n0704]', '[n0801]', '[n0802]', '[n0803]', '[n0901]','[n0902]','[n0903]','[n0904]','[n0905]','[n0906]','[n0907]','[n0908]','[n0909]', '[n1001]','[n1101]','[n1102]','[n1201]','[n1202]','[n1203]','[n1301]','[n1302]','[n1303]','[n1401]','[n1402]','[n1403]','[n1501]','[n1502]','[n1503]','[n1504]','[n1505]','[n1601]','[n1602]','[n1603]','[n1604]','[n1605]','[n1606]','[n1701]','[n1702]','[n1703]','[n1801]','[n1802]', '[ECTX]','[NOTE]','[ATX1]','[ATX2]')";
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
            sql = sql.Replace("[TIT4]", Titlestr0004);

            sql = sql.Replace("[n0101]", str0101);


            sql = sql.Replace("[n0201]", str0201);


            sql = sql.Replace("[n0301]", str0301);

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


            sql = sql.Replace("[n0801]", str0801);
            sql = sql.Replace("[n0802]", str0802);
            sql = sql.Replace("[n0803]", str0803);

            sql = sql.Replace("[n0901]", str0901);
            sql = sql.Replace("[n0902]", str0902);
            sql = sql.Replace("[n0903]", str0903);
            sql = sql.Replace("[n0904]", str0904);
            sql = sql.Replace("[n0905]", str0905);
            sql = sql.Replace("[n0906]", str0906);
            sql = sql.Replace("[n0907]", str0907);
            sql = sql.Replace("[n0908]", str0908);
            sql = sql.Replace("[n0909]", str0909);


            sql = sql.Replace("[n1001]", str1001);

            sql = sql.Replace("[n1101]", str1101);
            sql = sql.Replace("[n1102]", str1102);

            sql = sql.Replace("[n1201]", str1201);
            sql = sql.Replace("[n1202]", str1202);
            sql = sql.Replace("[n1203]", str1203);

            sql = sql.Replace("[n1301]", str1301);
            sql = sql.Replace("[n1302]", str1302);
            sql = sql.Replace("[n1303]", str1303);

            sql = sql.Replace("[n1401]", str1401);
            sql = sql.Replace("[n1402]", str1402);
            sql = sql.Replace("[n1403]", str1403);

            sql = sql.Replace("[n1501]", str1501);
            sql = sql.Replace("[n1502]", str1502);
            sql = sql.Replace("[n1503]", str1503);
            sql = sql.Replace("[n1504]", str1504);
            sql = sql.Replace("[n1505]", str1505);

            sql = sql.Replace("[n1601]", str1601);
            sql = sql.Replace("[n1602]", str1602);
            sql = sql.Replace("[n1603]", str1603);
            sql = sql.Replace("[n1604]", str1604);
            sql = sql.Replace("[n1605]", str1605);
            sql = sql.Replace("[n1606]", str1606);

            sql = sql.Replace("[n1701]", str1701);
            sql = sql.Replace("[n1702]", str1702);
            sql = sql.Replace("[n1703]", str1703);

            sql = sql.Replace("[n1801]", str1801);
            sql = sql.Replace("[n1802]", str1802);


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

        private void UpdateDB()
        {

            string Titlestr0001 = cbt00001.Text;
            Titlestr0001 = Titlestr0001.Replace("'", "^");

            string Titlestr0002 = cbt00002.Text;
            Titlestr0002 = Titlestr0002.Replace("'", "^");

            string Titlestr0003 = tbt00003.Text;
            Titlestr0003 = Titlestr0003.Replace("'", "^");

            string Titlestr0004 = cbt00004.Text;
            Titlestr0004 = Titlestr0004.Replace("'", "^");

            string str0101 = cb00101.Text;
            str0101 = str0101.Replace("'", "^");

            string str0201 = cb00201.Text;
            str0201 = str0201.Replace("'", "^");

            string str0301 = cb00301.Text;
            str0301 = str0301.Replace("'", "^");

            string str0401 = tb00401.Text;
            str0401 = str0401.Replace("'", "^");

            string str0402 = tb00402.Text;
            str0402 = str0402.Replace("'", "^");

            string str0403 = tb00403.Text;
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

            string str0703 = tb00703.Text;
            str0703 = str0703.Replace("'", "^");

            string str0704 = tb00704.Text;
            str0704 = str0704.Replace("'", "^");

            string str0801 = tb00801.Text;
            str0801 = str0801.Replace("'", "^");

            string str0802 = tb00802.Text;
            str0802 = str0802.Replace("'", "^");

            string str0803 = tb00803.Text;
            str0803 = str0803.Replace("'", "^");

            string str0901 = cb00901.Text;
            str0901 = str0901.Replace("'", "^");


            string str0902 = cb00902.Text;
            str0902 = str0902.Replace("'", "^");

            string str0903 = cb00903.Text;
            str0903 = str0903.Replace("'", "^");

            string str0904 = cb00904.Text;
            str0904 = str0904.Replace("'", "^");

            string str0905 = cb00905.Text;
            str0905 = str0905.Replace("'", "^");

            string str0906 = cb00906.Text;
            str0906 = str0906.Replace("'", "^");

            string str0907 = cb00907.Text;
            str0907 = str0907.Replace("'", "^");

            string str0908 = tb00908.Text;
            str0908 = str0908.Replace("'", "^");

            string str0909 = cb00909.Text;
            str0909 = str0909.Replace("'", "^");
            
            string str1001 = tb01001.Text;
            str1001 = str1001.Replace("'", "^");

            string str1101 = cb01101.Text;
            str1101 = str1101.Replace("'", "^");

            string str1102 = tb01102.Text;
            str1102 = str1102.Replace("'", "^");

            string str1201 = cb01201.Text;
            str1201 = str1201.Replace("'", "^");

            string str1202 = cb01202.Text;
            str1202 = str1202.Replace("'", "^");

            string str1203 = tb01203.Text;
            str1203 = str1203.Replace("'", "^");

            string str1301 = cb01301.Text;
            str1301 = str1301.Replace("'", "^");

            string str1302 = cb01302.Text;
            str1302 = str1302.Replace("'", "^");

            string str1303 = tb01303.Text;
            str1303 = str1303.Replace("'", "^");

            string str1401 = cb01401.Text;
            str1401 = str1401.Replace("'", "^");

            string str1402 = cb01402.Text;
            str1402 = str1402.Replace("'", "^");

            string str1403 = tb01403.Text;
            str1403 = str1403.Replace("'", "^");

            string str1501 = cb01501.Text;
            str1501 = str1501.Replace("'", "^");

            string str1502 = tb01502.Text;
            str1502 = str1502.Replace("'", "^");

            string str1503 = tb01503.Text;
            str1503 = str1503.Replace("'", "^");

            string str1504 = cb01504.Text;
            str1504 = str1504.Replace("'", "^");

            string str1505 = tb01505.Text;
            str1505 = str1505.Replace("'", "^");

            string str1601 = cb01601.Text;
            str1601 = str1601.Replace("'", "^");

            string str1602 = cb01602.Text;
            str1602 = str1602.Replace("'", "^");

            string str1603 = tb01603.Text;
            str1603 = str1603.Replace("'", "^");

            string str1604 = tb01604.Text;
            str1604 = str1604.Replace("'", "^");

            string str1605 = tb01605.Text;
            str1605 = str1605.Replace("'", "^");

            string str1606 = cb01606.Text;
            str1606 = str1606.Replace("'", "^");

            string str1701 = tb01701.Text;
            str1701 = str1701.Replace("'", "^");

            string str1702 = tb01702.Text;
            str1702 = str1702.Replace("'", "^");

            string str1703 = tb01703.Text;
            str1703 = str1703.Replace("'", "^");

            string str1801 = cb01801.Text;
            str1801 = str1801.Replace("'", "^");

            string str1802 = tb01802.Text;
            str1802 = str1802.Replace("'", "^");


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

            string sql = "Update pisCOL001 SET SYDT = '[SYDT]', UPDT = '[UPDT]', UPID = '[UPID]', OGTP = '[OGTP]', DITP='[DITP]', TRYN ='[TRYN]', TIT1 = '[TIT1]',TIT2= '[TIT2]',TIT3 ='[TIT3]',TIT4 ='[TIT4]', n0101 = '[n0101]', n0201 = '[n0201]',n0301='[n0301]', n0401 = '[n0401]', n0402 = '[n0402]', n0403 = '[n0403]', n0404 = '[n0404]', n0501 = '[n0501]', n0601='[n0601]', n0701='[n0701]', n0702='[n0702]', n0703='[n0703]',n0704='[n0704]', n0801='[n0801]', n0802='[n0802]', n0803='[n0803]', n0901='[n0901]', n0902='[n0902]', n0903='[n0903]', n0904='[n0904]', n0905='[n0905]', n0906='[n0906]', n0907='[n0907]', n0908='[n0908]',n0909='[n0909]',n1001='[n1001]',n1101='[n1101]',n1102='[n1102]',n1201='[n1201]',n1202='[n1202]',n1203='[n1203]',n1301='[n1301]',n1302='[n1302]',n1303='[n1303]',n1401='[n1401]',n1402='[n1402]',n1403='[n1403]',n1501='[n1501]',n1502='[n1502]',n1503='[n1503]',n1504='[n1504]',n1505='[n1505]', n1601='[n1601]',n1602='[n1602]',n1603='[n1603]',n1604='[n1604]',n1605='[n1605]',n1606='[n1606]', n1701='[n1701]',n1702='[n1702]',n1703='[n1703]', n1801='[n1801]',n1802='[n1802]',ECTX='[ECTX]', NOTE='[NOTE]' , ATX1='[ATX1]',ATX2 ='[ATX2]' where PTNO ='[PTNO]'";
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
            sql = sql.Replace("[TIT4]", Titlestr0004);

            sql = sql.Replace("[n0101]", str0101);
            

            sql = sql.Replace("[n0201]", str0201);
            

            sql = sql.Replace("[n0301]", str0301);

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


            sql = sql.Replace("[n0801]", str0801);
            sql = sql.Replace("[n0802]", str0802);
            sql = sql.Replace("[n0803]", str0803);
           
            sql = sql.Replace("[n0901]", str0901);
            sql = sql.Replace("[n0902]", str0902);
            sql = sql.Replace("[n0903]", str0903);
            sql = sql.Replace("[n0904]", str0904);
            sql = sql.Replace("[n0905]", str0905);
            sql = sql.Replace("[n0906]", str0906);
            sql = sql.Replace("[n0907]", str0907);
            sql = sql.Replace("[n0908]", str0908);
            sql = sql.Replace("[n0909]", str0909);
            

            sql = sql.Replace("[n1001]", str1001);

            sql = sql.Replace("[n1101]", str1101);
            sql = sql.Replace("[n1102]", str1102);

            sql = sql.Replace("[n1201]", str1201);
            sql = sql.Replace("[n1202]", str1202);
            sql = sql.Replace("[n1203]", str1203);

            sql = sql.Replace("[n1301]", str1301);
            sql = sql.Replace("[n1302]", str1302);
            sql = sql.Replace("[n1303]", str1303);

            sql = sql.Replace("[n1401]", str1401);
            sql = sql.Replace("[n1402]", str1402);
            sql = sql.Replace("[n1403]", str1403);

            sql = sql.Replace("[n1501]", str1501);
            sql = sql.Replace("[n1502]", str1502);
            sql = sql.Replace("[n1503]", str1503);
            sql = sql.Replace("[n1504]", str1504);
            sql = sql.Replace("[n1505]", str1505);

            sql = sql.Replace("[n1601]", str1601);
            sql = sql.Replace("[n1602]", str1602);
            sql = sql.Replace("[n1603]", str1603);
            sql = sql.Replace("[n1604]", str1604);
            sql = sql.Replace("[n1605]", str1605);
            sql = sql.Replace("[n1606]", str1606);

            sql = sql.Replace("[n1701]", str1701);
            sql = sql.Replace("[n1702]", str1702);
            sql = sql.Replace("[n1703]", str1703);

            sql = sql.Replace("[n1801]", str1801);
            sql = sql.Replace("[n1802]", str1802);


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


            for (int i = 0; i < Convert.ToUInt32(dataGridView1.Rows.Count - 1); i++)
            {
                string str1 = dataGridView1.Rows[i].Cells[0].FormattedValue.ToString();
                string str2 = dataGridView1.Rows[i].Cells[1].FormattedValue.ToString();
                string str3 = dataGridView1.Rows[i].Cells[2].FormattedValue.ToString();
                str1 = str1.Replace("'", "^");
                str2 = str2.Replace("'", "^");
                str3 = str3.Replace("'", "^");
                n = i + 1;
                string ADD1 = "A" + n + "01";
                string ADD2 = "A" + n + "02";
                string ADD3 = "A" + n + "03";

                string sql = String.Format("Update PISCOL001 set {0}='{1}', {2} = '{3}',{4}='{5}' where PTNO = '{6}'", ADD1, str1, ADD2, str2, ADD3, str3, PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }


        }

        private void MainDBUpdate()
        {

            string sql = "Update PISDIG001 set  DITX = '[DITX]', ABLK = '[ABLK]',NBLK = '[NBLK]',OGTP = '[OGTP]' where PTNO = '[PTNO]'";
            //string DITX = lbt00001.Text + Environment.NewLine + lbt00002.Text + cbt00001.Text + cbt00002.Text + cbt00003.Text + Environment.NewLine + " " + tbt00004.Text + Environment.NewLine + Environment.NewLine + "  " + lb00101.Text + Environment.NewLine + "    " + cb00101.Text + Environment.NewLine + Environment.NewLine + "  " + lb00201.Text + Environment.NewLine + "    " + cb00201.Text + Environment.NewLine + Environment.NewLine + "  " + lb00301.Text + Environment.NewLine + "    " + cb00301.Text + Environment.NewLine + Environment.NewLine + "  " + lb00401.Text + tb00401.Text + lb00402.Text + tb00402.Text + lb00403.Text + tb00403.Text + lb00404.Text + Environment.NewLine + Environment.NewLine + "  " + lb00501.Text + Environment.NewLine + "    " + cb00501.Text + Environment.NewLine + Environment.NewLine + "  " + lb00601.Text + Environment.NewLine + "    " + cb00601.Text + Environment.NewLine + Environment.NewLine + "  " + lb00701.Text + Environment.NewLine + "    " + cb00701.Text + Environment.NewLine + "    " + tb00702.Text + Environment.NewLine + Environment.NewLine + "  " + lb00801.Text + Environment.NewLine + "    " + lb00802.Text + Environment.NewLine + "     " + cb00801.Text + Environment.NewLine + "      " + lb00803.Text + tb00802.Text + lb00804.Text + Environment.NewLine + "    " + lb00805.Text + Environment.NewLine + "     " + cb00803.Text + Environment.NewLine + "    " + lb00806.Text + Environment.NewLine + "     " + cb00804.Text + Environment.NewLine + "      " + lb00807.Text + tb00805.Text + lb00808.Text + Environment.NewLine + "    " + lb00809.Text + Environment.NewLine + "     " + cb00806.Text + Environment.NewLine + Environment.NewLine + "  " + lb00901.Text + Environment.NewLine + "    " + cb00901.Text + Environment.NewLine + Environment.NewLine + "  " + lb01001.Text + cb01001.Text + Environment.NewLine + Environment.NewLine + "  " + lb01101.Text + cb01101.Text + Environment.NewLine + Environment.NewLine + "  " + lb01201.Text + cb01201.Text + Environment.NewLine + Environment.NewLine + "  " + lb01301.Text + Environment.NewLine + "     " + tb01301.Text + Environment.NewLine + Environment.NewLine + "  " + lb01401.Text + lb01402.Text + tb01401.Text + lb01403.Text + tb01402.Text + lb01404.Text + tb01403.Text + Environment.NewLine + Environment.NewLine + "  " + ectb001.Text + Environment.NewLine + Environment.NewLine + "  " + ntlb001.Text + Environment.NewLine + "  " + nttb001.Text;



            string str00001 = cbt00001.Text;
            str00001 = str00001.Replace("'", "^");
            string str00002 = " " +cbt00002.Text;
            str00002 = str00002.Replace("'", "^");
            string str00003 = " " + tbt00003.Text;
            str00003 = str00003.Replace("'", "^");
            string str00004 = Environment.NewLine + " " + cbt00004.Text;
            str00004 = str00004.Replace("'", "^");
            
           


            string str000 =  lbt00002.Text + str00001 + str00002 + str00003 + str00004 + " " +lbt00003.Text;
            str000 = str000.Replace("'", "^");
            if (cbt00004.Text == "")
            {
                str000 = lbt00002.Text + str00001 + str00002 + str00003 +Environment.NewLine + lbt00003.Text;
            }


            if (cbt00001.Text == " " && cbt00002.Text == " " && tbt00003.Text == "" && cbt00004.Text == " ")
            {
                str000 = "";
            }
            


            string str00101 = cb00101.Text;
            str00101 = str00101.Replace("'", "^");
          
           
            string str001 = Environment.NewLine + " " + lb00101.Text + str00101;
            str001 = str001.Replace("'", "^");
            if (cb00101.Text == " ")
            {
                str001 = "";
            }

            string str00201 = cb00201.Text;
            str00201 = str00201.Replace("'", "^");
            string str002 =  Environment.NewLine + " " + lb00201.Text +str00201;
            str002 = str002.Replace("'", "^");
            if (cb00201.Text == " ")
            {
                str002 = "";
            }

            string str00301 = cb00301.Text;
            str00301 = str00301.Replace("'", "^");
            string str003 = Environment.NewLine + " " + lb00301.Text + str00301;
            str003 = str003.Replace("'", "^");
            if (cb00301.Text == " ")
            {
                str003 = "";
            }


            string str00401 = tb00401.Text + lb00402.Text;
            string str00402 = tb00402.Text + lb00403.Text;
            string str00403 = tb00403.Text;
            string str00404 = lb00405.Text + tb00404.Text + lb00406.Text;
            string str004 =  Environment.NewLine + " " + lb00401.Text + " " + str00401 + str00402 + str00403 + lb00404.Text;
            str002 = str002.Replace("'", "^");


            if (tb00401.Text == "")
            {

                str004 = Environment.NewLine + " " + lb00401.Text+ " "+ str00402 + str00403 + lb00404.Text;
            }
            if (tb00402.Text == "")
            {
                str004 =  Environment.NewLine + " " + lb00401.Text + " " + str00401 + str00403 + lb00404.Text;
            }
            if (tb00403.Text == "")
            {

                str004 =  Environment.NewLine + " " + lb00401.Text + " " + str00401 + tb00402.Text + lb00404.Text;
            }
            if (tb00401.Text == "" && tb00402.Text == "")
            {
                str004 =  Environment.NewLine + " " + lb00401.Text + " " + str00403 + lb00404.Text;
            }
            if (tb00401.Text == "" && tb00403.Text == "")
            {
                str004 = Environment.NewLine + " " + lb00401.Text + " " + tb00402.Text + lb00404.Text;
            }
            if (tb00402.Text == "" && tb00403.Text == "")
            {
                str004 =Environment.NewLine + " " + lb00401.Text + " " + tb00401.Text + lb00404.Text;
            }
            if (tb00404.Text != "")
            {
                str004 = str004 + str00404;
            }

            if (tb00401.Text == "" && tb00402.Text == "" && tb00403.Text == ""&& tb00404.Text =="")
            {
                str004 = "";
            }
            string str005 =  Environment.NewLine + " " + lb00501.Text + cb00501.Text;
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


            string str00701 = Environment.NewLine + "     " + cb00701.Text;
            if (cb00701.Text == " ")
            {
                str00701 = "";
            }
            string str00702 = Environment.NewLine + "       " +lb00702.Text +  tb00702.Text + lb00703.Text;
            if (tb00702.Text == "")
            {
                str00702 = "";
            }
            string str00703 = Environment.NewLine + "       " + lb00704.Text + tb00703.Text + lb00705.Text;
            if (tb00703.Text == "")
            {
                str00703 = "";
            }
            string str00704;
            if (tb00704.Text != "")
            {
                str00704 = " " + lb00706.Text + tb00704.Text + lb00707.Text;
            }
            else
            {
                str00704 = "";
            }
            string str007 =  Environment.NewLine + " " + lb00701.Text + str00701 +str00704 +  str00702+str00703;
            if (cb00701.Text == " " && tb00702.Text == "" && tb00703.Text == "" && tb00704.Text == "")
            {
                str007 = "";
            }

            string str00801 = Environment.NewLine + "     " + lb00802.Text + tb00801.Text + lb00803.Text;
            if (tb00801.Text == "")
            {
                str00801 = "";
            }
            string str00802 = Environment.NewLine + "     " + lb00804.Text + tb00802.Text ;
            if (tb00802.Text == "")
            {
                str00802 = "";
            }
            string str00803 = lb00805.Text + tb00803.Text + lb00806.Text;
            if (tb00803.Text == "")
            {
                str00803 = "";
            }
            
           
            string str008 =  Environment.NewLine + " " + lb00801.Text + str00801 + str00802 + str00803;
            if (tb00801.Text == "" && tb00802.Text == "")
            {
                str008 = Environment.NewLine + " " + lb00801.Text + Environment.NewLine + tb00803.Text + " " + lb00806.Text;
            }

            if (tb00801.Text == "" && tb00802.Text == "" && tb00803.Text == "")
            {
                str008 = "";
            }

            string str00901 = cb00901.Text;
            str00901 = str00901.Replace("'", "^");
            if (cb00901.Text == " ")
            {
                str00901 = "";
            }

            string str00902 = lb00902.Text + cb00902.Text;
            str00902 = str00902.Replace("'", "^");
            if (cb00902.Text == " ")
            {
                str00902 = "";
            }

            string str00903 = cb00903.Text;
            str00903 = str00903.Replace("'", "^");
            if (cb00903.Text == " ")
            {
                str00903 = "";
            }

            string str00904 = lb00903.Text + cb00904.Text;
            str00904 = str00904.Replace("'", "^");
            if (cb00904.Text == " ")
            {
                str00904 = "";
            }

            string str00905 = cb00905.Text;
            str00905 = str00905.Replace("'", "^");
            if (cb00905.Text == " ")
            {
                str00905 = "";
            }

            string str00906 = lb00904.Text + cb00906.Text;
            str00906 = str00906.Replace("'", "^");
            if (cb00906.Text == " ")
            {
                str00906 = "";
            }

            string str00907 = Environment.NewLine + "      " +lb00905.Text +  cb00907.Text;
            str00907 = str00907.Replace("'", "^");
            if (cb00907.Text == " ")
            {
                str00907 = "";
            }

            string str00908 = " " + tb00908.Text;
            str00908 = str00908.Replace("'", "^");
            if (tb00908.Text == "")
            {
                str00908 = "";
            }

            string str00909 = Environment.NewLine + "      " +lb00906.Text + cb00909.Text;
            str00909 = str00909.Replace("'", "^");
            if (cb00909.Text == " ")
            {
                str00909 = "";
            }
            //작업현황1107
            string str009 =Environment.NewLine + " " + lb00901.Text + str00901 + str00902 + " " + str00903 + str00904+ " "  + str00905 + str00906 + str00907 + str00908 + str00909;
            str009 = str009.Replace("'", "^");
            if (cb00907.Text == " " && tb00908.Text == "")
            {
                str009 = Environment.NewLine + " " + lb00901.Text + str00901 + str00902 + str00903 + str00904 + str00905 + str00906;
            }
            if (cb00901.Text == " " && cb00902.Text == " " && cb00903.Text == " " && cb00904.Text == " " && cb00905.Text == " " && cb00906.Text == " " )
            {
                str009 =  Environment.NewLine + " " + lb00901.Text + str00907 + str00908;
            }
            if (cb00901.Text == " " && cb00902.Text == " " && cb00903.Text == " " && cb00904.Text == " " && cb00905.Text == " " && cb00906.Text == " " && cb00907.Text == " " && tb00908.Text == "")
            {
                str009 = "";
            }


            string str010 =  Environment.NewLine + " " + lb01001.Text + tb01001.Text;
            str010 = str010.Replace("'", "^");
            if (tb01001.Text == "")
            {
                str010 = "";
            }

            string str01101 = cb01101.Text;
            string str01102 = " " + tb01102.Text + lb01102.Text;
            string str011 = Environment.NewLine + " " + lb01101.Text + str01101 + str01102;
            str011 = str011.Replace("'", "^");
            if (cb01101.Text == " "&& tb01102.Text=="")
            {
                str011 = "";
            }

            string str01201 = cb01201.Text;
            string str01202 = " " + cb01202.Text;
            string str01203 = " " + tb01203.Text;
            string str012 =  Environment.NewLine + " " + lb01201.Text + str01201 + str01202 + str01203;
            str012 = str012.Replace("'", "^");
            if (cb01201.Text == " " && cb01202.Text == " " && tb01203.Text=="")
            {
                str012 = "";
            }

            string str01301 = cb01301.Text;
            string str01302 = " " + cb01302.Text;
            string str01303 = " " + tb01303.Text;
            string str013 =  Environment.NewLine + " " + lb01301.Text + str01301 + str01302 + str01303;
            str013 = str013.Replace("'", "^");
            if (cb01301.Text == " " && cb01302.Text == " "&& tb01303.Text=="")
            {
                str013 = "";
            }

            string str01401 = cb01401.Text;
            string str01402 = " " + cb01402.Text;
            string str01403 = " " + tb01403.Text;
            string str014 =  Environment.NewLine + " " + lb01401.Text + str01401 + str01402+ str01403;
            str014 = str014.Replace("'", "^");
            if (cb01401.Text == " " && cb01402.Text == " " && tb01403.Text=="")
            {
                str014 = "";
            }

            string str01501 = Environment.NewLine + "    " +cb01501.Text;
            string str01502 = Environment.NewLine + "     " + lb01503.Text + tb01502.Text + lb01504.Text;
            string str01503 = " " + lb01505.Text + tb01503.Text + lb01506.Text;

            string str01504 = Environment.NewLine + "    " + cb01504.Text;
            string str01505 = Environment.NewLine +"     " + lb01508.Text + tb01505.Text + lb01509.Text;

            string str015 =  Environment.NewLine + " " +lb01501.Text + Environment.NewLine +"   "+ lb01502.Text + str01501 + str01502 + str01503 + Environment.NewLine +"   " + lb01507.Text + str01504 + str01505;
            if (cb01501.Text == " " && tb01502.Text == "" && tb01503.Text == "")
            {
                str015 =  Environment.NewLine + "   " + lb01507.Text + str01504 + str01505;
            }
            if (cb01504.Text == " " && tb01505.Text == "")
            {
                str015 =  Environment.NewLine + lb01501.Text + Environment.NewLine + "   " + lb01502.Text + str01501 + str01502 + str01503;
            }

            if (cb01501.Text == " " && tb01502.Text == "" && tb01503.Text == "" && cb01504.Text == " " && tb01505.Text == "")
            {
                str015 = "";
            }

            string str01601 = cb01601.Text;
            
            string str01602 = " " + lb01602.Text + " " + cb01602.Text +" " + lb01603.Text;
            string str01603 = tb01603.Text;
            string str01604 = lb01605.Text + tb01604.Text;
            string str01605 = lb01606.Text + tb01605.Text;
            string str01606 = lb01608.Text + cb01606.Text;

            string str016 = Environment.NewLine + " " + lb01601.Text + str01601 + str01602 + Environment.NewLine + "      " + lb01604.Text + str01603 + str01604 + str01605 + lb01607.Text + Environment.NewLine + "      " + str01606;

            if (tb01603.Text == "")
            {
                str016 =  Environment.NewLine + " " + lb01601.Text + str01601 + str01602 + Environment.NewLine + "      " + lb01604.Text + tb01604.Text + str01605 + lb01607.Text + Environment.NewLine + "      " + str01606;
            }
            if (tb01604.Text == "")
            {
                str016 = Environment.NewLine + " " + lb01601.Text + str01601 + str01602 + Environment.NewLine + "      " + lb01604.Text + str01603 + str01605 + lb01607.Text + Environment.NewLine + "      " + str01606;
            }
            if (tb01605.Text == "")
            {
                str016 = Environment.NewLine + " " + lb01601.Text + str01601 + str01602 + Environment.NewLine + "      " + lb01604.Text + str01603 + str01604 + lb01607.Text + Environment.NewLine + "      " + str01606;

            }
            if (cb01606.Text == " ")
            {
                str016 = Environment.NewLine + " " + lb01601.Text + str01601 + str01602 + Environment.NewLine + "      " + lb01604.Text + str01603 + str01604 + str01605 + lb01607.Text;
            }

            if (cb01601.Text == " " && cb01602.Text == " " && tb01603.Text == "" && tb01604.Text == "" && tb01605.Text == "" && cb01606.Text == " ")
            {
                str016 = "";
            }
            //20161004
            str016 = str016.Replace("'", "^");
            string str01701 = Environment.NewLine + "      " + lb01702.Text + " " + tb01701.Text;
            if (tb01701.Text == "")
            {
                str01701 = "";
            }            
            string str01702 = Environment.NewLine + "      " + lb01703.Text + " " + tb01702.Text ;
            if (tb01702.Text == "")
            {
                str01702 = "";
            }
            string str01703 = Environment.NewLine + "      " + lb01704.Text + " " + tb01703.Text;
            if (tb01703.Text == "")
            {
                str01703 = "";
            }
            string str017 = Environment.NewLine + " " + lb01701.Text + str01701 + str01702 + str01703;
            str017 = str017.Replace("'", "^");

            if (tb01701.Text == "" && tb01702.Text == "" && tb01703.Text == "")
            {
                str017 = "";
            }

            string str01801 = cb01801.Text;
            if (cb01801.Text == " ")
            {
                str01801 = "";
            }
            
            string str01802 =  " " + tb01802.Text;
            if (tb01802.Text == "")
            {
                str01802 = "";
            }
            string str018 =  Environment.NewLine + " " + lb01801.Text + str01801 + str01802;

            if (cb01801.Text == " " && tb01802.Text == "")
            {
                str018 = "";
            }

            string strTBECTX = tbECTX.Text.Replace("\r\n", "\r\n ");
            string strECTX = Environment.NewLine + " " + strTBECTX;
            strECTX = strECTX.Replace("'", "^");
            string strTBNOTE = "     " + tbNOTE.Text.Replace("\r\n", "\r\n     ");
            string strNOTE =  Environment.NewLine + " " + lbNOTE.Text + Environment.NewLine + strTBNOTE;
            strNOTE = strNOTE.Replace("'", "^");
            string strTBATX1 = " " + tbATX1.Text.Replace("\r\n", "\r\n     ");
            string strATX1 = Environment.NewLine + tbATX1.Text;
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

            for (int i = 0; i < Convert.ToUInt32(dataGridView1.Rows.Count - 1); i++)
            {
                string str1 = dataGridView1.Rows[i].Cells[0].FormattedValue.ToString();
                string str2 = dataGridView1.Rows[i].Cells[1].FormattedValue.ToString();
                string str3 = dataGridView1.Rows[i].Cells[2].FormattedValue.ToString();
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

                totalAdd =  ADD[1] + ADD[2] +  ADD[3] +  ADD[4] + ADD[5] +  ADD[6] +  ADD[7] +  ADD[8];
                totalAdd = totalAdd.Replace("'", "^");
            }
            string DITX = lbt00001.Text +Environment.NewLine + str000 + str001 + str002 + str003 + str004 + str005 + str006 + str007 + str008 + str009 + str010 +str011 + str012 + str013 + str014 + str015 + str016 + str017 + str018 + strECTX + strNOTE + strATX1 +  totalAdd + strATX2;
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


        private void reset()
        {
            cbt00001.Text = " ";
            cbt00002.Text = " ";
            tbt00003.Text = "";
            cbt00004.Text = " ";

            cb00101.Text = " ";
            
            cb00201.Text = " ";
            
            cb00301.Text = " ";
            tb00401.Text = "";
            tb00402.Text = "";
            tb00403.Text = "";
            tb00404.Text = "";

            cb00501.Text = " ";
            
            cb00601.Text = " ";

            cb00701.Text = " ";
            tb00702.Text = "";
            tb00703.Text = "";
            tb00704.Text = "";
            tb00801.Text = "";
            tb00802.Text = "";
            tb00803.Text = "";
            

            cb00901.Text = "p";
            cb00902.Text = " ";
            cb00903.Text = "p";
            cb00904.Text = " ";
            cb00905.Text = "p";
            cb00906.Text = " ";
            cb00907.Text = " ";
            tb00908.Text = "";
            cb00909.Text = " ";

            tb01001.Text = "";

            cb01101.Text = " ";
            tb01102.Text = "";

            cb01201.Text = " ";
            cb01202.Text = " ";
            tb01203.Text = "";

            cb01301.Text = " ";
            cb01302.Text = " ";
            tb01303.Text = "";

            cb01401.Text = " ";
            cb01402.Text = " ";
            tb01403.Text = "";

            cb01501.Text = " ";
            tb01502.Text = "";
            tb01503.Text = "";
            cb01504.Text = " ";
            tb01505.Text = "";

            cb01601.Text = " ";
            cb01602.Text = " ";
            tb01603.Text = "";
            tb01604.Text = "";
            tb01605.Text = "";
            cb01606.Text = " ";

            tb01701.Text = "";
            tb01702.Text = "";
            tb01703.Text = "Not identified";

            cb01801.Text = " ";
            tb01802.Text = "";

            tbECTX.Text = "";
            tbNOTE.Text = "";

            tbblock01.Text = "";
            tbblock03.Text = "";
            tbATX1.Text = "";
            tbATX2.Text = "";
            dataGridView1.Rows.Clear();
            cbt00001.Select();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("정보를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sql = "delete from pisCOL001 where ptno = '[PTNO]'";
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select DITX from PISDIG001 where PTNO ='[PTNO]' and OGTP ='COL'";
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

        private void tb00401_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00402_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00403_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00702_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00703_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb01102_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb01502_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb01503_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb01505_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb01603_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb01604_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb01605_KeyPress(object sender, KeyPressEventArgs e)
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void lb00405_Click(object sender, EventArgs e)
        {

        }

        private void tb00404_TextChanged(object sender, EventArgs e)
        {

        }

        private void lb00406_Click(object sender, EventArgs e)
        {

        }

        private void cb01402_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cb01401_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lb01401_Click(object sender, EventArgs e)
        {

        }

        private void cb00601_TextChanged(object sender, EventArgs e)
        {
            //cb00601Text.Text = cb00601.Text;
        }

        private void cb00701_TextChanged(object sender, EventArgs e)
        {
            cb00701Text.Text = cb00701.Text;
            string str00701;
            str00701 = cb00701Text.Text;
            if (str00701.Length >= 80)
            {
                string first;
                string end;
                int i = str00701.Length - 80;
                first = str00701.Substring(0, 80);
                end = str00701.Substring(80, i);
                str00701 = first + Environment.NewLine + end;
                cb00701Text.Text = str00701;
            }
            
                

            
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Stage dlg = new Stage();
            dlg.Show();
        }

        private void button6_Click(object sender, EventArgs e)
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
