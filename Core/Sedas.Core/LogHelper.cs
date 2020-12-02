using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using log4net.Config;
using log4net.Appender;
using log4net.Layout;
using log4net.Repository.Hierarchy;
using System.Xml;
using log4net.Core;
using System.Reflection;
using System.IO;

namespace Sedas.Core
{
    public enum LogType
    {
        ERROR
            , WARRING
            , INFO
            , DEBUG
    }

    public enum ActionType
    {
        CALL_DB
            , INTERFACE
            , ACTION
            , ETC
    }

    public class LogDTO
    {
        public string logCode { get; set; }
        public string dept { get; set; }
        public string device { get; set; }
        public string date { get; set; }
        public string ptoNo { get; set; }
        public string ptno { get; set; }
        public string studyId { get; set; }
        public string accession_no { get; set; }
        public string ip { get; set; }
        public string location { get; set; }

        public string programName { get; set; }
        public LogType logType { get; set; }
        public ActionType actionType { get; set; }
        public string title { get; set; }
        public string message { get; set; }
        public string stackTrace { get; set; }
        public string paramInfo { get; set; }
        public string etc { get; set; }
        public string comment { get; set; }

        public string userid { get; set; }
        public string sysdate { get; set; }
        public string systime { get; set; }
    }

    public class LogHelper
    {
        string defaultIp = "10.10.50.142";
        string defaultPort = "28080";

        public LogHelper()
        {
            ft = new FileTransfer(defaultIp, defaultPort);
            ft.ShowErrorMessage = false;
        }

        public LogHelper(string ip, string port)
        {
            ft = new FileTransfer(ip, port);
            ft.ShowErrorMessage = false;
        }

        FileTransfer ft;

        public static int testIndex = 1;



        public async void WriteLog(string logCode, LogDTO logDTO)
        {
            WriteLogAfter(logCode, logDTO, false);
        }

        public async void WriteLog(string logCode, LogType logType, ActionType actionType, string title, string message, string ptoNo = "", string ptNo= "", string paramInfo = "", string etc = "", string studyId = "")
        {
            LogDTO dto = new LogDTO();
            dto.ptno = ptNo;
            dto.ptoNo = ptoNo;
            dto.logType = logType;
            dto.actionType = actionType;
            dto.title = title;
            dto.message = message;
            dto.paramInfo = paramInfo;
            dto.studyId = studyId;
            dto.etc = etc;


            WriteLogAfter(logCode, dto, false);
        }

        //public async void WriteLog(string logCode, string ptoNo, string ptNo)



        /// <summary>
        /// [사용안함]
        /// </summary>
        /// <param name="logCode"></param>
        /// <param name="ptoNo"></param>
        /// <param name="ptNo"></param>
        /// <param name="comments"></param>
        //public async void WriteLog(string logCode, string ptoNo, string ptNo, string[] comments)
        //{
        //    LogDTO dto = new LogDTO();
        //    dto.ptno = ptNo;
        //    dto.ptoNo = ptoNo;

        //    //if (comments != null && comments.Count() > 0)
        //    //{
        //    //    for (int i = 0; i < comments.Count(); i++)
        //    //    {
        //    //        string value = comments.ElementAt(i);
        //    //        if (i == 0)
        //    //        {
        //    //            dto.data_val_01 = value;
        //    //        }
        //    //        else if (i == 1)
        //    //        {
        //    //            dto.data_val_02 = value;
        //    //        }
        //    //        else if (i == 2)
        //    //        {
        //    //            dto.data_val_03 = value;
        //    //        }
        //    //        else if (i == 3)
        //    //        {
        //    //            dto.data_val_04 = value;
        //    //        }
        //    //        else if (i == 4)
        //    //        {
        //    //            dto.data_val_05 = value;
        //    //        }
        //    //        else if (i == 5)
        //    //        {
        //    //            dto.data_val_06 = value;
        //    //        }
        //    //    }
        //    //}

        //    //WriteLogAfter(logCode, dto, false);
        //}

        public async void WriteLogLocalOnly(string logCode, LogDTO logDTO)
        {
            WriteLogAfter(logCode, logDTO, true);
        }
        /// <summary>
        /// [사용안함]
        /// </summary>
        /// <param name="logCode"></param>
        /// <param name="ptoNo"></param>
        /// <param name="ptNo"></param>
        /// <param name="comments"></param>
        //public async void WriteLogLocalOnly(string logCode, string ptoNo, string ptNo, string[] comments)
        //{
        //    LogDTO dto = new LogDTO();
        //    dto.ptno = ptNo;
        //    dto.ptoNo = ptoNo;

