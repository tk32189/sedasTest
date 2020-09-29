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
using System.Drawing.Drawing2D;

namespace Integration_Viewer
{
    public partial class TopButtonList : DevExpress.XtraEditors.XtraUserControl
    {

        private int viewCount = 1;
        private bool viewCountVisible = true; //View갯수를 변경하기 위한 버튼 visible


        public int ViewCount
        {
            get
            {
                return viewCount;
            }

            set
            {
                viewCount = value;
            }
        }

        public bool ViewCountVisible
        {
            get
            {
                return viewCountVisible;
            }

            set
            {
                this.flwpnlViewCount.Visible = value;
            }
        }

        public TopButtonList()
        {
            InitializeComponent();
        }

        private void tlpTopButtons_Paint(object sender, PaintEventArgs e)
        {
            this.SetTableLayoutGradient(sender, e);
        }

        Color gradient1 = Color.FromArgb(35, 40, 57);
        Color gradient2 = Color.FromArgb(40, 52, 92);
        Color gradient3 = Color.FromArgb(35, 40, 57);

        

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

        

        /// <summary>
        /// name         : SetViewCountControlImage
        /// desc         : ViewerCount 관련 컨트롤 설정
        /// author       : 심우종
        /// create date  : 2020-07-07 09:56
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void SetViewCountControlImage(int viewCount)
        {
            if (viewCount == 1)
            {
                this.ViewCount = 1;
                this.picViewCount1.Tag = "1";
                this.picViewCount2.Tag = "0";
                this.picViewCount1.Image = global::Integration_Viewer.Properties.Resources.controls_10_on;
                this.picViewCount2.Image = global::Integration_Viewer.Properties.Resources.controls_11;
            }
            else if (viewCount == 2)
            {
                this.ViewCount = 2;
                this.picViewCount1.Tag = "0";
                this.picViewCount2.Tag = "1";
                this.picViewCount1.Image = global::Integration_Viewer.Properties.Resources.controls_10;
                this.picViewCount2.Image = global::Integration_Viewer.Properties.Resources.controls_11_on;
            }

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
                    case "FitPage":
                        if (isEnter == false)
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_03;
                        }
                        else
                        {
                            pic.Image = global::Integration_Viewer.Properties.Resources.controls_03_on;
                        }
                        break;
                    case "FitWidth":
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

        public event Action<string, string> OnButtonClick;

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
                        this.SetViewCountControlImage(1);
                        if (this.OnButtonClick != null)
                        {
                            this.OnButtonClick("picViewCount1", "");
                        }
                    }
                    else if (pic.Name == "picViewCount2")
                    {
                        this.SetViewCountControlImage(2);
                        if (this.OnButtonClick != null)
                        {
                            this.OnButtonClick("picViewCount2", "");
                        }
                    }

                    switch (pic.Tag.ToString())
                    {
                        case "ZoomIn":
                            if (this.OnButtonClick != null)
                            {
                                this.OnButtonClick("ZoomIn", "");
                            }
                            break;
                        case "ZoomOut":
                            if (this.OnButtonClick != null)
                            {
                                this.OnButtonClick("ZoomOut", "");
                            }
                            break;
                        case "FitWidth":
                            if (this.OnButtonClick != null)
                            {
                                this.OnButtonClick("FitWidth", "");
                            }
                            break;
                        case "FitPage":
                            if (this.OnButtonClick != null)
                            {
                                this.OnButtonClick("FitPage", "");
                            }
                            break;
                        case "AdjustGamma":
                            //if (this.OnButtonClick != null)
                            //{
                            //    this.OnButtonClick("AdjustGamma", "");
                            //}


                            this.flyoutPanel1.ShowPopup();
                            break;
                        case "RotateLeft":
                            if (this.OnButtonClick != null)
                            {
                                this.OnButtonClick("RotateLeft", "");
                            }
                            break;
                        case "RotateRight":
                            if (this.OnButtonClick != null)
                            {
                                this.OnButtonClick("RotateRight", "");
                            }
                            break;
                        case "FlipX":
                            if (this.OnButtonClick != null)
                            {
                                this.OnButtonClick("FlipX", "");
                            }
                            break;
                        case "FlipY":
                            if (this.OnButtonClick != null)
                            {
                                this.OnButtonClick("FlipY", "");
                            }
                            break;

                    }
                }
            }
        }


        /// <summary>
        /// name         : trackGamma_EditValueChanged
        /// desc         : 감마 값 변경시
        /// author       : 심우종
        /// create date  : 2020-07-10 16:59
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void trackGamma_EditValueChanged(object sender, EventArgs e)
        {
            if (this.OnButtonClick != null)
            {
                this.OnButtonClick("AdjustGamma", trackGamma.Value.ToString());
            }
            
        }
    }
}
