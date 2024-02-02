using banks_course.Entities.Contracts;
using banks_course.Entities.Currency.Factories;
using banks_course.Exceptions;
using banks_course.Processors.CurrencyParserProcessors;
using banks_course.Services.Validators;

namespace banks_course;

public class Application
{
    public void Run()
    {
        try
        {
            var date = GetData();
            var currencies = InitCurrencyEntity(date: date);

            Parse(currencies);
            Save(currencies);
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            throw;
        }
    }

    private List<ICurrency> InitCurrencyEntity(DateTime date)
    {
        return CurrencyFactory.CreateAllCurrencies(date);
    }

    private void Parse(List<ICurrency> currencies)
    {
        var parser = new CurrencyParserProcessor();
        parser.Parse(currencies);
    }

    private void Save(List<ICurrency> currencies)
    {
        // todo implement
    }

    private DateTime GetData()
    {
        var validator = new DateValidator();

        string? inputDate;
        Console.Write("Insert date in YYYY-MM-DD format: \n");
        do
        {
            inputDate = Console.ReadLine();

            try
            {
                validator.Validate(inputDate);
                break;
            }
            catch (ValidateException e)
            {
                Console.WriteLine(e.Message);
            }
        } while (true);

        DateTime.TryParseExact(inputDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None,
            out DateTime result);

        return result;
    }
}