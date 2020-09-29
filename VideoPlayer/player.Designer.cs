namespace VideoPlayer
{
    partial class player
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(player));
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.tlpLeft = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hPanelControl1 = new Sedas.Control.HPanelControl(this.components);
            this.hSimpleButton1 = new Sedas.Control.HSimpleButton();
            this.dtpDate = new DevExpress.XtraEditors.DateEdit();
            this.grdFileInfo = new Sedas.Control.GridControl.HGridControl(this.components);
            this.grvFileInfo = new Sedas.Control.GridControl.HGridView();
            this.hGridColumn1 = new Sedas.Control.GridControl.HGridColumn();
            this.hTableLayoutPanel1 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.lblCurrentTime = new Sedas.Control.HLabelControl(this.components);
            this.tlpMain.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).BeginInit();
            this.hPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFileInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFileInfo)).BeginInit();
            this.hTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 3;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpMain.Controls.Add(this.hTableLayoutPanel1, 2, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(749, 361);
            this.tlpMain.TabIndex = 1;
            // 
            // tlpLeft
            // 
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Controls.Add(this.hPanelControl1, 0, 0);
            this.tlpLeft.Controls.Add(this.grdFileInfo, 0, 1);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(3, 3);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 2;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 51F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Size = new System.Drawing.Size(294, 355);
            this.tlpLeft.TabIndex = 0;
            // 
            // hPanelControl1
            // 
            this.hPanelControl1.Controls.Add(this.hSimpleButton1);
            this.hPanelControl1.Controls.Add(this.dtpDate);
            this.hPanelControl1.Location = new System.Drawing.Point(3, 3);
            this.hPanelControl1.Name = "hPanelControl1";
            this.hPanelControl1.Size = new System.Drawing.Size(288, 45);
            this.hPanelControl1.TabIndex = 0;
            // 
            // hSimpleButton1
            // 
            this.hSimpleButton1.Location = new System.Drawing.Point(185, 8);
            this.hSimpleButton1.Name = "hSimpleButton1";
            this.hSimpleButton1.Size = new System.Drawing.Size(75, 23);
            this.hSimpleButton1.TabIndex = 2;
            this.hSimpleButton1.Text = "hSimpleButton1";
            this.hSimpleButton1.Click += new System.EventHandler(this.hSimpleButton1_Click);
            // 
            // dtpDate
            // 
            this.dtpDate.EditValue = null;
            this.dtpDate.Location = new System.Drawing.Point(6, 5);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpDate.Properties.Appearance.Options.UseFont = true;
            this.dtpDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Size = new System.Drawing.Size(150, 30);
            this.dtpDate.TabIndex = 1;
            this.dtpDate.EditValueChanged += new System.EventHandler(this.dtpDate_EditValueChanged);
            // 
            // grdFileInfo
            // 
            this.grdFileInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFileInfo.Location = new System.Drawing.Point(3, 54);
            this.grdFileInfo.MainView = this.grvFileInfo;
            this.grdFileInfo.Name = "grdFileInfo";
            this.grdFileInfo.Size = new System.Drawing.Size(288, 298);
            this.grdFileInfo.TabIndex = 1;
            this.grdFileInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFileInfo});
            // 
            // grvFileInfo
            // 
            this.grvFileInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.hGridColumn1});
            this.grvFileInfo.DetailHeight = 300;
            this.grvFileInfo.GridControl = this.grdFileInfo;
            this.grvFileInfo.Name = "grvFileInfo";
            this.grvFileInfo.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.False;
            this.grvFileInfo.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.False;
            this.grvFileInfo.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.grvFileInfo.OptionsCustomization.AllowColumnMoving = false;
            this.grvFileInfo.OptionsCustomization.AllowFilter = false;
            this.grvFileInfo.OptionsCustomization.AllowSort = false;
            this.grvFileInfo.OptionsFind.AllowFindPanel = false;
            this.grvFileInfo.OptionsMenu.EnableColumnMenu = false;
            this.grvFileInfo.OptionsSelection.MultiSelect = true;
            this.grvFileInfo.OptionsView.ColumnAutoWidth = false;
            this.grvFileInfo.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFileInfo.OptionsView.ShowGroupPanel = false;
            this.grvFileInfo.OptionsView.ShowIndicator = false;
            this.grvFileInfo.DoubleClick += new System.EventHandler(this.hGridView1_DoubleClick);
            // 
            // hGridColumn1
            // 
            this.hGridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn1.Caption = "파일명";
            this.hGridColumn1.FieldName = "fileName";
            this.hGridColumn1.Name = "hGridColumn1";
            this.hGridColumn1.OptionsColumn.AllowEdit = false;
            this.hGridColumn1.OptionsColumn.ReadOnly = true;
            this.hGridColumn1.Visible = true;
            this.hGridColumn1.VisibleIndex = 0;
            this.hGridColumn1.Width = 280;
            // 
            // hTableLayoutPanel1
            // 
            this.hTableLayoutPanel1.ColumnCount = 1;
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.hTableLayoutPanel1.Controls.Add(this.axWindowsMediaPlayer1, 0, 0);
            this.hTableLayoutPanel1.Controls.Add(this.lblCurrentTime, 0, 1);
            this.hTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel1.Location = new System.Drawing.Point(303, 3);
            this.hTableLayoutPanel1.Name = "hTableLayoutPanel1";
            this.hTableLayoutPanel1.RowCount = 2;
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.hTableLayoutPanel1.Size = new System.Drawing.Size(443, 355);
            this.hTableLayoutPanel1.TabIndex = 2;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(3, 3);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(437, 319);
            this.axWindowsMediaPlayer1.TabIndex = 1;
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.Location = new System.Drawing.Point(3, 328);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(0, 12);
            this.lblCurrentTime.TabIndex = 2;
            // 
            // player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(749, 361);
            this.Controls.Add(this.tlpMain);
            this.Name = "player";
            this.Text = "player";
            this.Load += new System.EventHandler(this.player_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).EndInit();
            this.hPanelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdFileInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFileInfo)).EndInit();
            this.hTableLayoutPanel1.ResumeLayout(false);
            this.hTableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private Sedas.Control.HTableLayoutPanel tlpLeft;
        private Sedas.Control.HPanelControl hPanelControl1;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private DevExpress.XtraEditors.DateEdit dtpDate;
        private Sedas.Control.GridControl.HGridControl grdFileInfo;
        private Sedas.Control.GridControl.HGridView grvFileInfo;
        private Sedas.Control.GridControl.HGridColumn hGridColumn1;
        private Sedas.Control.HSimpleButton hSimpleButton1;
        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel1;
        private Sedas.Control.HLabelControl lblCurrentTime;
    }
}