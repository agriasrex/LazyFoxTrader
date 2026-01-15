namespace LazyFoxTrader.Models;

public class BacktestTrade
{
    public Guid BacktestId { get; set; }

    public DateTime Timestamp { get; set; }
    public string Symbol { get; set; } = string.Empty;

    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public string Side { get; set; } = string.Empty; // BUY / SELL
}
