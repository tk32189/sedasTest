namespace FileTransferServer
{
    partial class MainForm
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
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.tlpServerMain = new System.Windows.Forms.TableLayoutPanel();
            this.tlpCenter = new System.Windows.Forms.TableLayoutPanel();
            this.hTableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.hFlowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtRoot = new System.Windows.Forms.TextBox();
            this.hFlowLayoutPanel4 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnForderOpen = new System.Windows.Forms.Button();
            this.btnStart = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBackupList = new System.Windows.Forms.RichTextBox();
            this.txtBoxFileList = new System.Windows.Forms.RichTextBox();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.crossCheckState = new System.Windows.Forms.Label();
            this.tlpServerMain.SuspendLayout();
            this.tlpCenter.SuspendLayout();
            this.hTableLayoutPanel3.SuspendLayout();
            this.hFlowLayoutPanel3.SuspendLayout();
            this.hFlowLayoutPanel4.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBox1
            // 
            this.richTextBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox1.Location = new System.Drawing.Point(3, 38);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(1140, 304);
            this.richTextBox1.TabIndex = 7;
            this.richTextBox1.Text = "";
            // 
            // tlpServerMain
            // 
            this.tlpServerMain.ColumnCount = 1;
            this.tlpServerMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpServerMain.Controls.Add(this.tlpCenter, 0, 1);
            this.tlpServerMain.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tlpServerMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpServerMain.Location = new System.Drawing.Point(0, 0);
            this.tlpServerMain.Name = "tlpServerMain";
            this.tlpServerMain.RowCount = 2;
            this.tlpServerMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tlpServerMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpServerMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpServerMain.Size = new System.Drawing.Size(1152, 691);
            this.tlpServerMain.TabIndex = 0;
            // 
            // tlpCenter
            // 
            this.tlpCenter.ColumnCount = 1;
            this.tlpCenter.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpCenter.Controls.Add(this.hTableLayoutPanel3, 0, 0);
            this.tlpCenter.Controls.Add(this.richTextBox1, 0, 1);
            this.tlpCenter.Controls.Add(this.tableLayoutPanel1, 0, 3);
            this.tlpCenter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpCenter.Location = new System.Drawing.Point(3, 33);
            this.tlpCenter.Name = "tlpCenter";
            this.tlpCenter.RowCount = 4;
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 0F));
            this.tlpCenter.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpCenter.Size = new System.Drawing.Size(1146, 655);
            this.tlpCenter.TabIndex = 2;
            // 
            // hTableLayoutPanel3
            // 
            this.hTableLayoutPanel3.ColumnCount = 2;
            this.hTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.hTableLayoutPanel3.Controls.Add(this.hFlowLayoutPanel3, 0, 0);
            this.hTableLayoutPanel3.Controls.Add(this.hFlowLayoutPanel4, 1, 0);
            this.hTableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel3.Location = new System.Drawing.Point(0, 0);
            this.hTableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.hTableLayoutPanel3.Name = "hTableLayoutPanel3";
            this.hTableLayoutPanel3.RowCount = 1;
            this.hTableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel3.Size = new System.Drawing.Size(1146, 35);
            this.hTableLayoutPanel3.TabIndex = 2;
            // 
            // hFlowLayoutPanel3
            // 
            this.hFlowLayoutPanel3.Controls.Add(this.label2);
            this.hFlowLayoutPanel3.Controls.Add(this.txtIP);
            this.hFlowLayoutPanel3.Controls.Add(this.label3);
            this.hFlowLayoutPanel3.Controls.Add(this.txtPort);
            this.hFlowLayoutPanel3.Controls.Add(this.label5);
            this.hFlowLayoutPanel3.Controls.Add(this.txtRoot);
            this.hFlowLayoutPanel3.Location = new System.Drawing.Point(3, 3);
            this.hFlowLayoutPanel3.Name = "hFlowLayoutPanel3";
            this.hFlowLayoutPanel3.Size = new System.Drawing.Size(738, 29);
            this.hFlowLayoutPanel3.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(38, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "HOST";
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(47, 3);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(100, 21);
            this.txtIP.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(153, 7);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 12);
            this.label3.TabIndex = 5;
            this.label3.Text = "PORT";
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(197, 3);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(56, 21);
            this.txtPort.TabIndex = 7;
            // 
            // label5
            // 
            this.label5.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(259, 7);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(91, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "SERVER ROOT";
            // 
            // txtRoot
            // 
            this.txtRoot.Location = new System.Drawing.Point(356, 3);
            this.txtRoot.Name = "txtRoot";
            this.txtRoot.ReadOnly = true;
            this.txtRoot.Size = new System.Drawing.Size(184, 21);
            this.txtRoot.TabIndex = 9;
            // 
            // hFlowLayoutPanel4
            // 
            this.hFlowLayoutPanel4.Controls.Add(this.btnForderOpen);
            this.hFlowLayoutPanel4.Controls.Add(this.btnStart);
            this.hFlowLayoutPanel4.Dock = System.Windows.Forms.DockStyle.Right;
            this.hFlowLayoutPanel4.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.hFlowLayoutPanel4.Location = new System.Drawing.Point(943, 3);
            this.hFlowLayoutPanel4.Name = "hFlowLayoutPanel4";
            this.hFlowLayoutPanel4.Size = new System.Drawing.Size(200, 29);
            this.hFlowLayoutPanel4.TabIndex = 1;
            // 
            // btnForderOpen
            // 
            this.btnForderOpen.Location = new System.Drawing.Point(106, 3);
            this.btnForderOpen.Name = "btnForderOpen";
            this.btnForderOpen.Size = new System.Drawing.Size(91, 23);
            this.btnForderOpen.TabIndex = 0;
            this.btnForderOpen.Text = "받은폴더열기";
            this.btnForderOpen.UseVisualStyleBackColor = true;
            this.btnForderOpen.Click += new System.EventHandler(this.btnForderOpen_Click);
            // 
            // btnStart
            // 
            this.btnStart.Location = new System.Drawing.Point(25, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(75, 23);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "시작";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tableLayoutPanel1.Controls.Add(this.label6, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.label7, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtBackupList, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtBoxFileList, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(3, 348);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1140, 304);
            this.tableLayoutPanel1.TabIndex = 9;
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 12);
            this.label6.TabIndex = 9;
            this.label6.Text = "받은 파일 리스트";
            // 
            // label7
            // 
            this.label7.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(459, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(97, 12);
            this.label7.TabIndex = 10;
            this.label7.Text = "백업 파일 리스트";
            // 
            // txtBackupList
            // 
            this.txtBackupList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBackupList.Location = new System.Drawing.Point(459, 33);
            this.txtBackupList.Name = "txtBackupList";
            this.txtBackupList.Size = new System.Drawing.Size(678, 268);
            this.txtBackupList.TabIndex = 11;
            this.txtBackupList.Text = "";
            // 
            // txtBoxFileList
            // 
            this.txtBoxFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBoxFileList.Location = new System.Drawing.Point(3, 33);
            this.txtBoxFileList.Name = "txtBoxFileList";
            this.txtBoxFileList.Size = new System.Drawing.Size(450, 268);
            this.txtBoxFileList.TabIndex = 12;
            this.txtBoxFileList.Text = "";
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 400F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.crossCheckState, 1, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1152, 30);
            this.tableLayoutPanel2.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(214, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "File Transfer Server        V.2020908-1";
            // 
            // crossCheckState
            // 
            this.crossCheckState.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.crossCheckState.AutoSize = true;
            this.crossCheckState.Location = new System.Drawing.Point(403, 9);
            this.crossCheckState.Name = "crossCheckState";
            this.crossCheckState.Size = new System.Drawing.Size(0, 12);
            this.crossCheckState.TabIndex = 2;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 691);
            this.Controls.Add(this.tlpServerMain);
            this.Name = "MainForm";
            this.Text = "FILE Transfer Server";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tlpServerMain.ResumeLayout(false);
            this.tlpCenter.ResumeLayout(false);
            this.hTableLayoutPanel3.ResumeLayout(false);
            this.hFlowLayoutPanel3.ResumeLayout(false);
            this.hFlowLayoutPanel3.PerformLayout();
            this.hFlowLayoutPanel4.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.TableLayoutPanel tlpServerMain;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TableLayoutPanel tlpCenter;
        private System.Windows.Forms.TableLayoutPanel hTableLayoutPanel3;
        private System.Windows.Forms.FlowLayoutPanel hFlowLayoutPanel3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.FlowLayoutPanel hFlowLayoutPanel4;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.Button btnForderOpen;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtRoot;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RichTextBox txtBackupList;
        private System.Windows.Forms.RichTextBox txtBoxFileList;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label crossCheckState;
    }
}