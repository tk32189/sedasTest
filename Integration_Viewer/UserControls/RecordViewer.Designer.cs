namespace Integration_Viewer
{
    partial class RecordViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tlpMain = new Sedas.Control.HTableLayoutPanel(this.components);
            this.memoRecord = new Sedas.Control.HMemoEdit(this.components);
            this.tlpMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.memoRecord.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // tlpMain
            // 
            this.tlpMain.ColumnCount = 1;
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Controls.Add(this.memoRecord, 0, 0);
            this.tlpMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpMain.Location = new System.Drawing.Point(0, 0);
            this.tlpMain.Name = "tlpMain";
            this.tlpMain.RowCount = 1;
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpMain.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpMain.Size = new System.Drawing.Size(691, 457);
            this.tlpMain.TabIndex = 0;
            // 
            // memoRecord
            // 
            this.memoRecord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.memoRecord.Location = new System.Drawing.Point(3, 3);
            this.memoRecord.Name = "memoRecord";
            this.memoRecord.Properties.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
            this.memoRecord.Properties.Appearance.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
            this.memoRecord.Properties.Appearance.Options.UseBackColor = true;
            this.memoRecord.Properties.Appearance.Options.UseForeColor = true;
            this.memoRecord.Properties.LookAndFeel.SkinName = "My Basic";
            this.memoRecord.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.memoRecord.SedasControlType = Sedas.Control.ControlType.Kuh;
            this.memoRecord.Size = new System.Drawing.Size(685, 451);
            this.memoRecord.TabIndex = 0;
            // 
            // RecordViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpMain);
            this.Name = "RecordViewer";
            this.Size = new System.Drawing.Size(691, 457);
            this.tlpMain.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.memoRecord.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel tlpMain;
        private Sedas.Control.HMemoEdit memoRecord;
    }
}
