using NewsAggregator.Infrastructure.Web.Middlewares;
using NewsAggregator.News;
using NewsAggregator.News.ConfigurationOptions;
using NewsAggregator.News.Web.Middlewares;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var appSettings = new AppSettings();

builder.Configuration.Bind(appSettings);

builder.Services.AddNewsModule(appSettings);

builder.Services.AddControllers().AddJsonOptions(options => 
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen();
builder.Services.AddSwaggerGenNewtonsoftSupport();

var app = builder.Build();

app.MigrateNewsDb();

await app.RefreshNewsSourceMemoryCacheAsync();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthorization();
app.MapControllers();

app.UseMiddleware<AutoWrapJsonResponseMiddleware>();
app.UseMiddleware<GlobalExceptionHandlerMiddleware>();

app.UseEndpoints(builder =>
{
    _ = builder.MapAreaControllerRoute("parsingArea", "parsing",
        "api/news/parsing/{controller=Home}/{action=Index}/{id?}");

    _ = builder.MapAreaControllerRoute("searchingArea", "searching",
        "api/news/searching/{controller=Home}/{action=Index}/{id?}");
});

app.Run();
