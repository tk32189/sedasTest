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
using GdPicture14;
using LicenseManager = GdPicture14.LicenseManager;
using Sedas.Core;

namespace Integration_Viewer
{
    public partial class Viewer : DevExpress.XtraEditors.XtraUserControl
    {
        public event Action<ImageContainer> OnViewerImageChanged;
        public event Action OnRightImageClick;
        public event Action OnLeftImageClick;
        public event Action<Viewer> OnViewSelected;

        string filePath;
        private ViewerDocument _document;
        ImageContainer imageContainer;
        bool isSelected = false;
        bool isPopup = false;

        public ImageContainer ImageContainer
        {
            get
            {
                return imageContainer;
            }

            set
            {
                imageContainer = value;
            }
        }

        public bool IsSelected
        {
            get
            {
                return isSelected;
            }

            set
            {
                isSelected = value;
                if (isSelected == true)
                {
                    picChecked.Visible = true;
                }
                else
                {
                    picChecked.Visible = false;
                }
            }
        }

        public bool IsPopup
        {
            get
            {
                return isPopup;
            }

            set
            {
                isPopup = value;
            }
        }

        /// <summary>
        /// The rasterization when loading the image from a pdf.
        /// </summary>
        private const int PdfRasterizationResolution = 300;


        /// <summary>
        /// GdPictureImaging instance.
        /// </summary>
        private GdPictureImaging _gdPictureImaging;


        public Viewer()
        {
            InitializeComponent();
        }

        public void CallMethod(string eventValue, string param = null)
        {
            switch (eventValue)
            {
                case "ZoomIn":
                    this.ZoomIn();
                    break;
                case "ZoomOut":
                    this.ZoomOut();
                    break;
                case "FitWidth":
                    FitWidth();
                    break;
                case "FitPage":
                    FitPage();
                    break;
                case "RotateLeft":
                    RotateLeft();
                    break;
                case "RotateRight":
                    RotateRight();
                    break;
                case "FlipX":
                    FlipX();
                    break;
                case "FlipY":
                    FlipY();
                    break;
                case "AdjustGamma":
                    AdjustGamma(param);
                    break;


            }
        }


        /// <summary>
        /// name         : AdjustGamma
        /// desc         : 감마조절
        /// author       : 심우종
        /// create date  : 2020-07-10 17:06
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void AdjustGamma(string param)
        {
            if (param.ToDoubleOrNull() != null)
            {
                gdViewer1.Gamma = (float)(param.ToDouble() / 10);
            }
        }


        /// <summary>
        /// name         : FlipY
        /// desc         : 상하반전
        /// author       : 심우종
        /// create date  : 2020-06-26 16:52
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void FlipY()
        {
            gdViewer1.Rotate(RotateFlipType.RotateNoneFlipY);
            //if (_document.IsOpen)
            //{
            //    UpdateControlsOcrResultDiscarded();

            //    GdPictureStatus errorCode = _gdPictureImaging.Rotate(_document.ImageId,
            //        RotateFlipType.RotateNoneFlipY);
            //    gdViewer1.Redraw();
            //}
        }

        /// <summary>
        /// name         : FlipX
        /// desc         : 좌우반전
        /// author       : 심우종
        /// create date  : 2020-06-26 16:52
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void FlipX()
        {
            gdViewer1.Rotate(RotateFlipType.RotateNoneFlipX);

            //if (_document.IsOpen)
            //{
            //    UpdateControlsOcrResultDiscarded();

            //    GdPictureStatus errorCode = _gdPictureImaging.Rotate(_document.ImageId,
            //        RotateFlipType.RotateNoneFlipX);
            //    gdViewer1.Redraw();
            //}
        }

        /// <summary>
        /// name         : RotateRight
        /// desc         : 오른쪽 90도
        /// author       : 심우종
        /// create date  : 2020-06-26 16:51
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void RotateRight()
        {
            gdViewer1.Rotate(RotateFlipType.Rotate90FlipNone);

            //if (_document.IsOpen)
            //{
            //    UpdateControlsOcrResultDiscarded();

            //    GdPictureStatus errorCode = _gdPictureImaging.Rotate(_document.ImageId,
            //        RotateFlipType.Rotate90FlipNone);
            //    gdViewer1.Redraw();
            //}
        }

