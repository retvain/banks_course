namespace banks_course.DTOs.Common;

public abstract class BaseDto
{
    public string Base { get; set; }
    public DateTime Date { get; set; }
    
    public Dictionary<string, double> ExchangeRates { get; set; } = new();
}