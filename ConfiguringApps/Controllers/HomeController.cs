using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Controllers
{
    public class HomeController: Controller
    {
        private UptimeService _uptime;
        private ILogger<HomeController> logger;

        public HomeController(UptimeService uptime, ILogger<HomeController> log)
        {
            _uptime = uptime;
            logger = log;
        }

        public ViewResult Index(bool throwException = false)
        {
            if (throwException)
                throw new System.NullReferenceException();

            logger.LogDebug($"Handled {Request.Path} at uptime {_uptime.Uptime}");

            return View(new Dictionary<string, string>
            {
                ["Message"] = "This is the index action",
                ["Uptime"] = $"{_uptime.Uptime}ms"
            });
        }

        public ViewResult Error()
        {
            return View("Index", new Dictionary<string, string>
            {
                ["Message"] = "This is the Error action"
            });
        }
            
    }
}
