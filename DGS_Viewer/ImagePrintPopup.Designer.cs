namespace DGS_Viewer
{
    partial class ImagePrintPopup
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImagePrintPopup));
            this.tlpMain = new Sedas.Control.HTableLayoutPanel();
            this.tableLayoutPanel17 = new System.Windows.Forms.TableLayoutPanel();
            this.btnPrint = new Sedas.Control.HSedasSimpleButton1();
            this.btnCancel = new Sedas.Control.HSedasSimpleButton1();
            this.grpControl1 = new Sedas.Control.HGroupControl();
            this.rdoSelect = new Sedas.Control.HCheckEdit();
            this.rdoAll = new Sedas.Control.HCheckEdit();
            this.grpControl2 = new Sedas.Control.HGroupControl();
            this.rdo2x2 = new Sedas.Control.HCheckEdit();
            this.rdo1x2 = new Sedas.Control.HCheckEdit();
            this.rdo1x1 = new Sedas.Control.HCheckEdit();
            this.grpControl3 = new Sedas.Control.HGroupControl();
            this.txtDignosis = new Sedas.Control.HMemoEdit();
            this.grpControl4 = new Sedas.Control.HGroupControl();
            this.txtComment = new Sedas.Control.HMemoEdit();
            this.tableLayoutPanel17.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl1)).BeginInit();
            this.grpControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdoSelect.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoAll.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl2)).BeginInit();
            this.grpControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rdo2x2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo1x2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo1x1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl3)).BeginInit();
            this.grpControl3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtDignosis.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl4)).BeginInit();
            this.grpControl4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(36)))), ((int)(((byte)(42)))), ((int)(((byte)(55)))));
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Controls.Add(this.grpControl1, 0, 0);
            this.tlpMain.Controls.Add(this.grpControl2, 0, 1);
            this.tlpMain.Controls.Add(this.grpControl3, 0, 2);
            this.tlpMain.Controls.Add(this.grpControl4, 0, 3);
            this.tlpMain.Controls.Add(this.tableLayoutPanel17, 0, 4);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 5;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 82F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 35F));
            this.tlpMain.Size = new System.Drawing.Size(300, 350);
            this.tlpMain.TabIndex = 0;
            // 
            // tableLayoutPanel17
            // 
            this.tableLayoutPanel17.ColumnCount = 2;
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel17.Controls.Add(this.btnPrint, 0, 0);
            this.tableLayoutPanel17.Controls.Add(this.btnCancel, 1, 0);
            this.tableLayoutPanel17.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel17.Location = new System.Drawing.Point(2, 316);
            this.tableLayoutPanel17.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel17.Name = "tableLayoutPanel17";
            this.tableLayoutPanel17.RowCount = 1;
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel17.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 32F));
            this.tableLayoutPanel17.Size = new System.Drawing.Size(296, 32);
            this.tableLayoutPanel17.TabIndex = 8;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.btnPrint.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnPrint.Appearance.Options.UseForeColor = true;
            this.btnPrint.Location = new System.Drawing.Point(7, 6);
            this.btnPrint.LookAndFeel.SkinName = "My Basic";
            this.btnPrint.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnPrint.Margin = new System.Windows.Forms.Padding(7, 2, 2, 2);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.SedasButtonType = Sedas.Control.HSedasSimpleButton1.HSimpleButtonType.Null;
            this.btnPrint.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnPrint.Size = new System.Drawing.Size(78, 19);
            this.btnPrint.TabIndex = 0;
            this.btnPrint.Text = "인 쇄";
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.btnCancel.Appearance.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Appearance.Options.UseForeColor = true;
            this.btnCancel.Location = new System.Drawing.Point(211, 6);
            this.btnCancel.LookAndFeel.SkinName = "My Basic";
            this.btnCancel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnCancel.Margin = new System.Windows.Forms.Padding(2, 2, 7, 2);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.SedasButtonType = Sedas.Control.HSedasSimpleButton1.HSimpleButtonType.Null;
            this.btnCancel.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.btnCancel.Size = new System.Drawing.Size(78, 19);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "취 소";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // grpControl1
            // 
            this.grpControl1.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpControl1.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grpControl1.Appearance.Options.UseBackColor = true;
            this.grpControl1.Appearance.Options.UseBorderColor = true;
            this.grpControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.grpControl1.Controls.Add(this.rdoSelect);
            this.grpControl1.Controls.Add(this.rdoAll);
            this.grpControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpControl1.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.grpControl1.Location = new System.Drawing.Point(7, 7);
            this.grpControl1.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.grpControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpControl1.Margin = new System.Windows.Forms.Padding(7);
            this.grpControl1.Name = "grpControl1";
            this.grpControl1.SedasControlType = Sedas.Control.HGroupControl.HGroupControlType.KuhLight;
            this.grpControl1.Size = new System.Drawing.Size(286, 68);
            this.grpControl1.TabIndex = 4;
            this.grpControl1.Text = "이미지 선택";
            // 
            // rdoSelect
            // 
            this.rdoSelect.Location = new System.Drawing.Point(144, 25);
            this.rdoSelect.Name = "rdoSelect";
            this.rdoSelect.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.rdoSelect.Properties.Appearance.Options.UseForeColor = true;
            this.rdoSelect.Properties.Caption = "선택한 영상";
            this.rdoSelect.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.rdoSelect.Properties.LookAndFeel.SkinName = "My Basic";
            this.rdoSelect.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.rdoSelect.Properties.RadioGroupIndex = 1;
            this.rdoSelect.SedasControlType = Sedas.Control.HCheckEdit.HCheckControlType.Kuh;
            this.rdoSelect.Size = new System.Drawing.Size(107, 28);
            this.rdoSelect.TabIndex = 6;
            this.rdoSelect.TabStop = false;
            // 
            // rdoAll
            // 
            this.rdoAll.EditValue = true;
            this.rdoAll.Location = new System.Drawing.Point(41, 25);
            this.rdoAll.Name = "rdoAll";
            this.rdoAll.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.rdoAll.Properties.Appearance.Options.UseForeColor = true;
            this.rdoAll.Properties.Caption = "전체 영상";
            this.rdoAll.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.rdoAll.Properties.LookAndFeel.SkinName = "My Basic";
            this.rdoAll.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.rdoAll.Properties.RadioGroupIndex = 1;
            this.rdoAll.SedasControlType = Sedas.Control.HCheckEdit.HCheckControlType.Kuh;
            this.rdoAll.Size = new System.Drawing.Size(97, 28);
            this.rdoAll.TabIndex = 5;
            // 
            // grpControl2
            // 
            this.grpControl2.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpControl2.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grpControl2.Appearance.Options.UseBackColor = true;
            this.grpControl2.Appearance.Options.UseBorderColor = true;
            this.grpControl2.AppearanceCaption.ForeColor = System.Drawing.Color.White;
            this.grpControl2.AppearanceCaption.Options.UseFont = true;
            this.grpControl2.AppearanceCaption.Options.UseForeColor = true;
            this.grpControl2.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.grpControl2.Controls.Add(this.rdo2x2);
            this.grpControl2.Controls.Add(this.rdo1x2);
            this.grpControl2.Controls.Add(this.rdo1x1);
            this.grpControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpControl2.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.grpControl2.Location = new System.Drawing.Point(7, 89);
            this.grpControl2.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.grpControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpControl2.Margin = new System.Windows.Forms.Padding(7);
            this.grpControl2.Name = "grpControl2";
            this.grpControl2.SedasControlType = Sedas.Control.HGroupControl.HGroupControlType.KuhLight;
            this.grpControl2.Size = new System.Drawing.Size(286, 68);
            this.grpControl2.TabIndex = 5;
            this.grpControl2.Text = "페이지 별 이미지 수";
            // 
            // rdo2x2
            // 
            this.rdo2x2.Location = new System.Drawing.Point(189, 25);
            this.rdo2x2.Name = "rdo2x2";
            this.rdo2x2.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.rdo2x2.Properties.Appearance.Options.UseForeColor = true;
            this.rdo2x2.Properties.Caption = "2 X 2";
            this.rdo2x2.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.rdo2x2.Properties.LookAndFeel.SkinName = "My Basic";
            this.rdo2x2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.rdo2x2.Properties.RadioGroupIndex = 2;
            this.rdo2x2.SedasControlType = Sedas.Control.HCheckEdit.HCheckControlType.Kuh;
            this.rdo2x2.Size = new System.Drawing.Size(75, 28);
            this.rdo2x2.TabIndex = 6;
            this.rdo2x2.TabStop = false;
            // 
            // rdo1x2
            // 
            this.rdo1x2.Location = new System.Drawing.Point(108, 25);
            this.rdo1x2.Name = "rdo1x2";
            this.rdo1x2.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.rdo1x2.Properties.Appearance.Options.UseForeColor = true;
            this.rdo1x2.Properties.Caption = "1 X 2";
            this.rdo1x2.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.rdo1x2.Properties.LookAndFeel.SkinName = "My Basic";
            this.rdo1x2.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.rdo1x2.Properties.RadioGroupIndex = 2;
            this.rdo1x2.SedasControlType = Sedas.Control.HCheckEdit.HCheckControlType.Kuh;
            this.rdo1x2.Size = new System.Drawing.Size(75, 28);
            this.rdo1x2.TabIndex = 5;
            this.rdo1x2.TabStop = false;
            // 
            // rdo1x1
            // 
            this.rdo1x1.Location = new System.Drawing.Point(27, 25);
            this.rdo1x1.Name = "rdo1x1";
            this.rdo1x1.Properties.Appearance.ForeColor = System.Drawing.Color.White;
            this.rdo1x1.Properties.Appearance.Options.UseForeColor = true;
            this.rdo1x1.Properties.Caption = "1 X 1";
            this.rdo1x1.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.Radio;
            this.rdo1x1.Properties.LookAndFeel.SkinName = "My Basic";
            this.rdo1x1.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.rdo1x1.Properties.RadioGroupIndex = 2;
            this.rdo1x1.SedasControlType = Sedas.Control.HCheckEdit.HCheckControlType.Kuh;
            this.rdo1x1.Size = new System.Drawing.Size(75, 28);
            this.rdo1x1.TabIndex = 4;
            this.rdo1x1.TabStop = false;
            // 
            // grpControl3
            // 
            this.grpControl3.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpControl3.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grpControl3.Appearance.Options.UseBackColor = true;
            this.grpControl3.Appearance.Options.UseBorderColor = true;
            this.grpControl3.AppearanceCaption.ForeColor = System.Drawing.Color.White;
            this.grpControl3.AppearanceCaption.Options.UseFont = true;
            this.grpControl3.AppearanceCaption.Options.UseForeColor = true;
            this.grpControl3.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.grpControl3.Controls.Add(this.txtDignosis);
            this.grpControl3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpControl3.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.grpControl3.Location = new System.Drawing.Point(7, 171);
            this.grpControl3.LookAndFeel.SkinName = "My Basic";
            this.grpControl3.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.grpControl3.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpControl3.Margin = new System.Windows.Forms.Padding(7);
            this.grpControl3.Name = "grpControl3";
            this.grpControl3.SedasControlType = Sedas.Control.HGroupControl.HGroupControlType.KuhLight;
            this.grpControl3.Size = new System.Drawing.Size(286, 61);
            this.grpControl3.TabIndex = 6;
            this.grpControl3.Text = "진 단 명";
            // 
            // txtDignosis
            // 
            this.txtDignosis.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtDignosis.Location = new System.Drawing.Point(2, 17);
            this.txtDignosis.Name = "txtDignosis";
            this.txtDignosis.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtDignosis.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtDignosis.Properties.Appearance.Options.UseBackColor = true;
            this.txtDignosis.Properties.Appearance.Options.UseForeColor = true;
            this.txtDignosis.Properties.LookAndFeel.SkinName = "My Basic";
            this.txtDignosis.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtDignosis.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtDignosis.Size = new System.Drawing.Size(282, 42);
            this.txtDignosis.TabIndex = 0;
            // 
            // grpControl4
            // 
            this.grpControl4.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.grpControl4.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grpControl4.Appearance.Options.UseBackColor = true;
            this.grpControl4.Appearance.Options.UseBorderColor = true;
            this.grpControl4.AppearanceCaption.ForeColor = System.Drawing.Color.White;
            this.grpControl4.AppearanceCaption.Options.UseFont = true;
            this.grpControl4.AppearanceCaption.Options.UseForeColor = true;
            this.grpControl4.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.grpControl4.Controls.Add(this.txtComment);
            this.grpControl4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpControl4.GroupStyle = DevExpress.Utils.GroupStyle.Light;
            this.grpControl4.Location = new System.Drawing.Point(7, 246);
            this.grpControl4.LookAndFeel.SkinName = "My Basic";
            this.grpControl4.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.grpControl4.LookAndFeel.UseDefaultLookAndFeel = false;
            this.grpControl4.Margin = new System.Windows.Forms.Padding(7);
            this.grpControl4.Name = "grpControl4";
            this.grpControl4.SedasControlType = Sedas.Control.HGroupControl.HGroupControlType.KuhLight;
            this.grpControl4.Size = new System.Drawing.Size(286, 61);
            this.grpControl4.TabIndex = 7;
            this.grpControl4.Text = "비  고";
            // 
            // txtComment
            // 
            this.txtComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtComment.Location = new System.Drawing.Point(2, 17);
            this.txtComment.Name = "txtComment";
            this.txtComment.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtComment.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtComment.Properties.Appearance.Options.UseBackColor = true;
            this.txtComment.Properties.Appearance.Options.UseForeColor = true;
            this.txtComment.Properties.LookAndFeel.SkinName = "My Basic";
            this.txtComment.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtComment.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtComment.Size = new System.Drawing.Size(282, 42);
            this.txtComment.TabIndex = 1;
            // 
            // ImagePrintPopup
            // 
            this.Appearance.Options.UseFont = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 350);
            this.Controls.Add(this.tlpMain);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("ImagePrintPopup.IconOptions.Image")));
            this.Name = "ImagePrintPopup";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "인   쇄";
            this.tableLayoutPanel17.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.grpControl1)).EndInit();
            this.grpControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdoSelect.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdoAll.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl2)).EndInit();
            this.grpControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.rdo2x2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo1x2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rdo1x1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl3)).EndInit();
            this.grpControl3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtDignosis.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grpControl4)).EndInit();
            this.grpControl4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.txtComment.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private Sedas.Control.HGroupControl grpControl2;
        private Sedas.Control.HGroupControl grpControl1;
        private Sedas.Control.HGroupControl grpControl3;
        private Sedas.Control.HGroupControl grpControl4;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel17;
        private Sedas.Control.HSedasSimpleButton1 btnPrint;
        private Sedas.Control.HSedasSimpleButton1 btnCancel;
        private Sedas.Control.HMemoEdit txtComment;
        private Sedas.Control.HMemoEdit txtDignosis;
        private Sedas.Control.HCheckEdit rdo2x2;
        private Sedas.Control.HCheckEdit rdo1x2;
        private Sedas.Control.HCheckEdit rdo1x1;
        private Sedas.Control.HCheckEdit rdoAll;
        private Sedas.Control.HCheckEdit rdoSelect;
    }
}