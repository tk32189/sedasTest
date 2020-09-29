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
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.Utils;
using DevExpress.Utils.About;

namespace Sedas.UserControl
{
    public partial class SmsPopupForTotal : DevExpress.XtraEditors.XtraForm
    {

        DataTable dataSource; //데이터그리드에 바인딩된 데이터
        CallService callService = new CallService();
        CoreLibrary core = new CoreLibrary();



        public SmsPopupForTotal()
        {
            InitializeComponent();
        }


        /// <summary>
        /// name         : SmsPopupForTotal_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-08-19 10:07
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SmsPopupForTotal_Load(object sender, EventArgs e)
        {
            this.InitControl();
            this.ControlClear();

            //로그인 사용자정보 설정
            if (!string.IsNullOrEmpty(userId))
            {
                f_setSendInfoSetting(userId);
            }

        }

        string userId = ""; //로그인 설정후.. 적용필요함.


        private void f_setSendInfoSetting(string userId)
        {
            //TODO. 사용자 정보에서 ID, name, 진료과정보 조회필요

            //string m_Userid = TFGetSessionInfo("userid");
            //string m_Username = TFGetSessionInfo("username");

            //UltraHelper.SetControlValue(this.input9, m_Userid);
            //UltraHelper.SetControlValue(this.input10, m_Username);
            //txtSendNum.Text = ""); // 전화번호

            //string userdeptcd = TFGetSessionInfo("userdeptcd");

            //사용자 진료과....
            string userdeptcd = "";


            if (userdeptcd == "000086")
            {
                txtMessage.Text = "[총무팀] ";
                txtSendNum.Text = "02-2030-7125"; //총무팀전화번호
            }
            else if (userdeptcd == "000010")
            {
                txtMessage.Text = "[건국대학교병원] KIS시스템 장애 발생, 의료정보팀으로 복귀하십시오.";
                txtSendNum.Text = "02-2030-7031";
            }
            else if (userdeptcd == "000815")
            {
                txtMessage.Text = "[건국대학교병원] KIS시스템 장애 발생, 의료정보팀으로 복귀하십시오.";
                txtSendNum.Text = "02-2030-7031";
            }
            else if (userdeptcd == "000091")
            {
                txtMessage.Text = "[인사팀] ";
            }
            else if (userdeptcd == "000096")
            {
                txtMessage.Text = "[경리팀] ";
            }
            else if (userdeptcd == "000024")
            {
                txtMessage.Text = "[감염관리팀] ";
            }
            else if (userdeptcd == "000021")
            {
                txtMessage.Text = "[적정진료팀] ";
            }
            else if (userdeptcd == "000027")
            {
                txtMessage.Text = "[KRC팀] ";
            }
            else if (userdeptcd == "000006")
            {
                txtMessage.Text = "[전략기획팀] ";
            }
            else if (userdeptcd == "000033")
            {
                txtMessage.Text = "[교육연구팀] ";
            }
            else if (userdeptcd == "000018")
            {
                txtMessage.Text = "[홍보팀] ";
            }
            else if (userdeptcd == "000785")
            {
                txtMessage.Text = "[진료지원팀] ";
            }
            else if (userdeptcd == "000760")
            {
                txtMessage.Text = "[CPR교육실] ";
                txtSendName.Text = "KMS팀";
                txtSendNum.Text = "02-2030-5484";
            }
            else if (userdeptcd == "000042")
            {
                txtMessage.Text = "[교육행정팀] ";
                txtSendNum.Text = "02-2030-7313";
            }
            else if (userdeptcd == "000065")
            {
                txtSendNum.Text = "02-2030-7321"; // 병동간호1-041병동.
            }
            else if (userdeptcd == "000066")
            {
                txtSendNum.Text = "02-2030-7331"; // 병동간호1-051병동.
            }
            else if (userdeptcd == "000067")
            {
                txtSendNum.Text = "02-2030-7341"; // 병동간호1-052병동.
            }
            else if (userdeptcd == "000068")
            {
                txtSendNum.Text = "02-2030-7351"; // 병동간호1-061병동.
            }
            else if (userdeptcd == "000069")
            {
                txtSendNum.Text = "02-2030-7361"; // 병동간호1-062병동.
            }
            else if (userdeptcd == "000055")
            {
                txtSendNum.Text = "02-2030-7371"; // 병동간호1-071병동.
            }
            else if (userdeptcd == "000070")
            {
                txtSendNum.Text = "02-2030-7381"; // 병동간호1-072병동.
            }
            else if (userdeptcd == "000057")
            {
                txtSendNum.Text = "02-2030-7411"; // 병동간호1-082병동.
            }
            else if (userdeptcd == "000056")
            {
                txtSendNum.Text = "02-2030-7391"; // 병동간호2-081병동.
            }
            else if (userdeptcd == "000058")
            {
                txtSendNum.Text = "02-2030-7421"; // 병동간호2-091병동.
            }
            else if (userdeptcd == "000059")
            {
                txtSendNum.Text = "02-2030-7431"; // 병동간호2-092병동.
            }
            else if (userdeptcd == "000060")
            {
                txtSendNum.Text = "02-2030-7441"; // 병동간호2-101병동.
            }
            else if (userdeptcd == "000061")
            {
                txtSendNum.Text = "02-2030-7451"; // 병동간호2-102병동.
            }
            else if (userdeptcd == "000062")
            {
                txtSendNum.Text = "02-2030-7461"; // 병동간호2-111병동.
            }
            else if (userdeptcd == "000071")
            {
                txtSendNum.Text = "02-2030-7471"; // 병동간호2-112병동.
            }
            else if (userdeptcd == "000063")
            {
                txtSendNum.Text = "02-2030-8481"; // 병동간호2-VIP병동.
            }
            else if (userdeptcd == "000078")
            {
                txtSendNum.Text = "02-2030-6081"; // 중환자간호-분만실.
            }
            else if (userdeptcd == "000075")
            {
                txtSendNum.Text = "02-2030-6041"; // 중환자간호-MICU.
            }
            else if (userdeptcd == "000813")
            {
                txtSendNum.Text = "02-2030-6011"; // 중환자간호-SICU1.
            }
            else if (userdeptcd == "000074")
            {
                txtSendNum.Text = "02-2030-6012"; // 중환자간호-SICU2.
            }
            else if (userdeptcd == "000696")
            {
                txtSendNum.Text = "02-2030-6071"; // 중환자간호-NICU.
            }
            else if (userdeptcd == "000081")
            {
                txtSendNum.Text = "02-2030-5400"; // 수술간호-중앙수술실.
            }
            else if (userdeptcd == "000082")
            {
                txtSendNum.Text = "02-2030-5461"; // 수술간호-통원수술실.
            }
            else if (userdeptcd == "000083")
            {
                txtSendNum.Text = "02-2030-5431"; // 수술간호-마취/회복실.
            }
            else if (userdeptcd == "000523")
            {
                txtSendNum.Text = "02-2030-5552"; // 외래간호-응급의료센터.
            }
            else if (userdeptcd == "000051")
            {
                txtSendNum.Text = "02-2030-5800"; // 외래간호-투석실.
            }
            else if (userdeptcd == "000806")
            {
                txtSendNum.Text = "02-2030-6182"; // 외래간호-소화기센터내시경실.
            }
            else if (userdeptcd == "000040")
            {
                txtMessage.Text = "[간호부] ";
            }
            else // Default
            {
                txtSendNum.Text = "02-2030-0000";
            }
        }




