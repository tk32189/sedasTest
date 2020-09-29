using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinWord = Microsoft.Office.Interop.Word;
using WinExcl = Microsoft.Office.Interop.Excel;
using WinPower = Microsoft.Office.Interop.PowerPoint;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.IO;
using System.Windows.Forms;
using GdPicture14;
using System.Drawing;

namespace Sedas.ImageHelper
{




    public class ImageHelper
    {
        string[] officeExcelType = { "xlsx", "xlsm", "xlsb", "xltx", "xml", "xlam", "xls" };
        string[] officePowerPointType = { "pptx", "ppt", "pot" };
        string[] officeWordType = { "doc", "docx" };


        /// <summary>
        /// name         : IsOfficeFileCheck
        /// desc         : 오피스 파일여부를 체크한다.
        /// author       : 심우종
        /// create date  : 2020-07-01 10:49
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool IsOfficeFileCheck(string strPath)
        {
            bool isOffice = false;
            string[] fileNameSplite = strPath.ToString().Split('.');
            if (fileNameSplite == null || fileNameSplite.Length > 0)
            {
                string lastValue = fileNameSplite[fileNameSplite.Length - 1].ToString();


                if (officeExcelType.Where(e => e == lastValue).Count() > 0)
                {
                    isOffice = true;
                }

                if (officePowerPointType.Where(e => e == lastValue).Count() > 0)
                {
                    isOffice = true;
                }

                if (officeWordType.Where(e => e == lastValue).Count() > 0)
                {
                    isOffice = true;
                }
            }

            return isOffice;
        }


        #region [MS office파일을 PDF로 변환]

