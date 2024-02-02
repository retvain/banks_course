using banks_course.Entities.Contracts;

namespace banks_course.Exceptions;

public class FactoryException(string message) : Exception(message)
{
    public static FactoryException BecauseParserNotFound(ICurrency currencyEntity)
    {
        var errorMessage = $"Parser for entity ({currencyEntity}) not found.";
        return new FactoryException(errorMessage);
    }
    
    public static FactoryException BecauseDtoNotFound(ICurrency currencyEntity)
    {
        var errorMessage = $"Dto for entity ({currencyEntity}) not found.";
        return new FactoryException(errorMessage);
    }
}