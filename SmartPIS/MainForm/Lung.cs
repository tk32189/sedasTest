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
    public partial class Lung : DevExpress.XtraEditors.XtraForm
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public static MySqlConnection Myconn;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        public string HMTP = "lng";
        public string PTNO;
        public string block1;
        public string block2;
        public string totalAdd;
        public Lung()
        {
            InitializeComponent();

            
        }

       

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cb00801.SelectedItem.ToString() == "Uninvolved by invasive carcinoma")
            {
                //label4.Visible = true;
                tb00802.Enabled = true;
                //label7.Visible = true;
            }
            else
            {
                //label4.Visible = false;
                tb00802.Text = "";
                tb00802.Enabled = false;
                //label7.Visible = false;
            }
        }

        private void comboBox7_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb00804.SelectedItem.ToString() == "Uninvolved by invasive carcinoma")
            {
                //label16.Visible = true;
                tb00805.Enabled = true;
                
                //label9.Visible = true;
            }
            else
            {
                tb00805.Text = "";
                //label6.Visible = false;
                tb00805.Enabled = false;
                //label9.Visible = false;
            }
        }

        private void comboBox18_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                tb00702.Text = cb00701.SelectedItem.ToString();
            }
            catch
            {
            }
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
      
        private void InsertcomboTitle00001()
        {

            String sql = Ini.DBSelect;
            string SQNO = "00001";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while(dr.Read())
            {
                cbt00001.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }
        private void InsertcomboTitle00002()
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
        private void InsertcomboTitle00003()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00003";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cbt00003.Items.Add(dr.GetString(0));
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
                cb00803.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }
        private void Insertcombo00803()
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
        private void Insertcombo00804()
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
        private void selectLNG()
        {

            String sql = "select TIT1, TIT2, TIT3, TIT4, n0101, n0102, n0201, n0301, n0401, n0402, n0403, n0501, n0601, n0701, n0702, n0801, n0802, n0803, n0804, n0805, n0806, n0901, n1001, n1101, n1201, n1301, n1401, n1402, n1403,ECTX,NOTE,ATX1,ATX2 from PISLNG001 where PTNO ='[PTNO]'";

            sql = sql.Replace("[PTNO]", PTNO);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read())
            {
                cbt00001.SelectedIndex = selectData00001(dr[0].ToString());
                //cbt00001.SelectedIndex = 0;

                cbt00002.SelectedIndex = selectData00002(dr[1].ToString());

                cbt00003.SelectedIndex = selectData00003(dr[2].ToString());
                tbt00004.Text = dr[3].ToString().Replace("^", "'");
                cb00101.SelectedIndex = selectData00101(dr[4].ToString());
                tb00102.Text = dr[5].ToString().Replace("^", "'");
                cb00201.SelectedIndex = selectData00201(dr[6].ToString());
                cb00301.SelectedIndex = selectData00301(dr[7].ToString());
                tb00401.Text = dr[8].ToString().Replace("^", "'");
                tb00402.Text = dr[9].ToString().Replace("^", "'");
                tb00403.Text = dr[10].ToString().Replace("^", "'");
                cb00501.SelectedIndex = selectData00501(dr[11].ToString());
                cb00601.SelectedIndex = selectData00601(dr[12].ToString());
                cb00701.SelectedIndex = selectData00701(dr[13].ToString());
                tb00702.Text = dr[14].ToString().Replace("^", "'");
                cb00801.SelectedIndex = selectData00801(dr[15].ToString());
                tb00802.Text = dr[16].ToString().Replace("^", "'");
                cb00803.SelectedIndex = selectData00803(dr[17].ToString());
                cb00804.SelectedIndex = selectData00804(dr[18].ToString());
                tb00805.Text = dr[19].ToString().Replace("^", "'");
                cb00806.SelectedIndex = selectData00806(dr[20].ToString());
                cb00901.SelectedIndex = selectData00901(dr[21].ToString());
                cb01001.SelectedIndex = selectData01001(dr[22].ToString());
                cb01101.SelectedIndex = selectData01101(dr[23].ToString());
                cb01201.SelectedIndex = selectData01201(dr[24].ToString());
                tb01301.Text = dr[25].ToString().Replace("^", "'");
                tb01401.Text = dr[26].ToString().Replace("^", "'");
                tb01402.Text = dr[27].ToString().Replace("^", "'");
                tb01403.Text = dr[28].ToString().Replace("^", "'");
                ectb001.Text = dr[29].ToString().Replace("^", "'");
                nttb001.Text = dr[30].ToString().Replace("^", "'");
                tbATX1.Text = dr[31].ToString().Replace("^", "'");
                tbATX2.Text = dr[32].ToString().Replace("^", "'");
                selectAdd();
            }
            dr.Close();
        }

        
        private void Lung_Load(object sender, EventArgs e)
        {
            try
            {
                CoreLibrary core = new CoreLibrary();
                core.InitGridStyle(dataGridView3);

                cbt00001.Items.Add(" ");
                cbt00002.Items.Add(" ");
                cbt00003.Items.Add(" ");
                cb00101.Items.Add(" ");
                cb00201.Items.Add(" ");
                cb00301.Items.Add(" ");

                cb00501.Items.Add(" ");
                cb00601.Items.Add(" ");
                cb00701.Items.Add(" ");
                cb00801.Items.Add(" ");
                cb00803.Items.Add(" ");
                cb00804.Items.Add(" ");
                cb00806.Items.Add(" ");
                cb00901.Items.Add(" ");
                cb01001.Items.Add(" ");
                cb01101.Items.Add(" ");
                cb01201.Items.Add(" ");

                string strSQL = Ini.strDB;

                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();

                InsertcomboTitle00001();
                InsertcomboTitle00002();
                InsertcomboTitle00003();
                Insertcombo00101();
                Insertcombo00201();
                Insertcombo00301();
                Insertcombo00501();
                Insertcombo00601();
                Insertcombo00701();
                Insertcombo00801();
                Insertcombo00802();
                Insertcombo00803();
                Insertcombo00804();
                Insertcombo00901();
                Insertcombo01001();
                Insertcombo01101();
                Insertcombo01201();

                String sql = "select TIT1, TIT2, TIT3, TIT4, n0101, n0102, n0201, n0301, n0401, n0402, n0403, n0501, n0601, n0701, n0702, n0801, n0802, n0803, n0804, n0805, n0806, n0901, n1001, n1101, n1201, n1301, n1401, n1402, n1403,ECTX,NOTE,ATX1,ATX2 from PISLNG001 where PTNO ='[PTNO]'";

                sql = sql.Replace("[PTNO]", PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();



                while (dr.Read())
                {
                    cbt00001.SelectedIndex = selectData00001(dr[0].ToString());
                    //cbt00001.SelectedIndex = 1;

                    cbt00002.SelectedIndex = selectData00002(dr[1].ToString());

                    cbt00003.SelectedIndex = selectData00003(dr[2].ToString());
                    //dr[3].ToString() = dr[3].ToString().Replace("^", "'");
                    tbt00004.Text = dr[3].ToString().Replace("^", "'");
                    cb00101.SelectedIndex = selectData00101(dr[4].ToString());
                    tb00102.Text = dr[5].ToString().Replace("^", "'");
                    cb00201.SelectedIndex = selectData00201(dr[6].ToString());
                    cb00301.SelectedIndex = selectData00301(dr[7].ToString());
                    tb00401.Text = dr[8].ToString().Replace("^", "'");
                    tb00402.Text = dr[9].ToString().Replace("^", "'");
                    tb00403.Text = dr[10].ToString().Replace("^", "'");
                    cb00501.SelectedIndex = selectData00501(dr[11].ToString());
                    cb00601.SelectedIndex = selectData00601(dr[12].ToString());
                    cb00701.SelectedIndex = selectData00701(dr[13].ToString());
                    tb00702.Text = dr[14].ToString().Replace("^", "'");
                    cb00801.SelectedIndex = selectData00801(dr[15].ToString());
                    tb00802.Text = dr[16].ToString().Replace("^", "'");
                    cb00803.SelectedIndex = selectData00803(dr[17].ToString());
                    cb00804.SelectedIndex = selectData00804(dr[18].ToString());
                    tb00805.Text = dr[19].ToString().Replace("^", "'");
                    cb00806.SelectedIndex = selectData00806(dr[20].ToString());
                    cb00901.SelectedIndex = selectData00901(dr[21].ToString());
                    cb01001.SelectedIndex = selectData01001(dr[22].ToString());
                    cb01101.SelectedIndex = selectData01101(dr[23].ToString());
                    cb01201.SelectedIndex = selectData01201(dr[24].ToString());
                    tb01301.Text = dr[25].ToString().Replace("^", "'");
                    tb01401.Text = dr[26].ToString().Replace("^", "'");
                    tb01402.Text = dr[27].ToString().Replace("^", "'");
                    tb01403.Text = dr[28].ToString().Replace("^", "'");
                    ectb001.Text = dr[29].ToString().Replace("^", "'");
                    nttb001.Text = dr[30].ToString().Replace("^", "'");
                    tbATX1.Text = dr[31].ToString().Replace("^", "'");
                    tbATX2.Text = dr[32].ToString().Replace("^", "'");
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
            int n=0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng'and  SQNO = '00001'";

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
            /*if (n > 0)
            {
                n--;
            }*/
            return n;
        }

        private int selectData00002(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng'and  SQNO = '00002'";

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
            /*if (n > 0)
            {
                n--;
            }*/
            return n;
        }
        private int selectData00003(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng'and  SQNO = '00003'";

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
            /*if (n > 0)
            {
                n--;
            }*/
            return n;
        }
        private int selectData00101(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng'and  SQNO = '00101'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng'and  SQNO = '00201'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng'and  SQNO = '00301'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng'and  SQNO = '00501'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng'and  SQNO = '00601'";

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
            /*if (n > 0)
            {
                n--;
            }*/
            return n;
        }
        private int selectData00701(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng' and  SQNO = '00701'";

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
          /*  if (n > 0)
            {
                n--;
            }*/
            return n;
        }
        private int selectData00801(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng'and  SQNO = '00801'";

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
        private int selectData00803(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng'and  SQNO = '00802'";

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
          /*  if (n > 0)
            {
                n--;
            }*/
            return n;
        }
        private int selectData00804(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng' and  SQNO = '00803'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng' and SQNO = '00804'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng'and SQNO = '00901'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng'and SQNO = '01001'";

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
          /*  if (n > 0)
            {
                n--;
            }*/
            return n;
        }

        private int selectData01101(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng'and SQNO = '01101'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'lng' and SQNO = '01201'";

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
         /*   if (n > 0)
            {
                n--;
            }*/
            return n;
        }
        private void Lung_FormClosing(object sender, FormClosingEventArgs e)
        {
            Myconn.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
            String sql = "select * from PISLNG001 where PTNO = '[PTNO]'";
            sql = sql.Replace("[PTNO]", PTNO);
            string strSQL = Ini.strDB;
            MySqlConnection conn = new MySqlConnection(strSQL);
            conn.Open();
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader drc = cmd.ExecuteReader();
            
            bool bRet = false;

            while(drc.Read())
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
            selectLNG();
            Selectblock();
            drc.Close();
            conn.Close();    
            }
            catch (System.Exception ex)
            {
            }
            

        }

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {

            if (DevExpress.XtraEditors.XtraMessageBox.Show("정보를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string sql = "delete from pislng001 where ptno = '[PTNO]'";
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
            tbt00004.Text = "Non Small Cell Lung Cancer";
            cbt00001.Text = " ";
            cbt00002.Text = " ";
            cbt00003.Text = " ";

            cb00101.Text = " ";
            cb00201.Text = " ";
            cb00301.Text = " ";
            cb00501.Text = " ";
            cb00601.Text = " ";
            cb00701.Text = " ";
            cb00801.Text = " ";
            cb00803.Text = " ";
            cb00804.Text = " ";
            cb00806.Text = " ";
            cb00901.Text = " ";
            cb01001.Text = " ";
            cb01101.Text = " ";
            cb01201.Text = " ";

            // tbt00001.Text = "";
            tb00102.Text = "";
            tb00401.Text = "";
            tb00402.Text = "";
            tb00403.Text = "";
            tb00702.Text = "";
            tb00802.Text = "";
            tb00805.Text = "";
            tb01301.Text = "";
            tb01401.Text = "";
            tb01402.Text = "";
            tb01403.Text = "";
            nttb001.Text = "";
            ectb001.Text = "";
            tbblock01.Text = "";
            tbblock03.Text = "";
            tbATX1.Text = "";
            tbATX2.Text = "";
            dataGridView3.Rows.Clear();
            cbt00001.Select();
        }

        private void InsertDB()
        {
            string Titlestr0001 = cbt00001.Text;
            //MessageBox.Show(Titlestr00001);
            string Titlestr0002 = cbt00002.Text;
            //MessageBox.Show(Titlestr00002);
            string Titlestr0003 = cbt00003.Text;
            //MessageBox.Show(Titlestr00003);
            string Titlestr0004 = tbt00004.Text;
            Titlestr0004=Titlestr0004.Replace("'", "^");
            //MessageBox.Show(Titlestr00004);

            string str0101 = cb00101.Text;
            //MessageBox.Show(str00101);
            string str0102 = tb00102.Text;
            str0102=str0102.Replace("'", "^");

            string str0201 = cb00201.Text;
            //MessageBox.Show(str00201);
            
            string str0301 = cb00301.Text;
            //MessageBox.Show(str00301);

            string str0401 = tb00401.Text;
            //MessageBox.Show(str00401);
           
            string str0402 = tb00402.Text;
            //MessageBox.Show(str00402);

            string str0403 = tb00403.Text;
            //MessageBox.Show(str00403);

            string str0501 = cb00501.Text;
            //MessageBox.Show(str00501);
            string str0601 = cb00601.Text;
            //MessageBox.Show(str00601);
            string str0701 = cb00701.Text;
            //MessageBox.Show(str00701);

            string str0702 = tb00702.Text;
            str0702=str0702.Replace("'", "^");
            //MessageBox.Show(str00702);
            string str0801 = cb00801.Text;
            //MessageBox.Show(str00801);
            string str0802 = tb00802.Text;
            str0802=str0802.Replace("'", "^");
            //MessageBox.Show(str00802);
            string str0803 = cb00803.Text;
            //MessageBox.Show(str00803);
            string str0804 = cb00804.Text;
            //MessageBox.Show(str00804);
            string str0805 = tb00805.Text;
            str0805=str0805.Replace("'", "^");
            //MessageBox.Show(str00805);
            string str0806 = cb00806.Text;
            //MessageBox.Show(str00806);

            string str0901 = cb00901.Text;
            //MessageBox.Show(str00901);
            string str1001 = cb01001.Text;
            //MessageBox.Show(str01001);
            string str1101 = cb01101.Text;
            //MessageBox.Show(str01101);
            string str1201 = cb01201.Text;
            //MessageBox.Show(str01201);
            string str1301 = tb01301.Text;
            str1301=str1301.Replace("'", "^");
            string str1401 = tb01401.Text;
            str1401=str1401.Replace("'", "^");
            //MessageBox.Show(str01401);
            string str1402 = tb01402.Text;
            str1402=str1402.Replace("'", "^");
            //MessageBox.Show(str01402);
            string str1403 = tb01403.Text;
           str1403= str1403.Replace("'", "^");
            //MessageBox.Show(str01403);
            string ectb = ectb001.Text;
            ectb=ectb.Replace("'", "^");
            string note = nttb001.Text;
            note=note.Replace("'", "^");

            string strATX1 = tbATX1.Text;
            strATX1=strATX1.Replace("'", "^");
            string strATX2 = tbATX2.Text;
            strATX2=strATX2.Replace("'", "^");
            string strblock001 = tbblock01.Text;
            strblock001=strblock001.Replace("'", "^");
            string strblock002 = tbblock03.Text;
            strblock002=strblock002.Replace("'", "^");

            string sql = Ini.DBInsert;
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
            sql = sql.Replace("[0101]", str0101);
            sql = sql.Replace("[0102]", str0102);
            sql = sql.Replace("[0201]", str0201);
            sql = sql.Replace("[0301]", str0301);
            sql = sql.Replace("[0401]", str0401);
            sql = sql.Replace("[0402]", str0402);
            sql = sql.Replace("[0403]", str0403);
            sql = sql.Replace("[0501]", str0501);
            sql = sql.Replace("[0601]", str0601);
            sql = sql.Replace("[0701]", str0701);
            sql = sql.Replace("[0702]", str0702);
            sql = sql.Replace("[0801]", str0801);
            sql = sql.Replace("[0802]", str0802);
            sql = sql.Replace("[0803]", str0803);
            sql = sql.Replace("[0804]", str0804);
            sql = sql.Replace("[0805]", str0805);
            sql = sql.Replace("[0806]", str0806);
            sql = sql.Replace("[0901]", str0901);
            sql = sql.Replace("[1001]", str1001);
            sql = sql.Replace("[1101]", str1101);
            sql = sql.Replace("[1201]", str1201);
            sql = sql.Replace("[1301]", str1301);
            sql = sql.Replace("[1401]", str1401);
            sql = sql.Replace("[1402]", str1402);
            sql = sql.Replace("[1403]", str1403);
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
            
            //MessageBox.Show(Titlestr00001);
            string Titlestr0002 = cbt00002.Text;
            //MessageBox.Show(Titlestr00002);
            string Titlestr0003 = cbt00003.Text;
            //MessageBox.Show(Titlestr00003);
            string Titlestr0004 = tbt00004.Text;
            //MessageBox.Show(Titlestr00004);
            Titlestr0004= Titlestr0004.Replace("'", "^");
            string str0101 = cb00101.Text;
            //MessageBox.Show(str00101);
            string str0102 = tb00102.Text;
            //MessageBox.Show(str00102);
            str0102=str0102.Replace("'", "^");
            string str0201 = cb00201.Text;
            //MessageBox.Show(str00201);
            string str0301 = cb00301.Text;
            //MessageBox.Show(str00301);

            string str0401 = tb00401.Text;
            
            //MessageBox.Show(str00401);
            string str0402 = tb00402.Text;
            //MessageBox.Show(str00402);
            string str0403 = tb00403.Text;
            //MessageBox.Show(str00403);

            string str0501 = cb00501.Text;
            //MessageBox.Show(str00501);
            string str0601 = cb00601.Text;
            //MessageBox.Show(str00601);
            string str0701 = cb00701.Text;
            //MessageBox.Show(str00701);

            string str0702 = tb00702.Text;
           str0702= str0702.Replace("'", "^");
            //MessageBox.Show(str00702);
            string str0801 = cb00801.Text;
            //MessageBox.Show(str00801);
            string str0802 = tb00802.Text;
           str0802= str0802.Replace("'", "^");
            //MessageBox.Show(str00802);
            string str0803 = cb00803.Text;
            //MessageBox.Show(str00803);
            string str0804 = cb00804.Text;
            //MessageBox.Show(str00804);
            string str0805 = tb00805.Text;
            str0805 = str0805.Replace("'", "^");
            //MessageBox.Show(str00805);
            string str0806 = cb00806.Text;
            //MessageBox.Show(str00806);

            string str0901 = cb00901.Text;
            //MessageBox.Show(str00901);
            string str1001 = cb01001.Text;
            //MessageBox.Show(str01001);
            string str1101 = cb01101.Text;
            //MessageBox.Show(str01101);
            string str1201 = cb01201.Text;
            //MessageBox.Show(str01201);
            string str1301 = tb01301.Text;
            str1301=str1301.Replace("'", "^");
            string str1401 = tb01401.Text;
            str1401=str1401.Replace("'", "^");
            //MessageBox.Show(str01401);
            string str1402 = tb01402.Text;
            str1402=str1402.Replace("'", "^");
            //MessageBox.Show(str01402);
            string str1403 = tb01403.Text;
            str1403 = str1403.Replace("'", "^");
            //MessageBox.Show(str01403);
            string ectb = ectb001.Text;
            ectb = ectb.Replace("'", "^");
            
            string note = nttb001.Text;
            note =note.Replace("'", "^");


            string strATX1 = tbATX1.Text;
            strATX1.Replace("'", "^");
            string strATX2 = tbATX2.Text;
            strATX2.Replace("'", "^");
            string strblock001 = tbblock01.Text;
            strblock001.Replace("'", "^");
            string strblock002 = tbblock03.Text;
            strblock002.Replace("'", "^");
            
            string sql = "Update pislng001 SET SYDT = '[SYDT]', UPDT = '[UPDT]', UPID = '[UPID]', OGTP = '[OGTP]', DITP='[DITP]', TRYN ='[TRYN]', TIT1 = '[TIT1]',TIT2= '[TIT2]', TIT3 ='[TIT3]', TIT4= '[TIT4]', n0101 = '[n0101]', n0102 = '[n0102]', n0201 = '[n0201]', n0301='[n0301]', n0401 = '[n0401]', n0402 = '[n0402]', n0403 = '[n0403]', n0501 = '[n0501]', n0601='[n0601]', n0701='[n0701]', n0702='[n0702]', n0801='[n0801]', n0802='[n0802]', n0803='[n0803]', n0804='[n0804]', n0805='[n0805]', n0806='[n0806]', n0901='[n0901]', n1001='[n1001]', n1101='[n1101]', n1201='[n1201]', n1301='[n1301]', n1401='[n1401]', n1402='[n1402]', n1403='[n1403]', ECTX='[ECTX]', NOTE='[NOTE]' , ATX1='[ATX1]',ATX2 ='[ATX2]' where PTNO ='[PTNO]'";
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
            sql = sql.Replace("[n0301]", str0301);
            sql = sql.Replace("[n0401]", str0401);
            sql = sql.Replace("[n0402]", str0402);
            sql = sql.Replace("[n0403]", str0403);
            sql = sql.Replace("[n0501]", str0501);
            sql = sql.Replace("[n0601]", str0601);
            sql = sql.Replace("[n0701]", str0701);
            sql = sql.Replace("[n0702]", str0702);
            sql = sql.Replace("[n0801]", str0801);
            sql = sql.Replace("[n0802]", str0802);
            sql = sql.Replace("[n0803]", str0803);
            sql = sql.Replace("[n0804]", str0804);
            sql = sql.Replace("[n0805]", str0805);
            sql = sql.Replace("[n0806]", str0806);
            sql = sql.Replace("[n0901]", str0901);
            sql = sql.Replace("[n1001]", str1001);
            sql = sql.Replace("[n1101]", str1101);
            sql = sql.Replace("[n1201]", str1201);
            sql = sql.Replace("[n1301]", str1301);
            sql = sql.Replace("[n1401]", str1401);
            sql = sql.Replace("[n1402]", str1402);
            sql = sql.Replace("[n1403]", str1403);
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
            
                
                for (int i = 0; i < Convert.ToUInt32(dataGridView3.Rows.Count-1); i++)
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
                    

                    string sql = String.Format("Update PISLNG001 set {0}='{1}', {2} = '{3}',{4}='{5}' where PTNO = '{6}'", ADD1, str1, ADD2, str2, ADD3, str3, PTNO);
                    
                    MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                    cmd.ExecuteNonQuery();
                }

                
        }
        /*
        private void MainDBInsert()
        {
            string sql = "INSERT INTO PISDlg001 (PTNO,DITX) value ('[PTNO]','[DITX]')";
            //string DIXT = lbt00001.Text + Environment.NewLine + lbt00002.Text + cbt00001.Text + cbt00002.Text + cbt00003.Text + Environment.NewLine + " " + tbt00004.Text + Environment.NewLine + "  " + lb00101.Text + Environment.NewLine + "    "+cb00101.Text + Environment.NewLine + "  " +lb00201.Text+ Environment.NewLine + "    "+cb00201 + Environment.NewLine + "  " + lb00301.Text + Environment.NewLine + "    " +cb00301.Text + Environment.NewLine + "  " + lb00401.Text + tb00401.Text + lb00402.Text + tb00402.Text + lb00403.Text + tb00403.Text + lb00404.Text +Environment.NewLine + "  "+lb00501.Text + Environment.NewLine + "    " +cb00501.Text + Environment.NewLine + "  " + lb00601.Text + Environment.NewLine +"    "+cb00601.Text + Environment.NewLine +"  " + lb00701.Text + Environment.NewLine + "    "+cb00701.Text + Environment.NewLine +"    "+tb00702.Text + Environment.NewLine + "  "+lb00801.Text + Environment.NewLine + "    " + lb00802.Text + Environment.NewLine + "     "+ cb00801.Text + Environment.NewLine + "      "+lb00803.Text + tb00802.Text + Environment.NewLine + "    "+lb00804.Text + Environment.NewLine + "     "+cb00803.Text 
            sql.Replace("[PTNO]", PTNO);
            //sql.Replace("[DITX]", DITX);
        }
          */
        private void MainDBUpdate()
        {
            
            string sql = "Update PISDIG001 set  DITX = '[DITX]', ABLK = '[ABLK]',NBLK = '[NBLK]', OGTP = '[OGTP]' where PTNO = '[PTNO]'";
            //string DITX = lbt00001.Text + Environment.NewLine + lbt00002.Text + cbt00001.Text + cbt00002.Text + cbt00003.Text + Environment.NewLine + " " + tbt00004.Text + Environment.NewLine + Environment.NewLine + "  " + lb00101.Text + Environment.NewLine + "    " + cb00101.Text + Environment.NewLine + Environment.NewLine + "  " + lb00201.Text + Environment.NewLine + "    " + cb00201.Text + Environment.NewLine + Environment.NewLine + "  " + lb00301.Text + Environment.NewLine + "    " + cb00301.Text + Environment.NewLine + Environment.NewLine + "  " + lb00401.Text + tb00401.Text + lb00402.Text + tb00402.Text + lb00403.Text + tb00403.Text + lb00404.Text + Environment.NewLine + Environment.NewLine + "  " + lb00501.Text + Environment.NewLine + "    " + cb00501.Text + Environment.NewLine + Environment.NewLine + "  " + lb00601.Text + Environment.NewLine + "    " + cb00601.Text + Environment.NewLine + Environment.NewLine + "  " + lb00701.Text + Environment.NewLine + "    " + cb00701.Text + Environment.NewLine + "    " + tb00702.Text + Environment.NewLine + Environment.NewLine + "  " + lb00801.Text + Environment.NewLine + "    " + lb00802.Text + Environment.NewLine + "     " + cb00801.Text + Environment.NewLine + "      " + lb00803.Text + tb00802.Text + lb00804.Text + Environment.NewLine + "    " + lb00805.Text + Environment.NewLine + "     " + cb00803.Text + Environment.NewLine + "    " + lb00806.Text + Environment.NewLine + "     " + cb00804.Text + Environment.NewLine + "      " + lb00807.Text + tb00805.Text + lb00808.Text + Environment.NewLine + "    " + lb00809.Text + Environment.NewLine + "     " + cb00806.Text + Environment.NewLine + Environment.NewLine + "  " + lb00901.Text + Environment.NewLine + "    " + cb00901.Text + Environment.NewLine + Environment.NewLine + "  " + lb01001.Text + cb01001.Text + Environment.NewLine + Environment.NewLine + "  " + lb01101.Text + cb01101.Text + Environment.NewLine + Environment.NewLine + "  " + lb01201.Text + cb01201.Text + Environment.NewLine + Environment.NewLine + "  " + lb01301.Text + Environment.NewLine + "     " + tb01301.Text + Environment.NewLine + Environment.NewLine + "  " + lb01401.Text + lb01402.Text + tb01401.Text + lb01403.Text + tb01402.Text + lb01404.Text + tb01403.Text + Environment.NewLine + Environment.NewLine + "  " + ectb001.Text + Environment.NewLine + Environment.NewLine + "  " + ntlb001.Text + Environment.NewLine + "  " + nttb001.Text;

            string str000 =   lbt00002.Text + cbt00001.Text +" " + cbt00002.Text +" " + cbt00003.Text + Environment.NewLine + " " + tbt00004.Text;
            str000=str000.Replace("'", "^");
            string str001 =  Environment.NewLine + lb00101.Text + Environment.NewLine + "    " + cb00101.Text + " " + tb00102.Text;
            str001 = str001.Replace("'", "^");
            string str004 =  Environment.NewLine + lb00401.Text + tb00401.Text + lb00402.Text + tb00402.Text + lb00403.Text + tb00403.Text + lb00404.Text;
            str004 = str004.Replace("'", "^");
            string str005 =  Environment.NewLine + lb00501.Text + Environment.NewLine + "    " + cb00501.Text;
            str005 = str005.Replace("'", "^");
            string str002 =  Environment.NewLine + lb00201.Text + Environment.NewLine + "    " + cb00201.Text;
            str002 = str002.Replace("'", "^");
            string str003 =  Environment.NewLine + lb00301.Text + Environment.NewLine + "    " + cb00301.Text;
            str003 = str003.Replace("'", "^");
            string str006 =  Environment.NewLine + lb00601.Text + Environment.NewLine + "    " + cb00601.Text;
            str006 = str006.Replace("'", "^");
            string str007 =  Environment.NewLine + lb00701.Text + Environment.NewLine + "    " + cb00701.Text + Environment.NewLine + "    " + tb00702.Text;
            str007 = str007.Replace("'", "^");

            string str00801 = lb00801.Text ;
            string str00802 = Environment.NewLine + "    " + lb00802.Text  + cb00801.Text;
            
            string str00803 = Environment.NewLine + "      " + lb00803.Text + tb00802.Text + lb00804.Text ;
            
            string str00804 = Environment.NewLine + "    " + lb00805.Text + cb00803.Text;
            
            string str00805 = Environment.NewLine + "    " + lb00806.Text  + cb00804.Text;
            
            string str00806 = Environment.NewLine + "      " + lb00807.Text + tb00805.Text + lb00808.Text ;
            
            string str00807 = Environment.NewLine + "    " + lb00809.Text + cb00806.Text;
            
            string str008;
            


            string str009 =  Environment.NewLine + lb00901.Text + Environment.NewLine + "    " + cb00901.Text;
            str009 = str009.Replace("'", "^");
            string str010 =  Environment.NewLine + lb01001.Text + cb01001.Text;
            str010 = str010.Replace("'", "^");
            string str011 =  Environment.NewLine + lb01101.Text + cb01101.Text;
            str011 = str011.Replace("'", "^");
            string str012 =  Environment.NewLine + lb01201.Text + cb01201.Text;
            str012 = str012.Replace("'", "^");
            string str013 =  Environment.NewLine + lb01301.Text + Environment.NewLine + "     " + tb01301.Text;
            str013 = str013.Replace("'", "^");
            string str014 = Environment.NewLine + lb01401.Text + lb01402.Text + tb01401.Text + lb01403.Text + tb01402.Text + lb01404.Text + tb01403.Text;
            str014 = str014.Replace("'", "^");
            string strECTX =  Environment.NewLine + ectb001.Text;
            strECTX = strECTX.Replace("'", "^");
            string strTBNOTE = "     " + nttb001.Text.Replace("\r\n", "\r\n     ");
            string strNOTE =  Environment.NewLine + ntlb001.Text + Environment.NewLine + strTBNOTE;
            strNOTE = strNOTE.Replace("'", "^");
            string strTBATX1 = " " + tbATX1.Text.Replace("\r\n", "\r\n     ");
            string strATX1 = Environment.NewLine + strTBATX1;
            strATX1 = strATX1.Replace("'", "^");
            
            string strTBATX2 = " " + tbATX2.Text.Replace("\r\n", "\r\n   ");
            strTBATX2 = strTBATX2.Replace("#. Histochemistry", "#. Histochemistry");
            string strATX2 = Environment.NewLine + strTBATX2;
            strATX2 = strATX2.Replace("'", "^");
            
            if (cbt00001.Text == "" && cbt00002.Text == "" && cbt00003.Text == "" && tbt00004.Text == "")
            {
                str000 = "";
            }
            if (cb00101.Text ==" "&& tb00102.Text =="")
            {
                str001 = "";
            }
             if (cb00201.Text == " ")
            {
                str002 = "";
            }
             if (cb00301.Text == " ")
            {
                str003 = "";
            }
             if (tb00401.Text == "" && tb00402.Text == "")
             {
                str004 = Environment.NewLine + lb00401.Text + tb00403.Text + lb00404.Text;
             }
             else if (tb00402.Text == "" && tb00403.Text == "")
             {
                 str004 =  Environment.NewLine + lb00401.Text + tb00401.Text + lb00404.Text;
             }
             else if (tb00401.Text == "" && tb00403.Text == "")
             {
                 str004 =  Environment.NewLine + lb00401.Text + tb00402.Text + lb00404.Text;
             }
             else if (tb00401.Text == "")
             {
                 str004 = Environment.NewLine + lb00401.Text + tb00402.Text + lb00403.Text + tb00403.Text + lb00404.Text;
             }
             else if (tb00403.Text == "")
             {
                 str004 =  Environment.NewLine + lb00401.Text + tb00401.Text + lb00402.Text + tb00402.Text + lb00404.Text;
             }
            
             else if (tb00402.Text == "")
             {
                 str004 =  Environment.NewLine + lb00401.Text + tb00401.Text + lb00402.Text + tb00403.Text + lb00404.Text;
             }
             
             else if (tb00401.Text == "" && tb00402.Text == "" && tb00403.Text == "")
             {
                 str004 = "";
             }
             
             if (cb00501.Text == " ")
            {
                str005 = "";
            }
             if (cb00601.Text == " ")
            {
                str006 = "";
            }
             if (cb00701.Text == " "&& tb00702.Text=="")
            {
                str007 = "";
            }
             if (cb00801.Text == " " )
            {
                str00802 = "";
            }
             if (tb00802.Text == "" )
            {
                str00803 = "";
            }

             if(cb00803.Text == " ")
            {
                str00804 = "";
            }
             if (cb00804.Text == " ")
            {
                str00805 = "";
            }
             if (tb00805.Text == "")
            {
                str00806 = "";
            }
             if (cb00806.Text == " ")
            {
                str00807 = "";
            }
             if (cb00801.Text == " " && tb00802.Text == "" && cb00803.Text == " " && cb00804.Text == " " && tb00805.Text == "" && cb00806.Text == " ")
             {
                 str00801 = "";
             }
             if (cb00901.Text == " ")
             {
                 str009 = "";
             }
             if(cb01001.Text == " ")
            {
                str010 = "";
            }
             if (cb01101.Text == " ")
            {
                str011 = "";
            }
            if (cb01201.Text == " ")
            {
                str012 = "";
            }
            if (tb01301.Text == "")
            {
                str013 = "";
            }
            if (tb01401.Text == "" && tb01402.Text == "" && tb01403.Text == "")
            {
                str014 = "";
            }
            if (ectb001.Text == "")
            {
                strECTX = "";
            }
            if (nttb001.Text == "")
            {
                strNOTE = "";
            }

            str008 =  Environment.NewLine + str00801 + str00802 + str00803 + str00804 + str00805 + str00806 + str00807;

           str008= str008.Replace("'", "^");

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
                else if( str1 !="" && str2!="" && str3=="")
                {
                    ADD[n] = Environment.NewLine + "  " + str1 + " : " + str2;
                }

                totalAdd =  ADD[1] + ADD[2] +  ADD[3] +  ADD[4] +ADD[5]  + ADD[6] +  ADD[7] +  ADD[8];
                totalAdd = totalAdd.Replace("'", "^");
            }
            
            if(tb00401.Text=="" && tb00402.Text =="" && tb00403.Text =="")
            {
                str004 = "";
            }
            string DITX = lbt00001.Text +Environment.NewLine + str000 +str001 + str002 + str003 + str004 + str005 + str006 + str007 + str008 + str009 + str010 + str011 + str012 + str013 + str014 + strECTX + strNOTE + strATX1 +  totalAdd + strATX2; 
            string NBLK = tbblock03.Text;
            NBLK = NBLK.Replace("'", "^");
            string ABLK = tbblock01.Text;
            ABLK = ABLK.Replace("'", "^");
            sql = sql.Replace("[PTNO]", PTNO);
            sql = sql.Replace("[DITX]", DITX);
            sql = sql.Replace("[ABLK]", ABLK);
            sql = sql.Replace("[NBLK]", NBLK);
            sql = sql.Replace("[OGTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            cmd.ExecuteNonQuery();
        }
        private void selectAdd()
        {

            string sql = "select A101,A102,A103,A201,A202,A203,A301,A302,A303,A401,A402,A403,A501,A502,A503,A601,A602,A603,A701,A702,A703,A801,A802,A803,A901,A902,A903 from PISLNG001 where PTNO ='[PTNO]'";
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

            string sql = "select ABLK, NBLK from PISDIG001 where PTNO ='[PTNO]' and OGTP ='lng'";
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

        private void tb00802_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00805_KeyPress(object sender, KeyPressEventArgs e)
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
                string sql = "select DITX from PISDIG001 where PTNO ='[PTNO]' and OGTP ='lng'";
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

        private void ectb001_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    ectb001.SelectAll();
                }
            }
        }

        private void nttb001_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    nttb001.SelectAll();
                }
            }
        }

        private void tbATX2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    tbATX2.SelectAll();
                }
            }
        }

        private void tbATX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    tbATX1.SelectAll();
                }
            }
        }

        private void tb00702_TextChanged(object sender, EventArgs e)
        {
            
            
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            //if (cb00701.Text.Length >= 80)
            //{
              //  string first;
               // string end;
                //int i = cb00701.Text.Length - 80;
                //first = cb00701.Text.Substring(0, 80);
                //end = cb00701.Text.Substring(80, i);
                //tb00702.Text = first + Environment.NewLine + end;

  //          }
    //        else
      //      {
                
        //    }
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

        private void button3_Click_2(object sender, EventArgs e)
        {
            tb00702.Text = cb00701.Text;
        }

        private void button8_Click(object sender, EventArgs e)
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
