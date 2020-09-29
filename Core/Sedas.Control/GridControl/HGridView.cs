using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using DevExpress.Skins;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Sedas.Control.GridControl
{
    public partial class HGridView : GridView
    {
        public HGridView()
        {

        }

        public HGridView(DevExpress.XtraGrid.GridControl gridControl) : base(gridControl)
        {
        }

        protected override GridColumnCollection CreateColumnCollection()
        {
            if (this.SedasControlType == ControlType.Kuh)
            {
                return new HGridColumnCollection(this, this.SedasControlType);
            }
            else
            {
                return new HGridColumnCollection(this);
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

        bool isSedasDefaultGrid = false; //평범한 그리드 형태의 컨트롤 속성만 주기 위해 사용

        public bool IsSedasDefaultGrid
        {
            get
            {
                return isSedasDefaultGrid;
            }

            set
            {
                isSedasDefaultGrid = value;

                if (value == true)
                {
                    SetDefaultControl();
                }
            }
        }

        private void SetDefaultControl()
        {
            //그 외 기본적으로 제거해야될 기본값 설정
            this.OptionsClipboard.AllowCopy = DevExpress.Utils.DefaultBoolean.False;
            this.OptionsClipboard.CopyCollapsedData = DevExpress.Utils.DefaultBoolean.False;
            this.OptionsClipboard.CopyColumnHeaders = DevExpress.Utils.DefaultBoolean.False;
            this.OptionsCustomization.AllowColumnMoving = false;
            this.OptionsCustomization.AllowFilter = false;
            this.OptionsCustomization.AllowSort = false;
            this.OptionsFind.AllowFindPanel = false;
            this.OptionsMenu.EnableColumnMenu = false;
            //this.OptionsSelection.MultiSelect = true;
            //this.OptionsView.ColumnAutoWidth = false;
            this.OptionsView.ShowFilterPanelMode = DevExpress.XtraGrid.Views.Base.ShowFilterPanelMode.Never;
            this.OptionsView.ShowGroupPanel = false;
            this.OptionsView.ShowIndicator = false;
        }


        Color borderColor = System.Drawing.Color.FromArgb(((int)(((byte)(54)))), ((int)(((byte)(61)))), ((int)(((byte)(90)))));
        Color cellColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
        //Color focusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(234)))), ((int)(((byte)(253)))));
        //Color focusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(110)))), ((int)(((byte)(191)))), ((int)(((byte)(186)))));
        Color focusedColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(122)))), ((int)(((byte)(199)))));

        /// <summary>
        /// name         : SedasControlTypeChanged
        /// desc         : 컨트롤 타입 변경시
        /// author       : 심우종
        /// create date  : 2020-06-09 12:41
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SedasControlTypeChanged()
        {
            //건대병원용 스타일
            if (this.sedasControlType == ControlType.Kuh)
            {
                if ( base.GridControl != null )
                {
                    base.GridControl.LookAndFeel.UseDefaultLookAndFeel = true;
                    Skin skin = GridSkins.GetSkin(DevExpress.LookAndFeel.UserLookAndFeel.Default.ActiveLookAndFeel);
                    SkinElement elem = skin[GridSkins.SkinBorder];
                    elem.Border.All = borderColor;
                }
                



                //비어있는 공간
                this.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(22)))), ((int)(((byte)(33)))));
                this.Appearance.Empty.Options.UseBackColor = true;

                //라인
                this.Appearance.HorzLine.BackColor = borderColor;
                this.Appearance.VertLine.BackColor = borderColor;

                //해더
                this.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
                this.Appearance.HeaderPanel.Options.UseBackColor = true;
                this.Appearance.HeaderPanel.BorderColor = borderColor;

                //포커스된 영역에 대한 처리
                this.Appearance.SelectedRow.BackColor = focusedColor;
                this.Appearance.FocusedRow.BackColor = focusedColor;
                this.Appearance.FocusedCell.BackColor = focusedColor;
                this.Appearance.HideSelectionRow.BackColor = focusedColor;

                //로우 컬러 처리
                this.Appearance.Row.BackColor = cellColor;
                this.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Flat;

                //컬럼 설정
                if (this.Columns != null && this.Columns.Count > 0)
                {
                    for (int i = 0; i < this.Columns.Count; i++)
                    {
                        this.Columns[i].AppearanceHeader.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(82)))), ((int)(((byte)(116)))));
                        this.Columns[i].AppearanceHeader.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(170)))), ((int)(((byte)(170)))), ((int)(((byte)(170)))));
                        this.Columns[i].AppearanceHeader.Options.UseBackColor = true;
                        this.Columns[i].AppearanceHeader.Options.UseForeColor = true;
                    }

                }


                this.CustomDrawColumnHeader -= HGridView_CustomDrawColumnHeader;
                this.CustomDrawColumnHeader += HGridView_CustomDrawColumnHeader;

                
            }
        }

        private void HGridView_CustomDrawColumnHeader(object sender, ColumnHeaderCustomDrawEventArgs e)
        {
            if (e.Column == null)
            {
                e.Info.AllowColoring = true;
            }
            else
            {
                e.DefaultDraw();

                using (Pen pen = new Pen(borderColor, 1))
                {
                    Rectangle rec = e.Bounds;
                    rec.X = rec.X - 1;
                    rec.Y = rec.Y - 1;
                    e.Graphics.DrawRectangle(pen, rec);
                }

                e.Handled = true;
            }
        }
    }
}