        /// <summary>
        /// name         : ControlClear
        /// desc         : 컨트롤을 초기화한다.
        /// author       : 심우종
        /// create date  : 2020-08-19 14:08
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ControlClear()
        {
            this.cmbSearch1.SedasSelectedValue = "1"; 
            this.cmbSearch2.SedasSelectedValue = "0";

            this.txtMessage.Text = "";

            this.dataSource.Clear();
        }
            


        /// <summary>
        /// name         : InitControl
        /// desc         : 컨트롤 초기화
        /// author       : 심우종
        /// create date  : 2020-08-19 10:07
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitControl()
        {
            //직종 cboSearch1
            //직위 / 직급    cboSearch2
            //직명    cboSearch3

            //직종
            KeyValueData searchCode1 = new KeyValueData();
            searchCode1.Add("0", " ");
            searchCode1.Add("1", "전직원");
            searchCode1.Add("2", "의사직");
            searchCode1.Add("3", "간호직");
            searchCode1.Add("4", "일반직");
            DataTable commonCode1 = KeyValueToDataTable(searchCode1);
            this.cmbSearch1.DataBindingFromDataTable(commonCode1, "key", "value");

            //직위 / 직급
            KeyValueData searchCode2 = new KeyValueData();
            searchCode2.Add("0", " ");
            searchCode2.Add("1", "보직자");
            searchCode2.Add("2", "전문의이상");
            searchCode2.Add("3", "레지던트");
            searchCode2.Add("4", "인턴");
            searchCode2.Add("5", "간호사");
            searchCode2.Add("6", "일반직");
            searchCode2.Add("7", "의료원장");
            searchCode2.Add("8", "병원장");
            searchCode2.Add("9", "부원장");
            searchCode2.Add("10", "부장");
            searchCode2.Add("11", "실장");
            searchCode2.Add("12", "소장");
            searchCode2.Add("13", "과장");
            searchCode2.Add("14", "분과장");
            searchCode2.Add("15", "팀장");
            searchCode2.Add("16", "파트장");
            searchCode2.Add("17", "수간호사");
            searchCode2.Add("18", "QI보직자그룹");
            searchCode2.Add("19", "전산장애호출");
            searchCode2.Add("20", "의평-수신자");
            searchCode2.Add("21", "의평-간호직");
            DataTable commonCode2 = KeyValueToDataTable(searchCode2);
            this.cmbSearch2.DataBindingFromDataTable(commonCode2, "key", "value");

            //직명
            DataTable jobNameCoddDt = SelectJobNameMaster();
            if (jobNameCoddDt != null && jobNameCoddDt.Rows.Count > 0)
            {
                DataRow newRow = jobNameCoddDt.NewRow();
                newRow["bascode"] = "";
                newRow["bascdnm"] = "";
                jobNameCoddDt.Rows.InsertAt(newRow, 0);
                this.cmbSearch3.DataBindingFromDataTable(jobNameCoddDt, "bascode", "bascdnm");
            }


            //데이터 그리드
            DataTable dt = this.InitDataTable();
            this.dataSource = dt;
            this.grdSms.DataSource = dt;

        }


