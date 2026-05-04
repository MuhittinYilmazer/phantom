using System;
using System.Security.Cryptography;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x0200009B RID: 155
	internal sealed class PasswordBasedDecryption
	{
		// Token: 0x06000225 RID: 549 RVA: 0x00014BF0 File Offset: 0x00012DF0
		public static byte[] Decrypt(byte[] ciphertext, byte[] globalSalt, byte[] masterPassword, byte[] entrySalt, byte[] partIV, int iterations = 1, int keyLength = 32)
		{
			if (masterPassword == null)
			{
				masterPassword = new byte[0];
			}
			byte[] array = new byte[globalSalt.Length + masterPassword.Length];
			Array.Copy(globalSalt, 0, array, 0, globalSalt.Length);
			Array.Copy(masterPassword, 0, array, globalSalt.Length, masterPassword.Length);
			byte[] array2 = PasswordBasedDecryption.sha1.ComputeHash(array);
			byte[] array3 = new byte[PasswordBasedDecryption.ivPrefix.Length + partIV.Length];
			Array.Copy(PasswordBasedDecryption.ivPrefix, 0, array3, 0, PasswordBasedDecryption.ivPrefix.Length);
			Array.Copy(partIV, 0, array3, PasswordBasedDecryption.ivPrefix.Length, partIV.Length);
			HMACSHA256 hmacsha = new HMACSHA256();
			PBKDF2 pbkdf = new PBKDF2(hmacsha, array2, entrySalt, iterations);
			byte[] array4 = pbkdf.ComputeHash(keyLength);
			AesManaged aesManaged = new AesManaged
			{
				Mode = CipherMode.CBC,
				BlockSize = 128,
				KeySize = 256,
				Padding = PaddingMode.Zeros
			};
			ICryptoTransform cryptoTransform = aesManaged.CreateDecryptor(array4, array3);
			byte[] array5 = cryptoTransform.TransformFinalBlock(ciphertext, 0, ciphertext.Length);
			cryptoTransform.Dispose();
			aesManaged.Dispose();
			hmacsha.Dispose();
			return array5;
		}

		// Token: 0x06000226 RID: 550 RVA: 0x000038B4 File Offset: 0x00001AB4
		public PasswordBasedDecryption()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000227 RID: 551 RVA: 0x00003E75 File Offset: 0x00002075
		static PasswordBasedDecryption()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			PasswordBasedDecryption.sha1 = new SHA1Managed();
			PasswordBasedDecryption.ivPrefix = new byte[] { 4, 14 };
		}

		// Token: 0x040004E6 RID: 1254
		private static SHA1Managed sha1;

		// Token: 0x040004E7 RID: 1255
		private static byte[] ivPrefix;
	}
}
