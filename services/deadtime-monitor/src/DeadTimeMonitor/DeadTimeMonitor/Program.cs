// See https://aka.ms/new-console-template for more information

public class DeadTimeWorker : BackgroundService
{
    private readonly IServiceScopeFactory _scopeFactory;
    private readonly TimeSpan _interval = TimeSpan.FromMinutes(1);

    public DeadTimeWorker(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _scopeFactory.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<AppDbContext>();
            var threshold = DateTime.UtcNow.AddMinutes(-30); // configurable
            var stuck = await db.PalletLocations.Where(p => p.LastSeen < threshold).ToListAsync();
            foreach(var p in stuck)
            {
                var alert = new Alert {
                    PalletId = p.PalletId,
                    AlertType = "stuck",
                    Details = JsonDocument.Parse("{\"lastSeen\":\"" + p.LastSeen.ToString("o") + "\"}").RootElement,
                    Severity = 2
                };
                db.Alerts.Add(alert);
            }
            await db.SaveChangesAsync();
            await Task.Delay(_interval, stoppingToken);
        }
    }
}
