using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Net;
using System.IO;

namespace Sedas.Core
{
    public class sFTP
    {
        /// <summary>
        /// FTP 파일 다운로드하기
        /// </summary>
        /// <param name="ftpPath">다운받을 FTP 파일 경로</param>
        /// <param name="userID">사용자 ID</param>
        /// <param name="password">패스워드</param>
        /// <param name="outputFile">생성될 경로</param>
        /// <returns>처리 결과</returns>
        /// 

        public bool FtpDownload(string ftpPath, string user, string pwd, string outputFile)
        {
            try
            {
                FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpPath);

                req.Credentials = new NetworkCredential(user, pwd);
                req.Method = WebRequestMethods.Ftp.DownloadFile;
                req.UsePassive = false;
                FtpWebResponse fwr = req.GetResponse() as FtpWebResponse;

                Stream ss = fwr.GetResponseStream();
                FileStream fs = new FileStream(outputFile, FileMode.Create, FileAccess.Write);

                byte[] bData = new byte[1024];

                while (true)
                {
                    int bc = ss.Read(bData, 0, bData.Length);

                    if (bc == 0)
                    {
                        break;
                    }

                    fs.Write(bData, 0, bc);
                }

                fs.Close();
                ss.Close();

            }
            catch (System.Exception ex)
            {
                ex.Message.ToString();
                return false;
            }
            return true;
        }

        /// <summary>
        /// FTP 파일 업로드하기
        /// </summary>
        /// <param name="ftpPath">업로드할 FTP 파일 경로</param>
        /// <param name="userID">사용자 ID</param>
        /// <param name="password">패스워드</param>
        /// <param name="inputFile">업로드할 파일 경로</param>
        /// <returns>처리 결과</returns>
        public bool FtpUpload(string ftpPath, string user, string pwd, string inputFile)
        {
            try
            {
                FtpWebRequest req = (FtpWebRequest)WebRequest.Create(ftpPath);

                req.Credentials = new NetworkCredential(user, pwd);
                req.Method = WebRequestMethods.Ftp.UploadFile;
                req.UsePassive = false;

                FileStream sfs = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
                Stream ts = req.GetRequestStream();
                byte[] bData = new byte[1024];

                while (true)
                {
                    int bc = sfs.Read(bData, 0, bData.Length);
                    if (bc == 0)
                    {
                        break;
                    }

                    ts.Write(bData, 0, bc);
                }

                ts.Close();
                sfs.Close();
            }
            catch (System.Exception ex)
            {
                string strMSg = ex.Message;
                return false;
            }
            return true;
        }

        public bool GetFTPList(string targetURI, string userID, string password, string Folder)
        {
            try
            {
                FtpWebRequest ftpWebRequest = WebRequest.Create(targetURI) as FtpWebRequest;

                ftpWebRequest.Credentials = new NetworkCredential(userID, password);
                ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectory;
                ftpWebRequest.UsePassive = false;
                StreamReader streamReader = new StreamReader(ftpWebRequest.GetResponse().GetResponseStream());

                List<string> list = new List<string>();

                while (true)
                {
                    string fileName = streamReader.ReadLine();

                    if (string.IsNullOrEmpty(fileName))
                    {
                        break;
                    }

                    if (!FtpDownload(targetURI + "/" + fileName, userID, password, Folder + "\\" + fileName))
                    {
                    }

                    //list.Add(fileName);
                }

                streamReader.Close();

                return true;
            }
            catch
            {
                return false;
            }
        }



        public bool MakeDirectory(string ftpPath, string FTPAdress, string user, string pwd)
        {

            System.Net.FtpWebRequest ftp = GetRequest(ftpPath, FTPAdress, user, pwd);
            ftp.Method = System.Net.WebRequestMethods.Ftp.MakeDirectory;
            ftp.UsePassive = false;
            try
            {
                string str = GetStringResponse(ftp);
            }
            catch
            {
                return false;
            }
            return true;
        }

