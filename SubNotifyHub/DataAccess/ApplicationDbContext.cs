using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SubNotifyHub.Models;

namespace SubNotifyHub.DataAccess
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Subscription> subscription { get; set; }
        private readonly IConfiguration _configuration;

        public ApplicationDbContext()
        {
            this._configuration = this._configuration = AppConfiguration.Instance.Configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var host = _configuration.GetSection("DatabaseConfig:Host").Value;
            var username = _configuration.GetSection("DatabaseConfig:Username").Value;
            var password = _configuration.GetSection("DatabaseConfig:Password").Value;
            var db = _configuration.GetSection("DatabaseConfig:DbName").Value;
            var connectionString = $"Host={host};Username={username};Password={password};Database={db}";
            optionsBuilder.UseNpgsql(connectionString);

            base.OnConfiguring(optionsBuilder);
        }
    }
}