namespace VideoPlayerForServer
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
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.tlpLeft = new System.Windows.Forms.TableLayoutPanel();
            this.grdFileInfo = new Sedas.Control.GridControl.HGridControl(this.components);
            this.grvFileInfo = new Sedas.Control.GridControl.HGridView();
            this.hGridColumn1 = new Sedas.Control.GridControl.HGridColumn();
            this.hFlowLayoutPanel1 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.btnPc1 = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.btnPc2 = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.hFlowLayoutPanel2 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.progressCtrl = new DevExpress.XtraEditors.ProgressBarControl();
            this.txtBigDataInfo = new Sedas.Control.HLabelControl(this.components);
            this.btnLocalFileDelete = new Sedas.Control.HSedasSImpleButtonOrange(this.components);
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.tlpLeft.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFileInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFileInfo)).BeginInit();
            this.hFlowLayoutPanel1.SuspendLayout();
            this.hFlowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.progressCtrl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(21)))));
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.axWindowsMediaPlayer1, 1, 0);
            this.tlpMain.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(799, 473);
            this.tlpMain.TabIndex = 0;
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(303, 3);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(493, 467);
            this.axWindowsMediaPlayer1.TabIndex = 2;
            // 
            // tlpLeft
            // 
            this.tlpLeft.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Controls.Add(this.grdFileInfo, 0, 3);
            this.tlpLeft.Controls.Add(this.hFlowLayoutPanel1, 0, 0);
            this.tlpLeft.Controls.Add(this.hFlowLayoutPanel2, 0, 2);
            this.tlpLeft.Controls.Add(this.txtBigDataInfo, 0, 1);
            this.tlpLeft.Controls.Add(this.btnLocalFileDelete, 0, 4);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(3, 3);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 5;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpLeft.Size = new System.Drawing.Size(294, 467);
            this.tlpLeft.TabIndex = 3;
            this.tlpLeft.CellPaint += new System.Windows.Forms.TableLayoutCellPaintEventHandler(this.tlpLeft_CellPaint);
            // 
            // grdFileInfo
            // 
            this.grdFileInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFileInfo.Location = new System.Drawing.Point(3, 118);
            this.grdFileInfo.MainView = this.grvFileInfo;
            this.grdFileInfo.Name = "grdFileInfo";
            this.grdFileInfo.Size = new System.Drawing.Size(288, 316);
            this.grdFileInfo.TabIndex = 2;
            this.grdFileInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFileInfo});
            // 
            // grvFileInfo
            // 
            this.grvFileInfo.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvFileInfo.Appearance.Empty.Options.UseBackColor = true;
            this.grvFileInfo.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvFileInfo.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFileInfo.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvFileInfo.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFileInfo.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.grvFileInfo.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvFileInfo.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFileInfo.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFileInfo.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvFileInfo.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFileInfo.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvFileInfo.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFileInfo.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvFileInfo.Appearance.Row.Options.UseBackColor = true;
            this.grvFileInfo.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvFileInfo.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFileInfo.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvFileInfo.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFileInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.grvFileInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.hGridColumn1});
            this.grvFileInfo.DetailHeight = 300;
            this.grvFileInfo.GridControl = this.grdFileInfo;
            this.grvFileInfo.IsSedasDefaultGrid = false;
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
            this.grvFileInfo.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFileInfo.OptionsView.ShowGroupPanel = false;
            this.grvFileInfo.OptionsView.ShowIndicator = false;
            this.grvFileInfo.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.grvFileInfo.DoubleClick += new System.EventHandler(this.grvFileInfo_DoubleClick);
            // 
            // hGridColumn1
            // 
            this.hGridColumn1.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn1.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn1.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn1.AppearanceHeader.Options.UseForeColor = true;
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
            // hFlowLayoutPanel1
            // 
            this.hFlowLayoutPanel1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.hFlowLayoutPanel1.AutoSize = true;
            this.hFlowLayoutPanel1.Controls.Add(this.btnPc1);
            this.hFlowLayoutPanel1.Controls.Add(this.btnPc2);
            this.hFlowLayoutPanel1.Location = new System.Drawing.Point(66, 3);
            this.hFlowLayoutPanel1.Name = "hFlowLayoutPanel1";
            this.hFlowLayoutPanel1.Size = new System.Drawing.Size(162, 29);
            this.hFlowLayoutPanel1.TabIndex = 0;
            // 
            // btnPc1
            // 
            this.btnPc1.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPc1.Appearance.Options.UseForeColor = true;
            this.btnPc1.Location = new System.Drawing.Point(3, 3);
            this.btnPc1.LookAndFeel.SkinName = "My Basic";
            this.btnPc1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPc1.Name = "btnPc1";
            this.btnPc1.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnPc1.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnPc1.Size = new System.Drawing.Size(75, 23);
            this.btnPc1.TabIndex = 0;
            this.btnPc1.Text = "Video1 다운";
            this.btnPc1.Click += new System.EventHandler(this.btnPc1_Click);
            // 
            // btnPc2
            // 
            this.btnPc2.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPc2.Appearance.Options.UseForeColor = true;
            this.btnPc2.Location = new System.Drawing.Point(84, 3);
            this.btnPc2.LookAndFeel.SkinName = "My Basic";
            this.btnPc2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPc2.Name = "btnPc2";
            this.btnPc2.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnPc2.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnPc2.Size = new System.Drawing.Size(75, 23);
            this.btnPc2.TabIndex = 1;
            this.btnPc2.Text = "Video2 다운";
            this.btnPc2.Click += new System.EventHandler(this.btnPc2_Click);
            // 
            // hFlowLayoutPanel2
            // 
            this.hFlowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hFlowLayoutPanel2.AutoSize = true;
            this.hFlowLayoutPanel2.Controls.Add(this.progressCtrl);
            this.hFlowLayoutPanel2.Location = new System.Drawing.Point(3, 88);
            this.hFlowLayoutPanel2.Name = "hFlowLayoutPanel2";
            this.hFlowLayoutPanel2.Size = new System.Drawing.Size(258, 24);
            this.hFlowLayoutPanel2.TabIndex = 1;
            // 
            // progressCtrl
            // 
            this.progressCtrl.Location = new System.Drawing.Point(3, 3);
            this.progressCtrl.Name = "progressCtrl";
            this.progressCtrl.Properties.Step = 1;
            this.progressCtrl.Size = new System.Drawing.Size(252, 18);
            this.progressCtrl.TabIndex = 1;
            // 
            // txtBigDataInfo
            // 
            this.txtBigDataInfo.Appearance.Options.UseTextOptions = true;
            this.txtBigDataInfo.Appearance.TextOptions.Trimming = DevExpress.Utils.Trimming.Character;
            this.txtBigDataInfo.Appearance.TextOptions.WordWrap = DevExpress.Utils.WordWrap.Wrap;
            this.txtBigDataInfo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.Vertical;
            this.txtBigDataInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBigDataInfo.Location = new System.Drawing.Point(3, 38);
            this.txtBigDataInfo.Name = "txtBigDataInfo";
            this.txtBigDataInfo.Size = new System.Drawing.Size(288, 44);
            this.txtBigDataInfo.TabIndex = 0;
            // 
            // btnLocalFileDelete
            // 
            this.btnLocalFileDelete.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnLocalFileDelete.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnLocalFileDelete.Appearance.Options.UseForeColor = true;
            this.btnLocalFileDelete.Location = new System.Drawing.Point(187, 440);
            this.btnLocalFileDelete.LookAndFeel.SkinName = "My Basic";
            this.btnLocalFileDelete.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnLocalFileDelete.Margin = new System.Windows.Forms.Padding(3, 3, 10, 3);
            this.btnLocalFileDelete.Name = "btnLocalFileDelete";
            this.btnLocalFileDelete.SedasButtonType = Sedas.Control.HSedasSImpleButtonOrange.HSimpleButtonType.Null;
            this.btnLocalFileDelete.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnLocalFileDelete.Size = new System.Drawing.Size(97, 23);
            this.btnLocalFileDelete.TabIndex = 3;
            this.btnLocalFileDelete.Text = "로컬파일삭제";
            this.btnLocalFileDelete.Click += new System.EventHandler(this.btnLocalFileDelete_Click);
            // 
            // player
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 473);
            this.Controls.Add(this.tlpMain);
            this.Name = "player";
            this.Text = "Video player";
            this.Load += new System.EventHandler(this.player_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.tlpLeft.ResumeLayout(false);
            this.tlpLeft.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFileInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFileInfo)).EndInit();
            this.hFlowLayoutPanel1.ResumeLayout(false);
            this.hFlowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.progressCtrl.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
        private System.Windows.Forms.TableLayoutPanel tlpLeft;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel1;
        private Sedas.Control.HSedasSImpleButtonBlue btnPc1;
        private Sedas.Control.HSedasSImpleButtonBlue btnPc2;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel2;
        private Sedas.Control.HLabelControl txtBigDataInfo;
        private DevExpress.XtraEditors.ProgressBarControl progressCtrl;
        private Sedas.Control.GridControl.HGridControl grdFileInfo;
        private Sedas.Control.GridControl.HGridView grvFileInfo;
        private Sedas.Control.GridControl.HGridColumn hGridColumn1;
        private Sedas.Control.HSedasSImpleButtonOrange btnLocalFileDelete;
    }
}