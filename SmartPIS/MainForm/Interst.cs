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
using System.Data.OleDb;

namespace SmartPIS
{
    public partial class Interst : Form
    {
        public string PTNO;
        public Interst()
        {
            InitializeComponent();
            
            
        }
        public static MySqlConnection Myconn;
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string strSQL = Ini.strDB;
                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();
                //관심사유 필드 수정
                string sql = string.Format("UPDATE PISDIG001 SET INTR = '[str]' where PTNO = '[PTNO]' AND INTEREST = '1'");
                sql = sql.Replace("[str]", tbreason.Text);
                sql = sql.Replace("[PTNO]", PTNO);
                     
                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
                DevExpress.XtraEditors.XtraMessageBox.Show("저장되었습니다.");
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
            Myconn.Close();
        }

        private void Interst_Load(object sender, EventArgs e)
        {
            try
            {
                string strSQL = Ini.strDB;
                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();
                string sql = string.Format("Select INTR FROM PISDIG001 where PTNO ='[PTNO]'");
                sql = sql.Replace("[PTNO]", PTNO);

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    tbreason.Text = dr[0].ToString().Replace("^", "'");
                }
                dr.Close();
                Myconn.Close();

            }
            catch (SystemException ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("조회실패");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
