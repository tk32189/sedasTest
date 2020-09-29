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
    public partial class HPanelControl : DevExpress.XtraEditors.PanelControl
    {
        public HPanelControl()
        {
            InitializeComponent();
        }

        public enum SedasPanelType
        {
            Null,
            Kuh

        }

        private SedasPanelType sedasControlType = SedasPanelType.Null;

        public SedasPanelType SedasControlType
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


        public HPanelControl(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }


        Color borderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));

        private void SedasControlTypeChanged()
        {
            if (sedasControlType == SedasPanelType.Kuh)
            {
                this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
                this.Appearance.Options.UseBackColor = true;
                this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
                this.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                this.LookAndFeel.UseDefaultLookAndFeel = false;
            }
        }
    }
}
