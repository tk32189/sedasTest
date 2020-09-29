namespace IIP
{
    partial class IIP_ImageShow
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
            DevExpress.Utils.TrackBarContextButton trackBarContextButton1 = new DevExpress.Utils.TrackBarContextButton();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IIP_ImageShow));
            this.behaviorManager1 = new DevExpress.Utils.Behaviors.BehaviorManager(this.components);
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hTableLayoutPanel2 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.btnUp = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.btnDown = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.btnStretch = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.btnExit = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.pnlMain = new Sedas.Control.HPanelControl(this.components);
            this.pictureEdit = new Sedas.Control.HPictureEdit(this.components);
            this.pnlTopLine = new Sedas.Control.HPanelControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).BeginInit();
            this.tlpMain.SuspendLayout();
            this.hTableLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTopLine)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.hTableLayoutPanel2, 0, 1);
            this.tlpMain.Controls.Add(this.pnlMain, 0, 2);
            this.tlpMain.Controls.Add(this.pnlTopLine, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 3;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 2F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 34F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(998, 573);
            this.tlpMain.TabIndex = 0;
            // 
            // hTableLayoutPanel2
            // 
            this.hTableLayoutPanel2.ColumnCount = 5;
            this.hTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.hTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.hTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.hTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.hTableLayoutPanel2.Controls.Add(this.btnUp, 0, 0);
            this.hTableLayoutPanel2.Controls.Add(this.btnDown, 1, 0);
            this.hTableLayoutPanel2.Controls.Add(this.btnStretch, 3, 0);
            this.hTableLayoutPanel2.Controls.Add(this.btnExit, 4, 0);
            this.hTableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel2.Location = new System.Drawing.Point(3, 5);
            this.hTableLayoutPanel2.Name = "hTableLayoutPanel2";
            this.hTableLayoutPanel2.RowCount = 1;
            this.hTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel2.Size = new System.Drawing.Size(992, 28);
            this.hTableLayoutPanel2.TabIndex = 0;
            // 
            // btnUp
            // 
            this.btnUp.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnUp.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnUp.Appearance.Options.UseForeColor = true;
            this.btnUp.Location = new System.Drawing.Point(12, 4);
            this.btnUp.LookAndFeel.SkinName = "My Basic";
            this.btnUp.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUp.Name = "btnUp";
            this.btnUp.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnUp.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnUp.Size = new System.Drawing.Size(75, 20);
            this.btnUp.TabIndex = 0;
            this.btnUp.Text = "+";
            this.btnUp.Click += new System.EventHandler(this.btnUp_Click);
            // 
            // btnDown
            // 
            this.btnDown.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnDown.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnDown.Appearance.Options.UseForeColor = true;
            this.btnDown.Location = new System.Drawing.Point(112, 4);
            this.btnDown.LookAndFeel.SkinName = "My Basic";
            this.btnDown.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDown.Name = "btnDown";
            this.btnDown.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnDown.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnDown.Size = new System.Drawing.Size(75, 20);
            this.btnDown.TabIndex = 1;
            this.btnDown.Text = "-";
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // btnStretch
            // 
            this.btnStretch.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStretch.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnStretch.Appearance.Options.UseForeColor = true;
            this.btnStretch.Location = new System.Drawing.Point(804, 4);
            this.btnStretch.LookAndFeel.SkinName = "My Basic";
            this.btnStretch.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnStretch.Name = "btnStretch";
            this.btnStretch.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnStretch.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnStretch.Size = new System.Drawing.Size(75, 20);
            this.btnStretch.TabIndex = 2;
            this.btnStretch.Text = "Stretch";
            this.btnStretch.Click += new System.EventHandler(this.btnStretch_Click);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnExit.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnExit.Appearance.Options.UseForeColor = true;
            this.btnExit.Location = new System.Drawing.Point(904, 4);
            this.btnExit.LookAndFeel.SkinName = "My Basic";
            this.btnExit.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnExit.Name = "btnExit";
            this.btnExit.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnExit.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnExit.Size = new System.Drawing.Size(75, 20);
            this.btnExit.TabIndex = 3;
            this.btnExit.Text = "EXIT";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // pnlMain
            // 
            this.pnlMain.Controls.Add(this.pictureEdit);
            this.pnlMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlMain.Location = new System.Drawing.Point(3, 39);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.pnlMain.Size = new System.Drawing.Size(992, 531);
            this.pnlMain.TabIndex = 1;
            // 
            // pictureEdit
            // 
            this.pictureEdit.Cursor = System.Windows.Forms.Cursors.Default;
            this.pictureEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit.Location = new System.Drawing.Point(2, 2);
            this.pictureEdit.Name = "pictureEdit";
            this.pictureEdit.Properties.AllowScrollViaMouseDrag = true;
            this.pictureEdit.Properties.AllowZoomOnMouseWheel = DevExpress.Utils.DefaultBoolean.True;
            this.pictureEdit.Properties.Appearance.Options.UseTextOptions = true;
            this.pictureEdit.Properties.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.pictureEdit.Properties.Appearance.TextOptions.VAlignment = DevExpress.Utils.VertAlignment.Center;
            this.pictureEdit.Properties.ContextButtonOptions.BottomPanelColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pictureEdit.Properties.ContextButtonOptions.Indent = 3;
            this.pictureEdit.Properties.ContextButtonOptions.TopPanelColor = System.Drawing.Color.FromArgb(((int)(((byte)(160)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            trackBarContextButton1.Id = new System.Guid("bb9f017e-df61-4140-afdb-de64a492aef4");
            trackBarContextButton1.Maximum = 200;
            trackBarContextButton1.Name = "trackBarContextButton";
            trackBarContextButton1.Value = 30;
            this.pictureEdit.Properties.ContextButtons.Add(trackBarContextButton1);
            this.pictureEdit.Properties.NullText = "no data";
            this.pictureEdit.Properties.ZoomingOperationMode = DevExpress.XtraEditors.Repository.ZoomingOperationMode.MouseWheel;
            this.pictureEdit.Properties.ContextButtonValueChanged += new DevExpress.Utils.ContextButtonValueChangedEventHandler(this.pictureEditSample_Properties_ContextButtonValueChanged);
            this.pictureEdit.Size = new System.Drawing.Size(988, 527);
            this.pictureEdit.TabIndex = 0;
            this.pictureEdit.ZoomPercentChanged += new System.EventHandler(this.pictureEditSample_ZoomPercentChanged);
            this.pictureEdit.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseDown);
            this.pictureEdit.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseUp);
            // 
            // pnlTopLine
            // 
            this.pnlTopLine.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.pnlTopLine.Appearance.Options.UseBackColor = true;
            this.pnlTopLine.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.tlpMain.SetColumnSpan(this.pnlTopLine, 3);
            this.pnlTopLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlTopLine.Location = new System.Drawing.Point(0, 0);
            this.pnlTopLine.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pnlTopLine.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlTopLine.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTopLine.Name = "pnlTopLine";
            this.pnlTopLine.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.pnlTopLine.Size = new System.Drawing.Size(998, 2);
            this.pnlTopLine.TabIndex = 2;
            // 
            // IIP_ImageShow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 573);
            this.Controls.Add(this.tlpMain);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("IIP_ImageShow.IconOptions.Image")));
            this.Name = "IIP_ImageShow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "IIP_ImageShow";
            this.Load += new System.EventHandler(this.IIP_ImageShow_Load);
            ((System.ComponentModel.ISupportInitialize)(this.behaviorManager1)).EndInit();
            this.tlpMain.ResumeLayout(false);
            this.hTableLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTopLine)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel2;
        private Sedas.Control.HSedasSImpleButtonBlue btnUp;
        private Sedas.Control.HSedasSImpleButtonBlue btnDown;
        private Sedas.Control.HSedasSImpleButtonBlue btnStretch;
        private Sedas.Control.HSedasSImpleButtonBlue btnExit;
        private Sedas.Control.HPanelControl pnlMain;
        private Sedas.Control.HPictureEdit pictureEdit;
        private DevExpress.Utils.Behaviors.BehaviorManager behaviorManager1;
        private Sedas.Control.HPanelControl pnlTopLine;
    }
}