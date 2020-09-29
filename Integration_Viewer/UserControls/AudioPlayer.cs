using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using NAudio.Wave;
using Integration_Viewer.Properties;

namespace Integration_Viewer
{
    public partial class AudioPlayer : DevExpress.XtraEditors.XtraUserControl
    {

        /// <summary>
        //  파일을 reader 에서 읽고 있는지 여부
        /// </summary>
        public bool IsReading { get; set; }

        /// <summary>
        /// 현재 Play 상태인지 여부
        /// </summary>
        /// 
        private bool isPlaying = false;
        public bool IsPlaying
        {
            get { return this.isPlaying; }
            set
            {
                this.isPlaying = value;
                if (IsPlaying)
                {
                    this.btnPlay.Image = Resources.icon_pause;
                }
                else
                {
                    this.btnPlay.Image = Resources.play;
                }
            }
        }

        private string totalTime = "00:00";
        public string TotalTime
        {
            get { return totalTime; }
            set
            {
                this.totalTime = value;
                this.lblTotalTime.Text = this.totalTime;
            }
        }

        private string currentTime = "00:00";
        public string CurrentTime
        {
            get { return this.currentTime; }
            set
            {
                this.currentTime = value;
                this.lblCurrentTime.Text = this.currentTime;
            }
        }

        WaveFileReader reader = null;
        WaveOut waveOut = null;

        public AudioPlayer()
        {
            InitializeComponent();

            //이벤트 정리
            InitEvents();

        }

        public void InitEvents()
        {
            this.btnFastBack.Click += BtnFastBack_Click;
            this.btnPlay.Click += BtnPlay_Click;
            this.btnStop.Click += BtnStop_Click;
            this.btnFastForward.Click += BtnFastForward_Click;
            this.gTrackBar1.Scroll += GTrackBar1_Scroll;
            this.timer1.Tick += Timer1_Tick;
            //메모리 관리
            this.Disposed += AudioPlayer_Disposed;
        }

        private void AudioPlayer_Disposed(object sender, EventArgs e)
        {
            this.AudioPlayerDispose();
        }

        public void AudioPlayerDispose()
        {
            this.AudioStop();

            if (this.reader != null)
            {
                this.reader.Dispose();
            }

            if (this.waveOut != null)
            {
                this.waveOut.Stop();
                this.waveOut.Init(reader);
                this.waveOut.Dispose();
                this.waveOut = null;
            }

            this.CurrentTime = "00:00";
            this.IsPlaying = false;
            this.IsReading = false;
            this.TotalTime = "00:00";
        }

        public bool ChangePlayObject(string path)
        {
            bool rVal = false;
            //파일 존재여부 확인
            if (new FileInfo(path).Exists)
            {
                Stream stream = new MemoryStream(File.ReadAllBytes(path));
                reader = new WaveFileReader(stream);
                //reader = new WaveFileReader(path);
                this.IsReading = true;

                this.TotalTime = reader.TotalTime.ToString().Substring(3, 5);

                int min = Convert.ToInt32(this.TotalTime.Substring(0, 2));
                int sec = Convert.ToInt32(this.TotalTime.Substring(3, 2));
                this.gTrackBar1.MaxValue = (min * 60) + sec;

                waveOut = new WaveOut();
                waveOut.Init(reader);
                reader.Position = (gTrackBar1.Value * reader.Length) / gTrackBar1.MaxValue;

                rVal = true;
            }
            return rVal;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            try
            {
                if (IsReading)
                {
                    this.CurrentTime = reader.CurrentTime.ToString().Substring(3, 5);
                    this.TotalTime = reader.TotalTime.ToString().Substring(3, 5);

                    gTrackBar1.Value = Math.Min((int)((gTrackBar1.MaxValue * reader.Position) / reader.Length), gTrackBar1.MaxValue);

                    if (gTrackBar1.Value == gTrackBar1.MaxValue)
                    {
                        this.timer1.Stop();
                        IsPlaying = false;
                        CurrentTime = "00:00";
                        //reader.Dispose();
                        //reader = null;

                        gTrackBar1.Value = gTrackBar1.MinValue;
                    }
                }
            }
            catch (System.Exception ex)
            {
                timer1.Stop();
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnFastBack_Click(object sender, EventArgs e)
        {
            try
            {
                if (reader == null)
                    return;

                if (isPlaying)
                {
                    waveOut.Pause();
                    gTrackBar1.Value = gTrackBar1.Value - 5;
                    reader.Position = (gTrackBar1.Value * reader.Length) / gTrackBar1.MaxValue;
                    waveOut.Play();
                }
                else
                {
                    gTrackBar1.Value = gTrackBar1.Value - 5;
                    reader.Position = (gTrackBar1.Value * reader.Length) / gTrackBar1.MaxValue;
                    this.CurrentTime = reader.CurrentTime.ToString().Substring(3, 5);
                }
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            //정지 -> 재생
            if (!this.IsPlaying)
            {
                this.IsPlaying = true;

                waveOut = new WaveOut();
                waveOut.Init(reader);
                reader.Position = (gTrackBar1.Value * reader.Length) / gTrackBar1.MaxValue;
                waveOut.Play();
                timer1.Start();
            }
            //재생 -> 일시정지
            else
            {
                if (waveOut != null)
                {
                    waveOut.Stop();
                    waveOut.Init(reader);
                    //waveOut.Dispose();
                    //waveOut = null;
                    timer1.Stop();
                }
                IsPlaying = false;

            }


        }

        private void BtnStop_Click(object sender, EventArgs e)
        {
            AudioStop();
        }

        private void AudioStop()
        {
            IsPlaying = false;
            this.gTrackBar1.Value = 0;
            this.CurrentTime = "00:00";

            if (waveOut != null)
            {
                waveOut.Stop();
                waveOut.Init(reader);
                //waveOut.Dispose();
                //waveOut = null;
                timer1.Stop();
            }
        }

        private void BtnFastForward_Click(object sender, EventArgs e)
        {
            try
            {
                if (reader == null)
                    return;

                if (isPlaying)
                {
                    waveOut.Pause();
                    gTrackBar1.Value = gTrackBar1.Value + 5;
                    reader.Position = (gTrackBar1.Value * reader.Length) / gTrackBar1.MaxValue;
                    waveOut.Play();
                }
                else
                {
                    gTrackBar1.Value = gTrackBar1.Value + 5;
                    reader.Position = (gTrackBar1.Value * reader.Length) / gTrackBar1.MaxValue;
                    this.CurrentTime = reader.CurrentTime.ToString().Substring(3, 5);
                }
            }
            catch (System.Exception ex)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show(ex.Message);
            }
        }

        private void GTrackBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (this.reader != null)
            {
                reader.Position = (gTrackBar1.Value * reader.Length) / gTrackBar1.MaxValue;
            }
        }
    }
}
