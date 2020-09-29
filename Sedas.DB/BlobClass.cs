using Sedas.Core;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Sedas.DB
{
    public class BlobClass
    {
        public BlobClass(CallService callService)
        {
            this.callService = callService;
        }

        CallService callService = new CallService("10.10.221.72", "8180");

        #region SearchNumber [UID 일련번호 조회]
        /// <summary>
        /// name         : SearchNumber
        /// desc         : UID 일련번호 조회
        /// author       : 심우종
        /// create date  : 2020-04-17 14:14
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public string SearchNumber(string ptoNo)
        {
            if (!string.IsNullOrEmpty(ptoNo))
            {
                KeyValueData param = new KeyValueData();
                param.Add("Data1", ptoNo);
                CallResultData result = this.callService.SelectSql("reqGetBlobSearchNumber", param);
                if (result.resultState == ResultState.OK)
                {
                    if (result.resultData != null && result.resultData.Rows.Count > 0 && result.resultData.Columns.Contains("resultValue"))
                    {
                        return result.resultData.Rows[0]["resultValue"].ToString();
                    }
                    //데이터 조회 성공
                    //DataTable dt = result.resultData;
                }
                else
                {
                    //실패에 대한 처리
                }

            }

            return null;
        }
        #endregion

        #region InsertLPRPRSTHM [LPRPRSTHM 테이블 업데이트]
        /// <summary>
        /// name         : InsertLPRPRSTHM
        /// desc         : LPRPRSTHM 테이블 업데이트
        /// author       : 심우종
        /// create date  : 2020-04-17 17:05
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public string InsertLPRPRSTHM(string ptoNo, string seqNo)
        {
            if (!string.IsNullOrEmpty(ptoNo) && !string.IsNullOrEmpty(seqNo))
            {
                KeyValueData param = new KeyValueData();
                param.Add("Data1", ptoNo);
                param.Add("Data2", seqNo);
                CallResultData result = this.callService.SelectSql("reqGetBlobInsertLPRPRSTHM", param);
                if (result.resultState == ResultState.OK)
                {
                    //데이터 조회 성공
                }
                else
                {
                    //실패에 대한 처리
                }
            }
            return null;
        }
        #endregion

        #region UpdateBlob [Blob데이터 업데이트]
        /// <summary>
        /// name         : UpdateBlob
        /// desc         : Blob데이터 업데이트
        /// author       : 심우종
        /// create date  : 2020-04-20 09:37
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public string UpdateBlob(string ptoNo, string strLocalFilePath, string saveFilePath)
        {
            if (!string.IsNullOrEmpty(ptoNo))
            {

                FileStream fs = new FileStream(strLocalFilePath, FileMode.Open, FileAccess.Read);
                BinaryReader br = new BinaryReader(fs);
                byte[] imageBytes = br.ReadBytes((int)fs.Length);


                //ByteArrayContent byteContent = new ByteArrayContent(imageBytes);
                //StringContent stringContent = new StringContent(imageBytes, System.Text.Encoding.UTF8);

                //String strImage = Base64.encodeToString(image1, Base64.DEFAULT);

                //String imageStr = Encoding.Default.GetString(imageBytes).TrimEnd('\0');
                //String test2 = Convert.ToBase64String(imageBytes);
                //string test3 = imageBytes.ToString();
                //string test4 = System.Text.Encoding.UTF8.GetString(imageBytes).TrimEnd('\0');
                string imageStr = BitConverter.ToString(imageBytes).Replace("-", "");


                KeyValueData param = new KeyValueData();
                param.Add("Data1", ptoNo);
                param.Add("Data2", imageStr);
                param.Add("Data3", saveFilePath);
                //param.Add("Data2", seqNo);
                CallResultData result = this.callService.SelectSqlToPost("reqGetBlobUpdateBlob", param);
                if (result.resultState == ResultState.OK)
                {
                    //데이터 조회 성공
                }
                else
                {
                    //실패에 대한 처리
                }
            }
            return null;
        }
        #endregion


    }
}
