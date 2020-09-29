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
using GdPicture14;

namespace TestProject
{
    public partial class GdPicturePdfToImage : DevExpress.XtraEditors.XtraForm
    {
        public GdPicturePdfToImage()
        {
            InitializeComponent();
        }

        private void hSimpleButton1_Click(object sender, EventArgs e)
        {
            //We assume that GdPicture has been correctly installed and unlocked.
            GdPictureImaging oGdPictureImaging = new GdPictureImaging();
            GdPicturePDF oGdPicturePDF = new GdPicturePDF();
            int multiTiffID = 0;
            //Loading the PDF document.

            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = true;
            ofd.Filter = "pdf(*.*)|*.pdf*";
            DialogResult drs = ofd.ShowDialog();
            string strPathCom = "";
            if (drs == DialogResult.OK)
            {
                for (int i = 0; i < ofd.FileNames.Length; i++)
                {
                    strPathCom = ofd.FileNames[i].ToString();
                }
            }



            //dPictureStatus status = oGdPicturePDF.LoadFromFile("input.pdf", false);
            GdPictureStatus status = oGdPicturePDF.LoadFromFile(strPathCom, false);



            //If PDF loading was successful:
            if (status == GdPictureStatus.OK)
            {
                //Loop through pages.
                for (int i = 1; i <= oGdPicturePDF.GetPageCount(); i++)
                {
                    //selecting a page.
                    oGdPicturePDF.SelectPage(i);
                    //Rendering the selected page to GdPictureImage identifier.
                    int rasterizedPageID = oGdPicturePDF.RenderPageToGdPictureImageEx(200.0f, true);
                    if (oGdPicturePDF.GetStat() == GdPictureStatus.OK)
                    {
                        //If it is the first page.
                        if (i == 1)
                        {
                            multiTiffID = rasterizedPageID;
                            status = oGdPictureImaging.SaveAsJPEG(multiTiffID, "output.jpeg");
                        }
                        else
                        {
                            multiTiffID = rasterizedPageID;
                            status = oGdPictureImaging.SaveAsJPEG(multiTiffID, "output"+ i.ToString() + ".jpeg");
                        }
                        //Checking for errors when adding a new page.
                        if (status != GdPictureStatus.OK)
                        {
                            MessageBox.Show("TiffSaveAsMultiPageFile - Error: " + status.ToString(), "Converting PDF to TIFF Example", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                    }
                    else
                    {
                        MessageBox.Show("RenderPageToGdPictureImageEx - Error: " + oGdPicturePDF.GetStat().ToString(), "Converting PDF to TIFF Example", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                //Closing the multipage tiff file.
                oGdPictureImaging.TiffCloseMultiPageFile(multiTiffID);
                //Releasing the multipage tiff image.
                oGdPictureImaging.ReleaseGdPictureImage(multiTiffID);
                //Closing and release the PDF document.
                oGdPicturePDF.CloseDocument();
                MessageBox.Show("Done!", "Converting PDF to TIFF Example", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("The PDF document can't be loaded. Status: " + status.ToString(), "Converting PDF to TIFF Example", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            oGdPictureImaging.Dispose();
            oGdPicturePDF.Dispose();
        }
    }
}