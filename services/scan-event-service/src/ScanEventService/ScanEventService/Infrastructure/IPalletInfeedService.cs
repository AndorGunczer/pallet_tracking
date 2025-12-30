using ScanEventService.Models;

namespace ScanEventService.Infrastructure;

public interface IPalletInfeedService
{
    Task InfeedAsync(ScanEvent scan);
}