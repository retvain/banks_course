using System.Globalization;
using banks_course.DTOs.Common;
using banks_course.DTOs.CzkDTOs;
using banks_course.Services.Contracts;
using banks_course.Services.Parsers.Responses;

namespace banks_course.Services.Parsers;

public class CzkExchangeRateParser : BaseParser, IExchangeRateParser
{
    public CzkExchangeRateParser()
    {
        SourceUrl = Settings.GetSection("CzkExchangeRateBaseLink").Value;
    }
    public BaseDto Parse(DateTime date)
    {
        var response = GetResponse(date).GetAwaiter().GetResult();

        var rates = ParseTextResponse(response);
        
        var dto = BuildDtoFromResponse(rates);

        return dto;
    }

    private CzkRateDto BuildDtoFromResponse(List<CzkExchangeRateResponse> rates)
    {
        var dto = new CzkRateDto();
        foreach (var rate in rates)
        {
            dto.ExchangeRates.Add(rate.Code, rate.Rate);
        }

        return dto;
    }
    
    private List<CzkExchangeRateResponse> ParseTextResponse(string response)
    {
        List<CzkExchangeRateResponse> currencies = [];

        using var reader = new StringReader(response);
        
        // skip first two lines
        reader.ReadLine();
        reader.ReadLine();

        while (reader.ReadLine() is { } line)
        {
            var parts = line.Split('|');

            if (parts.Length == 5)
            {
                currencies.Add(new CzkExchangeRateResponse
                {
                    Country = parts[0].Trim(),
                    Currency = parts[1].Trim(),
                    Amount = int.Parse(parts[2].Trim()),
                    Code = parts[3].Trim(),
                    Rate = double.Parse(parts[4].Trim(), CultureInfo.InvariantCulture)
                });
            }
        }

        return currencies;
    }
    
    // response example
    // 27 Jul 2018 #143
    // Country|Currency|Amount|Code|Rate
    // Australia|dollar|1|AUD|16.255
    // Brazil|real|1|BRL|5.895
    // Bulgaria|lev|1|BGN|13.099
    // Canada|dollar|1|CAD|16.866
    // China|renminbi|1|CNY|3.227
    // Croatia|kuna|1|HRK|3.462
    // Denmark|krone|1|DKK|3.439
    // EMU|euro|1|EUR|25.620
    // Hongkong|dollar|1|HKD|2.808
    // Hungary|forint|100|HUF|7.928
    // Iceland|krona|100|ISK|20.863
    // IMF|SDR|1|XDR|30.984
    // India|rupee|100|INR|32.087
    // Indonesia|rupiah|1000|IDR|1.529
    // Israel|new shekel|1|ILS|6.005
    // Japan|yen|100|JPY|19.821
    // Malaysia|ringgit|1|MYR|5.425
    // Mexico|peso|1|MXN|1.183
    // New Zealand|dollar|1|NZD|14.915
    // Norway|krone|1|NOK|2.687
    // Philippines|peso|100|PHP|41.348
    // Poland|zloty|1|PLN|5.969
    // Romania|leu|1|RON|5.534
    // Russia|rouble|100|RUB|34.973
    // Singapore|dollar|1|SGD|16.154
    // South Africa|rand|1|ZAR|1.664
    // South Korea|won|100|KRW|1.971
    // Sweden|krona|1|SEK|2.487
    // Switzerland|franc|1|CHF|22.092
    // Thailand|baht|100|THB|65.866
    // Turkey|lira|1|TRY|4.524
    // United Kingdom|pound|1|GBP|28.845
    // USA|dollar|1|USD|22.039
}