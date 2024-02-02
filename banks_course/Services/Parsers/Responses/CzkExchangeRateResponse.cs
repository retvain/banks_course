namespace banks_course.Services.Parsers.Responses;

public class CzkExchangeRateResponse
{
    public string Country { get; set; }
    public string Currency { get; set; }
    public int Amount { get; set; }
    public string Code { get; set; }
    public double Rate { get; set; }
}