        /// <summary>
        /// name         : RotateLeft
        /// desc         : 왼쪽 90도
        /// author       : 심우종
        /// create date  : 2020-06-26 16:50
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void RotateLeft()
        {
            gdViewer1.Rotate(RotateFlipType.Rotate270FlipNone);

            //if (_document.IsOpen)
            //{
            //    UpdateControlsOcrResultDiscarded();

            //    GdPictureStatus errorCode = _gdPictureImaging.Rotate(_document.ImageId,
            //        RotateFlipType.Rotate270FlipNone);
            //    gdViewer1.Redraw();
            //}



            //gdViewer1.Redraw();
            //gdViewer1.UpdateMainUi();
        }

        /// <summary>
        /// name         : FitPage
        /// desc         : 페이지 사이즈에 맞춤
        /// author       : 심우종
        /// create date  : 2020-06-26 16:29
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void FitPage()
        {
            gdViewer1.ZoomMode = ViewerZoomMode.ZoomModeFitToViewer;
        }

        /// <summary>
        /// name         : FitWidth
        /// desc         : 가로 사이즈에 맞춤
        /// author       : 심우종
        /// create date  : 2020-06-26 16:29
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void FitWidth()
        {
            gdViewer1.ZoomMode = ViewerZoomMode.ZoomModeWidthViewer;
        }

        /// <summary>
        /// name         : ZoomOut
        /// desc         : 축소 이벤트 처리
        /// author       : 심우종
        /// create date  : 2020-06-26 16:20
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ZoomOut()
        {
            gdViewer1.ZoomOUT();
        }


        /// <summary>
        /// name         : ZoomIn
        /// desc         : 확대 이벤트 처리
        /// author       : 심우종
        /// create date  : 2020-06-26 16:19
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ZoomIn()
        {
            gdViewer1.ZoomIN();
        }



        /// <summary>
        /// name         : Clear
        /// desc         : 화면을 초기화시킨다.
        /// author       : 심우종
        /// create date  : 2020-07-02 14:39
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void Clear()
        {
            _document.Close();
            UpdateControlsDocumentClosed();

            this.tlpCenter.Controls.Clear();

            this.ImageContainer = null;

            if (this.audioPlayer != null)
            {
                this.audioPlayer.AudioPlayerDispose();
                this.audioPlayer = null;
            }

            this.picDicomInfo.Visible = false;
        }


        AudioPlayer audioPlayer = null;
        RecordViewer recordViewer = null;

        /// <summary>
        /// name         : ShowWave
        /// desc         : 음성 파일 재생
        /// author       : 심우종
        /// create date  : 2020-07-13 10:38
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void ShowWave(string filePath)
        { 
            if (audioPlayer == null)
            {
                this.audioPlayer = new AudioPlayer();
                this.audioPlayer.BackColor = System.Drawing.Color.Black;
                this.audioPlayer.CurrentTime = "00:00";
                this.audioPlayer.IsPlaying = false;
                this.audioPlayer.IsReading = false;
                this.audioPlayer.Location = new System.Drawing.Point(122, 73);
                this.audioPlayer.Name = "audioPlayer1";
                this.audioPlayer.Size = new System.Drawing.Size(463, 133);
                this.audioPlayer.TabIndex = 0;
                this.audioPlayer.TotalTime = "00:00";
            }

            if (!this.tlpCenter.Controls.Contains(this.audioPlayer))
            {
                this.tlpCenter.Controls.Clear();
                this.tlpCenter.Controls.Add(this.audioPlayer);
                this.audioPlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
                this.tlpCenter.Update();
            }

            if (this.audioPlayer != null)
            {
                this.audioPlayer.ChangePlayObject(filePath);
            }
        }


