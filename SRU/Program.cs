using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SRU
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = true;


            if (args != null && args.Count() > 0)
            {
                Sedas.Core.SessionInfo.userId = args.ElementAt(0).ToString(); //로그인 유저 ID
            }
            Sedas.Core.SessionInfo.programName = "SRU"; //프로그램 명


            bool isNew;
            Mutex mtx = new Mutex(true, "itSign", out isNew);
            if (isNew)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
                mtx.ReleaseMutex();
            }


            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new MainForm());
        }
    }
}
