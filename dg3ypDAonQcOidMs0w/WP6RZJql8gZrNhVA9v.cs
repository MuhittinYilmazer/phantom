using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using rE4lpnT863QnijKQK5;

namespace dg3ypDAonQcOidMs0w
{
	// Token: 0x020000EF RID: 239
	internal class WP6RZJql8gZrNhVA9v
	{
		// Token: 0x06000382 RID: 898 RVA: 0x00020CD8 File Offset: 0x0001EED8
		static WP6RZJql8gZrNhVA9v()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x06000383 RID: 899 RVA: 0x0000391D File Offset: 0x00001B1D
		private void zYSwAnE5koRsP()
		{
		}

		// Token: 0x06000384 RID: 900 RVA: 0x00020E44 File Offset: 0x0001F044
		internal static byte[] ab9oDe4UH3(byte[] byte_0)
		{
			uint[] array = new uint[16];
			int num = 448 - byte_0.Length * 8 % 512;
			uint num2 = (uint)((num + 512) % 512);
			if (num2 == 0U)
			{
				num2 = 512U;
			}
			uint num3 = (uint)((long)byte_0.Length + (long)((ulong)(num2 / 8U)) + 8L);
			ulong num4 = (ulong)((long)byte_0.Length * 8L);
			byte[] array2 = new byte[num3];
			for (int i = 0; i < byte_0.Length; i++)
			{
				array2[i] = byte_0[i];
			}
			byte[] array3 = array2;
			int num5 = byte_0.Length;
			array3[num5] |= 128;
			for (int j = 8; j > 0; j--)
			{
				array2[(int)(checked((IntPtr)(unchecked((ulong)num3 - (ulong)((long)j)))))] = (byte)((num4 >> (8 - j) * 8) & 255UL);
			}
			uint num6 = (uint)(array2.Length * 8 / 32);
			uint num7 = 1732584193U;
			uint num8 = 4023233417U;
			uint num9 = 2562383102U;
			uint num10 = 271733878U;
			for (uint num11 = 0U; num11 < num6 / 16U; num11 += 1U)
			{
				uint num12 = num11 << 6;
				for (uint num13 = 0U; num13 < 61U; num13 += 4U)
				{
					array[(int)((UIntPtr)(num13 >> 2))] = (uint)(((int)array2[(int)((UIntPtr)(num12 + (num13 + 3U)))] << 24) | ((int)array2[(int)((UIntPtr)(num12 + (num13 + 2U)))] << 16) | ((int)array2[(int)((UIntPtr)(num12 + (num13 + 1U)))] << 8) | (int)array2[(int)((UIntPtr)(num12 + num13))]);
				}
				uint num14 = num7;
				uint num15 = num8;
				uint num16 = num9;
				uint num17 = num10;
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num7, num8, num9, num10, 0U, 7, 1U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num10, num7, num8, num9, 1U, 12, 2U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num9, num10, num7, num8, 2U, 17, 3U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num8, num9, num10, num7, 3U, 22, 4U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num7, num8, num9, num10, 4U, 7, 5U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num10, num7, num8, num9, 5U, 12, 6U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num9, num10, num7, num8, 6U, 17, 7U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num8, num9, num10, num7, 7U, 22, 8U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num7, num8, num9, num10, 8U, 7, 9U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num10, num7, num8, num9, 9U, 12, 10U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num9, num10, num7, num8, 10U, 17, 11U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num8, num9, num10, num7, 11U, 22, 12U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num7, num8, num9, num10, 12U, 7, 13U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num10, num7, num8, num9, 13U, 12, 14U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num9, num10, num7, num8, 14U, 17, 15U, array);
				WP6RZJql8gZrNhVA9v.TAOohhiP7R(ref num8, num9, num10, num7, 15U, 22, 16U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num7, num8, num9, num10, 1U, 5, 17U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num10, num7, num8, num9, 6U, 9, 18U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num9, num10, num7, num8, 11U, 14, 19U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num8, num9, num10, num7, 0U, 20, 20U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num7, num8, num9, num10, 5U, 5, 21U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num10, num7, num8, num9, 10U, 9, 22U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num9, num10, num7, num8, 15U, 14, 23U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num8, num9, num10, num7, 4U, 20, 24U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num7, num8, num9, num10, 9U, 5, 25U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num10, num7, num8, num9, 14U, 9, 26U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num9, num10, num7, num8, 3U, 14, 27U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num8, num9, num10, num7, 8U, 20, 28U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num7, num8, num9, num10, 13U, 5, 29U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num10, num7, num8, num9, 2U, 9, 30U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num9, num10, num7, num8, 7U, 14, 31U, array);
				WP6RZJql8gZrNhVA9v.zDKosecjaB(ref num8, num9, num10, num7, 12U, 20, 32U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num7, num8, num9, num10, 5U, 4, 33U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num10, num7, num8, num9, 8U, 11, 34U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num9, num10, num7, num8, 11U, 16, 35U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num8, num9, num10, num7, 14U, 23, 36U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num7, num8, num9, num10, 1U, 4, 37U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num10, num7, num8, num9, 4U, 11, 38U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num9, num10, num7, num8, 7U, 16, 39U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num8, num9, num10, num7, 10U, 23, 40U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num7, num8, num9, num10, 13U, 4, 41U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num10, num7, num8, num9, 0U, 11, 42U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num9, num10, num7, num8, 3U, 16, 43U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num8, num9, num10, num7, 6U, 23, 44U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num7, num8, num9, num10, 9U, 4, 45U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num10, num7, num8, num9, 12U, 11, 46U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num9, num10, num7, num8, 15U, 16, 47U, array);
				WP6RZJql8gZrNhVA9v.ubAof6RgCm(ref num8, num9, num10, num7, 2U, 23, 48U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num7, num8, num9, num10, 0U, 6, 49U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num10, num7, num8, num9, 7U, 10, 50U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num9, num10, num7, num8, 14U, 15, 51U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num8, num9, num10, num7, 5U, 21, 52U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num7, num8, num9, num10, 12U, 6, 53U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num10, num7, num8, num9, 3U, 10, 54U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num9, num10, num7, num8, 10U, 15, 55U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num8, num9, num10, num7, 1U, 21, 56U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num7, num8, num9, num10, 8U, 6, 57U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num10, num7, num8, num9, 15U, 10, 58U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num9, num10, num7, num8, 6U, 15, 59U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num8, num9, num10, num7, 13U, 21, 60U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num7, num8, num9, num10, 4U, 6, 61U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num10, num7, num8, num9, 11U, 10, 62U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num9, num10, num7, num8, 2U, 15, 63U, array);
				WP6RZJql8gZrNhVA9v.YpJoWsPi7X(ref num8, num9, num10, num7, 9U, 21, 64U, array);
				num7 += num14;
				num8 += num15;
				num9 += num16;
				num10 += num17;
			}
			byte[] array4 = new byte[16];
			Array.Copy(BitConverter.GetBytes(num7), 0, array4, 0, 4);
			Array.Copy(BitConverter.GetBytes(num8), 0, array4, 4, 4);
			Array.Copy(BitConverter.GetBytes(num9), 0, array4, 8, 4);
			Array.Copy(BitConverter.GetBytes(num10), 0, array4, 12, 4);
			return array4;
		}

		// Token: 0x06000385 RID: 901 RVA: 0x0000428E File Offset: 0x0000248E
		private static void TAOohhiP7R(ref uint uint_0, uint uint_1, uint uint_2, uint uint_3, uint uint_4, ushort ushort_0, uint uint_5, uint[] uint_6)
		{
			uint_0 = uint_1 + WP6RZJql8gZrNhVA9v.BEVodWAYPB(uint_0 + ((uint_1 & uint_2) | (~uint_1 & uint_3)) + uint_6[(int)((UIntPtr)uint_4)] + WP6RZJql8gZrNhVA9v.O1BkIDx0L0[(int)((UIntPtr)(uint_5 - 1U))], ushort_0);
		}

		// Token: 0x06000386 RID: 902 RVA: 0x000042B9 File Offset: 0x000024B9
		private static void zDKosecjaB(ref uint uint_0, uint uint_1, uint uint_2, uint uint_3, uint uint_4, ushort ushort_0, uint uint_5, uint[] uint_6)
		{
			uint_0 = uint_1 + WP6RZJql8gZrNhVA9v.BEVodWAYPB(uint_0 + ((uint_1 & uint_3) | (uint_2 & ~uint_3)) + uint_6[(int)((UIntPtr)uint_4)] + WP6RZJql8gZrNhVA9v.O1BkIDx0L0[(int)((UIntPtr)(uint_5 - 1U))], ushort_0);
		}

		// Token: 0x06000387 RID: 903 RVA: 0x000042E4 File Offset: 0x000024E4
		private static void ubAof6RgCm(ref uint uint_0, uint uint_1, uint uint_2, uint uint_3, uint uint_4, ushort ushort_0, uint uint_5, uint[] uint_6)
		{
			uint_0 = uint_1 + WP6RZJql8gZrNhVA9v.BEVodWAYPB(uint_0 + (uint_1 ^ uint_2 ^ uint_3) + uint_6[(int)((UIntPtr)uint_4)] + WP6RZJql8gZrNhVA9v.O1BkIDx0L0[(int)((UIntPtr)(uint_5 - 1U))], ushort_0);
		}

		// Token: 0x06000388 RID: 904 RVA: 0x0000430C File Offset: 0x0000250C
		private static void YpJoWsPi7X(ref uint uint_0, uint uint_1, uint uint_2, uint uint_3, uint uint_4, ushort ushort_0, uint uint_5, uint[] uint_6)
		{
			uint_0 = uint_1 + WP6RZJql8gZrNhVA9v.BEVodWAYPB(uint_0 + (uint_2 ^ (uint_1 | ~uint_3)) + uint_6[(int)((UIntPtr)uint_4)] + WP6RZJql8gZrNhVA9v.O1BkIDx0L0[(int)((UIntPtr)(uint_5 - 1U))], ushort_0);
		}

		// Token: 0x06000389 RID: 905 RVA: 0x00004335 File Offset: 0x00002535
		private static uint BEVodWAYPB(uint uint_0, ushort ushort_0)
		{
			return (uint_0 >> (int)(32 - ushort_0)) | (uint_0 << (int)ushort_0);
		}

		// Token: 0x0600038A RID: 906 RVA: 0x00004347 File Offset: 0x00002547
		internal static bool gX8onkMSd7()
		{
			if (!WP6RZJql8gZrNhVA9v.V9fkgxQPQA)
			{
				WP6RZJql8gZrNhVA9v.XS8oLZGMXn();
				WP6RZJql8gZrNhVA9v.V9fkgxQPQA = true;
			}
			return WP6RZJql8gZrNhVA9v.LrEkS2eXQL;
		}

		// Token: 0x0600038B RID: 907 RVA: 0x000214E8 File Offset: 0x0001F6E8
		internal static SymmetricAlgorithm PEXoCqmS4w()
		{
			SymmetricAlgorithm symmetricAlgorithm = null;
			if (WP6RZJql8gZrNhVA9v.gX8onkMSd7())
			{
				symmetricAlgorithm = new AesCryptoServiceProvider();
			}
			else
			{
				try
				{
					symmetricAlgorithm = new RijndaelManaged();
				}
				catch
				{
					symmetricAlgorithm = (SymmetricAlgorithm)Activator.CreateInstance("System.Core, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089", "System.Security.Cryptography.AesCryptoServiceProvider").Unwrap();
				}
			}
			return symmetricAlgorithm;
		}

		// Token: 0x0600038C RID: 908 RVA: 0x0002153C File Offset: 0x0001F73C
		internal static void XS8oLZGMXn()
		{
			try
			{
				WP6RZJql8gZrNhVA9v.LrEkS2eXQL = CryptoConfig.AllowOnlyFipsAlgorithms;
			}
			catch
			{
			}
		}

		// Token: 0x0600038D RID: 909 RVA: 0x00004360 File Offset: 0x00002560
		internal static byte[] XEDoeIU7mj(byte[] byte_0)
		{
			if (!WP6RZJql8gZrNhVA9v.gX8onkMSd7())
			{
				return new MD5CryptoServiceProvider().ComputeHash(byte_0);
			}
			return WP6RZJql8gZrNhVA9v.ab9oDe4UH3(byte_0);
		}

		// Token: 0x0600038E RID: 910 RVA: 0x00021568 File Offset: 0x0001F768
		internal static void vBuojdip3i(HashAlgorithm hashAlgorithm_0, Stream stream_0, uint uint_0, byte[] byte_0)
		{
			while (uint_0 > 0U)
			{
				int num = ((uint_0 > (uint)byte_0.Length) ? byte_0.Length : ((int)uint_0));
				stream_0.Read(byte_0, 0, num);
				WP6RZJql8gZrNhVA9v.NSmolmd79S(hashAlgorithm_0, byte_0, 0, num);
				uint_0 -= (uint)num;
			}
		}

		// Token: 0x0600038F RID: 911 RVA: 0x0000437B File Offset: 0x0000257B
		internal static void NSmolmd79S(HashAlgorithm hashAlgorithm_0, byte[] byte_0, int int_0, int int_1)
		{
			hashAlgorithm_0.TransformBlock(byte_0, int_0, int_1, byte_0, int_0);
		}

		// Token: 0x06000390 RID: 912 RVA: 0x000215A4 File Offset: 0x0001F7A4
		internal static uint SDQoufkqT0(uint uint_0, int int_0, long long_0, BinaryReader binaryReader_0)
		{
			for (int i = 0; i < int_0; i++)
			{
				binaryReader_0.BaseStream.Position = long_0 + (long)(i * 40 + 8);
				uint num = binaryReader_0.ReadUInt32();
				uint num2 = binaryReader_0.ReadUInt32();
				binaryReader_0.ReadUInt32();
				uint num3 = binaryReader_0.ReadUInt32();
				if (num2 <= uint_0 && uint_0 < num2 + num)
				{
					return num3 + uint_0 - num2;
				}
			}
			return 0U;
		}

