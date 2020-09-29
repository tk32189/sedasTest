using Newtonsoft.Json;
using Sedas.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SedasLauncher
{
    public class SedasLauncher
    {
        FileTransfer ft = new FileTransfer();


        private string path;
        private string addProgramList; //추가로 더 받아야할 프로젝트 이름

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

        private DataTable ServerMethod(string projectName, DateTime lastDtm)
        {
            string serverPath = @"D:\ServerData";

            string targetPath = serverPath + "\\" + "SedasSetupFiles" + "\\" + projectName;

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

                        if ((file.CreationTime - lastDtm).TotalSeconds > 0)
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

                return dt2;
            }

            return null;
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


      


        string filePathAndName = "";
        string loginId = "";

        public string FilePathAndName
        {
            get
            {
                return filePathAndName;
            }

            set
            {
                filePathAndName = value;
            }
        }

        public string LoginId
        {
            get
            {
                return loginId;
            }

            set
            {
                loginId = value;
            }
        }

        /// <summary>
        /// name         : Form1_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-08-25 09:41
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void Start()
        {

            //string testPath2 = @"C:\BASE\SedasSolutions\ImageOCR\bin\Debug\ImageOCR - 복사본.exe";
            //FileInfo testFile2 = new FileInfo(testPath2);


            //받아와야할 값!!! -------------------------------------------------------------
            //this.FilePathAndName = @"C:\BASE\사용자PC\SEDAS\ImageOCR\ImageOCR.exe";
            //this.FilePathAndName = @"C:\SEDAS\DGS_Viewer\DGS_Viewer.exe";
            
            //-------------------------------------------------------------

            if (string.IsNullOrEmpty(FilePathAndName))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("알수없는 실행경로 입니다.");
                return;
            }
            

            this.SetupFileCheck(this.FilePathAndName, true);

            //같이 다운받아야할 프로그램이 있는 경우.. 서버ini 파일의 ADD_PROGRAM과 연결된 경우 같이 다운받는다.
            if (!string.IsNullOrEmpty(this.addProgramList))
            {
                string rootPath = "";
                string[] stlPath = FilePathAndName.Split('\\');
                if (stlPath != null && stlPath.Count() > 2)
                {
                    for (int i = 0; i < stlPath.Count() - 2; i++)
                    {
                        //설치할 root경로 구하기 ex) C:\SEDAS\DGS_Viewer\DGS_Viewer.exe => "C:\SEDAS" 리턴
                        rootPath = rootPath + stlPath.ElementAt(i) + "\\";
                    }
                }

                if (!string.IsNullOrEmpty(rootPath))
                {
                    string[] splList = addProgramList.Split(',');
                    if (splList != null && splList.Count() > 0)
                    {
                        for (int i = 0; i < splList.Count(); i++)
                        {
                            string subProjectFilePathAndName = splList.ElementAt(i);
                            if (!string.IsNullOrEmpty(subProjectFilePathAndName))
                            {
                                this.SetupFileCheck(rootPath + subProjectFilePathAndName, false);
                            }
                        }
                    }
                }
            }

            FileInfo fileInfo = new FileInfo(FilePathAndName);

            //프로그램 실행
            if (fileInfo.Exists == true)
            {
                using (Process compiler = new Process())
                {
                    compiler.StartInfo.FileName = fileInfo.FullName;
                    string arg = string.Format("{0}", LoginId);
                    compiler.StartInfo.Arguments = arg;
                    compiler.StartInfo.UseShellExecute = false;
                    compiler.StartInfo.RedirectStandardOutput = true;
                    compiler.StartInfo.WorkingDirectory = fileInfo.DirectoryName;
                    compiler.Start();

                    Console.WriteLine(compiler.StandardOutput.ReadToEnd());
                }
            }



            return;



            //Global.InitGlobal(); //글로벌 변수 초기화
            //this.path = Global.path;

            //if (string.IsNullOrEmpty(this.path))
            //{
            //    this.Close();
            //}

            //FileInfo file = new FileInfo(this.path);
            //if (file.Exists == true)
            //{
            //    using (Process compiler = new Process())
            //    {
            //        compiler.StartInfo.FileName = this.path;
            //        //string arg = string.Format("\"{0}\" {1} {2} {3} {4} {5} {6}", filePath, strImagePath, strPathologyNum, imageType, ptNo, ptNm, imageNum);
            //        //compiler.StartInfo.Arguments = arg;
            //        compiler.StartInfo.UseShellExecute = false;
            //        compiler.StartInfo.RedirectStandardOutput = true;
            //        compiler.StartInfo.WorkingDirectory = file.DirectoryName;
            //        compiler.Start();

            //        Console.WriteLine(compiler.StandardOutput.ReadToEnd());
            //    }
            //}

            //this.Close();

        }

        public void InitGlobal(string localFolderPath)
        {
            Global.strSettingPath = localFolderPath + "\\" + "SedasSetupVersion_Client.ini";

            FileInfo file = new FileInfo(Global.strSettingPath);
            if (file.Exists == false)
            {
                file.Create();

                //INI 파일 초기값 설정
                //Global.G_IniWriteValue("LAUNCHER", "PATH", @"C:\BASE\SedasSolutions\ImageOCR\bin\Debug\ImageOCR.exe", Global.strSettingPath);
                Global.G_IniWriteValue("LAUNCHER", "LAST_UPDATE", "19000101010101", Global.strSettingPath);
            }


            //Global.path = Global.G_IniReadValue("LAUNCHER", "PATH", Global.strSettingPath);
            Global.strLastUpdate = Global.G_IniReadValue("LAUNCHER", "LAST_UPDATE", Global.strSettingPath);
            Global.strVersion = Global.G_IniReadValue("LAUNCHER", "VERSION", Global.strSettingPath);

        }


        /// <summary>
        /// name         : 
        /// desc         : 
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SetupFileCheck(string filePathAndName, bool isMainProject)
        {
            FileInfo fileInfo = new FileInfo(filePathAndName);
            string localFolderPath = fileInfo.DirectoryName;

            DirectoryInfo di = new DirectoryInfo(localFolderPath);

            if (di.Exists == false)
            {
                di.Create();
            }

            if (fileInfo.Exists)
            {
                string name = fileInfo.Name.Split('.').FirstOrDefault();

                if (!string.IsNullOrEmpty(name))
                {
                    Process[] processList = Process.GetProcessesByName(name);

                    //기존에 띄워져 있으면 kill
                    if (processList != null && processList.Count() > 0)
                    {
                        foreach (Process pro in processList)
                        {
                            pro.Kill();
                        }
                    }
                }
            }

            //글로벌 변수 설정
            this.InitGlobal(localFolderPath);

            int lastFolderIndex = fileInfo.DirectoryName.LastIndexOf("\\");
            string lastFolderName = fileInfo.DirectoryName.Substring(lastFolderIndex + 1, fileInfo.DirectoryName.Length - lastFolderIndex - 1);
            string versionInfo = "";

            //서버에 있는 버전파일 위치
            string versionFilePath = "SedasSetupFiles\\SedasSetupVersion_Server.ini";

            string versionFileLoadPath = "";
            //버전 정보 확인
            if (ft.FileDownLoad(versionFilePath, localFolderPath, ref versionFileLoadPath, isNeedToDupNameChange: false) == true)
            {
                versionInfo = Global.G_IniReadValue("VERSION", lastFolderName, versionFileLoadPath);
                string addProgramList = Global.G_IniReadValue("ADD_PROGRAM", lastFolderName, versionFileLoadPath);

                if ( isMainProject == true && !string.IsNullOrEmpty(addProgramList))
                {
                    this.addProgramList = addProgramList;
                }


                string isEnable = Global.G_IniReadValue("SETTING", "Enable", versionFileLoadPath);

                if (isEnable == "N")
                {
                    return;
                }

                if (!string.IsNullOrEmpty(versionInfo))
                {
                    if (versionInfo == Global.strVersion)
                    {
                        //이전에 받은 버전과 동일함.. PASS
                        return;
                    }
                }
            }

            string[] splName = fileInfo.Name.Split('.');
            if (splName.Count() > 0)
            {
                DateTime lastDtm = new DateTime(1900, 1, 1, 1, 1, 0);
                string strLastDtm = Global.strLastUpdate;
                if (!string.IsNullOrEmpty(strLastDtm) && strLastDtm.Length == 14)
                {
                    lastDtm = StringToDate(strLastDtm).Value;
                }

                //serverDt = ServerMethod(splName.ElementAt(0), lastDtm);

                //파일서버에서 다운로드 필요한 파일이 있는지 확인
                string result = ft.SedasSetupFileInfo(lastFolderName, lastDtm.ToString("yyyyMMddHHmmss"));


                //string jsonValue = ft.ExplorerInfo(path, paramIcon, paramSize);


                string[] splValue = result.Split('|');

                if (splValue.Count() < 2)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("설치파일 정보조회 실패");
                    return;
                }

                if (splValue.ElementAt(0).ToString() == "OK")
                {
                    //최신버전이거나.. 다운받을 파일이 없다.
                }
                else if (splValue.ElementAt(0).ToString() == "FAIL")
                {
                    //오류... 일단 무시하자
                }
                else if (splValue.ElementAt(0).ToString() == "EXISTS")
                {
                    //새 버전 복사 필요함.
                    DataTable serverDt = JsonConvert.DeserializeObject<DataTable>(splValue.ElementAt(1));

                    int count = 0;
                    if (serverDt != null && serverDt.Rows.Count > 0)
                    {
                        string title = lastFolderName + " 업데이트";
                        FileDownLoadProgressPopup fileDownLoadProgressPopup = new FileDownLoadProgressPopup(serverDt, localFolderPath, title, ft);
                        fileDownLoadProgressPopup.ShowDialog();
                        //fileDownLoadProgressPopup.Start(serverDt, localFolderPath, title, ft);
                        //fileDownLoadProgressPopup.Close();

                        //foreach (DataRow row in serverDt.Rows)
                        //{
                        //    string localPath = localFolderPath;
                        //    string fileCheckName = row["fileCheckName"].ToString();
                        //    int lastPathIndex = fileCheckName.LastIndexOf("\\");
                        //    if (lastPathIndex > 0)
                        //    {
                        //        localPath = localPath + fileCheckName.Substring(0, lastPathIndex);
                        //    }
                        //    //string localPath = localFolderPath + 
                        //    string savedFilePathAndName = "";
                        //    if (ft.FileDownLoad(row["fileFullName"].ToString(), localPath, ref savedFilePathAndName, isNeedToDupNameChange: false) == true)
                        //    {
                        //        //다운받기 성공
                        //    }
                        //    else
                        //    {
                        //        //다운받기 실패
                        //    }
                        //}

                        string lastUpdateDtm = DateTime.Now.ToString("yyyyMMddHHmmss");

                        //마지막 업데이트 정보를 남긴다.
                        Global.G_IniWriteValue("LAUNCHER", "LAST_UPDATE", lastUpdateDtm, Global.strSettingPath);

                        if (!string.IsNullOrEmpty(versionInfo))
                        {
                            Global.G_IniWriteValue("LAUNCHER", "VERSION", versionInfo, Global.strSettingPath);
                        }

                    }


                }


            }
        }
    }
}
