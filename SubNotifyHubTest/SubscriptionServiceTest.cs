using SubNotifyHub.Models;
using SubNotifyHub.Services;

namespace SubNotifyHubTest;

public class SubscriptionServiceTest
{
    [Fact]
    public void GetAllDailySub()
    {
        // Arrange
        var subscriptionService = new SubscriptionService();
        List<Subscription> dailySub; 

        // Act
        dailySub = subscriptionService.GetAllDailySubscriptions().ToList();

        // Assert
        Assert.Empty(dailySub);
    }
}