using GameStore.Models;
using GameStore.Services;
using Microsoft.ApplicationInsights;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GameStore.Controllers
{
  public class GamesController : Controller
  {
    private readonly GameService _gameService;
     private readonly TelemetryClient _telemetryClient;

        public GamesController(GameService gameService, TelemetryClient telemetryClient)
        {
            _gameService = gameService;
            _telemetryClient = telemetryClient;
        }

        // GET: Games
        public IActionResult Index()
    {
      var games = _gameService.GetAllGames();
            _telemetryClient.TrackEvent("GamesIndexVisited");  // Spåra händelsen
            return View(games);  // Rendera listan på en vy
    }
  }
}
