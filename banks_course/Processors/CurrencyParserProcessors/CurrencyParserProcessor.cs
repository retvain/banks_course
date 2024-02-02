using banks_course.DTOs.DtoFactories;
using banks_course.Entities.Contracts;
using banks_course.Processors.Contracts;
using banks_course.Services.Contracts;
using banks_course.Services.Parsers.Factories;

namespace banks_course.Processors.CurrencyParserProcessors;

public class CurrencyParserProcessor : ICurrencyParserProcessor
{
    public void Parse(List<ICurrency> currencies)
    {
        foreach (var currency in currencies)
        {
            var parser = ParserFactory.GetParserByEntity(currency);
            var dto = CurrencyDtoFactory.GetDtoByEntity(currency);
            var result = parser.Parse(dto, currency.GetExchangeRateSourceUrl());
            
            Console.Write($"{currency.GetType().Name} is parsed successfully. \n");
            
            // todo build DTO to entity result
        }
    }
}