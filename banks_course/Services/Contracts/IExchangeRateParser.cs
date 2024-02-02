using banks_course.DTOs.Common;

namespace banks_course.Services.Contracts;

public interface IExchangeRateParser
{
    public void Parse<T>(T dto, string url) where T : BaseDto;
}