using Microsoft.AspNetCore.Mvc;

namespace LazyFoxTrader.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
