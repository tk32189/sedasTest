using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.IO;
using DevExpress.XtraLayout;

namespace Integration_Viewer
{
    public partial class ThumNailTest : DevExpress.XtraEditors.XtraForm
    {


        int originalExStyle = -1;
        bool enableFormLevelDoubleBuffering = true;

        protected override CreateParams CreateParams
        {
            get
            {
                if (originalExStyle == -1)
                    originalExStyle = base.CreateParams.ExStyle;

                CreateParams cp = base.CreateParams;
                if (enableFormLevelDoubleBuffering)
                    cp.ExStyle |= 0x02000000;   // WS_EX_COMPOSITED
                else
                    cp.ExStyle = originalExStyle;

                return cp;
            }
        }

        public void TurnOffFormLevelDoubleBuffering()
        {
            enableFormLevelDoubleBuffering = false;
            // this.MaximizeBox = true;
        }






        public ThumNailTest()
        {
            InitializeComponent();
        }

        private void hSedasSimpleButton11_Click(object sender, EventArgs e)
        {

            ImageList imagelist = new ImageList();

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "jpg(*.*)|*.jpg*";
            DialogResult drs = ofd.ShowDialog();

            List<string> imageKeys = new List<string>();
            List<Image> imageDatas = new List<Image>();
            List<FileStream> imageStreams = new List<FileStream>();

            if (drs == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    string strPath = ofd.FileNames[i].ToString();

                    FileStream fs;
                    fs = new FileStream(strPath, FileMode.Open, FileAccess.Read);

                    imageStreams.Add(fs);

                    Image image = System.Drawing.Image.FromStream(fs);

                    imagelist.Images.Add(strPath, image);
                    imageKeys.Add(strPath);
                    imageDatas.Add(image);





                    fs.Close();
                }
            }



            //listView1.LargeImageList = imagelist;
            //listView1.View = View.List;
            //listView1.Alignment = ListViewAlignment.Left;
            



            //DataTable dt = new DataTable();
            //dt.Columns.Add("imageName");
            //dt.Columns.Add("imageData", typeof(Image));


            //if (imageKeys.Count > 0)
            //{
            //    for (int i = 0; i < imageKeys.Count; i++)
            //    {
            //        var listViewItem = listView1.Items.Add("test1");
            //        listViewItem.ImageKey = imageKeys[i].ToString();

            //        DataRow row = dt.NewRow();
            //        row["imageName"] = imageKeys[i].ToString();
            //        row["imageData"] = imageDatas[i];

            //        dt.Rows.Add(row);
            //    }
            //}

            //listBoxControl1.DataSource = dt;




            //ThumbnailEx1 이미지 추가
            this.ThumbnailEx1.ThumbnailSize = new Size(200, 200);
            this.ThumbnailEx1.ThumbnailSpacing = new Size(205, 205);
            this.ThumbnailEx1.ThumbnailAlignment = GdPicture14.ThumbnailAlignment.ThumbnailAlignmentHorizontal;
            this.ThumbnailEx1.VerticalScroll.Visible = false;


            //layoutControl
            //layoutControl1.VerticalScroll.Visible = false;
            //this.layoutControl1.OptionsView.UseParentAutoScaleFactor = true;
            //this.layoutControl1.AllowCustomization = false;

            //this.layoutControl1.BeginUpdate();
            if (imageKeys.Count > 0)
            {
                for (int i = 0; i < imageKeys.Count; i++)
                {
                    ThumbnailEx1.AddItemFromFile(imageKeys[i].ToString());
                    //ThumbnailEx1.AddItemFromStream(imageStreams[i], "test1");

                    //PictureEdit pic = new PictureEdit();
                    //pic.Image = imageDatas[i];
                    //pic.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
                    //pic.Size = new Size(66, 66);
                    //pic.StyleController = this.layoutControl1;
                    //pic.Properties.UseDisabledStatePainter = false;


                    //LayoutControlItem layoutItem = new LayoutControlItem();
                    //layoutItem.Control = pic;
                    //layoutItem.Size = new System.Drawing.Size(100, 100);


                    //layoutControl1.Controls.Add(pic);

                    //Root.AddItem(layoutItem);
                    
                }
            }

            //Root.Items.AddRange

            //this.layoutControl1.EndUpdate();






        }
    }
}