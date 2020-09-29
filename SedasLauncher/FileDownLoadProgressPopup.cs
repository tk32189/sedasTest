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

namespace SedasLauncher
{
    public partial class FileDownLoadProgressPopup : DevExpress.XtraEditors.XtraForm
    {
        DataTable serverDt;
        string localFolderPath;
        string title;
        FileTransfer ft;


        public FileDownLoadProgressPopup(DataTable serverDt, string localFolderPath, string title, FileTransfer ft)
        {
            InitializeComponent();

            this.serverDt = serverDt;
            this.localFolderPath = localFolderPath;
            this.title = title;
            this.ft = ft;
        }

        //public void Start(DataTable serverDt, string localFolderPath, string title, FileTransfer ft)
        //{

        //}

        public static BackgroundWorker bgwSocket = new BackgroundWorker();

        private void FileDownLoadProgressPopup_Shown(object sender, EventArgs e)
        {
            progressBarControl1.Properties.Maximum = serverDt.Rows.Count;

            Start();

            this.Close();

            //bgwSocket.DoWork += new DoWorkEventHandler(bgwSocket_DoWorkAsync);
            //bgwSocket.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwSocket_RunWorkerCompleted);
            //bgwSocket.WorkerSupportsCancellation = true;
            //bgwSocket.RunWorkerAsync();
            //StartAsync();
        }
        //private async void bgwSocket_DoWorkAsync(object sender, DoWorkEventArgs e)
        //{
        //    StartAsync();
        //}

        //void bgwSocket_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        //{ 
        
        //}


        //private async void StartAsync()
        //{
            
        //    bool result = await Task.Run(() =>
        //    {
        //        return Start();
        //    });

        //    this.Close();
        //}

        private void Start()
        {

            this.lblTitle.Text = this.title;
            this.lblTitle.Update();

            //updateTextInfo(lblTitle, this.title);

            int i = 0;
            foreach (DataRow row in serverDt.Rows)
            {
                string localPath = localFolderPath;
                string fileCheckName = row["fileCheckName"].ToString();
                int lastPathIndex = fileCheckName.LastIndexOf("\\");
                if (lastPathIndex > 0)
                {
                    localPath = localPath + fileCheckName.Substring(0, lastPathIndex);
                }
                //string localPath = localFolderPath + 
                string savedFilePathAndName = "";

                lblMessage.Text = row["fileFullName"].ToString() + "다운로드 중";
                lblMessage.Update();

                updateTextInfo(lblMessage, row["fileFullName"].ToString() + "다운로드 중");

                if (ft.FileDownLoad(row["fileFullName"].ToString(), localPath, ref savedFilePathAndName, isNeedToDupNameChange: false) == true)
                {
                    //다운받기 성공
                }
                else
                {
                    //다운받기 실패
                }
                i++;

                int position = Convert.ToInt32(Math.Round((double)(i * 100 / progressBarControl1.Properties.Maximum)));

                //updateProgressInfo(progressBarControl1, i);
                progressBarControl1.Position = i;
                progressBarControl1.Update();
                lblPercent.Text = position.ToString() + "%";
                lblPercent.Update();
                //updateTextInfo(lblPercent, position.ToString() + "%");
            }

            

            //return true;
        }

        private void updateProgressInfo(DevExpress.XtraEditors.ProgressBarControl control, int value)
        {

            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate
                {
                    updateProgressInfo(control, value);
                }));
                return;
            }

            control.Position = value;
        }

        private void updateTextInfo(Sedas.Control.HLabelControl control, string value)
        {

            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate
                {
                    updateTextInfo(control, value);
                }));
                return;
            }

            control.Text = value;
        }
    }
}