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

		private static string emailBodyTemplate(StockActionType emailType, string stockSymbol, decimal stockPrice)
		{
			return "not implemented";
		}

		private static string emailTitleTemplate(StockActionType emailType, string stockSymbol)
		{
			return "not implemented";
		}

		public static void MockSendEmail(StockActionType emailType, string stockSymbol, decimal stockPrice)
		{
			string emailBody = emailBodyTemplate(emailType, stockSymbol, stockPrice);
			string emailTitle = emailTitleTemplate(emailType, stockSymbol);

		}
	}
}