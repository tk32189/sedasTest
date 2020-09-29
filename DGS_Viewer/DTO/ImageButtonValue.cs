using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DGS_Viewer.DTO
{
    public class ImageButtonValue
    {
        public bool bSelect = false;
        public int nImageNum = -1;
        public int nSendStatus = -1;
        public int nType = -1;
        public string strRowFilePath = "";
        public string strSaveRootPath = "";
        public string strSaveFilePath = "";
        public string strPathologyNum = "";
        public int nStudyId = -1;
        public int nGI = 0;
        public int nMI = 0;
        public int nOI = 0;
        public int nSerialNo = 0;
        public string strPtNo = "";
        public string strPtNm = "";
        public string strCm = "";
        public int nSeq = -1;

        //public string strLocalFilePath = ""; //로컬에 내려받은 파일에 대한 실제 경로
    }
}
