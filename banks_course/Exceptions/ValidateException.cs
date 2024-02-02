namespace banks_course.Exceptions;

public class ValidateException : Exception
{
    public ValidateException(string message) : base(message)
    {
    }
    
    public static ValidateException BecauseDateIsNotValid(string date)
    {
        string errorMessage = $"Date - ({date}) is not valid. Insert date in YYYY-MM-DD format:";
        return new ValidateException(errorMessage);
    }
    
    public static ValidateException BecauseDateIsEmpty()
    {
        string errorMessage = $"Date is empty. Insert date in YYYY-MM-DD format:";
        return new ValidateException(errorMessage);
    }
}