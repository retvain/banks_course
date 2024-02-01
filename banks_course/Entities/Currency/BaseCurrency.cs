namespace banks_course.Entities.Currency;

public abstract class BaseCurrency
{
    protected abstract string ExchangeRateBaseLink { get; }

    private string _exchangeRateLink;

    protected BaseCurrency(DateTime date)
    {
        _exchangeRateLink = ExchangeRateBaseLink + date.ToString("yyyy-MM-dd");
    }
}