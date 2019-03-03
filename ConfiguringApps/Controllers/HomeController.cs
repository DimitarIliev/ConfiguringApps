using ConfiguringApps.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ConfiguringApps.Controllers
{
    public class HomeController: Controller
    {
        private UptimeService _uptime;

        public HomeController(UptimeService uptime)
        {
            _uptime = uptime;
        }

        public ViewResult Index() 
            => View(new Dictionary<string, string>
            {
                ["Message"] = "This is the index action",
                ["Uptime"] = $"{_uptime.Uptime}ms"
            });
    }
}