        /// <summary>
        /// name         : SelectJobNameMaster
        /// desc         : 직명 마스터 조회
        /// author       : 심우종
        /// create date  : 2020-08-20 09:55
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private DataTable SelectJobNameMaster()
        {
            KeyValueData param = new KeyValueData();
            //param.Add("Data1", "16797637");
            CallResultData result = this.callService.SelectSql("reqGetCoreUserJobName", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;
                return dt;
            }
            else
            {
                //실패에 대한 처리
            }

            return null;

        }




        /// <summary>
        /// name         : InitDataTable
        /// desc         : 데이터 테이블 초기화
        /// author       : 심우종
        /// create date  : 2020-08-17 09:07
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private DataTable InitDataTable()
        {
            DataTable dt = new DataTable();
            //dt.Columns.Add("recvname", typeof(string)); //이름
            //dt.Columns.Add("celtel", typeof(string)); //휴대전화번호
            //dt.Columns.Add("smsm", typeof(string)); //SMS메시지
            //dt.Columns.Add("msgByte", typeof(string)); //Byte
            //dt.Columns.Add("sendflag", typeof(string)); //전송

            dt.Columns.Add("jwcode", typeof(string)); //구분
            dt.Columns.Add("emplno", typeof(string)); //사원번호
            dt.Columns.Add("empknm", typeof(string)); //성명
            dt.Columns.Add("deptcd", typeof(string)); //소속부서
            dt.Columns.Add("deptgm", typeof(string)); //근무부서
            dt.Columns.Add("birthdaygb", typeof(string)); //양력음력
            dt.Columns.Add("birthday", typeof(string)); //생년월일
            dt.Columns.Add("receivetel", typeof(string)); //수신번호
            dt.Columns.Add("celnumber", typeof(string)); //휴대번호
            dt.Columns.Add("celtel", typeof(string)); //휴대전화번호
            dt.Columns.Add("hmetel", typeof(string)); //집전화번호
            dt.Columns.Add("jccod1", typeof(string)); //직책
            dt.Columns.Add("smsm", typeof(string)); //SMS Message
            dt.Columns.Add("msgbyte", typeof(string)); //Byte
            dt.Columns.Add("sendflag", typeof(string)); //전송

            return dt;
        }


