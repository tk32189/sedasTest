using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DGS_Viewer.DTO;

namespace DGS_Viewer
{
    public partial class ImagePrintPopup : DevExpress.XtraEditors.XtraForm
    {

        DataRow order = null;
        List<ImageContainer> imageList = null;

        public ImagePrintPopup()
        {
            InitializeComponent();
        }



        /// <summary>
        /// name         : SendData
        /// desc         : 초기 데이터를 전달받는다.
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void SendData(DataRow order, List<ImageContainer> imageList)
        {
            this.order = order;
            this.imageList = imageList;


            //초기 라디오 버튼 선택값
            this.rdoAll.Checked = true;
            this.rdo1x1.Checked = true;

            bool isSelectedImageExists = false;
            if (this.imageList != null && this.imageList.Count > 0)
            {
                if (this.imageList.Where(e => e.IsSelected == true).Count() > 0)
                {
                    //선택된 이미지가 존재하는 경우
                    isSelectedImageExists = true;

                }
                else
                {

                }
            }

            if (isSelectedImageExists == true)
            {
                rdoSelect.Checked = true;
            }
            else
            {
                rdoSelect.Enabled = false;
            }

        }


        /// <summary>
        /// name         : btnPrint_Click
        /// desc         : 인쇄 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-03-18 14:32
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnPrint_Click(object sender, EventArgs e)
        {
            //////정리해야 될 값
            int ncount = 1; //
            string pathologyNumber = this.order["ptoNo"].ToString(); // "S2008128"; //병리번호
            string suffererID = this.order["ptNo"].ToString(); // "2265235"; //등록번호
            string suffererName = this.order["ptNm"].ToString(); // "TEST네임!!!!";// 성명
            string age = this.order["age"].ToString(); // "77";//나이
            string sex = this.order["sex"].ToString(); // "F"; //성별
            string ageSex = string.Format("{0} / {1}", age, sex);


            List<ImageContainer> imageToExcel = null;
            if (rdoSelect.Checked == true)
            {
                List<ImageContainer> selectedImages = this.imageList.Where(o => o.IsSelected == true).ToList();
                if (selectedImages != null && selectedImages.Count > 0)
                {
                    imageToExcel = selectedImages;
                }
            }
            else
            {
                imageToExcel = this.imageList;
            }



            if (imageToExcel == null || imageToExcel.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("출력할 이미지가 존재하지 않습니다.");
                return;
            }

            int needToSheetCount = 0;

            if (rdo1x1.Checked == true)
            {
                needToSheetCount = imageToExcel.Count;
            }
            else if (rdo1x2.Checked == true)
            {
                needToSheetCount = (imageToExcel.Count + 1) / 2;
            }
            else if (rdo2x2.Checked == true)
            {
                needToSheetCount = (imageToExcel.Count + 3) / 4;
            }


            //int num = 0;
            //bool borderYn = true;
            object missingType = Type.Missing;

            Microsoft.Office.Interop.Excel.Application objApp = null;
            Microsoft.Office.Interop.Excel._Workbook objBook = null;
            Microsoft.Office.Interop.Excel.Workbooks objBooks = null;
            Microsoft.Office.Interop.Excel.Sheets objSheets = null;
            Microsoft.Office.Interop.Excel._Worksheet objSheet = null;
            Microsoft.Office.Interop.Excel.Range range;
            Microsoft.Office.Interop.Excel.Shape shape;



            try
            {
                //excel파일 경로 지정
                string excelpath = Global.strExcelPath + "\\soon.xls";
                string excelpath2 = Global.strExcelPath + "\\soon_h.xls";

                File.Delete(excelpath2); //기존 파일 삭제
                File.Copy(excelpath, excelpath2, true); //soon을 soon_h로 복사


                objApp = new Microsoft.Office.Interop.Excel.Application();
                objBooks = objApp.Workbooks;

                object mis = Type.Missing;
                objBook = objApp.Workbooks.Open(excelpath2);
                //objBook = objBooks.Add(Missing.Value);
                objSheets = objBook.Worksheets;

                //0, 1, 2
                for (int i = 0; i < needToSheetCount; i++)
                {
                    if (i >= 3) break;

                    objSheet = (Microsoft.Office.Interop.Excel._Worksheet)objSheets.get_Item(i+1);

                    if (!string.IsNullOrEmpty(pathologyNumber))
                    {
                        //등록번호
                        range = objSheet.get_Range("C13");
                        range.set_Value(Missing.Value, suffererID);

                        //병리번호
                        range = objSheet.get_Range("F14");
                        range.set_Value(Missing.Value, pathologyNumber);

                        //성명
                        range = objSheet.get_Range("F13");
                        range.set_Value(Missing.Value, suffererName);

                        //나이/성별
                        range = objSheet.get_Range("C14");
                        range.set_Value(Missing.Value, ageSex);
                    }

                    //진단명
                    range = objSheet.get_Range("C15");
                    range.set_Value(Missing.Value, this.txtDignosis.Text);

                    //비고
                    range = objSheet.get_Range("C17");
                    range.set_Value(Missing.Value, this.txtComment.Text);

                    //현재시간
                    DateTime nowDt = DateTime.Now;
                    string strNowDt = "'" + nowDt.ToString("yyyyMMdd");
                    range = objSheet.get_Range("G53");
                    range.set_Value(Missing.Value, strNowDt);

                    string tempVal = "병 리 과  ";
                    range = objSheet.get_Range("H53");
                    range.set_Value(Missing.Value, tempVal);



                    if (rdo1x1.Checked == true)
                    {
                        objSheet.Shapes.AddPicture(imageToExcel[i].Path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 3, 270, 492, 394);
                    }
                    else if (rdo1x2.Checked == true)
                    {
                        objSheet.Shapes.AddPicture(imageToExcel[2*i].Path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 100, 260, 290, 215);

                        if (2 * i + 1 < imageToExcel.Count)
                        {
                            objSheet.Shapes.AddPicture(imageToExcel[2 * i + 1].Path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 100, 476, 290, 215);
                        }
                    }
                    else if (rdo2x2.Checked == true)
                    {
                        
                        objSheet.Shapes.AddPicture(imageToExcel[4 * i].Path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 4, 274, 242, 195);

                        if (4 * i + 1 < imageToExcel.Count)
                        {
                            objSheet.Shapes.AddPicture(imageToExcel[4 * i + 1].Path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 248, 274, 242, 195);
                        }
                        if (4 * i + 2 < imageToExcel.Count)
                        {
                            objSheet.Shapes.AddPicture(imageToExcel[4 * i + 2].Path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 4, 472, 242, 195);
                        }
                        if (4 * i + 3 < imageToExcel.Count)
                        {
                            objSheet.Shapes.AddPicture(imageToExcel[4 * i + 3].Path, Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue, 248, 472, 242, 195);
                        }
                    }

                }

                objApp.Visible = false;
                objApp.UserControl = false;
                string strFileName = excelpath2; // System.Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyyMMddhhmmssfff") + ".xls";
                objBook.Save();
                //objBook.SaveAs(strFileName,
                //            Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                //            missingType, missingType, missingType, missingType,
                //            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                //            missingType, missingType, missingType, missingType, missingType);
                objBook.Close(false, missingType, missingType);

                Cursor.Current = Cursors.Default;

                Process process = new Process();
                process.StartInfo.FileName = strFileName;
                process.Start();
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
                ReleaseExcelObject(objApp);
                ReleaseExcelObject(objBook);
                ReleaseExcelObject(objBooks);
                ReleaseExcelObject(objSheets);
                ReleaseExcelObject(objSheet);
            }
        }



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


        /// <summary>
        /// name         : btnCancel_Click
        /// desc         : 취소버튼 클릭스
        /// author       : 심우종
        /// create date  : 2020-03-18 16:58
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
