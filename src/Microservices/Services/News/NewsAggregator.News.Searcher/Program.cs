using NewsAggregator.News;
using NewsAggregator.News.ConfigurationOptions;
using Serilog;

var builder = Host.CreateApplicationBuilder(args);

builder.Services.AddSerilog(loggerConfig =>
    loggerConfig.ReadFrom.Configuration(builder.Configuration));

var appSettings = new AppSettings();

builder.Configuration.Bind(appSettings);

builder.Services.AddSearcherNewsModule(appSettings);

var host = builder.Build();

host.Run();
