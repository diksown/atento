namespace Atento
{
	class ApiWrapper
	{
		public static decimal randomDecimal(int smallest, int biggest)
		{
			Random rng = new Random();
			int decimalPlaces = 2;
			int powerOfTen = (int)Math.Pow(10, decimalPlaces);
			return (decimal)rng.Next(smallest * powerOfTen, biggest * powerOfTen) / powerOfTen;
		}

		// // TODO
		// public async static Task<decimal> GetStockPrice(string stockSymbol)
		// {
		// }
		public async static Task<decimal> MockGetStockPrice(string stockSymbol)
		{
			await Task.Delay(300);
			decimal mockStockPrice = randomDecimal(4, 5);
			return mockStockPrice;
		}
	}
}