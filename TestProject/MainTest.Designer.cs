namespace TestProject
{
    partial class MainTest
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
            this.hSimpleButton2 = new Sedas.Control.HSimpleButton();
            this.hSimpleButton1 = new Sedas.Control.HSimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).BeginInit();
            this.hPanelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hPanelControl1
            // 
            this.hPanelControl1.Controls.Add(this.hSimpleButton2);
            this.hPanelControl1.Controls.Add(this.hSimpleButton1);
            this.hPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.hPanelControl1.Name = "hPanelControl1";
            this.hPanelControl1.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.hPanelControl1.Size = new System.Drawing.Size(572, 381);
            this.hPanelControl1.TabIndex = 0;
            // 
            // hSimpleButton2
            // 
            this.hSimpleButton2.Location = new System.Drawing.Point(49, 120);
            this.hSimpleButton2.Name = "hSimpleButton2";
            this.hSimpleButton2.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSimpleButton2.Size = new System.Drawing.Size(111, 47);
            this.hSimpleButton2.TabIndex = 1;
            this.hSimpleButton2.Text = "VIEWER";
            this.hSimpleButton2.Click += new System.EventHandler(this.hSimpleButton2_Click);
            // 
            // hSimpleButton1
            // 
            this.hSimpleButton1.Location = new System.Drawing.Point(49, 51);
            this.hSimpleButton1.Name = "hSimpleButton1";
            this.hSimpleButton1.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSimpleButton1.Size = new System.Drawing.Size(111, 47);
            this.hSimpleButton1.TabIndex = 0;
            this.hSimpleButton1.Text = "IIP";
            this.hSimpleButton1.Click += new System.EventHandler(this.hSimpleButton1_Click);
            // 
            // MainTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(572, 381);
            this.Controls.Add(this.hPanelControl1);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "MainTest";
            this.Text = "MainTest";
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).EndInit();
            this.hPanelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HPanelControl hPanelControl1;
        private Sedas.Control.HSimpleButton hSimpleButton2;
        private Sedas.Control.HSimpleButton hSimpleButton1;
    }
}