        //    //if (comments != null && comments.Count() > 0)
        //    //{
        //    //    for (int i = 0; i < comments.Count(); i++)
        //    //    {
        //    //        string value = comments.ElementAt(i);
        //    //        if (i == 0)
        //    //        {
        //    //            dto.data_val_01 = value;
        //    //        }
        //    //        else if (i == 1)
        //    //        {
        //    //            dto.data_val_02 = value;
        //    //        }
        //    //        else if (i == 2)
        //    //        {
        //    //            dto.data_val_03 = value;
        //    //        }
        //    //        else if (i == 3)
        //    //        {
        //    //            dto.data_val_04 = value;
        //    //        }
        //    //        else if (i == 4)
        //    //        {
        //    //            dto.data_val_05 = value;
        //    //        }
        //    //        else if (i == 5)
        //    //        {
        //    //            dto.data_val_06 = value;
        //    //        }
        //    //    }
        //    //}

        //    ////await Task.Run(() =>
        //    ////{
        //    ////    WriteLogAfter(logCode, dto, true);
        //    ////});

        //    //WriteLogAfter(logCode, dto, true);
        //}

        private bool WriteLogAfter(string logCode, LogDTO logDTO, bool isLocalOnly)
        {
            try
            {
                if (logDTO == null) return false;

                //시스템 변수값 설정
                InitSystemValue(logCode, logDTO);

                //Random ran = new Random();
                //int ranValue = ran.Next(1, 200000);
                DateTime current = DateTime.Now;
                //파일명 지정...... logCode(5) + 병리번호+ 환자번호 + 년월일+ 시분초 + random숫자
                StringBuilder fileName = new StringBuilder();
                fileName.Append(current.ToString("yyyyMMdd"));
                fileName.Append("$");
                fileName.Append(current.ToString("HHmmss"));
                fileName.Append("$");
                fileName.Append(current.ToString("fff"));
                fileName.Append("$");
                fileName.Append(logCode);
                fileName.Append("$");
                fileName.Append(logDTO.ptoNo);
                fileName.Append("$");
                fileName.Append(logDTO.ptno);
                fileName.Append(".xml");
                //string fileName = logCode + "_" logDTO.ptoNo + "_" +  current.ToString("yyyyMMdd") + "_" + current.ToString("HHmmss") + "_" + ranValue.ToString() + ".xml";
                //testIndex++;

                string strFileName = System.Environment.CurrentDirectory + "\\" + "logs";

                DirectoryInfo di = new DirectoryInfo(strFileName);
                if (di.Exists == false)
                {
                    di.Create();
                }


                string fullPath = strFileName + "\\" + fileName.ToString();

                this.InitLog(fullPath);

                ILog logger = LogManager.GetLogger(this.GetType());

                //repository.ResetConfiguration();


                //[로그 내용 구성]
                //logger.Debug("<?xml version=\"1.0\" encoding=\"UTF - 8\"?>");

                logger.Debug("xml|Start");
                logger.Debug("<logroot>");

                PropertyInfo[] targetProperties = typeof(LogDTO).GetProperties(BindingFlags.Public | BindingFlags.Instance);
                //프로퍼티의 내용을 모두 차례대로 찍는다.
                foreach (PropertyInfo targetProperty in targetProperties)
                {
                    if (targetProperty.CanWrite && targetProperty.GetSetMethod() != null)
                    {
                        logger.Debug(targetProperty.Name + "|" + targetProperty.GetValue(logDTO, null) ?? " ");
                    }
                }

                logger.Debug("</logroot>");
                logger.Debug("xml|End");


                //로그파일을 잡고있지 않도록 처리
                LogManager.ResetConfiguration();

                if (isLocalOnly == false)
                {
                    SendToServer(fullPath, fileName.ToString());
                }

            }
            catch
            {

            }


            return true;
        }

        private void InitSystemValue(string logCode, LogDTO logDTO)
        {
            DateTime current = DateTime.Now;
            if (string.IsNullOrEmpty(logDTO.ip))
            {
                logDTO.ip = GetIp();
            }

            if (string.IsNullOrEmpty(logDTO.sysdate))
            {
                logDTO.sysdate = current.ToString("yyyyMMdd");
            }

            if (string.IsNullOrEmpty(logDTO.systime))
            {
                logDTO.systime = current.ToString("HHmmss");
            }

            if (string.IsNullOrEmpty(logDTO.userid))
            {
                if (!string.IsNullOrEmpty(SessionInfo.userId))
                {
                    logDTO.userid = SessionInfo.userId;
                }
            }

            if (string.IsNullOrEmpty(logDTO.programName))
            {
                if (!string.IsNullOrEmpty(SessionInfo.programName))
                {
                    logDTO.programName = SessionInfo.programName;
                }
            }

            logDTO.logCode = logCode;
        }

