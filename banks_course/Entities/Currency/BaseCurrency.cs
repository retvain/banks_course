using banks_course.DTOs.Common;
using banks_course.Entities.Contracts;

namespace banks_course.Entities.Currency;

public abstract class BaseCurrency : ICurrency
{
    protected abstract string ExchangeRateBaseLink { get; }

    private readonly string _exchangeRateLink;

    private readonly DateTime _date;
    
    private Dictionary<string, double> _exchangeRates;

    protected BaseCurrency(DateTime date)
    {
        _date = date;
        _exchangeRateLink = ExchangeRateBaseLink + date.ToString("yyyy-MM-dd");
    }

    public string GetExchangeRateSourceUrl()
    {
        return _exchangeRateLink;
    }

    public DateTime GetDate()
    {
        return _date;
    }

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