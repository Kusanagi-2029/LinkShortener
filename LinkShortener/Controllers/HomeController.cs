using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(controllerName: "ShortLink", actionName: "Index");
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Страница описания нашего приложения.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            throw new NotImplementedException();
        }
    }
}