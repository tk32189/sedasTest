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
using Sedas.Core;
using System.IO;

namespace FileSendBatch
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private System.Windows.Forms.FolderBrowserDialog dlgOpenDir;
        FileTransfer ft = new FileTransfer();

        string rootPath = "D:\\blackBox";

        DateTime lastDate;
        DateTime currnetDate;
        string videoFolderNumber = "1";

        /// <summary>
        /// name         : btnStart_Click
        /// desc         : 시작버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-06-04 16:04
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnStart_Click(object sender, EventArgs e)
        {




        }


        /// <summary>
        /// name         : forderNameToDate
        /// desc         : 폴더명에 해당하는 날짜로 변환한다.
        /// author       : 심우종
        /// create date  : 2020-06-04 15:52
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private DateTime? ForderNameToDate(string directory)
        {
            string lastFolderName = directory.Split('\\').LastOrDefault();

            string date = lastFolderName.Replace("-", "").Substring(0, 8);
            string year = date.Substring(0, 4);
            string month = date.Substring(4, 2);
            string day = date.Substring(6, 2);

            if (year.ToIntOrNull() != null && month.ToIntOrNull() != null && day.ToIntOrNull() != null)
            {
                DateTime folderDt = new DateTime(year.ToInt(), month.ToInt(), day.ToInt());
                return folderDt;
            }
            return null;
        }


        /// <summary>
        /// name         : btnFindFolder_Click
        /// desc         : 폴더 찾기
        /// author       : 심우종
        /// create date  : 2020-06-04 14:15
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnFindFolder_Click(object sender, EventArgs e)
        {
            dlgOpenDir = new FolderBrowserDialog();
            DialogResult resDialog = dlgOpenDir.ShowDialog();
            if (resDialog.ToString() == "OK")
            {
                //this.txtDirectory.Text = dlgOpenDir.SelectedPath;
            }
        }


        /// <summary>
        /// name         : MainForm_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-06-04 16:33
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void MainForm_Load(object sender, EventArgs e)
        {
            //Start();
        }


        /// <summary>
        /// name         : Start
        /// desc         : 블랙박스 대용량 파일 서버에 올리는 배치 시작
        /// author       : 심우종
        /// create date  : 2020-06-04 16:32
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void Start()
        {
            Global.strinipath = System.Environment.CurrentDirectory + "\\Setting\\Setting.ini";
            string strLastDt = Global.G_IniReadValue("option", "lastDate", Global.strinipath);
            this.rootPath = Global.G_IniReadValue("option", "rootPath", Global.strinipath);
            this.videoFolderNumber = Global.G_IniReadValue("option", "videoFolderNumber", Global.strinipath);

            if (strLastDt.Length == 8)
            {
                if (strLastDt.Substring(0, 4).ToIntOrNull() != null
                    && strLastDt.Substring(4, 2).ToIntOrNull() != null
                    && strLastDt.Substring(6, 2).ToIntOrNull() != null)
                {
                    this.lastDate = new DateTime(strLastDt.Substring(0, 4).ToInt(), strLastDt.Substring(4, 2).ToInt(), strLastDt.Substring(6, 2).ToInt());
                }
            }

            // rootpath 밑에 폴더구조는 2020\2020-06-04 형태로 되어있어야 함.
            // lastDate 이후 현재일자 이전에 해당하는 폴더에 대해서만 업로드 처리한다.
            if (string.IsNullOrEmpty(rootPath)) return;
            if (string.IsNullOrEmpty(videoFolderNumber)) return;
            if (lastDate == null) return;

            //this.lastDate =  new DateTime(2020, 06, 01);
            currnetDate = DateTime.Now;


            List<string> directoryList = new List<string>();
            string tempPath = rootPath + "\\" + lastDate.ToString("yyyy");
            string[] directories = Directory.GetDirectories(tempPath);

            directoryList.AddRange(directories);

            if (lastDate.ToString("yyyy") != currnetDate.ToString("yyyy"))
            {
                tempPath = rootPath + "\\" + currnetDate.ToString("yyyy");
                directories = Directory.GetDirectories(tempPath);
                directoryList.AddRange(directories);
            }

            List<string> targetDirectoryList = new List<string>();

            for (int i = 0; i < directoryList.Count(); i++)
            {
                string directory = directoryList.ElementAt(i);
                if (directory.Replace("-", "").Length >= 8)
                {

                    DateTime? folderDt = ForderNameToDate(directory);

                    if (folderDt == null) continue;

                    //DateTime folderDt = new DateTime(year.ToInt(), month.ToInt(), day.ToInt());

                    TimeSpan ts = folderDt.Value - lastDate;

                    if (ts.Days <= 0)
                    {
                        //마지막 성공일자보다 이전의 폴더는 체크하지 않는다.
                        continue;
                    }

                    TimeSpan ts2 = folderDt.Value - currnetDate;
                    if (ts2.Days >= 0)
                    {
                        //현재일자 포함 미래일자는 체크하지 않는다.
                        continue;
                    }

                    targetDirectoryList.Add(directory);

                }
            }

            if (targetDirectoryList != null && targetDirectoryList.Count > 0)
            {
                for (int i = 0; i < targetDirectoryList.Count; i++)
                {
                    string directory = targetDirectoryList.ElementAt(i);

                    DateTime? folderDt = ForderNameToDate(directory);

                    string[] tempFiles = Directory.GetFiles(directory);

                    if (tempFiles != null && tempFiles.Count() > 0)
                    {
                        //txtMessage.Text = folderDt.Value.ToString("yyyy-MM-dd") + "일 데이터 복사중입니다.";
                        //txtMessage.Update();
                        foreach (string file in tempFiles)
                        {
                            string serverName = file.Replace(this.rootPath, "");

                            if (videoFolderNumber == "1")
                            {
                                serverName = "Video" + serverName;
                            }
                            else if (this.videoFolderNumber == "2")
                            {
                                serverName = "Video2" + serverName;
                            }

                            if (ft.FileUpload(file, serverName) == true)
                            {
                                //성공
                            }
                        }
                    }

                    

                    if (folderDt != null)
                    {
                        TimeSpan ts = folderDt.Value - lastDate;

                        if (ts.Days > 0)
                        {
                            Global.G_IniWriteValue("option", "lastDate", folderDt.Value.ToString("yyyyMMdd"), System.Environment.CurrentDirectory + "\\Setting\\Setting.ini");
                            //라스트 dt를 업데이트 하자..
                        }
                    }


                }
            }
            isStart = false;
            
        }

        bool isStart = false;
        public static BackgroundWorker bgwSocket = new BackgroundWorker();
        //Timer tm;
        private void MainForm_Shown(object sender, EventArgs e)
        {
            //tm = new Timer();
            //tm.Interval = 1000;
            //tm.Tick += Tm_Tick;
            //tm.Start();

            //StartAsync();

            bgwSocket.DoWork += new DoWorkEventHandler(DoWorkAsync);
            bgwSocket.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
            bgwSocket.WorkerSupportsCancellation = true;
            bgwSocket.RunWorkerAsync();


        }
        private async void DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            Start();
        }

        void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}