using Microsoft.EntityFrameworkCore;
using ScanEventService.Data;
using ScanEventService.Models;

namespace ScanEventService.Infrastructure;

public interface IPalletOutfeedService
{
    Task OutfeedAsync(ScanEvent scan);
}