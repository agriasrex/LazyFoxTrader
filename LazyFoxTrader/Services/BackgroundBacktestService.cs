using LazyFoxTrader.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace LazyFoxTrader.Services;

public class BackgroundBacktestService
{
    private readonly BacktestEngine _engine;
    private readonly IHubContext<BacktestHub> _hub;

    public BackgroundBacktestService(
        BacktestEngine engine,
        IHubContext<BacktestHub> hub)
    {
        _engine = engine;
        _hub = hub;
    }

    public Guid Start(string name, decimal capital, string code)
    {
        var id = Guid.NewGuid();

        Task.Run(async () =>
        {
            await Task.Delay(3000);
            await _hub.Clients.All.SendAsync("BacktestCompleted", id);
        });

        return id;
    }
}
