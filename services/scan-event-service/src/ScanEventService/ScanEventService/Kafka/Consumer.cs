using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Text;
// using ScanEventService.KafkaOptions;

namespace ScanEventService.Infrastructure.Kafka;
public sealed class UserEventsConsumer : BackgroundService
{
    private readonly KafkaOptions _opt;
    private readonly ILogger<UserEventsConsumer> _logger;
    public UserEventsConsumer(IOptions<KafkaOptions> opt, ILogger<UserEventsConsumer> logger)
    {
        _opt = opt.Value;
        _logger = logger;
    }
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        var cfg = new ConsumerConfig
        {
            BootstrapServers = _opt?.BootstrapServers,
            GroupId = "my-api-consumer-group",
            AutoOffsetReset = AutoOffsetReset.Earliest,
            EnableAutoCommit = false
        };
        using var consumer = new ConsumerBuilder<string, string>(cfg).Build();
        consumer.Subscribe(_opt.UserTopic);
        _logger.LogInformation("Kafka consumer iniciado. Ouvindo tópico {Topic}", _opt.UserTopic);
        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                var cr = consumer.Consume(stoppingToken);
                var eventType = GetHeader(cr.Message.Headers, "event_type");
                _logger.LogInformation("Mensagem recebida. Key={Key}, EventType={EventType}, Value={Value}",
                    cr.Message.Key, eventType, cr.Message.Value);
                // TODO: processar a mensagem
                consumer.Commit(cr);
            }
            catch (OperationCanceledException) { }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao consumir mensagem do Kafka.");
            }
        }
    }
    private static string GetHeader(Headers h, string key) =>
        h.TryGetLastBytes(key, out var bytes) && bytes is not null
            ? Encoding.UTF8.GetString(bytes)
            : string.Empty;
}