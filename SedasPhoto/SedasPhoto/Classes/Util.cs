using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.Serialization.Formatters.Binary;

namespace SedasPhotoMagic.Classes
{
    public static class Util
    {
        public static bool CanShowErrorMessage = true;//변경하면 에러메세지를 보여주지 않는다.

        #region 이미지처리
        //흰색의 바탕이미지 비트맵
        public static Bitmap GetBlankImage(int w, int h, float hRes, float vRes)
        {
            try
            {
                Bitmap bmp = new Bitmap(w, h);
                bmp.SetResolution(hRes, vRes);
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    Rectangle ImageSize = new Rectangle(0, 0, w, h);
                    g.FillRectangle(Brushes.White, ImageSize);
                }
                return bmp;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name + " || " + ex.ToString());
                return null;
            }
        }

        //회전 비트맵 - 높이와 넓이가 같아 잘리는 것 방지 // 대각선 길이를 이용하여 넓이 계산
        public static Bitmap RotateImage(Bitmap b, float angle, int w)
        {
            try
            {
                Bitmap returnBitmap = new Bitmap(w, w, b.PixelFormat);
                returnBitmap.SetResolution(b.HorizontalResolution, b.VerticalResolution);
                using (Graphics g = Graphics.FromImage(returnBitmap))
                {
                    g.FillRectangle(new SolidBrush(Color.White), new Rectangle(0, 0, w, w));
                    g.TranslateTransform((float)w / 2, (float)w / 2);
                    g.RotateTransform(angle);
                    g.TranslateTransform(-(float)w / 2, -(float)w / 2);
                    g.DrawImage(b, new Point(-(b.Width - w) / 2, -(b.Height - w) / 2));
                }
                return returnBitmap;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(System.Reflection.MethodInfo.GetCurrentMethod().Name + " || " + ex.ToString());
                return b;
            }
        }
        // 선택영역 이미지 추출

        #endregion

        #region 에러 및 메세지 처리
        //추후 사용자 배포시 간단한 에러 메시지를 보여주고, DB에 남길 수도 있다.
        public static void ShowErrorMessage(WorkSpace workSpace, string subroutine, Exception ex)
        {
            try
            {
                if (CanShowErrorMessage)
                {
                    Debug.WriteLine("ERR =========================");
                    Debug.WriteLine(subroutine);
                    Debug.WriteLine("============================");
                    //Debug.WriteLine("WorkSpace " + (workSpace == null ? "NULL" : workSpace.WorkName));
                    Debug.WriteLine(ex.ToString());
                    Debug.WriteLine("");
                    Debug.WriteLine("");
                    Debug.WriteLine("");
                    Debug.WriteLine("");
                    DevExpress.XtraEditors.XtraMessageBox.Show("에러가 발생하였습니다. 관리자에게 문의하여 주시기 바랍니다.\n.\n" + ex.ToString(), "에러");
                    CanShowErrorMessage = false;
                }
            }
            catch (Exception exe)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, exe);
            }
        }
        //사용자 확인
        public static void ShowConfirm(string message)
        {
            try { DevExpress.XtraEditors.XtraMessageBox.Show(message, "확인"); }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }

        }

        //사용자 선택 여부 확인
        public static bool CheckConfirm(string message)
        {
            try
            {
                return (DevExpress.XtraEditors.XtraMessageBox.Show(message, "확인", MessageBoxButtons.OKCancel) == DialogResult.OK);
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return false;
            }
        }
        #endregion

        #region 기타
        //되돌리기를 위해 리스트나 클래스 등에 대한 깊은 복사 수행
        public static object DeepClone(object obj)
        {
            object objResult = null;
            using (MemoryStream ms = new MemoryStream())
            {
                BinaryFormatter bf = new BinaryFormatter();
                bf.Serialize(ms, obj);

                ms.Position = 0;
                objResult = bf.Deserialize(ms);
            }
            return objResult;
        }

        //정수 여부 확인
        public static int CheckInt(string text)
        {
            int rtn = -1;
            try
            {
                if (int.TryParse(text, out rtn))
                {
                    if (rtn < 0)
                    {
                        ShowConfirm("반드시 0 이상의 정수를 입력해야 합니다.");
                        return -1;
                    }
                    else return rtn;
                }
                else return rtn;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return rtn;
            }
        }

        //소수 여부 확인
        public static float CheckFloat(string text)
        {
            float rtn = -1;
            try
            {
                if (float.TryParse(text, out rtn))
                {
                    if (rtn < 0)
                    {
                        ShowConfirm("반드시 0 이상의 정수를 입력해야 합니다.");
                        return -1;
                    }
                    else return rtn;
                }
                else return rtn;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return rtn;
            }
        }

        //다각형 내부 점인지 확인
        public static bool IsPointInPolygon(PointF[] polygon, PointF testPoint)
        {
            try
            {
                bool result = false;
                int j = polygon.Count() - 1;
                for (int i = 0; i < polygon.Count(); i++)
                {
                    if (polygon[i].Y < testPoint.Y && polygon[j].Y >= testPoint.Y || polygon[j].Y < testPoint.Y && polygon[i].Y >= testPoint.Y)
                    {
                        if (polygon[i].X + (testPoint.Y - polygon[i].Y) / (polygon[j].Y - polygon[i].Y) * (polygon[j].X - polygon[i].X) < testPoint.X)
                        {
                            result = !result;
                        }
                    }
                    j = i;
                }
                return result;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return false;
            }
        }

        //회전각 파악
        public static float getRotateAngle(List<PointF> pnts)
        {
            try
            {
                if (pnts.Count == 2) return (float)(180.0 / Math.PI * Math.Atan2(pnts[1].X - pnts[0].X, -(pnts[1].Y - pnts[0].Y)));
                else return 0;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return 0;
            }
        }

        //점 회전 - 직선 등에서 선택위한 사각형 생성에 필요
        public static PointF rotatePoint(double angle, PointF pointToRotate, PointF centerPoint)
        {
            try
            {
                double cosTheta = Math.Cos(angle);
                double sinTheta = Math.Sin(angle);
                return new PointF
                {
                    X =
                        (float)
                        (cosTheta * (pointToRotate.X - centerPoint.X) -
                        sinTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.X),
                    Y =
                        (float)
                        (sinTheta * (pointToRotate.X - centerPoint.X) +
                        cosTheta * (pointToRotate.Y - centerPoint.Y) + centerPoint.Y)
                };
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
                return new PointF(0, 0);
            }
        }

        //커서 변경
        public static void WaitCursor(bool isWait)
        {
            try
            {
                if (isWait) Cursor.Current = Cursors.WaitCursor;
                else Cursor.Current = Cursors.Default;
            }
            catch (Exception ex)
            {
                Util.ShowErrorMessage(null, System.Reflection.MethodInfo.GetCurrentMethod().Name, ex);
            }
        }

        //미리초 단위의 유일값 생성
        public static string GetNameFromTimebase()
        {
            return DateTime.Now.ToString("yyyyMMdd_HHmmssfff");
        }

        #endregion

    }
}
