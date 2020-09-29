namespace TestProject
{
    partial class Form3
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
            this.hPanelControl1 = new Sedas.Control.HPanelControl();
            this.hPanelControl2 = new Sedas.Control.HPanelControl();
            this.hSimpleButton1 = new Sedas.Control.HSimpleButton();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.hFlowLayoutPanel1 = new Sedas.Control.HFlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).BeginInit();
            this.hPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl2)).BeginInit();
            this.hPanelControl2.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hPanelControl1
            // 
            this.hPanelControl1.Controls.Add(this.hPanelControl2);
            this.hPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.hPanelControl1.Name = "hPanelControl1";
            this.hPanelControl1.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.hPanelControl1.Size = new System.Drawing.Size(800, 450);
            this.hPanelControl1.TabIndex = 0;
            // 
            // hPanelControl2
            // 
            this.hPanelControl2.Controls.Add(this.hSimpleButton1);
            this.hPanelControl2.Controls.Add(this.xtraScrollableControl1);
            this.hPanelControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hPanelControl2.Location = new System.Drawing.Point(2, 2);
            this.hPanelControl2.Name = "hPanelControl2";
            this.hPanelControl2.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.hPanelControl2.Size = new System.Drawing.Size(796, 446);
            this.hPanelControl2.TabIndex = 0;
            // 
            // hSimpleButton1
            // 
            this.hSimpleButton1.Location = new System.Drawing.Point(77, 270);
            this.hSimpleButton1.Name = "hSimpleButton1";
            this.hSimpleButton1.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSimpleButton1.Size = new System.Drawing.Size(75, 23);
            this.hSimpleButton1.TabIndex = 1;
            this.hSimpleButton1.Text = "hSimpleButton1";
            this.hSimpleButton1.Click += new System.EventHandler(this.hSimpleButton1_Click);
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.hFlowLayoutPanel1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(2, 2);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(792, 152);
            this.xtraScrollableControl1.TabIndex = 0;
            // 
            // hFlowLayoutPanel1
            // 
            this.hFlowLayoutPanel1.AutoSize = true;
            this.hFlowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.hFlowLayoutPanel1.Name = "hFlowLayoutPanel1";
            this.hFlowLayoutPanel1.Size = new System.Drawing.Size(148, 67);
            this.hFlowLayoutPanel1.TabIndex = 0;
            this.hFlowLayoutPanel1.WrapContents = false;
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hPanelControl1);
            this.Name = "Form3";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).EndInit();
            this.hPanelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl2)).EndInit();
            this.hPanelControl2.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            this.xtraScrollableControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HPanelControl hPanelControl1;
        private Sedas.Control.HPanelControl hPanelControl2;
        private Sedas.Control.HSimpleButton hSimpleButton1;
        private Sedas.Control.HFlowLayoutPanel hFlowLayoutPanel1;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
    }
}