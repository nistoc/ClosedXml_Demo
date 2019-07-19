using DemoApp.Models;
using DemoApp.Services;
using Microsoft.AspNetCore.Mvc;
using Models.Core;
using Newtonsoft.Json;
using System.Diagnostics;
using System.Linq;

namespace DemoApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IXLWorkbookProvider _xLWorkbookProvider;

        public HomeController(IXLWorkbookProvider xLWorkbookProvider)
        {
            _xLWorkbookProvider = xLWorkbookProvider;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Excel()
        {
            var fileData = _xLWorkbookProvider.GetFile("Demo01.xlsx");
            _xLWorkbookProvider.SaveFile(fileData, "newData.xlsx");
            return Content(JsonConvert.SerializeObject(fileData.FileRowList));
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
