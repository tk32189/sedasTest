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
using System.Drawing.Drawing2D;
using Istrib.Sound.Formats;
using Istrib.Sound;
using System.IO;
using System.Runtime.InteropServices;

namespace DRS
{

    public struct USB_INPUT     // UIO 입력 패킷으로부터 데이타를 얻기 위한 구조체 
    {
        public int ProductID;   // 장치 ID 
        public Byte Status;     // 패킷 수신 상태값  0=입력 변화에 의한 수신, 1=데이타 재전송 요구에 의한 수신 
        public Byte Button;     // 입력 버턴값
        public Byte Output;     // USB 장치의 입출력 상태값
        public Byte Mask;       // 포트의 입출력 설정값. bit값이 '0'이면 출력, '1'이면 입력
    };


    public partial class DRS : DevExpress.XtraEditors.XtraForm
    {

        [DllImport("uio.dll")]
        private static extern int usb_io_init(int pID);
        [DllImport("uio.dll")]
        private static extern void set_usb_events(int hWnd);
        [DllImport("uio.dll")]
        private static extern void get_usb_input(int lParam, ref USB_INPUT uInput);
        [DllImport("uio.dll")]
        private static extern bool usb_io_output(int pID, int cmd, int io1, int io2, int io3, int io4);
        [DllImport("uio.dll")]
        private static extern bool usb_io_reset(int pID);
        [DllImport("uio.dll")]
        private static extern bool usb_in_request(int pID);




        public DRS()
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("DevExpress Dark Style");

            InitializeComponent();
            
        }

        List<SoundCaptureDevice> deviceList = new List<SoundCaptureDevice>();
        int deviceSelectedIndex = 0;


        //----------------------------------기존변수들
        private bool _isPlayer = false;
        private FifoStream _stream;
        private AudioFrame _audioFrame;
        private bool _isTest = false;
        private WaveInRecorder _recorder;
        private byte[] _recorderBuffer;
        private WaveOutPlayer _player;
        private byte[] _playerBuffer;
        private WaveFormat _waveFormat;
        private int _audioFrameSize = 16384;
        private byte _audioBitsPerSample = 16;
        private byte _audioChannels = 2;

