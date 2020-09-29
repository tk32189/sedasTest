namespace Integration_Viewer
{
    partial class SimpleFileList
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.lblName = new Sedas.Control.HLabelControl(this.components);
            this.tlpCenter = new Sedas.Control.HTableLayoutPanel(this.components);
            this.grdFileList = new Sedas.Control.GridControl.HGridControl(this.components);
            this.grvFileList = new Sedas.Control.GridControl.HGridView();
            this.hGridColumn2 = new Sedas.Control.GridControl.HGridColumn();
            this.repositoryItemCheckEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit();
            this.hGridColumn1 = new Sedas.Control.GridControl.HGridColumn();
            this.tlpMain.SuspendLayout();
            this.tlpCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFileList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFileList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(47)))), ((int)(((byte)(67)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.lblName, 0, 0);
            this.tlpMain.Controls.Add(this.tlpCenter, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(518, 324);
            this.tlpMain.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblName.Location = new System.Drawing.Point(3, 7);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(47, 12);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "lblName";
            // 
            // tlpCenter
            // 
            this.tlpCenter.ColumnCount = 1;
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCenter.Controls.Add(this.grdFileList, 0, 0);
            this.tlpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCenter.Location = new System.Drawing.Point(3, 29);
            this.tlpCenter.Name = "tlpCenter";
            this.tlpCenter.RowCount = 1;
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tlpCenter.Size = new System.Drawing.Size(512, 292);
            this.tlpCenter.TabIndex = 1;
            // 
            // grdFileList
            // 
            this.grdFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdFileList.Location = new System.Drawing.Point(3, 3);
            this.grdFileList.MainView = this.grvFileList;
            this.grdFileList.Name = "grdFileList";
            this.grdFileList.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemCheckEdit1});
            this.grdFileList.Size = new System.Drawing.Size(506, 286);
            this.grdFileList.TabIndex = 0;
            this.grdFileList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvFileList});
            this.grdFileList.MouseUp += new System.Windows.Forms.MouseEventHandler(this.grdFileList_MouseUp);
            // 
            // grvFileList
            // 
            this.grvFileList.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvFileList.Appearance.Empty.Options.UseBackColor = true;
            this.grvFileList.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvFileList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvFileList.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvFileList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvFileList.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.grvFileList.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvFileList.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvFileList.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvFileList.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvFileList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvFileList.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvFileList.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvFileList.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvFileList.Appearance.Row.Options.UseBackColor = true;
            this.grvFileList.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvFileList.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvFileList.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvFileList.Appearance.VertLine.Options.UseBackColor = true;
            this.grvFileList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.grvFileList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.hGridColumn2,
            this.hGridColumn1});
            this.grvFileList.DetailHeight = 300;
            this.grvFileList.GridControl = this.grdFileList;
            this.grvFileList.IsSedasDefaultGrid = true;
            this.grvFileList.Name = "grvFileList";
            this.grvFileList.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.False;
            this.grvFileList.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.False;
            this.grvFileList.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.grvFileList.OptionsCustomization.AllowColumnMoving = false;
            this.grvFileList.OptionsCustomization.AllowFilter = false;
            this.grvFileList.OptionsCustomization.AllowSort = false;
            this.grvFileList.OptionsFind.AllowFindPanel = false;
            this.grvFileList.OptionsMenu.EnableColumnMenu = false;
            this.grvFileList.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvFileList.OptionsView.ShowGroupPanel = false;
            this.grvFileList.OptionsView.ShowIndicator = false;
            this.grvFileList.SedasControlType = Sedas.Control.ControlType.Kuh;
            // 
            // hGridColumn2
            // 
            this.hGridColumn2.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn2.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn2.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn2.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn2.Caption = "선택";
            this.hGridColumn2.ColumnEdit = this.repositoryItemCheckEdit1;
            this.hGridColumn2.FieldName = "isChecked";
            this.hGridColumn2.Name = "hGridColumn2";
            this.hGridColumn2.OptionsColumn.FixedWidth = true;
            this.hGridColumn2.Visible = true;
            this.hGridColumn2.VisibleIndex = 0;
            this.hGridColumn2.Width = 40;
            // 
            // repositoryItemCheckEdit1
            // 
            this.repositoryItemCheckEdit1.AutoHeight = false;
            this.repositoryItemCheckEdit1.Name = "repositoryItemCheckEdit1";
            this.repositoryItemCheckEdit1.NullText = "N";
            this.repositoryItemCheckEdit1.ValueChecked = "Y";
            this.repositoryItemCheckEdit1.ValueUnchecked = "N";
            this.repositoryItemCheckEdit1.CheckedChanged += new System.EventHandler(this.repositoryItemCheckEdit1_CheckedChanged);
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
            this.hGridColumn1.VisibleIndex = 1;
            this.hGridColumn1.Width = 464;
            // 
            // SimpleFileList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "SimpleFileList";
            this.Size = new System.Drawing.Size(518, 324);
            this.Load += new System.EventHandler(this.SimpleFileList_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdFileList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvFileList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemCheckEdit1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private Sedas.Control.HLabelControl lblName;
        private Sedas.Control.HTableLayoutPanel tlpCenter;
        private Sedas.Control.GridControl.HGridControl grdFileList;
        private Sedas.Control.GridControl.HGridView grvFileList;
        private Sedas.Control.GridControl.HGridColumn hGridColumn1;
        private Sedas.Control.GridControl.HGridColumn hGridColumn2;
        private DevExpress.XtraEditors.Repository.RepositoryItemCheckEdit repositoryItemCheckEdit1;
    }
}
