using DevExpress.Utils.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileOpenExplorer
{
    public class SedasFileSystemHelper
    {
        public static FileSystemEntryCollection GetFileSystemEntries(string path, IconSizeType sizeType, Size itemSize)
        {
            FileSystemEntryCollection col = new FileSystemEntryCollection();
            InitDirectories(path, col, sizeType, itemSize);
            InitFiles(path, col, sizeType, itemSize);
            return col;
        }

        public static void InitDirectories(string path, FileSystemEntryCollection col, IconSizeType sizeType, Size itemSize)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            if (info.Exists)
            {
                DirectoryInfo[] directories = info.GetDirectories("*", SearchOption.TopDirectoryOnly);
                for (int i = 0; (i < directories.Length); i++)
                {
                    DirectoryInfo info2 = directories[i];
                    if (CheckAccess(info2) && MatchFilter(info2.Attributes))
                        col.Add(new DirectoryEntry(info2.Name, info2.FullName, GetImage(info2.FullName, sizeType, itemSize)));
                }
            }
        }

        public static void InitFiles(string path, FileSystemEntryCollection col, IconSizeType sizeType, Size itemSize)
        {
            DirectoryInfo info = new DirectoryInfo(path);
            if (info.Exists)
            {
                FileInfo[] files = info.GetFiles("*", SearchOption.TopDirectoryOnly);
                for (int i = 0; (i < files.Length); i++)
                {
                    FileInfo info2 = files[i];
                    if (MatchFilter(info2.Attributes))
                        col.Add(new FileEntry(info2.Name, info2.FullName, GetImage(info2.FullName, sizeType, itemSize)));
                }

                //col.Add(new FileEntry("test1111", "D:\\LocalData\\202005211628170(1).jpg", GetImage("D:\\LocalData\\202005211628170(1).jpg", sizeType, itemSize)));
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

        public static Image GetImage(string path, IconSizeType sizeType, Size itemSize)
        {
            return FileSystemImageCache.Cache.GetImage(path, sizeType, itemSize);
        }
    }
}