        /// <summary>
        /// name         : ShowImage
        /// desc         : 이미지를 표시한다.
        /// author       : 심우종
        /// create date  : 2020-07-13 10:37
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void ShowImage(string filePath, ImageContainer container)
        {
            this.ImageContainer = container;
            this.filePath = filePath;
            ChildType childType = container.childType;

            //초기화
            if (this.audioPlayer != null)
            {
                this.audioPlayer.AudioPlayerDispose();
                //this.audioPlayer = null;
            }
            _document.Close();
            UpdateControlsDocumentClosed();



            //다이콤 tag 보기 버튼
            if (childType == ChildType.dicom)
            {
                this.picDicomInfo.Visible = true;
            }
            else
            {
                this.picDicomInfo.Visible = false;
            }

            //음성파일
            if (childType == ChildType.wave)
            {
                this.ShowWave(filePath);
            }
            else if (childType == ChildType.record)
            {
                this.ShowRecord(container.recordResult);
            }
            else
            {
                this.ShowGdPictureViewer(filePath);
            }

        }



        /// <summary>
        /// name         : ShowRecord
        /// desc         : 결과조회 표시
        /// author       : 심우종
        /// create date  : 2020-08-27 16:46
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void ShowRecord(string recordResult)
        {
            if (recordViewer == null)
            {
                recordViewer = new RecordViewer();
            }

            if (!this.tlpCenter.Controls.Contains(this.recordViewer))
            {
                this.tlpCenter.Controls.Clear();
                this.tlpCenter.Controls.Add(this.recordViewer);
                this.recordViewer.Dock = DockStyle.Fill;
                this.recordViewer.Margin = new Padding(45, 5, 45, 5);
                this.tlpCenter.Update();
            }

            if (this.recordViewer != null)
            {
                this.recordViewer.SetRecord(recordResult);
            }
        }



        /// <summary>
        /// name         : ShowGdPictureViewer
        /// desc         : GdPciture컨트롤에 표시한다.
        /// author       : 심우종
        /// create date  : 2020-07-13 11:06
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void ShowGdPictureViewer(string filePath)
        {
            if (!this.tlpCenter.Controls.Contains(this.gdViewer1))
            {
                this.tlpCenter.Controls.Clear();
                this.tlpCenter.Controls.Add(this.gdViewer1);
                this.gdViewer1.Dock = DockStyle.Fill;
                //this.audioPlayer.Anchor = System.Windows.Forms.AnchorStyles.None;
                this.tlpCenter.Update();
            }




            gdViewer1.ZoomMode = ViewerZoomMode.ZoomModeFitToViewer;
            gdViewer1.DocumentAlignment = ViewerDocumentAlignment.DocumentAlignmentTopCenter;


            //Cursor.Current = Cursors.WaitCursor;

            GdPictureStatus status = gdViewer1.DisplayFromFile(filePath);


            //_document.Close();
            //UpdateControlsDocumentClosed();
            //gdViewer1.ZoomMode = ViewerZoomMode.ZoomModeFitToViewer;
            //Cursor.Current = Cursors.WaitCursor;
            //bool bSuccess = _document.Load(filePath, PdfRasterizationResolution, gdViewer1);
            //Cursor.Current = Cursors.Default;

            //if (bSuccess)
            //{
            //    //UpdateControlsDocumentLoaded();
            //    //gdViewer1.DisplayFromGdPictureImage(_document.ImageId);
            //}
            //else
            //{
            //    //Cursor.Current = Cursors.Default;
            //    MessageBox.Show("Failed to load " + filePath, "Error", MessageBoxButtons.OK,
            //            MessageBoxIcon.Exclamation);
            //}
        }


        /// <summary>
        /// UpdateControlsDocumentLoaded updates the controls after the document has been loaded.
        /// </summary>
        private void UpdateControlsDocumentLoaded()
        {
            gdViewer1.DisplayFromGdPictureImage(_document.ImageId);

            updateImageInfo();
        }


