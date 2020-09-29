using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Diagnostics;

namespace SedasPhotoMagic.Classes
{
    [Serializable]
    public class GridObject
    {
        #region 격자디자인변수
        public bool isFullGrid { get; set; } // 전체 격자 여부
        public int gridHThick { get; set; } // 격자 가로 두께
        public int gridVThick { get; set; } // 격자 세로 두께
        public Color gridColor { get; set; } // 격자 색
        #endregion

        #region 변수선언
        public float[] RowHs;//행 높이 배열
        public float[] ColumnWs;//열 폭 배령
        public RectangleF GridRect { get; set; } // 그리드 사각형
        public List<Cell> listCells { get; set; } // 셀리스트
        private int SIZE_NODE_RECT = 10; // Gizmo 크기
        #endregion

        #region 함수
        public GridObject() { }

        //전체나 일부 격자를 생성시 사용
        // 전체인 경우 int col, int row=0, 일부인 경우 float gwidth, float gheight =0 으로 하고 계산
        public GridObject(RectangleF GridRect, float gwidth, float gheight, int col, int row, bool isPageAll, WorkSpace ws)
        {
            try
            {
                this.GridRect = GridRect;
                SIZE_NODE_RECT = ws.SIZE_NODE_RECT;
                this.isFullGrid = isPageAll;
                if (isPageAll)
                {
                    gwidth =ws.pixelPerCm * gwidth;
                    gheight = ws.pixelPerCm * gheight;
                    col = (int)(ws.paperSize.Width / gwidth) + 1;
                    row = (int)(ws.paperSize.Height / gheight) + 1;
                }
                else
                {
                    gwidth = (GridRect.Width / col);
                    gheight = (GridRect.Width / row);
                }
                RowHs = new float[row];
                for (int i = 0; i < row - 1; i++) RowHs[i] = gheight;
                ColumnWs = new float[col];
                for (int i = 0; i < col - 1; i++) ColumnWs[i] = gwidth;
                RowHs[row - 1] = GridRect.Height - (row - 1) * gheight;
                ColumnWs[col - 1] = GridRect.Width - (col - 1) * gwidth;

                listCells = new List<Cell>();
                for (int r = 0; r < row; r++)
                {
                    for (int c = 0; c < col; c++) listCells.Add(new Cell(r, c));
                }
                SetAllCellXY();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }

        }
        
        //디자인 설정하기
        public void setDesign(int gridHThick, int gridVThick, Color gridColor)
        {
            try
            {
                this.gridHThick = gridHThick;
                this.gridVThick = gridVThick;
                this.gridColor = gridColor;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }

        }
        
        //셀 사각형 구하기
        public RectangleF getCellRect(Cell cell)
        {
            try
            {
                return new RectangleF(cell.x, cell.y, ColumnWs[cell.c], RowHs[cell.r]);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return new RectangleF(0, 0, 0, 0);
            }

        }

