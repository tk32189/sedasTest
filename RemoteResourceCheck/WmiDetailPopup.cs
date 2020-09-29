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
using System.Management;

namespace RemoteResourceCheck
{
    public partial class WmiDetailPopup : DevExpress.XtraEditors.XtraForm
    {

        string ip;
        string id;
        string pw;
        string title;


        ulong Totalmemory = 0;
        double maxMem = 0;
        double memfree = 0;
        double memUsed = 0;
        double physicalDiskTotal = 0;
        double physicalDiskfree = 0;
        int Cpu_ExceedCnt = 0; // 임계치가 넘을때마다 전역변수에 저장함.
        int Cpu_Totalcycle = 0; // CPU가 전체 몇회를 돌았는지 확인.

        public WmiDetailPopup(string title, string ip, string id, string pw)
        {
            this.title = title;
            this.ip = ip;
            this.id = id;
            this.pw = pw;
            InitializeComponent();
        }


        WmiInfoDTO infoDTO;

        public WmiInfoDTO InfoDTO
        {
            get
            {
                return infoDTO;
            }

            set
            {
                infoDTO = value;
            }
        }

        /// <summary>
        /// name         : WmiDetailPopup_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-09-15 16:11
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void WmiDetailPopup_Load(object sender, EventArgs e)
        {
            InitControl();
            try
            {
                ConnectionOptions cConnectOption = new ConnectionOptions();
                string ip = this.ip; //"10.10.221.71";

                if (!string.IsNullOrEmpty(this.id) && !string.IsNullOrEmpty(this.pw))
                {
                    //cConnectOption.Username = "mj2kuh";
                    //cConnectOption.Password = "sJ0802$!";
                    cConnectOption.Username = this.id;
                    cConnectOption.Password = this.pw;
                }

                ManagementScope scope = new ManagementScope("\\\\" + ip + "\\root\\CIMV2", cConnectOption);
                //ManagementScope scope = new ManagementScope("\\\\192.168.123.220\\root\\CIMV2", connection);
                scope.Connect();



                ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Processor");
                ObjectQuery query1 = new ObjectQuery("SELECT * FROM Win32_Processor");
                ObjectQuery query2 = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ObjectQuery query3 = new ObjectQuery("SELECT * FROM Win32_LogicalDisk where caption='C:'");
                ObjectQuery query4 = new ObjectQuery("SELECT * FROM Win32_LogicalDisk where caption='D:'");
                ObjectQuery query5 = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ObjectQuery query6 = new ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");

                ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
                ManagementObjectSearcher searcher1 = new ManagementObjectSearcher(scope, query1);
                ManagementObjectSearcher searcher2 = new ManagementObjectSearcher(scope, query2);
                ManagementObjectSearcher searcher3 = new ManagementObjectSearcher(scope, query3);
                ManagementObjectSearcher searcher4 = new ManagementObjectSearcher(scope, query4);
                ManagementObjectSearcher searcher5 = new ManagementObjectSearcher(scope, query5);
                ManagementObjectSearcher searcher6 = new ManagementObjectSearcher(scope, query6);

                string Cpu_Info = "";
                string Cpu_Used = "";
                string Cpu_name = "";
                string WindowOS = "";
                ulong FreePhysicalMemory = 0;

                foreach (ManagementObject queryObj in searcher5.Get())
                {
                    WindowOS = queryObj["Caption"].ToString();
                }
                this.txtOs.Text = WindowOS;

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Cpu_Info = queryObj["Caption"].ToString();
                }
                

                //Cpu 상태
                foreach (ManagementObject queryObj in searcher.Get())
                {
                    Cpu_name = queryObj["Name"].ToString();
                }

                this.txtCpuInfo.Text = Cpu_name;
                this.txtCpuInfo2.Text = Cpu_Info;
                //Cpu 상태
                //***************************************************************
                //***************************************************************
                //CPU 사용량

                int Cpu_TotalUsed = 0;
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

                this.txtCpuUsage.Text = Cpu_Used + "%";
                //this.textBox5.Text = Cpu_Used + "%";
                int Cpu_UsedProgressBar = Convert.ToInt32(Cpu_Used);
                this.progressCpuUsage.EditValue = Cpu_UsedProgressBar;
                //Cpu_TotalUsed = Cpu_UsedProgressBar;

                // 싸이클 돌때마다 + 1 해줌
                //Cpu_Totalcycle = Cpu_Totalcycle + 1;
                //label17.Text = "ToTal_Cycle:" + Convert.ToString(Cpu_Totalcycle) + "회";
                //// 10 싸이클에 2분 , 50회에 10분 , 50회 돌았다면..
                //if (Cpu_Totalcycle >= 50)
                //{
                //    Cpu_Totalcycle = 0;
                //    Cpu_ExceedCnt = 0;
                //}


                // CPU 임계치가 90이 넘으면 
                //if (Cpu_TotalUsed >= 1)
                //{
                //    //int Cpu_ExceedCnt = 0;                                

                //    // CPU 90 넘을 시 +1 을 해줌 
                //    Cpu_ExceedCnt = Cpu_ExceedCnt + 1;
                //    // +1 해줄때마다 화면에 출력
                //    label16.Text = Convert.ToString(Cpu_ExceedCnt + " <== 10이 된다면 문자 발송이 된다");

                //    //+1을 해줌으로 10 이 된다면 아래 로그 생성
                //    if (Cpu_ExceedCnt >= 1)
                //    {
                //        Cpu_ExceedCnt = 0;
                //        string test1 = "C:\\Vm_HP_2_Server";
                //        string ServerName1 = "VM_HP_2_Server";
                //        string warning1 = "% CPU 임계치가 초과 되었습니다.";
                //        int USEDD = Cpu_TotalUsed;
                //        Program.ReadFile(test1, ServerName1, warning1, USEDD);
                //    }
                //}

                //CPU 사용량
                //***************************************************************
                //***************************************************************
                //물리적 총 메모리 
                foreach (ManagementObject queryObj in searcher2.Get())
                {
                    Totalmemory = ulong.Parse(queryObj["TotalVisibleMemorySize"].ToString());
                    FreePhysicalMemory = ulong.Parse(queryObj["FreePhysicalMemory"].ToString());
                }
                maxMem = (double)(Totalmemory / 1024);
                memfree = (double)(FreePhysicalMemory / 1024);
                memUsed = (double)(maxMem - memfree);
                double memUsedpercent = (double)((memUsed / maxMem) * 100);
                Math.Ceiling(memUsedpercent);
                int memUsedpercent1 = (int)(memUsedpercent);
                this.progressMemUsage.EditValue = memUsedpercent1;

                string mem1 = Convert.ToString(maxMem);
                string mem2 = Convert.ToString(memfree);
                string mem3 = Convert.ToString(memUsed);
                string mem4 = Convert.ToString(memUsedpercent1);

                this.txtRamPercent.Text = mem4 + " " + "%";
                this.txtRamTotal.Text = mem1 + " " + "MB";
                this.txtRamFree.Text = mem2 + " " + "MB";
                this.txtRamUsed.Text = mem3 + " " + "MB";

                //textBox4.Text = mem4 + " " + "%";
                //textBox7.Text = mem3 + " " + "MB";
                //textBox6.Text = mem2 + " " + "MB";
                //textBox3.Text = mem1 + " " + "MB";
                //물리적 총 메모리 
                //***************************************************************
                //***************************************************************
                //물리적 디스크 남은 용량
                try
                {


                    foreach (ManagementObject queryObj in searcher3.Get())
                    {
                        physicalDiskTotal = ulong.Parse(queryObj["Size"].ToString());
                        physicalDiskfree = ulong.Parse(queryObj["FreeSpace"].ToString());

                        double physicalDiskTotal1 = (double)(physicalDiskTotal / (1024 * 1024 * 1024));
                        physicalDiskTotal1 = (int)(physicalDiskTotal1);
                        string physicalDiskTotal2 = Convert.ToString(physicalDiskTotal1);

                        this.txtCTotal.Text = physicalDiskTotal2 + "GB";
                        //textBox8.Text = physicalDiskTotal2 + "GB";


                        double physicalDiskfree1 = (double)(physicalDiskfree / (1024 * 1024 * 1024));
                        physicalDiskfree1 = (int)(physicalDiskfree1);
                        string physicalDiskfree2 = Convert.ToString(physicalDiskfree1);
                        this.txtCFree.Text = physicalDiskfree2 + "GB";
                        //textBox9.Text = physicalDiskfree2 + "GB";


                        double physicalDiskUsed = (double)(physicalDiskTotal1 - physicalDiskfree1);
                        physicalDiskUsed = (int)(physicalDiskUsed);
                        string physicalDiskUsed1 = Convert.ToString(physicalDiskUsed);
                        this.txtCUsed.Text = physicalDiskUsed1 + "GB";
                        //textBox10.Text = physicalDiskUsed1 + "GB";


                        double physicalPercent = (double)((physicalDiskUsed / physicalDiskTotal1) * 100);
                        int physicalPercent1 = (int)(physicalPercent);
                        this.txtCPercent.Text = physicalPercent1 + " " + "%";
                        //textBox11.Text = physicalPercent1 + " " + "%";
                        //progressBar2.Value = physicalPercent1;
                        this.progressC.EditValue = physicalPercent1;

                    }
                }
                catch { }
                ////물리적 디스크 남은 용량
                ////***************************************************************
                ////***************************************************************
                try
                {

                    //D_물리적 디스크 남은 용량

                    foreach (ManagementObject queryObj in searcher4.Get())
                    {

                        ulong D_physicalDiskTotal = ulong.Parse(queryObj["Size"].ToString());
                        ulong D_physicalDiskfree = ulong.Parse(queryObj["FreeSpace"].ToString());

                        double D_physicalDiskTotal1 = (double)(D_physicalDiskTotal / (1024 * 1024 * 1024));
                        D_physicalDiskTotal1 = (int)(D_physicalDiskTotal1);
                        string D_physicalDiskTotal2 = Convert.ToString(D_physicalDiskTotal1);
                        //textBox12.Text = D_physicalDiskTotal2 + "GB";
                        this.txtDTotal.Text = D_physicalDiskTotal2 + "GB";


                        double D_physicalDiskfree1 = (double)(D_physicalDiskfree / (1024 * 1024 * 1024));
                        D_physicalDiskfree1 = (int)(D_physicalDiskfree1);
                        string D_physicalDiskfree2 = Convert.ToString(D_physicalDiskfree1);
                        //textBox13.Text = D_physicalDiskfree2 + "GB";
                        this.txtDFree.Text = D_physicalDiskfree2 + "GB";

                        double D_physicalDiskUsed = (double)(D_physicalDiskTotal1 - D_physicalDiskfree1);
                        D_physicalDiskUsed = (int)(D_physicalDiskUsed);
                        string D_physicalDiskUsed1 = Convert.ToString(D_physicalDiskUsed);
                        //textBox14.Text = D_physicalDiskUsed1 + "GB";
                        this.txtDUsed.Text = D_physicalDiskUsed1 + "GB";

                        double D_physicalPercent = (double)((D_physicalDiskUsed / D_physicalDiskTotal1) * 100);
                        int D_physicalPercent1 = (int)(D_physicalPercent);
                        //textBox15.Text = D_physicalPercent1 + " " + "%";
                        this.txtDPercent.Text = D_physicalPercent1 + " " + "%";
                        //progressBar3.Value = D_physicalPercent1;
                        this.progressD.EditValue = D_physicalPercent1;

                    }

                }
                catch { }
                //D_물리적 디스크 남은 용량
                //***************************************************************
                //***************************************************************
                //IP 정보
                string IPAddress2 = "";
                foreach (ManagementObject queryObj in searcher6.Get())
                {

                    String[] IPAddress = (String[])(queryObj["IPAddress"]);
                    string IPAddress1 = "";
                    for (int z = 0; z < IPAddress.Length; z++)
                    {
                        if (z == 0)
                            IPAddress1 = IPAddress1 + IPAddress[z] + ("\r\n");
                    }
                    IPAddress2 = IPAddress2 + IPAddress1 + ("\r\n");
                }



            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
            




            //InitControl();
        }


        /// <summary>
        /// name         : InitControl
        /// desc         : 컨트롤 초기화
        /// author       : 심우종
        /// create date  : 2020-09-15 16:11
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitControl()
        {
            this.lblTitle.Text = this.title;
            this.lblIp.Text = "(" + this.ip + ")";
            this.progressCpuUsage.Properties.Maximum = 100;
            this.progressMemUsage.Properties.Maximum = 100;
            this.progressC.Properties.Maximum = 100;
            this.progressD.Properties.Maximum = 100;
            //this.progressCpuUsage.Properties.Maximum = 100;
        }
    }
}