        /// <summary>
        /// name         : KeyValueToDataTable
        /// desc         : KeyValueData => DataTable로 변환
        /// author       : 심우종
        /// create date  : 2020-08-19 10:30
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private DataTable KeyValueToDataTable(KeyValueData param)
        {
            DataTable dt = InitDataTableForCommonCode();
            if (param != null && param.Count > 0)
            {
                for (int i = 0; i < param.Count; i++)
                {
                    DataRow row = dt.NewRow();
                    row["key"] = param.ElementAt(i).Key;
                    row["value"] = param.ElementAt(i).Value;

                    dt.Rows.Add(row);
                }
            }

            return dt;

        }

        /// <summary>
        /// name         : InitDataTableForCommonCode
        /// desc         : 콤보박스 데이터를 위한 테이블 생성
        /// author       : 심우종
        /// create date  : 2020-08-19 10:23
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private DataTable InitDataTableForCommonCode()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("key");
            dt.Columns.Add("value");

            return dt;
        }

        Color borderColor = Color.FromArgb(36, 84, 136);

        private void tlpCenter_CellPaint(object sender, TableLayoutCellPaintEventArgs e)
        {
            var rectangle = e.CellBounds;
            //rectangle.X = 3;
            //rectangle.Width = rectangle.Width - 5;
            
            if (e.Row == 0)
            {
                if (e.Column == 0)
                {
                    ControlPaint.DrawBorder(e.Graphics, rectangle, borderColor, 1, ButtonBorderStyle.Solid
                                                              , borderColor, 1, ButtonBorderStyle.Solid
                                                              , borderColor, 1, ButtonBorderStyle.Solid
                                                              , borderColor, 1, ButtonBorderStyle.Solid);

                }
                else
                {
                    ControlPaint.DrawBorder(e.Graphics, rectangle, borderColor, 0, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid
                                                                  , borderColor, 1, ButtonBorderStyle.Solid);
                }
                
            }
            else
            {
                ControlPaint.DrawBorder(e.Graphics, rectangle, borderColor, 1, ButtonBorderStyle.Solid
                                                              , borderColor, 0, ButtonBorderStyle.Solid
                                                              , borderColor, 1, ButtonBorderStyle.Solid
                                                              , borderColor, 1, ButtonBorderStyle.Solid);
            }
        }


        /// <summary>
        /// name         : btnAdd_Click
        /// desc         : + 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-19 11:01
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnAdd_Click(object sender, EventArgs e)
        {
            AddRow();
        }

        /// <summary>
        /// name         : AddRow
        /// desc         : 그리드의 행을 추가한다.
        /// author       : 심우종
        /// create date  : 2020-08-17 09:29
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void AddRow()
        {
            if (this.dataSource == null) return;

            DataRow newRow = this.dataSource.NewRow();
            this.dataSource.Rows.Add(newRow);
        }

