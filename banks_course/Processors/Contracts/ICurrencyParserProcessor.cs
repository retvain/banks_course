using banks_course.Entities.Contracts;

namespace banks_course.Processors.Contracts;

public interface ICurrencyParserProcessor
{
    public void Parse(List<ICurrency> currencies, DateTime date);
}