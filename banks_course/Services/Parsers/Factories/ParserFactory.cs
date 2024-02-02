using banks_course.Entities.Contracts;
using banks_course.Entities.Currency;
using banks_course.Exceptions;
using banks_course.Services.Contracts;

namespace banks_course.Services.Parsers.Factories;

public static class ParserFactory
{
    public static IExchangeRateParser GetParserByEntity(ICurrency currencyEntity)
    {
        return currencyEntity switch
        {
            Rub => new RubExchangeRateParser(),
            Czk => new CzkExchangeRateParser(),
            Eur => new EurExchangeRateParser(),
            _ => throw FactoryException.BecauseParserNotFound(currencyEntity)
        };
    }
}