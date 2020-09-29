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
using Sedas.Core;
using Sedas.DB;
using System.IO;

namespace Integration_Viewer
{
    public partial class TabPage2 : DevExpress.XtraEditors.XtraUserControl
    {

        CallService callService = new CallService("10.10.221.72", "8180");
        CoreLibrary core = new CoreLibrary();
        FileTransfer ft = new FileTransfer();
        ImageInOutClass imageInOutClass;
        BlobClass blob;



        DataTable selectedFilesDt; //선택된 파일 리스트를 담고 있는 Datatable

        public TabPage2()
        {
            InitializeComponent();
        }


        Color buttonFocusColor = Color.FromArgb(253, 114, 105);
        Color whiteColor = Color.White;

        private void FlatButton_MouseLeave(object sender, EventArgs e)
        {
            Sedas.Control.HSimpleButton button = sender as Sedas.Control.HSimpleButton;
            button.Tag = "0";
            button.ForeColor = whiteColor;
            button.Refresh();
        }

        private void FlatButton_MouseEnter(object sender, EventArgs e)
        {
            Sedas.Control.HSimpleButton button = sender as Sedas.Control.HSimpleButton;
            button.Tag = "1";
            button.ForeColor = buttonFocusColor;
            button.Refresh();
        }

        private void FlatButton_Paint(object sender, PaintEventArgs e)
        {
            Sedas.Control.HSimpleButton button = sender as Sedas.Control.HSimpleButton;
            //button.AppearanceHovered.BackColor
            if (button.Tag != null && button.Tag.ToString() == "1")
            {
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, buttonFocusColor, 1, ButtonBorderStyle.Solid
                                                                           , buttonFocusColor, 1, ButtonBorderStyle.Solid
                                                                           , buttonFocusColor, 1, ButtonBorderStyle.Solid
                                                                           , buttonFocusColor, 1, ButtonBorderStyle.Solid);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, e.ClipRectangle, whiteColor, 1, ButtonBorderStyle.Solid
                                                                           , whiteColor, 1, ButtonBorderStyle.Solid
                                                                           , whiteColor, 1, ButtonBorderStyle.Solid
                                                                           , whiteColor, 1, ButtonBorderStyle.Solid);
            }


        }


        /// <summary>
        /// name         : btnPeriod_Click
        /// desc         : 기간별 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-02 17:20
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnPeriod_Click(object sender, EventArgs e)
        {
            if (sender is Sedas.Control.HSimpleButton)
            {
                Sedas.Control.HSimpleButton button = sender as Sedas.Control.HSimpleButton;
                string value = button.Text.ToString();

                int period = 0;
                if (!string.IsNullOrEmpty(value))
                {
                    if (value.Contains("Y"))
                    {
                        string num = value.Replace("Y", "");
                        if (num.ToIntOrNull() != null)
                        {
                            period = num.ToInt() * 365;
                        }
                    }
                    else if (value.Contains("M"))
                    {
                        string num = value.Replace("M", "");
                        if (num.ToIntOrNull() != null)
                        {
                            period = num.ToInt() * 30;
                        }
                    }
                    else if (value.Contains("W"))
                    {
                        string num = value.Replace("W", "");
                        if (num.ToIntOrNull() != null)
                        {
                            period = num.ToInt() * 7;
                        }
                    }
                    else if (value.Contains("D"))
                    {
                        string num = value.Replace("D", "");
                        if (num.ToIntOrNull() != null)
                        {
                            period = num.ToInt();
                        }
                    }
                    else if (value == "개원부터")
                    {

                    }
                }

                if (period > 0)
                {
                    DateTime current = DateTime.Now;

                    this.txtEndDt.DateTime = current;
                    this.txtStartDt.DateTime = current.AddDays(-period);
                }
            }
        }



        /// <summary>
        /// name         : btnSearch_Click
        /// desc         : 조회버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-03 10:26
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string ptoNo = this.txtPtoNo.Text;
            string ptNo = this.txtPtNo.Text;
            string startDt = this.txtStartDt.DateTime.ToString("yyyyMMdd");
            string endDt = this.txtEndDt.DateTime.ToString("yyyyMMdd") + "999999";

            KeyValueData param = new KeyValueData();
            if (!string.IsNullOrEmpty(ptoNo))
            {
                param.Add("Data1", ptoNo);
            }

            if (!string.IsNullOrEmpty(ptNo))
            {
                param.Add("Data2", ptNo);
            }

            if (!string.IsNullOrEmpty(startDt) && !string.IsNullOrEmpty(endDt))
            {
                param.Add("Data3", startDt);
                param.Add("Data4", endDt);
            }

            CallResultData result = this.callService.SelectSql("reqGetIntegViewerData", param);

            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;
                grdWorkList.DataSource = dt;
            }
            else
            {
                //실패에 대한 처리
            }
        }


        /// <summary>
        /// name         : TabPage2_Load
        /// desc         : 화면로드시
        /// author       : 심우종
        /// create date  : 2020-07-15 13:52
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void TabPage2_Load(object sender, EventArgs e)
        {
            this.blob = new BlobClass(this.callService);
            this.imageInOutClass = new ImageInOutClass(this.callService);
            InitControl();
        }


        SimpleFileList sfDicom;
        SimpleFileList sfImage;
        SimpleFileList sfWave;
        List<SimpleFileList> allSimpleFileList = new List<SimpleFileList>();

        /// <summary>
        /// name         : InitControl
        /// desc         : 컨트롤 초기화
        /// author       : 심우종
        /// create date  : 2020-07-15 13:52
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitControl()
        {
            //--------------------------------------------------
            //검색 컨트롤 초기화
            //--------------------------------------------------
            DateTime current = DateTime.Now;
            this.txtStartDt.DateTime = current;
            this.txtEndDt.DateTime = current;

            //--------------------------------------------------
            //파일 리스트 컨트롤 초기화
            //--------------------------------------------------
            if (this.sfDicom == null)
            {
                this.sfDicom = new SimpleFileList();
                this.sfDicom.onFileChecked += onFileChecked;
                this.tlpDicom.Controls.Add(this.sfDicom);
                this.sfDicom.Dock = DockStyle.Fill;
                this.sfDicom.Title = "Dicom";
                allSimpleFileList.Add(this.sfDicom);
            }

            if (this.sfImage == null)
            {
                this.sfImage = new SimpleFileList();
                this.sfImage.onFileChecked += onFileChecked;
                this.tlpImage.Controls.Add(this.sfImage);
                this.sfImage.Dock = DockStyle.Fill;
                this.sfImage.Title = "이미지";
                allSimpleFileList.Add(this.sfImage);
            }

            if (this.sfWave == null)
            {
                this.sfWave = new SimpleFileList();
                this.sfWave.onFileChecked += onFileChecked;
                this.tlpWave.Controls.Add(this.sfWave);
                this.sfWave.Dock = DockStyle.Fill;
                this.sfWave.Title = "음성파일";
                allSimpleFileList.Add(this.sfWave);
            }

            //--------------------------------------------------
            // 선택된 파일 GridControl
            //--------------------------------------------------
            if (selectedFilesDt == null)
            {
                this.selectedFilesDt = Global.InitFileDataTable();
                this.grdSelectedFiles.DataSource = this.selectedFilesDt;
            }

            //변경할 병리번호 정보를 담기위한 table 설정
            InitTargetInfoDataTable();
        }


        /// <summary>
        /// name         : InitTargetInfoDataTable
        /// desc         : 타겟 병리번호에 대한 정보를 담는 데이터테이블
        /// author       : 심우종
        /// create date  : 2020-08-06 10:01
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitTargetInfoDataTable()
        {
            this.targetInfo = new DataTable();
            this.targetInfo.Columns.Add("studyId", typeof(string));
            this.targetInfo.Columns.Add("gi", typeof(string));
            this.targetInfo.Columns.Add("mi", typeof(string));
            this.targetInfo.Columns.Add("oi", typeof(string));
            this.targetInfo.Columns.Add("ptNo", typeof(string));
            this.targetInfo.Columns.Add("ptNm", typeof(string));

            this.targetInfo.Columns.Add("kornm", typeof(string));
            this.targetInfo.Columns.Add("regno", typeof(string));
            this.targetInfo.Columns.Add("tknm", typeof(string));
            this.targetInfo.Columns.Add("tkdt", typeof(string));
            this.targetInfo.Columns.Add("ptoNo", typeof(string));

            this.targetInfo.Columns.Add("patbir", typeof(string));
            this.targetInfo.Columns.Add("patage", typeof(string));
            this.targetInfo.Columns.Add("patsex", typeof(string));


        }

        


        /// <summary>
        /// name         : onFileChecked
        /// desc         : 파일 체크 변경시
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void onFileChecked()
        {

            this.selectedFilesDt.Clear();//기존 데이터 삭제

            allSimpleFileList.ForEach(item =>
            {
                DataTable dt = item.GetDataTable();
                if (dt != null && dt.Rows.Count > 0)
                {
                    List<DataRow> checkedList = dt.AsEnumerable().Where(e => e["isChecked"].ToString() == "Y").ToList();
                    if (checkedList != null && checkedList.Count > 0)
                    {
                        for (int i = 0; i < checkedList.Count; i++)
                        {
                            DataRow row = checkedList[i];
                            DataRow newRow = this.selectedFilesDt.NewRow();

                            this.core.TableCopy(row, ref newRow);
                            this.selectedFilesDt.Rows.Add(newRow);
                        }

                    }
                }
            });
        }

        DataRow selectedRow;

        /// <summary>
        /// name         : grvWorkList_DoubleClick
        /// desc         : 워크리스트 더블클릭시
        /// author       : 심우종
        /// create date  : 2020-07-15 14:32
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void grvWorkList_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = grvWorkList.GetFocusedDataRow();

            if (row == null) return;

            this.selectedRow = row;

            this.SearchFile();

        }


        /// <summary>
        /// name         : SearchFile
        /// desc         : 워크리스트에서 선택된 studyId기준으로 파일 리스트를 조회한다.
        /// author       : 심우종
        /// create date  : 2020-07-16 15:41
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SearchFile()
        {
            this.AllFileListClear(); //전체 파일리스트 클리어
            KeyValueData param = new KeyValueData();
            param.Add("Data1", this.selectedRow["studyId"].ToString());
            CallResultData result = this.callService.SelectSql("reqGetIntegViewerChild", param);

            if (result.resultState == ResultState.OK)
            {
                DataTable dt = result.resultData;
                if (dt != null && dt.Rows.Count > 0)
                {

                    List<DataRow> imageList = dt.AsEnumerable().Where(o => o["type"].ToString() == "0" || o["type"].ToString() == "1" || o["type"].ToString() == "2").ToList();
                    if (imageList != null && imageList.Count > 0)
                    {
                        if (this.sfImage != null)
                        {
                            this.sfImage.AddFiles(imageList);
                        }
                    }

                    List<DataRow> dicomList = new List<DataRow>(); //다이콤은 구분값이 뭘까??

                    List<DataRow> waveList = dt.AsEnumerable().Where(o => o["type"].ToString() == "4").ToList();
                    if (waveList != null && waveList.Count > 0)
                    {
                        if (this.sfWave != null)
                        {
                            this.sfWave.AddFiles(waveList);
                        }
                    }


                }
            }
            else
            {

            }
        }


        /// <summary>
        /// name         : AllFileListClear
        /// desc         : 전체 파일리스트 클리어
        /// author       : 심우종
        /// create date  : 2020-07-15 14:56
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void AllFileListClear()
        {
            this.allSimpleFileList.ForEach(item => {
                item.DataClear();
            });

            this.selectedFilesDt.Clear();
        }

        private void tlpBottom_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var rectangle = e.CellBounds;
            //rectangle.X = 3;
            //rectangle.Width = rectangle.Width - 5;
            Color color = Global.panelColor;
            if (e.Row == 0)
            {
                ControlPaint.DrawBorder(e.Graphics, rectangle, color, 2, ButtonBorderStyle.Solid
                                                              , color, 2, ButtonBorderStyle.Solid
                                                              , color, 2, ButtonBorderStyle.Solid
                                                              , color, 2, ButtonBorderStyle.Solid);
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, rectangle, color, 2, ButtonBorderStyle.Solid
                                                              , color, 0, ButtonBorderStyle.Solid
                                                              , color, 2, ButtonBorderStyle.Solid
                                                              , color, 2, ButtonBorderStyle.Solid);
            }

        }


        int m_bExist = -1;

        /// <summary>
        /// name         : btnTargetSearch_Click
        /// desc         : 타겟 병리번호 검색
        /// author       : 심우종
        /// create date  : 2020-07-16 09:40
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnTargetSearch_Click(object sender, EventArgs e)
        {
            string ptoNo = txtTargetPtoNo.Text;

            if (string.IsNullOrEmpty(ptoNo))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("병리번호를 입력하세요");
                return;
            }

            this.ClearTargetInfo();
            this.m_bExist = -1;
            bool isExists = IsValidStudy(ptoNo);
            if (isExists == true)
            {
                this.m_bExist = 1;
            }

            if (isExists == false)
            {
                KeyValueData param = new KeyValueData();
                param.Add("Data1", ptoNo);
                CallResultData result = this.callService.SelectSql("reqGetCorePtoNoCheck", param);
                if (result.resultState == ResultState.OK)
                {
                    //데이터 조회 성공
                    DataTable dt = result.resultData;

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        DataRow row = dt.Rows[0];

                        DataRow newRow = this.targetInfo.NewRow();
                        newRow["studyId"] = "";
                        newRow["gi"] = "0";
                        newRow["mi"] = "0";
                        newRow["oi"] = "0";
                        newRow["ptNo"] = row["ptno"].ToString();
                        newRow["ptNm"] = row["kornm"].ToString();

                        newRow["kornm"] = row["kornm"].ToString();
                        newRow["regno"]  = row["regno"].ToString();
                        newRow["tknm"] = row["tknm"].ToString();
                        newRow["tkdt"] = row["tkdt"].ToString();
                        newRow["ptoNo"] = row["ptoNo"].ToString();

                        string regno = row["regno"].ToString();

                        if (!string.IsNullOrEmpty(regno) && regno.Length >= 8)
                        {
                            if (regno.Substring(7, 1) == "1" || regno.Substring(7, 1) == "2" || regno.Substring(7, 1) == "5" || regno.Substring(7, 1) == "6")
                            {
                                newRow["patbir"] = "19" + regno.Substring(0, 2) + "-" + regno.Substring(2, 2) + "-" + regno.Substring(4, 2);
                            }
                            else if (regno.Substring(7, 1) == "3" || regno.Substring(7, 1) == "4" || regno.Substring(7, 1) == "7" || regno.Substring(7, 1) == "8")
                            {
                                newRow["patbir"] = "20" + regno.Substring(0, 2) + "-" + regno.Substring(2, 2) + "-" + regno.Substring(4, 2);
                            }
                            else if (regno.Substring(7, 1) == "9" || regno.Substring(7, 1) == "0")
                            {
                                newRow["patbir"] = "18" + regno.Substring(0, 2) + "-" + regno.Substring(2, 2) + "-" + regno.Substring(4, 2);
                            }
                        }

                        newRow["patage"] = (DateTime.Now.Year - Convert.ToInt32(newRow["patbir"].ToString().Substring(0, 4)) + 1).ToString();

                        switch (regno.Substring(7, 1).ToString())
                        {
                            case "1":
                            case "3":
                            case "5":
                            case "7":
                            case "9":
                                //IIP_Main.pathology_data.PATSEX[count] = "M";
                                newRow["patsex"] = "M";
                                break;
                            case "0":
                            case "2":
                            case "4":
                            case "6":
                            case "8":
                                //IIP_Main.pathology_data.PATSEX[count] = "F";
                                newRow["patsex"] = "F";
                                break;
                        }

                        this.targetInfo.Rows.Add(newRow);
                        this.m_bExist = 0;
                        isExists = true;
                    }
                }
                else
                {
                    //실패에 대한 처리
                }


                //확인필요!!!!
                //GetPatientInfoFromPathologyNo(prefix, m_strPathologyHeader, tail);

                //확인결과에 따라서..this.m_bExist = 0; 이 될수도...
            }

            if (isExists == true)
            {
                if (this.targetInfo != null && this.targetInfo.Rows.Count > 0)
                {
                    DataRow row = this.targetInfo.Rows[0];
                    this.txtTargetPtNo.Text = row["ptNo"].ToString();
                    this.txtTargetPtNm.Text = row["ptNm"].ToString();


                    //파일 리스트 조회
                    this.SelectTargetFile(row["studyId"].ToString());
                }
            }


            
        }

        


        /// <summary>
        /// name         : SelectTargetFile
        /// desc         : 타겟 병리번호에 대한 파일정보 조회
        /// author       : 심우종
        /// create date  : 2020-07-17 09:39
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SelectTargetFile(string studyId)
        {
            if (string.IsNullOrEmpty(studyId))
            {
                this.grdTarget.DataSource = null;
                return;
            }

            KeyValueData param = new KeyValueData();
            param.Add("Data1", studyId);
            CallResultData result = this.callService.SelectSql("reqGetIntegViewerChild", param);

            if (result.resultState == ResultState.OK)
            {
                DataTable dt = result.resultData;
                if (dt != null && dt.Rows.Count > 0)
                {

                    if (dt.Columns.Contains("fileName") == false) 
                    {
                        dt.Columns.Add("fileName", typeof(string));
                    }

                    dt.AsEnumerable().ToList().ForEach(item => {
                        string filePath = item["filePath"].ToString();

                        string lastValue = filePath.Split('\\').LastOrDefault();
                        if (!string.IsNullOrEmpty(lastValue))
                        {
                            item["fileName"] = lastValue;
                        }
                    });

                    this.grdTarget.DataSource = dt;
                }
                else
                {
                    this.grdTarget.DataSource = null;
                }
            }
            else
            {
                this.grdTarget.DataSource = null;
            }
        }


        /// <summary>
        /// name         : ClearTargetInfo
        /// desc         : 타켓 정보를 클리어한다.
        /// author       : 심우종
        /// create date  : 2020-07-16 09:44
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ClearTargetInfo()
        {
            this.targetInfo.Clear();
            this.targetPtoNo = "";
            this.txtTargetPtNo.Text = "";
            this.txtTargetPtNm.Text = "";
        }

        DataTable targetInfo = null;
        string targetPtoNo = "";

        /// <summary>
        /// name         : IsValidStudy
        /// desc         : 해당 병리번호 존재여부 확인
        /// author       : 심우종
        /// create date  : 2020-05-06 08:43
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool IsValidStudy(string ptoNo)
        {
            KeyValueData param = new KeyValueData();
            param.Add("Data1", ptoNo);
            CallResultData result = this.callService.SelectSql("reqGetViewerPtoNoExist", param);
            bool isExists = false;
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;

                if (dt != null && dt.Rows.Count > 0)
                {
                    isExists = true;
                }
                else
                {
                    isExists = false;
                }
            }
            else
            {
                //실패에 대한 처리
                isExists = false;
            }

            if (isExists == true)
            {
                DataTable dt = result.resultData;

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.targetInfo.Clear();

                    core.TableCopy(dt, ref this.targetInfo);
                    //this.targetInfo = dt;


                    this.targetPtoNo = ptoNo;
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                
                return false;
            }


        }


        /// <summary>
        /// name         : btnFileMove_Click
        /// desc         : 파일이동 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-07-16 13:16
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnFileMove_Click(object sender, EventArgs e)
        {
            if (targetInfo == null || targetInfo.Rows.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("파일을 이동할 병리번호를 검색해 주세요");
                return;
            }

            

            if (this.selectedRow == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("worklist에서 병리번호를 선택해 주세요");
                return;
            }

            //grdSelectedFiles
            if (this.selectedFilesDt == null || selectedFilesDt.Rows.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("이동할 파일을 선택해 주세요");
                return;
            }

            if (this.selectedRow["ptoNo"].ToString() == targetPtoNo)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("동일한 병리번호 입니다.");
                return;
            }


            //병리번호가 Study테이블에 없음. 신규로 추가필요함.
            if (m_bExist == 0)
            {
                InsertStudyAndPatDTO insertStudyAndPatDTO = new InsertStudyAndPatDTO();
                insertStudyAndPatDTO.ptoNo = targetInfo.Rows[0]["ptoNo"].ToString();
                insertStudyAndPatDTO.insertDt = DateTime.Now.ToString("yyyyMMdd");
                insertStudyAndPatDTO.accessno = "";
                insertStudyAndPatDTO.studyDt = targetInfo.Rows[0]["tkdt"].ToString();
                insertStudyAndPatDTO.gi = "0";
                insertStudyAndPatDTO.mi = "0";
                insertStudyAndPatDTO.oi = "0";
                insertStudyAndPatDTO.sendStat = "0";
                string uId = blob.SearchNumber(targetInfo.Rows[0]["ptoNo"].ToString());
                insertStudyAndPatDTO.uId = uId;
                insertStudyAndPatDTO.studyNm = targetInfo.Rows[0]["tknm"].ToString();
                insertStudyAndPatDTO.ptNo = targetInfo.Rows[0]["ptNo"].ToString();
                insertStudyAndPatDTO.ptNm = targetInfo.Rows[0]["ptNm"].ToString();
                insertStudyAndPatDTO.birth = targetInfo.Rows[0]["patbir"].ToString();
                insertStudyAndPatDTO.age = targetInfo.Rows[0]["patage"].ToString();
                insertStudyAndPatDTO.sex = targetInfo.Rows[0]["patsex"].ToString();

                ImageInOutClass imageInOutClass = new ImageInOutClass(this.callService);
                if (imageInOutClass.InsertStudyAndPatData(insertStudyAndPatDTO) == true)
                {
                    //저장성공

                    bool isExists = IsValidStudy(targetInfo.Rows[0]["ptoNo"].ToString());

                    if (isExists == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("Study테이블 저장시 오류");
                        return;
                    }
                }
                else
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("Study테이블 저장시 오류");
                    return;
                }
            }

            string targetStudyId = targetInfo.Rows[0]["studyId"].ToString();
            if (string.IsNullOrEmpty(targetPtoNo) || string.IsNullOrEmpty(targetStudyId))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("변경할 병리번호를 찾을수 없습니다.");
                return;
            }


            KeyValueData param = new KeyValueData();
            param.Add("changedStudyId", this.targetInfo.Rows[0]["studyId"].ToString() );
            param.Add("changedPtoNo", this.targetPtoNo);
            param.Add("changedGI", this.targetInfo.Rows[0]["gi"].ToString());
            param.Add("changedMI", this.targetInfo.Rows[0]["mi"].ToString());
            param.Add("changedOI", this.targetInfo.Rows[0]["oi"].ToString());

            this.SaveImageData(changedPatNoParam: param);
        }







        /// <summary>
        /// name         : SaveImageData
        /// desc         : 이미지를 저장한다.
        /// author       : 심우종
        /// create date  : 2020-04-24 10:23
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool SaveImageData(KeyValueData changedPatNoParam = null)
        {
            bool isPtoNoChange = false; // 병리번호 변경으로 인한 처리여부

            string changedStudyId = "";
            string changedPtoNo = "";
            int changedGI = 0;
            int changedMI = 0;
            int changedOI = 0;
            if (changedPatNoParam != null)
            {
                isPtoNoChange = true;
                changedStudyId = changedPatNoParam["changedStudyId"].ToString();
                changedPtoNo = changedPatNoParam["changedPtoNo"].ToString();
                changedGI = changedPatNoParam["changedGI"].ToString().ToInt();
                changedMI = changedPatNoParam["changedMI"].ToString().ToInt();
                changedOI = changedPatNoParam["changedOI"].ToString().ToInt();

            }

            string studyId = selectedRow["studyId"].ToString();
            string ptoNo = selectedRow["ptoNo"].ToString();

            if (string.IsNullOrEmpty(studyId) || string.IsNullOrEmpty(ptoNo)) return false;


            DateTime current = DateTime.Now;
            string filePath = "imagedata\\";
            string tempPath = current.ToString("yyyy") + "\\";
            filePath = filePath + tempPath;

            tempPath = ptoNo + "\\";
            filePath = filePath + tempPath;

            //this.nGI = 0;
            //this.nMI = 0;
            //this.nOI = 0;

            //this.nChangedGI = changedGI;
            //this.nChangedMI = changedMI;
            //this.nChangedOI = changedOI;

            int currentImageIndex = 0;
            int changedImageIndex = changedGI + changedMI + changedOI;

            //변경된 filePath를 구하자..
            string changedFilePath = "imagedata\\";
            string changedTempPath = current.ToString("yyyy") + "\\";
            changedFilePath = changedFilePath + changedTempPath;

            changedTempPath = changedPtoNo + "\\";
            changedFilePath = changedFilePath + changedTempPath;

            StringBuilder errMessage = new StringBuilder();
            List<DeleteImageDTO> deleteImageList = new List<DeleteImageDTO>(); //삭제가 필요한 이미지 데이터


            if (selectedFilesDt.Rows.Count > 0)
            {
                for (int i = 0; i < selectedFilesDt.Rows.Count; i++)
                {
                    DataRow row = selectedFilesDt.Rows[i];


                    DirectoryInfo di = new DirectoryInfo(Global.tempFolderForFileMovePath);
                    if (di.Exists == false)
                    {
                        di.Create();
                    }

                    if (di.Exists == true)
                    {
                        //기존에 받은 임시파일은 삭제처리함.
                        FileInfo[] files = di.GetFiles();
                        if (files != null && files.Count() > 0)
                        {
                            foreach (FileInfo file in files)
                            {
                                file.Delete();
                            }
                        }
                    }

                    string savedFilePathAndName = "";
                    if (ft.FileDownLoad(row["filePath"].ToString(), di.FullName, ref savedFilePathAndName) == true)
                    {
                        //로컬에 파일 다운로드 성공
                        //[1] 새로운 병리번호로 이미지 copy
                        if (this.imageInOutClass.ImageInsert(savedFilePathAndName, changedImageIndex, changedPtoNo, changedStudyId, row["type"].ToString()) == false)
                        {
                            //이미지 저장 실패
                            errMessage.Append(row["filePath"].ToString() + "파일을 이동하는데 실패하였습니다.[파일 저장 실패]\r\n");
                            continue;
                        }
                      
                        changedImageIndex++;

                        //[2] 기존 이미지는 삭제처리
                        DeleteImageDTO deletefile = new DeleteImageDTO();
                        deletefile.StudyId = row["studyId"].ToString();
                        deletefile.PtoNo = selectedRow["ptoNo"].ToString();
                        deletefile.Seq = row["seq"].ToString();
                        deletefile.FilePath = row["rootPath"].ToString() +  row["filePath"].ToString();
                        deletefile.FileServerPath = row["filePath"].ToString();
                        deleteImageList.Add(deletefile);
                    }
                    else
                    {
                        errMessage.Append(row["filePath"].ToString() + "파일을 이동하는데 실패하였습니다.[파일 다운로드 실패]\r\n");
                        continue;
                    }

                    
                }
            }

            if (deleteImageList != null && deleteImageList.Count > 0)
            {
                if (this.imageInOutClass.DeleteImageFromDB(deleteImageList) == false)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("기존 이미지 정보 삭제 실패");
                    return false;
                }
            }


            //이미지 변경후 처리
            if (this.imageInOutClass.UpdateImageSaveAfter(studyId) == false)
            {
                return false;

            }

            if (this.imageInOutClass.UpdateImageSaveAfter(changedStudyId) == false)
            {
                return false;
            }


            //기존 이미지 삭제
            if (deleteImageList != null && deleteImageList.Count > 0)
            {
                for (int i = 0; i < deleteImageList.Count; i++)
                {
                    //파일 서버에 있는 기존 이미지는 삭제한다.
                    ft.DeleteFile(deleteImageList[i].FileServerPath);
                }
            }


            string message = string.Format("{0}개의 이미지가 {1}로 이동되었습니다.", (changedImageIndex - (changedGI + changedMI + changedOI)).ToString(), changedPtoNo);

            if (!string.IsNullOrEmpty(errMessage.ToString()))
            {
                message = message + Environment.NewLine + Environment.NewLine + errMessage.ToString();
            }

            DevExpress.XtraEditors.XtraMessageBox.Show(message);

            this.SearchFile();

            //타겟 파일 리스트 조회
            this.SelectTargetFile(this.targetInfo.Rows[0]["studyId"].ToString());
            return true;
        }
    }
}
