using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraBars;
using Sedas.Core;
using Sedas.DB;
using System.Runtime.InteropServices;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Sedas.ImageHelper;
using System.Diagnostics;
using LicenseManager = GdPicture14.LicenseManager;

namespace IIP
{
    public partial class IIP_Main : DevExpress.XtraEditors.XtraForm
    {
        CallService callService = new CallService("10.10.221.72", "8180");
        BlobClass blob;
        ImageHelper imageHelper = new ImageHelper();

        FileTransfer ft = new FileTransfer();


        CoreLibrary coreLibrary = new CoreLibrary(); //자주사용하는 CoreUtil

        bool strcheck = false; //파일 존재여부 체크

        [DllImport("Shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirecotry, int nShowCmd);


        public partial struct pathology_data
        {
            static public int studyID = 0;
            static public int seachcount = 0;
            static public string[] Regno = new string[500];
            static public string[] PID = new string[500];
            static public string[] PathogyNo = new string[500];
            static public string[] Studydate = new string[500];
            static public string[] insertdate = new string[500];
            static public string[] Reqdoctor = new string[500];
            static public string[] Specimen = new string[500];
            static public string[] Studyname = new string[500];
            static public int GI = 0;
            static public string[] PATNAME = new string[500];
            static public string[] PATBIR = new string[500];
            static public string[] PATAGE = new string[500];
            static public string[] PATSEX = new string[500];
            static public string[] ACCESSNO = new string[500];
            static public string[] ROOTPATH = new string[500];
            static public string[] FILEPATH = new string[500];
            static public string[] DStudy_1 = new string[500];
            static public string[] DStudy_2 = new string[500];
            static public string[] DStudy_3 = new string[500];
            static public string[] TCD = new string[500];
            static public string[] UID = new string[500];
            static public int substring = 0;
        };









        /// <summary>
        /// name         : IIP_Main
        /// desc         : 생성자
        /// author       : 심우종
        /// create date  : 2020-04-01 16:44
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public IIP_Main()
        {
            InitializeComponent();

            this.Setting_Load();

            if (Global.strIsDev == "Y")
            {
                this.callService = new CallService("10.10.221.71", "8180");
            }
            else
            {
                this.callService = new CallService(Global.strCallService);
            }

            Net_Check.setRemoteConnection("\\\\" + Global.strDGSServerIP + "\\Imagedata", Global.strDGSServerID, Global.strDGSServerPASSWORD);

            reset_structure();
        }


        /// <summary>
        /// name         : IIP_Main_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-03-19 16:55
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void IIP_Main_Load(object sender, EventArgs e)
        {

            LicenseManager licenseManager = new LicenseManager();
            licenseManager.RegisterKEY("21185684790302862131615213975647244276");


            Global.strPath = System.Environment.CurrentDirectory + "\\Temp_image";
            DirectoryInfo di = new DirectoryInfo(Global.strPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            this.initContextMenu(); //Context메뉴 설정

            this.Image_reset();
            Clipboard.Clear();

            this.InitControl();


            //myConnection.ConnectionString = Global.strDGSConnectionString;
            //myConnection.Open();
            //conn.ConnectionString = Global.strEMRConnectionString;
            //conn.Open();

            this.blob = new BlobClass(this.callService);
        }


        /// <summary>
        /// name         : InitControl
        /// desc         : 컨트롤 초기화
        /// author       : 심우종
        /// create date  : 2020-04-01 17:04
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitControl()
        {
            this.chkPathoNo.Checked = true;
            this.txtStartDate.Enabled = false;
            this.txtEndDate.Enabled = false;

            DataTable dt = new DataTable();
            dt.Columns.Add("cdVal");
            dt.Columns.Add("cdValNm");

            //[이미지 분류 콤보박스 설정]
            string[] imageType = { "조직병리", "현미경", "분자병리" };

            for (int i = 0; i < imageType.Length; i++)
            {
                DataRow row = dt.NewRow();
                string value = imageType.ElementAt(i).ToString();
                row["cdVal"] = value;
                row["cdValNm"] = value;
                dt.Rows.Add(row);
            }

            cmbImageType.DataBindingFromDataTable(dt, "cdVal", "cdValNm");

            if (this.cmbImageType.Properties.Items.Where(e => e.Value.ToString() == Global.strSETTINGTYPE).Count() > 0)
            {
                this.cmbImageType.SelectedText = Global.strSETTINGTYPE;
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (dt.Rows[i]["cdVal"].ToString() == Global.strSETTINGTYPE)
                {
                    this.cmbImageType.SelectedIndex = i;
                    break;
                }
            }


            dt.Clear();

            //[병리번호 콤보박스 설정]
            for (int i = 0; i < Global.strSETTINGPRECOUNT + 1; i++)
            {
                DataRow row = dt.NewRow();
                string value = Global.strSETTINGPRE[i].ToString();
                row["cdVal"] = value;
                row["cdValNm"] = value;
                dt.Rows.Add(row);

            }

            this.cmbPathoNoPri.DataBindingFromDataTable(dt, "cdVal", "cdValNm");
            if (this.cmbPathoNoPri.Properties.Items.Count > 0)
            {
                this.cmbPathoNoPri.SelectedIndex = 0;
            }



            this.txtPathoNo.Text = Global.strSETTINGPRE[0] + DateTime.Now.ToString("yy");
            this.txtStartDate.EditValue = DateTime.Now;
            this.txtEndDate.EditValue = DateTime.Now;


            //[그리드 컨트롤 컬럼 설정]
            grvOrder.Columns.Clear();
            //IIP_Main_listView.Columns.Add("");
            grvSelectedOrder.Columns.Clear();
            //IIP_Main_selectlistView.Columns.Add("");

            if (Global.strColumn_Count.ToIntOrNull() != null)
            {
                for (int i = 0; i < Global.strColumn_Count.ToInt(); i++)
                {
                    Global.strColumn_Name[i] = Global.G_IniReadValue("Column", "Column" + (i + 1), Global.strinipath);
                    Global.strColumn_Len[i] = Global.G_IniReadValue("Column", "Col_Len" + (i + 1), Global.strinipath);
                    Global.strColumn_FieldName[i] = Global.G_IniReadValue("Column", "FieldName" + (i + 1), Global.strinipath);

                    //IIP_Main_listView.Columns.Add(Global.strColumn_Name[i]);
                    //IIP_Main_listView.Columns[i].Width = Int32.Parse(Global.strColumn_Len[i]);
                    //IIP_Main_listView.Columns[i].TextAlign = HorizontalAlignment.Center;
                    //IIP_Main_selectlistView.Columns.Add(Global.strColumn_Name[i]);
                    //IIP_Main_selectlistView.Columns[i].Width = Int32.Parse(Global.strColumn_Len[i]);
                    //IIP_Main_selectlistView.Columns[i].TextAlign = HorizontalAlignment.Center;

                    //하단 그리드 컬럼 설정
                    Sedas.Control.GridControl.HGridColumn gridColumn = new Sedas.Control.GridControl.HGridColumn();
                    gridColumn.AppearanceCell.Options.UseTextOptions = true;
                    gridColumn.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumn.AppearanceHeader.Options.UseTextOptions = true;
                    gridColumn.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumn.Caption = Global.strColumn_Name[i];
                    gridColumn.FieldName = Global.strColumn_FieldName[i].ToString();
                    gridColumn.Name = "grdColumn" + (i + 1).ToString();
                    gridColumn.OptionsColumn.AllowEdit = false;
                    gridColumn.Visible = true;
                    gridColumn.VisibleIndex = 0;
                    gridColumn.Width = 64;
                    gridColumn.OptionsColumn.FixedWidth = true;
                    gridColumn.MinWidth = 0;
                    gridColumn.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
                    gridColumn.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
                    gridColumn.AppearanceHeader.Options.UseBackColor = true;
                    gridColumn.AppearanceHeader.Options.UseForeColor = true;


                    int width = 100;
                    if (Global.strColumn_Len[i].ToIntOrNull() != null)
                    {
                        width = Global.strColumn_Len[i].ToInt();
                    }

                    gridColumn.Width = width;



                    grvOrder.Columns.Add(gridColumn);

                    //오른쪽 선택된 처방 그리드 컬럼 설정
                    Sedas.Control.GridControl.HGridColumn gridColumn2 = new Sedas.Control.GridControl.HGridColumn();
                    gridColumn2.AppearanceCell.Options.UseTextOptions = true;
                    gridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumn2.AppearanceHeader.Options.UseTextOptions = true;
                    gridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
                    gridColumn2.Caption = Global.strColumn_Name[i];
                    gridColumn2.FieldName = Global.strColumn_FieldName[i].ToString();
                    gridColumn2.Name = "grdSelectedColumn" + (i + 1).ToString();
                    gridColumn2.OptionsColumn.AllowEdit = false;
                    gridColumn2.Visible = true;
                    gridColumn2.VisibleIndex = 0;
                    gridColumn2.Width = 64;
                    gridColumn2.OptionsColumn.FixedWidth = true;
                    gridColumn2.MinWidth = 0;
                    gridColumn2.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
                    gridColumn2.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
                    gridColumn2.AppearanceHeader.Options.UseBackColor = true;
                    gridColumn2.AppearanceHeader.Options.UseForeColor = true;





                    width = 100;
                    if (Global.strColumn_Len[i].ToIntOrNull() != null)
                    {
                        width = Global.strColumn_Len[i].ToInt();
                    }

                    gridColumn2.Width = width;

                    grvSelectedOrder.Columns.Add(gridColumn2);
                }
            }


            OrderDataTable workDt = new OrderDataTable();
            this.grdOrder.DataSource = workDt;

            OrderDataTable selectedDt = new OrderDataTable();
            this.grdSelectedOrder.DataSource = selectedDt;



            //grvOrder.Columns[0].Width = 0;
            //grvSelectedOrder.Columns[0].Width = 0;
        }

        /// <summary>
        /// name         : Image_reset
        /// desc         : 임시파일의 이미지 삭제?
        /// author       : 심우종
        /// create date  : 2020-04-01 16:56
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void Image_reset()
        {
            DataTable filetable = new DataTable();
            DirectoryInfo dir = new DirectoryInfo(System.Environment.CurrentDirectory + "\\Temp_image");
            FileInfo[] fileList = dir.GetFiles();
            foreach (FileInfo f in fileList)
            {
                f.Delete();
            }
        }



        /// <summary>
        /// name         : Setting_Load
        /// desc         : 환경변수 불러오기
        /// author       : 심우종
        /// create date  : 2020-04-01 14:54
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void Setting_Load()
        {
            Global.strinipath = System.Environment.CurrentDirectory + "\\Setting\\IIP_Setting.ini";
            Global.strBackupFolderPath = System.Environment.CurrentDirectory + "\\upload_backup\\" + DateTime.Now.ToString("yyyyMMdd");
            Global.strPrinter_FolderPath = Global.G_IniReadValue("Image_Option", "Printer_FolderPath", Global.strinipath);
            Global.strViewerPath = Global.G_IniReadValue("Image_Option", "ViewerPath", Global.strinipath);
            //pathology_data.PID[0] = "sad";

            Global.strColumn_Count = Global.G_IniReadValue("Column", "Column_Count", Global.strinipath);


            Global.strDelete_Day = Global.G_IniReadValue("Image_Option", "Delete_Day", Global.strinipath);
            Global.strDPI = Global.G_IniReadValue("Image_Option", "DPI", Global.strinipath);
            Global.strWidth = Global.G_IniReadValue("Image_Option", "Width", Global.strinipath);
            Global.strHeight = Global.G_IniReadValue("Image_Option", "Height", Global.strinipath);

            Global.strHostital_Name = Global.G_IniReadValue("Hospital_Option", "Hostital_Name", Global.strinipath);
            Global.strSend_FTP_Address = Global.G_IniReadValue("Hospital_Option", "Send_FTP_Address", Global.strinipath);
            Global.strSend_FTP_ID = Global.G_IniReadValue("Hospital_Option", "Send_FTP_ID", Global.strinipath);
            Global.strSend_FTP_pwd = Global.G_IniReadValue("Hospital_Option", "Send_FTP_pwd", Global.strinipath);
            Global.strSend_FTP_Save_Path = Global.G_IniReadValue("Hospital_Option", "Send_FTP_Save_Path", Global.strinipath);



            Global.strProtocol = Global.G_IniReadValue("Serial_Option", "Protocol", Global.strinipath);
            Global.strClass = Global.G_IniReadValue("Serial_Option", "Class", Global.strinipath);
            Global.strCommPort = Global.G_IniReadValue("Serial_Option", "CommPort", Global.strinipath);
            Global.strBaudrate = Global.G_IniReadValue("Serial_Option", "Baudrate", Global.strinipath);
            Global.strParity = Global.G_IniReadValue("Serial_Option", "Parity", Global.strinipath);
            Global.strByte_size = Global.G_IniReadValue("Serial_Option", "Byte_size", Global.strinipath);
            Global.strStop_Bits = Global.G_IniReadValue("Serial_Option", "Stop_Bits", Global.strinipath);
            Global.strFlow_Control = Global.G_IniReadValue("Serial_Option", "Flow_Control", Global.strinipath);
            Global.strReceive_Queue = Global.G_IniReadValue("Serial_Option", "Receive_Queue", Global.strinipath);
            Global.strTransmit_Queue = Global.G_IniReadValue("Serial_Option", "Transmit_Queue", Global.strinipath);
            Global.strport = Global.G_IniReadValue("Serial_Option", "port", Global.strinipath);
            Global.strbyte_size = Global.G_IniReadValue("Serial_Option", "byte size", Global.strinipath);
            Global.strstop_bits = Global.G_IniReadValue("Serial_Option", "stop bits", Global.strinipath);
            Global.strflow_control = Global.G_IniReadValue("Serial_Option", "flow control", Global.strinipath);
            Global.strreceive_queue = Global.G_IniReadValue("Serial_Option", "receive queue", Global.strinipath);
            Global.strtransmit_queue = Global.G_IniReadValue("Serial_Option", "transmit queue", Global.strinipath);

            Global.strDGSConnectionString = Global.G_IniReadValue("DGSDB", "DGSConnectionString", Global.strinipath);
            Global.strDGSServerIP = Global.G_IniReadValue("DGSDB", "DGSSERVERIP", Global.strinipath);
            Global.strDGSServerID = Global.G_IniReadValue("DGSDB", "DGSServerID", Global.strinipath);
            Global.strDGSServerPASSWORD = Global.G_IniReadValue("DGSDB", "DGSServerPASSWORD", Global.strinipath);
            Global.strDGSimagepath = Global.G_IniReadValue("DGSDB", "DGSIMAGEPATH", Global.strinipath);
            Global.strSETTINGTYPE = Global.G_IniReadValue("DGSDB", "SETTINGTYPE", Global.strinipath);
            string m_pre = Global.G_IniReadValue("DGSDB", "SETTINGPRE", Global.strinipath);
            Global.strSETTINGPRECOUNT = 0;
            while (m_pre.Length > 0)
            {
                if (m_pre.IndexOf("|") > 0)
                {
                    Global.strSETTINGPRE[Global.strSETTINGPRECOUNT] = m_pre.Substring(0, m_pre.IndexOf("|"));
                    m_pre = m_pre.Substring(m_pre.IndexOf("|") + 1);
                    Global.strSETTINGPRECOUNT++;
                }
                else
                {
                    Global.strSETTINGPRE[Global.strSETTINGPRECOUNT] = m_pre;
                    m_pre = "";
                }

            }
            Global.strEMRTYPE = Global.G_IniReadValue("EMRDB", "EMRTYPE", Global.strinipath);
            Global.strEMRConnectionString = Global.G_IniReadValue("EMRDB", "EMRConnectionString", Global.strinipath);
            Global.strEMRServerIP = Global.G_IniReadValue("EMRDB", "EMRSERVERIP", Global.strinipath);
            Global.strEMRTNSNAME = Global.G_IniReadValue("EMRDB", "EMRTNSNAME", Global.strinipath);
            Global.strEMRID = Global.G_IniReadValue("EMRDB", "EMRID", Global.strinipath);
            Global.strEMRPASSWORD = Global.G_IniReadValue("EMRDB", "EMRPASSWORD", Global.strinipath);

            Global.strCallService = Global.G_IniReadValue("DGSDB", "CallService", Global.strinipath);
            Global.strIsDev = Global.G_IniReadValue("DGSDB", "IsDev", Global.strinipath);
        }




        /// <summary>
        /// name         : initContextMenu
        /// desc         : Context 메뉴 초기화
        /// author       : 심우종
        /// create date  : 2020-04-01 16:44
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void initContextMenu()
        {
            DevExpress.XtraBars.PopupMenu menu = new DevExpress.XtraBars.PopupMenu();
            menu.Name = "menu_image";
            menu.Manager = barManager1;
            BarButtonItem itemCopy = new BarButtonItem(barManager1, "이미지추가", 0);
            itemCopy.AccessibleName = "itemCopy";
            itemCopy.Hint = "itemCopy";
            BarButtonItem itemDelete = new BarButtonItem(barManager1, "이미지삭제", 1);
            itemDelete.AccessibleName = "itemDelete";
            itemDelete.Hint = "itemDelete";
            BarButtonItem itemSizeUp = new BarButtonItem(barManager1, "이미지확대", 2);
            itemSizeUp.AccessibleName = "itemSizeUp";
            itemSizeUp.Hint = "itemSizeUp";

            menu.AddItems(new BarItem[] { itemCopy, itemDelete, itemSizeUp });
            //barManager1.QueryShowPopupMenu += BarManager1_QueryShowPopupMenu;
            barManager1.ItemClick += BarManager1_ItemClick;
            barManager1.SetPopupContextMenu(this.imagePanel, menu);
        }


        /// <summary>
        /// name         : BarManager1_ItemClick
        /// desc         : ContextMenu 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-01 16:43
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary>  
        private void BarManager1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == null || string.IsNullOrEmpty(e.Item.AccessibleName)) return;
            string name = e.Item.AccessibleName;

            switch (name)
            {
                case "itemCopy": //이미지추가
                    this.menu_itemCopy();
                    break;
                case "itemDelete": //이미지삭제
                    this.menu_itemDelete();
                    break;
                case "itemSizeUp": //이미지확대
                    menu_itemSizeUp();
                    break;

            }


        }


        /// <summary>
        /// name         : menu_itemCopy
        /// desc         : 이미지추가 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-19 17:15
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menu_itemCopy()
        {
            this.AddImage();
        }


        /// <summary>
        /// name         : menu_itemDelete
        /// desc         : 이미지삭제 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-19 17:15
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void menu_itemDelete()
        {
            this.DeleteImage();
        }


        /// <summary>
        /// name         : menu_itemSizeUp
        /// desc         : 이미지확대 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-19 17:15
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary>  
        private void menu_itemSizeUp()
        {
            this.ShowImage();
        }



        private void hTableLayoutPanel4_Paint(object sender, PaintEventArgs e)
        {

        }



        /// <summary>
        /// name         : btnSelectImage_Click
        /// desc         : 이미지 선택추가 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-19 16:27
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSelectImage_Click(object sender, EventArgs e)
        {
            this.AddImage();
        }


        /// <summary>
        /// name         : AddImage
        /// desc         : 이미지를 추가한다.
        /// author       : 심우종
        /// create date  : 2020-03-20 08:58
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void AddImage()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "jpg(*.*)|*.jpg*";
            DialogResult drs = ofd.ShowDialog();
            if (drs == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    string strPath = ofd.FileNames[i].ToString();

                    string File_Full_path = Global.strPath;
                    DirectoryInfo di = new DirectoryInfo(File_Full_path);
                    if (!di.Exists)
                    {
                        di.Create();
                    }
                    File_Full_path = File_Full_path + "\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                    File.Copy(strPath, File_Full_path);
                    ImgThumbnail(strPath);
                }
            }

        }



