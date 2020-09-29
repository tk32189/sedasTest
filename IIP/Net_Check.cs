using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;


namespace IIP
{

    class Net_Check
    {
        [DllImport("Shell32.dll")]
        public static extern int ShellExecute(IntPtr hwnd, string lpOperation, string lpFile, string lpParameters, string lpDirecotry, int nShowCmd);
        /// NETSOURCE 구조체 선언
        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        public struct NETSOURCE
        {
            public uint dwScope;
            public uint dwType;
            public uint dwDisplayType;
            public uint dwUsage;
            public string IPLocalName;
            public string IPRemoteName;
            public string IPComment;
            public string IPProvider;
        }
        /// WNetUseConnection API에 대한 닷넷 메서드 선언
        [DllImport("mpr.dll", CharSet = CharSet.Auto)]
        public static extern int WNetUseConnection(
            IntPtr hwndOwner,
            [MarshalAs(UnmanagedType.Struct)] ref NETSOURCE IPNetResource,
            string IPPassword,
            string IPUserID,
            uint dwFlags,
            StringBuilder IPAccessName,
            ref int IPBufferSize,
            out uint IPResult
            );

        /// 
        ///  네트워크 드라이브 생성
        /// 
        /// 서버주소
        /// 아이디
        /// 비밀번호
        /// 결과에 대한 문자열
        /// 
        public static string setRemoteConnection(string strRemoteConnectString, string strRemoteUserID, string strRemotePWD)
        {
            int capacity = 64;
            uint resultFlags = 0;
            uint flags = 0x80;

            try
            {
                if ((strRemoteConnectString != "" || strRemoteConnectString != string.Empty))
                {
                    StringBuilder sb = new StringBuilder(capacity);
                    NETSOURCE ns = new NETSOURCE();

                    ns.dwType = 1;    //공유디스크
                    ns.IPLocalName = Global.strDGSimagepath.Replace("\\", "");    //로컬 드라이브 지정하지 않음

                    ns.IPRemoteName = @strRemoteConnectString;
                    ns.IPProvider = null;
                    int result = WNetUseConnection(IntPtr.Zero, ref ns, strRemotePWD, strRemoteUserID, flags, sb, ref capacity, out resultFlags);

                    if (result == 0)
                    {
                        //Successfully connected to a network drive
                        return "0네트워크 드라이브가 성공적으로 연결되었습니다.";
                    }
                    else if (result == 85)
                    {
                        return "네트워크 드라이브를 연결중";
                    }
                    else
                    {
                        ShellExecute(GetStringTOintPtr("0"), "open", System.Environment.CurrentDirectory + "\\NetDrive.bat", "NetDrive.bat", System.Environment.CurrentDirectory, 5);
                        return "네트워크 드라이브를 연결할 수 없습니다.\n연결 정보를 확인하세요..";
                    }
                }
                else
                {
                    //Network drive connection information is incorrect
                    return "네트워크 드라이브 연결 정보가 올바르지 않습니다.";
                }
            }
            catch (Exception e)
            {
                return e.Message;
            }
        }
        public static IntPtr GetStringTOintPtr(string data)
        {
            return Marshal.StringToHGlobalAnsi(data);
        }

    }
}
