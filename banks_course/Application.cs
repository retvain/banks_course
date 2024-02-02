using banks_course.Exceptions;
using banks_course.Services.Contracts;
using banks_course.Services.Validators;

namespace banks_course;

public class Application
{
    private IValidator<string?> _dateValidator;

    public void Run()
    {
        Bootstrap();
        DateTime date = GetData();
        // 1 get refs

        // 2 run parsers

        // save in files
    }

    private DateTime GetData()
    {
        string? inputDate;
        Console.Write("Insert date in YYYY-MM-DD format: \n");
        do
        {
            inputDate = Console.ReadLine();
            
            try
            {
                _dateValidator.Validate(inputDate);
                break;
            }
            catch (ValidateException e)
            {
                Console.WriteLine(e.Message);
            }
        } while (true);
        
        DateTime.TryParseExact(inputDate, "yyyy-MM-dd", null, System.Globalization.DateTimeStyles.None, out DateTime result);

        return result;
    }

    private void Bootstrap()
    {
        _dateValidator = new DateValidator();
    }
}