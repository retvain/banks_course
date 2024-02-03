using banks_course.DTOs.Common;

namespace banks_course.Services.Contracts;

public interface IExchangeRateParser
{
    public BaseDto Parse(DateTime date);
}