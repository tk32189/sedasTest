using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using DevExpress.Utils.Helpers;
using DevExpress.Utils;
using Sedas.Core;
using System.IO;
using DevExpress.XtraBars;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.WinExplorer;
using Newtonsoft.Json;
using System.Drawing.Drawing2D;
using DevExpress.LookAndFeel;

namespace Sedas.UserControl
{
    public partial class SedasFileOpen : DevExpress.XtraEditors.XtraUserControl, IFileSystemNavigationSupports
    {

        /// <summary>
        /// 옵션으로 받을수 있는 값 정리
        /// </summary>
        FileTransfer ft = null; // new FileTransfer("10.10.50.142", "28080");
        bool isServer = false;
        bool isShowPopup = true; //팝업으로 화면이 열리는 경우
        bool isFileManagement = false; //파일관리 화면에서 사용되는 경우 
        bool isIntegrationViewer = false; //통합뷰어 화면에서 사용되는 경우

        int defaultViewStyleIndex = 5; //기본 아이콘 스타일 인덱스
        string defaultPath = ""; //처음 시작할 path경로
        bool isLimitedStartPath = false; //서버 시작경로를 특정 위치 이상 벗어날수 없도록 하기위한 플래그

        List<string> selectedFiles = new List<string>();

        public event Action OnFileSelectedEvent;
        bool isInitControl = false; //최초 컨트롤 초기화중인지를 나타내는 플래그

        public SedasFileOpen()
        {
            InitializeComponent();
        }



        /// <summary>
        /// name         : InitServerInfo
        /// desc         : 서버용 탐색기로 적용하기 위해서 해당 메소드 호출필요
        /// author       : 심우종
        /// create date  : 2020-05-28 10:06
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void InitServerInfo(string ip, string port)
        {
            this.ft = new FileTransfer(ip, port);
            this.IsServer = true;
        }


        //static ExplorerView()
        //{
        //    FileSystemImageCache.Cache.EnableFileIconCaching = false;
        //}

        string _currentPath;


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Initialize();
        }



        /// <summary>
        /// name         : ReConnect
        /// desc         : 서버 재접속 처리
        /// author       : 심우종
        /// create date  : 
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void ReConnect(string ip, string port)
        {
            this.ft = new FileTransfer(ip, port);
            this.IsServer = true;
            Initialize();
        }


        void Initialize()
        {
            this.isInitControl = true;
            InitializeDefaultFolderIcons();
            InitializeBreadCrumb();
            //InitializeNavBar();
            InitializeAppearance();
            CalcPanels();
            UpdateView();

            
            InitControl();
            this.isInitControl = false;
        }


        DevExpress.Utils.Svg.SvgImage img1;

        private void InitControl()
        {

            //img1 = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage2")));
            //SvgBitmap bm = new SvgBitmap(img1);
            //Image img = SvgBitmap.Render(null, 1.0);

            DataTable viewTypeDt = new DataTable();
            viewTypeDt.Columns.Add("viewName", typeof(String));
            viewTypeDt.Columns.Add("index", typeof(String));
            viewTypeDt.Columns.Add("checked", typeof(String));

            string[] viewNameList = { "Extra large view", "Large icons", "Medium icons", "Small icons", "List", "Tiles", "Content" };
            string[] viewNameValue = { "1", "2", "3", "4", "6", "5", "7" };
            //string[] viewNameList = { "Extra large view", "Large icons", "Medium icons", "Small icons", "List", "Tiles", "Content" };

            int selectedIndex = 0;
            for (int i = 0; i < viewNameList.Length; i++)
            {
                DataRow row = viewTypeDt.NewRow();
                row["viewName"] = viewNameList.ElementAt(i);
                row["index"] = viewNameValue.ElementAt(i);
                viewTypeDt.Rows.Add(row);

                if (!string.IsNullOrEmpty(DefaultViewStyleIndex.ToString()))
                {
                    if (DefaultViewStyleIndex.ToString() == viewNameValue.ElementAt(i).ToString())
                    {
                        selectedIndex = i;
                    }
                }

            }

            

            grdViewType.DataSource = viewTypeDt;
            grvViewType.ClearSelection();
            grvViewType.FocusedRowHandle = selectedIndex;
            grvViewType.SetFocusedRowModified();

            WinExplorerViewStyle _viewStyle = (WinExplorerViewStyle)Enum.Parse(typeof(WinExplorerViewStyle), DefaultViewStyleIndex.ToString());

            //타일을 기본 형태로 지정
            winExplorerView.OptionsView.Style = _viewStyle;


            //파일관리 화면용 설정
            if (isFileManagement == true)
            {
                //체크박스 보이도록
                this.chkCheckBoxVisible.Visible = false;
                //this.winExplorerView.OptionsView.ShowCheckBoxes = true;

                if (IsServer == true)
                {
                    this.btnCreatFolder.Visible = true;//새폴더 생성 버튼
                }
                else
                {
                    this.btnCreatFolder.Visible = false;//새폴더 생성 버튼
                }

            }
            else if (this.IsIntegrationViewer == true)
            {
                this.tlpTop.ColumnStyles[2].Width = 0F;
                this.tlpCenter.ColumnStyles[1].Width = 0F;
            }
            else
            {
                this.btnCreatFolder.Visible = false;//새폴더 생성 버튼
            }

        }

