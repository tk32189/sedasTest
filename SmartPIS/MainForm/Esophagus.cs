﻿using System;
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
    public partial class Esophagus_ : DevExpress.XtraEditors.XtraForm
    {
        DataSet ds = new DataSet();
        DataTable dt = new DataTable();
        public static MySqlConnection Myconn;
        MySqlDataAdapter adp = new MySqlDataAdapter();
        public string HMTP = "esp";
        public string PTNO;
        public string block1;
        public string block2;
        public string totalAdd;
        
        public Esophagus_()
        {
            InitializeComponent();
        }

        private void comboBox12_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox10_TextChanged(object sender, EventArgs e)
        {

        }

        private void Esophagus__Load(object sender, EventArgs e)
        {
            try
            {
                CoreLibrary core = new CoreLibrary();
                core.InitGridStyle(dataGridView1);

                cb00101.Items.Add(" ");
                cb00301.Items.Add(" ");
                cb00401.Items.Add(" ");
                cb00501.Items.Add(" ");
                cb00601.Items.Add(" ");
                cb00701.Items.Add(" ");
                cb00704.Items.Add(" ");
                cb00801.Items.Add(" ");
                cb00805.Items.Add(" ");
                cb00901.Items.Add(" ");
                cb00902.Items.Add(" ");
                cb01001.Items.Add(" ");
                cb01002.Items.Add(" ");
                cb01101.Items.Add(" ");
                cb01102.Items.Add(" ");

                string strSQL = Ini.strDB;

                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();

                Insertcombo00101();
                Insertcombo00301();
                Insertcombo00401();
                Insertcombo00501();
                Insertcombo00601();
                Insertcombo00701();
                Insertcombo00704();
                Insertcombo00801();
                Insertcombo00805();
                Insertcombo00901();
                Insertcombo00902();
                Insertcombo01001();
                Insertcombo01002();
                Insertcombo01101();
                Insertcombo01102();

                String sql = "select TIT1, TIT2, n0101,n0102, n0201,n0202,n0203, n0301, n0401, n0402, n0501, n0601, n0602,n0701, n0702,n0703,n0704,n0705, n0801, n0802, n0803, n0804, n0805, n0901,n0902,n1001,n1002, n1101,n1102, n1201,ECTX,NOTE,ATX1,ATX2,n0603 from PISESP001 where PTNO ='[PTNO]'";

                sql = sql.Replace("[PTNO]", PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();



                while (dr.Read())
                {
                    tbt00001.Text = dr[0].ToString().Replace("^", "'");
                    tbt00002.Text = dr[1].ToString().Replace("^", "'");

                    cb00101.SelectedIndex = selectData00101(dr[2].ToString());
                    tb00102.Text = dr[3].ToString().Replace("^", "'");

                    tb00201.Text = dr[4].ToString().Replace("^", "'");
                    tb00202.Text = dr[5].ToString().Replace("^", "'");
                    tb00203.Text = dr[6].ToString().Replace("^", "'");

                    cb00301.SelectedIndex = selectData00301(dr[7].ToString());

                    cb00401.SelectedIndex = selectData00401(dr[8].ToString());
                    tb00402.Text = dr[9].ToString().Replace("^", "'");

                    cb00501.SelectedIndex = selectData00501(dr[10].ToString());

                    cb00601.SelectedIndex = selectData00601(dr[11].ToString());
                    tb00602.Text = dr[12].ToString().Replace("^", "'");

                    cb00701.SelectedIndex = selectData00701(dr[13].ToString());
                    tb00702.Text = dr[14].ToString().Replace("^", "'");
                    tb00703.Text = dr[15].ToString().Replace("^", "'");
                    cb00704.SelectedIndex = selectData00704(dr[16].ToString());
                    tb00705.Text = dr[17].ToString().Replace("^", "'");

                    cb00801.SelectedIndex = selectData00801(dr[18].ToString());

                    tb00802.Text = dr[19].ToString().Replace("^", "'");
                    tb00803.Text = dr[20].ToString().Replace("^", "'");
                    tb00804.Text = dr[21].ToString().Replace("^", "'");
                    cb00805.SelectedIndex = selectData00805(dr[22].ToString());


                    cb00901.SelectedIndex = selectData00901(dr[23].ToString());
                    cb00902.SelectedIndex = selectData00902(dr[24].ToString());

                    cb01001.SelectedIndex = selectData01001(dr[25].ToString());
                    cb01002.SelectedIndex = selectData01002(dr[26].ToString());

                    cb01101.SelectedIndex = selectData01101(dr[27].ToString());
                    cb01102.SelectedIndex = selectData01102(dr[28].ToString());

                    tb01201.Text = dr[29].ToString().Replace("^", "'");
                    tbECTX.Text = dr[30].ToString().Replace("^", "'");
                    tbNOTE.Text = dr[31].ToString().Replace("^", "'");
                    tbATX1.Text = dr[32].ToString().Replace("^", "'");
                    tbATX2.Text = dr[33].ToString().Replace("^", "'");
                    tb00603.Text = dr[34].ToString().Replace("^", "'");
                    selectAdd();
                }
                dr.Close();

                Selectblock();
            }
            catch (System.Exception ex)
            {
            }
             
        }
        private int selectData00101(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '00101'";
           
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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '00301'";
          
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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '00401'";
           
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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '00501'";
           
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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '00601'";
           
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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '00701'";
            
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
        private int selectData00704(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '00702'";
           
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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '00801'";
           
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
        private int selectData00805(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '00802'";
            
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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '00901'";
           
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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '00902'";
           
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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '01001'";
            
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
        private int selectData01002(string combo)
        {
            int n = 0;
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '01002'";
            
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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '01101'";
          
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
            String sql = "select EXOD from PISADM002 where EXTX = '" + combo + "' and HMTP = 'ESP'and  SQNO = '01102'";
           
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
        private void Insertcombo00704()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00702";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00704.Items.Add(dr.GetString(0));
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
                string IT00801 = dr.GetString(0).Replace("^", "'");
                cb00801.Items.Add(IT00801);
            }
            dr.Close();

        }
        private void Insertcombo00805()
        {
            String sql = Ini.DBSelect;
            string SQNO = "00802";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb00805.Items.Add(dr.GetString(0));
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
        private void Insertcombo01002()
        {
            String sql = Ini.DBSelect;
            string SQNO = "01002";
            sql = sql.Replace("[SQNO]", SQNO);
            sql = sql.Replace("[HMTP]", HMTP);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                cb01002.Items.Add(dr.GetString(0));
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

        private void selectAdd()
        {

            string sql = "select A101,A102,A103,A201,A202,A203,A301,A302,A303,A401,A402,A403,A501,A502,A503,A601,A602,A603,A701,A702,A703,A801,A802,A803,A901,A902,A903 from PISESP001 where PTNO ='[PTNO]'";
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
        private void Selectblock()
        {

            string sql = "select ABLK, NBLK from PISDIG001 where PTNO ='[PTNO]' and OGTP ='ESP'";
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
             */
        }

       

        private void button4_Click_1(object sender, EventArgs e)
        {
            try
            {
                String sql = "select * from PISESP001 where PTNO = '[PTNO]'";
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
                selectESP();
                Selectblock();
                drc.Close();
                conn.Close();
            }
            catch (System.Exception ex)
            {
            }
        }

        private void UpdateDB()
        {

            string Titlestr0001 = tbt00001.Text;
            Titlestr0001 = Titlestr0001.Replace("'", "^");

            string Titlestr0002 = tbt00002.Text;
            Titlestr0002 = Titlestr0002.Replace("'", "^");

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

            string str0601 = cb00601.Text;
            str0601 = str0601.Replace("'", "^");

            string str0602 = tb00602.Text;
            str0602 = str0602.Replace("'", "^");

            string str0603 = tb00603.Text;
            str0603 = str0603.Replace("'", "^");

            string str0701 = cb00701.Text;
            str0701 = str0701.Replace("'", "^");

            string str0702 = tb00702.Text;
            str0702 = str0702.Replace("'", "^");

            string str0703 = tb00703.Text;
            str0703 = str0703.Replace("'", "^");

            string str0704 = cb00704.Text;
            str0704 = str0704.Replace("'", "^");

            string str0705 = tb00705.Text;
            str0705 = str0705.Replace("'", "^");

            string str0801 = cb00801.Text;
            str0801 = str0801.Replace("'", "^");
            string str0802 = tb00802.Text;
            str0802 = str0802.Replace("'", "^");
            string str0803 = tb00803.Text;
            str0803 = str0803.Replace("'", "^");
            string str0804 = tb00804.Text;
            str0804 = str0804.Replace("'", "^");
            string str0805 = cb00805.Text;
            str0805 = str0805.Replace("'", "^");
            string str0901 = cb00901.Text;
            str0901 = str0901.Replace("'", "^");
            string str0902 = cb00902.Text;
            str0902 = str0902.Replace("'", "^");
            string str1001 = cb01001.Text;
            str1001 = str1001.Replace("'", "^");
            string str1002 = cb01002.Text;
            str1002 = str1002.Replace("'", "^");

            string str1101 = cb01101.Text;
            str1101 = str1101.Replace("'", "^");
            string str1102 = cb01102.Text;
            str1102 = str1102.Replace("'", "^");

            string str1201 = tb01201.Text;
            str1201 = str1201.Replace("'", "^");

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

            string sql = "Update pisESP001 SET SYDT = '[SYDT]', UPDT = '[UPDT]', UPID = '[UPID]', OGTP = '[OGTP]', DITP='[DITP]', TRYN ='[TRYN]', TIT1 = '[TIT1]',TIT2= '[TIT2]', n0101 = '[n0101]', n0102 = '[n0102]',n0201 = '[n0201]',  n0202 = '[n0202]', n0203 = '[n0203]',n0301='[n0301]', n0401 = '[n0401]', n0402 = '[n0402]', n0501 = '[n0501]', n0601='[n0601]', n0602='[n0602]', n0603='[n0603]', n0701='[n0701]', n0702='[n0702]',n0703='[n0703]',n0704='[n0704]',n0705='[n0705]', n0801='[n0801]', n0802='[n0802]', n0803='[n0803]', n0804='[n0804]', n0805='[n0805]', n0901='[n0901]', n0902='[n0902]',n1001='[n1001]',n1002='[n1002]', n1101='[n1101]',n1102='[n1102]', n1201='[n1201]', ECTX='[ECTX]', NOTE='[NOTE]' , ATX1='[ATX1]',ATX2 ='[ATX2]' where PTNO ='[PTNO]'";
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
            sql = sql.Replace("[n0102]", str0102);
            
            sql = sql.Replace("[n0201]", str0201);
            sql = sql.Replace("[n0202]", str0202);
            sql = sql.Replace("[n0203]", str0203);

            sql = sql.Replace("[n0301]", str0301);
            sql = sql.Replace("[n0401]", str0401);
            sql = sql.Replace("[n0402]", str0402);
            
            sql = sql.Replace("[n0501]", str0501);
            sql = sql.Replace("[n0601]", str0601);
            sql = sql.Replace("[n0602]", str0602);
            sql = sql.Replace("[n0603]", str0603);

            sql = sql.Replace("[n0701]", str0701);
            sql = sql.Replace("[n0702]", str0702);
            sql = sql.Replace("[n0703]", str0703);
            sql = sql.Replace("[n0704]", str0704);
            sql = sql.Replace("[n0705]", str0705);

            sql = sql.Replace("[n0801]", str0801);
            sql = sql.Replace("[n0802]", str0802);
            sql = sql.Replace("[n0803]", str0803);
            sql = sql.Replace("[n0804]", str0804);
            sql = sql.Replace("[n0805]", str0805);
           
            sql = sql.Replace("[n0901]", str0901);
            sql = sql.Replace("[n0902]", str0902);
            sql = sql.Replace("[n1001]", str1001);
            sql = sql.Replace("[n1002]", str1002);
            sql = sql.Replace("[n1101]", str1101);
            sql = sql.Replace("[n1102]", str1102);
            sql = sql.Replace("[n1201]", str1201);
           
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

            string str0601 = cb00601.Text;
            str0601 = str0601.Replace("'", "^");

            string str0602 = tb00602.Text;
            str0602 = str0602.Replace("'", "^");

            string str0603 = tb00603.Text;
            str0603 = str0603.Replace("'", "^");

            string str0701 = cb00701.Text;
            str0701 = str0701.Replace("'", "^");

            string str0702 = tb00702.Text;
            str0702 = str0702.Replace("'", "^");

            string str0703 = tb00703.Text;
            str0703 = str0703.Replace("'", "^");

            string str0704 = cb00704.Text;
            str0704 = str0704.Replace("'", "^");

            string str0705 = tb00705.Text;
            str0705 = str0705.Replace("'", "^");

            string str0801 = cb00801.Text;
            str0801 = str0801.Replace("'", "^");
            string str0802 = tb00802.Text;
            str0802 = str0802.Replace("'", "^");
            string str0803 = tb00803.Text;
            str0803 = str0803.Replace("'", "^");
            string str0804 = tb00804.Text;
            str0804 = str0804.Replace("'", "^");
            string str0805 = cb00805.Text;
            str0805 = str0805.Replace("'", "^");
            string str0901 = cb00901.Text;
            str0901 = str0901.Replace("'", "^");
            string str0902 = cb00902.Text;
            str0902 = str0902.Replace("'", "^");
            string str1001 = cb01001.Text;
            str1001 = str1001.Replace("'", "^");
            string str1002 = cb01002.Text;
            str1002 = str1002.Replace("'", "^");

            string str1101 = cb01101.Text;
            str1101 = str1101.Replace("'", "^");
            string str1102 = cb01102.Text;
            str1102 = str1102.Replace("'", "^");

            string str1201 = tb01201.Text;
            str1201 = str1201.Replace("'", "^");

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

            string sql = "INSERT INTO pisESP001 ( SYDT, UPDT, UPID, PTNO, OGTP, DITP, TRYN, TIT1, TIT2, n0101, n0102, n0201,n0202,n0203,n0301, n0401, n0402, n0501, n0601,n0602, n0603, n0701, n0702,n0703,n0704,n0705, n0801, n0802, n0803, n0804, n0805, n0901,n0902, n1001,n1002, n1101,n1102, n1201, ECTX, NOTE,ATX1,ATX2) VALUES ( '[SYDT]', '[UPDT]', '[UPID]', '[PTNO]', '[OGTP]', '[DITP]', '[TRYN]','[TIT1]', '[TIT2]', '[0101]','[0102]', '[0201]', '[0202]','[0203]','[0301]', '[0401]', '[0402]', '[0501]', '[0601]','[0602]','[0603]', '[0701]', '[0702]','[0703]','[0704]','[0705]', '[0801]', '[0802]', '[0803]', '[0804]', '[0805]','[0901]','[0902]', '[1001]','[1002]', '[1101]','[1102]', '[1201]', '[ECTX]','[NOTE]','[ATX1]','[ATX2]')";
            sql = sql.Replace("[SYDT]", DateTime.Now.ToString("yyyyMMdd"));
            sql = sql.Replace("[UPDT]", DateTime.Now.ToString("yyyyMMdd"));
            sql = sql.Replace("[UPID]", "");
            sql = sql.Replace("[PTNO]", PTNO);
            sql = sql.Replace("[OGTP]", HMTP);
            sql = sql.Replace("[DITP]", "");
            sql = sql.Replace("[TRYN]", "N");
            sql = sql.Replace("[TIT1]", Titlestr0001);
            sql = sql.Replace("[TIT2]", Titlestr0002);
           
            sql = sql.Replace("[0101]", str0101);
            sql = sql.Replace("[0102]", str0102);

            sql = sql.Replace("[0201]", str0201);
            sql = sql.Replace("[0202]", str0202);
            sql = sql.Replace("[0203]", str0203);
            sql = sql.Replace("[0301]", str0301);
            sql = sql.Replace("[0401]", str0401);
            sql = sql.Replace("[0402]", str0402);
          
            sql = sql.Replace("[0501]", str0501);
            sql = sql.Replace("[0601]", str0601);
            sql = sql.Replace("[0602]", str0602);
            sql = sql.Replace("[0603]", str0603);

            sql = sql.Replace("[0701]", str0701);
            sql = sql.Replace("[0702]", str0702);
            sql = sql.Replace("[0703]", str0703);
            sql = sql.Replace("[0704]", str0704);
            sql = sql.Replace("[0705]", str0705);
            sql = sql.Replace("[0801]", str0801);
            
            sql = sql.Replace("[0802]", str0802);
            sql = sql.Replace("[0803]", str0803);
            sql = sql.Replace("[0804]", str0804);
            sql = sql.Replace("[0805]", str0805);
            
            sql = sql.Replace("[0901]", str0901);
            sql = sql.Replace("[0902]", str0902);
            sql = sql.Replace("[1001]", str1001);
            sql = sql.Replace("[1002]", str1002);
            sql = sql.Replace("[1101]", str1101);
            sql = sql.Replace("[1102]", str1102);
            sql = sql.Replace("[1201]", str1201);
            
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

                string sql = String.Format("Update PISESP001 set {0}='{1}', {2} = '{3}',{4}='{5}' where PTNO = '{6}'", ADD1, str1, ADD2, str2, ADD3, str3, PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }


        }

        private void MainDBUpdate()
        {

            string sql = "Update PISDIG001 set  DITX = '[DITX]', ABLK = '[ABLK]',NBLK = '[NBLK]',OGTP = '[OGTP]' where PTNO = '[PTNO]'";
            //string DITX = lbt00001.Text + Environment.NewLine + lbt00002.Text + cbt00001.Text + cbt00002.Text + cbt00003.Text + Environment.NewLine + " " + tbt00004.Text + Environment.NewLine + Environment.NewLine + "  " + lb00101.Text + Environment.NewLine + "    " + cb00101.Text + Environment.NewLine + Environment.NewLine + "  " + lb00201.Text + Environment.NewLine + "    " + cb00201.Text + Environment.NewLine + Environment.NewLine + "  " + lb00301.Text + Environment.NewLine + "    " + cb00301.Text + Environment.NewLine + Environment.NewLine + "  " + lb00401.Text + tb00401.Text + lb00402.Text + tb00402.Text + lb00403.Text + tb00403.Text + lb00404.Text + Environment.NewLine + Environment.NewLine + "  " + lb00501.Text + Environment.NewLine + "    " + cb00501.Text + Environment.NewLine + Environment.NewLine + "  " + lb00601.Text + Environment.NewLine + "    " + cb00601.Text + Environment.NewLine + Environment.NewLine + "  " + lb00701.Text + Environment.NewLine + "    " + cb00701.Text + Environment.NewLine + "    " + tb00702.Text + Environment.NewLine + Environment.NewLine + "  " + lb00801.Text + Environment.NewLine + "    " + lb00802.Text + Environment.NewLine + "     " + cb00801.Text + Environment.NewLine + "      " + lb00803.Text + tb00802.Text + lb00804.Text + Environment.NewLine + "    " + lb00805.Text + Environment.NewLine + "     " + cb00803.Text + Environment.NewLine + "    " + lb00806.Text + Environment.NewLine + "     " + cb00804.Text + Environment.NewLine + "      " + lb00807.Text + tb00805.Text + lb00808.Text + Environment.NewLine + "    " + lb00809.Text + Environment.NewLine + "     " + cb00806.Text + Environment.NewLine + Environment.NewLine + "  " + lb00901.Text + Environment.NewLine + "    " + cb00901.Text + Environment.NewLine + Environment.NewLine + "  " + lb01001.Text + cb01001.Text + Environment.NewLine + Environment.NewLine + "  " + lb01101.Text + cb01101.Text + Environment.NewLine + Environment.NewLine + "  " + lb01201.Text + cb01201.Text + Environment.NewLine + Environment.NewLine + "  " + lb01301.Text + Environment.NewLine + "     " + tb01301.Text + Environment.NewLine + Environment.NewLine + "  " + lb01401.Text + lb01402.Text + tb01401.Text + lb01403.Text + tb01402.Text + lb01404.Text + tb01403.Text + Environment.NewLine + Environment.NewLine + "  " + ectb001.Text + Environment.NewLine + Environment.NewLine + "  " + ntlb001.Text + Environment.NewLine + "  " + nttb001.Text;

            string str000 = lbt00002.Text + tbt00001.Text +Environment.NewLine+ " " + tbt00002.Text;
            str000 = str000.Replace("'", "^");

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
            string str001 = Environment.NewLine + " " + lb00101.Text + str00101 + str00102;
            str001 = str001.Replace("'", "^");
            if (cb00101.Text == " " && tb00102.Text == "")
            {
                str001 = "";
            }
            string str002 =  Environment.NewLine +" " + lb00201.Text + tb00201.Text + lb00202.Text + tb00202.Text + lb00203.Text + tb00203.Text + lb00204.Text;
            str002 = str002.Replace("'", "^");
            string str003 =  Environment.NewLine + " " +lb00301.Text + cb00301.Text;
            str003 = str003.Replace("'", "^");
            //string str004 = Environment.NewLine + Environment.NewLine + lb00401.Text + Environment.NewLine+ "      " + cb00401.Text + Environment.NewLine + "      "+ lb00402.Text + tb00402.Text + lb00403.Text;
            string str00401 = " " + lb00401.Text + Environment.NewLine + "      " + cb00401.Text;
            string str00402 = Environment.NewLine + "      " + lb00402.Text + tb00402.Text + lb00403.Text;
           
            string str005 =  Environment.NewLine + " " + lb00501.Text + cb00501.Text;
            str005 = str005.Replace("'", "^");
            string str00602 = " " + lb00602.Text + tb00603.Text + lb00603.Text;
            if (tb00603.Text == "")
            {
                str00602 = "";
            }
            string str006 =Environment.NewLine + " " + lb00601.Text + Environment.NewLine + "      " + cb00601.Text + str00602+  Environment.NewLine + "      " + tb00602.Text;
            str006 = str006.Replace("'", "^");
            if (cb00601.Text == " " && tb00602.Text == "" && tb00603.Text == "")
            {
                str006 = "";
            }

            string str00701 = Environment.NewLine + "     " + lb00702.Text + Environment.NewLine + "      " + cb00701.Text;
            string str00702 = Environment.NewLine + "      " + lb00703.Text + tb00702.Text + lb00704.Text;
            string str00703 = Environment.NewLine + "      " + lb00705.Text + tb00703.Text + lb00706.Text;
            string str00704 = Environment.NewLine + "     " + lb00707.Text + Environment.NewLine + "      " + cb00704.Text;
            string str00705 = Environment.NewLine + "      " + lb00708.Text + tb00705.Text + lb00709.Text;

            
            /*
            string= lb00801.Text;
            string str00802 = Environment.NewLine + "    " + lb00802.Text + Environment.NewLine + "     " + cb00801.Text;

            string str00803 = Environment.NewLine + "      " + lb00803.Text + tb00802.Text + lb00804.Text;

            string str00804 = Environment.NewLine + "    " + lb00805.Text + Environment.NewLine + "     " + cb00803.Text;

            string str00805 = Environment.NewLine + "    " + lb00806.Text + Environment.NewLine + "     " + cb00804.Text;

            string str00806 = Environment.NewLine + "      " + lb00807.Text + tb00805.Text + lb00808.Text;

            string str00807 = Environment.NewLine + "    " + lb00809.Text + cb00806.Text;

            string str008;
            */
            
            string str00801 = Environment.NewLine + "      " + cb00801.Text;
            string str00802 = Environment.NewLine + "      " + lb00802.Text + tb00802.Text + lb00803.Text + tb00803.Text + lb00804.Text + tb00804.Text + lb00805.Text ;
            string str00803 = Environment.NewLine + "      " + lb00806.Text + cb00805.Text; 


            string str009 =  Environment.NewLine + " " + lb00901.Text + cb00901.Text + " " + cb00902.Text;
            str009 = str009.Replace("'", "^");
            if (cb00901.Text == " ")
            {
                str009 = Environment.NewLine + " " + lb00901.Text + cb00902.Text;
            }
            string str010 =  Environment.NewLine + " " + lb01001.Text + cb01001.Text +" " + cb01002.Text;
            str010 = str010.Replace("'", "^");
            if (cb01001.Text == " ")
            {
                str010 = Environment.NewLine + " " + lb00901.Text + cb01002.Text;
            }
            string str011 =  Environment.NewLine + " " + lb01101.Text + cb01101.Text +" "+ cb01102.Text;
            str011 = str011.Replace("'", "^");
            if (cb01101.Text == " ")
            {
                str011 = Environment.NewLine + " " + lb00901.Text + cb01102.Text;
            }
            string str012 =  Environment.NewLine + " " + lb01201.Text + Environment.NewLine + "      " +tb01201.Text;
            str012 = str012.Replace("'", "^");
            string strTBECTX =tbECTX.Text.Replace("\r\n", "\r\n ");
            string strECTX =  Environment.NewLine + " " + strTBECTX;
            strECTX = strECTX.Replace("'", "^");
            string strTBNOTE = "     " + tbNOTE.Text.Replace("\r\n", "\r\n     ");
            string strNOTE =  Environment.NewLine + " " +lbNOTE.Text + Environment.NewLine + strTBNOTE;
            strNOTE = strNOTE.Replace("'", "^");
            string strTBATX1 = " " + tbATX1.Text.Replace("\r\n", "\r\n     ");
            string strATX1 =  Environment.NewLine + tbATX1.Text;
            strATX1 = strATX1.Replace("'", "^");

            string strTBATX2 = " " + tbATX2.Text.Replace("\r\n", "\r\n   ");
            strTBATX2 = strTBATX2.Replace("#. Histochemistry", "#. Histochemistry");
            string strATX2 = Environment.NewLine + strTBATX2;
            strATX2 = strATX2.Replace("'", "^");

            if (tbt00001.Text == "" && tbt00002.Text == "" )
            {
                str000 = "";
            }
            
            if (tb00201.Text == "" && tb00202.Text == "" && tb00203.Text == "")
            {
                str002 = "";
            }
            if (cb00301.Text == " ")
            {
                str003 = "";
            }

            if (tb00201.Text == "" && tb00202.Text == "")
            {
                str002 =  Environment.NewLine + " " +lb00201.Text + tb00203.Text + lb00204.Text;
            }
            else if (tb00202.Text == "" && tb00203.Text == "")
            {
                str002 = Environment.NewLine + " " + lb00201.Text + tb00201.Text + lb00204.Text;
            }
            else if (tb00201.Text == "" && tb00203.Text == "")
            {
                str002 = Environment.NewLine + " " + lb00201.Text + tb00202.Text + lb00204.Text;
            }
            else if (tb00201.Text == "")
            {
                str002 = Environment.NewLine + " " + lb00201.Text + tb00202.Text + lb00203.Text + tb00203.Text + lb00204.Text;
            }
            else if (tb00203.Text == "")
            {
                str002 = Environment.NewLine + " " + lb00201.Text + tb00201.Text + lb00202.Text + tb00202.Text + lb00204.Text;
            }

            else if (tb00202.Text == "")
            {
                str002 =  Environment.NewLine + " " + lb00201.Text + tb00201.Text + lb00202.Text + tb00203.Text + lb00204.Text;
            }

            else if (tb00201.Text == "" && tb00202.Text == "" && tb00203.Text == "")
            {
                str002 = "";
            }

            if (cb00401.Text == " ")
            {
                str00401 = "";
            }
            if (tb00402.Text == "")
            {
                str00402 = "";
            }
            
            if (cb00501.Text == " ")
            {
                str005 = "";
            }
            if (cb00601.Text == " " && tb00602.Text =="")
            {
                str006 = "";
            }
            if (cb00701.Text == " ")
            {
                str00701 = "";
            }
            if (tb00702.Text == "")
            {
                str00702 = "";
            }
            if (tb00703.Text == "")
            {
                str00703 = "";
            }
            if (cb00704.Text == " ")
            {
                str00704 = "";
            }
            if (tb00705.Text == "")
            {
                str00705 = "";
            }
            
            if(cb00801.Text ==" ")
            {
                str00801="";
            }
            if (tb00802.Text == "" && tb00803.Text == "" && tb00804.Text == "")
            {
                str00802 = "";
            }
            else if (tb00802.Text == "" && tb00803.Text == "")
            {
                str00802 = Environment.NewLine + "      " + lb00802.Text + tb00804.Text + lb00805.Text;
            }
            else if (tb00803.Text == "" && tb00804.Text == "")
            {
                str00802 = Environment.NewLine + "      " + lb00802.Text + tb00802.Text + lb00805.Text;
            }
            else if (tb00802.Text == "" && tb00804.Text == "")
            {
                str00802 = Environment.NewLine + "      " + lb00802.Text + tb00803.Text + lb00805.Text;
            }
            else if (tb00802.Text == "")
            {
                str00802 = Environment.NewLine + "      " + lb00802.Text + tb00803.Text + lb00804.Text + tb00804.Text + lb00805.Text;
            }
            else if (tb00804.Text == "")
            {
                str00802 =  Environment.NewLine + "      " + lb00802.Text + tb00802.Text + lb00803.Text + tb00803.Text + lb00805.Text;
            }

            else if (tb00803.Text == "")
            {
                str00802 = Environment.NewLine + "      " + lb00802.Text + tb00802.Text + lb00803.Text + tb00804.Text + lb00805.Text;
            }

            

            
            if(cb00805.Text == " ")
            {
                str00803 ="";
            }
           
            if (cb00901.Text == " " && cb00902.Text == " ")
            {
                str009 = "";
            }
            if (cb01001.Text == " "&& cb01002.Text == " ")
            {
                str010 = "";
            }
            if (cb01101.Text == " "&& cb01102.Text == " ")
            {
                str011 = "";
            }
            if (tb01201.Text == " ")
            {
                str012 = "";
            }
            
            if (tbECTX.Text == "")
            {
                strECTX = "";
            }
            if (tbNOTE.Text == "")
            {
                strNOTE = "";
            }
            string str004 =  Environment.NewLine + str00401 + str00402;
            str004 = str004.Replace("'", "^");
            string str007 =  Environment.NewLine + " " + lb00701.Text + str00701 + str00702 + str00703 + str00704 + str00705;
            str007 = str007.Replace("'", "^");
            string str008 =  Environment.NewLine + " " + lb00801.Text + str00801 + str00802 + str00803;
            str008 = str008.Replace("'","^");
            if(str00401 ==""&& str00402 =="")
            {
                str004="";
            }
            if(str00801 ==""&&str00802==""&&str00803=="")
            {
                str008 ="";
            }
            if (str00701 == "" && str00702 == "" && str00703 == "" && str00704 == "" && str00705 == "")
            {
                str007 = "";
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
            

            if (tb01201.Text == "")
            {
                str012 = "";
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

                totalAdd =  ADD[1]  + ADD[2] + ADD[3] + ADD[4] +  ADD[5] + ADD[6] +  ADD[7] +  ADD[8];
                totalAdd = totalAdd.Replace("'", "^");
            }
            string DITX = lbt00001.Text + Environment.NewLine + str000 + str001 + str002 + str003 + str004 + str005 + str006 + str007 + str008 + str009 + str010 + str011 + str012 + strECTX + strNOTE + strATX1  + totalAdd + strATX2;
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

        private void button1_Click(object sender, EventArgs e)
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
        private void reset()
        {

            tbt00001.Text = "Ivor-Lewis operation :";
            tbt00002.Text = "Esophageal Cancer";
            cb00101.Text = " ";
            tb00102.Text = "";
            tb00201.Text = "";
            tb00202.Text = "";
            tb00203.Text = "";
            cb00301.Text = " ";
            cb00401.Text = " ";
            tb00402.Text = "";
            cb00501.Text = " ";
            cb00601.Text = " ";
            tb00602.Text = "";
            tb00603.Text = "";
            cb00701.Text = " ";
            tb00702.Text = "";
            tb00703.Text = "";
            cb00704.Text = " ";
            tb00705.Text = "";
            cb00801.Text = " ";
            tb00802.Text = "";
            tb00803.Text = "";
            tb00804.Text = "";
            cb00805.Text = " ";
            
            cb00901.Text = " ";
            cb00902.Text = " ";
            cb01001.Text = " ";
            cb01002.Text = " ";
            cb01101.Text = " ";
            cb01102.Text = " ";
            tb01201.Text = "Not identified";
            tbECTX.Text = "";
            tbNOTE.Text = "";
         
            tbblock01.Text = "";
            tbblock03.Text = "";
            tbATX1.Text = "";
            tbATX2.Text = "";
            dataGridView1.Rows.Clear();
            tbt00001.Select();
        }

        private void selectESP()
        {

            String sql = "select TIT1, TIT2, n0101,n0102, n0201,n0202,n0203, n0301, n0401, n0402, n0501, n0601, n0602,n0701, n0702,n0703,n0704,n0705, n0801, n0802, n0803, n0804, n0805, n0901,n0902,n1001,n1002, n1101,n1102, n1201,ECTX,NOTE,ATX1,ATX2,n0603 from PISESP001 where PTNO ='[PTNO]'";

            sql = sql.Replace("[PTNO]", PTNO);

            MySqlCommand cmd = new MySqlCommand(sql, Myconn);
            MySqlDataReader dr = cmd.ExecuteReader();



            while (dr.Read())
            {
                tbt00001.Text = dr[0].ToString().Replace("^", "'");
                tbt00002.Text = dr[1].ToString().Replace("^", "'");

                cb00101.SelectedIndex = selectData00101(dr[2].ToString());
                tb00102.Text = dr[3].ToString().Replace("^", "'");

                tb00201.Text = dr[4].ToString().Replace("^", "'");
                tb00202.Text = dr[5].ToString().Replace("^", "'");
                tb00203.Text = dr[6].ToString().Replace("^", "'");

                cb00301.SelectedIndex = selectData00301(dr[7].ToString());

                cb00401.SelectedIndex = selectData00401(dr[8].ToString());
                tb00402.Text = dr[9].ToString().Replace("^", "'");

                cb00501.SelectedIndex = selectData00501(dr[10].ToString());

                cb00601.SelectedIndex = selectData00601(dr[11].ToString());
                tb00602.Text = dr[12].ToString().Replace("^", "'");

                cb00701.SelectedIndex = selectData00701(dr[13].ToString());
                tb00702.Text = dr[14].ToString().Replace("^", "'");
                tb00703.Text = dr[15].ToString().Replace("^", "'");
                cb00704.SelectedIndex = selectData00704(dr[16].ToString());
                tb00705.Text = dr[17].ToString().Replace("^", "'");

                cb00801.SelectedIndex = selectData00801(dr[18].ToString());

                tb00802.Text = dr[19].ToString().Replace("^", "'");
                tb00803.Text = dr[20].ToString().Replace("^", "'");
                tb00804.Text = dr[21].ToString().Replace("^", "'");
                cb00805.SelectedIndex = selectData00805(dr[22].ToString());


                cb00901.SelectedIndex = selectData00901(dr[23].ToString());
                cb00902.SelectedIndex = selectData00902(dr[24].ToString());

                cb01001.SelectedIndex = selectData01001(dr[25].ToString());
                cb01002.SelectedIndex = selectData01002(dr[26].ToString());

                cb01101.SelectedIndex = selectData01101(dr[27].ToString());
                cb01102.SelectedIndex = selectData01102(dr[28].ToString());

                tb01201.Text = dr[29].ToString().Replace("^", "'");
                tbECTX.Text = dr[30].ToString().Replace("^", "'");
                tbNOTE.Text = dr[31].ToString().Replace("^", "'");
                tbATX1.Text = dr[32].ToString().Replace("^", "'");
                tbATX2.Text = dr[33].ToString().Replace("^", "'");
                tb00603.Text = dr[34].ToString().Replace("^", "'");
                selectAdd();
            }
            dr.Close();
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
       

        private void tb00702_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00703_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00705_KeyPress(object sender, KeyPressEventArgs e)
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

        private void tb00804_KeyPress(object sender, KeyPressEventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("정보를 삭제하시겠습니까?", "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string sql = "delete from pisESP001 where ptno = '[PTNO]'";
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
                string sql = "select DITX from PISDIG001 where PTNO ='[PTNO]' and OGTP ='ESP'";
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

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.CurrentCell.EditType == typeof(DataGridViewComboBoxEditingControl))
            {
                SendKeys.Send("{F4}");
            }
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

        private void tbECTX_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    tbECTX.SelectAll();
                }
            }
        }

        private void tbNOTE_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Control)
            {
                if (e.KeyCode == Keys.A)
                {
                    tbNOTE.SelectAll();
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

        private void cb00601_TextChanged(object sender, EventArgs e)
        {
            label1.Text = cb00601.Text;
            string str00601;
            str00601 = label1.Text;
            if (str00601.Length >= 80)
            {
                string first;
                string end;
                int i = str00601.Length - 80;
                first = str00601.Substring(0, 80);
                end = str00601.Substring(80, i);
                str00601 = first + Environment.NewLine + end;
                label1.Text = str00601;
            }
        }

        private void cb00401_TextChanged(object sender, EventArgs e)
        {
            label2.Text = cb00401.Text;
            string str00401;
            str00401 = label2.Text;
            if (str00401.Length >= 80)
            {
                string first;
                string end;
                int i = str00401.Length - 80;
                first = str00401.Substring(0, 80);
                end = str00401.Substring(80, i);
                str00401 = first + Environment.NewLine + end;
                label2.Text = str00401;
            }

        }

        private void cb00704_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lb00707_Click(object sender, EventArgs e)
        {

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

        private void button2_Click(object sender, EventArgs e)
        {
            Stage dlg = new Stage();
            dlg.Show();
        }

       

    }
}