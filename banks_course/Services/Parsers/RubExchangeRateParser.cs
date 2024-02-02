using banks_course.DTOs.Common;
using banks_course.Services.Contracts;
using banks_course.Services.Parsers.Responses;
using Newtonsoft.Json;

namespace banks_course.Services.Parsers;

public class RubExchangeRateParser : IExchangeRateParser
{
    public void Parse<T>(T dto, string url) where T : BaseDto
        {
            using var client = new HttpClient();
            
            var response = client.GetStringAsync(url).Result;
    
            var responseModel = JsonConvert.DeserializeObject<RubExchangeRateResponse>(response);
    
            if (responseModel != null) BuildDtoFromResponse(dto, responseModel);
        }
    
        private void BuildDtoFromResponse(BaseDto dto, RubExchangeRateResponse responseModel)
        {
            dto.Date = responseModel.Date;
            foreach (var rate in responseModel.Rates)
            {
                dto.ExchangeRates.Add(rate.Key, Math.Round(rate.Value, 4));
            }
        }
}