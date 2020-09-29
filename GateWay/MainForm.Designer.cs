namespace GateWay
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.tlpLeft = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hFlowLayoutPanel6 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.txtSyntaxValue = new Sedas.Control.HTextEdit(this.components);
            this.hFlowLayoutPanel5 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.txtSyntaxName = new Sedas.Control.HTextEdit(this.components);
            this.hFlowLayoutPanel3 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.hLabelControl3 = new Sedas.Control.HLabelControl(this.components);
            this.txtModality = new Sedas.Control.HTextEdit(this.components);
            this.hFlowLayoutPanel2 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.hLabelControl2 = new Sedas.Control.HLabelControl(this.components);
            this.txtInterval = new Sedas.Control.HTextEdit(this.components);
            this.hFlowLayoutPanel1 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.hLabelControl1 = new Sedas.Control.HLabelControl(this.components);
            this.txtState = new Sedas.Control.HTextEdit(this.components);
            this.hFlowLayoutPanel4 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.hLabelControl4 = new Sedas.Control.HLabelControl(this.components);
            this.hFlowLayoutPanel7 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.btnSetting = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.btnTest = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.btnStart = new Sedas.Control.HSedasSImpleButtonOrange(this.components);
            this.btnClose = new Sedas.Control.HSedasSImpleButtonGreen(this.components);
            this.tlpLog = new Sedas.Control.HTableLayoutPanel(this.components);
            this.memoLog = new Sedas.Control.HMemoEdit(this.components);
            this.tlpRight = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hTableLayoutPanel1 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.tlpMain.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.hFlowLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSyntaxValue.Properties)).BeginInit();
            this.hFlowLayoutPanel5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSyntaxName.Properties)).BeginInit();
            this.hFlowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModality.Properties)).BeginInit();
            this.hFlowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).BeginInit();
            this.hFlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtState.Properties)).BeginInit();
            this.hFlowLayoutPanel4.SuspendLayout();
            this.hFlowLayoutPanel7.SuspendLayout();
            this.tlpLog.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoLog.Properties)).BeginInit();
            this.tlpRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpMain.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpMain.Controls.Add(this.tlpLog, 0, 1);
            this.tlpMain.Controls.Add(this.tlpRight, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(657, 508);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpLeft
            // 
            this.tlpLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Controls.Add(this.hFlowLayoutPanel6, 0, 5);
            this.tlpLeft.Controls.Add(this.hFlowLayoutPanel5, 0, 4);
            this.tlpLeft.Controls.Add(this.hFlowLayoutPanel3, 0, 2);
            this.tlpLeft.Controls.Add(this.hFlowLayoutPanel2, 0, 1);
            this.tlpLeft.Controls.Add(this.hFlowLayoutPanel1, 0, 0);
            this.tlpLeft.Controls.Add(this.hFlowLayoutPanel4, 0, 3);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(3, 3);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 6;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpLeft.Size = new System.Drawing.Size(351, 194);
            this.tlpLeft.TabIndex = 0;
            // 
            // hFlowLayoutPanel6
            // 
            this.hFlowLayoutPanel6.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hFlowLayoutPanel6.AutoSize = true;
            this.hFlowLayoutPanel6.Controls.Add(this.txtSyntaxValue);
            this.hFlowLayoutPanel6.Location = new System.Drawing.Point(52, 167);
            this.hFlowLayoutPanel6.Name = "hFlowLayoutPanel6";
            this.hFlowLayoutPanel6.Size = new System.Drawing.Size(246, 22);
            this.hFlowLayoutPanel6.TabIndex = 5;
            // 
            // txtSyntaxValue
            // 
            this.txtSyntaxValue.Location = new System.Drawing.Point(3, 3);
            this.txtSyntaxValue.Name = "txtSyntaxValue";
            this.txtSyntaxValue.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtSyntaxValue.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtSyntaxValue.Properties.Appearance.Options.UseBackColor = true;
            this.txtSyntaxValue.Properties.Appearance.Options.UseForeColor = true;
            this.txtSyntaxValue.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtSyntaxValue.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtSyntaxValue.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSyntaxValue.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtSyntaxValue.Size = new System.Drawing.Size(240, 16);
            this.txtSyntaxValue.TabIndex = 0;
            // 
            // hFlowLayoutPanel5
            // 
            this.hFlowLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hFlowLayoutPanel5.AutoSize = true;
            this.hFlowLayoutPanel5.Controls.Add(this.txtSyntaxName);
            this.hFlowLayoutPanel5.Location = new System.Drawing.Point(52, 136);
            this.hFlowLayoutPanel5.Name = "hFlowLayoutPanel5";
            this.hFlowLayoutPanel5.Size = new System.Drawing.Size(246, 22);
            this.hFlowLayoutPanel5.TabIndex = 4;
            // 
            // txtSyntaxName
            // 
            this.txtSyntaxName.Location = new System.Drawing.Point(3, 3);
            this.txtSyntaxName.Name = "txtSyntaxName";
            this.txtSyntaxName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtSyntaxName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtSyntaxName.Properties.Appearance.Options.UseBackColor = true;
            this.txtSyntaxName.Properties.Appearance.Options.UseForeColor = true;
            this.txtSyntaxName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtSyntaxName.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtSyntaxName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSyntaxName.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtSyntaxName.Size = new System.Drawing.Size(240, 16);
            this.txtSyntaxName.TabIndex = 0;
            // 
            // hFlowLayoutPanel3
            // 
            this.hFlowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.hFlowLayoutPanel3.AutoSize = true;
            this.hFlowLayoutPanel3.Controls.Add(this.hLabelControl3);
            this.hFlowLayoutPanel3.Controls.Add(this.txtModality);
            this.hFlowLayoutPanel3.Location = new System.Drawing.Point(158, 71);
            this.hFlowLayoutPanel3.Name = "hFlowLayoutPanel3";
            this.hFlowLayoutPanel3.Size = new System.Drawing.Size(190, 22);
            this.hFlowLayoutPanel3.TabIndex = 2;
            // 
            // hLabelControl3
            // 
            this.hLabelControl3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hLabelControl3.Location = new System.Drawing.Point(3, 5);
            this.hLabelControl3.Name = "hLabelControl3";
            this.hLabelControl3.Size = new System.Drawing.Size(48, 12);
            this.hLabelControl3.TabIndex = 0;
            this.hLabelControl3.Text = "Modality";
            // 
            // txtModality
            // 
            this.txtModality.Location = new System.Drawing.Point(57, 3);
            this.txtModality.Name = "txtModality";
            this.txtModality.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtModality.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtModality.Properties.Appearance.Options.UseBackColor = true;
            this.txtModality.Properties.Appearance.Options.UseForeColor = true;
            this.txtModality.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtModality.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtModality.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtModality.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtModality.Size = new System.Drawing.Size(130, 16);
            this.txtModality.TabIndex = 2;
            // 
            // hFlowLayoutPanel2
            // 
            this.hFlowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.hFlowLayoutPanel2.AutoSize = true;
            this.hFlowLayoutPanel2.Controls.Add(this.hLabelControl2);
            this.hFlowLayoutPanel2.Controls.Add(this.txtInterval);
            this.hFlowLayoutPanel2.Location = new System.Drawing.Point(122, 38);
            this.hFlowLayoutPanel2.Name = "hFlowLayoutPanel2";
            this.hFlowLayoutPanel2.Size = new System.Drawing.Size(226, 22);
            this.hFlowLayoutPanel2.TabIndex = 1;
            // 
            // hLabelControl2
            // 
            this.hLabelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hLabelControl2.Location = new System.Drawing.Point(3, 5);
            this.hLabelControl2.Name = "hLabelControl2";
            this.hLabelControl2.Size = new System.Drawing.Size(84, 12);
            this.hLabelControl2.TabIndex = 0;
            this.hLabelControl2.Text = "Search Interval";
            // 
            // txtInterval
            // 
            this.txtInterval.Location = new System.Drawing.Point(93, 3);
            this.txtInterval.Name = "txtInterval";
            this.txtInterval.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtInterval.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtInterval.Properties.Appearance.Options.UseBackColor = true;
            this.txtInterval.Properties.Appearance.Options.UseForeColor = true;
            this.txtInterval.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtInterval.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtInterval.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtInterval.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtInterval.Size = new System.Drawing.Size(130, 16);
            this.txtInterval.TabIndex = 2;
            // 
            // hFlowLayoutPanel1
            // 
            this.hFlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.hFlowLayoutPanel1.AutoSize = true;
            this.hFlowLayoutPanel1.Controls.Add(this.hLabelControl1);
            this.hFlowLayoutPanel1.Controls.Add(this.txtState);
            this.hFlowLayoutPanel1.Location = new System.Drawing.Point(171, 5);
            this.hFlowLayoutPanel1.Name = "hFlowLayoutPanel1";
            this.hFlowLayoutPanel1.Size = new System.Drawing.Size(177, 22);
            this.hFlowLayoutPanel1.TabIndex = 0;
            // 
            // hLabelControl1
            // 
            this.hLabelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hLabelControl1.Location = new System.Drawing.Point(3, 5);
            this.hLabelControl1.Name = "hLabelControl1";
            this.hLabelControl1.Size = new System.Drawing.Size(35, 12);
            this.hLabelControl1.TabIndex = 0;
            this.hLabelControl1.Text = "Status";
            // 
            // txtState
            // 
            this.txtState.Location = new System.Drawing.Point(44, 3);
            this.txtState.Name = "txtState";
            this.txtState.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtState.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtState.Properties.Appearance.Options.UseBackColor = true;
            this.txtState.Properties.Appearance.Options.UseForeColor = true;
            this.txtState.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtState.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtState.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtState.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtState.Size = new System.Drawing.Size(130, 16);
            this.txtState.TabIndex = 1;
            // 
            // hFlowLayoutPanel4
            // 
            this.hFlowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hFlowLayoutPanel4.AutoSize = true;
            this.hFlowLayoutPanel4.Controls.Add(this.hLabelControl4);
            this.hFlowLayoutPanel4.Location = new System.Drawing.Point(129, 106);
            this.hFlowLayoutPanel4.Name = "hFlowLayoutPanel4";
            this.hFlowLayoutPanel4.Size = new System.Drawing.Size(92, 18);
            this.hFlowLayoutPanel4.TabIndex = 3;
            // 
            // hLabelControl4
            // 
            this.hLabelControl4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hLabelControl4.Location = new System.Drawing.Point(3, 3);
            this.hLabelControl4.Name = "hLabelControl4";
            this.hLabelControl4.Size = new System.Drawing.Size(86, 12);
            this.hLabelControl4.TabIndex = 0;
            this.hLabelControl4.Text = "TransferSyntax";
            // 
            // hFlowLayoutPanel7
            // 
            this.hFlowLayoutPanel7.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.hFlowLayoutPanel7.AutoSize = true;
            this.hFlowLayoutPanel7.Controls.Add(this.btnSetting);
            this.hFlowLayoutPanel7.Controls.Add(this.btnTest);
            this.hFlowLayoutPanel7.Controls.Add(this.btnStart);
            this.hFlowLayoutPanel7.Controls.Add(this.btnClose);
            this.hFlowLayoutPanel7.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.hFlowLayoutPanel7.Location = new System.Drawing.Point(3, 75);
            this.hFlowLayoutPanel7.Name = "hFlowLayoutPanel7";
            this.hFlowLayoutPanel7.Size = new System.Drawing.Size(96, 116);
            this.hFlowLayoutPanel7.TabIndex = 1;
            // 
            // btnSetting
            // 
            this.btnSetting.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Appearance.Options.UseForeColor = true;
            this.btnSetting.Location = new System.Drawing.Point(3, 3);
            this.btnSetting.LookAndFeel.SkinName = "My Basic";
            this.btnSetting.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnSetting.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnSetting.Size = new System.Drawing.Size(90, 23);
            this.btnSetting.TabIndex = 0;
            this.btnSetting.Text = "환경설정";
            // 
            // btnTest
            // 
            this.btnTest.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnTest.Appearance.Options.UseForeColor = true;
            this.btnTest.Location = new System.Drawing.Point(3, 32);
            this.btnTest.LookAndFeel.SkinName = "My Basic";
            this.btnTest.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnTest.Name = "btnTest";
            this.btnTest.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnTest.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnTest.Size = new System.Drawing.Size(90, 23);
            this.btnTest.TabIndex = 1;
            this.btnTest.Text = "전송 테스트";
            this.btnTest.Click += new System.EventHandler(this.hSedasSImpleButtonBlue2_Click);
            // 
            // btnStart
            // 
            this.btnStart.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnStart.Appearance.Options.UseForeColor = true;
            this.btnStart.Location = new System.Drawing.Point(3, 61);
            this.btnStart.LookAndFeel.SkinName = "My Basic";
            this.btnStart.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnStart.Name = "btnStart";
            this.btnStart.SedasButtonType = Sedas.Control.HSedasSImpleButtonOrange.HSimpleButtonType.Null;
            this.btnStart.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnStart.Size = new System.Drawing.Size(90, 23);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "시작";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Location = new System.Drawing.Point(3, 90);
            this.btnClose.LookAndFeel.SkinName = "My Basic";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Name = "btnClose";
            this.btnClose.SedasButtonType = Sedas.Control.HSedasSImpleButtonGreen.HSimpleButtonType.Null;
            this.btnClose.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnClose.Size = new System.Drawing.Size(90, 23);
            this.btnClose.TabIndex = 3;
            this.btnClose.Text = "닫기";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tlpLog
            // 
            this.tlpLog.ColumnCount = 1;
            this.tlpMain.SetColumnSpan(this.tlpLog, 2);
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLog.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpLog.Controls.Add(this.memoLog, 0, 0);
            this.tlpLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLog.Location = new System.Drawing.Point(3, 203);
            this.tlpLog.Name = "tlpLog";
            this.tlpLog.RowCount = 1;
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLog.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 303F));
            this.tlpLog.Size = new System.Drawing.Size(651, 302);
            this.tlpLog.TabIndex = 2;
            // 
            // memoLog
            // 
            this.memoLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoLog.Location = new System.Drawing.Point(3, 3);
            this.memoLog.Name = "memoLog";
            this.memoLog.SedasControlType = Sedas.Control.ControlType.Null;
            this.memoLog.Size = new System.Drawing.Size(645, 296);
            this.memoLog.TabIndex = 0;
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.hFlowLayoutPanel7, 0, 1);
            this.tlpRight.Controls.Add(this.hTableLayoutPanel1, 0, 0);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(360, 3);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 2;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpRight.Size = new System.Drawing.Size(294, 194);
            this.tlpRight.TabIndex = 3;
            // 
            // hTableLayoutPanel1
            // 
            this.hTableLayoutPanel1.ColumnCount = 2;
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.hTableLayoutPanel1.Name = "hTableLayoutPanel1";
            this.hTableLayoutPanel1.RowCount = 2;
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hTableLayoutPanel1.Size = new System.Drawing.Size(288, 66);
            this.hTableLayoutPanel1.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(657, 508);
            this.Controls.Add(this.tlpMain);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("MainForm.IconOptions.Image")));
            this.Name = "MainForm";
            this.Text = "Dicom Gateway";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.tlpLeft.PerformLayout();
            this.hFlowLayoutPanel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSyntaxValue.Properties)).EndInit();
            this.hFlowLayoutPanel5.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtSyntaxName.Properties)).EndInit();
            this.hFlowLayoutPanel3.ResumeLayout(false);
            this.hFlowLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtModality.Properties)).EndInit();
            this.hFlowLayoutPanel2.ResumeLayout(false);
            this.hFlowLayoutPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtInterval.Properties)).EndInit();
            this.hFlowLayoutPanel1.ResumeLayout(false);
            this.hFlowLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtState.Properties)).EndInit();
            this.hFlowLayoutPanel4.ResumeLayout(false);
            this.hFlowLayoutPanel4.PerformLayout();
            this.hFlowLayoutPanel7.ResumeLayout(false);
            this.tlpLog.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoLog.Properties)).EndInit();
            this.tlpRight.ResumeLayout(false);
            this.tlpRight.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private Sedas.Control.HTableLayoutPanel tlpLeft;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel3;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel2;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel1;
        private Sedas.Control.HLabelControl hLabelControl1;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel6;
        private Sedas.Control.HTextEdit txtSyntaxValue;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel5;
        private Sedas.Control.HTextEdit txtSyntaxName;
        private Sedas.Control.HLabelControl hLabelControl3;
        private Sedas.Control.HTextEdit txtModality;
        private Sedas.Control.HLabelControl hLabelControl2;
        private Sedas.Control.HTextEdit txtInterval;
        private Sedas.Control.HTextEdit txtState;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel4;
        private Sedas.Control.HLabelControl hLabelControl4;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel7;
        private Sedas.Control.HSedasSImpleButtonBlue btnSetting;
        private Sedas.Control.HSedasSImpleButtonBlue btnTest;
        private Sedas.Control.HSedasSImpleButtonOrange btnStart;
        private Sedas.Control.HSedasSImpleButtonGreen btnClose;
        private Sedas.Control.HTableLayoutPanel tlpLog;
        private Sedas.Control.HMemoEdit memoLog;
        private Sedas.Control.HTableLayoutPanel tlpRight;
        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel1;
    }
}