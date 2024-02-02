namespace banks_course.Entities.Currency;

public class Rub(DateTime date) : BaseCurrency(date)
{
    protected override string ExchangeRateBaseLink => Settings.RubExchangeRateBaseLink;
}