using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Windows.Forms;


namespace SedasPhotoMagic.Classes
{
    //되돌리기 기능의 개체
    public class UndoTask
    {
        public string TaskName { get; set; }
        public float pixelPerCm { get; set; }
        public string objImageFilename { get; set; }
        public RectangleF objSrcRect { get; set; }
        public RectangleF objCropRect { get; set; }
        public SizeF paperSize { get; set; }
        public List<GridObject> listGrids { get; set; }
        public RectangleF objRect { get; set; }
        public List<DrawingObject> listObject { get; set; }
        public UndoTask()
        {
        }
        public UndoTask(string TaskName, WorkSpace ws, bool isChangeImage=false)
        {
            try
            {
                this.TaskName = TaskName;
                this.pixelPerCm = ws.pixelPerCm;
                this.objCropRect = ws.objCropRect;
                this.paperSize = ws.paperSize;
                this.listGrids = (List<GridObject>)Util.DeepClone(ws.listGrids);
                this.objSrcRect = ws.objSrcRect;
                this.objRect = ws.objRect;
                this.listObject = (List<DrawingObject>)Util.DeepClone(ws.listObjects);
                this.objImageFilename = "";
                if (isChangeImage)
                {
                    this.objImageFilename = ws.WORK_DIREC + Util.GetNameFromTimebase() + ".JPG";
                    EncoderParameters encoderParameters = new EncoderParameters(1);
                    EncoderParameter encoderParameter = new EncoderParameter(System.Drawing.Imaging.Encoder.Quality, 100L);
                    ImageCodecInfo codecInfo = ImageCodecInfo.GetImageDecoders().First(codec => codec.FormatID == ImageFormat.Jpeg.Guid);
                    encoderParameters.Param[0] = encoderParameter;
                    ws.objBitmap.Save(objImageFilename, codecInfo, encoderParameters);
                    encoderParameters.Dispose();
                    encoderParameter.Dispose();
                } else this.objImageFilename = "";
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

    }
}
