using NewsAggregator.Notification;
using NewsAggregator.Notification.ConfigurationOptions;
using NewsAggregator.Notification.Web.Hubs;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

var appSettings = new AppSettings();

builder.Configuration.Bind(appSettings);

builder.Services.AddNotificationModule(appSettings);

builder.Services.AddSignalR();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.MapHub<NewsNotificationHub>("api/notification/news");

app.Run();
