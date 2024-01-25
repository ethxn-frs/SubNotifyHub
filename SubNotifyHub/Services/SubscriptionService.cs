using SubNotifyHub.DataAccess;
using SubNotifyHub.Models;

namespace SubNotifyHub.Services;

public class SubscriptionService
{
    private readonly ApplicationDbContext _context = new ApplicationDbContext();
    public List<Subscription> GetAllSubscriptions()
    {
        return _context.subscription.ToList();
    }
    
    public List<Subscription> GetAllDailySubscriptions()
    {
        return _context.subscription.Where(s => s.Requerence == Requerence.DAILY).ToList();
    }
    
    public List<Subscription> GetAllWeeklySubscriptions()
    {
        return _context.subscription.Where(s => s.Requerence == Requerence.WEEKLY).ToList();
    }
    
    public List<Subscription> GetAllMonthlySubscriptions()
    {
        return _context.subscription.Where(s => s.Requerence == Requerence.MONTHLY).ToList();
    }
    
    public List<Subscription> GetAllYearlySubscriptions()
    {
        return _context.subscription.Where(s => s.Requerence == Requerence.YEARLY).ToList();
    }
}