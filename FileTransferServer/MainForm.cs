using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
//using DevExpress.XtraEditors;
using System.Net.Sockets;
using System.IO;
using System.Threading;
using System.Net;
using DevExpress.Utils.Helpers;
using Newtonsoft.Json;
using System.Management;

namespace FileTransferServer
{
    public partial class MainForm : Form
    {

        public class SocketState
        {
            public const int BufferSize = 10240;

            public Socket WorkSocket = null;
            public byte[] Buffer = new byte[BufferSize];
            public StringBuilder ContentsBuilder = new StringBuilder();
            public FileStream oFileStream = null;
            public double iFileSize = 0;
            public Boolean isAuthUser = false;
            public FileInfo fileInfo;
        }
        //private System.IO.FileSystemWatcher m_Watcher; //파일서버 백업을 위한 와쳐
        private String appPath = Application.StartupPath;
        string startTag = "";
        //private String receivePath = String.Format(@"{0}\Receive", Application.StartupPath);
        //private String receivePath = "D:\\ServerData";


        private string rootPath = "W:"; //파일서버 루트경로

        //====FILE BACKUP==========
        private string rootPath_backup = "X:"; //백업루트경로
        private bool isNeedToFileBackup = false; //파일 백업 필요여부
        //=========================
        
        //====CROSS CEHCK==========
        string[] crossCheckingIp = { "10.10.50.141", "10.10.50.142" }; //서로 크로스 체크 하는 IP
        string defaultPort = "28080"; //재시작시 자동으로 설정된 포트
        bool isCrossCheckRestart = true;
        string crossCheckId = "mj2kuh";
        string crossCheckPw = "sJ0802$!";
        int crossCheckTimerInterval = 5000;
        //=========================

        bool isLocalTest = true; //로컬 테스트용


        /// <summary>
        /// name         : LocalTestInit
        /// desc         : 로컬 테스트를 위한 자동 값 변경
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void LocalTestInit()
        {
            rootPath = "D:\\ServerData";
            rootPath_backup = "D:\\SeverDataBackup";
            defaultPort = "28080"; //재시작시 자동으로 설정된 포트
            crossCheckingIp = new string[] { "10.10.221.71", "10.10.50.142" };
            //crossCheckingIp = new string[] { "10.10.221.71", "10.10.221.72" };
        }



        private Socket listener = null;
        public static ManualResetEvent allDone = new ManualResetEvent(false);
        public static ManualResetEvent sendDone = new ManualResetEvent(false);
        public static ManualResetEvent recevieDone = new ManualResetEvent(false);
        public static BackgroundWorker bgwSocket = new BackgroundWorker();

        public static ManualResetEvent MrSendFileDone = new ManualResetEvent(false);            // 파일 전송 쓰레드 이벤트 핸들링
        public static ManualResetEvent MrReceiveFileDone = new ManualResetEvent(false);          // 파일 수신 쓰레드 이벤트 핸들링

        private bool bStart = false;


        public MainForm()
        {
            InitializeComponent();

            Init(null);
        }

        public MainForm(string[] args)
        {
            InitializeComponent();

            Init(null);


            if (args != null && args.Length > 0)
            {
                this.startTag = args.ElementAt(0);
            }
        }


        private void Init(DataRow drFormInfo)
        {
            try
            {
                InitControls();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                ;
            }
        }

        private void InitControls()
        {

        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.InitGlobal();

            if (this.isLocalTest == true)
            {
                this.LocalTestInit(); //로컬 테스트용 변수 설정
            }

            Directory.CreateDirectory(String.Format(@"{0}\Log", appPath));
            Directory.CreateDirectory(rootPath);

            GetReceiveDirectoryFiles();

            txtIP.Text = GetIp();

            if (!string.IsNullOrEmpty(this.defaultPort))
            {
                this.txtPort.Text = this.defaultPort;
            }

            txtRoot.Text = this.rootPath;


            //재시작 태그로 시작하는 경우 자동으로 스타트 처리
            if (this.startTag == "ReStart")
            {
                this.txtPort.Text = this.defaultPort;
                this.btnStart.PerformClick();
            }

            OtherServerCrossCheck();
        }

        private void InitGlobal()
        {
            string iniPath = Global.strSettingPath;
            FileInfo file = new FileInfo(iniPath);
            if (file.Exists == false)
            {
                DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory + "\\Setting");
                if (di.Exists == false)
                {
                    di.Create();
                }

                file.Create();
            }

            //---------------------------- 데이터 넣을때 임시로 사용
            //Global.G_IniWriteValue("SETTING", "rootPath", "W:", Global.strSettingPath);
            //Global.G_IniWriteValue("SETTING", "rootPath_backup", "X:", Global.strSettingPath);
            //Global.G_IniWriteValue("SETTING", "isNeedToFileBackup", "Y", Global.strSettingPath);
            //Global.G_IniWriteValue("SETTING", "defaultPort", "28080", Global.strSettingPath);

            //Global.G_IniWriteValue("CROSSCHECK", "checkIp1", "10.10.50.141", Global.strSettingPath);
            //Global.G_IniWriteValue("CROSSCHECK", "checkIp2", "10.10.50.142", Global.strSettingPath);

            Global.G_IniWriteValue("CROSSCHECK", "isCrossCheckRestart", "Y", Global.strSettingPath);

            Global.G_IniWriteValue("CROSSCHECK", "crossCheckId", "mj2kuh", Global.strSettingPath);
            Global.G_IniWriteValue("CROSSCHECK", "crossCheckPw", "sJ0802$!", Global.strSettingPath);
            Global.G_IniWriteValue("CROSSCHECK", "crossCheckTimerInterval", "5000", Global.strSettingPath);


        


            //----------------------------


            this.rootPath = Global.G_IniReadValue("SETTING", "rootPath", Global.strSettingPath);
            this.rootPath_backup = Global.G_IniReadValue("SETTING", "rootPath_backup", Global.strSettingPath);
            if (Global.G_IniReadValue("SETTING", "isNeedToFileBackup", Global.strSettingPath) == "Y")
            {
                this.isNeedToFileBackup = true;
            }
            else
            {
                this.isNeedToFileBackup = false;
            }
            
            string checkIp1 = Global.G_IniReadValue("CROSSCHECK", "checkIp1", Global.strSettingPath);
            string checkIp2 = Global.G_IniReadValue("CROSSCHECK", "checkIp2", Global.strSettingPath);
            if (!string.IsNullOrEmpty(checkIp1) && !string.IsNullOrEmpty(checkIp2))
            {
                this.crossCheckingIp = new string[] { checkIp1, checkIp2 };
            }

            if (Global.G_IniReadValue("CROSSCHECK", "isCrossCheckRestart", Global.strSettingPath) == "Y")
            {
                this.isCrossCheckRestart = true;
            }
            else
            {
                this.isCrossCheckRestart = false;
            }

            this.crossCheckId = Global.G_IniReadValue("CROSSCHECK", "crossCheckId", Global.strSettingPath);
            this.crossCheckPw = Global.G_IniReadValue("CROSSCHECK", "crossCheckPw", Global.strSettingPath);
            
            string strInterval = Global.G_IniReadValue("CROSSCHECK", "crossCheckTimerInterval", Global.strSettingPath);
            if (!string.IsNullOrEmpty(strInterval))
            {
                int interval = 5000;
                if (int.TryParse(strInterval, out interval) == true)
                {
                    this.crossCheckTimerInterval = interval;
                }
            }



        }


        string needToCrossCheckIp = "";
        /// <summary>
        /// name         : OtherServerAppCheck
        /// desc         : 서버간 crossCheck
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void OtherServerCrossCheck()
        {
            //string myIp = GetIp();

            List<string> matchedIpList = new List<string>();

            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");
            foreach (System.Net.IPAddress ip in System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList)
            {
                if (regex.IsMatch(ip.ToString()))
                {
                    matchedIpList.Add(ip.ToString());
                }
            }

            if (matchedIpList != null && matchedIpList.Count > 0)
            {
                for (int i = 0; i < matchedIpList.Count; i++)
                {
                    string myIp = matchedIpList.ElementAt(i);

                    if (crossCheckingIp.Contains(myIp) == true)
                    {
                        foreach (string ip in crossCheckingIp)
                        {
                            if (ip == myIp)
                            {
                                continue;
                            }
                            else
                            {
                                this.needToCrossCheckIp = ip;
                            }
                        }
                    }
                }
            }

            //체크해야할 IP가 존재하는 경우
            if (!string.IsNullOrEmpty(this.needToCrossCheckIp))
            {
                timer = new System.Windows.Forms.Timer();
                timer.Interval = crossCheckTimerInterval;
                timer.Tick += Timer_Tick;
                timer.Start();
            }

        }

        

        private void Timer_Tick(object sender, EventArgs e)
        {

            //Socket oSocket = null;
            //oSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            //IPAddress oIPAddress = IPAddress.Parse(this.needToCrossCheckIp);
            //IPEndPoint oIPEndPoint = new IPEndPoint(oIPAddress, Convert.ToInt32(this.txtPort.Text));
            this.OtherServerCrossChecking();
        }



        private async void OtherServerCrossChecking()
        {
            await Task.Run(() =>
            {
                OtherServerCrossCheckingAsync();
            });
        }


        int isDisConnectCount = 0;
        /// <summary>
        /// name         : OtherServerCrossChecking
        /// desc         : 다른서버에 있는 프로그램 연결여부 확인
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void OtherServerCrossCheckingAsync()
        {
            if (string.IsNullOrEmpty(this.needToCrossCheckIp))
                return;

            bool isConnected = false;
            try
            {
                string ip = this.needToCrossCheckIp;
                int port = Convert.ToInt32(this.defaultPort);
                using (TcpClient client = new TcpClient(ip, port))
                {
                    if (client.Connected == true)
                    {
                        isConnected = true;
                    }
                }
            }
            catch
            {

            }

            //연결 끊어짐
            if (isConnected == true)
            {
                TextInputThreadSafe(this.crossCheckState, string.Format("[{0}] 연결됨", this.needToCrossCheckIp));
                isDisConnectCount = 0;
            }
            else
            {
                TextInputThreadSafe(this.crossCheckState, string.Format("[{0}] 연결 끊어짐", this.needToCrossCheckIp));
                isDisConnectCount++;
            }

            //타이머 10번 실행될 동안 연결이 안되면 프로세스를 강제로 다시 시작한다.
            if (isDisConnectCount == 10)
            {
                if (this.isCrossCheckRestart == true)
                {
                    this.RemoteProcessReStart(this.needToCrossCheckIp, crossCheckId, crossCheckPw);
                }

            }
        }

        

