using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace VideoPlayer
{
    public partial class player : DevExpress.XtraEditors.XtraForm
    {
        public player()
        {
            InitializeComponent();
        }

        DataTable dt;

        /// <summary>
        /// name         : player_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-05-20 10:02
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void player_Load(object sender, EventArgs e)
        {
            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("fileName", typeof(String));
                dt.Columns.Add("fullFileName", typeof(String));
            }

            this.grdFileInfo.DataSource = dt;
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            if (creatationTime != null && axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsPlaying)
            {
                lblCurrentTime.Text = creatationTime.AddSeconds(axWindowsMediaPlayer1.Ctlcontrols.currentPosition).ToString("yyyyMMdd HHmmss");
            }
        }

        Timer timer = new Timer();

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            //ofd.Filter = "jpg(*.*)|*.jpg*";
            DialogResult drs = ofd.ShowDialog();
            string strPath = "";
            if (drs == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    strPath = ofd.FileNames[i].ToString();


                }
            }

            axWindowsMediaPlayer1.URL = strPath;
        }


        string rootPath = "D:\\video";



        



        /// <summary>
        /// name         : dtpDate_EditValueChanged
        /// desc         : 날짜 변경시
        /// author       : 심우종
        /// create date  : 2020-05-20 10:02
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void dtpDate_EditValueChanged(object sender, EventArgs e)
        {

            dt.Rows.Clear();

            string date = dtpDate.DateTime.ToString("yyyyMMdd");

            if (!string.IsNullOrEmpty(date) && date.Length == 8)
            {
                string year = date.Substring(0, 4);

                string filePath = rootPath + "\\" + year + "\\" + date;
                System.IO.DirectoryInfo di = new System.IO.DirectoryInfo(filePath);

                if (di.Exists)
                {
                    foreach (System.IO.FileInfo File in di.GetFiles())
                    {
                        String FileNameOnly = File.Name.Substring(0, File.Name.Length - 4);
                        String FullFileName = File.FullName;
                        DataRow row = dt.NewRow();
                        row["fileName"] = FileNameOnly;
                        row["fullFileName"] = FullFileName;
                        dt.Rows.Add(row);
                    }
                }
            }
        }


        string fileName;
        DateTime creatationTime;

        /// <summary>
        /// name         : hGridView1_DoubleClick
        /// desc         : 그리드 더블클릭시
        /// author       : 심우종
        /// create date  : 2020-05-20 09:59
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void hGridView1_DoubleClick(object sender, EventArgs e)
        {
            DataRow selectedRow = grvFileInfo.GetFocusedDataRow();
            if (selectedRow != null)
            {
                string fullFileName = selectedRow["fullFileName"].ToString();

                //fileName = fullFileName;

                //string fileName = fullFileName.Split('\\').LastOrDefault();
                //this.creatationTime = null;
                FileInfo file = new FileInfo(fullFileName);
                if (file.Exists)
                {
                    this.creatationTime = file.CreationTime;
                }
                
                


                axWindowsMediaPlayer1.URL = fullFileName;

            }
        }

        private void hSimpleButton1_Click(object sender, EventArgs e)
        {
            //axWindowsMediaPlayer1
        }
    }
}