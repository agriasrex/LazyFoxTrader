namespace LazyFoxTrader.Models;

public class Trade
{
    public DateTime Timestamp { get; set; }

    public decimal Open { get; set; }
    public decimal High { get; set; }
    public decimal Low { get; set; }
    public decimal Close { get; set; }

    public long Volume { get; set; }
    public long TradeCount { get; set; }
    public decimal VolumeWeightedPrice { get; set; }
}
