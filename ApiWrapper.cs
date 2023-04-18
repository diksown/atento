using Newtonsoft.Json.Linq;


namespace Atento
{
	class ApiWrapper
	{
		public static decimal randomDecimal(decimal smallest, decimal biggest)
		{
			Random rng = new Random();
			int decimalPlaces = 2;
			int powerOfTen = (int)Math.Pow(10, decimalPlaces);
			return (decimal)rng.Next((int)(smallest * powerOfTen), (int)(biggest * powerOfTen)) / powerOfTen;
		}

		public async static Task<decimal> mockGetStockPrice(string stockSymbol)
		{
			await Task.Delay(100);
			decimal mockStockPrice = randomDecimal(22.54M, 22.70M);
			return mockStockPrice;
		}

		public async static Task<decimal> getStockPrice(string stockSymbol)
		{
			using var client = new HttpClient();

			HttpResponseMessage response = await client.GetAsync($"https://brapi.dev/api/quote/{stockSymbol}");
			string content = await response.Content.ReadAsStringAsync();

			JObject json = JObject.Parse(content);

			string stockPriceFromApi = (string)json["results"][0]["regularMarketPrice"];

			decimal stockPrice = Convert.ToDecimal((string)json["results"][0]["regularMarketPrice"]);

			return stockPrice;
		}
	}
}