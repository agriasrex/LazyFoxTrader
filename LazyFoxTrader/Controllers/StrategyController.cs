using LazyFoxTrader.Services;
using Microsoft.AspNetCore.Mvc;

namespace LazyFoxTrader.Controllers;

public class StrategyController : Controller
{
    private readonly StrategyCompiler _compiler;

    public StrategyController(StrategyCompiler compiler)
    {
        _compiler = compiler;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Compile(string code)
    {
        var result = _compiler.Compile(code);
        return Json(result);
    }
}
