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

namespace Sedas.UserControl
{
    public partial class UserSearchPopup : DevExpress.XtraEditors.XtraForm
    {

        CallService callService = new CallService();
        public UserSearchPopup()
        {
            InitializeComponent();
        }


        /// <summary>
        /// name         : UserSearchPopup_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-08-19 15:38
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void UserSearchPopup_Load(object sender, EventArgs e)
        {
            this.InitControl();
        }


        /// <summary>
        /// name         : InitControl
        /// desc         : 컨트롤 초기화
        /// author       : 심우종
        /// create date  : 2020-08-19 15:38
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitControl()
        {
            KeyValueData searchCode1 = new KeyValueData();
            searchCode1.Add("02", "사용자ID");
            searchCode1.Add("03", "사용자명");
            DataTable commonCode1 = KeyValueToDataTable(searchCode1);
            this.cmbSearchType.DataBindingFromDataTable(commonCode1, "key", "value");
            this.cmbSearchType.SedasSelectedValue = "03";
            this.txtSearch.ImeMode = System.Windows.Forms.ImeMode.Hangul;

            this.grdUserInfo.DataSource = new DataTable();

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


        /// <summary>
        /// name         : btnSearch_Click
        /// desc         : 조회버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-19 15:41
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.Search();
        }


        /// <summary>
        /// name         : Search
        /// desc         : 검색버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-19 16:21
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void Search()
        {
            //바인딩된 데이터 초기화
            DataTable dataSource = this.grdUserInfo.DataSource as DataTable;
            if (dataSource != null)
            {
                dataSource.Clear();
            }


            string cond1 = cmbSearchType.SedasSelectedValue;
            string cond2 = this.txtSearch.Text;

            if (string.IsNullOrEmpty(cond2))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("검색어를 입력하세요.");
                this.txtSearch.Focus();
                return;
            }

            if (cond2.Length < 2)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("검색어를 2자 이상 입력하세요.");
                this.txtSearch.Focus();
                return;
            }

            KeyValueData param = new KeyValueData();
            param.Add("Data1", cond1);
            param.Add("Data2", cond2);
            CallResultData result = this.callService.SelectSql("reqGetCoreUserInfo", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;

                if (dt != null && dt.Rows.Count > 0)
                {
                    this.grdUserInfo.DataSource = dt;
                }
            }
            else
            {
                //실패에 대한 처리
            }
        }


        /// <summary>
        /// name         : cmbSearchType_SelectedIndexChanged
        /// desc         : 검색 조건 콤보박스 변경시
        /// author       : 심우종
        /// create date  : 2020-08-19 16:18
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void cmbSearchType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbSearchType.SedasSelectedValue == "02") //직원ID검색
            {
                this.txtSearch.ImeMode = ImeMode.Alpha;
            }
            else //직원명 검색
            {
                this.txtSearch.ImeMode = ImeMode.Hangul;
            }
        }

        private void txtSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.Search();
            }
        }


        /// <summary>
        /// name         : btnClose_Click
        /// desc         : 취소버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-19 16:24
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }


        /// <summary>
        /// name         : btnConfirm_Click
        /// desc         : 확인 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-19 16:25
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            DataTable dt = this.grdUserInfo.DataSource as DataTable;
            if (dt == null || dt.Rows.Count == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            int[] selectedIndex =  grvUserInfo.GetSelectedRows();

            if (selectedIndex == null || selectedIndex.Count() == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("선택된 데이터가 없습니다.");
                return;
            }

            List<DataRow> selectedRows = new List<DataRow>();

            foreach (int index in selectedIndex)
            {
                DataRow row = dt.Rows[index];

                if (row != null)
                {
                    selectedRows.Add(row);
                }
            }

            this.SelectedDt = selectedRows.CopyToDataTable();

            this.Close();
        }

        DataTable selectedDt;

        public DataTable SelectedDt
        {
            get
            {
                return selectedDt;
            }

            set
            {
                selectedDt = value;
            }
        }


        /// <summary>
        /// name         : grvUserInfo_DoubleClick
        /// desc         : 그리드 더블클릭시
        /// author       : 심우종
        /// create date  : 2020-08-19 17:24
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void grvUserInfo_DoubleClick(object sender, EventArgs e)
        {
            DataRow row = this.grvUserInfo.GetFocusedDataRow();
            if (row != null)
            {
                List<DataRow> selectedRows = new List<DataRow>();
                selectedRows.Add(row);
                this.SelectedDt = selectedRows.CopyToDataTable();

                this.Close();
            }
        }
    }
}