using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedas.Control
{
    public partial class HGroupControl : DevExpress.XtraEditors.GroupControl
    {

        public enum HGroupControlType
        {
            Null,
            Kuh,
            KuhLight
        }

        private HGroupControlType sedasControlType = HGroupControlType.Null;

        public HGroupControlType SedasControlType
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

        public HGroupControl()
        {
            InitializeComponent();
        }

        public HGroupControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        Color borderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));

        /// <summary>
        /// name         : SedasControlTypeChanged
        /// desc         : 컨트롤 타입 변경시
        /// author       : 심우종
        /// create date  : 2020-03-25 12:41
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SedasControlTypeChanged()
        {
            if (this.sedasControlType == HGroupControlType.Kuh)
            {
                this.LookAndFeel.SkinName = "My Basic";
                this.LookAndFeel.UseDefaultLookAndFeel = false;

                //this.AppearanceCaption.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.AppearanceCaption.ForeColor = System.Drawing.Color.White;
                this.AppearanceCaption.Options.UseFont = true;
                this.AppearanceCaption.Options.UseForeColor = true;
            }
            else if (this.sedasControlType == HGroupControlType.KuhLight)
            {
                this.Appearance.BackColor = System.Drawing.Color.Transparent;
                this.Appearance.Options.UseBackColor = true;
                this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                this.LookAndFeel.UseDefaultLookAndFeel = false;
                this.Appearance.BorderColor = borderColor;
            }
        }
    }
}
