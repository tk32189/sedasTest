using Sedas.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sedas.DB
{
    public class ImageInOutClass
    {
        CallService callService = new CallService("10.10.221.71", "8180");
        public ImageInOutClass(CallService callService)
        {
            this.callService = callService;
        }

        /// <summary>
        /// name         : ImageInsert
        /// desc         : 이미지 한건에 대해서 파일복사 및 DB정보 추가
        /// author       : 심우종
        /// create date  : 2020-07-16 14:04
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool ImageInsert(string localFilePathAndName, int imageIndex, string ptoNo, string studyId, string nType, string nSendStatus = "0")
        {

            DateTime current = DateTime.Now;
            //------------------------------------------------
            //파일명 생성( 병리번호_yyyyMMddHHmmss + index)
            //------------------------------------------------
            string fileName = ptoNo + "_" + current.ToString("yyyyMMddHHmmss") + imageIndex.ToString() + ".jpg";


            //------------------------------------------------
            //파일 path 생성
            //------------------------------------------------
            string filePath = "imagedata\\";
            string changedTempPath = current.ToString("yyyy") + "\\";
            filePath = filePath + changedTempPath;

            changedTempPath = ptoNo + "\\";
            filePath = filePath + changedTempPath;

            string savePath = filePath + fileName;

            FileTransfer ft = new FileTransfer();
            //이미지 파일복사
            //File.Copy(buttonValue.strRowFilePath, savePath);
            if (ft.FileUpload(localFilePathAndName, savePath) == false)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("이미지 저장에 실패했습니다.");
                return false;
            }

            //*.IIF 파일 복사
            string iifPath = localFilePathAndName.Substring(0, localFilePathAndName.Length - 3);
            iifPath = iifPath + "IIF";

            bool isIifExist = File.Exists(iifPath);
            if (isIifExist == true)
            {
                string iifFilePath = savePath.Substring(0, savePath.Length - 3) + "IIF";
                //File.Copy(iifPath, iifFilePath);
                if (ft.FileUpload(iifPath, iifFilePath) == false)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("IIF파일 저장에 실패했습니다.");
                    return false;
                }

            }

            string temppath = current.ToString("yyyyMMdd") + "\\" + ptoNo + "\\";
            string datafilepath = temppath;

            int nImageNum = imageIndex + 1;
            int nSerialNo = imageIndex + 1;
            string strSaveFilePath = savePath;
            string strSaveRootPath = "Z:\\";

            //이미지 테이블에 정보 저장
            string insertDt = DateTime.Now.ToString("yyyyMMddHHmmss");
            KeyValueData param = new KeyValueData();
            param.Add("Data1", nType);
            param.Add("Data2", nSerialNo.ToString());
            param.Add("Data3", studyId);
            param.Add("Data4", strSaveRootPath);
            param.Add("Data5", strSaveFilePath);
            param.Add("Data6", nSendStatus);

            param.Add("Data7", "");
            param.Add("Data8", "");
            param.Add("Data9", "");
            param.Add("Data10", insertDt);
            param.Add("Data11", SessionInfo.userId);
            CallResultData result = this.callService.SelectSql("reqInsViewerImageData", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                //DataTable dt = result.resultData;
                return true;
            }
            else
            {
                //실패에 대한 처리
                DevExpress.XtraEditors.XtraMessageBox.Show("이미지 테이블 저장에 실패하였습니다.");
                return false;
            }
        }



        /// <summary>
        /// name         : DeleteImageFromDB
        /// desc         : 삭제되는 이미지 정보를 DB에 반영한다.
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool DeleteImageFromDB(List<DeleteImageDTO> deleteImages)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("studyId", typeof(String));
            dt.Columns.Add("seq", typeof(String));
            dt.Columns.Add("ptoNo", typeof(String));
            dt.Columns.Add("filePath", typeof(String));
            dt.Columns.Add("userId", typeof(String));

            for (int i = 0; i < deleteImages.Count; i++)
            {
                DataRow row = dt.NewRow();
                row["studyId"] = deleteImages[i].StudyId.ToString();
                row["seq"] = deleteImages[i].Seq.ToString();
                row["ptoNo"] = deleteImages[i].PtoNo.ToString();
                row["filePath"] = deleteImages[i].FilePath.ToString();
                row["userId"] = SessionInfo.userId;
                dt.Rows.Add(row);
            }

            KeyValueData param = new KeyValueData();
            param.Add("Data1", dt.DataTableToStringForServer());
            CallResultData result = this.callService.SelectSql("reqSetViewerDeleteImageData", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                //DataTable dt = result.resultData;
                return true;
            }
            else
            {
                //실패에 대한 처리
                DevExpress.XtraEditors.XtraMessageBox.Show("이미지 테이블 삭제 오류");
                return false;
            }
        }

        /// <summary>
        /// name         : UpdateImageSaveAfter
        /// desc         : 이미지 저장 후 처리 update
        /// author       : 심우종
        /// create date  : 2020-05-15 08:53
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool UpdateImageSaveAfter(string studyId)
        {
            //-----------------------------------------
            //1) study테이블의 이미지 number 재설정
            //2) 이미지 테이블의 serialNo재설정
            //-----------------------------------------
            KeyValueData param = new KeyValueData();
            param.Add("Data1", studyId);
            param.Add("Data2", SessionInfo.userId);
            CallResultData result = this.callService.SelectSql("reqSetViewerImageSaveAfter", param);
            if (result.resultState == ResultState.OK)
            {
                return true;
            }
            else
            {
                //실패에 대한 처리
                DevExpress.XtraEditors.XtraMessageBox.Show("이미지 저장 후 처리 업데이트시 오류");
                return false;
            }
        }


        /// <summary>
        /// name         : InsertStudyAndPatData
        /// desc         : 스터디 데이터와 환자정보를 저장한다.
        /// author       : 심우종
        /// create date  : 2020-08-05 16:58
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public bool InsertStudyAndPatData(InsertStudyAndPatDTO dto)
        {
            KeyValueData param = new KeyValueData();
            param.Add("Data1", dto.ptoNo);
            param.Add("Data2", dto.insertDt);
            param.Add("Data3", dto.accessno);
            param.Add("Data4", dto.studyDt);
            param.Add("Data5", dto.gi);
            param.Add("Data6", dto.mi);
            param.Add("Data7", dto.oi);
            param.Add("Data8", dto.sendStat);
            param.Add("Data9", dto.studyRslt);
            param.Add("Data10", dto.uId);
            param.Add("Data11", dto.dstudy1);
            param.Add("Data12", dto.dstudy2);
            param.Add("Data13", dto.dstudy3);
            param.Add("Data14", dto.studyNm);
            param.Add("Data15", dto.accessId);
            param.Add("Data16", dto.ptNo);
            param.Add("Data17", dto.ptNm);
            param.Add("Data18", dto.birth);
            param.Add("Data19", dto.age);
            param.Add("Data20", dto.sex);
            param.Add("Data21", SessionInfo.userId);


            CallResultData result = this.callService.SelectSql("reqInsCoreStudyAndPatData", param);
            if (result.resultState == ResultState.OK)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }

    public class InsertStudyAndPatDTO
    {
        public string ptoNo;
        public string insertDt;
        public string accessno;
        public string studyDt;
        public string gi;
        public string mi;
        public string oi;
        public string sendStat;
        public string studyRslt;
        public string uId;
        public string dstudy1;
        public string dstudy2;
        public string dstudy3;
        public string studyNm;
        public string accessId;
        public string ptNo;
        public string ptNm;
        public string birth;
        public string age;
        public string sex;
    }

    public class DeleteImageDTO
    {
        private string studyId;
        private string seq;
        private string ptoNo;
        private string filePath;

        private string fileServerPath;

        public string StudyId
        {
            get
            {
                return studyId;
            }

            set
            {
                studyId = value;
            }
        }

        public string Seq
        {
            get
            {
                return seq;
            }

            set
            {
                seq = value;
            }
        }

        public string PtoNo
        {
            get
            {
                return ptoNo;
            }

            set
            {
                ptoNo = value;
            }
        }

        public string FilePath
        {
            get
            {
                return filePath;
            }

            set
            {
                filePath = value;
            }
        }

        public string FileServerPath
        {
            get
            {
                return fileServerPath;
            }

            set
            {
                fileServerPath = value;
            }
        }
    }
}
