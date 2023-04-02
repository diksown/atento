namespace Atento
{
	class Program
	{
		static void displayHelp(bool invalidCommand = false)
		{
			string description = "ATENTO - Alerta de TEndencias e Negociacoes para Traders Online";
			string invalidCommandMessage = "ERRO: Comando invalido.";
			string programName = AppDomain.CurrentDomain.FriendlyName;
			string helpMessage =
				$"Uso: {programName} <ativo> <preco_para_venda> <preco_para_compra>\n\n" +
				$"Exemplo: {programName} PETR4 22.67 22.59";
			if (invalidCommand)
			{
				helpMessage = description + "\n\n" + helpMessage;
			}
			else
			{
				helpMessage = invalidCommandMessage + "\n\n" + helpMessage;
			}
			Console.WriteLine(helpMessage);
		}

		static async Task Main(string[] args)
		{
			if (args.Length == 0)
			{
				displayHelp();
				return;
			}
			if (args.Length != 3)
			{
				displayHelp(invalidCommand: true);
				return;
			}
			decimal priceToSell = 0;
			decimal priceToBuy = 0;
			string stockSymbol = "";
			try
			{
				stockSymbol = args[0];
				priceToSell = Decimal.Parse(args[1]);
				priceToBuy = Decimal.Parse(args[2]);
			}
			catch (FormatException)
			{
				displayHelp(invalidCommand: true);
				return;
			}
			await Worker.watchStock(stockSymbol, priceToSell, priceToBuy);
		}
	}
}