		// Token: 0x06000391 RID: 913 RVA: 0x00021600 File Offset: 0x0001F800
		public static void TAJo1U8fio(RuntimeTypeHandle runtimeTypeHandle_0)
		{
			try
			{
				Type typeFromHandle = Type.GetTypeFromHandle(runtimeTypeHandle_0);
				if (WP6RZJql8gZrNhVA9v.Tqek0lIh21 == null)
				{
					lock (WP6RZJql8gZrNhVA9v.emjkxI4Yxp)
					{
						Dictionary<int, int> dictionary = new Dictionary<int, int>();
						BinaryReader binaryReader = new BinaryReader(typeof(WP6RZJql8gZrNhVA9v).Assembly.GetManifestResourceStream("6qxr6Tgqept3lxxPot.1Mmj5VYG6e4dAjvwWe"));
						binaryReader.BaseStream.Position = 0L;
						byte[] array = binaryReader.ReadBytes((int)binaryReader.BaseStream.Length);
						binaryReader.Close();
						if (array.Length > 0)
						{
							int num = array.Length % 4;
							int num2 = array.Length / 4;
							byte[] array2 = new byte[array.Length];
							uint num3 = 0U;
							if (num > 0)
							{
								num2++;
							}
							for (int i = 0; i < num2; i++)
							{
								int num4 = i * 4;
								uint num5 = 255U;
								int num6 = 0;
								uint num7;
								if (i == num2 - 1 && num > 0)
								{
									num7 = 0U;
									for (int j = 0; j < num; j++)
									{
										if (j > 0)
										{
											num7 <<= 8;
										}
										num7 |= (uint)array[array.Length - (1 + j)];
									}
								}
								else
								{
									uint num8 = (uint)num4;
									num7 = (uint)(((int)array[(int)((UIntPtr)(num8 + 3U))] << 24) | ((int)array[(int)((UIntPtr)(num8 + 2U))] << 16) | ((int)array[(int)((UIntPtr)(num8 + 1U))] << 8) | (int)array[(int)((UIntPtr)num8)]);
								}
								num3 = num3;
								num3 += WP6RZJql8gZrNhVA9v.EObomOjAWk(num3);
								if (i == num2 - 1 && num > 0)
								{
									uint num9 = num3 ^ num7;
									for (int k = 0; k < num; k++)
									{
										if (k > 0)
										{
											num5 <<= 8;
											num6 += 8;
										}
										array2[num4 + k] = (byte)((num9 & num5) >> num6);
									}
								}
								else
								{
									uint num10 = num3 ^ num7;
									array2[num4] = (byte)(num10 & 255U);
									array2[num4 + 1] = (byte)((num10 & 65280U) >> 8);
									array2[num4 + 2] = (byte)((num10 & 16711680U) >> 16);
									array2[num4 + 3] = (byte)((num10 & 4278190080U) >> 24);
								}
							}
							array = array2;
							int num11 = array.Length / 8;
							WP6RZJql8gZrNhVA9v.VtNVUKGulysZw81C3E vtNVUKGulysZw81C3E = new WP6RZJql8gZrNhVA9v.VtNVUKGulysZw81C3E(new MemoryStream(array));
							for (int l = 0; l < num11; l++)
							{
								int num12 = vtNVUKGulysZw81C3E.TVtkAMaqpL();
								int num13 = vtNVUKGulysZw81C3E.TVtkAMaqpL();
								dictionary.Add(num12, num13);
							}
							vtNVUKGulysZw81C3E.VDqkQKyKML();
						}
						WP6RZJql8gZrNhVA9v.Tqek0lIh21 = dictionary;
					}
				}
				foreach (FieldInfo fieldInfo in typeFromHandle.GetFields(BindingFlags.Static | BindingFlags.NonPublic | BindingFlags.GetField))
				{
					int metadataToken = fieldInfo.MetadataToken;
					int num14 = WP6RZJql8gZrNhVA9v.Tqek0lIh21[metadataToken];
					bool flag2 = (num14 & 1073741824) > 0;
					num14 &= 1073741823;
					MethodInfo methodInfo = (MethodInfo)typeof(WP6RZJql8gZrNhVA9v).Module.ResolveMethod(num14, typeFromHandle.GetGenericArguments(), new Type[0]);
					if (methodInfo.IsStatic)
					{
						fieldInfo.SetValue(null, Delegate.CreateDelegate(fieldInfo.FieldType, methodInfo));
					}
					else
					{
						ParameterInfo[] parameters = methodInfo.GetParameters();
						int num15 = parameters.Length + 1;
						Type[] array3 = new Type[num15];
						if (methodInfo.DeclaringType.IsValueType)
						{
							array3[0] = methodInfo.DeclaringType.MakeByRefType();
						}
						else
						{
							array3[0] = typeof(object);
						}
						for (int n = 0; n < parameters.Length; n++)
						{
							array3[n + 1] = parameters[n].ParameterType;
						}
						DynamicMethod dynamicMethod = new DynamicMethod(string.Empty, methodInfo.ReturnType, array3, typeFromHandle, true);
						ILGenerator ilgenerator = dynamicMethod.GetILGenerator();
						for (int num16 = 0; num16 < num15; num16++)
						{
							switch (num16)
							{
							case 0:
								ilgenerator.Emit(OpCodes.Ldarg_0);
								break;
							case 1:
								ilgenerator.Emit(OpCodes.Ldarg_1);
								break;
							case 2:
								ilgenerator.Emit(OpCodes.Ldarg_2);
								break;
							case 3:
								ilgenerator.Emit(OpCodes.Ldarg_3);
								break;
							default:
								ilgenerator.Emit(OpCodes.Ldarg_S, num16);
								break;
							}
						}
						ilgenerator.Emit(OpCodes.Tailcall);
						ilgenerator.Emit(flag2 ? OpCodes.Callvirt : OpCodes.Call, methodInfo);
						ilgenerator.Emit(OpCodes.Ret);
						fieldInfo.SetValue(null, dynamicMethod.CreateDelegate(typeFromHandle));
					}
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x06000392 RID: 914 RVA: 0x00004389 File Offset: 0x00002589
		private static uint Ggxo4dRvtE(uint uint_0)
		{
			return (uint)"{11111-22222-10009-11111}".Length;
		}

		// Token: 0x06000393 RID: 915 RVA: 0x00004395 File Offset: 0x00002595
		private static uint EObomOjAWk(uint uint_0)
		{
			return 0U;
		}

		// Token: 0x06000394 RID: 916 RVA: 0x0000391D File Offset: 0x00001B1D
		internal static void w65ov7siki()
		{
		}

		// Token: 0x06000395 RID: 917 RVA: 0x00021A74 File Offset: 0x0001FC74
		[WP6RZJql8gZrNhVA9v.RJDcsuMfOxrTCYImPe(typeof(WP6RZJql8gZrNhVA9v.RJDcsuMfOxrTCYImPe.iGR41459RDH4FvPdNk<object>[]))]
		internal static string hg2oY5yaSM(string string_0)
		{
			"{11111-22222-50001-00000}".Trim();
			byte[] array = Convert.FromBase64String(string_0);
			return Encoding.Unicode.GetString(array, 0, array.Length);
		}

		// Token: 0x06000396 RID: 918 RVA: 0x00021AA4 File Offset: 0x0001FCA4
		internal static uint NvQ34uZt895nxEhi2FIr(IntPtr intptr_0, IntPtr intptr_1, IntPtr intptr_2, [MarshalAs(UnmanagedType.U4)] uint uint_0, IntPtr intptr_3, ref uint uint_1)
		{
			IntPtr intPtr = intptr_2;
			if (WP6RZJql8gZrNhVA9v.PRZkZqsNsa)
			{
				intPtr = intptr_1;
			}
			long num;
			if (IntPtr.Size == 4)
			{
				num = (long)Marshal.ReadInt32(intPtr, IntPtr.Size * 2);
			}
			else
			{
				num = Marshal.ReadInt64(intPtr, IntPtr.Size * 2);
			}
			object obj = WP6RZJql8gZrNhVA9v.lmdkVksVkh[num];
			if (obj == null)
			{
				return WP6RZJql8gZrNhVA9v.abxkLGOVrU(intptr_0, intptr_1, intptr_2, uint_0, intptr_3, ref uint_1);
			}
			WP6RZJql8gZrNhVA9v.BIpvxRBRb2dOGl802m bipvxRBRb2dOGl802m = (WP6RZJql8gZrNhVA9v.BIpvxRBRb2dOGl802m)obj;
			IntPtr intPtr2 = Marshal.AllocCoTaskMem(bipvxRBRb2dOGl802m.jsbkrdexts.Length);
			Marshal.Copy(bipvxRBRb2dOGl802m.jsbkrdexts, 0, intPtr2, bipvxRBRb2dOGl802m.jsbkrdexts.Length);
			if (bipvxRBRb2dOGl802m.JDNkifbo3S)
			{
				intptr_3 = intPtr2;
				uint_1 = (uint)bipvxRBRb2dOGl802m.jsbkrdexts.Length;
				WP6RZJql8gZrNhVA9v.YeeoMqaS3J(intptr_3, bipvxRBRb2dOGl802m.jsbkrdexts.Length, 64, ref WP6RZJql8gZrNhVA9v.CgSk1JZr60);
				return 0U;
			}
			Marshal.WriteIntPtr(intPtr, IntPtr.Size * 2, intPtr2);
			Marshal.WriteInt32(intPtr, IntPtr.Size * 3, bipvxRBRb2dOGl802m.jsbkrdexts.Length);
			uint num2 = 0U;
			if (uint_0 == 216669565U && !WP6RZJql8gZrNhVA9v.firstrundone)
			{
				WP6RZJql8gZrNhVA9v.firstrundone = true;
			}
			else
			{
				num2 = WP6RZJql8gZrNhVA9v.abxkLGOVrU(intptr_0, intptr_1, intptr_2, uint_0, intptr_3, ref uint_1);
			}
			return num2;
		}

		// Token: 0x06000397 RID: 919 RVA: 0x00004398 File Offset: 0x00002598
		private static int FPvotekByE()
		{
			return 5;
		}

		// Token: 0x06000398 RID: 920 RVA: 0x00021BD0 File Offset: 0x0001FDD0
		private static void svloy6EVGc()
		{
			try
			{
				RSACryptoServiceProvider.UseMachineKeyStore = true;
			}
			catch
			{
			}
		}

		// Token: 0x06000399 RID: 921 RVA: 0x00021BF8 File Offset: 0x0001FDF8
		private static Delegate iaKoOg5GGg(IntPtr intptr_0, Type type_0)
		{
			return (Delegate)typeof(Marshal).GetMethod("GetDelegateForFunctionPointer", new Type[]
			{
				typeof(IntPtr),
				typeof(Type)
			}).Invoke(null, new object[] { intptr_0, type_0 });
		}

		// Token: 0x0600039A RID: 922 RVA: 0x00021C5C File Offset: 0x0001FE5C
		internal unsafe static void prXoP4RuYp()
		{
			int num = 379;
			for (;;)
			{
				IL_0009:
				if (!WP6RZJql8gZrNhVA9v.MrkkWebIMK)
				{
					goto IL_0013;
				}
				goto IL_3964;
				int num2;
				long num9;
				uint num37;
				for (;;)
				{
					IL_0061:
					byte[] array;
					int num5;
					byte[] array2;
					int num6;
					byte[] array3;
					byte[] array4;
					byte[] array5;
					int num7;
					byte[] array6;
					int num8;
					byte[] array7;
					byte[] array8;
					byte[] array10;
					byte[] array11;
					int num10;
					byte[] array12;
					long num11;
					int num12;
					byte[] array13;
					WP6RZJql8gZrNhVA9v.VtNVUKGulysZw81C3E vtNVUKGulysZw81C3E;
					int num13;
					uint num14;
					int num16;
					uint num21;
					int num23;
					long num24;
					uint num25;
					uint num26;
					IntPtr zero;
					byte[] array15;
					IntPtr intPtr;
					IntPtr intPtr2;
					long num29;
					WP6RZJql8gZrNhVA9v.BIpvxRBRb2dOGl802m bipvxRBRb2dOGl802m2;
					int num31;
					int num32;
					int num35;
					uint num36;
					IntPtr intPtr4;
					IntPtr intPtr5;
					switch (num2)
					{
					case 0:
						goto IL_2BFB;
					case 1:
						goto IL_3652;
					case 2:
						goto IL_3778;
					case 3:
					{
						int num3;
						int num4;
						if (num3 == num4 - 1)
						{
							goto IL_322F;
						}
						goto IL_325C;
					}
					case 4:
						goto IL_2B2D;
					case 5:
						goto IL_0EED;
					case 6:
						goto IL_1C30;
					case 7:
						array[18] = (byte)num5;
						goto IL_264B;
					case 8:
						goto IL_28A8;
					case 9:
						array2[7] = 188;
						num2 = 374;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_208;
						}
						continue;
					case 10:
						goto IL_149D;
					case 11:
						goto IL_3B1E;
					case 12:
						goto IL_235F;
					case 13:
						goto IL_27A5;
					case 14:
						goto IL_1BF0;
					case 15:
						goto IL_2A9C;
					case 16:
						num6 = 144;
						goto IL_32A6;
					case 17:
						goto IL_274B;
					case 18:
						goto IL_4591;
					case 19:
						goto IL_0013;
					case 20:
						goto IL_317B;
					case 21:
						array3 = null;
						goto IL_27BE;
					case 22:
						goto IL_0DB8;
					case 23:
						if (!WP6RZJql8gZrNhVA9v.zqn4VshKNT3WCTFCwJZ(WP6RZJql8gZrNhVA9v.woW3uTh3BLqd1RTLGjC(WP6RZJql8gZrNhVA9v.HMmDSchYhBi0nCBpGT7(typeof(WP6RZJql8gZrNhVA9v).TypeHandle).Assembly), null))
						{
							goto IL_0F28;
						}
						num2 = 231;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_42B5;
						}
						continue;
					case 24:
						goto IL_34AA;
					case 25:
						goto IL_0C3C;
					case 26:
						goto IL_4416;
					case 27:
						goto IL_2436;
					case 28:
						goto IL_4525;
					case 29:
						goto IL_1F78;
					case 30:
						if (array4.Length != 0)
						{
							goto IL_3F6A;
						}
						goto IL_29A8;
					case 31:
						goto IL_2832;
					case 32:
						goto IL_1AC7;
					case 33:
						array2[15] = (byte)num6;
						goto IL_3ADF;
					case 34:
						goto IL_2AB5;
					case 35:
						array5 = array2;
						goto IL_2887;
					case 36:
						goto IL_3B38;
					case 37:
						goto IL_25E1;
					case 38:
						goto IL_3433;
					case 39:
						goto IL_3004;
					case 40:
						goto IL_2897;
					case 41:
						return;
					case 42:
						if (WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas() == 4)
						{
							goto IL_4591;
						}
						goto IL_37F9;
					case 43:
						goto IL_1D08;
					case 44:
						goto IL_0CAC;
					case 45:
						goto IL_3AEB;
					case 46:
						goto IL_446F;
					case 47:
						goto IL_1E41;
					case 48:
						goto IL_34C9;
					case 49:
						return;
					case 50:
						num7 = 101;
						goto IL_4554;
					case 51:
						goto IL_0CE7;
					case 52:
						goto IL_0D32;
					case 53:
						goto IL_2375;
					case 54:
						goto IL_0BA6;
					case 55:
						goto IL_27FA;
					case 56:
						num5 = 168;
						num = 601;
						goto IL_2604;
					case 57:
						goto IL_19F8;
					case 58:
						goto IL_0E67;
					case 59:
					case 274:
						goto IL_2380;
					case 60:
						goto IL_4554;
					case 61:
						goto IL_325C;
					case 62:
						goto IL_35B9;
					case 63:
						goto IL_0D9A;
					case 64:
						goto IL_2693;
					case 65:
						num6 = 105;
						goto IL_38E7;
					case 66:
						num5 = 60;
						num = 233;
						goto IL_3FBF;
					case 67:
						goto IL_2BCB;
					case 68:
					case 280:
						goto IL_2DF0;
					case 69:
						goto IL_38B8;
					case 70:
						goto IL_0C4A;
					case 71:
						goto IL_37BF;
					case 72:
						goto IL_2684;
					case 73:
						goto IL_1AA3;
					case 74:
					case 322:
						goto IL_2863;
					case 75:
						array6[num8 + 5] = array7[5];
						goto IL_4525;
					case 76:
						goto IL_0C91;
					case 77:
						array[27] = 170;
						goto IL_0D9A;
					case 78:
						goto IL_17A7;
					case 79:
						goto IL_2ED2;
					case 80:
						goto IL_128E;
					case 81:
						goto IL_2D0C;
					case 82:
					{
						byte[] array9;
						array8 = new byte[array9.Length];
						goto IL_4048;
					}
					case 83:
						num7 = 145;
						goto IL_276C;
					case 84:
						goto IL_2D20;
					case 85:
						goto IL_2B76;
					case 86:
						goto IL_0E25;
					case 87:
						array10[6] = 105;
						goto IL_3FB4;
					case 88:
						array2[14] = 111;
						goto IL_21DE;
					case 89:
						goto IL_2B59;
					case 90:
						goto IL_4183;
					case 91:
						goto IL_3949;
					case 92:
						array[9] = 224;
						num = 660;
						goto IL_18E1;
					case 93:
						array2[3] = (byte)num6;
						num = 570;
						goto IL_29FB;
					case 94:
						return;
					case 95:
						goto IL_136B;
					case 96:
					case 186:
						goto IL_31BD;
					case 97:
					{
						ProcessModuleCollection processModuleCollection = WP6RZJql8gZrNhVA9v.QXAPiWMFybI6qUa5Fy(WP6RZJql8gZrNhVA9v.KmKeX0bgSXhq1fq28N());
						goto IL_20A2;
					}
					case 98:
						goto IL_1300;
					case 99:
						goto IL_1D5B;
					case 100:
						goto IL_1C92;
					case 101:
					case 343:
						goto IL_2560;
					case 102:
						num7 = 124;
						goto IL_446F;
					case 103:
						array10[3] = 106;
						num2 = 123;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto Block_203;
						}
						continue;
					case 104:
						WP6RZJql8gZrNhVA9v.SEMrdPdZHGgNIZSO1O(new IntPtr((void*)(&num9)), 0, 0);
						goto IL_2D76;
					case 105:
						goto IL_0C7B;
					case 106:
					case 344:
						goto IL_1E57;
					case 107:
						goto IL_3486;
					case 108:
						array2[10] = 93;
						goto IL_2A83;
					case 109:
						num6 = 32;
						goto IL_4416;
					case 110:
						goto IL_2EF9;
					case 111:
						goto IL_0BF3;
					case 112:
						goto IL_1FA6;
					case 113:
						goto IL_32CC;
					case 114:
						goto IL_0BC4;
					case 115:
						array11[2] = 116;
						num2 = 424;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto Block_202;
						}
						continue;
					case 116:
						array2[10] = (byte)num10;
						goto IL_2C84;
					case 117:
						goto IL_0E06;
					case 118:
						goto IL_0020;
					case 119:
						goto IL_3299;
					case 120:
						num5 = 113;
						num2 = 170;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto Block_201;
						}
						continue;
					case 121:
						num5 = 165;
						num = 473;
						goto IL_3425;
					case 122:
						array12 = array8;
						num2 = 11;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
						{
							goto IL_2BA7;
						}
						continue;
					case 123:
						array10[4] = 105;
						goto IL_2295;
					case 124:
						goto IL_0DD1;
					case 125:
						array[29] = (byte)num7;
						goto IL_4357;
					case 126:
						goto IL_0B09;
					case 127:
						goto IL_436B;
					case 128:
						goto IL_3D99;
					case 129:
						goto IL_1AD2;
					case 130:
						goto IL_4357;
					case 131:
						goto IL_1B3A;
					case 132:
						goto IL_2DF9;
					case 133:
						array[11] = (byte)num5;
						num2 = 654;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto Block_199;
						}
						continue;
					case 134:
						goto IL_0B66;
					case 135:
						array2[15] = (byte)num10;
						num2 = 35;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_198;
						}
						continue;
					case 136:
						goto IL_22CF;
					case 137:
						array6[num8 + 1] = array7[1];
						goto IL_3DC6;
					case 138:
						array6[num8 + 4] = array3[4];
						num2 = 2;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto Block_197;
						}
						continue;
					case 139:
					case 253:
						goto IL_3F6A;
					case 140:
						goto IL_0EB7;
					case 141:
					case 517:
						goto IL_246E;
					case 142:
						goto IL_2A1F;
					case 143:
						goto IL_3F7E;
					case 144:
						goto IL_2FF6;
					case 145:
						num5 = 146;
						goto IL_3FA1;
					case 146:
						goto IL_2151;
					case 147:
						goto IL_42B5;
					case 148:
						goto IL_1383;
					case 149:
						goto IL_38C4;
					case 150:
						goto IL_1E07;
					case 151:
						goto IL_38FB;
					case 152:
						goto IL_23CD;
					case 153:
						WP6RZJql8gZrNhVA9v.YeeoMqaS3J(new IntPtr(num11), WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas(), 64, ref num12);
						num2 = 500;
						if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_316D;
						}
						continue;
					case 154:
						array13 = null;
						num2 = 134;
						if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_363F;
						}
						continue;
					case 155:
						WP6RZJql8gZrNhVA9v.HPPX7oC1352NeBiZaB(new IntPtr((void*)(&num9)), 0);
						num2 = 566;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto Block_193;
						}
						continue;
					case 156:
						array[8] = (byte)num5;
						num2 = 121;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_192;
						}
						continue;
					case 157:
						goto IL_0B17;
					case 158:
						num7 = 223;
						num2 = 324;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_191;
						}
						continue;
					case 159:
						goto IL_2727;
					case 160:
						goto IL_0DA9;
					case 161:
						return;
					case 162:
						goto IL_22E0;
					case 163:
						array6[num8 + 3] = array13[3];
						goto IL_2AB5;
					case 164:
						goto IL_2C9C;
					case 165:
						goto IL_1E8B;
					case 166:
						if (WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas() != 4)
						{
							goto IL_35DC;
						}
						num2 = 289;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_190;
						}
						continue;
					case 167:
					case 340:
						goto IL_12E9;
					case 168:
						goto IL_18B7;
					case 169:
						goto IL_2476;
					case 170:
						array[18] = (byte)num5;
						num2 = 674;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_188;
						}
						continue;
					case 171:
						goto IL_1284;
					case 172:
						goto IL_25AA;
					case 173:
						num7 = 40;
						goto IL_1BA9;
					case 174:
						goto IL_4191;
					case 175:
						goto IL_31C6;
					case 176:
						goto IL_1F48;
					case 177:
						goto IL_2550;
					case 178:
						goto IL_1D9C;
					case 179:
						array[20] = 202;
						num2 = 73;
						if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_4183;
						}
						continue;
					case 180:
					case 243:
						goto IL_1AF5;
					case 181:
						goto IL_12A2;
					case 182:
						goto IL_0DEF;
					case 183:
						goto IL_3514;
					case 184:
						goto IL_2356;
					case 185:
						goto IL_188B;
					case 187:
						goto IL_20FB;
					case 188:
						goto IL_371B;
					case 189:
						goto IL_22A1;
					case 190:
						num10 = 189;
						num = 430;
						goto IL_3603;
					case 191:
						array[7] = (byte)num7;
						num2 = 265;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_19F8;
						}
						continue;
					case 192:
						array2[14] = (byte)num10;
						num2 = 78;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
						{
							goto IL_4055;
						}
						continue;
					case 193:
					{
						MemoryStream memoryStream;
						WP6RZJql8gZrNhVA9v.Cv8hm26dWkilb1H7uG(memoryStream);
						num2 = 331;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto IL_2FF6;
						}
						continue;
					}
					case 194:
						goto IL_1A7A;
					case 195:
						goto IL_29CF;
					case 196:
						goto IL_137A;
					case 197:
						goto IL_382C;
					case 198:
						goto IL_2A3C;
					case 199:
						array[30] = (byte)num7;
						goto IL_2197;
					case 200:
						goto IL_2C49;
					case 201:
					{
						byte[] array14 = WP6RZJql8gZrNhVA9v.IkVx6W7gxIo4U9w5rM(vtNVUKGulysZw81C3E, (int)WP6RZJql8gZrNhVA9v.G2NYB14TljE8aPpplT(WP6RZJql8gZrNhVA9v.Wqta94qIF2UoY3DUfP(vtNVUKGulysZw81C3E)));
						goto IL_37CA;
					}
					case 202:
						goto IL_1A86;
					case 203:
						array[27] = 136;
						num2 = 77;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_183;
						}
						continue;
					case 204:
						goto IL_37D8;
					case 205:
						goto IL_0D7C;
					case 206:
						goto IL_2A0A;
					case 207:
						goto IL_1A0D;
					case 208:
					case 604:
						goto IL_24E1;
					case 209:
						array[14] = (byte)num7;
						num2 = 673;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto Block_182;
						}
						continue;
					case 210:
						goto IL_3B93;
					case 211:
						goto IL_4055;
					case 212:
						goto IL_23C1;
					case 213:
						goto IL_0F09;
					case 214:
						goto IL_1E0E;
					case 215:
						goto IL_1938;
					case 216:
						goto IL_29A8;
					case 217:
						goto IL_4048;
					case 218:
						goto IL_1DBD;
					case 219:
						array8[num13 + 1] = (byte)((num14 & 65280U) >> 8);
						num2 = 365;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_180;
						}
						continue;
					case 220:
						goto IL_0F28;
					case 221:
						goto IL_393A;
					case 222:
						goto IL_1DDB;
					case 223:
						goto IL_1C0A;
					case 224:
						goto IL_1A42;
					case 225:
						goto IL_13C5;
					case 226:
						goto IL_0CCB;
					case 227:
						goto IL_0BD2;
					case 228:
						array2[5] = (byte)num6;
						num2 = 455;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_1C30;
						}
						continue;
					case 229:
						goto IL_2B4E;
					case 230:
						goto IL_143D;
					case 231:
						if (WP6RZJql8gZrNhVA9v.NU0imqhIvW9D0YZELEm(WP6RZJql8gZrNhVA9v.woW3uTh3BLqd1RTLGjC(WP6RZJql8gZrNhVA9v.HMmDSchYhBi0nCBpGT7(typeof(WP6RZJql8gZrNhVA9v).TypeHandle).Assembly)).Length == 2)
						{
							goto IL_3BD3;
						}
						goto IL_0F28;
					case 232:
						goto IL_4695;
					case 233:
						goto IL_3FBF;
					case 234:
						goto IL_23C4;
					case 235:
						goto IL_192C;
					case 236:
						goto IL_3FB4;
					case 237:
						goto IL_19DC;
					case 238:
						goto IL_22F5;
					case 239:
						goto IL_26CB;
					case 240:
						goto IL_2D53;
					case 241:
						goto IL_18BD;
					case 242:
					case 386:
					{
						int num15;
						if (num15 < num16)
						{
							goto IL_38A2;
						}
						num2 = 505;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto Block_150;
						}
						continue;
					}
					case 244:
						goto IL_270F;
					case 245:
						goto IL_3FA1;
					case 246:
						goto IL_28AF;
					case 247:
						goto IL_2D12;
					case 248:
						goto IL_0B1D;
					case 249:
						goto IL_2A2E;
					case 250:
					case 635:
						goto IL_0C64;
					case 251:
						num5 = 6;
						goto IL_3F7E;
					case 252:
						goto IL_39A8;
					case 254:
						try
						{
							IEnumerator enumerator;
							while (WP6RZJql8gZrNhVA9v.ewZ3B8GFII2oOk3KXO(enumerator))
							{
								for (;;)
								{
									IL_3F04:
									ProcessModule processModule = (ProcessModule)WP6RZJql8gZrNhVA9v.oTcjQYPHTdNpOKif0G(enumerator);
									for (;;)
									{
										if (WP6RZJql8gZrNhVA9v.DiXRJpEwdIUvepcObv(WP6RZJql8gZrNhVA9v.jK2TOwkUhmLnnHUb6u(WP6RZJql8gZrNhVA9v.ywAggiNPXCMhKIlgTC(processModule)), "clrjit.dll"))
										{
											goto IL_3EA0;
										}
										int num17 = 5;
										if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
										{
											goto Block_281;
										}
										IL_3E38:
										Version version;
										switch (num17)
										{
										case 2:
											goto IL_3E1C;
										case 3:
											goto IL_3E09;
										case 4:
										case 5:
											goto IL_3F26;
										case 6:
											goto IL_3F04;
										case 7:
											continue;
										case 8:
											goto IL_3E7B;
										case 10:
											IL_3EA0:
											version = new Version(WP6RZJql8gZrNhVA9v.gfqjHD9ktuAv81yJeu(WP6RZJql8gZrNhVA9v.J5a8nm1HRWOQLFDo9S(processModule)), WP6RZJql8gZrNhVA9v.HutOr42o6jcXNEiaFt(WP6RZJql8gZrNhVA9v.J5a8nm1HRWOQLFDo9S(processModule)), WP6RZJql8gZrNhVA9v.wsq8JYndDHpXykO1eZ(WP6RZJql8gZrNhVA9v.J5a8nm1HRWOQLFDo9S(processModule)), WP6RZJql8gZrNhVA9v.GDKc1Y0YijcSpMv8FZ(WP6RZJql8gZrNhVA9v.J5a8nm1HRWOQLFDo9S(processModule)));
											goto IL_3E7B;
										case 12:
											goto IL_3F20;
										case 13:
											goto IL_3DED;
										}
										goto Block_279;
										IL_3DED:
										Version version2;
										if (WP6RZJql8gZrNhVA9v.LLU4PZx91pwM6AhMKu(version, version2))
										{
											goto IL_3F20;
										}
										num17 = 9;
										if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
										{
											goto IL_3E7B;
										}
										goto IL_3E38;
										IL_3E1C:
										Version version3;
										if (WP6RZJql8gZrNhVA9v.bFtxxQv53tSJCBLhwj(version, version3))
										{
											goto IL_3DED;
										}
										num17 = 0;
										if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
										{
											int num18;
											num17 = num18;
											goto IL_3E38;
										}
										goto IL_3E38;
										IL_3E09:
										version2 = new Version(4, 0, 30319, 17921);
										goto IL_3E1C;
										IL_3E7B:
										version3 = new Version(4, 0, 30319, 17020);
										num17 = 3;
										if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
										{
											goto IL_3E09;
										}
										goto IL_3E38;
									}
								}
								Block_279:
								Block_281:
								continue;
								IL_3F20:
								WP6RZJql8gZrNhVA9v.PRZkZqsNsa = true;
								IL_3F26:
								goto IL_0C16;
							}
							goto IL_3F26;
						}
						finally
						{
							IEnumerator enumerator;
							IDisposable disposable = enumerator as IDisposable;
							while (disposable == null)
							{
								int num19 = 1;
								if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
								{
									int num20;
									num19 = num20;
								}
								switch (num19)
								{
								case 0:
									goto IL_3F62;
								case 1:
								case 2:
									goto EndFinally_290;
								case 3:
									break;
								default:
									goto IL_3F62;
								}
							}
							IL_3F62:
							WP6RZJql8gZrNhVA9v.A3Yh5RFFFw06bojsfa(disposable);
							EndFinally_290:;
						}
						goto IL_3F6A;
					case 255:
						goto IL_3088;
					case 256:
						goto IL_229B;
					case 257:
						goto IL_3DC6;
					case 258:
						goto IL_247A;
					case 259:
						goto IL_2B45;
					case 260:
						goto IL_3802;
					case 261:
						goto IL_2942;
					case 262:
						num21 <<= 8;
						num2 = 490;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_174;
						}
						continue;
					case 263:
						goto IL_3C9C;
					case 264:
						array6[num8 + 7] = array3[7];
						num = 128;
						goto IL_3D99;
					case 265:
						num7 = 85;
						goto IL_33CC;
					case 266:
						goto IL_1B80;
					case 267:
						array10[2] = 99;
						num2 = 210;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
						{
							goto IL_1FFE;
						}
						continue;
					case 268:
						goto IL_1D3D;
					case 269:
						goto IL_1F81;
					case 270:
						goto IL_1FFE;
					case 271:
						goto IL_19CD;
					case 272:
						goto IL_1F8F;
					case 273:
						goto IL_1A6E;
					case 275:
						goto IL_1F4E;
					case 276:
						num21 = 0U;
						num2 = 284;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_172;
						}
						continue;
					case 277:
						goto IL_3D0F;
					case 278:
						goto IL_2250;
					case 279:
						goto IL_1C18;
					case 281:
						goto IL_24CA;
					case 282:
						IL_4683:
						WP6RZJql8gZrNhVA9v.r4I7EqhNy6xdDgjZqTE(WP6RZJql8gZrNhVA9v.abxkLGOVrU);
						goto IL_1270;
					case 283:
						goto IL_23AC;
					case 284:
					{
						int num22 = 0;
						goto IL_1E57;
					}
					case 285:
						array6[num8 + 2] = array3[2];
						num2 = 360;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_171;
						}
						continue;
					case 286:
						array6[num23 + 1] = array7[1];
						num2 = 146;
						if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_3D0F;
						}
						continue;
					case 287:
						goto IL_1270;
					case 288:
						goto IL_2AC9;
					case 289:
						num24 = (long)WP6RZJql8gZrNhVA9v.GWY1vnhwhFRByTHqG90(new IntPtr(num11));
						goto IL_1496;
					case 290:
						goto IL_3CCC;
					case 291:
						goto IL_1979;
					case 292:
						break;
					case 293:
						goto IL_2F74;
					case 294:
						goto IL_2EFD;
					case 295:
						goto IL_25CD;
					case 296:
						num25 += num26;
						num = 263;
						goto IL_3C9C;
					case 297:
					{
						WP6RZJql8gZrNhVA9v.BIpvxRBRb2dOGl802m bipvxRBRb2dOGl802m;
						WP6RZJql8gZrNhVA9v.kKd2fBhsYA0K0Yyxtft(WP6RZJql8gZrNhVA9v.lmdkVksVkh, 0L, bipvxRBRb2dOGl802m);
						goto IL_28D9;
					}
					case 298:
						goto IL_203D;
					case 299:
						goto IL_0E70;
					case 300:
						goto IL_277A;
					case 301:
						zero = IntPtr.Zero;
						num = 408;
						goto IL_3791;
					case 302:
						goto IL_1DC4;
					case 303:
						num5 = 55;
						goto IL_34FD;
					case 304:
						array2[5] = 170;
						num2 = 147;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_170;
						}
						continue;
					case 305:
						goto IL_3085;
					case 306:
						goto IL_217C;
					case 307:
					case 510:
						goto IL_31BA;
					case 308:
						goto IL_22C3;
					case 309:
						goto IL_1BE4;
					case 310:
						array7 = WP6RZJql8gZrNhVA9v.cxBgTlJNLn7Vsrekt7(WP6RZJql8gZrNhVA9v.Ehe0uhhX0aen13qwCxL(num24));
						num2 = 323;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_1284;
						}
						continue;
					case 311:
						goto IL_3BD3;
					case 312:
						goto IL_0D0B;
					case 313:
					{
						SymmetricAlgorithm symmetricAlgorithm;
						ICryptoTransform cryptoTransform = WP6RZJql8gZrNhVA9v.qgrAUuWmjXbCVLTFIo(symmetricAlgorithm, array15, array5);
						goto IL_39F3;
					}
					case 314:
						goto IL_1D20;
					case 315:
						array[10] = (byte)num5;
						goto IL_2CB0;
					case 316:
						goto IL_3559;
					case 317:
						goto IL_349C;
					case 318:
						goto IL_18A9;
					case 319:
						goto IL_3B17;
					case 320:
						goto IL_2352;
					case 321:
						goto IL_0EC6;
					case 323:
					case 624:
						goto IL_2243;
					case 324:
						array[28] = (byte)num7;
						goto IL_3B93;
					case 325:
						num12 = 0;
						num2 = 23;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_149D;
						}
						continue;
					case 326:
						array2[5] = 108;
						num2 = 304;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_164;
						}
						continue;
					case 327:
						goto IL_337D;
					case 328:
						goto IL_2D2F;
					case 329:
						goto IL_18DB;
					case 330:
						array[17] = 90;
						goto IL_3B38;
					case 331:
					{
						CryptoStream cryptoStream;
						WP6RZJql8gZrNhVA9v.Cv8hm26dWkilb1H7uG(cryptoStream);
						goto IL_3B17;
					}
					case 332:
						goto IL_3AFC;
					case 333:
						goto IL_1F32;
					case 334:
						goto IL_3263;
					case 335:
						goto IL_32B4;
					case 336:
						goto IL_1F98;
					case 337:
						goto IL_3ADF;
					case 338:
						goto IL_0C53;
					case 339:
						goto IL_19A3;
					case 341:
						goto IL_1C04;
					case 342:
						array[21] = (byte)num5;
						num2 = 524;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto Block_163;
						}
						continue;
					case 345:
						goto IL_38A2;
					case 346:
						WP6RZJql8gZrNhVA9v.GhTBkML7lWmHOUJLvu(WP6RZJql8gZrNhVA9v.Wqta94qIF2UoY3DUfP(vtNVUKGulysZw81C3E), 0L);
						num2 = 201;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_162;
						}
						continue;
					case 347:
					case 432:
						goto IL_1E5D;
					case 348:
						goto IL_2FB0;
					case 349:
						goto IL_2742;
					case 350:
						array2[12] = 225;
						num2 = 1;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_2BFB;
						}
						continue;
					case 351:
						goto IL_1416;
					case 352:
						goto IL_3A50;
					case 353:
						goto IL_38F5;
					case 354:
						goto IL_264B;
					case 355:
						goto IL_3A32;
					case 356:
						num10 = 143;
						num2 = 623;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_158;
						}
						continue;
					case 357:
						goto IL_1A48;
					case 358:
						goto IL_39F3;
					case 359:
						goto IL_0DF8;
					case 360:
						array6[num8 + 3] = array3[3];
						num2 = 138;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_156;
						}
						continue;
					case 361:
						goto IL_0043;
					case 362:
						goto IL_0D64;
					case 363:
						goto IL_1E12;
					case 364:
						goto IL_1BA9;
					case 365:
						array8[num13 + 2] = (byte)((num14 & 16711680U) >> 16);
						goto IL_2840;
					case 366:
						goto IL_2F88;
					case 367:
						goto IL_2786;
					case 368:
						goto IL_190D;
					case 369:
						goto IL_25DB;
					case 370:
						num7 = 120;
						goto IL_39A8;
					case 371:
						goto IL_240B;
					case 372:
						goto IL_2CE3;
					case 373:
					case 378:
						goto IL_3964;
					case 374:
						array2[8] = 153;
						num2 = 65;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_155;
						}
						continue;
					case 375:
						goto IL_1CA9;
					case 376:
						goto IL_0ECF;
					case 377:
						goto IL_2E04;
					case 379:
						goto IL_0009;
					case 380:
						array[1] = (byte)num7;
						goto IL_393A;
					case 381:
						num10 = 158;
						goto IL_2B84;
					case 382:
						goto IL_2739;
					case 383:
						goto IL_2223;
					case 384:
						goto IL_38E7;
					case 385:
						goto IL_2AD4;
					case 387:
						goto IL_3873;
					case 388:
						goto IL_3478;
					case 389:
						goto IL_3393;
					case 390:
						goto IL_2E53;
					case 391:
						goto IL_20C6;
					case 392:
						goto IL_1A8C;
					case 393:
						goto IL_3129;
					case 394:
						array[0] = (byte)num7;
						num2 = 9;
						if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_373C;
						}
						continue;
					case 395:
						goto IL_0B9D;
					case 396:
						array[29] = (byte)num7;
						goto IL_382C;
					case 397:
						goto IL_2C26;
					case 398:
						goto IL_281B;
					case 399:
						goto IL_37B0;
					case 400:
						array[5] = 97;
						goto IL_30A8;
					case 401:
						goto IL_2707;
					case 402:
						goto IL_37F9;
					case 403:
						goto IL_37CA;
					case 404:
						goto IL_141F;
					case 405:
						array2[5] = (byte)num10;
						num = 399;
						goto IL_37B0;
					case 406:
						goto IL_1B24;
					case 407:
						goto IL_2F7A;
					case 408:
						goto IL_3791;
					case 409:
						goto IL_2D8D;
					case 410:
					{
						string text;
						IntPtr procAddress = WP6RZJql8gZrNhVA9v.GetProcAddress(intPtr, text);
						num2 = 4;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto IL_3778;
						}
						continue;
					}
					case 411:
						goto IL_0EAB;
					case 412:
					case 466:
						goto IL_1B53;
					case 413:
						goto IL_373C;
					case 414:
						goto IL_0C6C;
					case 415:
						array2[1] = 97;
						goto IL_371B;
					case 416:
					{
						uint num27 = num25;
						uint num28 = num25;
						num28 ^= num28 << 5;
						num28 += 302943564U;
						num28 ^= num28 >> 27;
						num28 += 1324893550U;
						num28 ^= num28 << 25;
						num28 += 3021403202U;
						num28 = 1041728946U - num28;
						num25 = num27 + (uint)num28;
						num2 = 3;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto Block_143;
						}
						continue;
					}
					case 417:
						goto IL_3016;
					case 418:
						goto IL_3553;
					case 419:
						goto IL_30AE;
					case 420:
						goto IL_33EE;
					case 421:
						goto IL_2D95;
					case 422:
						array[17] = 112;
						num2 = 330;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto Block_142;
						}
						continue;
					case 423:
						goto IL_363F;
					case 424:
						array11[3] = 74;
						goto IL_35EF;
					case 425:
						goto IL_1BF6;
					case 426:
						goto IL_2CD7;
					case 427:
						goto IL_26B0;
					case 428:
						goto IL_1AEF;
					case 429:
						array[4] = 86;
						goto IL_330C;
					case 430:
						goto IL_3603;
					case 431:
						goto IL_33EA;
					case 433:
						goto IL_2EC9;
					case 434:
						goto IL_35EF;
					case 435:
						goto IL_1C52;
					case 436:
						goto IL_2F97;
					case 437:
						goto IL_0B86;
					case 438:
						goto IL_35DC;
					case 439:
						goto IL_1CBE;
					case 440:
						num10 = 62;
						goto IL_35B9;
					case 441:
						goto IL_12A5;
					case 442:
						goto IL_2CF5;
					case 443:
						goto IL_3244;
					case 444:
						goto IL_252B;
					case 445:
						goto IL_1ED8;
					case 446:
						goto IL_1CF4;
					case 447:
						goto IL_0E33;
					case 448:
						num7 = 7;
						num2 = 396;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_139;
						}
						continue;
					case 449:
						goto IL_2263;
					case 450:
						goto IL_2C66;
					case 451:
					{
						int num3;
						num13 = num3 * 4;
						goto IL_3553;
					}
					case 452:
						goto IL_2133;
					case 453:
						goto IL_1320;
					case 454:
					case 598:
						goto IL_2632;
					case 455:
						num10 = 136;
						num2 = 405;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_137;
						}
						continue;
					case 456:
						goto IL_323D;
					case 457:
						IL_4678:
						WP6RZJql8gZrNhVA9v.abxkLGOVrU = null;
						goto IL_17A7;
					case 458:
						goto IL_34FD;
					case 459:
						goto IL_2482;
					case 460:
						goto IL_12CC;
					case 461:
						goto IL_20D4;
					case 462:
						goto IL_242A;
					case 463:
						goto IL_2C32;
					case 464:
						goto IL_2C50;
					case 465:
						goto IL_2311;
					case 467:
					case 603:
						goto IL_2541;
					case 468:
						goto IL_200D;
					case 469:
						array[2] = (byte)num5;
						num2 = 83;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto Block_135;
						}
						continue;
					case 470:
						goto IL_2E0A;
					case 471:
						num5 = 140;
						num2 = 157;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
						{
							goto IL_3478;
						}
						continue;
					case 472:
						num29 = intPtr2.ToInt64();
						num2 = 571;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_134;
						}
						continue;
					case 473:
						goto IL_3425;
					case 474:
						goto IL_226C;
					case 475:
						goto IL_2730;
					case 476:
						if (WP6RZJql8gZrNhVA9v.DQB5bVrQeRYfHVIf8P(WP6RZJql8gZrNhVA9v.HVtG6OVrH4GYduNgRb(WP6RZJql8gZrNhVA9v.x4Dk2IHVmX)) == 0)
						{
							goto IL_1DBD;
						}
						goto IL_1DC4;
					case 477:
						goto IL_1E9A;
					case 478:
						array6[num23 + 3] = array3[3];
						goto IL_33EA;
					case 479:
						goto IL_33CC;
					case 480:
						goto IL_336E;
					case 481:
						WP6RZJql8gZrNhVA9v.rNZkehfwNu = new WP6RZJql8gZrNhVA9v.QZEOeHRUkDiNqCWT0p(WP6RZJql8gZrNhVA9v.NvQ34uZt895nxEhi2FIr);
						num2 = 639;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto Block_131;
						}
						continue;
					case 482:
						array[22] = (byte)num5;
						goto IL_336E;
					case 483:
					case 555:
						goto IL_28EC;
					case 484:
						goto IL_1A04;
					case 485:
					{
						int num4;
						num4++;
						goto IL_2E6E;
					}
					case 486:
						goto IL_308B;
					case 487:
						IL_2F2B:
						if (!WP6RZJql8gZrNhVA9v.pUG76uHlOlctFe7FPk(WP6RZJql8gZrNhVA9v.VbSEbDAwwZE4mU3b6d("System.Reflection.ReflectionContext", false), null))
						{
							goto IL_0C16;
						}
						num2 = 97;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_113;
						}
						continue;
					case 488:
						goto IL_3339;
					case 489:
						array6[num8 + 3] = array7[3];
						num = 667;
						goto IL_139F;
					case 490:
						goto IL_1EB2;
					case 491:
						goto IL_2028;
					case 492:
						goto IL_31EB;
					case 493:
						goto IL_330C;
					case 494:
						goto IL_1FEA;
					case 495:
						goto IL_1DE2;
					case 496:
						goto IL_1DD6;
					case 497:
						goto IL_30DA;
					case 498:
						goto IL_2A60;
					case 499:
						goto IL_1C27;
					case 500:
					{
						IntPtr intPtr3;
						num11 = (long)WP6RZJql8gZrNhVA9v.GWY1vnhwhFRByTHqG90(intPtr3);
						num2 = 598;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_130;
						}
						continue;
					}
					case 501:
						goto IL_2BDD;
					case 502:
						goto IL_0E7E;
					case 503:
						goto IL_32A6;
					case 504:
						goto IL_1CFA;
					case 505:
						WP6RZJql8gZrNhVA9v.lmdkVksVkh = new Hashtable(WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E) + 1);
						goto IL_3299;
					case 506:
						goto IL_322F;
					case 507:
						goto IL_0BED;
					case 508:
						array2[3] = (byte)num10;
						num2 = 637;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto IL_2BB4;
						}
						continue;
					case 509:
					{
						bool flag;
						bipvxRBRb2dOGl802m2.JDNkifbo3S = flag;
						goto IL_31EB;
					}
					case 511:
						goto IL_236A;
					case 512:
						goto IL_31A6;
					case 513:
						goto IL_316D;
					case 514:
						goto IL_1D2E;
					case 515:
						goto IL_1D17;
					case 516:
						goto IL_3149;
					case 518:
						array6[num8] = array13[0];
						goto IL_3129;
					case 519:
						goto IL_30FC;
					case 520:
						goto IL_27C6;
					case 521:
					{
						int num30 = WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E);
						goto IL_30DA;
					}
					case 522:
						goto IL_30A8;
					case 523:
						goto IL_3082;
					case 524:
						num7 = 164;
						num2 = 41;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
						{
							goto IL_3039;
						}
						continue;
					case 525:
						num5 = 41;
						num2 = 7;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto IL_1C30;
						}
						continue;
					case 526:
						goto IL_3039;
					case 527:
						goto IL_2FED;
					case 528:
						num31++;
						num = 280;
						goto IL_2DF0;
					case 529:
						goto IL_23AF;
					case 530:
						goto IL_250D;
					case 531:
						goto IL_2969;
					case 532:
						goto IL_2FCD;
					case 533:
						goto IL_0D73;
					case 534:
						goto IL_2F56;
					case 535:
						goto IL_194A;
					case 536:
						WP6RZJql8gZrNhVA9v.JujIUwQla0VMlNrhaS();
						num = 433;
						goto IL_2EC9;
					case 537:
						goto IL_2EA0;
					case 538:
						array2[4] = 86;
						num = 543;
						goto IL_2DD4;
					case 539:
						goto IL_2DFE;
					case 540:
						goto IL_2E6E;
					case 541:
						goto IL_2E44;
					case 542:
						array[17] = 57;
						goto IL_18A0;
					case 543:
						goto IL_2DD4;
					case 544:
						goto IL_1E26;
					case 545:
						num7 = 111;
						num2 = 191;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto Block_105;
						}
						continue;
					case 546:
						goto IL_0034;
					case 547:
						goto IL_2D76;
					case 548:
						goto IL_12B6;
					case 549:
						goto IL_1DCD;
					case 550:
						num5 = 104;
						goto IL_2D53;
					case 551:
						goto IL_2CC9;
					case 552:
						goto IL_1EEB;
					case 553:
						goto IL_2CB0;
					case 554:
						goto IL_0019;
					case 556:
						goto IL_2C84;
					case 557:
						goto IL_13D3;
					case 558:
						goto IL_2925;
					case 559:
						bipvxRBRb2dOGl802m2 = default(WP6RZJql8gZrNhVA9v.BIpvxRBRb2dOGl802m);
						goto IL_2C66;
					case 560:
					{
						MemoryStream memoryStream = new MemoryStream();
						goto IL_2C26;
					}
					case 561:
						goto IL_2BB4;
					case 562:
						goto IL_2BA7;
					case 563:
						goto IL_0B2B;
					case 564:
						goto IL_2599;
					case 565:
						goto IL_2B84;
					case 566:
						WP6RZJql8gZrNhVA9v.dTiCsUt8bdAoavmBNv(new IntPtr((void*)(&num9)), 0, IntPtr.Zero);
						num2 = 104;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_2B2D;
						}
						continue;
					case 567:
					{
						WP6RZJql8gZrNhVA9v.BIpvxRBRb2dOGl802m bipvxRBRb2dOGl802m;
						bipvxRBRb2dOGl802m.JDNkifbo3S = false;
						num2 = 297;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_96;
						}
						continue;
					}
					case 568:
						goto IL_2A83;
					case 569:
						goto IL_2A57;
					case 570:
						goto IL_29FB;
					case 571:
						num32 = 0;
						num = 646;
						goto IL_1D99;
					case 572:
						array[1] = (byte)num7;
						goto IL_29CF;
					case 573:
						goto IL_27D7;
					case 574:
						goto IL_227A;
					case 575:
						goto IL_26BF;
					case 576:
						goto IL_298C;
					case 577:
						goto IL_2963;
					case 578:
						goto IL_28D9;
					case 579:
						goto IL_28CE;
					case 580:
						goto IL_2887;
					case 581:
						goto IL_2877;
					case 582:
						goto IL_2840;
					case 583:
						goto IL_27BE;
					case 584:
						goto IL_0CA0;
					case 585:
					case 662:
						goto IL_1496;
					case 586:
						array10[0] = 99;
						goto IL_1F48;
					case 587:
						goto IL_0B78;
					case 588:
						goto IL_276C;
					case 589:
						goto IL_2143;
					case 590:
						goto IL_26EF;
					case 591:
						goto IL_0BDE;
					case 592:
						goto IL_2109;
					case 593:
						goto IL_0F28;
					case 594:
						array[0] = 35;
						goto IL_26B0;
					case 595:
						goto IL_1A5F;
					case 596:
						array[30] = (byte)num5;
						goto IL_2684;
					case 597:
						goto IL_2656;
					case 599:
						goto IL_1ABE;
					case 600:
					{
						int num33;
						num33++;
						goto IL_246E;
					}
					case 601:
						goto IL_2604;
					case 602:
						goto IL_25C4;
					case 605:
					{
						int num34 = WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E) - num35;
						goto IL_23A3;
					}
					case 606:
					{
						int num3 = 0;
						goto IL_24E1;
					}
					case 607:
						goto IL_249F;
					case 608:
						goto IL_1DFF;
					case 609:
						goto IL_246B;
					case 610:
						goto IL_2451;
					case 611:
						goto IL_241C;
					case 612:
						intPtr2 = WP6RZJql8gZrNhVA9v.kZQ8dAyUfWnWWqJUp8(WP6RZJql8gZrNhVA9v.DR9AZjjdNREcZwIYAb(WP6RZJql8gZrNhVA9v.x4Dk2IHVmX)[0]);
						goto IL_240B;
					case 613:
						goto IL_1FB8;
					case 614:
						goto IL_23ED;
					case 615:
						goto IL_23A3;
					case 616:
						goto IL_1B30;
					case 617:
						goto IL_2347;
					case 618:
						goto IL_1A1B;
					case 619:
						array6[num8 + 2] = array13[2];
						num2 = 163;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto IL_22E0;
						}
						continue;
					case 620:
						goto IL_1C44;
					case 621:
						num36 = 255U;
						num2 = 121;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
						{
							goto IL_22C3;
						}
						continue;
					case 622:
						goto IL_2295;
					case 623:
						array2[13] = (byte)num10;
						goto IL_2263;
					case 625:
						goto IL_221A;
					case 626:
						goto IL_21F9;
					case 627:
						goto IL_21DE;
					case 628:
						goto IL_21B2;
					case 629:
						goto IL_2197;
					case 630:
						WP6RZJql8gZrNhVA9v.YeeoMqaS3J(intPtr4, 4, num32, ref num32);
						goto IL_217C;
					case 631:
						goto IL_212D;
					case 632:
						goto IL_20F5;
					case 633:
						goto IL_1E76;
					case 634:
						num5 = 104;
						goto IL_20C6;
					case 636:
						goto IL_20A2;
					case 637:
						array2[4] = 114;
						num2 = 538;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_48;
						}
						continue;
					case 638:
						goto IL_205D;
					case 639:
						intPtr5 = IntPtr.Zero;
						num = 491;
						goto IL_2028;
					case 640:
						goto IL_1FDF;
					case 641:
						goto IL_1FCB;
					case 642:
						goto IL_1D52;
					case 643:
						goto IL_1C3E;
					case 644:
						goto IL_1F69;
					case 645:
						goto IL_1F24;
					case 646:
						goto IL_1D99;
					case 647:
						WP6RZJql8gZrNhVA9v.xo4kuDarJK = false;
						num2 = 153;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_34;
						}
						continue;
					case 648:
						goto IL_1AFB;
					case 649:
						goto IL_1CE6;
					case 650:
						goto IL_1C8E;
					case 651:
						goto IL_1C73;
					case 652:
						goto IL_1BCC;
					case 653:
						goto IL_1AB1;
					case 654:
						array[11] = 91;
						goto IL_1A42;
					case 655:
						array[23] = 126;
						goto IL_19CD;
					case 656:
						array[0] = 122;
						goto IL_19A3;
					case 657:
						goto IL_0B8F;
					case 658:
						goto IL_196D;
					case 659:
						goto IL_18FF;
					case 660:
						goto IL_18E1;
					case 661:
						goto IL_18A0;
					case 663:
						array[29] = (byte)num5;
						num2 = 448;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto Block_16;
						}
						continue;
					case 664:
						goto IL_1460;
					case 665:
						array2[1] = 174;
						num2 = 197;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
						{
							goto IL_1416;
						}
						continue;
					case 666:
						goto IL_13BF;
					case 667:
						goto IL_139F;
					case 668:
						array[25] = 99;
						goto IL_136B;
					case 669:
						goto IL_133C;
					case 670:
						goto IL_1319;
					case 671:
						array2[9] = 149;
						goto IL_0EAB;
					case 672:
						goto IL_0E51;
					case 673:
						array[14] = 134;
						goto IL_0D64;
					case 674:
						num5 = 150;
						goto IL_0D32;
					case 675:
						goto IL_0C16;
					case 676:
						goto IL_0B58;
					case 677:
						goto IL_0B03;
					default:
						goto IL_2BFB;
					}
					IL_0B31:
					array[26] = (byte)num7;
					num2 = 145;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_0BA6:
					array[13] = (byte)num5;
					num2 = 251;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						goto IL_0BC4;
					}
					continue;
					IL_0B9D:
					num5 = 132;
					goto IL_0BA6;
					IL_0B8F:
					array[13] = (byte)num5;
					goto IL_0B9D;
					IL_0B86:
					num5 = 144;
					goto IL_0B8F;
					IL_0B78:
					array[13] = (byte)num7;
					goto IL_0B86;
					IL_0B66:
					num7 = 128;
					num = 587;
					goto IL_0B78;
					IL_0B58:
					array[13] = (byte)num7;
					goto IL_0B66;
					IL_1AA3:
					num7 = 206;
					goto IL_0B58;
					IL_1A8C:
					array[13] = (byte)num5;
					num = 73;
					goto IL_1AA3;
					IL_1A86:
					num5 = 110;
					goto IL_1A8C;
					IL_1A7A:
					array[12] = 80;
					goto IL_1A86;
					IL_1A6E:
					array[12] = 112;
					goto IL_1A7A;
					IL_1A5F:
					array[12] = 166;
					goto IL_1A6E;
					IL_1A48:
					array[12] = (byte)num7;
					num = 595;
					goto IL_1A5F;
					IL_1A42:
					num7 = 126;
					goto IL_1A48;
					IL_0BF3:
					array[4] = (byte)num5;
					num2 = 634;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_0BED:
					num5 = 92;
					goto IL_0BF3;
					IL_0BDE:
					array[3] = 218;
					goto IL_0BED;
					IL_0BD2:
					array[3] = 66;
					goto IL_0BDE;
					IL_0BC4:
					array[3] = (byte)num5;
					goto IL_0BD2;
					IL_28CE:
					num5 = 106;
					goto IL_0BC4;
					IL_0C16:
					vtNVUKGulysZw81C3E = new WP6RZJql8gZrNhVA9v.VtNVUKGulysZw81C3E(WP6RZJql8gZrNhVA9v.T7nuDZ5OSGQU84pSUt(WP6RZJql8gZrNhVA9v.x4Dk2IHVmX, "q6IevjT37XvTQ9GOTR.QxNhac1QlK0N5pJp0C"));
					num2 = 346;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_0C3C;
					}
					continue;
					IL_2F17:
					if (WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas() == 4)
					{
						num = 487;
						goto IL_2F2B;
					}
					goto IL_0C16;
					IL_2EF9:
					bool flag2;
					if (!flag2)
					{
						goto IL_2EFD;
					}
					goto IL_2F17;
					IL_2ED2:
					flag2 = WP6RZJql8gZrNhVA9v.sQlfTBBY0H5wIm9Z3H(WP6RZJql8gZrNhVA9v.AJ6GN7KcvthHuwjypR(WP6RZJql8gZrNhVA9v.UAJlX83FojikbWHemo(WP6RZJql8gZrNhVA9v.bm1fQjZhZNHsQkRyOn(WP6RZJql8gZrNhVA9v.KmKeX0bgSXhq1fq28N())), "__", 10U), IntPtr.Zero);
					goto IL_2EF9;
					IL_2EC9:
					if (num37 == 76360321U)
					{
						goto IL_2ED2;
					}
					goto IL_2F17;
					IL_0C7B:
					array11[1] = 101;
					num2 = 115;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						goto IL_0C91;
					}
					continue;
					IL_0C6C:
					array11[0] = 103;
					num = 105;
					goto IL_0C7B;
					IL_0C64:
					array11 = new byte[6];
					goto IL_0C6C;
					IL_0C53:
					if (!WP6RZJql8gZrNhVA9v.eBS39ohdQ8KmmbnPINx(intPtr, IntPtr.Zero))
					{
						goto IL_0C64;
					}
					goto IL_0D0B;
					IL_0C4A:
					string text2;
					intPtr = WP6RZJql8gZrNhVA9v.LoadLibrary(text2);
					goto IL_0C53;
					IL_0C3C:
					text2 = WP6RZJql8gZrNhVA9v.eTgynxhtgEVcRlyJcRL(WP6RZJql8gZrNhVA9v.A1Ju77hCr9O8h9Qmym6(), array10);
					goto IL_0C4A;
					IL_0CAC:
					array[24] = 138;
					num2 = 201;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
					{
						goto IL_0CCB;
					}
					continue;
					IL_0CA0:
					array[24] = 100;
					goto IL_0CAC;
					IL_0C91:
					array[24] = 141;
					goto IL_0CA0;
					IL_0CCB:
					array[24] = 111;
					num2 = 25;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						continue;
					}
					IL_0CE7:
					array[25] = 148;
					num2 = 668;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_0D0B:
					array10 = new byte[10];
					num2 = 586;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_0D32:
					array[18] = (byte)num5;
					num2 = 525;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_0D7C:
					array[15] = (byte)num5;
					num2 = 102;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						goto IL_0D9A;
					}
					continue;
					IL_0D73:
					num5 = 144;
					goto IL_0D7C;
					IL_0D64:
					array[14] = 197;
					goto IL_0D73;
					IL_0DB8:
					num7 = 251;
					num2 = 106;
					if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_0DD1;
					}
					continue;
					IL_0DA9:
					array[27] = 150;
					goto IL_0DB8;
					IL_0D9A:
					array[27] = 152;
					goto IL_0DA9;
					IL_0DD1:
					array[27] = (byte)num7;
					num2 = 112;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
					{
						goto IL_0DEF;
					}
					continue;
					IL_0E06:
					array[28] = 133;
					num2 = 370;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						goto IL_0E25;
					}
					continue;
					IL_0DF8:
					array[28] = (byte)num7;
					goto IL_0E06;
					IL_0DEF:
					num7 = 150;
					goto IL_0DF8;
					IL_0E33:
					num5 = 204;
					num2 = 156;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_0E25:
					array[8] = (byte)num5;
					goto IL_0E33;
					IL_0E51:
					array10[5] = 106;
					num2 = 87;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						goto IL_0E67;
					}
					continue;
					IL_200D:
					array10[4] = 114;
					goto IL_0E51;
					IL_1FFE:
					array10[3] = 111;
					num = 468;
					goto IL_200D;
					IL_0E7E:
					num7 = 168;
					num2 = 209;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_0E70:
					array[14] = (byte)num7;
					goto IL_0E7E;
					IL_0E67:
					num7 = 166;
					goto IL_0E70;
					IL_1460:
					array[14] = (byte)num7;
					goto IL_0E67;
					IL_23ED:
					num7 = 42;
					goto IL_1460;
					IL_0ECF:
					array2[9] = (byte)num6;
					num2 = 108;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_0EED;
					}
					continue;
					IL_0EC6:
					num6 = 138;
					goto IL_0ECF;
					IL_0EB7:
					array2[9] = 142;
					goto IL_0EC6;
					IL_0EAB:
					array2[9] = 77;
					goto IL_0EB7;
					IL_0EED:
					array[16] = 70;
					num2 = 542;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_0F09;
					}
					continue;
					IL_1FB8:
					array[16] = (byte)num5;
					goto IL_0EED;
					IL_1FA6:
					num5 = 168;
					num = 613;
					goto IL_1FB8;
					IL_1F98:
					array[16] = (byte)num5;
					goto IL_1FA6;
					IL_1F8F:
					num5 = 159;
					goto IL_1F98;
					IL_1F81:
					array[16] = (byte)num5;
					goto IL_1F8F;
					IL_1F78:
					num5 = 218;
					goto IL_1F81;
					IL_1F69:
					array[15] = 128;
					goto IL_1F78;
					IL_31A6:
					array[15] = 156;
					goto IL_1F69;
					IL_436B:
					array[15] = 51;
					goto IL_31A6;
					IL_446F:
					array[15] = (byte)num7;
					goto IL_436B;
					IL_1300:
					byte[] array16;
					array6 = array16;
					num2 = 154;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_12E9:
					IntPtr intPtr6 = WP6RZJql8gZrNhVA9v.oq8Sffh95Uc0CDKB2bl(IntPtr.Zero, (uint)array16.Length, 4096U, 64U);
					goto IL_1300;
					IL_12CC:
					byte[] array17 = new byte[30];
					WP6RZJql8gZrNhVA9v.IiGW2uh1LxBvU8RVDfb(array17, fieldof(<PrivateImplementationDetails>{3CC8B112-5F4D-4500-A029-1EC2153D1631}.$$method0x6000332-2).FieldHandle);
					array16 = array17;
					num = 167;
					goto IL_12E9;
					IL_12A5:
					if (WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas() != 4)
					{
						num = 548;
						goto IL_12B6;
					}
					goto IL_12CC;
					IL_12A2:
					array16 = null;
					goto IL_12A5;
					IL_128E:
					WP6RZJql8gZrNhVA9v.BTPZm9hE4v9u1uh1YUy(WP6RZJql8gZrNhVA9v.VMlvEXhkVXM5aaWaEAF(WP6RZJql8gZrNhVA9v.JR8JqwhBOfTB1T9vhCR(WP6RZJql8gZrNhVA9v.rNZkehfwNu)));
					goto IL_12A2;
					IL_1284:
					WP6RZJql8gZrNhVA9v.r4I7EqhNy6xdDgjZqTE(WP6RZJql8gZrNhVA9v.rNZkehfwNu);
					goto IL_128E;
					IL_1270:
					WP6RZJql8gZrNhVA9v.BTPZm9hE4v9u1uh1YUy(WP6RZJql8gZrNhVA9v.VMlvEXhkVXM5aaWaEAF(WP6RZJql8gZrNhVA9v.JR8JqwhBOfTB1T9vhCR(WP6RZJql8gZrNhVA9v.abxkLGOVrU)));
					goto IL_1284;
					Block_8:
					try
					{
						IL_0F28:
						object obj = WP6RZJql8gZrNhVA9v.Nl7gdFhc9Q7mOSua7Px(WP6RZJql8gZrNhVA9v.Nhga6qhMTaiRlHe59Ab(WP6RZJql8gZrNhVA9v.f2EUdrhH7hx8TLHQiVt(WP6RZJql8gZrNhVA9v.gDkHBghANO2HqDrQPy0(WP6RZJql8gZrNhVA9v.HMmDSchYhBi0nCBpGT7(typeof(WP6RZJql8gZrNhVA9v).TypeHandle).Assembly))).GetField("m_ptr", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), WP6RZJql8gZrNhVA9v.f2EUdrhH7hx8TLHQiVt(WP6RZJql8gZrNhVA9v.gDkHBghANO2HqDrQPy0(WP6RZJql8gZrNhVA9v.HMmDSchYhBi0nCBpGT7(typeof(WP6RZJql8gZrNhVA9v).TypeHandle).Assembly)));
						int num38 = 18;
						byte[] array18;
						for (;;)
						{
							IL_1162:
							if (!(obj is IntPtr))
							{
								goto IL_1133;
							}
							int num39 = 13;
							if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
							{
								goto IL_1110;
							}
							MemoryStream memoryStream2;
							for (;;)
							{
								IL_10BD:
								switch (num39)
								{
								case 0:
									goto IL_10A2;
								case 1:
									if (WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas() == 4)
									{
										num38 = 14;
										goto IL_1007;
									}
									goto IL_1072;
								case 2:
								case 10:
									goto IL_0FAE;
								case 3:
									goto IL_0F8A;
								case 4:
									goto IL_1133;
								case 5:
									goto IL_124B;
								case 6:
								case 9:
									goto IL_102F;
								case 7:
									goto IL_1046;
								case 8:
									goto IL_105D;
								case 11:
									goto IL_1072;
								case 12:
									goto IL_116E;
								case 13:
									goto IL_1116;
								case 14:
									goto IL_1007;
								case 15:
									goto IL_0FBE;
								case 16:
									goto IL_1171;
								case 17:
									break;
								case 18:
									goto IL_1162;
								default:
									goto IL_10A2;
								}
								IL_0FE9:
								array18 = WP6RZJql8gZrNhVA9v.jnvtq3iCx4OYoUINoA(memoryStream2);
								num39 = 0;
								if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
								{
									goto Block_211;
								}
								continue;
								IL_105D:
								WP6RZJql8gZrNhVA9v.GhTBkML7lWmHOUJLvu(memoryStream2, 0L);
								goto IL_0FE9;
								IL_1046:
								WP6RZJql8gZrNhVA9v.HFqeTCUXpiOtLfNHOS(memoryStream2, new byte[WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas()], 0, WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas());
								goto IL_105D;
								IL_102F:
								WP6RZJql8gZrNhVA9v.HFqeTCUXpiOtLfNHOS(memoryStream2, new byte[WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas()], 0, WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas());
								goto IL_1046;
								IL_1072:
								WP6RZJql8gZrNhVA9v.HFqeTCUXpiOtLfNHOS(memoryStream2, WP6RZJql8gZrNhVA9v.O5H60QhPORn2lsaWULs(WP6RZJql8gZrNhVA9v.VE2k4S5okQ.ToInt64()), 0, 8);
								goto IL_102F;
								IL_1007:
								WP6RZJql8gZrNhVA9v.HFqeTCUXpiOtLfNHOS(memoryStream2, WP6RZJql8gZrNhVA9v.cxBgTlJNLn7Vsrekt7(WP6RZJql8gZrNhVA9v.VE2k4S5okQ.ToInt32()), 0, 4);
								num39 = 5;
								if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
								{
									goto IL_102F;
								}
								continue;
								IL_10A2:
								WP6RZJql8gZrNhVA9v.Cv8hm26dWkilb1H7uG(memoryStream2);
								num39 = 0;
								if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
								{
									goto Block_213;
								}
							}
							IL_1116:
							WP6RZJql8gZrNhVA9v.VE2k4S5okQ = (IntPtr)obj;
							goto IL_1133;
							Block_211:
							goto IL_1110;
							IL_0FBE:
							WP6RZJql8gZrNhVA9v.HFqeTCUXpiOtLfNHOS(memoryStream2, new byte[WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas()], 0, WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas());
							num39 = 1;
							if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
							{
								goto IL_1110;
							}
							goto IL_10BD;
							IL_0FAE:
							memoryStream2 = new MemoryStream();
							num38 = 15;
							goto IL_0FBE;
							IL_0F8A:
							WP6RZJql8gZrNhVA9v.VE2k4S5okQ = (IntPtr)WP6RZJql8gZrNhVA9v.Nl7gdFhc9Q7mOSua7Px(obj.GetType().GetField("m_pData", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic), obj);
							goto IL_0FAE;
							IL_1133:
							if (WP6RZJql8gZrNhVA9v.DiXRJpEwdIUvepcObv(obj.GetType().ToString(), "System.Reflection.RuntimeModule"))
							{
								goto IL_0F8A;
							}
							num39 = 2;
							if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
							{
								goto IL_10BD;
							}
							IL_1110:
							num39 = num38;
							goto IL_10BD;
						}
						Block_213:
						IL_116E:
						uint num40 = 0U;
						IL_1171:
						try
						{
							if ((array4 = array18) == null)
							{
								goto IL_1213;
							}
							int num41 = 3;
							if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
							{
								goto IL_11A2;
							}
							byte* ptr;
							for (;;)
							{
								IL_11F0:
								switch (num41)
								{
								case 1:
									goto IL_1213;
								case 2:
								case 5:
									WP6RZJql8gZrNhVA9v.rNZkehfwNu(new IntPtr((void*)ptr), new IntPtr((void*)ptr), new IntPtr((void*)ptr), 216669565U, new IntPtr((void*)ptr), ref num40);
									num41 = 0;
									if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
									{
										continue;
									}
									break;
								case 3:
									if (array4.Length != 0)
									{
										goto IL_118B;
									}
									goto IL_1213;
								case 4:
								case 6:
									goto IL_118B;
								}
								break;
								IL_118B:
								fixed (byte* ptr = &array4[0])
								{
									num41 = 5;
									if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
									{
										goto IL_11A2;
									}
								}
							}
							goto IL_124B;
							IL_11A2:
							int num42;
							num41 = num42;
							goto IL_11F0;
							IL_1213:
							ptr = null;
							num41 = 2;
							if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
							{
								goto IL_11A2;
							}
							goto IL_11F0;
						}
						finally
						{
							byte* ptr = null;
							int num43 = 0;
							if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
							{
								int num44;
								num43 = num44;
							}
							switch (num43)
							{
							}
						}
						IL_124B:
						goto IL_4683;
					}
					catch
					{
						int num45 = 0;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							int num46;
							num45 = num46;
						}
						switch (num45)
						{
						default:
							goto IL_4683;
						}
					}
					goto IL_1270;
					IL_0F09:
					if (WP6RZJql8gZrNhVA9v.DQB5bVrQeRYfHVIf8P(WP6RZJql8gZrNhVA9v.HVtG6OVrH4GYduNgRb(WP6RZJql8gZrNhVA9v.HMmDSchYhBi0nCBpGT7(typeof(WP6RZJql8gZrNhVA9v).TypeHandle).Assembly)) <= 0)
					{
						goto Block_8;
					}
					goto IL_4695;
					IL_3BD3:
					if (WP6RZJql8gZrNhVA9v.HVtG6OVrH4GYduNgRb(WP6RZJql8gZrNhVA9v.HMmDSchYhBi0nCBpGT7(typeof(WP6RZJql8gZrNhVA9v).TypeHandle).Assembly) != null)
					{
						goto IL_0F09;
					}
					num2 = 593;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_12B6:
					byte[] array19 = new byte[40];
					WP6RZJql8gZrNhVA9v.IiGW2uh1LxBvU8RVDfb(array19, fieldof(<PrivateImplementationDetails>{3CC8B112-5F4D-4500-A029-1EC2153D1631}.$$method0x6000332-1).FieldHandle);
					array16 = array19;
					goto IL_12E9;
					IL_1320:
					array10[11] = 108;
					num2 = 25;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_1319:
					array10[10] = 108;
					goto IL_1320;
					IL_2FCD:
					array10[9] = 100;
					goto IL_1319;
					IL_3AFC:
					array10[8] = 46;
					num = 532;
					goto IL_2FCD;
					IL_3FB4:
					array10[7] = 116;
					goto IL_3AFC;
					IL_133C:
					array[19] = (byte)num5;
					num2 = 56;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_264B:
					num5 = 89;
					goto IL_133C;
					IL_139F:
					array6[num8 + 4] = array7[4];
					num2 = 75;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_13D3:
					array2[9] = 186;
					num2 = 671;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_13C5:
					array2[8] = (byte)num10;
					goto IL_13D3;
					IL_13BF:
					num10 = 58;
					goto IL_13C5;
					IL_3873:
					array2[8] = 162;
					goto IL_13BF;
					IL_141F:
					array2[2] = (byte)num6;
					num2 = 440;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						goto IL_143D;
					}
					continue;
					IL_1416:
					num6 = 215;
					goto IL_141F;
					IL_143D:
					array[9] = (byte)num5;
					num2 = 92;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_3433:
					num5 = 136;
					goto IL_143D;
					IL_3425:
					array[9] = (byte)num5;
					goto IL_3433;
					IL_188B:
					num2 = 325;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_17A7:
					try
					{
						WP6RZJql8gZrNhVA9v.abxkLGOVrU = (WP6RZJql8gZrNhVA9v.QZEOeHRUkDiNqCWT0p)WP6RZJql8gZrNhVA9v.T5jTdMh84t7QTlT82Np(new IntPtr(num24), WP6RZJql8gZrNhVA9v.HMmDSchYhBi0nCBpGT7(typeof(WP6RZJql8gZrNhVA9v.QZEOeHRUkDiNqCWT0p).TypeHandle));
						int num47 = 0;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							int num48;
							num47 = num48;
						}
						switch (num47)
						{
						}
					}
					catch
					{
						int num49 = 0;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							int num50;
							num49 = num50;
						}
						switch (num49)
						{
						default:
							try
							{
								Delegate @delegate = WP6RZJql8gZrNhVA9v.T5jTdMh84t7QTlT82Np(new IntPtr(num24), WP6RZJql8gZrNhVA9v.HMmDSchYhBi0nCBpGT7(typeof(WP6RZJql8gZrNhVA9v.QZEOeHRUkDiNqCWT0p).TypeHandle));
								int num51 = 1;
								if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
								{
									goto IL_185B;
								}
								for (;;)
								{
									IL_185F:
									switch (num51)
									{
									default:
										goto IL_186C;
									case 1:
										WP6RZJql8gZrNhVA9v.abxkLGOVrU = (WP6RZJql8gZrNhVA9v.QZEOeHRUkDiNqCWT0p)WP6RZJql8gZrNhVA9v.tdcW58hfD532CID18nI(WP6RZJql8gZrNhVA9v.HMmDSchYhBi0nCBpGT7(typeof(WP6RZJql8gZrNhVA9v.QZEOeHRUkDiNqCWT0p).TypeHandle), WP6RZJql8gZrNhVA9v.JR8JqwhBOfTB1T9vhCR(@delegate));
										num51 = 0;
										if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
										{
											goto IL_185B;
										}
										break;
									}
								}
								IL_186C:
								break;
								IL_185B:
								int num52;
								num51 = num52;
								goto IL_185F;
							}
							catch
							{
								int num53 = 0;
								if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
								{
									switch (num53)
									{
									}
								}
							}
							break;
						case 1:
							break;
						}
					}
					goto IL_188B;
					Block_18:
					Process process;
					try
					{
						IL_1663:
						ProcessModuleCollection processModuleCollection2 = WP6RZJql8gZrNhVA9v.QXAPiWMFybI6qUa5Fy(process);
						int num54 = 0;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							int num55;
							num54 = num55;
						}
						IEnumerator enumerator;
						switch (num54)
						{
						default:
							enumerator = WP6RZJql8gZrNhVA9v.hRsR9gcWuuXGGEJDaX(processModuleCollection2);
							break;
						case 1:
							goto IL_1782;
						case 2:
							break;
						}
						try
						{
							for (;;)
							{
								if (WP6RZJql8gZrNhVA9v.ewZ3B8GFII2oOk3KXO(enumerator))
								{
									goto IL_16F7;
								}
								int num56 = 3;
								if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
								{
									goto Block_257;
								}
								for (;;)
								{
									IL_16D4:
									switch (num56)
									{
									case 1:
										goto IL_16BA;
									case 2:
										if (intPtr2.ToInt64() == WP6RZJql8gZrNhVA9v.eXJkjmTXDX)
										{
											num56 = 3;
											if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
											{
												goto Block_253;
											}
											continue;
										}
										break;
									case 3:
										goto IL_1731;
									case 4:
									case 5:
										goto IL_1734;
									case 6:
										goto IL_16F7;
									}
									break;
								}
								continue;
								IL_16BA:
								ProcessModule processModule2;
								intPtr2 = WP6RZJql8gZrNhVA9v.UAJlX83FojikbWHemo(processModule2);
								num56 = 2;
								if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
								{
									int num57;
									num56 = num57;
									goto IL_16D4;
								}
								goto IL_16D4;
								IL_16F7:
								processModule2 = (ProcessModule)WP6RZJql8gZrNhVA9v.oTcjQYPHTdNpOKif0G(enumerator);
								num56 = 0;
								if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
								{
									goto IL_16BA;
								}
								goto IL_16D4;
							}
							Block_253:
							goto IL_1731;
							Block_257:
							goto IL_1734;
							IL_1731:
							num35 = 0;
							IL_1734:;
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							int num58 = 0;
							if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
							{
								goto IL_1762;
							}
							for (;;)
							{
								IL_176E:
								switch (num58)
								{
								case 0:
									goto IL_1768;
								case 1:
									goto IL_1781;
								case 2:
									break;
								default:
									goto IL_1768;
								}
								IL_174E:
								WP6RZJql8gZrNhVA9v.A3Yh5RFFFw06bojsfa(disposable);
								num58 = 1;
								if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
								{
									goto IL_1762;
								}
								continue;
								IL_1768:
								if (disposable != null)
								{
									goto IL_174E;
								}
								break;
							}
							IL_1781:
							goto EndFinally_288;
							IL_1762:
							int num59;
							num58 = num59;
							goto IL_176E;
							EndFinally_288:;
						}
						IL_1782:
						goto IL_4678;
					}
					catch
					{
						int num60 = 0;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							int num61;
							num60 = num61;
						}
						switch (num60)
						{
						default:
							goto IL_4678;
						}
					}
					goto IL_17A7;
					IL_18DB:
					goto IL_1663;
					IL_149D:
					try
					{
						ProcessModuleCollection processModuleCollection3 = WP6RZJql8gZrNhVA9v.QXAPiWMFybI6qUa5Fy(process);
						IEnumerator enumerator;
						for (;;)
						{
							enumerator = WP6RZJql8gZrNhVA9v.hRsR9gcWuuXGGEJDaX(processModuleCollection3);
							int num62 = 0;
							if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
							{
								int num63;
								num62 = num63;
							}
							switch (num62)
							{
							case 1:
								goto IL_1644;
							case 2:
								continue;
							}
							break;
						}
						try
						{
							for (;;)
							{
								IL_15E7:
								if (WP6RZJql8gZrNhVA9v.ewZ3B8GFII2oOk3KXO(enumerator))
								{
									goto IL_15C6;
								}
								int num64 = 0;
								if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
								{
									break;
								}
								ProcessModule processModule3;
								for (;;)
								{
									IL_155E:
									switch (num64)
									{
									case 1:
									{
										long num65 = num24;
										intPtr2 = WP6RZJql8gZrNhVA9v.UAJlX83FojikbWHemo(processModule3);
										if (num65 <= intPtr2.ToInt64() + (long)WP6RZJql8gZrNhVA9v.mbCK41hZIUxGEfPiUxd(processModule3))
										{
											goto IL_15E7;
										}
										num64 = 2;
										if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
										{
											goto Block_237;
										}
										continue;
									}
									case 2:
										goto IL_14EB;
									case 3:
										goto IL_15B1;
									case 4:
										goto IL_15C6;
									case 5:
										goto IL_15F5;
									case 6:
										goto IL_15E7;
									case 7:
										goto IL_1517;
									case 8:
										goto IL_1598;
									}
									goto Block_238;
								}
								Block_237:
								goto IL_1529;
								IL_14EB:
								if (!WP6RZJql8gZrNhVA9v.zqn4VshKNT3WCTFCwJZ(WP6RZJql8gZrNhVA9v.woW3uTh3BLqd1RTLGjC(WP6RZJql8gZrNhVA9v.HMmDSchYhBi0nCBpGT7(typeof(WP6RZJql8gZrNhVA9v).TypeHandle).Assembly), null))
								{
									continue;
								}
								num64 = 7;
								if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
								{
									goto IL_1517;
								}
								goto IL_155E;
								IL_1598:
								long num66 = num24;
								intPtr2 = WP6RZJql8gZrNhVA9v.UAJlX83FojikbWHemo(processModule3);
								if (num66 < intPtr2.ToInt64())
								{
									goto IL_14EB;
								}
								num64 = 1;
								if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
								{
									goto IL_155E;
								}
								IL_1529:
								int num67;
								num64 = num67;
								goto IL_155E;
								IL_1517:
								WP6RZJql8gZrNhVA9v.zg2y0Yf8teq2aJWnZL();
								num64 = 5;
								if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
								{
									goto IL_1529;
								}
								goto IL_155E;
								IL_15B1:
								if (WP6RZJql8gZrNhVA9v.DiXRJpEwdIUvepcObv(WP6RZJql8gZrNhVA9v.ywAggiNPXCMhKIlgTC(processModule3), text2))
								{
									num67 = 8;
									goto IL_1598;
								}
								continue;
								IL_15C6:
								processModule3 = (ProcessModule)WP6RZJql8gZrNhVA9v.oTcjQYPHTdNpOKif0G(enumerator);
								goto IL_15B1;
							}
							Block_238:
							goto IL_1644;
							IL_15F5:
							return;
						}
						finally
						{
							IDisposable disposable = enumerator as IDisposable;
							IL_163F:
							while (disposable != null)
							{
								int num68 = 0;
								if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
								{
									goto IL_1628;
								}
								do
								{
									IL_162C:
									switch (num68)
									{
									case 1:
										goto IL_1643;
									case 2:
										goto IL_163F;
									}
									WP6RZJql8gZrNhVA9v.A3Yh5RFFFw06bojsfa(disposable);
									num68 = 1;
								}
								while (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null);
								IL_1628:
								int num69;
								num68 = num69;
								goto IL_162C;
							}
							IL_1643:;
						}
						IL_1644:;
					}
					catch
					{
						int num70 = 0;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							int num71;
							num70 = num71;
						}
						switch (num70)
						{
						}
					}
					goto Block_18;
					IL_1496:
					process = WP6RZJql8gZrNhVA9v.KmKeX0bgSXhq1fq28N();
					goto IL_149D;
					IL_35DC:
					num24 = WP6RZJql8gZrNhVA9v.qeXk8DhQ6H5BpiuRsJF(new IntPtr(num11));
					goto IL_1496;
					IL_18BD:
					array[17] = (byte)num7;
					num2 = 422;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_18DB;
					}
					continue;
					IL_18B7:
					num7 = 89;
					goto IL_18BD;
					IL_18A9:
					array[17] = (byte)num7;
					goto IL_18B7;
					IL_18A0:
					num7 = 146;
					goto IL_18A9;
					IL_18E1:
					num5 = 198;
					num2 = 315;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_190D:
					array2[6] = 128;
					num2 = 381;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_192C;
					}
					continue;
					IL_18FF:
					array2[6] = (byte)num10;
					goto IL_190D;
					IL_37BF:
					num10 = 56;
					goto IL_18FF;
					IL_37B0:
					array2[5] = 166;
					goto IL_37BF;
					IL_194A:
					array[20] = (byte)num7;
					num2 = 179;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_1938:
					num7 = 181;
					num = 535;
					goto IL_194A;
					IL_192C:
					array[20] = 110;
					goto IL_1938;
					IL_34C9:
					array[20] = 122;
					goto IL_192C;
					IL_1979:
					num6 = 243;
					num2 = 561;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_196D:
					array2[11] = 121;
					goto IL_1979;
					IL_2C9C:
					array2[11] = 141;
					goto IL_196D;
					IL_2C84:
					array2[10] = 161;
					num = 164;
					goto IL_2C9C;
					IL_19A3:
					num7 = 154;
					num2 = 394;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_19DC:
					array[23] = 70;
					num2 = 76;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_19F8;
					}
					continue;
					IL_19CD:
					array[23] = 151;
					goto IL_19DC;
					IL_1A1B:
					num5 = 75;
					num2 = 86;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_1A0D:
					array[8] = (byte)num7;
					goto IL_1A1B;
					IL_1A04:
					num7 = 138;
					goto IL_1A0D;
					IL_19F8:
					array[7] = 59;
					goto IL_1A04;
					IL_33CC:
					array[7] = (byte)num7;
					goto IL_19F8;
					IL_1AD2:
					array6[num23 + 2] = array3[2];
					num2 = 478;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						goto IL_1B53;
					}
					continue;
					IL_1AC7:
					array6[num23 + 1] = array3[1];
					goto IL_1AD2;
					IL_1ABE:
					array6[num23] = array3[0];
					goto IL_1AC7;
					IL_1AB1:
					num23 = 9;
					num = 599;
					goto IL_1ABE;
					IL_2243:
					if (WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas() == 4)
					{
						goto IL_1AB1;
					}
					goto IL_2250;
					IL_2832:
					array7 = WP6RZJql8gZrNhVA9v.O5H60QhPORn2lsaWULs(num24);
					goto IL_2243;
					IL_281B:
					array13 = WP6RZJql8gZrNhVA9v.O5H60QhPORn2lsaWULs(intPtr5.ToInt64());
					num = 31;
					goto IL_2832;
					IL_1AFB:
					IntPtr intPtr7 = new IntPtr(WP6RZJql8gZrNhVA9v.URnkCOceLK + (long)WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E) - (long)num35);
					num2 = 188;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
					{
						goto IL_1B24;
					}
					continue;
					IL_1AF5:
					int num72;
					if (num72 < num16)
					{
						goto IL_1AFB;
					}
					num2 = 343;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_3791:
					num72 = 0;
					goto IL_1AF5;
					IL_1AEF:
					num72++;
					goto IL_1AF5;
					IL_1B53:
					WP6RZJql8gZrNhVA9v.YeeoMqaS3J(intPtr7, 4, num32, ref num32);
					goto IL_1AEF;
					IL_1B3A:
					IntPtr intPtr8;
					WP6RZJql8gZrNhVA9v.mTfoQqVbOE(intPtr8, intPtr7, WP6RZJql8gZrNhVA9v.cxBgTlJNLn7Vsrekt7(WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E)), 4U, out zero);
					goto IL_1B53;
					IL_1B30:
					if (WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas() == 4)
					{
						num = 266;
						goto IL_1B80;
					}
					goto IL_1B3A;
					IL_1B24:
					WP6RZJql8gZrNhVA9v.YeeoMqaS3J(intPtr7, 4, 4, ref num32);
					goto IL_1B30;
					IL_1B80:
					WP6RZJql8gZrNhVA9v.mTfoQqVbOE(intPtr8, intPtr7, WP6RZJql8gZrNhVA9v.cxBgTlJNLn7Vsrekt7(WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E)), 4U, out zero);
					num2 = 466;
					if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						continue;
					}
					IL_1BA9:
					array[22] = (byte)num7;
					num2 = 50;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_1C52:
					array2[0] = 111;
					num2 = 415;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_1C44:
					array2[0] = (byte)num10;
					goto IL_1C52;
					IL_1C3E:
					num10 = 113;
					goto IL_1C44;
					IL_1C30:
					array2[0] = (byte)num10;
					goto IL_1C3E;
					IL_1C27:
					num10 = 147;
					goto IL_1C30;
					IL_1C18:
					array2[0] = 169;
					goto IL_1C27;
					IL_1C0A:
					array2 = new byte[16];
					goto IL_1C18;
					IL_1C04:
					array15 = array;
					goto IL_1C0A;
					IL_1BF6:
					array[31] = (byte)num7;
					goto IL_1C04;
					IL_1BF0:
					num7 = 54;
					goto IL_1BF6;
					IL_1BE4:
					array[31] = 47;
					goto IL_1BF0;
					IL_1BCC:
					array[31] = 153;
					num = 309;
					goto IL_1BE4;
					IL_2693:
					array[31] = 84;
					goto IL_1BCC;
					IL_2684:
					array[31] = 131;
					goto IL_2693;
					IL_1C73:
					array10[1] = 115;
					num2 = 267;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_3802:
					array10[0] = 109;
					goto IL_1C73;
					IL_37F9:
					array10 = new byte[12];
					goto IL_3802;
					IL_1CBE:
					intPtr2 = WP6RZJql8gZrNhVA9v.kZQ8dAyUfWnWWqJUp8(WP6RZJql8gZrNhVA9v.DR9AZjjdNREcZwIYAb(WP6RZJql8gZrNhVA9v.x4Dk2IHVmX)[0]);
					num2 = 472;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_1CA9:
					WP6RZJql8gZrNhVA9v.GhTBkML7lWmHOUJLvu(WP6RZJql8gZrNhVA9v.Wqta94qIF2UoY3DUfP(vtNVUKGulysZw81C3E), 0L);
					goto IL_1CBE;
					IL_1C92:
					vtNVUKGulysZw81C3E = new WP6RZJql8gZrNhVA9v.VtNVUKGulysZw81C3E(new MemoryStream(array12));
					num = 375;
					goto IL_1CA9;
					IL_1C8E:
					byte* ptr2 = null;
					goto IL_1C92;
					IL_31BD:
					int num73;
					int num74;
					if (num73 < num74)
					{
						goto IL_31C6;
					}
					goto IL_1C8E;
					IL_31BA:
					num73 = 0;
					goto IL_31BD;
					IL_3F6A:
					int num75;
					uint num76;
					int num77;
					int num80;
					byte[] array20;
					byte[] array21;
					int num84;
					int num83;
					fixed (byte* ptr2 = &array4[0])
					{
						goto IL_31BA;
						IL_1D5B:
						array[7] = (byte)num7;
						num2 = 545;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_1D52:
						num7 = 222;
						goto IL_1D5B;
						IL_1D3D:
						array[7] = 125;
						num = 642;
						goto IL_1D52;
						IL_1D2E:
						array[7] = 150;
						goto IL_1D3D;
						IL_1D20:
						array[6] = (byte)num5;
						goto IL_1D2E;
						IL_1D17:
						num5 = 217;
						goto IL_1D20;
						IL_1D08:
						array[6] = 137;
						goto IL_1D17;
						IL_1CFA:
						array[6] = (byte)num7;
						goto IL_1D08;
						IL_1CF4:
						num7 = 110;
						goto IL_1CFA;
						IL_1CE6:
						array[6] = (byte)num5;
						goto IL_1CF4;
						IL_1D9C:
						if (WP6RZJql8gZrNhVA9v.HVtG6OVrH4GYduNgRb(WP6RZJql8gZrNhVA9v.x4Dk2IHVmX) == null)
						{
							goto IL_1DBD;
						}
						num2 = 476;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_1D99:
						num35 = 0;
						goto IL_1D9C;
						IL_1DE2:
						SymmetricAlgorithm symmetricAlgorithm;
						WP6RZJql8gZrNhVA9v.pZirvkO3plqD0s2Ieu(symmetricAlgorithm, CipherMode.CBC);
						num2 = 313;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_1DDB:
						symmetricAlgorithm = WP6RZJql8gZrNhVA9v.qG4I2OlWlNSst7kqpS();
						goto IL_1DE2;
						IL_1DD6:
						if (num75 == 4)
						{
							goto IL_1DDB;
						}
						goto IL_1DFF;
						IL_1DCD:
						num75 = WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E);
						goto IL_1DD6;
						IL_1DC4:
						num16 = WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E);
						goto IL_1DCD;
						IL_1DBD:
						num35 = 7680;
						goto IL_1DC4;
						IL_1E26:
						if (WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas() != 4)
						{
							goto IL_1ED8;
						}
						num2 = 612;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto IL_1E41;
						}
						continue;
						IL_1E12:
						WP6RZJql8gZrNhVA9v.AwgKvrHJUS3TxryUsj awgKvrHJUS3TxryUsj;
						intPtr8 = WP6RZJql8gZrNhVA9v.OFTGEXTEON2THecrHE((uint)awgKvrHJUS3TxryUsj, 1, (uint)WP6RZJql8gZrNhVA9v.XJjeAvuYQjjJap119l(WP6RZJql8gZrNhVA9v.KmKeX0bgSXhq1fq28N()));
						goto IL_1E26;
						IL_1E0E:
						awgKvrHJUS3TxryUsj = (WP6RZJql8gZrNhVA9v.AwgKvrHJUS3TxryUsj)56;
						goto IL_1E12;
						IL_1E07:
						intPtr8 = IntPtr.Zero;
						goto IL_1E0E;
						IL_1DFF:
						if (num75 == 1)
						{
							goto IL_1E07;
						}
						int num15 = 0;
						num2 = 242;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_1E41:
						int num22;
						num22++;
						num2 = 164;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
						{
							goto IL_1E57;
						}
						continue;
						IL_1E5D:
						num25 = num25;
						num2 = 416;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_3C9C:
						byte[] array9;
						num21 = (uint)(((int)array9[(int)((UIntPtr)(num76 + 3U))] << 24) | ((int)array9[(int)((UIntPtr)(num76 + 2U))] << 16) | ((int)array9[(int)((UIntPtr)(num76 + 1U))] << 8) | (int)array9[(int)((UIntPtr)num76)]);
						goto IL_1E5D;
						IL_1E57:
						if (num22 >= num77)
						{
							goto IL_1E5D;
						}
						IL_1E76:
						if (num22 <= 0)
						{
							goto IL_1EB2;
						}
						num2 = 262;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto IL_1E8B;
						}
						continue;
						IL_1E9A:
						int num78 = 0;
						num2 = 467;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_1E8B:
						IntPtr intPtr9;
						int num79;
						WP6RZJql8gZrNhVA9v.YeeoMqaS3J(intPtr9, num79 * 4, 4, ref num32);
						goto IL_1E9A;
						IL_27A5:
						num79 = WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E);
						goto IL_1E8B;
						IL_30DA:
						int num30;
						intPtr9 = new IntPtr(WP6RZJql8gZrNhVA9v.URnkCOceLK + (long)num30 - (long)num35);
						num = 13;
						goto IL_27A5;
						IL_1EB2:
						num21 |= (uint)array9[array9.Length - (1 + num22)];
						num2 = 47;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_1EEB:
						WP6RZJql8gZrNhVA9v.URnkCOceLK = intPtr2.ToInt64();
						num2 = 301;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_1ED8:
						intPtr2 = WP6RZJql8gZrNhVA9v.kZQ8dAyUfWnWWqJUp8(WP6RZJql8gZrNhVA9v.DR9AZjjdNREcZwIYAb(WP6RZJql8gZrNhVA9v.x4Dk2IHVmX)[0]);
						goto IL_1EEB;
						IL_240B:
						WP6RZJql8gZrNhVA9v.XtMknffM5M = intPtr2.ToInt32();
						goto IL_1ED8;
						IL_1F32:
						num7 = 112;
						num2 = 199;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_1F48;
						}
						continue;
						IL_1F24:
						array[30] = (byte)num5;
						goto IL_1F32;
						IL_1FCB:
						num5 = 111;
						num = 645;
						goto IL_1F24;
						IL_3CCC:
						array[30] = 150;
						goto IL_1FCB;
						IL_3FBF:
						array[30] = (byte)num5;
						goto IL_3CCC;
						IL_1F4E:
						array10[2] = 114;
						num2 = 103;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_1F48:
						array10[1] = 108;
						goto IL_1F4E;
						IL_1FEA:
						num8 = 30;
						num2 = 518;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_1FFE;
						}
						continue;
						IL_1FDF:
						array6[num8 + 7] = array7[7];
						goto IL_1FEA;
						IL_4525:
						array6[num8 + 6] = array7[6];
						goto IL_1FDF;
						IL_203D:
						num24 = 0L;
						num2 = 166;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_2028:
						intPtr5 = WP6RZJql8gZrNhVA9v.kq4lKLhbtqXRHLrKScR(WP6RZJql8gZrNhVA9v.rNZkehfwNu);
						num = 298;
						goto IL_203D;
						IL_205D:
						array[22] = 151;
						num2 = 173;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_2451:
						array[22] = 104;
						num = 638;
						goto IL_205D;
						IL_3039:
						array[22] = (byte)num7;
						goto IL_2451;
						IL_20A2:
						ProcessModuleCollection processModuleCollection;
						IEnumerator enumerator = WP6RZJql8gZrNhVA9v.hRsR9gcWuuXGGEJDaX(processModuleCollection);
						num2 = 254;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_20D4:
						array[4] = 98;
						num2 = 429;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_20C6:
						array[4] = (byte)num5;
						goto IL_20D4;
						IL_2109:
						array[27] = 128;
						num2 = 203;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_20FB:
						array[26] = (byte)num7;
						goto IL_2109;
						IL_20F5:
						num7 = 103;
						goto IL_20FB;
						IL_3FA1:
						array[26] = (byte)num5;
						goto IL_20F5;
						IL_2151:
						intPtr = WP6RZJql8gZrNhVA9v.LoadLibrary(text2);
						num2 = 635;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_2143:
						text2 = WP6RZJql8gZrNhVA9v.eTgynxhtgEVcRlyJcRL(WP6RZJql8gZrNhVA9v.A1Ju77hCr9O8h9Qmym6(), array10);
						goto IL_2151;
						IL_2133:
						array10[9] = 108;
						num = 589;
						goto IL_2143;
						IL_212D:
						array10[8] = 108;
						goto IL_2133;
						IL_22A1:
						array10[7] = 100;
						goto IL_212D;
						IL_229B:
						array10[6] = 46;
						goto IL_22A1;
						IL_2295:
						array10[5] = 116;
						goto IL_229B;
						IL_217C:
						num15++;
						num2 = 386;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_2197:
						num5 = 92;
						num2 = 596;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_21B2:
						array4 = new byte[] { 42 };
						WP6RZJql8gZrNhVA9v.BIpvxRBRb2dOGl802m bipvxRBRb2dOGl802m;
						bipvxRBRb2dOGl802m.jsbkrdexts = array4;
						num2 = 567;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_3299:
						bipvxRBRb2dOGl802m = default(WP6RZJql8gZrNhVA9v.BIpvxRBRb2dOGl802m);
						goto IL_21B2;
						IL_21DE:
						num6 = 82;
						num2 = 33;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_21F9:
						WP6RZJql8gZrNhVA9v.akmBWvpHNGRy8htrfU(array5, 0, array5.Length);
						num2 = 193;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_2C50:
						MemoryStream memoryStream;
						array12 = WP6RZJql8gZrNhVA9v.jnvtq3iCx4OYoUINoA(memoryStream);
						goto IL_21F9;
						IL_2C49:
						CryptoStream cryptoStream;
						WP6RZJql8gZrNhVA9v.ArXWYRma06fMRXvDFB(cryptoStream);
						goto IL_2C50;
						IL_2C32:
						byte[] array14;
						WP6RZJql8gZrNhVA9v.HFqeTCUXpiOtLfNHOS(cryptoStream, array14, 0, array14.Length);
						num = 200;
						goto IL_2C49;
						IL_2C26:
						ICryptoTransform cryptoTransform;
						cryptoStream = new CryptoStream(memoryStream, cryptoTransform, CryptoStreamMode.Write);
						goto IL_2C32;
						IL_2223:
						array6[num8 + 1] = array3[1];
						num2 = 285;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_221A:
						array6[num8] = array3[0];
						goto IL_2223;
						IL_2250:
						num8 = 2;
						goto IL_221A;
						IL_227A:
						num10 = 118;
						num2 = 192;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_226C:
						array2[14] = (byte)num6;
						goto IL_227A;
						IL_2263:
						num6 = 145;
						goto IL_226C;
						IL_22E0:
						if (num77 <= 0)
						{
							goto IL_2311;
						}
						num2 = 67;
						if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_22F5;
						}
						continue;
						IL_22CF:
						int num3;
						int num4;
						if (num3 == num4 - 1)
						{
							num = 162;
							goto IL_22E0;
						}
						goto IL_2311;
						IL_22C3:
						num80 = 0;
						num = 136;
						goto IL_22CF;
						IL_22F5:
						num25 += num26;
						num2 = 276;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_2311:
						num76 = (uint)num13;
						num2 = 296;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_2380:
						WP6RZJql8gZrNhVA9v.amiZJawSB0ZaSQBdfI(array6, 0, intPtr6, array6.Length);
						num2 = 647;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_1F98;
						}
						continue;
						IL_2877:
						array6[num8 + 7] = array13[7];
						goto IL_2380;
						IL_2AD4:
						array6[num8 + 6] = array13[6];
						num = 581;
						goto IL_2877;
						IL_2AC9:
						array6[num8 + 5] = array13[5];
						goto IL_2AD4;
						IL_2AB5:
						array6[num8 + 4] = array13[4];
						num = 288;
						goto IL_2AC9;
						IL_2375:
						array6[num23 + 3] = array13[3];
						goto IL_2380;
						IL_236A:
						array6[num23 + 2] = array13[2];
						goto IL_2375;
						IL_235F:
						array6[num23 + 1] = array13[1];
						goto IL_236A;
						IL_2356:
						array6[num23] = array13[0];
						goto IL_235F;
						IL_2352:
						num23 = 23;
						goto IL_2356;
						IL_2347:
						array6[num23 + 3] = array7[3];
						goto IL_2352;
						IL_3D0F:
						array6[num23 + 2] = array7[2];
						goto IL_2347;
						IL_23CD:
						int num81;
						array20 = WP6RZJql8gZrNhVA9v.IkVx6W7gxIo4U9w5rM(vtNVUKGulysZw81C3E, num81);
						num2 = 559;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_23C4:
						num81 = WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E);
						goto IL_23CD;
						IL_23C1:
						bool flag = true;
						goto IL_23C4;
						IL_23AF:
						int num82;
						if (num82 >= 1879048192)
						{
							num = 212;
							goto IL_23C1;
						}
						goto IL_23C4;
						IL_23AC:
						flag = false;
						goto IL_23AF;
						IL_23A3:
						num82 = WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E);
						goto IL_23AC;
						IL_2436:
						num5 = 36;
						num2 = 342;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_242A:
						array[21] = 94;
						goto IL_2436;
						IL_241C:
						array[21] = (byte)num7;
						goto IL_242A;
						IL_4183:
						num7 = 160;
						goto IL_241C;
						IL_2482:
						num4 = array9.Length / 4;
						num2 = 82;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_247A:
						num77 = array9.Length % 4;
						goto IL_2482;
						IL_2476:
						array9 = array14;
						goto IL_247A;
						IL_246E:
						int num33;
						if (num33 >= array5.Length)
						{
							goto IL_2476;
						}
						goto IL_249F;
						IL_246B:
						num33 = 0;
						goto IL_246E;
						IL_28AF:
						if (array21.Length <= 0)
						{
							goto IL_246B;
						}
						num2 = 348;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_28A8:
						if (array21 != null)
						{
							goto IL_28AF;
						}
						goto IL_246B;
						IL_2897:
						array21 = WP6RZJql8gZrNhVA9v.b6kkEoSRgSgnV3yxh2(WP6RZJql8gZrNhVA9v.cutG4jRhdD1EHWOltr(WP6RZJql8gZrNhVA9v.x4Dk2IHVmX));
						goto IL_28A8;
						IL_2887:
						WP6RZJql8gZrNhVA9v.sDZRRXD0fxaC25PF88(array5);
						num = 40;
						goto IL_2897;
						IL_249F:
						array15[num33] ^= array5[num33];
						num2 = 600;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_24CA:
						num83 = num3 % num84;
						num2 = 451;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
						{
							continue;
						}
						IL_24E1:
						if (num3 < num4)
						{
							goto IL_24CA;
						}
						num2 = 122;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_2863:
						num3++;
						num = 208;
						goto IL_24E1;
						IL_2DF0:
						if (num31 < num77)
						{
							goto IL_2DF9;
						}
						goto IL_2863;
						IL_252B:
						num78++;
						num2 = 50;
						if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_2541;
						}
						continue;
						IL_250D:
						WP6RZJql8gZrNhVA9v.ubvua3hecKV44oZJiZx(new IntPtr(intPtr9.ToInt64() + (long)(num78 * 4)), WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E));
						goto IL_252B;
						IL_2541:
						if (num78 >= num79)
						{
							num = 177;
							goto IL_2550;
						}
						goto IL_250D;
						IL_2560:
						if (WP6RZJql8gZrNhVA9v.U3uctGzVl7Uc86yBWE(WP6RZJql8gZrNhVA9v.Wqta94qIF2UoY3DUfP(vtNVUKGulysZw81C3E)) >= WP6RZJql8gZrNhVA9v.G2NYB14TljE8aPpplT(WP6RZJql8gZrNhVA9v.Wqta94qIF2UoY3DUfP(vtNVUKGulysZw81C3E)) - 1L)
						{
							goto IL_2599;
						}
						num2 = 521;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_2550:
						WP6RZJql8gZrNhVA9v.YeeoMqaS3J(intPtr9, num79 * 4, num32, ref num32);
						goto IL_2560;
						IL_25AA:
						WP6RZJql8gZrNhVA9v.zg2y0Yf8teq2aJWnZL();
						num2 = 161;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_2599:
						WP6RZJql8gZrNhVA9v.AhI1G3hhw7olV71pYD1(intPtr8);
						num = 172;
						goto IL_25AA;
						IL_25E1:
						array2[13] = (byte)num6;
						num2 = 356;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_25DB:
						num6 = 46;
						goto IL_25E1;
						IL_25CD:
						array2[13] = (byte)num6;
						goto IL_25DB;
						IL_25C4:
						num6 = 156;
						goto IL_25CD;
						IL_3339:
						array2[13] = (byte)num6;
						num = 602;
						goto IL_25C4;
						IL_3652:
						num6 = 163;
						goto IL_3339;
						IL_2604:
						array[19] = (byte)num5;
						num2 = 471;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_2632:
						IntPtr intPtr3;
						WP6RZJql8gZrNhVA9v.k3A5xmYbdQkDBLoHFb(intPtr3, 0);
						num2 = 481;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_264B;
						}
						continue;
						IL_2B76:
						num11 = WP6RZJql8gZrNhVA9v.qeXk8DhQ6H5BpiuRsJF(intPtr3);
						goto IL_2632;
						IL_2B59:
						if (WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas() != 4)
						{
							goto IL_2B76;
						}
						num2 = 500;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_2B4E:
						num11 = 0L;
						goto IL_2B59;
						IL_2B45:
						WP6RZJql8gZrNhVA9v.OFfwWh6ZIHjfnqBOWx offwWh6ZIHjfnqBOWx;
						intPtr3 = WP6RZJql8gZrNhVA9v.wKVmWjhgE1OQ8sgXgBS(offwWh6ZIHjfnqBOWx);
						goto IL_2B4E;
						IL_2B2D:
						IntPtr procAddress;
						offwWh6ZIHjfnqBOWx = (WP6RZJql8gZrNhVA9v.OFfwWh6ZIHjfnqBOWx)WP6RZJql8gZrNhVA9v.T5jTdMh84t7QTlT82Np(procAddress, WP6RZJql8gZrNhVA9v.HMmDSchYhBi0nCBpGT7(typeof(WP6RZJql8gZrNhVA9v.OFfwWh6ZIHjfnqBOWx).TypeHandle));
						goto IL_2B45;
						IL_2656:
						array6[num8 + 6] = array3[6];
						num2 = 264;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							break;
						}
						continue;
						IL_3778:
						array6[num8 + 5] = array3[5];
						num = 597;
						goto IL_2656;
						IL_26CB:
						num7 = 140;
						num2 = 572;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_26BF:
						array[1] = 105;
						goto IL_26CB;
						IL_26B0:
						array[1] = 201;
						goto IL_26BF;
						IL_26EF:
						array5[3] = array21[1];
						num2 = 391;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
						{
							goto IL_2707;
						}
						continue;
						IL_270F:
						array5[7] = array21[3];
						num2 = 14;
						if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_2727;
						}
						continue;
						IL_2707:
						array5[5] = array21[2];
						goto IL_270F;
						IL_274B:
						WP6RZJql8gZrNhVA9v.akmBWvpHNGRy8htrfU(array21, 0, array21.Length);
						num2 = 609;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_2742:
						array5[15] = array21[7];
						goto IL_274B;
						IL_2739:
						array5[13] = array21[6];
						goto IL_2742;
						IL_2730:
						array5[11] = array21[5];
						goto IL_2739;
						IL_2727:
						array5[9] = array21[4];
						goto IL_2730;
						IL_2786:
						array[3] = 175;
						num2 = 550;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_27A5;
						}
						continue;
						IL_277A:
						array[2] = 87;
						goto IL_2786;
						IL_276C:
						array[2] = (byte)num7;
						goto IL_277A;
						IL_27D7:
						array13 = WP6RZJql8gZrNhVA9v.cxBgTlJNLn7Vsrekt7(intPtr5.ToInt32());
						num2 = 310;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_27C6:
						array3 = WP6RZJql8gZrNhVA9v.cxBgTlJNLn7Vsrekt7(WP6RZJql8gZrNhVA9v.VE2k4S5okQ.ToInt32());
						goto IL_27D7;
						IL_27BE:
						if (WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas() == 4)
						{
							goto IL_27C6;
						}
						IL_27FA:
						array3 = WP6RZJql8gZrNhVA9v.O5H60QhPORn2lsaWULs(WP6RZJql8gZrNhVA9v.VE2k4S5okQ.ToInt64());
						num2 = 281;
						if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							goto IL_281B;
						}
						continue;
						IL_2840:
						array8[num13 + 3] = (byte)((num14 & 4278190080U) >> 24);
						num2 = 25;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
						{
							goto IL_2863;
						}
						continue;
						IL_28D9:
						flag = false;
						num2 = 211;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							continue;
						}
						IL_28EC:
						if (WP6RZJql8gZrNhVA9v.U3uctGzVl7Uc86yBWE(WP6RZJql8gZrNhVA9v.Wqta94qIF2UoY3DUfP(vtNVUKGulysZw81C3E)) >= WP6RZJql8gZrNhVA9v.G2NYB14TljE8aPpplT(WP6RZJql8gZrNhVA9v.Wqta94qIF2UoY3DUfP(vtNVUKGulysZw81C3E)) - 1L)
						{
							goto IL_2925;
						}
						num2 = 605;
						if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
						{
							goto IL_229B;
						}
						continue;
						IL_31EB:
						int num34;
						WP6RZJql8gZrNhVA9v.kKd2fBhsYA0K0Yyxtft(WP6RZJql8gZrNhVA9v.lmdkVksVkh, num29 + (long)num34, bipvxRBRb2dOGl802m2);
						goto IL_28EC;
						IL_2942:
						WP6RZJql8gZrNhVA9v.eXJkjmTXDX = intPtr2.ToInt64();
						num2 = 42;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_2925:
						intPtr2 = WP6RZJql8gZrNhVA9v.kZQ8dAyUfWnWWqJUp8(WP6RZJql8gZrNhVA9v.DR9AZjjdNREcZwIYAb(WP6RZJql8gZrNhVA9v.HMmDSchYhBi0nCBpGT7(typeof(WP6RZJql8gZrNhVA9v).TypeHandle).Assembly)[0]);
						goto IL_2942;
						IL_2969:
						string text = WP6RZJql8gZrNhVA9v.eTgynxhtgEVcRlyJcRL(WP6RZJql8gZrNhVA9v.A1Ju77hCr9O8h9Qmym6(), array11);
						num2 = 410;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_2963:
						array11[5] = 116;
						goto IL_2969;
						IL_35EF:
						array11[4] = 105;
						num = 577;
						goto IL_2963;
						IL_298C:
						if ((array4 = array12) == null)
						{
							goto IL_29A8;
						}
						num2 = 30;
						if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
						{
							break;
						}
						continue;
						IL_2BA7:
						num74 = array12.Length / 8;
						goto IL_298C;
						IL_29A8:;
					}
					num2 = 307;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_29CF:
					num7 = 83;
					num2 = 380;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_2A3C:
					num10 = 49;
					num2 = 508;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_2A2E:
					array2[3] = (byte)num6;
					goto IL_2A3C;
					IL_2A1F:
					num6 = 86;
					num = 249;
					goto IL_2A2E;
					IL_2A0A:
					array2[3] = 124;
					num = 142;
					goto IL_2A1F;
					IL_29FB:
					array2[3] = 131;
					goto IL_2A0A;
					IL_2A60:
					array[23] = (byte)num5;
					num2 = 655;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_2A57:
					num5 = 142;
					goto IL_2A60;
					IL_3393:
					array[23] = (byte)num7;
					goto IL_2A57;
					IL_2A83:
					num10 = 137;
					num2 = 116;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
					{
						continue;
					}
					IL_2A9C:
					array6[num8] = array7[0];
					num2 = 137;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						goto IL_2AB5;
					}
					continue;
					IL_3D99:
					num8 = 18;
					num = 15;
					goto IL_2A9C;
					IL_2B84:
					array2[6] = (byte)num10;
					num2 = 190;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_2BDD:
					array2[12] = (byte)num10;
					num2 = 0;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
					{
						goto IL_2BFB;
					}
					continue;
					IL_2BCB:
					num10 = 146;
					num = 501;
					goto IL_2BDD;
					IL_2BB4:
					array2[11] = (byte)num6;
					num = 67;
					goto IL_2BCB;
					IL_2BFB:
					array2[12] = 131;
					num2 = 350;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_2C66:
					bipvxRBRb2dOGl802m2.jsbkrdexts = array20;
					num2 = 509;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_2CB0:
					num7 = 162;
					num2 = 326;
					if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_2CC9;
					}
					continue;
					IL_2D2F:
					num5 = 136;
					num2 = 133;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_2D20:
					array[11] = 186;
					goto IL_2D2F;
					IL_2D12:
					array[10] = (byte)num5;
					goto IL_2D20;
					IL_2D0C:
					num5 = 17;
					goto IL_2D12;
					IL_2CF5:
					array[10] = (byte)num5;
					num = 81;
					goto IL_2D0C;
					IL_2CE3:
					num5 = 162;
					num = 442;
					goto IL_2CF5;
					IL_2CD7:
					array[10] = 96;
					goto IL_2CE3;
					IL_2CC9:
					array[10] = (byte)num7;
					goto IL_2CD7;
					IL_2D53:
					array[3] = (byte)num5;
					num2 = 290;
					if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_28CE;
					}
					continue;
					IL_2D95:
					WP6RZJql8gZrNhVA9v.amiZJawSB0ZaSQBdfI(array4, 0, WP6RZJql8gZrNhVA9v.yMoAkRgfwbpT1WDXhi(8), 1);
					num2 = 536;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_22A1;
					}
					continue;
					IL_2D8D:
					array4 = new byte[1];
					goto IL_2D95;
					IL_2D76:
					WP6RZJql8gZrNhVA9v.wFMUk08ftpCdKXVaY7(new IntPtr((void*)(&num9)), 0, 0L);
					goto IL_2D8D;
					IL_2DD4:
					array2[4] = 63;
					num2 = 326;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_2DF0;
					}
					continue;
					IL_2E0A:
					uint num85;
					array8[num13 + num31] = (byte)((num85 & num36) >> num80);
					num2 = 528;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_2E04:
					num80 += 8;
					goto IL_2E0A;
					IL_2DFE:
					num36 <<= 8;
					goto IL_2E04;
					IL_2DF9:
					if (num31 > 0)
					{
						goto IL_2DFE;
					}
					goto IL_2E0A;
					IL_2E53:
					num6 = 103;
					num2 = 93;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_2D0C;
					}
					continue;
					IL_2E44:
					array2[3] = 134;
					goto IL_2E53;
					IL_4416:
					array2[2] = (byte)num6;
					goto IL_2E44;
					IL_2E6E:
					num76 = 0U;
					num2 = 606;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_308B:
					if (num77 <= 0)
					{
						goto IL_2E6E;
					}
					num2 = 485;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_3088:
					num21 = 0U;
					goto IL_308B;
					IL_3085:
					num26 = 0U;
					goto IL_3088;
					IL_3082:
					num25 = 0U;
					goto IL_3085;
					IL_4048:
					num84 = array15.Length / 4;
					goto IL_3082;
					IL_2EA0:
					num73++;
					num2 = 186;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_31C6:
					((long*)ptr2)[(IntPtr)num73 * 8] ^= 1990747641L;
					goto IL_2EA0;
					IL_2EFD:
					WP6RZJql8gZrNhVA9v.zg2y0Yf8teq2aJWnZL();
					num2 = 41;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_2F56:
					array[29] = (byte)num5;
					num2 = 207;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
					{
						goto IL_2F74;
					}
					continue;
					IL_4357:
					num5 = 89;
					num = 534;
					goto IL_2F56;
					IL_2F97:
					num5 = 145;
					num2 = 663;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						goto IL_2FB0;
					}
					continue;
					IL_2F88:
					array[29] = 158;
					goto IL_2F97;
					IL_2F7A:
					array[29] = (byte)num7;
					goto IL_2F88;
					IL_2F74:
					num7 = 104;
					goto IL_2F7A;
					IL_2FB0:
					array5[1] = array21[0];
					num2 = 520;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
					{
						goto IL_26EF;
					}
					continue;
					IL_3016:
					array[5] = (byte)num7;
					num2 = 400;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_3004:
					num7 = 162;
					num = 417;
					goto IL_3016;
					IL_2FF6:
					array[4] = (byte)num7;
					goto IL_3004;
					IL_2FED:
					num7 = 226;
					goto IL_2FF6;
					IL_330C:
					array[4] = 193;
					goto IL_2FED;
					IL_30AE:
					array[5] = (byte)num7;
					num2 = 303;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_30A8:
					num7 = 84;
					goto IL_30AE;
					IL_30FC:
					array[18] = 194;
					num2 = 120;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_3B38:
					array[18] = 168;
					goto IL_30FC;
					IL_3129:
					array6[num8 + 1] = array13[1];
					num2 = 619;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_3149:
					array[28] = 158;
					num2 = 158;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_39A8:
					array[28] = (byte)num7;
					goto IL_3149;
					IL_317B:
					WP6RZJql8gZrNhVA9v.YeeoMqaS3J(new IntPtr(num11), WP6RZJql8gZrNhVA9v.O6Acp9IOtGsKlNgeas(), num12, ref num12);
					num2 = 373;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_316D:
					WP6RZJql8gZrNhVA9v.kpsSl1h2TjCEf0Ntlu7(new IntPtr(num11), intPtr6);
					goto IL_317B;
					IL_3244:
					num31 = 0;
					num2 = 68;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_323D:
					num85 = num25 ^ num21;
					goto IL_3244;
					IL_322F:
					if (num77 > 0)
					{
						num = 456;
						goto IL_323D;
					}
					goto IL_325C;
					IL_3263:
					array8[num13] = (byte)(num14 & 255U);
					num2 = 219;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_325C:
					num14 = num25 ^ num21;
					goto IL_3263;
					IL_32CC:
					array2[7] = 98;
					num2 = 9;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_32B4:
					array2[7] = 129;
					num = 113;
					goto IL_32CC;
					IL_32A6:
					array2[7] = (byte)num6;
					goto IL_32B4;
					IL_337D:
					num7 = 119;
					num2 = 121;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
					{
						goto IL_3393;
					}
					continue;
					IL_336E:
					array[23] = 152;
					goto IL_337D;
					IL_33EE:
					array6[num23] = array7[0];
					num2 = 286;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_33EA:
					num23 = 16;
					goto IL_33EE;
					IL_3486:
					num7 = 100;
					num2 = 153;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
					{
						goto IL_349C;
					}
					continue;
					IL_3478:
					array[19] = (byte)num5;
					goto IL_3486;
					IL_34AA:
					array[19] = 164;
					num2 = 11;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
					{
						goto IL_34C9;
					}
					continue;
					IL_349C:
					array[19] = (byte)num7;
					goto IL_34AA;
					IL_3514:
					num5 = 89;
					num2 = 47;
					if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_1CE6;
					}
					continue;
					IL_34FD:
					array[5] = (byte)num5;
					num = 183;
					goto IL_3514;
					IL_3559:
					num26 = (uint)(((int)array15[(int)((UIntPtr)(num76 + 3U))] << 24) | ((int)array15[(int)((UIntPtr)(num76 + 2U))] << 16) | ((int)array15[(int)((UIntPtr)(num76 + 1U))] << 8) | (int)array15[(int)((UIntPtr)num76)]);
					num2 = 621;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						goto IL_13C5;
					}
					continue;
					IL_3553:
					num76 = (uint)(num83 * 4);
					goto IL_3559;
					IL_35B9:
					array2[2] = (byte)num10;
					num2 = 109;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_3603:
					array2[6] = (byte)num10;
					num2 = 16;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_363F:
					array7 = null;
					num2 = 21;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						goto IL_3652;
					}
					continue;
					IL_371B:
					array2[1] = 84;
					num2 = 665;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_373C:
					array[0] = 72;
					num2 = 594;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_37D8:
					array[0] = 83;
					num2 = 656;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_1C52;
					}
					continue;
					IL_37CA:
					array = new byte[32];
					goto IL_37D8;
					IL_382C:
					array[30] = 171;
					num2 = 66;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_38C4:
					WP6RZJql8gZrNhVA9v.ubvua3hecKV44oZJiZx(intPtr4, WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E));
					num2 = 630;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_38B8:
					WP6RZJql8gZrNhVA9v.YeeoMqaS3J(intPtr4, 4, 4, ref num32);
					goto IL_38C4;
					IL_38A2:
					intPtr4 = new IntPtr(num29 + (long)WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E) - (long)num35);
					goto IL_38B8;
					IL_38FB:
					array2[8] = (byte)num10;
					num2 = 65;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
					{
						goto IL_3873;
					}
					continue;
					IL_38F5:
					num10 = 103;
					goto IL_38FB;
					IL_38E7:
					array2[8] = (byte)num6;
					goto IL_38F5;
					IL_3949:
					num5 = 62;
					num2 = 469;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_393A:
					array[2] = 144;
					goto IL_3949;
					IL_39F3:
					WP6RZJql8gZrNhVA9v.akmBWvpHNGRy8htrfU(array15, 0, array15.Length);
					num2 = 560;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_3A32:
					num10 = 174;
					num2 = 135;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_3AEB:
					array2[15] = 86;
					goto IL_3A32;
					IL_3ADF:
					array2[15] = 70;
					goto IL_3AEB;
					IL_3A50:
					num75 = WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E);
					num2 = 90;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() == null)
					{
						goto IL_1DFF;
					}
					continue;
					IL_3B1E:
					num16 = WP6RZJql8gZrNhVA9v.n23COQa21qSiSV34bx(vtNVUKGulysZw81C3E);
					goto IL_3A50;
					IL_3B17:
					WP6RZJql8gZrNhVA9v.QqvKs1oXadKmvr1FhM(vtNVUKGulysZw81C3E);
					goto IL_3B1E;
					IL_3B93:
					num7 = 89;
					num2 = 125;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_3DC6:
					array6[num8 + 2] = array7[2];
					num2 = 489;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						break;
					}
					continue;
					IL_3F7E:
					array[13] = (byte)num5;
					num2 = 253;
					if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						goto IL_23ED;
					}
					continue;
					IL_4055:
					array2[14] = 77;
					num2 = 88;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_4191:
					num5 = 193;
					num2 = 482;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_4554:
					array[22] = (byte)num7;
					goto IL_4191;
					IL_42B5:
					num6 = 142;
					num2 = 228;
					if (!WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
					{
						break;
					}
					continue;
					IL_4591:
					WP6RZJql8gZrNhVA9v.wpoklx4RIX = WP6RZJql8gZrNhVA9v.Ehe0uhhX0aen13qwCxL(WP6RZJql8gZrNhVA9v.eXJkjmTXDX);
					num2 = 402;
					if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
					{
						goto IL_325C;
					}
					continue;
					IL_0B2B:
					num7 = 123;
					goto IL_0B31;
					IL_0B1D:
					array[25] = (byte)num7;
					goto IL_0B2B;
					IL_0B17:
					num7 = 88;
					goto IL_0B1D;
					IL_0B09:
					array[25] = (byte)num7;
					goto IL_0B17;
					IL_0B03:
					num7 = 101;
					goto IL_0B09;
					IL_1383:
					array[25] = (byte)num7;
					num = 677;
					goto IL_0B03;
					IL_137A:
					num7 = 155;
					goto IL_1383;
					IL_136B:
					array[25] = 158;
					goto IL_137A;
				}
				Block_16:
				Block_34:
				Block_48:
				Block_96:
				Block_105:
				Block_113:
				Block_130:
				Block_131:
				Block_134:
				Block_135:
				Block_137:
				Block_139:
				Block_142:
				Block_143:
				Block_150:
				Block_155:
				Block_156:
				Block_158:
				Block_162:
				Block_163:
				Block_164:
				Block_170:
				Block_171:
				Block_172:
				Block_174:
				Block_180:
				Block_182:
				Block_183:
				Block_188:
				Block_190:
				Block_191:
				Block_192:
				Block_193:
				Block_197:
				Block_198:
				Block_199:
				Block_201:
				Block_202:
				Block_203:
				Block_208:
				goto IL_0B4F;
				IL_0043:
				WP6RZJql8gZrNhVA9v.swobvbXXmPhDXTXm88(new IntPtr((void*)(&num9)), 0);
				num2 = 155;
				if (WP6RZJql8gZrNhVA9v.J4jDXwhlvXrNWQwYJ9())
				{
					goto IL_0061;
				}
				goto IL_0B4F;
				IL_0034:
				WP6RZJql8gZrNhVA9v.k3A5xmYbdQkDBLoHFb(new IntPtr((void*)(&num9)), 0);
				goto IL_0043;
				IL_0020:
				num9 = 0L;
				num = 546;
				goto IL_0034;
				IL_0019:
				num37 = 76360321U;
				goto IL_0020;
				IL_0013:
				WP6RZJql8gZrNhVA9v.MrkkWebIMK = true;
				goto IL_0019;
				IL_0B4F:
				num2 = num;
				goto IL_0061;
				IL_3964:
				WP6RZJql8gZrNhVA9v.zg2y0Yf8teq2aJWnZL();
				num2 = 49;
				if (WP6RZJql8gZrNhVA9v.VlDjo1sTWsIPgwQqKr() != null)
				{
					goto IL_0B4F;
				}
				goto IL_0061;
			}
			return;
			IL_4695:
			WP6RZJql8gZrNhVA9v.zg2y0Yf8teq2aJWnZL();
		}

		// Token: 0x0600039B RID: 923 RVA: 0x000263E0 File Offset: 0x000245E0
		internal static object PvroikJllY(object object_0)
		{
			try
			{
				if (File.Exists(((Assembly)object_0).Location))
				{
					return ((Assembly)object_0).Location;
				}
			}
			catch
			{
			}
			try
			{
				if (File.Exists(((Assembly)object_0).GetName().CodeBase.ToString().Replace("file:///", "")))
				{
					return ((Assembly)object_0).GetName().CodeBase.ToString().Replace("file:///", "");
				}
			}
			catch
			{
			}
			try
			{
				if (File.Exists(object_0.GetType().GetProperty("Location").GetValue(object_0, new object[0])
					.ToString()))
				{
					return object_0.GetType().GetProperty("Location").GetValue(object_0, new object[0])
						.ToString();
				}
			}
			catch
			{
			}
			return "";
		}

		// Token: 0x0600039C RID: 924
		[DllImport("kernel32")]
		public static extern IntPtr LoadLibrary(string string_0);

		// Token: 0x0600039D RID: 925
		[DllImport("kernel32", CharSet = CharSet.Ansi)]
		public static extern IntPtr GetProcAddress(IntPtr intptr_0, string string_0);

		// Token: 0x0600039E RID: 926 RVA: 0x000264EC File Offset: 0x000246EC
		private static IntPtr w3ZoqRBn5p(IntPtr intptr_0, string string_0, uint uint_0)
		{
			if (WP6RZJql8gZrNhVA9v.BV0kmUIPgx == null)
			{
				IntPtr procAddress = WP6RZJql8gZrNhVA9v.GetProcAddress(WP6RZJql8gZrNhVA9v.umLocehuEC(), "Find ".Trim() + "ResourceA");
				WP6RZJql8gZrNhVA9v.BV0kmUIPgx = (WP6RZJql8gZrNhVA9v.MacgPI7JyVeAhNaPvd)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(WP6RZJql8gZrNhVA9v.MacgPI7JyVeAhNaPvd));
			}
			return WP6RZJql8gZrNhVA9v.BV0kmUIPgx(intptr_0, string_0, uint_0);
		}

		// Token: 0x0600039F RID: 927 RVA: 0x00026548 File Offset: 0x00024748
		private static IntPtr YDsoA9ylfU(IntPtr intptr_0, uint uint_0, uint uint_1, uint uint_2)
		{
			if (WP6RZJql8gZrNhVA9v.yBRkv0eFeZ == null)
			{
				IntPtr procAddress = WP6RZJql8gZrNhVA9v.GetProcAddress(WP6RZJql8gZrNhVA9v.umLocehuEC(), "Virtual ".Trim() + "Alloc");
				WP6RZJql8gZrNhVA9v.yBRkv0eFeZ = (WP6RZJql8gZrNhVA9v.GL8NaIwq2KOvLQhMFX)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(WP6RZJql8gZrNhVA9v.GL8NaIwq2KOvLQhMFX));
			}
			return WP6RZJql8gZrNhVA9v.yBRkv0eFeZ(intptr_0, uint_0, uint_1, uint_2);
		}

		// Token: 0x060003A0 RID: 928 RVA: 0x000265A4 File Offset: 0x000247A4
		private static int mTfoQqVbOE(IntPtr intptr_0, IntPtr intptr_1, [In] [Out] byte[] byte_0, uint uint_0, out IntPtr intptr_2)
		{
			if (WP6RZJql8gZrNhVA9v.tTVkFDSO7A == null)
			{
				IntPtr procAddress = WP6RZJql8gZrNhVA9v.GetProcAddress(WP6RZJql8gZrNhVA9v.umLocehuEC(), "Write ".Trim() + "Process ".Trim() + "Memory");
				WP6RZJql8gZrNhVA9v.tTVkFDSO7A = (WP6RZJql8gZrNhVA9v.yy2w1VXOQgx806ubre)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(WP6RZJql8gZrNhVA9v.yy2w1VXOQgx806ubre));
			}
			return WP6RZJql8gZrNhVA9v.tTVkFDSO7A(intptr_0, intptr_1, byte_0, uint_0, out intptr_2);
		}

		// Token: 0x060003A1 RID: 929 RVA: 0x0002660C File Offset: 0x0002480C
		private static int YeeoMqaS3J(IntPtr intptr_0, int int_0, int int_1, ref int int_2)
		{
			if (WP6RZJql8gZrNhVA9v.zIOkYypt1M == null)
			{
				IntPtr procAddress = WP6RZJql8gZrNhVA9v.GetProcAddress(WP6RZJql8gZrNhVA9v.umLocehuEC(), "Virtual ".Trim() + "Protect");
				WP6RZJql8gZrNhVA9v.zIOkYypt1M = (WP6RZJql8gZrNhVA9v.N7UlhA3IRW2ugh7tWg)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(WP6RZJql8gZrNhVA9v.N7UlhA3IRW2ugh7tWg));
			}
			return WP6RZJql8gZrNhVA9v.zIOkYypt1M(intptr_0, int_0, int_1, ref int_2);
		}

		// Token: 0x060003A2 RID: 930 RVA: 0x00026668 File Offset: 0x00024868
		private static IntPtr tdOo5aPwrv(uint uint_0, int int_0, uint uint_1)
		{
			if (WP6RZJql8gZrNhVA9v.tuYkt9D06I == null)
			{
				IntPtr procAddress = WP6RZJql8gZrNhVA9v.GetProcAddress(WP6RZJql8gZrNhVA9v.umLocehuEC(), "Open ".Trim() + "Process");
				WP6RZJql8gZrNhVA9v.tuYkt9D06I = (WP6RZJql8gZrNhVA9v.RI754BJF754hNSApRW)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(WP6RZJql8gZrNhVA9v.RI754BJF754hNSApRW));
			}
			return WP6RZJql8gZrNhVA9v.tuYkt9D06I(uint_0, int_0, uint_1);
		}

		// Token: 0x060003A3 RID: 931 RVA: 0x000266C4 File Offset: 0x000248C4
		private static int Q2sob65b9D(IntPtr intptr_0)
		{
			if (WP6RZJql8gZrNhVA9v.etmkyDG2SG == null)
			{
				IntPtr procAddress = WP6RZJql8gZrNhVA9v.GetProcAddress(WP6RZJql8gZrNhVA9v.umLocehuEC(), "Close ".Trim() + "Handle");
				WP6RZJql8gZrNhVA9v.etmkyDG2SG = (WP6RZJql8gZrNhVA9v.YLCGmBEaUwBbEqLM01)Marshal.GetDelegateForFunctionPointer(procAddress, typeof(WP6RZJql8gZrNhVA9v.YLCGmBEaUwBbEqLM01));
			}
			return WP6RZJql8gZrNhVA9v.etmkyDG2SG(intptr_0);
		}

		// Token: 0x060003A4 RID: 932 RVA: 0x0000439B File Offset: 0x0000259B
		private static IntPtr umLocehuEC()
		{
			if (WP6RZJql8gZrNhVA9v.K7PkOHxqAd == IntPtr.Zero)
			{
				WP6RZJql8gZrNhVA9v.K7PkOHxqAd = WP6RZJql8gZrNhVA9v.LoadLibrary("kernel ".Trim() + "32.dll");
			}
			return WP6RZJql8gZrNhVA9v.K7PkOHxqAd;
		}

		// Token: 0x060003A5 RID: 933 RVA: 0x0002671C File Offset: 0x0002491C
		[WP6RZJql8gZrNhVA9v.RJDcsuMfOxrTCYImPe(typeof(WP6RZJql8gZrNhVA9v.RJDcsuMfOxrTCYImPe.iGR41459RDH4FvPdNk<object>[]))]
		private static byte[] VZpoRI2LOR(string string_0)
		{
			byte[] array;
			using (FileStream fileStream = new FileStream(string_0, FileMode.Open, FileAccess.Read, FileShare.Read))
			{
				int num = 0;
				long length = fileStream.Length;
				int i = (int)length;
				array = new byte[i];
				while (i > 0)
				{
					int num2 = fileStream.Read(array, num, i);
					num += num2;
					i -= num2;
				}
			}
			return array;
		}

		// Token: 0x060003A6 RID: 934 RVA: 0x000043D1 File Offset: 0x000025D1
		internal static Stream Njco6C1nc4()
		{
			return new MemoryStream();
		}

		// Token: 0x060003A7 RID: 935 RVA: 0x000043D8 File Offset: 0x000025D8
		internal static byte[] rLIoBbVVpm(Stream stream_0)
		{
			return ((MemoryStream)stream_0).ToArray();
		}

		// Token: 0x060003A8 RID: 936 RVA: 0x00026784 File Offset: 0x00024984
		[WP6RZJql8gZrNhVA9v.RJDcsuMfOxrTCYImPe(typeof(WP6RZJql8gZrNhVA9v.RJDcsuMfOxrTCYImPe.iGR41459RDH4FvPdNk<object>[]))]
		private static byte[] oN9oGXMAK7(byte[] byte_0)
		{
			Stream stream = WP6RZJql8gZrNhVA9v.Njco6C1nc4();
			SymmetricAlgorithm symmetricAlgorithm = WP6RZJql8gZrNhVA9v.PEXoCqmS4w();
			symmetricAlgorithm.Key = new byte[]
			{
				123, 5, 74, 12, 244, 156, 221, 154, 121, 221,
				183, 41, 121, 65, 9, 43, 67, 81, 23, 43,
				74, 63, 64, 23, 95, 185, 226, 244, 45, 194,
				211, 43
			};
			symmetricAlgorithm.IV = new byte[]
			{
				117, 254, 41, 121, 65, 52, 9, 43, 221, 154,
				12, 54, 68, 241, 68, 66
			};
			CryptoStream cryptoStream = new CryptoStream(stream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Write);
			cryptoStream.Write(byte_0, 0, byte_0.Length);
			cryptoStream.Close();
			byte[] array = WP6RZJql8gZrNhVA9v.rLIoBbVVpm(stream);
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			return array;
		}

		// Token: 0x060003A9 RID: 937 RVA: 0x000267FC File Offset: 0x000249FC
		private byte[] JBbo7fndGL()
		{
			string text = "{11111-22222-10001-00001}";
			if (text.Length > 0)
			{
				return new byte[] { 1, 2 };
			}
			return new byte[] { 1, 2 };
		}

		// Token: 0x060003AA RID: 938 RVA: 0x0002683C File Offset: 0x00024A3C
		private byte[] tM1owh06yH()
		{
			string text = "{11111-22222-10001-00002}";
			if (text.Length > 0)
			{
				return new byte[] { 1, 2 };
			}
			return new byte[] { 1, 2 };
		}

		// Token: 0x060003AB RID: 939 RVA: 0x0002687C File Offset: 0x00024A7C
		private byte[] HpuoXD9KwB()
		{
			string text = "{11111-22222-20001-00001}";
			if (text.Length > 0)
			{
				return new byte[] { 1, 2 };
			}
			return new byte[] { 1, 2 };
		}

		// Token: 0x060003AC RID: 940 RVA: 0x000268BC File Offset: 0x00024ABC
		private byte[] vLyo3J8m2E()
		{
			string text = "{11111-22222-20001-00002}";
			if (text.Length > 0)
			{
				return new byte[] { 1, 2 };
			}
			return new byte[] { 1, 2 };
		}

		// Token: 0x060003AD RID: 941 RVA: 0x000268FC File Offset: 0x00024AFC
		private byte[] fnqoJe2xAG()
		{
			return null;
		}

		// Token: 0x060003AE RID: 942 RVA: 0x000268FC File Offset: 0x00024AFC
		private byte[] IHuoEWDKCc()
		{
			return null;
		}

		// Token: 0x060003AF RID: 943 RVA: 0x0002690C File Offset: 0x00024B0C
		internal byte[] J6JoHkltLH()
		{
			string text = "{11111-22222-40001-00001}";
			if (text.Length > 0)
			{
				return new byte[] { 1, 2 };
			}
			return new byte[] { 1, 2 };
		}

		// Token: 0x060003B0 RID: 944 RVA: 0x0002694C File Offset: 0x00024B4C
		internal byte[] FtroUJNIfo()
		{
			string text = "{11111-22222-40001-00002}";
			if (text.Length > 0)
			{
				return new byte[] { 1, 2 };
			}
			return new byte[] { 1, 2 };
		}

		// Token: 0x060003B1 RID: 945 RVA: 0x0002698C File Offset: 0x00024B8C
		internal byte[] KIxoTLeGZr()
		{
			string text = "{11111-22222-50001-00001}";
			if (text.Length > 0)
			{
				return new byte[] { 1, 2 };
			}
			return new byte[] { 1, 2 };
		}

		// Token: 0x060003B2 RID: 946 RVA: 0x000269CC File Offset: 0x00024BCC
		internal byte[] S0yo9WrR0W()
		{
			string text = "{11111-22222-50001-00002}";
			if (text.Length > 0)
			{
				return new byte[] { 1, 2 };
			}
			return new byte[] { 1, 2 };
		}

		// Token: 0x060003B4 RID: 948 RVA: 0x000043ED File Offset: 0x000025ED
		internal static IntPtr k3A5xmYbdQkDBLoHFb(IntPtr intptr_0, int int_0)
		{
			return Marshal.ReadIntPtr(intptr_0, int_0);
		}

		// Token: 0x060003B5 RID: 949 RVA: 0x000043FC File Offset: 0x000025FC
		internal static int swobvbXXmPhDXTXm88(IntPtr intptr_0, int int_0)
		{
			return Marshal.ReadInt32(intptr_0, int_0);
		}

		// Token: 0x060003B6 RID: 950 RVA: 0x0000440B File Offset: 0x0000260B
		internal static long HPPX7oC1352NeBiZaB(IntPtr intptr_0, int int_0)
		{
			return Marshal.ReadInt64(intptr_0, int_0);
		}

		// Token: 0x060003B7 RID: 951 RVA: 0x0000441A File Offset: 0x0000261A
		internal static void dTiCsUt8bdAoavmBNv(IntPtr intptr_0, int int_0, IntPtr intptr_1)
		{
			Marshal.WriteIntPtr(intptr_0, int_0, intptr_1);
		}

		// Token: 0x060003B8 RID: 952 RVA: 0x0000442D File Offset: 0x0000262D
		internal static void SEMrdPdZHGgNIZSO1O(IntPtr intptr_0, int int_0, int int_1)
		{
			Marshal.WriteInt32(intptr_0, int_0, int_1);
		}

		// Token: 0x060003B9 RID: 953 RVA: 0x00004440 File Offset: 0x00002640
		internal static void wFMUk08ftpCdKXVaY7(IntPtr intptr_0, int int_0, long long_0)
		{
			Marshal.WriteInt64(intptr_0, int_0, long_0);
		}

		// Token: 0x060003BA RID: 954 RVA: 0x00004453 File Offset: 0x00002653
		internal static IntPtr yMoAkRgfwbpT1WDXhi(int int_0)
		{
			return Marshal.AllocCoTaskMem(int_0);
		}

		// Token: 0x060003BB RID: 955 RVA: 0x0000445E File Offset: 0x0000265E
		internal static void amiZJawSB0ZaSQBdfI(object object_0, int int_0, IntPtr intptr_0, int int_1)
		{
			Marshal.Copy(object_0, int_0, intptr_0, int_1);
		}

		// Token: 0x060003BC RID: 956 RVA: 0x00004475 File Offset: 0x00002675
		internal static void JujIUwQla0VMlNrhaS()
		{
			WP6RZJql8gZrNhVA9v.svloy6EVGc();
		}

		// Token: 0x060003BD RID: 957 RVA: 0x0000447C File Offset: 0x0000267C
		internal static object KmKeX0bgSXhq1fq28N()
		{
			return Process.GetCurrentProcess();
		}

		// Token: 0x060003BE RID: 958 RVA: 0x00004483 File Offset: 0x00002683
		internal static object bm1fQjZhZNHsQkRyOn(object object_0)
		{
			return object_0.MainModule;
		}

		// Token: 0x060003BF RID: 959 RVA: 0x0000448E File Offset: 0x0000268E
		internal static IntPtr UAJlX83FojikbWHemo(object object_0)
		{
			return object_0.BaseAddress;
		}

		// Token: 0x060003C0 RID: 960 RVA: 0x00004499 File Offset: 0x00002699
		internal static IntPtr AJ6GN7KcvthHuwjypR(IntPtr intptr_0, object object_0, uint uint_0)
		{
			return WP6RZJql8gZrNhVA9v.w3ZoqRBn5p(intptr_0, object_0, uint_0);
		}

		// Token: 0x060003C1 RID: 961 RVA: 0x000044AC File Offset: 0x000026AC
		internal static bool sQlfTBBY0H5wIm9Z3H(IntPtr intptr_0, IntPtr intptr_1)
		{
			return intptr_0 != intptr_1;
		}

		// Token: 0x060003C2 RID: 962 RVA: 0x000044BB File Offset: 0x000026BB
		internal static void zg2y0Yf8teq2aJWnZL()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
		}

		// Token: 0x060003C3 RID: 963 RVA: 0x000044C2 File Offset: 0x000026C2
		internal static int O6Acp9IOtGsKlNgeas()
		{
			return IntPtr.Size;
		}

		// Token: 0x060003C4 RID: 964 RVA: 0x000044C9 File Offset: 0x000026C9
		internal static Type VbSEbDAwwZE4mU3b6d(object object_0, bool bool_0)
		{
			return Type.GetType(object_0, bool_0);
		}

		// Token: 0x060003C5 RID: 965 RVA: 0x000044D8 File Offset: 0x000026D8
		internal static bool pUG76uHlOlctFe7FPk(Type type_0, Type type_1)
		{
			return type_0 != type_1;
		}

		// Token: 0x060003C6 RID: 966 RVA: 0x000044E7 File Offset: 0x000026E7
		internal static object QXAPiWMFybI6qUa5Fy(object object_0)
		{
			return object_0.Modules;
		}

		// Token: 0x060003C7 RID: 967 RVA: 0x000044F2 File Offset: 0x000026F2
		internal static object hRsR9gcWuuXGGEJDaX(object object_0)
		{
			return object_0.GetEnumerator();
		}

		// Token: 0x060003C8 RID: 968 RVA: 0x000044FD File Offset: 0x000026FD
		internal static object oTcjQYPHTdNpOKif0G(object object_0)
		{
			return ((IEnumerator)object_0).Current;
		}

		// Token: 0x060003C9 RID: 969 RVA: 0x00004508 File Offset: 0x00002708
		internal static object ywAggiNPXCMhKIlgTC(object object_0)
		{
			return object_0.ModuleName;
		}

		// Token: 0x060003CA RID: 970 RVA: 0x00004513 File Offset: 0x00002713
		internal static object jK2TOwkUhmLnnHUb6u(object object_0)
		{
			return object_0.ToLower();
		}

		// Token: 0x060003CB RID: 971 RVA: 0x0000451E File Offset: 0x0000271E
		internal static bool DiXRJpEwdIUvepcObv(object object_0, object object_1)
		{
			return object_0 == object_1;
		}

		// Token: 0x060003CC RID: 972 RVA: 0x0000452D File Offset: 0x0000272D
		internal static object J5a8nm1HRWOQLFDo9S(object object_0)
		{
			return object_0.FileVersionInfo;
		}

		// Token: 0x060003CD RID: 973 RVA: 0x00004538 File Offset: 0x00002738
		internal static int gfqjHD9ktuAv81yJeu(object object_0)
		{
			return object_0.ProductMajorPart;
		}

		// Token: 0x060003CE RID: 974 RVA: 0x00004543 File Offset: 0x00002743
		internal static int HutOr42o6jcXNEiaFt(object object_0)
		{
			return object_0.ProductMinorPart;
		}

		// Token: 0x060003CF RID: 975 RVA: 0x0000454E File Offset: 0x0000274E
		internal static int wsq8JYndDHpXykO1eZ(object object_0)
		{
			return object_0.ProductBuildPart;
		}

		// Token: 0x060003D0 RID: 976 RVA: 0x00004559 File Offset: 0x00002759
		internal static int GDKc1Y0YijcSpMv8FZ(object object_0)
		{
			return object_0.ProductPrivatePart;
		}

		// Token: 0x060003D1 RID: 977 RVA: 0x00004564 File Offset: 0x00002764
		internal static bool bFtxxQv53tSJCBLhwj(object object_0, object object_1)
		{
			return object_0 >= object_1;
		}

		// Token: 0x060003D2 RID: 978 RVA: 0x00004573 File Offset: 0x00002773
		internal static bool LLU4PZx91pwM6AhMKu(object object_0, object object_1)
		{
			return object_0 < object_1;
		}

		// Token: 0x060003D3 RID: 979 RVA: 0x00004582 File Offset: 0x00002782
		internal static bool ewZ3B8GFII2oOk3KXO(object object_0)
		{
			return ((IEnumerator)object_0).MoveNext();
		}

		// Token: 0x060003D4 RID: 980 RVA: 0x0000458D File Offset: 0x0000278D
		internal static void A3Yh5RFFFw06bojsfa(object object_0)
		{
			((IDisposable)object_0).Dispose();
		}

		// Token: 0x060003D5 RID: 981 RVA: 0x00004598 File Offset: 0x00002798
		internal static object T7nuDZ5OSGQU84pSUt(object object_0, object object_1)
		{
			return object_0.GetManifestResourceStream(object_1);
		}

		// Token: 0x060003D6 RID: 982 RVA: 0x000045A7 File Offset: 0x000027A7
		internal static object Wqta94qIF2UoY3DUfP(object object_0)
		{
			return object_0.KDikMXewCI();
		}

		// Token: 0x060003D7 RID: 983 RVA: 0x000045B2 File Offset: 0x000027B2
		internal static void GhTBkML7lWmHOUJLvu(object object_0, long long_0)
		{
			object_0.Position = long_0;
		}

		// Token: 0x060003D8 RID: 984 RVA: 0x000045C1 File Offset: 0x000027C1
		internal static long G2NYB14TljE8aPpplT(object object_0)
		{
			return object_0.Length;
		}

		// Token: 0x060003D9 RID: 985 RVA: 0x000045CC File Offset: 0x000027CC
		internal static object IkVx6W7gxIo4U9w5rM(object object_0, int int_0)
		{
			return object_0.B2XkaLi4dH(int_0);
		}

		// Token: 0x060003DA RID: 986 RVA: 0x000045DB File Offset: 0x000027DB
		internal static void sDZRRXD0fxaC25PF88(object object_0)
		{
			Array.Reverse(object_0);
		}

		// Token: 0x060003DB RID: 987 RVA: 0x000045E6 File Offset: 0x000027E6
		internal static object cutG4jRhdD1EHWOltr(object object_0)
		{
			return object_0.GetName();
		}

		// Token: 0x060003DC RID: 988 RVA: 0x000045F1 File Offset: 0x000027F1
		internal static object b6kkEoSRgSgnV3yxh2(object object_0)
		{
			return object_0.GetPublicKeyToken();
		}

		// Token: 0x060003DD RID: 989 RVA: 0x000045FC File Offset: 0x000027FC
		internal static void akmBWvpHNGRy8htrfU(object object_0, int int_0, int int_1)
		{
			Array.Clear(object_0, int_0, int_1);
		}

		// Token: 0x060003DE RID: 990 RVA: 0x0000460F File Offset: 0x0000280F
		internal static object DR9AZjjdNREcZwIYAb(object object_0)
		{
			return object_0.GetModules();
		}

		// Token: 0x060003DF RID: 991 RVA: 0x0000461A File Offset: 0x0000281A
		internal static IntPtr kZQ8dAyUfWnWWqJUp8(object object_0)
		{
			return Marshal.GetHINSTANCE(object_0);
		}

		// Token: 0x060003E0 RID: 992 RVA: 0x00004625 File Offset: 0x00002825
		internal static object HVtG6OVrH4GYduNgRb(object object_0)
		{
			return object_0.Location;
		}

		// Token: 0x060003E1 RID: 993 RVA: 0x00004630 File Offset: 0x00002830
		internal static int DQB5bVrQeRYfHVIf8P(object object_0)
		{
			return object_0.Length;
		}

		// Token: 0x060003E2 RID: 994 RVA: 0x0000463B File Offset: 0x0000283B
		internal static int n23COQa21qSiSV34bx(object object_0)
		{
			return object_0.TVtkAMaqpL();
		}

		// Token: 0x060003E3 RID: 995 RVA: 0x00004646 File Offset: 0x00002846
		internal static object qG4I2OlWlNSst7kqpS()
		{
			return WP6RZJql8gZrNhVA9v.PEXoCqmS4w();
		}

		// Token: 0x060003E4 RID: 996 RVA: 0x0000464D File Offset: 0x0000284D
		internal static void pZirvkO3plqD0s2Ieu(object object_0, CipherMode cipherMode_0)
		{
			object_0.Mode = cipherMode_0;
		}

		// Token: 0x060003E5 RID: 997 RVA: 0x0000465C File Offset: 0x0000285C
		internal static object qgrAUuWmjXbCVLTFIo(object object_0, object object_1, object object_2)
		{
			return object_0.CreateDecryptor(object_1, object_2);
		}

		// Token: 0x060003E6 RID: 998 RVA: 0x0000466F File Offset: 0x0000286F
		internal static void HFqeTCUXpiOtLfNHOS(object object_0, object object_1, int int_0, int int_1)
		{
			object_0.Write(object_1, int_0, int_1);
		}

		// Token: 0x060003E7 RID: 999 RVA: 0x00004686 File Offset: 0x00002886
		internal static void ArXWYRma06fMRXvDFB(object object_0)
		{
			object_0.FlushFinalBlock();
		}

		// Token: 0x060003E8 RID: 1000 RVA: 0x00004691 File Offset: 0x00002891
		internal static object jnvtq3iCx4OYoUINoA(object object_0)
		{
			return object_0.ToArray();
		}

		// Token: 0x060003E9 RID: 1001 RVA: 0x0000469C File Offset: 0x0000289C
		internal static void Cv8hm26dWkilb1H7uG(object object_0)
		{
			object_0.Close();
		}

		// Token: 0x060003EA RID: 1002 RVA: 0x000046A7 File Offset: 0x000028A7
		internal static void QqvKs1oXadKmvr1FhM(object object_0)
		{
			object_0.VDqkQKyKML();
		}

		// Token: 0x060003EB RID: 1003 RVA: 0x000046B2 File Offset: 0x000028B2
		internal static int XJjeAvuYQjjJap119l(object object_0)
		{
			return object_0.Id;
		}

		// Token: 0x060003EC RID: 1004 RVA: 0x000046BD File Offset: 0x000028BD
		internal static IntPtr OFTGEXTEON2THecrHE(uint uint_0, int int_0, uint uint_1)
		{
			return WP6RZJql8gZrNhVA9v.tdOo5aPwrv(uint_0, int_0, uint_1);
		}

		// Token: 0x060003ED RID: 1005 RVA: 0x000046D0 File Offset: 0x000028D0
		internal static object cxBgTlJNLn7Vsrekt7(int int_0)
		{
			return BitConverter.GetBytes(int_0);
		}

		// Token: 0x060003EE RID: 1006 RVA: 0x000046DB File Offset: 0x000028DB
		internal static long U3uctGzVl7Uc86yBWE(object object_0)
		{
			return object_0.Position;
		}

		// Token: 0x060003EF RID: 1007 RVA: 0x000046E6 File Offset: 0x000028E6
		internal static void ubvua3hecKV44oZJiZx(IntPtr intptr_0, int int_0)
		{
			Marshal.WriteInt32(intptr_0, int_0);
		}

		// Token: 0x060003F0 RID: 1008 RVA: 0x000046F5 File Offset: 0x000028F5
		internal static int AhI1G3hhw7olV71pYD1(IntPtr intptr_0)
		{
			return WP6RZJql8gZrNhVA9v.Q2sob65b9D(intptr_0);
		}

		// Token: 0x060003F1 RID: 1009 RVA: 0x00004700 File Offset: 0x00002900
		internal static void kKd2fBhsYA0K0Yyxtft(object object_0, object object_1, object object_2)
		{
			object_0.Add(object_1, object_2);
		}

		// Token: 0x060003F2 RID: 1010 RVA: 0x00004713 File Offset: 0x00002913
		internal static Type HMmDSchYhBi0nCBpGT7(RuntimeTypeHandle runtimeTypeHandle_0)
		{
			return Type.GetTypeFromHandle(runtimeTypeHandle_0);
		}

		// Token: 0x060003F3 RID: 1011 RVA: 0x0000471E File Offset: 0x0000291E
		internal static int Ehe0uhhX0aen13qwCxL(long long_0)
		{
			return Convert.ToInt32(long_0);
		}

		// Token: 0x060003F4 RID: 1012 RVA: 0x00004729 File Offset: 0x00002929
		internal static object A1Ju77hCr9O8h9Qmym6()
		{
			return Encoding.UTF8;
		}

		// Token: 0x060003F5 RID: 1013 RVA: 0x00004730 File Offset: 0x00002930
		internal static object eTgynxhtgEVcRlyJcRL(object object_0, object object_1)
		{
			return object_0.GetString(object_1);
		}

		// Token: 0x060003F6 RID: 1014 RVA: 0x0000473F File Offset: 0x0000293F
		internal static bool eBS39ohdQ8KmmbnPINx(IntPtr intptr_0, IntPtr intptr_1)
		{
			return intptr_0 == intptr_1;
		}

		// Token: 0x060003F7 RID: 1015 RVA: 0x0000474E File Offset: 0x0000294E
		internal static object T5jTdMh84t7QTlT82Np(IntPtr intptr_0, Type type_0)
		{
			return WP6RZJql8gZrNhVA9v.iaKoOg5GGg(intptr_0, type_0);
		}

		// Token: 0x060003F8 RID: 1016 RVA: 0x0000475D File Offset: 0x0000295D
		internal static IntPtr wKVmWjhgE1OQ8sgXgBS(object object_0)
		{
			return object_0();
		}

		// Token: 0x060003F9 RID: 1017 RVA: 0x00004768 File Offset: 0x00002968
		internal static int GWY1vnhwhFRByTHqG90(IntPtr intptr_0)
		{
			return Marshal.ReadInt32(intptr_0);
		}

		// Token: 0x060003FA RID: 1018 RVA: 0x00004773 File Offset: 0x00002973
		internal static long qeXk8DhQ6H5BpiuRsJF(IntPtr intptr_0)
		{
			return Marshal.ReadInt64(intptr_0);
		}

		// Token: 0x060003FB RID: 1019 RVA: 0x0000477E File Offset: 0x0000297E
		internal static IntPtr kq4lKLhbtqXRHLrKScR(object object_0)
		{
			return Marshal.GetFunctionPointerForDelegate(object_0);
		}

		// Token: 0x060003FC RID: 1020 RVA: 0x00004789 File Offset: 0x00002989
		internal static int mbCK41hZIUxGEfPiUxd(object object_0)
		{
			return object_0.ModuleMemorySize;
		}

		// Token: 0x060003FD RID: 1021 RVA: 0x00004794 File Offset: 0x00002994
		internal static object woW3uTh3BLqd1RTLGjC(object object_0)
		{
			return object_0.EntryPoint;
		}

		// Token: 0x060003FE RID: 1022 RVA: 0x0000479F File Offset: 0x0000299F
		internal static bool zqn4VshKNT3WCTFCwJZ(object object_0, object object_1)
		{
			return object_0 != object_1;
		}

		// Token: 0x060003FF RID: 1023 RVA: 0x000047AE File Offset: 0x000029AE
		internal static object JR8JqwhBOfTB1T9vhCR(object object_0)
		{
			return object_0.Method;
		}

		// Token: 0x06000400 RID: 1024 RVA: 0x000047B9 File Offset: 0x000029B9
		internal static object tdcW58hfD532CID18nI(Type type_0, object object_0)
		{
			return Delegate.CreateDelegate(type_0, object_0);
		}

		// Token: 0x06000401 RID: 1025 RVA: 0x000047C8 File Offset: 0x000029C8
		internal static object NU0imqhIvW9D0YZELEm(object object_0)
		{
			return object_0.GetParameters();
		}

		// Token: 0x06000402 RID: 1026 RVA: 0x000047D3 File Offset: 0x000029D3
		internal static object gDkHBghANO2HqDrQPy0(object object_0)
		{
			return object_0.ManifestModule;
		}

		// Token: 0x06000403 RID: 1027 RVA: 0x000047DE File Offset: 0x000029DE
		internal static ModuleHandle f2EUdrhH7hx8TLHQiVt(object object_0)
		{
			return object_0.ModuleHandle;
		}

		// Token: 0x06000404 RID: 1028 RVA: 0x000047E9 File Offset: 0x000029E9
		internal static Type Nhga6qhMTaiRlHe59Ab(object object_0)
		{
			return object_0.GetType();
		}

		// Token: 0x06000405 RID: 1029 RVA: 0x000047F4 File Offset: 0x000029F4
		internal static object Nl7gdFhc9Q7mOSua7Px(object object_0, object object_1)
		{
			return object_0.GetValue(object_1);
		}

		// Token: 0x06000406 RID: 1030 RVA: 0x00004803 File Offset: 0x00002A03
		internal static object O5H60QhPORn2lsaWULs(long long_0)
		{
			return BitConverter.GetBytes(long_0);
		}

		// Token: 0x06000407 RID: 1031 RVA: 0x0000480E File Offset: 0x00002A0E
		internal static void r4I7EqhNy6xdDgjZqTE(object object_0)
		{
			RuntimeHelpers.PrepareDelegate(object_0);
		}

		// Token: 0x06000408 RID: 1032 RVA: 0x00004819 File Offset: 0x00002A19
		internal static RuntimeMethodHandle VMlvEXhkVXM5aaWaEAF(object object_0)
		{
			return object_0.MethodHandle;
		}

		// Token: 0x06000409 RID: 1033 RVA: 0x00004824 File Offset: 0x00002A24
		internal static void BTPZm9hE4v9u1uh1YUy(RuntimeMethodHandle runtimeMethodHandle_0)
		{
			RuntimeHelpers.PrepareMethod(runtimeMethodHandle_0);
		}

		// Token: 0x0600040A RID: 1034 RVA: 0x0000482F File Offset: 0x00002A2F
		internal static void IiGW2uh1LxBvU8RVDfb(object object_0, RuntimeFieldHandle runtimeFieldHandle_0)
		{
			RuntimeHelpers.InitializeArray(object_0, runtimeFieldHandle_0);
		}

		// Token: 0x0600040B RID: 1035 RVA: 0x0000483E File Offset: 0x00002A3E
		internal static IntPtr oq8Sffh95Uc0CDKB2bl(IntPtr intptr_0, uint uint_0, uint uint_1, uint uint_2)
		{
			return WP6RZJql8gZrNhVA9v.YDsoA9ylfU(intptr_0, uint_0, uint_1, uint_2);
		}

		// Token: 0x0600040C RID: 1036 RVA: 0x00004855 File Offset: 0x00002A55
		internal static void kpsSl1h2TjCEf0Ntlu7(IntPtr intptr_0, IntPtr intptr_1)
		{
			Marshal.WriteIntPtr(intptr_0, intptr_1);
		}

		// Token: 0x0600040D RID: 1037 RVA: 0x00004864 File Offset: 0x00002A64
		internal static bool J4jDXwhlvXrNWQwYJ9()
		{
			return null == null;
		}

		// Token: 0x0600040E RID: 1038 RVA: 0x0000486A File Offset: 0x00002A6A
		internal static object VlDjo1sTWsIPgwQqKr()
		{
			return null;
		}

		// Token: 0x04000652 RID: 1618
		private static bool PRZkZqsNsa = false;

		// Token: 0x04000653 RID: 1619
		private static bool V9fkgxQPQA = false;

		// Token: 0x04000654 RID: 1620
		private static bool LrEkS2eXQL = false;

		// Token: 0x04000655 RID: 1621
		private static Dictionary<int, int> Tqek0lIh21 = null;

		// Token: 0x04000656 RID: 1622
		private static byte[] OObkplyC7t = new byte[0];

		// Token: 0x04000657 RID: 1623
		private static IntPtr wcyk8nIyBt = IntPtr.Zero;

		// Token: 0x04000658 RID: 1624
		private static int Qy5kfBXtEh = 1;

		// Token: 0x04000659 RID: 1625
		private static bool MrkkWebIMK = false;

		// Token: 0x0400065A RID: 1626
		private static int XtMknffM5M = 0;

		// Token: 0x0400065B RID: 1627
		internal static WP6RZJql8gZrNhVA9v.QZEOeHRUkDiNqCWT0p rNZkehfwNu = null;

		// Token: 0x0400065C RID: 1628
		private static long eXJkjmTXDX = 0L;

		// Token: 0x0400065D RID: 1629
		private static int CgSk1JZr60 = 0;

		// Token: 0x0400065E RID: 1630
		[WP6RZJql8gZrNhVA9v.RJDcsuMfOxrTCYImPe(typeof(WP6RZJql8gZrNhVA9v.RJDcsuMfOxrTCYImPe.iGR41459RDH4FvPdNk<object>[]))]
		private static bool firstrundone = false;

		// Token: 0x0400065F RID: 1631
		private static WP6RZJql8gZrNhVA9v.N7UlhA3IRW2ugh7tWg zIOkYypt1M = null;

		// Token: 0x04000660 RID: 1632
		private static WP6RZJql8gZrNhVA9v.RI754BJF754hNSApRW tuYkt9D06I = null;

		// Token: 0x04000661 RID: 1633
		private static IntPtr K7PkOHxqAd = IntPtr.Zero;

		// Token: 0x04000662 RID: 1634
		private static long URnkCOceLK = 0L;

		// Token: 0x04000663 RID: 1635
		internal static Assembly x4Dk2IHVmX = typeof(WP6RZJql8gZrNhVA9v).Assembly;

		// Token: 0x04000664 RID: 1636
		private static int[] zl0ksqgIH1 = new int[0];

		// Token: 0x04000665 RID: 1637
		private static SortedList VM5kd0GoFG = new SortedList();

		// Token: 0x04000666 RID: 1638
		private static byte[] s6pkoGoeab = new byte[0];

		// Token: 0x04000667 RID: 1639
		private static WP6RZJql8gZrNhVA9v.GL8NaIwq2KOvLQhMFX yBRkv0eFeZ = null;

		// Token: 0x04000668 RID: 1640
		private static WP6RZJql8gZrNhVA9v.MacgPI7JyVeAhNaPvd BV0kmUIPgx = null;

		// Token: 0x04000669 RID: 1641
		private static byte[] HkLkNdDPtB = new byte[0];

		// Token: 0x0400066A RID: 1642
		private static IntPtr aatkD4ZSGk = IntPtr.Zero;

		// Token: 0x0400066B RID: 1643
		private static IntPtr VE2k4S5okQ = IntPtr.Zero;

		// Token: 0x0400066C RID: 1644
		internal static RSACryptoServiceProvider onZkkIlVOi = null;

		// Token: 0x0400066D RID: 1645
		private static object emjkxI4Yxp = new object();

		// Token: 0x0400066E RID: 1646
		internal static WP6RZJql8gZrNhVA9v.QZEOeHRUkDiNqCWT0p abxkLGOVrU = null;

		// Token: 0x0400066F RID: 1647
		private static WP6RZJql8gZrNhVA9v.yy2w1VXOQgx806ubre tTVkFDSO7A = null;

		// Token: 0x04000670 RID: 1648
		private static WP6RZJql8gZrNhVA9v.YLCGmBEaUwBbEqLM01 etmkyDG2SG = null;

		// Token: 0x04000671 RID: 1649
		private static object WaKkhokJrA = new string[0];

		// Token: 0x04000672 RID: 1650
		internal static Hashtable lmdkVksVkh = new Hashtable();

		// Token: 0x04000673 RID: 1651
		private static int wpoklx4RIX = 0;

		// Token: 0x04000674 RID: 1652
		private static uint[] O1BkIDx0L0 = new uint[]
		{
			3614090360U, 3905402710U, 606105819U, 3250441966U, 4118548399U, 1200080426U, 2821735955U, 4249261313U, 1770035416U, 2336552879U,
			4294925233U, 2304563134U, 1804603682U, 4254626195U, 2792965006U, 1236535329U, 4129170786U, 3225465664U, 643717713U, 3921069994U,
			3593408605U, 38016083U, 3634488961U, 3889429448U, 568446438U, 3275163606U, 4107603335U, 1163531501U, 2850285829U, 4243563512U,
			1735328473U, 2368359562U, 4294588738U, 2272392833U, 1839030562U, 4259657740U, 2763975236U, 1272893353U, 4139469664U, 3200236656U,
			681279174U, 3936430074U, 3572445317U, 76029189U, 3654602809U, 3873151461U, 530742520U, 3299628645U, 4096336452U, 1126891415U,
			2878612391U, 4237533241U, 1700485571U, 2399980690U, 4293915773U, 2240044497U, 1873313359U, 4264355552U, 2734768916U, 1309151649U,
			4149444226U, 3174756917U, 718787259U, 3951481745U
		};

		// Token: 0x04000675 RID: 1653
		private static bool xo4kuDarJK = false;

		// Token: 0x04000676 RID: 1654
		private static bool fMAkKtNIoA = false;

		// Token: 0x020000F0 RID: 240
		private sealed class vXgxlLQcVHhY7dY50X : MulticastDelegate
		{
			// Token: 0x0600040F RID: 1039
			public extern vXgxlLQcVHhY7dY50X(object object_0, IntPtr intptr_0);

			// Token: 0x06000410 RID: 1040
			public extern void Invoke(object o);

			// Token: 0x06000411 RID: 1041
			public extern IAsyncResult BeginInvoke(object o, AsyncCallback callback, object @object);

			// Token: 0x06000412 RID: 1042
			public extern void EndInvoke(IAsyncResult result);

			// Token: 0x06000413 RID: 1043 RVA: 0x000038AD File Offset: 0x00001AAD
			static vXgxlLQcVHhY7dY50X()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}
		}

		// Token: 0x020000F1 RID: 241
		internal class RJDcsuMfOxrTCYImPe : Attribute
		{
			// Token: 0x06000414 RID: 1044 RVA: 0x0000486D File Offset: 0x00002A6D
			[WP6RZJql8gZrNhVA9v.RJDcsuMfOxrTCYImPe(typeof(WP6RZJql8gZrNhVA9v.RJDcsuMfOxrTCYImPe.iGR41459RDH4FvPdNk<object>[]))]
			public RJDcsuMfOxrTCYImPe(object object_0)
			{
			}

			// Token: 0x06000415 RID: 1045 RVA: 0x000038AD File Offset: 0x00001AAD
			static RJDcsuMfOxrTCYImPe()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x020000F2 RID: 242
			internal class iGR41459RDH4FvPdNk<T>
			{
				// Token: 0x06000416 RID: 1046 RVA: 0x000038B4 File Offset: 0x00001AB4
				public iGR41459RDH4FvPdNk()
				{
					hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
					base..ctor();
				}

				// Token: 0x06000417 RID: 1047 RVA: 0x000038AD File Offset: 0x00001AAD
				static iGR41459RDH4FvPdNk()
				{
					WP6RZJql8gZrNhVA9v.prXoP4RuYp();
				}
			}
		}

		// Token: 0x020000F3 RID: 243
		internal class qcBC7nbplYPB6DW0yw
		{
			// Token: 0x06000418 RID: 1048 RVA: 0x00026A0C File Offset: 0x00024C0C
			[WP6RZJql8gZrNhVA9v.RJDcsuMfOxrTCYImPe(typeof(WP6RZJql8gZrNhVA9v.RJDcsuMfOxrTCYImPe.iGR41459RDH4FvPdNk<object>[]))]
			internal static string G9skPDgcXb(string string_0, string string_1)
			{
				byte[] bytes = Encoding.Unicode.GetBytes(string_0);
				byte[] array = bytes;
				byte[] array2 = new byte[]
				{
					82, 102, 104, 110, 32, 77, 24, 34, 118, 181,
					51, 17, 18, 51, 12, 109, 10, 32, 77, 24,
					34, 158, 161, 41, 97, 28, 118, 181, 5, 25,
					1, 88
				};
				byte[] array3 = WP6RZJql8gZrNhVA9v.XEDoeIU7mj(Encoding.Unicode.GetBytes(string_1));
				MemoryStream memoryStream = new MemoryStream();
				SymmetricAlgorithm symmetricAlgorithm = WP6RZJql8gZrNhVA9v.PEXoCqmS4w();
				symmetricAlgorithm.Key = array2;
				symmetricAlgorithm.IV = array3;
				CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write);
				cryptoStream.Write(array, 0, array.Length);
				cryptoStream.Close();
				return Convert.ToBase64String(memoryStream.ToArray());
			}

			// Token: 0x0600041A RID: 1050 RVA: 0x000038AD File Offset: 0x00001AAD
			static qcBC7nbplYPB6DW0yw()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}
		}

		// Token: 0x020000F4 RID: 244
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		internal sealed class QZEOeHRUkDiNqCWT0p : MulticastDelegate
		{
			// Token: 0x0600041B RID: 1051
			public extern QZEOeHRUkDiNqCWT0p(object object_0, IntPtr intptr_0);

			// Token: 0x0600041C RID: 1052
			public extern uint Invoke(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode);

			// Token: 0x0600041D RID: 1053
			public extern IAsyncResult BeginInvoke(IntPtr classthis, IntPtr comp, IntPtr info, [MarshalAs(UnmanagedType.U4)] uint flags, IntPtr nativeEntry, ref uint nativeSizeOfCode, AsyncCallback callback, object @object);

			// Token: 0x0600041E RID: 1054
			public extern uint EndInvoke(ref uint nativeSizeOfCode, IAsyncResult result);

			// Token: 0x0600041F RID: 1055 RVA: 0x000038AD File Offset: 0x00001AAD
			static QZEOeHRUkDiNqCWT0p()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}
		}

		// Token: 0x020000F5 RID: 245
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class OFfwWh6ZIHjfnqBOWx : MulticastDelegate
		{
			// Token: 0x06000420 RID: 1056
			public extern OFfwWh6ZIHjfnqBOWx(object object_0, IntPtr intptr_0);

			// Token: 0x06000421 RID: 1057
			public extern IntPtr Invoke();

			// Token: 0x06000422 RID: 1058
			public extern IAsyncResult BeginInvoke(AsyncCallback callback, object @object);

			// Token: 0x06000423 RID: 1059
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000424 RID: 1060 RVA: 0x000038AD File Offset: 0x00001AAD
			static OFfwWh6ZIHjfnqBOWx()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}
		}

		// Token: 0x020000F6 RID: 246
		internal struct BIpvxRBRb2dOGl802m
		{
			// Token: 0x04000677 RID: 1655
			internal bool JDNkifbo3S;

			// Token: 0x04000678 RID: 1656
			internal byte[] jsbkrdexts;
		}

		// Token: 0x020000F7 RID: 247
		internal class VtNVUKGulysZw81C3E
		{
			// Token: 0x06000425 RID: 1061 RVA: 0x00004875 File Offset: 0x00002A75
			public VtNVUKGulysZw81C3E(Stream stream_0)
			{
				this.KPVkbuTpLj = new BinaryReader(stream_0);
			}

			// Token: 0x06000426 RID: 1062 RVA: 0x00004889 File Offset: 0x00002A89
			internal Stream KDikMXewCI()
			{
				return this.KPVkbuTpLj.BaseStream;
			}

			// Token: 0x06000427 RID: 1063 RVA: 0x00004896 File Offset: 0x00002A96
			internal byte[] B2XkaLi4dH(int int_0)
			{
				return this.KPVkbuTpLj.ReadBytes(int_0);
			}

			// Token: 0x06000428 RID: 1064 RVA: 0x000048A4 File Offset: 0x00002AA4
			internal int hx5kqNgSj4(byte[] byte_0, int int_0, int int_1)
			{
				return this.KPVkbuTpLj.Read(byte_0, int_0, int_1);
			}

			// Token: 0x06000429 RID: 1065 RVA: 0x000048B4 File Offset: 0x00002AB4
			internal int TVtkAMaqpL()
			{
				return this.KPVkbuTpLj.ReadInt32();
			}

			// Token: 0x0600042A RID: 1066 RVA: 0x000048C1 File Offset: 0x00002AC1
			internal void VDqkQKyKML()
			{
				this.KPVkbuTpLj.Close();
			}

			// Token: 0x0600042B RID: 1067 RVA: 0x000038AD File Offset: 0x00001AAD
			static VtNVUKGulysZw81C3E()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x04000679 RID: 1657
			private BinaryReader KPVkbuTpLj;
		}

		// Token: 0x020000F8 RID: 248
		[UnmanagedFunctionPointer(CallingConvention.StdCall, CharSet = CharSet.Ansi)]
		private sealed class MacgPI7JyVeAhNaPvd : MulticastDelegate
		{
			// Token: 0x0600042C RID: 1068
			public extern MacgPI7JyVeAhNaPvd(object object_0, IntPtr intptr_0);

			// Token: 0x0600042D RID: 1069
			public extern IntPtr Invoke(IntPtr hModule, string lpName, uint lpType);

			// Token: 0x0600042E RID: 1070
			public extern IAsyncResult BeginInvoke(IntPtr hModule, string lpName, uint lpType, AsyncCallback callback, object @object);

			// Token: 0x0600042F RID: 1071
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000430 RID: 1072 RVA: 0x000038AD File Offset: 0x00001AAD
			static MacgPI7JyVeAhNaPvd()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}
		}

		// Token: 0x020000F9 RID: 249
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class GL8NaIwq2KOvLQhMFX : MulticastDelegate
		{
			// Token: 0x06000431 RID: 1073
			public extern GL8NaIwq2KOvLQhMFX(object object_0, IntPtr intptr_0);

			// Token: 0x06000432 RID: 1074
			public extern IntPtr Invoke(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect);

			// Token: 0x06000433 RID: 1075
			public extern IAsyncResult BeginInvoke(IntPtr lpAddress, uint dwSize, uint flAllocationType, uint flProtect, AsyncCallback callback, object @object);

			// Token: 0x06000434 RID: 1076
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000435 RID: 1077 RVA: 0x000038AD File Offset: 0x00001AAD
			static GL8NaIwq2KOvLQhMFX()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}
		}

		// Token: 0x020000FA RID: 250
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class yy2w1VXOQgx806ubre : MulticastDelegate
		{
			// Token: 0x06000436 RID: 1078
			public extern yy2w1VXOQgx806ubre(object object_0, IntPtr intptr_0);

			// Token: 0x06000437 RID: 1079
			public extern int Invoke(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten);

			// Token: 0x06000438 RID: 1080
			public extern IAsyncResult BeginInvoke(IntPtr hProcess, IntPtr lpBaseAddress, [In] [Out] byte[] buffer, uint size, out IntPtr lpNumberOfBytesWritten, AsyncCallback callback, object @object);

			// Token: 0x06000439 RID: 1081
			public extern int EndInvoke(out IntPtr lpNumberOfBytesWritten, IAsyncResult result);

			// Token: 0x0600043A RID: 1082 RVA: 0x000038AD File Offset: 0x00001AAD
			static yy2w1VXOQgx806ubre()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}
		}

		// Token: 0x020000FB RID: 251
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class N7UlhA3IRW2ugh7tWg : MulticastDelegate
		{
			// Token: 0x0600043B RID: 1083
			public extern N7UlhA3IRW2ugh7tWg(object object_0, IntPtr intptr_0);

			// Token: 0x0600043C RID: 1084
			public extern int Invoke(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect);

			// Token: 0x0600043D RID: 1085
			public extern IAsyncResult BeginInvoke(IntPtr lpAddress, int dwSize, int flNewProtect, ref int lpflOldProtect, AsyncCallback callback, object @object);

			// Token: 0x0600043E RID: 1086
			public extern int EndInvoke(ref int lpflOldProtect, IAsyncResult result);

			// Token: 0x0600043F RID: 1087 RVA: 0x000038AD File Offset: 0x00001AAD
			static N7UlhA3IRW2ugh7tWg()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}
		}

		// Token: 0x020000FC RID: 252
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class RI754BJF754hNSApRW : MulticastDelegate
		{
			// Token: 0x06000440 RID: 1088
			public extern RI754BJF754hNSApRW(object object_0, IntPtr intptr_0);

			// Token: 0x06000441 RID: 1089
			public extern IntPtr Invoke(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId);

			// Token: 0x06000442 RID: 1090
			public extern IAsyncResult BeginInvoke(uint dwDesiredAccess, int bInheritHandle, uint dwProcessId, AsyncCallback callback, object @object);

			// Token: 0x06000443 RID: 1091
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x06000444 RID: 1092 RVA: 0x000038AD File Offset: 0x00001AAD
			static RI754BJF754hNSApRW()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}
		}

		// Token: 0x020000FD RID: 253
		[UnmanagedFunctionPointer(CallingConvention.StdCall)]
		private sealed class YLCGmBEaUwBbEqLM01 : MulticastDelegate
		{
			// Token: 0x06000445 RID: 1093
			public extern YLCGmBEaUwBbEqLM01(object object_0, IntPtr intptr_0);

			// Token: 0x06000446 RID: 1094
			public extern int Invoke(IntPtr ptr);

			// Token: 0x06000447 RID: 1095
			public extern IAsyncResult BeginInvoke(IntPtr ptr, AsyncCallback callback, object @object);

			// Token: 0x06000448 RID: 1096
			public extern int EndInvoke(IAsyncResult result);

			// Token: 0x06000449 RID: 1097 RVA: 0x000038AD File Offset: 0x00001AAD
			static YLCGmBEaUwBbEqLM01()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}
		}

		// Token: 0x020000FE RID: 254
		[Flags]
		private enum AwgKvrHJUS3TxryUsj
		{

		}
	}
}