        /// <summary>
        /// name         : OfficeToPDF
        /// desc         : MS office파일을 PDF로 변환
        /// author       : 심우종
        /// create date  : 2020-05-19 08:57
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool OfficeToPDF(string file, out string pdfFilePath, string tempFileSavePath = "")
        {
            //-------------------------------------------------
            // file : 파일전체경로
            // pdfFilePath : pdf변환후 파일 경로(out)
            // tempFileSavePath : pdf로 변환된 파일이 저장되는 위치, 없으면 현재파일위치에 pdf파일 생성됨
            //-------------------------------------------------

            FileInfo fileinfo = new FileInfo(file);
            if (fileinfo.Exists == false)
            {
                pdfFilePath = "";
                return false;
            }


            string directoryName = fileinfo.DirectoryName + "\\";

            if (!string.IsNullOrEmpty(tempFileSavePath))
            {
                DirectoryInfo diInfo = new DirectoryInfo(tempFileSavePath);
                if (diInfo.Exists == false)
                {
                    diInfo.Create();
                }

                directoryName = diInfo.FullName + "\\";
            }

            string fileName = "";
            if (!string.IsNullOrEmpty(fileinfo.Extension))
            {
                fileName = fileinfo.Name.Substring(0, fileinfo.Name.Length - fileinfo.Extension.Length);
            }

            DateTime current = DateTime.Now;


            DirectoryInfo di = new DirectoryInfo(directoryName);
            if (!di.Exists)
            {
                //di.Create();
                pdfFilePath = "";
                return false;
            }

            pdfFilePath = "";
            if (string.IsNullOrEmpty(file))
            {
                return false;
            }

            string[] fileNameSplite = file.ToString().Split('.');

            if (fileNameSplite == null || fileNameSplite.Length > 0)
            {

                string lastValue = fileNameSplite[fileNameSplite.Length - 1].ToString();
                if (lastValue == "doc" || lastValue == "docx")
                {
                    //isDirectRead = true;
                    object nullobj = System.Reflection.Missing.Value;
                    object doNotSaveChanges = WinWord.WdSaveOptions.wdDoNotSaveChanges;

                    string paramExportFilePath = directoryName + fileName + "_" + current.ToString("yyyyMMddHHmmss") + "_" + "tempWord.pdf";
                    WinWord.WdExportFormat paramExportFormat = WinWord.WdExportFormat.wdExportFormatPDF;
                    bool paramOpenAfterExport = false;
                    WinWord.WdExportOptimizeFor paramExportOptimizeFor = WinWord.WdExportOptimizeFor.wdExportOptimizeForPrint;
                    WinWord.WdExportRange paramExportRange = WinWord.WdExportRange.wdExportAllDocument;
                    int paramStartPage = 0;
                    int paramEndPage = 0;
                    WinWord.WdExportItem paramExportItem = WinWord.WdExportItem.wdExportDocumentContent;
                    bool paramIncludeDocProps = true;
                    bool paramKeepIRM = true;
                    WinWord.WdExportCreateBookmarks paramCreateBookmarks = WinWord.WdExportCreateBookmarks.wdExportCreateWordBookmarks;
                    bool paramDocStructureTags = true;
                    bool paramBitmapMissingFonts = true;
                    bool paramUseISO19005_1 = false;

                    object objFile = file;

                    WinWord._Application myWinWord = new WinWord.Application();
                    WinWord._Document mydoc = myWinWord.Documents.Open(ref objFile, ref nullobj, ref nullobj, ref nullobj, ref nullobj,
                                                                                ref nullobj, ref nullobj, ref nullobj, ref nullobj,
                                                                                ref nullobj, ref nullobj, ref nullobj, ref nullobj,
                                                                                ref nullobj, ref nullobj, ref nullobj);
                    mydoc.ExportAsFixedFormat(paramExportFilePath,
                                              paramExportFormat,
                                              paramOpenAfterExport,
                                              paramExportOptimizeFor,
                                              paramExportRange,
                                              paramStartPage,
                                              paramEndPage,
                                              paramExportItem,
                                              paramIncludeDocProps,
                                              paramKeepIRM,
                                              paramCreateBookmarks,
                                              paramDocStructureTags,
                                              paramBitmapMissingFonts,
                                              paramUseISO19005_1,
                                              ref nullobj);

                    mydoc.Close(ref doNotSaveChanges, ref nullobj, ref nullobj);
                    myWinWord.Quit(ref doNotSaveChanges, ref nullobj, ref nullobj);
                    pdfFilePath = paramExportFilePath;
                    //_owner.DisplayFromFile(paramExportFilePath);

                }
                else if (lastValue == "xlsx" || lastValue == "xls")
                {
                    //MessageFilter.Register();
                    int num = 0;
                    object missingType = Type.Missing;
                    object nullobj = System.Reflection.Missing.Value;

                    //Microsoft.Office.Interop.Excel.Application objApp = null;
                    WinExcl._Application objApp = null;
                    WinExcl._Workbook objBook = null;
                    WinExcl.Workbooks objBooks = null;
                    //WinExcl.Sheets objSheets = null;
                    //WinExcl._Worksheet objSheet = null;




                    //Microsoft.Office.Interop.Excel.Range range = null;
                    //Microsoft.Office.Interop.Excel.Worksheet worksheet = null;


                    try
                    {
                        objApp = new WinExcl.Application();
                        objBooks = objApp.Workbooks;
                        objBook = objBooks.Add(Missing.Value);
                        //objSheets = objBook.Worksheets;
                        //objSheet = (Microsoft.Office.Interop.Excel._Worksheet)objSheets.get_Item(1);
                        //objApp.ScreenUpdating = false;


                        objApp.Visible = false;
                        objApp.UserControl = false;

                        objApp.Interactive = false;

                        //-------------------------------------------------------------------------------
                        objApp.ScreenUpdating = false;
                        objApp.DisplayAlerts = true;

                        string paramExportFilePath = directoryName + fileName + "_" + current.ToString("yyyyMMddHHmmss") + "_" + "tempExcel.pdf";
                        //Excel인증 메시지 확인버튼을 누르지 않으면 에러가 나는 문제가 있어 적용함.
                        bool result = TryUntilSuccess(() =>
                        {
                            objBook = objApp.Workbooks.Open(file.ToString(), nullobj, true, nullobj, nullobj, nullobj, nullobj, nullobj, nullobj, nullobj, nullobj, nullobj, nullobj, nullobj, nullobj);

                            if (objBook == null)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show("불러오기 실패");
                                return;
                            }

                            //((Microsoft.Office.Interop.Excel.Worksheet)objBook.ActiveSheet).PageSetup.CenterHorizontally = true;

                            //Microsoft.Office.Interop.Excel.PageSetup
                            //worksheet = objBook.Worksheets.Add(objSheets[0], Type.Missing, Type.Missing, Type.Missing);
                            //var xlNewSheet = (Worksheet)xlSheets.Add(xlSheets[sheetNo], Type.Missing, Type.Missing, Type.Missing);

                            //(objSheets[0] as Microsoft.Office.Interop.Excel._Worksheet).PageSetup.CenterHorizontally = true;

                            foreach (WinExcl._Worksheet sheet in (objBook as Microsoft.Office.Interop.Excel._Workbook).Worksheets)
                            {
                                sheet.PageSetup.Orientation = WinExcl.XlPageOrientation.xlPortrait;
                                sheet.PageSetup.PaperSize = Microsoft.Office.Interop.Excel.XlPaperSize.xlPaperA4;
                                sheet.PageSetup.Zoom = false;
                                //sheet.PageSetup.PaperSize = WinExcl.XlPaperSize.xlPaperLegal;
                                sheet.PageSetup.FitToPagesWide = 1;
                                sheet.PageSetup.FitToPagesTall = false;
                                sheet.PageSetup.BottomMargin = 0;
                                sheet.PageSetup.TopMargin = 0;
                                sheet.PageSetup.RightMargin = 0;
                                sheet.PageSetup.LeftMargin = 0;
                            }


                            //(objBook as Microsoft.Office.Interop.Excel._Workbook).Worksheets.Item[1].PageSetup.CenterHorizontally = true;
                            //(objBook as Microsoft.Office.Interop.Excel._Workbook).Worksheets.Item[1].PageSetup.CenterVertically = true;
                            //(objBook as Microsoft.Office.Interop.Excel._Workbook).Worksheets.Item[1].PageSetup.Orientation = WinExcl.XlPageOrientation.xlLandscape;
                            //(objBook as Microsoft.Office.Interop.Excel._Workbook).Worksheets.Item[1].PageSetup.Zoom = false;
                            //(objBook as Microsoft.Office.Interop.Excel._Workbook).Worksheets.Item[1].PageSetup.FitToPagesWide = 1;
                            //(objBook as Microsoft.Office.Interop.Excel._Workbook).Worksheets.Item[1].PageSetup.FitToPagesTall = 1;
                            //(objBook as Microsoft.Office.Interop.Excel._Workbook).Worksheets.Item[1].PageSetup.BottomMargin = 0;
                            //(objBook as Microsoft.Office.Interop.Excel._Workbook).Worksheets.Item[1].PageSetup.TopMargin = 0;
                            //(objBook as Microsoft.Office.Interop.Excel._Workbook).Worksheets.Item[1].PageSetup.RightMargin = 0;
                            //(objBook as Microsoft.Office.Interop.Excel._Workbook).Worksheets.Item[1].PageSetup.LeftMargin = 0;





                            objBook.ExportAsFixedFormat(Microsoft.Office.Interop.Excel.XlFixedFormatType.xlTypePDF, paramExportFilePath, IncludeDocProperties: true, IgnorePrintAreas: false, OpenAfterPublish: false);



                            //objBook.SaveAs(strFileName,
                            //            Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                            //            missingType, missingType, missingType, missingType,
                            //            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                            //            missingType, missingType, missingType, missingType, missingType);
                            objBook.Close(false, missingType, missingType);

                            Cursor.Current = Cursors.Default;

                            //Process process = new Process();
                            //process.StartInfo.FileName = strFileName;
                            //process.Start();
                            //MessageBox.Show("Save Success!!!");

                            //_owner.DisplayFromFile(paramExportFilePath);
                            //pdfFilePath = paramExportFilePath;

                            //ok = true;



                        });

                        if (result == true)
                        {
                            pdfFilePath = paramExportFilePath;
                        }


                    }
                    catch (Exception theException)
                    {
                        String errorMessage;
                        errorMessage = "Error: ";
                        errorMessage = String.Concat(errorMessage, theException.Message);
                        errorMessage = String.Concat(errorMessage, " Line: ");
                        errorMessage = String.Concat(errorMessage, theException.Source);

                        DevExpress.XtraEditors.XtraMessageBox.Show(errorMessage, "Error");
                    }
                    finally
                    {
                        //if (objBook != null)
                        //{
                        //    objBook.Close(false, missingType, missingType);
                        //}

                        ReleaseExcelObject(objApp);
                        ReleaseExcelObject(objBook);
                        ReleaseExcelObject(objBooks);




                        //ReleaseExcelObject(objSheets);
                        //ReleaseExcelObject(objSheet);

                        //MessageFilter.Revoke();
                    }
                }
                else if (lastValue == "pptx" || lastValue == "pot")
                {
                    //isDirectRead = true;





                    Microsoft.Office.Interop.PowerPoint.Presentation presentation = null;
                    Microsoft.Office.Interop.PowerPoint.Application application = null;
                    //var test = new WinPower.Application();
                    //WinPower._Application application = new WinPower.Application();
                    try
                    {




                        application = new Microsoft.Office.Interop.PowerPoint.Application();
                        //application.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                        //application.Visible = Microsoft.Office.Core.MsoTriState.msoFalse;
                        presentation = application.Presentations.Open(file.ToString(), Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoFalse);

                        string paramExportFilePath = directoryName + fileName + "_" + current.ToString("yyyyMMddHHmmss") + "_" + "tempPPT.pdf";

                        presentation.SaveAs(paramExportFilePath, Microsoft.Office.Interop.PowerPoint.PpSaveAsFileType.ppSaveAsPDF, Microsoft.Office.Core.MsoTriState.msoTrue);

                        pdfFilePath = paramExportFilePath;

                        //_owner.DisplayFromFile(paramExportFilePath);
                        //result = true;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.Message);
                        //result = false;
                    }
                    finally
                    {
                        if (presentation != null)
                        {
                            presentation.Close();
                            presentation = null;
                        }
                        if (application != null)
                        {
                            application.Quit();
                            application = null;
                        }
                    }

                }
            }


