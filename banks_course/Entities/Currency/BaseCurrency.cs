using banks_course.DTOs.Common;
using banks_course.Entities.Contracts;

namespace banks_course.Entities.Currency;

public abstract class BaseCurrency : ICurrency
{
    private Dictionary<string, double> _exchangeRates;

    public void SetExchangeRates(BaseDto dto)
    {
        _exchangeRates = new Dictionary<string, double>();
        foreach (var rate in dto.ExchangeRates)
        {
            _exchangeRates.Add(rate.Key, rate.Value);
        }
    }

    public Dictionary<string, double> GetExchangeRates()
    {
        return _exchangeRates;
    }
    
}