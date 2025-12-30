using ScanEventService.DTOs;
using ScanEventService.Models;

namespace ScanEventService.Applications;

public interface IScanProcessorResolver
{
    IScanProcessor Resolve(ScanEvent scan);
}