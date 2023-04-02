namespace Atento
{
	class Worker
	{
		public static async void watchStock(string stockSymbol)
		{
			while (true)
			{
				decimal stockPrice = await ApiWrapper.MockGetStockPrice(stockSymbol);
				Console.WriteLine($"The stock price for {stockSymbol} is currently ${stockPrice}");
			}
		}
	}
}