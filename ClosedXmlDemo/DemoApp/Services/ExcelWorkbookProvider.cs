using System.IO;
using ClosedXML.Excel;
using System;
using Microsoft.AspNetCore.Hosting;
using Models.Core;

namespace DemoApp.Services
{
    public class ExcelWorkbookProvider : IXLWorkbookProvider
    {
        private readonly IHostingEnvironment _hostingEnvironment;

        public ExcelWorkbookProvider(IHostingEnvironment hostingEnvironment)
        {
            _hostingEnvironment = hostingEnvironment;
        }
        public IFileHolder<XLWorkbook> GetFile(string fileName)
        {
            // получаем сохраненный файл
            string xsltPath = Path.Combine(_hostingEnvironment.WebRootPath + @"~/wwwroot" + fileName);
            // начало использования библиотеке ClosedXML
            var workbook = new XLWorkbook(xsltPath);
            var worksheet = workbook.Worksheet(1);

            var model = new FileHolder<XLWorkbook>(fileName, workbook);



            return model;
        }

        public void SaveFile(IFileHolder<XLWorkbook> fileHolder, string newFileName)
        {
            throw new NotImplementedException();
        }
    }
}
