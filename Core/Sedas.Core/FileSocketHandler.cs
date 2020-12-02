using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sedas.Core
{
    public class FileSocketHandler
    {
        public static ManualResetEvent MrReceiveFileDone = new ManualResetEvent(false);          // 파일 수신 쓰레드 이벤트 핸들링
        public event Action<double, string, string, double, double> onPercentInfoEvent; //전송중인 데이터의 퍼센트를 알려주기 위한 이벤트
        public event Action<string> onIpChanged; //IP변경이 필요한 경우

        public class SocketState
        {
            public const int BufferSize = 10240;

            public Socket WorkSocket = null;
            public byte[] Buffer = new byte[BufferSize];
            public StringBuilder ContentsBuilder = new StringBuilder();
            public FileStream oFileStream = null;
            public double iFileSize = 0;
            public Boolean isAuthUser = false;
        }



        private Socket oSocket = null;
        private bool bSocketConnected = false;
        public bool ShowErrorMessage { get; set; } = true;

        string savedFilePath = ""; //로컬에 저장된 파일 경로명

        string ip = "";
        string port = "";

        bool isSync = false;
        bool isDupCheck = true;
        
        /// <summary>
        /// 동기, 비동기 여부 설정
        /// </summary>
        public bool IsSync
        {
            get { return isSync; }
            set { isSync = value; }
        }

        /// <summary>
        /// 이름 중복 체크
        /// </summary>
        public bool IsDupCheck
        {
            get { return isDupCheck; }
            set { isDupCheck = value; }
        }

        public FileSocketHandler(string ip, string port)
        {
            this.ip = ip;
            this.port = port;
        }


        /// <summary>
        /// name         : Start
        /// desc         : 서버 연결을 위한 메소드
        /// author       : 심우종
        /// create date  : 2020-05-21 13:31
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void Start()
        {
            try
            {
                int result = 0;
                if (this.port.ToIntOrNull() != null)
                {
                    result = port.ToInt();
                }
                //int result = 0;
                //int.TryParse(txtPort.Text.Trim(), out result);

                if (string.IsNullOrEmpty(ip.Trim()))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("연결할 IP주소를 입력하세요.", "IP주소 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //MessageBox.Show("연결할 IP주소를 입력하세요.", "IP주소 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (!IsChkIpAddress(ip.Trim()))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("입력한 IP주소를 확인하세요.", "IP주소 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (string.IsNullOrEmpty(port))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("연결할 Port를 입력하세요.", "Port 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                else if (result == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("입력한 Port를 확인하세요.", "Port 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                //1 ~ 65535
                else if (result < 1 || result > 65535)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("입력한 Port를 확인하세요.[1~65535]", "Port 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    if (!bSocketConnected)
                    {
                        oSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                        IPAddress oIPAddress = IPAddress.Parse(this.ip.Trim());
                        IPEndPoint oIPEndPoint = new IPEndPoint(oIPAddress, Convert.ToInt32(this.port.Trim()));

                        try
                        {
                            oSocket.Connect(oIPEndPoint);
                        }
                        catch(SocketException socketEx)
                        {
                            //141,142번 서버에 대해서 크로스 체크
                            if (ip == "10.10.50.141")
                            {
                                oIPAddress = IPAddress.Parse("10.10.50.142");
                                oIPEndPoint = new IPEndPoint(oIPAddress, Convert.ToInt32(this.port.Trim()));
                                oSocket.Connect(oIPEndPoint);
                                this.ip = "10.10.50.142";
                                if (onIpChanged != null)
                                {
                                    this.onIpChanged(this.ip);
                                }
                            }
                            else if (ip == "10.10.50.142")
                            {
                                oIPAddress = IPAddress.Parse("10.10.50.141");
                                oIPEndPoint = new IPEndPoint(oIPAddress, Convert.ToInt32(this.port.Trim()));
                                oSocket.Connect(oIPEndPoint);
                                this.ip = "10.10.50.141";
                                if (onIpChanged != null)
                                {
                                    this.onIpChanged(this.ip);
                                }
                            }
                        }
                        

                        // 소켓 연결 확인
                        if (oSocket.Connected)
                        {
                            bSocketConnected = true;

                            //SetControlStates(true);

                            LogWriter("서버와 연결 되었습니다.", false);

                        }
                        else
                        {
                            LogWriter("서버에 연결할 수 없습니다.", true);
                        }
                    }
                }
            }
            catch (SocketException oSocketException)

            {
                LogWriter(oSocketException);
            }
        }


        /// <summary>
        /// name         : DirectoryExists
        /// desc         : 디렉토리 존재여부 확인
        /// author       : 심우종
        /// create date  : 2020-05-25 11:27
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool DirectoryExists(string serverPath)
        {
            try
            {
                oSocket.Send(Encoding.UTF8.GetBytes("DirectoryExists|" + serverPath + "<EOF>"));

                string message = ReciveMessage(oSocket);
                if (message == "Y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("디렉토리 존재여부 확인 오류 : {0}", ex.Message), true);
                return false;
            }

        }


        /// <summary>
        /// name         : MakeDirectory
        /// desc         : 디렉토리 생성
        /// author       : 심우종
        /// create date  : 2020-05-25 13:13
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool MakeDirectory(string serverPath)
        {
            try
            {
                oSocket.Send(Encoding.UTF8.GetBytes("MakeDirectory|" + serverPath + "<EOF>"));

                string message = ReciveMessage(oSocket);
                if (message == "OK")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("디렉토리 생성 오류 : {0}", ex.Message), true);
                return false;
            }
        }




        /// <summary>
        /// name         : ExplorerInfo
        /// desc         : 파일 탐색기용 정보 조회
        /// author       : 심우종
        /// create date  : 2020-05-26 09:01
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public string ExplorerInfo(string serverPath, string paramIcon, string paramSize)
        {
            try
            {
                //string paramIcon = "1";
                //string paramSize = "16";

                oSocket.Send(Encoding.UTF8.GetBytes("ExplorerInfo|" + serverPath + "|" + paramIcon + "|" + paramSize + "<EOF>"));

                string message = ReciveMessage(oSocket);
                return message;
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일 탐색기용 정보 조회 오류 : {0}", ex.Message), true);
                return "";
            }
        }




        /// <summary>
        /// name         : SedasSetupFileInfo
        /// desc         : 설치파일정보 조회
        /// author       : 심우종
        /// create date  : 2020-08-25 16:46
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public string SedasSetupFileInfo(string projectName, string lastDtm)
        {
            try
            {
                oSocket.Send(Encoding.UTF8.GetBytes("SedasSetupFileInfo|" + projectName + "|" + lastDtm + "<EOF>"));

                string message = ReciveMessage(oSocket);
                return message;
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("설치파일정보 오류 : {0}", ex.Message), true);
                return "";
            }
        }

        /// <summary>
        /// name         : GetAllFiles
        /// desc         : 폴더 아래의 전체 파일 정보 리턴
        /// author       : 심우종
        /// create date  : 2020-09-29 14:33
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public string GetAllFiles(string folderPath)
        {
            try
            {
                oSocket.Send(Encoding.UTF8.GetBytes("GetAllFiles|" + folderPath + "<EOF>"));

                string message = ReciveMessage(oSocket);
                return message;
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("폴더 아래의 전체 파일 정보 리턴 조회 오류 : {0}", ex.Message), true);
                return "";
            }
        }







        /// <summary>
        /// name         : DeleteFile
        /// desc         : 파일삭제
        /// author       : 심우종
        /// create date  : 2020-05-25 13:29
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool DeleteFile(string serverPathAndName)
        {
            try
            {
                oSocket.Send(Encoding.UTF8.GetBytes("DeleteFile|" + serverPathAndName + "<EOF>"));

                string message = ReciveMessage(oSocket);
                if (message == "OK")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일삭제 오류 : {0}", ex.Message), true);
                return false;
            }
        }


        /// <summary>
        /// name         : FileDownLoad
        /// desc         : 파일을 다운로드 한다.
        /// author       : 심우종
        /// create date  : 2020-05-21 16:35
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool FileDownLoad(string serverPath, string localPath, ref string savedFilePathAndName)
        {
            //파일정보 설정
            this.paramInfo = new ParamInfo();
            this.paramInfo.serverPath = serverPath;
            this.paramInfo.localPath = localPath;

            if (string.IsNullOrEmpty(serverPath))
            {
                if (this.ShowErrorMessage == true)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("파일 경로가 없습니다.");
                }
                
                return false;
            }

            if (!bSocketConnected)
            {
                if (this.ShowErrorMessage == true)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("서버와 연결되지 않았습니다.", "서버 접속 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                return false;
            }
            else
            {
                try
                {
                    if (IsSync == false)
                    {
                        //비동기
                        BackgroundWorker bgwReeceiveFile = new BackgroundWorker();
                        bgwReeceiveFile.DoWork += new DoWorkEventHandler(bgwReceiveFile_DoWork);
                        //bgwReeceiveFile.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwSendFile_RunWorkerCompleted);
                        bgwReeceiveFile.RunWorkerAsync();

                    }
                    else
                    {
                        //동기
                        //bool result = SendFileDoWork();
                        //return result;

                        FileDownLoadDoWork();
                    }

                }
                catch (Exception ex)
                {
                    LogWriter(String.Format("파일 다운로드 오류 : {0}", ex.Message), true);
                    return false;
                }
            }

            savedFilePathAndName = this.savedFilePath;

            return true;
        }


        /// <summary>
        /// name         : NameChange
        /// desc         : 파일/폴더명 변경
        /// author       : 심우종
        /// create date  : 2020-05-29 14:58
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool NameChange(string paramPath, string newName, string type)
        {
            try
            {
                oSocket.Send(Encoding.UTF8.GetBytes("NameChange|" + paramPath + "|" + newName + "|" + type + "<EOF>"));

                string message = ReciveMessage(oSocket);
                if (message == "DUP")
                {
                    if (type == "F")
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("이미 동일한 파일이 존재합니다. 다른이름으로 변경해 주세요");
                        return false;
                    }
                    else if (type == "D")
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("이미 동일한 폴더가 존재합니다. 다른이름으로 변경해 주세요");
                        return false;
                    }

                }
                else if (message == "OK")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일/폴더명 변경 오류 : {0}", ex.Message), true);
                return false;
            }

            return false;
        }







        /// <summary>
        /// name         : FileCheckInFolder
        /// desc         : 폴더안에 파일 존재여부 확인
        /// author       : 심우종
        /// create date  : 2020-05-29 14:58
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool FileCheckInFolder(string folderName)
        {
            try
            {
                oSocket.Send(Encoding.UTF8.GetBytes("FileCheckInFolder|" + folderName + "<EOF>"));

                string message = ReciveMessage(oSocket);
                if (message == "Y")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("폴더안에 파일 존재여부 확인 오류 : {0}", ex.Message), true);
                return false;
            }

            return false;
        }


        /// <summary>
        /// name         : DeleteFolder
        /// desc         : 폴더 삭제
        /// author       : 심우종
        /// create date  : 2020-05-29 14:58
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool DeleteFolder(string folderName)
        {
            try
            {
                oSocket.Send(Encoding.UTF8.GetBytes("DeleteFolder|" + folderName + "<EOF>"));

                string message = ReciveMessage(oSocket);
                if (message == "OK")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("폴더 삭제 오류 : {0}", ex.Message), true);
                return false;
            }

            return false;
        }



        /// <summary>
        /// name         : CreateFolder
        /// desc         : 폴더 생성
        /// author       : 심우종
        /// create date  : 2020-06-01 09:24
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool CreateFolder(string serverPath)
        {
            try
            {
                oSocket.Send(Encoding.UTF8.GetBytes("CreateFolder|" + serverPath + "<EOF>"));

                string message = ReciveMessage(oSocket);
                if (message == "OK")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("폴더 생성 오류 : {0}", ex.Message), true);
                return false;
            }

            return false;
        }


        /// <summary>
        /// name         : ImageThumbnail
        /// desc         : 이미지 섬네일 조회
        /// author       : 심우종
        /// create date  : 2020-06-01 09:25
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public string ImageThumbnail(string serverPathAndName)
        {
            try
            {
                oSocket.Send(Encoding.UTF8.GetBytes("ImageThumbnail|" + serverPathAndName + "<EOF>"));

                string message = ReciveMessage(oSocket);

                if (string.IsNullOrEmpty(message)) return "";

                String[] arrContents = GetContentsArray(message);

                if (arrContents != null && arrContents.Length >= 2)
                {
                    if (arrContents[0].ToString() == "OK")
                    {
                        return arrContents[1].ToString();
                    }
                    else
                    {
                        return "";
                    }
                }
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("이미지 섬네일 조회 오류 : {0}", ex.Message), true);
                return "";
            }

            return "";
        }



        private bool FileDownLoadDoWork()
        {
            if (paramInfo == null)
            {
                if (this.ShowErrorMessage == true)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("파일 정보를 확인할 수 없습니다.");
                }
                    
                return false;
            }


            try
            {

                //MrReceiveFileDone.Reset();

                oSocket.Send(Encoding.UTF8.GetBytes("DownloadFile|" + paramInfo.serverPath + "|" + "test2" + "<EOF>"));

                string message = ReciveMessage(oSocket);
                String[] arrContents = GetContentsArray(message);
                String serverFileName = arrContents[1].Trim();

                if (arrContents[2].ToString().ToDoubleOrNull() == null)
                { 
                
                }

                double fileSize = Convert.ToDouble(arrContents[2].Trim());





                //파일경로 생성 및 파일명, 경로 부분 확인
                filePathCheck(paramInfo.localPath);
                string newFileName = serverFileName;
                string newFilePath = paramInfo.localPath;


                CoreLibrary core = new CoreLibrary();
                //중복된 파일명 체크
                newFileName = core.DupFileRenameCheck(newFilePath, newFileName, isNeedToDupCheck: IsDupCheck);



                //newFileName = (StaticUtilClass.counter++).ToString() + ".jpg";

                //FileInfo di = new FileInfo(newFilePath + "\\" + newFileName);
                //if (di.Exists)
                //{
                //    //이미 동일한 파일이 존재하는 경우
                //    //newFileName = newFileName + DateTime.Now.ToString("HHmmss");

                //    string[] splFileName = newFileName.Split('.');
                //    if ( splFileName.Count() ==2)
                //    {
                //        newFileName = splFileName.ElementAt(0) + DateTime.Now.ToString("HHmmss") + "." +  splFileName.ElementAt(1);
                //    }
                //}

                //if (ReciveMessage(oSocket).Equals("OK"))
                //SocketState oSocketState = (SocketState)Iar.AsyncState;
                //Socket oSocket = oSocketState.WorkSocket;

                //int BufferSize = 1024;
                //byte[] Buffer = new byte[BufferSize];

                //string strFilePath = "D:";
                //string strFileName = "testtest.jpg";

                SocketState oSocketState = new SocketState();
                oSocketState.oFileStream = new FileStream(newFilePath + @"\" + newFileName, FileMode.Create, FileAccess.ReadWrite);
                oSocketState.WorkSocket = oSocket;
                oSocketState.iFileSize = fileSize;



                if (isSync == true)
                {
                    Byte[] byteData = Encoding.UTF8.GetBytes("OK<EOF>");
                    oSocket.Send(byteData);


                    int lastPercent = 0;
                    int gap = 2;
                    string fileName = oSocketState.oFileStream.Name;
                    bool isLarge = false;

                    if (oSocketState.iFileSize > 10000000)
                    {
                        isLarge = true;
                    }



                    bool isFinished = false;
                    while (isFinished == false)
                    {

                        int iMessageLength = oSocket.Receive(oSocketState.Buffer, 0, SocketState.BufferSize, 0);

                        // 파일 데이터 사이즈를 가지고 옴
                        if (iMessageLength > 0)
                        {
                            oSocketState.oFileStream.Write(oSocketState.Buffer, 0, iMessageLength);


                            if (isLarge == true)
                            {
                                double percent = (double)(oSocketState.oFileStream.Length  * 100) / Convert.ToDouble(oSocketState.iFileSize);


                                if (percent > lastPercent)
                                {
                                    lastPercent = lastPercent + gap;
                                    if (onPercentInfoEvent != null)
                                    {
                                        onPercentInfoEvent(percent, fileName, "D", oSocketState.iFileSize, oSocketState.oFileStream.Length);
                                    }
                                }
                            }
                            



                            if (oSocketState.oFileStream.Length == oSocketState.iFileSize)
                            {
                                //파일 쓰기 완료
                                oSocketState.oFileStream.Flush();
                                oSocketState.oFileStream.Close();


                                if (isLarge == true)
                                {

                                    if (onPercentInfoEvent != null)
                                    {
                                        onPercentInfoEvent(100, fileName, "D", oSocketState.iFileSize, oSocketState.iFileSize);
                                    }
                                }


                                oSocket.Send(Encoding.UTF8.GetBytes("FINISH<EOF>"));
                                break;
                            }
                        }
                        else
                        {
                            isFinished = true;
                        }

                    }




                    savedFilePath = newFilePath + "\\" + newFileName;
                }
                else
                {
                    Byte[] byteData = Encoding.UTF8.GetBytes("OK<EOF>");
                    oSocket.Send(byteData);

                    oSocket.BeginReceive(oSocketState.Buffer, 0, SocketState.BufferSize, 0, new AsyncCallback(ReceiveDataStreamWrite), oSocketState);
                }

            }
            catch (Exception ex)
            {
                //LogWriter(String.Format("파일 전송 오류 : {0}", ex.Message));
                throw (ex);
                //return false;
            }
            finally
            {
                //oSocket.Send(Encoding.UTF8.GetBytes("Disconnection<EOF>"));
                //oSocket.Close();
            }

            return true;
        }



        private void ReceiveDataCallBack(IAsyncResult Iar)
        {
            SocketState oSocketState = (SocketState)Iar.AsyncState;
            Socket oSocket = oSocketState.WorkSocket;

            try
            {
                int iSendBytes = oSocket.EndSend(Iar);

                if (iSendBytes > 0)
                {
                    // 파일 정보 수신 모드로 할당
                    oSocket.BeginReceive(oSocketState.Buffer, 0, SocketState.BufferSize, 0, new AsyncCallback(ReceiveDataStreamWrite), oSocketState);
                }
                else
                {
                    CloseSocket(Iar);
                }
            }
            catch (SocketException oSocketException)
            {
                CloseSocket(Iar);

                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}", oSocket.RemoteEndPoint.ToString()), true);
                LogWriter(oSocketException);
            }
        }

        #region 접속 해제
        private void CloseSocket(IAsyncResult Iar)
        {
            try
            {
                Socket handler = ((SocketState)Iar.AsyncState).WorkSocket;
                handler.Close();
            }
            catch
            {

            }
        }
        #endregion

        private void ReceiveDataStreamWrite(IAsyncResult Iar)
        {
            string errorIndex = "0";

            SocketState oSocketState = (SocketState)Iar.AsyncState;
            Socket oSocket = oSocketState.WorkSocket;
            String strFileName = Path.GetFileName(oSocketState.oFileStream.Name);

            try
            {
                errorIndex = "1";
                int iMessageLength = oSocket.EndReceive(Iar);

                // 파일 데이터 사이즈를 가지고 옴
                if (iMessageLength > 0)
                {
                    errorIndex = "2";
                    oSocketState.oFileStream.Write(oSocketState.Buffer, 0, iMessageLength);
                    errorIndex = "3";
                    //진행 파일 크기 전송
                    //long fileStreamWriteSize = oSocketState.oFileStream.Length;
                    //SendMessage(Iar, "ReceiveFileSize TEST<EOF>");

                    if (oSocketState.oFileStream.Length == oSocketState.iFileSize)
                    {
                        errorIndex = "4";
                        // 파일 쓰기 완료
                        oSocketState.oFileStream.Flush();
                        oSocketState.oFileStream.Close();

                        //SendMessage(Iar, "FINISH<EOF>");
                        oSocket.Send(Encoding.UTF8.GetBytes("FINISH<EOF>"));

                        //if (ReciveMessage(oSocket).Equals("FINISH"))
                        //{ 
                        //oSocket.Send(Encoding.UTF8.GetBytes("FINISH<EOF>"));
                        //}



                        // 쓰레드 접근제한 해제
                        //MrReceiveFileDone.Set();

                        //txtBoxInfo.Text += String.Format("파일 수신완료 : {0}", strFileName);
                        //txtBoxFileList.Text += strFileName + Environment.NewLine;
                    }
                    else
                    {
                        errorIndex = "5";
                        // 데이터 추가 수신대기
                        oSocket.BeginReceive(oSocketState.Buffer, 0, SocketState.BufferSize, 0, new AsyncCallback(ReceiveDataStreamWrite), oSocketState);
                        errorIndex = "6";
                    }
                }
            }
            catch (SocketException oSocketException)
            {
                //CloseSocket(Iar);

                LogWriter(String.Format("파일 정보 수신중 오류 발생 : {0}   {1}", oSocket.RemoteEndPoint.ToString(), errorIndex), true);
                LogWriter(oSocketException);
            }
        }


        void bgwReceiveFile_DoWork(object sender, DoWorkEventArgs e)
        {
            FileDownLoadDoWork();
        }






        /// <summary>
        /// name         : FileUpload
        /// desc         : 서버에 파일을 올린다.
        /// author       : 심우종
        /// create date  : 2020-05-21 13:37
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool FileUpload(string localPath, string serverPath)
        {
            //파일정보 설정
            this.paramInfo = new ParamInfo();
            this.paramInfo.localPath = localPath;
            this.paramInfo.serverPath = serverPath;


            if (string.IsNullOrEmpty(localPath) || string.IsNullOrEmpty(serverPath))
            {
                if (this.ShowErrorMessage == true)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("파일 경로가 없습니다.");
                }
                
                return false;
            }

            if (!bSocketConnected)
            {
                if (this.ShowErrorMessage == true)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("서버와 연결되지 않았습니다.", "서버 접속 오류", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                
                return false;
            }
            else
            {
                try
                {
                    if (IsSync == false)
                    {
                        //비동기
                        BackgroundWorker bgwSendFile = new BackgroundWorker();
                        bgwSendFile.DoWork += new DoWorkEventHandler(bgwSendFile_DoWork);
                        bgwSendFile.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwSendFile_RunWorkerCompleted);
                        bgwSendFile.RunWorkerAsync();

                    }
                    else
                    {
                        //동기
                        bool result = SendFileDoWork();
                        return result;
                    }

                }
                catch (Exception ex)
                {
                    LogWriter(String.Format("파일 업로드 오류 : {0}", ex.Message), true);
                    return false;
                }
            }

            return true;
        }

        public class ParamInfo
        {
            public string localPath = "";
            public string serverPath = "";
        }

        ParamInfo paramInfo = new ParamInfo();



        

        private bool SendFileDoWork()
        {
            if (paramInfo == null)
            {
                if (this.ShowErrorMessage == true)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("파일 정보를 확인할 수 없습니다.");
                }
                
                return false;
            }

            try
            {


                //CheckForIllegalCrossThreadCalls = false;

                FileInfo oFileInfo = new FileInfo(paramInfo.localPath);
                string fileName = oFileInfo.Name;

                long holdFileSize = oFileInfo.Length;

                string strDupCheck = "N";
                if (IsDupCheck == true)
                {
                    strDupCheck = "Y";
                }

                // 파일 정보 전송
                oSocket.Send(Encoding.UTF8.GetBytes("FileUpload|" + paramInfo.serverPath + "|" + oFileInfo.Length + "|" + strDupCheck + "<EOF>"));

                string reciveValue = ReciveMessage(oSocket);
                // 파일 송신 대기
                if (reciveValue.Equals("OK"))
                {
                    //btnSend.Text = "전송중...";
                    //btnSend.Enabled = false;
                    LogWriter(String.Format("파일 전송 시작 : {0}", oFileInfo.Name), false);

                    byte[] btFileName = new byte[1024];
                    FileStream fs = null;

                    bool isLarge = false;


                    try
                    {
                        //progressBar1.Value = 0;
                        //progressBar1.Maximum = Convert.ToInt32(oFileInfo.Length);

                        fs = new FileStream(paramInfo.localPath, FileMode.Open, FileAccess.Read, FileShare.Read);
                        string stFileSize = fs.Length.ToString();

                        byte[] btFile = new byte[10240];
                        double sendBytes = 0;
                        int nSize = 0;

                        int lastPercent = 0;
                        int gap = 2;


                        if (oFileInfo.Length > 10000000)
                        {
                            isLarge = true;
                        }

                        while ((nSize = fs.Read(btFile, 0, btFile.Length)) > 0)
                        {
                            oSocket.Send(btFile, nSize, 0);

                            sendBytes += nSize;

                            //progressBar1.Value = sendBytes;
                            if (isLarge == true)
                            {
                                double percent = (double)(sendBytes * 100) / (double)(oFileInfo.Length);

                                if (percent > lastPercent)
                                {
                                    lastPercent = lastPercent + gap;
                                    if (onPercentInfoEvent != null)
                                    {
                                        onPercentInfoEvent(percent, fileName, "U", oFileInfo.Length, sendBytes);
                                    }
                                }
                            }



                            //label4.Text = String.Format("{0}%", Math.Ceiling(percent).ToString());
                            //label6.Text = GetFileSize(Convert.ToDouble(sendBytes));
                        }
                    }
                    catch (System.Exception ex)
                    {
                        if (this.ShowErrorMessage == true)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(ex.ToString());
                        }

                        return false;
                    }
                    finally
                    {
                        if (fs != null)
                        {
                            fs.Close();
                        }
                    }

                    if (!ReciveMessage(oSocket).Equals("FINISH"))
                    {
                        LogWriter("파일 전송중 오류가 발생 하였습니다.", true);
                        return false;
                    }
                    else
                    {
                        if (isLarge == true)
                        {
                            if (onPercentInfoEvent != null)
                            {
                                onPercentInfoEvent(100, fileName, "U", oFileInfo.Length, oFileInfo.Length);
                            }
                        }

                        //LogWriter(String.Format("파일 전송 완료 : {0}", oFileInfo.Name));
                        LogWriter(String.Format("파일 전송 완료"), false);
                        return true;
                    }
                }
                else if (reciveValue.Equals("SIZE_IS_EMPTY"))
                {
                    LogWriter(String.Format("파일 전송 완료"), false);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일 업로드 오류 : {0}", ex.Message), true);
                return false;
            }
            finally
            {
                //oSocket.Send(Encoding.UTF8.GetBytes("Disconnection<EOF>"));
                //oSocket.Close();
            }
        }

        void bgwSendFile_DoWork(object sender, DoWorkEventArgs e)
        {
            this.SendFileDoWork();
        }

        private string ReciveMessage(Socket oSocket)
        {
            byte[] bytes = new byte[10240];
            StringBuilder oStringBuilder = new StringBuilder();
            int bytesRec = 0;

            try
            {
                while (oStringBuilder.ToString().IndexOf("<EOF>") < 0)
                {


                    //int nCount = await Task.Factory.FromAsync<int>(
                    //           oSocket.BeginReceive(bytes, 0, bytes.Length, SocketFlags.None, null, oSocket),
                    //           oSocket.EndReceive);
                    //if (nCount > 0)
                    //{
                    //    oStringBuilder.Append(Encoding.UTF8.GetString(bytes, 0, nCount));
                    //}


                    bytesRec = oSocket.Receive(bytes);
                    oStringBuilder.Append(Encoding.UTF8.GetString(bytes, 0, bytesRec));

                    if (bytesRec.Equals(0))
                    {
                        break;
                    }
                }
                


                messageErrorCheck(oStringBuilder.ToString().Replace("<EOF>", ""));

                return oStringBuilder.ToString().Replace("<EOF>", "");
            }
            catch (SocketException oSocketException)
            {
                throw oSocketException;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        void bgwSendFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            //btnSend.Text = "전송";
            //btnSend.Enabled = true;

            if (e.Error != null)
            {
                LogWriter(String.Format("파일 전송 오류 : {0}", e.Error.Message), true);
            }
            else
            {
                //LogWriter(String.Format("파일 전송 완료"));
            }

        }


        private bool IsChkIpAddress(string strIP)
        {
            String pattern = @"^([1-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])(\.([0-9]|[1-9][0-9]|1[0-9][0-9]|2[0-4][0-9]|25[0-5])){3}$";
            return Regex.IsMatch(strIP, pattern);
        }

        private String[] GetContentsArray(string oStringBuilder)
        {
            try
            {
                String[] arrContents = oStringBuilder.ToString().Replace("<EOF>", "").Split(Convert.ToChar("|"));

                //if (arrContents.Length > 2)
                //{
                //    if (arrContents[0].ToString() == "▥FAIL▥")
                //    {
                //        Exception eee = new Exception(arrContents[1].ToString());
                //        throw (eee);
                //    }
                //}

                //messageErrorCheck(oStringBuilder);

                return arrContents;
            }
            catch(Exception ex)
            {

            }

            return null;
        }

        void messageErrorCheck(string message)
        {
            String[] arrContents = message.ToString().Replace("<EOF>", "").Split(Convert.ToChar("|"));

            try
            {
                if (arrContents.Length >= 2)
                {
                    if (arrContents[0].ToString() == "▥FAIL▥")
                    {
                        Exception eee = new Exception(arrContents[1].ToString());
                        throw (eee);
                    }
                }
            }
            catch(Exception ex)
            {
                if (this.ShowErrorMessage == true)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("파일 정보 수신중 오류 발생 : " + ex.Message, "확인");
                    
                }
                throw ex;
                
            }
            
        }


        /// <summary>
        /// name         : filePathCheck
        /// desc         : 경로 체크(디렉토리 생성)
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void filePathCheck(string localFilePath)
        {
            string[] spliPath = localFilePath.Split('\\');

            //string fileName = "";
            string path = "";


            if (spliPath != null && spliPath.Count() > 0)
            {



                for (int i = 0; i < spliPath.Count(); i++)
                {
                    //처음은 루트경로.. 체크 PASS
                    if (i == 0)
                    {
                        path = spliPath.ElementAt(i);
                    }
                    else
                    {
                        path = path + "\\" + spliPath.ElementAt(i);
                        this.DirectoryCheck(path);
                    }


                }
            }
        }



        /// <summary>
        /// name         : FileCopy
        /// desc         : 파일복사
        /// author       : 심우종
        /// create date  : 2020-11-04 11:42
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool FileCopy(string serverPathAndName, string copyFolder)
        {
            try
            {
                oSocket.Send(Encoding.UTF8.GetBytes("FileCopy|" + serverPathAndName + "|" + copyFolder + "<EOF>"));

                string message = ReciveMessage(oSocket);
                if (message == "OK")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                LogWriter(String.Format("파일복사 오류 : {0}", ex.Message), true);
                return false;
            }
        }




        string backUpRootPath = "D:\\SeverDataBackup";


        /// <summary>
        /// name         : filePathCheck
        /// desc         : 서버 경로 체크(디렉토리 생성 및 파일이름, 경로 리턴)
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        //private void filePathCheck(string rootPath, string serverFilePath, ref string outFileName, ref string outFilePath)
        //{
        //    string[] spliPath = serverFilePath.Split('\\');

        //    string fileName = "";
        //    //string path = this.rootPath;


        //    if (spliPath != null && spliPath.Count() > 0)
        //    {
        //        for (int i = 0; i < spliPath.Count(); i++)
        //        {
        //            //마지막은 파일명
        //            if (i == spliPath.Count() - 1)
        //            {
        //                fileName = spliPath.ElementAt(i);
        //            }
        //            else
        //            {
        //                path = path + "\\" + spliPath.ElementAt(i);
        //                this.DirectoryCheck(path);
        //            }


        //        }
        //    }

        //    outFileName = fileName;
        //    outFilePath = path;

        //}


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


        #region 로그 기록
        private void LogWriter(String strMsg, bool isError)
        {
            try
            {
                TxtBoxInfoWriter(strMsg);

                if (isError == true)
                {
                    //로그를 남기자..
                    LogHelper logHelper = new LogHelper();
                    logHelper.WriteLog("SocketServerError", LogType.ERROR, ActionType.ETC, "소켓 파일서버 에러", strMsg);
                }
            }
            catch
            {
                
            }
        }

        private void LogWriter(Exception ex)
        {
            try
            {
                TxtBoxInfoWriter(ex.Message);
                TxtBoxInfoWriter(ex.StackTrace);
            }
            catch
            {
            }
        }

        private void TxtBoxInfoWriter(String strMsg)
        {
            //txtBoxInfo.Text += strMsg + Environment.NewLine;
            Console.WriteLine(strMsg);
        }

        private void TxtBoxInfo_TextChanged(object sender, EventArgs e)
        {
            //txtBoxInfo.SelectionStart = txtBoxInfo.Text.Length;
            //txtBoxInfo.ScrollToCaret();

        }
        #endregion
    }
}
