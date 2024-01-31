using NewsAggregator.News;
using NewsAggregator.News.ConfigurationOptions;

var builder = Host.CreateApplicationBuilder(args);

var appSettings = new AppSettings();

builder.Configuration.Bind(appSettings);

builder.Services.AddSearcherNewsModule(appSettings);

var host = builder.Build();

host.MigrateNewsDb();

host.Run();
