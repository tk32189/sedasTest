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
using Sedas.Core;
using Sedas.DB;

namespace DGS_Viewer
{
    public partial class ViewResultPopup : DevExpress.XtraEditors.XtraForm
    {
        CallService callService = new CallService("10.10.221.72", "8180");

        public ViewResultPopup()
        {
            InitializeComponent();
            this.InitControl(); //컨트롤 초기화
        }

        //string ptoNo = "";
        //string studyDt = "";
        string studyId = "";

        DataRow dbDataRow;


        /// <summary>
        /// name         : ViewResultPopup_Load
        /// desc         : 화면로드시
        /// author       : 심우종
        /// create date  : 2020-04-23 13:58
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ViewResultPopup_Load(object sender, EventArgs e)
        {
            if (g_DBconnectData.strIsDev == "Y")
            {
                this.callService = new CallService("10.10.221.71", "8180");
                this.Text = this.Text + "  (개발)";
            }
            else
            {
                this.callService = new CallService(g_DBconnectData.strCallService);
            }
        }


        /// <summary>
        /// name         : InitControl
        /// desc         : 컨트롤을 초기화한다.
        /// author       : 심우종
        /// create date  : 2020-04-23 13:58
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitControl()
        {
            //전송상태 콤보박스 데이터
            DataTable dt = new DataTable();
            dt.Columns.Add("cdVal");
            dt.Columns.Add("cdValNm");

            String[] statMaster = { "0", "8", "9", "1" };
            for (int i = 0; i < statMaster.Count(); i++)
            {
                if (g_ComboData.strarrayChar.Count > i)
                {
                    DataRow row = dt.NewRow();
                    row["cdVal"] = statMaster.ElementAt(i).ToString();
                    row["cdValNm"] = statMaster.ElementAt(i).ToString();
                    dt.Rows.Add(row);
                }
            }

            this.cmbSendState.DataBindingFromDataTable(dt, "cdVal", "cdValNm");
        }

        DataRow workData;
        string m_SourcePtNo = "";

        /// <summary>
        /// name         : InitData
        /// desc         : 데이터 초기화
        /// author       : 심우종
        /// create date  : 2020-04-23 09:22
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void InitData(DataRow row)
        {
            

            this.workData = row;
            this.studyId = row["studyId"].ToString();
            DataTable resultDt = this.GetInfo(row["studyId"].ToString());
            if (resultDt != null && resultDt.Rows.Count > 0)
            {
                this.txtPtNo.Text = this.m_SourcePtNo = resultDt.Rows[0]["ptNo"].ToString();
                this.txtPtNm.Text = resultDt.Rows[0]["ptNm"].ToString();
                this.txtEngNm.Text = resultDt.Rows[0]["engNm"].ToString();
                this.txtBirth.Text = resultDt.Rows[0]["birth"].ToString();
                this.txtAge.Text = resultDt.Rows[0]["age"].ToString();
                this.txtSex.Text = resultDt.Rows[0]["sex"].ToString();
                this.txtGi.Text = resultDt.Rows[0]["gi"].ToString();
                this.txtMi.Text = resultDt.Rows[0]["mi"].ToString();
                this.txtOi.Text = resultDt.Rows[0]["oi"].ToString();
                this.cmbSendState.SedasSelectedValue = resultDt.Rows[0]["sendStat"].ToString();
                this.lblPtoNo.Text = resultDt.Rows[0]["ptoNo"].ToString();
                this.txtStudyRslt.Text = resultDt.Rows[0]["studyRslt"].ToString();

                this.dbDataRow = resultDt.Rows[0];

                //this.ptoNo = resultDt.Rows[0]["ptoNo"].ToString();
                //this.studyDt = resultDt.Rows[0]["studyDt"].ToString();

            }


        }



        /// <summary>
        /// name         : GetInfo
        /// desc         : 정보를 조회한다.
        /// author       : 심우종
        /// create date  : 2020-04-23 13:47
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private DataTable GetInfo(string studyId)
        {
            KeyValueData param = new KeyValueData();
            param.Add("Data1", studyId);
            CallResultData result = this.callService.SelectSql("reqGetViewerViewResult", param);
            if (result.resultState == ResultState.OK && result.resultData != null && result.resultData.Rows.Count > 0)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;
                //string patNo = dt.Rows[0]["ptoNo"].ToString();

                return dt;
                


            }
            else
            {
                //실패에 대한 처리
                DevExpress.XtraEditors.XtraMessageBox.Show("UpdateDlg : Select StudyTlb fail");
            }

            return null;
        }


