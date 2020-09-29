namespace Integration_Viewer
{
    partial class AudioPlayer
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
            gTrackBar.ColorPack colorPack9 = new gTrackBar.ColorPack();
            gTrackBar.ColorPack colorPack10 = new gTrackBar.ColorPack();
            gTrackBar.ColorPack colorPack11 = new gTrackBar.ColorPack();
            gTrackBar.ColorPack colorPack12 = new gTrackBar.ColorPack();
            gTrackBar.ColorLinearGradient colorLinearGradient3 = new gTrackBar.ColorLinearGradient();
            this.tblMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.gTrackBar1 = new gTrackBar.gTrackBar();
            this.hTableLayoutPanel1 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.lblCurrentTime = new Sedas.Control.HLabelControl(this.components);
            this.lblTotalTime = new Sedas.Control.HLabelControl(this.components);
            this.tblController = new Sedas.Control.HTableLayoutPanel(this.components);
            this.btnFastBack = new Sedas.Control.HPictureEdit(this.components);
            this.btnPlay = new Sedas.Control.HPictureEdit(this.components);
            this.btnStop = new Sedas.Control.HPictureEdit(this.components);
            this.btnFastForward = new Sedas.Control.HPictureEdit(this.components);
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tblMain.SuspendLayout();
            this.hTableLayoutPanel1.SuspendLayout();
            this.tblController.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnFastBack.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFastForward.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tblMain
            // 
            this.tblMain.ColumnCount = 1;
            this.tblMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblMain.Controls.Add(this.gTrackBar1, 0, 0);
            this.tblMain.Controls.Add(this.hTableLayoutPanel1, 0, 1);
            this.tblMain.Controls.Add(this.tblController, 0, 2);
            this.tblMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblMain.Location = new System.Drawing.Point(0, 0);
            this.tblMain.Name = "tblMain";
            this.tblMain.RowCount = 3;
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tblMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblMain.Size = new System.Drawing.Size(460, 130);
            this.tblMain.TabIndex = 1;
            // 
            // gTrackBar1
            // 
            colorPack9.Border = System.Drawing.Color.Transparent;
            colorPack9.Face = System.Drawing.Color.Transparent;
            colorPack9.Highlight = System.Drawing.Color.Lavender;
            this.gTrackBar1.AButColor = colorPack9;
            this.gTrackBar1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.gTrackBar1.ArrowColorDown = System.Drawing.Color.White;
            this.gTrackBar1.ArrowColorHover = System.Drawing.Color.White;
            this.gTrackBar1.ArrowColorUp = System.Drawing.Color.White;
            this.gTrackBar1.BackColor = System.Drawing.Color.Transparent;
            colorPack10.Border = System.Drawing.Color.White;
            colorPack10.Face = System.Drawing.Color.White;
            colorPack10.Highlight = System.Drawing.Color.White;
            this.gTrackBar1.ColorDown = colorPack10;
            colorPack11.Border = System.Drawing.Color.White;
            colorPack11.Face = System.Drawing.Color.White;
            colorPack11.Highlight = System.Drawing.Color.White;
            this.gTrackBar1.ColorHover = colorPack11;
            colorPack12.Border = System.Drawing.Color.White;
            colorPack12.Face = System.Drawing.Color.White;
            colorPack12.Highlight = System.Drawing.Color.White;
            this.gTrackBar1.ColorUp = colorPack12;
            this.gTrackBar1.Label = null;
            this.gTrackBar1.LabelPadding = new System.Windows.Forms.Padding(0);
            this.gTrackBar1.Location = new System.Drawing.Point(10, 10);
            this.gTrackBar1.Margin = new System.Windows.Forms.Padding(10);
            this.gTrackBar1.Name = "gTrackBar1";
            this.gTrackBar1.Size = new System.Drawing.Size(440, 20);
            colorLinearGradient3.ColorA = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(114)))), ((int)(((byte)(105)))));
            colorLinearGradient3.ColorB = System.Drawing.Color.FromArgb(((int)(((byte)(253)))), ((int)(((byte)(114)))), ((int)(((byte)(105)))));
            this.gTrackBar1.SliderColorLow = colorLinearGradient3;
            this.gTrackBar1.SliderSize = new System.Drawing.Size(20, 20);
            this.gTrackBar1.SliderWidthHigh = 1F;
            this.gTrackBar1.SliderWidthLow = 1F;
            this.gTrackBar1.TabIndex = 0;
            this.gTrackBar1.TickThickness = 1F;
            this.gTrackBar1.Value = 0;
            this.gTrackBar1.ValueAdjusted = 0F;
            this.gTrackBar1.ValueBoxBorder = System.Drawing.Color.White;
            this.gTrackBar1.ValueBoxFontColor = System.Drawing.Color.White;
            this.gTrackBar1.ValueDivisor = gTrackBar.gTrackBar.eValueDivisor.e1;
            this.gTrackBar1.ValueStrFormat = null;
            // 
            // hTableLayoutPanel1
            // 
            this.hTableLayoutPanel1.ColumnCount = 3;
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.hTableLayoutPanel1.Controls.Add(this.lblCurrentTime, 0, 0);
            this.hTableLayoutPanel1.Controls.Add(this.lblTotalTime, 2, 0);
            this.hTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel1.Location = new System.Drawing.Point(3, 43);
            this.hTableLayoutPanel1.Name = "hTableLayoutPanel1";
            this.hTableLayoutPanel1.RowCount = 1;
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.Size = new System.Drawing.Size(454, 24);
            this.hTableLayoutPanel1.TabIndex = 1;
            // 
            // lblCurrentTime
            // 
            this.lblCurrentTime.Appearance.Font = new System.Drawing.Font("Noto Sans KR Regular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblCurrentTime.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblCurrentTime.Appearance.Options.UseFont = true;
            this.lblCurrentTime.Appearance.Options.UseForeColor = true;
            this.lblCurrentTime.Appearance.Options.UseTextOptions = true;
            this.lblCurrentTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblCurrentTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblCurrentTime.Location = new System.Drawing.Point(0, 0);
            this.lblCurrentTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblCurrentTime.Name = "lblCurrentTime";
            this.lblCurrentTime.Size = new System.Drawing.Size(100, 24);
            this.lblCurrentTime.TabIndex = 0;
            this.lblCurrentTime.Text = "00:00";
            // 
            // lblTotalTime
            // 
            this.lblTotalTime.Appearance.Font = new System.Drawing.Font("Noto Sans KR Regular", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.lblTotalTime.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
            this.lblTotalTime.Appearance.Options.UseFont = true;
            this.lblTotalTime.Appearance.Options.UseForeColor = true;
            this.lblTotalTime.Appearance.Options.UseTextOptions = true;
            this.lblTotalTime.Appearance.TextOptions.HAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.lblTotalTime.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTotalTime.Location = new System.Drawing.Point(354, 0);
            this.lblTotalTime.Margin = new System.Windows.Forms.Padding(0);
            this.lblTotalTime.Name = "lblTotalTime";
            this.lblTotalTime.Size = new System.Drawing.Size(100, 24);
            this.lblTotalTime.TabIndex = 1;
            this.lblTotalTime.Text = "00:00";
            // 
            // tblController
            // 
            this.tblController.ColumnCount = 6;
            this.tblController.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblController.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tblController.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tblController.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tblController.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 70F));
            this.tblController.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblController.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tblController.Controls.Add(this.btnFastBack, 1, 0);
            this.tblController.Controls.Add(this.btnPlay, 2, 0);
            this.tblController.Controls.Add(this.btnStop, 3, 0);
            this.tblController.Controls.Add(this.btnFastForward, 4, 0);
            this.tblController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblController.Location = new System.Drawing.Point(3, 73);
            this.tblController.Name = "tblController";
            this.tblController.RowCount = 1;
            this.tblController.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblController.Size = new System.Drawing.Size(454, 54);
            this.tblController.TabIndex = 2;
            // 
            // btnFastBack
            // 
            this.btnFastBack.EditValue = global::Integration_Viewer.Properties.Resources.ic_skip_prev;
            this.btnFastBack.Location = new System.Drawing.Point(90, 3);
            this.btnFastBack.Name = "btnFastBack";
            this.btnFastBack.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnFastBack.Properties.Appearance.Options.UseBackColor = true;
            this.btnFastBack.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnFastBack.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.btnFastBack.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.btnFastBack.Size = new System.Drawing.Size(64, 48);
            this.btnFastBack.TabIndex = 0;
            // 
            // btnPlay
            // 
            this.btnPlay.EditValue = global::Integration_Viewer.Properties.Resources.play;
            this.btnPlay.Location = new System.Drawing.Point(160, 3);
            this.btnPlay.Name = "btnPlay";
            this.btnPlay.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnPlay.Properties.Appearance.Options.UseBackColor = true;
            this.btnPlay.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnPlay.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.btnPlay.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.btnPlay.Size = new System.Drawing.Size(64, 48);
            this.btnPlay.TabIndex = 1;
            // 
            // btnStop
            // 
            this.btnStop.EditValue = global::Integration_Viewer.Properties.Resources.ic_stop;
            this.btnStop.Location = new System.Drawing.Point(230, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnStop.Properties.Appearance.Options.UseBackColor = true;
            this.btnStop.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnStop.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.btnStop.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.btnStop.Size = new System.Drawing.Size(64, 48);
            this.btnStop.TabIndex = 2;
            // 
            // btnFastForward
            // 
            this.btnFastForward.EditValue = global::Integration_Viewer.Properties.Resources.ic_skip_next;
            this.btnFastForward.Location = new System.Drawing.Point(300, 3);
            this.btnFastForward.Name = "btnFastForward";
            this.btnFastForward.Properties.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.btnFastForward.Properties.Appearance.Options.UseBackColor = true;
            this.btnFastForward.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.btnFastForward.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.btnFastForward.Properties.SizeMode = DevExpress.XtraEditors.Controls.PictureSizeMode.Zoom;
            this.btnFastForward.Size = new System.Drawing.Size(64, 48);
            this.btnFastForward.TabIndex = 4;
            // 
            // AudioPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tblMain);
            this.Name = "AudioPlayer";
            this.Size = new System.Drawing.Size(460, 130);
            this.tblMain.ResumeLayout(false);
            this.hTableLayoutPanel1.ResumeLayout(false);
            this.hTableLayoutPanel1.PerformLayout();
            this.tblController.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.btnFastBack.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnPlay.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnStop.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnFastForward.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tblMain;
        private gTrackBar.gTrackBar gTrackBar1;
        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel1;
        private Sedas.Control.HLabelControl lblCurrentTime;
        private Sedas.Control.HLabelControl lblTotalTime;
        private Sedas.Control.HTableLayoutPanel tblController;
        private Sedas.Control.HPictureEdit btnFastBack;
        private Sedas.Control.HPictureEdit btnPlay;
        private Sedas.Control.HPictureEdit btnStop;
        private Sedas.Control.HPictureEdit btnFastForward;
        private System.Windows.Forms.Timer timer1;
    }
}
