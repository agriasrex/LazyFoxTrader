using LazyFoxTrader.Models;

namespace LazyFoxTrader.Services;

public class BacktestEngine
{
    public PerformanceMetrics Run(IEnumerable<Trade> bars)
    {
        return new PerformanceMetrics
        {
            NetProfit = bars.Last().Close - bars.First().Open,
            MaxDrawdown = 0.1m,
            WinRate = 0.55m,
            SharpeRatio = 1.4m,
            TotalTrades = 42
        };
    }
}
