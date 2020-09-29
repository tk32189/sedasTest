using SedasPhotoMagic.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SedasPhotoMagic
{
    //MainForm 의 줄자와 유사하게 설계
    public partial class RulerForm : DevExpress.XtraEditors.XtraForm
    {
        private MainForm parent;
        private WorkSpace ws;
        private PicStatus nowPicStatus;
        public List<PointF> listPoint = new List<PointF>();
        public List<PointF> listLineGrapPoint = new List<PointF>();
        private bool _drag;
        private PointF _dragStart;
        private Color _penColor = Color.Yellow;
        private RectangleF _rect;
        public RulerForm()
        {
            InitializeComponent();
        }
        private void RulerForm_Load(object sender, EventArgs e)
        {
            try
            {
                
                this.PanelView.MouseWheel += new MouseEventHandler(eMouseWheel);
                pm.Image = (Bitmap)Bitmap.FromFile(ws.imageFileFullname);
                ZoomImage(Zoom.Source);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }
        public void reLoad()
        {
            try
            {
                lblPixelPerCm.Text = ws.pixelPerCm.ToString("F1") + " px/cm";
                listPoint.Clear();
                pm.Image = (Bitmap)Bitmap.FromFile(ws.imageFileFullname);
                ZoomImage(Zoom.Source);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }

        }
        public void LoadData(MainForm parent)
        {
            try
            {
                this.parent = parent;
                ws = parent.ws;
                lblPixelPerCm.Text = ws.pixelPerCm.ToString("F1") + " px/cm";
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }

        }
        private void btnMesure_Click(object sender, EventArgs e)
        {
            try
            {
                SetCursor(Cursors.Cross);
                nowPicStatus = PicStatus.Start;
                listPoint.Clear();
                listLineGrapPoint.Clear();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Paint Event - PictureBoxMain
        private void PictureBoxMain_MouseDown(object sender, MouseEventArgs e)
        {
            try
            {
                if (pm.Image == null) return;
                if (e.Button == MouseButtons.Right)
                {
                    _drag = false;
                    SetCursor(Cursors.Default);
                    nowPicStatus = PicStatus.None;
                    pm.Invalidate();
                    return;
                }
                float zf = (float)(1.0 * pm.ClientSize.Width / pm.Image.Width);
                PointF _pnt = new PointF(e.X / zf, e.Y / zf);
                if (nowPicStatus == PicStatus.Start)
                {

                    _drag = true;
                    _dragStart = _pnt;
                    listPoint.Add(_dragStart);
                    listPoint.Add(_dragStart);
                    nowPicStatus = PicStatus.End;
                }
                else
                {
                    _drag = true;
                    _dragStart = e.Location;
                    nowPicStatus = PicStatus.None;
                }
                pm.Invalidate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name + " || " + ex.ToString());
            }
        }

        private void PictureBoxMain_MouseMove(object sender, MouseEventArgs e)
        {
            try
            {
                float _len, _factor;
                if (pm.Image == null) return;
                if (_drag)
                {

                    float zf = (float)(1.0 * pm.ClientSize.Width / pm.Image.Width);
                    List<PointF> pnts;
                    PointF _pnt = new PointF(e.X / zf, e.Y / zf);

                    if (nowPicStatus == PicStatus.End)
                    {
                        listPoint[1] = new PointF(_pnt.X, _pnt.Y);
                        pnts = listPoint;
                        _len = (float)Math.Sqrt(Math.Pow(pnts[0].X - pnts[1].X, 2) + Math.Pow(pnts[0].Y - pnts[1].Y, 2));
                        List<PointF> _pnts = new List<PointF>();
                        _factor = 3;
                        _pnts.Add(new PointF(pnts[0].X, pnts[0].Y - ws.SIZE_NODE_RECT * _factor));
                        _pnts.Add(new PointF(pnts[0].X, pnts[0].Y + ws.SIZE_NODE_RECT * _factor));
                        _pnts.Add(new PointF(pnts[0].X + _len, pnts[0].Y + ws.SIZE_NODE_RECT * _factor));
                        _pnts.Add(new PointF(pnts[0].X + _len, pnts[0].Y - ws.SIZE_NODE_RECT * _factor));
                        double _angle = Math.Atan2(pnts[1].Y - pnts[0].Y, pnts[1].X - pnts[0].X);
                        for (int i = 0; i < _pnts.Count; i++)
                        {
                            _pnts[i] = Util.rotatePoint(_angle, _pnts[i], pnts[0]);
                        }
                        listLineGrapPoint = _pnts;

                    }
                    else if (ws.nowPicStatus == PicStatus.None)
                    {
                        pm.Location = new Point(pm.Location.X + (int)(e.X - _dragStart.X), pm.Location.Y + (int)(e.Y - _dragStart.Y));
                    }
                    pm.Invalidate();
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name + " || " + ex.ToString());
            }
        }

        private void PictureBoxMain_MouseUp(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    _drag = false;
                    SetCursor(Cursors.Default);
                    nowPicStatus = PicStatus.None;
                    pm.Invalidate();
                    return;
                }
                _drag = false;
                if (pm.Image == null) return;
                List<PointF> pnts;
                float _len, _factor;
                float zf = (float)(1.0 * pm.ClientSize.Width / pm.Image.Width);
                PointF _pnt = new PointF(e.X / zf, e.Y / zf);
                if (nowPicStatus == PicStatus.End && listPoint.Count == 2)
                {
                    ws.nowPicStatus = PicStatus.None;
                    SetCursor(Cursors.Default);
                    _drag = false;
                    pnts = listPoint;
                    _len = (float)Math.Sqrt(Math.Pow(pnts[0].X - pnts[1].X, 2) + Math.Pow(pnts[0].Y - pnts[1].Y, 2));
                    string msg;
                    if (_len > 120)
                    {
                        msg = "측정된 픽셀은 1cm당 " + _len.ToString("F1") + " 픽셀입니다. 120보다 큰 경우는 이 값을 100으로 수정하여 저장합니다. 그리고, 이 값을 변경하면 용지가 실제사이즈와 달라지므로, 용지를 변경하여 실제 사이즈와 맞출 필요가 있습니다. 이 값으로 수정하시겠습니까?";
                    }
                    else
                    {
                        msg = "측정된 픽셀은 1cm당 " + _len.ToString("F1") + " 픽셀입니다. 이 값을 변경하면 용지가 실제사이즈와 달라지므로, 용지를 변경하여 실제 사이즈와 맞출 필요가 있습니다. 이 값으로 수정하시겠습니까?";
                    }
                    if (Util.CheckConfirm(msg)) 
                    {
                        ws.pixelPerCm = _len;
                        lblPixelPerCm.Text = _len.ToString("F1") + " px/cm";
                        parent.UpdatePixelPerCm(this);
                    }
                }
                pm.Invalidate();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name+" || "+ex.ToString());
            }
        }

        private void PictureBoxMain_Paint(object sender, PaintEventArgs e)
        {
            try
            {
                Graphics g = e.Graphics;
                if (pm.Image == null) return;
                float zf = (float)(1.0 * pm.ClientSize.Width / pm.Image.Width);
                PointF[] _pnts;
                double _len;
                if (listPoint.Count == 2)
                {
                    if (listLineGrapPoint.Count > 0)
                    {
                        var lineColor = Color.Gray;
                        var lineThickness = 3;
                        var font = new Font(btnMesure.Font.FontFamily, 16, btnMesure.Font.Style);
                        _pnts = new PointF[listLineGrapPoint.Count];
                        for (int i = 0; i < listLineGrapPoint.Count; i++) _pnts[i] = new PointF(listLineGrapPoint[i].X * zf, listLineGrapPoint[i].Y * zf);
                        g.DrawLine(new Pen(lineColor, lineThickness), _pnts[0], _pnts[1]);
                        g.DrawLine(new Pen(lineColor, lineThickness), _pnts[2], _pnts[3]);
                        _len = parent.DistanceTo(listPoint[0], listPoint[1]);
                        g.DrawString(" " + _len.ToString("F2") + "px/cm", font, new SolidBrush(lineColor), _pnts[3]);
                        g.DrawLine(new Pen(lineColor, lineThickness), zf * listPoint[0].X, zf * listPoint[0].Y, zf * listPoint[1].X, zf * listPoint[1].Y);
                    }

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name + " || " + ex.ToString());
            }
        }
        //메인 페이지 이미지 리사이즈 이벤트
        public void ePictureBoxMainSizeChanged(object sender, EventArgs e)
        {
            try
            {
                int imageWidth, imageHeight, pictureBoxMainClientHeight;
                if (pm != null && pm.Image != null)
                {
                    imageWidth = pm.Image.Width;
                    imageHeight = pm.Image.Height;
                    pictureBoxMainClientHeight = pm.ClientSize.Height;
                    pm.ClientSize = new Size((int)(1.0 * imageWidth * pictureBoxMainClientHeight / imageHeight), pictureBoxMainClientHeight);
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        #endregion Paint Event - PictureBoxMain

        #region 확대 축소

        private void ZoomImage(Zoom ztag = Zoom.FitHeight)
        {
            try
            {
                if (pm.Image == null) return;
                
                float _scale = (float)PanelView.Width / pm.Image.Width;
                float zf = (float)(1.0 * pm.ClientSize.Width / pm.Image.Width);
                if (ztag == Zoom.FitWidth) _scale = 0.95f * PanelView.Width / pm.Image.Width;
                else if (ztag == Zoom.FitHeight) _scale = 0.95f * PanelView.Height / pm.Image.Height;
                else if (ztag == Zoom.Source) _scale = (ws.objSrcRect == null ? 1:ws.objSrcRect.Width/ pm.Image.Width);
                else if (ztag == Zoom.Bigger) zf += parent.ScalePerDelta * 100;
                else zf -= parent.ScalePerDelta * 100;
                if (zf < 0.2) zf = 0.2f;
                else if (zf > 2) zf = 2f;
                if (ztag == Zoom.Bigger || ztag == Zoom.Smaller) _scale = zf;
                PanelView.HorizontalScroll.Value = 0;
                PanelView.VerticalScroll.Value = 0;
                pm.Size = new Size(
                    (int)(pm.Image.Width * _scale),
                    (int)(pm.Image.Height * _scale)); Point _pnt = new Point((PanelView.Width - pm.Width) / 2, 10);
                if (ztag == Zoom.Source) _pnt = new Point(-pm.Width + PanelView.Width, -pm.Height + PanelView.Height);
                pm.Location = _pnt;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }
        private void eMouseWheel(object sender, MouseEventArgs e)
        {
            try
            {
                if (System.Windows.Forms.Control.ModifierKeys == Keys.Control)
                {
                    if (pm.Image == null) return;
                    if (e.Delta > 0) ZoomImage(Zoom.Bigger);
                    else ZoomImage(Zoom.Smaller);
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        #endregion Panel Event - 확대 축소

        private void btnZoomSmaller_Click(object sender, EventArgs e)
        {
            ZoomImage(Zoom.Smaller);
        }

        private void btnZoomSource_Click(object sender, EventArgs e)
        {
            ZoomImage(Zoom.Source);

        }

        private void btnZoomBigger_Click(object sender, EventArgs e)
        {
            ZoomImage(Zoom.Bigger);

        }
        private void SetCursor(Cursor cursor)
        {
            try
            {
                this.Cursor = cursor;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(ws, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }
    }
}
