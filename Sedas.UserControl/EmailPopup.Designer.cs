namespace Sedas.UserControl
{
    partial class EmailPopup
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
            this.tlpMain = new Sedas.Control.HTableLayoutPanel();
            this.hFlowLayoutPanel1 = new Sedas.Control.HFlowLayoutPanel();
            this.btnSend = new Sedas.Control.HSedasSImpleButtonBlue();
            this.tlpMain.SuspendLayout();
            this.hFlowLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.hFlowLayoutPanel1, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 2;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(680, 443);
            this.tlpMain.TabIndex = 0;
            // 
            // hFlowLayoutPanel1
            // 
            this.hFlowLayoutPanel1.Controls.Add(this.btnSend);
            this.hFlowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.hFlowLayoutPanel1.Name = "hFlowLayoutPanel1";
            this.hFlowLayoutPanel1.Size = new System.Drawing.Size(345, 24);
            this.hFlowLayoutPanel1.TabIndex = 0;
            // 
            // btnSend
            // 
            this.btnSend.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnSend.Appearance.Options.UseForeColor = true;
            this.btnSend.Location = new System.Drawing.Point(3, 3);
            this.btnSend.LookAndFeel.SkinName = "My Basic";
            this.btnSend.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnSend.Name = "btnSend";
            this.btnSend.SedasButtonType = Sedas.Control.HSedasSImpleButtonBlue.HSimpleButtonType.Null;
            this.btnSend.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnSend.Size = new System.Drawing.Size(75, 23);
            this.btnSend.TabIndex = 0;
            this.btnSend.Text = "hSedasSImpleButtonBlue1";
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // EmailPopup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(680, 443);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.Name = "EmailPopup";
            this.Text = "EmailPopup";
            this.tlpMain.ResumeLayout(false);
            this.hFlowLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private Control.HTableLayoutPanel tlpMain;
        private Control.HFlowLayoutPanel hFlowLayoutPanel1;
        private Control.HSedasSImpleButtonBlue btnSend;
    }
}