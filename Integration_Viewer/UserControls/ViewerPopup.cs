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

namespace Integration_Viewer
{
    public partial class ViewerPopup : DevExpress.XtraEditors.XtraForm
    {

        Viewer viewer;
        TopButtonList topButtonList = new TopButtonList();


        public ViewerPopup()
        {
            InitializeComponent();
        }

        

        /// <summary>
        /// name         : ViewerPopup_Load
        /// desc         : 화면로드시
        /// author       : 심우종
        /// create date  : 2020-07-10 13:46
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ViewerPopup_Load(object sender, EventArgs e)
        {
            
        }

        string filePath;
        ImageContainer imageContainer;

        public void ShowImage(string filePath, ImageContainer imageContainer)
        {
            this.filePath = filePath;
            this.imageContainer = imageContainer;
        }

        private void ViewerPopup_Shown(object sender, EventArgs e)
        {
            if (viewer == null)
            {
                this.viewer = new Viewer();
                this.viewer.IsPopup = true;
                this.tlpViewer.Controls.Add(viewer);
                this.viewer.Dock = DockStyle.Fill;
                this.viewer.Update();
            }

            if (this.viewer != null)
            {
                this.viewer.ShowImage(filePath, this.imageContainer);

            }


            //상단버튼
            //--------------------------------------------------
            // 상단 버튼 설정
            //--------------------------------------------------
            this.tlpTop.Controls.Add(this.topButtonList);
            topButtonList.Dock = DockStyle.Fill;
            topButtonList.Update();
            topButtonList.OnButtonClick += TopButtonList_OnButtonClick;
            this.topButtonList.ViewCountVisible = false;



        }

        /// <summary>
        /// name         : TopButtonList_OnButtonClick
        /// desc         : 탑 버튼 클릭 이벤트 처리
        /// author       : 심우종
        /// create date  : 2020-07-10 14:42
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void TopButtonList_OnButtonClick(string buttonName, string arg2)
        {
            if (this.viewer != null)
            {
                this.viewer.CallMethod(buttonName, arg2);
            }
        }


        /// <summary>
        /// name         : ViewerPopup_FormClosed
        /// desc         : 화면 닫힐때 처리
        /// author       : 심우종
        /// create date  : 2020-07-10 14:53
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ViewerPopup_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (viewer != null)
            {
                this.viewer.Clear();
            }

            if (this.topButtonList != null)
            {
                //이벤트 해제
                topButtonList.OnButtonClick -= TopButtonList_OnButtonClick;
            }
        }
    }
}