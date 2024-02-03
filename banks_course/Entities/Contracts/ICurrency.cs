using banks_course.DTOs.Common;

namespace banks_course.Entities.Contracts;

public interface ICurrency
{
    public void SetExchangeRates(BaseDto dto);
    public Dictionary<string, double> GetExchangeRates();
}