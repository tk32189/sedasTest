namespace Integration_Viewer
{
    partial class ThumNailTest
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
            this.hTableLayoutPanel1 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hPanelControl1 = new Sedas.Control.HPanelControl(this.components);
            this.hGridControl1 = new Sedas.Control.GridControl.HGridControl(this.components);
            this.hGridView1 = new Sedas.Control.GridControl.HGridView();
            this.hGridColumn1 = new Sedas.Control.GridControl.HGridColumn();
            this.hGridView2 = new Sedas.Control.GridControl.HGridView();
            this.advBandedGridView1 = new DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView();
            this.gridBand1 = new DevExpress.XtraGrid.Views.BandedGrid.GridBand();
            this.ThumbnailEx1 = new GdPicture14.ThumbnailEx();
            this.hSedasSimpleButton11 = new Sedas.Control.HSedasSimpleButton1(this.components);
            this.galleryControl1 = new DevExpress.XtraBars.Ribbon.GalleryControl();
            this.galleryControlClient1 = new DevExpress.XtraBars.Ribbon.GalleryControlClient();
            this.hTableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).BeginInit();
            this.hPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hGridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hGridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControl1)).BeginInit();
            this.galleryControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hTableLayoutPanel1
            // 
            this.hTableLayoutPanel1.ColumnCount = 1;
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.hTableLayoutPanel1.Controls.Add(this.hPanelControl1, 0, 0);
            this.hTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.hTableLayoutPanel1.Name = "hTableLayoutPanel1";
            this.hTableLayoutPanel1.RowCount = 1;
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 395F));
            this.hTableLayoutPanel1.Size = new System.Drawing.Size(1546, 695);
            this.hTableLayoutPanel1.TabIndex = 0;
            // 
            // hPanelControl1
            // 
            this.hPanelControl1.Controls.Add(this.galleryControl1);
            this.hPanelControl1.Controls.Add(this.hGridControl1);
            this.hPanelControl1.Controls.Add(this.hSedasSimpleButton11);
            this.hPanelControl1.Location = new System.Drawing.Point(3, 3);
            this.hPanelControl1.Name = "hPanelControl1";
            this.hPanelControl1.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.hPanelControl1.Size = new System.Drawing.Size(1531, 588);
            this.hPanelControl1.TabIndex = 0;
            // 
            // hGridControl1
            // 
            this.hGridControl1.Location = new System.Drawing.Point(912, 54);
            this.hGridControl1.MainView = this.hGridView1;
            this.hGridControl1.Name = "hGridControl1";
            this.hGridControl1.Size = new System.Drawing.Size(585, 207);
            this.hGridControl1.TabIndex = 4;
            this.hGridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.hGridView1,
            this.hGridView2,
            this.advBandedGridView1});
            // 
            // hGridView1
            // 
            this.hGridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.hGridColumn1});
            this.hGridView1.GridControl = this.hGridControl1;
            this.hGridView1.IsSedasDefaultGrid = false;
            this.hGridView1.Name = "hGridView1";
            this.hGridView1.SedasControlType = Sedas.Control.ControlType.Null;
            // 
            // hGridColumn1
            // 
            this.hGridColumn1.Caption = "hGridColumn1";
            this.hGridColumn1.Name = "hGridColumn1";
            this.hGridColumn1.Visible = true;
            this.hGridColumn1.VisibleIndex = 0;
            // 
            // hGridView2
            // 
            this.hGridView2.GridControl = this.hGridControl1;
            this.hGridView2.IsSedasDefaultGrid = false;
            this.hGridView2.Name = "hGridView2";
            this.hGridView2.SedasControlType = Sedas.Control.ControlType.Null;
            // 
            // advBandedGridView1
            // 
            this.advBandedGridView1.Bands.AddRange(new DevExpress.XtraGrid.Views.BandedGrid.GridBand[] {
            this.gridBand1});
            this.advBandedGridView1.GridControl = this.hGridControl1;
            this.advBandedGridView1.Name = "advBandedGridView1";
            // 
            // gridBand1
            // 
            this.gridBand1.Caption = "gridBand1";
            this.gridBand1.Name = "gridBand1";
            this.gridBand1.VisibleIndex = 0;
            // 
            // ThumbnailEx1
            // 
            this.ThumbnailEx1.AllowDropFiles = false;
            this.ThumbnailEx1.AllowMoveItems = false;
            this.ThumbnailEx1.BackColor = System.Drawing.SystemColors.Control;
            this.ThumbnailEx1.CheckBoxes = false;
            this.ThumbnailEx1.CheckBoxesMarginLeft = 0;
            this.ThumbnailEx1.CheckBoxesMarginTop = 0;
            this.ThumbnailEx1.DefaultItemCheckState = false;
            this.ThumbnailEx1.DefaultItemTextPrefix = "Page ";
            this.ThumbnailEx1.DisplayAnnotations = true;
            this.ThumbnailEx1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ThumbnailEx1.EnableDropShadow = true;
            this.ThumbnailEx1.HorizontalTextAlignment = GdPicture14.TextAlignment.TextAlignmentCenter;
            this.ThumbnailEx1.HotTracking = false;
            this.ThumbnailEx1.Location = new System.Drawing.Point(3, 3);
            this.ThumbnailEx1.LockGdViewerEvents = false;
            this.ThumbnailEx1.MultiSelect = false;
            this.ThumbnailEx1.Name = "ThumbnailEx1";
            this.ThumbnailEx1.OwnDrop = false;
            this.ThumbnailEx1.PauseThumbsLoading = false;
            this.ThumbnailEx1.PdfIncreaseTextContrast = false;
            this.ThumbnailEx1.PdfRasterizerEngine = GdPicture14.PdfRasterizerEngine.PdfRasterizerEngineHybrid;
            this.ThumbnailEx1.PreloadAllItems = true;
            this.ThumbnailEx1.RotateExif = true;
            this.ThumbnailEx1.SelectedThumbnailBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(153)))), ((int)(((byte)(255)))));
            this.ThumbnailEx1.ShowText = true;
            this.ThumbnailEx1.Size = new System.Drawing.Size(778, 144);
            this.ThumbnailEx1.TabIndex = 1;
            this.ThumbnailEx1.TextMarginLeft = 0;
            this.ThumbnailEx1.TextMarginTop = 0;
            this.ThumbnailEx1.ThumbnailAlignment = GdPicture14.ThumbnailAlignment.ThumbnailAlignmentHorizontal;
            this.ThumbnailEx1.ThumbnailBackColor = System.Drawing.Color.Transparent;
            this.ThumbnailEx1.ThumbnailBorder = false;
            this.ThumbnailEx1.ThumbnailForeColor = System.Drawing.Color.Black;
            this.ThumbnailEx1.ThumbnailSize = new System.Drawing.Size(256, 256);
            this.ThumbnailEx1.ThumbnailSpacing = new System.Drawing.Size(0, 0);
            this.ThumbnailEx1.VerticalTextAlignment = GdPicture14.TextAlignment.TextAlignmentCenter;
            // 
            // hSedasSimpleButton11
            // 
            this.hSedasSimpleButton11.Appearance.ForeColor = System.Drawing.Color.White;
            this.hSedasSimpleButton11.Appearance.Options.UseForeColor = true;
            this.hSedasSimpleButton11.Location = new System.Drawing.Point(27, 553);
            this.hSedasSimpleButton11.LookAndFeel.SkinName = "My Basic";
            this.hSedasSimpleButton11.LookAndFeel.UseDefaultLookAndFeel = false;
            this.hSedasSimpleButton11.Name = "hSedasSimpleButton11";
            this.hSedasSimpleButton11.SedasButtonType = Sedas.Control.HSedasSimpleButton1.HSimpleButtonType.Null;
            this.hSedasSimpleButton11.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSedasSimpleButton11.Size = new System.Drawing.Size(75, 20);
            this.hSedasSimpleButton11.TabIndex = 1;
            this.hSedasSimpleButton11.Text = "hSedasSimpleButton11";
            this.hSedasSimpleButton11.Click += new System.EventHandler(this.hSedasSimpleButton11_Click);
            // 
            // galleryControl1
            // 
            this.galleryControl1.Controls.Add(this.galleryControlClient1);
            // 
            // 
            // 
            this.galleryControl1.Gallery.ScrollMode = DevExpress.XtraBars.Ribbon.Gallery.GalleryScrollMode.Smooth;
            this.galleryControl1.Location = new System.Drawing.Point(96, 110);
            this.galleryControl1.Name = "galleryControl1";
            this.galleryControl1.Size = new System.Drawing.Size(698, 179);
            this.galleryControl1.TabIndex = 5;
            this.galleryControl1.Text = "galleryControl1";
            // 
            // galleryControlClient1
            // 
            this.galleryControlClient1.GalleryControl = this.galleryControl1;
            this.galleryControlClient1.Location = new System.Drawing.Point(2, 2);
            this.galleryControlClient1.Size = new System.Drawing.Size(677, 175);
            // 
            // ThumNailTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1546, 695);
            this.Controls.Add(this.hTableLayoutPanel1);
            this.Name = "ThumNailTest";
            this.Text = "ThumNailTest";
            this.hTableLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).EndInit();
            this.hPanelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hGridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hGridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.advBandedGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.galleryControl1)).EndInit();
            this.galleryControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel1;
        private Sedas.Control.HPanelControl hPanelControl1;
        private Sedas.Control.HSedasSimpleButton1 hSedasSimpleButton11;
        internal GdPicture14.ThumbnailEx ThumbnailEx1;
        private Sedas.Control.GridControl.HGridControl hGridControl1;
        private Sedas.Control.GridControl.HGridView hGridView1;
        private Sedas.Control.GridControl.HGridColumn hGridColumn1;
        private Sedas.Control.GridControl.HGridView hGridView2;
        private DevExpress.XtraGrid.Views.BandedGrid.AdvBandedGridView advBandedGridView1;
        private DevExpress.XtraGrid.Views.BandedGrid.GridBand gridBand1;
        private DevExpress.XtraBars.Ribbon.GalleryControl galleryControl1;
        private DevExpress.XtraBars.Ribbon.GalleryControlClient galleryControlClient1;
    }
}