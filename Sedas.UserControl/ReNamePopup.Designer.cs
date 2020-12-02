namespace Sedas.UserControl
{
    partial class ReNamePopup
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReNamePopup));
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hLabelControl1 = new Sedas.Control.HLabelControl(this.components);
            this.txtName = new Sedas.Control.HTextEdit(this.components);
            this.flwpnlButtons = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.btnConfirm = new Sedas.Control.HSimpleButton();
            this.btnCancel = new Sedas.Control.HSimpleButton();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).BeginInit();
            this.flwpnlButtons.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.hLabelControl1, 0, 0);
            this.tlpMain.Controls.Add(this.txtName, 0, 1);
            this.tlpMain.Controls.Add(this.flwpnlButtons, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpMain.Size = new System.Drawing.Size(290, 75);
            this.tlpMain.TabIndex = 0;
            // 
            // hLabelControl1
            // 
            this.hLabelControl1.Location = new System.Drawing.Point(10, 4);
            this.hLabelControl1.Margin = new System.Windows.Forms.Padding(10, 4, 5, 4);
            this.hLabelControl1.Name = "hLabelControl1";
            this.hLabelControl1.Size = new System.Drawing.Size(156, 12);
            this.hLabelControl1.TabIndex = 0;
            this.hLabelControl1.Text = "변경할 이름을 입력해 주세요";
            // 
            // txtName
            // 
            this.txtName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtName.Location = new System.Drawing.Point(3, 23);
            this.txtName.Name = "txtName";
            this.txtName.SedasControlType = Sedas.Control.ControlType.Null;
            this.txtName.SedasForeColor = null;
            this.txtName.Size = new System.Drawing.Size(266, 18);
            this.txtName.TabIndex = 1;
            this.txtName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtName_KeyDown);
            // 
            // flwpnlButtons
            // 
            this.flwpnlButtons.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flwpnlButtons.AutoSize = true;
            this.flwpnlButtons.Controls.Add(this.btnConfirm);
            this.flwpnlButtons.Controls.Add(this.btnCancel);
            this.flwpnlButtons.Location = new System.Drawing.Point(64, 46);
            this.flwpnlButtons.Name = "flwpnlButtons";
            this.flwpnlButtons.Size = new System.Drawing.Size(162, 26);
            this.flwpnlButtons.TabIndex = 2;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(3, 3);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnConfirm.Size = new System.Drawing.Size(75, 20);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "확인";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(84, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnCancel.Size = new System.Drawing.Size(75, 20);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "취소";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ReNamePopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 75);
            this.Controls.Add(this.tlpMain);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("ReNamePopup.IconOptions.Icon")));
            this.Name = "ReNamePopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "이름변경";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtName.Properties)).EndInit();
            this.flwpnlButtons.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Control.HTableLayoutPanel tlpMain;
        private Control.HLabelControl hLabelControl1;
        private Control.HTextEdit txtName;
        private Control.HFlowLayoutPanel flwpnlButtons;
        private Control.HSimpleButton btnConfirm;
        private Control.HSimpleButton btnCancel;
    }
}