        public void UpdateControlsDocumentClosed()
        {
            UpdateControlsOcrResultDiscarded();
            gdViewer1.CloseDocument();

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
        /// name         : Viewer_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-06-25 15:13
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void Viewer_Load(object sender, EventArgs e)
        {
            LicenseManager licenseManager = new LicenseManager();
            licenseManager.RegisterKEY("21185684790302862131615213975647244276");
            //Please replace XXX by a valid demo or commercial key.

            _gdPictureImaging = new GdPictureImaging();
            //_gdPictureOcr = new GdPictureOCR();
            _document = new ViewerDocument(_gdPictureImaging);

            this.InitGlobal(); //전역변수 설정

            //if (tbResouceFolder.Text.Length == 0)
            //{
            //    tbResouceFolder.Text = licenseManager.GetRedistPath() + "OCR\\";
            //}

            //OCRLanguage resourceLanguage;
            //UpdateLanguages(resourceFolder, new OCRLanguage[] { OCRLanguage.Dutch });

            UpdateControlsDocumentClosed();
            this.InitControl();
        }


        /// <summary>
        /// name         : InitControl
        /// desc         : 컨트롤 초기화
        /// author       : 심우종
        /// create date  : 2020-07-01 10:11
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitControl()
        {
            this.picChecked.Visible = false;

            if (isPopup == true) //팝업으로 열리는 경우
            {
                picChecked.Visible = false;
                this.picRight.Visible = false;
                this.picLeft.Visible = false;
            }

            this.picDicomInfo.Visible = false;
        }


        private void InitGlobal()
        {
            //기본...
            //int left = 139;
            //int top = 100;
            //int width = 679;
            //int height = 185;

            ////넓게 잡자..
            //this.g_left = 0;
            //this.g_top = 0;
            //this.g_width = 1011;
            //this.g_height = 491;

            ////디테일 체크용
            //this.g2_left = 58;
            //this.g2_top = 51;
            //this.g2_width = 838;
            //this.g2_height = 274;

            ////deatil 체크..
            //resourceFolder = System.Environment.CurrentDirectory + "\\" + "Resource\\";
        }

        private void Viewer_DragDrop(object sender, DragEventArgs e)
        {
            ImageContainer srcHitInfo = e.Data.GetData(typeof(ImageContainer)) as ImageContainer;
            if (srcHitInfo != null)
            {
                this.ShowImage(srcHitInfo.ImageButtonValue.strRowFilePath, srcHitInfo);

                if (srcHitInfo.IsSelected == false)
                {
                    srcHitInfo.IsSelected = true;
                    //srcHitInfo.IsLastSelected = true;
                }
                OnViewerImageChanged(srcHitInfo); //이미지가 변경되었음을 알린다.
            }
        }


        private void Viewer_DragOver(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
        }

        private void Viewer_SizeChanged(object sender, EventArgs e)
        {
            Point left = new Point();
            left.X = 15;
            left.Y = (hPanelControl1.Height / 2) - (picLeft.Height / 2);
            //btnLeft.Location = 

            picLeft.Location = left;

            Point right = new Point();
            right.X = hPanelControl1.Width - picRight.Width - 13;
            right.Y = (hPanelControl1.Height / 2) - ( picRight.Height / 2);
            picRight.Location = right;
        }


        /// <summary>
        /// name         : picRight_Click
        /// desc         : 오른쪽 이미지 이동
        /// author       : 심우종
        /// create date  : 2020-06-30 16:25
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void picRight_Click(object sender, EventArgs e)
        {
            if (this.OnRightImageClick != null)
            {
                this.OnRightImageClick();
            }
        }


        /// <summary>
        /// name         : picLeft_Click
        /// desc         : 왼쪽 이미지 이동
        /// author       : 심우종
        /// create date  : 2020-06-30 16:25
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void picLeft_Click(object sender, EventArgs e)
        {
            if (this.OnLeftImageClick != null)
            {
                this.OnLeftImageClick();
            }
        }



        /// <summary>
        /// name         : gdViewer1_Click
        /// desc         : 화면 선택시
        /// author       : 심우종
        /// create date  : 2020-07-01 10:03
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void gdViewer1_Click(object sender, EventArgs e)
        {
            if (OnViewSelected != null)
            {
                OnViewSelected(this);
            }
        }


        /// <summary>
        /// name         : gdViewer1_DoubleClick
        /// desc         : 뷰어 더블클릭시
        /// author       : 심우종
        /// create date  : 2020-07-10 13:48
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void gdViewer1_DoubleClick(object sender, EventArgs e)
        {
            ViewerPopup viewerPopup = new ViewerPopup();
            if (!string.IsNullOrEmpty(filePath))
            {
                viewerPopup.ShowImage(filePath, this.imageContainer);
                viewerPopup.ShowDialog();
            }

            
        }


        /// <summary>
        /// name         : picDicomInfo_Click
        /// desc         : Dimcom정보 조회 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-17 13:42
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void picDicomInfo_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();
            dt.Columns.Add("tagId", typeof(string));
            dt.Columns.Add("description", typeof(string));
            dt.Columns.Add("value", typeof(string));

            using (GdPictureImaging oGdPictureImaging = new GdPictureImaging())
            {
                int imageId = oGdPictureImaging.CreateGdPictureImageFromFile(this.filePath);
                int tagsCount = oGdPictureImaging.DicomGetTagsCount(imageId);
                for (int i = 0; i <= tagsCount - 1; i++)
                {
                    string tagID = "<" + String.Format("{0:X}", (oGdPictureImaging.DicomGetTagGroup(imageId, i))).PadLeft(4, '0') + "," + String.Format("{0:X}", (oGdPictureImaging.DicomGetTagElement(imageId, i))).PadLeft(4, '0') + ">";
                    //DataGridView1.Rows.Add(new object[] { tagID, oGdPictureImaging.DicomGetTagDescription(imageId, i), oGdPictureImaging.DicomGetTagValue(imageId, i) });

                    DataRow row = dt.NewRow();
                    row["tagId"] = tagID;
                    row["description"] = oGdPictureImaging.DicomGetTagDescription(imageId, i);
                    row["value"] = oGdPictureImaging.DicomGetTagValue(imageId, i);

                    dt.Rows.Add(row);

                }
            }

            if (dt != null && dt.Rows.Count > 0)
            {

                DicomTagViewPopup dicomTagViewPopup = new DicomTagViewPopup(dt);
                dicomTagViewPopup.ShowDialog();
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("Dicom Tag를 조회할수 없습니다.");
            }
        }

