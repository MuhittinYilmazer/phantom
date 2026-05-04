using System;
using System.Runtime.InteropServices;
using System.Text;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000004 RID: 4
	internal class AesGcm
	{
		// Token: 0x06000015 RID: 21 RVA: 0x00004EA4 File Offset: 0x000030A4
		public static byte[] Decrypt(byte[] key, byte[] iv, byte[] aad, byte[] cipherText, byte[] authTag)
		{
			IntPtr intPtr;
			byte[] array;
			IntPtr intPtr2;
			IntPtr intPtr3;
			uint num;
			if (!AesGcm.OpenAlgorithmProvider(AesGcm.BCRYPT_AES_ALGORITHM, AesGcm.MS_PRIMITIVE_PROVIDER, AesGcm.BCRYPT_CHAIN_MODE_GCM, out intPtr))
			{
				array = null;
			}
			else if (!AesGcm.ImportKey(intPtr, key, out intPtr2, out intPtr3))
			{
				BCryptNativeMethods.BCryptCloseAlgorithmProvider(intPtr, 0U);
				array = null;
			}
			else if (!AesGcm.GetMaxAuthTagSize(intPtr, out num))
			{
				BCryptNativeMethods.BCryptDestroyKey(intPtr2);
				Marshal.FreeHGlobal(intPtr3);
				BCryptNativeMethods.BCryptCloseAlgorithmProvider(intPtr, 0U);
				array = null;
			}
			else
			{
				BCryptInternalStructs.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO bcrypt_AUTHENTICATED_CIPHER_MODE_INFO = new BCryptInternalStructs.BCRYPT_AUTHENTICATED_CIPHER_MODE_INFO(iv, aad, authTag);
				byte[] array2 = new byte[num];
				int num2 = 0;
				uint num3 = BCryptNativeMethods.BCryptDecrypt(intPtr2, cipherText, (uint)cipherText.Length, ref bcrypt_AUTHENTICATED_CIPHER_MODE_INFO, array2, (uint)array2.Length, null, 0U, ref num2, 0U);
				if (num3 != AesGcm.SUCCESS)
				{
					BCryptNativeMethods.BCryptDestroyKey(intPtr2);
					Marshal.FreeHGlobal(intPtr3);
					BCryptNativeMethods.BCryptCloseAlgorithmProvider(intPtr, 0U);
					bcrypt_AUTHENTICATED_CIPHER_MODE_INFO.Dispose();
					array = null;
				}
				else
				{
					byte[] array3 = new byte[num2];
					num3 = BCryptNativeMethods.BCryptDecrypt(intPtr2, cipherText, (uint)cipherText.Length, ref bcrypt_AUTHENTICATED_CIPHER_MODE_INFO, array2, (uint)array2.Length, array3, (uint)array3.Length, ref num2, 0U);
					BCryptNativeMethods.BCryptDestroyKey(intPtr2);
					Marshal.FreeHGlobal(intPtr3);
					BCryptNativeMethods.BCryptCloseAlgorithmProvider(intPtr, 0U);
					bcrypt_AUTHENTICATED_CIPHER_MODE_INFO.Dispose();
					if (num3 != AesGcm.SUCCESS)
					{
						array = null;
					}
					else
					{
						array = array3;
					}
				}
			}
			return array;
		}

		// Token: 0x06000016 RID: 22 RVA: 0x00004FD8 File Offset: 0x000031D8
		private static bool GetMaxAuthTagSize(IntPtr hAlg, out uint MaxAuthTagSize)
		{
			BCryptInternalStructs.BCRYPT_KEY_LENGTHS_STRUCT bcrypt_KEY_LENGTHS_STRUCT;
			bool flag;
			if (AesGcm.GetProperty<BCryptInternalStructs.BCRYPT_KEY_LENGTHS_STRUCT>(hAlg, AesGcm.BCRYPT_AUTH_TAG_LENGTH, out bcrypt_KEY_LENGTHS_STRUCT))
			{
				MaxAuthTagSize = bcrypt_KEY_LENGTHS_STRUCT.dwMaxLength;
				flag = true;
			}
			else
			{
				MaxAuthTagSize = 0U;
				flag = false;
			}
			return flag;
		}

		// Token: 0x06000017 RID: 23 RVA: 0x00005008 File Offset: 0x00003208
		private static bool OpenAlgorithmProvider(string alg, string provider, string chainingMode, out IntPtr hAlg)
		{
			uint num = BCryptNativeMethods.BCryptOpenAlgorithmProvider(out hAlg, alg, provider, 0U);
			bool flag;
			if (num != AesGcm.SUCCESS)
			{
				flag = false;
			}
			else
			{
				byte[] bytes = Encoding.Unicode.GetBytes(chainingMode);
				num = BCryptNativeMethods.BCryptSetProperty(hAlg, AesGcm.BCRYPT_CHAINING_MODE, bytes, (uint)bytes.Length, 0U);
				if (num != AesGcm.SUCCESS)
				{
					BCryptNativeMethods.BCryptCloseAlgorithmProvider(hAlg, 0U);
					flag = false;
				}
				else
				{
					flag = true;
				}
			}
			return flag;
		}

		// Token: 0x06000018 RID: 24 RVA: 0x0000506C File Offset: 0x0000326C
		private static bool ImportKey(IntPtr hAlg, byte[] key, out IntPtr hKey, out IntPtr keyDataBuffer)
		{
			hKey = IntPtr.Zero;
			keyDataBuffer = IntPtr.Zero;
			InternalStructs.UINTRESULT uintresult;
			bool flag;
			if (!AesGcm.GetProperty<InternalStructs.UINTRESULT>(hAlg, AesGcm.BCRYPT_OBJECT_LENGTH, out uintresult))
			{
				flag = false;
			}
			else
			{
				uint value = uintresult.Value;
				keyDataBuffer = Marshal.AllocHGlobal((int)value);
				BCryptInternalStructs.BCRYPT_KEY_DATA_BLOB_HEADER bcrypt_KEY_DATA_BLOB_HEADER = new BCryptInternalStructs.BCRYPT_KEY_DATA_BLOB_HEADER
				{
					dwMagic = AesGcm.BCRYPT_KEY_DATA_BLOB_MAGIC,
					dwVersion = 1U,
					cbKeyData = (uint)key.Length
				};
				uint num = (uint)(Marshal.SizeOf<BCryptInternalStructs.BCRYPT_KEY_DATA_BLOB_HEADER>(bcrypt_KEY_DATA_BLOB_HEADER) + key.Length);
				IntPtr intPtr = Marshal.AllocHGlobal((int)num);
				Marshal.StructureToPtr<BCryptInternalStructs.BCRYPT_KEY_DATA_BLOB_HEADER>(bcrypt_KEY_DATA_BLOB_HEADER, intPtr, false);
				Marshal.Copy(key, 0, intPtr + Marshal.SizeOf<BCryptInternalStructs.BCRYPT_KEY_DATA_BLOB_HEADER>(bcrypt_KEY_DATA_BLOB_HEADER), key.Length);
				uint num2 = BCryptNativeMethods.BCryptImportKey_KeyDataBlob(hAlg, IntPtr.Zero, out hKey, keyDataBuffer, value, intPtr, num);
				Marshal.FreeHGlobal(intPtr);
				if (num2 != AesGcm.SUCCESS)
				{
					Marshal.FreeHGlobal(keyDataBuffer);
					flag = false;
				}
				else
				{
					flag = true;
				}
			}
			return flag;
		}

		// Token: 0x06000019 RID: 25 RVA: 0x00005144 File Offset: 0x00003344
		private static bool GetProperty<T>(IntPtr hAlg, string name, out T outData)
		{
			outData = default(T);
			uint num = 0U;
			uint num2 = (uint)Marshal.SizeOf<T>();
			IntPtr intPtr = Marshal.AllocHGlobal((int)num2);
			uint num3 = BCryptNativeMethods.BCryptGetProperty(hAlg, name, intPtr, num2, ref num, 0U);
			bool flag;
			if (num3 != AesGcm.SUCCESS)
			{
				Marshal.FreeHGlobal(intPtr);
				flag = false;
			}
			else
			{
				outData = Marshal.PtrToStructure<T>(intPtr);
				Marshal.FreeHGlobal(intPtr);
				flag = true;
			}
			return flag;
		}

		// Token: 0x0600001A RID: 26 RVA: 0x000038B4 File Offset: 0x00001AB4
		public AesGcm()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x0600001B RID: 27 RVA: 0x000051A4 File Offset: 0x000033A4
		static AesGcm()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			AesGcm.SUCCESS = 0U;
			AesGcm.BCRYPT_KEY_DATA_BLOB_MAGIC = 1296188491U;
			AesGcm.BCRYPT_OBJECT_LENGTH = "ObjectLength";
			AesGcm.BCRYPT_CHAIN_MODE_GCM = "ChainingModeGCM";
			AesGcm.BCRYPT_AUTH_TAG_LENGTH = "AuthTagLength";
			AesGcm.BCRYPT_CHAINING_MODE = "ChainingMode";
			AesGcm.BCRYPT_AES_ALGORITHM = "AES";
			AesGcm.MS_PRIMITIVE_PROVIDER = "Microsoft Primitive Provider";
		}

		// Token: 0x0400000B RID: 11
		private static uint SUCCESS;

		// Token: 0x0400000C RID: 12
		private static uint BCRYPT_KEY_DATA_BLOB_MAGIC;

		// Token: 0x0400000D RID: 13
		private static string BCRYPT_OBJECT_LENGTH;

		// Token: 0x0400000E RID: 14
		private static string BCRYPT_CHAIN_MODE_GCM;

		// Token: 0x0400000F RID: 15
		private static string BCRYPT_AUTH_TAG_LENGTH;

		// Token: 0x04000010 RID: 16
		private static string BCRYPT_CHAINING_MODE;

		// Token: 0x04000011 RID: 17
		private static string BCRYPT_AES_ALGORITHM;

		// Token: 0x04000012 RID: 18
		private static string MS_PRIMITIVE_PROVIDER;
	}
}
