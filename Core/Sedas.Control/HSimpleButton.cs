using DevExpress.Skins;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Drawing;
using DevExpress.XtraEditors.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sedas.Control
{
    public partial class HSimpleButton : DevExpress.XtraEditors.SimpleButton
    {

        public enum ButtonControlType
        {
            Null,
        }

        private ButtonControlType sedasControlType = ButtonControlType.Null;

        public ButtonControlType SedasControlType
        {
            get
            {
                return sedasControlType;
            }

            set
            {
                sedasControlType = value;
                SedasControlTypeChanged();
            }
        }


        [ToolboxItem(true)]
        public HSimpleButton() : base()
        {
            
            InitializeComponent();
        }



        /// <summary>
        /// name         : SedasControlTypeChanged
        /// desc         : 컨트롤 타입 변경시
        /// author       : 심우종
        /// create date  : 2020-03-25 12:41
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SedasControlTypeChanged()
        {
            //터치스크린용 큰 이미지 체크박스
            //if (this.sedasControlType == ButtonControlType.OrangColorCornol)
            //{
            //    this.LookAndFeel.SkinName = "My Basic";
            //    this.LookAndFeel.UseDefaultLookAndFeel = false;
            //}
        }

    }
}
