using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DevExpress.XtraEditors.Controls;
using System.Collections;
using System.Data;
using System.Drawing;
using DevExpress.LookAndFeel;
using System.Collections.ObjectModel;

namespace Sedas.Control
{
    public partial class HImageComboBoxEdit : DevExpress.XtraEditors.ImageComboBoxEdit
    {
        public HImageComboBoxEdit()
        {
            InitializeComponent();
        }

        public HImageComboBoxEdit(IContainer container)
        {
            
            container.Add(this);

            InitializeComponent();
            

        }

       

        //public void DataBinding<T>(List<T> listData, string value, string Description)
        //{
        //    if (listData != null && listData.Count > 0)
        //    {
        //        this.Properties.Items.Clear();

        //        for (int i = 0; i < listData.Count; i++)
        //        {
        //            T item = listData[i];

        //            string cdVal = item.GetType().GetProperty(value).GetValue(item, null).ToString();
        //            string CdValNm = item.GetType().GetProperty(Description).GetValue(item, null).ToString();

        //            ImageComboBoxItem imageComboBoxItem = new ImageComboBoxItem();
        //            imageComboBoxItem.Value = cdVal.ToString();
        //            imageComboBoxItem.Description = CdValNm.ToString();
        //            this.Properties.Items.Add(imageComboBoxItem);


        //        }
        //    }
        //}

        public void DataBindingFromDataTable(DataTable dt, string value, string description)
        {
            if (dt != null && dt.Rows.Count > 0)
            {
                this.Properties.Items.Clear();

                if (dt.Columns.Contains(value) == false || dt.Columns.Contains(description) == false) return;


                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    DataRow row = dt.Rows[i];

                    string cdVal = row[value].ToString();
                    string cdValNm = row[description].ToString();

                    ImageComboBoxItem imageComboBoxItem = new ImageComboBoxItem();
                    imageComboBoxItem.Value = cdVal;
                    imageComboBoxItem.Description = cdValNm;
                    this.Properties.Items.Add(imageComboBoxItem);
                }
            }
        }


        public void DataBindingFromArray(string[] array)
        {
            if (array != null && array.Count() > 0)
            {
                this.Properties.Items.Clear();

                //if (dt.Columns.Contains(value) == false || dt.Columns.Contains(description) == false) return;


                for (int i = 0; i < array.Count(); i++)
                {
                    string value = array.ElementAt(i);

                    ImageComboBoxItem imageComboBoxItem = new ImageComboBoxItem();
                    imageComboBoxItem.Value = value;
                    imageComboBoxItem.Description = value;
                    this.Properties.Items.Add(imageComboBoxItem);
                }
            }
        }

        private string selectedValue = string.Empty;

        
        public string SedasSelectedValue
        {
            get
            {
                if (this.EditValue != null)
                {
                    return this.EditValue.ToString();
                }
                else
                {
                    return "";
                }
            }

            set
            {

                if (this.Properties.Items != null && this.Properties.Items.Count > 0)
                {
                    ImageComboBoxItem selectedItem = this.Properties.Items.Where(e => e.Value.ToString() == value).FirstOrDefault();
                    if (selectedItem != null)
                    {
                        this.SelectedIndex = this.Properties.Items.IndexOf(selectedItem);
                    }
                }
                //selectedValue = value;
            }
        }

        public string SedasSelectedText
        {
            get
            {
                if (this.SelectedIndex >= 0)
                {
                    return this.Properties.Items[this.SelectedIndex].Description;
                }
                else
                {
                    return "";
                }
            }

            set
            {

                if (this.Properties.Items != null && this.Properties.Items.Count > 0)
                {
                    ImageComboBoxItem selectedItem = this.Properties.Items.Where(e => e.Description.ToString() == value).FirstOrDefault();
                    if (selectedItem != null)
                    {
                        this.SelectedIndex = this.Properties.Items.IndexOf(selectedItem);
                    }
                }
            }
        }




        private ControlType sedasControlType = ControlType.Null;

        public ControlType SedasControlType
        {
            get
            {
                return sedasControlType;
            }

            set
            {
                sedasControlType = value;
                SedasControlTypeChanged();
            }
        }

        private Color? sedasForeColor = null;
        public Color? SedasForeColor
        {
            get
            {
                return sedasForeColor;
            }

            set
            {
                sedasForeColor = value;

                if (value != null && value != Color.Empty)
                {
                    this.Properties.Appearance.ForeColor = value.Value;
                    this.Properties.AppearanceDropDown.ForeColor = value.Value;
                }
            }
        }



        Color backColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
        Color textColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
        Color buttonColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));
        Color borderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));

        private void SedasControlTypeChanged()
        {
            if (sedasControlType == ControlType.Kuh)
            {
                this.Properties.Appearance.BackColor = backColor;
                this.Properties.Appearance.Options.UseBackColor = true;
                if (SedasForeColor != null)
                {
                    this.Properties.Appearance.ForeColor = SedasForeColor.Value;
                    this.Properties.AppearanceDropDown.ForeColor = SedasForeColor.Value;
                }
                else
                {
                    this.Properties.Appearance.ForeColor = textColor;
                    this.Properties.AppearanceDropDown.ForeColor = textColor;
                }
                
                this.Properties.AppearanceDropDown.BackColor = backColor;
                this.Properties.AppearanceItemSelected.BackColor = backColor;
                this.Properties.AppearanceDropDown.BorderColor = borderColor;
                this.Properties.AppearanceDropDown.Options.UseBorderColor = true;
                this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
                this.Properties.Appearance.Options.UseBorderColor = true;
                this.Properties.Appearance.BorderColor = borderColor;

                if (this.Properties.Buttons == null || this.Properties.Buttons.Count == 0)
                {
                    this.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                        new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
                }

                if (this.Properties.Buttons != null && this.Properties.Buttons.Count > 0)
                {
                    this.Properties.Buttons[0].Appearance.BackColor = backColor;
                    this.Properties.Buttons[0].Appearance.BorderColor = buttonColor2;
                    this.Properties.Buttons[0].IsDefaultButton = true;
                    this.Properties.Buttons[0].AppearancePressed.BackColor = backColor;
                    this.Properties.Buttons[0].AppearancePressed.BorderColor = buttonColor2;
                    this.Properties.Buttons[0].AppearanceHovered.BackColor = backColor;
                    this.Properties.Buttons[0].AppearanceHovered.BorderColor = buttonColor2;
                    this.Properties.Buttons[0].AppearanceDisabled.BackColor = Color.DimGray;
                }

                
                this.Properties.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
                this.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
                this.Properties.ButtonsStyle = DevExpress.XtraEditors.Controls.BorderStyles.UltraFlat;
                this.LookAndFeel.SetSkinStyle(SkinSvgPalette.DefaultSkin.BlueDark);

                items = new ObservableCollection<string>();
                items.CollectionChanged += Items_CollectionChanged;
            }
        }

        System.Collections.ObjectModel.ObservableCollection<string> items = new System.Collections.ObjectModel.ObservableCollection<string>();

  
        public ObservableCollection<string> Items
        {
            get
            {
                return items;
            }

            set
            {
                items = value;
            }
        }

      

        private void Items_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            if (e.NewItems.Count > 0)
            {
                ImageComboBoxItem imageComboBoxItem = new ImageComboBoxItem();
                imageComboBoxItem.Value = e.NewItems[0].ToString();
                imageComboBoxItem.Description = e.NewItems[0].ToString();
                this.Properties.Items.Add(imageComboBoxItem);
            }
            //throw new NotImplementedException();
        }
    }
}
