// See https://aka.ms/new-console-template for more information

using Microsoft.EntityFrameworkCore;
using UserService;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<UsersDbContext>(opt => opt.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
// builder.Services.AddSignalR();
builder.Services.AddControllers();
var app = builder.Build();
app.MapControllers();
// app.MapHub<AlertHub>("/hubs/alerts");
app.Run();