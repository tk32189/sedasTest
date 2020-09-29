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
using System.Net.Sockets;
using Sedas.Core;
using DevExpress.XtraGauges.Core.Drawing;

namespace TestProject
{
    public partial class WMI : DevExpress.XtraEditors.XtraForm
    {
		public WMI()
        {
            InitializeComponent();
        }

		ManagementScope mScope;
		System.Threading.Thread thread;



		/// <summary>
		/// name         : hSimpleButton2_Click
		/// desc         : 원격프로그램 체킹 및 테스트
		/// author       : 심우종
		/// create date  : 
		/// update date  : 최종 수정일자 , 수정자, 수정개요
		/// </summary> 
		private void hSimpleButton2_Click(object sender, EventArgs e)
		{
			FileServerReStartTest();
		}


		/// <summary>
		/// name         : FileServerReStartTest
		/// desc         : Standby-Active 간의 파일서버를 재 실행한다.
		/// author       : 심우종
		/// create date  : 2020-08-21 14:26
		/// update date  : 최종 수정일자 , 수정자, 수정개요
		/// </summary> 
		private void FileServerReStartTest()
		{
			ConnectionOptions cConnectOption = new ConnectionOptions();
			string ip = "10.10.221.71";
			//cConnectOption.Username = "mj2kuh";
			//cConnectOption.Password = "sJ0802$!";
			mScope = new ManagementScope("\\\\" + ip + "\\root\\CIMV2", cConnectOption);
			mScope.Connect();

			//object[] theProcessToRun = { "notepad.exe" };

			ManagementClass theClass = new ManagementClass(mScope, new ManagementPath("Win32_Process"), new ObjectGetOptions());

			//1) 기존에 띄워져 있는 프로세스가 있으면 KILL
			ObjectQuery theQuery = new ObjectQuery("SELECT * FROM Win32_Process WHERE Name='FileTransferServer.exe'");
			ManagementObjectSearcher theSearcher = new ManagementObjectSearcher(mScope, theQuery);
			ManagementObjectCollection theCollection = theSearcher.Get();

			foreach (ManagementObject theCurObject in theCollection)
			{
				//기존에 프로그램이 띄워져 있으면 kill
				if (theCurObject["Caption"].ToString() == "FileTransferServer.exe")
				{
					theCurObject.InvokeMethod("Terminate", null);
				}
			}

			//2) 다시 실행
			object[] theProcessToRun = { @"C:\BASE\SedasSolutions\FileTransferServer\bin\Debug\FileTransferServer.exe ReStart" };
			theClass.InvokeMethod("Create", theProcessToRun);
		}

		private void hSimpleButton1_Click(object sender, EventArgs e)
        {

			try
			{

				ConnectionOptions cConnectOption = new ConnectionOptions();
				//10.10.221.71
				string ip = "10.10.221.71";
				mScope = new ManagementScope("\\\\" + ip + "\\root\\CIMV2", cConnectOption);
				mScope.Connect();


				//ConnectionOptions cConnectOption = new ConnectionOptions();
				//cConnectOption.Username = "mj2kuh";
				//cConnectOption.Password = "sJ0802$!";
				////10.10.221.71
				//string ip = "10.10.50.142";
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
					getCpuTime();
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

				//label1.Text = "CPU 미사용 : " + (100 - cpuTime).ToString();

				//label2.Text = "CPU 사용중 : " +  cpuTime.ToString();

				txtThreadSafeDisplay(label1, "CPU 미사용: " + (100 - cpuTime).ToString());
				txtThreadSafeDisplay(label2, "CPU 사용중 : " + cpuTime.ToString());

				arcScaleComponent1.Value = (float)cpuTime;
				//this.arcScaleRangeBarComponent1.Appearance.ContentBrush = new SolidBrushObject(Color.Red);

				//label1.Update();
				//label2.Update();
				//fdfdfdfdfd
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.Message);
				Console.WriteLine(ex.StackTrace);
			}
		}


		private void txtThreadSafeDisplay(Label control, string text)
		{
			if (control.InvokeRequired)
			{
				control.BeginInvoke(new Action(delegate
				{
					txtThreadSafeDisplay(control, text);
				}));
				return;
			}

			control.Text = text;
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

			decimal memUse = ((Convert.ToDecimal(mObject["FreePhysicalMemory"].ToString()) / Convert.ToDecimal(mObject["TotalVisibleMemorySize"].ToString())) * 100);
			decimal memNotUse = (((Convert.ToDecimal(mObject["TotalVisibleMemorySize"].ToString()) - Convert.ToDecimal(mObject["FreePhysicalMemory"].ToString())) / Convert.ToDecimal(mObject["TotalVisibleMemorySize"].ToString())) * 100);

			hLabelControl8.Text = "여유 : "  + memUse.ToString();
			hLabelControl9.Text = "사용중 : " + memNotUse.ToString();

			hLabelControl1.Text = "전체 메모리 : " + (Convert.ToInt32(mObject["TotalVisibleMemorySize"].ToString()) / 1024).ToString();
			hLabelControl2.Text = "여유 메모리 : " + (Convert.ToInt32(mObject["FreePhysicalMemory"].ToString()) / 1024).ToString();
			hLabelControl3.Text = "사용 메모리 : " + ((Convert.ToInt32(mObject["TotalVisibleMemorySize"].ToString()) - Convert.ToInt32(mObject["FreePhysicalMemory"].ToString())) / 1024).ToString();


			hLabelControl4.Text = "OS : " + mObject["Caption"].ToString();
			hLabelControl5.Text = "OS Version : " + mObject["Version"].ToString();
			hLabelControl6.Text = "BuildNumber : " + mObject["BuildNumber"].ToString();
			hLabelControl7.Text = "Server-Name : " + mObject["CSName"].ToString();

			arcScaleComponent2.Value = (float)memNotUse;


			//if (listBox1.Items.Count == 0)
			//{
			//	listBox1.Items.Add("OS : " + mObject["Caption"].ToString());
			//	listBox1.Items.Add("OS Version : " + mObject["Version"].ToString());
			//	listBox1.Items.Add("BuildNumber : " + mObject["BuildNumber"].ToString());
			//	listBox1.Items.Add("Server-Name : " + mObject["CSName"].ToString());
			//}
		}

