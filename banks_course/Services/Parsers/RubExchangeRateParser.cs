using banks_course.DTOs.Common;
using banks_course.DTOs.RubDTOs;
using banks_course.Services.Contracts;
using banks_course.Services.Parsers.Responses;
using Newtonsoft.Json;

namespace banks_course.Services.Parsers;

public class RubExchangeRateParser : BaseParser, IExchangeRateParser
{
    public RubExchangeRateParser()
    {
        SourceUrl = Settings.GetSection("RubExchangeRateBaseLink").Value;
    }

    public BaseDto Parse(DateTime date)
    {
        var response = GetResponse(date).GetAwaiter().GetResult();

        var responseModel = JsonConvert.DeserializeObject<RubExchangeRateResponse>(response);

        var dto = BuildDtoFromResponse(responseModel);

        return dto;
    }

    private RubRateDto BuildDtoFromResponse(RubExchangeRateResponse responseModel)
    {
        var dto = new RubRateDto();
        foreach (var rate in responseModel.Rates)
        {
            dto.ExchangeRates.Add(rate.Key, Math.Round(rate.Value, 4));
        }
        
        return dto;
    }
}