using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedas.DB
{
    public enum ResultState
    { 
        NONE, //미확인
        OK,  //성공
        FAIL //실패
    }
    public class CallResultData
    {
        public ResultState resultState = ResultState.NONE; //DB연결 결과코드
        public DataTable resultData; //결과값 리턴용
        public List<DataTable> resultDataList; //결과값이 여러개의 테이블로 리턴되는 경우에 대한 처리
        public string errorMessage = "";
    }
}
