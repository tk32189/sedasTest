using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.Utils.Drawing;

namespace TestProject
{
    public class hotTrackHelper
    {
        public hotTrackHelper(GridView view)
        {
            _View = view;
            view.GridControl.PaintEx += GridControl_PaintEx;
            //view.MouseMove += new MouseEventHandler(view_MouseMove);
        }

        private void GridControl_PaintEx(object sender, DevExpress.XtraGrid.PaintExEventArgs e)
        {


            e.Cache.DrawRectangle(new Pen(Brushes.Red, _BorderWidth), e.ClipRectangle);

            //DrawHotTrackedCell(e.Cache);
        }


        private int _BorderWidth = 4;
        private GridCell _HotTrackedCell;
        private readonly GridView _View;
        public GridCell HotTrackedCell
        {
            get { return _HotTrackedCell; }
            set
            {
                RefreshCell(_HotTrackedCell);
                _HotTrackedCell = value;
            }
        }

        public Rectangle GetCellBounds(GridCell cell)
        {
            if (cell == null)
                return Rectangle.Empty;
            GridViewInfo info = _View.GetViewInfo() as GridViewInfo;
            GridCellInfo cellInfo = info.GetGridCellInfo(cell.RowHandle, cell.Column);
            return cellInfo.Bounds;
        }


        private void UpdateHotTrackedCell(Point location)
        {
            GridHitInfo hi = _View.CalcHitInfo(location);
            if (hi.HitTest == GridHitTest.Row || hi.HitTest == GridHitTest.RowEdge)
                return;
            if (hi.InRowCell)
            {
                if (_View.IsRowVisible(hi.RowHandle) == RowVisibleState.Visible)
                {
                    HotTrackedCell = new GridCell(hi.RowHandle, hi.Column);
                    return;
                }
            }
            HotTrackedCell = null;
        }


        void view_MouseMove(object sender, MouseEventArgs e)
        {
            UpdateHotTrackedCell(e.Location);
        }


        private void RefreshCell(GridCell cell)
        {
            if (cell == null)
                return;
            Rectangle rect = GetCellBounds(cell);
            rect.Inflate(_BorderWidth, _BorderWidth);
            _View.InvalidateRect(rect);
        }

        private void DrawHotTrackedCell(GraphicsCache cache)
        {
            Rectangle bounds = GetCellBounds(HotTrackedCell);
            cache.DrawRectangle(new Pen(Brushes.Black, _BorderWidth), bounds);
        }
    }
}
