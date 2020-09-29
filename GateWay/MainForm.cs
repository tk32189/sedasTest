using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using Sedas.DB;
using Sedas.Core;
using System.IO;
using Dicom;
using Dicom.Network;
using BinaryAnalysis.UnidecodeSharp;

namespace GateWay
{
    public enum GateState
    {
        waiting
            , sending
            , stoped
            , failed
            , unknown
    }

    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        private String appPath = Application.StartupPath;
        CallService callService = new CallService("10.10.221.71", "8180");
        FileTransfer ft = new FileTransfer();


        public MainForm()
        {
            InitializeComponent();
        }


        /// <summary>
        /// name         : SendNotifyMsg
        /// desc         : 상태를 표시한다.
        /// author       : 심우종
        /// create date  : 2020-09-07 13:58
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SendNotifyMsg(GateState state)
        {
            switch (state)
            {
                case GateState.waiting:
                    TxtBoxTextChange(this.txtState, "Waiting");
                    ButtonTextChange(this.btnStart, "검색 중지");
                    this.EnableButtons(false);
                    break;
                case GateState.sending:
                    TxtBoxTextChange(this.txtState, "Sending");
                    ButtonTextChange(this.btnStart, "검색 중지");
                    this.EnableButtons(false);
                    break;
                case GateState.stoped:
                    TxtBoxTextChange(this.txtState, "Stoped");
                    ButtonTextChange(this.btnStart, "검색 시작");
                    this.EnableButtons(true);
                    break;
                case GateState.failed:
                    break;
                default:

                    break;
            }

        }

