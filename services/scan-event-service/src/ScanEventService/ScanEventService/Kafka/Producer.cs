using Confluent.Kafka;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
// using ScanEventService.KafkaOptions;

namespace ScanEventService.Infrastructure.Kafka;
public interface IKafkaProducer
{
    Task PublishAsync(string topic, string key, string value);
}
public sealed class KafkaProducer : IKafkaProducer
{
    private readonly KafkaOptions _opt;
    private readonly ILogger<KafkaProducer> _logger;
    public KafkaProducer(IOptions<KafkaOptions> opt, ILogger<KafkaProducer> logger)
    {
        _opt = opt.Value;
        _logger = logger;
    }
    public async Task PublishAsync(string topic, string key, string value)
    {
        var cfg = new ProducerConfig
        {
            BootstrapServers = _opt.BootstrapServers
        };
        using var producer = new ProducerBuilder<string, string>(cfg).Build();
        try
        {
            var result = await producer.ProduceAsync(
                topic,
                new Message<string, string> { Key = key, Value = value });
            _logger.LogInformation("Mensagem publicada em {Topic} [Key={Key}, Offset={Offset}]",
                topic, key, result.Offset);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Erro ao publicar mensagem no Kafka.");
            throw;
        }
    }
}