        void InitializeDefaultFolderIcons()
        {
            //groupFavorites.ImageOptions.SmallImage = FileSystemHelper.GetImage(Environment.GetFolderPath(Environment.SpecialFolder.Favorites), IconSizeType.Small, FolderIconSize);
            //navPanelItemDesktop.ImageOptions.SmallImage = FileSystemHelper.GetImage(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), IconSizeType.Small, FolderIconSize);
            //navPanelItemDownloads.ImageOptions.SmallImage = FileSystemHelper.GetImage(FileSystemHelper.GetDownloadsDir(), IconSizeType.Small, FolderIconSize);
            //navPanelItemRecent.ImageOptions.SmallImage = FileSystemHelper.GetImage(Environment.GetFolderPath(Environment.SpecialFolder.Recent), IconSizeType.Small, FolderIconSize);

            //groupLibraries.ImageOptions.SmallImage = FileSystemHelper.GetImage(Environment.GetFolderPath(Environment.SpecialFolder.MyComputer), IconSizeType.Small, FolderIconSize);
            //navPanelItemDocuments.ImageOptions.SmallImage = FileSystemHelper.GetImage(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), IconSizeType.Small, FolderIconSize);
            //navPanelItemPictures.ImageOptions.SmallImage = FileSystemHelper.GetImage(Environment.GetFolderPath(Environment.SpecialFolder.MyPictures), IconSizeType.Small, FolderIconSize);
            //navPanelItemVideos.ImageOptions.SmallImage = FileSystemHelper.GetImage(Environment.GetFolderPath(Environment.SpecialFolder.MyVideos), IconSizeType.Small, FolderIconSize);
            //navPanelItemMusic.ImageOptions.SmallImage = FileSystemHelper.GetImage(Environment.GetFolderPath(Environment.SpecialFolder.MyMusic), IconSizeType.Small, FolderIconSize);
        }
        Size FolderIconSize
        {
            get { return new Size(ScaleUtils.ScaleValue(16), ScaleUtils.ScaleValue(16)); }
        }
        void InitializeBreadCrumb()
        {
            if (IsServer == true)
            {
                if (this.editBreadCrumb.Properties.Nodes.Count() > 0)
                {
                    this.editBreadCrumb.Properties.Nodes.Clear();
                }

                if (!string.IsNullOrEmpty(this.DefaultPath))
                {
                    this._currentPath = this.DefaultPath;
                }
                else
                {
                    this._currentPath = "serverRoot";
                }

                if (!string.IsNullOrEmpty(DefaultPath))
                {
                    if (DefaultPath.Length > 10 && this.DefaultPath.Substring(0, 10) == "serverRoot")
                    {
                        //시작 경로가 serverRoot로 시작하지 않으면 해당 플래그 지정
                        this.isLimitedStartPath = false;
                    }
                    else
                    {
                        this.isLimitedStartPath = true;
                    }
                }
                


                BreadCrumb.Path = this._currentPath;
                //foreach (DriveInfo driveInfo in FileSystemHelper.GetFixedDrives())
                //{
                //    BreadCrumb.Properties.History.Add(new BreadCrumbHistoryItem(driveInfo.RootDirectory.ToString()));
                //}

                

            }
            else
            {
                this._currentPath = StartupPath;
                BreadCrumb.Path = this._currentPath;
                foreach (DriveInfo driveInfo in FileSystemHelper.GetFixedDrives())
                {
                    BreadCrumb.Properties.History.Add(new BreadCrumbHistoryItem(driveInfo.RootDirectory.ToString()));
                }
            }

        }
        void InitializeAppearance()
        {
            //GalleryItem item = rgbiViewStyle.Gallery.GetCheckedItem();
            //if (item != null)
            //    this.winExplorerView.OptionsView.Style = (WinExplorerViewStyle)item.Tag;
        }
        void OnBreadCrumbPathChanged(object sender, BreadCrumbPathChangedEventArgs e)
        {
            if (isInitControl == true)
                return;

            PathChanged(e.Path);
        }
        private void PathChanged(string path)
        {
            if (IsServer == true)
            {
                //제한된 path를 사용하는 경우에는 serverRoot를 추가하지 말자.
                if (this.isLimitedStartPath == false)
                {
                    if (path.Length >= 10)
                    {
                        if (path.Substring(0, 10) != "serverRoot")
                        {
                            path = "serverRoot" + "\\" + path;
                        }
                    }
                }
                
            }

            this._currentPath = path;
            UpdateView();
            UpdateButtons();
        }