        //----------------------------------기존변수들


        
        /// <summary>
        /// name         : DRS_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-04-01 11:00
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void DRS_Load(object sender, EventArgs e)
        {
            try
            {

                this.txtYear.Text = DateTime.Now.ToString("yy");

                //this.Size = new System.Drawing.Size(1207, 1000);
                gTrackBar1.Location = new System.Drawing.Point(20, 105);
                gTrackBar1.Size = new System.Drawing.Size(370, 30);
                foreach (SoundCaptureDevice device in SoundCaptureDevice.AllAvailable)
                {
                    deviceList.Add(device);
                }
                GetIniFile();

                DirectoryInfo di = new DirectoryInfo(Ini.strTempPath.Substring(0, Ini.strTempPath.Length));
                if (di.Exists == true)
                {
                    FileDelete();
                }
                if (di.Exists == false)   //If New Folder not exits  
                {
                    di.Create();             //create Folder  
                }

                //OCSConn();
                deviceSelectedIndex = 0;

                if (WaveNative.waveInGetNumDevs() > 0)
                {
                    if (_isPlayer == true)
                        _stream = new FifoStream();
                    _audioFrame = new AudioFrame(_isTest);
                }
                WaveStart();

                //bool ret = LocalDB.MySqlOpen(Ini.strDB);
                //if (!ret) MessageBox.Show("DB 접속실패");
                
                set_usb_events(this.Handle.ToInt32());

                txtPtNo.Focus();



            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }



        /// <summary>
        /// name         : GetIniFile
        /// desc         : 환경변수 불러오기
        /// author       : 심우종
        /// create date  : 2020-04-01 11:11
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void GetIniFile()
        {
            Ini.strPath = System.Environment.CurrentDirectory + "\\IniFile\\Setting.ini";

            Ini.strDB = Ini.G_IniReadValue("DB_Connection", "DBConnectionString", Ini.strPath);
            Ini.DBSelect = Ini.G_IniReadValue("DB_Connection", "SELECT", Ini.strPath);
            Ini.DBInsert = Ini.G_IniReadValue("DB_Connection", "INSERT", Ini.strPath);
            Ini.DBUpdate = Ini.G_IniReadValue("DB_Connection", "UPDATE", Ini.strPath);
            Ini.DBDelete = Ini.G_IniReadValue("DB_Connection", "DELETE", Ini.strPath);

            Ini.strOCS = Ini.G_IniReadValue("OCS_Connection", "OCSConnectionString", Ini.strPath);
            Ini.OCSSelectDate = Ini.G_IniReadValue("OCS_Connection", "DATE_SELECT", Ini.strPath);
            Ini.OCSSelectPtno = Ini.G_IniReadValue("OCS_Connection", "PTNO_SELECT", Ini.strPath);
            Ini.OCSInsert = Ini.G_IniReadValue("OCS_Connection", "INSERT", Ini.strPath);
            Ini.OCSUpdate = Ini.G_IniReadValue("OCS_Connection", "UPDATE", Ini.strPath);
            Ini.OCSDelete = Ini.G_IniReadValue("OCS_Connection", "DELETE", Ini.strPath);

            Ini.SQLDB = Ini.G_IniReadValue("OCS_Connection", "OCSConnectionString", Ini.strPath);
            Ini.SQLDBDateSelect = Ini.G_IniReadValue("OCS_Connection", "DATE_SELECT", Ini.strPath);
            Ini.SQLDBPtnoSelect = Ini.G_IniReadValue("OCS_Connection", "PTNO_SELECT", Ini.strPath);

            Ini.rootpath = Ini.G_IniReadValue("PATH", "ROOTPATH", Ini.strPath);
            Ini.strSearchPath = Ini.G_IniReadValue("PATH", "SEARCHPATH", Ini.strPath);
            //Ini.strBackPath = Ini.G_IniReadValue("PATH", "BACKPATH", Ini.strPath);
            Ini.strBackPath = Application.StartupPath + "\\backup";
            Ini.strTempPath = Application.StartupPath + "\\Temp";
            //Ini.strTempPath = Ini.G_IniReadValue("PATH", "TEMPPATH", Ini.strPath);
            Ini.CapturePath = Ini.G_IniReadValue("PATH", "CAPTUREPATH", Ini.strPath);

            Ini.nRecord = Convert.ToInt32(Ini.G_IniReadValue("ETC", "Record", Ini.strPath));
            Ini.nPlay = Convert.ToInt32(Ini.G_IniReadValue("ETC", "Play", Ini.strPath));



            Ini.strPath = System.Environment.CurrentDirectory + "\\IniFile\\Combo.ini";
            Ini.PFCnt = Ini.G_IniReadValue("PREFIX", "COUNT", Ini.strPath);
            Ini.PFHP = Ini.G_IniReadValue("YEAR", "PrefixHyphen", Ini.strPath);
            Ini.YRHP = Ini.G_IniReadValue("YEAR", "YearHyphen", Ini.strPath);
            Ini.YRLen = Ini.G_IniReadValue("YEAR", "Length", Ini.strPath);
            Ini.NumCnt = Ini.G_IniReadValue("NUMBER", "Length", Ini.strPath);
            Ini.Zero = Ini.G_IniReadValue("NUMBER", "Zero", Ini.strPath);

        }


        public void FileDelete()
        {
            try
            {

                DirectoryInfo dir = new DirectoryInfo(Ini.strTempPath.Substring(0, Ini.strTempPath.Length));
                if (dir.Exists == true)
                {
                    System.IO.FileInfo[] files = dir.GetFiles("*.*", SearchOption.AllDirectories);
                    foreach (System.IO.FileInfo file in files)
                        file.Attributes = FileAttributes.Normal;
                    Directory.Delete(Ini.strTempPath.Substring(0, Ini.strTempPath.Length), true);


                    DirectoryInfo di = new DirectoryInfo(Ini.strTempPath.Substring(0, Ini.strTempPath.Length));  //Create Directoryinfo value by sDirPath  

                    if (di.Exists == false)   //If New Folder not exits  
                    {
                        di.Create();             //create Folder  
                    }
                }
            }
            catch { }


        }


        private void WaveStart()
        {
            WaveStop();
            try
            {
                _waveFormat = new WaveFormat(_audioFrameSize, _audioBitsPerSample, _audioChannels);
                _recorder = new WaveInRecorder(0, _waveFormat, _audioFrameSize * 2, 3, new BufferDoneEventHandler(DataArrived));
                if (_isPlayer == true)
                    _player = new WaveOutPlayer(-1, _waveFormat, _audioFrameSize * 2, 3, new BufferFillEventHandler(Filler));
                /*tbYear.AppendText(DateTime.Now.ToString() + " : Audio device initialized\r\n");
                tbYear.AppendText(DateTime.Now.ToString() + " : Audio device polling started\r\n");
                tbYear.AppendText(DateTime.Now + " : Samples per second = " + _audioSamplesPerSecond.ToString() + "\r\n");
                tbYear.AppendText(DateTime.Now + " : Frame size = " + _audioFrameSize.ToString() + "\r\n");
                tbYear.AppendText(DateTime.Now + " : Bits per sample = " + _audioBitsPerSample.ToString() + "\r\n");
                tbYear.AppendText(DateTime.Now + " : Channels = " + _audioChannels.ToString() + "\r\n");*/
            }
            catch (Exception ex)
            {
                //tbYear.AppendText(DateTime.Now + " : Audio exception\r\n" + ex.ToString() + "\r\n");
                MessageBox.Show(DateTime.Now + " : Audio exception\r\n" + ex.ToString() + "\r\n");
            }
        }

        private void WaveStop()
        {
            if (_recorder != null)
                try
                {
                    _recorder.Dispose();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    _recorder = null;
                }
            if (_isPlayer == true)
            {
                if (_player != null)
                    try
                    {
                        _player.Dispose();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    finally
                    {
                        _player = null;
                    }
                _stream.Flush(); // clear all pending data
            }
        }

        private void DataArrived(IntPtr data, int size)
        {
            if (_recorderBuffer == null || _recorderBuffer.Length < size)
                _recorderBuffer = new byte[size];
            if (_recorderBuffer != null)
            {
                System.Runtime.InteropServices.Marshal.Copy(data, _recorderBuffer, 0, size);
                if (_isPlayer == true)
                    _stream.Write(_recorderBuffer, 0, _recorderBuffer.Length);
                _audioFrame.Process(ref _recorderBuffer);
                _audioFrame.RenderTimeDomain(ref pictureBox1);
            }
        }

        private void Filler(IntPtr data, int size)
        {
            if (_isPlayer == true)
            {
                if (_playerBuffer == null || _playerBuffer.Length < size)
                    _playerBuffer = new byte[size];
                if (_stream.Length >= size)
                    _stream.Read(_playerBuffer, 0, size);
                else
                    for (int i = 0; i < _playerBuffer.Length; i++)
                        _playerBuffer[i] = 0;
                System.Runtime.InteropServices.Marshal.Copy(_playerBuffer, 0, data, size);
            }
        }

        private void grdOrder_Click(object sender, EventArgs e)
        {

        }
    }
}