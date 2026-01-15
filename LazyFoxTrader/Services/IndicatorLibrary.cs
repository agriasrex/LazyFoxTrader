using LazyFoxTrader.Models;

namespace LazyFoxTrader.Services;

public class IndicatorLibrary
{
    public decimal SMA(IEnumerable<Trade> bars, int period)
        => bars.TakeLast(period).Average(b => b.Close);

    public decimal EMA(IEnumerable<Trade> bars, int period)
    {
        var k = 2m / (period + 1);
        decimal ema = bars.First().Close;

        foreach (var b in bars.Skip(1))
            ema = (b.Close - ema) * k + ema;

        return ema;
    }

    public decimal RSI(IEnumerable<Trade> bars, int period = 14)
    {
        var diffs = bars.Zip(bars.Skip(1),
            (a, b) => b.Close - a.Close).TakeLast(period);

        var gain = diffs.Where(d => d > 0).Sum();
        var loss = diffs.Where(d => d < 0).Sum(d => -d);

        if (loss == 0) return 100;
        return 100 - (100 / (1 + gain / loss));
    }
}
