using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesStatistics.Logic;

namespace SalesStatistics.Controllers
{
    [Route("api/[controller]")]
    public class UploadController : Controller
    {
        private readonly IFileService _fileService;
        public UploadController(IFileService fileService)
        {
            _fileService = fileService;
        }
        
        [Route("files")]
        public IActionResult UploadFiles(List<IFormFile> files) => Ok(_fileService.UploadFiles(files));

    }
}