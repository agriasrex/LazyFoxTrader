using LazyFoxTrader.Services;
using Microsoft.AspNetCore.Mvc;

namespace LazyFoxTrader.Controllers;

public class BacktestController : Controller
{
    private readonly BackgroundBacktestService _background;

    public BacktestController(BackgroundBacktestService background)
    {
        _background = background;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Run(string name, decimal capital, string strategyCode)
    {
        var id = _background.Start(name, capital, strategyCode);
        return Json(new { backtestId = id });
    }
}
