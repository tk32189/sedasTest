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
using Sedas.ImageHelper;
using Integration_Viewer.DTO;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Drawing.Imaging;
using GdPicture14;
using DevExpress.Utils.Helpers;
using Sedas.Core;
using Sedas.DB;
using System.Drawing.Drawing2D;
using DevExpress.XtraTreeList;
using DevExpress.XtraGrid;
using DevExpress.XtraPrinting;
using System.Net.Mail;

namespace Integration_Viewer
{
    public partial class TabPage1 : DevExpress.XtraEditors.XtraUserControl
    {
        CoreLibrary core = new CoreLibrary();
        ImageHelper imageHelper = new ImageHelper();
        CallService callService = new CallService("10.10.221.72", "8180");
        FileTransfer ft = new FileTransfer();

        TopButtonList topButtonList = new TopButtonList();


        //int originalExStyle = -1;
        //bool enableFormLevelDoubleBuffering = true;

        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        if (originalExStyle == -1)
        //            originalExStyle = base.CreateParams.ExStyle;

        //        CreateParams cp = base.CreateParams;
        //        if (enableFormLevelDoubleBuffering)
        //            cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
        //        else
        //            cp.ExStyle = originalExStyle;

        //        return cp;
        //    }
        //}

        //public void TurnOffFormLevelDoubleBuffering()
        //{
        //    enableFormLevelDoubleBuffering = false;
        //    // this.MaximizeBox = true;
        //}



        public TabPage1()
        {
            InitializeComponent();

        }



        private void hSedasSImpleButtonBlue1_Click(object sender, EventArgs e)
        {
            //Main main = new Main();
            //main.ShowDialog();
        }


        /// <summary>
        /// name         : btnFileOpen_Click
        /// desc         : 파일열기 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-06-24 10:20
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnFileOpen_Click(object sender, EventArgs e)
        {
            InitThumbnail();
            LocalFileLoad(false);
        }

        private void hSedasSImpleButtonGreen3_Click(object sender, EventArgs e)
        {
            InitThumbnail();
            LocalFileLoad(true);
        }

        /// <summary>
        /// name         : InitThumbnail
        /// desc         : 썸네일 초기화
        /// author       : 심우종
        /// create date  : 2020-06-24 10:44
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitThumbnail()
        {
            //this.thumbnail.ThumbnailSize = new Size(128, 128);
            //this.thumbnail.ThumbnailSpacing = new Size(130, 130);
            //this.thumbnail.ThumbnailAlignment = GdPicture14.ThumbnailAlignment.ThumbnailAlignmentHorizontal;
            //this.thumbnail.VerticalScroll.Visible = false;

        }


        //이미지 사이즈
        const int imageSize_BigHeight = 140;
        const int imageSize_BigWidth = 170;
        const int imageSize_smallHeight = 90;
        const int imageSize_smallWidth = 100;

        private void LocalFileLoad(bool gdPic)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            //ofd.Filter = "jpg(*.*)|*.jpg*";
            DialogResult drs = ofd.ShowDialog();
            List<string> files = new List<string>();
            List<string> tempFiles = new List<string>();
            //string strPath = "";
            if (drs == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    tempFiles.Add(ofd.FileNames[i].ToString());
                }
            }

