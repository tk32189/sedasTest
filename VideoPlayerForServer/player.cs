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
using Sedas.UserControl;
using Sedas.Core;
using System.IO;

namespace VideoPlayerForServer
{
    public partial class player : DevExpress.XtraEditors.XtraForm
    {
        public static Color backColor = Color.FromArgb(11, 11, 21);
        public static Color panelColor = Color.FromArgb(36, 42, 55);


        FileTransfer ft = new FileTransfer();
        DataTable dt;
        string localFilePath = "";


        public player()
        {
            InitializeComponent();
        }


        /// <summary>
        /// name         : btnPc1_Click
        /// desc         : PC1버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-13 16:20
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnPc1_Click(object sender, EventArgs e)
        {
            this.FileDownload("Video");
        }


        /// <summary>
        /// name         : btnPc2_Click
        /// desc         : PC2 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-14 13:25
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnPc2_Click(object sender, EventArgs e)
        {
            this.FileDownload("Video2");
        }


        /// <summary>
        /// name         : FileDownload
        /// desc         : 파일을 다운로드 받는다.
        /// author       : 심우종
        /// create date  : 2020-07-13 16:21
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void FileDownload(string defaultPath)
        {
            //생성자에 아무것도 안넘기면 로컬용
            //아이피와 포트를 넘기면 서버 접속용
            //SedasFileOpenPopup sedasFileOpenPopup = new SedasFileOpenPopup();
            SedasFileOpenPopup sedasFileOpenPopup = new SedasFileOpenPopup("10.10.50.141", "28080", defaultPath: defaultPath);
            sedasFileOpenPopup.ShowDialog();

            
            string result = "";
            if (sedasFileOpenPopup.ResultState == SedasFileOpenPopup.PopupResult.OK)
            {
                List<string> files = sedasFileOpenPopup.SelctedFiles;

                if (files.Count > 0)
                {
                    result = files.ElementAt(0);
                }


                if (string.IsNullOrEmpty(result))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("파일을 선택해 주세요");
                    return;
                }



                DirectoryInfo di = new DirectoryInfo(this.localFilePath);
                if (di.Exists == false)
                {
                    di.Create();
                }


                string downLoadFilePath = "";
                //if (ft.FileDownLoad(result, localFilePath, ref downLoadFilePath) == true)
                //{
                //    MessageBox.Show(downLoadFilePath + " : 파일을 내려받았습니다.");

                //    this.SelectLocalFiles();
                //}

                downLoadFilePath = await Task.Run(() => {
                    return FileDownLoadAsync(result, localFilePath);
                });

                if (!string.IsNullOrEmpty(downLoadFilePath))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show(downLoadFilePath + " : 파일을 내려받았습니다.");
                    this.SelectLocalFiles();
                }
            }
        }


        private async Task<string> FileDownLoadAsync(string serverFile, string clientPath)
        {

            string downLoadFilePath = "";
            if (ft.FileDownLoad(serverFile, clientPath, ref downLoadFilePath) == false)
            {
                return null;
            }
            else
            {
                return downLoadFilePath;
            }
        }


        /// <summary>
        /// name         : player_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-07-14 11:49
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void player_Load(object sender, EventArgs e)
        {
            
            this.localFilePath = Application.StartupPath + "\\" + "tempFiles";

            ft.onPercentInfoEvent += Ft_onPercentInfoEvent;


            if (dt == null)
            {
                dt = new DataTable();
                dt.Columns.Add("fileName", typeof(String));
                dt.Columns.Add("fullFileName", typeof(String));
            }

            this.grdFileInfo.DataSource = dt;

            this.SelectLocalFiles();

        }


        /// <summary>
        /// name         : SelectLocalFiles
        /// desc         : 로컬에 있는 파일정보를 조회한다.
        /// author       : 심우종
        /// create date  : 2020-07-14 13:12
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SelectLocalFiles()
        {
            dt.Rows.Clear();

            DirectoryInfo di = new DirectoryInfo(localFilePath);
            if (di.Exists == true)
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

        private void Ft_onPercentInfoEvent(double obj, string fileName, string type, double allSize, double sendSize)
        {
            try
            {

                double allSizeMB = Math.Round(allSize / 1024 / 1024);
                double sendSizeMB = Math.Round(sendSize / 1024 / 1024);

                string info = "";
                if (obj == 100)
                {
                    info = "[" + fileName + "]" + "파일 다운로드 완료";
                }
                else
                {
                    info = "[" + fileName + ",  " + allSizeMB + "MB/" + sendSizeMB + "MB]" + "파일 다운로드중입니다.";
                }

                this.txtBigDataDisplay(info, obj);


                //txtBigDataInfo.Text = info;
                //txtBigDataInfo.Update();

                //progressCtrl.Position = Convert.ToInt32(Math.Round(obj));
                //progressCtrl.Update();
            }
            catch
            {
            }
        }


        /// <summary>
        /// name         : txtBigDataDisplay
        /// desc         : 다운로드/업로드 정보 표시(Cross Thread 문제가 있어 txtBigDataInfo.InvokeRequired 처리 필요 )
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void txtBigDataDisplay(string info, double obj)
        {

            if (txtBigDataInfo.InvokeRequired)
            {
                txtBigDataInfo.BeginInvoke(new Action(delegate
                {
                    txtBigDataDisplay(info, obj);
                }));
                return;
            }


            txtBigDataInfo.Text = info;
            txtBigDataInfo.Update();

            progressCtrl.Position = Convert.ToInt32(Math.Round(obj));
            progressCtrl.Update();


        }


        /// <summary>
        /// name         : grvFileInfo_DoubleClick
        /// desc         : 그리드 더블클릭시
        /// author       : 심우종
        /// create date  : 2020-07-14 13:19
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void grvFileInfo_DoubleClick(object sender, EventArgs e)
        {
            DataRow selectedRow = grvFileInfo.GetFocusedDataRow();
            if (selectedRow != null)
            {
                string fullFileName = selectedRow["fullFileName"].ToString();

                axWindowsMediaPlayer1.URL = fullFileName;

            }
        }

        Color borderColor = Color.FromArgb(40, 103, 163);

        private void tlpLeft_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var rectangle = e.CellBounds;
            //rectangle.X = 3;
            //rectangle.Width = rectangle.Width - 5;

            int bordeWidth = 1;


            if (e.Row == 0)
            {
                ControlPaint.DrawBorder(e.Graphics, rectangle, borderColor, bordeWidth, ButtonBorderStyle.Solid
                                                              , borderColor, bordeWidth, ButtonBorderStyle.Solid
                                                              , borderColor, bordeWidth, ButtonBorderStyle.Solid
                                                              , borderColor, bordeWidth, ButtonBorderStyle.Solid);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, rectangle, borderColor, bordeWidth, ButtonBorderStyle.Solid
                                                              , borderColor, 0, ButtonBorderStyle.Solid
                                                              , borderColor, bordeWidth, ButtonBorderStyle.Solid
                                                              , borderColor, bordeWidth, ButtonBorderStyle.Solid);
            }
        }


        /// <summary>
        /// name         : btnLocalFileDelete_Click
        /// desc         : 로컬 파일 삭제
        /// author       : 심우종
        /// create date  : 2020-07-14 13:50
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnLocalFileDelete_Click(object sender, EventArgs e)
        {
            if (DevExpress.XtraEditors.XtraMessageBox.Show("정말 삭제하시겠습니까?", "파일삭제", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
            {

                axWindowsMediaPlayer1.close();
                //return;

                DirectoryInfo di = new DirectoryInfo(this.localFilePath);
                if (di.Exists == true)
                {
                    di.Delete(true);
                    this.SelectLocalFiles();
                }
            }
        }
    }
}