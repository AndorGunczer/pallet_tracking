using ScanEventService.DTOs;
using ScanEventService.Models;

namespace ScanEventService.Applications;

public class ScanProcessorResolver : IScanProcessorResolver
{
    private readonly IEnumerable<IScanProcessor> _processors;

    public ScanProcessorResolver(IEnumerable<IScanProcessor> processors)
    {
        _processors = processors;
    }

    public IScanProcessor Resolve(ScanEvent scan)
    {
        var processor = _processors.FirstOrDefault(p => p.CanHandle(scan));

        if (processor == null)
            throw new InvalidOperationException(
                $"No processor found for scan type {scan.Type}");

        return processor;
    }
}