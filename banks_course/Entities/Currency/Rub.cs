namespace banks_course.Entities.Currency;

public class Rub : BaseCurrency
{
    public Rub(DateTime date) : base(date)
    {
    }

    protected override string ExchangeRateBaseLink => Settings.RubExchangeRateBaseLink;
}