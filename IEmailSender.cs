namespace Atento
{
    internal interface IEmailSender
    {
        Task sendEmailAsync(string subject, string body);
        Task sendNotificationEmail(EmailSender.StockActionType emailType, string stockSymbol, decimal curStockPrice, decimal priceLimit);
    }
}