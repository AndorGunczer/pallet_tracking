using Microsoft.EntityFrameworkCore;
using ScanEventService.Data;
using ScanEventService.Models;

namespace ScanEventService.Infrastructure;

public class PalletInfeedService : IPalletInfeedService
{
    private AppDbContext _db;

    public PalletInfeedService(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task InfeedAsync(ScanEvent scan)
    {
        var location = await _db.PalletLocations.FirstOrDefaultAsync(x => x.LocationName == scan.TargetLocation);
        var pallet = new Pallet
        {
            Name = scan.PalletExternalName,
            Description = scan.PalletDescription,
            PalletLocationId = location.Id,
            Quantity = scan.Quantity,
            CreatedAt =  DateTime.UtcNow
        };
        
        if (location == null)
            throw new InvalidOperationException($"Location '{scan.TargetLocation}' not found.");
        
        _db.Pallets.Add(pallet);
        await _db.SaveChangesAsync();
    }
}