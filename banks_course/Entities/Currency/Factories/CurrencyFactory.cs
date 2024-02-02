using banks_course.Entities.Contracts;

namespace banks_course.Entities.Currency.Factories
{
    public static class CurrencyFactory
    {
        public static List<ICurrency> CreateAllCurrencies(DateTime date)
        {
            List<ICurrency> currencies =
            [
                new Rub(date),
                new Czk(date),
                new Eur(date)
            ];

            return currencies;
        }
    }
}