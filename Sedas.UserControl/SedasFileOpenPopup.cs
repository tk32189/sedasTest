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
using DevExpress.Utils.Helpers;

namespace Sedas.UserControl
{
    public partial class SedasFileOpenPopup : DevExpress.XtraEditors.XtraForm
    {
        List<string> selctedFiles = null; //선택된 파일
        string selectedFolder = ""; //선택된 폴더
        PopupResult result = PopupResult.NULL; //선택결과

        string defaultPath = "";

        public enum PopupResult
        {
            YES, NO, NULL, OK
        }


        public string SelectedFolder
        {
            get { return selectedFolder; }
            set { selectedFolder = value; }
        }

        public List<string> SelctedFiles
        {
            get { return selctedFiles; }
            set { selctedFiles = value; }
        }

        public PopupResult ResultState
        {
            get { return result; }
            set { result = value; }
        }

        bool isFolderSelect = false;

        SedasFileOpen sedasFileOpen = null;
        public SedasFileOpenPopup(string defaultPath = "", bool isFolderSelect = false)
        {
            this.isFolderSelect = isFolderSelect;
            InitializeComponent();
            InitFileOpenUserControl();
        }

        public SedasFileOpenPopup(string ip, string port, string defaultPath = "", bool isFolderSelect = false)
        {
            if (!string.IsNullOrEmpty(defaultPath))
            {
                this.defaultPath = defaultPath;
            }

            this.isFolderSelect = isFolderSelect;

            InitializeComponent();
            InitFileOpenUserControl();
            //sedasFileOpen.InitServerInfo("10.10.221.71", "1111");
            sedasFileOpen.InitServerInfo(ip, port);
        }


        private void InitFileOpenUserControl()
        {
            sedasFileOpen = new SedasFileOpen();
            if (!string.IsNullOrEmpty(this.defaultPath))
            {
                sedasFileOpen.DefaultPath = this.defaultPath;
            }
            sedasFileOpen.OnFileSelectedEvent += SedasFileOpen_OnFileSelectedEvent;
            sedasFileOpen.OnFolderSelectedEvent += SedasFileOpen_OnFolderSelectedEvent;
            sedasFileOpen.IsShowPopup = true;
            sedasFileOpen.IsFolderSelectButtonVisible = this.isFolderSelect;
        }


        /// <summary>
        /// name         : SedasFileOpen_OnFolderSelectedEvent
        /// desc         : 폴더 선택 완료시
        /// author       : 심우종
        /// create date  : 2020-10-06 15:17
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SedasFileOpen_OnFolderSelectedEvent(string obj)
        {
            if (!string.IsNullOrEmpty(obj))
            {
                this.ResultState = PopupResult.OK;
                this.SelectedFolder = obj;
                this.Close();
            }
        }

        private void SedasFileOpenPopup_Load(object sender, EventArgs e)
        {
            this.tlpMain.Controls.Add(sedasFileOpen);
            sedasFileOpen.Dock = DockStyle.Fill;

        }


        /// <summary>
        /// name         : SedasFileOpen_OnFileSelectedEvent
        /// desc         : 파일 선택후 발생되는 이벤트
        /// author       : 심우종
        /// create date  : 2020-05-28 10:07
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void SedasFileOpen_OnFileSelectedEvent()
        {
            if (this.sedasFileOpen.SelectedFiles != null && this.sedasFileOpen.SelectedFiles.Count > 0)
            {
                this.ResultState = PopupResult.OK;
                this.SelctedFiles = this.sedasFileOpen.SelectedFiles;
                this.Close();
            }
            else
            {
                MessageBox.Show("선택된 파일이 없습니다.");
            }
        }

        string _currentPath;



        #region IFileSystemNavigationSupports
        //string IFileSystemNavigationSupports.CurrentPath
        //{
        //    get { return _currentPath; }
        //}
        //void IFileSystemNavigationSupports.UpdatePath(string path)
        //{

        //    BreadCrumb.Path = path;
        //    //if (this.isServer == true)
        //    //{
        //    //    this.PathChanged(path);
        //    //}

        //}
        #endregion
    }
}