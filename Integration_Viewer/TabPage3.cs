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
using Sedas.UserControl;

namespace Integration_Viewer
{
    public partial class TabPage3 : DevExpress.XtraEditors.XtraUserControl
    {

        string ip = "10.10.50.141";
        string port = "28080";


        SedasFileOpen wave;
        SedasFileOpen image;
        SedasFileOpen dicom;
        SedasFileOpen video1;
        SedasFileOpen video2;
        SedasFileOpen snapshot;


        public TabPage3()
        {
            InitializeComponent();
        }


        /// <summary>
        /// name         : TabPage3_Load
        /// desc         : 화면 로드시
        /// author       : 심우종
        /// create date  : 2020-06-23 11:42
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void TabPage3_Load(object sender, EventArgs e)
        {
            this.InitControl();
            
        }

        

        int defaultViewStyleIndex = 4;

        private void InitControl()
        {
            if (dicom == null)
            {
                dicom = new SedasFileOpen();
                dicom.InitServerInfo(ip, port);
                dicom.IsIntegrationViewer = true;
                dicom.DefaultPath = "dicom";
                dicom.DefaultViewStyleIndex = this.defaultViewStyleIndex;

                this.tlpDicom.Controls.Add(dicom, 0, 1);
                dicom.Dock = DockStyle.Fill;

                dicom.Update();
                this.tlpDicom.Update();
            }

            if (image == null)
            {
                image = new SedasFileOpen();
                image.InitServerInfo(ip, port);
                image.IsIntegrationViewer = true;
                image.DefaultPath = "imagedata";
                image.DefaultViewStyleIndex = this.defaultViewStyleIndex;

                this.tlpImage.Controls.Add(image, 0, 1);
                image.Dock = DockStyle.Fill;

                image.Update();
                this.tlpImage.Update();
            }

            if (wave == null)
            {
                wave = new SedasFileOpen();
                wave.InitServerInfo(ip, port);
                wave.IsIntegrationViewer = true;
                wave.DefaultPath = "wave";
                wave.DefaultViewStyleIndex = this.defaultViewStyleIndex;

                this.tlpWave.Controls.Add(wave, 0, 1);
                wave.Dock = DockStyle.Fill;

                wave.Update();
                this.tlpWave.Update();
            }

            if (snapshot == null)
            {
                snapshot = new SedasFileOpen();
                snapshot.InitServerInfo(ip, port);
                snapshot.IsIntegrationViewer = true;
                snapshot.DefaultPath = "Snapshot";
                snapshot.DefaultViewStyleIndex = this.defaultViewStyleIndex;

                this.tlpSnapshot.Controls.Add(snapshot, 0, 1);
                snapshot.Dock = DockStyle.Fill;

                snapshot.Update();
                this.tlpSnapshot.Update();
            }

            if (this.video1 == null)
            {
                video1 = new SedasFileOpen();
                video1.InitServerInfo(ip, port);
                video1.IsIntegrationViewer = true;
                video1.DefaultPath = "Video";
                video1.DefaultViewStyleIndex = this.defaultViewStyleIndex;

                this.tlpVideo1.Controls.Add(video1, 0, 1);
                video1.Dock = DockStyle.Fill;

                video1.Update();
                this.tlpVideo1.Update();
            }

            if (this.video2 == null)
            {
                video2 = new SedasFileOpen();
                video2.InitServerInfo(ip, port);
                video2.IsIntegrationViewer = true;
                video2.DefaultPath = "Video2";
                video2.DefaultViewStyleIndex = this.defaultViewStyleIndex;

                this.tlpVideo2.Controls.Add(video2, 0, 1);
                video2.Dock = DockStyle.Fill;

                video2.Update();
                this.tlpVideo2.Update();
            }
        }
    }
}
