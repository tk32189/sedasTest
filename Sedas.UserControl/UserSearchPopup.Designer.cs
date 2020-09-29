namespace Sedas.UserControl
{
    partial class UserSearchPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserSearchPopup));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tlpMain = new Sedas.Control.HTableLayoutPanel();
            this.tlpTop = new Sedas.Control.HTableLayoutPanel();
            this.hFlowLayoutPanel1 = new Sedas.Control.HFlowLayoutPanel();
            this.cmbSearchType = new Sedas.Control.HImageComboBoxEdit();
            this.txtSearch = new Sedas.Control.HTextEdit();
            this.btnSearch = new Sedas.Control.HSedasSImpleButtonBlue();
            this.tlpGrid = new Sedas.Control.HTableLayoutPanel();
            this.grdUserInfo = new Sedas.Control.GridControl.HGridControl();
            this.grvUserInfo = new Sedas.Control.GridControl.HGridView();
            this.hGridColumn1 = new Sedas.Control.GridControl.HGridColumn();
            this.hGridColumn2 = new Sedas.Control.GridControl.HGridColumn();
            this.hGridColumn3 = new Sedas.Control.GridControl.HGridColumn();
            this.hFlowLayoutPanel2 = new Sedas.Control.HFlowLayoutPanel();
            this.btnConfirm = new Sedas.Control.HSedasSImpleButtonOrange();
            this.btnClose = new Sedas.Control.HSedasSImpleButtonBlue();
            this.tlpMain.SuspendLayout();
            this.tlpTop.SuspendLayout();
            this.hFlowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cmbSearchType.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).BeginInit();
            this.tlpGrid.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdUserInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserInfo)).BeginInit();
            this.hFlowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpTop, 0, 0);
            this.tlpMain.Controls.Add(this.tlpGrid, 0, 1);
            this.tlpMain.Controls.Add(this.hFlowLayoutPanel2, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tlpMain.Size = new System.Drawing.Size(490, 365);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpTop
            // 
            this.tlpTop.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.tlpTop.ColumnCount = 1;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Controls.Add(this.hFlowLayoutPanel1, 0, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop.Location = new System.Drawing.Point(3, 3);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpTop.Size = new System.Drawing.Size(484, 34);
            this.tlpTop.TabIndex = 0;
            // 
            // hFlowLayoutPanel1
            // 
            this.hFlowLayoutPanel1.Controls.Add(this.cmbSearchType);
            this.hFlowLayoutPanel1.Controls.Add(this.txtSearch);
            this.hFlowLayoutPanel1.Controls.Add(this.btnSearch);
            this.hFlowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.hFlowLayoutPanel1.Name = "hFlowLayoutPanel1";
            this.hFlowLayoutPanel1.Size = new System.Drawing.Size(478, 28);
            this.hFlowLayoutPanel1.TabIndex = 0;
            // 
            // cmbSearchType
            // 
            this.cmbSearchType.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.cmbSearchType.Items = ((System.Collections.ObjectModel.ObservableCollection<string>)(resources.GetObject("cmbSearchType.Items")));
            this.cmbSearchType.Location = new System.Drawing.Point(3, 5);
            this.cmbSearchType.Name = "cmbSearchType";
            this.cmbSearchType.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.cmbSearchType.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.cmbSearchType.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.cmbSearchType.Properties.Appearance.Options.UseBackColor = true;
            this.cmbSearchType.Properties.Appearance.Options.UseBorderColor = true;
            this.cmbSearchType.Properties.Appearance.Options.UseForeColor = true;
            this.cmbSearchType.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.cmbSearchType.Properties.AppearanceDropDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.cmbSearchType.Properties.AppearanceDropDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.cmbSearchType.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cmbSearchType.Properties.AppearanceDropDown.Options.UseBorderColor = true;
            this.cmbSearchType.Properties.AppearanceDropDown.Options.UseForeColor = true;
            this.cmbSearchType.Properties.AppearanceItemSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.cmbSearchType.Properties.AppearanceItemSelected.Options.UseBackColor = true;
            this.cmbSearchType.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            serializableAppearanceObject1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject1.Options.UseBorderColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            serializableAppearanceObject2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject2.Options.UseBorderColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            serializableAppearanceObject3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject3.Options.UseBorderColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.DimGray;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.cmbSearchType.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.cmbSearchType.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cmbSearchType.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cmbSearchType.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.cmbSearchType.SedasSelectedText = "";
            this.cmbSearchType.SedasSelectedValue = "";
            this.cmbSearchType.Size = new System.Drawing.Size(100, 18);
            this.cmbSearchType.TabIndex = 2;
            this.cmbSearchType.SelectedIndexChanged += new System.EventHandler(this.cmbSearchType_SelectedIndexChanged);
            // 
            // txtSearch
            // 
            this.txtSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.txtSearch.Location = new System.Drawing.Point(109, 6);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtSearch.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtSearch.Properties.Appearance.Options.UseBackColor = true;
            this.txtSearch.Properties.Appearance.Options.UseForeColor = true;
            this.txtSearch.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtSearch.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtSearch.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtSearch.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtSearch.Size = new System.Drawing.Size(174, 16);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtSearch_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnSearch.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Appearance.Options.UseForeColor = true;
            this.btnSearch.Location = new System.Drawing.Point(289, 3);
            this.btnSearch.LookAndFeel.SkinName = "My Basic";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnSearch.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnSearch.Size = new System.Drawing.Size(75, 23);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "조회";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // tlpGrid
            // 
            this.tlpGrid.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.tlpGrid.ColumnCount = 1;
            this.tlpGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGrid.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpGrid.Controls.Add(this.grdUserInfo, 0, 0);
            this.tlpGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGrid.Location = new System.Drawing.Point(3, 43);
            this.tlpGrid.Name = "tlpGrid";
            this.tlpGrid.RowCount = 1;
            this.tlpGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGrid.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 279F));
            this.tlpGrid.Size = new System.Drawing.Size(484, 279);
            this.tlpGrid.TabIndex = 1;
            // 
            // grdUserInfo
            // 
            this.grdUserInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdUserInfo.Location = new System.Drawing.Point(3, 3);
            this.grdUserInfo.MainView = this.grvUserInfo;
            this.grdUserInfo.Name = "grdUserInfo";
            this.grdUserInfo.Size = new System.Drawing.Size(478, 273);
            this.grdUserInfo.TabIndex = 0;
            this.grdUserInfo.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvUserInfo});
            // 
            // grvUserInfo
            // 
            this.grvUserInfo.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvUserInfo.Appearance.Empty.Options.UseBackColor = true;
            this.grvUserInfo.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvUserInfo.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvUserInfo.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvUserInfo.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvUserInfo.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.grvUserInfo.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvUserInfo.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvUserInfo.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvUserInfo.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvUserInfo.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvUserInfo.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvUserInfo.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvUserInfo.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvUserInfo.Appearance.Row.Options.UseBackColor = true;
            this.grvUserInfo.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvUserInfo.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvUserInfo.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvUserInfo.Appearance.VertLine.Options.UseBackColor = true;
            this.grvUserInfo.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.grvUserInfo.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.hGridColumn1,
            this.hGridColumn2,
            this.hGridColumn3});
            this.grvUserInfo.GridControl = this.grdUserInfo;
            this.grvUserInfo.IsSedasDefaultGrid = true;
            this.grvUserInfo.Name = "grvUserInfo";
            this.grvUserInfo.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.False;
            this.grvUserInfo.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.False;
            this.grvUserInfo.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.grvUserInfo.OptionsCustomization.AllowColumnMoving = false;
            this.grvUserInfo.OptionsCustomization.AllowFilter = false;
            this.grvUserInfo.OptionsCustomization.AllowSort = false;
            this.grvUserInfo.OptionsFind.AllowFindPanel = false;
            this.grvUserInfo.OptionsMenu.EnableColumnMenu = false;
            this.grvUserInfo.OptionsSelection.MultiSelect = true;
            this.grvUserInfo.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvUserInfo.OptionsView.ShowGroupPanel = false;
            this.grvUserInfo.OptionsView.ShowIndicator = false;
            this.grvUserInfo.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.grvUserInfo.DoubleClick += new System.EventHandler(this.grvUserInfo_DoubleClick);
            // 
            // hGridColumn1
            // 
            this.hGridColumn1.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn1.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn1.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn1.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn1.Caption = "사용자ID";
            this.hGridColumn1.FieldName = "userid";
            this.hGridColumn1.Name = "hGridColumn1";
            this.hGridColumn1.OptionsColumn.AllowEdit = false;
            this.hGridColumn1.OptionsColumn.FixedWidth = true;
            this.hGridColumn1.OptionsColumn.ReadOnly = true;
            this.hGridColumn1.Visible = true;
            this.hGridColumn1.VisibleIndex = 0;
            this.hGridColumn1.Width = 100;
            // 
            // hGridColumn2
            // 
            this.hGridColumn2.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn2.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn2.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn2.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn2.Caption = "사용자명";
            this.hGridColumn2.FieldName = "username";
            this.hGridColumn2.Name = "hGridColumn2";
            this.hGridColumn2.OptionsColumn.AllowEdit = false;
            this.hGridColumn2.OptionsColumn.ReadOnly = true;
            this.hGridColumn2.Visible = true;
            this.hGridColumn2.VisibleIndex = 1;
            this.hGridColumn2.Width = 269;
            // 
            // hGridColumn3
            // 
            this.hGridColumn3.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn3.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn3.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn3.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn3.Caption = "부서명";
            this.hGridColumn3.FieldName = "deptnm";
            this.hGridColumn3.Name = "hGridColumn3";
            this.hGridColumn3.OptionsColumn.AllowEdit = false;
            this.hGridColumn3.OptionsColumn.ReadOnly = true;
            this.hGridColumn3.Visible = true;
            this.hGridColumn3.VisibleIndex = 2;
            this.hGridColumn3.Width = 269;
            // 
            // hFlowLayoutPanel2
            // 
            this.hFlowLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hFlowLayoutPanel2.AutoSize = true;
            this.hFlowLayoutPanel2.Controls.Add(this.btnConfirm);
            this.hFlowLayoutPanel2.Controls.Add(this.btnClose);
            this.hFlowLayoutPanel2.Location = new System.Drawing.Point(164, 330);
            this.hFlowLayoutPanel2.Name = "hFlowLayoutPanel2";
            this.hFlowLayoutPanel2.Size = new System.Drawing.Size(162, 29);
            this.hFlowLayoutPanel2.TabIndex = 2;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnConfirm.Appearance.Options.UseForeColor = true;
            this.btnConfirm.Location = new System.Drawing.Point(3, 3);
            this.btnConfirm.LookAndFeel.SkinName = "My Basic";
            this.btnConfirm.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.SedasButtonType = Sedas.Control.HSedasSImpleButtonOrange.HSimpleButtonType.Null;
            this.btnConfirm.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnConfirm.Size = new System.Drawing.Size(75, 23);
            this.btnConfirm.TabIndex = 0;
            this.btnConfirm.Text = "확인";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // btnClose
            // 
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Location = new System.Drawing.Point(84, 3);
            this.btnClose.LookAndFeel.SkinName = "My Basic";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Name = "btnClose";
            this.btnClose.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnClose.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnClose.Size = new System.Drawing.Size(75, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "취소";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // UserSearchPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(490, 365);
            this.Controls.Add(this.tlpMain);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("UserSearchPopup.IconOptions.Image")));
            this.Name = "UserSearchPopup";
            this.Text = "직원조회";
            this.Load += new System.EventHandler(this.UserSearchPopup_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpMain.PerformLayout();
            this.tlpTop.ResumeLayout(false);
            this.hFlowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.cmbSearchType.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtSearch.Properties)).EndInit();
            this.tlpGrid.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdUserInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvUserInfo)).EndInit();
            this.hFlowLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Control.HTableLayoutPanel tlpMain;
        private Control.HTableLayoutPanel tlpTop;
        private Control.HFlowLayoutPanel hFlowLayoutPanel1;
        private Control.HTextEdit txtSearch;
        private Control.HSedasSImpleButtonBlue btnSearch;
        private Control.HImageComboBoxEdit cmbSearchType;
        private Control.HTableLayoutPanel tlpGrid;
        private Control.GridControl.HGridControl grdUserInfo;
        private Control.GridControl.HGridView grvUserInfo;
        private Control.GridControl.HGridColumn hGridColumn1;
        private Control.GridControl.HGridColumn hGridColumn2;
        private Control.GridControl.HGridColumn hGridColumn3;
        private Control.HFlowLayoutPanel hFlowLayoutPanel2;
        private Control.HSedasSImpleButtonOrange btnConfirm;
        private Control.HSedasSImpleButtonBlue btnClose;
    }
}