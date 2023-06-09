namespace Atento
{
	class Worker
	{
		private static int TimeBetweenApiCalls = 1000 * 60 * 5; // One request each 5 min

		public static async Task watchStock(string stockSymbol, decimal priceToSell, decimal priceToBuy)
		{
			// These flags will be used to avoid sending multiple
			// emails suggesting the same thing
			bool shouldSendSellEmail = true;
			bool shouldSendBuyEmail = true;
			decimal stockPrice = 0;
			EmailSender sender = new EmailSender();

			while (true)
			{
				stockPrice = await ApiWrapper.getStockPrice(stockSymbol);

				System.Console.WriteLine($"Valor do ativo {stockSymbol}: " + stockPrice);

				if (stockPrice > priceToSell && shouldSendSellEmail)
				{
					await sender.sendNotificationEmail(
						EmailSender.StockActionType.Sell,
						stockSymbol,
						stockPrice,
						priceToSell
					);
					shouldSendSellEmail = false;
				}

				if (stockPrice < priceToBuy && shouldSendBuyEmail)
				{
					await sender.sendNotificationEmail(
						EmailSender.StockActionType.Buy,
						stockSymbol,
						stockPrice,
						priceToBuy
					);
					shouldSendBuyEmail = false;
				}

				if (stockPrice <= priceToSell)
					shouldSendSellEmail = true;

				if (stockPrice >= priceToBuy)
					shouldSendBuyEmail = true;

				await Task.Delay(TimeBetweenApiCalls);
			}
		}
	}
}