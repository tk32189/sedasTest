namespace LogViewer
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
            DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
            DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.tlpMain = new Sedas.Control.HTableLayoutPanel();
            this.hPanelControl1 = new Sedas.Control.HPanelControl();
            this.txtRoot = new Sedas.Control.HTextEdit();
            this.hLabelControl7 = new Sedas.Control.HLabelControl();
            this.txtCode = new Sedas.Control.HTextEdit();
            this.hLabelControl6 = new Sedas.Control.HLabelControl();
            this.txtPtno = new Sedas.Control.HTextEdit();
            this.hLabelControl5 = new Sedas.Control.HLabelControl();
            this.txtPtoNo = new Sedas.Control.HTextEdit();
            this.hLabelControl4 = new Sedas.Control.HLabelControl();
            this.hLabelControl3 = new Sedas.Control.HLabelControl();
            this.txtEndTm = new Sedas.Control.HTextEdit();
            this.txtStTm = new Sedas.Control.HTextEdit();
            this.hLabelControl2 = new Sedas.Control.HLabelControl();
            this.hLabelControl1 = new Sedas.Control.HLabelControl();
            this.dtpDate = new Sedas.Control.HDateEdit();
            this.hSimpleButton1 = new Sedas.Control.HSimpleButton();
            this.grdOrder = new Sedas.Control.GridControl.HGridControl();
            this.grvOrder = new Sedas.Control.GridControl.HGridView();
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).BeginInit();
            this.hPanelControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoot.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPtno.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPtoNo.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndTm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStTm.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOrder)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 2;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Controls.Add(this.hPanelControl1, 0, 0);
            this.tlpMain.Controls.Add(this.grdOrder, 1, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.Size = new System.Drawing.Size(1290, 668);
            this.tlpMain.TabIndex = 1;
            // 
            // hPanelControl1
            // 
            this.hPanelControl1.Controls.Add(this.txtRoot);
            this.hPanelControl1.Controls.Add(this.hLabelControl7);
            this.hPanelControl1.Controls.Add(this.txtCode);
            this.hPanelControl1.Controls.Add(this.hLabelControl6);
            this.hPanelControl1.Controls.Add(this.txtPtno);
            this.hPanelControl1.Controls.Add(this.hLabelControl5);
            this.hPanelControl1.Controls.Add(this.txtPtoNo);
            this.hPanelControl1.Controls.Add(this.hLabelControl4);
            this.hPanelControl1.Controls.Add(this.hLabelControl3);
            this.hPanelControl1.Controls.Add(this.txtEndTm);
            this.hPanelControl1.Controls.Add(this.txtStTm);
            this.hPanelControl1.Controls.Add(this.hLabelControl2);
            this.hPanelControl1.Controls.Add(this.hLabelControl1);
            this.hPanelControl1.Controls.Add(this.dtpDate);
            this.hPanelControl1.Controls.Add(this.hSimpleButton1);
            this.hPanelControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hPanelControl1.Location = new System.Drawing.Point(3, 3);
            this.hPanelControl1.Name = "hPanelControl1";
            this.hPanelControl1.SedasControlType = Sedas.Control.HPanelControl.SedasPanelType.Null;
            this.hPanelControl1.Size = new System.Drawing.Size(294, 662);
            this.hPanelControl1.TabIndex = 0;
            // 
            // txtRoot
            // 
            this.txtRoot.Enabled = false;
            this.txtRoot.Location = new System.Drawing.Point(124, 7);
            this.txtRoot.Name = "txtRoot";
            this.txtRoot.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtRoot.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtRoot.Properties.Appearance.Options.UseBackColor = true;
            this.txtRoot.Properties.Appearance.Options.UseForeColor = true;
            this.txtRoot.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtRoot.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtRoot.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtRoot.Properties.ReadOnly = true;
            this.txtRoot.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtRoot.Size = new System.Drawing.Size(93, 16);
            this.txtRoot.TabIndex = 15;
            // 
            // hLabelControl7
            // 
            this.hLabelControl7.Location = new System.Drawing.Point(7, 9);
            this.hLabelControl7.Name = "hLabelControl7";
            this.hLabelControl7.Size = new System.Drawing.Size(100, 12);
            this.hLabelControl7.TabIndex = 14;
            this.hLabelControl7.Text = "네트워크 드라이브";
            // 
            // txtCode
            // 
            this.txtCode.Location = new System.Drawing.Point(88, 172);
            this.txtCode.Name = "txtCode";
            this.txtCode.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtCode.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtCode.Properties.Appearance.Options.UseBackColor = true;
            this.txtCode.Properties.Appearance.Options.UseForeColor = true;
            this.txtCode.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtCode.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtCode.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtCode.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtCode.Size = new System.Drawing.Size(93, 16);
            this.txtCode.TabIndex = 13;
            // 
            // hLabelControl6
            // 
            this.hLabelControl6.Location = new System.Drawing.Point(7, 175);
            this.hLabelControl6.Name = "hLabelControl6";
            this.hLabelControl6.Size = new System.Drawing.Size(46, 12);
            this.hLabelControl6.TabIndex = 12;
            this.hLabelControl6.Text = "CODE : ";
            // 
            // txtPtno
            // 
            this.txtPtno.Location = new System.Drawing.Point(88, 138);
            this.txtPtno.Name = "txtPtno";
            this.txtPtno.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtPtno.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtPtno.Properties.Appearance.Options.UseBackColor = true;
            this.txtPtno.Properties.Appearance.Options.UseForeColor = true;
            this.txtPtno.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtPtno.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtPtno.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPtno.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtPtno.Size = new System.Drawing.Size(93, 16);
            this.txtPtno.TabIndex = 11;
            // 
            // hLabelControl5
            // 
            this.hLabelControl5.Location = new System.Drawing.Point(7, 141);
            this.hLabelControl5.Name = "hLabelControl5";
            this.hLabelControl5.Size = new System.Drawing.Size(60, 12);
            this.hLabelControl5.TabIndex = 10;
            this.hLabelControl5.Text = "환자번호 : ";
            // 
            // txtPtoNo
            // 
            this.txtPtoNo.Location = new System.Drawing.Point(88, 105);
            this.txtPtoNo.Name = "txtPtoNo";
            this.txtPtoNo.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtPtoNo.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtPtoNo.Properties.Appearance.Options.UseBackColor = true;
            this.txtPtoNo.Properties.Appearance.Options.UseForeColor = true;
            this.txtPtoNo.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtPtoNo.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtPtoNo.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtPtoNo.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtPtoNo.Size = new System.Drawing.Size(93, 16);
            this.txtPtoNo.TabIndex = 9;
            // 
            // hLabelControl4
            // 
            this.hLabelControl4.Location = new System.Drawing.Point(7, 108);
            this.hLabelControl4.Name = "hLabelControl4";
            this.hLabelControl4.Size = new System.Drawing.Size(60, 12);
            this.hLabelControl4.TabIndex = 8;
            this.hLabelControl4.Text = "병리번호 : ";
            // 
            // hLabelControl3
            // 
            this.hLabelControl3.Location = new System.Drawing.Point(154, 78);
            this.hLabelControl3.Name = "hLabelControl3";
            this.hLabelControl3.Size = new System.Drawing.Size(9, 12);
            this.hLabelControl3.TabIndex = 7;
            this.hLabelControl3.Text = "~";
            // 
            // txtEndTm
            // 
            this.txtEndTm.Location = new System.Drawing.Point(169, 74);
            this.txtEndTm.Name = "txtEndTm";
            this.txtEndTm.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtEndTm.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtEndTm.Properties.Appearance.Options.UseBackColor = true;
            this.txtEndTm.Properties.Appearance.Options.UseForeColor = true;
            this.txtEndTm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtEndTm.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtEndTm.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtEndTm.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtEndTm.Size = new System.Drawing.Size(60, 16);
            this.txtEndTm.TabIndex = 6;
            // 
            // txtStTm
            // 
            this.txtStTm.Location = new System.Drawing.Point(88, 75);
            this.txtStTm.Name = "txtStTm";
            this.txtStTm.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.txtStTm.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.txtStTm.Properties.Appearance.Options.UseBackColor = true;
            this.txtStTm.Properties.Appearance.Options.UseForeColor = true;
            this.txtStTm.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.txtStTm.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.txtStTm.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtStTm.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.txtStTm.Size = new System.Drawing.Size(60, 16);
            this.txtStTm.TabIndex = 5;
            // 
            // hLabelControl2
            // 
            this.hLabelControl2.Location = new System.Drawing.Point(7, 77);
            this.hLabelControl2.Name = "hLabelControl2";
            this.hLabelControl2.Size = new System.Drawing.Size(76, 12);
            this.hLabelControl2.TabIndex = 4;
            this.hLabelControl2.Text = "시간(6자리) : ";
            // 
            // hLabelControl1
            // 
            this.hLabelControl1.Location = new System.Drawing.Point(7, 39);
            this.hLabelControl1.Name = "hLabelControl1";
            this.hLabelControl1.Size = new System.Drawing.Size(36, 12);
            this.hLabelControl1.TabIndex = 2;
            this.hLabelControl1.Text = "일자 : ";
            // 
            // dtpDate
            // 
            this.dtpDate.EditValue = null;
            this.dtpDate.Location = new System.Drawing.Point(55, 36);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.dtpDate.Properties.Appearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.dtpDate.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.dtpDate.Properties.Appearance.Options.UseBackColor = true;
            this.dtpDate.Properties.Appearance.Options.UseBorderColor = true;
            this.dtpDate.Properties.Appearance.Options.UseForeColor = true;
            this.dtpDate.Properties.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
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
            this.dtpDate.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
            this.dtpDate.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
            this.dtpDate.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dtpDate.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.dtpDate.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.dtpDate.Size = new System.Drawing.Size(100, 18);
            this.dtpDate.TabIndex = 1;
            // 
            // hSimpleButton1
            // 
            this.hSimpleButton1.Location = new System.Drawing.Point(38, 330);
            this.hSimpleButton1.Name = "hSimpleButton1";
            this.hSimpleButton1.SedasControlType = Sedas.Control.HSimpleButton.ButtonControlType.Null;
            this.hSimpleButton1.Size = new System.Drawing.Size(122, 39);
            this.hSimpleButton1.TabIndex = 0;
            this.hSimpleButton1.Text = "조회";
            this.hSimpleButton1.Click += new System.EventHandler(this.hSimpleButton1_Click);
            // 
            // grdOrder
            // 
            this.grdOrder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdOrder.Location = new System.Drawing.Point(303, 3);
            this.grdOrder.MainView = this.grvOrder;
            this.grdOrder.Name = "grdOrder";
            this.grdOrder.Size = new System.Drawing.Size(984, 662);
            this.grdOrder.TabIndex = 1;
            this.grdOrder.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grvOrder});
            // 
            // grvOrder
            // 
            this.grvOrder.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvOrder.Appearance.Empty.Options.UseBackColor = true;
            this.grvOrder.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvOrder.Appearance.FocusedCell.Options.UseBackColor = true;
            this.grvOrder.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvOrder.Appearance.FocusedRow.Options.UseBackColor = true;
            this.grvOrder.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
            this.grvOrder.Appearance.HeaderPanel.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvOrder.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.grvOrder.Appearance.HeaderPanel.Options.UseBorderColor = true;
            this.grvOrder.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvOrder.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.grvOrder.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvOrder.Appearance.HorzLine.Options.UseBackColor = true;
            this.grvOrder.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.grvOrder.Appearance.Row.Options.UseBackColor = true;
            this.grvOrder.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
            this.grvOrder.Appearance.SelectedRow.Options.UseBackColor = true;
            this.grvOrder.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
            this.grvOrder.Appearance.VertLine.Options.UseBackColor = true;
            this.grvOrder.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;
            this.grvOrder.GridControl = this.grdOrder;
            this.grvOrder.IsSedasDefaultGrid = false;
            this.grvOrder.Name = "grvOrder";
            this.grvOrder.SedasControlType = Sedas.Control.ControlType.Kuh;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1290, 668);
            this.Controls.Add(this.tlpMain);
            this.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("MainForm.IconOptions.Image")));
            this.Name = "MainForm";
            this.Text = "Log Viewer";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hPanelControl1)).EndInit();
            this.hPanelControl1.ResumeLayout(false);
            this.hPanelControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.txtRoot.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtCode.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPtno.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtPtoNo.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtEndTm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtStTm.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtpDate.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdOrder)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grvOrder)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private Sedas.Control.HPanelControl hPanelControl1;
        private Sedas.Control.HSimpleButton hSimpleButton1;
        private Sedas.Control.GridControl.HGridControl grdOrder;
        private Sedas.Control.GridControl.HGridView grvOrder;
        private Sedas.Control.HTextEdit txtPtno;
        private Sedas.Control.HLabelControl hLabelControl5;
        private Sedas.Control.HTextEdit txtPtoNo;
        private Sedas.Control.HLabelControl hLabelControl4;
        private Sedas.Control.HLabelControl hLabelControl3;
        private Sedas.Control.HTextEdit txtEndTm;
        private Sedas.Control.HTextEdit txtStTm;
        private Sedas.Control.HLabelControl hLabelControl2;
        private Sedas.Control.HLabelControl hLabelControl1;
        private Sedas.Control.HDateEdit dtpDate;
        private Sedas.Control.HTextEdit txtCode;
        private Sedas.Control.HLabelControl hLabelControl6;
        private Sedas.Control.HTextEdit txtRoot;
        private Sedas.Control.HLabelControl hLabelControl7;
    }
}