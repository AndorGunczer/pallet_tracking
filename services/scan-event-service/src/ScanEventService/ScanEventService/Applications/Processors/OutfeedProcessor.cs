using ScanEventService.DTOs;
using ScanEventService.Infrastructure;
using ScanEventService.Models;

namespace ScanEventService.Applications;

public class OutfeedProcessor : IScanProcessor
{
    IPalletOutfeedService _palletOutfeedService;
    public OutfeedProcessor(IPalletOutfeedService palletInfeedService)
    {
        _palletOutfeedService = palletInfeedService;
    }
    public bool CanHandle(ScanEvent scan)
        => scan.Type == ScanType.Outfeed;

    public async Task ProcessAsync(ScanEvent scan)
    {
        await _palletOutfeedService.OutfeedAsync(scan);
        // domain rules
        // state transition
        // persist changes
        // publish event
    }
}