            //가상 폴더 없으면 생성
            if (!string.IsNullOrEmpty(Global.tempFolderPath))
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(Global.tempFolderPath);
                if (directoryInfo.Exists == false)
                {
                    directoryInfo.Create();
                }
            }


            List<FileInfoDTO> fileInfoList = new List<FileInfoDTO>();
            //선택한 파일은 임시 폴더에 복사하자... 실제로는 파일을 임시폴더로 내려받아야 함.
            if (tempFiles != null && tempFiles.Count > 0)
            {

                for (int i = 0; i < tempFiles.Count; i++)
                {
                    FileInfo info = new FileInfo(tempFiles[i]);

                    if (info.Exists)
                    {
                        //중복된 파일명 체크
                        string newFileName = core.DupFileRenameCheck(Global.tempFolderPath, info.Name, isNeedToDupCheck: true);

                        string newFile = Global.tempFolderPath + newFileName;
                        File.Copy(info.FullName, newFile);
                        //FileInfo newFileInfo = info.CopyTo(newFile);
                        files.Add(newFile);

                        FileInfoDTO file = new FileInfoDTO();
                        file.LocalFilePath = newFile;
                        fileInfoList.Add(file);
                    }

                }
            }



            this.AddChild(fileInfoList, gdPic: gdPic);




        }



        /// <summary>
        /// name         : AddChild
        /// desc         : 받아온 파일에 대해서 섬네일에 ADD한다.
        /// author       : 심우종
        /// create date  : 2020-07-03 13:09
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void AddChild(List<FileInfoDTO> files, bool gdPic = false)
        {
            List<ImageButtonValue> addedButtonValueList = new List<ImageButtonValue>();

            if (files != null && files.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    string filePath = files[i].LocalFilePath;
                    string type = files[i].Type;

                    //파일이 있는 형태인 경우
                    if (!string.IsNullOrEmpty(filePath))
                    {
                        FileInfo fileinfo = new FileInfo(filePath);
                        if (fileinfo.Exists == false) continue;



                        ImageButtonValue imageButtonValue = new ImageButtonValue();
                        imageButtonValue.strRowFilePath = filePath;
                        imageButtonValue.strOriginFilePath = filePath;
                        imageButtonValue.strRowFileName = fileinfo.Name;

                        addedButtonValueList.Add(imageButtonValue);

                        ImageContainer imageBox = new ImageContainer();

                        //다이콤 tag 보기 버튼
                        if (filePath.GetFileExtension().ToUpper() == "DCM")
                        {
                            imageBox.childType = ChildType.dicom;
                        }
                        else if (filePath.GetFileExtension().ToUpper() == "WAV")
                        {
                            imageBox.childType = ChildType.wave;
                        }
                        else
                        {
                            imageBox.childType = ChildType.image;
                        }

                        if (imageButtonValue != null)
                        {
                            imageBox.ImageButtonValue = imageButtonValue;
                        }

                        //treeListDTO
                        //트리에 바인딩된 DTO가 있으면 같이 넘겨주자.
                        if (this.treeListDTO != null && this.treeListDTO.Count > 0)
                        {
                            TreeDTO treeDTO = this.treeListDTO.Where(e => e.DtoId == files[i].DtoId).FirstOrDefault();
                            if (treeDTO != null)
                            {
                                imageBox.TreeDTO = treeDTO;
                            }
                        }

                        //이미지 파일을 섬네일 형태로 변경
                        Image image = imageHelper.SaveToThumbnailImage(filePath);

                        if (image == null)
                        {
                            //이미지가 아닌경우
                            //GetImage(info2.FullName, sizeType, itemSize)
                            Size itemSize = new Size(Convert.ToInt32(16), Convert.ToInt32(16));
                            IconSizeType sizeType = IconSizeType.ExtraLarge;
                            Image typeImage = FileSystemImageCache.Cache.GetImage(filePath, sizeType, itemSize);

                            imageBox.SetExtensionImage(typeImage);


                            if (GetFileExtension(imageButtonValue.strRowFilePath).ToUpper() == "PDF")
                            {
                                //PDF는 첫 페이지를 섬네일로 보여준다.
                                image = imageHelper.PdfThumbnail(imageButtonValue.strRowFilePath);
                            }

                        }


                        imageBox.SetImage(image, filePath);

                        int imageSize = 0;
                        if (imageSize == 0)
                        {
                            //이미지 크게
                            imageBox.Height = imageSize_BigHeight; // ;
                            imageBox.Width = imageSize_BigWidth; // ;

                        }
                        else if (imageSize == 1)
                        {
                            //이미지 작게
                            imageBox.Height = imageSize_smallHeight; // 90;
                            imageBox.Width = imageSize_smallWidth; // 100;
                        }

                        imageBox.onImageSelected += ImageBox_onImageSelected;

                        flwpnlThumbNail.Controls.Add(imageBox);
                        //flwpnlThumbNail.ScrollControlIntoView(imageBox);
                        ScrollIntoView(imageBox, "Right");
                        flwpnlThumbNail.Update();


                        if (gdPic == false)
                        {
                            //Office파일은 변환처리..
                            if (this.imageHelper.IsOfficeFileCheck(filePath) == true)
                            {
                                imageBox.OfficeFileTransferAsync();
                            }
                        }
                    }
                    else //파일이 없는 형태인 경우 처리(ex : 결과조회)
                    {
                        if (type == "999")
                        {
                            ImageButtonValue imageButtonValue = new ImageButtonValue();
                            imageButtonValue.strRowFilePath = filePath;
                            imageButtonValue.strOriginFilePath = filePath;
                            imageButtonValue.strRowFileName = "결과조회";

                            addedButtonValueList.Add(imageButtonValue);

                            ImageContainer imageBox = new ImageContainer();
                            imageBox.childType = ChildType.record;
                            imageBox.recordResult = files[i].RecordResult;
                            if (imageButtonValue != null)
                            {
                                imageBox.ImageButtonValue = imageButtonValue;
                            }

                            //treeListDTO
                            //트리에 바인딩된 DTO가 있으면 같이 넘겨주자.
                            if (this.treeListDTO != null && this.treeListDTO.Count > 0)
                            {
                                TreeDTO treeDTO = this.treeListDTO.Where(e => e.DtoId == files[i].DtoId).FirstOrDefault();
                                if (treeDTO != null)
                                {
                                    imageBox.TreeDTO = treeDTO;
                                }
                            }

                            Image image = global::Integration_Viewer.Properties.Resources.recordImage;
                            imageBox.SetImage(image, filePath);

                            int imageSize = 0;
                            if (imageSize == 0)
                            {
                                //이미지 크게
                                imageBox.Height = imageSize_BigHeight; // ;
                                imageBox.Width = imageSize_BigWidth; // ;

                            }
                            else if (imageSize == 1)
                            {
                                //이미지 작게
                                imageBox.Height = imageSize_smallHeight; // 90;
                                imageBox.Width = imageSize_smallWidth; // 100;
                            }

                            imageBox.onImageSelected += ImageBox_onImageSelected;

                            flwpnlThumbNail.Controls.Add(imageBox);
                            //flwpnlThumbNail.ScrollControlIntoView(imageBox);
                            ScrollIntoView(imageBox, "Right");
                            flwpnlThumbNail.Update();
                        }
                    }

                    
                }

            }
        }





        //string[] officeExcelType = { "xlsx", "xlsm", "xlsb", "xltx", "xml", "xlam", "xls" };
        //string[] officePowerPointType = { "pptx", "ppt", "pot" };
        //string[] officeWordType = { "doc", "docx" };
        ///// <summary>
        ///// name         : IsOfficeFileCheck
        ///// desc         : 오피스 파일여부를 체크한다.
        ///// author       : 심우종
        ///// create date  : 2020-07-01 10:49
        ///// update date  : 최종 수정일자 , 수정자, 수정개요
        ///// </summary> 
        //private bool IsOfficeFileCheck(string strPath)
        //{
        //    bool isOffice = false;
        //    string[] fileNameSplite = strPath.ToString().Split('.');
        //    if (fileNameSplite == null || fileNameSplite.Length > 0)
        //    {
        //        string lastValue = fileNameSplite[fileNameSplite.Length - 1].ToString();


        //        if (officeExcelType.Where(e => e == lastValue).Count() > 0)
        //        {
        //            isOffice = true;
        //        }

        //        if (officePowerPointType.Where(e => e == lastValue).Count() > 0)
        //        {
        //            isOffice = true;
        //        }

        //        if (officeWordType.Where(e => e == lastValue).Count() > 0)
        //        {
        //            isOffice = true;
        //        }
        //    }

        //    return isOffice;
        //}


        /// <summary>
        /// name         : GetFileExtension
        /// desc         : 파일 확장자 리턴
        /// author       : 심우종
        /// create date  : 2020-07-01 14:12
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private string GetFileExtension(string strPath)
        {
            string lastValue = "";
            string[] fileNameSplite = strPath.ToString().Split('.');
            if (fileNameSplite == null || fileNameSplite.Length > 0)
            {
                lastValue = fileNameSplite[fileNameSplite.Length - 1].ToString();
            }

            return lastValue;
        }


        /// <summary>
        /// 화면에 보이는 이미지 리스트를 리턴한다.
        /// </summary>
        /// <returns></returns>
        private List<ImageContainer> GetImageList(bool needToSelectedImage = false)
        {
            List<ImageContainer> imageList = new List<ImageContainer>();
            if (flwpnlThumbNail.Controls.Count > 0)
            {
                for (int i = 0; i < this.flwpnlThumbNail.Controls.Count; i++)
                {
                    if (this.flwpnlThumbNail.Controls[i] is ImageContainer)
                    {
                        if (needToSelectedImage == true)
                        {
                            ImageContainer imageContainer = this.flwpnlThumbNail.Controls[i] as ImageContainer;
                            if (imageContainer != null && imageContainer.IsSelected == true)
                            {
                                imageList.Add(this.flwpnlThumbNail.Controls[i] as ImageContainer);
                            }
                        }
                        else
                        {
                            imageList.Add(this.flwpnlThumbNail.Controls[i] as ImageContainer);
                        }
                    }
                }
            }

            return imageList;
        }


        /// <summary>
        /// name         : ImageBox_onImageSelected
        /// desc         : 섬네일에서 이미지 선택시
        /// author       : 심우종
        /// create date  : 2020-06-25 14:54
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ImageBox_onImageSelected(ImageContainer obj, string pressedKeyCode)
        {
            //MessageBox.Show("test", "test2");
            //return;
            if (obj == null) return;

            List<ImageContainer> imageList = this.GetImageList();
            if (imageList != null && imageList.Count > 0)
            {
                if (pressedKeyCode == "Control")
                {
                    //imageList.ForEach(item => { item.IsLastSelected = false; });

                    for (int i = 0; i < imageList.Count; i++)
                    {
                        ImageContainer image = imageList[i];
                        if (image == obj) //선택됨
                        {
                            //if (image.IsSelected == true)
                            //{
                            //    //image.IsSelected = false;
                            //}
                            //else
                            //{
                            //    image.IsSelected = true;
                            //}
                            image.IsSelected = true;
                            image.IsLastSelected = true;
                        }
                        else //선택안됨
                        {
                            if (image.IsLastSelected == true)
                            {
                                image.IsSelected = true;
                                image.IsLastSelected = false;
                            }
                            else
                            {
                                image.IsSelected = false;
                                image.IsLastSelected = false;
                            }
                        }
                    }
                }
                //else if (pressedKeyCode == "Shift")
                //{
                //    int lastSelectedIndex = -1;
                //    int targetIndex = -1;
                //    for (int i = 0; i < imageList.Count; i++)
                //    {
                //        ImageContainer image = imageList[i];

                //        if (image.IsLastSelected == true)
                //        {
                //            lastSelectedIndex = i;
                //        }

                //        if (image == obj)
                //        {
                //            targetIndex = i;
                //        }
                //    }





                //    if (lastSelectedIndex > -1 && targetIndex > -1)
                //    {
                //        //imageList.ForEach(item => { item.IsLastSelected = false; });

                //        int min = -1;
                //        int max = -1;

                //        if (lastSelectedIndex > targetIndex)
                //        {
                //            min = targetIndex;
                //            max = lastSelectedIndex;
                //        }
                //        else
                //        {
                //            min = lastSelectedIndex;
                //            max = targetIndex;
                //        }

                //        for (int i = 0; i < imageList.Count; i++)
                //        {
                //            ImageContainer image = imageList[i];

                //            if (i >= min && i <= max)
                //            {
                //                image.IsSelected = true;
                //            }
                //            else
                //            {
                //                image.IsSelected = false;
                //            }
                //        }
                //    }

                //}
                else
                {
                    //imageList.ForEach(item => { item.IsLastSelected = false; });

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
                            image.IsLastSelected = false;
                        }
                    }

                    //obj.DoDragDrop(obj, DragDropEffects.All);

                    //string filePath = obj.ImageButtonValue.strRowFilePath;
                    //if (!string.IsNullOrEmpty(filePath))
                    //{
                    //    this.ShowImage(filePath);
                    //}

                }

                ShowImageMulti();

            }
        }



        //private void ShowImage(string filePath)
        //{
        //    if (this.viewer != null)
        //    {
        //        this.viewer.ShowImage(filePath);
        //    }
        //}

        private void ShowImageMulti()
        {
            List<ImageContainer> imageList = this.GetImageList();



            if (imageList != null && imageList.Count > 0)
            {
                List<ImageContainer> selectedImage = imageList.Where(e => e.IsSelected == true).ToList();

                if (selectedImage != null && selectedImage.Count > 0)
                {
                    if (selectedImage.Count >= 2)
                    {
                        if (this.viewerCount == 1)
                        {
                            this.viewerCount = 2;
                            ViewSetting();
                        }

                        if (this.viewer != null)
                        {
                            this.viewer.ShowImage(selectedImage[0].ImageButtonValue.strRowFilePath, selectedImage[0]);
                        }

                        if (this.viewer2 != null)
                        {
                            this.viewer2.ShowImage(selectedImage[1].ImageButtonValue.strRowFilePath, selectedImage[1]);
                        }

                    }
                    else if (selectedImage.Count == 1)
                    {
                        if (this.viewerCount == 2 && this.topButtonList.ViewCount == 1)
                        {
                            this.viewerCount = 1;
                            ViewSetting();
                        }

                        if (this.viewer != null)
                        {
                            this.viewer.ShowImage(selectedImage[0].ImageButtonValue.strRowFilePath, selectedImage[0]);
                            ImageSelectFromViewer();
                        }
                    }

                }

            }

        }





        /// <summary>
        /// name         : AddToThumnamil
        /// desc         : 로컬 이미지를 썸네일에 추가한다.
        /// author       : 심우종
        /// create date  : 2020-06-24 10:26
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void AddToThumnamil(string filePath)
        {

            //System.Environment.CurrentDirectory + "\\Temp_image";
            //object file = tbFile.Text;
            bool isOfficeRead = false;
            string outResult = "";
            string[] fileNameSplite = filePath.Split('.');
            if (fileNameSplite == null || fileNameSplite.Length > 0)
            {

                string lastValue = fileNameSplite[fileNameSplite.Length - 1].ToString();
                if (lastValue == "doc" || lastValue == "docx" || lastValue == "xlsx" || lastValue == "xls" || lastValue == "pptx" || lastValue == "pot")
                {
                    isOfficeRead = true;

                    //office파일을 pdf로 변환
                    if (imageHelper.OfficeToPDF(filePath, out outResult) == true)
                    {
                        //if (!string.IsNullOrEmpty(outResult))
                        //{
                        //    _owner.DisplayFromFile(outResult);

                        //    List<string> imageList = new List<string>(); //저장된 이미지 경로 리턴 변수
                        //    //pdf파일을 이미지로 변환
                        //    if (this.imageHelper.PdfToImage(outResult, ref imageList) == true)
                        //    {

                        //    }
                        //}


                    }


                }
            }

            //this.thumbnail.AddItemFromFile(filePath);
            //this.thumbnail.




        }

        private void hSedasSImpleButtonGreen1_Click(object sender, EventArgs e)
        {
            ThumNailTest thum = new ThumNailTest();
            thum.ShowDialog();
        }

        //ImageThumbnail thumbnail;
        Viewer viewer;
        Viewer viewer2;

        public Viewer SelectedViewer
        {
            get
            {
                if (this.viewer2 != null && this.viewer2.IsSelected == true)
                {
                    return this.viewer2;
                }
                else if (this.viewer != null && this.viewer.IsSelected == true)
                {
                    return this.viewer;
                }
                else
                {
                    return this.viewer;
                }
            }
        }


        /// <summary>
        /// name         : TabPage1_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-06-24 15:29
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void TabPage1_Load(object sender, EventArgs e)
        {
            //if (thumbnail == null)
            //{
            //    thumbnail = new ImageThumbnail();

            //    tlpThumbnail.Controls.Add(thumbnail);
            //    thumbnail.Dock = DockStyle.Fill;
            //}

            //this.flwpnlThumbNail.AutoScroll = false;
            //this.flwpnlThumbNail.HorizontalScroll.Maximum = 0;
            //this.flwpnlThumbNail.HorizontalScroll.Visible = false;
            //this.flwpnlThumbNail.VerticalScroll.Maximum = 0;
            //this.flwpnlThumbNail.VerticalScroll.Visible = false;
            //this.flwpnlThumbNail.AutoScroll = true;


            //this.flwpnlThumbNail.HorizontalScroll.Maximum = 100;
            //this.flwpnlThumbNail.VerticalScroll.Maximum = 100;

            //BufferedGraphicsContext myContext;
            //myContext = new BufferedGraphicsContext();

            //DoubleBuffered = true;

            ViewSetting();
            InitControl();
        }


        /// <summary>
        /// name         : InitControl
        /// desc         : 컨트롤 초기화
        /// author       : 심우종
        /// create date  : 2020-07-01 10:13
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitControl()
        {
            this.viewerCount = 1;
            this.topButtonList.SetViewCountControlImage(1); //한페이지 보기

            //--------------------------------------------------
            //검색 컨트롤 초기화
            //--------------------------------------------------
            DateTime current = DateTime.Now;
            this.txtStartDt.DateTime = current;
            this.txtEndDt.DateTime = current;

            //--------------------------------------------------
            // 상단 버튼 설정
            //--------------------------------------------------
            this.tlpTopNew.Controls.Add(this.topButtonList);
            topButtonList.Dock = DockStyle.Fill;
            topButtonList.Update();
            topButtonList.OnButtonClick += TopButtonList_OnButtonClick;

        }


        /// <summary>
        /// name         : TopButtonList_OnButtonClick
        /// desc         : 탑 버튼 클릭 이벤트 처리
        /// author       : 심우종
        /// create date  : 2020-07-10 14:42
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void TopButtonList_OnButtonClick(string buttonName, string param)
        {
            if (buttonName == "picViewCount1")
            {
                ViewCountChanged();
                ImageSelectFromViewer();
            }
            else if (buttonName == "picViewCount2")
            {
                ViewCountChanged();
                ImageSelectFromViewer();
            }

            if (this.SelectedViewer != null)
            {
                this.SelectedViewer.CallMethod(buttonName, param);
            }
        }


        /// <summary>
        /// name         : ViewSetting
        /// desc         : View영역 초기화
        /// author       : 심우종
        /// create date  : 2020-07-01 10:14
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ViewSetting()
        {
            if (this.viewerCount == 1)
            {
                this.tlpViewer.ColumnStyles[1].SizeType = SizeType.Absolute;
                this.tlpViewer.ColumnStyles[1].Width = 0;

                if (this.viewer == null)
                {
                    this.viewer = new Viewer();
                    this.viewer.OnViewerImageChanged += Viewer_OnViewerImageChanged;
                    this.viewer.OnRightImageClick += Viewer_OnRightImageClick;
                    this.viewer.OnLeftImageClick += Viewer_OnLeftImageClick;
                    this.viewer.OnViewSelected += Viewer_OnViewSelected;
                    this.tlpViewer.Controls.Add(viewer, 0, 0);
                    viewer.Dock = DockStyle.Fill;
                }

            }
            else if (this.viewerCount == 2)
            {
                this.tlpViewer.ColumnStyles[1].SizeType = SizeType.Percent;
                this.tlpViewer.ColumnStyles[1].Width = 50;

                this.tlpViewer.Update();

                if (this.viewer2 == null)
                {
                    this.viewer2 = new Viewer();
                    this.viewer2.OnViewerImageChanged += Viewer_OnViewerImageChanged;
                    this.viewer2.OnRightImageClick += Viewer2_OnRightImageClick;
                    this.viewer2.OnLeftImageClick += Viewer2_OnLeftImageClick;
                    this.viewer2.OnViewSelected += Viewer_OnViewSelected;
                    this.tlpViewer.Controls.Add(viewer2, 1, 0);
                    viewer2.Dock = DockStyle.Fill;
                }

            }

        }


        /// <summary>
        /// name         : Viewer_OnViewSelected
        /// desc         : 뷰어 선택시
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void Viewer_OnViewSelected(Viewer obj)
        {
            if (obj == null) return;

            if (viewer != null)
            {
                if (viewer == obj)
                {
                    viewer.IsSelected = true;
                }
                else
                {
                    viewer.IsSelected = false;
                }

            }

            if (viewer2 != null)
            {
                if (viewer2 == obj)
                {
                    viewer2.IsSelected = true;
                }
                else
                {
                    viewer2.IsSelected = false;
                }
            }

        }


        /// <summary>
        /// name         : Viewer2_OnLeftImageClick
        /// desc         : View2에서 왼쪽 이미지 변경 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-06-30 16:30
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void Viewer2_OnLeftImageClick()
        {
            //throw new NotImplementedException();
            this.OnLeftImageClick(viewer2);
        }

        /// <summary>
        /// name         : Viewer2_OnRightImageClick
        /// desc         : View2에서 오른쪽 이미지 변경 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-06-30 16:30
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void Viewer2_OnRightImageClick()
        {
            //throw new NotImplementedException();
            this.OnRightImageClick(viewer2);
        }

        /// <summary>
        /// name         : Viewer_OnLeftImageClick
        /// desc         : View1에서 왼쪽 이미지 변경 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-06-30 16:30
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void Viewer_OnLeftImageClick()
        {
            //throw new NotImplementedException();
            this.OnLeftImageClick(viewer);
        }

        /// <summary>
        /// name         : Viewer_OnRightImageClick
        /// desc         : View1에서 오른쪽 이미지 변경 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-06-30 16:30
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void Viewer_OnRightImageClick()
        {
            //throw new NotImplementedException();
            this.OnRightImageClick(viewer);
        }


        /// <summary>
        /// name         : OnRightImageClick
        /// desc         : 오른쪽 이미지 변경 이벤트 처리
        /// author       : 심우종
        /// create date  : 2020-06-30 16:31
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void OnRightImageClick(Viewer viewer)
        {
            if (viewer == null) return;

            if (viewer.ImageContainer == null) return;

            List<ImageContainer> imageList = this.GetImageList();

            if (imageList != null && imageList.Count > 0)
            {
                for (int i = 0; i < imageList.Count; i++)
                {
                    ImageContainer item = imageList.ElementAt(i);

                    if (item == viewer.ImageContainer)
                    {

                        int nextValue = i + 1;
                        if (nextValue > imageList.Count - 1)
                        {
                            nextValue = 0;
                        }

                        ImageContainer selectedImage = null;
                        for (int j = 0; j < imageList.Count; j++)
                        {
                            if (imageList.ElementAt(nextValue).Visible == true)
                            {
                                selectedImage = imageList.ElementAt(nextValue);
                                break;
                            }
                            else
                            {
                                nextValue = nextValue + 1;
                                if (nextValue > imageList.Count - 1)
                                {
                                    nextValue = 0;
                                }
                            }
                        }

                        //ImageContainer selectedImage = imageList.ElementAt(nextValue);

                        if (selectedImage != null)
                        {
                            viewer.ShowImage(selectedImage.ImageButtonValue.strRowFilePath, selectedImage);

                            if (selectedImage.IsSelected == false)
                            {
                                selectedImage.IsSelected = true;
                                selectedImage.IsLastSelected = true;
                            }

                            this.ImageSelectFromViewer(); //이미지 선택 재변경
                            ScrollIntoView(selectedImage, "Right");
                            break;

                        }

                    }
                }
            }


        }


        /// <summary>
        /// name         : ScrollIntoView
        /// desc         : 현재 선택된 이미지로 포커스를 이동한다.
        /// author       : 심우종
        /// create date  : 2020-07-01 09:32
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ScrollIntoView(ImageContainer selectedImage, string type)
        {
            if (selectedImage == null) return;

            try
            {
                int xPoint = 0;
                if (this.flwpnlThumbNail.Controls.Count > 0)
                {
                    for (int i = 0; i < this.flwpnlThumbNail.Controls.Count; i++)
                    {
                        if (this.flwpnlThumbNail.Controls[i] is ImageContainer)
                        {
                            ImageContainer image = this.flwpnlThumbNail.Controls[i] as ImageContainer;
                            if (image != null)
                            {
                                if (image == selectedImage)
                                {
                                    xPoint = xPoint + image.Width;
                                    break;
                                }
                                else
                                {
                                    xPoint = xPoint + image.Width;
                                }
                            }
                        }
                    }

                    int gap = xtraScrollableControl1.HorizontalScroll.LargeChange / 5;
                    int currentStartPoint = xtraScrollableControl1.HorizontalScroll.Value + gap;
                    int currentEndPoint = xtraScrollableControl1.HorizontalScroll.Value + xtraScrollableControl1.Width - gap;

                    if (xPoint > currentStartPoint && xPoint < currentEndPoint)
                    {
                        //PASS
                    }
                    else
                    {
                        //if ( xPoint )

                        if (type == "Right")
                        {
                            xPoint = xPoint - (gap * 4);
                        }
                        else if (type == "Left")
                        {
                            xPoint = xPoint - (gap * 1);
                        }


                        if (xtraScrollableControl1.HorizontalScroll.Maximum < xPoint)
                        {
                            xtraScrollableControl1.HorizontalScroll.Value = xtraScrollableControl1.HorizontalScroll.Maximum;
                        }
                        else if (xPoint < 0)
                        {
                            xtraScrollableControl1.HorizontalScroll.Value = 0;
                        }
                        else
                        {
                            xtraScrollableControl1.HorizontalScroll.Value = xPoint;
                        }
                    }

                }
            }
            catch
            {
                //오류 무시
            }


        }

        /// <summary>
        /// name         : OnLeftImageClick
        /// desc         : 왼쪽 이미지 변경 이벤트 처리
        /// author       : 심우종
        /// create date  : 2020-06-30 16:31
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void OnLeftImageClick(Viewer viewer)
        {
            if (viewer == null) return;

            if (viewer.ImageContainer == null) return;

            List<ImageContainer> imageList = this.GetImageList();

            if (imageList != null && imageList.Count > 0)
            {
                for (int i = 0; i < imageList.Count; i++)
                {
                    ImageContainer item = imageList.ElementAt(i);

                    if (item == viewer.ImageContainer)
                    {


                        int nextValue = i - 1;
                        if (nextValue < 0)
                        {
                            nextValue = imageList.Count - 1;
                        }

                        ImageContainer selectedImage = null;
                        for (int j = 0; j < imageList.Count; j++)
                        {
                            if (imageList.ElementAt(nextValue).Visible == true)
                            {
                                selectedImage = imageList.ElementAt(nextValue);
                                break;
                            }
                            else
                            {
                                nextValue = nextValue - 1;
                                if (nextValue < 0)
                                {
                                    nextValue = imageList.Count - 1;
                                }
                            }
                        }


                        //int nextValue = i - 1;
                        //if (nextValue < 0)
                        //{
                        //    nextValue = imageList.Count - 1;
                        //}

                        //ImageContainer selectedImage = imageList.ElementAt(nextValue);

                        if (selectedImage != null)
                        {
                            viewer.ShowImage(selectedImage.ImageButtonValue.strRowFilePath, selectedImage);

                            if (selectedImage.IsSelected == false)
                            {
                                selectedImage.IsSelected = true;
                                selectedImage.IsLastSelected = true;
                            }

                            this.ImageSelectFromViewer(); //이미지 선택 재변경
                            ScrollIntoView(selectedImage, "Left");
                            break;

                        }

                    }
                }
            }
        }


        /// <summary>
        /// name         : Viewer_OnViewerImageChanged
        /// desc         : 뷰어에서 이미지 변경 이벤트 발생시
        /// author       : 심우종
        /// create date  : 2020-06-29 10:53
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary>  
        private void Viewer_OnViewerImageChanged(ImageContainer image)
        {

            List<ImageContainer> imageList = this.GetImageList();

            if (image != null && imageList != null && imageList.Count() > 0)
            {
                for (int i = 0; i < imageList.Count; i++)
                {
                    if (imageList.ElementAt(i) == image)
                    {
                        image.IsLastSelected = true;
                    }
                    else
                    {
                        imageList.ElementAt(i).IsLastSelected = false;
                    }
                }
            }

            this.ImageSelectFromViewer(); //이미지 선택 재변경
        }


        /// <summary>
        /// name         : ImageSelectFromViewer
        /// desc         : 뷰어에 보이는 이미지에 맞게 이미지 선택을 바꾼다.
        /// author       : 심우종
        /// create date  : 2020-06-29 11:00
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ImageSelectFromViewer()
        {
            List<ImageContainer> imageList = this.GetImageList();
            imageList.ForEach(item =>
            {
                item.IsSelected = false;
            });

            if (this.viewerCount == 1)
            {
                if (this.viewer != null && this.viewer.ImageContainer != null)
                {
                    this.viewer.ImageContainer.IsSelected = true;
                }

            }
            else if (this.viewerCount == 2)
            {
                if (this.viewer != null && this.viewer.ImageContainer != null)
                {
                    this.viewer.ImageContainer.IsSelected = true;
                }

                if (this.viewer2 != null && this.viewer2.ImageContainer != null)
                {
                    this.viewer2.ImageContainer.IsSelected = true;
                }
            }

        }

        int viewerCount = 1;



        private void FlwpnlThumbNail_MouseWheel(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //flwpnlThumbNail.HorizontalScroll.Value = flwpnlThumbNail.HorizontalScroll.Value + 10;
            //this.flwpnlThumbNail.AutoScrollPosition
            //this.flwpnlThumbNail.AutoScrollPosition = Point.Empty;
            this.flwpnlThumbNail.AutoScrollPosition = new Point(this.flwpnlThumbNail.AutoScrollPosition.X - 10, this.flwpnlThumbNail.AutoScrollPosition.Y);
            //this.flwpnlThumbNail.HorizontalScroll.Value = this.flwpnlThumbNail.HorizontalScroll.Value + 10;
            this.flwpnlThumbNail.PerformLayout();
        }

        private void xtraScrollableControl1_Scroll(object sender, XtraScrollEventArgs e)
        {
            //if (!System.Windows.Forms.SystemInformation.TerminalServerSession)
            //{
            //    Type dgvType = xtraScrollableControl1.GetType();
            //    PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
            //      BindingFlags.Instance | BindingFlags.NonPublic);
            //    pi.SetValue(xtraScrollableControl1, e.NewValue, null);
            //}
        }

        private void cbZoom_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbZoom_Validating(object sender, CancelEventArgs e)
        {

        }






        private void TopButtonClick()
        {

        }


        /// <summary>
        /// name         : rdoViewCount_CheckedChanged
        /// desc         : 뷰 카운트 설정 라디오버튼 값 변경시
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void rdoViewCount_CheckedChanged(object sender, EventArgs e)
        {
            ViewCountChanged();
            ImageSelectFromViewer();
        }


        /// <summary>
        /// name         : ViewCountChanged
        /// desc         : 화면에 표시될 뷰 갯수를 설정한다.
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ViewCountChanged()
        {
            if (this.topButtonList.ViewCount == 1)
            {
                if (this.viewerCount == 2)
                {
                    this.viewerCount = 1;
                    ViewSetting();
                }

                this.Viewer_OnViewSelected(this.viewer); //1페이지 보기이면 무조건 첫번쨰 뷰를 선택
            }
            else if (topButtonList.ViewCount == 2)
            {
                if (this.viewerCount == 1)
                {
                    this.viewerCount = 2;
                    ViewSetting();
                }
            }
        }

        private void hPictureEdit4_MouseDown(object sender, MouseEventArgs e)
        {

        }


        /// <summary>
        /// name         : btnWorkListClose_Click
        /// desc         : 워크리스트 Close 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-06-30 16:14
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnWorkListClose_Click(object sender, EventArgs e)
        {

            if (this.tlpAll.ColumnStyles[0].Width == 0F)
            {
                this.tlpAll.ColumnStyles[0].SizeType = SizeType.Absolute;
                this.tlpAll.ColumnStyles[0].Width = 350F;
            }
            else
            {
                this.tlpAll.ColumnStyles[0].SizeType = SizeType.Absolute;
                this.tlpAll.ColumnStyles[0].Width = 0F;
            }
        }

        /// <summary>
        /// 임시폴더 삭제
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hSedasSImpleButtonGreen2_Click(object sender, EventArgs e)
        {
            this.AllDataClear();
        }



        /// <summary>
        /// name         : AllDataClear
        /// desc         : 화면에 바인딩된 데이터 클리어
        /// author       : 심우종
        /// create date  : 2020-07-03 11:34
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void AllDataClear()
        {


            if (this.viewer != null)
            {
                this.viewer.Clear();
            }

            if (this.viewer2 != null)
            {
                this.viewer2.Clear();
            }

            //섬네일 클리어
            List<ImageContainer> imageList = GetImageList();
            if (imageList != null && imageList.Count() > 0)
            {
                for (int i = 0; i < imageList.Count(); i++)
                {
                    ImageContainer image = imageList.ElementAt(i);
                    ImageContainerClear(image);
                }
            }

            this.flwpnlThumbNail.Controls.Clear();

            //트리리스트 클리어
            treeList1.DataSource = null;
            treeList1.ForceInitialize();


            DirectoryInfo directoryInfo = new DirectoryInfo(Global.tempFolderPath);


            //기존에 있던 임시파일은 모두 삭제
            FileInfo[] existsFiles = directoryInfo.GetFiles();
            if (existsFiles != null && existsFiles.Count() > 0)
            {
                for (int i = 0; i < existsFiles.Length; i++)
                {
                    try
                    {
                        existsFiles.ElementAt(i).Attributes = FileAttributes.Normal;
                        existsFiles.ElementAt(i).Delete();
                    }
                    catch
                    {
                        //오류무시;;;
                    }

                }

                //existsFiles.ToList().ForEach(item =>
                //{
                //    item.Attributes = FileAttributes.Normal;
                //    item.Delete();
                //});
            }
        }


        /// <summary>
        /// name         : ImageContainerClear
        /// desc         : 이미지 컨테이너 초기화
        /// author       : 심우종
        /// create date  : 2020-07-02 14:42
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ImageContainerClear(ImageContainer image)
        {
            //이벤트 연결 해제
            image.onImageSelected -= ImageBox_onImageSelected;
            image.Clear();
            image.Dispose();
        }


        /// <summary>
        /// name         : btnPeriod_Click
        /// desc         : 기간별 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-02 17:20
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnPeriod_Click(object sender, EventArgs e)
        {
            if (sender is Sedas.Control.HSimpleButton)
            {
                Sedas.Control.HSimpleButton button = sender as Sedas.Control.HSimpleButton;
                string value = button.Text.ToString();

                int period = 0;
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Contains("Y"))
                    {
                        string num = value.Replace("Y", "");
                        if (num.ToIntOrNull() != null)
                        {
                            period = num.ToInt() * 365;
                        }
                    }
                    else if (value.Contains("M"))
                    {
                        string num = value.Replace("M", "");
                        if (num.ToIntOrNull() != null)
                        {
                            period = num.ToInt() * 30;
                        }
                    }
                    else if (value.Contains("W"))
                    {
                        string num = value.Replace("W", "");
                        if (num.ToIntOrNull() != null)
                        {
                            period = num.ToInt() * 7;
                        }
                    }
                    else if (value.Contains("D"))
                    {
                        string num = value.Replace("D", "");
                        if (num.ToIntOrNull() != null)
                        {
                            period = num.ToInt();
                        }
                    }
                    else if (value == "개원부터")
                    {

                    }
                }

                if (period > 0)
                {
                    DateTime current = DateTime.Now;

                    this.txtEndDt.DateTime = current;
                    this.txtStartDt.DateTime = current.AddDays(-period);
                }
            }
        }


        /// <summary>
        /// name         : btnSearch_Click
        /// desc         : 조회버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-03 10:26
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string ptoNo = this.txtPtoNo.Text;
            string ptNo = this.txtPtNo.Text;
            string startDt = this.txtStartDt.DateTime.ToString("yyyyMMdd");
            string endDt = this.txtEndDt.DateTime.ToString("yyyyMMdd") + "999999";

            KeyValueData param = new KeyValueData();
            if (!string.IsNullOrEmpty(ptoNo))
            {
                param.Add("Data1", ptoNo);
            }

            if (!string.IsNullOrEmpty(ptNo))
            {
                param.Add("Data2", ptNo);
            }

            if (!string.IsNullOrEmpty(startDt) && !string.IsNullOrEmpty(endDt))
            {
                param.Add("Data3", startDt);
                param.Add("Data4", endDt);
            }

            CallResultData result = this.callService.SelectSql("reqGetIntegViewerData", param);

            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;
                grdWorkList.DataSource = dt;
            }
            else
            {
                //실패에 대한 처리
            }
        }


        /// <summary>
        /// name         : grvWorkList_DoubleClick
        /// desc         : 워크 리스트 더블클릭시
        /// author       : 심우종
        /// create date  : 2020-07-03 11:21
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void grvWorkList_DoubleClick(object sender, EventArgs e)
        {
            this.AllDataClear(); //데이터 클리어
            DataRow row = grvWorkList.GetFocusedDataRow();

            if (row == null) return;

            this.GetChildData(row["studyId"].ToString(), row["ptNo"].ToString(), row["ptoNo"].ToString()) ;
        }
        BindingList<TreeDTO> treeListDTO;

        /// <summary>
        /// name         : SetTreeList
        /// desc         : 선택한 병리번호에 대한 트리 리스트 설정
        /// author       : 심우종
        /// create date  : 2020-07-06 10:31
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SetTreeList(List<FileInfoDTO> fileList)
        {
            //case "조직병리":
            //                    imagetableTYPE = "0";
            //                    break;
            //                case "현미경":
            //                    imagetableTYPE = "1";
            //                    break;
            //                case "분자병리":
            //                    imagetableTYPE = "2";
            //                    break;

            int id = 1;
            if (fileList != null && fileList.Count > 0)
            {

                BindingList<TreeDTO> treeDTO = new BindingList<TreeDTO>();



                List<FileInfoDTO> giList = fileList.Where(e => e.Type.ToString() == "0" && !string.IsNullOrEmpty(e.LocalFilePath)).ToList();
                List<FileInfoDTO> miList = fileList.Where(e => e.Type.ToString() == "1" && !string.IsNullOrEmpty(e.LocalFilePath)).ToList();
                List<FileInfoDTO> oiList = fileList.Where(e => e.Type.ToString() == "2" && !string.IsNullOrEmpty(e.LocalFilePath)).ToList();
                List<FileInfoDTO> waveList = fileList.Where(e => e.Type.ToString() == "4" && !string.IsNullOrEmpty(e.LocalFilePath)).ToList();
                List<FileInfoDTO> recordList = fileList.Where(e => e.Type.ToString() == "999").ToList();

                if (recordList != null && recordList.Count() > 0)
                {
                    treeDTO.Add(new TreeDTO() { ParentID = 0, ID = 100999, Name = "결과조회", Checked = true });

                    for (int i = 0; i < recordList.Count; i++)
                    {
                        FileInfoDTO row = recordList[i];
                        treeDTO.Add(new TreeDTO() { ParentID = 100999, ID = id++, FilePath = "", Name = row.FileName, DtoId = row.DtoId, Checked = true });
                    }
                }


                if (giList != null && giList.Count() > 0)
                {
                    treeDTO.Add(new TreeDTO() { ParentID = 0, ID = 100000, Name = "조직병리", Checked = true });

                    for (int i = 0; i < giList.Count; i++)
                    {
                        FileInfoDTO row = giList[i];
                        treeDTO.Add(new TreeDTO() { ParentID = 100000, ID = id++, FilePath = row.LocalFilePath.ToString(), Name = row.FileName, DtoId = row.DtoId, Checked = true });
                    }
                }

                if (giList != null && miList.Count() > 0)
                {
                    treeDTO.Add(new TreeDTO() { ParentID = 0, ID = 100001, Name = "현미경", Checked = true });

                    for (int i = 0; i < miList.Count; i++)
                    {
                        FileInfoDTO row = miList[i];
                        treeDTO.Add(new TreeDTO() { ParentID = 100001, ID = id++, FilePath = row.LocalFilePath.ToString(), Name = row.FileName, DtoId = row.DtoId, Checked = true });
                    }
                }

                if (giList != null && oiList.Count() > 0)
                {
                    treeDTO.Add(new TreeDTO() { ParentID = 0, ID = 100002, Name = "분자병리", Checked = true });

                    for (int i = 0; i < oiList.Count; i++)
                    {
                        FileInfoDTO row = oiList[i];
                        treeDTO.Add(new TreeDTO() { ParentID = 100002, ID = id++, FilePath = row.LocalFilePath.ToString(), Name = row.FileName, DtoId = row.DtoId, Checked = true });
                    }
                }

                if (giList != null && waveList.Count() > 0)
                {
                    treeDTO.Add(new TreeDTO() { ParentID = 0, ID = 100004, Name = "음성녹음", Checked = true });

                    for (int i = 0; i < waveList.Count; i++)
                    {
                        FileInfoDTO row = waveList[i];
                        treeDTO.Add(new TreeDTO() { ParentID = 100004, ID = id++, FilePath = row.LocalFilePath.ToString(), Name = row.FileName, DtoId = row.DtoId, Checked = true });
                    }
                }

                




                treeList1.DataSource = treeDTO;
                treeList1.ForceInitialize();
                treeList1.OptionsView.RootCheckBoxStyle = NodeCheckBoxStyle.Check;

                if (treeList1.Nodes.Count > 0)
                {
                    for (int i = 0; i < treeList1.Nodes.Count; i++)
                    {
                        treeList1.Nodes[i].ChildrenCheckBoxStyle = NodeCheckBoxStyle.Check;
                    }
                    //treeList1.Nodes[0].ChildrenCheckBoxStyle = NodeCheckBoxStyle.Check;
                }

                //treeList1.Nodes[1].ChildrenCheckBoxStyle = NodeCheckBoxStyle.Radio;
                //treeList1.Nodes[2].ChildrenCheckBoxStyle = NodeCheckBoxStyle.Radio;
                //treeList1.Nodes[3].ChildrenCheckBoxStyle = NodeCheckBoxStyle.Radio;
                treeList1.ExpandAll();

                this.treeListDTO = treeDTO;
            }
            else
            {
                this.treeListDTO = null;
            }
        }



        /// <summary>
        /// name         : SelectKuhRecord
        /// desc         : 건대병원 결과조회
        /// author       : 심우종
        /// create date  : 2020-08-27 15:36
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private DataTable SelectKuhRecord(string ptno)
        {
            string ptoNo = "";
            DataRow row = grvWorkList.GetFocusedDataRow();
            if (row != null)
            {
                if (row.Table.Columns.Contains("ptoNo"))
                {
                    ptoNo = row["ptoNo"].ToString();
                }
            }

            if (string.IsNullOrEmpty(ptoNo)) return null;


            KeyValueData param = new KeyValueData();
            param.Add("Data1", ptoNo);


            CallResultData result = this.callService.SelectSql("reqGetGyeolGwa", param);

            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                if (result.resultDataList != null && result.resultDataList.Count > 0)
                {
                    DataTable dt = result.resultDataList[0];

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        return dt;
                    }
                }

                //grdWorkList.DataSource = dt;
            }
            else
            {
                //실패에 대한 처리
            }

            return null;
        }


        /// <summary>
        /// name         : GetChildData
        /// desc         : 
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void GetChildData(string studyId, string ptNo, string ptoNo)
        {
            if (string.IsNullOrEmpty(studyId) || string.IsNullOrEmpty(ptNo)) return;


            List<FileInfoDTO> totalFileInfoList = new List<FileInfoDTO>();

            //1. KUH 결과조회
            DataTable recordDt = SelectKuhRecord(ptNo);

            if (recordDt != null && recordDt.Rows.Count > 0)
            {
                FileInfoDTO fileDTO = new FileInfoDTO();
                fileDTO.DtoId = 999;


                string recordResult = SetRecord(recordDt, ptoNo); 


                fileDTO.RecordResult = recordResult;
                fileDTO.FileName = "결과조회";
                fileDTO.Type = "999";
                //fileDTO.RootPath = row["rootPath"].ToString();
                //fileDTO.FilePath = row["filePath"].ToString();
                //fileDTO.SendStat = row["sendStat"].ToString();
                //fileDTO.SerialNo = row["serialNo"].ToString();
                //fileDTO.StudyId = row["studyId"].ToString();
                //fileDTO.Type = row["type"].ToString();
                //fileDTO.Seq = row["seq"].ToString();
                totalFileInfoList.Add(fileDTO);
            }


            //2. 세다스 차일드 정보 점검
            KeyValueData param = new KeyValueData();
            param.Add("Data1", studyId);
            CallResultData result = this.callService.SelectSql("reqGetIntegViewerChild", param);

            if (result.resultState == ResultState.OK)
            {
                //가상 폴더 없으면 생성
                if (!string.IsNullOrEmpty(Global.tempFolderPath))
                {
                    DirectoryInfo directoryInfo = new DirectoryInfo(Global.tempFolderPath);
                    if (directoryInfo.Exists == false)
                    {
                        directoryInfo.Create();
                    }
                }



                //데이터 조회 성공
                DataTable dt = result.resultData;


                if (dt != null && dt.Rows.Count > 0)
                {
                    List<FileInfoDTO> fileInfoList = InitChildData(dt);
                    List<string> files = new List<string>();

                    for (int i = 0; i < fileInfoList.Count; i++)
                    {
                        FileInfoDTO dto = fileInfoList[i];

                        if (!string.IsNullOrEmpty(dto.FilePath))
                        {


                            //-----------------------------------------------
                            //이전 데이터 파일 경로 맞추는 작업 필요함!!!!!!!!!!!!!!
                            //-----------------------------------------------

                            string type = dto.Type;
                            string filePath = dto.FilePath;
                            if (type == "0" || type == "1" || type == "2")
                            {
                                if (filePath.Substring(0, 8) == "Snapshot")
                                {
                                    //PASS
                                }
                                else if (filePath.Substring(0, 9).ToLower() == "imagedata")
                                {
                                    //PASS
                                }
                                else
                                {
                                    filePath = "imagedata" + "\\" + filePath;
                                }

                            }

                            //-----------------------------------------------
                            //이전 데이터 파일 경로 맞추는 작업 필요함!!!!!!!!!!!!!! END
                            //-----------------------------------------------



                            string savedFilePathAndName = "";
                            if (ft.FileDownLoad(filePath, Global.tempFolderPath, ref savedFilePathAndName) == true)
                            {
                                //files.Add(savedFilePathAndName);


                                FileInfo file = new FileInfo(savedFilePathAndName);
                                if (file.Exists == true)
                                {
                                    dto.LocalFilePath = savedFilePathAndName;
                                    dto.FileName = file.Name;
                                }
                            }
                        }
                    }

                    //다운로드 받은 파일리스트가 존재하면..
                    if (fileInfoList.Count > 0)
                    {
                        totalFileInfoList.AddRange(fileInfoList);
                        //this.SetTreeList(fileInfoList);
                        //this.AddChild(fileInfoList);
                    }

                }
                //grdWorkList.DataSource = dt;
            }
            else
            {
                //실패에 대한 처리
            }

            if (totalFileInfoList != null && totalFileInfoList.Count > 0)
            {
                this.SetTreeList(totalFileInfoList);
                this.AddChild(totalFileInfoList);
            }
        }



        /// <summary>
        /// name         : USP_ArrayList
        /// desc         : CLOB의 내용을 각 라인별로 분리
        /// author       : 심우종
        /// create date  : 2020-08-28 08:32
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private string USP_ArrayList(string strCont)
        {
            string result = "";
            string[] spl = strCont.Split('\n');
            if (spl != null && spl.Count() > 0)
            {
                for( int i=0; i< spl.Count(); i++)
                {
                    result = result + "　　　" + spl.ElementAt(i).ToString() + Environment.NewLine;
                }
            }

            return result;

        }

        /// <summary>
        /// name         : USP_ArrayList
        /// desc         : CLOB의 내용을 각 라인별로 분리(분자보고서의 경우, 타이틀을 제거하여 수정함)
        /// author       : 심우종
        /// create date  : 2020-08-28 08:32
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private string USP_ArrayList2(string strCont)
        {
            string result = "";
            string[] spl = strCont.Split('\n');
            if (spl != null && spl.Count() > 0)
            {
                for (int i = 0; i < spl.Count(); i++)
                {
                    result = result + spl.ElementAt(i).ToString() + Environment.NewLine;
                }
            }

            return result;
        }



        /// <summary>
        /// name         : SetRecordString
        /// desc         : 조회한 레코드 데이터를 string 형태로 변경
        /// author       : 심우종
        /// create date  : 2020-08-27 17:16
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private string SetRecord(DataTable dt, string ptoNo)
        {
            StringBuilder strRecord = new StringBuilder();
            if (dt != null && dt.Rows.Count > 0)
            {
                DataRow row = dt.Rows[0];

                //새로 변경된 분자병리보고서 출력을 위해 날짜로 구분
                string bunjaPtNo = ptoNo;
                string bunjacfmdt = "N";

                if (bunjaPtNo.Length == 8)
                {
                    bunjaPtNo = bunjaPtNo.Substring(0, 1);
                }
                else
                {
                    bunjaPtNo = bunjaPtNo.Substring(0, 2);
                }

                if (dt.Columns.Contains("cfmdt") && dt.Columns.Contains("cfmtm") )
                {

                    string cfmdt = row["cfmdt"].ToString();
                    string cfmtm = row["cfmtm"].ToString();

                    switch (bunjaPtNo)
                    {
                        case "M":           // 분자
                        case "OM":          // 분자(수탁)
                        case "RM":          // 분자(연구)
                        case "MH":          // In situ hybridization
                        case "OH":          // In situ hybridization(수탁)
                        case "RH":          // In situ hybridization(연구)
                            if ( (cfmdt + cfmtm).CompareTo("20140618163000") > 0
                                || cfmdt == "-"
                                || cfmdt == "")
                            {
                                bunjacfmdt = "Y";
                            }
                            break;

                        case "CG":          // 염색체
                        case "OG":          // 염색체(수탁)
                        case "RG":          // 염색체(연구)
                        case "FI":          // FISH
                        case "SI":          // FISH								
                        case "OF":          // FISH(수탁)
                        case "RF":          // FISH(연구)
                            if ((cfmdt + cfmtm).CompareTo("20140625163000") > 0
                           || cfmdt == "-"
                                || cfmdt == "")
                            {
                                bunjacfmdt = "Y";
                            }
                            break;
                    }
                }

                //------------------------
                // Addemdum(추가결과) 설정
                if (dt.Columns.Contains("addendumdt")
                    && dt.Columns.Contains("addendum"))
                {
                    string addendumdt = row["addendumdt"].ToString();
                    string addendum = row["addendum"].ToString();
                    
                    if (!string.IsNullOrEmpty(addendum))
                    {
                        strRecord.Append("[ADDENDUM]     -     " + addendumdt + Environment.NewLine);
                        strRecord.Append(USP_ArrayList(addendum));
                        strRecord.Append("────────────────────────────────────" + Environment.NewLine + Environment.NewLine);
                    }
                }

                //-------------------
                // GROSS FINDING 설정
                if (dt.Columns.Contains("rstcont1"))
                {
                    string rstcont1 = row["rstcont1"].ToString();
                    if (!string.IsNullOrEmpty(rstcont1))
                    {
                        strRecord.Append("[GROSS FINDING]" + Environment.NewLine);
                        strRecord.Append(USP_ArrayList(rstcont1) + Environment.NewLine + Environment.NewLine);
                    }
                }

                //-------------------------
                // MICROSCOPIC FINDING 설정
                if (dt.Columns.Contains("rstcont2"))
                {
                    string rstcont2 = row["rstcont2"].ToString();
                    if (!string.IsNullOrEmpty(rstcont2))
                    {
                        strRecord.Append("[MICROSCOPIC FINDING]" + Environment.NewLine);
                        strRecord.Append(USP_ArrayList(rstcont2) + Environment.NewLine + Environment.NewLine);
                    }
                }


                //-----------------------
                // SPECIAL TECHNIQUE 설정
                if (dt.Columns.Contains("rstcont3"))
                {
                    string rstcont3 = row["rstcont3"].ToString();
                    if (!string.IsNullOrEmpty(rstcont3))
                    {
                        strRecord.Append("[SPECIAL TECHNIQUE]" + Environment.NewLine);
                        strRecord.Append(USP_ArrayList(rstcont3) + Environment.NewLine + Environment.NewLine);
                    }
                }


                //----------------------
                // 검사결과([DIAGNOSIS])
                if (dt.Columns.Contains("viscont") && dt.Columns.Contains("opcont") && dt.Columns.Contains("diagcont"))
                {
                    string viscont = row["viscont"].ToString();
                    string opcont = row["opcont"].ToString();
                    string diagcont = row["diagcont"].ToString();

                    if (bunjacfmdt == "Y")
                    {
                        //------------------------------
                        // 진단내용이 존재하는 경우 포함
                        if (!string.IsNullOrEmpty(diagcont))
                        {
                            if (!string.IsNullOrEmpty(viscont))
                            {
                                strRecord.Append(USP_ArrayList2(diagcont + " : " + viscont));
                            }
                            else
                            {
                                //strGyeolGwa += "　" + "\n" + "　" + "\n";
                                strRecord.Append(USP_ArrayList2(diagcont));
                            }
                        }
                        strRecord.Append(Environment.NewLine + Environment.NewLine);
                    }
                    else if (ptoNo.Substring(0, 2) == "IH")
                    {
                        //continue;
                    }
                    else
                    {
                        strRecord.Append("[DIAGNOSIS]" + Environment.NewLine);

                        //------------------------------
                        // 장기내용이 존재하는 경우 포함
                        if (!string.IsNullOrEmpty(viscont))
                        {
                            strRecord.Append(USP_ArrayList(viscont));
                        }

                        //------------------------------
                        // 수술내용이 존재하는 경우 포함
                        // 부인과/비부인과 병리번호인 경우 opcont의 내용은 결과코드 이기에 표시되지 않도록 처리
                        if (ptoNo.Substring(0, 2) == "NG" || ptoNo.Substring(0, 2) == "GY")
                        {
                            // Continue
                        }
                        else
                        {
                            if (!string.IsNullOrEmpty(opcont))
                            {
                                strRecord.Append(USP_ArrayList(opcont));
                            }
                        }

                        //------------------------------
                        // 수술내용이 존재하는 경우 포함
                        if (!string.IsNullOrEmpty(diagcont))
                        {
                            strRecord.Append(USP_ArrayList(diagcont));
                        }

                        //--------------------
                        strRecord.Append(Environment.NewLine + Environment.NewLine);
                    }
                }

                //-------------------
                // Comments(Comments)
                if (dt.Columns.Contains("refcont"))
                {
                    string refcont = row["refcont"].ToString();
                    if (!string.IsNullOrEmpty(refcont))
                    {
                        if (bunjacfmdt == "Y")
                        {
                            strRecord.Append("　" + Environment.NewLine + "　" + Environment.NewLine);
                            strRecord.Append(USP_ArrayList2(refcont) + Environment.NewLine + Environment.NewLine);
                        }
                        else if (ptoNo.Substring(0, 2) == "IH")
                        {
                            //continue;
                        }
                        else
                        {
                            strRecord.Append("[COMMENTS]" + Environment.NewLine);
                            strRecord.Append(USP_ArrayList(refcont) + Environment.NewLine + Environment.NewLine);
                        }
                    }
                }
            }
            
            return strRecord.ToString();
        }


        /// <summary>
        /// name         : InitChildData
        /// desc         : 자식 데이터들에 대한 정리
        /// author       : 심우종
        /// create date  : 2020-07-06 10:54
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private List<FileInfoDTO> InitChildData(DataTable dt)
        {
            List<FileInfoDTO> fileInfoList = new List<FileInfoDTO>();
            if (dt != null && dt.Rows.Count > 0)
            {
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];
                    FileInfoDTO fileDTO = new FileInfoDTO();
                    fileDTO.DtoId = i;
                    fileDTO.RootPath = row["rootPath"].ToString();
                    fileDTO.FilePath = row["filePath"].ToString();
                    fileDTO.SendStat = row["sendStat"].ToString();
                    fileDTO.SerialNo = row["serialNo"].ToString();
                    fileDTO.StudyId = row["studyId"].ToString();
                    fileDTO.Type = row["type"].ToString();
                    fileDTO.Seq = row["seq"].ToString();

                    fileInfoList.Add(fileDTO);
                }
            }

            return fileInfoList;
        }

        Color gradient1 = Color.FromArgb(35, 40, 57);
        Color gradient2 = Color.FromArgb(40, 52, 92);
        Color gradient3 = Color.FromArgb(35, 40, 57);
        private void hTableLayoutPanel10_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            //Rectangle rc = new Rectangle(x, y, w, h);

        }

        private void tlpViewer_Paint(object sender, PaintEventArgs e)
        {
            this.SetTableLayoutGradient(sender, e);
        }

        private void tlpTopButtons_Paint(object sender, PaintEventArgs e)
        {
            this.SetTableLayoutGradient(sender, e);
        }
        private void tlpBottomButtons_Paint(object sender, PaintEventArgs e)
        {
            this.SetTableLayoutGradient(sender, e);
        }

        private void tlpThumbnail_Paint(object sender, PaintEventArgs e)
        {
            this.SetTableLayoutGradient(sender, e);
        }


        /// <summary>
        /// name         : SetTableLayoutGradient
        /// desc         : 테이블레이아웃 판넬에 그라디에이션 효과적용
        /// author       : 심우종
        /// create date  : 2020-07-03 14:26
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SetTableLayoutGradient(object sender, PaintEventArgs e)
        {
            if (sender is TableLayoutPanel)
            {
                TableLayoutPanel table = sender as TableLayoutPanel;

                int[] rowHeights = table.GetRowHeights();
                int[] colmWidths = table.GetColumnWidths();


                int boxLeft = 0;
                int boxTop = 0;
                int boxRight = 0;
                int boxBottom = 0;

                Rectangle r = Rectangle.Empty;

                for (int i = 0; i < rowHeights.Length; i++)
                {
                    boxBottom = boxBottom + rowHeights[i];
                }

                for (int i = 0; i < colmWidths.Length; i++)
                {
                    boxRight = boxRight + colmWidths[i];
                }

                r.X = boxLeft;
                r.Y = boxTop;
                r.Width = boxRight;
                r.Height = boxBottom;

                if (!r.IsEmpty)
                {
                    e.Graphics.TranslateTransform(table.AutoScrollPosition.X,
                                                  table.AutoScrollPosition.Y);
                    using (var br = new LinearGradientBrush(
                                          r,
                                          gradient2,
                                          gradient3,
                                          LinearGradientMode.Horizontal))
                    {
                        e.Graphics.FillRectangle(br, r);
                    }
                }
            }


        }



        Color buttonFocusColor = Color.FromArgb(253, 114, 105);
        Color whiteColor = Color.White;
        //int flatButtonPixel = 0.5;
        private void FlatButton_Paint(object sender, PaintEventArgs e)
        {
            Sedas.Control.HSimpleButton button = sender as Sedas.Control.HSimpleButton;
            //button.AppearanceHovered.BackColor
            if (button.Tag != null && button.Tag.ToString() == "1")
            {
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, buttonFocusColor, 1, ButtonBorderStyle.Solid
                                                                           , buttonFocusColor, 1, ButtonBorderStyle.Solid
                                                                           , buttonFocusColor, 1, ButtonBorderStyle.Solid
                                                                           , buttonFocusColor, 1, ButtonBorderStyle.Solid);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, whiteColor, 1, ButtonBorderStyle.Solid
                                                                           , whiteColor, 1, ButtonBorderStyle.Solid
                                                                           , whiteColor, 1, ButtonBorderStyle.Solid
                                                                           , whiteColor, 1, ButtonBorderStyle.Solid);
            }


        }

        private void FlatButton_MouseLeave(object sender, EventArgs e)
        {
            Sedas.Control.HSimpleButton button = sender as Sedas.Control.HSimpleButton;
            button.Tag = "0";
            button.ForeColor = whiteColor;
            button.Refresh();
        }

        private void FlatButton_MouseEnter(object sender, EventArgs e)
        {
            Sedas.Control.HSimpleButton button = sender as Sedas.Control.HSimpleButton;
            button.Tag = "1";
            button.ForeColor = buttonFocusColor;
            button.Refresh();
        }


        /// <summary>
        /// name         : treeList1_CustomDrawNodeCell
        /// desc         : 트리컨트롤 CustomDrawNodeCell이벤트
        /// author       : 심우종
        /// create date  : 2020-07-06 16:23
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void treeList1_CustomDrawNodeCell(object sender, CustomDrawNodeCellEventArgs e)
        {
            //if ( e.Node
            if (e.Node != null)
            {
                if (e.Node.Level == 0)
                {
                    e.Appearance.BackColor = Color.FromArgb(253, 114, 105);
                }
            }
        }


        /// <summary>
        /// name         : treeList1_AfterCheckNode
        /// desc         : 트리 체크 변경시
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary>  
        private void treeList1_AfterCheckNode(object sender, NodeEventArgs e)
        {
            //if (treeList1.DataSource is BindingList<TreeDTO>)
            //{
            //    BindingList<TreeDTO> treeList = treeList1.DataSource as BindingList<TreeDTO>;



            //    //List<ImageContainer> imageList = this.GetImageList();
            //}
        }


        /// <summary>
        /// name         : treeList1_FocusedNodeChanged
        /// desc         : 트리뷰의 아이템 선택 변경시
        /// author       : 심우종
        /// create date  : 2020-07-06 16:04
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void treeList1_FocusedNodeChanged(object sender, FocusedNodeChangedEventArgs e)
        {
            if (e.Node != null && e.Node.Level != 0)
            {
                BindingList<TreeDTO> treeList = treeList1.DataSource as BindingList<TreeDTO>;
                if (treeList != null)
                {
                    //TreeDTO treeDTO = treeList.Where(o => o.ID == e.Node.Id).FirstOrDefault();

                    TreeDTO treeDTO = treeList1.GetDataRecordByNode(e.Node) as TreeDTO;

                    if (treeDTO != null)
                    {
                        List<ImageContainer> imageList = GetImageList();
                        ImageContainer imageContainer = imageList.Where(o => o.TreeDTO == treeDTO).FirstOrDefault();
                        if (imageContainer != null)
                        {
                            //해당 이미지를 선택한다.
                            this.ImageBox_onImageSelected(imageContainer, "");
                            this.ScrollIntoView(imageContainer, "Right");
                        }
                    }
                }



            }
        }

        private void txtPtNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch.PerformClick();
            }
        }

        private void txtPtoNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.btnSearch.PerformClick();
            }
        }

        private void picWorkListExpand_Click(object sender, EventArgs e)
        {
            //accordionControl1.exp
            //if (accordionControlElement1.Expanded == true)
            //{
            //    accordionControlElement1.Expanded = false;
            //}
            //else
            //{
            //    accordionControlElement1.Expanded = true;
            //}
        }


        /// <summary>
        /// name         : TopButtons_MouseEnter
        /// desc         : 상단버튼 MouseEnter 이벤트
        /// author       : 심우종
        /// create date  : 2020-07-07 09:05
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void TopButtons_MouseEnter(object sender, EventArgs e)
        {
            if (sender is Sedas.Control.HPictureEdit)
            {
                Sedas.Control.HPictureEdit pic = sender as Sedas.Control.HPictureEdit;
                SetTopButtonImage(pic, true);
            }
        }

        /// <summary>
        /// name         : TopButtons_MouseLeave
        /// desc         : 상단버튼 MouseLeave 이벤트
        /// author       : 심우종
        /// create date  : 2020-07-07 09:05
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary>
        private void TopButtons_MouseLeave(object sender, EventArgs e)
        {
            if (sender is Sedas.Control.HPictureEdit)
            {
                Sedas.Control.HPictureEdit pic = sender as Sedas.Control.HPictureEdit;
                SetTopButtonImage(pic, false);
            }
        }


        /// <summary>
        /// name         : SetTopButtonImage
        /// desc         : 상단 버튼의 이미지 설정
        /// author       : 심우종
        /// create date  : 2020-07-07 09:02
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SetTopButtonImage(Sedas.Control.HPictureEdit pic, bool isEnter)
        {
            if (pic != null)
            {
                switch (pic.Tag.ToString())
                {
                    case "ZoomIn":
                        if (isEnter == false)
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_01;
                        }
                        else
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_01_on;
                        }
                        break;
                    case "ZoomOut":
                        if (isEnter == false)
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_02;
                        }
                        else
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_02_on;
                        }
                        break;
                    case "FitWidth":
                        if (isEnter == false)
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_03;
                        }
                        else
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_03_on;
                        }
                        break;
                    case "FitPage":
                        if (isEnter == false)
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_04;
                        }
                        else
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_04_on;
                        }
                        break;
                    case "AdjustGamma":
                        if (isEnter == false)
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_05;
                        }
                        else
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_05_on;
                        }
                        break;
                    case "RotateLeft":
                        if (isEnter == false)
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_06;
                        }
                        else
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_06_on;
                        }
                        break;
                    case "RotateRight":
                        if (isEnter == false)
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_07;
                        }
                        else
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_07_on;
                        }
                        break;
                    case "FlipX":
                        if (isEnter == false)
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_08;
                        }
                        else
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_08_on;
                        }
                        break;
                    case "FlipY":
                        if (isEnter == false)
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_09;
                        }
                        else
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_09_on;
                        }
                        break;
                    case "ViewCount1":
                        if (isEnter == false)
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_10;
                        }
                        else
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_10_on;
                        }
                        break;
                    case "ViewCount2":
                        if (isEnter == false)
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_11;
                        }
                        else
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_11_on;
                        }
                        break;
                }
            }
        }



        /// <summary>
        /// name         : picViewCount1_Click
        /// desc         : 한페이지 보기 클릭
        /// author       : 심우종
        /// create date  : 2020-07-07 09:45
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void picViewCount1_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// name         : picViewCount2_Click
        /// desc         : 두 페이지 보기 클릭
        /// author       : 심우종
        /// create date  : 2020-07-07 09:45
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void picViewCount2_Click(object sender, EventArgs e)
        {



        }


        private void acodiWorkList_Click(object sender, EventArgs e)
        {
            SetAcodiControlHeight("workList");
        }

        private void acodiTreeList_Click(object sender, EventArgs e)
        {
            SetAcodiControlHeight("treeList");
        }

        private void accordionControl1_SizeChanged(object sender, EventArgs e)
        {
            SetAcodiControlHeight("all");
        }


        /// <summary>
        /// name         : SetAcodiControlHeight
        /// desc         : 워크리스트/treeList영역 높이 조절
        /// author       : 심우종
        /// create date  : 2020-07-07 14:09
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SetAcodiControlHeight(string clickControl)
        {
            bool workListExpaned = this.acodiWorkList.Expanded;
            bool treeListExpanded = this.acodiTreeList.Expanded;

            if (clickControl == "workList")
            {
                workListExpaned = !workListExpaned;
            }
            else if (clickControl == "treeList")
            {
                treeListExpanded = !treeListExpanded;
            }

            int maxHeight = accordionControl1.Height;
            int gap = 20;
            maxHeight = maxHeight - acodiTreeList.Height - acodiWorkList.Height - gap;

            if (workListExpaned == true)
            {
                if (treeListExpanded == true)
                {
                    this.acodiContainerWorkList.Height = maxHeight / 2;
                    this.tlpWorkListNew.Height = this.acodiContainerWorkList.Height - 5;

                    this.acodiContainerTreeList.Height = maxHeight / 2;
                    this.tlpTreeListNew.Height = this.acodiContainerTreeList.Height - 5;
                }
                else
                {
                    this.acodiContainerWorkList.Height = maxHeight;
                    this.tlpWorkListNew.Height = this.acodiContainerWorkList.Height - 5;

                    this.acodiContainerTreeList.Height = 0;
                    this.tlpTreeListNew.Height = 0;
                }
            }
            else
            {
                if (treeListExpanded == true)
                {
                    this.acodiContainerWorkList.Height = 0;
                    this.tlpWorkListNew.Height = 0;

                    this.acodiContainerTreeList.Height = maxHeight;
                    this.tlpTreeListNew.Height = this.acodiContainerTreeList.Height - 5;
                }
                else
                {
                    this.acodiContainerWorkList.Height = 0;
                    this.tlpWorkListNew.Height = 0;

                    this.acodiContainerTreeList.Height = 0;
                    this.tlpTreeListNew.Height = 0;
                }
            }
        }


        /// <summary>
        /// name         : TopButton_MouseDown
        /// desc         : 상단 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-07 14:09
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary>  
        private void TopButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (sender is Sedas.Control.HPictureEdit)
            {
                Sedas.Control.HPictureEdit pic = sender as Sedas.Control.HPictureEdit;
                if (pic != null)
                {
                    if (pic.Name == "picViewCount1")
                    {
                        this.topButtonList.SetViewCountControlImage(1);
                        ViewCountChanged();
                        ImageSelectFromViewer();
                    }
                    else if (pic.Name == "picViewCount2")
                    {
                        this.topButtonList.SetViewCountControlImage(2);
                        ViewCountChanged();
                        ImageSelectFromViewer();
                    }

                    switch (pic.Tag.ToString())
                    {
                        case "ZoomIn":
                            if (this.SelectedViewer != null)
                            {
                                this.SelectedViewer.CallMethod("ZoomIn");
                            }
                            break;
                        case "ZoomOut":
                            if (this.SelectedViewer != null)
                            {
                                this.SelectedViewer.CallMethod("ZoomOut");
                            }
                            break;
                        case "FitWidth":
                            if (this.SelectedViewer != null)
                            {
                                this.SelectedViewer.CallMethod("FitWidth");
                            }
                            break;
                        case "FitPage":
                            if (this.SelectedViewer != null)
                            {
                                this.SelectedViewer.CallMethod("FitPage");
                            }
                            break;
                        case "AdjustGamma":

                            break;
                        case "RotateLeft":
                            if (this.SelectedViewer != null)
                            {
                                this.SelectedViewer.CallMethod("RotateLeft");
                            }
                            break;
                        case "RotateRight":
                            if (this.SelectedViewer != null)
                            {
                                this.SelectedViewer.CallMethod("RotateRight");
                            }
                            break;
                        case "FlipX":
                            if (this.SelectedViewer != null)
                            {
                                this.SelectedViewer.CallMethod("FlipX");
                            }
                            break;
                        case "FlipY":
                            if (this.SelectedViewer != null)
                            {
                                this.SelectedViewer.CallMethod("FlipY");
                            }
                            break;

                    }
                }
            }
        }


        /// <summary>
        /// name         : picDownload_MouseDown
        /// desc         : 다운로드 이미지 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-13 15:25
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void picDownload_MouseDown(object sender, MouseEventArgs e)
        {
            if (viewerCount == 1)
            {
                if (this.viewer != null)
                {
                    FileSaveAs(this.viewer);
                }
            }
            else if (this.viewerCount == 2)
            {
                if (this.viewer != null)
                {
                    FileSaveAs(this.viewer);
                }
                if (this.viewer2 != null)
                {
                    FileSaveAs(this.viewer2);
                }
            }


        }


        /// <summary>
        /// name         : FileDownload
        /// desc         : 파일을 다른이름으로 저장한다.
        /// author       : 심우종
        /// create date  : 2020-07-17 10:49
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void FileSaveAs(Viewer viewer)
        {

            if (viewer != null && viewer.ImageContainer != null && !string.IsNullOrEmpty(viewer.ImageContainer.ImageButtonValue.strRowFilePath))
            {



                SaveFileDialog ofd = new SaveFileDialog();
                ofd.Title = "다른이름으로 저장(" + viewer.ImageContainer.ImageButtonValue.strRowFileName + ")";

                //ofd.Filter = "jpg(*.*)|*.jpg*";
                DialogResult drs = ofd.ShowDialog();
                if (drs == DialogResult.OK)
                {
                    string fileName = ofd.FileName;

                    int fileNameDivideIndex = fileName.LastIndexOf("\\");
                    string path = fileName.Substring(0, fileNameDivideIndex + 1);
                    string name = fileName.Substring(fileNameDivideIndex + 1, fileName.Length - fileNameDivideIndex - 1);



                    string filePath = viewer.ImageContainer.ImageButtonValue.strRowFilePath;

                    FileInfo file = new FileInfo(filePath);
                    if (file.Exists == true)
                    {
                        string extrenstion = filePath.GetFileExtension();
                        File.Copy(filePath, path + name + "." + extrenstion);

                        DevExpress.XtraEditors.XtraMessageBox.Show("파일이 저장되었습니다.");
                    }



                    //File.Copy(filePath, path + name + ".jpg");

                    //XtraMessageBox.Show("이미지가 저장되었습니다.");
                }
            }
        }

        private void hSedasSImpleButtonGreen4_Click(object sender, EventArgs e)
        {
            string ptoNo = "";
            DataRow row = grvWorkList.GetFocusedDataRow();
            if (row != null)
            {
                if (row.Table.Columns.Contains("ptoNo"))
                {
                    ptoNo = row["ptoNo"].ToString();
                }
            }

            if (string.IsNullOrEmpty(ptoNo)) return;


            KeyValueData param = new KeyValueData();
            param.Add("Data1", ptoNo);


            CallResultData result = this.callService.SelectSql("reqGetGyeolGwa", param);

            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                if (result.resultDataList != null && result.resultDataList.Count > 0)
                {
                    DataTable dt = result.resultDataList[0];

                    if (dt != null && dt.Rows.Count > 0)
                    { 
                    
                    }
                }

                //grdWorkList.DataSource = dt;
            }
            else
            {
                //실패에 대한 처리
            }


        }


        /// <summary>
        /// name         : picPrint_MouseDown
        /// desc         : 프린트 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-20 10:12
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void picPrint_MouseDown(object sender, MouseEventArgs e)
        {

            this.flyoutPanel1.ShowPopup();
            //Print("H");
            //return;


        }


        /// <summary>
        /// name         : Print
        /// desc         : 프린트
        /// author       : 심우종
        /// create date  : 2020-07-20 10:12
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void Print(string direction)
        {
            int imageCount = 0;
            using (PrintLayout print = new PrintLayout(direction))
            {
                if (viewerCount == 1)
                {
                    if (this.viewer != null)
                    {
                        string filePath = this.viewer.SaveGdPictureToImage();

                        if (!string.IsNullOrEmpty(filePath))
                        {
                            FileStream fs;
                            fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                            Image image = System.Drawing.Image.FromStream(fs);
                            //print.Image1 = image;
                            print.ImageAdd(image);
                            imageCount++;
                            fs.Close();
                        }
                    }
                }
                else if (this.viewerCount == 2)
                {
                    if (this.viewer != null)
                    {
                        string filePath = this.viewer.SaveGdPictureToImage();
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            FileStream fs;
                            fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                            Image image = System.Drawing.Image.FromStream(fs);
                            //print.Image1 = image;
                            print.ImageAdd(image);
                            imageCount++;
                            fs.Close();
                        }
                    }
                    if (this.viewer2 != null)
                    {
                        string filePath = this.viewer2.SaveGdPictureToImage();
                        if (!string.IsNullOrEmpty(filePath))
                        {
                            FileStream fs;
                            fs = new FileStream(filePath, FileMode.Open, FileAccess.Read);
                            Image image = System.Drawing.Image.FromStream(fs);
                            //print.Image1 = image;
                            print.ImageAdd(image);
                            imageCount++;
                            fs.Close();
                        }
                    }
                }

                

                if (imageCount > 0)
                {
                    using (PrintingSystem ps = new PrintingSystem())
                    {
                        using (PrintableComponentLink link = new PrintableComponentLink(ps))
                        {
                            link.PaperKind = System.Drawing.Printing.PaperKind.A4;
                            if (direction == "H")
                            {
                                link.Landscape = true;
                            }
                            else
                            {
                                link.Landscape = false;
                            }
                            link.Component = print.layoutControl1;
                            //Show a preview  
                            link.ShowPreviewDialog();
                            //Or print directly  
                            //ps.Print();
                        }
                    }
                }
            }


            
        }


        /// <summary>
        /// name         : picSendEmail_MouseDown
        /// desc         : 이메일 보내기
        /// author       : 심우종
        /// create date  : 2020-07-20 15:36
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void picSendEmail_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                return;
                // Create a new report.                
                SendEmailReport report = new SendEmailReport();

                // Create a new memory stream and export the report into it as PDF.
                MemoryStream mem = new MemoryStream();
                report.ExportToPdf(mem);
                // Export report to PDF file
                report.ExportToPdf("exportedFile.pdf");

                // Create a new attachment and put the PDF report into it.
                //mem.Seek(0, System.IO.SeekOrigin.Begin);
                //Attachment att = new Attachment(mem, "TestReport.pdf", "application/pdf");

                // Create second attachment and put the exported PDF report into it.
                var currentFolder = Path.GetDirectoryName(this.GetType().Assembly.Location);
                Attachment att2 = new Attachment(@"C:\BASE\이미지 캡쳐\테스트용 이미지\1 - 복사본 - 복사본 - 복사본.jpg", "image/jpeg");

                // Create a new message and attach the PDF reports to it.
                MailMessage mail = new MailMessage();
                //mail.Attachments.Add(att);
                mail.Attachments.Add(att2);

                // Specify sender and recipient options for the e-mail message.
                mail.From = new MailAddress("tk32189@naver.com", "Someone");
                mail.To.Add(new MailAddress("tk32189@naver.com"));
                //hannah54389@gmail.com

                // Specify other e-mail options.
                mail.Subject = "타이틀인가?";
                mail.Body = "내용인가?";

                // Send the e-mail message via the specified SMTP server.
                SmtpClient smtp = new SmtpClient("smtp.somewhere.com");
                smtp.Send(mail);

                // Close the memory stream.
                mem.Close();
                mem.Flush();
            }
            catch (Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(this, "Error sending a report.\n" + ex.ToString());
            }
        }


        /// <summary>
        /// name         : btnPrintH_Click
        /// desc         : 가로출력
        /// author       : 심우종
        /// create date  : 2020-07-21 11:34
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnPrintH_Click(object sender, EventArgs e)
        {
            flyoutPanel1.Options.CloseOnOuterClick = false;
            this.Print("H");
            flyoutPanel1.Options.CloseOnOuterClick = true;
            flyoutPanel1.HidePopup();
        }


        /// <summary>
        /// name         : btnPrintV_Click
        /// desc         : 세로출력
        /// author       : 심우종
        /// create date  : 2020-07-21 11:34
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnPrintV_Click(object sender, EventArgs e)
        {
            flyoutPanel1.Options.CloseOnOuterClick = false;
            this.Print("V");
            flyoutPanel1.Options.CloseOnOuterClick = true;
            flyoutPanel1.HidePopup();

        }

        private void btnPrintV_MouseDown(object sender, MouseEventArgs e)
        {
            


            //this.Update();
        }

        //private void btnPrintV_MouseUp(object sender, MouseEventArgs e)
        //{
        //    this.Print("V");
        //}







        //private void hSimpleButton6_Click(object sender, EventArgs e)
        //{
        //    this.SelectedViewer.CallMethod("ZoomIn");
        //}
    }


}
