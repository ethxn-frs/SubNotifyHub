using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using SubNotifyHub.DataAccess;

namespace SubNotifyHub.Services
{
    public class WebHookService
    {
        private readonly IConfiguration _configuration;

        public WebHookService()
        {
            this._configuration = AppConfiguration.Instance.Configuration;
        }

        private record WebHookContent(string Content);

        public async Task SendMessage(string url, string message)
        {
            try
            {
                using (var client = new HttpClient())
                {
                    await client.PostAsJsonAsync(url, new WebHookContent(message));
                }

                Console.WriteLine("Message sent successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error sending message: {ex.Message}");
            }
        }

        public async Task SendSubscriptionMessage(string message)
        {
            var url = _configuration.GetSection("Discord:WebHookUrl").Value;
            await SendMessage(url ?? throw new InvalidOperationException(), message);
        }
    }
}