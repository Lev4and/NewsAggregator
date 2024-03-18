using Asp.Versioning;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.OpenApi.Models;
using NewsAggregator.Notification;
using NewsAggregator.Notification.Api.OpenApi;
using NewsAggregator.Notification.ConfigurationOptions;
using NewsAggregator.Notification.Web.Hubs;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

var appSettings = new AppSettings();

builder.Configuration.Bind(appSettings);

builder.Services.AddNotificationModule(appSettings);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost", "http://news-lev4and.ru")
        .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
});


builder.Services.AddSignalR();
builder.Services.AddControllers().AddJsonOptions(options =>
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddServer(new OpenApiServer()
    {
        Url = "http://localhost/"
    });

    options.AddServer(new OpenApiServer()
    {
        Url = "http://news-lev4and.ru/"
    });
});
builder.Services.AddSwaggerGenNewtonsoftSupport();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1);
    options.ApiVersionReader = new UrlSegmentApiVersionReader();
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'V";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.ConfigureOptions<ConfigureSwaggerGenOptions>();

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor
        | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var descriptions = app.DescribeApiVersions();

    foreach (var description in descriptions)
    {
        var url = $"/api/notification/swagger/{description.GroupName}/swagger.json";
        var name = description.GroupName.ToUpperInvariant();

        options.SwaggerEndpoint(url, name);
    }
});

app.UseSerilogRequestLogging();

app.UseForwardedHeaders();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.MapHub<NewsNotificationHub>("/api/notification/news");

app.Run();
