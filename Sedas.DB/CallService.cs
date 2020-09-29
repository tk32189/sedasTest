using Sedas.Core;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Web;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace Sedas.DB
{
    public class CallService
    {
        string connectInfo;
        bool isDevMode = true;
        const string devConnect = "http://127.0.0.1:8180/lis/byeongriweb/PIE_Interface.live?Mode=";
        private string ip;
        private string port;
        private string url;
        private bool errorMessageDisplay = true;
        LogHelper logHelper = new LogHelper();

        public string Ip
        {
            get { return ip; }
            set { ip = value; }
        }

        public string Port
        {
            get { return port; }
            set { port = value; }
        }


        public CallService()
        { 
        
        }

        public CallService(string ip, string port)
        {
            this.ip = ip;
            this.port = port;
        }

        public CallService(string url)
        {
            this.url = url;
        }

        public string ConnectInfo
        {
            get
            {
                if (!string.IsNullOrEmpty(ip) && !string.IsNullOrEmpty(port))
                {
                    return string.Format("http://{0}:{1}/lis/byeongriweb/PIE_Interface.live?Mode=", this.ip, this.port);
                }
                else if (!string.IsNullOrEmpty(url))
                {
                    return string.Format("http://{0}/lis/byeongriweb/PIE_Interface.live?Mode=", this.url);
                }
                else
                {
                    if (isDevMode == true)
                    {
                        return devConnect;
                    }
                    else
                    {
                        return "";
                    }
                }
            }

            set
            {
                connectInfo = value;
            }
        }

        public bool ErrorMessageDisplay
        {
            get
            {
                return errorMessageDisplay;
            }

            set
            {
                errorMessageDisplay = value;
            }
        }




        /// <summary>
        /// name         : SelectSql
        /// desc         : DB접속
        /// author       : 심우종
        /// create date  : 2020-05-13 09:51
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public CallResultData SelectSql(string serviceName, KeyValueData param = null)
        {
            StringBuilder strParam = new StringBuilder();
            if (param != null && param.Count > 0)
            {
                for (int i = 0; i < param.Count; i++)
                {
                    string key = param.ElementAt(i).Key;
                    string value = param.ElementAt(i).Value;

                    strParam.Append("&" + key + "=" + HttpUtility.UrlEncode(value, System.Text.Encoding.GetEncoding("euc-kr")));
                }
            }



            //string paramValue = Uri.EscapeDataString(strParam.ToString());


            string connectionString = string.Format("{0}{1}{2}", ConnectInfo, serviceName, strParam.ToString());
            WebRequest request = WebRequest.Create(connectionString); // 호출할 url
            //WebRequest request = WebRequest.Create("http://127.0.0.1:8180/lis/byeongriweb/PIE_Interface.live?Mode=reqGetComPatientInfo&Data1=16797637"); // 호출할 url
            request.Method = "GET";
            //request.ContentType = "application/x-www-form-urlencoded";


            //WebResponse response = request.GetResponse();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream, Encoding.Default, true);

            string responseFromServer = reader.ReadToEnd();

            //Console.WriteLine(responseFromServer); // response 출력


            reader.Close();
            dataStream.Close();
            response.Close();

            responseFromServer = responseFromServer.Trim();



            XElement element = XElement.Parse(responseFromServer.Trim());
            IEnumerable<XElement> rootElemets = element.Elements();
            DataTable resultDt = new DataTable();
            List<DataTable> resultList = new List<DataTable>();
            if (rootElemets.Where(e => e.Name == "resultKM").Count() > 0)
            {
                //에러가 발생된 경우 처리?
                StringReader theReader = new StringReader(responseFromServer);
                DataSet theDataSet = new DataSet();
                theDataSet.ReadXml(theReader);
                DataTable dt = theDataSet.Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Columns.Contains("error") && dt.Columns.Contains("description"))
                    {
                        DataRow row = dt.Rows[0];

                        if (row["error"].ToString() == "yes")
                        {
                            //서버 에러가 있는 경우 별도로 로그 생성하자
                            if (!string.IsNullOrEmpty(row["description"].ToString()))
                            {
                                logHelper.WriteLog("SERVER_ERROR", LogType.ERROR, ActionType.CALL_DB, "서버에러", row["description"].ToString(), paramInfo: connectionString);
                            }

                            if (ErrorMessageDisplay == true)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show(row["description"].ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return new CallResultData();
                            }
                            else
                            {
                                CallResultData resultData = new CallResultData();
                                resultData.resultState = ResultState.FAIL;
                                resultData.errorMessage = row["description"].ToString();
                                return resultData;
                            }

                            
                            
                        }
                    }
                }
            }
            else
            {
                if (rootElemets != null && rootElemets.Count() > 0)
                {
                    rootElemets.ToList().ForEach(item =>
                    {
                        if (item.Name == "info")
                        {
                            IEnumerable<XElement> elements = item.Elements();
                            resultDt = this.xmlElemntToDataTable(elements);
                        }
                        else if (item.Name == "AddCheoBang")
                        {
                            IEnumerable<XElement> elements = item.Elements().Elements();
                            resultDt = this.xmlElemntToDataTable(elements);
                        }
                        else
                        {
                            //그 외 테이블 결과값 처리... 
                            IEnumerable<XElement> elements = item.Elements();
                            
                            DataTable tempResultDt = this.xmlElemntToDataTable(elements, item.Name.ToString());
                            if (tempResultDt != null && tempResultDt.Rows.Count > 0)
                            {
                                resultList.Add(tempResultDt);
                            }

                        }
                    });
                }
            }

            CallResultData result = new CallResultData();
            result.resultData = resultDt;

            if (resultList != null && resultList.Count > 0)
            {
                result.resultDataList = resultList;
            }

            if (response.StatusCode == HttpStatusCode.OK)
            {
                result.resultState = ResultState.OK;
            }
            else
            {
                result.resultState = ResultState.FAIL;
            }



            return result;

        }




        /// <summary>
        /// name         : SelectSqlToPost
        /// desc         : DB접속(POST방식) - BLOB형식 데이터 전달시나 대용량 데이터 전달시에 사용
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public CallResultData SelectSqlToPost(string serviceName, KeyValueData param = null)
        {
            StringBuilder strParam = new StringBuilder();
            if (param != null && param.Count > 0)
            {
                for (int i = 0; i < param.Count; i++)
                {
                    string key = param.ElementAt(i).Key;
                    string value = param.ElementAt(i).Value;

                    strParam.Append("&" + key + "=" + HttpUtility.UrlEncode(value, System.Text.Encoding.GetEncoding("euc-kr")));
                }
            }


            string connectionString = string.Format("{0}{1}", ConnectInfo, serviceName);
            //string connectionString = string.Format("{0}{1}{2}", ConnectInfo, serviceName, strParam.ToString());
            WebRequest request = WebRequest.Create(connectionString); // 호출할 url
            //WebRequest request = WebRequest.Create("http://127.0.0.1:8180/lis/byeongriweb/PIE_Interface.live?Mode=reqGetComPatientInfo&Data1=16797637"); // 호출할 url
            request.Method = "POST";
            //request.ContentType = "application/x-www-form-urlencoded";


            //string postData = "This is a test that posts this string to a Web server.";
            byte[] byteArray = Encoding.UTF8.GetBytes(strParam.ToString());
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = byteArray.Length;
            Stream snedDataStream = request.GetRequestStream();
            snedDataStream.Write(byteArray, 0, byteArray.Length);
            snedDataStream.Close();


            //WebResponse response = request.GetResponse();
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream, Encoding.Default, true);

            string responseFromServer = reader.ReadToEnd();

            Console.WriteLine(responseFromServer); // response 출력


            reader.Close();
            dataStream.Close();
            response.Close();

            responseFromServer = responseFromServer.Trim();



            XElement element = XElement.Parse(responseFromServer.Trim());
            IEnumerable<XElement> rootElemets = element.Elements();
            DataTable resultDt = new DataTable();
            if (rootElemets.Where(e => e.Name == "resultKM").Count() > 0)
            {
                //에러가 발생된 경우 처리?
                StringReader theReader = new StringReader(responseFromServer);
                DataSet theDataSet = new DataSet();
                theDataSet.ReadXml(theReader);
                DataTable dt = theDataSet.Tables[0];

                if (dt != null && dt.Rows.Count > 0)
                {
                    if (dt.Columns.Contains("error") && dt.Columns.Contains("description"))
                    {
                        DataRow row = dt.Rows[0];

                        if (row["error"].ToString() == "yes")
                        {
                            //서버 에러가 있는 경우 별도로 로그 생성하자
                            if (!string.IsNullOrEmpty(row["description"].ToString()))
                            {
                                logHelper.WriteLog("SERVER_ERROR", LogType.ERROR, ActionType.CALL_DB, "서버에러", row["description"].ToString(), paramInfo: connectionString);
                            }

                            if (ErrorMessageDisplay == true)
                            {
                                DevExpress.XtraEditors.XtraMessageBox.Show(row["description"].ToString(), caption: "ERROR", buttons: MessageBoxButtons.OK, icon: MessageBoxIcon.Error);
                                return new CallResultData();
                            }
                            else
                            {
                                CallResultData resultData = new CallResultData();
                                resultData.resultState = ResultState.FAIL;
                                resultData.errorMessage = row["description"].ToString();
                                return resultData;
                            }
                        }
                    }
                }
            }
            else
            {
                if (rootElemets != null && rootElemets.Count() > 0)
                {
                    rootElemets.ToList().ForEach(item =>
                    {
                        if (item.Name == "info")
                        {
                            IEnumerable<XElement> elements = item.Elements();
                            resultDt = this.xmlElemntToDataTable(elements);
                        }
                    });
                }
            }

            CallResultData result = new CallResultData();
            result.resultData = resultDt;
            if (response.StatusCode == HttpStatusCode.OK)
            {
                result.resultState = ResultState.OK;
            }
            else
            {
                result.resultState = ResultState.FAIL;
            }



            return result;

        }

        private DataTable xmlElemntToDataTable(IEnumerable<XElement> elements, string tableName = "")
        {
            DataTable dt = new DataTable();
            if ( !string.IsNullOrEmpty(tableName))
            {
                dt.TableName = tableName;
            }
            List<string> columns = new List<string>();
            if (elements != null && elements.Count() > 0)
            {
                elements.ToList().ForEach(item =>
                {
                    if (!columns.Contains(item.Name.ToString()))
                    {
                        columns.Add(item.Name.ToString());
                    }
                });
            }

            if (columns.Count > 0)
            {
                for (int i = 0; i < columns.Count; i++)
                {
                    dt.Columns.Add(columns[i].ToString(), typeof(String));
                }

                string firstColumnName = columns[0].ToString();
                string lastColumName = columns[columns.Count - 1].ToString();
                DataRow row = null;
                if (elements != null && elements.Count() > 0)
                {
                    foreach (XElement ele in elements)
                    {
                        if (ele.Name == firstColumnName)
                        {
                            //첫번째 컬럼이니깐 datarow를 신규생성
                            row = dt.NewRow();
                            dt.Rows.Add(row);
                        }

                        if (ele.FirstNode != null && !string.IsNullOrEmpty(ele.FirstNode.ToString()))
                        {
                            row[ele.Name.ToString()] = ele.FirstNode.ToString();
                        }
                    }
                    //for (int i = 0; i < elements.Count(); i++)
                    //{
                    //    XElement ele = elements.ElementAt(i);
                    //    if (ele.Name == firstColumnName)
                    //    {
                    //        //첫번째 컬럼이니깐 datarow를 신규생성
                    //        row = dt.NewRow();
                    //        dt.Rows.Add(row);
                    //    }

                    //    if (ele.FirstNode != null && !string.IsNullOrEmpty(ele.FirstNode.ToString()))
                    //    {
                    //        row[ele.Name.ToString()] = ele.FirstNode.ToString();
                    //    }

                    //}
                }
            }


            return dt;


        }


        public bool SendEmail(string m_RecvMail, string m_SenderMail, string m_SenderName, string m_Title, string m_Msg, string m_RecvCCMail)
        {
            KeyValueData param = new KeyValueData();
            param.Add("Data1", m_RecvMail); //m_RecvMail
            param.Add("Data2", m_SenderMail); //m_SenderMail
            param.Add("Data3", m_SenderName); //m_SenderName
            param.Add("Data4", m_Title); //m_Title
            param.Add("Data5", m_Msg); //m_Msg
            param.Add("Data6", m_RecvCCMail); //m_RecvCCMail
            CallResultData result = this.SelectSql("reqSetSendMail", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                //DataTable dt = result.resultData;
                return true;
            }
            else
            {
                //실패에 대한 처리
                return false;
            }
        }
    }


}
