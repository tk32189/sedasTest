namespace FileManagement
{
    partial class MainForm2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm2));
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.tlpClient = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hTableLayoutPanel1 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hLabelControl2 = new Sedas.Control.HLabelControl(this.components);
            this.progressCtrl = new DevExpress.XtraEditors.ProgressBarControl();
            this.txtBigDataInfo = new Sedas.Control.HLabelControl(this.components);
            this.tlpServer = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hTableLayoutPanel2 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hLabelControl1 = new Sedas.Control.HLabelControl(this.components);
            this.hTableLayoutPanel3 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.txtPort = new Sedas.Control.HTextEdit(this.components);
            this.hLabelControl4 = new Sedas.Control.HLabelControl(this.components);
            this.hLabelControl3 = new Sedas.Control.HLabelControl(this.components);
            this.txtIp = new Sedas.Control.HTextEdit(this.components);
            this.btnConnect = new Sedas.Control.HSimpleButton();
            this.flwpnlButton = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.btnUpLoad = new Sedas.Control.HSedasSImpleButtonPurple(this.components);
            this.btnDownLoad = new Sedas.Control.HSedasSImpleButtonPurple(this.components);
            this.tlpMain.SuspendLayout();
            this.tlpClient.SuspendLayout();
            this.hTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressCtrl.Properties)).BeginInit();
            this.tlpServer.SuspendLayout();
            this.hTableLayoutPanel2.SuspendLayout();
            this.hTableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIp.Properties)).BeginInit();
            this.flwpnlButton.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(21)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.tlpClient, 0, 2);
            this.tlpMain.Controls.Add(this.tlpServer, 0, 0);
            this.tlpMain.Controls.Add(this.flwpnlButton, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 43F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.Size = new System.Drawing.Size(990, 858);
            this.tlpMain.TabIndex = 0;
            this.tlpMain.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tlpMain_CellPaint);
            // 
            // tlpClient
            // 
            this.tlpClient.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.tlpClient.ColumnCount = 1;
            this.tlpClient.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClient.Controls.Add(this.hTableLayoutPanel1, 0, 0);
            this.tlpClient.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpClient.Location = new System.Drawing.Point(3, 453);
            this.tlpClient.Name = "tlpClient";
            this.tlpClient.RowCount = 2;
            this.tlpClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpClient.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpClient.Size = new System.Drawing.Size(984, 402);
            this.tlpClient.TabIndex = 2;
            // 
            // hTableLayoutPanel1
            // 
            this.hTableLayoutPanel1.ColumnCount = 4;
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 8F));
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.hTableLayoutPanel1.Controls.Add(this.hLabelControl2, 0, 0);
            this.hTableLayoutPanel1.Controls.Add(this.progressCtrl, 1, 0);
            this.hTableLayoutPanel1.Controls.Add(this.txtBigDataInfo, 2, 0);
            this.hTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.hTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.hTableLayoutPanel1.Name = "hTableLayoutPanel1";
            this.hTableLayoutPanel1.RowCount = 1;
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.Size = new System.Drawing.Size(984, 30);
            this.hTableLayoutPanel1.TabIndex = 2;
            // 
            // hLabelControl2
            // 
            this.hLabelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hLabelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hLabelControl2.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(157)))), ((int)(((byte)(216)))));
            this.hLabelControl2.Appearance.Options.UseFont = true;
            this.hLabelControl2.Appearance.Options.UseForeColor = true;
            this.hLabelControl2.Location = new System.Drawing.Point(10, 3);
            this.hLabelControl2.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.hLabelControl2.Name = "hLabelControl2";
            this.hLabelControl2.Size = new System.Drawing.Size(32, 25);
            this.hLabelControl2.TabIndex = 1;
            this.hLabelControl2.Text = "로컬";
            // 
            // progressCtrl
            // 
            this.progressCtrl.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.progressCtrl.Location = new System.Drawing.Point(65, 7);
            this.progressCtrl.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.progressCtrl.Name = "progressCtrl";
            this.progressCtrl.Properties.Step = 1;
            this.progressCtrl.Size = new System.Drawing.Size(275, 15);
            this.progressCtrl.TabIndex = 2;
            // 
            // txtBigDataInfo
            // 
            this.txtBigDataInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtBigDataInfo.Appearance.ForeColor = System.Drawing.Color.White;
            this.txtBigDataInfo.Appearance.Options.UseForeColor = true;
            this.txtBigDataInfo.Location = new System.Drawing.Point(346, 9);
            this.txtBigDataInfo.Name = "txtBigDataInfo";
            this.txtBigDataInfo.Size = new System.Drawing.Size(0, 12);
            this.txtBigDataInfo.TabIndex = 3;
            // 
            // tlpServer
            // 
            this.tlpServer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.tlpServer.ColumnCount = 1;
            this.tlpServer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpServer.Controls.Add(this.hTableLayoutPanel2, 0, 0);
            this.tlpServer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpServer.Location = new System.Drawing.Point(3, 3);
            this.tlpServer.Name = "tlpServer";
            this.tlpServer.RowCount = 2;
            this.tlpServer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpServer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpServer.Size = new System.Drawing.Size(984, 401);
            this.tlpServer.TabIndex = 1;
            this.tlpServer.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tlpServer_CellPaint);
            // 
            // hTableLayoutPanel2
            // 
            this.hTableLayoutPanel2.ColumnCount = 2;
            this.hTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hTableLayoutPanel2.Controls.Add(this.hLabelControl1, 0, 0);
            this.hTableLayoutPanel2.Controls.Add(this.hTableLayoutPanel3, 1, 0);
            this.hTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.hTableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.hTableLayoutPanel2.Name = "hTableLayoutPanel2";
            this.hTableLayoutPanel2.RowCount = 1;
            this.hTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.hTableLayoutPanel2.Size = new System.Drawing.Size(984, 30);
            this.hTableLayoutPanel2.TabIndex = 1;
            // 
            // hLabelControl1
            // 
            this.hLabelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hLabelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hLabelControl1.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(53)))), ((int)(((byte)(157)))), ((int)(((byte)(216)))));
            this.hLabelControl1.Appearance.Options.UseFont = true;
            this.hLabelControl1.Appearance.Options.UseForeColor = true;
            this.hLabelControl1.Location = new System.Drawing.Point(10, 3);
            this.hLabelControl1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.hLabelControl1.Name = "hLabelControl1";
            this.hLabelControl1.Size = new System.Drawing.Size(32, 25);
            this.hLabelControl1.TabIndex = 0;
            this.hLabelControl1.Text = "서버";
            // 
            // hTableLayoutPanel3
            // 
            this.hTableLayoutPanel3.ColumnCount = 5;
            this.hTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.hTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.hTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.hTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.hTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel3.Controls.Add(this.txtPort, 3, 0);
            this.hTableLayoutPanel3.Controls.Add(this.hLabelControl4, 2, 0);
            this.hTableLayoutPanel3.Controls.Add(this.hLabelControl3, 0, 0);
            this.hTableLayoutPanel3.Controls.Add(this.txtIp, 1, 0);
            this.hTableLayoutPanel3.Controls.Add(this.btnConnect, 4, 0);
            this.hTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel3.Location = new System.Drawing.Point(495, 3);
            this.hTableLayoutPanel3.Name = "hTableLayoutPanel3";
            this.hTableLayoutPanel3.RowCount = 1;
            this.hTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel3.Size = new System.Drawing.Size(486, 24);
            this.hTableLayoutPanel3.TabIndex = 1;
            // 
            // txtPort
            // 
            this.txtPort.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtPort.Location = new System.Drawing.Point(189, 4);
            this.txtPort.Name = "txtPort";
            this.txtPort.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtPort.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtPort.Properties.Appearance.Options.UseBackColor = true;
            this.txtPort.Properties.Appearance.Options.UseForeColor = true;
            this.txtPort.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtPort.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtPort.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPort.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtPort.Size = new System.Drawing.Size(55, 16);
            this.txtPort.TabIndex = 3;
            // 
            // hLabelControl4
            // 
            this.hLabelControl4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hLabelControl4.Appearance.ForeColor = System.Drawing.Color.White;
            this.hLabelControl4.Appearance.Options.UseForeColor = true;
            this.hLabelControl4.Location = new System.Drawing.Point(138, 6);
            this.hLabelControl4.Name = "hLabelControl4";
            this.hLabelControl4.Size = new System.Drawing.Size(45, 12);
            this.hLabelControl4.TabIndex = 2;
            this.hLabelControl4.Text = "PORT : ";
            // 
            // hLabelControl3
            // 
            this.hLabelControl3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hLabelControl3.Appearance.ForeColor = System.Drawing.Color.White;
            this.hLabelControl3.Appearance.Options.UseForeColor = true;
            this.hLabelControl3.Location = new System.Drawing.Point(3, 6);
            this.hLabelControl3.Name = "hLabelControl3";
            this.hLabelControl3.Size = new System.Drawing.Size(23, 12);
            this.hLabelControl3.TabIndex = 0;
            this.hLabelControl3.Text = "IP : ";
            // 
            // txtIp
            // 
            this.txtIp.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtIp.Location = new System.Drawing.Point(32, 4);
            this.txtIp.Name = "txtIp";
            this.txtIp.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtIp.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtIp.Properties.Appearance.Options.UseBackColor = true;
            this.txtIp.Properties.Appearance.Options.UseForeColor = true;
            this.txtIp.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtIp.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtIp.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtIp.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtIp.Size = new System.Drawing.Size(100, 16);
            this.txtIp.TabIndex = 1;
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(250, 3);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnConnect.Size = new System.Drawing.Size(75, 18);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "연결";
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // flwpnlButton
            // 
            this.flwpnlButton.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.flwpnlButton.AutoSize = true;
            this.flwpnlButton.Controls.Add(this.btnUpLoad);
            this.flwpnlButton.Controls.Add(this.btnDownLoad);
            this.flwpnlButton.Location = new System.Drawing.Point(380, 410);
            this.flwpnlButton.Name = "flwpnlButton";
            this.flwpnlButton.Size = new System.Drawing.Size(229, 36);
            this.flwpnlButton.TabIndex = 3;
            // 
            // btnUpLoad
            // 
            this.btnUpLoad.Appearance.Font = new System.Drawing.Font("Noto Sans KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUpLoad.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnUpLoad.Appearance.Options.UseFont = true;
            this.btnUpLoad.Appearance.Options.UseForeColor = true;
            this.btnUpLoad.Location = new System.Drawing.Point(3, 3);
            this.btnUpLoad.LookAndFeel.SkinName = "My Basic";
            this.btnUpLoad.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUpLoad.Name = "btnUpLoad";
            this.btnUpLoad.SedasButtonType = Sedas.Control.HSedasSImpleButtonPurple.HSimpleButtonType.Null;
            this.btnUpLoad.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnUpLoad.Size = new System.Drawing.Size(100, 30);
            this.btnUpLoad.TabIndex = 2;
            this.btnUpLoad.Text = "▲ 업로드";
            this.btnUpLoad.Click += new System.EventHandler(this.btnUpLoad_Click);
            // 
            // btnDownLoad
            // 
            this.btnDownLoad.Appearance.Font = new System.Drawing.Font("Noto Sans KR Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDownLoad.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDownLoad.Appearance.Options.UseFont = true;
            this.btnDownLoad.Appearance.Options.UseForeColor = true;
            this.btnDownLoad.Location = new System.Drawing.Point(126, 3);
            this.btnDownLoad.LookAndFeel.SkinName = "My Basic";
            this.btnDownLoad.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDownLoad.Margin = new System.Windows.Forms.Padding(20, 3, 3, 3);
            this.btnDownLoad.Name = "btnDownLoad";
            this.btnDownLoad.SedasButtonType = Sedas.Control.HSedasSImpleButtonPurple.HSimpleButtonType.Null;
            this.btnDownLoad.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnDownLoad.Size = new System.Drawing.Size(100, 30);
            this.btnDownLoad.TabIndex = 3;
            this.btnDownLoad.Text = "▼ 다운로드";
            this.btnDownLoad.Click += new System.EventHandler(this.btnDownLoad_Click);
            // 
            // MainForm2
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(990, 858);
            this.Controls.Add(this.tlpMain);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("MainForm2.IconOptions.Image")));
            this.Name = "MainForm2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "파일 관리";
            this.Load += new System.EventHandler(this.MainForm2_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpClient.ResumeLayout(false);
            this.hTableLayoutPanel1.ResumeLayout(false);
            this.hTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressCtrl.Properties)).EndInit();
            this.tlpServer.ResumeLayout(false);
            this.hTableLayoutPanel2.ResumeLayout(false);
            this.hTableLayoutPanel2.PerformLayout();
            this.hTableLayoutPanel3.ResumeLayout(false);
            this.hTableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPort.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtIp.Properties)).EndInit();
            this.flwpnlButton.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private Sedas.Control.HTableLayoutPanel tlpServer;
        private Sedas.Control.HLabelControl hLabelControl1;
        private Sedas.Control.HTableLayoutPanel tlpClient;
        private Sedas.Control.HLabelControl hLabelControl2;
        private Sedas.Control.HFlowLayoutPanel flwpnlButton;
        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel1;
        private DevExpress.XtraEditors.ProgressBarControl progressCtrl;
        private Sedas.Control.HLabelControl txtBigDataInfo;
        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel2;
        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel3;
        private Sedas.Control.HTextEdit txtPort;
        private Sedas.Control.HLabelControl hLabelControl4;
        private Sedas.Control.HLabelControl hLabelControl3;
        private Sedas.Control.HTextEdit txtIp;
        private Sedas.Control.HSimpleButton btnConnect;
        private Sedas.Control.HSedasSImpleButtonPurple btnUpLoad;
        private Sedas.Control.HSedasSImpleButtonPurple btnDownLoad;
    }
}