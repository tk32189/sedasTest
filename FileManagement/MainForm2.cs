using Sedas.Core;
using Sedas.UserControl;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Threading.Tasks;

namespace FileManagement
{
    public partial class MainForm2 : DevExpress.XtraEditors.XtraForm
    {
        SedasFileOpen serverControl = null;
        SedasFileOpen clientControl = null;

        FileTransfer ft = new FileTransfer("10.10.221.71", "1111");

        public MainForm2()
        {
            InitializeComponent();
        }

        private void MainForm2_Load(object sender, EventArgs e)
        {

            this.InitGlobal();

            this.serverControl = new SedasFileOpen();
            this.serverControl.DefaultPath = "DiR";
            this.serverControl.InitServerInfo(this.txtIp.Text, this.txtPort.Text);
            this.serverControl.IsFileManagement = true;
            this.tlpServer.Controls.Add(this.serverControl, 0, 1);
            this.serverControl.Dock = DockStyle.Fill;


            this.clientControl = new SedasFileOpen();
            this.clientControl.IsFileManagement = true;
            this.tlpClient.Controls.Add(this.clientControl, 0, 1);
            this.clientControl.Dock = DockStyle.Fill;

            ft.onPercentInfoEvent += Ft_onPercentInfoEvent;
        }

        private void Ft_onPercentInfoEvent(double obj, string fileName, string type, double allSize, double sendSize)
        {
            try
            {
                double allSizeMB = Math.Round(allSize / 1024 / 1024);
                double sendSizeMB = Math.Round(sendSize / 1024 / 1024);

                string info = "";
                if (type == "U")
                {
                    if (obj == 100)
                    {
                        info = "[" + fileName + "]" + "파일 업로드 완료";
                    }
                    else
                    {
                        info = "[" + fileName + ",  " + allSizeMB + "MB/" + sendSizeMB + "MB]" + "파일 업로드중입니다.";
                    }

                }
                else if (type == "D")
                {
                    if (obj == 100)
                    {
                        info = "[" + fileName + "]" + "파일 다운로드 완료";
                    }
                    else
                    {
                        info = "[" + fileName + ",  " + allSizeMB + "MB/" + sendSizeMB + "MB]" + "파일 다운로드중입니다.";
                    }
                }

                this.txtBigDataDisplay(info, obj);
                //textBox1.Text = info;
                //if (txtBigDataInfo != null && txtBigDataInfo.InvokeRequired == true)
                //{
                //    txtBigDataInfo.Text = info;
                //    txtBigDataInfo.Update();
                //}
            }
            catch (Exception ex)
            {
            }

            //throw new NotImplementedException();
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

        private void InitGlobal()
        {
            Global.strinipath = System.Environment.CurrentDirectory + "\\Setting\\Setting.ini";

            Global.ip = Global.G_IniReadValue("Server_Option", "ip", Global.strinipath);
            Global.port = Global.G_IniReadValue("Server_Option", "port", Global.strinipath);

            this.txtIp.Text = Global.ip;
            this.txtPort.Text = Global.port;
            this.ft = new FileTransfer(this.txtIp.Text, this.txtPort.Text);
        }


        /// <summary>
        /// name         : btnUpLoad_Click
        /// desc         : 업로드 버튼 클릭시
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            FileUpLoad();
        }

        private async void FileUpLoad()
        {
            List<string> selectedFiles = this.clientControl.GetSelectedFilesNew(isFileAdd: true, isFolderAdd: false);
            if (selectedFiles == null || selectedFiles.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("업로드할 파일을 선택해 주세요");
                return;
            }

            string serverPath = this.serverControl.GetCurrentPath();
            if (serverPath.Split('\\').FirstOrDefault() == "serverRoot")
            {
                int delLangth = "serverRoot".Length;
                serverPath = serverPath.Substring(delLangth, serverPath.Length - delLangth);
            }

            if (string.IsNullOrEmpty(serverPath))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("서버 경로를 확인할 수 없습니다.");
                return;
            }

            try
            {
                this.btnDownLoad.Enabled = false;
                this.btnUpLoad.Enabled = false;

                for (int i = 0; i < selectedFiles.Count; i++)
                {
                    string localFile = selectedFiles.ElementAt(i);
                    string fileName = localFile.Split('\\').LastOrDefault();

                    string serverFile = serverPath + "\\" + fileName;

                    //selectedFiles.ElementAt(i);


                    bool result = await Task.Run(() =>
                    {
                        return FileUpLoadAsync(localFile, serverFile);
                    });

                    if (result == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(localFile + " : 업로드에 실패하였습니다.");
                    }
                }

                this.serverControl.FileRefresh();
                this.clientControl.ClearSelection(); //파일체크 초기화
            }
            finally
            {
                this.btnDownLoad.Enabled = true;
                this.btnUpLoad.Enabled = true;
            }

            

        }

