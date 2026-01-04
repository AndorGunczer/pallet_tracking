using ScanEventService.Models;

public class Pallet
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public int Quantity { get; set; }
    public DateTime CreatedAt { get; set; }
    
    public Guid PalletLocationId { get; set; }   // required FK
    public PalletLocation PalletLocation { get; set; }

    // Navigation Property
    public ICollection<ScanEvent> ScanEvents { get; set; } = new List<ScanEvent>();
}

// namespace ScanEventService.Models;
//
// public class Pallet
// {
//     public Guid Id { get; set; } = Guid.NewGuid();
//     public string Name { get; set; }
//     public string Description { get; set; }
//     
//     // Foreign Key
//     public Guid PalletLocationId { get; set; }
//
//     // Navigation Property
//     public PalletLocation PalletLocation { get; set; }
// }

