namespace SmartPIS
{
    partial class BaselineData
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BaselineData));
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.gv001 = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SQNO = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnUP = new Sedas.Control.HSedasSimpleButton1(this.components);
            this.btnDOWN = new Sedas.Control.HSedasSimpleButton1(this.components);
            this.button3 = new Sedas.Control.HSedasSimpleButton1(this.components);
            this.button2 = new Sedas.Control.HSedasSimpleButton1(this.components);
            this.gv002 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tbGross = new System.Windows.Forms.TextBox();
            this.label1 = new Sedas.Control.HLabelControl(this.components);
            this.cbHMTP = new Sedas.Control.HImageComboBoxEdit(this.components);
            this.button1 = new Sedas.Control.HSedasSimpleButton1(this.components);
            this.button4 = new Sedas.Control.HSedasSimpleButton1(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv002)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHMTP.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 119);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gv001);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnUP);
            this.splitContainer1.Panel2.Controls.Add(this.btnDOWN);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.button2);
            this.splitContainer1.Panel2.Controls.Add(this.gv002);
            this.splitContainer1.Panel2.Controls.Add(this.tbGross);
            this.splitContainer1.Size = new System.Drawing.Size(1152, 643);
            this.splitContainer1.SplitterDistance = 429;
            this.splitContainer1.TabIndex = 0;
            // 
            // gv001
            // 
            this.gv001.AllowUserToAddRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv001.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.gv001.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv001.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.SQNO});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(235)))), ((int)(((byte)(235)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.gv001.DefaultCellStyle = dataGridViewCellStyle2;
            this.gv001.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gv001.Location = new System.Drawing.Point(0, 0);
            this.gv001.MultiSelect = false;
            this.gv001.Name = "gv001";
            this.gv001.ReadOnly = true;
            this.gv001.RowHeadersWidth = 5;
            this.gv001.RowTemplate.Height = 23;
            this.gv001.Size = new System.Drawing.Size(427, 641);
            this.gv001.TabIndex = 0;
            this.gv001.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv001_CellClick);
            this.gv001.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.gv001.KeyDown += new System.Windows.Forms.KeyEventHandler(this.gv001_KeyDown);
            this.gv001.Resize += new System.EventHandler(this.gv001_Resize);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "순번";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 60;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "항목이름";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 310;
            // 
            // SQNO
            // 
            this.SQNO.HeaderText = "Column3";
            this.SQNO.Name = "SQNO";
            this.SQNO.ReadOnly = true;
            this.SQNO.Visible = false;
            // 
            // btnUP
            // 
            this.btnUP.Location = new System.Drawing.Point(20, 595);
            this.btnUP.LookAndFeel.SkinName = "My Basic";
            this.btnUP.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnUP.Name = "btnUP";
            this.btnUP.SedasButtonType = Sedas.Control.HSedasSimpleButton1.HSimpleButtonType.Null;
            this.btnUP.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnUP.Size = new System.Drawing.Size(34, 29);
            this.btnUP.TabIndex = 9;
            this.btnUP.Text = "▲";
            this.btnUP.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnDOWN
            // 
            this.btnDOWN.Location = new System.Drawing.Point(58, 595);
            this.btnDOWN.LookAndFeel.SkinName = "My Basic";
            this.btnDOWN.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnDOWN.Name = "btnDOWN";
            this.btnDOWN.SedasButtonType = Sedas.Control.HSedasSimpleButton1.HSimpleButtonType.Null;
            this.btnDOWN.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnDOWN.Size = new System.Drawing.Size(34, 29);
            this.btnDOWN.TabIndex = 8;
            this.btnDOWN.Text = "▼";
            this.btnDOWN.Click += new System.EventHandler(this.btnDOWN_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(536, 592);
            this.button3.LookAndFeel.SkinName = "My Basic";
            this.button3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.button3.Name = "button3";
            this.button3.SedasButtonType = Sedas.Control.HSedasSimpleButton1.HSimpleButtonType.Null;
            this.button3.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.button3.Size = new System.Drawing.Size(82, 35);
            this.button3.TabIndex = 7;
            this.button3.Text = "저 장";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(624, 592);
            this.button2.LookAndFeel.SkinName = "My Basic";
            this.button2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.button2.Name = "button2";
            this.button2.SedasButtonType = Sedas.Control.HSedasSimpleButton1.HSimpleButtonType.Null;
            this.button2.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.button2.Size = new System.Drawing.Size(82, 35);
            this.button2.TabIndex = 6;
            this.button2.Text = "삭 제";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // gv002
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.gv002.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.gv002.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gv002.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            this.gv002.Dock = System.Windows.Forms.DockStyle.Top;
            this.gv002.Location = new System.Drawing.Point(0, 0);
            this.gv002.MultiSelect = false;
            this.gv002.Name = "gv002";
            this.gv002.RowHeadersWidth = 5;
            this.gv002.RowTemplate.Height = 23;
            this.gv002.Size = new System.Drawing.Size(717, 577);
            this.gv002.TabIndex = 1;
            this.gv002.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv002_CellClick);
            this.gv002.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv002_CellValueChanged);
            this.gv002.Paint += new System.Windows.Forms.PaintEventHandler(this.gv002_Paint);
            this.gv002.Resize += new System.EventHandler(this.gv002_Resize);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "순번";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Visible = false;
            this.dataGridViewTextBoxColumn1.Width = 5;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "예문명칭";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 330;
            // 
            // tbGross
            // 
            this.tbGross.Location = new System.Drawing.Point(70, 89);
            this.tbGross.Multiline = true;
            this.tbGross.Name = "tbGross";
            this.tbGross.Size = new System.Drawing.Size(179, 200);
            this.tbGross.TabIndex = 0;
            this.tbGross.Visible = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(57, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "장 기 :";
            // 
            // cbHMTP
            // 
            this.cbHMTP.Items = ((System.Collections.ObjectModel.ObservableCollection<string>)(resources.GetObject("cbHMTP.Items")));
            this.cbHMTP.Location = new System.Drawing.Point(130, 34);
            this.cbHMTP.Name = "cbHMTP";
            this.cbHMTP.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.cbHMTP.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.cbHMTP.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.cbHMTP.Properties.Appearance.Options.UseBackColor = true;
            this.cbHMTP.Properties.Appearance.Options.UseBorderColor = true;
            this.cbHMTP.Properties.Appearance.Options.UseForeColor = true;
            this.cbHMTP.Properties.AppearanceDropDown.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.cbHMTP.Properties.AppearanceDropDown.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.cbHMTP.Properties.AppearanceDropDown.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.cbHMTP.Properties.AppearanceDropDown.Options.UseBackColor = true;
            this.cbHMTP.Properties.AppearanceDropDown.Options.UseBorderColor = true;
            this.cbHMTP.Properties.AppearanceDropDown.Options.UseForeColor = true;
            this.cbHMTP.Properties.AppearanceItemSelected.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.cbHMTP.Properties.AppearanceItemSelected.Options.UseBackColor = true;
            this.cbHMTP.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            serializableAppearanceObject1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            serializableAppearanceObject1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            serializableAppearanceObject1.Options.UseBackColor = true;
            serializableAppearanceObject1.Options.UseBorderColor = true;
            serializableAppearanceObject2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            serializableAppearanceObject2.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            serializableAppearanceObject2.Options.UseBackColor = true;
            serializableAppearanceObject2.Options.UseBorderColor = true;
            serializableAppearanceObject3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            serializableAppearanceObject3.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            serializableAppearanceObject3.Options.UseBackColor = true;
            serializableAppearanceObject3.Options.UseBorderColor = true;
            serializableAppearanceObject4.BackColor = System.Drawing.Color.DimGray;
            serializableAppearanceObject4.Options.UseBackColor = true;
            this.cbHMTP.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.cbHMTP.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.cbHMTP.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.cbHMTP.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.cbHMTP.SedasSelectedText = "";
            this.cbHMTP.SedasSelectedValue = "";
            this.cbHMTP.Size = new System.Drawing.Size(207, 18);
            this.cbHMTP.TabIndex = 2;
            this.cbHMTP.SelectedIndexChanged += new System.EventHandler(this.cbHMTP_SelectedIndexChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(601, 22);
            this.button1.LookAndFeel.SkinName = "My Basic";
            this.button1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.button1.Name = "button1";
            this.button1.SedasButtonType = Sedas.Control.HSedasSimpleButton1.HSimpleButtonType.Null;
            this.button1.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.button1.Size = new System.Drawing.Size(82, 35);
            this.button1.TabIndex = 3;
            this.button1.Text = "추 가";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1031, 20);
            this.button4.LookAndFeel.SkinName = "My Basic";
            this.button4.LookAndFeel.UseDefaultLookAndFeel = false;
            this.button4.Name = "button4";
            this.button4.SedasButtonType = Sedas.Control.HSedasSimpleButton1.HSimpleButtonType.Null;
            this.button4.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.button4.Size = new System.Drawing.Size(109, 47);
            this.button4.TabIndex = 6;
            this.button4.Text = "종 료";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // BaselineData
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 762);
            this.BackColor = Global.backColor;
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cbHMTP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "BaselineData";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "결과 기초 자료";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BaselineData_FormClosing);
            this.Load += new System.EventHandler(this.BaselineData_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.BaselineData_KeyDown);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gv002)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHMTP.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gv001;
        private Sedas.Control.HLabelControl label1;
        private Sedas.Control.HImageComboBoxEdit cbHMTP;
        private Sedas.Control.HSedasSimpleButton1 button1;
        private Sedas.Control.HSedasSimpleButton1 button4;
        private System.Windows.Forms.TextBox tbGross;
        private System.Windows.Forms.DataGridView gv002;
        private Sedas.Control.HSedasSimpleButton1 button3;
        private Sedas.Control.HSedasSimpleButton1 button2;
        private Sedas.Control.HSedasSimpleButton1 btnUP;
        private Sedas.Control.HSedasSimpleButton1 btnDOWN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SQNO;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}