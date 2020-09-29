using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Integration_Viewer.DTO;
using System.Drawing.Drawing2D;
using System.IO;
using Sedas.ImageHelper;
using Sedas.Core;
using DevExpress.Utils.Behaviors;
using DevExpress.Utils.DragDrop;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using DevExpress.Utils.Drawing;
using DevExpress.XtraLayout;
using DevExpress.XtraGrid.Views.Layout;
using System.Reflection;
using DevExpress.XtraGrid.Views.Layout.ViewInfo;
using GdPicture14;

namespace Integration_Viewer
{
   

    public partial class ImageContainer : DevExpress.XtraEditors.XtraUserControl
    {
        public ChildType childType;//child 종류
        public string recordResult = string.Empty;

        ImageHelper imageHelper = new ImageHelper();
        //BehaviorManager behaviorManager1 = new BehaviorManager();

        public event Action<ImageContainer, string> onImageSelected;
        public event Action<ImageContainer, string> onImageDoubleClick;

        private ImageButtonValue imageButtonValue = null; //이미지 관련 데이터
        private TreeDTO treeDTO;


        public ImageContainer()
        {
            InitializeComponent();
        }

        bool isSelected = false; //이미지 선택여부
        bool isLastSelected = false; //마지막으로 선택된 이미지 여부
        string path = ""; //경로
        Image image = null;//이미지
        Image extensionImage = null; //타입종류를 나타내는 이미지

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                isSelected = value;
                this.ImageBorderChange(value);
            }
        }

        public string Path
        {
            get
            {
                return path;
            }

            set
            {
                path = value;
            }
        }

        public bool IsLastSelected
        {
            get
            {
                return isLastSelected;
            }

            set
            {
                isLastSelected = value;
            }
        }

        public Image Image
        {
            get
            {
                return image;
            }

            set
            {
                image = value;
            }
        }

        public ImageButtonValue ImageButtonValue
        {
            get
            {
                return imageButtonValue;
            }

            set
            {
                imageButtonValue = value;
            }
        }

        public TreeDTO TreeDTO
        {
            get
            {
                return treeDTO;
            }

            set
            {
                treeDTO = value;
                treeDTO.PropertyChanged += TreeDTO_PropertyChanged;
            }
        }


        /// <summary>
        /// name         : TreeDTO_PropertyChanged
        /// desc         : 트리컨트롤에서 데이터 변경시
        /// author       : 심우종
        /// create date  : 2020-07-06 15:39
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void TreeDTO_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "Checked")
            {
                this.Visible = this.TreeDTO.Checked.Value;
            }
        }

        /// <summary>
        /// 이미지 border 표시여부
        /// </summary>
        /// <param name="isYn"></param>
        private void ImageBorderChange(bool isYn)
        {
            if (isYn == true)
            {
                this.pnlMain.Appearance.Options.UseBorderColor = true;
                this.pnlMain.Appearance.BorderColor = this.selectcolor;
            }
            else
            {
                this.pnlMain.Appearance.Options.UseBorderColor = false;
                this.pnlMain.Appearance.BorderColor = this.nomalcolor;
                    //System.Drawing.Color.Empty;
            }
        }


        Color nomalcolor = Color.Red;
        Color selectcolor = System.Drawing.Color.FromArgb(253, 114, 105);
        Color pencolor = Color.Green;



        /// <summary>
        /// name         : Dispose
        /// desc         : 객체 삭제를 위한 처리
        /// author       : 심우종
        /// create date  : 2020-07-02 14:44
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void Clear()
        {
            if (Image != null)
            {
                this.Image.Dispose();
                this.image = null;
            }

            if (this.extensionImage != null)
            {
                this.extensionImage.Dispose();
                this.extensionImage = null;
            }

            if (this.treeDTO != null)
            {
                treeDTO.PropertyChanged -= TreeDTO_PropertyChanged;
                this.treeDTO = null;
            }

        }

        /// <summary>
        /// name         : ImageContainer_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-04-24 08:52
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ImageContainer_Load(object sender, EventArgs e)
        {
            //if (g_OthersSetupData.nImageSize.ToString() == ConstantData.LARGE_SIZE)
            //{
            //    if (this.tlpMain.RowStyles.Count >= 3)
            //    {
            //        this.tlpMain.RowStyles[0].Height = 22;
            //        this.tlpMain.RowStyles[2].Height = 22;
            //    }
            //}
            //else
            //{
            //    if (this.tlpMain.RowStyles.Count >= 3)
            //    {
            //        this.tlpMain.RowStyles[0].Height = 15;
            //        this.tlpMain.RowStyles[2].Height = 15;
            //    }
            //}

            //if ( this.pnlMain.)
            if (imageButtonValue != null)
            {

                this.nomalcolor = Global.backColor;
                //this.selectcolor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
                this.pencolor = Color.White;

                //this.nomalcolor = Color.FromArgb(200, 200, 255);
                //this.selectcolor = Color.FromArgb(70, 70, 255);
                //this.pencolor = Color.FromArgb(150, 150, 250);

                //if (this.ImageButtonValue.nSendStatus == -1)
                //{
                //    this.nomalcolor = Color.FromArgb(200, 200, 200);
                //    this.selectcolor = Color.FromArgb(70, 70, 70);
                //    this.pencolor = Color.FromArgb(150, 150, 150);
                //}
                //else if (this.ImageButtonValue.nSendStatus == 0 || this.ImageButtonValue.nSendStatus == 9 || this.ImageButtonValue.nSendStatus == 8)
                //{
                //    if (this.ImageButtonValue.nType == 0)
                //    {
                //        this.nomalcolor = Color.FromArgb(255, 200, 200);
                //        this.selectcolor = Color.FromArgb(255, 70, 70);
                //        this.pencolor = Color.FromArgb(250, 150, 150);
                //    }
                //    if (this.ImageButtonValue.nType == 1)
                //    {
                //        this.nomalcolor = Color.FromArgb(150, 255, 150);
                //        this.selectcolor = Color.FromArgb(70, 200, 70);
                //        this.pencolor = Color.FromArgb(150, 200, 150);
                //    }
                //    if (this.ImageButtonValue.nType == 2)
                //    {
                //        this.nomalcolor = Color.FromArgb(160, 227, 250);
                //        this.selectcolor = Color.FromArgb(31, 0, 242);
                //        this.pencolor = Color.FromArgb(160, 150, 250);
                //    }
                //}
                //else if (this.ImageButtonValue.nSendStatus == 1)
                //{
                //    this.nomalcolor = Color.FromArgb(200, 200, 255);
                //    this.selectcolor = Color.FromArgb(70, 70, 255);
                //    this.pencolor = Color.FromArgb(150, 150, 250);
                //}

                //string imageInfo = this.ImageButtonValue.strRowFilePath.Split('\\').LastOrDefault();
                string imageInfo = this.ImageButtonValue.strRowFileName;

                //this.lblImageInfo.Text = imageInfo;
                //this.lblPtoNo.Text = this.ImageButtonValue.strPathologyNum;
                this.lblOcrResult.Text = this.ImageButtonValue.ocrResult;

                if (this.ImageButtonValue.nImageNum == -1)
                {
                    this.lblImageNum.Text = "";
                }
                else
                {
                    this.lblImageNum.Text = this.ImageButtonValue.nImageNum.ToString();
                }

                if (this.pictureEdit.Properties.ContextButtons != null && this.pictureEdit.Properties.ContextButtons.Count > 0)
                {
                    this.pictureEdit.Properties.ContextButtons.Where(o => o.Name == "imageName").ToList().ForEach(item =>
                    {
                        if (item is DevExpress.Utils.ContextButton)
                        {
                            (item as DevExpress.Utils.ContextButton).Caption = imageInfo;
                            //(item as DevExpress.Utils.ContextButton).Visibility = DevExpress.Utils.ContextItemVisibility.Visible;
                            //pictureEdit1.Height++;
                            //pictureEdit1.Height--;
                        }
                    });
                }



            }



            this.tlpMain.BackColor = this.nomalcolor;
            //this.lblImageInfo.ForeColor = this.pencolor;
            this.pnlMain.Appearance.BorderColor = this.nomalcolor;



        }





        /// <summary>
        /// name         : ImageClickEvent
        /// desc         : 이미지 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-03 11:29
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ImageClickEvent()
        {
            string pressedKeyCode = "";
            if (Control.ModifierKeys == Keys.Control)
            {
                pressedKeyCode = "Control";
            }
            else if (Control.ModifierKeys == Keys.Shift)
            {
                pressedKeyCode = "Shift";
            }


            if (onImageSelected != null)
            {
                this.onImageSelected(this, pressedKeyCode);
            }
        }


        private void imageBox_MouseDown(object sender, MouseEventArgs e)
        {


        }

        /// <summary>
        /// 이미지를 설정한다.
        /// </summary>
        /// <param name="image"></param>
        public void SetImage(Image image, string path)
        {
            this.Path = path;
            this.Image = image;
            pictureEdit.Image = image;
            pictureEdit.Properties.InitialImageOptions.BeginUpdate();
            pictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            //this.pictureEdit.Refresh();


            Bitmap bm = (Bitmap)this.image;

            //Bitmap copy_bm = (Bitmap)bm.Clone();

            //using (Graphics gr = Graphics.FromImage(copy_bm))
            //{
            //    // Cover with translucent white.
            //    using (SolidBrush br =
            //        new SolidBrush(Color.FromArgb(128, 255, 255, 255)))
            //    {
            //        gr.FillRectangle(br, 0, 0, bm.Width, bm.Height);
            //    }
            //}


            //MyNormalCursor = new Cursor(copy_bm.GetHicon());
            if (bm != null)
            {
                this.MyNormalCursor = CreateCursor(bm);
                this.MyNoDropCursor = Cursors.No;
            }
            else
            {
                //Cursor current = Cursors.No;
                this.MyNormalCursor = Cursors.Hand;
                this.MyNoDropCursor = Cursors.No;
            }
            


            //DragDropManager.Default.DragOver += OnDragOver;
            //DragDropManager.Default.DragDrop += OnDragDrop;

            //pnlImage.BackgroundImage = image;
            //imageBox.SetBounds(18, 18, 150, 150);
            //pnlImage.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Stretch;
        }


        public struct IconInfo
        {
            public bool fIcon;
            public int xHotspot;
            public int yHotspot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetIconInfo(IntPtr hIcon, ref IconInfo pIconInfo);
        [DllImport("user32.dll")]
        public static extern IntPtr CreateIconIndirect(ref IconInfo icon);

        public static Cursor CreateCursor(Bitmap bmp)
        {

            //Bitmap result = new Bitmap(bmp.Width, bmp.Height);
            //Graphics resultGraphics = Graphics.FromImage(result);
            //float[][] matrixItems ={
            //                   new float[] {1, 0, 0, 0, 0},
            //                   new float[] {0, 1, 0, 0, 0},
            //                   new float[] {0, 0, 1, 0, 0},
            //                   new float[] {0, 0, 0, 0.7f, 0},
            //                   new float[] {0, 0, 0, 0, 1}};
            //ColorMatrix colorMatrix = new ColorMatrix(matrixItems);
            //ImageAttributes imageAttributes = new ImageAttributes();
            //imageAttributes.SetColorMatrix(
            //   colorMatrix,
            //   ColorMatrixFlag.Default,
            //   ColorAdjustType.Bitmap);
            //resultGraphics.DrawImage(bmp, imageBounds, rowInfo.TotalBounds.X, 0, rowInfo.TotalBounds.Width, rowInfo.TotalBounds.Height, GraphicsUnit.Pixel, imageAttributes);




            int xHotSpot = 0;
            int yHotSpot = 0;

            //IntPtr ptr = bmp.GetHicon();
            //IconInfo tmp = new IconInfo();
            //GetIconInfo(ptr, ref tmp);
            //tmp.xHotspot = xHotSpot;
            //tmp.yHotspot = yHotSpot;
            //tmp.fIcon = false;
            //ptr = CreateIconIndirect(ref tmp);
            //return new Cursor(ptr);


            if (bmp == null) return Cursors.Default;
            bmp = (Bitmap)bmp.GetThumbnailImage(bmp.Width, bmp.Height, null, IntPtr.Zero);
            IntPtr ptr = bmp.GetHicon();
            IconInfo tmp = new IconInfo();
            GetIconInfo(ptr, ref tmp);
            tmp.fIcon = false;
            tmp.xHotspot = xHotSpot;
            tmp.yHotspot = yHotSpot;
            ptr = CreateIconIndirect(ref tmp);
            return new Cursor(ptr);


        }

        //private DevExpress.XtraGrid.Views.Layout.LayoutViewCard layoutViewCard1;
        //private DevExpress.XtraGrid.Views.Layout.LayoutView layoutView1;
        //LayoutViewHitInfo downHitInfo;

        //private Bitmap GetPicture()
        //{
        //    //pictureEdit
        //    if (downHitInfo == null) return null;
        //    LayoutViewCard layoutCard = downHitInfo.HitCard;
        //    if (layoutCard == null) return null;
        //    Rectangle r = new Rectangle(0, 0, Width * 2, Height * 2);
        //    using (Bitmap bmp = new Bitmap(r.Width, r.Height, PixelFormat.Format32bppArgb))
        //    {
        //        using (Graphics imgGraphics = Graphics.FromImage(bmp))
        //        {
        //            using (XtraBufferedGraphics bufferedGraphics = XtraBufferedGraphicsManager.Current.Allocate(imgGraphics, r))
        //            {
        //                ObjectPainter cardPainter = (layoutView1 as ILayoutControl).PaintStyle.GetPainter(layoutCard);
        //                bufferedGraphics.Graphics.Clear(Color.White);
        //                layoutCard.ViewInfo.Cache = new GraphicsCache(new DXPaintEventArgs(bufferedGraphics.Graphics, r));
        //                PropertyInfo property = typeof(LayoutView).GetProperty("DrawCard", BindingFlags.Instance | BindingFlags.NonPublic);
        //                property.SetValue(layoutView1, layoutCard, null);
        //                cardPainter.DrawObject(layoutCard.ViewInfo);
        //                layoutCard.ViewInfo.Cache = null;
        //                bufferedGraphics.Render();
        //            }
        //            Bitmap newImage = Copy(bmp, layoutCard.Bounds);
        //            return newImage;
        //        }
        //    }
        //}

        static public Bitmap Copy(Bitmap srcBitmap, Rectangle section)
        {
            Bitmap bmp = new Bitmap(section.Width, section.Height);
            using (Graphics g = Graphics.FromImage(bmp))
            {
                g.DrawImage(srcBitmap, 0, 0, section, GraphicsUnit.Pixel);
            }
            return bmp;
        }

        void OnDragOver(object sender, DragOverEventArgs e)
        {
            if (object.ReferenceEquals(e.Source, e.Target))
                return;
            e.Default();
            if (e.InsertType == InsertType.None)
                return;
            e.Action = DragDropActions.Move;
            Cursor current = Cursors.No;
            if (e.Action != DragDropActions.None)
                current = Cursors.Default;
            e.Cursor = current;
        }

        void OnDragDrop(object sender, DragDropEventArgs e)
        {
            if (object.ReferenceEquals(e.Source, e.Target))
                return;
            e.Handled = true;
            if (e.Action == DragDropActions.None || e.InsertType == InsertType.None)
                return;
            //if (e.Target == treeList1)
            //    OnTreeListDrop(e);
            //if (e.Target == listBoxControl)
            //    OnListBoxDrop(e);
            Cursor.Current = Cursors.Default;
        }


        /// <summary>
        /// name         : SetExtensionImage
        /// desc         : 확장자에 따른 파일 종류에 대한 이미지
        /// author       : 심우종
        /// create date  : 2020-07-01 14:46
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void SetExtensionImage(Image image)
        {
            this.extensionImage = image;
            //pictureEdit.Image = image;
            //pictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            //fdfd
            

            //Sedas.Control.HPictureEdit picExtention = new Sedas.Control.HPictureEdit();
            //picExtention.Location = new System.Drawing.Point(3, 3);
            //picExtention.Name = "picExtention";
            ////picExtention.Properties.Appearance.BackColor = System.Drawing.Color.Red;
            ////picExtention.Properties.Appearance.Options.UseBackColor = true;
            //picExtention.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            //picExtention.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            //picExtention.Size = new System.Drawing.Size(52, 48);
            //picExtention.TabIndex = 3;
            //picExtention.Image = this.extensionImage;
            //picExtention.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            ////picExtention.Anchor = AnchorStyles.Left;
            //this.pnlMain.Controls.Add(picExtention);
            //picExtention.BringToFront();

        }


        


        private void tableLayoutPanel1_Click(object sender, EventArgs e)
        {
            this.ImageClickEvent();
        }

        private void imageBox_Click(object sender, EventArgs e)
        {
            this.ImageClickEvent();
        }


        private void pictureEdit_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ImageMouseDoubleClick();
        }

        private void tlpMain_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            this.ImageMouseDoubleClick();
        }


        /// <summary>
        /// name         : ImageMouseDoubleClick
        /// desc         : 이미지 더블클릭에 대한 처리
        /// author       : 심우종
        /// create date  : 2020-04-03 11:30
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ImageMouseDoubleClick()
        {
            if (this.onImageDoubleClick != null)
            {
                this.onImageDoubleClick(this, null);
            }
        }

        bool isDrag = false;
        private void pictureEdit_MouseDown(object sender, MouseEventArgs e)
        {
            
            isDrag = false;
            pictureEdit.DoDragDrop(this, DragDropEffects.Move);
            //this.ImageClickEvent();

            if (isDragCancel == true)
            {
                pictureEdit_MouseUp(sender, new MouseEventArgs(Control.MouseButtons, 0, Control.MousePosition.X, Control.MousePosition.Y, 0));
            }

            RectStartPoint = e.Location;
            Invalidate();
        }

        private Cursor MyNormalCursor;
        private Cursor MyNoDropCursor;

        private void pictureEdit_DragOver(object sender, DragEventArgs e)
        {
            
            isDrag = true;
            e.Effect = DragDropEffects.Move;
            //Cursor.Current = Cursors.Hand;
            
        }

        private void pictureEdit_GiveFeedback(object sender, GiveFeedbackEventArgs e)
        {
            e.UseDefaultCursors = false;
            if ((e.Effect & DragDropEffects.Move) == DragDropEffects.Move)
                Cursor.Current = MyNormalCursor;
            else
                Cursor.Current = MyNoDropCursor;
        }

        private void pictureEdit_MouseUp(object sender, MouseEventArgs e)
        {
            if (isDrag == false)
            {
                this.ImageClickEvent();
            }
            
        }
        
        
        private void pictureEdit_DragDrop(object sender, DragEventArgs e)
        {
            this.ImageClickEvent();
            Console.WriteLine("test");
        }
        bool isDragCancel = false;

        private void pictureEdit_QueryContinueDrag(object sender, QueryContinueDragEventArgs e)
        {
            //Rectangle rect = new Rectangle(this.Location, new Size(pictureEdit.Width, pictureEdit.Height));
            this.isDragCancel = false;
            if (e.Action == DragAction.Drop)
            {
                //e.Action = DragAction.Cancel;
                //Manually fire the MouseUp event
                if (isDrag == false)
                {
                    e.Action = DragAction.Cancel;
                    isDragCancel = true;
                    //Cursor.Current = Cursors.Default;
                    //MessageBox.Show("test");
                    //pictureEdit_MouseUp(sender, new MouseEventArgs(Control.MouseButtons, 0, Control.MousePosition.X, Control.MousePosition.Y, 0));
                }
            }
            else if ( e.Action == DragAction.Continue)
            {


            }
        }

        private Rectangle Rect = new Rectangle();
        private Brush selectionBrush = new SolidBrush(Color.FromArgb(128, 72, 145, 220));
        private Point RectStartPoint;
        private void pictureEdit_Paint(object sender, PaintEventArgs e)
        {
            if (extensionImage != null)
            {
                Size imageSize = new System.Drawing.Size(50, 50);

                Point imageLocation = new Point(pictureEdit.Bounds.X, pictureEdit.Bounds.Y + pictureEdit.Bounds.Height - imageSize.Height);

                try
                {
                    e.Graphics.DrawImage(extensionImage, new Rectangle(imageLocation, imageSize));
                }
                catch
                { 
                }
                
            }
            //Graphics image = Graphics.FromImage(extensionImage);
            //Brush brush = color
            //image.FillEllipse(Color.Red, 0, 0, 70, 70);


        }

        private void pictureEdit_MouseMove(object sender, MouseEventArgs e)
        {
            //if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            //{
            //    MyNormalCursor = new Cursor(this.Path);
            //    MyNoDropCursor = new Cursor(this.Path);
            //}


            Rect.Size = new Size(70, 70);
        }




        public async void OfficeFileTransferAsync()
        {
            //var thumbImage = OfficeFileTransfer();

            this.pictureEdit.Properties.NullText = "Office 파일 변환중 입니다.\r\n잠시만 기다려 주세요.";
                //this.ImageButtonValue.strRowFileName;


            BackgroundWorker bgwSendFile = new BackgroundWorker();
            bgwSendFile.DoWork += new DoWorkEventHandler(bgwOfficeFileChange_DoWork);
            bgwSendFile.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgwOfficeFileChange_Completed);
            bgwSendFile.RunWorkerAsync();

            //await Task.Run(() =>
            //{
            //    OfficeFileTransfer();
            //});

            //thumbImage.ContinueWith(task =>
            //{
            //    Image image = task.Result;
            //    if (image != null)
            //    {
            //        this.SetImage(image, imageButtonValue.strRowFilePath);
            //    }
            //});

            //await Task.Run(() =>
            //{
            //    WriteLogAfter(logDTO);
            //});


        }

        void bgwOfficeFileChange_DoWork(object sender, DoWorkEventArgs e)
        {
            //OfficeFileTransfer();

            OfficeFileTransferForGdPicture();
        }

        void bgwOfficeFileChange_Completed(object sender, RunWorkerCompletedEventArgs e)
        {

            if (this.isOfficeToPdfSuccess == false)
            {
                this.pictureEdit.Properties.NullText = "변환에 실패하였습니다.";
            }
            else
            {
                if (imageButtonValue.strRowFilePath.GetFileExtension().ToUpper() == "PDF")
                {
                    //PDF는 첫 페이지를 섬네일로 보여준다.
                    Image thumbImage = imageHelper.PdfThumbnail(imageButtonValue.strRowFilePath);
                    //return thumbImage;
                    this.SetImage(thumbImage, imageButtonValue.strRowFilePath);
                    this.isOfficeToPdfSuccess = true;
                }
            }

            this.pictureEdit.Refresh();

        }

        bool isOfficeToPdfSuccess = false; //office to pdf 변환 성공여부


        private bool OfficeFileTransferForGdPicture()
        {
            if (this.ImageButtonValue == null) return false;

            try
            {
                FileInfo fileinfo = new FileInfo(this.ImageButtonValue.strRowFilePath);

                if (fileinfo.Exists)
                {
                    string outResult = "";

                    string directoryName = fileinfo.DirectoryName + "\\";

                    string fileName = "";
                    if (!string.IsNullOrEmpty(fileinfo.Extension))
                    {
                        fileName = fileinfo.Name.Substring(0, fileinfo.Name.Length - fileinfo.Extension.Length);
                    }

                    DateTime current = DateTime.Now;
                    fileName = directoryName + fileName + "_" + current.ToString("yyyyMMddHHmmss") + "_" + "temp.pdf";

                    //GdPicture에서 변환가능여부 먼저 확인
                    // -------------------------- 아래 이유로 GDPicture변환은 사용안함...
                    // GDPciture 변환기능을 사용하면 메모리를 너무 많이 잡아먹음..
                    // 특정 파일 변환시 너무 오래 걸리는 문제 있음.
                    //using (GdPictureDocumentConverter gdpictureDocumentConverter = new GdPictureDocumentConverter())
                    //{
                    //    // Loading the source document.
                    //    if (gdpictureDocumentConverter.LoadFromFile(this.ImageButtonValue.strRowFilePath) == GdPictureStatus.OK)
                    //    {
                    //        // Saving as the PDF document.
                    //        if (gdpictureDocumentConverter.SaveAsPDF(fileName, PdfConformance.PDF1_5) == GdPictureStatus.OK)
                    //        {
                    //            if (!string.IsNullOrEmpty(fileName))
                    //            {
                    //                imageButtonValue.strRowFilePath = fileName;
                    //                this.isOfficeToPdfSuccess = true;
                    //                //if (imageButtonValue.strRowFilePath.GetFileExtension().ToUpper() == "PDF")
                    //                //{
                    //                //    //PDF는 첫 페이지를 섬네일로 보여준다.
                    //                //    Image thumbImage = imageHelper.PdfThumbnail(imageButtonValue.strRowFilePath);
                    //                //    //return thumbImage;
                    //                //    this.SetImage(thumbImage, imageButtonValue.strRowFilePath);
                                        
                    //                //}
                    //            }
                    //        }
                    //    }
                    //}

                    if (this.isOfficeToPdfSuccess == false)
                    {
                        if (imageHelper.OfficeToPDF(this.ImageButtonValue.strRowFilePath, out outResult) == true)
                        {
                            if (!string.IsNullOrEmpty(outResult))
                            {
                                imageButtonValue.strRowFilePath = outResult;
                                this.isOfficeToPdfSuccess = true;
                                //if (imageButtonValue.strRowFilePath.GetFileExtension().ToUpper() == "PDF")
                                //{
                                //    //PDF는 첫 페이지를 섬네일로 보여준다.
                                //    Image thumbImage = imageHelper.PdfThumbnail(imageButtonValue.strRowFilePath);
                                //    //return thumbImage;
                                //    this.SetImage(thumbImage, imageButtonValue.strRowFilePath);
                                   
                                //}
                            }

                        }

                    }

                }
            }
            catch(Exception ex)
            { 
            
            }

            return false;
        }

        /// <summary>
        /// name         : OfficeFileTransfer
        /// desc         : 오피스 파일 PDF변경에 시간이 걸리므로 비동기 처리
        /// author       : 심우종
        /// create date  : 2020-07-02 08:51
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public async Task<Image> OfficeFileTransfer()
        {

            if (this.ImageButtonValue == null) return null;

            FileInfo fileinfo = new FileInfo(this.ImageButtonValue.strRowFilePath);

            if (fileinfo.Exists)
            {
                string outResult = "";

                


                if (imageHelper.OfficeToPDF(this.ImageButtonValue.strRowFilePath, out outResult) == true)
                {
                    if (!string.IsNullOrEmpty(outResult))
                    {
                        imageButtonValue.strRowFilePath = outResult;

                        if (imageButtonValue.strRowFilePath.GetFileExtension().ToUpper() == "PDF")
                        {
                            //PDF는 첫 페이지를 섬네일로 보여준다.
                            Image thumbImage = imageHelper.PdfThumbnail(imageButtonValue.strRowFilePath);
                            //return thumbImage;
                            this.SetImage(thumbImage, imageButtonValue.strRowFilePath);
                            this.isOfficeToPdfSuccess = true;
                        }
                    }

                }
            }

            return null;
        }

        
    }
}
