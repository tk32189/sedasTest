using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Sedas.Core;
using Sedas.DB;

namespace DGS_Viewer
{
    public partial class ChangeNumPopup : DevExpress.XtraEditors.XtraForm
    {
        //CallService callService = new CallService("10.10.221.72", "8180");
        CallService callService = new CallService("10.10.221.72", "8180");
        CoreLibrary coreLibrary = new CoreLibrary();
        DataTable targetInfo = null;
        BlobClass blob;


        public int m_bExist = -1;

        //새로 변경될 데이터
        public string ptoNo = "";
        public string studyId = "";
        public string ptNo = "";
        public string ptNm = "";
        public string gi = "";
        public string mi = "";
        public string oi = "";


        public ChangeNumPopup()
        {
            InitializeComponent();
        }


        /// <summary>
        /// name         : ChangeNumPopup_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-04-29 15:52
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ChangeNumPopup_Load(object sender, EventArgs e)
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



            this.blob = new BlobClass(this.callService);

            //병리번호 콤보박스 데이터
            DataTable dt = new DataTable();
            dt.Columns.Add("cdVal");
            dt.Columns.Add("cdValNm");

            if (g_ComboData.strCharCount.ToIntOrNull() != null)
            {
                for (int i = 0; i < g_ComboData.strCharCount.ToInt(); i++)
                {
                    if (g_ComboData.strarrayChar.Count > i)
                    {
                        DataRow row = dt.NewRow();
                        row["cdVal"] = g_ComboData.strarrayChar[i].ToString();
                        row["cdValNm"] = g_ComboData.strarrayChar[i].ToString();
                        dt.Rows.Add(row);
                    }
                }
            }

            //commonCode_pathologyType = dt;
            cmbChar.DataBindingFromDataTable(dt, "cdVal", "cdValNm");

            cmbChar.SedasSelectedValue = "S";

            //if (cmbChar.Properties.Items.Count > 0)
            //{
            //    cmbChar.SelectedIndex = 0;
            //}

            GetCharYearName();

            this.txtPtoNo.Focus();


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
        /// name         : GetCharYearName
        /// desc         : Year형태 구성
        /// author       : 심우종
        /// create date  : 2020-04-29 16:15
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void GetCharYearName()
        {
            DateTime currnetDt = DateTime.Now;

            if (g_OthersSetupData.nCipher == 0)
                txtYear.Text = currnetDt.Year.ToString();
            else
                txtYear.Text = (currnetDt.Year - 2000).ToString();
        }

        

        /// <summary>
        /// name         : btnSearch_Click
        /// desc         : 조회버튼(☞) 클릭시
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.targetInfo.Clear();
            string prefix = this.cmbChar.SedasSelectedText;
            
            string header = this.txtYear.Text.Trim();
            string tail = this.txtPtoNo.Text;

            string ptoNo = string.Format("{0}{1}{2}", prefix, header, tail);


            //m_bExist = (int)IsValidStudy(patho);
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
                        newRow["regno"] = row["regno"].ToString();
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

                        //DataTable dt = result.resultData;
                        this.studyId = "";
                        this.ptoNo = ptoNo;
                        this.ptNo = this.targetInfo.Rows[0]["ptNo"].ToString();
                        this.ptNm = this.targetInfo.Rows[0]["ptNm"].ToString();
                        this.gi = this.targetInfo.Rows[0]["gi"].ToString();
                        this.mi = this.targetInfo.Rows[0]["mi"].ToString();
                        this.oi = this.targetInfo.Rows[0]["oi"].ToString();
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


            this.txtPtNo.Text = this.ptNo;
            this.txtPtNm.Text = this.ptNm;


            //m_StudyTlb.Pathono = patho;
            //m_PatID = m_PatientTlb.PatID;
            //m_PatName = m_PatientTlb.PatName;
            //m_strPathologyTail.Format("%s", tail);
        }



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
                this.studyId = dt.Rows[0]["studyId"].ToString();
                this.ptoNo = ptoNo;
                this.ptNo = dt.Rows[0]["ptNo"].ToString();
                this.ptNm = dt.Rows[0]["ptNm"].ToString();
                this.gi = dt.Rows[0]["gi"].ToString();
                this.mi = dt.Rows[0]["mi"].ToString();
                this.oi = dt.Rows[0]["oi"].ToString();
                return true;
            }
            else
            {
                this.studyId = "";
                this.ptoNo = "";
                this.ptNo = "NOPID";
                this.ptNm = "NONAME";
                this.gi = "0";
                this.mi = "0";
                this.oi = "0";
                return false;
            }


        }

        private void btnKey_Click(object sender, EventArgs e)
        {
            if (sender is Sedas.Control.HSimpleButton)
            {
                Sedas.Control.HSimpleButton selectedButton = sender as Sedas.Control.HSimpleButton;

                if (selectedButton.Text == "B")
                {
                    if (txtPtoNo.Text.Length > 0)
                    {
                        txtPtoNo.Text = txtPtoNo.Text.Substring(0, txtPtoNo.Text.Length - 1);
                    }
                }
                else if (selectedButton.Text == "C")
                {
                    txtPtoNo.Text = "";
                }
                else
                {
                    if (txtPtoNo.Text.Length < 8)
                    {
                        txtPtoNo.Text = txtPtoNo.Text + selectedButton.Text;
                    }
                    
                }
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (m_bExist == 0)
            {
                if (targetInfo != null && targetInfo.Rows.Count > 0)
                {
                    //병리번호가 Study테이블에 없음. 신규로 추가필요함.
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
                
            }
            else if (m_bExist == 1)
            { 
                //PASS
            }
            else
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("병리번호 검사를 하세요(☞)");
                return;
            }

            this.DialogResult = DialogResult.OK;
        }
    }
}
