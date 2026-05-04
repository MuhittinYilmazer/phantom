using System;
using System.Collections.Generic;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000008 RID: 8
	internal sealed class ASN1DER
	{
		// Token: 0x06000031 RID: 49 RVA: 0x0000700C File Offset: 0x0000520C
		public static ASN1DER.ASN1DERObject Parse(byte[] ASN1DERData)
		{
			ASN1DER.ASN1DERObject asn1DERObject = new ASN1DER.ASN1DERObject(ASN1DER.ASN1DERTypeEnum.None, 0, null);
			for (int i = 0; i < ASN1DERData.Length - 1; i++)
			{
				int num = (int)ASN1DERData[i + 1];
				ASN1DER.ASN1DERTypeEnum asn1DERTypeEnum = (ASN1DER.ASN1DERTypeEnum)ASN1DERData[i];
				if (asn1DERTypeEnum == ASN1DER.ASN1DERTypeEnum.Sequence)
				{
					byte[] array;
					if (asn1DERObject.length == 0)
					{
						asn1DERObject.type = ASN1DER.ASN1DERTypeEnum.Sequence;
						asn1DERObject.length = ASN1DERData.Length;
						array = new byte[ASN1DERData.Length];
					}
					else
					{
						asn1DERObject.objects.Add(new ASN1DER.ASN1DERObject(ASN1DER.ASN1DERTypeEnum.Sequence, num, null));
						array = new byte[num];
					}
					int num2 = ASN1DERData.Length - (i + 2);
					if (array.Length < num2)
					{
						num2 = array.Length;
					}
					Array.Copy(ASN1DERData, i + 2, array, 0, num2);
					asn1DERObject.objects.Add(ASN1DER.Parse(array));
					i += num + 1;
				}
				else if (asn1DERTypeEnum == ASN1DER.ASN1DERTypeEnum.Integer || asn1DERTypeEnum == ASN1DER.ASN1DERTypeEnum.OctetString || asn1DERTypeEnum == ASN1DER.ASN1DERTypeEnum.ObjectIdentifier)
				{
					byte[] array = new byte[num];
					int num3 = num;
					if (num + (i + 2) > ASN1DERData.Length)
					{
						num3 = ASN1DERData.Length - (i + 2);
					}
					Array.Copy(ASN1DERData, i + 2, array, 0, num3);
					asn1DERObject.objects.Add(new ASN1DER.ASN1DERObject(asn1DERTypeEnum, num, array));
					i += num + 1;
				}
			}
			return asn1DERObject;
		}

		// Token: 0x06000032 RID: 50 RVA: 0x000038B4 File Offset: 0x00001AB4
		public ASN1DER()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000033 RID: 51 RVA: 0x000038AD File Offset: 0x00001AAD
		static ASN1DER()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}

		// Token: 0x02000009 RID: 9
		public enum ASN1DERTypeEnum
		{
			// Token: 0x0400001D RID: 29
			None,
			// Token: 0x0400001E RID: 30
			Sequence = 48,
			// Token: 0x0400001F RID: 31
			Integer = 2,
			// Token: 0x04000020 RID: 32
			OctetString = 4,
			// Token: 0x04000021 RID: 33
			ObjectIdentifier = 6
		}

		// Token: 0x0200000A RID: 10
		public struct ASN1DERObject
		{
			// Token: 0x06000034 RID: 52 RVA: 0x0000391F File Offset: 0x00001B1F
			public ASN1DERObject(ASN1DER.ASN1DERTypeEnum _type, int _length, byte[] _data)
			{
				hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
				this.type = _type;
				this.length = _length;
				this.data = _data;
				this.objects = new List<ASN1DER.ASN1DERObject>();
			}

			// Token: 0x06000035 RID: 53 RVA: 0x000038AD File Offset: 0x00001AAD
			static ASN1DERObject()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}

			// Token: 0x04000022 RID: 34
			public ASN1DER.ASN1DERTypeEnum type;

			// Token: 0x04000023 RID: 35
			public int length;

			// Token: 0x04000024 RID: 36
			public List<ASN1DER.ASN1DERObject> objects;

			// Token: 0x04000025 RID: 37
			public byte[] data;
		}
	}
}
