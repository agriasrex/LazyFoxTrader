namespace LazyFoxTrader.Models;

public class Backtest
{
    public Guid Id { get; set; } = Guid.NewGuid();

    public string Name { get; set; } = string.Empty;
    public decimal StartingCapital { get; set; }

    public decimal NetProfit { get; set; }
    public decimal MaxDrawdown { get; set; }

    public DateTime Started { get; set; }
    public DateTime Completed { get; set; }

    public string StrategyCode { get; set; } = string.Empty;
}
