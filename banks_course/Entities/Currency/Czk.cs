namespace banks_course.Entities.Currency;

public class Czk : BaseCurrency
{
    public Czk(DateTime date) : base(date)
    {
    }
    
    protected override string ExchangeRateBaseLink => Settings.CzkExchangeRateBaseLink;
}