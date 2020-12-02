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

namespace Sedas.UserControl
{
    public partial class ClosingPwCheckPopup : DevExpress.XtraEditors.XtraForm
    {

        string resultValue = "";

        public ClosingPwCheckPopup()
        {
            InitializeComponent();
        }

        public string ResultValue
        {
            get
            {
                return resultValue;
            }

            set
            {
                resultValue = value;
            }
        }


        /// <summary>
        /// name         : txtPw_KeyDown
        /// desc         : 키다운 이벤트
        /// author       : 심우종
        /// create date  : 2020-11-16 09:48
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void txtPw_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                this.ResultValue = txtPw.Text;
                this.Close();
            }
        }


        /// <summary>
        /// name         : btnConfirm_Click
        /// desc         : 확인버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-11-16 09:50
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnConfirm_Click(object sender, EventArgs e)
        {
            this.ResultValue = txtPw.Text;
            this.Close();
        }


        /// <summary>
        /// name         : btnCancel_Click
        /// desc         : 취소버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-11-16 09:50
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.ResultValue = "";
            this.Close();
        }
    }
}