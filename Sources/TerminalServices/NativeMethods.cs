using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace PosInformatique.TerminalServices
{
    internal static class NativeMethods
    {
        private const string WTSDll = "wtsapi32.dll";
        private const string Kernel32Dll = "kernel32.dll";

        [DllImport(WTSDll)]
        internal static extern void WTSCloseServer(
            [In] HandleRef hServer);

        [DllImport(WTSDll, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr WTSOpenServer(
            [In] string pServerName);

        [DllImport(WTSDll, SetLastError = false)]
        internal static extern void WTSFreeMemory(
            [In] IntPtr memory);

        [DllImport(WTSDll, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool WTSEnumerateSessions(
                [In] HandleRef hServer,
                [In] int Reserved,
                [In] int Version,
                [Out] out IntPtr ppSessionInfo,
                [Out] out int pCount);

        [DllImport(WTSDll, CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern bool WTSEnumerateServers(
                [In] [MarshalAs(UnmanagedType.LPTStr)] string pDomainName,
                [In] int Reserved,
                [In] int Version,
                [Out] out IntPtr ppServerInfo,
                [Out] out int pCount
        );

        [DllImport(WTSDll, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool WTSEnumerateProcesses(
                [In] HandleRef hServer,
                [In] int Reserved,
                [In] int Version,
                [Out] out IntPtr ppProcessInfo,
                [Out] out int pCount);

        [DllImport(Kernel32Dll, SetLastError = true)]
        internal static extern int WTSGetActiveConsoleSessionId();


        [DllImport(WTSDll, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool WTSSendMessage(
                    [In] HandleRef hServer,
                    [In] int SessionId,
                    [In] [MarshalAs(UnmanagedType.LPTStr)] string pTitle,
                    [In] int TitleLength,
                    [In] [MarshalAs(UnmanagedType.LPTStr)] string pMessage,
                    [In] int MessageLength,
                    [In] int Style,
                    [In] int Timeout,
                    [Out] out int pResponse,
                    [In] bool bWait);

        [DllImport(WTSDll, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool WTSQuerySessionInformation(
                [In] HandleRef hServer,
                [In] int SessionId,
                [In] WTS_INFO_CLASS WTSInfoClass,
                [Out] out IntPtr ppBuffer,
                [Out] out int pBytesReturned);

        internal static bool WTSQuerySessionInformation(Session session, WTS_INFO_CLASS WTSInfoClass,
            out IntPtr ppBuffer, out int pBytesReturned)
        {
            return WTSQuerySessionInformation(new HandleRef(session.Server, session.Server.Handle), session.Id,
                WTSInfoClass, out ppBuffer, out pBytesReturned);
        }

        [DllImport(WTSDll, CharSet = CharSet.Auto, SetLastError = true)]
        private static extern bool WTSTerminateProcess(
                [In] HandleRef hServer,
                [In] int ProcessId,
                [In] int ExitCode);

        internal static bool WTSTerminateProcess(Process process, int ExitCode)
        {
            return WTSTerminateProcess(new HandleRef(process.Server, process.Server.Handle), process.Id, ExitCode);
        }

        #region WTSDisconnectSession

        [DllImport(WTSDll, SetLastError = true)]
        private static extern bool WTSDisconnectSession(
                [In] HandleRef hServer,
                [In] int SessionId,
                [In] [MarshalAs(UnmanagedType.Bool)] bool bWait);

        internal static bool WTSDisconnectSession(Session session, bool bWait)
        {
            return WTSDisconnectSession(new HandleRef(session.Server, session.Server.Handle), session.Id, bWait);
        }

        #endregion

        #region WTSDisconnectSession

        [DllImport(WTSDll, SetLastError = true)]
        private static extern bool WTSLogoffSession(
                [In] HandleRef hServer,
                [In] int SessionId,
                [In] [MarshalAs(UnmanagedType.Bool)] bool bWait);

        internal static bool WTSLogoffSession(Session session, bool bWait)
        {
            return WTSLogoffSession(new HandleRef(session.Server, session.Server.Handle), session.Id, bWait);
        }

        #endregion

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct WTS_SESSION_INFO
        {
            public int SessionId;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pWinStationName;
            public int State;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct WTS_SERVER_INFO
        {
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pServerName;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
        internal struct WTS_PROCESS_INFO
        {
            public int SessionId;
            public int ProcessId;
            [MarshalAs(UnmanagedType.LPTStr)]
            public string pProcessName;
            public IntPtr pUserSid;
        }

        internal enum WTS_INFO_CLASS
        {
            WTSInitialProgram = 0,
            WTSApplicationName = 1,
            WTSWorkingDirectory = 2,
            WTSOEMId = 3,
            WTSSessionId = 4,
            WTSUserName = 5,
            WTSWinStationName = 6,
            WTSDomainName = 7,
            WTSConnectState = 8,
            WTSClientBuildNumber = 9,
            WTSClientName = 10,
            WTSClientDirectory = 11,
            WTSClientProductId = 12,
            WTSClientHardwareId = 13,
            WTSClientAddress = 14,
            WTSClientDisplay = 15,
            WTSClientProtocolType = 16,
            WTSIdleTime = 17,
            WTSLogonTime = 18,
            WTSIncomingBytes = 19,
            WTSOutgoingBytes = 20,
            WTSIncomingFrames = 21,
            WTSOutgoingFrames = 22
        }

        internal static bool WTSSendMessage(Session session, string pTitle, string pMessage, int Style,
                    TimeSpan Timeout, out int pResponse,  bool bWait)
        {
            return WTSSendMessage(new HandleRef(session.Server, session.Server.Handle), session.Id, pTitle, 
                pTitle.Length * 2, pMessage, pMessage.Length * 2, Style,
                (int)Timeout.TotalSeconds, out pResponse, bWait);
        }
        internal static bool WTSEnumerateProcesses(HandleRef hServer, out IntPtr ppProcessInfo, out int pCount)
        {
            return WTSEnumerateProcesses(hServer, 0, 1, out ppProcessInfo, out pCount);
        }
        internal static bool WTSEnumerateSessions(HandleRef hServer, out IntPtr ppSessionInfo, out int pCount)
        {
            return WTSEnumerateSessions(hServer, 0, 1, out ppSessionInfo, out pCount);
        }

        private static IntPtr OffSet(IntPtr ptr, int size)
        {
            return new IntPtr(ptr.ToInt32() + size);
        }

        internal static T[] GetStructuresArrays<T>(IntPtr ptr, int count)
        {
            T[] array;
            int size;

            array = new T[count];
            size = Marshal.SizeOf(typeof(T));

            for (int i = 0; i < count; i++)
            {
                array[i] = (T)Marshal.PtrToStructure(ptr, typeof(T));
                ptr = OffSet(ptr, size);
            }

            return array;
        }
    }

    

    
}
