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

namespace Integration_Viewer
{
    public partial class RecordViewer : DevExpress.XtraEditors.XtraUserControl
    {
        public RecordViewer()
        {
            InitializeComponent();
        }


        /// <summary>
        /// name         : SetRecord
        /// desc         : 결과조회 정보 표시
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void SetRecord(string recordResult)
        {
            this.memoRecord.Text = "";

            this.memoRecord.Text = recordResult;
        }
    }
}
