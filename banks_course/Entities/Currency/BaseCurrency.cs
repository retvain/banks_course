using banks_course.Entities.Contracts;

namespace banks_course.Entities.Currency;

public abstract class BaseCurrency : ICurrency
{
    protected abstract string ExchangeRateBaseLink { get; }

    private readonly string _exchangeRateLink;

    private readonly DateTime _date;

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
}