using System.Diagnostics;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using GameStore.Models;

namespace GameStore.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly TelemetryClient _telemetryClient;

    public HomeController(ILogger<HomeController> logger, TelemetryClient telemetryClient)
    {
        _logger = logger;
        _telemetryClient = telemetryClient;
    }

    public IActionResult Index()
    {
        _telemetryClient.TrackEvent("HomeIndexVisited");
        return View();
    }

    public IActionResult Contact()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
