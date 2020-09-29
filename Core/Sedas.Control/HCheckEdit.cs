using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sedas.Control
{
    public partial class HCheckEdit : DevExpress.XtraEditors.CheckEdit
    {

        public enum HCheckControlType
        {
            Null,
            MaterialControl,
            Kuh,
        }


        private HCheckControlType sedasControlType = HCheckControlType.Null;

        public HCheckControlType SedasControlType
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

        public HCheckEdit()
        {
            InitializeComponent();
        }

        public HCheckEdit(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }



        /// <summary>
        /// name         : OnCreateControl
        /// desc         : 컨트롤 생성시에 호출
        /// author       : 심우종
        /// create date  : 2020-03-25 14:00
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        protected override void OnCreateControl()
        {
            base.OnCreateControl();
            this.SedasControlTypeChanged();
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
            if (this.sedasControlType == HCheckControlType.MaterialControl)
            {
                this.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgCheckBox1;
                this.Properties.CheckBoxOptions.SvgImageSize = new System.Drawing.Size(18, 18);
            }
            else if (this.sedasControlType == HCheckControlType.Kuh)
            {
                Assembly asm = typeof(DevExpress.UserSkins.Seda20200611).Assembly;
                DevExpress.Skins.SkinManager.Default.RegisterAssembly(asm);
                this.LookAndFeel.SkinName = "My Basic";
                this.LookAndFeel.UseDefaultLookAndFeel = false;

                this.ForeColor = System.Drawing.Color.White;
                //this.Properties.CheckBoxOptions.SvgImageSize = new System.Drawing.Size(9, 9);
            }
        }
    }
}