        private void ButtonTextChange(Sedas.Control.HSimpleButton control, string text)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate
                {
                    ButtonTextChange(control, text);
                }));
                return;
            }

            control.Text = text;
        }

        private void ButtonEnableChange(Sedas.Control.HSimpleButton control, bool isValue)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate
                {
                    ButtonEnableChange(control, isValue);
                }));
                return;
            }

            control.Enabled = isValue;
        }

        private void TxtBoxTextChange(Sedas.Control.HTextEdit control, string text)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate
                {
                    TxtBoxTextChange(control, text);
                }));
                return;
            }

            control.Text = text;
        }


        /// <summary>
        /// name         : EnableButtons
        /// desc         : 테스트, setting버튼 enable상태변경
        /// author       : 심우종
        /// create date  : 2020-09-07 14:05
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void EnableButtons(bool isEnable)
        {
            ButtonEnableChange(this.btnSetting, isEnable);
            ButtonEnableChange(this.btnTest, isEnable);
        }

        public static BackgroundWorker bgw = new BackgroundWorker();


        bool isRun = false;

        /// <summary>
        /// name         : btnStart_Click
        /// desc         : 시작 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-08-31 14:04
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnStart_Click(object sender, EventArgs e)
        {
            if (isRun == false)
            {
                Start();
            }
            else
            {
                isRun = false;
                //bgw.CancelAsync();
            }

        }

        private void Start()
        {
            this.isRun = true;


            bgw.RunWorkerAsync();
        }

        void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

            }
            catch (Exception ex)
            {

            }
        }

        public static string currentPtoNo = "";
        public static bool isErrorExist = false;

        private async void bgw_DoWorkAsync(object sender, DoWorkEventArgs e)
        {
            int interval = m_SettingValue.dwSearchInterval * 1000;

            this.SendNotifyMsg(GateState.waiting);

            while (isRun)
            {
                //if (bgw.CancellationPending)
                //{
                //    break;
                //}

                try
                {
                    System.Threading.Thread.Sleep(interval);

                    DataTable studyTable = null;
                    DataTable imageTable = null;
                    this.RetrieveStudyItems(ref studyTable, ref imageTable);

                    if (studyTable == null || studyTable.Rows.Count == 0) continue;
                    if (imageTable == null || imageTable.Rows.Count == 0) {

                        this.AddLog("처리할 이미지 정보 없음");
                        continue;
                    }

                    imageTable.Columns.Add("strLocalFilePath", typeof(string));
                    imageTable.Columns.Add("strDicomFilePath", typeof(string));
                    imageTable.Columns.Add("isSend", typeof(string));

                    for (int i = 0; i < studyTable.Rows.Count; i++)
                    {
                        try
                        {
                            DataRow row = studyTable.Rows[i];
                            string studyId = row["studyId"].ToString();
                            string ptNo = row["ptNo"].ToString();
                            string studyDt = row["studyDt"].ToString();
                            string ptoNo = row["ptoNo"].ToString();
                            string accessId = row["accessId"].ToString();
                            string tcd = row["tcd"].ToString();

                            List<DataRow> imageList = imageTable.AsEnumerable().Where(o => o["studyId"].ToString() == studyId).ToList();

                            MainForm.currentPtoNo = ptoNo;
                            MainForm.isErrorExist = false;
                            this.AddLog(string.Format("===== 작업시작 ===== : StudyID : {0} / ptNo : {1} / studyDt : {2} / ptoNo : {3} / accessId : {4} / tcd : {5} / File Count : {6}", studyId, ptNo, studyDt, ptoNo, accessId, tcd, imageList.Count.ToString()));

                            if (string.IsNullOrEmpty(studyId)
                                || string.IsNullOrEmpty(ptNo)
                                || string.IsNullOrEmpty(ptoNo)
                                || string.IsNullOrEmpty(accessId) || accessId.Length < 10
                                || string.IsNullOrEmpty(tcd)
                                || imageList == null || imageList.Count == 0
                                )
                            {
                                this.AddLog(string.Format("Ignored case : StudyID : {0} / ptNo : {1} / studyDt : {2} / ptoNo : {3} / accessId : {4} / tcd : {5} / File Count : {6}", studyId, ptNo, studyDt, ptoNo, accessId, tcd, imageList.Count.ToString()));
                                continue;
                            }

                            this.UpdateSendStatus(row, imageList, "7");

                            //Kuh table에 데이터 업데이트
                            if (this.UpdateKuhData(row) == false)
                            {
                                AddErrorLog(string.Format("Kuh Table update 실패 : StudyID : {0} / ptNo : {1} / studyDt : {2} / ptoNo : {3} / accessId : {4} / tcd : {5} / File Count : {6}", studyId, ptNo, studyDt, ptoNo, accessId, tcd, imageList.Count.ToString()));
                                //실패!!
                                this.UpdateSendStatus(row, imageList, "-1");
                                continue;
                            }
                            else
                            {
                                this.AddLog(string.Format("Kuh Table update 성공 : StudyID : {0} / ptNo : {1} / studyDt : {2} / ptoNo : {3} / accessId : {4} / tcd : {5} / File Count : {6}", studyId, ptNo, studyDt, ptoNo, accessId, tcd, imageList.Count.ToString()));
                            }


                            DicomDataset dataset = MakeDicomDataSet(row);
                            this.MakeDicomFile(dataset, row, imageList);

                            int dicomFileCount = 0;
                            foreach (DataRow imageRow in imageList)
                            {
                                if (imageRow != null)
                                {
                                    if (!string.IsNullOrEmpty(imageRow["strDicomFilePath"].ToString()))
                                    {
                                        dicomFileCount++;
                                    }
                                }
                            }



                            if (dicomFileCount > 0)
                            {
                                this.SendNotifyMsg(GateState.sending);
                                this.UpdateSendStatus(row, imageList, "7");


                                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                //다이콤 전송!!!!!!!!!!!!!!!!
                                //!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
                                if (SendDicom(row, imageList) == true)
                                {
                                    //CString SendedAccessionNo = DicomNet.GetCurrentAccession();
                                    string SendedAccessionNo = "";

                                    //if (SendedAccessionNo.Compare(item.AccessionNo) == 0)
                                    if (true)
                                    {
                                        if (this.SetOACRPACSH(row) == false)
                                        {
                                            AddErrorLog(string.Format("OACRPACSH update 실패 : StudyID : {0} / ptNo : {1} / studyDt : {2} / ptoNo : {3} / accessId : {4} / tcd : {5} / File Count : {6}", studyId, ptNo, studyDt, ptoNo, accessId, tcd, imageList.Count.ToString()));
                                        }
                                        else
                                        {
                                            AddLog(string.Format("OACRPACSH update 성공 : StudyID : {0} / ptNo : {1} / studyDt : {2} / ptoNo : {3} / accessId : {4} / tcd : {5} / File Count : {6}", studyId, ptNo, studyDt, ptoNo, accessId, tcd, imageList.Count.ToString()));
                                        }


                                        //예전 Call OCSif.dll => SetOOEROPDOH로 변경
                                        if (this.SetOOEROPDOH(row) == false)
                                        {
                                            AddErrorLog(string.Format("OOEROPDOH update 실패 : StudyID : {0} / ptNo : {1} / studyDt : {2} / ptoNo : {3} / accessId : {4} / tcd : {5} / File Count : {6}", studyId, ptNo, studyDt, ptoNo, accessId, tcd, imageList.Count.ToString()));
                                        }
                                        else
                                        {
                                            this.AddLog(string.Format("OOEROPDOH update 성공 : StudyID : {0} / ptNo : {1} / studyDt : {2} / ptoNo : {3} / accessId : {4} / tcd : {5} / File Count : {6}", studyId, ptNo, studyDt, ptoNo, accessId, tcd, imageList.Count.ToString()));
                                        }

                                        this.UpdateSendStatus(row, imageList, "-1");
                                    }
                                    //else
                                    //{
                                    //    if (pConfig->GetValue(TYPE_LOGGING))
                                    //    {
                                    //        CString logmsg;
                                    //        logmsg.Format("Mismatched accession number : %s, Updated nothing.", SendedAccessionNo);
                                    //        pConfig->Logging(logmsg);
                                    //    }
                                    //    UpdateSendStatus(&item, DicomNet.GetISerials(), 777);
                                    //}
                                }
                                else
                                {
                                    this.UpdateSendStatus(row, imageList, "6");
                                }

                                System.Threading.Thread.Sleep(200);

                            }
                            else
                            {
                                this.UpdateSendStatus(row, imageList, "5");
                            }
                        }
                        finally
                        {
                            if (MainForm.isErrorExist == true)
                            {
                                this.SendEmailByError(MainForm.currentPtoNo);
                            }
                        }



                    } //[end for]

                    MainForm.currentPtoNo = "";


                    this.SendNotifyMsg(GateState.waiting);
                }
                catch (Exception ex)
                {
                    AddErrorLog(ex.Message);
                    AddErrorLog(ex.StackTrace);
                }

                //SendLogToServer();


            } //[end while]

            this.SendNotifyMsg(GateState.stoped);



        }



        /// <summary>
        /// name         : SendEmailByError
        /// desc         : 에러 발생시 Email로 에러전송
        /// author       : 심우종
        /// create date  : 2020-09-21 11:12
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SendEmailByError(string ptoNo)
        {
            try
            {
                if (m_SettingValue.bSendEmailByError == true && m_SettingValue.emailAddressList != null && m_SettingValue.emailAddressList.Count > 0)
                {
                    FileInfo file = new FileInfo(String.Format(@"{0}\Log\{1}", appPath, ptoNo + ".TXT"));
                    if (file.Exists)
                    {
                        

                        StringBuilder message = new StringBuilder();
                        //message.Append("병리번호 : " + ptoNo + "의 PACS 전송에 실패하였습니다.");
                        //message.Append(Environment.NewLine);
                        //message.Append(Environment.NewLine);

                        string text = System.IO.File.ReadAllText(file.FullName);

                        string[] splText = text.Split('\n');
                        string m_templete = "";
                        m_templete += "<HTML>";
                        //m_templete += "    <HEAD>";
                        //m_templete += "        <TITLE></TITLE>";
                        //m_templete += "        <META content='text/html; charset=euc-kr' http-equiv=Content-Type>";
                        //m_templete += "        <META name=GENERATOR content=ActiveSquare>";
                        //m_templete += "    </HEAD>";
                        m_templete += "    <BODY style='FONT-FAMILY: 맑은고딕; FONT-SIZE: 9pt'>";
                        m_templete += "        <DIV align=left>";
                        m_templete += "           <TABLE style='WIDTH: 100%; table-layout:fixed;'border=0 cellSpacing=0 borderColor=#7f7f7f>";
                        m_templete += "              <TBODY>";


                        m_templete += "                      <TR><TD>" + "병리번호 : " + ptoNo + "의 PACS 전송에 실패하였습니다." + "</TD></TR>";
                        m_templete += "                      <TR><TD>" + " " + "</TD></TR>";
                        m_templete += "                      <TR><TD>" + " " + "</TD></TR>";
                        m_templete += "                      <TR><TD>" + "==================Error Log========================" + "</TD></TR>";
                        m_templete += "                      <TR><TD>" + " " + "</TD></TR>";
                        m_templete += "                      <TR><TD>" + " " + "</TD></TR>";


                        for (int i = 0; i < splText.Count(); i++)
                        {
                            string childText = splText.ElementAt(i);

                            m_templete += "                      <TR><TD>" + childText + "</TD></TR>";
                        }

                        m_templete += "              </TBODY>";
                        m_templete += "            </TABLE>";
                        m_templete += "        </DIV>";
                        m_templete += "    </BODY>";
                        m_templete += "</HTML>";

                        message.Append(m_templete);

                        for (int i = 0; i < m_SettingValue.emailAddressList.Count; i++)
                        {
                            string emailAddress = m_SettingValue.emailAddressList.ElementAt(i);
                            string m_RecvMail = emailAddress;
                            string m_SenderMail = "tk32189@gamil.com"; // "kuh@kuh.ac.kr";
                            string m_SenderName = "Sedas";
                            string m_Title = "PACS 전송 실패 알림 : 병리번호(" + ptoNo + ")";
                            string m_Msg = message.ToString();
                            string m_RecvCCMail = "";

                            this.callService.SendEmail(m_RecvMail, m_SenderMail, m_SenderName, m_Title, m_Msg, m_RecvCCMail);
                        }
                    }

                }
            }
            catch
            { 
            
            }
            
        }

        /// <summary>
        /// name         : SendLogToServer
        /// desc         : 로그파일을 파일서버에 복사
        /// author       : 심우종
        /// create date  : 2020-09-10 10:24
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SendLogToServer()
        {
            try
            {
                string path = string.Format(@"{0}\Log\{1}", appPath, DateTime.Now.ToShortDateString() + ".TXT");
                FileInfo file = new FileInfo(path);
                if (file.Exists)
                {
                    string serverPathAndName = "log" + "\\" + "gateway" + "\\" + DateTime.Now.ToShortDateString() + ".TXT";
                    if (ft.FileUpload(path, serverPathAndName) == true)
                    {

                    }
                }
            }
            catch
            {

            }

        }


        /// <summary>
        /// name         : SetOACRPACSH
        /// desc         : OACRPACSH 테이블 수정
        /// author       : 심우종
        /// create date  : 2020-09-09 14:26
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool SetOACRPACSH(DataRow row)
        {
            KeyValueData param = new KeyValueData();
            param.Add("Data1", row["accessId"].ToString());
            param.Add("Data2", row["ptNo"].ToString());
            param.Add("Data3", row["lastUpdtDt"].ToString());
            param.Add("Data4", row["drCd"].ToString());
            CallResultData result = this.callService.SelectSql("reqSetGateOacrpacsh", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                //DataTable dt = result.resultData;
                return true;
            }
            else
            {
                //실패에 대한 처리
                if (!string.IsNullOrEmpty(result.errorMessage))
                {
                    AddErrorLog(result.errorMessage);
                }
                return false;
            }


        }



        /// <summary>
        /// name         : SetOOEROPDOH
        /// desc         : OOEROPDOH 데이터 업데이트
        /// author       : 심우종
        /// create date  : 2020-09-17 10:00
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool SetOOEROPDOH(DataRow row)
        {
            KeyValueData param = new KeyValueData();
            param.Add("Data1", row["accessId"].ToString());
            CallResultData result = this.callService.SelectSql("reqSetGateOoeropdoh", param);
            if (result.resultState == ResultState.OK)
            {
                return true;
            }
            else
            {
                //실패에 대한 처리
                if (!string.IsNullOrEmpty(result.errorMessage))
                {
                    AddErrorLog(result.errorMessage);
                }
                return false;
            }
        }


        /// <summary>
        /// name         : SendDicom
        /// desc         : 다이콤 파일을 전송한다.
        /// author       : 심우종
        /// create date  : 2020-09-07 16:30
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool SendDicom(DataRow row, List<DataRow> imageList)
        {
            foreach (DataRow imageRow in imageList)
            {
                if (imageRow != null)
                {
                    if (!string.IsNullOrEmpty(imageRow["strDicomFilePath"].ToString()))
                    {
                        //여기서 보내자..
                        string serialNo = imageRow["serialNo"].ToString();
                        string strDicomFilePath = imageRow["strDicomFilePath"].ToString();
                        //string dicomSendIp = "";
                        //int dicomSendPort = 1111;

                        string serverAE = m_SettingValue.szPacsServerAE;
                        string clientAe = m_SettingValue.szPacsClientAE;
                        string pacsIp = m_SettingValue.szPacsIP;
                        int port = m_SettingValue.nPacsPort;

                        //PCAS 전송 성공하면
                        if (this.SendDicomToPacs(strDicomFilePath, clientAe, pacsIp, port, serverAE) == true)
                        {
                            imageRow["isSend"] = "Y"; //dicom 전송 성공여부
                            AddLog("Dicom PACS 전송성공 [Success]: " + "serialNo : " + serialNo);

                            this.SendDicomToServer(strDicomFilePath, row["ptoNo"].ToString(), row["studyId"].ToString(), serialNo);
                        }
                        else
                        {
                            //실패
                            AddErrorLog("Dicom PACS 전송실패: " + "serialNo : " + serialNo);
                        }


                    }
                }
            }

            return true;
        }


        /// <summary>
        /// name         : SendDicomToServer
        /// desc         : Image테이블에 저장
        /// author       : 심우종
        /// create date  : 2020-04-22 10:48
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool SendDicomToServer(string strDicomFilePath, string ptoNo, string studyId, string serialNo)
        {


            DateTime current = DateTime.Now;
            string filePath = "dicom\\"; // g_PathData.strImagePath;
            string tempPath = current.ToString("yyyy") + "\\";
            filePath = filePath + tempPath;

            tempPath = ptoNo + "\\";
            filePath = filePath + tempPath;

            string fileName = ptoNo + "_" + current.ToString("yyyyMMddHHmmss") + serialNo.ToString() + ".dcm";
            string savePath = filePath + fileName;


            //localPathAndName : 로컬 파일 경로 ( ex : C:\Users\tk321\OneDrive\사진\Screenshots\1.JPG)
            //serverPathAndName : 서버에 저장될 파일 경로 (ex : Imagedata\20200521\M0000001\202005211629240.jpg)
            if (ft.FileUpload(strDicomFilePath, savePath) == true)
            {
                string paramMessage = "ptoNo : " + ptoNo + " / " + "serialNo : " + serialNo;
                AddLog("파일서버에 Dicom 전송 성공 : " + paramMessage);

                string insertDt = DateTime.Now.ToString("yyyyMMddHHmmss");
                KeyValueData param = new KeyValueData();
                param.Add("Data1", "5"); //nType
                param.Add("Data2", serialNo); //nSerialNo
                param.Add("Data3", studyId); //nStudyId
                param.Add("Data4", "Z:\\"); //strSaveRootPath
                param.Add("Data5", savePath); //strSaveFilePath
                param.Add("Data6", "0"); //nSendStatus

                param.Add("Data7", "0"); //nGI
                param.Add("Data8", "0"); //nMI
                param.Add("Data9", "0"); //nOI
                param.Add("Data10", insertDt);
                param.Add("Data11", SessionInfo.userId);
                CallResultData result = this.callService.SelectSql("reqInsViewerImageData", param);
                if (result.resultState == ResultState.OK)
                {
                    //데이터 조회 성공
                    DataTable dt = result.resultData;
                    if (dt != null && dt.Rows.Count > 0)
                    {
                        string resultValue = dt.Rows[0]["resultValue"].ToString();
                        if (!string.IsNullOrEmpty(resultValue))
                        {
                            this.AddLog(resultValue);
                            return false;
                        }
                    }

                    paramMessage = "savePath : " + savePath;
                    AddLog("이미지 테이블 저장 성공 : " + paramMessage);

                    return true;
                }
                else
                {
                    //실패에 대한 처리
                    if (!string.IsNullOrEmpty(result.errorMessage))
                    {
                        AddErrorLog(result.errorMessage);
                    }

                    paramMessage = "savePath : " + savePath;
                    AddErrorLog("이미지 테이블 저장 실패 : " + paramMessage);
                    return false;
                }
            }
            else
            {
                //전송실패
                string paramMessage = "ptoNo : " + ptoNo + " / " + "serialNo : " + serialNo;
                AddErrorLog("파일서버에 Dicom 전송 실패 : " + paramMessage);
            }

            return false;
        }


        /// <summary>
        /// name         : SendToPacs
        /// desc         : 다이콤 파일을 PACS에 전송한다.
        /// author       : 심우종
        /// create date  : 2020-09-17 10:10
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool SendDicomToPacs(string dcmfile, string sourceAET, string targetIP, int targetPort, string targetAET)
        {
            if (Global.isDev == true)
            {
                //개발은 PACS전송은 하지 말자
                return true;
            }

            try
            {
                var m_pDicomFile = DicomFile.Open(dcmfile);
                DicomClient pClient = new DicomClient();

                pClient.NegotiateAsyncOps();
                pClient.AddRequest(new DicomCStoreRequest(m_pDicomFile, DicomPriority.Medium));
                pClient.Send(targetIP, targetPort, false, sourceAET, targetAET);

                return true;
            }
            catch(Exception ex)
            {
                AddErrorLog("Dicom 전송 실패 : " + dcmfile);
                AddErrorLog(ex.Message);
                AddErrorLog(ex.StackTrace);
            }

            return false;
            
            
        }


        /// <summary>
        /// name         : UpdateSendStatus
        /// desc         : Send State를 업데이트한다.
        /// author       : 심우종
        /// create date  : 2020-09-07 15:44
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void UpdateSendStatus(DataRow row, List<DataRow> imageSerial, string etc)
        {
            int sendImageCount = 0;
            for (int i = 0; i < imageSerial.Count; i++)
            {
                DataRow imageRow = imageSerial[i];
                string serialNo = imageRow["serialNo"].ToString();
                string isSend = imageRow["isSend"].ToString();

                string sendStat = "";

                if (isSend == "Y")
                {
                    sendStat = "1";
                    sendImageCount++;
                }
                else
                {
                    sendStat = "2";
                }

                if (etc != "-1")
                {
                    sendStat = etc;
                }

                //이미지 테이블 상태 변경
                this.reqSetGateImageState(sendStat, row["studyId"].ToString(), serialNo);
            }

            string sendMsg = "";
            string sendState = "-1";
            if (sendImageCount == imageSerial.Count())
            {
                sendMsg = "All images sended";
                sendState = "1";
            }
            else if (sendImageCount > 0 && sendImageCount < imageSerial.Count())
            {
                sendMsg = "Some images sended";
                sendState = "3";
            }
            else
            {
                sendMsg = "No images sended";
                sendState = "2";
            }

            if (etc != "-1")
            {
                sendState = etc;
            }


            if (this.reqSetGateStudyState(sendState, row["studyId"].ToString()) == true)
            {
                AddLog("StudyTable Update [Success]: " + "etc:" + etc + " : " + sendMsg);
            }
            else
            {
                AddLog("StudyTable Update [Failure]: " + "etc:" + etc + " : " + sendMsg);
            }
        }


        /// <summary>
        /// name         : reqSetGateImageState
        /// desc         : 이미지 테이블 상태변경
        /// author       : 심우종
        /// create date  : 2020-09-07 16:02
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool reqSetGateImageState(string sendStat, string studyId, string serialNo)
        {
            KeyValueData param = new KeyValueData();
            param.Add("Data1", sendStat);
            param.Add("Data2", studyId);
            param.Add("Data3", serialNo);
            CallResultData result = this.callService.SelectSql("reqSetGateImageState", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;
                return true;
            }
            else
            {
                //실패에 대한 처리
                if (!string.IsNullOrEmpty(result.errorMessage))
                {
                    AddErrorLog(result.errorMessage);
                }

                return false;
                //실패에 대한 처리
            }

        }


        /// <summary>
        /// name         : reqSetGateStudyState
        /// desc         : Study 테이블 상태변경
        /// author       : 심우종
        /// create date  : 2020-09-07 16:02
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool reqSetGateStudyState(string sendStat, string studyId)
        {
            KeyValueData param = new KeyValueData();
            param.Add("Data1", sendStat);
            param.Add("Data2", studyId);
            CallResultData result = this.callService.SelectSql("reqSetGateStudyState", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;
                return true;
            }
            else
            {
                //실패에 대한 처리
                if (!string.IsNullOrEmpty(result.errorMessage))
                {
                    AddErrorLog(result.errorMessage);
                }
                return false;
            }

        }

        private DicomDataset MakeDicomDataSet(DataRow row)
        {
            DicomDataset dataset = new DicomDataset();

            //DicomEncoding.GetEncoding("ISO 2022 IR 101");
            //DicomEncoding.GetEncoding("GB18030")
            //환자정보

            string nowDate = DateTime.Now.ToString("yyyyMMdd");
            string nowTime = DateTime.Now.ToString("HHmmss");
            //ISO 2022 IR 149
            dataset.Add(DicomTag.SpecificCharacterSet, "ISO_IR 100");
            dataset.Add(DicomTag.ImageType, "DERIVED\\SECONDARY\\MPR");
            //if (!SetStringValueToElement(TAG_SOP_INSTANCE_UID, pDicomData->strUidSopInstance))
            dataset.Add(DicomTag.InstanceCreationDate, nowDate);
            dataset.Add(DicomTag.StudyDate, nowDate);
            //dataset.Add(DicomTag.SeriesDate, nowDate);
            dataset.Add(DicomTag.ContentDate, nowDate);
            dataset.Add(DicomTag.AcquisitionDate, nowDate);
            dataset.Add(DicomTag.CreationTime, nowTime);
            dataset.Add(DicomTag.StudyTime, nowTime);

            //dataset.Add(DicomTag.SeriesTime, nowTime);

            dataset.Add(DicomTag.ContentTime, nowTime);
            dataset.Add(DicomTag.AcquisitionTime, nowTime);
            dataset.Add(DicomTag.AccessionNumber, row["accessId"].ToString());
            dataset.Add(DicomTag.Modality, m_SettingValue.szModality);
            dataset.Add(DicomTag.Manufacturer, "Sedas Media");
            dataset.Add(DicomTag.InstitutionName, "KUH");
            dataset.Add(DicomTag.StudyDescription, row["ordNm"].ToString());
            dataset.Add(DicomTag.ManufacturerModelName, "DISP");


            dataset.Add(DicomTag.PatientID, row["ptNo"].ToString());


            string engName = "";
            try
            {
                engName = row["ptNm"].ToString().Unidecode();
            }
            catch
            { 
            
            }
            dataset.Add(DicomTag.PatientName, engName);
            dataset.Add(DicomTag.PatientBirthDate, row["birth"].ToString().Replace("-", ""));
            dataset.Add(DicomTag.PatientSex, row["sex"].ToString());
            dataset.Add(DicomTag.PatientAge, row["age"].ToString());
            dataset.Add(DicomTag.BodyPartExamined, row["dstudy1"].ToString());


            string studyInstanceUID = m_SettingValue.szStudyInstanceUID + "." + row["accessId"].ToString() + ".2";
            dataset.Add(DicomTag.StudyInstanceUID, studyInstanceUID);

            string seriesInstanceUID = m_SettingValue.szStudyInstanceUID + "." + row["accessId"].ToString() + ".3";
            dataset.Add(DicomTag.SeriesInstanceUID, seriesInstanceUID);
            dataset.Add(DicomTag.StudyID, row["studyId"].ToString());


            dataset.Add(DicomTag.SeriesNumber, "1");
            dataset.Add(DicomTag.ImagesInAcquisition, "1");
            dataset.Add(DicomTag.LossyImageCompression, "00");



            //dataset.Add(DicomTag.ModalitiesInStudy, m_SettingValue.szModality);
            AddLog(string.Format("SetElements_StudyInstanceUid : {0}, SeriesInstanceUid : {1}", studyInstanceUID, seriesInstanceUID));

            //------------------------------------------------------------

            //아래는 알수없는 데이터.. 
            dataset.Add(DicomTag.SOPClassUID, DicomUID.SecondaryCaptureImageStorage);
            dataset.Add(DicomTag.ReferringPhysicianName, string.Empty);
            dataset.Add(DicomTag.NumberOfStudyRelatedInstances, "1");
            dataset.Add(DicomTag.NumberOfStudyRelatedSeries, "1");
            dataset.Add(DicomTag.NumberOfSeriesRelatedInstances, "1");
            dataset.Add(DicomTag.PatientOrientation, "F/A");
            dataset.Add(DicomTag.ImageLaterality, "U");

            dataset.Add(DicomTag.ConversionType, "a");
            dataset.Add(DicomTag.BitsAllocated, (ushort)8);

            return dataset;

        }


        /// <summary>
        /// name         : MakeDicomFile
        /// desc         : Dicom File을 생성한다.
        /// author       : 심우종
        /// create date  : 2020-09-04 15:06
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void MakeDicomFile(DicomDataset dataset, DataRow row, List<DataRow> imageList)
        {
            this.ImageFileDownload(imageList, row);

            for (int i = 0; i < imageList.Count; i++)
            {
                DataRow imageRow = imageList[i];
                try
                {


                    if (string.IsNullOrEmpty(imageRow["strLocalFilePath"].ToString()))
                    {
                        continue;
                    }

                    string serialNo = imageRow["serialNo"].ToString();
                    dataset.AddOrUpdate(DicomTag.InstanceNumber, serialNo);

                    DateTime current = DateTime.Now;
                    string strCurrent = current.ToString("yyyyMMddHHmmss") + "." + serialNo;

                    string strUidStudyInstance = m_SettingValue.szStudyInstanceUID + "." + strCurrent + ".1";
                    dataset.AddOrUpdate(DicomTag.SOPInstanceUID, strUidStudyInstance);

                    string dicomFileName = strCurrent + "_" + i.ToString();
                    string dicomFilePathAndName = Global.dicomFolder + "\\" + dicomFileName + ".dcm";

                    string targetPath = DicomClass.MakeDicom(dataset, imageRow["strLocalFilePath"].ToString(), dicomFilePathAndName);

                    if (!string.IsNullOrEmpty(targetPath))
                    {
                        string param = StringforLogParam(imageRow, new string[] { "studyId", "serialNo" });
                        AddLog("Dicom 생성 성공 : " + param);
                    }

                    imageRow["strDicomFilePath"] = targetPath;
                }
                catch (Exception ex)
                {
                    string param = StringforLogParam(imageRow, new string[] { "studyId", "serialNo" });
                    AddErrorLog("Dicom 생성 실패 : " + param);
                    AddErrorLog(ex.Message);
                    AddErrorLog(ex.StackTrace);
                }

            }
        }

        //public void AddErrorLog(string message)
        //{
        //    if (m_SettingValue.bLogging == true)
        //    {
        //        StreamWriter oStreamWriter = new StreamWriter(String.Format(@"{0}\Log\{1}", appPath, DateTime.Now.ToShortDateString() + ".TXT"), true);
        //        oStreamWriter.WriteLine(String.Format("[ERROR] {0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message));
        //        oStreamWriter.Close();
        //    }

        //}




        /// <summary>
        /// name         : ImageFileDownload
        /// desc         : Dicom변환이 필요한 이미지 파일들을 다운로드한다.
        /// author       : 심우종
        /// create date  : 2020-09-04 15:11
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ImageFileDownload(List<DataRow> imageList, DataRow row)
        {
            if (imageList == null || imageList.Count == 0) return;

            //임시폴더에 데이터 삭제
            DirectoryInfo di = new DirectoryInfo(Global.tempFolder);
            if (di.Exists == false)
            {
                di.Create();
            }
            else
            {
                //모두 삭제
                FileInfo[] files = di.GetFiles();
                if (files != null && files.Count() > 0)
                {
                    foreach (FileInfo file in files)
                    {
                        file.Delete();
                    }
                }
            }

            DirectoryInfo diDicom = new DirectoryInfo(Global.dicomFolder);
            if (diDicom.Exists == false)
            {
                diDicom.Create();
            }
            else
            {
                //모두 삭제
                FileInfo[] files = diDicom.GetFiles();
                if (files != null && files.Count() > 0)
                {
                    foreach (FileInfo file in files)
                    {
                        file.Delete();
                    }
                }
            }



            for (int i = 0; i < imageList.Count; i++)
            {
                DataRow imageRow = imageList[i];

                string savedFileName = "";
                if (ft.FileDownLoad(imageRow["filePath"].ToString(), Global.tempFolder, ref savedFileName) == true)
                {
                    imageRow["strLocalFilePath"] = savedFileName;
                    string param = StringforLogParam(imageRow, new string[] { "studyId", "filePath", "serialNo" });
                    AddLog("이미지 다운로드 성공 : " + param);
                }
                else
                {
                    string param = StringforLogParam(imageRow, new string[] { "studyId", "filePath", "serialNo" });
                    AddErrorLog("이미지 다운로드 실패 : " + param);
                }
            }
        }


        /// <summary>
        /// name         : StringforLogParam
        /// desc         : 해당컬럼에 대한 key, value리턴
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private string StringforLogParam(DataRow row, string[] columnNames)
        {
            try
            {
                if (row == null) return "";
                if (columnNames == null || columnNames.Count() == 0) return "";

                StringBuilder strMessage = new StringBuilder();

                for (int i = 0; i < columnNames.Count(); i++)
                {
                    string key = columnNames.ElementAt(i);

                    if (row.Table.Columns.Contains(key))
                    {
                        strMessage.Append(" / ");
                        strMessage.Append(key + " : ");
                        strMessage.Append(row[key].ToString());
                    }
                }


                return strMessage.ToString();

            }
            catch
            {

            }

            return "";

        }

        int db_interval = 0;
        /// <summary>
        /// name         : DicomSendProcess
        /// desc         : Dicom정보 전달 
        /// author       : 심우종
        /// create date  : 2020-08-31 14:06
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void DicomSendProcess()
        {
            //CWnd* pWnd = (CWnd*)pArg;
            //ConfigManager* pConfig = ConfigManager::GetPointer();
            //DWORD SleepInterval = (DWORD)pConfig->GetValue(TYPE_SERARCH_INTERVAL) * 1000;
            //CDicomNetwork DicomNet(NULL, DICOM_SECURE_NONE);
            //DICOM_DATA DicomData;
            //StudyItemSet StudyItems;

            int SleepInterval = m_SettingValue.dwSearchInterval * 1000;

            //::CoInitialize(NULL);

            // 대기중으로 표시
            //SendNotifyMsg(pWnd, GLOBAL_STATUS_WAIT);

            while (Global.isRun)
            {
                int nReturnValue = -1;
                //DicomData.Clean();
                //StudyItems.clear();


                System.Threading.Thread.Sleep(SleepInterval);

                db_interval += SleepInterval;
                if (db_interval >= 1200000)
                {
                    //if (pConfig->GetValue(TYPE_LOGGING))
                    //{
                    //	CString tmp;
                    //	tmp.Format("%d", db_interval);
                    //	pConfig->Logging(tmp);
                    //}

                    //db_interval = 0;
                    //SelectLPRPRSTHM("");
                }

                DataTable studyTable = null;
                DataTable imageTable = null;
                this.RetrieveStudyItems(ref studyTable, ref imageTable);

                if (studyTable == null || studyTable.Rows.Count == 0) continue;

                for (int i = 0; i < studyTable.Rows.Count; i++)
                {
                    DataRow row = studyTable.Rows[i];
                    string studyId = row["studyId"].ToString();
                    string ptNo = row["ptNo"].ToString();
                    string studyDt = row["studyDt"].ToString();
                    string ptoNo = row["ptoNo"].ToString();
                    string accessId = row["accessId"].ToString();
                    string tcd = row["tcd"].ToString();

                    if (string.IsNullOrEmpty(studyId)
                        || string.IsNullOrEmpty(ptNo)
                        || string.IsNullOrEmpty(ptoNo)
                        || string.IsNullOrEmpty(accessId) || accessId.Length < 15
                        || string.IsNullOrEmpty(tcd)
                        )
                    {
                        this.AddLog(string.Format("Ignored case : StudyID : {0} / ptNo : {1} / studyDt : {2} / ptoNo : {3} / accessId : {4} / tcd : {5}", studyId, ptNo, studyDt, ptoNo, accessId, tcd));
                        continue;
                    }

                    //SEND_ITEM item = *Iterator;
                    //UpdateSendStatus(&item, DicomNet.GetISerials(), 7);

                    //if (!SelectLPRPRSTHM(item.PathologyNo))
                    //{
                    //	UpdatePacsNo(&item);
                    //}
                    //else
                    //{
                    //	UpdateSendStatus(&item, DicomNet.GetISerials(), -1);
                    //	if (pConfig->GetValue(TYPE_LOGGING))
                    //	{
                    //		CString logmsg;
                    //		logmsg.Format("No record in the LPRPRSTHM : ignored %s", item.AccessionNo);
                    //		pConfig->Logging(logmsg);
                    //	}
                    //	continue;
                    //}

                    //int nResult = SelectOACAPACSH(item.AccessionNo);
                    //if (nResult < 0)
                    //{
                    //	//Database error
                    //	UpdateSendStatus(&item, DicomNet.GetISerials(), -1);
                    //	continue;
                    //}
                    //else if (nResult == 0)                          //q1
                    //{
                    //	InsertOACAPACSH(&item);                     //q3
                    //	InsertOACAPACSM(&item);
                    //}

                    //SetElements(pConfig, DicomData, item);

                    //DeleteAllFiles();
                    //if (MakeDcmFile(pConfig, DicomData, Iterator->Files) > 0)
                    //{
                    //	SendNotifyMsg(pWnd, GLOBAL_STATUS_SENDING);
                    //	UpdateSendStatus(&item, DicomNet.GetISerials(), 77);

                    //	if (SendDicom(DicomNet, &item) > 0)
                    //	{
                    //		CString SendedAccessionNo = DicomNet.GetCurrentAccession();

                    //		if (SendedAccessionNo.Compare(item.AccessionNo) == 0)
                    //		{
                    //			if (SelectOACRPACSH(SendedAccessionNo))     //q7
                    //				InsertOACRPACSH(&item);                 //q8
                    //			else
                    //				UpdateOACRPACSH(&item);                 //q9

                    //			// Call OCSif.dll request
                    //			OnExplictLinking(&item);

                    //			UpdateSendStatus(&item, DicomNet.GetISerials(), -1);
                    //		}
                    //		else
                    //		{
                    //			if (pConfig->GetValue(TYPE_LOGGING))
                    //			{
                    //				CString logmsg;
                    //				logmsg.Format("Mismatched accession number : %s, Updated nothing.", SendedAccessionNo);
                    //				pConfig->Logging(logmsg);
                    //			}
                    //			UpdateSendStatus(&item, DicomNet.GetISerials(), 777);
                    //		}
                    //	}
                    //	else
                    //	{
                    //		UpdateSendStatus(&item, DicomNet.GetISerials(), 6);
                    //	}
                    //	DicomNet.ClearCurrentSet();
                    //	Sleep(200);
                    //}
                    //else
                    //{
                    //	UpdateSendStatus(&item, DicomNet.GetISerials(), 5);
                    //}
                }


                //SendNotifyMsg(pWnd, GLOBAL_STATUS_WAIT);
            }
            //		SendNotifyMsg(pWnd, GLOBAL_STATUS_STOPED);

            //		DicomData.Clean();
            //		StudyItems.clear();
            //::CoUninitialize();

            //		return 0;
        }




        /// <summary>
        /// name         : UpdateKuhData
        /// desc         : Kuh 테이블 업데이트 처리
        /// author       : 심우종
        /// create date  : 2020-09-04 11:24
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool UpdateKuhData(DataRow row)
        {
            string strUidStudyInstance = m_SettingValue.szStudyInstanceUID + "." + row["accessId"].ToString() + ".2";
            KeyValueData param = new KeyValueData();
            param.Add("Data1", row["studyId"].ToString());
            param.Add("Data2", row["ptNo"].ToString());
            param.Add("Data3", row["studyDt"].ToString());
            param.Add("Data4", row["ptoNo"].ToString());
            param.Add("Data5", row["accessId"].ToString());
            param.Add("Data6", row["tcd"].ToString());
            param.Add("Data7", row["ordNm"].ToString());
            param.Add("Data8", row["reqDr"].ToString());
            param.Add("Data9", row["reqDrId"].ToString());
            param.Add("Data10", row["drCd"].ToString());
            param.Add("Data11", row["lastUpdtDt"].ToString());
            param.Add("Data12", row["ptNm"].ToString());
            param.Add("Data13", row["birth"].ToString());
            param.Add("Data14", row["sex"].ToString());
            param.Add("Data15", row["age"].ToString());
            param.Add("Data16", strUidStudyInstance);
            CallResultData result = this.callService.SelectSql("reqSetGateKuhData", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;
                if (dt != null && dt.Rows.Count > 0)
                {
                    string resultValue = dt.Rows[0]["resultValue"].ToString();
                    if (!string.IsNullOrEmpty(resultValue))
                    {
                        this.AddLog(resultValue);
                        return false;
                    }
                }

                return true;
            }
            else
            {
                //실패에 대한 처리
                if (!string.IsNullOrEmpty(result.errorMessage))
                {
                    AddErrorLog(result.errorMessage);
                }
                return false;
            }
        }



        /// <summary>
        /// name         : RetrieveStudyItems
        /// desc         : Dicom 전송이 필요한 StudyId조회
        /// author       : 심우종
        /// create date  : 2020-09-02 13:43
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private bool RetrieveStudyItems(ref DataTable studyTable, ref DataTable imageTable)
        {
            KeyValueData param = new KeyValueData();
            CallResultData result = this.callService.SelectSql("reqGetGateStudyData", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                studyTable = result.resultData;
                if (studyTable != null && studyTable.Rows.Count > 0)
                {
                    DataTable studyIdList = new DataTable();
                    studyIdList.Columns.Add("studyId", typeof(string));

                    this.AddLog(string.Format("============= 조회 ({0}건) ==============", studyTable.Rows.Count));
                    for (int i = 0; i < studyTable.Rows.Count; i++)
                    {
                        DataRow row = studyTable.Rows[i];
                        //LobCodeTable이 없어 일단은 하드코딩함.
                        row["tcd"] = "PA0008";
                        row["ordNm"] = "Gross";



                        string studyId = row["studyId"].ToString();
                        string ptNo = row["ptNo"].ToString();
                        string studyDt = row["studyDt"].ToString();
                        string ptoNo = row["ptoNo"].ToString();
                        string accessId = row["accessId"].ToString();
                        this.AddLog(string.Format("RetrieveStudyItems_StudyInfo : {0} / {1} / {2} / {3} / {4}", studyId, ptNo, studyDt, ptoNo, accessId));

                        DataRow studyIdRow = studyIdList.NewRow();
                        studyIdRow["studyId"] = row["studyId"].ToString();
                        studyIdList.Rows.Add(studyIdRow);
                    }


                    if (studyIdList != null && studyIdList.Rows.Count > 0)
                    {
                        KeyValueData param2 = new KeyValueData();
                        param2.Add("Data1", studyIdList.DataTableToStringForServer());


                        CallResultData resultImage = this.callService.SelectSql("reqGetGateImageData", param2);
                        if (resultImage.resultState == ResultState.OK)
                        {
                            imageTable = resultImage.resultData;
                        }

                    }
                }
            }
            else
            {
                if (!string.IsNullOrEmpty(result.errorMessage))
                {
                    AddErrorLog(result.errorMessage);
                }
                //실패에 대한 처리
            }

            return true;
        }


        /// <summary>
        /// name         : MainForm_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-09-14 09:04
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void MainForm_Load(object sender, EventArgs e)
        {
            if (Global.isDev == true)
            {
                //개발
                this.callService = new CallService("10.10.221.71", "8180");
                this.Text = this.Text + "  (개발)";
            }
            else
            {
                //운영
                this.callService = new CallService("kis.kuh.ac.kr"); //건대병원 DB연결
            }


            this.callService.ErrorMessageDisplay = false; //서버 에러 메시지 박스 표시 안하도록 함.
            ft.ShowErrorMessage = false;//파일다운로드시 에러메시지 표시 PASS

            globalLogText = this.memoLog;

            bgw.DoWork += new DoWorkEventHandler(bgw_DoWorkAsync);
            bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);
            bgw.WorkerSupportsCancellation = true;


            string logPath = appPath + "\\" + "Log";
            DirectoryInfo di = new DirectoryInfo(logPath);
            if (di.Exists == false)
            {
                di.Create();
            }

            InitGlobal(); //글로벌 변수 읽어오기

            SettingChage();
        }


        private void SettingChage()
        {
            //Search Interval
            this.txtInterval.Text = m_SettingValue.dwSearchInterval + " 초";

            // Modality
            this.txtModality.Text = m_SettingValue.szModality;

            // Transfer Syntax Value
            this.txtSyntaxValue.Text = m_SettingValue.szTransferSyntax;

            string[] lines = System.IO.File.ReadAllLines(".\\Setting\\TransferSyntaxList.TXT");
            if (lines != null && lines.Count() > 0)
            {
                for (int i = 0; i < lines.Count(); i++)
                {
                    string str = lines.ElementAt(i).ToString();
                    string[] strSpl = str.Split('|');
                    if (strSpl.Count() >= 2)
                    {
                        if (strSpl.ElementAt(1).ToString() == this.txtSyntaxValue.Text)
                        {
                            this.txtSyntaxName.Text = strSpl.ElementAt(0).ToString();
                        }
                    }
                }
            }

        }


        private void GetPrivateProfileString(string section, string key, string defaultValue, ref string globalobj, string filePath)
        {
            string value = Global.G_IniReadValue(section, key, filePath);
            if (string.IsNullOrEmpty(value))
            {
                globalobj = defaultValue;
            }
            else
            {
                globalobj = value;
            }

        }


        /// <summary>
        /// name         : AddLog
        /// desc         : 로그를 남긴다.
        /// author       : 심우종
        /// create date  : 2020-09-02 13:40
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void AddLog(string message)
        {
            if (m_SettingValue.bLogging == true)
            {
                StreamWriter oStreamWriter = new StreamWriter(String.Format(@"{0}\Log\{1}", appPath, DateTime.Now.ToShortDateString() + ".TXT"), true);
                oStreamWriter.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message));
                oStreamWriter.Close();

                MainForm.LogTextEvent(this.memoLog, message);

                if (!string.IsNullOrEmpty(MainForm.currentPtoNo))
                {
                    StreamWriter oStreamWriter2 = new StreamWriter(String.Format(@"{0}\Log\{1}", appPath, MainForm.currentPtoNo + ".TXT"), true);
                    oStreamWriter2.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message));
                    oStreamWriter2.Close();
                }
            }
        }

        private static Sedas.Control.HMemoEdit globalLogText;


        public static void AddErrorLog(string message)
        {
            if (m_SettingValue.bLogging == true)
            {
                StreamWriter oStreamWriter = new StreamWriter(String.Format(@"{0}\Log\{1}", Application.StartupPath, DateTime.Now.ToShortDateString() + ".TXT"), true);
                oStreamWriter.WriteLine(String.Format("[=====ERROR=====] {0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message));
                oStreamWriter.Close();

                if (globalLogText != null)
                {
                    LogTextEvent(globalLogText, message);
                }

                if (!string.IsNullOrEmpty(MainForm.currentPtoNo))
                {

                    StreamWriter oStreamWriter2 = new StreamWriter(String.Format(@"{0}\Log\{1}", Application.StartupPath, MainForm.currentPtoNo + ".TXT"), true);
                    oStreamWriter2.WriteLine(String.Format("[=====ERROR=====] {0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message));
                    oStreamWriter2.Close();
                }

                MainForm.isErrorExist = true;
            }
        }

        public static void LogTextEvent(Sedas.Control.HMemoEdit TextEventLog, string EventText)
        {
            if (TextEventLog.InvokeRequired)
            {
                TextEventLog.BeginInvoke(new Action(delegate
                {
                    LogTextEvent(TextEventLog, EventText);
                }));
                return;
            }

            string nDateTime = DateTime.Now.ToString("hh:mm:ss tt") + " - ";

            TextEventLog.SelectionStart = TextEventLog.Text.Length;

            // newline if first line, append if else.
            if (TextEventLog.Lines.Length == 0)
            {
                TextEventLog.Text = TextEventLog.Text + (nDateTime + EventText);
                //TextEventLog.ScrollToCaret();
                TextEventLog.Text = TextEventLog.Text + (System.Environment.NewLine);
            }
            else
            {
                TextEventLog.Text = TextEventLog.Text + (nDateTime + EventText + System.Environment.NewLine);
                //
            }


            //string line = (string)TextEventLog.EditValue;
            //if (line.Length == TextEventLog.SelectionStart)
            //    return;
            //int index = line.IndexOf(newPage, TextEventLog.SelectionStart + newPage.Length);
            //if (index == -1)
            //    index = line.Length;
            //TextEventLog.SelectionStart = index;
            //TextEventLog.ScrollToCaret();



            TextEventLog.SelectionStart = TextEventLog.Text.Length;
            TextEventLog.ScrollToCaret();
            //TextEventLog.MaskBox.MaskBoxScrollToCaret();

            textCount++;

            if (textCount > 5000)
            {
                textCount = 0;
                TextEventLog.Text = "";
            }
        }
        static int textCount = 0;

        /// <summary>
        /// name         : InitGlobal
        /// desc         : 글로벌 변수 설정
        /// author       : 심우종
        /// create date  : 2020-09-02 10:28
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitGlobal()
        {
            string strPath = System.Environment.CurrentDirectory + "\\setting\\Setting.ini";
            Global.m_strPath = strPath;

            string strTemp = "";


            // WorkList Setting Load
            GetPrivateProfileString("WorkList", "IP", "0.0.0.0", ref m_SettingValue.szWorkListIP, strPath);
            GetPrivateProfileString("WorkList", "Port", "104", ref strTemp, strPath);
            if (strTemp.ToIntOrNull() != null)
            {
                m_SettingValue.nWorkListPort = strTemp.ToInt();
            }

            GetPrivateProfileString("WorkList", "ServerAE", "", ref m_SettingValue.szWorkListServerAE, strPath);
            GetPrivateProfileString("WorkList", "ClientAE", "", ref m_SettingValue.szWorkListClientAE, strPath);

            // Pacs Setting Load
            GetPrivateProfileString("PACS", "IP", "0.0.0.0", ref m_SettingValue.szPacsIP, strPath);
            GetPrivateProfileString("PACS", "Port", "107", ref strTemp, strPath);
            if (strTemp.ToIntOrNull() != null)
            {
                m_SettingValue.nPacsPort = strTemp.ToInt();
            }

            GetPrivateProfileString("PACS", "ServerAE", "", ref m_SettingValue.szPacsServerAE, strPath);
            GetPrivateProfileString("PACS", "ClientAE", "", ref m_SettingValue.szPacsClientAE, strPath);

            // Pacs Seconde Setting Load
            GetPrivateProfileString("PACS_SECONDE", "IP", "0.0.0.0", ref m_SettingValue.szPacsIP_2, strPath);
            GetPrivateProfileString("PACS_SECONDE", "Port", "107", ref strTemp, strPath);
            if (strTemp.ToIntOrNull() != null)
            {
                m_SettingValue.nPacsPort_2 = strTemp.ToInt();
            }

            GetPrivateProfileString("PACS_SECONDE", "ServerAE", "", ref m_SettingValue.szPacsServerAE_2, strPath);
            GetPrivateProfileString("PACS_SECONDE", "ClientAE", "", ref m_SettingValue.szPacsClientAE_2, strPath);

            // ETC Setting Load
            GetPrivateProfileString("ETC", "Modality", "", ref m_SettingValue.szModality, strPath);
            GetPrivateProfileString("ETC", "Transfer_Syntax", "", ref m_SettingValue.szTransferSyntax, strPath);
            GetPrivateProfileString("ETC", "Implementation_Class_UID", "", ref m_SettingValue.szImplementationClassUID, strPath);
            GetPrivateProfileString("ETC", "Study_Instance_UID", "", ref m_SettingValue.szStudyInstanceUID, strPath);

            GetPrivateProfileString("ETC", "Copy_Local_Name", "", ref m_SettingValue.szCopyLName, strPath);
            GetPrivateProfileString("ETC", "Copy_ID", "", ref m_SettingValue.szCopyID, strPath);
            GetPrivateProfileString("ETC", "Copy_Password", "", ref m_SettingValue.szCopyPassword, strPath);
            GetPrivateProfileString("ETC", "Copy_Address", "", ref m_SettingValue.szCopyAddress, strPath);

            GetPrivateProfileString("ETC", "Use_Seconde_Pacs", "0", ref strTemp, strPath);
            if (strTemp.ToIntOrNull() != null)
            {
                m_SettingValue.bUseSecondePacs = strTemp.ToInt();
            }

            //에러발생시 Email전송
            GetPrivateProfileString("ETC", "SendEmailByError", "Y", ref strTemp, strPath);
            if (strTemp == "Y")
            {
                m_SettingValue.bSendEmailByError = true;
            }
            else
            {
                m_SettingValue.bSendEmailByError = false;
            }

            GetPrivateProfileString("ETC", "EmailAddressByError", "", ref strTemp, strPath);
            if (!string.IsNullOrEmpty(strTemp))
            {
                string[] splStr = strTemp.Split('|');
                if (splStr != null && splStr.Count() > 0)
                {
                    for (int i = 0; i < splStr.Count(); i++)
                    {
                        string email = splStr.ElementAt(i);
                        m_SettingValue.emailAddressList.Add(email);
                    }
                }
            }

            // Database Setting Load
            GetPrivateProfileString("Database", "DSN", "DGS", ref m_SettingValue.szDSN, strPath);
            GetPrivateProfileString("Database", "ID", "", ref m_SettingValue.szDBID, strPath);
            GetPrivateProfileString("Database", "Password", "", ref m_SettingValue.szDBPassword, strPath);

            // OCS Database Setting Load
            GetPrivateProfileString("OCS_Database", "DSN", "OCS", ref m_SettingValue.szOCS_DSN, strPath);
            GetPrivateProfileString("OCS_Database", "ID", "", ref m_SettingValue.szOCS_DBID, strPath);
            GetPrivateProfileString("OCS_Database", "Password", "", ref m_SettingValue.szOCS_DBPassword, strPath);

            // FTP Server Setting Load
            GetPrivateProfileString("FTP", "IP", "", ref m_SettingValue.szFTPServerIP, strPath);
            GetPrivateProfileString("FTP", "User", "", ref m_SettingValue.szFTPUser, strPath);
            GetPrivateProfileString("FTP", "Password", "", ref m_SettingValue.szFTPPassword, strPath);
            GetPrivateProfileString("FTP", "DstPath", "", ref m_SettingValue.szFtpDstDir, strPath);

            // Program Setting Load
            GetPrivateProfileString("Program", "Image_Path", "C:\\", ref m_SettingValue.szImagePath, strPath);
            GetPrivateProfileString("Program", "Search_Interval", "5", ref strTemp, strPath);
            if (strTemp.ToIntOrNull() != null)
            {
                m_SettingValue.dwSearchInterval = strTemp.ToInt();
            }

            //## added by kswoo
            GetPrivateProfileString("Program", "Logging", "0", ref strTemp, strPath);
            if (strTemp.ToIntOrNull() != null)
            {
                if (strTemp.ToInt() == 0)
                {
                    m_SettingValue.bLogging = false;
                }
                else
                {
                    m_SettingValue.bLogging = true;
                }
            }
            if (m_SettingValue.bLogging)
            {
                // create log file
                //CTime time = CTime::GetCurrentTime();
                //m_logfile.Format(".\\Log\\%d-%d-%d-%02d-%02d-%02d.log", time.GetYear(), time.GetMonth(), time.GetDay(),
                //time.GetHour(), time.GetMinute(), time.GetSecond());
                //std::ofstream of(m_logfile, std::ios::out);
            }


            
        }

        private void hSedasSImpleButtonBlue2_Click(object sender, EventArgs e)
        {


            //OpenFileDialog ofd = new OpenFileDialog();
            //ofd.Multiselect = true;
            //ofd.Filter = "jpg(*.*)|*.jpg*";
            //DialogResult drs = ofd.ShowDialog();
            //string strPath = "";
            //if (drs == DialogResult.OK)
            //{
            //	for (int i = 0; i < ofd.FileNames.Length; i++)
            //	{
            //		strPath = ofd.FileNames[i].ToString();
            //	}
            //}
            //if (!string.IsNullOrEmpty(strPath))
            //{
            //}

            //-----------------------------------------------------------


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}