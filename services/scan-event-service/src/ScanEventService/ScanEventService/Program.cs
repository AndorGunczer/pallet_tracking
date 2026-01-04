// See https://aka.ms/new-console-template for more information

using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using ScanEventService.Applications;
using ScanEventService.Applications.Workflows;
using ScanEventService.Data;
using ScanEventService.Infrastructure;
using ScanEventService.Infrastructure.Kafka;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Konfiguration
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));
builder.Services.AddScoped<IScanProcessorResolver, ScanProcessorResolver>();
builder.Services.AddScoped<ScanWorkflow>();
builder.Services.AddScoped<IScanProcessor, InfeedProcessor>();
builder.Services.AddScoped<IScanProcessor, OutfeedProcessor>();
builder.Services.AddScoped<IPalletInfeedService, PalletInfeedService>();
builder.Services.AddScoped<IPalletOutfeedService, PalletOutfeedService>();
builder.Services.AddSingleton<IKafkaProducer, KafkaProducer>(); // implementiere
// builder.Services.AddStackExchangeRedisCache(options =>
// {
//     options.Configuration = builder.Configuration["Redis:Connection"];
// });

var app = builder.Build();
app.MapControllers();
app.Run();