        private async Task<bool> FileUpLoadAsync(string localFile, string serverFile)
        {

            if (ft.FileUpload(localFile, serverFile, dupCheckAndChangeName: true) == false)
            {
                //MessageBox.Show(localFile + " : 업로드에 실패하였습니다.");
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// name         : btnDownLoad_Click
        /// desc         : 다운로드 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-05-29 10:11
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnDownLoad_Click(object sender, EventArgs e)
        {
            FileDownload();
        }

        private async void FileDownload()
        {
            List<string> serverFiles = serverControl.GetSelectedFilesNew(isFileAdd: true, isFolderAdd: false);
            if (serverFiles == null || serverFiles.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("다운로드 할 파일을 선택해 주세요");
                return;
            }

            string clientPaht = clientControl.GetCurrentPath();

            if (string.IsNullOrEmpty(clientPaht))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("다운받을 경로를 찾을 수 없습니다.");
                return;
            }

            try
            {
                this.btnDownLoad.Enabled = false;
                this.btnUpLoad.Enabled = false;

                string downLoadFilePath = "";
                for (int i = 0; i < serverFiles.Count; i++)
                {
                    string serverFile = serverFiles.ElementAt(i);

                    downLoadFilePath = await Task.Run(() =>
                    {
                        return FileDownLoadAsync(serverFile, clientPaht);
                    });

                    //downLoadFilePath = await FileDownLoadAsync(serverFile, clientPaht);

                    if (string.IsNullOrEmpty(downLoadFilePath))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(serverFile + " : 다운로드에 실패하였습니다.");
                    }
                }

                this.clientControl.FileRefresh();
                this.serverControl.ClearSelection(); //파일체크 초기화
            }
            finally
            {
                this.btnDownLoad.Enabled = true;
                this.btnUpLoad.Enabled = true;
            }


        }

        private async Task<string> FileDownLoadAsync(string serverFile, string clientPaht)
        {

            string downLoadFilePath = "";
            if (ft.FileDownLoad(serverFile, clientPaht, ref downLoadFilePath) == false)
            {
                //MessageBox.Show(serverFile + " : 다운로드에 실패하였습니다.");
                return null;
            }
            else
            {
                return downLoadFilePath;
            }
        }


        /// <summary>
        /// name         : btnConnect_Click
        /// desc         : 서버 재연결
        /// author       : 심우종2020-06-03 10:48
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnConnect_Click(object sender, EventArgs e)
        {

            Global.G_IniWriteValue("Server_Option", "ip", txtIp.Text, System.Environment.CurrentDirectory + "\\Setting\\Setting.ini");
            Global.G_IniWriteValue("Server_Option", "port", txtPort.Text, System.Environment.CurrentDirectory + "\\Setting\\Setting.ini");

            this.serverControl.ReConnect(this.txtIp.Text, this.txtPort.Text);
            this.ft = new FileTransfer(this.txtIp.Text, this.txtPort.Text);
            ft.onPercentInfoEvent += Ft_onPercentInfoEvent;
        }


        /// <summary>
        /// name         : tlpServer_CellPaint
        /// desc         : border색 지정
        /// author       : 심우종
        /// create date  : 2020-06-15 13:17
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void tlpServer_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {

        }

        private void tlpMain_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var rectangle = e.CellBounds;
            //rectangle.X = 3;
            //rectangle.Width = rectangle.Width - 5;
            Color color = Global.panelColor;
            if (e.Row == 0)
            {
                ControlPaint.DrawBorder(e.Graphics, rectangle, color, 2, ButtonBorderStyle.Solid
                                                              , color, 2, ButtonBorderStyle.Solid
                                                              , color, 2, ButtonBorderStyle.Solid
                                                              , color, 2, ButtonBorderStyle.Solid);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, rectangle, color, 2, ButtonBorderStyle.Solid
                                                              , color, 0, ButtonBorderStyle.Solid
                                                              , color, 2, ButtonBorderStyle.Solid
                                                              , color, 2, ButtonBorderStyle.Solid);
            }
        }
    }
}