using Microsoft.EntityFrameworkCore;
using ScanEventService.Data;
using ScanEventService.Models;

namespace ScanEventService.Infrastructure;

public class PalletOutfeedService : IPalletOutfeedService
{
    private AppDbContext _db;

    public PalletOutfeedService(AppDbContext db)
    {
        _db = db;
    }
    
    public async Task OutfeedAsync(ScanEvent scan)
    {
        using var transaction = await _db.Database.BeginTransactionAsync();

        // Load pallets deterministically (FIFO example)
        var pallets = await _db.Pallets
            .Where(p => p.Name == scan.PalletExternalName && p.Quantity > 0)
            .OrderBy(p => p.CreatedAt) // REQUIRED
            .ToListAsync();

        if (!pallets.Any())
            throw new InvalidOperationException("No pallets found.");

        var totalQuantity = pallets.Sum(p => p.Quantity);

        if (totalQuantity < scan.Quantity)
            throw new InvalidOperationException("Insufficient pallet quantity.");

        var remaining = scan.Quantity;

        foreach (var pallet in pallets)
        {
            if (remaining <= 0)
                break;

            if (pallet.Quantity <= remaining)
            {
                remaining -= pallet.Quantity;
                _db.Pallets.Remove(pallet);
            }
            else
            {
                pallet.Quantity -= remaining;
                remaining = 0;
            }
        }

        await _db.SaveChangesAsync();
        await transaction.CommitAsync();
    }
}