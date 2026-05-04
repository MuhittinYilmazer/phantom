using System;
using System.IO;
using dg3ypDAonQcOidMs0w;
using ICSharpCode.SharpZipLib.Core;
using ICSharpCode.SharpZipLib.Zip;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000D9 RID: 217
	internal class ZipManager
	{
		// Token: 0x0600035E RID: 862 RVA: 0x000204C8 File Offset: 0x0001E6C8
		public static void CreateZip(string sourceDirectory, string destinationArchive, string comment = null)
		{
			Logging.Log(string.Concat(new string[] { "Starting ZIP creation: Source='", sourceDirectory, "', Destination='", destinationArchive, "'" }), true);
			try
			{
				if (!Directory.Exists(sourceDirectory))
				{
					string text = "Source directory not found: " + sourceDirectory;
					Logging.Log(text, true);
				}
				else
				{
					using (FileStream fileStream = File.Create(destinationArchive))
					{
						using (ZipOutputStream zipOutputStream = new ZipOutputStream(fileStream))
						{
							zipOutputStream.SetLevel(9);
							Logging.Log("ZIP stream initialized with maximum compression.", true);
							ZipManager.AddDirectoryToZip(zipOutputStream, sourceDirectory, sourceDirectory);
							if (!string.IsNullOrEmpty(comment))
							{
								zipOutputStream.SetComment(comment);
								Logging.Log("ZIP archive comment added.", true);
							}
						}
					}
					Logging.Log("ZIP creation completed successfully: " + destinationArchive, true);
				}
			}
			catch (Exception ex)
			{
				Logging.Log("Error during ZIP creation: " + ex.Message, true);
			}
		}

		// Token: 0x0600035F RID: 863 RVA: 0x000205E4 File Offset: 0x0001E7E4
		private static void AddDirectoryToZip(ZipOutputStream zipStream, string currentDirectory, string baseDirectory)
		{
			try
			{
				string[] files = Directory.GetFiles(currentDirectory);
				foreach (string text in files)
				{
					string text2 = ZipManager.GetRelativePath(baseDirectory, text).Replace("\\", "/");
					ZipEntry zipEntry = new ZipEntry(text2)
					{
						DateTime = File.GetLastWriteTime(text),
						Size = new FileInfo(text).Length
					};
					zipStream.PutNextEntry(zipEntry);
					using (FileStream fileStream = File.OpenRead(text))
					{
						StreamUtils.Copy(fileStream, zipStream, new byte[4096]);
					}
					zipStream.CloseEntry();
				}
				string[] directories = Directory.GetDirectories(currentDirectory);
				foreach (string text3 in directories)
				{
					ZipManager.AddDirectoryToZip(zipStream, text3, baseDirectory);
				}
			}
			catch (Exception ex)
			{
				Logging.Log("Error while adding directory '" + currentDirectory + "' to ZIP: " + ex.Message, true);
			}
		}

		// Token: 0x06000360 RID: 864 RVA: 0x000206FC File Offset: 0x0001E8FC
		private static string GetRelativePath(string basePath, string fullPath)
		{
			if (string.IsNullOrEmpty(basePath))
			{
				throw new ArgumentNullException("basePath");
			}
			if (string.IsNullOrEmpty(fullPath))
			{
				throw new ArgumentNullException("fullPath");
			}
			Uri uri = new Uri(ZipManager.AppendDirectorySeparatorChar(basePath));
			Uri uri2 = new Uri(fullPath);
			string text;
			if (uri.Scheme != uri2.Scheme)
			{
				text = fullPath;
			}
			else
			{
				Uri uri3 = uri.MakeRelativeUri(uri2);
				string text2 = Uri.UnescapeDataString(uri3.ToString());
				if (uri2.Scheme.Equals("file", StringComparison.InvariantCultureIgnoreCase))
				{
					text2 = text2.Replace('/', Path.DirectorySeparatorChar);
				}
				text = text2;
			}
			return text;
		}

		// Token: 0x06000361 RID: 865 RVA: 0x00020794 File Offset: 0x0001E994
		private static string AppendDirectorySeparatorChar(string path)
		{
			string text;
			if (!ZipManager.EndsInDirectorySeparator(path))
			{
				text = path + Path.DirectorySeparatorChar.ToString();
			}
			else
			{
				text = path;
			}
			return text;
		}

		// Token: 0x06000362 RID: 866 RVA: 0x000207C8 File Offset: 0x0001E9C8
		private static bool EndsInDirectorySeparator(string path)
		{
			bool flag;
			if (string.IsNullOrEmpty(path))
			{
				flag = false;
			}
			else
			{
				char c = path[path.Length - 1];
				flag = c == Path.DirectorySeparatorChar || c == Path.AltDirectorySeparatorChar;
			}
			return flag;
		}

		// Token: 0x06000363 RID: 867 RVA: 0x000038B4 File Offset: 0x00001AB4
		public ZipManager()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000364 RID: 868 RVA: 0x000038AD File Offset: 0x00001AAD
		static ZipManager()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
