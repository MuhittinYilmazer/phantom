using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

// Token: 0x02000003 RID: 3
internal sealed class BerkelyParser
{
	// Token: 0x06000011 RID: 17 RVA: 0x00004D2C File Offset: 0x00002F2C
	public static KeyValuePair<string, byte[]>[] Parse(byte[] fileBytes)
	{
		List<KeyValuePair<string, byte[]>> list = new List<KeyValuePair<string, byte[]>>();
		uint num = BerkelyParser.ReadUIntBigEndian(fileBytes, 0);
		KeyValuePair<string, byte[]>[] array;
		if (num != 398689U)
		{
			array = null;
		}
		else
		{
			int num2 = (int)BerkelyParser.ReadUIntBigEndian(fileBytes, 12);
			int num3 = (int)BerkelyParser.ReadUIntBigEndian(fileBytes, 56);
			int num4 = 1;
			while (list.Count < num3)
			{
				int num5 = (num3 - list.Count) * 2;
				ushort[] array2 = new ushort[num5];
				for (int i = 0; i < num5; i++)
				{
					array2[i] = BitConverter.ToUInt16(fileBytes, num2 * num4 + 2 + i * 2);
				}
				Array.Sort<ushort>(array2);
				for (int j = 0; j < array2.Length; j += 2)
				{
					int num6 = (int)array2[j] + num2 * num4;
					int num7 = (int)array2[j + 1] + num2 * num4;
					int num8 = ((j + 2 >= array2.Length) ? (num2 + num2 * num4) : ((int)array2[j + 2] + num2 * num4));
					string @string = Encoding.Default.GetString(fileBytes, num7, num8 - num7);
					byte[] array3 = fileBytes.Skip(num6).Take(num7 - num6).ToArray<byte>();
					if (!string.IsNullOrWhiteSpace(@string))
					{
						list.Add(new KeyValuePair<string, byte[]>(@string, array3));
					}
				}
				num4++;
			}
			array = list.ToArray();
		}
		return array;
	}

	// Token: 0x06000012 RID: 18 RVA: 0x00004E78 File Offset: 0x00003078
	private static uint ReadUIntBigEndian(byte[] buffer, int offset)
	{
		return (uint)(((int)buffer[offset] << 24) | ((int)buffer[offset + 1] << 16) | ((int)buffer[offset + 2] << 8) | (int)buffer[offset + 3]);
	}

	// Token: 0x06000013 RID: 19 RVA: 0x000038B4 File Offset: 0x00001AB4
	public BerkelyParser()
	{
		hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
		base..ctor();
	}

	// Token: 0x06000014 RID: 20 RVA: 0x000038AD File Offset: 0x00001AAD
	static BerkelyParser()
	{
		WP6RZJql8gZrNhVA9v.prXoP4RuYp();
	}
}
