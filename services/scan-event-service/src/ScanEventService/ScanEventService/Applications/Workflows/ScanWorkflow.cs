using ScanEventService.Models;

namespace ScanEventService.Applications.Workflows;

using ScanEventService.DTOs;
// using ScanEventService.Domain;
using ScanEventService.Applications;

public class ScanWorkflow
{
    private readonly IScanProcessorResolver _resolver;

    public ScanWorkflow(IScanProcessorResolver resolver)
    {
        _resolver = resolver;
    }

    public async Task ExecuteAsync(ScanDto dto)
    {
        // 1. Map DTO → Domain
        var scan = ScanEvent.CreateFrom(dto);

        // 2. Resolve correct processor
        var processor = _resolver.Resolve(scan);

        // 3. Execute domain behavior
        await processor.ProcessAsync(scan);
    }
}