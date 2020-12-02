using Sedas.Core;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DGS_Viewer
{
    public static class ConstantData
    {
        public static string SMALL_SIZE = "1";
        public static string LARGE_SIZE = "0";
    }
    



    public static class g_DBconnectData
    {
        //setup.ini
        public static string strDGSDsn; //DB, DGSDSN
        public static string strDGSPasswd; //DB, DGSUSER
        public static string strDGSUser; //DB, DGSPASSWD
        public static string strDGSConnectionString; //DB, DGSConnectionString
        public static string strOCSDsn; //DB, OCSDSN
        public static string strOCSPasswd; //DB, OCSPASSWD
        public static string strOCSUser; //DB, OCSUSER
        public static string strOCSConnectionString; //DB, OCSConnectionString

        public static string strCallService;
        public static string strIsDev;
        public static bool bOCS = false; //
    }

    public static class g_OthersSetupData
    {
        //setup.ini
        public static int nUIMode; //OTHERS, UIMODE
        public static int nCipher; //OTHERS, CIPHER
        public static int nImageSize; //OTHERS, IMAGESIZE
        public static string sortOption; // studyDt : 접수일 우선, insertDt : 촬영일 우선
        public static int nPeriod; //조회기간
        public static string periodType; //기간검색 타입
        public static string onlyMapping; //매핑 이미지만 조회여부
        public static bool bAddHypen; //OTHERS, ADDHYPEN
        public static bool bShowPathology; //OTHERS, SHOWPATHOLOGY
        public static bool bNotSendDicom; //OTHERS, SEARCHNOTDICOM
        public static string SearchType;
        public static string ptonoType;
    }

    public static class g_PathData
    {
        public static string strIniPath; //IniFiles\\setup.ini
        public static string strIniCombo; //IniFiles\\combo.ini
        public static string strQueryPath; //Querys\\
        public static string strPaintPath; //IniFiles\\Paint.ini

        public static string strExcelPath; //excel
        public static string strMappingPath; //IniFiles\\mapping.ini
        public static string strBackGroundImagePath; //Background\\
        public static string strImageButtonPath; //Background\\
        public static string strTempImagePath; //tempimage\\

        //setup.ini
        public static string strImagePath; //PATH, IMAGE
        public static string strServerIP; //PATH, SERVERIP
        public static string strPhotoshopPath; //PATH, PROGRAM
    }

    public static class g_ListData
    {
        //setup.ini
        public static string strCount; //LIST, COUNT
        public static List<string> strarrayListName = new List<string>(); //[LIST]
        public static List<string> strarrayListNumber = new List<string>(); //[LIST]
        public static List<string> strarrayListLength = new List<string>(); //[LIST]
    }

    public static class g_ComboData
    {
        //combo.ini
        public static string strCharCount; //[CHAR], COUNT 
        public static List<string> strarrayChar = new List<string>(); //[CHAR], COUNT 
        public static string strWeekCount; //[[WEEK]], COUNT 
        public static List<string> strarrayWeek = new List<string>(); //[[WEEK]], COUNT 
    }

    public static class g_MappingData
    {
        //mapping.ini
        public static double dbHorizontal; //[OP], HORIZONTAL
        public static double dbVertical; //[OP], VERTICAL
        public static double dbBi; //[OP],BI
        public static int nBlue; //[OP], BLUE
        public static int nGridOnOffMode; //[OP], GRID
        public static int nBlackMode; //[OP], BLACK
        public static int nColorMode; //[OP], COLOR
        public static int nSizeMode; //[OP], SIZE
        public static Color rgnColor;
    }

    public class Global
    {
        public static LogHelper logHelper = new LogHelper();

        public static string strPath;
        public static string strExcelPath;
        public static string tempFolder;

        public static Color backColor = Color.FromArgb(11, 11, 21);
        public static Color panelColor = Color.FromArgb(36, 42, 55);



        


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

        public static String G_IniReadValue(String Section, String Key, string avsPath)
        {
            StringBuilder temp = new StringBuilder(2000);
            int i = GetPrivateProfileString(Section, Key, "", temp, 2000, avsPath);

            return temp.ToString();
        }
    }

    
}
