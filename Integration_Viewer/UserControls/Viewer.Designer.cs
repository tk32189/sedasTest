namespace Integration_Viewer
{
    partial class Viewer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Viewer));
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hPanelControl1 = new Sedas.Control.HPanelControl(this.components);
            this.picDicomInfo = new Sedas.Control.HPictureEdit(this.components);
            this.picChecked = new Sedas.Control.HPictureEdit(this.components);
            this.picLeft = new Sedas.Control.HPictureEdit(this.components);
            this.picRight = new Sedas.Control.HPictureEdit(this.components);
            this.tlpCenter = new Sedas.Control.HTableLayoutPanel(this.components);
            this.gdViewer1 = new GdPicture14.GdViewer();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).BeginInit();
            this.hPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDicomInfo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChecked.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight.Properties)).BeginInit();
            this.tlpCenter.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(57)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.hPanelControl1, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(879, 503);
            this.tlpMain.TabIndex = 0;
            // 
            // hPanelControl1
            // 
            this.hPanelControl1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(57)))));
            this.hPanelControl1.Appearance.Options.UseBackColor = true;
            this.hPanelControl1.Controls.Add(this.picDicomInfo);
            this.hPanelControl1.Controls.Add(this.picChecked);
            this.hPanelControl1.Controls.Add(this.picLeft);
            this.hPanelControl1.Controls.Add(this.picRight);
            this.hPanelControl1.Controls.Add(this.tlpCenter);
            this.hPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.hPanelControl1.Margin = new System.Windows.Forms.Padding(0);
            this.hPanelControl1.Name = "hPanelControl1";
            this.hPanelControl1.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.hPanelControl1.Size = new System.Drawing.Size(879, 503);
            this.hPanelControl1.TabIndex = 1;
            // 
            // picDicomInfo
            // 
            this.picDicomInfo.EditValue = ((object)(resources.GetObject("picDicomInfo.EditValue")));
            this.picDicomInfo.Location = new System.Drawing.Point(60, 2);
            this.picDicomInfo.Name = "picDicomInfo";
            this.picDicomInfo.Properties.AllowFocused = false;
            this.picDicomInfo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(57)))));
            this.picDicomInfo.Properties.Appearance.Options.UseBackColor = true;
            this.picDicomInfo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picDicomInfo.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picDicomInfo.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picDicomInfo.Size = new System.Drawing.Size(51, 56);
            this.picDicomInfo.TabIndex = 7;
            this.picDicomInfo.Visible = false;
            this.picDicomInfo.Click += new System.EventHandler(this.picDicomInfo_Click);
            // 
            // picChecked
            // 
            this.picChecked.EditValue = ((object)(resources.GetObject("picChecked.EditValue")));
            this.picChecked.Location = new System.Drawing.Point(2, 1);
            this.picChecked.Name = "picChecked";
            this.picChecked.Properties.AllowFocused = false;
            this.picChecked.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(57)))));
            this.picChecked.Properties.Appearance.Options.UseBackColor = true;
            this.picChecked.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picChecked.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picChecked.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picChecked.Size = new System.Drawing.Size(51, 56);
            this.picChecked.TabIndex = 5;
            // 
            // picLeft
            // 
            this.picLeft.EditValue = global::Integration_Viewer.Properties.Resources.arrow_left;
            this.picLeft.Location = new System.Drawing.Point(16, 212);
            this.picLeft.Name = "picLeft";
            this.picLeft.Properties.AllowFocused = false;
            this.picLeft.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(57)))));
            this.picLeft.Properties.Appearance.Options.UseBackColor = true;
            this.picLeft.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picLeft.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picLeft.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picLeft.Size = new System.Drawing.Size(35, 76);
            this.picLeft.TabIndex = 4;
            this.picLeft.Click += new System.EventHandler(this.picLeft_Click);
            //this.picLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picLeft_MouseDown);
            // 
            // picRight
            // 
            this.picRight.EditValue = global::Integration_Viewer.Properties.Resources.arrow_right;
            this.picRight.Location = new System.Drawing.Point(830, 212);
            this.picRight.Margin = new System.Windows.Forms.Padding(0);
            this.picRight.Name = "picRight";
            this.picRight.Properties.AllowFocused = false;
            this.picRight.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(57)))));
            this.picRight.Properties.Appearance.Options.UseBackColor = true;
            this.picRight.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.picRight.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.picRight.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.picRight.Size = new System.Drawing.Size(35, 76);
            this.picRight.TabIndex = 3;
            this.picRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picRight_MouseDown);
            // 
            // tlpCenter
            // 
            this.tlpCenter.ColumnCount = 1;
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpCenter.Controls.Add(this.gdViewer1, 0, 0);
            this.tlpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCenter.Location = new System.Drawing.Point(2, 2);
            this.tlpCenter.Name = "tlpCenter";
            this.tlpCenter.RowCount = 1;
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 499F));
            this.tlpCenter.Size = new System.Drawing.Size(875, 499);
            this.tlpCenter.TabIndex = 6;
            // 
            // gdViewer1
            // 
            this.gdViewer1.AllowDropFile = false;
            this.gdViewer1.AnimateGIF = true;
            this.gdViewer1.AnnotationDropShadow = false;
            this.gdViewer1.AnnotationResizeRotateHandlesColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.gdViewer1.AnnotationResizeRotateHandlesScale = 1F;
            this.gdViewer1.AnnotationSelectionLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.gdViewer1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.gdViewer1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.gdViewer1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(57)))));
            this.gdViewer1.BackgroundImage = null;
            this.gdViewer1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.gdViewer1.ContinuousViewMode = true;
            this.gdViewer1.Cursor = System.Windows.Forms.Cursors.Default;
            this.gdViewer1.DisplayQuality = GdPicture14.DisplayQuality.DisplayQualityAutomatic;
            this.gdViewer1.DisplayQualityAuto = true;
            this.gdViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gdViewer1.DocumentAlignment = GdPicture14.ViewerDocumentAlignment.DocumentAlignmentMiddleCenter;
            this.gdViewer1.DocumentPosition = GdPicture14.ViewerDocumentPosition.DocumentPositionMiddleCenter;
            this.gdViewer1.DrawPageBorders = true;
            this.gdViewer1.EnableDeferredPainting = true;
            this.gdViewer1.EnabledProgressBar = true;
            this.gdViewer1.EnableICM = false;
            this.gdViewer1.EnableMenu = true;
            this.gdViewer1.EnableMouseWheel = true;
            this.gdViewer1.EnableTextSelection = true;
            this.gdViewer1.ForceScrollBars = false;
            this.gdViewer1.ForceTemporaryMode = false;
            this.gdViewer1.ForeColor = System.Drawing.Color.Black;
            this.gdViewer1.Gamma = 1F;
            this.gdViewer1.HQAnnotationRendering = true;
            this.gdViewer1.IgnoreDocumentResolution = false;
            this.gdViewer1.KeepDocumentPosition = false;
            this.gdViewer1.Location = new System.Drawing.Point(0, 0);
            this.gdViewer1.LockViewer = false;
            this.gdViewer1.MagnifierHeight = 90;
            this.gdViewer1.MagnifierWidth = 160;
            this.gdViewer1.MagnifierZoomX = 2F;
            this.gdViewer1.MagnifierZoomY = 2F;
            this.gdViewer1.Margin = new System.Windows.Forms.Padding(0);
            this.gdViewer1.MouseButtonForMouseMode = GdPicture14.MouseButton.MouseButtonLeft;
            this.gdViewer1.MouseMode = GdPicture14.ViewerMouseMode.MouseModePan;
            this.gdViewer1.MouseWheelMode = GdPicture14.ViewerMouseWheelMode.MouseWheelModeZoom;
            this.gdViewer1.Name = "gdViewer1";
            this.gdViewer1.PageBordersColor = System.Drawing.Color.Black;
            this.gdViewer1.PageBordersPenSize = 1;
            this.gdViewer1.PageDisplayMode = GdPicture14.PageDisplayMode.MultiplePagesView;
            this.gdViewer1.PdfDisplayFormField = true;
            this.gdViewer1.PdfEnableFileLinks = true;
            this.gdViewer1.PdfEnableLinks = true;
            this.gdViewer1.PdfIncreaseTextContrast = false;
            this.gdViewer1.PdfRasterizerEngine = GdPicture14.PdfRasterizerEngine.PdfRasterizerEngineHybrid;
            this.gdViewer1.PdfShowDialogForPassword = true;
            this.gdViewer1.PdfShowOpenFileDialogForDecryption = true;
            this.gdViewer1.PdfVerifyDigitalCertificates = false;
            this.gdViewer1.RectBorderColor = System.Drawing.Color.Black;
            this.gdViewer1.RectBorderSize = 1;
            this.gdViewer1.RectIsEditable = true;
            this.gdViewer1.RegionsAreEditable = true;
            this.gdViewer1.RenderGdPictureAnnots = true;
            this.gdViewer1.ScrollBars = true;
            this.gdViewer1.ScrollLargeChange = ((short)(50));
            this.gdViewer1.ScrollSmallChange = ((short)(1));
            this.gdViewer1.SilentMode = true;
            this.gdViewer1.Size = new System.Drawing.Size(875, 499);
            this.gdViewer1.TabIndex = 0;
            this.gdViewer1.ViewRotation = System.Drawing.RotateFlipType.RotateNoneFlipNone;
            this.gdViewer1.Zoom = 0D;
            this.gdViewer1.ZoomCenterAtMousePosition = false;
            this.gdViewer1.ZoomMode = GdPicture14.ViewerZoomMode.ZoomModeFitToViewer;
            this.gdViewer1.ZoomStep = 25;
            this.gdViewer1.Click += new System.EventHandler(this.gdViewer1_Click);
            this.gdViewer1.DoubleClick += new System.EventHandler(this.gdViewer1_DoubleClick);
            // 
            // Viewer
            // 
            this.AllowDrop = true;
            this.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(35)))), ((int)(((byte)(40)))), ((int)(((byte)(57)))));
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "Viewer";
            this.Size = new System.Drawing.Size(879, 503);
            this.Load += new System.EventHandler(this.Viewer_Load);
            this.SizeChanged += new System.EventHandler(this.Viewer_SizeChanged);
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Viewer_DragDrop);
            this.DragOver += new System.Windows.Forms.DragEventHandler(this.Viewer_DragOver);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).EndInit();
            this.hPanelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDicomInfo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picChecked.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picLeft.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picRight.Properties)).EndInit();
            this.tlpCenter.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private GdPicture14.GdViewer gdViewer1;
        private Sedas.Control.HPanelControl hPanelControl1;
        private Sedas.Control.HPictureEdit picRight;
        private Sedas.Control.HPictureEdit picLeft;
        private Sedas.Control.HPictureEdit picChecked;
        private Sedas.Control.HTableLayoutPanel tlpCenter;
        private Sedas.Control.HPictureEdit picDicomInfo;
    }
}
