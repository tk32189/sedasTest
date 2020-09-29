namespace TestProject
{
    partial class Watcher
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
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.hPanelControl1 = new Sedas.Control.HPanelControl(this.components);
            this.btnLog = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.lstNotification = new System.Windows.Forms.ListBox();
            this.lblFile = new System.Windows.Forms.Label();
            this.btnWatchFile = new System.Windows.Forms.Button();
            this.btnBrowseFile = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkSubFolder = new System.Windows.Forms.CheckBox();
            this.rdbDir = new System.Windows.Forms.RadioButton();
            this.rdbFile = new System.Windows.Forms.RadioButton();
            this.txtFile = new Sedas.Control.HTextEdit(this.components);
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).BeginInit();
            this.hPanelControl1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.hPanelControl1, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(800, 450);
            this.tlpMain.TabIndex = 0;
            // 
            // hPanelControl1
            // 
            this.hPanelControl1.Controls.Add(this.txtFile);
            this.hPanelControl1.Controls.Add(this.btnLog);
            this.hPanelControl1.Controls.Add(this.label3);
            this.hPanelControl1.Controls.Add(this.lstNotification);
            this.hPanelControl1.Controls.Add(this.lblFile);
            this.hPanelControl1.Controls.Add(this.btnWatchFile);
            this.hPanelControl1.Controls.Add(this.btnBrowseFile);
            this.hPanelControl1.Controls.Add(this.groupBox1);
            this.hPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hPanelControl1.Location = new System.Drawing.Point(3, 3);
            this.hPanelControl1.Name = "hPanelControl1";
            this.hPanelControl1.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.hPanelControl1.Size = new System.Drawing.Size(794, 444);
            this.hPanelControl1.TabIndex = 0;
            // 
            // btnLog
            // 
            this.btnLog.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnLog.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnLog.Location = new System.Drawing.Point(55, 399);
            this.btnLog.Name = "btnLog";
            this.btnLog.Size = new System.Drawing.Size(139, 21);
            this.btnLog.TabIndex = 16;
            this.btnLog.Text = "Dump To Log";
            this.btnLog.UseVisualStyleBackColor = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(55, 165);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(125, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Change Notifications";
            // 
            // lstNotification
            // 
            this.lstNotification.FormattingEnabled = true;
            this.lstNotification.ItemHeight = 12;
            this.lstNotification.Location = new System.Drawing.Point(55, 180);
            this.lstNotification.Name = "lstNotification";
            this.lstNotification.Size = new System.Drawing.Size(537, 196);
            this.lstNotification.TabIndex = 13;
            // 
            // lblFile
            // 
            this.lblFile.AutoSize = true;
            this.lblFile.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFile.Location = new System.Drawing.Point(55, 92);
            this.lblFile.Name = "lblFile";
            this.lblFile.Size = new System.Drawing.Size(124, 13);
            this.lblFile.TabIndex = 11;
            this.lblFile.Text = "Select File/Directory";
            // 
            // btnWatchFile
            // 
            this.btnWatchFile.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnWatchFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnWatchFile.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnWatchFile.Location = new System.Drawing.Point(55, 133);
            this.btnWatchFile.Name = "btnWatchFile";
            this.btnWatchFile.Size = new System.Drawing.Size(139, 21);
            this.btnWatchFile.TabIndex = 12;
            this.btnWatchFile.Text = "Start Watching";
            this.btnWatchFile.UseVisualStyleBackColor = false;
            this.btnWatchFile.Click += new System.EventHandler(this.btnWatchFile_Click);
            // 
            // btnBrowseFile
            // 
            this.btnBrowseFile.BackColor = System.Drawing.Color.LightSkyBlue;
            this.btnBrowseFile.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowseFile.Location = new System.Drawing.Point(376, 106);
            this.btnBrowseFile.Name = "btnBrowseFile";
            this.btnBrowseFile.Size = new System.Drawing.Size(87, 21);
            this.btnBrowseFile.TabIndex = 15;
            this.btnBrowseFile.Text = "Browse";
            this.btnBrowseFile.UseVisualStyleBackColor = false;
            this.btnBrowseFile.Click += new System.EventHandler(this.btnBrowseFile_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkSubFolder);
            this.groupBox1.Controls.Add(this.rdbDir);
            this.groupBox1.Controls.Add(this.rdbFile);
            this.groupBox1.Location = new System.Drawing.Point(55, 9);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(390, 63);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Mode";
            // 
            // chkSubFolder
            // 
            this.chkSubFolder.AutoSize = true;
            this.chkSubFolder.Enabled = false;
            this.chkSubFolder.Location = new System.Drawing.Point(216, 42);
            this.chkSubFolder.Name = "chkSubFolder";
            this.chkSubFolder.Size = new System.Drawing.Size(129, 16);
            this.chkSubFolder.TabIndex = 2;
            this.chkSubFolder.Text = "Include Subfolders";
            this.chkSubFolder.UseVisualStyleBackColor = true;
            // 
            // rdbDir
            // 
            this.rdbDir.AutoSize = true;
            this.rdbDir.Location = new System.Drawing.Point(7, 39);
            this.rdbDir.Name = "rdbDir";
            this.rdbDir.Size = new System.Drawing.Size(111, 16);
            this.rdbDir.TabIndex = 1;
            this.rdbDir.Text = "Watch Directory";
            this.rdbDir.UseVisualStyleBackColor = true;
            // 
            // rdbFile
            // 
            this.rdbFile.AutoSize = true;
            this.rdbFile.Checked = true;
            this.rdbFile.Location = new System.Drawing.Point(7, 18);
            this.rdbFile.Name = "rdbFile";
            this.rdbFile.Size = new System.Drawing.Size(81, 16);
            this.rdbFile.TabIndex = 0;
            this.rdbFile.TabStop = true;
            this.rdbFile.Text = "Watch File";
            this.rdbFile.UseVisualStyleBackColor = true;
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(55, 108);
            this.txtFile.Name = "txtFile";
            this.txtFile.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtFile.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtFile.Properties.Appearance.Options.UseBackColor = true;
            this.txtFile.Properties.Appearance.Options.UseForeColor = true;
            this.txtFile.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtFile.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtFile.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtFile.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtFile.Size = new System.Drawing.Size(289, 16);
            this.txtFile.TabIndex = 17;
            // 
            // Watcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tlpMain);
            this.Name = "Watcher";
            this.Text = "Watcher";
            this.Load += new System.EventHandler(this.Watcher_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).EndInit();
            this.hPanelControl1.ResumeLayout(false);
            this.hPanelControl1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtFile.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private Sedas.Control.HPanelControl hPanelControl1;
        private System.Windows.Forms.Button btnLog;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lstNotification;
        private System.Windows.Forms.Label lblFile;
        private System.Windows.Forms.Button btnWatchFile;
        private System.Windows.Forms.Button btnBrowseFile;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.CheckBox chkSubFolder;
        private System.Windows.Forms.RadioButton rdbDir;
        private System.Windows.Forms.RadioButton rdbFile;
        private Sedas.Control.HTextEdit txtFile;
    }
}