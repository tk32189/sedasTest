namespace DGS_Viewer
{
    partial class VersionInfoPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VersionInfoPopup));
            this.hPanelControl1 = new Sedas.Control.HPanelControl(this.components);
            this.btnConfirm = new Sedas.Control.HSimpleButton();
            this.hLabelControl2 = new Sedas.Control.HLabelControl(this.components);
            this.hLabelControl1 = new Sedas.Control.HLabelControl(this.components);
            this.imageBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).BeginInit();
            this.SuspendLayout();
            // 
            // hPanelControl1
            // 
            this.hPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.hPanelControl1.Name = "hPanelControl1";
            this.hPanelControl1.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.hPanelControl1.Size = new System.Drawing.Size(334, 81);
            this.hPanelControl1.Controls.Add(btnConfirm);
            this.hPanelControl1.Controls.Add(hLabelControl2);
            this.hPanelControl1.Controls.Add(hLabelControl1);
            this.hPanelControl1.Controls.Add(imageBox);
            this.hPanelControl1.TabIndex = 0;
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(245, 16);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnConfirm.Size = new System.Drawing.Size(75, 27);
            this.btnConfirm.TabIndex = 3;
            this.btnConfirm.Text = "확인";
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // hLabelControl2
            // 
            this.hLabelControl2.Location = new System.Drawing.Point(98, 48);
            this.hLabelControl2.Name = "hLabelControl2";
            this.hLabelControl2.Size = new System.Drawing.Size(103, 12);
            this.hLabelControl2.TabIndex = 2;
            this.hLabelControl2.Text = "Copyright (c) 2007";
            // 
            // hLabelControl1
            // 
            this.hLabelControl1.Location = new System.Drawing.Point(98, 19);
            this.hLabelControl1.Name = "hLabelControl1";
            this.hLabelControl1.Size = new System.Drawing.Size(118, 12);
            this.hLabelControl1.TabIndex = 1;
            this.hLabelControl1.Text = "DGS_Viewer 버전 2.0";
            // 
            // imageBox
            // 
            this.imageBox.Location = new System.Drawing.Point(25, 23);
            this.imageBox.Name = "imageBox";
            this.imageBox.Size = new System.Drawing.Size(57, 45);
            this.imageBox.TabIndex = 4;
            this.imageBox.TabStop = false;
            // 
            // VersionInfoPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 81);
            this.Controls.Add(this.hPanelControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("VersionInfoPopup.IconOptions.Image")));
            this.Name = "VersionInfoPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DGS_Viewer 정보";
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imageBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HPanelControl hPanelControl1;
        private Sedas.Control.HSimpleButton btnConfirm;
        private Sedas.Control.HLabelControl hLabelControl2;
        private Sedas.Control.HLabelControl hLabelControl1;
        private System.Windows.Forms.PictureBox imageBox;
    }
}