using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace BookManage.Controllers
{
    public class HomeController : Controller
    {
        public IOptions<AppSettings> AppSettings { get; set; }

        public HomeController(IOptions<AppSettings> appSettings)
        {
            this.AppSettings = appSettings;
        }

        public IActionResult Index()
        {
            ViewBag.ReleaseNo = AppSettings.Value.ReleaseNo;

            return View();
        }
    }
}