        private string GetIp()
        {
            System.Text.RegularExpressions.Regex regex = new System.Text.RegularExpressions.Regex(@"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$");
            foreach (System.Net.IPAddress ip in System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList)
            {
                if (regex.IsMatch(ip.ToString()))
                {
                    return ip.ToString();
                }
            }
            return null;
        }

        /// <summary>
        /// name         : SendToServer
        /// desc         : 로그데이터를 서버에 전송한다.
        /// author       : 심우종
        /// create date  : 2020-06-02 17:19
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private async void SendToServer(string localPathAndName, string fileName)
        {
            await Task.Run(() =>
            {
                SendToServerAsync(localPathAndName, fileName);
            });
        }

        private void SendToServerAsync(string localPathAndName, string fileName)
        {
            try
            {
                DateTime current = DateTime.Now;
                string serverPathAndName = "log\\" + current.ToString("yyyy") + "\\" + current.ToString("MM") + "\\" + current.ToString("dd") + "\\" + fileName;
                if (ft.FileUpload(localPathAndName, serverPathAndName) == true)
                {

                }
            }
            catch
            {

            }
        }

        /// <summary>
        /// name         : InitLog
        /// desc         : 로그세팅 정보 설정
        /// author       : 심우종
        /// create date  : 2020-06-02 14:18
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitLog(string path)
        {
            // 로그 매니져 세팅
            var repository = LogManager.GetRepository();

            repository.Configured = true;
            // 콘솔 로그 패턴 설정
            var consoleAppender = new ConsoleAppender();
            consoleAppender.Name = "Console";
            // 로그 패턴
            consoleAppender.Layout = new PatternLayout("%d [%t] %-5p %c - %m%n");
            // 파일 로그 패턴 설정
            var rollingAppender = new RollingFileAppender();
            rollingAppender.Name = "RollingFile";


            //DateTime current = DateTime.Now;
            //파일명 지정......
            //string fileName = current.ToString("yyyyMMdd") + "_" + testIndex.ToString();
            //testIndex++;


            // 로그 파일 설정
            rollingAppender.File = path;
            // 시스템이 기동되면 파일을 추가해서 할 것인가? 새로 작성할 것인가?
            rollingAppender.AppendToFile = true;
            //rollingAppender.DatePattern = "-yyyy-MM-dd";
            // 파일 단위는 날짜 단위인 것인가, 파일 사이즈인가?
            rollingAppender.RollingStyle = RollingFileAppender.RollingMode.Size;
            rollingAppender.MaxSizeRollBackups = 10;
            rollingAppender.MaximumFileSize = "10MB";
            rollingAppender.Encoding = Encoding.UTF8;
            rollingAppender.StaticLogFileName = true;
            rollingAppender.Layout = new XmlLogLayout();
            rollingAppender.LockingModel = new FileAppender.MinimalLock();



            var hierarchy = (Hierarchy)repository;
            hierarchy.Root.AddAppender(consoleAppender);
            hierarchy.Root.AddAppender(rollingAppender);
            rollingAppender.ActivateOptions();
            // 로그 출력 설정 All 이면 모든 설정이 되고 Info 이면 최하 레벨 Info 위가 설정됩니다.
            hierarchy.Root.Level = log4net.Core.Level.All;
        }



    }



    public class XmlLogLayout : XmlLayoutBase
    {
        protected override void FormatXml(XmlWriter writer, LoggingEvent loggingEvent)
        {

            //if (loggingEvent.MessageObject is log4net.Util.SystemStringFormat)
            //{
            //    log4net.Util.SystemStringFormat message = loggingEvent.MessageObject as log4net.Util.SystemStringFormat;
            //}

            string message = loggingEvent.RenderedMessage;
            string[] splMessage = message.Split('|');

            if (splMessage.Length == 2)
            {
                string name = splMessage.ElementAt(0);
                string value = splMessage.ElementAt(1);
                if (name == "xml")
                {
                    if (value == "Start")
                    {
                        writer.WriteStartDocument();
                    }
                    else if (value == "End")
                    {
                        writer.WriteEndDocument();
                        writer.Close();
                    }
                }
                else
                {
                    writer.WriteStartElement(name);
                    writer.WriteString(value);
                    writer.WriteFullEndElement();
                }
            }
            else
            {
                //writer.WriteStartAttribute("test");
                //writer.WriteAttributeString("test2");

                //writer.WriteEndAttribute();
                //writer.WriteString(message);
                //writer.WriteString(message);
                writer.WriteRaw(message);

            }

            //writer.WriteStartElement("LogEntry");

            //writer.WriteString(loggingEvent.RenderedMessage);

            //writer.WriteEndElement();
            //writer.WriteString(Environment.NewLine);

            //writer.WriteStartElement("Message");
            //writer.WriteString(loggingEvent.RenderedMessage);
            //writer.WriteEndElement();
        }
    }
}
