using Sedas.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace IIP
{
    public class Global
    {
        public static LogHelper logHelper = new LogHelper();

        public static string strOriPath;
        public static string strPath;
        public static string strinipath;
        public static string strEdit_Path;
        public static string strsubPath;
        public static string strBackupFolderPath;
        public static string strPrinter_FolderPath;
        public static string strViewerPath;


        public static string strCallService;
        public static string strIsDev;

        public static string strGum_Location;
        public static string[] strGum_Code = new string[25];
        public static string[] strGum_Cancle_Code = new string[25];
        public static string strMachin_Code;

        //H_CODE=병원코드,  ORNB=처방번호, PAID=환자번호, PANM=환자명
        //ORDT=처방일자,    NWDT=접수일자, ORCD=처방코드, ORRS=처방명
        //DOCT=의사명,      AUDL=검사실명, ATTT=부서명
        public static string strList_Count;
        public static string[] strH_CODE = new string[500];
        public static string[] strORNB = new string[500];
        public static string[] strPAID = new string[500];
        public static string[] strPANM = new string[500];
        public static string[] strORDT = new string[500];
        public static string[] strNWDT = new string[500];
        public static string[] strORCD = new string[500];
        public static string[] strORRS = new string[500];
        public static string[] strDOCT = new string[500];
        public static string[] strAUDL = new string[500];
        public static string[] strATTT = new string[500];

        public static string strDelete_Day;
        public static string strDPI;
        public static string strWidth;
        public static string strHeight;

        public static string strHostital_Name;
        public static string strSend_FTP_Address;
        public static string strSend_FTP_ID;
        public static string strSend_FTP_pwd;
        public static string strSend_FTP_Save_Path;

        public static string strProtocol;
        public static string strClass;
        public static string strCommPort;
        public static string strBaudrate;
        public static string strParity;
        public static string strByte_size;
        public static string strStop_Bits;
        public static string strFlow_Control;
        public static string strReceive_Queue;
        public static string strTransmit_Queue;
        public static string strport;
        public static string strbyte_size;
        public static string strstop_bits;
        public static string strflow_control;
        public static string strreceive_queue;
        public static string strtransmit_queue;

        public static string strColumn_Count;
        public static string[] strColumn_Name = new string[25];
        public static string[] strColumn_Len = new string[25];
        public static string[] strColumn_FieldName = new string[25];

        public static string strDGSConnectionString;
        public static string strDGSServerIP;
        public static string strDGSServerID;
        public static string strDGSServerPASSWORD;
        public static string strDGSimagepath;
        public static string strSETTINGTYPE;
        public static int strSETTINGPRECOUNT = 0;
        public static string[] strSETTINGPRE = new string[25];
        public static string strEMRTYPE;
        public static string strEMRConnectionString;
        public static string strEMRServerIP;
        public static string strEMRTNSNAME;
        public static string strEMRID;
        public static string strEMRPASSWORD;

        //ImageShow에 보여줄 파일 주소
        public static string strShow_File_Path;

        public static Color backColor = Color.FromArgb(11, 11, 21);
        public static Color panelColor = Color.FromArgb(36, 42, 55);

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

        public static string Left(string target, int length)
        {
            if (length <= target.Length)
            {
                return target.Substring(0, length);
            }
            return target;
        }

        public static string Mid(string target, int start, int length)
        {
            if (start <= target.Length)
            {
                if (start + length - 1 <= target.Length)
                {
                    return target.Substring(start - 1, length);
                }
                return target.Substring(start - 1);
            }
            return string.Empty;
        }

        public static string Right(string target, int length)
        {
            if (length <= target.Length)
            {
                return target.Substring(target.Length - length);
            }
            return target;
        }
    }
}
