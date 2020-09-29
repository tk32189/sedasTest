using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TestProject
{
    static class Program
    {
        /// <summary>
        /// 해당 애플리케이션의 주 진입점입니다.
        /// </summary>
        [STAThread]
        static void Main()
        {
            DevExpress.XtraEditors.XtraMessageBox.SmartTextWrap = true;
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Noto Sans KR Regular", 10);

            //Assembly asm = typeof(DevExpress.UserSkins.Seda20200611).Assembly;
            //DevExpress.Skins.SkinManager.Default.RegisterAssembly(asm);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