        /// <summary>
        /// name         : ShowImage
        /// desc         : 이미지 확대를 위한 팝업을 호출한다.
        /// author       : 심우종
        /// create date  : 2020-03-20 08:58
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ShowImage()
        {
            int n = this.imagePanel.Controls.IndexOf(imgbox);
            for (int i = n; i >= 0; i--)
            {
                System.Windows.Forms.Button btn = (System.Windows.Forms.Button)this.imagePanel.Controls[i];
                if (btn.Focused == true)
                {
                    Global.strShow_File_Path = btn.Tag.ToString();
                }
            }
            if (Global.strShow_File_Path == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 선택해주십시요");
            }
            else
            {
                IIP_ImageShow dlg = new IIP_ImageShow();
                dlg.StartPosition = FormStartPosition.CenterParent;
                dlg.ShowDialog();
            }
        }

        /// <summary>
        /// name         : DeleteImage
        /// desc         : 이미지를 삭제한다.
        /// author       : 심우종
        /// create date  : 2020-03-20 08:58
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary>  
        private void DeleteImage()
        {
            int n = this.imagePanel.Controls.IndexOf(imgbox);
            string[] strColumn_Name = new string[25];
            int remove_i = 1;
            for (int i = n; i >= 0; i--)
            {
                System.Windows.Forms.Button btn = (System.Windows.Forms.Button)imagePanel.Controls[i];
                if (btn.Focused == false)
                {
                    strColumn_Name[remove_i] = btn.Tag.ToString();
                    remove_i++;
                }

                btn.DoubleClick -= Imgbox_DoubleClick;
                btn.BackgroundImage.Dispose();
                btn.BackgroundImage = null;

                imagePanel.Controls.RemoveAt(i);
            }
            for (int i = remove_i - 1; i > 0; i--)
            {
                ImgThumbnail(strColumn_Name[i]);
            }
        }

