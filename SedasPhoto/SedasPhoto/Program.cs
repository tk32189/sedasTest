using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace SedasPhotoMagic
{
    internal static class Program
    {

        //private static void Main()
        //{
        //    //DevExpress.XtraEditors.WindowsFormsSettings.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.True;

        //    Application.EnableVisualStyles();
        //    Application.SetCompatibleTextRenderingDefault(false);
        //    Application.Run(new MainForm());
        //}

        [STAThread]
        private static void Main(string[] args)
        {
            //DevExpress.XtraEditors.WindowsFormsSettings.TouchUIMode = DevExpress.LookAndFeel.TouchUIMode.True;

            //if (args != null && args.Length > 0)
            //{
            //    MessageBox.Show(args.ElementAt(0).ToString());
            //}

            DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = true;
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Noto Sans KR Regular", 9);

            Sedas.Core.SessionInfo.programName = "Editor"; //프로그램 명

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm(args));


            
        }
    }
}
