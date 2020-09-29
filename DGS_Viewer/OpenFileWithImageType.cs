using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using DevExpress.XtraPrinting;
using System.Text;
using System.Collections.Generic;

namespace DGS_Viewer
{
    public class OpenFileWithImageType
    {
        private delegate int OFNHookProcDelegate(int hdlg, int msg, int wParam, int lParam);

        private int m_LabelHandle = 0;
        private int m_ComboHandle = 0;
        private int m_radioHandle1 = 0;
        private int m_radioHandle2 = 0;
        private int m_radioHandle3 = 0;

        private string m_Filter = "";
        private string m_DefaultExt = "";
        private List<string> files = new List<string>();

        private string m_FileName = "";

        private EncodingType m_EncodingType;
        public int imageType = 0;
        private Screen m_ActiveScreen;

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        private struct OPENFILENAME
        {
            public int lStructSize;
            public IntPtr hwndOwner;
            public int hInstance;
            [MarshalAs(UnmanagedType.LPTStr)] public string lpstrFilter;
            [MarshalAs(UnmanagedType.LPTStr)] public string lpstrCustomFilter;
            public int nMaxCustFilter;
            public int nFilterIndex;
            [MarshalAs(UnmanagedType.LPTStr)] public string lpstrFile;
            //public char[] lpstrFile;

            //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 2048)] public string lpstrFile;
            public int nMaxFile;
            [MarshalAs(UnmanagedType.LPTStr)] public string lpstrFileTitle;
            public int nMaxFileTitle;
            [MarshalAs(UnmanagedType.LPTStr)] public string lpstrInitialDir;
            [MarshalAs(UnmanagedType.LPTStr)] public string lpstrTitle;
            public int Flags;
            public short nFileOffset;
            public short nFileExtension;
            [MarshalAs(UnmanagedType.LPTStr)] public string lpstrDefExt;
            public int lCustData;
            public OFNHookProcDelegate lpfnHook;
            [MarshalAs(UnmanagedType.LPTStr)] public string lpTemplateName;
            //only if on nt 5.0 or higher
            public int pvReserved;
            public int dwReserved;
            public int FlagsEx;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public class OpenFileName
        {
            public int structSize = 0;
            public IntPtr dlgOwner = IntPtr.Zero;
            public IntPtr instance = IntPtr.Zero;

            public String filter = null;
            public String customFilter = null;
            public int maxCustFilter = 0;
            public int filterIndex = 0;

            public String file = null;
            public int maxFile = 0;

            public String fileTitle = null;
            public int maxFileTitle = 0;

            public String initialDir = null;

            public String title = null;

            public int flags = 0;
            public short fileOffset = 0;
            public short fileExtension = 0;

            public String defExt = null;

            public IntPtr custData = IntPtr.Zero;
            public IntPtr hook = IntPtr.Zero;

            public String templateName = null;

            public IntPtr reservedPtr = IntPtr.Zero;
            public int reservedInt = 0;
            public int flagsEx = 0;
        }

        [DllImport("Comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GetSaveFileName(ref OPENFILENAME lpofn);


        [DllImport("Comdlg32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool GetOpenFileName(ref OPENFILENAME lpofn);

        //[DllImport("Comdlg32.dll", CharSet = CharSet.Auto)]
        //private static extern bool GetOpenFileName([In, Out] OpenFileName lpofn);


        [DllImport("Comdlg32.dll")]
        private static extern int CommDlgExtendedError();

        [DllImport("user32.dll")]
        private static extern bool SetWindowPos(int hWnd, int hWndInsertAfter, int X, int Y, int cx, int cy, uint uFlags);

        private struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        private struct POINT
        {
            public int X;
            public int Y;
        }

        private struct NMHDR
        {
            public int HwndFrom;
            public int IdFrom;
            public int Code;
        }

        [DllImport("user32.dll")]
        private static extern bool GetWindowRect(int hWnd, ref RECT lpRect);

        [DllImport("user32.dll")]
        private static extern int GetParent(int hWnd);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern bool SetWindowText(int hWnd, string lpString);

        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int SendMessage(int hWnd, int Msg, int wParam, string lParam);

        [DllImport("user32")]
        public static extern Int32 SendMessage(IntPtr hWnd, Int32 uMsg, IntPtr WParam, IntPtr LParam);

        [DllImport("user32.dll")]
        private static extern bool DestroyWindow(int hwnd);

        private const int OFN_ENABLEHOOK = 0x00000020;
        private const int OFN_EXPLORER = 0x00080000;
        private const int OFN_FILEMUSTEXIST = 0x00001000;
        private const int OFN_HIDEREADONLY = 0x00000004;
        private const int OFN_CREATEPROMPT = 0x00002000;
        private const int OFN_NOTESTFILECREATE = 0x00010000;
        private const int OFN_OVERWRITEPROMPT = 0x00000002;
        private const int OFN_PATHMUSTEXIST = 0x00000800;
        private const int OFN_ALLOWMULTISELECT = 0x00000200;  // 512;
        private const int OFN_LONGNAMES = 0x00200000;
        private const int OFN_NODEREFERENCELINKS = 0x100000;




        private const int SWP_NOSIZE = 0x0001;
        private const int SWP_NOMOVE = 0x0002;
        private const int SWP_NOZORDER = 0x0004;

        private const int WM_INITDIALOG = 0x110;
        private const int WM_DESTROY = 0x2;
        private const int WM_SETFONT = 0x0030;
        private const int WM_GETFONT = 0x0031;
        private const int WM_LBUTTONDOWN = 0x0201;

        private const int CBS_DROPDOWNLIST = 0x0003;
        private const int CBS_HASSTRINGS = 0x0200;
        private const int CB_ADDSTRING = 0x0143;
        private const int CB_SETCURSEL = 0x014E;
        private const int CB_GETCURSEL = 0x0147;

        private const uint WS_VISIBLE = 0x10000000;
        private const uint WS_CHILD = 0x40000000;
        private const uint WS_TABSTOP = 0x00010000;
        private const uint WS_GROUP = 0x00020000;

        private const uint BS_RADIOBUTTON = 0x00000004;
        private const uint BS_AUTORADIOBUTTON = 0x00000009;

        private const int CDM_GETFILEPATH = 1125;



        private const int CDN_FILEOK = -606;
        private const int WM_NOTIFY = 0x004E;
        private const int BN_CLICKED = 245;
        private const uint WM_COMMAND = 0x0111;




        private const int BM_GETCHECK = 0x00F0;

        //0x00F0

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int GetDlgItem(int hDlg, int nIDDlgItem);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int CreateWindowEx(int dwExStyle, string lpClassName, string lpWindowName, uint dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int hMenu, int hInstance, int lpParam);


        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int CreateWindow(string lpClassName, string lpWindowName, uint dwStyle, int x, int y, int nWidth, int nHeight, int hWndParent, int hMenu, int hInstance, int lpParam);


        [DllImport("user32.dll")]
        private static extern bool ScreenToClient(int hWnd, ref POINT lpPoint);

        private int HookProc(int hdlg, int msg, int wParam, int lParam)
        {
            switch (msg)
            {
                case WM_INITDIALOG:

                    //we need to centre the dialog
                    Rectangle sr = m_ActiveScreen.Bounds;
                    RECT cr = new RECT();
                    int parent = GetParent(hdlg);
                    GetWindowRect(parent, ref cr);

                    int x = (sr.Right + sr.Left - (cr.Right - cr.Left)) / 2;
                    int y = (sr.Bottom + sr.Top - (cr.Bottom - cr.Top)) / 2;

                    SetWindowPos(parent, 0, x, y, cr.Right - cr.Left, cr.Bottom - cr.Top + 32, SWP_NOZORDER);


                    //we need to find the label to position our new label under

                    int fileTypeWindow = GetDlgItem(parent, 0x441);

                    RECT aboveRect = new RECT();
                    GetWindowRect(fileTypeWindow, ref aboveRect);

                    //now convert the label's screen co-ordinates to client co-ordinates
                    POINT point = new POINT();
                    point.X = aboveRect.Left;
                    point.Y = aboveRect.Bottom;

                    ScreenToClient(parent, ref point);

                    //create the label
                    int labelHandle = CreateWindowEx(0, "STATIC", "mylabel", WS_VISIBLE | WS_CHILD | WS_TABSTOP, point.X, point.Y + 12, 200, 100, parent, 0, 0, 0);
                    SetWindowText(labelHandle, "&파일종류:");

                    int fontHandle = SendMessage(fileTypeWindow, WM_GETFONT, 0, 0);
                    SendMessage(labelHandle, WM_SETFONT, fontHandle, 0);

                    //we now need to find the combo-box to position the new combo-box under

                    int fileComboWindow = GetDlgItem(parent, 0x470);
                    aboveRect = new RECT();
                    GetWindowRect(fileComboWindow, ref aboveRect);

                    point = new POINT();
                    point.X = aboveRect.Left;
                    point.Y = aboveRect.Bottom;
                    ScreenToClient(parent, ref point);

                    POINT rightPoint = new POINT();
                    rightPoint.X = aboveRect.Right;
                    rightPoint.Y = aboveRect.Top;

                    ScreenToClient(parent, ref rightPoint);

                    //we create the new combobox


                    m_radioHandle1 = CreateWindowEx(0, "BUTTON", "Gross", WS_CHILD | WS_VISIBLE |
                                BS_AUTORADIOBUTTON,
                                point.X, point.Y + 8, 80, 20, parent, 0, 0, 0);
                    SendMessage(m_radioHandle1, WM_SETFONT, fontHandle, 0);

                    m_radioHandle2 = CreateWindowEx(0, "BUTTON", "Micro", WS_CHILD | WS_VISIBLE |
                                BS_AUTORADIOBUTTON,
                                point.X + 80, point.Y + 8, 80, 20, parent, 0, 0, 0);
                    SendMessage(m_radioHandle2, WM_SETFONT, fontHandle, 0);

                    m_radioHandle3 = CreateWindowEx(0, "BUTTON", "Order", WS_CHILD | WS_VISIBLE |
                                BS_AUTORADIOBUTTON,
                                point.X + 160, point.Y + 8, 80, 20, parent, 0, 0, 0);
                    SendMessage(m_radioHandle3, WM_SETFONT, fontHandle, 0);

                    SendMessage(m_radioHandle1, BN_CLICKED, 0, 0);

                    //WS_GROUP

                    //int comboHandle = CreateWindowEx(0, "ComboBox", "mycombobox", WS_VISIBLE | WS_CHILD | CBS_HASSTRINGS | CBS_DROPDOWNLIST | WS_TABSTOP, point.X, point.Y + 8, rightPoint.X - point.X, 100, parent, 0, 0, 0);
                    //SendMessage(comboHandle, WM_SETFONT, fontHandle, 0);

                    ////and add the encodings we want to offer
                    //SendMessage(comboHandle, CB_ADDSTRING, 0, "UTF-8");
                    //SendMessage(comboHandle, CB_ADDSTRING, 0, "UTF-8 with preamble");
                    //SendMessage(comboHandle, CB_ADDSTRING, 0, "Unicode");
                    //SendMessage(comboHandle, CB_ADDSTRING, 0, "ANSI");

                    //SendMessage(comboHandle, CB_SETCURSEL, (int)m_EncodingType, 0);

                    //remember the handles of the controls we have created so we can destroy them after
                    m_LabelHandle = labelHandle;
                    //m_ComboHandle = comboHandle;

                    break;
                    //case WM_COMMAND:
                    //	if (HIWORD(wParam) == BN_CLICKED)
                    //	{ 

                    //	}
                    break;
                case WM_DESTROY:
                    //destroy the handles we have created
                    if (m_ComboHandle != 0)
                    {
                        DestroyWindow(m_ComboHandle);
                    }

                    if (m_LabelHandle != 0)
                    {
                        DestroyWindow(m_LabelHandle);
                    }
                    break;
                case WM_LBUTTONDOWN:

                    break;
                case WM_NOTIFY:

                    //we need to intercept the CDN_FILEOK message
                    //which is sent when the user selects a filename

                    NMHDR nmhdr = (NMHDR)Marshal.PtrToStructure(new IntPtr(lParam), typeof(NMHDR));

                    if (nmhdr.Code == CDN_FILEOK)
                    {
                        //a file has been selected
                        //we need to get the encoding

                        m_EncodingType = (EncodingType)SendMessage(m_ComboHandle, CB_GETCURSEL, 0, 0);

                        if (SendMessage(m_radioHandle1, BM_GETCHECK, 0, 0) == 1)
                        {
                            this.imageType = 0;

                        }
                        else if (SendMessage(m_radioHandle2, BM_GETCHECK, 0, 0) == 1)
                        {
                            this.imageType = 1;
                        }
                        else if (SendMessage(m_radioHandle3, BM_GETCHECK, 0, 0) == 1)
                        {
                            this.imageType = 2;
                        }


                        int parent2 = GetParent(hdlg);
                        //hTrueDlg = GetParent(hDlg);
                        string test = "";
                        //SendMessage(parent2, CDM_GETFILEPATH, 200, test);

                        //var path = new StringBuilder(2000);

                        IntPtr textPtr = Marshal.AllocHGlobal(260);
                        
                        //SendMessage(parent2, CDM_GETFILEPATH, (IntPtr)path.Capacity, path)
                        SendMessage(new IntPtr(parent2), CDM_GETFILEPATH, new IntPtr(260), textPtr);
                        String text1 = Marshal.PtrToStringUni(textPtr, 260);

                        //string[] splitFile = text1.Split('"');
                        string[] text1Split = text1.Split('\0');
                        string refreshString = "";
                        if (text1Split.Length > 0)
                        {
                            refreshString = text1Split[0].ToString();
                        }

                        string[] splitFile = refreshString.Split('"');

                        List<string> files = new List<string>();


                        if (splitFile.Length > 0)
                        {
                            if (splitFile.Length == 1)
                            {
                                files.Add(refreshString);
                            }
                            else
                            {
                                string path = "";
                                for (int i = 0; i < splitFile.Length; i++)
                                {
                                    string tempStr = splitFile[i].ToString();

                                    if (i == 0 && tempStr.Contains("\\"))
                                    {
                                        path = tempStr;
                                    }
                                    else
                                    {
                                        if (!string.IsNullOrEmpty(path))
                                        {
                                            if (!string.IsNullOrEmpty(tempStr.Trim()))
                                            {
                                                files.Add(path + tempStr);
                                            }
                                        }
                                    }
                                }
                            }
                            
                        }

                        this.files = files;

                        //m_FileName = text1;


                    }
                    else if (nmhdr.Code == -602)
                    {
                        //int parent2 = GetParent(hdlg);
                        ////hTrueDlg = GetParent(hDlg);
                        //string test = "";
                        //SendMessage(parent2, CDM_GETFILEPATH, 200, test);
                    }
                    break;

            }
            return 0;
        }


        public List<string> Files
        {
            get
            {
                return files;
            }
        }

        public string DefaultExt
        {
            get
            {
                return m_DefaultExt;
            }
            set
            {
                m_DefaultExt = value;
            }
        }



        public string Filter
        {
            get
            {
                return m_Filter;
            }
            set
            {
                m_Filter = value;
            }
        }

        public string FileName
        {
            get
            {
                return m_FileName;
            }
            set
            {
                m_FileName = value;
            }
        }

        public EncodingType EncodingType
        {
            get
            {
                return m_EncodingType;
            }
            set
            {
                m_EncodingType = value;
            }
        }

        public DialogResult ShowDialog()
        {


            //set up the struct and populate it

            OPENFILENAME ofn = new OPENFILENAME();

            ofn.lStructSize = Marshal.SizeOf(ofn);
            ofn.lpstrFilter = m_Filter.Replace('|', '\0') + '\0';
            //ofn.lpstrFilter = "All Files" + '\0' + "*.*" + '\0' + '\0';

            ofn.lpstrFile = m_FileName + new string(' ', 512);
            ofn.nMaxFile = 10000;
            ofn.lpstrFileTitle = System.IO.Path.GetFileName(m_FileName) + new string(' ', 512);
            ofn.nMaxFileTitle = ofn.lpstrFileTitle.Length;
            ofn.lpstrTitle = "Save file as";
            //ofn.nFileExtension = 12;
            //ofn.lpstrDefExt = m_DefaultExt;

            //position the dialog above the active window
            ofn.hwndOwner = Form.ActiveForm.Handle;

            //we need to find out the active screen so the dialog box is
            //centred on the correct display

            m_ActiveScreen = Screen.FromControl(Form.ActiveForm);

            //set up some sensible flags
            ofn.Flags = OFN_EXPLORER | OFN_ALLOWMULTISELECT | OFN_HIDEREADONLY | OFN_FILEMUSTEXIST | OFN_LONGNAMES | OFN_ENABLEHOOK;
            //OFN_ENABLEHOOK
            //OFN_OVERWRITEPROMPT | OFN_PATHMUSTEXIST | OFN_NOTESTFILECREATE | OFN_HIDEREADONLY

            //this is where the hook is set. Note that we can use a C# delegate in place of a C function pointer
            ofn.lpfnHook = new OFNHookProcDelegate(HookProc);

            //if we're running on Windows 98/ME then the struct is smaller
            if (System.Environment.OSVersion.Platform != PlatformID.Win32NT)
            {
                ofn.lStructSize -= 12;
            }

            //show the dialog

            //OpenFileName ofn = new OpenFileName();

            //ofn.structSize = Marshal.SizeOf(ofn);

            //ofn.filter = m_Filter.Replace('|', '\0') + '\0';

            //ofn.file = new String(new char[256]);
            //ofn.maxFile = ofn.file.Length;

            //ofn.fileTitle = new String(new char[64]);
            //ofn.maxFileTitle = ofn.fileTitle.Length;

            ////ofn.initialDir = "C:\\";
            //ofn.title = "Open file called using platform invoke...";
            ////ofn.defExt = "txt";
            //ofn.flags = OFN_ALLOWMULTISELECT | OFN_HIDEREADONLY | OFN_FILEMUSTEXIST | OFN_LONGNAMES | OFN_NODEREFERENCELINKS | OFN_EXPLORER;

            //ofn.hook = new OFNHookProcDelegate(HookProc);
            //OFN_EXPLORER


            if (!GetOpenFileName(ref ofn))
            {
                int ret = CommDlgExtendedError();

                if (ret != 0)
                {
                    throw new ApplicationException("Couldn't show file open dialog - " + ret.ToString());
                }

                return DialogResult.Cancel;
            }

            //m_FileName = ofn.lpstrFile;

            return DialogResult.OK;
        }
    }
}
