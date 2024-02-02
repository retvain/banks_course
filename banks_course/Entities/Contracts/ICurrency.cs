namespace banks_course.Entities.Contracts;

public interface ICurrency
{
    public string GetExchangeRateSourceUrl();
    public DateTime GetDate();
}