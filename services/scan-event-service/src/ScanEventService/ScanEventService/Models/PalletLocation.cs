namespace ScanEventService.Models;

public class PalletLocation
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string LocationName { get; set; }
    public string LocationDescription { get; set; }
}