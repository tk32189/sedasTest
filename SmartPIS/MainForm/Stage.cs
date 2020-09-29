using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;

namespace SmartPIS
{
    public partial class Stage : Form
    {
        OleDbConnection EMRconn = null;

        public Stage()
        {
            InitializeComponent();
        }

        private void Stage_Load(object sender, EventArgs e)
        {
            if (!EMRConn())
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("EMR접속실패");
                Close();
            }

            EMRSearch();
        }

        private bool EMRConn()
        {
            try
            {
                string strEMR = Ini.strOCSDB;
                EMRconn = new OleDbConnection(strEMR);
                EMRconn.Open();
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        private void EMRSearch()
        { 
            string strQuery = "";
            
            try
            {
                strQuery = "select GRP_TYP, SUB_GRP from SUPTXTMT GROUP BY GRP_TYP, SUB_GRP ORDER BY GRP_TYP DESC, SUB_GRP";
                OleDbDataAdapter ap = new OleDbDataAdapter(strQuery, EMRconn);
                DataSet ds = new DataSet();
                ap.Fill(ds);
                string strNode = "", strNode2 = "";
                int nNodeCnt = -1;                

                foreach (DataRow topRow in ds.Tables[0].Rows)
                {
                    if (strNode != topRow["GRP_TYP"].ToString())
                    {
                        nNodeCnt++;
                        strNode = topRow["GRP_TYP"].ToString();
                        if (strNode != "")
                            treeView1.Nodes.Add(strNode);
                    }
                    else
                    {
                        strNode2 = topRow["SUB_GRP"].ToString();
                        if (strNode2!="")
                            treeView1.Nodes[nNodeCnt].Nodes.Add(strNode2);
                    }
                }                
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            string str1 = "", str2 = "";
            try
            {
                str1 = e.Node.Parent.Text;
            }
            catch (System.Exception ex)
            {
            	
            }
            try
            {
                str2 = e.Node.Text;
            }
            catch (System.Exception ex)
            {
            	
            }
            GetStageData(str1, str2);
        }

        private void GetStageData(string strGrp, string strSub)
        {
            listView1.Items.Clear();
            string strQuery = "";
            try
            {
                if (strGrp!="")
                    strQuery = "SELECT SUB_TYP, F_KEY||H_KEY, SEQ_NO, IMG FROM SUPTXTMT WHERE GRP_TYP = '" + strGrp + "' AND SUB_GRP = '" + strSub + "' ORDER BY grp_typ ,seq_no";
                else
                    strQuery = "SELECT SUB_TYP, F_KEY||H_KEY, SEQ_NO, IMG FROM SUPTXTMT WHERE GRP_TYP = '" + strSub + "' ORDER BY grp_typ ,seq_no";
                OleDbCommand cmd = new OleDbCommand(strQuery, EMRconn);
                OleDbDataReader read = cmd.ExecuteReader();
                while (read.Read())
                {
                    ListViewItem lvi = new ListViewItem();
                    lvi.SubItems.Add(read[0].ToString());
                    lvi.SubItems.Add(read[1].ToString());
                    lvi.SubItems.Add(read[2].ToString());
                    lvi.SubItems.Add(read[3].ToString());
                    listView1.Items.Add(lvi);
                }

            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        private void listView1_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button.Equals(MouseButtons.Right))
                {
                    string strUrl = listView1.Items[listView1.FocusedItem.Index].SubItems[4].Text;
                    string[] img = new string[2];
                    img = strUrl.Split('|');
                    strUrl = @"http://image.pnuyh.co.kr/" + img[0] + "/" + img[1];
                    webBrowser1.Navigate(strUrl);
                }
            }
            catch (System.Exception ex)
            {
                webBrowser1.Navigate("");
            }            
        }

    }
}
