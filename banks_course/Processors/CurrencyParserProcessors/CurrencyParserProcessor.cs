using banks_course.DTOs.Common;
using banks_course.DTOs.DtoFactories;
using banks_course.Entities.Contracts;
using banks_course.Processors.Contracts;
using banks_course.Services.Parsers.Factories;

namespace banks_course.Processors.CurrencyParserProcessors;

public class CurrencyParserProcessor : ICurrencyParserProcessor
{
    public void Parse(List<ICurrency> currencies, DateTime date)
    {
        foreach (var currency in currencies)
        {
            var parser = ParserFactory.GetParserByEntity(currency);
            var rateDto = CurrencyDtoFactory.GetDtoByEntity(currency);
            parser.Parse(date);

            EnrichEntity(currency, rateDto);
            
            Console.Write($"{currency.GetType().Name} is parsed successfully. \n");
        }
    }

    private void EnrichEntity(ICurrency currency, BaseDto rateDto)
    {
        currency.SetExchangeRates(rateDto);
    }
}