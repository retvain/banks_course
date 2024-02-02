namespace banks_course.Entities.Currency;

public class Eur(DateTime date) : BaseCurrency(date)
{
    protected override string ExchangeRateBaseLink => Settings.EurExchangeRateBaseLink;
}