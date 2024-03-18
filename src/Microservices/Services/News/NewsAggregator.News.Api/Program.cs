using Asp.Versioning;
using Microsoft.OpenApi.Models;
using NewsAggregator.Infrastructure.Web.Middlewares;
using NewsAggregator.News;
using NewsAggregator.News.Api.OpenApi;
using NewsAggregator.News.ConfigurationOptions;
using NewsAggregator.News.Web.Middlewares;
using Serilog;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

var appSettings = new AppSettings();

builder.Configuration.Bind(appSettings);

builder.Services.AddNewsModule(appSettings);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder => builder.WithOrigins("http://localhost", "http://news-lev4and.ru")
        .AllowAnyMethod().AllowAnyHeader().AllowCredentials());
});

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

var app = builder.Build();

app.MigrateNewsDb();

await app.RefreshNewsSourceMemoryCacheAsync();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    var descriptions = app.DescribeApiVersions();

    foreach (var description in descriptions)
    {
        var url = $"/api/news/swagger/{description.GroupName}/swagger.json";
        var name = description.GroupName.ToUpperInvariant();

        options.SwaggerEndpoint(url, name);
    }
});

app.UseSerilogRequestLogging();

app.UseCors();

app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.UseMiddleware<AutoWrapJsonResponseMiddleware>();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseEndpoints(builder =>
{
    _ = builder.MapAreaControllerRoute("parsingArea", "parsing",
        "api/news/v{apiVersion:apiVersion}/parsing/{controller=Home}/{action=Index}/{id?}");

    _ = builder.MapAreaControllerRoute("searchingArea", "searching",
        "api/news/v{apiVersion:apiVersion}/searching/{controller=Home}/{action=Index}/{id?}");
});

app.Run();
