using System.Drawing;

namespace Sedas.UserControl
{
    partial class SedasFileOpen
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        //public Color backColor = Color.FromArgb(11, 11, 21);
        //public Color panelColor = Color.FromArgb(36, 42, 55);

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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions4 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject13 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject14 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject15 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject16 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.XtraEditors.BreadCrumbNode breadCrumbNode1 = new DevExpress.XtraEditors.BreadCrumbNode();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SedasFileOpen));
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.tlpCenter = new Sedas.Control.HTableLayoutPanel(this.components);
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.winExplorerView = new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView();
            this.columnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tlpOption = new Sedas.Control.HTableLayoutPanel(this.components);
            this.grdViewType = new Sedas.Control.GridControl.HGridControl(this.components);
            this.grvViewType = new Sedas.Control.GridControl.HGridView();
            this.view = new Sedas.Control.GridControl.HGridColumn();
            this.chkCheckBoxVisible = new Sedas.Control.HCheckEdit(this.components);
            this.chkShowFileNameExtension = new Sedas.Control.HCheckEdit(this.components);
            this.btnCreatFolder = new Sedas.Control.HSimpleButton();
            this.picturethumbnail = new Sedas.Control.HPictureEdit(this.components);
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.ContextItemRename = new DevExpress.XtraBars.BarButtonItem();
            this.ContextItemDelete = new DevExpress.XtraBars.BarButtonItem();
            this.ContextItemCopy = new DevExpress.XtraBars.BarButtonItem();
            this.ContextItemPaste = new DevExpress.XtraBars.BarButtonItem();
            this.ContextItemCut = new DevExpress.XtraBars.BarButtonItem();
            this.ContextItemRefresh = new DevExpress.XtraBars.BarButtonItem();
            this.btnFolderSelect = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.tlpTop = new Sedas.Control.HTableLayoutPanel(this.components);
            this.EditSearch = new DevExpress.XtraEditors.ButtonEdit();
            this.editBreadCrumb = new DevExpress.XtraEditors.BreadCrumbEdit();
            this.hPanelControl1 = new Sedas.Control.HPanelControl(this.components);
            this.btnUpTo = new DevExpress.XtraEditors.LabelControl();
            this.btnNavigationHistory = new DevExpress.XtraEditors.LabelControl();
            this.btnForward = new DevExpress.XtraEditors.LabelControl();
            this.btnBack = new DevExpress.XtraEditors.LabelControl();
            this.tlpTree = new Sedas.Control.HTableLayoutPanel(this.components);
            this.navigationTreeList = new DevExpress.XtraTreeList.TreeList();
            this.navNameCol = new DevExpress.XtraTreeList.Columns.TreeListColumn();
            this.svgImageCollection1 = new DevExpress.Utils.SvgImageCollection(this.components);
            this.itemPopupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.breadCrumbEvents1 = new DevExpress.XtraEditors.Behaviors.BreadCrumbEvents(this.components);
            this.btnTreeRefresh = new Sedas.Control.HSimpleButton();
            this.tlpMain.SuspendLayout();
            this.tlpCenter.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.tlpOption.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvViewType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCheckBoxVisible.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowFileNameExtension.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturethumbnail.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            this.tlpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.EditSearch.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBreadCrumb.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).BeginInit();
            this.hPanelControl1.SuspendLayout();
            this.tlpTree.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.navigationTreeList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPopupMenu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(11)))), ((int)(((byte)(21)))));
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 250F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpCenter, 1, 1);
            this.tlpMain.Controls.Add(this.tlpTop, 1, 0);
            this.tlpMain.Controls.Add(this.tlpTree, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(822, 431);
            this.tlpMain.TabIndex = 0;
            // 
            // tlpCenter
            // 
            this.tlpCenter.ColumnCount = 2;
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCenter.Controls.Add(this.gridControl, 0, 0);
            this.tlpCenter.Controls.Add(this.tlpOption, 1, 0);
            this.tlpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCenter.Location = new System.Drawing.Point(250, 26);
            this.tlpCenter.Margin = new System.Windows.Forms.Padding(0);
            this.tlpCenter.Name = "tlpCenter";
            this.tlpCenter.RowCount = 1;
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCenter.Size = new System.Drawing.Size(572, 405);
            this.tlpCenter.TabIndex = 3;
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.Location = new System.Drawing.Point(3, 3);
            this.gridControl.MainView = this.winExplorerView;
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(366, 399);
            this.gridControl.TabIndex = 3;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.winExplorerView,
            this.gridView1});
            this.gridControl.DragDrop += new System.Windows.Forms.DragEventHandler(this.gridControl_DragDrop);
            this.gridControl.DragEnter += new System.Windows.Forms.DragEventHandler(this.gridControl_DragEnter);
            // 
            // winExplorerView
            // 
            this.winExplorerView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.winExplorerView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnName,
            this.columnPath,
            this.columnCheck,
            this.columnGroup,
            this.columnImage});
            this.winExplorerView.ColumnSet.CheckBoxColumn = this.columnCheck;
            this.winExplorerView.ColumnSet.DescriptionColumn = this.columnPath;
            this.winExplorerView.ColumnSet.ExtraLargeImageColumn = this.columnImage;
            this.winExplorerView.ColumnSet.GroupColumn = this.columnGroup;
            this.winExplorerView.ColumnSet.LargeImageColumn = this.columnImage;
            this.winExplorerView.ColumnSet.MediumImageColumn = this.columnImage;
            this.winExplorerView.ColumnSet.SmallImageColumn = this.columnImage;
            this.winExplorerView.ColumnSet.TextColumn = this.columnName;
            this.winExplorerView.GridControl = this.gridControl;
            this.winExplorerView.GroupCount = 1;
            this.winExplorerView.Name = "winExplorerView";
            this.winExplorerView.OptionsBehavior.Editable = false;
            this.winExplorerView.OptionsSelection.AllowMarqueeSelection = true;
            this.winExplorerView.OptionsSelection.ItemSelectionMode = DevExpress.XtraGrid.Views.WinExplorer.IconItemSelectionMode.Click;
            this.winExplorerView.OptionsSelection.MultiSelect = true;
            this.winExplorerView.OptionsView.ImageLayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch;
            this.winExplorerView.OptionsView.ShowViewCaption = true;
            this.winExplorerView.OptionsViewStyles.List.ItemWidth = 250;
            this.winExplorerView.OptionsViewStyles.Tiles.ItemWidth = 250;
            this.winExplorerView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.columnGroup, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.winExplorerView.ItemClick += new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewItemClickEventHandler(this.OnWinExplorerViewItemClick);
            this.winExplorerView.ItemDoubleClick += new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewItemDoubleClickEventHandler(this.OnWinExplorerViewItemDoubleClick);
            this.winExplorerView.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.OnWinExplorerViewSelectionChanged);
            this.winExplorerView.CustomColumnSort += new DevExpress.XtraGrid.Views.Base.CustomColumnSortEventHandler(this.winExplorerView_CustomColumnSort);
            this.winExplorerView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnWinExplorerViewKeyDown);
            // 
            // columnName
            // 
            this.columnName.Caption = "columnName";
            this.columnName.FieldName = "Name";
            this.columnName.Name = "columnName";
            this.columnName.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.columnName.Visible = true;
            this.columnName.VisibleIndex = 0;
            // 
            // columnPath
            // 
            this.columnPath.Caption = "columnPath";
            this.columnPath.FieldName = "Path";
            this.columnPath.Name = "columnPath";
            this.columnPath.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.columnPath.Visible = true;
            this.columnPath.VisibleIndex = 0;
            // 
            // columnCheck
            // 
            this.columnCheck.Caption = "columnCheck";
            this.columnCheck.FieldName = "IsCheck";
            this.columnCheck.Name = "columnCheck";
            this.columnCheck.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.columnCheck.Visible = true;
            this.columnCheck.VisibleIndex = 0;
            // 
            // columnGroup
            // 
            this.columnGroup.Caption = "columnGroup";
            this.columnGroup.FieldName = "Group";
            this.columnGroup.Name = "columnGroup";
            this.columnGroup.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.columnGroup.Visible = true;
            this.columnGroup.VisibleIndex = 0;
            // 
            // columnImage
            // 
            this.columnImage.Caption = "columnImage";
            this.columnImage.FieldName = "Image";
            this.columnImage.Name = "columnImage";
            this.columnImage.SortMode = DevExpress.XtraGrid.ColumnSortMode.Custom;
            this.columnImage.Visible = true;
            this.columnImage.VisibleIndex = 0;
            // 
            // gridView1
            // 
            this.gridView1.DetailHeight = 300;
            this.gridView1.GridControl = this.gridControl;
            this.gridView1.Name = "gridView1";
            // 
            // tlpOption
            // 
            this.tlpOption.ColumnCount = 1;
            this.tlpOption.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOption.Controls.Add(this.grdViewType, 0, 0);
            this.tlpOption.Controls.Add(this.chkCheckBoxVisible, 0, 1);
            this.tlpOption.Controls.Add(this.chkShowFileNameExtension, 0, 2);
            this.tlpOption.Controls.Add(this.btnCreatFolder, 0, 3);
            this.tlpOption.Controls.Add(this.picturethumbnail, 0, 6);
            this.tlpOption.Controls.Add(this.btnFolderSelect, 0, 4);
            this.tlpOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpOption.Location = new System.Drawing.Point(375, 3);
            this.tlpOption.Name = "tlpOption";
            this.tlpOption.RowCount = 7;
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.tlpOption.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpOption.Size = new System.Drawing.Size(194, 399);
            this.tlpOption.TabIndex = 5;
            // 
            // grdViewType
            // 
            this.grdViewType.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdViewType.Location = new System.Drawing.Point(3, 3);
            this.grdViewType.MainView = this.grvViewType;
            this.grdViewType.Name = "grdViewType";
            this.grdViewType.Size = new System.Drawing.Size(188, 110);
            this.grdViewType.TabIndex = 0;
            this.grdViewType.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvViewType});
            // 
            // grvViewType
            // 
            this.grvViewType.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvViewType.Appearance.Empty.Options.UseBackColor = true;
            this.grvViewType.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvViewType.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvViewType.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvViewType.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.grvViewType.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvViewType.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvViewType.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvViewType.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvViewType.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvViewType.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvViewType.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvViewType.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvViewType.Appearance.Row.Options.UseBackColor = true;
            this.grvViewType.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvViewType.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvViewType.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvViewType.Appearance.VertLine.Options.UseBackColor = true;
            this.grvViewType.AutoFillColumn = this.view;
            this.grvViewType.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.grvViewType.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.view});
            this.grvViewType.DetailHeight = 300;
            this.grvViewType.GridControl = this.grdViewType;
            this.grvViewType.IsSedasDefaultGrid = false;
            this.grvViewType.Name = "grvViewType";
            this.grvViewType.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.False;
            this.grvViewType.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.False;
            this.grvViewType.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.grvViewType.OptionsCustomization.AllowColumnMoving = false;
            this.grvViewType.OptionsCustomization.AllowFilter = false;
            this.grvViewType.OptionsCustomization.AllowSort = false;
            this.grvViewType.OptionsFind.AllowFindPanel = false;
            this.grvViewType.OptionsMenu.EnableColumnMenu = false;
            this.grvViewType.OptionsSelection.MultiSelect = true;
            this.grvViewType.OptionsView.ShowColumnHeaders = false;
            this.grvViewType.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.grvViewType.OptionsView.ShowGroupPanel = false;
            this.grvViewType.OptionsView.ShowIndicator = false;
            this.grvViewType.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.grvViewType.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grvViewType_CustomDrawCell);
            this.grvViewType.SelectionChanged += new DevExpress.Data.SelectionChangedEventHandler(this.grvViewType_SelectionChanged);
            // 
            // view
            // 
            this.view.AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.view.AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.view.AppearanceHeader.Options.UseBackColor = true;
            this.view.AppearanceHeader.Options.UseForeColor = true;
            this.view.Caption = "view";
            this.view.FieldName = "viewName";
            this.view.Name = "view";
            this.view.OptionsColumn.AllowEdit = false;
            this.view.OptionsColumn.ReadOnly = true;
            this.view.Visible = true;
            this.view.VisibleIndex = 0;
            this.view.Width = 180;
            // 
            // chkCheckBoxVisible
            // 
            this.chkCheckBoxVisible.Location = new System.Drawing.Point(3, 119);
            this.chkCheckBoxVisible.Name = "chkCheckBoxVisible";
            this.chkCheckBoxVisible.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.chkCheckBoxVisible.Properties.Appearance.Options.UseForeColor = true;
            this.chkCheckBoxVisible.Properties.Caption = "체크박스 보이기";
            this.chkCheckBoxVisible.Properties.LookAndFeel.SkinName = "My Basic";
            this.chkCheckBoxVisible.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkCheckBoxVisible.SedasControlType = Sedas.Control.HCheckEdit.HCheckControlType.Kuh;
            this.chkCheckBoxVisible.Size = new System.Drawing.Size(143, 28);
            this.chkCheckBoxVisible.TabIndex = 1;
            this.chkCheckBoxVisible.CheckedChanged += new System.EventHandler(this.chkCheckBoxVisible_CheckedChanged);
            // 
            // chkShowFileNameExtension
            // 
            this.chkShowFileNameExtension.Location = new System.Drawing.Point(3, 153);
            this.chkShowFileNameExtension.Name = "chkShowFileNameExtension";
            this.chkShowFileNameExtension.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.chkShowFileNameExtension.Properties.Appearance.Options.UseForeColor = true;
            this.chkShowFileNameExtension.Properties.Caption = "확장자 보이기";
            this.chkShowFileNameExtension.Properties.LookAndFeel.SkinName = "My Basic";
            this.chkShowFileNameExtension.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkShowFileNameExtension.SedasControlType = Sedas.Control.HCheckEdit.HCheckControlType.Kuh;
            this.chkShowFileNameExtension.Size = new System.Drawing.Size(143, 28);
            this.chkShowFileNameExtension.TabIndex = 2;
            this.chkShowFileNameExtension.CheckedChanged += new System.EventHandler(this.chkShowFileNameExtension_CheckedChanged);
            // 
            // btnCreatFolder
            // 
            this.btnCreatFolder.Location = new System.Drawing.Point(3, 187);
            this.btnCreatFolder.Name = "btnCreatFolder";
            this.btnCreatFolder.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnCreatFolder.Size = new System.Drawing.Size(94, 20);
            this.btnCreatFolder.TabIndex = 3;
            this.btnCreatFolder.Text = "새폴더 만들기";
            this.btnCreatFolder.Click += new System.EventHandler(this.btnCreatFolder_Click);
            // 
            // picturethumbnail
            // 
            this.picturethumbnail.Location = new System.Drawing.Point(3, 256);
            this.picturethumbnail.MenuManager = this.barManager1;
            this.picturethumbnail.Name = "picturethumbnail";
            this.picturethumbnail.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picturethumbnail.Size = new System.Drawing.Size(161, 111);
            this.picturethumbnail.TabIndex = 4;
            // 
            // barManager1
            // 
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ContextItemRename,
            this.ContextItemDelete,
            this.ContextItemCopy,
            this.ContextItemPaste,
            this.ContextItemCut,
            this.ContextItemRefresh});
            this.barManager1.MaxItemId = 8;
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Size = new System.Drawing.Size(822, 0);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 431);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Size = new System.Drawing.Size(822, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 0);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 431);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(822, 0);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 431);
            // 
            // ContextItemRename
            // 
            this.ContextItemRename.Caption = "이름변경";
            this.ContextItemRename.Id = 0;
            this.ContextItemRename.Name = "ContextItemRename";
            this.ContextItemRename.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ContextItemRename_ItemClick);
            // 
            // ContextItemDelete
            // 
            this.ContextItemDelete.Caption = "삭제";
            this.ContextItemDelete.Id = 1;
            this.ContextItemDelete.Name = "ContextItemDelete";
            this.ContextItemDelete.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ContextItemDelete_ItemClick);
            // 
            // ContextItemCopy
            // 
            this.ContextItemCopy.Caption = "복사";
            this.ContextItemCopy.Id = 3;
            this.ContextItemCopy.Name = "ContextItemCopy";
            this.ContextItemCopy.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ContextItemCopy_ItemClick);
            // 
            // ContextItemPaste
            // 
            this.ContextItemPaste.Caption = "붙여넣기";
            this.ContextItemPaste.Id = 4;
            this.ContextItemPaste.Name = "ContextItemPaste";
            this.ContextItemPaste.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ContextItemPaste_ItemClick);
            // 
            // ContextItemCut
            // 
            this.ContextItemCut.Caption = "잘라내기";
            this.ContextItemCut.Id = 5;
            this.ContextItemCut.Name = "ContextItemCut";
            this.ContextItemCut.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ContextItemCut_ItemClick);
            // 
            // ContextItemRefresh
            // 
            this.ContextItemRefresh.Caption = "새로고침";
            this.ContextItemRefresh.Id = 7;
            this.ContextItemRefresh.Name = "ContextItemRefresh";
            this.ContextItemRefresh.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.ContextItemRefresh_ItemClick);
            // 
            // btnFolderSelect
            // 
            this.btnFolderSelect.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnFolderSelect.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnFolderSelect.Appearance.Options.UseForeColor = true;
            this.btnFolderSelect.Location = new System.Drawing.Point(3, 213);
            this.btnFolderSelect.LookAndFeel.SkinName = "My Basic";
            this.btnFolderSelect.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnFolderSelect.Name = "btnFolderSelect";
            this.btnFolderSelect.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnFolderSelect.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnFolderSelect.Size = new System.Drawing.Size(75, 20);
            this.btnFolderSelect.TabIndex = 5;
            this.btnFolderSelect.Text = "폴더선택";
            this.btnFolderSelect.Click += new System.EventHandler(this.btnFolderSelect_Click);
            // 
            // tlpTop
            // 
            this.tlpTop.ColumnCount = 3;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 200F));
            this.tlpTop.Controls.Add(this.EditSearch, 2, 0);
            this.tlpTop.Controls.Add(this.editBreadCrumb, 1, 0);
            this.tlpTop.Controls.Add(this.hPanelControl1, 0, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop.Location = new System.Drawing.Point(250, 0);
            this.tlpTop.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.tlpTop.Size = new System.Drawing.Size(572, 26);
            this.tlpTop.TabIndex = 2;
            // 
            // EditSearch
            // 
            this.EditSearch.Dock = System.Windows.Forms.DockStyle.Right;
            this.EditSearch.Location = new System.Drawing.Point(375, 3);
            this.EditSearch.Name = "EditSearch";
            this.EditSearch.Properties.AutoHeight = false;
            editorButtonImageOptions1.SvgImageSize = new System.Drawing.Size(16, 16);
            this.EditSearch.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.EditSearch.Size = new System.Drawing.Size(194, 20);
            this.EditSearch.TabIndex = 5;
            this.EditSearch.TextChanged += new System.EventHandler(this.OnEditSearchTextChanged);
            // 
            // editBreadCrumb
            // 
            this.editBreadCrumb.Dock = System.Windows.Forms.DockStyle.Fill;
            this.editBreadCrumb.Location = new System.Drawing.Point(103, 3);
            this.editBreadCrumb.Name = "editBreadCrumb";
            this.editBreadCrumb.Properties.AutoHeight = false;
            editorButtonImageOptions2.SvgImageSize = new System.Drawing.Size(8, 8);
            this.editBreadCrumb.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.SpinDown, "", 18, true, true, false, editorButtonImageOptions2, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject5, serializableAppearanceObject6, serializableAppearanceObject7, serializableAppearanceObject8, "", null, null, DevExpress.Utils.ToolTipAnchor.Default),
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Redo, "", 15, true, true, false, editorButtonImageOptions4, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject13, serializableAppearanceObject14, serializableAppearanceObject15, serializableAppearanceObject16, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.editBreadCrumb.Properties.DropDownRows = 12;
            this.editBreadCrumb.Properties.ImageIndex = 0;
            breadCrumbNode1.Caption = "Computer";
            breadCrumbNode1.Persistent = true;
            breadCrumbNode1.PopulateOnDemand = true;
            breadCrumbNode1.Value = "Computer";
            this.editBreadCrumb.Properties.Nodes.AddRange(new DevExpress.XtraEditors.BreadCrumbNode[] {
            breadCrumbNode1});
            this.editBreadCrumb.Properties.RootImageIndex = 0;
            this.editBreadCrumb.Properties.SortNodesByCaption = true;
            this.editBreadCrumb.Properties.RootGlyphClick += new System.EventHandler(this.OnBreadCrumbRootGlyphClick);
            this.editBreadCrumb.Properties.QueryChildNodes += new DevExpress.XtraEditors.BreadCrumbQueryChildNodesEventHandler(this.OnBreadCrumbQueryChildNodes);
            this.editBreadCrumb.Properties.ValidatePath += new DevExpress.XtraEditors.BreadCrumbValidatePathEventHandler(this.OnBreadCrumbValidatePath);
            this.editBreadCrumb.Properties.NewNodeAdding += new DevExpress.XtraEditors.BreadCrumbNewNodeAddingEventHandler(this.OnBreadCrumbNewNodeAdding);
            this.editBreadCrumb.Size = new System.Drawing.Size(266, 20);
            this.editBreadCrumb.TabIndex = 4;
            this.editBreadCrumb.PathChanged += new DevExpress.XtraEditors.BreadCrumbPathChangedEventHandler(this.OnBreadCrumbPathChanged);
            // 
            // hPanelControl1
            // 
            this.hPanelControl1.Controls.Add(this.btnUpTo);
            this.hPanelControl1.Controls.Add(this.btnNavigationHistory);
            this.hPanelControl1.Controls.Add(this.btnForward);
            this.hPanelControl1.Controls.Add(this.btnBack);
            this.hPanelControl1.Location = new System.Drawing.Point(3, 3);
            this.hPanelControl1.Name = "hPanelControl1";
            this.hPanelControl1.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.hPanelControl1.Size = new System.Drawing.Size(94, 20);
            this.hPanelControl1.TabIndex = 0;
            // 
            // btnUpTo
            // 
            this.btnUpTo.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnUpTo.Appearance.ImageIndex = 5;
            this.btnUpTo.Appearance.Options.UseImageIndex = true;
            this.btnUpTo.Appearance.Options.UseImageList = true;
            this.btnUpTo.AppearanceHovered.ImageIndex = 2;
            this.btnUpTo.AppearanceHovered.Options.UseImageIndex = true;
            this.btnUpTo.AppearancePressed.ImageIndex = 8;
            this.btnUpTo.AppearancePressed.Options.UseImageIndex = true;
            this.btnUpTo.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnUpTo.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnUpTo.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnUpTo.ImageOptions.SvgImage")));
            this.btnUpTo.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnUpTo.Location = new System.Drawing.Point(74, 2);
            this.btnUpTo.Name = "btnUpTo";
            this.btnUpTo.Size = new System.Drawing.Size(24, 16);
            this.btnUpTo.TabIndex = 10;
            this.btnUpTo.Click += new System.EventHandler(this.OnUpButtonClick);
            // 
            // btnNavigationHistory
            // 
            this.btnNavigationHistory.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnNavigationHistory.Appearance.ImageIndex = 2;
            this.btnNavigationHistory.Appearance.Options.UseImageIndex = true;
            this.btnNavigationHistory.Appearance.Options.UseImageList = true;
            this.btnNavigationHistory.AppearanceHovered.ImageIndex = 1;
            this.btnNavigationHistory.AppearanceHovered.Options.UseImageIndex = true;
            this.btnNavigationHistory.AppearancePressed.ImageIndex = 3;
            this.btnNavigationHistory.AppearancePressed.Options.UseImageIndex = true;
            this.btnNavigationHistory.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnNavigationHistory.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnNavigationHistory.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnNavigationHistory.ImageOptions.SvgImage")));
            this.btnNavigationHistory.ImageOptions.SvgImageSize = new System.Drawing.Size(8, 8);
            this.btnNavigationHistory.Location = new System.Drawing.Point(50, 2);
            this.btnNavigationHistory.Name = "btnNavigationHistory";
            this.btnNavigationHistory.Size = new System.Drawing.Size(24, 16);
            this.btnNavigationHistory.TabIndex = 11;
            this.btnNavigationHistory.Click += new System.EventHandler(this.OnNavigationMenuButtonClick);
            // 
            // btnForward
            // 
            this.btnForward.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnForward.Appearance.ImageIndex = 4;
            this.btnForward.Appearance.Options.UseImageIndex = true;
            this.btnForward.Appearance.Options.UseImageList = true;
            this.btnForward.AppearanceHovered.ImageIndex = 1;
            this.btnForward.AppearanceHovered.Options.UseImageIndex = true;
            this.btnForward.AppearancePressed.ImageIndex = 7;
            this.btnForward.AppearancePressed.Options.UseImageIndex = true;
            this.btnForward.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnForward.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnForward.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnForward.ImageOptions.SvgImage")));
            this.btnForward.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnForward.Location = new System.Drawing.Point(26, 2);
            this.btnForward.Name = "btnForward";
            this.btnForward.Size = new System.Drawing.Size(24, 16);
            this.btnForward.TabIndex = 7;
            this.btnForward.Click += new System.EventHandler(this.OnNextButtonClick);
            // 
            // btnBack
            // 
            this.btnBack.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            this.btnBack.Appearance.ImageIndex = 3;
            this.btnBack.Appearance.Options.UseImageIndex = true;
            this.btnBack.Appearance.Options.UseImageList = true;
            this.btnBack.AppearanceHovered.ImageIndex = 0;
            this.btnBack.AppearanceHovered.Options.UseImageIndex = true;
            this.btnBack.AppearancePressed.ImageIndex = 6;
            this.btnBack.AppearancePressed.Options.UseImageIndex = true;
            this.btnBack.AutoSizeMode = DevExpress.XtraEditors.LabelAutoSizeMode.None;
            this.btnBack.Dock = System.Windows.Forms.DockStyle.Left;
            this.btnBack.ImageOptions.SvgImage = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("btnBack.ImageOptions.SvgImage")));
            this.btnBack.ImageOptions.SvgImageSize = new System.Drawing.Size(16, 16);
            this.btnBack.Location = new System.Drawing.Point(2, 2);
            this.btnBack.Name = "btnBack";
            this.btnBack.Size = new System.Drawing.Size(24, 16);
            this.btnBack.TabIndex = 6;
            this.btnBack.Click += new System.EventHandler(this.OnBackButtonClick);
            // 
            // tlpTree
            // 
            this.tlpTree.ColumnCount = 1;
            this.tlpTree.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTree.Controls.Add(this.navigationTreeList, 0, 0);
            this.tlpTree.Controls.Add(this.btnTreeRefresh, 0, 1);
            this.tlpTree.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTree.Location = new System.Drawing.Point(3, 3);
            this.tlpTree.Name = "tlpTree";
            this.tlpTree.RowCount = 2;
            this.tlpMain.SetRowSpan(this.tlpTree, 2);
            this.tlpTree.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTree.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.tlpTree.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTree.Size = new System.Drawing.Size(244, 425);
            this.tlpTree.TabIndex = 4;
            // 
            // navigationTreeList
            // 
            this.behaviorManager1.SetBehaviors(this.navigationTreeList, new DevExpress.Utils.Behaviors.Behavior[] {
            ((DevExpress.Utils.Behaviors.Behavior)(DevExpress.XtraEditors.Behaviors.BreadCrumbBehavior.Create(typeof(DevExpress.XtraTreeList.TreeListBreadCrumbSource), this.editBreadCrumb, "DisplayName", "Name", this.breadCrumbEvents1)))});
            this.navigationTreeList.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.navigationTreeList.Columns.AddRange(new DevExpress.XtraTreeList.Columns.TreeListColumn[] {
            this.navNameCol});
            this.navigationTreeList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.navigationTreeList.Location = new System.Drawing.Point(3, 3);
            this.navigationTreeList.MenuManager = this.barManager1;
            this.navigationTreeList.Name = "navigationTreeList";
            this.navigationTreeList.OptionsBehavior.AllowPixelScrolling = DevExpress.Utils.DefaultBoolean.False;
            this.navigationTreeList.OptionsBehavior.Editable = false;
            this.navigationTreeList.OptionsFind.AllowFindPanel = false;
            this.navigationTreeList.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.navigationTreeList.OptionsView.FocusRectStyle = DevExpress.XtraTreeList.DrawFocusRectStyle.None;
            this.navigationTreeList.OptionsView.ShowColumns = false;
            this.navigationTreeList.OptionsView.ShowHorzLines = false;
            this.navigationTreeList.OptionsView.ShowIndentAsRowStyle = true;
            this.navigationTreeList.OptionsView.ShowIndicator = false;
            this.navigationTreeList.OptionsView.ShowVertLines = false;
            this.navigationTreeList.RowHeight = 22;
            this.navigationTreeList.SelectImageList = this.svgImageCollection1;
            this.navigationTreeList.Size = new System.Drawing.Size(238, 394);
            this.navigationTreeList.TabIndex = 0;
            // 
            // navNameCol
            // 
            this.navNameCol.Caption = "DisplayName";
            this.navNameCol.FieldName = "DisplayName";
            this.navNameCol.Name = "navNameCol";
            this.navNameCol.Visible = true;
            this.navNameCol.VisibleIndex = 0;
            // 
            // svgImageCollection1
            // 
            this.svgImageCollection1.Add("electronics_desktopmac", "image://svgimages/icon builder/electronics_desktopmac.svg");
            // 
            // itemPopupMenu
            // 
            this.itemPopupMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.ContextItemRefresh),
            new DevExpress.XtraBars.LinkPersistInfo(this.ContextItemDelete, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ContextItemRename),
            new DevExpress.XtraBars.LinkPersistInfo(this.ContextItemCut, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.ContextItemCopy),
            new DevExpress.XtraBars.LinkPersistInfo(this.ContextItemPaste)});
            this.itemPopupMenu.Manager = this.barManager1;
            this.itemPopupMenu.Name = "itemPopupMenu";
            // 
            // btnTreeRefresh
            // 
            this.btnTreeRefresh.Location = new System.Drawing.Point(3, 403);
            this.btnTreeRefresh.Name = "btnTreeRefresh";
            this.btnTreeRefresh.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnTreeRefresh.Size = new System.Drawing.Size(238, 19);
            this.btnTreeRefresh.TabIndex = 1;
            this.btnTreeRefresh.Text = "새로고침";
            this.btnTreeRefresh.Click += new System.EventHandler(this.btnTreeRefresh_Click);
            // 
            // SedasFileOpen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Name = "SedasFileOpen";
            this.Size = new System.Drawing.Size(822, 431);
            this.Load += new System.EventHandler(this.SedasFileOpen_Load);
            this.tlpMain.ResumeLayout(false);
            this.tlpCenter.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.tlpOption.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grdViewType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvViewType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkCheckBoxVisible.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chkShowFileNameExtension.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picturethumbnail.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            this.tlpTop.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.EditSearch.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.editBreadCrumb.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).EndInit();
            this.hPanelControl1.ResumeLayout(false);
            this.tlpTree.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.navigationTreeList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.svgImageCollection1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPopupMenu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Control.HTableLayoutPanel tlpMain;
        private Control.HTableLayoutPanel tlpTop;
        private DevExpress.XtraEditors.ButtonEdit EditSearch;
        private DevExpress.XtraEditors.BreadCrumbEdit editBreadCrumb;
        private Control.HPanelControl hPanelControl1;
        private DevExpress.XtraEditors.LabelControl btnUpTo;
        private DevExpress.XtraEditors.LabelControl btnNavigationHistory;
        private DevExpress.XtraEditors.LabelControl btnForward;
        private DevExpress.XtraEditors.LabelControl btnBack;
        private Control.HTableLayoutPanel tlpCenter;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView winExplorerView;
        private DevExpress.XtraGrid.Columns.GridColumn columnName;
        private DevExpress.XtraGrid.Columns.GridColumn columnPath;
        private DevExpress.XtraGrid.Columns.GridColumn columnCheck;
        private DevExpress.XtraGrid.Columns.GridColumn columnGroup;
        private DevExpress.XtraGrid.Columns.GridColumn columnImage;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private Control.HTableLayoutPanel tlpOption;
        private Control.GridControl.HGridControl grdViewType;
        private Control.GridControl.HGridView grvViewType;
        private Control.GridControl.HGridColumn view;
        private Control.HCheckEdit chkCheckBoxVisible;
        private Control.HCheckEdit chkShowFileNameExtension;
        private DevExpress.XtraBars.PopupMenu itemPopupMenu;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem ContextItemRename;
        private DevExpress.XtraBars.BarButtonItem ContextItemDelete;
        private Control.HSimpleButton btnCreatFolder;
        private Control.HPictureEdit picturethumbnail;
        private Control.HSedasSImpleButtonBlue btnFolderSelect;
        private DevExpress.XtraBars.BarButtonItem ContextItemCopy;
        private DevExpress.XtraBars.BarButtonItem ContextItemPaste;
        private DevExpress.XtraBars.BarButtonItem ContextItemCut;
        private Control.HTableLayoutPanel tlpTree;
        private DevExpress.XtraTreeList.TreeList navigationTreeList;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private DevExpress.XtraTreeList.Columns.TreeListColumn navNameCol;
        private DevExpress.Utils.SvgImageCollection svgImageCollection1;
        private DevExpress.XtraEditors.Behaviors.BreadCrumbEvents breadCrumbEvents1;
        private DevExpress.XtraBars.BarButtonItem ContextItemRefresh;
        private Control.HSimpleButton btnTreeRefresh;
        //private DevExpress.XtraBars.BarButtonItem barButtonItem1;
    }
}
