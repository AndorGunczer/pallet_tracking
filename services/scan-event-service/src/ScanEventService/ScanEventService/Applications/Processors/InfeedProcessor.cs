using ScanEventService.DTOs;
using ScanEventService.Infrastructure;
using ScanEventService.Models;

namespace ScanEventService.Applications;

public class InfeedProcessor : IScanProcessor
{
    private readonly IPalletInfeedService _palletInfeedService;
    
    public InfeedProcessor(IPalletInfeedService palletInfeedService)
    {
        _palletInfeedService = palletInfeedService;
    }
    public bool CanHandle(ScanEvent scan)
        => scan.Type == ScanType.Infeed;

    public async Task ProcessAsync(ScanEvent scan)
    {
        await _palletInfeedService.InfeedAsync(scan);

        // domain rules
        // state transition
        // persist changes
        // publish event
    }
}