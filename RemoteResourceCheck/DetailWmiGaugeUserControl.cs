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
using DevExpress.XtraGauges.Core.Drawing;
using System.Management;

namespace RemoteResourceCheck
{
    public partial class DetailWmiGaugeUserControl : DevExpress.XtraEditors.XtraUserControl
    {

        string ip = "10.10.221.71";
        string id;
        string pw;

        System.Threading.Thread thread;
        bool isRun = false;

        Color greenColor = Color.FromArgb(4, 178, 121);
        Color redColor = Color.FromArgb(249, 53, 67);
        Color blueColor = Color.FromArgb(72, 190, 251);
        Color yellowColor = Color.FromArgb(255, 171, 24);

        
        public DetailWmiGaugeUserControl()
        {
            InitializeComponent();

            this.arcScaleRangeBarComponent2.Appearance.ContentBrush = new SolidBrushObject(redColor);
            this.labelComponent2.AppearanceText.TextBrush = new SolidBrushObject(redColor);
            this.arcScaleRangeBarComponent3.Appearance.ContentBrush = new SolidBrushObject(blueColor);
            this.labelComponent3.AppearanceText.TextBrush = new SolidBrushObject(blueColor);
            this.arcScaleRangeBarComponent4.Appearance.ContentBrush = new SolidBrushObject(greenColor);
            this.labelComponent4.AppearanceText.TextBrush = new SolidBrushObject(greenColor);
            this.arcScaleRangeBarComponent5.Appearance.ContentBrush = new SolidBrushObject(yellowColor);
            this.labelComponent5.AppearanceText.TextBrush = new SolidBrushObject(yellowColor);
        }

        int value = 10;
        int value2 = 20;
        int value3 = 30;
        int value4 = 40;
        private void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();

            try
            {



                //CheckStart();
            }
            finally
            {
                timer1.Start();
            }

            //arcScaleComponent2.Value = value++;
            //arcScaleComponent3.Value = value2++;
            //arcScaleComponent4.Value = value3++;
            //arcScaleComponent5.Value = value4++;
        }



        ulong Totalmemory = 0;
        double maxMem = 0;
        double memfree = 0;
        double memUsed = 0;
        double physicalDiskTotal = 0;
        double physicalDiskfree = 0;


        private string strValue;

        public string StrValue
        {
            get
            {
                return strValue;
            }

            set
            {
                strValue = value;
            }
        }

        private void DetailWmiGaugeUserControl_Load(object sender, EventArgs e)
        {
            

            System.Threading.ThreadStart threadStart = new System.Threading.ThreadStart(recvSSHData);
            thread = new System.Threading.Thread(threadStart);

            thread.IsBackground = true;
            thread.Start();

            //this.txtCpuInfo.Text


            //this.txtCpuInfo.DataBindings.Clear();
            //this.txtCpuInfo.DataBindings.Add("Text", this, "StrValue", true, DataSourceUpdateMode.OnPropertyChanged);

            //CheckStart();

            //InitComputer();
        }
        ManagementScope scope;
        public void InitComputer(DTO.ComInfoDTO cominfo)
        {

            this.ip = cominfo.ip;
            this.id = cominfo.id;
            this.pw = cominfo.pw;
            this.lblTitle.Text = cominfo.name;

            this.isRun = false;
            ConnectionOptions cConnectOption = new ConnectionOptions();
            string ip = this.ip; //"10.10.221.71";

            if (!string.IsNullOrEmpty(this.id) && !string.IsNullOrEmpty(this.pw))
            {
                cConnectOption.Username = this.id;
                cConnectOption.Password = this.pw;
            }

            scope = new ManagementScope("\\\\" + ip + "\\root\\CIMV2", cConnectOption);
            //ManagementScope scope = new ManagementScope("\\\\192.168.123.220\\root\\CIMV2", connection);
            scope.Connect();
            this.isRun = true;

            this.CheckOsInfo();
        }


        /// <summary>
        /// name         : CheckOsInfo
        /// desc         : OS정보 조회
        /// author       : 심우종
        /// create date  : 2020-09-22 17:13
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void CheckOsInfo()
        {
            ObjectQuery query = new ObjectQuery("SELECT * FROM Win32_Processor");
            ObjectQuery query5 = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
            ManagementObjectSearcher searcher = new ManagementObjectSearcher(scope, query);
            ManagementObjectSearcher searcher5 = new ManagementObjectSearcher(scope, query5);

            string Cpu_Info = "";
            string Cpu_name = "";
            string WindowOS = "";

            foreach (ManagementObject queryObj in searcher5.Get())
            {
                WindowOS = queryObj["Caption"].ToString();
            }
            //this.txtOS.Text = WindowOS;
            TextWriteer(this.txtOS, WindowOS);

            foreach (ManagementObject queryObj in searcher.Get())
            {
                Cpu_Info = queryObj["Caption"].ToString();
            }


            //Cpu 상태
            foreach (ManagementObject queryObj in searcher.Get())
            {
                Cpu_name = queryObj["Name"].ToString();
            }

            //this.txtCpuInfo.Text = Cpu_name;
            TextWriteer(this.txtCpuInfo, Cpu_name);
            //this.txtCpuInfo2.Text = Cpu_Info;
            TextWriteer(this.txtCpuInfo2, Cpu_Info);
        }

