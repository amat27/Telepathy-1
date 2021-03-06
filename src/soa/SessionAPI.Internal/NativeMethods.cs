﻿// Copyright (c) Microsoft Corporation.
// Licensed under the MIT license.

namespace Microsoft.Telepathy.Session.Internal
{
    using System;
    using System.Runtime.ConstrainedExecution;
    using System.Runtime.InteropServices;
    using System.Text;

    using Microsoft.Telepathy.RuntimeTrace;
    using Microsoft.Win32.SafeHandles;
    // using Microsoft.Hpc.RuntimeTrace;

    /// <summary>
    /// Wrapped native methods
    /// </summary>
    public static class NativeMethods
    {
        public static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);

        // Create process
        public const uint CREATE_UNICODE_ENVIRONMENT = 0x00000400;
        public const uint CREATE_SUSPENDED = 0x00000004;
        public const uint CREATE_BREAKAWAY_FROM_JOB = 0x01000000;
        public const uint CREATE_NO_WINDOW = 0x08000000;


        // Job object
        public const int JobObjectExtendedLimitInformationClass = 9;
        public const uint JOB_OBJECT_LIMIT_KILL_ON_JOB_CLOSE = 0x00002000;

        [StructLayout(LayoutKind.Sequential)]
        public struct PROCESS_INFORMATION
        {
            public IntPtr hProcess;
            public IntPtr hThread;
            public int dwProcessId;
            public int dwThreadId;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct STARTUPINFO
        {
            public Int32 cb;
            public string lpReserved;
            public string lpDesktop;
            public string lpTitle;
            public Int32 dwX;
            public Int32 dwY;
            public Int32 dwXSize;
            public Int32 dwYSize;
            public Int32 dwXCountChars;
            public Int32 dwYCountChars;
            public Int32 dwFillAttribute;
            public Int32 dwFlags;
            public Int16 wShowWindow;
            public Int16 cbReserved2;
            public IntPtr lpReserved2;
            public IntPtr hStdInput;
            public IntPtr hStdOutput;
            public IntPtr hStdError;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct JobObjectExtendedLimitInformation
        {
            public Int64 PerProcessUserTimeLimit;
            public Int64 PerJobUserTimeLimit;
            public UInt32 LimitFlags;
            public UIntPtr MinimumWorkingSetSize;
            public UIntPtr MaximumWorkingSetSize;
            public UInt32 ActiveProcessLimit;
            public IntPtr Affinity;
            public UInt32 PriorityClass;
            public UInt32 SchedulingClass;
            public UInt64 ReadOperationCount;
            public UInt64 WriteOperationCount;
            public UInt64 OtherOperationCount;
            public UInt64 ReadTransferCount;
            public UInt64 WriteTransferCount;
            public UInt64 OtherTransferCount;
            public UIntPtr ProcessMemoryLimit;
            public UIntPtr JobMemoryLimit;
            public UIntPtr PeakProcessMemoryUsed;
            public UIntPtr PeakJobMemoryUsed;
        }

        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool CreateProcess([MarshalAs(UnmanagedType.LPTStr)]string lpApplicationName,
           StringBuilder lpCommandLine, IntPtr lpProcessAttributes,
           IntPtr lpThreadAttributes, bool bInheritHandles,
           uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory,
           [In] ref STARTUPINFO lpStartupInfo,
           out PROCESS_INFORMATION lpProcessInformation);

        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetExitCodeProcess(SafeProcessHandle hProcess, out uint lpExitCode);

        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool TerminateProcess(SafeProcessHandle hProcess, int uExitCode);

        [DllImport("Kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        public static extern uint ResumeThread(SafeThreadHandle hThread);

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true, CharSet = CharSet.Unicode)]
        public static extern IntPtr CreateJobObject(IntPtr lpJobAttributes, string lpName);

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern static bool SetInformationJobObject(IntPtr hJob, int informationClass, [In] ref JobObjectExtendedLimitInformation info, int size);

        [DllImport("kernel32.dll", CallingConvention = CallingConvention.Winapi, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public extern static bool AssignProcessToJobObject(IntPtr hJob, SafeProcessHandle hProcess);

        [DllImport("kernel32.dll", SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public extern static bool CloseHandle(IntPtr handle);

        [DllImport("kernel32.dll", SetLastError = true)]
        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public extern static bool CloseHandle(HandleRef handleRef);

        [ReliabilityContract(Consistency.WillNotCorruptState, Cer.Success)]
        public static void SafeCloseValidHandle(HandleRef handleRef)
        {
            if (handleRef.Handle != IntPtr.Zero && handleRef.Handle != INVALID_HANDLE_VALUE)
            {
                try
                {
                    CloseHandle(handleRef);
                }
                catch (Exception ex)
                {
                    // Swallow exception
                    TraceHelper.TraceWarning(
                        "0",
                        "[NativeMethods].SafeCloseValidHandle: Exception {0}.",
                        ex);
                }
            }
        }

        [DllImport("kernel32.dll", SetLastError = true)] 
        public static extern Int32 WaitForSingleObject(IntPtr Handle, Int32 Wait);
    }
}
