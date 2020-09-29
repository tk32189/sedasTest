using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using DGS_Viewer.DTO;

namespace DGS_Viewer
{
    public partial class ImageContainer : UserControl
    {
        public event Action<ImageContainer, string> onImageSelected;
        public event Action<ImageContainer, string> onImageDoubleClick;

        private ImageButtonValue imageButtonValue = null; //이미지 관련 데이터


        public ImageContainer()
        {
            InitializeComponent();
        }

        bool isSelected = false; //이미지 선택여부
        bool isLastSelected = false; //마지막으로 선택된 이미지 여부
        string path = ""; //경로
        Image image = null;//이미지

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
                this.pnlMain.Appearance.BorderColor = System.Drawing.Color.Empty;
            }
        }


        Color nomalcolor = Color.Red;
        Color selectcolor = Color.Blue;
        Color pencolor = Color.Green;



        /// <summary>
        /// name         : ImageContainer_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-04-24 08:52
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ImageContainer_Load(object sender, EventArgs e)
        {
            if (g_OthersSetupData.nImageSize.ToString() == ConstantData.LARGE_SIZE)
            {
                if (this.tlpMain.RowStyles.Count >= 3)
                {
                    this.tlpMain.RowStyles[0].Height = 22;
                    this.tlpMain.RowStyles[2].Height = 22;
                }
            }
            else
            {
                if (this.tlpMain.RowStyles.Count >= 3)
                {
                    this.tlpMain.RowStyles[0].Height = 15;
                    this.tlpMain.RowStyles[2].Height = 15;
                }
            }

                //if ( this.pnlMain.)
                if (imageButtonValue != null)
            {
                if (this.ImageButtonValue.nSendStatus == -1)
                {
                    this.nomalcolor = Color.FromArgb(200, 200, 200);
                    this.selectcolor = Color.FromArgb(70, 70, 70);
                    this.pencolor = Color.FromArgb(150, 150, 150);
                }
                else if (this.ImageButtonValue.nSendStatus == 0 || this.ImageButtonValue.nSendStatus == 9 || this.ImageButtonValue.nSendStatus == 8)
                {
                    if (this.ImageButtonValue.nType == 0)
                    {
                        this.nomalcolor = Color.FromArgb(255, 200, 200);
                        this.selectcolor = Color.FromArgb(255, 70, 70);
                        this.pencolor = Color.FromArgb(250, 150, 150);
                    }
                    if (this.ImageButtonValue.nType == 1)
                    {
                        this.nomalcolor = Color.FromArgb(150, 255, 150);
                        this.selectcolor = Color.FromArgb(70, 200, 70);
                        this.pencolor = Color.FromArgb(150, 200, 150);
                    }
                    if (this.ImageButtonValue.nType == 2)
                    {
                        this.nomalcolor = Color.FromArgb(160, 227, 250);
                        this.selectcolor = Color.FromArgb(31, 0, 242);
                        this.pencolor = Color.FromArgb(160, 150, 250);
                    }
                }
                else if (this.ImageButtonValue.nSendStatus == 1)
                {
                    this.nomalcolor = Color.FromArgb(200, 200, 255);
                    this.selectcolor = Color.FromArgb(70, 70, 255);
                    this.pencolor = Color.FromArgb(150, 150, 250);
                }

                string imageInfo = "";
                if (this.ImageButtonValue.nSendStatus == 0)
                {
                    imageInfo = "미전송";
                }
                else if (this.ImageButtonValue.nSendStatus == 1)
                {
                    imageInfo = "전송";
                }
                else if (this.ImageButtonValue.nSendStatus == 2)
                {
                    imageInfo = "전송실패";
                }
                else if (this.ImageButtonValue.nSendStatus == 8)
                {
                    imageInfo = "전송대기";
                }
                else if (this.ImageButtonValue.nSendStatus == 9)
                {
                    imageInfo = "전송중";
                }
                else
                {
                    imageInfo = "외부이미지";
                }

                string[] filepathSlite = this.ImageButtonValue.strSaveFilePath.Split('\\');
                if (filepathSlite != null && filepathSlite.Count() > 0)
                {
                    imageInfo = imageInfo +  "   " +  filepathSlite.ElementAt(filepathSlite.Count() - 1).ToString();
                }

                this.lblImageInfo.Text = imageInfo;
                this.lblPtoNo.Text = this.ImageButtonValue.strPathologyNum;

                if (this.ImageButtonValue.nImageNum == -1)
                {
                    this.lblImageNum.Text = "";
                }
                else
                {
                    this.lblImageNum.Text = this.ImageButtonValue.nImageNum.ToString();
                }
                
            }



            this.tlpMain.BackColor = this.nomalcolor;


            

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
            else if ( Control.ModifierKeys == Keys.Shift)
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
            pictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Stretch;
            //pnlImage.BackgroundImage = image;
            //imageBox.SetBounds(18, 18, 150, 150);
            //pnlImage.SizeMode = DevExpress.XtraEditors.SvgImageSizeMode.Stretch;
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
    }
}
