using System.Text.Json;
using System.Text.Json.Nodes;

namespace ScanEventService.DTOs;

public enum ScanType { Infeed, Outfeed, Waypoint }
public record ScanDto(string PalletName, string PalletDescription, Guid ScannerId, ScanType Type, string TargetLocation, DateTime EventTime, JsonElement? Payload);
