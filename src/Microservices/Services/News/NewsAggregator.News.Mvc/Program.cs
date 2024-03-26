using Microsoft.AspNetCore.HttpOverrides;
using NewsAggregator.News;
using NewsAggregator.News.ConfigurationOptions;
using NewsAggregator.News.Web.Middlewares;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) =>
    loggerConfig.ReadFrom.Configuration(context.Configuration));

var appSettings = new AppSettings();

builder.Configuration.Bind(appSettings);

builder.Services.AddMvcNewsModule(appSettings);

builder.Services.AddControllersWithViews();

builder.Services.AddHttpContextAccessor();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.ForwardedHeaders = ForwardedHeaders.XForwardedFor 
        | ForwardedHeaders.XForwardedProto;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseSerilogRequestLogging();

app.UseStaticFiles();

app.UseForwardedHeaders();

app.UseRouting();

app.UseAuthorization();

app.UseMiddleware<RegisterNewsSiteVisitMiddleware>();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