            return true;
        }
        #endregion

        private void ExcelTest()
        {
        }

        #region [엑셀 오브젝트 메모리해제]
        /// <summary>
        /// name         : ReleaseExcelObject
        /// desc         : 엑셀 오브젝트 메모리해제
        /// author       : 심우종
        /// create date  : 2020-05-19 09:01
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ReleaseExcelObject(object obj)
        {
            try
            {
                if (obj != null)
                {
                    Marshal.ReleaseComObject(obj);
                    obj = null;
                }
            }
            catch (Exception ex)
            {
                obj = null;
                throw ex;
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion

        #region [office 인증관련 팝업 대기를 위해 사용]
        /// <summary>
        /// name         : TryUntilSuccess
        /// desc         : office 인증관련 팝업 대기를 위해 사용
        /// author       : 심우종
        /// create date  : 2020-05-19 09:00
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary>  
        int errorWatingCount = 0;
        private bool TryUntilSuccess(Action action)
        {
            bool success = false;
            errorWatingCount = 0;
            while (!success)
            {
                try
                {
                    action();
                    success = true;
                    return true;
                }

                catch (System.Runtime.InteropServices.COMException e)
                {
                    errorWatingCount++;
                    if (errorWatingCount == 30)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("파일을 열수 없습니다.");
                        //throw e;
                        return false;
                    }

                    //Excel 인증창에 대한 팝업.. 확인버튼 누를떄까지 대기
                    if (e.ErrorCode == -2147418111 || e.ErrorCode == -2146777998)
                    {   // Excel is busy
                        Thread.Sleep(500); // Wait, and...
                        success = false;  // ...try again
                    }
                    else
                    {   // Re-throw!
                        throw e;
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        public bool PdfToImage(string pdfFilePath, ref List<string> imageFilePathList)
        {
            LicenseManager licenseManager = new LicenseManager();
            licenseManager.RegisterKEY("21185684790302862131615213975647244276");

            bool isSuccess = false;
            int multiTiffID = 0;
            GdPictureImaging oGdPictureImaging = new GdPictureImaging();
            GdPicturePDF oGdPicturePDF = new GdPicturePDF();


            string imageDirectory = System.Environment.CurrentDirectory + "\\TempPdfToImage\\";
            GdPictureStatus status = oGdPicturePDF.LoadFromFile(pdfFilePath, false);


            //임시파일 경로가 존재하지 않으면 생성
            DirectoryInfo dir = new DirectoryInfo(imageDirectory);
            if (!dir.Exists)
            {
                dir.Create();
            }

            //임시파일의 이미지 지우기
            FileInfo[] fileList = dir.GetFiles();
            foreach (FileInfo f in fileList)
            {
                f.Delete();
            }

            List<string> savedImages = new List<string>();

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
                        string filePath = imageDirectory + "output" + i.ToString() + ".jpeg";
                        //If it is the first page.
                        multiTiffID = rasterizedPageID;
                        status = oGdPictureImaging.SaveAsJPEG(multiTiffID, filePath);


                        if (status != GdPictureStatus.OK)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("TiffSaveAsMultiPageFile - Error: " + status.ToString(), "Converting PDF to TIFF Example", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            break;
                        }
                        else
                        {
                            imageFilePathList.Add(filePath);
                        }
                    }
                    else
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("RenderPageToGdPictureImageEx - Error: " + oGdPicturePDF.GetStat().ToString(), "Converting PDF to TIFF Example", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        break;
                    }
                }
                //Closing the multipage tiff file.
                oGdPictureImaging.TiffCloseMultiPageFile(multiTiffID);
                //Releasing the multipage tiff image.
                oGdPictureImaging.ReleaseGdPictureImage(multiTiffID);
                //Closing and release the PDF document.
                oGdPicturePDF.CloseDocument();
                DevExpress.XtraEditors.XtraMessageBox.Show("Done!", "Converting PDF to TIFF Example", MessageBoxButtons.OK, MessageBoxIcon.Information);
                isSuccess = true;
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("The PDF document can't be loaded. Status: " + status.ToString(), "Converting PDF to TIFF Example", MessageBoxButtons.OK, MessageBoxIcon.Error);
                isSuccess = false;


            }
            oGdPictureImaging.Dispose();
            oGdPicturePDF.Dispose();


            //imageFilePathList = savedImages;

            return isSuccess;
        }



        /// <summary>
        /// name         : SaveToThumbnailImage
        /// desc         : 섬네일 이미지를 리턴한다.
        /// author       : 심우종
        /// create date  : 2020-06-25 14:05
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public Image SaveToThumbnailImage(string filePath)
        {

            if (string.IsNullOrEmpty(filePath)) return null;

            string imageDirectory = System.Environment.CurrentDirectory + "\\TempThumbnailImage\\";

            DirectoryInfo di = new DirectoryInfo(imageDirectory);
            if (di.Exists == false)
            {
                di.Create();
            }

            string newthumbnailPath = imageDirectory + "thumbnail.png";

            using (GdPictureImaging gdpictureImaging = new GdPictureImaging())
            {
                // Create a thumbnail with a black background that is 100 pixels width and 200 pixels height.
                // An empty string allows the control to prompt for selecting an input file.
                int thumbnailID = gdpictureImaging.CreateThumbnailHQ(filePath, 200, 200, gdpictureImaging.ARGBI(255, 0, 0, 0)); //검은색 바탕

                GdPictureStatus status = gdpictureImaging.SaveAsPNG(thumbnailID, newthumbnailPath);

                if (status == GdPictureStatus.OK)
                {
                    string strBmp = newthumbnailPath;

                    FileStream fs;
                    fs = new FileStream(strBmp, FileMode.Open, FileAccess.Read);
                    Image image = System.Drawing.Image.FromStream(fs);

                    fs.Close();

                    return image;
                }
                else
                {
                    return null;
                }
            }


        }


        /// <summary>
        /// name         : PdfThumbnail
        /// desc         : PDF파일에 대한 섬네일 리턴(첫 페이지 이미지를 섬네일로 리턴함)
        /// author       : 심우종
        /// create date  : 2020-07-02 09:14
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public Image PdfThumbnail(string strRowFilePath)
        {
            GdPicturePDF oGdPicturePDF = new GdPicturePDF();
            GdPictureStatus status = oGdPicturePDF.LoadFromFile(strRowFilePath, false);
            if (status == GdPictureStatus.OK)
            {
                if (oGdPicturePDF.GetPageCount() > 0)
                {
                    oGdPicturePDF.SelectPage(0);
                    int rasterizedPageID = oGdPicturePDF.RenderPageToGdPictureImageEx(200.0f, true);

                    if (oGdPicturePDF.GetStat() == GdPictureStatus.OK)
                    {

                        using (GdPictureImaging gdpictureImaging = new GdPictureImaging())
                        {
                            string imageDirectory = System.Environment.CurrentDirectory + "\\TempThumbnailImage\\";

                            DirectoryInfo directoryInfo = new DirectoryInfo(imageDirectory);
                            if (directoryInfo.Exists == false)
                            {
                                directoryInfo.Create();
                            }

                            string newthumbnailPath = imageDirectory + "thumbnail.png";

                            int thumbnailID = gdpictureImaging.CreateThumbnailHQ(rasterizedPageID, 200, 200, gdpictureImaging.ARGBI(255, 0, 0, 0)); //검은색 바탕

                            GdPictureStatus status2 = gdpictureImaging.SaveAsPNG(thumbnailID, newthumbnailPath);

                            if (status2 == GdPictureStatus.OK)
                            {
                                string strBmp = newthumbnailPath;

                                FileStream fs;
                                fs = new FileStream(strBmp, FileMode.Open, FileAccess.Read);
                                Image image = System.Drawing.Image.FromStream(fs);

                                fs.Close();

                                return image;
                            }
                            else
                            {
                                return null;
                            }
                        }
                    }
                }
            }

            return null;
        }
    }
}
