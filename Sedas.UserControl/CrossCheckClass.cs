using Sedas.Core;
using Sedas.DB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;


namespace Sedas.UserControl
{
    /// <summary>
    /// name         : CrossCheckClass
    /// desc         : 서버 프로그램 간에 메인-서브 체크
    /// author       : 심우종
    /// create date  : 2020-11-11 15:39
    /// update date  : 최종 수정일자 , 수정자, 수정개요
    /// </summary> 
    public class CrossCheckClass
    {
        CallService callService;
        public enum CrossCheckState
        {
            Ready
            , Work
        }

        string myIp;

        string titleId = "SERVER_STATE_CHECK";
        string codeId = "";
        string checkDiff = "3600"; //3600초 => 1시간

        //--------------------------------
        //상호 체크 서버 재시작을 위한 파라미터
        string crossCheckId = "";
        string crossCheckPw = "";
        string crossCheckIp = "";
        string isCrossCheckRestart = "N";
        string processName = "";
        string restartPath = "";
        //--------------------------------


        string restartGapReday = "N"; //Ready서버 재사용 기능 사용에 gap을 주기위해 사용
        DateTime restartGapCheckTime;

        /// <summary>
        /// name         : CrossCheckClass
        /// desc         : 생성자
        /// author       : 심우종
        /// create date  : 2020-11-11 16:09
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public CrossCheckClass(CallService callService, string myIp, string codeId, string checkDiff)
        {
            this.callService = callService;
            this.myIp = myIp;
            this.codeId = codeId;
            this.checkDiff = checkDiff;
            restartGapCheckTime = DateTime.Now;
        }


        /// <summary>
        /// name         : RestartDataSetting
        /// desc         : 타 서버가 죽었을때 다시 재시작시키기 위한 설정값을 받는다.
        /// author       : 심우종
        /// create date  : 2020-11-12 16:50
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void RestartDataSetting(string crossCheckIp, string crossCheckId, string crossCheckPw, string isCrossCheckRestart, string processName, string restartPath)
        {
            this.crossCheckIp = crossCheckIp;
            this.crossCheckId = crossCheckId;
            this.crossCheckPw = crossCheckPw;
            this.isCrossCheckRestart = isCrossCheckRestart;
            this.processName = processName;
            this.restartPath = restartPath;
        }

        /// <summary>
        /// name         : CheckDb
        /// desc         : 해당 IP의 사용가능여부를 확인한다.
        /// author       : 심우종
        /// create date  : 2020-11-11 17:25
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private string CheckDb()
        {
            try
            {
                KeyValueData param = new KeyValueData();
                param.Add("Data1", titleId);
                param.Add("Data2", codeId);
                param.Add("Data3", myIp);
                param.Add("Data4", checkDiff);
                CallResultData result = this.callService.SelectSql("reqGetSeverStateCheck", param);
                if (result.resultState == ResultState.OK)
                {
                    //데이터 조회 성공
                    DataTable dt = result.resultData;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string resultvalue = dt.Rows[0]["resultValue"].ToString();
                        return resultvalue;
                    }
                }
                else
                {
                    //실패에 대한 처리
                }
            }
            catch
            {

            }

            return "";
        }

        /// <summary>
        /// name         : CheckState
        /// desc         : ready-work 상태를 리턴해준다.
        /// author       : 심우종
        /// create date  : 2020-11-11 16:11
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public CrossCheckState CheckState()
        {

            if (restartGapReday == "N")
            {
                TimeSpan ts = DateTime.Now - restartGapCheckTime;
                if (ts.TotalSeconds > checkDiff.ToInt())
                {
                    restartGapReday = "Y";
                }
            }



            string resultValue = this.CheckDb();

            if (resultValue == "Y") //사용가능
            {
                return CrossCheckState.Work;
            }
            else if (resultValue == "A") //Ready 서버 작동안함.
            {
                if (isCrossCheckRestart == "Y" && restartGapReday == "Y") //Ready서버 재시작여부
                {
                    //크로스 서버 재시작
                    RemoteProcessReStart(this.crossCheckIp, this.crossCheckId, this.crossCheckPw, this.processName, this.restartPath);

                    //재시작후 다시 갭 체크
                    restartGapReday = "N";
                    restartGapCheckTime = DateTime.Now;
                }

                return CrossCheckState.Work;
            }
            else
            {
                return CrossCheckState.Ready;
            }
        }



        /// <summary>
        /// name         : RunExeForPsExec
        /// desc         : 원격지의 프로그램을 실행한다.
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void RunExeForPsExec(string ip, string userName, string password, string processName, string restartPath)
        {
            try
            {
                //실행파일이 있는 경로에 같이 있어야 함.
                string psExecPathAndName = System.Environment.CurrentDirectory + "\\" + "PsExec.exe";

                Process Psexec = new Process();
                Psexec.StartInfo.FileName = psExecPathAndName;
                Psexec.StartInfo.Arguments = "-accepteula";
                Psexec.Start();


                string workDirectroy = restartPath.Substring(0, restartPath.LastIndexOf("\\"));
                string command = string.Format("cmd /c start /d {0} /b {1} ReStart", workDirectroy, processName);
                Process proc = new Process();
                proc.StartInfo.FileName = psExecPathAndName;
                proc.StartInfo.Arguments = string.Format("\\\\{0} -i 2 -u {1} -p {2} {3}",
                                                         ip,
                                                         userName,
                                                         password,
                                                         command);
                proc.StartInfo.CreateNoWindow = true;
                proc.StartInfo.UseShellExecute = false;
                proc.Start();
            }
            catch
            {

            }

        }


        ManagementScope mScope;
        /// <summary>
        /// name         : RemoteProcessReStart
        /// desc         : standby 서버가 죽은경우 재실행한다.
        /// author       : 심우종
        /// create date  : 2020-11-12 17:01
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void RemoteProcessReStart(string ip, string userName, string password, string processName, string restartPath)
        {
            try
            {
                ConnectionOptions cConnectOption = new ConnectionOptions();
                //string ip = "10.10.221.71";

                cConnectOption.Username = userName; // "mj2kuh";
                cConnectOption.Password = password; // "sJ0802$!";
                mScope = new ManagementScope("\\\\" + ip + "\\root\\CIMV2", cConnectOption);
                mScope.Connect();

                //object[] theProcessToRun = { "notepad.exe" };

                ManagementClass theClass = new ManagementClass(mScope, new ManagementPath("Win32_Process"), new ObjectGetOptions());

                //1) 기존에 띄워져 있는 프로세스가 있으면 KILL
                ObjectQuery theQuery = new ObjectQuery("SELECT * FROM Win32_Process WHERE Name='" + processName + "'");
                ManagementObjectSearcher theSearcher = new ManagementObjectSearcher(mScope, theQuery);
                ManagementObjectCollection theCollection = theSearcher.Get();

                foreach (ManagementObject theCurObject in theCollection)
                {
                    //기존에 프로그램이 띄워져 있으면 kill
                    if (theCurObject["Caption"].ToString() == processName)
                    {
                        theCurObject.InvokeMethod("Terminate", null);
                    }
                }

                this.RunExeForPsExec(ip, userName, password, processName, restartPath);
                //2) 다시 실행 - sesstion를 지정하지 못해 process에만 올라오고 visible되지 않음. 사용못함.
                //object[] theProcessToRun = { restartPath + " ReStart" };
                //theClass.InvokeMethod("Create", theProcessToRun);
            }
            catch
            {

            }
        }




    }
}