        System.Windows.Forms.Button imgbox = null;

        public void ImgThumbnail(string FilePath)
        {
            string strBmp = FilePath;
            int nImgCnt = imagePanel.Controls.Count;

            imgbox = new System.Windows.Forms.Button();
            this.SetStyle(ControlStyles.StandardDoubleClick, true);
            this.SetStyle(ControlStyles.StandardClick, true);

            //imgbox.Click += new System.EventHandler(this.imgbox_Click);
            imgbox.DoubleClick += Imgbox_DoubleClick;


            imgbox.BackgroundImageLayout = ImageLayout.Stretch;
            imgbox.Tag = strBmp;

            if (!imagePanel.Contains(imgbox))
            {
                imagePanel.AutoScrollPosition = new System.Drawing.Point(0, 0);
                imagePanel.Controls.Add(imgbox);
            }
            FileStream fs;
            fs = new FileStream(strBmp, FileMode.Open, FileAccess.Read);
            imgbox.BackgroundImage = System.Drawing.Image.FromStream(fs);
            fs.Close();
            if (nImgCnt == 0)
                imgbox.SetBounds(18, 18, 150, 150);
            else
            {
                int nY = (nImgCnt * 170) + 18;
                imgbox.SetBounds(nY, 18, 150, 150);
            }
            imagePanel.AutoScrollPosition = new System.Drawing.Point(100000, 100000);
        }



