using ScanEventService.DTOs;
using ScanEventService.Models;

namespace ScanEventService.Applications;

public class OutfeedProcessor : IScanProcessor
{
    public bool CanHandle(ScanEvent scan)
        => scan.Type == ScanType.Outfeed;

    public async Task ProcessAsync(ScanEvent scan)
    {
        // domain rules
        // state transition
        // persist changes
        // publish event
    }
}