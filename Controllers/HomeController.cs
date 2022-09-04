using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Vericekme.Models;
using System.Net;
using System.IO;
using System.Text.Json;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Vericekme.Controllers
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
            var url = "https://api.";

            var httpRequest = (HttpWebRequest)WebRequest.Create(url);

            httpRequest.Headers["authority"] = "api.";
            httpRequest.Headers["accept"] = "application/json, text/plain, */*";
            httpRequest.Headers["authorization"] = "Token c";
            httpRequest.Headers["user-agent"] = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/99.0.4844.51 Safari/537.36 Edg/99.0.1150.39";


            var httpResponse = (HttpWebResponse)httpRequest.GetResponse();

           StreamReader reader = new StreamReader(httpResponse.GetResponseStream());

            var text= reader.ReadToEnd();
            var myjson = QuickType.Welcome.FromJson(text);
          //  ViewData["welcome"] =myjson;
 
            return View(myjson.Results);
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
