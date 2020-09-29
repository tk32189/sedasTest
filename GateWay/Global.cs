using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace GateWay
{
    public static class m_SettingValue
    {
        public static string szWorkListIP;
        public static string szWorkListServerAE;
        public static string szWorkListClientAE;
        public static int nWorkListPort;

        public static string szPacsIP;
        public static string szPacsServerAE;
        public static string szPacsClientAE;
        public static int nPacsPort;

        public static string szPacsIP_2;
        public static string szPacsServerAE_2;
        public static string szPacsClientAE_2;
        public static int nPacsPort_2;

        public static string szModality;
        public static string szTransferSyntax;
        public static string szImplementationClassUID;
        public static string szStudyInstanceUID;

        public static string szCopyLName;
        public static string szCopyID;
        public static string szCopyPassword;
        public static string szCopyAddress;
        public static int bUseSecondePacs;

        public static string szDSN;
        public static string szDBID;
        public static string szDBPassword;

        public static string szOCS_DSN;
        public static string szOCS_DBID;
        public static string szOCS_DBPassword;

        public static string szFTPServerIP;
        public static string szFTPUser;
        public static string szFTPPassword;
        public static string szFtpDstDir;

        public static string szImagePath;
        public static int dwSearchInterval;
        public static bool bLogging;

        public static bool bSendEmailByError;

        

        public static List<string> emailAddressList = new List<string>();

    }

    public class Global
    {
        public static bool isRun = false;

        public static string m_strPath;
        public static string tempFolder = System.Environment.CurrentDirectory + "\\" + "TempFolder";
        public static string dicomFolder = System.Environment.CurrentDirectory + "\\" + "dicom";

        public static bool isDev = false; //개발모드(true), 운영모드(false)

        // --------ini 파일 읽고 쓰기위한 API 함수 선언 ------------ //
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(    // ini Read 함수
                    String section,
                    String key,
                    String def,
                    StringBuilder retVal,
                    int size,
                    String filePath);
        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(  // ini Write 함수
                    String section,
                    String key,
                    String val,
                    String filePath);

        /// ini파일에 쓰기
        public static void G_IniWriteValue(String Section, String Key, String Value, string avsPath)
        {
            WritePrivateProfileString(Section, Key, Value, avsPath);
        }

        /// ini파일에서 읽어 오기
        public static String G_IniReadValue(String Section, String Key, string avsPath)
        {
            StringBuilder temp = new StringBuilder(2000);
            int i = GetPrivateProfileString(Section, Key, "", temp, 2000, avsPath);

            return temp.ToString();
        }
    }
}
