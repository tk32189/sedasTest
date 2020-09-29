namespace Sedas.Control
{
    partial class Form2
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
            this.hSimpleButton1 = new Sedas.Control.HSimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).BeginInit();
            this.hPanelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // hPanelControl1
            // 
            this.hPanelControl1.Controls.Add(this.hSimpleButton1);
            this.hPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hPanelControl1.Location = new System.Drawing.Point(0, 0);
            this.hPanelControl1.Name = "hPanelControl1";
            this.hPanelControl1.Size = new System.Drawing.Size(800, 450);
            this.hPanelControl1.TabIndex = 0;
            // 
            // hSimpleButton1
            // 
            this.hSimpleButton1.Location = new System.Drawing.Point(120, 94);
            this.hSimpleButton1.LookAndFeel.SkinName = "My Basic";
            this.hSimpleButton1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.hSimpleButton1.Name = "hSimpleButton1";
            this.hSimpleButton1.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSimpleButton1.Size = new System.Drawing.Size(110, 32);
            this.hSimpleButton1.TabIndex = 0;
            this.hSimpleButton1.Text = "hSimpleButton1";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hPanelControl1);
            this.Name = "Form2";
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).EndInit();
            this.hPanelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HPanelControl hPanelControl1;
        private HSimpleButton hSimpleButton1;
    }
}