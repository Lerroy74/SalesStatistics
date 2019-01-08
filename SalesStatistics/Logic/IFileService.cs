using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using SalesStatistics.Domain.Common.ViewModels;

namespace SalesStatistics.Logic
{
    public interface IFileService
    {
        Task<string> UploadFiles(List<IFormFile> files);
        IEnumerable<SalesDataBySallerViewModel> GetSallesDataFromExcel();
    }
}