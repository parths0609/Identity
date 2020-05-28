using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoginIdentityDemo.Models;
using Microsoft.AspNetCore.Http;

namespace LoginIdentityDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            string dummyvalue = "just to activate my application cookie";
            HttpContext.Session.SetString("dummyvariable", dummyvalue);



            return View();
        }

        public IActionResult Privacy()
        {
            string getSessionValue = HttpContext.Session.GetString("dummyvariable");
            Console.WriteLine("my dummy variable value through session" + getSessionValue);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
