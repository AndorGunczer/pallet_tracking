using System.Text.Json;
using System.Text.Json.Nodes;
using ScanEventService.DTOs;

namespace ScanEventService.Models;

public class ScanEvent
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid PalletId { get; set; }
    public string PalletExternalName { get; set; }
    public string PalletDescription { get; set; }
    public string TargetLocation { get; set; }
    public Guid ScannerId { get; set; }
    public ScanType Type { get; set; }   // ← THIS is the key addition
    public Guid PalletLocationId { get; set; }
    public DateTime EventTime { get; set; }   // Zeit des Events
    public JsonElement? Payload { get; set; }  // JSON-Daten

    // Navigation Properties
    public Pallet Pallet { get; set; }
    public PalletLocation PalletLocation { get; set; }    // falls du eine Location-Klasse hast
    
    // Create DTO on request
    public static ScanEvent CreateFrom(
        ScanDto dto)
    {
        // 1. Invariants
        if (dto == null)
            throw new ArgumentNullException(nameof(dto));

        // 3. Create valid domain object
        return new ScanEvent
        {
            PalletExternalName = dto.PalletName,
            PalletDescription = dto.PalletDescription,
            Type = dto.Type,
            TargetLocation = dto.TargetLocation,
            EventTime = dto.EventTime,
            Payload = dto.Payload?.Clone()
        };
    }
}