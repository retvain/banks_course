using banks_course.DTOs.Common;
using banks_course.DTOs.CzkDTOs;
using banks_course.DTOs.EurDTOs;
using banks_course.DTOs.RubDTOs;
using banks_course.Entities.Contracts;
using banks_course.Entities.Currency;
using banks_course.Exceptions;

namespace banks_course.DTOs.DtoFactories;

public static class CurrencyDtoFactory
{
    public static BaseDto GetDtoByEntity(ICurrency currencyEntity)
    {
        return currencyEntity switch
        {
            Rub => new RubRateDto(),
            Czk => new CzkRateDto(),
            Eur => new EurRateDto(),
            _ => throw FactoryException.BecauseDtoNotFound(currencyEntity)
        };
    }
}