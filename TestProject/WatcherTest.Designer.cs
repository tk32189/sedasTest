namespace TestProject
{
    partial class WatcherTest
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
            this.hPanelControl1 = new Sedas.Control.HPanelControl();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.btnPath = new Sedas.Control.HSimpleButton();
            this.txtPath = new Sedas.Control.HTextEdit();
            this.btnStart = new Sedas.Control.HSimpleButton();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).BeginInit();
            this.hPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.hPanelControl1, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(891, 378);
            this.tlpMain.TabIndex = 0;
            // 
            // hPanelControl1
            // 
            this.hPanelControl1.Controls.Add(this.richTextBox1);
            this.hPanelControl1.Controls.Add(this.btnPath);
            this.hPanelControl1.Controls.Add(this.txtPath);
            this.hPanelControl1.Controls.Add(this.btnStart);
            this.hPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hPanelControl1.Location = new System.Drawing.Point(3, 3);
            this.hPanelControl1.Name = "hPanelControl1";
            this.hPanelControl1.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.hPanelControl1.Size = new System.Drawing.Size(885, 372);
            this.hPanelControl1.TabIndex = 0;
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(39, 135);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(620, 228);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // btnPath
            // 
            this.btnPath.Location = new System.Drawing.Point(342, 50);
            this.btnPath.Name = "btnPath";
            this.btnPath.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnPath.Size = new System.Drawing.Size(52, 23);
            this.btnPath.TabIndex = 2;
            this.btnPath.Text = "...";
            this.btnPath.Click += new System.EventHandler(this.btnPath_Click);
            // 
            // txtPath
            // 
            this.txtPath.Location = new System.Drawing.Point(39, 55);
            this.txtPath.Name = "txtPath";
            this.txtPath.SedasControlType = Sedas.Control.ControlType.Null;
            this.txtPath.Size = new System.Drawing.Size(297, 18);
            this.txtPath.TabIndex = 1;
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(48, 91);
            this.btnStart.Name = "btnStart";
            this.btnStart.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 0;
            this.btnStart.Text = "실행";
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // WatcherTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(891, 378);
            this.Controls.Add(this.tlpMain);
            this.Name = "WatcherTest";
            this.Text = "WatcherTest";
            this.Load += new System.EventHandler(this.WatcherTest_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).EndInit();
            this.hPanelControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtPath.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private Sedas.Control.HPanelControl hPanelControl1;
        private Sedas.Control.HSimpleButton btnPath;
        private Sedas.Control.HTextEdit txtPath;
        private Sedas.Control.HSimpleButton btnStart;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}