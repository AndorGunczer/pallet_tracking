using ScanEventService.DTOs;
using ScanEventService.Models;

namespace ScanEventService.Applications;

public class CloseOutfeedProcessor
{
    public bool CanHandle(ScanEvent scan)
        => scan.Type == ScanType.CloseOutfeed;

    public async Task ProcessAsync(ScanEvent scan)
    {
        // domain rules
        // state transition
        // persist changes
        // publish event
    }
}