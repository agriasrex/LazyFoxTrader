using LazyFoxTrader.Services;
using Microsoft.AspNetCore.Mvc;

namespace LazyFoxTrader.Controllers;

public class DataController : Controller
{
    private readonly AlpacaService _alpaca;

    public DataController(AlpacaService alpaca)
    {
        _alpaca = alpaca;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Load(string timeframe, int limit)
    {
        await _alpaca.LoadSymbolsAndTradesAsync(timeframe, limit);
        return Ok();
    }
}
