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
using Sedas.Core;
using Sedas.DB;
using System.IO;

namespace SRU
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm
    {
        CallService callService = new CallService("10.10.221.71", "8180");
        CoreLibrary core = new CoreLibrary();

        private String appPath = Application.StartupPath;
        public MainForm()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Minimized;
        }

        Timer Time_Result;
        Timer Seach_Sendstatus8;

        /// <summary>
        /// name         : MainForm_Load
        /// desc         : 화면로드시
        /// author       : 심우종
        /// create date  : 2020-08-31 15:24
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
                //this.callService = new CallService("kis.kuh.ac.kr"); //건대병원 DB연결
                this.callService = new CallService("10.20.200.1"); //건대병원 DB연결
                //this.callService = new CallService("10.20.251.101", "8001"); //건대병원 DB연결
            }


            this.progressBarControl1.Properties.Maximum = 500;
            this.progressBarControl1.EditValue = 0;

            this.Seach_Sendstatus8 = new Timer();
            this.Seach_Sendstatus8.Enabled = true;
            this.Seach_Sendstatus8.Interval = 4000;
            this.Seach_Sendstatus8.Tick += Seach_Sendstatus8_Tick;

            this.Time_Result = new Timer();
            this.Time_Result.Enabled = true;
            this.Time_Result.Interval = 5000;
            this.Time_Result.Tick += Time_Result_Tick;

            string logPath = appPath + "\\" + "Log";
            DirectoryInfo di = new DirectoryInfo(logPath);
            if (di.Exists == false)
            {
                di.Create();
            }

        }



        private void MessageClear()
        {
            this.memoMessage.Text = "";
        }

        private void MessageAdd(string message)
        {
            if (string.IsNullOrEmpty(this.memoMessage.Text))
            {
                this.memoMessage.Text = this.memoMessage.Text + message;
            }
            else
            {
                this.memoMessage.Text = this.memoMessage.Text + Environment.NewLine + message;
            }

             

            StreamWriter oStreamWriter = new StreamWriter(String.Format(@"{0}\Log\{1}", appPath, DateTime.Now.ToShortDateString() + ".TXT"), true);
            oStreamWriter.WriteLine(String.Format("{0} : {1}", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"), message));
            oStreamWriter.Close();
        }


        List<string> cancelPtoNoList = new List<string>(); //점검하지 않을 병리번호리스트


        private void Time_Result_Tick(object sender, EventArgs e)
        {
            if (this.progressBarControl1.Position > this.progressBarControl1.Properties.Maximum - 5)
            {
                this.progressBarControl1.Properties.Maximum = this.progressBarControl1.Properties.Maximum + 300;
            }
            try
            {
                if (DateTime.Now.Hour > 0 && DateTime.Now.Hour < 6)
                //if (true)
                {
                    DataTable searchData = PathloNo_DB_Seach();

                    if (searchData != null && searchData.Rows.Count > 0)
                    {
                        for (int i = 0; i < searchData.Rows.Count; i++)
                        {
                            DataRow row = searchData.Rows[i];

                            txtMessage1.Text = row["ptoNo"].ToString() + " 을 처리하고있습니다.";
                            string resultValue = this.PathloNo_DB_Update(row["ptoNo"].ToString(), "N");

                            progressBarControl1.Position = this.progressBarControl1.Position + 1;
                            if (!string.IsNullOrEmpty(resultValue))
                            {
                                this.MessageAdd(resultValue);
                                cancelPtoNoList.Add(row["ptoNo"].ToString());
                            }
                            else
                            {
                                this.MessageAdd(row["ptoNo"].ToString() + " 을 처리완료.");
                                txtMessage2.Text = progressBarControl1.Position.ToString() + "건 처리";
                            }

                            if (progressBarControl1.Position > progressBarControl1.Properties.Maximum - 5)
                            {
                                progressBarControl1.Properties.Maximum = progressBarControl1.Properties.Maximum + 300;
                            }
                            if (progressBarControl1.Properties.Maximum > 5000)
                            {
                                progressBarControl1.Properties.Maximum = 500;
                                progressBarControl1.Position = 0;
                            }
                        }
                    }
                    else
                    {
                        this.MessageAdd("오늘작업량 없으므로 프로그램 멈춥니다.");
                        Time_Result.Enabled = false;
                        return;
                    }

                }
            }
            catch (Exception ex)
            {
                Time_Result.Enabled = false;
                MessageAdd(ex.Message);
                MessageBox.Show(ex.Message);
            }
        }


        private void Seach_Sendstatus8_Tick(object sender, EventArgs e)
        {
            Seach_Sendstatus8.Enabled = false;
            try
            {
                if (DateTime.Now.Hour > 7 && DateTime.Now.Hour < 9)
                {
                    if (cancelPtoNoList != null && cancelPtoNoList.Count > 0)
                    {
                        this.cancelPtoNoList.Clear(); //병리번호 점검 취소 리스트 clear
                        this.MessageClear();
                        //ListViewItem lv = new ListViewItem("");
                        this.MessageAdd("오늘 새벽작업한 내용을 초기화합니다.");
                        //PathloNo_DB_RESETUpdate(); //왜 하는거지????

                    }
                    if (Time_Result.Enabled == false)
                    {
                        this.MessageClear();
                        Time_Result.Enabled = true;
                        //PathloNo_DB_RESETUpdate();  //왜 하는거지????
                        this.MessageAdd("오늘 새벽작업을 예약합니다.");
                    }
                }
                if (this.progressBarControl1.Position > progressBarControl1.Properties.Maximum - 5)
                {
                    progressBarControl1.Properties.Maximum = progressBarControl1.Properties.Maximum + 300;
                }
                try
                {
                    if (DateTime.Now.Hour > 7 && DateTime.Now.Hour < 22)
                    {
                        DataTable searchData = PathloNo_DB_Sendstatus8Seach();

                        if (searchData != null && searchData.Rows.Count > 0)
                        {
                            for (int i = 0; i < searchData.Rows.Count; i++)
                            {
                                DataRow row = searchData.Rows[i];

                                txtMessage1.Text = row["ptoNo"].ToString() + " 을 처리하고있습니다.";
                                string resultValue = this.PathloNo_DB_Update(row["ptoNo"].ToString(), "Y");

                                progressBarControl1.Position = this.progressBarControl1.Position + 1;
                                if (!string.IsNullOrEmpty(resultValue))
                                {
                                    this.MessageAdd(resultValue);
                                    cancelPtoNoList.Add(row["ptoNo"].ToString());
                                }
                                else
                                {
                                    this.MessageAdd(row["ptoNo"].ToString() + " 을 처리완료.");
                                    txtMessage2.Text = progressBarControl1.Position.ToString() + "건 처리";
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    Seach_Sendstatus8.Enabled = false;
                    MessageAdd(ex.Message);
                    MessageBox.Show(ex.Message);
                }
            }
            finally
            {
                Seach_Sendstatus8.Enabled = true;
            }
        }


        /// <summary>
        /// name         : PathloNo_DB_Sendstatus8Seach
        /// desc         : SendState = 8 데이터 조회
        /// author       : 심우종
        /// create date  : 2020-09-01 11:09
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private DataTable PathloNo_DB_Sendstatus8Seach()
        {
            string sendState = "8";
            KeyValueData param = new KeyValueData();
            param.Add("Data1", sendState);
            CallResultData result = this.callService.SelectSql("reqGetSruStudyData", param);
            if (result.resultState == ResultState.OK)
            {
                //MessageBox.Show("쿼리실행확인");

                //데이터 조회 성공
                DataTable dt = result.resultData;
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataTable resultDt = new DataTable();
                    resultDt.Columns.Add("studyId");
                    resultDt.Columns.Add("ptoNo");

                    foreach (DataRow row in dt.Rows)
                    {
                        if (this.cancelPtoNoList != null && this.cancelPtoNoList.Count() > 0)
                        {
                            if (this.cancelPtoNoList.Contains(row["ptoNo"].ToString()) == true)
                            {
                                //cancelList에 포함되어 있으면 PASS
                                continue;
                            }
                        }

                        this.core.TableCopy(row, ref resultDt);

                        if (resultDt.Rows.Count >= 20)
                        {
                            break;
                        }
                    }

                    return resultDt;
                }
            }
            else
            {
                //실패에 대한 처리
            }
            return null;
        }

        private DataTable PathloNo_DB_Seach()
        {
            DateTime nowDt = DateTime.Now;

            KeyValueData param = new KeyValueData();
            param.Add("Data1", nowDt.AddDays(-60).ToString("yyyyMMdd"));
            param.Add("Data2", nowDt.ToString("yyyyMMdd"));
            CallResultData result = this.callService.SelectSql("reqGetSruStudyDataForNight", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;
                if (dt != null && dt.Rows.Count > 0)
                {
                    DataTable resultDt = new DataTable();
                    resultDt.Columns.Add("studyId");
                    resultDt.Columns.Add("ptoNo");

                    foreach (DataRow row in dt.Rows)
                    {
                        if (this.cancelPtoNoList != null && this.cancelPtoNoList.Count() > 0)
                        {
                            if (this.cancelPtoNoList.Contains(row["ptoNo"].ToString()) == true)
                            {
                                //cancelList에 포함되어 있으면 PASS
                                continue;
                            }
                        }

                        this.core.TableCopy(row, ref resultDt);

                        if (resultDt.Rows.Count >= 20)
                        {
                            break;
                        }
                    }

                    return resultDt;
                }
            }
            else
            {
                //실패에 대한 처리
            }
            return null;
        }


        /// <summary>
        /// name         : PathloNo_DB_Update
        /// desc         : 검사결과를 업데이트 한다.
        /// author       : 심우종
        /// create date  : 2020-09-01 11:10
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private string PathloNo_DB_Update(string ptoNo, string sendStatChange)
        {
            KeyValueData param = new KeyValueData();
            param.Add("Data1", ptoNo);
            param.Add("Data2", sendStatChange);
            CallResultData result = this.callService.SelectSql("reqSetSruStudyData", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;

                if (dt != null && dt.Rows.Count > 0)
                {
                    string resultValue = dt.Rows[0]["resultValue"].ToString();
                    return resultValue;
                }
            }
            else
            {
                //실패에 대한 처리
                return "[서버에러] 업데이트에 실패하였습니다. : ptoNo" + ptoNo;
            }
            return null;
        }

        private void hSedasSImpleButtonBlue1_Click(object sender, EventArgs e)
        {
        
        }


        /// <summary>
        /// name         : btnClose_Click
        /// desc         : 종료
        /// author       : 심우종
        /// create date  : 2020-09-01 17:00
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void m_notify_DoubleClick(object sender, EventArgs e)
        {
            //Notify Icon을 더블클릭했을시 일어나는 이벤트.
            //this.WindowState = FormWindowState.Normal;
            
            this.ShowIcon = true;
            m_notify.Visible = false; //트레이 아이콘을 숨긴다.
            this.ShowInTaskbar = true;
            this.Visible = true;
            this.WindowState = FormWindowState.Normal;
            Invalidate();
            
        }

        private void 작업시작ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Time_Result.Enabled = true;
            Seach_Sendstatus8.Enabled = true;
            MessageBox.Show("작업이 시작되었습니다.");
        }

        private void 작업정지ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Time_Result.Enabled = false;
            Seach_Sendstatus8.Enabled = false;
            MessageBox.Show("작업이 종료되었습니다.");
        }

        private void 프로그램종료ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false; //창을 보이지 않게 한다.
                this.ShowIcon = false; //작업표시줄에서 제거.
                m_notify.Visible = true; //트레이 아이콘을 표시한다.
            }
            else if (this.WindowState == FormWindowState.Normal)
            {
                this.Visible = true; //창을 보이지 않게 한다.
                this.ShowIcon = true; //작업표시줄에서 제거.
                m_notify.Visible = false; //트레이 아이콘을 표시한다.
                this.ShowInTaskbar = true;
            }
        }
    }
}