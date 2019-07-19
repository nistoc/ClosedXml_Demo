using System.IO;
using ClosedXML.Excel;
using System;
using Microsoft.AspNetCore.Hosting;
using Models.Core;

namespace DemoAppCore3beta.Services
{
    public class ExcelWorkbookProvider : IXLWorkbookProvider
    {
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ExcelWorkbookProvider(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        public IFileHolder<XLWorkbook> GetFile(string fileName)
        {
            // получаем сохраненный файл
            var xsltPath = Path.Combine(_webHostEnvironment.ContentRootPath + @"~/App_Data" + fileName);
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
