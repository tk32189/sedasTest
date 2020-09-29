using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIP
{
    public class StudyDataTable : DataTable
    {
        public StudyDataTable()
        {
            this.Columns.Add("studyId", typeof(String));   //스터디 번호


            this.Columns.Add("ptNo", typeof(String)); //환자번호
            this.Columns.Add("studyDt", typeof(String)); //작업일자
            this.Columns.Add("insertDt", typeof(String));  // 
            this.Columns.Add("gi", typeof(String));  //육안이미지
            this.Columns.Add("mi", typeof(String));  //현미경이미지
            this.Columns.Add("oi", typeof(String));  //분자이미지

            this.Columns.Add("ptoNo", typeof(String)); //병리번호
            this.Columns.Add("sendStat", typeof(String)); //PACS 전송상태


            this.Columns.Add("studyRslt", typeof(String)); //진단결과
            this.Columns.Add("uId", typeof(String)); //일련번호
            this.Columns.Add("dstudy1", typeof(String)); //채취부위
            this.Columns.Add("dstudy2", typeof(String)); //진단
            this.Columns.Add("dstudy3", typeof(String)); //채위방법
            this.Columns.Add("studyNm", typeof(String)); //처방명
            this.Columns.Add("accessId", typeof(String)); //PACS ID


            //이미지 테이블 저장관련
            this.Columns.Add("imageType", typeof(String)); //이미지 종류
            this.Columns.Add("rootPath", typeof(String)); //공통경로
            this.Columns.Add("filePath", typeof(String)); //파일경로

            //환자정보 테이블 저장관련
            this.Columns.Add("ptNm", typeof(String)); //환자명
            this.Columns.Add("birth", typeof(String)); //생년월일
            this.Columns.Add("age", typeof(String)); //나이
            this.Columns.Add("sex", typeof(String)); //성별

            this.Columns.Add("userId", typeof(String)); //성별





        }
    }
}