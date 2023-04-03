namespace Atento
{
	class Email
	{
		// // TODO
		// public static void SendEmail()
		// {
		// }
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

		public static void MockSendEmail(StockActionType emailType, string stockSymbol, decimal curStockPrice, decimal priceLimit)
		{
			string emailTitle = emailTitleTemplate(emailType, stockSymbol, curStockPrice);
			string emailBody = emailBodyTemplate(emailType, stockSymbol, curStockPrice, priceLimit);

			Console.WriteLine(emailTitle);
			Console.WriteLine("");
			Console.WriteLine(emailBody);
			Console.WriteLine("==============");
		}
	}
}