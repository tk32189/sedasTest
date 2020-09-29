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
using System.Diagnostics;
using System.IO;

namespace TestProject
{
    public partial class MainTest : DevExpress.XtraEditors.XtraForm
    {
        public MainTest()
        {
            InitializeComponent();
        }

        private void hSimpleButton1_Click(object sender, EventArgs e)
        {
            string param1 = @"C:\SEDAS\IIP\IIP.exe";
            string logId = "00000012";
            this.ExecTest(param1, logId);
        }

        private void hSimpleButton2_Click(object sender, EventArgs e)
        {
            //viewer
            string param1 = @"C:\SEDAS\DGS_Viewer\DGS_Viewer.exe";
            string logId = "00000012";
            this.ExecTest(param1, logId);
        }

        private void ExecTest(string runExe, string logId)
        {
            using (Process compiler = new Process())
            {
                string path = @"C:\SEDAS\SedasLauncher\SedasLauncher.exe";
                string param1 = runExe;
                string param2 = logId;
                FileInfo file = new FileInfo(path);

                compiler.StartInfo.FileName = path;
                string arg = string.Format("\"{0}\" {1}", runExe, logId);
                compiler.StartInfo.Arguments = arg;
                //compiler.StartInfo.Arguments = "\"" + jsonValue + "\"" ;

                compiler.StartInfo.UseShellExecute = false;
                compiler.StartInfo.RedirectStandardOutput = true;
                compiler.StartInfo.WorkingDirectory = file.DirectoryName;
                compiler.Start();

                Console.WriteLine(compiler.StandardOutput.ReadToEnd());
            }


            //runExe : 실행파일의 절대경로, 실행파일이 위치하는 폴더명(ex:IIP)과 서버에 올린 폴더명이 동일해야 다운로드 가능합니다.
            //logId : 로그인 ID를 2번째 파라미터로 넘기면 각 화면별로 다시 그대로 전달합니다.
            //string runExe = @"C:\SEDAS\IIP\IIP.exe";
            //string logId = "00000012";

            //using (Process compiler = new Process())
            //{
            //    string path = @"C:\SEDAS\SedasLauncher\SedasLauncher.exe";
            //    FileInfo file = new FileInfo(path);

            //    compiler.StartInfo.FileName = path;
            //    string arg = string.Format("\"{0}\" {1}", runExe, logId);
            //    compiler.StartInfo.Arguments = arg;
            //    //compiler.StartInfo.Arguments = "\"" + jsonValue + "\"" ;

            //    compiler.StartInfo.UseShellExecute = false;
            //    compiler.StartInfo.RedirectStandardOutput = true;
            //    compiler.StartInfo.WorkingDirectory = file.DirectoryName;
            //    compiler.Start();

            //    Console.WriteLine(compiler.StandardOutput.ReadToEnd());
            //}
        }
    }
}