namespace SedasLauncher
{
    partial class FileDownLoadProgressPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FileDownLoadProgressPopup));
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hTableLayoutPanel1 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.lblTitle = new Sedas.Control.HLabelControl(this.components);
            this.lblMessage = new Sedas.Control.HLabelControl(this.components);
            this.hTableLayoutPanel2 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.lblPercent = new Sedas.Control.HLabelControl(this.components);
            this.progressBarControl1 = new DevExpress.XtraEditors.ProgressBarControl();
            this.tlpMain.SuspendLayout();
            this.hTableLayoutPanel1.SuspendLayout();
            this.hTableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.hTableLayoutPanel1, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 216F));
            this.tlpMain.Size = new System.Drawing.Size(362, 216);
            this.tlpMain.TabIndex = 0;
            // 
            // hTableLayoutPanel1
            // 
            this.hTableLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.hTableLayoutPanel1.ColumnCount = 1;
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.Controls.Add(this.lblTitle, 0, 0);
            this.hTableLayoutPanel1.Controls.Add(this.lblMessage, 0, 1);
            this.hTableLayoutPanel1.Controls.Add(this.hTableLayoutPanel2, 0, 2);
            this.hTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel1.Location = new System.Drawing.Point(5, 4);
            this.hTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.hTableLayoutPanel1.Name = "hTableLayoutPanel1";
            this.hTableLayoutPanel1.RowCount = 3;
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.hTableLayoutPanel1.Size = new System.Drawing.Size(352, 208);
            this.hTableLayoutPanel1.TabIndex = 2;
            // 
            // lblTitle
            // 
            this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblTitle.Appearance.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblTitle.Appearance.Options.UseFont = true;
            this.lblTitle.Location = new System.Drawing.Point(3, 26);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(48, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "타이틀";
            // 
            // lblMessage
            // 
            this.lblMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblMessage.Appearance.Options.UseTextOptions = true;
            this.lblMessage.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.lblMessage.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.lblMessage.Location = new System.Drawing.Point(3, 123);
            this.lblMessage.Name = "lblMessage";
            this.lblMessage.Size = new System.Drawing.Size(346, 12);
            this.lblMessage.TabIndex = 2;
            this.lblMessage.Text = "메시지";
            // 
            // hTableLayoutPanel2
            // 
            this.hTableLayoutPanel2.ColumnCount = 2;
            this.hTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.hTableLayoutPanel2.Controls.Add(this.lblPercent, 1, 0);
            this.hTableLayoutPanel2.Controls.Add(this.progressBarControl1, 0, 0);
            this.hTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel2.Location = new System.Drawing.Point(3, 141);
            this.hTableLayoutPanel2.Name = "hTableLayoutPanel2";
            this.hTableLayoutPanel2.RowCount = 1;
            this.hTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 64F));
            this.hTableLayoutPanel2.Size = new System.Drawing.Size(346, 64);
            this.hTableLayoutPanel2.TabIndex = 3;
            // 
            // lblPercent
            // 
            this.lblPercent.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPercent.Location = new System.Drawing.Point(279, 26);
            this.lblPercent.Name = "lblPercent";
            this.lblPercent.Size = new System.Drawing.Size(28, 12);
            this.lblPercent.TabIndex = 3;
            this.lblPercent.Text = "100%";
            // 
            // progressBarControl1
            // 
            this.progressBarControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progressBarControl1.Location = new System.Drawing.Point(10, 23);
            this.progressBarControl1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.progressBarControl1.Name = "progressBarControl1";
            this.progressBarControl1.Size = new System.Drawing.Size(263, 18);
            this.progressBarControl1.TabIndex = 1;
            // 
            // FileDownLoadProgressPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(362, 216);
            this.Controls.Add(this.tlpMain);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FileDownLoadProgressPopup.IconOptions.Image")));
            this.Name = "FileDownLoadProgressPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SedasLauncher";
            this.Shown += new System.EventHandler(this.FileDownLoadProgressPopup_Shown);
            this.tlpMain.ResumeLayout(false);
            this.hTableLayoutPanel1.ResumeLayout(false);
            this.hTableLayoutPanel1.PerformLayout();
            this.hTableLayoutPanel2.ResumeLayout(false);
            this.hTableLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressBarControl1.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private Sedas.Control.HLabelControl lblMessage;
        private DevExpress.XtraEditors.ProgressBarControl progressBarControl1;
        private Sedas.Control.HLabelControl lblTitle;
        private Sedas.Control.HLabelControl lblPercent;
        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel1;
        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel2;
    }
}