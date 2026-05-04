using System;
using System.Reflection;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace oRZtxCaSAYh6EEGEIZ
{
	// Token: 0x020000ED RID: 237
	internal class Idt5pgryuYoFVQiX6j
	{
		// Token: 0x0600037A RID: 890 RVA: 0x00020C6C File Offset: 0x0001EE6C
		internal static void FRTwAnEEJWa1U(int typemdt)
		{
			Type type = Idt5pgryuYoFVQiX6j.Kh2o8BSHbd.ResolveType(33554432 + typemdt);
			foreach (FieldInfo fieldInfo in type.GetFields())
			{
				MethodInfo methodInfo = (MethodInfo)Idt5pgryuYoFVQiX6j.Kh2o8BSHbd.ResolveMethod(fieldInfo.MetadataToken + 100663296);
				fieldInfo.SetValue(null, (MulticastDelegate)Delegate.CreateDelegate(type, methodInfo));
			}
		}

		// Token: 0x0600037B RID: 891 RVA: 0x000038B4 File Offset: 0x00001AB4
		public Idt5pgryuYoFVQiX6j()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x0600037C RID: 892 RVA: 0x00004269 File Offset: 0x00002469
		static Idt5pgryuYoFVQiX6j()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			Idt5pgryuYoFVQiX6j.Kh2o8BSHbd = typeof(Idt5pgryuYoFVQiX6j).Assembly.ManifestModule;
		}

		// Token: 0x04000651 RID: 1617
		internal static Module Kh2o8BSHbd;

		// Token: 0x020000EE RID: 238
		internal sealed class SFU4mbT3GMret7THonf : MulticastDelegate
		{
			// Token: 0x0600037D RID: 893
			public extern SFU4mbT3GMret7THonf(object @object, IntPtr method);

			// Token: 0x0600037E RID: 894
			public extern void Invoke(object o);

			// Token: 0x0600037F RID: 895
			public extern IAsyncResult BeginInvoke(object o, AsyncCallback callback, object @object);

			// Token: 0x06000380 RID: 896
			public extern void EndInvoke(IAsyncResult result);

			// Token: 0x06000381 RID: 897 RVA: 0x000038AD File Offset: 0x00001AAD
			static SFU4mbT3GMret7THonf()
			{
				WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			}
		}
	}
}
