namespace banks_course.Entities.Currency;

public class Eur : BaseCurrency
{
    public Eur(DateTime date) : base(date)
    {
    }

    protected override string ExchangeRateBaseLink => Settings.EurExchangeRateBaseLink;
}