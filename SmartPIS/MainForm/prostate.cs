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
    public partial class prostate : DevExpress.XtraEditors.XtraForm
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public static MySqlConnection Myconn;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        public string HMTP = "prs";
        public string PTNO;
        public string block1;
        public string block2;
        public string totalAdd;

        public prostate()
        {
            InitializeComponent();
        }

        private void button5_Click(object sender, EventArgs e)
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

        private void comboBox25_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb00603.SelectedItem.ToString() == "present")
            {
                cb00604.Enabled = true;
            }
            else
            {
                cb00604.Enabled = false;
                cb00604.Text = " ";
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void prostate_Load(object sender, EventArgs e)
        {
            try
            {
                CoreLibrary core = new CoreLibrary();
                core.InitGridStyle(dataGridView3);

                cb00101.Items.Add(" ");
                
                cb00201.Items.Add(" ");
                cb00202.Items.Add(" ");
                cb00301.Items.Add(" ");
                cb00601.Items.Add(" ");
                cb00602.Items.Add(" ");
                cb00603.Items.Add(" ");
                cb00604.Items.Add(" ");
                
                cb00701.Items.Add(" ");
                
                cb00801.Items.Add(" ");


                cb00901.Items.Add(" ");
                
                cb01001.Items.Add(" ");
                cb01101.Items.Add(" ");
                cb01102.Items.Add(" ");
                cb01201.Items.Add(" ");
                cb01202.Items.Add(" ");
                cb01203.Items.Add(" ");
                cb01204.Items.Add(" ");
               


                string strSQL = Ini.strDB;

                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();


                Insertcombo00101();
                Insertcombo00201();
                Insertcombo00202();

                Insertcombo00301();
                
                Insertcombo00601();
                Insertcombo00602();
                Insertcombo00603();
                Insertcombo00604();
                
                Insertcombo00701();
                
                Insertcombo00801();
                
                Insertcombo00901();

                Insertcombo01001();

                Insertcombo01101();
                Insertcombo01102();


                Insertcombo01201();
                Insertcombo01202();
                Insertcombo01203();
                Insertcombo01204();



                String sql = "select TIT1, TIT2, n0101, n0201,n0202, n0301, n0401,n0402,n0403,n0404,n0405,n0406, n0501, n0601,n0602, n0603, n0604, n0701, n0702, n0801, n0802, n0901,n0902,n1001,n1101,n1102,n1103,n1201,n1202,n1203,n1204,ECTX,NOTE,ATX1,ATX2 from PISPRS001 where PTNO ='[PTNO]'";

                sql = sql.Replace("[PTNO]", PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();



                while (dr.Read())
                {

                    tbt00001.Text = dr[0].ToString().Replace("^", "'");
                    tbt00002.Text = dr[1].ToString().Replace("^", "'");
                    
                    cb00101.SelectedIndex = selectData00101(dr[2].ToString());
                    
                    cb00201.SelectedIndex = selectData00201(dr[3].ToString());
                    cb00202.SelectedIndex = selectData00202(dr[4].ToString());

                    cb00301.SelectedIndex = selectData00301(dr[5].ToString());

                    tb00401.Text = dr[6].ToString().Replace("^", "'");
                    tb00402.Text = dr[7].ToString().Replace("^", "'");
                    tb00403.Text = dr[8].ToString().Replace("^", "'");
                    tb00404.Text = dr[9].ToString().Replace("^", "'");
                    tb00405.Text = dr[10].ToString().Replace("^", "'");
                    tb00406.Text = dr[11].ToString().Replace("^", "'");
                                   
                    tb00501.Text = dr[12].ToString().Replace("^", "'");

                    cb00601.SelectedIndex = selectData00601(dr[13].ToString());
                    cb00602.SelectedIndex = selectData00602(dr[14].ToString());
                    cb00603.SelectedIndex = selectData00603(dr[15].ToString());
                    cb00604.SelectedIndex = selectData00604(dr[16].ToString());


                    cb00701.SelectedIndex = selectData00701(dr[17].ToString());
                    tb00702.Text = dr[18].ToString().Replace("^", "'");

                    cb00801.SelectedIndex = selectData00801(dr[19].ToString());
                    tb00802.Text = dr[20].ToString().Replace("^", "'");

                    cb00901.SelectedIndex = selectData00901(dr[21].ToString());
                    tb00902.Text = dr[22].ToString().Replace("^", "'");

                    cb01001.SelectedIndex = selectData01001(dr[23].ToString());
                    

                    cb01101.SelectedIndex = selectData01101(dr[24].ToString());
                    cb01102.SelectedIndex = selectData01102(dr[25].ToString());
                    tb01103.Text = dr[26].ToString().Replace("^", "'");

                    cb01201.SelectedIndex = selectData01201(dr[27].ToString());
                    cb01202.SelectedIndex = selectData01202(dr[28].ToString());
                    cb01203.SelectedIndex = selectData01203(dr[29].ToString());
                    cb01204.SelectedIndex = selectData01204(dr[30].ToString());



                    //161005

                    tbECTX.Text = dr[31].ToString().Replace("^", "'");
                    tbNOTE.Text = dr[32].ToString().Replace("^", "'");
                    tbATX1.Text = dr[33].ToString().Replace("^", "'");
                    tbATX2.Text = dr[34].ToString().Replace("^", "'");
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

            string sql = "select ABLK, NBLK from PISDIG001 where PTNO ='[PTNO]' and OGTP ='PRS'";
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

            string sql = "select A101,A102,A103,A201,A202,A203,A301,A302,A303,A401,A402,A403,A501,A502,A503,A601,A602,A603,A701,A702,A703,A801,A802,A803,A901,A902,A903 from PISPRS001 where PTNO ='[PTNO]'";
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

        private int selectData00101(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '00101'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '00201'";

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

        private int selectData00202(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '00202'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '00301'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '00601'";

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
        private int selectData00602(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '00602'";

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
        private int selectData00603(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '00603'";

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
        private int selectData00604(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '00604'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '00701'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '00801'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '00901'";

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

        private int selectData01001(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '01001'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '01101'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '01102'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '01201'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '01202'";

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

        private int selectData01203(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '01203'";

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

        private int selectData01204(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'PRS'and  SQNO = '01204'";

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

        private void Insertcombo00202()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00202";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00202.Items.Add(dr.GetString(0));
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

        private void Insertcombo00602()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00602";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00602.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00603()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00603";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00603.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00604()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00604";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00604.Items.Add(dr.GetString(0));
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

        private void Insertcombo01001()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01001";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01001.Items.Add(dr.GetString(0));
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
        private void Insertcombo01203()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01203";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01203.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }
        private void Insertcombo01204()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01204";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01204.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void button6_Click(object sender, EventArgs e)
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

        private void button9_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = "select * from PISPRS001 where PTNO = '[PTNO]'";
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
                selectPRS();
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
            tbt00001.Text = "radical retropubic prostatectomy:";
            tbt00002.Text = "Adenocarcinoma";


            cb00101.Text = " ";
            
            cb00201.Text = " ";
            cb00202.Text = " ";

            cb00301.Text = " ";

            tb00401.Text = "";
            tb00402.Text = "";
            tb00403.Text = "";
            tb00404.Text = "";
            tb00405.Text = "";
            tb00406.Text = "";
                        
            tb00501.Text = "";

            cb00601.Text = " ";
            cb00602.Text = " ";
            cb00603.Text = " ";
            cb00604.Text = " ";

            cb00701.Text = " ";
            tb00702.Text = "";

            cb00801.Text = " ";
            tb00802.Text = "";

            cb00901.Text = " ";
            tb00902.Text = "";

            cb01001.Text = " ";
            
            cb01101.Text = " ";
            cb01102.Text = " ";
            tb01103.Text = "X";

            cb01201.Text = " ";
            cb01202.Text = " ";
            cb01203.Text = " ";
            cb01204.Text = " ";

           

            tbECTX.Text = "";
            tbNOTE.Text = "";

            tbblock01.Text = "";
            tbblock03.Text = "";
            tbATX1.Text = "";
            tbATX2.Text = "";
            dataGridView3.Rows.Clear();
            tbt00001.Select();
        }

        private void selectPRS()
        {


            String sql = "select TIT1, TIT2, n0101, n0201,n0202, n0301, n0401,n0402,n0403,n0404,n0405,n0406, n0501, n0601,n0602, n0603, n0604, n0701, n0702, n0801, n0802, n0901,n0902,n1001,n1101,n1102,n1103,n1201,n1202,n1203,n1204,ECTX,NOTE,ATX1,ATX2 from PISPRS001 where PTNO ='[PTNO]'";

            sql = sql.Replace("[PTNO]", PTNO);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read())
            {

                tbt00001.Text = dr[0].ToString().Replace("^", "'");
                tbt00002.Text = dr[1].ToString().Replace("^", "'");

                cb00101.SelectedIndex = selectData00101(dr[2].ToString());

                cb00201.SelectedIndex = selectData00201(dr[3].ToString());
                cb00202.SelectedIndex = selectData00202(dr[4].ToString());

                cb00301.SelectedIndex = selectData00301(dr[5].ToString());

                tb00401.Text = dr[6].ToString().Replace("^", "'");
                tb00402.Text = dr[7].ToString().Replace("^", "'");
                tb00403.Text = dr[8].ToString().Replace("^", "'");
                tb00404.Text = dr[9].ToString().Replace("^", "'");
                tb00405.Text = dr[10].ToString().Replace("^", "'");
                tb00406.Text = dr[11].ToString().Replace("^", "'");

                tb00501.Text = dr[12].ToString().Replace("^", "'");

                cb00601.SelectedIndex = selectData00601(dr[13].ToString());
                cb00602.SelectedIndex = selectData00602(dr[14].ToString());
                cb00603.SelectedIndex = selectData00603(dr[15].ToString());
                cb00604.SelectedIndex = selectData00604(dr[16].ToString());


                cb00701.SelectedIndex = selectData00701(dr[17].ToString());
                tb00702.Text = dr[18].ToString().Replace("^", "'");

                cb00801.SelectedIndex = selectData00801(dr[19].ToString());
                tb00802.Text = dr[20].ToString().Replace("^", "'");

                cb00901.SelectedIndex = selectData00901(dr[21].ToString());
                tb00902.Text = dr[22].ToString().Replace("^", "'");

                cb01001.SelectedIndex = selectData01001(dr[23].ToString());


                cb01101.SelectedIndex = selectData01101(dr[24].ToString());
                cb01102.SelectedIndex = selectData01102(dr[25].ToString());
                tb01103.Text = dr[26].ToString().Replace("^", "'");

                cb01201.SelectedIndex = selectData01201(dr[27].ToString());
                cb01202.SelectedIndex = selectData01202(dr[28].ToString());
                cb01203.SelectedIndex = selectData01203(dr[29].ToString());
                cb01204.SelectedIndex = selectData01204(dr[30].ToString());



                //161005

                tbECTX.Text = dr[31].ToString().Replace("^", "'");
                tbNOTE.Text = dr[32].ToString().Replace("^", "'");
                tbATX1.Text = dr[33].ToString().Replace("^", "'");
                tbATX2.Text = dr[34].ToString().Replace("^", "'");
                selectAdd();
            }
            dr.Close();
        }

        private void UpdateDB()
        {

            string Titlestr0001 = tbt00001.Text;
            Titlestr0001 = Titlestr0001.Replace("'", "^");

            string Titlestr0002 = tbt00002.Text;
            Titlestr0002 = Titlestr0002.Replace("'", "^");



            string str0101 = cb00101.Text;
            str0101 = str0101.Replace("'", "^");

            string str0201 = cb00201.Text;
            str0201 = str0201.Replace("'", "^");

            string str0202 = cb00202.Text;
            str0202 = str0202.Replace("'", "^");



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

            string str0405 = tb00405.Text;
            str0405 = str0405.Replace("'", "^");

            string str0406 = tb00406.Text;
            str0406 = str0406.Replace("'", "^");


            string str0501 = tb00501.Text;
            str0501 = str0501.Replace("'", "^");

            
            string str0601 = cb00601.Text;
            str0601 = str0601.Replace("'", "^");

            string str0602 = cb00602.Text;
            str0602 = str0602.Replace("'", "^");

            string str0603 = cb00603.Text;
            str0603 = str0603.Replace("'", "^");

            string str0604 = cb00604.Text;
            str0604 = str0604.Replace("'", "^");

            string str0701 = cb00701.Text;
            str0701 = str0701.Replace("'", "^");

            string str0702 = tb00702.Text;
            str0702 = str0702.Replace("'", "^");


            string str0801 = cb00801.Text;
            str0801 = str0801.Replace("'", "^");

            string str0802 = tb00802.Text;
            str0802 = str0802.Replace("'", "^");


            string str0901 = cb00901.Text;
            str0901 = str0901.Replace("'", "^");

            string str0902 = tb00902.Text;
            str0902 = str0902.Replace("'", "^");





            string str1001 = cb01001.Text;
            str1001 = str1001.Replace("'", "^");

          

            string str1101 = cb01101.Text;
            str1101 = str1101.Replace("'", "^");

            string str1102 = cb01102.Text;
            str1102 = str1102.Replace("'", "^");

            string str1103 = tb01103.Text;
            str1103 = str1103.Replace("'", "^");

            string str1201 = cb01201.Text;
            str1201 = str1201.Replace("'", "^");

            string str1202 = cb01202.Text;
            str1202 = str1202.Replace("'", "^");
            
            string str1203 = cb01203.Text;
            str1203 = str1203.Replace("'", "^");

            string str1204 = cb01204.Text;
            str1204 = str1204.Replace("'", "^");
           

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

            string sql = "Update pisPRS001 SET SYDT = '[SYDT]', UPDT = '[UPDT]', UPID = '[UPID]', OGTP = '[OGTP]', DITP='[DITP]', TRYN ='[TRYN]', TIT1 = '[TIT1]',TIT2= '[TIT2]', n0101 = '[n0101]', n0201 = '[n0201]', n0202 = '[n0202]', n0301='[n0301]', n0401 = '[n0401]', n0402 = '[n0402]', n0403 = '[n0403]', n0404 = '[n0404]', n0405 = '[n0405]', n0406 = '[n0406]', n0501 = '[n0501]',  n0601='[n0601]',n0602='[n0602]',n0603='[n0603]',n0604='[n0604]', n0701='[n0701]', n0702='[n0702]', n0801='[n0801]', n0802='[n0802]',  n0901='[n0901]', n0902='[n0902]',n1001='[n1001]',n1101='[n1101]',n1102='[n1102]',n1103='[n1103]',n1201='[n1201]',n1202='[n1202]',n1203='[n1203]',n1204='[n1204]',ECTX='[ECTX]', NOTE='[NOTE]' , ATX1='[ATX1]',ATX2 ='[ATX2]' where PTNO ='[PTNO]'";
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



            sql = sql.Replace("[n0101]", str0101);
           
            sql = sql.Replace("[n0201]", str0201);
            sql = sql.Replace("[n0202]", str0202);
            
            sql = sql.Replace("[n0301]", str0301);
            
            sql = sql.Replace("[n0401]", str0401);
            sql = sql.Replace("[n0402]", str0402);
            sql = sql.Replace("[n0403]", str0403);
            sql = sql.Replace("[n0404]", str0404);
            sql = sql.Replace("[n0405]", str0405);
            sql = sql.Replace("[n0406]", str0406);

            sql = sql.Replace("[n0501]", str0501);
            
            sql = sql.Replace("[n0601]", str0601);
            sql = sql.Replace("[n0602]", str0602);
            sql = sql.Replace("[n0603]", str0603);
            sql = sql.Replace("[n0604]", str0604);

            sql = sql.Replace("[n0701]", str0701);
            sql = sql.Replace("[n0702]", str0702);




            sql = sql.Replace("[n0801]", str0801);
            sql = sql.Replace("[n0802]", str0802);

            sql = sql.Replace("[n0901]", str0901);
            sql = sql.Replace("[n0902]", str0902);
            
            sql = sql.Replace("[n1001]", str1001);
            

            sql = sql.Replace("[n1101]", str1101);
            sql = sql.Replace("[n1102]", str1102);
            sql = sql.Replace("[n1103]", str1103);

            sql = sql.Replace("[n1201]", str1201);
            sql = sql.Replace("[n1202]", str1202);
            sql = sql.Replace("[n1203]", str1203);
            sql = sql.Replace("[n1204]", str1204);


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
            string Titlestr0001 = tbt00001.Text;
            Titlestr0001 = Titlestr0001.Replace("'", "^");

            string Titlestr0002 = tbt00002.Text;
            Titlestr0002 = Titlestr0002.Replace("'", "^");



            string str0101 = cb00101.Text;
            str0101 = str0101.Replace("'", "^");

            string str0201 = cb00201.Text;
            str0201 = str0201.Replace("'", "^");

            string str0202 = cb00202.Text;
            str0202 = str0202.Replace("'", "^");



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

            string str0405 = tb00405.Text;
            str0405 = str0405.Replace("'", "^");

            string str0406 = tb00406.Text;
            str0406 = str0406.Replace("'", "^");


            string str0501 = tb00501.Text;
            str0501 = str0501.Replace("'", "^");


            string str0601 = cb00601.Text;
            str0601 = str0601.Replace("'", "^");

            string str0602 = cb00602.Text;
            str0602 = str0602.Replace("'", "^");

            string str0603 = cb00603.Text;
            str0603 = str0603.Replace("'", "^");

            string str0604 = cb00604.Text;
            str0604 = str0604.Replace("'", "^");

            string str0701 = cb00701.Text;
            str0701 = str0701.Replace("'", "^");

            string str0702 = tb00702.Text;
            str0702 = str0702.Replace("'", "^");


            string str0801 = cb00801.Text;
            str0801 = str0801.Replace("'", "^");

            string str0802 = tb00802.Text;
            str0802 = str0802.Replace("'", "^");


            string str0901 = cb00901.Text;
            str0901 = str0901.Replace("'", "^");

            string str0902 = tb00902.Text;
            str0902 = str0902.Replace("'", "^");





            string str1001 = cb01001.Text;
            str1001 = str1001.Replace("'", "^");



            string str1101 = cb01101.Text;
            str1101 = str1101.Replace("'", "^");

            string str1102 = cb01102.Text;
            str1102 = str1102.Replace("'", "^");

            string str1103 = tb01103.Text;
            str1103 = str1103.Replace("'", "^");

            string str1201 = cb01201.Text;
            str1201 = str1201.Replace("'", "^");

            string str1202 = cb01202.Text;
            str1202 = str1202.Replace("'", "^");

            string str1203 = cb01203.Text;
            str1203 = str1203.Replace("'", "^");

            string str1204 = cb01204.Text;
            str1204 = str1204.Replace("'", "^");


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

            string sql = "INSERT INTO pisPRS001 ( SYDT, UPDT, UPID, PTNO, OGTP, DITP, TRYN, TIT1, TIT2, n0101,n0201,n0202, n0301,n0401, n0402, n0403, n0404, n0405, n0406, n0501, n0601, n0602, n0603, n0604, n0701, n0702, n0801, n0802,n0901, n0902, n1001,n1101,n1102, n1103,n1201,n1202,n1203,n1204, ECTX, NOTE,ATX1,ATX2) VALUES ( '[SYDT]', '[UPDT]', '[UPID]', '[PTNO]', '[OGTP]', '[DITP]', '[TRYN]','[TIT1]', '[TIT2]', '[n0101]', '[n0201]', '[n0202]','[n0301]', '[n0401]', '[n0402]', '[n0403]', '[n0404]', '[n0405]', '[n0406]', '[n0501]','[n0601]','[n0602]','[n0603]','[n0604]', '[n0701]', '[n0702]','[n0801]','[n0802]', '[n0901]','[n0902]', '[n1001]','[n1101]','[n1102]','[n1103]','[n1201]','[n1202]','[n1203]','[n1204]', '[ECTX]','[NOTE]','[ATX1]','[ATX2]')";
            sql = sql.Replace("[SYDT]", DateTime.Now.ToString("yyyyMMdd"));
            sql = sql.Replace("[UPDT]", DateTime.Now.ToString("yyyyMMdd"));
            sql = sql.Replace("[UPID]", "");
            sql = sql.Replace("[PTNO]", PTNO);
            sql = sql.Replace("[OGTP]", HMTP);
            sql = sql.Replace("[DITP]", "");
            sql = sql.Replace("[TRYN]", "N");

            sql = sql.Replace("[TIT1]", Titlestr0001);
            sql = sql.Replace("[TIT2]", Titlestr0002);



            sql = sql.Replace("[n0101]", str0101);

            sql = sql.Replace("[n0201]", str0201);
            sql = sql.Replace("[n0202]", str0202);

            sql = sql.Replace("[n0301]", str0301);

            sql = sql.Replace("[n0401]", str0401);
            sql = sql.Replace("[n0402]", str0402);
            sql = sql.Replace("[n0403]", str0403);
            sql = sql.Replace("[n0404]", str0404);
            sql = sql.Replace("[n0405]", str0405);
            sql = sql.Replace("[n0406]", str0406);

            sql = sql.Replace("[n0501]", str0501);

            sql = sql.Replace("[n0601]", str0601);
            sql = sql.Replace("[n0602]", str0602);
            sql = sql.Replace("[n0603]", str0603);
            sql = sql.Replace("[n0604]", str0604);

            sql = sql.Replace("[n0701]", str0701);
            sql = sql.Replace("[n0702]", str0702);




            sql = sql.Replace("[n0801]", str0801);
            sql = sql.Replace("[n0802]", str0802);

            sql = sql.Replace("[n0901]", str0901);
            sql = sql.Replace("[n0902]", str0902);

            sql = sql.Replace("[n1001]", str1001);


            sql = sql.Replace("[n1101]", str1101);
            sql = sql.Replace("[n1102]", str1102);
            sql = sql.Replace("[n1103]", str1103);

            sql = sql.Replace("[n1201]", str1201);
            sql = sql.Replace("[n1202]", str1202);
            sql = sql.Replace("[n1203]", str1203);
            sql = sql.Replace("[n1204]", str1204);


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

            string str00001 = Environment.NewLine + " " + lbt00002.Text + tbt00001.Text;
            str00001 = str00001.Replace("'", "^");
            string str00002 = Environment.NewLine + "  " + tbt00002.Text;
            str00002 = str00002.Replace("'", "^");
            if (tbt00001.Text == "")
            {
                str00001 = "";
            }
            if (tbt00002.Text == "")
            {
                str00002 = "";
            }

            string str000 = str00001 + str00002;
            str000 = str000.Replace("'", "^");
          
            
            string str001 =  Environment.NewLine + " " + lb00101.Text + cb00101.Text;
                       
            if (cb00101.Text == " ")
            {
                str001 = "";
            }
            str001 = str001.Replace("'", "^");
            string str00201 = Environment.NewLine + "      " + lb00202.Text + cb00201.Text;
            if (cb00201.Text == " ")
            {
                str00201 = "";
            }

            string str00202 = Environment.NewLine + "      " + lb00203.Text + cb00202.Text;
            if (cb00201.Text == " ")
            {
                str00202 = "";
            }
            string str002 =  Environment.NewLine + " " + lb00201.Text +str00201 + str00202;
            str002 = str002.Replace("'", "^");
            if (cb00201.Text == " " && cb00202.Text==" " )
            {
                str002 = "";
            }
            
            string str003 =Environment.NewLine + " " + lb00301.Text + cb00301.Text;

            if (cb00301.Text == " ")
            {
                str003 = "";
            }


            string str00401 = tb00401.Text + lb00403.Text;
            string str00402 = tb00402.Text + lb00404.Text;
            string str00403 = tb00403.Text;
            if (tb00401.Text == "")
            {
                str00401 = "";
            }
            if (tb00402.Text == "")
            {
                str00402 = "";
            }
            if (tb00403.Text == "")
            {
                str00402 = tb00402.Text;
                str00403 = "";
            }
            if (tb00402.Text == "" && tb00403.Text == "")
            {
                str00401 = tb00401.Text;
            }
            string str00404 = tb00404.Text + lb00407.Text;
            string str00405 = tb00405.Text + lb00408.Text;
            string str00406 = tb00406.Text;
            if (tb00404.Text == "")
            {
                str00404 = "";
            }
            if (tb00405.Text == "")
            {
                str00405 = "";
            }
            if (tb00406.Text == "")
            {
                str00405 = tb00405.Text;
                str00406 = "";
            }
            if (tb00405.Text == "" && tb00406.Text == "")
            {
                str00404 = tb00404.Text;
            }
            
            string str004 = Environment.NewLine + " " + lb00401.Text +" " + lb00402.Text + str00401 + str00402 + str00403 + lb00405.Text + Environment.NewLine + "                           " + lb00406.Text + str00404 + str00405 + str00406 + lb00409.Text;
            str003 = str003.Replace("'", "^");
            if (tb00401.Text == "" && tb00402.Text =="" && tb00403.Text =="")
            {
                str004 = Environment.NewLine + " " + lb00401.Text + " " +  lb00406.Text + str00404 + str00405 + str00406 + lb00409.Text;
            }

            if (tb00404.Text == "" && tb00405.Text == "" && tb00406.Text == "")
            {
                str004 =Environment.NewLine + " " + lb00401.Text + " " + lb00402.Text + str00401 + str00402 + str00403 + lb00405.Text;
            }

            if (tb00401.Text == "" && tb00402.Text == "" && tb00403.Text == "" && tb00404.Text == "" && tb00405.Text == "" && tb00406.Text == "")
            {
                str004 = "";
            }
                        
            string str005 =  Environment.NewLine + " " + lb00501.Text + tb00501.Text + lb00502.Text;
            str005 = str005.Replace("'", "^");

            if ( tb00501.Text == "")
            {
                str005 = "";
            }

            string str00601 = Environment.NewLine + "      " + lb00602.Text + cb00601.Text;
            string str00602 = Environment.NewLine + "      " + lb00603.Text + cb00602.Text;
            string str00603 = Environment.NewLine + "      " + lb00603.Text + cb00603.Text;
            string str00604 = Environment.NewLine + "      " + cb00604.Text;
            if (cb00601.Text == " ")
            {
                str00601 = "";
            }
            if (cb00602.Text == " ")
            {
                str00602 = "";
            }
            if (cb00603.Text == " ")
            {
                str00603 = "";
            }
            if (cb00604.Text == " ")
            {
                str00604 = "";
            }
            string str006 =  Environment.NewLine + " " + lb00601.Text + str00601 + str00602 + str00603 + str00604;
            str006 = str006.Replace("'", "^");

            if (cb00601.Text == " " && cb00602.Text == " " && cb00603.Text == " " && cb00604.Text == " ")
            {
                str006 = "";
            }
            //
            string str00701 = cb00701.Text;
            if (cb00701.Text == " ")
            {
                str00701 = "";
            }
            string str00702 = " " + tb00702.Text;
            if (tb00702.Text == "")
            {
                str00702 = "";
            }
            string str007 =  Environment.NewLine + " " + lb00701.Text + str00701 + str00702;
            str007 = str007.Replace("'", "^");
            if (cb00701.Text == " " && tb00702.Text =="")
            {
               str007 = "";
            }

            string str00801 = cb00801.Text;
            if (cb00801.Text == " ")
            {
                str00801 = "";
            }
            string str00802 = " " + tb00802.Text;
            if (tb00802.Text == "")
            {
                str00802 = "";
            }
            string str008 =  Environment.NewLine + " " + lb00801.Text + str00801 + str00802;
            str008 = str008.Replace("'", "^");
            if (cb00801.Text == " " && tb00802.Text == "")
            {
                str008 = "";
            }


            string str00901 = cb00901.Text;
            if (cb00901.Text == " ")
            {
                str00901 = "";
            }
            string str00902 = " " + lb00902.Text + " " + tb00902.Text + " " + lb00903.Text;
            if (tb00902.Text == "")
            {
                str00902 = "";
            }
            string str009=  Environment.NewLine + " " + lb00901.Text + str00901 + str00902;
            str009 = str009.Replace("'", "^");
            if (cb00901.Text == " " && tb00902.Text == "")
            {
                str009 = "";
            }

            string str010 =  Environment.NewLine + " " + lb01001.Text + cb01001.Text;
            str010 = str010.Replace("'", "^");
            if (cb01001.Text == " ")
            {
                str010 = "";
            }

            string str01101 = lb01102.Text + cb01101.Text;
            string str01102 = " " +lb01103.Text + cb01102.Text;
            string str01103 = " " + lb01104.Text + tb01103.Text;
            if (cb01101.Text == " ")
            {
                str01101 = "";
            }
            if (cb01102.Text == " ")
            {
                str01102 = "";
            }
            if (tb01103.Text == "")
            {
                str01103 = "";
            }
            string str011 =  Environment.NewLine + " " + lb01101.Text + str01101 + str01102 + str01103;
            str011 = str011.Replace("'", "^");

            if (cb01101.Text == " " && cb01102.Text == " " && tb01103.Text =="")
            {
                str011 = "";
            }

            string str01201 = Environment.NewLine + "      " + lb01202.Text + cb01201.Text;
            if (cb01201.Text == " ")
            {
                str01201 = "";
            }
            string str01202 = Environment.NewLine + "      " + lb01203.Text + cb01202.Text;
            if (cb01202.Text == " ")
            {
                str01202 = "";
            }
            string str01203 = Environment.NewLine + "      " + lb01204.Text + cb01203.Text;
            if (cb01203.Text == " ")
            {
                str01203 = "";
            }
            string str01204 = Environment.NewLine + "      " + lb01205.Text + cb01204.Text;
            if (cb01204.Text == " ")
            {
                str01204 = "";
            }
            string str012 = Environment.NewLine + " " + lb01201.Text + str01201 + str01202 + str01203 + str01204;
            str012 = str012.Replace("'", "^");
            if (cb01201.Text == " " && cb01202.Text == " " && cb01203.Text == " " && cb01204.Text == " ")
            {
                str012 = "";
            }

           
            string strTBECTX = tbECTX.Text.Replace("\r\n", "\r\n ");
            string strECTX = Environment.NewLine + " " + strTBECTX;
            strECTX = strECTX.Replace("'", "^");
            string strTBNOTE = "     " + tbNOTE.Text.Replace("\r\n", "\r\n     ");
            string strNOTE = Environment.NewLine + " " + lbNOTE.Text + Environment.NewLine + strTBNOTE;
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

                totalAdd = ADD[1] + ADD[2] +  ADD[3] +  ADD[4] + ADD[5] +  ADD[6] + ADD[7] + ADD[8];
                totalAdd = totalAdd.Replace("'", "^");
            }
            string DITX = lbt00001.Text + str000 + str001 + str002 + str003 + str004 + str005 + str006 + str007 + str008 + str009 + str010 + str011 + str012 + strECTX + strNOTE + strATX1 +  totalAdd + strATX2;
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

                string sql = String.Format("Update PISPRS001 set {0}='{1}', {2} = '{3}',{4}='{5}' where PTNO = '{6}'", ADD1, str1, ADD2, str2, ADD3, str3, PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }


        }

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select DITX from PISDIG001 where PTNO ='[PTNO]' and OGTP ='PRS'";
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
                    string sql = "delete from pisPRS001 where ptno = '[PTNO]'";
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

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
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

        private void tb00405_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00406_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00501_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button5_Click_1(object sender, EventArgs e)
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

        private void button4_Click(object sender, EventArgs e)
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
