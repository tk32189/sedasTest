using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Sedas.Control
{
    public partial class HListBoxControl : DevExpress.XtraEditors.ListBoxControl
    {

        public enum HListBoxControlType
        {
            Null,
            Kuh,
        }

        public HListBoxControl()
        {
            InitializeComponent();
        }

        public HListBoxControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        private HListBoxControlType sedasControlType = HListBoxControlType.Null;

        public HListBoxControlType SedasControlType
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


        /// <summary>
        /// name         : SedasControlTypeChanged
        /// desc         : 컨트롤 타입 변경시
        /// author       : 심우종
        /// create date  : 2020-03-25 12:41
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SedasControlTypeChanged()
        {
            if (this.sedasControlType == HListBoxControlType.Kuh)
            {
                Assembly asm = typeof(DevExpress.UserSkins.Seda20200611).Assembly;
                DevExpress.Skins.SkinManager.Default.RegisterAssembly(asm);
                this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
                this.LookAndFeel.SkinName = "My Basic";
                this.LookAndFeel.UseDefaultLookAndFeel = false;

                this.ForeColor = System.Drawing.Color.White;
            }
        }
    }
}
