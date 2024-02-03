using banks_course.Entities.Contracts;

namespace banks_course.Processors.Contracts;

public interface ICurrencyFileSaveProcessor
{
    public void SaveCurrencyToExcel(ICurrency currency, DateTime date);
}