using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGS_Viewer.DTO;
using System.Diagnostics;
using System.Reflection;
using Sedas.Control;
using System.Runtime.InteropServices;
using Sedas.Core;
using Sedas.DB;
using System.Net;
using System.Xml;
using System.Xml.Linq;
using DevExpress.XtraPrinting;
using ClosedXML.Excel;
using Newtonsoft.Json;
using Sedas.ImageHelper;
using LicenseManager = GdPicture14.LicenseManager;
using DevExpress.XtraGrid.Columns;

namespace DGS_Viewer
{
    public partial class DGS_Viewer : DevExpress.XtraEditors.XtraForm
    {
        [DllImport("Shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirecotry, int nShowCmd);

        public string receivedPtono = ""; //다른 프로그램에서 전달된 ptono가 있는경우

        //FileTransfer ft = new FileTransfer("10.10.221.72", "1111");
        FileTransfer ft = new FileTransfer();

        CallService callService = new CallService("10.10.221.72", "8180"); //건대병원 DB연결
        //CallService callService = new CallService("kis.kuh.ac.kr"); //건대병원 DB연결
        CoreLibrary coreLibrary = new CoreLibrary();


        //이미지 사이즈
        const int imageSize_BigHeight = 180;
        const int imageSize_BigWidth = 210;
        const int imageSize_smallHeight = 90;
        const int imageSize_smallWidth = 100;

        int beforeUiMode = -1; //이전에 설정된 UI모드
        int beforeImageSize = -1; //이전에 설정된 사이즈모드

        //현재 선택된 아이템.. [중요] 저장버튼 클릭시 이 데이터를 기준으로 저장이 이루어짐.
        DataRow selectedItem = null;


        //현재 화면에 나오는 이미지 리스트
        List<ImageContainer> imageList = new List<ImageContainer>();

        public List<ImageContainer> ImageList
        {
            get
            {
                return GetImageList();
            }
        }

        public DGS_Viewer()
        {
            InitializeComponent();
        }


        /// <summary>
        /// 로드시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {

            LicenseManager licenseManager = new LicenseManager();
            licenseManager.RegisterKEY("21185684790302862131615213975647244276");


            //글로벌 변수 설정
            Global.strPath = System.Environment.CurrentDirectory + "\\Temp_image";
            Global.strExcelPath = System.Environment.CurrentDirectory + "\\excel";
            Global.tempFolder = System.Environment.CurrentDirectory + "\\" + "TempFolder";

            this.InitGlobalData();


            if (g_DBconnectData.strIsDev == "Y")
            {
                this.callService = new CallService("10.10.221.72", "8180");
                ft = new FileTransfer("10.10.221.71", "1111");
                //this.callService = new CallService("kisnewdev.kuh.ac.kr");
                this.Text = this.Text + "  (개발)";
            }
            else
            {
                this.callService = new CallService(g_DBconnectData.strCallService);
            }

            //컨트롤 초기화
            InitControls();

            //Context 메뉴 설정
            this.initContextMenu();

            //다른 프로그램에서 넘어온 병리번호가 있는경우
            if (!string.IsNullOrEmpty(this.receivedPtono))
            {
                if (receivedPtono.Length >= 8)
                {
                    string alpha = "";
                    string number = "";
                    for (int i = 0; i < receivedPtono.Length; i++)
                    {
                        string value = receivedPtono.ElementAt(i).ToString();

                        if (value.ToIntOrNull() == null)
                        {
                            //문자
                            if (i == 0 || i == 1)
                            {
                                alpha = alpha + value.ToString();
                            }

                        }
                        else
                        {
                            //숫자
                            number = number + value;
                        }
                    }

                    //넘어온 병리번호가 있으면..
                    if (!string.IsNullOrEmpty(alpha) && !string.IsNullOrEmpty(number) && number.Length >= 7)
                    {
                        cmbChar.SedasSelectedText = alpha;
                        if (g_OthersSetupData.nCipher == 0)
                        {
                            //4자리
                            txtYear.Text = number.Substring(0, 4);
                            txtPtoNo.Text = number.Substring(4, number.Length - 4);

                        }
                        else
                        {
                            //2자리
                            txtYear.Text = number.Substring(0, 2);
                            txtPtoNo.Text = number.Substring(2, number.Length - 2);
                        }

                        this.SearchData();
                    }

                }

            }


            this.txtPtNo.Focus(); //최초 포커스는 등록번호로..
        }


        /// <summary>
        /// name         : InitGlobalData
        /// desc         : 글로벌 변수 설정
        /// author       : 심우종
        /// create date  : 2020-03-26 14:48
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitGlobalData()
        {
            g_PathData.strIniPath = System.Environment.CurrentDirectory + "\\IniFiles\\setup.ini";
            g_PathData.strIniCombo = System.Environment.CurrentDirectory + "\\IniFiles\\combo.ini";
            g_PathData.strQueryPath = System.Environment.CurrentDirectory + "\\Querys\\";
            g_PathData.strPaintPath = System.Environment.CurrentDirectory + "\\IniFiles\\Paint.ini";
            g_PathData.strExcelPath = System.Environment.CurrentDirectory + "\\excel\\";
            g_PathData.strMappingPath = System.Environment.CurrentDirectory + "\\IniFiles\\mapping.ini";
            g_PathData.strBackGroundImagePath = System.Environment.CurrentDirectory + "\\Background\\";
            g_PathData.strImageButtonPath = System.Environment.CurrentDirectory + "\\Background\\";
            g_PathData.strTempImagePath = System.Environment.CurrentDirectory + "\\tempimage\\";

            //Global.G_IniReadValue("Image_Option", "Printer_FolderPath", Global.strinipath);

            string tempValue = "";

            //======================================
            //setup.ini  [DB]
            //======================================
            // DGS
            g_DBconnectData.strDGSDsn = Global.G_IniReadValue("DB", "DGSDSN", g_PathData.strIniPath);
            g_DBconnectData.strDGSUser = Global.G_IniReadValue("DB", "DGSUSER", g_PathData.strIniPath);
            g_DBconnectData.strDGSPasswd = Global.G_IniReadValue("DB", "DGSPASSWD", g_PathData.strIniPath);
            g_DBconnectData.strDGSConnectionString = Global.G_IniReadValue("DB", "DGSConnectionString", g_PathData.strIniPath);

            g_DBconnectData.strDGSConnectionString = Global.G_IniReadValue("DB", "CallService", g_PathData.strIniPath);

            // OCS
            g_DBconnectData.strOCSDsn = Global.G_IniReadValue("DB", "OCSDSN", g_PathData.strIniPath);
            g_DBconnectData.strOCSUser = Global.G_IniReadValue("DB", "OCSUSER", g_PathData.strIniPath);
            g_DBconnectData.strOCSPasswd = Global.G_IniReadValue("DB", "OCSPASSWD", g_PathData.strIniPath);
            g_DBconnectData.strOCSConnectionString = Global.G_IniReadValue("DB", "OCSConnectionString", g_PathData.strIniPath);

            g_DBconnectData.strCallService = Global.G_IniReadValue("DB", "CallService", g_PathData.strIniPath);
            g_DBconnectData.strIsDev = Global.G_IniReadValue("DB", "IsDev", g_PathData.strIniPath);

            tempValue = Global.G_IniReadValue("DB", "OCS", g_PathData.strIniPath);
            if (tempValue == "1")
            {
                g_DBconnectData.bOCS = true;
            }
            else
            {
                g_DBconnectData.bOCS = false;
            }

            //======================================
            //setup.ini  [OTHERS]
            //======================================
            g_OthersSetupData.nUIMode = int.Parse(Global.G_IniReadValue("OTHERS", "UIMODE", g_PathData.strIniPath));
            g_OthersSetupData.nCipher = int.Parse(Global.G_IniReadValue("OTHERS", "CIPHER", g_PathData.strIniPath));
            g_OthersSetupData.nImageSize = int.Parse(Global.G_IniReadValue("OTHERS", "IMAGESIZE", g_PathData.strIniPath));

            g_OthersSetupData.sortOption = Global.G_IniReadValue("OTHERS", "SORT", g_PathData.strIniPath);
            g_OthersSetupData.periodType = Global.G_IniReadValue("OTHERS", "PERIOD_TYPE", g_PathData.strIniPath);
            g_OthersSetupData.onlyMapping = Global.G_IniReadValue("OTHERS", "ONLY_MAPPING", g_PathData.strIniPath);

            string strPeriod = Global.G_IniReadValue("OTHERS", "PERIOD", g_PathData.strIniPath);
            if (!string.IsNullOrEmpty(strPeriod) && strPeriod.ToIntOrNull() != null)
            {
                g_OthersSetupData.nPeriod = strPeriod.ToInt();
            }
            else
            {
                g_OthersSetupData.nPeriod = 7;  //default 7일
            }



            tempValue = Global.G_IniReadValue("OTHERS", "ADDHYPEN", g_PathData.strIniPath);
            if (tempValue == "1")
                g_OthersSetupData.bAddHypen = true;
            else
                g_OthersSetupData.bAddHypen = false;

            tempValue = Global.G_IniReadValue("OTHERS", "SHOWPATHOLOGY", g_PathData.strIniPath);
            if (tempValue == "1")
                g_OthersSetupData.bShowPathology = true;
            else
                g_OthersSetupData.bShowPathology = false;

            tempValue = Global.G_IniReadValue("OTHERS", "SEARCHNOTDICOM", g_PathData.strIniPath);
            if (tempValue == "1")
                g_OthersSetupData.bNotSendDicom = true;
            else
                g_OthersSetupData.bNotSendDicom = false;


            g_OthersSetupData.SearchType = Global.G_IniReadValue("OTHERS", "SEARCHTYPE", g_PathData.strIniPath);
            g_OthersSetupData.ptonoType = Global.G_IniReadValue("OTHERS", "PTONO_TYPE", g_PathData.strIniPath);


            //======================================
            //setup.ini  [PATH]
            //======================================
            g_PathData.strImagePath = Global.G_IniReadValue("PATH", "IMAGE", g_PathData.strIniPath);
            g_PathData.strServerIP = Global.G_IniReadValue("PATH", "SERVERIP", g_PathData.strIniPath);
            g_PathData.strPhotoshopPath = Global.G_IniReadValue("PATH", "PROGRAM", g_PathData.strIniPath);


            //======================================
            //setup.ini  [LIST]
            //======================================
            g_ListData.strCount = Global.G_IniReadValue("LIST", "COUNT", g_PathData.strIniPath);

            int iCount = 0;
            if (g_ListData.strCount.ToIntOrNull() != null)
            {
                iCount = g_ListData.strCount.ToInt();
            }

            string listName = "";
            string listLength = "";
            g_ListData.strarrayListName.Clear();
            g_ListData.strarrayListLength.Clear();
            for (int i = 0; i < iCount; i++)
            {
                listName = "NAME" + (i + 1).ToString();
                listLength = "LENGTH" + (i + 1).ToString();

                string strName = Global.G_IniReadValue("LIST", listName, g_PathData.strIniPath);
                g_ListData.strarrayListName.Add(strName);
                g_ListData.strarrayListNumber.Add(strName.Substring(0, 2));

                string strLength = Global.G_IniReadValue("LIST", listLength, g_PathData.strIniPath);
                g_ListData.strarrayListLength.Add(strLength);
            }


            //======================================
            //combo.ini  [CHAR]
            //======================================
            g_ComboData.strarrayChar.Clear();
            g_ComboData.strCharCount = Global.G_IniReadValue("CHAR", "COUNT", g_PathData.strIniCombo);

            iCount = 0;
            if (g_ComboData.strCharCount.ToIntOrNull() != null)
            {
                iCount = g_ComboData.strCharCount.ToInt();
            }

            for (int i = 0; i < iCount; i++)
            {
                string listCount = "COUNT" + (i + 1).ToString();
                string strChar = Global.G_IniReadValue("CHAR", listCount, g_PathData.strIniCombo);
                g_ComboData.strarrayChar.Add(strChar);
            }

            //======================================
            //combo.ini  [WEEK]
            //======================================
            g_ComboData.strarrayWeek.Clear();
            g_ComboData.strWeekCount = Global.G_IniReadValue("WEEK", "COUNT", g_PathData.strIniCombo);

            iCount = 0;
            if (g_ComboData.strWeekCount.ToIntOrNull() != null)
            {
                iCount = g_ComboData.strWeekCount.ToInt();
            }

            for (int i = 0; i < iCount; i++)
            {
                string listCount = "COUNT" + (i + 1).ToString();
                string strWeek = Global.G_IniReadValue("WEEK", listCount, g_PathData.strIniCombo);
                g_ComboData.strarrayWeek.Add(strWeek);
            }

            //======================================
            //mapping.ini  [OP]
            //======================================
            tempValue = Global.G_IniReadValue("OP", "BLUE", g_PathData.strMappingPath);
            if (tempValue.ToIntOrNull() != null)
            {
                g_MappingData.nBlue = tempValue.ToInt();
            }

            tempValue = Global.G_IniReadValue("OP", "BI", g_PathData.strMappingPath);
            if (tempValue.ToDoubleOrNull() != null)
            {
                g_MappingData.dbBi = tempValue.ToDouble();
            }

            tempValue = Global.G_IniReadValue("OP", "HORIZONTAL", g_PathData.strMappingPath);
            if (tempValue.ToDoubleOrNull() != null)
            {
                g_MappingData.dbHorizontal = tempValue.ToDouble();
            }

            tempValue = Global.G_IniReadValue("OP", "VERTICAL", g_PathData.strMappingPath);
            if (tempValue.ToDoubleOrNull() != null)
            {
                g_MappingData.dbVertical = tempValue.ToDouble();
            }

            tempValue = Global.G_IniReadValue("OP", "GRID", g_PathData.strMappingPath);
            if (tempValue.ToIntOrNull() != null)
            {
                g_MappingData.nGridOnOffMode = tempValue.ToInt();
            }

            tempValue = Global.G_IniReadValue("OP", "BLACK", g_PathData.strMappingPath);
            if (tempValue.ToIntOrNull() != null)
            {
                g_MappingData.nBlackMode = tempValue.ToInt();
            }

            tempValue = Global.G_IniReadValue("OP", "COLOR", g_PathData.strMappingPath);
            if (tempValue.ToIntOrNull() != null)
            {
                g_MappingData.nColorMode = tempValue.ToInt();
            }

            tempValue = Global.G_IniReadValue("OP", "SIZE", g_PathData.strMappingPath);
            if (tempValue.ToIntOrNull() != null)
            {
                g_MappingData.nSizeMode = tempValue.ToInt();
            }

            string red = Global.G_IniReadValue("OP", "RGNR", g_PathData.strMappingPath);
            string green = Global.G_IniReadValue("OP", "RGNG", g_PathData.strMappingPath);
            string blue = Global.G_IniReadValue("OP", "RGNB", g_PathData.strMappingPath);

            if (red.ToIntOrNull() != null && green.ToIntOrNull() != null && blue.ToIntOrNull() != null)
            {
                g_MappingData.rgnColor = Color.FromArgb(red.ToInt(), green.ToInt(), blue.ToInt());
            }


        }

        DataTable commonCode_pathologyType;
        DataTable commonCode_period; //기간 콤보박스 구성 데이터






        private void ComboBoxBinding()
        {
            List<CommonCodeDTO> commonCodeList = new List<CommonCodeDTO>();

            string[] pathologyType = { "S", "C", "AC", "F", "M", "*" };


            DataTable dt = new DataTable();
            dt.Columns.Add("cdVal");
            dt.Columns.Add("cdValNm");



            for (int i = 0; i < pathologyType.Length; i++)
            {
                //CommonCodeDTO dto = new CommonCodeDTO();
                //dto.CdVal = pathologyType[i].ToString();
                //dto.CdValNm = pathologyType[i].ToString();

                //commonCodeList.Add(dto);

                DataRow row = dt.NewRow();
                row["cdVal"] = pathologyType[i].ToString();
                row["cdValNm"] = pathologyType[i].ToString();
                dt.Rows.Add(row);
            }



            cmbChar.DataBindingFromDataTable(dt, "cdVal", "cdValNm");


            //commonCodeList.ToList().ForEach(item =>
            //{

            //    ImageComboBoxItem imageComboBoxItem = new ImageComboBoxItem();
            //    imageComboBoxItem.Value = item.CdVal.ToString();
            //    imageComboBoxItem.Description = item.CdValNm.ToString();
            //    imageComboBoxEdit1.Properties.Items.Add(imageComboBoxItem);
            //});



        }



        /// <summary>
        /// 컨트롤 초기화
        /// </summary>
        private void InitControls()
        {
            //병리번호 콤보박스 데이터
            DataTable dt = new DataTable();
            dt.Columns.Add("cdVal");
            dt.Columns.Add("cdValNm");

            if (g_ComboData.strCharCount.ToIntOrNull() != null)
            {
                for (int i = 0; i < g_ComboData.strCharCount.ToInt(); i++)
                {
                    if (g_ComboData.strarrayChar.Count > i)
                    {
                        DataRow row = dt.NewRow();
                        row["cdVal"] = g_ComboData.strarrayChar[i].ToString();
                        row["cdValNm"] = g_ComboData.strarrayChar[i].ToString();
                        dt.Rows.Add(row);
                    }
                }
            }

            commonCode_pathologyType = dt;
            cmbChar.DataBindingFromDataTable(dt, "cdVal", "cdValNm");

            if (cmbChar.Properties.Items.Count > 0)
            {
                cmbChar.SelectedIndex = 0;
            }



            //기간검색 콤보박스 데이터
            this.InitCmbWeek();

            //전송상태 콤보박스 데이터
            this.InitCmbSendStat();

            DateTime current = DateTime.Now;

            DateTime startDt = current.AddDays(g_OthersSetupData.nPeriod * -1);

            this.dtpStart.EditValue = startDt;
            this.dtpEnd.EditValue = current;
            this.dtpStart.Enabled = false;
            this.dtpEnd.Enabled = false;

            //당일로 체크한 경우 자동으로 기간 선택되도록 전사실 요청 2020-11-17
            if (g_OthersSetupData.nPeriod == 0)
            {
                this.chkStDt.Checked = true;
                this.chkEdDt.Checked = true;
            }

            //그리드 컨트롤 초기값 설정
            this.InitGridControl();

            DateTime date = DateTime.Now;
            if (g_OthersSetupData.nCipher == 0)
            {
                //4자리
                txtYear.Text = date.ToString("yyyy");

            }
            else
            {
                //2자리
                txtYear.Text = date.ToString("yyyy").Substring(2, 2);
            }

            //병리번호 시작 문자열..
            if (!string.IsNullOrEmpty(g_OthersSetupData.ptonoType))
            {
                this.cmbChar.SedasSelectedText = g_OthersSetupData.ptonoType;
            }


            //[이미지 판넬 위치, 사이즈 설정]
            if (g_OthersSetupData.nUIMode == 0)
            {
                //LEFT
                this.xtraScrollableControl1.Dock = DockStyle.Left;
                this.flwpnlImage.FlowDirection = FlowDirection.TopDown;
                //this.flwpnlImage.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;

                if (g_OthersSetupData.nImageSize == 0)
                {
                    //크게
                    this.flwpnlImage.Width = imageSize_BigWidth + 25;
                    this.xtraScrollableControl1.Width = imageSize_BigWidth + 25;
                }
                else if (g_OthersSetupData.nImageSize == 1)
                {
                    //작게
                    this.flwpnlImage.Width = imageSize_smallWidth + 25;
                    this.xtraScrollableControl1.Width = imageSize_smallWidth + 25;
                }
            }
            else if (g_OthersSetupData.nUIMode == 1)
            {
                //RIGHT
                //this.flwpnlImage.Dock = DockStyle.Right;
                xtraScrollableControl1.Dock = DockStyle.Right;
                this.flwpnlImage.FlowDirection = FlowDirection.TopDown;
                //this.flwpnlImage.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.TopDown;
                this.flwpnlImage.Width = 230;

                if (g_OthersSetupData.nImageSize == 0)
                {
                    //크게
                    this.flwpnlImage.Width = imageSize_BigWidth + 25;
                    this.xtraScrollableControl1.Width = imageSize_BigWidth + 25;
                }
                else if (g_OthersSetupData.nImageSize == 1)
                {
                    //작게
                    this.flwpnlImage.Width = imageSize_smallWidth + 25;
                    this.xtraScrollableControl1.Width = imageSize_smallWidth + 25;
                }
            }
            else if (g_OthersSetupData.nUIMode == 2)
            {
                //TOP
                this.xtraScrollableControl1.Dock = DockStyle.Top;
                this.flwpnlImage.FlowDirection = FlowDirection.LeftToRight;
                //this.flwpnlImage.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.LeftToRight;

                if (g_OthersSetupData.nImageSize == 0)
                {
                    //크게
                    this.flwpnlImage.Height = imageSize_BigHeight + 25;
                    this.xtraScrollableControl1.Height = imageSize_BigHeight + 25;
                }
                else if (g_OthersSetupData.nImageSize == 1)
                {
                    //작게
                    this.flwpnlImage.Height = imageSize_smallHeight + 25;
                    this.xtraScrollableControl1.Height = imageSize_smallHeight + 25;
                }
            }
            else if (g_OthersSetupData.nUIMode == 3)
            {
                //BOTTOM
                this.xtraScrollableControl1.Dock = DockStyle.Bottom;
                this.flwpnlImage.FlowDirection = FlowDirection.LeftToRight;
                //this.flwpnlImage.LayoutDirection = DevExpress.Utils.Layout.StackPanelLayoutDirection.LeftToRight;
                this.flwpnlImage.Height = 200;

                if (g_OthersSetupData.nImageSize == 0)
                {
                    //크게
                    this.flwpnlImage.Height = imageSize_BigHeight + 25;
                    this.xtraScrollableControl1.Height = imageSize_BigHeight + 25;
                }
                else if (g_OthersSetupData.nImageSize == 1)
                {
                    //작게
                    this.flwpnlImage.Height = imageSize_smallHeight + 25;
                    this.xtraScrollableControl1.Height = imageSize_smallHeight + 25;
                }
            }

            if (this.beforeImageSize != g_OthersSetupData.nImageSize
                || this.beforeUiMode != g_OthersSetupData.nUIMode)
            {
                this.beforeImageSize = g_OthersSetupData.nImageSize;
                this.beforeUiMode = g_OthersSetupData.nUIMode;

                if (this.flwpnlImage.Controls.Count > 0)
                {
                    //이미지 초기화
                    this.flwpnlImage.Controls.Clear();
                }
            }

            if (g_OthersSetupData.periodType == "last")
            {
                lblPeriod.Text = "기간검색 (마지막 수정일 기준)";
            }
            else
            {
                lblPeriod.Text = "기간검색";
            }

        }



        /// <summary>
        /// name         : InitCmbSendStat
        /// desc         : 전송상태 콤보 초기화
        /// author       : 심우종
        /// create date  : 2020-10-19 13:51
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitCmbSendStat()
        {
            //전송상태 콤보박스 데이터
            DataTable dt = new DataTable();
            dt.Columns.Add("cdVal");
            dt.Columns.Add("cdValNm");

            String[] statMaster = { "", "0", "1", "2", "8", "9" };
            String[] statMasterDesc = { "", "미전송", "전송완료", "전송실패", "전송대기", "전송중" };
            for (int i = 0; i < statMaster.Count(); i++)
            {
                if (g_ComboData.strarrayChar.Count > i)
                {
                    DataRow row = dt.NewRow();
                    row["cdVal"] = statMaster.ElementAt(i).ToString();
                    row["cdValNm"] = statMasterDesc.ElementAt(i).ToString();
                    dt.Rows.Add(row);
                }
            }

            this.cmbSendStat.DataBindingFromDataTable(dt, "cdVal", "cdValNm");
        }

        /// <summary>
        /// name         : InitCmbWeek
        /// desc         : 기간검색 콤보 데이터 초기화
        /// author       : 심우종
        /// create date  : 2020-04-21 14:03
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitCmbWeek(bool isNeedToPeriod = false)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("cdVal");
            dt.Columns.Add("cdValNm");

            if (g_ComboData.strWeekCount.ToIntOrNull() != null)
            {
                for (int i = 0; i < g_ComboData.strWeekCount.ToInt(); i++)
                {
                    if (g_ComboData.strarrayWeek.Count > i)
                    {
                        string[] splitData = g_ComboData.strarrayWeek[i].Split('.');
                        if (splitData.Length == 2)
                        {
                            DataRow row = dt.NewRow();
                            row["cdVal"] = splitData[0].ToString();
                            row["cdValNm"] = splitData[1].ToString();
                            dt.Rows.Add(row);
                        }

                    }
                }
            }

            if (isNeedToPeriod == true)
            {
                DataRow row = dt.NewRow();
                row["cdVal"] = "-002";
                row["cdValNm"] = "기간검색";
                dt.Rows.Add(row);
            }


            this.commonCode_period = dt;

            cmbWeek.DataBindingFromDataTable(dt, "cdVal", "cdValNm");

            if (cmbWeek.Properties.Items.Count > 0)
            {
                cmbWeek.SelectedIndex = 0;
            }
        }




