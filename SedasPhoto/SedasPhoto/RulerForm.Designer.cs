namespace SedasPhotoMagic
{
    partial class RulerForm
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
            this.pm = new System.Windows.Forms.PictureBox();
            this.PanelView = new System.Windows.Forms.Panel();
            this.lblPixelPerCm = new System.Windows.Forms.Label();
            this.btnMesure = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.btnZoomSource = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.btnZoomBigger = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.btnZoomSmaller = new Sedas.Control.HSedasSImpleButtonBlue(this.components);
            this.btnClose = new Sedas.Control.HSedasSImpleButtonGreen(this.components);
            this.pnlTopLine = new Sedas.Control.HPanelControl(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pm)).BeginInit();
            this.PanelView.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pnlTopLine)).BeginInit();
            this.SuspendLayout();
            // 
            // pm
            // 
            this.pm.Location = new System.Drawing.Point(23, 19);
            this.pm.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.pm.Name = "pm";
            this.pm.Size = new System.Drawing.Size(176, 244);
            this.pm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pm.TabIndex = 0;
            this.pm.TabStop = false;
            this.pm.SizeChanged += new System.EventHandler(this.ePictureBoxMainSizeChanged);
            this.pm.Paint += new System.Windows.Forms.PaintEventHandler(this.PictureBoxMain_Paint);
            this.pm.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMain_MouseDown);
            this.pm.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMain_MouseMove);
            this.pm.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBoxMain_MouseUp);
            // 
            // PanelView
            // 
            this.PanelView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.PanelView.BackColor = System.Drawing.Color.LightGray;
            this.PanelView.Controls.Add(this.pm);
            this.PanelView.Location = new System.Drawing.Point(13, 50);
            this.PanelView.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.PanelView.Name = "PanelView";
            this.PanelView.Size = new System.Drawing.Size(865, 471);
            this.PanelView.TabIndex = 1;
            // 
            // lblPixelPerCm
            // 
            this.lblPixelPerCm.AutoSize = true;
            this.lblPixelPerCm.Location = new System.Drawing.Point(9, 15);
            this.lblPixelPerCm.Name = "lblPixelPerCm";
            this.lblPixelPerCm.Size = new System.Drawing.Size(70, 19);
            this.lblPixelPerCm.TabIndex = 2;
            this.lblPixelPerCm.Text = "80 px/cm";
            // 
            // btnMesure
            // 
            this.btnMesure.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMesure.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMesure.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnMesure.Appearance.Options.UseFont = true;
            this.btnMesure.Appearance.Options.UseForeColor = true;
            this.btnMesure.Location = new System.Drawing.Point(101, 7);
            this.btnMesure.LookAndFeel.SkinName = "My Basic";
            this.btnMesure.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnMesure.Name = "btnMesure";
            this.btnMesure.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnMesure.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnMesure.Size = new System.Drawing.Size(75, 36);
            this.btnMesure.TabIndex = 57;
            this.btnMesure.Tag = "";
            this.btnMesure.Text = "측정하기";
            this.btnMesure.Click += new System.EventHandler(this.btnMesure_Click);
            // 
            // btnZoomSource
            // 
            this.btnZoomSource.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnZoomSource.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomSource.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnZoomSource.Appearance.Options.UseFont = true;
            this.btnZoomSource.Appearance.Options.UseForeColor = true;
            this.btnZoomSource.Location = new System.Drawing.Point(195, 7);
            this.btnZoomSource.LookAndFeel.SkinName = "My Basic";
            this.btnZoomSource.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnZoomSource.Name = "btnZoomSource";
            this.btnZoomSource.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnZoomSource.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnZoomSource.Size = new System.Drawing.Size(75, 36);
            this.btnZoomSource.TabIndex = 58;
            this.btnZoomSource.Tag = "";
            this.btnZoomSource.Text = "원본";
            this.btnZoomSource.Click += new System.EventHandler(this.btnZoomSource_Click);
            // 
            // btnZoomBigger
            // 
            this.btnZoomBigger.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnZoomBigger.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomBigger.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnZoomBigger.Appearance.Options.UseFont = true;
            this.btnZoomBigger.Appearance.Options.UseForeColor = true;
            this.btnZoomBigger.Location = new System.Drawing.Point(276, 7);
            this.btnZoomBigger.LookAndFeel.SkinName = "My Basic";
            this.btnZoomBigger.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnZoomBigger.Name = "btnZoomBigger";
            this.btnZoomBigger.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnZoomBigger.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnZoomBigger.Size = new System.Drawing.Size(49, 36);
            this.btnZoomBigger.TabIndex = 59;
            this.btnZoomBigger.Tag = "";
            this.btnZoomBigger.Text = "+";
            this.btnZoomBigger.Click += new System.EventHandler(this.btnZoomBigger_Click);
            // 
            // btnZoomSmaller
            // 
            this.btnZoomSmaller.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnZoomSmaller.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnZoomSmaller.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnZoomSmaller.Appearance.Options.UseFont = true;
            this.btnZoomSmaller.Appearance.Options.UseForeColor = true;
            this.btnZoomSmaller.Location = new System.Drawing.Point(331, 7);
            this.btnZoomSmaller.LookAndFeel.SkinName = "My Basic";
            this.btnZoomSmaller.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnZoomSmaller.Name = "btnZoomSmaller";
            this.btnZoomSmaller.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnZoomSmaller.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnZoomSmaller.Size = new System.Drawing.Size(43, 36);
            this.btnZoomSmaller.TabIndex = 60;
            this.btnZoomSmaller.Tag = "";
            this.btnZoomSmaller.Text = "-";
            this.btnZoomSmaller.Click += new System.EventHandler(this.btnZoomSmaller_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.btnClose.Appearance.Font = new System.Drawing.Font("맑은 고딕", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnClose.Appearance.Options.UseFont = true;
            this.btnClose.Appearance.Options.UseForeColor = true;
            this.btnClose.Location = new System.Drawing.Point(790, 6);
            this.btnClose.LookAndFeel.SkinName = "My Basic";
            this.btnClose.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnClose.Name = "btnClose";
            this.btnClose.SedasButtonType = Sedas.Control.HSedasSImpleButtonGreen.HSimpleButtonType.Null;
            this.btnClose.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnClose.Size = new System.Drawing.Size(75, 36);
            this.btnClose.TabIndex = 61;
            this.btnClose.Tag = "";
            this.btnClose.Text = "Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // pnlTopLine
            // 
            this.pnlTopLine.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(103)))), ((int)(((byte)(163)))));
            this.pnlTopLine.Appearance.Options.UseBackColor = true;
            this.pnlTopLine.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.pnlTopLine.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTopLine.Location = new System.Drawing.Point(0, 0);
            this.pnlTopLine.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.pnlTopLine.LookAndFeel.UseDefaultLookAndFeel = false;
            this.pnlTopLine.Margin = new System.Windows.Forms.Padding(0);
            this.pnlTopLine.Name = "pnlTopLine";
            this.pnlTopLine.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.pnlTopLine.Size = new System.Drawing.Size(890, 2);
            this.pnlTopLine.TabIndex = 2;
            // 
            // RulerForm
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(890, 535);
            this.Controls.Add(this.pnlTopLine);
            this.Controls.Add(this.btnMesure);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnZoomSmaller);
            this.Controls.Add(this.btnZoomBigger);
            this.Controls.Add(this.btnZoomSource);
            this.Controls.Add(this.lblPixelPerCm);
            this.Controls.Add(this.PanelView);
            this.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "RulerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SET pixel/cm";
            this.Load += new System.EventHandler(this.RulerForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pm)).EndInit();
            this.PanelView.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pnlTopLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pm;
        private System.Windows.Forms.Panel PanelView;
        private System.Windows.Forms.Label lblPixelPerCm;
        private Sedas.Control.HSedasSImpleButtonGreen btnClose;
        private Sedas.Control.HSedasSImpleButtonBlue btnZoomSmaller;
        private Sedas.Control.HSedasSImpleButtonBlue btnZoomBigger;
        private Sedas.Control.HSedasSImpleButtonBlue btnZoomSource;
        private Sedas.Control.HSedasSImpleButtonBlue btnMesure;
        private Sedas.Control.HPanelControl pnlTopLine;
    }
}