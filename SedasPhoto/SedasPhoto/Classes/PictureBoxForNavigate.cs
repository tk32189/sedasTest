using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;
using System.IO;

namespace SedasPhotoMagic.Classes
{
    public class PictureBoxForNavigate : PictureBox
    {
        public bool IsSelect = false;
        public string title;
        public string imageFilename;
        private WorkSpace ws;

        public PictureBoxForNavigate()
        {
        }

        public PictureBoxForNavigate(string title, string imageFilename, WorkSpace workSpace)
        {
            try
            {
                SetStyle(
             ControlStyles.AllPaintingInWmPaint |
             ControlStyles.OptimizedDoubleBuffer |
             ControlStyles.UserPaint |
             ControlStyles.ResizeRedraw, true);
                this.Margin = new Padding(3, 3, 3, 3);
                this.SizeMode = PictureBoxSizeMode.Zoom;
                this.BorderStyle = BorderStyle.None;

                this.title = title;
                this.imageFilename = imageFilename;
                this.ws = workSpace;

                using (Bitmap sourceImage = new Bitmap(imageFilename))
                {
                    int width = sourceImage.Width;
                    int height = sourceImage.Height / 2;
                    this.Size = new Size((int)(1.0 * sourceImage.Width / sourceImage.Height * 140), 140);
                    Bitmap resizeImage = new Bitmap(sourceImage, this.Size);
                    if (this.Image != null) this.Image.Dispose();
                    this.Image = resizeImage;
                }
                
                

                this.MouseClick += new MouseEventHandler(ePanelPageClick);
                this.Paint += new PaintEventHandler(paintEventHandler);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //클릭 페이지 선택 패널
        private void ePanelPageClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            try
            {
                ws.mainForm.LoadImage(imageFilename,false);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //페인트 페이지 선택 패널
        private void paintEventHandler(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            try
            {

                Graphics g = e.Graphics;

                // 선택 여부 표시
                if (IsSelect)
                {
                    Pen pen = new Pen(Color.FromArgb(255, 76,175, 80), 5);
                    pen.Alignment = PenAlignment.Inset;
                    g.DrawRectangle(pen, 0, 0, this.Width, this.Height);
                    //g.FillRectangle(new SolidBrush(Color.FromArgb(255, 153, 180, 209)), 0, 0, this.Width, this.Height);
                }
                g.FillRectangle(new SolidBrush(Color.FromArgb(150, 0, 0, 0)), 0, this.Height - 30, this.Width, 30);
                g.DrawString(this.title, new Font("맑은 고딕", 10), new SolidBrush(Color.White),
                    (int)(this.Width / 2 - 7.0 * this.title.Length / 2), this.Height - 25, new StringFormat());

            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }


        public void SelfDispose()
        {
            if (this.Image != null) this.Image.Dispose();
            this.Dispose();
        }

    }
}
