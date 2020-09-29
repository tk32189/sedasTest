using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace SmartPIS
{
    public class Ini
    {
        public static string strDB, strDBType, strPath, strStyle, xlsPath;
        public static string DBSelect, DBInsert, DBUpdate, DBDelete, DBDate, DBPtno, strOCSDB, OCSUpdate;
        
        public static bool working;
        public static string WK_NM, WK_ID, IniPTNO, LibraryPath;

        public static string rootpath;
        public static string temppath;
        
        // --------ini ���� �а� �������� API �Լ� ���� ------------ //
        [DllImport("kernel32.dll")]
        private static extern int GetPrivateProfileString(    // ini Read �Լ�
                    String section,
                    String key,
                    String def,
                    StringBuilder retVal,
                    int size,
                    String filePath);
        [DllImport("kernel32.dll")]
        private static extern long WritePrivateProfileString(  // ini Write �Լ�
                    String section,
                    String key,
                    String val,
                    String filePath);

        /// ini���Ͽ� ����
        public static void G_IniWriteValue(String Section, String Key, String Value, string avsPath)
        {
            WritePrivateProfileString(Section, Key, Value, avsPath);
        }

        /// ini���Ͽ��� �о� ����
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
