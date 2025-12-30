// See https://aka.ms/new-console-template for more information

var builder = Host.CreateDefaultBuilder(args)
    .ConfigureServices((hostContext, services) =>
    {
        services.AddHostedService<RouteAnalysisWorker>();
        services.AddDbContext<AppDbContext>(options =>
            options.UseNpgsql(hostContext.Configuration.GetConnectionString("Main")));
        services.AddSingleton<IKafkaConsumer, KafkaConsumer>(); // implementiere
        services.AddSingleton<IAlertPublisher, KafkaAlertPublisher>(); // publisht alerts to topic or call alert-service
    }).UseConsoleLifetime();

var host = builder.Build();
await host.RunAsync();
