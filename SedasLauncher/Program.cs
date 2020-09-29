using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SedasLauncher
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        //static void Main()
        //{
        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    //Application.Run(new Form1());

        //    SedasLauncher sedasLauncher = new SedasLauncher();
        //    sedasLauncher.Start();
        //}

        private static void Main(string[] args)
        {

            //if (args != null && args.Length > 0)
            //{
            //    MessageBox.Show(args.ElementAt(0).ToString());
            //}

            DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = true;

            Sedas.Core.SessionInfo.programName = "SedasLauncher"; //프로그램 명



            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            SedasLauncher sedasLauncher = new SedasLauncher();

            if (args != null && args.Length > 0)
            {
                sedasLauncher.FilePathAndName = args.ElementAt(0).ToString();

                if (args.Length > 1)
                {
                    sedasLauncher.LoginId = args.ElementAt(1).ToString();
                }

            }

            
            sedasLauncher.Start();
        }
    }
}
