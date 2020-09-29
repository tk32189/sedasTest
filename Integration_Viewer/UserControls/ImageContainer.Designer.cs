namespace Integration_Viewer
{
    partial class ImageContainer
    {


        /// <summary> 
        /// Required designer variable.
        /// </summary>
        public System.ComponentModel.IContainer components = null;

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
            DevExpress.Utils.ContextButton contextButton1 = new DevExpress.Utils.ContextButton();
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.lblOcrResult = new DevExpress.XtraEditors.LabelControl();
            this.lblImageNum = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit = new DevExpress.XtraEditors.PictureEdit();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpTop.SuspendLayout();
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
            this.pnlMain.Size = new System.Drawing.Size(318, 212);
            this.pnlMain.TabIndex = 2;
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.Gray;
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.tlpTop, 0, 0);
            this.tlpMain.Controls.Add(this.pictureEdit, 1, 0);
            this.tlpMain.Controls.Add(this.tlpBottom, 0, 2);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(3, 3);
            this.tlpMain.Margin = new System.Windows.Forms.Padding(1);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tlpMain.Size = new System.Drawing.Size(312, 206);
            this.tlpMain.TabIndex = 0;
            this.tlpMain.Click += new System.EventHandler(this.tableLayoutPanel1_Click);
            this.tlpMain.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tlpMain_MouseDoubleClick);
            // 
            // tlpTop
            // 
            this.tlpTop.BackColor = System.Drawing.Color.Transparent;
            this.tlpTop.ColumnCount = 2;
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpTop.Controls.Add(this.lblOcrResult, 0, 0);
            this.tlpTop.Controls.Add(this.lblImageNum, 1, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop.Location = new System.Drawing.Point(1, 1);
            this.tlpTop.Margin = new System.Windows.Forms.Padding(1);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Size = new System.Drawing.Size(310, 1);
            this.tlpTop.TabIndex = 0;
            this.tlpTop.Click += new System.EventHandler(this.tableLayoutPanel1_Click);
            this.tlpTop.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tlpMain_MouseDoubleClick);
            // 
            // lblOcrResult
            // 
            this.lblOcrResult.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblOcrResult.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblOcrResult.Appearance.Options.UseForeColor = true;
            this.lblOcrResult.Location = new System.Drawing.Point(1, 1);
            this.lblOcrResult.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblOcrResult.Margin = new System.Windows.Forms.Padding(1);
            this.lblOcrResult.Name = "lblOcrResult";
            this.lblOcrResult.Size = new System.Drawing.Size(50, 12);
            this.lblOcrResult.TabIndex = 0;
            this.lblOcrResult.Text = "S2008131";
            this.lblOcrResult.Click += new System.EventHandler(this.imageBox_Click);
            this.lblOcrResult.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseDoubleClick);
            // 
            // lblImageNum
            // 
            this.lblImageNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImageNum.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblImageNum.Appearance.Options.UseForeColor = true;
            this.lblImageNum.Location = new System.Drawing.Point(291, 1);
            this.lblImageNum.Margin = new System.Windows.Forms.Padding(1);
            this.lblImageNum.Name = "lblImageNum";
            this.lblImageNum.Size = new System.Drawing.Size(6, 12);
            this.lblImageNum.TabIndex = 1;
            this.lblImageNum.Text = "1";
            this.lblImageNum.Click += new System.EventHandler(this.imageBox_Click);
            this.lblImageNum.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseDoubleClick);
            // 
            // pictureEdit
            // 
            this.pictureEdit.AllowDrop = true;
            this.pictureEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit.Location = new System.Drawing.Point(0, 0);
            this.pictureEdit.Margin = new System.Windows.Forms.Padding(0);
            this.pictureEdit.Name = "pictureEdit";
            this.pictureEdit.Properties.AllowFocused = false;
            this.pictureEdit.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(32)))), ((int)(((byte)(44)))));
            this.pictureEdit.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit.Properties.ContextButtonOptions.BottomPanelColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureEdit.Properties.ContextButtonOptions.Indent = 5;
            this.pictureEdit.Properties.ContextButtonOptions.TopPanelColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(112)))), ((int)(((byte)(192)))), ((int)(((byte)(255)))));
            contextButton1.AllowGlyphSkinning = DevExpress.Utils.DefaultBoolean.True;
            contextButton1.AppearanceHover.ForeColor = System.Drawing.Color.White;
            contextButton1.AppearanceHover.Options.UseForeColor = true;
            contextButton1.AppearanceNormal.ForeColor = System.Drawing.Color.White;
            contextButton1.AppearanceNormal.Options.UseForeColor = true;
            contextButton1.Id = new System.Guid("fcbdd391-65b6-49f1-8397-dfc3c3318322");
            contextButton1.Name = "imageName";
            this.pictureEdit.Properties.ContextButtons.Add(contextButton1);
            this.pictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.pictureEdit.Size = new System.Drawing.Size(312, 206);
            this.pictureEdit.TabIndex = 2;
            this.pictureEdit.Click += new System.EventHandler(this.imageBox_Click);
            this.pictureEdit.DragDrop += new System.Windows.Forms.DragEventHandler(this.pictureEdit_DragDrop);
            this.pictureEdit.DragOver += new System.Windows.Forms.DragEventHandler(this.pictureEdit_DragOver);
            this.pictureEdit.GiveFeedback += new System.Windows.Forms.GiveFeedbackEventHandler(this.pictureEdit_GiveFeedback);
            this.pictureEdit.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureEdit_Paint);
            this.pictureEdit.QueryContinueDrag += new System.Windows.Forms.QueryContinueDragEventHandler(this.pictureEdit_QueryContinueDrag);
            this.pictureEdit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseDoubleClick);
            this.pictureEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseDown);
            this.pictureEdit.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseMove);
            this.pictureEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseUp);
            // 
            // tlpBottom
            // 
            this.tlpBottom.BackColor = System.Drawing.Color.Transparent;
            this.tlpBottom.ColumnCount = 1;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottom.Location = new System.Drawing.Point(1, 207);
            this.tlpBottom.Margin = new System.Windows.Forms.Padding(1);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpBottom.Size = new System.Drawing.Size(310, 1);
            this.tlpBottom.TabIndex = 1;
            this.tlpBottom.Click += new System.EventHandler(this.imageBox_Click);
            this.tlpBottom.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tlpMain_MouseDoubleClick);
            // 
            // ImageContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Name = "ImageContainer";
            this.Size = new System.Drawing.Size(318, 212);
            this.Load += new System.EventHandler(this.ImageContainer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpTop.ResumeLayout(false);
            this.tlpTop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMain;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private DevExpress.XtraEditors.LabelControl lblOcrResult;
        private DevExpress.XtraEditors.LabelControl lblImageNum;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private DevExpress.XtraEditors.PictureEdit pictureEdit;
        //private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        //private DevExpress.Utils.DragDrop.DragDropEvents dragDropEvents1;
        //private Sedas.Control.HPictureEdit picExtention;
    }
}