        /// <summary>
        /// name         : btnClose_Click
        /// desc         : 닫기버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-23 14:35
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// name         : btnSave_Click
        /// desc         : 저장버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-23 14:36
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (this.dbDataRow == null)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("데이터를 저장할수 없습니다.");
                return;
            }

            if (this.m_SourcePtNo != this.txtPtNo.Text)
            {
                bool isNeedToNewPtNo = false; //신규 환자번호 생성 필요여부
                //변경된 환자 번호가 있는지 확인하고.
                KeyValueData param = new KeyValueData();
                param.Add("Data1", this.txtPtNo.Text);
                CallResultData result = this.callService.SelectSql("reqGetViewerPtNoExist", param);
                if (result.resultState == ResultState.OK)
                {
                    //데이터 조회 성공
                    DataTable dt = result.resultData;

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        //기존에 환자가 존재함. PASS
                    }
                    else
                    {
                        if (DevExpress.XtraEditors.XtraMessageBox.Show("환자번호가 변경 되었습니다.\n\r\n\r변경된 환자정보를 추가 하시겠습니까?", "데이터 수정", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            isNeedToNewPtNo = true;
                        }
                    }
                }
                else
                {
                    //실패에 대한 처리
                    DevExpress.XtraEditors.XtraMessageBox.Show("DataUpdateDlg : Search Patient fail.");
                    return;
                }

                if (isNeedToNewPtNo == true)
                {
                    if (this.InsertPatInfo() == false)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show("DataUpdateDlg : Insert Patient fail.");
                        return;
                    }
                }

            }

            this.UpdateStudyInfo();
        }


        /// <summary>
        /// name         : UpdateStudyInfo
        /// desc         : 스터디 정보를 업데이트한다.
        /// author       : 심우종
        /// create date  : 2020-04-23 16:01
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void UpdateStudyInfo()
        {
            KeyValueData param = new KeyValueData();
            param.Add("Data1", this.txtPtNo.Text);
            param.Add("Data2", this.dbDataRow["ptoNo"].ToString());
            param.Add("Data3", this.dbDataRow["studyDt"].ToString());
            param.Add("Data4", this.dbDataRow["insertDt"].ToString());
            param.Add("Data5", this.dbDataRow["reqDr"].ToString());
            param.Add("Data6", this.dbDataRow["reqDrId"].ToString());
            param.Add("Data7", this.dbDataRow["resDr"].ToString());
            param.Add("Data8", this.dbDataRow["resDrId"].ToString());
            param.Add("Data9", this.dbDataRow["specimen"].ToString());
            param.Add("Data10", this.dbDataRow["specimenCd"].ToString());
            param.Add("Data11", this.dbDataRow["studyNm"].ToString());
            param.Add("Data12", this.dbDataRow["studyDesc"].ToString());
            param.Add("Data13", this.txtStudyRslt.Text);
            param.Add("Data14", this.txtGi.Text);
            param.Add("Data15", this.txtMi.Text);
            param.Add("Data16", this.txtOi.Text);
            param.Add("Data17", this.cmbSendState.SedasSelectedValue);
            param.Add("Data18", this.studyId);
            param.Add("Data19", SessionInfo.userId);

            CallResultData result = this.callService.SelectSqlToPost("reqSetViewerStudyData", param);
            if (result.resultState == ResultState.OK)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("저장하였습니다.");
            }
            else
            {
                //실패에 대한 처리
                DevExpress.XtraEditors.XtraMessageBox.Show("UpdateDlg : Update StudyTlb fail");
                return;
            }
        }

        /// <summary>
        /// name         : InsertPatInfo
        /// desc         : 환자정보를 insert한다.
        /// author       : 심우종
        /// create date  : 2020-04-23 15:29
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool InsertPatInfo()
        {

            KeyValueData param = new KeyValueData();
            param.Add("Data1", txtPtNo.Text);
            param.Add("Data2", txtPtNm.Text);
            param.Add("Data3", txtBirth.Text);
            param.Add("Data4", txtAge.Text);
            param.Add("Data5", txtSex.Text);
            param.Add("Data6", txtEngNm.Text);
            param.Add("Data7", SessionInfo.userId);

            CallResultData result = this.callService.SelectSql("reqInsViewerPatData", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                //DataTable dt = result.resultData;
                Global.logHelper.WriteLog("viewerInsertPatInfo", LogType.INFO, ActionType.CALL_DB, "Viewer환자정보 변경", "DB 저장 성공", studyId: studyId);
                return true;
            }
            else
            {
                Global.logHelper.WriteLog("viewerInsertPatInfo", LogType.ERROR, ActionType.CALL_DB, "Viewer환자정보 변경", "DB 저장 실패", studyId: studyId);
                //실패에 대한 처리
                return false;
            }


        }
    }
}