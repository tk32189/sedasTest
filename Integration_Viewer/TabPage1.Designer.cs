using DevExpress.XtraTreeList;
using System.Drawing;

namespace Integration_Viewer
{
    partial class TabPage1
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions2 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject5 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject6 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject7 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject8 = new DevExpress.Utils.SerializableAppearanceObject();
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.tlpAll = new Sedas.Control.HTableLayoutPanel(this.components);
            this.tlpLeft = new Sedas.Control.HTableLayoutPanel(this.components);
            this.tlpWorkList = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hTableLayoutPanel5 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hTableLayoutPanel6 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.accordionControl1 = new DevExpress.XtraBars.Navigation.AccordionControl();
            this.acodiContainerWorkList = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.tlpWorkListNew = new Sedas.Control.HTableLayoutPanel(this.components);
            this.grdWorkList = new Sedas.Control.GridControl.HGridControl(this.components);
            this.grvWorkList = new Sedas.Control.GridControl.HGridView();
            this.hGridColumn1 = new Sedas.Control.GridControl.HGridColumn();
            this.hGridColumn2 = new Sedas.Control.GridControl.HGridColumn();
            this.hGridColumn3 = new Sedas.Control.GridControl.HGridColumn();
            this.acodiContainerTreeList = new DevExpress.XtraBars.Navigation.AccordionContentContainer();
            this.tlpTreeListNew = new Sedas.Control.HTableLayoutPanel(this.components);
            this.treeList1 = new DevExpress.XtraTreeList.TreeList();
            this.acodiWorkList = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement2 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.acodiTreeList = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.accordionControlElement4 = new DevExpress.XtraBars.Navigation.AccordionControlElement();
            this.tlpSearch = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hTableLayoutPanel1 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hTableLayoutPanel8 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hFlowLayoutPanel6 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.hLabelControl1 = new Sedas.Control.HLabelControl(this.components);
            this.txtPtNo = new Sedas.Control.HTextEdit(this.components);
            this.hLabelControl2 = new Sedas.Control.HLabelControl(this.components);
            this.txtPtoNo = new Sedas.Control.HTextEdit(this.components);
            this.btnSearch = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.hFlowLayoutPanel4 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.hLabelControl3 = new Sedas.Control.HLabelControl(this.components);
            this.txtStartDt = new Sedas.Control.HDateEdit();
            this.hLabelControl4 = new Sedas.Control.HLabelControl(this.components);
            this.txtEndDt = new Sedas.Control.HDateEdit();
            this.hPanelControl1 = new Sedas.Control.HPanelControl(this.components);
            this.hTableLayoutPanel7 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hFlowLayoutPanel7 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.hSimpleButton1 = new Sedas.Control.HSimpleButton();
            this.hSimpleButton2 = new Sedas.Control.HSimpleButton();
            this.hSimpleButton3 = new Sedas.Control.HSimpleButton();
            this.hSimpleButton4 = new Sedas.Control.HSimpleButton();
            this.hSimpleButton5 = new Sedas.Control.HSimpleButton();
            this.tlpRight = new Sedas.Control.HTableLayoutPanel(this.components);
            this.tlpThumbnail = new Sedas.Control.HTableLayoutPanel(this.components);
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.flwpnlThumbNail = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.tlpViewer = new Sedas.Control.HTableLayoutPanel(this.components);
            this.tlpBottomButtons = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hFlowLayoutPanel1 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.btnFileOpen = new Sedas.Control.HSedasSImpleButtonGreen(this.components);
            this.hSedasSImpleButtonGreen3 = new Sedas.Control.HSedasSImpleButtonGreen(this.components);
            this.hSedasSImpleButtonGreen2 = new Sedas.Control.HSedasSImpleButtonGreen(this.components);
            this.hSedasSImpleButtonGreen1 = new Sedas.Control.HSedasSImpleButtonGreen(this.components);
            this.hSedasSImpleButtonGreen4 = new Sedas.Control.HSedasSImpleButtonGreen(this.components);
            this.hFlowLayoutPanel3 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.picPrint = new Sedas.Control.HPictureEdit(this.components);
            this.picDownload = new Sedas.Control.HPictureEdit(this.components);
            this.picSendEmail = new Sedas.Control.HPictureEdit(this.components);
            this.flyoutPanel1 = new DevExpress.Utils.FlyoutPanel();
            this.flyoutPanelControl1 = new DevExpress.Utils.FlyoutPanelControl();
            this.tlpPrintSet = new Sedas.Control.HTableLayoutPanel(this.components);
            this.btnPrintH = new Sedas.Control.HSedasSImpleButtonPurple(this.components);
            this.btnPrintV = new Sedas.Control.HSedasSImpleButtonPurple(this.components);
            this.tlpTopNew = new Sedas.Control.HTableLayoutPanel(this.components);
            this.btnWorkListClose = new Sedas.Control.HPictureEdit(this.components);
            this.hFlowLayoutPanel5 = new Sedas.Control.HFlowLayoutPanel(this.components);
            this.tlpMain.SuspendLayout();
            this.tlpAll.SuspendLayout();
            this.tlpLeft.SuspendLayout();
            this.tlpWorkList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).BeginInit();
            this.accordionControl1.SuspendLayout();
            this.acodiContainerWorkList.SuspendLayout();
            this.tlpWorkListNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWorkList)).BeginInit();
            this.acodiContainerTreeList.SuspendLayout();
            this.tlpTreeListNew.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).BeginInit();
            this.tlpSearch.SuspendLayout();
            this.hTableLayoutPanel1.SuspendLayout();
            this.hTableLayoutPanel8.SuspendLayout();
            this.hFlowLayoutPanel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPtNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPtoNo.Properties)).BeginInit();
            this.hFlowLayoutPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDt.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDt.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDt.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).BeginInit();
            this.hTableLayoutPanel7.SuspendLayout();
            this.hFlowLayoutPanel7.SuspendLayout();
            this.tlpRight.SuspendLayout();
            this.tlpThumbnail.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            this.tlpBottomButtons.SuspendLayout();
            this.hFlowLayoutPanel1.SuspendLayout();
            this.hFlowLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPrint.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDownload.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSendEmail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).BeginInit();
            this.flyoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).BeginInit();
            this.flyoutPanelControl1.SuspendLayout();
            this.tlpPrintSet.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnWorkListClose.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(22)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpAll, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tlpMain.Size = new System.Drawing.Size(1400, 800);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpAll
            // 
            this.tlpAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(22)))));
            this.tlpAll.ColumnCount = 3;
            this.tlpAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 350F));
            this.tlpAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 16F));
            this.tlpAll.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAll.Controls.Add(this.tlpLeft, 0, 0);
            this.tlpAll.Controls.Add(this.tlpRight, 2, 0);
            this.tlpAll.Controls.Add(this.btnWorkListClose, 1, 0);
            this.tlpAll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpAll.Location = new System.Drawing.Point(3, 3);
            this.tlpAll.Name = "tlpAll";
            this.tlpAll.RowCount = 1;
            this.tlpAll.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpAll.Size = new System.Drawing.Size(1394, 794);
            this.tlpAll.TabIndex = 0;
            // 
            // tlpLeft
            // 
            this.tlpLeft.ColumnCount = 1;
            this.tlpLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Controls.Add(this.tlpWorkList, 0, 1);
            this.tlpLeft.Controls.Add(this.tlpSearch, 0, 0);
            this.tlpLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpLeft.Location = new System.Drawing.Point(3, 3);
            this.tlpLeft.Margin = new System.Windows.Forms.Padding(3, 3, 0, 3);
            this.tlpLeft.Name = "tlpLeft";
            this.tlpLeft.RowCount = 2;
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 150F));
            this.tlpLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpLeft.Size = new System.Drawing.Size(347, 788);
            this.tlpLeft.TabIndex = 0;
            // 
            // tlpWorkList
            // 
            this.tlpWorkList.ColumnCount = 1;
            this.tlpWorkList.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpWorkList.Controls.Add(this.hTableLayoutPanel5, 0, 1);
            this.tlpWorkList.Controls.Add(this.hTableLayoutPanel6, 0, 3);
            this.tlpWorkList.Controls.Add(this.accordionControl1, 0, 2);
            this.tlpWorkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpWorkList.Location = new System.Drawing.Point(0, 150);
            this.tlpWorkList.Margin = new System.Windows.Forms.Padding(0);
            this.tlpWorkList.Name = "tlpWorkList";
            this.tlpWorkList.RowCount = 4;
            this.tlpWorkList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tlpWorkList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tlpWorkList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpWorkList.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tlpWorkList.Size = new System.Drawing.Size(347, 638);
            this.tlpWorkList.TabIndex = 0;
            // 
            // hTableLayoutPanel5
            // 
            this.hTableLayoutPanel5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.hTableLayoutPanel5.ColumnCount = 1;
            this.hTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel5.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.hTableLayoutPanel5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel5.Location = new System.Drawing.Point(3, 3);
            this.hTableLayoutPanel5.Name = "hTableLayoutPanel5";
            this.hTableLayoutPanel5.RowCount = 1;
            this.hTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel5.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.hTableLayoutPanel5.Size = new System.Drawing.Size(341, 1);
            this.hTableLayoutPanel5.TabIndex = 2;
            // 
            // hTableLayoutPanel6
            // 
            this.hTableLayoutPanel6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.hTableLayoutPanel6.ColumnCount = 1;
            this.hTableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel6.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.hTableLayoutPanel6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel6.Location = new System.Drawing.Point(3, 641);
            this.hTableLayoutPanel6.Name = "hTableLayoutPanel6";
            this.hTableLayoutPanel6.RowCount = 1;
            this.hTableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel6.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 1F));
            this.hTableLayoutPanel6.Size = new System.Drawing.Size(341, 1);
            this.hTableLayoutPanel6.TabIndex = 3;
            // 
            // accordionControl1
            // 
            this.accordionControl1.Appearance.AccordionControl.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(17)))), ((int)(((byte)(17)))), ((int)(((byte)(22)))));
            this.accordionControl1.Appearance.AccordionControl.Options.UseBackColor = true;
            this.accordionControl1.Controls.Add(this.acodiContainerWorkList);
            this.accordionControl1.Controls.Add(this.acodiContainerTreeList);
            this.accordionControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.accordionControl1.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.acodiWorkList,
            this.acodiTreeList});
            this.accordionControl1.Location = new System.Drawing.Point(3, 3);
            this.accordionControl1.Name = "accordionControl1";
            this.accordionControl1.ScrollBarMode = DevExpress.XtraBars.Navigation.ScrollBarMode.Fluent;
            this.accordionControl1.ShowGroupExpandButtons = false;
            this.accordionControl1.Size = new System.Drawing.Size(341, 632);
            this.accordionControl1.TabIndex = 5;
            this.accordionControl1.Text = "accordionControl1";
            this.accordionControl1.SizeChanged += new System.EventHandler(this.accordionControl1_SizeChanged);
            // 
            // acodiContainerWorkList
            // 
            this.acodiContainerWorkList.Controls.Add(this.tlpWorkListNew);
            this.acodiContainerWorkList.Name = "acodiContainerWorkList";
            this.acodiContainerWorkList.Size = new System.Drawing.Size(324, 300);
            this.acodiContainerWorkList.TabIndex = 3;
            // 
            // tlpWorkListNew
            // 
            this.tlpWorkListNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(47)))), ((int)(((byte)(67)))));
            this.tlpWorkListNew.ColumnCount = 1;
            this.tlpWorkListNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpWorkListNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpWorkListNew.Controls.Add(this.grdWorkList, 0, 0);
            this.tlpWorkListNew.Location = new System.Drawing.Point(0, 3);
            this.tlpWorkListNew.Name = "tlpWorkListNew";
            this.tlpWorkListNew.RowCount = 1;
            this.tlpWorkListNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpWorkListNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpWorkListNew.Size = new System.Drawing.Size(335, 300);
            this.tlpWorkListNew.TabIndex = 0;
            // 
            // grdWorkList
            // 
            this.grdWorkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdWorkList.Location = new System.Drawing.Point(3, 3);
            this.grdWorkList.MainView = this.grvWorkList;
            this.grdWorkList.Name = "grdWorkList";
            this.grdWorkList.Size = new System.Drawing.Size(329, 294);
            this.grdWorkList.TabIndex = 0;
            this.grdWorkList.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvWorkList});
            // 
            // grvWorkList
            // 
            this.grvWorkList.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvWorkList.Appearance.Empty.Options.UseBackColor = true;
            this.grvWorkList.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvWorkList.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvWorkList.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvWorkList.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvWorkList.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.grvWorkList.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvWorkList.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvWorkList.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvWorkList.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvWorkList.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvWorkList.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvWorkList.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvWorkList.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvWorkList.Appearance.Row.Options.UseBackColor = true;
            this.grvWorkList.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvWorkList.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvWorkList.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvWorkList.Appearance.VertLine.Options.UseBackColor = true;
            this.grvWorkList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.grvWorkList.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.hGridColumn1,
            this.hGridColumn2,
            this.hGridColumn3});
            this.grvWorkList.DetailHeight = 300;
            this.grvWorkList.GridControl = this.grdWorkList;
            this.grvWorkList.IsSedasDefaultGrid = true;
            this.grvWorkList.Name = "grvWorkList";
            this.grvWorkList.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.False;
            this.grvWorkList.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.False;
            this.grvWorkList.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.grvWorkList.OptionsCustomization.AllowColumnMoving = false;
            this.grvWorkList.OptionsCustomization.AllowFilter = false;
            this.grvWorkList.OptionsCustomization.AllowSort = false;
            this.grvWorkList.OptionsFind.AllowFindPanel = false;
            this.grvWorkList.OptionsMenu.EnableColumnMenu = false;
            this.grvWorkList.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvWorkList.OptionsView.ShowGroupPanel = false;
            this.grvWorkList.OptionsView.ShowIndicator = false;
            this.grvWorkList.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.grvWorkList.DoubleClick += new System.EventHandler(this.grvWorkList_DoubleClick);
            // 
            // hGridColumn1
            // 
            this.hGridColumn1.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn1.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn1.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn1.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn1.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn1.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn1.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.hGridColumn1.Caption = "병리번호";
            this.hGridColumn1.FieldName = "ptoNo";
            this.hGridColumn1.Name = "hGridColumn1";
            this.hGridColumn1.OptionsColumn.AllowEdit = false;
            this.hGridColumn1.OptionsColumn.ReadOnly = true;
            this.hGridColumn1.Visible = true;
            this.hGridColumn1.VisibleIndex = 0;
            // 
            // hGridColumn2
            // 
            this.hGridColumn2.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn2.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn2.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn2.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn2.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn2.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn2.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.hGridColumn2.Caption = "환자번호";
            this.hGridColumn2.FieldName = "ptNo";
            this.hGridColumn2.Name = "hGridColumn2";
            this.hGridColumn2.OptionsColumn.AllowEdit = false;
            this.hGridColumn2.OptionsColumn.ReadOnly = true;
            this.hGridColumn2.Visible = true;
            this.hGridColumn2.VisibleIndex = 1;
            // 
            // hGridColumn3
            // 
            this.hGridColumn3.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.hGridColumn3.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.hGridColumn3.AppearanceHeader.Options.UseBackColor = true;
            this.hGridColumn3.AppearanceHeader.Options.UseForeColor = true;
            this.hGridColumn3.AppearanceHeader.Options.UseTextOptions = true;
            this.hGridColumn3.AppearanceHeader.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.hGridColumn3.AppearanceHeader.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.hGridColumn3.Caption = "이름";
            this.hGridColumn3.FieldName = "ptNm";
            this.hGridColumn3.Name = "hGridColumn3";
            this.hGridColumn3.OptionsColumn.AllowEdit = false;
            this.hGridColumn3.OptionsColumn.ReadOnly = true;
            this.hGridColumn3.Visible = true;
            this.hGridColumn3.VisibleIndex = 2;
            // 
            // acodiContainerTreeList
            // 
            this.acodiContainerTreeList.Controls.Add(this.tlpTreeListNew);
            this.acodiContainerTreeList.Name = "acodiContainerTreeList";
            this.acodiContainerTreeList.Size = new System.Drawing.Size(324, 200);
            this.acodiContainerTreeList.TabIndex = 5;
            // 
            // tlpTreeListNew
            // 
            this.tlpTreeListNew.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(47)))), ((int)(((byte)(67)))));
            this.tlpTreeListNew.ColumnCount = 1;
            this.tlpTreeListNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTreeListNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTreeListNew.Controls.Add(this.treeList1, 0, 0);
            this.tlpTreeListNew.Location = new System.Drawing.Point(0, 3);
            this.tlpTreeListNew.Name = "tlpTreeListNew";
            this.tlpTreeListNew.RowCount = 1;
            this.tlpTreeListNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTreeListNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpTreeListNew.Size = new System.Drawing.Size(335, 200);
            this.tlpTreeListNew.TabIndex = 0;
            // 
            // treeList1
            // 
            this.treeList1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(47)))), ((int)(((byte)(67)))));
            this.treeList1.Appearance.Empty.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.treeList1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.treeList1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.treeList1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.treeList1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(47)))), ((int)(((byte)(67)))));
            this.treeList1.Appearance.Row.Options.UseBackColor = true;
            this.treeList1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.treeList1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.treeList1.CheckBoxFieldName = "Checked";
            this.treeList1.CustomizationFormBounds = new System.Drawing.Rectangle(342, 343, 260, 222);
            this.treeList1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeList1.FixedLineWidth = 4;
            this.treeList1.HorzScrollStep = 6;
            this.treeList1.IndicatorWidth = 20;
            this.treeList1.Location = new System.Drawing.Point(3, 3);
            this.treeList1.Name = "treeList1";
            this.treeList1.OptionsBehavior.AllowRecursiveNodeChecking = true;
            this.treeList1.OptionsBehavior.Editable = false;
            this.treeList1.OptionsBehavior.ReadOnly = true;
            this.treeList1.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.treeList1.OptionsView.ShowColumns = false;
            this.treeList1.Size = new System.Drawing.Size(329, 194);
            this.treeList1.TabIndex = 0;
            this.treeList1.TreeLevelWidth = 36;
            this.treeList1.TreeViewFieldName = "Name";
            this.treeList1.AfterCheckNode += new DevExpress.XtraTreeList.NodeEventHandler(this.treeList1_AfterCheckNode);
            this.treeList1.FocusedNodeChanged += new DevExpress.XtraTreeList.FocusedNodeChangedEventHandler(this.treeList1_FocusedNodeChanged);
            this.treeList1.CustomDrawNodeCell += new DevExpress.XtraTreeList.CustomDrawNodeCellEventHandler(this.treeList1_CustomDrawNodeCell);
            // 
            // acodiWorkList
            // 
            this.acodiWorkList.Appearance.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(48)))), ((int)(((byte)(206)))));
            this.acodiWorkList.Appearance.Hovered.Options.UseBackColor = true;
            this.acodiWorkList.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(48)))), ((int)(((byte)(206)))));
            this.acodiWorkList.Appearance.Normal.Options.UseBackColor = true;
            this.acodiWorkList.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement2});
            this.acodiWorkList.Expanded = true;
            this.acodiWorkList.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image, DevExpress.XtraBars.Navigation.HeaderElementAlignment.Right),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons)});
            this.acodiWorkList.Height = 25;
            this.acodiWorkList.ImageOptions.Image = global::Integration_Viewer.Properties.Resources.zoonin;
            this.acodiWorkList.Name = "acodiWorkList";
            this.acodiWorkList.Text = "WorkList";
            this.acodiWorkList.Click += new System.EventHandler(this.acodiWorkList_Click);
            // 
            // accordionControlElement2
            // 
            this.accordionControlElement2.ContentContainer = this.acodiContainerWorkList;
            this.accordionControlElement2.Expanded = true;
            this.accordionControlElement2.HeaderVisible = false;
            this.accordionControlElement2.Name = "accordionControlElement2";
            this.accordionControlElement2.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement2.Text = "Element2";
            // 
            // acodiTreeList
            // 
            this.acodiTreeList.Appearance.Hovered.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(217)))));
            this.acodiTreeList.Appearance.Hovered.Options.UseBackColor = true;
            this.acodiTreeList.Appearance.Normal.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(116)))), ((int)(((byte)(217)))));
            this.acodiTreeList.Appearance.Normal.Options.UseBackColor = true;
            this.acodiTreeList.Elements.AddRange(new DevExpress.XtraBars.Navigation.AccordionControlElement[] {
            this.accordionControlElement4});
            this.acodiTreeList.Expanded = true;
            this.acodiTreeList.HeaderTemplate.AddRange(new DevExpress.XtraBars.Navigation.HeaderElementInfo[] {
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Text),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.HeaderControl),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.ContextButtons),
            new DevExpress.XtraBars.Navigation.HeaderElementInfo(DevExpress.XtraBars.Navigation.HeaderElementType.Image, DevExpress.XtraBars.Navigation.HeaderElementAlignment.Right)});
            this.acodiTreeList.Height = 25;
            this.acodiTreeList.ImageOptions.Image = global::Integration_Viewer.Properties.Resources.zoonin;
            this.acodiTreeList.Name = "acodiTreeList";
            this.acodiTreeList.Text = "파일 상세";
            this.acodiTreeList.Click += new System.EventHandler(this.acodiTreeList_Click);
            // 
            // accordionControlElement4
            // 
            this.accordionControlElement4.ContentContainer = this.acodiContainerTreeList;
            this.accordionControlElement4.Expanded = true;
            this.accordionControlElement4.HeaderVisible = false;
            this.accordionControlElement4.Name = "accordionControlElement4";
            this.accordionControlElement4.Style = DevExpress.XtraBars.Navigation.ElementStyle.Item;
            this.accordionControlElement4.Text = "Element4";
            // 
            // tlpSearch
            // 
            this.tlpSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(47)))), ((int)(((byte)(67)))));
            this.tlpSearch.ColumnCount = 1;
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpSearch.Controls.Add(this.hTableLayoutPanel1, 0, 0);
            this.tlpSearch.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpSearch.Location = new System.Drawing.Point(3, 3);
            this.tlpSearch.Name = "tlpSearch";
            this.tlpSearch.RowCount = 1;
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpSearch.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 145F));
            this.tlpSearch.Size = new System.Drawing.Size(341, 144);
            this.tlpSearch.TabIndex = 1;
            // 
            // hTableLayoutPanel1
            // 
            this.hTableLayoutPanel1.ColumnCount = 1;
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.Controls.Add(this.hTableLayoutPanel8, 0, 3);
            this.hTableLayoutPanel1.Controls.Add(this.hPanelControl1, 0, 4);
            this.hTableLayoutPanel1.Controls.Add(this.hTableLayoutPanel7, 0, 5);
            this.hTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.hTableLayoutPanel1.Margin = new System.Windows.Forms.Padding(0);
            this.hTableLayoutPanel1.Name = "hTableLayoutPanel1";
            this.hTableLayoutPanel1.RowCount = 6;
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 10F));
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.hTableLayoutPanel1.Size = new System.Drawing.Size(341, 144);
            this.hTableLayoutPanel1.TabIndex = 0;
            // 
            // hTableLayoutPanel8
            // 
            this.hTableLayoutPanel8.ColumnCount = 2;
            this.hTableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel8.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.hTableLayoutPanel8.Controls.Add(this.hFlowLayoutPanel6, 0, 0);
            this.hTableLayoutPanel8.Controls.Add(this.btnSearch, 1, 0);
            this.hTableLayoutPanel8.Controls.Add(this.hFlowLayoutPanel4, 0, 1);
            this.hTableLayoutPanel8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel8.Location = new System.Drawing.Point(0, 0);
            this.hTableLayoutPanel8.Margin = new System.Windows.Forms.Padding(0);
            this.hTableLayoutPanel8.Name = "hTableLayoutPanel8";
            this.hTableLayoutPanel8.RowCount = 2;
            this.hTableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hTableLayoutPanel8.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.hTableLayoutPanel8.Size = new System.Drawing.Size(341, 94);
            this.hTableLayoutPanel8.TabIndex = 3;
            // 
            // hFlowLayoutPanel6
            // 
            this.hFlowLayoutPanel6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hFlowLayoutPanel6.AutoSize = true;
            this.hFlowLayoutPanel6.Controls.Add(this.hLabelControl1);
            this.hFlowLayoutPanel6.Controls.Add(this.txtPtNo);
            this.hFlowLayoutPanel6.Controls.Add(this.hLabelControl2);
            this.hFlowLayoutPanel6.Controls.Add(this.txtPtoNo);
            this.hFlowLayoutPanel6.Location = new System.Drawing.Point(3, 8);
            this.hFlowLayoutPanel6.Name = "hFlowLayoutPanel6";
            this.hFlowLayoutPanel6.Size = new System.Drawing.Size(272, 30);
            this.hFlowLayoutPanel6.TabIndex = 0;
            // 
            // hLabelControl1
            // 
            this.hLabelControl1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.hLabelControl1.Appearance.Font = new System.Drawing.Font("Noto Sans KR Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.hLabelControl1.Appearance.Options.UseFont = true;
            this.hLabelControl1.Location = new System.Drawing.Point(3, 5);
            this.hLabelControl1.Name = "hLabelControl1";
            this.hLabelControl1.Size = new System.Drawing.Size(48, 19);
            this.hLabelControl1.TabIndex = 1;
            this.hLabelControl1.Text = "등록번호";
            // 
            // txtPtNo
            // 
            this.txtPtNo.Location = new System.Drawing.Point(57, 3);
            this.txtPtNo.Name = "txtPtNo";
            this.txtPtNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtPtNo.Properties.Appearance.Font = new System.Drawing.Font("Noto Sans KR Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPtNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtPtNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtPtNo.Properties.Appearance.Options.UseFont = true;
            this.txtPtNo.Properties.Appearance.Options.UseForeColor = true;
            this.txtPtNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtPtNo.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtPtNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPtNo.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtPtNo.Size = new System.Drawing.Size(76, 24);
            this.txtPtNo.TabIndex = 2;
            this.txtPtNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPtNo_KeyDown);
            // 
            // hLabelControl2
            // 
            this.hLabelControl2.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.hLabelControl2.Appearance.Font = new System.Drawing.Font("Noto Sans KR Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.hLabelControl2.Appearance.Options.UseFont = true;
            this.hLabelControl2.Location = new System.Drawing.Point(139, 5);
            this.hLabelControl2.Name = "hLabelControl2";
            this.hLabelControl2.Size = new System.Drawing.Size(48, 19);
            this.hLabelControl2.TabIndex = 3;
            this.hLabelControl2.Text = "병리번호";
            // 
            // txtPtoNo
            // 
            this.txtPtoNo.Location = new System.Drawing.Point(193, 3);
            this.txtPtoNo.Name = "txtPtoNo";
            this.txtPtoNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtPtoNo.Properties.Appearance.Font = new System.Drawing.Font("Noto Sans KR Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtPtoNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtPtoNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtPtoNo.Properties.Appearance.Options.UseFont = true;
            this.txtPtoNo.Properties.Appearance.Options.UseForeColor = true;
            this.txtPtoNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtPtoNo.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtPtoNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPtoNo.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtPtoNo.Size = new System.Drawing.Size(76, 24);
            this.txtPtoNo.TabIndex = 4;
            this.txtPtoNo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPtoNo_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnSearch.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSearch.Appearance.Options.UseForeColor = true;
            this.btnSearch.Location = new System.Drawing.Point(286, 14);
            this.btnSearch.LookAndFeel.SkinName = "My Basic";
            this.btnSearch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSearch.Name = "btnSearch";
            this.hTableLayoutPanel8.SetRowSpan(this.btnSearch, 2);
            this.btnSearch.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnSearch.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnSearch.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.btnSearch.Size = new System.Drawing.Size(52, 66);
            this.btnSearch.TabIndex = 1;
            this.btnSearch.Text = "조회";
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // hFlowLayoutPanel4
            // 
            this.hFlowLayoutPanel4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hFlowLayoutPanel4.AutoSize = true;
            this.hFlowLayoutPanel4.Controls.Add(this.hLabelControl3);
            this.hFlowLayoutPanel4.Controls.Add(this.txtStartDt);
            this.hFlowLayoutPanel4.Controls.Add(this.hLabelControl4);
            this.hFlowLayoutPanel4.Controls.Add(this.txtEndDt);
            this.hFlowLayoutPanel4.Location = new System.Drawing.Point(3, 54);
            this.hFlowLayoutPanel4.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.hFlowLayoutPanel4.Name = "hFlowLayoutPanel4";
            this.hFlowLayoutPanel4.Size = new System.Drawing.Size(247, 32);
            this.hFlowLayoutPanel4.TabIndex = 1;
            // 
            // hLabelControl3
            // 
            this.hLabelControl3.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.hLabelControl3.Appearance.Font = new System.Drawing.Font("Noto Sans KR Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.hLabelControl3.Appearance.Options.UseFont = true;
            this.hLabelControl3.Location = new System.Drawing.Point(3, 6);
            this.hLabelControl3.Name = "hLabelControl3";
            this.hLabelControl3.Size = new System.Drawing.Size(24, 19);
            this.hLabelControl3.TabIndex = 3;
            this.hLabelControl3.Text = "기간";
            // 
            // txtStartDt
            // 
            this.txtStartDt.EditValue = null;
            this.txtStartDt.Location = new System.Drawing.Point(33, 3);
            this.txtStartDt.Name = "txtStartDt";
            this.txtStartDt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtStartDt.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.txtStartDt.Properties.Appearance.Font = new System.Drawing.Font("Noto Sans KR Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtStartDt.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtStartDt.Properties.Appearance.Options.UseBackColor = true;
            this.txtStartDt.Properties.Appearance.Options.UseBorderColor = true;
            this.txtStartDt.Properties.Appearance.Options.UseFont = true;
            this.txtStartDt.Properties.Appearance.Options.UseForeColor = true;
            this.txtStartDt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
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
            this.txtStartDt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtStartDt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.txtStartDt.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtStartDt.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtStartDt.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtStartDt.Size = new System.Drawing.Size(95, 26);
            this.txtStartDt.TabIndex = 0;
            // 
            // hLabelControl4
            // 
            this.hLabelControl4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hLabelControl4.Location = new System.Drawing.Point(134, 10);
            this.hLabelControl4.Name = "hLabelControl4";
            this.hLabelControl4.Size = new System.Drawing.Size(9, 12);
            this.hLabelControl4.TabIndex = 2;
            this.hLabelControl4.Text = "~";
            // 
            // txtEndDt
            // 
            this.txtEndDt.EditValue = null;
            this.txtEndDt.Location = new System.Drawing.Point(149, 3);
            this.txtEndDt.Name = "txtEndDt";
            this.txtEndDt.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtEndDt.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.txtEndDt.Properties.Appearance.Font = new System.Drawing.Font("Noto Sans KR Regular", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.txtEndDt.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtEndDt.Properties.Appearance.Options.UseBackColor = true;
            this.txtEndDt.Properties.Appearance.Options.UseBorderColor = true;
            this.txtEndDt.Properties.Appearance.Options.UseFont = true;
            this.txtEndDt.Properties.Appearance.Options.UseForeColor = true;
            this.txtEndDt.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            serializableAppearanceObject5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            serializableAppearanceObject5.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            serializableAppearanceObject5.Options.UseBackColor = true;
            serializableAppearanceObject5.Options.UseBorderColor = true;
            serializableAppearanceObject6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            serializableAppearanceObject6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            serializableAppearanceObject6.Options.UseBackColor = true;
            serializableAppearanceObject6.Options.UseBorderColor = true;
            serializableAppearanceObject7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            serializableAppearanceObject7.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            serializableAppearanceObject7.Options.UseBackColor = true;
            serializableAppearanceObject7.Options.UseBorderColor = true;
            this.txtEndDt.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.txtEndDt.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.txtEndDt.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.txtEndDt.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtEndDt.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtEndDt.Size = new System.Drawing.Size(95, 26);
            this.txtEndDt.TabIndex = 1;
            // 
            // hPanelControl1
            // 
            this.hPanelControl1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hPanelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(84)))), ((int)(((byte)(136)))));
            this.hPanelControl1.Appearance.Options.UseBackColor = true;
            this.hPanelControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.hPanelControl1.Location = new System.Drawing.Point(5, 98);
            this.hPanelControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.hPanelControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.hPanelControl1.Name = "hPanelControl1";
            this.hPanelControl1.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.hPanelControl1.Size = new System.Drawing.Size(330, 1);
            this.hPanelControl1.TabIndex = 4;
            // 
            // hTableLayoutPanel7
            // 
            this.hTableLayoutPanel7.ColumnCount = 1;
            this.hTableLayoutPanel7.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel7.Controls.Add(this.hFlowLayoutPanel7, 0, 1);
            this.hTableLayoutPanel7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel7.Location = new System.Drawing.Point(0, 104);
            this.hTableLayoutPanel7.Margin = new System.Windows.Forms.Padding(0);
            this.hTableLayoutPanel7.Name = "hTableLayoutPanel7";
            this.hTableLayoutPanel7.RowCount = 2;
            this.hTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.hTableLayoutPanel7.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel7.Size = new System.Drawing.Size(341, 40);
            this.hTableLayoutPanel7.TabIndex = 5;
            // 
            // hFlowLayoutPanel7
            // 
            this.hFlowLayoutPanel7.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.hFlowLayoutPanel7.AutoSize = true;
            this.hFlowLayoutPanel7.Controls.Add(this.hSimpleButton1);
            this.hFlowLayoutPanel7.Controls.Add(this.hSimpleButton2);
            this.hFlowLayoutPanel7.Controls.Add(this.hSimpleButton3);
            this.hFlowLayoutPanel7.Controls.Add(this.hSimpleButton4);
            this.hFlowLayoutPanel7.Controls.Add(this.hSimpleButton5);
            this.hFlowLayoutPanel7.Location = new System.Drawing.Point(20, 5);
            this.hFlowLayoutPanel7.Name = "hFlowLayoutPanel7";
            this.hFlowLayoutPanel7.Size = new System.Drawing.Size(300, 29);
            this.hFlowLayoutPanel7.TabIndex = 1;
            // 
            // hSimpleButton1
            // 
            this.hSimpleButton1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hSimpleButton1.Appearance.Options.UseBackColor = true;
            this.hSimpleButton1.Location = new System.Drawing.Point(3, 3);
            this.hSimpleButton1.Name = "hSimpleButton1";
            this.hSimpleButton1.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.hSimpleButton1.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSimpleButton1.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.hSimpleButton1.Size = new System.Drawing.Size(51, 23);
            this.hSimpleButton1.TabIndex = 0;
            this.hSimpleButton1.Text = "1Y";
            this.hSimpleButton1.Click += new System.EventHandler(this.btnPeriod_Click);
            this.hSimpleButton1.Paint += new System.Windows.Forms.PaintEventHandler(this.FlatButton_Paint);
            this.hSimpleButton1.MouseEnter += new System.EventHandler(this.FlatButton_MouseEnter);
            this.hSimpleButton1.MouseLeave += new System.EventHandler(this.FlatButton_MouseLeave);
            // 
            // hSimpleButton2
            // 
            this.hSimpleButton2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hSimpleButton2.Appearance.Options.UseBackColor = true;
            this.hSimpleButton2.Location = new System.Drawing.Point(60, 3);
            this.hSimpleButton2.Name = "hSimpleButton2";
            this.hSimpleButton2.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.hSimpleButton2.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSimpleButton2.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.hSimpleButton2.Size = new System.Drawing.Size(51, 23);
            this.hSimpleButton2.TabIndex = 1;
            this.hSimpleButton2.Text = "3Y";
            this.hSimpleButton2.Click += new System.EventHandler(this.btnPeriod_Click);
            this.hSimpleButton2.Paint += new System.Windows.Forms.PaintEventHandler(this.FlatButton_Paint);
            this.hSimpleButton2.MouseEnter += new System.EventHandler(this.FlatButton_MouseEnter);
            this.hSimpleButton2.MouseLeave += new System.EventHandler(this.FlatButton_MouseLeave);
            // 
            // hSimpleButton3
            // 
            this.hSimpleButton3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hSimpleButton3.Appearance.Options.UseBackColor = true;
            this.hSimpleButton3.Location = new System.Drawing.Point(117, 3);
            this.hSimpleButton3.Name = "hSimpleButton3";
            this.hSimpleButton3.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.hSimpleButton3.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSimpleButton3.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.hSimpleButton3.Size = new System.Drawing.Size(51, 23);
            this.hSimpleButton3.TabIndex = 2;
            this.hSimpleButton3.Text = "5Y";
            this.hSimpleButton3.Click += new System.EventHandler(this.btnPeriod_Click);
            this.hSimpleButton3.Paint += new System.Windows.Forms.PaintEventHandler(this.FlatButton_Paint);
            this.hSimpleButton3.MouseEnter += new System.EventHandler(this.FlatButton_MouseEnter);
            this.hSimpleButton3.MouseLeave += new System.EventHandler(this.FlatButton_MouseLeave);
            // 
            // hSimpleButton4
            // 
            this.hSimpleButton4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hSimpleButton4.Appearance.Options.UseBackColor = true;
            this.hSimpleButton4.Location = new System.Drawing.Point(174, 3);
            this.hSimpleButton4.Name = "hSimpleButton4";
            this.hSimpleButton4.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.hSimpleButton4.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSimpleButton4.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.hSimpleButton4.Size = new System.Drawing.Size(51, 23);
            this.hSimpleButton4.TabIndex = 3;
            this.hSimpleButton4.Text = "10Y";
            this.hSimpleButton4.Click += new System.EventHandler(this.btnPeriod_Click);
            this.hSimpleButton4.Paint += new System.Windows.Forms.PaintEventHandler(this.FlatButton_Paint);
            this.hSimpleButton4.MouseEnter += new System.EventHandler(this.FlatButton_MouseEnter);
            this.hSimpleButton4.MouseLeave += new System.EventHandler(this.FlatButton_MouseLeave);
            // 
            // hSimpleButton5
            // 
            this.hSimpleButton5.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.hSimpleButton5.Appearance.Options.UseBackColor = true;
            this.hSimpleButton5.Location = new System.Drawing.Point(231, 3);
            this.hSimpleButton5.Name = "hSimpleButton5";
            this.hSimpleButton5.PaintStyle = DevExpress.XtraEditors.Controls.PaintStyles.Light;
            this.hSimpleButton5.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSimpleButton5.ShowFocusRectangle = DevExpress.Utils.DefaultBoolean.False;
            this.hSimpleButton5.Size = new System.Drawing.Size(66, 23);
            this.hSimpleButton5.TabIndex = 4;
            this.hSimpleButton5.Text = "개원부터";
            this.hSimpleButton5.Click += new System.EventHandler(this.btnPeriod_Click);
            this.hSimpleButton5.Paint += new System.Windows.Forms.PaintEventHandler(this.FlatButton_Paint);
            this.hSimpleButton5.MouseEnter += new System.EventHandler(this.FlatButton_MouseEnter);
            this.hSimpleButton5.MouseLeave += new System.EventHandler(this.FlatButton_MouseLeave);
            // 
            // tlpRight
            // 
            this.tlpRight.ColumnCount = 1;
            this.tlpRight.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.Controls.Add(this.tlpThumbnail, 0, 4);
            this.tlpRight.Controls.Add(this.tlpViewer, 0, 2);
            this.tlpRight.Controls.Add(this.tlpBottomButtons, 0, 3);
            this.tlpRight.Controls.Add(this.tlpTopNew, 0, 1);
            this.tlpRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpRight.Location = new System.Drawing.Point(369, 3);
            this.tlpRight.Name = "tlpRight";
            this.tlpRight.RowCount = 5;
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 65F));
            this.tlpRight.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 178F));
            this.tlpRight.Size = new System.Drawing.Size(1022, 788);
            this.tlpRight.TabIndex = 1;
            // 
            // tlpThumbnail
            // 
            this.tlpThumbnail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.tlpThumbnail.ColumnCount = 1;
            this.tlpThumbnail.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpThumbnail.Controls.Add(this.xtraScrollableControl1, 0, 0);
            this.tlpThumbnail.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpThumbnail.Location = new System.Drawing.Point(3, 613);
            this.tlpThumbnail.Name = "tlpThumbnail";
            this.tlpThumbnail.RowCount = 1;
            this.tlpThumbnail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpThumbnail.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 173F));
            this.tlpThumbnail.Size = new System.Drawing.Size(1016, 172);
            this.tlpThumbnail.TabIndex = 4;
            this.tlpThumbnail.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpThumbnail_Paint);
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.xtraScrollableControl1.Appearance.Options.UseBackColor = true;
            this.xtraScrollableControl1.Controls.Add(this.flwpnlThumbNail);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(3, 3);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(1010, 166);
            this.xtraScrollableControl1.TabIndex = 1;
            this.xtraScrollableControl1.Scroll += new DevExpress.XtraEditors.XtraScrollEventHandler(this.xtraScrollableControl1_Scroll);
            // 
            // flwpnlThumbNail
            // 
            this.flwpnlThumbNail.AllowDrop = true;
            this.flwpnlThumbNail.AutoSize = true;
            this.flwpnlThumbNail.Location = new System.Drawing.Point(3, 3);
            this.flwpnlThumbNail.Name = "flwpnlThumbNail";
            this.flwpnlThumbNail.Size = new System.Drawing.Size(1067, 143);
            this.flwpnlThumbNail.TabIndex = 0;
            this.flwpnlThumbNail.WrapContents = false;
            // 
            // tlpViewer
            // 
            this.tlpViewer.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.tlpViewer.ColumnCount = 2;
            this.tlpViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpViewer.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpViewer.Location = new System.Drawing.Point(3, 93);
            this.tlpViewer.Name = "tlpViewer";
            this.tlpViewer.RowCount = 1;
            this.tlpViewer.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpViewer.Size = new System.Drawing.Size(1016, 449);
            this.tlpViewer.TabIndex = 5;
            this.tlpViewer.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpViewer_Paint);
            // 
            // tlpBottomButtons
            // 
            this.tlpBottomButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.tlpBottomButtons.ColumnCount = 2;
            this.tlpBottomButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottomButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpBottomButtons.Controls.Add(this.hFlowLayoutPanel1, 1, 0);
            this.tlpBottomButtons.Controls.Add(this.hFlowLayoutPanel3, 0, 0);
            this.tlpBottomButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottomButtons.Location = new System.Drawing.Point(3, 548);
            this.tlpBottomButtons.Name = "tlpBottomButtons";
            this.tlpBottomButtons.RowCount = 1;
            this.tlpBottomButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottomButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpBottomButtons.Size = new System.Drawing.Size(1016, 59);
            this.tlpBottomButtons.TabIndex = 7;
            this.tlpBottomButtons.Paint += new System.Windows.Forms.PaintEventHandler(this.tlpBottomButtons_Paint);
            // 
            // hFlowLayoutPanel1
            // 
            this.hFlowLayoutPanel1.BackColor = System.Drawing.Color.Transparent;
            this.hFlowLayoutPanel1.Controls.Add(this.btnFileOpen);
            this.hFlowLayoutPanel1.Controls.Add(this.hSedasSImpleButtonGreen3);
            this.hFlowLayoutPanel1.Controls.Add(this.hSedasSImpleButtonGreen2);
            this.hFlowLayoutPanel1.Controls.Add(this.hSedasSImpleButtonGreen1);
            this.hFlowLayoutPanel1.Controls.Add(this.hSedasSImpleButtonGreen4);
            this.hFlowLayoutPanel1.Location = new System.Drawing.Point(511, 3);
            this.hFlowLayoutPanel1.Name = "hFlowLayoutPanel1";
            this.hFlowLayoutPanel1.Size = new System.Drawing.Size(425, 53);
            this.hFlowLayoutPanel1.TabIndex = 0;
            // 
            // btnFileOpen
            // 
            this.btnFileOpen.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnFileOpen.Appearance.Options.UseForeColor = true;
            this.btnFileOpen.Location = new System.Drawing.Point(3, 3);
            this.btnFileOpen.LookAndFeel.SkinName = "My Basic";
            this.btnFileOpen.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFileOpen.Name = "btnFileOpen";
            this.btnFileOpen.SedasButtonType = Sedas.Control.HSedasSImpleButtonGreen.HSimpleButtonType.Null;
            this.btnFileOpen.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnFileOpen.Size = new System.Drawing.Size(75, 20);
            this.btnFileOpen.TabIndex = 1;
            this.btnFileOpen.Text = "파일열기";
            this.btnFileOpen.Click += new System.EventHandler(this.btnFileOpen_Click);
            // 
            // hSedasSImpleButtonGreen3
            // 
            this.hSedasSImpleButtonGreen3.Appearance.ForeColor = System.Drawing.Color.White;
            this.hSedasSImpleButtonGreen3.Appearance.Options.UseForeColor = true;
            this.hSedasSImpleButtonGreen3.Location = new System.Drawing.Point(84, 3);
            this.hSedasSImpleButtonGreen3.LookAndFeel.SkinName = "My Basic";
            this.hSedasSImpleButtonGreen3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.hSedasSImpleButtonGreen3.Name = "hSedasSImpleButtonGreen3";
            this.hSedasSImpleButtonGreen3.SedasButtonType = Sedas.Control.HSedasSImpleButtonGreen.HSimpleButtonType.Null;
            this.hSedasSImpleButtonGreen3.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSedasSImpleButtonGreen3.Size = new System.Drawing.Size(86, 20);
            this.hSedasSImpleButtonGreen3.TabIndex = 4;
            this.hSedasSImpleButtonGreen3.Text = "파일열기(GD)";
            this.hSedasSImpleButtonGreen3.Click += new System.EventHandler(this.hSedasSImpleButtonGreen3_Click);
            // 
            // hSedasSImpleButtonGreen2
            // 
            this.hSedasSImpleButtonGreen2.Appearance.ForeColor = System.Drawing.Color.White;
            this.hSedasSImpleButtonGreen2.Appearance.Options.UseForeColor = true;
            this.hSedasSImpleButtonGreen2.Location = new System.Drawing.Point(176, 3);
            this.hSedasSImpleButtonGreen2.LookAndFeel.SkinName = "My Basic";
            this.hSedasSImpleButtonGreen2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.hSedasSImpleButtonGreen2.Name = "hSedasSImpleButtonGreen2";
            this.hSedasSImpleButtonGreen2.SedasButtonType = Sedas.Control.HSedasSImpleButtonGreen.HSimpleButtonType.Null;
            this.hSedasSImpleButtonGreen2.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSedasSImpleButtonGreen2.Size = new System.Drawing.Size(82, 20);
            this.hSedasSImpleButtonGreen2.TabIndex = 3;
            this.hSedasSImpleButtonGreen2.Text = "임시폴더 삭제";
            this.hSedasSImpleButtonGreen2.Visible = false;
            this.hSedasSImpleButtonGreen2.Click += new System.EventHandler(this.hSedasSImpleButtonGreen2_Click);
            // 
            // hSedasSImpleButtonGreen1
            // 
            this.hSedasSImpleButtonGreen1.Appearance.ForeColor = System.Drawing.Color.White;
            this.hSedasSImpleButtonGreen1.Appearance.Options.UseForeColor = true;
            this.hSedasSImpleButtonGreen1.Location = new System.Drawing.Point(264, 3);
            this.hSedasSImpleButtonGreen1.LookAndFeel.SkinName = "My Basic";
            this.hSedasSImpleButtonGreen1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.hSedasSImpleButtonGreen1.Name = "hSedasSImpleButtonGreen1";
            this.hSedasSImpleButtonGreen1.SedasButtonType = Sedas.Control.HSedasSImpleButtonGreen.HSimpleButtonType.Null;
            this.hSedasSImpleButtonGreen1.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSedasSImpleButtonGreen1.Size = new System.Drawing.Size(75, 20);
            this.hSedasSImpleButtonGreen1.TabIndex = 2;
            this.hSedasSImpleButtonGreen1.Text = "섬네일테스트";
            this.hSedasSImpleButtonGreen1.Visible = false;
            this.hSedasSImpleButtonGreen1.Click += new System.EventHandler(this.hSedasSImpleButtonGreen1_Click);
            // 
            // hSedasSImpleButtonGreen4
            // 
            this.hSedasSImpleButtonGreen4.Appearance.ForeColor = System.Drawing.Color.White;
            this.hSedasSImpleButtonGreen4.Appearance.Options.UseForeColor = true;
            this.hSedasSImpleButtonGreen4.Location = new System.Drawing.Point(345, 3);
            this.hSedasSImpleButtonGreen4.LookAndFeel.SkinName = "My Basic";
            this.hSedasSImpleButtonGreen4.LookAndFeel.UseDefaultLookAndFeel = false;
            this.hSedasSImpleButtonGreen4.Name = "hSedasSImpleButtonGreen4";
            this.hSedasSImpleButtonGreen4.SedasButtonType = Sedas.Control.HSedasSImpleButtonGreen.HSimpleButtonType.Null;
            this.hSedasSImpleButtonGreen4.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSedasSImpleButtonGreen4.Size = new System.Drawing.Size(75, 20);
            this.hSedasSImpleButtonGreen4.TabIndex = 5;
            this.hSedasSImpleButtonGreen4.Text = "결과조회";
            this.hSedasSImpleButtonGreen4.Visible = false;
            this.hSedasSImpleButtonGreen4.Click += new System.EventHandler(this.hSedasSImpleButtonGreen4_Click);
            // 
            // hFlowLayoutPanel3
            // 
            this.hFlowLayoutPanel3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.hFlowLayoutPanel3.AutoSize = true;
            this.hFlowLayoutPanel3.BackColor = System.Drawing.Color.Transparent;
            this.hFlowLayoutPanel3.Controls.Add(this.picPrint);
            this.hFlowLayoutPanel3.Controls.Add(this.picDownload);
            this.hFlowLayoutPanel3.Controls.Add(this.picSendEmail);
            this.hFlowLayoutPanel3.Controls.Add(this.flyoutPanel1);
            this.hFlowLayoutPanel3.Location = new System.Drawing.Point(0, 6);
            this.hFlowLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.hFlowLayoutPanel3.Name = "hFlowLayoutPanel3";
            this.hFlowLayoutPanel3.Size = new System.Drawing.Size(294, 46);
            this.hFlowLayoutPanel3.TabIndex = 1;
            // 
            // picPrint
            // 
            this.picPrint.EditValue = global::Integration_Viewer.Properties.Resources.controls_detail_03;
            this.picPrint.Location = new System.Drawing.Point(3, 3);
            this.picPrint.Name = "picPrint";
            this.picPrint.Properties.AllowFocused = false;
            this.picPrint.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picPrint.Properties.Appearance.Options.UseBackColor = true;
            this.picPrint.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picPrint.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picPrint.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picPrint.Size = new System.Drawing.Size(40, 40);
            this.picPrint.TabIndex = 0;
            this.picPrint.ToolTip = "출력";
            this.picPrint.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picPrint_MouseDown);
            // 
            // picDownload
            // 
            this.picDownload.EditValue = global::Integration_Viewer.Properties.Resources.controls_detail_01;
            this.picDownload.Location = new System.Drawing.Point(49, 3);
            this.picDownload.Name = "picDownload";
            this.picDownload.Properties.AllowFocused = false;
            this.picDownload.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picDownload.Properties.Appearance.Options.UseBackColor = true;
            this.picDownload.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picDownload.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picDownload.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picDownload.Size = new System.Drawing.Size(40, 40);
            this.picDownload.TabIndex = 1;
            this.picDownload.ToolTip = "파일 내려받기";
            this.picDownload.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picDownload_MouseDown);
            // 
            // picSendEmail
            // 
            this.picSendEmail.EditValue = global::Integration_Viewer.Properties.Resources.controls_detail_02;
            this.picSendEmail.Location = new System.Drawing.Point(95, 3);
            this.picSendEmail.Name = "picSendEmail";
            this.picSendEmail.Properties.AllowFocused = false;
            this.picSendEmail.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.picSendEmail.Properties.Appearance.Options.UseBackColor = true;
            this.picSendEmail.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picSendEmail.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picSendEmail.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picSendEmail.Size = new System.Drawing.Size(40, 40);
            this.picSendEmail.TabIndex = 2;
            this.picSendEmail.ToolTip = "메일 보내기";
            this.picSendEmail.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSendEmail_MouseDown);
            // 
            // flyoutPanel1
            // 
            this.flyoutPanel1.AnimationRate = 100;
            this.flyoutPanel1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.flyoutPanel1.Appearance.Options.UseBackColor = true;
            this.flyoutPanel1.Controls.Add(this.flyoutPanelControl1);
            this.flyoutPanel1.Location = new System.Drawing.Point(141, 3);
            this.flyoutPanel1.Name = "flyoutPanel1";
            this.flyoutPanel1.Options.AnchorType = DevExpress.Utils.Win.PopupToolWindowAnchor.TopLeft;
            this.flyoutPanel1.Options.AnimationType = DevExpress.Utils.Win.PopupToolWindowAnimation.Fade;
            this.flyoutPanel1.Options.CloseOnOuterClick = true;
            this.flyoutPanel1.Options.VertIndent = 43;
            this.flyoutPanel1.OptionsBeakPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.flyoutPanel1.OptionsButtonPanel.ButtonPanelContentAlignment = System.Drawing.ContentAlignment.BottomRight;
            this.flyoutPanel1.OptionsButtonPanel.ButtonPanelHeight = 26;
            this.flyoutPanel1.OptionsButtonPanel.ButtonPanelLocation = DevExpress.Utils.FlyoutPanelButtonPanelLocation.Bottom;
            this.flyoutPanel1.OwnerControl = this.picPrint;
            this.flyoutPanel1.Size = new System.Drawing.Size(150, 30);
            this.flyoutPanel1.TabIndex = 3;
            // 
            // flyoutPanelControl1
            // 
            this.flyoutPanelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.flyoutPanelControl1.Appearance.Options.UseBackColor = true;
            this.flyoutPanelControl1.Controls.Add(this.tlpPrintSet);
            this.flyoutPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flyoutPanelControl1.FlyoutPanel = this.flyoutPanel1;
            this.flyoutPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.flyoutPanelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.flyoutPanelControl1.Name = "flyoutPanelControl1";
            this.flyoutPanelControl1.Size = new System.Drawing.Size(150, 30);
            this.flyoutPanelControl1.TabIndex = 0;
            // 
            // tlpPrintSet
            // 
            this.tlpPrintSet.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.tlpPrintSet.ColumnCount = 2;
            this.tlpPrintSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrintSet.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpPrintSet.Controls.Add(this.btnPrintH, 1, 0);
            this.tlpPrintSet.Controls.Add(this.btnPrintV, 0, 0);
            this.tlpPrintSet.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpPrintSet.Location = new System.Drawing.Point(2, 2);
            this.tlpPrintSet.Margin = new System.Windows.Forms.Padding(0);
            this.tlpPrintSet.Name = "tlpPrintSet";
            this.tlpPrintSet.RowCount = 1;
            this.tlpPrintSet.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpPrintSet.Size = new System.Drawing.Size(146, 26);
            this.tlpPrintSet.TabIndex = 0;
            // 
            // btnPrintH
            // 
            this.btnPrintH.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPrintH.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPrintH.Appearance.Options.UseForeColor = true;
            this.btnPrintH.Location = new System.Drawing.Point(76, 3);
            this.btnPrintH.LookAndFeel.SkinName = "My Basic";
            this.btnPrintH.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPrintH.Name = "btnPrintH";
            this.btnPrintH.SedasButtonType = Sedas.Control.HSedasSImpleButtonPurple.HSimpleButtonType.Null;
            this.btnPrintH.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnPrintH.Size = new System.Drawing.Size(67, 20);
            this.btnPrintH.TabIndex = 1;
            this.btnPrintH.Text = "가로출력";
            this.btnPrintH.Click += new System.EventHandler(this.btnPrintH_Click);
            // 
            // btnPrintV
            // 
            this.btnPrintV.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPrintV.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPrintV.Appearance.Options.UseForeColor = true;
            this.btnPrintV.Location = new System.Drawing.Point(3, 3);
            this.btnPrintV.LookAndFeel.SkinName = "My Basic";
            this.btnPrintV.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPrintV.Name = "btnPrintV";
            this.btnPrintV.SedasButtonType = Sedas.Control.HSedasSImpleButtonPurple.HSimpleButtonType.Null;
            this.btnPrintV.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnPrintV.Size = new System.Drawing.Size(67, 20);
            this.btnPrintV.TabIndex = 0;
            this.btnPrintV.Text = "세로출력";
            this.btnPrintV.Click += new System.EventHandler(this.btnPrintV_Click);
            // 
            // tlpTopNew
            // 
            this.tlpTopNew.ColumnCount = 1;
            this.tlpTopNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopNew.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTopNew.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTopNew.Location = new System.Drawing.Point(0, 0);
            this.tlpTopNew.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTopNew.Name = "tlpTopNew";
            this.tlpTopNew.RowCount = 1;
            this.tlpTopNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTopNew.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 90F));
            this.tlpTopNew.Size = new System.Drawing.Size(1022, 90);
            this.tlpTopNew.TabIndex = 8;
            // 
            // btnWorkListClose
            // 
            this.btnWorkListClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnWorkListClose.EditValue = global::Integration_Viewer.Properties.Resources.close;
            this.btnWorkListClose.Location = new System.Drawing.Point(350, 0);
            this.btnWorkListClose.Margin = new System.Windows.Forms.Padding(0);
            this.btnWorkListClose.Name = "btnWorkListClose";
            this.btnWorkListClose.Properties.AllowFocused = false;
            this.btnWorkListClose.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnWorkListClose.Properties.Appearance.Options.UseBackColor = true;
            this.btnWorkListClose.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnWorkListClose.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.btnWorkListClose.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.StretchVertical;
            this.btnWorkListClose.Size = new System.Drawing.Size(16, 794);
            this.btnWorkListClose.TabIndex = 2;
            this.btnWorkListClose.Click += new System.EventHandler(this.btnWorkListClose_Click);
            // 
            // hFlowLayoutPanel5
            // 
            this.hFlowLayoutPanel5.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.hFlowLayoutPanel5.AutoSize = true;
            this.hFlowLayoutPanel5.Location = new System.Drawing.Point(150, 108);
            this.hFlowLayoutPanel5.Name = "hFlowLayoutPanel5";
            this.hFlowLayoutPanel5.Size = new System.Drawing.Size(0, 0);
            this.hFlowLayoutPanel5.TabIndex = 3;
            // 
            // TabPage1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "TabPage1";
            this.Size = new System.Drawing.Size(1400, 800);
            this.Load += new System.EventHandler(this.TabPage1_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpAll.ResumeLayout(false);
            this.tlpLeft.ResumeLayout(false);
            this.tlpWorkList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.accordionControl1)).EndInit();
            this.accordionControl1.ResumeLayout(false);
            this.acodiContainerWorkList.ResumeLayout(false);
            this.tlpWorkListNew.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdWorkList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvWorkList)).EndInit();
            this.acodiContainerTreeList.ResumeLayout(false);
            this.tlpTreeListNew.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeList1)).EndInit();
            this.tlpSearch.ResumeLayout(false);
            this.hTableLayoutPanel1.ResumeLayout(false);
            this.hTableLayoutPanel8.ResumeLayout(false);
            this.hTableLayoutPanel8.PerformLayout();
            this.hFlowLayoutPanel6.ResumeLayout(false);
            this.hFlowLayoutPanel6.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPtNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPtoNo.Properties)).EndInit();
            this.hFlowLayoutPanel4.ResumeLayout(false);
            this.hFlowLayoutPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDt.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStartDt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDt.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndDt.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).EndInit();
            this.hTableLayoutPanel7.ResumeLayout(false);
            this.hTableLayoutPanel7.PerformLayout();
            this.hFlowLayoutPanel7.ResumeLayout(false);
            this.tlpRight.ResumeLayout(false);
            this.tlpThumbnail.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.xtraScrollableControl1.PerformLayout();
            this.tlpBottomButtons.ResumeLayout(false);
            this.tlpBottomButtons.PerformLayout();
            this.hFlowLayoutPanel1.ResumeLayout(false);
            this.hFlowLayoutPanel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picPrint.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDownload.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSendEmail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanel1)).EndInit();
            this.flyoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.flyoutPanelControl1)).EndInit();
            this.flyoutPanelControl1.ResumeLayout(false);
            this.tlpPrintSet.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnWorkListClose.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        


        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private Sedas.Control.HTableLayoutPanel tlpAll;
        private Sedas.Control.HTableLayoutPanel tlpLeft;
        private Sedas.Control.HTableLayoutPanel tlpWorkList;
        private Sedas.Control.HTableLayoutPanel tlpRight;
        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel5;
        private Sedas.Control.GridControl.HGridControl grdWorkList;
        private Sedas.Control.GridControl.HGridView grvWorkList;
        private Sedas.Control.GridControl.HGridColumn hGridColumn1;
        private Sedas.Control.GridControl.HGridColumn hGridColumn2;
        private Sedas.Control.GridControl.HGridColumn hGridColumn3;
        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel6;
        private Sedas.Control.HTableLayoutPanel tlpSearch;
        private Sedas.Control.HTableLayoutPanel tlpThumbnail;
        private Sedas.Control.HTableLayoutPanel tlpViewer;
        private Sedas.Control.HTableLayoutPanel tlpBottomButtons;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel1;
        private Sedas.Control.HSedasSImpleButtonGreen btnFileOpen;
        private Sedas.Control.HSedasSImpleButtonGreen hSedasSImpleButtonGreen1;
        private Sedas.Control.HFlowLayoutPanel flwpnlThumbNail;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel3;
        private Sedas.Control.HPictureEdit picPrint;
        private Sedas.Control.HPictureEdit picDownload;
        private Sedas.Control.HPictureEdit picSendEmail;
        private Sedas.Control.HPictureEdit btnWorkListClose;
        private Sedas.Control.HSedasSImpleButtonGreen hSedasSImpleButtonGreen2;
        private Sedas.Control.HSedasSImpleButtonGreen hSedasSImpleButtonGreen3;
        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel1;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel5;
        private Sedas.Control.HPanelControl hPanelControl1;
        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel7;
        private Sedas.Control.HSimpleButton hSimpleButton1;
        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel8;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel6;
        private Sedas.Control.HLabelControl hLabelControl1;
        private Sedas.Control.HTextEdit txtPtNo;
        private Sedas.Control.HLabelControl hLabelControl2;
        private Sedas.Control.HTextEdit txtPtoNo;
        private Sedas.Control.HSedasSImpleButtonBlue btnSearch;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel4;
        private Sedas.Control.HDateEdit txtStartDt;
        private Sedas.Control.HLabelControl hLabelControl4;
        private Sedas.Control.HDateEdit txtEndDt;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel7;
        private Sedas.Control.HSimpleButton hSimpleButton2;
        private Sedas.Control.HSimpleButton hSimpleButton3;
        private Sedas.Control.HSimpleButton hSimpleButton4;
        private Sedas.Control.HSimpleButton hSimpleButton5;
        private DevExpress.XtraTreeList.TreeList treeList1;
        private Sedas.Control.HLabelControl hLabelControl3;
        private DevExpress.XtraBars.Navigation.AccordionControl accordionControl1;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acodiWorkList;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer acodiContainerWorkList;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement2;
        private Sedas.Control.HTableLayoutPanel tlpWorkListNew;
        private DevExpress.XtraBars.Navigation.AccordionControlElement acodiTreeList;
        private DevExpress.XtraBars.Navigation.AccordionContentContainer acodiContainerTreeList;
        private Sedas.Control.HTableLayoutPanel tlpTreeListNew;
        private DevExpress.XtraBars.Navigation.AccordionControlElement accordionControlElement4;
        private Sedas.Control.HTableLayoutPanel tlpTopNew;
        private Sedas.Control.HSedasSImpleButtonGreen hSedasSImpleButtonGreen4;
        private DevExpress.Utils.FlyoutPanel flyoutPanel1;
        private DevExpress.Utils.FlyoutPanelControl flyoutPanelControl1;
        private Sedas.Control.HTableLayoutPanel tlpPrintSet;
        private Sedas.Control.HSedasSImpleButtonPurple btnPrintH;
        private Sedas.Control.HSedasSImpleButtonPurple btnPrintV;
    }
}
