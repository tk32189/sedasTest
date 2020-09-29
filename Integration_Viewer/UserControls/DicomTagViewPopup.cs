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

namespace Integration_Viewer
{
    public partial class DicomTagViewPopup : DevExpress.XtraEditors.XtraForm
    {
        public DicomTagViewPopup()
        {
            InitializeComponent();
        }

        DataTable receivedDt;
        public DicomTagViewPopup(DataTable dt)
        {
            InitializeComponent();
            this.receivedDt = dt;
        }


        /// <summary>
        /// name         : DicomTagViewPopup_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-07-17 14:28
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void DicomTagViewPopup_Load(object sender, EventArgs e)
        {
            
        }

        private void DicomTagViewPopup_Shown(object sender, EventArgs e)
        {
            if (this.receivedDt != null)
            {
                this.grdTagInfo.DataSource = this.receivedDt;
            }
        }
    }
}