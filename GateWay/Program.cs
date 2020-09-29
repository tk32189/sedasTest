using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GateWay
{
    static class Program
    {
        

        static MainForm main = null;
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = true;
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Noto Sans KR Regular", 9);

            if (args != null && args.Count() > 0)
            {
                Sedas.Core.SessionInfo.userId = args.ElementAt(0).ToString(); //로그인 유저 ID
            }
            Sedas.Core.SessionInfo.programName = "GateWay"; //프로그램 명

            Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
            Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
            //AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            main = new MainForm();
            Application.Run(main);
        }

        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs t)
        {
            if (main != null)
            {
                MainForm.AddErrorLog(t.Exception.Message);
                MainForm.AddErrorLog(t.Exception.StackTrace);
                //main.AddErrorLog(t.Exception.Message);
                //main.AddErrorLog(t.Exception.StackTrace);
            }
        }

    }
}

