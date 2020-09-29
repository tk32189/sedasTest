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
using DevExpress.Utils.Animation;
using DevExpress.Utils;
using RemoteResourceCheck.DTO;

namespace RemoteResourceCheck
{
    public partial class XtraForm1 : DevExpress.XtraEditors.XtraForm
    {
        public XtraForm1()
        {
            InitializeComponent();
        }

        List<ComInfoDTO> cominfoList = new List<ComInfoDTO>();


        wmiGaugeUserControl wmiGaugeUserControl;
        wmiGaugeUserControl wmiGaugeUserControl3;
        private void XtraForm1_Load(object sender, EventArgs e)
        {
            ComInfoDTO dto1 = new ComInfoDTO();
            dto1.ip = "10.10.221.71";
            dto1.name = "내컴퓨터";
            dto1.id = "";
            dto1.pw = "";
            cominfoList.Add(dto1);

            ComInfoDTO dto2 = new ComInfoDTO();
            dto2.ip = "10.10.50.141";
            dto2.name = "파일서버1";
            dto2.id = "mj2kuh";
            dto2.pw = "sJ0802$!";
            cominfoList.Add(dto2);

            ComInfoDTO dto3 = new ComInfoDTO();
            dto3.ip = "10.10.50.142";
            dto3.name = "파일서버2";
            dto3.id = "mj2kuh";
            dto3.pw = "sJ0802$!";
            cominfoList.Add(dto3);

            if (cominfoList != null && cominfoList.Count > 0)
            {
                for (int i = 0; i < cominfoList.Count; i++)
                {
                    ComInfoDTO dto = cominfoList[i];
                    wmiGaugeUserControl wmiGaugeUserControl = new wmiGaugeUserControl(dto.ip, dto.id, dto.pw);
                    wmiGaugeUserControl.Title = dto.name;
                    flwpnlMain.Controls.Add(wmiGaugeUserControl);
                }
            }


            this.InitLeftControl();
            //wmiGaugeUserControl = new wmiGaugeUserControl("10.10.221.71", "", "");
            //wmiGaugeUserControl.Title = "내컴퓨터";
            //flwpnlMain.Controls.Add(wmiGaugeUserControl);

            ////wmiGaugeUserControl wmiGaugeUserControl2 = new wmiGaugeUserControl("10.10.221.72", "", "");
            ////wmiGaugeUserControl2.Title = "컴퓨터2";
            ////flwpnlMain.Controls.Add(wmiGaugeUserControl2);

            //wmiGaugeUserControl3 = new wmiGaugeUserControl("10.10.50.141", "mj2kuh", "sJ0802$!");
            //wmiGaugeUserControl3.Title = "파일서버1";
            //flwpnlMain.Controls.Add(wmiGaugeUserControl3);

            //wmiGaugeUserControl wmiGaugeUserControl4 = new wmiGaugeUserControl("10.10.50.142", "mj2kuh", "sJ0802$!");
            //wmiGaugeUserControl4.Title = "파일서버2";
            //flwpnlMain.Controls.Add(wmiGaugeUserControl4);

            //this.detailUserControl1.CominfoList = this.cominfoList;

        }


        private DetailUserControl detailUserControl1;

        /// <summary>
        /// name         : InitLeftControl
        /// desc         : 왼쪽 상세영역 초기화
        /// author       : 심우종
        /// create date  : 2020-09-23 09:10
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void InitLeftControl()
        {
            this.detailUserControl1 = new RemoteResourceCheck.DetailUserControl();

            this.detailUserControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.detailUserControl1.Location = new System.Drawing.Point(3, 3);
            this.detailUserControl1.Name = "detailUserControl1";
            this.detailUserControl1.Size = new System.Drawing.Size(488, 773);
            this.detailUserControl1.TabIndex = 0;
            this.tlpLeft.Controls.Add(this.detailUserControl1, 0, 0);

            this.detailUserControl1.CominfoList = this.cominfoList;

        }


    }
}