        //변경사항으로 모든 셀의 위치 조절
        public void SetAllCellXY()
        {
            try
            {
                float x = GridRect.X, y = GridRect.Y;
                for (int c = 0; c < ColumnWs.Length; c++)
                {
                    foreach (Cell cell in listCells.Where(p => p.c == c)) cell.x = x;
                    x += ColumnWs[c];
                }
                for (int r = 0; r < RowHs.Length; r++)
                {
                    foreach (Cell cell in listCells.Where(p => p.r == r)) cell.y = y;
                    y += RowHs[r];
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }

        }

        //셀 크기 변경
        public void changeCellSize(Cell cell, float deltaWidth, float deltaHeight, Gizmo gizmo)
        {
            try
            {
                int r = cell.r, c = cell.c;
                if (gizmo == Gizmo.UpMiddle)
                {
                    if (r == 0 || deltaHeight == 0) return;
                    if (RowHs[r - 1] + deltaHeight < 1 || RowHs[r] - deltaHeight < 1) return;
                    RowHs[r - 1] += deltaHeight;
                    RowHs[r] -= deltaHeight;
                }
                else if (gizmo == Gizmo.BottomMiddle)
                {
                    if (r == RowHs.Length - 1 || deltaHeight == 0) return;
                    if (RowHs[r + 1] - deltaHeight < 1 || RowHs[r] + deltaHeight < 1) return;
                    RowHs[r + 1] -= deltaHeight;
                    RowHs[r] += deltaHeight;
                }
                else if (gizmo == Gizmo.LeftMiddle)
                {
                    if (c == 0 || deltaWidth == 0) return;
                    if (ColumnWs[c - 1] + deltaWidth < 1 || ColumnWs[c] - deltaWidth < 1) return;
                    ColumnWs[c - 1] += deltaWidth;
                    ColumnWs[c] -= deltaWidth;
                }
                else if (gizmo == Gizmo.RightMiddle)
                {
                    if (c == ColumnWs.Length - 1 || deltaWidth == 0) return;
                    if (ColumnWs[c + 1] - deltaWidth < 1 || ColumnWs[c] + deltaWidth < 1) return;
                    ColumnWs[c + 1] -= deltaWidth;
                    ColumnWs[c] += deltaWidth;
                }
                SetAllCellXY();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }

        }

        //격자 생성 중 전체 크기 변경
        public void changeGridRectInDrag(RectangleF rect)
        {
            try
            {
                float w, h;
                this.GridRect = rect;
                w =(GridRect.Width / ColumnWs.Length);
                h = (GridRect.Height / RowHs.Length);
                for (int i = 0; i < ColumnWs.Length; i++) ColumnWs[i] = w;
                for (int i = 0; i < RowHs.Length; i++) RowHs[i] = h;
                SetAllCellXY();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }

        }

        //격자 전체 크기 변경
        public void changeGridRect(RectangleF rect)
        {
            try
            {
                float w, h;
                this.GridRect = rect;
                w = (GridRect.Width / ColumnWs.Length);
                h = (GridRect.Height / RowHs.Length);
                for (int i = 0; i < ColumnWs.Length; i++) ColumnWs[i] = w;
                for (int i = 0; i < RowHs.Length; i++) RowHs[i] = h;
                SetAllCellXY();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }

        }

        //마커설정
        public void setMarker(int r, int c, bool isMarking, Color markerColor)
        {
            try
            {
                Cell cell = listCells.Where(p => p.r == r && p.c == c).ToList()[0];
                cell.isMarking = isMarking;
                cell.gColor = markerColor;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }

        }

        //마커 전체 지우기
        public void clearMarker()
        {
            try
            {
                foreach (Cell cell in listCells)
                {
                    cell.isMarking = false;
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }


        }

        //좌표로부터 셀 구하기
        public Cell getCell(PointF apnt)
        {
            try
            {
                PointF pnt = new PointF(apnt.X - GridRect.X, apnt.Y - GridRect.Y);
                float x = 0, y = 0;
                for (int r = 0; r < RowHs.Length; r++)
                {
                    y += RowHs[r];
                    if (pnt.Y>0 && pnt.Y < y)
                    {
                        for (int c = 0; c < ColumnWs.Length; c++)
                        {
                            x += ColumnWs[c];
                            if (pnt.X>0 && pnt.X < x)
                            {
                                return listCells.Where(p => p.r == r && p.c == c).ToList()[0];
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        //좌표로부터 기즈모 제외 셀 구하기
        public Cell getCellWithotGizmo(PointF apnt)
        {
            try
            {
                PointF pnt = new PointF(apnt.X - GridRect.X, apnt.Y - GridRect.Y);
                float x = 0, y = 0;
                for (int r = 0; r < RowHs.Length; r++)
                {
                    y += RowHs[r];
                    if (pnt.Y < y+ SIZE_NODE_RECT/2)
                    {
                        for (int c = 0; c < ColumnWs.Length; c++)
                        {
                            x += ColumnWs[c];
                            if (pnt.X < x + SIZE_NODE_RECT / 2)
                            {
                                return listCells.Where(p => p.r == r && p.c == c).ToList()[0];
                            }
                        }
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return null;
            }
        }

        //좌표로부터 셀 행, 열값 구하기
        public Point getRC(PointF pnt)
        {
            try
            {
                float x = 0, y = 0;
                for (int r = 0; r < RowHs.Length; r++)
                {
                    y += RowHs[r];
                    if (pnt.Y < y)
                    {
                        for (int c = 0; c < ColumnWs.Length; c++)
                        {
                            x += ColumnWs[c];
                            if (pnt.X < x)
                            {
                                return new Point(c, r);
                            }
                        }
                    }
                }
                return new Point(-1, -1);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return new Point(-1, -1);
            }
        }
        #endregion

    }
}
