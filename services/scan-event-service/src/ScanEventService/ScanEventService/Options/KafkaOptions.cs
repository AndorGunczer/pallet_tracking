namespace ScanEventService.Infrastructure.Kafka;

public class KafkaOptions
{
    public string BootstrapServers { get; set; } = "0.0.0.0:9092";
    public string UserTopic { get; set; } = string.Empty;
}