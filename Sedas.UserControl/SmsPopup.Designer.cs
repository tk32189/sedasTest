namespace Sedas.UserControl
{
    partial class SmsPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SmsPopup));
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.tlpTop = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hLabelControl1 = new Sedas.Control.HLabelControl(this.components);
            this.hLabelControl2 = new Sedas.Control.HLabelControl(this.components);
            this.flwpnlButtons = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.btnAddRow = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.btnAddDelete = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.btnClear = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.btnExcel = new Sedas.Control.HSedasSImpleButtonGreen(this.components);
            this.btnSendSms = new Sedas.Control.HSedasSImpleButtonOrange(this.components);
            this.flwSender = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.hLabelControl3 = new Sedas.Control.HLabelControl(this.components);
            this.txtSendNum = new Sedas.Control.HTextEdit(this.components);
            this.hLabelControl4 = new Sedas.Control.HLabelControl(this.components);
            this.txtSendName = new Sedas.Control.HTextEdit(this.components);
            this.hTableLayoutPanel1 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.grdSms = new Sedas.Control.GridControl.HGridControl(this.components);
            this.grvSms = new Sedas.Control.GridControl.HGridView();
            this.hGridColumn1 = new Sedas.Control.GridControl.HGridColumn();
            this.hGridColumn2 = new Sedas.Control.GridControl.HGridColumn();
            this.hGridColumn3 = new Sedas.Control.GridControl.HGridColumn();
            this.repositoryItemMemoEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit();
            this.hGridColumn4 = new Sedas.Control.GridControl.HGridColumn();
            this.hGridColumn5 = new Sedas.Control.GridControl.HGridColumn();
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.tlpMain.SuspendLayout();
            this.tlpTop.SuspendLayout();
            this.flwpnlButtons.SuspendLayout();
            this.flwSender.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSendNum.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSendName.Properties)).BeginInit();
            this.hTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSms)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 1190F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.tlpTop, 0, 0);
            this.tlpMain.Controls.Add(this.hTableLayoutPanel1, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1190, 447);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpTop
            // 
            this.tlpTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.tlpTop.ColumnCount = 5;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTop.Controls.Add(this.hLabelControl1, 0, 0);
            this.tlpTop.Controls.Add(this.hLabelControl2, 1, 0);
            this.tlpTop.Controls.Add(this.flwpnlButtons, 4, 0);
            this.tlpTop.Controls.Add(this.flwSender, 3, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop.Location = new System.Drawing.Point(0, 0);
            this.tlpTop.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Size = new System.Drawing.Size(1190, 40);
            this.tlpTop.TabIndex = 0;
            // 
            // hLabelControl1
            // 
            this.hLabelControl1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hLabelControl1.Location = new System.Drawing.Point(10, 14);
            this.hLabelControl1.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.hLabelControl1.Name = "hLabelControl1";
            this.hLabelControl1.Size = new System.Drawing.Size(95, 12);
            this.hLabelControl1.TabIndex = 0;
            this.hLabelControl1.Text = "SMS 전송 대상자";
            // 
            // hLabelControl2
            // 
            this.hLabelControl2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hLabelControl2.Location = new System.Drawing.Point(118, 14);
            this.hLabelControl2.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.hLabelControl2.Name = "hLabelControl2";
            this.hLabelControl2.Size = new System.Drawing.Size(268, 12);
            this.hLabelControl2.TabIndex = 1;
            this.hLabelControl2.Text = "* Message 전송은 최대 80 Byte까지 가능합니다.";
            // 
            // flwpnlButtons
            // 
            this.flwpnlButtons.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.flwpnlButtons.AutoSize = true;
            this.flwpnlButtons.Controls.Add(this.btnAddRow);
            this.flwpnlButtons.Controls.Add(this.btnAddDelete);
            this.flwpnlButtons.Controls.Add(this.btnClear);
            this.flwpnlButtons.Controls.Add(this.btnExcel);
            this.flwpnlButtons.Controls.Add(this.btnSendSms);
            this.flwpnlButtons.Location = new System.Drawing.Point(863, 3);
            this.flwpnlButtons.Name = "flwpnlButtons";
            this.flwpnlButtons.Size = new System.Drawing.Size(324, 34);
            this.flwpnlButtons.TabIndex = 4;
            // 
            // btnAddRow
            // 
            this.btnAddRow.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAddRow.Appearance.Options.UseForeColor = true;
            this.btnAddRow.Location = new System.Drawing.Point(3, 3);
            this.btnAddRow.LookAndFeel.SkinName = "My Basic";
            this.btnAddRow.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddRow.Name = "btnAddRow";
            this.btnAddRow.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnAddRow.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnAddRow.Size = new System.Drawing.Size(75, 23);
            this.btnAddRow.TabIndex = 0;
            this.btnAddRow.Text = "행추가";
            this.btnAddRow.Click += new System.EventHandler(this.btnAddRow_Click);
            // 
            // btnAddDelete
            // 
            this.btnAddDelete.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnAddDelete.Appearance.Options.UseForeColor = true;
            this.btnAddDelete.Location = new System.Drawing.Point(84, 3);
            this.btnAddDelete.LookAndFeel.SkinName = "My Basic";
            this.btnAddDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAddDelete.Name = "btnAddDelete";
            this.btnAddDelete.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnAddDelete.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnAddDelete.Size = new System.Drawing.Size(75, 23);
            this.btnAddDelete.TabIndex = 1;
            this.btnAddDelete.Text = "행삭제";
            this.btnAddDelete.Click += new System.EventHandler(this.btnAddDelete_Click);
            // 
            // btnClear
            // 
            this.btnClear.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClear.Appearance.Options.UseForeColor = true;
            this.btnClear.Location = new System.Drawing.Point(165, 3);
            this.btnClear.LookAndFeel.SkinName = "My Basic";
            this.btnClear.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClear.Name = "btnClear";
            this.btnClear.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnClear.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "정리";
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnExcel
            // 
            this.btnExcel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExcel.Appearance.Options.UseForeColor = true;
            this.btnExcel.Location = new System.Drawing.Point(246, 3);
            this.btnExcel.LookAndFeel.SkinName = "My Basic";
            this.btnExcel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.SedasButtonType = Sedas.Control.HSedasSImpleButtonGreen.HSimpleButtonType.Null;
            this.btnExcel.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExcel.TabIndex = 5;
            this.btnExcel.Text = "엑셀";
            this.btnExcel.Visible = false;
            // 
            // btnSendSms
            // 
            this.btnSendSms.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSendSms.Appearance.Options.UseForeColor = true;
            this.btnSendSms.Location = new System.Drawing.Point(3, 32);
            this.btnSendSms.LookAndFeel.SkinName = "My Basic";
            this.btnSendSms.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSendSms.Name = "btnSendSms";
            this.btnSendSms.SedasButtonType = Sedas.Control.HSedasSImpleButtonOrange.HSimpleButtonType.Null;
            this.btnSendSms.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnSendSms.Size = new System.Drawing.Size(75, 23);
            this.btnSendSms.TabIndex = 4;
            this.btnSendSms.Text = "SMS전송";
            this.btnSendSms.Click += new System.EventHandler(this.btnSendSms_Click);
            // 
            // flwSender
            // 
            this.flwSender.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.flwSender.AutoSize = true;
            this.flwSender.Controls.Add(this.hLabelControl3);
            this.flwSender.Controls.Add(this.txtSendNum);
            this.flwSender.Controls.Add(this.hLabelControl4);
            this.flwSender.Controls.Add(this.txtSendName);
            this.flwSender.Location = new System.Drawing.Point(392, 9);
            this.flwSender.Name = "flwSender";
            this.flwSender.Size = new System.Drawing.Size(339, 22);
            this.flwSender.TabIndex = 6;
            // 
            // hLabelControl3
            // 
            this.hLabelControl3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hLabelControl3.Location = new System.Drawing.Point(10, 5);
            this.hLabelControl3.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.hLabelControl3.Name = "hLabelControl3";
            this.hLabelControl3.Size = new System.Drawing.Size(60, 12);
            this.hLabelControl3.TabIndex = 3;
            this.hLabelControl3.Text = "발신번호 : ";
            // 
            // txtSendNum
            // 
            this.txtSendNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSendNum.Location = new System.Drawing.Point(76, 3);
            this.txtSendNum.Name = "txtSendNum";
            this.txtSendNum.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtSendNum.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtSendNum.Properties.Appearance.Options.UseBackColor = true;
            this.txtSendNum.Properties.Appearance.Options.UseForeColor = true;
            this.txtSendNum.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtSendNum.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtSendNum.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSendNum.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtSendNum.Size = new System.Drawing.Size(94, 16);
            this.txtSendNum.TabIndex = 5;
            // 
            // hLabelControl4
            // 
            this.hLabelControl4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hLabelControl4.Location = new System.Drawing.Point(176, 5);
            this.hLabelControl4.Name = "hLabelControl4";
            this.hLabelControl4.Size = new System.Drawing.Size(60, 12);
            this.hLabelControl4.TabIndex = 6;
            this.hLabelControl4.Text = "발신자명 : ";
            // 
            // txtSendName
            // 
            this.txtSendName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSendName.Location = new System.Drawing.Point(242, 3);
            this.txtSendName.Name = "txtSendName";
            this.txtSendName.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtSendName.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtSendName.Properties.Appearance.Options.UseBackColor = true;
            this.txtSendName.Properties.Appearance.Options.UseForeColor = true;
            this.txtSendName.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtSendName.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtSendName.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSendName.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtSendName.Size = new System.Drawing.Size(94, 16);
            this.txtSendName.TabIndex = 7;
            // 
            // hTableLayoutPanel1
            // 
            this.hTableLayoutPanel1.ColumnCount = 1;
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.hTableLayoutPanel1.Controls.Add(this.grdSms, 0, 0);
            this.hTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel1.Location = new System.Drawing.Point(3, 43);
            this.hTableLayoutPanel1.Name = "hTableLayoutPanel1";
            this.hTableLayoutPanel1.RowCount = 1;
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 401F));
            this.hTableLayoutPanel1.Size = new System.Drawing.Size(1184, 401);
            this.hTableLayoutPanel1.TabIndex = 1;
            // 
            // grdSms
            // 
            this.grdSms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSms.Location = new System.Drawing.Point(3, 3);
            this.grdSms.MainView = this.grvSms;
            this.grdSms.Name = "grdSms";
            this.grdSms.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemMemoEdit1});
            this.grdSms.Size = new System.Drawing.Size(1178, 395);
            this.grdSms.TabIndex = 0;
            this.grdSms.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvSms});
            // 
            // grvSms
            // 
            this.grvSms.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvSms.Appearance.Empty.Options.UseBackColor = true;
            this.grvSms.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvSms.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvSms.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvSms.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvSms.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.grvSms.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvSms.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvSms.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvSms.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvSms.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvSms.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvSms.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvSms.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvSms.Appearance.Row.Options.UseBackColor = true;
            this.grvSms.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvSms.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvSms.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvSms.Appearance.VertLine.Options.UseBackColor = true;
            this.grvSms.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.grvSms.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.hGridColumn1,
            this.hGridColumn2,
            this.hGridColumn3,
            this.hGridColumn4,
            this.hGridColumn5});
            this.grvSms.GridControl = this.grdSms;
            this.grvSms.IsSedasDefaultGrid = true;
            this.grvSms.Name = "grvSms";
            this.grvSms.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.False;
            this.grvSms.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.False;
            this.grvSms.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.grvSms.OptionsCustomization.AllowColumnMoving = false;
            this.grvSms.OptionsCustomization.AllowFilter = false;
            this.grvSms.OptionsCustomization.AllowSort = false;
            this.grvSms.OptionsFind.AllowFindPanel = false;
            this.grvSms.OptionsMenu.EnableColumnMenu = false;
            this.grvSms.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvSms.OptionsView.ShowGroupPanel = false;
            this.grvSms.OptionsView.ShowIndicator = false;
            this.grvSms.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.grvSms.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grvSms_CellValueChanged);
            // 
            // hGridColumn1
            // 
            this.hGridColumn1.AppearanceCell.Options.UseTextOptions = true;
            this.hGridColumn1.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn1.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn1.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn1.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn1.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn1.Caption = "이름";
            this.hGridColumn1.FieldName = "recvname";
            this.hGridColumn1.Name = "hGridColumn1";
            this.hGridColumn1.OptionsColumn.FixedWidth = true;
            this.hGridColumn1.Visible = true;
            this.hGridColumn1.VisibleIndex = 0;
            this.hGridColumn1.Width = 90;
            // 
            // hGridColumn2
            // 
            this.hGridColumn2.AppearanceCell.Options.UseTextOptions = true;
            this.hGridColumn2.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn2.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn2.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn2.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn2.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn2.Caption = "휴대전화번호";
            this.hGridColumn2.FieldName = "celtel";
            this.hGridColumn2.Name = "hGridColumn2";
            this.hGridColumn2.OptionsColumn.FixedWidth = true;
            this.hGridColumn2.Visible = true;
            this.hGridColumn2.VisibleIndex = 1;
            this.hGridColumn2.Width = 100;
            // 
            // hGridColumn3
            // 
            this.hGridColumn3.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn3.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn3.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn3.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn3.Caption = "SMS Message";
            this.hGridColumn3.ColumnEdit = this.repositoryItemMemoEdit1;
            this.hGridColumn3.FieldName = "smsm";
            this.hGridColumn3.Name = "hGridColumn3";
            this.hGridColumn3.Visible = true;
            this.hGridColumn3.VisibleIndex = 2;
            this.hGridColumn3.Width = 428;
            // 
            // repositoryItemMemoEdit1
            // 
            this.repositoryItemMemoEdit1.Name = "repositoryItemMemoEdit1";
            this.repositoryItemMemoEdit1.EditValueChanging += new DevExpress.XtraEditors.Controls.ChangingEventHandler(this.repositoryItemMemoEdit1_EditValueChanging);
            // 
            // hGridColumn4
            // 
            this.hGridColumn4.AppearanceCell.Options.UseTextOptions = true;
            this.hGridColumn4.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn4.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn4.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn4.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn4.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn4.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn4.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn4.Caption = "Byte";
            this.hGridColumn4.FieldName = "msgByte";
            this.hGridColumn4.Name = "hGridColumn4";
            this.hGridColumn4.OptionsColumn.AllowEdit = false;
            this.hGridColumn4.OptionsColumn.FixedWidth = true;
            this.hGridColumn4.OptionsColumn.ReadOnly = true;
            this.hGridColumn4.Visible = true;
            this.hGridColumn4.VisibleIndex = 3;
            this.hGridColumn4.Width = 48;
            // 
            // hGridColumn5
            // 
            this.hGridColumn5.AppearanceCell.Options.UseTextOptions = true;
            this.hGridColumn5.AppearanceCell.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn5.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn5.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn5.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn5.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn5.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn5.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn5.Caption = "전송";
            this.hGridColumn5.FieldName = "sendflag";
            this.hGridColumn5.Name = "hGridColumn5";
            this.hGridColumn5.OptionsColumn.AllowEdit = false;
            this.hGridColumn5.OptionsColumn.FixedWidth = true;
            this.hGridColumn5.OptionsColumn.ReadOnly = true;
            this.hGridColumn5.Visible = true;
            this.hGridColumn5.VisibleIndex = 4;
            this.hGridColumn5.Width = 80;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(1190, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 447);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(1190, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 447);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1190, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 447);
            // 
            // SmsPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1190, 447);
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("SmsPopup.IconOptions.Image")));
            this.Name = "SmsPopup";
            this.Text = "SMS 전송";
            this.Load += new System.EventHandler(this.SmsPopup_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpTop.ResumeLayout(false);
            this.tlpTop.PerformLayout();
            this.flwpnlButtons.ResumeLayout(false);
            this.flwSender.ResumeLayout(false);
            this.flwSender.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtSendNum.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSendName.Properties)).EndInit();
            this.hTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdSms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvSms)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemMemoEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.HTableLayoutPanel tlpMain;
        private Control.HTableLayoutPanel tlpTop;
        private Control.HLabelControl hLabelControl1;
        private Control.HLabelControl hLabelControl2;
        private Control.HFlowLayoutPanel flwpnlButtons;
        private Control.HSedasSImpleButtonBlue btnAddRow;
        private Control.HSedasSImpleButtonBlue btnAddDelete;
        private Control.HSedasSImpleButtonBlue btnClear;
        private Control.HSedasSImpleButtonOrange btnSendSms;
        private Control.HSedasSImpleButtonGreen btnExcel;
        private Control.HTableLayoutPanel hTableLayoutPanel1;
        private Control.GridControl.HGridControl grdSms;
        private Control.GridControl.HGridView grvSms;
        private Control.GridControl.HGridColumn hGridColumn1;
        private Control.GridControl.HGridColumn hGridColumn2;
        private Control.GridControl.HGridColumn hGridColumn3;
        private Control.GridControl.HGridColumn hGridColumn4;
        private Control.GridControl.HGridColumn hGridColumn5;
        private Control.HTextEdit txtSendNum;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraEditors.Repository.RepositoryItemMemoEdit repositoryItemMemoEdit1;
        private Control.HFlowLayoutPanel flwSender;
        private Control.HLabelControl hLabelControl3;
        private Control.HLabelControl hLabelControl4;
        private Control.HTextEdit txtSendName;
    }
}