        /// <summary>
        /// name         : btnDelete_Click
        /// desc         : - 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-19 11:01
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            DeleteRow();
        }

        /// <summary>
        /// name         : DeleteRow
        /// desc         : 선택한 행을 삭제한다.
        /// author       : 심우종
        /// create date  : 2020-08-17 09:34
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void DeleteRow()
        {
            if (this.dataSource == null) return;

            DataRow row = this.grvSms.GetFocusedDataRow();
            if (row != null)
            {
                if (DevExpress.XtraEditors.XtraMessageBox.Show("선택하신 항목을 삭제할까요?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.No)
                {
                    return;
                }

                this.dataSource.Rows.Remove(row);
            }

            
        }


        /// <summary>
        /// name         : btnSearch_Click
        /// desc         : 조회버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-19 13:20
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchValue1 = this.cmbSearch1.SedasSelectedValue;
            string searchValue2 = this.cmbSearch2.SedasSelectedValue;
            string searchValue3 = this.cmbSearch3.SedasSelectedValue;

            if (string.IsNullOrEmpty(searchValue1))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("검색조건을 지정하여 주십시오.");
                this.cmbSearch1.Focus();
                return;
            }

            this.dataSource.Clear(); //초기화


            KeyValueData param = new KeyValueData();
            param.Add("Data1", searchValue1);
            param.Add("Data2", searchValue2);
            param.Add("Data3", searchValue3);
            CallResultData result = this.callService.SelectSql("reqGetCoreSmsUserInfo", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;

                if (dt != null && dt.Rows.Count > 0)
                {
                    core.TableCopy(dt, ref this.dataSource);
                }
            }
            else
            {
                //실패에 대한 처리
            }

        }


        /// <summary>
        /// name         : btnClear_Click
        /// desc         : 클리어 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-19 14:12
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnClear_Click(object sender, EventArgs e)
        {
            this.ControlClear();
        }


        /// <summary>
        /// name         : btnSetMessage_Click
        /// desc         : 메시지 적용 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-19 14:19
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSetMessage_Click(object sender, EventArgs e)
        {
            string message =  this.txtMessage.Text;

            if (this.dataSource == null || this.dataSource.Rows.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("조회된 대상이 없습니다.");
                return;
            }

            int Length = GetByte(message);

            if (Length > 80)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("전송할 SMS 메세지가 80Byte 이상의 한도를 초과하였습니다");
                return;
            }

            foreach (DataRow row in this.dataSource.Rows)
            {
                row["smsm"] = message;
                row["msgbyte"] = Length.ToString();
            }
        }


        /// <summary>
        /// name         : GetByte
        /// desc         : 스트링의 바이트값 리턴
        /// author       : 심우종
        /// create date  : 2020-08-17 10:24
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public int GetByte(string strData)
        {
            int iCnt = 0;
            for (int i = 0; i < strData.Length; i++)
            {
                byte[] bTmp = new byte[2];
                bTmp = System.Text.Encoding.Default.GetBytes(strData.Substring(i, 1));

                if (bTmp.GetUpperBound(0) < 1)
                {
                    iCnt++;
                    continue;
                }

                if (bTmp[0] > 128)
                {
                    iCnt += 2;
                }
            }
            return iCnt;
        }

        //private void grvSms_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        //{
        //    if (e.Column != null && e.Column.FieldName == "smsm")
        //    {
        //        DataRow row = grvSms.GetDataRow(e.RowHandle);
        //        if (row != null)
        //        {
        //            row["msgByte"] = GetByte(row["smsm"].ToString()).ToString();
        //        }
        //    }
        //}

        private void grvSms_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "smsm")
            {
                DataRow row = grvSms.GetDataRow(e.RowHandle);
                if (row != null)
                {
                    row["msgByte"] = GetByte(e.Value.ToString()).ToString();
                    row.EndEdit();
                }
            }
        }


        

        private void repositoryItemMemoEdit1_DoubleClick(object sender, EventArgs e)
        {
            DataRow dr = grvSms.GetFocusedDataRow();

            if (dr != null)
            {
                UserSearchPopup userSearchPopup = new UserSearchPopup();
                userSearchPopup.ShowDialog();

                if (userSearchPopup.SelectedDt != null)
                {
                    DataTable selectedDt = userSearchPopup.SelectedDt;
                    if (selectedDt.Rows.Count > 0)
                    {
                        DataRow row = selectedDt.Rows[0];
                        dr["emplno"] = row["userid"].ToString();
                        dr["empknm"] = row["username"].ToString();
                        dr["deptgm"] = row["deptnm"].ToString();
                        dr["celtel"] = row["emplceltel"].ToString().Replace("-", "");

                        // *표로 된 전화번호 세팅
                        string m_celNumber = row["emplceltel"].ToString();
                        string m_HideCelNumber = "";
                        if (m_celNumber.Length == 13)
                        {
                            m_HideCelNumber = m_celNumber.Substring(0, 10) + "***";
                        }
                        else if (m_celNumber.Length == 12)
                        {
                            m_HideCelNumber = m_celNumber.Substring(0, 9) + "***";
                        }
                        else
                        {
                            m_HideCelNumber = "";
                        }
                        dr["celnumber"] = m_HideCelNumber;
                        grvSms.UpdateCurrentRow();
                    }
                }
            }
        }


        /// <summary>
        /// name         : btnSave_Click
        /// desc         : 저장버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-20 13:59
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSave_Click(object sender, EventArgs e)
        {

            int count_success = 0;
            int count_fail = 0;
            int count_total = 0;


            if (this.dataSource != null && this.dataSource.Rows.Count > 0)
            {
                string sendNum = txtSendNum.Text.ToString();
                string sendName = txtSendName.Text.ToString();
                if (string.IsNullOrEmpty(sendNum))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("발신번호를 입력해주세요");
                    return;
                }

                if (string.IsNullOrEmpty(sendName))
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("발신자명을 입력해주세요");
                    return;
                }


                for (int i = 0; i < this.dataSource.Rows.Count; i++)
                {
                    DataRow row = this.dataSource.Rows[i];

                    string emplno = row["emplno"].ToString();
                    string celtel = row["celtel"].ToString().Replace("-", "");
                    string empknm = row["empknm"].ToString();
                    //전화번호 확인
                    if (celtel.ToIntOrNull() == null || celtel.Length < 10)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("전송대상자 [{0}({1})] 의 연락번호를 확인해주세요", empknm, emplno));
                        return;
                    }
                    string smsm = row["smsm"].ToString();

                    int countByte = this.GetByte(smsm);

                    if (countByte > 80)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("전송대상자 [({0})] 에게 전송할 SMS 메세지가 80Byte 이상의 한도를 초과하였습니다.", celtel));
                        return;
                    }

                    if (string.IsNullOrEmpty(smsm))
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("전송대상자  [{0}({1})] 에게 전송할 SMS 메세지가 없습니다.", empknm, emplno));
                        return;
                    }
                }

                if (DevExpress.XtraEditors.XtraMessageBox.Show("SMS 전송을 하시겠습니까?", "확인", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.No)
                {
                    return;
                }

                for (int i = 0; i < this.dataSource.Rows.Count; i++)
                {
                    DataRow row = this.dataSource.Rows[i];

                    string userId = this.userId;

                    string m_Kornm = row["empknm"].ToString();
                    string receiverNumber = row["celtel"].ToString().Replace("-", "");
                    //string receiverNumber = "010-6742-7275";
                    string senderName = sendName;
                    string senderNumber = sendNum;
                    //string messageId = "sms.com.001";
                    string messageParams = row["smsm"].ToString();

                    KeyValueData param = new KeyValueData();
                    param.Add("Data1", senderName); //senderName
                    param.Add("Data2", senderNumber); //senderNumber
                    param.Add("Data3", m_Kornm); //receiverName
                    param.Add("Data4", receiverNumber); //receiverNumber
                    param.Add("Data5", messageParams); //msg
                    param.Add("Data6", userId); //userid

                    CallResultData result = this.callService.SelectSql("reqInsCoreSmsSend", param);

                    bool isSuccess = false;
                    if (result.resultState == ResultState.OK)
                    {



                        //데이터 조회 성공
                        DataTable dt = result.resultData;
                        if (dt != null && dt.Rows.Count > 0 && dt.Columns.Contains("resultValue"))
                        {
                            string resultValue = dt.Rows[0]["resultValue"].ToString();
                            if (resultValue.ToIntOrNull() != null && resultValue.ToInt() > 0)
                            {
                                //성공
                                isSuccess = true;

                                LogHelper logHelper = new LogHelper();
                                string logParam = string.Format("senderName : {0} / senderNumber : {1} / receiverName : {2} / receiverNumber : {3} / userId : {4} /", senderName, senderNumber, m_Kornm, receiverNumber, SessionInfo.userId);
                                logHelper.WriteLog("SmsPopup_SendSMSForTotal", LogType.INFO, ActionType.CALL_DB, "SMS전송", "SMS전송완료", paramInfo: logParam);

                            }
                        }
                    }
                    else
                    {
                        //실패에 대한 처리
                    }

                    if (isSuccess == true)
                    {
                        row["sendflag"] = "성공";
                        count_success++;
                    }
                    else
                    {
                        row["sendflag"] = "실패";
                        count_fail++;
                    }

                    count_total++;
                }

                string strMsg = string.Format("SMS 메세지 전송: 총 {0}건 중 성공 {1}건, 실패 {2}건", count_total, count_success, count_fail);
                DevExpress.XtraEditors.XtraMessageBox.Show(strMsg);


            }
        }
    }
}