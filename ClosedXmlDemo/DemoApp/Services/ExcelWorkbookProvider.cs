using System.IO;
using ClosedXML.Excel;
using System;
using Microsoft.AspNetCore.Hosting;
using Models.Core;
using System.Linq;

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
            string xsltPath = Path.Combine(_hostingEnvironment.WebRootPath, "excel", fileName);
            // начало использования библиотеке ClosedXML
            var workbook = new XLWorkbook(xsltPath);
            var worksheet = workbook.Worksheet(1);

            var model = new FileHolder<XLWorkbook>(fileName, workbook);

            var capacity = worksheet.FirstColumnUsed().LastCellUsed().Address.RowNumber;

            capacity--;

            foreach (var column in worksheet.ColumnsUsed())
            {
                var rowItem = new RowItem(capacity);

                foreach (var usedCell in column.CellsUsed().Where(c => c.Address.RowNumber > 1))
                {
                    rowItem.SetValue(usedCell.Address.RowNumber - 2, usedCell.Value.ToString());
                }

                model.FileRowList.AddRow(rowItem);
            }


            return model;
        }

        public void SaveFile(IFileHolder<XLWorkbook> fileHolder, string newFileName)
        {
            var wb = new XLWorkbook();
            var ws = wb.Worksheets.Add("Contacts");

            var rowNum = 1;
            foreach (var row in fileHolder.FileRowList.DataInFile)
            {
                var colNum = 1;
                foreach (var column in row.Columns)
                {
                    ws.Cell(rowNum, colNum).Value = column.Value;

                    ////
                    colNum++;
                }
                rowNum++;
            }

            ws.Columns().AdjustToContents(); //ширина столбца по содержимому

            // вернем пользователю файл без сохранения его на сервере
            string xsltPath = Path.Combine(_hostingEnvironment.WebRootPath, "excel", newFileName);
            wb.SaveAs(xsltPath);

        }
    }
}
