using System;
using System.Security.Cryptography;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x0200009F RID: 159
	public class PBKDF2
	{
		// Token: 0x06000235 RID: 565 RVA: 0x00015D94 File Offset: 0x00013F94
		public PBKDF2(HMAC algo, byte[] password, byte[] salt, int interations)
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			this.blockIndex = 1U;
			this.bufferStartIndex = 0;
			this.bufferEndIndex = 0;
			base..ctor();
			algo.Key = password;
			this.algo = algo;
			this.salt = salt;
			this.blockSize = algo.HashSize / 8;
			this.interations = interations;
			this.bufferBytes = new byte[this.blockSize];
		}

		// Token: 0x06000236 RID: 566 RVA: 0x00015E00 File Offset: 0x00014000
		public byte[] ComputeHash(int keySize)
		{
			byte[] array = new byte[keySize];
			int i = 0;
			int num = this.bufferEndIndex - this.bufferStartIndex;
			if (num > 0)
			{
				if (keySize < num)
				{
					Array.Copy(this.bufferBytes, this.bufferStartIndex, array, 0, keySize);
					this.bufferStartIndex += keySize;
					return array;
				}
				Array.Copy(this.bufferBytes, this.bufferStartIndex, array, 0, num);
				this.bufferStartIndex = 0;
				this.bufferEndIndex = 0;
				i += num;
			}
			while (i < keySize)
			{
				int num2 = keySize - i;
				byte[] array2 = new byte[this.salt.Length + 4];
				Array.Copy(this.salt, 0, array2, 0, this.salt.Length);
				Array.Copy(PBKDF2.GetBytesFromUInt(this.blockIndex), 0, array2, this.salt.Length, 4);
				byte[] array3 = this.algo.ComputeHash(array2);
				this.bufferBytes = array3;
				for (int j = 2; j <= this.interations; j++)
				{
					array3 = this.algo.ComputeHash(array3, 0, array3.Length);
					for (int k = 0; k < this.blockSize; k++)
					{
						this.bufferBytes[k] = this.bufferBytes[k] ^ array3[k];
					}
				}
				if (this.blockIndex == 4294967295U)
				{
					return null;
				}
				this.blockIndex += 1U;
				if (num2 <= this.blockSize)
				{
					Array.Copy(this.bufferBytes, 0, array, i, num2);
					this.bufferStartIndex = num2;
					this.bufferEndIndex = this.blockSize;
					IL_01AF:
					return array;
				}
				Array.Copy(this.bufferBytes, 0, array, i, this.blockSize);
				i += this.blockSize;
			}
			goto IL_01AF;
		}

		// Token: 0x06000237 RID: 567 RVA: 0x00015FC4 File Offset: 0x000141C4
		private static byte[] GetBytesFromUInt(uint i)
		{
			byte[] bytes = BitConverter.GetBytes(i);
			if (BitConverter.IsLittleEndian)
			{
				Array.Reverse(bytes);
			}
			return bytes;
		}

		// Token: 0x06000238 RID: 568 RVA: 0x000038AD File Offset: 0x00001AAD
		static PBKDF2()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}

		// Token: 0x040004F3 RID: 1267
		private int blockSize;

		// Token: 0x040004F4 RID: 1268
		private uint blockIndex;

		// Token: 0x040004F5 RID: 1269
		private byte[] bufferBytes;

		// Token: 0x040004F6 RID: 1270
		private int bufferStartIndex;

		// Token: 0x040004F7 RID: 1271
		private int bufferEndIndex;

		// Token: 0x040004F8 RID: 1272
		private byte[] salt;

		// Token: 0x040004F9 RID: 1273
		private HMAC algo;

		// Token: 0x040004FA RID: 1274
		private int interations;
	}
}
