namespace Atento
{
	class Worker
	{
		public static async Task watchStock(string stockSymbol, decimal priceToSell, decimal priceToBuy)
		{
			while (true)
			{
				decimal stockPrice = await ApiWrapper.MockGetStockPrice(stockSymbol);
				Console.WriteLine($"The stock price for {stockSymbol} is currently ${stockPrice}");

			}
		}
	}
}