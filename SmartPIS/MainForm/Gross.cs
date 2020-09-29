using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using MySql.Data.MySqlClient;

namespace SmartPIS
{
    public partial class Gross : Form
    {
        MySqlConnection Myconn;
        public string strGross, strPTNO;
        public int lbSet;

        public Gross()
        {
            InitializeComponent();
            lbSet = 0;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = textBox1.Text;
        }

        private void Gross_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            textBox2.Text = strGross;
            Myconn = new MySqlConnection(Ini.strDB);
            Myconn.Open();
            DBSearch();
        }

        private void listBox1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text != "" && lbSet != listBox1.SelectedIndex)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("작업중이던 내용이 있습니다.\r\n작업한 내용을 저장하고 이동하시겠습니까?", "작업확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    strGross = textBox2.Text;
                    strGross = strGross.Replace("'", "^");
                    DBUpdate();
                    textBox1.Text = EXTXSearch(listBox1.SelectedItem.ToString());
                }
                else
                    listBox1.SelectedIndex = lbSet;
            }
            else
                textBox1.Text = EXTXSearch(listBox1.SelectedItem.ToString());

            lbSet = listBox1.SelectedIndex;
        }

        private void listBox1_DoubleClick(object sender, EventArgs e)
        {
            textBox2.Text = EXTXSearch(listBox1.SelectedItem.ToString());
        }

        private void DBSearch()
        {
            try
            {
                int i = 1;

                string sql = string.Format("select HMNM from pisadm001 where hmtp = 'grs' order by sqno");
                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    listBox1.Items.Add(dr[0].ToString());
                    i++;
                }
                dr.Close();
            }
            catch (System.Exception ex)
            {

            }
        }

        private string EXTXSearch(string strEXNM)
        {
            string str = "";
            try
            {
                int i = 1;

                string sql = string.Format("select EXTX from pisadm002 where hmtp = 'grs' and EXNM = '{0}' order by sqno", strEXNM);
                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    str = dr[0].ToString();
                    i++;
                }
                dr.Close();
            }
            catch (System.Exception ex)
            {

            }
            return str.Replace("^","'");
        }

        private void DBUpdate()
        {
            MySqlConnection conn = null;
            try
            {
                conn = new MySqlConnection(Ini.strDB);
                conn.Open();
                string sql = string.Format("Update pisdig001 set GRTX = '{0}' where ptno = '{1}'", strGross, strPTNO);
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex)
            {
            	
            }
            if (conn.State == ConnectionState.Open) conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            strGross = textBox2.Text;
            strGross = strGross.Replace("'", "^");
            DBUpdate();
            Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            OleDbConnection emr = null;
            try
            {
                if (strPTNO == "") return;

                string strSQL = Ini.strOCSDB;
                emr = new OleDbConnection(strSQL);
                emr.Open();
                string strQ = "select READ_RSLT from sptprslt where patho_no = '" + strPTNO + "'";
                OleDbCommand cmd = new OleDbCommand(strQ, emr);
                OleDbDataReader dr = cmd.ExecuteReader();

                string strData = "";
                while (dr.Read())
                {

                    strData = dr[0].ToString();
                    textBox2.Text = strData.Substring(0, strData.IndexOf("DIAGNOSIS"));
                }

                dr.Close();
                emr.Close();        
            }
            catch (System.Exception ex)
            {
                
            }

            if (emr.State == ConnectionState.Open) emr.Close();

        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            e.Graphics.DrawString(this.listBox1.Items[e.Index].ToString(),
                e.Font, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }
    }
}
