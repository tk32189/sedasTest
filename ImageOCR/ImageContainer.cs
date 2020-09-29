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
using ImageOCR.DTO;

namespace ImageOCR
{
    public partial class ImageContainer : DevExpress.XtraEditors.XtraUserControl
    {
        public event Action<ImageContainer, string> onImageSelected;
        public event Action<ImageContainer, string> onImageDoubleClick;

        private ImageInfoDTO imageButtonValue = null; //이미지 관련 데이터


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

        public ImageInfoDTO ImageButtonValue
        {
            get
            {
                return imageButtonValue;
            }

            set
            {
                imageButtonValue = value;
                if (this.imageButtonValue != null)
                {
                    this.imageButtonValue.PropertyChanged += ImageButtonValue_PropertyChanged;
                }
            }
        }


        /// <summary>
        /// name         : ImageButtonValue_PropertyChanged
        /// desc         : 데이터 변경시
        /// author       : 심우종
        /// create date  : 2020-07-22 15:01
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ImageButtonValue_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "IsChecked")
            {
                if (this.ImageButtonValue.IsChecked == true)
                {
                    this.tlpMain.BackColor = this.checkedBackColor;
                }
                else
                {
                    this.tlpMain.BackColor = this.nomalcolor;
                }
            }
            else if ( e.PropertyName == "PtoNo" || e.PropertyName == "OcrResult" || e.PropertyName == "Kornm")
            {
                this.SetImageInfo();

                
            }

            

            

        }


        /// <summary>
        /// name         : SetImageInfo
        /// desc         : 이미지 정보 표시
        /// author       : 심우종
        /// create date  : 2020-07-23 10:43
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SetImageInfo()
        {
            if (ImageButtonValue == null) return;

            string imageInfo = this.ImageButtonValue.StrRowFilePath.Split('\\').LastOrDefault();
            this.lblImageInfo.Text = imageInfo;
            if (!string.IsNullOrEmpty(ImageButtonValue.PtoNo))
            {
                this.lblOcrResult.Text = this.ImageButtonValue.PtoNo;
            }
            else
            {
                this.lblOcrResult.Text = this.ImageButtonValue.OcrResult;
            }
            
            this.lblPtnm.Text = this.ImageButtonValue.Kornm;

            if (string.IsNullOrEmpty(this.ImageButtonValue.PtoNo) || string.IsNullOrEmpty(this.ImageButtonValue.Kornm))
            {
                tlpTop.BackColor = needToCheckColor;
            }
            else
            {
                tlpTop.BackColor = Color.Transparent;
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


        Color nomalcolor;
        Color checkedBackColor;
        Color selectcolor;
        Color pencolor;
        Color needToCheckColor;



        /// <summary>
        /// name         : ImageContainer_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-04-24 08:52
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ImageContainer_Load(object sender, EventArgs e)
        {

            if (imageButtonValue != null)
            {
                //컬러 지정
                this.nomalcolor = Color.FromArgb(200, 200, 200);
                this.checkedBackColor = Color.FromArgb(23, 122, 199);
                this.selectcolor = Color.FromArgb(23, 122, 199);
                this.pencolor = Color.FromArgb(150, 150, 150);
                this.needToCheckColor = Color.FromArgb(253, 114, 105);


                this.SetImageInfo();


                //바인딩 처리
                this.chkSelected.DataBindings.Clear();
                this.chkSelected.DataBindings.Add("Checked", this.ImageButtonValue, "IsChecked", true, DataSourceUpdateMode.OnPropertyChanged);
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
        private void ImageClickEvent(bool isCheckboxChange = false)
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

            //체크박스 변경 필요시
            if (isCheckboxChange == true)
            {
                if (imageButtonValue != null)
                {
                    if (imageButtonValue.IsChecked == true)
                    {
                        imageButtonValue.IsChecked = false;
                    }
                    else
                    {
                        imageButtonValue.IsChecked = true;
                    }
                }
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


        private void tlpTop_Click(object sender, EventArgs e)
        {
            this.ImageClickEvent(isCheckboxChange: true);
        }

        private void lblTopInfo_Click(object sender, EventArgs e)
        {
            this.ImageClickEvent(isCheckboxChange: true);
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
