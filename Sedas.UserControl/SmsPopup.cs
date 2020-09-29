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
using DevExpress.XtraBars;
using Sedas.Core;
using Sedas.DB;

namespace Sedas.UserControl
{
    public partial class SmsPopup : DevExpress.XtraEditors.XtraForm
    {
        DataTable dataSource; //데이터그리드에 바인딩된 데이터
        CallService callService = new CallService();

        public SmsPopup()
        {
            InitializeComponent();
        }







        /// <summary>
        /// name         : SmsPopup_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-08-17 09:06
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SmsPopup_Load(object sender, EventArgs e)
        {
            DataTable dt = this.InitDataTable();
            this.dataSource = dt;
            this.grdSms.DataSource = dt;

            this.InitContextMenu();
        }


        /// <summary>
        /// name         : InitContextMenu
        /// desc         : Context메뉴 초기화
        /// author       : 심우종
        /// create date  : 2020-08-17 09:53
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitContextMenu()
        {
            //1. 이미지 영역용 contextMenu
            DevExpress.XtraBars.PopupMenu menu = new DevExpress.XtraBars.PopupMenu();
            menu.Name = "menu_image";
            menu.Manager = barManager1;
            BarButtonItem itemCopy = new BarButtonItem(barManager1, "행추가", 0);
            itemCopy.AccessibleName = "itemAdd";
            itemCopy.Hint = "itemAdd";
            BarButtonItem itemDelete = new BarButtonItem(barManager1, "행삭제", 1);
            itemDelete.AccessibleName = "itemDelete";
            itemDelete.Hint = "itemDelete";


            menu.AddItems(new BarItem[] { itemCopy, itemDelete });
            //menu.ItemLinks.Add(itemPrint).BeginGroup = true;
            //menu.AddItems(new BarItem[] { itemEdit });
            //menu.ItemLinks.Add(itemSendResult).BeginGroup = true;
            barManager1.ItemClick += BarManager1_ItemClick;
            //barManager1.QueryShowPopupMenu += BarManager1_QueryShowPopupMenu;
            barManager1.SetPopupContextMenu(this.grdSms, menu);
        }

        /// <summary>
        /// ContextMenu 클릭시
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BarManager1_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (e.Item == null || string.IsNullOrEmpty(e.Item.AccessibleName)) return;
            string name = e.Item.AccessibleName;

            //이미지 영역용 ContextMenu
            switch (name)
            {
                case "itemAdd": //행추가
                    this.AddRow();
                    break;
                case "itemDelete": //행삭제
                    this.DeleteRow();
                    break;
            }

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
            dt.Columns.Add("recvname", typeof(string)); //이름
            dt.Columns.Add("celtel", typeof(string)); //휴대전화번호
            dt.Columns.Add("smsm", typeof(string)); //SMS메시지
            dt.Columns.Add("msgByte", typeof(string)); //Byte
            dt.Columns.Add("sendflag", typeof(string)); //전송

            return dt;
        }


        /// <summary>
        /// name         : btnAddRow_Click
        /// desc         : 행추가 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-17 09:05
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnAddRow_Click(object sender, EventArgs e)
        {
            AddRow();
        }


        /// <summary>
        /// name         : btnAddDelete_Click
        /// desc         : 행삭제 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-17 09:31
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnAddDelete_Click(object sender, EventArgs e)
        {
            DeleteRow();
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
        /// name         : btnClear_Click
        /// desc         : 정리버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-17 09:48
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnClear_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// name         : btnSendSms_Click
        /// desc         : SMS 전송 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-17 09:50
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSendSms_Click(object sender, EventArgs e)
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

                    string celtel = row["celtel"].ToString().Replace("-", "");
                    //전화번호 확인
                    if (celtel.ToIntOrNull() == null || celtel.Length < 10)
                    {
                        DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("전송대상자 [({0})] 의 연락번호를 확인해주세요", celtel));
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
                        DevExpress.XtraEditors.XtraMessageBox.Show(string.Format("전송대상자  [({0})] 에게 전송할 SMS 메세지가 없습니다.", celtel));
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

                    string userId = "00000012";

                    string receiverName = row["recvname"].ToString();
                    string receiverNumber = row["celtel"].ToString().Replace("-", "");
                    string senderName = sendName;
                    string senderNumber = sendNum;
                    //string messageId = "sms.com.001";
                    string messageParams = row["smsm"].ToString();

                    KeyValueData param = new KeyValueData();
                    param.Add("Data1", senderName); //senderName
                    param.Add("Data2", senderNumber); //senderNumber
                    param.Add("Data3", receiverName); //receiverName
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
                                string logParam = string.Format("senderName : {0} / senderNumber : {1} / receiverName : {2} / receiverNumber : {3} / userId : {4} /", senderName, senderNumber, receiverName, receiverNumber, SessionInfo.userId);
                                logHelper.WriteLog("SmsPopup_SendSMS", LogType.INFO, ActionType.CALL_DB, "SMS전송", "SMS전송완료", paramInfo: logParam);

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

            //recvname 이름
            //celtel 휴대전화번호
            //smsm SMS메시지
            //msgByte Byte
            //sendflag 전송
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

        private void grvSms_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column != null && e.Column.FieldName == "smsm")
            {
                DataRow row = grvSms.GetDataRow(e.RowHandle);
                if (row != null)
                {
                    row["msgByte"] = GetByte(row["smsm"].ToString()).ToString();
                }
            }
        }

        private void repositoryItemMemoEdit1_EditValueChanging(object sender, DevExpress.XtraEditors.Controls.ChangingEventArgs e)
        {
            DataRow row = grvSms.GetFocusedDataRow();
            if (row != null && e.NewValue != null)
            {
                row["msgByte"] = GetByte(e.NewValue.ToString()).ToString();
                row.EndEdit();
            }
        }
    }
}