        private void CheckTest()
        {
            arcScaleComponent2.Value = value++;
            arcScaleComponent3.Value = value2++;
            arcScaleComponent4.Value = value3++;
            arcScaleComponent5.Value = value4++;

            //this.txtCpuInfo.Text = value.ToString();
            //this.StrValue = value.ToString();

            this.TextWriteer(txtCpuInfo, value.ToString());

            //this.txtCpuInfo.DataBindings.Clear();
            //this.txtCpuInfo.DataBindings.Add("Text", this, "StrValue", true, DataSourceUpdateMode.OnPropertyChanged);
        }

        public void TextWriteer(Sedas.Control.HTextEdit control, string value)
        {
            if (control.InvokeRequired)
            {
                control.BeginInvoke(new Action(delegate
                {
                    TextWriteer(control, value);
                }));
                return;
            }

            control.Text = value;
        }

        /// <summary>
        /// name         : CheckStart
        /// desc         : WMI 데이터 체크시작
        /// author       : 심우종
        /// create date  : 2020-09-22 15:31
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void CheckStart()
        {
            try
            {
                ObjectQuery query1 = new ObjectQuery("SELECT * FROM Win32_Processor");
                ObjectQuery query2 = new ObjectQuery("SELECT * FROM Win32_OperatingSystem");
                ObjectQuery query3 = new ObjectQuery("SELECT * FROM Win32_LogicalDisk where caption='C:'");
                ObjectQuery query4 = new ObjectQuery("SELECT * FROM Win32_LogicalDisk where caption='D:'");
                //ObjectQuery query6 = new ObjectQuery("SELECT * FROM Win32_NetworkAdapterConfiguration WHERE IPEnabled = 'TRUE'");
                

                ManagementObjectSearcher searcher1 = new ManagementObjectSearcher(scope, query1);
                ManagementObjectSearcher searcher2 = new ManagementObjectSearcher(scope, query2);
                ManagementObjectSearcher searcher3 = new ManagementObjectSearcher(scope, query3);
                ManagementObjectSearcher searcher4 = new ManagementObjectSearcher(scope, query4);
                
                //ManagementObjectSearcher searcher6 = new ManagementObjectSearcher(scope, query6);

                
                string Cpu_Used = "";
                
                ulong FreePhysicalMemory = 0;

                
                //Cpu 상태
                //***************************************************************
                //***************************************************************
                //CPU 사용량

                int Cpu_TotalUsed = 0;


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

                //this.txtCpuUsage.Text = Cpu_Used + "%";
                TextWriteer(this.txtCpuUsage, Cpu_Used + "%");
                //this.textBox5.Text = Cpu_Used + "%";
                //int Cpu_UsedProgressBar = Convert.ToInt32(Cpu_Used);
                arcScaleComponent2.Value = Convert.ToInt32(Cpu_Used);
                this.labelComponent2.Text = "CPU : " + Cpu_Used + "%";
                //this.progressCpuUsage.EditValue = Cpu_UsedProgressBar;
                //Cpu_TotalUsed = Cpu_UsedProgressBar;

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
                //this.progressMemUsage.EditValue = memUsedpercent1;
                

                string mem1 = Convert.ToString(maxMem);
                string mem2 = Convert.ToString(memfree);
                string mem3 = Convert.ToString(memUsed);
                string mem4 = Convert.ToString(memUsedpercent1);

                //this.txtRamPercent.Text = mem4 + " " + "%";
                TextWriteer(this.txtRamPercent, mem4 + " " + "%");
                //this.txtRamTotal.Text = mem1 + " " + "MB";
                TextWriteer(this.txtRamTotal, mem1 + " " + "MB");
                //this.txtRamFree.Text = mem2 + " " + "MB";
                TextWriteer(this.txtRamFree, mem2 + " " + "MB");
                //this.txtRamUsed.Text = mem3 + " " + "MB";
                TextWriteer(this.txtRamUsed, mem3 + " " + "MB");

                this.arcScaleComponent3.Value = memUsedpercent1;
                this.labelComponent3.Text = "RAM : " + mem4 + " " + "%";

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

                        //this.txtCTotal.Text = physicalDiskTotal2 + "GB";
                        TextWriteer(this.txtCTotal, physicalDiskTotal2 + "GB");
                        //textBox8.Text = physicalDiskTotal2 + "GB";


                        double physicalDiskfree1 = (double)(physicalDiskfree / (1024 * 1024 * 1024));
                        physicalDiskfree1 = (int)(physicalDiskfree1);
                        string physicalDiskfree2 = Convert.ToString(physicalDiskfree1);
                        //this.txtCFree.Text = physicalDiskfree2 + "GB";
                        TextWriteer(this.txtCFree, physicalDiskfree2 + "GB");
                        //textBox9.Text = physicalDiskfree2 + "GB";


                        double physicalDiskUsed = (double)(physicalDiskTotal1 - physicalDiskfree1);
                        physicalDiskUsed = (int)(physicalDiskUsed);
                        string physicalDiskUsed1 = Convert.ToString(physicalDiskUsed);
                        //this.txtCUsed.Text = physicalDiskUsed1 + "GB";
                        TextWriteer(this.txtCUsed, physicalDiskUsed1 + "GB");
                        //textBox10.Text = physicalDiskUsed1 + "GB";


                        double physicalPercent = (double)((physicalDiskUsed / physicalDiskTotal1) * 100);
                        int physicalPercent1 = (int)(physicalPercent);
                        //this.txtCPercent.Text = physicalPercent1 + " " + "%";
                        TextWriteer(this.txtCPercent, physicalPercent1 + " " + "%");
                        //textBox11.Text = physicalPercent1 + " " + "%";
                        //progressBar2.Value = physicalPercent1;
                        arcScaleComponent4.Value = physicalPercent1;
                        this.labelComponent4.Text = "DISC C : " + physicalPercent1 + " " + "%";
                        //this.progressC.EditValue = physicalPercent1;

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
                        //this.txtDTotal.Text = D_physicalDiskTotal2 + "GB";
                        TextWriteer(this.txtDTotal, D_physicalDiskTotal2 + "GB");


                        double D_physicalDiskfree1 = (double)(D_physicalDiskfree / (1024 * 1024 * 1024));
                        D_physicalDiskfree1 = (int)(D_physicalDiskfree1);
                        string D_physicalDiskfree2 = Convert.ToString(D_physicalDiskfree1);
                        //textBox13.Text = D_physicalDiskfree2 + "GB";
                        //this.txtDFree.Text = D_physicalDiskfree2 + "GB";
                        TextWriteer(this.txtDFree, D_physicalDiskfree2 + "GB");

                        double D_physicalDiskUsed = (double)(D_physicalDiskTotal1 - D_physicalDiskfree1);
                        D_physicalDiskUsed = (int)(D_physicalDiskUsed);
                        string D_physicalDiskUsed1 = Convert.ToString(D_physicalDiskUsed);
                        //textBox14.Text = D_physicalDiskUsed1 + "GB";
                        //this.txtDUsed.Text = D_physicalDiskUsed1 + "GB";
                        TextWriteer(this.txtDUsed, D_physicalDiskUsed1 + "GB");

                        double D_physicalPercent = (double)((D_physicalDiskUsed / D_physicalDiskTotal1) * 100);
                        int D_physicalPercent1 = (int)(D_physicalPercent);
                        //textBox15.Text = D_physicalPercent1 + " " + "%";
                        //this.txtDPercent.Text = D_physicalPercent1 + " " + "%";
                        TextWriteer(this.txtDPercent, D_physicalPercent1 + " " + "%");
                        //progressBar3.Value = D_physicalPercent1;
                        arcScaleComponent5.Value = D_physicalPercent1;
                        this.labelComponent5.Text = "DISC D : " + D_physicalPercent1 + " " + "%";
                        //this.progressD.EditValue = D_physicalPercent1;

                    }

                }
                catch { }
                //D_물리적 디스크 남은 용량
                //***************************************************************
                //***************************************************************
                //IP 정보
                //string IPAddress2 = "";
                //foreach (ManagementObject queryObj in searcher6.Get())
                //{

                //    String[] IPAddress = (String[])(queryObj["IPAddress"]);
                //    string IPAddress1 = "";
                //    for (int z = 0; z < IPAddress.Length; z++)
                //    {
                //        if (z == 0)
                //            IPAddress1 = IPAddress1 + IPAddress[z] + ("\r\n");
                //    }
                //    IPAddress2 = IPAddress2 + IPAddress1 + ("\r\n");
                //}



            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
            }
        }

        


        private void recvSSHData()
        {
            while (true)
            {
                if (isRun == false)
                {
                    System.Threading.Thread.Sleep(1000);
                    continue;
                }

                try
                {
                    //this.Invoke((MethodInvoker)delegate {  });
                    CheckStart();
                    //CheckTest();

                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.WriteLine(ex.StackTrace);
                }
                //Update();
                System.Threading.Thread.Sleep(1000);
            }
        }
    }
}
