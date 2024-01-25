using SubNotifyHub.Models;
using SubNotifyHub.Services;

namespace SubNotifyHub
{
    internal static class Program
    {
        private static  void  Main()
        {
            var webHookService = new WebHookService();
            var subscriptionService = new SubscriptionService();
            var nextMonth = DateTime.Now.AddMonths(1).ToString("MMMM");
            var nextYear = DateTime.Now.AddYears(1).Year;
            
            var allSubscriptions = subscriptionService.GetAllSubscriptions();
            var monthlySubscriptions = subscriptionService.GetAllMonthlySubscriptions();
            var yearlyDescriptions = subscriptionService.GetAllYearlySubscriptions();
            
            var totalMonthlySubscriptionPrice = monthlySubscriptions.Sum(s => s.Price);
            var totalSubscriptionPrice = allSubscriptions.Sum(s => s.Requerence == Requerence.MONTHLY  ? s.Price * 12 : s.Price);
            var totalYearlySubscriptionPrice = yearlyDescriptions.Sum(s => s.Price);

            var message =
                          $"\n 🚀🟥💵🤑 Abonnements à venir pour {nextMonth} 🤑💵🟥🚀 \n \n" +
                          $"💵 Total à payer pour {nextYear} : {totalSubscriptionPrice} € 💵 \n\n" +
                          $"💵 Le prix des abonnements pour le mois de {nextMonth} est : {totalMonthlySubscriptionPrice} €  💵 \n" +
                          "ℹ️ Détails des abonnements mensuels : ℹ️\n" +
                          $"{string.Join("\n", monthlySubscriptions.Select(s => $" - {s.Name} : {s.Price} €"))}\n" +
                          $"\n💵 Le prix des abonnements pour l'année {nextYear} est : {totalYearlySubscriptionPrice} € 💵 \n" +
                          "ℹ️ Détails des abonnements annuels : ℹ️\n" +
                          $"{string.Join("\n", yearlyDescriptions.Select(s => $" - {s.Name} : {s.Price} €"))} \n" +
                          $"\n @everyone \n" +
                          $"\n --------------------------------------------- ";
            
            webHookService.SendSubscriptionMessage(message).Wait();
        }
    }
}