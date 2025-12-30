using AlertService.Models;
using Microsoft.EntityFrameworkCore;

namespace AlertService;

public class AlertsDbContext : DbContext
{
    public AlertsDbContext(DbContextOptions<AlertsDbContext> options) : base(options) {}
    public DbSet<Alert> Alerts { get; set; }
}
