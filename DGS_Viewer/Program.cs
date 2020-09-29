using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DGS_Viewer
{
    static class Program
    {

        
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        private static void Main(string[] args)
        {
            DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = true;
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Noto Sans KR Regular", 10);
            //DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("굴림", 10);


            if (args != null && args.Count() > 0)
            {
                Sedas.Core.SessionInfo.userId = args.ElementAt(0).ToString(); //로그인 유저 ID
            }

            string receivedPtono = "";
            if (args != null && args.Count() > 1)
            {
                receivedPtono = args.ElementAt(1).ToString(); //병리번호
            }
            //receivedPtono = "S2015596";

            //Sedas.Core.SessionInfo.userId = "00000012";
            Sedas.Core.SessionInfo.programName = "DGS_Viewer"; //프로그램 명

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            DGS_Viewer dGS_Viewer = new DGS_Viewer();
            dGS_Viewer.receivedPtono = receivedPtono;
            Application.Run(dGS_Viewer);
        }
    }
}
