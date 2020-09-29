using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace TestProject
{
    public partial class myTextEdit : UserControl
    {

        GraphicsPath path = new GraphicsPath();

        public myTextEdit()
        {
            InitializeComponent();

            InitializeComponent();
            path.AddEllipse(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            this.Region = new Region(path);

            this.BackColor = SystemColors.ControlDarkDark;
        }

        private void FindWord_Resize(object sender, EventArgs e)
        {
            path.Reset();

            if (this.Region != null)
            {
                this.Region.Dispose();
                this.Region = null;
            }

            path.AddEllipse(0, 0, this.ClientSize.Width, this.ClientSize.Height);
            this.Region = new Region(path);
        }

    }

}
