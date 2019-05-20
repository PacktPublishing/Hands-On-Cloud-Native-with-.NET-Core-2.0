using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.ApplicationInsights;
using Microsoft.ApplicationInsights.DataContracts;
using Microsoft.AspNetCore.Mvc;
using MonitoringLogging.AspnetCore.Models;

namespace MonitoringLogging.AspnetCore.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            new TelemetryClient().TrackRequest(new RequestTelemetry
            {
                // Add metrics here
            });
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
