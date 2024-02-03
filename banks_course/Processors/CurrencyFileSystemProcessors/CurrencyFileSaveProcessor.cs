using System.Reflection;
using banks_course.Entities.Contracts;
using banks_course.Processors.Contracts;
using OfficeOpenXml;

namespace banks_course.Processors.CurrencyFileSystemProcessors;

public class CurrencyFileSaveProcessor : ICurrencyFileSaveProcessor
{
    public void SaveCurrencyToExcel(ICurrency currency, DateTime date)
    {
        ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        
        using var package = new ExcelPackage();
        
        var worksheet = package.Workbook.Worksheets.Add("ExchangeRates");
        var row = 2;
        var stringDate = date.ToString("yyyy-MM-dd");
        var currencyName = currency.GetType().Name;

        worksheet.Cells[1, 1].Value = "Currency";
        worksheet.Cells[1, 2].Value = "Exchange Rate";
        worksheet.Cells[1, 3].Value = "Date";

        foreach (var exchangeRate in currency.GetExchangeRates())
        {
            worksheet.Cells[row, 1].Value = exchangeRate.Key;
            worksheet.Cells[row, 2].Value = exchangeRate.Value;
            worksheet.Cells[row, 3].Value = stringDate;

            row++;
        }

        var rootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
        var filePath = Path.Combine(rootPath, "..", "..", "..", Settings.GetSection("RelativeStoragePath").Value, $"{currencyName}_{stringDate}.xlsx"); // todo this is shit
        package.SaveAs(new FileInfo(filePath));

        Console.WriteLine($"{currencyName} has been saved to {filePath}");
    }
}