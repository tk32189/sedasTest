using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IIP
{
    public class OrderDataTable : DataTable
    {
        public OrderDataTable()
        {
            this.Columns.Add("pid", typeof(String));   //환자번호(등록번호)
            this.Columns.Add("kornm", typeof(String)); //환자명(한글)
            this.Columns.Add("regno", typeof(String)); //주민번호
            this.Columns.Add("tknm", typeof(String));  //검사한글명칭
            this.Columns.Add("tkdt", typeof(String));  //인수/접수일자
            this.Columns.Add("ptno", typeof(String));  //병리번호

            this.Columns.Add("patbir", typeof(String)); //생년월일
            this.Columns.Add("patage", typeof(String)); //나이
            this.Columns.Add("patsex", typeof(String)); //성별

            //this.Columns.Add("study1")
            


        }

    }
}
