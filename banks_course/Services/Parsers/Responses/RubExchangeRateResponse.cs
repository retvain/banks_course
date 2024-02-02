namespace banks_course.Services.Parsers.Responses;

public class RubExchangeRateResponse
{
    public double Amount { get; set; }
    public string Base { get; set; }
    public DateTime Date { get; set; }
    public Dictionary<string, double> Rates { get; set; }
}