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
using GdPicture14;
using LicenseManager = GdPicture14.LicenseManager;
using System.Diagnostics;
using ImageOCR.DTO;
using System.IO;
using ImageOCR.Properties;
using Sedas.Core;
using Sedas.ImageHelper;
using Sedas.DB;


namespace ImageOCR
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        public MainForm()
        {
            InitializeComponent();
        }


        bool op_EnableVigorousDespeckle = false;
        int op_CharacterSetIndex = 2;
        int op_ContextCheckIndex = 0;
        int op_ModeIndex = 1;



        private GdPicture14.GdViewer gdViewerForCheck;
        DataTable dt = new DataTable();
        bool isWorking = false; //작업 진행중 여부
        ImageHelper imageHelper = new ImageHelper();
        CallService callService = new CallService("10.10.221.71", "8180");
        BlobClass blob;
        FileTransfer ft = new FileTransfer();
        CoreLibrary core = new CoreLibrary();
        LogHelper logHelper = new LogHelper();

        List<ImageInfoDTO> workList = new List<ImageInfoDTO>();

        public bool IsWorking
        {
            get
            {
                return isWorking;
            }

            set
            {
                isWorking = value;
            }
        }

        private String appPath = Application.StartupPath;


        private void MainForm_Load(object sender, EventArgs e)
        {



            this.blob = new BlobClass(this.callService);

            //dt.Columns.Add("Name", typeof(String));
            //dt.Columns.Add("Image", typeof(String));

            //DataRow row = dt.NewRow();
            //row["Name"] = "test1";
            //row["Image"] = "C:\\BASE\\이미지 캡쳐\\A20200417042846.jpg";
            //dt.Rows.Add(row);

            //DataRow row2 = dt.NewRow();
            //row2["Name"] = "test2";
            //row2["Image"] = "C:\\BASE\\이미지 캡쳐\\A20200417042846.jpg";
            //dt.Rows.Add(row2);

            //layoutGridControl.DataSource = dt;


            LicenseManager licenseManager = new LicenseManager();
            licenseManager.RegisterKEY("21185684790302862131615213975647244276");
            //Please replace XXX by a valid demo or commercial key.

            _gdPictureImaging = new GdPictureImaging();
            _gdPictureOcr = new GdPictureOCR();
            _document = new Document(_gdPictureImaging, _gdPictureOcr);

            _gdPictureImagingForCheck = new GdPictureImaging();
            _gdPictureOcrForCheck = new GdPictureOCR();
            _documentForCheck = new Document(_gdPictureImagingForCheck, _gdPictureOcrForCheck);
            
            this.InitGlobal(); //전역변수 설정

            if (Global.isDev == "Y")
            {
                this.callService = new CallService("10.10.221.71", "8180");
                ft = new FileTransfer("10.10.221.72", "1111");
                this.Text = this.Text + "  (개발)";
            }
            else
            {
                this.callService = new CallService(Global.callService);
            }





            this.InitControl();

            //if (tbResouceFolder.Text.Length == 0)
            //{
            //    tbResouceFolder.Text = licenseManager.GetRedistPath() + "OCR\\";
            //}

            //OCRLanguage resourceLanguage;
            UpdateLanguages(resourceFolder, new OCRLanguage[] { OCRLanguage.Dutch });

            UpdateControlsDocumentClosed();

            //타이머 실행
            if (timer == null)
            {
                this.timer = new Timer();
                this.timer.Interval = 2000;
                this.timer.Tick += Timer_Tick;
            }

            this.timer.Stop();
            this.timer.Start();
        }



        private void InitGdPictureForCheck()
        {
            if (this.gdViewerForCheck == null)
            {
                this.gdViewerForCheck = new GdViewer();
                this.gdViewerForCheck.AllowDropFile = false;
                this.gdViewerForCheck.AnimateGIF = false;
                this.gdViewerForCheck.AnnotationDropShadow = false;
                this.gdViewerForCheck.AnnotationResizeRotateHandlesColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
                this.gdViewerForCheck.AnnotationResizeRotateHandlesScale = 1F;
                this.gdViewerForCheck.AnnotationSelectionLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
                this.gdViewerForCheck.AutoScrollMargin = new System.Drawing.Size(0, 0);
                this.gdViewerForCheck.AutoScrollMinSize = new System.Drawing.Size(0, 0);
                this.gdViewerForCheck.BackColor = System.Drawing.Color.Gray;
                this.gdViewerForCheck.BackgroundImage = null;
                this.gdViewerForCheck.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
                this.gdViewerForCheck.ContinuousViewMode = true;
                this.gdViewerForCheck.DisplayQuality = GdPicture14.DisplayQuality.DisplayQualityBicubicHQ;
                this.gdViewerForCheck.DisplayQualityAuto = false;
                this.gdViewerForCheck.Dock = System.Windows.Forms.DockStyle.Fill;
                this.gdViewerForCheck.DocumentAlignment = GdPicture14.ViewerDocumentAlignment.DocumentAlignmentMiddleCenter;
                this.gdViewerForCheck.DocumentPosition = GdPicture14.ViewerDocumentPosition.DocumentPositionMiddleCenter;
                this.gdViewerForCheck.DrawPageBorders = true;
                this.gdViewerForCheck.EnableDeferredPainting = true;
                this.gdViewerForCheck.EnabledProgressBar = true;
                this.gdViewerForCheck.EnableICM = false;
                this.gdViewerForCheck.EnableMenu = true;
                this.gdViewerForCheck.EnableMouseWheel = true;
                this.gdViewerForCheck.EnableTextSelection = true;
                this.gdViewerForCheck.ForceScrollBars = false;
                this.gdViewerForCheck.ForceTemporaryMode = false;
                this.gdViewerForCheck.ForeColor = System.Drawing.Color.Black;
                this.gdViewerForCheck.Gamma = 1F;
                this.gdViewerForCheck.HQAnnotationRendering = true;
                this.gdViewerForCheck.IgnoreDocumentResolution = false;
                this.gdViewerForCheck.KeepDocumentPosition = false;
                this.gdViewerForCheck.Location = new System.Drawing.Point(2, 2);
                this.gdViewerForCheck.LockViewer = false;
                this.gdViewerForCheck.MagnifierHeight = 90;
                this.gdViewerForCheck.MagnifierWidth = 160;
                this.gdViewerForCheck.MagnifierZoomX = 2F;
                this.gdViewerForCheck.MagnifierZoomY = 2F;
                this.gdViewerForCheck.Margin = new System.Windows.Forms.Padding(2);
                this.gdViewerForCheck.MouseButtonForMouseMode = GdPicture14.MouseButton.MouseButtonLeft;
                this.gdViewerForCheck.MouseMode = GdPicture14.ViewerMouseMode.MouseModeAreaSelection;
                this.gdViewerForCheck.MouseWheelMode = GdPicture14.ViewerMouseWheelMode.MouseWheelModeZoom;
                this.gdViewerForCheck.Name = "gdViewer1";
                this.gdViewerForCheck.PageBordersColor = System.Drawing.Color.Black;
                this.gdViewerForCheck.PageBordersPenSize = 1;
                this.gdViewerForCheck.PageDisplayMode = GdPicture14.PageDisplayMode.SinglePageView;
                this.gdViewerForCheck.PdfDisplayFormField = true;
                this.gdViewerForCheck.PdfEnableFileLinks = true;
                this.gdViewerForCheck.PdfEnableLinks = true;
                this.gdViewerForCheck.PdfIncreaseTextContrast = false;
                this.gdViewerForCheck.PdfRasterizerEngine = GdPicture14.PdfRasterizerEngine.PdfRasterizerEngineHybrid;
                this.gdViewerForCheck.PdfShowDialogForPassword = true;
                this.gdViewerForCheck.PdfShowOpenFileDialogForDecryption = true;
                this.gdViewerForCheck.PdfVerifyDigitalCertificates = false;
                this.gdViewerForCheck.RectBorderColor = System.Drawing.Color.Black;
                this.gdViewerForCheck.RectBorderSize = 1;
                this.gdViewerForCheck.RectIsEditable = true;
                this.gdViewerForCheck.RegionsAreEditable = true;
                this.gdViewerForCheck.RenderGdPictureAnnots = true;
                this.gdViewerForCheck.ScrollBars = true;
                this.gdViewerForCheck.ScrollLargeChange = ((short)(50));
                this.gdViewerForCheck.ScrollSmallChange = ((short)(1));
                this.gdViewerForCheck.SilentMode = true;
                this.gdViewerForCheck.Size = new System.Drawing.Size(491, 438);
                this.gdViewerForCheck.TabIndex = 1;
                this.gdViewerForCheck.ViewRotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
                this.gdViewerForCheck.Zoom = 1D;
                this.gdViewerForCheck.ZoomCenterAtMousePosition = false;
                this.gdViewerForCheck.ZoomMode = GdPicture14.ViewerZoomMode.ZoomMode100;
                this.gdViewerForCheck.ZoomStep = 25;
            }

        }


        /// <summary>
        /// name         : InitControl
        /// desc         : 컨트롤 초기화
        /// author       : 심우종
        /// create date  : 2020-07-21 15:51
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitControl()
        {
            this.InitGdPictureForCheck();
            this.txtWorkingPath.Text = Global.strWorkingPath;

            if (!string.IsNullOrEmpty(this.txtWorkingPath.Text))
            {
                FileCheck();
            }

            //type콤보박스 설정
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

            string typeValue = Global.G_IniReadValue("OCR", "TYPE_VALUE", Global.strSettingPath);
            if (!string.IsNullOrEmpty(typeValue))
            {
                cmbImageType.SedasSelectedValue = typeValue;
            }

            this.grdWorkList.DataSource = workList;

            //if ( Global.strAutoCheck == "Y")
            //{
            //    this.chkAuto.Checked = true;
            //}
            //else
            //{
            //    this.chkAuto.Checked = false;
            //}

            //this.AutoImageCheck();

            //workList.Add(new ImageInfoDTO());

        }

        int g_left = 0;
        int g_top = 0;
        int g_width = 0;
        int g_height = 0;

        int g2_left = 0;
        int g2_top = 0;
        int g2_width = 0;
        int g2_height = 0;

        int g3_width = 0;
        int g3_height = 0;

        string resourceFolder = "";
        private void InitGlobal()
        {

            string iniPath = Global.strSettingPath;
            FileInfo file = new FileInfo(iniPath);
            if (file.Exists == false)
            {
                DirectoryInfo di = new DirectoryInfo(System.Environment.CurrentDirectory + "\\Setting");
                if (di.Exists == false)
                {
                    di.Create();
                }

                file.Create();

                //INI 파일 초기값 설정
                Global.G_IniWriteValue("REGION", "REGION_LEFT", "0", Global.strSettingPath);
                Global.G_IniWriteValue("REGION", "REGION_TOP", "0", Global.strSettingPath);
                Global.G_IniWriteValue("REGION", "REGION_WIDTH", "800", Global.strSettingPath);
                Global.G_IniWriteValue("REGION", "REGION_HEIGHT", "450", Global.strSettingPath);

                Global.G_IniWriteValue("REGION", "REGION_DETAIL_LEFT", "58", Global.strSettingPath);
                Global.G_IniWriteValue("REGION", "REGION_DETAIL_TOP", "51", Global.strSettingPath);
                Global.G_IniWriteValue("REGION", "REGION_DETAIL_WIDTH", "838", Global.strSettingPath);
                Global.G_IniWriteValue("REGION", "REGION_DETAIL_HEIGHT", "274", Global.strSettingPath);

                Global.G_IniWriteValue("OCR", "WORKING_PATH", "D:\\OCR_WORK", Global.strSettingPath);
                Global.G_IniWriteValue("OCR", "IMAGE_PATH", "Imagedata\\", Global.strSettingPath);
            }


            //insert용 임시!!!!!!!!!!!!!!
            //Global.G_IniWriteValue("REGION", "REGION_LEFT", "0", Global.strSettingPath);
            //Global.G_IniWriteValue("REGION", "REGION_TOP", "0", Global.strSettingPath);
            //Global.G_IniWriteValue("REGION", "REGION_WIDTH", "800", Global.strSettingPath);
            //Global.G_IniWriteValue("REGION", "REGION_HEIGHT", "450", Global.strSettingPath);

            //Global.G_IniWriteValue("REGION", "REGION_DETAIL_LEFT", "58", Global.strSettingPath);
            //Global.G_IniWriteValue("REGION", "REGION_DETAIL_TOP", "51", Global.strSettingPath);
            //Global.G_IniWriteValue("REGION", "REGION_DETAIL_WIDTH", "838", Global.strSettingPath);
            //Global.G_IniWriteValue("REGION", "REGION_DETAIL_HEIGHT", "274", Global.strSettingPath);

            //Global.G_IniWriteValue("OCR", "WORKING_PATH", "D:\\OCR_WORK", Global.strSettingPath);


            //1차 체크
            //this.g_left = 0;
            //this.g_top = 0;
            //this.g_width = 800;
            //this.g_height = 450;

            ////디테일 체크용
            //this.g2_left = 58;
            //this.g2_top = 51;
            //this.g2_width = 838;
            //this.g2_height = 274;

            //1차 체크
            this.g_left = Global.G_IniReadValue("REGION", "REGION_LEFT", Global.strSettingPath).ToInt();
            this.g_top = Global.G_IniReadValue("REGION", "REGION_TOP", Global.strSettingPath).ToInt();
            this.g_width = Global.G_IniReadValue("REGION", "REGION_WIDTH", Global.strSettingPath).ToInt();
            this.g_height = Global.G_IniReadValue("REGION", "REGION_HEIGHT", Global.strSettingPath).ToInt();

            //디테일 체크용
            this.g2_left = Global.G_IniReadValue("REGION", "REGION_DETAIL_LEFT", Global.strSettingPath).ToInt();
            this.g2_top = Global.G_IniReadValue("REGION", "REGION_DETAIL_TOP", Global.strSettingPath).ToInt();
            this.g2_width = Global.G_IniReadValue("REGION", "REGION_DETAIL_WIDTH", Global.strSettingPath).ToInt();
            this.g2_height = Global.G_IniReadValue("REGION", "REGION_DETAIL_HEIGHT", Global.strSettingPath).ToInt();

            this.g3_width= Global.G_IniReadValue("REGION", "REGION_BIG_WIDTH", Global.strSettingPath).ToInt();
            this.g3_height = Global.G_IniReadValue("REGION", "REGION_BIG_HEIGHT", Global.strSettingPath).ToInt();


            //작업 경로
            Global.strWorkingPath = Global.G_IniReadValue("OCR", "WORKING_PATH", Global.strSettingPath);



            //이미지 저장 경로
            Global.strImagePath = Global.G_IniReadValue("OCR", "IMAGE_PATH", Global.strSettingPath);
            //Global.strAutoCheck = Global.G_IniReadValue("OCR", "AUTO_CHECK", Global.strSettingPath);

            Global.callService = Global.G_IniReadValue("DB", "CallService", Global.strSettingPath);
            Global.isDev = Global.G_IniReadValue("DB", "IsDev", Global.strSettingPath);

            //deatil 체크..
            resourceFolder = System.Environment.CurrentDirectory + "\\" + "Resource\\";
        }

        //private void layoutView1_CustomUnboundColumnData(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDataEventArgs e)
        //{
        //    if ( e.Column.FieldName == "Image")
        //    {
        //        string avlue =   layoutView1.GetRowCellValue(e.ListSourceRowIndex, e.Column).ToString();

        //    }
        //}


        /// <summary>
        /// Updates the languages proposed to the user
        /// </summary>
        private void UpdateLanguages(string resourceFolder, OCRLanguage[] selectedLanguages)
        {
            //lbLanguages.Items.Clear();

            _gdPictureOcr.ResourceFolder = resourceFolder;
            _gdPictureOcrForCheck.ResourceFolder = resourceFolder;
            //IList<OCRLanguage> languages = _gdPictureOcr.GetAvailableLanguages();
            //if (languages != null)
            //{
            //    foreach (OCRLanguage language in languages)
            //    {
            //        int index = lbLanguages.Items.Add(language);
            //        if (selectedLanguages != null && selectedLanguages.Contains(language))
            //        {
            //            lbLanguages.SetSelected(index, true);
            //        }
            //    }
            //}
        }

        /// <summary>
        /// The current document.
        /// </summary>
        private Document _document;
        private Document _documentForCheck;

        /// <summary>
        /// GdPictureImaging instance.
        /// </summary>
        private GdPictureImaging _gdPictureImaging;

        /// <summary>
        /// GdPictureImaging instance.
        /// </summary>
        private GdPictureImaging _gdPictureImagingForCheck;

        /// <summary>
        /// GdPictureOcr instance.
        /// </summary>
        private GdPictureOCR _gdPictureOcr;

        /// <summary>
        /// GdPictureOcr instance.
        /// </summary>
        private GdPictureOCR _gdPictureOcrForCheck;


        private OCRSpecialContext _ocrSpecialContext = OCRSpecialContext.None;

        /// <summary>
        /// The rasterization when loading the image from a pdf.
        /// </summary>
        private const int PdfRasterizationResolution = 300;

        //private void hSimpleButton1_Click(object sender, EventArgs e)
        //{
        //    OpenFileDialog openFileDialog = new OpenFileDialog();
        //    if (openFileDialog.ShowDialog(this) == DialogResult.OK)
        //    {
        //        _document.Close();
        //        UpdateControlsDocumentClosed();
        //        gdViewer1.ZoomMode = ViewerZoomMode.ZoomModeFitToViewer;
        //        Cursor.Current = Cursors.WaitCursor;
        //        bool bSuccess = _document.Load(openFileDialog.FileName, PdfRasterizationResolution);
        //        Cursor.Current = Cursors.Default;
        //        if (bSuccess)
        //        {
        //            UpdateControlsDocumentLoaded();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Failed to load " + openFileDialog.FileName, "Error", MessageBoxButtons.OK,
        //                MessageBoxIcon.Exclamation);
        //        }
        //    }

        //}

        /// <summary>
        /// UpdateControlsDocumentLoaded updates the controls after the document has been loaded.
        /// </summary>
        private void UpdateControlsDocumentLoaded()
        {
            gdViewer1.DisplayFromGdPictureImage(_document.ImageId);

            //closeToolStripMenuItem.Enabled = true;
            //viewToolStripMenuItem.Enabled = true;
            //rotateToolStripMenuItem.Enabled = true;
            //imageEnhancementToolStripMenuItem.Enabled = true;
            //ocrToolStripMenuItem.Enabled = true;
            updateImageInfo();
        }

        private void UpdateControlsDocumentClosed()
        {
            //this.Text = InitialText;
            UpdateControlsOcrResultDiscarded();
            gdViewer1.CloseDocument();

            //closeToolStripMenuItem.Enabled = false;
            //viewToolStripMenuItem.Enabled = false;
            //rotateToolStripMenuItem.Enabled = false;
            //imageEnhancementToolStripMenuItem.Enabled = false;
            //ocrToolStripMenuItem.Enabled = false;
            updateImageInfo();
        }

        private void UpdateControlsOcrResultDiscarded()
        {
            //rtbText.Text = "";
            gdViewer1.RemoveAllRegions();
            //btnSave.Enabled = false;
        }

        private void updateImageInfo()
        {
            //if (_document.IsOpen)
            //{
            //    tsImageInfo.Text = "Image properties :: width: " + _gdPictureImaging.GetWidth(_document.ImageId).ToString() + "." +
            //                       " height: " + _gdPictureImaging.GetHeight(_document.ImageId).ToString() + "." +
            //                       " horizontal resolution: " + _gdPictureImaging.GetHorizontalResolution(_document.ImageId).ToString() + " dpi." +
            //                       " vertical resolution: " + _gdPictureImaging.GetVerticalResolution(_document.ImageId).ToString() + " dpi." +
            //                       " bit depth: " + _gdPictureImaging.GetBitDepth(_document.ImageId) + " bpp.";
            //}
            //else
            //{
            //    tsImageInfo.Text = "";
            //}
        }


        /// <summary>
        /// name         : btnOCR_Click
        /// desc         : OCR버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-06-05 14:39
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        //private void btnOCR_Click(object sender, EventArgs e)
        //{
        //    if (_document.IsOpen)
        //    {
        //        _document.DiscardOcrResult();
        //        UpdateControlsOcrResultDiscarded();
        //        int left = 139;
        //        int top = 100;
        //        int width = 679;
        //        int height = 185;
        //        //gdViewer1.GetRectCoordinatesOnDocument(ref left, ref top, ref width, ref height);
        //        lblrect.Text = left.ToString() + ", " + top.ToString() + ", " + width.ToString() + ", " + height.ToString();
        //        StartOCR(left, top, width, height);



        //        //if (gdViewer1.IsRect())
        //        //{
        //        //    _document.DiscardOcrResult();
        //        //    UpdateControlsOcrResultDiscarded();

        //        //    //아래 4개 값으로 포지션을 잡으면 될듯 하다..
        //        //    //int left = 0;
        //        //    //int top = 0;
        //        //    //int width = 0;
        //        //    //int height = 0;
        //        //    //gdViewer1.GetRectCoordinatesOnDocument(ref left, ref top, ref width, ref height);

        //        //    int left = 139;
        //        //    int top = 100;
        //        //    int width = 679;
        //        //    int height = 185;
        //        //    StartOCR(left, top, width, height);
        //        //}
        //        //else
        //        //{
        //        //    MessageBox.Show("Please draw a region of interest into the viewer in order to specify the zone to read.");
        //        //}
        //    }
        //}



        /// <summary>
        /// name         : StartOCR
        /// desc         : OCR재점검 시작
        /// author       : 심우종
        /// create date  : 2020-08-05 09:28
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary>  
        private void StartOCR(int roiLeft, int roiTop, int roiWidth, int roiHeight)
        {
            SetOcrParameters(roiLeft, roiTop, roiWidth, roiHeight, 0);
            Cursor.Current = Cursors.WaitCursor;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            _document.OcrResultId = _gdPictureOcr.RunOCR(_ocrSpecialContext);
            stopWatch.Stop();
            //if (_gdPictureOcr.GetStat() == GdPictureStatus.OK)
            //{
            //    this.Text = InitialText + " - Elapsed: " + stopWatch.Elapsed.ToString() + ". Average confidence: " + _gdPictureOcr.GetAverageWordConfidence(_document.OcrResultId) + " %";

            //}
            //else
            //{
            //    this.Text = InitialText;
            //}
            Cursor.Current = Cursors.Default;

            UpdateControlsOcrResultCreated();


        }


        /// <summary>
        /// name         : rotateRight90ToolStripMenuItem_Click
        /// desc         : 오른쪽으로 90도 돌리기
        /// author       : 심우종
        /// create date  : 2020-06-15 13:54
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void rotateRight90ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_document.IsOpen)
            {
                _document.DiscardOcrResult();
                UpdateControlsOcrResultDiscarded();

                GdPictureStatus errorCode = _gdPictureImaging.Rotate(_document.ImageId,
                    RotateFlipType.Rotate90FlipNone);
                if (errorCode != GdPictureStatus.OK)
                {
                    DisplayError(errorCode);
                }
                gdViewer1.Redraw();
            }
        }


        /// <summary>
        /// name         : rotateLeft90ToolStripMenuItem_Click
        /// desc         : 왼쪽으로 90도 돌리기
        /// author       : 심우종
        /// create date  : 2020-06-15 13:54
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void rotateLeft90ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (_document.IsOpen)
            {
                _document.DiscardOcrResult();
                UpdateControlsOcrResultDiscarded();

                GdPictureStatus errorCode = _gdPictureImaging.Rotate(_document.ImageId,
                    RotateFlipType.Rotate270FlipNone);
                if (errorCode != GdPictureStatus.OK)
                {
                    DisplayError(errorCode);
                }
                gdViewer1.Redraw();
            }
        }


        /// <summary>
        /// name         : UpdateControlsOcrResultCreated
        /// desc         : Ocr재점검 완료후 처리
        /// author       : 심우종
        /// create date  : 2020-08-05 09:29
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void UpdateControlsOcrResultCreated()
        {
            if (!_document.HasOcr)
            {
                DisplayError(_gdPictureOcr.GetStat());
            }
            else
            {
                DisplayBoxes();
                txtTest.Text = _document.OCRResult;
                string ocrResultPre = _document.OCRResult;
                //this.txtResult.Text = ocrResultPre;


                string ocrResult = OcrResultFilter(ocrResultPre);

                if (!string.IsNullOrEmpty(ocrResult))
                {
                    this.txtRePtoNo.Text = ocrResult;
                }
            }
        }

        /// <summary>
        /// Displays the error message corresponding to the provided code.
        /// </summary>
        /// <param name="errorCode"></param>
        private void DisplayError(GdPictureStatus errorCode)
        {
            DevExpress.XtraEditors.XtraMessageBox.Show("The operation failed with error code " + errorCode.ToString(), "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Exclamation);
        }

        /// <summary>
        /// Displays the boxes.
        /// </summary>
        private void DisplayBoxes()
        {
            //Rectangle[] blocks = blocksToolStripMenuItem.Checked ? _document.BlocksBoundingBoxes : null;
            //Rectangle[] paragraphs = paragraphsToolStripMenuItem.Checked ? _document.ParagraphsBoundingBoxes : null;
            //Rectangle[] textLines = textLinesToolStripMenuItem.Checked ? _document.TextLinesBoundingBoxes : null;
            //Rectangle[] words = wordsToolStripMenuItem.Checked ? _document.WordsBoundingBoxes : null;
            //Rectangle[] characters = charactersToolStripMenuItem.Checked ? _document.CharactersBoundingBoxes : null;

            //Utilities.MarkRegions(gdViewer1, blocks, paragraphs, textLines, words, characters,
            //    _gdPictureImaging.GetHorizontalResolution(_document.ImageId),
            //    _gdPictureImaging.GetVerticalResolution(_document.ImageId));
        }

        /// <summary>
        /// The map to obtain the context based on the selected item within the combo box.
        /// </summary>
        private static readonly OCRContext[] OcrContextMap =
        {
            OCRContext.OCRContextDocument,
            OCRContext.OCRContextSingleColumn,
            OCRContext.OCRContextSingleBlock,
            OCRContext.OCRContextSingleBlockVertical,
            OCRContext.OCRContextSingleLine,
            OCRContext.OCRContextSingleWord,
            OCRContext.OCRContextSingleWordCircle,
            OCRContext.OCRContextSingleChar,
            OCRContext.OCRContextSparseText,
            OCRContext.OCRContextRawLine,
            OCRContext.OCRContextSegmentationOnly
        };


        /// <summary>
        /// The map to obtain the mode based on the selected item within the combo box.
        /// </summary>
        private static readonly OCRMode[] OcrModeMap =
        {
            OCRMode.FavorAccuracy,
            OCRMode.FavorSpeed
        };


        /// <summary>
        /// name         : SetOcrParameters
        /// desc         : OCR 옵션 설정 (OCR 재점검용)
        /// author       : 심우종
        /// create date  : 2020-06-05 15:02
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SetOcrParameters(int roiLeft, int roiTop, int roiWidth, int roiHeight, int ContextCheckIndex)
        {
            _gdPictureOcr.SetImage(_document.ImageId);

            int index = ContextCheckIndex; // OCRContextSingleBlock  2

            _gdPictureOcr.Context = OcrContextMap[op_ContextCheckIndex];

            _gdPictureOcr.ResetSelectedDictionaries();
            _gdPictureOcr.AddLanguage(OCRLanguage.Dutch); //Dutch

            _gdPictureOcr.CharacterSet = GetCharacterSet(op_CharacterSetIndex); //0

            //_gdPictureOcr.CharacterSet = "0123456789.,-S";
            _gdPictureOcr.CharacterBlackList = "$§";
            _ocrSpecialContext = OCRSpecialContext.None;




            //Try to vigorously remove noise (vigorous despeckle)
            _gdPictureOcr.EnableVigorousDespeckle = op_EnableVigorousDespeckle;

            float nNonDictWords = 15; //15
            //Penalty for words no in the dict.:
            _gdPictureOcr.LanguageModelPenaltyNonDictWords = (float)nNonDictWords / 100;

            float nNonFreqWords = 10; //10
            //Penalty for no frequent words:
            _gdPictureOcr.LanguageModelPenaltyNonFreqDictWords = (float)nNonFreqWords / 100;


            _gdPictureOcr.ResourceFolder = this.resourceFolder;
            _gdPictureOcr.LoadMainDictionary = true;
            _gdPictureOcr.LoadFreqWordsDictionary = true;

            _gdPictureOcr.EnableOrientationDetection = false;
            _gdPictureOcr.EnableSkewDetection = true;
            _gdPictureOcr.EnablePreprocessing = true;

            _gdPictureOcr.OCRMode = OcrModeMap[op_ModeIndex];

            _gdPictureOcr.SetROI(roiLeft, roiTop, roiWidth, roiHeight);
        }

 

        /// <summary>
        /// name         : SetOcrParametersForCheck
        /// desc         : OCR 옵션 설정 점검용 OCR
        /// author       : 심우종
        /// create date  : 2020-08-05 09:31
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SetOcrParametersForCheck(int roiLeft, int roiTop, int roiWidth, int roiHeight, int ContextCheckIndex)
        {
            _gdPictureOcrForCheck.SetImage(_documentForCheck.ImageId);

            int index = ContextCheckIndex; // OCRContextSingleBlock  2

            _gdPictureOcrForCheck.Context = OcrContextMap[op_ContextCheckIndex];

            _gdPictureOcrForCheck.ResetSelectedDictionaries();
            _gdPictureOcrForCheck.AddLanguage(OCRLanguage.Dutch); //Dutch

            _gdPictureOcrForCheck.CharacterSet = GetCharacterSet(op_CharacterSetIndex); //0

            //_gdPictureOcr.CharacterSet = "0123456789.,-S";
            _gdPictureOcrForCheck.CharacterBlackList = "$§";
            _ocrSpecialContext = OCRSpecialContext.None;




            //Try to vigorously remove noise (vigorous despeckle)
            _gdPictureOcrForCheck.EnableVigorousDespeckle = op_EnableVigorousDespeckle;

            float nNonDictWords = 15; //15
            //Penalty for words no in the dict.:
            _gdPictureOcrForCheck.LanguageModelPenaltyNonDictWords = (float)nNonDictWords / 100;

            float nNonFreqWords = 10; //10
            //Penalty for no frequent words:
            _gdPictureOcrForCheck.LanguageModelPenaltyNonFreqDictWords = (float)nNonFreqWords / 100;


            _gdPictureOcrForCheck.ResourceFolder = this.resourceFolder;
            _gdPictureOcrForCheck.LoadMainDictionary = true;
            _gdPictureOcrForCheck.LoadFreqWordsDictionary = true;

            _gdPictureOcrForCheck.EnableOrientationDetection = false;
            _gdPictureOcrForCheck.EnableSkewDetection = true;
            _gdPictureOcrForCheck.EnablePreprocessing = true;

            _gdPictureOcrForCheck.OCRMode = OcrModeMap[op_ModeIndex];

            _gdPictureOcrForCheck.SetROI(roiLeft, roiTop, roiWidth, roiHeight);
        }

        /// <summary>
        /// GetCharacterSet retrieves the characters for the selected character set.
        /// </summary>
        /// <returns>The characters.</returns>
        private string GetCharacterSet(int index)
        {
            switch (index)
            {
                case 1:
                    return "0123456789.,";
                case 2:
                    return "0123456789.,-SABCD";
                default:
                    return "";
            }
        }


        /// <summary>
        /// name         : btnImageAdd_Click
        /// desc         : 이미지 추가 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-06-05 16:21
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnImageAdd_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "jpg(*.*)|*.jpg*";
            DialogResult drs = ofd.ShowDialog();

            List<string> imageList = new List<string>();
            if (drs == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    //strPath = ofd.FileNames[i].ToString();
                    imageList.Add(ofd.FileNames[i].ToString());
                }
            }

            if (imageList != null && imageList.Count > 0)
            {
                timer.Stop();
                this.ImageAddAsync(imageList, isDirectAdded: true);
            }



        }



        //이미지 사이즈
        const int imageSize_BigHeight = 180;
        const int imageSize_BigWidth = 210;
        const int imageSize_smallHeight = 90;
        const int imageSize_smallWidth = 100;




        /// <summary>
        /// name         : ImageAdd
        /// desc         : 이미지 추가및 OCR점검
        /// author       : 심우종
        /// create date  : 2020-06-08 10:18
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private List<ImageInfoDTO> ImageAdd(List<string> imageList, bool isDirectAdded = false)
        {
            List<ImageInfoDTO> addedButtonValueList = new List<ImageInfoDTO>();

            for (int i = 0; i < imageList.Count; i++)
            {
                //string message = string.Format("({0} / {1}) OCR체크 중 입니다.", imageList.Count.ToString(), (i + 1).ToString());

                //lblImageInfo.Text = message;
                //lblImageInfo.Update();

                string filePath = imageList.ElementAt(i);


                ImageInfoDTO imageInfoDTO = new ImageInfoDTO();
                imageInfoDTO.StrRowFilePath = filePath;
                imageInfoDTO.FileName = filePath.Split('\\').LastOrDefault();
                if (isDirectAdded == true)
                {
                    imageInfoDTO.IsDirectAdded = true;
                }


                //GdPictureImaging _gdPictureImagingTemp = new GdPictureImaging();
                //GdPictureOCR _gdPictureOcrTemp = new GdPictureOCR();
                //Document _documentTemp = new Document(_gdPictureImagingTemp, _gdPictureOcrTemp);

                addedButtonValueList.Add(imageInfoDTO);

                //[이미지 로드]
                if (this.ImageLoad(filePath) == false) continue;

                for (int j = 0; j < 4; j++)
                {
                    if (j != 0)
                    {
                        //[90도 회전] 
                        this.Rotate();
                    }

                    //[OCR 체크]
                    string ocrResultPre = OcrCheck(this.g_left, this.g_top, this.g_width, this.g_height, 0);

                    this.totalCheckCount = 0;
                    //[OCR 결과값에서 필요한 데이터를 추출한다.]
                    string ocrResult = OcrResultFilter(ocrResultPre);

                    if (!string.IsNullOrEmpty(ocrResult))
                    {
                        imageInfoDTO.OcrResult = ocrResult.Replace("-", "");
                        break;
                    }
                    else
                    {
                        if (this.totalCheckCount >= 5)
                        {
                            //숫자가 5자리 이상 발견되었으면 디테일하게 체크를 한번더 실행하자.

                            //[ContextCheckIndex = document로 변경후 체크]
                            string ocrResultPre2 = OcrCheck(this.g_left, this.g_top, this.g_width, this.g_height, 2);
                            string ocrResult2 = OcrResultFilter(ocrResultPre2);

                            if (!string.IsNullOrEmpty(ocrResult2))
                            {
                                imageInfoDTO.OcrResult = ocrResult2.Replace("-", "");
                                break;
                            }

                            //[이미지 존을 줄여서 detail하게 체크]
                            ocrResultPre2 = OcrCheck(this.g2_left, this.g2_top, this.g2_width, this.g2_height);
                            ocrResult2 = OcrResultFilter(ocrResultPre2);

                            if (!string.IsNullOrEmpty(ocrResult2))
                            {
                                imageInfoDTO.OcrResult = ocrResult2.Replace("-", "");
                                break;
                            }

                        }
                    }
                }

                //병리번호에 관련된 정보 조회및 설정
                this.SetImagePtoNo(imageInfoDTO, imageInfoDTO.OcrResult);


                //flwpnlImage.Controls.Add(imageBox);
                //flwpnlImage.ScrollControlIntoView(imageBox);
                //flwpnlImage.Update();

                this.workingList.Add(filePath);

                //stackPanel1.Controls.Add(imageBox);
                //stackPanel1.Update();
                //stackPanel1.AutoScroll = true;

                //xtraScrollableControl1.Controls.Add(imageBox);
                //xtraScrollableControl1.Update();
                //xtraScrollableControl1.AutoScroll = true;


                workList.Add(imageInfoDTO);
                this.grvWorkList.RefreshData();
                this.grdWorkList.Update();

            }

            return addedButtonValueList;
        }

        int checkingCount = 0;

        /// <summary>
        /// name         : ImageAdd
        /// desc         : 이미지 추가및 OCR점검
        /// author       : 심우종
        /// create date  : 2020-06-08 10:18
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void ImageAddAsync(List<string> imageList, bool isDirectAdded = false)
        {
            List<ImageInfoDTO> addedButtonValueList = new List<ImageInfoDTO>();
            this.checkingCount = imageList.Count;

            for (int i = 0; i < imageList.Count; i++)
            {
                if (IsWorking == true || isDirectAdded == true)
                {
                    //PASS
                }
                else
                {
                    checkingCount = 0;
                    break;
                }

                string message = string.Format("({0} / {1}) OCR체크 중 입니다.", imageList.Count.ToString(), (i + 1).ToString());

                lblImageInfo.Text = message;
                lblImageInfo.Update();

                string filePath = imageList.ElementAt(i);


                ImageInfoDTO imageInfoDTO = new ImageInfoDTO();
                imageInfoDTO.StrRowFilePath = filePath;
                imageInfoDTO.FileName = filePath.Split('\\').LastOrDefault();
                if (isDirectAdded == true)
                {
                    imageInfoDTO.IsDirectAdded = true;
                }

                addedButtonValueList.Add(imageInfoDTO);



                if (string.IsNullOrEmpty(imageInfoDTO.OcrResult))
                {
                    imageInfoDTO.OcrResult = await Task.Run(() =>
                    {
                        return CheckOCRAsync(filePath, width: g_width, height: g_height);
                    });
                }


                //1차 재점검
                if ( string.IsNullOrEmpty( imageInfoDTO.OcrResult))
                {
                    imageInfoDTO.OcrResult = await Task.Run(() =>
                    {
                        return CheckOCRAsync(filePath, "1BppAT", g_width, g_height);
                    });
                }

                //2차 재점검
                if (string.IsNullOrEmpty(imageInfoDTO.OcrResult))
                {
                    imageInfoDTO.OcrResult = await Task.Run(() =>
                    {
                        return CheckOCRAsync(filePath, "1BppBradley", g_width, g_height);
                    });
                }

               

                //1차 재점검 width
                if (string.IsNullOrEmpty(imageInfoDTO.OcrResult))
                {
                    imageInfoDTO.OcrResult = await Task.Run(() =>
                    {
                        return CheckOCRAsync(filePath, "1BppAT", g3_width, g3_height);
                    });
                }


                //2차 재점검 width
                if (string.IsNullOrEmpty(imageInfoDTO.OcrResult))
                {
                    imageInfoDTO.OcrResult = await Task.Run(() =>
                    {
                        return CheckOCRAsync(filePath, "1BppBradley", g3_width, g3_height);
                    });
                }

                

                //imageInfoDTO.OcrResult = await CheckOCRAsync(filePath);

                //병리번호에 관련된 정보 조회및 설정
                this.SetImagePtoNo(imageInfoDTO, imageInfoDTO.OcrResult);




                workList.Add(imageInfoDTO);
                this.grvWorkList.RefreshData();
                this.grdWorkList.Update();

                this.waitingList.Remove(filePath); //대기 리스트에서 제거
                this.workingList.Add(filePath); //작업리스트로 이동
                checkingCount--;
            }

            //return addedButtonValueList;

            this.timer.Start();
        }


        string filePath = "";
        string reCheckType = "";
        string lotateIndex = "";
        string left = "";
        string top = "";
        string width = "";
        string height = "";


        private async Task<string> CheckOCRAsync(string filePath, string reCheckType = "", int width = 0, int height = 0)
        {
            this.filePath = filePath;
            this.reCheckType = reCheckType;

            using (GdPictureImaging _gdPictureImagingTemp = new GdPictureImaging())
            {
                using (GdPictureOCR _gdPictureOcrTemp = new GdPictureOCR())
                {
                    //UpdateLanguages(resourceFolder, new OCRLanguage[] { OCRLanguage.Dutch });

                    _gdPictureOcrTemp.ResourceFolder = resourceFolder;

                    Document _documentTemp = new Document(_gdPictureImagingTemp, _gdPictureOcrTemp);

                    try
                    {
                        //[이미지 로드]
                        if (string.IsNullOrEmpty(filePath)) return "";

                        //이미지 불러오기
                        _documentTemp.Close();
                        bool bSuccess = _documentTemp.Load(filePath, PdfRasterizationResolution);
                        if (bSuccess == false)
                        {
                            return "";
                        }


                        if (reCheckType == "1BppAT")
                        {
                            if (_documentTemp.IsOpen)
                            {
                                _documentTemp.DiscardOcrResult();
                                GdPictureStatus errorCode = _gdPictureImagingTemp.ConvertTo1BppAT(_documentTemp.ImageId, 50);
                                if (errorCode != GdPictureStatus.OK)
                                {
                                    DisplayError(errorCode);
                                }
                            }
                        }
                        else if (reCheckType == "1BppBradley")
                        {
                            if (_documentTemp.IsOpen)
                            {
                                _documentTemp.DiscardOcrResult();
                                GdPictureStatus errorCode = _gdPictureImagingTemp.ConvertTo1BppBradley(_documentTemp.ImageId, 38);
                                if (errorCode != GdPictureStatus.OK)
                                {
                                    DisplayError(errorCode);
                                }
                            }
                        }

                        for (int j = 0; j < 4; j++)
                        {
                            lotateIndex = j.ToString();
                            if (j != 0)
                            {
                                //[90도 회전] 
                                //왼쪽 90도 처리
                                if (_documentTemp.IsOpen)
                                {
                                    _documentTemp.DiscardOcrResult();
                                    //UpdateControlsOcrResultDiscarded();

                                    GdPictureStatus errorCode = _gdPictureImagingTemp.Rotate(_documentTemp.ImageId,
                                        RotateFlipType.Rotate270FlipNone);
                                    if (errorCode != GdPictureStatus.OK)
                                    {
                                        //DisplayError(errorCode);
                                    }

                                    //gdViewer1.Redraw();
                                }
                            }

                            //[OCR 체크]
                            //string ocrResultPre = OcrCheck(this.g_left, this.g_top, this.g_width, this.g_height, 0);
                            string ocrResultPre = "";

                            _documentTemp.DiscardOcrResult();
                            //SetOcrParametersForCheck(left, top, width, height, 0);


                            _gdPictureOcrTemp.SetImage(_documentTemp.ImageId);

                            //int index = 0; // OCRContextSingleBlock  2

                            _gdPictureOcrTemp.Context = OcrContextMap[op_ContextCheckIndex];

                            _gdPictureOcrTemp.ResetSelectedDictionaries();
                            _gdPictureOcrTemp.AddLanguage(OCRLanguage.Dutch); //Dutch

                            _gdPictureOcrTemp.CharacterSet = GetCharacterSet(this.op_CharacterSetIndex); //0

                            //_gdPictureOcr.CharacterSet = "0123456789.,-S";
                            _gdPictureOcrTemp.CharacterBlackList = "$§";
                            _ocrSpecialContext = OCRSpecialContext.None;




                            //Try to vigorously remove noise (vigorous despeckle)
                            _gdPictureOcrTemp.EnableVigorousDespeckle = op_EnableVigorousDespeckle;

                            float nNonDictWords = 15; //15
                                                      //Penalty for words no in the dict.:
                            _gdPictureOcrTemp.LanguageModelPenaltyNonDictWords = (float)nNonDictWords / 100;

                            float nNonFreqWords = 10; //10
                                                      //Penalty for no frequent words:
                            _gdPictureOcrTemp.LanguageModelPenaltyNonFreqDictWords = (float)nNonFreqWords / 100;


                            _gdPictureOcrTemp.ResourceFolder = this.resourceFolder;
                            _gdPictureOcrTemp.LoadMainDictionary = true;
                            _gdPictureOcrTemp.LoadFreqWordsDictionary = true;

                            _gdPictureOcrTemp.EnableOrientationDetection = false;
                            _gdPictureOcrTemp.EnableSkewDetection = true;
                            _gdPictureOcrTemp.EnablePreprocessing = true;

                            _gdPictureOcrTemp.OCRMode = OcrModeMap[op_ModeIndex];

                            if (width > 0 && height > 0)
                            {
                                _gdPictureOcrTemp.SetROI(this.g_left, this.g_top, width, height);
                            }
                            else
                            {
                                _gdPictureOcrTemp.SetROI(this.g_left, this.g_top, this.g_width, this.g_height);
                            }

                            
                            this.left = this.g_left.ToString();
                            this.top = this.g_top.ToString();
                            this.width = this.g_width.ToString();
                            this.height = this.g_height.ToString();



                            _documentTemp.OcrResultId = _gdPictureOcrTemp.RunOCR(_ocrSpecialContext);

                            if (_documentTemp.HasOcr)
                            {
                                ocrResultPre = _documentTemp.OCRResult;
                            }



                            LogDTO logDTO = new LogDTO();
                            logDTO.title = ocrResultPre;
                            logDTO.message = j.ToString();
                            logHelper.WriteLogLocalOnly("ocrResult", logDTO);

                            this.totalCheckCount = 0;
                            //[OCR 결과값에서 필요한 데이터를 추출한다.]
                            string ocrResult = OcrResultFilter(ocrResultPre);

                            if (!string.IsNullOrEmpty(ocrResult))
                            {
                                //imageInfoDTO.OcrResult = ocrResult.Replace("-", "");
                                return ocrResult.Replace("-", "");

                            }
                            else
                            {
                                
                            }
                        }

                        return "";
                    }
                    finally
                    {
                        _documentTemp.Close();
                        _documentTemp = null;
                    }


                }

            }




        }




        /// <summary>
        /// name         : SetImagePtoNo
        /// desc         : 이미지에 해당 병리번호를 설정한다.
        /// author       : 심우종
        /// create date  : 2020-07-23 10:32
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SetImagePtoNo(ImageInfoDTO imageInfoDTO, string ptoNo)
        {
            //초기화
            imageInfoDTO.Ptno = "";
            imageInfoDTO.Kornm = "";
            imageInfoDTO.Regno = "";
            imageInfoDTO.Tknm = "";
            imageInfoDTO.Tkdt = "";
            imageInfoDTO.PtoNo = ptoNo;


            //-------------------------------
            //병리번호 존재여부 확인
            //-------------------------------
            if (!string.IsNullOrEmpty(ptoNo))
            {
                string ptoNO = ptoNo.Replace("-", "");
                //callService.SelectSql("reqGetOcrPtoNoCheck")

                KeyValueData param = new KeyValueData();
                param.Add("Data1", ptoNO);
                CallResultData result = this.callService.SelectSql("reqGetCorePtoNoCheck", param);
                if (result.resultState == ResultState.OK)
                {
                    //데이터 조회 성공
                    DataTable dt = result.resultData;

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];
                        imageInfoDTO.Ptno = row["ptno"].ToString();
                        imageInfoDTO.Kornm = row["kornm"].ToString();
                        imageInfoDTO.Regno = row["regno"].ToString();
                        imageInfoDTO.Tknm = row["tknm"].ToString();
                        imageInfoDTO.Tkdt = row["tkdt"].ToString();
                        imageInfoDTO.PtoNo = row["ptoNo"].ToString();

                        this.regnoDataParsing(imageInfoDTO);

                        grvWorkList.RefreshData();

                    }
                }
                else
                {
                    //실패에 대한 처리
                }
            }
        }

        private void regnoDataParsing(ImageInfoDTO imageInfoDTO)
        {
            string regno = imageInfoDTO.Regno.ToString();

            if (!string.IsNullOrEmpty(regno) && regno.Length >= 8)
            {
                if (regno.Substring(7, 1) == "1" || regno.Substring(7, 1) == "2" || regno.Substring(7, 1) == "5" || regno.Substring(7, 1) == "6")
                {
                    imageInfoDTO.Patbir = "19" + regno.Substring(0, 2) + "-" + regno.Substring(2, 2) + "-" + regno.Substring(4, 2);
                }
                else if (regno.Substring(7, 1) == "3" || regno.Substring(7, 1) == "4" || regno.Substring(7, 1) == "7" || regno.Substring(7, 1) == "8")
                {
                    imageInfoDTO.Patbir = "20" + regno.Substring(0, 2) + "-" + regno.Substring(2, 2) + "-" + regno.Substring(4, 2);
                }
                else if (regno.Substring(7, 1) == "9" || regno.Substring(7, 1) == "0")
                {
                    imageInfoDTO.Patbir = "18" + regno.Substring(0, 2) + "-" + regno.Substring(2, 2) + "-" + regno.Substring(4, 2);
                }
            }

            imageInfoDTO.Patage = (DateTime.Now.Year - Convert.ToInt32(imageInfoDTO.Patbir.Substring(0, 4)) + 1).ToString();

            switch (regno.Substring(7, 1).ToString())
            {
                case "1":
                case "3":
                case "5":
                case "7":
                case "9":
                    //IIP_Main.pathology_data.PATSEX[count] = "M";
                    imageInfoDTO.Patsex = "M";
                    break;
                case "0":
                case "2":
                case "4":
                case "6":
                case "8":
                    //IIP_Main.pathology_data.PATSEX[count] = "F";
                    imageInfoDTO.Patsex = "F";
                    break;
            }
        }

        private bool ImageLoad(string pathAndName)
        {
            if (string.IsNullOrEmpty(pathAndName)) return false;

            //이미지 불러오기
            _documentForCheck.Close();
            //UpdateControlsDocumentClosed();
            //gdViewer1.ZoomMode = ViewerZoomMode.ZoomModeFitToViewer;
            Cursor.Current = Cursors.WaitCursor;
            bool bSuccess = _documentForCheck.Load(pathAndName, PdfRasterizationResolution);
            Cursor.Current = Cursors.Default;
            if (bSuccess)
            {
                return true;
            }

            return false;


        }

        bool isDisplayForChecking = false;


        /// <summary>
        /// name         : Rotate
        /// desc         : 체크용 OCR 이미지 rotate
        /// author       : 심우종
        /// create date  : 2020-08-05 09:37
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void Rotate()
        {
            if (isDisplayForChecking == true)
            {

            }
            else
            {

            }

        }




        /// <summary>
        /// name         : OcrResultFilter
        /// desc         : OCR 결과값에서 필요한 데이터를 추출한다.
        /// author       : 심우종
        /// create date  : 2020-06-08 10:24
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private string OcrResultFilter(string ocrResult)
        {
            string result = "";
            if (string.IsNullOrEmpty(ocrResult.ToString())) return result;

            string[] splData = ocrResult.Split('\n');

            if (splData != null && splData.Count() > 0)
            {
                for (int i = 0; i < splData.Count(); i++)
                {
                    string checkData = splData.ElementAt(i).ToString().Replace(" ", "");

                    AddLog(checkData);
                    //[병리번호 추출]
                    string patNO = PtoNoCheck(checkData);

                    if (!string.IsNullOrEmpty(patNO))
                    {
                        return patNO;
                    }
                }
            }

            return "";
        }


        private void AddLog(string message)
        {
            string messagetitle = "filePath : " + this.filePath + " / " + "reCheckType : " + this.reCheckType + " / " + "lotateIndex : " + lotateIndex + " / " +
                 "left : " + this.left + " / " + "top : " + this.top + " / " + "width : " + this.width + " / " + "height : " + this.height;

            //string filePath = "";
            //string reCheckType = "";
            //string lotateIndex = "";

            StreamWriter oStreamWriter = new StreamWriter(String.Format(@"{0}\Log\{1}", appPath, DateTime.Now.ToShortDateString() + ".TXT"), true);
            oStreamWriter.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), messagetitle));
            oStreamWriter.Close();

            oStreamWriter = new StreamWriter(String.Format(@"{0}\Log\{1}", appPath, DateTime.Now.ToShortDateString() + ".TXT"), true);
            oStreamWriter.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message));
            oStreamWriter.Close();
        }


        int totalCheckCount = 0;
        /// <summary>
        /// name         : PtoNoCheck
        /// desc         : 병리번호 조합이 있는지 체크한다.
        /// author       : 심우종
        /// create date  : 2020-06-08 10:27
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private string PtoNoCheck(string value)
        {
            string[] firstStrList = { "S" };
            int firstNumberIndex = -1;
            int numberContinuCount = 0;

            //int totalNumberCount = 0;

            int firstIndex = -1;
            int lastIndex = -1;

            for (int i = 0; i < value.Length; i++)
            {
                if (value[i].ToString().ToIntOrNull() != null)
                {
                    numberContinuCount++;
                    this.totalCheckCount++;
                    //숫자
                    if (firstNumberIndex == -1)
                    {
                        firstNumberIndex = i;

                    }

                    if (numberContinuCount == 7)
                    {
                        //연속으로 7번째 숫자가 발견되었다.

                        if (firstNumberIndex >= 1)
                        {
                            //최소 숫자의 앞자리 문자 확인
                            string checkStr = value[firstNumberIndex - 1].ToString();
                            bool isChecked = false;
                            foreach (string str in firstStrList)
                            {
                                if (str == checkStr)
                                {
                                    isChecked = true;
                                }
                            }

                            if (isChecked == true)
                            {
                                firstIndex = firstNumberIndex - 1;
                                lastIndex = i;


                                //7자리 숫자 이후에도 숫자가 또 나오면 의심이 필요함.. 정확성을 위해 오류로 판별하자.
                                if (value.Length > lastIndex + 1)
                                {
                                    if (value[lastIndex + 1].ToString().ToIntOrNull() != null)
                                    {
                                        //8번째도 숫자이면 오류.
                                        continue;
                                    }
                                }


                                return value.Substring(firstIndex, lastIndex - firstIndex + 1);
                            }

                        }
                    }
                }
                else
                {
                    if (value[i].ToString() == "-")
                    {
                        //"-"는 무시하자.
                        continue;
                    }

                    //숫자가 아님..
                    numberContinuCount = 0;
                    firstNumberIndex = -1;
                }

            }

            return "";
        }


        /// <summary>
        /// name         : OcrCheck
        /// desc         : 추가되는 이미지에 대한 OCR점검을 실시한다.
        /// author       : 심우종
        /// create date  : 2020-06-08 09:28
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private string OcrCheck(int left, int top, int width, int height, int ContextCheckIndex = 2)
        {

            //OCR 처리 시작
            _documentForCheck.DiscardOcrResult();
            SetOcrParametersForCheck(left, top, width, height, ContextCheckIndex);
            Cursor.Current = Cursors.WaitCursor;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            _documentForCheck.OcrResultId = _gdPictureOcrForCheck.RunOCR(_ocrSpecialContext);
            stopWatch.Stop();
            Cursor.Current = Cursors.Default;


            string result = "";
            if (_documentForCheck.HasOcr)
            {
                result = _documentForCheck.OCRResult;
            }

            return result;
        }




        /// <summary>
        /// name         : ImageBox_onImageSelected
        /// desc         : 이미지 선택시
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        //private void ImageBox_onImageSelected(ImageContainer obj, string pressedKeyCode)
        //{
        //    if (obj == null) return;

        //    List<ImageContainer> imageList = this.GetImageList();
        //    if (imageList != null && imageList.Count > 0)
        //    {
        //        imageList.ForEach(item => { item.IsLastSelected = false; });

        //        for (int i = 0; i < imageList.Count; i++)
        //        {
        //            ImageContainer image = imageList[i];
        //            if (image == obj)
        //            {
        //                image.IsSelected = true;
        //                image.IsLastSelected = true;
        //            }
        //            else
        //            {
        //                image.IsSelected = false;
        //            }
        //        }

        //        string filePath = obj.ImageButtonValue.StrRowFilePath;
        //        if (!string.IsNullOrEmpty(filePath))
        //        {
        //            this.ShowImage(filePath);
        //        }

        //    }
        //}

        private void ShowImage(string filePath)
        {
            _document.Close();
            UpdateControlsDocumentClosed();
            gdViewer1.ZoomMode = ViewerZoomMode.ZoomModeFitToViewer;
            Cursor.Current = Cursors.WaitCursor;
            bool bSuccess = _document.Load(filePath, PdfRasterizationResolution);
            Cursor.Current = Cursors.Default;
            if (bSuccess)
            {
                UpdateControlsDocumentLoaded();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Failed to load " + filePath, "Error", MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation);
            }
        }

        /// <summary>
        /// 화면에 보이는 이미지 리스트를 리턴한다.
        /// </summary>
        /// <returns></returns>
        private List<ImageContainer> GetImageList(bool isSelected = false)
        {
            List<ImageContainer> imageList = new List<ImageContainer>();
            if (flwpnlImage.Controls.Count > 0)
            {
                for (int i = 0; i < this.flwpnlImage.Controls.Count; i++)
                {
                    if (this.flwpnlImage.Controls[i] is ImageContainer)
                    {
                        if (isSelected == true)
                        {

                            ImageContainer imageCon = this.flwpnlImage.Controls[i] as ImageContainer;
                            if (imageCon.IsSelected == true)
                            {
                                imageList.Add(imageCon);
                            }
                        }
                        else
                        {
                            imageList.Add(this.flwpnlImage.Controls[i] as ImageContainer);
                        }

                    }
                }
            }

            return imageList;
        }

        private List<ImageInfoDTO> GetWorkList(bool isSelected = false)
        {
            if (grvWorkList.DataSource is List<ImageInfoDTO>)
            {
                List<ImageInfoDTO> list = grvWorkList.DataSource as List<ImageInfoDTO>;

                if (list != null)
                {
                    if (isSelected == true)
                    {
                        list = list.Where(e => e.IsChecked == true).ToList();
                        return list;
                    }
                    else
                    {
                        return list;
                    }
                }

            }
            //this.grvWorkList.DataSource
            return null;
        }


        /// <summary>
        /// name         : btnOcrReCheck_Click
        /// desc         : OCR 재점검 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-06-08 09:54
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnOcrReCheck_Click(object sender, EventArgs e)
        {
            //초기화
            txtRePtoNo.Text = "";

            if (_document.IsOpen)
            {
                if (gdViewer1.IsRect())
                {
                    _document.DiscardOcrResult();
                    UpdateControlsOcrResultDiscarded();

                    int left = 0;
                    int top = 0;
                    int width = 0;
                    int height = 0;
                    gdViewer1.GetRectCoordinatesOnDocument(ref left, ref top, ref width, ref height);


                    lblrectRe.Text = left.ToString() + ", " + top.ToString() + ", " + width.ToString() + ", " + height.ToString();

                    StartOCR(left, top, width, height);
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Please draw a region of interest into the viewer in order to specify the zone to read.");
                }
            }
        }



        /// <summary>
        /// name         : btnWorkingFolder_Click
        /// desc         : 작업 경로 재설정
        /// author       : 심우종
        /// create date  : 2020-07-21 15:52
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnWorkingFolder_Click(object sender, EventArgs e)
        {
            this.timer.Stop();

            try
            {
                FolderBrowserDialog dialog = new FolderBrowserDialog();
                dialog.ShowDialog();

                string selectedPath = dialog.SelectedPath;

                if (!string.IsNullOrEmpty(selectedPath))
                {
                    Global.G_IniWriteValue("OCR", "WORKING_PATH", selectedPath, Global.strSettingPath);

                    this.txtWorkingPath.Text = selectedPath;
                }
            }
            finally
            {
                this.timer.Start();
            }
            
        }

        Timer timer;
        List<string> workingList = new List<string>();
        List<string> waitingList = new List<string>();



        /// <summary>
        /// name         : btnWork_Click
        /// desc         : 작업시작 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-21 16:10
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        //private void btnWork_Click(object sender, EventArgs e)
        //{
        //    if (this.waitingList.Count > 0)
        //    {
        //        this.timer.Stop();
        //        //this.IsWorking = true;
        //        try
        //        {
        //            for (int i = 0; i < this.waitingList.Count; i++)
        //            {
        //                this.ImageAdd(waitingList);
        //                this.waitingList.Clear();
        //            }
        //        }
        //        finally
        //        {
        //            this.timer.Start();
        //            //this.IsWorking = false;
        //        }
        //    }
        //}


        public static BackgroundWorker bgwImageAdd = new BackgroundWorker();
        /// <summary>
        /// name         : Timer_Tick
        /// desc         : 타이머 작업 시작
        /// author       : 심우종
        /// create date  : 2020-07-21 16:10
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void Timer_Tick(object sender, EventArgs e)
        {

            FileCheck();
            if (this.IsWorking == true)
            {
                if (this.waitingList.Count > 0 && this.checkingCount == 0)
                {
                    this.timer.Stop();
                    try
                    {
                        //this.ImageAdd(waitingList);


                        //BackgroundWorker bgwImageAdd = new BackgroundWorker();
                        //bgwImageAdd.DoWork += new DoWorkEventHandler(bgwImageAdd_DoWorkAsync);
                        //bgwImageAdd.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwImageAdd_RunWorkerCompleted);
                        //bgwImageAdd.WorkerSupportsCancellation = true;
                        //bgwImageAdd.RunWorkerAsync();

                        //this.BeginInvoke(new MethodInvoker(delegate
                        //{
                        //    this.ImageAddAsync(waitingList);
                        //    this.grvWorkList.RefreshData();
                        //    this.grdWorkList.Update();
                        //    this.waitingList.Clear();
                        //}));

                        List<string> imageList = waitingList.ToList();

                        this.ImageAddAsync(imageList);
                        //this.waitingList.Clear();
                    }
                    finally
                    {
                        //this.timer.Start();
                    }
                }
            }

           
        }

        //private async void AddImageAsync()
        //{
        //    await Task.Run(()=> {
        //        this.ImageAdd(waitingList);
        //        this.waitingList.Clear();
        //    });
        //}

        //private async void bgwImageAdd_DoWorkAsync(object sender, DoWorkEventArgs e)
        //{
        //    this.ImageAddAsync(waitingList);
        //    this.grvWorkList.RefreshData();
        //    this.grdWorkList.Update();
        //    this.waitingList.Clear();
        //}

        void bgwImageAdd_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {
                //LogWriter(ex.Message);
                //throw ex;
            }
        }


        /// <summary>
        /// name         : FileCheck
        /// desc         : 추가된 파일이 있는지 채크한다.
        /// author       : 심우종
        /// create date  : 2020-07-24 09:55
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void FileCheck()
        {
            //this.timer.Stop();
            try
            {
                this.waitingList.Clear();
                if (string.IsNullOrEmpty(txtWorkingPath.Text)) return;

                string workPath = txtWorkingPath.Text;
                DirectoryInfo di = new DirectoryInfo(workPath);

                if (di.Exists == false)
                {
                    //MessageBox.Show(workPath + "\r\n작업경로를 확인할 수 없습니다.");
                    return;
                }

                FileInfo[] files = di.GetFiles();
                if (files != null && files.Count() > 0)
                {
                    foreach (FileInfo file in files)
                    {
                        if (this.workingList.Where(o => o.ToString() == file.FullName).Count() > 0)
                        {
                            continue;
                        }
                        //else if (this.waitingList.Where(o => o.ToString() == file.FullName).Count() > 0)
                        //{
                        //    continue;
                        //}
                        else
                        {
                            this.waitingList.Add(file.FullName);
                        }
                    }
                }

                if (waitingList != null && waitingList.Count > 0)
                {

                    lblImageInfo.Text = waitingList.Count().ToString() + "개 이미지 검색됨";
                }
                else
                {
                    lblImageInfo.Text = "추가할 이미지가 없습니다.";
                }
            }
            finally
            {
                //this.timer.Start();
            }
        }


        /// <summary>
        /// name         : txtRePtoNo_TextChanged
        /// desc         : 병리번호 입력시
        /// author       : 심우종
        /// create date  : 2020-07-23 10:08
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void txtRePtoNo_TextChanged(object sender, EventArgs e)
        {
            bool isExists = false;
            string ptoNo = txtRePtoNo.Text.Replace("-", "");

            if (!string.IsNullOrEmpty(ptoNo) && (ptoNo.Length == 8 || ptoNo.Length == 9))
            {
                //병리번호 검색
                KeyValueData param = new KeyValueData();
                param.Add("Data1", ptoNo);
                CallResultData result = this.callService.SelectSql("reqGetCorePtoNoCheck", param);
                if (result.resultState == ResultState.OK)
                {
                    //데이터 조회 성공
                    DataTable dt = result.resultData;

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        this.lblReName.Text = row["kornm"].ToString();
                        isExists = true;
                    }
                }
                else
                {
                    //실패에 대한 처리
                }
            }

            if (isExists == false)
            {
                this.lblReName.Text = "No Name";
            }
        }


        /// <summary>
        /// name         : btnConfirmPtono_Click
        /// desc         : 적용 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-23 10:23
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnConfirmPtono_Click(object sender, EventArgs e)
        {
            bool ptoNoCheck = true;
            if (string.IsNullOrEmpty(txtRePtoNo.Text.ToString()))
            {
                ptoNoCheck = false;
            }

            if (lblReName.Text == "No Name")
            {
                ptoNoCheck = false;
            }

            if (ptoNoCheck == false)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("병리번호가 선택되지 않았습니다.");
                return;
            }

            string ptono = txtRePtoNo.Text;

            if (this.selectedRow != null)
            {
                this.SetImagePtoNo(selectedRow, ptono);
            }

            //if (imageList != null && imageList.Count > 0)
            //{
            //    ImageContainer image = imageList.ElementAt(0);

            //    //병리번호에 관련된 정보 조회및 설정
            //    this.SetImagePtoNo(image.ImageButtonValue, ptono);
            //}


        }


        /// <summary>
        /// name         : GetSelectedRow
        /// desc         : 현재선택된 workList 리턴
        /// author       : 심우종
        /// create date  : 2020-08-05 11:07
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private ImageInfoDTO GetSelectedRow()
        {
            object row = this.grvWorkList.GetFocusedRow();
            if (row != null && row is ImageInfoDTO)
            {
                return row as ImageInfoDTO;
            }

            return null;
        }


        /// <summary>
        /// name         : btnAllSelect_Click
        /// desc         : 전체선택 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-23 15:58
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnAllSelect_Click(object sender, EventArgs e)
        {
            //List<ImageContainer> imageList = GetImageList();
            List<ImageInfoDTO> imageList = GetWorkList();

            if (imageList != null && imageList.Count > 0)
            {
                if (imageList.Where(o => o.IsChecked == true).Count() == imageList.Count())
                {
                    //전체해제
                    imageList.ForEach(item =>
                    {
                        item.IsChecked = false;
                    });
                }
                else
                {
                    //전체선택
                    imageList.ForEach(item =>
                    {
                        item.IsChecked = true;
                    });
                }
            }

            grvWorkList.RefreshData();
        }

        string workEndPath = string.Empty; //작업완료 경로
        string workDeletePath = string.Empty; //삭제완료 경로

        /// <summary>
        /// name         : btnSave_Click
        /// desc         : 이미지 저장 버튼 클릭시
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSave_Click(object sender, EventArgs e)
        {
            //List<ImageContainer> list = GetImageList();
            List<ImageInfoDTO> list = GetWorkList();

            if (list == null || list.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("선택된 이미지가 없습니다.");
                return;
            }

            List<ImageInfoDTO> selectedList = list.Where(o => o.IsChecked == true).ToList();

            if (selectedList == null || selectedList.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("선택된 이미지가 없습니다.");
                return;
            }

            for (int i = 0; i < selectedList.Count; i++)
            {
                ImageInfoDTO image = selectedList.ElementAt(i);

                if (string.IsNullOrEmpty(image.PtoNo) || string.IsNullOrEmpty(image.Kornm))
                {
                    string imageName = image.StrRowFilePath.Split('\\').LastOrDefault();
                    DevExpress.XtraEditors.XtraMessageBox.Show("병리번호를 확인할 수 없습니다.", imageName);
                    return;
                }
            }

            string workPath = Global.strWorkingPath;
            if (string.IsNullOrEmpty(workPath))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("작업경로를 확인할 수 없습니다.");
                return;
            }

            DirectoryInfo di = new DirectoryInfo(workPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            this.workEndPath = workPath + "\\작업완료";
            DirectoryInfo di2 = new DirectoryInfo(workEndPath);
            if (di2.Exists == false)
            {
                di2.Create();
            }


            //viewer 클리어
            _document.Close();
            UpdateControlsDocumentClosed();

            timer.Stop();
            //저장시작!!
            this.Save(selectedList);
            timer.Start();
        }


        bool isSaveing = false;

        /// <summary>
        /// name         : Save
        /// desc         : 이미지 저장
        /// author       : 심우종
        /// create date  : 2020-07-24 10:02
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void Save(List<ImageInfoDTO> list)
        {
            string workPath = Global.strWorkingPath;
            int progressBarMax = list.Count;
            int progressValue = 0;
            this.progressBarControl1.Properties.Maximum = progressBarMax;
            this.progressBarControl1.EditValue = progressValue;
            int imageIndex = list.Count;

            //string strmessage =  IIP_Main_selectlistView.Items.Count.ToString() + " 명의 환자에 // " + (Main_Image_panel.Controls.IndexOf(imgbox) + 1).ToString() + " 의 사진을 보내겠습니다.";
            string strmessage = list.Count.ToString() + "개의 사진을 저장합니다.\r\n계속하시겠습니까?";

            if (DevExpress.XtraEditors.XtraMessageBox.Show(strmessage, "전송", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    this.isSaveing = true;

                    for (int j = imageIndex - 1; j >= 0; j--)
                    {
                        //System.Windows.Forms.Button btn = (System.Windows.Forms.Button)this.imagePanel.Controls[j];
                        ImageInfoDTO imageInfo = list[j];


                        FileInfo file = new FileInfo(imageInfo.StrRowFilePath);
                        if (file.Exists)
                        {
                            StudyDataTable saveDt = new StudyDataTable();
                            //DataRow row = selectedOrderDt.Rows[i];
                            DataRow newRow = saveDt.NewRow();


                            string ptoNo = imageInfo.PtoNo;


                            newRow["ptNo"] = imageInfo.Ptno;
                            newRow["studyDt"] = imageInfo.Tkdt;
                            newRow["insertDt"] = DateTime.Now.ToString("yyyyMMdd");
                            newRow["ptoNo"] = ptoNo; //병리번호
                            newRow["sendStat"] = "0";

                            string uId = blob.SearchNumber(ptoNo);
                            newRow["uId"] = uId;

                            newRow["gi"] = "0";
                            newRow["mi"] = "0";
                            newRow["oi"] = "0";
                            string typeValue = this.cmbImageType.Properties.Items[this.cmbImageType.SelectedIndex].Value.ToString();

                            //string typeValue = "6";
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

                            //newRow["imageType"] = typeValue;
                            //string rootPath = Global.strDGSimagepath;

                            string newFileName = ptoNo + "_" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".jpg";

                            string filePath = Global.strImagePath + DateTime.Now.ToString("yyyy") + "\\" + ptoNo + "\\" + newFileName;
                            newRow["rootPath"] = "Z:\\";
                            newRow["filePath"] = filePath;

                            newRow["ptNm"] = imageInfo.Kornm;
                            newRow["birth"] = imageInfo.Patbir;
                            newRow["age"] = imageInfo.Patage;
                            newRow["sex"] = imageInfo.Patsex;

                            newRow["studyNm"] = imageInfo.Tknm;
                            newRow["userId"] = SessionInfo.userId;

                            saveDt.Rows.Add(newRow);


                            KeyValueData param = new KeyValueData();
                            param.Add("Data1", saveDt.DataTableToStringForServer());
                            CallResultData result = this.callService.SelectSql("reqInsIipData", param);
                            if (result.resultState == ResultState.OK)
                            {
                                Global.logHelper.WriteLog("ImageOCRSave", LogType.INFO, ActionType.CALL_DB, "이미지 저장", "DB 저장 성공", ptNo: imageInfo.Ptno, ptoNo: ptoNo , paramInfo: "filePath : " + filePath);
                                //파일 복사
                                //Directory.CreateDirectory(rootPath + filePath.ToString().Substring(0, filePath.LastIndexOf("\\")));
                                string strNewPath = filePath;

                                if (ft.FileUpload(imageInfo.StrRowFilePath, strNewPath) == true)
                                {
                                    Global.logHelper.WriteLog("ImageOCRSave", LogType.INFO, ActionType.ACTION, "이미지 저장", "파일서버 업로드 성공", ptNo: imageInfo.Ptno, ptoNo: ptoNo, paramInfo: "filePath : " + filePath);
                                    //LogDTO logDTO = new LogDTO();
                                    //logDTO.ptoNo = imageInfo.PtoNo;
                                    //logDTO.ptno = imageInfo.Ptno;
                                    //logDTO.title = strNewPath;
                                    //logHelper.WriteLog("OcrSave", logDTO);


                                    //KIS에 전송필요?????
                                    //파일전송 성공  
                                    //this.blob.InsertLPRPRSTHM(ptoNo, uId);
                                    //this.blob.UpdateBlob(ptoNo, btn.Tag.ToString());

                                    //저장성공후 처리
                                    DirectoryInfo di = new DirectoryInfo(this.workEndPath);
                                    if (di.Exists == false)
                                    {
                                        di.Create();
                                    }

                                    string tempWorkEndPath = this.workEndPath + "\\" + DateTime.Now.ToString("yyyyMMdd");
                                    di = new DirectoryInfo(tempWorkEndPath);
                                    if (di.Exists == false)
                                    {
                                        di.Create();
                                    }


                                    string targetFilePathAndName = tempWorkEndPath + "\\" + newFileName;
                                    //기존파일을 작업완료 폴더로 복사
                                    File.Copy(imageInfo.StrRowFilePath, targetFilePathAndName);
                                    //기존파일 삭제
                                    if (imageInfo.IsDirectAdded == false)
                                    {
                                        file.Delete();
                                    }
                                }
                                else
                                {
                                    Global.logHelper.WriteLog("ImageOCRSave", LogType.INFO, ActionType.ACTION, "이미지 저장", "파일서버 업로드 실패", ptNo: imageInfo.Ptno, ptoNo: ptoNo, paramInfo: "filePath : " + filePath);
                                }

                                progressValue++;
                                this.progressBarControl1.EditValue = progressValue;
                                this.Update();
                                System.Threading.Thread.Sleep(1000);
                            }
                            else
                            {
                                Global.logHelper.WriteLog("ImageOCRSave", LogType.ERROR, ActionType.CALL_DB, "이미지 저장", "DB 저장 실패", ptNo: imageInfo.Ptno, ptoNo: ptoNo, paramInfo: "filePath : " + filePath);
                                DevExpress.XtraEditors.XtraMessageBox.Show("DB 업데이트 실패");
                                return;
                            }
                        }
                        else
                        {
                            //파일이 없음
                            DevExpress.XtraEditors.XtraMessageBox.Show("파일이 없습니다.");
                            return;
                        }

                        this.workingList.Remove(imageInfo.StrRowFilePath);

                        this.workList.Where(e => e == imageInfo).ToList().ForEach(item =>
                        {
                            workList.Remove(item);
                        });

                        this.grvWorkList.RefreshData();
                        this.Update();
                    }

                }
                finally
                {
                    isSaveing = false;
                }

            }
        }


        /// <summary>
        /// name         : cmbImageType_SelectedIndexChanged
        /// desc         : 타입값 변경시
        /// author       : 심우종
        /// create date  : 2020-07-23 16:54
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void cmbImageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedValue = this.cmbImageType.SedasSelectedValue;
            if (!string.IsNullOrEmpty(selectedValue))
            {
                Global.G_IniWriteValue("OCR", "TYPE_VALUE", selectedValue, Global.strSettingPath);
            }
        }


        /// <summary>
        /// name         : btnDelete_Click
        /// desc         : 삭제버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-24 13:38
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            //List<ImageContainer> list = GetImageList();
            List<ImageInfoDTO> selectedList = GetWorkList(isSelected: true);

            //if (list == null || list.Count == 0)
            //{
            //    DevExpress.XtraEditors.XtraMessageBox.Show("선택된 이미지가 없습니다.");
            //    return;
            //}

            //List<ImageContainer> selectedList = list.Where(o => o.ImageButtonValue.IsChecked == true).ToList();

            if (selectedList == null || selectedList.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("선택된 이미지가 없습니다.");
                return;
            }


            string workPath = Global.strWorkingPath;
            if (string.IsNullOrEmpty(workPath))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("작업경로를 확인할 수 없습니다.");
                return;
            }

            DirectoryInfo di = new DirectoryInfo(workPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            this.workDeletePath = workPath + "\\삭제완료";
            DirectoryInfo di2 = new DirectoryInfo(workDeletePath);
            if (di2.Exists == false)
            {
                di2.Create();
            }


            //삭제시작!!
            this.Delete(selectedList);

            //viewer 클리어
            _document.Close();
            UpdateControlsDocumentClosed();
        }


        /// <summary>
        /// name         : Delete
        /// desc         : 선택한 이미지 삭제
        /// author       : 심우종
        /// create date  : 2020-07-24 13:41
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void Delete(List<ImageInfoDTO> list)
        {
            string workPath = Global.strWorkingPath;

            string strmessage = list.Count.ToString() + "개의 사진을 삭제합니다.\r\n계속하시겠습니까?";

            if (DevExpress.XtraEditors.XtraMessageBox.Show(strmessage, "삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                for (int j = list.Count - 1; j >= 0; j--)
                {
                    ImageInfoDTO imageInfo = list[j];


                    FileInfo file = new FileInfo(imageInfo.StrRowFilePath);
                    if (file.Exists)
                    {
                        DirectoryInfo di = new DirectoryInfo(this.workDeletePath);
                        if (di.Exists == false)
                        {
                            di.Create();
                        }

                        string tempWorkDeletePath = this.workDeletePath + "\\" + DateTime.Now.ToString("yyyyMMdd");
                        di = new DirectoryInfo(tempWorkDeletePath);
                        if (di.Exists == false)
                        {
                            di.Create();
                        }

                        string fileName = imageInfo.StrRowFilePath.Split('\\').LastOrDefault();

                        //파일명 중복 체크
                        string newFileName = core.DupFileRenameCheck(tempWorkDeletePath, fileName, isNeedToDupCheck: true);
                        string targetFilePathAndName = tempWorkDeletePath + "\\" + newFileName;


                        //기존파일을 작업완료 폴더로 복사
                        File.Copy(imageInfo.StrRowFilePath, targetFilePathAndName);
                        //기존파일 삭제
                        if (imageInfo.IsDirectAdded == false)
                        {
                            file.Delete();
                        }
                    }
                    else
                    {
                        //파일이 없음
                        DevExpress.XtraEditors.XtraMessageBox.Show("파일이 없습니다.");
                        return;
                    }

                    this.workingList.Remove(imageInfo.StrRowFilePath);
                    this.workList.Where(e => e == imageInfo).ToList().ForEach(item =>
                    {
                        workList.Remove(item);
                    });

                    this.grvWorkList.RefreshData();
                    this.Update();
                }
            }
        }





        /// <summary>
        /// name         : grvWorkList_RowCellClick
        /// desc         : 워크리스트 선택변경시
        /// author       : 심우종
        /// create date  : 2020-08-05 10:39
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void grvWorkList_RowCellClick(object sender, DevExpress.XtraGrid.Views.Grid.RowCellClickEventArgs e)
        {

        }

        ImageInfoDTO selectedRow; //현재 선택된 Row

        private void grvWorkList_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            WorkListSelectChanged();
        }

        private void grvWorkList_RowClick(object sender, DevExpress.XtraGrid.Views.Grid.RowClickEventArgs e)
        {
            WorkListSelectChanged();
        }


        /// <summary>
        /// name         : WorkListSelectChanged
        /// desc         : 워크리스트 선택 변경시
        /// author       : 심우종
        /// create date  : 2020-08-05 10:55
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void WorkListSelectChanged()
        {
            if (isSaveing == true) return;

            object row = grvWorkList.GetFocusedRow();
            if (row is ImageInfoDTO)
            {
                ImageInfoDTO imageInfo = row as ImageInfoDTO;
                if (imageInfo != null && this.selectedRow != imageInfo)
                {
                    this.selectedRow = imageInfo;
                    string filePath = imageInfo.StrRowFilePath;
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        this.ShowImage(filePath);
                    }
                }
            }
        }


        /// <summary>
        /// name         : btnStart_Click
        /// desc         : 시작버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-05 13:59
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (this.IsWorking == true)
            {
                this.IsWorking = false;
                this.btnStart.Text = "시작";
            }
            else
            {
                this.IsWorking = true;
                this.btnStart.Text = "중지";
            }
        }


        /// <summary>
        /// name         : chkAuto_CheckedChanged
        /// desc         : 이미지 자동추가 체크박스 체크변경시
        /// author       : 심우종
        /// create date  : 2020-08-05 14:37
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void chkAuto_CheckedChanged(object sender, EventArgs e)
        {
            //this.AutoImageCheck();
        }

        private void grvWorkList_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            object row = grvWorkList.GetRow(e.RowHandle);
            if (row != null && row is ImageInfoDTO)
            {
                ImageInfoDTO imageInfo = row as ImageInfoDTO;
                if (imageInfo != null)
                {
                    if (string.IsNullOrEmpty(imageInfo.PtoNo) || string.IsNullOrEmpty(imageInfo.Kornm))
                    {
                        e.Appearance.ForeColor = Color.DarkOrange;
                    }
                }
            }
        }

        /// <summary>
        /// name         : AutoImageCheck
        /// desc         : 이미지 자동추가 변경시
        /// author       : 심우종
        /// create date  : 2020-08-05 14:38
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        //private void AutoImageCheck()
        //{
        //    this.IsWorking = chkAuto.Checked;
        //    if (chkAuto.Checked == true)
        //    {
        //        Global.G_IniWriteValue("OCR", "AUTO_CHECK", "Y", Global.strSettingPath);
        //    }
        //    else
        //    {
        //        Global.G_IniWriteValue("OCR", "AUTO_CHECK", "N", Global.strSettingPath);
        //    }

        //}
    }
}