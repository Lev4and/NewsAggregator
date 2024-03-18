using Asp.Versioning;
using Microsoft.OpenApi.Models;
using NewsAggregator.Gateways.Api.OpenApi;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost", "http://news-lev4and.ru")
        .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
});

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

builder.Services.AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var descriptions = app.DescribeApiVersions();

    foreach (var description in descriptions)
    {
        var url = $"/api/gateways/swagger/{description.GroupName}/swagger.json";
        var name = description.GroupName.ToUpperInvariant();

        options.SwaggerEndpoint(url, name);
    }
});

app.UseSerilogRequestLogging();

app.UseCors();

app.MapReverseProxy();

app.Run();
