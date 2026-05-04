using System;
using System.IO;
using System.Text;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000094 RID: 148
	internal sealed class Logging
	{
		// Token: 0x060001BF RID: 447 RVA: 0x0001454C File Offset: 0x0001274C
		private static string FormatLogEntry(string text)
		{
			string text2 = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
			return string.Concat(new string[]
			{
				"[",
				text2,
				"] ",
				text,
				Environment.NewLine
			});
		}

		// Token: 0x060001C0 RID: 448 RVA: 0x0001459C File Offset: 0x0001279C
		public static bool Log(string text, bool ret = true)
		{
			string text2 = Logging.FormatLogEntry(text);
			if (Config.Debug == "1")
			{
				object @lock = Logging._lock;
				lock (@lock)
				{
					Logging.logBuffer.Append(text2);
					File.AppendAllText(Logging.Logfile, text2);
				}
			}
			return ret;
		}

		// Token: 0x060001C1 RID: 449 RVA: 0x00014608 File Offset: 0x00012808
		public static void Save(string sSavePath)
		{
			if (!(Config.Debug != "1") && File.Exists(Logging.Logfile))
			{
				try
				{
					File.Copy(Logging.Logfile, sSavePath, true);
				}
				catch
				{
				}
			}
		}

		// Token: 0x060001C2 RID: 450 RVA: 0x0001465C File Offset: 0x0001285C
		public static string GetBufferedLogs()
		{
			object @lock = Logging._lock;
			string text;
			lock (@lock)
			{
				text = Logging.logBuffer.ToString();
			}
			return text;
		}

		// Token: 0x060001C3 RID: 451 RVA: 0x000038B4 File Offset: 0x00001AB4
		public Logging()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x060001C4 RID: 452 RVA: 0x00003DDF File Offset: 0x00001FDF
		static Logging()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			Logging.Logfile = Path.Combine(Path.GetTempPath(), "Phantom-DebugFile.log");
			Logging._lock = new object();
			Logging.logBuffer = new StringBuilder();
		}

		// Token: 0x040004DD RID: 1245
		private static readonly string Logfile;

		// Token: 0x040004DE RID: 1246
		private static readonly object _lock;

		// Token: 0x040004DF RID: 1247
		private static readonly StringBuilder logBuffer;
	}
}
