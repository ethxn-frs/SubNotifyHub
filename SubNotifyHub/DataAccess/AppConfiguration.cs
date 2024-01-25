using Microsoft.Extensions.Configuration;

namespace SubNotifyHub.DataAccess;

public class AppConfiguration
{
    private static AppConfiguration? _instance;
    private static readonly object LockObject = new object();
    public IConfiguration Configuration { get; }
    private AppConfiguration()
    {
        var appSettingsPath = "/Users/ethan/Documents/dev/SubNotifyHub/SubNotifyHub/appsettings.json";
        Configuration = new ConfigurationBuilder()
            .AddJsonFile(appSettingsPath, optional: false, reloadOnChange: true)
            .Build();
    }

    public static AppConfiguration Instance
    {
        get
        {
            if (_instance != null) return _instance;
            lock (LockObject)
            {
                _instance ??= new AppConfiguration();
            }
            return _instance;
        }
    }
}