        /// <summary>
        /// name         : InitGridControl
        /// desc         : 그리드컨트롤 초기값 설정
        /// author       : 심우종
        /// create date  : 2020-03-30 15:48
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitGridControl()
        {
            this.grvOrder.Columns.Clear();
            //this.grvOrder.Columns

            if (g_ListData.strCount.ToIntOrNull() != null)
            {
                int lastIndex = 0;
                for (int i = 0; i < g_ListData.strCount.ToInt(); i++)
                {
                    if (g_ListData.strarrayListName.Count > i
                        && g_ListData.strarrayListLength.Count > i)
                    {

                        string[] captionSplite = g_ListData.strarrayListName[i].Split('.');

                        string codeValue = "";
                        string caption = "";
                        if (captionSplite.Count() >= 2)
                        {
                            codeValue = "Data" + captionSplite[0].ToString();
                            caption = captionSplite[1].ToString();
                        }
                        else
                        {
                            codeValue = "NoData" + i.ToString();
                            caption = g_ListData.strarrayListName[i].ToString();
                        }

                        //컬럼 생성
                        Sedas.Control.GridControl.HGridColumn gridColumn = GetGridColumn(caption, codeValue, "grdColumn" + (i + 1).ToString(), codeValue, i);


                        //Sedas.Control.GridControl.HGridColumn gridColumn = new Sedas.Control.GridControl.HGridColumn();
                        //gridColumn.AppearanceCell.Options.UseTextOptions = true;
                        //gridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //gridColumn.AppearanceCell.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                        //gridColumn.AppearanceCell.Options.UseFont = true;
                        //gridColumn.AppearanceHeader.Options.UseTextOptions = true;
                        //gridColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                        //gridColumn.AppearanceHeader.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
                        //gridColumn.AppearanceHeader.Options.UseFont = true;
                        //gridColumn.Caption = caption;
                        //gridColumn.FieldName = codeValue; // "Data" + (i + 1).ToString();
                        //gridColumn.Name = "grdColumn" + (i + 1).ToString();
                        //gridColumn.OptionsColumn.AllowEdit = false;
                        //gridColumn.Visible = true;
                        //gridColumn.VisibleIndex = i;
                        //gridColumn.Width = 64;
                        //gridColumn.Tag = codeValue;
                        //gridColumn.OptionsColumn.FixedWidth = true;
                        //gridColumn.MinWidth = 0;
                        //gridColumn.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
                        //gridColumn.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
                        //gridColumn.AppearanceHeader.Options.UseBackColor = true;
                        //gridColumn.AppearanceHeader.Options.UseForeColor = true;



                        int width = 100;
                        if (g_ListData.strarrayListLength[i].ToIntOrNull() != null)
                        {
                            width = g_ListData.strarrayListLength[i].ToInt();
                        }

                        gridColumn.Width = width;



                        grvOrder.Columns.Add(gridColumn);

                    }


                    lastIndex = i;
                }

                //마지막 수정시간 컬럼 필요..
                Sedas.Control.GridControl.HGridColumn lastDtColumn = GetGridColumn("마지막 수정일자", "lastUpdtDtDisplay", "lastUpdtDtColumn", "", lastIndex++);
                lastDtColumn.Width = 120;
                grvOrder.Columns.Add(lastDtColumn);

            }

            grdOrder.Dock = DockStyle.None;
            grdOrder.Dock = DockStyle.Fill;

        }

        private Sedas.Control.GridControl.HGridColumn GetGridColumn(string caption, string fieldName, string name, string tag, int visibleIndex)
        {
            Sedas.Control.GridControl.HGridColumn gridColumn = new Sedas.Control.GridControl.HGridColumn();
            gridColumn.AppearanceCell.Options.UseTextOptions = true;
            gridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn.AppearanceCell.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            gridColumn.AppearanceCell.Options.UseFont = true;
            gridColumn.AppearanceHeader.Options.UseTextOptions = true;
            gridColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            gridColumn.AppearanceHeader.Font = new System.Drawing.Font("굴림", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            gridColumn.AppearanceHeader.Options.UseFont = true;
            gridColumn.Caption = caption;
            gridColumn.FieldName = fieldName; // "Data" + (i + 1).ToString();
            gridColumn.Name = name;
            gridColumn.OptionsColumn.AllowEdit = false;
            gridColumn.Visible = true;
            gridColumn.VisibleIndex = visibleIndex;
            gridColumn.Width = 64;
            gridColumn.Tag = tag;
            gridColumn.OptionsColumn.FixedWidth = true;
            gridColumn.MinWidth = 0;
            gridColumn.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            gridColumn.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            gridColumn.AppearanceHeader.Options.UseBackColor = true;
            gridColumn.AppearanceHeader.Options.UseForeColor = true;

            return gridColumn;

        }




        /// <summary>
        /// name         : btnSearch_Click
        /// desc         : 조회 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-21 08:57
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //this.SelectOrder();
            //this.SelectDbTest();
            //this.SelectDbTest2();

            this.SearchData();
        }


        /// <summary>
        /// name         : SearchData
        /// desc         : 데이터를 조회한다.
        /// author       : 심우종
        /// create date  : 2020-04-21 08:58
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SearchData(string reSelectStudyId = "")
        {

            this.AllDeleteImage();
            this.deleteImage = new List<ImageButtonValue>(); //삭제처리를 위한 이미지 정보 클리어
            this.selectedItem = null;
            string searchType = "";


            if (g_OthersSetupData.bNotSendDicom == true)
            {
                searchType = "1";
            }
            else if (!string.IsNullOrEmpty(this.txtPtoNo.Text))
            {
                searchType = "2";
            }
            else
            {
                searchType = "3";
            }

            string ptoNo = this.formatingPtoNo(this.txtPtoNo.Text); //병리번호
            string ptNo = this.txtPtNo.Text.ToString();
            string ptNm = this.txtPtNm.Text.ToString();
            string specimen = this.txtSpecimen.Text.ToString();


            KeyValueData param = new KeyValueData();
            param.Add("Data0", searchType);

            if (searchType == "2")
            {
                param.Add("Data1", ptoNo);
            }
            else
            {
                if (!string.IsNullOrEmpty(ptoNo))
                {
                    param.Add("Data1", "%" + ptoNo + "%");
                }
            }


            if (!string.IsNullOrEmpty(ptNo))
            {
                param.Add("Data2", "%" + ptNo + "%");
            }

            if (!string.IsNullOrEmpty(ptNm))
            {
                param.Add("Data3", "%" + ptNm + "%");
            }

            if (!string.IsNullOrEmpty(specimen))
            {
                param.Add("Data4", "%" + specimen + "%");
            }

            //this.cmbWeek.selecte this.cmbWeek.SelectedIndex

            double weekValue = cmbWeek.Properties.Items[cmbWeek.SelectedIndex].Value.ToString().ToDouble();

            if (this.chkStDt.Checked == false && this.chkEdDt.Checked == false && weekValue > 0)
            {
                DateTime current = DateTime.Now;
                DateTime firstDt = current.AddDays(-weekValue);

                param.Add("Data5", firstDt.ToString("yyyyMMdd"));
                param.Add("Data6", current.ToString("yyyyMMdd"));
            }
            else
            {
                if (this.chkStDt.Checked == true)
                {
                    string startDt = dtpStart.DateTime.ToString("yyyyMMdd");
                    param.Add("Data5", startDt);
                }
                if (this.chkEdDt.Checked == true)
                {
                    string endDt = dtpEnd.DateTime.ToString("yyyyMMdd");
                    param.Add("Data6", endDt);
                }
            }
            //return;


            //CallResultData resultTest = this.callService.SelectSql("reqGetTestData", param);

            //if (resultTest.resultState == ResultState.OK)
            //{
            //    DataTable dt = resultTest.resultData;
            //}




            //return;
            if (g_OthersSetupData.periodType == "last")
            {
                param.Add("Data7", "last");
            }
            

            string sendStatOption = cmbSendStat.SedasSelectedValue;

            CallResultData result = this.callService.SelectSql("reqGetViewerData", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;

                if (dt != null && dt.Rows.Count > 0)
                {

                    if (g_OthersSetupData.sortOption == "insertDt")
                    {
                        DataView dv = dt.DefaultView;
                        dv.Sort = "insertDt desc, studyId desc";
                        dt = dv.ToTable();
                    }
                    else if ( g_OthersSetupData.sortOption == "lastDt")
                    {
                        if (dt.Columns.Contains("lastUpdtDt"))
                        {
                            DataView dv = dt.DefaultView;
                            dv.Sort = "lastUpdtDt desc, studyId desc";
                            dt = dv.ToTable();
                        }
                    }
                    else if (g_OthersSetupData.sortOption == "studyDt" || string.IsNullOrEmpty(g_OthersSetupData.sortOption))
                    {
                        //그대로
                    }
                    

                    StudyDataTable newDt = new StudyDataTable();

                    int count = 1;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        DataRow newRow = newDt.NewRow();
                        DataRow row = dt.Rows[i];

                        if (!string.IsNullOrEmpty(sendStatOption))
                        {
                            if (row["sendStat"].ToString() != sendStatOption)
                            {
                                continue;
                            }
                        }

                        //매핑 이미지가 있는 데이터만 조회
                        if (g_OthersSetupData.onlyMapping == "Y")
                        {
                            if (row.Table.Columns.Contains("mappingCount"))
                            {
                                string mappingCount = row["mappingCount"].ToString();

                                if (mappingCount.ToIntOrNull() != null && mappingCount.ToInt() == 0)
                                {
                                    continue;
                                }
                            } 
                        }

                        string gi = row["gi"].ToString();
                        string mi = row["mi"].ToString();
                        string oi = row["oi"].ToString();

                        bool isPass = false;
                        if (gi.ToIntOrNull() != null && gi.ToInt() > 0)
                        {
                            isPass = true;
                        }

                        if (mi.ToIntOrNull() != null && mi.ToInt() > 0)
                        {
                            isPass = true;
                        }

                        if (oi.ToIntOrNull() != null && oi.ToInt() > 0)
                        {
                            isPass = true;
                        }

                        if (isPass == false) continue;


                        this.coreLibrary.TableCopy(row, ref newRow);

                        //그리드에 보여주기위한 컬럼 매핑
                        newRow["Data00"] = count.ToString(); //row["studyId"].ToString();
                        newRow["Data01"] = row["ptoNo"].ToString();
                        newRow["Data02"] = row["gi"].ToString();
                        newRow["Data03"] = row["mi"].ToString();
                        newRow["Data04"] = row["oi"].ToString();

                        string sendStstNm = "";
                        if (row["sendStat"].ToString() == "0")
                        {
                            sendStstNm = "미전송";
                        }
                        else if (row["sendStat"].ToString() == "1")
                        {
                            sendStstNm = "전송완료";
                        }
                        else if (row["sendStat"].ToString() == "2")
                        {
                            sendStstNm = "전송실패";
                        }
                        else if (row["sendStat"].ToString() == "8")
                        {
                            sendStstNm = "전송대기";
                        }
                        else if (row["sendStat"].ToString() == "9")
                        {
                            sendStstNm = "전송중";
                        }

                        newRow["Data05"] = sendStstNm;
                        newRow["Data06"] = row["ptNo"].ToString();
                        newRow["Data07"] = row["ptNm"].ToString();
                        newRow["Data08"] = row["birth"].ToString();
                        newRow["Data09"] = row["age"].ToString();
                        newRow["Data10"] = row["sex"].ToString();
                        if (row["studyDt"].ToString().Length >= 8)
                        {
                            string studyDt = row["studyDt"].ToString().Substring(0, 4) + "-" + row["studyDt"].ToString().Substring(4, 2) + "-" + row["studyDt"].ToString().Substring(6, 2);
                            newRow["Data11"] = studyDt;

                        }
                        if (row["insertDt"].ToString().Length >= 8)
                        {
                            string insertDt = row["insertDt"].ToString().Substring(0, 4) + "-" + row["insertDt"].ToString().Substring(4, 2) + "-" + row["insertDt"].ToString().Substring(6, 2);
                            newRow["Data12"] = insertDt;
                        }


                        newRow["Data13"] = row["dstudy1"].ToString();
                        newRow["Data14"] = row["dstudy2"].ToString();
                        newRow["Data15"] = row["dstudy3"].ToString();
                        newRow["Data16"] = row["accessId"].ToString();
                        newRow["Data17"] = row["studyNm"].ToString();
                        newRow["Data18"] = row["uuId"].ToString();

                        if (row.Table.Columns.Contains("lastUpdtDt") && !string.IsNullOrEmpty(row["lastUpdtDt"].ToString()) && row["lastUpdtDt"].ToString().Length >= 8)
                        {
                            newRow["lastUpdtDtDisplay"] = row["lastUpdtDt"].ToString().Substring(0, 4) + "-" + row["lastUpdtDt"].ToString().Substring(4, 2) + "-" + row["lastUpdtDt"].ToString().Substring(6, 2);
                        }
                        




                        newDt.Rows.Add(newRow);
                        count++;
                    }









                    grdOrder.DataSource = newDt;

                    foreach (GridColumn column in grvOrder.Columns)
                    {
                        column.SortOrder = DevExpress.Data.ColumnSortOrder.None;
                    }

                    this.SetMessage("검색된 건수 : " + newDt.Rows.Count.ToString() + "건");
                }
                else
                {
                    //조회결과가 없음.
                    StudyDataTable newDt = new StudyDataTable();
                    grdOrder.DataSource = newDt;

                    this.SetMessage("검색된 데이터가 없습니다.");
                }
            }
            else
            {
                //실패에 대한 처리
                Global.logHelper.WriteLog("viewerSelect", LogType.ERROR, ActionType.ACTION, "Viewer 조회 실패", "Viewer 조회시 DB에서 발생", ptoNo: ptoNo);
            }


