using LazyFoxTrader.Services;
using LazyFoxTrader.Hubs;

var builder = WebApplication.CreateBuilder(args);

// MVC
builder.Services.AddControllersWithViews();

// SignalR
builder.Services.AddSignalR();

// App services
builder.Services.AddSingleton<ClickHouseService>();
builder.Services.AddSingleton<AlpacaService>();
builder.Services.AddSingleton<IndicatorLibrary>();
builder.Services.AddSingleton<StrategyCompiler>();
builder.Services.AddSingleton<BacktestEngine>();
builder.Services.AddSingleton<BackgroundBacktestService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();
app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapHub<BacktestHub>("/backtestHub");

app.Run();
