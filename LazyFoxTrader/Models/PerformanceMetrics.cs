namespace LazyFoxTrader.Models;

public class PerformanceMetrics
{
    public decimal NetProfit { get; set; }
    public decimal MaxDrawdown { get; set; }
    public decimal WinRate { get; set; }
    public decimal SharpeRatio { get; set; }
    public int TotalTrades { get; set; }
}
