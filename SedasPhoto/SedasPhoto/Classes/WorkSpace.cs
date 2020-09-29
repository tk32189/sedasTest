using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SedasPhotoMagic.Classes
{
    //확대 종류
    public enum Zoom  
    {
        Source, Bigger, Smaller, FitWidth, FitHeight
    }

    //선택자 종류
    public enum Gizmo
    {
        LeftBottom,
        LeftUp,
        RightUp,
        RightBottom,
        UpMiddle,
        BottomMiddle,
        LeftMiddle,
        RightMiddle,
        Drag,
        None

    };

    //이미지 상태 종류
    public enum PicStatus 
    {
        //PaperDrag 배경이동, BGSelect 수동배경제거 점선택, InspectObj 검체이동, ZoomWithCenter: 중심점 확대
        PaperDrag, BGSelect, InspectObj, ZoomWithCenter, 
        Start, End, Select, None
    }

    //개체 종류
    public enum DrawingObjectType
    {
        Source,
        Image,
        Line,
        Free,
        Polygon,
        Ruler,
        Triangle,
        Rect,
        Circle,
        Text,
        Grid, ObjCrop, ObjRotate,Cell,Marker,
        None
    }

    //개체 클래스
    [Serializable]
    public class DrawingObject //  listObject  내의 아이템 - 이미지와 격자 이외의 모든 개체정보
    {
        public DrawingObjectType oType { get; set; }
        public int zIndex { get; set; } // 깊이값
        public string text { get; set; }
        public Font font { get; set; }
        public Color lineColor { get; set; }
        public Color faceColor { get; set; }
        public bool isTransparent { get; set; }
        public int lineThickness { get; set; }
        public List<List<PointF>> listFreePoint { get; set; } // 자유선에서만 사용
        public List<PointF> listPoint { get; set; }
        public List<PointF> listLineGrapPoint { get; set; } //직선 및 줄자에서만 사용
        public RectangleF rect { get; set; }
        public bool isSelect { get; set; }
        public DrawingObject() { }
        public DrawingObject(DrawingObjectType oType, int zIndex)
        {
            this.oType = oType;
            this.zIndex = zIndex;
            listPoint = new List<PointF>();
            listLineGrapPoint = new List<PointF>();
            listFreePoint = new List<List<PointF>>();
        }

    }
    public class WorkSpace // 프로그램 관련 핵심 변수만 담긴 작업장
    {
        #region 기본변수
        public float ZOOM_FACTOR = 5;//Paint Element Zoom Factor
        public int SIZE_NODE_RECT = 10; // Gizmo 크기
        public string WORK_DIREC = Application.StartupPath + @"\TMP\";
        public float[] TEXT_BOX_MARGIN = new float[] { 5, 5, 40, 20 };
        public MainForm mainForm { get; set; }
        public PictureBox pictureBoxMain { get; set; }
        public Color bgColorBefore { get; set; } // 배경제거색
        public Color bgColorAfter { get; set; } // 배경 제거시 대체색
        public Bitmap bitmap { get; set; } // Paper bitmap - 저장시 사용
        public float pixelPerCm { get; set; } //px/cm
        public int nowTab { get; set; } // 현재 탭 번호
        public DrawingObjectType nowDrawingObjectType { get; set; } // Grid, ObjCrop, ObjRotate
        public PicStatus nowPicStatus { get; set; }
        public DrawingObject no { get; set; } // 현재 선택 오브젝트
        public string imageFilename { get; set; }
        public string imageFileFullname { get; set; }
        public Bitmap objBitmap { get; set; }// 검체 비트맵
        public List<PointF> listDragPoint { get; set; } // 검체 자유 회전시 사용하는 좌표 리스트
        public RectangleF objSrcRect { get; set; } // 단위수정 원본 사각형
        public RectangleF objCropRect { get; set; } // 자르기시 사용하는 사각형
        public List<DrawingObject> listObjects { get; set; } // 생성한 개체 리스트
        public List<PictureBoxForNavigate> listNavi { get; set; } // 네비창 리스트
        public List<GridObject> listGrids { get; set; } 
        public SizeF paperSize { get; set; } // 전체 페이지 크기
        public RectangleF objRect { get; set; } // 검체 사각형
        #endregion

        #region 격자변수
        public bool isGridShow { get; set; } // 격자 보기
        public Color markerColor { get; set; } // 마커 색
        #endregion

        public WorkSpace()
        {
        }
        public WorkSpace(MainForm mainForm, PictureBox pictureBox)
        {
            try
            {
                this.mainForm = mainForm;
                this.pictureBoxMain = pictureBox;
                bgColorAfter = Color.White;
                bgColorBefore = Color.FromArgb(50, 50, 200);
                listObjects = new List<DrawingObject>();
                listNavi = new List<PictureBoxForNavigate>();
                listDragPoint = new List<PointF>();
                listGrids =new List<GridObject>();
                nowPicStatus = PicStatus.None;
                no = null;
                nowTab = 0;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //모든 개체 선택 해제 - 취소등에 활용
        public void unSelectAllObject()
        {
            try
            {
                foreach (DrawingObject _obj in listObjects.Where(p => p.isSelect == true))
                {
                    _obj.isSelect = false;
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //현재 오브젝트 선택
        public void SetNowObject(DrawingObject obj, PicStatus status)
        {
            try
            {
                this.no = obj;
                this.nowPicStatus = status;
                foreach (DrawingObject _obj in listObjects.Where(p => p.zIndex > 0))
                {
                    if (obj == null) _obj.isSelect = false;
                    else _obj.isSelect = (_obj.zIndex == obj.zIndex);
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //현재 네비 선택
        public void SetNowNavi(string imagefilename)
        {
            try
            {
                foreach (PictureBoxForNavigate pic in listNavi)
                {
                    pic.IsSelect = (pic.imageFilename == imagefilename);
                    pic.Invalidate();
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //현재 검체 설정
        public void SetObjBitmap(Bitmap pbitmap)
        {
            try
            {
                if (this.objBitmap != null) this.objBitmap.Dispose();
                this.objBitmap = pbitmap;
                this.objRect = new RectangleF((paperSize.Width - pbitmap.Width) / 2, (paperSize.Height - pbitmap.Height) / 2,
                    pbitmap.Width, pbitmap.Height);
                pictureBoxMain.Invalidate();
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //현재 선택된 개체 찾기
        public DrawingObject getFocusedObject(PointF point, float zf = 1)
        {
            try
            {
                foreach (DrawingObject obj in listObjects.Where(p => p.zIndex > 0).OrderByDescending(p => p.zIndex))
                {
                    if (obj.oType == DrawingObjectType.Line || obj.oType == DrawingObjectType.Ruler)
                    {
                        if (Util.IsPointInPolygon(obj.listLineGrapPoint.ToArray(), point)) return obj;
                    }
                    else if (obj.oType == DrawingObjectType.Free || obj.oType == DrawingObjectType.Rect || obj.oType == DrawingObjectType.Circle)
                    {
                        if (obj.rect.Contains(point)) return obj;

                    }
                    else if (obj.oType == DrawingObjectType.Text)
                    {
                        RectangleF _objRect = new RectangleF(obj.rect.X * zf - TEXT_BOX_MARGIN[0], obj.rect.Y * zf - TEXT_BOX_MARGIN[1]
                                    , obj.rect.Width + TEXT_BOX_MARGIN[2], obj.rect.Height + TEXT_BOX_MARGIN[3]);
                        if (_objRect.Contains(new PointF(point.X * zf, point.Y * zf))) return obj;
                    }
                    else if (obj.oType == DrawingObjectType.Triangle || obj.oType == DrawingObjectType.Polygon)
                    {
                        if (Util.IsPointInPolygon(obj.listPoint.ToArray(), point)) return obj;
                    }
                }
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
            return null;
        }
    }
}
