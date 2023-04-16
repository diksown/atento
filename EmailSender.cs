using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;

namespace Atento
{
	class EmailSender
	{
		public EmailSettings _emailSettings;
		public EmailSender()
		{
			IConfiguration config = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: false, reloadOnChange: true).Build();
			IConfigurationSection smtpConfig = config.GetSection("smtpConfig");

			_emailSettings = new EmailSettings
			{
				ToEmail = config["toEmail"],
				PrimaryDomain = smtpConfig["primaryDomain"],
				PrimaryPort = int.Parse(smtpConfig["primaryPort"]),
				SenderEmail = smtpConfig["senderEmail"],
				SenderPassword = smtpConfig["senderPassword"]
			};
		}

		public async Task sendEmailAsync(string subject, string body)
		{

			MailMessage mail = new MailMessage()
			{
				From = new MailAddress(_emailSettings.SenderEmail)
			};

			mail.To.Add(new MailAddress(_emailSettings.ToEmail));
			mail.Subject = subject;
			mail.Body = body;
			// mail.IsBodyHtml = true;
			using (SmtpClient smtp = new SmtpClient(_emailSettings.PrimaryDomain, _emailSettings.PrimaryPort))
			{
				smtp.Credentials = new NetworkCredential(_emailSettings.SenderEmail, _emailSettings.SenderPassword);
				// smtp.EnableSsl = true;
				await smtp.SendMailAsync(mail);
			}
		}

		public enum StockActionType
		{
			Buy, Sell
		}

		private static string fmtStock(decimal stockDecimal)
		{
			return string.Format("{0:0.00}", stockDecimal);
		}

		private static string emailBodyTemplate(StockActionType emailType, string stockSymbol, decimal curStockPrice, decimal priceLimit)
		{
			bool isBuying = emailType == StockActionType.Buy;
			string emailBody = "Olá!\n\n" +
			$"O valor das ações de {stockSymbol} está R${fmtStock(curStockPrice)}, " +
			$"{(isBuying ? "abaixo" : "acima")} do limite de R${fmtStock(priceLimit)} estabelecido por você. " +
			$"{(isBuying ? "Compre" : "Venda")} agora!\n\n" +
			"Atenciosamente,\n\n" +
			"Equipe atento.";
			return emailBody;
		}

		private static string emailTitleTemplate(StockActionType emailType, string stockSymbol, decimal curStockPrice)
		{
			bool isBuying = emailType == StockActionType.Buy;
			string emailTitle = $"{(isBuying ? "Compre" : "Venda")} " +
			$"ações de {stockSymbol} por R${fmtStock(curStockPrice)}";
			return emailTitle;
		}

		public static void mockSendNotificationEmail(StockActionType emailType, string stockSymbol, decimal curStockPrice, decimal priceLimit)
		{
			string emailTitle = emailTitleTemplate(emailType, stockSymbol, curStockPrice);
			string emailBody = emailBodyTemplate(emailType, stockSymbol, curStockPrice, priceLimit);

			Console.WriteLine(emailTitle);
			Console.WriteLine("");
			Console.WriteLine(emailBody);
			Console.WriteLine("==============");
		}

		public async Task sendNotificationEmail(StockActionType emailType, string stockSymbol, decimal curStockPrice, decimal priceLimit)
		{
			string emailTitle = emailTitleTemplate(emailType, stockSymbol, curStockPrice);
			string emailBody = emailBodyTemplate(emailType, stockSymbol, curStockPrice, priceLimit);

			await sendEmailAsync(emailTitle, emailBody);
		}
	}
}