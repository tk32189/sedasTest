using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Management;
using DevExpress.XtraGauges.Core.Drawing;

namespace RemoteResourceCheck
{
    public partial class wmiGaugeUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        ManagementScope mScope;
        System.Threading.Thread thread;
        WmiInfoDTO wmiInfoDTO = new WmiInfoDTO(); //wmi결과를 담고있는 DTO

        string ip;
        string id;
        string pw;
        string title = "NoName";

        public string Title
        {
            get
            {
                return title;
            }

            set
            {
                title = value;
                this.lblTitle.Text = title;
            }
        }

        public wmiGaugeUserControl(string ip, string id, string pw)
        {

            this.ip = ip;
            this.id = id;
            this.pw = pw;

            InitializeComponent();

        }

        Color greenColor = Color.FromArgb(4, 178, 121);
        Color redColor = Color.FromArgb(249, 53, 67);
        Color blueColor = Color.FromArgb(72, 190, 251);
        Color yellowColor = Color.FromArgb(255, 171, 24);

        //Color cpuColor = Color.FromArgb(4, 178, 121);
        //Color ramColor = Color.Blue;

        /// <summary>
        /// name         : wmiGaugeUserControl_Load
        /// desc         : 화면로드시
        /// author       : 심우종
        /// create date  : 2020-09-15 13:18
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void wmiGaugeUserControl_Load(object sender, EventArgs e)
        {
            this.InitControl();
            this.Start();
        }


        /// <summary>
        /// name         : InitControl
        /// desc         : 컨트롤 초기화
        /// author       : 심우종
        /// create date  : 2020-09-15 15:55
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitControl()
        {
            this.lblIp.Text = ip;
            this.arcScaleRangeBarComponent1.Appearance.ContentBrush = new SolidBrushObject(redColor);
            this.lblCompCpu.AppearanceText.TextBrush = new SolidBrushObject(redColor);
            this.arcScaleRangeBarComponent2.Appearance.ContentBrush = new SolidBrushObject(blueColor);
            this.lblCompRam.AppearanceText.TextBrush = new SolidBrushObject(blueColor);
        }