        public void reset_structure()
        {
            pathology_data.studyID = 0;
            pathology_data.seachcount = 0;
            pathology_data.PID[0] = "NOPID";
            pathology_data.PathogyNo[0] = "";
            pathology_data.Studydate[0] = "";
            pathology_data.insertdate[0] = "";
            pathology_data.Reqdoctor[0] = "";
            pathology_data.Specimen[0] = "";
            pathology_data.Studyname[0] = "";
            pathology_data.GI = 0;
            pathology_data.PATNAME[0] = "NONAME";
            pathology_data.PATBIR[0] = "NOBIR";
            pathology_data.PATAGE[0] = "NOAGE";
            pathology_data.PATSEX[0] = "NOSEX";
            pathology_data.ACCESSNO[0] = "";
            pathology_data.ROOTPATH[0] = "";
            pathology_data.FILEPATH[0] = "";
            pathology_data.DStudy_1[0] = "";
            pathology_data.DStudy_2[0] = "";
            pathology_data.DStudy_3[0] = "";
            pathology_data.TCD[0] = "";
            pathology_data.UID[0] = "";
            pathology_data.substring = 0;
        }



        private void Imgbox_DoubleClick(object sender, EventArgs e)
        {
            ShowImageBox();
            //throw new NotImplementedException();
        }



        private void ShowImageBox()
        {

        }