        public string SaveGdPictureToImage()
        {
            //gdViewer1.SaveDocumentToJPEG()
            //_gdPictureImaging
            string filePath = Global.tempFolderPath + "viewer1PrintTemp.jpg";
            //string filePath2 = Global.tempFolderPath + "viewer1PrintTemp222.jpg";

            //gdViewer1.SaveDocumentToPDF(filePath);

            //return "";

            //if (_gdPictureImaging.SaveAsJPEG(_document.ImageId, filePath) == GdPictureStatus.OK)
            //{
            //    return filePath;
            //}
            //else
            //{
            //    return "";
            //}

            //int m_ImageID = _gdPictureImaging.TiffCreateMultiPageFromGdPictureImage()





            if ((gdViewer1.SaveAnnotationsToPage() == GdPictureStatus.OK) &&
            (gdViewer1.BurnAnnotationsToPage(false) == GdPictureStatus.OK) &&
            (gdViewer1.SaveDocumentToJPEG(filePath, 100) == GdPictureStatus.OK))
            {
                //MessageBox.Show("Finished successfully!", "AnnotationManager.SaveDocumentToJPEG");
                return filePath;
            }
            else
            {
                return "";
            }
            
        }


        /// <summary>
        /// name         : picRight_MouseDown
        /// desc         : 오른쪽으로 이동 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-21 09:44
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void picRight_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.OnRightImageClick != null)
            {
                this.OnRightImageClick();
            }
        }


        /// <summary>
        /// name         : picLeft_MouseDown
        /// desc         : 왼쪽으로 이동 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-21 09:44
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void picLeft_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.OnLeftImageClick != null)
            {
                this.OnLeftImageClick();
            }
        }
    }
}
