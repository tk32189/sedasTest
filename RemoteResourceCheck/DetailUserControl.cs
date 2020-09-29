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
using DevExpress.Utils.Animation;
using DevExpress.Utils;
using RemoteResourceCheck.DTO;

namespace RemoteResourceCheck
{
    public partial class DetailUserControl : DevExpress.XtraEditors.XtraUserControl
    {
        List<ComInfoDTO> cominfoList = new List<ComInfoDTO>();

        public DetailUserControl()
        {
            InitializeComponent();

            
        }

        public List<ComInfoDTO> CominfoList
        {
            get
            {
                return cominfoList;
            }

            set
            {
                cominfoList = value;
                this.RefreshComInfoChange();
            }
        }

        private void DetailUserControl_Load(object sender, EventArgs e)
        {
            InitLeftPage();
        }

        public void Start()
        {

        }

        DetailWmiGaugeUserControl detailWmiGaugeUserControl = new DetailWmiGaugeUserControl();
        TransitionManager manager;

        private void InitLeftPage()
        {

            //wmiGaugeUserControl wmiGaugeUserControl = new wmiGaugeUserControl("10.10.221.71", "", "");
            //wmiGaugeUserControl.Title = "내컴퓨터";


            
            detailWmiGaugeUserControl.Dock = DockStyle.Fill;


            //XtraUserControl transitionManagerHost = new XtraUserControl() { Dock = DockStyle.Fill };
            detailWmiGaugeUserControl.Parent = this;

            Transition transiton = new Transition();
            transiton.Control = detailWmiGaugeUserControl;
            transiton.ShowWaitingIndicator = DefaultBoolean.False;
            transiton.TransitionType = new SlideFadeTransition();
            this.manager = new TransitionManager();
            manager.Transitions.Add(transiton);
            SimpleButton button = new SimpleButton() { Text = "다음", Dock = DockStyle.Top };
            button.Parent = detailWmiGaugeUserControl;
            //Random r = new Random();
            button.Click += (sender, e) =>
            {
                RefreshComInfoChange();
            };

        }

        private void RefreshComInfoChange()
        {
            timer1.Stop();
            ComInfoChange();
            timer1.Start();
        }



        private void StartTransition()
        {
            manager.StartTransition(detailWmiGaugeUserControl);
            //detailWmiGaugeUserControl.BackColor = Color.FromArgb(r.Next(0, 255), r.Next(0, 255), r.Next(0, 255));
            manager.EndTransition();
        }

        int index = -1;

        private void timer1_Tick(object sender, EventArgs e)
        {
            //30초 타이머
            this.ComInfoChange();
        }

        private void ComInfoChange()
        {
            if (detailWmiGaugeUserControl != null && this.CominfoList != null && this.CominfoList.Count > 0)
            {
                StartTransition();

                index++;
                if (index > this.CominfoList.Count - 1)
                {
                    index = 0;
                }

                ComInfoDTO dto = this.CominfoList[index];

                detailWmiGaugeUserControl.InitComputer(dto);

            }
        }
    }
}
