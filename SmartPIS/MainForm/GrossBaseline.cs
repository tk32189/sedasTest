using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Threading;

namespace SmartPIS
{
    public partial class GrossBaseline : DevExpress.XtraEditors.XtraForm
    {
        MySqlConnection Myconn;
        string strHMTP = "grs";
        string strSQNO = "";
        string strEXNM = "";
        int gv2=-1;
        int oldpos = -1;
        int newpos = -1;

        public GrossBaseline()
        {
            InitializeComponent();
        }        

        private bool DBDell(string strEXNO, string strEXTX)
        {
            try
            {
                string sql = string.Format("DELETE FROM PISADM002 WHERE HMTP = '{0}' AND EXNO = '{1}' AND EXTX = '{2}' AND SQNO = '{3}' "
                                            , strHMTP, strEXNO, strEXTX, strSQNO);
                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
                return false;            	
            }            
            return true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                tbGross.Text = "";
                DBSave(tbGross.Text);

                GetAdm002(strHMTP, strSQNO);
            }
            catch (System.Exception ex)
            {
                return;
            }

            DevExpress.XtraEditors.XtraMessageBox.Show("삭제완료");          
        }

        private void DBUpdate(string strIndex, string strEXNO, string strEXTX)
        {
            try
            {             
                string sql = "";
                if (strEXNO == "")
                {
                    sql = string.Format("INSERT INTO PISADM002 ( SYDT, UPDT, UPID, HMTP, SQNO, EXNM, EXTX, EXOD, EXNO) values " +
                                                                    " ('{0}','{1}','SEDAS','{2}','{3}','{4}','{5}','{6:D3}','{7:D3}')  "
                                                                   , DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd")
                                                                   , strHMTP, strSQNO, strEXNM, strEXTX
                                                                   , Convert.ToInt32(strIndex), Convert.ToInt32(strIndex) );
                }
                else
                {
                    sql = string.Format("update PISADM002 set EXOD = '{0:D3}', EXTX = '{1}' where HMTP = '{2}' and EXNO = '{3}' and SQNO = '{4}' ",
                                                Convert.ToInt32(strIndex), strEXTX, strHMTP, strEXNO, strSQNO);
                }

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex) { DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message); }
        }

        private void DBSave(string strEXTX)
        {
            try
            {
                strEXTX = strEXTX.Replace("'", "^");
                string sql = string.Format("update PISADM002 set EXTX = '{0}' where HMTP = '{1}' and SQNO = '{2}' ", strEXTX, strHMTP, strSQNO);  

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex) { }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DBSave(tbGross.Text);
                
                GetAdm002(strHMTP, strSQNO);
            }
            catch (System.Exception ex)
            {
                return;
            }

            DevExpress.XtraEditors.XtraMessageBox.Show("저장완료");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void GetAdm001()
        {
            try
            {
                gv001.Rows.Clear();
                int i = 1;

                string sql = string.Format("select HMNM, SQNO from pisadm001 where hmtp = '{0}' order by sqno", strHMTP);
                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    gv001.Rows.Add(i.ToString(), dr[0].ToString().Replace("^", "'"), dr[1].ToString().Replace("^", "'"));
                    i++;
                }
                dr.Close();                
            }
            catch (System.Exception ex)
            {

            }
        }

        private void GrossBaseline_Load(object sender, EventArgs e)
        {
            try
            {
                CoreLibrary core = new CoreLibrary();
                core.InitGridStyle(gv001);


                string[] cbHMTPValues = { "Breast",
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
                                        "Urinary",
                                        "Urinary bladder turb",
                                        "추가처방결과"};

                foreach (string value in cbHMTPValues)
                {
                    this.cbHMTP.Items.Add(value);
                }





                string strSQL = Ini.strDB;
                gv001.Columns[1].Width = gv001.Width - 10;
                
                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();
                GetAdm001();
                try
                {
                    strEXNM = gv001.Rows[0].Cells[1].Value.ToString();
                    strSQNO = gv001.Rows[0].Cells[2].Value.ToString();

                    GetAdm002(strHMTP, strSQNO);
                    gv2 = 0;
                }
                catch (System.Exception ex)
                {

                }
            }
            catch (System.Exception ex)
            {
        	
            }
        }

        private void GetAdm002(string str1, string str2)
        {
            try
            {
                tbGross.Text = "";
                string sql = string.Format("select EXTX from pisadm002 where hmtp = '{0}' and sqno = '{1}' order by sqno, exod+0", str1.Replace("'","^"), str2);
                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();
                string str = "";
                while (dr.Read())
                {
                     str = dr[0].ToString();
                }
                dr.Close();
                tbGross.Text = str.Replace("^", "'");
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        private void gv001_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                strEXNM = gv001.Rows[e.RowIndex].Cells[1].Value.ToString();
                strSQNO = gv001.Rows[e.RowIndex].Cells[2].Value.ToString();                

                GetAdm002(strHMTP, strSQNO);
                gv2 = 0;
            }
            catch (System.Exception ex)
            {
            	
            }
        }


        private void GrossBaseline_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                if (Myconn.State == ConnectionState.Open)
                {
                    Myconn.Close();
                }
            }
            catch (System.Exception ex)
            {

            }
        }   
        
        private void GrossBaseline_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                button2.PerformClick();
            }
        }

        private void gv001_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F7)
            {
                button2.PerformClick();
            }
        }

       

        private void gv001_Resize(object sender, EventArgs e)
        {
            gv001.Columns[1].Width = gv001.Width - 10;
           
        }

        private void gv002_Resize(object sender, EventArgs e)
        {
            gv001.Columns[1].Width = gv001.Width - 10;
            
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            GrossAdd dgs = new GrossAdd();
            dgs.ShowDialog();
            GetAdm001();
        }

        
    }
}
