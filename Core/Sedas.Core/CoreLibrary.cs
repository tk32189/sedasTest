using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;
using ClosedXML.Excel;
using System.Diagnostics;
using System.Windows.Forms;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Sedas.Core
{
    public class CoreLibrary
    {
        #region 테이블 값 복사(DataTable => DataTable)
        /// <summary>
        /// 테이블 값 복사(DataTable => DataTable)
        /// </summary>
        /// <param name="targetTable"></param>
        /// <returns></returns>
        public void TableCopy(DataTable targetTable, ref DataTable resultTable)
        {
            // DataTable dt = new DataTable();


            foreach (DataRow dr in targetTable.Rows)
            {
                DataRow newDr = resultTable.NewRow();
                foreach (DataColumn dc in targetTable.Columns)
                {
                    if (resultTable.Columns.Contains(dc.ColumnName) == true)
                    {
                        if (string.IsNullOrEmpty(dr[dc.ColumnName].ToString()))
                            newDr[dc.ColumnName] = DBNull.Value;
                        else
                            newDr[dc.ColumnName] = dr[dc.ColumnName];
                    }
                }

                resultTable.Rows.Add(newDr);
            }

        }
        #endregion

        #region 테이블 값 복사(DataRow => DataTable)
        /// <summary>
        /// 테이블 값 복사(DataRow => DataTable)
        /// </summary>
        /// <param name="targetTable"></param>
        /// <returns></returns>
        public DataRow TableCopy(DataRow targetRow, ref DataTable resultTable)
        {
            DataRow newDr = resultTable.NewRow();
            foreach (DataColumn dc in targetRow.Table.Columns)
            {
                if (resultTable.Columns.Contains(dc.ColumnName) == true)
                {
                    if (string.IsNullOrEmpty(targetRow[dc.ColumnName].ToString()))
                        newDr[dc.ColumnName] = DBNull.Value;
                    else
                        newDr[dc.ColumnName] = targetRow[dc.ColumnName];
                }
            }

            resultTable.Rows.Add(newDr);
            return newDr;
        }
        #endregion

        #region 테이블 값 복사(DataRow<T> => DataTable)
        /// <summary>
        /// 테이블 값 복사(DataRow<T> => DataTable)
        /// </summary>
        /// <param name="targetTable"></param>
        /// <returns></returns>
        public DataRow TableCopy<T>(DataRow targetRow, ref T resultTable) where T : DataTable
        {
            DataRow newDr = resultTable.NewRow();
            foreach (DataColumn dc in targetRow.Table.Columns)
            {
                if (resultTable.Columns.Contains(dc.ColumnName) == true)
                {
                    if (string.IsNullOrEmpty(targetRow[dc.ColumnName].ToString()))
                        newDr[dc.ColumnName] = DBNull.Value;
                    else
                        newDr[dc.ColumnName] = targetRow[dc.ColumnName];
                }
            }

            resultTable.Rows.Add(newDr);
            return newDr;
        }
        #endregion

        #region 테이블 값 복사(DataTable => <T>DataTable)
        public void TableCopy<T>(DataTable targetTable, ref T resultTable) where T : DataTable
        {
            foreach (DataRow dr in targetTable.Rows)
            {
                DataRow newDr = resultTable.NewRow();
                foreach (DataColumn dc in targetTable.Columns)
                {
                    if (resultTable.Columns.Contains(dc.ColumnName) == true)
                    {
                        if (string.IsNullOrEmpty(dr[dc.ColumnName].ToString()))
                            newDr[dc.ColumnName] = DBNull.Value;
                        else
                            newDr[dc.ColumnName] = dr[dc.ColumnName];
                    }
                }

                resultTable.Rows.Add(newDr);
            }

        }
        #endregion

        #region 테이블 값 복사(DataRow => DataRow)
        /// <summary>
        /// 테이블 값 복사(DataRow => DataRow)
        /// </summary>
        /// <param name="targetTable"></param>
        /// <returns></returns>
        public void TableCopy(DataRow targetRow, ref DataRow resultRow)
        {
            //DataRow newDr = resultTable.NewRow();
            foreach (DataColumn dc in targetRow.Table.Columns)
            {
                if (resultRow.Table.Columns.Contains(dc.ColumnName) == true)
                {
                    if (string.IsNullOrEmpty(targetRow[dc.ColumnName].ToString()))
                        resultRow[dc.ColumnName] = DBNull.Value;
                    else
                        resultRow[dc.ColumnName] = targetRow[dc.ColumnName];
                }
            }

            //resultTable.Rows.Add(newDr);


        }
        #endregion

        #region GridControl 엑셀출력(CloseXML Neget에서 추가설치 필요)
        public void GridControlToExcelByClosedXML(Sedas.Control.GridControl.HGridView grdView, bool titleYn = true, bool borderYn = true, string excelPath = "")
        {
            //설정 옵션
            /////////////////////////////////////////////////////////
            //bool titleYn = true; //타이틀 표시여부
            //bool borderYn = true; //Border 필요여부
            //string excelPath = "" //엑셀파일 생성 경로 없으면 실행파일이 있는 디렉토리에 자동생성
            ////////////////////////////////////////////////////////
            ///
            //var workbook = new XLWorkbook("양식있는빈엑셀.xlsx");  // 기존 엑셀 열기

            var workbook = new XLWorkbook(); // 새 엑셀 열기


            var worksheet = workbook.Worksheets.Add("Sheet1");  // 빈 sheet추가하기
            //var worksheet = workbook.Worksheet(1);  // 첫번째 sheet열기

            //var worksheet = workbook.Worksheets.Add("Sheet1");  // 빈 sheet추가하기

            int num = 0;
            object missingType = Type.Missing;
            //string[] headers = new string[dgvList.ColumnCount];
            string[] columns = new string[grdView.Columns.Count];
            string[] columnsFieldName = new string[grdView.Columns.Count];

            for (int c = 0; c < grdView.Columns.Count; c++)
            {
                //headers[c] = dgvList.Rows[0].Cells[c].OwningColumn.HeaderText.ToString();
                num = c + 65;
                columns[c] = Convert.ToString((char)num);
                columnsFieldName[c] = grdView.Columns[c].FieldName.ToString();
            }

            //해더 표시
            if (titleYn == true)
            {
                if (grdView.Columns != null && grdView.Columns.Count > 0)
                {
                    for (int i = 0; i < grdView.Columns.Count; i++)
                    {


                        worksheet.Cell(columns[i] + "1").Value = grdView.Columns[i].Caption.ToString();
                        worksheet.Cell(columns[i] + "1").Style.Font.Bold = true;

                        worksheet.Columns(columns[i]).Width = Math.Round((Double)(grdView.Columns[i].Width / 6));

                        //range.ColumnWidth = Math.Round((Double)(grdView.Columns[i].Width / 6));
                        //해더 정렬
                        if (grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Center)
                        {
                            //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            worksheet.Cell(columns[i] + "1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                        }
                        else if (grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Near)
                        {
                            //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            worksheet.Cell(columns[i] + "1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                        }
                        else if (grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Far)
                        {
                            //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                            worksheet.Cell(columns[i] + "1").Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                        }
                    }
                }

                //worksheet.Columns(columns[0], columns[grdView.Columns.Count-1]).AdjustToContents();
            }


            if (grdView.DataRowCount > 0)
            {
                for (int i = 0; i < grdView.DataRowCount; i++)
                {
                    for (int j = 0; j < columnsFieldName.Length; j++)
                    {
                        object value = grdView.GetRowCellValue(i, columnsFieldName[j].ToString());
                        if (value != null)
                        {



                            worksheet.Cell(columns[j] + Convert.ToString(i + 2)).Value = "'" + value.ToString();


                            //range = objSheet.get_Range(columns[j] + Convert.ToString(i + 2), Missing.Value);
                            //// 문자로 변환하기 위해서 "'" 추가
                            //range.set_Value(Missing.Value, "'" + value.ToString());

                            //정렬
                            if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Center)
                            {
                                //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                worksheet.Cell(columns[j] + Convert.ToString(i + 2)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Center;
                            }
                            else if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Near)
                            {
                                //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                                worksheet.Cell(columns[j] + Convert.ToString(i + 2)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Left;
                            }
                            else if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Far)
                            {
                                //range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                worksheet.Cell(columns[j] + Convert.ToString(i + 2)).Style.Alignment.Horizontal = XLAlignmentHorizontalValues.Right;
                            }


                        }

                    }
                }
            }

            //테두리 그리기
            if (borderYn == true)
            {
                worksheet.Range("A1", columns[columns.Length - 1].ToString() + (grdView.DataRowCount + 1).ToString()).Style.Border.InsideBorder = XLBorderStyleValues.Thin;
                worksheet.Range("A1", columns[columns.Length - 1].ToString() + (grdView.DataRowCount + 1).ToString()).Style.Border.OutsideBorder = XLBorderStyleValues.Thin;

                //range = objSheet.get_Range("A1", columns[columns.Length - 1] + (grdView.DataRowCount + 1).ToString());
                ////선 종류
                //range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                ////선 두께
                //range.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
            }


            string strFileName = "";
            if (!string.IsNullOrEmpty(excelPath))
            {
                strFileName = excelPath + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xlsx";
            }
            else
            {
                strFileName = System.Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".xlsx";
            }

            workbook.SaveAs(strFileName);  // 새로운 이름으로 저장하기

            //objApp.ScreenUpdating = true;

            //objBook.SaveAs(strFileName,
            //            Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
            //            missingType, missingType, missingType, missingType,
            //            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
            //            missingType, missingType, missingType, missingType, missingType);
            //objBook.Close(false, missingType, missingType);

            //Cursor.Current = Cursors.Default;

            Process process = new Process();
            process.StartInfo.FileName = strFileName;
            process.Start();
        }
        #endregion

        #region GridControl 엑셀출력 - 속도느림
        /// <summary>
        /// name         : GridControlToExcel
        /// desc         : 그리드 컨트롤 내용을 엑셀로 출력한다.
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void GridControlToExcel(Sedas.Control.GridControl.HGridView grdView, bool titleYn = true, bool borderYn = true, string excelPath = "")
        {
            //설정 옵션
            /////////////////////////////////////////////////////////
            //bool titleYn = true; //타이틀 표시여부
            //bool borderYn = true; //Border 필요여부
            //string excelPath = "" //엑셀파일 생성 경로 없으면 실행파일이 있는 디렉토리에 자동생성
            ////////////////////////////////////////////////////////


            //Sedas.Control.GridControl.HGridView grdView = this.hGridView1;


            int num = 0;
            object missingType = Type.Missing;

            Microsoft.Office.Interop.Excel.Application objApp = null;
            Microsoft.Office.Interop.Excel._Workbook objBook = null;
            Microsoft.Office.Interop.Excel.Workbooks objBooks = null;
            Microsoft.Office.Interop.Excel.Sheets objSheets = null;
            Microsoft.Office.Interop.Excel._Worksheet objSheet = null;
            Microsoft.Office.Interop.Excel.Range range = null;


            //string[] headers = new string[dgvList.ColumnCount];
            string[] columns = new string[grdView.Columns.Count];
            string[] columnsFieldName = new string[grdView.Columns.Count];

            for (int c = 0; c < grdView.Columns.Count; c++)
            {
                //headers[c] = dgvList.Rows[0].Cells[c].OwningColumn.HeaderText.ToString();
                num = c + 65;
                columns[c] = Convert.ToString((char)num);
                columnsFieldName[c] = grdView.Columns[c].FieldName.ToString();
            }

            try
            {
                objApp = new Microsoft.Office.Interop.Excel.Application();
                objBooks = objApp.Workbooks;
                objBook = objBooks.Add(Missing.Value);
                objSheets = objBook.Worksheets;
                objSheet = (Microsoft.Office.Interop.Excel._Worksheet)objSheets.get_Item(1);
                objApp.ScreenUpdating = false;
                //if (captions)
                //{
                //    for (int c = 0; c < dgvList.ColumnCount; c++)
                //    {

                //        range = objSheet.get_Range(columns[c] + "1", Missing.Value);
                //        range.set_Value(Missing.Value, headers[c]);
                //    }
                //}

                //해더 표시
                if (titleYn == true)
                {
                    if (grdView.Columns != null && grdView.Columns.Count > 0)
                    {
                        for (int i = 0; i < grdView.Columns.Count; i++)
                        {
                            range = objSheet.get_Range(columns[i] + "1", Missing.Value);
                            range.set_Value(Missing.Value, grdView.Columns[i].Caption.ToString());
                            range.Font.Bold = true;

                            //컬럼 사이즈 지정할때는 여기서 하자...
                            range.Columns.AutoFit();

                            range.ColumnWidth = Math.Round((Double)(grdView.Columns[i].Width / 6));
                            //해더 정렬
                            if (grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Center)
                            {
                                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                            }
                            else if (grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Near)
                            {
                                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                            }
                            else if (grdView.Columns[i].AppearanceHeader.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Far)
                            {
                                range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                            }
                        }
                    }
                }

                //그리드 내용 출력
                if (grdView.DataRowCount > 0)
                {
                    for (int i = 0; i < grdView.DataRowCount; i++)
                    {
                        for (int j = 0; j < columnsFieldName.Length; j++)
                        {
                            object value = grdView.GetRowCellValue(i, columnsFieldName[j].ToString());
                            if (value != null)
                            {
                                range = objSheet.get_Range(columns[j] + Convert.ToString(i + 2), Missing.Value);
                                // 문자로 변환하기 위해서 "'" 추가
                                range.set_Value(Missing.Value, "'" + value.ToString());

                                //정렬
                                if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Center)
                                {
                                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignCenter;
                                }
                                else if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Near)
                                {
                                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignLeft;
                                }
                                else if (grdView.Columns[j].AppearanceCell.TextOptions.HAlignment == DevExpress.Utils.HorzAlignment.Far)
                                {
                                    range.HorizontalAlignment = Microsoft.Office.Interop.Excel.XlHAlign.xlHAlignRight;
                                }


                            }

                        }
                    }
                }

                //테두리 그리기
                if (borderYn == true)
                {
                    range = objSheet.get_Range("A1", columns[columns.Length - 1] + (grdView.DataRowCount + 1).ToString());
                    //선 종류
                    range.Borders.LineStyle = Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous;
                    //선 두께
                    range.Borders.Weight = Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin;
                }



                objApp.Visible = false;
                objApp.UserControl = false;


                string strFileName = "";
                if (!string.IsNullOrEmpty(excelPath))
                {
                    strFileName = excelPath + DateTime.Now.ToString("yyyy-MM-dd-HH-mm-ss") + ".xls";
                }
                else
                {
                    strFileName =  System.Environment.CurrentDirectory + "\\" + DateTime.Now.ToString("yyyy-MM-dd-hh-mm-ss") + ".xls";
                }

                objApp.ScreenUpdating = true;

                objBook.SaveAs(strFileName,
                            Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
                            missingType, missingType, missingType, missingType,
                            Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlNoChange,
                            missingType, missingType, missingType, missingType, missingType);
                objBook.Close(false, missingType, missingType);

                Cursor.Current = Cursors.Default;

                Process process = new Process();
                process.StartInfo.FileName = strFileName;
                process.Start();
                //MessageBox.Show("Save Success!!!");
            }
            catch (Exception theException)
            {
                String errorMessage;
                errorMessage = "Error: ";
                errorMessage = String.Concat(errorMessage, theException.Message);
                errorMessage = String.Concat(errorMessage, " Line: ");
                errorMessage = String.Concat(errorMessage, theException.Source);

                DevExpress.XtraEditors.XtraMessageBox.Show(errorMessage, "Error");
                //MessageBox.Show(errorMessage, "Error");
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
        #endregion


        /// <summary>
        /// name         : DupFileRenameCheck
        /// desc         : 파일명 중복체크
        /// author       : 심우종
        /// create date  : 2020-05-22 10:21
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public string DupFileRenameCheck(string newFilePath, string newFileName, bool isNeedToDupCheck = true)
        {
            string tempNewFileName = newFileName;
            bool isDup = false;

            if (newFilePath.Substring(newFilePath.Length - 1, 1) == "\\")
            {
                newFilePath = newFilePath.Substring(0, newFilePath.Length - 1);
            }

            FileInfo di = new FileInfo(newFilePath + "\\" + tempNewFileName);

            if (isNeedToDupCheck == true)
            {
                if (di.Exists)
                {
                    isDup = true;
                    //이미 동일한 파일이 존재하는 경우
                    //newFileName = newFileName + DateTime.Now.ToString("HHmmss");

                    bool isTempNumExists = false;
                    int existTempNum = 0;
                    int existTempNumIndex = 0;
                    string[] splFileName = newFileName.Split('.');
                    if (splFileName.Count() == 2)
                    {
                        //newFileName = splFileName.ElementAt(0) + DateTime.Now.ToString("HHmmss") + "." + splFileName.ElementAt(1);

                        int startIndexNum = splFileName.ElementAt(0).LastIndexOf('(');
                        int endIndexNum = splFileName.ElementAt(0).LastIndexOf(')');
                        existTempNumIndex = startIndexNum;
                        if (startIndexNum >= 0 && endIndexNum >= 0)
                        {
                            //임시번호가 뒤에 붙어있음.
                            string tempNum = splFileName.ElementAt(0).Substring(startIndexNum, endIndexNum - startIndexNum + 1);
                            if (tempNum.Length >= 3)
                            {
                                if (tempNum[0].ToString() == "(" && tempNum[tempNum.Length - 1].ToString() == ")")
                                {
                                    string strNumber = tempNum.Substring(1, tempNum.Length - 2);
                                    if (strNumber.ToIntOrNull() != null)
                                    {
                                        int num = strNumber.ToInt();
                                        existTempNum = num;
                                        isTempNumExists = true;
                                    }
                                }
                            }
                        }
                    }

                    if (isTempNumExists == true && existTempNum > 0 && existTempNumIndex > 0)
                    {
                        tempNewFileName = splFileName.ElementAt(0).Substring(0, existTempNumIndex) + "(" + (existTempNum + 1).ToString() + ")" + "." + splFileName.ElementAt(1);
                    }
                    else
                    {
                        tempNewFileName = splFileName.ElementAt(0).ToString() + "(1)" + "." + splFileName.ElementAt(1);
                    }
                }
            }


            if (isDup == false)
            {
                return tempNewFileName;
            }
            else
            {
                return DupFileRenameCheck(newFilePath, tempNewFileName, isNeedToDupCheck);
            }
        }




        /// <summary>
        /// name         : DupFolderCheck
        /// desc         : 폴더명 중복체크
        /// author       : 심우종
        /// create date  : 2020-09-29
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public string DupFolderCheck(string newFolderPath, bool isNeedToDupCheck = true)
        {
            bool isDup = false;
            DirectoryInfo di = new DirectoryInfo(newFolderPath);

            if (isNeedToDupCheck == true)
            {
                if (di.Exists)
                {
                    isDup = true;
                    //이미 동일한 파일이 존재하는 경우
                    //newFileName = newFileName + DateTime.Now.ToString("HHmmss");

                    bool isTempNumExists = false;
                    int existTempNum = 0;
                    int existTempNumIndex = 0;


                    string folderName = di.Name;


                    if (!string.IsNullOrEmpty(folderName))
                    {
                        //newFileName = splFileName.ElementAt(0) + DateTime.Now.ToString("HHmmss") + "." + splFileName.ElementAt(1);

                        int startIndexNum = folderName.LastIndexOf('(');
                        int endIndexNum = folderName.LastIndexOf(')');
                        existTempNumIndex = startIndexNum;
                        if (startIndexNum >= 0 && endIndexNum >= 0)
                        {
                            //임시번호가 뒤에 붙어있음.
                            string tempNum = folderName.Substring(startIndexNum, endIndexNum - startIndexNum + 1);
                            if (tempNum.Length >= 3)
                            {
                                if (tempNum[0].ToString() == "(" && tempNum[tempNum.Length - 1].ToString() == ")")
                                {
                                    string strNumber = tempNum.Substring(1, tempNum.Length - 2);
                                    if (strNumber.ToIntOrNull() != null)
                                    {
                                        int num = strNumber.ToInt();
                                        existTempNum = num;
                                        isTempNumExists = true;
                                    }
                                }
                            }
                        }
                    }

                   

                    if (isTempNumExists == true && existTempNum > 0 && existTempNumIndex > 0)
                    {

                        newFolderPath = di.Parent.FullName + "\\" +  folderName.Substring(0, existTempNumIndex) + "(" + (existTempNum + 1).ToString() + ")";
                    }
                    else
                    {
                        newFolderPath = di.Parent.FullName + "\\" + folderName.ToString() + "(1)";
                    }
                }
            }


            if (isDup == false)
            {
                return newFolderPath;
            }
            else
            {
                return DupFolderCheck(newFolderPath, isNeedToDupCheck);
            }
        }




        /// <summary>
        /// name         : SedasRunProcess
        /// desc         : 프로그램을 실행한다.
        /// author       : 심우종
        /// create date  : 2020-10-14 13:47
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void SedasRunProcess(string runExe, string logId)
        {
            using (Process compiler = new Process())
            {
                string path = @"C:\SEDAS\SedasLauncher\SedasLauncher.exe";
                string param1 = runExe;
                string param2 = logId;
                FileInfo file = new FileInfo(path);

                compiler.StartInfo.FileName = path;
                string arg = string.Format("\"{0}\" {1}", runExe, logId);
                compiler.StartInfo.Arguments = arg;
                //compiler.StartInfo.Arguments = "\"" + jsonValue + "\"" ;
                compiler.StartInfo.UseShellExecute = true;

                compiler.StartInfo.WorkingDirectory = file.DirectoryName;
                compiler.Start();
            }
        }

    }
}
