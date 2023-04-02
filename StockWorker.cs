namespace Atento
{
	class Worker
	{
		public static async Task watchStock(string stockSymbol, decimal priceToSell, decimal priceToBuy)
		{
			while (true)
			{
				decimal stockPrice = await ApiWrapper.MockGetStockPrice(stockSymbol);

				// These flags will be used to avoid sending multiple
				// emails suggesting the same thing
				bool shouldSendSellEmail = true;
				bool shouldSendBuyEmail = true;
				if (stockPrice > priceToSell && shouldSendSellEmail)
				{
					Email.MockSendEmail(Email.StockActionType.Buy, stockSymbol, stockPrice);
					shouldSendBuyEmail = true;
					shouldSendSellEmail = false;
				}
				if (stockPrice < priceToBuy && shouldSendBuyEmail)
				{
					Email.MockSendEmail(Email.StockActionType.Sell, stockSymbol, stockPrice);
					shouldSendSellEmail = true;
					shouldSendBuyEmail = false;
				}
			}
		}
	}
}