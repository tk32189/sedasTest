using DevExpress.Utils.Drawing;
using DevExpress.XtraTab;
using DevExpress.XtraTab.Drawing;
using DevExpress.XtraTab.Registrator;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sedas.Control
{
    class TabControlSkinTabPainter : SkinTabPainter
    {
        public TabControlSkinTabPainter(IXtraTab tabControl)
            : base(tabControl)
        {

        }



        protected override void DrawHeaderBackground(TabDrawArgs e)
        {
            base.DrawHeaderBackground(e);
            var rectangle = e.Bounds;
            rectangle.Height = rectangle.Height - 22;
            rectangle.Y = rectangle.Y + 22;
            ControlPaint.DrawBorder(e.Graphics, rectangle, borderColor, 1, ButtonBorderStyle.Solid
                                                                       , borderColor, 0, ButtonBorderStyle.Solid
                                                                       , borderColor, 1, ButtonBorderStyle.Solid
                                                                       , borderColor, 1, ButtonBorderStyle.Solid);
        }

        //protected override void DrawTabPage(TabDrawArgs e)
        //{
        //    base.DrawHeaderBackground(e);
        //    ControlPaint.DrawBorder(e.Graphics, e.Bounds, borderColor2, 1, ButtonBorderStyle.Solid
        //                                                               , borderColor2, 1, ButtonBorderStyle.Solid
        //                                                               , borderColor2, 1, ButtonBorderStyle.Solid
        //                                                               , borderColor2, 1, ButtonBorderStyle.Solid);
        //}

        //Color red = Color.Red;
        Color borderColor = Color.FromArgb(36, 84, 136);
        Color borderColor2 = Color.Red;
        Color selectedBackColor = Color.FromArgb(17, 17, 22);
        protected override void DrawHeaderPage(TabDrawArgs e, DevExpress.XtraTab.ViewInfo.BaseTabRowViewInfo row, DevExpress.XtraTab.ViewInfo.BaseTabPageViewInfo pInfo)
        {
            base.DrawHeaderPage(e, row, pInfo);
            Rectangle rect = pInfo.Bounds;
            if (pInfo.PageState == ObjectState.Selected)
            {
                var rectangle = e.Bounds;


                Brush brush = new SolidBrush(selectedBackColor);
                e.Graphics.FillRectangle(brush, row.SelectedPage.Bounds);

                ControlPaint.DrawBorder(e.Graphics, rect, borderColor, 1, ButtonBorderStyle.Solid
                                                                      , borderColor, 1, ButtonBorderStyle.Solid
                                                                      , borderColor, 1, ButtonBorderStyle.Solid
                                                                      , borderColor, 0, ButtonBorderStyle.Solid);
                DrawHeaderPageImageText(e, pInfo);
                DrawHeaderFocus(e, pInfo);
            }
            else
            {
                var rectangle = e.Bounds;
                ControlPaint.DrawBorder(e.Graphics, rect, borderColor, 0, ButtonBorderStyle.Solid
                                                                      , borderColor, 0, ButtonBorderStyle.Solid
                                                                      , borderColor, 0, ButtonBorderStyle.Solid
                                                                      , borderColor, 1, ButtonBorderStyle.Solid);
            }


            Rectangle rowRect = row.Bounds;

            ControlPaint.DrawBorder(e.Graphics, rowRect, borderColor, 0, ButtonBorderStyle.Solid
                                                                       , borderColor, 0, ButtonBorderStyle.Solid
                                                                       , borderColor, 0, ButtonBorderStyle.Solid
                                                                       , borderColor, 1, ButtonBorderStyle.Solid);

        }
    }

    public class SedasTabControlSkinViewInfoRegistrator : SkinViewInfoRegistrator
    {
        public SedasTabControlSkinViewInfoRegistrator()
            : base()
        {

        }
        public override string ViewName
        {
            get
            {
                return "Sedas";
            }
        }
        public override DevExpress.XtraTab.Drawing.BaseTabPainter CreatePainter(DevExpress.XtraTab.IXtraTab tabControl)
        {
            return new TabControlSkinTabPainter(tabControl);
        }
    }
}
