namespace AlertService.Models;

public class Alert
{        
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Message { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public bool Acknowledged { get; set; } = false;
}