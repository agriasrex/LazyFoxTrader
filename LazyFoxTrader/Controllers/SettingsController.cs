using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace LazyFoxTrader.Controllers;

public class SettingsController : Controller
{
    private readonly IConfiguration _config;

    public SettingsController(IConfiguration config)
    {
        _config = config;
    }

    public IActionResult Index()
    {
        return View(_config);
    }
}
