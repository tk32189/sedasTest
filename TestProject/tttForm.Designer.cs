namespace TestProject
{
    partial class tttForm
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
            this.hLabelControl1 = new Sedas.Control.HLabelControl(this.components);
            this.SuspendLayout();
            // 
            // hLabelControl1
            // 
            this.hLabelControl1.Location = new System.Drawing.Point(152, 94);
            this.hLabelControl1.Name = "hLabelControl1";
            this.hLabelControl1.Size = new System.Drawing.Size(84, 12);
            this.hLabelControl1.TabIndex = 0;
            this.hLabelControl1.Text = "hLabelControl1";
            // 
            // tttForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.hLabelControl1);
            this.Name = "tttForm";
            this.Text = "tttForm";
            this.Load += new System.EventHandler(this.tttForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Sedas.Control.HLabelControl hLabelControl1;
    }
}