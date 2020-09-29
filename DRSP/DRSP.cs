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
using System.Runtime.InteropServices;
using NAudio.Wave;
using NAudio.CoreAudioApi;
using System.IO;
using System.Diagnostics;

namespace DRSP
{
    public partial class DRSP : DevExpress.XtraEditors.XtraForm
    {
        private bool bPause = false;
        private string sPTNO, sPID, sNAME, rootFile;
        private WaveInRecorder _recorder;
        private byte[] _recorderBuffer;
        private WaveOutPlayer _player;
        private byte[] _playerBuffer;
        private FifoStream _stream;
        private WaveFormat _waveFormat;
        private AudioFrame _audioFrame;
        private int _audioSamplesPerSecond = 44100;
        private int _audioFrameSize = 16384;
        private byte _audioBitsPerSample = 16;
        private byte _audioChannels = 2;
        private bool _isPlayer = false;
        private bool _isTest = false;
        private string strSryle;
        //private static OleDbConnection conn;

        [DllImport("Gdi32.dll", EntryPoint = "CreateRoundRectRgn")]
        private static extern IntPtr CreateRoundRectRgn(int left, int top, int right, int bottom, int radiusX, int radiusY);

        private Point mousePoint;
        private bool bDate, bPlay;

        public Mp3FileReader reader;
        private WaveOut waveOut;
        private string fileName;
        private int M = 0;


