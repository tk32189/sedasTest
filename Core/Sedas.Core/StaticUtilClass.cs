using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sedas.Core
{
    /// <summary>
    /// name         : StaticUtilClass
    /// desc         : 자주 사용하는 유틸성 정적 클래스 모음
    /// author       : 심우종
    /// create date  : 2020-03-26 15:59
    /// update date  : 최종 수정일자 , 수정자, 수정개요
    /// </summary> 
    public static class StaticUtilClass
    {
        public static int counter = 0;

        /// <summary>
        /// String => Int
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }
        /// <summary>
        /// String => Int (널 허용)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static int? ToIntOrNull(this string value)
        {
            int returnValue;
            if (int.TryParse(value, out returnValue) == true)
            {
                return returnValue;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// String => double
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double ToDouble(this string value)
        {
            return double.Parse(value);
        }

        /// <summary>
        /// String => double (널 허용)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static double? ToDoubleOrNull(this string value)
        {
            double returnValue;
            if (double.TryParse(value, out returnValue) == true)
            {
                return returnValue;
            }
            else
            {
                return null;
            }
        }

        /// <summary>
        /// String => Decimal
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal ToDecimal(this string value)
        {
            return decimal.Parse(value);
        }

        /// <summary>
        /// String => Decimal (널 허용)
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static decimal? ToDecimalOrNull(this string value)
        {
            decimal returnValue;
            if (decimal.TryParse(value, out returnValue) == true)
            {
                return returnValue;
            }
            else
            {
                return null;
            }
        }


        /// <summary>
        /// name         : GetFileExtension
        /// desc         : 파일 확장자 리턴
        /// author       : 심우종
        /// create date  : 2020-07-02 09:11
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public static string GetFileExtension(this string strPath)
        {
            string lastValue = "";
            string[] fileNameSplite = strPath.ToString().Split('.');
            if (fileNameSplite == null || fileNameSplite.Length > 0)
            {
                lastValue = fileNameSplite[fileNameSplite.Length - 1].ToString();
            }

            return lastValue;
        }


        /// <summary>
        /// name         : DataTableToStringForServer
        /// desc         : 서버에 DataTable형태의 데이터 전달시 인코딩 처리
        /// author       : 심우종
        /// create date  : 2020-04-14 10:30
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public static string DataTableToStringForServer(this DataTable dt, string niud_Column = "")
        {
            /*
             * 넘어가야 하는 데이터 구조 프로토콜 형태 첫 라인의 niud값 필수
            m▦num▦day▦dd▦iud▩
            i▦data1▦data2▦data3▦i▩
            i▦data4▦data5▦data6▦i▩
            u▦data7▦data8▦data9▦i▩
            d▦data10▦data11▦data12▦i▩
             */
            StringBuilder str = new StringBuilder();

            str.Append("m▦");

            //1. 해더 구조 만들기
            for (int i = 0; i < dt.Columns.Count; i++)
            {
                string columnName = dt.Columns[i].ColumnName;

                if (i != dt.Columns.Count - 1)
                {
                    str.Append(columnName + "▦");
                }
                else
                {
                    //해당 row의 마지막은 ▩표시로..
                    str.Append(columnName + "▩");
                }
            }

            //2. 바디 구조 만들기
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow row = dt.Rows[i];

                //2.1 NIUD 값 설정
                if (!string.IsNullOrEmpty(niud_Column))
                {
                    str.Append(row["niud_Column"].ToString().ToLower() + "▦");
                }
                else
                {
                    //niud컬럼 지정되지 않으면 무조건 i로 설정함.
                    str.Append("i" + "▦");
                }

                //2.2 row데이터 복사
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    string value = row[dt.Columns[j].ColumnName.ToString()].ToString();

                    if (j != dt.Columns.Count - 1)
                    {
                        str.Append(value + "▦");
                    }
                    else
                    {
                        //해당 row의 마지막은 ▩표시로..
                        str.Append(value + "▩");
                    }
                }
            }

            return str.ToString();
        }

        /// <summary>
        /// name         : XmlToDataTable
        /// desc         : XML을 데이터테이블로 반환
        /// author       : 심우종
        /// create date  : 2020-04-10 11:05
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        //public static void XmlToDataTable(this string responseFromServer, string elemnetName)
        //{
        //    StringReader theReader = new StringReader(responseFromServer);
        //    DataSet theDataSet = new DataSet();
        //    theDataSet.ReadXml(theReader);
        //}
    }
}
