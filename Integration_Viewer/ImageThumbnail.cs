using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;

namespace Integration_Viewer
{
    public partial class ImageThumbnail : DevExpress.XtraEditors.XtraUserControl
    {
        public ImageThumbnail()
        {
            InitializeComponent();
        }

        public void InitData()
        { 
            
        }

        public void ImageAdd(List<string> imageList)
        {
            if (imageList == null || imageList.Count == 0) return;

            List<string> imageKeys = new List<string>();
            List<Image> imageDatas = new List<Image>();

            for (int i = 0; i < imageList.Count; i++)
            {
                FileStream fs;
                fs = new FileStream(imageList.ElementAt(i), FileMode.Open, FileAccess.Read);
                Image image = System.Drawing.Image.FromStream(fs);

                imageKeys.Add(imageList.ElementAt(i));
                imageDatas.Add(image);
            }


            if (imageKeys.Count > 0)
            {
                for (int i = 0; i < imageKeys.Count; i++)
                {

                    DataRow row = this.dataSource.NewRow();
                    row["imageName"] = imageKeys[i].ToString();
                    row["imageData"] = imageDatas[i];

                    dataSource.Rows.Add(row);
                }
            }
        }


        DataTable dataSource;
        private void ImageThumbnail_Load(object sender, EventArgs e)
        {
            this.dataSource = new DataTable();
            this.dataSource.Columns.Add("imageName");
            this.dataSource.Columns.Add("imageData", typeof(Image));

            this.listBoxControl.DataSource = this.dataSource;

        }
    }

}
