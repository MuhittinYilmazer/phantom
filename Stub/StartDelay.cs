using System;
using System.Threading;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000B5 RID: 181
	internal sealed class StartDelay
	{
		// Token: 0x0600029B RID: 667 RVA: 0x00019BD0 File Offset: 0x00017DD0
		public static void Run()
		{
			try
			{
				Random random = new Random();
				int num = random.Next(0, 10000);
				double num2 = (double)num / 1000.0;
				Logging.Log(string.Format("StartDelay: Sleeping for {0:0.00} seconds.", num2), true);
				Thread.Sleep(num);
			}
			catch (Exception ex)
			{
				Logging.Log("StartDelay: Error during delay. " + ex.Message, true);
			}
		}

		// Token: 0x0600029C RID: 668 RVA: 0x000038B4 File Offset: 0x00001AB4
		public StartDelay()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x0600029D RID: 669 RVA: 0x000038AD File Offset: 0x00001AAD
		static StartDelay()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
