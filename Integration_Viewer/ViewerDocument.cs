using GdPicture14;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration_Viewer
{
    public class ViewerDocument
    {
        /// <summary>
        /// The constructor initializes members to their default values.
        /// </summary>
        public ViewerDocument(GdPictureImaging gdPictureImaging)
        {
            _gdPictureImaging = gdPictureImaging;
            //_gdPictureOcr = gdPictureOcr;
            ImageId = -1;
            _ocrResultId = "";
        }

        /// <summary>
        /// Load document loads the document.
        /// </summary>
        /// <param name="filePath">The path to the file to load.</param>        
        /// <param name="pdfRasterizationResolution">The resolution for the rasterization of the pdfs.</param>
        /// <returns>true of the load succeeds otherwise returns false.</returns>
        public bool Load(string filePath, float pdfRasterizationResolution, GdViewer gdViewer)
        {
            // In case the document is a pdf, it is required to rasterize the page.

            if (GdPictureDocumentUtilities.GetDocumentFormat(filePath) == GdPicture14.DocumentFormat.DocumentFormatPDF)
            {
                using (GdPicturePDF gdPicturePdf = new GdPicturePDF())
                {
                    if (gdPicturePdf.LoadFromFile(filePath, false) == GdPictureStatus.OK)
                    {
                        ImageId = gdPicturePdf.RenderPageToGdPictureImageEx(pdfRasterizationResolution, true);
                        gdPicturePdf.CloseDocument();

                        gdViewer.DisplayFromGdPicturePDF(gdPicturePdf);
                    }
                }
            }
            else
            {
                ImageId = _gdPictureImaging.CreateGdPictureImageFromFile(filePath);
                gdViewer.DisplayFromGdPictureImage(ImageId);
            }

            if (ImageId == 0)
            {
                return false;
            }

            // Take into accourant the rotation information stored within the exif tags.

            GdPictureRotateFlipType rotateFlipType = _gdPictureImaging.TagGetExifRotation(ImageId);
            if (rotateFlipType != GdPictureRotateFlipType.GdPictureRotateNoneFlipNone)
            {
                _gdPictureImaging.Rotate(ImageId, (RotateFlipType)rotateFlipType);
                _gdPictureImaging.TagDeleteAll(ImageId);
            }

            return true;
        }

        /// <summary>
        /// Close closes the current document if one.
        /// </summary>
        public void Close()
        {
            if (ImageId != 0)
            {
                _gdPictureImaging.ReleaseGdPictureImage(ImageId);
                ImageId = 0;
            }
        }


        /// <summary>
        /// The identifier for the current image.
        /// </summary>
        public int ImageId { get; private set; }


        /// <summary>
        /// The flag indicates whether a document is open or not.
        /// </summary>
        public bool IsOpen
        {
            get { return ImageId > 0; }
        }

        /// <summary>
        /// The flag indicates whether a document has been recognized or not.
        /// </summary>
        public bool HasOcr
        {
            get { return !string.IsNullOrWhiteSpace(_ocrResultId); }
        }

        /// <summary>
        /// GdPictureImaging instance.
        /// </summary>
        private readonly GdPictureImaging _gdPictureImaging;

        /// <summary>
        /// GdPictureOcr instance.
        /// </summary>
        //private readonly GdPictureOCR _gdPictureOcr;

        /// <summary>
        /// The identifier for the ocr result.
        /// </summary>
        private string _ocrResultId;
    }
}
