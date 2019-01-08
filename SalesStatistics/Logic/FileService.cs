using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;
using SalesStatistics.Domain.Common.ViewModels;

namespace SalesStatistics.Logic
{
    public class FileService : IFileService
    {
        public async Task<string> UploadFiles(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var filePath = Path.GetTempPath();

            foreach (var formFile in files)
            {
                if (!formFile.FileName.Split(".").Last().Equals("xlsm"))
                    return new {Error = "Incorrect format"}.ToString();

                if (formFile.Length > 0)
                {
                    using (var stream = new FileStream(filePath + $"\\\\{formFile.FileName}", FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            return new {count = files.Count, size, filePath}.ToString();
        }

        public IEnumerable<SalesDataBySallerViewModel> GetSallesDataFromExcel()
        {
            var models = new List<SalesDataBySallerViewModel>();
            var filePath = Path.GetTempPath();
            FileInfo file = new FileInfo(filePath + $"\\\\Ежедневник Январь.xlsm");

            using (ExcelPackage package = new ExcelPackage(file))
            {
                if (package.Workbook.Worksheets.Count == 0)
                    return models;

                ExcelWorksheet worksheet = package.Workbook.Worksheets[2];
                var ammountCell = 52;
                for (int i = 14; i < 22; i++)
                {
                    var name = worksheet.Cells[$"B{i}"].Value;
                    var plan = Math.Round((double)worksheet.Cells[$"c{i}"].Value, 2);
                    var ammount = Math.Round((double)worksheet.Cells[$"c{ammountCell}"].Value, 2);
                    models.Add(new SalesDataBySallerViewModel()
                    {
                        Seller = name.ToString(),
                        Plan = plan,
                        Ammount = ammount,
                        Percentage = Math.Round(ammount / (plan / 100), 1)
                    });
                    ammountCell++;
                }
            }

            return models;
        }
    }
}
