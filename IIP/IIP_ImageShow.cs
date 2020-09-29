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
using DevExpress.Utils;

namespace IIP
{
    public partial class IIP_ImageShow : DevExpress.XtraEditors.XtraForm
    {
        Image showimage = Image.FromFile(Global.strShow_File_Path);

        public IIP_ImageShow()
        {
            InitializeComponent();
        }

        /// <summary>
        /// name         : IIP_ImageShow_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-03-20 11:20
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void IIP_ImageShow_Load(object sender, EventArgs e)
        {
            pictureEdit.Image = showimage;

            double percentWidth = Math.Round((double)((pictureEdit.Width * 100 / showimage.Width)));
            double percentHeight = Math.Round((double)((pictureEdit.Height * 100 / showimage.Height)));

            double percentLess = 0;
            if (percentWidth < percentHeight)
            {
                percentLess = percentWidth;
            }
            else
            {
                percentLess = percentHeight;
            }

            TrackBarContextButton trackBarButton = pictureEdit.Properties.ContextButtons["trackBarContextButton"] as TrackBarContextButton;

            if (trackBarButton.Minimum <= percentLess && trackBarButton.Maximum >= percentLess)
            {
                pictureEdit.Properties.ZoomPercent = percentLess;
            }
            else
            {
                pictureEdit.Properties.ZoomPercent = 100;
            }
        }




        /// <summary>
        /// name         : btnUp_Click
        /// desc         : + 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-20 11:26
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnUp_Click(object sender, EventArgs e)
        {
            TrackBarContextButton trackBarButton = pictureEdit.Properties.ContextButtons["trackBarContextButton"] as TrackBarContextButton;
            int value = trackBarButton.Value;
            int changeValue = value + 10;
            if (trackBarButton.Maximum < changeValue)
            {
                pictureEdit.Properties.ZoomPercent = trackBarButton.Maximum;
            }
            else
            {
                pictureEdit.Properties.ZoomPercent = changeValue;
            }
        }


        /// <summary>
        /// name         : btnDown_Click
        /// desc         : - 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-20 11:26
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnDown_Click(object sender, EventArgs e)
        {
            TrackBarContextButton trackBarButton = pictureEdit.Properties.ContextButtons["trackBarContextButton"] as TrackBarContextButton;
            int value = trackBarButton.Value;
            int changeValue = value - 10;
            if (trackBarButton.Minimum > changeValue)
            {
                pictureEdit.Properties.ZoomPercent = trackBarButton.Minimum;
            }
            else
            {
                pictureEdit.Properties.ZoomPercent = changeValue;
            }
        }


        /// <summary>
        /// name         : btnStretch_Click
        /// desc         : stretch 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-20 13:09
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnStretch_Click(object sender, EventArgs e)
        {
            TrackBarContextButton trackBarButton = pictureEdit.Properties.ContextButtons["trackBarContextButton"] as TrackBarContextButton;
            pictureEdit.Properties.ZoomPercent = 100;
        }


        /// <summary>
        /// name         : btnExit_Click
        /// desc         : Close버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-20 13:30
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        private void pictureEditSample_ZoomPercentChanged(object sender, EventArgs e)
        {
            (pictureEdit.Properties.ContextButtons["trackBarContextButton"] as TrackBarContextButton).Value = Convert.ToInt32(pictureEdit.Properties.ZoomPercent);
        }

        private void pictureEditSample_Properties_ContextButtonValueChanged(object sender, ContextButtonValueEventArgs e)
        {
            if (e.Item.Name == "trackBarContextButton")
            {
                pictureEdit.Properties.ZoomPercent = Convert.ToDouble(e.Value);
            }
        }

        private void pictureEdit_MouseDown(object sender, MouseEventArgs e)
        {


        }

        private void pictureEdit_MouseUp(object sender, MouseEventArgs e)
        {
            
        }
    }
}