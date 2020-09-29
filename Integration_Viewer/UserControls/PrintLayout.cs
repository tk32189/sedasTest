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

namespace Integration_Viewer
{
    public partial class PrintLayout : DevExpress.XtraEditors.XtraUserControl
    {
        string direction = "V";
        public PrintLayout(string direction)
        {
            this.direction = direction;
            
            InitializeComponent();

            if (direction == "V")
            {
                this.Width = 580;
                this.Height = 900;
            }
            else if (direction == "H")
            {
                this.Width = 900;
                this.Height = 600;
            }
        }

        private Image image1;

        public Image Image1
        {
            get
            {
                return image1;
            }

            set
            {
                image1 = value;

                
            }
        }


        int height = 20; //default
        public void ImageAdd(Image image)
        {
            
            if (image != null)
            {
                PictureEdit pic = new PictureEdit();
                //pic.Size = new Size(470, 730);
                if (direction == "V") //세로출력
                {
                    pic.Size = new Size(550, 850); 
                }
                else //가로출력
                {
                    pic.Size = new Size(880, 560);
                }
                
                pic.Image = image;
                pic.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Squeeze;
                pic.BackColor = Color.White;
                pic.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;

                flwpnlMain.Controls.Add(pic);
                height = height + pic.Height + pic.Margin.Top + pic.Margin.Bottom;


                this.Height = height;
            }
        }


    }
}
