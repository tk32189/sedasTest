using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sedas.Core
{
    public class FileTransfer
    {

        public event Action<double, string, string, double, double> onPercentInfoEvent; //전송중인 데이터의 퍼센트를 알려주기 위한 이벤트
        /// <summary>
        /// name         : FileTransfer
        /// desc         : FileTransfer 생성자
        /// author       : 심우종
        /// create date  : FileTransfer
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public FileTransfer(string ip, string port)
        {
            this.ip = ip;
            this.port = port;
        }

        public FileTransfer()
        {
            //따로 IP, PORT를 넘기지 않으면 병리서버로 자동설정
            this.ip = "10.10.50.141";
            this.port = "28080";
        }

        bool showErrorMessage = true; //에러메시지를 표시할지 여부

        

        string ip = "";
        string port = "";

        public bool ShowErrorMessage
        {
            get
            {
                return showErrorMessage;
            }

            set
            {
                showErrorMessage = value;
            }
        }


        /// <summary>
        /// name         : FileUpload
        /// desc         : 파일 업로드
        /// author       : 심우종
        /// create date  : 2020-05-21 15:28
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// ---------------------------------------------------------------------------------------------------
        /// localPathAndName : 로컬 파일 경로 ( ex : C:\Users\tk321\OneDrive\사진\Screenshots\1.JPG)
        /// serverPathAndName : 서버에 저장될 파일 경로 (ex : Imagedata\20200521\M0000001\202005211629240.jpg)
        /// dupCheckAndChangeName : 중복된 이름 업로드시 이름 자동변경 여부
        /// </summary> 
        public bool FileUpload(string localPathAndName, string serverPathAndName, bool dupCheckAndChangeName = false)
        {
            FileSocketHandler fileSocket = new FileSocketHandler(this.ip, this.port);
            fileSocket.IsSync = true;
            fileSocket.ShowErrorMessage = this.ShowErrorMessage;
            fileSocket.IsDupCheck = dupCheckAndChangeName;
            fileSocket.onPercentInfoEvent += FileSocket_onPercentInfoEvent;
            fileSocket.onIpChanged += FileSocket_onIpChanged;
            fileSocket.Start();
            return fileSocket.FileUpload(localPathAndName, serverPathAndName);
        }


        /// <summary>
        /// name         : FileSocket_onIpChanged
        /// desc         : Ip변경이 필요한 경우
        /// author       : 심우종
        /// create date  : 2020-06-03 14:35
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void FileSocket_onIpChanged(string ip)
        {
            this.ip = ip;
        }

        /// <summary>
        /// 진행률퍼센트 데이터 전달
        /// </summary>
        /// <param name="obj"></param>
        private void FileSocket_onPercentInfoEvent(double obj, string fileName, string type, double allSize, double sendSize)
        {
            if (onPercentInfoEvent != null)
            {
                onPercentInfoEvent(obj, fileName, type, allSize, sendSize);
            }
            //throw new NotImplementedException();
        }


        /// <summary>
        /// name         : FileDownLoad
        /// desc         : 파일 다운로드
        /// author       : 심우종
        /// create date  : 2020-05-22 09:48
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// ---------------------------------------------------------------------------------------------------
        /// serverPathAndName : 서버에서 다운받을 파일 경로 (ex : Imagedata\20200521\M0000001\202005211629240.jpg)
        /// localPath : 다운로드 되는 경로 지정 (ex : D:\\LocalData)
        /// savedFilePathAndName : 다운완료 후 로컬파일경로 ( ex : D:\\LocalData\\202005211628170.jpg)
        /// [옵션] isNeedToDupNameChange (디폴트 true) : 파일 다운시 동일한 이름에 대해서 이름을 변경할지 여부 파일(1).jpg, 파일(2).jpg 형태로 자동 변경됨
        /// </summary> 
        public bool FileDownLoad(string serverPathAndName, string localPath, ref string savedFilePathAndName, bool isNeedToDupNameChange = true)
        {
            FileSocketHandler fileSocket = new FileSocketHandler(this.ip, this.port);
            fileSocket.IsSync = true;
            fileSocket.ShowErrorMessage = this.ShowErrorMessage;
            fileSocket.IsDupCheck = isNeedToDupNameChange;
            fileSocket.onPercentInfoEvent += FileSocket_onPercentInfoEvent;
            fileSocket.onIpChanged += FileSocket_onIpChanged;
            fileSocket.Start();
            return fileSocket.FileDownLoad(serverPathAndName, localPath, ref savedFilePathAndName);
        }


        /// <summary>
        /// name         : DirectoryExists
        /// desc         : 디렉토리 존재여부 확인
        /// author       : 심우종
        /// create date  : 2020-05-25 11:28
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// ---------------------------------------------------------------------------------------------------
        /// serverPath : 서버 디렉토리 경로 (ex : Imagedata\\20200525\\M0000001)
        /// </summary> 
        public bool DirectoryExists(string serverPath)
        {
            FileSocketHandler fileSocket = new FileSocketHandler(this.ip, this.port);
            fileSocket.IsSync = true;
            fileSocket.ShowErrorMessage = this.ShowErrorMessage;
            fileSocket.onIpChanged += FileSocket_onIpChanged;
            fileSocket.Start();
            
            return fileSocket.DirectoryExists(serverPath);
        }


        /// <summary>
        /// name         : MakeDirectory
        /// desc         : 디렉토리 생성
        /// author       : 심우종
        /// create date  : 2020-05-25 13:11
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// ---------------------------------------------------------------------------------------------------
        /// serverPath : 서버 디렉토리 경로 (ex : Imagedata\\test1\\test2\\S000001)
        /// </summary> 
        public bool MakeDirectory(string serverPath)
        {
            FileSocketHandler fileSocket = new FileSocketHandler(this.ip, this.port);
            fileSocket.ShowErrorMessage = this.ShowErrorMessage;
            fileSocket.IsSync = true;
            fileSocket.onIpChanged += FileSocket_onIpChanged;
            fileSocket.Start();
            return fileSocket.MakeDirectory(serverPath);

        }


        /// <summary>
        /// name         : DeleteFile
        /// desc         : 파일삭제
        /// author       : 심우종
        /// create date  : 2020-05-25 13:29
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// ---------------------------------------------------------------------------------------------------
        /// serverPathAndName : 삭제할 서버 파일 경로 (ex : Imagedata\\test1\\test2\\S000001)
        /// </summary> 
        public bool DeleteFile(string serverPathAndName)
        {
            FileSocketHandler fileSocket = new FileSocketHandler(this.ip, this.port);
            fileSocket.ShowErrorMessage = this.ShowErrorMessage;
            fileSocket.IsSync = true;
            fileSocket.onIpChanged += FileSocket_onIpChanged;
            fileSocket.Start();
            return fileSocket.DeleteFile(serverPathAndName);

        }


        /// <summary>
        /// name         : ExplorerInfo
        /// desc         : 파일 탐색기용 정보 조회
        /// author       : 심우종
        /// create date  : 2020-05-26 09:06
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public string ExplorerInfo(string serverPath, string paramIcon, string paramSize)
        {
            FileSocketHandler fileSocket = new FileSocketHandler(this.ip, this.port);
            fileSocket.ShowErrorMessage = this.ShowErrorMessage;
            fileSocket.IsSync = true;
            fileSocket.onIpChanged += FileSocket_onIpChanged;
            fileSocket.Start();
            return fileSocket.ExplorerInfo(serverPath, paramIcon, paramSize);
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
            FileSocketHandler fileSocket = new FileSocketHandler(this.ip, this.port);
            fileSocket.ShowErrorMessage = this.ShowErrorMessage;
            fileSocket.IsSync = true;
            fileSocket.onIpChanged += FileSocket_onIpChanged;
            fileSocket.Start();
            return fileSocket.NameChange(paramPath, newName, type);
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
            FileSocketHandler fileSocket = new FileSocketHandler(this.ip, this.port);
            fileSocket.ShowErrorMessage = this.ShowErrorMessage;
            fileSocket.IsSync = true;
            fileSocket.onIpChanged += FileSocket_onIpChanged;
            fileSocket.Start();
            return fileSocket.FileCheckInFolder(folderName);
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
            FileSocketHandler fileSocket = new FileSocketHandler(this.ip, this.port);
            fileSocket.ShowErrorMessage = this.ShowErrorMessage; 
            fileSocket.IsSync = true;
            fileSocket.onIpChanged += FileSocket_onIpChanged;
            fileSocket.Start();
            return fileSocket.DeleteFolder(folderName);
        }

        /// <summary>
        /// name         : CreateFolder
        /// desc         : 폴더 생성
        /// author       : 심우종
        /// create date  : 2020-06-01 09:25
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool CreateFolder(string serverPath)
        {
            FileSocketHandler fileSocket = new FileSocketHandler(this.ip, this.port);
            fileSocket.ShowErrorMessage = this.ShowErrorMessage;
            fileSocket.IsSync = true;
            fileSocket.onIpChanged += FileSocket_onIpChanged;
            fileSocket.Start();
            return fileSocket.CreateFolder(serverPath);
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
            FileSocketHandler fileSocket = new FileSocketHandler(this.ip, this.port);
            fileSocket.ShowErrorMessage = this.ShowErrorMessage;
            fileSocket.IsSync = true;
            fileSocket.onIpChanged += FileSocket_onIpChanged;
            fileSocket.Start();
            return fileSocket.ImageThumbnail(serverPathAndName);
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
            FileSocketHandler fileSocket = new FileSocketHandler(this.ip, this.port);
            fileSocket.ShowErrorMessage = this.ShowErrorMessage;
            fileSocket.IsSync = true;
            fileSocket.onIpChanged += FileSocket_onIpChanged;
            fileSocket.Start();
            return fileSocket.SedasSetupFileInfo(projectName, lastDtm);
        }



        //private void SetControlStates(bool isConnected)
        //{
        //    //btnStart.Enabled = !isConnected;
        //    //btnStop.Enabled = isConnected;
        //    //btnSend.Enabled = isConnected;
        //}









    }
}
