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
using Sedas.Core;
using Sedas.DB;

namespace Sedas.UserControl
{
    public partial class EmailPopup : DevExpress.XtraEditors.XtraForm
    {
        CallService callService = new CallService();

        public EmailPopup()
        {
            InitializeComponent();
        }


        /// <summary>
        /// name         : btnSend_Click
        /// desc         : 이메일을 전송한다.
        /// author       : 심우종
        /// create date  : 2020-08-27 14:21
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnSend_Click(object sender, EventArgs e)
        {
            //string m_RecvMail = "";
            //string m_SenderMail = "";
            //string m_SenderName = "";
            //string m_Title = "";
            //string m_Msg = "";
            //string m_RecvCCMail = "";




            string m_templete = "";
            m_templete += "<HTML>";
            m_templete += "    <HEAD>";
            m_templete += "        <TITLE></TITLE>";
            m_templete += "        <META content='text/html; charset=euc-kr' http-equiv=Content-Type>";
            m_templete += "        <META name=GENERATOR content=ActiveSquare>";
            m_templete += "    </HEAD>";
            m_templete += "    <BODY style='FONT-FAMILY: 맑은고딕; FONT-SIZE: 9pt'>";
            m_templete += "        <DIV align=left>";
            m_templete += "           <TABLE style='WIDTH: 100%; table-layout:fixed;'border=1 cellSpacing=0 borderColor=#7f7f7f>";
            m_templete += "              <TBODY>";
            m_templete += "                  <TR>";
            m_templete += "                      <TD style='WIDTH:100%;' height=33 width=50> test12354 </TD>";
            m_templete += "                  </TR>";
            m_templete += "                  <TR>";
            m_templete += "                      <TD style='WIDTH:100%;' border=1 height=33 width=50>";
            m_templete += "                         <img style='WIDTH:100%;' src='http://10.10.221.73:8101/TFS_UI_C_2020/images/img03.jpg' alt='Image_11'>";
            m_templete += "                         <img style='WIDTH:100%;' src='http://10.20.250.201/V/chartimg/7100/17357100.jpg' alt='Image_21'>";
            m_templete += "                      </TD>"; 
            m_templete += "                  </TR>";
            m_templete += "              </TBODY>";
            m_templete += "            </TABLE>";
            m_templete += "        </DIV>";
            m_templete += "    </BODY>";
            m_templete += "</HTML>";
            //string message = "</TD></TR></TBODY></TABLE></DIV></BODY></HTML>";
            //string message = "< HTML >< HEAD >< TITLE ></ TITLE >< META content = 'text/html; charset=euc-kr' http - equiv = Content - Type >< META name = GENERATOR content = ActiveSquare ></ HEAD >< BODY style = 'FONT-FAMILY: ����; FONT-SIZE: 10pt' >< DIV align = left >< TABLE style = 'WIDTH: 100%; table-layout:fixed;' border = 1 cellSpacing = 0 borderColor =#7f7f7f><TBODY><TR><TD style='WIDTH: 100%;' height=33 width=50>test12354</TD></TR><TR><TD style='WIDTH: 100%;' border=1 height=33 width=50><img style='WIDTH: 100%;' src='http://10.20.250.201/V/chartimg/7099/17357099.jpg' alt='Image_11'><img style='WIDTH: 100%;' src='http://10.20.250.201/V/chartimg/7100/17357100.jpg' alt='Image_21'></TD></TR></TBODY></TABLE></DIV></BODY></HTML>";

            string m_RecvMail = "tk32189@naver.com";
            string m_SenderMail = "kuh@kuh.ac.kr";
            string m_SenderName = "심우종";
            string m_Title = "테스트메일";
            string m_Msg = m_templete;
            string m_RecvCCMail = "";


            KeyValueData param = new KeyValueData();
            param.Add("Data1", m_RecvMail); //m_RecvMail
            param.Add("Data2", m_SenderMail); //m_SenderMail
            param.Add("Data3", m_SenderName); //m_SenderName
            param.Add("Data4", m_Title); //m_Title
            param.Add("Data5", m_Msg); //m_Msg
            param.Add("Data6", m_RecvCCMail); //m_RecvCCMail
            CallResultData result = this.callService.SelectSql("reqSetSendMail", param);
            if (result.resultState == ResultState.OK)
            {
                //데이터 조회 성공
                DataTable dt = result.resultData;
            }
            else
            {
                //실패에 대한 처리
            }

        }
    }
}