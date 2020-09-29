namespace SmartPIS
{
    partial class GrossBaseline
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GrossBaseline));
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
            this.btnAdd = new Sedas.Control.HSedasSimpleButton1(this.components);
            this.button3 = new Sedas.Control.HSedasSimpleButton1(this.components);
            this.tbGross = new Sedas.Control.HMemoEdit(this.components);
            this.label1 = new Sedas.Control.HLabelControl(this.components);
            this.cbHMTP = new Sedas.Control.HImageComboBoxEdit(this.components);
            this.button4 = new Sedas.Control.HSedasSimpleButton1(this.components);
            this.button2 = new Sedas.Control.HSedasSimpleButton1(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gv001)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGross.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHMTP.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitContainer1.Location = new System.Drawing.Point(0, 80);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.gv001);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.btnAdd);
            this.splitContainer1.Panel2.Controls.Add(this.button3);
            this.splitContainer1.Panel2.Controls.Add(this.tbGross);
            this.splitContainer1.Size = new System.Drawing.Size(1152, 682);
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
            this.gv001.Size = new System.Drawing.Size(427, 680);
            this.gv001.TabIndex = 0;
            this.gv001.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gv001_CellClick);
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
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(618, 633);
            this.btnAdd.LookAndFeel.SkinName = "My Basic";
            this.btnAdd.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.SedasButtonType = Sedas.Control.HSedasSimpleButton1.HSimpleButtonType.Null;
            this.btnAdd.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnAdd.Size = new System.Drawing.Size(82, 31);
            this.btnAdd.TabIndex = 12;
            this.btnAdd.Text = "추 가";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(519, 633);
            this.button3.LookAndFeel.SkinName = "My Basic";
            this.button3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.button3.Name = "button3";
            this.button3.SedasButtonType = Sedas.Control.HSedasSimpleButton1.HSimpleButtonType.Null;
            this.button3.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.button3.Size = new System.Drawing.Size(82, 31);
            this.button3.TabIndex = 11;
            this.button3.Text = "저 장";
            // 
            // tbGross
            // 
            this.tbGross.Location = new System.Drawing.Point(0, 2);
            this.tbGross.Name = "tbGross";
            this.tbGross.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.tbGross.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.tbGross.Properties.Appearance.Options.UseBackColor = true;
            this.tbGross.Properties.Appearance.Options.UseForeColor = true;
            this.tbGross.Properties.LookAndFeel.SkinName = "My Basic";
            this.tbGross.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.tbGross.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.tbGross.Size = new System.Drawing.Size(717, 600);
            this.tbGross.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Appearance.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Appearance.Options.UseFont = true;
            this.label1.Location = new System.Drawing.Point(57, 27);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 19);
            this.label1.TabIndex = 1;
            this.label1.Text = "구 분 :";
            this.label1.Visible = false;
            // 
            // cbHMTP
            // 
            this.cbHMTP.Items = ((System.Collections.ObjectModel.ObservableCollection<string>)(resources.GetObject("cbHMTP.Items")));
            this.cbHMTP.Location = new System.Drawing.Point(130, 22);
            this.cbHMTP.Name = "cbHMTP";
            this.cbHMTP.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.cbHMTP.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.cbHMTP.Properties.Appearance.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cbHMTP.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.cbHMTP.Properties.Appearance.Options.UseBackColor = true;
            this.cbHMTP.Properties.Appearance.Options.UseBorderColor = true;
            this.cbHMTP.Properties.Appearance.Options.UseFont = true;
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
            this.cbHMTP.Size = new System.Drawing.Size(207, 26);
            this.cbHMTP.TabIndex = 2;
            this.cbHMTP.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(1016, 16);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(454, 12);
            this.button2.LookAndFeel.SkinName = "My Basic";
            this.button2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.button2.Name = "button2";
            this.button2.SedasButtonType = Sedas.Control.HSedasSimpleButton1.HSimpleButtonType.Null;
            this.button2.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.button2.Size = new System.Drawing.Size(109, 47);
            this.button2.TabIndex = 8;
            this.button2.Text = "삭 제";
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // GrossBaseline
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1152, 762);
            this.BackColor = Global.backColor;
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.cbHMTP);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.splitContainer1);
            this.MaximizeBox = false;
            this.Name = "GrossBaseline";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Gross기초자료";
            this.Load += new System.EventHandler(this.GrossBaseline_Load);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gv001)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbGross.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cbHMTP.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView gv001;
        private Sedas.Control.HLabelControl label1;
        private Sedas.Control.HImageComboBoxEdit cbHMTP;
        private Sedas.Control.HSedasSimpleButton1 button4;
        private Sedas.Control.HMemoEdit tbGross;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn SQNO;
        private Sedas.Control.HSedasSimpleButton1 button2;
        private Sedas.Control.HSedasSimpleButton1 btnAdd;
        private Sedas.Control.HSedasSimpleButton1 button3;
    }
}