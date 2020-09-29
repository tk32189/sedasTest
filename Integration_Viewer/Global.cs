using Sedas.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Integration_Viewer
{
    public class Global
    {
        public static LogHelper logHelper = new LogHelper();

        public static string tempFolderPath = System.Environment.CurrentDirectory + "\\" + "tempFiles" + "\\";
        public static string tempFolderForFileMovePath = System.Environment.CurrentDirectory + "\\" + "tempForFileMove" + "\\";


        public static Color backColor = Color.FromArgb(11, 11, 21);
        public static Color panelColor = Color.FromArgb(29, 32, 44);
        public static Color tabBackColor = Color.FromArgb(17, 17, 22);

        public static DataTable InitFileDataTable()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("rootPath", typeof(string));
            dt.Columns.Add("filePath", typeof(string));
            dt.Columns.Add("sendStat", typeof(string));
            dt.Columns.Add("serialNo", typeof(string));
            dt.Columns.Add("studyId", typeof(string));
            dt.Columns.Add("type", typeof(string));
            dt.Columns.Add("seq", typeof(string));

            dt.Columns.Add("fileName", typeof(string));
            dt.Columns.Add("isChecked", typeof(string));

            return dt;
        }

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
