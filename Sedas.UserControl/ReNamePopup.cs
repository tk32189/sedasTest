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
    public partial class ReNamePopup : DevExpress.XtraEditors.XtraForm
    {
        public ReNamePopup()
        {
            InitializeComponent();
        }

        private string resultValue = "";
        private string resultStat = "N";

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

        public string ResultStat
        {
            get
            {
                return resultStat;
            }

            set
            {
                resultStat = value;
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Confirm();
        }

        private void Confirm()
        {
            if (string.IsNullOrEmpty(txtName.Text))
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("파일이름을 입력해 주세요");
                return;
            }


            this.ResultValue = txtName.Text;
            this.ResultStat = "Y";

            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Confirm();
            }
        }
    }
}