        private void Start()
        {
            try
            {

                ConnectionOptions cConnectOption = new ConnectionOptions();
                //10.10.221.71
                string ip = this.ip; //"10.10.221.71";

                if (!string.IsNullOrEmpty(this.id) && !string.IsNullOrEmpty(this.pw))
                {
                    //cConnectOption.Username = "mj2kuh";
                    //cConnectOption.Password = "sJ0802$!";
                    cConnectOption.Username = this.id;
                    cConnectOption.Password = this.pw;
                }

                mScope = new ManagementScope("\\\\" + ip + "\\root\\CIMV2", cConnectOption);
                mScope.Connect();
                if (mScope.IsConnected)
                {

                    System.Threading.ThreadStart threadStart = new System.Threading.ThreadStart(recvSSHData);
                    thread = new System.Threading.Thread(threadStart);

                    thread.IsBackground = true;
                    thread.Start();
                }
                else
                {
                    //label5.Text = "Status : disConnected";
                }
            }
            catch (Exception ex)
            {
                //label5.Text = "Status : Error";
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void recvSSHData()
        {
            while (true)
            {
                try
                {
                    getCpuTime2();
                    getOperatingInfo();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }

                System.Threading.Thread.Sleep(1000);
            }
        }

        decimal pTimeNew;
        decimal tStampNew;
        decimal pTimeOld;
        decimal tStampOld;


        private void getCpuTime2()
        {
            try
            {
                //decimal cpuTime = 0;

                ObjectQuery query1 = new ObjectQuery("SELECT * FROM Win32_Processor");
                ManagementObjectSearcher searcher1 = new ManagementObjectSearcher(mScope, query1);


                //CPU 사용량

                int Cpu_TotalUsed = 0;
                string Cpu_Used = "0";
                //int[] Cpu_idx = new int[10] {1,2,3,4,5,6,7,8,9,10 };


                foreach (ManagementObject queryObj in searcher1.Get())
                {
                    try
                    {
                        Cpu_Used = queryObj["LoadPercentage"].ToString();
                    }
                    catch
                    {
                    }


                }


                float cpuPercnetF = float.Parse(Cpu_Used);
                //wmiInfoDTO.CpuTime = cpuTime;
                //wmiInfoDTO.CpuNotUseTime = (100 - cpuTime);
                arcScaleComponent1.Value = cpuPercnetF;
                lblCompCpu.Text = "CPU : " + Math.Round(cpuPercnetF, 2).ToString() + "%";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        private void getCpuTime()
        {
            try
            {
                decimal cpuTime = 0;

                ManagementPath mPath = new ManagementPath();
                mPath.RelativePath = "Win32_PerfRawData_PerfOS_Processor.Name='_Total'";

                ManagementObject mObject = new ManagementObject(mScope, mPath, null);
                mObject.Get();

                if (pTimeOld == 0 && tStampOld == 0)
                {
                    pTimeOld = Convert.ToDecimal(mObject.Properties["PercentProcessorTime"].Value);
                    tStampOld = Convert.ToDecimal(mObject.Properties["TimeStamp_Sys100NS"].Value);

                    pTimeNew = Convert.ToDecimal(mObject.Properties["PercentProcessorTime"].Value);
                    tStampNew = Convert.ToDecimal(mObject.Properties["TimeStamp_Sys100NS"].Value);

                    cpuTime = (1 - (pTimeNew / tStampNew)) * 100m;
                }
                else
                {
                    pTimeOld = pTimeNew;
                    tStampOld = tStampNew;

                    pTimeNew = Convert.ToDecimal(mObject.Properties["PercentProcessorTime"].Value);
                    tStampNew = Convert.ToDecimal(mObject.Properties["TimeStamp_Sys100NS"].Value);

                    cpuTime = (1 - ((pTimeNew - pTimeOld) / (tStampNew - tStampOld))) * 100m;
                }




                wmiInfoDTO.CpuTime = cpuTime;
                wmiInfoDTO.CpuNotUseTime = (100 - cpuTime);
                //label1.Text = "CPU 미사용 : " + (100 - cpuTime).ToString();
                //label2.Text = "CPU 사용중 : " +  cpuTime.ToString();

                //txtThreadSafeDisplay(label1, "CPU 미사용: " + (100 - cpuTime).ToString());
                //txtThreadSafeDisplay(label2, "CPU 사용중 : " + cpuTime.ToString());


                //decimal test = Convert.ToDecimal(mObject.Properties["PercentIdleTime"].Value);

                arcScaleComponent1.Value = (float)cpuTime;
                lblCompCpu.Text = "CPU : " + Math.Round(cpuTime, 2).ToString() + "%";





                //double CurrentCPU = 0;
                //CurrentCPU = Convert.ToDouble(ulong.Parse(mObject.Properties["PercentProcessorTime"].ToString())); //%로 계산



                //float value = 0;

                //ManagementObjectSearcher searcher = new ManagementObjectSearcher("select * from Win32_PerfFormattedData_PerfOS_Processor");
                //foreach (ManagementObject obj in searcher.Get())
                //{
                //    var usage = obj["PercentProcessorTime"];
                //    var name = obj["Name"];

                //    if (name.ToString() == "_Total")
                //    {
                //        value = float.Parse(usage.ToString()); 
                //    }
                //}


                //arcScaleComponent1.Value = value;
                //lblCompCpu.Text = "CPU : " + Math.Round(value, 2).ToString() + "%";

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }


        private void getOperatingInfo()
        {
            try
            {
                ObjectQuery mQuery = new ObjectQuery();
                mQuery.QueryString = "SELECT * FROM Win32_OperatingSystem";

                ManagementObjectSearcher mObjSearcher = new ManagementObjectSearcher(mScope, mQuery);

                foreach (ManagementObject mObject in mObjSearcher.Get())
                {
                    //if (chart2.IsHandleCreated && listBox1.IsHandleCreated)
                    //{

                    //}
                    this.Invoke((MethodInvoker)delegate { UpdateOSInfo(mObject); });
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }


        private void UpdateOSInfo(ManagementObject mObject)
        {
            //chart2.Series["mem"].Points.Clear();

            //chart2.Series["mem"].Points.AddXY("여유", ((Convert.ToDecimal(mObject["FreePhysicalMemory"].ToString()) / Convert.ToDecimal(mObject["TotalVisibleMemorySize"].ToString())) * 100));
            //chart2.Series["mem"].Points.AddXY("사용중", ((Convert.ToDecimal(mObject["TotalVisibleMemorySize"].ToString()) - Convert.ToDecimal(mObject["FreePhysicalMemory"].ToString())) / Convert.ToDecimal(mObject["TotalVisibleMemorySize"].ToString())) * 100);

            decimal memNotUse = ((Convert.ToDecimal(mObject["FreePhysicalMemory"].ToString()) / Convert.ToDecimal(mObject["TotalVisibleMemorySize"].ToString())) * 100);
            decimal memUse = (((Convert.ToDecimal(mObject["TotalVisibleMemorySize"].ToString()) - Convert.ToDecimal(mObject["FreePhysicalMemory"].ToString())) / Convert.ToDecimal(mObject["TotalVisibleMemorySize"].ToString())) * 100);

            wmiInfoDTO.MemUse = memUse;
            wmiInfoDTO.MemNotUse = memNotUse;
            //hLabelControl8.Text = "여유 : " + memUse.ToString();
            //hLabelControl9.Text = "사용중 : " + memNotUse.ToString();

            wmiInfoDTO.TotalVisibleMemorySize = (Convert.ToInt32(mObject["TotalVisibleMemorySize"].ToString()) / 1024).ToString();
            wmiInfoDTO.FreePhysicalMemory = (Convert.ToInt32(mObject["FreePhysicalMemory"].ToString()) / 1024).ToString();
            wmiInfoDTO.TotalVisibleMemorySize = ((Convert.ToInt32(mObject["TotalVisibleMemorySize"].ToString()) - Convert.ToInt32(mObject["FreePhysicalMemory"].ToString())) / 1024).ToString();
            //hLabelControl1.Text = "전체 메모리 : " + (Convert.ToInt32(mObject["TotalVisibleMemorySize"].ToString()) / 1024).ToString();
            //hLabelControl2.Text = "여유 메모리 : " + (Convert.ToInt32(mObject["FreePhysicalMemory"].ToString()) / 1024).ToString();
            //hLabelControl3.Text = "사용 메모리 : " + ((Convert.ToInt32(mObject["TotalVisibleMemorySize"].ToString()) - Convert.ToInt32(mObject["FreePhysicalMemory"].ToString())) / 1024).ToString();

            wmiInfoDTO.Os = mObject["Caption"].ToString();
            wmiInfoDTO.OsVersion = mObject["Version"].ToString();
            wmiInfoDTO.BuildNumber = mObject["BuildNumber"].ToString();
            wmiInfoDTO.ServerName = mObject["CSName"].ToString();
            //hLabelControl4.Text = "OS : " + mObject["Caption"].ToString();
            //hLabelControl5.Text = "OS Version : " + mObject["Version"].ToString();
            //hLabelControl6.Text = "BuildNumber : " + mObject["BuildNumber"].ToString();
            //hLabelControl7.Text = "Server-Name : " + mObject["CSName"].ToString();

            arcScaleComponent2.Value = (float)memUse;
            this.lblCompRam.Text = "RAM : " + Math.Round(memUse, 2) + "%";




            //if (listBox1.Items.Count == 0)
            //{
            //	listBox1.Items.Add("OS : " + mObject["Caption"].ToString());
            //	listBox1.Items.Add("OS Version : " + mObject["Version"].ToString());
            //	listBox1.Items.Add("BuildNumber : " + mObject["BuildNumber"].ToString());
            //	listBox1.Items.Add("Server-Name : " + mObject["CSName"].ToString());
            //}
        }



        /// <summary>
        /// name         : btnDetail_Click
        /// desc         : 상세버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-09-15 16:13
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnDetail_Click(object sender, EventArgs e)
        {
            WmiDetailPopup detailPopup = new WmiDetailPopup(this.Title, this.ip, this.id, this.pw);
            detailPopup.InfoDTO = this.wmiInfoDTO;
            detailPopup.ShowDialog();
        }
    }
}
