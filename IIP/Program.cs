﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IIP
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
            DevExpress.XtraEditors.WindowsFormsSettings.DefaultFont = new Font("Noto Sans KR Regular", 9);

            if (args != null && args.Count() > 0)
            {
                Sedas.Core.SessionInfo.userId = args.ElementAt(0).ToString(); //로그인 유저 ID
            }
            //Sedas.Core.SessionInfo.userId = "00000012";
            Sedas.Core.SessionInfo.programName = "IIP"; //프로그램 명

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new IIP_Main());
        }
    }
}
