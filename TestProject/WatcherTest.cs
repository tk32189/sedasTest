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
using System.IO;

namespace TestProject
{
    public partial class WatcherTest : DevExpress.XtraEditors.XtraForm
    {
        public WatcherTest()
        {
            InitializeComponent();
        }

        private void btnPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.ShowDialog();

            string selectedPath = dialog.SelectedPath;

            if (!string.IsNullOrEmpty(selectedPath))
            {
                //Global.G_IniWriteValue("OCR", "WORKING_PATH", selectedPath, Global.strSettingPath);

                this.txtPath.Text = selectedPath;
            }
        }
        private System.IO.FileSystemWatcher m_Watcher;
        private void btnStart_Click(object sender, EventArgs e)
        {
            m_Watcher = new System.IO.FileSystemWatcher();
            m_Watcher.Filter = "*.*";
            m_Watcher.Path = txtPath.Text + "\\";

            m_Watcher.IncludeSubdirectories = true;

            m_Watcher.NotifyFilter = NotifyFilters.LastAccess | NotifyFilters.LastWrite
                                     | NotifyFilters.FileName | NotifyFilters.DirectoryName;
            m_Watcher.Changed += new FileSystemEventHandler(OnChanged);
            m_Watcher.Created += new FileSystemEventHandler(OnChanged);
            m_Watcher.Deleted += new FileSystemEventHandler(OnChanged);
            //m_Watcher.Renamed += new RenamedEventHandler(OnRenamed);
            m_Watcher.EnableRaisingEvents = true;
        }


        private void OnChanged(object sender, FileSystemEventArgs e)
        {
            if (e.ChangeType == WatcherChangeTypes.Created)
            {

            }
            else if (e.ChangeType == WatcherChangeTypes.Deleted)
            {

            }


            //if (!m_bDirty)
            //{
            //    m_Sb.Remove(0, m_Sb.Length);
            //    m_Sb.Append(e.FullPath);
            //    m_Sb.Append(" ");
            //    m_Sb.Append(e.ChangeType.ToString());
            //    m_Sb.Append("    ");
            //    m_Sb.Append(DateTime.Now.ToString());
            //    m_bDirty = true;
            //}
        }


        private void WatcherTest_Load(object sender, EventArgs e)
        {
            txtPath.Text = "D:\\ServerData";
        }
    }
}