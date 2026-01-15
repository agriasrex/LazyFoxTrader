using LazyFoxTrader.Models;

namespace LazyFoxTrader.Services;

public class OptimizationAdvisor
{
    public IEnumerable<string> Suggest(PerformanceMetrics metrics)
    {
        if (metrics.WinRate < 0.5m)
            yield return "Consider tightening your entry conditions.";

        if (metrics.MaxDrawdown > 0.2m)
            yield return "Add a stop-loss or reduce position sizing.";

        if (metrics.SharpeRatio < 1)
            yield return "Reduce volatility exposure.";
    }
}
