using banks_course.Exceptions;
using banks_course.Services.Contracts;

namespace banks_course.Services.Validators;

public class DateValidator : IValidator<string?>
{
    public void Validate(string? date)
    {
        if (string.IsNullOrEmpty(date))
        {
            throw ValidateException.BecauseDateIsEmpty();
        }

        bool isValidDate = false;
        DateTime dateTime;
        isValidDate = DateTime.TryParseExact(date, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out dateTime);
        
        if (!isValidDate)
        {
            throw ValidateException.BecauseDateIsNotValid(date);
        }
    }
}