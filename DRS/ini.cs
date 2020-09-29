using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DRS
{
    public class Ini
    {

        public static string strStudyID;
        public static string strPatID;
        public static int nType;

        public static string strDB;
        public static string strOCS;
        public static string OCSSelectDate, OCSSelectPtno, OCSInsert, OCSUpdate, OCSDelete;
        public static string DBSelect, DBInsert, DBUpdate, DBDelete;
        public static string strAviPath;

        public static bool working;

        public static string strPath;
        public static string strPathoNo;
        public static string filepath;
        public static string fullpath;
        public static string rootpath;
        public static string avipath;

        public static string strVideo;
        public static string strAudio;
        public static string strCodec;
        public static int nVedio;
        public static int nAudio;
        public static int nCodec;

        public static string PFCnt;
        public static string PFHP;
        public static string YRHP;
        public static string YRLen;
        public static string NumCnt;
        public static string Zero;
        public static string SQLDB;
        public static string SQLDBPtnoSelect, SQLDBDateSelect;
        public static int nRecord;
        public static int nPlay;

        public static string strSearchPath, strBackPath, CapturePath, strTempPath;


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