        void OnBreadCrumbNewNodeAdding(object sender, BreadCrumbNewNodeAddingEventArgs e)
        {
            e.Node.PopulateOnDemand = true;
        }
        void OnBreadCrumbQueryChildNodes(object sender, BreadCrumbQueryChildNodesEventArgs e)
        {
            if (e.Node.Caption == "Root")
            {
                InitBreadCrumbRootNode(e.Node);
                return;
            }
            if (e.Node.Caption == "Computer")
            {
                InitBreadCrumbComputerNode(e.Node);
                return;
            }
            string dir = e.Node.Path;
            if (!FileSystemHelper.IsDirExists(dir))
                return;
            string[] subDirs = FileSystemHelper.GetSubFolders(dir);
            for (int i = 0; i < subDirs.Length; i++)
            {
                e.Node.ChildNodes.Add(CreateNode(subDirs[i]));
            }
        }
        void InitBreadCrumbRootNode(BreadCrumbNode node)
        {
            node.ChildNodes.Add(new BreadCrumbNode("Desktop", Environment.GetFolderPath(Environment.SpecialFolder.Desktop)));
            node.ChildNodes.Add(new BreadCrumbNode("Documents", Environment.GetFolderPath(Environment.SpecialFolder.Recent)));
            node.ChildNodes.Add(new BreadCrumbNode("Music", Environment.GetFolderPath(Environment.SpecialFolder.MyMusic)));
            node.ChildNodes.Add(new BreadCrumbNode("Pictures", Environment.GetFolderPath(Environment.SpecialFolder.MyPictures)));
            node.ChildNodes.Add(new BreadCrumbNode("Video", Environment.GetFolderPath(Environment.SpecialFolder.MyVideos)));
            node.ChildNodes.Add(new BreadCrumbNode("Program Files", Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles)));
            node.ChildNodes.Add(new BreadCrumbNode("Windows", Environment.GetFolderPath(Environment.SpecialFolder.Windows)));
        }
        void InitBreadCrumbComputerNode(BreadCrumbNode node)
        {
            foreach (DriveInfo driveInfo in FileSystemHelper.GetFixedDrives())
            {
                node.ChildNodes.Add(new BreadCrumbNode(driveInfo.Name, driveInfo.RootDirectory));
            }
        }
        void OnBreadCrumbValidatePath(object sender, BreadCrumbValidatePathEventArgs e)
        {
            if (this.IsServer == true)
            {
                e.ValidationResult = BreadCrumbValidatePathResult.CreateNodes;
            }
            else
            {
                if (!FileSystemHelper.IsDirExists(e.Path))
                {
                    e.ValidationResult = BreadCrumbValidatePathResult.Cancel;
                    return;
                }
                e.ValidationResult = BreadCrumbValidatePathResult.CreateNodes;
            }


        }
        void OnBreadCrumbRootGlyphClick(object sender, EventArgs e)
        {
            BreadCrumb.Properties.BreadCrumbMode = BreadCrumbMode.Edit;
            BreadCrumb.SelectAll();
        }
        BreadCrumbNode CreateNode(string path)
        {
            string folderName = FileSystemHelper.GetDirName(path);
            return new BreadCrumbNode(folderName, folderName, true);
        }
        protected string StartupPath { get { return Environment.GetFolderPath(Environment.SpecialFolder.Desktop); } }

        public static Image GetImage(string path, IconSizeType sizeType, Size itemSize)
        {
            return FileSystemImageCache.Cache.GetImage(path, sizeType, itemSize);
        }







        void UpdateView()
        {
            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;





            //try
            //{
            //    if (!string.IsNullOrEmpty(this._currentPath))
            //        gridControl.DataSource = FileSystemHelper.GetFileSystemEntries(this._currentPath, GetItemSizeType(ViewStyle), GetItemSize(ViewStyle));
            //    else
            //        gridControl.DataSource = null;
            //    winExplorerView.RefreshData();
            //    EnsureSearchEdit();
            //    BeginInvoke(new MethodInvoker(winExplorerView.ClearSelection));
            //}
            //finally
            //{
            //    Cursor.Current = oldCursor;
            //}



            //return;

            try
            {
                if (IsServer == true)
                {
                    if (!string.IsNullOrEmpty(this._currentPath) || IsServer == true)
                    {
                        FileSystemEntryCollection col = new FileSystemEntryCollection();

                        IconSizeType iconSizeType = GetItemSizeType(ViewStyle);
                        Size size = GetItemSize(ViewStyle);


                        string paramIcon = "3";
                        string paramSize = "16";

                        if (iconSizeType == IconSizeType.ExtraLarge)
                        {
                            paramIcon = "1";
                        }
                        else if (iconSizeType == IconSizeType.Large)
                        {
                            paramIcon = "2";
                        }
                        else if (iconSizeType == IconSizeType.Medium)
                        {
                            paramIcon = "3";
                        }
                        else if (iconSizeType == IconSizeType.Small)
                        {
                            paramIcon = "4";
                        }

                        paramSize = size.Width.ToString();


                        //string path = "D:\\LocalData\\";
                        //string path = this._currentPath;

                        string path = "\\";
                        if (string.IsNullOrEmpty(_currentPath) || _currentPath == "serverRoot" || _currentPath == "serverRoot\\")
                        {
                            path = "\\";
                        }
                        else
                        {
                            string tempPath = _currentPath;
                            if (_currentPath.Length > 10)
                            {
                                if (_currentPath.Substring(0, 10) == "serverRoot")
                                {
                                    tempPath = _currentPath.Substring(11, _currentPath.Length - 11);
                                }
                            }

                            path = "\\" + tempPath;
                        }


                        //path = "W:\\";
                        //소켓방식으로 파일정보 리턴
                        string jsonValue = ft.ExplorerInfo(path, paramIcon, paramSize);


                        string[] splValue = jsonValue.Split('|');

                        if (splValue.Count() != 2)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("파일 정보 조회에 실패하였습니다.");
                            return;
                        }


                        if (true)
                        {
                            DataTable reDt = JsonConvert.DeserializeObject<DataTable>(splValue.ElementAt(0));
                            DataTable imageDt = JsonConvert.DeserializeObject<DataTable>(splValue.ElementAt(1));

                            if (reDt != null && reDt.Rows.Count > 0)
                            {
                                for (int i = 0; i < reDt.Rows.Count; i++)
                                {
                                    DataRow row = reDt.Rows[i];

                                    DataRow imageRow = imageDt.AsEnumerable().Where(e => e["imageCode"].ToString() == row["image"].ToString()).FirstOrDefault();

                                    if (imageRow != null)
                                    {
                                        if (row["type"].ToString() == "D")
                                        {
                                            col.Add(new DirectoryEntry(row["name"].ToString(), row["fullName"].ToString(), stringToImage(imageRow["imageValue"].ToString())));
                                        }
                                        else if (row["type"].ToString() == "F")
                                        {
                                            col.Add(new FileEntry(row["name"].ToString(), row["fullName"].ToString(), stringToImage(imageRow["imageValue"].ToString())));
                                        }
                                    }
                                }
                            }
                            gridControl.DataSource = col;

                        }
                        else
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show("파일 정보 조회에 실패하였습니다.");
                            return;
                        }
                    }
                    else
                    {
                        gridControl.DataSource = null;
                    }

                    winExplorerView.RefreshData();
                    EnsureSearchEdit();
                    BeginInvoke(new MethodInvoker(winExplorerView.ClearSelection));
                }
                else
                {
                    try
                    {
                        if (!string.IsNullOrEmpty(this._currentPath))
                            gridControl.DataSource = FileSystemHelper.GetFileSystemEntries(this._currentPath, GetItemSizeType(ViewStyle), GetItemSize(ViewStyle));
                        else
                            gridControl.DataSource = null;
                        winExplorerView.RefreshData();
                        EnsureSearchEdit();
                        BeginInvoke(new MethodInvoker(winExplorerView.ClearSelection));
                    }
                    finally
                    {
                        Cursor.Current = oldCursor;
                    }
                }


            }
            finally
            {
                Cursor.Current = oldCursor;
            }

            // gridControl.DataSource = SedasFileSystemHelper.GetFileSystemEntries("C:\\Users\\tk321\\OneDrive\\", IconSizeType.Medium, new Size(32, 32));






            //return;


            //DataTable dt = new DataTable();
            //dt.Columns.Add("type", typeof(String));
            //dt.Columns.Add("name", typeof(String));
            //dt.Columns.Add("fullName", typeof(String));
            //dt.Columns.Add("image", typeof(String));







            //IconSizeType sizeType = IconSizeType.Medium;
            //Size itemSize = new Size(32, 32);


            ////디렉토리
            //DirectoryInfo info = new DirectoryInfo(path);
            //if (info.Exists)
            //{
            //    DirectoryInfo[] directories = info.GetDirectories("*", SearchOption.TopDirectoryOnly);
            //    for (int i = 0; (i < directories.Length); i++)
            //    {
            //        DirectoryInfo info2 = directories[i];
            //        if (CheckAccess(info2) && MatchFilter(info2.Attributes))
            //        {
            //            DataRow row = dt.NewRow();
            //            row["type"] = "D";
            //            row["name"] = info2.Name;
            //            row["fullName"] = info2.FullName;
            //            row["image"] = imageToString(GetImage(info2.FullName, sizeType, itemSize));

            //            dt.Rows.Add(row);
            //        }
            //    }
            //}



            ////파일
            //if (info.Exists)
            //{
            //    FileInfo[] files = info.GetFiles("*", SearchOption.TopDirectoryOnly);
            //    for (int i = 0; (i < files.Length); i++)
            //    {
            //        FileInfo info2 = files[i];
            //        if (MatchFilter(info2.Attributes))
            //        {
            //            //col.Add(new FileEntry(info2.Name, info2.FullName, GetImage(info2.FullName, sizeType, itemSize)));
            //            DataRow row = dt.NewRow();
            //            row["type"] = "F";
            //            row["name"] = info2.Name;
            //            row["fullName"] = info2.FullName;
            //            row["image"] = imageToString(GetImage(info2.FullName, sizeType, itemSize));

            //            dt.Rows.Add(row);
            //        }

            //    }

            //}

            //string jsonValue = JsonConvert.SerializeObject(dt);











            return;



        }


        public static bool CheckAccess(DirectoryInfo info)
        {
            bool hasAccess = false;
            try
            {
                info.GetAccessControl();
                hasAccess = true;
            }
            catch
            {
            }
            return hasAccess;
        }


        public static bool MatchFilter(FileAttributes attributes)
        {
            return ((attributes & (FileAttributes.System | FileAttributes.Hidden)) == 0);
        }


        private Image stringToImage(string base64String)
        {
            byte[] imageBytes = Convert.FromBase64String(base64String);
            // Convert byte[] to Image
            using (var ms = new MemoryStream(imageBytes, 0, imageBytes.Length))
            {
                Image image = Image.FromStream(ms, true);
                return image;
            }
        }

        private string imageToString(Image image)
        {
            string strImage = "";
            using (MemoryStream memoryStream = new MemoryStream())
            {
                image.Save(memoryStream, System.Drawing.Imaging.ImageFormat.Png);

                byte[] bitmapByte = memoryStream.ToArray();
                strImage = Convert.ToBase64String(bitmapByte);
            }
            return strImage;
        }


        void EnsureSearchEdit()
        {
            EditSearch.Properties.NullValuePrompt = "Search " + FileSystemHelper.GetDirName(this._currentPath);
            EditSearch.EditValue = null;
            this.winExplorerView.FindFilterText = string.Empty;
        }
        //void OnNavPanelLinkClicked(object sender, NavBarLinkEventArgs e)
        //{
        //    BreadCrumb.Path = (string)e.Link.Item.Tag;
        //}
        //void OnShowNavPaneItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    BarCheckItem item = (BarCheckItem)e.Item;
        //    this.liNavPaneRight.Visibility = item.Checked ? LayoutVisibility.Always : LayoutVisibility.Never;
        //    this.navBar.Visible = item.Checked;
        //}
        //void OnShowFavoritesItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    this.groupFavorites.Visible = ((BarCheckItem)e.Item).Checked;
        //}
        //void OnShowLibrariesItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    groupLibraries.Visible = ((BarCheckItem)e.Item).Checked;
        //}
        //void OnShowCheckBoxesItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        //{
        //    this.winExplorerView.OptionsView.ShowCheckBoxes = ((BarCheckItem)e.Item).Checked;
        //}
        //void InitializeNavBar()
        //{
        //    navPanelItemDesktop.Tag = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
        //    navPanelItemRecent.Tag = Environment.GetFolderPath(Environment.SpecialFolder.Recent);
        //    navPanelItemDocuments.Tag = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        //    navPanelItemMusic.Tag = Environment.GetFolderPath(Environment.SpecialFolder.MyMusic);
        //    navPanelItemPictures.Tag = Environment.GetFolderPath(Environment.SpecialFolder.MyPictures);
        //    navPanelItemVideos.Tag = Environment.GetFolderPath(Environment.SpecialFolder.MyVideos);
        //    navPanelItemDownloads.Tag = FileSystemHelper.GetDownloadsDir();
        //    if (navPanelItemDownloads.Tag == null) navPanelItemDownloads.Visible = false;
        //}
        //void OnViewStyleGalleryItemCheckedChanged(object sender, GalleryItemEventArgs e)
        //{
        //    GalleryItem item = e.Item;
        //    if (!item.Checked) return;
        //    WinExplorerViewStyle _viewStyle = (WinExplorerViewStyle)Enum.Parse(typeof(WinExplorerViewStyle), item.Tag.ToString());
        //    this.winExplorerView.OptionsView.Style = _viewStyle;
        //    FileSystemImageCache.Cache.ClearCache();
        //    UpdateView();
        //}
        //void OnRgbiViewStyleInitDropDown(object sender, InplaceGalleryEventArgs e)
        //{
        //    e.PopupGallery.SynchWithInRibbonGallery = true;
        //}
        void OnEditSearchTextChanged(object sender, EventArgs e)
        {
            this.winExplorerView.FindFilterText = EditSearch.Text;
        }
        //void OnSelectAllItemClick(object sender, ItemClickEventArgs e)
        //{
        //    this.winExplorerView.SelectAll();
        //}
        //void OnSelectNoneItemClick(object sender, ItemClickEventArgs e)
        //{
        //    this.winExplorerView.ClearSelection();
        //}
        //void OnInvertSelectionItemClick(object sender, ItemClickEventArgs e)
        //{
        //    for (int i = 0; i < this.winExplorerView.RowCount; i++) this.winExplorerView.InvertRowSelection(i);
        //}
        void OnShowFileNameExtensionsCheckItemClick(object sender, ItemClickEventArgs e)
        {
            FileSystemEntryCollection col = gridControl.DataSource as FileSystemEntryCollection;
            if (col == null) return;
            col.ShowExtensions = ((BarCheckItem)e.Item).Checked;
            gridControl.RefreshDataSource();
        }
        void OnShowHiddenItemsCheckItemClick(object sender, ItemClickEventArgs e)
        {
            //btnHideSelectedItems.Enabled = !((BarCheckItem)e.Item).Checked;
        }
        void OnHelpButtonItemClick(object sender, ItemClickEventArgs e)
        {
            //StartApplicationHelper.ShowHelp();
        }
        void OnOptionsItemClick(object sender, ItemClickEventArgs e)
        {
            IEnumerable<FileSystemEntry> entries = GetSelectedEntries();
            if (entries.Count() == 0)
            {
                FileSystemHelper.ShellExecuteFileInfo(this._currentPath, ShellExecuteInfoFileType.Properties);
                return;
            }
            foreach (FileSystemEntry entry in entries) entry.ShowProperties();
        }
        void OnWinExplorerViewSelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            List<string> selectedFile = GetSelectedFilesNew(isFileAdd: true, isFolderAdd: false);

            if (selectedFile != null && selectedFile.Count == 1)
            {
                ViewThumbnail(selectedFile.ElementAt(0));
            }


            UpdateButtons();
        }


        /// <summary>
        /// name         : viewThumbnail
        /// desc         : 선택한 파일에 대한 섬네일을 불러온다
        /// author       : 심우종
        /// create date  : 2020-06-01 16:33
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ViewThumbnail(string pathAndName)
        {
            picturethumbnail.Image = null;
            if (!string.IsNullOrEmpty(pathAndName))

            {
                bool isImage = false;
                int lastIndexDot = pathAndName.LastIndexOf('.');

                if (lastIndexDot > 0)
                {
                    string fileType = pathAndName.Substring(lastIndexDot + 1, pathAndName.Length - lastIndexDot - 1);

                    switch (fileType.ToLower())
                    {
                        case "jpeg":
                        case "jpg":
                        case "png": 
                        case "icon":
                        case "gif": 
                        case "bmp": 
                        case "tiff":
                        case "emf": 
                        case "wmf":
                            isImage = true;
                            break;
                    }
                }

                if (isImage == true)
                {
                    if (isServer == true)
                    {
                        string value = ft.ImageThumbnail(pathAndName);

                        if (!string.IsNullOrEmpty(value))
                        {
                            Image img = stringToImage(value);
                            picturethumbnail.Image = img;
                        }

                    }
                    else
                    {
                        Image.GetThumbnailImageAbort callback =
                                new Image.GetThumbnailImageAbort(ThumbnailCallback);
                        Image image = new Bitmap(pathAndName);
                        Image pThumbnail = image.GetThumbnailImage(150, 150, callback, new IntPtr());
                        picturethumbnail.Image = pThumbnail;
                    }
                }
                
            }

        }

        public bool ThumbnailCallback()
        {
            return true;
        }

        void OnCopyPathItemClick(object sender, ItemClickEventArgs e)
        {
            StringBuilder builder = new StringBuilder();
            foreach (FileSystemEntry entry in GetSelectedEntries())
            {
                builder.AppendLine(entry.Path);
            }
            if (!string.IsNullOrEmpty(builder.ToString())) Clipboard.SetText(builder.ToString());
        }
        void OnOpenItemClick(object sender, ItemClickEventArgs e)
        {
            foreach (FileSystemEntry entry in GetSelectedEntries(true))
            {
                entry.DoAction(this);
            }
        }
        void OnWinExplorerViewKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            FileSystemEntry entry = GetSelectedEntries().LastOrDefault();
            if (entry != null) entry.DoAction(this);
        }
        void OnWinExplorerViewItemClick(object sender, WinExplorerViewItemClickEventArgs e)
        {
            if (e.MouseInfo.Button == MouseButtons.Right) itemPopupMenu.ShowPopup(Cursor.Position);


            if (this.IsFileManagement == true)
            {

                if (e.ItemInfo != null && e.ItemInfo.Row != null && e.ItemInfo.Row.RowKey != null)
                {
                    if (e.ItemInfo.Row.RowKey is FileEntry)
                    {
                        if ((e.ItemInfo.Row.RowKey as FileEntry).IsCheck == true)
                        {
                            (e.ItemInfo.Row.RowKey as FileEntry).IsCheck = false;
                        }
                        else
                        {
                            (e.ItemInfo.Row.RowKey as FileEntry).IsCheck = true;
                        }

                        gridControl.RefreshDataSource();

                    }
                }

                //IEnumerable<FileSystemEntry> entries = GetSelectedEntries();

                //if (entries.Count() == 1)
                //{
                //    if (entries.ElementAt(0).IsCheck == true)
                //    {
                //        entries.ElementAt(0).IsCheck = false;
                //    }
                //    else
                //    {
                //        entries.ElementAt(0).IsCheck = true;
                //    }
                //    gridControl.RefreshDataSource();
                //}
            }

        }








        /// <summary>
        /// name         : ClearSelection
        /// desc         : 체크박스를 클리어한다.
        /// author       : 심우종
        /// create date  : 2020-05-29 09:03
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void ClearSelection()
        {
            FileSystemEntryCollection col = gridControl.DataSource as FileSystemEntryCollection;

            if (col != null)
            {
                for (int i = 0; i < col.Count; i++)
                {
                    if (col.ElementAt(i).IsCheck == true)
                    {
                        col.ElementAt(i).IsCheck = false;
                    }
                }
            }

            gridControl.RefreshDataSource();
        }

        void OnWinExplorerViewItemDoubleClick(object sender, WinExplorerViewItemDoubleClickEventArgs e)
        {
            if (e.MouseInfo.Button != MouseButtons.Left) return;
            winExplorerView.ClearSelection();
            bool needToDoAction = false;
            if (IsServer == true)
            {
                //FileSystemEntry entry = ((FileSystemEntry)e.ItemInfo.Row.RowKey);
                //string lastValue = entry.Path.Split('\\').Last();

                if (((FileSystemEntry)e.ItemInfo.Row.RowKey).ToString() == "DevExpress.Utils.Helpers.FileEntry")
                {
                    //파일
                    //아무일도 일어나지 않도록 수정
                    needToDoAction = false;

                    //팝업인 경우
                    if (IsShowPopup == true)
                    {
                        //해당 파일 정보 리턴
                        if (SelectedFiles == null)
                        {
                            SelectedFiles = new List<string>();
                        }

                        SelectedFiles.Clear();
                        string path = ((FileSystemEntry)e.ItemInfo.Row.RowKey).Path;
                        SelectedFiles.Add(path);

                        //파일선택 이벤트 전달
                        if (this.OnFileSelectedEvent != null)
                        {
                            this.OnFileSelectedEvent();
                        }
                    }
                }
                else if (((FileSystemEntry)e.ItemInfo.Row.RowKey).ToString() == "DevExpress.Utils.Helpers.DirectoryEntry")
                {
                    //폴더
                    needToDoAction = true;
                }
            }
            else
            {
                needToDoAction = true;
            }

            if (needToDoAction == true)
            {
                ((FileSystemEntry)e.ItemInfo.Row.RowKey).DoAction(this);
            }




        }
        void UpdateButtons()
        {
            int selEntriesCount = GetSelectedEntries().Count();
            //this.btnOpen.Enabled = this.btnCopyItem.Enabled = selEntriesCount > 0;
            this.btnUpTo.Enabled = BreadCrumb.CanGoUp;
            this.btnBack.Enabled = BreadCrumb.CanGoBack;
            this.btnForward.Enabled = BreadCrumb.CanGoForward;
        }
        void OnBackButtonClick(object sender, EventArgs e)
        {
            BreadCrumb.GoBack();
        }
        void OnNextButtonClick(object sender, EventArgs e)
        {
            BreadCrumb.GoForward();
        }
        void OnUpButtonClick(object sender, EventArgs e)
        {
            BreadCrumb.GoUp();
        }
        void OnNavigationMenuButtonClick(object sender, EventArgs e)
        {
            //navigationMenu.ItemLinks.Clear();
            //navigationMenu.ItemLinks.AddRange(GetNavigationHistroryItems().ToArray());
            //navigationMenu.ShowPopup(PointToScreen(new Point(0, navigationPanel.Bottom)));
        }
        IEnumerable<BarItem> GetNavigationHistroryItems()
        {
            BreadCrumbHistory history = BreadCrumb.GetNavigationHistory();
            for (int i = history.Count - 1; i >= 0; i--)
            {
                BreadCrumbHistoryItem item = history[i];
                BarCheckItem menuItem = new BarCheckItem();
                menuItem.Tag = i;
                menuItem.Caption = FileSystemHelper.GetDirName(item.Path);
                menuItem.ItemClick += OnNavigationMenuItemClick;
                menuItem.Checked = BreadCrumb.GetNavigationHistoryCurrentItemIndex() == i;
                yield return menuItem;
            }
        }
        void OnNavigationMenuItemClick(object sender, ItemClickEventArgs e)
        {
            BreadCrumb.SetNavigationHistoryCurrentItemIndex(Convert.ToInt32(e.Item.Tag));
            UpdateButtons();
        }
        List<FileSystemEntry> GetSelectedEntries() { return GetSelectedEntries(false); }
        List<FileSystemEntry> GetSelectedEntries(bool sort)
        {
            List<FileSystemEntry> list = new List<FileSystemEntry>();
            int[] rows = winExplorerView.GetSelectedRows();
            for (int i = 0; i < rows.Length; i++)
            {
                list.Add((FileSystemEntry)winExplorerView.GetRow(rows[i]));
            }
            if (sort) list.Sort(new FileSytemEntryComparer());
            return list;
        }
        Size GetItemSize(WinExplorerViewStyle viewStyle)
        {
            switch (viewStyle)
            {
                case WinExplorerViewStyle.ExtraLarge: return new Size(256, 256);
                case WinExplorerViewStyle.Large: return new Size(96, 96);
                case WinExplorerViewStyle.Content: return new Size(32, 32);
                case WinExplorerViewStyle.Small: return new Size(16, 16);
                case WinExplorerViewStyle.Tiles:
                case WinExplorerViewStyle.Default:
                case WinExplorerViewStyle.List:
                case WinExplorerViewStyle.Medium:
                default: return new Size(96, 96);
            }
        }
        IconSizeType GetItemSizeType(WinExplorerViewStyle viewStyle)
        {
            switch (viewStyle)
            {
                case WinExplorerViewStyle.Large:
                case WinExplorerViewStyle.ExtraLarge: return IconSizeType.ExtraLarge;
                case WinExplorerViewStyle.List:
                case WinExplorerViewStyle.Small: return IconSizeType.Small;
                case WinExplorerViewStyle.Tiles:
                case WinExplorerViewStyle.Medium:
                case WinExplorerViewStyle.Content: return IconSizeType.Large;
                default: return IconSizeType.ExtraLarge;
            }
        }
        void CalcPanels()
        {
            //this.navigationPanel.Location = Point.Empty;
            //this.contentPanel.Location = new Point(0, this.navigationPanel.Bottom - 1);
            //this.contentPanel.Height = Height - this.navigationPanel.Height + 1;
        }
        public BreadCrumbEdit BreadCrumb { get { return editBreadCrumb; } }
        public WinExplorerViewStyle ViewStyle { get { return this.winExplorerView.OptionsView.Style; } }

        #region IFileSystemNavigationSupports
        string IFileSystemNavigationSupports.CurrentPath
        {
            get { return _currentPath; }
        }

        public List<string> SelectedFiles
        {
            get { return selectedFiles; }
            set { selectedFiles = value; }
        }

        public bool IsShowPopup
        {
            get
            {
                return isShowPopup;
            }

            set
            {
                isShowPopup = value;
            }
        }

        public bool IsServer
        {
            get
            {
                return isServer;
            }

            set
            {
                isServer = value;
            }
        }

        public bool IsFileManagement
        {
            get
            {
                return isFileManagement;
            }

            set
            {
                isFileManagement = value;
            }
        }

        public bool IsIntegrationViewer
        {
            get
            {
                return isIntegrationViewer;
            }

            set
            {
                isIntegrationViewer = value;
            }
        }

        public int DefaultViewStyleIndex
        {
            get
            {
                return defaultViewStyleIndex;
            }

            set
            {
                defaultViewStyleIndex = value;
            }
        }

        public string DefaultPath
        {
            get
            {
                return defaultPath;
            }

            set
            {
                defaultPath = value;

            }
        }

        void IFileSystemNavigationSupports.UpdatePath(string path)
        {
            BreadCrumb.Path = path;
            //if (this.isServer == true)
            //{
            //    this.PathChanged(path);
            //}

        }
        #endregion

        #region ReportGeneration
        //public override bool AllowGenerateReport { get { return false; } }
        #endregion

        //System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));

        /// <summary>
        /// name         : grvViewType_CustomDrawCell
        /// desc         : grvViewType CustondrawCell이벤트
        /// author       : 심우종
        /// create date  : 2020-05-26 14:24
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void grvViewType_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {
            //img1

            //switch (e.Column.Name)
            //{
            //    case "view":  //
            //        if (grvViewType.GetDataRow(e.RowHandle)["checked"].ToString() == "Y")
            //        {
            //            e.Appearance.BackColor =  Color.FromArgb(255, 226, 234, 253);
            //        }
            //        break;
            //        //e.Appearance.BackColor = Color.FromArgb(0xCB, 0xE6, 0xCB);
            //}


            //try
            //{
            //    var palette = SvgPaletteHelper.GetSvgPalette(this.LookAndFeel, ObjectState.Normal);
            //    // Produce and draw a raster image
            //    // The image size matches the current system DPI value
            //    e.Cache.DrawImage(img1.Render(palette), Point.Empty);
            //}
            //catch { }


        }

        

        private void grvViewType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (this.isInitControl == true)
                return;


            DataRow selectedRow = grvViewType.GetFocusedDataRow();
            if (selectedRow != null)
            {
                DataTable dt = grdViewType.DataSource as DataTable;

                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    if (dt.Rows[i] == selectedRow)
                    {
                        dt.Rows[i]["checked"] = "Y";
                    }
                    else
                    {
                        dt.Rows[i]["checked"] = "N";
                    }
                }

                WinExplorerViewStyle _viewStyle = (WinExplorerViewStyle)Enum.Parse(typeof(WinExplorerViewStyle), selectedRow["index"].ToString().ToString());
                this.winExplorerView.OptionsView.Style = _viewStyle;
                FileSystemImageCache.Cache.ClearCache();
                UpdateView();
            }
        }


        /// <summary>
        /// name         : chkCheckBoxVisible_CheckedChanged
        /// desc         : 체크박스 보이기 옵션
        /// author       : 심우종
        /// create date  : 2020-05-26 15:34
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void chkCheckBoxVisible_CheckedChanged(object sender, EventArgs e)
        {
            this.winExplorerView.OptionsView.ShowCheckBoxes = chkCheckBoxVisible.Checked;
        }

        private void chkShowFileNameExtension_CheckedChanged(object sender, EventArgs e)
        {
            FileSystemEntryCollection col = gridControl.DataSource as FileSystemEntryCollection;
            if (col == null) return;
            col.ShowExtensions = chkShowFileNameExtension.Checked;
            gridControl.RefreshDataSource();
        }



        /// <summary>
        /// name         : GetSelectedFiles
        /// desc         : 현재 선택된 파일정보를 넘긴다.
        /// author       : 심우종
        /// create date  : 2020-05-28 17:15
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public List<string> GetSelectedFiles()
        {
            List<string> selectedFiles = new List<string>();
            FileSystemEntryCollection col = gridControl.DataSource as FileSystemEntryCollection;

            if (col != null)
            {
                for (int i = 0; i < col.Count; i++)
                {
                    if (col.ElementAt(i).ToString() == "DevExpress.Utils.Helpers.FileEntry")
                    {
                        if (col.ElementAt(i).IsCheck == true)
                        {
                            selectedFiles.Add(col.ElementAt(i).Path);
                        }
                    }
                }
            }

            return selectedFiles;
        }


        /// <summary>
        /// name         : GetCurrentPath
        /// desc         : 현재 선택된 경로를 리턴한다.
        /// author       : 심우종
        /// create date  : 2020-05-29 08:30
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public string GetCurrentPath()
        {
            return _currentPath;
        }


        /// <summary>
        /// name         : GetSelectedFilesNew
        /// desc         : 현재 선택된 파일정보를 넘긴다.
        /// author       : 심우종
        /// create date  : 2020-05-28 17:15
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public List<string> GetSelectedFilesNew(bool isFileAdd, bool isFolderAdd)
        {
            IEnumerable<FileSystemEntry> entries = GetSelectedEntries();
            List<string> selectedFiles = new List<string>();

            if (entries != null && entries.Count() > 0)
            {
                for (int i = 0; i < entries.Count(); i++)
                {
                    FileSystemEntry file = entries.ElementAt(i);

                    //파일만 추가
                    if (isFileAdd == true)
                    {
                        if (file.ToString() == "DevExpress.Utils.Helpers.FileEntry")
                        {
                            selectedFiles.Add(file.Path);
                        }
                    }

                    //폴더만 추가
                    if (isFolderAdd == true)
                    {
                        if (file.ToString() == "DevExpress.Utils.Helpers.DirectoryEntry")
                        {
                            selectedFiles.Add(file.Path);
                        }
                    }

                }
            }

            return selectedFiles;
        }


        /// <summary>
        /// name         : Refresh
        /// desc         : 재조회
        /// author       : 심우종
        /// create date  : 2020-05-29 08:53
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        public void FileRefresh()
        {
            //재조회
            UpdateView();
        }

        /// <summary>
        /// name         : ContextItemRename_ItemClick
        /// desc         : 이름변경 클릭시
        /// author       : 심우종
        /// create date  : 2020-05-29 13:28
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ContextItemRename_ItemClick(object sender, ItemClickEventArgs e)
        {

            List<string> selectedFile = GetSelectedFilesNew(isFileAdd: true, isFolderAdd: false);
            List<string> selectedFolder = GetSelectedFilesNew(isFileAdd: false, isFolderAdd: true);

            if (selectedFile.Count() + selectedFolder.Count() == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("변경이 필요한 파일 또는 폴더를 선택해 주세요");
                return;
            }


            if (selectedFile.Count() + selectedFolder.Count() > 1)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("변경이 필요한 파일 또는 폴더를 하나만 선택해 주세요");
                return;
            }


            if (isServer == true)
            {

                string newName = "";
                //신규이름을 받는 팝업 호출
                ReNamePopup renamePopup = new ReNamePopup();
                renamePopup.ShowDialog();
                if (renamePopup.ResultStat == "Y")
                {
                    newName = renamePopup.ResultValue;
                }
                else
                {
                    return;
                }

                if (selectedFile.Count() > 0)
                {
                    string filePath = selectedFile.ElementAt(0);
                    

                    

                    if (filePath.Split('.').Length >= 2)
                    {
                        //확장자
                        string lastName = filePath.Split('.').LastOrDefault();

                        //신규이름이 따로 확장자를 주지 않은 경우 기존 확장자 유지
                        if (newName.Contains(".") == false && !string.IsNullOrEmpty(lastName))
                        {
                            newName = newName + "." + lastName;
                        }
                    }

                    if (ft.NameChange(filePath, newName, "F") == true)
                    { 
                        //성공
                    }

                }

                // 2. 디렉토리 이름을 변경하는 경우
                if (selectedFolder.Count() > 0)
                {
                    string folderName = selectedFolder.ElementAt(0);

                    if (ft.NameChange(folderName, newName, "D") == true)
                    {
                        //성공
                    }

                }
            }
            else
            {

                //1. 파일은 변경하는 경우
                if (selectedFile.Count() > 0)
                {
                    string filePath = selectedFile.ElementAt(0);

                    ClientNameChang(filePath, "F");
                }

                // 2. 디렉토리 이름을 변경하는 경우
                if (selectedFolder.Count() > 0)
                {
                    string folderName = selectedFolder.ElementAt(0);

                    ClientNameChang(folderName, "D");
                }



            }

            this.FileRefresh();
        }


        /// <summary>
        /// name         : NameChang
        /// desc         : 파일/폴더 이름 변경
        /// author       : 심우종
        /// create date  : 2020-05-29 14:22
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ClientNameChang(string paramPath, string type)
        {
            //string filePath = selectedFile.ElementAt(0);


            string newName = "";

            //신규이름을 받는 팝업 호출
            ReNamePopup renamePopup = new ReNamePopup();
            renamePopup.ShowDialog();
            if (renamePopup.ResultStat == "Y")
            {
                newName = renamePopup.ResultValue;
            }
            else
            {
                return;
            }

            if (type == "F") //파일인 경우에만
            {
                if (paramPath.Split('.').Length >= 2)
                {
                    //확장자
                    string lastName = paramPath.Split('.').LastOrDefault();

                    //신규이름이 따로 확장자를 주지 않은 경우 기존 확장자 유지
                    if (newName.Contains(".") == false && !string.IsNullOrEmpty(lastName))
                    {
                        newName = newName + "." + lastName;
                    }
                }


                FileInfo fileInfo = new FileInfo(paramPath);


                //체크1 : 파일이 존재하는 확인필요
                string newFilePath = fileInfo.Directory + "\\" + newName;
                FileInfo newFileInfo = new FileInfo(newFilePath);

                if (newFileInfo.Exists == true)
                {
                    //이미 파일이 존재하는 경우
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미 동일한 파일이 존재합니다. 다른이름으로 변경해 주세요");
                    return;
                }

                string newPath = Path.Combine(fileInfo.DirectoryName, newName);
                fileInfo.MoveTo(newPath);
            }
            else if (type == "D")
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(paramPath);
                //string lastPath = directoryInfo.FullName.Split('\\').LastOrDefault();
                string pathName = directoryInfo.FullName.Substring(0, directoryInfo.FullName.Length - directoryInfo.Name.Length);

                string newPath = pathName + newName;

                DirectoryInfo newDirInfo = new DirectoryInfo(newPath);
                if (newDirInfo.Exists == true)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("이미 동일한 폴더가 존재합니다. 다른이름으로 변경해 주세요");
                    return;
                }

                Directory.Move(paramPath, newPath);

            }
        }


        /// <summary>
        /// name         : ContextItemDelete_ItemClick
        /// desc         : 삭제 클릭시
        /// author       : 심우종
        /// create date  : 2020-05-29 16:17
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void ContextItemDelete_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<string> selectedFile = GetSelectedFilesNew(isFileAdd: true, isFolderAdd: false);
            List<string> selectedFolder = GetSelectedFilesNew(isFileAdd: false, isFolderAdd: true);

            if (selectedFile.Count() + selectedFolder.Count() == 0)
            {
                DevExpress.XtraEditors.XtraMessageBox.Show("삭제할 파일 또는 폴더를 선택해 주세요");
                return;
            }

            if (DevExpress.XtraEditors.XtraMessageBox.Show("정말 삭제하시겠습니까?", "확인", MessageBoxButtons.YesNo) == DialogResult.No)
            {
                return;
            }

            if (isServer == true)
            {
                //1. 파일을 삭제하는 경우
                if (selectedFile.Count() > 0)
                {
                    for (int i = 0; i < selectedFile.Count; i++)
                    {
                        string filePath = selectedFile.ElementAt(i);

                        if (ft.DeleteFile(filePath) == false)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(filePath + "파일 삭제에 실패하였습니다.");
                        }
                    }
                }


                // 2. 디렉토리를 삭제하는 경우
                if (selectedFolder.Count() > 0)
                {
                    for (int i = 0; i < selectedFolder.Count; i++)
                    {
                        string folderName = selectedFolder.ElementAt(i);

                        if (ft.FileCheckInFolder(folderName) == true)
                        {
                            if (DevExpress.XtraEditors.XtraMessageBox.Show(folderName + " 폴더안에 파일이 존재합니다. 모두 삭제하시겠습니까?", "확인", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                //PASS
                            }
                            else
                            {
                                continue;
                            }
                        }

                        if (ft.DeleteFolder(folderName) == false)
                        {
                            DevExpress.XtraEditors.XtraMessageBox.Show(folderName + " 폴더 삭제에 실패하였습니다.");
                        }
                    }

                }


            }
            else
            {

                //1. 파일을 삭제하는 경우
                if (selectedFile.Count() > 0)
                {
                    for (int i = 0; i < selectedFile.Count; i++)
                    {
                        string filePath = selectedFile.ElementAt(i);

                        FileInfo oFileInfo = new FileInfo(filePath);
                        if (oFileInfo.Exists == true)
                        {
                            oFileInfo.Delete();
                        }
                    }
                }

                // 2. 디렉토리를 삭제하는 경우
                if (selectedFolder.Count() > 0)
                {
                    for (int i = 0; i < selectedFolder.Count; i++)
                    {
                        string folderName = selectedFolder.ElementAt(i);

                        DirectoryInfo di = new DirectoryInfo(folderName);

                        if (di.Exists)
                        {
                            //폴더안에 파일 체크
                            if (this.isFiles(folderName) == true)
                            {
                                if (DevExpress.XtraEditors.XtraMessageBox.Show(folderName + " 폴더안에 파일이 존재합니다. 모두 삭제하시겠습니까?", "확인", buttons: MessageBoxButtons.YesNo) == DialogResult.Yes)
                                {
                                    //PASS
                                }
                                else
                                {
                                    continue;
                                }
                            }

                            
                            di.Delete(true); //true 넣으면 파일 존재시에도 모두 삭제
                        }
                    }

                }
            }

            this.FileRefresh();
        }

        private bool isFiles(string dir)
        {
            string[] directories = Directory.GetDirectories(dir);

            string[] files = Directory.GetFiles(dir);
            if (files.Length != 0) return true;

            if (directories != null && directories.Count() > 0)
            {
                foreach (string nodeDir in directories)
                {
                    if (isFiles(nodeDir) == true)
                    {
                        return true;
                    }
                }
            }

            return false;
        }


        /// <summary>
        /// name         : btnCreatFolder_Click
        /// desc         : 새폴더 만들기 버튼 클릭시
        /// author       : 심우종
        /// create date  : 2020-06-01 08:57
        /// update date  : 최종 수정일자 , 수정자, 수정개요
        /// </summary> 
        private void btnCreatFolder_Click(object sender, EventArgs e)
        {
            if (isServer == true)
            {
                string currentPath = GetCurrentPath();

                if (_currentPath.Length > 10)
                {
                    if (currentPath.Substring(0, 10) == "serverRoot")
                    {
                        currentPath = currentPath.Substring(11, currentPath.Length - 11);
                    }
                }

                if (ft.CreateFolder(currentPath) == false)
                {
                    DevExpress.XtraEditors.XtraMessageBox.Show("폴더 생성에 실패하였습니다.");
                }
               
            }

            this.FileRefresh();
        }

        private void SedasFileOpen_Load(object sender, EventArgs e)
        {
            this.LookAndFeel.SetSkinStyle(SkinSvgPalette.DefaultSkin.BlueDark);
        }
    }

}
