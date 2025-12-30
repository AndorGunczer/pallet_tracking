using AlertService.Hubs;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.SignalR;

// Microsoft.AspNetCore.Builder;


namespace AlertService.Controllers;

[ApiController]
[Route("api/alerts")]
public class AlertsController : ControllerBase
{
    private readonly AlertsDbContext _db;
    private readonly IHubContext<AlertHub> _hub;

    public AlertsController(AlertsDbContext db, IHubContext<AlertHub> hub)
    {
        _db = db;
        _hub = hub;
    }

    [HttpGet]
    public async Task<IActionResult> GetAlerts() => Ok(await _db.Alerts.OrderByDescending(a => a.CreatedAt).Take(100).ToListAsync());

    [HttpPost("ack/{id}")]
    public async Task<IActionResult> Ack(Guid id)
    {
        var a = await _db.Alerts.FindAsync(id);
        if(a==null) return NotFound();
        a.Acknowledged = true;
        await _db.SaveChangesAsync();
        return Ok();
    }
}
