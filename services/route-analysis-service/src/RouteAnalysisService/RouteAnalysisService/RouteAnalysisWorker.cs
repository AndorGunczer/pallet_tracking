namespace RouteAnalysisService;

public class RouteAnalysisWorker : BackgroundService
{
    private readonly IKafkaConsumer _consumer;
    private readonly AppDbContext _db;
    private readonly IAlertPublisher _alerts;

    public RouteAnalysisWorker(IKafkaConsumer consumer, AppDbContext db, IAlertPublisher alerts)
    {
        _consumer = consumer;
        _db = db;
        _alerts = alerts;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        await _consumer.SubscribeAsync("pallet.scanned.v1", async (msg) =>
        {
            // Deserialize
            var payload = JsonSerializer.Deserialize<PalletScannedEvent>(msg);
            // Simple rule: if location is not allowed for pallet -> raise alert
            bool wrongRoute = await CheckWrongRoute(payload);
            if (wrongRoute)
            {
                var alert = new Alert {
                    PalletId = await ResolvePalletId(payload.PalletId),
                    AlertType = "wrong_route",
                    Details = JsonDocument.Parse("{\"location\":\"" + payload.LocationId + "\"}").RootElement,
                    Severity = 2
                };
                _db.Alerts.Add(alert);
                await _db.SaveChangesAsync();
                await _alerts.PublishAlert(alert);
            }
        });
    }

    private Task<bool> CheckWrongRoute(PalletScannedEvent ev)
    {
        // einfache Logik placeholder
        return Task.FromResult(false);
    }
}
