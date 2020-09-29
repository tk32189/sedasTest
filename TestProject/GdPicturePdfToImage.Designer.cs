namespace TestProject
{
    partial class GdPicturePdfToImage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GdPicturePdfToImage));
            this.hSimpleButton1 = new Sedas.Control.HSimpleButton();
            this.SuspendLayout();
            // 
            // hSimpleButton1
            // 
            this.hSimpleButton1.Location = new System.Drawing.Point(108, 63);
            this.hSimpleButton1.Name = "hSimpleButton1";
            this.hSimpleButton1.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSimpleButton1.Size = new System.Drawing.Size(129, 58);
            this.hSimpleButton1.TabIndex = 0;
            this.hSimpleButton1.Text = "hSimpleButton1";
            this.hSimpleButton1.Click += new System.EventHandler(this.hSimpleButton1_Click);
            // 
            // GdPicturePdfToImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(702, 322);
            this.Controls.Add(this.hSimpleButton1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("GdPicturePdfToImage.IconOptions.Image")));
            this.Name = "GdPicturePdfToImage";
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HSimpleButton hSimpleButton1;
    }
}