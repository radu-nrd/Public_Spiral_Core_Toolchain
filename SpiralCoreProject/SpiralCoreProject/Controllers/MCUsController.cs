using Microsoft.AspNetCore.Mvc;
using SpiralCoreProject.Models;
using SpiralCoreProject.Utils;

namespace SpiralCoreProject.Controllers
{
    public class MCUsController : Controller
    {
        public IActionResult Index()
        {
            var data = ApiFetcher.FetchMCUs().Result;
            return View(data);
        }

        public IActionResult FetchData(string category,int page = 1)
        {
            this.ViewData["Title"] = category;
            var data = ApiFetcher.FetchGenericByCategory(category).Result;

            var pagedData = data!.Skip((page - 1) * 50).Take(50);
            ViewBag.CurrentPage = page;
            ViewBag.TotalPages = (int)Math.Ceiling((double)data!.Count() / 50);
            return View("__genericView", pagedData);
        }
    }
}
