using banks_course.DTOs.Common;
using banks_course.Services.Contracts;

namespace banks_course.Services.Parsers;

public class CzkExchangeRateParser : IExchangeRateParser
{
    public T Parse<T>(T dto, string url) where T : BaseDto
    {
        return dto;
    }
}