        private void TextInputThreadSafe(Label control, string message)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate
                {
                    TextInputThreadSafe(control, message);
                }));
                return;
            }

            control.Text = message;
        }

        System.Windows.Forms.Timer timer;



        bool isStart = false;

        private void btnStart_Click(object sender, EventArgs e)
        {

            ServerStart();
        }

        private void ServerStart()
        {

            int result = 0;
            int.TryParse(txtPort.Text.Trim(), out result);

            if (txtPort.Text.Trim().Length.Equals(0))
            {
                MessageBox.Show("Port를 입력하세요.", "Port 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            else
            {
                if (result == 0)
                {
                    MessageBox.Show("입력한 Port를 확인하세요.", "Port 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //1 ~ 65535
                else if (result < 1 || result > 65535)
                {
                    MessageBox.Show("입력한 Port를 확인하세요.[1~65535]", "Port 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    LogWriter("서버 Start....");
                    isStart = true;

                    bgwSocket.DoWork += new DoWorkEventHandler(bgwSocket_DoWorkAsync);
                    bgwSocket.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwSocket_RunWorkerCompleted);
                    bgwSocket.WorkerSupportsCancellation = true;
                    bgwSocket.RunWorkerAsync();

                    bStart = true;
                    SetControlStates(bStart);

                    //this.StartBackupWatcher(); //백업용 와쳐 실행

                }
            }
        }



        //private void StartBackupWatcher()
        //{
        //    try
        //    {
        //        m_Watcher = new System.IO.FileSystemWatcher();
        //        m_Watcher.Filter = "*.*";
        //        m_Watcher.Path = this.rootPath + "\\";

        //        m_Watcher.IncludeSubdirectories = true;

        //        m_Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
        //                                 | NotifyFilters.FileName | NotifyFilters.DirectoryName;
        //        m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
        //        m_Watcher.Created += new FileSystemEventHandler(OnCreated);
        //        m_Watcher.Deleted += new FileSystemEventHandler(OnChanged);
        //        m_Watcher.Renamed += new RenamedEventHandler(OnRenamed);
        //        m_Watcher.EnableRaisingEvents = true;
        //    }
        //    catch(Exception ex)
        //    {
        //        LogWriterForBackup(ex);
        //    }

        //}

        string createdFileName = "";
        private void OnCreated(object sender, FileSystemEventArgs e)
        {
            this.createdFileName = e.FullPath;
        }

        //private void OnChanged(object sender, FileSystemEventArgs e)
        //{
        //    try
        //    {
        //        string fullPath = e.FullPath;

        //        if (e.ChangeType == WatcherChangeTypes.Changed)
        //        {
        //            if (this.createdFileName != e.FullPath) return;

        //            // 쓰기모드로 오픈이 가능해야, 파일복사가 완료된것으로 본다.
        //            try
        //            {
        //                FileStream fs = File.Open(e.FullPath, FileMode.Open);
        //                fs.Close();
        //                fs.Dispose();
        //            }
        //            catch (IOException)
        //            {
        //                return;
        //            }


        //            FileInfo fileInfo = new FileInfo(fullPath);
        //            if (fileInfo.Exists == true)
        //            {
        //                string newFileName = "";
        //                string newFilePath = "";
        //                //파일경로 생성 및 파일명, 경로 부분 확인
        //                this.filePathCheckForBackup(fullPath, ref newFileName, ref newFilePath);
        //                //newFileName = this.DupFileRenameCheck(newFilePath, newFileName);
        //                File.Copy(fullPath, newFilePath + "\\" + newFileName);
        //                this.createdFileName = "";
        //                LogWriterForBackup("파일 생성 : " + newFilePath + "\\" + newFileName);
        //            }
        //        }
        //        else if (e.ChangeType == WatcherChangeTypes.Deleted)
        //        {

        //            string backupPath = fullPath.Replace(this.rootPath, this.rootPath_backup);


        //            FileInfo oFileInfo = new FileInfo(backupPath);
        //            if (oFileInfo.Exists == true)
        //            {
        //                oFileInfo.Delete();
        //                LogWriterForBackup("파일/폴더 삭제 : " + backupPath);
        //            }
        //            else
        //            {
        //                DirectoryInfo di = new DirectoryInfo(backupPath);
        //                if (di.Exists == true)
        //                {
        //                    di.Delete(true);
        //                    LogWriterForBackup("파일/폴더 삭제 : " + backupPath);
        //                }

        //            }
        //        }
        //    }
        //    catch(Exception ex)
        //    {
        //        LogWriterForBackup(ex);
        //    }


        //}



        private void FileBackup(string changeType, string fullPath, string oldFullPath)
        {
            if (isNeedToFileBackup == false)
            {
                return;
            }

            try
            {
                //string fullPath = e.FullPath;

                if (changeType == "UPLOAD")
                {

                    FileInfo fileInfo = new FileInfo(fullPath);
                    if (fileInfo.Exists == true)
                    {
                        string newFileName = "";
                        string newFilePath = "";
                        //파일경로 생성 및 파일명, 경로 부분 확인
                        this.filePathCheckForBackup(fullPath, ref newFileName, ref newFilePath);
                        //newFileName = this.DupFileRenameCheck(newFilePath, newFileName);
                        File.Copy(fullPath, newFilePath + "\\" + newFileName, true);
                        this.createdFileName = "";
                        LogWriterForBackup("[파일 생성] : " + newFilePath + "\\" + newFileName);
                    }
                }
                else if (changeType == "DELETE")
                {

                    string backupPath = fullPath.Replace(this.rootPath, this.rootPath_backup);


                    FileInfo oFileInfo = new FileInfo(backupPath);
                    if (oFileInfo.Exists == true)
                    {
                        oFileInfo.Delete();
                        LogWriterForBackup("[파일/폴더 삭제] : " + backupPath);
                    }
                    else
                    {
                        DirectoryInfo di = new DirectoryInfo(backupPath);
                        if (di.Exists == true)
                        {
                            di.Delete(true);
                            LogWriterForBackup("[파일/폴더 삭제] : " + backupPath);
                        }

                    }
                }
                else if (changeType == "RENAME")
                {
                    string oldNameAndPath = oldFullPath.Replace(this.rootPath, this.rootPath_backup);
                    string newNameAndPath = fullPath.Replace(this.rootPath, this.rootPath_backup);

                    FileInfo file = new FileInfo(oldNameAndPath);
                    if (file.Exists == true)
                    {
                        file.MoveTo(newNameAndPath);
                        LogWriterForBackup(string.Format("[파일/폴더 명 변경] : {0} => {1}", oldNameAndPath, newNameAndPath));
                    }
                    else
                    {
                        DirectoryInfo di = new DirectoryInfo(oldNameAndPath);
                        if (di.Exists == true)
                        {
                            di.MoveTo(newNameAndPath);
                            LogWriterForBackup(string.Format("[파일/폴더 명 변경] : {0} => {1}", oldNameAndPath, newNameAndPath));
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriterForBackup(ex);
            }
        }

        private void OnRenamed(object sender, RenamedEventArgs e)
        {
            string oldNameAndPath = e.OldFullPath.Replace(this.rootPath, this.rootPath_backup);
            string newNameAndPath = e.FullPath.Replace(this.rootPath, this.rootPath_backup);

            FileInfo file = new FileInfo(oldNameAndPath);
            if (file.Exists == true)
            {
                file.MoveTo(newNameAndPath);
                LogWriterForBackup(string.Format("파일/폴더 명 변경 : {0} => {1}", oldNameAndPath, newNameAndPath));
            }
            else
            {
                DirectoryInfo di = new DirectoryInfo(oldNameAndPath);
                if (di.Exists == true)
                {
                    di.MoveTo(newNameAndPath);
                    LogWriterForBackup(string.Format("파일/폴더 명 변경 : {0} => {1}", oldNameAndPath, newNameAndPath));
                }
            }
        }

        private void btnForderOpen_Click(object sender, EventArgs e)
        {
            try
            {
                System.Diagnostics.Process.Start("explorer.exe", rootPath);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //void bgwSocket_DoWork(object sender, DoWorkEventArgs e)
        //{
        //    CheckForIllegalCrossThreadCalls = false;

        //    int iPort = int.Parse(txtPort.Text.Trim());

        //    byte[] bytes = new byte[SocketState.BufferSize];
        //    IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
        //    IPAddress oIPAddress = null;

        //    foreach (IPAddress iIPAddress in ipHostInfo.AddressList)
        //    {
        //        if (iIPAddress.AddressFamily.Equals(AddressFamily.InterNetwork))
        //        {
        //            oIPAddress = iIPAddress;
        //        }
        //    }

        //    IPEndPoint localEndPoint = new IPEndPoint(oIPAddress, iPort);

        //    listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        //    try
        //    {
        //        listener.SetSocketOption(SocketOptionLevel.Socket, SocketOptionName.ReuseAddress, true);
        //        //listener.Bind(localEndPoint);
        //        listener.Bind(new IPEndPoint(IPAddress.Any, iPort));
        //        listener.Listen(0);

        //        while (true)
        //        {
        //            allDone.Reset();
        //            LogWriter(String.Format("IP : {0} 연결 대기중....", oIPAddress.ToString()));
        //            listener.BeginAccept(new AsyncCallback(AcceptCallback), listener);
        //            allDone.WaitOne();

        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogWriter(ex.Message);
        //        throw ex;
        //    }
        //}


        private async void bgwSocket_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            try
            {
                CheckForIllegalCrossThreadCalls = false;

                int iPort = int.Parse(txtPort.Text.Trim());

                byte[] bytes = new byte[SocketState.BufferSize];
                IPHostEntry ipHostInfo = Dns.GetHostEntry(Dns.GetHostName());
                IPAddress oIPAddress = null;

                foreach (IPAddress iIPAddress in ipHostInfo.AddressList)
                {
                    if (iIPAddress.AddressFamily.Equals(AddressFamily.InterNetwork))
                    {
                        oIPAddress = iIPAddress;
                    }
                }

                IPEndPoint localEndPoint = new IPEndPoint(oIPAddress, iPort);

                listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);


                listener.Bind(new IPEndPoint(IPAddress.Any, iPort));
                //listener.Bind(localEndPoint);
                listener.Listen(100);

                while (true)
                {
                    //allDone.Reset();
                    LogWriter(String.Format("IP : {0} 연결 대기중....", oIPAddress.ToString()));
                    try
                    {
                        Socket clientSocket = await Task.Factory.FromAsync<Socket>(listener.BeginAccept, listener.EndAccept, null);
                        LogWriter(String.Format("클라이언트 접속 : {0}", clientSocket.RemoteEndPoint.ToString()));
                        this.AcceptCallbackAsync(clientSocket);
                    }
                    catch (Exception ex)
                    {
                        LogWriter(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter(ex);
                //throw ex;
            }
        }

        private void AcceptCallbackAsync(Socket clientSock)
        {
            try
            {
                SocketState state = new SocketState();
                state.WorkSocket = clientSock;

                ReceiveMessageAsync(state);
            }
            catch (Exception ex)
            {
                LogWriter(ex);
            }
        }

        private async void ReceiveMessageAsync(SocketState state)
        {

            try
            {
                int nCount = await Task.Factory.FromAsync<int>(state.WorkSocket.BeginReceive(state.Buffer, 0, SocketState.BufferSize, SocketFlags.None, null, state), state.WorkSocket.EndReceive);


                if (nCount > 0)
                {
                    // 비동기 개체에 메시지 할당
                    state.ContentsBuilder.Append(Encoding.UTF8.GetString(state.Buffer, 0, nCount));

                    // 메시지 종료 확인
                    if (state.ContentsBuilder.ToString().IndexOf("<EOF>") > -1)
                    {
                        try
                        {
                            String strOrderType = state.ContentsBuilder.ToString().Replace("<EOF>", "").Split(Convert.ToChar("|"))[0];

                            switch (strOrderType)
                            {

                                case "FileUpload": //파일 업로드
                                    FileUploadNew(state);
                                    break;
                                case "DownloadFile": //파일 다운로드
                                    DownloadFileNew(state);
                                    break;
                                case "DirectoryExists": //폴더 체크
                                    DirectoryExistsNew(state);
                                    break;
                                case "MakeDirectory": //폴더 만들기
                                    MakeDirectoryNew(state);
                                    break;
                                case "DeleteFile": //파일 삭제
                                    DeleteFileNew(state);
                                    break;
                                case "DeleteFolder": //폴더 삭제
                                    DeleteFolder(state);
                                    break;
                                case "FileCheckInFolder": //폴더안에 파일존재여부 확인
                                    FileCheckInFolder(state);
                                    break;
                                case "ExplorerInfo": //파일관리 정보 조회
                                    ExplorerInfoNew(state);
                                    break;
                                case "NameChange": //파일/폴더 이름 변경
                                    NameChange(state);
                                    break;
                                case "CreateFolder": //새폴더 생성
                                    CreateFolder(state);
                                    break;
                                case "ImageThumbnail": //이미지 섬네일 정보 조회
                                    ImageThumbnail(state);
                                    break;
                                case "SedasSetupFileInfo": //설치파일정보 조회
                                    SedasSetupFileInfo(state);
                                    break;
                                    //case "Disconnection": // 소켓 연결 종료
                                    //    Disconnection2(state);
                                    //    break;
                            }
                        }
                        catch (Exception ex)
                        {
                            LogWriter(ex.Message);
                            //CloseSocket(Iar);
                            state.WorkSocket.Close();
                        }
                    }
                    // 메시지 추가 수신
                    else
                    {
                        ReceiveMessageAsync(state);
                    }
                }
                else
                {
                    LogWriter(String.Format("클라이언트 연결 종료 : {0}", state.WorkSocket.RemoteEndPoint.ToString()));
                    //CloseSocket(Iar);
                    state.WorkSocket.Close();
                }
            }
            catch
            {
                state.WorkSocket.Close();
            }

        }



        void bgwSocket_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                LogWriter(ex.Message);
                throw ex;
            }
        }

        #region 소켓으로 접속 요청
        //private void AcceptCallback(IAsyncResult Iar)
        //{
        //    allDone.Set();

        //    try
        //    {
        //        Socket listener = (Socket)Iar.AsyncState;
        //        Socket handler = listener.EndAccept(Iar);

        //        SocketState state = new SocketState();
        //        state.WorkSocket = handler;
        //        handler.BeginReceive(state.Buffer, 0, SocketState.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveMessage), state);
        //        LogWriter(String.Format("클라이언트 접속 : {0}", handler.RemoteEndPoint.ToString()));
        //    }
        //    catch (ObjectDisposedException odex)
        //    {
        //        StreamWriter oStreamWriter = new StreamWriter(String.Format(@"{0}\Log\{1}", appPath, DateTime.Now.ToShortDateString() + ".TXT"), true);
        //        oStreamWriter.WriteLine("프로그램 종료 : {0}", odex.Message.ToString());
        //        oStreamWriter.Close();
        //    }
        //    catch (AggregateException aex)
        //    {
        //        LogWriter(String.Format("클라이언트 접속 실패 : {0}, 오류 메시지 : {1}", ((Socket)Iar.AsyncState).RemoteEndPoint.ToString(), aex.Message.ToString()));
        //        CloseSocket(Iar);
        //    }
        //    catch (SocketException sex)
        //    {
        //        LogWriter(String.Format("클라이언트 접속 실패 : {0}, 오류 메시지 : {1}", ((Socket)Iar.AsyncState).RemoteEndPoint.ToString(), sex.Message.ToString()));
        //        CloseSocket(Iar);
        //    }
        //}
        #endregion

        #region 접속 해제
        private void CloseSocket(IAsyncResult Iar)
        {
            try
            {
                Socket handler = ((SocketState)Iar.AsyncState).WorkSocket;
                //handler.Close();
                DisConnect(handler);
            }
            catch
            {

            }
        }

        private void CloseSocket(SocketState oSocketState)
        {
            try
            {
                //oSocketState.WorkSocket.Close();
                DisConnect(oSocketState.WorkSocket);
            }
            catch
            {

            }
        }

        private void CloseSocket(Socket socket)
        {
            try
            {
                //socket.Close();
                DisConnect(socket);
            }
            catch
            {

            }
        }

        private void DisConnect(Socket socket)
        {
            if (socket != null)
            {
                socket.Disconnect(false);
                socket.Close();
            }

            socket = null;
        }


        #endregion

        #region 소켓으로 부터 메시지 수신
        //private void ReceiveMessage(IAsyncResult Iar)
        //{
        //    try
        //    {
        //        SocketState state = (SocketState)Iar.AsyncState;
        //        Socket handler = state.WorkSocket;

        //        // 리시브 버퍼에서 데이터 읽기
        //        int iMessageLength = handler.EndReceive(Iar);

        //        // 메시지의 길이가 0보다 작은 경우 연결 종료 문자열
        //        if (iMessageLength > 0)
        //        {
        //            // 비동기 개체에 메시지 할당
        //            state.ContentsBuilder.Append(Encoding.UTF8.GetString(state.Buffer, 0, iMessageLength));

        //            // 메시지 종료 확인
        //            if (state.ContentsBuilder.ToString().IndexOf("<EOF>") > -1)
        //            {
        //                try
        //                {
        //                    String strOrderType = state.ContentsBuilder.ToString().Replace("<EOF>", "").Split(Convert.ToChar("|"))[0];

        //                    switch (strOrderType)
        //                    {
        //                        //파일 업로드
        //                        case "FileUpload":
        //                            FileUpload(Iar);
        //                            break;
        //                        case "DownloadFile":
        //                            DownloadFile(Iar);
        //                            break;
        //                        case "DirectoryExists":
        //                            DirectoryExists(Iar);
        //                            break;
        //                        case "MakeDirectory":
        //                            MakeDirectory(Iar);
        //                            break;
        //                        case "DeleteFile":
        //                            DeleteFile(Iar);
        //                            break;
        //                        case "ExplorerInfo":
        //                            ExplorerInfo(Iar);
        //                            break;
        //                        // 소켓 연결 종료
        //                        case "Disconnection":
        //                            Disconnection(Iar);
        //                            break;
        //                    }
        //                }
        //                catch (Exception ex)
        //                {
        //                    LogWriter(ex.Message);
        //                    CloseSocket(Iar);
        //                }
        //            }
        //            // 메시지 추가 수신
        //            else
        //            {
        //                handler.BeginReceive(state.Buffer, 0, SocketState.BufferSize, 0, new AsyncCallback(ReceiveMessage), state);
        //            }
        //        }
        //        else
        //        {
        //            LogWriter(String.Format("클라이언트 연결 종료 : {0}", handler.RemoteEndPoint.ToString()));
        //            CloseSocket(Iar);
        //        }
        //    }
        //    catch
        //    {
        //        CloseSocket(Iar);
        //    }
        //}
        #endregion




        /// <summary>
        /// name         : DirectoryExistsNew
        /// desc         : 폴더 체크
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void DirectoryExistsNew(SocketState oSocketState)
        {
            Socket oSocket = oSocketState.WorkSocket;
            String[] arrContents = GetContentsArray(oSocketState.ContentsBuilder);


            string exists = "N"; //폴더존재여부

            try
            {
                string param1 = arrContents[1].Trim();
                string filePath = param1;
                if (!string.IsNullOrEmpty(filePath) && filePath.Length > 2)
                {
                    if (filePath.Substring(0, 1) == "\\")
                    {
                        filePath = filePath.Substring(1, filePath.Length - 1);
                    }
                }

                filePath = rootPath + "\\" + filePath;
                //FileInfo oFileInfo = new FileInfo(rootPath + "\\" + filePath);


                DirectoryInfo di = new DirectoryInfo(filePath);


                if (di.Exists)
                {
                    exists = "Y";
                }

                Byte[] byteData = Encoding.UTF8.GetBytes(exists + "<EOF>");
                LogWriter(String.Format("디렉토리 확인 : {0}", param1));
                oSocket.Send(byteData);


                await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);



            }
            catch (SocketException oSocketException)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocketState);
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(ex);

                Byte[] byteData = Encoding.UTF8.GetBytes("▥FAIL▥" + "|" + ex.Message + "<EOF>");
                await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);

                CloseSocket(oSocketState);
            }
        }



        public bool ThumbnailCallback()
        {
            return true;
        }





        /// <summary>
        /// name         : StringToDate
        /// desc         : 스트링을 Date형식으로 변환
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private DateTime? StringToDate(string str)
        {
            if (str.Length == 14)
            {
                if (str.Substring(0, 4).ToIntOrNull() == null)
                {
                    return null;
                }

                int yyyy = str.Substring(0, 4).ToInt();

                if (str.Substring(4, 2).ToIntOrNull() == null)
                {
                    return null;
                }

                int MM = str.Substring(4, 2).ToInt();

                if (str.Substring(6, 2).ToIntOrNull() == null)
                {
                    return null;
                }

                int dd = str.Substring(6, 2).ToInt();

                if (str.Substring(8, 2).ToIntOrNull() == null)
                {
                    return null;
                }

                int hh = str.Substring(8, 2).ToInt();

                if (str.Substring(10, 2).ToIntOrNull() == null)
                {
                    return null;
                }

                int mi = str.Substring(10, 2).ToInt();

                if (str.Substring(12, 2).ToIntOrNull() == null)
                {
                    return null;
                }

                int ss = str.Substring(12, 2).ToInt();

                DateTime dt = new DateTime(yyyy, MM, dd, hh, mi, ss);
                return dt;
            }
            return null;
        }


        /// <summary>
        /// name         : SedasSetupFileInfo
        /// desc         : 설치파일 정보를 보내준다.
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void SedasSetupFileInfo(SocketState oSocketState)
        {
            Socket oSocket = oSocketState.WorkSocket;
            String[] arrContents = GetContentsArray(oSocketState.ContentsBuilder);

            try
            {
                //string newFolerFullName = "";

                string projectName = arrContents[1].Trim();
                string lastChangedDtm = arrContents[2].Trim();
                //string version = arrContents[3].Trim();


                string serverPath = this.rootPath;
                string targetPath = serverPath + "\\" + "SedasSetupFiles" + "\\" + projectName;

                //버전 정보를 확인한다.
                //string strSettingPath = System.Environment.CurrentDirectory + "\\launcherSetting.ini";




                bool isSuccess = false;
                DateTime lastDtm = DateTime.Now;
                if (lastChangedDtm.Length == 14)
                {
                    DateTime? tempDtm = StringToDate(lastChangedDtm);
                    if (tempDtm != null)
                    {
                        lastDtm = tempDtm.Value;
                    }
                }


                

                DirectoryInfo di = new DirectoryInfo(targetPath);

                if (di.Exists)
                {
                    List<FileInfo> files = GetAllFiles(di.FullName);

                    DataTable dt2 = new DataTable();
                    dt2.Columns.Add("fileFullName");
                    dt2.Columns.Add("fileCheckName");
                    dt2.Columns.Add("createTime");
                    dt2.Columns.Add("length");

                    if (files != null && files.Count > 0)
                    {
                        foreach (FileInfo file in files)
                        {
                            //if (file.Name == "IIP.exe")
                            //{ 
                            
                            //}

                            if ((file.CreationTime - lastDtm).TotalSeconds > 0 || (file.LastWriteTime - lastDtm).TotalSeconds > 0)
                            {
                                DataRow row = dt2.NewRow();
                                row["fileFullName"] = file.FullName.Replace(serverPath, "");
                                row["fileCheckName"] = file.FullName.Replace(targetPath, "");
                                row["createTime"] = file.CreationTime.ToString("yyyyMMddHHmmss");
                                row["length"] = file.Length.ToString();

                                dt2.Rows.Add(row);
                            }
                        }
                    }





                    if (dt2 != null && dt2.Rows.Count > 0)
                    {
                        string jsonDtValue = JsonConvert.SerializeObject(dt2);



                        Byte[] byteData = Encoding.UTF8.GetBytes("EXISTS" + "|" + jsonDtValue + "<EOF>");
                        LogWriter(String.Format("설치파일 정보 조회 : {0}", projectName));
                        //oSocket.Send(byteData);

                        await Task.Factory.FromAsync(
                                    oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                                    oSocket.EndSend);

                        isSuccess = true;

                    }
                    else
                    {
                        Byte[] byteData = Encoding.UTF8.GetBytes("OK" + "|" + " " + "<EOF>");
                        await Task.Factory.FromAsync(
                                    oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                                    oSocket.EndSend);
                    }

                }

                if (isSuccess == false)
                {
                    Byte[] byteData = Encoding.UTF8.GetBytes("FAIL" + "|" + " " + "<EOF>");
                    await Task.Factory.FromAsync(
                                oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                                oSocket.EndSend);
                }

            }
            catch (SocketException oSocketException)
            {
                LogWriter(String.Format("설치파일 정보 조회 중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocketState);
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("설치파일 정보 조회 중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(ex);

                CloseSocket(oSocketState);
            }
        }



        /// <summary>
        /// name         : GetAllFiles
        /// desc         : 해당 디렉토리 안의 모든 파일정보 리턴
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private List<FileInfo> GetAllFiles(string directoriPath)
        {
            List<FileInfo> totalFiles = new List<FileInfo>();
            DirectoryInfo di = new DirectoryInfo(directoriPath);
            if (di.Exists)
            {
                DirectoryInfo[] directories = di.GetDirectories();

                if (directories != null && directories.Count() > 0)
                {
                    foreach (DirectoryInfo subDi in directories)
                    {
                        List<FileInfo> subFiles = GetAllFiles(subDi.FullName);
                        totalFiles.AddRange(subFiles);
                    }
                }

                FileInfo[] files = di.GetFiles();
                if (files != null && files.Count() > 0)
                {
                    totalFiles.AddRange(files);
                }

            }
            return totalFiles;
        }


        /// <summary>
        /// name         : ImageThumbnail
        /// desc         : 이미지 섬네일 조회
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 

        private async void ImageThumbnail(SocketState oSocketState)
        {
            Socket oSocket = oSocketState.WorkSocket;
            String[] arrContents = GetContentsArray(oSocketState.ContentsBuilder);

            try
            {
                //string newFolerFullName = "";

                string paramPathAndName = arrContents[1].Trim();

                FileInfo file = new FileInfo(rootPath + "\\" + paramPathAndName);

                if (file.Exists)
                {
                    using (Image image = new Bitmap(file.FullName))
                    {
                        Image.GetThumbnailImageAbort callback =
                                    new Image.GetThumbnailImageAbort(ThumbnailCallback);

                        using (Image pThumbnail = image.GetThumbnailImage(150, 150, callback, new IntPtr()))
                        {
                            string strImage = imageToString(pThumbnail);
                            Byte[] byteData = Encoding.UTF8.GetBytes("OK" + "|" + strImage + "<EOF>");
                            LogWriter(String.Format("섬네일 조회 : {0}", paramPathAndName));
                            await Task.Factory.FromAsync(
                                        oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                                        oSocket.EndSend);

                            //image = null;
                            //pThumbnail = null;
                        }
                    }
                }
                else
                {
                    Byte[] byteData = Encoding.UTF8.GetBytes("FAIL" + "|" + " " + "<EOF>");
                    await Task.Factory.FromAsync(
                                oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                                oSocket.EndSend);
                }

            }
            catch (SocketException oSocketException)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocketState);
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(ex);

                CloseSocket(oSocketState);
            }
        }


        /// <summary>
        /// name         : CreateFolder
        /// desc         : 새폴더 생성
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void CreateFolder(SocketState oSocketState)
        {
            Socket oSocket = oSocketState.WorkSocket;
            String[] arrContents = GetContentsArray(oSocketState.ContentsBuilder);

            try
            {
                string newFolerFullName = "";

                string paramPath = arrContents[1].Trim();

                DirectoryInfo directoryInfo = new DirectoryInfo(rootPath + "\\" + paramPath);

                //경로 확인
                if (directoryInfo.Exists == false)
                {
                    Byte[] byteData = Encoding.UTF8.GetBytes("FAIL" + "<EOF>");
                    await Task.Factory.FromAsync(
                        oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                        oSocket.EndSend);
                    return;
                }

                //신규 폴더명 중복체크
                string newFolderName = DupFolderNameCheck("새폴더", directoryInfo.FullName);

                if (!string.IsNullOrEmpty(newFolderName))
                {
                    DirectoryInfo di = new DirectoryInfo(rootPath + "\\" + paramPath + "\\" + newFolderName);
                    newFolerFullName = di.FullName;
                    if (di.Exists == false)
                    {
                        di.Create();
                    }
                }


                Byte[] byteData2 = Encoding.UTF8.GetBytes("OK" + "<EOF>");
                LogWriter(String.Format("신규폴더 생성 : {0}", newFolerFullName));
                //oSocket.Send(byteData2);
                await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData2, 0, byteData2.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);
            }
            catch (SocketException oSocketException)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocketState);
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(ex);

                CloseSocket(oSocketState);
            }
        }

        /// <summary>
        /// name         : NameChange
        /// desc         : 파일/폴더 이름 변경
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void NameChange(SocketState oSocketState)
        {
            Socket oSocket = oSocketState.WorkSocket;
            String[] arrContents = GetContentsArray(oSocketState.ContentsBuilder);

            string exists = "N"; //폴더존재여부

            try
            {
                //클라이언트에서 받아야할 데이터
                string paramPath = arrContents[1].Trim();
                string newName = arrContents[2].Trim();
                string type = arrContents[3].Trim();

                if (type == "F") //파일인 경우에만
                {
                    FileInfo fileInfo = new FileInfo(rootPath + "\\" + paramPath);

                    //체크1 : 파일이 존재하는 확인필요
                    string newFilePath = fileInfo.Directory + "\\" + newName;
                    FileInfo newFileInfo = new FileInfo(newFilePath);

                    if (newFileInfo.Exists == true)
                    {
                        //이미 파일이 존재하는 경우
                        //MessageBox.Show("이미 동일한 파일이 존재합니다. 다른이름으로 변경해 주세요");
                        Byte[] byteData = Encoding.UTF8.GetBytes("DUP" + "<EOF>");
                        await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);

                        return;
                    }

                    string newPath = Path.Combine(fileInfo.DirectoryName, newName);
                    fileInfo.MoveTo(newPath);

                    //백업서버에 전달
                    this.FileBackup("RENAME", newPath, rootPath + "\\" + paramPath);
                }
                else if (type == "D")
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(rootPath + "\\" + paramPath);
                    //string lastPath = directoryInfo.FullName.Split('\\').LastOrDefault();
                    string pathName = directoryInfo.FullName.Substring(0, directoryInfo.FullName.Length - directoryInfo.Name.Length);

                    string newPath = pathName + newName;

                    DirectoryInfo newDirInfo = new DirectoryInfo(newPath);
                    if (newDirInfo.Exists == true)
                    {
                        //MessageBox.Show("이미 동일한 폴더가 존재합니다. 다른이름으로 변경해 주세요");
                        Byte[] byteData = Encoding.UTF8.GetBytes("DUP" + "<EOF>");
                        await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);
                        return;
                    }

                    Directory.Move(rootPath + "\\" + paramPath, newPath);

                    //백업서버에 전달
                    this.FileBackup("RENAME", rootPath + "\\" + paramPath, newPath);
                }

                Byte[] byteData2 = Encoding.UTF8.GetBytes("OK" + "<EOF>");
                LogWriter(String.Format("파일/폴더 명 변경 : {0} => {1}", paramPath, newName));
                //oSocket.Send(byteData2);
                await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData2, 0, byteData2.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);



            }
            catch (SocketException oSocketException)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocketState);
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(ex);

                CloseSocket(oSocketState);
            }
        }



        /// <summary>
        /// name         : ExplorerInfoNew
        /// desc         : 파일관리 정보 조회
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void ExplorerInfoNew(SocketState oSocketState)
        {
            Socket oSocket = oSocketState.WorkSocket;
            String[] arrContents = GetContentsArray(oSocketState.ContentsBuilder);

            try
            {
                string param1 = arrContents[1].Trim();
                string filePath = param1;
                if (!string.IsNullOrEmpty(filePath) && filePath.Length > 2)
                {
                    if (filePath.Substring(0, 1) == "\\")
                    {
                        filePath = filePath.Substring(1, filePath.Length - 1);
                    }
                }

                string paramIcon = arrContents[2];
                string paramSize = arrContents[3];


                DataTable dt = new DataTable();
                dt.Columns.Add("type", typeof(String));
                dt.Columns.Add("name", typeof(String));
                dt.Columns.Add("fullName", typeof(String));
                dt.Columns.Add("image", typeof(String));

                DataTable imageDt = new DataTable();
                imageDt.Columns.Add("imageCode", typeof(String));
                imageDt.Columns.Add("imageValue", typeof(String));

                Size itemSize = new Size(Convert.ToInt32(paramSize), Convert.ToInt32(paramSize));


                IconSizeType sizeType = IconSizeType.Medium;
                if (paramIcon == "1")
                {
                    sizeType = IconSizeType.ExtraLarge;
                }
                else if (paramIcon == "2")
                {
                    sizeType = IconSizeType.Large;
                }
                else if (paramIcon == "3")
                {
                    sizeType = IconSizeType.Medium;
                }
                else if (paramIcon == "4")
                {
                    sizeType = IconSizeType.Small;
                }







                DirectoryInfo info = new DirectoryInfo(rootPath + "\\" + filePath);
                if (info.Exists)
                {
                    DirectoryInfo[] directories = info.GetDirectories("*", SearchOption.TopDirectoryOnly);
                    for (int i = 0; (i < directories.Length); i++)
                    {
                        DirectoryInfo info2 = directories[i];
                        if (CheckAccess(info2) && MatchFilter(info2.Attributes))
                        {
                            //string fullName = info2.FullName.Substring(1, info2.FullName.Length - 2);
                            //fullName = "Z" + fullName;
                            string fullName = info2.FullName;
                            fullName = fullName.Replace(rootPath, ""); //루트경로는 빼고 전달하자.

                            string[] nameSplit = info2.Name.Split('.');
                            string imageCode = "";
                            if (nameSplit.Count() == 1)
                            {
                                imageCode = "D_NULL";
                                DataRow tempRow = imageDt.AsEnumerable().Where(e => e["imageCode"].ToString() == imageCode).FirstOrDefault();
                                if (tempRow == null)
                                {
                                    DataRow newRow = imageDt.NewRow();
                                    newRow["imageCode"] = imageCode;
                                    newRow["imageValue"] = imageToString(GetImage(info2.FullName, sizeType, itemSize));
                                    imageDt.Rows.Add(newRow);
                                }
                            }
                            else
                            {
                                imageCode = nameSplit.ElementAt(nameSplit.Count() - 1);

                                DataRow tempRow = imageDt.AsEnumerable().Where(e => e["imageCode"].ToString() == imageCode).FirstOrDefault();
                                if (tempRow == null)
                                {
                                    DataRow newRow = imageDt.NewRow();
                                    newRow["imageCode"] = imageCode;
                                    newRow["imageValue"] = imageToString(GetImage(info2.FullName, sizeType, itemSize));
                                    imageDt.Rows.Add(newRow);
                                }
                            }






                            DataRow row = dt.NewRow();
                            row["type"] = "D";
                            row["name"] = info2.Name;
                            row["fullName"] = fullName; // info2.FullName;
                            row["image"] = imageCode; // imageToString(GetImage(info2.FullName, sizeType, itemSize));

                            dt.Rows.Add(row);
                        }
                        //    col.Add(new DirectoryEntry(info2.Name, info2.FullName, GetImage(info2.FullName, sizeType, itemSize)));
                    }
                }



                //파일
                if (info.Exists)
                {
                    FileInfo[] files = info.GetFiles("*", SearchOption.TopDirectoryOnly);
                    for (int i = 0; (i < files.Length); i++)
                    {
                        FileInfo info2 = files[i];
                        if (MatchFilter(info2.Attributes))
                        {

                            //string fullName = info2.FullName.Substring(1, info2.FullName.Length - 2);
                            //fullName = "Z" + fullName;
                            string fullName = info2.FullName;
                            fullName = fullName.Replace(rootPath, ""); //루트경로는 빼고 전달하자.


                            //imageDt.AsEnumerable().Where(e=>e[""])

                            string[] nameSplit = info2.Name.Split('.');
                            string imageCode = "";
                            if (nameSplit.Count() == 1)
                            {
                                imageCode = "F_NULL";
                                DataRow tempRow = imageDt.AsEnumerable().Where(e => e["imageCode"].ToString() == imageCode).FirstOrDefault();
                                if (tempRow == null)
                                {
                                    DataRow newRow = imageDt.NewRow();
                                    newRow["imageCode"] = imageCode;
                                    newRow["imageValue"] = imageToString(GetImage(info2.FullName, sizeType, itemSize));
                                    imageDt.Rows.Add(newRow);
                                }
                            }
                            else
                            {
                                imageCode = nameSplit.ElementAt(nameSplit.Count() - 1);

                                DataRow tempRow = imageDt.AsEnumerable().Where(e => e["imageCode"].ToString() == imageCode).FirstOrDefault();
                                if (tempRow == null)
                                {
                                    DataRow newRow = imageDt.NewRow();
                                    newRow["imageCode"] = imageCode;
                                    newRow["imageValue"] = imageToString(GetImage(info2.FullName, sizeType, itemSize));
                                    imageDt.Rows.Add(newRow);
                                }
                            }


                            //col.Add(new FileEntry(info2.Name, info2.FullName, GetImage(info2.FullName, sizeType, itemSize)));
                            DataRow row = dt.NewRow();
                            row["type"] = "F";
                            row["name"] = info2.Name;
                            row["fullName"] = fullName;
                            row["image"] = imageCode; //imageToString(GetImage(info2.FullName, sizeType, itemSize));

                            dt.Rows.Add(row);
                        }

                    }

                    //col.Add(new FileEntry("test1111", "D:\\LocalData\\202005211628170(1).jpg", GetImage("D:\\LocalData\\202005211628170(1).jpg", sizeType, itemSize)));
                }


                string jsonValue = JsonConvert.SerializeObject(dt);
                string jsonImageDtValue = JsonConvert.SerializeObject(imageDt);


                Byte[] byteData = Encoding.UTF8.GetBytes(jsonValue + "|" + jsonImageDtValue + "<EOF>");
                LogWriter(String.Format("파일 Explorer정보 : {0}", param1));
                //oSocket.Send(byteData);

                await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);
            }
            catch (SocketException oSocketException)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocketState);
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(ex);

                Byte[] byteData = Encoding.UTF8.GetBytes("FAIL" + "<EOF>");
                await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);

                CloseSocket(oSocketState);
            }
        }


        /// <summary>
        /// name         : ExplorerInfo
        /// desc         : 파일 탐색기 정보 표시를 위한 정보 리턴
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ExplorerInfo(IAsyncResult Iar)
        {
            SocketState oSocketState = (SocketState)Iar.AsyncState;
            Socket oSocket = oSocketState.WorkSocket;
            String[] arrContents = GetContentsArray(oSocketState.ContentsBuilder);

            try
            {
                string param1 = arrContents[1].Trim();
                string filePath = param1;
                if (!string.IsNullOrEmpty(filePath) && filePath.Length > 2)
                {
                    if (filePath.Substring(0, 1) == "\\")
                    {
                        filePath = filePath.Substring(1, filePath.Length - 1);
                    }
                }


                //FileInfo oFileInfo = new FileInfo(rootPath + "\\" + filePath);
                //if (oFileInfo.Exists == true)
                //{
                //    oFileInfo.Delete();
                //}

                string paramIcon = arrContents[2];
                string paramSize = arrContents[3];


                DataTable dt = new DataTable();
                dt.Columns.Add("type", typeof(String));
                dt.Columns.Add("name", typeof(String));
                dt.Columns.Add("fullName", typeof(String));
                dt.Columns.Add("image", typeof(String));

                DataTable imageDt = new DataTable();
                imageDt.Columns.Add("imageCode", typeof(String));
                imageDt.Columns.Add("imageValue", typeof(String));

                Size itemSize = new Size(Convert.ToInt32(paramSize), Convert.ToInt32(paramSize));


                IconSizeType sizeType = IconSizeType.Medium;
                if (paramIcon == "1")
                {
                    sizeType = IconSizeType.ExtraLarge;
                }
                else if (paramIcon == "2")
                {
                    sizeType = IconSizeType.Large;
                }
                else if (paramIcon == "3")
                {
                    sizeType = IconSizeType.Medium;
                }
                else if (paramIcon == "4")
                {
                    sizeType = IconSizeType.Small;
                }







                DirectoryInfo info = new DirectoryInfo(rootPath + "\\" + filePath);
                if (info.Exists)
                {
                    DirectoryInfo[] directories = info.GetDirectories("*", SearchOption.TopDirectoryOnly);
                    for (int i = 0; (i < directories.Length); i++)
                    {
                        DirectoryInfo info2 = directories[i];
                        if (CheckAccess(info2) && MatchFilter(info2.Attributes))
                        {
                            //string fullName = info2.FullName.Substring(1, info2.FullName.Length - 2);
                            //fullName = "Z" + fullName;
                            string fullName = info2.FullName;


                            string[] nameSplit = info2.Name.Split('.');
                            string imageCode = "";
                            if (nameSplit.Count() == 1)
                            {
                                imageCode = "D_NULL";
                                DataRow tempRow = imageDt.AsEnumerable().Where(e => e["imageCode"].ToString() == imageCode).FirstOrDefault();
                                if (tempRow == null)
                                {
                                    DataRow newRow = imageDt.NewRow();
                                    newRow["imageCode"] = imageCode;
                                    newRow["imageValue"] = imageToString(GetImage(info2.FullName, sizeType, itemSize));
                                    imageDt.Rows.Add(newRow);
                                }
                            }
                            else
                            {
                                imageCode = nameSplit.ElementAt(nameSplit.Count() - 1);

                                DataRow tempRow = imageDt.AsEnumerable().Where(e => e["imageCode"].ToString() == imageCode).FirstOrDefault();
                                if (tempRow == null)
                                {
                                    DataRow newRow = imageDt.NewRow();
                                    newRow["imageCode"] = imageCode;
                                    newRow["imageValue"] = imageToString(GetImage(info2.FullName, sizeType, itemSize));
                                    imageDt.Rows.Add(newRow);
                                }
                            }






                            DataRow row = dt.NewRow();
                            row["type"] = "D";
                            row["name"] = info2.Name;
                            row["fullName"] = fullName; // info2.FullName;
                            row["image"] = imageCode; // imageToString(GetImage(info2.FullName, sizeType, itemSize));

                            dt.Rows.Add(row);
                        }
                        //    col.Add(new DirectoryEntry(info2.Name, info2.FullName, GetImage(info2.FullName, sizeType, itemSize)));
                    }
                }



                //파일
                if (info.Exists)
                {
                    FileInfo[] files = info.GetFiles("*", SearchOption.TopDirectoryOnly);
                    for (int i = 0; (i < files.Length); i++)
                    {
                        FileInfo info2 = files[i];
                        if (MatchFilter(info2.Attributes))
                        {

                            //string fullName = info2.FullName.Substring(1, info2.FullName.Length - 2);
                            //fullName = "Z" + fullName;
                            string fullName = info2.FullName;


                            //imageDt.AsEnumerable().Where(e=>e[""])

                            string[] nameSplit = info2.Name.Split('.');
                            string imageCode = "";
                            if (nameSplit.Count() == 1)
                            {
                                imageCode = "F_NULL";
                                DataRow tempRow = imageDt.AsEnumerable().Where(e => e["imageCode"].ToString() == imageCode).FirstOrDefault();
                                if (tempRow == null)
                                {
                                    DataRow newRow = imageDt.NewRow();
                                    newRow["imageCode"] = imageCode;
                                    newRow["imageValue"] = imageToString(GetImage(info2.FullName, sizeType, itemSize));
                                    imageDt.Rows.Add(newRow);
                                }
                            }
                            else
                            {
                                imageCode = nameSplit.ElementAt(nameSplit.Count() - 1);

                                DataRow tempRow = imageDt.AsEnumerable().Where(e => e["imageCode"].ToString() == imageCode).FirstOrDefault();
                                if (tempRow == null)
                                {
                                    DataRow newRow = imageDt.NewRow();
                                    newRow["imageCode"] = imageCode;
                                    newRow["imageValue"] = imageToString(GetImage(info2.FullName, sizeType, itemSize));
                                    imageDt.Rows.Add(newRow);
                                }
                            }


                            //col.Add(new FileEntry(info2.Name, info2.FullName, GetImage(info2.FullName, sizeType, itemSize)));
                            DataRow row = dt.NewRow();
                            row["type"] = "F";
                            row["name"] = info2.Name;
                            row["fullName"] = fullName;
                            row["image"] = imageCode; //imageToString(GetImage(info2.FullName, sizeType, itemSize));

                            dt.Rows.Add(row);
                        }

                    }

                    //col.Add(new FileEntry("test1111", "D:\\LocalData\\202005211628170(1).jpg", GetImage("D:\\LocalData\\202005211628170(1).jpg", sizeType, itemSize)));
                }


                string jsonValue = JsonConvert.SerializeObject(dt);
                string jsonImageDtValue = JsonConvert.SerializeObject(imageDt);



                Byte[] byteData = Encoding.UTF8.GetBytes(jsonValue + "|" + jsonImageDtValue + "<EOF>");
                LogWriter(String.Format("파일 Explorer정보 : {0}", param1));
                oSocket.Send(byteData);
            }
            catch (SocketException oSocketException)
            {

                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(Iar);
            }
        }

        public static bool CheckAccess(DirectoryInfo info)
        {
            bool hasAccess = false;
            try
            {
                info.GetAccessControl();
                hasAccess = true;
            }
            catch
            {
            }
            return hasAccess;
        }


        public static bool MatchFilter(FileAttributes attributes)
        {
            return ((attributes & (FileAttributes.System | FileAttributes.Hidden)) == 0);
        }

        private string imageToString(Image image)
        {
            string strImage = "";
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

                byte[] bitmapByte = memoryStream.ToArray();
                strImage = Convert.ToBase64String(bitmapByte);
            }
            return strImage;
        }

        public static Image GetImage(string path, IconSizeType sizeType, Size itemSize)
        {
            return FileSystemImageCache.Cache.GetImage(path, sizeType, itemSize);
        }



        /// <summary>
        /// name         : FileCheckInFolder
        /// desc         : 폴더안에 파일 존재여부 확인
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void FileCheckInFolder(SocketState oSocketState)
        {
            Socket oSocket = oSocketState.WorkSocket;
            String[] arrContents = GetContentsArray(oSocketState.ContentsBuilder);

            try
            {
                string param1 = arrContents[1].Trim();
                string folderName = param1;
                if (!string.IsNullOrEmpty(folderName) && folderName.Length > 2)
                {
                    if (folderName.Substring(0, 1) == "\\")
                    {
                        folderName = folderName.Substring(1, folderName.Length - 1);
                    }
                }


                string exists = "N";
                if (isFiles(rootPath + "\\" + folderName) == true)
                {
                    exists = "Y";
                }


                Byte[] byteData = Encoding.UTF8.GetBytes(exists + "<EOF>");
                LogWriter(String.Format("폴더안에 파일 존재여부 확인 : {0}", param1));
                //oSocket.Send(byteData);


                await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);

            }
            catch (SocketException oSocketException)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocketState);
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(ex);

                CloseSocket(oSocketState);
            }
        }

        /// <summary>
        /// name         : DeleteFolder
        /// desc         : 폴더 삭제
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void DeleteFolder(SocketState oSocketState)
        {
            Socket oSocket = oSocketState.WorkSocket;
            String[] arrContents = GetContentsArray(oSocketState.ContentsBuilder);

            try
            {
                string param1 = arrContents[1].Trim();
                string folderName = param1;
                if (!string.IsNullOrEmpty(folderName) && folderName.Length > 2)
                {
                    if (folderName.Substring(0, 1) == "\\")
                    {
                        folderName = folderName.Substring(1, folderName.Length - 1);
                    }
                }


                DirectoryInfo di = new DirectoryInfo(rootPath + "\\" + folderName);

                di.Delete(true); //true 넣으면 파일 존재시에도 모두 삭제

                Byte[] byteData = Encoding.UTF8.GetBytes("OK<EOF>");
                LogWriter(String.Format("폴더삭제 : {0}", param1));
                //oSocket.Send(byteData);


                await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);


                //백업서버에 전달
                this.FileBackup("DELETE", rootPath + "\\" + folderName, "");

            }
            catch (SocketException oSocketException)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocketState);
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(ex);

                CloseSocket(oSocketState);
            }
        }



        /// <summary>
        /// name         : isFiles
        /// desc         : 폴더안에 파일존재여부 확인
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool isFiles(string dir)
        {
            try
            {
                string[] directories = Directory.GetDirectories(dir);

                string[] files = Directory.GetFiles(dir);
                if (files.Length != 0) return true;

                if (directories != null && directories.Count() > 0)
                {
                    foreach (string nodeDir in directories)
                    {
                        if (isFiles(nodeDir) == true)
                        {
                            return true;
                        }
                    }
                }

                return false;
            }
            catch
            {
                return true;
            }

        }

        /// <summary>
        /// name         : DeleteFileNew
        /// desc         : 파일 삭제
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void DeleteFileNew(SocketState oSocketState)
        {
            Socket oSocket = oSocketState.WorkSocket;
            String[] arrContents = GetContentsArray(oSocketState.ContentsBuilder);

            try
            {
                string param1 = arrContents[1].Trim();
                string filePath = param1;
                if (!string.IsNullOrEmpty(filePath) && filePath.Length > 2)
                {
                    if (filePath.Substring(0, 1) == "\\")
                    {
                        filePath = filePath.Substring(1, filePath.Length - 1);
                    }
                }


                FileInfo oFileInfo = new FileInfo(rootPath + "\\" + filePath);
                if (oFileInfo.Exists == true)
                {
                    oFileInfo.Delete();
                }

                Byte[] byteData = Encoding.UTF8.GetBytes("OK<EOF>");
                LogWriter(String.Format("파일삭제 : {0}", param1));
                //oSocket.Send(byteData);

                await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);

                //백업서버에 전달
                this.FileBackup("DELETE", rootPath + "\\" + filePath, "");

            }
            catch (SocketException oSocketException)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocketState);
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(ex);

                Byte[] byteData = Encoding.UTF8.GetBytes("▥FAIL▥" + "|" + ex.Message + "<EOF>");
                await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);

                CloseSocket(oSocketState);
            }
        }



        /// <summary>
        /// name         : MakeDirectoryNew
        /// desc         : 폴더 만들기
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void MakeDirectoryNew(SocketState oSocketState)
        {
            Socket oSocket = oSocketState.WorkSocket;
            String[] arrContents = GetContentsArray(oSocketState.ContentsBuilder);

            try
            {
                string param1 = arrContents[1].Trim();
                string filePath = param1;
                if (!string.IsNullOrEmpty(filePath) && filePath.Length > 2)
                {
                    if (filePath.Substring(0, 1) == "\\")
                    {
                        filePath = filePath.Substring(1, filePath.Length - 1);
                    }
                }

                string[] spliPath = filePath.Split('\\');

                string path = this.rootPath;


                if (spliPath != null && spliPath.Count() > 0)
                {
                    for (int i = 0; i < spliPath.Count(); i++)
                    {
                        path = path + "\\" + spliPath.ElementAt(i);
                        this.DirectoryCheck(path);


                    }
                }

                Byte[] byteData = Encoding.UTF8.GetBytes("OK<EOF>");
                LogWriter(String.Format("디렉토리 생성 : {0}", param1));
                //oSocket.Send(byteData);

                await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);

            }
            catch (SocketException oSocketException)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocketState);
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(ex);

                Byte[] byteData = Encoding.UTF8.GetBytes("▥FAIL▥" + "|" + ex.Message + "<EOF>");
                await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);

                CloseSocket(oSocketState);
            }
        }





        /// <summary>
        /// name         : DownloadFileNew
        /// desc         : 파일 다운로드
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void DownloadFileNew(SocketState oSocketState)
        {
            Socket oSocket = oSocketState.WorkSocket;

            // 쓰레드 접근 제한
            MrReceiveFileDone.Reset();

            try
            {
                // 파일 생성 정보 할당
                String[] arrContents = GetContentsArray(oSocketState.ContentsBuilder);
                string filePath = arrContents[1].Trim();
                if (!string.IsNullOrEmpty(filePath) && filePath.Length > 2)
                {
                    if (filePath.Substring(0, 1) == "\\")
                    {
                        filePath = filePath.Substring(1, filePath.Length - 1);
                    }
                }


                FileInfo oFileInfo = new FileInfo(rootPath + "\\" + filePath);

                Byte[] byteData = Encoding.UTF8.GetBytes("FileData|" + oFileInfo.Name + "|" + oFileInfo.Length.ToString() + "<EOF>");


                oSocketState.fileInfo = oFileInfo;
                //oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(DownLoadCallBack_1), oSocketState);


                await Task.Factory.FromAsync(
                            oSocketState.WorkSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocketState.WorkSocket),
                            oSocketState.WorkSocket.EndSend);



                byte[] bytes = new byte[1024];
                StringBuilder oStringBuilder = new StringBuilder();

                int nCount = await Task.Factory.FromAsync<int>(
                               oSocket.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, null, oSocket),
                               oSocket.EndReceive);
                if (nCount > 0)
                {
                    oStringBuilder.Append(Encoding.UTF8.GetString(bytes, 0, nCount));
                    string strValue = oStringBuilder.ToString().Replace("<EOF>", "");

                    if (strValue == "OK")
                    {


                    }
                    else
                    {
                        return;
                    }
                }


                //SocketState oSocketState = (SocketState)Iar.AsyncState;
                //Socket oSocket = oSocketState.WorkSocket;


                byte[] btFileName = new byte[1024];
                FileStream fs = null;

                try
                {

                    fs = new FileStream(oSocketState.fileInfo.FullName, FileMode.Open, FileAccess.Read, FileShare.Read);

                    string stFileSize = fs.Length.ToString();





                    byte[] btFile = new byte[10240];
                    int sendBytes = 0;
                    int nSize = 0;

                    while ((nSize = fs.Read(btFile, 0, btFile.Length)) > 0)
                    {
                        oSocket.Send(btFile, nSize, 0);

                        sendBytes += nSize;
                    }
                }
                catch (System.Exception ex)
                {
                    //MessageBox.Show(ex.ToString());
                    LogWriter(String.Format("에러발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                }
                finally
                {
                    if (fs != null)
                    {
                        fs.Close();
                    }
                }


                oStringBuilder = new StringBuilder();

                nCount = await Task.Factory.FromAsync<int>(
                               oSocket.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, null, oSocket),
                               oSocket.EndReceive);
                if (nCount > 0)
                {
                    oStringBuilder.Append(Encoding.UTF8.GetString(bytes, 0, nCount));
                    string finished = oStringBuilder.ToString().Replace("<EOF>", "");

                    if (finished == "FINISH")
                    {
                        //LogWriter(String.Format("파일 다운로드FINISH : {0}", oSocketState.fileInfo.FullName));
                    }
                }


                //string finished = await ReciveMessageAsync(oSocket);

                //if (finished.Equals("FINISH"))
                //{

                //}
                //else
                //{

                //}

                LogWriter(String.Format("파일 다운로드 : {0}", oSocketState.fileInfo.FullName));


            }
            catch (SocketException oSocketException)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocketState);
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(ex);

                Byte[] byteData = Encoding.UTF8.GetBytes("▥FAIL▥" + "|" + ex.Message + "<EOF>");
                await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);

                CloseSocket(oSocketState);
            }

        }


        private String ReciveMessage(Socket oSocket)
        {
            byte[] bytes = new byte[1024];
            StringBuilder oStringBuilder = new StringBuilder();
            int bytesRec = 0;

            try
            {
                while (oStringBuilder.ToString().IndexOf("<EOF>") < 0)
                {
                    bytesRec = oSocket.Receive(bytes);
                    oStringBuilder.Append(Encoding.UTF8.GetString(bytes, 0, bytesRec));

                    if (bytesRec.Equals(0))
                    {
                        break;
                    }
                }

                return oStringBuilder.ToString().Replace("<EOF>", "");
            }
            catch (SocketException oSocketException)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocket);
            }

            return "";
        }


        private async Task<string> ReciveMessageAsync(Socket oSocket)
        {
            byte[] bytes = new byte[1024];
            StringBuilder oStringBuilder = new StringBuilder();
            int bytesRec = 0;

            try
            {
                while (oStringBuilder.ToString().IndexOf("<EOF>") < 0)
                {
                    //bytesRec = oSocket.Receive(bytes);

                    int nCount = await Task.Factory.FromAsync<int>(
                               oSocket.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, null, oSocket),
                               oSocket.EndReceive);
                    if (nCount > 0)
                    {
                        oStringBuilder.Append(Encoding.UTF8.GetString(bytes, 0, nCount));
                    }

                    if (nCount.Equals(0))
                    {
                        break;
                    }
                }

                return oStringBuilder.ToString().Replace("<EOF>", "");
            }
            catch (SocketException oSocketException)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocket);
            }

            return "";
        }


        /// <summary>
        /// name         : DirectoryCheck
        /// desc         : 폴더 체크 및 없으면 폴더생성
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void DirectoryCheck(string path)
        {
            DirectoryInfo di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                di.Create();
            }

        }

        /// <summary>
        /// name         : filePathCheck
        /// desc         : 서버 경로 체크(디렉토리 생성 및 파일이름, 경로 리턴)
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void filePathCheck(string serverFilePath, ref string outFileName, ref string outFilePath)
        {
            string[] spliPath = serverFilePath.Split('\\');

            string fileName = "";
            string path = this.rootPath;


            if (spliPath != null && spliPath.Count() > 0)
            {
                for (int i = 0; i < spliPath.Count(); i++)
                {
                    //마지막은 파일명
                    if (i == spliPath.Count() - 1)
                    {
                        fileName = spliPath.ElementAt(i);
                    }
                    else
                    {
                        path = path + "\\" + spliPath.ElementAt(i);
                        this.DirectoryCheck(path);
                    }


                }
            }

            outFileName = fileName;
            outFilePath = path;

        }


        /// <summary>
        /// name         : filePathCheckForBackup
        /// desc         : 파일경로 체크(백업시 체크)
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void filePathCheckForBackup(string serverFilePath, ref string outFileName, ref string outFilePath)
        {

            serverFilePath = serverFilePath.Replace(this.rootPath, "");

            string[] spliPath = serverFilePath.Split('\\');

            string fileName = "";
            string serverPath = this.rootPath;
            string backupPath = this.rootPath_backup;


            if (spliPath != null && spliPath.Count() > 0)
            {
                for (int i = 0; i < spliPath.Count(); i++)
                {
                    //if (spliPath.ElementAt(i) == serverPath)
                    //{
                    //    continue;
                    //}
                    if (string.IsNullOrEmpty(spliPath.ElementAt(i)))
                    {
                        continue;
                    }

                    //마지막은 파일명
                    if (i == spliPath.Count() - 1)
                    {
                        fileName = spliPath.ElementAt(i);
                    }
                    else
                    {
                        backupPath = backupPath + "\\" + spliPath.ElementAt(i);
                        this.DirectoryCheck(backupPath);
                    }
                }
            }

            outFileName = fileName;
            outFilePath = backupPath;

        }



        /// <summary>
        /// name         : FileUploadNew
        /// desc         : 파일 업로드
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void FileUploadNew(SocketState oSocketState)
        {
            //SocketState oSocketState = (SocketState)Iar.AsyncState;
            Socket oSocket = oSocketState.WorkSocket;

            try
            {
                // 쓰레드 접근 제한
                MrReceiveFileDone.Reset();


                // 파일 생성 정보 할당
                String[] arrContents = GetContentsArray(oSocketState.ContentsBuilder);

                //String strFilePath = String.Format(appPath + @"\Receive\{0}", DateTime.Now.ToShortDateString().Replace("-", ""));
                String strFilePath = rootPath;
                String serverFilePath = arrContents[1].Trim();
                String strFullPath = String.Empty;

                string newFileName = "";
                string newFilePath = "";

                String dupCheck = arrContents[3].Trim();

                //파일경로 생성 및 파일명, 경로 부분 확인
                filePathCheck(serverFilePath, ref newFileName, ref newFilePath);


                if (dupCheck == "Y")
                {
                    //파일명 중복체크
                    newFileName = DupFileRenameCheck(newFilePath, newFileName);
                }


                if (!string.IsNullOrEmpty(newFileName) && !string.IsNullOrEmpty(newFilePath))
                {
                    //Directory.CreateDirectory(strFilePath);

                    oSocketState.oFileStream = new FileStream(newFilePath + @"\" + newFileName, FileMode.Create, FileAccess.ReadWrite);
                    oSocketState.iFileSize = Convert.ToDouble(arrContents[2].Trim());

                    String strFileName = Path.GetFileName(oSocketState.oFileStream.Name);

                    //LogWriter(String.Format("파일 정보 수신 : {0}", strFileName));
                    LogWriter(String.Format("파일 사이즈 : {0}", arrContents[2].Trim()));
                    LogWriter(String.Format("파일 생성 : {0}", newFilePath + @"\" + newFileName));


                    //사이즈가 0이면 finish
                    if (arrContents[2].ToString() == "0")
                    {
                        Byte[] byteData = Encoding.UTF8.GetBytes("SIZE_IS_EMPTY<EOF>");

                        int iSendBytes = await Task.Factory.FromAsync<int>(
                                oSocketState.WorkSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocketState.WorkSocket),
                                oSocketState.WorkSocket.EndSend);


                        //파일 쓰기 완료
                        oSocketState.oFileStream.Flush();
                        oSocketState.oFileStream.Close();

                        //SendMessage(Iar, "FINISH<EOF>");
                        //await SendMessage2(oSocket, "FINISH<EOF>");

                        // 쓰레드 접근제한 해제
                        MrReceiveFileDone.Set();

                        //txtBoxInfo.Text += String.Format("파일 수신완료 : {0}", strFileName);

                        //LogTextEvent(richTextBox1, Color.Black, String.Format("파일 수신완료 : {0}", strFileName));
                        LogWriter(String.Format("파일 수신완료 : {0}", strFileName));


                        //txtBoxFileList.Text += strFileName + Environment.NewLine;
                        LogTextEvent(this.txtBoxFileList, Color.Black, strFileName);

                        //백업서버에 전달
                        this.FileBackup("UPLOAD", newFilePath + @"\" + newFileName, "");

                    }
                    else
                    {
                        Byte[] byteData = Encoding.UTF8.GetBytes("OK<EOF>");

                        //oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(ReceiveDataCallBack), oSocketState);
                        int iSendBytes = await Task.Factory.FromAsync<int>(
                                oSocketState.WorkSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocketState.WorkSocket),
                                oSocketState.WorkSocket.EndSend);

                        try
                        {


                            bool isFinished = false;
                            while (isFinished == false)
                            {

                                //int iMessageLength = oSocket.Receive(oSocketState.Buffer, 0, SocketState.BufferSize, 0);


                                int iMessageLength = await Task.Factory.FromAsync<int>(
                                                           oSocketState.WorkSocket.BeginReceive(oSocketState.Buffer, 0, SocketState.BufferSize, SocketFlags.None, null, oSocketState.WorkSocket),
                                                           oSocketState.WorkSocket.EndReceive);

                                //int iMessageLength = await Task.Run<int>(() =>
                                //{
                                //    return oSocketState.WorkSocket.BeginReceive(oSocketState.Buffer, 0, SocketState.BufferSize, SocketFlags.None, null, oSocketState.WorkSocket);

                                //});

                                //int iMessageLength = oSocketState.WorkSocket.Receive(oSocketState.Buffer, 0, SocketState.BufferSize, SocketFlags.None);

                                // 파일 데이터 사이즈를 가지고 옴
                                if (iMessageLength > 0)
                                {
                                    oSocketState.oFileStream.Write(oSocketState.Buffer, 0, iMessageLength);

                                    if (oSocketState.oFileStream.Length == oSocketState.iFileSize)
                                    {
                                        //파일 쓰기 완료
                                        oSocketState.oFileStream.Flush();
                                        oSocketState.oFileStream.Close();

                                        //SendMessage(Iar, "FINISH<EOF>");
                                        await SendMessage2(oSocket, "FINISH<EOF>");

                                        // 쓰레드 접근제한 해제
                                        MrReceiveFileDone.Set();

                                        //txtBoxInfo.Text += String.Format("파일 수신완료 : {0}", strFileName);

                                        //LogTextEvent(richTextBox1, Color.Black, String.Format("파일 수신완료 : {0}", strFileName));
                                        LogWriter(String.Format("파일 수신완료 : {0}", strFileName));


                                        //txtBoxFileList.Text += strFileName + Environment.NewLine;
                                        LogTextEvent(this.txtBoxFileList, Color.Black, strFileName);


                                        //백업서버에 전달
                                        this.FileBackup("UPLOAD", newFilePath + @"\" + newFileName, "");

                                        break;
                                    }
                                }
                                else
                                {
                                    isFinished = true;
                                }

                            }


                            //int iSendBytes = oSocket.EndSend(Iar);

                            //if (iSendBytes > 0)
                            //{
                            //    // 파일 정보 수신 모드로 할당
                            //    // oSocket.BeginReceive(oSocketState.Buffer, 0, SocketState.BufferSize, 0, new AsyncCallback(ReceiveDataStreamWrite), oSocketState);

                            //    ReceiveDataStreamWriteAsync(oSocketState);
                            //}
                            //else
                            //{
                            //    //CloseSocket(Iar);
                            //    oSocketState.WorkSocket.Close();
                            //}
                        }
                        catch (SocketException oSocketException)
                        {
                            //CloseSocket(Iar);
                            LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                            LogWriter(oSocketException);

                            //파일 닫기
                            oSocketState.oFileStream.Flush();
                            oSocketState.oFileStream.Close();
                            // 쓰레드 접근제한 해제
                            MrReceiveFileDone.Set();

                            //oSocketState.WorkSocket.Close();
                            CloseSocket(oSocketState);
                        }

                    }

                }
                else
                {
                    Byte[] byteData = Encoding.UTF8.GetBytes("FALSE<EOF>");
                    oSocket.Send(byteData);
                }




                // 파일 송신 대기 전송

            }
            catch (SocketException oSocketException)
            {
                //CloseSocket(Iar);
                //oSocketState.WorkSocket.Close();

                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocketState);
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(ex);

                Byte[] byteData = Encoding.UTF8.GetBytes("▥FAIL▥" + "|" + ex.Message + "<EOF>");
                await Task.Factory.FromAsync(
                            oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                            oSocket.EndSend);

                CloseSocket(oSocketState);
            }
        }


        /// <summary>
        /// name         : DupFolderNameCheck
        /// desc         : 폴더명 중복체크
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private string DupFolderNameCheck(string newFolderName, string path)
        {

            string tempNewFolderName = newFolderName;
            try
            {
                bool isDup = false;
                DirectoryInfo di = new DirectoryInfo(path + "\\" + tempNewFolderName);

                //디렉토리명 중복
                if (di.Exists == true)
                {
                    isDup = true;

                    bool isTempNumExists = false;
                    int existTempNum = 0;
                    int existTempNumIndex = 0;

                    int startIndexNum = tempNewFolderName.LastIndexOf('(');
                    int endIndexNum = tempNewFolderName.LastIndexOf(')');
                    existTempNumIndex = startIndexNum;
                    if (startIndexNum >= 0 && endIndexNum >= 0)
                    {
                        //임시번호가 뒤에 붙어있음.
                        string tempNum = tempNewFolderName.Substring(startIndexNum, endIndexNum - startIndexNum + 1);
                        if (tempNum.Length >= 3)
                        {
                            if (tempNum[0].ToString() == "(" && tempNum[tempNum.Length - 1].ToString() == ")")
                            {
                                string strNumber = tempNum.Substring(1, tempNum.Length - 2);
                                int number;
                                if (int.TryParse(strNumber, out number) == true)
                                {
                                    int num = number;
                                    existTempNum = num;
                                    isTempNumExists = true;
                                }
                            }
                        }
                    }

                    if (isTempNumExists == true && existTempNum > 0 && existTempNumIndex > 0)
                    {
                        tempNewFolderName = tempNewFolderName.Substring(0, existTempNumIndex) + "(" + (existTempNum + 1).ToString() + ")";
                    }
                    else
                    {
                        tempNewFolderName = tempNewFolderName + "(1)";
                    }
                }


                if (isDup == false)
                {
                    return tempNewFolderName;
                }
                else
                {
                    return DupFolderNameCheck(tempNewFolderName, path);
                }
            }
            catch
            {
                return tempNewFolderName;
            }
        }


        /// <summary>
        /// name         : DupFileRenameCheck
        /// desc         : 파일명 중복체크
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private string DupFileRenameCheck(string newFilePath, string newFileName, bool isNeedToDupCheck = true)
        {
            string tempNewFileName = newFileName;
            try
            {
                bool isDup = false;
                FileInfo di = new FileInfo(newFilePath + "\\" + tempNewFileName);

                if (isNeedToDupCheck == true)
                {
                    if (di.Exists)
                    {
                        isDup = true;
                        //이미 동일한 파일이 존재하는 경우
                        //newFileName = newFileName + DateTime.Now.ToString("HHmmss");

                        bool isTempNumExists = false;
                        int existTempNum = 0;
                        int existTempNumIndex = 0;
                        string[] splFileName = newFileName.Split('.');
                        if (splFileName.Count() == 2)
                        {
                            //newFileName = splFileName.ElementAt(0) + DateTime.Now.ToString("HHmmss") + "." + splFileName.ElementAt(1);

                            int startIndexNum = splFileName.ElementAt(0).LastIndexOf('(');
                            int endIndexNum = splFileName.ElementAt(0).LastIndexOf(')');
                            existTempNumIndex = startIndexNum;
                            if (startIndexNum >= 0 && endIndexNum >= 0)
                            {
                                //임시번호가 뒤에 붙어있음.
                                string tempNum = splFileName.ElementAt(0).Substring(startIndexNum, endIndexNum - startIndexNum + 1);
                                if (tempNum.Length >= 3)
                                {
                                    if (tempNum[0].ToString() == "(" && tempNum[tempNum.Length - 1].ToString() == ")")
                                    {
                                        string strNumber = tempNum.Substring(1, tempNum.Length - 2);
                                        int number;
                                        if (int.TryParse(strNumber, out number) == true)
                                        {
                                            int num = number;
                                            existTempNum = num;
                                            isTempNumExists = true;
                                        }
                                    }
                                }
                            }
                        }

                        if (isTempNumExists == true && existTempNum > 0 && existTempNumIndex > 0)
                        {
                            tempNewFileName = splFileName.ElementAt(0).Substring(0, existTempNumIndex) + "(" + (existTempNum + 1).ToString() + ")" + "." + splFileName.ElementAt(1);
                        }
                        else
                        {
                            tempNewFileName = splFileName.ElementAt(0).ToString() + "(1)" + "." + splFileName.ElementAt(1);
                        }
                    }
                }


                if (isDup == false)
                {
                    return tempNewFileName;
                }
                else
                {
                    return DupFileRenameCheck(newFilePath, tempNewFileName, isNeedToDupCheck);
                }
            }
            catch
            {
                return tempNewFileName;
            }
        }

        private async void ReceiveDataStreamWriteAsync(SocketState oSocketState)
        {
            Socket oSocket = oSocketState.WorkSocket;
            String strFileName = Path.GetFileName(oSocketState.oFileStream.Name);

            try
            {

                int iMessageLength = await Task.Factory.FromAsync<int>(
                       oSocketState.WorkSocket.BeginReceive(oSocketState.Buffer, 0, SocketState.BufferSize, SocketFlags.None, null, oSocketState.WorkSocket),
                       oSocketState.WorkSocket.EndReceive);


                // 파일 데이터 사이즈를 가지고 옴
                if (iMessageLength > 0)
                {
                    oSocketState.oFileStream.Write(oSocketState.Buffer, 0, iMessageLength);

                    //진행 파일 크기 전송
                    //long fileStreamWriteSize = oSocketState.oFileStream.Length;
                    //SendMessage(Iar, "ReceiveFileSize TEST<EOF>");

                    if (oSocketState.oFileStream.Length == oSocketState.iFileSize)
                    {
                        // 파일 쓰기 완료
                        oSocketState.oFileStream.Flush();
                        oSocketState.oFileStream.Close();

                        //SendMessage(Iar, "FINISH<EOF>");
                        await SendMessage2(oSocket, "FINISH<EOF>");

                        // 쓰레드 접근제한 해제
                        MrReceiveFileDone.Set();

                        //txtBoxInfo.Text += String.Format("파일 수신완료 : {0}", strFileName);

                        //LogTextEvent(richTextBox1, Color.Black, String.Format("파일 수신완료 : {0}", strFileName));
                        LogWriter(String.Format("파일 수신완료 : {0}", strFileName));


                        //txtBoxFileList.Text += strFileName + Environment.NewLine;
                        LogTextEvent(this.txtBoxFileList, Color.Black, strFileName);
                    }
                    else
                    {
                        // 데이터 추가 수신대기
                        //oSocket.BeginReceive(oSocketState.Buffer, 0, SocketState.BufferSize, 0, new AsyncCallback(ReceiveDataStreamWrite), oSocketState);
                        ReceiveDataStreamWriteAsync(oSocketState);
                    }
                }
            }
            catch (SocketException oSocketException)
            {
                //CloseSocket(Iar);
                //oSocketState.WorkSocket.Close();

                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocketState);
            }

        }




        #region 클라이언트에 메시지 전송



        private async Task<int> SendMessage2(Socket oSocket, String strMsg)
        {
            int iSendBytes = 0;
            try
            {
                Byte[] byteData = Encoding.UTF8.GetBytes(strMsg);

                //oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, new AsyncCallback(ReceiveDataCallBack), oSocketState);


                iSendBytes = await Task.Factory.FromAsync<int>(
                        oSocket.BeginSend(byteData, 0, byteData.Length, SocketFlags.None, null, oSocket),
                        oSocket.EndSend);


            }
            catch (SocketException oSocketException)
            {
                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()));
                LogWriter(oSocketException);

                CloseSocket(oSocket);
                //oSocket.Close();
            }

            return iSendBytes;

        }


        #endregion

        #region 클라이언트 메시지 전송 콜백
        //private void SendCallBack(IAsyncResult Iar)
        //{
        //    SocketState state = (SocketState)Iar.AsyncState;
        //    Socket handler = state.WorkSocket;

        //    try
        //    {
        //        int iSendByte = handler.EndSend(Iar);

        //        // 데이터가 전송되어 메시지 수신 대기 상태로 전환
        //        if (iSendByte > 0)
        //        {
        //            handler.BeginReceive(state.Buffer, 0, SocketState.BufferSize, 0, new AsyncCallback(ReceiveMessage), state);
        //        }
        //        // 데이터 전송 실패 클라이언트로 부터 연결이 종료되는 경우
        //        else
        //        {
        //            LogWriter(String.Format("클라이언트로 메시지 전송 바이트가 0이되어 연결종료 : {0}", handler.RemoteEndPoint.ToString()));
        //            CloseSocket(Iar);
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        LogWriter(String.Format("클라이언트 메시지 전송 오류 : {0}, 오류 내용 : {1}", handler.RemoteEndPoint.ToString(), ex.Message.ToString()));
        //        CloseSocket(Iar);
        //    }
        //}
        #endregion

        #region 소켓에서 명령어를 배열 형태로 반환
        private String[] GetContentsArray(StringBuilder oStringBuilder)
        {
            try
            {
                String[] arrContents = oStringBuilder.ToString().Replace("<EOF>", "").Split(Convert.ToChar("|"));
                return arrContents;
            }
            catch
            {
            }

            return null;
        }
        #endregion

        #region 연결 종료 요청
        //private void Disconnection(IAsyncResult Iar)
        //{
        //    SocketState state = (SocketState)Iar.AsyncState;
        //    Socket handler = state.WorkSocket;
        //    state.ContentsBuilder.Clear();

        //    LogWriter(String.Format("클라이언트로 부터 접속 종료 요청 수신 : {0}", handler.RemoteEndPoint.ToString()));

        //    handler.BeginReceive(state.Buffer, 0, SocketState.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveMessage), state);
        //}

        //private void Disconnection2(SocketState state)
        //{
        //    //SocketState state = (SocketState)Iar.AsyncState;
        //    Socket handler = state.WorkSocket;
        //    state.ContentsBuilder.Clear();

        //    LogWriter(String.Format("클라이언트로 부터 접속 종료 요청 수신 : {0}", handler.RemoteEndPoint.ToString()));

        //    handler.BeginReceive(state.Buffer, 0, SocketState.BufferSize, SocketFlags.None, new AsyncCallback(ReceiveMessage), state);
        //}
        #endregion

        private void SetControlStates(bool isConnected)
        {
            btnStart.Enabled = !isConnected;
        }

        private string GetIp()
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");
            foreach (System.Net.IPAddress ip in System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList)
            {
                if (regex.IsMatch(ip.ToString()))
                {
                    return ip.ToString();
                }
            }
            return null;
        }

        private void GetReceiveDirectoryFiles()
        {
            DirectoryInfo dir = new DirectoryInfo(rootPath);
            FileInfo[] Files = dir.GetFiles();

            foreach (FileInfo file in Files)
            {
                //txtBoxFileList.Text += file.Name + Environment.NewLine;
                LogTextEvent(this.txtBoxFileList, Color.Black, file.Name);
            }
        }
        private void txtBoxFileList_TextChanged(object sender, EventArgs e)
        {

            txtBoxFileList.SelectionStart = txtBoxFileList.Text.Length;
            txtBoxFileList.ScrollToCaret();
        }

        #region 로그 기록
        private void LogWriter(String strMsg)
        {
            try
            {
                TxtBoxInfoWriter(strMsg);
            }
            catch
            {
            }
        }

        private void LogWriter(Exception ex)
        {
            try
            {
                TxtBoxInfoWriter(ex.Message, strColor: "red");


                StreamWriter oStreamWriter = new StreamWriter(String.Format(@"{0}\Log\{1}", appPath, DateTime.Now.ToShortDateString() + "Error" + ".TXT"), true);
                oStreamWriter.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ex.Message));
                oStreamWriter.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ex.StackTrace));
                oStreamWriter.Close();
            }
            catch
            {
            }
        }

        private void LogWriterForBackup(String strMsg)
        {
            try
            {
                //텍스트 박스에 표시
                LogTextEvent(this.txtBackupList, Color.Black, strMsg);

                //로그 파일에 표시
                StreamWriter oStreamWriter = new StreamWriter(String.Format(@"{0}\Log\{1}", appPath, DateTime.Now.ToShortDateString() + "BackUp" + ".TXT"), true);
                oStreamWriter.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), strMsg));
                oStreamWriter.Close();
            }
            catch
            {
            }
        }

        private void LogWriterForBackup(Exception ex)
        {
            try
            {
                //텍스트 박스에 표시
                LogTextEvent(this.txtBackupList, Color.Red, ex.Message);

                //로그 파일에 표시
                StreamWriter oStreamWriter = new StreamWriter(String.Format(@"{0}\Log\{1}", appPath, DateTime.Now.ToShortDateString() + "BackUpError" + ".TXT"), true);
                oStreamWriter.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ex.Message));
                oStreamWriter.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ex.StackTrace));
                oStreamWriter.Close();

            }
            catch
            {
            }
        }




        private void ErrorLogWrite(Exception ex)
        {
            StreamWriter oStreamWriter = new StreamWriter(String.Format(@"{0}\Log\{1}", appPath, DateTime.Now.ToShortDateString() + "Error" + ".TXT"), true);
            oStreamWriter.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ex.Message));
            oStreamWriter.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), ex.StackTrace));
            oStreamWriter.Close();
        }



        private void TxtBoxInfoWriter(String strMsg, string strColor = "")
        {
            Color color = Color.Black;
            if (strColor == "red")
            {
                color = Color.Red;
            }

            LogTextEvent(richTextBox1, color, strMsg);


            StreamWriter oStreamWriter = new StreamWriter(String.Format(@"{0}\Log\{1}", appPath, DateTime.Now.ToShortDateString() + ".TXT"), true);
            oStreamWriter.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), strMsg));
            oStreamWriter.Close();
        }

        int textCount = 0;

        public void LogTextEvent(RichTextBox TextEventLog, Color TextColor, string EventText)
        {
            if (TextEventLog.InvokeRequired)
            {
                TextEventLog.BeginInvoke(new Action(delegate
                {
                    LogTextEvent(TextEventLog, TextColor, EventText);
                }));
                return;
            }

            string nDateTime = DateTime.Now.ToString("hh:mm:ss tt") + " - ";

            // color text.
            TextEventLog.SelectionStart = TextEventLog.Text.Length;
            TextEventLog.SelectionColor = TextColor;

            // newline if first line, append if else.
            if (TextEventLog.Lines.Length == 0)
            {
                TextEventLog.AppendText(nDateTime + EventText);
                TextEventLog.ScrollToCaret();
                TextEventLog.AppendText(System.Environment.NewLine);
            }
            else
            {
                TextEventLog.AppendText(nDateTime + EventText + System.Environment.NewLine);
                TextEventLog.ScrollToCaret();
            }

            textCount++;

            if (textCount > 5000)
            {
                textCount = 0;
                TextEventLog.Clear();
            }
        }


        //public void LogTextEventForBackup(RichTextBox TextEventLog, Color TextColor, string EventText)
        //{
        //    if (TextEventLog.InvokeRequired)
        //    {
        //        TextEventLog.BeginInvoke(new Action(delegate
        //        {
        //            LogTextEventForBackup(TextEventLog, TextColor, EventText);
        //        }));
        //        return;
        //    }

        //    string nDateTime = DateTime.Now.ToString("hh:mm:ss tt") + " - ";

        //    // color text.
        //    TextEventLog.SelectionStart = TextEventLog.Text.Length;
        //    TextEventLog.SelectionColor = TextColor;

        //    // newline if first line, append if else.
        //    if (TextEventLog.Lines.Length == 0)
        //    {
        //        TextEventLog.AppendText(nDateTime + EventText);
        //        TextEventLog.ScrollToCaret();
        //        TextEventLog.AppendText(System.Environment.NewLine);
        //    }
        //    else
        //    {
        //        TextEventLog.AppendText(nDateTime + EventText + System.Environment.NewLine);
        //        TextEventLog.ScrollToCaret();
        //    }
        //}

        private void TxtBoxInfo_TextChanged(object sender, EventArgs e)
        {

            //txtBoxInfo.SelectionStart = txtBoxInfo.Text.Length;
            //txtBoxInfo.ScrollToCaret();

        }

        #endregion


        //DataTable dt;
        ///// <summary>
        ///// name         : button1_Click
        ///// desc         : 테스트 버튼
        ///// author       : 심우종
        ///// create date  : 
        ///// update date  : 최종 수정일자 , 수정자, 수정개요
        ///// </summary> 
        //private void button1_Click(object sender, EventArgs e)
        //{
        //    string test = dt.Rows[0]["test"].ToString();       
        //}




        ManagementScope mScope;
        /// <summary>
        /// name         : RemoteProcessReStart
        /// desc         : standby 소켓서버가 죽은경우 재실행한다.
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void RemoteProcessReStart(string ip, string userName, string password)
        {
            try
            {
                ConnectionOptions cConnectOption = new ConnectionOptions();
                //string ip = "10.10.221.71";

                cConnectOption.Username = userName; // "mj2kuh";
                cConnectOption.Password = password; // "sJ0802$!";
                mScope = new ManagementScope("\\\\" + ip + "\\root\\CIMV2", cConnectOption);
                mScope.Connect();

                //object[] theProcessToRun = { "notepad.exe" };

                ManagementClass theClass = new ManagementClass(mScope, new ManagementPath("Win32_Process"), new ObjectGetOptions());

                //1) 기존에 띄워져 있는 프로세스가 있으면 KILL
                ObjectQuery theQuery = new ObjectQuery("SELECT * FROM Win32_Process WHERE Name='FileTransferServer.exe'");
                ManagementObjectSearcher theSearcher = new ManagementObjectSearcher(mScope, theQuery);
                ManagementObjectCollection theCollection = theSearcher.Get();

                foreach (ManagementObject theCurObject in theCollection)
                {
                    //기존에 프로그램이 띄워져 있으면 kill
                    if (theCurObject["Caption"].ToString() == "FileTransferServer.exe")
                    {
                        theCurObject.InvokeMethod("Terminate", null);
                    }
                }

                //2) 다시 실행
                object[] theProcessToRun = { @"C:\SEDAS\FileTransferServer\FileTransferServer.exe ReStart" };
                theClass.InvokeMethod("Create", theProcessToRun);
            }
            catch
            {

            }
        }

    }

    public static class StaticUtilClass
    {
        /// <summary>
        /// String => Int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }
        /// <summary>
        /// String => Int (널 허용)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? ToIntOrNull(this string value)
        {
            int returnValue;
            if (int.TryParse(value, out returnValue) == true)
            {
                return returnValue;
            }
            else
            {
                return null;
            }
        }
    }

}