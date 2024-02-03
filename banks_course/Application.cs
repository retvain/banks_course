using System.Globalization;
using banks_course.Entities.Contracts;
using banks_course.Entities.Currency.Factories;
using banks_course.Processors.CurrencyFileSystemProcessors;
using banks_course.Processors.CurrencyParserProcessors;
using Microsoft.Extensions.Configuration;

namespace banks_course;

public class Application
{
    public void Run()
    {
        IConfigurationRoot config = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();
        
        IConfigurationSection settings = config.GetRequiredSection("ExchangeRateSettings");
        var v = settings.GetSection("RubExchangeRateBaseLink").Value;

        try
        {
            var date = GetDate();
            var currencies = InitCurrencyEntity();

            Parse(currencies, date);
            Save(currencies, date);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    private List<ICurrency> InitCurrencyEntity()
    {
        return CurrencyFactory.CreateAllCurrencies();
    }

    private void Parse(List<ICurrency> currencies, DateTime date)
    {
        var parser = new CurrencyParserProcessor();
        parser.Parse(currencies, date);
    }

    private void Save(List<ICurrency> currencies, DateTime date)
    {
        var currencySaver = new CurrencyFileSaveProcessor();
        foreach (var currency in currencies)
        {
            currencySaver.SaveCurrencyToExcel(currency, date);
        }
    }

    private DateTime GetDate()
    {
        DateTime date;
        bool isValidDate;

        do
        {
            Console.Write("Insert date in YYYY-MM-DD format: \n");
            string? inputDate = Console.ReadLine();

            isValidDate = DateTime.TryParseExact(inputDate, "yyyy-MM-dd", null, DateTimeStyles.None, out date);

            if (!isValidDate)
            {
                Console.WriteLine("Wrong format. Please, insert date in YYYY-MM-DD format: ");
            }
        } while (!isValidDate);

        return date;
    }
}