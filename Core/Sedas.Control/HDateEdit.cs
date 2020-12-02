using DevExpress.LookAndFeel;
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
    public partial class HDateEdit : DevExpress.XtraEditors.DateEdit
    {
        public HDateEdit()
        {
            InitializeComponent();
        }

        private ControlType sedasControlType = ControlType.Null;

        public ControlType SedasControlType
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

        private Color? sedasForeColor = null;
        public Color? SedasForeColor
        {
            get
            {
                return sedasForeColor;
            }

            set
            {
                sedasForeColor = value;

                if (value != null && value != Color.Empty)
                {
                    this.Properties.Appearance.ForeColor = value.Value;
                }
            }
        }


        Color backColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
        Color textColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
        Color buttonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
        Color borderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));

        private void SedasControlTypeChanged()
        {
            if (sedasControlType == ControlType.Kuh)
            {
                this.Properties.Appearance.BackColor = backColor;
                this.Properties.Appearance.Options.UseBackColor = true;
                if (SedasForeColor != null)
                {
                    this.Properties.Appearance.ForeColor = SedasForeColor.Value;
                }
                else
                {
                    this.Properties.Appearance.ForeColor = textColor;
                }
                
                this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                this.Properties.Appearance.Options.UseBorderColor = true;
                this.Properties.Appearance.BorderColor = borderColor;
                if (this.Properties.Buttons != null && this.Properties.Buttons.Count > 0)
                {
                    this.Properties.Buttons[0].Appearance.BackColor = backColor;
                    this.Properties.Buttons[0].Appearance.BorderColor = buttonColor2;
                    this.Properties.Buttons[0].IsDefaultButton = true;
                    this.Properties.Buttons[0].AppearancePressed.BackColor = backColor;
                    this.Properties.Buttons[0].AppearancePressed.BorderColor = buttonColor2;
                    this.Properties.Buttons[0].AppearanceHovered.BackColor = backColor;
                    this.Properties.Buttons[0].AppearanceHovered.BorderColor = buttonColor2;
                }
                
                this.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                this.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
                this.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
                this.LookAndFeel.SetSkinStyle(SkinSvgPalette.DefaultSkin.BlueDark);
            }
        }
    }
}
