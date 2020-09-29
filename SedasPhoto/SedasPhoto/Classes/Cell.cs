using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SedasPhotoMagic.Classes
{
    //격자의 단위 셀
    [Serializable]
    public class Cell
    {
        public RectangleF rect { get; set; }//셀 사각형
        public float x { get; set; }//셀 좌료
        public float y { get; set; }//셀 좌표
        public int r { get; set; }//셀 행
        public int c { get; set; }//셀 열
        public bool isMarking { get; set; }//마커 여부
        public Color gColor { get; set; }//마커 컬러
        public Cell() { }
        public Cell(int r, int c)
        {
            this.r = r; this.c = c; isMarking = false;
        }
    }
}
