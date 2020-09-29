namespace Integration_Viewer
{
    partial class DicomTagViewPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DicomTagViewPopup));
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.grdTagInfo = new Sedas.Control.GridControl.HGridControl(this.components);
            this.grvTagInfo = new Sedas.Control.GridControl.HGridView();
            this.hGridColumn1 = new Sedas.Control.GridControl.HGridColumn();
            this.hGridColumn2 = new Sedas.Control.GridControl.HGridColumn();
            this.hGridColumn3 = new Sedas.Control.GridControl.HGridColumn();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdTagInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTagInfo)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.grdTagInfo, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 450F));
            this.tlpMain.Size = new System.Drawing.Size(807, 450);
            this.tlpMain.TabIndex = 0;
            // 
            // grdTagInfo
            // 
            this.grdTagInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdTagInfo.Location = new System.Drawing.Point(3, 3);
            this.grdTagInfo.MainView = this.grvTagInfo;
            this.grdTagInfo.Name = "grdTagInfo";
            this.grdTagInfo.Size = new System.Drawing.Size(801, 444);
            this.grdTagInfo.TabIndex = 0;
            this.grdTagInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvTagInfo});
            // 
            // grvTagInfo
            // 
            this.grvTagInfo.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvTagInfo.Appearance.Empty.Options.UseBackColor = true;
            this.grvTagInfo.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvTagInfo.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvTagInfo.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvTagInfo.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvTagInfo.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.grvTagInfo.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvTagInfo.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvTagInfo.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvTagInfo.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvTagInfo.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvTagInfo.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvTagInfo.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvTagInfo.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvTagInfo.Appearance.Row.Options.UseBackColor = true;
            this.grvTagInfo.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvTagInfo.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvTagInfo.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvTagInfo.Appearance.VertLine.Options.UseBackColor = true;
            this.grvTagInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.grvTagInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.hGridColumn1,
            this.hGridColumn2,
            this.hGridColumn3});
            this.grvTagInfo.GridControl = this.grdTagInfo;
            this.grvTagInfo.IsSedasDefaultGrid = true;
            this.grvTagInfo.Name = "grvTagInfo";
            this.grvTagInfo.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.False;
            this.grvTagInfo.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.False;
            this.grvTagInfo.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.grvTagInfo.OptionsCustomization.AllowColumnMoving = false;
            this.grvTagInfo.OptionsCustomization.AllowFilter = false;
            this.grvTagInfo.OptionsCustomization.AllowSort = false;
            this.grvTagInfo.OptionsFind.AllowFindPanel = false;
            this.grvTagInfo.OptionsMenu.EnableColumnMenu = false;
            this.grvTagInfo.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvTagInfo.OptionsView.ShowGroupPanel = false;
            this.grvTagInfo.OptionsView.ShowIndicator = false;
            this.grvTagInfo.SedasControlType = Sedas.Control.ControlType.Kuh;
            // 
            // hGridColumn1
            // 
            this.hGridColumn1.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn1.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn1.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn1.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn1.Caption = "Tag ID";
            this.hGridColumn1.FieldName = "tagId";
            this.hGridColumn1.Name = "hGridColumn1";
            this.hGridColumn1.OptionsColumn.AllowEdit = false;
            this.hGridColumn1.OptionsColumn.FixedWidth = true;
            this.hGridColumn1.OptionsColumn.ReadOnly = true;
            this.hGridColumn1.Visible = true;
            this.hGridColumn1.VisibleIndex = 0;
            this.hGridColumn1.Width = 120;
            // 
            // hGridColumn2
            // 
            this.hGridColumn2.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn2.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn2.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn2.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn2.Caption = "Description";
            this.hGridColumn2.FieldName = "description";
            this.hGridColumn2.Name = "hGridColumn2";
            this.hGridColumn2.OptionsColumn.AllowEdit = false;
            this.hGridColumn2.OptionsColumn.ReadOnly = true;
            this.hGridColumn2.Visible = true;
            this.hGridColumn2.VisibleIndex = 1;
            this.hGridColumn2.Width = 139;
            // 
            // hGridColumn3
            // 
            this.hGridColumn3.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn3.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn3.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn3.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn3.Caption = "Value";
            this.hGridColumn3.FieldName = "value";
            this.hGridColumn3.Name = "hGridColumn3";
            this.hGridColumn3.OptionsColumn.AllowEdit = false;
            this.hGridColumn3.OptionsColumn.ReadOnly = true;
            this.hGridColumn3.Visible = true;
            this.hGridColumn3.VisibleIndex = 2;
            this.hGridColumn3.Width = 139;
            // 
            // DicomTagViewPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(807, 450);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("DicomTagViewPopup.IconOptions.Image")));
            this.Name = "DicomTagViewPopup";
            this.Text = "Dicom Tag";
            this.Load += new System.EventHandler(this.DicomTagViewPopup_Load);
            this.Shown += new System.EventHandler(this.DicomTagViewPopup_Shown);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdTagInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvTagInfo)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private Sedas.Control.GridControl.HGridControl grdTagInfo;
        private Sedas.Control.GridControl.HGridView grvTagInfo;
        private Sedas.Control.GridControl.HGridColumn hGridColumn1;
        private Sedas.Control.GridControl.HGridColumn hGridColumn2;
        private Sedas.Control.GridControl.HGridColumn hGridColumn3;
    }
}