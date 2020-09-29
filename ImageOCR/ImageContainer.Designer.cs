namespace ImageOCR
{
    partial class ImageContainer
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
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.lblOcrResult = new DevExpress.XtraEditors.LabelControl();
            this.chkSelected = new Sedas.Control.HCheckEdit();
            this.lblPtnm = new Sedas.Control.HLabelControl();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.lblImageInfo = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpTop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelected.Properties)).BeginInit();
            this.tlpBottom.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.HotFlat;
            this.pnlMain.Controls.Add(this.tlpMain);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(0, 0);
            this.pnlMain.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pnlMain.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlMain.Margin = new System.Windows.Forms.Padding(1);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(278, 185);
            this.pnlMain.TabIndex = 1;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.Gray;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpTop, 0, 0);
            this.tlpMain.Controls.Add(this.tlpBottom, 0, 2);
            this.tlpMain.Controls.Add(this.pictureEdit, 0, 1);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(3, 3);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(1);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 19F));
            this.tlpMain.Size = new System.Drawing.Size(272, 179);
            this.tlpMain.TabIndex = 0;
            this.tlpMain.Click += new System.EventHandler(this.tableLayoutPanel1_Click);
            this.tlpMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tlpMain_MouseDoubleClick);
            // 
            // tlpTop
            // 
            this.tlpTop.BackColor = System.Drawing.Color.Transparent;
            this.tlpTop.ColumnCount = 3;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tlpTop.Controls.Add(this.lblOcrResult, 1, 0);
            this.tlpTop.Controls.Add(this.chkSelected, 0, 0);
            this.tlpTop.Controls.Add(this.lblPtnm, 2, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop.Location = new System.Drawing.Point(0, 0);
            this.tlpTop.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Size = new System.Drawing.Size(272, 23);
            this.tlpTop.TabIndex = 0;
            this.tlpTop.Click += new System.EventHandler(this.tlpTop_Click);
            this.tlpTop.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tlpMain_MouseDoubleClick);
            // 
            // lblOcrResult
            // 
            this.lblOcrResult.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOcrResult.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblOcrResult.Appearance.Options.UseForeColor = true;
            this.lblOcrResult.Location = new System.Drawing.Point(33, 5);
            this.lblOcrResult.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblOcrResult.Margin = new System.Windows.Forms.Padding(1);
            this.lblOcrResult.Name = "lblOcrResult";
            this.lblOcrResult.Size = new System.Drawing.Size(50, 12);
            this.lblOcrResult.TabIndex = 0;
            this.lblOcrResult.Text = "S2008131";
            this.lblOcrResult.Click += new System.EventHandler(this.lblTopInfo_Click);
            this.lblOcrResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseDoubleClick);
            // 
            // chkSelected
            // 
            this.chkSelected.Location = new System.Drawing.Point(3, 1);
            this.chkSelected.Margin = new System.Windows.Forms.Padding(3, 1, 0, 0);
            this.chkSelected.Name = "chkSelected";
            this.chkSelected.Properties.Caption = "";
            this.chkSelected.SedasControlType = Sedas.Control.HCheckEdit.HCheckControlType.Null;
            this.chkSelected.Size = new System.Drawing.Size(18, 17);
            this.chkSelected.TabIndex = 1;
            // 
            // lblPtnm
            // 
            this.lblPtnm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPtnm.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblPtnm.Appearance.Options.UseForeColor = true;
            this.lblPtnm.Location = new System.Drawing.Point(173, 5);
            this.lblPtnm.Margin = new System.Windows.Forms.Padding(1);
            this.lblPtnm.Name = "lblPtnm";
            this.lblPtnm.Size = new System.Drawing.Size(0, 12);
            this.lblPtnm.TabIndex = 2;
            this.lblPtnm.Click += new System.EventHandler(this.lblTopInfo_Click);
            // 
            // tlpBottom
            // 
            this.tlpBottom.BackColor = System.Drawing.Color.Transparent;
            this.tlpBottom.ColumnCount = 1;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.Controls.Add(this.lblImageInfo, 0, 0);
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottom.Location = new System.Drawing.Point(1, 161);
            this.tlpBottom.Margin = new System.Windows.Forms.Padding(1);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpBottom.Size = new System.Drawing.Size(270, 17);
            this.tlpBottom.TabIndex = 1;
            this.tlpBottom.Click += new System.EventHandler(this.imageBox_Click);
            this.tlpBottom.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tlpMain_MouseDoubleClick);
            // 
            // lblImageInfo
            // 
            this.lblImageInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImageInfo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblImageInfo.Appearance.Options.UseForeColor = true;
            this.lblImageInfo.Location = new System.Drawing.Point(1, 2);
            this.lblImageInfo.Margin = new System.Windows.Forms.Padding(1);
            this.lblImageInfo.Name = "lblImageInfo";
            this.lblImageInfo.Size = new System.Drawing.Size(48, 12);
            this.lblImageInfo.TabIndex = 1;
            this.lblImageInfo.Text = "경로없음";
            this.lblImageInfo.Click += new System.EventHandler(this.imageBox_Click);
            this.lblImageInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseDoubleClick);
            // 
            // pictureEdit
            // 
            this.pictureEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit.Location = new System.Drawing.Point(3, 26);
            this.pictureEdit.Name = "pictureEdit";
            this.pictureEdit.Properties.Appearance.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pictureEdit.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit.Size = new System.Drawing.Size(266, 131);
            this.pictureEdit.TabIndex = 2;
            this.pictureEdit.Click += new System.EventHandler(this.imageBox_Click);
            this.pictureEdit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseDoubleClick);
            // 
            // ImageContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "ImageContainer";
            this.Size = new System.Drawing.Size(278, 185);
            this.Load += new System.EventHandler(this.ImageContainer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpTop.ResumeLayout(false);
            this.tlpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkSelected.Properties)).EndInit();
            this.tlpBottom.ResumeLayout(false);
            this.tlpBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMain;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private DevExpress.XtraEditors.LabelControl lblOcrResult;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private DevExpress.XtraEditors.LabelControl lblImageInfo;
        private DevExpress.XtraEditors.PictureEdit pictureEdit;
        private Sedas.Control.HCheckEdit chkSelected;
        private Sedas.Control.HLabelControl lblPtnm;
    }
}
