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
    public partial class BaselineData : DevExpress.XtraEditors.XtraForm
    {
        MySqlConnection Myconn;
        string strHMTP = "";
        string strSQNO = "";
        string strEXNM = "";
        int gv2 = -1;
        int oldpos = -1;
        int newpos = -1;

        public BaselineData()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

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
                if (gv002.Rows.Count == 2)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("삭제 하실 수 없습니다.\r\n최소한 1개 이상 값이 있어야 합니다.", "삭제 불가");
                    return;
                }
                else
                {
                    if (DevExpress.XtraEditors.XtraMessageBox.Show("해당 값을 사용한 병리번호가 있으면 삭제 후 조회 시 문제가 발생 할 수 있습니다.\r\n그래도 삭제하시겠습니까?", "삭제 확인", MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        if (DBDell(gv002.Rows[gv2].Cells[0].Value.ToString(), gv002.Rows[gv2].Cells[1].Value.ToString()))
                        {
                            gv002.Rows.RemoveAt(gv2);
                            DBSave();
                        }
                    }
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void DBUpdate(string strIndex, string strEXNO, string strEXTX)
        {
            try
            {
                /*   string sql = string.Format("UPDATE SET PISADM001 EXNO = '{0}' and EXTX = '{1}' where HMTP = '{2}' and SQNO = '{3}' and EXNM = '{4}' "
                                                   , strEXNO, strEXTX, strHMTP, strSQNO, strEXNM);

                   MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                   cmd.ExecuteNonQuery();*/
                string sql = "";
                if (strEXNO == "")
                {
                    sql = string.Format("INSERT INTO PISADM002 ( SYDT, UPDT, UPID, HMTP, SQNO, EXNM, EXTX, EXOD, EXNO) values " +
                                                                    " ('{0}','{1}','SEDAS','{2}','{3}','{4}','{5}','{6:D3}','{7:D3}')  "
                                                                   , DateTime.Now.ToString("yyyyMMdd"), DateTime.Now.ToString("yyyyMMdd")
                                                                   , strHMTP, strSQNO, strEXNM, strEXTX
                                                                   , Convert.ToInt32(strIndex), Convert.ToInt32(strIndex));
                }
                else
                {
                    sql = string.Format("update PISADM002 set EXOD = '{0:D3}', EXTX = '{1}' where HMTP = '{2}' and EXNO = '{3}' and SQNO = '{4}' ",
                                                Convert.ToInt32(strIndex), strEXTX, strHMTP, strEXNO, strSQNO);
                }

                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                cmd.ExecuteNonQuery();
            }
            catch (System.Exception ex) { }
        }

        private void DBSave()
        {
            try
            {
                //string sql = string.Format("DELETE FROM PISADM002 where HMTP = '{0}' and SQNO = '{1}' ", strHMTP, strSQNO);
                //MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                //cmd.ExecuteNonQuery();

                for (int i = 0; i < gv002.Rows.Count - 1; i++)
                {
                    DBUpdate((i + 1).ToString(), gv002.Rows[i].Cells[0].Value.ToString(), gv002.Rows[i].Cells[1].Value.ToString());
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                DBSave();

                GetAdm002(strHMTP, strSQNO);
            }
            catch (System.Exception ex)
            {

            }

            DevExpress.XtraEditors.XtraMessageBox.Show("저장완료");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }

        string GetHTMP(string strData)
        {
            try
            {
                switch (strData)
                {
                    case "Breast":
                        strHMTP = "brs";
                        break;
                    case "Cervix":
                        strHMTP = "cvx";
                        break;
                    case "Colon":
                        strHMTP = "col";
                        break;
                    case "Endometrial cancer":
                        strHMTP = "edc";
                        break;
                    case "Esophagus":
                        strHMTP = "esp";
                        break;
                    case "Gross":
                        strHMTP = "grs";
                        break;
                    case "Kidney":
                        strHMTP = "kdn";
                        break;
                    case "Liver Hepatectomy":
                        strHMTP = "lvh";
                        break;
                    case "Liver Intrahepatic":
                        strHMTP = "lvi";
                        break;
                    case "Liver meta":
                        strHMTP = "lvm";
                        break;
                    case "Lung":
                        strHMTP = "lng";
                        break;
                    case "Ovary cancer":
                        strHMTP = "ovc";
                        break;
                    case "Prostate":
                        strHMTP = "prs";
                        break;
                    case "Rectal":
                        strHMTP = "rtc";
                        break;
                    case "Stomach gastrectomy":
                        strHMTP = "stm";
                        break;
                    case "Stomach GIST":
                        strHMTP = "stg";
                        break;
                    case "TESTIS":
                        strHMTP = "tst";
                        break;
                    case "Urinary bladder carcinoma":
                        strHMTP = "ubc";
                        break;
                    case "Urinary bladder turb":
                        strHMTP = "ubt";
                        break;
                    case "추가처방":
                        strHMTP = "pia";
                        break;
                }
            }
            catch (System.Exception ex)
            {

            }
            return strHMTP;
        }

        private void cbHMTP_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                strHMTP = GetHTMP(cbHMTP.Text);
                gv001.Rows.Clear();
                if (strHMTP != "grs")
                {
                    gv002.Visible = true;
                    tbGross.Visible = false;
                    int i = 1;

                    string sql = string.Format("select HMNM, SQNO from pisadm001 where hmtp = '{0}' order by sqno", strHMTP);
                    MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                    MySqlDataReader dr = cmd.ExecuteReader();
                    while (dr.Read())
                    {
                        gv001.Rows.Add(i.ToString(), dr[0].ToString(), dr[1].ToString());
                        i++;
                    }
                    dr.Close();
                }
                else
                {
                    gv002.Visible = false;
                    tbGross.Dock = DockStyle.Top;
                    tbGross.Height = gv002.Height;
                    tbGross.Visible = true;

                }
            }
            catch (System.Exception ex)
            {

            }

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

        private void BaselineData_Load(object sender, EventArgs e)
        {
            try
            {
                CoreLibrary core = new CoreLibrary();
                core.InitGridStyle(gv001);
                core.InitGridStyle(gv002);

                string[] cbhmtpList = {
                                        "Breast",
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
                                        "Urinary bladder carcinoma",
                                        "Urinary bladder turb",
                                        "추가처방"};

                foreach (string value in cbhmtpList)
                {
                    cbHMTP.Items.Add(value);
                }




                foreach (Form openForm in Application.OpenForms)
                {
                    if (openForm.Name == "BaselineData")
                    {
                        if (openForm.WindowState == FormWindowState.Minimized)
                        {
                            openForm.WindowState = FormWindowState.Normal;
                            openForm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                        }
                        openForm.Activate();

                    }
                }

                string strSQL = Ini.strDB;
                gv001.Columns[1].Width = gv001.Width - 10;
                gv002.Columns[1].Width = gv002.Width - 10;

                Myconn = new MySqlConnection(strSQL);
                Myconn.Open();
            }
            catch (System.Exception ex)
            {

            }
        }

        private void GetAdm002(string str1, string str2)
        {
            try
            {
                gv002.Rows.Clear();
                string sql = string.Format("select EXNO, EXTX from pisadm002 where hmtp = '{0}' and sqno = '{1}' order by sqno, exod+0", str1, str2);
                MySqlCommand cmd = new MySqlCommand(sql, Myconn);
                MySqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    gv002.Rows.Add(dr[0].ToString(), dr[1].ToString());
                }
                dr.Close();
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

        private void gv002_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                gv2 = e.RowIndex;
            }
            catch (System.Exception ex)
            {

            }
        }

        private void gv002_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex > -1 && gv002.Rows[e.RowIndex].Cells[0].Value == null)
                    gv002.Rows[e.RowIndex].Cells[0].Value = "";
            }
            catch (System.Exception ex)
            {

            }
        }

        private void BaselineData_FormClosing(object sender, FormClosingEventArgs e)
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

        private void button5_Click(object sender, EventArgs e)
        {
            try
            {
                if (gv002.CurrentRow.Index <= 0) return;
                //
                int _iCurrentRow = gv002.CurrentRow.Index;
                DataGridViewRow _dgvRow = gv002.Rows[_iCurrentRow];
                gv002.Rows.RemoveAt(_iCurrentRow);
                gv002.Rows.Insert(_iCurrentRow - 1, _dgvRow);
                gv002.Rows[_iCurrentRow - 1].Selected = true;
                gv002.CurrentCell = gv002[gv002.CurrentCell.ColumnIndex, _iCurrentRow - 1];

                DBSave();
            }
            catch (System.Exception ex)
            {

            }
        }

        private void btnDOWN_Click(object sender, EventArgs e)
        {
            try
            {
                if (gv002.CurrentRow.Index < 0 || gv002.CurrentRow.Index + 2 == gv002.Rows.Count) return;
                //                
                int _iCurrentRow = gv002.CurrentRow.Index;
                DataGridViewRow _dgvRow = gv002.Rows[_iCurrentRow];
                gv002.Rows.RemoveAt(_iCurrentRow);
                gv002.Rows.Insert(_iCurrentRow + 1, _dgvRow);
                gv002.Rows[_iCurrentRow + 1].Selected = true;
                gv002.CurrentCell = gv002[gv002.CurrentCell.ColumnIndex, _iCurrentRow + 1];

                DBSave();
            }
            catch (System.Exception ex)
            {

            }
        }

        private void BaselineData_KeyDown(object sender, KeyEventArgs e)
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

        private void gv002_Paint(object sender, PaintEventArgs e)
        {
            gv2 = gv002.SelectedCells[0].RowIndex;
        }

        private void gv001_Resize(object sender, EventArgs e)
        {
            gv001.Columns[1].Width = gv001.Width - 10;
            gv002.Columns[1].Width = gv002.Width - 10;
        }

        private void gv002_Resize(object sender, EventArgs e)
        {
            gv001.Columns[1].Width = gv001.Width - 10;
            gv002.Columns[1].Width = gv002.Width - 10;
        }

    }
}