        /// <summary>
        /// name         : DRSP
        /// desc         : 생성자
        /// author       : 심우종
        /// create date  : 2020-04-06 09:20
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public DRSP()
        {
            InitializeComponent();

            //intro 임시 제외..
            //Intro dlg = new Intro();
            //dlg.ShowDialog();

            fileName = "";
            bDate = true;
            bPlay = false;

            FormBorderStyle = FormBorderStyle.None;
            this.Size = new System.Drawing.Size(390, 800);
            Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 35, 35));
        }


        private void DRSP_Load(object sender, EventArgs e)
        {
            try
            {
                Getini();
                ChangFormStyle(Ini.strStyle);
                CteatTV();
                //DBM.DBConn(Ini.strDB, Ini.strDBType);
                if (WaveNative.waveInGetNumDevs() > 0)
                {
                    if (_isPlayer == true)
                        _stream = new FifoStream();
                    _audioFrame = new AudioFrame(_isTest);
                    Start();
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show(ex.Message);
                Application.Exit();
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            /*
                        OpenFileDialog ofd = new OpenFileDialog();
                        ofd.ShowDialog();
                        fileName = ofd.FileName;

                        try
                        {
                            if (!bPlay && fileName != "")
                            {
                                if (!bPause)
                                {
                                    fileName = Ini.temppath + listView1.FocusedItem.SubItems[4].Text.ToString();
                                    String rootpath;
                                    rootpath = Ini.rootpath + rootFile;

                                    FileInfo file = new FileInfo(fileName);
                                    //file.CopyTo(rootpath, true);
                                    File.Copy(rootpath, fileName, true);
                                    file = null;

                                    reader = new Mp3FileReader(fileName);
                                    waveOut = new WaveOut();
                                    waveOut.Init(reader);

                                }
                                waveOut.Play();
                                timer1.Start();
                                bPlay = true;
                                btnPlay.BackgroundImage = global::DRSP.Properties.Resources.플레이어_일시정지_01;
                                pictureBox1.Visible = true;
                                bPause = false;

                            }

                            else if (bPlay)
                            {
                                bPause = true;
                                pictureBox1.Visible = false;
                                waveOut.Pause();
                                bPlay = false;
                                btnPlay.BackgroundImage = global::DRSP.Properties.Resources.플레이어_재생_01;
                            }
                            MessageBox.Show("2");
                        }
                        catch (System.Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                            MessageBox.Show(fileName);
                        }
              */
            play();

        }

        private void play()
        {
            //try
            //{
            //    if (!bPlay && fileName != "")
            //    {
            //        if (!bPause)
            //        {
            //            fileName = Ini.temppath + listView1.FocusedItem.SubItems[4].Text.ToString();
            //            String rootpath;
            //            rootpath = Ini.rootpath + rootFile;

            //            FileInfo file = new FileInfo(fileName);
            //            //file.CopyTo(rootpath, true);
            //            File.Copy(rootpath, fileName, true);
            //            file = null;

            //            reader = new Mp3FileReader(fileName);
            //            waveOut = new WaveOut();
            //            waveOut.Init(reader);

            //        }
            //        waveOut.Play();
            //        timer1.Start();
            //        bPlay = true;
            //        btnPlay.BackgroundImage = global::DRSP.Properties.Resources.플레이어_일시정지_01;
            //        pictureBox1.Visible = true;
            //        bPause = false;

            //    }

            //    else if (bPlay)
            //    {
            //        bPause = true;
            //        pictureBox1.Visible = false;
            //        waveOut.Pause();
            //        bPlay = false;
            //        btnPlay.BackgroundImage = global::DRSP.Properties.Resources.플레이어_재생_01;

            //    }

            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //    //MessageBox.Show(fileName);
            //}

        }


        private void btnStop_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    if (bPlay)
            //    {

            //        bPlay = false;
            //        pictureBox1.Visible = false;
            //        gTrackBar1.Value = gTrackBar1.MinValue;
            //        waveOut.Stop();
            //        reader.Dispose();
            //        reader = null;
            //        labelTotalTime.Text = "00:00 / 00:00";
            //        FileInfo fi = new FileInfo(fileName);
            //        if (fi.Exists)
            //        {
            //            fi.Delete();
            //        }

            //    }
            //    btnPlay.BackgroundImage = global::DRSP.Properties.Resources.플레이어_재생_01;
            //}
            //catch (System.Exception ex)
            //{

            //}
        }


        /// <summary>
        /// name         : pnlTop_MouseDown
        /// desc         : 화면 해더 부분 MouseDown이벤트
        /// author       : 심우종
        /// create date  : 2020-04-06 09:30
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void pnlTop_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }



        /// <summary>
        /// name         : pnlTop_MouseMove
        /// desc         : 화면 해더 부분 MouseMove이벤트
        /// author       : 심우종
        /// create date  : 2020-04-06 09:30
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void pnlTop_MouseMove(object sender, MouseEventArgs e)
        {
            if ((e.Button & MouseButtons.Left) == MouseButtons.Left)
            {
                Location = new Point(this.Left - (mousePoint.X - e.X), this.Top - (mousePoint.Y - e.Y));
            }
        }


        /// <summary>
        /// name         : btnMini_Click
        /// desc         : 최소화 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-06 09:29
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnMini_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }


        /// <summary>
        /// name         : btnExit_Click
        /// desc         : 닫기버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-06 09:29
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void CteatTV()
        {
            TreeNode MainNode = new TreeNode("Gross", 1, 1);
            TreeNode Node1 = new TreeNode("Stomach");
            Node1.Nodes.Add("Biopsy");
            TreeNode Node2 = new TreeNode("Breast");
            Node2.Nodes.Add("Cor biopsy");
            TreeNode Node21 = new TreeNode("Mammotome biopsy");
            Node21.Nodes.Add("Rt");
            Node21.Nodes.Add("Lt");
            TreeNode Node3 = new TreeNode("Placenta");
            TreeNode Node4 = new TreeNode("Rectum");
            TreeNode Node5 = new TreeNode("Bone marrow");
            TreeNode Node6 = new TreeNode("SKIN");


            Node2.Nodes.Add(Node21);
            MainNode.Nodes.Add(Node1);
            MainNode.Nodes.Add(Node2);
            MainNode.Nodes.Add(Node3);
            MainNode.Nodes.Add(Node4);
            MainNode.Nodes.Add(Node5);
            MainNode.Nodes.Add(Node6);

            //treeView1.Nodes.Add(MainNode);

        }

        

        private void Start()
        {
            Stop();
            try
            {
                _waveFormat = new WaveFormat(_audioFrameSize, _audioBitsPerSample, _audioChannels);
                _recorder = new WaveInRecorder(1, _waveFormat, _audioFrameSize * 2, 3, new BufferDoneEventHandler(DataArrived));
                if (_isPlayer == true)
                    _player = new WaveOutPlayer(1, _waveFormat, _audioFrameSize * 2, 3, new BufferFillEventHandler(Filler));
            }
            catch (Exception ex)
            {
                MessageBox.Show("스피커를 연결해 주세요.\r\n" + ex.Message);//ex.Message);
            }
        }

        private void Stop()
        {
            if (_recorder != null)
                try
                {
                    _recorder.Dispose();
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
                    finally
                    {
                        _player = null;
                    }
                _stream.Flush(); // clear all pending data
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

        //private void chkDate_Click(object sender, EventArgs e)
        //{
        //    if (!bDate)
        //    {
        //        this.chkPTNO.BackgroundImage = global::DRSP.Properties.Resources.원형체크박스_01;
        //        this.chkDate.BackgroundImage = global::DRSP.Properties.Resources.원형체크박스_02_선택_;
        //        bDate = true;
        //    }
        //    else
        //    {
        //        this.chkPTNO.BackgroundImage = global::DRSP.Properties.Resources.원형체크박스_02_선택_;
        //        this.chkDate.BackgroundImage = global::DRSP.Properties.Resources.원형체크박스_01;
        //        bDate = false;
        //    }
        //}

        //private void chkPTNO_Click(object sender, EventArgs e)
        //{
        //    if (bDate)
        //    {
        //        bDate = false;
        //        this.chkPTNO.BackgroundImage = global::DRSP.Properties.Resources.원형체크박스_02_선택_;
        //        this.chkDate.BackgroundImage = global::DRSP.Properties.Resources.원형체크박스_01;
        //    }
        //    else
        //    {
        //        bDate = true;
        //        this.chkDate.BackgroundImage = global::DRSP.Properties.Resources.원형체크박스_02_선택_;
        //        this.chkPTNO.BackgroundImage = global::DRSP.Properties.Resources.원형체크박스_01;
        //    }
        //}

        //private void btnRecord_MouseMove(object sender, MouseEventArgs e)
        //{
        //    this.btnRecord.BackgroundImage = global::DRSP.Properties.Resources.검색_button_02;
        //}

        //private void btnRecord_MouseLeave(object sender, EventArgs e)
        //{
        //    this.btnRecord.BackgroundImage = global::DRSP.Properties.Resources.검색_button_01;
        //}

        //private void timer1_Tick(object sender, EventArgs e)
        //{
        //    if (reader != null)
        //    {

        //        string str1 = reader.CurrentTime.ToString();
        //        string str2 = reader.TotalTime.ToString();
        //        str1 = str1.Substring(3, 5);
        //        str2 = str2.Substring(3, 5);


        //        labelTotalTime.Text = string.Format("{0} / {1}", str1, str2);

        //        gTrackBar1.Value = Math.Min((int)((gTrackBar1.MaxValue * reader.Position) / reader.Length), gTrackBar1.MaxValue);
        //        if (gTrackBar1.Value == 99)
        //        {
        //            M++;
        //        }
        //        if (M == 7)
        //        {

        //            M = 0;
        //            gTrackBar1.Value = 100;
        //        }

        //        if (gTrackBar1.Value == gTrackBar1.MaxValue)
        //        // if(str1 ==str2)
        //        {
        //            timer1.Stop();

        //            bPlay = false;
        //            reader.Dispose();
        //            reader = null;
        //            btnPlay.BackgroundImage = global::DRSP.Properties.Resources.플레이어_재생_01;
        //            pictureBox1.Visible = false;
        //            labelTotalTime.Text = "00:00 / 00:00";
        //            gTrackBar1.Value = gTrackBar1.MinValue;
        //            // fileName = Ini.temppath + listView1.FocusedItem.SubItems[4].Text.ToString();
        //            FileInfo fi = new FileInfo(fileName);

        //            if (fi.Exists)
        //            {
        //                fi.Delete();
        //            }

        //        }

        //    }
        //}

        private void timer2_Tick(object sender, EventArgs e)
        {
            M++;
        }

        private void gTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (this.reader != null)
            {
                reader.Position = (gTrackBar1.Value * reader.Length) / gTrackBar1.MaxValue;
            }
        }

        private void gTrackBar1_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.reader != null)
            {
                double clickValue = ((double)e.X / (double)gTrackBar1.Width) * (gTrackBar1.MaxValue - gTrackBar1.MinValue);
                gTrackBar1.Value = Convert.ToInt32(clickValue);
                reader.Position = (gTrackBar1.Value * reader.Length) / gTrackBar1.MaxValue;
            }
        }

        private void btnRewind_Click(object sender, EventArgs e)
        {
            if (bPlay)
            {
                waveOut.Pause();
                gTrackBar1.Value = gTrackBar1.Value - 5;
                reader.Position = (gTrackBar1.Value * reader.Length) / gTrackBar1.MaxValue;
                waveOut.Play();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (bPlay)
            {
                waveOut.Pause();
                gTrackBar1.Value = gTrackBar1.Value + 5;
                reader.Position = (gTrackBar1.Value * reader.Length) / gTrackBar1.MaxValue;
                waveOut.Play();
            }
        }

        private void gTrackBar1_ValueChanged(object sender, EventArgs e)
        {
            if (this.reader != null)
            {
                //reader.Position = (gTrackBar1.Value * reader.Length) / gTrackBar1.MaxValue;
            }
        }

        private void DRSP_FormClosing(object sender, FormClosingEventArgs e)
        {
            Ini.G_IniWriteValue("ETC", "STYLE", Ini.strStyle, Ini.strPath);

            if (bPlay)
            {
                waveOut.Stop();
            }
            if (reader != null)
            {
                waveOut.Dispose();
                reader.Dispose();
            }

            //DBM.DBClose(Ini.strDBType);

            Process[] mProcess = Process.GetProcessesByName(Application.ProductName);
            foreach (System.Diagnostics.Process p in mProcess)
                p.Kill();

        }
        private void Search()
        {
            //listView1.Items.Clear();


            //string sql = Ini.DBSelect;
            //if (bDate)
            //{
            //    sql += string.Format(" WHERE {0} between '{1}' and '{2}' ", Ini.DBDate, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            //}
            //else
            //{
            //    sql += string.Format(" WHERE {0} between '{1}' and '{2}' ", Ini.DBPtno, tbPTNO1.Text, tbPTNO2.Text);
            //}

            //DataTable dt = DBM.DBSearch(sql, Ini.strDBType);
            //if (dt == null) return;
            //int nCol = dt.Columns.Count;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ListViewItem lvi = new ListViewItem();
            //    DataRow drow = dt.Rows[i];
            //    for (int j = 0; j < nCol; j++)
            //    {
            //        lvi.SubItems.Add(drow[j].ToString());
            //    }
            //    listView1.Items.Add(lvi);
            //}
        }

        private void btnRecord_Click(object sender, EventArgs e)
        {
            //listView1.Items.Clear();

            //string sql = Ini.DBSelect;
            ///*if (bDate)
            //{
            //    sql += string.Format(" WHERE a.pathno = c.PATHONO AND c.PATID = b.PATID and {0} between '{1}' and '{2}' ", 
            //        Ini.DBDate, dateTimePicker1.Value.ToString("yyyyMMdd"), dateTimePicker2.Value.ToString("yyyyMMdd"));
            //}
            //else
            //{
            //    sql += string.Format(" WHERE a.pathno = c.PATHONO AND c.PATID = b.PATID and {0} between '{1}' and '{2}' ", 
            //        Ini.DBPtno, tbPTNO1.Text, tbPTNO2.Text);
            //}
            //*/
            //DataTable dt = DBM.DBSearch(sql, Ini.strDBType);
            //if (dt == null) return;
            //int nCol = dt.Columns.Count;
            //for (int i = 0; i < dt.Rows.Count; i++)
            //{
            //    ListViewItem lvi = new ListViewItem();
            //    DataRow drow = dt.Rows[i];
            //    for (int j = 0; j < nCol; j++)
            //    {
            //        lvi.SubItems.Add(drow[j].ToString());
            //    }
            //    listView1.Items.Add(lvi);
            //}
        }



        //private void listView1_Click(object sender, EventArgs e)
        //{
        //    try
        //    {
        //        tbDes.Text = "";
        //        sPTNO = listView1.FocusedItem.SubItems[1].Text.ToString();
        //        sPID = listView1.FocusedItem.SubItems[2].Text.ToString();
        //        sNAME = listView1.FocusedItem.SubItems[3].Text.ToString();


        //        fileName = Ini.temppath + listView1.FocusedItem.SubItems[4].Text.ToString();

        //        rootFile = listView1.FocusedItem.SubItems[5].Text.ToString();


        //        lbName.Text = sNAME;
        //        lbPID.Text = sPID;
        //        lbPTNO.Text = sPTNO;



        //        tbDes.Text = listView1.FocusedItem.SubItems[6].Text.ToString();
        //    }
        //    catch (System.Exception ex)
        //    {

        //    }
        //}

        private void Getini()
        {
            Ini.strPath = System.Environment.CurrentDirectory + "\\Setup.ini";
            Ini.rootpath = Ini.G_IniReadValue("PATH", "ROOTPATH", Ini.strPath);
            Ini.temppath = Ini.G_IniReadValue("PATH", "TEMPPATH", Ini.strPath);
            Ini.strDB = Ini.G_IniReadValue("DB_Connection", "DBConnectionString", Ini.strPath);
            Ini.strDBType = Ini.G_IniReadValue("DB_Connection", "DBTYPE", Ini.strPath);
            Ini.DBSelect = Ini.G_IniReadValue("DB_Connection", "SELECT", Ini.strPath);
            Ini.DBDate = Ini.G_IniReadValue("DB_Connection", "DATE", Ini.strPath);
            Ini.DBPtno = Ini.G_IniReadValue("DB_Connection", "PTNO", Ini.strPath);
            Ini.DBDelete = Ini.G_IniReadValue("DB_Connection", "DELETE", Ini.strPath);
            Ini.DBUpdate = Ini.G_IniReadValue("DB_Connection", "UPDATE", Ini.strPath);
            Ini.DBInsert = Ini.G_IniReadValue("DB_Connection", "INSERT", Ini.strPath);
            Ini.strOCSDB = Ini.G_IniReadValue("OCS_Connection", "OCSConnectionString", Ini.strPath);
            Ini.OCSUpdate = Ini.G_IniReadValue("OCS_Connection", "OCSUpdate", Ini.strPath);
            Ini.strStyle = Ini.G_IniReadValue("ETC", "STYLE", Ini.strPath);

            if (Ini.temppath == "")
            {
                Ini.temppath = Application.StartupPath + "\\temp\\";
                DirectoryInfo di = new DirectoryInfo(Ini.temppath);
                if (!di.Exists) di.Create();
            }
        }

        private void ChangFormStyle(string sType)
        {
            //if (sType == "1")
            //{
            //    this.Size = new System.Drawing.Size(1111, 800);
            //    Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 35, 35));
            //    this.CenterToScreen();
            //    TopMost = false;
            //    pPlayer.Location = new Point(730, 26);
            //    pSearch.Location = new Point(12, 26);
            //    pWorkList.Location = new Point(12, 170);
            //    pWorkList.Size = new Size(361, 610);
            //    //listView1.Location = new Point(13, 179);
            //    listView1.Size = new Size(359, 590);
            //}
            //else
            //{
            //    this.Size = new System.Drawing.Size(390, 800);
            //    Region = Region.FromHrgn(CreateRoundRectRgn(0, 0, Width, Height, 35, 35));
            //    pPlayer.Location = new Point(12, 26);
            //    pSearch.Location = new Point(12, 258);
            //    pWorkList.Location = new Point(12, 391);
            //    pWorkList.Size = new Size(360, 390);
            //    //listView1.Location = new Point(13, 424);
            //    listView1.Size = new Size(359, 380);
            //    this.CenterToScreen();
            //    TopMost = true;
            //}
        }

        private void btnMax_Click(object sender, EventArgs e)
        {

        }



        /// <summary>
        /// name         : btnSend_Click
        /// desc         : Send버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-06 13:36
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSend_Click(object sender, EventArgs e)
        {
            //if (tbDes.Text.ToString() != "")
            //{
            //    try
            //    {
            //        /*
            //        string strOCSDB = "Data Source=(DESCRIPTION="
            //        + "(ADDRESS_LIST=(ADDRESS=(PROTOCOL=TCP)(HOST=192.168.0.25)(PORT=1521)))"
            //         + "(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=KUH)));"
            //          + "User Id=dis;Password=\"dis\"";
            //       */
            //        conn = new OleDbConnection(Ini.strOCSDB);
            //        try
            //        {
            //            conn.Open();
            //            // MessageBox.Show("OCS연동 성공");
            //        }
            //        catch (System.Exception ex)
            //        {
            //            string str = ex.Message;
            //            MessageBox.Show("OCS연동 실패");
            //            MessageBox.Show(ex.Message);

            //        }


            //        //String Query;
            //        //Query = Ini.OCSUpdate.Replace("[Text]", tbDes.Text.ToString());
            //        //Query = Query.Replace("[PathNo]", lbPTNO.Text);

            //        //OracleCommand cmd = new OracleCommand(Query, conn);

            //        //OracleDataReader dr = cmd.ExecuteReader();
            //        try
            //        {
            //            String Query;
            //            Query = Ini.OCSUpdate.Replace("[Text]", tbDes.Text.ToString());
            //            Query = Query.Replace("[PathNo]", lbPTNO.Text);
            //            OleDbCommand cmd = new OleDbCommand(Query, conn);

            //            cmd.ExecuteNonQuery();

            //            MessageBox.Show("EMR 전송 완료");
            //        }
            //        catch (System.Exception ex)
            //        {
            //            MessageBox.Show("EMR 전송 실패");
            //        }
            //        tbDes.Text = "";
            //        listView1.Items.Clear();
            //        lbPTNO.Text = "";
            //        lbPID.Text = "";
            //        lbName.Text = "";
            //    }
            //    catch (System.Exception ex)
            //    {
            //        MessageBox.Show(ex.Message);
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("입력된 문자가 없습니다");
            //}
        }


        /// <summary>
        /// name         : btnSave_Click
        /// desc         : 저장버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-06 13:35
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSave_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    string sql = Ini.DBUpdate + "'" + lbPTNO.Text + "'";
            //    sql = sql.Replace("[TEXT]", tbDes.Text.Replace("'", "`"));

            //    bool bRet = DBM.DBUpdate(sql, Ini.strDBType);
            //    if (bRet)
            //    {
            //        MessageBox.Show("저장 완료");
            //    }
            //    Search();
            //}
            //catch (System.Exception ex)
            //{
            //    MessageBox.Show(ex.Message);
            //}
        }


        /// <summary>
        /// name         : btnDelete_Click
        /// desc         : 삭제버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-04-06 13:35
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnDelete_Click(object sender, EventArgs e)
        {
            txtDes.Text = "";
        }


        /// <summary>
        /// name         : txtPtno1_EditValueChanged
        /// desc         : 병리번호 첫번째 텍스트 값 변경시
        /// author       : 심우종
        /// create date  : 2020-04-06 13:35
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void txtPtno1_EditValueChanged(object sender, EventArgs e)
        {
            txtPtno2.Text = txtPtno1.Text;
            chkPtno.Checked = true;
        }


        /// <summary>
        /// name         : txtPtno2_EditValueChanged
        /// desc         : 병리번호 두번째 텍스트 값 변경시
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void txtPtno2_EditValueChanged(object sender, EventArgs e)
        {
            if (txtPtno1.Text == "")
            {
                txtPtno1.Text = txtPtno2.Text;
            }
            chkPtno.Checked = true;
        }


        //private void btnDelete_MouseMove(object sender, MouseEventArgs e)
        //{
        //    this.btnDelete.BackgroundImage = global::DRSP.Properties.Resources.delete_button_02;
        //}

        //private void btnDelete_MouseLeave(object sender, EventArgs e)
        //{
        //    this.btnDelete.BackgroundImage = global::DRSP.Properties.Resources.delete_button_01;
        //}

        //private void btnSave_MouseMove(object sender, MouseEventArgs e)
        //{
        //    this.btnSave.BackgroundImage = global::DRSP.Properties.Resources.save_button_02;
        //}

        //private void btnSave_MouseLeave(object sender, EventArgs e)
        //{
        //    this.btnSave.BackgroundImage = global::DRSP.Properties.Resources.save_button_01;
        //}
        //private void btnSend_MouseLeave(object sender, EventArgs e)
        //{
        //    this.btnSend.BackgroundImage = global::DRSP.Properties.Resources.send_button_01;
        //}

        //private void btnSend_MouseMove(object sender, MouseEventArgs e)
        //{
        //    this.btnSend.BackgroundImage = global::DRSP.Properties.Resources.send_button_02;
        //}



        //private void treeView1_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        //{
        //    try
        //    {
        //        if (lbPTNO.Text == "")
        //        {
        //            MessageBox.Show("환자를 선택하세요.");
        //            return;
        //        }
        //        string sql = "select content  from description where title = '" + e.Node.Text + "'";
        //        DataTable dt = DBM.DBSearch(sql, Ini.strDBType);
        //        if (dt != null)
        //            tbDes.Text += "\r\n" + dt.Rows[0][0].ToString();
        //    }
        //    catch (System.Exception ex)
        //    {

        //    }
        //}

        private void listView1_DoubleClick(object sender, EventArgs e)
        {
            btnPlay.PerformClick();
        }

        
    }
}