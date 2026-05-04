using System;
using System.Runtime.InteropServices;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x0200000B RID: 11
	internal sealed class BCryptInternalStructs
	{
		// Token: 0x06000036 RID: 54 RVA: 0x000038B4 File Offset: 0x00001AB4
		public BCryptInternalStructs()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000037 RID: 55 RVA: 0x00003946 File Offset: 0x00001B46
		static BCryptInternalStructs()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			BCryptInternalStructs.BCRYPT_INIT_AUTH_MODE_INFO_VERSION = 1U;
		}

		// Token: 0x04000026 RID: 38
		private static uint BCRYPT_INIT_AUTH_MODE_INFO_VERSION;

		// Token: 0x0200000C RID: 12
		public struct BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO : IDisposable
		{
			// Token: 0x06000038 RID: 56 RVA: 0x00007134 File Offset: 0x00005334
			public BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO(byte[] iv, byte[] aad, byte[] tag)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this = default(BCryptInternalStructs.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO);
				this.dwInfoVersion = BCryptInternalStructs.BCRYPT_INIT_AUTH_MODE_INFO_VERSION;
				this.cbSize = (uint)Marshal.SizeOf(typeof(BCryptInternalStructs.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO));
				if (iv != null)
				{
					this.cbNonce = (uint)iv.Length;
					this.pbNonce = Marshal.AllocHGlobal((int)this.cbNonce);
					Marshal.Copy(iv, 0, this.pbNonce, (int)this.cbNonce);
				}
				if (aad != null)
				{
					this.cbAuthData = (uint)aad.Length;
					this.pbAuthData = Marshal.AllocHGlobal((int)this.cbAuthData);
					Marshal.Copy(aad, 0, this.pbAuthData, (int)this.cbAuthData);
				}
				if (tag != null)
				{
					this.cbTag = (uint)tag.Length;
					this.pbTag = Marshal.AllocHGlobal((int)this.cbTag);
					Marshal.Copy(tag, 0, this.pbTag, (int)this.cbTag);
					this.cbMacContext = (uint)tag.Length;
					this.pbMacContext = Marshal.AllocHGlobal((int)this.cbMacContext);
				}
			}

			// Token: 0x06000039 RID: 57 RVA: 0x00007220 File Offset: 0x00005420
			public void Dispose()
			{
				if (this.pbNonce != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.pbNonce);
				}
				if (this.pbTag != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.pbTag);
				}
				if (this.pbAuthData != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.pbAuthData);
				}
				if (this.pbMacContext != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.pbMacContext);
				}
			}

			// Token: 0x0600003A RID: 58 RVA: 0x000038AD File Offset: 0x00001AAD
			static BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x04000027 RID: 39
			public uint cbSize;

			// Token: 0x04000028 RID: 40
			public uint dwInfoVersion;

			// Token: 0x04000029 RID: 41
			public IntPtr pbNonce;

			// Token: 0x0400002A RID: 42
			public uint cbNonce;

			// Token: 0x0400002B RID: 43
			public IntPtr pbAuthData;

			// Token: 0x0400002C RID: 44
			public uint cbAuthData;

			// Token: 0x0400002D RID: 45
			public IntPtr pbTag;

			// Token: 0x0400002E RID: 46
			public uint cbTag;

			// Token: 0x0400002F RID: 47
			public IntPtr pbMacContext;

			// Token: 0x04000030 RID: 48
			public uint cbMacContext;

			// Token: 0x04000031 RID: 49
			public uint cbAAD;

			// Token: 0x04000032 RID: 50
			public ulong cbData;

			// Token: 0x04000033 RID: 51
			public uint dwFlags;
		}

		// Token: 0x0200000D RID: 13
		public struct BCRYPT_KEY_LENGTHS_STRUCT
		{
			// Token: 0x04000034 RID: 52
			public uint dwMinLength;

			// Token: 0x04000035 RID: 53
			public uint dwMaxLength;

			// Token: 0x04000036 RID: 54
			public uint dwIncrement;
		}

		// Token: 0x0200000E RID: 14
		public struct BCRYPT_KEY_DATA_BLOB_HEADER
		{
			// Token: 0x04000037 RID: 55
			public uint dwMagic;

			// Token: 0x04000038 RID: 56
			public uint dwVersion;

			// Token: 0x04000039 RID: 57
			public uint cbKeyData;
		}
	}
}
