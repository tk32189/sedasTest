namespace TestProject
{
    partial class transform
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
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).BeginInit();
            this.SuspendLayout();
            // 
            // hPanelControl1
            // 
            this.hPanelControl1.Location = new System.Drawing.Point(50, 94);
            this.hPanelControl1.Name = "hPanelControl1";
            this.hPanelControl1.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.hPanelControl1.Size = new System.Drawing.Size(200, 100);
            this.hPanelControl1.TabIndex = 0;
            // 
            // transform
            // 
            this.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.Appearance.Options.UseBackColor = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(290, 268);
            this.Controls.Add(this.hPanelControl1);
            this.Name = "transform";
            this.Text = "transform";
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HPanelControl hPanelControl1;
    }
}