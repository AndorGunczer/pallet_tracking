using System.Text.Json;
using System.Text.Json.Nodes;

namespace ScanEventService.DTOs;

public enum ScanType { Infeed, Outfeed, CloseOutfeed, Waypoint }
public record ScanDto(string PalletName, string PalletDescription, int Quantity, Guid ScannerId, ScanType Type, string TargetLocation, DateTime EventTime, JsonElement? Payload);
