using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Threading;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Costura
{
	// Token: 0x020000EA RID: 234
	[CompilerGenerated]
	internal static class AssemblyLoader
	{
		// Token: 0x0600036E RID: 878 RVA: 0x00004258 File Offset: 0x00002458
		private static string CultureToString(CultureInfo culture)
		{
			if (culture == null)
			{
				return "";
			}
			return culture.Name;
		}

		// Token: 0x0600036F RID: 879 RVA: 0x00020870 File Offset: 0x0001EA70
		private static Assembly ReadExistingAssembly(AssemblyName name)
		{
			AppDomain currentDomain = AppDomain.CurrentDomain;
			Assembly[] assemblies = currentDomain.GetAssemblies();
			foreach (Assembly assembly in assemblies)
			{
				AssemblyName name2 = assembly.GetName();
				if (string.Equals(name2.Name, name.Name, StringComparison.InvariantCultureIgnoreCase) && string.Equals(AssemblyLoader.CultureToString(name2.CultureInfo), AssemblyLoader.CultureToString(name.CultureInfo), StringComparison.InvariantCultureIgnoreCase))
				{
					return assembly;
				}
			}
			return null;
		}

		// Token: 0x06000370 RID: 880 RVA: 0x000208E0 File Offset: 0x0001EAE0
		private static void CopyTo(Stream source, Stream destination)
		{
			byte[] array = new byte[81920];
			int num;
			while ((num = source.Read(array, 0, array.Length)) != 0)
			{
				destination.Write(array, 0, num);
			}
		}

		// Token: 0x06000371 RID: 881 RVA: 0x00020914 File Offset: 0x0001EB14
		private static Stream LoadStream(string fullName)
		{
			Assembly executingAssembly = Assembly.GetExecutingAssembly();
			if (fullName.EndsWith(".compressed"))
			{
				Stream stream;
				using (Stream manifestResourceStream = executingAssembly.GetManifestResourceStream(fullName))
				{
					using (DeflateStream deflateStream = new DeflateStream(manifestResourceStream, CompressionMode.Decompress))
					{
						MemoryStream memoryStream = new MemoryStream();
						AssemblyLoader.CopyTo(deflateStream, memoryStream);
						memoryStream.Position = 0L;
						stream = memoryStream;
					}
				}
				return stream;
			}
			return executingAssembly.GetManifestResourceStream(fullName);
		}

		// Token: 0x06000372 RID: 882 RVA: 0x000209A0 File Offset: 0x0001EBA0
		private static Stream LoadStream(Dictionary<string, string> resourceNames, string name)
		{
			string text;
			if (resourceNames.TryGetValue(name, out text))
			{
				return AssemblyLoader.LoadStream(text);
			}
			return null;
		}

		// Token: 0x06000373 RID: 883 RVA: 0x000209C0 File Offset: 0x0001EBC0
		private static byte[] ReadStream(Stream stream)
		{
			byte[] array = new byte[stream.Length];
			stream.Read(array, 0, array.Length);
			return array;
		}

		// Token: 0x06000374 RID: 884 RVA: 0x000209E8 File Offset: 0x0001EBE8
		private static Assembly ReadFromEmbeddedResources(Dictionary<string, string> assemblyNames, Dictionary<string, string> symbolNames, AssemblyName requestedAssemblyName)
		{
			string text = requestedAssemblyName.Name.ToLowerInvariant();
			if (requestedAssemblyName.CultureInfo != null && !string.IsNullOrEmpty(requestedAssemblyName.CultureInfo.Name))
			{
				text = requestedAssemblyName.CultureInfo.Name + "." + text;
			}
			byte[] array;
			using (Stream stream = AssemblyLoader.LoadStream(assemblyNames, text))
			{
				if (stream == null)
				{
					return null;
				}
				array = AssemblyLoader.ReadStream(stream);
			}
			using (Stream stream2 = AssemblyLoader.LoadStream(symbolNames, text))
			{
				if (stream2 != null)
				{
					byte[] array2 = AssemblyLoader.ReadStream(stream2);
					return Assembly.Load(array, array2);
				}
			}
			return Assembly.Load(array);
		}

		// Token: 0x06000375 RID: 885 RVA: 0x00020AA8 File Offset: 0x0001ECA8
		public static Assembly ResolveAssembly(object sender, ResolveEventArgs e)
		{
			object obj = AssemblyLoader.nullCacheLock;
			lock (obj)
			{
				if (AssemblyLoader.nullCache.ContainsKey(e.Name))
				{
					return null;
				}
			}
			AssemblyName assemblyName = new AssemblyName(e.Name);
			Assembly assembly = AssemblyLoader.ReadExistingAssembly(assemblyName);
			if (assembly != null)
			{
				return assembly;
			}
			assembly = AssemblyLoader.ReadFromEmbeddedResources(AssemblyLoader.assemblyNames, AssemblyLoader.symbolNames, assemblyName);
			if (assembly == null)
			{
				object obj2 = AssemblyLoader.nullCacheLock;
				lock (obj2)
				{
					AssemblyLoader.nullCache[e.Name] = true;
				}
				if ((assemblyName.Flags & AssemblyNameFlags.Retargetable) != AssemblyNameFlags.None)
				{
					assembly = Assembly.Load(assemblyName);
				}
			}
			return assembly;
		}

		// Token: 0x06000376 RID: 886 RVA: 0x00020B80 File Offset: 0x0001ED80
		static AssemblyLoader()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			AssemblyLoader.nullCacheLock = new object();
			AssemblyLoader.nullCache = new Dictionary<string, bool>();
			AssemblyLoader.assemblyNames = new Dictionary<string, string>();
			AssemblyLoader.symbolNames = new Dictionary<string, string>();
			AssemblyLoader.assemblyNames.Add("costura", "costura.costura.dll.compressed");
			AssemblyLoader.symbolNames.Add("costura", "costura.costura.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("icsharpcode.sharpziplib", "costura.icsharpcode.sharpziplib.dll.compressed");
			AssemblyLoader.symbolNames.Add("icsharpcode.sharpziplib", "costura.icsharpcode.sharpziplib.pdb.compressed");
			AssemblyLoader.assemblyNames.Add("newtonsoft.json", "costura.newtonsoft.json.dll.compressed");
			AssemblyLoader.assemblyNames.Add("system.diagnostics.diagnosticsource", "costura.system.diagnostics.diagnosticsource.dll.compressed");
		}

		// Token: 0x06000377 RID: 887 RVA: 0x00020C38 File Offset: 0x0001EE38
		public static void Attach()
		{
			if (Interlocked.Exchange(ref AssemblyLoader.isAttached, 1) == 1)
			{
				return;
			}
			AppDomain currentDomain = AppDomain.CurrentDomain;
			currentDomain.AssemblyResolve += AssemblyLoader.ResolveAssembly;
		}

		// Token: 0x0400064C RID: 1612
		private static object nullCacheLock;

		// Token: 0x0400064D RID: 1613
		private static Dictionary<string, bool> nullCache;

		// Token: 0x0400064E RID: 1614
		private static Dictionary<string, string> assemblyNames;

		// Token: 0x0400064F RID: 1615
		private static Dictionary<string, string> symbolNames;

		// Token: 0x04000650 RID: 1616
		private static int isAttached;
	}
}
