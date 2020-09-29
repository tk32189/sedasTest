using MaterialSkin;
using MaterialSkin.Controls;
using Newtonsoft.Json;
using OpenCvSharp;
using Sedas.Core;
using Sedas.DB;
using SedasPhotoMagic.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using System.Xml;
using Point = System.Drawing.Point;
using Size = System.Drawing.Size;
using System.Reflection;


namespace SedasPhotoMagic
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        #region 변수선언

        public WorkSpace ws;
        private float[] TEXT_BOX_MARGIN = new float[] { 5, 5, 120, 60 }; // 삽입시 텍스트 마진

        public float ScalePerDelta = 0.1f / 240; // 스크롤 확대시 기본 단위

        private readonly MaterialSkinManager materialSkinManager;
        private bool _drag;//드래그 시작
        private PointF _dragStart;//드래그 시작점
        private Color _penColor = Color.FromArgb(0, 188, 212); //개체 테두리 기본 색

        private Gizmo _selGizmo;//선택된 기즈모
        private Cell _selCell;//선택된 셀
        public GridObject _selGrid = null; //선택한 격자

        private int _selPolyIndex;// 삼각형이나 다각형의 경우 몇번째 점에 해당하는지 기록
        private bool isMarking;//마킹 여부 (쓰기 / 지우기)
        private PictureBox pm;//메인 픽쳐박스

        private List<UndoTask> listUndos = new List<UndoTask>(); // 되돌리기 목록
        private int nowUndoIdx = -1;//되돌리기 현재 값
        private bool isLoading = false; //로드중 여부

        //private string receviedFilePath = "";
        private string receivedPtoNo = "";
        private string strImagePath = "";
        private string strPtNo = "";
        private string strPtNm = "";
        private string selectedImageNum = "";


        private DataTable receivedImageDt;
        private DataRow selectedImage;
        //private bool isImageUpdate = false; //기존 저장된 이미지 수정여부


        //private string imageType = ""; //삭제해야함.


        FileTransfer ft = new FileTransfer();

        #endregion 변수선언


        #region 폼 로드

        public MainForm()
        {
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;
        }


        public MainForm(string[] args)
        {
            //Assembly asm = typeof(DevExpress.UserSkins.Seda20200611).Assembly;
            //DevExpress.Skins.SkinManager.Default.RegisterAssembly(asm);
            //DevExpress.Skins.SkinManager.Default.GetValidSkinName("My Basic")
            InitializeComponent();
            materialSkinManager = MaterialSkinManager.Instance;
            //materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.DARK;


            

            if (args != null && args.Length > 0)
            {
                
                if (args.Length >= 6)
                {
                    string imageValue = args.ElementAt(0).ToString();

                    //MessageBox.Show(imageValue);

                    DataTable imageDt = JsonConvert.DeserializeObject<DataTable>(imageValue);
                    if (imageDt != null && imageDt.Rows.Count > 0)
                    {
                        receivedImageDt = imageDt;

                        if (receivedImageDt != null)
                        {
                            receivedImageDt.Columns.Add("cmChanged", typeof(string));
                        }
                    }

                    //MessageBox.Show(imageDt.Rows.Count.ToString());

                    this.strImagePath = args.ElementAt(1).ToString();
                    this.receivedPtoNo = args.ElementAt(2).ToString();
                    this.strPtNo = args.ElementAt(3).ToString();

                    
                    this.strPtNm = args.ElementAt(4).ToString();
                    //MessageBox.Show(strPtNm);
                    this.selectedImageNum = args.ElementAt(5).ToString();
                    //MessageBox.Show(selectedImageNum);

                    if (args.Length >= 7)
                    {
                        SessionInfo.userId = args.ElementAt(6).ToString(); //사용자ID
                    }
                    
                    //MessageBox.Show(args.ElementAt(6).ToString());

                    //MessageBox.Show(strImagePath + " /  " + receivedPtoNo +  "  / " + strPtNo + " / " + strPtNm + " / " + selectedImageNum + " / " + SessionInfo.userId);
                }


                //if (args.Length >= 4)
                //{
                //    this.receviedFilePath = args.ElementAt(0).ToString();
                //    this.strImagePath = args.ElementAt(1).ToString();
                //    this.receivedPtoNo = args.ElementAt(2).ToString();
                //    this.imageType = args.ElementAt(3).ToString();
                //}
                ////MessageBox.Show(this.receviedFilePath + " " + this.strImagePath + " " + receivedPtoNo + " " + imageType);

                //string ptNo = "";
                //string ptNm = "";
                //string imageNum = "";

                ////MessageBox.Show(args.ElementAt(2).ToString());

                //if (args.Length >= 7)
                //{
                //    ptNo = args.ElementAt(4).ToString();
                //    ptNm = args.ElementAt(5).ToString();
                //    imageNum = args.ElementAt(6).ToString();
                //}

                //string fileInfo = string.Format("병리번호 {0}\r\n등록번호  {1}\r\n환자명 {2}\r\n이미지번호 {3}", this.receivedPtoNo, ptNo, ptNm, imageNum);
                //this.lblFileInfo.Text = fileInfo;

                //if (!string.IsNullOrEmpty(receivedPtoNo) && !string.IsNullOrEmpty(receviedFilePath) && !string.IsNullOrEmpty(strImagePath) && !string.IsNullOrEmpty(imageType))
                //{
                //    this.isImageUpdate = true;
                //}

            }
        }

        CallService callService;



        private void MainForm_Load(object sender, EventArgs e)
        {
            try
            {
                if (Global.strIsDev == "Y")
                {
                    this.Text = Text + "   (개발)";
                }



                this.isLoading = true;
                this.Icon = Properties.Resources.Camera;
                this.PanelView.MouseWheel += new MouseEventHandler(eMouseWheel);
                //this.lblVersion.Text = "Sedas Photo Magic V" + System.Reflection.Assembly.GetEntryAssembly().GetName().Version.ToString();
                ws = new WorkSpace(this, this.PictureBoxMain);
                ws.pixelPerCm = 80;
                lblPixelPerCm.Text = ws.pixelPerCm.ToString("F1") + " px/cm";
                pm = this.PictureBoxMain;

                LoadConfig();

                this.chkShowGrid.Checked = false;
                rdoPaperSource.Checked = true;
                ws.isGridShow = this.chkShowGrid.Checked;

                //ReSIZE 
                this.Size = new Size(Screen.PrimaryScreen.Bounds.Size.Width - 40, Screen.PrimaryScreen.Bounds.Size.Height - 80);
                this.Location = new Point(0, 0);

                //디렉토리 준비6
                if (Directory.Exists(ws.WORK_DIREC)) Directory.Delete(ws.WORK_DIREC, true);
                while (Directory.Exists(ws.WORK_DIREC)) Thread.Sleep(100);
                Directory.CreateDirectory(ws.WORK_DIREC);
                /*
                          LoadImage(@"D:\IIS\NewBiz\C# 기반 이미지 편집 UI 프로그램 개발\받은파일\육안 이미지\20121204104404.jpg", true); // 320
                          LoadImage(@"D:\IIS\NewBiz\C# 기반 이미지 편집 UI 프로그램 개발\받은파일\육안 이미지\01.jpg", true); //80
                          RemoveBG(true);
                          tabMain.SelectedIndex = 1;
                          createEdge();
                          */


            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
            finally
            {
                this.isLoading = false;
            }

            //Viewer에서 넘어온 이미지가 있는 경우
            if (receivedImageDt != null && receivedImageDt.Rows.Count > 0)
            {
                for (int i = 0; i < receivedImageDt.Rows.Count; i++)
                {

                    DataRow row = receivedImageDt.Rows[i];


                    if (!string.IsNullOrEmpty(row["fileName"].ToString()))
                    {
                        LoadImage(row["fileName"].ToString(), true);
                    }
                }

                if (!string.IsNullOrEmpty(this.selectedImageNum)) //선택한 이미지가 존재하는 경우
                {
                    DataRow selectedImage = receivedImageDt.AsEnumerable().Where(o => o["imageNum"].ToString() == this.selectedImageNum).FirstOrDefault();
                    if (selectedImage != null)
                    {
                        if (!string.IsNullOrEmpty(selectedImage["fileName"].ToString()))
                        {
                            LoadImage(selectedImage["fileName"].ToString(), false);
                        }
                    }
                }
            }

            



        }
        #endregion 폼 로드

        #region Undo/Redo
        //되돌리기 추가 - 이미지 변경하는 경우만 현재의 비트맵을 임시파일로 저장
        //string nowTask : 현재 작업 이름, bool isChangeImage : 이미지를 변경하는 작업인지 여부 (기본값 false)
        private void AddUndoList(string nowTask, bool isChangeImage = false)
        {
            try
            {
                if (nowUndoIdx > -1 && nowUndoIdx != listUndos.Count - 1)
                {
                    for (int i = listUndos.Count - 1; i > nowUndoIdx; i--)
                    {
                        listUndos.RemoveAt(i);
                    }
                }
                listUndos.Add(new UndoTask(nowTask, ws, isChangeImage));
                Debug.WriteLine(" =================");
                for (int i = 0; i < listUndos.Count; i++)
                {
                    Debug.WriteLine(i + " | " + listUndos[i].TaskName + "," + listUndos[i].objImageFilename);
                }
                Debug.WriteLine(" =================");
                Debug.WriteLine("");
                Debug.WriteLine("");

                nowUndoIdx = listUndos.Count - 1;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //되돌리기 실행 - 이미지 파일이 설정된 경우 이미지를 불러옴
        //bool isUndo 되돌리기인지 다시 실행인지 구분 
        private void ExecuteUndo(bool isUndo)
        {
            try
            {
                int oldUndoIdx = nowUndoIdx;
                if (isUndo)
                {
                    if (nowUndoIdx > 0) nowUndoIdx--;
                    else
                    {
                        Util.ShowConfirm("되돌리기할 내용이 없습니다.");
                        return;
                    }
                }
                else
                {
                    if (nowUndoIdx < listUndos.Count - 1) nowUndoIdx++;
                    else
                    {
                        Util.ShowConfirm("다시 실행할 내용이 없습니다.");
                        return;
                    }
                }
                var ut = listUndos[nowUndoIdx];
                bool imageChanged = (listUndos[oldUndoIdx].objImageFilename != "");
                if (ut.objImageFilename != "")
                {
                    ws.objBitmap.Dispose();
                    ws.objBitmap = (Bitmap)Bitmap.FromFile(ut.objImageFilename);
                }
                else if (imageChanged)
                {
                    for (int i = nowUndoIdx; i >= 0; i--)
                    {
                        if (listUndos[i].objImageFilename != "")
                        {
                            ws.objBitmap.Dispose();
                            ws.objBitmap = (Bitmap)Bitmap.FromFile(listUndos[i].objImageFilename);
                            break;
                        }
                    }
                }
                bool isPageChanged = (ws.paperSize != ut.paperSize);
                ws.pixelPerCm = ut.pixelPerCm;
                ws.paperSize = ut.paperSize;
                ws.objRect = ut.objRect;
                lblPixelPerCm.Text = ws.pixelPerCm.ToString("F1") + " px/cm";
                ws.listObjects = (List<DrawingObject>)Util.DeepClone(ut.listObject);
                ws.listGrids = (List<GridObject>)Util.DeepClone(ut.listGrids);
                if (isPageChanged)
                {
                    var _paperName = getPaperName(ws.paperSize.Width);
                    if (this.Controls.Find("rdoPaper" + _paperName, true).Count() > 0)
                    {
                        ((MaterialRadioButton)this.Controls.Find("rdoPaper" + _paperName, true)[0]).Checked = true;
                        _ChangePaper(true);
                    }
                }
                if (isUndo) ShowStatus("되돌리기(" + ut.TaskName + ")를 실행하였습니다.");
                else ShowStatus("다시하기(" + ut.TaskName + ")를 실행하였습니다.");
                CancelTask();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        #endregion

        #region Image
        //이미지를 불러옴, 네비에 추가할 경우는 TRUE
        public void Print()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                float _scale = (float)pm.Width / pm.Image.Width;
                if (ws.bitmap == null) return;
                string filename = ws.WORK_DIREC + Util.GetNameFromTimebase() + ".JPG";
                int w, h;
                if (pm.Image.Width > 4000)
                {
                    w = 4000;
                    h = (int)(1.0 * pm.Image.Height * w / pm.Image.Width);
                }
                else
                {
                    w = pm.Image.Width;
                    h = pm.Image.Height;
                }

                Bitmap bmp = new Bitmap(w, h);
                bmp.SetResolution(ws.objBitmap.HorizontalResolution, ws.objBitmap.VerticalResolution);
                pm.ClientSize = new Size(w, h);
                pm.Invalidate();
                pm.DrawToBitmap(bmp, new Rectangle(0, 0, w, h));


                //이미지 상단에 병리번호 출력기능 추가
                if (!string.IsNullOrEmpty(this.receivedPtoNo))
                {
                    int width = (int)(w * 0.2);
                    int height = (int)(width * 0.2);
                    int gap = (int)(width * 0.05);
                    Label label = new Label();

                    label.Size = new Size(width, height);

                    label.Font = new Font("맑은 고딕", 10, FontStyle.Bold);
                    label.BackColor = Color.White;
                    string ptoNo = this.receivedPtoNo;
                    if (this.receivedPtoNo.Length >= 8)
                    {
                        ptoNo = this.receivedPtoNo.Substring(0, 3) + "-" + this.receivedPtoNo.Substring(3, this.receivedPtoNo.Length - 3);
                    }
                    label.Text = ptoNo;

                    Size test = System.Windows.Forms.TextRenderer.MeasureText(label.Text, new Font(label.Font.FontFamily, label.Font.Size, label.Font.Style));

                    while (label.Width - 30 > System.Windows.Forms.TextRenderer.MeasureText(label.Text,
                            new Font(label.Font.FontFamily, label.Font.Size, label.Font.Style)).Width)
                    {
                        label.Font = new Font(label.Font.FontFamily, label.Font.Size + 0.5f, label.Font.Style);
                    }

                    label.TextAlign = ContentAlignment.TopCenter;

                    label.DrawToBitmap(bmp, new Rectangle(gap, gap, width, height));
                }



                EncoderParameters encoderParameters = new EncoderParameters(1);
                EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                ImageCodecInfo codecInfo = ImageCodecInfo.GetImageDecoders().First(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
                encoderParameters.Param[0] = encoderParameter;
                bmp.Save(filename, codecInfo, encoderParameters);
                encoderParameters.Dispose();
                encoderParameter.Dispose();
                bmp.Dispose();

                pm.ClientSize = new Size((int)(pm.Image.Width * _scale), (int)(pm.Image.Height * _scale));
                pm.Invalidate();

                //return;

                using (var pd = new PrintDocument())
                {
                    var ps = pd.DefaultPageSettings;
                    pd.DefaultPageSettings.Landscape = true;
                    ps.Margins = new Margins(0, 0, 0, 0);
                    //ps.PaperSize = new PaperSize("A4 210 x 297 mm", (int)(297 * ws.pixelPerCm / 10), (int)(210 * ws.pixelPerCm/10));
                    pd.PrintPage += (sender, args) =>
                    {
                        Rectangle m = args.MarginBounds;
                        var i = Image.FromFile(filename);
                        if ((double)i.Width / (double)i.Height > (double)m.Width / (double)m.Height) // image is wider
                        {
                            m.Height = (int)((double)i.Height / (double)i.Width * (double)m.Width);
                        }
                        else
                        {
                            m.Width = (int)((double)i.Width / (double)i.Height * (double)m.Height);
                        }
                        args.Graphics.DrawImage(i, m);
                    };
                    pd.Print();
                }
                Util.ShowConfirm("인쇄하였습니다.");
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }


        DataRow selectedImageRow = null;

        //이미지를 불러옴, 네비에 추가할 경우는 TRUE
        //string filename : 이미지명, bool isInsertNavi : 네비에 포함시킬지 여부
        public void LoadImage(string filename, bool isInsertNavi)
        {


            try
            {
                this.lblFileInfo.Text = ""; //라벨정보 초기화
                this.selectedImage = null; //선택된 이미지 정보 초기화


                //int changeCm = 0;
                if (this.receivedImageDt != null && this.receivedImageDt.Rows.Count > 0)
                {
                    selectedImageRow = this.receivedImageDt.AsEnumerable().Where(e => e["fileName"].ToString() == filename).FirstOrDefault();
                    if (selectedImageRow != null)
                    {
                        if (this.selectedImageRow.Table.Columns.Contains("cmChanged"))
                        {
                            selectedImageRow["cmChanged"] = "N";
                        }
                        

                        this.selectedImage = selectedImageRow;
                        string lblInfo = string.Format("병리번호 {0}\r\n등록번호  {1}\r\n환자명 {2}\r\n이미지번호 {3}", this.receivedPtoNo, this.strPtNo, this.strPtNm, selectedImageRow["imageNum"].ToString());
                        this.lblFileInfo.Text = lblInfo;

                        //if (isInsertNavi == false)
                        //{
                            
                        //    if (!string.IsNullOrEmpty(selectedImage["strCm"].ToString()) && selectedImage["strCm"].ToString().ToIntOrNull() != null)
                        //    {
                        //        changeCm = selectedImage["strCm"].ToString().ToInt();
                        //    }
                        //}
                        
                    }
                }


                if (ws.listObjects.Count > 0 || ws.listGrids.Count > 0)
                {
                    if (!Util.CheckConfirm("현재 파일을 로드하면 기존의 오브젝트 및 격자는 모두 사라집니다. 계속하시겠습니까?")) return;
                }
                listUndos.Clear();
                nowUndoIdx = -1;
                FileInfo fileInfo = new FileInfo(filename);
                ws.imageFilename = fileInfo.Name;
                ws.imageFileFullname = fileInfo.FullName;

                if (ws.objBitmap != null) ws.objBitmap.Dispose();
                ws.objBitmap = (Bitmap)Bitmap.FromFile(filename);
                ws.objRect = new RectangleF(0, 0, ws.objBitmap.Width, ws.objBitmap.Height);
                //Temp 디렉토리를 로드하는 경우는 원본을 변경하는 경우가 아님
                if (filename.IndexOf(ws.WORK_DIREC) == -1) ws.objSrcRect = new RectangleF(0, 0, ws.objBitmap.Width, ws.objBitmap.Height);

                ws.paperSize = getPaperSize();
                if (ws.bitmap != null) ws.bitmap.Dispose();
                ws.bitmap = Util.GetBlankImage((int)ws.paperSize.Width, (int)ws.paperSize.Height, ws.objBitmap.HorizontalResolution, ws.objBitmap.VerticalResolution);
                if (pm.Image != null) pm.Image.Dispose();
                pm.Image = ws.bitmap;

                ws.listGrids.Clear();

                if (isInsertNavi)
                {
                    PictureBoxForNavigate pictureBoxForNavigate = new PictureBoxForNavigate(ws.imageFilename, ws.imageFileFullname, ws);
                    FlowLayoutPanelImages.Controls.Add(pictureBoxForNavigate);
                    ws.listNavi.Add(pictureBoxForNavigate);
                }
                ws.listDragPoint.Clear();
                ws.listObjects.Clear();

                this.chkShowGrid.Checked = false;
                rdoPaperSource.Checked = true;
                ws.isGridShow = this.chkShowGrid.Checked;

                CancelTask();
                ws.SetNowNavi(ws.imageFileFullname);
                SetAlignCenter();
                ZoomImage();
                AddUndoList("원본", true);

                
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //px/cm 변경 창에서 메인창으로 변경값 전달
        public void UpdatePixelPerCm(RulerForm frm)
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                if (ws.pixelPerCm > 120)
                {
                    Bitmap src = (Bitmap)Bitmap.FromFile(ws.imageFileFullname);
                    Size _size = new Size((int)(src.Width * 100.0 / ws.pixelPerCm), (int)(src.Height * 100.0 / ws.pixelPerCm));
                    Bitmap bmp = new Bitmap(src, _size);
                    string filename = ws.WORK_DIREC + Util.GetNameFromTimebase() + ".JPG";
                    bmp.SetResolution(ws.objBitmap.HorizontalResolution, ws.objBitmap.VerticalResolution);
                    EncoderParameters encoderParameters = new EncoderParameters(1);
                    EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                    ImageCodecInfo codecInfo = ImageCodecInfo.GetImageDecoders().First(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
                    encoderParameters.Param[0] = encoderParameter;
                    bmp.Save(filename, codecInfo, encoderParameters);
                    encoderParameters.Dispose();
                    encoderParameter.Dispose();
                    bmp.Dispose();
                    src.Dispose();
                    ws.pixelPerCm = 100;

                    FileInfo fileInfo = new FileInfo(filename);
                    ws.imageFilename = fileInfo.Name;
                    ws.imageFileFullname = fileInfo.FullName;

                    Bitmap resize = new Bitmap(_size.Width, _size.Height, ws.objBitmap.PixelFormat);
                    resize.SetResolution(ws.objBitmap.HorizontalResolution, ws.objBitmap.VerticalResolution);
                    using (Graphics g = Graphics.FromImage(resize))
                    {
                        g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, _size.Width, _size.Height));
                        g.DrawImage(ws.objBitmap, new Rectangle(new Point(0, 0), _size));
                    }
                    if (ws.objBitmap != null) ws.objBitmap.Dispose();
                    ws.objBitmap = resize;
                    ws.objRect = new RectangleF(0, 0, ws.objBitmap.Width, ws.objBitmap.Height);
                    SetAlignCenter();
                    if (frm != null)
                    {
                        frm.reLoad();
                    }
                    
                }
                lblPixelPerCm.Text = ws.pixelPerCm.ToString("F1") + " px/cm";
                pm.Invalidate();
                AddUndoList("단위변경", true);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }

        }

        //원본 자유 회전 시작
        private void RotateObjectStart()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                float _len = (float)Math.Sqrt(Math.Pow(ws.objBitmap.Width, 2) + Math.Pow(ws.objBitmap.Height, 2));
                //회전에 맞도록 사각형 확장
                if (_len > Math.Min(ws.objBitmap.Height, ws.objBitmap.Width) && ws.objBitmap.Height != ws.objBitmap.Width) //이미 한번 회전한 경우는 무시
                {
                    if (!Util.CheckConfirm("현재 개체사이즈가 회전하려는 개체사이즈에 비해 작아 회전시 가장자리가 잘릴 수 있습니다. 그래도, 회전하시겠습니까? 회전을 위해 용지 및 개체를 확장합니다.")) return;
                    ws.paperSize = new SizeF(_len, _len);
                    if (ws.bitmap != null) ws.bitmap.Dispose();
                    ws.bitmap = Util.GetBlankImage((int)ws.paperSize.Width, (int)ws.paperSize.Height, ws.objBitmap.HorizontalResolution, ws.objBitmap.VerticalResolution);
                    pm.Image.Dispose();
                    pm.Image = ws.bitmap;
                    Bitmap clone = new Bitmap((int)_len, (int)_len, ws.objBitmap.PixelFormat);
                    clone.SetResolution(ws.objBitmap.HorizontalResolution, ws.objBitmap.VerticalResolution);
                    using (Graphics g = Graphics.FromImage(clone))
                    {
                        g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, clone.Width, clone.Height));
                        g.DrawImage(ws.objBitmap, new RectangleF((ws.paperSize.Width - ws.objBitmap.Width) / 2, (ws.paperSize.Height - ws.objBitmap.Height) / 2, ws.objBitmap.Width, ws.objBitmap.Height));
                    }
                    ws.SetObjBitmap(clone);
                    ZoomImage();
                }
                //개체 가운데 정렬
                //ws.objRect = new RectangleF((ws.paperSize.Width - _len) / 2, (ws.paperSize.Height - _len) / 2 , _len, _len);

                ws.objCropRect = new RectangleF(0, 0, 0, 0);
                ws.listDragPoint.Clear();
                ws.nowDrawingObjectType = DrawingObjectType.ObjRotate;
                ws.listDragPoint.Add(new PointF(ws.objRect.X + ws.objRect.Width / 2, ws.objRect.Y + ws.objRect.Height / 2));
                ws.listDragPoint.Add(new PointF(ws.objRect.X + ws.objRect.Width / 2, ws.objRect.Y + ws.objRect.Height / 2 - 200));
                SetCursor(Cursors.Cross);
                ShowStatus("마우스를 이용하여 회전점을 드래그하세요. ");
                pm.Invalidate();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //이미지 저장 filename이 없는 경우 임시파일에 저장한 후 네비에만 추가
        private void SaveImage(string filename, bool isFileSave = false)
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                float _scale = (float)pm.Width / pm.Image.Width;
                if (ws.bitmap == null) return;
                bool isAuto = (filename == "");
                if (isAuto) filename = ws.WORK_DIREC + Util.GetNameFromTimebase() + ".JPG";
                int w, h;
                if (pm.Image.Width > 4000)
                {
                    w = 4000;
                    h = (int)(1.0 * pm.Image.Height * w / pm.Image.Width);
                }
                else
                {
                    w = pm.Image.Width;
                    h = pm.Image.Height;
                }
                Bitmap bmp = new Bitmap(w, h);
                bmp.SetResolution(ws.objBitmap.HorizontalResolution, ws.objBitmap.VerticalResolution);
                pm.ClientSize = new Size(w, h);
                pm.Invalidate();
                pm.DrawToBitmap(bmp, new Rectangle(0, 0, w, h));

                EncoderParameters encoderParameters = new EncoderParameters(1);
                EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                ImageCodecInfo codecInfo = ImageCodecInfo.GetImageDecoders().First(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
                encoderParameters.Param[0] = encoderParameter;

                //이미 파일서버에 저장된 이미지를 불러온 경우 해당 경로에 insert처리하자.
                if (!string.IsNullOrEmpty(this.receivedPtoNo) && isFileSave == false)
                {
                    //this.ImageUpdateCheck(this.receivedPtoNo, this.receviedFilePath);
                    if (this.callService == null)
                    {
                        if (Global.strIsDev == "Y")
                        {
                            this.callService = new CallService("10.10.221.71", "8180");
                            this.Text = Text + "   (개발)";
                        }
                        else
                        {
                            this.callService = new CallService(Global.strCallService);
                        }
                    }

                    KeyValueData param = new KeyValueData();
                    param.Add("Data1", this.receivedPtoNo);
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



                            string tempFolder = System.Environment.CurrentDirectory + "\\" + "tempFiles";

                            DirectoryInfo di = new DirectoryInfo(tempFolder);
                            if (di.Exists == false)
                            {
                                di.Create();
                            }






                            DateTime current = DateTime.Now;
                            //string fileName = "A" + current.ToString("yyyyMMddHHmmss") + imageCount + ".jpg";
                            string fileName = this.receivedPtoNo + "_" + current.ToString("yyyyMMddHHmmss") + imageCount.ToString() + ".jpg";


                            string filePath = "imagedata\\"; // g_PathData.strImagePath;
                            string tempPath = current.ToString("yyyy") + "\\";
                            filePath = filePath + tempPath;

                            tempPath = this.receivedPtoNo + "\\";
                            filePath = filePath + tempPath;


                            // *.jpg 파일 복사
                            string localFileSavePath = tempFolder + "\\" + fileName;
                            //filePath = filePath + fileName;
                            //File.Copy(data.strRowFilePath, filePath);
                            bmp.Save(localFileSavePath, codecInfo, encoderParameters);
                            encoderParameters.Dispose();
                            encoderParameter.Dispose();
                            bmp.Dispose();

                            string savePath = filePath + fileName;

                            if (ft.FileUpload(localFileSavePath, savePath) == false)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("이미지 저장에 실패했습니다.");
                                Global.logHelper.WriteLog("editorImageSave", LogType.ERROR, ActionType.ACTION, "Editor 이미지 저장", "파일서버 전송 실패", studyId: studyId, paramInfo: "savePath : " + savePath);
                            }
                            else
                            {
                                Global.logHelper.WriteLog("editorImageSave", LogType.INFO, ActionType.ACTION, "Editor 이미지 저장", "파일서버 전송 성공", studyId: studyId, paramInfo: "savePath : " + savePath);

                                pm.ClientSize = new Size((int)(pm.Image.Width * _scale), (int)(pm.Image.Height * _scale));
                                pm.Invalidate();

                                //data.nStudyId = studyId.ToInt();
                                string imageType = "0";
                                if (selectedImage != null)
                                {
                                    imageType = selectedImage["imageType"].ToString();
                                }
                                if (imageType == "0")
                                {
                                    gi = gi + 1;
                                }
                                else if (imageType == "1")
                                {
                                    mi = mi + 1;
                                }
                                else if (imageType == "2")
                                {
                                    oi = oi + 1;
                                }

                                int nImageNum = imageCount + 1;
                                int nSerialNo = imageCount + 1;
                                //data.strSaveRootPath = this.strImagePath;
                                //string strSaveFilePath = filePath.Substring(this.strImagePath.Length, filePath.Length - this.strImagePath.Length);
                                string sendStatus = "0";

                                string insertDt = DateTime.Now.ToString("yyyyMMddHHmmss");
                                KeyValueData saveParam = new KeyValueData();
                                saveParam.Add("Data1", imageType.ToString());
                                saveParam.Add("Data2", nSerialNo.ToString());
                                saveParam.Add("Data3", studyId);
                                saveParam.Add("Data4", "Z:\\");
                                saveParam.Add("Data5", savePath);
                                saveParam.Add("Data6", sendStatus);

                                saveParam.Add("Data7", gi.ToString());
                                saveParam.Add("Data8", mi.ToString());
                                saveParam.Add("Data9", oi.ToString());
                                saveParam.Add("Data10", insertDt);
                                saveParam.Add("Data11", SessionInfo.userId);
                                CallResultData saveResult = this.callService.SelectSql("reqInsViewerImageData", saveParam);
                                if (saveResult.resultState == ResultState.OK)
                                {
                                    Global.logHelper.WriteLog("editorImageSave", LogType.INFO, ActionType.CALL_DB, "Editor 이미지 저장", "DB저장 성공", studyId: studyId, paramInfo: "savePath : " + savePath);

                                    //이미지 저장 후 처리
                                    this.UpdateImageSaveAfter(studyId);

                                    //데이터 조회 성공
                                    //PASS
                                    Util.ShowConfirm("파일을 저장하였습니다.");
                                    this.Close();
                                }
                                else
                                {
                                    Global.logHelper.WriteLog("editorImageSave", LogType.INFO, ActionType.CALL_DB, "Editor 이미지 저장", "DB저장 실패", studyId: studyId, paramInfo: "savePath : " + savePath);
                                    //실패에 대한 처리
                                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지 테이블 저장에 실패하였습니다.");
                                    return;
                                }
                            }

                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("이미지 추가 : Query Error(Select Form Study)");
                            //return false;
                        }
                    }
                    else
                    {
                        //실패에 대한 처리
                        DevExpress.XtraEditors.XtraMessageBox.Show("이미지 추가 : Query Error(Select Form Study)");
                        //return
                    }



                }
                else
                {
                    bmp.Save(filename, codecInfo, encoderParameters);
                    encoderParameters.Dispose();
                    encoderParameter.Dispose();
                    bmp.Dispose();


                    pm.ClientSize = new Size((int)(pm.Image.Width * _scale), (int)(pm.Image.Height * _scale));
                    pm.Invalidate();
                    if (isAuto)
                    {
                        FileInfo fileInfo = new FileInfo(filename);
                        PictureBoxForNavigate pictureBoxForNavigate = new PictureBoxForNavigate(fileInfo.Name, filename, ws);
                        FlowLayoutPanelImages.Controls.Add(pictureBoxForNavigate);
                        ws.listNavi.Add(pictureBoxForNavigate);
                    }
                    Util.ShowConfirm("파일을 저장하였습니다.");
                }






            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
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
                return true;
            }
            else
            {
                //실패에 대한 처리
                DevExpress.XtraEditors.XtraMessageBox.Show("이미지 저장 후 처리 업데이트시 오류");
                return false;
            }
        }

        //90,-90 등 회전
        private void RotateFlipImage(RotateFlipType rfType)
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                if (ws.objBitmap == null) return;
                Bitmap bitmap = (Bitmap)ws.objBitmap.Clone();
                bitmap.RotateFlip(rfType);
                ws.SetObjBitmap(bitmap);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //원본 자르기
        private void CropImage()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                if (ws.objCropRect.Width == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("먼저 배경제거를 통해 검체 테두리를 설정하여야 합니다.");
                }
                if (!Util.CheckConfirm("현재 설정된 영역으로 검체를 자르시겠습니까?"))
                {
                    ws.nowPicStatus = PicStatus.Select;
                    pm.Invalidate();
                    return;
                }
                ws.nowPicStatus = PicStatus.None;
                var _rect = new RectangleF(ws.objCropRect.X - ws.objRect.X, ws.objCropRect.Y - ws.objRect.Y, ws.objCropRect.Width, ws.objCropRect.Height);
                var _pnt = new PointF((_rect.X < 0 ? 0 : _rect.X), (_rect.Y < 0 ? 0 : _rect.Y));
                var _size = new SizeF((_rect.Width > ws.objBitmap.Width - _pnt.X ? ws.objBitmap.Width - _pnt.X : _rect.Width), (_rect.Height > ws.objBitmap.Height - _pnt.Y ? ws.objBitmap.Height - _pnt.Y : _rect.Height));
                _rect = new RectangleF(_pnt, _size);
                Bitmap croppedImage = ws.objBitmap.Clone(_rect, ws.objBitmap.PixelFormat);
                ws.SetObjBitmap(croppedImage);
                ws.objCropRect = new RectangleF(0, 0, 0, 0);
                if (rdoPaperSource.Checked) _ChangePaper(true); // Undo 에 넣지 않음
                CancelTask();
                AddUndoList("자르기", true);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //배경 삭제
        //bool isAuto : 자동인지 수동인지 여부
        private void RemoveBG(bool isAuto)
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                Scalar blueLower, blueUpper;
                if (isAuto)
                {
                    blueLower = new Scalar(100, 0, 0);
                    blueUpper = new Scalar(255, 100, 100);
                }
                else
                {
                    var range = this.trbBGwindow.Value;
                    blueLower = new Scalar(Math.Max(0, ws.bgColorBefore.B - range)
                        , Math.Max(0, ws.bgColorBefore.G - range / 2)
                        , Math.Max(0, ws.bgColorBefore.R - range / 2));
                    blueUpper = new Scalar(Math.Min(255, ws.bgColorBefore.B + range)
                        , Math.Min(255, ws.bgColorBefore.G + range / 2)
                        , Math.Min(255, ws.bgColorBefore.R + range / 2));
                }
                Mat src = OpenCvSharp.Extensions.BitmapConverter.ToMat(ws.objBitmap);
                Mat mask = new Mat();
                Mat dst = new Mat();
                Cv2.InRange(src, blueLower, blueUpper, mask);
                Cv2.BitwiseAnd(src, src, dst, ~mask);
                dst.SetTo(new Scalar(ws.bgColorAfter.B, ws.bgColorAfter.G, ws.bgColorAfter.R), mask);
                Bitmap bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(dst, ws.objBitmap.PixelFormat);
                bitmap.SetResolution(ws.objBitmap.HorizontalResolution, ws.objBitmap.VerticalResolution);
                ws.SetObjBitmap(bitmap);
                dst.Dispose();
                mask.Dispose();
                src.Dispose();
                pm.Invalidate();
                Util.ShowConfirm("배경을 삭제하였습니다.");
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }
        //테두리 생성 흰색배경제거 - 회색으로 변경후 특정 색 범위로 변경
        private void createEdge()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                SetCursor(Cursors.WaitCursor);
                Scalar blueLower, blueUpper;
                blueLower = new Scalar(155 + (int)20 * trbEdge.Value);
                blueUpper = new Scalar(255);
                Mat src = OpenCvSharp.Extensions.BitmapConverter.ToMat(ws.objBitmap);
                Mat gray = new Mat();
                Mat mask = new Mat();
                Mat dst = new Mat(src.Size(), src.Type(), Scalar.White);
                Cv2.Rectangle(dst, new Rect(0, 0, src.Width, src.Height), Scalar.White, -1);
                Cv2.CvtColor(src, gray, ColorConversionCodes.RGB2GRAY);
                Cv2.InRange(gray, blueLower, blueUpper, mask);
                OpenCvSharp.Point[][] contours;
                HierarchyIndex[] hierarchy;
                Cv2.FindContours(mask, out contours, out hierarchy, RetrievalModes.List, ContourApproximationModes.ApproxNone);
                double area;
                int i = 0;
                foreach (var contour in contours)
                {
                    area = Cv2.ContourArea(contour);
                    //if (area < ws.objBitmap.Width * ws.objBitmap.Height * 0.9 && area > 100)
                    if (area < ws.objBitmap.Width * ws.objBitmap.Height * 0.9 && area > 100)
                    {
                        Cv2.DrawContours(dst, contours, i, Scalar.Black, 3);
                    }
                    i++;
                }
                Bitmap bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(dst, ws.objBitmap.PixelFormat);
                bitmap.SetResolution(ws.objBitmap.HorizontalResolution, ws.objBitmap.VerticalResolution);
                ws.objBitmap.Dispose();
                ws.objBitmap = bitmap;
                dst.Dispose();
                gray.Dispose();
                mask.Dispose();
                src.Dispose();
                pm.Invalidate();
                AddUndoList("검체테두리생성", true);
                SetCursor(Cursors.Default);
            }
            catch (Exception ex)
            {
                SetCursor(Cursors.Default);
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //사용하지 않음 테두리 생성 Canny Edge Detection 사용
        //- threshold 값을 조정가능 현재 80을 0이나 50으로 바꾸면 좀 더 자세한 경계값 표시
        private void createEdgeByCanny()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                Mat src = OpenCvSharp.Extensions.BitmapConverter.ToMat(ws.objBitmap);
                Mat gray = new Mat();
                Mat dst = new Mat(src.Size(), src.Type(), Scalar.White);
                Cv2.Rectangle(dst, new Rect(0, 0, src.Width, src.Height), Scalar.White, -1);
                Cv2.CvtColor(src, gray, ColorConversionCodes.RGB2GRAY);
                Cv2.Canny(gray, dst, 80, 100);
                Bitmap bitmap = OpenCvSharp.Extensions.BitmapConverter.ToBitmap(~dst);
                bitmap.SetResolution(ws.objBitmap.HorizontalResolution, ws.objBitmap.VerticalResolution);
                Bitmap clone = new Bitmap(ws.objBitmap.Width, ws.objBitmap.Height, ws.objBitmap.PixelFormat);
                clone.SetResolution(ws.objBitmap.HorizontalResolution, ws.objBitmap.VerticalResolution);

                using (Graphics g = Graphics.FromImage(clone))
                {
                    g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, clone.Width, clone.Height));
                    //가장자리 2픽셀씩 테두리 없애기 위해 제외
                    g.DrawImage(bitmap, new Rectangle(2, 2, clone.Width - 4, clone.Height - 4));
                }
                ws.SetObjBitmap(clone);
                bitmap.Dispose();
                dst.Dispose();
                gray.Dispose();
                src.Dispose();
                pm.Invalidate();
                AddUndoList("검체테두리", true);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        #endregion Image

        #region Object
        //직선 시작
        private void LineStart()
        {

            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                int zindex = getNewZindex();
                DrawingObject obj = new DrawingObject(DrawingObjectType.Line, zindex);
                obj.lineColor = btnLineColor.BackColor;
                obj.lineThickness = int.Parse(tbxLineThick.Text);
                ws.listObjects.Add(obj);
                ws.SetNowObject(obj, PicStatus.Start);
                SetCursor(Cursors.Cross);
                ShowStatus("마우스를 클릭하여 시작점을 정하고 드래그하세요.");
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //px/cm 변경 창 로드
        private void ChangeUnit()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                var f = new RulerForm();
                f.LoadData(this);
                f.ShowDialog();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //줄자 시작
        private void RulerStart()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                int zindex = getNewZindex();
                DrawingObject obj = new DrawingObject(DrawingObjectType.Ruler, zindex);
                obj.lineColor = btnFontColor.BackColor;
                obj.lineThickness = int.Parse(tbxLineThick.Text);
                obj.font = new Font(btnFont.Font.FontFamily, int.Parse(tbxFontsize.Text), btnFont.Font.Style);
                ws.listObjects.Add(obj);
                ws.SetNowObject(obj, PicStatus.Start);
                SetCursor(Cursors.Cross);
                ShowStatus("마우스를 클릭하여 시작점을 정하고 드래그하세요.");
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        List<DrawingObject> tempObject = new List<DrawingObject>();

        //다각형 테스트
        private void RectStartTest()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }


                if (tempObject.Count() > 0)
                {
                    for (int i = tempObject.Count - 1; i >= 0; i--)
                    {
                        DrawingObject tempObj = tempObject.ElementAt(i);
                        ws.listObjects.Remove(tempObj);
                        ws.SetNowObject(null, PicStatus.None);
                        pm.Invalidate();
                    }

                    tempObject.Clear();

                    //foreach (DrawingObject tempObj in tempObject)
                    //{
                    //    ws.listObjects.Remove(tempObj);
                    //    ws.SetNowObject(null, PicStatus.None);
                    //    pm.Invalidate();
                    //}


                    //ws.listObjects.Clear();
                    //ws.SetNowObject(null, PicStatus.None);
                    //pm.Invalidate();
                    //tempObject.Clear();

                    return;

                }




                //int zindex = getNewZindex();
                //DrawingObject obj = new DrawingObject(DrawingObjectType.Rect, zindex);
                //obj.lineColor = Color.White;
                //obj.isTransparent = this.chkPolyTransparent.Checked;
                //obj.faceColor = Color.White;
                //obj.lineThickness = int.Parse(tbxPolyThick.Text);
                //ws.listObjects.Add(obj);
                //ws.SetNowObject(obj, PicStatus.Start);
                ////ws.nowPicStatus = PicStatus.End;

                //ws.no.rect = new RectangleF(100, 100, 500, 100);

                //tempObject.Add(ws.no);


                //ws.no.listPoint.Add(_dragStart);
                //ws.no.listPoint.Add(_dragStart);
                //ws.nowPicStatus = PicStatus.End;

                //pm.Invalidate();

                //ws.nowPicStatus = PicStatus.None;
                //SetCursor(Cursors.Default);

                int zindex2 = getNewZindex();
                DrawingObject obj2 = new DrawingObject(DrawingObjectType.Text, zindex2);
                obj2.lineColor = btnFontColor.BackColor;
                obj2.font = new Font("굴림", 16);
                ws.listObjects.Add(obj2);
                ws.SetNowObject(obj2, PicStatus.Start);
                //ws.nowPicStatus = PicStatus.End;

                ws.no.text = "test123";
                ws.no.rect = new RectangleF(
                                   100, 100
                                   , 500, 100
                                   );

                CancelTask();
                pm.Invalidate();


                ws.listObjects.Remove(ws.no);
                ws.SetNowObject(null, PicStatus.None);

                tempObject.Add(ws.no);

                //SetCursor(Cursors.Cross);
                //ShowStatus("마우스를 클릭하여 시작점을 정하고 드래그하세요. ");
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }



        //사각형 시작
        private void RectStart()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                int zindex = getNewZindex();
                DrawingObject obj = new DrawingObject(DrawingObjectType.Rect, zindex);
                obj.lineColor = btnPolyLineColor.BackColor;
                obj.isTransparent = this.chkPolyTransparent.Checked;
                obj.faceColor = btnPolyFaceColor.BackColor;
                obj.lineThickness = int.Parse(tbxPolyThick.Text);
                ws.listObjects.Add(obj);
                ws.SetNowObject(obj, PicStatus.Start);
                SetCursor(Cursors.Cross);
                ShowStatus("마우스를 클릭하여 시작점을 정하고 드래그하세요. ");
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //원 시작
        private void CircleStart()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                int zindex = getNewZindex();
                DrawingObject obj = new DrawingObject(DrawingObjectType.Circle, zindex);
                obj.lineColor = btnPolyLineColor.BackColor;
                obj.isTransparent = this.chkPolyTransparent.Checked;
                obj.faceColor = btnPolyFaceColor.BackColor;
                obj.lineThickness = int.Parse(tbxPolyThick.Text);
                ws.listObjects.Add(obj);
                ws.SetNowObject(obj, PicStatus.Start);
                SetCursor(Cursors.Cross);
                ShowStatus("마우스를 클릭하여 시작점을 정하고 드래그하세요. ");
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //삼각형 시작
        private void TriStart()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                int zindex = getNewZindex();
                DrawingObject obj = new DrawingObject(DrawingObjectType.Triangle, zindex);
                obj.lineColor = btnPolyLineColor.BackColor;
                obj.isTransparent = this.chkPolyTransparent.Checked;
                obj.faceColor = btnPolyFaceColor.BackColor;
                obj.lineThickness = int.Parse(tbxPolyThick.Text);
                ws.listObjects.Add(obj);
                ws.SetNowObject(obj, PicStatus.Start);
                SetCursor(Cursors.Cross);
                ShowStatus("마우스를 클릭하여 시작점을 정하고 드래그하세요.");
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }



        /// <summary>
        /// name         : ChangeAutoCm
        /// desc         : CM 값에 맞게 자동으로 사이즈를 조절한다.
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ChangeAutoCm()
        {
            if (this.selectedImageRow == null) return;
            if (this.selectedImageRow.Table.Columns.Contains("strCm") && this.selectedImageRow.Table.Columns.Contains("cmChanged"))
            {

                string cmChanged = this.selectedImageRow["cmChanged"].ToString();
                if (cmChanged == "Y") return;


                if (!string.IsNullOrEmpty(selectedImageRow["strCm"].ToString()) && selectedImageRow["strCm"].ToString().ToIntOrNull() != null)
                {


                    int changeCm = selectedImageRow["strCm"].ToString().ToInt();


                    if (changeCm > 0)
                    {
                        RulerForm f = new RulerForm();
                        f.LoadData(this);
                        //MessageBox.Show(changeCm.ToString());
                        //설정된 cm으로 간격을 수정한다.
                        ws.pixelPerCm = changeCm;
                        //lblPixelPerCm.Text = _len.ToString("F1") + " px/cm";
                        this.UpdatePixelPerCm(f);

                        _ChangePaper();
                        pm.Invalidate();

                        this.selectedImageRow["cmChanged"] = "Y";
                    }
                }

            }

            
            
        }



        //다각형 시작
        private void PolyStart()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                int zindex = getNewZindex();
                DrawingObject obj = new DrawingObject(DrawingObjectType.Polygon, zindex);
                obj.lineColor = btnPolyLineColor.BackColor;
                obj.isTransparent = this.chkPolyTransparent.Checked;
                obj.faceColor = btnPolyFaceColor.BackColor;
                obj.lineThickness = int.Parse(tbxPolyThick.Text);
                ws.listObjects.Add(obj);
                ws.SetNowObject(obj, PicStatus.Start);
                SetCursor(Cursors.Cross);
                ShowStatus("마우스를 클릭하여 시작점을 정하고 드래그하세요.");
                btnFinishObject.Visible = true;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //자유선 테두리 사각형 및 내용 정리(점의 갯수가 2개 이하면 삭제)
        private bool checkFreeObjectRect(DrawingObject obj)
        {
            try
            {
                PointF _pnt;
                float minx = 100000, miny = 100000, maxx = 0, maxy = 0;
                for (int i = 0; i < obj.listFreePoint.Count; i++)
                {
                    for (int j = 0; j < obj.listFreePoint[i].Count; j++)
                    {
                        _pnt = obj.listFreePoint[i][j];
                        if (_pnt.X < minx) minx = _pnt.X;
                        if (_pnt.X > maxx) maxx = _pnt.X;
                        if (_pnt.Y < miny) miny = _pnt.Y;
                        if (_pnt.Y > maxy) maxy = _pnt.Y;
                    }
                }
                obj.rect = new RectangleF(minx, miny, maxx - minx, maxy - miny);
                if (obj.rect.Width < 10 && obj.rect.Height < 10)
                {
                    return false;
                }
                else return true;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        //자유선 시작
        private void FreeStart()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                int zindex = getNewZindex();
                DrawingObject obj = new DrawingObject(DrawingObjectType.Free, zindex);
                obj.lineColor = btnLineColor.BackColor;
                obj.lineThickness = int.Parse(tbxLineThick.Text);
                ws.listObjects.Add(obj);
                ws.SetNowObject(obj, PicStatus.Start);
                SetCursor(Cursors.Cross);
                ShowStatus("마우스를 클릭하여 시작점을 정하고 드래그하세요.");
                btnFinishObject.Visible = true;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //문자 시작
        private void TextStart()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                int zindex = getNewZindex();
                DrawingObject obj = new DrawingObject(DrawingObjectType.Text, zindex);
                obj.lineColor = btnFontColor.BackColor;
                obj.font = new Font(btnFont.Font.FontFamily.Name, int.Parse(tbxFontsize.Text), btnFont.Font.Style);
                ws.listObjects.Add(obj);
                ws.SetNowObject(obj, PicStatus.Start);
                SetCursor(Cursors.Cross);
                ShowStatus("마우스를 클릭하여 시작점을 정하세요.");
                btnFinishObject.Visible = true;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //모든 개체 삭제
        private void DeleteObjectAll()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                if (ws.listObjects.Count == 0)
                {
                    Util.ShowConfirm("삭제할 개체가 없습니다.");
                    return;
                }
                ws.listObjects.Clear();
                ws.SetNowObject(null, PicStatus.None);
                pm.Invalidate();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //선택 개체 삭제
        private void DeleteObject()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                if (ws.no == null)
                {
                    Util.ShowConfirm("먼저 개체를 선택해야 합니다.");
                    return;
                }
                ws.listObjects.Remove(ws.no);
                ws.SetNowObject(null, PicStatus.None);
                pm.Invalidate();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //위/아래로 이동
        private void MoveLayer(int flag) // 1 위로 -1 아래로 9 맨 위로 -9 맨 아래로
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                if (ws.no == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("먼저 개체를 선택해야 합니다.");
                    return;
                }
                int _zIndex = ws.no.zIndex;
                DrawingObject _nextObj;
                if (flag == 1)
                {
                    if (ws.listObjects.Where(p => p.zIndex > _zIndex).Count() > 0)
                    {
                        _nextObj = ws.listObjects.Where(p => p.zIndex > _zIndex).OrderBy(p => p.zIndex).First();
                        ws.no.zIndex = _nextObj.zIndex;
                        _nextObj.zIndex = _zIndex;
                        pm.Invalidate();
                    }
                }
                else if (flag == 9)
                {
                    if (ws.listObjects.Where(p => p.zIndex > _zIndex).Count() > 0)
                    {
                        _nextObj = ws.listObjects.Where(p => p.zIndex > _zIndex).OrderByDescending(p => p.zIndex).First();
                        ws.no.zIndex = _nextObj.zIndex;
                        _nextObj.zIndex = _zIndex;
                        pm.Invalidate();
                    }
                }
                else if (flag == -1)
                {
                    if (ws.listObjects.Where(p => p.zIndex < _zIndex && p.zIndex > 0).Count() > 0)
                    {
                        _nextObj = ws.listObjects.Where(p => p.zIndex < _zIndex && p.zIndex > 0).OrderByDescending(p => p.zIndex).First();
                        ws.no.zIndex = _nextObj.zIndex;
                        _nextObj.zIndex = _zIndex;
                        pm.Invalidate();
                    }
                }
                else if (flag == -9)
                {
                    if (ws.listObjects.Where(p => p.zIndex < _zIndex && p.zIndex > 0).Count() > 0)
                    {
                        _nextObj = ws.listObjects.Where(p => p.zIndex < _zIndex && p.zIndex > 0).OrderBy(p => p.zIndex).First();
                        ws.no.zIndex = _nextObj.zIndex;
                        _nextObj.zIndex = _zIndex;
                        pm.Invalidate();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }

        }

        //상황에 맞게 처리한 후 취소
        private void FinishTask()
        {
            try
            {
                float zf = (float)(1.0 * pm.ClientSize.Width / pm.Image.Width);
                if (ws.nowDrawingObjectType == DrawingObjectType.ObjRotate)
                {
                    if (ws.no.listPoint.Count() > 2)
                    {
                        ws.no.listPoint.RemoveAt(ws.no.listPoint.Count() - 1);
                    }
                }
                else if (ws.no == null) { }
                else if (ws.no.oType == DrawingObjectType.Polygon && ws.nowPicStatus != PicStatus.Select)
                {
                    if (ws.no.listPoint.Count() > 2)
                    {
                        ws.no.listPoint.RemoveAt(ws.no.listPoint.Count() - 1);
                        AddUndoList(ws.no.oType.ToString() + " : " + ws.nowPicStatus.ToString(), false);

                    }
                }
                else if (ws.no.oType == DrawingObjectType.Free && ws.nowPicStatus != PicStatus.Select)
                {
                    if (ws.no.listFreePoint.Count() > 0)
                    {
                        // 2개 이하의 점을 가진 것은 삭제하고, 내용이 없으면 자유선 아이템 자체 삭제
                        for (int i = ws.no.listFreePoint.Count - 1; i >= 0; i--)
                        {
                            if (ws.no.listFreePoint[i].Count <= 2) ws.no.listFreePoint.RemoveAt(i);
                        }
                        if (ws.no.listFreePoint.Count == 0)
                        {
                            ws.listObjects.Remove(ws.no);
                            ws.no = null;
                        }
                        else
                        {
                            checkFreeObjectRect(ws.no);
                            if (ws.no.rect.Width < 10 && ws.no.rect.Height < 10)
                            {
                                ws.listObjects.Remove(ws.no);
                                ws.no = null;
                            }
                            else AddUndoList(ws.no.oType.ToString() + " : " + ws.nowPicStatus.ToString(), false);
                        }
                    }
                }
                else if (ws.no.oType == DrawingObjectType.Text && ws.nowPicStatus != PicStatus.Select)
                {
                    if (tbxInput.Text != "")
                    {
                        ws.no.text = tbxInput.Text;
                        Size size = UpdateTextSize(ws.no.text, ws.no.font);
                        ws.no.rect = new RectangleF((tbxInput.Location.X - pm.Location.X) / zf, (tbxInput.Location.Y - pm.Location.Y) / zf, size.Width / zf, size.Height / zf);
                        tbxInput.Visible = false;
                        AddUndoList(ws.no.oType.ToString() + " : " + ws.nowPicStatus.ToString(), false);
                    }
                }
                ShowStatus("작업을 완료했습니다.");
                CancelTask();

            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }

        }

        //일방적 취소
        private void CancelTask()
        {
            try
            {
                ws.unSelectAllObject();
                _drag = false;
                tbxInput.Visible = false;
                btnFinishObject.Visible = false;
                SetCursor(Cursors.Default);
                if (ws.no != null) ws.no.isSelect = false;
                ws.no = null;
                _selGrid = null;
                _selCell = null;
                _selGizmo = Gizmo.None;
                ws.nowDrawingObjectType = DrawingObjectType.None;
                ws.nowPicStatus = PicStatus.None;
                pm.Invalidate();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        #endregion Object

        #region Grid
        //격자 생성
        private void createGrid()
        {
            try
            {
                if (!this.chkShowGrid.Checked)
                {
                    this.chkShowGrid.Checked = true;
                    ws.isGridShow = true;
                }
                _selGrid = null;
                _selCell = null;
                GridObject _grid;
                if (rdoAll.Checked)
                {
                    if (ws.listGrids.Where(p => p.GridRect.Size == ws.paperSize).Count() > 0)
                    {
                        ws.listGrids.Remove(ws.listGrids.Where(p => p.GridRect.Size == ws.paperSize).ToList()[0]);
                    }
                    _grid = new GridObject(new RectangleF(new PointF(0, 0), ws.paperSize), float.Parse(tbxGridHor.Text), float.Parse(tbxGridVer.Text), 0, 0, true, ws);
                    ws.listGrids.Insert(0, _grid);
                    _grid.setDesign(int.Parse(tbxGridThick.Text), int.Parse(tbxGridVThick.Text), btnGridColor.BackColor);
                    AddUndoList("격자생성", false);
                }
                else
                {
                    _grid = new GridObject(new RectangleF(0, 0, 0, 0), 0, 0, int.Parse(tbxGridColumnCount.Text), int.Parse(tbxGridRowCount.Text), false, ws);
                    ws.listGrids.Add(_grid);
                    _selGrid = ws.listGrids.Last();
                    SetCursor(Cursors.Cross);
                    ShowStatus("격자 시작점을 선택하고 드래그하여 주십시요.", true);
                    ws.nowDrawingObjectType = DrawingObjectType.Grid;
                    ws.nowPicStatus = PicStatus.Start;
                    _grid.setDesign(int.Parse(tbxGridThick.Text), int.Parse(tbxGridVThick.Text), btnGridColor.BackColor);
                }
                pm.Invalidate();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //격자 선택
        private void GridSelect()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                if (ws.listGrids.Count == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("격자를 먼저 생성해야 합니다.");
                    return;
                }
                CancelTask();
                btnFinishObject.Visible = true;
                ws.nowDrawingObjectType = DrawingObjectType.Grid;
                ws.nowPicStatus = PicStatus.Select;
                pm.Invalidate();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //격자 삭제
        private void GridDelete()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                if (ws.listGrids.Count == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("격자를 먼저 생성해야 합니다.");
                    return;
                }
                if (_selGrid == null)
                {
                    Util.ShowConfirm("격자를 먼저 선택해야 합니다.");
                    return;
                }
                ws.listGrids.Remove(_selGrid);
                _selGrid = null;
                _selCell = null;
                pm.Invalidate();
                AddUndoList("격자삭제", false);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //개체 이동
        private void MoveInstpectedObject()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                if (ws.objBitmap == null)
                {
                    Util.ShowConfirm("먼저 검체를 가져와야 합니다.");
                    return;
                }
                btnFinishObject.Visible = true;
                ws.nowDrawingObjectType = DrawingObjectType.None;
                ws.nowPicStatus = PicStatus.InspectObj;
                pm.Invalidate();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //마커 그리기 / 지우기 시작 - isMarking
        private void MarkerDraw()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                if (ws.listGrids.Count == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("격자를 먼저 생성해야 합니다.");
                    return;
                }
                btnFinishObject.Visible = true;
                SetCursor(Cursors.Cross);
                ws.markerColor = Color.FromArgb(trbMarker.Value, btnMarkerColor.BackColor);
                ws.nowDrawingObjectType = DrawingObjectType.Marker;
                ws.nowPicStatus = PicStatus.None;
                pm.Invalidate();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //마커 모두 지우기
        private void deleteMarker()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                if (ws.listGrids.Count == 0)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("격자를 먼저 생성해야 합니다.");
                    return;
                }
                foreach (var item in ws.listGrids) item.clearMarker();
                pm.Invalidate();
                AddUndoList("마커삭제", false);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //가운데 정렬
        private void SetAlignCenter()
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                if (ws.objBitmap != null)
                    ws.objRect = new RectangleF((ws.paperSize.Width - ws.objRect.Width) / 2, (ws.paperSize.Height - ws.objRect.Height) / 2
                    , ws.objRect.Width, ws.objRect.Height);
                pm.Invalidate();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //용지 변경
        //bool isFromUndo : 되돌리기에서 실행여부(기본값 false) 되돌리기를 통해 실행하는 경우 되돌리기 목록에 넣지 않기 위함
        private void _ChangePaper(bool isFromUndo = false)
        {
            try
            {
                if (pm.Image == null)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미지를 먼저 선택해야 합니다.");
                    return;
                }
                bool isChanged = false;
                SizeF _size;
                RectangleF _rect;
                float _val;
                if (!float.TryParse(tbxGridHor.Text, out _val) || _val <= 0)
                {
                    Util.ShowConfirm("격자는 0보다 커야 합니다.");
                    return;
                }
                if (!float.TryParse(tbxGridVer.Text, out _val) || _val <= 0)
                {
                    Util.ShowConfirm("격자는 0보다 커야 합니다.");
                    return;
                }
                if (!float.TryParse(tbxGridRowCount.Text, out _val) || _val <= 0)
                {
                    Util.ShowConfirm("격자개수는 0보다 커야 합니다.");
                    return;
                }
                if (!float.TryParse(tbxGridColumnCount.Text, out _val) || _val <= 0)
                {
                    Util.ShowConfirm("격자개수는 0보다 커야 합니다.");
                    return;
                }
                _size = new SizeF(float.Parse(tbxGridHor.Text) * ws.pixelPerCm, float.Parse(tbxGridVer.Text) * ws.pixelPerCm);

                _size = getPaperSize();
                if (ws.listObjects.Count > 0)
                {
                    if (!Util.CheckConfirm("현재 삽입된 개체들이 있습니다. 용지를 바꾸면 위치가 모두 달라집니다. 계속하시겠습니까?")) return;
                }
                isChanged = (ws.paperSize != _size);
                if (isChanged)
                {
                    ws.paperSize = _size;
                    if (ws.listGrids.Where(p => p.isFullGrid == true).Count() > 0)
                    {
                        var _grid = ws.listGrids.Where(p => p.isFullGrid == true).ToList()[0];
                        _grid.changeGridRect(new RectangleF(new PointF(0, 0), ws.paperSize));
                    }
                }

                if (ws.bitmap != null) ws.bitmap.Dispose();
                ws.bitmap = Util.GetBlankImage((int)ws.paperSize.Width, (int)ws.paperSize.Height, ws.objBitmap.HorizontalResolution, ws.objBitmap.VerticalResolution);
                if (pm != null)
                {
                    pm.Image = ws.bitmap;
                    ZoomImage();
                }
                SetAlignCenter();
                if (!isFromUndo) AddUndoList("용지변경", false);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }
        #endregion

        #region Config
        //기본값 저장
        private void SaveConfig()
        {
            try
            {
                using (XmlWriter xmlWriter = XmlWriter.Create(Application.StartupPath + @"\Config.xml"))
                {
                    xmlWriter.WriteStartDocument();
                    xmlWriter.WriteStartElement("Sedas");
                    xmlWriter.WriteElementString("trbBGwindow", trbBGwindow.Value.ToString());
                    xmlWriter.WriteElementString("btnBeforeBGColor", btnBeforeBGColor.BackColor.ToArgb().ToString());
                    xmlWriter.WriteElementString("btnAfterBGColor", btnAfterBGColor.BackColor.ToArgb().ToString());
                    /*
                    xmlWriter.WriteElementString("ckbShowGrid", ckbShowGrid.Checked.ToString());
                    xmlWriter.WriteElementString("rdoPaperA3", rdoPaperA3.Checked.ToString());
                    xmlWriter.WriteElementString("rdoPaperA4", rdoPaperA4.Checked.ToString());
                    xmlWriter.WriteElementString("rdoPaperB4", rdoPaperB4.Checked.ToString());
                    xmlWriter.WriteElementString("rdoPaperB5", rdoPaperB5.Checked.ToString());
                    xmlWriter.WriteElementString("rdoPaperSource", rdoPaperSource.Checked.ToString());
                    xmlWriter.WriteElementString("rdoAll", rdoAll.Checked.ToString());
                    xmlWriter.WriteElementString("rdoPartial", rdoPartial.Checked.ToString());
                    */
                    xmlWriter.WriteElementString("tbxGridColumnCount", tbxGridColumnCount.Text);
                    xmlWriter.WriteElementString("tbxGridRowCount", tbxGridRowCount.Text);
                    xmlWriter.WriteElementString("tbxGridVer", tbxGridVer.Text);
                    xmlWriter.WriteElementString("tbxGridHor", tbxGridHor.Text);
                    xmlWriter.WriteElementString("tbxGridThick", tbxGridThick.Text);
                    xmlWriter.WriteElementString("tbxGridVThick", tbxGridVThick.Text);
                    xmlWriter.WriteElementString("btnGridColor", btnGridColor.BackColor.ToArgb().ToString());
                    xmlWriter.WriteElementString("btnMarkerColor", btnMarkerColor.BackColor.ToArgb().ToString());
                    xmlWriter.WriteElementString("trbMarker", trbMarker.Value.ToString());
                    xmlWriter.WriteElementString("tbxLineThick", tbxGridVThick.Text);
                    xmlWriter.WriteElementString("btnLineColor", btnLineColor.BackColor.ToArgb().ToString());
                    xmlWriter.WriteElementString("tbxPolyThick", tbxPolyThick.Text);
                    xmlWriter.WriteElementString("btnPolyLineColor", btnPolyLineColor.BackColor.ToArgb().ToString());
                    xmlWriter.WriteElementString("btnPolyFaceColor", btnPolyFaceColor.BackColor.ToArgb().ToString());
                    xmlWriter.WriteElementString("chkPolyTransparent", this.chkPolyTransparent.Checked.ToString());
                    xmlWriter.WriteElementString("btnFontFamily", btnFont.Font.FontFamily.Name.ToString());
                    xmlWriter.WriteElementString("tbxFontsize", tbxFontsize.Text.ToString());
                    xmlWriter.WriteElementString("btnFontColor", btnFontColor.BackColor.ToArgb().ToString());
                    xmlWriter.WriteEndElement();
                    xmlWriter.WriteEndDocument();
                    DevExpress.XtraEditors.XtraMessageBox.Show("현재 설정을 기본값으로 저장하였습니다.");
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //기본값 불러오기
        private void LoadConfig()
        {
            try
            {
                string filename = Application.StartupPath + @"\Config.xml";
                if (!File.Exists(filename))
                {
                    Util.ShowConfirm(filename + "이 없습니다. 확인바랍니다.");
                    return;
                }
                XmlDocument xmlDocument = new XmlDocument();
                XmlNode root;
                xmlDocument.Load(filename);
                root = xmlDocument.SelectSingleNode("/Sedas");

                this.trbBGwindow.Value = int.Parse(root.SelectSingleNode("./trbBGwindow").InnerText);
                this.btnBeforeBGColor.BackColor = Color.FromArgb(int.Parse(root.SelectSingleNode("./btnBeforeBGColor").InnerText));
                this.btnAfterBGColor.BackColor = Color.FromArgb(int.Parse(root.SelectSingleNode("./btnAfterBGColor").InnerText));
                /*
                this.ckbShowGrid.Checked = (root.SelectSingleNode("./ckbShowGrid").InnerText == "True");
                this.rdoPaperA3.Checked = (root.SelectSingleNode("./rdoPaperA3").InnerText == "True");
                this.rdoPaperA4.Checked = (root.SelectSingleNode("./rdoPaperA4").InnerText == "True");
                this.rdoPaperB4.Checked = (root.SelectSingleNode("./rdoPaperB4").InnerText == "True");
                this.rdoPaperB5.Checked = (root.SelectSingleNode("./rdoPaperB5").InnerText == "True");
                this.rdoPaperSource.Checked = (root.SelectSingleNode("./rdoPaperSource").InnerText == "True");
                this.rdoAll.Checked = (root.SelectSingleNode("./rdoAll").InnerText == "True");
                this.rdoPartial.Checked = (root.SelectSingleNode("./rdoPartial").InnerText == "True");
                */
                this.tbxGridColumnCount.Text = root.SelectSingleNode("./tbxGridColumnCount").InnerText;
                this.tbxGridRowCount.Text = root.SelectSingleNode("./tbxGridRowCount").InnerText;
                this.tbxGridHor.Text = root.SelectSingleNode("./tbxGridHor").InnerText;
                this.tbxGridVer.Text = root.SelectSingleNode("./tbxGridVer").InnerText;
                this.tbxGridThick.Text = root.SelectSingleNode("./tbxGridThick").InnerText;
                this.tbxGridVThick.Text = root.SelectSingleNode("./tbxGridVThick").InnerText;
                this.btnGridColor.BackColor = Color.FromArgb(int.Parse(root.SelectSingleNode("./btnGridColor").InnerText));
                this.btnMarkerColor.BackColor = Color.FromArgb(int.Parse(root.SelectSingleNode("./btnMarkerColor").InnerText));
                this.trbMarker.Value = int.Parse(root.SelectSingleNode("./trbMarker").InnerText);

                this.tbxLineThick.Text = root.SelectSingleNode("./tbxLineThick").InnerText;
                this.btnLineColor.BackColor = Color.FromArgb(int.Parse(root.SelectSingleNode("./btnLineColor").InnerText));
                this.tbxPolyThick.Text = root.SelectSingleNode("./tbxPolyThick").InnerText;
                this.btnPolyLineColor.BackColor = Color.FromArgb(int.Parse(root.SelectSingleNode("./btnPolyLineColor").InnerText));
                this.btnPolyFaceColor.BackColor = Color.FromArgb(int.Parse(root.SelectSingleNode("./btnPolyFaceColor").InnerText));
                //this.chbPolyTransparent.Checked = (root.SelectSingleNode("./btnPolyFaceColor").InnerText == "True");

                Font _font = btnFont.Font;
                this.tbxFontsize.Text = root.SelectSingleNode("./tbxFontsize").InnerText;
                this.btnFont.Font = new Font(root.SelectSingleNode("./btnFontFamily").InnerText, 10, _font.Style);
                this.btnFont.Text = root.SelectSingleNode("./btnFontFamily").InnerText;
                this.btnFontColor.BackColor = Color.FromArgb(int.Parse(root.SelectSingleNode("./btnFontColor").InnerText));

                xmlDocument = null;
                root = null;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        #endregion

        #region TabMain & Action Button & KeyDown
        //메인탭 변경
        private void tabMain_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (ws == null) return;
                ws.nowTab = tabMain.SelectedIndex;
                ws.nowDrawingObjectType = DrawingObjectType.None;
                ws.SetNowObject(null, PicStatus.None);
                pm.Invalidate();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //텍스트입력 라우터 - 텍스트 태그 활룡
        private void eTextChanged(object sender, EventArgs e)
        {
            try
            {
                int _intv;
                TextBox tbx = (TextBox)sender;
                switch (tbx.Tag.ToString())
                {
                    case "그리드두께":
                        if (!int.TryParse(tbx.Text, out _intv)) return;
                        if (_selGrid != null) _selGrid.setDesign(int.Parse(tbxGridThick.Text), int.Parse(tbxGridVThick.Text), btnGridColor.BackColor);
                        pm.Invalidate();
                        break;
                    case "그리드세로두께":
                        if (!int.TryParse(tbx.Text, out _intv)) return;
                        if (_selGrid != null) _selGrid.setDesign(int.Parse(tbxGridThick.Text), int.Parse(tbxGridVThick.Text), btnGridColor.BackColor);
                        pm.Invalidate();
                        break;
                    case "선두께":
                        if (!int.TryParse(tbx.Text, out _intv)) return;
                        if (ws.no != null && (ws.no.oType == DrawingObjectType.Line || ws.no.oType == DrawingObjectType.Free || ws.no.oType == DrawingObjectType.Ruler))
                        {
                            ws.no.lineThickness = _intv;
                            pm.Invalidate();
                            AddUndoList(ws.no.oType.ToString() + " : " + ws.nowPicStatus.ToString(), false);
                        }
                        break;
                    case "면두께":
                        if (!int.TryParse(tbx.Text, out _intv)) return;
                        if (ws.no != null && (ws.no.oType == DrawingObjectType.Rect || ws.no.oType == DrawingObjectType.Circle || ws.no.oType == DrawingObjectType.Triangle || ws.no.oType == DrawingObjectType.Polygon))
                        {
                            ws.no.lineThickness = _intv;
                            pm.Invalidate();
                            AddUndoList(ws.no.oType.ToString() + " : " + ws.nowPicStatus.ToString(), false);
                        }
                        break;
                    case "문자크기":
                        if (!int.TryParse(tbx.Text, out _intv)) return;
                        if (ws.no != null && (ws.no.oType == DrawingObjectType.Text))
                        {
                            ws.no.font = new Font(btnFont.Font.FontFamily, _intv, btnFont.Font.Style);
                            UpdateTextRect();
                            AddUndoList(ws.no.oType.ToString() + " : " + ws.nowPicStatus.ToString(), false);
                        }
                        break;
                    case "텍스트입력":
                        if (ws.no != null && (ws.no.oType == DrawingObjectType.Text))
                        {
                            Size size = UpdateTextSize(tbx.Text, ws.no.font);
                            tbx.Size = new Size(size.Width + (int)TEXT_BOX_MARGIN[2], size.Height + (int)TEXT_BOX_MARGIN[3]);
                        }

                        break;
                    default:
                        Util.ShowConfirm("[" + tbx.Tag.ToString() + "] 명령이 없습니다. 관리자에게 문의하세요.");
                        break;
                }
                Debug.WriteLine("텍스트 태그 " + tbx.Tag.ToString());
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }

        }

        //명령 라우터 - 버튼 태그 활용
        private void eButton_Click(object sender, EventArgs e)
        {
            try
            {
                string tag = "";
                if (sender is Sedas.Control.HSimpleButton)
                {
                    Sedas.Control.HSimpleButton button = sender as Sedas.Control.HSimpleButton;
                    tag = button.Tag.ToString();
                }
                else
                {
                    Button button = (Button)sender;
                    tag = button.Tag.ToString();
                }

                int _intv;

                switch (tag)
                {
                    #region 기타
                    case "인쇄":
                        Print();
                        break;
                    case "기본값 가져오기":
                        LoadConfig();
                        break;
                    case "기본값으로 저장":
                        SaveConfig();
                        break;
                    case "원본F":
                        ZoomImage(Zoom.Source);
                        break;
                    case "폭F":
                        ZoomImage(Zoom.FitWidth);
                        break;
                    case "높이F":
                        ZoomImage(Zoom.FitHeight);
                        break;
                    case "중심점 확대":
                        CancelTask();
                        btnFinishObject.Visible = true;
                        SetCursor(new Cursor(Properties.Resources.zoomin.Handle));
                        ws.nowPicStatus = PicStatus.ZoomWithCenter;
                        ShowStatus("확대 중심점을 선택해 주세요.");
                        pm.Invalidate();
                        break;
                    case "확대":
                        ZoomImage(Zoom.Bigger);
                        break;
                    case "축소":
                        ZoomImage(Zoom.Smaller);
                        break;
                    case "다시실행":
                        ExecuteUndo(false);
                        break;
                    case "되돌리기":
                        ExecuteUndo(true);
                        break;

                    #endregion

                    #region 이미지
                    case "회전하기":
                        RotateObjectStart();
                        break;

                    case "파일열기":
                        if (openFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            LoadImage(openFileDialog.FileName, true);
                        }
                        break;

                    case "저장":
                        SaveImage("", false);
                        break;

                    case "파일저장":
                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            SaveImage(saveFileDialog.FileName, true);
                        }
                        break;

                    case "90회전":
                        RotateFlipImage(RotateFlipType.Rotate90FlipNone);
                        AddUndoList(tag.ToString(), true);
                        break;

                    case "-90회전":
                        RotateFlipImage(RotateFlipType.Rotate270FlipNone);
                        AddUndoList(tag.ToString(), true);
                        break;

                    case "좌우반전":
                        RotateFlipImage(RotateFlipType.RotateNoneFlipX);
                        AddUndoList(tag.ToString(), true);
                        break;

                    case "상하반전":
                        RotateFlipImage(RotateFlipType.RotateNoneFlipY);
                        AddUndoList(tag.ToString(), true);
                        break;

                    case "변경전배경색":
                        ShowStatus("이미지에서 지우고 싶은 색상을 클릭하세요.", true);
                        ws.nowPicStatus = PicStatus.BGSelect;
                        SetCursor(Cursors.Cross);
                        break;

                    case "변경후배경색":
                        colorDialog.FullOpen = true;
                        colorDialog.Color = btnAfterBGColor.BackColor;
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            ws.bgColorAfter = colorDialog.Color;
                            btnAfterBGColor.BackColor = colorDialog.Color;
                        }
                        break;

                    case "수동배경제거":
                        RemoveBG(false);
                        AddUndoList(tag.ToString(), true);
                        break;

                    case "자동배경제거":
                        RemoveBG(true);
                        AddUndoList(tag.ToString(), true);
                        break;

                    case "원본":
                        LoadImage(ws.imageFileFullname, false);
                        break;

                    case "단위수정":
                        ChangeUnit();
                        break;

                    #endregion 이미지

                    #region 격자
                    case "검체테두리보기":
                        createEdge();
                        break;

                    case "자르기":
                        ShowStatus("자를 영역을 선택하세요.", true);
                        ws.nowDrawingObjectType = DrawingObjectType.ObjCrop;
                        ws.nowPicStatus = PicStatus.Start;
                        SetCursor(Cursors.Cross);
                        pm.Invalidate();
                        break;
                    case "셀선택":
                        if (ws.listGrids.Count == 0)
                        {
                            Util.ShowConfirm("격자를 먼저 생성하여야 합니다.");
                            return;
                        }
                        if (ws.listGrids.Count == 1 && ws.listGrids[0].GridRect.Size == ws.paperSize)
                        {
                            Util.ShowConfirm("격자가 전체모드일 경우는 셀을 선택할 수 없습니다.");
                            return;
                        }
                        _selGrid = null;
                        _selCell = null;
                        ShowStatus("셀을 선택하세요.", true);
                        ws.nowDrawingObjectType = DrawingObjectType.Cell;
                        ws.nowPicStatus = PicStatus.Select;
                        SetCursor(Cursors.Cross);
                        pm.Invalidate();
                        break;

                    case "가운데정렬":
                        //ChangeAutoCm();
                        SetAlignCenter();
                        AddUndoList(tag.ToString(), false);
                        break;
                    case "마커":
                        isMarking = true;
                        MarkerDraw();
                        break;
                    case "마커지우기":
                        isMarking = false;
                        MarkerDraw();
                        break;
                    case "마커모두지우기":
                        deleteMarker();
                        break;
                    case "격자생성":
                        createGrid();
                        break;
                    case "격자선택":
                        GridSelect();
                        break;
                    case "격자삭제":
                        GridDelete();
                        break;
                    case "검체이동":
                        MoveInstpectedObject();
                        break;
                    case "마커색":
                        colorDialog.FullOpen = true;
                        colorDialog.Color = this.btnMarkerColor.BackColor;
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            btnMarkerColor.BackColor = colorDialog.Color;
                            ws.markerColor = Color.FromArgb(trbMarker.Value, colorDialog.Color);
                            pm.Invalidate();
                        }
                        break;
                    case "그리드선색변경":
                        colorDialog.FullOpen = true;
                        colorDialog.Color = this.btnGridColor.BackColor;
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            btnGridColor.BackColor = colorDialog.Color;
                            if (_selGrid != null) _selGrid.setDesign(int.Parse(tbxGridThick.Text), int.Parse(tbxGridVThick.Text), btnGridColor.BackColor);
                            pm.Invalidate();
                        }
                        break;
                    case "그리드두께증가":
                        _intv = Util.CheckInt(tbxGridThick.Text);
                        if (_intv >= 0)
                        {
                            _intv += 1;
                            tbxGridThick.Text = _intv.ToString();
                            if (_selGrid != null) _selGrid.setDesign(int.Parse(tbxGridThick.Text), int.Parse(tbxGridVThick.Text), btnGridColor.BackColor);
                            pm.Invalidate();
                        }
                        break;
                    case "그리드두께감소":
                        _intv = Util.CheckInt(tbxGridThick.Text);
                        if (_intv >= 1)
                        {
                            _intv -= 1;
                            tbxGridThick.Text = _intv.ToString();
                            if (_selGrid != null) _selGrid.setDesign(int.Parse(tbxGridThick.Text), int.Parse(tbxGridVThick.Text), btnGridColor.BackColor);
                            pm.Invalidate();
                        }
                        break;
                    case "그리드세로두께증가":
                        _intv = Util.CheckInt(tbxGridVThick.Text);
                        if (_intv >= 0)
                        {
                            _intv += 1;
                            tbxGridVThick.Text = _intv.ToString();
                            if (_selGrid != null) _selGrid.setDesign(int.Parse(tbxGridThick.Text), int.Parse(tbxGridVThick.Text), btnGridColor.BackColor);
                            pm.Invalidate();
                        }
                        break;
                    case "그리드세로두께감소":
                        _intv = Util.CheckInt(tbxGridVThick.Text);
                        if (_intv >= 1)
                        {
                            _intv -= 1;
                            tbxGridVThick.Text = _intv.ToString();
                            if (_selGrid != null) _selGrid.setDesign(int.Parse(tbxGridThick.Text), int.Parse(tbxGridVThick.Text), btnGridColor.BackColor);
                            pm.Invalidate();
                        }
                        break;

                    #endregion

                    #region 삽입
                    case "전체삭제":
                        DeleteObjectAll();
                        AddUndoList(tag.ToString(), false);
                        break;
                    case "삭제":
                        DeleteObject();
                        AddUndoList(tag.ToString(), false);
                        break;
                    case "완료":
                        FinishTask();
                        break;
                    case "직선":
                        btnFinishObject.Visible = true;
                        LineStart();
                        break;

                    case "자유선":
                        FreeStart();
                        break;

                    case "직선두께증가":
                        _intv = Util.CheckInt(tbxLineThick.Text);
                        if (_intv >= 0)
                        {
                            _intv += 1;
                            tbxLineThick.Text = _intv.ToString();
                            if (ws.no != null && (ws.no.oType == DrawingObjectType.Line || ws.no.oType == DrawingObjectType.Free || ws.no.oType == DrawingObjectType.Ruler))
                            {
                                ws.no.lineThickness = _intv;
                                pm.Invalidate();
                                AddUndoList(tag.ToString(), false);
                            }
                        }
                        break;

                    case "직선두께감소":
                        _intv = Util.CheckInt(tbxLineThick.Text);
                        if (_intv >= 1)
                        {
                            _intv -= 1;
                            tbxLineThick.Text = _intv.ToString();
                            if (ws.no != null && (ws.no.oType == DrawingObjectType.Line || ws.no.oType == DrawingObjectType.Free || ws.no.oType == DrawingObjectType.Ruler))
                            {
                                ws.no.lineThickness = _intv;
                                pm.Invalidate();
                                AddUndoList(tag.ToString(), false);
                            }
                        }
                        break;

                    case "직선색변경":
                        colorDialog.FullOpen = true;
                        colorDialog.Color = this.btnLineColor.BackColor;
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            btnLineColor.BackColor = colorDialog.Color;
                            if (ws.no != null && (ws.no.oType == DrawingObjectType.Line || ws.no.oType == DrawingObjectType.Free || ws.no.oType == DrawingObjectType.Ruler))
                            {
                                ws.no.lineColor = colorDialog.Color;
                                pm.Invalidate();
                                AddUndoList(tag.ToString(), false);
                            }
                        }
                        break;

                    case "다각형":
                        PolyStart();
                        //test();
                        break;

                    case "삼각형":
                        TriStart();
                        break;

                    case "사각형":
                        RectStartTest();
                        //RectStart();
                        break;

                    case "원":
                        CircleStart();
                        break;

                    case "다각형두께증가":
                        _intv = Util.CheckInt(tbxPolyThick.Text);
                        if (_intv >= 0)
                        {
                            _intv += 1;
                            tbxPolyThick.Text = _intv.ToString();
                            if (ws.no != null && (ws.no.oType == DrawingObjectType.Rect || ws.no.oType == DrawingObjectType.Circle || ws.no.oType == DrawingObjectType.Triangle || ws.no.oType == DrawingObjectType.Polygon))
                            {
                                ws.no.lineThickness = _intv;
                                pm.Invalidate();
                                AddUndoList(tag.ToString(), false);
                            }
                        }
                        break;

                    case "다각형두께감소":
                        _intv = Util.CheckInt(tbxPolyThick.Text);
                        if (_intv >= 1)
                        {
                            _intv -= 1;
                            tbxPolyThick.Text = _intv.ToString();
                            if (ws.no != null && (ws.no.oType == DrawingObjectType.Rect || ws.no.oType == DrawingObjectType.Circle || ws.no.oType == DrawingObjectType.Triangle || ws.no.oType == DrawingObjectType.Polygon))
                            {
                                ws.no.lineThickness = _intv;
                                pm.Invalidate();
                                AddUndoList(tag.ToString(), false);
                            }
                        }
                        break;
                    case "다각형선색변경":
                        colorDialog.FullOpen = true;
                        colorDialog.Color = this.btnPolyLineColor.BackColor;
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            btnPolyLineColor.BackColor = colorDialog.Color;
                            if (ws.no != null && (ws.no.oType == DrawingObjectType.Rect || ws.no.oType == DrawingObjectType.Circle || ws.no.oType == DrawingObjectType.Triangle || ws.no.oType == DrawingObjectType.Polygon))
                            {
                                ws.no.lineColor = colorDialog.Color;
                                pm.Invalidate();
                                AddUndoList(tag.ToString(), false);
                            }
                        }
                        break;

                    case "다각형면색변경":
                        colorDialog.FullOpen = true;
                        colorDialog.Color = this.btnPolyFaceColor.BackColor;
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            btnPolyFaceColor.BackColor = colorDialog.Color;
                            if (ws.no != null && (ws.no.oType == DrawingObjectType.Rect || ws.no.oType == DrawingObjectType.Circle || ws.no.oType == DrawingObjectType.Triangle || ws.no.oType == DrawingObjectType.Polygon))
                            {
                                ws.no.faceColor = colorDialog.Color;
                                pm.Invalidate();
                                AddUndoList(tag.ToString(), false);
                            }
                        }
                        break;

                    case "문자":
                        TextStart();
                        break;

                    case "줄자":
                        btnFinishObject.Visible = true;
                        RulerStart();
                        break;

                    case "문자크기증가":
                        _intv = Util.CheckInt(tbxFontsize.Text);
                        if (_intv >= 0)
                        {
                            _intv += 1;
                            tbxFontsize.Text = _intv.ToString();
                            if (ws.no != null && (ws.no.oType == DrawingObjectType.Text || ws.no.oType == DrawingObjectType.Ruler))
                            {
                                ws.no.font = new Font(ws.no.font.FontFamily, _intv, ws.no.font.Style);
                                UpdateTextRect();

                                AddUndoList(tag.ToString(), false);
                            }
                        }
                        break;

                    case "문자크기감소":
                        _intv = Util.CheckInt(tbxFontsize.Text);
                        if (_intv >= 2)
                        {
                            _intv -= 1;
                            tbxFontsize.Text = _intv.ToString();
                            if (ws.no != null && (ws.no.oType == DrawingObjectType.Text || ws.no.oType == DrawingObjectType.Ruler))
                            {
                                ws.no.font = new Font(ws.no.font.FontFamily, _intv, ws.no.font.Style);
                                UpdateTextRect();
                                AddUndoList(tag.ToString(), false);
                            }
                        }
                        break;

                    case "문자폰트":
                        fontDialog.Font = new Font(btnFont.Font.FontFamily, int.Parse(this.tbxFontsize.Text), btnFont.Font.Style);
                        if (fontDialog.ShowDialog() == DialogResult.OK)
                        {
                            this.btnFont.Font = new Font(fontDialog.Font.FontFamily, 10, fontDialog.Font.Style);
                            this.btnFont.Text = fontDialog.Font.FontFamily.Name;
                            this.tbxFontsize.Text = Math.Round(fontDialog.Font.Size, 0).ToString();
                            if (ws.no != null && (ws.no.oType == DrawingObjectType.Text || ws.no.oType == DrawingObjectType.Ruler))
                            {
                                ws.no.font = fontDialog.Font;
                                UpdateTextRect();
                                AddUndoList(tag.ToString(), false);
                            }
                        }
                        break;

                    case "문자색":
                        colorDialog.FullOpen = true;
                        colorDialog.Color = this.btnFontColor.BackColor;
                        if (colorDialog.ShowDialog() == DialogResult.OK)
                        {
                            btnFontColor.BackColor = colorDialog.Color;
                            if (ws.no != null && (ws.no.oType == DrawingObjectType.Text || ws.no.oType == DrawingObjectType.Ruler))
                            {
                                ws.no.lineColor = colorDialog.Color;
                                UpdateTextRect();
                                AddUndoList(tag.ToString(), false);
                            }
                        }
                        break;

                    #endregion 삽입

                    #region 정렬
                    case "앞으로":
                        MoveLayer(1);
                        AddUndoList(tag.ToString(), false);
                        break;
                    case "뒤로":
                        MoveLayer(-1);
                        AddUndoList(tag.ToString(), false);
                        break;
                    case "맨 앞으로":
                        MoveLayer(9);
                        AddUndoList(tag.ToString(), false);
                        break;
                    case "맨 뒤로":
                        MoveLayer(-9);
                        AddUndoList(tag.ToString(), false);
                        break;
                    #endregion

                    default:
                        Util.ShowConfirm("[" + tag.ToString() + "] 명령이 없습니다. 관리자에게 문의하세요.");
                        break;
                }
                Debug.WriteLine("명령 태그 " + tag.ToString());
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //명령 라우터 - 체크 태그 활용
        private void eCheck_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                string tag = "";
                bool isChecked = false;
                if (sender is Sedas.Control.HCheckEdit)
                {
                    Sedas.Control.HCheckEdit checkEdit = (sender as Sedas.Control.HCheckEdit);
                    tag = checkEdit.Tag.ToString();
                    isChecked = checkEdit.Checked;
                }
                else
                {
                    CheckBox checkBox = (sender as CheckBox);
                    tag = checkBox.Tag.ToString();
                    isChecked = checkBox.Checked;
                }
                //CheckBox button = (CheckBox)sender;
                switch (tag)
                {
                    case "격자보기":
                        ws.isGridShow = this.chkShowGrid.Checked;
                        if (ws.listGrids.Count == 0)
                        {
                            rdoPaperA4.Checked = true;
                            rdoAll.Checked = true;
                            _ChangePaper();
                            createGrid();
                        }
                        pm.Invalidate();

                        if (ws.isGridShow == true)
                        {
                            this.ChangeAutoCm();
                        }
                        
                        break;

                    case "투명":
                        if (ws.no != null && (ws.no.oType == DrawingObjectType.Rect || ws.no.oType == DrawingObjectType.Circle || ws.no.oType == DrawingObjectType.Triangle || ws.no.oType == DrawingObjectType.Polygon))
                        {
                            ws.no.isTransparent = isChecked;
                            pm.Invalidate();
                            AddUndoList(tag.ToString(), false);
                        }
                        break;
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //명령 라우터 - 라디오 태그 활용
        private void eRadio_CheckedChanged(object sender, EventArgs e)
        {
            if (this.isLoading == true) return;

            try
            {
                string tag = "";
                bool isChecked = false;
                if (sender is Sedas.Control.HCheckEdit)
                {
                    Sedas.Control.HCheckEdit checkEdit = (sender as Sedas.Control.HCheckEdit);
                    tag = checkEdit.Tag.ToString();
                    isChecked = checkEdit.Checked;

                }
                else
                {
                    RadioButton btn = (RadioButton)sender;
                    tag = btn.Tag.ToString();
                    isChecked = btn.Checked;
                }


                if (!isChecked) return;
                switch (tag)
                {
                    case "A3":
                    case "A4":
                    case "B4":
                    case "B5":
                    case "Source":
                        _ChangePaper();
                        pm.Invalidate();
                        break;
                    case "전체":
                    case "일부":
                        createGrid();
                        pm.Invalidate();
                        break;
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //메인폼 키다운 이벤트
        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (!(this.ActiveControl is TextBox))
                {
                    if (e.KeyCode == Keys.Escape)
                    {
                        FinishTask();
                    }
                    else if (e.KeyCode == Keys.Z && e.Control)
                    {
                        ExecuteUndo(true);
                    }
                    else if (e.KeyCode == Keys.Y && e.Control)
                    {
                        ExecuteUndo(false);
                    }
                    else if (e.KeyCode == Keys.Delete)
                    {
                        if (pm.Image == null)
                        {
                            return;
                        }
                        if (ws.nowTab == 1 && _selGrid != null) GridDelete();
                        else if (ws.nowTab == 2 && ws.no != null) DeleteObject();
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        #endregion TabMain & Action Button & KeyDown

        #region Paint Event - PictureBoxMain
        /*
         * 상황에 따른 페인트 - 중요
         * 주로 DrawingObjectType, PicStatus 의 조합으로 현재 사용자 환경을 인지
         * Down / Move-drag 여부 확인 / Up 순으로 명령확인
         * 각 상황에 맞는 Paint
         */
        private void PictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (pm.Image == null) return;
                if (e.Button == MouseButtons.Right)
                {
                    FinishTask();
                    return;
                }
                float zf = (float)(1.0 * pm.ClientSize.Width / pm.Image.Width);
                PointF _pnt = new PointF(e.X / zf, e.Y / zf);
                DrawingObject _obj;
                RectangleF _rect;
                _selGizmo = Gizmo.None;
                if (ws.no != null)
                    Debug.WriteLine("Before Down ws.no = " + ws.no.oType.ToString() + ", nowPicStatus = " + ws.nowPicStatus.ToString());
                else
                    Debug.WriteLine("Before Down nowDrawingObjectType = " + ws.nowDrawingObjectType.ToString() + ", nowPicStatus = " + ws.nowPicStatus.ToString());
                if (ws.nowTab == 0)
                {
                    if (ws.nowDrawingObjectType == DrawingObjectType.ObjRotate)
                    {
                        if (CreateRectSizableNode(ws.listDragPoint[1].X, ws.listDragPoint[1].Y, 1 / zf).Contains(_pnt))
                        {
                            _selGizmo = Gizmo.Drag;
                            _drag = true;
                            _dragStart = _pnt;
                            return;
                        }
                    }
                    else if (ws.nowDrawingObjectType == DrawingObjectType.ObjCrop)
                    {

                        if (ws.nowPicStatus == PicStatus.Start)
                        {
                            _drag = true;
                            _dragStart = _pnt;
                            ws.objCropRect = new RectangleF(_dragStart.X, _dragStart.Y, 0, 0);
                            ws.nowPicStatus = PicStatus.End;
                        }
                        else if (ws.objCropRect.Width > 0)
                        {
                            ws.nowPicStatus = PicStatus.Select;
                            if (GetGizmoRect(ws.objCropRect, Gizmo.LeftUp, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.LeftUp;
                            else if (GetGizmoRect(ws.objCropRect, Gizmo.LeftBottom, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.LeftBottom;
                            else if (GetGizmoRect(ws.objCropRect, Gizmo.RightUp, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.RightUp;
                            else if (GetGizmoRect(ws.objCropRect, Gizmo.RightBottom, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.RightBottom;
                            else if (ws.objCropRect.Contains(_pnt)) _selGizmo = Gizmo.Drag;
                            if (_selGizmo != Gizmo.None)
                            {
                                SetCursor(Cursors.Cross);
                                _drag = true;
                                _dragStart = _pnt;
                                return;
                            }
                        }
                    }
                }
                else if (ws.nowTab == 1)//격자
                {
                    if (ws.nowDrawingObjectType == DrawingObjectType.Grid)
                    {
                        if (ws.nowPicStatus == PicStatus.Start && _selGrid != null)
                        {
                            _drag = true;
                            _dragStart = _pnt;
                            _selGrid.GridRect = new RectangleF(_dragStart.X, _dragStart.Y, 0, 0);
                            ws.nowPicStatus = PicStatus.End;
                        }
                        else if (ws.nowPicStatus == PicStatus.Select)
                        {
                            if (_selGrid != null)
                            {
                                if (_selGrid.GridRect.Size != ws.paperSize) // 전체 격자인 경우는 크기 조절 안함
                                {
                                    if (GetGizmoRect(_selGrid.GridRect, Gizmo.LeftUp, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.LeftUp;
                                    else if (GetGizmoRect(_selGrid.GridRect, Gizmo.LeftBottom, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.LeftBottom;
                                    else if (GetGizmoRect(_selGrid.GridRect, Gizmo.RightUp, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.RightUp;
                                    else if (GetGizmoRect(_selGrid.GridRect, Gizmo.RightBottom, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.RightBottom;
                                    else if (_selGrid.GridRect.Contains(_pnt)) _selGizmo = Gizmo.Drag;
                                    if (_selGizmo != Gizmo.None)
                                    {
                                        SetCursor(Cursors.Cross);
                                        _drag = true;
                                        _dragStart = _pnt;
                                        return;
                                    }
                                }
                            }
                            if (_selGizmo == Gizmo.None)
                            {
                                for (int i = ws.listGrids.Count - 1; i >= 0; i--)
                                {
                                    var item = ws.listGrids[i];
                                    if (item.GridRect.Contains(_pnt))
                                    {
                                        _selGrid = item;
                                        pm.Invalidate();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else if (ws.nowDrawingObjectType == DrawingObjectType.Cell)
                    {
                        if (_selCell != null && _selGrid != null)
                        {
                            _rect = _selGrid.getCellRect(_selCell);
                            if (GetGizmoRect(_rect, Gizmo.LeftMiddle, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.LeftMiddle;
                            else if (GetGizmoRect(_rect, Gizmo.RightMiddle, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.RightMiddle;
                            else if (GetGizmoRect(_rect, Gizmo.UpMiddle, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.UpMiddle;
                            else if (GetGizmoRect(_rect, Gizmo.BottomMiddle, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.BottomMiddle;
                            if (_selGizmo != Gizmo.None)
                            {
                                _drag = true;
                                _dragStart = _pnt;
                                pm.Invalidate();
                            }
                        }
                        if (_selGizmo == Gizmo.None)
                        {
                            for (int i = ws.listGrids.Count - 1; i >= 0; i--)
                            {
                                var item = ws.listGrids[i];
                                if (item.GridRect.Size != ws.paperSize) // 전체 격자 제외
                                {
                                    if (item.GridRect.Contains(_pnt))
                                    {
                                        _selGrid = item;
                                        _selCell = _selGrid.getCell(_pnt);
                                        pm.Invalidate();
                                        break;
                                    }
                                }
                            }
                        }
                    }
                    else if (ws.nowPicStatus == PicStatus.InspectObj)
                    {
                        if (ws.objRect.Contains(_pnt)) _selGizmo = Gizmo.Drag;
                        if (_selGizmo != Gizmo.None)
                        {
                            SetCursor(Cursors.Cross);
                            _drag = true;
                            _dragStart = _pnt;
                            return;
                        }
                    }
                    else if (ws.nowDrawingObjectType == DrawingObjectType.Marker)
                    {
                        for (int i = ws.listGrids.Count - 1; i >= 0; i--)
                        {
                            var item = ws.listGrids[i];
                            if (item.GridRect.Contains(_pnt))
                            {
                                _selGizmo = Gizmo.Drag;
                                SetCursor(Cursors.IBeam);
                                _drag = true;
                                _dragStart = _pnt;
                                return;
                            }
                        }
                    }
                }
                else if (ws.nowTab == 2)
                {
                    if (ws.nowPicStatus == PicStatus.None || ws.nowPicStatus == PicStatus.Select) // 생성작업이 아닐때
                    {
                        //먼저 선택된 요소부터 확인하고 해당되면 넘김
                        if (ws.no != null && ws.nowPicStatus == PicStatus.Select)
                        {
                            if (ws.no.oType == DrawingObjectType.Line || ws.no.oType == DrawingObjectType.Ruler)
                            {
                                if (CreateRectSizableNode(ws.no.listPoint[0].X, ws.no.listPoint[0].Y, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.LeftUp;
                                else if (CreateRectSizableNode(ws.no.listPoint[1].X, ws.no.listPoint[1].Y, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.RightUp;
                                else if (Util.IsPointInPolygon(ws.no.listLineGrapPoint.ToArray(), _pnt)) _selGizmo = Gizmo.Drag;
                                if (_selGizmo != Gizmo.None)
                                {
                                    SetCursor(Cursors.Cross);
                                    _drag = true;
                                    _dragStart = _pnt;
                                    return;
                                }
                            }
                            else if (ws.no.oType == DrawingObjectType.Text)
                            {
                                RectangleF _objRect = new RectangleF(ws.no.rect.X * zf - TEXT_BOX_MARGIN[0], ws.no.rect.Y * zf - TEXT_BOX_MARGIN[1]
                                    , ws.no.rect.Width * zf + TEXT_BOX_MARGIN[2], ws.no.rect.Height * zf + TEXT_BOX_MARGIN[3]);
                                RectangleF _objText = new RectangleF(ws.no.rect.X * zf, ws.no.rect.Y * zf
                                    , ws.no.rect.Width * zf, ws.no.rect.Height * zf);
                                if (_objText.Contains(e.Location))
                                {
                                    tbxInput.Text = ws.no.text;
                                    Font _font = new Font(ws.no.font.FontFamily, (int)(ws.no.font.Size * zf * ws.ZOOM_FACTOR), ws.no.font.Style);
                                    tbxInput.Font = _font;
                                    tbxInput.ForeColor = ws.no.lineColor;
                                    tbxInput.Location = new Point((int)_objRect.X + pm.Location.X, (int)_objRect.Y + pm.Location.Y);
                                    tbxInput.Size = new Size((int)_objRect.Width, (int)_objRect.Height);
                                    tbxInput.Visible = true;
                                    tbxInput.Focus();
                                    btnFinishObject.Visible = true;
                                    SetCursor(Cursors.Default);
                                    ws.nowPicStatus = PicStatus.End;
                                    return;
                                }
                                else if (_objRect.Contains(e.Location))
                                {
                                    SetCursor(Cursors.Cross);
                                    _drag = true;
                                    _dragStart = _pnt;
                                    return;
                                }
                            }
                            else if (ws.no.oType == DrawingObjectType.Free)
                            {
                                if (ws.no.rect.Contains(_pnt)) _selGizmo = Gizmo.Drag;
                                if (_selGizmo != Gizmo.None)
                                {
                                    SetCursor(Cursors.Cross);
                                    _drag = true;
                                    _dragStart = _pnt;
                                    return;
                                }
                            }
                            else if (ws.no.oType == DrawingObjectType.Triangle || ws.no.oType == DrawingObjectType.Polygon)
                            {
                                _selPolyIndex = -1;
                                _selGizmo = Gizmo.None;
                                for (int i = 0; i < ws.no.listPoint.Count; i++)
                                {
                                    if (CreateRectSizableNode(ws.no.listPoint[i].X, ws.no.listPoint[i].Y, 1 / zf).Contains(_pnt))
                                    {
                                        _selPolyIndex = i;
                                        _selGizmo = Gizmo.LeftUp;
                                        break;
                                    }
                                }
                                if (_selPolyIndex == -1)
                                {
                                    if (Util.IsPointInPolygon(ws.no.listPoint.ToArray(), _pnt)) _selGizmo = Gizmo.Drag;
                                }
                                if (_selGizmo != Gizmo.None)
                                {
                                    SetCursor(Cursors.Cross);
                                    _drag = true;
                                    _dragStart = _pnt;
                                    return;
                                }
                            }
                            else if (ws.no.oType == DrawingObjectType.Circle || ws.no.oType == DrawingObjectType.Rect)
                            {
                                if (GetGizmoRect(ws.no.rect, Gizmo.LeftUp, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.LeftUp;
                                else if (GetGizmoRect(ws.no.rect, Gizmo.LeftBottom, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.LeftBottom;
                                else if (GetGizmoRect(ws.no.rect, Gizmo.RightUp, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.RightUp;
                                else if (GetGizmoRect(ws.no.rect, Gizmo.RightBottom, 1 / zf).Contains(_pnt)) _selGizmo = Gizmo.RightBottom;
                                else if (ws.no.rect.Contains(_pnt)) _selGizmo = Gizmo.Drag;
                                if (_selGizmo != Gizmo.None)
                                {
                                    SetCursor(Cursors.Cross);
                                    _drag = true;
                                    _dragStart = _pnt;
                                    return;
                                }
                            }
                        }
                        // 다른 선택요소가 있는지 확인
                        _obj = ws.getFocusedObject(_pnt, zf);
                        if (_obj != null)
                        {
                            if (!_obj.isSelect) // 선택된 개체에서 진행할때는 다음으로 넘김
                            {
                                ws.SetNowObject(_obj, PicStatus.Select);
                                pm.Invalidate();
                                return;
                            }
                        }
                    }
                    else if (ws.nowPicStatus == PicStatus.End)
                    {
                        //PASS
                    }
                    else if (ws.no != null)// 생성 시작
                    {
                        if (ws.no.oType == DrawingObjectType.Line || ws.no.oType == DrawingObjectType.Ruler)
                        {
                            if (ws.nowPicStatus == PicStatus.Start)
                            {
                                _drag = true;
                                _dragStart = _pnt;
                                ws.no.listPoint.Add(_dragStart);
                                ws.no.listPoint.Add(_dragStart);
                                ws.nowPicStatus = PicStatus.End;
                            }
                        }
                        else if (ws.no.oType == DrawingObjectType.Free)
                        {
                            if (ws.nowPicStatus == PicStatus.Start)
                            {
                                _drag = true;
                                _dragStart = _pnt;
                                ws.no.listFreePoint.Add(new List<PointF>());
                                ws.no.listFreePoint.Last().Add(_dragStart);
                                ws.nowPicStatus = PicStatus.End;
                            }
                        }
                        else if (ws.no.oType == DrawingObjectType.Text)
                        {
                            if (ws.nowPicStatus == PicStatus.Start)
                            {
                                tbxInput.Text = "";
                                Font _font = new Font(ws.no.font.FontFamily, (int)(ws.no.font.Size * zf * ws.ZOOM_FACTOR), ws.no.font.Style);
                                tbxInput.Font = _font;
                                tbxInput.ForeColor = ws.no.lineColor;
                                tbxInput.Location = new Point(e.Location.X + pm.Location.X, e.Location.Y + pm.Location.Y);
                                tbxInput.Size = UpdateTextSize("   ", _font);
                                tbxInput.Visible = true;
                                tbxInput.Focus();
                                SetCursor(Cursors.Default);
                                ws.nowPicStatus = PicStatus.End;
                            }
                        }
                        else if (ws.no.oType == DrawingObjectType.Rect)
                        {
                            if (ws.nowPicStatus == PicStatus.Start)
                            {
                                _drag = true;
                                _dragStart = _pnt;
                                ws.no.listPoint.Add(_dragStart);
                                ws.no.listPoint.Add(_dragStart);
                                ws.nowPicStatus = PicStatus.End;
                            }
                        }
                        else if (ws.no.oType == DrawingObjectType.Circle)
                        {
                            if (ws.nowPicStatus == PicStatus.Start)
                            {
                                _drag = true;
                                _dragStart = _pnt;
                                ws.no.listPoint.Add(_dragStart);
                                ws.no.listPoint.Add(_dragStart);
                                ws.nowPicStatus = PicStatus.End;
                            }
                        }
                    }

                }
                if (_selGizmo == Gizmo.None && ws.no == null && ws.nowPicStatus == PicStatus.None && ws.nowDrawingObjectType == DrawingObjectType.None)
                {
                    _drag = true;
                    _dragStart = e.Location;
                    ws.nowPicStatus = PicStatus.PaperDrag;
                }
                else if (ws.nowPicStatus == PicStatus.ZoomWithCenter)
                {
                    ZoomImageWithCenterPoint(_pnt);
                    return;
                }
                if (ws.no != null)
                    Debug.WriteLine("Down ws.no = " + ws.no.oType.ToString() + ", nowPicStatus = " + ws.nowPicStatus.ToString());
                else
                    Debug.WriteLine("Down nowDrawingObjectType = " + ws.nowDrawingObjectType.ToString() + ", nowPicStatus = " + ws.nowPicStatus.ToString());

            }
            catch (Exception ex)
            {
                Debug.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name + " || " + ex.ToString());
            }
        }

        private void PictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                if (pm.Image == null) return;
                if (e.Button == MouseButtons.Right)
                {
                    FinishTask();
                    return;
                }
                float zf = (float)(1.0 * pm.ClientSize.Width / pm.Image.Width);
                List<PointF> pnts;
                float _len, _factor;
                int _r, _c, x, y;
                Cell _cell_start, _cell_end;
                PointF _pnt = new PointF(e.X / zf, e.Y / zf);
                if (_drag)
                {
                    if (ws.nowPicStatus == PicStatus.PaperDrag)
                    {
                        x = pm.Location.X + (int)(e.X - _dragStart.X);
                        if (x > 0) x = 0;
                        else if (x < PanelView.Width - pm.Width + 1) x = PanelView.Width - pm.Width + 1;
                        y = pm.Location.Y + (int)(e.Y - _dragStart.Y);
                        if (y > 0) y = 0;
                        else if (y < PanelView.Height - pm.Height + 1) y = PanelView.Height - pm.Height + 1;

                        if (PanelView.HorizontalScroll.Visible && PanelView.VerticalScroll.Visible)
                        {
                            pm.Location = new Point(x, y);
                        }
                        else if (PanelView.HorizontalScroll.Visible)
                        {
                            pm.Location = new Point(x, pm.Location.Y);
                        }
                        else if (PanelView.VerticalScroll.Visible)
                        {
                            pm.Location = new Point(pm.Location.X, y);
                        }
                        else
                        {
                            _drag = false;
                        }

                        //pm.Location = new Point(pm.Location.X + (int)(e.X - _dragStart.X), pm.Location.Y + (int)(e.Y - _dragStart.Y));
                        //Debug.WriteLine(pm.Location + "/" + pm.Size);
                    }
                    else if (ws.nowDrawingObjectType == DrawingObjectType.ObjCrop)
                    {

                        if (ws.nowPicStatus == PicStatus.End)
                        {
                            ws.objCropRect = new RectangleF(ws.objCropRect.X, ws.objCropRect.Y, _pnt.X - ws.objCropRect.X, _pnt.Y - ws.objCropRect.Y);
                        }
                        else if (ws.nowPicStatus == PicStatus.Select && _selGizmo != Gizmo.None)
                        {

                            if (_selGizmo == Gizmo.LeftUp)
                            {
                                ws.objCropRect = new RectangleF(_pnt.X, _pnt.Y
                                    , ws.objCropRect.Width - (_pnt.X - _dragStart.X), ws.objCropRect.Height - (+_pnt.Y - _dragStart.Y));
                            }
                            else if (_selGizmo == Gizmo.LeftBottom)
                            {
                                ws.objCropRect = new RectangleF(_pnt.X, ws.objCropRect.Y
                                    , ws.objCropRect.Width - (_pnt.X - _dragStart.X), ws.objCropRect.Height + (+_pnt.Y - _dragStart.Y));
                            }
                            else if (_selGizmo == Gizmo.RightUp)
                            {
                                ws.objCropRect = new RectangleF(ws.objCropRect.X, _pnt.Y
                                    , ws.objCropRect.Width + (_pnt.X - _dragStart.X), ws.objCropRect.Height - (+_pnt.Y - _dragStart.Y));
                            }
                            else if (_selGizmo == Gizmo.RightBottom)
                            {
                                ws.objCropRect = new RectangleF(ws.objCropRect.X, ws.objCropRect.Y
                                    , ws.objCropRect.Width + (_pnt.X - _dragStart.X), ws.objCropRect.Height + (+_pnt.Y - _dragStart.Y));
                            }
                            else if (_selGizmo == Gizmo.Drag)
                            {
                                ws.objCropRect = new RectangleF(ws.objCropRect.X + (_pnt.X - _dragStart.X), ws.objCropRect.Y + _pnt.Y - _dragStart.Y
                                    , ws.objCropRect.Width, ws.objCropRect.Height);
                            }
                            _dragStart = _pnt;
                        }
                    }
                    else if (ws.nowDrawingObjectType == DrawingObjectType.ObjRotate && _selGizmo == Gizmo.Drag)
                    {
                        ws.listDragPoint[1] = _pnt;
                    }
                    else if (ws.nowDrawingObjectType == DrawingObjectType.Grid && ws.listGrids.Count > 0)
                    {

                        if (ws.nowPicStatus == PicStatus.End && _selGrid != null)
                        {
                            _selGrid.changeGridRectInDrag(new RectangleF(_dragStart.X, _dragStart.Y, _pnt.X - _dragStart.X, _pnt.Y - _dragStart.Y));
                        }
                        else if (ws.nowPicStatus == PicStatus.Select && _selGizmo != Gizmo.None)
                        {
                            if (_selGizmo == Gizmo.LeftUp)
                            {
                                _selGrid.changeGridRect(new RectangleF(_pnt.X, _pnt.Y
                                    , _selGrid.GridRect.Width - (_pnt.X - _dragStart.X), _selGrid.GridRect.Height - (+_pnt.Y - _dragStart.Y)));
                            }
                            else if (_selGizmo == Gizmo.LeftBottom)
                            {
                                _selGrid.changeGridRect(new RectangleF(_pnt.X, _selGrid.GridRect.Y
                                    , _selGrid.GridRect.Width - (_pnt.X - _dragStart.X), _selGrid.GridRect.Height + (+_pnt.Y - _dragStart.Y)));
                            }
                            else if (_selGizmo == Gizmo.RightUp)
                            {
                                _selGrid.changeGridRect(new RectangleF(_selGrid.GridRect.X, _pnt.Y
                                    , _selGrid.GridRect.Width + (_pnt.X - _dragStart.X), _selGrid.GridRect.Height - (+_pnt.Y - _dragStart.Y)));
                            }
                            else if (_selGizmo == Gizmo.RightBottom)
                            {
                                _selGrid.changeGridRect(new RectangleF(_selGrid.GridRect.X, _selGrid.GridRect.Y
                                    , _selGrid.GridRect.Width + (_pnt.X - _dragStart.X), _selGrid.GridRect.Height + (+_pnt.Y - _dragStart.Y)));
                            }
                            else if (_selGizmo == Gizmo.Drag)
                            {
                                _selGrid.GridRect = new RectangleF(_selGrid.GridRect.X + (_pnt.X - _dragStart.X), _selGrid.GridRect.Y + _pnt.Y - _dragStart.Y
                                    , _selGrid.GridRect.Width, _selGrid.GridRect.Height);
                                _selGrid.SetAllCellXY();
                            }
                            _dragStart = _pnt;
                        }
                    }
                    else if (ws.nowDrawingObjectType == DrawingObjectType.Cell && ws.listGrids.Count > 0 && _selGrid != null)
                    {

                        if (ws.nowPicStatus == PicStatus.Select && _selGizmo != Gizmo.None && _selCell != null)
                        {
                            if (_selGizmo == Gizmo.UpMiddle || _selGizmo == Gizmo.BottomMiddle)
                            {
                                _selGrid.changeCellSize(_selCell, 0, (_pnt.Y - _dragStart.Y), _selGizmo);
                            }
                            else if (_selGizmo == Gizmo.LeftMiddle || _selGizmo == Gizmo.RightMiddle)
                            {
                                _selGrid.changeCellSize(_selCell, (_pnt.X - _dragStart.X), 0, _selGizmo);
                            }
                            _dragStart = _pnt;
                        }
                    }
                    else if (ws.nowPicStatus == PicStatus.InspectObj)
                    {
                        ws.objRect = new RectangleF(ws.objRect.X + (_pnt.X - _dragStart.X), ws.objRect.Y + _pnt.Y - _dragStart.Y
                            , ws.objRect.Width, ws.objRect.Height);
                        _dragStart = _pnt;
                    }
                    else if (ws.nowDrawingObjectType == DrawingObjectType.Marker && ws.listGrids.Count > 0)
                    {
                        if (!pm.ClientRectangle.Contains(e.Location))
                        {
                            _drag = false;
                            return;
                        }
                        for (int g = ws.listGrids.Count - 1; g >= 0; g--)
                        {
                            var item = ws.listGrids[g];
                            if (item.GridRect.Contains(_pnt) && item.GridRect.Contains(_dragStart))
                            {
                                _selGrid = item;
                                _cell_start = _selGrid.getCell(_dragStart);
                                _cell_end = _selGrid.getCell(_pnt);
                                if (_cell_start != null & _cell_end != null)
                                {
                                    //Y Draw
                                    if (Math.Abs(_cell_start.r - _cell_end.r) > Math.Abs(_cell_start.c - _cell_end.c))
                                    {
                                        for (int i = Math.Min(_cell_start.r, _cell_end.r); i <= Math.Max(_cell_start.r, _cell_end.r); i++)
                                        {
                                            _selGrid.setMarker(i, _cell_start.c, isMarking, ws.markerColor);
                                        }
                                    }
                                    else
                                    {
                                        for (int i = Math.Min(_cell_start.c, _cell_end.c); i <= Math.Max(_cell_start.c, _cell_end.c); i++)
                                        {
                                            _selGrid.setMarker(_cell_start.r, i, isMarking, ws.markerColor);
                                        }

                                    }
                                    break;
                                }
                            }
                        }
                        _dragStart = _pnt;
                    }
                    else if (ws.no == null)
                    {
                        //PASS
                    }
                    else if ((ws.no.oType == DrawingObjectType.Line || ws.no.oType == DrawingObjectType.Ruler) && ws.no.listPoint.Count == 2)
                    {
                        if (ws.nowPicStatus == PicStatus.End)
                        {
                            ws.no.listPoint[1] = new PointF(_pnt.X, _pnt.Y);
                        }
                        else if (ws.nowPicStatus == PicStatus.Select && _selGizmo != Gizmo.None)
                        {
                            if (_selGizmo == Gizmo.LeftUp)
                            {
                                ws.no.listPoint[0] = new PointF(ws.no.listPoint[0].X + _pnt.X - _dragStart.X, ws.no.listPoint[0].Y + _pnt.Y - _dragStart.Y);
                            }
                            else if (_selGizmo == Gizmo.RightUp)
                            {

                                ws.no.listPoint[1] = new PointF(ws.no.listPoint[1].X + _pnt.X - _dragStart.X, ws.no.listPoint[1].Y + _pnt.Y - _dragStart.Y);
                            }
                            else if (_selGizmo == Gizmo.Drag)
                            {
                                ws.no.listPoint[0] = new PointF(ws.no.listPoint[0].X + _pnt.X - _dragStart.X, ws.no.listPoint[0].Y + _pnt.Y - _dragStart.Y);
                                ws.no.listPoint[1] = new PointF(ws.no.listPoint[1].X + _pnt.X - _dragStart.X, ws.no.listPoint[1].Y + _pnt.Y - _dragStart.Y);
                            }
                            _dragStart = _pnt;

                        }
                        if (ws.no.oType == DrawingObjectType.Ruler)
                        {
                            pnts = ws.no.listPoint;
                            _len = (float)Math.Sqrt(Math.Pow(pnts[0].X - pnts[1].X, 2) + Math.Pow(pnts[0].Y - pnts[1].Y, 2));
                            List<PointF> _pnts = new List<PointF>();
                            _factor = 3;
                            _pnts.Add(new PointF(pnts[0].X, pnts[0].Y - ws.SIZE_NODE_RECT * _factor));
                            _pnts.Add(new PointF(pnts[0].X, pnts[0].Y + ws.SIZE_NODE_RECT * _factor));
                            _pnts.Add(new PointF(pnts[0].X + _len, pnts[0].Y + ws.SIZE_NODE_RECT * _factor));
                            _pnts.Add(new PointF(pnts[0].X + _len, pnts[0].Y - ws.SIZE_NODE_RECT * _factor));
                            double _angle = Math.Atan2(pnts[1].Y - pnts[0].Y, pnts[1].X - pnts[0].X);
                            for (int i = 0; i < _pnts.Count; i++)
                            {
                                _pnts[i] = Util.rotatePoint(_angle, _pnts[i], pnts[0]);
                            }
                            ws.no.listLineGrapPoint = _pnts;
                        }
                    }
                    else if (ws.no.oType == DrawingObjectType.Text)
                    {
                        if (ws.nowPicStatus == PicStatus.Select)
                        {
                            ws.no.rect = new RectangleF(ws.no.rect.X + (_pnt.X - _dragStart.X), ws.no.rect.Y + _pnt.Y - _dragStart.Y
                                , ws.no.rect.Width, ws.no.rect.Height);
                            _dragStart = _pnt;
                        }
                    }
                    else if (ws.no.oType == DrawingObjectType.Free && ws.no.listFreePoint.Count > 0)
                    {
                        if (ws.nowPicStatus == PicStatus.End)
                        {
                            ws.no.listFreePoint.Last().Add(_pnt);
                        }
                        else if (ws.nowPicStatus == PicStatus.Select)
                        {
                            for (int i = 0; i < ws.no.listFreePoint.Count; i++)
                            {
                                for (int j = 0; j < ws.no.listFreePoint[i].Count; j++)
                                {
                                    ws.no.listFreePoint[i][j] = new PointF(ws.no.listFreePoint[i][j].X + _pnt.X - _dragStart.X, ws.no.listFreePoint[i][j].Y + _pnt.Y - _dragStart.Y);
                                }
                            }
                            ws.no.rect = new RectangleF(ws.no.rect.X + _pnt.X - _dragStart.X, ws.no.rect.Y + _pnt.Y - _dragStart.Y
                                , ws.no.rect.Width, ws.no.rect.Height);
                            _dragStart = _pnt;
                        }
                    }
                    else if ((ws.no.oType == DrawingObjectType.Triangle || ws.no.oType == DrawingObjectType.Polygon) && ws.no.listPoint.Count >= 2)
                    {
                        if (ws.nowPicStatus == PicStatus.End)
                        {
                            ws.no.listPoint[ws.no.listPoint.Count - 1] = new PointF(_pnt.X, _pnt.Y);
                        }
                        else if (ws.nowPicStatus == PicStatus.Select && _selGizmo != Gizmo.None)
                        {
                            if (_selGizmo == Gizmo.LeftUp)
                            {
                                ws.no.listPoint[_selPolyIndex] = new PointF(ws.no.listPoint[_selPolyIndex].X + _pnt.X - _dragStart.X, ws.no.listPoint[_selPolyIndex].Y + _pnt.Y - _dragStart.Y);
                            }
                            else if (_selGizmo == Gizmo.Drag)
                            {
                                for (int i = 0; i < ws.no.listPoint.Count; i++)
                                {
                                    ws.no.listPoint[i] = new PointF(ws.no.listPoint[i].X + _pnt.X - _dragStart.X, ws.no.listPoint[i].Y + _pnt.Y - _dragStart.Y);
                                }
                            }
                            _dragStart = _pnt;

                        }
                    }
                    else if (ws.no.oType == DrawingObjectType.Rect && ws.no.listPoint.Count == 2)
                    {
                        if (ws.nowPicStatus == PicStatus.End)
                        {
                            ws.no.listPoint[1] = new PointF(_pnt.X, _pnt.Y);
                            pnts = ws.no.listPoint;
                            ws.no.rect = new RectangleF(
                                    Math.Min(pnts[0].X, pnts[1].X), Math.Min(pnts[0].Y, pnts[1].Y)
                                    , Math.Abs(pnts[0].X - pnts[1].X), Math.Abs(pnts[0].Y - pnts[1].Y)
                                    );
                        }
                        else if (ws.nowPicStatus == PicStatus.Select && _selGizmo != Gizmo.None)
                        {
                            if (_selGizmo == Gizmo.LeftUp)
                            {
                                ws.no.rect = new RectangleF(_pnt.X, _pnt.Y
                                    , ws.no.rect.Width - (_pnt.X - _dragStart.X), ws.no.rect.Height - (+_pnt.Y - _dragStart.Y));
                            }
                            else if (_selGizmo == Gizmo.LeftBottom)
                            {
                                ws.no.rect = new RectangleF(_pnt.X, ws.no.rect.Y
                                    , ws.no.rect.Width - (_pnt.X - _dragStart.X), ws.no.rect.Height + (+_pnt.Y - _dragStart.Y));
                            }
                            else if (_selGizmo == Gizmo.RightUp)
                            {
                                ws.no.rect = new RectangleF(ws.no.rect.X, _pnt.Y
                                    , ws.no.rect.Width + (_pnt.X - _dragStart.X), ws.no.rect.Height - (+_pnt.Y - _dragStart.Y));
                            }
                            else if (_selGizmo == Gizmo.RightBottom)
                            {
                                ws.no.rect = new RectangleF(ws.no.rect.X, ws.no.rect.Y
                                    , ws.no.rect.Width + (_pnt.X - _dragStart.X), ws.no.rect.Height + (+_pnt.Y - _dragStart.Y));
                            }
                            else if (_selGizmo == Gizmo.Drag)
                            {
                                ws.no.rect = new RectangleF(ws.no.rect.X + (_pnt.X - _dragStart.X), ws.no.rect.Y + _pnt.Y - _dragStart.Y
                                    , ws.no.rect.Width, ws.no.rect.Height);
                            }
                            _dragStart = _pnt;

                        }
                    }
                    else if (ws.no.oType == DrawingObjectType.Circle && ws.no.listPoint.Count == 2)
                    {
                        if (ws.nowPicStatus == PicStatus.End)
                        {
                            ws.no.listPoint[1] = new PointF(_pnt.X, _pnt.Y);
                            pnts = ws.no.listPoint;
                            ws.no.rect = new RectangleF(
                                  Math.Min(pnts[0].X, pnts[1].X), Math.Min(pnts[0].Y, pnts[1].Y)
                                  , Math.Abs(pnts[0].X - pnts[1].X), Math.Abs(pnts[0].Y - pnts[1].Y)
                                  );
                        }
                        else if (ws.nowPicStatus == PicStatus.Select && _selGizmo != Gizmo.None)
                        {
                            if (_selGizmo == Gizmo.LeftUp)
                            {
                                ws.no.rect = new RectangleF(_pnt.X, _pnt.Y
                                    , ws.no.rect.Width - (_pnt.X - _dragStart.X), ws.no.rect.Height - (+_pnt.Y - _dragStart.Y));
                            }
                            else if (_selGizmo == Gizmo.LeftBottom)
                            {
                                ws.no.rect = new RectangleF(_pnt.X, ws.no.rect.Y
                                    , ws.no.rect.Width - (_pnt.X - _dragStart.X), ws.no.rect.Height + (+_pnt.Y - _dragStart.Y));
                            }
                            else if (_selGizmo == Gizmo.RightUp)
                            {
                                ws.no.rect = new RectangleF(ws.no.rect.X, _pnt.Y
                                    , ws.no.rect.Width + (_pnt.X - _dragStart.X), ws.no.rect.Height - (+_pnt.Y - _dragStart.Y));
                            }
                            else if (_selGizmo == Gizmo.RightBottom)
                            {
                                ws.no.rect = new RectangleF(ws.no.rect.X, ws.no.rect.Y
                                    , ws.no.rect.Width + (_pnt.X - _dragStart.X), ws.no.rect.Height + (+_pnt.Y - _dragStart.Y));
                            }
                            else if (_selGizmo == Gizmo.Drag)
                            {
                                ws.no.rect = new RectangleF(ws.no.rect.X + (_pnt.X - _dragStart.X), ws.no.rect.Y + _pnt.Y - _dragStart.Y
                                    , ws.no.rect.Width, ws.no.rect.Height);
                            }
                            _dragStart = _pnt;

                        }
                    }
                    pm.Invalidate();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name + " || " + ex.ToString());
            }
        }

        private void PictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (pm.Image == null) return;
                if (e.Button == MouseButtons.Right)
                {
                    FinishTask();
                    return;
                }
                List<PointF> pnts;
                float _len, _factor;
                float zf = (float)(1.0 * pm.ClientSize.Width / pm.Image.Width);
                PointF _pnt = new PointF(e.X / zf, e.Y / zf);
                DrawingObject _obj;
                Cell _cell;
                if (ws.nowPicStatus == PicStatus.Start)
                {
                    if (ws.no != null && (ws.no.oType == DrawingObjectType.Triangle || ws.no.oType == DrawingObjectType.Polygon))
                    {
                        _drag = true;
                        _dragStart = _pnt;
                        ws.no.listPoint.Add(_dragStart);
                        ws.no.listPoint.Add(_dragStart);
                        ws.nowPicStatus = PicStatus.End;
                    }
                    else if (ws.no != null && (ws.no.oType == DrawingObjectType.Free))
                    {
                        _drag = true;
                        _dragStart = _pnt;
                        ws.no.listFreePoint.Add(new List<PointF>());
                        ws.no.listFreePoint.Last().Add(_dragStart);
                        ws.nowPicStatus = PicStatus.End;
                    }
                }
                else if (ws.nowPicStatus == PicStatus.BGSelect)
                {
                    Mat src = OpenCvSharp.Extensions.BitmapConverter.ToMat(ws.objBitmap);
                    var data = src.At<Vec3b>((int)(_pnt.Y - ws.objRect.Y), (int)(_pnt.X - ws.objRect.X));
                    ws.bgColorBefore = Color.FromArgb(data[2], data[1], data[0]);
                    btnBeforeBGColor.BackColor = ws.bgColorBefore;
                    ShowStatus(String.Format("선택 RGB = ({0},{1},{2}) 수동 영역제거 준비 완료", data[2], data[1], data[0]), true);
                    ws.nowPicStatus = PicStatus.None;
                    SetCursor(Cursors.Default);
                    src.Dispose();
                }
                else if (ws.nowPicStatus == PicStatus.PaperDrag)
                {
                    ws.nowPicStatus = PicStatus.None;
                    SetCursor(Cursors.Default);
                    _drag = false;
                }
                else if (_drag)
                {
                    if (ws.nowDrawingObjectType == DrawingObjectType.ObjCrop)
                    {

                        if (ws.nowPicStatus == PicStatus.End || ws.nowPicStatus == PicStatus.Select)
                        {
                            SetCursor(Cursors.Default);
                            _drag = false;
                            if (ws.nowPicStatus == PicStatus.End) CropImage();
                        }
                    }
                    else if (ws.nowDrawingObjectType == DrawingObjectType.Grid && ws.listGrids.Count > 0)
                    {
                        if (ws.nowPicStatus == PicStatus.Select)
                        {
                            AddUndoList("격자이동", false);
                        }
                        else
                        {
                            _selGrid = null;
                            AddUndoList("격자생성", false);
                            CancelTask();
                        }
                        _selGizmo = Gizmo.None;
                        SetCursor(Cursors.Default);
                        _drag = false;
                    }
                    else if (ws.nowDrawingObjectType == DrawingObjectType.Cell && ws.listGrids.Count > 0)
                    {
                        _selGizmo = Gizmo.None;
                        _drag = false;
                    }
                    else if (ws.nowDrawingObjectType == DrawingObjectType.ObjRotate && _selGizmo == Gizmo.Drag)
                    {
                        if (ws.listDragPoint.Count == 2)
                        {
                            float _angle = Util.getRotateAngle(ws.listDragPoint);
                            Bitmap _b = Util.RotateImage(ws.objBitmap, _angle, (int)ws.objRect.Width);
                            ws.objBitmap.Dispose();
                            ws.objBitmap = _b;
                            AddUndoList("회전", true);
                        }
                        SetCursor(Cursors.Default);
                        _drag = false;
                        ws.nowDrawingObjectType = DrawingObjectType.None;
                    }
                    else if (ws.nowDrawingObjectType == DrawingObjectType.Grid)
                    {
                        if (ws.nowPicStatus == PicStatus.Select || ws.nowPicStatus == PicStatus.End)
                        {
                            SetCursor(Cursors.Default);
                            _drag = false;
                            ws.nowPicStatus = PicStatus.Select;
                            AddUndoList(ws.nowPicStatus.ToString(), false);
                        }
                    }
                    else if (ws.nowPicStatus == PicStatus.InspectObj)
                    {
                        SetCursor(Cursors.Default);
                        _drag = false;
                        AddUndoList(ws.nowPicStatus.ToString(), false);
                    }
                    else if (ws.nowDrawingObjectType == DrawingObjectType.Marker && ws.listGrids.Count > 0 && _selGrid != null)
                    {
                        _cell = _selGrid.getCell(_pnt);
                        if (_cell != null) _selGrid.setMarker(_cell.r, _cell.c, isMarking, ws.markerColor);
                        SetCursor(Cursors.Default);
                        _drag = false;
                        AddUndoList(ws.nowDrawingObjectType.ToString(), false);
                    }
                    else if (ws.no.oType == DrawingObjectType.Line && ws.no.listPoint.Count == 2)
                    {
                        if (ws.nowPicStatus == PicStatus.End)
                        {
                            if (DistanceTo(ws.no.listPoint[0], _pnt) > 10)
                            {
                                pnts = ws.no.listPoint;
                                _len = (float)Math.Sqrt(Math.Pow(pnts[0].X - pnts[1].X, 2) + Math.Pow(pnts[0].Y - pnts[1].Y, 2)) + ws.SIZE_NODE_RECT;
                                List<PointF> _pnts = new List<PointF>();
                                _factor = 4;
                                _pnts.Add(new PointF(pnts[0].X - ws.SIZE_NODE_RECT / 2, pnts[0].Y - ws.SIZE_NODE_RECT * _factor));
                                _pnts.Add(new PointF(pnts[0].X - ws.SIZE_NODE_RECT / 2, pnts[0].Y + ws.SIZE_NODE_RECT * _factor));
                                _pnts.Add(new PointF(pnts[0].X + _len, pnts[0].Y + ws.SIZE_NODE_RECT * _factor));
                                _pnts.Add(new PointF(pnts[0].X + _len, pnts[0].Y - ws.SIZE_NODE_RECT * _factor));
                                double _angle = Math.Atan2(pnts[1].Y - pnts[0].Y, pnts[1].X - pnts[0].X);
                                for (int i = 0; i < _pnts.Count; i++)
                                {
                                    _pnts[i] = Util.rotatePoint(_angle, _pnts[i], pnts[0]);
                                }
                                ws.no.listLineGrapPoint = _pnts;

                                ws.nowPicStatus = PicStatus.None;
                                SetCursor(Cursors.Default);
                                _drag = false;
                                AddUndoList(ws.no.oType.ToString() + ":" + ws.nowPicStatus, false);
                                LineStart();
                            }
                            else
                            {
                                CancelTask();
                                ShowStatus("라인이 너무 작아 취소되었습니다. 드래그를 통해 다시 그려주시기 바랍니다.");
                            }
                        }
                        else if (ws.nowPicStatus == PicStatus.Select)
                        {
                            pnts = ws.no.listPoint;
                            _len = (float)Math.Sqrt(Math.Pow(pnts[0].X - pnts[1].X, 2) + Math.Pow(pnts[0].Y - pnts[1].Y, 2)) + ws.SIZE_NODE_RECT;
                            List<PointF> _pnts = new List<PointF>();
                            _factor = 4;
                            _pnts.Add(new PointF(pnts[0].X - ws.SIZE_NODE_RECT / 2, pnts[0].Y - ws.SIZE_NODE_RECT * _factor));
                            _pnts.Add(new PointF(pnts[0].X - ws.SIZE_NODE_RECT / 2, pnts[0].Y + ws.SIZE_NODE_RECT * _factor));
                            _pnts.Add(new PointF(pnts[0].X + _len, pnts[0].Y + ws.SIZE_NODE_RECT * _factor));
                            _pnts.Add(new PointF(pnts[0].X + _len, pnts[0].Y - ws.SIZE_NODE_RECT * _factor));
                            double _angle = Math.Atan2(pnts[1].Y - pnts[0].Y, pnts[1].X - pnts[0].X);
                            for (int i = 0; i < _pnts.Count; i++)
                            {
                                _pnts[i] = Util.rotatePoint(_angle, _pnts[i], pnts[0]);
                            }
                            ws.no.listLineGrapPoint = _pnts;
                            SetCursor(Cursors.Default);
                            _drag = false;
                            AddUndoList(ws.no.oType.ToString() + ":" + ws.nowPicStatus, false);
                        }
                    }
                    else if (ws.no.oType == DrawingObjectType.Ruler && ws.no.listPoint.Count == 2)
                    {
                        if (ws.nowPicStatus == PicStatus.End)
                        {
                            ws.nowPicStatus = PicStatus.None;
                            SetCursor(Cursors.Default);
                            _drag = false;
                            AddUndoList(ws.no.oType.ToString() + ":" + ws.nowPicStatus, false);
                            RulerStart();
                        }
                        else if (ws.nowPicStatus == PicStatus.Select)
                        {
                            SetCursor(Cursors.Default);
                            _drag = false;
                            AddUndoList(ws.no.oType.ToString() + ":" + ws.nowPicStatus, false);
                        }
                    }
                    else if (ws.no.oType == DrawingObjectType.Free && ws.no.listFreePoint.Count > 0)
                    {
                        if (ws.nowPicStatus == PicStatus.End)
                        {
                            ws.nowPicStatus = PicStatus.Start;
                            SetCursor(Cursors.Default);
                            _drag = false;
                            AddUndoList(ws.no.oType.ToString() + ":" + ws.nowPicStatus, false);
                        }
                        else if (ws.nowPicStatus == PicStatus.Select)
                        {
                            SetCursor(Cursors.Default);
                            _drag = false;
                            AddUndoList(ws.no.oType.ToString() + ":" + ws.nowPicStatus, false);
                        }
                    }
                    else if (ws.no.oType == DrawingObjectType.Text && ws.no.rect != null)
                    {
                        if (ws.nowPicStatus == PicStatus.Select)
                        {
                            SetCursor(Cursors.Default);
                            _drag = false;
                            AddUndoList(ws.no.oType.ToString() + ":" + ws.nowPicStatus, false);
                        }
                    }
                    else if ((ws.no.oType == DrawingObjectType.Triangle || ws.no.oType == DrawingObjectType.Polygon) && ws.no.listPoint.Count >= 2)
                    {
                        if (ws.nowPicStatus == PicStatus.End)
                        {
                            if (ws.no.oType == DrawingObjectType.Triangle && ws.no.listPoint.Count >= 3)
                            {
                                ws.nowPicStatus = PicStatus.None;
                                SetCursor(Cursors.Default);
                                _drag = false;
                                AddUndoList(ws.no.oType.ToString() + ":" + ws.nowPicStatus, false);
                            }
                            else
                            {
                                ws.no.listPoint.Add(_pnt);
                            }
                        }
                        else if (ws.nowPicStatus == PicStatus.Select)
                        {
                            SetCursor(Cursors.Default);
                            _drag = false;
                            AddUndoList(ws.no.oType.ToString() + ":" + ws.nowPicStatus, false);
                        }
                    }
                    else if (ws.no.oType == DrawingObjectType.Rect && ws.no.listPoint.Count == 2)
                    {
                        if (ws.nowPicStatus == PicStatus.End)
                        {
                            pnts = ws.no.listPoint;
                            ws.nowPicStatus = PicStatus.None;
                            SetCursor(Cursors.Default);
                            _drag = false;
                            AddUndoList(ws.no.oType.ToString() + ":" + ws.nowPicStatus, false);
                        }
                        else if (ws.nowPicStatus == PicStatus.Select)
                        {
                            SetCursor(Cursors.Default);
                            _drag = false;
                            AddUndoList(ws.no.oType.ToString() + ":" + ws.nowPicStatus, false);
                        }
                    }
                    else if (ws.no.oType == DrawingObjectType.Circle && ws.no.listPoint.Count == 2)
                    {
                        if (ws.nowPicStatus == PicStatus.End)
                        {
                            pnts = ws.no.listPoint;
                            ws.nowPicStatus = PicStatus.None;
                            SetCursor(Cursors.Default);
                            _drag = false;
                            AddUndoList(ws.no.oType.ToString() + ":" + ws.nowPicStatus, false);
                        }
                        else if (ws.nowPicStatus == PicStatus.Select)
                        {
                            SetCursor(Cursors.Default);
                            _drag = false;
                            AddUndoList(ws.no.oType.ToString() + ":" + ws.nowPicStatus, false);
                        }
                    }

                    pm.Invalidate();
                }
                else if (ws.nowPicStatus == PicStatus.None) // 생성작업이 아닐때
                {
                    _obj = ws.getFocusedObject(_pnt);
                    if (_obj != null)
                    {
                        ws.SetNowObject(_obj, PicStatus.Select);
                    }
                    else
                        ws.SetNowObject(null, PicStatus.None);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name + " || " + ex.ToString());
            }
        }

        private void PictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                if (pm.Image == null) return;
                Graphics g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                if (pm.Image == null) return;
                float zf = (float)(1.0 * pm.ClientSize.Width / pm.Image.Width);
                PointF[] _pnts;
                Pen _pen;
                RectangleF _rect;
                double _len;
                SolidBrush _brush;
                Font _font;
                SizeF _size;
                float x, y;
                // 검체
                if (ws.objBitmap != null)
                {
                    if (ws.nowDrawingObjectType == DrawingObjectType.ObjRotate && ws.listDragPoint.Count == 2)
                    {
                        float _angle = Util.getRotateAngle(ws.listDragPoint);
                        Bitmap _b = Util.RotateImage(ws.objBitmap, _angle, (int)ws.objRect.Width);
                        g.DrawImage(_b, new RectangleF(ws.objRect.X * zf, ws.objRect.Y * zf, ws.objRect.Width * zf, ws.objRect.Height * zf));
                        _b.Dispose();
                        g.DrawLine(new Pen(_penColor), zf * ws.listDragPoint[0].X, zf * ws.listDragPoint[0].Y, zf * ws.listDragPoint[1].X, zf * ws.listDragPoint[1].Y);
                        g.FillEllipse(new SolidBrush(Color.Gray), CreateRectSizableNode(zf * ws.listDragPoint[0].X, zf * ws.listDragPoint[0].Y));
                        g.FillRectangle(new SolidBrush(_penColor), CreateRectSizableNode(zf * ws.listDragPoint[1].X, zf * ws.listDragPoint[1].Y));
                    }
                    else
                    {
                        g.DrawImage(ws.objBitmap, new RectangleF(ws.objRect.X * zf, ws.objRect.Y * zf
                        , ws.objRect.Width * zf, ws.objRect.Height * zf));
                    }
                }
                if (ws.nowPicStatus == PicStatus.InspectObj)
                {
                    _rect = new RectangleF(ws.objRect.X * zf, ws.objRect.Y * zf, ws.objRect.Width * zf, ws.objRect.Height * zf);
                    _pen = new Pen(_penColor);
                    _pen.DashStyle = DashStyle.Dash;
                    g.DrawRectangles(_pen, new[] { _rect });
                }
                else if (ws.nowDrawingObjectType == DrawingObjectType.ObjCrop)
                {
                    if (ws.nowPicStatus == PicStatus.End || ws.nowPicStatus == PicStatus.Select)
                    {
                        _pen = new Pen(_penColor, 2);
                        _pen.DashStyle = DashStyle.Dash;
                        _rect = new RectangleF(ws.objCropRect.X * zf, ws.objCropRect.Y * zf
                          , ws.objCropRect.Width * zf, ws.objCropRect.Height * zf);
                        g.DrawRectangles(_pen, new[] { _rect });
                        if (ws.nowPicStatus == PicStatus.Select)
                        {
                            g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.LeftUp));
                            g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.LeftBottom));
                            g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.RightUp));
                            g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.RightBottom));
                        }
                    }
                }

                if (ws.isGridShow && ws.listGrids.Count > 0)
                {
                    //격자
                    foreach (var gs in ws.listGrids)
                    {
                        _pen = new Pen(gs.gridColor, gs.gridHThick * zf * ws.ZOOM_FACTOR);
                        _rect = new RectangleF(gs.GridRect.X * zf, gs.GridRect.Y * zf
                            , gs.GridRect.Width * zf, gs.GridRect.Height * zf);
                        if (gs.GridRect.Width > 10)
                        {
                            g.DrawLine(_pen, new PointF(_rect.X, _rect.Y), new PointF(_rect.X + _rect.Width, _rect.Y));
                            g.DrawLine(_pen, new PointF(_rect.X, _rect.Y + _rect.Height), new PointF(_rect.X + _rect.Width, _rect.Y + _rect.Height));
                            y = 0;
                            for (int r = 0; r < gs.RowHs.Length - 1; r++)
                            {
                                y += gs.RowHs[r];
                                g.DrawLine(_pen, new PointF(_rect.X, _rect.Y + y * zf), new PointF(_rect.X + _rect.Width, _rect.Y + y * zf));
                            }
                            _pen = new Pen(gs.gridColor, gs.gridVThick * zf * ws.ZOOM_FACTOR);
                            g.DrawLine(_pen, new PointF(_rect.X, _rect.Y), new PointF(_rect.X, _rect.Y + _rect.Height));
                            g.DrawLine(_pen, new PointF(_rect.X + _rect.Width, _rect.Y), new PointF(_rect.X + _rect.Width, _rect.Y + _rect.Height));
                            x = 0;
                            for (int c = 0; c < gs.ColumnWs.Length - 1; c++)
                            {
                                x += gs.ColumnWs[c];
                                g.DrawLine(_pen, new PointF(_rect.X + x * zf, _rect.Y), new PointF(_rect.X + x * zf, _rect.Y + _rect.Height));
                            }
                            //마커
                            _brush = new SolidBrush(ws.markerColor);
                            foreach (Cell cell in gs.listCells)
                            {
                                if (cell.isMarking)
                                {
                                    g.FillRectangle(new SolidBrush(cell.gColor), new RectangleF(cell.x * zf, cell.y * zf, gs.ColumnWs[cell.c] * zf, gs.RowHs[cell.r] * zf));
                                }
                            }
                        }
                    }
                    if (ws.nowDrawingObjectType == DrawingObjectType.Grid && _selGrid != null)
                    {
                        if (_selGrid.GridRect.Width > 10)
                        {
                            _rect = new RectangleF(_selGrid.GridRect.X * zf, _selGrid.GridRect.Y * zf, _selGrid.GridRect.Width * zf, _selGrid.GridRect.Height * zf);
                            _pen = new Pen(_penColor);
                            _pen.DashStyle = DashStyle.Dash;
                            g.DrawRectangles(_pen, new[] { _rect });
                            if (_selGrid.GridRect.Size != ws.paperSize) // 전체 격자인 경우는 크기 조절 안함
                            {
                                g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.LeftUp));
                                g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.LeftBottom));
                                g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.RightUp));
                                g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.RightBottom));
                            }
                        }
                    }
                    else if (ws.nowDrawingObjectType == DrawingObjectType.Cell && _selGrid != null && _selCell != null)
                    {
                        _rect = new RectangleF(_selGrid.GridRect.X * zf, _selGrid.GridRect.Y * zf, _selGrid.GridRect.Width * zf, _selGrid.GridRect.Height * zf);
                        _pen = new Pen(_penColor);
                        _pen.DashStyle = DashStyle.Dash;
                        g.DrawRectangles(_pen, new[] { _rect });

                        _rect = _selGrid.getCellRect(_selCell);
                        _rect = new RectangleF(_rect.X * zf, _rect.Y * zf, _rect.Width * zf, _rect.Height * zf);
                        g.DrawRectangles(_pen, new[] { _rect });
                        g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.LeftMiddle));
                        g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.RightMiddle));
                        g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.UpMiddle));
                        g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.BottomMiddle));
                    }

                }

                foreach (DrawingObject obj in ws.listObjects.OrderBy(p => p.zIndex))
                {
                    if (obj.oType == DrawingObjectType.Line)
                    {
                        if (obj.listPoint.Count == 2)
                        {
                            if (false && obj.listLineGrapPoint.Count > 0)
                            {
                                _pnts = new PointF[obj.listLineGrapPoint.Count];
                                for (int i = 0; i < obj.listLineGrapPoint.Count; i++) _pnts[i] = new PointF(obj.listLineGrapPoint[i].X * zf, obj.listLineGrapPoint[i].Y * zf);
                                g.DrawPolygon(new Pen(Color.Pink), _pnts);
                            }
                            g.DrawLine(new Pen(obj.lineColor, obj.lineThickness * zf * ws.ZOOM_FACTOR), zf * obj.listPoint[0].X, zf * obj.listPoint[0].Y, zf * obj.listPoint[1].X, zf * obj.listPoint[1].Y);
                            if (obj.isSelect)
                            {
                                g.FillRectangle(new SolidBrush(_penColor), CreateRectSizableNode(zf * obj.listPoint[0].X, zf * obj.listPoint[0].Y));
                                g.FillRectangle(new SolidBrush(_penColor), CreateRectSizableNode(zf * obj.listPoint[1].X, zf * obj.listPoint[1].Y));
                            }
                        }
                    }
                    else if (obj.oType == DrawingObjectType.Ruler)
                    {
                        if (obj.listPoint.Count == 2)
                        {
                            if (obj.listLineGrapPoint.Count > 0)
                            {
                                _pnts = new PointF[obj.listLineGrapPoint.Count];
                                for (int i = 0; i < obj.listLineGrapPoint.Count; i++) _pnts[i] = new PointF(obj.listLineGrapPoint[i].X * zf, obj.listLineGrapPoint[i].Y * zf);
                                //g.DrawPolygon(new Pen(Color.Pink), _pnts);
                                g.DrawLine(new Pen(obj.lineColor, obj.lineThickness), _pnts[0], _pnts[1]);
                                g.DrawLine(new Pen(obj.lineColor, obj.lineThickness), _pnts[2], _pnts[3]);
                                _len = DistanceTo(obj.listPoint[0], obj.listPoint[1]) / ws.pixelPerCm;
                                _font = new Font(obj.font.FontFamily, (int)(obj.font.Size * zf * ws.ZOOM_FACTOR), obj.font.Style);
                                g.DrawString(" " + _len.ToString("F2") + "cm", _font, new SolidBrush(obj.lineColor), _pnts[3]);
                                Debug.WriteLine(_len);
                            }
                            g.DrawLine(new Pen(obj.lineColor, obj.lineThickness), zf * obj.listPoint[0].X, zf * obj.listPoint[0].Y, zf * obj.listPoint[1].X, zf * obj.listPoint[1].Y);

                            if (obj.isSelect)
                            {
                                g.FillRectangle(new SolidBrush(_penColor), CreateRectSizableNode(zf * obj.listPoint[0].X, zf * obj.listPoint[0].Y));
                                g.FillRectangle(new SolidBrush(_penColor), CreateRectSizableNode(zf * obj.listPoint[1].X, zf * obj.listPoint[1].Y));
                            }
                        }
                    }
                    else if (obj.oType == DrawingObjectType.Free)
                    {
                        if (obj.listFreePoint.Count > 0)
                        {
                            _pen = new Pen(obj.lineColor, obj.lineThickness * zf * ws.ZOOM_FACTOR);
                            for (int i = 0; i < obj.listFreePoint.Count; i++)
                            {
                                _pnts = new PointF[obj.listFreePoint[i].Count];
                                if (_pnts.Length > 2)
                                {
                                    for (int j = 0; j < obj.listFreePoint[i].Count; j++)
                                    {
                                        _pnts[j] = new PointF(obj.listFreePoint[i][j].X * zf, obj.listFreePoint[i][j].Y * zf);
                                    }
                                    g.DrawCurve(_pen, _pnts.ToArray());
                                }
                            }
                            if (obj.isSelect)
                            {
                                _rect = new RectangleF(obj.rect.X * zf, obj.rect.Y * zf, obj.rect.Width * zf, obj.rect.Height * zf);
                                _pen = new Pen(_penColor);
                                _pen.DashStyle = DashStyle.Dash;
                                g.DrawRectangles(_pen, new[] { _rect });
                            }
                        }
                    }
                    else if (obj.oType == DrawingObjectType.Text)
                    {
                        if (obj.rect != null)
                        {
                            _rect = new RectangleF(obj.rect.X * zf, obj.rect.Y * zf, obj.rect.Width * zf, obj.rect.Height * zf);
                            RectangleF _objRect = new RectangleF(_rect.X - TEXT_BOX_MARGIN[0], _rect.Y - TEXT_BOX_MARGIN[1]
                                    , _rect.Width + TEXT_BOX_MARGIN[2], _rect.Height + TEXT_BOX_MARGIN[3]);
                            _font = new Font(obj.font.FontFamily, (int)(obj.font.Size * zf * ws.ZOOM_FACTOR), obj.font.Style); //폰트 배율 조정
                            g.DrawString(obj.text, _font, new SolidBrush(obj.lineColor), _rect.Location);
                            if (obj.isSelect)
                            {
                                _pen = new Pen(_penColor);
                                _pen.DashStyle = DashStyle.Dash;
                                g.DrawRectangles(_pen, new[] { _rect, _objRect });
                            }
                        }
                    }
                    else if (obj.oType == DrawingObjectType.Triangle || obj.oType == DrawingObjectType.Polygon)
                    {
                        if (obj.listPoint.Count >= 2)
                        {
                            _pnts = new PointF[obj.listPoint.Count];
                            for (int i = 0; i < obj.listPoint.Count; i++) _pnts[i] = new PointF(obj.listPoint[i].X * zf, obj.listPoint[i].Y * zf);
                            if (!obj.isTransparent) g.FillPolygon(new SolidBrush(obj.faceColor), _pnts);
                            if (obj.lineThickness > 0) g.DrawPolygon(new Pen(obj.lineColor, obj.lineThickness * zf * ws.ZOOM_FACTOR), _pnts);
                            if (obj.isSelect)
                            {
                                for (int i = 0; i < _pnts.Length; i++)
                                {
                                    g.FillRectangle(new SolidBrush(_penColor), CreateRectSizableNode(_pnts[i].X, _pnts[i].Y));
                                }
                            }
                        }
                    }
                    else if (obj.oType == DrawingObjectType.Rect)
                    {
                        if (obj.listPoint.Count == 2)
                        {
                            _rect = new RectangleF(obj.rect.X * zf, obj.rect.Y * zf, obj.rect.Width * zf, obj.rect.Height * zf);
                            if (!obj.isTransparent) g.FillRectangle(new SolidBrush(obj.faceColor), _rect);
                            if (obj.lineThickness > 0) g.DrawRectangles(new Pen(obj.lineColor, obj.lineThickness * zf * ws.ZOOM_FACTOR), new[] { _rect });
                            if (obj.isSelect)
                            {
                                g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.LeftUp));
                                g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.LeftBottom));
                                g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.RightUp));
                                g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.RightBottom));
                            }
                        }
                    }
                    else if (obj.oType == DrawingObjectType.Circle)
                    {
                        if (obj.listPoint.Count == 2)
                        {
                            _rect = new RectangleF(obj.rect.X * zf, obj.rect.Y * zf, obj.rect.Width * zf, obj.rect.Height * zf);
                            if (!obj.isTransparent) g.FillEllipse(new SolidBrush(obj.faceColor), _rect);
                            if (obj.lineThickness > 0) g.DrawEllipse(new Pen(obj.lineColor, obj.lineThickness * zf * ws.ZOOM_FACTOR), _rect);
                            if (obj.isSelect)
                            {
                                g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.LeftUp));
                                g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.LeftBottom));
                                g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.RightUp));
                                g.FillRectangle(new SolidBrush(_penColor), GetGizmoRect(_rect, Gizmo.RightBottom));
                            }
                        }
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name + " || " + ex.ToString());
            }
        }

        //메인 페이지 이미지 리사이즈 이벤트
        public void ePictureBoxMainSizeChanged(object sender, EventArgs e)
        {
            try
            {
                if (pm.Image == null) return;
                int imageWidth, imageHeight, pictureBoxMainClientHeight;
                if (pm != null && pm.Image != null)
                {
                    imageWidth = pm.Image.Width;
                    imageHeight = pm.Image.Height;
                    pictureBoxMainClientHeight = pm.ClientSize.Height;
                    pm.ClientSize = new Size((int)(1.0 * imageWidth * pictureBoxMainClientHeight / imageHeight), pictureBoxMainClientHeight);
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        #endregion Paint Event - PictureBoxMain

        #region 확대 축소
        // centerPoint : 원본이미지에서 클릭 위치
        private void ZoomImageWithCenterPoint(PointF centerPoint)
        {
            try
            {
                if (pm.Image == null) return;
                float _scale = (float)(1.0 * pm.ClientSize.Width / pm.Image.Width);
                _scale += ScalePerDelta * 100;
                if (_scale > 2) _scale = 2f;
                PanelView.HorizontalScroll.Value = 0;
                PanelView.VerticalScroll.Value = 0;
                pm.Size = new Size(
                    (int)(pm.Image.Width * _scale),
                    (int)(pm.Image.Height * _scale));
                Point _pnt = new Point((int)(PanelView.Width / 2 - centerPoint.X * _scale), (int)(PanelView.Height / 2 - centerPoint.Y * _scale));
                pm.Location = _pnt;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        private void ZoomImage(Zoom ztag = Zoom.FitHeight)
        {
            try
            {
                if (pm.Image == null) return;
                float _scale = (float)PanelView.Width / pm.Image.Width;
                float zf = (float)(1.0 * pm.ClientSize.Width / pm.Image.Width);
                if (ztag == Zoom.FitWidth) _scale = 0.95f * PanelView.Width / pm.Image.Width;
                else if (ztag == Zoom.FitHeight) _scale = 0.95f * PanelView.Height / pm.Image.Height;
                else if (ztag == Zoom.Source) _scale = 1;
                else if (ztag == Zoom.Bigger) zf += ScalePerDelta * 100;
                else zf -= ScalePerDelta * 100;
                if (zf < 0.2) zf = 0.2f;
                else if (zf > 2) zf = 2f;
                if (ztag == Zoom.Bigger || ztag == Zoom.Smaller) _scale = zf;
                PanelView.HorizontalScroll.Value = 0;
                PanelView.VerticalScroll.Value = 0;
                pm.Size = new Size(
                    (int)(pm.Image.Width * _scale),
                    (int)(pm.Image.Height * _scale)); Point _pnt = new Point((PanelView.Width - pm.Width) / 2, 10);
                if (ztag == Zoom.Source) _pnt = new Point(10, 10);
                pm.Location = _pnt;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }
        private void eMouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (pm.Image == null) return;
                if (System.Windows.Forms.Control.ModifierKeys == Keys.Control)
                {
                    if (pm.Image == null) return;
                    if (e.Delta > 0) ZoomImage(Zoom.Bigger);
                    else ZoomImage(Zoom.Smaller);
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        #endregion Panel Event - 확대 축소

        #region Util Paint
        public double DistanceTo(PointF point1, PointF point2)
        {
            try
            {
                var a = (double)(point2.X - point1.X);
                var b = (double)(point2.Y - point1.Y);
                return Math.Sqrt(a * a + b * b);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return 0;
            }
        }

        private RectangleF CreateRectSizableNode(float x, float y, float zoomFactor = 1)
        {
            try
            {
                return new RectangleF(x - ws.SIZE_NODE_RECT * zoomFactor / 2, y - ws.SIZE_NODE_RECT * zoomFactor / 2, ws.SIZE_NODE_RECT * zoomFactor, ws.SIZE_NODE_RECT * zoomFactor);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return new Rectangle(10, 10, 10, 10);
            }
        }

        private RectangleF GetGizmoRect(RectangleF rect, Gizmo Gizmo, float zoomFactor = 1)
        {
            try
            {
                switch (Gizmo)
                {
                    case Gizmo.LeftMiddle:
                        return CreateRectSizableNode(rect.X, rect.Y + rect.Height / 2, zoomFactor);
                    case Gizmo.RightMiddle:
                        return CreateRectSizableNode(rect.X + rect.Width, rect.Y + rect.Height / 2, zoomFactor);
                    case Gizmo.UpMiddle:
                        return CreateRectSizableNode(rect.X + rect.Width / 2, rect.Y, zoomFactor);
                    case Gizmo.BottomMiddle:
                        return CreateRectSizableNode(rect.X + rect.Width / 2, rect.Y + rect.Height, zoomFactor);
                    case Gizmo.LeftUp:
                        return CreateRectSizableNode(rect.X, rect.Y, zoomFactor);

                    case Gizmo.LeftBottom:
                        return CreateRectSizableNode(rect.X, rect.Y + rect.Height, zoomFactor);

                    case Gizmo.RightUp:
                        return CreateRectSizableNode(rect.X + rect.Width, rect.Y, zoomFactor);

                    case Gizmo.RightBottom:
                        return CreateRectSizableNode(rect.X + rect.Width, rect.Y + rect.Height, zoomFactor);

                    default:
                        return new RectangleF();
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return new RectangleF(10, 10, 10, 10);
            }
        }

        #endregion Util Paint

        #region Util
        private SizeF getPaperSize()
        {
            SizeF _size = new SizeF(0, 0);
            try
            {
                //A3(297,420), A4(210,297), B4(257,364), B5(182,257)
                if (rdoPaperA3.Checked)
                {
                    _size = new SizeF(420 * ws.pixelPerCm / 10, 297 * ws.pixelPerCm / 10);
                }
                else if (rdoPaperA4.Checked)
                {
                    _size = new SizeF(297 * ws.pixelPerCm / 10, 210 * ws.pixelPerCm / 10);
                }
                else if (rdoPaperB4.Checked)
                {
                    _size = new SizeF(364 * ws.pixelPerCm / 10, 257 * ws.pixelPerCm / 10);
                }
                else if (rdoPaperSource.Checked)
                {
                    _size = ws.objBitmap.Size;
                }
                else//B5
                {
                    _size = new SizeF(257 * ws.pixelPerCm / 10, 182 * ws.pixelPerCm / 10);
                }
                return _size;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return _size;
            }
        }
        private string getPaperName(float w)
        {
            try
            {
                //A3(297,420), A4(210,297), B4(257,364), B5(182,257)
                if (Math.Abs(w - 420 * ws.pixelPerCm / 10) < 1) return "A3";
                else if (Math.Abs(w - 297 * ws.pixelPerCm / 10) < 1) return "A4";
                else if (Math.Abs(w - 364 * ws.pixelPerCm / 10) < 1) return "B4";
                else if (Math.Abs(w - 257 * ws.pixelPerCm / 10) < 1) return "B5";
                else return "Source";
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return "Source";
            }
        }


        private int getNewZindex()
        {
            try
            {
                int cnt = ws.listObjects.Where(p => p.zIndex > 0).Count();
                int zindex = 1;
                if (cnt > 0) zindex = ws.listObjects.Where(p => p.zIndex > 0).Last().zIndex + 1;
                return zindex;

            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return 0;
            }
        }

        private void UpdateTextRect()
        {
            try
            {
                if (pm.Image == null) return;
                if (ws.no != null && ws.no.oType == DrawingObjectType.Text)
                {
                    float zf = (float)(1.0 * pm.ClientSize.Width / pm.Image.Width);
                    Size size = UpdateTextSize(ws.no.text, ws.no.font);
                    ws.no.rect = new RectangleF(ws.no.rect.X, ws.no.rect.Y, size.Width / zf, size.Height / zf);
                    pm.Invalidate();
                }
                else if (ws.no != null && ws.no.oType == DrawingObjectType.Ruler)
                {
                    pm.Invalidate();
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }
        private Size UpdateTextSize(string text, Font font)
        {
            try
            {
                if (pm.Image == null) return new Size(0, 0);
                float zf = (float)(1.0 * pm.ClientSize.Width / pm.Image.Width);
                Font _font = new Font(font.FontFamily, (int)(font.Size * zf * ws.ZOOM_FACTOR), font.Style);
                return TextRenderer.MeasureText(text, _font);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return new Size(0, 0);
            }
        }

        private void SetCursor(Cursor cursor)
        {
            try
            {
                this.Cursor = cursor;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        private void ShowStatus(string msg, bool isIntense = false)
        {
            try
            {
                this.lblStatus.Text = DateTime.Now.ToString("HH:mm:ss") + " | " + msg;
                if (isIntense) lblStatus.ForeColor = Color.Black;
                else lblStatus.ForeColor = Color.Gray;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }




        #endregion Util

        private void materialTabSelector1_Click(object sender, EventArgs e)
        {

        }


    }
}