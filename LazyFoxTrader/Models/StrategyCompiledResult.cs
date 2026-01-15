namespace LazyFoxTrader.Models;

public class StrategyCompileResult
{
    public bool Success { get; set; }
    public List<string> Errors { get; set; } = new();
}
