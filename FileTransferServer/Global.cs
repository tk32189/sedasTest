using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FileTransferServer
{
    public class Global
    {
        public static string strSettingPath = System.Environment.CurrentDirectory + "\\Setting\\Setting.ini";
        public static string rootPath = "";
        public static string rootPath_backup = "";
        public static string isNeedToFileBackup = "";
        public static string defaultPort = "";
        public static string checkIp1 = "";
        public static string checkIp2 = "";


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
