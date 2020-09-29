namespace Sedas.Control
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.hComboBoxEdit1 = new Sedas.Control.HComboBoxEdit();
            this.hCheckEdit1 = new Sedas.Control.HCheckEdit();
            this.hTextEdit1 = new Sedas.Control.HTextEdit();
            this.hTabControl1 = new Sedas.Control.HTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.hCheckEdit2 = new Sedas.Control.HCheckEdit();
            this.hCheckEdit3 = new Sedas.Control.HCheckEdit();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            ((System.ComponentModel.ISupportInitialize)(this.hComboBoxEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCheckEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hTextEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hTabControl1)).BeginInit();
            this.hTabControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hCheckEdit2.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCheckEdit3.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // simpleButton1
            // 
            this.simpleButton1.Location = new System.Drawing.Point(30, 93);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(75, 23);
            this.simpleButton1.TabIndex = 0;
            this.simpleButton1.Text = "simpleButton1";
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(47, 209);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(70, 14);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "labelControl1";
            // 
            // hComboBoxEdit1
            // 
            this.hComboBoxEdit1.Location = new System.Drawing.Point(30, 159);
            this.hComboBoxEdit1.Name = "hComboBoxEdit1";
            this.hComboBoxEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.hComboBoxEdit1.Size = new System.Drawing.Size(100, 20);
            this.hComboBoxEdit1.TabIndex = 4;
            // 
            // hCheckEdit1
            // 
            this.hCheckEdit1.Location = new System.Drawing.Point(21, 229);
            this.hCheckEdit1.Name = "hCheckEdit1";
            this.hCheckEdit1.Properties.Caption = "hCheckEdit1";
            this.hCheckEdit1.SedasControlType = HCheckEdit.HCheckControlType.Null;
            this.hCheckEdit1.Size = new System.Drawing.Size(96, 19);
            this.hCheckEdit1.TabIndex = 3;
            // 
            // hTextEdit1
            // 
            this.hTextEdit1.Location = new System.Drawing.Point(30, 126);
            this.hTextEdit1.Name = "hTextEdit1";
            this.hTextEdit1.Size = new System.Drawing.Size(163, 20);
            this.hTextEdit1.TabIndex = 1;
            // 
            // hTabControl1
            // 
            this.hTabControl1.Location = new System.Drawing.Point(394, 232);
            this.hTabControl1.Name = "hTabControl1";
            this.hTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.hTabControl1.Size = new System.Drawing.Size(331, 137);
            this.hTabControl1.TabIndex = 6;
            this.hTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(325, 108);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(325, 108);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // radioButton1
            // 
            this.radioButton1.Font = new System.Drawing.Font("굴림", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.radioButton1.Location = new System.Drawing.Point(192, 153);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(142, 43);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // hCheckEdit2
            // 
            this.hCheckEdit2.Location = new System.Drawing.Point(122, 382);
            this.hCheckEdit2.Name = "hCheckEdit2";
            this.hCheckEdit2.Properties.Caption = "hCheckEdit2";
            this.hCheckEdit2.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgRadio1;
            this.hCheckEdit2.Properties.CheckBoxOptions.SvgImageSize = new System.Drawing.Size(22, 22);
            this.hCheckEdit2.SedasControlType = HCheckEdit.HCheckControlType.Null;
            this.hCheckEdit2.Size = new System.Drawing.Size(75, 26);
            this.hCheckEdit2.TabIndex = 9;
            // 
            // hCheckEdit3
            // 
            this.hCheckEdit3.Location = new System.Drawing.Point(224, 382);
            this.hCheckEdit3.Name = "hCheckEdit3";
            this.hCheckEdit3.Properties.Caption = "hCheckEdit3";
            this.hCheckEdit3.Properties.CheckBoxOptions.Style = DevExpress.XtraEditors.Controls.CheckBoxStyle.SvgRadio1;
            this.hCheckEdit3.Properties.CheckBoxOptions.SvgImageSize = new System.Drawing.Size(22, 22);
            this.hCheckEdit3.SedasControlType = HCheckEdit.HCheckControlType.Null;
            this.hCheckEdit3.Size = new System.Drawing.Size(75, 26);
            this.hCheckEdit3.TabIndex = 10;
            // 
            // dateEdit1
            // 
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(397, 84);
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(100, 20);
            this.dateEdit1.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.dateEdit1);
            this.Controls.Add(this.hCheckEdit3);
            this.Controls.Add(this.hCheckEdit2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.hTabControl1);
            this.Controls.Add(this.hComboBoxEdit1);
            this.Controls.Add(this.hCheckEdit1);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.hTextEdit1);
            this.Controls.Add(this.simpleButton1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.hComboBoxEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCheckEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hTextEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hTabControl1)).EndInit();
            this.hTabControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.hCheckEdit2.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hCheckEdit3.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private HTextEdit hTextEdit1;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private HCheckEdit hCheckEdit1;
        private HComboBoxEdit hComboBoxEdit1;
        private HTabControl hTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.RadioButton radioButton1;
        private HCheckEdit hCheckEdit2;
        private HCheckEdit hCheckEdit3;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        //private GridControl.HGridControl hGridControl1;
        //private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
    }
}

