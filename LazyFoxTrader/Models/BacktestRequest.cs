namespace LazyFoxTrader.Models;

public class BacktestRequest
{
    public string Name { get; set; } = string.Empty;
    public decimal StartingCapital { get; set; }
    public string StrategyCode { get; set; } = string.Empty;
}
