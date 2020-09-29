using System.Drawing;

namespace DGS_Viewer
{
    partial class ImageContainer
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.pnlMain = new DevExpress.XtraEditors.PanelControl();
            this.tlpMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpTop = new System.Windows.Forms.TableLayoutPanel();
            this.lblPtoNo = new DevExpress.XtraEditors.LabelControl();
            this.lblImageNum = new DevExpress.XtraEditors.LabelControl();
            this.tlpBottom = new System.Windows.Forms.TableLayoutPanel();
            this.lblImageInfo = new DevExpress.XtraEditors.LabelControl();
            this.pictureEdit = new DevExpress.XtraEditors.PictureEdit();
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).BeginInit();
            this.pnlMain.SuspendLayout();
            this.tlpMain.SuspendLayout();
            this.tlpTop.SuspendLayout();
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
            this.pnlMain.Size = new System.Drawing.Size(251, 229);
            this.pnlMain.TabIndex = 0;
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
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.tlpMain.Size = new System.Drawing.Size(245, 223);
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
            this.tlpTop.Controls.Add(this.lblPtoNo, 0, 0);
            this.tlpTop.Controls.Add(this.lblImageNum, 1, 0);
            this.tlpTop.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpTop.Location = new System.Drawing.Point(0, 0);
            this.tlpTop.Margin = new System.Windows.Forms.Padding(0);
            this.tlpTop.Name = "tlpTop";
            this.tlpTop.RowCount = 1;
            this.tlpTop.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpTop.Size = new System.Drawing.Size(245, 28);
            this.tlpTop.TabIndex = 0;
            this.tlpTop.Click += new System.EventHandler(this.tableLayoutPanel1_Click);
            this.tlpTop.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tlpMain_MouseDoubleClick);
            // 
            // lblPtoNo
            // 
            this.lblPtoNo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblPtoNo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblPtoNo.Appearance.Options.UseForeColor = true;
            this.lblPtoNo.Location = new System.Drawing.Point(1, 8);
            this.lblPtoNo.LookAndFeel.UseDefaultLookAndFeel = false;
            this.lblPtoNo.Margin = new System.Windows.Forms.Padding(1);
            this.lblPtoNo.Name = "lblPtoNo";
            this.lblPtoNo.Size = new System.Drawing.Size(50, 12);
            this.lblPtoNo.TabIndex = 0;
            this.lblPtoNo.Text = "S2008131";
            this.lblPtoNo.Click += new System.EventHandler(this.imageBox_Click);
            this.lblPtoNo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseDoubleClick);
            // 
            // lblImageNum
            // 
            this.lblImageNum.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImageNum.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblImageNum.Appearance.Options.UseForeColor = true;
            this.lblImageNum.Location = new System.Drawing.Point(226, 8);
            this.lblImageNum.Margin = new System.Windows.Forms.Padding(1);
            this.lblImageNum.Name = "lblImageNum";
            this.lblImageNum.Size = new System.Drawing.Size(6, 12);
            this.lblImageNum.TabIndex = 1;
            this.lblImageNum.Text = "1";
            this.lblImageNum.Click += new System.EventHandler(this.imageBox_Click);
            this.lblImageNum.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseDoubleClick);
            // 
            // tlpBottom
            // 
            this.tlpBottom.BackColor = System.Drawing.Color.Transparent;
            this.tlpBottom.ColumnCount = 1;
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpBottom.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpBottom.Controls.Add(this.lblImageInfo, 0, 0);
            this.tlpBottom.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpBottom.Location = new System.Drawing.Point(0, 195);
            this.tlpBottom.Margin = new System.Windows.Forms.Padding(0);
            this.tlpBottom.Name = "tlpBottom";
            this.tlpBottom.RowCount = 1;
            this.tlpBottom.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tlpBottom.Size = new System.Drawing.Size(245, 28);
            this.tlpBottom.TabIndex = 1;
            this.tlpBottom.Click += new System.EventHandler(this.imageBox_Click);
            this.tlpBottom.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.tlpMain_MouseDoubleClick);
            // 
            // lblImageInfo
            // 
            this.lblImageInfo.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblImageInfo.Appearance.ForeColor = System.Drawing.Color.Black;
            this.lblImageInfo.Appearance.Options.UseForeColor = true;
            this.lblImageInfo.Location = new System.Drawing.Point(1, 8);
            this.lblImageInfo.Margin = new System.Windows.Forms.Padding(1);
            this.lblImageInfo.Name = "lblImageInfo";
            this.lblImageInfo.Size = new System.Drawing.Size(119, 12);
            this.lblImageInfo.TabIndex = 1;
            this.lblImageInfo.Text = "A202020202020202.jap";
            this.lblImageInfo.Click += new System.EventHandler(this.imageBox_Click);
            this.lblImageInfo.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseDoubleClick);
            // 
            // pictureEdit
            // 
            this.pictureEdit.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureEdit.Location = new System.Drawing.Point(3, 28);
            this.pictureEdit.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.pictureEdit.Name = "pictureEdit";
            this.pictureEdit.Properties.Appearance.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pictureEdit.Properties.Appearance.Options.UseBackColor = true;
            this.pictureEdit.Properties.ShowCameraMenuItem = DevExpress.XtraEditors.Controls.CameraMenuItemVisibility.Auto;
            this.pictureEdit.Size = new System.Drawing.Size(239, 167);
            this.pictureEdit.TabIndex = 2;
            this.pictureEdit.Click += new System.EventHandler(this.imageBox_Click);
            this.pictureEdit.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureEdit_MouseDoubleClick);
            // 
            // ImageContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.pnlMain);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "ImageContainer";
            this.Size = new System.Drawing.Size(251, 229);
            this.Load += new System.EventHandler(this.ImageContainer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pnlMain)).EndInit();
            this.pnlMain.ResumeLayout(false);
            this.tlpMain.ResumeLayout(false);
            this.tlpTop.ResumeLayout(false);
            this.tlpTop.PerformLayout();
            this.tlpBottom.ResumeLayout(false);
            this.tlpBottom.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureEdit.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl pnlMain;
        private System.Windows.Forms.TableLayoutPanel tlpMain;
        private System.Windows.Forms.TableLayoutPanel tlpTop;
        private DevExpress.XtraEditors.LabelControl lblPtoNo;
        private DevExpress.XtraEditors.LabelControl lblImageNum;
        private System.Windows.Forms.TableLayoutPanel tlpBottom;
        private DevExpress.XtraEditors.LabelControl lblImageInfo;
        private DevExpress.XtraEditors.PictureEdit pictureEdit;
    }
}
