using banks_course.DTOs.Common;
using banks_course.DTOs.EurDTOs;
using banks_course.Services.Contracts;
using banks_course.Services.Parsers.Responses;
using Newtonsoft.Json;

namespace banks_course.Services.Parsers;

public class EurExchangeRateParser : BaseParser, IExchangeRateParser
{
    public EurExchangeRateParser()
    {
        SourceUrl = Settings.GetSection("EurExchangeRateBaseLink").Value;
    }
    
    public BaseDto Parse(DateTime date)
    {
        var response = GetResponse(date).GetAwaiter().GetResult();

        var responseModel = JsonConvert.DeserializeObject<EurExchangeRateResponse>(response);

        var dto = BuildDtoFromResponse(responseModel);

        return dto;
    }

    private EurRateDto BuildDtoFromResponse(EurExchangeRateResponse responseModel)
    {
        var dto = new EurRateDto();
        foreach (var rate in responseModel.Rates)
        {
            dto.ExchangeRates.Add(rate.Key, Math.Round(rate.Value, 4));
        }
        
        return dto;
    }
}