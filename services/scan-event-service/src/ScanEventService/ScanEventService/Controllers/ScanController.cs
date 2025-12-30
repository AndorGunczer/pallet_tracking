using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ScanEventService.Applications.Workflows;
using ScanEventService.Data;
using ScanEventService.Models;
using ScanEventService.DTOs;
using ScanEventService.Infrastructure.Kafka;

namespace ScanEventService.Controllers;

[ApiController]
[Route("api/scans")]
public class ScanController : ControllerBase
{
    private readonly AppDbContext _db;
    private readonly IKafkaProducer _producer;
    private readonly ScanWorkflow _scanWorkflow;

    public ScanController(AppDbContext db, IKafkaProducer producer, ScanWorkflow scanWorkflow)
    {
        _db = db;
        _producer = producer;
        _scanWorkflow = scanWorkflow;
    }

    // [HttpPost]
    // public async Task<IActionResult> PostScan([FromBody] ScanDto dto)
    // {
        // var Payload = JsonSerializer.Serialize(dto.Payload);
        

        
    //     PalletLocation palletLocation =
    //         await _db.PalletLocations.FirstOrDefaultAsync(l => l.LocationName == "EXIT");
    //
    //     if (palletLocation == null)
    //     {
    //         palletLocation = new PalletLocation
    //         {
    //             LocationName = "EXIT",
    //             LocationDescription = "Outfeed Place",
    //         };
    //             
    //         _db.PalletLocations.Add(palletLocation);
    //         await _db.SaveChangesAsync();
    //     }
    //     
    //     // Validierung
    //     var pallet = await _db.Pallets.FirstOrDefaultAsync(p => p.Name == dto.PalletName);
    //     
    //     if (pallet == null)
    //     {

    //         _db.Pallets.Add(pallet);
    //         await _db.SaveChangesAsync();
    //
    //     }
    //
    //     var scan = new ScanEvent
    //     {
    //         PalletId = pallet.Id,
    //         ScannerId = dto.ScannerId,
    //         PalletLocationId = dto.LocationId,
    //         EventTime = dto.EventTime,
    //         Payload = dto.Payload?.Clone()
    //     };
    //     Console.WriteLine(scan.Payload);
    //     _db.ScanEvents.Add(scan);
    //     await _db.SaveChangesAsync();
    //
    //     // publish kafka // topic key value
    //     await _producer.PublishAsync("pallet.scanned.v1", null, JsonSerializer.Serialize(new
    //     {
    //         scan.PalletId,
    //         scan.ScannerId,
    //         scan.PalletLocationId,
    //         scan.EventTime,
    //         Payload = scan.Payload?.GetRawText()
    //     }));
    //
    //     return Ok(new { status = "ok" });
    // }

    [HttpPost]
    public async Task<IActionResult> ScanAsync([FromBody] ScanDto scan)
    {
        await _scanWorkflow.ExecuteAsync(scan);
        return Ok(new { status = "ok" });
    }
}
