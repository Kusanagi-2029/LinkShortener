using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using LinkShortener.Helpers;
using LinkShortener.Models;
using LinkShortener.Services;

namespace LinkShortener.Controllers
{
    public class ShortLinkController : Controller
    {
        private readonly IShortLinkService _service;

        public ShortLinkController(IShortLinkService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            return RedirectToAction(actionName: nameof(Create));
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(string originalUrl)
        {
            var ShortLinks = new ShortLinks
            {
                OriginalUrl = originalUrl
            };

            TryValidateModel(ShortLinks);
            if (ModelState.IsValid)
            {
                _service.Save(ShortLinks);

                return RedirectToAction(actionName: nameof(Show), routeValues: new { id = ShortLinks.Id });
            }

            return View(ShortLinks);
        }

        public IActionResult Show(int? id)
        {
            if (!id.HasValue) 
            {
                return NotFound();
            }

            var ShortLinks = _service.GetById(id.Value);
            if (ShortLinks == null) 
            {
                return NotFound();
            }

            ViewData["Path"] = ShortLinkHelper.Encode(ShortLinks.Id);

            return View(ShortLinks);
        }

        [HttpGet("/ShortLinks/RedirectTo/{path:required}", Name = "ShortLinks_RedirectTo")]
        public IActionResult RedirectTo(string path)
        {
            if (path == null) 
            {
                return NotFound();
            }

            var ShortLinks = _service.GetByPath(path);
            if (ShortLinks == null) 
            {
                return NotFound();
            }

            return Redirect(ShortLinks.OriginalUrl);
        }
    }
}

