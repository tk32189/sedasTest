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
    public partial class Stomach_gastrectomy : DevExpress.XtraEditors.XtraForm
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public static MySqlConnection Myconn;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        public string HMTP = "stm";
        public string PTNO;
        public string block1;
        public string block2;
        public string totalAdd;

        public Stomach_gastrectomy()
        {
            InitializeComponent();
           
        }

        private void Stomach_gastrectomy_Load(object sender, EventArgs e)
        {
            try
            {
                CoreLibrary core = new CoreLibrary();
                core.InitGridStyle(dataGridView1);

                cbt00001.Items.Add(" ");
                cbt00002.Items.Add(" ");
                cb00101.Items.Add(" ");
                cb00201.Items.Add(" ");
                cb00202.Items.Add(" ");
                cb00203.Items.Add(" ");
                cb00302.Items.Add(" ");
                
                cb00501.Items.Add(" ");
                cb00503.Items.Add(" ");
                cb00601.Items.Add(" ");
                cb00701.Items.Add(" ");
                cb00801.Items.Add(" ");
                cb00901.Items.Add(" ");
                cb01006.Items.Add(" ");
                cb01101.Items.Add(" ");
                cb01201.Items.Add(" ");
                cb01301.Items.Add(" ");

                cb01401.Items.Add(" ");
                


                string strSQL = Ini.strDB;

                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();

                Insertcombo00001();
                Insertcombo00002();


                Insertcombo00101();
                Insertcombo00201();
                Insertcombo00202();
                Insertcombo00203();
                Insertcombo00302();               

                Insertcombo00501();
                Insertcombo00503();
                Insertcombo00601();
                Insertcombo00701();

                Insertcombo00801();

                Insertcombo00901();
                Insertcombo01006();
                Insertcombo01101();
                Insertcombo01201();

                Insertcombo01301();

                Insertcombo01401();


                String sql = "select TIT1, TIT2, TIT3, n0101,n0102, n0201, n0202, n0203, n0301, n0302,n0401,n0402,n0403, n0501, n0502, n0503, n0504, n0505, n0506, n0601, n0701, n0801, n0802, n0803, n0804, n0805, n0901,n0902,n0903, n1001,n1002,n1003,n1004,n1005,n1006,n1101,n1102,n1201,n1202,n1301,n1302,n1401,ECTX,NOTE,ATX1,ATX2,n0806 from PISSTM001 where PTNO ='[PTNO]'";

                sql = sql.Replace("[PTNO]", PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();



                while (dr.Read())
                {

                    cbt00001.SelectedIndex = selectData00001(dr[0].ToString());
                    cbt00002.SelectedIndex = selectData00002(dr[1].ToString());
                    tbt00003.Text = dr[2].ToString().Replace("^", "'");

                    cb00101.SelectedIndex = selectData00101(dr[3].ToString());
                    tb00102.Text = dr[4].ToString().Replace("^", "'");

                    cb00201.SelectedIndex = selectData00201(dr[5].ToString());
                    cb00202.SelectedIndex = selectData00202(dr[6].ToString());
                    cb00203.SelectedIndex = selectData00203(dr[7].ToString());

                    tb00301.Text = dr[8].ToString().Replace("^", "'");
                    cb00302.SelectedIndex = selectData00302(dr[9].ToString());

                    tb00401.Text = dr[10].ToString().Replace("^", "'");
                    tb00402.Text = dr[11].ToString().Replace("^", "'");
                    tb00403.Text = dr[12].ToString().Replace("^", "'");

                    cb00501.SelectedIndex = selectData00501(dr[13].ToString());
                    tb00502.Text = dr[14].ToString().Replace("^", "'");
                    cb00503.SelectedIndex = selectData00503(dr[15].ToString());
                    tb00504.Text = dr[16].ToString().Replace("^", "'");
                    tb00505.Text = dr[17].ToString().Replace("^", "'");
                    tb00506.Text = dr[18].ToString().Replace("^", "'");

                    cb00601.SelectedIndex = selectData00601(dr[19].ToString());


                    cb00701.SelectedIndex = selectData00701(dr[20].ToString());


                    cb00801.SelectedIndex = selectData00801(dr[21].ToString());
                    tb00802.Text = dr[22].ToString().Replace("^", "'");
                    tb00803.Text = dr[23].ToString().Replace("^", "'");
                    tb00804.Text = dr[24].ToString().Replace("^", "'");
                    tb00805.Text = dr[25].ToString().Replace("^", "'");

                    cb00901.SelectedIndex = selectData00901(dr[26].ToString());
                    tb00902.Text = dr[27].ToString().Replace("^", "'");
                    tb00903.Text = dr[28].ToString().Replace("^", "'");

                    tb01001.Text = dr[29].ToString().Replace("^", "'");
                    tb01002.Text = dr[30].ToString().Replace("^", "'");
                    tb01003.Text = dr[31].ToString().Replace("^", "'");
                    tb01004.Text = dr[32].ToString().Replace("^", "'");
                    tb01005.Text = dr[33].ToString().Replace("^", "'");
                    cb01006.SelectedIndex = selectData01006(dr[34].ToString());

                    cb01101.SelectedIndex = selectData01101(dr[35].ToString());
                    tb01102.Text = dr[36].ToString().Replace("^", "'");

                    cb01201.SelectedIndex = selectData01201(dr[37].ToString());
                    tb01202.Text = dr[38].ToString().Replace("^", "'");

                    cb01301.SelectedIndex = selectData01301(dr[39].ToString());
                    tb01302.Text = dr[40].ToString().Replace("^", "'");

                    cb01401.SelectedIndex = selectData01401(dr[41].ToString());
                    


                    tbECTX.Text = dr[42].ToString().Replace("^", "'");
                    tbNOTE.Text = dr[43].ToString().Replace("^", "'");
                    tbATX1.Text = dr[44].ToString().Replace("^", "'");
                    tbATX2.Text = dr[45].ToString().Replace("^", "'");
                    tb00806.Text = dr[46].ToString().Replace("^", "'");
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

            string sql = "select ABLK, NBLK from PISDIG001 where PTNO ='[PTNO]' and OGTP ='stm'";
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

            string sql = "select A101,A102,A103,A201,A202,A203,A301,A302,A303,A401,A402,A403,A501,A502,A503,A601,A602,A603,A701,A702,A703,A801,A802,A803,A901,A902,A903 from PISSTM001 where PTNO ='[PTNO]'";
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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '00001'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '00002'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '00101'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '00201'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '00202'";

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

        private int selectData00203(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '00203'";

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

        private int selectData00302(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '00301'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '00501'";

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


        private int selectData00503(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '00502'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '00601'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '00701'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '00801'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '00901'";

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

        private int selectData01006(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '01001'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '01101'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '01201'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '01301'";

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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'stm'and  SQNO = '01401'";

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
        private void comboBox25_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label64_Click(object sender, EventArgs e)
        {

        }

        private void label25_Click(object sender, EventArgs e)
        {

        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label24_Click(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void comboBox10_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox6_SelectedIndexChanged(object sender, EventArgs e)
        {
           /* if (comboBox6.SelectedItem.ToString() == "out of")
            {
                textBox8.Visible = true;
                label28.Visible = true;
            }
            else
            {
                textBox8.Visible = false;
                label28.Visible = false;
            }*/

        }

        private void label62_Click(object sender, EventArgs e)
        {

        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void comboBox24_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel46_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel44_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel43_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel42_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel41_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label43_Click(object sender, EventArgs e)
        {

        }

        private void panel38_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox22_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            /*
            dataGridView1.Rows.Clear();
            tbATX1.Text = "#. Immunohistochemistry";
            tbATX2.Text = "#. Histochemistry\r\nVanGieson elastic fiber\r\nMucicarmine\r\nMasson Trichrome";

            dataGridView1.Rows.Add("TIF-1", "", "");
            dataGridView1.Rows.Add("CK7", "", "");
            dataGridView1.Rows.Add("p63", "", "");
            dataGridView1.Rows.Add("CK5/6", "", "");
            dataGridView1.Rows.Add("ALK", "", "");
            dataGridView1.Rows.Add("p53", "", "");
             * */
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


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = "select * from PISSTM001 where PTNO = '[PTNO]'";
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
                selectSTM();
                Selectblock();
                drc.Close();
                conn.Close();
            }
            catch (System.Exception ex)
            {
            }
 
        }

        private void selectSTM()
        {

            String sql = "select TIT1, TIT2, TIT3, n0101,n0102, n0201, n0202, n0203, n0301, n0302,n0401,n0402,n0403, n0501, n0502, n0503, n0504, n0505, n0506, n0601, n0701, n0801, n0802, n0803, n0804, n0805, n0901,n0902,n0903, n1001,n1002,n1003,n1004,n1005,n1006,n1101,n1102,n1201,n1202,n1301,n1302,n1401,ECTX,NOTE,ATX1,ATX2,n0806 from PISSTM001 where PTNO ='[PTNO]'";

            sql = sql.Replace("[PTNO]", PTNO);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read())
            {

                cbt00001.SelectedIndex = selectData00001(dr[0].ToString());
                cbt00002.SelectedIndex = selectData00002(dr[1].ToString());
                tbt00003.Text = dr[2].ToString().Replace("^", "'");

                cb00101.SelectedIndex = selectData00101(dr[3].ToString());
                tb00102.Text = dr[4].ToString().Replace("^", "'");

                cb00201.SelectedIndex = selectData00201(dr[5].ToString());
                cb00202.SelectedIndex = selectData00202(dr[6].ToString());
                cb00203.SelectedIndex = selectData00203(dr[7].ToString());

                tb00301.Text = dr[8].ToString().Replace("^", "'");
                cb00302.SelectedIndex = selectData00302(dr[9].ToString());

                tb00401.Text = dr[10].ToString().Replace("^", "'");
                tb00402.Text = dr[11].ToString().Replace("^", "'");
                tb00403.Text = dr[12].ToString().Replace("^", "'");

                cb00501.SelectedIndex = selectData00501(dr[13].ToString());
                tb00502.Text = dr[14].ToString().Replace("^", "'");
                cb00503.SelectedIndex = selectData00503(dr[15].ToString());
                tb00504.Text = dr[16].ToString().Replace("^", "'");
                tb00505.Text = dr[17].ToString().Replace("^", "'");
                tb00506.Text = dr[18].ToString().Replace("^", "'");

                cb00601.SelectedIndex = selectData00601(dr[19].ToString());


                cb00701.SelectedIndex = selectData00701(dr[20].ToString());


                cb00801.SelectedIndex = selectData00801(dr[21].ToString());
                tb00802.Text = dr[22].ToString().Replace("^", "'");
                tb00803.Text = dr[23].ToString().Replace("^", "'");
                tb00804.Text = dr[24].ToString().Replace("^", "'");
                tb00805.Text = dr[25].ToString().Replace("^", "'");

                cb00901.SelectedIndex = selectData00901(dr[26].ToString());
                tb00902.Text = dr[27].ToString().Replace("^", "'");
                tb00903.Text = dr[28].ToString().Replace("^", "'");

                tb01001.Text = dr[29].ToString().Replace("^", "'");
                tb01002.Text = dr[30].ToString().Replace("^", "'");
                tb01003.Text = dr[31].ToString().Replace("^", "'");
                tb01004.Text = dr[32].ToString().Replace("^", "'");
                tb01005.Text = dr[33].ToString().Replace("^", "'");
                cb01006.SelectedIndex = selectData01006(dr[34].ToString());

                cb01101.SelectedIndex = selectData01101(dr[35].ToString());
                tb01102.Text = dr[36].ToString().Replace("^", "'");

                cb01201.SelectedIndex = selectData01201(dr[37].ToString());
                tb01202.Text = dr[38].ToString().Replace("^", "'");

                cb01301.SelectedIndex = selectData01301(dr[39].ToString());
                tb01302.Text = dr[40].ToString().Replace("^", "'");

                cb01401.SelectedIndex = selectData01401(dr[41].ToString());



                tbECTX.Text = dr[42].ToString().Replace("^", "'");
                tbNOTE.Text = dr[43].ToString().Replace("^", "'");
                tbATX1.Text = dr[44].ToString().Replace("^", "'");
                tbATX2.Text = dr[45].ToString().Replace("^", "'");
                tb00806.Text = dr[46].ToString().Replace("^", "'");
                selectAdd();
            }
            dr.Close();

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

            string str0102 = tb00102.Text;
            str0102 = str0102.Replace("'", "^");

            string str0201 = cb00201.Text;
            str0201 = str0201.Replace("'", "^");

            string str0202 = cb00202.Text;
            str0202 = str0202.Replace("'", "^");

            string str0203 = cb00203.Text;
            str0203 = str0203.Replace("'", "^");

            string str0301 = tb00301.Text;
            str0301 = str0301.Replace("'", "^");

            string str0302 = cb00302.Text;
            str0302 = str0302.Replace("'", "^");

            string str0401 = tb00401.Text;
            str0401 = str0401.Replace("'", "^");

            string str0402 = tb00402.Text;
            str0402 = str0402.Replace("'", "^");

            string str0403 = tb00403.Text;
            str0403 = str0403.Replace("'", "^");


            string str0501 = cb00501.Text;
            str0501 = str0501.Replace("'", "^");

            string str0502 = tb00502.Text;
            str0502 = str0502.Replace("'", "^");

            string str0503 = cb00503.Text;
            str0503 = str0503.Replace("'", "^");

            string str0504 = tb00504.Text;
            str0504 = str0504.Replace("'", "^");

            string str0505 = tb00505.Text;
            str0505 = str0505.Replace("'", "^");

            string str0506 = tb00506.Text;
            str0506 = str0506.Replace("'", "^");

            string str0601 = cb00601.Text;
            str0601 = str0601.Replace("'", "^");

            string str0701 = cb00701.Text;
            str0701 = str0701.Replace("'", "^");

            string str0801 = cb00801.Text;
            str0801 = str0801.Replace("'", "^");

            string str0802 = tb00802.Text;
            str0802 = str0802.Replace("'", "^");

            string str0803 = tb00803.Text;
            str0803 = str0803.Replace("'", "^");

            string str0804 = tb00804.Text;
            str0804 = str0804.Replace("'", "^");

            string str0805 = tb00805.Text;
            str0805 = str0805.Replace("'", "^");

            string str0806 = tb00806.Text;
            str0806 = str0806.Replace("'", "^");

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

            string str1004 = tb01004.Text;
            str1004 = str1004.Replace("'", "^");

            string str1005 = tb01005.Text;
            str1005 = str1005.Replace("'", "^");

            string str1006 = cb01006.Text;
            str1006 = str1006.Replace("'", "^");

            string str1101 = cb01101.Text;
            str1101 = str1101.Replace("'", "^");

            string str1102 = tb01102.Text;
            str1102 = str1102.Replace("'", "^");


            string str1201 = cb01201.Text;
            str1201 = str1201.Replace("'", "^");

            string str1202 = tb01202.Text;
            str1202 = str1202.Replace("'", "^");

            string str1301 = cb01301.Text;
            str1301 = str1301.Replace("'", "^");

            string str1302 = tb01302.Text;
            str1302 = str1302.Replace("'", "^");

            string str1401 = cb01401.Text;
            str1401 = str1401.Replace("'", "^");


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

            string sql = "Update pisSTM001 SET SYDT = '[SYDT]', UPDT = '[UPDT]', UPID = '[UPID]', OGTP = '[OGTP]', DITP='[DITP]', TRYN ='[TRYN]', TIT1 = '[TIT1]',TIT2= '[TIT2]',TIT3= '[TIT3]', n0101 = '[n0101]', n0201 = '[n0201]', n0202 = '[n0202]', n0203 = '[n0203]', n0301='[n0301]', n0302='[n0302]', n0401 = '[n0401]',n0402 = '[n0402]',n0403 = '[n0403]', n0501 = '[n0501]', n0502 = '[n0502]', n0503 = '[n0503]', n0504 = '[n0504]', n0505 = '[n0505]', n0506 = '[n0506]',  n0601='[n0601]', n0701='[n0701]', n0801='[n0801]', n0802='[n0802]', n0803='[n0803]', n0804='[n0804]', n0805='[n0805]', n0806='[n0806]',n0901='[n0901]',n0902='[n0902]', n0903='[n0903]', n1001='[n1001]',n1002='[n1002]',n1003='[n1003]',n1004='[n1004]',n1005='[n1005]',n1006='[n1006]',n1101='[n1101]',n1102='[n1102]',n1201='[n1201]',n1202='[n1202]',n1301='[n1301]',n1302='[n1302]',n1401='[n1401]',ECTX='[ECTX]', NOTE='[NOTE]' , ATX1='[ATX1]',ATX2 ='[ATX2]' where PTNO ='[PTNO]'";
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
            sql = sql.Replace("[n0102]", str0102);

            sql = sql.Replace("[n0201]", str0201);
            sql = sql.Replace("[n0202]", str0202);
            sql = sql.Replace("[n0203]", str0203);

            sql = sql.Replace("[n0301]", str0301);
            sql = sql.Replace("[n0302]", str0302);


            sql = sql.Replace("[n0401]", str0401);
            sql = sql.Replace("[n0402]", str0402);
            sql = sql.Replace("[n0403]", str0403);



            sql = sql.Replace("[n0501]", str0501);
            sql = sql.Replace("[n0502]", str0502);
            sql = sql.Replace("[n0503]", str0503);
            sql = sql.Replace("[n0504]", str0504);
            sql = sql.Replace("[n0505]", str0505);
            sql = sql.Replace("[n0506]", str0506);

            sql = sql.Replace("[n0601]", str0601);



            sql = sql.Replace("[n0701]", str0701);

            sql = sql.Replace("[n0801]", str0801);
            sql = sql.Replace("[n0802]", str0802);
            sql = sql.Replace("[n0803]", str0803);
            sql = sql.Replace("[n0804]", str0804);
            sql = sql.Replace("[n0805]", str0805);
            sql = sql.Replace("[n0806]", str0806);


            sql = sql.Replace("[n0901]", str0901);
            sql = sql.Replace("[n0902]", str0902);
            sql = sql.Replace("[n0903]", str0903);

            sql = sql.Replace("[n1001]", str1001);
            sql = sql.Replace("[n1002]", str1002);
            sql = sql.Replace("[n1003]", str1003);
            sql = sql.Replace("[n1004]", str1004);
            sql = sql.Replace("[n1005]", str1005);
            sql = sql.Replace("[n1006]", str1006);

            sql = sql.Replace("[n1101]", str1101);
            sql = sql.Replace("[n1102]", str1102);

            sql = sql.Replace("[n1201]", str1201);
            sql = sql.Replace("[n1202]", str1202);

            sql = sql.Replace("[n1301]", str1301);
            sql = sql.Replace("[n1302]", str1302);

            sql = sql.Replace("[n1401]", str1401);


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

        private void MainDBUpdate()
        {

            string sql = "Update PISDIG001 set  DITX = '[DITX]', ABLK = '[ABLK]',NBLK = '[NBLK]',OGTP = '[OGTP]' where PTNO = '[PTNO]'";
            //string DITX = lbt00001.Text + Environment.NewLine + lbt00002.Text + cbt00001.Text + cbt00002.Text + cbt00003.Text + Environment.NewLine + " " + tbt00004.Text + Environment.NewLine + Environment.NewLine + "  " + lb00101.Text + Environment.NewLine + "    " + cb00101.Text + Environment.NewLine + Environment.NewLine + "  " + lb00201.Text + Environment.NewLine + "    " + cb00201.Text + Environment.NewLine + Environment.NewLine + "  " + lb00301.Text + Environment.NewLine + "    " + cb00301.Text + Environment.NewLine + Environment.NewLine + "  " + lb00401.Text + tb00401.Text + lb00402.Text + tb00402.Text + lb00403.Text + tb00403.Text + lb00404.Text + Environment.NewLine + Environment.NewLine + "  " + lb00501.Text + Environment.NewLine + "    " + cb00501.Text + Environment.NewLine + Environment.NewLine + "  " + lb00601.Text + Environment.NewLine + "    " + cb00601.Text + Environment.NewLine + Environment.NewLine + "  " + lb00701.Text + Environment.NewLine + "    " + cb00701.Text + Environment.NewLine + "    " + tb00702.Text + Environment.NewLine + Environment.NewLine + "  " + lb00801.Text + Environment.NewLine + "    " + lb00802.Text + Environment.NewLine + "     " + cb00801.Text + Environment.NewLine + "      " + lb00803.Text + tb00802.Text + lb00804.Text + Environment.NewLine + "    " + lb00805.Text + Environment.NewLine + "     " + cb00803.Text + Environment.NewLine + "    " + lb00806.Text + Environment.NewLine + "     " + cb00804.Text + Environment.NewLine + "      " + lb00807.Text + tb00805.Text + lb00808.Text + Environment.NewLine + "    " + lb00809.Text + Environment.NewLine + "     " + cb00806.Text + Environment.NewLine + Environment.NewLine + "  " + lb00901.Text + Environment.NewLine + "    " + cb00901.Text + Environment.NewLine + Environment.NewLine + "  " + lb01001.Text + cb01001.Text + Environment.NewLine + Environment.NewLine + "  " + lb01101.Text + cb01101.Text + Environment.NewLine + Environment.NewLine + "  " + lb01201.Text + cb01201.Text + Environment.NewLine + Environment.NewLine + "  " + lb01301.Text + Environment.NewLine + "     " + tb01301.Text + Environment.NewLine + Environment.NewLine + "  " + lb01401.Text + lb01402.Text + tb01401.Text + lb01403.Text + tb01402.Text + lb01404.Text + tb01403.Text + Environment.NewLine + Environment.NewLine + "  " + ectb001.Text + Environment.NewLine + Environment.NewLine + "  " + ntlb001.Text + Environment.NewLine + "  " + nttb001.Text;

            string str00001 = lbt00002.Text + cbt00001.Text + lbt00003.Text;
            str00001 = str00001.Replace("'", "^");
            string str00002 = lbt00004.Text + Environment.NewLine + " " + cbt00002.Text;
            str00002 = str00002.Replace("'", "^");
            string str00003 = " " + tbt00003.Text;
            if (cbt00001.Text == " ")
            {
                str00001 = "";
            }
            if (cbt00002.Text == " ")
            {
                str00002 = "";
                str00003 = lbt00004.Text + Environment.NewLine + " " + tbt00003.Text;
            }

            if (tbt00003.Text == "")
            {
                str00003 = "";
            }

            string str000 = " " + str00001 + str00002 + str00003;
            str000 = str000.Replace("'", "^");
            if (cbt00001.Text == " " && cbt00002.Text == " ")
            {
                str000 = " " + str00003;
            }

            string str00101 = cb00101.Text;
            if (cb00101.Text == " ")
            {
                str00101 = "";
            }

            string str00102 = " " + tb00102.Text;
            if (tb00102.Text == "")
            {
                str00102 = "";
            }

            string str001 =  Environment.NewLine + " " + lb00101.Text + str00101 + str00102;

            if (cb00101.Text == " "&&tb00102.Text=="")
            {
                str001 = "";
            }
            str001 = str001.Replace("'", "^");

            string str00201 = cb00201.Text;
            if (cb00201.Text == " ")
            {
                str00201 = "";
            }
            string str00202 = lb00202.Text  + cb00202.Text;
            if (cb00202.Text == " ")
            {
                str00202 = "";
            }
            string str00203 = lb00203.Text  + cb00203.Text;
            if (cb00203.Text == " ")
            {
                str00203 = "";
            }

            string str002 = Environment.NewLine + " " + lb00201.Text + str00201 + str00202 + str00203;
            if (cb00201.Text == " " && cb00202.Text == " ")
            {
                str002 =  Environment.NewLine + " " + lb00201.Text + cb00203.Text;
            }
            if (cb00201.Text == " " && cb00203.Text == " ")
            {
                str002 = Environment.NewLine + " " + lb00201.Text + cb00202.Text;
            }

            if (cb00202.Text == " " && cb00203.Text == " ")
            {
                str002 =  Environment.NewLine + " " + lb00201.Text +cb00101.Text;
            }

            if (cb00201.Text == " "&& cb00202.Text ==" "&&cb00203.Text ==" ")
            {
                str002 = "";
            }
            str002 = str002.Replace("'", "^");

            string str00301 = lb00302.Text + tb00301.Text;
           
            string str00302 = Environment.NewLine + "                       " + lb00303.Text + cb00302.Text;
            if (tb00301.Text == "")
            {
                str00301 = "";
                str00302 = lb00303.Text + cb00302.Text;
            }
            if (cb00302.Text == " ")
            {
                str00302 = "";
            }
                
            string str003 = Environment.NewLine + " " + lb00301.Text + str00301 + str00302;

            if (tb00301.Text == "" && cb00302.Text ==" ")
            {
                str003 = "";
            }
            str003 = str003.Replace("'", "^");



            string str00401 = tb00401.Text + lb00402.Text;
            string str00402 = tb00402.Text + lb00403.Text;
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

            string str004 = Environment.NewLine + " " + lb00401.Text + str00401 + str00402 + str00403 + lb00404.Text;
            if (tb00402.Text == "" && tb00401.Text == "" && tb00403.Text == "")
            {
                str004 = "";
            }

            string str00501 = lb00502.Text + cb00501.Text;
            if (cb00501.Text == " ")
            {
                str00501 = "";
            }
            string str00502 = lb00503.Text + tb00502.Text + lb00504.Text;
            if (tb00502.Text == "")
            {
                str00502 = "";
            }
            string str00503 = lb00505.Text + cb00503.Text + lb00506.Text;
            if (cb00503.Text == " ")
            {
                str00503 = "";
            }
            string str00504 = tb00504.Text + lb00507.Text;
            if (tb00504.Text == "")
            {
                str00504 = "";
            }
            string str00505 = lb00508.Text + tb00505.Text + lb00509.Text;
            if (tb00505.Text == "")
            {
                str00505 = "";
            }
            string str00506 = Environment.NewLine + "       " + tb00506.Text;
            string str005 =  Environment.NewLine + " " + lb00501.Text + Environment.NewLine + "      " + str00501 + str00502 + Environment.NewLine + "      " + str00503 + str00504 + Environment.NewLine + "      " + str00505 + str00506;
            str005 = str005.Replace("'", "^");

            if (cb00501.Text == " " && tb00502.Text == "")
            {
                str005 = Environment.NewLine + " " + lb00501.Text + Environment.NewLine + "      " + str00503 + str00504 + Environment.NewLine + "      " + str00505 + str00506;
            }

            if (cb00503.Text == " " && tb00504.Text == "")
            {
                str005 = Environment.NewLine + " " + lb00501.Text + Environment.NewLine + "      " + str00501 + str00502 + Environment.NewLine + "      " + str00505 + str00506;
            }

            if (tb00505.Text == "")
            {
                str005 =  Environment.NewLine + " " + lb00501.Text + Environment.NewLine + "      " + str00503 + str00504 + str00506 ;
            }
            if (cb00501.Text == " " && tb00502.Text == "" && cb00503.Text == " " && tb00504.Text == "" && tb00505.Text == "")
            {
                str005 =  Environment.NewLine + " " + lb00501.Text + str00506;
            }

            if (cb00501.Text == " " && tb00502.Text == "" && cb00503.Text == " " && tb00504.Text == "" && tb00505.Text == "" && tb00506.Text =="")
            {
                str005 = "";
            }

            string str006 = Environment.NewLine + " " + lb00601.Text + cb00601.Text;

            if (cb00601.Text == " ")
            {
                str006 = "";
            }
            str006 = str006.Replace("'", "^");

            string str007 =  Environment.NewLine + " " + lb00701.Text + cb00701.Text;

            if (cb00701.Text == " ")
            {
                str007 = "";
            }
            str007 = str007.Replace("'", "^");


            string str00801 = Environment.NewLine + "      " + cb00801.Text;
            if (cb00801.Text == " ")
            {
                str00801 = "";
            }
            string str00802 = Environment.NewLine + "        " + lb00802.Text + tb00802.Text + lb00803.Text;
            if (tb00802.Text == "")
            {
                str00802 = "";
            }
            string str00803 = Environment.NewLine + "        " + lb00804.Text + tb00803.Text + lb00805.Text;
            if (tb00803.Text == "")
            {
                str00803 = "";
            }
            string str00804 = Environment.NewLine + "        " + lb00806.Text + tb00804.Text;
            if (tb00804.Text == "")
            {
                str00804 = "";
            }
            string str00805 = Environment.NewLine + "        " + lb00807.Text + tb00805.Text;
            if (tb00805.Text == "")
            {
                str00805 = "";
            }
            string str00806 = " " + lb00808.Text + tb00806.Text + lb00809.Text;
            if (tb00806.Text == "")
            {
                str00806 = "";
            }

            string str008 =  Environment.NewLine + " " + lb00801.Text +str00801 + str00806 + str00802 + str00803 + str00804 + str00805;

            if (cb00801.Text == " " && tb00802.Text == "" && tb00803.Text == "" && tb00804.Text == "" && tb00805.Text == "")
            {
                str008 = "";
            }
            str008 = str008.Replace("'", "^");
            //
            string str00901 = Environment.NewLine + "      " + cb00901.Text;
            if (cb00901.Text == " ")
            {
                str00901 = "";
            }
            string str00902 = Environment.NewLine + "      " + lb00902.Text + lb00906.Text + " " + tb00902.Text + lb00903.Text;

            string str00903 = lb00904.Text + tb00903.Text + lb00905.Text;

            if (tb00902.Text == "")
            {
                str00902 = "";
                str00903 = Environment.NewLine + "      " + lb00904.Text + tb00903.Text + lb00905.Text;
            }
            if (tb00903.Text == "")
            {
                str00903 = "";
            }
            string str009 =  Environment.NewLine + " " + lb00901.Text + str00901 + str00902 + str00903;
            str009 = str009.Replace("'", "^");
            if (cb00901.Text == " " && tb00902.Text == "" && tb00903.Text == "")
            {
                str009 = "";
            }

            string str01001 =  lb01002.Text + tb01001.Text + lb01003.Text + " " + lb01009.Text;
            string str01002 = " " + lb01004.Text + tb01002.Text ;
            string str01003 = lb01005.Text + tb01003.Text + lb01006.Text;
            string str01004 = lb01007.Text + tb01004.Text +  ",";
            string str01005 = lb01008.Text + tb01005.Text;
            string str01006 = " " + lb01010.Text + cb01006.Text;
            if (tb01001.Text == "")
            {
                str01001 = "";
            }
            if (tb01002.Text == "" )
            {
                str01002 = "";
            }
            if (tb01003.Text == "")
            {
                str01003 = "";
            }
            if (tb01004.Text =="")
            {
                str01004 = "";
            }
            if (tb01005.Text == "")
            {
                str01005 = "";
            }
            if (cb01006.Text == " ")
            {
                str01006 = "";
            }
            string str010 =  Environment.NewLine + " " + lb01001.Text + Environment.NewLine + "        " + str01001 + str01002+ str01003 + str01006 + Environment.NewLine +"        " + str01004 + str01005;
            if (tb01001.Text == "" && tb01002.Text == "" && tb01003.Text == "")
            {
                str010 = Environment.NewLine + " " + lb01001.Text + Environment.NewLine + "        " + str01004 + str01005;
            }
            if (tb01004.Text == "" && tb01005.Text == "")
            {
                str010 =  Environment.NewLine + " " + lb01001.Text + Environment.NewLine + "        " + str01001 + str01002 + str01003 + str01006;
            }
            if (tb01001.Text == "" && tb01002.Text == "" && tb01003.Text == "" && tb01004.Text == "" && tb01005.Text == ""&& cb01006.Text ==" ")
            {
                str010 = "";
            }
            str010 = str010.Replace("'", "^");

            string str01101 = cb01101.Text;
            if (cb01101.Text == " " )
            {
                str01101 = "";
            }
            string str01102 = " " + tb01102.Text;
            if (tb01102.Text == "")
            {
                str01102 = "";
            }
           
            string str011 =  Environment.NewLine + " " + lb01101.Text + str01101 + str01102 ;

            str011 = str011.Replace("'", "^");
            if (cb01101.Text == " " && tb01102.Text == "" )
            {
                str011 = "";
            }

            string str01201 = cb01201.Text;
            if (cb01201.Text == " ")
            {
                str01201 = "";
            }
            string str01202 = " " + tb01202.Text;
            if (tb01202.Text == "")
            {
                str01202 = "";
            }

            string str012 =  Environment.NewLine + " " + lb01201.Text + str01201 + str01202;

            str012 = str012.Replace("'", "^");
            if (cb01201.Text == " " && tb01202.Text == "")
            {
                str012 = "";
            }

            string str01301 = cb01301.Text;
            if (cb01301.Text == " ")
            {
                str01301 = "";
            }
            string str01302 = " " + tb01302.Text;
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

            
            string str014 =  Environment.NewLine + " " + lb01401.Text + cb01401.Text;
            str014 = str014.Replace("'", "^");
            if (cb01401.Text == " ")
            {
                str014 = "";
            }

            string strTBECTX = tbECTX.Text.Replace("\r\n", "\r\n ");
            string strECTX = Environment.NewLine + " " + strTBECTX;
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

                totalAdd =  ADD[1] + ADD[2] + ADD[3] + ADD[4] +  ADD[5] +  ADD[6] +  ADD[7] +  ADD[8];
                totalAdd = totalAdd.Replace("'", "^");
            }
            string DITX = lbt00001.Text + Environment.NewLine + str000 + str001 + str002 + str003 + str004 + str005 + str006 + str007 + str008 + str009 + str010 + str011 + str012 + str013 + str014 + strECTX + strNOTE + strATX1 + totalAdd + strATX2;
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

                string sql = String.Format("Update PISSTM001 set {0}='{1}', {2} = '{3}',{4}='{5}' where PTNO = '{6}'", ADD1, str1, ADD2, str2, ADD3, str3, PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
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


            string str0101 = cb00101.Text;
            str0101 = str0101.Replace("'", "^");

            string str0102 = tb00102.Text;
            str0102 = str0102.Replace("'", "^");

            string str0201 = cb00201.Text;
            str0201 = str0201.Replace("'", "^");

            string str0202 = cb00202.Text;
            str0202 = str0202.Replace("'", "^");

            string str0203 = cb00203.Text;
            str0203 = str0203.Replace("'", "^");

            string str0301 = tb00301.Text;
            str0301 = str0301.Replace("'", "^");

            string str0302 = cb00302.Text;
            str0302 = str0302.Replace("'", "^");
            
            string str0401 = tb00401.Text;
            str0401 = str0401.Replace("'", "^");

            string str0402 = tb00402.Text;
            str0402 = str0402.Replace("'", "^");

            string str0403 = tb00403.Text;
            str0403 = str0403.Replace("'", "^");


            string str0501 = cb00501.Text;
            str0501 = str0501.Replace("'", "^");

            string str0502 = tb00502.Text;
            str0502 = str0502.Replace("'", "^");

            string str0503 = cb00503.Text;
            str0503 = str0503.Replace("'", "^");

            string str0504 = tb00504.Text;
            str0504 = str0504.Replace("'", "^");

            string str0505 = tb00505.Text;
            str0505 = str0505.Replace("'", "^");

            string str0506 = tb00506.Text;
            str0506 = str0506.Replace("'", "^");

            string str0601 = cb00601.Text;
            str0601 = str0601.Replace("'", "^");
            
            string str0701 = cb00701.Text;
            str0701 = str0701.Replace("'", "^");
            
            string str0801 = cb00801.Text;
            str0801 = str0801.Replace("'", "^");

            string str0802 = tb00802.Text;
            str0802 = str0802.Replace("'", "^");

            string str0803 = tb00803.Text;
            str0803 = str0803.Replace("'", "^");

            string str0804 = tb00804.Text;
            str0804 = str0804.Replace("'", "^");

            string str0805 = tb00805.Text;
            str0805 = str0805.Replace("'", "^");

            string str0806 = tb00806.Text;
            str0806 = str0806.Replace("'", "^");

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

            string str1004 = tb01004.Text;
            str1004 = str1004.Replace("'", "^");

            string str1005 = tb01005.Text;
            str1005 = str1005.Replace("'", "^");

            string str1006 = cb01006.Text;
            str1006 = str1006.Replace("'", "^");

            string str1101 = cb01101.Text;
            str1101 = str1101.Replace("'", "^");

            string str1102 = tb01102.Text;
            str1102 = str1102.Replace("'", "^");


            string str1201 = cb01201.Text;
            str1201 = str1201.Replace("'", "^");

            string str1202 = tb01202.Text;
            str1202 = str1202.Replace("'", "^");

            string str1301 = cb01301.Text;
            str1301 = str1301.Replace("'", "^");

            string str1302 = tb01302.Text;
            str1302 = str1302.Replace("'", "^");

            string str1401 = cb01401.Text;
            str1401 = str1401.Replace("'", "^");


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


            string sql = "INSERT INTO pisSTM001 ( SYDT, UPDT, UPID, PTNO, OGTP, DITP, TRYN, TIT1, TIT2,TIT3, n0101,n0102, n0201,n0202,n0203, n0301,n0302, n0401,n0402,n0403, n0501, n0502,n0503,n0504,n0505,n0506,n0601, n0701, n0801, n0802,n0803,n0804,n0805,n0806,n0901,n0902, n0903,n1001,n1002,n1003,n1004,n1005,n1006, n1101,n1102,n1201, n1202,n1301,n1302,n1401, ECTX, NOTE,ATX1,ATX2) VALUES (  '[SYDT]', '[UPDT]', '[UPID]', '[PTNO]', '[OGTP]', '[DITP]', '[TRYN]', '[TIT1]', '[TIT2]','[TIT3]','[n0101]','[n0102]', '[n0201]','[n0202]','[n0203]', '[n0301]','[n0302]', '[n0401]','[n0402]','[n0403]', '[n0501]', '[n0502]','[n0503]','[n0504]','[n0505]','[n0506]','[n0601]', '[n0701]', '[n0801]', '[n0802]','[n0803]','[n0804]','[n0805]','[n0806]','[n0901]','[n0902]', '[n0903]','[n1001]','[n1002]','[n1003]','[n1004]','[n1005]', '[n1006]', '[n1101]','[n1102]','[n1201]','[n1202]','[n1301]','[n1302]','[n1401]', '[ECTX]', '[NOTE]','[ATX1]','[ATX2]')";
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
            sql = sql.Replace("[n0102]", str0102);

            sql = sql.Replace("[n0201]", str0201);
            sql = sql.Replace("[n0202]", str0202);
            sql = sql.Replace("[n0203]", str0203);

            sql = sql.Replace("[n0301]", str0301);
            sql = sql.Replace("[n0302]", str0302);


            sql = sql.Replace("[n0401]", str0401);
            sql = sql.Replace("[n0402]", str0402);
            sql = sql.Replace("[n0403]", str0403);



            sql = sql.Replace("[n0501]", str0501);
            sql = sql.Replace("[n0502]", str0502);
            sql = sql.Replace("[n0503]", str0503);
            sql = sql.Replace("[n0504]", str0504);
            sql = sql.Replace("[n0505]", str0505);
            sql = sql.Replace("[n0506]", str0506);

            sql = sql.Replace("[n0601]", str0601);
           


            sql = sql.Replace("[n0701]", str0701);

            sql = sql.Replace("[n0801]", str0801);
            sql = sql.Replace("[n0802]", str0802);
            sql = sql.Replace("[n0803]", str0803);
            sql = sql.Replace("[n0804]", str0804);
            sql = sql.Replace("[n0805]", str0805);
            sql = sql.Replace("[n0806]", str0806);


            sql = sql.Replace("[n0901]", str0901);
            sql = sql.Replace("[n0902]", str0902);
            sql = sql.Replace("[n0903]", str0903);

            sql = sql.Replace("[n1001]", str1001);
            sql = sql.Replace("[n1002]", str1002);
            sql = sql.Replace("[n1003]", str1003);
            sql = sql.Replace("[n1004]", str1004);
            sql = sql.Replace("[n1005]", str1005);
            sql = sql.Replace("[n1006]", str1006);

            sql = sql.Replace("[n1101]", str1101);
            sql = sql.Replace("[n1102]", str1102);
            
            sql = sql.Replace("[n1201]", str1201);
            sql = sql.Replace("[n1202]", str1202);

            sql = sql.Replace("[n1301]", str1301);
            sql = sql.Replace("[n1302]", str1302);

            sql = sql.Replace("[n1401]", str1401);
            

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
        private void reset()
        {
            cbt00001.Text = " ";
            cbt00002.Text = " ";
            tbt00003.Text = " Gastric Cancer";

            cb00101.Text = " ";
            tb00102.Text = "";


            cb00201.Text = " ";
            cb00202.Text = " ";
            cb00203.Text = " ";

            tb00301.Text = "";
            cb00302.Text = " ";

            tb00401.Text = "";
            tb00402.Text = "";
            tb00403.Text = "";

            cb00501.Text = " ";
            cb00503.Text = " ";
            tb00502.Text = "";
            tb00504.Text = "";
            tb00505.Text = "";
            tb00506.Text = "";


            cb00601.Text = " ";

            cb00701.Text = " ";

            cb00801.Text = " ";
            tb00802.Text = "";
            tb00803.Text = "";
            tb00804.Text = "";
            tb00805.Text = "";
            tb00806.Text = "";

            cb00901.Text = " ";
            tb00902.Text = "";
            tb00903.Text = "";


            tb01001.Text = "";
            tb01002.Text = "";
            tb01003.Text = "";
            tb01004.Text = "";
            tb01005.Text = "";
            cb01006.Text = " ";

            cb01101.Text = " ";
            tb01102.Text = "";

            cb01201.Text = " ";
            tb01202.Text = "";

            cb01301.Text = " ";
            tb01302.Text = "";

            cb01401.Text = " ";
            tbECTX.Text = "";
            tbNOTE.Text = "";

            tbblock01.Text = "";
            tbblock03.Text = "";
            tbATX1.Text = "";
            tbATX2.Text = "";
            dataGridView1.Rows.Clear();
            cbt00001.Select();
        }
        private void Stomach_gastrectomy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Myconn.Close();
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


        private void Insertcombo00203()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00203";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00203.Items.Add(dr.GetString(0));
            }
            dr.Close();

        }

        private void Insertcombo00302()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00301";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00302.Items.Add(dr.GetString(0));
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

        private void Insertcombo00503()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00502";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00503.Items.Add(dr.GetString(0));
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

        private void Insertcombo01006()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01001";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01006.Items.Add(dr.GetString(0));
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

        private void button7_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "select DITX from PISDIG001 where PTNO ='[PTNO]' and OGTP ='STM'";
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
                    string sql = "delete from pisSTM001 where ptno = '[PTNO]'";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
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

        private void tb00504_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00505_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00803_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00902_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00903_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button3_Click_1(object sender, EventArgs e)
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

        private void dataGridView1_CellClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
        }

        private void lb00902_Click(object sender, EventArgs e)
        {

        }

        private void lb00906_Click(object sender, EventArgs e)
        {

        }

        private void tb00902_TextChanged(object sender, EventArgs e)
        {

        }

        private void button4_Click_1(object sender, EventArgs e)
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

        //

    }
}
