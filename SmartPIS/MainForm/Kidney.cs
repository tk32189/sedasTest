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
    public partial class Kidney : DevExpress.XtraEditors.XtraForm
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public static MySqlConnection Myconn;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        public string HMTP = "kdn";
        public string PTNO;
        public string block1;
        public string block2;
        public string totalAdd;

        public Kidney()
        {
            InitializeComponent();
        }

        private void comboBox27_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb00401.SelectedItem.ToString() == "Present")
            {
                tb00402.Enabled = true;
            }
            else
            {
                tb00402.Enabled = false;
                tb00402.Text = "";
            }
            

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb00501.SelectedItem.ToString() == "Present")
            {
                tb00502.Enabled = true;
            }
            else
            {
                tb00502.Enabled = false;
                tb00502.Text = "";
            }
            
        }

        private void comboBox31_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb00701.SelectedItem.ToString() == "Tumor extension into")
            {
                cb00702.Enabled = true;
                tb00704.Enabled = true;
                tb00703.Enabled = false;
                tb00703.Text = "";
            }
            else
            {
                cb00702.Enabled = false;
                cb00702.Text = " ";
                tb00704.Text = "";
                tb00704.Enabled = false;
                tb00703.Enabled = true;
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel40_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel43_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string[] strData = null;
            dataGridView3.Rows.Clear();
            tbATX1.Text = "#. Immunohistochemistry";
            tbATX2.Text = "#. Histochemistry\r\nVanGieson elastic fiber\r\nMucicarmine\r\nMasson Trichrome";
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
            }
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

        private void Kidney_Load(object sender, EventArgs e)
        {
            
            try
            {
                CoreLibrary core = new CoreLibrary();
                core.InitGridStyle(dataGridView3);

                cbt00001.Items.Add(" ");
                cbt00002.Items.Add(" ");
                
                cb00101.Items.Add(" ");
                cb00301.Items.Add(" ");
                cb00401.Items.Add(" ");
                cb00501.Items.Add(" ");
                cb00601.Items.Add(" ");
                cb00701.Items.Add(" ");
                cb00702.Items.Add(" ");
                cb00801.Items.Add(" ");
                cb00802.Items.Add(" ");
                cb00804.Items.Add(" ");
                cb00806.Items.Add(" ");
                cb00808.Items.Add(" ");
                cb00810.Items.Add(" ");
                cb00812.Items.Add(" ");
                cb00901.Items.Add(" ");
                

                string strSQL = Ini.strDB;

                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();

                Insertcombo00001();
                Insertcombo00002();
                
                Insertcombo00101();
                Insertcombo00301();
                Insertcombo00401();
                Insertcombo00501();
                Insertcombo00601();
                Insertcombo00701();
                Insertcombo00702();
                Insertcombo00801();
                Insertcombo00802();
                Insertcombo00804();
                Insertcombo00806();
                Insertcombo00808();
                Insertcombo00810();
                Insertcombo00812();       
                
                Insertcombo00901();
               

                String sql = "select TIT1, TIT2, TIT3, TIT4, n0101, n0102, n0201,n0202,n0203, n0301, n0401, n0402, n0501,n0502, n0601,n0701, n0702, n0801, n0802, n0803, n0804, n0805, n0806,n0807,n0808,n0809,n0810,n0811,n0812,n0813,n0901,n0902,n1001,ECTX,NOTE,ATX1,ATX2,n0703,n0704 from PISKDN001 where PTNO ='[PTNO]'";

                sql = sql.Replace("[PTNO]", PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();



                while (dr.Read())
                {
                    
                    cbt00001.SelectedIndex = selectData00001(dr[0].ToString());
                    cbt00002.SelectedIndex = selectData00002(dr[1].ToString());
                    tbt00003.Text = dr[2].ToString().Replace("^", "'");
                    tbt00004.Text = dr[3].ToString().Replace("^", "'");

                    cb00101.SelectedIndex = selectData00101(dr[4].ToString());
                    tb00102.Text = dr[5].ToString().Replace("^", "'");

                    tb00201.Text = dr[6].ToString().Replace("^", "'");
                    tb00202.Text = dr[7].ToString().Replace("^", "'");
                    tb00203.Text = dr[8].ToString().Replace("^", "'");

                    cb00301.SelectedIndex = selectData00301(dr[9].ToString());

                    cb00401.SelectedIndex = selectData00401(dr[10].ToString());
                    tb00402.Text = dr[11].ToString().Replace("^", "'");

                    cb00501.SelectedIndex = selectData00501(dr[12].ToString());
                    tb00502.Text = dr[13].ToString().Replace("^", "'");

                    cb00601.SelectedIndex = selectData00601(dr[14].ToString());                    

                    cb00701.SelectedIndex = selectData00701(dr[15].ToString());
                    cb00702.SelectedIndex = selectData00702(dr[16].ToString());

                    cb00801.SelectedIndex = selectData00801(dr[17].ToString());
                    cb00802.SelectedIndex = selectData00802(dr[18].ToString());
                    tb00803.Text = dr[19].ToString().Replace("^", "'");
                    cb00804.SelectedIndex = selectData00804(dr[20].ToString());
                    tb00805.Text = dr[21].ToString().Replace("^", "'");
                    cb00806.SelectedIndex = selectData00806(dr[22].ToString());
                    tb00807.Text = dr[23].ToString().Replace("^", "'");
                    cb00808.SelectedIndex = selectData00808(dr[24].ToString());
                    tb00809.Text = dr[25].ToString().Replace("^", "'");
                    cb00810.SelectedIndex = selectData00810(dr[26].ToString());
                    tb00811.Text = dr[27].ToString().Replace("^", "'");
                    cb00812.SelectedIndex = selectData00812(dr[28].ToString());
                    tb00813.Text = dr[29].ToString().Replace("^", "'");

                    cb00901.SelectedIndex = selectData00901(dr[30].ToString());
                    tb00902.Text = dr[31].ToString().Replace("^", "'");

                    tb01001.Text = dr[32].ToString().Replace("^", "'");

                    tbECTX.Text = dr[33].ToString().Replace("^", "'");
                    tbNOTE.Text = dr[34].ToString().Replace("^", "'");
                    tbATX1.Text = dr[35].ToString().Replace("^", "'");
                    tbATX2.Text = dr[36].ToString().Replace("^", "'");
                    tb00703.Text = dr[37].ToString().Replace("^", "'");
                    tb00704.Text = dr[38].ToString().Replace("^", "'");
                    selectAdd();
                }
                dr.Close();

                Selectblock();
            }
            catch (System.Exception ex)
            {
            }
             
        }

        private int selectData00001(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00001'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00002'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00101'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00301'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00401'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00501'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00601'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00701'";

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
        private int selectData00702(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00702'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00801'";

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
        private int selectData00802(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00802'";

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
        private int selectData00804(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00803'";

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
        private int selectData00806(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00804'";

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
        private int selectData00808(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00805'";

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
        private int selectData00810(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00806'";

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

        private int selectData00812(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00807'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'KDN'and  SQNO = '00901'";

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
        private void Insertcombo00702()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00702";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00702.Items.Add(dr.GetString(0));
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
        private void Insertcombo00802()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00802";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00802.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }
        private void Insertcombo00804()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00803";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00804.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }
        private void Insertcombo00806()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00804";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00806.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }
        private void Insertcombo00808()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00805";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00808.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00810()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00806";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00810.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }
        private void Insertcombo00812()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00807";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00812.Items.Add(dr.GetString(0));
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
        private void selectAdd()
        {

            string sql = "select A101,A102,A103,A201,A202,A203,A301,A302,A303,A401,A402,A403,A501,A502,A503,A601,A602,A603,A701,A702,A703,A801,A802,A803,A901,A902,A903 from PISKDN001 where PTNO ='[PTNO]'";
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

        private void Selectblock()
        {

            string sql = "select ABLK, NBLK from PISDIG001 where PTNO ='[PTNO]' and OGTP ='KDN'";
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

        private void button8_Click(object sender, EventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("정보를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sql = "delete from pisKDN001 where ptno = '[PTNO]'";
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

        private void reset()
        {
            cbt00001.Text = " ";
            cbt00002.Text = " ";
            tbt00003.Text = "nephrectomy :";
            tbt00004.Text = "Renal cancer";

            cb00101.Text = " ";
            tb00102.Text = "";
            tb00201.Text = "";
            tb00202.Text = "";
            tb00203.Text = "";
            cb00301.Text = " ";
            cb00401.Text = " ";
            tb00402.Text = "";
            cb00501.Text = " ";
            tb00502.Text = "";
            
            cb00601.Text = " ";

            cb00701.Text = " ";
            cb00702.Text = " ";
            tb00703.Text = "";
            tb00704.Text = "";

            cb00801.Text = " ";
            cb00802.Text = " ";
            cb00804.Text = " ";
            cb00806.Text = " ";
            cb00808.Text = " ";
            cb00810.Text = " ";
            cb00812.Text = " ";
            tb00803.Text = "";
            tb00805.Text = "";
            tb00807.Text = "";
            tb00809.Text = "";
            tb00811.Text = "";
            tb00813.Text = "";

            cb00901.Text = " ";
            tb00902.Text = "";
            tb01001.Text = "Not identified";
            tbECTX.Text = "";
            tbNOTE.Text = "";

            tbblock01.Text = "";
            tbblock03.Text = "";
            tbATX1.Text = "";
            tbATX2.Text = "";
            dataGridView3.Rows.Clear();
            cbt00001.Select();
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = "select * from PISKDN001 where PTNO = '[PTNO]'";
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
                selectKDN();
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

            string Titlestr0004 = tbt00004.Text;
            Titlestr0004 = Titlestr0004.Replace("'", "^");

            string str0101 = cb00101.Text;
            str0101 = str0101.Replace("'", "^");

            string str0102 = tb00102.Text;
            str0102 = str0102.Replace("'", "^");

            string str0201 = tb00201.Text;
            str0201 = str0201.Replace("'", "^");

            string str0202 = tb00202.Text;
            str0202 = str0202.Replace("'", "^");

            string str0203 = tb00203.Text;
            str0203 = str0203.Replace("'", "^");

            string str0301 = cb00301.Text;
            str0301 = str0301.Replace("'", "^");

            string str0401 = cb00401.Text;
            str0401 = str0401.Replace("'", "^");

            string str0402 = tb00402.Text;
            str0402 = str0402.Replace("'", "^");

            string str0501 = cb00501.Text;
            str0501 = str0501.Replace("'", "^");

            string str0502 = tb00502.Text;
            str0502 = str0502.Replace("'", "^");
            //161003
            string str0601 = cb00601.Text;
            str0601 = str0601.Replace("'", "^");



            string str0701 = cb00701.Text;
            str0701 = str0701.Replace("'", "^");

            string str0702 = cb00702.Text;
            str0702 = str0702.Replace("'", "^");

            string str0703 = tb00703.Text;
            str0703 = str0703.Replace("'", "^");

            string str0704 = tb00704.Text;
            str0704 = str0704.Replace("'", "^");

            string str0801 = cb00801.Text;
            str0801 = str0801.Replace("'", "^");
            string str0802 = cb00802.Text;
            str0802 = str0802.Replace("'", "^");
            string str0803 = tb00803.Text;
            str0803 = str0803.Replace("'", "^");
            string str0804 = cb00804.Text;
            str0804 = str0804.Replace("'", "^");
            string str0805 = tb00805.Text;
            str0805 = str0805.Replace("'", "^");
            string str0806 = cb00806.Text;
            str0806 = str0806.Replace("'", "^");
            string str0807 = tb00807.Text;
            str0807 = str0807.Replace("'", "^");
            string str0808 = cb00808.Text;
            str0808 = str0808.Replace("'", "^");
            string str0809 = tb00809.Text;
            str0809 = str0809.Replace("'", "^");
            string str0810 = cb00810.Text;
            str0810 = str0810.Replace("'", "^");
            string str0811 = tb00811.Text;
            str0811 = str0811.Replace("'", "^");
            string str0812 = cb00812.Text;
            str0812 = str0812.Replace("'", "^");
            string str0813 = tb00813.Text;
            str0813 = str0813.Replace("'", "^");

            string str0901 = cb00901.Text;
            str0901 = str0901.Replace("'", "^");
            string str0902 = tb00902.Text;
            str0902 = str0902.Replace("'", "^");
            string str1001 = tb01001.Text;
            str1001 = str1001.Replace("'", "^");


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

            string sql = "INSERT INTO pisKDN001 ( SYDT, UPDT, UPID, PTNO, OGTP, DITP, TRYN, TIT1, TIT2,TIT3,TIT4, n0101,n0102, n0201,n0202,n0203,n0301, n0401, n0402, n0501,n0502, n0601, n0701, n0702, n0703, n0704, n0801, n0802, n0803, n0804, n0805, n0806, n0807, n0808, n0809, n0810,n0811,n0812,n0813, n0901,n0902, n1001, ECTX, NOTE,ATX1,ATX2) VALUES ( '[SYDT]', '[UPDT]', '[UPID]', '[PTNO]', '[OGTP]', '[DITP]', '[TRYN]','[TIT1]', '[TIT2]', '[TIT3]','[TIT4]','[n0101]','[n0102]', '[n0201]', '[n0202]','[n0203]','[n0301]', '[n0401]', '[n0402]', '[n0501]','[n0502]', '[n0601]', '[n0701]', '[n0702]', '[n0703]', '[n0704]', '[n0801]', '[n0802]', '[n0803]', '[n0804]', '[n0805]', '[n0806]', '[n0807]', '[n0808]', '[n0809]', '[n0810]','[n0811]','[n0812]','[n0813]','[n0901]','[n0902]', '[n1001]', '[ECTX]','[NOTE]','[ATX1]','[ATX2]')";
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
            sql = sql.Replace("[n0102]", str0102);

            sql = sql.Replace("[n0201]", str0201);
            sql = sql.Replace("[n0202]", str0202);
            sql = sql.Replace("[n0203]", str0203);

            sql = sql.Replace("[n0301]", str0301);

            sql = sql.Replace("[n0401]", str0401);
            sql = sql.Replace("[n0402]", str0402);

            sql = sql.Replace("[n0501]", str0501);
            sql = sql.Replace("[n0502]", str0502);

            sql = sql.Replace("[n0601]", str0601);


            sql = sql.Replace("[n0701]", str0701);
            sql = sql.Replace("[n0702]", str0702);
            sql = sql.Replace("[n0703]", str0704);
            sql = sql.Replace("[n0704]", str0703);


            sql = sql.Replace("[n0801]", str0801);
            sql = sql.Replace("[n0802]", str0802);
            sql = sql.Replace("[n0803]", str0803);
            sql = sql.Replace("[n0804]", str0804);
            sql = sql.Replace("[n0805]", str0805);
            sql = sql.Replace("[n0806]", str0806);
            sql = sql.Replace("[n0807]", str0807);
            sql = sql.Replace("[n0808]", str0808);
            sql = sql.Replace("[n0809]", str0809);
            sql = sql.Replace("[n0810]", str0810);
            sql = sql.Replace("[n0811]", str0811);
            sql = sql.Replace("[n0812]", str0812);
            sql = sql.Replace("[n0813]", str0813);


            sql = sql.Replace("[n0901]", str0901);
            sql = sql.Replace("[n0902]", str0902);
            sql = sql.Replace("[n1001]", str1001);


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

            string Titlestr0004 = tbt00004.Text;
            Titlestr0004 = Titlestr0004.Replace("'", "^");

            string str0101 = cb00101.Text;
            str0101 = str0101.Replace("'", "^");

            string str0102 = tb00102.Text;
            str0102 = str0102.Replace("'", "^");

            string str0201 = tb00201.Text;
            str0201 = str0201.Replace("'", "^");

            string str0202 = tb00202.Text;
            str0202 = str0202.Replace("'", "^");

            string str0203 = tb00203.Text;
            str0203 = str0203.Replace("'", "^");

            string str0301 = cb00301.Text;
            str0301 = str0301.Replace("'", "^");

            string str0401 = cb00401.Text;
            str0401 = str0401.Replace("'", "^");

            string str0402 = tb00402.Text;
            str0402 = str0402.Replace("'", "^");

            string str0501 = cb00501.Text;
            str0501 = str0501.Replace("'", "^");

            string str0502 = tb00502.Text;
            str0502 = str0502.Replace("'", "^");
            //161003
            string str0601 = cb00601.Text;
            str0601 = str0601.Replace("'", "^");
           

           
            string str0701 = cb00701.Text;
            str0701 = str0701.Replace("'", "^");

            string str0702 = cb00702.Text;
            str0702 = str0702.Replace("'", "^");

            string str0703 = tb00703.Text;
            str0703 = str0703.Replace("'", "^");

            string str0704 = tb00704.Text;
            str0704 = str0704.Replace("'", "^");

            string str0801 = cb00801.Text;
            str0801 = str0801.Replace("'", "^");
            string str0802 = cb00802.Text;
            str0802 = str0802.Replace("'", "^");
            string str0803 = tb00803.Text;
            str0803 = str0803.Replace("'", "^");
            string str0804 = cb00804.Text;
            str0804 = str0804.Replace("'", "^");
            string str0805 = tb00805.Text;
            str0805 = str0805.Replace("'", "^");
            string str0806 = cb00806.Text;
            str0806 = str0806.Replace("'", "^");
            string str0807 = tb00807.Text;
            str0807 = str0807.Replace("'", "^");
            string str0808 = cb00808.Text;
            str0808 = str0808.Replace("'", "^");
            string str0809 = tb00809.Text;
            str0809 = str0809.Replace("'", "^");
            string str0810 = cb00810.Text;
            str0810 = str0810.Replace("'", "^");
            string str0811 = tb00811.Text;
            str0811 = str0811.Replace("'", "^");
            string str0812 = cb00812.Text;
            str0812 = str0812.Replace("'", "^");
            string str0813 = tb00813.Text;
            str0813 = str0813.Replace("'", "^");
           
            string str0901 = cb00901.Text;
            str0901 = str0901.Replace("'", "^");
            string str0902 = tb00902.Text;
            str0902 = str0902.Replace("'", "^");
            string str1001 = tb01001.Text;
            str1001 = str1001.Replace("'", "^");
                      

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

            string sql = "Update pisKDN001 SET SYDT = '[SYDT]', UPDT = '[UPDT]', UPID = '[UPID]', OGTP = '[OGTP]', DITP='[DITP]', TRYN ='[TRYN]', TIT1 = '[TIT1]',TIT2= '[TIT2]',TIT3 ='[TIT3]',TIT4 ='[TIT4]', n0101 = '[n0101]', n0102 = '[n0102]', n0201 = '[n0201]',  n0202 = '[n0202]', n0203 = '[n0203]',n0301='[n0301]', n0401 = '[n0401]', n0402 = '[n0402]', n0501 = '[n0501]', n0502 = '[n0502]', n0601='[n0601]', n0701='[n0701]', n0702='[n0702]', n0703='[n0703]', n0704='[n0704]', n0801='[n0801]', n0802='[n0802]', n0803='[n0803]', n0804='[n0804]', n0805='[n0805]', n0806='[n0806]', n0807='[n0807]', n0808='[n0808]', n0809='[n0809]', n0810='[n0810]', n0811='[n0811]',n0812='[n0812]', n0813='[n0813]', n0901='[n0901]', n0902='[n0902]',n1001='[n1001]', ECTX='[ECTX]', NOTE='[NOTE]' , ATX1='[ATX1]',ATX2 ='[ATX2]' where PTNO ='[PTNO]'";
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
            sql = sql.Replace("[n0102]", str0102);

            sql = sql.Replace("[n0201]", str0201);
            sql = sql.Replace("[n0202]", str0202);
            sql = sql.Replace("[n0203]", str0203);

            sql = sql.Replace("[n0301]", str0301);

            sql = sql.Replace("[n0401]", str0401);
            sql = sql.Replace("[n0402]", str0402);

            sql = sql.Replace("[n0501]", str0501);
            sql = sql.Replace("[n0502]", str0502);

            sql = sql.Replace("[n0601]", str0601);
            

            sql = sql.Replace("[n0701]", str0701);
            sql = sql.Replace("[n0702]", str0702);
            sql = sql.Replace("[n0703]", str0703);
            sql = sql.Replace("[n0704]", str0704);

            sql = sql.Replace("[n0801]", str0801);
            sql = sql.Replace("[n0802]", str0802);
            sql = sql.Replace("[n0803]", str0803);
            sql = sql.Replace("[n0804]", str0804);
            sql = sql.Replace("[n0805]", str0805);
            sql = sql.Replace("[n0806]", str0806);
            sql = sql.Replace("[n0807]", str0807);
            sql = sql.Replace("[n0808]", str0808);
            sql = sql.Replace("[n0809]", str0809);
            sql = sql.Replace("[n0810]", str0810);
            sql = sql.Replace("[n0811]", str0811);
            sql = sql.Replace("[n0812]", str0812);
            sql = sql.Replace("[n0813]", str0813);


            sql = sql.Replace("[n0901]", str0901);
            sql = sql.Replace("[n0902]", str0902);
            sql = sql.Replace("[n1001]", str1001);
            

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

                string sql = String.Format("Update PISKDN001 set {0}='{1}', {2} = '{3}',{4}='{5}' where PTNO = '{6}'", ADD1, str1, ADD2, str2, ADD3, str3, PTNO);

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
            string str00004 = Environment.NewLine + " " + tbt00004.Text; 
            str00004 = str00004.Replace("'", "^");

            if (tbt00004.Text == "")
            {
                str00004 = "";
            }
            
                
            string str000 = lbt00002.Text + str00001 + str00002 + str00003 + str00004;
            str000 = str000.Replace("'", "^");
            if (cbt00001.Text == " " && cbt00002.Text == " " && tbt00003.Text == " " && tbt00004.Text == "")
            {
                str000 = "";
            }



            string str00101 = cb00101.Text;
            str00101 = str00101.Replace("'", "^");
            if (cb00101.Text == " ")
            {
                str00101 = "";
            }

            string str00102 =" " + tb00102.Text;
            str00102 = str00102.Replace("'", "^");
            if (tb00102.Text == "")
            {
                str00102 = "";
            }
            string str001 =  Environment.NewLine + " " + lb00101.Text + str00101 + str00102;
            str001 = str001.Replace("'", "^");
            if (cb00101.Text == " " && tb00102.Text == "")
            {
                str001 = "";
            }

            string str00201 = tb00201.Text + lb00202.Text;
            string str00202 = tb00202.Text + lb00203.Text;
            string str00203 = tb00203.Text;
          


            string str002 = Environment.NewLine + " " + lb00201.Text +str00201 + str00202 + str00203 + lb00204.Text;
            str002 = str002.Replace("'", "^");
            

            if (tb00201.Text == "")
            {

                str002 = Environment.NewLine + " " + lb00201.Text + str00202 + str00203 + lb00204.Text;
            }
            if (tb00202.Text == "")
            {
                str002 =  Environment.NewLine + " " + lb00201.Text + str00201 + str00203 + lb00204.Text;
            }
            if (tb00203.Text == "")
            {

                str002 =Environment.NewLine + " " + lb00201.Text + str00201 + tb00202.Text + lb00204.Text;
            }
            if (tb00201.Text == "" && tb00202.Text == "")
            {
                str002 =Environment.NewLine + " " + lb00201.Text + str00203 + lb00204.Text;
            }
            if (tb00201.Text == "" && tb00203.Text == "")
            {
                str002 = Environment.NewLine + " " + lb00201.Text + tb00202.Text + lb00204.Text;
            }
            if ( tb00202.Text == "" && tb00203.Text == "")
            {
                str002 = Environment.NewLine + " " + lb00201.Text + tb00201.Text + lb00204.Text;
            }

            if (tb00201.Text == "" && tb00202.Text == "" && tb00203.Text == "")
            {
                str002 = "";
            }
            string str003 =  Environment.NewLine + " " + lb00301.Text + cb00301.Text;
            str003 = str003.Replace("'", "^");
            if (cb00301.Text == " ")
            {
                str003 = "";
            }
            
            //string str004 = Environment.NewLine + Environment.NewLine + lb00401.Text + Environment.NewLine+ "      " + cb00401.Text + Environment.NewLine + "      "+ lb00402.Text + tb00402.Text + lb00403.Text;
            string str00401 = cb00401.Text;
            string str00402 = " " + tb00402.Text + lb00402.Text;
            if (cb00401.Text == " ")
            {
                str00401 = "";
            }
            if (tb00402.Text == "")
            {
                str00402 = "";
            }
            string str004 = Environment.NewLine + " " + lb00401.Text + str00401 + str00402;
            if (cb00401.Text == " " && tb00402.Text == "")
            {
                str004 = "";
            }

            string str00501 = cb00501.Text;
            string str00502 = " " + tb00502.Text + lb00502.Text;
            string str005 =  Environment.NewLine + " " + lb00501.Text + str00501 + str00502;
            if (cb00501.Text == " " && tb00502.Text == "")
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
            string str00702 = Environment.NewLine + "     " + cb00702.Text;
            if (cb00702.Text == " ")
            {
                str00702 = "";
            }
            string str00703 = " " + lb00702.Text + tb00703.Text + lb00703.Text;
            if (tb00703.Text == "")
                str00703 = "";

            string str00704 = " " + lb00704.Text + tb00704.Text + lb00705.Text;
            if (tb00704.Text == "")
                str00704 = "";

            string str007 = Environment.NewLine + " " + lb00701.Text + str00701 + str00703 + str00702+str00704;
            if (cb00701.Text == " " && cb00702.Text == " " && str00703 =="" && str00704 =="")
            {
                str007 = "";
            }


            

            string str00801 = Environment.NewLine + "     " + cb00801.Text;
            if (cb00801.Text == " ")
            {
                str00801 = "";
            }
            string str00802 = Environment.NewLine + "        " + lb00802.Text + cb00802.Text;
            if (cb00802.Text == " ")
            {
                str00802 = "";
            }
            string str00803 = Environment.NewLine + "         " + lb00803.Text + tb00803.Text;
            if (tb00803.Text == "")
            {
                str00803 = "";
            }
            string str00804 = Environment.NewLine + "        " + lb00804.Text + cb00804.Text;
            if (cb00804.Text == " ")
            {
                str00804 = "";
            }
            string str00805 = Environment.NewLine + "         " + lb00805.Text + tb00805.Text;
            if (tb00805.Text == "")
            {
                str00805 = "";
            }
            string str00806 =Environment.NewLine + "        " + lb00806.Text + cb00806.Text;
            if (cb00806.Text == " ")
            {
                str00806 = "";
            }
            string str00807 = Environment.NewLine + "         " + lb00807.Text + tb00807.Text;
            if (tb00807.Text == "")
            {
                str00807 = "";
            }
            string str00808 =Environment.NewLine + "        " + lb00808.Text + cb00808.Text;
            if (cb00808.Text == " ")
            {
                str00808 = "";
            }
            string str00809 = Environment.NewLine + "         " + lb00809.Text + tb00809.Text;
            if (tb00809.Text == "")
            {
                str00809 = "";
            }
            string str00810 =Environment.NewLine + "        " + lb00810.Text + cb00810.Text;
            if (cb00810.Text == " ")
            {
                str00810 = "";
            }
            string str00811 = Environment.NewLine + "         " + lb00811.Text + tb00811.Text;
            if (tb00811.Text == "")
            {
                str00811 = "";
            }
            string str00812 =Environment.NewLine + "        " + lb00812.Text + cb00812.Text;
            if (cb00812.Text == " ")
            {
                str00812 = "";
            }
            string str00813 =Environment.NewLine + "         " + lb00813.Text + tb00813.Text;
            if (tb00813.Text == "")
            {
                str00813 = "";
            }
            string str008 = Environment.NewLine + " " + lb00801.Text + str00801 + str00802 + str00803 + str00804 + str00805 + str00806 + str00807 + str00808 + str00809 + str00810 + str00811 + str00812 + str00813;
            if (cb00801.Text == " " && cb00802.Text == " " && tb00803.Text == "" && cb00804.Text == " " && tb00805.Text == "" && cb00806.Text == " " && tb00807.Text == "" && cb00808.Text == " " && tb00809.Text == "" && cb00810.Text == " " && tb00811.Text == "" && cb00812.Text == " " && tb00813.Text == "")
            {
                str008 = "";
            }

            string str00901 =  cb00901.Text;
            str00901 = str00901.Replace("'", "^");
            if (cb00901.Text == " ")
            {
                str00901 = "";
            }
            string str00902 =  " " +  tb00902.Text;            
            str00902 = str00902.Replace("'", "^");
            if (tb00902.Text == "")
            {
                str00902 = "";
            }
            string str009 = Environment.NewLine + " " + lb00901.Text + lb00902.Text + str00901 + str00902;
            str009 = str009.Replace("'", "^");
            if (cb00901.Text == " " && tb00902.Text == "")
            {
                str009 = "";
            }

            string str010 = Environment.NewLine + " " + lb01001.Text + tb01001.Text;
            str010 = str010.Replace("'", "^");
            if (tb01001.Text == "")
            {
                str010 = "";
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
            if (tb00201.Text == "" && tb00202.Text == "" && tb00203.Text == "")
            {
                str002 = "";
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

                totalAdd =  ADD[1] + ADD[2] + ADD[3] + ADD[4] +  ADD[5]  + ADD[6]  + ADD[7]+ ADD[8];
                totalAdd = totalAdd.Replace("'", "^");
            }
            string DITX = lbt00001.Text + Environment.NewLine + str000 + str001 + str002 + str003 + str004 + str005 + str006 + str007 + str008 + str009 + str010  + strECTX + strNOTE + strATX1 + totalAdd + strATX2;
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

        private void selectKDN()
        {

            String sql = "select TIT1, TIT2, TIT3, TIT4, n0101, n0102, n0201,n0202,n0203, n0301, n0401, n0402, n0501,n0502, n0601,n0701, n0702, n0801, n0802, n0803, n0804, n0805, n0806,n0807,n0808,n0809,n0810,n0811,n0812,n0813,n0901,n0902,n1001,ECTX,NOTE,ATX1,ATX2,n0703,n0704 from PISKDN001 where PTNO ='[PTNO]'";

            sql = sql.Replace("[PTNO]", PTNO);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read())
            {

                cbt00001.SelectedIndex = selectData00001(dr[0].ToString());
                cbt00002.SelectedIndex = selectData00002(dr[1].ToString());
                tbt00003.Text = dr[2].ToString().Replace("^", "'");
                tbt00004.Text = dr[3].ToString().Replace("^", "'");

                cb00101.SelectedIndex = selectData00101(dr[4].ToString());
                tb00102.Text = dr[5].ToString().Replace("^", "'");

                tb00201.Text = dr[6].ToString().Replace("^", "'");
                tb00202.Text = dr[7].ToString().Replace("^", "'");
                tb00203.Text = dr[8].ToString().Replace("^", "'");

                cb00301.SelectedIndex = selectData00301(dr[9].ToString());

                cb00401.SelectedIndex = selectData00401(dr[10].ToString());
                tb00402.Text = dr[11].ToString().Replace("^", "'");

                cb00501.SelectedIndex = selectData00501(dr[12].ToString());
                tb00502.Text = dr[13].ToString().Replace("^", "'");

                cb00601.SelectedIndex = selectData00601(dr[14].ToString());

                cb00701.SelectedIndex = selectData00701(dr[15].ToString());
                cb00702.SelectedIndex = selectData00702(dr[16].ToString());

                cb00801.SelectedIndex = selectData00801(dr[17].ToString());
                cb00802.SelectedIndex = selectData00802(dr[18].ToString());
                tb00803.Text = dr[19].ToString().Replace("^", "'");
                cb00804.SelectedIndex = selectData00804(dr[20].ToString());
                tb00805.Text = dr[21].ToString().Replace("^", "'");
                cb00806.SelectedIndex = selectData00806(dr[22].ToString());
                tb00807.Text = dr[23].ToString().Replace("^", "'");
                cb00808.SelectedIndex = selectData00808(dr[24].ToString());
                tb00809.Text = dr[25].ToString().Replace("^", "'");
                cb00810.SelectedIndex = selectData00810(dr[26].ToString());
                tb00811.Text = dr[27].ToString().Replace("^", "'");
                cb00812.SelectedIndex = selectData00812(dr[28].ToString());
                tb00813.Text = dr[29].ToString().Replace("^", "'");

                cb00901.SelectedIndex = selectData00901(dr[30].ToString());
                tb00902.Text = dr[31].ToString().Replace("^", "'");

                tb01001.Text = dr[32].ToString().Replace("^", "'");

                tbECTX.Text = dr[33].ToString().Replace("^", "'");
                tbNOTE.Text = dr[34].ToString().Replace("^", "'");
                tbATX1.Text = dr[35].ToString().Replace("^", "'");
                tbATX2.Text = dr[36].ToString().Replace("^", "'");
                tb00703.Text = dr[37].ToString().Replace("^", "'");
                tb00704.Text = dr[38].ToString().Replace("^", "'");
                selectAdd();
            }
            dr.Close();
        }

        private void dataGridView3_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView3.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void tb00201_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00202_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00203_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00502_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select DITX from PISDIG001 where PTNO ='[PTNO]' and OGTP ='KDN'";
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

        private void button9_Click(object sender, EventArgs e)
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