        /// <summary>
        /// name         : chkPathoNo_CheckedChanged
        /// desc         : 병리번호 라디오버튼 선택시
        /// author       : 심우종
        /// create date  : 2020-04-01 17:21
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary>  
        private void chkPathoNo_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkPathoNo.Checked == true)
            {
                this.txtStartDate.Enabled = false;
                this.txtEndDate.Enabled = false;
                this.cmbPathoNoPri.Enabled = true;
                this.txtPathoNo.Enabled = true;

                this.chkDay.Checked = false;
            }
        }


        /// <summary>
        /// name         : chkDay_CheckedChanged
        /// desc         : 접수일자 라디오버튼 선택시
        /// author       : 심우종
        /// create date  : 2020-04-01 17:22
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void chkDay_CheckedChanged(object sender, EventArgs e)
        {
            if (this.chkDay.Checked == true)
            {
                this.txtStartDate.Enabled = true;
                this.txtEndDate.Enabled = true;
                this.cmbPathoNoPri.Enabled = true;
                this.txtPathoNo.Enabled = false;

                this.chkPathoNo.Checked = false;
            }
        }


        /// <summary>
        /// name         : cmbImageType_SelectedIndexChanged
        /// desc         : 이미지분류 선택값 변경시
        /// author       : 심우종
        /// create date  : 2020-04-01 17:26
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary>  
        private void cmbImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.cmbImageType.SelectedIndex > -1)
            {
                string value = this.cmbImageType.Properties.Items[this.cmbImageType.SelectedIndex].Value.ToString();
                Global.G_IniWriteValue("DGSDB", "SETTINGTYPE", value, System.Environment.CurrentDirectory + "\\Setting\\IIP_Setting.ini");
            }

        }


        /// <summary>
        /// name         : btnViewer_Click
        /// desc         : 뷰어실행 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-03 11:45
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnViewer_Click(object sender, EventArgs e)
        {
            //ShellExecute(GetStringTOintPtr("0"), "open", "C:\\Program Files\\SEDAS\\DISViewer\\DGS_Viewer.exe", "DGS_Viewer.exe", "C:\\Program Files\\SEDAS\\DISViewer\\", 5);
            //ShellExecute(GetStringTOintPtr("0"), "open", Global.strViewerPath, "DGS_Viewer.exe", "C:\\BASE\\SedasSolutions\\DGS_Viewer\\bin\\Debug\\", 5);


            using (Process compiler = new Process())
            {
                string path = Global.strViewerPath;
                FileInfo file = new FileInfo(path);

                compiler.StartInfo.FileName = path;
                string arg = string.Format("{0}", SessionInfo.userId);
                compiler.StartInfo.Arguments = arg;
                //compiler.StartInfo.Arguments = "\"" + jsonValue + "\"" ;

                compiler.StartInfo.UseShellExecute = true;
                //compiler.StartInfo.RedirectStandardOutput = true;
                compiler.StartInfo.WorkingDirectory = file.DirectoryName;
                compiler.Start();

                //Console.WriteLine(compiler.StandardOutput.ReadToEnd());

            }


        }

        public IntPtr GetStringTOintPtr(string data)
        {
            return Marshal.StringToHGlobalAnsi(data);
        }

        private void hTextEdit7_EditValueChanged(object sender, EventArgs e)
        {

        }

        bool isSearching = false;

        /// <summary>
        /// name         : btnSearch_Click
        /// desc         : 조회버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-14 08:59
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            KeyValueData param = new KeyValueData();
            if (this.chkPathoNo.Checked == true)
            {
                //1. 병리번호로 검색
                param.Add("Data1", this.txtPathoNo.Text); //병리번호
            }
            else
            {
                //DateTime dt = new DateTime(2008, 9, 22);
                //this.txtStartDate.EditValue = dt;
                //this.txtEndDate.EditValue = dt;


                //2. 접수일자로 검색
                param.Add("Data2", this.txtStartDate.Text.Replace("-", "")); //시작일자
                param.Add("Data3", this.txtEndDate.Text.Replace("-", "")); //종료일자
                param.Add("Data4", this.cmbPathoNoPri.Properties.Items[cmbPathoNoPri.SelectedIndex].Value.ToString() + "%"); //병리 구분 콤보값
            }

            this.isSearching = true;
            try
            {
                CallResultData result = this.callService.SelectSql("reqGetIipData", param);

                if (result.resultState == ResultState.OK)
                {
                    //데이터 조회 성공
                    DataTable dt = result.resultData;

                    OrderDataTable orderDt = new OrderDataTable();
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            DataRow row = dt.Rows[i];
                            if (i >= 1)
                            {
                                if (orderDt.Rows[orderDt.Rows.Count - 1]["ptno"].ToString() == row["ptno"].ToString())
                                {
                                    orderDt.Rows[orderDt.Rows.Count - 1]["tknm"] = orderDt.Rows[orderDt.Rows.Count - 1]["tknm"].ToString() + "\n" + row["tknm"].ToString();
                                }
                                else
                                {
                                    this.coreLibrary.TableCopy(row, ref orderDt);
                                }
                            }
                            else
                            {
                                this.coreLibrary.TableCopy(row, ref orderDt);
                            }

                            if (i > 500)
                            {
                                break;
                            }
                        }

                        this.regnoDataParsing(orderDt);

                        this.grdOrder.DataSource = orderDt;
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("정보가 없습니다.");

                    }
                }
                else
                {
                    //실패에 대한 처리
                }
            }
            finally
            {
                isSearching = false;
            }
        }


        /// <summary>
        /// name         : regnoDataParsing
        /// desc         : 병리번호에 의한 데이터 추출
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void regnoDataParsing(DataTable dt)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    string regno = row["regno"].ToString();

                    if (!string.IsNullOrEmpty(regno) && regno.Length >= 8)
                    {
                        if (regno.Substring(7, 1) == "1" || regno.Substring(7, 1) == "2" || regno.Substring(7, 1) == "5" || regno.Substring(7, 1) == "6")
                        {
                            row["patbir"] = "19" + regno.Substring(0, 2) + "-" + regno.Substring(2, 2) + "-" + regno.Substring(4, 2);
                        }
                        else if (regno.Substring(7, 1) == "3" || regno.Substring(7, 1) == "4" || regno.Substring(7, 1) == "7" || regno.Substring(7, 1) == "8")
                        {
                            row["patbir"] = "20" + regno.Substring(0, 2) + "-" + regno.Substring(2, 2) + "-" + regno.Substring(4, 2);
                        }
                        else if (regno.Substring(7, 1) == "9" || regno.Substring(7, 1) == "0")
                        {
                            row["patbir"] = "18" + regno.Substring(0, 2) + "-" + regno.Substring(2, 2) + "-" + regno.Substring(4, 2);
                        }
                    }

                    row["patage"] = (DateTime.Now.Year - Convert.ToInt32(row["patbir"].ToString().Substring(0, 4)) + 1).ToString();

                    switch (regno.Substring(7, 1).ToString())
                    {
                        case "1":
                        case "3":
                        case "5":
                        case "7":
                        case "9":
                            //IIP_Main.pathology_data.PATSEX[count] = "M";
                            row["patsex"] = "M";
                            break;
                        case "0":
                        case "2":
                        case "4":
                        case "6":
                        case "8":
                            //IIP_Main.pathology_data.PATSEX[count] = "F";
                            row["patsex"] = "F";
                            break;
                    }
                }
            }
        }








        /// <summary>
        /// name         : grdOrder_MouseDown
        /// desc         : 하단의 그리드 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-14 14:34
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void grdOrder_MouseDown(object sender, MouseEventArgs e)
        {

        }


        /// <summary>
        /// name         : grvOrder_RowClick
        /// desc         : 하단의 그리드 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-14 14:34
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void grvOrder_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            GridHitInfo hitInfo = this.grvOrder.CalcHitInfo(new Point(e.X, e.Y));

            if (hitInfo.HitTest == GridHitTest.RowCell)
            {
                DataRow row = this.grvOrder.GetFocusedDataRow();

                if (row != null)
                {
                    this.txtSpathoNo.Text = row["ptno"].ToString();
                    this.txtPid.Text = row["pid"].ToString();
                    this.txtTkdt.Text = row["tkdt"].ToString();
                    this.txtName.Text = row["kornm"].ToString();

                    DataTable dt = this.grdSelectedOrder.DataSource as DataTable;

                    DataRow newRow = dt.NewRow();
                    this.coreLibrary.TableCopy(row, ref newRow);
                    dt.Rows.Add(newRow);
                }
            }
        }



        /// <summary>
        /// name         : grdSelectedOrder_Click
        /// desc         : 오른쪽 선택된 처방 그리드 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-14 17:09
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void grdSelectedOrder_MouseDown(object sender, MouseEventArgs e)
        {

        }


        /// <summary>
        /// name         : grvSelectedOrder_RowClick
        /// desc         : 오른쪽 선택된 처방 그리드 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-14 17:09
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void grvSelectedOrder_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            GridHitInfo hitInfo = this.grvSelectedOrder.CalcHitInfo(new Point(e.X, e.Y));

            if (hitInfo.HitTest == GridHitTest.RowCell)
            {
                DataRow row = this.grvSelectedOrder.GetFocusedDataRow();
                if (row != null)
                {
                    DataTable dt = this.grdSelectedOrder.DataSource as DataTable;
                    dt.Rows.Remove(row);
                }
            }
        }

        //LogHelper logHelper = new LogHelper("10.10.221.71", "1111");

        /// <summary>
        /// name         : btnSave_Click
        /// desc         : 저장 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-16 08:41
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSave_Click(object sender, EventArgs e)
        {
            //string id =  SessionInfo.userId;

            //logHelper.WriteLog("IIP_SAVE", LogType.ERROR, ActionType.CALL_DB, "IIP 저장", "IIP 저장에 실패하였습니다.", "S2005767", "16655329");

            ////logHelper.WriteLog("IIP_SAVE", LogType.INFO, ActionType.CALL_DB, "이미지 저장2", "이미지 저장합니다. \r\n 테스트테스트", "testPTONO2", "testPTNO2", paramInfo: "testPARAM2", "testETC2");

            //LogDTO logDTO = new LogDTO();
            //logDTO.ptno = "16655329";
            //logDTO.ptoNo = "S2005767";
            //logDTO.logType = LogType.ERROR;
            //logDTO.actionType = ActionType.CALL_DB;
            //logDTO.title = "IIP 저장";
            //logDTO.message = "IIP 저장에 실패하였습니다.";

            //logHelper.WriteLog("IIP_SAVE", logDTO);

            //return;
            

            //FTPclient Str_FTP = new FTPclient();
            DataTable selectedOrderDt = grdSelectedOrder.DataSource as DataTable;

            if (selectedOrderDt == null || selectedOrderDt.Rows.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("전송할 병리번호를 확인해주십시요");
                return;
            }

            if (this.imagePanel.Controls.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("전송할 사진을 확인해주십시요");
                return;
            }



            int progressBarMax = this.imagePanel.Controls.Count * selectedOrderDt.Rows.Count;
            int progressValue = 0;
            this.progressBarControl1.Properties.Maximum = progressBarMax;
            this.progressBarControl1.EditValue = progressValue;
            int imageIndex = this.imagePanel.Controls.Count;

            //string strmessage =  IIP_Main_selectlistView.Items.Count.ToString() + " 명의 환자에 // " + (Main_Image_panel.Controls.IndexOf(imgbox) + 1).ToString() + " 의 사진을 보내겠습니다.";
            string strmessage = selectedOrderDt.Rows.Count.ToString() + " 명의 환자에 // " + this.imagePanel.Controls.Count.ToString() + " 의 사진을 보내겠습니다.";

            if (DevExpress.XtraEditors.XtraMessageBox.Show(strmessage, "전송", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int j = imageIndex - 1; j >= 0; j--)
                {
                    System.Windows.Forms.Button btn = (System.Windows.Forms.Button)this.imagePanel.Controls[j];
                    this.strcheck = File.Exists(btn.Tag.ToString());

                    if (strcheck == true)
                    {
                        for (int i = 0; i < selectedOrderDt.Rows.Count; i++)
                        {
                            StudyDataTable saveDt = new StudyDataTable();
                            DataRow row = selectedOrderDt.Rows[i];
                            DataRow newRow = saveDt.NewRow();


                            string ptoNo = row["ptno"].ToString();


                            newRow["ptNo"] = row["pid"].ToString();
                            newRow["studyDt"] = row["tkdt"].ToString();
                            newRow["insertDt"] = DateTime.Now.ToString("yyyyMMdd");
                            newRow["ptoNo"] = ptoNo; //병리번호
                            newRow["sendStat"] = "0";

                            string uId = blob.SearchNumber(ptoNo);
                            newRow["uId"] = uId;

                            newRow["gi"] = "0";
                            newRow["mi"] = "0";
                            newRow["oi"] = "0";
                            string typeValue = this.cmbImageType.Properties.Items[this.cmbImageType.SelectedIndex].Value.ToString();
                            if (typeValue == "조직병리")
                            {
                                newRow["gi"] = "1";
                                newRow["imageType"] = "0";
                            }
                            else if (typeValue == "현미경")
                            {
                                newRow["mi"] = "1";
                                newRow["imageType"] = "1";
                            }
                            else if (typeValue == "분자병리")
                            {
                                newRow["oi"] = "1";
                                newRow["imageType"] = "2";
                            }
                            //string rootPath = Global.strDGSimagepath;
                            string filePath = Global.strDGSimagepath + DateTime.Now.ToString("yyyy") + "\\" + ptoNo + "\\" + ptoNo + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";
                            newRow["rootPath"] = "Z:\\";
                            newRow["filePath"] = filePath;

                            newRow["ptNm"] = row["kornm"].ToString();
                            newRow["birth"] = row["patbir"].ToString();
                            newRow["age"] = row["patage"].ToString();
                            newRow["sex"] = row["patsex"].ToString();

                            newRow["studyNm"] = row["tknm"].ToString();
                            newRow["userId"] = SessionInfo.userId;

                            saveDt.Rows.Add(newRow);


                            KeyValueData param = new KeyValueData();
                            param.Add("Data1", saveDt.DataTableToStringForServer());
                            CallResultData result = this.callService.SelectSql("reqInsIipData", param);
                            if (result.resultState == ResultState.OK)
                            {
                                Global.logHelper.WriteLog("IIPSave", LogType.INFO, ActionType.CALL_DB, "IIP 저장", "DB에 이미지 정보 저장 성공", ptNo: row["pid"].ToString(), ptoNo: ptoNo, paramInfo: "filePath : " + filePath);
                                if (strcheck == true)
                                {
                                    //파일 복사
                                    //Directory.CreateDirectory(rootPath + filePath.ToString().Substring(0, filePath.LastIndexOf("\\")));
                                    string strNewPath = filePath;

                                    if (ft.FileUpload(btn.Tag.ToString(), strNewPath) == true)
                                    {
                                        Global.logHelper.WriteLog("IIPSave", LogType.INFO, ActionType.ACTION, "IIP 저장", "이미지 파일 파일서버에 저장 성공", ptNo: row["pid"].ToString(), ptoNo: ptoNo, paramInfo: "filePath : " + filePath);
                                        //파일전송 성공  
                                        this.blob.InsertLPRPRSTHM(ptoNo, uId);
                                        this.blob.UpdateBlob(ptoNo, btn.Tag.ToString(), filePath);
                                    }
                                    //File.Copy(btn.Tag.ToString(), strNewPath);

                                    progressValue++;
                                    this.progressBarControl1.EditValue = progressValue;
                                    this.Update();
                                    System.Threading.Thread.Sleep(1000);

                                }
                            }
                            else
                            {
                                Global.logHelper.WriteLog("IIPSave", LogType.INFO, ActionType.CALL_DB, "IIP 저장", "DB에 이미지 정보 저장 실패", ptNo: row["pid"].ToString(), ptoNo: ptoNo, paramInfo: "filePath : " + filePath);
                                DevExpress.XtraEditors.XtraMessageBox.Show("DB 업데이트 실패");
                                return;
                            }

                        }
                    }
                    else
                    {
                        //파일이 없음
                        DevExpress.XtraEditors.XtraMessageBox.Show("파일이 없습니다.");
                        return;
                    }

                    this.imagePanel.Controls.Remove(btn);
                    this.Update();
                }

                DataTable dt = (this.grdSelectedOrder.DataSource as DataTable);
                dt.Clear();

                this.txtPathoNo.Text = cmbPathoNoPri.Properties.Items[cmbPathoNoPri.SelectedIndex].Value.ToString() + DateTime.Now.ToString("yy");
                this.txtSpathoNo.Text = "";
                this.txtPid.Text = "";
                this.txtTkdt.Text = "";
                this.txtName.Text = "";




            }



            //if (MessageBox.Show(strmessage, "전송", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //{

            //    //전송모듈
            //    int n = this.imagePanel.Controls.Count;
            //    progressBar.Maximum = (Main_Image_panel.Controls.IndexOf(imgbox) + 1) * IIP_Main_selectlistView.Items.Count;
            //    progressBar.Value = 0;
            //    for (int i = n - 1; i >= 0; i--)
            //    {

            //        System.Windows.Forms.Button btn = (System.Windows.Forms.Button)this.imagePanel.Controls[i];
            //        this.strcheck = File.Exists(btn.Tag.ToString());

            //        for (int j = 0; j < selectedOrderDt.Rows.Count; j++)
            //        {
            //            IIP_Main.pathology_data.PathogyNo[0] = IIP_Main_selectlistView.Items[j].SubItems[1].Text;
            //            IIP_Main.pathology_data.PID[0] = IIP_Main_selectlistView.Items[j].SubItems[2].Text;
            //            IIP_Main.pathology_data.PATBIR[0] = IIP_Main_selectlistView.Items[j].SubItems[3].Text;
            //            IIP_Main.pathology_data.PATNAME[0] = IIP_Main_selectlistView.Items[j].SubItems[4].Text;
            //            IIP_Main.pathology_data.PATAGE[0] = IIP_Main_selectlistView.Items[j].SubItems[5].Text;
            //            IIP_Main.pathology_data.PATSEX[0] = IIP_Main_selectlistView.Items[j].SubItems[6].Text;
            //            IIP_Main.pathology_data.Studyname[0] = IIP_Main_selectlistView.Items[j].SubItems[7].Text;
            //            IIP_Main.pathology_data.DStudy_1[0] = IIP_Main_selectlistView.Items[j].SubItems[8].Text;
            //            IIP_Main.pathology_data.DStudy_2[0] = IIP_Main_selectlistView.Items[j].SubItems[9].Text;
            //            IIP_Main.pathology_data.DStudy_3[0] = IIP_Main_selectlistView.Items[j].SubItems[10].Text;
            //            IIP_Main.pathology_data.Studydate[0] = IIP_Main_selectlistView.Items[j].SubItems[11].Text;

            //            pathology_data.ROOTPATH[0] = Global.strDGSimagepath;
            //            pathology_data.FILEPATH[0] = DateTime.Now.ToString("yyyyMMdd") + "\\" + pathology_data.PathogyNo[0] + "\\A" + DateTime.Now.ToString("yyyyMMddhhmmss") + ".jpg";
            //            if (this.strcheck == true)
            //            {
            //                DB_Save(pathology_data.FILEPATH[0]);//DGS로의 연결

            //                if (this.strcheck == true)
            //                {
            //                    Directory.CreateDirectory(pathology_data.ROOTPATH[0] + pathology_data.FILEPATH[0].ToString().Substring(0, pathology_data.FILEPATH[0].LastIndexOf("\\")));
            //                    string strNewPath = pathology_data.ROOTPATH[0] + pathology_data.FILEPATH[0];
            //                    File.Copy(btn.Tag.ToString(), strNewPath);

            //                    if (pathology_data.PathogyNo[0] != "" || pathology_data.UID[0] != "")
            //                    {
            //                        blob.InsertLPRPRSTHM(pathology_data.PathogyNo[0], pathology_data.UID[0], Global.strEMRTNSNAME, Global.strEMRID, Global.strEMRPASSWORD);
            //                        //blob.UpdateBlob(pathology_data.PathogyNo[0], btn.Tag.ToString(), Global.strEMRTNSNAME, Global.strEMRID, Global.strEMRPASSWORD);
            //                        blob.UpdateBlob(pathology_data.PathogyNo[0], strNewPath, Global.strEMRTNSNAME, Global.strEMRID, Global.strEMRPASSWORD);
            //                        progressBar.Value++;
            //                        System.Threading.Thread.Sleep(350);
            //                    }
            //                }
            //                else
            //                {
            //                    MessageBox.Show("SEDAS DB 업데이트 실패");
            //                    return;
            //                }
            //            }
            //            else
            //            {
            //                MessageBox.Show("파일이 없습니다.");
            //                return;
            //            }
            //        }
            //        Main_Image_panel.Controls.RemoveAt(i);
            //    }
            //    IIP_Main_selectlistView.Items.Clear();
            //    reset_structure();
            //    Btn_PATHONO_Text.Text = Btn_PATHONOPRI.Text + DateTime.Now.ToString("yy");
            //    Btn_SPATHONO.Text = "";
            //    Btn_SPID.Text = "";
            //    Btn_SDAY.Text = "";
            //    Btn_SNAME.Text = "";
            //    Btn_SDOCTOR.Text = "";
            //}
        }


        /// <summary>
        /// name         : btnPrinter_Click
        /// desc         : 프린터 선택추가 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-05-19 10:19
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnPrinter_Click(object sender, EventArgs e)
        {
            DataTable filetable = new DataTable();
            DirectoryInfo dir = new DirectoryInfo(Global.strPrinter_FolderPath);

            if (dir.Exists == false)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(dir.FullName + "경로를 찾을수 없습니다.");
                return;
            }

            FileInfo[] fileList = dir.GetFiles();
            foreach (FileInfo f in fileList)
            {
                // f를 이용해서 원하는 정보를 가져오세요.
                if (Path.GetExtension(f.FullName.ToString()).ToLower() == ".jpg")
                {
                    string File_Full_path = Global.strPath;
                    DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory + "\\Temp_image");
                    if (!di.Exists)
                    {
                        di.Create();
                    }
                    File_Full_path = System.Environment.CurrentDirectory + "\\Temp_image\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                    File.Copy(f.FullName.ToString(), File_Full_path);
                    ImgThumbnail(File_Full_path);
                    File.Delete(f.FullName.ToString());
                }
            }
        }


        /// <summary>
        /// name         : btnRemote_Click
        /// desc         : 원격프로그램 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-05-19 10:22
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnRemote_Click(object sender, EventArgs e)
        {
            ShellExecute(GetStringTOintPtr("0"), "open", System.Environment.CurrentDirectory + "\\RemoteClient.exe", "RemoteClient.exe", System.Environment.CurrentDirectory, 5);

            //string path = @"D:\디자인요청 이미지\디자인 받은 이미지\통합뷰어 이미지";
            //CoreLibrary core = new CoreLibrary();
            //core.GridControlToExcel(grvOrder, titleYn: true, borderYn: true, excelPath: path); //속도느림
            //core.GridControlToExcelByClosedXML(grvOrder, titleYn: true, borderYn: true); //속도 빠름
        }



        /// <summary>
        /// name         : btnWord_Click
        /// desc         : 문서파일 추가 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-05-19 10:25
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnWord_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "office, pdf(*.pdf;*.doc;*.docx;*.xlsx;*.pptx)|*.pdf;*.doc;*.docx;*.xlsx;*.pptx";

            string strPath = "";
            DialogResult drs = ofd.ShowDialog();
            if (drs == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    strPath = ofd.FileNames[i].ToString();
                }
            }

            List<string> imageList = new List<string>(); //저장된 이미지 경로 리턴 변수

            if (!string.IsNullOrEmpty(strPath))
            {
                string[] fileNameSplite = strPath.ToString().Split('.');
                if (fileNameSplite == null || fileNameSplite.Length > 0)
                {
                    string lastValue = fileNameSplite[fileNameSplite.Length - 1].ToString();
                    if ( imageHelper.IsOfficeFileCheck(strPath))
                    {
                        string outResult = "";
                        //office파일을 pdf로 변환
                        string OfficeToPdfTempPath = System.Environment.CurrentDirectory + "\\Temp_ConvertPDF";
                        if (imageHelper.OfficeToPDF(strPath.ToString(), out outResult, tempFileSavePath: OfficeToPdfTempPath) == true)
                        {
                            if (!string.IsNullOrEmpty(outResult))
                            {
                                //_owner.DisplayFromFile(outResult);


                                string pdfPath = outResult;
                                //pdf파일을 이미지로 변환
                                if (this.imageHelper.PdfToImage(pdfPath, ref imageList) == true)
                                {
                                    //PASS
                                }
                                else
                                {
                                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지 변환에 실패하였습니다.");
                                    return;
                                }
                            }
                        }
                    }
                    else if (lastValue == "pdf")
                    {
                        string pdfPath = strPath;
                        //pdf파일을 이미지로 변환
                        if (this.imageHelper.PdfToImage(pdfPath, ref imageList) == true)
                        {
                            //PASS
                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("이미지 변환에 실패하였습니다.");
                            return;
                        }
                    }
                }
            }

            if (imageList != null && imageList.Count > 0)
            {
                for (int i = 0; i < imageList.Count; i++)
                {
                    string imagePath = imageList[i].ToString();
                    DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory + "\\Temp_image");
                    if (!di.Exists)
                    {
                        di.Create();
                    }
                    string File_Full_path = System.Environment.CurrentDirectory + "\\Temp_image\\" + DateTime.Now.ToString("yyyyMMddHHmmssfff") + ".jpg";
                    File.Copy(imagePath.ToString(), File_Full_path);
                    ImgThumbnail(File_Full_path);
                }
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("이미지 변환에 실패하였습니다.");
                return;
            }


        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            System.Drawing.Image image = Clipboard.GetImage();
            if (image != null)
            {
                string File_Full_path = Global.strPath;
                DirectoryInfo di = new DirectoryInfo(File_Full_path);
                if (!di.Exists)
                {
                    di.Create();
                }
                File_Full_path = File_Full_path + "\\" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".jpg";
                image.Save(File_Full_path);
                ImgThumbnail(File_Full_path);
                Clipboard.Clear();
            }
        }

        /// <summary>
        /// name         : DB_Save
        /// desc         : 이미지 저장 정보를 DB에 전송한다.
        /// author       : 심우종
        /// create date  : 2020-04-16 09:03
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        //        private void DB_Save(string FILEPATH)
        //        {
        //            pathology_data.insertdate[0] = DateTime.Now.ToString("yyyyMMdd");
        //            if (pathology_data.Studydate[0] == "" || pathology_data.Studydate[0] == null)
        //            {
        //                pathology_data.Studydate[0] = DateTime.Now.ToString("yyyyMMdd");
        //            }
        //            if (pathology_data.PID[0] == "")
        //            {
        //                pathology_data.PID[0] = "NOPID";
        //            }

        //            //pathology_data.PID[0] = Btn_SPID.Text;
        //            pathology_data.FILEPATH[0] = FILEPATH;
        //            //imagetable type 정하기
        //            string imagetableTYPE = "0";
        //            switch (this.cmbImageType.SelectedText)
        //            {
        //                case "조직병리":
        //                    imagetableTYPE = "0";
        //                    break;
        //                case "현미경":
        //                    imagetableTYPE = "1";
        //                    break;
        //                case "분자병리":
        //                    imagetableTYPE = "2";
        //                    break;
        //            }

        //            bool m_new = false;
        //            string m_studyid;
        //            string m_accessno;
        //            // studytable 조회
        //            strQuery = "SELECT * FROM studytable where PATHONO = '" + pathology_data.PathogyNo[0] + "' ";
        //            MySqlCommand cmd = new MySqlCommand(strQuery, myConnection);
        //            MySqlDataReader rdr = cmd.ExecuteReader();
        //            if (rdr.Read())
        //            {

        //                m_studyid = rdr["STUDYID"].ToString();
        //                m_accessno = "";
        //                pathology_data.UID[0] = rdr["UID"].ToString();

        //                cmd.Dispose();
        //                rdr.Close();
        //                m_new = false;
        //                switch (Btn_Type.Text)
        //                {
        //                    case "조직병리":
        //                        strQuery = string.Format("Update studytable set GI = GI+1 Where studyid = '{0}'", m_studyid);
        //                        break;
        //                    case "현미경":
        //                        strQuery = string.Format("Update studytable set MI = MI+1 Where studyid = '{0}'", m_studyid);
        //                        break;
        //                    case "분자병리":
        //                        strQuery = string.Format("Update studytable set OI = OI+1 Where studyid = '{0}'", m_studyid);
        //                        break;
        //                }

        //                cmd.CommandText = strQuery;
        //                rdr.Close();
        //                cmd.ExecuteNonQuery();
        //            }
        //            else
        //            {
        //                cmd.Dispose();
        //                rdr.Close();
        //#if DEBUG
        //                pathology_data.UID[0] = "";
        //#else
        //                pathology_data.UID[0] = blob.SearchNumber(pathology_data.PathogyNo[0], Global.strEMRTNSNAME, Global.strEMRID, Global.strEMRPASSWORD).ToString();
        //#endif
        //                MessageBox.Show(pathology_data.UID[0].ToString());
        //                strQuery = "SELECT ACCESSNO + 1 AS ACCESSNO,STUDYID + 1 AS STUDYID FROM basetable ";
        //                cmd.CommandText = strQuery;
        //                rdr = cmd.ExecuteReader();
        //                rdr.Read();
        //                m_studyid = rdr["STUDYID"].ToString();
        //                m_accessno = rdr["ACCESSNO"].ToString();
        //                pathology_data.ACCESSNO[0] = DateTime.Now.ToString("yyyyMMdd") + "99" + rdr["ACCESSNO"].ToString().PadLeft(6, '0');
        //                m_new = true;
        //                cmd.Dispose();
        //                rdr.Close();
        //                switch (Btn_Type.Text)
        //                {
        //                    case "조직병리":
        //                        strQuery = string.Format("INSERT INTO StudyTable( StudyID, PatID, Studydate,InsertDate, GI, MI, OI, PATHONO, SendStatus , STUDYRESULT, UID, DSTUDY_1, DSTUDY_2, DSTUDY_3 , STUDYNAME, ACCESSID ) " +
        //                        "VALUES ( {0}, '{1}', '{2}', '{3}', 1, 0, 0, '{4}', 0 ,'','{5}','{6}','{7}','{8}','{9}','{10}') ", m_studyid, pathology_data.PID[0], pathology_data.Studydate[0], pathology_data.insertdate[0], pathology_data.PathogyNo[0], pathology_data.UID[0], pathology_data.DStudy_1[0], pathology_data.DStudy_2[0], pathology_data.DStudy_3[0], pathology_data.Studyname[0], pathology_data.ACCESSNO[0]);

        //                        break;
        //                    case "현미경":
        //                        strQuery = string.Format("INSERT INTO StudyTable( StudyID, PatID, Studydate,InsertDate, GI, MI, OI, PATHONO, SendStatus , STUDYRESULT, UID, DSTUDY_1, DSTUDY_2, DSTUDY_3 , STUDYNAME, ACCESSID ) " +
        //                         "VALUES ( {0}, '{1}', '{2}', '{3}', 0, 1, 0, '{4}', 0 ,'','{5}','{6}','{7}','{8}','{9}','{10}') ", m_studyid, pathology_data.PID[0], pathology_data.Studydate[0], pathology_data.insertdate[0], pathology_data.PathogyNo[0], pathology_data.UID[0], pathology_data.DStudy_1[0], pathology_data.DStudy_2[0], pathology_data.DStudy_3[0], pathology_data.Studyname[0], pathology_data.ACCESSNO[0]);

        //                        break;
        //                    case "분자병리":
        //                        strQuery = string.Format("INSERT INTO StudyTable( StudyID, PatID, Studydate,InsertDate, GI, MI, OI, PATHONO, SendStatus , STUDYRESULT, UID, DSTUDY_1, DSTUDY_2, DSTUDY_3 , STUDYNAME, ACCESSID ) " +
        //                        "VALUES ( {0}, '{1}', '{2}', '{3}', 0, 0, 1, '{4}', 0 ,'','{5}','{6}','{7}','{8}','{9}','{10}') ", m_studyid, pathology_data.PID[0], pathology_data.Studydate[0], pathology_data.insertdate[0], pathology_data.PathogyNo[0], pathology_data.UID[0], pathology_data.DStudy_1[0], pathology_data.DStudy_2[0], pathology_data.DStudy_3[0], pathology_data.Studyname[0], pathology_data.ACCESSNO[0]);

        //                        break;
        //                }
        //                cmd.CommandText = strQuery;
        //                rdr.Close();
        //                cmd.ExecuteNonQuery();

        //            }
        //            // imagetable SerialNo 조회
        //            strQuery = string.Format("Select max(serialno) from imagetable Where studyid = '{0}'", m_studyid);
        //            cmd.CommandText = strQuery;
        //            rdr = cmd.ExecuteReader();
        //            rdr.Read();
        //            string serialnocount = rdr["max(serialno)"].ToString();
        //            if (serialnocount == "")
        //            { serialnocount = "0"; }
        //            rdr.Close();



        //            // imagetable 저장
        //            strQuery = string.Format("insert into imagetable(TYPE,SERIALNO,STUDYID,ROOTPATH,FILEPATH,SENDSTATUS) " +
        //                         "VALUES({0},{1}+1,'{2}','{3}','{4}',0)", imagetableTYPE, serialnocount, m_studyid, pathology_data.ROOTPATH[0].Replace("\\", "\\\\"), pathology_data.FILEPATH[0].Replace("\\", "\\\\"));
        //            cmd.CommandText = strQuery;
        //            cmd.ExecuteNonQuery();
        //            rdr.Close();
        //            // imagetable 저장
        //            /////////////////
        //            strQuery = "SELECT * FROM patienttable where PATID = '" + pathology_data.PID[0] + "'";
        //            cmd.CommandText = strQuery;
        //            rdr = cmd.ExecuteReader();
        //            if (!rdr.Read())
        //            {
        //                strQuery = string.Format("insert into patienttable (PATID,PATNAME,PATBIRTH,PATAGE,PATSEX) " +
        //                                         "VALUES('{0}','{1}','{2}','{3}','{4}')", pathology_data.PID[0], pathology_data.PATNAME[0], pathology_data.PATBIR[0], pathology_data.PATAGE[0], pathology_data.PATSEX[0]);
        //                cmd.CommandText = strQuery;
        //                rdr.Close();
        //                cmd.ExecuteNonQuery();
        //            }
        //            else
        //            {
        //                strQuery = string.Format("update patienttable set PATNAME = '{0}', PATBIRTH = '{1}', PATAGE = '{2}', PATSEX = '{3}' where PATID = '{4}' "
        //                                         , pathology_data.PATNAME[0], pathology_data.PATBIR[0], pathology_data.PATAGE[0], pathology_data.PATSEX[0], pathology_data.PID[0]);
        //                cmd.CommandText = strQuery;
        //                rdr.Close();
        //                cmd.ExecuteNonQuery();
        //            }
        //            rdr.Close();
        //            /////////////////

        //            if (m_new == true)//베이스테이블에서 스터디아이디를 끌고온경우만 업데이트
        //            {
        //                // basetable 저장
        //                strQuery = string.Format("UPDATE BaseTable SET StudyID = {0}, ACCESSNO = {1} ", m_studyid, m_accessno);
        //                cmd.CommandText = strQuery;
        //                cmd.ExecuteNonQuery();
        //                rdr.Close();
        //            }
        //        }
    }
}