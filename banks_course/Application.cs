using banks_course.Exceptions;
using banks_course.Services.Contracts;
using banks_course.Services.Validators;

namespace banks_course;

public class Application
{
    private IValidator<string> _dateValidator;

    public void Run()
    {
        Bootstrap();

        // 1 get refs

        // 2 run parsers

        // save in files
    }

    private DateTime GetData()
    {
        DateTime date = default;

        Console.Write("Введите дату в формате YYYY-MM-DD: ");
        do
        {
            string? inputDate = Console.ReadLine();
            
            try
            {
                _dateValidator.Validate(inputDate);
                // todo преобразовать дату в DateTime
                break;
            }
            catch (ValidateException e)
            {
                Console.WriteLine(e.Message);
            }
        } while (true);

        return date;
    }

    private void Bootstrap()
    {
        _dateValidator = new DateValidator();
    }
}