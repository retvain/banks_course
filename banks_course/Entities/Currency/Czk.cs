using banks_course.Entities.Contracts;

namespace banks_course.Entities.Currency;

public class Czk(DateTime date) : BaseCurrency(date)
{
    protected override string ExchangeRateBaseLink => Settings.CzkExchangeRateBaseLink;
}