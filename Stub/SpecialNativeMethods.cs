using System;
using System.Runtime.InteropServices;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000B1 RID: 177
	internal sealed class SpecialNativeMethods
	{
		// Token: 0x06000278 RID: 632
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern int NtWow64QueryInformationProcess64(IntPtr ProcessHandle, InternalStructs.PROCESSINFOCLASS ProcessInformationClass, ref InternalStructs64.PROCESS_BASIC_INFORMATION64 ProcessInformation, uint BufferSize, ref uint NumberOfBytesRead);

		// Token: 0x06000279 RID: 633
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern int NtWow64ReadVirtualMemory64(IntPtr ProcessHandle, ulong BaseAddress, IntPtr Buffer, ulong BufferSize, ref ulong NumberOfBytesWritten);

		// Token: 0x0600027A RID: 634
		[DllImport("ntdll.dll", SetLastError = true)]
		public static extern int NtWow64WriteVirtualMemory64(IntPtr ProcessHandle, ulong BaseAddress, IntPtr Buffer, ulong BufferSize, ref ulong NumberOfBytesWritten);

		// Token: 0x0600027B RID: 635 RVA: 0x000038B4 File Offset: 0x00001AB4
		public SpecialNativeMethods()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x0600027C RID: 636 RVA: 0x000038AD File Offset: 0x00001AAD
		static SpecialNativeMethods()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
