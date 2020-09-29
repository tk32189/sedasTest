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
    public partial class HSedasSImpleButtonGreen : HSimpleButton
    {
        public HSedasSImpleButtonGreen()
        {
            InitializeComponent();
        }

        public HSedasSImpleButtonGreen(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }

        protected override BaseStyleControlViewInfo CreateViewInfo()
        {
            if (DevExpress.Skins.SkinManager.Default.GetValidSkinName("My Basic") != "My Basic")
            {
                Assembly asm = typeof(DevExpress.UserSkins.Seda20200611).Assembly;
                DevExpress.Skins.SkinManager.Default.RegisterAssembly(asm);
            }

            //this.LookAndFeel.SetSkinStyle("My Basic");
            this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            this.LookAndFeel.SkinName = "My Basic";
            this.LookAndFeel.UseDefaultLookAndFeel = false;

            this.Appearance.ForeColor = Color.White;

            return new CustomSimpleButtonViewInfo(this);

            //return new SimpleButtonViewInfo(this);
        }

        public class CustomSimpleButtonViewInfo : SimpleButtonViewInfo
        {
            public CustomSimpleButtonViewInfo(SimpleButton owner) : base(owner)
            {
            }
            protected override EditorButtonPainter GetButtonPainter()
            {
                return new CustomSkinEditorButtonPainter(this.LookAndFeel);
            }
        }



        public class CustomSkinEditorButtonPainter : SkinEditorButtonPainter
        {
            public CustomSkinEditorButtonPainter(ISkinProvider provider) : base(provider) { }
            protected override SkinElement GetSkinElement(EditorButtonObjectInfoArgs e, ButtonPredefines kind)
            {
                return CommonSkins.GetSkin(Provider)["Button_green"];
            }
        }


        public enum HSimpleButtonType
        {
            Null,
        }


        private HSimpleButtonType sedasButtonType = HSimpleButtonType.Null;

        public HSimpleButtonType SedasButtonType
        {
            get
            {
                return sedasButtonType;
            }

            set
            {
                sedasButtonType = value;
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
            this.LookAndFeel.SkinName = "My Basic";
            this.LookAndFeel.UseDefaultLookAndFeel = false;
        }
    }
}
