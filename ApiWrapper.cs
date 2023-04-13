using Newtonsoft.Json.Linq;


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
			await Task.Delay(100);
			decimal mockStockPrice = randomDecimal(4, 5);
			return mockStockPrice;
		}

		public async static Task<decimal> getStockPrice(string stockSymbol)
		{
			using var client = new HttpClient();

			var response = await client.GetAsync($"https://brapi.dev/api/quote/{stockSymbol}");
			var content = await response.Content.ReadAsStringAsync();

			JObject json = JObject.Parse(content);

			decimal stockPrice = Convert.ToDecimal((string)json["results"][0]["regularMarketPrice"]);

			return stockPrice;
		}
	}
}