		private void hPanelControl1_Paint(object sender, PaintEventArgs e)
		{

		}

		Timer timer;

		private void hSimpleButton3_Click(object sender, EventArgs e)
		{
			timer = new System.Windows.Forms.Timer();
			timer.Interval = 5000;
			timer.Tick += Timer_Tick;
			timer.Start();
		}
		private void Timer_Tick(object sender, EventArgs e)
		{

			//Socket oSocket = null;
			//oSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			//IPAddress oIPAddress = IPAddress.Parse(this.needToCrossCheckIp);
			//IPEndPoint oIPEndPoint = new IPEndPoint(oIPAddress, Convert.ToInt32(this.txtPort.Text));
			this.OtherServerCrossChecking();
		}


		private async void OtherServerCrossChecking()
		{
			await Task.Run(() =>
			{
				OtherServerCrossCheckingAsync();
			});
		}

		string needToCrossCheckIp = "10.10.221.71";
		string reStartDefaultPort = "28080";

		int isDisConnectCount = 0;
		/// <summary>
		/// name         : OtherServerCrossChecking
		/// desc         : 다른서버에 있는 프로그램 연결여부 확인
		/// author       : 심우종
		/// create date  : 
		/// update date  : 최종 수정일자 , 수정자, 수정개요
		/// </summary> 
		private async void OtherServerCrossCheckingAsync()
		{
			if (string.IsNullOrEmpty(this.needToCrossCheckIp))
				return;

			bool isConnected = false;
			try
			{
				string ip = this.needToCrossCheckIp;
				int port = Convert.ToInt32(this.reStartDefaultPort);
				using (TcpClient client = new TcpClient(ip, port))
				{
					if (client.Connected == true)
					{
						isConnected = true;
					}
				}
			}
			catch
			{

			}

			//연결 끊어짐
			if (isConnected == true)
			{
				TextInputThreadSafe(this.crossCheckState, string.Format("[{0}] 연결됨", this.needToCrossCheckIp));
				isDisConnectCount = 0;
			}
			else
			{
				TextInputThreadSafe(this.crossCheckState, string.Format("[{0}] 연결 끊어짐", this.needToCrossCheckIp));
				isDisConnectCount++;
			}

			//타이머 10번 실행될 동안 연결이 안되면 프로세스를 강제로 다시 시작한다.
			if (isDisConnectCount == 10)
			{
				this.FileServerReStartTest();
			}
		}


		private void TextInputThreadSafe(Label control, string message)
		{
			if (control.InvokeRequired)
			{
				control.BeginInvoke(new Action(delegate
				{
					TextInputThreadSafe(control, message);
				}));
				return;
			}

			control.Text = message;
		}
		//private void UpdateOSInfo(ManagementObject mObject)
		//{
		//	chart2.Series["mem"].Points.Clear();

		//	chart2.Series["mem"].Points.AddXY("여유", ((Convert.ToDecimal(mObject["FreePhysicalMemory"].ToString()) / Convert.ToDecimal(mObject["TotalVisibleMemorySize"].ToString())) * 100));
		//	chart2.Series["mem"].Points.AddXY("사용중", ((Convert.ToDecimal(mObject["TotalVisibleMemorySize"].ToString()) - Convert.ToDecimal(mObject["FreePhysicalMemory"].ToString())) / Convert.ToDecimal(mObject["TotalVisibleMemorySize"].ToString())) * 100);

		//	label10.Text = "전체 메모리 : " + (Convert.ToInt32(mObject["TotalVisibleMemorySize"].ToString()) / 1024).ToString();
		//	label11.Text = "여유 메모리 : " + (Convert.ToInt32(mObject["FreePhysicalMemory"].ToString()) / 1024).ToString();
		//	label12.Text = "사용 메모리 : " + ((Convert.ToInt32(mObject["TotalVisibleMemorySize"].ToString()) - Convert.ToInt32(mObject["FreePhysicalMemory"].ToString())) / 1024).ToString();

		//	if (listBox1.Items.Count == 0)
		//	{
		//		listBox1.Items.Add("OS : " + mObject["Caption"].ToString());
		//		listBox1.Items.Add("OS Version : " + mObject["Version"].ToString());
		//		listBox1.Items.Add("BuildNumber : " + mObject["BuildNumber"].ToString());
		//		listBox1.Items.Add("Server-Name : " + mObject["CSName"].ToString());
		//	}
		//}
	}
}