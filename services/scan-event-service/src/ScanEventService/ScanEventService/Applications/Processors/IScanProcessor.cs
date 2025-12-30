using ScanEventService.Models;

namespace ScanEventService.Applications;

public interface IScanProcessor
{
    bool CanHandle(ScanEvent scan);
    Task ProcessAsync(ScanEvent scan);
}