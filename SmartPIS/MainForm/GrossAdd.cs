using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace SmartPIS
{
    public partial class GrossAdd : Form
    {
        public GrossAdd()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (DBInsert(tbTitle.Text, tbData.Text)) Close();
            else
                DevExpress.XtraEditors.XtraMessageBox.Show("저장 실패");
        }

        private bool DBInsert(string strTit, string strEXTX)
        {
            try
            {
                MySqlConnection conn = new MySqlConnection(Ini.strDB);
                conn.Open();
                string sql = string.Format("INSERT INTO PISADM001 (SYDT, UPDT, UPID, HMTP, SQNO, HMNM) values "+
                                           "('{0}', '{1}', '{2}', 'grs', (SELECT  lpad(max(sqno)+100, 5, 0) FROM pisadm002 WHERE hmtp = 'grs'), '{3}')",
                                           DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd"), "GROSS", strTit.Replace("'", "^"));
                MySqlCommand cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                sql = string.Format("INSERT INTO PISADM002 (SYDT, UPDT, UPID, HMTP, SQNO, EXNO, EXNM, EXTX, EXOD) values " +
                                                              "('{0}', '{1}', '{2}', 'grs', (SELECT max(sqno) FROM pisadm001 WHERE hmtp = 'grs'), '001', '{3}', '{4}', '001')",
                                            DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd"), "GROSS", strTit.Replace("'", "^"), strEXTX.Replace("'", "^"));
                cmd = new MySqlCommand(sql, conn);
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                return false;
            }

            return true;
        }
    }
}
