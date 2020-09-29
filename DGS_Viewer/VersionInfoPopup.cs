using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace DGS_Viewer
{
    public partial class VersionInfoPopup : DevExpress.XtraEditors.XtraForm
    {
        public VersionInfoPopup()
        {
            InitializeComponent();
            Icon myIcon = new Icon(System.Environment.CurrentDirectory + "\\" + "Resources/0012.ICO");
            Bitmap bmp = myIcon.ToBitmap();
            //imageIcon.Image = bmp;
            //Image img = bmp;
            imageBox.Image = bmp;
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
