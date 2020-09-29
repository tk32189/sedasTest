using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Drawing;

namespace Sedas.Control
{
    public partial class HTextEdit : TextEdit
    {
        public HTextEdit()
        {
            InitializeComponent();
        }

        public HTextEdit(IContainer container)
        {
            container.Add(this);

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

        Color borderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));

        private void SedasControlTypeChanged()
        {
            if (sedasControlType == ControlType.Kuh)
            {
                this.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
                this.Properties.Appearance.Options.UseBackColor = true;
                this.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                this.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
                this.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                this.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
                this.Paint += HTextEdit_Paint;
            }
        }

        private void HTextEdit_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            Color color = borderColor;
            ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, color, 1, ButtonBorderStyle.Solid
                                                           , color, 1, ButtonBorderStyle.Solid
                                                           , color, 1, ButtonBorderStyle.Solid
                                                           , color, 1, ButtonBorderStyle.Solid);
        }
    }
}
