namespace SmartPIS
{
    partial class DiaSearch
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvList = new System.Windows.Forms.DataGridView();
            this.cPathologyID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cSex = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cAge = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbHMTP = new System.Windows.Forms.ComboBox();
            this.label3 = new Sedas.Control.HLabelControl();
            this.label2 = new Sedas.Control.HLabelControl();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new Sedas.Control.HLabelControl();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.btnExcel = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.검사코드 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.관심사유 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvList
            // 
            this.dgvList.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvList.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.cPathologyID,
            this.cID,
            this.cName,
            this.cSex,
            this.cAge,
            this.Column1,
            this.Column2,
            this.검사코드,
            this.관심사유});
            this.dgvList.Location = new System.Drawing.Point(12, 131);
            this.dgvList.Name = "dgvList";
            this.dgvList.RowHeadersVisible = false;
            this.dgvList.RowTemplate.Height = 25;
            this.dgvList.RowTemplate.ReadOnly = true;
            this.dgvList.Size = new System.Drawing.Size(1210, 799);
            this.dgvList.TabIndex = 0;
            // 
            // cPathologyID
            // 
            this.cPathologyID.HeaderText = "병리번호";
            this.cPathologyID.Name = "cPathologyID";
            this.cPathologyID.Width = 80;
            // 
            // cID
            // 
            this.cID.HeaderText = "환자번호";
            this.cID.Name = "cID";
            this.cID.Width = 80;
            // 
            // cName
            // 
            this.cName.HeaderText = "환자이름";
            this.cName.Name = "cName";
            this.cName.Width = 80;
            // 
            // cSex
            // 
            this.cSex.HeaderText = "성별";
            this.cSex.Name = "cSex";
            this.cSex.Width = 60;
            // 
            // cAge
            // 
            this.cAge.HeaderText = "나이";
            this.cAge.Name = "cAge";
            this.cAge.Width = 60;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "병변Block";
            this.Column1.Name = "Column1";
            // 
            // Column2
            // 
            this.Column2.HeaderText = "정상Block";
            this.Column2.Name = "Column2";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbHMTP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dateTimePicker2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.btnExcel);
            this.groupBox1.Controls.Add(this.btnExit);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Location = new System.Drawing.Point(12, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1210, 98);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "[ 조 회 조 건 ]";
            // 
            // cbHMTP
            // 
            this.cbHMTP.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbHMTP.FormattingEnabled = true;
            this.cbHMTP.Items.AddRange(new object[] {
            "Breast",
            "Cervix",
            "Colon",
            "Endometrial cancer",
            "Esophagus",
            "Kidney",
            "Liver Hepatectomy",
            "Liver Intrahepatic",
            "Liver meta",
            "Lung",
            "Ovary cancer",
            "Prostate",
            "Rectal",
            "Stomach gastrectomy",
            "Stomach GIST",
            "TESTIS",
            "Urinary bladder carcinoma",
            "Urinary bladder turb"});
            this.cbHMTP.Location = new System.Drawing.Point(92, 39);
            this.cbHMTP.Name = "cbHMTP";
            this.cbHMTP.Size = new System.Drawing.Size(144, 20);
            this.cbHMTP.TabIndex = 12;
            this.cbHMTP.SelectedIndexChanged += new System.EventHandler(this.cbHMTP_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "장기 구분 :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(257, 45);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 10;
            this.label2.Text = "접수 일자 :";
            // 
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(563, 40);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker2.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(543, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 12);
            this.label1.TabIndex = 8;
            this.label1.Text = "~";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(337, 40);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 7;
            // 
            // btnExcel
            // 
            this.btnExcel.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExcel.Location = new System.Drawing.Point(979, 32);
            this.btnExcel.Name = "btnExcel";
            this.btnExcel.Size = new System.Drawing.Size(98, 41);
            this.btnExcel.TabIndex = 6;
            this.btnExcel.Text = "엑셀 출력";
            this.btnExcel.UseVisualStyleBackColor = true;
            this.btnExcel.Click += new System.EventHandler(this.btnExcel_Click);
            // 
            // btnExit
            // 
            this.btnExit.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnExit.Location = new System.Drawing.Point(1093, 32);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(98, 41);
            this.btnExit.TabIndex = 5;
            this.btnExit.Text = "종  료";
            this.btnExit.UseVisualStyleBackColor = true;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(862, 32);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 41);
            this.btnSearch.TabIndex = 4;
            this.btnSearch.Text = "조  회";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // 검사코드
            // 
            this.검사코드.HeaderText = "검사코드";
            this.검사코드.Name = "검사코드";
            // 
            // 관심사유
            // 
            this.관심사유.HeaderText = "관심사유";
            this.관심사유.Name = "관심사유";
            // 
            // DiaSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 942);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvList);
            this.MaximizeBox = false;
            this.Name = "DiaSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "병리 결과 조회";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DiaSearch_FormClosing);
            this.Load += new System.EventHandler(this.DiaSearch_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnExcel;
        private System.Windows.Forms.DataGridViewTextBoxColumn cPathologyID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cID;
        private System.Windows.Forms.DataGridViewTextBoxColumn cName;
        private System.Windows.Forms.DataGridViewTextBoxColumn cSex;
        private System.Windows.Forms.DataGridViewTextBoxColumn cAge;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private Sedas.Control.HLabelControl label2;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private Sedas.Control.HLabelControl label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private Sedas.Control.HLabelControl label3;
        private System.Windows.Forms.ComboBox cbHMTP;
        private System.Windows.Forms.DataGridViewTextBoxColumn 검사코드;
        private System.Windows.Forms.DataGridViewTextBoxColumn 관심사유;
    }
}