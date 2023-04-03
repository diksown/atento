namespace Atento
{
	class Worker
	{
		private static int TimeBetweenApiCalls = 1000;

		public static async Task watchStock(string stockSymbol, decimal priceToSell, decimal priceToBuy)
		{
			// These flags will be used to avoid sending multiple
			// emails suggesting the same thing
			bool shouldSendSellEmail = true;
			bool shouldSendBuyEmail = true;
			decimal stockPrice = 0;

			while (true)
			{
				stockPrice = await ApiWrapper.MockGetStockPrice(stockSymbol);

				System.Console.WriteLine("Price is " + stockPrice);

				if (stockPrice > priceToSell && shouldSendSellEmail)
				{
					Email.MockSendEmail(
						Email.StockActionType.Sell,
						stockSymbol,
						stockPrice,
						priceToSell
					);
					shouldSendSellEmail = false;
				}

				if (stockPrice < priceToBuy && shouldSendBuyEmail)
				{
					Email.MockSendEmail(
						Email.StockActionType.Buy,
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