        private string GetStringResponse(FtpWebRequest ftp)
        {
            string result = "";
            using (FtpWebResponse response = (FtpWebResponse)ftp.GetResponse())
            {
                long size = response.ContentLength;
                using (Stream datastream = response.GetResponseStream())
                {
                    if (datastream != null)
                    {
                        using (StreamReader sr = new StreamReader(datastream))
                        {
                            result = sr.ReadToEnd();
                            sr.Close();
                        }

                        datastream.Close();
                    }
                }

                response.Close();
            }

            return result;
        }

        private FtpWebRequest GetRequest(string ftpPath, string FTPAdress, string user, string pwd)
        {
            FtpWebRequest result = (FtpWebRequest)WebRequest.Create(FTPAdress + ftpPath);
            result.Credentials = GetCredentials(user, pwd);
            result.KeepAlive = false;
            return result;
        }

        private ICredentials GetCredentials(string user, string pwd)
        {

            return new NetworkCredential(user, pwd);
        }

        public bool FTPDirectioryCheck(string directoryPath, string user, string pwd)
        {

            char Gubun = '/';
            string[] Path = directoryPath.Split(Gubun);
            directoryPath = "/" + Path[3] + "/" + Path[4];
            string FTPAdress = Path[0] + "//" + Path[2];
            string[] directoryPaths = directoryPath.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);

            string currentDirectory = string.Empty;
            foreach (string directory in directoryPaths)
            {
                currentDirectory += string.Format("/{0}", directory);
                if (!IsExtistDirectory(currentDirectory, FTPAdress, user, pwd))
                {
                    MakeDirectory(currentDirectory, FTPAdress, user, pwd);
                }
            }
            return true;
        }

        private string GetParentDirectory(string currentDirectory)
        {
            string[] directorys = currentDirectory.Split(new string[] { "/" }, StringSplitOptions.RemoveEmptyEntries);
            string parentDirectory = string.Empty;
            for (int i = 0; i < directorys.Length - 1; i++)
            {
                parentDirectory += "/" + directorys[i];
            }

            return parentDirectory;
        }


        private bool IsExtistDirectory(string currentDirectory, string FTPAdress, string user, string pwd)
        {
            string ftpFileFullPath = string.Format("{0}", GetParentDirectory(currentDirectory));
            FtpWebRequest ftpWebRequest = WebRequest.Create(new Uri(FTPAdress + currentDirectory)) as FtpWebRequest;
            ftpWebRequest.Credentials = new NetworkCredential(user, pwd);
            ftpWebRequest.UseBinary = true;
            ftpWebRequest.UsePassive = false;
            ftpWebRequest.Timeout = 10000;
            ftpWebRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            FtpWebResponse response = null;
            string data = string.Empty;
            try
            {
                response = ftpWebRequest.GetResponse() as FtpWebResponse;
                if (response != null)
                {
                    StreamReader streamReader = new StreamReader(response.GetResponseStream(), Encoding.Default);

                    data = streamReader.ReadToEnd();
                }
            }
            catch (Exception ex)
            { 
            
            }
            finally
            {
                if (response != null)
                {
                    response.Close();
                }
            }

            string[] directorys = data.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            return (from directory in directorys
                    select directory.Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries)
                        into directoryInfos
                    where directoryInfos[0][0] == 'd'
                    select directoryInfos[8]).Any(
                        name => name == (currentDirectory.Split('/')[currentDirectory.Split('/').Length - 1]).ToString());
        }

        public bool DeleteFTPFile(string targetURI, string userID, string password)
        {
            try
            {
                FtpWebRequest ftpWebRequest = WebRequest.Create(targetURI) as FtpWebRequest;

                ftpWebRequest.Credentials = new NetworkCredential(userID, password);
                ftpWebRequest.Method = WebRequestMethods.Ftp.DeleteFile;
                ftpWebRequest.UsePassive = false;
                FtpWebResponse ftpWebResponse = ftpWebRequest.GetResponse() as FtpWebResponse;
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