            if (string.IsNullOrEmpty(reSelectStudyId))
            {
                if (grdOrder.DataSource != null)
                {
                    DataTable dt = grdOrder.DataSource as DataTable;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        if (dt.Rows.Count == 1)
                        {
                            reSelectStudyId = dt.Rows[0]["studyId"].ToString();
                        }
                    }
                }
            }



            if (!string.IsNullOrEmpty(reSelectStudyId))
            {
                //재조회 후 stidyId에 해당하는 컬럼 자동 포커스
                DataView dv = grvOrder.DataSource as DataView;
                DataRow row = dv.Table.AsEnumerable().Where(o => o["studyId"].ToString() == reSelectStudyId).FirstOrDefault();

                if (row != null)
                {
                    int index = dv.Table.Rows.IndexOf(row);

                    this.grvOrder.ClearSelection();
                    this.grvOrder.FocusedRowHandle = index;
                    this.grvOrder.SelectRows(index, index);

                    this.ShowImages(reSelectStudyId, row);
                    this.selectedItem = row;
                    this.SetMessage("선택된 데이터 : " + row["ptoNo"].ToString(), headerMessage: row["ptoNo"].ToString());
                }
            }
        }


        /// <summary>
        /// name         : SetMessage
        /// desc         : 메시지를 설정한다.
        /// author       : 심우종
        /// create date  : 2020-04-24 10:45
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SetMessage(string message, string headerMessage = "")
        {
            this.lblMessage.Text = message;
            if (string.IsNullOrEmpty(headerMessage))
            {
                this.Text = "DIS Viewer : " + message;
            }
            else
            {
                this.Text = "DIS Viewer : " + headerMessage;
            }


        }


        /// <summary>
        /// name         : formatingPtoNo
        /// desc         : 병리번호 검색 string 포멧 리턴
        /// author       : 심우종
        /// create date  : 2020-04-21 10:43
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private string formatingPtoNo(string ptoNo)
        {

            string returnValue = "";
            string prefix = cmbChar.SelectedItem.ToString();

            if (string.IsNullOrEmpty(ptoNo))
            {
                if (prefix == "*" || prefix == "")
                {
                    returnValue = this.txtYear.Text;
                }
                else
                {
                    returnValue = prefix + this.txtYear.Text;
                }
            }
            else
            {
                if (ptoNo.ToIntOrNull() != null)
                {
                    returnValue = prefix + this.txtYear.Text + ptoNo.ToInt().ToString("00000");
                }
            }

            return returnValue;
        }


        //private void SelectDbTest2()
        //{
        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("num");
        //    dt.Columns.Add("dd");
        //    dt.Columns.Add("icu");

        //    DataRow row = dt.NewRow();
        //    row["num"] = "data1";
        //    row["dd"] = "data1";
        //    row["icu"] = "i";
        //    dt.Rows.Add(row);

        //    DataRow row2 = dt.NewRow();
        //    row2["num"] = "data2";
        //    row2["dd"] = "data2";
        //    row2["icu"] = "i";
        //    dt.Rows.Add(row2);

        //    DataRow row3 = dt.NewRow();
        //    row3["num"] = "data3";
        //    row3["dd"] = "data3";
        //    row3["icu"] = "i";
        //    dt.Rows.Add(row3);

        //    DataRow row4 = dt.NewRow();
        //    row4["num"] = "data4";
        //    row4["dd"] = "data5";
        //    row4["icu"] = "d";
        //    dt.Rows.Add(row4);

        //    //niud_Column : i, u, d 구분값이 들어갈 컬럼명 지정, 지정하지 않을 경우 i로 설정됨
        //    string tempValue = dt.DataTableToStringForServer(niud_Column: "icu");


        //    KeyValueData param = new KeyValueData();
        //    param.Add("Data1", "16797637");
        //    param.Add("Data2", "한글테스트");
        //    param.Add("Data4", tempValue);

        //    CallResultData result = this.callService.SelectSql("reqGetComPatientInfoSwj", param);


        //}


        /// <summary>
        /// name         : DataTableToStringForServer
        /// desc         : 서버에 전달하기위한 DataTable을 String으로 파싱 처리
        /// author       : 심우종
        /// create date  : 2020-04-13 16:53
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private string DataTableToStringForServer(DataTable dt, string niud_Column = "")
        {
            /*
             * 넘어가야 하는 데이터 구조 프로토콜 형태 첫 라인의 niud값 필수
            m▦num▦day▦dd▦iud▩
            i▦data1▦data2▦data3▦i▩
            i▦data4▦data5▦data6▦i▩
            u▦data7▦data8▦data9▦i▩
            d▦data10▦data11▦data12▦i▩
             */
            StringBuilder str = new StringBuilder();

            str.Append("m▦");

            //1. 해더 구조 만들기
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string columnName = dt.Columns[i].ColumnName;

                if (i != dt.Columns.Count - 1)
                {
                    str.Append(columnName + "▦");
                }
                else
                {
                    //해당 row의 마지막은 ▩표시로..
                    str.Append(columnName + "▩");
                }
            }

            //2. 바디 구조 만들기
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];

                //2.1 NIUD 값 설정
                if (!string.IsNullOrEmpty(niud_Column))
                {
                    str.Append(row["niud_Column"].ToString().ToLower() + "▦");
                }
                else
                {
                    //niud컬럼 지정되지 않으면 무조건 i로 설정함.
                    str.Append("i" + "▦");
                }

                //2.2 row데이터 복사
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string value = row[dt.Columns[j].ColumnName.ToString()].ToString();

                    if (j != dt.Columns.Count - 1)
                    {
                        str.Append(value + "▦");
                    }
                    else
                    {
                        //해당 row의 마지막은 ▩표시로..
                        str.Append(value + "▩");
                    }
                }
            }

            return str.ToString();
        }

        /// <summary>
        /// .DB테스트!!!!!!
        /// </summary>
        //private void SelectDbTest()
        //{
        //    //DataTable dt = initDataTable();

        //    List<OrderDTO> orderList = new List<OrderDTO>();

        //    this.initTempData(orderList);


        //    KeyValueData param = new KeyValueData();
        //    param.Add("Data1", "16797637");

        //    CallResultData result = this.callService.SelectSql("reqGetComPatientInfoSwj", param);

        //    if (result.resultState == ResultState.OK)
        //    {
        //        //데이터 조회 성공
        //        DataTable dt = result.resultData;
        //    }
        //    else
        //    {
        //        //실패에 대한 처리
        //    }


        //    return;


        //    //방법 1
        //    //XElement element = XElement.Parse(responseFromServer);
        //    //IEnumerable<XElement> eleList = element.Element("info").Elements();

        //    //if (eleList.Count() > 0)
        //    //{
        //    //    foreac
        //    //}


        //    //방법 2 데이터 테이블로 반환
        //    //StringReader theReader = new StringReader(responseFromServer);
        //    //DataSet theDataSet = new DataSet();
        //    //theDataSet.ReadXml(theReader);
        //    //DataTable dt = theDataSet.Tables[0];

        //}


        ImageHelper imageHelper = new ImageHelper();

        private static DataTable CreateTestTable(string tableName)
        {
            // Create a test DataTable with two columns and a few rows.
            DataTable table = new DataTable(tableName);
            DataColumn column = new DataColumn("id", typeof(System.Int32));
            column.AutoIncrement = true;
            table.Columns.Add(column);

            column = new DataColumn("item", typeof(System.String));
            table.Columns.Add(column);

            // Add ten rows.
            DataRow row;
            for (int i = 0; i <= 9; i++)
            {
                row = table.NewRow();
                row["item"] = "item " + i;
                table.Rows.Add(row);
            }

            table.AcceptChanges();
            return table;
        }


        private Image stringToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        List<string> testList = new List<string>();


        /// <summary>
        /// 이미지를 추가한다.
        /// </summary>
        private async void ImageAdd(string filePath, bool isNewImage, ImageButtonValue imageButtonValue = null)
        {

            if (string.IsNullOrEmpty(filePath)) return;

            ImageContainer imageBox = new ImageContainer();
            if (imageButtonValue != null)
            {
                imageBox.ImageButtonValue = imageButtonValue;
            }

            if (isNewImage == true)
            {
                if (File.Exists(filePath) == false) return;

                if (!string.IsNullOrEmpty(filePath))
                {

                    Image image = imageHelper.SaveToThumbnailImage(filePath);


                    string strBmp = filePath;

                    //FileStream fs;
                    //fs = new FileStream(strBmp, FileMode.Open, FileAccess.Read);
                    //Image image = System.Drawing.Image.FromStream(fs);
                    imageBox.SetImage(image, strBmp);

                    //fs.Close();
                }
            }
            else
            {
                string savedFileName = "";
                if (ft.FileDownLoad(filePath, Global.tempFolder, ref savedFileName) == true)
                {
                    //strLocalFilePath
                }

                if (string.IsNullOrEmpty(savedFileName)) return;


                if (imageButtonValue != null)
                {
                    imageButtonValue.strRowFilePath = savedFileName;
                }

                string strBmp = savedFileName;

                //FileStream fs;
                //fs = new FileStream(strBmp, FileMode.Open, FileAccess.Read);
                //Image image = System.Drawing.Image.FromStream(fs);


                Image image = imageHelper.SaveToThumbnailImage(savedFileName);
                imageBox.SetImage(image, strBmp);


                //fs.Close();
            }


            //if (this.flwpnlImage.FlowDirection == FlowDirection.LeftToRight)
            //{
            //    imageBox.Height = 180;
            //    imageBox.Width = 210;
            //}
            //else if (this.flwpnlImage.FlowDirection == FlowDirection.TopDown)
            //{
            //    imageBox.Height = 180;
            //    imageBox.Width = 210;
            //}



            imageBox.Click += ImageBox_Click;
            //imageBox.MouseClick += ImageBox_MouseClick;
            imageBox.onImageSelected += ImageBox_onImageSelected1;
            imageBox.onImageDoubleClick += ImageBox_onImageDoubleClick;
            //flwpnlImage.SuspendLayout();
            flwpnlImage.SuspendLayout();
            imageBox.SuspendLayout();
            //imageBox.SuspendLayout();
            flwpnlImage.Controls.Add(imageBox);


            //판넬에 넣고 나서 사이즈가 변경되는 현상떄문에 뒤로 옮김.
            if (g_OthersSetupData.nImageSize == 0)
            {
                //이미지 크게
                imageBox.Height = imageSize_BigHeight; //180
                imageBox.Width = imageSize_BigWidth; // 210;

            }
            else if (g_OthersSetupData.nImageSize == 1)
            {
                //이미지 작게
                imageBox.Height = imageSize_smallHeight; // 90;
                imageBox.Width = imageSize_smallWidth; // 100;
            }

            flwpnlImage.Update();

            flwpnlImage.ResumeLayout();
            imageBox.ResumeLayout();
            //imageBox.ResumeLayout();
            //flwpnlImage.BeginInit();


        }


        /// <summary>
        /// name         : ImageBox_onImageDoubleClick
        /// desc         : 이미지 더블클릭시
        /// author       : 심우종
        /// create date  : 2020-04-03 11:30
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ImageBox_onImageDoubleClick(ImageContainer arg1, string arg2)
        {
            if (this.selectedItem == null)
            {
                return;
            }

            //화면에 보이는 이미지 리스트 전체
            List<ImageContainer> imageList = GetImageList();

            DataTable imageDt = new DataTable();
            imageDt.Columns.Add("fileName", typeof(string));
            imageDt.Columns.Add("imageType", typeof(string));
            imageDt.Columns.Add("imageNum", typeof(string));
            imageDt.Columns.Add("strCm", typeof(string));

            for (int i = 0; i < imageList.Count; i++)
            {
                ImageContainer image = imageList.ElementAt(i);
                if (image.ImageButtonValue != null)
                {
                    DataRow row = imageDt.NewRow();
                    row["fileName"] = image.ImageButtonValue.strRowFilePath;
                    row["imageType"] = image.ImageButtonValue.nType;
                    row["imageNum"] = image.ImageButtonValue.nImageNum.ToString();
                    row["strCm"] = image.ImageButtonValue.strCm.ToString();
                    imageDt.Rows.Add(row);
                }
            }


            //return;

            //string filePath = arg1.ImageButtonValue.strRowFilePath;
            string strImagePath = g_PathData.strImagePath;
            string strPathologyNum = this.selectedItem["ptoNo"].ToString();
            //string imageType = arg1.ImageButtonValue.nType.ToString();
            string ptNo = this.selectedItem["ptNo"].ToString();
            string ptNm = this.selectedItem["ptNm"].ToString();
            string selectedImageNum = arg1.ImageButtonValue.nImageNum.ToString();
            string userId = SessionInfo.userId;

            string jsonValue = JsonConvert.SerializeObject(imageDt);

            jsonValue = jsonValue.Replace("\"", "\\\"");

            //KeyValueData parmaResult = JsonConvert.DeserializeObject<KeyValueData>(jsonValue);
            //MessageBox.Show(jsonValue);


            string path = @"C:\SEDAS\SedasPhoto\SedasPhotoMagic.exe";
            FileInfo file = new FileInfo(path);

            //기존에 띄워져 있으면 kill
            if (file.Exists)
            {
                string name = file.Name.Split('.').FirstOrDefault();

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



            using (Process compiler = new Process())
            {
                compiler.StartInfo.FileName = path;
                //string arg = string.Format("\"{0}\" {1} {2} {3} {4} {5} {6}", filePath, strImagePath, strPathologyNum, imageType, ptNo, ptNm, imageNum);
                string arg = string.Format("\"{0}\" {1} {2} {3} \"{4}\" {5} {6}", jsonValue, strImagePath, strPathologyNum, ptNo, ptNm, selectedImageNum, userId);
                compiler.StartInfo.Arguments = arg;
                //compiler.StartInfo.Arguments = "\"" + jsonValue + "\"" ;

                compiler.StartInfo.UseShellExecute = true;
                //compiler.StartInfo.RedirectStandardOutput = true;
                compiler.StartInfo.WorkingDirectory = file.DirectoryName;
                compiler.Start();

                //Console.WriteLine(compiler.StandardOutput.ReadToEnd());

                //compiler.WaitForExit();


                //this.SearchData(reSelectStudyId: this.selectedItem["studyId"].ToString());
            }
        }


        /// <summary>
        /// 이미지 선택시 발생되는 이벤트
        /// </summary>
        private void ImageBox_onImageSelected1(ImageContainer obj, string pressedKeyCode)
        {
            if (obj == null) return;

            List<ImageContainer> imageList = this.GetImageList();
            if (imageList != null && imageList.Count > 0)
            {
                if (pressedKeyCode == "Control")
                {
                    imageList.ForEach(item => { item.IsLastSelected = false; });

                    for (int i = 0; i < imageList.Count; i++)
                    {
                        ImageContainer image = imageList[i];
                        if (image == obj)
                        {
                            if (image.IsSelected == true)
                            {
                                image.IsSelected = false;
                            }
                            else
                            {
                                image.IsSelected = true;
                            }

                            image.IsLastSelected = true;
                        }
                    }
                }
                else if (pressedKeyCode == "Shift")
                {
                    int lastSelectedIndex = -1;
                    int targetIndex = -1;
                    for (int i = 0; i < imageList.Count; i++)
                    {
                        ImageContainer image = imageList[i];

                        if (image.IsLastSelected == true)
                        {
                            lastSelectedIndex = i;
                        }

                        if (image == obj)
                        {
                            targetIndex = i;
                        }
                    }





                    if (lastSelectedIndex > -1 && targetIndex > -1)
                    {
                        //imageList.ForEach(item => { item.IsLastSelected = false; });

                        int min = -1;
                        int max = -1;

                        if (lastSelectedIndex > targetIndex)
                        {
                            min = targetIndex;
                            max = lastSelectedIndex;
                        }
                        else
                        {
                            min = lastSelectedIndex;
                            max = targetIndex;
                        }

                        for (int i = 0; i < imageList.Count; i++)
                        {
                            ImageContainer image = imageList[i];

                            if (i >= min && i <= max)
                            {
                                image.IsSelected = true;
                            }
                            else
                            {
                                image.IsSelected = false;
                            }
                        }
                    }

                }
                else
                {
                    imageList.ForEach(item => { item.IsLastSelected = false; });

                    for (int i = 0; i < imageList.Count; i++)
                    {
                        ImageContainer image = imageList[i];
                        if (image == obj)
                        {
                            image.IsSelected = true;
                            image.IsLastSelected = true;
                        }
                        else
                        {
                            image.IsSelected = false;
                        }
                    }
                }

            }
        }

        private void ImageBox_MouseClick(object sender, MouseEventArgs e)
        {


            //throw new NotImplementedException();
        }

        /// <summary>
        /// 이미지 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ImageBox_Click(object sender, EventArgs e)
        {
            //throw new NotImplementedException();


            List<ImageContainer> imageList = this.GetImageList();
            if (imageList != null && imageList.Count > 0)
            {

            }
        }

        /// <summary>
        /// 화면에 보이는 이미지 리스트를 리턴한다.
        /// </summary>
        /// <returns></returns>
        private List<ImageContainer> GetImageList()
        {
            List<ImageContainer> imageList = new List<ImageContainer>();
            if (flwpnlImage.Controls.Count > 0)
            {
                for (int i = 0; i < this.flwpnlImage.Controls.Count; i++)
                {
                    if (this.flwpnlImage.Controls[i] is ImageContainer)
                    {
                        imageList.Add(this.flwpnlImage.Controls[i] as ImageContainer);
                    }
                }
            }

            return imageList;
        }



        /// <summary>
        /// 저장버튼 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            if (this.selectedItem == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("병리번호를 선택해 주세요");
                return;
            }

            //처방조회
            //SelectOrder();

            if (DevExpress.XtraEditors.XtraMessageBox.Show("변경된 이미지를 저장 하시겠습니까?", "이미지 저장", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (this.SaveImageData() == false)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지 저장 실패");
                    return;
                }
            }



        }

        //private void AddLog(string logCode, string ptno, string ptoNo, string title, string message, LogType logType, ActionType actionType)
        //{
        //    if (this.logHelper == null) return;

        //    LogDTO log = new LogDTO();
        //    log.ptno = ptno;
        //    log.ptoNo = ptoNo;
        //    log.title = title;
        //    log.message = message;
        //    log.logCode = logCode;
        //    log.logType = LogType.INFO;
        //    log.actionType = ActionType.CALL_DB;

        //    logHelper.WriteLog(logCode, log);
        //}


        /// <summary>
        /// name         : UpdateStudyTableImageData
        /// desc         : 스터디 데이블의 이미지 정보 업데이트 
        /// author       : 심우종
        /// create date  : 2020-04-24 15:49
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool UpdateStudyTableImageData(string gi, string mi, string oi, string studyId)
        {
            DateTime current = DateTime.Now;
            string insertDt = current.ToString("yyyyMMddHHmmss");

            KeyValueData param = new KeyValueData();
            param.Add("Data1", gi);
            param.Add("Data2", mi);
            param.Add("Data3", oi);
            param.Add("Data4", insertDt);
            param.Add("Data5", studyId);
            param.Add("Data6", SessionInfo.userId);
            CallResultData result = this.callService.SelectSql("reqSetViewerStudyImageData", param);
            if (result.resultState == ResultState.OK)
            {
                return true;
            }
            else
            {
                //실패에 대한 처리
                DevExpress.XtraEditors.XtraMessageBox.Show("이미지 정보 업데이트시 오류");
                return false;
            }
        }


        /// <summary>
        /// name         : UpdateImageSaveAfter
        /// desc         : 이미지 저장 후 처리 update
        /// author       : 심우종
        /// create date  : 2020-05-15 08:53
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool UpdateImageSaveAfter(string studyId)
        {
            //-----------------------------------------
            //1) study테이블의 이미지 number 재설정
            //2) 이미지 테이블의 serialNo재설정
            //-----------------------------------------
            KeyValueData param = new KeyValueData();
            param.Add("Data1", studyId);
            param.Add("Data2", SessionInfo.userId);
            CallResultData result = this.callService.SelectSql("reqSetViewerImageSaveAfter", param);
            if (result.resultState == ResultState.OK)
            {
                if (selectedItem != null)
                {
                    Global.logHelper.WriteLog("viewerSaveClick", LogType.INFO, ActionType.CALL_DB, "Viewer 이미지 저장", "reqSetViewerImageSaveAfter 저장 성공", ptoNo: selectedItem["ptoNo"].ToString());
                }

                return true;
            }
            else
            {
                //실패에 대한 처리
                DevExpress.XtraEditors.XtraMessageBox.Show("이미지 저장 후 처리 업데이트시 오류");
                if (selectedItem != null)
                {
                    Global.logHelper.WriteLog("viewerSaveClick", LogType.ERROR, ActionType.CALL_DB, "Viewer 이미지 저장", "reqSetViewerImageSaveAfter 저장 실패", ptoNo: selectedItem["ptoNo"].ToString());
                }

                return false;
            }
        }


        /// <summary>
        /// name         : DeleteAllImage
        /// desc         : 이미지 
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        //private bool DeleteAllImage(string studyId)
        //{
        //    KeyValueData param = new KeyValueData();
        //    param.Add("Data1", studyId);
        //    CallResultData result = this.callService.SelectSql("reqSetViewerDeleteImageData", param);
        //    if (result.resultState == ResultState.OK)
        //    {
        //        //데이터 조회 성공
        //        return true;
        //    }
        //    else
        //    {
        //        //실패에 대한 처리
        //        MessageBox.Show("이미지 테이블 삭제 오류");
        //        return false;
        //    }
        //}


        /// <summary>
        /// name         : DeleteImageFromDB
        /// desc         : 삭제되는 이미지 정보를 DB에 반영한다.
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool DeleteImageFromDB(List<ImageButtonValue> deleteImages)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("studyId", typeof(String));
            dt.Columns.Add("seq", typeof(String));
            dt.Columns.Add("ptoNo", typeof(String));
            dt.Columns.Add("filePath", typeof(String));

            List<DeleteImageDTO> deleteImageList = new List<DeleteImageDTO>();
            for (int i = 0; i < deleteImages.Count; i++)
            {
                //DataRow row = dt.NewRow();
                //row["studyId"] = deleteImages[i].nStudyId.ToString();
                //row["seq"] = deleteImages[i].nSeq.ToString();
                //row["ptoNo"] = deleteImage[i].strPathologyNum.ToString();
                //row["filePath"] = g_PathData.strImagePath + deleteImage[i].strSaveFilePath.ToString();
                //dt.Rows.Add(row);

                DeleteImageDTO deleteDTO = new DeleteImageDTO();
                deleteDTO.StudyId = deleteImages[i].nStudyId.ToString();
                deleteDTO.Seq = deleteImages[i].nSeq.ToString();
                deleteDTO.PtoNo = deleteImage[i].strPathologyNum.ToString();
                deleteDTO.FilePath = deleteImage[i].strSaveFilePath.ToString();
                deleteImageList.Add(deleteDTO);
            }

            ImageInOutClass imageInOutClass = new ImageInOutClass(callService);
            if (imageInOutClass.DeleteImageFromDB(deleteImageList) == true)
            {
                if (deleteImages != null && deleteImages.Count > 0)
                {
                    string ptoNo = deleteImage[0].strPathologyNum.ToString();
                    Global.logHelper.WriteLog("viewerSaveClick", LogType.INFO, ActionType.ACTION, "Viewer 이미지 저장", "DB에서 이미지 삭제 성공", ptoNo: ptoNo);
                }

                return true;
            }
            else
            {
                if (deleteImages != null && deleteImages.Count > 0)
                {
                    string ptoNo = deleteImage[0].strPathologyNum.ToString();
                    Global.logHelper.WriteLog("viewerSaveClick", LogType.INFO, ActionType.ACTION, "Viewer 이미지 저장", "DB에서 이미지 삭제 실패", ptoNo: ptoNo);
                }
                return false;
            }
        }


        /// <summary>
        /// name         : GetImageInfo
        /// desc         : 이미지 경로를 조회한다.
        /// author       : 심우종
        /// create date  : 2020-04-24 11:11
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool GetImageInfo(string studyId, out DataTable resultDt)
        {
            KeyValueData param = new KeyValueData();
            param.Add("Data1", studyId);
            CallResultData result = this.callService.SelectSql("reqGetViewerImagePath", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;
                resultDt = dt;
                return true;

            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("이미지 경로 조회시 에러");
                resultDt = null;
                return false;
            }
        }

        //이미지 종류별 건수 Count
        int nGI = 0;
        int nMI = 0;
        int nOI = 0;

        //변경된 병리번호에 대한 이미지 종류별 건수 Count
        int nChangedGI = 0;
        int nChangedMI = 0;
        int nChangedOI = 0;

        /// <summary>
        /// name         : SaveImageData
        /// desc         : 이미지를 저장한다.
        /// author       : 심우종
        /// create date  : 2020-04-24 10:23
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool SaveImageData(KeyValueData changedPatNoParam = null)
        {

            bool isPtoNoChange = false; // 병리번호 변경으로 인한 처리여부

            string changedStudyId = "";
            string changedPtoNo = "";
            int changedGI = 0;
            int changedMI = 0;
            int changedOI = 0;
            if (changedPatNoParam != null)
            {
                isPtoNoChange = true;
                changedStudyId = changedPatNoParam["changedStudyId"].ToString();
                changedPtoNo = changedPatNoParam["changedPtoNo"].ToString();
                changedGI = changedPatNoParam["changedGI"].ToString().ToInt();
                changedMI = changedPatNoParam["changedMI"].ToString().ToInt();
                changedOI = changedPatNoParam["changedOI"].ToString().ToInt();

            }

            //changedSutdyId, changedPtoNo

            if (this.selectedItem == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("병리번호를 선택해 주세요");
                return false;
            }

            string studyId = selectedItem["studyId"].ToString();
            string ptoNo = selectedItem["ptoNo"].ToString();

            Global.logHelper.WriteLog("viewerSaveClick", LogType.INFO, ActionType.ACTION, "Viewer 이미지 저장", "Viewer 이미지 저장 시작", ptoNo: ptoNo);

            if (string.IsNullOrEmpty(studyId) || string.IsNullOrEmpty(ptoNo)) return false;

            //기존의 DB에 저장된 이미지 정보 조회
            //DataTable dbImagePath = null;
            //if (this.GetImageInfo(studyId, out dbImagePath) == false)
            //{
            //    return false;
            //}



            //기존 DB의 이미지 테이블 정보 삭제
            //if (this.DeleteAllImage(studyId) == false)
            //{
            //    return false;
            //}

            DateTime current = DateTime.Now;
            string filePath = "imagedata\\"; // g_PathData.strImagePath;
            string tempPath = current.ToString("yyyy") + "\\";
            filePath = filePath + tempPath;


            //Directory.CreateDirectory(filePath);

            tempPath = ptoNo + "\\";
            filePath = filePath + tempPath;

            //Directory.CreateDirectory(filePath);

            this.nGI = 0;
            this.nMI = 0;
            this.nOI = 0;

            this.nChangedGI = changedGI;
            this.nChangedMI = changedMI;
            this.nChangedOI = changedOI;

            int currentImageIndex = 0;
            int changedImageIndex = changedGI + changedMI + changedOI;

            if (isPtoNoChange == true) //[병리번호 변경 이벤트로 처리하는 경우]
            {
                //변경된 filePath를 구하자..
                string changedFilePath = "imagedata\\";
                string changedTempPath = current.ToString("yyyy") + "\\";
                changedFilePath = changedFilePath + changedTempPath;


                //Directory.CreateDirectory(filePath);

                changedTempPath = changedPtoNo + "\\";
                changedFilePath = changedFilePath + changedTempPath;

                //Directory.CreateDirectory(changedFilePath);



                if (flwpnlImage.Controls.Count > 0)
                {
                    for (int i = 0; i < flwpnlImage.Controls.Count; i++)
                    {
                        if (this.flwpnlImage.Controls[i] is ImageContainer)
                        {
                            ImageContainer image = this.flwpnlImage.Controls[i] as ImageContainer;

                            if (image.IsSelected == true)
                            {
                                //[1] 새로운 병리번호로 이미지 copy
                                if (this.ImageInsert(image, changedImageIndex, changedFilePath, changedPtoNo, changedStudyId, isPtoNoChanged: true) == false)
                                {
                                    return false;
                                }
                                changedImageIndex++;

                                //[2] 기존 이미지는 삭제처리
                                this.deleteImage.Add(image.ImageButtonValue);
                            }
                            else
                            {
                                //[2] 기존 병리번호로 새로 insert처리   
                                //if (this.ImageInsert(image, currentImageIndex, filePath, ptoNo, studyId) == false)
                                //{
                                //    return false;
                                //}
                                //currentImageIndex++;
                            }

                        }
                    }
                }

                if (this.deleteImage != null && this.deleteImage.Count > 0)
                {
                    //삭제가 필요한 데이터 DB에서 제거
                    if (this.DeleteImageFromDB(this.deleteImage) == false)
                    {
                        return false;
                    }
                }


                //이미지 변경후 처리
                if (UpdateImageSaveAfter(studyId) == false)
                {
                    return false;

                }

                if (UpdateImageSaveAfter(changedStudyId) == false)
                {
                    return false;

                }


                //기존 병리번호에 남은 데이터가 없으면 study테이블에 건수를 0으로 업데이트
                //if (currentImageIndex == 0)
                //{
                //    if (this.UpdateStudyTableImageData("0", "0", "0", studyId) == false)
                //    {
                //        return false;
                //    }
                //}
            }
            else
            {
                if (this.deleteImage != null && this.deleteImage.Count > 0)
                {
                    //삭제가 필요한 데이터 DB에서 제거
                    if (this.DeleteImageFromDB(this.deleteImage) == false)
                    {
                        return false;
                    }
                }


                if (flwpnlImage.Controls.Count > 0)
                {
                    for (int i = 0; i < flwpnlImage.Controls.Count; i++)
                    {
                        if (this.flwpnlImage.Controls[i] is ImageContainer)
                        {
                            ImageContainer image = this.flwpnlImage.Controls[i] as ImageContainer;

                            if (string.IsNullOrEmpty(image.ImageButtonValue.strSaveFilePath))
                            {
                                //신규로 추가된 이미지만 처리
                                if (this.ImageInsert(image, i, filePath, ptoNo, studyId) == false)
                                {
                                    return false;
                                }
                            }
                        }
                    }
                }

                //이미지 저장 후 처리
                if (UpdateImageSaveAfter(studyId) == false)
                {
                    return false;

                }
            }




            //기존 이미지 삭제
            //if (dbImagePath != null && dbImagePath.Rows.Count > 0)
            //{
            //    for (int i = 0; i < dbImagePath.Rows.Count; i++)
            //    {
            //        string path = g_PathData.strImagePath + dbImagePath.Rows[i]["filePath"].ToString();

            //        bool isFileExist = File.Exists(path);
            //        if (isFileExist)
            //        {
            //            File.Delete(path);
            //        }

            //    }
            //}

            //기존 이미지 삭제
            if (this.deleteImage != null && this.deleteImage.Count > 0)
            {
                for (int i = 0; i < this.deleteImage.Count; i++)
                {
                    //string path = g_PathData.strImagePath + this.deleteImage[i].strSaveFilePath;

                    if (ft.DeleteFile(this.deleteImage[i].strSaveFilePath) == true)
                    {
                        //파일서버에서 이미지 삭제
                    }
                    //bool isFileExist = File.Exists(path);
                    //if (isFileExist)
                    //{
                    //    File.Delete(path);
                    //}

                }
            }


            if (isPtoNoChange == true)
            {
                string message = string.Format("{0}개의 이미지가 {1}로 이동되었습니다.", (changedImageIndex - (changedGI + changedMI + changedOI)).ToString(), changedPtoNo);
                DevExpress.XtraEditors.XtraMessageBox.Show(message);
                this.SearchData(reSelectStudyId: changedStudyId);
            }
            else
            {
                this.SearchData(reSelectStudyId: studyId);
            }

            return true;
        }





        /// <summary>
        /// name         : copyImageButtonValue
        /// desc         : 이미지 버튼Value 데이터 copy
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private ImageButtonValue copyImageButtonValue(ImageButtonValue dto)
        {
            ImageButtonValue copyDto = new ImageButtonValue();
            copyDto.bSelect = dto.bSelect;
            copyDto.nImageNum = dto.nImageNum;
            copyDto.nSendStatus = dto.nSendStatus;
            copyDto.nType = dto.nType;
            copyDto.strRowFilePath = dto.strRowFilePath;
            copyDto.strSaveRootPath = dto.strSaveRootPath;
            copyDto.strSaveFilePath = dto.strSaveFilePath;
            copyDto.strPathologyNum = dto.strPathologyNum;
            copyDto.nStudyId = dto.nStudyId;
            copyDto.nGI = dto.nGI;
            copyDto.nMI = dto.nMI;
            copyDto.nOI = dto.nOI;
            copyDto.nSerialNo = dto.nSerialNo;
            copyDto.strPtNo = dto.strPtNo;
            copyDto.strPtNm = dto.strPtNm;
            copyDto.nSeq = dto.nSeq;

            return copyDto;
        }

        /// <summary>
        /// name         : ImageInsert
        /// desc         : 이미지 한건에 대해서 파일복사 및 DB정보 추가
        /// author       : 심우종
        /// create date  : 2020-05-08 12:57
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool ImageInsert(ImageContainer image, int imageIndex, string filePath, string ptoNo, string studyId, bool isPtoNoChanged = false)
        {
            //ImageContainer image = this.flwpnlImage.Controls[i] as ImageContainer;
            if (image != null)
            {
                //ImageButtonValue buttonValue = image.ImageButtonValue;
                //ImageButtonValue buttonValue = DTOCopy.PropertyValueCopy(image.ImageButtonValue, typeof(ImageButtonValue)) as ImageButtonValue;

                ImageButtonValue buttonValue = copyImageButtonValue(image.ImageButtonValue);


                DateTime current = DateTime.Now;
                string fileName = ptoNo + "_" + current.ToString("yyyyMMddHHmmss") + imageIndex.ToString() + ".jpg";
                string savePath = filePath + fileName;

                //이미지 파일복사
                //File.Copy(buttonValue.strRowFilePath, savePath);
                if (ft.FileUpload(buttonValue.strRowFilePath, savePath) == false)
                {
                    Global.logHelper.WriteLog("viewerSaveClick", LogType.ERROR, ActionType.ACTION, "Viewer 이미지 저장", "이미지 파일복사 실패", ptoNo: ptoNo);
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지 저장에 실패했습니다.");
                    return false;
                }

                //*.IIF 파일 복사
                string iifPath = buttonValue.strRowFilePath.Substring(0, buttonValue.strRowFilePath.Length - 3);
                iifPath = iifPath + "IIF";

                bool isIifExist = File.Exists(iifPath);
                if (isIifExist == true)
                {
                    string iifFilePath = savePath.Substring(0, savePath.Length - 3) + "IIF";
                    //File.Copy(iifPath, iifFilePath);
                    if (ft.FileUpload(iifPath, iifFilePath) == false)
                    {
                        Global.logHelper.WriteLog("viewerSaveClick", LogType.ERROR, ActionType.ACTION, "Viewer 이미지 저장", "IIF 파일복사 실패", ptoNo: ptoNo);
                        DevExpress.XtraEditors.XtraMessageBox.Show("IIF파일 저장에 실패했습니다.");
                        return false;
                    }

                }


                string temppath = current.ToString("yyyyMMdd") + "\\" + ptoNo + "\\";
                string datafilepath = temppath;

                buttonValue.nImageNum = imageIndex + 1;

                buttonValue.nSerialNo = imageIndex + 1;
                buttonValue.strSaveFilePath = savePath;
                buttonValue.strSaveRootPath = "Z:\\";
                buttonValue.nStudyId = studyId.ToInt();

                if (isPtoNoChanged == true) //병리번호 변경인 경우
                {
                    if (buttonValue.nType == 0)
                        this.nChangedGI++;
                    if (buttonValue.nType == 1)
                        this.nChangedMI++;
                    if (buttonValue.nType == 2)
                        this.nChangedOI++;

                    buttonValue.nGI = nChangedGI;
                    buttonValue.nMI = nChangedMI;
                    buttonValue.nOI = nChangedOI;
                }
                else
                {
                    if (buttonValue.nType == 0)
                        nGI++;
                    if (buttonValue.nType == 1)
                        nMI++;
                    if (buttonValue.nType == 2)
                        nOI++;

                    buttonValue.nGI = nGI;
                    buttonValue.nMI = nMI;
                    buttonValue.nOI = nOI;
                }



                if (buttonValue.nSendStatus == -1)
                    buttonValue.nSendStatus = 0;

                //이미지 테이블에 정보 저장
                if (this.InsertImage(buttonValue, ptoNo) == false)
                {
                    return false;
                }

            }

            return true;
        }


        /// <summary>
        /// 처방 데이터를 조회한다.
        /// </summary>
        private void SelectOrder()
        {
            //DataTable dt = initDataTable();

            List<OrderDTO> orderList = new List<OrderDTO>();

            this.initTempData(orderList);

            grdOrder.DataSource = orderList;

            if (this.flwpnlImage.Controls.Count > 0)
            {
                //이미지 초기화
                this.flwpnlImage.Controls.Clear();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        private void initTempData(List<OrderDTO> orderList)
        {

            for (int i = 0; i < 100; i++)
            {
                OrderDTO order = new OrderDTO();
                order.Data1 = i.ToString(); //
                order.Data2 = "S2008001"; //
                order.Data3 = "1";
                order.Data4 = "0";
                order.Data5 = "0";
                order.Data6 = "";
                order.Data7 = "02263556";
                order.Data8 = "지정식";
                order.Data9 = "1955-02-14";
                order.Data10 = "61";
                order.Data11 = "F";
                orderList.Add(order);
            }



            //DataRow row = dt.NewRow();
            //row["data1"] = "98965";
            //row["data2"] = "S2008001";
            //row["data3"] = "1";
            //row["data4"] = "0";
            //row["data5"] = "0";
            //row["data6"] = "";
            //row["data7"] = "02263556";
            //row["data8"] = "지정식";
            //row["data9"] = "1955-02-14";
            //row["data10"] = "61";
            //row["data11"] = "F";

            //dt.Rows.Add(row);
        }

        //private DataTable initDataTable()
        //{
        //    OrderDTO orderDTO = new OrderDTO();




        //    DataTable dt = new DataTable();
        //    dt.Columns.Add("data1", typeof(String));
        //    dt.Columns.Add("data2", typeof(String));
        //    dt.Columns.Add("data3", typeof(String));
        //    dt.Columns.Add("data4", typeof(String));
        //    dt.Columns.Add("data5", typeof(String));
        //    dt.Columns.Add("data6", typeof(String));
        //    dt.Columns.Add("data7", typeof(String));
        //    dt.Columns.Add("data8", typeof(String));
        //    dt.Columns.Add("data9", typeof(String));
        //    dt.Columns.Add("data10", typeof(String));
        //    dt.Columns.Add("data11", typeof(String));
        //    dt.Columns.Add("data12", typeof(String));
        //    dt.Columns.Add("data13", typeof(String));
        //    dt.Columns.Add("data14", typeof(String));
        //    dt.Columns.Add("data15", typeof(String));
        //    dt.Columns.Add("data16", typeof(String));
        //    dt.Columns.Add("data17", typeof(String));

        //    return dt;
        //}



        /// <summary>
        /// context메뉴 설정
        /// </summary>
        private void initContextMenu()
        {
            //1. 이미지 영역용 contextMenu
            DevExpress.XtraBars.PopupMenu menu = new DevExpress.XtraBars.PopupMenu();
            menu.Name = "menu_image";
            menu.Manager = barManager2;
            BarButtonItem itemCopy = new BarButtonItem(barManager2, "이미지추가", 0);
            itemCopy.AccessibleName = "itemCopy";
            itemCopy.Hint = "itemCopy";
            BarButtonItem itemDelete = new BarButtonItem(barManager2, "이미지삭제", 1);
            itemDelete.AccessibleName = "itemDelete";
            itemDelete.Hint = "itemDelete";
            BarButtonItem itemPaste = new BarButtonItem(barManager2, "이미지내보내기", 2);
            itemPaste.AccessibleName = "itemPaste";
            itemPaste.Hint = "itemPaste";
            BarButtonItem itemChangeNo = new BarButtonItem(barManager2, "이미지병리번호변경", 2);
            itemChangeNo.AccessibleName = "itemChangeNo";
            itemChangeNo.Hint = "itemChangeNo";
            //SeparatorControl sp = new SeparatorControl();

            BarButtonItem itemPrint = new BarButtonItem(barManager2, "이미지 인쇄", 2);
            itemPrint.AccessibleName = "itemPrint";
            itemPrint.Hint = "itemPrint";
            BarButtonItem itemEdit = new BarButtonItem(barManager2, "이미지편집(응용프로그램)", 2);
            itemEdit.AccessibleName = "itemEdit";
            itemEdit.Hint = "itemEdit";

            BarButtonItem itemSendResult = new BarButtonItem(barManager2, "결과전송(선택영상)", 2);
            itemSendResult.AccessibleName = "itemSendResult";
            itemSendResult.Hint = "itemSendResult";

            menu.AddItems(new BarItem[] { itemCopy, itemDelete, itemPaste, itemChangeNo });
            menu.ItemLinks.Add(itemPrint).BeginGroup = true;
            menu.AddItems(new BarItem[] { itemEdit });
            menu.ItemLinks.Add(itemSendResult).BeginGroup = true;
            barManager2.ItemClick += BarManager1_ItemClick;
            barManager2.QueryShowPopupMenu += BarManager1_QueryShowPopupMenu;
            barManager2.SetPopupContextMenu(xtraScrollableControl1, menu);
            //barManager1.SetPopupContextMenu(grdOrder, menu);



            //return;

            //2. 그리드 영역용 contextMenu
            DevExpress.XtraBars.PopupMenu menuGrid = new DevExpress.XtraBars.PopupMenu();
            menuGrid.Name = "menu_grid";
            menuGrid.Manager = barManager2;
            BarButtonItem menuGridAdd = new BarButtonItem(barManager2, "이미지추가", 0);

            menuGridAdd.AccessibleName = "menuGridAdd";
            menuGridAdd.Hint = "menuGridAdd";

            BarButtonItem menuGridView = new BarButtonItem(barManager2, "이미지보기", 1);
            menuGridView.AccessibleName = "menuGridView";
            menuGridView.Hint = "menuGridView";
            BarButtonItem menuGridToExcel = new BarButtonItem(barManager2, "데이터출력(Excel)", 2);
            menuGridToExcel.AccessibleName = "menuGridToExcel";
            menuGridToExcel.Hint = "menuGridToExcel";
            BarButtonItem menuGridDelete = new BarButtonItem(barManager2, "데이터삭제", 2);
            menuGridDelete.AccessibleName = "menuGridDelete";
            menuGridDelete.Hint = "menuGridDelete";
            //SeparatorControl sp = new SeparatorControl();

            BarButtonItem menuGridSendResult = new BarButtonItem(barManager2, "결과전송(전체영상)", 2);
            menuGridSendResult.AccessibleName = "menuGridSendResult";
            menuGridSendResult.Hint = "menuGridSendResult";
            BarButtonItem menuGridViewResult = new BarButtonItem(barManager2, "결과보기", 2);
            menuGridViewResult.AccessibleName = "menuGridViewResult";
            menuGridViewResult.Hint = "menuGridViewResult";

            BarButtonItem menuGridRefresh = new BarButtonItem(barManager2, "새로고침", 2);
            menuGridRefresh.AccessibleName = "menuGridRefresh";
            menuGridRefresh.Hint = "menuGridRefresh";

            menuGrid.AddItems(new BarItem[] { menuGridAdd, menuGridView });
            menuGrid.ItemLinks.Add(menuGridToExcel).BeginGroup = true;
            menuGrid.AddItems(new BarItem[] { menuGridDelete });
            menuGrid.ItemLinks.Add(menuGridSendResult).BeginGroup = true;
            menuGrid.AddItems(new BarItem[] { menuGridViewResult });
            menuGrid.ItemLinks.Add(menuGridRefresh).BeginGroup = true;

            //barManager1.ItemClick += BarManager1_ItemClick;
            barManager2.SetPopupContextMenu(grdOrder, menuGrid);



        }


        /// <summary>
        /// name         : BarManager1_QueryShowPopupMenu
        /// desc         : Context 메뉴 팝업시 체크
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void BarManager1_QueryShowPopupMenu(object sender, QueryShowPopupMenuEventArgs e)
        {
            if (e.Menu.Name == "menu_image")
            {

                if (this.ImageList.Count == 0)
                {
                    //이미지가 없는경우
                    BarItemLink itemDelete = e.Menu.ItemLinks.Where(o => o.DisplayHint == "itemDelete").FirstOrDefault();
                    itemDelete.Item.Enabled = false;
                    BarItemLink itemPaste = e.Menu.ItemLinks.Where(o => o.DisplayHint == "itemPaste").FirstOrDefault();
                    itemPaste.Item.Enabled = false;
                    BarItemLink itemChangeNo = e.Menu.ItemLinks.Where(o => o.DisplayHint == "itemChangeNo").FirstOrDefault();
                    itemChangeNo.Item.Enabled = false;
                    BarItemLink itemPrint = e.Menu.ItemLinks.Where(o => o.DisplayHint == "itemPrint").FirstOrDefault();
                    itemPrint.Item.Enabled = false;
                    BarItemLink itemEdit = e.Menu.ItemLinks.Where(o => o.DisplayHint == "itemEdit").FirstOrDefault();
                    itemEdit.Item.Enabled = false;
                    BarItemLink itemSendResult = e.Menu.ItemLinks.Where(o => o.DisplayHint == "itemSendResult").FirstOrDefault();
                    itemSendResult.Item.Enabled = false;
                }
                else
                {
                    BarItemLink itemDelete = e.Menu.ItemLinks.Where(o => o.DisplayHint == "itemDelete").FirstOrDefault();
                    itemDelete.Item.Enabled = true;
                    BarItemLink itemPaste = e.Menu.ItemLinks.Where(o => o.DisplayHint == "itemPaste").FirstOrDefault();
                    itemPaste.Item.Enabled = true;
                    BarItemLink itemChangeNo = e.Menu.ItemLinks.Where(o => o.DisplayHint == "itemChangeNo").FirstOrDefault();
                    itemChangeNo.Item.Enabled = true;
                    BarItemLink itemPrint = e.Menu.ItemLinks.Where(o => o.DisplayHint == "itemPrint").FirstOrDefault();
                    itemPrint.Item.Enabled = true;
                    BarItemLink itemEdit = e.Menu.ItemLinks.Where(o => o.DisplayHint == "itemEdit").FirstOrDefault();
                    itemEdit.Item.Enabled = true;
                    BarItemLink itemSendResult = e.Menu.ItemLinks.Where(o => o.DisplayHint == "itemSendResult").FirstOrDefault();
                    itemSendResult.Item.Enabled = true;

                }
            }
            else if (e.Menu.Name == "menu_grid")
            {
                if (grvOrder.RowCount <= 0)
                {
                    //그리드에 데이터가 없는경우
                    BarItemLink menuGridView = e.Menu.ItemLinks.Where(o => o.DisplayHint == "menuGridView").FirstOrDefault();
                    menuGridView.Item.Enabled = false;
                    BarItemLink menuGridDelete = e.Menu.ItemLinks.Where(o => o.DisplayHint == "menuGridDelete").FirstOrDefault();
                    menuGridDelete.Item.Enabled = false;
                    BarItemLink menuGridViewResult = e.Menu.ItemLinks.Where(o => o.DisplayHint == "menuGridViewResult").FirstOrDefault();
                    menuGridViewResult.Item.Enabled = false;
                }
                else
                {
                    BarItemLink menuGridView = e.Menu.ItemLinks.Where(o => o.DisplayHint == "menuGridView").FirstOrDefault();
                    menuGridView.Item.Enabled = true;
                    BarItemLink menuGridDelete = e.Menu.ItemLinks.Where(o => o.DisplayHint == "menuGridDelete").FirstOrDefault();
                    menuGridDelete.Item.Enabled = true;
                    BarItemLink menuGridViewResult = e.Menu.ItemLinks.Where(o => o.DisplayHint == "menuGridViewResult").FirstOrDefault();
                    menuGridViewResult.Item.Enabled = true;
                }
            }
        }


        /// <summary>
        /// ContextMenu 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarManager1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == null || string.IsNullOrEmpty(e.Item.AccessibleName)) return;
            string name = e.Item.AccessibleName;

            //이미지 영역용 ContextMenu
            switch (name)
            {
                case "itemCopy": //이미지추가
                    this.menu_itemCopy();
                    break;
                case "itemDelete": //이미지삭제
                    this.menu_itemDelete();
                    break;
                case "itemPaste": //이미지내보내기
                    this.menu_itemPaste();
                    break;
                case "itemChangeNo": //이미지병리번호변경
                    this.menu_itemChageNo();
                    break;
                case "itemPrint": //이미지 인쇄
                    this.menu_ItemPrint();
                    break;
                case "itemEdit": //이미지편집(응용프로그램)
                    this.menu_ItemEdit();
                    break;
                case "itemSendResult": //결과전송(선택영상)
                    this.menu_itemSendResult();
                    break;
            }

            //그리드 영역용 ContextMenu
            switch (name)
            {
                case "menuGridAdd": //이미지추가
                    this.menuGrid_Add();
                    break;
                case "menuGridView": //이미지보기
                    this.menuGrid_View();
                    break;
                case "menuGridToExcel": //데이터출력(Excel)
                    this.menuGrid_ToExcel();
                    break;
                case "menuGridDelete": //데이터삭제
                    this.menuGrid_Delete();
                    break;
                case "menuGridSendResult": //결과전송(전체영상)
                    this.menuGrid_SendResult();
                    break;
                case "menuGridViewResult": //결과보기
                    this.menuGrid_ViewResult();
                    break;
                case "menuGridRefresh": //새로고침
                    this.SearchData();
                    break;
            }
        }


        #region [메뉴 아이템 클릭 이벤트 처리]



        /// <summary>
        /// name         : menuGrid_SendResult
        /// desc         : 그리드에서 결과전송(전체영상) 클릭시 
        /// author       : 심우종
        /// create date  : 2020-04-22 16:29
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menuGrid_SendResult()
        {
            int[] selectedRows = this.grvOrder.GetSelectedRows();

            if (selectedRows == null || selectedRows.Count() == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("선택한 데이터가 없습니다.");
                return;
            }

            string seletedStudyId = "";
            DataTable sendDicomDt = new DataTable();
            sendDicomDt.Columns.Add("studyId", typeof(String));
            sendDicomDt.Columns.Add("userId", typeof(String));
            for (int i = 0; i < selectedRows.Count(); i++)
            {
                DataRow dr = this.grvOrder.GetDataRow(selectedRows.ElementAt(i));
                DataRow newDr = sendDicomDt.NewRow();
                newDr["studyId"] = dr["studyId"].ToString();
                newDr["userId"] = SessionInfo.userId;
                seletedStudyId = dr["studyId"].ToString();
                sendDicomDt.Rows.Add(newDr);
            }

            if (sendDicomDt != null && sendDicomDt.Rows.Count > 0)
            {
                string tempValue = sendDicomDt.DataTableToStringForServer();

                KeyValueData param = new KeyValueData();
                param.Add("Data1", tempValue);
                CallResultData result = this.callService.SelectSql("reqSetViewerSendDicom", param);
                if (result.resultState == ResultState.OK)
                {
                    Global.logHelper.WriteLog("viewerSendResult", LogType.INFO, ActionType.CALL_DB, "Viewer 결과전송(전체영상)", "결과전송에 성공하였습니다.", studyId: seletedStudyId);
                    //데이터 조회 성공
                    //MessageBox.Show("삭제되었습니다.");
                }
                else
                {
                    Global.logHelper.WriteLog("viewerSendResult", LogType.ERROR, ActionType.CALL_DB, "Viewer 결과전송(전체영상)", "결과전송에 실패하였습니다.", studyId: seletedStudyId);
                    //실패에 대한 처리
                    DevExpress.XtraEditors.XtraMessageBox.Show("결과전송에 실패하였습니다.");
                }
            }

            ////데이터를 재조회한다.
            this.SearchData(reSelectStudyId: seletedStudyId);
        }


        /// <summary>
        /// name         : menuGrid_Delete
        /// desc         : 그리드에서 데이터 삭제 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-22 15:02
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menuGrid_Delete()
        {
            int[] selectedRows = this.grvOrder.GetSelectedRows();

            if (selectedRows == null || selectedRows.Count() == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("선택한 데이터가 없습니다.");
                return;
            }


            if (DevExpress.XtraEditors.XtraMessageBox.Show("데이터를 삭제 하시겠습니까?", "데이터 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                DataTable deleteDt = new DataTable();
                deleteDt.Columns.Add("studyId", typeof(String));
                deleteDt.Columns.Add("userId", typeof(String));
                for (int i = 0; i < selectedRows.Count(); i++)
                {
                    DataRow dr = this.grvOrder.GetDataRow(selectedRows.ElementAt(i));
                    DataRow newDr = deleteDt.NewRow();
                    newDr["studyId"] = dr["studyId"].ToString();
                    newDr["userId"] = SessionInfo.userId;
                    deleteDt.Rows.Add(newDr);
                }

                if (deleteDt != null && deleteDt.Rows.Count > 0)
                {
                    string tempValue = deleteDt.DataTableToStringForServer();

                    KeyValueData param = new KeyValueData();
                    param.Add("Data1", tempValue);
                    CallResultData result = this.callService.SelectSql("reqSetViewerDeleteData", param);
                    if (result.resultState == ResultState.OK)
                    {
                        //데이터 조회 성공
                        //DataTable dt = result.resultData;
                        //MessageBox.Show("삭제되었습니다.");
                        //this.logHelper.WriteLog("viewerDelete", LogType.INFO, ActionType.CALL_DB, "Viewer 그리드 삭제", "성공하였습니다.", studyId: studyId);
                    }
                    else
                    {
                        //실패에 대한 처리
                        DevExpress.XtraEditors.XtraMessageBox.Show("삭제처리가 실패하였습니다.");
                        //this.logHelper.WriteLog("viewerDelete", LogType.ERROR, ActionType.CALL_DB, "Viewer 그리드 삭제", "삭제 실패", studyId: studyId);
                    }
                }

                //데이터를 재조회한다.
                this.SearchData();

            }
        }

        /// <summary>
        /// name         : menuGrid_View
        /// desc         : 그리드에서 이미지 보기 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-22 14:17
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menuGrid_View()
        {
            ShowImage();
        }




        /// <summary>
        /// name         : menuGrid_itemCopy
        /// desc         : 그리드에서 이미지 추가 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-21 17:03
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menuGrid_Add()
        {
            this.AddingLocalImage();
        }


        /// <summary>
        /// name         : AddingLocalImage
        /// desc         : 신규 이미지를 추가한다.
        /// author       : 심우종
        /// create date  : 2020-04-22 09:08
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void AddingLocalImage()
        {
            DataRow selectedRow = grvOrder.GetFocusedDataRow();
            if (selectedRow == null) return;
            string studyId = selectedRow["studyId"].ToString();
            string ptoNo = selectedRow["ptoNo"].ToString();

            if (string.IsNullOrEmpty(studyId) || string.IsNullOrEmpty(ptoNo)) return;

            this.NewImageAdd(studyId, ptoNo);

        }


        /// <summary>
        /// name         : NewImageAdd
        /// desc         : 
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool NewImageAdd(string studyId, string ptoNo)
        {
            OpenFileWithImageType ofd = new OpenFileWithImageType();
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Multiselect = true;
            ofd.Filter = "jpg(*.*)|*.jpg*";
            DialogResult drs = ofd.ShowDialog();
            if (drs == DialogResult.OK)
            {
                for (int i = 0; i < ofd.Files.Count; i++)
                {
                    ImageButtonValue item = new ImageButtonValue();
                    item.strPathologyNum = ptoNo;
                    item.bSelect = false;
                    item.nImageNum = -1;
                    item.nSendStatus = -1;
                    item.nType = -1;
                    item.nType = ofd.imageType;
                    item.strRowFilePath = ofd.Files[i].ToString();



                    if (this.AddImageToStudy(item) == false)
                    {
                        return false;
                    }


                }

                //이미지 저장 후 처리
                if (UpdateImageSaveAfter(studyId) == false)
                {
                    return false;

                }

                this.SearchData(reSelectStudyId: studyId); //재조회

                //재조회 후 stidyId에 해당하는 컬럼 자동 포커스
                //DataView dv = grvOrder.DataSource as DataView;
                //DataRow row = dv.Table.AsEnumerable().Where(o => o["studyId"].ToString() == studyId).FirstOrDefault();

                //if (row != null)
                //{
                //    int index = dv.Table.Rows.IndexOf(row);
                //    grvOrder.FocusedRowHandle = index;

                //    this.ShowImages(studyId, row);
                //}


            }

            return true;
        }


        string tempFolder = "";



        /// <summary>
        /// name         : ShowImages
        /// desc         : 이미지를 불러온다.
        /// author       : 심우종
        /// create date  : 2020-04-22 14:05
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool ShowImages(string studyId, DataRow tableData)
        {
            this.AllDeleteImage(); //이미지 판넬의 이미지 클리어
            this.deleteImage = new List<ImageButtonValue>(); //삭제처리를 위한 이미지 정보 클리어

            //임시폴더에 데이터 삭제

            DirectoryInfo di = new DirectoryInfo(Global.tempFolder);
            if (di.Exists == false)
            {
                di.Create();
            }
            else
            {
                //모두 삭제
                FileInfo[] files = di.GetFiles();
                if (files != null && files.Count() > 0)
                {
                    foreach (FileInfo file in files)
                    {
                        file.Delete();
                    }
                }
            }





            KeyValueData param = new KeyValueData();
            param.Add("Data1", studyId);
            CallResultData result = this.callService.SelectSql("reqGetViewerImagePath", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;

                if (dt != null && dt.Rows.Count > 0)
                {
                    int nGI = 0;
                    int nMI = 0;
                    int nOI = 0;
                    int nRowNumCount = 0;

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        nRowNumCount++;
                        DataRow row = dt.Rows[i];

                        ImageButtonValue data = new ImageButtonValue();
                        data.bSelect = false;
                        data.strPathologyNum = tableData["ptoNo"].ToString();
                        data.strRowFilePath = row["filePath"].ToString();
                        if (row["sendStat"].ToString().ToIntOrNull() != null)
                        {
                            data.nSendStatus = row["sendStat"].ToString().ToInt();
                        }

                        if (row["serialNo"].ToString().ToIntOrNull() != null)
                        {
                            data.nSerialNo = row["serialNo"].ToString().ToInt();
                        }

                        data.strSaveFilePath = row["filePath"].ToString();

                        if (row["studyId"].ToString().ToIntOrNull() != null)
                        {
                            data.nStudyId = row["studyId"].ToString().ToInt();
                        }
                        data.nType = row["type"].ToString().ToInt();

                        if (dt.Columns.Contains("cm"))
                        {
                            data.strCm = row["cm"].ToString();
                        }

                        data.strPtNo = tableData["ptNo"].ToString();
                        data.strPtNm = tableData["ptNm"].ToString();
                        if (row["seq"].ToString().ToIntOrNull() != null)
                        {
                            data.nSeq = row["seq"].ToString().ToInt();
                        }

                        if (data.nType == 0)
                            nGI++;
                        if (data.nType == 1)
                            nMI++;
                        if (data.nType == 2)
                            nOI++;
                        data.nGI = nGI;
                        data.nMI = nMI;
                        data.nOI = nOI;

                        data.nImageNum = nRowNumCount;
                        this.ImageAdd(data.strRowFilePath, false, imageButtonValue: data);
                    }
                }
            }
            else
            {
                return false;
                //실패에 대한 처리
            }

            return true;
        }


        /// <summary>
        /// name         : AllDeleteImage
        /// desc         : 이미지 판넬의 이미지 클리어
        /// author       : 심우종
        /// create date  : 2020-04-22 14:56
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void AllDeleteImage()
        {
            if (flwpnlImage.Controls.Count > 0)
            {
                for (int i = this.flwpnlImage.Controls.Count - 1; i >= 0; i--)
                {
                    if (this.flwpnlImage.Controls[i] is ImageContainer)
                    {
                        ImageContainer image = this.flwpnlImage.Controls[i] as ImageContainer;
                        if (image != null)
                        {
                            this.flwpnlImage.Controls.Remove(image);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// name         : AddImageToStudy
        /// desc         : 이미지를 저장한다.
        /// author       : 심우종
        /// create date  : 2020-04-21 17:04
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool AddImageToStudy(ImageButtonValue data)
        {
            KeyValueData param = new KeyValueData();
            param.Add("Data1", data.strPathologyNum);
            CallResultData result = this.callService.SelectSql("reqGetViewerStudyInfo", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;

                if (dt != null && dt.Rows.Count > 0)
                {
                    string studyId = dt.Rows[0]["studyId"].ToString();
                    int gi = dt.Rows[0]["gi"].ToString().ToInt();
                    int mi = dt.Rows[0]["mi"].ToString().ToInt();
                    int oi = dt.Rows[0]["oi"].ToString().ToInt();

                    int imageCount = 0;
                    imageCount = gi + mi + oi;

                    DateTime current = DateTime.Now;
                    string fileName = data.strPathologyNum + "_" + current.ToString("yyyyMMddHHmmss") + imageCount + ".jpg";



                    string filePath = "imagedata\\";
                    string tempPath = current.ToString("yyyy") + "\\";
                    filePath = filePath + tempPath;


                    //Directory.CreateDirectory(filePath);

                    tempPath = data.strPathologyNum + "\\";
                    filePath = filePath + tempPath;

                    //Directory.CreateDirectory(filePath);


                    // *.jpg 파일 복사
                    filePath = filePath + fileName;
                    //File.Copy(data.strRowFilePath, filePath);
                    if (ft.FileUpload(data.strRowFilePath, filePath) == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("이미지 파일 저장에 실패하였습니다.");
                        return false;
                    }

                    //ft.FileUpload(data.strRowFilePath, )


                    //*.IIF 파일 복사
                    string iifPath = data.strRowFilePath.Substring(0, data.strRowFilePath.Length - 3);
                    iifPath = iifPath + "IIF";

                    bool isIifExist = File.Exists(iifPath);
                    if (isIifExist == true)
                    {
                        string iifFilePath = filePath.Substring(0, filePath.Length - 3) + "IIF";
                        //File.Copy(iifPath, iifFilePath);

                        if (ft.FileUpload(iifPath, iifFilePath) == false)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("IIF 파일 저장에 실패하였습니다.");
                            return false;
                        }
                    }

                    data.nStudyId = studyId.ToInt();
                    if (data.nType == 0)
                    {
                        data.nGI = gi + 1;
                        data.nMI = mi;
                        data.nOI = oi;
                    }
                    else if (data.nType == 1)
                    {
                        data.nGI = gi;
                        data.nMI = mi + 1;
                        data.nOI = oi;
                    }
                    else if (data.nType == 2)
                    {
                        data.nGI = gi;
                        data.nMI = mi;
                        data.nOI = oi + 1;
                    }

                    data.nImageNum = imageCount + 1;
                    data.nSerialNo = imageCount + 1;
                    data.strSaveRootPath = "Z:\\";
                    //string temppath = current.ToString("yyyyMMdd") + "\\" + ptoNo + "\\";
                    data.strSaveFilePath = filePath;
                    data.nSendStatus = 0;

                    this.InsertImage(data, data.strPathologyNum);

                    return true;

                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지 추가 : Query Error(Select Form Study)");
                    return false;
                }
            }
            else
            {
                //실패에 대한 처리
                DevExpress.XtraEditors.XtraMessageBox.Show("이미지 추가 : Query Error(Select Form Study)");
                return false;
            }


        }


        /// <summary>
        /// name         : InsertImage
        /// desc         : Image테이블에 저장
        /// author       : 심우종
        /// create date  : 2020-04-22 10:48
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool InsertImage(ImageButtonValue data, string ptoNo)
        {
            string insertDt = DateTime.Now.ToString("yyyyMMddHHmmss");
            KeyValueData param = new KeyValueData();
            param.Add("Data1", data.nType.ToString());
            param.Add("Data2", data.nSerialNo.ToString());
            param.Add("Data3", data.nStudyId.ToString());
            param.Add("Data4", data.strSaveRootPath);
            param.Add("Data5", data.strSaveFilePath);
            param.Add("Data6", data.nSendStatus.ToString());

            param.Add("Data7", data.nGI.ToString());
            param.Add("Data8", data.nMI.ToString());
            param.Add("Data9", data.nOI.ToString());
            param.Add("Data10", insertDt);
            param.Add("Data11", SessionInfo.userId);
            CallResultData result = this.callService.SelectSql("reqInsViewerImageData", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                //DataTable dt = result.resultData;
                Global.logHelper.WriteLog("viewerSaveClick", LogType.INFO, ActionType.ACTION, "Viewer 이미지 저장", "reqInsViewerImageData 호출 성공", ptoNo: ptoNo);
                return true;
            }
            else
            {
                //실패에 대한 처리
                DevExpress.XtraEditors.XtraMessageBox.Show("이미지 테이블 저장에 실패하였습니다.");
                Global.logHelper.WriteLog("viewerSaveClick", LogType.INFO, ActionType.ACTION, "Viewer 이미지 저장", "reqInsViewerImageData 호출 실패", ptoNo: ptoNo);
                return false;
            }
        }

        /// <summary>
        /// name         : menuGrid_ViewResult
        /// desc         : 결과보기 메뉴 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-23 10:08
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menuGrid_ViewResult()
        {
            DataRow selectedRow = this.grvOrder.GetFocusedDataRow();

            string studyId = selectedRow["studyId"].ToString();


            if (selectedRow == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("선택된 항목이 없습니다.");
                return;
            }

            ViewResultPopup viewResultPopup = new ViewResultPopup();
            viewResultPopup.InitData(selectedRow);
            viewResultPopup.ShowDialog();


            this.SearchData(reSelectStudyId: studyId); //재조회

            //if (!string.IsNullOrEmpty(studyId))
            //{
            //    //재조회 후 stidyId에 해당하는 컬럼 자동 포커스
            //    DataView dv = grvOrder.DataSource as DataView;
            //    DataRow row = dv.Table.AsEnumerable().Where(o => o["studyId"].ToString() == studyId).FirstOrDefault();

            //    if (row != null)
            //    {
            //        int index = dv.Table.Rows.IndexOf(row);
            //        grvOrder.FocusedRowHandle = index;

            //        this.ShowImages(studyId, row);
            //    }
            //}
        }



        /// <summary>
        /// name         : menu_itemSendResult
        /// desc         : 선택영상 결과전송
        /// author       : 심우종
        /// create date  : 2020-05-06 10:45
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menu_itemSendResult()
        {
            //DataTable dt = this.grdOrder.DataSource as DataTable;
            //if (this.selectedItem == null) return;

            List<ImageContainer> imageList = GetImageList();


            DataTable saveDt = new DataTable();
            saveDt.Columns.Add("studyId", typeof(String));
            saveDt.Columns.Add("serialNo", typeof(String));
            saveDt.Columns.Add("userId", typeof(String));

            string studyId = "";

            if (imageList != null && imageList.Count > 0)
            {
                for (int i = 0; i < imageList.Count; i++)
                {
                    ImageContainer image = imageList[i];

                    if (image.IsSelected == true && image.ImageButtonValue.nSendStatus == 0)
                    {
                        DataRow newRow = saveDt.NewRow();
                        newRow["studyId"] = image.ImageButtonValue.nStudyId.ToString();
                        studyId = image.ImageButtonValue.nStudyId.ToString();
                        newRow["serialNo"] = image.ImageButtonValue.nSerialNo.ToString();
                        newRow["userId"] = SessionInfo.userId;

                        saveDt.Rows.Add(newRow);
                    }
                }
            }

            if (saveDt != null && saveDt.Rows.Count > 0)
            {
                KeyValueData param = new KeyValueData();
                param.Add("Data1", saveDt.DataTableToStringForServer());
                CallResultData result = this.callService.SelectSql("reqSetViewerImageSendDicom", param);
                if (result.resultState == ResultState.OK)
                {
                    //PASS
                    Global.logHelper.WriteLog("viewerSendResult", LogType.INFO, ActionType.CALL_DB, "Viewer결과전송(선택영상)", "DB 저장 성공", studyId: studyId);
                }
                else
                {
                    //실패에 대한 처리
                    DevExpress.XtraEditors.XtraMessageBox.Show("선택영상 결과전송에 실패하였습니다.");
                    Global.logHelper.WriteLog("viewerSendResult", LogType.ERROR, ActionType.CALL_DB, "Viewer결과전송(선택영상)", "DB 저장 실패", studyId: studyId);
                }
            }

            //재조회
            this.SearchData(reSelectStudyId: selectedItem["studyId"].ToString());

        }




        /// <summary>
        /// name         : menu_ItemEdit
        /// desc         : 이미지편집(응용프로그램) 메뉴 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-19 08:39
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menu_ItemEdit()
        {
            List<ImageContainer> imagelist = GetImageList();
            List<ImageContainer> selectedImageList = imagelist.Where(e => e.IsSelected == true).ToList();

            if (selectedImageList == null || selectedImageList.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("편집할 영상을 선택하십시오.");
                return;
            }

            //XtraMessageBox.Show

            ImageContainer image = selectedImageList[0];


            string path = g_PathData.strPhotoshopPath;
            FileInfo file = new FileInfo(path);

            using (Process compiler = new Process())
            {
                compiler.StartInfo.FileName = path;
                string arg = string.Format("\"{0}\"", image.ImageButtonValue.strRowFilePath);
                compiler.StartInfo.Arguments = arg;
                //compiler.StartInfo.Arguments = "\"" + jsonValue + "\"" ;

                compiler.StartInfo.UseShellExecute = false;
                compiler.StartInfo.RedirectStandardOutput = true;
                compiler.StartInfo.WorkingDirectory = file.DirectoryName;
                compiler.Start();

                Console.WriteLine(compiler.StandardOutput.ReadToEnd());
            }

        }

        /// <summary>
        /// name         : menu_ItemPrint
        /// desc         : 이미지 인쇄 메뉴 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-18 13:29
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menu_ItemPrint()
        {
            DataRow row = grvOrder.GetFocusedDataRow();
            //OrderDTO selectedItem = null;
            List<ImageContainer> imageList = null;


            //if (grvOrder.DataSource != null && grvOrder.DataSource is List<OrderDTO>)
            //{
            //    List<OrderDTO> selectedItems = SelectedRows<OrderDTO>(ref grvOrder);

            //    if (selectedItems != null && selectedItems.Count > 0)
            //    {
            //        selectedItem = selectedItems[0];
            //    }
            //}

            if (this.selectedItem == null) return;

            imageList = GetImageList();


            ImagePrintPopup imagePrintPopup = new ImagePrintPopup();
            imagePrintPopup.SendData(this.selectedItem, imageList);
            imagePrintPopup.ShowDialog();
        }



        /// <summary>
        /// name         : SelectedRows
        /// desc         : 그리드 뷰에서 선택된 아이템 리스트를 리턴한다.
        /// author       : 심우종
        /// create date  : 2020-03-18 15:11
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private List<T> SelectedRows<T>(ref Sedas.Control.GridControl.HGridView gridView)
        {
            List<T> dataList = gridView.DataSource as List<T>;
            List<T> selectedItems = new List<T>();

            int[] selectedIndexs = grvOrder.GetSelectedRows();
            if (selectedIndexs != null && selectedIndexs.Length > 0)
            {
                for (int i = 0; i < selectedIndexs.Length; i++)
                {
                    T selectedItem = dataList[i];
                    selectedItems.Add(selectedItem);
                }
            }

            return selectedItems;
        }



        private void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }


        /// <summary>
        /// name         : menuGrid_ToExcel
        /// desc         : 그리드 내용을 엑셀로 출력한다.
        /// author       : 심우종
        /// create date  : 2020-03-18 09:07
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menuGrid_ToExcel()
        {
            //this.GridControlToExcel(this.grvOrder, true, true, excelPath: g_PathData.strExcelPath);
            this.GridControlToExcelByClosedXML(this.grvOrder, true, true, excelPath: g_PathData.strExcelPath);
        }



        private void GridControlToExcelByClosedXML(Sedas.Control.GridControl.HGridView grdView, bool titleYn = true, bool borderYn = true, string excelPath = "")
        {
            //설정 옵션
            /////////////////////////////////////////////////////////
            //bool titleYn = true; //타이틀 표시여부
            //bool borderYn = true; //Border 필요여부
            ////////////////////////////////////////////////////////
            ///
            //var workbook = new XLWorkbook("양식있는빈엑셀.xlsx");  // 기존 엑셀 열기

            var workbook = new XLWorkbook(); // 새 엑셀 열기


            var worksheet = workbook.Worksheets.Add("Sheet1");  // 빈 sheet추가하기
            //var worksheet = workbook.Worksheet(1);  // 첫번째 sheet열기

            //var worksheet = workbook.Worksheets.Add("Sheet1");  // 빈 sheet추가하기

            int num = 0;
            object missingType = Type.Missing;
            //string[] headers = new string[dgvList.ColumnCount];
            string[] columns = new string[grdView.Columns.Count];
            string[] columnsFieldName = new string[grdView.Columns.Count];

            for (int c = 0; c < grdView.Columns.Count; c++)
            {
                //headers[c] = dgvList.Rows[0].Cells[c].OwningColumn.HeaderText.ToString();
                num = c + 65;
                columns[c] = Convert.ToString((char)num);
                columnsFieldName[c] = grdView.Columns[c].FieldName.ToString();
            }

            //해더 표시
            if (titleYn == true)
            {
                if (grdView.Columns != null && grdView.Columns.Count > 0)
                {
                    for (int i = 0; i < grdView.Columns.Count; i++)
                    {


                        worksheet.Cell(columns[i] + "1").Value = grdView.Columns[i].Caption.ToString();
                        worksheet.Cell(columns[i] + "1").Style.Font.Bold = true;

                        worksheet.Columns(columns[i]).Width = Math.Round((Double)(grdView.Columns[i].Width / 6));

                        //range.ColumnWidth = Math.Round((Double)(grdView.Columns[i].Width / 6));
                        //해더 정렬
                        if (grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Center)
                        {
                            //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            worksheet.Cell(columns[i] + "1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        else if (grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Near)
                        {
                            //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            worksheet.Cell(columns[i] + "1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }
                        else if (grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Far)
                        {
                            //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                            worksheet.Cell(columns[i] + "1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }
                    }
                }

                //worksheet.Columns(columns[0], columns[grdView.Columns.Count-1]).AdjustToContents();
            }


            if (grdView.DataRowCount > 0)
            {
                for (int i = 0; i < grdView.DataRowCount; i++)
                {
                    for (int j = 0; j < columnsFieldName.Length; j++)
                    {
                        object value = grdView.GetRowCellValue(i, columnsFieldName[j].ToString());
                        if (value != null)
                        {



                            worksheet.Cell(columns[j] + Convert.ToString(i + 2)).Value = "'" + value.ToString();


                            //range = objSheet.get_Range(columns[j] + Convert.ToString(i + 2), Missing.Value);
                            //// 문자로 변환하기 위해서 "'" 추가
                            //range.set_Value(Missing.Value, "'" + value.ToString());

                            //정렬
                            if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Center)
                            {
                                //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                worksheet.Cell(columns[j] + Convert.ToString(i + 2)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            }
                            else if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Near)
                            {
                                //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                                worksheet.Cell(columns[j] + Convert.ToString(i + 2)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            }
                            else if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Far)
                            {
                                //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                worksheet.Cell(columns[j] + Convert.ToString(i + 2)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            }


                        }

                    }
                }
            }

            //테두리 그리기
            if (borderYn == true)
            {
                worksheet.Range("A1", columns[columns.Length - 1].ToString() + (grdView.DataRowCount + 1).ToString()).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                worksheet.Range("A1", columns[columns.Length - 1].ToString() + (grdView.DataRowCount + 1).ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                //range = objSheet.get_Range("A1", columns[columns.Length - 1] + (grdView.DataRowCount + 1).ToString());
                ////선 종류
                //range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                ////선 두께
                //range.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            }


            string strFileName = "";
            if (!string.IsNullOrEmpty(excelPath))
            {
                strFileName = excelPath + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xlsx";
            }
            else
            {
                strFileName = System.Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".xlsx";
            }


            workbook.SaveAs(strFileName);  // 새로운 이름으로 저장하기

            //objApp.ScreenUpdating = true;

            //objBook.SaveAs(strFileName,
            //            Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
            //            missingType, missingType, missingType, missingType,
            //            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            //            missingType, missingType, missingType, missingType, missingType);
            //objBook.Close(false, missingType, missingType);

            //Cursor.Current = Cursors.Default;

            Process process = new Process();
            process.StartInfo.FileName = strFileName;
            process.Start();




            //worksheet.Cell("B3").Value = "데이터넣기";  // B3에 값 넣기

            //worksheet.Cell(3, 2).Value = "데이터넣기";   // 3행, 2열 즉 B3에 값 넣기
        }


        /// <summary>
        /// name         : GridControlToExcel
        /// desc         : 그리드 컨트롤 내용을 엑셀로 출력한다.
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void GridControlToExcel(Sedas.Control.GridControl.HGridView grdView, bool titleYn = true, bool borderYn = true, string excelPath = "")
        {
            //설정 옵션
            /////////////////////////////////////////////////////////
            //bool titleYn = true; //타이틀 표시여부
            //bool borderYn = true; //Border 필요여부
            ////////////////////////////////////////////////////////


            //Sedas.Control.GridControl.HGridView grdView = this.hGridView1;


            int num = 0;
            object missingType = Type.Missing;

            Microsoft.Office.Interop.Excel.Application objApp = null;
            Microsoft.Office.Interop.Excel._Workbook objBook = null;
            Microsoft.Office.Interop.Excel.Workbooks objBooks = null;
            Microsoft.Office.Interop.Excel.Sheets objSheets = null;
            Microsoft.Office.Interop.Excel._Worksheet objSheet = null;
            Microsoft.Office.Interop.Excel.Range range = null;


            //string[] headers = new string[dgvList.ColumnCount];
            string[] columns = new string[grdView.Columns.Count];
            string[] columnsFieldName = new string[grdView.Columns.Count];

            for (int c = 0; c < grdView.Columns.Count; c++)
            {
                //headers[c] = dgvList.Rows[0].Cells[c].OwningColumn.HeaderText.ToString();
                num = c + 65;
                columns[c] = Convert.ToString((char)num);
                columnsFieldName[c] = grdView.Columns[c].FieldName.ToString();
            }

            try
            {
                objApp = new Microsoft.Office.Interop.Excel.Application();
                objBooks = objApp.Workbooks;
                objBook = objBooks.Add(Missing.Value);
                objSheets = objBook.Worksheets;
                objSheet = (Microsoft.Office.Interop.Excel._Worksheet)objSheets.get_Item(1);
                objApp.ScreenUpdating = false;
                //if (captions)
                //{
                //    for (int c = 0; c < dgvList.ColumnCount; c++)
                //    {

                //        range = objSheet.get_Range(columns[c] + "1", Missing.Value);
                //        range.set_Value(Missing.Value, headers[c]);
                //    }
                //}

                //해더 표시
                if (titleYn == true)
                {
                    if (grdView.Columns != null && grdView.Columns.Count > 0)
                    {
                        for (int i = 0; i < grdView.Columns.Count; i++)
                        {
                            range = objSheet.get_Range(columns[i] + "1", Missing.Value);
                            range.set_Value(Missing.Value, grdView.Columns[i].Caption.ToString());
                            range.Font.Bold = true;

                            //컬럼 사이즈 지정할때는 여기서 하자...
                            range.Columns.AutoFit();

                            range.ColumnWidth = Math.Round((Double)(grdView.Columns[i].Width / 6));
                            //해더 정렬
                            if (grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Center)
                            {
                                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            }
                            else if (grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Near)
                            {
                                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            }
                            else if (grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Far)
                            {
                                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                            }
                        }
                    }
                }

                //DataTable dt = grdOrder.DataSource as DataTable;
                //DataTable dt = (grdView.DataSource as DataView).Table;


                //string value = "";
                //if (dt != null && dt.Rows.Count > 0)
                //{
                //    range = (Microsoft.Office.Interop.Excel.Range)objSheet.Cells[1, 1];
                //    int i = 0;
                //    foreach (DataRow row in dt.Rows)
                //    {
                //        for (int j = 0; j < columnsFieldName.Length; j++)
                //        {
                //            if (dt.Columns.Contains(columnsFieldName[j].ToString()) == true)
                //            {
                //                value = row[columnsFieldName[j].ToString()].ToString();
                //                if (value != null)
                //                {
                //                    range = objSheet.get_Range(columns[j] + Convert.ToString(i + 2), Missing.Value);
                //                    //range = range.get_Resize(i+2, j);
                //                    // 문자로 변환하기 위해서 "'" 추가
                //                    range.set_Value(Missing.Value, "'" + value);

                //                    //정렬
                //                    //if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Center)
                //                    //{
                //                    //    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                //                    //}
                //                    //else if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Near)
                //                    //{
                //                    //    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                //                    //}
                //                    //else if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Far)
                //                    //{
                //                    //    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                //                    //}


                //                }
                //            }
                //            //object value = grdView.GetRowCellValue(i, columnsFieldName[j].ToString());

                //        }

                //        i++;
                //    }


                //}


                //그리드 내용 출력
                if (grdView.DataRowCount > 0)
                {
                    for (int i = 0; i < grdView.DataRowCount; i++)
                    {
                        for (int j = 0; j < columnsFieldName.Length; j++)
                        {
                            object value = grdView.GetRowCellValue(i, columnsFieldName[j].ToString());
                            if (value != null)
                            {
                                range = objSheet.get_Range(columns[j] + Convert.ToString(i + 2), Missing.Value);
                                // 문자로 변환하기 위해서 "'" 추가
                                range.set_Value(Missing.Value, "'" + value.ToString());

                                //정렬
                                if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Center)
                                {
                                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                }
                                else if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Near)
                                {
                                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                                }
                                else if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Far)
                                {
                                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                }


                            }

                        }
                    }
                }

                //테두리 그리기
                if (borderYn == true)
                {
                    range = objSheet.get_Range("A1", columns[columns.Length - 1] + (grdView.DataRowCount + 1).ToString());
                    //선 종류
                    range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    //선 두께
                    range.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                }





                //List<OrderDTO> orderList = hGridView1.DataSource as List<OrderDTO>;

                //if (hGridView1.Columns != null && )



                //range = objSheet.get_Range("A2", Missing.Value);
                //range.set_Value(Missing.Value, "test");



                //for (int i = 0; i < dgvList.RowCount; i++)
                //{
                //    for (int j = 0; j < dgvList.ColumnCount; j++)
                //    {
                //        range = objSheet.get_Range(columns[j] + Convert.ToString(i + 2),
                //                                                Missing.Value);
                //        range.set_Value(Missing.Value,
                //                                dgvList.Rows[i].Cells[j].Value.ToString());
                //    }
                //}


                // "C: \Users\SJS\Desktop"


                objApp.Visible = false;
                objApp.UserControl = false;


                string strFileName = "";
                if (!string.IsNullOrEmpty(excelPath))
                {
                    strFileName = excelPath + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xls";
                }
                else
                {
                    strFileName = System.Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".xls";
                }

                objApp.ScreenUpdating = true;

                objBook.SaveAs(strFileName,
                            Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                            missingType, missingType, missingType, missingType,
                            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                            missingType, missingType, missingType, missingType, missingType);
                objBook.Close(false, missingType, missingType);

                Cursor.Current = Cursors.Default;

                Process process = new Process();
                process.StartInfo.FileName = strFileName;
                process.Start();
                //MessageBox.Show("Save Success!!!");
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                DevExpress.XtraEditors.XtraMessageBox.Show(errorMessage, "Error");
            }
            finally
            {
                ReleaseExcelObject(objApp);
                ReleaseExcelObject(objBook);
                ReleaseExcelObject(objBooks);
                ReleaseExcelObject(objSheets);
                ReleaseExcelObject(objSheet);
            }
        }

        /// <summary>
        /// name         : menu_itemChageNo
        /// desc         : ContextMenu 이미지 병리번호 변경
        /// author       : 심우종
        /// create date  : 2020-03-18 09:07
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menu_itemChageNo()
        {
            List<ImageContainer> imagelist = GetImageList();
            List<ImageContainer> selectedImageList = imagelist.Where(e => e.IsSelected == true).ToList();

            if (selectedImageList == null || selectedImageList.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("선택된 이미지가 없습니다.");
                return;
            }

            if (this.selectedItem == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("병리번호를 선택해 주세요");
                return;
            }


            ChangeNumPopup changeNumPopup = new ChangeNumPopup();
            changeNumPopup.ShowDialog();

            if (changeNumPopup.DialogResult == DialogResult.OK)
            {
                if (this.selectedItem["ptoNo"].ToString() == changeNumPopup.ptoNo)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("동일한 병리번호 입니다.");
                    return;
                }

                if (string.IsNullOrEmpty(changeNumPopup.studyId) || string.IsNullOrEmpty(changeNumPopup.ptoNo))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("변경할 병리번호를 찾을수 없습니다.");
                    return;
                }

                KeyValueData param = new KeyValueData();
                param.Add("changedStudyId", changeNumPopup.studyId);
                param.Add("changedPtoNo", changeNumPopup.ptoNo);
                param.Add("changedGI", changeNumPopup.gi);
                param.Add("changedMI", changeNumPopup.mi);
                param.Add("changedOI", changeNumPopup.oi);

                this.SaveImageData(changedPatNoParam: param);
            }


        }




        /// <summary>
        /// name         : menu_itemPaste
        /// desc         : ContextMenu 이미지 내보내기
        /// author       : 심우종
        /// create date  : 2020-05-07 08:59
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menu_itemPaste()
        {

            List<ImageContainer> imageList = this.GetImageList();
            if (imageList == null || imageList.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("따로 저장할 영상을 선택하십시오.");
                return;
            }

            List<ImageContainer> selectedImages = imageList.Where(e => e.IsSelected == true && !string.IsNullOrEmpty(e.Path)).ToList();
            if (selectedImages.Count == 0)
            {
                //선택된 이미지가 없을경우
                DevExpress.XtraEditors.XtraMessageBox.Show("따로 저장할 영상을 선택하십시오.");
                return;
            }



            SaveFileDialog ofd = new SaveFileDialog();
            //ofd.Multiselect = true;
            ofd.Filter = "jpg(*.*)|*.jpg*";
            DialogResult drs = ofd.ShowDialog();
            if (drs == DialogResult.OK)
            {
                string fileName = ofd.FileName;

                int fileNameDivideIndex = fileName.LastIndexOf("\\");
                string path = fileName.Substring(0, fileNameDivideIndex + 1);
                string name = fileName.Substring(fileNameDivideIndex + 1, fileName.Length - fileNameDivideIndex - 1);

                if (selectedImages.Count > 1)
                {

                    int tempCount = 1;
                    //2개 이상인 경우
                    for (int i = 0; i < selectedImages.Count; i++)
                    {
                        ImageContainer image = selectedImages[i];




                        string strCount = tempCount.ToString();

                        for (int j = 0; j < 5; j++)
                        {
                            if (strCount.Length == 5)
                            {
                                break;
                            }

                            strCount = "0" + strCount;
                        }


                        File.Copy(image.Path, path + name + strCount + ".jpg");

                        tempCount++;
                    }
                }
                else
                {
                    ImageContainer image = selectedImages[0];
                    File.Copy(image.Path, path + name + ".jpg");
                }

                //for()
                //for (int i = 0; i < ofd.FileNames.Length; i++)
                //{
                //    string strPath = ofd.FileNames[i].ToString();
                //    string File_Full_path = Global.strPath + "\\" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                //    DirectoryInfo di = new DirectoryInfo(File_Full_path);
                //    if (!di.Exists)
                //    {
                //        di.Create();
                //    }
                //    File_Full_path = File_Full_path + "\\" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".jpg";
                //    File.Copy(strPath, File_Full_path);

                //    this.ImageAdd(strPath);

                //    //ImgThumbnail(strPath);
                //}

                DevExpress.XtraEditors.XtraMessageBox.Show("이미지가 저장되었습니다.");
            }
        }

        List<ImageButtonValue> deleteImage = new List<ImageButtonValue>(); //삭제처리가 필요한 이미지 정보

        /// <summary>
        /// name         : menu_itemDelete
        /// desc         : 이미지 삭제 클릭시
        /// author       : 심우종
        /// create date  : 2020-05-07 08:59
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menu_itemDelete()
        {
            //List<ImageContainer> imageList = new List<ImageContainer>();


            if (this.ImageList.Where(e => e.IsSelected == true).Count() == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("삭제할 영상을 선택하십시오");
                return;
            }


            if (flwpnlImage.Controls.Count > 0)
            {
                for (int i = this.flwpnlImage.Controls.Count - 1; i >= 0; i--)
                {
                    if (this.flwpnlImage.Controls[i] is ImageContainer)
                    {
                        ImageContainer image = this.flwpnlImage.Controls[i] as ImageContainer;
                        if (image != null)
                        {
                            if (image.IsSelected == true)
                            {
                                if (image.ImageButtonValue != null)
                                {
                                    if (string.IsNullOrEmpty(image.ImageButtonValue.strSaveFilePath))
                                    {
                                        //아직 저장되지 않은 이미지 Db작업 없이 그냥 화면에서 삭제처리함.
                                    }
                                    else
                                    {
                                        this.deleteImage.Add(image.ImageButtonValue);
                                    }
                                }

                                this.flwpnlImage.Controls.Remove(image);
                            }
                        }
                    }
                }
            }




            if (DevExpress.XtraEditors.XtraMessageBox.Show("변경된 상태를 저장 하시겠습니까?", "이미지 저장", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                if (this.SaveImageData() == false)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지 저장 실패");
                    return;
                }
            }
        }




        /// <summary>
        /// name         : menu_itemCopy
        /// desc         : 이미지 추가 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-05-07 08:59
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menu_itemCopy()
        {
            OpenFileWithImageType ofd = new OpenFileWithImageType();
            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Multiselect = true;
            ofd.Filter = "jpg(*.*)|*.jpg*";
            DialogResult drs = ofd.ShowDialog();
            if (drs == DialogResult.OK)
            {
                for (int i = 0; i < ofd.Files.Count; i++)
                {
                    string strPath = ofd.Files[i].ToString();
                    //string File_Full_path = Global.strPath + "\\" + DateTime.Now.ToString("yyyyMMddhhmmssfff");
                    //DirectoryInfo di = new DirectoryInfo(File_Full_path);
                    //if (!di.Exists)
                    //{
                    //    di.Create();
                    //}
                    //File_Full_path = File_Full_path + "\\" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".jpg";
                    //File.Copy(strPath, File_Full_path);


                    ImageButtonValue data = new ImageButtonValue();
                    data.bSelect = false;
                    data.strPathologyNum = "";
                    data.nImageNum = -1;
                    data.nSendStatus = -1;
                    data.nType = -1;
                    data.nGI = -1;
                    data.nMI = -1;
                    data.nOI = -1;

                    data.strRowFilePath = strPath;
                    data.nType = ofd.imageType;

                    this.ImageAdd(strPath, true, imageButtonValue: data);
                }
            }
        }
        #endregion


        private void ImagePanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                popupMenu1.ShowPopup(Control.MousePosition);
            }
        }

        private void ImagePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void layoutControl1_PopupMenuShowing(object sender, DevExpress.XtraLayout.PopupMenuShowingEventArgs e)
        {
            e.Menu.Items.Add(new DXMenuItem("&조회", new EventHandler(test)));
        }

        private void test(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// name         : barSetting_ItemClick
        /// desc         : 환경설정 메뉴 클릭시
        /// author       : 심우종
        /// create date  :  
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void barSetting_ItemClick(object sender, ItemClickEventArgs e)
        {
            SettingPopup popup = new SettingPopup();
            popup.ShowDialog();

            if (popup.DialogResult == DialogResult.OK) //환경설정 완료 후 
            {
                //Global 환경 변수 재설정
                this.InitGlobalData();
                this.InitControls();
            }

        }


        /// <summary>
        /// name         : barVersionInfo_ItemClick
        /// desc         : DGS_Viewer 정보(A) 메뉴 클릭시
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void barVersionInfo_ItemClick(object sender, ItemClickEventArgs e)
        {
            VersionInfoPopup versionInfoPopup = new VersionInfoPopup();
            versionInfoPopup.ShowDialog();
        }


        /// <summary>
        /// name         : chkStDt_CheckedChanged
        /// desc         : 기간검색 날짜 시작일자 체크박스 변경시
        /// author       : 심우종
        /// create date  : 2020-04-21 14:01
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void chkStDt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.isPeriodChanged == true) return;
            this.isPeriodChanged = true;
            this.DateCheckBoxChanged();

            if (chkStDt.Checked == true)
            {
                dtpStart.Enabled = true;
            }
            else
            {
                dtpStart.Enabled = false;
            }

            isPeriodChanged = false;
        }

        bool isPeriodChanged = false;

        /// <summary>
        /// name         : chkEdDt_CheckedChanged
        /// desc         : 기간검색 날짜 시작일자 체크박스 변경시
        /// author       : 심우종
        /// create date  : 2020-04-21 14:27
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void chkEdDt_CheckedChanged(object sender, EventArgs e)
        {
            if (this.isPeriodChanged == true) return;
            this.isPeriodChanged = true;

            this.DateCheckBoxChanged();

            if (chkEdDt.Checked == true)
            {
                dtpEnd.Enabled = true;
            }
            else
            {
                dtpEnd.Enabled = false;
            }

            this.isPeriodChanged = false;
        }


        /// <summary>
        /// name         : DateCheckBoxChanged
        /// desc         : 기간검색 날짜 체크박스 변경시
        /// author       : 심우종
        /// create date  : 2020-04-21 14:27
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void DateCheckBoxChanged()
        {
            if (chkStDt.Checked == true || chkEdDt.Checked == true)
            {
                InitCmbWeek(isNeedToPeriod: true);
                this.cmbWeek.EditValue = "-002"; //기간검색
            }
            else
            {
                InitCmbWeek();
            }
        }


        /// <summary>
        /// name         : cmbWeek_SelectedValueChanged
        /// desc         : 기간검색 콤보박스 선택 변경시
        /// author       : 심우종
        /// create date  : 2020-04-21 14:37
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void cmbWeek_SelectedValueChanged(object sender, EventArgs e)
        {
            if (this.isPeriodChanged == true) return;
            this.isPeriodChanged = true;

            if (this.cmbWeek.SelectedItem != null && this.cmbWeek.SelectedItem.ToString() != "기간검색")
            {
                this.chkStDt.Checked = false;
                this.chkEdDt.Checked = false;
                this.dtpStart.Enabled = false;
                this.dtpEnd.Enabled = false;
            }

            if (cmbWeek.Properties.Items.Where(o => o.Description == "기간검색").Count() > 0)
            {
                cmbWeek.Properties.Items.Remove(cmbWeek.Properties.Items.Where(o => o.Description == "기간검색").FirstOrDefault());
            }

            this.isPeriodChanged = false;


        }


        /// <summary>
        /// name         : txtBox_KeyDown
        /// desc         : 텍스트박스 키다운 이벤트
        /// author       : 심우종
        /// create date  : 2020-04-21 16:26
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void txtBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.SearchData();
            }
        }

        /// <summary>

        /// Byte를 File로 변환합니다.

        /// </summary>

        /// <author> Kim Se Hoon </author>

        /// <param name="source"> 대상 byte[] </param>

        /// <param name="filename"> 파일명 (상대 or 절대)</param>

        private void ByteToFile(byte[] source, string filename)
        {
            /// Create Mode로 FileStream을 오픈합니다.
            FileStream file = new FileStream(filename, FileMode.Create);

            /// Byte에 있는 내용을 File에 씁니다.
            file.Write(source, 0, source.Length);

            /// 파일을 닫습니다.
            file.Close();
        }

        //FileTransfer ft = new FileTransfer("10.10.50.143", "28080");
        //FileTransfer ft = new FileTransfer("10.10.221.71", "1111");

        private void FileDownloadTest()
        {
            string localPath = "D:\\LocalData";
            string serverPathAndName = "Imagedata\\20200521\\M0000001\\202005251036350.jpg";

            for (int i = 0; i < 20; i++)
            {
                string savedFilePath = "";
                //[파일 다운로드]
                //serverPathAndName : 서버에서 다운받을 파일 경로 (ex : Imagedata\20200521\M0000001\202005211629240.jpg)
                //localPath : 다운로드 되는 경로 지정 (ex : D:\\LocalData)
                //savedFilePathAndName : 다운완료 후 로컬파일경로 ( ex : D:\\LocalData\\202005211628170.jpg)
                //[옵션] isNeedToDupNameChange (디폴트 true) : 파일 다운시 동일한 이름에 대해서 이름을 변경할지 여부 파일(1).jpg, 파일(2).jpg 형태로 자동 변경됨
                if (ft.FileDownLoad(serverPathAndName, localPath, ref savedFilePath) == true)
                {
                    //저장성공
                }
                else
                {

                }
            }
        }

        private void FileUploadTest()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "jpg(*.*)|*.jpg*";
            DialogResult drs = ofd.ShowDialog();
            string localPathAndName = "";

            //FileTransfer ft = new FileTransfer("10.10.221.71", "1111");



            if (drs == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    localPathAndName = ofd.FileNames[i].ToString();


                    DateTime current = DateTime.Now;
                    string serverPathAndName = "imagedata\\";
                    string tempPath = current.ToString("yyyyMMdd") + "\\";
                    serverPathAndName = serverPathAndName + tempPath;


                    //Directory.CreateDirectory(filePath);

                    tempPath = "M0000001" + "\\";
                    serverPathAndName = serverPathAndName + tempPath;

                    //Directory.CreateDirectory(filePath);
                    serverPathAndName = serverPathAndName + current.ToString("yyyyMMddHHmmss") + i.ToString() + ".jpg";


                    //[파일 업로드]
                    //localPathAndName : 로컬 파일 경로 ( ex : C:\Users\tk321\OneDrive\사진\Screenshots\1.JPG)
                    //serverPathAndName : 서버에 저장될 파일 경로 (ex : Imagedata\20200521\M0000001\202005211629240.jpg)
                    if (ft.FileUpload(localPathAndName, serverPathAndName) == true)
                    {
                        //저장성공
                    }

                }
            }
        }

        private void DirectoryExistsTest()
        {

            string serverPath = "Imagedata\\20200525\\M0000001";
            //[디렉토리 존재여부 확인]
            //serverPath : 서버 디렉토리 경로 (ex : Imagedata\\20200525\\M0000001)

            for (int i = 0; i < 1000; i++)
            {
                if (ft.DirectoryExists(serverPath) == true)
                {

                }
            }

        }


        private void MakeDirectoryTest()
        {
            string serverPath = "Imagedata\\test1\\test2\\S000001";
            //[디렉토리 생성]
            //serverPath : 서버 디렉토리 경로 (ex : Imagedata\\test1\\test2\\S000001)
            if (ft.MakeDirectory(serverPath) == true)
            {

            }
        }

        private void DeleteFileTest()
        {
            string serverPathAndName = "Imagedata\\20200525\\M0000001\\202005251036350.jpg";
            //[파일삭제]
            //serverPathAndName : 삭제할 서버 파일 경로 (ex : Imagedata\\test1\\test2\\S000001)
            if (ft.DeleteFile(serverPathAndName) == true)
            {

            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            //FileDownloadTest();
            //FileUploadTest();
            DirectoryExistsTest();
            //MakeDirectoryTest();
            //DeleteFileTest();

            return;

            //string serverPathAndName = "Imagedata\\20200521\\M0000001\\202005211626111.jpg";
            string localPath = "D:\\LocalData";

            //if (ft.FileDownLoad(serverPathAndName, localPath, isSync: false) == true)
            //{
            //    //저장성공
            //}

            string serverPathAndName2 = "Imagedata\\20200521\\M0000001\\202005211628170.jpg";
            //string localPath = "D:\\LocalData";

            for (int i = 0; i < 5; i++)
            {
                string savedFilePath = "";
                if (ft.FileDownLoad(serverPathAndName2, localPath, ref savedFilePath) == true)
                {
                    //저장성공
                }
            }





            return;

            //파일 업로드
            //FileUpliadTest();

            return;

            sFTP ftpdll = new sFTP();
            //string ftpPath = "//10.20.210.139//kuh-keis2//imagedata";
            string ftpPath = "ftp://10.20.210.139//kuh-keis2//imagedata";
            string user = "kuhkeis";

            string pwd = "keis123!";


            bool result = ftpdll.FTPDirectioryCheck(ftpPath, user, pwd);




            return;



            //ftpdll.FtpUpload();


            //if (!ftpdll.FtpDownload(Ini.FTPPath + rootFile, Ini.FTPID, Ini.FTPPWD, fileName))
            //{
            //    MessageBox.Show("FTP 다운실패");
            //}
            //OpenFileWithImageType ofd = new OpenFileWithImageType();
            //ofd.DefaultExt = "sql";
            //ofd.EncodingType = EncodingType.UTF8;
            //ofd.Filter = "jpg(*.*)|*.jpg*";
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    if (ofd.Files != null && ofd.Files.Count > 0)
            //    {
            //        int imageCount = 0;
            //        foreach (string str in ofd.Files)
            //        {
            //            imageCount++;

            //            DateTime current = DateTime.Now;
            //            string fileName = "A" + current.ToString("yyyyMMddHHmmss") + imageCount + ".jpg";

            //            //ftp



            //            //string inputFile
            //            //ftpdll.FtpUpload()
            //        }
            //    }
            //}

            //ftpdll.FtpUpload()


            return;
            //OpenFileWithImageType ofd = new OpenFileWithImageType();
            //ofd.DefaultExt = "sql";
            //ofd.EncodingType = EncodingType.UTF8;
            //ofd.Filter = "jpg(*.*)|*.jpg*";
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    MessageBox.Show(String.Format("Name={0}, Encoding={1}", ofd.FileName, ofd.EncodingType));
            //}

            //return;

            //ImageContainer image = GetImageList().FirstOrDefault(); ;
            //FileStream fs = new FileStream(image.ImageButtonValue.strRowFilePath, FileMode.Open, FileAccess.Read);
            //BinaryReader br = new BinaryReader(fs);
            //byte[] imageBytes = br.ReadBytes((int)fs.Length);
            //String imageStr = Encoding.Default.GetString(imageBytes);



            //ByteToFile(imageBytes, "C:\\Users\\tk321\\OneDrive\\사진\\Screenshots\\1 - 복사본2.JPG");


            //return;

            //ImageContainer image = GetImageList().FirstOrDefault(); ;
            //string ptoNo = this.selectedItem["ptoNo"].ToString();

            //BlobClass blob = new BlobClass();

            //blob.UpdateBlob(ptoNo, image.ImageButtonValue.strRowFilePath);




            return;
            KeyValueData test = new KeyValueData();
            test.Add("key1", "test1");
            test.Add("key2", "test2");
            test.Add("key3", "test3");

            DevExpress.XtraEditors.XtraMessageBox.Show(test["key1"].ToString());
            test["key1"] = "2";
            DevExpress.XtraEditors.XtraMessageBox.Show(test["key1"].ToString());
            return;

            //OpenFileWithImageType ofd = new OpenFileWithImageType();
            //ofd.DefaultExt = "sql";
            //ofd.EncodingType = EncodingType.UTF8;
            //ofd.Filter = "jpg(*.*)|*.jpg*";
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    MessageBox.Show(String.Format("Name={0}, Encoding={1}", ofd.FileName, ofd.EncodingType));
            //}

            return;



            //SaveFileDialogWithEncoding ofd = new SaveFileDialogWithEncoding();
            //ofd.DefaultExt = "sql";
            //ofd.EncodingType = EncodingType.UTF8;
            //ofd.Filter = "SQL files (*.sql)|*.sql|All files (*.*)|*.*";
            //if (ofd.ShowDialog() == DialogResult.OK)
            //{
            //    MessageBox.Show(String.Format("Name={0}, Encoding={1}", ofd.FileName, ofd.EncodingType));
            //}




            return;

            //ShellExecute(GetStringTOintPtr("0"), "open", "C:\\BASE\\SedasSolutions\\SedasPhoto\\SedasPhoto\\bin\\Debug\\SedasPhotoMagic.exe", "SedasPhotoMagic.exe", "C:\\BASE\\SedasSolutions\\SedasPhoto\\SedasPhoto\\bin\\Debug\\", 5);
            //string filePath = "";
            //if (this.ImageList != null && this.ImageList.Count > 0)
            //{
            //    ImageContainer image = this.ImageList.AsEnumerable().Where(o => o.IsSelected == true).FirstOrDefault();
            //    if (image != null)
            //    {
            //        if (!string.IsNullOrEmpty(image.ImageButtonValue.strRowFilePath))
            //        {
            //            filePath = image.ImageButtonValue.strRowFilePath;
            //        }
            //    }
            //}


            //using (Process compiler = new Process())
            //{

            //    compiler.StartInfo.FileName = "C:\\BASE\\SedasSolutions\\SedasPhoto\\SedasPhoto\\bin\\Debug\\SedasPhotoMagic.exe";
            //    compiler.StartInfo.Arguments = filePath;
            //    compiler.StartInfo.UseShellExecute = false;
            //    compiler.StartInfo.RedirectStandardOutput = true;
            //    compiler.Start();

            //    Console.WriteLine(compiler.StandardOutput.ReadToEnd());

            //    compiler.WaitForExit();
            //}
        }



        public IntPtr GetStringTOintPtr(string data)
        {
            return Marshal.StringToHGlobalAnsi(data);
        }


        /// <summary>
        /// name         : grvOrder_DoubleClick
        /// desc         : 그리드 데이터 더블클릭시
        /// author       : 심우종
        /// create date  : 2020-04-22 17:12
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary>  
        private void grvOrder_DoubleClick(object sender, EventArgs e)
        {
            ShowImage();
        }




        /// <summary>
        /// name         : ShowImage
        /// desc         : 선택한 그리드 기준으로 이미지를 불러온다.
        /// author       : 심우종
        /// create date  : 2020-04-22 17:13
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ShowImage()
        {
            DataRow selectedRow = this.grvOrder.GetFocusedDataRow();


            if (selectedRow != null)
            {


                string studyId = selectedRow["studyId"].ToString();
                string ptoNo = selectedRow["ptoNo"].ToString();

                if (!string.IsNullOrEmpty(studyId))
                {
                    if (this.ShowImages(studyId, selectedRow) == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("영상보기 실패");
                        return;
                    }
                }

                this.selectedItem = selectedRow;
                this.SetMessage("선택된 데이터 : " + ptoNo, headerMessage: ptoNo);


            }
        }

        private void tlpTop_Paint(object sender, PaintEventArgs e)
        {

        }


        /// <summary>
        /// name         : barClose_ItemClick
        /// desc         : 종료버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-11 15:36
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void barClose_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Close();
        }

        private void cmbChar_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbChar.SelectedIndex > -1)
            {

                string value = this.cmbChar.Properties.Items[this.cmbChar.SelectedIndex].Value.ToString();
                //Global.G_IniWriteValue("DGSDB", "SETTINGTYPE", value, System.Environment.CurrentDirectory + "\\Setting\\IIP_Setting.ini");
                Global.G_IniWriteValue("OTHERS", "PTONO_TYPE", value, g_PathData.strIniPath);
            }
        }

        private void hSimpleButton1_Click(object sender, EventArgs e)
        {
            foreach (GridColumn column in grvOrder.Columns)
            {
                if (column.Visible == true)
                {
                    if (string.IsNullOrEmpty(column.Tag.ToString()))
                    {

                    }
                }
            }
        }
    }



}
