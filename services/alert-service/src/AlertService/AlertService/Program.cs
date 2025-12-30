// See https://aka.ms/new-console-template for more information

using AlertService;
using AlertService.Hubs;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AlertsDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddSignalR();
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
app.MapHub<AlertHub>("/hubs/alerts");
app.Run();
