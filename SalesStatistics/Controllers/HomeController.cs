using Microsoft.AspNetCore.Mvc;
using SalesStatistics.Logic;

namespace SalesStatistics.Controllers
{
    public class HomeController : Controller
    {
        private readonly IFileService _fileService;
        public HomeController(IFileService fileService)
        {
            _fileService = fileService;
        }

        public IActionResult Index()
        {
            return View(_fileService.GetSallesDataFromExcel());
        }
        
        public IActionResult Upload()
        {
            return View();
        }
    }
}
