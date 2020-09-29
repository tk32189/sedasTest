namespace Integration_Viewer
{
    partial class ImageThumbnail
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
            DevExpress.XtraEditors.TableLayout.ItemTemplateBase itemTemplateBase1 = new DevExpress.XtraEditors.TableLayout.ItemTemplateBase();
            DevExpress.XtraEditors.TableLayout.TableColumnDefinition tableColumnDefinition1 = new DevExpress.XtraEditors.TableLayout.TableColumnDefinition();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement1 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            DevExpress.XtraEditors.TableLayout.TemplatedItemElement templatedItemElement2 = new DevExpress.XtraEditors.TableLayout.TemplatedItemElement();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImageThumbnail));
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition1 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            DevExpress.XtraEditors.TableLayout.TableRowDefinition tableRowDefinition2 = new DevExpress.XtraEditors.TableLayout.TableRowDefinition();
            this.hTableLayoutPanel1 = new Sedas.Control.HTableLayoutPanel(this.components);
            this.listBoxControl = new DevExpress.XtraEditors.ListBoxControl();
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl)).BeginInit();
            this.SuspendLayout();
            // 
            // hTableLayoutPanel1
            // 
            this.hTableLayoutPanel1.ColumnCount = 1;
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.hTableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hTableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.hTableLayoutPanel1.Name = "hTableLayoutPanel1";
            this.hTableLayoutPanel1.RowCount = 1;
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.hTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 17F));
            this.hTableLayoutPanel1.Size = new System.Drawing.Size(917, 184);
            this.hTableLayoutPanel1.TabIndex = 0;
            // 
            // listBoxControl
            // 
            this.listBoxControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBoxControl.HorizontalScrollbar = true;
            this.listBoxControl.ItemHeight = 103;
            this.listBoxControl.Location = new System.Drawing.Point(3, 3);
            this.listBoxControl.MultiColumn = true;
            this.listBoxControl.Name = "listBoxControl";
            this.listBoxControl.Size = new System.Drawing.Size(911, 178);
            this.listBoxControl.TabIndex = 3;
            itemTemplateBase1.Columns.Add(tableColumnDefinition1);
            templatedItemElement1.FieldName = "imageName";
            templatedItemElement1.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement1.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement1.RowIndex = 1;
            templatedItemElement1.Text = "imageName";
            templatedItemElement1.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement2.FieldName = "imageData";
            templatedItemElement2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("resource.Image")));
            templatedItemElement2.ImageOptions.ImageAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            templatedItemElement2.ImageOptions.ImageScaleMode = DevExpress.XtraEditors.TileItemImageScaleMode.ZoomInside;
            templatedItemElement2.Text = "imageData";
            templatedItemElement2.TextAlignment = DevExpress.XtraEditors.TileItemContentAlignment.MiddleCenter;
            itemTemplateBase1.Elements.Add(templatedItemElement1);
            itemTemplateBase1.Elements.Add(templatedItemElement2);
            itemTemplateBase1.Name = "template1";
            tableRowDefinition1.Length.Value = 92D;
            tableRowDefinition2.Length.Value = 24D;
            itemTemplateBase1.Rows.Add(tableRowDefinition1);
            itemTemplateBase1.Rows.Add(tableRowDefinition2);
            this.listBoxControl.Templates.Add(itemTemplateBase1);
            // 
            // ImageThumbnail
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.hTableLayoutPanel1);
            this.Name = "ImageThumbnail";
            this.Size = new System.Drawing.Size(917, 184);
            this.Load += new System.EventHandler(this.ImageThumbnail_Load);
            ((System.ComponentModel.ISupportInitialize)(this.listBoxControl)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Sedas.Control.HTableLayoutPanel hTableLayoutPanel1;
        private DevExpress.XtraEditors.ListBoxControl listBoxControl;
    }
}
