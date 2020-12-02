namespace Sedas.UserControl
{
    partial class ClosingPwCheckPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClosingPwCheckPopup));
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hFlowLayoutPanel1 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.btnConfirm = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.btnCancel = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.txtPw = new Sedas.Control.HTextEdit(this.components);
            this.hLabelControl1 = new Sedas.Control.HLabelControl(this.components);
            this.tlpMain.SuspendLayout();
            this.hFlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPw.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.hFlowLayoutPanel1, 0, 2);
            this.tlpMain.Controls.Add(this.txtPw, 0, 1);
            this.tlpMain.Controls.Add(this.hLabelControl1, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 27.77778F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 44.44444F));
            this.tlpMain.Size = new System.Drawing.Size(196, 124);
            this.tlpMain.TabIndex = 0;
            // 
            // hFlowLayoutPanel1
            // 
            this.hFlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hFlowLayoutPanel1.AutoSize = true;
            this.hFlowLayoutPanel1.Controls.Add(this.btnConfirm);
            this.hFlowLayoutPanel1.Controls.Add(this.btnCancel);
            this.hFlowLayoutPanel1.Location = new System.Drawing.Point(17, 81);
            this.hFlowLayoutPanel1.Name = "hFlowLayoutPanel1";
            this.hFlowLayoutPanel1.Size = new System.Drawing.Size(162, 29);
            this.hFlowLayoutPanel1.TabIndex = 0;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Appearance.Options.UseForeColor = true;
            this.btnConfirm.Location = new System.Drawing.Point(3, 3);
            this.btnConfirm.LookAndFeel.SkinName = "My Basic";
            this.btnConfirm.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnConfirm.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "확인";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.Location = new System.Drawing.Point(84, 3);
            this.btnCancel.LookAndFeel.SkinName = "My Basic";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnCancel.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "취소";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txtPw
            // 
            this.txtPw.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtPw.Location = new System.Drawing.Point(23, 43);
            this.txtPw.Name = "txtPw";
            this.txtPw.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtPw.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtPw.Properties.Appearance.Options.UseBackColor = true;
            this.txtPw.Properties.Appearance.Options.UseForeColor = true;
            this.txtPw.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtPw.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtPw.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPw.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtPw.SedasForeColor = null;
            this.txtPw.Size = new System.Drawing.Size(150, 16);
            this.txtPw.TabIndex = 1;
            this.txtPw.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPw_KeyDown);
            // 
            // hLabelControl1
            // 
            this.hLabelControl1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.hLabelControl1.Location = new System.Drawing.Point(51, 19);
            this.hLabelControl1.Name = "hLabelControl1";
            this.hLabelControl1.Size = new System.Drawing.Size(94, 12);
            this.hLabelControl1.TabIndex = 2;
            this.hLabelControl1.Text = "PW를 입력하세요";
            // 
            // ClosingPwCheckPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(196, 124);
            this.ControlBox = false;
            this.Controls.Add(this.tlpMain);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("ClosingPwCheckPopup.IconOptions.Icon")));
            this.Name = "ClosingPwCheckPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "확인";
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.hFlowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPw.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Control.HTableLayoutPanel tlpMain;
        private Control.HFlowLayoutPanel hFlowLayoutPanel1;
        private Control.HSedasSImpleButtonBlue btnConfirm;
        private Control.HSedasSImpleButtonBlue btnCancel;
        private Control.HTextEdit txtPw;
        private Control.HLabelControl hLabelControl1;
    }
}