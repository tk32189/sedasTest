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
using DevExpress.Utils;
using DevExpress.Utils.Helpers;
using System.IO;
using DevExpress.XtraNavBar;
using DevExpress.XtraBars;
using DevExpress.Data;
using DevExpress.XtraGrid.Views.WinExplorer;
using DevExpress.XtraBars.Ribbon;
using Newtonsoft.Json;
using Sedas.Core;
using DevExpress.Utils.Svg;
using DevExpress.Utils.Drawing;

namespace FileOpenExplorer
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm, IFileSystemNavigationSupports
    {
        bool isServer = true;

        public MainForm()
        {
            InitializeComponent();
            //AutoMergeRibbon = true;
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
        void Initialize()
        {
            InitializeDefaultFolderIcons();
            InitializeBreadCrumb();
            //InitializeNavBar();
            InitializeAppearance();
            CalcPanels();
            UpdateView();
            InitControl();
        }


        DevExpress.Utils.Svg.SvgImage img1;

        private void InitControl()
        {
            
            img1 = ((DevExpress.Utils.Svg.SvgImage)(resources.GetObject("resource.SvgImage2")));
            //SvgBitmap bm = new SvgBitmap(img1);
            //Image img = SvgBitmap.Render(null, 1.0);

            DataTable viewTypeDt = new DataTable();
            viewTypeDt.Columns.Add("viewName", typeof(String));
            viewTypeDt.Columns.Add("index", typeof(String));
            viewTypeDt.Columns.Add("checked", typeof(String));

            string[] viewNameList = { "Extra large view", "Large icons", "Medium icons", "Small icons", "List", "Tiles", "Content" };
            string[] viewNameValue = { "1", "2", "3", "4", "6", "5", "7" };
            //string[] viewNameList = { "Extra large view", "Large icons", "Medium icons", "Small icons", "List", "Tiles", "Content" };
            for (int i = 0; i < viewNameList.Length; i++)
            {
                DataRow row = viewTypeDt.NewRow();
                row["viewName"] = viewNameList.ElementAt(i);
                row["index"] = viewNameValue.ElementAt(i); 
                viewTypeDt.Rows.Add(row);
            }

            grdViewType.DataSource = viewTypeDt;

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
            if (isServer == true)
            {

                this._currentPath = "serverRoot";
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
            PathChanged(e.Path);
        }
        private void PathChanged(string path)
        {
            if (isServer == true)
            {
                if (path.Length >= 10)
                {
                    if (path.Substring(0, 10) != "serverRoot")
                    {
                        path = "serverRoot" + "\\" + path;
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
            if (this.isServer == true)
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


        FileTransfer ft = new FileTransfer("10.10.221.71", "1111");



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
                if (isServer == true)
                {
                    if (!string.IsNullOrEmpty(this._currentPath) || isServer == true)
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
            using(MemoryStream memoryStream = new MemoryStream()) {
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
        void OnNavPanelLinkClicked(object sender, NavBarLinkEventArgs e)
        {
            BreadCrumb.Path = (string)e.Link.Item.Tag;
        }
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
        void OnSelectAllItemClick(object sender, ItemClickEventArgs e)
        {
            this.winExplorerView.SelectAll();
        }
        void OnSelectNoneItemClick(object sender, ItemClickEventArgs e)
        {
            this.winExplorerView.ClearSelection();
        }
        void OnInvertSelectionItemClick(object sender, ItemClickEventArgs e)
        {
            for (int i = 0; i < this.winExplorerView.RowCount; i++) this.winExplorerView.InvertRowSelection(i);
        }
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
            UpdateButtons();
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
            //if (e.MouseInfo.Button == MouseButtons.Right) itemPopupMenu.ShowPopup(Cursor.Position);
        }
        void OnWinExplorerViewItemDoubleClick(object sender, WinExplorerViewItemDoubleClickEventArgs e)
        {
            if (e.MouseInfo.Button != MouseButtons.Left) return;
            winExplorerView.ClearSelection();

            if (isServer == true)
            {
                //FileSystemEntry entry = ((FileSystemEntry)e.ItemInfo.Row.RowKey);
                //string lastValue = entry.Path.Split('\\').Last();


                ((FileSystemEntry)e.ItemInfo.Row.RowKey).DoAction(this);
            }
            else
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

        System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));

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

            switch (e.Column.Name)
            {
                case "view":  //
                    if (grvViewType.GetDataRow(e.RowHandle)["checked"].ToString() == "Y") 
                    {
                        e.Appearance.BackColor = Color.FromArgb(255, 226, 234, 253);
                    }
                    break;
                                        //e.Appearance.BackColor = Color.FromArgb(0xCB, 0xE6, 0xCB);
            }
                

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
    }
}