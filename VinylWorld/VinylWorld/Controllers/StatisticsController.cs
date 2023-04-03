using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VinylWorld.Abstractions;
using VinylWorld.Models.Statistics;

namespace VinylWorld.Controllers
{
    [Authorize(Roles = "Administrator")]
    public class StatisticsController : Controller
    {
        private readonly IStatisticsService statisticsService;

        public StatisticsController(IStatisticsService statisticsService)
        {
            this.statisticsService = statisticsService;
        }
        public IActionResult Index()
        {
            StatisticsVM statistics = new StatisticsVM();

            statistics.CountClients = statisticsService.CountClients();
            statistics.CountAlbums = statisticsService.CountAlbums();
            statistics.CountOrders = statisticsService.CountOrders();
            statistics.SumOrders = statisticsService.SumOrders();

            return View(statistics);
        }
    }
}
