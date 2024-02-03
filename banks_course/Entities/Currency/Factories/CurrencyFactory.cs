using banks_course.Entities.Contracts;

namespace banks_course.Entities.Currency.Factories
{
    public static class CurrencyFactory
    {
        public static List<ICurrency> CreateAllCurrencies()
        {
            List<ICurrency> currencies =
            [
                new Rub(),
                new Czk(),
                new Eur()
            ];

            return currencies;
        }
    }
}